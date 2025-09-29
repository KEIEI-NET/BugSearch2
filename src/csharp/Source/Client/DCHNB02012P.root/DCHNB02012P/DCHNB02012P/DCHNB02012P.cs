#define CHG20060329
#define CHG20060410
#define CHG20060418
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

using Broadleaf.Application.Remoting.ParamData;
using DataDynamics.ActiveReports;

namespace Broadleaf.Drawing.Printing
{
    /// public class name:   DCHNB02012PA
    /// <summary>
    ///                      �󒍁E�ݏo�m�F�\����N���X
    /// </summary>
    /// <remarks>
    /// �󒍁E�ݏo�m�F�\����N���X
    /// </remarks>
    public class DCHNB02012PA
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
        /// <summary>
        /// �󒍁E�ݏo�m�F�\����N���X�R���X�g���N�^�[
        /// </summary>
        public DCHNB02012PA()
		{
		}

        /// <summary>
        /// �󒍁E�ݏo�m�F�\����N���X�R���X�g���N�^�[
        /// </summary>
        public DCHNB02012PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
			
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

            this._csSaleOrderPara = this._printInfo.jyoken as ExtrInfo_DCHNB02013E;

            this.SelectTableName();

        }
		#endregion

		//================================================================================
		//  �����萔
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ITEM_INTERVAL        = "�@";

        // 2008.08.01 30413 ���� ���o�����̒萔�ǉ� >>>>>>START
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
        // 2008.08.01 30413 ���� ���o�����̒萔�ǉ� <<<<<<END
        
		#endregion
		
		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member    
		private SFCMN06002C     _printInfo           = null;
		private PdfHistoryControl _pdfHistoryControl = null;
		private SFCMN00331C _sfcmn00331C             = null;			// ���[�n���ʕ��i
        private ExtrInfo_DCHNB02013E _csSaleOrderPara = null;

        #endregion

		/// <summary>�\������</summary>
	
		private string CT_Sort1_Odr01 = "SectionCode, SalesDate, SalesSlipNum, SalesRowNo ";	//�i���_�j�{�󒍓��{�`�[�ԍ��{�s�ԍ�
		private string CT_Sort1_Odr02 = "SectionCode, ShipmentDay, SalesSlipNum, SalesRowNo ";	//�i���_�j�{�ݏo���{�`�[�ԍ��{�s�ԍ�
        // 2008.08.01 30413 ���� �\�[�g���ʂ̏C�� >>>>>>START
        //private string CT_Sort2_Odr = "SectionCode,SalesSlipNum";									//�i���_�j�{�`�[�ԍ�
        //private string CT_Sort3_Odr = "SectionCode,CustomerCode, SalesSlipNum";					//�i���_�j�{���Ӑ�{�`�[�ԍ�
        //private string CT_Sort4_Odr = "SectionCode,SalesEmployeeCd, SalesSlipNum";				//�i���_�j�{�̔��]�ƈ�(�S����)�R�[�h�{�`�[�ԍ�
        private string CT_Sort2_Odr = "SectionCode, SalesSlipNum, SearchSlipDate, SalesRowNo";						//�i���_�j�{�`�[�ԍ��{�`�[���t(���͓�)�{�s�ԍ�
        private string CT_Sort3_Odr = "SectionCode, CustomerCode, SalesSlipNum, SearchSlipDate, SalesRowNo";		//�i���_�j�{���Ӑ�{�`�[�ԍ��{�`�[���t(���͓�)�{�s�ԍ�
        private string CT_Sort4_Odr = "SectionCode, SalesEmployeeCd, SalesSlipNum, SearchSlipDate, SalesRowNo";		//�i���_�j�{�̔��]�ƈ�(�S����)�R�[�h�{�`�[�ԍ��{�`�[���t(���͓�)�{�s�ԍ�
        // 2008.08.01 30413 ���� �\�[�g���ʂ̏C�� <<<<<<END
        
		
		private string CT_Sort1_OdrStr01 = "[�󒍓��{�`�[�ԍ�]";				//�󒍕\�̏ꍇ
        // 2008.08.01 30413 ���� �o�ד����ݏo���ɏC�� >>>>>>START
        //private string CT_Sort1_OdrStr02 = "[�o�ד��{�`�[�ԍ��{�s�ԍ�]";				//�o�ו\�̏ꍇ
        private string CT_Sort1_OdrStr02 = "[�ݏo���{�`�[�ԍ�]";				//�ݏo�\�̏ꍇ
        // 2008.08.01 30413 ���� �o�ד����ݏo���ɏC�� <<<<<<END
        private string CT_Sort2_OdrStr = "[�`�[�ԍ�]";
		private string CT_Sort3_OdrStr = "[���Ӑ�{�`�[�ԍ�]";
		private string CT_Sort4_OdrStr = "[�S���ҁ{�`�[�ԍ�]";


        // �f�[�^�擾���e�[�u����
        private string ct_TableName;

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
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}
		#endregion

		//================================================================================
		// �����֐�
		//================================================================================
		#region Private Methods
		#region ���@������C������
		/// <summary>
		/// ������C������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			try
			{
				// ����t�H�[���N���X�C���X�^���X�쐬
				DataDynamics.ActiveReports.ActiveReport3 prtRpt;

				// ���|�[�g�C���X�^���X�쐬
				this.CreateReport(out prtRpt, this._printInfo.prpid);
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;

				// ����f�[�^�擾�B�\�[�g�����f�[�^��DataView�ɓ����B
				DataSet ds = (DataSet)this._printInfo.rdData;
				DataView dv = new DataView();
				dv.Table = ds.Tables[ct_TableName];

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

			}
			catch(DemandPrintException ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, ex.Status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			catch(Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}

			return status;
		}

        /// <summary>
        /// �d�l�e�[�u�����ݒ菈��
        /// </summary>
        private void SelectTableName()
        {
			ct_TableName = DCHNB02014EA.CT_OrderConfDataTable;
        }

		#endregion
	
		#region ���@ActiveReport���[�C���X�^���X�쐬�֘A
		/// <summary>
		/// �e��ActiveReport���[�C���X�^���X�쐬
		/// </summary>
		/// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// ����t�H�[���N���X�C���X�^���X�쐬
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(	prpid.Trim(), CT_REPORTFORM_NAMESPASE + "." + prpid.Trim(), 
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
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				
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
		#endregion
	
		#region ���@AvtiveReport�Ɋe��v���p�e�B��ݒ肵�܂�
		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// �e��v���p�e�B��ݒ肵�܂��B<br/>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = SaleConfAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0)
			{
				throw new DemandPrintException(message, status);
			}
			
			// ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

			// �\�[�g���̏o��
			string sortTitle = "";
			this.SORTTITLE(out sortTitle);

			instance.PageHeaderSortOderTitle = sortTitle;

			//�w�e�����`�F�b�N���X�g�͈́x�̏o��
			string marginMark = "";
			this.MARGINMARK(out marginMark);

			instance.PageHeaderSubtitle = marginMark;

			// �t�b�^�o�͋敪
			instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

			// �t�b�^�o�̓��b�Z�[�W�i�ŉ����r���j
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);

			instance.PageFooters = footers;

			// ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

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
			string wrkstr = "";
			sorttitle = "";
			switch (this._csSaleOrderPara.SortOrder)
			{
				case 0:
					{
						if (this._csSaleOrderPara.AcptAnOdrStatus == 20)
						{
							wrkstr = CT_Sort1_OdrStr01;
						}
						else
						{
							wrkstr = CT_Sort1_OdrStr02;
						}
						break;
					}
				case 1:
					{
						wrkstr = CT_Sort2_OdrStr;
						break;
					}
				case 2:
					{
						wrkstr = CT_Sort3_OdrStr;
						break;
					}
				case 3:
					{
						wrkstr = CT_Sort4_OdrStr;
						break;
					}
			}

			sorttitle = wrkstr;

		}
		#endregion
		#region ���@�w�e�����`�F�b�N���X�g�͈́x�o�͍쐬
		/// <summary>
		/// �w�e�����`�F�b�N���X�g�͈́x�o�͍쐬
		/// </summary>
		/// <param name="marginmark">�w�e�����`�F�b�N���X�g�͈́x�o�͍쐬</param>
		/// <remarks>
		/// <br> �w�e�����`�F�b�N���X�g�͈́x���쐬���܂��B</br>
		/// </remarks>

		private void MARGINMARK(out string marginmark)
		{
			string mark1 = this._csSaleOrderPara.GrossMargin1Mark;
			string mark2 = this._csSaleOrderPara.GrossMargin2Mark;
			string mark3 = this._csSaleOrderPara.GrossMargin3Mark;
			string mark4 = this._csSaleOrderPara.GrossMargin4Mark;
			string grsLower = this._csSaleOrderPara.GrsProfitCheckLower.ToString();
			string grsBest = this._csSaleOrderPara.GrsProfitCheckBest.ToString();
			string grsUpper = this._csSaleOrderPara.GrsProfitCheckUpper.ToString();

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //string marginExpra1 = mark1 + "�F" + grsLower + "�������@�@";
            //string marginExpra2 = mark2 + "�F" + grsLower + "���ȏ�  �`  " + grsBest + "�������@�@";
            //string marginExpra3 = mark3 + "�F" + grsBest + "���ȏ�  �`  " + grsUpper + "�������@�@";
            //string marginExpra4 = mark4 + "�F" + grsUpper + "���ȏ�";
            // --- DEL 2009/03/30 -------------------------------->>>>>
            // --- ADD 2009/03/30 -------------------------------->>>>>
            string marginExpra1 = grsLower + "������" + "�F" + mark1 + "�@�@";
            string marginExpra2 = grsLower + "���ȏ�  �`  " + grsBest + "������" + "�F" + mark2 + "�@�@";
            string marginExpra3 = grsBest + "���ȏ�  �`  " + grsUpper + "������" + "�F" + mark3 + "�@�@";
            string marginExpra4 = grsUpper + "���ȏ�" + "�F" + mark4;
            // --- ADD 2009/03/30 --------------------------------<<<<<

			marginmark = marginExpra1 + marginExpra2 + marginExpra3 + marginExpra4;

		}
		#endregion

		#region ���@���o�����w�b�_�[�쐬����
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br> �o�͂��钊�o������������쐬���܂��B</br>
		/// </remarks>
		private void MakeExtarCondition(out StringCollection extraConditions)
		{
			// ���o�����w�b�_�[����
			extraConditions = new StringCollection();

            // 2008.08.01 30413 ���� �����ύX >>>>>>START
            const string dateFormat = "YYYY/MM/DD";
            // 2008.08.01 30413 ���� �����ύX <<<<<<END

			// �Ώۊ���
			string target = "";
			string stTarget = "";
			string edTarget = "";


            // 2008.08.01 30413 ���� �����̏����̓R�����g�� >>>>>>START
            //// �󒍓��i�o�ד��j
            //if ((this._csSaleOrderPara.SalesDateSt != 0) || (this._csSaleOrderPara.SalesDateEd != 0) ||
            //    (this._csSaleOrderPara.ShipmentDaySt != 0) || (this._csSaleOrderPara.ShipmentDayEd != 0))
            //{
            //    switch(this._csSaleOrderPara.AcptAnOdrStatus)
            //    {
            //        case 20:
						
            //            stTarget = "�󒍓�: " + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.SalesDateSt);
            //            edTarget = "  �`�@" + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.SalesDateEd);
            //            break;

            //        case 40:
						
            //            stTarget = "�o�ד�: " + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.ShipmentDaySt);
            //            edTarget = "  �`�@" + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.ShipmentDayEd);
            //            break;

            //}			

            //    target = stTarget + edTarget;

            //    this.EditCondition(ref extraConditions, target);
            //}

            //// ���͓�
            //if ((this._csSaleOrderPara.SearchSlipDateSt != 0) ||
            //   (this._csSaleOrderPara.SearchSlipDateEd != 0))
            //{
            //    stTarget = "���͓�: " + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.SearchSlipDateSt);
            //    edTarget = "  �`�@" + TDateTime.LongDateToString("YY/MM/DD", this._csSaleOrderPara.SearchSlipDateEd);

            //    target = stTarget + edTarget;

            //    this.EditCondition(ref extraConditions, target);
            //}

            //// ���Ӑ�
            //if (this._csSaleOrderPara.CustomerCodeSt != 0)
            //{
            //    if (this._csSaleOrderPara.CustomerCodeEd != 0)	//From To ������
            //    {
            //        target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " �` " + this._csSaleOrderPara.CustomerCodeEd.ToString();
            //    }
            //    else�@											//From ������
            //    {
            //        target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " �` ";
            //    }

            //    this.EditCondition(ref extraConditions, target);
            //}

            //else if (this._csSaleOrderPara.CustomerCodeEd != 0)	//To������
            //{
            //    target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " �` " + this._csSaleOrderPara.CustomerCodeEd.ToString();
            //    this.EditCondition(ref extraConditions, target);
            //}
            // 2008.08.01 30413 ���� �����̏����̓R�����g�� <<<<<<END
            
			
			//if (this._csSaleOrderPara.CustomerCodeSt >= 0)	
			//{
			//    if ((this._csSaleOrderPara.CustomerCodeSt == 0) || (this._csSaleOrderPara.CustomerCodeEd == 0))	// �o�͂��Ȃ�
			//    {
			//        target = "";
			//    }
			//    else
			//    {
			//        target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " �` ";
			//    }

			//    this.EditCondition(ref extraConditions, target);
			//}
	

			//if ((this._csSaleOrderPara.CustomerCodeSt == 0) || (this._csSaleOrderPara.CustomerCodeEd == 0))
			//{
			//    target = "";
			//    this.EditCondition(ref extraConditions, target);
			//}
			//else if ((this._csSaleOrderPara.CustomerCodeEd != 0) || (this._csSaleOrderPara.CustomerCodeEd != 0))
			//{
			//    target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " �` " + this._csSaleOrderPara.CustomerCodeEd.ToString();
			//    this.EditCondition(ref extraConditions, target);
			//}


			//if (this._csSaleOrderPara.CustomerCodeEd != 0)
			//{
			//    target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " �` " + this._csSaleOrderPara.CustomerCodeEd.ToString();
			//    this.EditCondition(ref extraConditions, target);
			//}

            // 2008.08.01 30413 ���� �����̏����̓R�����g�� >>>>>>START
            //// �S���҃R�[�h
            //if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") ||
            //    (this._csSaleOrderPara.SalesEmployeeCdEd != ""))
            //{
            //    target = "�S���҃R�[�h: " + this._csSaleOrderPara.SalesEmployeeCdSt + " �` " + this._csSaleOrderPara.SalesEmployeeCdEd;
            //    this.EditCondition(ref extraConditions, target);
            //}
            // 2008.08.01 30413 ���� �����̏����̓R�����g�� <<<<<<END
            
            // 2008.08.01 30413 ���� ���o����������ݒ��ύX >>>>>>START
            // �󒍓��E�ݏo��
            switch (this._csSaleOrderPara.AcptAnOdrStatus)
            {
                case 20:
                    {
                        // �󒍓�
                        if ((this._csSaleOrderPara.SalesDateSt != 0) || (this._csSaleOrderPara.SalesDateEd != 0))
                        {
                            // �J�n
                            if (this._csSaleOrderPara.SalesDateSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.SalesDateSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._csSaleOrderPara.SalesDateEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.SalesDateEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�󒍓�" + ct_RangeConst, stTarget, edTarget));
                        }
                        break;
                    }
                case 40:
                    {
                        // �ݏo��
                        if ((this._csSaleOrderPara.ShipmentDaySt != 0) || (this._csSaleOrderPara.ShipmentDayEd != 0))
                        {
                            // �J�n
                            if (this._csSaleOrderPara.ShipmentDaySt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.ShipmentDaySt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._csSaleOrderPara.ShipmentDayEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.ShipmentDayEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�ݏo��" + ct_RangeConst, stTarget, edTarget));
                        }
                        break;
                    }
            }

            // ���͓�
            if ((this._csSaleOrderPara.SearchSlipDateSt != 0) || (this._csSaleOrderPara.SearchSlipDateEd != 0))
            {
                // �J�n
                if (this._csSaleOrderPara.SearchSlipDateSt != 0)
                {
                    stTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.SearchSlipDateSt);
                }
                else
                {
                    stTarget = ct_Extr_Top;
                }
                // �I��
                if (this._csSaleOrderPara.SearchSlipDateEd != 0)
                {
                    edTarget = TDateTime.LongDateToString(dateFormat, this._csSaleOrderPara.SearchSlipDateEd);
                }
                else
                {
                    edTarget = ct_Extr_End;
                }
                this.EditCondition(ref extraConditions, string.Format("���͓�" + ct_RangeConst, stTarget, edTarget));
            }

            // ���s�^�C�v
            switch (this._csSaleOrderPara.PublicationType)
            {
                case (int)ExtrInfo_DCHNB02013E.PublicationTypeState.AcceptAnOrder:
                    {
                        // ��
                        target = "��";
                        break;
                    }
                case (int)ExtrInfo_DCHNB02013E.PublicationTypeState.AcceptAnOrderAddUp:
                    {
                        // �󒍌v���
                        target = "�󒍌v���";
                        break;
                    }
                case (int)ExtrInfo_DCHNB02013E.PublicationTypeState.Loan:
                    {
                        // �ݏo
                        target = "�ݏo";
                        break;
                    }
                case (int)ExtrInfo_DCHNB02013E.PublicationTypeState.LoanAddUp:
                    {
                        // �ݏo�v���
                        target = "�ݏo�v���";
                        break;
                    }
            }
            this.EditCondition(ref extraConditions, "���s�^�C�v�F" + target);

            // ����
            switch (this._csSaleOrderPara.NewPageType)
            {
                case 0:
                    {
                        // ���_
                        target = "���_";
                        break;
                    }
                case 1:
                    {
                        // ���v
                        target = "���v";
                        break;
                    }
                case 2:
                    {
                        // ���Ȃ�
                        target = "���Ȃ�";
                        break;
                    }
            }
            this.EditCondition(ref extraConditions, "���ŁF" + target);

            // �S���� 
            if (this._csSaleOrderPara.SalesEmployeeCdSt != string.Empty || this._csSaleOrderPara.SalesEmployeeCdEd != string.Empty)
            {
                stTarget = this._csSaleOrderPara.SalesEmployeeCdSt;
                edTarget = this._csSaleOrderPara.SalesEmployeeCdEd;
                if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                if (edTarget == string.Empty) edTarget = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("�S����" + ct_RangeConst, stTarget, edTarget));
            }

            // ���Ӑ�
            target = "";
            if ((this._csSaleOrderPara.CustomerCodeSt == 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
            {
                target = string.Format("���Ӑ�" + ct_RangeConst, ct_Extr_Top, this._csSaleOrderPara.CustomerCodeEd.ToString("d08"));
            }

            if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd == 0))
            {
                target = string.Format("���Ӑ�" + ct_RangeConst, this._csSaleOrderPara.CustomerCodeSt.ToString("d08"), ct_Extr_End);
            }

            if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
            {
                target = string.Format("���Ӑ�" + ct_RangeConst, this._csSaleOrderPara.CustomerCodeSt.ToString("d08"), this._csSaleOrderPara.CustomerCodeEd.ToString("d08"));
            }
            this.EditCondition(ref extraConditions, target);
            // 2008.08.01 30413 ���� ���o����������ݒ��ύX <<<<<<END
            
            
		}
		
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		///  �o�͂��钊�o�����������ҏW���܂��B<br/>
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

				if ((areaByte + targetByte + 2) <= 180)
				{
					isEdit = true;

					// �S�p�X�y�[�X��}��
					if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;
					
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
		
		#region ���@���ʃv���r���[���i�p�����[�^�ݒ�
		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// �����ʋ��ʏ����̐ݒ���s���܂��B<br/>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;
			
			// ���[��
			commonInfo.PrintName   = this._printInfo.prpnm;				
				
			// �������
            commonInfo.PrintMax = ((DataSet)this._printInfo.rdData).Tables[ct_TableName].Rows.Count;
			
			// ������[�h
			commonInfo.PrintMode   = this._printInfo.printmode;
			
			// �]���ݒ�
			// ���ʒu
			commonInfo.MarginsLeft = this._printInfo.px;
			
			// �s�ʒu
			commonInfo.MarginsTop  = this._printInfo.py;

			// PDF�o�̓t���p�X
			string pdfPath = "";
			string pdfName = "";
			this._sfcmn00331C.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			
			string pdfFileName     = System.IO.Path.Combine(pdfPath,pdfName);
			commonInfo.PdfFullPath = pdfFileName;
			
			this._printInfo.pdftemppath = pdfFileName;
		}
		#endregion
		
		#region ���@������N�G���쐬�֐�
		/// <summary>
		/// �󎚏��N�G���쐬����
		/// </summary>
		/// <returns>�쐬�����N�G��</returns>
		/// <remarks>
		/// DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B<br/>
        /// �f�[�^���\�[�g���܂��B<br/>
		/// </remarks>
		private string GetPrintOderQuerry()
		{
            string oderQuerry = "";

            switch (this._csSaleOrderPara.SortOrder)
            {
                case 0:
                    {
						if (this._csSaleOrderPara.AcptAnOdrStatus == 20)
						{
							oderQuerry = CT_Sort1_Odr01;
						}
						else
						{
							oderQuerry = CT_Sort1_Odr02;
						}
						break;
                    }
                case 1:
                    {
                        oderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 2:
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }
                case 3:
                    {
                        oderQuerry = CT_Sort4_Odr;
                        break;
                    }
				
            }
			
			return oderQuerry;
		}
		#endregion

		
		#region ���@���b�Z�[�W�\������
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
		///  �o�͌����̐ݒ���s���܂��B<br/>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCHNB02012P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion
	}
}
