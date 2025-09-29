#define  CHG20060417
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;


using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows; 
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �I���ߕs���X�V�G���[���X�g����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I���ߕs���X�V�G���[���X�g�̈�����s���܂��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.07.19</br>
	/// </remarks>
	public class MAZAI05167PA
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		public MAZAI05167PA()
		{
		}
		/// <summary>
		/// �I���ߕs���X�V�G���[���X�g����N���X�R���X�g���N�^(�I�[�o�[���[�h +1)
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �I���ߕs���X�V�G���[���X�g����N���X�̏��������s���V�����C���X�^���X�𐶐����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		public MAZAI05167PA(object printInfo)
		{
			this._printInfo       = printInfo as SFCMN06002C;
		}
		#endregion
	
		//================================================================================
		//  �����萔
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ASSEMBLY_ID = "MAZAI05167P";
		#endregion
	
		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member    
		private SFCMN06002C _printInfo               = null;
		private PrtOutSetAcs _prtOutSetAcs;
		#endregion
	
		//================================================================================
		//  IPrintProc�̃����o
		//================================================================================
		#region IPrintProc �����o
		public SFCMN06002C Printinfo
		{
			get
			{
				return this._printInfo;
			}
			set
			{
				this._printInfo = value;
			}
		}
		#endregion
	
		// ===============================================================================
		// ��O�N���X
		// ===============================================================================
		#region ��O�N���X
		private class InventoryErrorDataPrintException: ApplicationException
		{
			private int _status;

			#region constructor
			public InventoryErrorDataPrintException(string message, int status)
				: base(message)
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
		/// ������C������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}
		#endregion
		
		//================================================================================
		//  ��������
		//================================================================================
		#region private method        
		/// <summary>
		/// ������C������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// ����pDataSet�̎擾
				InventoryUpdateDataSet.ErrorDataDataTable dt = (InventoryUpdateDataSet.ErrorDataDataTable)this._printInfo.rdData;
				
				// ����pDataView�̍쐬
				DataView dv = dt.DefaultView;

				// ���|�[�g�C���X�^���X�̍쐬
				this.CreateReport(out prtRpt, this._printInfo.prpid);
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt);
				if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

				// �w�i�摜�L���ݒ�
				if (prtRpt is IPrintActiveReportTypeCommon)
				{
					((IPrintActiveReportTypeCommon)prtRpt).WatermarkMode  = 0;
				}
					
				// �f�[�^�\�[�X�ݒ�
				prtRpt.DataSource  = dv;
					
				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				this.SetPrintCommonInfo(out commonInfo);

				// ��������ݒ�
				commonInfo.PrintMax = dv.Count; 
					
				// �v���r���[�L��				
				int prevkbn = this._printInfo.prevkbn;
				
				// �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
				if (this._printInfo.printmode == 2)
				{
					prevkbn = 0;
				}

				switch (prevkbn)
				{
					case 0:		// �v���r���[�Ȃ�
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
						status = processForm.Run(prtRpt,true);

						// �߂�l�ݒ�
						this._printInfo.status = status;

						break;
					}
					case 1:		// �v���r���[����
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
					default:
						break;
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
#if false		// ���̂Ƃ���o�c�e�o�͖͂�

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
#endif
							break;
						}
					}
				}

				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch (InventoryErrorDataPrintException ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message ,
					-1, MessageBoxButtons.OKCancel,MessageBoxDefaultButton.Button1);
			}
			catch (Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message + "\n\r" + ex.StackTrace,
					-1, MessageBoxButtons.OKCancel,MessageBoxDefaultButton.Button1);
			}
			finally
			{
				if ( prtRpt != null ){ prtRpt.Dispose(); }
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
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
				else 
				{
					throw new InventoryErrorDataPrintException(classname + "�����݂��܂���B",-1);				
				}
			}
			catch(System.IO.FileNotFoundException)
			{
				throw new InventoryErrorDataPrintException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new InventoryErrorDataPrintException(er.Message, -1);
			}
			return obj;
		}

		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// �\�[�g���v���p�e�B�ݒ�
			instance.PageHeaderSortOderTitle = "";

			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet = null;
			try
			{
				//string message;
				this._prtOutSetAcs = new PrtOutSetAcs();
				string sectionCode = string.Empty;

				if (LoginInfoAcquisition.Employee != null)
					sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

				status = this._prtOutSetAcs.Read(out prtOutSet, LoginInfoAcquisition.EnterpriseCode, sectionCode);
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
							throw new InventoryErrorDataPrintException("���[�o�͐ݒ�̓Ǎ����ɗ�O���������܂����B", status);
						}
				}
			}
			catch (Exception)
			{
			}

			// ���o�����w�b�_�o�͋敪
			if (prtOutSet != null)
				instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// �t�b�^�o�͋敪
			if (prtOutSet != null)
				instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

			// �t�b�^�o�̓��b�Z�[�W
			StringCollection footers = new StringCollection();
			
			if (prtOutSet != null)
			{
				footers.Add(prtOutSet.PrintFooter1);
				footers.Add(prtOutSet.PrintFooter2);
			}

			instance.PageFooters = footers;

			// ������I�u�W�F�N�g
			instance.PrintInfo = this._printInfo;

			// ���̑��f�[�^

			// ���_�I�v�V�����L���`�F�b�N
			bool isSection = false;
			if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
			{
				isSection = true;
			}

			ArrayList otherData = new ArrayList();
			otherData.Add(isSection);

			instance.OtherDataList = otherData;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		
		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;
			
			// ���[��
			commonInfo.PrintName   = this._printInfo.prpnm;				
				
			// ������[�h
			commonInfo.PrintMode   = this._printInfo.printmode;
			
			// �]���ݒ�
			// ���ʒu
			commonInfo.MarginsLeft = this.Printinfo.px;
			
			// �s�ʒu
			commonInfo.MarginsTop  = this.Printinfo.py;

			// ���[�t�H�[��ID
			commonInfo.OutputFormID = this._printInfo.prpid;

			// �󎚈ʒu����
			commonInfo.PrintPositionAdjust = 0;
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.07.19</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, CT_ASSEMBLY_ID, iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		
	}
}
