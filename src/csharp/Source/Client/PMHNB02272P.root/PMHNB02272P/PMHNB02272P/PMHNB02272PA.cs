//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���|�c���ꗗ�\(����)
// �v���O�����T�v   : ���|�c���ꗗ�\(����)�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

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
    /// ���|�c���ꗗ�\(����)����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���|�c���ꗗ�\(����)�̈�����s���B</br>
	/// <br></br>
    /// </remarks>
	class PMHNB02272PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
        /// ���|�c���ꗗ�\(����)����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���|�c���ꗗ�\(����)����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br></br>
        /// </remarks>
		public PMHNB02272PA()
		{
		}

		/// <summary>
        /// ���|�c���ꗗ�\(����)����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ���|�c���ꗗ�\(����)����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br></br>
        /// </remarks>
		public PMHNB02272PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._sumExtrInfo_BillBalance = this._printInfo.jyoken as SumExtrInfo_BillBalance;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					            // ������N���X
        private SumExtrInfo_BillBalance _sumExtrInfo_BillBalance;	// ���o�����N���X
		#endregion �� Private Member

        private string CT_Sort1_Odr = "AddUpSecCode, ClaimCode";                        // ���_+���Ӑ�
        private string CT_Sort2_Odr = "AddUpSecCode, AgentCd, ClaimCode"; �@            // ���_+�S����+���Ӑ�
        private string CT_Sort3_Odr = "AddUpSecCode, SalesAreaCode, ClaimCode";         // ���_+�n��+���Ӑ�

		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class SumBillBalanceException: ApplicationException
		{
			private int _status;
			#region �� Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public SumBillBalanceException(string message, int status): base(message)
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
        /// <br></br>
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
        /// <br></br>
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
							
				// ����f�[�^�擾
                DataSet ds = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv.Table = ds.Tables[PMHNB02274EA.Col_Tbl_SumBillBalance];

                // �\�[�g���ݒ�
                dv.Sort = this.GetPrintOderQuerry();

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
        /// <br></br>
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
        /// <br></br>
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
				throw new SumBillBalanceException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new SumBillBalanceException(er.Message, -1);
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
        /// <br></br>
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
            int maxCount = 0;
            foreach (object obj in (this._printInfo.rdData as DataSet).Tables)
            {
                if (obj is DataTable && (obj as DataTable).TableName == PMHNB02274EA.Col_Tbl_SumBillBalance)
                {
                    maxCount = (obj as DataTable).Rows.Count;
                    break;
                }
            }
            commonInfo.PrintMax = maxCount;
            
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
        /// <br></br>
        /// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            SumExtrInfo_BillBalance extraInfo = (SumExtrInfo_BillBalance)this._printInfo.jyoken;

			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
            int st = SumBillBalanceAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new SumBillBalanceException(message, status);
            }
			
			// ���o�����w�b�_�o�͋敪
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// ���o�����ҏW����
			StringCollection extraInfomations;
			this.MakeExtarCondition( out extraInfomations );

			instance.ExtraConditions = extraInfomations;

            // �\�[�g���̏o��
            string sortTitle = "";
            this.SORTTITLE(out sortTitle);

            instance.PageHeaderSortOderTitle = sortTitle;
            
			// �t�b�^�o�͋敪
			instance.PageFooterOutCode   = prtOutSet.FooterPrintOutCode;

			// �t�b�^�o�̓��b�Z�[�W
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);
			
			instance.PageFooters = footers;

			// ������I�u�W�F�N�g
			instance.PrintInfo = this._printInfo;

			// �w�b�_�[�T�u�^�C�g��
			instance.PageHeaderSubtitle = this._sumExtrInfo_BillBalance.PrintDivName;

			// ���̑��f�[�^
			ArrayList otherDataList = new ArrayList();

			// �S�Ђ��I������Ă����疾�ׂɋ��_���̂��o���B
			if ( this._sumExtrInfo_BillBalance.IsSelectAllSection )
			{
				otherDataList.Add("�v�㋒�_");		    // ���׋��_���̃^�C�g��
			}
			else
			{
				otherDataList.Add( string.Empty );		// ���׋��_���̃^�C�g��
			}
			instance.OtherDataList = otherDataList;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

        #region ���@�\�[�g���o��
        /// <summary>
        /// �\�[�g���o��
        /// </summary>
        /// <param name="sorttitle">�\�[�g���o��</param>
        /// <remarks>
        /// <br> �\�[�g���̏o�͂��쐬���܂��B</br>
        /// </remarks>
        private void SORTTITLE(out string sorttitle)
        {
            // �\�[�g��
            sorttitle = "[" + this._sumExtrInfo_BillBalance.SortOrderDivName + "]";
        }
        #endregion

		#region �� ���o�����o�͏��쐬
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br></br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			extraConditions = new StringCollection();

			// ������ -----------------------------------------------------------------------------------------------------------
            string year = string.Empty;
            string month = string.Empty;
            string yearMonth = string.Empty;

            StringCollection addConditions = new StringCollection();
            if (this._sumExtrInfo_BillBalance.AddUpYearMonth != DateTime.MinValue)
            {
                // �J�n
                if (this._sumExtrInfo_BillBalance.AddUpYearMonth != DateTime.MinValue)
                {
                    yearMonth = TDateTime.DateTimeToString("YYYY/MM", this._sumExtrInfo_BillBalance.AddUpYearMonth);
                }
            }

            this.EditCondition(ref addConditions, string.Format("�������F{0}", yearMonth));

            // �S����
            if ((this._sumExtrInfo_BillBalance.St_EmployeeCode == "") && (this._sumExtrInfo_BillBalance.Ed_EmployeeCode != ""))
            {
                this.EditCondition(ref addConditions, string.Format("�S���ҁF{0} �` {1}", ct_Extr_Top, this._sumExtrInfo_BillBalance.Ed_EmployeeCode));
            }

            if ((this._sumExtrInfo_BillBalance.St_EmployeeCode != "") && (this._sumExtrInfo_BillBalance.Ed_EmployeeCode == ""))
            {
                this.EditCondition(ref addConditions, string.Format("�S���ҁF{0} �` {1}", this._sumExtrInfo_BillBalance.St_EmployeeCode, ct_Extr_End));
            }

            if ((this._sumExtrInfo_BillBalance.St_EmployeeCode != "") && (this._sumExtrInfo_BillBalance.Ed_EmployeeCode != ""))
            {
                this.EditCondition(ref addConditions, string.Format("�S���ҁF{0} �` {1}", this._sumExtrInfo_BillBalance.St_EmployeeCode, this._sumExtrInfo_BillBalance.Ed_EmployeeCode));
            }

            // �n��
            if ((this._sumExtrInfo_BillBalance.St_SalesAreaCode == 0) && (this._sumExtrInfo_BillBalance.Ed_SalesAreaCode != 0))
            {
                this.EditCondition(ref addConditions, string.Format("�n��F{0} �` {1}", ct_Extr_Top, this._sumExtrInfo_BillBalance.Ed_SalesAreaCode.ToString("d04")));
            }

            if ((this._sumExtrInfo_BillBalance.St_SalesAreaCode > 0) && (this._sumExtrInfo_BillBalance.Ed_SalesAreaCode == 0))
            {
                this.EditCondition(ref addConditions, string.Format("�n��F{0} �` {1}", this._sumExtrInfo_BillBalance.St_SalesAreaCode.ToString("d04"), ct_Extr_End));
            }

            if ((this._sumExtrInfo_BillBalance.St_SalesAreaCode > 0) && (this._sumExtrInfo_BillBalance.Ed_SalesAreaCode != 0))
            {
                this.EditCondition(ref addConditions, string.Format("�n��F{0} �` {1}", this._sumExtrInfo_BillBalance.St_SalesAreaCode.ToString("d04"), this._sumExtrInfo_BillBalance.Ed_SalesAreaCode.ToString("d04")));
            }

            // ���Ӑ�R�[�h ----------------------------------------------------------------------------------------------------
            if ((this._sumExtrInfo_BillBalance.St_ClaimCode != 0) || (this._sumExtrInfo_BillBalance.Ed_ClaimCode != 0))
            {
                string st_ClaimCode_Top = string.Empty;
                string ed_ClaimCode_End = string.Empty;

                if (this._sumExtrInfo_BillBalance.St_ClaimCode == 0)
                {
                    st_ClaimCode_Top = ct_Extr_Top;
                }
                else
                {
                    st_ClaimCode_Top = this._sumExtrInfo_BillBalance.St_ClaimCode.ToString("d08");
                }

                if (this._sumExtrInfo_BillBalance.Ed_ClaimCode == 0)
                {
                    ed_ClaimCode_End = ct_Extr_End;
                }
                else
                {
                    ed_ClaimCode_End = this._sumExtrInfo_BillBalance.Ed_ClaimCode.ToString("d08");
                }

                this.EditCondition(ref addConditions, string.Format("���Ӑ�F{0} �` {1}", st_ClaimCode_Top, ed_ClaimCode_End));
            }
            
            // �o�͋��z�敪
            string sOutMoneyDivName = string.Empty;

            switch ((SumExtrInfo_BillBalance.OutMoneyDivState)this._sumExtrInfo_BillBalance.OutMoneyDiv)
            {
                case SumExtrInfo_BillBalance.OutMoneyDivState.All:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_All;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.Minus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_Minus;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.Plus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_Plus;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.PlusMinus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_PlusMinus;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.Zero:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_Zero;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.ZeroMinus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_ZeroMinus;
                    break;
                case SumExtrInfo_BillBalance.OutMoneyDivState.ZeroPlus:
                    sOutMoneyDivName = SumExtrInfo_BillBalance.ct_OutMoneyDiv_ZeroPlus;
                    break;
                default:
                    sOutMoneyDivName = string.Empty;
                    break;
            }
            this.EditCondition(ref addConditions,
                string.Format("�o�͋��z�敪�F{0}", sOutMoneyDivName));

            // ��������
            if (this._sumExtrInfo_BillBalance.DepoDtlDiv == 0)
            {
                this.EditCondition(ref addConditions, "��������F�󎚂���");
            }
            else
            {
                this.EditCondition(ref addConditions, "��������F�󎚂��Ȃ�");
            }
            
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
        /// <br></br>
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
        /// <br></br>
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

        #region ���@������N�G���쐬�֐�
        /// <summary>
        /// �󎚏��N�G���쐬����
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        /// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch ((SumExtrInfo_BillBalance.SortOrderDivState)this._sumExtrInfo_BillBalance.SortOrderDiv)
            {
                case SumExtrInfo_BillBalance.SortOrderDivState.CustomerCode:
                    {
                        oderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case SumExtrInfo_BillBalance.SortOrderDivState.EmployeeCode:
                    {
                        oderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case SumExtrInfo_BillBalance.SortOrderDivState.SalesAreaCode:
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }                
            }

            return oderQuerry;
        }
        #endregion

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
        /// <br></br>
        /// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMHNB02272P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
