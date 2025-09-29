//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d���m�F�\
// �v���O�����T�v   : �d���m�F�\�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ēc �ύK
// �� �� ��  2008/07/16  �C�����e : �f�[�^���ڂ̒ǉ�/�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2008/12/02  �C�����e : �\�[�g�����Ɏd��SEQ�ԍ���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�� �⎟�Y
// �C �� ��  2008/12/02  �C�����e : ����̓`�[���[�h���A�`�[�ԍ��\�[�g��I��ł�SEQ�ԍ��\�[�g����Ă�����Q���C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/07  �C�����e : ��Q�Ή�13157(�t�b�^���̎擾������ǉ�)
//----------------------------------------------------------------------------//
#define CHG20060329
#define CHG20060410
#define CHG20060418
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/06 �s��Ή�[5654]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller; // ADD 2009/04/07


namespace Broadleaf.Drawing.Printing
{
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E�f�[�^���ڂ̒ǉ�/�C��</br>
    /// <br>Programmer	: 30415 �ēc �ύK</br>
    /// <br>Date		: 2008/07/16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E�\�[�g�����Ɏd��SEQ�ԍ���ǉ�</br>
    /// <br>Programmer	: 30452 ��� �r��</br>
    /// <br>Date		: 2008/12/02</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E����̓`�[���[�h���A�`�[�ԍ��\�[�g��I��ł�SEQ�ԍ��\�[�g����Ă�����Q���C��</br>
    /// <br>Programmer	: 30365 �{�� �⎟�Y</br>
    /// <br>Date		: 2008/12/02</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E��Q�Ή�13157(�t�b�^���̎擾������ǉ�)</br>
    /// <br>Programmer	: 30452 ��� �r��</br>
    /// <br>Date		: 2009/04/07</br>
    /// -----------------------------------------------------------------------------------
	public class MAKON02243PA
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		public MAKON02243PA()
		{
		}
		/// <summary>
		public MAKON02243PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
			
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

            this._csStockConfPara = this._printInfo.jyoken as ExtrInfo_MAKON02247E;

            this.SelectTableName();

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
		private SFCMN06002C     _printInfo           = null;
		private PdfHistoryControl _pdfHistoryControl = null;
		private SFCMN00331C _sfcmn00331C             = null;			// ���[�n���ʕ��i
        private ExtrInfo_MAKON02247E _csStockConfPara = null;
        #endregion

        /// <summary>�\������</summary>
        private string CT_Sort1_Odr = "SectionCodeRF, StockDateRF, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";
        //private string CT_Sort2_Odr = "SectionCodeRF, SupplierCd, StockDateRF, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF"; // DEL 2008/12/02
        private string CT_Sort2_Odr = "SectionCodeRF, SupplierCd, StockDateRF, PartySaleSlipNumRF, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF"; // ADD 2008/12/02
        private string CT_Sort3_Odr = "SectionCodeRF, InputDayRF, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";
        //private string CT_Sort4_Odr = "SectionCodeRF, SupplierCd, InputDayRF, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF"; // DEL 2008/12/02
        private string CT_Sort4_Odr = "SectionCodeRF, SupplierCd, InputDayRF, PartySaleSlipNumRF, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF"; // ADD 2008/12/02
        private string CT_Sort5_Odr = "SectionCodeRF, SupplierCd, PartySaleSlipNumRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";                

        private string CT_Sort6_Odr = "SectionCodeRF, SupplierCd, StockDateRF, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";
        private string CT_Sort7_Odr = "SectionCodeRF, SupplierCd, InputDayRF, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";
        private string CT_Sort8_Odr = "SectionCodeRF, SupplierCd, SupplierSlipNoRF, StockRowNoRF, FirstRowFlg, StckSlipExpNumRF";

        // >>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu DEL
        //private string CT_Sort_Den_Odr = "SectionCodeRF, SupplierCd, StockDateRF, SupplierSlipNoRF";

        // >>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu ADD
        private string CT_Sort1_Den_Odr = "SectionCodeRF, SupplierCd, StockDateRF, SupplierSlipNoRF";
        private string CT_Sort2_Den_Odr = "SectionCodeRF, SupplierCd, InputDayRF, SupplierSlipNoRF";
        private string CT_Sort3_Den_Odr = "SectionCodeRF, SupplierCd, StockDateRF, PartySaleSlipNumRF";
        private string CT_Sort4_Den_Odr = "SectionCodeRF, SupplierCd, InputDayRF, PartySaleSlipNumRF";
        // <<<<<<<<<<<<<<<<<<<<<<< 2008/12/02 G.Miyatsu ADD

		// �`�[�`��
		private string CT_Sort1_OdrStr = "�d�������`�[�ԍ�";
		private string CT_Sort2_OdrStr = "�d���恨�d�������`�[�ԍ�";
		private string CT_Sort3_OdrStr = "���͓����`�[�ԍ�";
		private string CT_Sort4_OdrStr = "�d���恨���͓����`�[�ԍ�";
		private string CT_Sort5_OdrStr = "�d���恨�`�[�ԍ�";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        private string CT_Sort6_OdrStr = "�d���恨�d�������d��SEQ�ԍ�";
        private string CT_Sort7_OdrStr = "�d���恨���͓����d��SEQ�ԍ�";
        private string CT_Sort8_OdrStr = "�d���恨�d��SEQ�ԍ�";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
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

				// ����f�[�^�擾
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
                                // ----- iitani c ---------- start 2007.05.26
                                //// �o�͗����Ǘ��ɒǉ�
                                //this._pdfHistoryControl.AddPrintHistoryList(this._printInfo.key, "�d���m�F�\", this._printInfo.prpnm,
                                //    this._printInfo.pdftemppath);
                                // �o�͗����Ǘ��ɒǉ�
                                Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                    this._printInfo.pdftemppath);
                                // ----- iitani c ---------- end 2007.05.26
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
			if (_printInfo.frycd == 3)
			{
				ct_TableName = MAKON02249EB.CT_StockConfSlipTtlDataTable;
			}
			else
			{
				ct_TableName = MAKON02249EA.CT_StockConfDataTable;
			}
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
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
		/// <br>Date       : 2005.11.15</br>
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
		#endregion
	
