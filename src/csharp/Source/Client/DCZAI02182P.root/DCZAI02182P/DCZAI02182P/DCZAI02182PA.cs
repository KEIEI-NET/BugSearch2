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
	/// �݌ɉߏ�ꗗ�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌ɉߏ�ꗗ�\�̈�����s���B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
	/// <br>Date       : 2007.11.13</br>
    /// <br>UpdateNote : 2008/10/03 30462 �s�V �m���@�o�O�C��</br>
    /// <br>           : 2009/03/10       �Ɠc �M�u�@�s��Ή�[12269]</br>
    /// <br>           : 2009/03/17       ��� �r���@�s��Ή�[12490]</br>
    /// <br>           : 2009/04/02       ��� �r���@�s��Ή�[13058]</br>
	/// </remarks>
	class DCZAI02182PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �݌ɉߏ�ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌ɉߏ�ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
		/// </remarks>
		public DCZAI02182PA()
		{
		}

		/// <summary>
		/// �݌ɉߏ�ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �݌ɉߏ�ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
		/// </remarks>
		public DCZAI02182PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._stockOverListCndtn = this._printInfo.jyoken as StockOverListCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
		private const string ct_Extr_Top		= "�ŏ�����";
		private const string ct_Extr_End		= "�Ō�܂�";
		private	const string ct_RangeConst		= "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
        private StockOverListCndtn _stockOverListCndtn;	// ���o�����N���X
		#endregion �� Private Member

        
		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class StockMoveException: ApplicationException
		{
			private int _status;
			#region �� Constructor
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
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
				prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = DCZAI02184EA.ct_Tbl_StockOver;
				
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
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

		#region �� �����ʋ��ʏ��ݒ�

		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
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
			//commonInfo.PrintMax    = 0;                                           //DEL 2009/03/10 �s��Ή�[12269]
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;       //ADD 2009/03/10 �s��Ή�[12269]
			
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            StockOverListCndtn extraInfo = (StockOverListCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = String.Format("[�\�[�g���F{0}]", this._stockOverListCndtn.PrintSortDivStateTitle);
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
            int st = StockOverListAcs.ReadPrtOutSet(out prtOutSet, out message);
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

			// �w�b�_�[�T�u�^�C�g��
            //object[] titleObj = new object[] { this._stockOverListCndtn.ReportSubTitle, "�݌ɉߏ�ꗗ�\" }; // DEL 2009/03/17
            object[] titleObj = new object[] { this._stockOverListCndtn.ReportSubTitle, "�ߏ�݌Ɉꗗ�\" }; // ADD 2009/03/17
            instance.PageHeaderSubtitle = string.Format("{0}{1}", titleObj);

			// ���̑��f�[�^
			instance.OtherDataList = null;

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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
        /// <br>Update     : 2008/10/02 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
        /// <br>Update     : 2008/10/03 �s�V �m���@�o�O�C���A�d�l�ύX�Ή�</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            //--- DEL 2008/10/03 �s��Ή�[6075] ----------<<<<<
            //// �Ώ۔N�� ------------------------------------------------------------------------------------------------------
            //string st_ShipArrivalDate = string.Empty;
            //string ed_ShipArrivalDate = string.Empty;

            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( ( this._stockOverListCndtn.St_AddUpYearMonth != DateTime.MinValue ) || ( this._stockOverListCndtn.Ed_AddUpYearMonth != DateTime.MinValue ) ) {
            //    // �J�n
            //    if ( this._stockOverListCndtn.St_AddUpYearMonth != DateTime.MinValue )
            //        //st_ShipArrivalDate = this._stockOverListCndtn.St_AddUpYearMonth.ToString("yyyy�NMM��");       //DEL 2008/10/02 �����ύX
            //        st_ShipArrivalDate = this._stockOverListCndtn.St_AddUpYearMonth.ToString("yyyy/MM");            //ADD 2008/10/02
            //    else
            //        st_ShipArrivalDate = ct_Extr_Top;
            //    // �I��
            //    if ( this._stockOverListCndtn.Ed_AddUpYearMonth != DateTime.MinValue )
            //        //ed_ShipArrivalDate = this._stockOverListCndtn.Ed_AddUpYearMonth.ToString("yyyy�NMM��");       //DEL 2008/10/02 �����ύX
            //        ed_ShipArrivalDate = this._stockOverListCndtn.Ed_AddUpYearMonth.ToString("yyyy/MM");            //ADD 2008/10/02
            //    else
            //        ed_ShipArrivalDate = ct_Extr_End;

            //    this.EditCondition(
            //        ref addConditions,
            //        string.Format(
            //            "������" + ct_RangeConst,
            //            st_ShipArrivalDate,
            //            ed_ShipArrivalDate));
            //}
            //--- DEL 2008/10/03 �s��Ή�[6075] ---------->>>>>

            // �݌ɓo�^�� ----------------------------------------------------------------------------------------------------
            if (this._stockOverListCndtn.StockCreateDate != DateTime.MinValue) // ADD 2009/04/02
            {
                this.EditCondition(ref addConditions, String.Format("�݌ɓo�^���F{0}{1}",
                    //this._stockOverListCndtn.StockCreateDate.ToString("yyyy�NMM��dd��"),      //DEL 2008/10/02 �����ύX
                                                                        this._stockOverListCndtn.StockCreateDate.ToString("yyyy/MM/dd"),            //ADD 2008/10/02
                                                                        this._stockOverListCndtn.StockCreateDateDivStateTitle));
            }

            //--- ADD 2008/10/03 �s��Ή�[6074] ----------<<<<<
            // ���o�׌o�ߌ� ----------------------------------------------------------------------------------------------------
            if (this._stockOverListCndtn.NoShipmentDiv == 1)
            {                
                string st_ShipArrivalDate = string.Empty;
                string ed_ShipArrivalDate = string.Empty;

                if ((this._stockOverListCndtn.St_AddUpYearMonth != DateTime.MinValue) || (this._stockOverListCndtn.Ed_AddUpYearMonth != DateTime.MinValue))
                {
                    // �J�n
                    if (this._stockOverListCndtn.St_AddUpYearMonth != DateTime.MinValue)
                        st_ShipArrivalDate = this._stockOverListCndtn.St_AddUpYearMonth.ToString("yyyy/MM");            
                    else
                        st_ShipArrivalDate = ct_Extr_Top;
                    // �I��
                    if (this._stockOverListCndtn.Ed_AddUpYearMonth != DateTime.MinValue)
                        ed_ShipArrivalDate = this._stockOverListCndtn.Ed_AddUpYearMonth.ToString("yyyy/MM");          
                    else
                        ed_ShipArrivalDate = ct_Extr_End;

                    this.EditCondition(
                        ref addConditions,
                        string.Format(
                            "���o�׌o�ߌ�" + ct_RangeConst,
                            st_ShipArrivalDate,
                            ed_ShipArrivalDate));
                }
            }
            // �Ǘ��敪�P ----------------------------------------------------------------------------------------------------
            if (this._stockOverListCndtn.PartsManagementDivide1.Length != 0)
            {
                StringBuilder PartsData1 = new StringBuilder();

                for (int i = 0; i < this._stockOverListCndtn.PartsManagementDivide1.Length; i++)
                {
                    PartsData1.Append(this._stockOverListCndtn.PartsManagementDivide1[i]);
                }

                this.EditCondition(ref addConditions, String.Format("�Ǘ��敪�P: {0}",                                                                    PartsData1));
            }
            
            // �Ǘ��敪�Q ----------------------------------------------------------------------------------------------------
            if (this._stockOverListCndtn.PartsManagementDivide2.Length != 0)
            {
                StringBuilder PartsData2 = new StringBuilder();

                for (int i = 0; i < this._stockOverListCndtn.PartsManagementDivide2.Length; i++)
                {
                    PartsData2.Append(this._stockOverListCndtn.PartsManagementDivide2[i]);
                }

                this.EditCondition(ref addConditions, String.Format("�Ǘ��敪�Q: {0}", PartsData2));
            }

            // �I�ԃu���C�N�w�� ----------------------------------------------------------------------------------------------
            if (this._stockOverListCndtn.PrintSortDiv == StockOverListCndtn.PrintSortDivState.ByWarehouseShelfNo)
            {
                this.EditCondition(ref addConditions, String.Format("�I�ԃu���[�N: {0}",
                                                                    this._stockOverListCndtn.WarehouseShelfNoBreakDiv.ToString().Substring(6,1) + "��"));
            }

            // �q�� ----------------------------------------------------------------------------------------------------------
            if (!RangeUtil.WarehouseCode.IsAllRange(this._stockOverListCndtn.St_WarehouseCode, this._stockOverListCndtn.Ed_WarehouseCode)) 
            {
                string start = RangeUtil.WarehouseCode.GetStartString(this._stockOverListCndtn.St_WarehouseCode);
                string end = RangeUtil.WarehouseCode.GetEndString(this._stockOverListCndtn.Ed_WarehouseCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("�q��" + ct_RangeConst, start, end)
                );
            }

            // �d���� --------------------------------------------------------------------------------------------------------
            if (!RangeUtil.SupplierCode.IsAllRange(this._stockOverListCndtn.St_SupplierCd, this._stockOverListCndtn.Ed_SupplierCd)) 
            {
                string start = RangeUtil.SupplierCode.GetStartString(this._stockOverListCndtn.St_SupplierCd);
                string end = RangeUtil.SupplierCode.GetEndString(this._stockOverListCndtn.Ed_SupplierCd);

                EditCondition(
                    ref addConditions,
                    string.Format("�d����" + ct_RangeConst, start, end)
                );
            }

            // ���[�J�[ ------------------------------------------------------------------------------------------------------
            if (!RangeUtil.GoodsMakerCode.IsAllRange(this._stockOverListCndtn.St_GoodsMakerCd, this._stockOverListCndtn.Ed_GoodsMakerCd))   
            {
                string start = RangeUtil.GoodsMakerCode.GetStartString(this._stockOverListCndtn.St_GoodsMakerCd);
                string end = RangeUtil.GoodsMakerCode.GetEndString(this._stockOverListCndtn.Ed_GoodsMakerCd);

                this.EditCondition(
                    ref addConditions,
                    string.Format("���[�J�[" + ct_RangeConst, start, end)
                );

            }

            // �q�ɒI�� ------------------------------------------------------------------------------------------------------
            if (this._stockOverListCndtn.St_WarehouseShelfNo != string.Empty || this._stockOverListCndtn.Ed_WarehouseShelfNo != string.Empty)
            {
                string st_WarehouseShelfNo = this._stockOverListCndtn.St_WarehouseShelfNo;
                string ed_WarehouseShelfNo = this._stockOverListCndtn.Ed_WarehouseShelfNo;

                if (st_WarehouseShelfNo == string.Empty)
                    st_WarehouseShelfNo = ct_Extr_Top;
                if (ed_WarehouseShelfNo == string.Empty)
                    ed_WarehouseShelfNo = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("�I��" + ct_RangeConst, st_WarehouseShelfNo, ed_WarehouseShelfNo));
            }

            // �i�� ----------------------------------------------------------------------------------------------------------
            if (this._stockOverListCndtn.St_GoodsNo != string.Empty || this._stockOverListCndtn.Ed_GoodsNo != string.Empty)
            {
                string st_GoodsNo = this._stockOverListCndtn.St_GoodsNo;
                string ed_GoodsNo = this._stockOverListCndtn.Ed_GoodsNo;

                if (st_GoodsNo == string.Empty)
                    st_GoodsNo = ct_Extr_Top;
                if (ed_GoodsNo == string.Empty)
                    ed_GoodsNo = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("�i��" + ct_RangeConst, st_GoodsNo, ed_GoodsNo));         
            }

            // ���i�啪�� ----------------------------------------------------------------------------------------------------
            if (!RangeUtil.GoodsLGroupCode.IsAllRange(this._stockOverListCndtn.St_LargeGoodsGanreCode, this._stockOverListCndtn.Ed_LargeGoodsGanreCode))
            {
                string start = RangeUtil.GoodsLGroupCode.GetStartString(this._stockOverListCndtn.St_LargeGoodsGanreCode);
                string end = RangeUtil.GoodsLGroupCode.GetEndString(this._stockOverListCndtn.Ed_LargeGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("���i�啪��" + ct_RangeConst, start, end)
                );
            }

            // ���i������ ----------------------------------------------------------------------------------------------------
            if (!RangeUtil.GoodsMGroupCode.IsAllRange(this._stockOverListCndtn.St_MediumGoodsGanreCode, this._stockOverListCndtn.Ed_MediumGoodsGanreCode))
            {
                string start = RangeUtil.GoodsMGroupCode.GetStartString(this._stockOverListCndtn.St_MediumGoodsGanreCode);
                string end = RangeUtil.GoodsMGroupCode.GetEndString(this._stockOverListCndtn.Ed_MediumGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("���i������" + ct_RangeConst, start, end)
                );
            }

            // ���i�O���[�v --------------------------------------------------------------------------------------------------
            if (!RangeUtil.BLGroupCode.IsAllRange(this._stockOverListCndtn.St_DetailGoodsGanreCode, this._stockOverListCndtn.Ed_DetailGoodsGanreCode))
            {
                string start = RangeUtil.BLGroupCode.GetStartString(this._stockOverListCndtn.St_DetailGoodsGanreCode);
                string end = RangeUtil.BLGroupCode.GetEndString(this._stockOverListCndtn.Ed_DetailGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("�O���[�v�R�[�h" + ct_RangeConst, start, end)
                );
            }

            // ���i�敪 ------------------------------------------------------------------------------------------------------
            if (!RangeUtil.EnterpriseGanreCode.IsAllRange(this._stockOverListCndtn.St_EnterpriseGanreCode, this._stockOverListCndtn.Ed_EnterpriseGanreCode))
            {
                string start = RangeUtil.EnterpriseGanreCode.GetStartString(this._stockOverListCndtn.St_EnterpriseGanreCode);
                string end = RangeUtil.EnterpriseGanreCode.GetEndString(this._stockOverListCndtn.Ed_EnterpriseGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("���i�敪" + ct_RangeConst, start, end)
                );
            }

            // �a�k�R�[�h ----------------------------------------------------------------------------------------------------
            if (!RangeUtil.BLGoodsCode.IsAllRange(this._stockOverListCndtn.St_BLGoodsCode, this._stockOverListCndtn.Ed_BLGoodsCode))   
            {
                string start = RangeUtil.BLGoodsCode.GetStartString(this._stockOverListCndtn.St_BLGoodsCode);
                string end = RangeUtil.BLGoodsCode.GetEndString(this._stockOverListCndtn.Ed_BLGoodsCode);

                EditCondition(
                    ref addConditions,
                    string.Format("�a�k�R�[�h" + ct_RangeConst, start, end)
                );
            }
            //--- ADD 2008/10/03 �s��Ή�[6074] ---------->>>>>

            // �ǉ�
            foreach ( string exCondStr in addConditions ) {
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
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

		#region �� ���o����������ҏW
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.13</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCZAI02182P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion

        // ADD 2008/10/06 �s��Ή�[6074]---------->>>>>
        #region <�͈͊֘A/>

        /// <summary>
        /// �͈̓��[�e�B���e�B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�R�[�h�͈̔͂ƌ��̏���񋟂��܂��B</br>
        /// <br>Programmer : 30434 �H�� �b�D</br>
        /// <br>Date       : 2008.09.30</br>
        /// </remarks>
        public static class RangeUtil
        {
            /// <summary>�ŏ�����</summary>
            public const string FROM_BEGIN = "�ŏ�����";
            /// <summary>�Ō�܂�</summary>
            public const string TO_END = "�Ō�܂�";

            /// <summary>
            /// �ŏ����炩���肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="minNumber">�ŏ��l</param>
            /// <returns><c>true</c> :�ŏ�����<br/><c>false</c>:�ŏ�����ł͂Ȃ�</returns>
            private static bool IsFromBegin(
                string startCode,
                int minNumber
            )
            {
                if (string.IsNullOrEmpty(startCode)) return true;

                int startNumber = -1;
                if (int.TryParse(startCode, out startNumber))
                {
                    return startNumber < minNumber;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// �Ō�܂ł����肵�܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <param name="maxNumber">�ő�l</param>
            /// <returns><c>true</c> :�Ō�܂�<br/><c>false</c>:�Ō�܂łł͂Ȃ�</returns>
            private static bool IsToEnd(
                string endCode,
                int maxNumber
            )
            {
                if (string.IsNullOrEmpty(endCode)) return true;

                int endNumber = -1;
                if (int.TryParse(endCode, out endNumber))
                {
                    return endNumber >= maxNumber;
                }
                else
                {
                    return false;
                }
            }

            #region <�q�ɃR�[�h/>

            /// <summary>
            /// �q�ɁF�q�ɃR�[�h
            /// </summary>
            public static class WarehouseCode
            {
                /// <summary>���x��</summary>
                public const string LABEL = "�q��";
                /// <summary>�ŏ��l</summary>
                public const int MIN = 1;
                /// <summary>�ő�l</summary>
                public const int MAX = 9999;
                /// <summary>���l�t�H�[�}�b�g</summary>
                public const string NUMBER_FORMAT = "0000";

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(string startCode, string endCode)
                {
                    return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(string startCode)
                {
                    return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(string endCode)
                {
                    return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
                }
            }

            #endregion  // <�q�ɃR�[�h/>

            #region <�d����R�[�h/>

            /// <summary>
            /// �d����F�d����R�[�h
            /// </summary>
            public static class SupplierCode
            {
                /// <summary>���x��</summary>
                public const string LABEL = "�d����";
                /// <summary>�ŏ��l</summary>
                public const int MIN = 1;
                /// <summary>�ő�l</summary>
                public const int MAX = 999999;
                /// <summary>���l�t�H�[�}�b�g</summary>
                public const string NUMBER_FORMAT = "000000";

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(int startCode, int endCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(int startCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(int endCode)
                {
                    return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
                }
            }

            #endregion

            #region <���i���[�J�[�R�[�h/>

            /// <summary>
            /// ���[�J�[�F���i���[�J�[�R�[�h
            /// </summary>
            public static class GoodsMakerCode
            {
                /// <summary>���x��</summary>
                public const string LABEL = "���[�J�[";
                /// <summary>�ŏ��l</summary>
                public const int MIN = 1;
                /// <summary>�ő�l</summary>
                public const int MAX = 9999;
                /// <summary>���l�t�H�[�}�b�g</summary>
                public const string NUMBER_FORMAT = "0000";

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(int startCode, int endCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(int startCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(int endCode)
                {
                    return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
                }
            }

            #endregion  // <���i���[�J�[�R�[�h/>

            #region <���i�啪�ރR�[�h/>

            /// <summary>
            /// ���i�啪�ށF���i�啪�ރR�[�h
            /// </summary>
            public static class GoodsLGroupCode
            {
                /// <summary>���x��</summary>
                public const string LABEL = "���i�啪��";
                /// <summary>�ŏ��l</summary>
                public const int MIN = 1;
                /// <summary>�ő�l</summary>
                public const int MAX = 9999;
                /// <summary>���l�t�H�[�}�b�g</summary>
                public const string NUMBER_FORMAT = "0000";

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(int startCode, int endCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
                }

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(string startCode, string endCode)
                {
                    return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(int startCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(int endCode)
                {
                    return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(string startCode)
                {
                    return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(string endCode)
                {
                    return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
                }
            }

            #endregion  // <���i�啪�ރR�[�h/>

            #region <���i�����ރR�[�h/>

            /// <summary>
            /// ���i�����ށF���i�����ރR�[�h
            /// </summary>
            public static class GoodsMGroupCode
            {
                /// <summary>���x��</summary>
                public const string LABEL = "���i������";
                /// <summary>�ŏ��l</summary>
                public const int MIN = 1;
                /// <summary>�ő�l</summary>
                public const int MAX = 9999;
                /// <summary>���l�t�H�[�}�b�g</summary>
                public const string NUMBER_FORMAT = "0000";

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(int startCode, int endCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
                }

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(string startCode, string endCode)
                {
                    return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(int startCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(int endCode)
                {
                    return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(string startCode)
                {
                    return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(string endCode)
                {
                    return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
                }
            }

            #endregion  // <���i�����ރR�[�h/>

            #region <�a�k�O���[�v�R�[�h/>

            /// <summary>
            /// �O���[�v�R�[�h�FBL�O���[�v�R�[�h
            /// </summary>
            public static class BLGroupCode
            {
                /// <summary>���x��</summary>
                public const string LABEL = "�O���[�v�R�[�h";
                /// <summary>�ŏ��l</summary>
                public const int MIN = 1;
                /// <summary>�ő�l</summary>
                public const int MAX = 99999;
                /// <summary>���l�t�H�[�}�b�g</summary>
                public const string NUMBER_FORMAT = "00000";

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(int startCode, int endCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
                }

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(string startCode, string endCode)
                {
                    return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(int startCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(int endCode)
                {
                    return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(string startCode)
                {
                    return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(string endCode)
                {
                    return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
                }
            }

            #endregion  // <�a�k�O���[�v�R�[�h/>

            #region <���Е��ރR�[�h/>

            /// <summary>
            /// ���i�敪�F���Е��ރR�[�h
            /// </summary>
            public static class EnterpriseGanreCode
            {
                /// <summary>���x��</summary>
                public const string LABEL = "���i�敪";
                /// <summary>�ŏ��l</summary>
                public const int MIN = 1;
                /// <summary>�ő�l</summary>
                public const int MAX = 9999;
                /// <summary>���l�t�H�[�}�b�g</summary>
                public const string NUMBER_FORMAT = "0000";

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(int startCode, int endCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(int startCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(int endCode)
                {
                    return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
                }
            }

            #endregion  // <���Е��ރR�[�h/>

            #region <�a�k�R�[�h/>

            /// <summary>
            /// BL�R�[�h�FBL�R�[�h
            /// </summary>
            public static class BLGoodsCode
            {
                /// <summary>���x��</summary>
                public const string LABEL = "�a�k�R�[�h";
                /// <summary>�ŏ��l</summary>
                public const int MIN = 1;
                /// <summary>�ő�l</summary>
                public const int MAX = 99999;
                /// <summary>���l�t�H�[�}�b�g</summary>
                public const string NUMBER_FORMAT = "00000";

                /// <summary>
                /// �S�͈͂����肵�܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
                public static bool IsAllRange(int startCode, int endCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
                }

                /// <summary>
                /// �J�n��������擾���܂��B
                /// </summary>
                /// <param name="startCode">�J�n�R�[�h</param>
                /// <returns>�J�n������</returns>
                public static string GetStartString(int startCode)
                {
                    return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
                }

                /// <summary>
                /// �I����������擾���܂��B
                /// </summary>
                /// <param name="endCode">�I���R�[�h</param>
                /// <returns>�I��������</returns>
                public static string GetEndString(int endCode)
                {
                    return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
                }
            }

            #endregion  // <�a�k�R�[�h�F�a�k�R�[�h/>
        }

        #endregion  // <�͈�/>
        // ADD 2008/10/06 �s��Ή�[6074]----------<<<<<
		#endregion
	}
}
