using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �d���挳������N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d���挳���̈�����s���܂��B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2007.11.26</br>
	/// </remarks>
	public class PMKOU02033PA
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// �d���挳������N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �d���挳������N���X�̏��������s���V�����C���X�^���X�𐶐����܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public PMKOU02033PA()
		{
		}
		/// <summary>
		/// �d���挳������N���X�R���X�g���N�^(�I�[�o�[���[�h +1)
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �d���挳������N���X�̏��������s���V�����C���X�^���X�𐶐����܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public PMKOU02033PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._supplierLedgerAcs = new SupplierLedgerAcs();
			this._ledgerCmnCndtn     = this._printInfo.jyoken as LedgerCmnCndtn;
			this._pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
			this._sfcmn00331c       = new SFCMN00331C();

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
			}
		}
		#endregion

		//================================================================================
		//  �����萔
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ITEM_INTERVAL        = "�@�@�@�@�@";
		#endregion
		
		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member    
		private SFCMN06002C _printInfo;

        private SupplierLedgerAcs _supplierLedgerAcs = null;
		private LedgerCmnCndtn _ledgerCmnCndtn         = null;
		private Broadleaf.Windows.Forms.SFANL06101UA _pdfHistoryControl = null;
		
		private SFCMN00331C _sfcmn00331c             = null;

		private string _loginSectionCode = "";		// ���O�C�����_�R�[�h	
		#endregion
	
		//================================================================================
		//  �O���񋟃v���p�e�B
		//================================================================================
		#region public property
		#region IPrintProc�̎�����(�v���p�e�B) 
		/// <summary>����f�[�^</summary>
		/// <value>�������f�[�^���擾�܂��͐ݒ肵�܂��B</value>
		public SFCMN06002C Printinfo
		{
			get { return _printInfo; }
			set { _printInfo = value; }
		}
		#endregion
		#endregion
	
		// ===============================================================================
		// ��O�N���X
		// ===============================================================================
		#region ��O�N���X
		private class DemandPrintException: ApplicationException
		{
			private int _status;

			#region constructor
			public DemandPrintException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region public property
			public int Status
			{
				get{return this._status;}
			}
			#endregion
		}
		#endregion
		
		//================================================================================
		//  IPrintProc�̎������@������C������
		//================================================================================
		#region IPrintProc�̎�����
		/// <summary>
		/// ����J�n����
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̊J�n�������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}
		#endregion

		/// <summary>
		/// ������C������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			string message = "";
			try
			{
				// ����t�H�[���N���X�C���X�^���X�쐬
				DataDynamics.ActiveReports.ActiveReport3 prtRpt;

				// ���|�[�g�C���X�^���X�쐬
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt, out message);
				if (status != 0)
				{
					TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
						message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
					return status;
				}

				// ����f�[�^�擾
				DataView dv = (DataView)this._printInfo.rdData;
				// �\�[�g���ݒ�
				dv.Sort = this.GetPrintOderQuerry();
				
				// �f�[�^�\�[�X�ݒ�
				prtRpt.DataSource = dv;

				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				this.SetPrintCommonInfo(out commonInfo);

				// �v���r���[�L��				
				int prevkbn = this._printInfo.prevkbn;
				
				// �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
				if (this._printInfo.printmode == 2)
				{
					prevkbn = 0;
				}
				
				switch(prevkbn)
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

#if true				
				// �o�c�e�o�͂̏ꍇ
				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					switch (this._printInfo.printmode)
					{
						case 1:		// �v�����^
							break;
						case 2:		// �o�c�e
						case 3:		// ����(�v�����^ + �o�c�e)
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
#else
				if (this._printInfo.printmode != 1 && status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					// �o�͗����Ǘ��ɒǉ�
					Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
					pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
						this._printInfo.pdftemppath);

					// PDF�\���t���OON
					this._printInfo.pdfopen = true;
				}