		#region ���@AvtiveReport�Ɋe��v���p�e�B��ݒ肵�܂�
		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // --- ADD 2009/04/07 -------------------------------->>>>>
            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            StockConfAcs _stockConfAcs = new StockConfAcs();
            int st = _stockConfAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new DemandPrintException(message, status);
            }

            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;
            // --- ADD 2009/04/07 --------------------------------<<<<<

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �\�[�g��
            string wrkstr = "";
            string target = "";

            #region [--2008/12/02 G.Miyatsu DEL--]
            //�`�[�`��
            //if (_printInfo.frycd == 3)
            //{
            //    wrkstr = CT_Sort1_Den_OdrStr;
            //}
            
            //���׌`�� �ڍ׌`��
            // DEL 2008/10/08 �s��Ή�[5664]��
            //else
            //{
            #endregion
            switch (this._csStockConfPara.SortOrder)
            {
                case 0:
                    {
                        wrkstr = CT_Sort1_OdrStr;
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
                case 4:
                    {
                        wrkstr = CT_Sort5_OdrStr;
                        break;
                    }
                case 5:
                    {
                        // �d���恨�d�����t���d��SEQ�ԍ�
                        wrkstr = CT_Sort6_OdrStr;
                        break;
                    }
                case 6:
                    {
                        // �d���恨���͓��t���d��SEQ�ԍ�
                        wrkstr = CT_Sort7_OdrStr;
                        break;
                    }
                case 7:
                    {
                        // �d���恨�d��SEQ�ԍ�
                        wrkstr = CT_Sort8_OdrStr;
                        break;
                    }
            }
            // DEL 2008/10/08 �s��Ή�[5664]��
            //}

            target = "�\�[�g���F[" + wrkstr + "] ��";
            instance.PageHeaderSortOderTitle = target;
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
		}
		#endregion
	
		#region ���@���o�����w�b�_�[�쐬����
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void MakeExtarCondition(out StringCollection extraConditions)
		{
			// ���o�����w�b�_�[����
			extraConditions = new StringCollection();
			
			// �`�[���t
			string target = "";
			string stTarget = "";
			string edTarget = "";
            string wrkstr = "";
            wrkstr = "";

			if ((this._csStockConfPara.StockDateSt != 0) || (this._csStockConfPara.StockDateEd != 0))
			{
				// �J�n
				if (this._csStockConfPara.StockDateSt != 0)
					stTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._csStockConfPara.StockDateSt);
				else
					stTarget = ct_Extr_Top;

				// �I��
				if (this._csStockConfPara.StockDateEd != 0)
					edTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._csStockConfPara.StockDateEd);
				else
					edTarget = ct_Extr_End;

				target = "�d�����F " + stTarget + "  �`�@" + edTarget;
				this.EditCondition(ref extraConditions, target);
			}

			// ���͓��t
			target = "";
			stTarget = "";
			edTarget = "";
			wrkstr = "";
			wrkstr = "";

			if ((this._csStockConfPara.InputDaySt != 0) || (this._csStockConfPara.InputDayEd != 0))
			{
				// �J�n
				if (this._csStockConfPara.InputDaySt != 0)
					stTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._csStockConfPara.InputDaySt);
				else
					stTarget = ct_Extr_Top;

				// �I��
				if (this._csStockConfPara.InputDayEd != 0)
					edTarget = TDateTime.LongDateToString("YYYY/MM/DD", this._csStockConfPara.InputDayEd);
				else
					edTarget = ct_Extr_End;

				target = "���͓��F " + stTarget + "  �`�@" + edTarget;
				this.EditCondition(ref extraConditions, target);
			}

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //// �\�[�g��
            //wrkstr = "";
            //target = "";

            ////�`�[�`��
            //if (_printInfo.frycd == 3)
            //{
            //    wrkstr = CT_Sort_Den_OdrStr;
            //}
            ////���׌`�� �ڍ׌`��
            //else
            //{

            //    switch (this._csStockConfPara.SortOrder)
            //    {
            //        case 0:
            //            {
            //                wrkstr = CT_Sort1_OdrStr;
            //                break;
            //            }
            //        case 1:
            //            {
            //                wrkstr = CT_Sort2_OdrStr;
            //                break;
            //            }
            //        case 2:
            //            {
            //                wrkstr = CT_Sort3_OdrStr;
            //                break;
            //            }
            //        case 3:
            //            {
            //                wrkstr = CT_Sort4_OdrStr;
            //                break;
            //            }
            //        case 4:
            //            {
            //                wrkstr = CT_Sort5_OdrStr;
            //                break;
            //            }
            //    }
            //}
            //target = "�\�[�g���F" + wrkstr + " ��";
            //this.EditCondition(ref extraConditions, target);
            // --- DEL 2008/07/16 --------------------------------<<<<< 



            // �S����
            if ((this._csStockConfPara.StockAgentCodeSt != "") || (this._csStockConfPara.StockAgentCodeEd != ""))
            {
                this.EditCondition(ref extraConditions,
                    GetConditionRange("�S���ҁF{0} �` {1}", this._csStockConfPara.StockAgentCodeSt, this._csStockConfPara.StockAgentCodeEd));
            }

            // DEL 2008/10/06 �s��Ή�[5654]---------->>>>>
            //// --- ADD 2008/07/16 -------------------------------->>>>>
            //// �n��
            //if ((this._csStockConfPara.SalesAreaCodeSt != 0) || (this._csStockConfPara.SalesAreaCodeEd != 0))
            //{
            //    this.EditCondition(ref extraConditions,
            //        GetConditionRange("�n��F{0} �` {1}", this._csStockConfPara.SalesAreaCodeSt, this._csStockConfPara.SalesAreaCodeEd,"d4"));
            //}
            //// --- ADD 2008/07/16 --------------------------------<<<<<
            // DEL 2008/10/06 �s��Ή�[5654]----------<<<<<
            // ADD 2008/10/06 �s��Ή�[5654]---------->>>>>
            int convertedSalesAreaCodeEd = (this._csStockConfPara.SalesAreaCodeEd.Equals(0) ? RangeUtil.SalesAreaCode.MAX + 1 : this._csStockConfPara.SalesAreaCodeEd);
            if (!RangeUtil.SalesAreaCode.IsAllRange(
                this._csStockConfPara.SalesAreaCodeSt,
                convertedSalesAreaCodeEd
            ))
            {
                string start= RangeUtil.SalesAreaCode.GetStartString(this._csStockConfPara.SalesAreaCodeSt);
                string end  = RangeUtil.SalesAreaCode.GetEndString(convertedSalesAreaCodeEd);

                EditCondition(
                    ref extraConditions,
                    string.Format("�n��" + ct_RangeConst, start, end)
                );
            }
            // ADD 2008/10/06 �s��Ή�[5654]----------<<<<<

            // �d����
            //if ((this._csStockConfPara.CustomerCodeSt != 0) || (this._csStockConfPara.CustomerCodeEd != 0))  // DEL 2008/07/16
            if ((this._csStockConfPara.SupplierCdSt != 0) || (this._csStockConfPara.SupplierCdEd != 0))        // ADD 2008/07/16
            {
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //this.EditCondition(ref extraConditions,
                //    GetConditionRange("�d����R�[�h:{0} �` {1}", this._csStockConfPara.CustomerCodeSt, this._csStockConfPara.CustomerCodeEd, "d9"));
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                this.EditCondition(ref extraConditions,
                    GetConditionRange("�d����:{0} �` {1}", this._csStockConfPara.SupplierCdSt, this._csStockConfPara.SupplierCdEd, "d6"));
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }

            // �d��SEQ�ԍ�
            if ((this._csStockConfPara.SupplierSlipNoSt != 0) || (this._csStockConfPara.SupplierSlipNoEd != 0))
            {
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //this.EditCondition(ref extraConditions,
                //    GetConditionRange("�`�[�ԍ�:{0} �` {1}", this._csStockConfPara.SupplierSlipNoSt, this._csStockConfPara.SupplierSlipNoEd, "d9"));
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                this.EditCondition(ref extraConditions,
                    GetConditionRange("�d��SEQ�ԍ�:{0} �` {1}", this._csStockConfPara.SupplierSlipNoSt, this._csStockConfPara.SupplierSlipNoEd, "d9"));
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }

			// �`�[�ԍ�
			if ((this._csStockConfPara.PartySaleSlipNumSt != "") || (this._csStockConfPara.PartySaleSlipNumEd != ""))
			{
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //this.EditCondition(ref extraConditions,
                //    GetConditionRange("�����`�[�ԍ�:{0} �` {1}", this._csStockConfPara.PartySaleSlipNumSt, this._csStockConfPara.PartySaleSlipNumEd));
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                this.EditCondition(ref extraConditions,
                    GetConditionRange("�`�[�ԍ�:{0} �` {1}", this._csStockConfPara.PartySaleSlipNumSt, this._csStockConfPara.PartySaleSlipNumEd));
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }

            // ADD 2008/10/06 �s��Ή�[5654]---------->>>>>
            // �`�[�敪
            string supplierSlipCdLabel = string.Empty;
            switch (this._csStockConfPara.SupplierSlipCd)   // �ꍇ�����̐��l�͉�ʁi�R���{�{�b�N�X�̃A�C�e���l�j���
            {
                case 0: // �S��
                    {
                        supplierSlipCdLabel = "�S��";    // LITERAL:
                        break;
                    }
                case 10:// �d��
                    {
                        supplierSlipCdLabel = "�d��";    // LITERAL:   
                        break;
                    }
                case 20:// �ԕi
                    {
                        supplierSlipCdLabel = "�ԕi";    // LITERAL:
                        break;
                    }
                // 2009.02.20 30413 ���� "�ԕi�{�s�l��"��ǉ� >>>>>>START
                case 30:// �ԕi+�s�l��
                    {
                        supplierSlipCdLabel = "�ԕi�{�s�l��";    // LITERAL:
                        break;
                    }
                // 2009.02.20 30413 ���� "�ԕi�{�s�l��"��ǉ� <<<<<<END
                default:
                    {
                        supplierSlipCdLabel = "�S��";    // LITERAL:
                        break;
                    }
            }
            EditCondition(ref extraConditions, "�`�[�敪�F" + supplierSlipCdLabel + " ");   // LITERAL:

            // �ԓ`�敪
            string debitNoteDivLabel = string.Empty;
            switch (this._csStockConfPara.DebitNoteDiv + 1) // �ꍇ�����̐��l�͉�ʁi�R���{�{�b�N�X�̃A�C�e���l�j���
            {
                case 0: // �S��
                    {
                        debitNoteDivLabel = "�S��";    // LITERAL:
                        break;
                    }
                case 1: // ���`
                    {
                        debitNoteDivLabel = "���`";    // LITERAL:   
                        break;
                    }
                case 2: // �ԓ`
                    {
                        debitNoteDivLabel = "�ԓ`";    // LITERAL:
                        break;
                    }
                case 3: // ����
                    {
                        debitNoteDivLabel = "����";    // LITERAL:
                        break;
                    }
                default:
                    {
                        debitNoteDivLabel = "�S��";    // LITERAL:
                        break;
                    }

            }
            EditCondition(ref extraConditions, "�ԓ`�敪�F" + debitNoteDivLabel + " ");   // LITERAL:
            // ADD 2008/10/06 �s��Ή�[5654]----------<<<<<

            // ���s�^�C�v
            wrkstr = "";
            target = "";
            switch (this._csStockConfPara.PrintType)
            {
                case 0:
                    {
                        wrkstr = "�ʏ�";
                        break;
                    }
                case 1:
                    {
                        wrkstr = "����";
                        break;
                    }
                case 2:
                    {
                        wrkstr = "�폜";
                        break;
                    }
                case 3:
                    {
                        wrkstr = "�����{�폜";
                        break;
                    }
            }

            target = "���s�^�C�v�F";
            target = "���s�^�C�v�F" + wrkstr + " ";
            this.EditCondition(ref extraConditions, target);

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �o�͎w��
            wrkstr = "";
            target = "";
            switch (this._csStockConfPara.OutputDesignated)
            {
                case 0:
                    {
                        wrkstr = "�S��";
                        break;
                    }
                case 1:
                    {
                        wrkstr = "�d������";
                        break;
                    }
                case 2:
                    {
                        wrkstr = "UOE��";
                        break;
                    }
                case 3:
                    {
                        wrkstr = "�������͕�";
                        break;
                    }
                case 4:
                    {
                        wrkstr = "UOE�A���}�b�`";
                        break;
                    }
            }
            target = "�o�͎w��F" + wrkstr + " ";
            this.EditCondition(ref extraConditions, target);

            // �ݎ�w��
            wrkstr = "";
            target = "";
            switch (this._csStockConfPara.StockOrderDivCd)
            {
                case -1:
                    {
                        wrkstr = "�S��";
                        break;
                    }
                case 0:
                    {
                        wrkstr = "���";
                        break;
                    }
                case 1:
                    {
                        wrkstr = "�݌�";
                        break;
                    }
            }
            target = "�݌Ɏ��w��F" + wrkstr + " ";   // MOD 2008/10/06 �s��Ή�[5654] "�ݎ�w��F"��"�݌Ɏ��w��F"
            this.EditCondition(ref extraConditions, target);
            // --- ADD 2008/07/16 --------------------------------<<<<< 
		}

		#region �� ���o�͈͕�����쐬
        // --- DEL 2008/07/16 -------------------------------->>>>>
        //private const string ct_Extr_Top = "�s�n�o";
        //private const string ct_Extr_End = "�d�m�c";
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        // --- ADD 2008/07/16 -------------------------------->>>>>
        private const string ct_Extr_Top = RangeUtil.FROM_BEGIN;    // MOD 2008/10/06 �s��Ή�[5654] "�ŏ�����"��RangeUtil.FROM_BEGIN
        private const string ct_Extr_End = RangeUtil.TO_END;        // MOD 2008/10/06 �s��Ή�[5654] "�Ō�܂�"��RangeUtil.TO_END
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		private const string ct_RangeConst = "�F{0} �` {1}";

		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetConditionRange(string title, string startString, string endString)
		{
			string result = "";
			if ((startString != "") || (endString != ""))
			{
				string start = ct_Extr_Top;
				string end = ct_Extr_End;
				if (startString != "") start = startString;
				if (endString != "") end = endString;
				//result = String.Format(title + ct_RangeConst, start, end);  // DEL 2008/07/16
                result = String.Format(title, start, end);                    // ADD 2008/07/16
			}
			return result;
		}

		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetConditionRange(string title, int startString, int endString, string kt)
		{
			string result = "";
			if ((startString != 0) || (endString != 0))
			{
				string start = ct_Extr_Top;
				string end = ct_Extr_End;
				if (startString != 0) start = startString.ToString(kt);
				if (endString != 0) end = endString.ToString(kt);
                //result = String.Format(title + ct_RangeConst, start, end);  // DEL 2008/07/16
                result = String.Format(title, start, end);                    // ADD 2008/07/16
			}
			return result;
		}
		#endregion

		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
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

				if ((areaByte + targetByte + 2) <= 186)
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
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
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
		/// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.12.06</br>
		/// </remarks>
		private string GetPrintOderQuerry()
		{
            string oderQuerry = "";

			//�`�[�`��
			if (_printInfo.frycd == 3)
			{
                // >>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu ADD
                switch (this._csStockConfPara.SortOrder)
                {
                    case 1:
                        {
                            oderQuerry = CT_Sort3_Den_Odr;
                            break;
                        }
                    case 3:
                        {
                            oderQuerry = CT_Sort4_Den_Odr;
                            break;
                        }
                    case 5:
                        {
                            oderQuerry = CT_Sort1_Den_Odr;
                            break;
                        }
                    case 6:
                        {
                            oderQuerry = CT_Sort2_Den_Odr;
                            break;
                        }
                    default:
                        {
                            oderQuerry = CT_Sort1_Den_Odr;
                            break;
                        }
                }
                // <<<<<<<<<<<<<<<<<<<<<<< 2008/12/02 G.Miyatsu ADD

                //>>>> 2008/12/02 G.Miyatsu DEL
                //oderQuerry = CT_Sort_Den_Odr;
			}
			//���׌`�� �ڍ׌`��
			else
			{
				switch (this._csStockConfPara.SortOrder)
				{
					case 0:
						{
							oderQuerry = CT_Sort1_Odr;
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
					case 4:
						{
							oderQuerry = CT_Sort5_Odr;
							break;
						}
                    case 5:
                        {
                            oderQuerry = CT_Sort6_Odr;
                            break;
                        }
                    case 6:
                        {
                            oderQuerry = CT_Sort7_Odr;
                            break;
                        }
                    case 7:
                        {
                            oderQuerry = CT_Sort8_Odr;
                            break;
                        }
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
		/// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAKON02243P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion
	}
}
