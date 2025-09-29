using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ���|�c����������N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���|�c�������̈�����s���B</br>
	/// <br>Programmer : ��c �h��</br>
	/// <br>Date       : 2007.11.19</br>
    /// <br>Update Note: 2008/12/11 30414 �E �K�j Partsman�p�ɕύX</br>
	/// </remarks>
	class DCKAK02582PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
        /// ���|�c����������N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���|�c����������N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		public DCKAK02582PA()
		{
		}

		/// <summary>
        /// ���|�c����������N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ���|�c����������N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		public DCKAK02582PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._extrInfo_AccPayBalance = this._printInfo.jyoken as ExtrInfo_AccPayBalance;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
		private const string ct_Extr_Top		= "�ŏ�����";
		private const string ct_Extr_End		= "�Ō�܂�";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					                // ������N���X
        private ExtrInfo_AccPayBalance _extrInfo_AccPayBalance;	        // ���o�����N���X
		#endregion �� Private Member

		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class PaymentBalanceException: ApplicationException
		{
			private int _status;
			#region �� Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public PaymentBalanceException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region �� Public Property
			/// <summary> �X�e�[�^�X�v���p�e�B </summary>
			public int Status
			{
				get{ return this._status; }
			}
			#endregion
		}
		#endregion �� Exception Class
		


		#region �� IPrintProc �����o
		#region �� Public Property
		/// <summary>
		/// ������擾�v���p�e�B
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		#endregion �� Public Property

		#region �� Public Method
		#region �� ��������J�n
		/// <summary>
		/// ��������J�n
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ������J�n����B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		public int StartPrint ()
		{
			return PrintMain();
		}
		#endregion
		#endregion �� Public Method
		#endregion �� IPrintProc �����o

		#region �� Private Member
		#region �� �������
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����������s���B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private int PrintMain ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ����t�H�[���N���X�C���X�^���X�쐬
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			try
			{
				// ���|�[�g�C���X�^���X�쐬
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;
							
				// �f�[�^�\�[�X�ݒ�
                //prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                //prtRpt.DataMember = DCKAK02584EA.Col_Tbl_DmdBalance;

                // ����f�[�^�擾
                DataSet ds = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();

                //dv.Table = ds.Tables[DCKAK02584EA.Col_Tbl_DmdBalance];
                dv = ds.Tables[DCKAK02584EA.Col_Tbl_DmdBalance].DefaultView;

                // �\�[�g���ݒ�
                dv.Sort = "AddUpSecCode, PayeeCode, AddUpYearMonth"; //���_�R�[�h�A�d����A���t";

                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = dv;
				
				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
			    this.SetPrintCommonInfo(out commonInfo);

			    // �v���r���[�L��				
			    int mode = this._printInfo.prevkbn;
				
			    // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
			    if (this._printInfo.printmode == 2)
			    {
			        mode = 0;
			    }
				
			    switch(mode)
			    {
			        case 0:		// �v���r����
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();
						
			            // ���ʏ����ݒ�
			            processForm.CommonInfo = commonInfo;

			            // �v���O���X�o�[UP�C�x���g�ǉ�
			            if (prtRpt is IPrintActiveReportTypeCommon)
			            {
			                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
			                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
			            }

			            // ������s
			            status = processForm.Run(prtRpt);

			            // �߂�l�ݒ�
			            this._printInfo.status = status;

			            break;
			        }
			        case 1:		// �v���r���L
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

			            // ���ʏ����ݒ�
			            viewForm.CommonInfo   = commonInfo;

			            // �v���r���[���s
			            status = viewForm.Run(prtRpt); 

			            // �߂�l�ݒ�
			            this._printInfo.status = status;
						
			            break;
			        }
			    }

			    // �o�c�e�o�͂̏ꍇ
			    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			    {
			        switch (this._printInfo.printmode)
			        {
			            case 1:  // �v�����^
			                break;
			            case 2:  // �o�c�e
			            case 3:  // ����(�v�����^ + �o�c�e)
			            {
			                // �o�c�e�\���t���OON
			                this._printInfo.pdfopen = true;
   
			                // ����������̂ݗ���ۑ�
			                if (this._printInfo.printmode == 3)
			                {
			                    // �o�͗����Ǘ��ɒǉ�
			                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
			                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
			                        this._printInfo.pdftemppath);
			                }
			                break;
			            }
			        }
			    }
			}
			catch(Exception ex)
			{
			    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
			        ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
			    if ( prtRpt != null )
			    {
			        prtRpt.Dispose();
			    }
			}
			return status;
		}
		#endregion �� �������

		#region �� ���|�[�g�t�H�[���ݒ�֘A
		#region �� �e��ActiveReport���[�C���X�^���X�쐬
		/// <summary>
		/// �e��ActiveReport���[�C���X�^���X�쐬
		/// </summary>
		/// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// ����t�H�[���N���X�C���X�^���X�쐬
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}
		#endregion

		#region �� ���|�[�g�A�Z���u���C���X�^���X��
		/// <summary>
		/// ���|�[�g�A�Z���u���C���X�^���X��
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(System.IO.FileNotFoundException)
			{
				throw new PaymentBalanceException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new PaymentBalanceException(er.Message, -1);
			}
			return obj;
		}
		#endregion

		#region �� �����ʋ��ʏ��ݒ�

		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
			
			// ���[�`���[�g���ʕ��i�N���X
			SFCMN00331C cmnCommon = new SFCMN00331C(); 

			// PDF�p�X�擾
			string pdfPath = "";
			string pdfName = "";
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;
			// ���[��
			commonInfo.PrintName   = this._printInfo.prpnm;				
			// ������[�h
			commonInfo.PrintMode   = this.Printinfo.printmode;
			// �������
            // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
            //commonInfo.PrintMax = 0;
            commonInfo.PrintMax = (this._printInfo.rdData as DataSet).Tables[DCKAK02584EA.Col_Tbl_DmdBalance].Rows.Count;
            // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// ��]��
			commonInfo.MarginsTop  = this._printInfo.py;
			// ���]��
			commonInfo.MarginsLeft = this._printInfo.px;
		}

		#endregion
		

		#region �� �e��v���p�e�B�ݒ�
		
		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            ExtrInfo_AccPayBalance extraInfo = (ExtrInfo_AccPayBalance)this._printInfo.jyoken;

			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
            int st = DmdBalanceAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new PaymentBalanceException(message, status);
            }
			
			// ���o�����w�b�_�o�͋敪
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// ���o�����ҏW����
			StringCollection extraInfomations;
			this.MakeExtarCondition( out extraInfomations );

			instance.ExtraConditions = extraInfomations; 
			
			// �t�b�^�o�͋敪
			instance.PageFooterOutCode   = prtOutSet.FooterPrintOutCode;

			// �t�b�^�o�̓��b�Z�[�W
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);
			
			instance.PageFooters = footers;

			// ������I�u�W�F�N�g
			instance.PrintInfo = this._printInfo;

            /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
			// �w�b�_�[�T�u�^�C�g��
			instance.PageHeaderSubtitle = this._extrInfo_AccPayBalance.PrintDivName;
               --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/
            
            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region �� ���o�����o�͏��쐬
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			const string ct_RangeConst = "�F{0} �` {1}";
			extraConditions = new StringCollection();

            // ������ -----------------------------------------------------------------------------------------------------------
            string st_Year = string.Empty;
            string ed_Year = string.Empty;
            string st_Month = string.Empty;
            string ed_Month = string.Empty;
            string st_YearMonth = string.Empty;
            string ed_YearMonth = string.Empty;

            // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
            //if (this._extrInfo_AccPayBalance.St_AddUpYearMonth != DateTime.MinValue)
            if (TDateTime.LongDateToDateTime(this._extrInfo_AccPayBalance.St_AddUpYearMonth) != DateTime.MinValue)
            // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
            {
                //st_Year = Convert.ToString(this._extrInfo_DmdBalance.St_AddUpYearMonth / 100);
                //st_Month = Convert.ToString(this._extrInfo_DmdBalance.St_AddUpYearMonth % 100);
                //st_YearMonth = st_Year + "/" + st_Month;

                //st_Year = Convert.ToString(this._extrInfo_AccPayBalance.St_AddUpYearMonth.Year);
                //st_Month = Convert.ToString(this._extrInfo_AccPayBalance.St_AddUpYearMonth.Month);

                //st_YearMonth = st_Year + "/" + st_Month;

                // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                //st_YearMonth = TDateTime.DateTimeToString(ExtrInfo_AccPayBalance.ct_MonthFomat, this._extrInfo_AccPayBalance.St_AddUpYearMonth);
                st_YearMonth = TDateTime.LongDateToString(ExtrInfo_AccPayBalance.ct_MonthFomat, this._extrInfo_AccPayBalance.St_AddUpYearMonth);
                // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
            }
            else
            {
                st_YearMonth = ct_Extr_Top;
            }

            // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
            //if (this._extrInfo_AccPayBalance.Ed_AddUpYearMonth != DateTime.MinValue)
            if (TDateTime.LongDateToDateTime(this._extrInfo_AccPayBalance.Ed_AddUpYearMonth) != DateTime.MinValue)
            // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
            {
                //ed_Year = Convert.ToString(this._extrInfo_DmdBalance.Ed_AddUpYearMonth / 100);
                //ed_Month = Convert.ToString(this._extrInfo_DmdBalance.Ed_AddUpYearMonth % 100);
                //ed_YearMonth = ed_Year + "/" + ed_Month;

                //ed_Year = Convert.ToString(this._extrInfo_AccPayBalance.Ed_AddUpYearMonth.Year);
                //ed_Month = Convert.ToString(this._extrInfo_AccPayBalance.Ed_AddUpYearMonth.Month);

                //ed_YearMonth = ed_Year + "/" + ed_Month;  

                // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                //ed_YearMonth = TDateTime.DateTimeToString(ExtrInfo_AccPayBalance.ct_MonthFomat, this._extrInfo_AccPayBalance.Ed_AddUpYearMonth);
                ed_YearMonth = TDateTime.LongDateToString(ExtrInfo_AccPayBalance.ct_MonthFomat, this._extrInfo_AccPayBalance.Ed_AddUpYearMonth);
                // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
            }
            else
            {
                ed_YearMonth = ct_Extr_End;
            }

            this.EditCondition(ref extraConditions, string.Format("������" + ct_RangeConst, st_YearMonth, ed_YearMonth));

			StringCollection addConditions = new StringCollection();

			// �d���� ----------------------------------------------------------------------------------------------------------------------
            //if ( ( this._extrInfo_DmdBalance.St_PayeeCode != 0 ) || ( this._extrInfo_DmdBalance.Ed_PayeeCode != 999999999 ) )
            //{
            //    this.EditCondition( ref addConditions, 
            //        string.Format( "���Ӑ�R�[�h�F{0} �` {1}", this._extrInfo_DmdBalance.St_PayeeCode, this._extrInfo_DmdBalance.Ed_PayeeCode ));
            //}

            if ((this._extrInfo_AccPayBalance.St_PayeeCode != 0) && (this._extrInfo_AccPayBalance.Ed_PayeeCode != 0))
            {
                // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                //this.EditCondition(ref addConditions,
                //    string.Format("�d����F{0} �` {1}", this._extrInfo_AccPayBalance.St_PayeeCode, this._extrInfo_AccPayBalance.Ed_PayeeCode));
                this.EditCondition(ref addConditions,
                    "�d����F" + this._extrInfo_AccPayBalance.St_PayeeCode.ToString("000000") + " �` " + this._extrInfo_AccPayBalance.Ed_PayeeCode.ToString("000000"));
                // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
            }

            if ((this._extrInfo_AccPayBalance.St_PayeeCode == 0) && (this._extrInfo_AccPayBalance.Ed_PayeeCode != 0))
            {
                // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                //this.EditCondition(ref addConditions,
                //    string.Format("�d����F{0} �` {1}", ct_Extr_Top, this._extrInfo_AccPayBalance.Ed_PayeeCode));
                this.EditCondition(ref addConditions,
                    "�d����F" + ct_Extr_Top + " �` " + this._extrInfo_AccPayBalance.Ed_PayeeCode.ToString("000000"));
                // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
            }

            if ((this._extrInfo_AccPayBalance.St_PayeeCode != 0) && (this._extrInfo_AccPayBalance.Ed_PayeeCode == 0))
            {
                // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
                //this.EditCondition(ref addConditions,
                //    string.Format("�d����F{0} �` {1}", this._extrInfo_AccPayBalance.St_PayeeCode, ct_Extr_End));
                this.EditCondition(ref addConditions,
                    "�d����F" + this._extrInfo_AccPayBalance.St_PayeeCode.ToString("000000") + " �` " + ct_Extr_End);
                // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<
            }

            /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
            // �o�͋��z�敪
            string sOutMoneyDivName = string.Empty; 

            switch (this._extrInfo_AccPayBalance.OutMoneyDiv)
            {
                case ExtrInfo_AccPayBalance.OutMoneyDivState.All:
                    sOutMoneyDivName = ExtrInfo_AccPayBalance.ct_OutMoneyDiv_All;
                    break;
                case ExtrInfo_AccPayBalance.OutMoneyDivState.Minus:
                    sOutMoneyDivName = ExtrInfo_AccPayBalance.ct_OutMoneyDiv_Minus;
                    break;
                case ExtrInfo_AccPayBalance.OutMoneyDivState.Plus:
                    sOutMoneyDivName = ExtrInfo_AccPayBalance.ct_OutMoneyDiv_Plus;
                    break;
                case ExtrInfo_AccPayBalance.OutMoneyDivState.PlusMinus:
                    sOutMoneyDivName = ExtrInfo_AccPayBalance.ct_OutMoneyDiv_PlusMinus;
                    break;
                case ExtrInfo_AccPayBalance.OutMoneyDivState.Zero:
                    sOutMoneyDivName = ExtrInfo_AccPayBalance.ct_OutMoneyDiv_Zero;
                    break;
                case ExtrInfo_AccPayBalance.OutMoneyDivState.ZeroMinus:
                    sOutMoneyDivName = ExtrInfo_AccPayBalance.ct_OutMoneyDiv_ZeroMinus;
                    break;
                case ExtrInfo_AccPayBalance.OutMoneyDivState.ZeroPlus:
                    sOutMoneyDivName = ExtrInfo_AccPayBalance.ct_OutMoneyDiv_ZeroPlus;
                    break;
                default:
                    sOutMoneyDivName = string.Empty;
                    break;
            }
            this.EditCondition(ref addConditions,
                string.Format("�o�͋��z�敪�F{0}", sOutMoneyDivName));
               --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
		}
		#endregion

		#region �� ���o�͈͕�����쐬
		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private string GetConditionRange( string title, string startString, string endString )
		{
			string result = "";
			if ((startString != "") || (endString != ""))
			{
				string start = ct_Extr_Top;
				string end	 = ct_Extr_End;
				if (startString	!= "")	start	= startString;
				if (endString	!= "")	end		= endString;
				result = String.Format(title + "�F {0} �` {1}", start, end);
			}
			return result;
		}
		#endregion

		#region �� ���o����������ҏW
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : ��cb �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// �ҏW�Ώە����o�C�g���Z�o
			int targetByte = TStrConv.SizeCountSJIS(target);
			
			for (int i = 0; i < editArea.Count; i++)
			{
				int areaByte = 0;
				
				// �i�[�G���A�̃o�C�g���Z�o
				if (editArea[i] != null)
				{
					areaByte = TStrConv.SizeCountSJIS(editArea[i]);
				}

				if ((areaByte + targetByte + 2) <= 190)
				{
					isEdit = true;

					// �S�p�X�y�[�X��}��
					if (editArea[i] != null) editArea[i] += ct_Space;
					
					editArea[i]  += target;
					break;
				}
			}
			// �V�K�ҏW�G���A�쐬
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}
		#endregion
		#endregion �� ���|�[�g�t�H�[���ݒ�֘A

		#region �� ���b�Z�[�W�\��

		/// <summary>
		/// ���b�Z�[�W�\��
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="iMsg">�G���[���b�Z�[�W</param>
		/// <param name="iSt">�X�e�[�^�X</param>
		/// <param name="iButton">�\���{�^��</param>
		/// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
		/// <br>Programmer : ��c �h��</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCKAK02582P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
