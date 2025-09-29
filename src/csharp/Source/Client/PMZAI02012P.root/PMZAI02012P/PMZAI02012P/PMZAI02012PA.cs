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
	/// �݌Ɍ���N�����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌Ɍ���N��̈�����s���B</br>
	/// <br>Programmer : 30416 ���� ����</br>
	/// <br>Date       : 2008.08.06</br>
    /// <br>Update     : 2008/10/10 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>Update Note: 2009/03/17 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12704</br>
    /// </remarks>
	class PMZAI02012PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
        /// �݌Ɍ���N�����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �݌Ɍ���N�����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
		/// </remarks>
		public PMZAI02012PA()
		{
		}

		/// <summary>
        /// �݌Ɍ���N�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �݌Ɍ���N�����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
		/// </remarks>
        public PMZAI02012PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._stockMonthYearReportCndtn = this._printInfo.jyoken as StockMonthYearReportCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					                // ������N���X
        private StockMonthYearReportCndtn _stockMonthYearReportCndtn;	// ���o�����N���X
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
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
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
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
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
                prtRpt.DataMember = PMZAI02014EA.ct_Tbl_StockNoShipment;
				
				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                //this.SetPrintCommonInfo(out commonInfo); // DEL 2009/03/17
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo); // ADD 2009/03/17

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
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
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
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
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
        /// <param name="rptObj"></param>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
		/// </remarks>
        //private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // DEL 2009/03/17
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17
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
			commonInfo.PrintMax    = (this._printInfo.rdData as DataView).Count;
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// ��]��
			commonInfo.MarginsTop  = this._printInfo.py;
			// ���]��
			commonInfo.MarginsLeft = this._printInfo.px;

            // --- ADD 2009/03/17 -------------------------------->>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // --- ADD 2009/03/17 --------------------------------<<<<< 
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
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            StockMonthYearReportCndtn extraInfo = (StockMonthYearReportCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
            //instance.PageHeaderSortOderTitle = this._stockGetuNenCndtn.PrintSortDivStateTitle;
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = StockMonthYearReportAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            //object[] titleObj = new object[] { this._stockMonthYearReportCndtn.ReportSubTitle, "�݌Ɍ���N��" };
            //instance.PageHeaderSubtitle = string.Format("{0}{1}", titleObj);
            instance.PageHeaderSubtitle = string.Format("�݌Ɍ���N��");

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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br>Update     : 2008/10/10 �Ɠc �M�u�@�󎚏�����ʂ̒��o���ڂɍ��킹��(�R�����g�A�E�g�����A�ʒu������ύX)</br>
        /// <br>                                   ���s�^�C�v�A���z�P�ʁA�Ώ۔N�����Ώ۔N���A���z�P�ʁA���s�N��</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // �Ώ۔N�� ----------------------------------------------------------------------------------------------------
            string st_ShipArrivalDate = string.Empty;
            string ed_ShipArrivalDate = string.Empty;

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ((this._stockMonthYearReportCndtn.St_AddUpYearMonth != DateTime.MinValue) || (this._stockMonthYearReportCndtn.Ed_AddUpYearMonth != DateTime.MinValue))
            {
                // �J�n
                if (this._stockMonthYearReportCndtn.St_AddUpYearMonth != DateTime.MinValue)
                    //st_ShipArrivalDate = this._stockMonthYearReportCndtn.St_AddUpYearMonth.ToString("yyyy�NMM��");        //DEL 2008/10/10 �����ύX
                    st_ShipArrivalDate = this._stockMonthYearReportCndtn.St_AddUpYearMonth.ToString("yyyy/MM");             //ADD 2008/10/10
                else
                    st_ShipArrivalDate = ct_Extr_Top;
                // �I��
                if (this._stockMonthYearReportCndtn.Ed_AddUpYearMonth != DateTime.MinValue)
                    //ed_ShipArrivalDate = this._stockMonthYearReportCndtn.Ed_AddUpYearMonth.ToString("yyyy�NMM��");        //DEL 2008/10/10 �����ύX
                    ed_ShipArrivalDate = this._stockMonthYearReportCndtn.Ed_AddUpYearMonth.ToString("yyyy/MM");             //ADD 2008/10/10
                else
                    ed_ShipArrivalDate = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format(
                        //"�Ώ۔N���F" + ct_RangeConst,         //DEL 2008/10/10 "�F"��2�\��������
                        "�Ώ۔N��" + ct_RangeConst,             //ADD 2008/10/10
                        st_ShipArrivalDate,
                        ed_ShipArrivalDate));
            }
            // ���z�P��
            if (this._stockMonthYearReportCndtn.MoneyUnit == StockMonthYearReportCndtn.MoneyUnitState.One)
            {
                this.EditCondition(
                   ref addConditions,
                   string.Format(
                       "���z�P�ʁF�~"));
            }
            else
            {
                this.EditCondition(
                   ref addConditions,
                   string.Format(
                       "���z�P�ʁF��~"));
            }
            // ���s�^�C�v
            if (this._stockMonthYearReportCndtn.PrintType == StockMonthYearReportCndtn.PrintTypeState.ThisMonth)
            {
                this.EditCondition(
                   ref addConditions,
                   string.Format(
                       "���s�^�C�v�F����"));
            }
            else
            {
                this.EditCondition(
                   ref addConditions,
                   string.Format(
                       "���s�^�C�v�F����"));
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �\�[�g�� ----------------------------------------------------------------------------------------------------
            //this.EditCondition(ref addConditions, String.Format("�\�[�g���F{0}",
            //                                                        this._stockNoShipmentListCndtn.PrintSortDivStateTitle));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �q��
            if (this._stockMonthYearReportCndtn.St_WarehouseCode != string.Empty || this._stockMonthYearReportCndtn.Ed_WarehouseCode != string.Empty)
            {
                string st_WarehouseCode = this._stockMonthYearReportCndtn.St_WarehouseCode;
                string ed_WarehouseCode = this._stockMonthYearReportCndtn.Ed_WarehouseCode;

                if ( st_WarehouseCode == string.Empty )
                    st_WarehouseCode = ct_Extr_Top;
                //if ( ed_WarehouseCode == string.Empty )                                       //DEL 2008/10/10 "9999"�����u�Ō�܂Łv�Ƃ���
                if (( ed_WarehouseCode == string.Empty ) || (ed_WarehouseCode == "9999"))       //ADD 2008/10/10
                    ed_WarehouseCode = ct_Extr_End;

                if ((st_WarehouseCode != ct_Extr_Top) || (ed_WarehouseCode != ct_Extr_End))     //ADD 2008/10/10
                {                                                                               //ADD 2008/10/10
                    this.EditCondition(
                        ref addConditions,
                        string.Format("�q��" + ct_RangeConst, st_WarehouseCode, ed_WarehouseCode));
                }                                                                               //ADD 2008/10/10
            }
            // �d����
            //if (this._stockMonthYearReportCndtn.St_SupplierCd != 0 || this._stockMonthYearReportCndtn.Ed_SupplierCd != 999999999)     //DEL 2008/10/10 �����ύX
            if (this._stockMonthYearReportCndtn.St_SupplierCd != 0 || this._stockMonthYearReportCndtn.Ed_SupplierCd != 999999)          //ADD 2008/10/10
            {
                // --- ADD 2008/10/10 ---------------------------------------------------------------->>>>>
                string st_SupplierCd = this._stockMonthYearReportCndtn.St_SupplierCd.ToString("000000");
                string ed_SupplierCd = this._stockMonthYearReportCndtn.Ed_SupplierCd.ToString("000000");
                if (st_SupplierCd == "000000")
                    st_SupplierCd = ct_Extr_Top;
                if (ed_SupplierCd == "999999")
                    ed_SupplierCd = ct_Extr_End;
                // --- ADD 2008/10/10 ----------------------------------------------------------------<<<<<

                this.EditCondition(
                    ref addConditions,
                    string.Format( "�d����" + ct_RangeConst,
                                    //this._stockMonthYearReportCndtn.St_SupplierCd,    //DEL 2008/10/10 �[���l�߁A�ŏ�����A�Ō�܂ł�\���̈�
                                    //this._stockMonthYearReportCndtn.Ed_SupplierCd));  //DEL 2008/10/10
                                    st_SupplierCd, ed_SupplierCd));                     //ADD 2008/10/10
            }
            // ���[�J�[
            //if (this._stockMonthYearReportCndtn.St_GoodsMakerCd != 0 || this._stockMonthYearReportCndtn.Ed_GoodsMakerCd != 999999)        //DEL 2008/10/10 �����ύX
            if (this._stockMonthYearReportCndtn.St_GoodsMakerCd != 0 || this._stockMonthYearReportCndtn.Ed_GoodsMakerCd != 9999)            //ADD 2008/10/10
            {
                // --- ADD 2008/10/10 ---------------------------------------------------------------->>>>>
                string st_GoodsMakerCd = this._stockMonthYearReportCndtn.St_GoodsMakerCd.ToString("0000");
                string ed_GoodsMakerCd = this._stockMonthYearReportCndtn.Ed_GoodsMakerCd.ToString("0000");
                if (st_GoodsMakerCd == "0000")
                    st_GoodsMakerCd = ct_Extr_Top;
                if (ed_GoodsMakerCd == "9999")
                    ed_GoodsMakerCd = ct_Extr_End;
                // --- ADD 2008/10/10 ----------------------------------------------------------------<<<<<

                this.EditCondition(
                    ref addConditions,
                    string.Format( "���[�J�[" + ct_RangeConst,
                                    //this._stockMonthYearReportCndtn.St_GoodsMakerCd,      //DEL 2008/10/10 �[���l�߁A�ŏ�����A�Ō�܂ł�\���̈�
                                    //this._stockMonthYearReportCndtn.Ed_GoodsMakerCd));    //DEL 2008/10/10
                                    st_GoodsMakerCd, ed_GoodsMakerCd));                     //ADD 2008/10/10
            }
            // ���i�啪��
            if (this._stockMonthYearReportCndtn.St_LargeGoodsGanreCode != string.Empty || this._stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode != string.Empty)
            {
                string st_LargeGoodsGanreCode = this._stockMonthYearReportCndtn.St_LargeGoodsGanreCode;
                string ed_LargeGoodsGanreCode = this._stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode;

                if (st_LargeGoodsGanreCode == string.Empty)
                    st_LargeGoodsGanreCode = ct_Extr_Top;
                //if (ed_LargeGoodsGanreCode == string.Empty)                                               //DEL 2008/10/10 "9999"�����u�Ō�܂Łv�Ƃ���
                if ((ed_LargeGoodsGanreCode == string.Empty) || (ed_LargeGoodsGanreCode == "9999"))         //ADD 2008/10/10
                    ed_LargeGoodsGanreCode = ct_Extr_End;

                if ((st_LargeGoodsGanreCode != ct_Extr_Top) || (ed_LargeGoodsGanreCode != ct_Extr_End))     //ADD 2008/10/10
                {                                                                                           //ADD 2008/10/10
                    this.EditCondition(
                        ref addConditions,
                        string.Format("���i�啪��" + ct_RangeConst, st_LargeGoodsGanreCode, ed_LargeGoodsGanreCode));
                }                                                                                           //ADD 2008/10/10
            }
            // ���i������
            if (this._stockMonthYearReportCndtn.St_MediumGoodsGanreCode != string.Empty || this._stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode != string.Empty)
            {
                string st_MediumGoodsGanreCode = this._stockMonthYearReportCndtn.St_MediumGoodsGanreCode;
                string ed_MediumGoodsGanreCode = this._stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode;

                if (st_MediumGoodsGanreCode == string.Empty)
                    st_MediumGoodsGanreCode = ct_Extr_Top;
                //if (ed_MediumGoodsGanreCode == string.Empty)                                              //DEL 2008/10/10 "9999"�����u�Ō�܂Łv�Ƃ���
                if ((ed_MediumGoodsGanreCode == string.Empty) || (ed_MediumGoodsGanreCode == "9999"))       //ADD 2008/10/10
                    ed_MediumGoodsGanreCode = ct_Extr_End;

                if ((st_MediumGoodsGanreCode != ct_Extr_Top) || (ed_MediumGoodsGanreCode != ct_Extr_End))   //ADD 2008/10/10
                {                                                                                           //ADD 2008/10/10
                    this.EditCondition(
                        ref addConditions,
                        string.Format("���i������" + ct_RangeConst, st_MediumGoodsGanreCode, ed_MediumGoodsGanreCode));
                }                                                                                           //ADD 2008/10/10
            }
            // �O���[�v�R�[�h
            if (this._stockMonthYearReportCndtn.St_DetailGoodsGanreCode != string.Empty || this._stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode != string.Empty)
            {
                string st_DetailGoodsGanreCode = this._stockMonthYearReportCndtn.St_DetailGoodsGanreCode;
                string ed_DetailGoodsGanreCode = this._stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode;

                if (st_DetailGoodsGanreCode == string.Empty)
                    st_DetailGoodsGanreCode = ct_Extr_Top;
                //if (ed_DetailGoodsGanreCode == string.Empty)                                              //DEL 2008/10/10 "99999"�����u�Ō�܂Łv�Ƃ���
                if ((ed_DetailGoodsGanreCode == string.Empty) || (ed_DetailGoodsGanreCode == "99999"))      //ADD 2008/10/10
                    ed_DetailGoodsGanreCode = ct_Extr_End;

                if ((st_DetailGoodsGanreCode != ct_Extr_Top) || (ed_DetailGoodsGanreCode != ct_Extr_End))   //ADD 2008/10/10
                {                                                                                           //ADD 2008/10/10
                    this.EditCondition(
                        ref addConditions,
                        string.Format("�O���[�v�R�[�h" + ct_RangeConst, st_DetailGoodsGanreCode, ed_DetailGoodsGanreCode));
                }
            }
            // ���i�ԍ�
            if (this._stockMonthYearReportCndtn.St_GoodsNo != string.Empty || this._stockMonthYearReportCndtn.Ed_GoodsNo != string.Empty)
            {
                string st_GoodsNo = this._stockMonthYearReportCndtn.St_GoodsNo;
                string ed_GoodsNo = this._stockMonthYearReportCndtn.Ed_GoodsNo;

                if ( st_GoodsNo == string.Empty )
                    st_GoodsNo = ct_Extr_Top;
                if ( ed_GoodsNo == string.Empty )
                    ed_GoodsNo = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format( "�i��" + ct_RangeConst, st_GoodsNo, ed_GoodsNo ) );
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.08.06</br>
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
        /// <br>Programmer : 30416 ���� ����</br>
        /// <br>Date       : 2008.08.06</br>
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
		/// <br>Programmer : 30416 ���� ����</br>
		/// <br>Date       : 2008.08.06</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMZAI02012P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
