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
	/// UOE�����񓚈ꗗ�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : UOE�����񓚈ꗗ�\�̈�����s���B</br>
	/// <br>Programmer : �Ɠc �M�u</br>
	/// <br>Date       : 2008/11/10</br>
	/// </remarks>
	class PMUOE04205PA: IPrintProc
	{
        #region ���萔�A�ϐ���
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";

        private SFCMN06002C _printInfo;					                // ������N���X
        private UOEAnswerLedgerOrderCndtn _uoeAnswerLedgerOrderCndtn;   // ���o�����N���X
        #endregion

        #region ��Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �C���X�^���X�̏��������s���B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public PMUOE04205PA()
		{
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �C���X�^���X�̏��������s���B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		public PMUOE04205PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;                                             // ������
            this._uoeAnswerLedgerOrderCndtn = this.Printinfo.jyoken as UOEAnswerLedgerOrderCndtn;   // ���o����
		}
		#endregion ��Constructor - end

		#region ��Exception�N���X
		/// <summary> ��O�N���X </summary>
        private class StockMoveException: ApplicationException
		{
			private int _status;
			#region ��Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public StockMoveException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region ��Public Property
			/// <summary> �X�e�[�^�X�v���p�e�B </summary>
			public int Status
			{
				get{ return this._status; }
			}
			#endregion
		}
		#endregion ��Exception�N���X - end

		#region ��IPrintProc �����o
		#region ��Public Property
		/// <summary> ������擾�v���p�e�B </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		#endregion ��Public Property - end

        #region ��StartPrint(��������J�n)
        /// <summary>
		/// ��������J�n
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ������J�n���܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public int StartPrint ()
		{
			return PrintMain();
		}
		#endregion
		#endregion �� IPrintProc �����o - end

		#region ��Private
        #region ��PrintMain(�������)
        /// <summary>
		/// �������
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����������s���B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private int PrintMain()
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
				prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = DCHAT02104EA.ct_Tbl_OrderList;
				
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
        #endregion

        #region ��CreateReport(�e��ActiveReport���[�C���X�^���X�쐬)
        /// <summary>
		/// �e��ActiveReport���[�C���X�^���X�쐬
		/// </summary>
		/// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// ����t�H�[���N���X�C���X�^���X�쐬
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}
		#endregion

        #region ��LoadAssemblyReport(���|�[�g�A�Z���u���C���X�^���X��)
        /// <summary>
		/// ���|�[�g�A�Z���u���C���X�^���X��
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
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
				throw new StockMoveException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new StockMoveException(er.Message, -1);
			}
			return obj;
		}
		#endregion

        #region ��SetPrintCommonInfo(�����ʋ��ʏ��ݒ�)
        /// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
            SFCMN00331C cmnCommon = new SFCMN00331C();  // ���[�`���[�g���ʕ��i�N���X

            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
            commonInfo.PrinterName = this._printInfo.prinm;                     // �v�����^��
            commonInfo.PrintName = this._printInfo.prpnm;		                // ���[��
            commonInfo.PrintMode = this.Printinfo.printmode;                    // ������[�h
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;   // �������
            commonInfo.MarginsTop = this._printInfo.py;                         // ��]��
            commonInfo.MarginsLeft = this._printInfo.px;                        // ���]��

            // PDF�p�X�擾
            string pdfPath = "";
            string pdfName = "";

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);

			this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;               // PDF�p�X
		}

		#endregion

        #region ��SettingProperty(�e��v���p�e�B�ݒ�)
        /// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            UOEAnswerLedgerOrderCndtn extraInfo = (UOEAnswerLedgerOrderCndtn)this._uoeAnswerLedgerOrderCndtn;

			// �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = string.Empty;
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = OrderListAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new StockMoveException(message, status);
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

			// �w�b�_�[�^�C�g��
            object[] titleObj = new object[] { _printInfo.prpnm };
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);

			// ���̑��f�[�^
			instance.OtherDataList = null;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}
		#endregion

        #region ��MakeExtarCondition(���o�����o�͏��쐬)
        /// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // �����敪
            this.EditCondition(ref addConditions, String.Format("�����敪�F{0}", this._uoeAnswerLedgerOrderCndtn.SystemDivName));
            // ������
            if (this._uoeAnswerLedgerOrderCndtn.UOESupplierCd != 0)
            {
                this.EditCondition(ref addConditions,
                    String.Format("������F{0} {1}", this._uoeAnswerLedgerOrderCndtn.UOESupplierCd.ToString("000000"), this._uoeAnswerLedgerOrderCndtn.UOESupplierName));
            }
            // ���Ӑ�
            if (this._uoeAnswerLedgerOrderCndtn.CustomerCode != 0)
            {
                this.EditCondition(ref addConditions,
                    String.Format("���Ӑ�F{0} {1}", this._uoeAnswerLedgerOrderCndtn.CustomerCode.ToString("00000000"), this._uoeAnswerLedgerOrderCndtn.CustomerName));
            }
            // ��M���t
            this.EditCondition(ref addConditions,
                GetExtarConditionOfDates("��M��", this._uoeAnswerLedgerOrderCndtn.St_ReceiveDate, this._uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate));

            // �ǉ�
            foreach ( string exCondStr in addConditions ) {
                extraConditions.Add(exCondStr);
            }
        }
        #endregion

        #region ��GetExtarConditionOfDates(���t�͈͕�����쐬)
        /// <summary>
        /// ���t�͈̔͏��������񐶐�
        /// </summary>
        /// <param name="dateTitle">���t�^�C�g��</param>
        /// <param name="stDate">�J�n���t</param>
        /// <param name="edDate">�I�����t</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���t�o�͎��̕�������쐬����B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private string GetExtarConditionOfDates(string dateTitle, DateTime stDate, DateTime edDate)
        {
            string wkStDate = string.Empty;
            string wkEdDate = string.Empty;

            string resultString = string.Empty;

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ( ( stDate != DateTime.MinValue ) || ( edDate != DateTime.MinValue ) ) {
                // �J�n
                if ( stDate != DateTime.MinValue ) {
                    wkStDate = stDate.ToString("yyyy/MM/dd");
                }
                else {
                    wkStDate = ct_Extr_Top;
                }

                // �I��
                if ( edDate != DateTime.MinValue ) {
                    wkEdDate = edDate.ToString("yyyy/MM/dd");
                }
                else {
                    wkEdDate = ct_Extr_End;
                }

                resultString = string.Format( dateTitle + ct_RangeConst, wkStDate, wkEdDate);
            }

            return resultString;
        }
		#endregion

        #region ��GetConditionRange(���o�͈͕�����쐬)
        /// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
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
				result = String.Format(title + ct_RangeConst, start, end);
			}
			return result;
		}
		#endregion

        #region ��EditCondition(���o����������ҏW)
        /// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
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

        #region ��MsgDispProc(���b�Z�[�W�\��)
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
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMUOE04205P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
        #endregion ��Private - end
    }
}