#endif

			}
			catch(Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}

			return status;
		}
	
		/// <summary>
		/// �e��ActiveReport���[�C���X�^���X�쐬
		/// </summary>
		/// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// ����t�H�[���N���X�C���X�^���X�쐬
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), CT_REPORTFORM_NAMESPASE + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}

		/// <summary>
		/// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
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
				throw new DemandPrintException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new DemandPrintException(er.Message, -1);
			}
			return obj;
		}
	
		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt, out string message)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			message = "";

			try
			{
				// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
				IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

				// ��������擾
				LedgerCmnCndtn extraInfo = (LedgerCmnCndtn)this._printInfo.jyoken;

				// �\�[�g���v���p�e�B�ݒ�
				string wrkstr = "";
				switch (extraInfo.PrintOder)
				{
					case 0:
						wrkstr = "[���Ӑ�R�[�h��]";
						break;
					case 1:
						wrkstr = "[���Ӑ�J�i��]";
						break;
					case 2:
						wrkstr = "[�S���ҁ����Ӑ�R�[�h��]";
						break;
					case 3:
						wrkstr = "[�S���ҁ����Ӑ�J�i��]";
						break;
					default:
						break;
				}
				instance.PageHeaderSortOderTitle = wrkstr;

				// �T�u�^�C�g��
				string subTitle = "";
				switch (extraInfo.ListDivCode)
				{
					case 0:
						subTitle = "�x���c";
						break;
					case 1:
						subTitle = "���|�c";
						break;
					default:
						break;
				}
				instance.PageHeaderSubtitle = subTitle;


				// ���[�o�͐ݒ���擾 
				PrtOutSet prtOutSet;
				status = this._supplierLedgerAcs.ReadPrtOutSet(out prtOutSet, out message);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						{
							break;
						}
					default:
						{
							return status;
						}
				}
				// ���o�����w�b�_�o�͋敪
				instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

				// �t�b�^�o�͋敪
				instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

				// �t�b�^�o�̓��b�Z�[�W
				StringCollection footers = new StringCollection();
				footers.Add(prtOutSet.PrintFooter1);
				footers.Add(prtOutSet.PrintFooter2);

				instance.PageFooters = footers;

				// ���̑��֘A�f�[�^�ݒ�
				ArrayList otherDataList = new ArrayList();

				// ���_���󎚗L������
				bool isSectionPrint = true;
				bool isSectionTitlePrint = false;

				// ���_�I�v�V��������
				if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
				{
					isSectionPrint = this.CheackSectionNamePrint(extraInfo);
					isSectionTitlePrint = true;	
				}
				// ���_�I�v�V�����Ȃ�
				else
				{
					isSectionPrint = false;
					isSectionTitlePrint = false;
				}

				otherDataList.Add(isSectionPrint);
				otherDataList.Add(isSectionTitlePrint);

				// �S�̍��ڕ\���ݒ�̎擾
                AlItmDspNm alItmDspNm = this._supplierLedgerAcs.GetAlItmDspNm(this._printInfo.enterpriseCode);
				otherDataList.Add(alItmDspNm);

				instance.OtherDataList = otherDataList;

				// ������I�u�W�F�N�g
				instance.PrintInfo = this._printInfo;

				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
				message = ex.Message;
			}

			return status;
		}
	
		/// <summary>
		/// �󎚏��N�G���쐬����
		/// </summary>
		/// <returns>�쐬�����N�G��</returns>
		/// <remarks>
		/// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private string GetPrintOderQuerry()
		{
			string oderQuerry = "";		
		
			// �󎚏��ݒ�
			switch (this._ledgerCmnCndtn.PrintOder)
			{
				// ���Ӑ�R�[�h��(���_�R�[�h,���Ӑ�R�[�h)
				case 0: 
				{//���_�A�x����A�������A�d����A���t�A�`�[�ԍ���																																				

                    oderQuerry = SupplierLedgerAcs.COL_Spl_AddUpSecCode + "," +
                        //SupplierLedgerAcs.COL_Spl_CustomerCode + "," + 
                        SupplierLedgerAcs.COL_Spl_SupplierCd + "," +
                        SupplierLedgerAcs.COL_Spl_PayeeCode;
                        //SupplierLedgerAcs.COL_Spl_TotalDay + ",";
					break;
				}
				// ���Ӑ�J�i��(���_�R�[�h,���Ӑ�J�i,���Ӑ�R�[�h)
				case 1: 
				{
                    oderQuerry = SupplierLedgerAcs.COL_Spl_AddUpSecCode + "," +
                        //SupplierLedgerAcs.COL_Spl_Kana + "," +
                        SupplierLedgerAcs.COL_Spl_PayeeCode;
                        //SupplierLedgerAcs.COL_Spl_CustomerCode;
					break;
				}
			}
		
			return oderQuerry;
		}
		
		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;
			
			// ���[��
			commonInfo.PrintName   = this._printInfo.prpnm;				
			
			// ������[�h
			commonInfo.PrintMode   = this.Printinfo.printmode;
			
			// �������
			commonInfo.PrintMax    = ((DataView)this._printInfo.rdData).Count;
			
			// PDF�o�̓t���p�X
			string pdfPath = "";
			string pdfName = "";
			this._sfcmn00331c.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			
			string pdfFileName     = System.IO.Path.Combine(pdfPath,pdfName);
			commonInfo.PdfFullPath = pdfFileName;
			this._printInfo.pdftemppath = pdfFileName;
			
			// ��]��
			commonInfo.MarginsTop  = this._printInfo.py;
			
			// ���]��
			commonInfo.MarginsLeft = this._printInfo.px;
		}
		
		/// <summary>
		/// ���_���̈󎚗L���`�F�b�N����
		/// </summary>
		/// <param name="extraInfo">���o�����f�[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : ���_�^�C�g���A���_���̂��󎚂��邩�ǂ����𔻒肵�܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private bool CheackSectionNamePrint(LedgerCmnCndtn extraInfo)
		{
			bool result = false;
            /*
			// �{�Ћ@�\ & �u�S�Ёv���I������Ă���ꍇ
			if (this._supplierLedgerAcs.CheckMainOfficeFunc(this._loginSectionCode) && extraInfo.AddUpSecCode.Equals(CsLedgerDmdAcs.CT_AllSectionCode))
			{
				result = true;
			}
			*/
			return result;
		}
		
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMKOU02033P", iMsg, iSt, iButton, iDefButton);
		}
	
	
	
	
	}
}
