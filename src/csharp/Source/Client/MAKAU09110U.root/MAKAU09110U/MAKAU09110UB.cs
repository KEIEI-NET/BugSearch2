//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ���яC��
// �v���O�����T�v   �F���Ӑ���яC���̓o�^�E�ύX�E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F21024 ���X�� ��
// �C����    2009/01/06     �C�����e�FPartsman�p�ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2009/01/26     �C�����e�F��QID:10441,10447�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2009/01/28     �C�����e�F��QID:10447�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/06     �C�����e�FMantis�y13144�z�N����̓��Ӑ�ǉ����G���[�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/23     �C�����e�FMantis�y13484�z������No��ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30517 �Ė� �x��
// �C����    2011/11/08     �C�����e�F���яC�����s���Ɛ����ꗗ�\�̕ԕi�l�����ڂ�0�ɂȂ�s��C��
// ---------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Application;

// SFCMN00001U...�R���|�[�l���g
// SFCMN00002C...TDateTime
// SFCMN00006C...ConstantManagement
// SFCMN00008C...�{�^���摜�֘A
// SFCMN00011I...HFileHeader
// SFCMN00013C...TStrConv
// SFCMN00212I
// SFCMN00615C...�I�v�V�����R�[�h
// SFCMN00651C...���O�C�����擾
// SFCMN00654D...�I�v�V�����擾�f�[�^�N���X
// SFCMN09003I...�}�X�^�����e�p
// SFCMN09004C...�}�X�^�����e�p
// SFKTN01210A...���_���SecInfoAcs�A�N�Z�X�N���X
// SFKTN09001E...���_���SecInfoSet
// SFTOK01136E...CustomerCarSearch
// SFTOK01180U...�ڋq�����K�C�h
// SFTOK09241E...���Ӑ���f�[�^�N���X
// SFTOK09242A...���Ӑ���擾�A�N�Z�X�N���X
// SFTOK09381E...�]�ƈ����f�[�^�N���X
// SFUKK01333D...���X�P�W���[���擾�f�[�^�N���X
// SFUKK01334A...���X�P�W���[���擾�A�N�Z�X�N���X

namespace Broadleaf.Windows.Forms
{
    /// **********************************************************************
    /// <summary>
	///	���Ӑ���яC���t�H�[���N���X
	/// </summary>
	/// <remarks> 
	/// <br>note       : ���Ӑ�̔��|�E�����̎��яC�����s���܂��B</br>
    /// <br>Programmer : 30154 �����@���m</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br></br>
    /// <br>note       : ����.NS�p�ɕύX</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br></br>
    /// <br>Note       : PM.NS�p�ɕύX</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.01.06</br>
    /// <br></br>
    /// <br>Note       : ��QID:10441,10447�Ή�</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2009.01.26</br>
    /// <br></br>
    /// <br>Note       : ��QID:10447�Ή�</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2009.01.28</br>
    /// </remarks>
    /// **********************************************************************
	public class MAKAU09110UB : System.Windows.Forms.Form, IMasterMaintenanceAccDmdType
	{
		# region Private Members (Component)
		
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private System.Windows.Forms.Panel CustomerInfo_Panel;
		private Infragistics.Win.Misc.UltraLabel customerCode_Label;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel TotalDay_Tittle_Label;
		private Infragistics.Win.Misc.UltraLabel CustomerSnm_Label;
		private Broadleaf.Library.Windows.Forms.TLine tLine17;
		private Broadleaf.Library.Windows.Forms.TLine tLine5;
		private Broadleaf.Library.Windows.Forms.TLine tLine3;
		private Broadleaf.Library.Windows.Forms.TLine tLine2;
		private Broadleaf.Library.Windows.Forms.TLine tLine1;
		private Infragistics.Win.Misc.UltraLabel CustomerTittle_Label;
		private Infragistics.Win.Misc.UltraLabel CustomerInfo_Title_Label;
		private Infragistics.Win.Misc.UltraLabel TotalDay_Label;
		private Infragistics.Win.Misc.UltraLabel demandAddUpSecCd_Label;
		private Infragistics.Win.Misc.UltraLabel AddUpADate_Tittle_Label;
		private Broadleaf.Library.Windows.Forms.TDateEdit AddUpADate_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel demandAddUpSecName_Label;
		private Infragistics.Win.Misc.UltraLabel SecInf_Tittle_Label;
		private Broadleaf.Library.Windows.Forms.TLine tLine26;
		private Broadleaf.Library.Windows.Forms.TLine tLine27;
		private Infragistics.Win.Misc.UltraLabel DemandSalesInfo_Title_Label;
        private Broadleaf.Library.Windows.Forms.TLine tLine41;
		private System.Windows.Forms.Timer Initial_Timer;
		private Broadleaf.Library.Windows.Forms.TLine tLine15;
		private Broadleaf.Library.Windows.Forms.TLine tLine22;
		private Broadleaf.Library.Windows.Forms.TLine tLine23;
        private Broadleaf.Library.Windows.Forms.TLine tLine24;
        private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel DmdSalesInfo_Panel;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Undo_Button;
        private Panel CustDmdPrc_panel;
        private Infragistics.Win.Misc.UltraLabel ClaimName_Label;
        private Infragistics.Win.Misc.UltraLabel claimCode_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel46;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel39;
        private Infragistics.Win.Misc.UltraLabel ultraLabel50;
        private TDateEdit ExpectedDepositDate_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel49;
        private TDateEdit BillPrintDate_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel CollectCond_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel52;
        private Infragistics.Win.Misc.UltraLabel ultraLabel51;
        private TNedit CollectCondValue_tNedit;
        private Infragistics.Win.Misc.UltraLabel CustomerName2_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerName_Label;
        private Infragistics.Win.Misc.UltraLabel ClaimSnm_Label;
        private Infragistics.Win.Misc.UltraLabel ClaimName2_Label;
        private UiSetControl uiSetControl1;
        private Panel LtBlInfo_Pnl;
        private Infragistics.Win.Misc.UltraLabel ultraLabel29;
        private TNedit Bf2TmBl_tNedit;
        private TNedit Bf3TmBl_tNedit;
        private TNedit LMBl_tNedit;
        private Infragistics.Win.Misc.UltraLabel Bf3TmBl_Label;
        private Infragistics.Win.Misc.UltraLabel Bf2TmBl_Label;
        private Infragistics.Win.Misc.UltraLabel LMBl_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.Misc.UltraLabel ultraLabel24;
        private Infragistics.Win.Misc.UltraLabel ultraLabel34;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel35;
        private Infragistics.Win.Misc.UltraLabel BlTotalTitle_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel33;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Panel AjustInfo_Pnl;
        private Infragistics.Win.Misc.UltraLabel ultraLabel57;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel58;
        private Infragistics.Win.Misc.UltraLabel ultraLabel56;
        private Infragistics.Win.Misc.UltraLabel ultraLabel32;
        private TNedit TaxAdjust_tNedit;
        private TNedit BalanceAdjust_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Panel DepositInfo_Pnl;
        private TNedit FeeNrml_tNedit;
        private Infragistics.Win.Misc.UltraLabel Fee_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel31;
        private Infragistics.Win.Misc.UltraLabel ultraLabel41;
        private Infragistics.Win.Misc.UltraLabel NrmlTotal_Label;
        private Infragistics.Win.Misc.UltraLabel ColDepoTotal_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private TNedit DisNrml_tNedit;
        private Infragistics.Win.Misc.UltraLabel Discount_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Panel SalesInfo_Pnl;
        private TNedit SaleslSlipCount_tNedit;
        private Infragistics.Win.Misc.UltraLabel Label101;
        private Infragistics.Win.Misc.UltraLabel ultraLabel30;
        private TNedit TtlItdedRetTaxFree_tNedit;
        private TNedit TtlRetInnerTax_tNedit;
        private TNedit TtlRetOuterTax_tNedit;
        private TNedit TtlItdedRetInTax_tNedit;
        private TNedit TtlItdedRetOutTax_tNedit;
        private TNedit TtlItdedDisTaxFree_tNedit;
        private TNedit TtlDisInnerTax_tNedit;
        private TNedit TtlDisOuterTax_tNedit;
        private TNedit TtlItdedDisInTax_tNedit;
        private TNedit TtlItdedDisOutTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Infragistics.Win.Misc.UltraLabel RowSalesTotal_Tittle_Label;
        private Infragistics.Win.Misc.UltraLabel Paym_Title_Label;
        private TNedit ItdedSalesTaxFree_tNedit;
        private Infragistics.Win.Misc.UltraLabel ItdedTaxFree_Title_Label;
        private TNedit SalesInTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel Sales_Title_Label;
        private TNedit SalesOutTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel SalesPaymInfo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel OutTax_Title_Label;
        private TNedit ItdedSalesInTax_tNedit;
        private TNedit ItdedSalesOutTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel ColSalesTotal_Tittle_Label;
        private Infragistics.Win.Misc.UltraLabel ItdedOutTax_Tittle_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel OfsThisTimeSales_Label;
        private Infragistics.Win.Misc.UltraLabel ItdedOffsetTaxFree_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ItdedOffsetOutTax_Label;
        private Infragistics.Win.Misc.UltraLabel DepositInfo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel LtBlInfo_Title_Label;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_DemandInfo;
        private Infragistics.Win.Misc.UltraLabel BlTotal_Label;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDepositKind;
        private TLine tLine4;
        private TNedit OfsThisSalesTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel DisTotal_Label;
        private Infragistics.Win.Misc.UltraLabel RetTotal_Label;
        private Infragistics.Win.Misc.UltraLabel SalesTotal_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel ultraLabel36;
        private Infragistics.Win.Misc.UltraLabel OfsThisTimeSalesTaxInc_Label;
        private TNedit OffsetOutTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel48;
        private Infragistics.Win.Misc.UltraLabel ultraLabel47;
        private TNedit BillNo_tNedit;
        private Infragistics.Win.Misc.UltraLabel BillNo_uLabel;
        private TLine tLine6;
		private System.ComponentModel.IContainer components;

		# endregion
		
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>�R���X�g���N�^</summary>
		public MAKAU09110UB()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			// Culture��񏉊��ݒ�
			this.calendar = new System.Globalization.JapaneseCalendar();
			this.culture  = new System.Globalization.CultureInfo("ja-JP");
			this.culture.DateTimeFormat.Calendar = this.calendar;

			// �f�[�^�Z�b�g����\�z����
            //DataSetColumnConstruction();

            //�@��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			
            // �S���҂̋@�\���䏈���擾


			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canClose = true;		// �f�t�H���g:true�Œ�
			this._canNew   = true;

			this._canDelete                         = false;
			this._canLogicalDeleteDataExtraction    = false;
			this._defaultAutoFillToAccRecGridColumn = true;
			this._defaultAutoFillToDmdPrcGridColumn = true;

			// �ϐ�������
			this._customerAcs         = new CustomerSearchAcs();
            this._customerInfoAcs     = new CustomerInfoAcs();
			this._secInfoAcs          = new SecInfoAcs();
            this._custAccRecDmdPrcAcs = new CustAccRecDmdPrcAcs();

			this._accRecDataIndex   = -1;
			this._dmdPrcDataIndex   = -1;
	
			this._totalCount = 0;
			
			this._customerTable  = new Hashtable();
			this._secInfSetTable = new Hashtable();

			// GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._accRecIndexBuf	= -2;
			this._dmdPrcIndexBuf	= -2;
			this._customerCodeBuf	= -2;
			this._targetTableBuf	= "";
			
			this._sectionCode        = "";
			this._targetCustomerCode = 0;
		
			this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
			this._targetTableName          = "";

			this._formBeingStarted = false;   // ��ʋN������FLG

			// ���_�I�v�V����
			if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION ) >0)
			{
				this.Opt_Section        = true;
                //this._autoAllUpDateMode = false;
			} 
			else 
			{
				this.Opt_Section       = false;
                //this._autoAllUpDateMode = true;
			}
			//���_�I�v�V��������
    		// ���O�C���S���ҏ��
			if ( LoginInfoAcquisition.Employee != null) 
			{
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;
				int employeeMode = employee.UserAdminFlag;  //���[�U�[�Ǘ���FLG
			}

            // 2009.01.06 Add >>>
            BalanceDisplayTable.CreateTable(ref this._totalDisplayTable);
            this._totalDisplayTable.Rows.Add(this._totalDisplayTable.NewRow());

            this._depositRelDataAcs = new DepositRelDataAcs();
            string msg;
            this._depositRelDataAcs.GetInitialSettingData(out msg);

            this.DepositKindGridInitialSetting();
            // 2009.01.06 Add <<<
        }

		# endregion

        // ===================================================================================== //
		// �j��
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion
	
		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Events
		/// <summary>
		/// ��ʔ�\���C�x���g
		/// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
		/// </summary>
		public event MasterMaintenanceAccDmdTypeUnDisplayingEventHandler UnDisplaying;
        
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�����o�[
		// ===================================================================================== //
		#region Private Menbers
		// �ҏW���
        private CustAccRec     _editCustAccRec    = null;       // �ҏW�p
        private CustDmdPrc     _editCustDmdPrc    = null;       // �ҏW�p
        private CustAccRec     _custAccRecClone   = null;       // �N�����o�b�N�A�b�v�p
        private CustDmdPrc     _custDmdPrcClone   = null;       // �N�����o�b�N�A�b�v�p

        // 2009.01.06 Add >>>
        private List<AccRecDepoTotal> _editAccRecDepoList = null;  // �ҏW�p�̓����W�v�f�[�^���X�g
        private List<DmdDepoTotal> _editDmdDepoList = null;        // �ҏW�p�̓����W�v�f�[�^���X�g
        private CustAccRec _custAccRecTotal = new CustAccRec();    // �W�v���R�[�h�p
        private CustDmdPrc _custDmdPrcTotal = new CustDmdPrc();    // �W�v���R�[�h�p
        private List<AccRecDepoTotal> _accRecDepoTotalList = null;  // �W�v���R�[�h�p�����W�v�f�[�^���X�g
        private List<DmdDepoTotal> _dmdDepoTotalList = null;        // �W�v���R�[�h�p�����W�v�f�[�^���X�g
        private DataTable _totalDisplayTable = null;            // �c���\���p

        private DataTable _depositDataTable = null;             // ����������͗p
        private DataView _depositDataView = null;
        // 2009.01.06 Add <<<

		private int	           _logicalDeleteMode = -1;			// ��ʋN�����[�h


		private System.Globalization.Calendar    calendar;
		private System.Globalization.CultureInfo culture;

		private	DateTime									befTempDateTime ;

		private CustomerSearchAcs      _customerAcs         = null;		    // ���Ӑ���
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private CustomerInfoAcs        _customerInfoAcs     = null;         // ���Ӑ�A�N�Z�X
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		private SecInfoAcs             _secInfoAcs          = null;		    // ���_���
        private CustAccRecDmdPrcAcs    _custAccRecDmdPrcAcs = null;         // ���Ӑ攄�|���z�}�X�^�X�V
		private CustomerSearchRet      _prevCustomer;					    // ���Ӑ���Last
		
		private int                    _totalCount;						    // ����
		private string                 _enterpriseCode      = "";	        // ��ƃR�[�h
		private string                 _companySecCode      = "";           // �����_�R�[�h 

		private bool                   Opt_Section          = false;        // ���_OP�L��
        //private bool                   _autoAllUpDateMode   = false;        // �S���_�������ɔ��f���邩
		private bool                   _mainOfficeFuncFlag  = false;        // �{�Ћ@�\�t���O

		private Hashtable _customerTable  = new Hashtable();  // ���Ӑ�
		private Hashtable _secInfSetTable = new Hashtable();  // ���_���
		private Hashtable _AllaccrecTable = new Hashtable();  // ���|���z(�S�Ќv)
		private Hashtable _AlldmdprcTable = new Hashtable();  // �������z(�S�Ќv)

		// �v���p�e�B�p
		private bool   _canPrint;
		private bool   _canLogicalDeleteDataExtraction;
		private bool   _canClose;
		private bool   _canNew;
		private bool   _canDelete;
	
		private string _targetTableName;
		private int    _accRecDataIndex;
		private int    _dmdPrcDataIndex;
	
		//_GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int    _accRecIndexBuf;
		private int    _dmdPrcIndexBuf;
		private int    _customerCodeBuf;
		private string _targetTableBuf;
		
		private bool   _defaultAutoFillToAccRecGridColumn;
		private bool   _defaultAutoFillToDmdPrcGridColumn;

		private string _mainGridTitle    = "";
		private string _detailsGridTitle = "";

		private Image  _mainGridIcon     = null; 
		private Image  _detailsGridIcon  = null; 

		private MGridDisplayLayout _defaultGridDisplayLayout;


		private string _sectionCode;                    // �I�����_�R�[�h
		private int    _targetCustomerCode;             // �I�𓾈Ӑ�R�[�h
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private int    _targetClaimCode;                // �I�𐿋���R�[�h
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		private bool   _formBeingStarted = false;       // ��ʋN������ �N���r����Close���̏����G���[���p
		private bool   _timerStarted     = false;		// �d���N���z��

		private bool   _changeFlg        = false;       // ���͍��ڕύX��

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        // 2009.01.06 >>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
        //// �ǉ��p�l���\���ʒu
        ////private readonly Point _expansionPanelLocation = new Point(723,1);
        //// ���C�A�E�g�ύX�ɂ��\���ʒu���C��
        //private readonly Point _expansionPanelLocation = new Point(5, 307);
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
        private readonly Point _expansionPanelLocation = new Point(4, 293);

        private readonly Point _balance3LabelLocation = new Point(5, 66);
        private readonly Point _balance3EditLocation = new Point(96, 66);

        private readonly Point _balance1LabelLocation = new Point(5, 128);
        private readonly Point _balance1EditLocation = new Point(96, 128);

        // 2009.01.06 <<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        private int     _targetDivType;                     // �w��敪�i�����擾���ɕK�v��public property�Ŏ��)
        private string  _mngSectionCode;                    // �Ǘ��c�Ə��R�[�h�i�����ݒ�Ăяo�����Ɏg�p��public property�Ŏ��)
        private int     _condCustomerCode;                  // �����p���Ӑ�R�[�h
        private int     _condClaimCode;                     // �����p������R�[�h
        private string  _condSectionCode;                   // �����p�v�㋒�_�R�[�h

        // �w��敪�v���_�E���I�����ڒl�ݒ�
        private const int TARGET_DIV_CLAIM      = 0;      // �w��敪=������
        private const int TARGET_DIV_CUSTOMER   = 1;      // �w��敪=���Ӑ�
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

        // 2009.01.06 Add >>>
        private DepositRelDataAcs _depositRelDataAcs;
        // 2009.01.06 Add <<<

        # endregion

        // ===================================================================================== //
		// �萔��`
		// ===================================================================================== //
		#region Private Constant

		// �ҏW���[�h
		private const string INSERT_MODE                 = "�V�K���[�h";
		private const string REFER_MODE                  = "�Q�ƃ��[�h";
		private const string UPDATE_MODE                 = "�X�V���[�h";
		private const string DELETE_MODE                 = "�폜���[�h";

		// ���Ӑ��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string CUST_DELETE_DATE            = "�폜��";
		private const string CUST_CODE_TITLE             = "�R�[�h";
		private const string CUST_KANA_TITLE             = "���Ӑ�J�i";
		private const string CUST_NAME1_TITLE            = "���Ӑ於�̂P";
		private const string CUST_NAME2_TITLE            = "���Ӑ於�̂Q";
		private const string CUST_TOTALDAY_TITLE         = "����";
		private const string CUST_CORPORATEDIVCODE_TITLE = "�l�E�@�l";

		private const string CUST_GUID_TITLE             = "CUST_GUID";
		private const string CUSTOMER_TABLE              = "CUSTOMER";

		// ���|�E������View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string REC_SECCODE_TITLE           = "���_�R�[�h";

        private const string REC_ADDUPYEARMONTH_TITLE    = "_�v��N��";
        private const string REC_ADDUPDATE_TITLE         = "_�v��N����";
        private const string REC_ADDUPYEARMONTHJP_TITLE  = "�v��N��";
        private const string REC_ADDUPDATEJP_TITLE       = "�v��N����";
        private const string REC_TOTAL3_BEF_TITLE        = "�O�X�X��c��";
        private const string REC_TOTAL2_BEF_TITLE        = "�O�X��c��";
        private const string REC_TOTAL1_BEF_TITLE        = "�O��c��";
        private const string REC_THISTIMESALES_TITLE     = "���񔄏�";
        private const string REC_CONSTAX_TITLE           = "�����";
        private const string REC_THISTIMEPAYM_TITLE      = "����x��";
        private const string REC_PAYMCONSTAX_TITLE       = "�x�������";
        private const string REC_THISTIMEDEPO_TITLE      = "�������";
        private const string REC_ACCRECBLNCE_TITLE       = "���|�c��";
        private const string REC_DMDPRCBLNCE_TITLE       = "�����c��";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private const string REC_BALANCEADJUST_TITLE     = "�c�������z";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
        private const string REC_TOTALADJUST_TITLE       = "�c�������z�\��";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

		// Format��`
		private const string DATE_FORMAT                 = "gyy/MM/dd";
		private const string LONG_FORMAT                 = "###,###,##0�~";
		private const string MASK_MONEY                  = "#,##0;-#,##0;''";
		private const string MASK_CNT                    = "#,##0.00;-#,##0.00;''";
		private const string MASK_CODE                   = "#0;-#0;''";

		// �S�Ћ��_�R�[�h
		private const string ALLSECCODE                  = "000000";
		
		// �\�[�g�p�L�[
		private const string viewGridFilterDefault		 = "";
		private const string viewGridSortDefault		 = REC_ADDUPDATE_TITLE + " DESC";

		#endregion

		// ===================================================================================== //
		// Windows �t�H�[�� �f�U�C�i
		// ===================================================================================== //
		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance170 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance171 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance175 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance188 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance187 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance178 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance194 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance195 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance196 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance197 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance198 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance199 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance200 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance203 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance190 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance179 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance180 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance189 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance191 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance192 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance193 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU09110UB));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.CustomerInfo_Panel = new System.Windows.Forms.Panel();
            this.uGrid_DemandInfo = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tLine4 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ClaimSnm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ClaimName2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ClaimName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.claimCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel46 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine24 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine23 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine22 = new Broadleaf.Library.Windows.Forms.TLine();
            this.DemandSalesInfo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tLine15 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine41 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine27 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine26 = new Broadleaf.Library.Windows.Forms.TLine();
            this.customerCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.TotalDay_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerSnm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tLine17 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine5 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine3 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.CustomerTittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerInfo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TotalDay_Label = new Infragistics.Win.Misc.UltraLabel();
            this.demandAddUpSecCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.demandAddUpSecName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SecInf_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AddUpADate_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AddUpADate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tLine2 = new Broadleaf.Library.Windows.Forms.TLine();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Undo_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.DmdSalesInfo_Panel = new System.Windows.Forms.Panel();
            this.OffsetOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BillPrintDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.SalesInfo_Pnl = new System.Windows.Forms.Panel();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.OfsThisTimeSalesTaxInc_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.DisTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RetTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SalesTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OfsThisSalesTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.OfsThisTimeSales_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedOffsetTaxFree_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedOffsetOutTax_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SaleslSlipCount_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Label101 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.TtlItdedRetTaxFree_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedRetOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedDisTaxFree_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedDisOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.RowSalesTotal_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Paym_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedSalesTaxFree_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ItdedTaxFree_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Sales_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SalesPaymInfo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OutTax_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedSalesOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ColSalesTotal_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel36 = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedOutTax_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.DepositInfo_Pnl = new System.Windows.Forms.Panel();
            this.DepositInfo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.grdDepositKind = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraLabel41 = new Infragistics.Win.Misc.UltraLabel();
            this.NrmlTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ColDepoTotal_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.DisNrml_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Discount_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.FeeNrml_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Fee_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.AjustInfo_Pnl = new System.Windows.Forms.Panel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.TaxAdjust_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BalanceAdjust_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel58 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel56 = new Infragistics.Win.Misc.UltraLabel();
            this.LtBlInfo_Pnl = new System.Windows.Forms.Panel();
            this.BlTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.LtBlInfo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.BlTotalTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.Bf2TmBl_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Bf3TmBl_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.LMBl_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Bf3TmBl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Bf2TmBl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.LMBl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.CustDmdPrc_panel = new System.Windows.Forms.Panel();
            this.ExpectedDepositDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.CollectCondValue_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CollectCond_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel52 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel51 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel50 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel49 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel48 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel47 = new Infragistics.Win.Misc.UltraLabel();
            this.TtlItdedDisInTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ItdedSalesInTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SalesInTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlRetInnerTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlDisInnerTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlRetOuterTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedRetInTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SalesOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlDisOuterTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.BillNo_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tLine6 = new Broadleaf.Library.Windows.Forms.TLine();
            this.CustomerInfo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_DemandInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.DmdSalesInfo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetOutTax_tNedit)).BeginInit();
            this.SalesInfo_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleslSlipCount_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetTaxFree_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetOutTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisTaxFree_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisOutTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItdedSalesTaxFree_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItdedSalesOutTax_tNedit)).BeginInit();
            this.DepositInfo_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepositKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisNrml_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeeNrml_tNedit)).BeginInit();
            this.AjustInfo_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaxAdjust_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAdjust_tNedit)).BeginInit();
            this.LtBlInfo_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bf2TmBl_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bf3TmBl_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMBl_tNedit)).BeginInit();
            this.CustDmdPrc_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectCondValue_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisInTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItdedSalesInTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlRetInnerTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlDisInnerTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlRetOuterTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetInTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOutTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlDisOuterTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine6)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 636);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(978, 23);
            this.ultraStatusBar1.TabIndex = 3;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // CustomerInfo_Panel
            // 
            this.CustomerInfo_Panel.Controls.Add(this.tLine6);
            this.CustomerInfo_Panel.Controls.Add(this.uGrid_DemandInfo);
            this.CustomerInfo_Panel.Controls.Add(this.tLine4);
            this.CustomerInfo_Panel.Controls.Add(this.ClaimSnm_Label);
            this.CustomerInfo_Panel.Controls.Add(this.ClaimName2_Label);
            this.CustomerInfo_Panel.Controls.Add(this.CustomerName_Label);
            this.CustomerInfo_Panel.Controls.Add(this.CustomerName2_Label);
            this.CustomerInfo_Panel.Controls.Add(this.ClaimName_Label);
            this.CustomerInfo_Panel.Controls.Add(this.claimCode_Label);
            this.CustomerInfo_Panel.Controls.Add(this.BillNo_tNedit);
            this.CustomerInfo_Panel.Controls.Add(this.ultraLabel46);
            this.CustomerInfo_Panel.Controls.Add(this.tLine24);
            this.CustomerInfo_Panel.Controls.Add(this.tLine23);
            this.CustomerInfo_Panel.Controls.Add(this.tLine22);
            this.CustomerInfo_Panel.Controls.Add(this.DemandSalesInfo_Title_Label);
            this.CustomerInfo_Panel.Controls.Add(this.tLine15);
            this.CustomerInfo_Panel.Controls.Add(this.tLine41);
            this.CustomerInfo_Panel.Controls.Add(this.tLine27);
            this.CustomerInfo_Panel.Controls.Add(this.tLine26);
            this.CustomerInfo_Panel.Controls.Add(this.customerCode_Label);
            this.CustomerInfo_Panel.Controls.Add(this.Mode_Label);
            this.CustomerInfo_Panel.Controls.Add(this.ultraLabel6);
            this.CustomerInfo_Panel.Controls.Add(this.TotalDay_Tittle_Label);
            this.CustomerInfo_Panel.Controls.Add(this.CustomerSnm_Label);
            this.CustomerInfo_Panel.Controls.Add(this.tLine17);
            this.CustomerInfo_Panel.Controls.Add(this.tLine5);
            this.CustomerInfo_Panel.Controls.Add(this.tLine3);
            this.CustomerInfo_Panel.Controls.Add(this.tLine1);
            this.CustomerInfo_Panel.Controls.Add(this.CustomerTittle_Label);
            this.CustomerInfo_Panel.Controls.Add(this.CustomerInfo_Title_Label);
            this.CustomerInfo_Panel.Controls.Add(this.TotalDay_Label);
            this.CustomerInfo_Panel.Controls.Add(this.demandAddUpSecCd_Label);
            this.CustomerInfo_Panel.Controls.Add(this.demandAddUpSecName_Label);
            this.CustomerInfo_Panel.Controls.Add(this.SecInf_Tittle_Label);
            this.CustomerInfo_Panel.Controls.Add(this.BillNo_uLabel);
            this.CustomerInfo_Panel.Controls.Add(this.AddUpADate_Tittle_Label);
            this.CustomerInfo_Panel.Controls.Add(this.AddUpADate_tDateEdit);
            this.CustomerInfo_Panel.Controls.Add(this.tLine2);
            this.CustomerInfo_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CustomerInfo_Panel.Location = new System.Drawing.Point(0, 0);
            this.CustomerInfo_Panel.Name = "CustomerInfo_Panel";
            this.CustomerInfo_Panel.Size = new System.Drawing.Size(978, 203);
            this.CustomerInfo_Panel.TabIndex = 0;
            // 
            // uGrid_DemandInfo
            // 
            appearance18.BackColor = System.Drawing.Color.White;
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_DemandInfo.DisplayLayout.Appearance = appearance18;
            this.uGrid_DemandInfo.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_DemandInfo.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_DemandInfo.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_DemandInfo.DisplayLayout.MaxRowScrollRegions = 1;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.ActiveCellAppearance = appearance19;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_DemandInfo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_DemandInfo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.uGrid_DemandInfo.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance20.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance20.ForeColor = System.Drawing.Color.White;
            appearance20.TextHAlignAsString = "Center";
            appearance20.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_DemandInfo.DisplayLayout.Override.HeaderAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowAlternateAppearance = appearance21;
            appearance22.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance22.TextVAlignAsString = "Middle";
            this.uGrid_DemandInfo.DisplayLayout.Override.RowAppearance = appearance22;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance23.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance23.ForeColor = System.Drawing.Color.White;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowSelectorAppearance = appearance23;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            this.uGrid_DemandInfo.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_DemandInfo.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_DemandInfo.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_DemandInfo.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_DemandInfo.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_DemandInfo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_DemandInfo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_DemandInfo.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_DemandInfo.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_DemandInfo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_DemandInfo.Location = new System.Drawing.Point(7, 145);
            this.uGrid_DemandInfo.Name = "uGrid_DemandInfo";
            this.uGrid_DemandInfo.Size = new System.Drawing.Size(963, 47);
            this.uGrid_DemandInfo.TabIndex = 1342;
            this.uGrid_DemandInfo.TabStop = false;
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine4.Location = new System.Drawing.Point(5, 195);
            this.tLine4.Name = "tLine4";
            this.tLine4.Size = new System.Drawing.Size(968, 4);
            this.tLine4.TabIndex = 396;
            this.tLine4.Text = "tLine4";
            // 
            // ClaimSnm_Label
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.ClaimSnm_Label.Appearance = appearance1;
            this.ClaimSnm_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ClaimSnm_Label.Location = new System.Drawing.Point(179, 56);
            this.ClaimSnm_Label.Name = "ClaimSnm_Label";
            this.ClaimSnm_Label.Size = new System.Drawing.Size(496, 24);
            this.ClaimSnm_Label.TabIndex = 395;
            // 
            // ClaimName2_Label
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ClaimName2_Label.Appearance = appearance2;
            this.ClaimName2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ClaimName2_Label.Location = new System.Drawing.Point(702, 56);
            this.ClaimName2_Label.Name = "ClaimName2_Label";
            this.ClaimName2_Label.Size = new System.Drawing.Size(16, 24);
            this.ClaimName2_Label.TabIndex = 394;
            this.ClaimName2_Label.Visible = false;
            // 
            // CustomerName_Label
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.CustomerName_Label.Appearance = appearance3;
            this.CustomerName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerName_Label.Location = new System.Drawing.Point(722, 31);
            this.CustomerName_Label.Name = "CustomerName_Label";
            this.CustomerName_Label.Size = new System.Drawing.Size(16, 24);
            this.CustomerName_Label.TabIndex = 393;
            this.CustomerName_Label.Visible = false;
            // 
            // CustomerName2_Label
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.CustomerName2_Label.Appearance = appearance4;
            this.CustomerName2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerName2_Label.Location = new System.Drawing.Point(702, 31);
            this.CustomerName2_Label.Name = "CustomerName2_Label";
            this.CustomerName2_Label.Size = new System.Drawing.Size(16, 24);
            this.CustomerName2_Label.TabIndex = 392;
            this.CustomerName2_Label.Visible = false;
            // 
            // ClaimName_Label
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.ClaimName_Label.Appearance = appearance5;
            this.ClaimName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ClaimName_Label.Location = new System.Drawing.Point(722, 56);
            this.ClaimName_Label.Name = "ClaimName_Label";
            this.ClaimName_Label.Size = new System.Drawing.Size(16, 24);
            this.ClaimName_Label.TabIndex = 3;
            this.ClaimName_Label.Visible = false;
            // 
            // claimCode_Label
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.claimCode_Label.Appearance = appearance6;
            this.claimCode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.claimCode_Label.Location = new System.Drawing.Point(105, 56);
            this.claimCode_Label.Name = "claimCode_Label";
            this.claimCode_Label.Size = new System.Drawing.Size(71, 24);
            this.claimCode_Label.TabIndex = 2;
            // 
            // ultraLabel46
            // 
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel46.Appearance = appearance7;
            this.ultraLabel46.Location = new System.Drawing.Point(12, 56);
            this.ultraLabel46.Name = "ultraLabel46";
            this.ultraLabel46.Size = new System.Drawing.Size(68, 24);
            this.ultraLabel46.TabIndex = 391;
            this.ultraLabel46.Text = "������";
            // 
            // tLine24
            // 
            this.tLine24.BackColor = System.Drawing.Color.Transparent;
            this.tLine24.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine24.ForeColor = System.Drawing.Color.Black;
            this.tLine24.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine24.Location = new System.Drawing.Point(325, 107);
            this.tLine24.Name = "tLine24";
            this.tLine24.Size = new System.Drawing.Size(4, 32);
            this.tLine24.TabIndex = 390;
            this.tLine24.Text = "tLine24";
            // 
            // tLine23
            // 
            this.tLine23.BackColor = System.Drawing.Color.Transparent;
            this.tLine23.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine23.ForeColor = System.Drawing.Color.Black;
            this.tLine23.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine23.Location = new System.Drawing.Point(402, 107);
            this.tLine23.Name = "tLine23";
            this.tLine23.Size = new System.Drawing.Size(4, 32);
            this.tLine23.TabIndex = 389;
            this.tLine23.Text = "tLine23";
            // 
            // tLine22
            // 
            this.tLine22.BackColor = System.Drawing.Color.Transparent;
            this.tLine22.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine22.ForeColor = System.Drawing.Color.Black;
            this.tLine22.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine22.Location = new System.Drawing.Point(750, 107);
            this.tLine22.Name = "tLine22";
            this.tLine22.Size = new System.Drawing.Size(4, 32);
            this.tLine22.TabIndex = 388;
            this.tLine22.Text = "tLine22";
            // 
            // DemandSalesInfo_Title_Label
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance8.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.DemandSalesInfo_Title_Label.Appearance = appearance8;
            this.DemandSalesInfo_Title_Label.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DemandSalesInfo_Title_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DemandSalesInfo_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DemandSalesInfo_Title_Label.Location = new System.Drawing.Point(4, 83);
            this.DemandSalesInfo_Title_Label.Name = "DemandSalesInfo_Title_Label";
            this.DemandSalesInfo_Title_Label.Size = new System.Drawing.Size(204, 24);
            this.DemandSalesInfo_Title_Label.TabIndex = 8;
            this.DemandSalesInfo_Title_Label.Text = "����������";
            // 
            // tLine15
            // 
            this.tLine15.BackColor = System.Drawing.Color.Transparent;
            this.tLine15.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine15.Location = new System.Drawing.Point(4, 106);
            this.tLine15.Name = "tLine15";
            this.tLine15.Size = new System.Drawing.Size(968, 4);
            this.tLine15.TabIndex = 387;
            this.tLine15.Text = "tLine15";
            // 
            // tLine41
            // 
            this.tLine41.BackColor = System.Drawing.Color.Transparent;
            this.tLine41.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine41.ForeColor = System.Drawing.Color.Black;
            this.tLine41.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine41.Location = new System.Drawing.Point(4, 27);
            this.tLine41.Name = "tLine41";
            this.tLine41.Size = new System.Drawing.Size(3, 169);
            this.tLine41.TabIndex = 367;
            this.tLine41.Text = "tLine41";
            // 
            // tLine27
            // 
            this.tLine27.BackColor = System.Drawing.Color.Transparent;
            this.tLine27.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine27.ForeColor = System.Drawing.Color.Black;
            this.tLine27.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine27.Location = new System.Drawing.Point(972, 27);
            this.tLine27.Name = "tLine27";
            this.tLine27.Size = new System.Drawing.Size(3, 168);
            this.tLine27.TabIndex = 365;
            this.tLine27.Text = "tLine27";
            // 
            // tLine26
            // 
            this.tLine26.BackColor = System.Drawing.Color.Transparent;
            this.tLine26.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine26.ForeColor = System.Drawing.Color.Black;
            this.tLine26.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine26.Location = new System.Drawing.Point(876, 27);
            this.tLine26.Name = "tLine26";
            this.tLine26.Size = new System.Drawing.Size(3, 56);
            this.tLine26.TabIndex = 364;
            this.tLine26.Text = "tLine26";
            // 
            // customerCode_Label
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance62.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance62.TextHAlignAsString = "Right";
            appearance62.TextVAlignAsString = "Middle";
            this.customerCode_Label.Appearance = appearance62;
            this.customerCode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.customerCode_Label.Location = new System.Drawing.Point(105, 31);
            this.customerCode_Label.Name = "customerCode_Label";
            this.customerCode_Label.Size = new System.Drawing.Size(71, 24);
            this.customerCode_Label.TabIndex = 0;
            // 
            // Mode_Label
            // 
            appearance10.ForeColor = System.Drawing.Color.White;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance10;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(872, 3);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 17;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // ultraLabel6
            // 
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance11;
            this.ultraLabel6.Location = new System.Drawing.Point(924, 55);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(28, 24);
            this.ultraLabel6.TabIndex = 7;
            this.ultraLabel6.Text = "��";
            // 
            // TotalDay_Tittle_Label
            // 
            appearance12.TextHAlignAsString = "Center";
            appearance12.TextVAlignAsString = "Middle";
            this.TotalDay_Tittle_Label.Appearance = appearance12;
            this.TotalDay_Tittle_Label.Location = new System.Drawing.Point(812, 55);
            this.TotalDay_Tittle_Label.Name = "TotalDay_Tittle_Label";
            this.TotalDay_Tittle_Label.Size = new System.Drawing.Size(44, 24);
            this.TotalDay_Tittle_Label.TabIndex = 5;
            this.TotalDay_Tittle_Label.Text = "����";
            // 
            // CustomerSnm_Label
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.CustomerSnm_Label.Appearance = appearance13;
            this.CustomerSnm_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerSnm_Label.Location = new System.Drawing.Point(179, 31);
            this.CustomerSnm_Label.Name = "CustomerSnm_Label";
            this.CustomerSnm_Label.Size = new System.Drawing.Size(496, 24);
            this.CustomerSnm_Label.TabIndex = 1;
            // 
            // tLine17
            // 
            this.tLine17.BackColor = System.Drawing.Color.Transparent;
            this.tLine17.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine17.Location = new System.Drawing.Point(4, 27);
            this.tLine17.Name = "tLine17";
            this.tLine17.Size = new System.Drawing.Size(968, 4);
            this.tLine17.TabIndex = 118;
            this.tLine17.Text = "tLine17";
            // 
            // tLine5
            // 
            this.tLine5.BackColor = System.Drawing.Color.Transparent;
            this.tLine5.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine5.ForeColor = System.Drawing.Color.Black;
            this.tLine5.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine5.Location = new System.Drawing.Point(100, 27);
            this.tLine5.Name = "tLine5";
            this.tLine5.Size = new System.Drawing.Size(4, 112);
            this.tLine5.TabIndex = 36;
            this.tLine5.Text = "tLine5";
            // 
            // tLine3
            // 
            this.tLine3.BackColor = System.Drawing.Color.Transparent;
            this.tLine3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine3.Location = new System.Drawing.Point(4, 83);
            this.tLine3.Name = "tLine3";
            this.tLine3.Size = new System.Drawing.Size(968, 4);
            this.tLine3.TabIndex = 34;
            this.tLine3.Text = "tLine3";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine1.ForeColor = System.Drawing.Color.Black;
            this.tLine1.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine1.Location = new System.Drawing.Point(797, 27);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(4, 56);
            this.tLine1.TabIndex = 32;
            this.tLine1.Text = "tLine1";
            // 
            // CustomerTittle_Label
            // 
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.CustomerTittle_Label.Appearance = appearance14;
            this.CustomerTittle_Label.Location = new System.Drawing.Point(12, 31);
            this.CustomerTittle_Label.Name = "CustomerTittle_Label";
            this.CustomerTittle_Label.Size = new System.Drawing.Size(66, 24);
            this.CustomerTittle_Label.TabIndex = 1;
            this.CustomerTittle_Label.Text = "���Ӑ�";
            // 
            // CustomerInfo_Title_Label
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance15.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.BorderColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Center";
            appearance15.TextVAlignAsString = "Middle";
            this.CustomerInfo_Title_Label.Appearance = appearance15;
            this.CustomerInfo_Title_Label.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.CustomerInfo_Title_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerInfo_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerInfo_Title_Label.Location = new System.Drawing.Point(4, 4);
            this.CustomerInfo_Title_Label.Name = "CustomerInfo_Title_Label";
            this.CustomerInfo_Title_Label.Size = new System.Drawing.Size(204, 24);
            this.CustomerInfo_Title_Label.TabIndex = 0;
            this.CustomerInfo_Title_Label.Text = "���Ӑ���";
            // 
            // TotalDay_Label
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.TotalDay_Label.Appearance = appearance16;
            this.TotalDay_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.TotalDay_Label.Location = new System.Drawing.Point(888, 55);
            this.TotalDay_Label.Name = "TotalDay_Label";
            this.TotalDay_Label.Size = new System.Drawing.Size(32, 24);
            this.TotalDay_Label.TabIndex = 4;
            // 
            // demandAddUpSecCd_Label
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance17.TextHAlignAsString = "Left";
            appearance17.TextVAlignAsString = "Middle";
            this.demandAddUpSecCd_Label.Appearance = appearance17;
            this.demandAddUpSecCd_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.demandAddUpSecCd_Label.Location = new System.Drawing.Point(407, 111);
            this.demandAddUpSecCd_Label.Name = "demandAddUpSecCd_Label";
            this.demandAddUpSecCd_Label.Size = new System.Drawing.Size(25, 24);
            this.demandAddUpSecCd_Label.TabIndex = 5;
            // 
            // demandAddUpSecName_Label
            // 
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance88.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance88.TextHAlignAsString = "Left";
            appearance88.TextVAlignAsString = "Middle";
            this.demandAddUpSecName_Label.Appearance = appearance88;
            this.demandAddUpSecName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.demandAddUpSecName_Label.Location = new System.Drawing.Point(435, 111);
            this.demandAddUpSecName_Label.Name = "demandAddUpSecName_Label";
            this.demandAddUpSecName_Label.Size = new System.Drawing.Size(296, 24);
            this.demandAddUpSecName_Label.TabIndex = 6;
            this.demandAddUpSecName_Label.Tag = "";
            // 
            // SecInf_Tittle_Label
            // 
            appearance138.TextHAlignAsString = "Center";
            appearance138.TextVAlignAsString = "Middle";
            this.SecInf_Tittle_Label.Appearance = appearance138;
            this.SecInf_Tittle_Label.Location = new System.Drawing.Point(325, 112);
            this.SecInf_Tittle_Label.Name = "SecInf_Tittle_Label";
            this.SecInf_Tittle_Label.Size = new System.Drawing.Size(80, 24);
            this.SecInf_Tittle_Label.TabIndex = 12;
            this.SecInf_Tittle_Label.Text = "���͋��_";
            // 
            // AddUpADate_Tittle_Label
            // 
            appearance63.TextHAlignAsString = "Left";
            appearance63.TextVAlignAsString = "Middle";
            this.AddUpADate_Tittle_Label.Appearance = appearance63;
            this.AddUpADate_Tittle_Label.Location = new System.Drawing.Point(12, 112);
            this.AddUpADate_Tittle_Label.Name = "AddUpADate_Tittle_Label";
            this.AddUpADate_Tittle_Label.Size = new System.Drawing.Size(91, 24);
            this.AddUpADate_Tittle_Label.TabIndex = 9;
            this.AddUpADate_Tittle_Label.Text = "����";
            // 
            // AddUpADate_tDateEdit
            // 
            appearance170.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance170.ForeColor = System.Drawing.Color.Black;
            appearance170.ForeColorDisabled = System.Drawing.Color.Black;
            this.AddUpADate_tDateEdit.ActiveEditAppearance = appearance170;
            this.AddUpADate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.AddUpADate_tDateEdit.CalendarDisp = true;
            appearance171.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance171.ForeColor = System.Drawing.Color.Black;
            appearance171.ForeColorDisabled = System.Drawing.Color.Black;
            appearance171.TextHAlignAsString = "Left";
            appearance171.TextVAlignAsString = "Middle";
            this.AddUpADate_tDateEdit.EditAppearance = appearance171;
            this.AddUpADate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.AddUpADate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AddUpADate_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AddUpADate_tDateEdit.ForeColor = System.Drawing.Color.Black;
            appearance175.ForeColor = System.Drawing.Color.Black;
            appearance175.ForeColorDisabled = System.Drawing.Color.Black;
            appearance175.TextHAlignAsString = "Left";
            appearance175.TextVAlignAsString = "Middle";
            this.AddUpADate_tDateEdit.LabelAppearance = appearance175;
            this.AddUpADate_tDateEdit.Location = new System.Drawing.Point(105, 112);
            this.AddUpADate_tDateEdit.Name = "AddUpADate_tDateEdit";
            this.AddUpADate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.AddUpADate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.AddUpADate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.AddUpADate_tDateEdit.TabIndex = 0;
            this.AddUpADate_tDateEdit.TabStop = true;
            this.AddUpADate_tDateEdit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.AddUpADate_tDateEdit.Enter += new System.EventHandler(this.Control_Enter);
            this.AddUpADate_tDateEdit.Leave += new System.EventHandler(this.AddUpADate_tDateEdit_Leave);
            // 
            // tLine2
            // 
            this.tLine2.BackColor = System.Drawing.Color.Transparent;
            this.tLine2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine2.Location = new System.Drawing.Point(4, 139);
            this.tLine2.Name = "tLine2";
            this.tLine2.Size = new System.Drawing.Size(969, 4);
            this.tLine2.TabIndex = 33;
            this.tLine2.Text = "tLine2";
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Undo_Button
            // 
            this.Undo_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Undo_Button.Location = new System.Drawing.Point(470, 389);
            this.Undo_Button.Name = "Undo_Button";
            this.Undo_Button.Size = new System.Drawing.Size(125, 34);
            this.Undo_Button.TabIndex = 71;
            this.Undo_Button.Text = "���(&U)";
            this.Undo_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Undo_Button.Visible = false;
            this.Undo_Button.Click += new System.EventHandler(this.Undo_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(720, 389);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 73;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(845, 389);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 74;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(595, 389);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 72;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // DmdSalesInfo_Panel
            // 
            this.DmdSalesInfo_Panel.Controls.Add(this.OffsetOutTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.BillPrintDate_tDateEdit);
            this.DmdSalesInfo_Panel.Controls.Add(this.SalesInfo_Pnl);
            this.DmdSalesInfo_Panel.Controls.Add(this.DepositInfo_Pnl);
            this.DmdSalesInfo_Panel.Controls.Add(this.AjustInfo_Pnl);
            this.DmdSalesInfo_Panel.Controls.Add(this.LtBlInfo_Pnl);
            this.DmdSalesInfo_Panel.Controls.Add(this.CustDmdPrc_panel);
            this.DmdSalesInfo_Panel.Controls.Add(this.Delete_Button);
            this.DmdSalesInfo_Panel.Controls.Add(this.Cancel_Button);
            this.DmdSalesInfo_Panel.Controls.Add(this.ultraLabel48);
            this.DmdSalesInfo_Panel.Controls.Add(this.ultraLabel47);
            this.DmdSalesInfo_Panel.Controls.Add(this.Ok_Button);
            this.DmdSalesInfo_Panel.Controls.Add(this.Undo_Button);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlItdedDisInTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.ItdedSalesInTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.SalesInTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlRetInnerTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlDisInnerTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlRetOuterTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlItdedRetInTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.SalesOutTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlDisOuterTax_tNedit);
            this.DmdSalesInfo_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DmdSalesInfo_Panel.Location = new System.Drawing.Point(0, 203);
            this.DmdSalesInfo_Panel.Name = "DmdSalesInfo_Panel";
            this.DmdSalesInfo_Panel.Size = new System.Drawing.Size(978, 433);
            this.DmdSalesInfo_Panel.TabIndex = 2;
            // 
            // OffsetOutTax_tNedit
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextHAlignAsString = "Right";
            this.OffsetOutTax_tNedit.ActiveAppearance = appearance59;
            appearance60.BackColor = System.Drawing.Color.White;
            appearance60.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.ForeColorDisabled = System.Drawing.Color.Black;
            appearance60.TextHAlignAsString = "Right";
            this.OffsetOutTax_tNedit.Appearance = appearance60;
            this.OffsetOutTax_tNedit.AutoSelect = true;
            this.OffsetOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.OffsetOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.OffsetOutTax_tNedit.DataText = "";
            this.OffsetOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OffsetOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.OffsetOutTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OffsetOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.OffsetOutTax_tNedit.Location = new System.Drawing.Point(614, 295);
            this.OffsetOutTax_tNedit.MaxLength = 13;
            this.OffsetOutTax_tNedit.Name = "OffsetOutTax_tNedit";
            this.OffsetOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.OffsetOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OffsetOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.OffsetOutTax_tNedit.TabIndex = 595;
            this.OffsetOutTax_tNedit.Visible = false;
            // 
            // BillPrintDate_tDateEdit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillPrintDate_tDateEdit.ActiveEditAppearance = appearance44;
            this.BillPrintDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.BillPrintDate_tDateEdit.CalendarDisp = true;
            appearance45.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance45.ForeColor = System.Drawing.Color.Black;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextHAlignAsString = "Left";
            appearance45.TextVAlignAsString = "Middle";
            this.BillPrintDate_tDateEdit.EditAppearance = appearance45;
            this.BillPrintDate_tDateEdit.Enabled = false;
            this.BillPrintDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.BillPrintDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BillPrintDate_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillPrintDate_tDateEdit.ForeColor = System.Drawing.Color.Black;
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            appearance46.TextHAlignAsString = "Left";
            appearance46.TextVAlignAsString = "Middle";
            this.BillPrintDate_tDateEdit.LabelAppearance = appearance46;
            this.BillPrintDate_tDateEdit.Location = new System.Drawing.Point(99, 402);
            this.BillPrintDate_tDateEdit.Name = "BillPrintDate_tDateEdit";
            this.BillPrintDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.BillPrintDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.BillPrintDate_tDateEdit.Size = new System.Drawing.Size(156, 22);
            this.BillPrintDate_tDateEdit.TabIndex = 1;
            this.BillPrintDate_tDateEdit.TabStop = true;
            this.BillPrintDate_tDateEdit.Visible = false;
            this.BillPrintDate_tDateEdit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.BillPrintDate_tDateEdit.Enter += new System.EventHandler(this.Control_Enter);
            this.BillPrintDate_tDateEdit.Leave += new System.EventHandler(this.DateEdit_Leave);
            // 
            // SalesInfo_Pnl
            // 
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel22);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel20);
            this.SalesInfo_Pnl.Controls.Add(this.OfsThisTimeSalesTaxInc_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel7);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel23);
            this.SalesInfo_Pnl.Controls.Add(this.DisTotal_Label);
            this.SalesInfo_Pnl.Controls.Add(this.RetTotal_Label);
            this.SalesInfo_Pnl.Controls.Add(this.SalesTotal_Label);
            this.SalesInfo_Pnl.Controls.Add(this.OfsThisSalesTax_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.OfsThisTimeSales_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedOffsetTaxFree_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedOffsetOutTax_Label);
            this.SalesInfo_Pnl.Controls.Add(this.SaleslSlipCount_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.Label101);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel30);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedRetTaxFree_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedRetOutTax_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedDisTaxFree_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedDisOutTax_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.RowSalesTotal_Tittle_Label);
            this.SalesInfo_Pnl.Controls.Add(this.Paym_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedSalesTaxFree_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedTaxFree_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.Sales_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.SalesPaymInfo_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.OutTax_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedSalesOutTax_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.ColSalesTotal_Tittle_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel12);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel14);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel15);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel18);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel19);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel17);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel36);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedOutTax_Tittle_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel3);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel13);
            this.SalesInfo_Pnl.Location = new System.Drawing.Point(4, 1);
            this.SalesInfo_Pnl.Name = "SalesInfo_Pnl";
            this.SalesInfo_Pnl.Size = new System.Drawing.Size(427, 292);
            this.SalesInfo_Pnl.TabIndex = 1;
            // 
            // ultraLabel22
            // 
            appearance159.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel22.Appearance = appearance159;
            this.ultraLabel22.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel22.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel22.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel22.Location = new System.Drawing.Point(0, 219);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(423, 4);
            this.ultraLabel22.TabIndex = 620;
            // 
            // ultraLabel20
            // 
            appearance36.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel20.Appearance = appearance36;
            this.ultraLabel20.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel20.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel20.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel20.Location = new System.Drawing.Point(0, 154);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(423, 4);
            this.ultraLabel20.TabIndex = 605;
            // 
            // OfsThisTimeSalesTaxInc_Label
            // 
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance124.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance124.TextHAlignAsString = "Right";
            appearance124.TextVAlignAsString = "Middle";
            this.OfsThisTimeSalesTaxInc_Label.Appearance = appearance124;
            this.OfsThisTimeSalesTaxInc_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.OfsThisTimeSalesTaxInc_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OfsThisTimeSalesTaxInc_Label.Location = new System.Drawing.Point(317, 227);
            this.OfsThisTimeSalesTaxInc_Label.Name = "OfsThisTimeSalesTaxInc_Label";
            this.OfsThisTimeSalesTaxInc_Label.Size = new System.Drawing.Size(101, 22);
            this.OfsThisTimeSalesTaxInc_Label.TabIndex = 623;
            // 
            // ultraLabel7
            // 
            appearance130.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel7.Appearance = appearance130;
            this.ultraLabel7.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel7.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel7.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel7.Location = new System.Drawing.Point(308, 33);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(4, 221);
            this.ultraLabel7.TabIndex = 610;
            // 
            // ultraLabel23
            // 
            appearance162.TextHAlignAsString = "Left";
            appearance162.TextVAlignAsString = "Middle";
            this.ultraLabel23.Appearance = appearance162;
            this.ultraLabel23.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel23.Location = new System.Drawing.Point(5, 227);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel23.TabIndex = 621;
            this.ultraLabel23.Text = "�ō����z";
            // 
            // DisTotal_Label
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance52.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance52.TextHAlignAsString = "Right";
            appearance52.TextVAlignAsString = "Middle";
            this.DisTotal_Label.Appearance = appearance52;
            this.DisTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DisTotal_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DisTotal_Label.Location = new System.Drawing.Point(317, 128);
            this.DisTotal_Label.Name = "DisTotal_Label";
            this.DisTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.DisTotal_Label.TabIndex = 618;
            // 
            // RetTotal_Label
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance32.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.RetTotal_Label.Appearance = appearance32;
            this.RetTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.RetTotal_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RetTotal_Label.Location = new System.Drawing.Point(317, 97);
            this.RetTotal_Label.Name = "RetTotal_Label";
            this.RetTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.RetTotal_Label.TabIndex = 617;
            // 
            // SalesTotal_Label
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance33.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance33.TextHAlignAsString = "Right";
            appearance33.TextVAlignAsString = "Middle";
            this.SalesTotal_Label.Appearance = appearance33;
            this.SalesTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SalesTotal_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesTotal_Label.Location = new System.Drawing.Point(317, 66);
            this.SalesTotal_Label.Name = "SalesTotal_Label";
            this.SalesTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.SalesTotal_Label.TabIndex = 616;
            // 
            // OfsThisSalesTax_tNedit
            // 
            appearance122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance122.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance122.ForeColorDisabled = System.Drawing.Color.Black;
            appearance122.TextHAlignAsString = "Right";
            this.OfsThisSalesTax_tNedit.ActiveAppearance = appearance122;
            appearance123.BackColor = System.Drawing.Color.White;
            appearance123.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance123.ForeColor = System.Drawing.Color.Black;
            appearance123.ForeColorDisabled = System.Drawing.Color.Black;
            appearance123.TextHAlignAsString = "Right";
            this.OfsThisSalesTax_tNedit.Appearance = appearance123;
            this.OfsThisSalesTax_tNedit.AutoSelect = true;
            this.OfsThisSalesTax_tNedit.BackColor = System.Drawing.Color.White;
            this.OfsThisSalesTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.OfsThisSalesTax_tNedit.DataText = "";
            this.OfsThisSalesTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OfsThisSalesTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.OfsThisSalesTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OfsThisSalesTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.OfsThisSalesTax_tNedit.Location = new System.Drawing.Point(317, 193);
            this.OfsThisSalesTax_tNedit.MaxLength = 13;
            this.OfsThisSalesTax_tNedit.Name = "OfsThisSalesTax_tNedit";
            this.OfsThisSalesTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.OfsThisSalesTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OfsThisSalesTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.OfsThisSalesTax_tNedit.TabIndex = 7;
            this.OfsThisSalesTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.OfsThisSalesTax_tNedit.Leave += new System.EventHandler(this.Offset_tNedit_Leave);
            this.OfsThisSalesTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.OfsThisSalesTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // OfsThisTimeSales_Label
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance39.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance39.TextHAlignAsString = "Right";
            appearance39.TextVAlignAsString = "Middle";
            this.OfsThisTimeSales_Label.Appearance = appearance39;
            this.OfsThisTimeSales_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.OfsThisTimeSales_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OfsThisTimeSales_Label.Location = new System.Drawing.Point(317, 162);
            this.OfsThisTimeSales_Label.Name = "OfsThisTimeSales_Label";
            this.OfsThisTimeSales_Label.Size = new System.Drawing.Size(101, 22);
            this.OfsThisTimeSales_Label.TabIndex = 615;
            // 
            // ItdedOffsetTaxFree_Label
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance34.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance34.TextHAlignAsString = "Right";
            appearance34.TextVAlignAsString = "Middle";
            this.ItdedOffsetTaxFree_Label.Appearance = appearance34;
            this.ItdedOffsetTaxFree_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ItdedOffsetTaxFree_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedOffsetTaxFree_Label.Location = new System.Drawing.Point(202, 162);
            this.ItdedOffsetTaxFree_Label.Name = "ItdedOffsetTaxFree_Label";
            this.ItdedOffsetTaxFree_Label.Size = new System.Drawing.Size(101, 22);
            this.ItdedOffsetTaxFree_Label.TabIndex = 614;
            // 
            // ItdedOffsetOutTax_Label
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance91.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance91.TextHAlignAsString = "Right";
            appearance91.TextVAlignAsString = "Middle";
            this.ItdedOffsetOutTax_Label.Appearance = appearance91;
            this.ItdedOffsetOutTax_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ItdedOffsetOutTax_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedOffsetOutTax_Label.Location = new System.Drawing.Point(95, 162);
            this.ItdedOffsetOutTax_Label.Name = "ItdedOffsetOutTax_Label";
            this.ItdedOffsetOutTax_Label.Size = new System.Drawing.Size(101, 22);
            this.ItdedOffsetOutTax_Label.TabIndex = 609;
            // 
            // SaleslSlipCount_tNedit
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance74.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance74.ForeColorDisabled = System.Drawing.Color.Black;
            appearance74.TextHAlignAsString = "Right";
            this.SaleslSlipCount_tNedit.ActiveAppearance = appearance74;
            appearance75.BackColor = System.Drawing.Color.White;
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColor = System.Drawing.Color.Black;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            appearance75.TextHAlignAsString = "Right";
            this.SaleslSlipCount_tNedit.Appearance = appearance75;
            this.SaleslSlipCount_tNedit.AutoSelect = true;
            this.SaleslSlipCount_tNedit.BackColor = System.Drawing.Color.White;
            this.SaleslSlipCount_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SaleslSlipCount_tNedit.DataText = "";
            this.SaleslSlipCount_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SaleslSlipCount_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SaleslSlipCount_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SaleslSlipCount_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SaleslSlipCount_tNedit.Location = new System.Drawing.Point(95, 263);
            this.SaleslSlipCount_tNedit.MaxLength = 13;
            this.SaleslSlipCount_tNedit.Name = "SaleslSlipCount_tNedit";
            this.SaleslSlipCount_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SaleslSlipCount_tNedit.Size = new System.Drawing.Size(101, 22);
            this.SaleslSlipCount_tNedit.TabIndex = 11;
            // 
            // Label101
            // 
            appearance76.TextHAlignAsString = "Left";
            appearance76.TextVAlignAsString = "Middle";
            this.Label101.Appearance = appearance76;
            this.Label101.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label101.Location = new System.Drawing.Point(5, 263);
            this.Label101.Name = "Label101";
            this.Label101.Size = new System.Drawing.Size(85, 22);
            this.Label101.TabIndex = 607;
            this.Label101.Text = "����`�[����";
            // 
            // ultraLabel30
            // 
            appearance188.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel30.Appearance = appearance188;
            this.ultraLabel30.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel30.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel30.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel30.Location = new System.Drawing.Point(0, 258);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(204, 32);
            this.ultraLabel30.TabIndex = 606;
            // 
            // TtlItdedRetTaxFree_tNedit
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance103.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance103.ForeColorDisabled = System.Drawing.Color.Black;
            appearance103.TextHAlignAsString = "Right";
            this.TtlItdedRetTaxFree_tNedit.ActiveAppearance = appearance103;
            appearance104.BackColor = System.Drawing.Color.White;
            appearance104.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance104.ForeColor = System.Drawing.Color.Black;
            appearance104.ForeColorDisabled = System.Drawing.Color.Black;
            appearance104.TextHAlignAsString = "Right";
            this.TtlItdedRetTaxFree_tNedit.Appearance = appearance104;
            this.TtlItdedRetTaxFree_tNedit.AutoSelect = true;
            this.TtlItdedRetTaxFree_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedRetTaxFree_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedRetTaxFree_tNedit.DataText = "";
            this.TtlItdedRetTaxFree_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedRetTaxFree_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedRetTaxFree_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedRetTaxFree_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedRetTaxFree_tNedit.Location = new System.Drawing.Point(202, 97);
            this.TtlItdedRetTaxFree_tNedit.MaxLength = 13;
            this.TtlItdedRetTaxFree_tNedit.Name = "TtlItdedRetTaxFree_tNedit";
            this.TtlItdedRetTaxFree_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedRetTaxFree_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedRetTaxFree_tNedit.TabIndex = 5;
            this.TtlItdedRetTaxFree_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedRetTaxFree_tNedit.Leave += new System.EventHandler(this.Ret_tNedit_Leave);
            this.TtlItdedRetTaxFree_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedRetTaxFree_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedRetOutTax_tNedit
            // 
            appearance116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance116.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance116.ForeColorDisabled = System.Drawing.Color.Black;
            appearance116.TextHAlignAsString = "Right";
            this.TtlItdedRetOutTax_tNedit.ActiveAppearance = appearance116;
            appearance117.BackColor = System.Drawing.Color.White;
            appearance117.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance117.ForeColor = System.Drawing.Color.Black;
            appearance117.ForeColorDisabled = System.Drawing.Color.Black;
            appearance117.TextHAlignAsString = "Right";
            this.TtlItdedRetOutTax_tNedit.Appearance = appearance117;
            this.TtlItdedRetOutTax_tNedit.AutoSelect = true;
            this.TtlItdedRetOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedRetOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedRetOutTax_tNedit.DataText = "";
            this.TtlItdedRetOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedRetOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedRetOutTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedRetOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedRetOutTax_tNedit.Location = new System.Drawing.Point(95, 97);
            this.TtlItdedRetOutTax_tNedit.MaxLength = 13;
            this.TtlItdedRetOutTax_tNedit.Name = "TtlItdedRetOutTax_tNedit";
            this.TtlItdedRetOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedRetOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlItdedRetOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedRetOutTax_tNedit.TabIndex = 2;
            this.TtlItdedRetOutTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedRetOutTax_tNedit.Leave += new System.EventHandler(this.Ret_tNedit_Leave);
            this.TtlItdedRetOutTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedRetOutTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedDisTaxFree_tNedit
            // 
            appearance118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance118.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance118.ForeColorDisabled = System.Drawing.Color.Black;
            appearance118.TextHAlignAsString = "Right";
            this.TtlItdedDisTaxFree_tNedit.ActiveAppearance = appearance118;
            appearance119.BackColor = System.Drawing.Color.White;
            appearance119.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance119.ForeColor = System.Drawing.Color.Black;
            appearance119.ForeColorDisabled = System.Drawing.Color.Black;
            appearance119.TextHAlignAsString = "Right";
            this.TtlItdedDisTaxFree_tNedit.Appearance = appearance119;
            this.TtlItdedDisTaxFree_tNedit.AutoSelect = true;
            this.TtlItdedDisTaxFree_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedDisTaxFree_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedDisTaxFree_tNedit.DataText = "";
            this.TtlItdedDisTaxFree_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedDisTaxFree_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedDisTaxFree_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedDisTaxFree_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedDisTaxFree_tNedit.Location = new System.Drawing.Point(202, 128);
            this.TtlItdedDisTaxFree_tNedit.MaxLength = 13;
            this.TtlItdedDisTaxFree_tNedit.Name = "TtlItdedDisTaxFree_tNedit";
            this.TtlItdedDisTaxFree_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedDisTaxFree_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedDisTaxFree_tNedit.TabIndex = 6;
            this.TtlItdedDisTaxFree_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedDisTaxFree_tNedit.Leave += new System.EventHandler(this.Dis_tNedit_Leave);
            this.TtlItdedDisTaxFree_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedDisTaxFree_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedDisOutTax_tNedit
            // 
            appearance127.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance127.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance127.ForeColorDisabled = System.Drawing.Color.Black;
            appearance127.TextHAlignAsString = "Right";
            this.TtlItdedDisOutTax_tNedit.ActiveAppearance = appearance127;
            appearance128.BackColor = System.Drawing.Color.White;
            appearance128.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance128.ForeColor = System.Drawing.Color.Black;
            appearance128.ForeColorDisabled = System.Drawing.Color.Black;
            appearance128.TextHAlignAsString = "Right";
            this.TtlItdedDisOutTax_tNedit.Appearance = appearance128;
            this.TtlItdedDisOutTax_tNedit.AutoSelect = true;
            this.TtlItdedDisOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedDisOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedDisOutTax_tNedit.DataText = "";
            this.TtlItdedDisOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedDisOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedDisOutTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedDisOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedDisOutTax_tNedit.Location = new System.Drawing.Point(95, 128);
            this.TtlItdedDisOutTax_tNedit.MaxLength = 13;
            this.TtlItdedDisOutTax_tNedit.Name = "TtlItdedDisOutTax_tNedit";
            this.TtlItdedDisOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedDisOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlItdedDisOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedDisOutTax_tNedit.TabIndex = 3;
            this.TtlItdedDisOutTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedDisOutTax_tNedit.Leave += new System.EventHandler(this.Dis_tNedit_Leave);
            this.TtlItdedDisOutTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedDisOutTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // RowSalesTotal_Tittle_Label
            // 
            appearance131.TextHAlignAsString = "Left";
            appearance131.TextVAlignAsString = "Middle";
            this.RowSalesTotal_Tittle_Label.Appearance = appearance131;
            this.RowSalesTotal_Tittle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RowSalesTotal_Tittle_Label.Location = new System.Drawing.Point(5, 128);
            this.RowSalesTotal_Tittle_Label.Name = "RowSalesTotal_Tittle_Label";
            this.RowSalesTotal_Tittle_Label.Size = new System.Drawing.Size(85, 22);
            this.RowSalesTotal_Tittle_Label.TabIndex = 571;
            this.RowSalesTotal_Tittle_Label.Text = "�l��";
            // 
            // Paym_Title_Label
            // 
            appearance132.TextHAlignAsString = "Left";
            appearance132.TextVAlignAsString = "Middle";
            this.Paym_Title_Label.Appearance = appearance132;
            this.Paym_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Paym_Title_Label.Location = new System.Drawing.Point(5, 97);
            this.Paym_Title_Label.Name = "Paym_Title_Label";
            this.Paym_Title_Label.Size = new System.Drawing.Size(85, 22);
            this.Paym_Title_Label.TabIndex = 570;
            this.Paym_Title_Label.Text = "�ԕi";
            // 
            // ItdedSalesTaxFree_tNedit
            // 
            appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance133.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance133.ForeColorDisabled = System.Drawing.Color.Black;
            appearance133.TextHAlignAsString = "Right";
            this.ItdedSalesTaxFree_tNedit.ActiveAppearance = appearance133;
            appearance134.BackColor = System.Drawing.Color.White;
            appearance134.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance134.ForeColor = System.Drawing.Color.Black;
            appearance134.ForeColorDisabled = System.Drawing.Color.Black;
            appearance134.TextHAlignAsString = "Right";
            this.ItdedSalesTaxFree_tNedit.Appearance = appearance134;
            this.ItdedSalesTaxFree_tNedit.AutoSelect = true;
            this.ItdedSalesTaxFree_tNedit.BackColor = System.Drawing.Color.White;
            this.ItdedSalesTaxFree_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.ItdedSalesTaxFree_tNedit.DataText = "";
            this.ItdedSalesTaxFree_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ItdedSalesTaxFree_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.ItdedSalesTaxFree_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedSalesTaxFree_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ItdedSalesTaxFree_tNedit.Location = new System.Drawing.Point(202, 66);
            this.ItdedSalesTaxFree_tNedit.MaxLength = 13;
            this.ItdedSalesTaxFree_tNedit.Name = "ItdedSalesTaxFree_tNedit";
            this.ItdedSalesTaxFree_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.ItdedSalesTaxFree_tNedit.Size = new System.Drawing.Size(101, 22);
            this.ItdedSalesTaxFree_tNedit.TabIndex = 4;
            this.ItdedSalesTaxFree_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.ItdedSalesTaxFree_tNedit.Leave += new System.EventHandler(this.Sales_tNedit_Leave);
            this.ItdedSalesTaxFree_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.ItdedSalesTaxFree_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // ItdedTaxFree_Title_Label
            // 
            appearance135.TextHAlignAsString = "Center";
            appearance135.TextVAlignAsString = "Middle";
            this.ItdedTaxFree_Title_Label.Appearance = appearance135;
            this.ItdedTaxFree_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedTaxFree_Title_Label.Location = new System.Drawing.Point(202, 35);
            this.ItdedTaxFree_Title_Label.Name = "ItdedTaxFree_Title_Label";
            this.ItdedTaxFree_Title_Label.Size = new System.Drawing.Size(101, 25);
            this.ItdedTaxFree_Title_Label.TabIndex = 577;
            this.ItdedTaxFree_Title_Label.Text = "��ېőΏۊz";
            // 
            // Sales_Title_Label
            // 
            appearance139.TextHAlignAsString = "Left";
            appearance139.TextVAlignAsString = "Middle";
            this.Sales_Title_Label.Appearance = appearance139;
            this.Sales_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Sales_Title_Label.Location = new System.Drawing.Point(5, 66);
            this.Sales_Title_Label.Name = "Sales_Title_Label";
            this.Sales_Title_Label.Size = new System.Drawing.Size(85, 22);
            this.Sales_Title_Label.TabIndex = 569;
            this.Sales_Title_Label.Text = "����";
            // 
            // SalesPaymInfo_Title_Label
            // 
            appearance161.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance161.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance161.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance161.BorderColor = System.Drawing.Color.Black;
            appearance161.TextHAlignAsString = "Center";
            appearance161.TextVAlignAsString = "Middle";
            this.SalesPaymInfo_Title_Label.Appearance = appearance161;
            this.SalesPaymInfo_Title_Label.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.SalesPaymInfo_Title_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SalesPaymInfo_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesPaymInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.SalesPaymInfo_Title_Label.Name = "SalesPaymInfo_Title_Label";
            this.SalesPaymInfo_Title_Label.Size = new System.Drawing.Size(413, 24);
            this.SalesPaymInfo_Title_Label.TabIndex = 568;
            this.SalesPaymInfo_Title_Label.Text = "������";
            // 
            // OutTax_Title_Label
            // 
            appearance37.TextHAlignAsString = "Left";
            appearance37.TextVAlignAsString = "Middle";
            this.OutTax_Title_Label.Appearance = appearance37;
            this.OutTax_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OutTax_Title_Label.Location = new System.Drawing.Point(5, 193);
            this.OutTax_Title_Label.Name = "OutTax_Title_Label";
            this.OutTax_Title_Label.Size = new System.Drawing.Size(85, 22);
            this.OutTax_Title_Label.TabIndex = 573;
            this.OutTax_Title_Label.Text = "����Ŋz";
            // 
            // ItdedSalesOutTax_tNedit
            // 
            appearance166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance166.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance166.ForeColorDisabled = System.Drawing.Color.Black;
            appearance166.TextHAlignAsString = "Right";
            this.ItdedSalesOutTax_tNedit.ActiveAppearance = appearance166;
            appearance167.BackColor = System.Drawing.Color.White;
            appearance167.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance167.ForeColor = System.Drawing.Color.Black;
            appearance167.ForeColorDisabled = System.Drawing.Color.Black;
            appearance167.TextHAlignAsString = "Right";
            this.ItdedSalesOutTax_tNedit.Appearance = appearance167;
            this.ItdedSalesOutTax_tNedit.AutoSelect = true;
            this.ItdedSalesOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.ItdedSalesOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.ItdedSalesOutTax_tNedit.DataText = "";
            this.ItdedSalesOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ItdedSalesOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.ItdedSalesOutTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedSalesOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ItdedSalesOutTax_tNedit.Location = new System.Drawing.Point(95, 66);
            this.ItdedSalesOutTax_tNedit.MaxLength = 13;
            this.ItdedSalesOutTax_tNedit.Name = "ItdedSalesOutTax_tNedit";
            this.ItdedSalesOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.ItdedSalesOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ItdedSalesOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.ItdedSalesOutTax_tNedit.TabIndex = 1;
            this.ItdedSalesOutTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.ItdedSalesOutTax_tNedit.Leave += new System.EventHandler(this.Sales_tNedit_Leave);
            this.ItdedSalesOutTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.ItdedSalesOutTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // ColSalesTotal_Tittle_Label
            // 
            appearance56.TextHAlignAsString = "Left";
            appearance56.TextVAlignAsString = "Middle";
            this.ColSalesTotal_Tittle_Label.Appearance = appearance56;
            this.ColSalesTotal_Tittle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColSalesTotal_Tittle_Label.Location = new System.Drawing.Point(5, 162);
            this.ColSalesTotal_Tittle_Label.Name = "ColSalesTotal_Tittle_Label";
            this.ColSalesTotal_Tittle_Label.Size = new System.Drawing.Size(85, 22);
            this.ColSalesTotal_Tittle_Label.TabIndex = 578;
            this.ColSalesTotal_Tittle_Label.Text = "���v";
            // 
            // ultraLabel12
            // 
            appearance181.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel12.Appearance = appearance181;
            this.ultraLabel12.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel12.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel12.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(423, 34);
            this.ultraLabel12.TabIndex = 598;
            // 
            // ultraLabel14
            // 
            appearance183.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel14.Appearance = appearance183;
            this.ultraLabel14.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel14.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel14.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel14.Location = new System.Drawing.Point(0, 61);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel14.TabIndex = 600;
            // 
            // ultraLabel15
            // 
            appearance184.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel15.Appearance = appearance184;
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel15.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel15.Location = new System.Drawing.Point(0, 92);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel15.TabIndex = 601;
            // 
            // ultraLabel18
            // 
            appearance187.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel18.Appearance = appearance187;
            this.ultraLabel18.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel18.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel18.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel18.Location = new System.Drawing.Point(0, 123);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel18.TabIndex = 603;
            // 
            // ultraLabel19
            // 
            appearance35.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel19.Appearance = appearance35;
            this.ultraLabel19.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel19.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel19.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel19.Location = new System.Drawing.Point(0, 157);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel19.TabIndex = 604;
            // 
            // ultraLabel17
            // 
            appearance38.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel17.Appearance = appearance38;
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel17.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel17.Location = new System.Drawing.Point(0, 188);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel17.TabIndex = 619;
            // 
            // ultraLabel36
            // 
            appearance57.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel36.Appearance = appearance57;
            this.ultraLabel36.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel36.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel36.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel36.Location = new System.Drawing.Point(0, 222);
            this.ultraLabel36.Name = "ultraLabel36";
            this.ultraLabel36.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel36.TabIndex = 622;
            // 
            // ItdedOutTax_Tittle_Label
            // 
            appearance169.TextHAlignAsString = "Center";
            appearance169.TextVAlignAsString = "Middle";
            this.ItdedOutTax_Tittle_Label.Appearance = appearance169;
            this.ItdedOutTax_Tittle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedOutTax_Tittle_Label.Location = new System.Drawing.Point(95, 32);
            this.ItdedOutTax_Tittle_Label.Name = "ItdedOutTax_Tittle_Label";
            this.ItdedOutTax_Tittle_Label.Size = new System.Drawing.Size(101, 30);
            this.ItdedOutTax_Tittle_Label.TabIndex = 572;
            this.ItdedOutTax_Tittle_Label.Text = "�ېőΏۊz";
            // 
            // ultraLabel3
            // 
            appearance168.TextHAlignAsString = "Center";
            appearance168.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance168;
            this.ultraLabel3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(317, 33);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(101, 29);
            this.ultraLabel3.TabIndex = 608;
            this.ultraLabel3.Text = "���v";
            // 
            // ultraLabel13
            // 
            appearance182.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel13.Appearance = appearance182;
            this.ultraLabel13.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel13.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel13.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel13.Location = new System.Drawing.Point(0, 32);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(423, 30);
            this.ultraLabel13.TabIndex = 599;
            // 
            // DepositInfo_Pnl
            // 
            this.DepositInfo_Pnl.Controls.Add(this.DepositInfo_Title_Label);
            this.DepositInfo_Pnl.Controls.Add(this.grdDepositKind);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel41);
            this.DepositInfo_Pnl.Controls.Add(this.NrmlTotal_Label);
            this.DepositInfo_Pnl.Controls.Add(this.ColDepoTotal_Title_Label);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel9);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel21);
            this.DepositInfo_Pnl.Controls.Add(this.DisNrml_tNedit);
            this.DepositInfo_Pnl.Controls.Add(this.Discount_Title_Label);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel8);
            this.DepositInfo_Pnl.Controls.Add(this.FeeNrml_tNedit);
            this.DepositInfo_Pnl.Controls.Add(this.Fee_Title_Label);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel4);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel31);
            this.DepositInfo_Pnl.Location = new System.Drawing.Point(432, 1);
            this.DepositInfo_Pnl.Name = "DepositInfo_Pnl";
            this.DepositInfo_Pnl.Size = new System.Drawing.Size(243, 279);
            this.DepositInfo_Pnl.TabIndex = 2;
            // 
            // DepositInfo_Title_Label
            // 
            appearance129.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance129.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance129.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance129.BorderColor = System.Drawing.Color.Black;
            appearance129.TextHAlignAsString = "Center";
            appearance129.TextVAlignAsString = "Middle";
            this.DepositInfo_Title_Label.Appearance = appearance129;
            this.DepositInfo_Title_Label.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DepositInfo_Title_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DepositInfo_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DepositInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.DepositInfo_Title_Label.Name = "DepositInfo_Title_Label";
            this.DepositInfo_Title_Label.Size = new System.Drawing.Size(229, 24);
            this.DepositInfo_Title_Label.TabIndex = 599;
            this.DepositInfo_Title_Label.Text = "�������";
            // 
            // grdDepositKind
            // 
            this.grdDepositKind.Cursor = System.Windows.Forms.Cursors.Default;
            appearance143.BackColor = System.Drawing.Color.White;
            appearance143.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance143.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance143.BorderColor = System.Drawing.Color.Blue;
            this.grdDepositKind.DisplayLayout.Appearance = appearance143;
            appearance144.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance144.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance144.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance144.BorderColor = System.Drawing.SystemColors.Window;
            this.grdDepositKind.DisplayLayout.GroupByBox.Appearance = appearance144;
            appearance145.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdDepositKind.DisplayLayout.GroupByBox.BandLabelAppearance = appearance145;
            this.grdDepositKind.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdDepositKind.DisplayLayout.GroupByBox.Hidden = true;
            appearance146.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance146.BackColor2 = System.Drawing.SystemColors.Control;
            appearance146.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance146.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdDepositKind.DisplayLayout.GroupByBox.PromptAppearance = appearance146;
            this.grdDepositKind.DisplayLayout.MaxColScrollRegions = 1;
            this.grdDepositKind.DisplayLayout.MaxRowScrollRegions = 1;
            appearance147.BackColor = System.Drawing.SystemColors.Window;
            appearance147.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdDepositKind.DisplayLayout.Override.ActiveCellAppearance = appearance147;
            this.grdDepositKind.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdDepositKind.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdDepositKind.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdDepositKind.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdDepositKind.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            appearance148.BackColor = System.Drawing.SystemColors.Window;
            this.grdDepositKind.DisplayLayout.Override.CardAreaAppearance = appearance148;
            appearance149.BorderColor = System.Drawing.Color.Silver;
            appearance149.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdDepositKind.DisplayLayout.Override.CellAppearance = appearance149;
            this.grdDepositKind.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdDepositKind.DisplayLayout.Override.CellPadding = 0;
            appearance150.BackColor = System.Drawing.SystemColors.Control;
            appearance150.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance150.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance150.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance150.BorderColor = System.Drawing.SystemColors.Window;
            this.grdDepositKind.DisplayLayout.Override.GroupByRowAppearance = appearance150;
            appearance151.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance151.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance151.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance151.ForeColor = System.Drawing.Color.White;
            appearance151.TextHAlignAsString = "Center";
            appearance151.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdDepositKind.DisplayLayout.Override.HeaderAppearance = appearance151;
            appearance152.BackColor = System.Drawing.SystemColors.Window;
            appearance152.BorderColor = System.Drawing.Color.Silver;
            this.grdDepositKind.DisplayLayout.Override.RowAppearance = appearance152;
            this.grdDepositKind.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance153.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance153.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance153.ForeColor = System.Drawing.Color.Black;
            this.grdDepositKind.DisplayLayout.Override.SelectedRowAppearance = appearance153;
            this.grdDepositKind.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdDepositKind.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdDepositKind.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            appearance154.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdDepositKind.DisplayLayout.Override.TemplateAddRowAppearance = appearance154;
            this.grdDepositKind.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black;
            this.grdDepositKind.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.grdDepositKind.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdDepositKind.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdDepositKind.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.grdDepositKind.Location = new System.Drawing.Point(5, 35);
            this.grdDepositKind.Name = "grdDepositKind";
            this.grdDepositKind.Size = new System.Drawing.Size(229, 131);
            this.grdDepositKind.TabIndex = 1;
            this.grdDepositKind.AfterExitEditMode += new System.EventHandler(this.grdDepositKind_AfterExitEditMode);
            this.grdDepositKind.AfterEnterEditMode += new System.EventHandler(this.grdDepositKind_AfterEnterEditMode);
            this.grdDepositKind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdDepositKind_KeyPress);
            this.grdDepositKind.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdDepositKind_CellChange);
            this.grdDepositKind.Leave += new System.EventHandler(this.grdDepositKind_Leave);
            this.grdDepositKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdDepositKind_KeyDown);
            // 
            // ultraLabel41
            // 
            appearance178.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel41.Appearance = appearance178;
            this.ultraLabel41.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel41.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel41.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel41.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel41.Name = "ultraLabel41";
            this.ultraLabel41.Size = new System.Drawing.Size(239, 33);
            this.ultraLabel41.TabIndex = 583;
            // 
            // NrmlTotal_Label
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance24.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance24.TextHAlignAsString = "Right";
            appearance24.TextVAlignAsString = "Middle";
            this.NrmlTotal_Label.Appearance = appearance24;
            this.NrmlTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.NrmlTotal_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NrmlTotal_Label.Location = new System.Drawing.Point(115, 238);
            this.NrmlTotal_Label.Name = "NrmlTotal_Label";
            this.NrmlTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.NrmlTotal_Label.TabIndex = 597;
            // 
            // ColDepoTotal_Title_Label
            // 
            appearance54.TextHAlignAsString = "Left";
            appearance54.TextVAlignAsString = "Middle";
            this.ColDepoTotal_Title_Label.Appearance = appearance54;
            this.ColDepoTotal_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColDepoTotal_Title_Label.Location = new System.Drawing.Point(5, 238);
            this.ColDepoTotal_Title_Label.Name = "ColDepoTotal_Title_Label";
            this.ColDepoTotal_Title_Label.Size = new System.Drawing.Size(80, 22);
            this.ColDepoTotal_Title_Label.TabIndex = 596;
            this.ColDepoTotal_Title_Label.Text = "�������v";
            // 
            // ultraLabel9
            // 
            appearance55.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel9.Appearance = appearance55;
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel9.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel9.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(0, 233);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(239, 32);
            this.ultraLabel9.TabIndex = 598;
            // 
            // ultraLabel21
            // 
            appearance61.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel21.Appearance = appearance61;
            this.ultraLabel21.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel21.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel21.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel21.Location = new System.Drawing.Point(0, 230);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(239, 4);
            this.ultraLabel21.TabIndex = 595;
            // 
            // DisNrml_tNedit
            // 
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance72.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Right";
            this.DisNrml_tNedit.ActiveAppearance = appearance72;
            appearance73.BackColor = System.Drawing.Color.White;
            appearance73.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance73.ForeColor = System.Drawing.Color.Black;
            appearance73.ForeColorDisabled = System.Drawing.Color.Black;
            appearance73.TextHAlignAsString = "Right";
            this.DisNrml_tNedit.Appearance = appearance73;
            this.DisNrml_tNedit.AutoSelect = true;
            this.DisNrml_tNedit.BackColor = System.Drawing.Color.White;
            this.DisNrml_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DisNrml_tNedit.DataText = "";
            this.DisNrml_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DisNrml_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.DisNrml_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DisNrml_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DisNrml_tNedit.Location = new System.Drawing.Point(115, 204);
            this.DisNrml_tNedit.MaxLength = 13;
            this.DisNrml_tNedit.Name = "DisNrml_tNedit";
            this.DisNrml_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DisNrml_tNedit.Size = new System.Drawing.Size(101, 22);
            this.DisNrml_tNedit.TabIndex = 3;
            this.DisNrml_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.DisNrml_tNedit.Leave += new System.EventHandler(this.Normal_tNedit_Leave);
            this.DisNrml_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.DisNrml_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // Discount_Title_Label
            // 
            appearance78.TextHAlignAsString = "Left";
            appearance78.TextVAlignAsString = "Middle";
            this.Discount_Title_Label.Appearance = appearance78;
            this.Discount_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Discount_Title_Label.Location = new System.Drawing.Point(5, 204);
            this.Discount_Title_Label.Name = "Discount_Title_Label";
            this.Discount_Title_Label.Size = new System.Drawing.Size(80, 22);
            this.Discount_Title_Label.TabIndex = 592;
            this.Discount_Title_Label.Text = "�l���z";
            // 
            // ultraLabel8
            // 
            appearance79.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel8.Appearance = appearance79;
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel8.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(0, 199);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(239, 32);
            this.ultraLabel8.TabIndex = 594;
            // 
            // FeeNrml_tNedit
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance85.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance85.ForeColorDisabled = System.Drawing.Color.Black;
            appearance85.TextHAlignAsString = "Right";
            this.FeeNrml_tNedit.ActiveAppearance = appearance85;
            appearance86.BackColor = System.Drawing.Color.White;
            appearance86.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance86.ForeColor = System.Drawing.Color.Black;
            appearance86.ForeColorDisabled = System.Drawing.Color.Black;
            appearance86.TextHAlignAsString = "Right";
            this.FeeNrml_tNedit.Appearance = appearance86;
            this.FeeNrml_tNedit.AutoSelect = true;
            this.FeeNrml_tNedit.BackColor = System.Drawing.Color.White;
            this.FeeNrml_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.FeeNrml_tNedit.DataText = "";
            this.FeeNrml_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.FeeNrml_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.FeeNrml_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FeeNrml_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.FeeNrml_tNedit.Location = new System.Drawing.Point(115, 173);
            this.FeeNrml_tNedit.MaxLength = 13;
            this.FeeNrml_tNedit.Name = "FeeNrml_tNedit";
            this.FeeNrml_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.FeeNrml_tNedit.Size = new System.Drawing.Size(101, 22);
            this.FeeNrml_tNedit.TabIndex = 2;
            this.FeeNrml_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.FeeNrml_tNedit.Leave += new System.EventHandler(this.Normal_tNedit_Leave);
            this.FeeNrml_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.FeeNrml_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // Fee_Title_Label
            // 
            appearance90.TextHAlignAsString = "Left";
            appearance90.TextVAlignAsString = "Middle";
            this.Fee_Title_Label.Appearance = appearance90;
            this.Fee_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Fee_Title_Label.Location = new System.Drawing.Point(5, 173);
            this.Fee_Title_Label.Name = "Fee_Title_Label";
            this.Fee_Title_Label.Size = new System.Drawing.Size(80, 22);
            this.Fee_Title_Label.TabIndex = 589;
            this.Fee_Title_Label.Text = "�萔���z";
            // 
            // ultraLabel4
            // 
            appearance92.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel4.Appearance = appearance92;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(0, 168);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(239, 32);
            this.ultraLabel4.TabIndex = 591;
            // 
            // ultraLabel31
            // 
            appearance27.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel31.Appearance = appearance27;
            this.ultraLabel31.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel31.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel31.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel31.Location = new System.Drawing.Point(0, 32);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(239, 137);
            this.ultraLabel31.TabIndex = 582;
            // 
            // AjustInfo_Pnl
            // 
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel32);
            this.AjustInfo_Pnl.Controls.Add(this.TaxAdjust_tNedit);
            this.AjustInfo_Pnl.Controls.Add(this.BalanceAdjust_tNedit);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel27);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel57);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel10);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel58);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel56);
            this.AjustInfo_Pnl.Location = new System.Drawing.Point(752, 277);
            this.AjustInfo_Pnl.Name = "AjustInfo_Pnl";
            this.AjustInfo_Pnl.Size = new System.Drawing.Size(218, 106);
            this.AjustInfo_Pnl.TabIndex = 573;
            this.AjustInfo_Pnl.Visible = false;
            // 
            // ultraLabel32
            // 
            appearance194.TextHAlignAsString = "Center";
            appearance194.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance194;
            this.ultraLabel32.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel32.Location = new System.Drawing.Point(1, 74);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(91, 24);
            this.ultraLabel32.TabIndex = 590;
            this.ultraLabel32.Text = "����Œ����z";
            // 
            // TaxAdjust_tNedit
            // 
            appearance195.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance195.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance195.ForeColorDisabled = System.Drawing.Color.Black;
            appearance195.TextHAlignAsString = "Right";
            this.TaxAdjust_tNedit.ActiveAppearance = appearance195;
            appearance196.BackColor = System.Drawing.Color.White;
            appearance196.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance196.ForeColor = System.Drawing.Color.Black;
            appearance196.ForeColorDisabled = System.Drawing.Color.Black;
            appearance196.TextHAlignAsString = "Right";
            this.TaxAdjust_tNedit.Appearance = appearance196;
            this.TaxAdjust_tNedit.AutoSelect = true;
            this.TaxAdjust_tNedit.BackColor = System.Drawing.Color.White;
            this.TaxAdjust_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxAdjust_tNedit.DataText = "";
            this.TaxAdjust_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxAdjust_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TaxAdjust_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TaxAdjust_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxAdjust_tNedit.Location = new System.Drawing.Point(95, 74);
            this.TaxAdjust_tNedit.MaxLength = 10;
            this.TaxAdjust_tNedit.Name = "TaxAdjust_tNedit";
            this.TaxAdjust_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxAdjust_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TaxAdjust_tNedit.TabIndex = 588;
            // 
            // BalanceAdjust_tNedit
            // 
            appearance197.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance197.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance197.ForeColorDisabled = System.Drawing.Color.Black;
            appearance197.TextHAlignAsString = "Right";
            this.BalanceAdjust_tNedit.ActiveAppearance = appearance197;
            appearance198.BackColor = System.Drawing.Color.White;
            appearance198.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance198.ForeColor = System.Drawing.Color.Black;
            appearance198.ForeColorDisabled = System.Drawing.Color.Black;
            appearance198.TextHAlignAsString = "Right";
            this.BalanceAdjust_tNedit.Appearance = appearance198;
            this.BalanceAdjust_tNedit.AutoSelect = true;
            this.BalanceAdjust_tNedit.BackColor = System.Drawing.Color.White;
            this.BalanceAdjust_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.BalanceAdjust_tNedit.DataText = "";
            this.BalanceAdjust_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BalanceAdjust_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.BalanceAdjust_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BalanceAdjust_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BalanceAdjust_tNedit.Location = new System.Drawing.Point(95, 40);
            this.BalanceAdjust_tNedit.MaxLength = 13;
            this.BalanceAdjust_tNedit.Name = "BalanceAdjust_tNedit";
            this.BalanceAdjust_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.BalanceAdjust_tNedit.Size = new System.Drawing.Size(101, 22);
            this.BalanceAdjust_tNedit.TabIndex = 587;
            // 
            // ultraLabel27
            // 
            appearance199.TextHAlignAsString = "Center";
            appearance199.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance199;
            this.ultraLabel27.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel27.Location = new System.Drawing.Point(3, 39);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(89, 24);
            this.ultraLabel27.TabIndex = 589;
            this.ultraLabel27.Text = "�c�������z";
            // 
            // ultraLabel57
            // 
            appearance200.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel57.Appearance = appearance200;
            this.ultraLabel57.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel57.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel57.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel57.Location = new System.Drawing.Point(0, 32);
            this.ultraLabel57.Name = "ultraLabel57";
            this.ultraLabel57.Size = new System.Drawing.Size(214, 35);
            this.ultraLabel57.TabIndex = 582;
            // 
            // ultraLabel10
            // 
            appearance201.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance201.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance201.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance201.BorderColor = System.Drawing.Color.Black;
            appearance201.TextHAlignAsString = "Center";
            appearance201.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance201;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraLabel10.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel10.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(3, 4);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(206, 24);
            this.ultraLabel10.TabIndex = 535;
            this.ultraLabel10.Text = "�c���������";
            // 
            // ultraLabel58
            // 
            appearance202.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel58.Appearance = appearance202;
            this.ultraLabel58.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel58.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel58.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel58.Location = new System.Drawing.Point(0, 66);
            this.ultraLabel58.Name = "ultraLabel58";
            this.ultraLabel58.Size = new System.Drawing.Size(214, 35);
            this.ultraLabel58.TabIndex = 584;
            // 
            // ultraLabel56
            // 
            appearance203.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel56.Appearance = appearance203;
            this.ultraLabel56.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel56.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel56.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel56.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel56.Name = "ultraLabel56";
            this.ultraLabel56.Size = new System.Drawing.Size(214, 33);
            this.ultraLabel56.TabIndex = 583;
            // 
            // LtBlInfo_Pnl
            // 
            this.LtBlInfo_Pnl.Controls.Add(this.BlTotal_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.LtBlInfo_Title_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel34);
            this.LtBlInfo_Pnl.Controls.Add(this.BlTotalTitle_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel33);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel28);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel29);
            this.LtBlInfo_Pnl.Controls.Add(this.Bf2TmBl_tNedit);
            this.LtBlInfo_Pnl.Controls.Add(this.Bf3TmBl_tNedit);
            this.LtBlInfo_Pnl.Controls.Add(this.LMBl_tNedit);
            this.LtBlInfo_Pnl.Controls.Add(this.Bf3TmBl_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.Bf2TmBl_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.LMBl_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel26);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel11);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel24);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel25);
            this.LtBlInfo_Pnl.Location = new System.Drawing.Point(676, 1);
            this.LtBlInfo_Pnl.Name = "LtBlInfo_Pnl";
            this.LtBlInfo_Pnl.Size = new System.Drawing.Size(207, 210);
            this.LtBlInfo_Pnl.TabIndex = 3;
            // 
            // BlTotal_Label
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance40.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance40.TextHAlignAsString = "Right";
            appearance40.TextVAlignAsString = "Middle";
            this.BlTotal_Label.Appearance = appearance40;
            this.BlTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.BlTotal_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BlTotal_Label.Location = new System.Drawing.Point(96, 162);
            this.BlTotal_Label.Name = "BlTotal_Label";
            this.BlTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.BlTotal_Label.TabIndex = 598;
            // 
            // LtBlInfo_Title_Label
            // 
            appearance97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance97.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance97.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance97.BorderColor = System.Drawing.Color.Black;
            appearance97.TextHAlignAsString = "Center";
            appearance97.TextVAlignAsString = "Middle";
            this.LtBlInfo_Title_Label.Appearance = appearance97;
            this.LtBlInfo_Title_Label.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.LtBlInfo_Title_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.LtBlInfo_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LtBlInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.LtBlInfo_Title_Label.Name = "LtBlInfo_Title_Label";
            this.LtBlInfo_Title_Label.Size = new System.Drawing.Size(192, 24);
            this.LtBlInfo_Title_Label.TabIndex = 589;
            this.LtBlInfo_Title_Label.Text = "�O��c�����";
            // 
            // ultraLabel34
            // 
            appearance190.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel34.Appearance = appearance190;
            this.ultraLabel34.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel34.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel34.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel34.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(202, 33);
            this.ultraLabel34.TabIndex = 583;
            // 
            // BlTotalTitle_Label
            // 
            appearance94.TextHAlignAsString = "Left";
            appearance94.TextVAlignAsString = "Middle";
            this.BlTotalTitle_Label.Appearance = appearance94;
            this.BlTotalTitle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BlTotalTitle_Label.Location = new System.Drawing.Point(5, 162);
            this.BlTotalTitle_Label.Name = "BlTotalTitle_Label";
            this.BlTotalTitle_Label.Size = new System.Drawing.Size(89, 22);
            this.BlTotalTitle_Label.TabIndex = 587;
            this.BlTotalTitle_Label.Text = "�c�����v";
            // 
            // ultraLabel33
            // 
            appearance95.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel33.Appearance = appearance95;
            this.ultraLabel33.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel33.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel33.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel33.Location = new System.Drawing.Point(0, 157);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(202, 32);
            this.ultraLabel33.TabIndex = 586;
            // 
            // ultraLabel28
            // 
            appearance96.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel28.Appearance = appearance96;
            this.ultraLabel28.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel28.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel28.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel28.Location = new System.Drawing.Point(0, 154);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(202, 4);
            this.ultraLabel28.TabIndex = 573;
            // 
            // ultraLabel29
            // 
            appearance98.BackColor = System.Drawing.Color.Transparent;
            appearance98.TextHAlignAsString = "Center";
            appearance98.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance98;
            this.ultraLabel29.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel29.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel29.Location = new System.Drawing.Point(96, 40);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(101, 18);
            this.ultraLabel29.TabIndex = 578;
            this.ultraLabel29.Text = "�c��";
            // 
            // Bf2TmBl_tNedit
            // 
            appearance99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance99.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance99.ForeColorDisabled = System.Drawing.Color.Black;
            appearance99.TextHAlignAsString = "Right";
            this.Bf2TmBl_tNedit.ActiveAppearance = appearance99;
            appearance100.BackColor = System.Drawing.Color.White;
            appearance100.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance100.ForeColor = System.Drawing.Color.Black;
            appearance100.ForeColorDisabled = System.Drawing.Color.Black;
            appearance100.TextHAlignAsString = "Right";
            this.Bf2TmBl_tNedit.Appearance = appearance100;
            this.Bf2TmBl_tNedit.AutoSelect = true;
            this.Bf2TmBl_tNedit.BackColor = System.Drawing.Color.White;
            this.Bf2TmBl_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.Bf2TmBl_tNedit.DataText = "";
            this.Bf2TmBl_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Bf2TmBl_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.Bf2TmBl_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf2TmBl_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Bf2TmBl_tNedit.Location = new System.Drawing.Point(96, 97);
            this.Bf2TmBl_tNedit.MaxLength = 13;
            this.Bf2TmBl_tNedit.Name = "Bf2TmBl_tNedit";
            this.Bf2TmBl_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.Bf2TmBl_tNedit.Size = new System.Drawing.Size(101, 22);
            this.Bf2TmBl_tNedit.TabIndex = 2;
            this.Bf2TmBl_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.Bf2TmBl_tNedit.Leave += new System.EventHandler(this.AcpOdrTtlLMBlDmd_tNedit_Leave);
            this.Bf2TmBl_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.Bf2TmBl_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // Bf3TmBl_tNedit
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance64.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance64.ForeColorDisabled = System.Drawing.Color.Black;
            appearance64.TextHAlignAsString = "Right";
            this.Bf3TmBl_tNedit.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.White;
            appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance65.ForeColor = System.Drawing.Color.Black;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            appearance65.TextHAlignAsString = "Right";
            this.Bf3TmBl_tNedit.Appearance = appearance65;
            this.Bf3TmBl_tNedit.AutoSelect = true;
            this.Bf3TmBl_tNedit.BackColor = System.Drawing.Color.White;
            this.Bf3TmBl_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.Bf3TmBl_tNedit.DataText = "";
            this.Bf3TmBl_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Bf3TmBl_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.Bf3TmBl_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf3TmBl_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Bf3TmBl_tNedit.Location = new System.Drawing.Point(96, 66);
            this.Bf3TmBl_tNedit.MaxLength = 13;
            this.Bf3TmBl_tNedit.Name = "Bf3TmBl_tNedit";
            this.Bf3TmBl_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.Bf3TmBl_tNedit.Size = new System.Drawing.Size(101, 22);
            this.Bf3TmBl_tNedit.TabIndex = 1;
            this.Bf3TmBl_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.Bf3TmBl_tNedit.Leave += new System.EventHandler(this.AcpOdrTtlLMBlDmd_tNedit_Leave);
            this.Bf3TmBl_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.Bf3TmBl_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // LMBl_tNedit
            // 
            appearance172.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance172.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance172.ForeColorDisabled = System.Drawing.Color.Black;
            appearance172.TextHAlignAsString = "Right";
            this.LMBl_tNedit.ActiveAppearance = appearance172;
            appearance173.BackColor = System.Drawing.Color.White;
            appearance173.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance173.ForeColor = System.Drawing.Color.Black;
            appearance173.ForeColorDisabled = System.Drawing.Color.Black;
            appearance173.TextHAlignAsString = "Right";
            this.LMBl_tNedit.Appearance = appearance173;
            this.LMBl_tNedit.AutoSelect = true;
            this.LMBl_tNedit.BackColor = System.Drawing.Color.White;
            this.LMBl_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.LMBl_tNedit.DataText = "";
            this.LMBl_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.LMBl_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.LMBl_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LMBl_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.LMBl_tNedit.Location = new System.Drawing.Point(96, 128);
            this.LMBl_tNedit.MaxLength = 13;
            this.LMBl_tNedit.Name = "LMBl_tNedit";
            this.LMBl_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.LMBl_tNedit.Size = new System.Drawing.Size(101, 22);
            this.LMBl_tNedit.TabIndex = 3;
            this.LMBl_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.LMBl_tNedit.Leave += new System.EventHandler(this.AcpOdrTtlLMBlDmd_tNedit_Leave);
            this.LMBl_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.LMBl_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // Bf3TmBl_Label
            // 
            appearance174.TextHAlignAsString = "Left";
            appearance174.TextVAlignAsString = "Middle";
            this.Bf3TmBl_Label.Appearance = appearance174;
            this.Bf3TmBl_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf3TmBl_Label.Location = new System.Drawing.Point(5, 66);
            this.Bf3TmBl_Label.Name = "Bf3TmBl_Label";
            this.Bf3TmBl_Label.Size = new System.Drawing.Size(88, 22);
            this.Bf3TmBl_Label.TabIndex = 567;
            this.Bf3TmBl_Label.Text = "�O�X�X��c��";
            // 
            // Bf2TmBl_Label
            // 
            appearance179.TextHAlignAsString = "Left";
            appearance179.TextVAlignAsString = "Middle";
            this.Bf2TmBl_Label.Appearance = appearance179;
            this.Bf2TmBl_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf2TmBl_Label.Location = new System.Drawing.Point(5, 97);
            this.Bf2TmBl_Label.Name = "Bf2TmBl_Label";
            this.Bf2TmBl_Label.Size = new System.Drawing.Size(89, 22);
            this.Bf2TmBl_Label.TabIndex = 569;
            this.Bf2TmBl_Label.Text = "�O�X��c��";
            // 
            // LMBl_Label
            // 
            appearance180.TextHAlignAsString = "Left";
            appearance180.TextVAlignAsString = "Middle";
            this.LMBl_Label.Appearance = appearance180;
            this.LMBl_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LMBl_Label.Location = new System.Drawing.Point(5, 128);
            this.LMBl_Label.Name = "LMBl_Label";
            this.LMBl_Label.Size = new System.Drawing.Size(89, 22);
            this.LMBl_Label.TabIndex = 571;
            this.LMBl_Label.Text = "�O��c��";
            // 
            // ultraLabel26
            // 
            appearance189.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel26.Appearance = appearance189;
            this.ultraLabel26.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel26.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel26.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel26.Location = new System.Drawing.Point(0, 123);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(202, 32);
            this.ultraLabel26.TabIndex = 577;
            // 
            // ultraLabel11
            // 
            appearance191.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel11.Appearance = appearance191;
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel11.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel11.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel11.Location = new System.Drawing.Point(0, 32);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(202, 30);
            this.ultraLabel11.TabIndex = 582;
            // 
            // ultraLabel24
            // 
            appearance192.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel24.Appearance = appearance192;
            this.ultraLabel24.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel24.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel24.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel24.Location = new System.Drawing.Point(0, 61);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(202, 32);
            this.ultraLabel24.TabIndex = 584;
            // 
            // ultraLabel25
            // 
            appearance193.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel25.Appearance = appearance193;
            this.ultraLabel25.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel25.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel25.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel25.Location = new System.Drawing.Point(0, 92);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(202, 32);
            this.ultraLabel25.TabIndex = 585;
            // 
            // CustDmdPrc_panel
            // 
            this.CustDmdPrc_panel.Controls.Add(this.ExpectedDepositDate_tDateEdit);
            this.CustDmdPrc_panel.Controls.Add(this.CollectCondValue_tNedit);
            this.CustDmdPrc_panel.Controls.Add(this.CollectCond_Label);
            this.CustDmdPrc_panel.Controls.Add(this.ultraLabel52);
            this.CustDmdPrc_panel.Controls.Add(this.ultraLabel51);
            this.CustDmdPrc_panel.Controls.Add(this.ultraLabel50);
            this.CustDmdPrc_panel.Controls.Add(this.ultraLabel49);
            this.CustDmdPrc_panel.Controls.Add(this.ultraLabel1);
            this.CustDmdPrc_panel.Controls.Add(this.ultraLabel39);
            this.CustDmdPrc_panel.Location = new System.Drawing.Point(4, 293);
            this.CustDmdPrc_panel.Name = "CustDmdPrc_panel";
            this.CustDmdPrc_panel.Size = new System.Drawing.Size(275, 108);
            this.CustDmdPrc_panel.TabIndex = 4;
            // 
            // ExpectedDepositDate_tDateEdit
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            this.ExpectedDepositDate_tDateEdit.ActiveEditAppearance = appearance41;
            this.ExpectedDepositDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ExpectedDepositDate_tDateEdit.CalendarDisp = true;
            appearance42.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.ForeColorDisabled = System.Drawing.Color.Black;
            appearance42.TextHAlignAsString = "Left";
            appearance42.TextVAlignAsString = "Middle";
            this.ExpectedDepositDate_tDateEdit.EditAppearance = appearance42;
            this.ExpectedDepositDate_tDateEdit.Enabled = false;
            this.ExpectedDepositDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ExpectedDepositDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ExpectedDepositDate_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExpectedDepositDate_tDateEdit.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextHAlignAsString = "Left";
            appearance43.TextVAlignAsString = "Middle";
            this.ExpectedDepositDate_tDateEdit.LabelAppearance = appearance43;
            this.ExpectedDepositDate_tDateEdit.Location = new System.Drawing.Point(95, 41);
            this.ExpectedDepositDate_tDateEdit.Name = "ExpectedDepositDate_tDateEdit";
            this.ExpectedDepositDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ExpectedDepositDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ExpectedDepositDate_tDateEdit.Size = new System.Drawing.Size(156, 22);
            this.ExpectedDepositDate_tDateEdit.TabIndex = 2;
            this.ExpectedDepositDate_tDateEdit.TabStop = true;
            this.ExpectedDepositDate_tDateEdit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.ExpectedDepositDate_tDateEdit.Enter += new System.EventHandler(this.Control_Enter);
            this.ExpectedDepositDate_tDateEdit.Leave += new System.EventHandler(this.DateEdit_Leave);
            // 
            // CollectCondValue_tNedit
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance48.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            appearance48.TextHAlignAsString = "Right";
            this.CollectCondValue_tNedit.ActiveAppearance = appearance48;
            appearance49.BackColor = System.Drawing.Color.White;
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextHAlignAsString = "Right";
            this.CollectCondValue_tNedit.Appearance = appearance49;
            this.CollectCondValue_tNedit.AutoSelect = true;
            this.CollectCondValue_tNedit.BackColor = System.Drawing.Color.White;
            this.CollectCondValue_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CollectCondValue_tNedit.DataText = "";
            this.CollectCondValue_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CollectCondValue_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 0, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CollectCondValue_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CollectCondValue_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CollectCondValue_tNedit.Location = new System.Drawing.Point(218, 75);
            this.CollectCondValue_tNedit.MaxLength = 0;
            this.CollectCondValue_tNedit.Name = "CollectCondValue_tNedit";
            this.CollectCondValue_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CollectCondValue_tNedit.Size = new System.Drawing.Size(11, 22);
            this.CollectCondValue_tNedit.TabIndex = 64;
            this.CollectCondValue_tNedit.Visible = false;
            // 
            // CollectCond_Label
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance50.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance50.TextHAlignAsString = "Left";
            appearance50.TextVAlignAsString = "Middle";
            this.CollectCond_Label.Appearance = appearance50;
            this.CollectCond_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CollectCond_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CollectCond_Label.Location = new System.Drawing.Point(95, 75);
            this.CollectCond_Label.Name = "CollectCond_Label";
            this.CollectCond_Label.Size = new System.Drawing.Size(117, 22);
            this.CollectCond_Label.TabIndex = 63;
            this.CollectCond_Label.WrapText = false;
            // 
            // ultraLabel52
            // 
            appearance51.TextHAlignAsString = "Left";
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel52.Appearance = appearance51;
            this.ultraLabel52.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel52.Location = new System.Drawing.Point(5, 74);
            this.ultraLabel52.Name = "ultraLabel52";
            this.ultraLabel52.Size = new System.Drawing.Size(96, 24);
            this.ultraLabel52.TabIndex = 566;
            this.ultraLabel52.Text = "�������";
            // 
            // ultraLabel51
            // 
            appearance58.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel51.Appearance = appearance58;
            this.ultraLabel51.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel51.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel51.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel51.Location = new System.Drawing.Point(0, 68);
            this.ultraLabel51.Name = "ultraLabel51";
            this.ultraLabel51.Size = new System.Drawing.Size(256, 35);
            this.ultraLabel51.TabIndex = 565;
            // 
            // ultraLabel50
            // 
            appearance77.TextHAlignAsString = "Left";
            appearance77.TextVAlignAsString = "Middle";
            this.ultraLabel50.Appearance = appearance77;
            this.ultraLabel50.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel50.Location = new System.Drawing.Point(3, 41);
            this.ultraLabel50.Name = "ultraLabel50";
            this.ultraLabel50.Size = new System.Drawing.Size(96, 24);
            this.ultraLabel50.TabIndex = 564;
            this.ultraLabel50.Text = "�����\���";
            // 
            // ultraLabel49
            // 
            appearance80.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel49.Appearance = appearance80;
            this.ultraLabel49.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel49.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel49.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel49.Location = new System.Drawing.Point(0, 34);
            this.ultraLabel49.Name = "ultraLabel49";
            this.ultraLabel49.Size = new System.Drawing.Size(256, 35);
            this.ultraLabel49.TabIndex = 562;
            // 
            // ultraLabel1
            // 
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance83.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance83.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance83.BorderColor = System.Drawing.Color.Black;
            appearance83.TextHAlignAsString = "Center";
            appearance83.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance83;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(4, 6);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(248, 24);
            this.ultraLabel1.TabIndex = 545;
            this.ultraLabel1.Text = "�����E������";
            // 
            // ultraLabel39
            // 
            appearance84.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel39.Appearance = appearance84;
            this.ultraLabel39.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel39.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel39.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel39.Location = new System.Drawing.Point(0, 1);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(256, 34);
            this.ultraLabel39.TabIndex = 544;
            // 
            // ultraLabel48
            // 
            appearance81.TextHAlignAsString = "Left";
            appearance81.TextVAlignAsString = "Middle";
            this.ultraLabel48.Appearance = appearance81;
            this.ultraLabel48.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel48.Location = new System.Drawing.Point(7, 402);
            this.ultraLabel48.Name = "ultraLabel48";
            this.ultraLabel48.Size = new System.Drawing.Size(96, 24);
            this.ultraLabel48.TabIndex = 561;
            this.ultraLabel48.Text = "���������s��";
            this.ultraLabel48.Visible = false;
            // 
            // ultraLabel47
            // 
            appearance82.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel47.Appearance = appearance82;
            this.ultraLabel47.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel47.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel47.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel47.Location = new System.Drawing.Point(4, 395);
            this.ultraLabel47.Name = "ultraLabel47";
            this.ultraLabel47.Size = new System.Drawing.Size(256, 35);
            this.ultraLabel47.TabIndex = 559;
            this.ultraLabel47.Visible = false;
            // 
            // TtlItdedDisInTax_tNedit
            // 
            appearance125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance125.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance125.ForeColorDisabled = System.Drawing.Color.Black;
            appearance125.TextHAlignAsString = "Right";
            this.TtlItdedDisInTax_tNedit.ActiveAppearance = appearance125;
            appearance126.BackColor = System.Drawing.Color.White;
            appearance126.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance126.ForeColor = System.Drawing.Color.Black;
            appearance126.ForeColorDisabled = System.Drawing.Color.Black;
            appearance126.TextHAlignAsString = "Right";
            this.TtlItdedDisInTax_tNedit.Appearance = appearance126;
            this.TtlItdedDisInTax_tNedit.AutoSelect = true;
            this.TtlItdedDisInTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedDisInTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedDisInTax_tNedit.DataText = "";
            this.TtlItdedDisInTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedDisInTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedDisInTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedDisInTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedDisInTax_tNedit.Location = new System.Drawing.Point(507, 330);
            this.TtlItdedDisInTax_tNedit.MaxLength = 13;
            this.TtlItdedDisInTax_tNedit.Name = "TtlItdedDisInTax_tNedit";
            this.TtlItdedDisInTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedDisInTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedDisInTax_tNedit.TabIndex = 593;
            this.TtlItdedDisInTax_tNedit.Visible = false;
            // 
            // ItdedSalesInTax_tNedit
            // 
            appearance164.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance164.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance164.ForeColorDisabled = System.Drawing.Color.Black;
            appearance164.TextHAlignAsString = "Right";
            this.ItdedSalesInTax_tNedit.ActiveAppearance = appearance164;
            appearance165.BackColor = System.Drawing.Color.White;
            appearance165.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance165.ForeColor = System.Drawing.Color.Black;
            appearance165.ForeColorDisabled = System.Drawing.Color.Black;
            appearance165.TextHAlignAsString = "Right";
            this.ItdedSalesInTax_tNedit.Appearance = appearance165;
            this.ItdedSalesInTax_tNedit.AutoSelect = true;
            this.ItdedSalesInTax_tNedit.BackColor = System.Drawing.Color.White;
            this.ItdedSalesInTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.ItdedSalesInTax_tNedit.DataText = "";
            this.ItdedSalesInTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ItdedSalesInTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.ItdedSalesInTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedSalesInTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ItdedSalesInTax_tNedit.Location = new System.Drawing.Point(297, 330);
            this.ItdedSalesInTax_tNedit.MaxLength = 13;
            this.ItdedSalesInTax_tNedit.Name = "ItdedSalesInTax_tNedit";
            this.ItdedSalesInTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.ItdedSalesInTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.ItdedSalesInTax_tNedit.TabIndex = 581;
            this.ItdedSalesInTax_tNedit.Visible = false;
            // 
            // SalesInTax_tNedit
            // 
            appearance136.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance136.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            appearance136.TextHAlignAsString = "Right";
            this.SalesInTax_tNedit.ActiveAppearance = appearance136;
            appearance137.BackColor = System.Drawing.Color.White;
            appearance137.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance137.ForeColor = System.Drawing.Color.Black;
            appearance137.ForeColorDisabled = System.Drawing.Color.Black;
            appearance137.TextHAlignAsString = "Right";
            this.SalesInTax_tNedit.Appearance = appearance137;
            this.SalesInTax_tNedit.AutoSelect = true;
            this.SalesInTax_tNedit.BackColor = System.Drawing.Color.White;
            this.SalesInTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SalesInTax_tNedit.DataText = "";
            this.SalesInTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SalesInTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SalesInTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesInTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SalesInTax_tNedit.Location = new System.Drawing.Point(297, 364);
            this.SalesInTax_tNedit.MaxLength = 13;
            this.SalesInTax_tNedit.Name = "SalesInTax_tNedit";
            this.SalesInTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SalesInTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.SalesInTax_tNedit.TabIndex = 582;
            this.SalesInTax_tNedit.Visible = false;
            // 
            // TtlRetInnerTax_tNedit
            // 
            appearance106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance106.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance106.ForeColorDisabled = System.Drawing.Color.Black;
            appearance106.TextHAlignAsString = "Right";
            this.TtlRetInnerTax_tNedit.ActiveAppearance = appearance106;
            appearance107.BackColor = System.Drawing.Color.White;
            appearance107.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance107.ForeColor = System.Drawing.Color.Black;
            appearance107.ForeColorDisabled = System.Drawing.Color.Black;
            appearance107.TextHAlignAsString = "Right";
            this.TtlRetInnerTax_tNedit.Appearance = appearance107;
            this.TtlRetInnerTax_tNedit.AutoSelect = true;
            this.TtlRetInnerTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlRetInnerTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlRetInnerTax_tNedit.DataText = "";
            this.TtlRetInnerTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlRetInnerTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlRetInnerTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlRetInnerTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlRetInnerTax_tNedit.Location = new System.Drawing.Point(402, 364);
            this.TtlRetInnerTax_tNedit.MaxLength = 13;
            this.TtlRetInnerTax_tNedit.Name = "TtlRetInnerTax_tNedit";
            this.TtlRetInnerTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlRetInnerTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlRetInnerTax_tNedit.TabIndex = 588;
            this.TtlRetInnerTax_tNedit.Visible = false;
            // 
            // TtlDisInnerTax_tNedit
            // 
            appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance120.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance120.ForeColorDisabled = System.Drawing.Color.Black;
            appearance120.TextHAlignAsString = "Right";
            this.TtlDisInnerTax_tNedit.ActiveAppearance = appearance120;
            appearance121.BackColor = System.Drawing.Color.White;
            appearance121.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance121.ForeColor = System.Drawing.Color.Black;
            appearance121.ForeColorDisabled = System.Drawing.Color.Black;
            appearance121.TextHAlignAsString = "Right";
            this.TtlDisInnerTax_tNedit.Appearance = appearance121;
            this.TtlDisInnerTax_tNedit.AutoSelect = true;
            this.TtlDisInnerTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlDisInnerTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlDisInnerTax_tNedit.DataText = "";
            this.TtlDisInnerTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlDisInnerTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlDisInnerTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlDisInnerTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlDisInnerTax_tNedit.Location = new System.Drawing.Point(507, 364);
            this.TtlDisInnerTax_tNedit.MaxLength = 13;
            this.TtlDisInnerTax_tNedit.Name = "TtlDisInnerTax_tNedit";
            this.TtlDisInnerTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlDisInnerTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlDisInnerTax_tNedit.TabIndex = 594;
            this.TtlDisInnerTax_tNedit.Visible = false;
            // 
            // TtlRetOuterTax_tNedit
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Right";
            this.TtlRetOuterTax_tNedit.ActiveAppearance = appearance47;
            appearance53.BackColor = System.Drawing.Color.White;
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            appearance53.TextHAlignAsString = "Right";
            this.TtlRetOuterTax_tNedit.Appearance = appearance53;
            this.TtlRetOuterTax_tNedit.AutoSelect = true;
            this.TtlRetOuterTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlRetOuterTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlRetOuterTax_tNedit.DataText = "";
            this.TtlRetOuterTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlRetOuterTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlRetOuterTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlRetOuterTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlRetOuterTax_tNedit.Location = new System.Drawing.Point(507, 295);
            this.TtlRetOuterTax_tNedit.MaxLength = 13;
            this.TtlRetOuterTax_tNedit.Name = "TtlRetOuterTax_tNedit";
            this.TtlRetOuterTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlRetOuterTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlRetOuterTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlRetOuterTax_tNedit.TabIndex = 5;
            this.TtlRetOuterTax_tNedit.Visible = false;
            this.TtlRetOuterTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlRetOuterTax_tNedit.Leave += new System.EventHandler(this.Ret_tNedit_Leave);
            this.TtlRetOuterTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlRetOuterTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedRetInTax_tNedit
            // 
            appearance114.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance114.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance114.ForeColorDisabled = System.Drawing.Color.Black;
            appearance114.TextHAlignAsString = "Right";
            this.TtlItdedRetInTax_tNedit.ActiveAppearance = appearance114;
            appearance115.BackColor = System.Drawing.Color.White;
            appearance115.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance115.ForeColor = System.Drawing.Color.Black;
            appearance115.ForeColorDisabled = System.Drawing.Color.Black;
            appearance115.TextHAlignAsString = "Right";
            this.TtlItdedRetInTax_tNedit.Appearance = appearance115;
            this.TtlItdedRetInTax_tNedit.AutoSelect = true;
            this.TtlItdedRetInTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedRetInTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedRetInTax_tNedit.DataText = "";
            this.TtlItdedRetInTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedRetInTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedRetInTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedRetInTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedRetInTax_tNedit.Location = new System.Drawing.Point(402, 330);
            this.TtlItdedRetInTax_tNedit.MaxLength = 13;
            this.TtlItdedRetInTax_tNedit.Name = "TtlItdedRetInTax_tNedit";
            this.TtlItdedRetInTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedRetInTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedRetInTax_tNedit.TabIndex = 587;
            this.TtlItdedRetInTax_tNedit.Visible = false;
            // 
            // SalesOutTax_tNedit
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance25.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Right";
            this.SalesOutTax_tNedit.ActiveAppearance = appearance25;
            appearance26.BackColor = System.Drawing.Color.White;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Right";
            this.SalesOutTax_tNedit.Appearance = appearance26;
            this.SalesOutTax_tNedit.AutoSelect = true;
            this.SalesOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.SalesOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SalesOutTax_tNedit.DataText = "";
            this.SalesOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SalesOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SalesOutTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SalesOutTax_tNedit.Location = new System.Drawing.Point(297, 295);
            this.SalesOutTax_tNedit.MaxLength = 13;
            this.SalesOutTax_tNedit.Name = "SalesOutTax_tNedit";
            this.SalesOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SalesOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SalesOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.SalesOutTax_tNedit.TabIndex = 2;
            this.SalesOutTax_tNedit.Visible = false;
            this.SalesOutTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.SalesOutTax_tNedit.Leave += new System.EventHandler(this.Sales_tNedit_Leave);
            this.SalesOutTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.SalesOutTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlDisOuterTax_tNedit
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            appearance30.TextHAlignAsString = "Right";
            this.TtlDisOuterTax_tNedit.ActiveAppearance = appearance30;
            appearance31.BackColor = System.Drawing.Color.White;
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            appearance31.TextHAlignAsString = "Right";
            this.TtlDisOuterTax_tNedit.Appearance = appearance31;
            this.TtlDisOuterTax_tNedit.AutoSelect = true;
            this.TtlDisOuterTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlDisOuterTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlDisOuterTax_tNedit.DataText = "";
            this.TtlDisOuterTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlDisOuterTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlDisOuterTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlDisOuterTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlDisOuterTax_tNedit.Location = new System.Drawing.Point(402, 295);
            this.TtlDisOuterTax_tNedit.MaxLength = 13;
            this.TtlDisOuterTax_tNedit.Name = "TtlDisOuterTax_tNedit";
            this.TtlDisOuterTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlDisOuterTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlDisOuterTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlDisOuterTax_tNedit.TabIndex = 8;
            this.TtlDisOuterTax_tNedit.Visible = false;
            this.TtlDisOuterTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlDisOuterTax_tNedit.Leave += new System.EventHandler(this.Dis_tNedit_Leave);
            this.TtlDisOuterTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlDisOuterTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // BillNo_uLabel
            // 
            appearance160.TextHAlignAsString = "Left";
            appearance160.TextVAlignAsString = "Middle";
            this.BillNo_uLabel.Appearance = appearance160;
            this.BillNo_uLabel.Location = new System.Drawing.Point(760, 111);
            this.BillNo_uLabel.Name = "BillNo_uLabel";
            this.BillNo_uLabel.Size = new System.Drawing.Size(71, 24);
            this.BillNo_uLabel.TabIndex = 9;
            this.BillNo_uLabel.Text = "������No";
            // 
            // BillNo_tNedit
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Right";
            this.BillNo_tNedit.ActiveAppearance = appearance28;
            appearance29.BackColor = System.Drawing.Color.White;
            appearance29.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            this.BillNo_tNedit.Appearance = appearance29;
            this.BillNo_tNedit.AutoSelect = true;
            this.BillNo_tNedit.BackColor = System.Drawing.Color.White;
            this.BillNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.BillNo_tNedit.DataText = "";
            this.BillNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BillNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.BillNo_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BillNo_tNedit.Location = new System.Drawing.Point(850, 111);
            this.BillNo_tNedit.MaxLength = 9;
            this.BillNo_tNedit.Name = "BillNo_tNedit";
            this.BillNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.BillNo_tNedit.Size = new System.Drawing.Size(84, 24);
            this.BillNo_tNedit.TabIndex = 1;
            this.BillNo_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.BillNo_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.BillNo_tNedit.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.BillNo_tNedit_BeforeEnterEditMode);
            // 
            // tLine6
            // 
            this.tLine6.BackColor = System.Drawing.Color.Transparent;
            this.tLine6.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine6.ForeColor = System.Drawing.Color.Black;
            this.tLine6.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine6.Location = new System.Drawing.Point(840, 107);
            this.tLine6.Name = "tLine6";
            this.tLine6.Size = new System.Drawing.Size(4, 32);
            this.tLine6.TabIndex = 1343;
            this.tLine6.Text = "tLine6";
            // 
            // MAKAU09110UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(978, 659);
            this.Controls.Add(this.DmdSalesInfo_Panel);
            this.Controls.Add(this.CustomerInfo_Panel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKAU09110UB";
            this.Text = "���Ӑ���яC��";
            this.Load += new System.EventHandler(this.MAKAU09110UB_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKAU09110UB_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKAU09110UB_Closing);
            this.CustomerInfo_Panel.ResumeLayout(false);
            this.CustomerInfo_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_DemandInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.DmdSalesInfo_Panel.ResumeLayout(false);
            this.DmdSalesInfo_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetOutTax_tNedit)).EndInit();
            this.SalesInfo_Pnl.ResumeLayout(false);
            this.SalesInfo_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleslSlipCount_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetTaxFree_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetOutTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisTaxFree_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisOutTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItdedSalesTaxFree_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItdedSalesOutTax_tNedit)).EndInit();
            this.DepositInfo_Pnl.ResumeLayout(false);
            this.DepositInfo_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepositKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisNrml_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeeNrml_tNedit)).EndInit();
            this.AjustInfo_Pnl.ResumeLayout(false);
            this.AjustInfo_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaxAdjust_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAdjust_tNedit)).EndInit();
            this.LtBlInfo_Pnl.ResumeLayout(false);
            this.LtBlInfo_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bf2TmBl_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bf3TmBl_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMBl_tNedit)).EndInit();
            this.CustDmdPrc_panel.ResumeLayout(false);
            this.CustDmdPrc_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectCondValue_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisInTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItdedSalesInTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlRetInnerTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlDisInnerTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlRetOuterTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetInTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOutTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlDisOuterTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine6)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get{ return this._canLogicalDeleteDataExtraction; }
		}

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get{ return this._canClose; }
			set{ this._canClose = value; }
		}

		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get{ return this._canNew; }
		}

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get{ return this._canDelete; }
		}

		/// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
		/// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
		public MGridDisplayLayout DefaultGridDisplayLayout
		{
			get{ return this._defaultGridDisplayLayout; }
		}

		/// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
		/// <value>����Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
		public string TargetTableName
		{
			get{ return this._targetTableName; }
			set{ this._targetTableName = value; }
		}
		
		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int AccRecDataIndex
		{
			get{ return this._accRecDataIndex; }
			set{ this._accRecDataIndex = value; }
		}

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DmdPrcDataIndex
		{
			get{ return this._dmdPrcDataIndex; }
			set{ this._dmdPrcDataIndex = value; }
		}

		/// <summary>���C���O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>���C���O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToAccRecGridColumn
		{
			get{ return this._defaultAutoFillToAccRecGridColumn; }
		}

		/// <summary>���׃O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>���׃O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToDmdPrcGridColumn
		{
			get{ return this._defaultAutoFillToDmdPrcGridColumn; }
		}
		/// <summary>�I�����ꂽ���_�R�[�h�v���p�e�B</summary>
		/// <value>��ʂőI�����ꂽ���_�R�[�h���擾���܂��B</value>
		public string SectionCodeData
		{
			get{ return this._sectionCode; }
			set{ this._sectionCode = value; }
		}
		/// <summary>�I�����ꂽ���Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>��ʂőI�����ꂽ���Ӑ�R�[�h���擾���܂��B</value>
		public int TargetCustomerCode
		{
			get{ return this._targetCustomerCode; }
			set{ this._targetCustomerCode = value; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>�I�����ꂽ������R�[�h�v���p�e�B</summary>
        /// <value>��ʂőI�����ꂽ������R�[�h���擾���܂�</value>
        public int TargetClaimCode
        {
            get { return this._targetClaimCode; }
            set { this._targetClaimCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        /// <summary>�w��敪�ݒ�v���p�e�B</summary>
        /// <value>�ݒ��ʏ�́u�w��敪�v�v���_�E���̒l��ݒ肵�܂��B</value>
        public int TargetDivType
        {
            get { return this._targetDivType; }
            set { this._targetDivType = value; }
        }

        /// <summary>�������R�[�h�̊Ǘ��c�Ə��R�[�h</summary>
        /// <value>�����ݒ�Ɏg�p����Ǘ��c�Ə��R�[�h��ݒ肵�܂��B</value>
        public string MngSectionCode
        {
            get { return this._mngSectionCode; }
            set { this._mngSectionCode = value; }
        }

        /// <summary>�����p������R�[�h</summary>
        /// <value>�����Ŏg�p���鐿����R�[�h���擾���܂��B�I�𐿋���R�[�h�͍Č������̂ݎg�p</value>
        public int CondClaimCode
        {
            get { return this._condClaimCode; }
            set { this._condClaimCode = value; }
        }

        /// <summary>�����p���Ӑ�R�[�h</summary>
        /// <value>�����Ŏg�p���链�Ӑ�R�[�h���擾���܂��B�I�𓾈Ӑ�R�[�h�͍Č������̂ݎg�p</value>
        public int CondCustomerCode
        {
            get { return this._condCustomerCode; }
            set { this._condCustomerCode = value; }
        }

        /// <summary>�����p�v�㋒�_�R�[�h</summary>
        /// <value>�����Ŏg�p����v�㋒�_�R�[�h���擾���܂��B�I�����_�R�[�h�͍Č������̂ݎg�p</value>
        public string CondSectionCode
        {
            get { return this._condSectionCode; }
            set { this._condSectionCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

		/// <summary>���_����ʂ�\�����邩�̗L���v���p�e�B</summary>
		/// <value>���_�I�v�V�������擾���܂��B</value>
		public bool Opt_SectionInfo
		{
			get{ return this.Opt_Section; }
		}

		/// <summary>�����_�R�[�h�v���p�e�B</summary>
		/// <value>�����_�R�[�h���擾���܂��B</value>
		public string GetCompanySectionCode
		{
			get{ return this._companySecCode; }
		}
		/// <summary>�{�Ћ@�\�t���O�v���p�e�B</summary>
		/// <value>�{�Ћ@�\�t���O���擾���܂��B</value>
		public bool GetMainOfficeFuncMode
		{
			get{ return this._mainOfficeFuncFlag; }
		}
		# endregion

        private Form _invokerForm;
        public Form InvokerForm
        {
            get { return this._invokerForm; }
            set { this._invokerForm = value; }
        }

		// ===================================================================================== //
		// �O�����\�b�h
		// ===================================================================================== //
		# region Public Methods

		/// <summary>�_���폜�f�[�^���o�\�ݒ胊�X�g�擾</summary>
		/// <returns>�_���폜�ېݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �_���폜�f�[�^���o�̉E�s�����X�g�ɂĎ擾</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = false;     // ���|
			blRet[1] = false;     // ����
			return blRet;
		}

		/// <summary>�����񕝒����ݒ胊�X�g�擾</summary>
		/// <returns>�����񕝒����L�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �����񕝒����̗L�������X�g�ɂĎ擾</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetDefaultAutoFillToGridColumnList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;   
			blRet[1] = true;   
			return blRet;
		}

		/// <summary>�V�K�{�^���\���ݒ胊�X�g�擾</summary>
		/// <returns>�V�K�{�^���\���L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �V�K�{�^���̕\���̗L���ݒ�����X�g�ɂĎ擾���܂�</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;   
			blRet[1] = true;
			return blRet;
		}

		/// <summary>�폜�{�^���\���ݒ胊�X�g�擾</summary>
		/// <returns>�폜�{�^���\���L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �폜�{�^���̕\���̗L���ݒ�����X�g�ɂĎ擾���܂�</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = false;  
			blRet[1] = false;
			
			return blRet;
		}

		/// <summary>�C���{�^���\���ݒ胊�X�g�擾</summary>
		/// <returns>�C���{�^���\���L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �C���{�^���̕\���̗L���ݒ�����X�g�ɂĎ擾���܂�</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;    
			blRet[1] = true;
			return blRet;
		}

		/// <summary>�e�e�[�u���^�C�g���擾</summary>
		/// <returns>�e�e�[�u���^�C�g��</returns>
		/// <remarks>
		/// <br>Note       : �e�e�[�u�����e��\������O���b�h�̃^�C�g�����擾����</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public string[] GetGridTitleList()
		{
			string[] strRet = new string[2];
			strRet[0] = this._mainGridTitle;
			strRet[1] = this._detailsGridTitle;
			return strRet;
		}

		/// <summary>�e�e�[�u���\���A�C�R���擾</summary>
		/// <returns>�e�e�[�u���\���A�C�R��</returns>
		/// <remarks>
		/// <br>Note       : �e�e�[�u�����e��\������O���b�h�̃A�C�R�����擾����</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public Image[] GetGridIconList()
		{
			Image[] objRet = new Image[2];
			objRet[0] = this._mainGridIcon;
			objRet[1] = this._detailsGridIcon;
			return objRet;
		}

		/// <summary>�f�[�^�폜����</summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int Delete()
		{
			// ������
			return 0;
		}

		/// <summary>�������</summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}
	
		/// <summary>�O���b�h��O�Ϗ��擾����</summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			appearanceTable = new Hashtable[2];
			// ���|�O���b�h�̗�O�Ϗ��ݒ�
			Hashtable	accTable = new Hashtable();

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_CREATEDATETIME,             new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            accTable.Add(CustAccRecDmdPrcAcs.COL_UPDATEDATETIME,             new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_DELETEDATE_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPSECCODE_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_CUSTOMERCODE_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_CUSTOMERNAME_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_CUSTOMERNAME2_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_CUSTOMERSNM_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_CLAIMCODE_TITLE,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_CLAIMNAME_TITLE,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_CLAIMNAME2_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_CLAIMSNM_TITLE,             new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPYEARMONTH_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPDATEJP_TITLE,          new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPYEARMONTHJP_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDMDNRML_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDNRML_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDNRML_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDNRML_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDMDDEPO_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDDEPO_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDDEPO_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDDEPO_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMETTLBLCACC_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_OFSTHISTIMESALES_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_OFSTHISSALESTAX_TITLE,      new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDOFFSETOUTTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDOFFSETINTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDOFFSETTAXFREE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_OFFSETOUTTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_OFFSETINTAX_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDSALESOUTTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDSALESINTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDSALESTAXFREE_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_SALESOUTTAX_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_SALESINTAX_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_CONSTAXLAYMETHOD_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_CONSTAXRATE_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_FRACTIONPROCCD_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_MONTHADDUPEXPDATE_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_GUID_TITLE,                 new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            // 2009.01.06 >>>
            //accTable.Add(CustAccRecDmdPrcAcs.COL_ACPODRTTL3TMBFACCREC_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_ACPODRTTL2TMBFACCREC_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ACPODRTTL3TMBFACCREC_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_ACPODRTTL2TMBFACCREC_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.06 <<<
            accTable.Add(CustAccRecDmdPrcAcs.COL_LASTTIMEACCREC_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMESALES_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_THISSALESTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_OFSTHISTIMESALES_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_OFSTHISSALESTAX_TITLE,      new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //accTable.Add(CustAccRecDmdPrcAcs.COL_TTLINCDTBTTAXEXC_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_TTLINCDTBTTAX_TITLE,        new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDRETOUTTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDRETINTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDRETTAXFREE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLRETOUTERTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLRETINNERTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDDISOUTTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDDISINTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDDISTAXFREE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLDISOUTERTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TTLDISINNERTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            //accTable.Add(CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE,       new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.06 >>>
            //accTable.Add(CustAccRecDmdPrcAcs.COL_TOTALADJUST_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_TOTALADJUST_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.06 <<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //accTable.Add(CustAccRecDmdPrcAcs.COL_NONSTMNTAPPEARANCE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_NONSTMNTISDONE_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_STMNTAPPEARANCE_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_STMNTISDONE_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //accTable.Add(CustAccRecDmdPrcAcs.COL_THISCASHSALEPRICE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(CustAccRecDmdPrcAcs.COL_THISCASHSALETAX,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_SALESSLIPCOUNT_TITLE,             new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_BILLPRINTDATE_TITLE,              new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_EXPECTEDDEPOSITDATE_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_COLLECTCOND_TITLE,                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDEPODMD_TITLE,      new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_AFCALTMONTHACCREC_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //accTable.Add( CustAccRecDmdPrcAcs.COL_THISPAYOFFSET_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( CustAccRecDmdPrcAcs.COL_THISPAYOFFSETTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            // 2009.01.06 Add >>>
            accTable.Add(CustAccRecDmdPrcAcs.COL_STMONCADDUPUPDDATE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_LAMONCADDUPUPDDATE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(CustAccRecDmdPrcAcs.COL_DEPOTOTAL, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.06 Add <<<

            appearanceTable[0] = accTable;

			// �����O���b�h�̗�O�Ϗ��ݒ�
			Hashtable	dmdTable = new Hashtable();
			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CREATEDATETIME,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_UPDATEDATETIME,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_DELETEDATE_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPSECCODE_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_RESULTSECCODE_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CUSTOMERCODE_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CUSTOMERNAME_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CUSTOMERNAME2_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CUSTOMERSNM_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black)); 
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CLAIMCODE_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CLAIMNAME_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CLAIMNAME2_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CLAIMSNM_TITLE,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPYEARMONTH_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPDATEJP_TITLE,         new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ADDUPYEARMONTHJP_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDMDNRML_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight,"", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDNRML_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight,"", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDNRML_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight,"", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDNRML_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDMDDEPO_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDDEPO_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDDEPO_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDDEPO_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMETTLBLCDMD_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_OFSTHISTIMESALES_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_OFSTHISSALESTAX_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDOFFSETOUTTAX_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDOFFSETINTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDOFFSETTAXFREE_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_OFFSETOUTTAX_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_OFFSETINTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDSALESOUTTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDSALESINTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDSALESTAXFREE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_SALESOUTTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_SALESINTAX_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CONSTAXLAYMETHOD_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CONSTAXRATE_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_FRACTIONPROCCD_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_CADDUPUPDEXECDATE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_DMDPROCNUM_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_GUID_TITLE,                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ACPODRTTL3TMBFBLDMD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_ACPODRTTL2TMBFBLDMD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_LASTTIMEDEMAND_TITLE,      new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMESALES_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISSALESTAX_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_OFSTHISTIMESALES_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_OFSTHISSALESTAX_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLINCDTBTTAXEXC_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLINCDTBTTAX_TITLE,       new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDRETOUTTAX_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDRETINTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDRETTAXFREE_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLRETOUTERTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLRETINNERTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDDISOUTTAX_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDDISINTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLITDEDDISTAXFREE_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLDISOUTERTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TTLDISINNERTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE,       new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.06 >>>
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_TOTALADJUST_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_TOTALADJUST_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.06 <<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
 
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_NONSTMNTAPPEARANCE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_NONSTMNTISDONE_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_STMNTAPPEARANCE_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_STMNTISDONE_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISCASHSALEPRICE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISCASHSALETAX,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_SALESSLIPCOUNT_TITLE,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_BILLPRINTDATE_TITLE,             new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_EXPECTEDDEPOSITDATE_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_COLLECTCOND_TITLE,               new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            dmdTable.Add(CustAccRecDmdPrcAcs.COL_THISTIMEDEPODMD_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_AFCALDEMANDPRICE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // 2009.01.06 Add >>>
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_STARTCADDUPUPDDATE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_LASTCADDUPUPDDATE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_DEPOTOTAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.06 Add <<<

            // ADD 2009/06/23 ------>>>
            dmdTable.Add(CustAccRecDmdPrcAcs.COL_BILLNO_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ADD 2009/06/23 ------<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dmdTable.Add( CustAccRecDmdPrcAcs.COL_THISPAYOFFSET_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( CustAccRecDmdPrcAcs.COL_THISPAYOFFSETTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            appearanceTable[1] = dmdTable;
		}

		/// <summary>�O���b�h��O�Ϗ��擾�i�ڍׁj</summary>
		/// <param name="targetGrid">�O���b�h��O�Ϗ��</param>
		/// <param name="TABLE_NAME">�Y���e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�̗�̊O�Ϗ���ݒ���쐬</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public void GetDisPlayDisplayLayoutTable(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, string TABLE_NAME)
		{
			targetGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

			// �Œ��̐ݒ�
			targetGrid.DisplayLayout.UseFixedHeaders               = false;
			targetGrid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			targetGrid.DisplayLayout.Override.CellClickAction      = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			targetGrid.DisplayLayout.Override.SelectTypeCell       = Infragistics.Win.UltraWinGrid.SelectType.None;
			targetGrid.DisplayLayout.Override.AllowUpdate          = Infragistics.Win.DefaultableBoolean.False;

			// ��O�Ϗ��ݒ�
			// �ҏW�s�ݒ�
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in targetGrid.DisplayLayout.Bands[TABLE_NAME].Columns)
			{
				column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				column.AutoEdit = false;
				switch ( column.Key )
				{		
					case REC_TOTAL3_BEF_TITLE:
					case REC_TOTAL2_BEF_TITLE:
					case REC_TOTAL1_BEF_TITLE:
					case REC_THISTIMESALES_TITLE:
					case REC_CONSTAX_TITLE:
					case REC_THISTIMEDEPO_TITLE:
                    case REC_ACCRECBLNCE_TITLE:
                    case REC_THISTIMEPAYM_TITLE:
                    case REC_PAYMCONSTAX_TITLE:
                    case REC_DMDPRCBLNCE_TITLE:
                    case REC_BALANCEADJUST_TITLE:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
                    case REC_TOTALADJUST_TITLE:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
                    {
						column.Format = MASK_MONEY;
						break;
					}
				}
			}
		}

		/// <summary>�o�C���h�f�[�^�Z�b�g�擾����</summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="TableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] TableName)
		{
			// �f�[�^�Z�b�g
            this.Bind_DataSet = this._custAccRecDmdPrcAcs.BindDataSet;
			bindDataSet = this.Bind_DataSet;
            // �e�[�u�����擾
			string[] strRet = new string[2];
			strRet[0] = CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE;
			strRet[1] = CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE;
			TableName = strRet;
		}

		/// <summary>�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��</summary>
		/// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X��ݒ肵�܂�</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public void SetDataIndexList(int[] indexList)
		{
			this._accRecDataIndex    = indexList[0];
			this._dmdPrcDataIndex    = indexList[1];
		}

		/// <summary>Label�ɕ\��������z�J���}����</summary>
		/// <param name="val">���z</param>
		/// <param name="checkMode">���ʕ�������12���𒴂������ɃJ���}�ҏW���Ȃ��`�F�b�N�L�� true:�������� flase:�������Ȃ�</param>
		/// <returns>����</returns>
		/// <remarks>
		/// <br>Note       : �n���ꂽ���z��Label�p�ɃJ���}�ҏW���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public string Claim_panelDataFormat(Int64 val , bool checkMode)
		{
			if (val == 0 ) return "";
			if ( checkMode == true )
			{
				if ( val.ToString("#,###;-#,###;").Length > 14 )
					return val.ToString();
			}

			return val.ToString("#,###;-#,###;");
		}

		/// <summary>���Ӑ�f�[�^��������</summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�f�[�^���������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int CustomerData_Search(ref int totalCount, int readCount)
		{
			int status = 0;
            CustomerSearchPara  para = new CustomerSearchPara();
            CustomerSearchRet[] retArray = null;

			if (readCount == 0)
			{
				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                para.EnterpriseCode = this._enterpriseCode;
                status = this._customerAcs.Serch(out retArray, para);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( retArray.Length > 0 ) 
					{
                        // �ŏI�̓��Ӑ�I�u�W�F�N�g��ޔ�����
                        this._prevCustomer = ((CustomerSearchRet)retArray[retArray.Length - 1]).Clone();
					}

                    foreach (CustomerSearchRet customerRet in retArray)
					{
                        if (this._customerTable.ContainsKey(customerRet.CustomerCode) == false)
						{
                            CustomerToDataSet(customerRet.Clone());
						}
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(this, 								    // �e�E�B���h�E�t�H�[��
						          emErrorLevel.ERR_LEVEL_STOP, 		        // �G���[���x��
						          "MAKAU09110U", 						    // �A�Z���u���h�c�܂��̓N���X�h�c
						          "���Ӑ���яC��",					        // �v���O��������
						          "MAKAU09110U", 						    // ��������
						          TMsgDisp.OPE_GET, 					    // �I�y���[�V����
						          "���Ӑ���ǂݍ��݂Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
						          status, 							        // �X�e�[�^�X�l
						          this._customerAcs,	 				    // �G���[�����������I�u�W�F�N�g
						          MessageBoxButtons.OK, 				    // �\������{�^��
						          MessageBoxDefaultButton.Button1 );	    // �����\���{�^��
					break;
				}
			}

			totalCount = this._totalCount;

			return status;
		}

		/// <summary>�w�蓾�Ӑ�f�[�^���ǂݍ��ݏ���</summary>
        /// <param name="customerRet">���Ӑ���</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�蓾�Ӑ�R�[�h�̃f�[�^���������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int ReadCustomerData(out CustomerSearchRet customerRet, int customerCode)
		{
            customerRet = (CustomerSearchRet)this._customerTable[customerCode];

            this._AllaccrecTable.Clear();
			this._AlldmdprcTable.Clear();
            this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Clear();
            this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Clear();

            if (customerRet == null)
            {
                //return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // DEL 2009/04/06
                // ADD 2009/04/06 ------>>>
                // UI��ʂ��J������Ԃœ��Ӑ��ǉ������ꍇ�A
                // ���������s����̂ōČ���������ǉ�
                CustomerSearchPara para = new CustomerSearchPara();
                CustomerSearchRet[] retArray = null;
                para.EnterpriseCode = this._enterpriseCode;
                para.CustomerCode = customerCode;
                // �Č���
                int status = this._customerAcs.Serch(out retArray, para);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            foreach (CustomerSearchRet wkCustomerRet in retArray)
                            {
                                if (this._customerTable.ContainsKey(wkCustomerRet.CustomerCode) == false)
                                {
                                    CustomerToDataSet(wkCustomerRet.Clone());
                                    customerRet = wkCustomerRet.Clone();
                                    break;
                                }
                            }
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    default:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }
                }
                return status;
                // ADD 2009/04/06 ------<<<
            }
			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}

		/// <summary>���_���̃f�[�^��������</summary>
		/// <param name="retSecInfSetList">���_���i�[</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���_����S���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int SecInf_Search(out ArrayList retSecInfSetList)
		{
			int status = 0;
			// �f�[�^�̒��o���������s����
			// ���_�����擾
		
			status  =  SearchAllSecInfSetInfo(out retSecInfSetList, true, true);

			switch (status)
			{
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					foreach( SecInfoSet secInfSet in retSecInfSetList)
					{
						if (this._secInfSetTable.ContainsKey(secInfSet.SectionCode.Trim()) == true)
						{
                            this._secInfSetTable.Remove(secInfSet.SectionCode.Trim());
						}
                        this._secInfSetTable.Add(secInfSet.SectionCode.Trim(), secInfSet);
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					return status;
				}
			}
			// �����_���擾
			status = ReadCompanySecInfoSetInfo();
			return status;
		}

		/// <summary>�������z���̃f�[�^��������</summary>
        /// <param name="claimCode">������R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="addUpSecCode">���_�R�[�h</param>
        /// <param name="targetDivType">�w��敪�^�C�v</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �������z�����擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int DmdRec_Data_Search(int claimCode, int customerCode, string addUpSecCode, int targetDivType)
		{
			int status = 0;
			Hashtable retHash = new Hashtable();
			this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Clear();

            if ((customerCode != 0) && (addUpSecCode != ""))
            {
                status = SearchDmdRecInfo(claimCode, customerCode, addUpSecCode, out retHash, true, targetDivType);
            }
			return status ;
		}

		/// <summary>���|���z���̃f�[�^��������</summary>
        /// <param name="claimCode">������R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="addUpSecCode">���_�R�[�h</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���|���z�����擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int AccRec_Data_Search(int claimCode, int customerCode, string addUpSecCode, int targetDivType)
		{
			int status = 0;
			Hashtable retHash = new Hashtable();
			this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Clear();
            if ((customerCode != 0) && (addUpSecCode != ""))
            {
                status = SearchAccPrcInfo(claimCode, customerCode, addUpSecCode, out retHash, true, targetDivType);
            }
			return status ;
		}

        /// <summary>�ӕҏW�p�̑Ή�����񖼏̎擾</summary>
		/// <param name="LABELList">�񖼏̔z��</param>
		/// <remarks>
		/// <br>Note       : �ӕҏW�p�̑Ή�����񖼏̂�Ԃ��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        public void ReadTabelData_claim_panelSet(out string[] LABELList)
        {
            LABELList = new string[15];

            // �ӂɏ��𔽉f
            LABELList[0] = REC_TOTAL3_BEF_TITLE;        // �R��ȑO�c��
            LABELList[1] = REC_TOTAL2_BEF_TITLE;        // �Q��ȑO�c��
            LABELList[2] = REC_TOTAL1_BEF_TITLE;        // �O��c��
            LABELList[3] = REC_THISTIMESALES_TITLE;     // ���񔄏�
            LABELList[4] = REC_CONSTAX_TITLE;           // �����
            LABELList[5] = REC_THISTIMEPAYM_TITLE;      // ����x��
            LABELList[6] = REC_PAYMCONSTAX_TITLE;       // �x�������
            LABELList[7] = REC_THISTIMEDEPO_TITLE;      // �������
            LABELList[8] = REC_ACCRECBLNCE_TITLE;       // �c��
        }


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START

        /// <summary>
        /// �V�K��ʂ��쐬����ۂɁA�󂯎�������Ӑ�R�[�h�����ɓ��Ӑ�̏����擾����
        /// </summary>
        /// <remarks>�e�[�u����Ɂu���Ӑ於�v�u���Ӑ於�Q�v�Ȃǂ�
        /// �Z�b�g����Ă��Ȃ��������������邽�߂̏��u�i���Ƃ��Ƃ̐݌v�̖��j
        /// �f�[�^�x�[�X����уA�v���P�[�V�����̕\����͖��Ȃ��͗l�i�\������Ȃ��j</remarks>
        public void GetSettledCustomerData()
        {
            int status;
            CustomerInfo customerInfo;

            // Public Property�Ŏ󂯎�������Ӑ�R�[�h�����ɓ��Ӑ�����擾����
            status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, this._targetCustomerCode, out customerInfo);

            // ���Ӑ�����擾�ł����Ƃ��̂ݏ��𒊏o
            if (customerInfo != null)
            {
                this.CustomerName_Label.Text = customerInfo.Name;
                this.CustomerName2_Label.Text = customerInfo.Name2;

                // ������������o���Ă���
                this.ClaimName_Label.Text = customerInfo.ClaimName;
                this.ClaimName2_Label.Text = customerInfo.ClaimName2;
                this.ClaimSnm_Label.Text = customerInfo.ClaimSnm;
            }

        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
        # endregion

        // ===================================================================================== //
		// �������\�b�h�iDB�֘A�j
		// ===================================================================================== //
		# region Private Methods_DB_Relation

		/// <summary>HashTable�ɓ��Ӑ���i�[</summary>
        /// <param name="customerRet">���Ӑ���</param>
		/// <remarks>
		/// <br>Note       : �n���ꂽ���Ӑ����HashTable�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void CustomerToDataSet(CustomerSearchRet customerRet)
		{
            if (this._customerTable.ContainsKey(customerRet.CustomerCode) == true)
			{
                this._customerTable.Remove(customerRet.CustomerCode);
			}
            this._customerTable.Add(customerRet.CustomerCode, customerRet);
		}

        /// <summary>���|���z���擾����</summary>
        /// <param name="claimCode">������R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="addUpSecCode">���_�R�[�h</param>
		/// <param name="retAccRecTable">���|���z���擾����</param>
		/// <param name="BindDataSetMode">DataSet�ւ̐ݒ�L���iHashTable�݂̂Ȃ�false�j</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : ���|���z���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        /// 
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
		private int SearchAccPrcInfo(int claimCode, int customerCode, string addUpSecCode, out Hashtable retAccRecTable, bool BindDataSetMode, int targetDivType)
        //private int SearchAccPrcInfo(int claimCode, int customerCode, string addUpSecCode, out Hashtable retAccRecTable, bool BindDataSetMode)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
		{	
			int status = 0;
			int totalCount = 0;

			retAccRecTable = new Hashtable();

            // �S�Ђ��I������Ă���ꍇ
            if (addUpSecCode == ALLSECCODE)
            {
                addUpSecCode = null;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            if (targetDivType == TARGET_DIV_CLAIM)
            {
                // �w��敪�F������̎�
                // ���Ӑ�E������R�[�h�F��ʏ�̓��Ӑ�R�[�h
                // �v�㋒�_�R�[�h�F��ʂ̋��_�R�[�h
                // 2009.01.06 >>>
                //status = this._custAccRecDmdPrcAcs.SearchCustAccRec(out totalCount, this._enterpriseCode, addUpSecCode, customerCode, customerCode);
                status = this._custAccRecDmdPrcAcs.SearchCustAccRec(out totalCount, this._enterpriseCode, addUpSecCode, customerCode, 0);
                // 2009.01.06 <<<
            }
            else
            {
                // �w��敪�F���Ӑ�̎�
                // ������R�[�h�F���Ӑ�ɑ΂��鐿����R�[�h
                // ���Ӑ�R�[�h�F��ʏ�̓��Ӑ�R�[�h
                // �v�㋒�_�R�[�h�F������̊Ǘ��c�Ə��R�[�h
                status = this._custAccRecDmdPrcAcs.SearchCustAccRec(out totalCount, this._enterpriseCode, this._mngSectionCode, this._targetClaimCode, customerCode);
                //status = this._custAccRecDmdPrcAcs.SearchCustAccRec(out totalCount, this._enterpriseCode, addUpSecCode, , customerCode);
                
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_STOP, 		    // �G���[���x��
                                      "MAKAU09110U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                      "���Ӑ���яC��",					    // �v���O��������
                                      "SearchAccPrcInfo", 					// ��������
                                      TMsgDisp.OPE_GET, 					// �I�y���[�V����
                                      "���|���ǂݍ��݂Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
                                      status, 							    // �X�e�[�^�X�l
                                      this._custAccRecDmdPrcAcs,			// �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK, 				// �\������{�^��
                                      MessageBoxDefaultButton.Button1);	    // �����\���{�^��
                        break;
                    }
            }

			return status;
		}

        /// <summary>�������z���擾����</summary>
        /// <param name="claimCode">������R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
		/// <param name="retDmdRecTable">�������z���擾����</param>
		/// <param name="BindDataSetMode">DataSet�ւ̐ݒ�L���iHashTable�݂̂Ȃ�false�j</param>
        /// <param name="targetDivType">�w��敪�^�C�v</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : �������z���擾���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private int SearchDmdRecInfo(int claimCode, int customerCode,string addUpSecCode, out Hashtable retDmdRecTable,bool BindDataSetMode, int targetDivType)
		{
			int status = 0;
            int totalCount = 0;
			
			retDmdRecTable = new Hashtable();

            // �S�Ђ��I������Ă���ꍇ
            if (addUpSecCode == ALLSECCODE)
            {
                addUpSecCode = null;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            if (targetDivType == TARGET_DIV_CLAIM) 
            {
                // �w��敪���u������v�̎��͌v�㋒�_�E���ы��_�ɉ�ʂ̋��_�R�[�h���Z�b�g���Č���
                // �ΏۂƂȂ链�Ӑ�E������R�[�h�͐�����R�[�h
                // 2009.01.06 >>>
                //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, addUpSecCode, addUpSecCode, customerCode, customerCode);
                status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, addUpSecCode, string.Empty, customerCode, 0);
                // 2009.01.06 <<<
                //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, addUpSecCode, string.Empty, claimCode, customerCode);
            }
            else
            {
                // �w��敪���u���Ӑ�v�̎��͎��ы��_�ɉ�ʂ̋��_�R�[�h�A�v�㋒�_�ɊǗ��c�Ə��R�[�h���Z�b�g���Č���
                // �ΏۂƂȂ链�Ӑ�R�[�h�͓��Ӑ�R�[�h,������R�[�h�͓��Ӑ�ɑ΂��鐿����R�[�h
                //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, this._mngSectionCode, addUpSecCode, this.TargetClaimCode, customerCode);
                // 2009.01.06 >>>
                //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, this._mngSectionCode, addUpSecCode, claimCode, customerCode);
                status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, addUpSecCode, this._mngSectionCode, claimCode, customerCode);
                // 2009.01.06 <<<
                //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, this._mngSectionCode, addUpSecCode, claimCode, customerCode);
                
            }
            //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, string.Empty, addUpSecCode, claimCode, customerCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_STOP, 		    // �G���[���x��
                                      "MAKAU09110U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                      "���Ӑ���яC��",					    // �v���O��������
                                      "SearchDmdRecInfo", 					// ��������
                                      TMsgDisp.OPE_GET, 					// �I�y���[�V����
                                      "�������ǂݍ��݂Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
                                      status, 							    // �X�e�[�^�X�l
                                      this._custAccRecDmdPrcAcs,			// �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK, 				// �\������{�^��
                                      MessageBoxDefaultButton.Button1);	    // �����\���{�^��
                        break;
                    }
            }

			return status;
		}

        /// <summary>���_���ύX����</summary>
		/// <param name="retSecInfSet">���_���}�X�^�N���X�I�u�W�F�N�g</param>
		/// <param name="showMessage">���b�Z�[�W�̕\��(true:�\��, false:��\��)</param>
		/// <param name="dataOutPutMode">�f�[�^����ʂɏo�͂���敪(true:�\��, false:��\��)</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : ���_�����Q�Ƃ��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private int SearchAllSecInfSetInfo(out ArrayList retSecInfSet, bool showMessage, bool dataOutPutMode )
		{	
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			retSecInfSet = new ArrayList();
			ArrayList secInfoSetList = new ArrayList();
		
			SecInfoSet[] secInfoSets = new SecInfoSet[_secInfoAcs.SecInfoSetList.Length];
			foreach( SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
			{
				secInfoSetList.Add(secInfoSet);
			}

			if (secInfoSetList.Count == 0)
            {
                status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
			
			switch( status ) 
			{
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{	
					retSecInfSet = secInfoSetList;
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				{
					if( dataOutPutMode == true )
					{
						if ( showMessage == true ) 
						{
							TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
								          emErrorLevel.ERR_LEVEL_STOP, 		    // �G���[���x��
								          "MAKAU09110U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
								          "���Ӑ���яC��",					    // �v���O��������
								          "SearchAllSecInfSetInfo", 			// ��������
								          TMsgDisp.OPE_GET, 					// �I�y���[�V����
								          "���_��񂪓o�^����Ă��܂���B", 	// �\�����郁�b�Z�[�W
								          status, 							    // �X�e�[�^�X�l
								          this._secInfoAcs,	 				    // �G���[�����������I�u�W�F�N�g
								          MessageBoxButtons.OK, 				// �\������{�^��
								          MessageBoxDefaultButton.Button1 );	// �����\���{�^��
						}
					}
					break;
				}
				default:
				{
					if ( dataOutPutMode == true )
					{
						if ( showMessage == true ) 
						{
							TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
								          emErrorLevel.ERR_LEVEL_STOP, 		    // �G���[���x��
								          "MAKAU09110U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
								          "���Ӑ���яC��",					    // �v���O��������
								          "SearchAllSecInfSetInfo", 			// ��������
								          TMsgDisp.OPE_GET, 					// �I�y���[�V����
								          "���_���ǂݍ��݂Ɏ��s���܂����B",   // �\�����郁�b�Z�[�W
								          status, 							    // �X�e�[�^�X�l
								          this._secInfoAcs,	 				    // �G���[�����������I�u�W�F�N�g
								          MessageBoxButtons.OK, 				// �\������{�^��
								          MessageBoxDefaultButton.Button1 );	// �����\���{�^��
						}
					}
					break;
				}
			}

			return status;
		}

		/// <summary>�����_���擾����</summary>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : ���_�����Q�Ƃ��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private int ReadCompanySecInfoSetInfo()
		{	
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            this._mainOfficeFuncFlag = true;    // �{�Ћ@�\�Œ�

            //SecInfoSet secInfoSet = this._secInfoAcs.SecInfoSet;

            //if (secInfoSet == null)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}

            //switch( status ) 
            //{
            //    case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
            //    {	
            //        this._companySecCode = secInfoSet.SectionCode;
            //        // �����_���{�Ћ@�\�L��
            //        this._mainOfficeFuncFlag = Convert.ToBoolean(this._secInfoAcs.GetMainOfficeFuncFlag(this._companySecCode)); 
            //        break;
            //    }
            //    case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
            //    {
            //        TMsgDisp.Show(this,											    // �e�E�B���h�E�t�H�[��
            //                      emErrorLevel.ERR_LEVEL_EXCLAMATION,				// �G���[���x��
            //                      "MAKAU09110U",		  						    // �A�Z���u���h�c�܂��̓N���X�h�c
            //                      " ���_������ɓo�^����Ă��܂���B",			// �\�����郁�b�Z�[�W 
            //                      0,												// �X�e�[�^�X�l
            //                      MessageBoxButtons.OK);							// �\������{�^��
            //        break;
            //    }
            //    default:
            //    {
            //        TMsgDisp.Show(this,											    // �e�E�B���h�E�t�H�[��
            //                      emErrorLevel.ERR_LEVEL_STOP,					    // �G���[���x��
            //                      "MAKAU09110U",									// �A�Z���u���h�c�܂��̓N���X�h�c
            //                      this.Text,										// �v���O��������
            //                      "ReadCompanySecInfoSetInfo",				        // ��������
            //                      TMsgDisp.OPE_GET,								    // �I�y���[�V����
            //                      "���_������̓ǂݍ��݂Ɏ��s���܂����B",		    // �\�����郁�b�Z�[�W 
            //                      status,											// �X�e�[�^�X�l
            //                      this._secInfoAcs,			  			   		    // �G���[�����������I�u�W�F�N�g
            //                      MessageBoxButtons.OK,							    // �\������{�^��
            //                      MessageBoxDefaultButton.Button1);			  	    // �����\���{�^��
            //        break;
            //    }
            //}

			return status;
		}
		
        /// <summary>�r������</summary>
		/// <param name="status">status</param>
		/// <remarks>
		/// <br>Note       : �r������</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show(this,                                     // �e�E�B���h�E�t�H�[��
						          emErrorLevel.ERR_LEVEL_EXCLAMATION,       // �G���[���x��
						          "MAKAU09110U",						    // �A�Z���u��ID
						          "���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						          status,									// �X�e�[�^�X�l
						          MessageBoxButtons.OK);					// �\������{�^��
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show(this,                                     // �e�E�B���h�E�t�H�[��
						          emErrorLevel.ERR_LEVEL_EXCLAMATION,       // �G���[���x��
						          "MAKAU09110U",						    // �A�Z���u��ID
						          "���ɑ��[�����폜����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						          status,									// �X�e�[�^�X�l
						          MessageBoxButtons.OK);					// �\������{�^��
					break;
				}
			}
		}

		# endregion	

        // ===================================================================================== //
		// �������\�b�h�i��ʊ֘A�j
		// ===================================================================================== //
		# region Private Methods_Screen

        /// <summary>��ʃN���A����</summary>
		/// <param name="HeaderClear">���Ӑ�E���_�̃N���A�L�� true:�N���A false:�N���A���Ȃ�</param>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenClear( bool HeaderClear )
		{
			this._formBeingStarted = false;

			if ( HeaderClear == true )
			{
				// ���Ӑ���i�R�[�h�E���́E����)
				this.customerCode_Label.Text       = "";
				this.CustomerSnm_Label.Text       = "";
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                this.CustomerName2_Label.Text      = "";
                this.CustomerSnm_Label.Text        = ""; 
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                this.claimCode_Label.Text          = "";
                this.ClaimName_Label.Text          = "";
                this.ClaimName2_Label.Text         = "";
                this.ClaimSnm_Label.Text           = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				this.TotalDay_Label.Text           = "";
				// ���_���
				this.demandAddUpSecCd_Label.Text   = "";
				this.demandAddUpSecName_Label.Text = "";
			}

			// �v����t
            this.AddUpADate_tDateEdit.SetDateTime(DateTime.MinValue);

            // ADD 2009/06/23 ------>>>
            this.BillNo_tNedit.Text = "";   // ������No
            // ADD 2009/06/23 ------<<<
			
			// ----- �Ӎ��� -----
            // 2009.01.06 >>>
            //// �O����
            //this.TtlBf3TmBl_Label.Text = "";        // �R��ȑO�c��
            //this.TtlBf2TmBl_Label.Text = "";        // �Q��ȑO�c��
            //this.TtlLMBl_Label.Text    = "";        // �O��c��

            ////�J���}�ҏW�O�̒l��ݒ�
            //this.TtlBf3TmBl_Label.Tag  = 0;         // �R��ȑO�c��
            //this.TtlBf2TmBl_Label.Tag  = 0;         // �Q��ȑO�c��
            //this.TtlLMBl_Label.Tag     = 0;         // �O��c��

            //this.TtlSales_Label.Text   = "";        // ���񔄏�
            //this.TtlTax_Label.Text     = "";        // �����
            //this.TtlDepo_Label.Text    = "";        // �������
            //this.TtlBl_Label.Text      = "";        // ���|�c���c��

            this._totalDisplayTable.Rows.Clear();
            this._totalDisplayTable.Rows.Add(this._totalDisplayTable.NewRow());
            // 2009.01.06 <<<

            // ----- �ڍ׏���ʍ��� -----
			// ����E�x�����
            this.ItdedSalesOutTax_tNedit.Clear();   // ����O�őΏۊz
            this.SalesOutTax_tNedit.Clear();        // ����O�Ŋz
            this.ItdedSalesInTax_tNedit.Clear();    // ������őΏۊz
            this.SalesInTax_tNedit.Clear();         // ������Ŋz
            this.ItdedSalesTaxFree_tNedit.Clear();  // �����ېőΏۊz
            this.SalesTotal_Label.Text        = ""; // ���㍇�v�z     
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �ԕi
            this.TtlItdedRetOutTax_tNedit.Clear();  // �ԕi�O�őΏۊz
            this.TtlRetOuterTax_tNedit.Clear();     // �ԕi�O�Ŋz
            this.TtlItdedRetInTax_tNedit.Clear();   // �ԕi���őΏۊz
            this.TtlRetInnerTax_tNedit.Clear();     // �ԕi���Ŋz
            this.TtlItdedRetTaxFree_tNedit.Clear(); // �ԕi��ېőΏۊz
            this.RetTotal_Label.Text = "";          // �ԕi���v�z     
            // �l��
            this.TtlItdedDisOutTax_tNedit.Clear();  // �l���O�őΏۊz
            this.TtlDisOuterTax_tNedit.Clear();     // �l���O�Ŋz
            this.TtlItdedDisInTax_tNedit.Clear();   // �l�����őΏۊz
            this.TtlDisInnerTax_tNedit.Clear();     // �l�����Ŋz
            this.TtlItdedDisTaxFree_tNedit.Clear(); // �l����ېőΏۊz
            this.DisTotal_Label.Text = "";          // �l�����v�z   
            // �c������
            this.BalanceAdjust_tNedit.Clear();      // �c�������z
            //// ��������
            //this.ThisCashSalePrice_tNedit.Clear();  // ����������z
            //this.ThisCashSaleTax_tNedit.Clear();    // ������������

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // �����ϋ��z
            //this.NonStmntAppearance_tNedit.Clear();  // �����ϋ��z�i���U�j
            //this.NonStmntIsdone_tNedit.Clear();      // �����ϋ��z�i�􂵁j
            // ���ϋ��z
            //this.StmntAppearance_tNedit.Clear();    // ���ϋ��z�i���U�j
            //this.StmntIsdone_tNedit.Clear();        // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ItdedPaymOutTax_tNedit.Clear();    // �x���O�őΏۊz
            //this.PaymentOutTax_tNedit.Clear();      // �x���O�Ŋz
            //this.ItdedPaymInTax_tNedit.Clear();     // �x�����őΏۊz
            //this.PaymentInTax_tNedit.Clear();       // �x�����Ŋz
            //this.ItdedPaymTaxFree_tNedit.Clear();   // �x����ېőΏۊz
            //this.PaymTotal_Label.Text         = ""; // �x�����v�z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ItdedOutTaxTotal_Label.Text  = ""; // �O�őΏۊz���v
            //this.OutTaxTotal_Label.Text       = ""; // �O�Ŋz���v
            //this.ItdedInTaxTotal_Label.Text   = ""; // ���őΏۊz���v
            //this.InTaxTotal_Label.Text        = ""; // ���Ŋz���v
            //this.ItdedTaxFreeTotal_Label.Text = ""; // ��ېőΏۊz���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // �������
            //this.DepoNrml_tNedit.Clear();           // �ʏ�������z   // 2009.01.06 Del
            this.FeeNrml_tNedit.Clear();            // �ʏ�萔���z
            this.DisNrml_tNedit.Clear();            // �ʏ�l���z
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.Clear();            // �ʏ탊�x�[�g�z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.NrmlTotal_Label.Text    = "";      // �ʏ퍇�v�z
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.Depo_tNedit.Clear();               // �a����������z
            //this.FeeDepo_tNedit.Clear();            // �a����萔���z
            //this.DisDepo_tNedit.Clear();            // �a����l���z
            //this.RbtDepo_tNedit.Clear();            // �a������x�[�g�z
            //this.DepoTotal_Label.Text    = "";      // �a������v�z
            //this.DepoPrcTotal_Label.Text = "";      // �������z���v
            //this.FeeTotal_Label.Text     = "";      // �萔���z���v
            //this.DisTotal_Label.Text     = "";      // �l���z���v
            //this.RbtTotal_Label.Text     = "";      // ���x�[�g�z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // �O��c��
            this.Bf3TmBl_tNedit.Clear();            // �R��ȑO�c��
            this.Bf2TmBl_tNedit.Clear();            // �Q��ȑO�c��
            this.LMBl_tNedit.Clear();               // �O��c��

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �x�����z
            //this.ItdedPaymOutTax_tNedit.Clear();    // �x���O�őΏۊz
            //this.PaymentOutTax_tNedit.Clear();      // �x���O�Ŋz
            //this.ItdedPaymInTax_tNedit.Clear();     // �x�����őΏۊz
            //this.PaymentInTax_tNedit.Clear();       // �x�����Ŋz
            //this.ItdedPaymTaxFree_tNedit.Clear();   // �x����ېőΏۊz
            //this.ItdedPaymTotal_Label.Text = string.Empty;  // �x���z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            this._formBeingStarted = true;
		}

        /// <summary>��ʓ��͋����䏈��_�v����t</summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : �v����t�̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenInputPermissionControl_Date( bool enabled )
		{
			// �V�K�̎��̂�
			// �v����t
			this.AddUpADate_tDateEdit.Enabled = enabled;
		}

        /// <summary>��ʓ��͋����䏈��_���_</summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ���_�̍��ڂ̕\���E��\���𐧌䂵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenInputPermissionControl_Section( bool enabled )
		{
			this.SecInf_Tittle_Label.Visible      = enabled;
			this.demandAddUpSecCd_Label.Visible   = enabled;
			this.demandAddUpSecName_Label.Visible = enabled;
			this.tLine23.Visible                  = enabled;
		}

		/// <summary>��ʓ��͋����䏈��_�ڍ�</summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ���z�֘A�̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenInputPermissionControl_Details( bool enabled )
		{
			// ----- �ڍ׏���ʍ��� -----
			// ����E�x�����
            this.ItdedSalesOutTax_tNedit.Enabled  = enabled;
            this.SalesOutTax_tNedit.Enabled       = enabled;
            this.ItdedSalesInTax_tNedit.Enabled   = enabled;
            this.SalesInTax_tNedit.Enabled        = enabled;
            this.ItdedSalesTaxFree_tNedit.Enabled = enabled;
            this.SalesTotal_Label.Enabled         = enabled;      
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ItdedPaymOutTax_tNedit.Enabled   = enabled;
            //this.PaymentOutTax_tNedit.Enabled     = enabled;
            //this.ItdedPaymInTax_tNedit.Enabled    = enabled;
            //this.ItdedSalesInTax_tNedit.Enabled   = enabled;
            //this.PaymentInTax_tNedit.Enabled      = enabled;
            //this.ItdedPaymTaxFree_tNedit.Enabled  = enabled;
            //this.PaymTotal_Label.Enabled          = enabled;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ItdedOutTaxTotal_Label.Enabled   = enabled;
            //this.OutTaxTotal_Label.Enabled        = enabled;
            //this.ItdedInTaxTotal_Label.Enabled    = enabled;
            //this.InTaxTotal_Label.Enabled         = enabled;
            //this.ItdedTaxFreeTotal_Label.Enabled  = enabled;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // ����
            //this.DepoNrml_tNedit.Enabled          = enabled;  // 2009.01.06 Del
            this.FeeNrml_tNedit.Enabled           = enabled;
            this.DisNrml_tNedit.Enabled           = enabled;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.Enabled           = enabled;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.NrmlTotal_Label.Enabled          = enabled;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.Depo_tNedit.Enabled              = enabled;
            //this.FeeDepo_tNedit.Enabled           = enabled;
            //this.DisDepo_tNedit.Enabled           = enabled;
            //this.RbtDepo_tNedit.Enabled           = enabled;
            //this.DepoTotal_Label.Enabled          = enabled;
            //this.DepoPrcTotal_Label.Enabled       = enabled;
            //this.FeeTotal_Label.Enabled           = enabled;
            //this.DisTotal_Label.Enabled           = enabled;
            //this.RbtTotal_Label.Enabled           = enabled;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			// �O��c
			this.LMBl_tNedit.Enabled              = enabled;
            this.Bf2TmBl_tNedit.Enabled           = enabled;
            this.Bf3TmBl_tNedit.Enabled           = enabled;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �x��
            //this.ItdedPaymOutTax_tNedit.Enabled = enabled;
            //this.PaymentOutTax_tNedit.Enabled = enabled;
            //this.ItdedPaymInTax_tNedit.Enabled = enabled;
            //this.PaymentInTax_tNedit.Enabled = enabled;
            //this.ItdedPaymTaxFree_tNedit.Enabled = enabled;
            //this.ItdedPaymTotal_Label.Enabled = enabled;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

		}

        // ADD 2009/06/23 ------>>>
        /// <summary>��ʓ��͋����䏈��_������No</summary>
        /// <param name="enabled">���͋��ݒ�l</param>
        /// <remarks>
        /// <br>Note       : ������No�̓��͋��𐧌䂵�܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl_BillNo(bool enabled)
        {
            // �������̂ݕ\��
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                // ���|���
                this.BillNo_uLabel.Visible = false;
                this.BillNo_tNedit.Visible = false;
            }
            else
            {
                // �������
                this.BillNo_uLabel.Visible = true;
                this.BillNo_tNedit.Visible = true;
                this.BillNo_tNedit.Enabled = enabled;
            }
        }
        // ADD 2009/06/23 ------<<<
        
        /// <summary>��ʍč\�z����</summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			_logicalDeleteMode = -1;
			Control focusControl = null;   // �t�H�[�J�X�Z�b�g�R���g���[��

			// ����c�ݒ�
			this.Text = "���Ӑ���яC��";

            CustomerSearchRet customerRet = (CustomerSearchRet)this._customerTable[this._targetCustomerCode];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            CustomerInfo customerInfo;
            this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerRet.CustomerCode);

            // (������̏����̗���㔭�����Ȃ����A�O�̈�static�ɂȂ��ꍇ�̓����[�g�Ăяo�����鏈�����L�q)
            if (customerInfo.CustomerCode != customerRet.CustomerCode) {
                this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerRet.CustomerCode,out customerInfo);
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// ���Ӑ�E���_����\��
            this.customerCode_Label.Text = customerRet.CustomerCode.ToString().PadLeft(8, '0');
            this.CustomerSnm_Label.Text  = customerRet.Name.ToString().TrimEnd();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.CustomerName2_Label.Text = customerRet.Name2.ToString().TrimEnd();
            this.CustomerSnm_Label.Text = customerRet.Snm.ToString().TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.claimCode_Label.Text = customerInfo.ClaimCode.ToString().PadLeft(8, '0');
            this.ClaimName_Label.Text = customerInfo.ClaimName.ToString().TrimEnd();
            this.ClaimName2_Label.Text = customerInfo.ClaimName2.ToString().TrimEnd();
            this.ClaimSnm_Label.Text = customerInfo.ClaimSnm.ToString().TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.TotalDay_Label.Text      = customerRet.TotalDay.ToString();
            
            // 2009.01.06 Add >>>
            this.SettingDemandInfoGrid();
            this.ClearDepositDataTable();
            // 2009.01.06 Add <<<
			
			if ( this._sectionCode != "" )
			{
				this.demandAddUpSecCd_Label.Text = this._sectionCode;
				SecInfoSet secInfo = (SecInfoSet)this._secInfSetTable[this._sectionCode];
                if (secInfo != null)
                {
                    this.demandAddUpSecName_Label.Text = secInfo.SectionGuideNm;
                }
                else if (this._sectionCode == ALLSECCODE)
                {
                    this.demandAddUpSecCd_Label.Text   = "";
                    this.demandAddUpSecName_Label.Text = "�S��";
                }
                else
                {
                    this.demandAddUpSecName_Label.Text = "���_��� ���ݒ�";
                }
			}
			else 
			{
				this.demandAddUpSecCd_Label.Text   = "";
				this.demandAddUpSecName_Label.Text = "�S��";
			}

            // 2009.01.06 Add >>>
            this._totalDisplayTable.Rows.Clear();
            this._totalDisplayTable.Rows.Add(this._totalDisplayTable.NewRow());
            // 2009.01.06 Add <<<

			// ���|
			if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
                CustAccRec custAccRec = new CustAccRec();
                // 2009.01.06 Add >>>
                CustAccRec custAccRecTotal = new CustAccRec();
                List<AccRecDepoTotal> accRecDepoList = new List<AccRecDepoTotal>();
                List<AccRecDepoTotal> accRecDepoTotalList = new List<AccRecDepoTotal>();
                // 2009.01.06 Add <<<
				// �V�K
				if(this._accRecDataIndex < 0 )
				{
					// �V�K
					this.Mode_Label.Text = INSERT_MODE;
					_logicalDeleteMode = -1;
					focusControl = this.AddUpADate_tDateEdit;		
				}
				else
				{
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;
					_logicalDeleteMode = 0;
					focusControl = this.ItdedSalesOutTax_tNedit;
                    // 2009.01.06 >>>
                    //DataRowToCustAccRec(this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Rows[this._accRecDataIndex], custAccRec);
                    DataRowToCustAccRec(this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Rows[this._accRecDataIndex], out custAccRec, out accRecDepoList);

                    this.GetTotalCustAccRecFromTable(custAccRec, out custAccRecTotal, out accRecDepoTotalList);

                    // 2009.01.06 <<<
				}

                // 2009.01.06 Add >>>
                //this._editCustAccRec = custAccRec_Clone(custAccRec);
                //this._custAccRecClone = custAccRec_Clone(custAccRec);

                this._editCustAccRec = custAccRec.Clone();
                this._custAccRecClone = custAccRec.Clone();

                this._editAccRecDepoList = new List<AccRecDepoTotal>();
                foreach (AccRecDepoTotal accRecDepoTotal in accRecDepoList)
                {
                    this._editAccRecDepoList.Add(accRecDepoTotal.Clone());
                }
                this.AccRecDepoTotalListToTable(this._editAccRecDepoList);

                this._custAccRecTotal = custAccRecTotal.Clone();
                this._accRecDepoTotalList = new List<AccRecDepoTotal>();
                foreach (AccRecDepoTotal accRecDepoTotal in accRecDepoTotalList)
                {
                    this._accRecDepoTotalList.Add(accRecDepoTotal.Clone());
                }
                // 2009.01.06 Add <<<
				// ��ʕ\��		
                DetailsAccRecToScreen(this._editCustAccRec);
			
				this._accRecIndexBuf  = this._accRecDataIndex;
				this._dmdPrcIndexBuf  = -2;
                //this.TtlBl_Title_Label.Text         = "���|�c��";     // 2009.01.06 Del
                this.SalesPaymInfo_Title_Label.Text = "���|���";

            }
			else
			{
                CustDmdPrc custDmdPrc = new CustDmdPrc();
                // 2009.01.06 Add >>>
                CustDmdPrc custDmdTotalPrc = new CustDmdPrc();
                List<DmdDepoTotal> dmdDepoList = new List<DmdDepoTotal>();
                List<DmdDepoTotal> dmdDepoTotalList = new List<DmdDepoTotal>();
                // 2009.01.06 Add <<<
				// ���Ӑ�R�[�h���ݒ�
				if(this._dmdPrcDataIndex < 0 )
				{
					// �V�K
					this.Mode_Label.Text = INSERT_MODE;
					_logicalDeleteMode = -1;
					focusControl = this.AddUpADate_tDateEdit;		
				}
				else
				{
                    // 2009.01.06 >>>
                    //DataRowToCustDmdPrc(this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Rows[this._dmdPrcDataIndex], custDmdPrc);
                    DataRowToCustDmdPrc(this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Rows[this._dmdPrcDataIndex], out custDmdPrc, out dmdDepoList);

                    this.GetTotalCustDmdPrcFromTable(custDmdPrc, out custDmdTotalPrc, out dmdDepoTotalList);
                    // 2009.01.06 <<<
                    // �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;
					_logicalDeleteMode = 0;
                    //focusControl = this.ItdedSalesOutTax_tNedit;  // DEL 2009/06/23
                    focusControl = this.BillNo_tNedit;  // ADD 2009/06/23
				}

                // 2009.01.06 >>>
                //this._editCustDmdPrc = custdmdRec_Clone(custDmdPrc);
                //this._custDmdPrcClone = custdmdRec_Clone(custDmdPrc);

                this._editCustDmdPrc = custDmdPrc.Clone();
                this._custDmdPrcClone = custDmdPrc.Clone();

                this._editDmdDepoList = new List<DmdDepoTotal>();
                foreach (DmdDepoTotal dmdDepoTotal in dmdDepoList)
                {
                    this._editDmdDepoList.Add(dmdDepoTotal.Clone());
                }
                this.DmdDepoTotalListToTable(this._editDmdDepoList);

                this._custDmdPrcTotal = custDmdTotalPrc.Clone();
                this._dmdDepoTotalList = new List<DmdDepoTotal>();
                foreach (DmdDepoTotal dmdDepoTotal in dmdDepoTotalList)
                {
                    this._dmdDepoTotalList.Add(dmdDepoTotal.Clone());
                }
                // 2009.01.06 <<<

				// ��ʕ\��		
                DetailsDmdPrcToScreen(this._editCustDmdPrc);

				this._accRecIndexBuf  = -2;
				this._dmdPrcIndexBuf  = this._dmdPrcDataIndex;
                //this.TtlBl_Title_Label.Text         = "�����c��";     // 2009.01.06 Del
                this.SalesPaymInfo_Title_Label.Text = "����������";
            }

			// ���͎�t����
			ScreenInputPermissionControl_Date(_logicalDeleteMode == -1);
			ScreenInputPermissionControl_Details((_logicalDeleteMode == -1) || (_logicalDeleteMode == 0));
            ScreenInputPermissionControl_BillNo((_logicalDeleteMode == -1) || (_logicalDeleteMode == 0));  // ADD 2009/06/23

			// ���_�̋@�\���{�Ћ@�\�Ȃ�΋��_��ʕ\��
            ScreenInputPermissionControl_Section((Opt_Section == true));
			
			// �{�^���\���E��\��
			this.Cancel_Button.Visible = true;
			this.Ok_Button.Visible     = ((_logicalDeleteMode == -1)||(_logicalDeleteMode == 0));
			this.Delete_Button.Visible = (_logicalDeleteMode == 0);
			
			// ���[�h�E���̑��̃f�[�^��Ԃɂ�鍀�ڂ̕\���E��\��
			focusControl.Focus();
            if (focusControl is TEdit)
            {
                ((TEdit)focusControl).SelectAll();
            }
            if (focusControl is TNedit)
            {
                ((TNedit)focusControl).SelectAll();
            }

			// �N���������̏����i�[
            this._customerCodeBuf = customerRet.CustomerCode;
			this._targetTableBuf  = this._targetTableName;

            // ���㍇�v���z���x���̔��f
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                // 2009.01.06 >>>
                //DetailsAccRecToClaim_panel(this._editCustAccRec);
                // ������w�莞�͉�ʕ\�����z�̏W�v����\�����A���Ӑ�w�莞�͑ޔ����Ă���W�v���R�[�h����\������
                DetailsAccRecToClaim_panel(( this._targetDivType == 1 ) ? this._custAccRecTotal : this._editCustAccRec);
                // 2009.01.06 <<<
                getKinSetInfo_Acc(ref this._editCustAccRec);
                // �ӏ����Čv�Z(�I���W�i���f�[�^)
                // ��������s��Ȃ��ƕҏW���f�[�^�Ƃ̐��������Ƃ�Ȃ��Ȃ�A�ҏW���Ă��Ȃ��̂ɕҏW���Ƃ���邽��
                getKinSetInfo_Acc(ref this._custAccRecClone);
            }
            else
            {
                // 2009.01.06 >>>
                //DetailsDmdPrcToClaim_panel(this._editCustDmdPrc);
                // ������w�莞�͉�ʕ\�����z�̏W�v����\�����A���Ӑ�w�莞�͑ޔ����Ă���W�v���R�[�h����\������
                DetailsDmdPrcToClaim_panel(( this._targetDivType == 1 ) ? this._custDmdPrcTotal : this._editCustDmdPrc);
                // 2009.01.06 <<<
                getKinSetInfo_Dmd(ref this._editCustDmdPrc);
                // �ӏ����Čv�Z(�I���W�i���f�[�^)
                // ��������s��Ȃ��ƕҏW���f�[�^�Ƃ̐��������Ƃ�Ȃ��Ȃ�A�ҏW���Ă��Ȃ��̂ɕҏW���Ƃ���邽��
                getKinSetInfo_Dmd(ref this._custDmdPrcClone);
            }

            //TtlBl_Label.Text = Claim_panelDataFormat(this.custAccRec.AfCalTMonthAccRec + custAccRec.BalanceAdjust + custAccRec.TaxAdjust, true);
		}

		/// <summary>��ʂɔ��|���z���ݒ�</summary>
        /// <param name="custAccRec">���|���z���</param>
		/// <remarks>
		/// <br>Note       : ��ʂɔ��|���z����ݒ肵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsAccRecToScreen(CustAccRec custAccRec)
		{
			// �v����t
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (TDateTime.LongDateToDateTime(custAccRec.AddUpYearMonth) == DateTime.MinValue)
            if ( custAccRec.AddUpYearMonth == DateTime.MinValue )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                this.AddUpADate_tDateEdit.SetDateTime(DateTime.MinValue);
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.AddUpADate_tDateEdit.SetDateTime(TDateTime.LongDateToDateTime(custAccRec.AddUpDate));
                this.AddUpADate_tDateEdit.SetDateTime(custAccRec.AddUpDate);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            this.AddUpADate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;

            // �ӂɏ��𔽉f
            // 2009.01.06 >>>
            //DetailsAccRecToClaim_panel(custAccRec);
            // ������w�莞�͉�ʕ\�����z�̏W�v����\�����A���Ӑ�w�莞�͑ޔ����Ă���W�v���R�[�h����\������
            DetailsAccRecToClaim_panel(( this._targetDivType == 1 ) ? this._custAccRecTotal : custAccRec);
            // 2009.01.06 <<<
	
			// ----- �ڍ׏���ʍ��� -----
			// �O��c�����
            this.LMBl_tNedit.SetValue(custAccRec.LastTimeAccRec);
            this.Bf2TmBl_tNedit.SetValue(custAccRec.AcpOdrTtl2TmBfAccRec);
            this.Bf3TmBl_tNedit.SetValue(custAccRec.AcpOdrTtl3TmBfAccRec);

			// ����E�x�����
            // ����
            this.ItdedSalesOutTax_tNedit.SetValue(custAccRec.ItdedSalesOutTax);
            this.SalesOutTax_tNedit.SetValue(custAccRec.SalesOutTax);
            this.ItdedSalesInTax_tNedit.SetValue(custAccRec.ItdedSalesInTax);
            this.SalesInTax_tNedit.SetValue(custAccRec.SalesInTax);
            this.ItdedSalesTaxFree_tNedit.SetValue(custAccRec.ItdedSalesTaxFree);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �ԕi
            this.TtlItdedRetOutTax_tNedit.SetValue( -1 * custAccRec.TtlItdedRetOutTax );
            this.TtlRetOuterTax_tNedit.SetValue(-1 * custAccRec.TtlRetOuterTax);
            this.TtlItdedRetInTax_tNedit.SetValue( -1 * custAccRec.TtlItdedRetInTax );
            this.TtlRetInnerTax_tNedit.SetValue( -1 * custAccRec.TtlRetInnerTax );
            this.TtlItdedRetTaxFree_tNedit.SetValue( -1 * custAccRec.TtlItdedRetTaxFree );
            // �l��
            this.TtlItdedDisOutTax_tNedit.SetValue( -1 * custAccRec.TtlItdedDisOutTax );
            this.TtlDisOuterTax_tNedit.SetValue(-1 * custAccRec.TtlDisOuterTax);
            this.TtlItdedDisInTax_tNedit.SetValue( -1 * custAccRec.TtlItdedDisInTax );
            this.TtlDisInnerTax_tNedit.SetValue( -1 * custAccRec.TtlDisInnerTax );
            this.TtlItdedDisTaxFree_tNedit.SetValue( -1 * custAccRec.TtlItdedDisTaxFree );
            // �c������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            this.BalanceAdjust_tNedit.SetValue(custAccRec.BalanceAdjust);
            this.TaxAdjust_tNedit.SetValue(custAccRec.TaxAdjust);
            this.SaleslSlipCount_tNedit.SetValue(custAccRec.SalesSlipCount);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
            //// ����������z
            //this.ThisCashSalePrice_tNedit.SetValue(custAccRec.ThisCashSalePrice);
            //this.ThisCashSaleTax_tNedit.SetValue(custAccRec.ThisCashSaleTax);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // �����ϋ��z
            //this.NonStmntAppearance_tNedit.SetValue(custAccRec.NonStmntAppearance);
            //this.NonStmntIsdone_tNedit.SetValue(custAccRec.NonStmntIsdone);
            // ���ϋ��z
            //this.StmntAppearance_tNedit.SetValue(custAccRec.StmntAppearance);
            //this.StmntIsdone_tNedit.SetValue(custAccRec.StmntIsdone);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �x��
            //this.ItdedPaymOutTax_tNedit.SetValue(custAccRec.ItdedPaymOutTax);
            //this.PaymentOutTax_tNedit.SetValue(custAccRec.PaymentOutTax);
            //this.ItdedPaymInTax_tNedit.SetValue(custAccRec.ItdedPaymInTax);
            //this.PaymentInTax_tNedit.SetValue(custAccRec.PaymentInTax);
            //this.ItdedPaymTaxFree_tNedit.SetValue(custAccRec.ItdedPaymTaxFree);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �x��
            //this.ItdedPaymOutTax_tNedit.SetValue( -1 * custAccRec.ItdedPaymOutTax);
            //this.PaymentOutTax_tNedit.SetValue( -1 * custAccRec.PaymentOutTax );
            //this.ItdedPaymInTax_tNedit.SetValue( -1 * custAccRec.ItdedPaymInTax );
            //this.PaymentInTax_tNedit.SetValue( -1 * custAccRec.PaymentInTax );
            //this.ItdedPaymTaxFree_tNedit.SetValue( -1 * custAccRec.ItdedPaymTaxFree );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // 2009.01.06 Add >>>
            // ���E������
            this.OfsThisSalesTax_tNedit.SetValue(custAccRec.OfsThisSalesTax);
            this.OffsetOutTax_tNedit.SetValue(custAccRec.OffsetOutTax);
            // 2009.01.06 Add <<<

            // �������
            // �ʏ����
            //this.DepoNrml_tNedit.SetValue(custAccRec.ThisTimeDmdNrml);    // 2009.01.06 Del
            this.FeeNrml_tNedit.SetValue(custAccRec.ThisTimeFeeDmdNrml);
            this.DisNrml_tNedit.SetValue(custAccRec.ThisTimeDisDmdNrml);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.SetValue(custAccRec.ThisTimeRbtDmdNrml);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �a���
            //this.Depo_tNedit.SetValue(custAccRec.ThisTimeDmdDepo);
            //this.FeeDepo_tNedit.SetValue(custAccRec.ThisTimeFeeDmdDepo);
            //this.DisDepo_tNedit.SetValue(custAccRec.ThisTimeDisDmdDepo);
            //this.RbtDepo_tNedit.SetValue(custAccRec.ThisTimeRbtDmdDepo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �e���v���ɍ��v���z�𔽉f
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_ItdedOutTaxTotalLabel();     // �O�őΏۋ��z���v
            //update_OutTaxTotalLabel();          // �O�ŋ��z���v
            //update_ItdedInTaxTotalLabel();      // ���őΏۋ��z���v
            //update_InTaxTotalLabel();           // ���ŋ��z���v
            //update_ItdedTaxFreeTotalLabel();    // ��ېőΏۋ��z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_SalesTotalLabel();           // ����z���v
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_RetTotalLabel();             // �ԕi���z���v
            update_DisTotalLabel();             // �l�����z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_PaymTotalLabel();            // �x���z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoPrcTotalLabel();         // �������z���v
            //update_FeeTotalLabel();             // �萔���z���v
            //update_DisTotalLabel();             // �l���z���v
            //update_RbtTotalLabel();             // ���x�[�g�z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_NormalTotalLabel();          // �ʏ�������v
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoTotalLabel();            // �a������v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_ItdedPaymTotalLabel();   // �x�����z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            // ���E�㔄��O�őΏۊz���x���̔��f
            this.update_ItdedOffsetOutTaxLabel();
            // ���E���ېőΏۊz���x���̔��f
            this.update_ItdedOffsetTaxFreeLabel();
            // ���E�㔄�㍇�v���x���̔��f
            this.update_OfsThisTimeSalesTotalLabel();
            // �ō��ݍ��v���x���̔��f
            this.update_OfsThisTimeSalesTaxIncLabel();
            // �c�����v���x���̔��f
            this.update_BlTotalLabel();
            // 2009.01.06 Add <<<
		}

		/// <summary>�ӂɔ��|���z���ݒ�</summary>
        /// <param name="custAccRec">���|���z���</param>
		/// <remarks>
		/// <br>Note       : �Ӊ�ʂɔ��|���z����ݒ肵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsAccRecToClaim_panel(CustAccRec custAccRec)
		{
			// �ӂɏ��𔽉f
            // 2009.01.06 >>>
#if false
            // �O����
            this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(custAccRec.AcpOdrTtl3TmBfAccRec, true);
            this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(custAccRec.AcpOdrTtl2TmBfAccRec, true);
            this.TtlLMBl_Label.Text = Claim_panelDataFormat(custAccRec.LastTimeAccRec, true);

            this.TtlBf3TmBl_Label.Tag = custAccRec.AcpOdrTtl3TmBfAccRec;
            this.TtlBf2TmBl_Label.Tag = custAccRec.AcpOdrTtl2TmBfAccRec;
            this.TtlLMBl_Label.Tag = custAccRec.LastTimeAccRec;

            // ���񔄏�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.TtlSales_Label.Text   = Claim_panelDataFormat(custAccRec.ThisTimeSales, true);
            this.TtlSales_Label.Text = Claim_panelDataFormat(custAccRec.OfsThisTimeSales, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // �����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.TtlTax_Label.Text     = Claim_panelDataFormat(custAccRec.ThisSalesTax, true);
            this.TtlTax_Label.Text = Claim_panelDataFormat(custAccRec.OfsThisSalesTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ����x��
            //this.TtlPaym_Label.Text    = Claim_panelDataFormat(custAccRec.TtlIncDtbtTaxExc, true);
            //// �x�������
            //this.TtlPaymTax_Label.Text = Claim_panelDataFormat(custAccRec.TtlIncDtbtTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �������
            //Int64 DepoTotal = custAccRec.ThisTimeDmdNrml    +       // �ʏ�������z
            //                  custAccRec.ThisTimeFeeDmdNrml +       // �ʏ�萔���z
            //                  custAccRec.ThisTimeDisDmdNrml +       // �ʏ�l���z
            //                  custAccRec.ThisTimeRbtDmdNrml +       // �ʏ탊�x�[�g�z
            //                  custAccRec.ThisTimeDmdDepo    +       // �a����������z
            //                  custAccRec.ThisTimeFeeDmdDepo +       // �a����萔���z
            //                  custAccRec.ThisTimeDisDmdDepo +       // �a����l���z
            //                  custAccRec.ThisTimeRbtDmdDepo;        // �a������x�[�g�z
            //this.TtlDepo_Label.Text   = Claim_panelDataFormat(DepoTotal, true);

            // �������
            // 2008.11.25 modify start [8193]
            //Int64 DepoTotal = custAccRec.ThisTimeDmdNrml +       // �ʏ�������z
            //custAccRec.ThisTimeFeeDmdNrml +       // �ʏ�萔���z
            //custAccRec.ThisTimeDisDmdNrml ;       // �ʏ�l���z
            Int64 DepoTotal = custAccRec.ThisTimeDmdNrml;       // �ʏ�������z
            // 2008.11.25 modify end [8193]
            this.TtlDepo_Label.Text = Claim_panelDataFormat(DepoTotal, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            // �c�������z
            this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(custAccRec.BalanceAdjust + custAccRec.TaxAdjust, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

            // �c��
            this.TtlBl_Label.Text = Claim_panelDataFormat(custAccRec.AfCalTMonthAccRec, true);
            //this.TtlBl_Label.Text = Claim_panelDataFormat(custAccRec.AfCalTMonthAccRec + custAccRec.BalanceAdjust + custAccRec.TaxAdjust, true);
#endif
            DataRow row = this._totalDisplayTable.Rows[0];

            // �c�����
            row[BalanceDisplayTable.ct_Col_TOTAL3_BEF] = custAccRec.AcpOdrTtl3TmBfAccRec;
            row[BalanceDisplayTable.ct_Col_TOTAL2_BEF] = custAccRec.AcpOdrTtl2TmBfAccRec;
            row[BalanceDisplayTable.ct_Col_TOTAL1_BEF] = custAccRec.LastTimeAccRec;

            // ���񔄏�
            row[BalanceDisplayTable.ct_Col_THISTIMESALES] = custAccRec.OfsThisTimeSales;
            // �����
            row[BalanceDisplayTable.ct_Col_CONSTAX] = custAccRec.OfsThisSalesTax;
            // �������
            Int64 depoTotal = custAccRec.ThisTimeDmdNrml;       // �ʏ�������z
            row[BalanceDisplayTable.ct_Col_THISTIMEDEPO] = depoTotal;

            // �c��
            row[BalanceDisplayTable.ct_Col_ACCRECBLNCE] = custAccRec.AfCalTMonthAccRec;
            // 2009.01.06 <<<
        }

		/// <summary>��ʂɐ������z���ݒ�</summary>
        /// <param name="custDmdPrc">�������z���</param>
		/// <remarks>
		/// <br>Note       : ��ʂɐ������z����ݒ肵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsDmdPrcToScreen(CustDmdPrc custDmdPrc)
		{
			// �v����t
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (TDateTime.LongDateToDateTime(custDmdPrc.AddUpDate) == DateTime.MinValue)
            if ( custDmdPrc.AddUpDate == DateTime.MinValue )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                this.AddUpADate_tDateEdit.SetDateTime(DateTime.MinValue);
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.AddUpADate_tDateEdit.SetDateTime(TDateTime.LongDateToDateTime(custDmdPrc.AddUpDate));
                this.AddUpADate_tDateEdit.SetDateTime(custDmdPrc.AddUpDate);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
			this.AddUpADate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;

            // ADD 2009/06/23 ------>>>
            // ������No
            this.BillNo_tNedit.SetInt(custDmdPrc.BillNo);
            // ADD 2009/06/23 ------<<<

			// �ӂɏ��𔽉f
            // 2009.01.06 >>>
            //DetailsDmdPrcToClaim_panel(custDmdPrc);
            // ������w�莞�͉�ʕ\�����z�̏W�v����\�����A���Ӑ�w�莞�͑ޔ����Ă���W�v���R�[�h����\������
            DetailsDmdPrcToClaim_panel(( this._targetDivType == 1 ) ? this._custDmdPrcTotal : custDmdPrc);
            // 2009.01.06 <<<

	
			// ----- �ڍ׏���ʍ��� -----
			// �O��c�����
            this.LMBl_tNedit.SetValue(custDmdPrc.LastTimeDemand);
            this.Bf2TmBl_tNedit.SetValue(custDmdPrc.AcpOdrTtl2TmBfBlDmd);
            this.Bf3TmBl_tNedit.SetValue(custDmdPrc.AcpOdrTtl3TmBfBlDmd);

			// ����E�x�����
            // ����
            this.ItdedSalesOutTax_tNedit.SetValue(custDmdPrc.ItdedSalesOutTax);
            this.SalesOutTax_tNedit.SetValue(custDmdPrc.SalesOutTax);
            this.ItdedSalesInTax_tNedit.SetValue(custDmdPrc.ItdedSalesInTax);
            this.SalesInTax_tNedit.SetValue(custDmdPrc.SalesInTax);
            this.ItdedSalesTaxFree_tNedit.SetValue(custDmdPrc.ItdedSalesTaxFree);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �ԕi
            this.TtlItdedRetOutTax_tNedit.SetValue( -1 * custDmdPrc.TtlItdedRetOutTax );
            this.TtlRetOuterTax_tNedit.SetValue( -1 * custDmdPrc.TtlRetOuterTax );
            this.TtlItdedRetInTax_tNedit.SetValue( -1 * custDmdPrc.TtlItdedRetInTax );
            this.TtlRetInnerTax_tNedit.SetValue( -1 * custDmdPrc.TtlRetInnerTax );
            this.TtlItdedRetTaxFree_tNedit.SetValue( -1 * custDmdPrc.TtlItdedRetTaxFree );
            // �l��
            this.TtlItdedDisOutTax_tNedit.SetValue( -1 * custDmdPrc.TtlItdedDisOutTax );
            this.TtlDisOuterTax_tNedit.SetValue( -1 * custDmdPrc.TtlDisOuterTax );
            this.TtlItdedDisInTax_tNedit.SetValue( -1 * custDmdPrc.TtlItdedDisInTax );
            this.TtlDisInnerTax_tNedit.SetValue( -1 * custDmdPrc.TtlDisInnerTax );
            this.TtlItdedDisTaxFree_tNedit.SetValue( -1 * custDmdPrc.TtlItdedDisTaxFree );
            // �c������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            //this.BalanceAdjust_tNedit.SetValue(custDmdPrc.BalanceAdjust);
            this.BalanceAdjust_tNedit.SetValue(custDmdPrc.BalanceAdjust);
            this.TaxAdjust_tNedit.SetValue(custDmdPrc.TaxAdjust);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

            //// ����������z (�N���A����)
            //this.ThisCashSalePrice_tNedit.Clear();
            //this.ThisCashSaleTax_tNedit.Clear();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // �����ϋ��z (�N���A����)
            //this.NonStmntAppearance_tNedit.Clear();
            //this.NonStmntIsdone_tNedit.Clear();
            // ���ϋ��z (�N���A����)
            //this.StmntAppearance_tNedit.Clear();
            //this.StmntIsdone_tNedit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �x��
            //this.ItdedPaymOutTax_tNedit.SetValue(custDmdPrc.ItdedPaymOutTax);
            //this.PaymentOutTax_tNedit.SetValue(custDmdPrc.PaymentOutTax);
            //this.ItdedPaymInTax_tNedit.SetValue(custDmdPrc.ItdedPaymInTax);
            //this.PaymentInTax_tNedit.SetValue(custDmdPrc.PaymentInTax);
            //this.ItdedPaymTaxFree_tNedit.SetValue(custDmdPrc.ItdedPaymTaxFree);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �x��
            //this.ItdedPaymOutTax_tNedit.SetValue( -1 * custDmdPrc.ItdedPaymOutTax );
            //this.PaymentOutTax_tNedit.SetValue( -1 * custDmdPrc.PaymentOutTax );
            //this.ItdedPaymInTax_tNedit.SetValue( -1 * custDmdPrc.ItdedPaymInTax );
            //this.PaymentInTax_tNedit.SetValue( -1 * custDmdPrc.PaymentInTax );
            //this.ItdedPaymTaxFree_tNedit.SetValue( -1 * custDmdPrc.ItdedPaymTaxFree );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // 2009.01.06 Add >>>
            // ���E�����ł��Z�b�g
            this.OfsThisSalesTax_tNedit.SetValue(custDmdPrc.OfsThisSalesTax);
            this.OffsetOutTax_tNedit.SetValue(custDmdPrc.OffsetOutTax);
            // 2009.01.06 Add <<<

            // �������
            // �ʏ����
            //this.DepoNrml_tNedit.SetValue(custDmdPrc.ThisTimeDmdNrml);        // 2009.01.06 Del
            this.FeeNrml_tNedit.SetValue(custDmdPrc.ThisTimeFeeDmdNrml);
            this.DisNrml_tNedit.SetValue(custDmdPrc.ThisTimeDisDmdNrml);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.SetValue(custDmdPrc.ThisTimeRbtDmdNrml);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �a���
            //this.Depo_tNedit.SetValue(custDmdPrc.ThisTimeDmdDepo);
            //this.FeeDepo_tNedit.SetValue(custDmdPrc.ThisTimeFeeDmdDepo);
            //this.DisDepo_tNedit.SetValue(custDmdPrc.ThisTimeDisDmdDepo);
            //this.RbtDepo_tNedit.SetValue(custDmdPrc.ThisTimeRbtDmdDepo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ����`�[����
            this.SaleslSlipCount_tNedit.SetValue(custDmdPrc.SalesSlipCount);

            // ���������s��
            this.BillPrintDate_tDateEdit.SetDateTime( custDmdPrc.BillPrintDate );

            // �����\���
            this.ExpectedDepositDate_tDateEdit.SetDateTime(custDmdPrc.ExpectedDepositDate);
            
            // �������
            if (custDmdPrc.CollectCond == 0) {
                // ���Ӑ�}�X�^�Q��
                CustomerInfo customerInfo;
                this._customerInfoAcs.ReadCacheMemoryData(out customerInfo, this._enterpriseCode, this._targetCustomerCode);
                custDmdPrc.CollectCond = customerInfo.CollectCond;
            }
            // 2009.01.06 >>>
            //this.CollectCond_Label.Text = CustomerInfo.GetCollectCondName(custDmdPrc.CollectCond);
            this.CollectCond_Label.Text = this._custAccRecDmdPrcAcs.GetDepsitStKindNm(this._enterpriseCode, custDmdPrc.CollectCond);
            // 2009.01.06 <<<
            this.CollectCondValue_tNedit.SetValue(custDmdPrc.CollectCond);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �e���v���ɍ��v���z�𔽉f
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_ItdedOutTaxTotalLabel();     // �O�őΏۋ��z���v
            //update_OutTaxTotalLabel();          // �O�ŋ��z���v
            //update_ItdedInTaxTotalLabel();      // ���őΏۋ��z���v
            //update_InTaxTotalLabel();           // ���ŋ��z���v
            //update_ItdedTaxFreeTotalLabel();    // ��ېőΏۋ��z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_SalesTotalLabel();           // ����z���v
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_RetTotalLabel();             // �ԕi���z���v
            update_DisTotalLabel();             // �l�����z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_PaymTotalLabel();            // �x���z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoPrcTotalLabel();         // �������z���v
            //update_FeeTotalLabel();             // �萔���z���v
            //update_DisTotalLabel();             // �l���z���v
            //update_RbtTotalLabel();             // ���x�[�g�z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_NormalTotalLabel();          // �ʏ�������v
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoTotalLabel();            // �a������v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_ItdedPaymTotalLabel();       // �x�����z���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            // ���E�㔄��O�őΏۊz���x���̔��f
            this.update_ItdedOffsetOutTaxLabel();
            // ���E���ېőΏۊz���x���̔��f
            this.update_ItdedOffsetTaxFreeLabel();
            // ���E�㔄�㍇�v���x���̔��f
            this.update_OfsThisTimeSalesTotalLabel();
            // �ō��ݍ��v���x���̔��f
            this.update_OfsThisTimeSalesTaxIncLabel();
            // �c�����v���x���̔��f
            this.update_BlTotalLabel();
            // 2009.01.06 Add <<<
        }

        /// <summary>�Ӊ�ʂɐ������z���ݒ�</summary>
        /// <param name="custDmdPrc">�������z���</param>
		/// <remarks>
		/// <br>Note       : �Ӊ�ʂɐ������z����ݒ肵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsDmdPrcToClaim_panel(CustDmdPrc custDmdPrc)
		{
			// �ӂɏ��𔽉f
            // 2009.01.06 >>>
#if false
            // �O����
            this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AcpOdrTtl3TmBfBlDmd, true);
            this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AcpOdrTtl2TmBfBlDmd, true);
            this.TtlLMBl_Label.Text = Claim_panelDataFormat(custDmdPrc.LastTimeDemand, true);

            this.TtlBf3TmBl_Label.Tag = custDmdPrc.AcpOdrTtl3TmBfBlDmd;
            this.TtlBf2TmBl_Label.Tag = custDmdPrc.AcpOdrTtl2TmBfBlDmd;
            this.TtlLMBl_Label.Tag = custDmdPrc.LastTimeDemand;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ���񔄏�
            //this.TtlSales_Label.Text   = Claim_panelDataFormat(custDmdPrc.ThisTimeSales, true);
            //// �����
            //this.TtlTax_Label.Text     = Claim_panelDataFormat(custDmdPrc.ThisSalesTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ���񔄏�
            this.TtlSales_Label.Text = Claim_panelDataFormat(custDmdPrc.OfsThisTimeSales, true);
            // �����
            this.TtlTax_Label.Text = Claim_panelDataFormat(custDmdPrc.OfsThisSalesTax, true);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ����x��
            //this.TtlPaym_Label.Text    = Claim_panelDataFormat(custDmdPrc.TtlIncDtbtTaxExc, true);
            //// �x�������
            //this.TtlPaymTax_Label.Text = Claim_panelDataFormat(custDmdPrc.TtlIncDtbtTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �������
            //Int64 DepoTotal = custDmdPrc.ThisTimeDmdNrml    +       // �ʏ�������z
            //                  custDmdPrc.ThisTimeFeeDmdNrml +       // �ʏ�萔���z
            //                  custDmdPrc.ThisTimeDisDmdNrml +       // �ʏ�l���z
            //                  custDmdPrc.ThisTimeRbtDmdNrml +       // �ʏ탊�x�[�g�z
            //                  custDmdPrc.ThisTimeDmdDepo    +       // �a����������z
            //                  custDmdPrc.ThisTimeFeeDmdDepo +       // �a����萔���z
            //                  custDmdPrc.ThisTimeDisDmdDepo +       // �a����l���z
            //                  custDmdPrc.ThisTimeRbtDmdDepo;        // �a������x�[�g�z
            //this.TtlDepo_Label.Text   = Claim_panelDataFormat(DepoTotal, true);
            // �������
            // 2008.11.25 modify start [8193]
            //Int64 DepoTotal = custDmdPrc.ThisTimeDmdNrml +       // �ʏ�������z
            //custDmdPrc.ThisTimeFeeDmdNrml +       // �ʏ�萔���z
            //custDmdPrc.ThisTimeDisDmdNrml;       // �ʏ�l���z
            Int64 DepoTotal = custDmdPrc.ThisTimeDmdNrml;       // �ʏ�������z
            // 2008.11.25 modify end [8193]
            this.TtlDepo_Label.Text = Claim_panelDataFormat(DepoTotal, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            // �c������
            //this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(custDmdPrc.BalanceAdjust,true);
            this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(custDmdPrc.BalanceAdjust + custDmdPrc.TaxAdjust, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // �c��
            this.TtlBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AfCalDemandPrice, true);
            //this.TtlBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AfCalDemandPrice + custDmdPrc.BalanceAdjust + custDmdPrc.TaxAdjust, true);
#endif
            DataRow row = this._totalDisplayTable.Rows[0];

            // �c�����
            row[BalanceDisplayTable.ct_Col_TOTAL3_BEF] = custDmdPrc.AcpOdrTtl3TmBfBlDmd;
            row[BalanceDisplayTable.ct_Col_TOTAL2_BEF] = custDmdPrc.AcpOdrTtl2TmBfBlDmd;
            row[BalanceDisplayTable.ct_Col_TOTAL1_BEF] = custDmdPrc.LastTimeDemand;

            // ���񔄏�
            row[BalanceDisplayTable.ct_Col_THISTIMESALES] = custDmdPrc.OfsThisTimeSales;
            // �����
            row[BalanceDisplayTable.ct_Col_CONSTAX] = custDmdPrc.OfsThisSalesTax;
            // �������
            Int64 depoTotal = custDmdPrc.ThisTimeDmdNrml;       // �ʏ�������z
            row[BalanceDisplayTable.ct_Col_THISTIMEDEPO] = depoTotal;

            // �c��
            row[BalanceDisplayTable.ct_Col_ACCRECBLNCE] = custDmdPrc.AfCalDemandPrice;
            // 2009.01.06 <<<
		}

        /// <summary>�Ӊ�ʂ̍Čv�Z����</summary>
		/// <remarks>
		/// <br>Note       : ���͂��ꂽ���ڂŊӏ����Čv�Z���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void upDateClaim_PanelTextData()
		{
			// ���|
			if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
                CustAccRec custAccRec = this._editCustAccRec;
                ScreenToCustAccRec(ref custAccRec);
                getKinSetInfo_Acc(ref custAccRec);
                // �����݂ɏ��𔽉f����
                // 2009.01.06 >>>
                //DetailsAccRecToClaim_panel(custAccRec);
                // ������w�莞�͉�ʕ\�����z�̏W�v����\�����A���Ӑ�w�莞�͑ޔ����Ă���W�v���R�[�h����\������
                DetailsAccRecToClaim_panel(( this._targetDivType == 1 ) ? this._custAccRecTotal : custAccRec);

                // 2009.01.06 <<<
            }
			else
			{
                CustDmdPrc custDmdPrc = this._editCustDmdPrc;
                ScreenToCustDmdPrc(ref custDmdPrc);
                getKinSetInfo_Dmd(ref custDmdPrc);
                // �����݂ɏ��𔽉f����
                // 2009.01.06 >>>
                //DetailsDmdPrcToClaim_panel(custDmdPrc);
                // ������w�莞�͉�ʕ\�����z�̏W�v����\�����A���Ӑ�w�莞�͑ޔ����Ă���W�v���R�[�h����\������
                DetailsDmdPrcToClaim_panel(( this._targetDivType == 1 ) ? this._custDmdPrcTotal : custDmdPrc);
                // 2009.01.06 <<<
			}
		}

		/// <summary>���|���zKINSET����</summary>
		/// <param name="custAccRec">���|���z���</param>
		/// <remarks>
		/// <br>Note       : ���|���z��KINSET���������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void getKinSetInfo_Acc(ref CustAccRec custAccRec)
		{
            // 2009.01.06 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////Int64 TotalDepo = custAccRec.ThisTimeDmdNrml    +
            ////                  custAccRec.ThisTimeFeeDmdNrml +
            ////                  custAccRec.ThisTimeDisDmdNrml +
            ////                  custAccRec.ThisTimeRbtDmdNrml +
            ////                  custAccRec.ThisTimeDmdDepo    +
            ////                  custAccRec.ThisTimeFeeDmdDepo +
            ////                  custAccRec.ThisTimeDisDmdDepo +
            ////                  custAccRec.ThisTimeRbtDmdDepo;

            //Int64 TotalDepo = custAccRec.ThisTimeDmdNrml +
            //                  custAccRec.ThisTimeFeeDmdNrml +
            //                  custAccRec.ThisTimeDisDmdNrml ;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            Int64 TotalDepo = custAccRec.ThisTimeDmdNrml;       // �������v�͍���������z�����̂܂܎g�p����
            // 2009.01.06 <<<

            // 2008.11.21 modify start [8039]
            //custAccRec.ThisTimeTtlBlcAcc    = custAccRec.LastTimeAccRec - TotalDepo;
            custAccRec.ThisTimeTtlBlcAcc = custAccRec.LastTimeAccRec + custAccRec.AcpOdrTtl2TmBfAccRec + custAccRec.AcpOdrTtl3TmBfAccRec - TotalDepo;
            // 2008.11.21 modify end [8039]
            custAccRec.ThisTimeSales        = custAccRec.ItdedSalesOutTax +
                                              custAccRec.ItdedSalesInTax  +
                                              custAccRec.ItdedSalesTaxFree;
            custAccRec.ThisSalesTax         = custAccRec.SalesOutTax + custAccRec.SalesInTax;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custAccRec.ThisSalesPricRgds    = custAccRec.TtlItdedRetOutTax +
                                              custAccRec.TtlItdedRetInTax +
                                              custAccRec.TtlItdedRetTaxFree;
            custAccRec.ThisSalesPrcTaxRgds  = custAccRec.TtlRetOuterTax + custAccRec.TtlRetInnerTax;
            custAccRec.ThisSalesPricDis     = custAccRec.TtlItdedDisOutTax +
                                              custAccRec.TtlItdedDisInTax +
                                              custAccRec.TtlItdedDisTaxFree;
            custAccRec.ThisSalesPrcTaxDis   = custAccRec.TtlDisOuterTax + custAccRec.TtlDisInnerTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.TtlIncDtbtTaxExc     = custAccRec.ItdedPaymOutTax +
            //                                  custAccRec.ItdedPaymInTax  +
            //                                  custAccRec.ItdedPaymTaxFree;
            //custAccRec.TtlIncDtbtTax        = custAccRec.PaymentOutTax + custAccRec.PaymentInTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.ItdedOffsetOutTax = custAccRec.ItdedSalesOutTax - custAccRec.ItdedPaymOutTax;
            //custAccRec.ItdedOffsetInTax = custAccRec.ItdedSalesInTax - custAccRec.ItdedPaymInTax;
            //custAccRec.ItdedOffsetTaxFree   = custAccRec.ItdedSalesTaxFree - custAccRec.ItdedPaymTaxFree;
            //custAccRec.OffsetOutTax         = custAccRec.SalesOutTax       - custAccRec.PaymentOutTax;
            //custAccRec.OffsetInTax          = custAccRec.SalesInTax        - custAccRec.PaymentInTax;
            custAccRec.ItdedOffsetOutTax = custAccRec.ItdedSalesOutTax
                                           + custAccRec.TtlItdedDisOutTax
                                           + custAccRec.TtlItdedRetOutTax;
                                           //+ custAccRec.ItdedPaymOutTax;
            custAccRec.ItdedOffsetInTax = custAccRec.ItdedSalesInTax
                                          + custAccRec.TtlItdedDisInTax
                                          + custAccRec.TtlItdedRetInTax;
                                          //+ custAccRec.ItdedPaymInTax;
            custAccRec.ItdedOffsetTaxFree = custAccRec.ItdedSalesTaxFree
                                            + custAccRec.TtlItdedDisTaxFree
                                            + custAccRec.TtlItdedRetTaxFree;
                                            //+ custAccRec.ItdedPaymTaxFree;
            // 2009.01.06 Del >>>
            //custAccRec.OffsetOutTax = custAccRec.SalesOutTax
            //                          + custAccRec.TtlDisOuterTax
            //                          + custAccRec.TtlRetOuterTax;
            //                          //+ custAccRec.PaymentOutTax;
            // 2009.01.06 Del <<<
            custAccRec.OffsetInTax = custAccRec.SalesInTax
                                     + custAccRec.TtlDisInnerTax
                                     + custAccRec.TtlRetInnerTax;
                                     //+ custAccRec.PaymentInTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custAccRec.OfsThisTimeSales = custAccRec.ItdedOffsetOutTax
                                              + custAccRec.ItdedOffsetInTax
                                              + custAccRec.ItdedOffsetTaxFree;
                                              //+ custAccRec.ThisSalesPricRgds
                                              //+ custAccRec.ThisSalesPricDis;
                                              //+ custAccRec.ThisCashSalePrice;
            // 2009.01.06 Del >>>
            //custAccRec.OfsThisSalesTax = custAccRec.OffsetOutTax
            //                                + custAccRec.OffsetInTax;
            //                                //+ custAccRec.ThisSalesPrcTaxRgds
            //                                //+ custAccRec.ThisSalesPrcTaxDis;
            //                                //+ custAccRec.ThisCashSaleTax;
            // 2009.01.06 Del <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.AfCalTMonthAccRec    = custAccRec.ThisTimeTtlBlcAcc +
            //                                  custAccRec.OfsThisTimeSales  +
            //                                  custAccRec.OfsThisSalesTax;
            // 2008.10.06
            custAccRec.AfCalTMonthAccRec = custAccRec.ThisTimeTtlBlcAcc
                                              + custAccRec.OfsThisTimeSales
                                              + custAccRec.OfsThisSalesTax
                                              + custAccRec.BalanceAdjust
                                              + custAccRec.TaxAdjust;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>�������zKINSET����</summary>
		/// <param name="custDmdPrc">�������z���</param>
		/// <remarks>
		/// <br>Note       : �������z��KINSET���������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private  void getKinSetInfo_Dmd(ref CustDmdPrc custDmdPrc)
		{
            // 2009.01.06 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////Int64 TotalDepo = custDmdPrc.ThisTimeDmdNrml    +
            ////                  custDmdPrc.ThisTimeFeeDmdNrml +
            ////                  custDmdPrc.ThisTimeDisDmdNrml +
            ////                  custDmdPrc.ThisTimeRbtDmdNrml +
            ////                  custDmdPrc.ThisTimeDmdDepo    +
            ////                  custDmdPrc.ThisTimeFeeDmdDepo +
            ////                  custDmdPrc.ThisTimeDisDmdDepo +
            ////                  custDmdPrc.ThisTimeRbtDmdDepo;
            //Int64 TotalDepo = custDmdPrc.ThisTimeDmdNrml +
            //                  custDmdPrc.ThisTimeFeeDmdNrml +
            //                  custDmdPrc.ThisTimeDisDmdNrml ;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            Int64 TotalDepo = custDmdPrc.ThisTimeDmdNrml;   // �������v�͍���������z�����̂܂܎g�p����
            // 2009.01.06 <<<

            // 2008.11.21 modify start [8039]
            //custDmdPrc.ThisTimeTtlBlcDmd    = custDmdPrc.LastTimeDemand - TotalDepo;
            custDmdPrc.ThisTimeTtlBlcDmd = custDmdPrc.LastTimeDemand + custDmdPrc.AcpOdrTtl2TmBfBlDmd + custDmdPrc.AcpOdrTtl3TmBfBlDmd - TotalDepo;
            // 2008.11.21 modify end [8039]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custDmdPrc.ThisTimeSales = custDmdPrc.ItdedSalesOutTax +
                                       custDmdPrc.ItdedSalesInTax +
                                       custDmdPrc.ItdedSalesTaxFree;
            custDmdPrc.ThisSalesTax = custDmdPrc.SalesOutTax + custDmdPrc.SalesInTax;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.TtlIncDtbtTaxExc     = custDmdPrc.ItdedPaymOutTax +
            //                                  custDmdPrc.ItdedPaymInTax  +
            //                                  custDmdPrc.ItdedPaymTaxFree;
            //custDmdPrc.TtlIncDtbtTax        = custDmdPrc.PaymentOutTax + custDmdPrc.PaymentInTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.ItdedOffsetOutTax = custDmdPrc.ItdedSalesOutTax - custDmdPrc.ItdedPaymOutTax;
            //custDmdPrc.ItdedOffsetInTax     = custDmdPrc.ItdedSalesInTax   - custDmdPrc.ItdedPaymInTax;
            //custDmdPrc.ItdedOffsetTaxFree   = custDmdPrc.ItdedSalesTaxFree - custDmdPrc.ItdedPaymTaxFree;
            //custDmdPrc.OffsetOutTax         = custDmdPrc.SalesOutTax       - custDmdPrc.PaymentOutTax;
            //custDmdPrc.OffsetInTax          = custDmdPrc.SalesInTax        - custDmdPrc.PaymentInTax;
            custDmdPrc.ItdedOffsetOutTax = custDmdPrc.ItdedSalesOutTax
                                           + custDmdPrc.TtlItdedDisOutTax
                                           + custDmdPrc.TtlItdedRetOutTax;
                                           //+ custDmdPrc.ItdedPaymOutTax;
            custDmdPrc.ItdedOffsetInTax = custDmdPrc.ItdedSalesInTax
                                          + custDmdPrc.TtlItdedDisInTax
                                          + custDmdPrc.TtlItdedRetInTax;
                                          //+ custDmdPrc.ItdedPaymInTax;
            custDmdPrc.ItdedOffsetTaxFree = custDmdPrc.ItdedSalesTaxFree
                                            + custDmdPrc.TtlItdedDisTaxFree
                                            + custDmdPrc.TtlItdedRetTaxFree;
                                            //+ custDmdPrc.ItdedPaymTaxFree;
            // 2009.01.06 Del >>>
            //custDmdPrc.OffsetOutTax = custDmdPrc.SalesOutTax
            //                          + custDmdPrc.TtlDisOuterTax
            //                          + custDmdPrc.TtlRetOuterTax;
            //                          //+ custDmdPrc.PaymentOutTax;
            // 2009.01.06 Del <<<
            custDmdPrc.OffsetInTax = custDmdPrc.SalesInTax
                                     + custDmdPrc.TtlDisInnerTax
                                     + custDmdPrc.TtlRetInnerTax;
                                     //+ custDmdPrc.PaymentInTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custDmdPrc.OfsThisTimeSales     = custDmdPrc.ItdedOffsetOutTax +
                                              custDmdPrc.ItdedOffsetInTax  +
                                              custDmdPrc.ItdedOffsetTaxFree;
            // 2009.01.06 Del >>>
            //custDmdPrc.OfsThisSalesTax      = custDmdPrc.OffsetOutTax +
            //                                  custDmdPrc.OffsetInTax;
            // 2009.01.06 Del <<<
            custDmdPrc.AfCalDemandPrice = custDmdPrc.ThisTimeTtlBlcDmd
                                        + custDmdPrc.OfsThisTimeSales
                                        + custDmdPrc.OfsThisSalesTax//;// +
                                        + custDmdPrc.BalanceAdjust
                                        + custDmdPrc.TaxAdjust;// +
                                              //custDmdPrc.OfsThisSalesTax;

            // 2011/11/08 Add >>>
            custDmdPrc.ThisSalesPricRgds = custDmdPrc.TtlItdedRetOutTax +
                                              custDmdPrc.TtlItdedRetInTax +
                                              custDmdPrc.TtlItdedRetTaxFree;
            custDmdPrc.ThisSalesPrcTaxRgds = custDmdPrc.TtlRetOuterTax + custDmdPrc.TtlRetInnerTax;

            custDmdPrc.ThisSalesPricDis = custDmdPrc.TtlItdedDisOutTax +
                                              custDmdPrc.TtlItdedDisInTax +
                                              custDmdPrc.TtlItdedDisTaxFree;
            custDmdPrc.ThisSalesPrcTaxDis = custDmdPrc.TtlDisOuterTax + custDmdPrc.TtlDisInnerTax;
            // 2011/11/08 Add <<<
        }

		/// <summary>��ʏ��𔄊|���z�ɔ��f����</summary>
		/// <param name="custAccRec">���|���z���</param>
		/// <remarks>
		/// <br>Note       : ��ʍ��ڏ��𔄊|���z�ɐݒ肵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void ScreenToCustAccRec(ref CustAccRec custAccRec)
		{
            custAccRec.EnterpriseCode       = this._enterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ���Ӑ�
            custAccRec.CustomerCode = Int32.Parse(this.customerCode_Label.Text);
            custAccRec.CustomerName = this.CustomerName_Label.Text;
            custAccRec.CustomerName2 = this.CustomerName2_Label.Text;
            custAccRec.CustomerSnm = this.CustomerSnm_Label.Text;
            // ������
            custAccRec.ClaimCode = Int32.Parse(this.claimCode_Label.Text);
            custAccRec.ClaimName = this.ClaimName_Label.Text;
            custAccRec.ClaimName2 = this.ClaimName2_Label.Text;
            custAccRec.ClaimSnm = this.ClaimSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// �v����t
			if ( this.AddUpADate_tDateEdit.Enabled == true )
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //custAccRec.AddUpYearMonth = this.AddUpADate_tDateEdit.GetLongDate();
                //custAccRec.AddUpDate      = this.AddUpADate_tDateEdit.GetLongDate();
                custAccRec.AddUpYearMonth = this.AddUpADate_tDateEdit.GetDateTime();
                custAccRec.AddUpDate = this.AddUpADate_tDateEdit.GetDateTime();                
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
			// ����
			custAccRec.ItdedSalesOutTax     = (Int64)this.ItdedSalesOutTax_tNedit.GetValue();
			custAccRec.SalesOutTax          = (Int64)this.SalesOutTax_tNedit.GetValue();
            custAccRec.ItdedSalesInTax      = (Int64)this.ItdedSalesInTax_tNedit.GetValue();
            custAccRec.SalesInTax           = (Int64)this.SalesInTax_tNedit.GetValue();
            custAccRec.ItdedSalesTaxFree    = (Int64)this.ItdedSalesTaxFree_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �ԕi
            custAccRec.TtlItdedRetOutTax = -1 * (Int64)this.TtlItdedRetOutTax_tNedit.GetValue();
            custAccRec.TtlRetOuterTax = -1 * (Int64)this.TtlRetOuterTax_tNedit.GetValue();
            custAccRec.TtlItdedRetInTax = -1 * (Int64)this.TtlItdedRetInTax_tNedit.GetValue();
            custAccRec.TtlRetInnerTax = -1 * (Int64)this.TtlRetInnerTax_tNedit.GetValue();
            custAccRec.TtlItdedRetTaxFree = -1 * (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue();
            // �l��
            custAccRec.TtlItdedDisOutTax = -1 * (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();
            custAccRec.TtlDisOuterTax = -1 * (Int64)this.TtlDisOuterTax_tNedit.GetValue();
            custAccRec.TtlItdedDisInTax = -1 * (Int64)this.TtlItdedDisInTax_tNedit.GetValue();
            custAccRec.TtlDisInnerTax = -1 * (Int64)this.TtlDisInnerTax_tNedit.GetValue();
            custAccRec.TtlItdedDisTaxFree = -1 * (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();
            // �c������
            custAccRec.BalanceAdjust        = (Int64)this.BalanceAdjust_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            custAccRec.TaxAdjust = (Int64)this.TaxAdjust_tNedit.GetValue();
            custAccRec.SalesSlipCount = (Int32)this.SaleslSlipCount_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // �����ϋ��z
            //custAccRec.NonStmntAppearance   = (Int64)this.NonStmntAppearance_tNedit.GetValue();
            //custAccRec.NonStmntIsdone       = (Int64)this.NonStmntIsdone_tNedit.GetValue();
            // ���ϋ��z
            //custAccRec.StmntAppearance      = (Int64)this.StmntAppearance_tNedit.GetValue();
            //custAccRec.StmntIsdone          = (Int64)this.StmntIsdone_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //// ��������
            //custAccRec.ThisCashSalePrice    = (Int64)this.ThisCashSalePrice_tNedit.GetValue();
            //custAccRec.ThisCashSaleTax      = (Int64)this.ThisCashSaleTax_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �x��
            //custAccRec.ItdedPaymOutTax      = (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //custAccRec.PaymentOutTax        = (Int64)this.PaymentOutTax_tNedit.GetValue();
            //custAccRec.ItdedPaymInTax       = (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //custAccRec.PaymentInTax         = (Int64)this.PaymentInTax_tNedit.GetValue();
            //custAccRec.ItdedPaymTaxFree     = (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // ����
            //custAccRec.ThisTimeDmdNrml      = (Int64)this.DepoNrml_tNedit.GetValue();     // 2009.01.06 Del
            custAccRec.ThisTimeFeeDmdNrml = (Int64)this.FeeNrml_tNedit.GetValue();
			custAccRec.ThisTimeDisDmdNrml   = (Int64)this.DisNrml_tNedit.GetValue();
            // 2009.01.06 Add >>>
            object value = this._depositDataTable.Compute(string.Format("SUM({0})", DepositRelDataAcs.ctDeposit), string.Empty);
            Int64 total = ( value is DBNull ) ? 0 : (Int64)value;
            custAccRec.ThisTimeDmdNrml = total + custAccRec.ThisTimeFeeDmdNrml + custAccRec.ThisTimeDisDmdNrml;

            // ���E���񔄏�����
            custAccRec.OfsThisSalesTax = (Int64)this.OfsThisSalesTax_tNedit.GetValue();
            custAccRec.OffsetOutTax = (Int64)this.OffsetOutTax_tNedit.GetValue();

            // 2009.01.06 Add <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.ThisTimeRbtDmdNrml   = (Int64)this.RbtNrml_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.ThisTimeDmdDepo      = (Int64)this.Depo_tNedit.GetValue();
            //custAccRec.ThisTimeFeeDmdDepo   = (Int64)this.FeeDepo_tNedit.GetValue();
            //custAccRec.ThisTimeDisDmdDepo   = (Int64)this.DisDepo_tNedit.GetValue();
            //custAccRec.ThisTimeRbtDmdDepo   = (Int64)this.RbtDepo_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // �x��
            //custAccRec.ItdedPaymOutTax = -1 * (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //custAccRec.PaymentOutTax = -1 * (Int64)this.PaymentOutTax_tNedit.GetValue();
            //custAccRec.ItdedPaymInTax = -1 * (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //custAccRec.PaymentInTax = -1 * (Int64)this.PaymentInTax_tNedit.GetValue();
            //custAccRec.ItdedPaymTaxFree = -1 * (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

			// �����ݏ��
			// �O����
			custAccRec.AcpOdrTtl3TmBfAccRec = (Int64)Bf3TmBl_tNedit.GetValue();
			custAccRec.AcpOdrTtl2TmBfAccRec = (Int64)Bf2TmBl_tNedit.GetValue(); 
			custAccRec.LastTimeAccRec       = (Int64)LMBl_tNedit.GetValue();
            //if (!String.IsNullOrEmpty(TtlBl_Label.Text.Replace(",", "")))
            //{
            //    custAccRec.AfCalTMonthAccRec = long.Parse(TtlBl_Label.Text.Replace(",", ""));
            //}

            if (this._targetDivType == 0)
            {
                custAccRec.CustomerCode = 0;
                custAccRec.CustomerName = "";
                custAccRec.CustomerName2 = "";
                custAccRec.CustomerSnm = "";
            }
		}

        /// <summary>��ʏ��𐿋����z�ɔ��f����</summary>
		/// <param name="custDmdPrc">�������z���</param>
		/// <remarks>
		/// <br>Note       : ��ʍ��ڏ��𐿋����z�ɐݒ肵�܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void ScreenToCustDmdPrc(ref CustDmdPrc custDmdPrc)
		{
            custDmdPrc.EnterpriseCode      = this._enterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // ���Ӑ�
            custDmdPrc.CustomerCode = Int32.Parse(this.customerCode_Label.Text);
            custDmdPrc.CustomerName = this.CustomerName_Label.Text;
            custDmdPrc.CustomerName2 = this.CustomerName2_Label.Text;
            custDmdPrc.CustomerSnm = this.CustomerSnm_Label.Text;
            // ������
            custDmdPrc.ClaimCode = Int32.Parse(this.claimCode_Label.Text);
            custDmdPrc.ClaimName = this.ClaimName_Label.Text;
            custDmdPrc.ClaimName2 = this.ClaimName2_Label.Text;
            custDmdPrc.ClaimSnm = this.ClaimSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// �v����t
			if ( this.AddUpADate_tDateEdit.Enabled == true )
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //custDmdPrc.AddUpYearMonth = this.AddUpADate_tDateEdit.GetLongDate();
                //custDmdPrc.AddUpDate      = this.AddUpADate_tDateEdit.GetLongDate();
                custDmdPrc.AddUpYearMonth = this.AddUpADate_tDateEdit.GetDateTime();
                custDmdPrc.AddUpDate = this.AddUpADate_tDateEdit.GetDateTime();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

            // ADD 2009/06/23 ------>>>
            // ������No
            custDmdPrc.BillNo = this.BillNo_tNedit.GetInt();
            // ADD 2009/06/23 ------<<<
            
			// ����
			custDmdPrc.ItdedSalesOutTax    = (Int64)this.ItdedSalesOutTax_tNedit.GetValue();
			custDmdPrc.SalesOutTax         = (Int64)this.SalesOutTax_tNedit.GetValue();
            custDmdPrc.ItdedSalesInTax     = (Int64)this.ItdedSalesInTax_tNedit.GetValue();
            custDmdPrc.SalesInTax          = (Int64)this.SalesInTax_tNedit.GetValue();
            custDmdPrc.ItdedSalesTaxFree   = (Int64)this.ItdedSalesTaxFree_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �ԕi
            custDmdPrc.TtlItdedRetOutTax = -1 * (Int64)this.TtlItdedRetOutTax_tNedit.GetValue();
            custDmdPrc.TtlRetOuterTax = -1 * (Int64)this.TtlRetOuterTax_tNedit.GetValue();
            custDmdPrc.TtlItdedRetInTax = -1 * (Int64)this.TtlItdedRetInTax_tNedit.GetValue();
            custDmdPrc.TtlRetInnerTax = -1 * (Int64)this.TtlRetInnerTax_tNedit.GetValue();
            custDmdPrc.TtlItdedRetTaxFree = -1 * (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue();
            // �l��
            custDmdPrc.TtlItdedDisOutTax = -1 * (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();
            custDmdPrc.TtlDisOuterTax = -1 * (Int64)this.TtlDisOuterTax_tNedit.GetValue();
            custDmdPrc.TtlItdedDisInTax = -1 * (Int64)this.TtlItdedDisInTax_tNedit.GetValue();
            custDmdPrc.TtlDisInnerTax = -1 * (Int64)this.TtlDisInnerTax_tNedit.GetValue();
            custDmdPrc.TtlItdedDisTaxFree = -1 * (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();
            // �c������
            custDmdPrc.BalanceAdjust       = (Int64)this.BalanceAdjust_tNedit.GetValue();
            custDmdPrc.TaxAdjust = (Int64)this.TaxAdjust_tNedit.GetValue();
            // ����`�[����
            custDmdPrc.SalesSlipCount     = (Int32)this.SaleslSlipCount_tNedit.GetValue();

            // ���������s��
            custDmdPrc.BillPrintDate       = this.BillPrintDate_tDateEdit.GetDateTime();

            // �����\���
            // --- CHG 2009/01/28 ��QID:10447�Ή�------------------------------------------------------>>>>>
            //custDmdPrc.ExpectedDepositDate = this.ExpectedDepositDate_tDateEdit.GetDateTime();
            if (this._dmdPrcDataIndex < 0)
            {
                // ���Ӑ�}�X�^�Q��
                CustomerInfo customerInfo;
                this._customerInfoAcs.ReadCacheMemoryData(out customerInfo, this._enterpriseCode, this._targetCustomerCode);

                DateTime collectMoneyDate = custDmdPrc.AddUpDate;
                switch (customerInfo.CollectMoneyCode) // 0:����,1:����,2:���X��,3���X�X��
                {
                    case 1:
                        collectMoneyDate = collectMoneyDate.AddMonths(1);
                        break;
                    case 2:
                        collectMoneyDate = collectMoneyDate.AddMonths(2);
                        break;
                    case 3:
                        collectMoneyDate = collectMoneyDate.AddMonths(3);
                        break;
                }
                // 28���ȍ~�͖����Ƃ���
                if (customerInfo.CollectMoneyDay >= 28)
                {
                    collectMoneyDate = new DateTime(collectMoneyDate.Year, collectMoneyDate.Month, 1);
                    collectMoneyDate = collectMoneyDate.AddMonths(1);
                    collectMoneyDate = collectMoneyDate.AddDays(-1);
                }
                else
                {
                    collectMoneyDate = new DateTime(collectMoneyDate.Year, collectMoneyDate.Month, customerInfo.CollectMoneyDay);
                }
                custDmdPrc.ExpectedDepositDate = collectMoneyDate;�@// �����\���
            }
            else
            {
                custDmdPrc.ExpectedDepositDate = this.ExpectedDepositDate_tDateEdit.GetDateTime();
            }
            // --- CHG 2009/01/28 ��QID:10447�Ή�------------------------------------------------------<<<<<

            // �������
            custDmdPrc.CollectCond         = (Int32)this.CollectCondValue_tNedit.GetValue();


            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �x��
            //custDmdPrc.ItdedPaymOutTax     = (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //custDmdPrc.PaymentOutTax       = (Int64)this.PaymentOutTax_tNedit.GetValue();
            //custDmdPrc.ItdedPaymInTax      = (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //custDmdPrc.PaymentInTax        = (Int64)this.PaymentInTax_tNedit.GetValue();
            //custDmdPrc.ItdedPaymTaxFree    = (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // ����
            //custDmdPrc.ThisTimeDmdNrml     = (Int64)this.DepoNrml_tNedit.GetValue();  // 2009.01.06 Del
            custDmdPrc.ThisTimeFeeDmdNrml = (Int64)this.FeeNrml_tNedit.GetValue();
            custDmdPrc.ThisTimeDisDmdNrml = (Int64)this.DisNrml_tNedit.GetValue();

            // 2009.01.06 Add >>>
            object value = this._depositDataTable.Compute(string.Format("SUM({0})", DepositRelDataAcs.ctDeposit), string.Empty);
            Int64 total = ( value is DBNull ) ? 0 : (Int64)value;
            custDmdPrc.ThisTimeDmdNrml = total + custDmdPrc.ThisTimeFeeDmdNrml + custDmdPrc.ThisTimeDisDmdNrml;

            custDmdPrc.OfsThisSalesTax = (Int64)this.OfsThisSalesTax_tNedit.GetValue();
            custDmdPrc.OffsetOutTax = (Int64)this.OffsetOutTax_tNedit.GetValue();
            // 2009.01.06 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.ThisTimeRbtDmdNrml  = (Int64)this.RbtNrml_tNedit.GetValue();
            //custDmdPrc.ThisTimeDmdDepo     = (Int64)this.Depo_tNedit.GetValue();
            //custDmdPrc.ThisTimeFeeDmdDepo  = (Int64)this.DisDepo_tNedit.GetValue();
            //custDmdPrc.ThisTimeDisDmdDepo  = (Int64)this.FeeDepo_tNedit.GetValue();
            //custDmdPrc.ThisTimeRbtDmdDepo  = (Int64)this.RbtDepo_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �x��
            //custDmdPrc.ItdedPaymOutTax = -1 * (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //custDmdPrc.PaymentOutTax = -1 * (Int64)this.PaymentOutTax_tNedit.GetValue();
            //custDmdPrc.ItdedPaymInTax = -1 * (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //custDmdPrc.PaymentInTax = -1 * (Int64)this.PaymentInTax_tNedit.GetValue();
            //custDmdPrc.ItdedPaymTaxFree = -1 * (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

			// �����ݏ��
			// �O����
			custDmdPrc.AcpOdrTtl3TmBfBlDmd = (Int64)Bf3TmBl_tNedit.GetValue();
			custDmdPrc.AcpOdrTtl2TmBfBlDmd = (Int64)Bf2TmBl_tNedit.GetValue(); 
			custDmdPrc.LastTimeDemand      = (Int64)LMBl_tNedit.GetValue();
            //if (!String.IsNullOrEmpty(TtlBl_Label.Text.Replace(",", "")))
            //{
            //    custDmdPrc.AfCalDemandPrice = long.Parse(TtlBl_Label.Text.Replace(",", ""));
            //}
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.28 TOKUNAGA ADD START
            custDmdPrc.ResultsSectCd = this._sectionCode.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.28 TOKUNAGA ADD END

            if (this._targetDivType == 0)
            {
                custDmdPrc.CustomerCode = 0;
                custDmdPrc.CustomerName = "";
                custDmdPrc.CustomerName2 = "";
                custDmdPrc.CustomerSnm = "";
                custDmdPrc.ResultsSectCd = CustAccRecDmdPrcAcs.ALL_SECTION;
            }
		}

        # endregion

		// ===================================================================================== //
		// �������\�b�h�i�ۑ��E�폜�֘A�j
		// ===================================================================================== //
		#region Privete Methods WriteAndDelete_Relation Methods

        /// <summary>��ʓ��͏��s���`�F�b�N����</summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool CheckScreenData(ref Control control, ref string message)
		{
			bool result = true;

            // GetDateTime���g�p����ƕs���ȃf�[�^�ł�MinValue�ɂȂ�ׁALongDate���g�p����
			if ( this.AddUpADate_tDateEdit.LongDate == 0 )
            {
				control = AddUpADate_tDateEdit;
				message = this.AddUpADate_Tittle_Label.Text + "����͂��ĉ������B";
				result = false;
			}
    		// ���t�̓��̓`�F�b�N�ǉ� 
			else if (( this.AddUpADate_tDateEdit.LongDate != 0  ) && 
                     (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(this.AddUpADate_tDateEdit.LongDate)) == false))
			{
				control = AddUpADate_tDateEdit;
				message = this.AddUpADate_Tittle_Label.Text + "���s���ł��B���������t����͂��ĉ������B";
				result = false;
			}
			else
			{
                DataRow[] rows = this.GetDepositRows();         // 2009.01.06 Add
                
				// ���ڃ`�F�b�N
				if (
					// �c��
                    // 2009.01.06 Del >>>
                    //((Int64)this.TtlBf3TmBl_Label.Tag         == 0) && 
                    //((Int64)this.TtlBf2TmBl_Label.Tag         == 0) &&
                    //((Int64)this.TtlLMBl_Label.Tag            == 0) &&
                    // 2009.01.06 Del <<<
                    // ����
					(this.ItdedSalesOutTax_tNedit.GetValue()  == 0) &&
					(this.SalesOutTax_tNedit.GetValue()       == 0) &&
                    (this.ItdedSalesInTax_tNedit.GetValue()   == 0) &&
                    (this.SalesInTax_tNedit.GetValue()        == 0) &&
                    (this.ItdedSalesTaxFree_tNedit.GetValue() == 0) &&
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // �ԕi
                    ( this.TtlItdedRetOutTax_tNedit.GetValue()  == 0 ) &&
                    ( this.TtlRetOuterTax_tNedit.GetValue()     == 0 ) &&
                    ( this.TtlItdedRetInTax_tNedit.GetValue()   == 0 ) &&
                    ( this.TtlRetInnerTax_tNedit.GetValue()     == 0 ) &&
                    ( this.TtlItdedRetTaxFree_tNedit.GetValue() == 0 ) &&
                    // �l��
                    ( this.TtlItdedDisOutTax_tNedit.GetValue()  == 0 ) &&
                    ( this.TtlDisOuterTax_tNedit.GetValue()     == 0 ) &&
                    ( this.TtlItdedDisInTax_tNedit.GetValue()   == 0 ) &&
                    ( this.TtlDisInnerTax_tNedit.GetValue()     == 0 ) &&
                    ( this.TtlItdedDisTaxFree_tNedit.GetValue() == 0 ) &&
                    // �c��
                    ( this.Bf3TmBl_tNedit.GetValue() == 0 ) &&
                    ( this.Bf2TmBl_tNedit.GetValue() == 0 ) &&
                    ( this.LMBl_tNedit.GetValue() == 0 ) &&
                    // �c������
                    ( this.BalanceAdjust_tNedit.GetValue() == 0 ) &&
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
                    ( this.TaxAdjust_tNedit.GetValue() == 0) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
                    //// ��������
                    //( this.ThisCashSalePrice_tNedit.GetValue() == 0) &&
                    //( this.ThisCashSaleTax_tNedit.GetValue() == 0) &&

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
                    // �����ϋ��z
                    //( this.NonStmntAppearance_tNedit.GetValue() == 0 ) &&
                    //( this.NonStmntIsdone_tNedit.GetValue() == 0 ) &&
                    // ���ϋ��z
                    //( this.StmntAppearance_tNedit.GetValue() == 0 ) &&
                    //( this.StmntIsdone_tNedit.GetValue() == 0 ) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// �x��
                    //(this.ItdedPaymOutTax_tNedit.GetValue()   == 0) &&
                    //(this.PaymentOutTax_tNedit.GetValue()     == 0) &&
                    //(this.ItdedPaymInTax_tNedit.GetValue()    == 0) &&
                    //(this.PaymentInTax_tNedit.GetValue()      == 0) &&
                    //(this.ItdedPaymTaxFree_tNedit.GetValue()  == 0) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // �ʏ����
                    // 2009.01.06 >>>
                    //(this.DepoNrml_tNedit.GetValue()          == 0) &&    // 2009.01.06 Del
                    ( ( rows == null ) || ( rows.Length == 0 ) ) &&
                    // 2009.01.06 <<<
                    ( this.FeeNrml_tNedit.GetValue() == 0 ) &&
                    (this.DisNrml_tNedit.GetValue()           == 0))
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //(this.RbtNrml_tNedit.GetValue()           == 0) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// �a�������
                    //(this.Depo_tNedit.GetValue()              == 0) &&
                    //(this.FeeDepo_tNedit.GetValue()           == 0) &&
                    //(this.DisDepo_tNedit.GetValue()           == 0) &&
                    //(this.RbtDepo_tNedit.GetValue()           == 0))
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //(this.ItdedPaymOutTax_tNedit.GetValue() == 0) &&
                    //(this.PaymentOutTax_tNedit.GetValue() == 0) &&
                    //(this.ItdedPaymInTax_tNedit.GetValue() == 0) &&
                    //(this.PaymentInTax_tNedit.GetValue() == 0) &&
                    //(this.ItdedPaymTaxFree_tNedit.GetValue() == 0))
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
                {
					control = this.ItdedSalesOutTax_tNedit;
					message = "�S�Ă̋��z�������͂ł̍X�V�͂ł��܂���B";
					result = false;
				}
			}
		
			return result;
		}

        /// <summary>�ۑ�����</summary>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕ۑ��������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool SaveProc()
		{
			bool result = false;
			
			Control control = null;
			string errmsg = "";

            // 2009.01.06 Add >>>
            List<DmdDepoTotal> dmdDepoTotalList = new List<DmdDepoTotal>();
            List<AccRecDepoTotal> accRecDepoTotalList = new List<AccRecDepoTotal>();
            // 2009.01.06 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE))
            {
                this._editCustDmdPrc.AddUpSecCode = this._mngSectionCode;
                this._editCustDmdPrc.CustomerCode = this._targetCustomerCode;
                this._editCustDmdPrc.ClaimCode = this._targetClaimCode;
                this._editCustDmdPrc.ResultsSectCd = this._sectionCode.Trim();

                ScreenToCustDmdPrc(ref _editCustDmdPrc);

                // 2009.01.06 Add >>>
                if (this._targetDivType == 0)
                {
                    dmdDepoTotalList = this.GetDmdDepoTotalList();
                }
                // 2009.01.06 Add <<<
            }
            else
            {
                this._editCustAccRec.AddUpSecCode = this._mngSectionCode;
                this._editCustAccRec.CustomerCode = this._targetCustomerCode;
                this._editCustAccRec.ClaimCode = this._targetClaimCode;

                ScreenToCustAccRec(ref _editCustAccRec);

                // 2009.01.06 Add >>>
                if (this._targetDivType == 0)
                {
                    accRecDepoTotalList = this.GetAccRecDepoTotalList();
                }
                // 2009.01.06 Add <<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

			// �X�V�O�`�F�b�N����
			// ��ʓ��͏��s���`�F�b�N����
			if (!CheckScreenData(ref control, ref errmsg))
			{
				TMsgDisp.Show(this,										// �e�E�B���h�E�t�H�[��
					          emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
					          "MAKAU09110U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
					          errmsg,									// �\�����郁�b�Z�[�W 
					          0,										// �X�e�[�^�X�l
					          MessageBoxButtons.OK);					// �\������{�^��

				control.Focus();
				if(control is TEdit)   ((TEdit)control).SelectAll();
				if(control is TNedit)  ((TNedit)control).SelectAll();
				return result;
			}

            // 2009.01.06 >>>
            //result = SaveDetailsProc(ref this._editCustAccRec, ref this._editCustDmdPrc);
            result = SaveDetailsProc(ref this._editCustAccRec, ref this._editCustDmdPrc, ref accRecDepoTotalList, ref dmdDepoTotalList);
            // 2009.01.06 <<<

#if false
			// �I�v�V���������݂��Ȃ��ꍇ�́A�S�Ќv���X�V����
			if (( this.Opt_Section == false ) && ( result  == true )&& (this._autoAllUpDateMode == true ))
			{
				// �S�Ќv���擾���A��ʏ��𔽉f����
				CustAccRec allAccRec = new CustAccRec();
				CustDmdPrc allDmdPrc = new CustDmdPrc(); 
				
				// ���_�����̎��悤�ɑS�Ќv���擾���A��ʏ��𔽉f����
				ReadAllSecCodeAndSetScreenInformation(ref allAccRec, ref allDmdPrc, true);
				
				result = SaveDetailsProc( ref allAccRec, ref allDmdPrc );
			}
#endif 
			if ( result  == true )
			{
				if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
				{
					// �f�[�^�ēǂݍ��ݏ���
					AccRec_Data_Search(this._targetClaimCode,this._targetCustomerCode, this._sectionCode, this._targetDivType);
					this._accRecIndexBuf = -2;
				}
    			// �������z
				else
				{
					// �f�[�^�ēǂݍ��ݏ���
					DmdRec_Data_Search(this._targetClaimCode, this._targetCustomerCode, this._sectionCode, this._targetDivType);
					this._dmdPrcIndexBuf = -2;
				}
			}
			return result;
		}

		/// <summary>�ۑ�����</summary>
		/// <param name="custAccRec">���|���z���</param>
		/// <param name="custDmdPrc">�������z���</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕ۑ��������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        // 2009.01.06 >>>
		//private bool SaveDetailsProc(ref CustAccRec custAccRec ,ref CustDmdPrc custDmdPrc)
        private bool SaveDetailsProc(ref CustAccRec custAccRec, ref CustDmdPrc custDmdPrc, ref List<AccRecDepoTotal> accRecDepoTotalList, ref List<DmdDepoTotal> dmdDepoTotalList)
        // 2009.01.06 <<<
        {
			bool result = false;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			string errmsg = "";
		
			// ���|���z
			if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
                // 2009.01.06 >>>
                //// �K�{���͍��ڂ̊m�F
                //WriteInputDataCheck_ACC(ref custAccRec );
                //// (�ŏI���R�[�h�������čX�V����)
                //status = this._custAccRecDmdPrcAcs.WriteCustAccRec(custAccRec, out errmsg);
                try
                {
                    // �K�{���͍��ڂ̊m�F
                    WriteInputDataCheck_ACC(ref custAccRec );
                    // (�ŏI���R�[�h�������čX�V����)
                    status = this._custAccRecDmdPrcAcs.WriteCustAccRec(custAccRec, accRecDepoTotalList, out errmsg);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                // 2009.01.06 <<<
            }
			// �������z
			else
			{
                try
                {
                    // �K�{���͍��ڂ̊m�F
                    WriteInputDataCheck_DMD(ref custDmdPrc);
                    // (�ŏI���R�[�h�������čX�V����)
                    // 2009.01.06 >>>
                    //status = this._custAccRecDmdPrcAcs.WriteCustDmdPrc(custDmdPrc, out errmsg);
                    status = this._custAccRecDmdPrcAcs.WriteCustDmdPrc(custDmdPrc, dmdDepoTotalList, out errmsg);
                    // 2009.01.06 <<<
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
			}

			//������̑Ή��ǉ�
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					result = true;
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
                    TMsgDisp.Show(this,											  // �e�E�B���h�E�t�H�[��
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,	          // �G���[���x��
                                  "MAKAU09110U",							      // �A�Z���u���h�c�܂��̓N���X�h�c
                                  this.Text,									  // �v���O��������
                                  "Save_Button_Click",							  // ��������
                                  TMsgDisp.OPE_UPDATE,							  // �I�y���[�V����
                                  "���ɓ���̌v����Ńf�[�^�����݂��邽�ߐV�K�ł͍쐬�ł��܂���B",   // �\�����郁�b�Z�[�W 
                                  status,										  // �X�e�[�^�X�l
                                  this._custAccRecDmdPrcAcs,					  // �G���[�����������I�u�W�F�N�g
                                  MessageBoxButtons.OK,							  // �\������{�^��
                                  MessageBoxDefaultButton.Button1);			  	  // �����\���{�^��
                    break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
				
					this.DialogResult = DialogResult.Cancel;
					break;
				}
				default:
				{
                    if (errmsg == "")
                    {
                        errmsg = "�o�^�Ɏ��s���܂����B";
                    }
					TMsgDisp.Show(this,											  // �e�E�B���h�E�t�H�[��
						          emErrorLevel.ERR_LEVEL_STOP,				      // �G���[���x��
						          "MAKAU09110U",							  // �A�Z���u���h�c�܂��̓N���X�h�c
						          this.Text,									  // �v���O��������
						          "Save_Button_Click",							  // ��������
						          TMsgDisp.OPE_UPDATE,							  // �I�y���[�V����
						          errmsg,						                  // �\�����郁�b�Z�[�W 
						          status,										  // �X�e�[�^�X�l
                                  this._custAccRecDmdPrcAcs,					  // �G���[�����������I�u�W�F�N�g
						          MessageBoxButtons.OK,							  // �\������{�^��
						          MessageBoxDefaultButton.Button1);			  	  // �����\���{�^��
					this.DialogResult = DialogResult.Cancel;
					break;
				}
			}

			return result;
		}

        /// <summary>�S���_�v�̎擾�y�щ�ʏ�񔽉f����</summary>
		/// <param name="allAccRec">���|���z���</param>
		/// <param name="allDmdPrc">�������z���</param>
		/// <param name="reflectedMode">��ʏ��𔽉f���邩�̗L��</param>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕ۑ��������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ReadAllSecCodeAndSetScreenInformation(ref CustAccRec allAccRec, ref CustDmdPrc allDmdPrc, bool reflectedMode )
		{
			if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
				bool selectData = false;
				this._AllaccrecTable.Clear();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                SearchAccPrcInfo(this._targetClaimCode, this._targetCustomerCode, "", out this._AllaccrecTable, false, this._targetDivType);
                //SearchAccPrcInfo(this._targetClaimCode, this._targetCustomerCode, "", out this._AllaccrecTable, false);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
                foreach (CustAccRec _accRec in this._AllaccrecTable.Values)
				{
                    if (_accRec.AddUpDate == this._editCustAccRec.AddUpDate)
					{
						allAccRec = custAccRec_Clone(_accRec);
						selectData = true;
						break;
					}
				}
				if ( selectData == false )
				{
					allAccRec.AddUpSecCode = ALLSECCODE;
				}
				if ( reflectedMode == true )
				{
					//��ʏ��𔽉f���X�V����
					ScreenToCustAccRec(ref allAccRec);
					getKinSetInfo_Acc(ref allAccRec);
				}
			}
			else
			{
				bool selectData = false;
				this._AlldmdprcTable.Clear();
			
				SearchDmdRecInfo(this._targetClaimCode, this._targetCustomerCode, null, out this._AlldmdprcTable, false, this._targetDivType);
				foreach( CustDmdPrc _dmdPrc in this._AlldmdprcTable.Values)
				{
                    if (_dmdPrc.AddUpDate == this._editCustDmdPrc.AddUpDate)
					{
						allDmdPrc = custdmdRec_Clone(_dmdPrc);
						selectData = true;
						break;
					}
				}
				if ( selectData == false )
				{
					allDmdPrc.AddUpSecCode = ALLSECCODE;
				}
				if ( reflectedMode == true )
				{
					//��ʏ��𔽉f���X�V����
					ScreenToCustDmdPrc(ref allDmdPrc);
					getKinSetInfo_Dmd(ref allDmdPrc);
				}
			}
		}

        /// <summary>�K�{���͍��ړ��̃`�F�b�N����</summary>
		/// <param name="accRec">���|���z���</param>
		/// <remarks>
		/// <br>Note       : �ۑ��ŕK�v�ȕK�{���ڂ��Z�b�g���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void WriteInputDataCheck_ACC(ref CustAccRec accRec)
		{
            if ((accRec.EnterpriseCode == null) || (accRec.EnterpriseCode == ""))
            {
                accRec.EnterpriseCode = this._enterpriseCode;
            }
            // 2009.01.06 >>>
            //if (accRec.CustomerCode == 0)
            //{
            //    accRec.CustomerCode  = this._targetCustomerCode;
            //    accRec.CustomerName  = this.CustomerSnm_Label.Text;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    accRec.CustomerName2 = this.CustomerName2_Label.Text;
            //    accRec.CustomerSnm = this.CustomerSnm_Label.Text;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}

            if (this._targetDivType == 1)
            {
                if (accRec.CustomerCode == 0)
                {
                    accRec.CustomerCode = this._targetCustomerCode;
                    accRec.CustomerName = this.CustomerSnm_Label.Text;
                    accRec.CustomerName2 = this.CustomerName2_Label.Text;
                    accRec.CustomerSnm = this.CustomerSnm_Label.Text;
                }
            }
            else
            {
                accRec.CustomerCode = 0;
                accRec.CustomerName = "";
                accRec.CustomerName2 = "";
                accRec.CustomerSnm = "";
            }
            // 2009.01.06 <<<

            if (( accRec.AddUpSecCode == null ) || ( accRec.AddUpSecCode == "" ))
            {
                accRec.AddUpSecCode = this._sectionCode;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (TDateTime.LongDateToDateTime(accRec.AddUpDate) ==DateTime.MinValue)
            //{
            //    accRec.AddUpDate      = this.AddUpADate_tDateEdit.GetLongDate();
            //    accRec.AddUpYearMonth = this.AddUpADate_tDateEdit.GetLongDate();
            //}
            if ( accRec.AddUpDate == DateTime.MinValue ) {
                accRec.AddUpDate = this.AddUpADate_tDateEdit.GetDateTime();
                accRec.AddUpYearMonth = this.AddUpADate_tDateEdit.GetDateTime();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accRec.ClaimCode = this._targetClaimCode;
            accRec.ClaimName = this.ClaimName_Label.Text;
            accRec.ClaimName2 = this.ClaimName2_Label.Text;
            accRec.ClaimSnm = this.ClaimSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		}

        /// <summary>�K�{���͍��ړ��̃`�F�b�N����</summary>
		/// <param name="dmdPrc">�������z���</param>
		/// <remarks>
		/// <br>Note       : �ۑ��ŕK�v�ȕK�{���ڂ��Z�b�g���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void WriteInputDataCheck_DMD(ref CustDmdPrc dmdPrc)
		{
            if ((dmdPrc.EnterpriseCode == null) || (dmdPrc.EnterpriseCode == ""))
            {
                dmdPrc.EnterpriseCode = this._enterpriseCode;
            }
            // 2009.01.06 >>>
            //if (dmdPrc.CustomerCode == 0)
            //{
            //    dmdPrc.CustomerCode  = this._targetCustomerCode;
            //    dmdPrc.CustomerName  = this.CustomerSnm_Label.Text;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    dmdPrc.CustomerName2 = this.CustomerName2_Label.Text;
            //    dmdPrc.CustomerSnm = this.CustomerSnm_Label.Text;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}
            // �u���Ӑ�v�w�莞�́A���ьv�㋒�_�A���Ӑ�R�[�h�͕K�{
            if (this._targetDivType == 1)
            {
                if (dmdPrc.CustomerCode == 0)
                {
                    dmdPrc.CustomerCode = this._targetCustomerCode;
                    dmdPrc.CustomerName = this.CustomerSnm_Label.Text;
                    dmdPrc.CustomerName2 = this.CustomerName2_Label.Text;
                    dmdPrc.CustomerSnm = this.CustomerSnm_Label.Text;
                }

                dmdPrc.ResultsSectCd = this._sectionCode.Trim();
            }
            else
            {
                dmdPrc.ResultsSectCd = CustAccRecDmdPrcAcs.ALL_SECTION;
                dmdPrc.CustomerCode = 0;
                dmdPrc.CustomerName = "";
                dmdPrc.CustomerName2 = "";
                dmdPrc.CustomerSnm = "";
            }
            // 2009.01.06 <<<
            if (( dmdPrc.AddUpSecCode == null ) || ( dmdPrc.AddUpSecCode == "" ))
            {
                dmdPrc.AddUpSecCode = this._sectionCode;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (TDateTime.LongDateToDateTime(dmdPrc.AddUpDate) ==DateTime.MinValue)
            //{
            //    dmdPrc.AddUpDate      = this.AddUpADate_tDateEdit.GetLongDate();
            //    dmdPrc.AddUpYearMonth = this.AddUpADate_tDateEdit.GetLongDate();
            //}
            if ( dmdPrc.AddUpDate == DateTime.MinValue ) {
                dmdPrc.AddUpDate = this.AddUpADate_tDateEdit.GetDateTime();
                dmdPrc.AddUpYearMonth = this.AddUpADate_tDateEdit.GetDateTime();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdPrc.ClaimCode = this._targetClaimCode;
            dmdPrc.ClaimName = this.ClaimName_Label.Text;
            dmdPrc.ClaimName2 = this.ClaimName2_Label.Text;
            dmdPrc.ClaimSnm = this.ClaimSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //dmdPrc.ResultsSectCd = this._sectionCode.Trim();  // 2009.01.06 Del
        }

        /// <summary>�폜����</summary>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʏ��Ŏw�肳�ꂽ���̍폜�������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private bool DeleteProc()
        {
            bool result = false;

            result = DeleteDetailsProc(this._custAccRecClone, this._custDmdPrcClone);

#if false
            // �I�v�V���������݂��Ȃ��ꍇ�́A�S�Ќv���X�V����
            if ((this.Opt_Section == false) && (result == true) && (this._autoAllUpDateMode == true))
            {
                // �S�Ќv���擾���A��ʏ��𔽉f����
                CustAccRec allAccRec = new CustAccRec();
                CustDmdPrc allDmdPrc = new CustDmdPrc();

                // ���_�����̎��悤�ɑS�Ќv���擾���A��ʏ��𔽉f����
                ReadAllSecCodeAndSetScreenInformation(ref allAccRec, ref allDmdPrc, false);

                result = DeleteDetailsProc(allAccRec, allDmdPrc);
            }
#endif
            if (result == true)
            {
                if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
                {
                    // �f�[�^�ēǂݍ��ݏ���
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                    //AccRec_Data_Search(this._condClaimCode, this._condCustomerCode, this._condSectionCode, this._targetDivType);
                    AccRec_Data_Search(this._targetClaimCode, this._targetCustomerCode, this._sectionCode, this._targetDivType);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
                    this._accRecIndexBuf = -2;
                }
                // �������z
                else
                {
                    // �f�[�^�ēǂݍ��ݏ���
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                    //DmdRec_Data_Search(this._condClaimCode, this._condCustomerCode, this._condSectionCode, this._targetDivType);
                    DmdRec_Data_Search(this._targetClaimCode, this._targetCustomerCode, this._sectionCode,  this._targetDivType);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
                    this._dmdPrcIndexBuf = -2;
                }
            }
            return result;
        }

        /// <summary>�폜�ڍ׏���</summary>
		/// <param name="custAccRec">���|���z���</param>
		/// <param name="custDmdPrc">�������z���</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʏ��Ŏw�肳�ꂽ���̍폜�������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private bool DeleteDetailsProc(CustAccRec custAccRec, CustDmdPrc custDmdPrc)
        {
            bool result = false;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // ���|���z(�ŏI���R�[�h�������čX�V����)
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                status = this._custAccRecDmdPrcAcs.DeleteCustAccRec(custAccRec);
            }
            // �������z(�ŏI���R�[�h�������čX�V����)
            else
            {
                status = this._custAccRecDmdPrcAcs.DeleteCustDmdPrc(custDmdPrc);
            }

            //������̑Ή��ǉ�
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,											  // �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_STOP,				      // �G���[���x��
                                      "MAKAU09110U",							  // �A�Z���u���h�c�܂��̓N���X�h�c
                                      this.Text,									  // �v���O��������
                                      "Delete_Button_Click",						  // ��������
                                      TMsgDisp.OPE_UPDATE,							  // �I�y���[�V����
                                      "�o�^�Ɏ��s���܂����B",						  // �\�����郁�b�Z�[�W 
                                      status,										  // �X�e�[�^�X�l
                                      this._custAccRecDmdPrcAcs,					  // �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK,							  // �\������{�^��
                                      MessageBoxDefaultButton.Button1);			  	  // �����\���{�^��
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }
            }

            return result;
        }

        # endregion

        // ===================================================================================== //
		// �������\�b�h�i���|�E�������Clone�쐬 & Equals�j
		// ===================================================================================== //
		#region  Privete Methods AccPrcAndDmdPrcClone&Equals

		/// <summary>���|���z�̃N���[���쐬����</summary>
		/// <param name="targetCustAccRec">���|���z���</param>
		/// <returns>���|���z���</returns>
		/// <remarks>
		/// <br>Note       : �n���ꂽ���|���z���̃N���[���f�[�^���쐬���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private CustAccRec custAccRec_Clone(CustAccRec targetCustAccRec)
		{
            CustAccRec custAccRec = new CustAccRec();
			// �f�[�^�N���X��Type�I�u�W�F�N�g���擾����
            Type myType2 = typeof(CustAccRec);
			// �f�[�^�N���X�̃v���p�e�B���擾
			PropertyInfo[] propertyInfoList2 = myType2.GetProperties(); 

			if (propertyInfoList2 != null)
			{
				foreach (PropertyInfo propertyInfo in propertyInfoList2)
				{
					PropertyInfo propertyInfo2 = propertyInfo;
                    propertyInfo.SetValue(custAccRec, propertyInfo2.GetValue(targetCustAccRec, null), null);
				}
			}
            return custAccRec;
		}

		/// <summary>�������z�̃N���[���쐬����</summary>
		/// <param name="targetCustDmdPrc">�������z���</param>
		/// <returns>�������z���</returns>
		/// <remarks>
		/// <br>Note       : �n���ꂽ�������z���̃N���[���f�[�^���쐬���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private CustDmdPrc custdmdRec_Clone(CustDmdPrc targetCustDmdPrc)
		{
			CustDmdPrc custDmdPrc = new CustDmdPrc();
			
			// �f�[�^�N���X��Type�I�u�W�F�N�g���擾����
            Type myType2 = typeof(CustDmdPrc);
			// �f�[�^�N���X�̃v���p�e�B���擾
			PropertyInfo[] propertyInfoList2 = myType2.GetProperties();

			if (propertyInfoList2 != null)
			{
				foreach (PropertyInfo propertyInfo in propertyInfoList2)
				{
					PropertyInfo propertyInfo2 = propertyInfo;
                    propertyInfo.SetValue(custDmdPrc, propertyInfo2.GetValue(targetCustDmdPrc, null), null);
				}
			}
            return custDmdPrc;
		}

		/// <summary>���|���z����r����</summary>
		/// <param name="targetCustAccRec">���|���z���A</param>
		/// <param name="compCustAccRec">���|���z���B</param>
		/// <returns>�`�F�b�N���ʁitrue:�����^false:�قȂ�j</returns>
		/// <remarks>
		/// <br>Note       : ���|���z���A�Ɣ��|���z���B�̓��e���r���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private  bool custAccRec_Equals(CustAccRec targetCustAccRec, CustAccRec compCustAccRec)
		{
			bool result = true;
			// �f�[�^�N���X��Type�I�u�W�F�N�g���擾����
			Type myType2 = typeof(CustAccRec);
			// �f�[�^�N���X�̃v���p�e�B���擾
			PropertyInfo[] propertyInfoList2 = myType2.GetProperties();

			if (propertyInfoList2 != null)
			{
				foreach (PropertyInfo propertyInfo in propertyInfoList2)
				{
					PropertyInfo propertyInfo2 = propertyInfo;

					if ( propertyInfo.GetValue(compCustAccRec,null ).Equals(propertyInfo2.GetValue(targetCustAccRec,null)) == false )
					{
						result = false;
						break;
					}
				}
			}
			return result ;
		}

		/// <summary>�������z����r����</summary>
		/// <param name="targetCustDmdPrc">�������z���A</param>
		/// <param name="compCustDmdPrc">�������z���B</param>
		/// <returns>�`�F�b�N���ʁitrue:�����^false:�قȂ�j</returns>
		/// <remarks>
		/// <br>Note       : �������z���A�Ɛ������z���B�̓��e���r���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private  bool custDmdPrc_Equals(CustDmdPrc targetCustDmdPrc, CustDmdPrc compCustDmdPrc)
		{
			bool result = true;
			// �f�[�^�N���X��Type�I�u�W�F�N�g���擾����
			Type myType2 = typeof(CustDmdPrc);
			// �f�[�^�N���X�̃v���p�e�B���擾
			PropertyInfo[] propertyInfoList2 = myType2.GetProperties();

			if (propertyInfoList2 != null)
			{
				foreach (PropertyInfo propertyInfo in propertyInfoList2)
				{
					PropertyInfo propertyInfo2 = propertyInfo;

					if ( propertyInfo.GetValue(compCustDmdPrc, null).Equals(propertyInfo2.GetValue(targetCustDmdPrc, null)) == false )
					{
						result = false;
						break;
					}
				}
			}
			return result ;
		}

		# endregion

		// ===================================================================================== //
		// �R���g���[���C�x���g
		// ===================================================================================== //
		#region Control Events
		# endregion

		// ===================================================================================== //
		// ��ʃC�x���g
		// ===================================================================================== //
		# region Control Form Events

        /// <summary>Form.Load �C�x���g(MAKAU09110UB)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09110UB_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList     = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Undo_Button.ImageList   = imageList25;
			this.Delete_Button.ImageList = imageList25;

            this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Undo_Button.Appearance.Image   = Size24_Index.BEFORE;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.28 TOKUNAGA ADD START
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                this.DemandSalesInfo_Title_Label.Text = "���|���";
            }
            else
            {
                this.DemandSalesInfo_Title_Label.Text = "�������";
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.28 TOKUNAGA ADD END

            // 2009.01.06 Add >>>
            //this.uGrid_DemandInfo.DataSource = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCRECTOTAL_TITLE];
            this.uGrid_DemandInfo.DataSource = this._totalDisplayTable;
            this.SettingDemandInfoGrid();

            this.ClearDepositDataTable();
            // 2009.01.06 Add <<<
    	}

		/// <summary>VisibleChanged �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09110UB_VisibleChanged(object sender, System.EventArgs e)
		{
			if (this.Visible == false)
			{
				return;
			}

			// �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._targetTableName == CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE)
			{
				// �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
				if ((this._accRecIndexBuf  == this._accRecDataIndex) &&
					(this._customerCodeBuf == this._targetCustomerCode) &&
					(this._targetTableBuf  == this._targetTableName))
				{
					return;
				}
			}
			if (this._targetTableName == CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE)
			{
				// �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
				if ((this._dmdPrcIndexBuf  == this._dmdPrcDataIndex) &&
					(this._customerCodeBuf == this._targetCustomerCode)	&&
					(this._targetTableBuf  == this._targetTableName))
				{
					return;
				}
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE) ) {
                // <���|���ŗL����> ��\��
                //this.CustAccRec_panel.Visible = true;
                // <�������ŗL����> ���\��
                this.CustDmdPrc_panel.Visible = false;

                //this.CustAccRec_panel.Location = this._expansionPanelLocation;

                // 2009.01.06 Add >>>
                this.LMBl_Label.Location = this._balance3LabelLocation;
                this.LMBl_tNedit.Location = this._balance3EditLocation;

                this.Bf2TmBl_Label.Visible = false;
                this.Bf2TmBl_tNedit.Visible = false;
                this.Bf3TmBl_Label.Visible = false;
                this.Bf3TmBl_tNedit.Visible = false;

                this.BlTotal_Label.Visible = false;
                this.BlTotalTitle_Label.Visible = false;

                this.ultraLabel33.Visible = false;
                this.ultraLabel28.Visible = false;
                this.ultraLabel26.Visible = false;
                this.ultraLabel25.Visible = false;

                this.AddUpADate_Tittle_Label.Text = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Columns[CustAccRecDmdPrcAcs.COL_ADDUPDATEJP_TITLE].Caption;
                // 2009.01.06 Add <<<
            }
            else {
                // <���|���ŗL����> ���\��
                //this.CustAccRec_panel.Visible = false;
                // <�������ŗL����> ��\��
                this.CustDmdPrc_panel.Visible = true;

                this.CustDmdPrc_panel.Location = this._expansionPanelLocation;

                // 2009.01.06 Add >>>
                this.LMBl_Label.Location = this._balance1LabelLocation;
                this.LMBl_tNedit.Location = this._balance1EditLocation;

                this.Bf2TmBl_Label.Visible = true;
                this.Bf2TmBl_tNedit.Visible = true;
                this.Bf3TmBl_Label.Visible = true;
                this.Bf3TmBl_tNedit.Visible = true;

                this.BlTotal_Label.Visible = true;
                this.BlTotalTitle_Label.Visible = true;

                this.ultraLabel33.Visible = true;
                this.ultraLabel28.Visible = true;
                this.ultraLabel26.Visible = true;
                this.ultraLabel25.Visible = true;
                this.AddUpADate_Tittle_Label.Text = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Columns[CustAccRecDmdPrcAcs.COL_ADDUPDATEJP_TITLE].Caption;
                // 2009.01.06 Add <<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
            // �Ȃ�ŃN���A���Ă�́H
			//ScreenClear(true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END

            // 2009.01.06 Add >>>
            if (this._targetDivType == 1)
            {
                this.DepositInfo_Pnl.Visible = false;
                this.LtBlInfo_Pnl.Visible = false;
            }
            else
            {
                this.DepositInfo_Pnl.Visible = true;
                this.LtBlInfo_Pnl.Visible = true;

            }
            // 2009.01.06 Add <<<

            // ��ʏ�����
			Initial_Timer.Enabled = true;

    	}

		/// <summary>Closing �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[���I�����ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09110UB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._accRecIndexBuf  = -2;
			this._dmdPrcIndexBuf  = -2;
			this._targetTableBuf  = "";
			this._customerCodeBuf = -2;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z�����ăt�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

        /// <summary>Timer.Tick �C�x���g �C�x���g(Initial_Timer)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///	                 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///	                 �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			if ( this._timerStarted == true ) return;
			this._timerStarted     = true;
			this._formBeingStarted = false;
			Initial_Timer.Enabled  = false;

            ScreenReconstruction();
			this._formBeingStarted = true;
			this._timerStarted     = false;
        }

        /// <summary>Control.ChangeFocus �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X�ړ����ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null) return;
			if (e.NextCtrl == null) return;

            # region    ********** Unnecessary(�s�v) **********
            //if ( e.NextCtrl == this.VarCstList_Grid )
            //{
            //    if (e.Key == Keys.Up)
            //    {
            //        for (int index = this.VarCstList_Grid.Rows.Count -1 ; index >= 0; index--)
            //        {
            //            if (VarCstList_Grid.Rows[index].Hidden == false)
            //            {
            //                SelectCell(index, VARCSTTOTAL);
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        for (int index = 0; index < this.VarCstList_Grid.Rows.Count; index++)
            //        {
            //            if (VarCstList_Grid.Rows[index].Hidden == false)
            //            {
            //                SelectCell(index, VARCSTTOTAL);
            //                break;
            //            }
            //        }
            //    }
            //}
            //if (e.PrevCtrl == this.VarCstList_Grid)
            //{
            //    // ���^�[���L�[�̎�
            //    if ((e.Key == Keys.Return) ||
            //        (e.Key == Keys.Tab))
            //    {
            //        Control _nextCtrl = e.NextCtrl;
            //        e.NextCtrl = null;
			
            //        if (this.VarCstList_Grid.ActiveCell != null)
            //        {
            //            // �A�N�e�B�u�Z�����G�f�B�b�g���[�h�ɂȂ��Ă��Ȃ��ꍇ�̓G�f�B�b�g���[�h�ɂ���
            //            // �A�N�e�B�u�Z�����G�f�B�b�g���[�h�ɂȂ��Ă��Ȃ��ꍇ�̓G�f�B�b�g���[�h�ɂ���
            //            if ((this.VarCstList_Grid.ActiveCell.IsInEditMode == false) && (this.VarCstList_Grid.ActiveCell.Activation != Infragistics.Win.UltraWinGrid.Activation.NoEdit)
            //                && (this.VarCstList_Grid.ActiveCell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
            //            {
            //                this.VarCstList_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            //                return;
            //            }
            //            // �ŏI�Z���̎�
            //            if ((this.VarCstList_Grid.ActiveCell.Row.Index == this.VarCstList_Grid.Rows.Count - 1) &&
            //                (this.VarCstList_Grid.ActiveCell.Column.Index == this.VarCstList_Grid.DisplayLayout.Bands[VARCST_TABLE].Columns.Count -1 ))
            //            {	
            //                e.NextCtrl =_nextCtrl ;
            //            }
            //            else
            //            {
            //                // ���̃Z���Ƀt�H�[�J�X�J��
            //                this.VarCstList_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
            //            }
            //        }
            //    }
            //}
            # endregion ********** Unnecessary(�s�v) **********

            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            // 2009.01.06 Add >>>
            switch (e.PrevCtrl.Name)
            {
                // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                case "AddUpADate_tDateEdit":
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else 
                        {
                            int index;
                            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
                            {
                                index = this._accRecDataIndex;
                            }
                            else
                            {
                                index = this._dmdPrcDataIndex;
                            }

                            if (index < 0)
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = AddUpADate_tDateEdit;
                                }
                            }
                        }
                        break;
                    }
                // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                case "grdDepositKind":

                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            if (grdDepositKind.ActiveCell == null)
                            {
                                return;
                            }
                            int rowIndex = grdDepositKind.ActiveCell.Row.Index;
                            // Shift�L�[��������ĂȂ��ꍇ
                            if (!e.ShiftKey)
                            {
                                if (rowIndex == grdDepositKind.Rows.Count - 1)
                                {
                                    e.NextCtrl = this.FeeNrml_tNedit;
                                    grdDepositKind.ActiveCell = null;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    grdDepositKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                    grdDepositKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                if (rowIndex == 0)
                                {
                                    e.NextCtrl = this.SaleslSlipCount_tNedit;
                                    grdDepositKind.ActiveCell = null;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    grdDepositKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                    grdDepositKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            if (e.NextCtrl == null) return;

            switch (e.NextCtrl.Name)
            {
                case "grdDepositKind":

                    // �t�H�[�J�X�����邱�Ƃ��ł��Ȃ��ꍇ�̏���
                    if (( grdDepositKind.Rows.Count == 0 ) ||
                        ( this.grdDepositKind.Rows[0].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled ))
                    {
                        if (( ( !e.ShiftKey ) && ( ( e.Key == Keys.Return ) || ( e.Key == Keys.Tab ) ) ) ||
                              ( e.Key == Keys.Right ) || ( e.Key == Keys.Left ))
                        {
                            e.NextCtrl = this.FeeNrml_tNedit;
                            break;
                        }
                        else if (( e.ShiftKey ) && ( ( e.Key == Keys.Return ) || ( e.Key == Keys.Tab ) ))
                        {
                            e.NextCtrl = this.SaleslSlipCount_tNedit;
                            break;
                        }
                        else if (e.Key == Keys.Up)
                        {
                            if (this.AddUpADate_tDateEdit.CanFocus)
                            {
                                e.NextCtrl = this.AddUpADate_tDateEdit;
                            }
                        }
                        else
                        {
                        }
                    }

                    switch (e.Key)
                    {
                        case Keys.Up:
                            e.NextCtrl = null;
                            this.grdDepositKind.DisplayLayout.Rows[grdDepositKind.Rows.Count - 1].Cells[DepositRelDataAcs.ctDeposit].Activate();
                            this.grdDepositKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            break;
                        case Keys.Tab:
                        case Keys.Return:
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = null;
                                this.grdDepositKind.DisplayLayout.Rows[grdDepositKind.Rows.Count - 1].Cells[DepositRelDataAcs.ctDeposit].Activate();
                                this.grdDepositKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                e.NextCtrl = null;
                                this.grdDepositKind.DisplayLayout.Rows[0].Cells[DepositRelDataAcs.ctDeposit].Activate();
                                this.grdDepositKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }
                            break;

                        default:
                            e.NextCtrl = null;
                            this.grdDepositKind.DisplayLayout.Rows[0].Cells[DepositRelDataAcs.ctDeposit].Activate();
                            this.grdDepositKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                    }
                    break;
                default:
                    break;
            }
            // 2009.01.06 Add <<<
        }

        # endregion

		// ===================================================================================== //
		// �{�^���C�x���g
		// ===================================================================================== //
		#region Control Button Events

        /// <summary>Control.Click �C�x���g(Cancel_Button)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///	                 �������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			Cancel_Button.Focus();
		
			bool chgMode = false;
			// ��ʋN�����I�����Ă�����
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if ((this._formBeingStarted == true) &&
				((this.Mode_Label.Text != DELETE_MODE) &&
				(this.Mode_Label.Text != REFER_MODE)))
			{
				if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
				{
					CustAccRec compareCustAccRec = new CustAccRec();
					compareCustAccRec = this._custAccRecClone;  // clone
                    if (custAccRec_Equals(this._editCustAccRec, compareCustAccRec) == false)
                    {
                        chgMode = true;
                    }
				}
				else
				{
					CustDmdPrc compareCustDmdPrc = new CustDmdPrc();
					compareCustDmdPrc = this._custDmdPrcClone;  // clone
                    if (custDmdPrc_Equals(this._editCustDmdPrc, compareCustDmdPrc) == false)
                    {
                        chgMode = true;
                    }
				}
				
				// �ۑ��m�F
				// �ŏ��Ɏ擾������ʏ��Ɣ�r
				if (chgMode == true)	
				{
					// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					DialogResult res = TMsgDisp.Show(this,                                  // �e�E�B���h�E�t�H�[��
						                             emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // �G���[���x��
						                             "SFUUKK01540U.DLL",		            // �A�Z���u���h�c�܂��̓N���X�h�c
						                             null, 					                // �\�����郁�b�Z�[�W
						                             0, 					                // �X�e�[�^�X�l
						                             MessageBoxButtons.YesNoCancel);	    // �\������{�^��
					switch(res)
					{
						case DialogResult.Yes:
						{
							// �S��ʂɔ��f���鏈��
							if (SaveProc() == false)
							{
								return;
							}
							this.DialogResult = DialogResult.OK;
							break;
						}
						case DialogResult.No:
						{
							this.DialogResult = DialogResult.Cancel;
							break;
						}
						default:
						{
                            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            if (_modeFlg)
                            {
                                AddUpADate_tDateEdit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

							return;
						}
					}
				}
			}

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// �ŏ�������t���O�̏�����
			this._accRecIndexBuf = -2;
			this._dmdPrcIndexBuf = -2;

			ScreenClear(true);
			
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
            if (CanClose == true)
            {
				this.Close();
            }
            else
            {
                this.Hide();
            }

            this._invokerForm.Focus();
		}

		/// <summary>Control.Click �C�x���g(Ok_Button)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// ��ʋN�����������Ă�����
			if (this._formBeingStarted == true )
			{
				// ��ʏ����e�[�u���Ɋi�[����
				if (SaveProc() == false)
				{
					return;
				}
			}

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// �ŏ�������t���O�̏�����
			this._accRecIndexBuf = -2;
			this._dmdPrcIndexBuf = -2;

			ScreenClear(true);

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z�����ăt�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
            this._invokerForm.Focus();
		}

        /// <summary>Control.Click �C�x���g(Delete_Button)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // �f�[�^�폜
            // �V�K�Ȃ�Ζ���
            if (this._logicalDeleteMode == -1) return;

            // �{���ɍ폜���Ă悢���̃`�F�b�N��ʂ�\�����܂��B
            DialogResult result = TMsgDisp.Show(this,
                                                emErrorLevel.ERR_LEVEL_QUESTION,
                                                "MAKAU09110U",
                                                " �폜���Ă���낵���ł����H",
                                                0,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }

            // �폜����
            DeleteProc();

            this.DialogResult = DialogResult.OK;

            ScreenClear(true);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            this._invokerForm.Focus();
        }

		/// <summary>Control.Click �C�x���g(Undo_Button)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Undo_Button_Click(object sender, System.EventArgs e)
		{
			// �N�����ɖ߂�
			ScreenClear(false);

			if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
				// ��ʕ\��		
				DetailsAccRecToScreen(this._custAccRecClone);
			}
			else
			{
				// ��ʕ\��		
				DetailsDmdPrcToScreen(this._custDmdPrcClone);
			}
			// ��ʏ�����
			Initial_Timer.Enabled = true;
		}
#if false
        /// <summary>Control.Click �C�x���g(ultraButton1)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �O��c���擾�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			// �O��c���擾����
			// ���݁A�\�����Ă���v����t�����O�R�񕪂̎c�����擾���A�ݒ肷��
			// �V�K���[�h
			if (_logicalDeleteMode == -1 )
			{
				// ���͂���Ă�����t����Ƃ���
				if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
				{
					// ���������t���`�F�b�N
                    if (TDateTime.IsAvailableDate(this.AddUpADate_tDateEdit.GetDateTime()) == false)
                    {
						// ���͂���Ă�����t���������Ȃ�
						return;
					}
				}
				else
				{
					// ���������t���`�F�b�N
                    if (TDateTime.IsAvailableDate(this.AddUpADate_tDateEdit.GetDateTime()) == false)
                        {
						// ���͂���Ă�����t���������Ȃ�
						return;
					}
				}
			}

            DateTime AddUpADate_Edit = this.AddUpADate_tDateEdit.GetDateTime();
			
			//---------------------------------
			// ���|
			//---------------------------------
			// �����f�[�^���`�F�b�N����
			if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
				// �f�[�^���P���̏ꍇ�A�O��f�[�^�����݂��Ȃ��̂Ŏ擾�͂ł��Ȃ����߁A�I��
                if ((this._logicalDeleteMode != -1) && (this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Rows.Count == 1)) return;
			
				// �\�[�g���Č����J�n���t���O�̏����擾����
                string selectCmd = REC_ADDUPDATE_TITLE + " < " + this.AddUpADate_tDateEdit.GetLongDate().ToString();
                DataRow[] dataRows = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Select(selectCmd, viewGridSortDefault);

                // �ŐV�̃��R�[�h���擾
                CustAccRec custAccRec = new CustAccRec();
                if (dataRows.Length > 0)
                {
                    DataRowToCustAccRec(dataRows[0], custAccRec);
                }

                this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(custAccRec.AcpOdrTtl2TmBfAccRec, true);
                this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(custAccRec.LastTimeAccRec, true);
                this.TtlLMBl_Label.Text = Claim_panelDataFormat(custAccRec.AfCalTMonthAccRec, true);

                this.TtlBf3TmBl_Label.Tag = custAccRec.AcpOdrTtl2TmBfAccRec;
                this.TtlBf2TmBl_Label.Tag = custAccRec.LastTimeAccRec;
                this.TtlLMBl_Label.Tag = custAccRec.AfCalTMonthAccRec;

                this.LMBl_tNedit.SetValue(custAccRec.AfCalTMonthAccRec);
                this.Bf2TmBl_tNedit.SetValue(custAccRec.LastTimeAccRec);
                this.Bf3TmBl_tNedit.SetValue(custAccRec.AcpOdrTtl2TmBfAccRec);
                
                //�擾�����O��c�Ɠ�����������_KINSET�����s
				upDateClaim_PanelTextData();
			}

            //---------------------------------
			// ����
			//---------------------------------
			else
			{
				// �f�[�^���P���̏ꍇ�A�O��f�[�^�����݂��Ȃ��̂Ŏ擾�͂ł��Ȃ����߁A�I��
                if ((this._logicalDeleteMode != -1) && (this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Rows.Count == 1)) return;

				// �\�[�g���Č����J�n���t���O�̏����擾����
                string selectCmd = REC_ADDUPDATE_TITLE + " < " + this.AddUpADate_tDateEdit.GetLongDate().ToString();
                DataRow[] dataRows = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Select(selectCmd, viewGridSortDefault);

                // �ŐV�̃��R�[�h���擾
                CustDmdPrc custDmdPrc = new CustDmdPrc();
                if (dataRows.Length > 0)
                {
                    DataRowToCustDmdPrc(dataRows[0], custDmdPrc);
                }

                this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AcpOdrTtl2TmBfBlDmd, true);
                this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(custDmdPrc.LastTimeDemand, true);
                this.TtlLMBl_Label.Text    = Claim_panelDataFormat(custDmdPrc.AfCalDemandPrice, true);

                this.TtlBf3TmBl_Label.Tag = custDmdPrc.AcpOdrTtl2TmBfBlDmd;
                this.TtlBf2TmBl_Label.Tag = custDmdPrc.LastTimeDemand;
                this.TtlLMBl_Label.Tag    = custDmdPrc.AfCalDemandPrice;

                this.LMBl_tNedit.SetValue(custDmdPrc.AfCalDemandPrice);
                this.Bf2TmBl_tNedit.SetValue(custDmdPrc.LastTimeDemand);
                this.Bf3TmBl_tNedit.SetValue(custDmdPrc.AcpOdrTtl2TmBfBlDmd);
                
                //�擾�����O��c�Ɠ�����������_KINSET�����s
				upDateClaim_PanelTextData();
			}
		}
#endif
        # endregion

		// ===================================================================================== //
		// ���ڃC�x���g
		// ===================================================================================== //
		#region Control Component Events

        /// <summary>Enter �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�ɂȂ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Control_Enter(object sender, System.EventArgs e)
        {
            this._changeFlg = false;
            if (sender.GetType().Name == "TDateEdit")
            {
                befTempDateTime = TDateTime.LongDateToDateTime(AddUpADate_tDateEdit.LongDate);
            }
        }

        /// <summary>ValueChanged �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���͓��e�ɕύX�����������Ƃ��Ɏ��s����܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Control_ValueChanged(object sender, System.EventArgs e)
        {
            if (this._formBeingStarted == false) return;
            this._changeFlg = true;
        }

        /// <summary>Leave �C�x���g(����)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Sales_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // ���㍇�v���z���x���̔��f
            update_SalesTotalLabel();

            // 2009.01.06 Add >>>
            // ���E�㔄��O�őΏۊz���x���̔��f
            if (sender == this.ItdedSalesOutTax_tNedit)
            {
                this.update_ItdedOffsetOutTaxLabel();
            }
            // ���E���ېőΏۊz���x���̔��f
            else if (sender == this.ItdedSalesTaxFree_tNedit)
            {
                this.update_ItdedOffsetTaxFreeLabel();
            }
            // ���E�㔄�㍇�v���x���̔��f
            this.update_OfsThisTimeSalesTotalLabel();
            // �ō��ݍ��v���x���̔��f
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 2009.01.06 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (ctrlTNedit.Name == "ItdedSalesOutTax_tNedit")
            //{
            //    update_ItdedOutTaxTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "SalesOutTax_tNedit")
            //{
            //    update_OutTaxTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "ItdedSalesInTax_tNedit")
            //{
            //    update_ItdedInTaxTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "SalesInTax_tNedit")
            //{
            //    update_InTaxTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "ItdedSalesTaxFree_tNedit")
            //{
            //    update_ItdedTaxFreeTotalLabel();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }

        /// <summary>Leave �C�x���g(�ԕi)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void Ret_tNedit_Leave ( object sender, System.EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = ( TNedit ) sender;

            if ( ctrlTNedit == null ) return;

            // �ԕi���v���z���x���̔��f
            update_RetTotalLabel();

            // 2009.01.06 Add >>>
            // ���E�㔄��O�őΏۊz���x���̔��f
            if (sender == this.TtlItdedRetOutTax_tNedit)
            {
                this.update_ItdedOffsetOutTaxLabel();
            }
            // ���E���ېőΏۊz���x���̔��f
            else if (sender == TtlItdedRetTaxFree_tNedit)
            {
                this.update_ItdedOffsetTaxFreeLabel();
            }
            // ���E�㔄�㍇�v���x���̔��f
            this.update_OfsThisTimeSalesTotalLabel();
            // �ō��ݍ��v���x���̔��f
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 2009.01.06 Add <<<

            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }
        /// <summary>Leave �C�x���g(�l��)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void Dis_tNedit_Leave ( object sender, System.EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = ( TNedit ) sender;

            if ( ctrlTNedit == null ) return;

            // �l�����v���z���x���̔��f
            update_DisTotalLabel();

            // 2009.01.06 Add >>>
            // ���E�㔄��O�őΏۊz���x���̔��f
            if (sender == this.TtlItdedDisOutTax_tNedit)
            {
                this.update_ItdedOffsetOutTaxLabel();
            }
            // ���E���ېőΏۊz���x���̔��f
            else if (sender == this.TtlItdedDisTaxFree_tNedit)
            {
                this.update_ItdedOffsetTaxFreeLabel();
            }
            // ���E�㔄�㍇�v���x���̔��f
            this.update_OfsThisTimeSalesTotalLabel();
            // �ō��ݍ��v���x���̔��f
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 2009.01.06 Add <<<


            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }
        /// <summary>Leave �C�x���g(�x��)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void ItdedPaym_tNedit_Leave( object sender, EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if ( ctrlTNedit == null ) return;

            // ���E�d�����z���x���̔��f
            update_ItdedPaymTotalLabel();

            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }

        /// <summary>Leave �C�x���g(���̂ق�)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Other_tNedit_Leave ( object sender, System.EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = ( TNedit ) sender;

            if ( ctrlTNedit == null ) return;

            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }
        /// <summary>Leave �C�x���g(���t)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void DateEdit_Leave ( object sender, EventArgs e )
        {
            // ���ւ̔��f
            upDateClaim_PanelTextData();
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>Leave �C�x���g(�x��)</summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void Payment_tNedit_Leave(object sender, System.EventArgs e)
        //{
        //    if (this._changeFlg == false) return;

        //    TNedit ctrlTNedit = (TNedit)sender;

        //    if (ctrlTNedit == null) return;

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// �x�����v���z���x���̔��f
        //    //update_PaymTotalLabel();
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //if (ctrlTNedit.Name == "ItdedPaymOutTax_tNedit")
        //    //{
        //    //    update_ItdedOutTaxTotalLabel();
        //    //}
        //    //else if (ctrlTNedit.Name == "PaymentOutTax_tNedit")
        //    //{
        //    //    update_OutTaxTotalLabel();
        //    //}
        //    //else if (ctrlTNedit.Name == "ItdedPaymInTax_tNedit")
        //    //{
        //    //    update_ItdedInTaxTotalLabel();
        //    //}
        //    //else if (ctrlTNedit.Name == "PaymentInTax_tNedit")
        //    //{
        //    //    update_InTaxTotalLabel();
        //    //}
        //    //else if (ctrlTNedit.Name == "ItdedPaymTaxFree_tNedit")
        //    //{
        //    //    update_ItdedTaxFreeTotalLabel();
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    // �ӂւ̔��f
        //    upDateClaim_PanelTextData();
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>Leave �C�x���g(�ʏ����)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Normal_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // �������v���z���x���̔��f
            update_NormalTotalLabel();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (ctrlTNedit.Name == "DepoNrml_tNedit")
            //{
            //    update_DepoPrcTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "FeeNrml_tNedit")
            //{
            //    update_FeeTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "DisNrml_tNedit")
            //{
            //    update_DisTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "RbtNrml_tNedit")
            //{
            //    update_RbtTotalLabel();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }

        ///// <summary>Leave �C�x���g(�a���)</summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void Deposit_tNedit_Leave(object sender, System.EventArgs e)
        //{
        //    if (this._changeFlg == false) return;

        //    TNedit ctrlTNedit = (TNedit)sender;

        //    if (ctrlTNedit == null) return;

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// �������v���z���x���̔��f
        //    //update_DepoTotalLabel();

        //    //if (ctrlTNedit.Name == "Depo_tNedit")
        //    //{
        //    //    update_DepoPrcTotalLabel();
        //    //}
        //    //else if (ctrlTNedit.Name == "FeeDepo_tNedit")
        //    //{
        //    //    update_FeeTotalLabel();
        //    //}
        //    //else if (ctrlTNedit.Name == "DisDepo_tNedit")
        //    //{
        //    //    update_DisTotalLabel();
        //    //}
        //    //else if (ctrlTNedit.Name == "RbtDepo_tNedit")
        //    //{
        //    //    update_RbtTotalLabel();
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    // �ӂւ̔��f
        //    upDateClaim_PanelTextData();
        //}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>Leave �C�x���g(�݌ɒ���)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void BalanceAdjust_tNedit_Leave ( object sender, System.EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = ( TNedit ) sender;

            if ( ctrlTNedit == null ) return;
            //this._editCustAccRec.AfCalTMonthAccRec
            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>Leave �C�x���g(AcpOdrTtlLMBlDmd_tNedit)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AcpOdrTtlLMBlDmd_tNedit_Leave(object sender, System.EventArgs e)
		{
			if ( this._changeFlg == false ) return;

            // 2009.01.06 >>>
            //// �O��c��
            //double acpOdrTtlLMBl  = this.LMBl_tNedit.GetValue();
            //TtlLMBl_Label.Text    = Claim_panelDataFormat((Int64)acpOdrTtlLMBl, true);
            //// 2��ȑO�c��
            //double acpOdrTtlLMBl2 = this.Bf2TmBl_tNedit.GetValue();
            //TtlBf2TmBl_Label.Text = Claim_panelDataFormat((Int64)acpOdrTtlLMBl2, true);
            //// 3��ȑO�c��
            //double acpOdrTtlLMBl3 = this.Bf3TmBl_tNedit.GetValue();
            //TtlBf3TmBl_Label.Text = Claim_panelDataFormat((Int64)acpOdrTtlLMBl3, true);

            // �O��c��
            if (sender == LMBl_tNedit)
            {
                double acpOdrTtlLMBl = this.LMBl_tNedit.GetValue();
                this._totalDisplayTable.Rows[0][BalanceDisplayTable.ct_Col_TOTAL1_BEF] = (Int64)acpOdrTtlLMBl;
            }
            // 2��ȑO�c��
            if (sender == Bf2TmBl_tNedit)
            {
                double acpOdrTtlLMBl2 = this.Bf2TmBl_tNedit.GetValue();
                this._totalDisplayTable.Rows[0][BalanceDisplayTable.ct_Col_TOTAL2_BEF] = (Int64)acpOdrTtlLMBl2;
            }
            // 3��ȑO�c��
            if (sender == Bf3TmBl_tNedit)
            {
                double acpOdrTtlLMBl3 = this.Bf3TmBl_tNedit.GetValue();
                this._totalDisplayTable.Rows[0][BalanceDisplayTable.ct_Col_TOTAL3_BEF] = (Int64)acpOdrTtlLMBl3;
            }

            // �c�����v�̍X�V

            this.update_BlTotalLabel();
            // 2009.01.06 <<<

			upDateClaim_PanelTextData();
		}

        private bool _addUpADateLeaving = false;
        /// <summary>Leave �C�x���g(AddUpADate_tDateEdit)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����A�N�e�B�u�łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AddUpADate_tDateEdit_Leave(object sender, System.EventArgs e)
		{
            if (this._addUpADateLeaving) return;

            try
            {
                this._addUpADateLeaving = true;
                if (this.AddUpADate_tDateEdit.LongDate == 0) return;

                // ���|
                //if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
                //{
                //    this.AddUpADate_tDateEdit.SetLongDate(this.AddUpADate_tDateEdit.LongDate + 1);
                //}

                if (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(this.AddUpADate_tDateEdit.LongDate)) == false)
                {
                    TMsgDisp.Show(this,											// �e�E�B���h�E�t�H�[��
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,			// �G���[���x��
                                  "",											// �A�Z���u���h�c�܂��̓N���X�h�c
                                  "���������t��ݒ肵�ĉ������B",				// �\�����郁�b�Z�[�W 
                                  0,											// �X�e�[�^�X�l
                                  MessageBoxButtons.OK);						// �\������{�^��

                    this.AddUpADate_tDateEdit.LongDate = 0;
                    this.AddUpADate_tDateEdit.Focus();
                    return;
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                upDateClaim_PanelTextData();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            }
            finally
            {
                this._addUpADateLeaving = false;
            }
        }

        /// <summary>KeyPress �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[���͂��ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void tNedit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Grid�̓��͕����ɍ��킹�鏈�� Grid�̌����ɂ̓}�C�i�X�������܂܂Ȃ������ŏ������Ă���ׁA
            // Edit�͌����̓}�C�i�X�������܂ތ����Ƃ��A���͂��ꂽ�������}�C�i�X���Ȃ����1�����炵�������Ƃ��鏈��������
            TNedit chk_tNedit = (TNedit)sender;

            int selstart = chk_tNedit.SelectionStart;// 0;
            int sellength = chk_tNedit.TextLength - chk_tNedit.SelectionStart;
            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";

            // ���̏����ƑS�������ϐ����g���Ă��邽�ߍ폜 2008.10.14
            //if (chk_tNedit.TextLength > 0)
            //{
            //    _strResult = chk_tNedit.Text.Substring(0, selstart) + chk_tNedit.Text.Substring(selstart + sellength, chk_tNedit.Text.Length - (selstart + sellength));
            //}
            //else
            //{
            //    _strResult = chk_tNedit.Text;
            //}

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = chk_tNedit.Text.Substring(0, selstart)
                       + e.KeyChar
                       + chk_tNedit.Text.Substring(selstart + sellength, chk_tNedit.Text.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > chk_tNedit.ExtEdit.Column - 1)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > chk_tNedit.ExtEdit.Column)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        # endregion

        // ===================================================================================== //
        // �������\�b�h(���v�v�Z)
        // ===================================================================================== //
        # region Private Methods_Total_Calculate

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>�O�őΏۊz���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : �O�őΏۊz�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_ItdedOutTaxTotalLabel()
        //{
        //    double ItdedOutTaxTotal = this.ItdedSalesOutTax_tNedit.GetValue() -       // ����O�őΏۊz
        //                              this.ItdedPaymOutTax_tNedit.GetValue();         // �x���O�őΏۊz
        //    this.ItdedOutTaxTotal_Label.Text = Claim_panelDataFormat((Int64)ItdedOutTaxTotal, false);
        //}

        ///// <summary>�O�Ŋz���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : �O�Ŋz�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_OutTaxTotalLabel()
        //{
        //    double OutTaxTotal = this.SalesOutTax_tNedit.GetValue() -       // ����O�Ŋz
        //                         this.PaymentOutTax_tNedit.GetValue();      // �x���O�Ŋz
        //    this.OutTaxTotal_Label.Text = Claim_panelDataFormat((Int64)OutTaxTotal, false);
        //}

        ///// <summary>���őΏۊz���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : ���őΏۊz�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_ItdedInTaxTotalLabel()
        //{
        //    double ItdedInTaxTotal = this.ItdedSalesInTax_tNedit.GetValue() -       // ������őΏۊz
        //                             this.ItdedPaymInTax_tNedit.GetValue();         // �x�����őΏۊz
        //    this.ItdedInTaxTotal_Label.Text = Claim_panelDataat((Int64)ItdedInTaxTotal, false);
        //}

        ///// <summary>���Ŋz���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : ���Ŋz�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_InTaxTotalLabel()
        //{
        //    double InTaxTotal = this.SalesInTax_tNedit.GetValue() -       // ������Ŋz
        //                        this.PaymentInTax_tNedit.GetValue();      // �x�����Ŋz
        //    this.InTaxTotal_Label.Text = Claim_panelDataFormat((Int64)InTaxTotal, false);
        //}

        ///// <summary>��ېőΏۊz���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : ��ېőΏۊz�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_ItdedTaxFreeTotalLabel()
        //{
        //    double ItdedTaxFreeTotal = this.ItdedSalesTaxFree_tNedit.GetValue() -       // �����ېőΏۊz
        //                               this.ItdedPaymTaxFree_tNedit.GetValue();         // �x����ېőΏۊz
        //    this.ItdedTaxFreeTotal_Label.Text = Claim_panelDataFormat((Int64)ItdedTaxFreeTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>�������z���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : �������z�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_DepoPrcTotalLabel()
        //{
        //    double DepoPrcTotal = this.DepoNrml_tNedit.GetValue() +     // �ʏ�������z
        //                          this.Depo_tNedit.GetValue();          // �a����������z
        //    this.DepoPrcTotal_Label.Text = Claim_panelDataFormat((Int64)DepoPrcTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>�萔���z���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : �萔���z�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_FeeTotalLabel()
        //{
        //    double FeeTotal = this.FeeNrml_tNedit.GetValue() +          // �ʏ�萔���z
        //                      this.FeeDepo_tNedit.GetValue();           // �a����萔���z
        //    this.FeeTotal_Label.Text = Claim_panelDataFormat((Int64)FeeTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>�l���z���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : �l���z�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_DisTotalLabel()
        //{
        //    double DisTotal = this.DisNrml_tNedit.GetValue() +          // �ʏ�l���z
        //                      this.DisDepo_tNedit.GetValue();           // �a����l���z
        //    this.DisTotal_Label.Text = Claim_panelDataFormat((Int64)DisTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>���x�[�g�z���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : ���x�[�g�z�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_RbtTotalLabel()
        //{
        //    double RbtTotal = this.RbtNrml_tNedit.GetValue() +          // �ʏ탊�x�[�g�z
        //                      this.RbtDepo_tNedit.GetValue();           // �a������x�[�g�z
        //    this.RbtTotal_Label.Text = Claim_panelDataFormat((Int64)RbtTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // 2009.01.06 Del >>>
        //public void update_TtlBl_Label()
        //{
        //    double salesTotal = this.ItdedSalesOutTax_tNedit.GetValue() +       // ����O�őΏۊz
        //                        this.SalesOutTax_tNedit.GetValue() +       // ����O�Ŋz
        //                        this.ItdedSalesInTax_tNedit.GetValue() +       // ������őΏۊz
        //                        this.SalesInTax_tNedit.GetValue() +       // ������Ŋz
        //                        this.ItdedSalesTaxFree_tNedit.GetValue();       // �����ېőΏۊz
        //    TtlBl_Label.Text = Claim_panelDataFormat((Int64)salesTotal, false);
        //}
        // 2009.01.06 Del <<<

        /// <summary>����z���v�v�Z</summary>
        /// <remarks>
        /// <br>Note       : ����z�̍��v�v�Z���s��</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void update_SalesTotalLabel()
        {
            // 2009.01.06 >>>
            //double salesTotal = this.ItdedSalesOutTax_tNedit.GetValue() +       // ����O�őΏۊz
            //                    this.SalesOutTax_tNedit.GetValue()      +       // ����O�Ŋz
            //                    this.ItdedSalesInTax_tNedit.GetValue()  +       // ������őΏۊz
            //                    this.SalesInTax_tNedit.GetValue()       +       // ������Ŋz
            //                    this.ItdedSalesTaxFree_tNedit.GetValue();       // �����ېőΏۊz
            double salesTotal = this.ItdedSalesOutTax_tNedit.GetValue() +       // ����O�őΏۊz
                                this.ItdedSalesInTax_tNedit.GetValue() +        // ������őΏۊz
                                this.ItdedSalesTaxFree_tNedit.GetValue();       // �����ېőΏۊz
            // 2009.01.06 <<<
            SalesTotal_Label.Text = Claim_panelDataFormat((Int64)salesTotal, false);
        }
        /// <summary>�ԕi�z���v�v�Z</summary>
        /// <remarks>
        /// <br>Note       : �ԕi�z�̍��v�v�Z���s��</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void update_RetTotalLabel ()
        {
            // 2009.01.06 >>>
            //double retTotal   = this.TtlItdedRetOutTax_tNedit.GetValue() +       // �ԕi�O�őΏۊz
            //                    this.TtlRetOuterTax_tNedit.GetValue() +          // �ԕi�O�Ŋz
            //                    this.TtlItdedRetInTax_tNedit.GetValue() +        // �ԕi���őΏۊz
            //                    this.TtlRetInnerTax_tNedit.GetValue() +          // �ԕi���Ŋz
            //                    this.TtlItdedRetTaxFree_tNedit.GetValue();       // �ԕi��ېőΏۊz
            double retTotal = this.TtlItdedRetOutTax_tNedit.GetValue() +       // �ԕi�O�őΏۊz
                                this.TtlItdedRetInTax_tNedit.GetValue() +        // �ԕi���őΏۊz
                                this.TtlItdedRetTaxFree_tNedit.GetValue();       // �ԕi��ېőΏۊz
            // 2009.01.06 <<<
            RetTotal_Label.Text = Claim_panelDataFormat((Int64)retTotal, false);
        }
        /// <summary>�l���z���v�v�Z</summary>
        /// <remarks>
        /// <br>Note       : �l���z�̍��v�v�Z���s��</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void update_DisTotalLabel ()
        {
            // 2009.01.06 >>>
            //double disTotal   = this.TtlItdedDisOutTax_tNedit.GetValue() +       // �l���O�őΏۊz
            //                    this.TtlDisOuterTax_tNedit.GetValue() +          // �l���O�Ŋz
            //                    this.TtlItdedDisInTax_tNedit.GetValue() +        // �l�����őΏۊz
            //                    this.TtlDisInnerTax_tNedit.GetValue() +          // �l�����Ŋz
            //                    this.TtlItdedDisTaxFree_tNedit.GetValue();       // �l����ېőΏۊz

            double disTotal = this.TtlItdedDisOutTax_tNedit.GetValue() +       // �l���O�őΏۊz
                                this.TtlItdedDisInTax_tNedit.GetValue() +        // �l�����őΏۊz
                                this.TtlItdedDisTaxFree_tNedit.GetValue();       // �l����ېőΏۊz
            // 2009.01.06 <<<
            DisTotal_Label.Text = Claim_panelDataFormat((Int64)disTotal, false);
        }

        // 2009.01.06 Add >>>
        /// <summary>���E��O�őΏۊz�v�Z</summary>
        /// <remarks>
        /// <br>Note       : ���E��O�őΏۊz�̌v�Z���s��</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_ItdedOffsetOutTaxLabel()
        {
            long total = (Int64)this.ItdedSalesOutTax_tNedit.GetValue() -       // ����O�őΏۊz
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // �ԕi�O�őΏۊz
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();       // �l���O�őΏۊz
            ItdedOffsetOutTax_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>���E���ېőΏۊz�v�Z</summary>
        /// <remarks>
        /// <br>Note       : ���E���ېőΏۊz�̌v�Z���s��</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_ItdedOffsetTaxFreeLabel()
        {
            long total = (Int64)this.ItdedSalesTaxFree_tNedit.GetValue() -      // �����ېőΏۊz
                         (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue() -     // �ԕi��ېőΏۊz
                         (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();      // �l����ېőΏۊz
            ItdedOffsetTaxFree_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>���E�㍡�񔄏���z�v�Z</summary>
        /// <remarks>
        /// <br>Note       : ���E���ېőΏۊz�̌v�Z���s��</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_OfsThisTimeSalesTotalLabel()
        {
            long total = (Int64)this.ItdedSalesOutTax_tNedit.GetValue() -       // ����O�őΏۊz
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // �ԕi�O�őΏۊz
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue() +      // �l���O�őΏۊz
                         (Int64)this.ItdedSalesInTax_tNedit.GetValue() -        // ������őΏۊz
                         (Int64)this.TtlItdedRetInTax_tNedit.GetValue() -       // �ԕi���őΏۊz
                         (Int64)this.TtlItdedDisInTax_tNedit.GetValue() +       // �l�����őΏۊz
                         (Int64)this.ItdedSalesTaxFree_tNedit.GetValue() -      // �����ېőΏۊz
                         (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue() -     // �ԕi��ېőΏۊz
                         (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();      // �l����ېőΏۊz
            OfsThisTimeSales_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>
        /// �c�����v�v�Z
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�����v�̌v�Z���s��</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_BlTotalLabel()
        {
            long total = (Int64)this.Bf3TmBl_tNedit.GetValue() +    // �O�X�X��c��
                         (Int64)this.Bf2TmBl_tNedit.GetValue() +    // �O�X��c��
                         (Int64)this.LMBl_tNedit.GetValue();        // �O��c��
            this.BlTotal_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>
        /// �ō����z�v�Z
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ō����v�̌v�Z���s��</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_OfsThisTimeSalesTaxIncLabel()
        {
            long total = (Int64)this.ItdedSalesOutTax_tNedit.GetValue() -       // ����O�őΏۊz
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // �ԕi�O�őΏۊz
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue() +      // �l���O�őΏۊz
                         (Int64)this.ItdedSalesInTax_tNedit.GetValue() -        // ������őΏۊz
                         (Int64)this.TtlItdedRetInTax_tNedit.GetValue() -       // �ԕi���őΏۊz
                         (Int64)this.TtlItdedDisInTax_tNedit.GetValue() +       // �l�����őΏۊz
                         (Int64)this.ItdedSalesTaxFree_tNedit.GetValue() -      // �����ېőΏۊz
                         (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue() -     // �ԕi��ېőΏۊz
                         (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue() +     // �l����ېőΏۊz
                         (Int64)this.OfsThisSalesTax_tNedit.GetValue();         // ����ō��v

            this.OfsThisTimeSalesTaxInc_Label.Text = Claim_panelDataFormat(total, false);
        }
        // 2009.01.06 Add <<<
        /// <summary>���E�x�����v�v�Z</summary>
        /// <remarks>
        /// <br>Note       : ���E�x���z�̍��v�v�Z���s��</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.12.21</br>
        /// </remarks>
        private void update_ItdedPaymTotalLabel ()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //double itdedPaymTotal = this.ItdedPaymOutTax_tNedit.GetValue() +    // �x���O�őΏۊz
                                    //this.PaymentOutTax_tNedit.GetValue() +      // �x���O�Ŋz
                                    //this.ItdedPaymInTax_tNedit.GetValue() +     // �x�����őΏۊz
                                    //this.PaymentInTax_tNedit.GetValue() +       // �x�����Ŋz
                                    //this.ItdedPaymTaxFree_tNedit.GetValue();    // �x����ېőΏۊz

            //ItdedPaymTotal_Label.Text = Claim_panelDataFormat( (Int64)itdedPaymTotal, false );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>�x���z���v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : �x���z�̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_PaymTotalLabel()
        //{
        //    double PaymTotal = this.ItdedPaymOutTax_tNedit.GetValue() +     // �x���O�őΏۊz
        //                       this.PaymentOutTax_tNedit.GetValue()   +     // �x���O�Ŋz
        //                       this.ItdedPaymInTax_tNedit.GetValue()  +     // �x�����őΏۊz
        //                       this.PaymentInTax_tNedit.GetValue()    +     // �x�����Ŋz
        //                       this.ItdedPaymTaxFree_tNedit.GetValue();     // �x����ېőΏۊz
        //    PaymTotal_Label.Text = Claim_panelDataFormat((Int64)PaymTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>�ʏ�������v�v�Z</summary>
        /// <remarks>
        /// <br>Note       : �ʏ�����̍��v�v�Z���s��</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void update_NormalTotalLabel()
        {
            // 2009.01.06 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////double NormalTotal = this.DepoNrml_tNedit.GetValue() +     // �ʏ�������z
            ////                     this.FeeNrml_tNedit.GetValue()  +     // �ʏ�萔���z
            ////                     this.DisNrml_tNedit.GetValue()  +     // �ʏ�l���z
            ////                     this.RbtNrml_tNedit.GetValue();       // �ʏ탊�x�[�g�z
            //double NormalTotal = this.DepoNrml_tNedit.GetValue() +     // �ʏ�������z
            //                     this.FeeNrml_tNedit.GetValue() +     // �ʏ�萔���z
            //                     this.DisNrml_tNedit.GetValue();     // �ʏ�l���z
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //NrmlTotal_Label.Text = Claim_panelDataFormat((Int64)NormalTotal, false);

            // ����̍��v
            object value = this._depositDataTable.Compute(string.Format("SUM({0})", DepositRelDataAcs.ctDeposit), string.Empty);
            Int64 total = ( value is DBNull ) ? 0 : (Int64)value;

            total += (Int64)this.FeeNrml_tNedit.GetValue() + (long)this.DisNrml_tNedit.GetValue();

            NrmlTotal_Label.Text = Claim_panelDataFormat(total, false);
            // 2009.01.06 <<<
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>�a������v�v�Z</summary>
        ///// <remarks>
        ///// <br>Note       : �a����̍��v�v�Z���s��</br>
        ///// <br>Programmer : 30154 �����@���m</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_DepoTotalLabel()
        //{
        //    double DepositTotal = this.Depo_tNedit.GetValue()    +     // �a����������z
        //                          this.FeeDepo_tNedit.GetValue() +     // �a����萔���z
        //                          this.DisDepo_tNedit.GetValue() +     // �a����l���z
        //                          this.RbtDepo_tNedit.GetValue();      // �a������x�[�g�z
        //    DepoTotal_Label.Text = Claim_panelDataFormat((Int64)DepositTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        # endregion

        /// <summary>DataRow���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g�W�J����</summary>
        /// <param name="dr">���Ӑ攄�|���z���DataTable��DataRow</param>
        /// <param name="custAccRec">���Ӑ攄�|���z�}�X�^�N���X</param>
        /// <param name="accRecDepoTotalList">���|�����W�v�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �Ώۂ�DataRow���瓾�Ӑ攄�|���z�}�X�^�I�u�W�F�N�g�֊i�[����</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        // 2009.01.06 >>>
        //private void DataRowToCustAccRec(DataRow dr, CustAccRec custAccRec)
        private void DataRowToCustAccRec(DataRow dr, out  CustAccRec custAccRec, out List<AccRecDepoTotal> accRecDepoTotalList)
        // 2009.01.06 <<<
        {
            // 2009.01.06 Add >>>
            custAccRec = new CustAccRec();
            accRecDepoTotalList = new List<AccRecDepoTotal>();
            // 2009.01.06 Add <<<

            custAccRec.EnterpriseCode       = this._enterpriseCode;
            custAccRec.AddUpSecCode         = dr[CustAccRecDmdPrcAcs.COL_ADDUPSECCODE_TITLE].ToString();
            custAccRec.CustomerCode         = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_CUSTOMERCODE_TITLE].ToString());
            custAccRec.CustomerName         = dr[CustAccRecDmdPrcAcs.COL_CUSTOMERNAME_TITLE].ToString();
            custAccRec.CustomerName2        = dr[CustAccRecDmdPrcAcs.COL_CUSTOMERNAME2_TITLE].ToString();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custAccRec.CustomerSnm          = dr[CustAccRecDmdPrcAcs.COL_CUSTOMERSNM_TITLE].ToString();
            custAccRec.ClaimCode            = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_CLAIMCODE_TITLE].ToString());
            custAccRec.ClaimName            = dr[CustAccRecDmdPrcAcs.COL_CLAIMNAME_TITLE].ToString();
            custAccRec.ClaimName2           = dr[CustAccRecDmdPrcAcs.COL_CLAIMNAME2_TITLE].ToString();
            custAccRec.ClaimSnm             = dr[CustAccRecDmdPrcAcs.COL_CLAIMSNM_TITLE].ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.AddUpDate            = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE].ToString());
            //custAccRec.AddUpYearMonth       = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_ADDUPYEARMONTH_TITLE].ToString());
            custAccRec.AddUpDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE].ToString()));
            custAccRec.AddUpYearMonth = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_ADDUPYEARMONTH_TITLE].ToString()));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custAccRec.LastTimeAccRec       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_LASTTIMEACCREC_TITLE].ToString());
            custAccRec.ThisTimeDmdNrml      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEDMDNRML_TITLE].ToString());
            custAccRec.ThisTimeFeeDmdNrml   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDNRML_TITLE].ToString());
            custAccRec.ThisTimeDisDmdNrml   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDNRML_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.ThisTimeRbtDmdNrml   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDNRML_TITLE].ToString());
            //custAccRec.ThisTimeDmdDepo      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEDMDDEPO_TITLE].ToString());
            //custAccRec.ThisTimeFeeDmdDepo   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDDEPO_TITLE].ToString());
            //custAccRec.ThisTimeDisDmdDepo   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDDEPO_TITLE].ToString());
            //custAccRec.ThisTimeRbtDmdDepo   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDDEPO_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custAccRec.ThisTimeTtlBlcAcc    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMETTLBLCACC_TITLE].ToString());
            custAccRec.ThisTimeSales        = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMESALES_TITLE].ToString());
            custAccRec.ThisSalesTax         = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISSALESTAX_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.TtlIncDtbtTaxExc     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLINCDTBTTAXEXC_TITLE].ToString());
            //custAccRec.TtlIncDtbtTax        = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLINCDTBTTAX_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custAccRec.OfsThisTimeSales     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_OFSTHISTIMESALES_TITLE].ToString());
            custAccRec.OfsThisSalesTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_OFSTHISSALESTAX_TITLE].ToString());
            custAccRec.ItdedOffsetOutTax    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDOFFSETOUTTAX_TITLE].ToString());
            custAccRec.ItdedOffsetInTax     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDOFFSETINTAX_TITLE].ToString());
            custAccRec.ItdedOffsetTaxFree   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDOFFSETTAXFREE_TITLE].ToString());
            custAccRec.OffsetOutTax         = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_OFFSETOUTTAX_TITLE].ToString());
            custAccRec.OffsetInTax          = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_OFFSETINTAX_TITLE].ToString());
            custAccRec.ItdedSalesOutTax     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDSALESOUTTAX_TITLE].ToString());
            custAccRec.ItdedSalesInTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDSALESINTAX_TITLE].ToString());
            custAccRec.ItdedSalesTaxFree    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDSALESTAXFREE_TITLE].ToString());
            custAccRec.SalesOutTax          = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_SALESOUTTAX_TITLE].ToString());
            custAccRec.SalesInTax           = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_SALESINTAX_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custAccRec.TtlItdedRetOutTax    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDRETOUTTAX_TITLE].ToString());
            custAccRec.TtlItdedRetInTax     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDRETINTAX_TITLE].ToString());
            custAccRec.TtlItdedRetTaxFree   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDRETTAXFREE_TITLE].ToString());
            custAccRec.TtlRetOuterTax       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLRETOUTERTAX_TITLE].ToString());
            custAccRec.TtlRetInnerTax       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLRETINNERTAX_TITLE].ToString());
            custAccRec.TtlItdedDisOutTax    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDDISOUTTAX_TITLE].ToString());
            custAccRec.TtlItdedDisInTax     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDDISINTAX_TITLE].ToString());
            custAccRec.TtlItdedDisTaxFree   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDDISTAXFREE_TITLE].ToString());
            custAccRec.TtlDisOuterTax       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLDISOUTERTAX_TITLE].ToString());
            custAccRec.TtlDisInnerTax       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLDISINNERTAX_TITLE].ToString());
            custAccRec.BalanceAdjust        = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE].ToString());


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //custAccRec.NonStmntAppearance = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_NONSTMNTAPPEARANCE_TITLE].ToString());
            //custAccRec.NonStmntIsdone       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_NONSTMNTISDONE_TITLE].ToString());
            //custAccRec.StmntAppearance      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_STMNTAPPEARANCE_TITLE].ToString());
            //custAccRec.StmntIsdone          = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_STMNTISDONE_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //custAccRec.ThisCashSalePrice    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISCASHSALEPRICE].ToString());
            //custAccRec.ThisCashSaleTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISCASHSALETAX].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.ItdedPaymOutTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE].ToString());
            //custAccRec.ItdedPaymInTax       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE].ToString());
            //custAccRec.ItdedPaymTaxFree     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE].ToString());
            //custAccRec.PaymentOutTax        = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE].ToString());
            //custAccRec.PaymentInTax         = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custAccRec.ConsTaxLayMethod     = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_CONSTAXLAYMETHOD_TITLE].ToString());
            custAccRec.ConsTaxRate          = Double.Parse(dr[CustAccRecDmdPrcAcs.COL_CONSTAXRATE_TITLE].ToString());
            custAccRec.FractionProcCd       = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString());
            custAccRec.AfCalTMonthAccRec = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_AFCALTMONTHACCREC_TITLE].ToString());
                //+ Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE].ToString())
                //+ Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE].ToString());
            custAccRec.AcpOdrTtl2TmBfAccRec = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ACPODRTTL2TMBFACCREC_TITLE].ToString());
            custAccRec.AcpOdrTtl3TmBfAccRec = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ACPODRTTL3TMBFACCREC_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.MonthAddUpExpDate    = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_MONTHADDUPEXPDATE_TITLE].ToString());
            custAccRec.MonthAddUpExpDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_MONTHADDUPEXPDATE_TITLE].ToString()));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRec.ThisPayOffset = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_THISPAYOFFSET_TITLE].ToString() ); // ����x�����E���z
            //custAccRec.ThisPayOffsetTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_THISPAYOFFSETTAX_TITLE].ToString() ); // ����x�����E�����
            //custAccRec.ItdedPaymOutTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE].ToString() ); // �x���O�őΏۊz
            //custAccRec.ItdedPaymInTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE].ToString() ); // �x�����őΏۊz
            //custAccRec.ItdedPaymTaxFree = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE].ToString() ); // �x����ېőΏۊz
            //custAccRec.PaymentOutTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE].ToString() ); // �x���O�ŏ����
            //custAccRec.PaymentInTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE].ToString() ); // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            custAccRec.TaxAdjust = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE].ToString() ); // ����Œ����z
            custAccRec.SalesSlipCount = Int32.Parse( dr[CustAccRecDmdPrcAcs.COL_SALESSLIPCOUNT_TITLE].ToString() ); // ����`�[����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            

            custAccRec.FileHeaderGuid = (Guid)dr[CustAccRecDmdPrcAcs.COL_GUID_TITLE];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custAccRec.CreateDateTime = (DateTime)dr[CustAccRecDmdPrcAcs.COL_CREATEDATETIME];
            custAccRec.UpdateDateTime = (DateTime)dr[CustAccRecDmdPrcAcs.COL_UPDATEDATETIME];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            custAccRec.StMonCAddUpUpdDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_STMONCADDUPUPDDATE_TITLE].ToString()));
            custAccRec.LaMonCAddUpUpdDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_LAMONCADDUPUPDDATE_TITLE].ToString()));
            accRecDepoTotalList = (List<AccRecDepoTotal>)dr[CustAccRecDmdPrcAcs.COL_DEPOTOTAL];
            // 2009.01.06 Add <<<
        }

        /// <summary>DataRow���Ӑ搿�����z�}�X�^�I�u�W�F�N�g�W�J����</summary>
        /// <param name="dr">���Ӑ搿�����z���DataTable��DataRow</param>
        /// <param name="custDmdPrc">���Ӑ搿�����z�}�X�^�N���X</param>
        /// <param name="dmdDepoTotalList">�������������W�v�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �Ώۂ�DataRow���瓾�Ӑ搿�����z�}�X�^�I�u�W�F�N�g�֊i�[����</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        // 2009.01.06 >>>
        //private void DataRowToCustDmdPrc(DataRow dr, CustDmdPrc custDmdPrc)
        private void DataRowToCustDmdPrc(DataRow dr, out  CustDmdPrc custDmdPrc, out List<DmdDepoTotal> dmdDepoTotalList)
        // 2009.01.06 <<<
        {
            // 2009.01.06 Add >>>
            custDmdPrc = new CustDmdPrc();
            dmdDepoTotalList = new List<DmdDepoTotal>();
            // 2009.01.06 Add <<<

            custDmdPrc.EnterpriseCode      = this._enterpriseCode;
            custDmdPrc.AddUpSecCode        = dr[CustAccRecDmdPrcAcs.COL_ADDUPSECCODE_TITLE].ToString();
            custDmdPrc.CustomerCode        = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_CUSTOMERCODE_TITLE].ToString());
            custDmdPrc.CustomerName        = dr[CustAccRecDmdPrcAcs.COL_CUSTOMERNAME_TITLE].ToString();
            custDmdPrc.CustomerName2       = dr[CustAccRecDmdPrcAcs.COL_CUSTOMERNAME2_TITLE].ToString();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custDmdPrc.CustomerSnm         = dr[CustAccRecDmdPrcAcs.COL_CUSTOMERSNM_TITLE].ToString();
            custDmdPrc.ClaimCode           = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_CLAIMCODE_TITLE].ToString());
            custDmdPrc.ClaimName           = dr[CustAccRecDmdPrcAcs.COL_CLAIMNAME_TITLE].ToString();
            custDmdPrc.ClaimName2          = dr[CustAccRecDmdPrcAcs.COL_CLAIMNAME2_TITLE].ToString();
            custDmdPrc.ClaimSnm            = dr[CustAccRecDmdPrcAcs.COL_CLAIMSNM_TITLE].ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.AddUpDate           = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE].ToString());
            //custDmdPrc.AddUpYearMonth      = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_ADDUPYEARMONTH_TITLE].ToString());
            custDmdPrc.AddUpDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE].ToString()));
            custDmdPrc.AddUpYearMonth = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_ADDUPYEARMONTH_TITLE].ToString()));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custDmdPrc.LastTimeDemand      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_LASTTIMEDEMAND_TITLE].ToString());
            custDmdPrc.ThisTimeDmdNrml     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEDMDNRML_TITLE].ToString());
            custDmdPrc.ThisTimeFeeDmdNrml  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDNRML_TITLE].ToString());
            custDmdPrc.ThisTimeDisDmdNrml  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDNRML_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.ThisTimeRbtDmdNrml  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDNRML_TITLE].ToString());
            //custDmdPrc.ThisTimeDmdDepo     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEDMDDEPO_TITLE].ToString());
            //custDmdPrc.ThisTimeFeeDmdDepo  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDDEPO_TITLE].ToString());
            //custDmdPrc.ThisTimeDisDmdDepo  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDDEPO_TITLE].ToString());
            //custDmdPrc.ThisTimeRbtDmdDepo  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDDEPO_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custDmdPrc.ThisTimeTtlBlcDmd   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMETTLBLCDMD_TITLE].ToString());
            custDmdPrc.ThisTimeSales       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISTIMESALES_TITLE].ToString());
            custDmdPrc.ThisSalesTax        = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_THISSALESTAX_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.TtlIncDtbtTaxExc    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLINCDTBTTAXEXC_TITLE].ToString());
            //custDmdPrc.TtlIncDtbtTax       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLINCDTBTTAX_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custDmdPrc.OfsThisTimeSales    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_OFSTHISTIMESALES_TITLE].ToString());
            custDmdPrc.OfsThisSalesTax     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_OFSTHISSALESTAX_TITLE].ToString());
            custDmdPrc.ItdedOffsetOutTax   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDOFFSETOUTTAX_TITLE].ToString());
            custDmdPrc.ItdedOffsetInTax    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDOFFSETINTAX_TITLE].ToString());
            custDmdPrc.ItdedOffsetTaxFree  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDOFFSETTAXFREE_TITLE].ToString());
            custDmdPrc.OffsetOutTax        = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_OFFSETOUTTAX_TITLE].ToString());
            custDmdPrc.OffsetInTax         = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_OFFSETINTAX_TITLE].ToString());
            custDmdPrc.ItdedSalesOutTax    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDSALESOUTTAX_TITLE].ToString());
            custDmdPrc.ItdedSalesInTax     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDSALESINTAX_TITLE].ToString());
            custDmdPrc.ItdedSalesTaxFree   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDSALESTAXFREE_TITLE].ToString());
            custDmdPrc.SalesOutTax         = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_SALESOUTTAX_TITLE].ToString());
            custDmdPrc.SalesInTax          = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_SALESINTAX_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custDmdPrc.TtlItdedRetOutTax   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDRETOUTTAX_TITLE].ToString());
            custDmdPrc.TtlItdedRetInTax    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDRETINTAX_TITLE].ToString());
            custDmdPrc.TtlItdedRetTaxFree  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDRETTAXFREE_TITLE].ToString());
            custDmdPrc.TtlRetOuterTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLRETOUTERTAX_TITLE].ToString());
            custDmdPrc.TtlRetInnerTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLRETINNERTAX_TITLE].ToString());
            custDmdPrc.TtlItdedDisOutTax   = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDDISOUTTAX_TITLE].ToString());
            custDmdPrc.TtlItdedDisInTax    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDDISINTAX_TITLE].ToString());
            custDmdPrc.TtlItdedDisTaxFree  = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLITDEDDISTAXFREE_TITLE].ToString());
            custDmdPrc.TtlDisOuterTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLDISOUTERTAX_TITLE].ToString());
            custDmdPrc.TtlDisInnerTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TTLDISINNERTAX_TITLE].ToString());
            custDmdPrc.BalanceAdjust       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE].ToString());
            custDmdPrc.SalesSlipCount      = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_SALESSLIPCOUNT_TITLE].ToString());
            custDmdPrc.BillPrintDate       = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_BILLPRINTDATE_TITLE].ToString()));
            custDmdPrc.ExpectedDepositDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_EXPECTEDDEPOSITDATE_TITLE].ToString()));
            custDmdPrc.CollectCond         = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_COLLECTCOND_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.ItdedPaymOutTax     = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE].ToString());
            //custDmdPrc.ItdedPaymInTax      = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE].ToString());
            //custDmdPrc.ItdedPaymTaxFree    = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE].ToString());
            //custDmdPrc.PaymentOutTax       = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE].ToString());
            //custDmdPrc.PaymentInTax        = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            custDmdPrc.ConsTaxLayMethod    = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_CONSTAXLAYMETHOD_TITLE].ToString());
            custDmdPrc.ConsTaxRate         = Double.Parse(dr[CustAccRecDmdPrcAcs.COL_CONSTAXRATE_TITLE].ToString());
            custDmdPrc.FractionProcCd      = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_FRACTIONPROCCD_TITLE].ToString());
            custDmdPrc.AfCalDemandPrice = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_AFCALDEMANDPRICE_TITLE].ToString());
                //+ Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE].ToString())
                //+ Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE].ToString());
            custDmdPrc.AcpOdrTtl2TmBfBlDmd = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ACPODRTTL2TMBFBLDMD_TITLE].ToString());
            custDmdPrc.AcpOdrTtl3TmBfBlDmd = Int64.Parse(dr[CustAccRecDmdPrcAcs.COL_ACPODRTTL3TMBFBLDMD_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.CAddUpUpdExecDate   = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_CADDUPUPDEXECDATE_TITLE].ToString());
            custDmdPrc.CAddUpUpdExecDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_CADDUPUPDEXECDATE_TITLE].ToString()));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.DmdProcNum          = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_DMDPROCNUM_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrc.ThisPayOffset = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_THISPAYOFFSET_TITLE].ToString() ); // ����x�����E���z
            //custDmdPrc.ThisPayOffsetTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_THISPAYOFFSETTAX_TITLE].ToString() ); // ����x�����E�����
            //custDmdPrc.ItdedPaymOutTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE].ToString() ); // �x���O�őΏۊz
            //custDmdPrc.ItdedPaymInTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE].ToString() ); // �x�����őΏۊz
            //custDmdPrc.ItdedPaymTaxFree = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE].ToString() ); // �x����ېőΏۊz
            //custDmdPrc.PaymentOutTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE].ToString() ); // �x���O�ŏ����
            //custDmdPrc.PaymentInTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE].ToString() ); // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            custDmdPrc.TaxAdjust = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE].ToString() ); // ����Œ����z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // add
            custDmdPrc.ResultsSectCd = dr[CustAccRecDmdPrcAcs.COL_RESULTSECCODE_TITLE].ToString().Trim();


            custDmdPrc.FileHeaderGuid      = (Guid)dr[CustAccRecDmdPrcAcs.COL_GUID_TITLE];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custDmdPrc.CreateDateTime = (DateTime)dr[CustAccRecDmdPrcAcs.COL_CREATEDATETIME];
            custDmdPrc.UpdateDateTime = (DateTime)dr[CustAccRecDmdPrcAcs.COL_UPDATEDATETIME];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            custDmdPrc.StartCAddUpUpdDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_STARTCADDUPUPDDATE_TITLE].ToString()));
            custDmdPrc.LastCAddUpUpdDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_LASTCADDUPUPDDATE_TITLE].ToString()));
            dmdDepoTotalList = (List<DmdDepoTotal>)dr[CustAccRecDmdPrcAcs.COL_DEPOTOTAL];
            // 2009.01.06 Add <<<

            // ADD 2009/06/23 ------>>>
            custDmdPrc.BillNo = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_BILLNO_TITLE].ToString());       // ������No
            // ADD 2009/06/23 ------<<<
        }

        private void TaxAdjust_tNedit_Leave(object sender, EventArgs e)
        {
            //if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }

        // 2009.01.06 Add >>>

        /// <summary>
        /// �W�v���R�[�h�̐������z�}�X�^���擾���܂��B
        /// </summary>
        /// <param name="custDmdPrc"></param>
        /// <param name="custDmdPrcTotal"></param>
        /// <param name="dmdDepoTotalList"></param>
        private void GetTotalCustDmdPrcFromTable(CustDmdPrc custDmdPrc, out CustDmdPrc custDmdPrcTotal, out List<DmdDepoTotal> dmdDepoTotalList)
        {
            custDmdPrcTotal = null;
            dmdDepoTotalList = null;
            string select = string.Format("{0}='{1}' AND {2}={3} AND {4}={5}", 
                CustAccRecDmdPrcAcs.COL_ADDUPSECCODE_TITLE, custDmdPrc.AddUpSecCode,
                CustAccRecDmdPrcAcs.COL_CLAIMCODE_TITLE, custDmdPrc.ClaimCode,
                CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE, TDateTime.DateTimeToLongDate(custDmdPrc.AddUpDate));
            DataRow[] rows = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRCTOTAL_TITLE].Select(select);

            if (( rows != null ) && ( rows.Length > 0 ))
            {
                this.DataRowToCustDmdPrc(rows[0], out custDmdPrcTotal, out dmdDepoTotalList);
            }
            else
            {
                custDmdPrcTotal = new CustDmdPrc();
                dmdDepoTotalList = new List<DmdDepoTotal>();
            }
        }

        /// <summary>
        /// �W�v���R�[�h�̔��|���z�}�X�^���擾���܂��B
        /// </summary>
        /// <param name="custAccRec"></param>
        /// <param name="custAccRecTotal"></param>
        /// <param name="accRecDepoTotalList"></param>
        private void GetTotalCustAccRecFromTable(CustAccRec custAccRec, out CustAccRec custAccRecTotal, out List<AccRecDepoTotal> accRecDepoTotalList)
        {
            custAccRecTotal = null;
            accRecDepoTotalList = null;
            string select = string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                CustAccRecDmdPrcAcs.COL_ADDUPSECCODE_TITLE, custAccRec.AddUpSecCode,
                CustAccRecDmdPrcAcs.COL_CLAIMCODE_TITLE, custAccRec.ClaimCode,
                CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE, TDateTime.DateTimeToLongDate(custAccRec.AddUpDate));
            DataRow[] rows = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCRECTOTAL_TITLE].Select(select);

            if (( rows != null ) && ( rows.Length > 0 ))
            {
                this.DataRowToCustAccRec(rows[0], out custAccRecTotal, out accRecDepoTotalList);
            }
            else
            {
                custAccRecTotal = new CustAccRec();
                accRecDepoTotalList = new List<AccRecDepoTotal>();
            }
        }

        /// <summary>
        /// �c�����\���O���b�h�̏����Z�b�e�B���O
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�����\���O���b�h�̕\���ݒ���s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void SettingDemandInfoGrid()
        {
            string moneyFormat = "#,##0;-#,##0";
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_DemandInfo.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.Header.Fixed = false;
                //���͋��ݒ�
                //column.AutoEdit = false;
            }

            int visiblePosition = 1;

            // ���|�\��
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                // �O��c��
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Header.Caption = REC_TOTAL1_BEF_TITLE;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Width = 200;

                // ���񔄏�
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Header.Caption = REC_THISTIMESALES_TITLE;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Width = 200;

                // �����
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Header.Caption = REC_CONSTAX_TITLE;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Width = 200;

                // �������
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Header.Caption = REC_THISTIMEDEPO_TITLE;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Width = 200;

                // ���|�c��
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Header.Caption = REC_ACCRECBLNCE_TITLE;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Width = 200;

            }
            else
            {

                // �O�X��c��
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Header.Caption = REC_TOTAL3_BEF_TITLE;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Width = 200;

                // �O�X��c��
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Header.Caption = REC_TOTAL2_BEF_TITLE;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Width = 200;

                // �O��c��
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Header.Caption = REC_TOTAL1_BEF_TITLE;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Width = 200;

                // ���񔄏�
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Header.Caption = REC_THISTIMESALES_TITLE;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Width = 200;

                // �����
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Header.Caption = REC_CONSTAX_TITLE;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Width = 200;

                // �������
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Header.Caption = REC_THISTIMEDEPO_TITLE;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Width = 200;

                // �����c��
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Header.Caption = REC_DMDPRCBLNCE_TITLE;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Width = 200;
            }

            // �Œ���؂���ݒ�
            this.uGrid_DemandInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_DemandInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_DemandInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        /// <summary>
        /// ��������O���b�h�\���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��������O���b�h�̕\���ݒ���s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void DepositKindGridInitialSetting()
        {
            try
            {
                // �f�[�^�e�[�u���̗��`
                _depositDataTable = new DataTable();

                // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
                _depositDataTable.Columns.Add(DepositRelDataAcs.ctDepositKindDiv, typeof(Int32));      // ����敪
                _depositDataTable.Columns.Add(DepositRelDataAcs.ctDepositKindCode, typeof(Int32));      // ����R�[�h
                _depositDataTable.Columns.Add(DepositRelDataAcs.ctDepositKindName, typeof(string));     // ��������
                _depositDataTable.Columns.Add(DepositRelDataAcs.ctDeposit, typeof(Int64));              // �������z


                _depositDataTable.PrimaryKey = new DataColumn[] { _depositDataTable.Columns[DepositRelDataAcs.ctDepositKindCode] };

                this._depositDataView = this._depositDataTable.DefaultView;

                this.grdDepositKind.DataSource = this._depositDataView;
                this._depositDataView.Sort = DepositRelDataAcs.ctDepositKindDiv;

                string moneyFormat = "#,##0;-#,##0;''";

                // --- ��������o���h --- //
                Infragistics.Win.UltraWinGrid.ColumnsCollection pareColumns = this.grdDepositKind.DisplayLayout.Bands[0].Columns;

                // ����R�[�h
                pareColumns[DepositRelDataAcs.ctDepositKindDiv].Header.Caption = "����R�[�h";
                pareColumns[DepositRelDataAcs.ctDepositKindDiv].Hidden = true;

                // ����R�[�h
                pareColumns[DepositRelDataAcs.ctDepositKindCode].Header.Caption = "����R�[�h";
                pareColumns[DepositRelDataAcs.ctDepositKindCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                //pareColumns[DepositRelDataAcs.ctDepositKindCode].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                pareColumns[DepositRelDataAcs.ctDepositKindCode].Hidden = true;

                // ���햼��
                pareColumns[DepositRelDataAcs.ctDepositKindName].Header.Caption = "��������";
                pareColumns[DepositRelDataAcs.ctDepositKindName].Header.Appearance.FontData.SizeInPoints = 10;
                pareColumns[DepositRelDataAcs.ctDepositKindName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                pareColumns[DepositRelDataAcs.ctDepositKindName].CellAppearance.ForeColorDisabled = Color.Black;
                pareColumns[DepositRelDataAcs.ctDepositKindName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                pareColumns[DepositRelDataAcs.ctDepositKindName].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                //pareColumns[DepositRelDataAcs.ctDepositKindName].CellAppearance.FontData.SizeInPoints = 10;
                pareColumns[DepositRelDataAcs.ctDepositKindName].Width = 105;

                // �����z
                pareColumns[DepositRelDataAcs.ctDeposit].Header.Caption = "�������z";
                pareColumns[DepositRelDataAcs.ctDeposit].Header.Appearance.FontData.SizeInPoints = 10;
                pareColumns[DepositRelDataAcs.ctDeposit].CellAppearance.ForeColorDisabled = Color.Black;
                pareColumns[DepositRelDataAcs.ctDeposit].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                pareColumns[DepositRelDataAcs.ctDeposit].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                pareColumns[DepositRelDataAcs.ctDeposit].CellAppearance.FontData.SizeInPoints = 10;
                pareColumns[DepositRelDataAcs.ctDeposit].Width = 105;
                pareColumns[DepositRelDataAcs.ctDeposit].Format = moneyFormat;
            }
            finally
            {
                this._depositDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.DepositChanged);
            }
        }

        /// <summary>
        /// ��������e�[�u�� ColumnChange�C�x���g
        /// </summary>
        /// <returns></returns>
        private  void DepositChanged(object sender,DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == DepositRelDataAcs.ctDeposit)
            {
                // �������v���x���֔��f
                this.update_NormalTotalLabel();
                // �ӂւ̔��f
                upDateClaim_PanelTextData();
            }
        }

        /// <summary>
        /// ��������e�[�u���N���A
        /// </summary>
        private void ClearDepositDataTable()
        {
            try
            {
                this._depositDataTable.ColumnChanged -= new DataColumnChangeEventHandler(this.DepositChanged);

                this._depositDataTable.Rows.Clear();

                DataRow dataRow;

                foreach (int key in _depositRelDataAcs.DicMoneyKindCode.Keys)
                {
                    dataRow = _depositDataTable.NewRow();

                    dataRow[DepositRelDataAcs.ctDepositKindDiv] = (int)_depositRelDataAcs.HtMoneyKindDiv[key];
                    dataRow[DepositRelDataAcs.ctDepositKindCode] = key;
                    dataRow[DepositRelDataAcs.ctDepositKindName] = (string)_depositRelDataAcs.DicMoneyKindCode[key];
                    dataRow[DepositRelDataAcs.ctDeposit] = 0;

                    _depositDataTable.Rows.Add(dataRow);
                }

            }
            finally
            {
                this._depositDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.DepositChanged);
            }
        }

        /// <summary>
        /// ���������W�v�f�[�^����������e�[�u���ݒ菈��
        /// </summary>
        /// <param name="dmdDepoTotalList">���������W�v�f�[�^���X�g</param>
        private void DmdDepoTotalListToTable(List<DmdDepoTotal> dmdDepoTotalList)
        {
            if (dmdDepoTotalList == null) return;

            try
            {
                this._depositDataTable.ColumnChanged -= new DataColumnChangeEventHandler(this.DepositChanged);

                foreach (DmdDepoTotal dmdDepoTotal in dmdDepoTotalList)
                {
                    DataRow row = this._depositDataTable.Rows.Find(dmdDepoTotal.MoneyKindCode);
                    if (row == null)
                    {
                        row = this._depositDataTable.NewRow();
                        row[DepositRelDataAcs.ctDepositKindDiv] = dmdDepoTotal.MoneyKindDiv;
                        row[DepositRelDataAcs.ctDepositKindCode] = dmdDepoTotal.MoneyKindCode;
                        row[DepositRelDataAcs.ctDepositKindName] = dmdDepoTotal.MoneyKindName;
                        this._depositDataTable.Rows.Add(row);
                    }
                    row[DepositRelDataAcs.ctDeposit] = dmdDepoTotal.Deposit;
                }

            }
            finally
            {
                this._depositDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.DepositChanged);
            }
        }

        /// <summary>
        /// ���|�����W�v�f�[�^����������e�[�u���ݒ菈��
        /// </summary>
        /// <param name="accRecDepoTotalList">���|�����W�v�f�[�^���X�g</param>
        private void AccRecDepoTotalListToTable(List<AccRecDepoTotal> accRecDepoTotalList)
        {
            if (accRecDepoTotalList == null) return;

            try
            {
                this._depositDataTable.ColumnChanged -= new DataColumnChangeEventHandler(this.DepositChanged);


                foreach (AccRecDepoTotal accRecDepoTotal in accRecDepoTotalList)
                {
                    DataRow row = this._depositDataTable.Rows.Find(accRecDepoTotal.MoneyKindCode);
                    if (row == null)
                    {
                        row = this._depositDataTable.NewRow();
                        row[DepositRelDataAcs.ctDepositKindDiv] = accRecDepoTotal.MoneyKindDiv;
                        row[DepositRelDataAcs.ctDepositKindCode] = accRecDepoTotal.MoneyKindCode;
                        row[DepositRelDataAcs.ctDepositKindName] = accRecDepoTotal.MoneyKindName;
                        this._depositDataTable.Rows.Add(row);
                    }
                    row[DepositRelDataAcs.ctDeposit] = accRecDepoTotal.Deposit;
                }
            }
            finally
            {
                this._depositDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.DepositChanged);
            }
        }

        /// <summary>
        /// ���������f�[�^�擾����
        /// </summary>
        /// <returns></returns>
        private List<DmdDepoTotal> GetDmdDepoTotalList()
        {
            List<DmdDepoTotal> returnList = new List<DmdDepoTotal>();

            DataRow[] depositRows = this.GetDepositRows();

            if (( depositRows != null ) && ( depositRows.Length > 0 ))
            {
                foreach (DataRow row in depositRows)
                {
                    DmdDepoTotal dmdDepoTotal = new DmdDepoTotal();
                    dmdDepoTotal.MoneyKindCode = (Int32)row[DepositRelDataAcs.ctDepositKindCode];   // ����R�[�h
                    dmdDepoTotal.MoneyKindName = (string)row[DepositRelDataAcs.ctDepositKindName];  // ���햼��
                    dmdDepoTotal.MoneyKindDiv = (Int32)row[DepositRelDataAcs.ctDepositKindDiv];     // ����敪
                    dmdDepoTotal.Deposit = (Int64)row[DepositRelDataAcs.ctDeposit];                 // �������z
                    returnList.Add(dmdDepoTotal);
                }
            }

            return returnList;
        }

        /// <summary>
        /// ���������f�[�^�擾����
        /// </summary>
        /// <returns></returns>
        private List<AccRecDepoTotal> GetAccRecDepoTotalList()
        {
            List<AccRecDepoTotal> returnList = new List<AccRecDepoTotal>();

            DataRow[] depositRows = this.GetDepositRows();

            if (( depositRows != null ) && ( depositRows.Length > 0 ))
            {
                foreach (DataRow row in depositRows)
                {
                    AccRecDepoTotal accRecDepoTotal = new AccRecDepoTotal();
                    accRecDepoTotal.MoneyKindCode = (Int32)row[DepositRelDataAcs.ctDepositKindCode];    // ����R�[�h
                    accRecDepoTotal.MoneyKindName = (string)row[DepositRelDataAcs.ctDepositKindName];   // ���햼��
                    accRecDepoTotal.MoneyKindDiv = (Int32)row[DepositRelDataAcs.ctDepositKindDiv];      // ����敪
                    accRecDepoTotal.Deposit = (Int64)row[DepositRelDataAcs.ctDeposit];                  // �������z
                    returnList.Add(accRecDepoTotal);
                }
            }

            return returnList;
        }

        /// <summary>
        /// ���z���͍ς݂̓����f�[�^��DataRow���擾���܂��B
        /// </summary>
        /// <returns></returns>
        private DataRow[] GetDepositRows()
        {
            return this._depositDataTable.Select(string.Format("{0}<>0", DepositRelDataAcs.ctDeposit));
        }

        /// <summary>
        /// ��������O���b�h KeyDown�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void grdDepositKind_KeyDown(object sender, KeyEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid uGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = uGrid.ActiveCell.Column.Index;
            int rowIndex = uGrid.ActiveCell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = uGrid.ActiveCell;


            // -------------------------------------------
            // �J�[�\���L�[�������̃t�H�[�J�X������s���܂�
            // -------------------------------------------
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (rowIndex == 0)
                    {
                        //// �������Ƀt�H�[�J�X�ݒ�
                        //e.Handled = true;
                        //uGrid.ActiveCell = null;
                        //uGrid.ActiveRow = null;
                        //this.edtDepositDate.Focus();
                    }
                    else
                    {
                        e.Handled = true;
                        uGrid.DisplayLayout.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                        uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                    break;
                case Keys.Down:
                    if (rowIndex == uGrid.Rows.Count - 1)
                    {
                        // �萔���Ƀt�H�[�J�X�ݒ�
                        e.Handled = true;
                        uGrid.ActiveCell = null;
                        uGrid.ActiveRow = null;
                        this.FeeNrml_tNedit.Focus();
                    }
                    else
                    {
                        e.Handled = true;
                        uGrid.DisplayLayout.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                        uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                    break;
                case Keys.Left:
                    if (uGrid.ActiveCell.IsInEditMode)
                    {
                        if (( cell.SelLength == 0 ) && ( cell.SelStart == 0 ))
                        {
                            // ���E�����łɃt�H�[�J�X�ݒ�
                            e.Handled = true;
                            uGrid.ActiveCell = null;
                            uGrid.ActiveRow = null;
                            this.OfsThisSalesTax_tNedit.Focus();
                        }
                    }
                    break;
                case Keys.Right:
                    if (uGrid.ActiveCell.IsInEditMode)
                    {
                        if (( cell.SelLength == 0 ) && ( cell.SelStart == cell.Text.Length ))
                        {
                            e.Handled = true;
                            uGrid.ActiveCell = null;
                            uGrid.ActiveRow = null;
                            if (Bf3TmBl_tNedit.Visible)
                            {
                                this.Bf3TmBl_tNedit.Focus();
                            }
                            else
                            {
                                this.LMBl_tNedit.Focus();
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// ��������O���b�h KeyPress�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void grdDepositKind_KeyPress(object sender, KeyPressEventArgs e)
        {
            // --- ADD 2009/01/26 ��QID:10441�Ή�------------------------------------------------------>>>>>
            if (this.grdDepositKind.ActiveCell == null)
            {
                return;
            }
            // --- ADD 2009/01/26 ��QID:10441�Ή�------------------------------------------------------<<<<<

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.grdDepositKind.ActiveCell;
            if (cell.Column.Key == DepositRelDataAcs.ctDeposit)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(10, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ��������O���b�h AfterEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void grdDepositKind_AfterEnterEditMode(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ��������O���b�h AfterExitEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void grdDepositKind_AfterExitEditMode(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ��������O���b�h CellChange�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void grdDepositKind_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {

        }

        /// <summary>
        /// ��������O���b�h Leave�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void grdDepositKind_Leave(object sender, EventArgs e)
        {
            this.grdDepositKind.ActiveCell = null;
            this.grdDepositKind.ActiveRow = null;
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                if (( key != '.' ) && ( key != '-' ))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - ( selstart + sellength ));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if (( minusFlg == false ) || ( selstart > 0 ) || ( _strResult.IndexOf('-') != -1 ))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if (( priod <= 0 ) || ( _strResult.IndexOf('.') != -1 ))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - ( selstart + sellength ));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > ( keta + 1 ))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = ( _strResult[0] == '-' ) ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ���E����zTNedit_Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Offset_tNedit_Leave(object sender, EventArgs e)
        {
            if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // �ō��ݍ��v���x���̔��f
            this.update_OfsThisTimeSalesTaxIncLabel();
            // �ӂւ̔��f
            upDateClaim_PanelTextData();
        }

        // 2009.01.06 Add <<<

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ����
            int addUpADate = AddUpADate_tDateEdit.GetLongDate();

            for (int i = 0; i < this.Bind_DataSet.Tables[this._targetTableName].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsAddUpADate = (int)this.Bind_DataSet.Tables[this._targetTableName].Rows[i][CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE];
                if (addUpADate == dsAddUpADate)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[this._targetTableName].Rows[i][CustAccRecDmdPrcAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "MAKAU09110U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̓��Ӑ���яC�����͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �����̃N���A
                        AddUpADate_tDateEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        "MAKAU09110U",                          // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̓��Ӑ���яC����񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
                                {
                                    this._accRecDataIndex = i;
                                }
                                else
                                {
                                    this._dmdPrcDataIndex = i;
                                }
                                ScreenClear(true);                                
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �����̃N���A
                                AddUpADate_tDateEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        // ADD 2009/06/23 ------>>>
        /// <summary>
        /// BillNo_tNedit_BeforeEnterEditMode�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BillNo_tNedit_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            TNedit tNedit = (TNedit)sender;

            int billNo = tNedit.GetInt();
            if (billNo != 0)
            {
                tNedit.Text = billNo.ToString();
            }
        }
        // ADD 2009/06/23 ------<<<
        
    }
}
