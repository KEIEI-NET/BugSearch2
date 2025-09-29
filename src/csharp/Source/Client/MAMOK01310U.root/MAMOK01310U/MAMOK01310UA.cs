using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����ڕW�ݒ�(�v�f��)���
	/// </summary>
	/// <remarks>
	/// <br>Note			 : ����ڕW�ݒ�(�v�f��)���s����ʂł��B</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.04.23</br>
	/// <br>Update Note		 : 2007.11.21 ��� �O�M</br>
	/// <br>                   ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// <br>Update Note		 : 2008.03.07 ��� �O�M</br>
	/// <br>                   ���ڕ\���ύX</br>
	/// </remarks>
	public partial class MAMOK01310UA : Form, ISalesMonDetailsTargetMDIChild
	{
		# region Private Constants

		// ��ʏ�ԕۑ��p�t�@�C����
		private const string XML_FILE_INITIAL_DATA = "MAMOK01310U.dat";
		private const string XML_FILE_INITIAL_DATA_EMPLOYEE = "MAMOK01310U_Employee.dat";
		private const string XML_FILE_INITIAL_DATA_GOODS = "MAMOK01310U_Goods.dat";
//----- ueno add---------- start 2007.11.21
		private const string XML_FILE_INITIAL_DATA_CUSTOMER = "MAMOK01310U_Customer.dat";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string XML_FILE_INITIAL_DATA_SALESFORMAL = "MAMOK01310U_SalesFormal.dat";
		//private const string XML_FILE_INITIAL_DATA_SALESFORM = "MAMOK01310U_SalesForm.dat";
		//----- ueno del---------- end   2007.11.21

		// PG����
		private const string ctPGNM = "����ڕW�ݒ�(�v�f��)";

		// �e�[�u������
		private const string SECTION_SALESTARGET = "sectionTarget";
		private const string EMPLOYEE_SALESTARGET = "employeeSalesTarget";
		private const string GOODS_SALESTARGET = "goodsSalesTarget";
//----- ueno add---------- start 2007.11.21
		private const string CUSTOMER_SALESTARGET = "customerSalesTarget";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string SALESFORMAL_SALESTARGET = "salesFormalSalesTarget";
		//private const string SALESFORM_SALESTARGET = "salesFormSalesTarget";
		//----- ueno del---------- end   2007.11.21
//----- ueno add---------- start 2007.11.21
		private const string COL_SALESTARGET_TARGETCONSTRASTCD = "targetContrastCd";
		private const string COL_SALESTARGET_TARGETCONSTRASTNM = "targetContrastNm";
//----- ueno add---------- end   2007.11.21
		private const string COL_SALESTARGET_SECTIONCODE = "sectionCode";
		private const string COL_SALESTARGET_SECTIONNAME = "sectionName";
		private const string COL_SALESTARGET_EMPLOYEECODE = "employeeCode";
		private const string COL_SALESTARGET_NAME = "name";
		private const string COL_SALESTARGET_GOODSCODE = "goodsCode";
		private const string COL_SALESTARGET_GOODSNAME = "goodsName";
		private const string COL_SALESTARGET_MAKERCODE = "makerCode";
		private const string COL_SALESTARGET_MAKERNAME = "makerName";
//----- ueno add---------- start 2007.11.21
		private const string COL_SALESTARGET_EMPLOYEEDIVCD = "employeeDivCd";
		private const string COL_SALESTARGET_EMPLOYEEDIVNM = "employeeDivNm";
		private const string COL_SALESTARGET_SUBSECTIONCODE = "subSectionCode";
		private const string COL_SALESTARGET_SUBSECTIONNAME = "subSectionName";
		private const string COL_SALESTARGET_MINSECTIONCODE = "minSectionCode";
		private const string COL_SALESTARGET_MINSECTIONNAME = "minSectionName";
		private const string COL_SALESTARGET_BUSINESSTYPECODE = "businessTypeCode";
		private const string COL_SALESTARGET_BUSINESSTYPENAME = "businessTypeName";
		private const string COL_SALESTARGET_SALESAREACODE = "salesAreaCode";
		private const string COL_SALESTARGET_SALESAREANAME = "salesAreaName";
		private const string COL_SALESTARGET_CUSTOMERCODE = "customerCode";
		private const string COL_SALESTARGET_CUSTOMERNAME = "customerName";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string COL_SALESTARGET_SALESFORMALCODE = "salesFormalCode";
		//private const string COL_SALESTARGET_SALESFORMAL = "salesFormal";
		//private const string COL_SALESTARGET_SALESFORMCODE = "salesFormCode";
		//private const string COL_SALESTARGET_SALESFORM = "salesForm";
		//----- ueno del---------- end   2007.11.21
		private const string COL_SALESTARGET_MONEY = "money";
		private const string COL_SALESTARGET_PROFIT = "profit";
		private const string COL_SALESTARGET_COUNT = "count";

		//----- ueno del---------- start 2007.11.21
		#region del
		//private const string COL_SALESTARGET_MONEY_SUNDAY = "sundayMoney";
		//private const string COL_SALESTARGET_PROFIT_SUNDAY = "sundayProfit";
		//private const string COL_SALESTARGET_COUNT_SUNDAY = "sundayCount";
		//private const string COL_SALESTARGET_MONEY_MONDAY = "mondayMoney";
		//private const string COL_SALESTARGET_PROFIT_MONDAY = "mondayProfit";
		//private const string COL_SALESTARGET_COUNT_MONDAY = "mondayCount";
		//private const string COL_SALESTARGET_MONEY_TUESDAY = "tuesdayMoney";
		//private const string COL_SALESTARGET_PROFIT_TUESWDAY = "tuesdayProfit";
		//private const string COL_SALESTARGET_COUNT_TUESDAY = "tuesdayCount";
		//private const string COL_SALESTARGET_MONEY_WEDNESDAY = "wednesdayMoney";
		//private const string COL_SALESTARGET_PROFIT_WEDNESDAY = "wednesdayProfit";
		//private const string COL_SALESTARGET_COUNT_WEDNESDAY = "wednesdayCount";
		//private const string COL_SALESTARGET_MONEY_THURSDAY = "thursdayMoney";
		//private const string COL_SALESTARGET_PROFIT_THURSDAY = "thursdayProfit";
		//private const string COL_SALESTARGET_COUNT_THURSDAY = "thursdayCount";
		//private const string COL_SALESTARGET_MONEY_FRIDAY = "fridayMoney";
		//private const string COL_SALESTARGET_PROFIT_FRIDAY = "fridayProfit";
		//private const string COL_SALESTARGET_COUNT_FRIDAY = "fridayCount";
		//private const string COL_SALESTARGET_MONEY_SATURDAY = "saturdayMoney";
		//private const string COL_SALESTARGET_PROFIT_SATURDAY = "saturdayProfit";
		//private const string COL_SALESTARGET_COUNT_SATURDAY = "saturdayCount";
		//private const string COL_SALESTARGET_MONEY_HOLIDAY = "holidayMoney";
		//private const string COL_SALESTARGET_PROFIT_HOLIDAY = "holidayProfit";
		//private const string COL_SALESTARGET_COUNT_HOLIDAY = "holidayCount";
		#endregion del
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
		private const string VIEW_SALESTARGET_TARGETCONSTRASTNM = "�ڕW�Δ�敪";
//----- ueno add---------- end   2007.11.21
		private const string VIEW_SALESTARGET_SECTIONNAME = "���_";
		private const string VIEW_SALESTARGET_EMPLOYEECODE = "�]�ƈ��R�[�h";
		private const string VIEW_SALESTARGET_NAME = "�]�ƈ���";
		private const string VIEW_SALESTARGET_GOODSCODE = "���i�R�[�h";
		private const string VIEW_SALESTARGET_GOODSNAME = "���i��";
		private const string VIEW_SALESTARGET_MAKERNAME = "���[�J�[����";
//----- ueno add---------- start 2007.11.21
		private const string VIEW_SALESTARGET_MAKERCODE = "���[�J�[�R�[�h";
		private const string VIEW_SALESTARGET_EMPLOYEEDIVCD = "�]�ƈ��敪";
		private const string VIEW_SALESTARGET_EMPLOYEEDIVNM = "�]�ƈ��敪����";
		private const string VIEW_SALESTARGET_SUBSECTIONCODE = "����R�[�h";
		private const string VIEW_SALESTARGET_SUBSECTIONNAME = "���喼��";
		private const string VIEW_SALESTARGET_MINSECTIONCODE = "�ۃR�[�h";
		private const string VIEW_SALESTARGET_MINSECTIONNAME = "�ۖ���";
		private const string VIEW_SALESTARGET_BUSINESSTYPECODE = "�Ǝ�R�[�h";
		private const string VIEW_SALESTARGET_BUSINESSTYPENAME = "�Ǝ햼��";
		private const string VIEW_SALESTARGET_SALESAREACODE = "�̔��G���A�R�[�h";
		private const string VIEW_SALESTARGET_SALESAREANAME = "�̔��G���A����";
		private const string VIEW_SALESTARGET_CUSTOMERCODE = "���Ӑ�R�[�h";
		private const string VIEW_SALESTARGET_CUSTOMERNAME = "���Ӑ於��";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string VIEW_SALESTARGET_SALESFORMAL = "����`��";
		//private const string VIEW_SALESTARGET_SALESFORM = "�̔��`��";
		//----- ueno del---------- end   2007.11.21
		private const string VIEW_SALESTARGET_MONEY_MONTH = "����ڕW\n(�~/��)";
        private const string VIEW_SALESTARGET_PROFIT_MONTH = "�e���ڕW\n(�~/��)";

		//----- ueno upd ---------- start 2008.03.07 �u��v�폜
        private const string VIEW_SALESTARGET_COUNT_MONTH = "���ʖڕW\n(��)";
		//----- ueno upd ---------- end 2008.03.07

        private const string VIEW_SALESTARGET_MONEY_TERM = "����ڕW\n(�~/����)";
        private const string VIEW_SALESTARGET_PROFIT_TERM = "�e���ڕW\n(�~/����)";

		//----- ueno upd ---------- start 2008.03.07 �u��v�폜
        private const string VIEW_SALESTARGET_COUNT_TERM = "���ʖڕW\n(����)";
		//----- ueno upd ---------- end 2008.03.07

		//----- ueno del---------- start 2007.11.21
		#region del
		//private const string VIEW_SALESTARGET_MONEY_SUNDAY = "���j����ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_PROFIT_SUNDAY = "���j�e���ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_COUNT_SUNDAY = "���j���ʖڕW\n(��/��)";
		//private const string VIEW_SALESTARGET_MONEY_MONDAY = "���j����ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_PROFIT_MONDAY = "���j�e���ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_COUNT_MONDAY = "���j���ʖڕW\n(��/��)";
		//private const string VIEW_SALESTARGET_MONEY_TUESDAY = "�Ηj����ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_PROFIT_TUESDAY = "�Ηj�e���ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_COUNT_TUESDAY = "�Ηj���ʖڕW\n(��/��)";
		//private const string VIEW_SALESTARGET_MONEY_WEDNESDAY = "���j����ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_PROFIT_WEDNESDAY = "���j�e���ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_COUNT_WEDNESDAY = "���j���ʖڕW\n(��/��)";
		//private const string VIEW_SALESTARGET_MONEY_THURSDAY = "�ؗj����ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_PROFIT_THURSDAY = "�ؗj�e���ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_COUNT_THURSDAY = "�ؗj���ʖڕW\n(��/��)";
		//private const string VIEW_SALESTARGET_MONEY_FRIDAY = "���j����ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_PROFIT_FRIDAY = "���j�e���ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_COUNT_FRIDAY = "���j���ʖڕW\n(��/��)";
		//private const string VIEW_SALESTARGET_MONEY_SATURDAY = "�y�j����ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_PROFIT_SATURDAY = "�y�j�e���ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_COUNT_SATURDAY = "�y�j���ʖڕW\n(��/��)";
		//private const string VIEW_SALESTARGET_MONEY_HOLIDAY = "�j�Փ�����ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_PROFIT_HOLIDAY = "�j�Փ��e���ڕW\n(�~/��)";
		//private const string VIEW_SALESTARGET_COUNT_HOLIDAY = "�j�Փ����ʖڕW\n(��/��)";
		#endregion del
		//----- ueno del---------- end   2007.11.21
		private const string VIEW_SALESTARGET_TOTAL = "���v";

//----- ueno add---------- start 2007.11.21
		private const int WIDTH_SALESTARGET_TARGETCONSTRASTNM = 200;
//----- ueno add---------- end   2007.11.21
		private const int WIDTH_SALESTARGET_SECTIONNAME = 100;
		private const int WIDTH_SALESTARGET_EMPLOYEECODE = 100;
		private const int WIDTH_SALESTARGET_NAME = 90;
		private const int WIDTH_SALESTARGET_GOODSCODE = 90;
		private const int WIDTH_SALESTARGET_GOODSNAME = 90;
		private const int WIDTH_SALESTARGET_MAKERNAME = 90;
//----- ueno add---------- start 2007.11.21
		private const int WIDTH_SALESTARGET_MAKERCODE = 90;
		private const int WIDTH_SALESTARGET_EMPLOYEEDIVCD = 90;
		private const int WIDTH_SALESTARGET_EMPLOYEEDIVNM = 90;
		private const int WIDTH_SALESTARGET_SUBSECTIONCODE = 90;
		private const int WIDTH_SALESTARGET_SUBSECTIONNAME = 90;
		private const int WIDTH_SALESTARGET_MINSECTIONCODE = 90;
		private const int WIDTH_SALESTARGET_MINSECTIONNAME = 90;
		private const int WIDTH_SALESTARGET_BUSINESSTYPECODE = 90;
		private const int WIDTH_SALESTARGET_BUSINESSTYPENAME = 90;
		private const int WIDTH_SALESTARGET_SALESAREACODE = 90;
		private const int WIDTH_SALESTARGET_SALESAREANAME = 90;
		private const int WIDTH_SALESTARGET_CUSTOMERCODE = 90;
		private const int WIDTH_SALESTARGET_CUSTOMERNAME = 90;
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const int WIDTH_SALESTARGET_SALESFORMAL = 80;
		//private const int WIDTH_SALESTARGET_SALESFORM = 80;
		//----- ueno del---------- end   2007.11.21
		private const int WIDTH_SALESTARGET_MONEY = 115;
		private const int WIDTH_SALESTARGET_PROFIT = 115;
		private const int WIDTH_SALESTARGET_COUNT = 115;

        private readonly Color COLOR_TOTAL = Color.FromArgb(255, 255, 192);

		//private const double RATIO = 1.00;

//----- ueno add---------- start 2007.11.21
		private const int GUIDEDIVCD_BUSINESSTYPECODE = 33;	// ���[�U�[�K�C�h�敪�i�Ǝ�R�[�h�j
		private const int GUIDEDIVCD_SALESAREACODE = 21;	// ���[�U�[�K�C�h�敪�i�̔��G���A�R�[�h�j
//----- ueno add---------- end   2007.11.21

        private const string FORMAT_NUM = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

		// ���_�ڕW�p�]�ƈ��R�[�h
		private const string EMPLOYEECODE_SECTION = "SECTION";

		//----- ueno del---------- start 2007.11.21
		//// �@��R�[�h�Ȃ�
		//private const string CELLPHONEMODELCODE_NONE = "none";
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
		private const int DUMMY_TARGETCONSTRASTCD = 99999;	// �O���b�h�\�[�g���g�p�i���v�s�Ƀ_�~�[�ݒ�j
//----- ueno add---------- end   2007.11.21

		# endregion Private Constants

		# region Private Members

		// �^�C�g��
		private readonly string _title;
		// ���ɖ߂��{�^��
		private bool _undoButton;

		// ��ƃR�[�h
		private string _enterpriseCode;
		// ���_�R�[�h
		private string _sectionCode;
		// ���_��
		private string _sectionName;

		// �O���b�h
		private UltraGrid _uGrid;
		// �t�H���g�T�C�Y
		private TComboEditor _cmbFontSize;
		// ��T�C�Y
		private UltraCheckEditor _uceAutoFitCol;

		// �ڕW�}�X�^�A�N�Z�X�N���X
		private SalesTargetAcs _salesTargetAcs;

		// �ڕW�f�[�^���X�g
		private List<SalesTarget> _sectionSalesTargetList;
		private List<SalesTarget> _employeeSalesTargetList;
		private List<SalesTarget> _goodsSalesTargetList;
//----- ueno add---------- start 2007.11.21
		private List<SalesTarget> _customerTargetList;
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private List<SalesTarget> _salesFormalSalesTargetList;
		//private List<SalesTarget> _salesFormSalesTargetList;
		//----- ueno del---------- end   2007.11.21

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
        // ���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

//----- ueno add---------- start 2007.11.21
		// ���[�U�[�K�C�h�A�N�Z�X�N���X
		private UserGuideAcs _userGuideAcs = null;

		// ���[�U�[�K�C�h�f�[�^�i�[�p�i�Ǝ�R�[�h�j
		private SortedList _businessTypeCodeSList = null;

		// ���[�U�[�K�C�h�f�[�^�i�[�p�i�̔��G���A�R�[�h�j
		private SortedList _salesAreaCodeSList = null;
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		//// �x�Ɠ��ݒ�}�X�^
		//private Dictionary<SectionAndDate, HolidaySetting> _holidaySettingDic;

		//// ���n�v�Z�䗦���X�g
		//private List<LdgCalcRatioMng> _ldgCalcRatioMngList;
		//----- ueno del---------- end   2007.11.21

		// �O���b�h�ݒ萧��N���X
		private GridStateController _gridStateController;

		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// �����t���O
		private bool _searchFlag;

		// �ۊǗp�]�ƈ�
//----- ueno add---------- start 2007.11.21
		private int _empTargetConstrastCd = 0;
		private int _employeeDivCd;
		private string _employeeDivNm;
		private int _subSectionCode;
		private string _subSectionName;
		private int _minSectionCode;
		private string _minSectionName;
//----- ueno add---------- end   2007.11.21
		private string _employeeCode;
		private string _employeeName;

		// �ۊǗp���i
//----- ueno add---------- start 2007.11.21
		//private int _goodsTargetConstrastCd = 0;
        private int _goodsTargetConstrastCd = 43;
//----- ueno add---------- end   2007.11.21
		private string _goodsCode;
		private string _goodsName;
		private int _makerCode;

//----- ueno add---------- start 2007.11.21
		// �ۊǗp���Ӑ�
		private int _custTargetConstrastCd = 0;
		private int _businessTypeCode;
		private string _businessTypeName;
		private int _salesAreaCode;
		private string _salesAreaName;
		private int _customerCode;
		private string _customerName = "";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//// �ۊǗp����`��
		//private int _salesFormalCode;
		//private string _salesFormalName;
		//// �ۊǗp�̔��`��
		//private int _salesFormCode;
		//private string _salesFormName;
		//----- ueno del---------- end   2007.11.21

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
        // BL�R�[�h
        private int _bLCode;
        // BL�O���[�v�R�[�h
        private int _bLGroupCode;
        // �̔��敪�R�[�h
        private int _salesCode;
        // ���i�敪�R�[�h
        private int _enterpriseGanreCode;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAMOK01310UA()
		{
			InitializeComponent();

			// ���ɖ߂�
			this._undoButton = true;

			// ��ƃR�[�h���擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// ���_���擾
			SecInfoSet secInfoSet;
			SecInfoAcs secInfoAcs = new SecInfoAcs();
			secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
			this._sectionCode = secInfoSet.SectionCode.TrimEnd();
			this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

			this._employeeSalesTargetList = new List<SalesTarget>();
			this._goodsSalesTargetList = new List<SalesTarget>();
//----- ueno add---------- start 2007.11.21
			this._customerTargetList = new List<SalesTarget>();
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this._salesFormalSalesTargetList = new List<SalesTarget>();
			//this._salesFormSalesTargetList = new List<SalesTarget>();
			//----- ueno del---------- end   2007.11.21

			this._salesTargetAcs = new SalesTargetAcs();

			this._gridStateController = new GridStateController();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // ���_�A�N�Z�X�N���X
            this._secInfoSetAcs = new SecInfoSetAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

//----- ueno add---------- start 2007.11.21
			// ���[�U�[�K�C�h�A�N�Z�X�N���X
			this._userGuideAcs = new UserGuideAcs();

			// ���[�U�[�K�C�h�f�[�^�i�[�p�i�Ǝ�R�[�h�j
			this._businessTypeCodeSList = new SortedList();

			// ���[�U�[�K�C�h�f�[�^�i�[�p�i�̔��G���A�R�[�h�j
			this._salesAreaCodeSList = new SortedList();
//----- ueno add---------- end   2007.11.21

			// �A�C�R���摜�̐ݒ�

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // ���_�R�[�h�K�C�h�{�^��
            this.SectionCodeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END
			// �����{�^��
			this.Search_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];
			// �ڕW�K�C�h�{�^��
			this.TargetGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			// �Q�ƃ{�^��
			this.ReferSection_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW];
			// �V�K�{�^��
			this.NewSection_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
			this.NewEmployee_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
			this.NewGoods_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
//----- ueno add---------- start 2007.11.21
			this.NewCustomer_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this.NewSalesFormal_Button.Appearance.Image
			//	= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
			//this.NewSalesForm_Button.Appearance.Image
			//    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
			//----- ueno del---------- end   2007.11.21
			
			// �ҏW�{�^��
			this.Edit_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
			this.EditSection_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
			this.EditEmployee_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
			this.EditGoods_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
//----- ueno add---------- start 2007.11.21
			this.EditCustomer_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
//----- ueno add---------- start 2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this.EditSalesFormal_Button.Appearance.Image
			//	= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
			//this.EditSalesForm_Button.Appearance.Image
			//	= IconResourceManagement.ImageList16.Images[(int)Size16_Index.EDITING];
			//----- ueno del---------- end   2007.11.21
			
			// �폜�{�^��
			this.DeleteSection_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];
			this.DeleteEmployee_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];
			this.DeleteGoods_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];
//----- ueno add---------- start 2007.11.21
			this.DeleteCustomer_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this.DeleteSalesFormal_Button.Appearance.Image
			//	= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];
			//this.DeleteSalesForm_Button.Appearance.Image
			//	= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];
			//----- ueno del---------- end   2007.11.21

			this._title = ctPGNM;
            this.TargetSetCd_tComboEditor.SelectedIndex = 0;

		}

		# endregion Constructor

		# region ISalesMonDetailsTargetMDIChild �����o

		/// <summary>
		/// �^�C�g��
		/// </summary>
		public string Title
		{
			get
			{
				return (_title);
			}
		}

		/// <summary>
		/// ���ɖ߂��{�^��
		/// </summary>
		public bool UndoButton
		{
			get
			{
				return (_undoButton);
			}
		}

		/// <summary>
		/// �I�����_�擾�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �t���[���ɂđI������Ă��鋒�_�R�[�h���擾���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		//public event GetSalesMonDetailsTargetSelectSectionCodeEventHandler GetSelectSectionCodeEvent;

		/// <summary>
		/// �c�[���o�[�{�^������C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B
		///					  (IPaymentInputMDIChild�C���^�[�t�F�[�X�̎���)</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public event ParentToolbarSalesMonDetailsTargetSettingEventHandler ParentToolbarSettingEvent;

		/// <summary>
		/// ���_�ύX�㏈��
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �t���[���ɂċ��_���ύX���ꂽ��ɏ�������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public void AfterSectionChange()
		{

		}

		/// <summary>
		/// �I���O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ��ʂ����O�ɏ�������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public int BeforeClose(object parameter)
		{
			// ��ʏ�Ԃ�ۑ�
			SaveStateXmlData();
			return (0);
		}

		/// <summary>
		/// ���_�ύX�O����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �t���[���ɂċ��_���ύX�����O�ɏ�������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public int BeforeSectionChange()
		{
			return (0);
		}

		/// <summary>
		/// �^�u�֑ؑO����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �t���[���ɂă^�u���؂�ւ�����O�ɏ�������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public int BeforeTabChange(object parameter)
		{
			return (0);
		}

        /// <summary>
        /// �t�H�[������������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �t���[���ɂăt�H�[�������������O�ɏ�������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.11</br>
        /// </remarks>
        public int InitializeForm()
        {
			//----- ueno del---------- start 2007.11.21
			//int status = LoadMasterTable();
			//if (status != 0)
			//{
			//    // �c�[���o�[������
			//    this._undoButton = false;
			//    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
			//}
			//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
			int status = 0;
			
			// ���[�U�[�K�C�h�f�[�^�擾
			ArrayList userGdBdList;
			
			// �Ǝ�R�[�h�擾
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_BUSINESSTYPECODE);
			SetUserGdBd(ref this._businessTypeCodeSList, ref userGdBdList);
			
			// �̔��G���A�擾
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_SALESAREACODE);
			SetUserGdBd(ref this._salesAreaCodeSList, ref userGdBdList);

//----- ueno add---------- end   2007.11.21

            return (status);

        }

		/// <summary>
		/// ���[�h���X�\�������i�p�����[�^�L��j
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �ʏ�N�����Ƀt���[������Ăяo����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public void Show(object parameter)
		{
			this.Show();
		}

		/// <summary>
		/// ���ɖ߂�����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʂ��N���A���܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public void UndoSalesMonTargetProc()
		{
			if (this._searchFlag == false)
			{
				return;
			}

			string Msg = "��ʏ����N���A���܂����A��낵���ł����H";
			DialogResult res = TMsgDisp.Show(
										this, 							// �e�E�B���h�E�t�H�[��
										emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
										this.Name,						// �A�Z���u��ID
										Msg, 							// �\�����郁�b�Z�[�W
										0,								// �X�e�[�^�X�l
										MessageBoxButtons.OKCancel);	// �\������{�^��

			switch (res)
			{
				case DialogResult.OK:
					{
						// ��ʃN���A
						ClearScreen();

						this.ReferSection_Button.Enabled = false;
						this.EditSection_Button.Enabled = false;
						this.EditEmployee_Button.Enabled = false;
						this.EditGoods_Button.Enabled = false;
//----- ueno add---------- start 2007.11.21
						this.EditCustomer_Button.Enabled = false;
//----- ueno add---------- end   2007.11.21
						//----- ueno del---------- start 2007.11.21
						//this.EditSalesFormal_Button.Enabled = false;
						//this.EditSalesForm_Button.Enabled = false;
						//----- ueno del---------- end   2007.11.21					
						this.DeleteSection_Button.Enabled = false;
						this.DeleteEmployee_Button.Enabled = false;
						this.DeleteGoods_Button.Enabled = false;
//----- ueno add---------- start 2007.11.21
						this.DeleteCustomer_Button.Enabled = false;
//----- ueno add---------- end   2007.11.21
						//----- ueno del---------- start 2007.11.21
						//this.DeleteSalesFormal_Button.Enabled = false;
						//this.DeleteSalesForm_Button.Enabled = false;
						//----- ueno del---------- end   2007.11.21

						return;
					}
				case DialogResult.Cancel:
					{
						return;
					}
			}
		}

		# endregion ISalesMonDetailsTargetMDIChild �����o

		# region Private Methods

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �}�X�^�Ǎ�����
		///// </summary>
		///// <remarks>
		///// <br>Note		: �e�}�X�^��ǂݍ��݂܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.24</br>
		///// </remarks>
		//private int LoadMasterTable()
		//{
		//    int status;

		//    // �x�Ɠ��ݒ�}�X�^
		//    status = LoadHolidaySettingTable(this._sectionCode);
		//    if (status != 0)
		//    {
		//        return (status);
		//    }


		//    // ���n�v�Z�䗦�Ǘ��}�X�^
		//    status = LoadLdgCalcRatioMngTable(this._sectionCode);

		//    if (status != 0)
		//    {
		//        return (status);
		//    }
		//    return (0);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �x�Ɠ��ݒ�}�X�^�ǂݍ��ݏ���
		///// </summary>
		///// <param name="sectionCode">���_�R�[�h</param>
		///// <remarks>
		///// <br>Note		: �x�Ɠ��ݒ�}�X�^��ǂݍ��݋x�Ɠ��K�p�敪���擾���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.11</br>
		///// </remarks>
		//private int LoadHolidaySettingTable(string sectionCode)
		//{
		//    int status;
		//    ArrayList retList;

		//    _holidaySettingDic = new Dictionary<SectionAndDate, HolidaySetting>();

		//    // �x�Ɠ��ݒ�}�X�^����f�[�^���擾
		//    HolidaySettingAcs holidaySettingAcs = new HolidaySettingAcs();
		//    status = holidaySettingAcs.Search(
		//        out retList,
		//        this._enterpriseCode,
		//        sectionCode,
		//        DateTime.MinValue,
		//        DateTime.MaxValue);
		//    switch (status)
		//    {
		//        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//        case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//            break;
		//        default:
		//            TMsgDisp.Show(
		//                this,										// �e�E�B���h�E�t�H�[��
		//                emErrorLevel.ERR_LEVEL_STOP,				// �G���[���x��
		//                this.Name,									// �A�Z���u��ID
		//                ctPGNM,  �@�@								// �v���O��������
		//                "LoadHolidaySettingTable",					// ��������
		//                TMsgDisp.OPE_GET,							// �I�y���[�V����
		//                "�x�Ɠ��ݒ�}�X�^�̓ǂݍ��݂Ɏ��s���܂���",					// �\�����郁�b�Z�[�W
		//                status,										// �X�e�[�^�X�l
		//                holidaySettingAcs,							// �G���[�����������I�u�W�F�N�g
		//                MessageBoxButtons.OK,			  			// �\������{�^��
		//                MessageBoxDefaultButton.Button1);			// �����\���{�^��
		//            return (status);
		//    }

		//    // ���X�g�쐬
		//    SectionAndDate sectionAndDate;
		//    foreach (HolidaySetting holidaySetting in retList)
		//    {
		//        sectionAndDate.SectionCode = holidaySetting.SectionCode;
		//        sectionAndDate.Date = holidaySetting.ApplyDate;
		//        _holidaySettingDic.Add(sectionAndDate, holidaySetting);
		//    }

		//    return (0);

		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// ���n�v�Z�䗦�Ǘ��}�X�^�ǂݍ��ݏ���
		///// </summary>
		///// <param name="sectionCode">���_�R�[�h</param>
		///// <remarks>
		///// <br>Note		: ���n�v�Z�䗦�Ǘ��}�X�^��ǂݍ��݊e�j���̔䗦���擾���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.12</br>
		///// </remarks>
		//private int LoadLdgCalcRatioMngTable(string sectionCode)
		//{
		//    LdgCalcRatioMngAcs ldgCalcRatioMngAcs = new LdgCalcRatioMngAcs();
		//    this._ldgCalcRatioMngList = new List<LdgCalcRatioMng>();

		//    string[] sectionCodeList = new string[1];
		//    sectionCodeList[0] = sectionCode;

		//    // ���n�v�Z�䗦�Ǘ��}�X�^�擾
		//    int status = ldgCalcRatioMngAcs.Search(out this._ldgCalcRatioMngList, this._enterpriseCode, sectionCodeList);
		//    switch (status)
		//    {
		//        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//        case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//            // ����
		//            break;
		//        default:
		//            // �G���[
		//            return (status);
		//    }

		//    return (0);
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �w�l�k�f�[�^�̕ۑ�����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̕ۑ��������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void SaveStateXmlData()
		{
			// �O���b�h����ۑ�
			this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this._uGrid);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �w�l�k�f�[�^�̓Ǎ�����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̓Ǎ��������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void LoadStateXmlData()
		{
			int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this._uGrid);
			if (status == 0)
			{
				GridStateController.GridStateInfo gridStateInfo = _gridStateController.GetGridStateInfo(ref this._uGrid);
				if (gridStateInfo != null)
				{
					// �t�H���g�T�C�Y
					this._cmbFontSize.Value = (int)gridStateInfo.FontSize;
					// ��̎�������
					this._uceAutoFitCol.Checked = gridStateInfo.AutoFit;
				}
				else
				{
					status = 4;
				}
			}
			if (status != 0)
			{
				// �t�H���g�T�C�Y
				this._cmbFontSize.Value = 10;
				// ��̎�������
				this._uceAutoFitCol.Checked = false;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ǉ��i���ʕ����j����
		/// </summary>
        /// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note		: �e�[�u���ɗ�i���ʕ����j��ǉ����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void DispScreenCommonColumn(ref DataTable dataTable)
		{
			dataTable.Columns.Add(COL_SALESTARGET_MONEY, typeof(long));
			dataTable.Columns.Add(COL_SALESTARGET_PROFIT, typeof(long));
			dataTable.Columns.Add(COL_SALESTARGET_COUNT, typeof(double));

			//----- ueno del---------- start 2007.11.21
			#region del
			//dataTable.Columns.Add(COL_SALESTARGET_MONEY_SUNDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_PROFIT_SUNDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_COUNT_SUNDAY, typeof(double));
			//dataTable.Columns.Add(COL_SALESTARGET_MONEY_MONDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_PROFIT_MONDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_COUNT_MONDAY, typeof(double));
			//dataTable.Columns.Add(COL_SALESTARGET_MONEY_TUESDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_PROFIT_TUESWDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_COUNT_TUESDAY, typeof(double));
			//dataTable.Columns.Add(COL_SALESTARGET_MONEY_WEDNESDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_PROFIT_WEDNESDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_COUNT_WEDNESDAY, typeof(double));
			//dataTable.Columns.Add(COL_SALESTARGET_MONEY_THURSDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_PROFIT_THURSDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_COUNT_THURSDAY, typeof(double));
			//dataTable.Columns.Add(COL_SALESTARGET_MONEY_FRIDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_PROFIT_FRIDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_COUNT_FRIDAY, typeof(double));
			//dataTable.Columns.Add(COL_SALESTARGET_MONEY_SATURDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_PROFIT_SATURDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_COUNT_SATURDAY, typeof(double));
			//dataTable.Columns.Add(COL_SALESTARGET_MONEY_HOLIDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_PROFIT_HOLIDAY, typeof(long));
			//dataTable.Columns.Add(COL_SALESTARGET_COUNT_HOLIDAY, typeof(double));
			#endregion del
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^�ݒ�i���ʕ����j����
		/// </summary>
        /// <param name="dataRow">�f�[�^���E</param>
        /// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�ݒ�i���ʕ����j���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void DispScreenCommonRow(ref DataRow dataRow, SalesTarget salesTarget)
		{
			if (salesTarget.SalesTargetMoney == 0)
			{
				dataRow[COL_SALESTARGET_MONEY] = DBNull.Value;
			}
			else
			{
				dataRow[COL_SALESTARGET_MONEY] = salesTarget.SalesTargetMoney;
			}

			if (salesTarget.SalesTargetProfit == 0)
			{
				dataRow[COL_SALESTARGET_PROFIT] = DBNull.Value;
			}
			else
			{
				dataRow[COL_SALESTARGET_PROFIT] = salesTarget.SalesTargetProfit;
			}

			if (salesTarget.SalesTargetCount == 0)
			{
				dataRow[COL_SALESTARGET_COUNT] = DBNull.Value;
			}
			else
			{
				dataRow[COL_SALESTARGET_COUNT] = salesTarget.SalesTargetCount;
			}

			//----- ueno del---------- start 2007.11.21
			#region del
			//dataRow[COL_SALESTARGET_MONEY_SUNDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_PROFIT_SUNDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_COUNT_SUNDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_MONEY_MONDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_PROFIT_MONDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_COUNT_MONDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_MONEY_TUESDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_PROFIT_TUESWDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_COUNT_TUESDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_MONEY_WEDNESDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_PROFIT_WEDNESDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_COUNT_WEDNESDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_MONEY_THURSDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_PROFIT_THURSDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_COUNT_THURSDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_MONEY_FRIDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_PROFIT_FRIDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_COUNT_FRIDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_MONEY_SATURDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_PROFIT_SATURDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_COUNT_SATURDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_MONEY_HOLIDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_PROFIT_HOLIDAY] = DBNull.Value;
			//dataRow[COL_SALESTARGET_COUNT_HOLIDAY] = DBNull.Value;
			#endregion del
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�i���_�j�O���b�h�\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^�i���_�j���O���b�h�ɕ\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void DispScreenSection_uGrid()
		{
			// �f�[�^�ǉ��p
			DataRow dataRow;

			// �e�[�u���̒�`
			DataTable dataTable = new DataTable(SECTION_SALESTARGET);

			dataTable.Columns.Add(COL_SALESTARGET_SECTIONCODE, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_SECTIONNAME, typeof(string));
			// ��ǉ��i���ʕ����j
			DispScreenCommonColumn(ref dataTable);

			foreach (SalesTarget salesTarget in this._sectionSalesTargetList)
			{
				dataRow = dataTable.NewRow();

				dataRow[COL_SALESTARGET_SECTIONCODE] = this._sectionCode;
				dataRow[COL_SALESTARGET_SECTIONNAME] = this._sectionName;
				// �f�[�^�ݒ�i���ʕ����j
				DispScreenCommonRow(ref dataRow, salesTarget);

				// �f�[�^�ǉ�
				dataTable.Rows.Add(dataRow);
			}

			// ���v�s�ǉ�
			if (this._sectionSalesTargetList.Count > 0)
			{
				dataRow = dataTable.NewRow();

				dataRow[COL_SALESTARGET_SECTIONCODE] = DBNull.Value;
				dataRow[COL_SALESTARGET_SECTIONNAME] = VIEW_SALESTARGET_TOTAL;
				dataRow[COL_SALESTARGET_MONEY] = DBNull.Value;
				dataRow[COL_SALESTARGET_PROFIT] = DBNull.Value;
				dataRow[COL_SALESTARGET_COUNT] = DBNull.Value;

				//----- ueno del---------- start 2007.11.21
				#region del
				//dataRow[COL_SALESTARGET_MONEY_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_TUESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_TUESWDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_TUESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_HOLIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_HOLIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_HOLIDAY] = DBNull.Value;
				#endregion del
				//----- ueno del---------- end   2007.11.21

				// �f�[�^�ǉ�
				dataTable.Rows.Add(dataRow);
			}

			this.Section_uGrid.DataSource = dataTable;
			this.Section_uGrid.DataBind();
		}
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�i�]�ƈ��j�O���b�h�\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^�i�]�ƈ��j���O���b�h�ɕ\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void DispScreenEmployee_uGrid()
		{
			// �f�[�^�ǉ��p
			DataRow dataRow;

			// �e�[�u���̒�`
			DataTable dataTable = new DataTable(EMPLOYEE_SALESTARGET);

//----- ueno add---------- start 2007.11.21
			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTCD, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTNM, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_EMPLOYEEDIVCD, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_EMPLOYEEDIVNM, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_SUBSECTIONCODE, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_SUBSECTIONNAME, typeof(string));
			//dataTable.Columns.Add(COL_SALESTARGET_MINSECTIONCODE, typeof(Int32));
			//dataTable.Columns.Add(COL_SALESTARGET_MINSECTIONNAME, typeof(string));
//----- ueno add---------- end   2007.11.21

			dataTable.Columns.Add(COL_SALESTARGET_EMPLOYEECODE, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_NAME, typeof(string));

			// ��ǉ��i���ʕ����j
			DispScreenCommonColumn(ref dataTable);

			foreach (SalesTarget salesTarget in this._employeeSalesTargetList)
			{
				dataRow = dataTable.NewRow();

//----- ueno add---------- start 2007.11.21
				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = salesTarget.TargetContrastCd;
				dataRow[COL_SALESTARGET_TARGETCONSTRASTNM] = SalesTarget.GetTargetContrastNm(salesTarget.TargetContrastCd);
				dataRow[COL_SALESTARGET_EMPLOYEEDIVCD] = salesTarget.EmployeeDivCd;
				dataRow[COL_SALESTARGET_EMPLOYEEDIVNM] = EmpSalesTarget.GetEmployeeDivNm(salesTarget.EmployeeDivCd);
				dataRow[COL_SALESTARGET_SUBSECTIONCODE] = salesTarget.SubSectionCode;
				dataRow[COL_SALESTARGET_SUBSECTIONNAME] = GetSubSectionName(salesTarget.SubSectionCode);
				//dataRow[COL_SALESTARGET_MINSECTIONCODE] = salesTarget.MinSectionCode;
				//dataRow[COL_SALESTARGET_MINSECTIONNAME] = GetMinSectionName(salesTarget.SubSectionCode, salesTarget.MinSectionCode);
//----- ueno add---------- end   2007.11.21

				dataRow[COL_SALESTARGET_EMPLOYEECODE] = salesTarget.EmployeeCode;
				dataRow[COL_SALESTARGET_NAME] = salesTarget.EmployeeName;
				
				// �f�[�^�ݒ�i���ʕ����j
				DispScreenCommonRow(ref dataRow, salesTarget);

				// �f�[�^�ǉ�
				dataTable.Rows.Add(dataRow);
			}

			// ���v�s�ǉ�
			if (this._employeeSalesTargetList.Count > 0)
			{
				dataRow = dataTable.NewRow();

//----- ueno upd---------- start 2007.11.21
				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = DUMMY_TARGETCONSTRASTCD;	// �\�[�g�p
				dataRow[COL_SALESTARGET_TARGETCONSTRASTNM] = VIEW_SALESTARGET_TOTAL;
				dataRow[COL_SALESTARGET_EMPLOYEEDIVCD] = DBNull.Value;
				dataRow[COL_SALESTARGET_EMPLOYEEDIVNM] = "";
				dataRow[COL_SALESTARGET_SUBSECTIONCODE] = DBNull.Value;
				dataRow[COL_SALESTARGET_SUBSECTIONNAME] = "";
				//dataRow[COL_SALESTARGET_MINSECTIONCODE] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MINSECTIONNAME] = "";
				dataRow[COL_SALESTARGET_EMPLOYEECODE] = "";
				dataRow[COL_SALESTARGET_NAME] = "";
//----- ueno upd---------- end   2007.11.21

				dataRow[COL_SALESTARGET_MONEY] = DBNull.Value;
				dataRow[COL_SALESTARGET_PROFIT] = DBNull.Value;
				dataRow[COL_SALESTARGET_COUNT] = DBNull.Value;

				//----- ueno del---------- start 2007.11.21
				#region del
				//dataRow[COL_SALESTARGET_MONEY_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_TUESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_TUESWDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_TUESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_HOLIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_HOLIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_HOLIDAY] = DBNull.Value;
				#endregion del
				//----- ueno del---------- end   2007.11.21

				// �f�[�^�ǉ�
				dataTable.Rows.Add(dataRow);
			}

//----- ueno add---------- start 2007.11.21
			this.Employee_uGrid.DataSource = dataTable.DefaultView;

			// �\�[�g�i�ڕW�Δ�敪, �]�ƈ��敪, ����R�[�h, �ۃR�[�h, �]�ƈ��R�[�h�����j
			string sortStr = string.Format("{0} ASC, {1} ASC, {2} ASC, {3} ASC",//, {4} ASC",
				COL_SALESTARGET_TARGETCONSTRASTCD, COL_SALESTARGET_EMPLOYEEDIVCD,
				COL_SALESTARGET_SUBSECTIONCODE, COL_SALESTARGET_EMPLOYEECODE);//, COL_SALESTARGET_MINSECTIONCODE, COL_SALESTARGET_EMPLOYEECODE);

			dataTable.DefaultView.Sort = sortStr;
//----- ueno add---------- end   2007.11.21

			this.Employee_uGrid.DataBind();
		}
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�i���i�j�O���b�h�\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^�i���i�j���O���b�h�ɕ\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void DispScreenGoods_uGrid()
		{
			// �f�[�^�ǉ��p
			DataRow dataRow;

			// �e�[�u���̒�`
			DataTable dataTable = new DataTable(GOODS_SALESTARGET);

//----- ueno add---------- start 2007.11.21
			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTCD, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTNM, typeof(string));
//----- ueno add---------- end   2007.11.21

			dataTable.Columns.Add(COL_SALESTARGET_MAKERCODE, typeof(int));
			dataTable.Columns.Add(COL_SALESTARGET_MAKERNAME, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_GOODSCODE, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_GOODSNAME, typeof(string));
			// ��ǉ��i���ʕ����j
			DispScreenCommonColumn(ref dataTable);

			foreach (SalesTarget salesTarget in this._goodsSalesTargetList)
			{
				dataRow = dataTable.NewRow();

//----- ueno add---------- start 2007.11.21
				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = salesTarget.TargetContrastCd;
				dataRow[COL_SALESTARGET_TARGETCONSTRASTNM] = SalesTarget.GetTargetContrastNm(salesTarget.TargetContrastCd);
//----- ueno add---------- end   2007.11.21
				dataRow[COL_SALESTARGET_MAKERCODE] = salesTarget.MakerCode;
				dataRow[COL_SALESTARGET_MAKERNAME] = salesTarget.MakerName;
				dataRow[COL_SALESTARGET_GOODSCODE] = salesTarget.GoodsCode;
				dataRow[COL_SALESTARGET_GOODSNAME] = salesTarget.GoodsName;

				// �f�[�^�ݒ�i���ʕ����j
				DispScreenCommonRow(ref dataRow, salesTarget);

				// �f�[�^�ǉ�
				dataTable.Rows.Add(dataRow);
			}

			// ���v�s�ǉ�
			if (this._goodsSalesTargetList.Count > 0)
			{
				dataRow = dataTable.NewRow();

//----- ueno upd---------- start 2007.11.21
				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = DUMMY_TARGETCONSTRASTCD;	// �\�[�g�p
				dataRow[COL_SALESTARGET_TARGETCONSTRASTNM] = VIEW_SALESTARGET_TOTAL;
				dataRow[COL_SALESTARGET_MAKERCODE] = DBNull.Value;
				dataRow[COL_SALESTARGET_MAKERNAME] = "";
				dataRow[COL_SALESTARGET_GOODSCODE] = "";
				dataRow[COL_SALESTARGET_GOODSNAME] = "";
				dataRow[COL_SALESTARGET_MONEY] = DBNull.Value;
				dataRow[COL_SALESTARGET_PROFIT] = DBNull.Value;
				dataRow[COL_SALESTARGET_COUNT] = DBNull.Value;
//----- ueno upd---------- end   2007.11.21

				//----- ueno del---------- start 2007.11.21
				#region del
				//dataRow[COL_SALESTARGET_MONEY_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_TUESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_TUESWDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_TUESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_HOLIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_HOLIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_HOLIDAY] = DBNull.Value;
				#endregion del
				//----- ueno del---------- end   2007.11.21

				// �f�[�^�ǉ�
				dataTable.Rows.Add(dataRow);
			}

//----- ueno add---------- start 2007.11.21
			this.Goods_uGrid.DataSource = dataTable.DefaultView;

			// �\�[�g�i�ڕW�Δ�敪, ���[�J�[�R�[�h, ���i�R�[�h�����j
			string sortStr = string.Format("{0} ASC, {1} ASC, {2} ASC", COL_SALESTARGET_TARGETCONSTRASTCD, COL_SALESTARGET_MAKERCODE, COL_SALESTARGET_GOODSCODE);
			dataTable.DefaultView.Sort = sortStr;
			
//----- ueno add---------- end   2007.11.21

			this.Goods_uGrid.DataBind();
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �ڕW�f�[�^�i����`���j�O���b�h�\������
		///// </summary>
		///// <remarks>
		///// <br>Note		: �ڕW�f�[�^�i����`���j���O���b�h�ɕ\�����܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void DispScreenSalesFormal_uGrid()
		//{
		//    // �f�[�^�ǉ��p
		//    DataRow dataRow;

		//    // �e�[�u���̒�`
		//    DataTable dataTable = new DataTable(SALESFORMAL_SALESTARGET);

		//    dataTable.Columns.Add(COL_SALESTARGET_SALESFORMALCODE, typeof(int));
		//    dataTable.Columns.Add(COL_SALESTARGET_SALESFORMAL, typeof(string));
		//    // ��ǉ��i���ʕ����j
		//    DispScreenCommonColumn(ref dataTable);

		//    foreach (SalesTarget salesTarget in this._salesFormalSalesTargetList)
		//    {
		//        dataRow = dataTable.NewRow();

		//        dataRow[COL_SALESTARGET_SALESFORMALCODE] = salesTarget.SalesFormal;

		//        if (salesTarget.SalesFormal == 10)
		//        {
		//            dataRow[COL_SALESTARGET_SALESFORMAL] = SalesTarget.SALESFORMAL_COUNTER_SALES;
		//        }
		//        else if (salesTarget.SalesFormal == 11)
		//        {
		//            dataRow[COL_SALESTARGET_SALESFORMAL] = SalesTarget.SALESFORMAL_OUTSIDE_SALES;
		//        }
		//        else if (salesTarget.SalesFormal == 20)
		//        {
		//            dataRow[COL_SALESTARGET_SALESFORMAL] = SalesTarget.SALESFORMAL_BUSINESS_SALES;
		//        }
		//        else if (salesTarget.SalesFormal == 30)
		//        {
		//            dataRow[COL_SALESTARGET_SALESFORMAL] = SalesTarget.SALESFORMAL_OTHERS_SALES;
		//        }

		//        // �f�[�^�ݒ�i���ʕ����j
		//        DispScreenCommonRow(ref dataRow, salesTarget);

		//        // �f�[�^�ǉ�
		//        dataTable.Rows.Add(dataRow);
		//    }

		//    // ���v�s�ǉ�
		//    if (this._salesFormalSalesTargetList.Count > 0)
		//    {
		//        dataRow = dataTable.NewRow();

		//        dataRow[COL_SALESTARGET_SALESFORMAL] = VIEW_SALESTARGET_TOTAL;
		//        dataRow[COL_SALESTARGET_MONEY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT] = DBNull.Value;

		//        dataRow[COL_SALESTARGET_MONEY_SUNDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_SUNDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_SUNDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_MONDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_MONDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_MONDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_TUESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_TUESWDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_TUESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_WEDNESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_WEDNESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_WEDNESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_THURSDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_THURSDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_THURSDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_FRIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_FRIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_FRIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_SATURDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_SATURDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_SATURDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_HOLIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_HOLIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_HOLIDAY] = DBNull.Value;

		//        // �f�[�^�ǉ�
		//        dataTable.Rows.Add(dataRow);
		//    }

		//    this.SalesFormal_uGrid.DataSource = dataTable;
		//    this.SalesFormal_uGrid.DataBind();
		//}
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �ڕW�f�[�^�i�̔��ڕW�j�O���b�h�\������
		///// </summary>
		///// <remarks>
		///// <br>Note		: �ڕW�f�[�^�i�̔��ڕW�j���O���b�h�ɕ\�����܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void DispScreenSalesForm_uGrid()
		//{
		//    // �f�[�^�ǉ��p
		//    DataRow dataRow;

		//    // �e�[�u���̒�`
		//    DataTable dataTable = new DataTable(SALESFORM_SALESTARGET);

		//    dataTable.Columns.Add(COL_SALESTARGET_SALESFORMCODE, typeof(int));
		//    dataTable.Columns.Add(COL_SALESTARGET_SALESFORM, typeof(string));
		//    // ��ǉ��i���ʕ����j
		//    DispScreenCommonColumn(ref dataTable);

		//    foreach (SalesTarget salesTarget in this._salesFormSalesTargetList)
		//    {
		//        dataRow = dataTable.NewRow();

		//        dataRow[COL_SALESTARGET_SALESFORMCODE] = salesTarget.SalesFormCode;
		//        dataRow[COL_SALESTARGET_SALESFORM] = salesTarget.SalesFormName;

		//        // �f�[�^�ݒ�i���ʕ����j
		//        DispScreenCommonRow(ref dataRow, salesTarget);

		//        // �f�[�^�ǉ�
		//        dataTable.Rows.Add(dataRow);
		//    }

		//    // ���v�s�ǉ�
		//    if (this._salesFormSalesTargetList.Count > 0)
		//    {
		//        dataRow = dataTable.NewRow();

		//        dataRow[COL_SALESTARGET_SALESFORM] = VIEW_SALESTARGET_TOTAL;
		//        dataRow[COL_SALESTARGET_MONEY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT] = DBNull.Value;

		//        dataRow[COL_SALESTARGET_MONEY_SUNDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_SUNDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_SUNDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_MONDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_MONDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_MONDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_TUESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_TUESWDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_TUESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_WEDNESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_WEDNESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_WEDNESDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_THURSDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_THURSDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_THURSDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_FRIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_FRIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_FRIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_SATURDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_SATURDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_SATURDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_MONEY_HOLIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_PROFIT_HOLIDAY] = DBNull.Value;
		//        dataRow[COL_SALESTARGET_COUNT_HOLIDAY] = DBNull.Value;

		//        // �f�[�^�ǉ�
		//        dataTable.Rows.Add(dataRow);
		//    }

		//    this.SalesForm_uGrid.DataSource = dataTable;
		//    this.SalesForm_uGrid.DataBind();
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�i���Ӑ�j�O���b�h�\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^�i���Ӑ�j���O���b�h�ɕ\�����܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private void DispScreenCustomer_uGrid()
		{
			// �f�[�^�ǉ��p
			DataRow dataRow;

			// �e�[�u���̒�`
			DataTable dataTable = new DataTable(CUSTOMER_SALESTARGET);

			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTCD, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTNM, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_BUSINESSTYPECODE, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_BUSINESSTYPENAME, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_SALESAREACODE, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_SALESAREANAME, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_CUSTOMERCODE, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_CUSTOMERNAME, typeof(string));
			
			// ��ǉ��i���ʕ����j
			DispScreenCommonColumn(ref dataTable);
			
			foreach (SalesTarget salesTarget in this._customerTargetList)
			{
				dataRow = dataTable.NewRow();

				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = salesTarget.TargetContrastCd;
				dataRow[COL_SALESTARGET_TARGETCONSTRASTNM] = SalesTarget.GetTargetContrastNm(salesTarget.TargetContrastCd);
				dataRow[COL_SALESTARGET_BUSINESSTYPECODE] = salesTarget.BusinessTypeCode;
				dataRow[COL_SALESTARGET_BUSINESSTYPENAME] = GetUserGdBdNm(ref this._businessTypeCodeSList, salesTarget.BusinessTypeCode);
				dataRow[COL_SALESTARGET_SALESAREACODE] = salesTarget.SalesAreaCode;
				dataRow[COL_SALESTARGET_SALESAREANAME] = GetUserGdBdNm(ref this._salesAreaCodeSList, salesTarget.SalesAreaCode);
				dataRow[COL_SALESTARGET_CUSTOMERCODE] = salesTarget.CustomerCode;
				dataRow[COL_SALESTARGET_CUSTOMERNAME] = GetCustomerName(salesTarget.CustomerCode);
				
				// �f�[�^�ݒ�i���ʕ����j
				DispScreenCommonRow(ref dataRow, salesTarget);

				// �f�[�^�ǉ�
				dataTable.Rows.Add(dataRow);
			}

			// ���v�s�ǉ�
			if (this._customerTargetList.Count > 0)
			{
				dataRow = dataTable.NewRow();

				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = DUMMY_TARGETCONSTRASTCD;	// �\�[�g�p
				dataRow[COL_SALESTARGET_TARGETCONSTRASTNM] = VIEW_SALESTARGET_TOTAL;
				dataRow[COL_SALESTARGET_BUSINESSTYPECODE] = DBNull.Value;
				dataRow[COL_SALESTARGET_BUSINESSTYPENAME] = "";
				dataRow[COL_SALESTARGET_SALESAREACODE] = DBNull.Value;
				dataRow[COL_SALESTARGET_SALESAREANAME] = "";
				dataRow[COL_SALESTARGET_CUSTOMERCODE] = DBNull.Value;
				dataRow[COL_SALESTARGET_CUSTOMERNAME] = "";
				dataRow[COL_SALESTARGET_MONEY] = DBNull.Value;
				dataRow[COL_SALESTARGET_PROFIT] = DBNull.Value;
				dataRow[COL_SALESTARGET_COUNT] = DBNull.Value;

				//----- ueno del---------- start 2007.11.21
				#region del
				//dataRow[COL_SALESTARGET_MONEY_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_SUNDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_MONDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_TUESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_TUESWDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_TUESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_WEDNESDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_THURSDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_FRIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_SATURDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_MONEY_HOLIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_PROFIT_HOLIDAY] = DBNull.Value;
				//dataRow[COL_SALESTARGET_COUNT_HOLIDAY] = DBNull.Value;
				#endregion del
				//----- ueno del---------- end   2007.11.21

				// �f�[�^�ǉ�
				dataTable.Rows.Add(dataRow);
			}
			this.Customer_uGrid.DataSource = dataTable.DefaultView;

			// �\�[�g�i�ڕW�Δ�敪, ���Ӑ�R�[�h, �Ǝ�R�[�h, �̔��G���A�R�[�h�����j
			string sortStr = string.Format("{0} ASC, {1} ASC, {2} ASC, {3} ASC",
				COL_SALESTARGET_TARGETCONSTRASTCD, COL_SALESTARGET_CUSTOMERCODE, COL_SALESTARGET_BUSINESSTYPECODE, COL_SALESTARGET_SALESAREACODE);

			dataTable.DefaultView.Sort = sortStr;

			this.Customer_uGrid.DataBind();
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ�i���ʕ����j����
		/// </summary>
        /// <param name="uGrid">�O���b�h</param>
		/// <remarks>
		/// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ�i���ʕ����j���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void GridCommonInitializeLayout(UltraGrid uGrid)
		{
			// ����
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Width = WIDTH_SALESTARGET_MONEY;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].CellActivation = Activation.NoEdit;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Format = FORMAT_NUM;

			// �e��
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Width = WIDTH_SALESTARGET_PROFIT;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].CellActivation = Activation.NoEdit;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Format = FORMAT_NUM;

			// ����
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].Width = WIDTH_SALESTARGET_COUNT;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].CellActivation = Activation.NoEdit;
            uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].Format = FORMAT_NUM_DECIMAL;

			//----- ueno del---------- start 2007.11.21
			#region del
			//// ���j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].Width = WIDTH_SALESTARGET_MONEY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].Header.Caption = VIEW_SALESTARGET_MONEY_SUNDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SUNDAY].Format = FORMAT_NUM;

			//// ���j�e��
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].Width = WIDTH_SALESTARGET_PROFIT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].Header.Caption = VIEW_SALESTARGET_PROFIT_SUNDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SUNDAY].Format = FORMAT_NUM;

			//// ���j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].Width = WIDTH_SALESTARGET_COUNT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].Header.Caption = VIEW_SALESTARGET_COUNT_SUNDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SUNDAY].Format = FORMAT_NUM_DECIMAL;

			//// ���j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].Width = WIDTH_SALESTARGET_MONEY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].Header.Caption = VIEW_SALESTARGET_MONEY_MONDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_MONDAY].Format = FORMAT_NUM;


			//// ���j�e��
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].Width = WIDTH_SALESTARGET_PROFIT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].Header.Caption = VIEW_SALESTARGET_PROFIT_MONDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_MONDAY].Format = FORMAT_NUM;

			//// ���j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].Width = WIDTH_SALESTARGET_COUNT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].Header.Caption = VIEW_SALESTARGET_COUNT_MONDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_MONDAY].Format = FORMAT_NUM_DECIMAL;

			//// �Ηj����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].Width = WIDTH_SALESTARGET_MONEY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].Header.Caption = VIEW_SALESTARGET_MONEY_TUESDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_TUESDAY].Format = FORMAT_NUM;

			//// �Ηj�e��
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].Width = WIDTH_SALESTARGET_PROFIT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].Header.Caption = VIEW_SALESTARGET_PROFIT_TUESDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_TUESWDAY].Format = FORMAT_NUM;

			//// �Ηj����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].Width = WIDTH_SALESTARGET_COUNT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].Header.Caption = VIEW_SALESTARGET_COUNT_TUESDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_TUESDAY].Format = FORMAT_NUM_DECIMAL;

			//// ���j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].Width = WIDTH_SALESTARGET_MONEY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].Header.Caption = VIEW_SALESTARGET_MONEY_WEDNESDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_WEDNESDAY].Format = FORMAT_NUM;

			//// ���j�e��
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].Width = WIDTH_SALESTARGET_PROFIT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].Header.Caption = VIEW_SALESTARGET_PROFIT_WEDNESDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_WEDNESDAY].Format = FORMAT_NUM;

			//// ���j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].Width = WIDTH_SALESTARGET_COUNT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].Header.Caption = VIEW_SALESTARGET_COUNT_WEDNESDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_WEDNESDAY].Format = FORMAT_NUM_DECIMAL;

			//// �ؗj����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].Width = WIDTH_SALESTARGET_MONEY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].Header.Caption = VIEW_SALESTARGET_MONEY_THURSDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_THURSDAY].Format = FORMAT_NUM;

			//// �ؗj�e��
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].Width = WIDTH_SALESTARGET_PROFIT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].Header.Caption = VIEW_SALESTARGET_PROFIT_THURSDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_THURSDAY].Format = FORMAT_NUM;

			//// �ؗj����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].Width = WIDTH_SALESTARGET_COUNT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].Header.Caption = VIEW_SALESTARGET_COUNT_THURSDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_THURSDAY].Format = FORMAT_NUM_DECIMAL;

			//// ���j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].Width = WIDTH_SALESTARGET_MONEY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].Header.Caption = VIEW_SALESTARGET_MONEY_FRIDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_FRIDAY].Format = FORMAT_NUM;

			//// ���j�e��
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].Width = WIDTH_SALESTARGET_PROFIT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].Header.Caption = VIEW_SALESTARGET_PROFIT_FRIDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_FRIDAY].Format = FORMAT_NUM;

			//// ���j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].Width = WIDTH_SALESTARGET_COUNT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].Header.Caption = VIEW_SALESTARGET_COUNT_FRIDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_FRIDAY].Format = FORMAT_NUM_DECIMAL;

			//// �y�j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].Width = WIDTH_SALESTARGET_MONEY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].Header.Caption = VIEW_SALESTARGET_MONEY_SATURDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_SATURDAY].Format = FORMAT_NUM;

			//// �y�j�e��
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].Width = WIDTH_SALESTARGET_PROFIT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].Header.Caption = VIEW_SALESTARGET_PROFIT_SATURDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_SATURDAY].Format = FORMAT_NUM;

			//// �y�j����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].Width = WIDTH_SALESTARGET_COUNT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].Header.Caption = VIEW_SALESTARGET_COUNT_SATURDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_SATURDAY].Format = FORMAT_NUM_DECIMAL;

			//// �j�Փ�����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].Width = WIDTH_SALESTARGET_MONEY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].Header.Caption = VIEW_SALESTARGET_MONEY_HOLIDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY_HOLIDAY].Format = FORMAT_NUM;

			//// �j�Փ��e��
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].Width = WIDTH_SALESTARGET_PROFIT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].Header.Caption = VIEW_SALESTARGET_PROFIT_HOLIDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT_HOLIDAY].Format = FORMAT_NUM;

			//// �j�Փ�����
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].Width = WIDTH_SALESTARGET_COUNT;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].Header.Caption = VIEW_SALESTARGET_COUNT_HOLIDAY;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].CellActivation = Activation.NoEdit;
			//uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT_HOLIDAY].Format = FORMAT_NUM_DECIMAL;
			#endregion del
			//----- ueno del---------- end   2007.11.21

			// �w�b�_�[�L���v�V����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			{
				uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Header.Caption = VIEW_SALESTARGET_MONEY_MONTH;
				uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Header.Caption = VIEW_SALESTARGET_PROFIT_MONTH;
				uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].Header.Caption = VIEW_SALESTARGET_COUNT_MONTH;
			}
			else
			{
				uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Header.Caption = VIEW_SALESTARGET_MONEY_TERM;
				uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Header.Caption = VIEW_SALESTARGET_PROFIT_TERM;
				uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_COUNT].Header.Caption = VIEW_SALESTARGET_COUNT_TERM;
			}

			uGrid.DisplayLayout.Bands[0].UseRowLayout = true;

			int rowIndex = uGrid.Rows.Count;

			// ���v�s�ǉ�
			if (rowIndex > 0)
			{
				uGrid.DisplayLayout.Rows[rowIndex - 1].Activation = Activation.Disabled;
                uGrid.DisplayLayout.Rows[rowIndex - 1].Appearance.BackColor = COLOR_TOTAL;
				uGrid.DisplayLayout.Rows[rowIndex - 1].Appearance.ForeColorDisabled = Color.Black;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ�i���_�j����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ�i���_�j���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void InitializeLayout_Section_uGrid()
		{
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONCODE].Hidden = true;

			// ���_����
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].Width = WIDTH_SALESTARGET_SECTIONNAME;
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].Header.Caption = VIEW_SALESTARGET_SECTIONNAME;
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONNAME].CellActivation = Activation.NoEdit;

			GridCommonInitializeLayout(this.Section_uGrid);
		}
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ�i�]�ƈ��j����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ�i�]�ƈ��j���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void InitializeLayout_Employee_uGrid()
		{
//----- ueno add---------- start 2007.11.21
			// �ڕW�Δ�敪�R�[�h
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTCD].Hidden = true;
			
			// �ڕW�Δ�敪����
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Width = WIDTH_SALESTARGET_TARGETCONSTRASTNM;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Caption = VIEW_SALESTARGET_TARGETCONSTRASTNM;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellActivation = Activation.NoEdit;

			// �]�ƈ��敪�R�[�h
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].Hidden = true;
			
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].Width = WIDTH_SALESTARGET_EMPLOYEEDIVCD;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].Header.Caption = VIEW_SALESTARGET_EMPLOYEEDIVCD;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVCD].CellActivation = Activation.NoEdit;
			
			// �]�ƈ��敪����
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].Width = WIDTH_SALESTARGET_EMPLOYEEDIVNM;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].Header.Caption = VIEW_SALESTARGET_EMPLOYEEDIVNM;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].CellActivation = Activation.NoEdit;
			
			// ����R�[�h
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].Hidden = true;
			
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].Width = WIDTH_SALESTARGET_SUBSECTIONCODE;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].Header.Caption = VIEW_SALESTARGET_SUBSECTIONCODE;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONCODE].CellActivation = Activation.NoEdit;
			
			// ���喼��
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].Width = WIDTH_SALESTARGET_SUBSECTIONNAME;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].Header.Caption = VIEW_SALESTARGET_SUBSECTIONNAME;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].CellActivation = Activation.NoEdit;
			
			// �ۃR�[�h
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].Hidden = true;
			
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].Width = WIDTH_SALESTARGET_MINSECTIONCODE;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].Header.Caption = VIEW_SALESTARGET_MINSECTIONCODE;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONCODE].CellActivation = Activation.NoEdit;
			
			// �ۖ���
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].Hidden = true;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].Width = WIDTH_SALESTARGET_MINSECTIONNAME;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].Header.Caption = VIEW_SALESTARGET_MINSECTIONNAME;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MINSECTIONNAME].CellActivation = Activation.NoEdit;
			
//----- ueno add---------- end   2007.11.21

			// �]�ƈ��R�[�h
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].Width = WIDTH_SALESTARGET_EMPLOYEECODE;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].Header.Caption = VIEW_SALESTARGET_EMPLOYEECODE;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].CellActivation = Activation.NoEdit;

			// �]�ƈ�����
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].Width = WIDTH_SALESTARGET_NAME;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].Header.Caption = VIEW_SALESTARGET_NAME;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_NAME].CellActivation = Activation.NoEdit;

			GridCommonInitializeLayout(this.Employee_uGrid);
		}
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ�i���i�j����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ�i���i�j���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void InitializeLayout_Goods_uGrid()
		{
//----- ueno add---------- start 2007.11.21
			// �ڕW�Δ�敪�R�[�h
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTCD].Hidden = true;

			// �ڕW�Δ�敪����
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Width = WIDTH_SALESTARGET_TARGETCONSTRASTNM;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Caption = VIEW_SALESTARGET_TARGETCONSTRASTNM;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellActivation = Activation.NoEdit;
//----- ueno add---------- end   2007.11.21

			// ���[�J�[�R�[�h
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].Hidden = true;

			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].Width = WIDTH_SALESTARGET_MAKERCODE;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].Header.Caption = VIEW_SALESTARGET_MAKERCODE;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERCODE].CellActivation = Activation.NoEdit;

			// ���[�J�[����
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].Width = WIDTH_SALESTARGET_MAKERNAME;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].Header.Caption = VIEW_SALESTARGET_MAKERNAME;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].CellActivation = Activation.NoEdit;

			// ���i�R�[�h
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].Hidden = true;

			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].Width = WIDTH_SALESTARGET_GOODSCODE;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].Header.Caption = VIEW_SALESTARGET_GOODSCODE;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSCODE].CellActivation = Activation.NoEdit;

			// ���i����
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].Width = WIDTH_SALESTARGET_GOODSNAME;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].Header.Caption = VIEW_SALESTARGET_GOODSNAME;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODSNAME].CellActivation = Activation.NoEdit;

			GridCommonInitializeLayout(this.Goods_uGrid);
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �O���b�h���C�A�E�g�ݒ�i����`���j����
		///// </summary>
		///// <remarks>
		///// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ�i����`���j���s���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void InitializeLayout_SalesFormal_uGrid()
		//{
		//    // ����`���R�[�h
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMALCODE].Hidden = true;

		//    // ����`��
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Width = WIDTH_SALESTARGET_SALESFORMAL;
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Caption = VIEW_SALESTARGET_SALESFORMAL;
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellActivation = Activation.NoEdit;

		//    GridCommonInitializeLayout(this.SalesFormal_uGrid);
		//}
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �O���b�h���C�A�E�g�ݒ�i�̔��`�ԁj����
		///// </summary>
		///// <remarks>
		///// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ�i�̔��`�ԁj���s���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void InitializeLayout_SalesForm_uGrid()
		//{
		//    // �̔��`�ԃR�[�h
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMCODE].Hidden = true;

		//    // �̔��`�Ԗ���
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Width = WIDTH_SALESTARGET_SALESFORM;
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Caption = VIEW_SALESTARGET_SALESFORM;
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellActivation = Activation.NoEdit;

		//    GridCommonInitializeLayout(this.SalesForm_uGrid);
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ�i���Ӑ�j����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ�i���Ӑ�j���s���܂��B</br>
		/// <br>Programmer	: 30167</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void InitializeLayout_Customer_uGrid()
		{
			// �ڕW�Δ�敪�R�[�h
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTCD].Hidden = true;

			// �ڕW�Δ�敪����
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Width = WIDTH_SALESTARGET_TARGETCONSTRASTNM;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Caption = VIEW_SALESTARGET_TARGETCONSTRASTNM;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellActivation = Activation.NoEdit;

			// ���Ӑ�R�[�h
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].Hidden = true;
			
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].Width = WIDTH_SALESTARGET_CUSTOMERCODE;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].Header.Caption = VIEW_SALESTARGET_CUSTOMERCODE;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERCODE].CellActivation = Activation.NoEdit;
			
			// ���Ӑ於��
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].Width = WIDTH_SALESTARGET_CUSTOMERNAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].Header.Caption = VIEW_SALESTARGET_CUSTOMERNAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].CellActivation = Activation.NoEdit;

			// �Ǝ�R�[�h
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].Hidden = true;
			
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].Width = WIDTH_SALESTARGET_BUSINESSTYPECODE;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].Header.Caption = VIEW_SALESTARGET_BUSINESSTYPECODE;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPECODE].CellActivation = Activation.NoEdit;

			// �Ǝ햼��
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].Width = WIDTH_SALESTARGET_BUSINESSTYPENAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].Header.Caption = VIEW_SALESTARGET_BUSINESSTYPENAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].CellActivation = Activation.NoEdit;

			// �̔��G���A�R�[�h
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].Hidden = true;
			
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].Width = WIDTH_SALESTARGET_SALESAREACODE;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].Header.Caption = VIEW_SALESTARGET_SALESAREACODE;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREACODE].CellActivation = Activation.NoEdit;
			
			// �̔��G���A����
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].Width = WIDTH_SALESTARGET_SALESAREANAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].Header.Caption = VIEW_SALESTARGET_SALESAREANAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESAREANAME].CellActivation = Activation.NoEdit;
			
			GridCommonInitializeLayout(this.Customer_uGrid);
		}

//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���������`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���������̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private bool CheckSearchCondition()
		{
			string errMsg = "";
			string targetDivideCode = "";
            //int month = 0;
            bool result;

			try
			{
				if (this.TargetDivideCode_tEdit.DataText == "")
				{
					errMsg = "�ڕW�敪�R�[�h����͂��Ă�������";
					this.TargetDivideCode_tEdit.Focus();
					return (false);
				}
				// ���ԖڕW
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
				{
					targetDivideCode = this.TargetDivideCode_tEdit.DataText.TrimEnd();
					if (targetDivideCode.Length != 6)
					{
						errMsg = "���ԖڕW�́A�ڕW�敪�R�[�h��N���̌`�œ��͂��Ă�������\nex.2007�N1���̏ꍇ��200701";
						this.TargetDivideCode_tEdit.Focus();
						return (false);
					}


                    if (targetDivideCode == "000101")
                    {
                        errMsg = "�ڕW�敪�R�[�h�𐳂����ݒ肵�Ă�������";
                        this.TargetDivideCode_tEdit.Focus();
                        return (false);
                    }
                    //int num;
                    //if (!int.TryParse(targetDivideCode, out num))
                    //{
                    //    errMsg = "���ԖڕW�́A�ڕW�敪�R�[�h��N���̌`�œ��͂��Ă�������\nex.2007�N1���̏ꍇ��200701";
                    //    this.TargetDivideCode_tEdit.Focus();
                    //    return (false);
                    //}

                    //month = int.Parse(targetDivideCode.Substring(4, 2));
                    //if (month < 1 || month > 12)
                    //{
                    //    errMsg = "���ԖڕW�́A�ڕW�敪�R�[�h��N���̌`�œ��͂��Ă�������\nex.2007�N1���̏ꍇ��200701";
                    //    this.TargetDivideCode_tEdit.Focus();
                    //    return (false);
                    //}

                    try
                    {
                        string year = targetDivideCode.Substring(0, 4);
                        string month = targetDivideCode.Substring(4, 2);
                        result = CheckNum(year.ToCharArray());
                        if (!result)
                        {
                            errMsg = "���ԖڕW�́A�ڕW�敪�R�[�h��N���̌`�œ��͂��Ă�������\nex.2007�N1���̏ꍇ��200701";
                            this.TargetDivideCode_tEdit.Focus();
                            return (false);
                        }
                        result = CheckNum(month.ToCharArray());
                        if (!result)
                        {
                            errMsg = "���ԖڕW�́A�ڕW�敪�R�[�h��N���̌`�œ��͂��Ă�������\nex.2007�N1���̏ꍇ��200701";
                            this.TargetDivideCode_tEdit.Focus();
                            return (false);
                        }
                        DateTime targetDate = new DateTime(int.Parse(year), int.Parse(month), 1);

                        if (targetDate.Year < 1900)
                        {
                            errMsg = "�ڕW�敪�R�[�h�𐳂����ݒ肵�Ă�������";
                            this.TargetDivideCode_tEdit.Focus();
                            return (false);
                        }
                    }
                    catch
                    {
                        errMsg = "���ԖڕW�́A�ڕW�敪�R�[�h��N���̌`�œ��͂��Ă�������\nex.2007�N1���̏ꍇ��200701";
                        this.TargetDivideCode_tEdit.Focus();
						return (false);
                    }
                    
				}
			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 							// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
							this.Name,						// �A�Z���u��ID
							errMsg, 						// �\�����郁�b�Z�[�W
							0,								// �X�e�[�^�X�l
							MessageBoxButtons.OK);			// �\������{�^��
				}
			}

			// ���ԖڕW
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			{
                this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime(int.Parse(targetDivideCode.Substring(0, 4)), int.Parse(targetDivideCode.Substring(4, 2)), 1));
			}

			return (true);
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���l�ϊ��`�F�b�N
        /// </summary>
        /// <param name="str">�`�F�b�N������</param>
        /// <returns>True:���l�ϊ��\(���l�̂�)�AFalse:���l�ϊ��s��</returns>
        /// <remarks>
        /// <br>Note		: ���l�ϊ��\���`�F�b�N���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.27</br>
        /// </remarks>
        private bool CheckNum(char[] str)
        {
            foreach (char targetChar in str)
            {
                if (targetChar < '0' || '9' < targetChar)
                {
                    return (false);
                }
            }
            return (true);
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���������ݒ菈��
		/// </summary>
        /// <param name="extrInfo">��������</param>
		/// <remarks>
		/// <br>Note		: ���������̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void GetExtrInfo(out ExtrInfo_MAMOK09197EA extrInfo)
		{
			extrInfo = new ExtrInfo_MAMOK09197EA();

			// ��ƃR�[�h
			extrInfo.EnterpriseCode = this._enterpriseCode;
			// ���_�R�[�h
			extrInfo.SelectSectCd = new string[1];
			extrInfo.SelectSectCd[0] = this._sectionCode;
			// �ڕW�ݒ�敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            extrInfo.TargetSetCd = int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            //extrInfo.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			// �ڕW�敪�R�[�h
			extrInfo.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
			// �ڕW�敪����
			extrInfo.TargetDivideName = this.TargetDivideName_tEdit.DataText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^��������
		/// </summary>
        /// <param name="salesTargetList">�ڕW�f�[�^���X�g</param>
        /// <param name="extrInfo">��������</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^���������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool SearchSalesTarget(out List<SalesTarget> salesTargetList, ExtrInfo_MAMOK09197EA extrInfo)
		{
			int status = this._salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					break;
				default:
					TMsgDisp.Show(this, 						// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						this.Name,								// �A�Z���u��ID
						ctPGNM, 			 �@�@				// �v���O��������
						"Search",								// ��������
						TMsgDisp.OPE_GET,						// �I�y���[�V����
						"�ڕW�f�[�^�̓ǂݍ��݂Ɏ��s���܂���", // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._salesTargetAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					return (false);
			}
			return (true);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���_�ڕW�f�[�^��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���_�ڕW�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool SearchSectionTarget()
		{
			ExtrInfo_MAMOK09197EA extrInfo;

			// ���������ݒ�
			GetExtrInfo(out extrInfo);
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;

			// �ڕW�f�[�^����
			bool bStatus = SearchSalesTarget(out this._sectionSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �]�ƈ��ڕW�f�[�^��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �]�ƈ��ڕW�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool SearchEmployeeTarget()
		{
			ExtrInfo_MAMOK09197EA extrInfo;

			// ���������ݒ�
			GetExtrInfo(out extrInfo);
			//----- ueno upd---------- start 2007.11.21
			// �C�ӂ̏]�ƈ��ڕW�Δ�敪��ݒ�
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
			//----- ueno upd---------- end   2007.11.21

			// �ڕW�f�[�^����
			bool bStatus = SearchSalesTarget(out this._employeeSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���i�ڕW�f�[�^��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���i�ڕW�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool SearchGoodsTarget()
		{
			ExtrInfo_MAMOK09197EA extrInfo;

			// ���������ݒ�
			GetExtrInfo(out extrInfo);
			//----- ueno upd---------- start 2007.11.21
			// �C�ӂ̏��i�ڕW�Δ�敪��ݒ�
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods;
            extrInfo.TargetContrastCd = this._goodsTargetConstrastCd;

            //������̂����ňꗗ�ɉ����o�Ȃ��I�I�I�I�I�I�I
			//----- ueno upd---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            extrInfo.BLCode = this._bLCode;
            extrInfo.BLGroupCode = this._bLGroupCode;
            extrInfo.SalesTypeCode = this._salesCode;
            extrInfo.ItemTypeCode = this._enterpriseGanreCode;
            //string[] strTemp = new string[1];
            //strTemp[0] = this._sectionCode;
            //extrInfo.SelectSectCd = strTemp;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

			// �ڕW�f�[�^����
			bool bStatus = SearchSalesTarget(out this._goodsSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			return (true);
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// ����`���ڕW�f�[�^��������
		///// </summary>
		///// <remarks>
		///// <br>Note		: ����`���ڕW�f�[�^��ݒ肵�܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool SearchSalesFormalTarget()
		//{
		//    ExtrInfo_MAMOK09197EA extrInfo;

		//    // ���������ݒ�
		//    GetExtrInfo(out extrInfo);
		//    extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;

		//    // �ڕW�f�[�^����
		//    bool bStatus = SearchSalesTarget(out this._salesFormalSalesTargetList, extrInfo);
		//    if (!bStatus)
		//    {
		//        return (false);
		//    }

		//    return (true);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �̔��`�ԖڕW�f�[�^��������
		///// </summary>
		///// <remarks>
		///// <br>Note		: �̔��`�ԖڕW�f�[�^��ݒ肵�܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool SearchSalesFormTarget()
		//{
		//    ExtrInfo_MAMOK09197EA extrInfo;

		//    // ���������ݒ�
		//    GetExtrInfo(out extrInfo);
		//    extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;

		//    // �ڕW�f�[�^����
		//    bool bStatus = SearchSalesTarget(out this._salesFormSalesTargetList, extrInfo);
		//    if (!bStatus)
		//    {
		//        return (false);
		//    }

		//    return (true);
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���Ӑ�ڕW�f�[�^��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���Ӑ�ڕW�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private bool SearchCustomerTarget()
		{
			ExtrInfo_MAMOK09197EA extrInfo;

			// ���������ݒ�
			GetExtrInfo(out extrInfo);
			// �C�ӂ̓��Ӑ�ڕW�Δ�敪��ݒ�
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;

			// �ڕW�f�[�^����
			bool bStatus = SearchSalesTarget(out this._customerTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			return (true);
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�V�K�쐬����
		/// </summary>
        /// <param name="salesTarget">�ڕW�f�[�^</param>
        /// <param name="searchFlag">�����t���O</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^��V�K�ɍ쐬���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void CreateSalesTarget(out SalesTarget salesTarget, bool searchFlag)
		{
			salesTarget = new SalesTarget();

			// ��ƃR�[�h
			salesTarget.EnterpriseCode = this._enterpriseCode;
			// ���_
			salesTarget.SectionCode = this._sectionCode;

			if (searchFlag == true)
			{
				// ���ԖڕW
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
				{
					// �K�p���ԁi�J�n�j
					salesTarget.ApplyStaDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), 1);
					// �K�p���ԁi�I���j
					int days = DateTime.DaysInMonth(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth());
					salesTarget.ApplyEndDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), days);
				}
				// �ʖڕW
				else
				{
					// �K�p���ԁi�J�n�j
					salesTarget.ApplyStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
					// �K�p���ԁi�I���j
					salesTarget.ApplyEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();
				}

				// �ڕW�敪�R�[�h
				salesTarget.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
				// �ڕW�敪����
				salesTarget.TargetDivideName = this.TargetDivideName_tEdit.DataText;

			}
			else
			{
				// �K�p���ԁi�J�n�j
				salesTarget.ApplyStaDate = new DateTime();
				// �K�p���ԁi�I���j
				salesTarget.ApplyEndDate = new DateTime();
				// �K�p���ԁi�J�n�j
				salesTarget.ApplyStaDate = new DateTime();
				// �K�p���ԁi�I���j
				salesTarget.ApplyEndDate = new DateTime();

				// �ڕW�敪�R�[�h
				salesTarget.TargetDivideCode = "";
				// �ڕW�敪����
				salesTarget.TargetDivideName = "";

			}
			// �ڕW�ݒ�敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            salesTarget.TargetSetCd = int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            //salesTarget.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
            //// �����䗦
            //salesTarget.WeekdayRatio = RATIO;
            //// �y���䗦
            //salesTarget.SatSunRatio = RATIO;
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �䗦�v�Z���ʕ\�������i���ʁj
		///// </summary>
		///// <param name="uGrid">�O���b�h</param>
		///// <remarks>
		///// <br>Note		: �䗦����ڕW�i���ʁj���v�Z���\�����܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void CalcFromRatioSalesDay(UltraGrid uGrid)
		//{

		//    double salesTarget = 0;
		//    double[] salesTargetDayOfWeek;

		//    DateTime targetDateSt;
		//    int days;
		//    DateTime targetDateEd;

		//    if ((int)this.TargetSetCd_uOptionSet.Value == 10)
		//    {
		//        targetDateSt = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), 1);
		//        days = DateTime.DaysInMonth(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth());
		//        targetDateEd = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), days);
		//    }
		//    else
		//    {
		//        targetDateSt = this.ApplyStaDate_tDateEdit.GetDateTime();
		//        targetDateEd = this.ApplyEndDate_tDateEdit.GetDateTime();
		//    }

		//    for (int index = 0; index < (uGrid.Rows.Count - 1); index++)
		//    {
		//        if (uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY].Text != "")
		//        {
		//            salesTarget = double.Parse(uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY].Text);
		//            // �䗦�v�Z
		//            SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//                out salesTargetDayOfWeek,
		//                salesTarget,
		//                0,
		//                targetDateSt,
		//                targetDateEd,
		//                this._sectionCode,
		//                this._ldgCalcRatioMngList,
		//                this._holidaySettingDic);

		//            // ���j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_SUNDAY].Value = salesTargetDayOfWeek[0];
		//            // ���j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_MONDAY].Value = salesTargetDayOfWeek[1];
		//            // �Ηj����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_TUESDAY].Value = salesTargetDayOfWeek[2];
		//            // ���j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_WEDNESDAY].Value = salesTargetDayOfWeek[3];
		//            // �ؗj����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_THURSDAY].Value = salesTargetDayOfWeek[4];
		//            // ���j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_FRIDAY].Value = salesTargetDayOfWeek[5];
		//            // �y�j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_SATURDAY].Value = salesTargetDayOfWeek[6];
		//            // �j�Փ�����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_HOLIDAY].Value = salesTargetDayOfWeek[7];
		//        }

		//        if (uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT].Text != "")
		//        {
		//            salesTarget = double.Parse(uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT].Text);
		//            // �䗦�v�Z
		//            SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//                out salesTargetDayOfWeek,
		//                salesTarget,
		//                0,
		//                targetDateSt,
		//                targetDateEd,
		//                this._sectionCode,
		//                this._ldgCalcRatioMngList,
		//                this._holidaySettingDic);

		//            // ���j�e��
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_SUNDAY].Value = salesTargetDayOfWeek[0];
		//            // ���j�e��
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_MONDAY].Value = salesTargetDayOfWeek[1];
		//            // �Ηj�e��
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_TUESWDAY].Value = salesTargetDayOfWeek[2];
		//            // ���j�e��
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_WEDNESDAY].Value = salesTargetDayOfWeek[3];
		//            // �ؗj�e��
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_THURSDAY].Value = salesTargetDayOfWeek[4];
		//            // ���j�e��
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_FRIDAY].Value = salesTargetDayOfWeek[5];
		//            // �y�j�e��
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_SATURDAY].Value = salesTargetDayOfWeek[6];
		//            // �j�Փ��e��
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_HOLIDAY].Value = salesTargetDayOfWeek[7];
		//        }

		//        if (uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT].Text != "")
		//        {
		//            salesTarget = double.Parse(uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT].Text);
		//            // �䗦�v�Z
		//            SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//                out salesTargetDayOfWeek,
		//                salesTarget,
		//                1,
		//                targetDateSt,
		//                targetDateEd,
		//                this._sectionCode,
		//                this._ldgCalcRatioMngList,
		//                this._holidaySettingDic);

		//            // ���j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_SUNDAY].Value = salesTargetDayOfWeek[0];
		//            // ���j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_MONDAY].Value = salesTargetDayOfWeek[1];
		//            // �Ηj����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_TUESDAY].Value = salesTargetDayOfWeek[2];
		//            // ���j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_WEDNESDAY].Value = salesTargetDayOfWeek[3];
		//            // �ؗj����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_THURSDAY].Value = salesTargetDayOfWeek[4];
		//            // ���j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_FRIDAY].Value = salesTargetDayOfWeek[5];
		//            // �y�j����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_SATURDAY].Value = salesTargetDayOfWeek[6];
		//            // �j�Փ�����
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_HOLIDAY].Value = salesTargetDayOfWeek[7];
		//        }
		//    }
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^���v�v�Z����
		/// </summary>
        /// <param name="uGrid">�O���b�h</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^�̍��v���v�Z���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void CalcTotalSalesTarget(UltraGrid uGrid)
		{
			int rowIndex;
			double salesTargetMoney = 0;
			double salesTargetProfit = 0;
			double salesTargetCount = 0;

			if (uGrid.Rows.Count > 0)
			{
				rowIndex = uGrid.Rows.Count;
				for (int index = 0; index < (rowIndex - 1); index++)
				{
					if (uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY].Value != DBNull.Value)
					{
						salesTargetMoney += double.Parse(uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY].Value.ToString());
					}
					if (uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT].Value != DBNull.Value)
					{
						salesTargetProfit += double.Parse(uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT].Value.ToString());
					}
					if (uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT].Value != DBNull.Value)
					{
						salesTargetCount += double.Parse(uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT].Value.ToString());
					}
				}
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COL_SALESTARGET_MONEY].Value = salesTargetMoney;
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COL_SALESTARGET_PROFIT].Value = salesTargetProfit;
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COL_SALESTARGET_COUNT].Value = salesTargetCount;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�V�K�쐬����
		/// </summary>
        /// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^��V�K�쐬���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private bool BeforeShowNewSalesTarget(SalesTarget salesTarget)
		{
			bool bStatus;
			int status = this.CustomerTarget_uTabControl.SelectedTab.Index;
			switch (status)
			{
				case 0:
					// ���_�ڕW
					bStatus = ShowSectionTarget(ref salesTarget);
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 1:
					// �]�ƈ��ڕW
					bStatus = ShowEmployeeTarget(ref salesTarget);
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 2:
					// ���i�ڕW
					bStatus = ShowGoodsTarget(ref salesTarget);
					if (!bStatus)
					{
						return (false);
					}
					break;

//----- ueno add---------- start 2007.11.21
				case 3:
					// ���Ӑ�ڕW
					bStatus = ShowCustomerTarget(ref salesTarget);
					if (!bStatus)
					{
						return (false);
					}
					break;
//----- ueno add---------- end   2007.11.21
				
				//----- ueno del---------- start 2007.11.21
				#region del
				//case 3:
				//    // ����`���ڕW
				//    bStatus = ShowSalesFormalTarget(ref salesTarget);
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				//case 4:
				//    // �̔��`�ԖڕW
				//    bStatus = ShowSalesFormTarget(ref salesTarget);
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				#endregion del
				//----- ueno del---------- end   2007.11.21

			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            if (salesTarget.TargetSetCd == 10)
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 0;// SelectedItem.DataValue = salesTarget.TargetSetCd;
            }
            else
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 1;
            }
            //this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
            this.TargetDivideCode_tEdit.DataText = salesTarget.TargetDivideCode;
            this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate);
            this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate);

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���_�ڕW���͉�ʕ\������
		/// </summary>
        /// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �V�K���_�ڕW�̓��͉�ʂ�\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private bool ShowSectionTarget(ref SalesTarget salesTarget)
		{
			MAMOK09110UA sectionTarget = new MAMOK09110UA();
			salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			salesTarget.EmployeeCode = EMPLOYEECODE_SECTION;
			sectionTarget.SalesTarget = salesTarget;
			sectionTarget.Mode = 0;
			sectionTarget.SearchFlag = this._searchFlag;
			sectionTarget.ShowDialog();

			if (sectionTarget.DialogResult == DialogResult.OK)
			{
                salesTarget = sectionTarget.SalesTarget.Clone();
				return (true);
			}

			return (false);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �]�ƈ��ڕW���͉�ʕ\������
		/// </summary>
        /// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �V�K�]�ƈ��ڕW�̓��͉�ʂ�\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool ShowEmployeeTarget(ref SalesTarget salesTarget)
		{
			MAMOK09110UA employeeTarget = new MAMOK09110UA();
			//----- ueno upd---------- start 2007.11.21
			// �ڕW�Δ�敪�ݒ�i0:�����O�V�K, 0�ȊO:������V�K�j
			if (this._empTargetConstrastCd == 0)
			{
				// �����O�V�K���̓f�t�H���g�ݒ�
				salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndSubSec;
			}
			else
			{
				salesTarget.TargetContrastCd = this._empTargetConstrastCd;
			}
			//----- ueno upd---------- end   2007.11.21
			employeeTarget.SalesTarget = salesTarget;
			employeeTarget.Mode = 0;
			employeeTarget.SearchFlag = this._searchFlag;
			employeeTarget.ShowDialog();

			if (employeeTarget.DialogResult == DialogResult.OK)
			{
//----- ueno add---------- start 2007.11.21
				this._empTargetConstrastCd = employeeTarget.SalesTarget.TargetContrastCd;
				this._employeeDivCd = employeeTarget.SalesTarget.EmployeeDivCd;
				this._subSectionCode = employeeTarget.SalesTarget.SubSectionCode;
				this._minSectionCode = employeeTarget.SalesTarget.MinSectionCode;
//----- ueno add---------- end   2007.11.21
                this._employeeCode = employeeTarget.SalesTarget.EmployeeCode;

				salesTarget = employeeTarget.SalesTarget.Clone();
				return (true);
			}
			return (false);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���i�ڕW���͉�ʕ\������
		/// </summary>
        /// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �V�K���i�ڕW�̓��͉�ʂ�\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool ShowGoodsTarget(ref SalesTarget salesTarget)
		{
			MAMOK09130UA goodsTarget = new MAMOK09130UA();

			//----- ueno upd---------- start 2007.11.21
			// �ڕW�Δ�敪�ݒ�i0:�����O�V�K, 0�ȊO:������V�K�j
			if (this._goodsTargetConstrastCd == 0)
			{
				// �����O�V�K���̓f�t�H���g�ݒ�
				salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMaker;
			}
			else
			{
				salesTarget.TargetContrastCd = this._goodsTargetConstrastCd;
			}
			//----- ueno upd---------- end   2007.11.21
			
			//----- ueno del---------- start 2007.11.21
			//salesTarget.CarrierCode = -1;
			//salesTarget.CellphoneModelCode = CELLPHONEMODELCODE_NONE;
			//salesTarget.MakerCode = -1;
			//----- ueno del---------- end   2007.11.21
			goodsTarget.SalesTarget = salesTarget;
			goodsTarget.Mode = 0;
			goodsTarget.SearchFlag = this._searchFlag;
			goodsTarget.ShowDialog();

			if (goodsTarget.DialogResult == DialogResult.OK)
			{
//----- ueno add---------- start 2007.11.21
				this._goodsTargetConstrastCd = goodsTarget.SalesTarget.TargetContrastCd;
//----- ueno add---------- end   2007.11.21
				this._goodsCode = goodsTarget.SalesTarget.GoodsCode;
				this._makerCode = goodsTarget.SalesTarget.MakerCode;


                salesTarget = goodsTarget.SalesTarget.Clone();
				return (true);
			}
			return (false);
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// ����`���ڕW���͉�ʕ\������
		///// </summary>
		///// <param name="salesTarget">�ڕW�f�[�^</param>
		///// <remarks>
		///// <br>Note		: �V�K����`���ڕW�̓��͉�ʂ�\�����܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool ShowSalesFormalTarget(ref SalesTarget salesTarget)
		//{
		//    MAMOK09150UA salesFormalTarget = new MAMOK09150UA();
		//    salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
		//    salesTarget.SalesFormal = -1;
		//    salesFormalTarget.SalesTarget = salesTarget;
		//    salesFormalTarget.Mode = 0;
		//    salesFormalTarget.SearchFlag = this._searchFlag;
		//    salesFormalTarget.ShowDialog();

		//    if (salesFormalTarget.DialogResult == DialogResult.OK)
		//    {
		//        this._salesFormalCode = salesFormalTarget.SalesTarget.SalesFormal;

		//        salesTarget = salesFormalTarget.SalesTarget.Clone();

		//        return (true);
		//    }

		//    return (false);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �̔��`�ԖڕW���͉�ʕ\������
		///// </summary>
		///// <param name="salesTarget">�ڕW�f�[�^</param>
		///// <remarks>
		///// <br>Note		: �V�K�̔��`�ԖڕW�̓��͉�ʂ�\�����܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool ShowSalesFormTarget(ref SalesTarget salesTarget)
		//{
		//    MAMOK09170UA salesFormTarget = new MAMOK09170UA();
		//    salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;
		//    salesTarget.SalesFormCode = -1;
		//    salesFormTarget.SalesTarget = salesTarget;
		//    salesFormTarget.Mode = 0;
		//    salesFormTarget.SearchFlag = this._searchFlag;
		//    salesFormTarget.ShowDialog();

		//    if (salesFormTarget.DialogResult == DialogResult.OK)
		//    {
		//        this._salesFormCode = salesFormTarget.SalesTarget.SalesFormCode;

		//        salesTarget = salesFormTarget.SalesTarget.Clone();

		//        return (true);
		//    }

		//    return (false);
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���Ӑ�ڕW���͉�ʕ\������
		/// </summary>
		/// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �V�K���Ӑ�ڕW�̓��͉�ʂ�\�����܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private bool ShowCustomerTarget(ref SalesTarget salesTarget)
		{
			DCKHN09190UA customerTarget = new DCKHN09190UA();

			// �ڕW�Δ�敪�ݒ�i0:�����O�V�K, 0�ȊO:������V�K�j
			if (this._custTargetConstrastCd == 0)
			{
				// �����O�V�K���̓f�t�H���g�ݒ�
				salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;
			}
			else
			{
				salesTarget.TargetContrastCd = this._custTargetConstrastCd;
			}

			customerTarget.SalesTarget = salesTarget;
			customerTarget.Mode = 0;
			customerTarget.SearchFlag = this._searchFlag;
			customerTarget.ShowDialog();

			if (customerTarget.DialogResult == DialogResult.OK)
			{
				this._custTargetConstrastCd = customerTarget.SalesTarget.TargetContrastCd;
				this._businessTypeCode = customerTarget.SalesTarget.BusinessTypeCode;
				this._salesAreaCode = customerTarget.SalesTarget.SalesAreaCode;
				this._customerCode = customerTarget.SalesTarget.CustomerCode;

				salesTarget = customerTarget.SalesTarget.Clone();
				return (true);
			}
			return (false);
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���_�ڕW�Q�Ɖ�ʕ\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���_�ڕW�̎Q�Ɖ�ʂ�\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool ReferSectionTarget()
		{
			if (this.Section_uGrid.ActiveRow == null)
			{
				return (false);
			}

			foreach (SalesTarget salesTarget in this._sectionSalesTargetList)
			{
				if (salesTarget.SectionCode == this._sectionCode)
				{
					MAMOK09110UA sectionTarget = new MAMOK09110UA();
					salesTarget.EmployeeCode = EMPLOYEECODE_SECTION;
					sectionTarget.SalesTarget = salesTarget;
					sectionTarget.Mode = 2;
					sectionTarget.ShowDialog();
				}
			}

			return (false);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڍזڕW�ҏW�O����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I�����ꂽ�ڍזڕW�f�[�^��ҏW���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void BeforeEditSalesTarget()
		{
			if (this._uGrid.ActiveRow == null)
			{
				return;
			}

			if (this._uGrid != Section_uGrid)
			{
				// ���v�s�������ꍇ
				if ((this._uGrid.ActiveRow.Index + 1) == this._uGrid.Rows.Count)
				{
					return;
				}
			}
			// �A�N�e�B�u�s�擾
			SetBeforeActiveRow();

            int scrollRegionPosition = this._uGrid.DisplayLayout.RowScrollRegions[0].ScrollPosition;

			// �ڍזڕW�ҏW
			bool bStatus = EditSalesTarget();
			if (!bStatus)
			{
				return;
			}

			//----- ueno del---------- start 2007.11.21
			//// �}�X�^�e�[�u���ǂݍ���
			//int status = LoadMasterTable();
			//if (status != 0)
			//{
			//    return;
			//}
			//----- ueno del---------- end   2007.11.21

			// �ڍזڕW�f�[�^����
			bStatus = SearchAllSalesTarget();
			if (!bStatus)
			{
				return;
			}

			// ��ʕ\��
			DispScreen();

            // �X�N���[���o�[�̈ʒu�ݒ�
            this._uGrid.DisplayLayout.RowScrollRegions[0].ScrollPosition = scrollRegionPosition;

			// �R���g���[������
			SetControlEnabled();

			// �A�N�e�B�u�s�ݒ�
			SetActiveRow();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڍזڕW�ҏW����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I�����ꂽ�ڍזڕW�f�[�^��ҏW���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private bool EditSalesTarget()
		{
			bool bStatus;
			int status = this.CustomerTarget_uTabControl.SelectedTab.Index;
			switch (status)
			{
				case 0:
					// ���_�ڕW
					bStatus = EditSectionTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 1:
					// �]�ƈ��ڕW
					bStatus = EditEmployeeTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 2:
					// ���i�ڕW
					bStatus = EditGoodsTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
//----- ueno add---------- start 2007.11.21
				case 3:
					// ���Ӑ�ڕW
					bStatus = EditCustomerTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
//----- ueno add---------- end   2007.11.21

				//----- ueno del---------- start 2007.11.21
				#region del
				//case 3:
				//    // ����`���ڕW
				//    bStatus = EditSalesFormalTarget();
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				//case 4:
				//    // �̔��`�ԖڕW
				//    bStatus = EditSalesFormTarget();
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				#endregion del
				//----- ueno del---------- end   2007.11.21
			}

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���_�ڕW�ҏW��ʕ\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���_�ڕW�̕ҏW��ʂ�\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private bool EditSectionTarget()
		{
			if (this.Section_uGrid.ActiveRow == null)
			{
				return (false);
			}

			foreach (SalesTarget salesTarget in this._sectionSalesTargetList)
			{
				if (salesTarget.SectionCode == this._sectionCode)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                    salesTarget.SectionCode = this._sectionCode;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

					MAMOK09110UA sectionTarget = new MAMOK09110UA();
					salesTarget.EmployeeCode = EMPLOYEECODE_SECTION;
					sectionTarget.SalesTarget = salesTarget;
					sectionTarget.Mode = 1;
					sectionTarget.ShowDialog();

					if (sectionTarget.DialogResult == DialogResult.OK)
					{
						return (true);
					}
					else
					{
						return (false);
					}
				}
			}

			return (false);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �]�ƈ��ڕW�ҏW��ʕ\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �]�ƈ��ڕW�̕ҏW��ʂ�\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool EditEmployeeTarget()
		{
			if (this.Employee_uGrid.ActiveRow == null)
			{
				return (false);
			}

			this._employeeCode = (string)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_EMPLOYEECODE].Value;
			foreach (SalesTarget salesTarget in this._employeeSalesTargetList)
			{
				//----- ueno upd---------- start 2007.11.21
				// �I���O���b�h����
				//   �ڕW�Δ�敪, �]�ƈ��敪�R�[�h, ����R�[�h, �ۃR�[�h, �]�ƈ��R�[�h����v�����ꍇ
				if ((salesTarget.TargetContrastCd	== (int)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value)
					&&(salesTarget.EmployeeDivCd	== (int)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_EMPLOYEEDIVCD].Value)
					&&(salesTarget.SubSectionCode	== (int)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_SUBSECTIONCODE].Value)
					//&&(salesTarget.MinSectionCode	== (int)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_MINSECTIONCODE].Value)
					&& (salesTarget.EmployeeCode.TrimEnd()	== this._employeeCode.TrimEnd()))
				//----- ueno upd---------- end   2007.11.21
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                    salesTarget.SectionCode = this._sectionCode;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

					MAMOK09110UA employeeTarget = new MAMOK09110UA();
					employeeTarget.SalesTarget = salesTarget;
					employeeTarget.Mode = 1;
					employeeTarget.ShowDialog();

					if (employeeTarget.DialogResult == DialogResult.OK)
					{
						return (true);
					}
					else
					{
						return (false);
					}
				}
			}

			return (false);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���i�ڕW�ҏW��ʕ\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���i�ڕW�̕ҏW��ʂ�\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool EditGoodsTarget()
		{
			if (this.Goods_uGrid.ActiveRow == null)
			{
				return (false);
			}

			this._goodsCode = (string)this.Goods_uGrid.ActiveRow.Cells[COL_SALESTARGET_GOODSCODE].Value;
			foreach (SalesTarget salesTarget in this._goodsSalesTargetList)
			{
				//----- ueno upd---------- start 2007.11.21
				string wkGoodsCode = (string)this.Goods_uGrid.ActiveRow.Cells[COL_SALESTARGET_GOODSCODE].Value;
				
				// �I���O���b�h����
				//   �ڕW�Δ�敪, ���[�J�[�R�[�h, ���i�R�[�h����v�����ꍇ
				if ((salesTarget.TargetContrastCd	== (int)this.Goods_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value)
					&&(salesTarget.MakerCode		== (int)this.Goods_uGrid.ActiveRow.Cells[COL_SALESTARGET_MAKERCODE].Value)
					&& (salesTarget.GoodsCode.TrimEnd() == wkGoodsCode.TrimEnd()))

				//----- ueno upd---------- end   2007.11.21
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                    salesTarget.SectionCode = this._sectionCode;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

					MAMOK09130UA goodsTarget = new MAMOK09130UA();
					goodsTarget.SalesTarget = salesTarget;
					goodsTarget.Mode = 1;
					goodsTarget.ShowDialog();

					if (goodsTarget.DialogResult == DialogResult.OK)
					{
						return (true);
					}
					else
					{
						return (false);
					}
				}
			}

			return (false);
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// ����`���ڕW�ҏW��ʕ\������
		///// </summary>
		///// <remarks>
		///// <br>Note		: ����`���ڕW�̕ҏW��ʂ�\�����܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool EditSalesFormalTarget()
		//{
		//    if (this.SalesFormal_uGrid.ActiveRow == null)
		//    {
		//        return (false);
		//    }

		//    this._salesFormalCode = (int)this.SalesFormal_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMALCODE].Value;
		//    foreach (SalesTarget salesTarget in this._salesFormalSalesTargetList)
		//    {
		//        if (salesTarget.SalesFormal == this._salesFormalCode)
		//        {
		//            MAMOK09150UA salesFormalTarget = new MAMOK09150UA();
		//            salesFormalTarget.SalesTarget = salesTarget;
		//            salesFormalTarget.Mode = 1;
		//            salesFormalTarget.ShowDialog();

		//            if (salesFormalTarget.DialogResult == DialogResult.OK)
		//            {
		//                return (true);
		//            }
		//            else
		//            {
		//                return (false);
		//            }
		//        }
		//    }

		//    return (false);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �̔��`�ԖڕW�ҏW��ʕ\������
		///// </summary>
		///// <remarks>
		///// <br>Note		: �̔��`�ԖڕW�̕ҏW��ʂ�\�����܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool EditSalesFormTarget()
		//{
		//    if (this.SalesForm_uGrid.ActiveRow == null)
		//    {
		//        return (false);
		//    }

		//    this._salesFormCode = (int)this.SalesForm_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMCODE].Value;
		//    foreach (SalesTarget salesTarget in this._salesFormSalesTargetList)
		//    {
		//        if (salesTarget.SalesFormCode == this._salesFormCode)
		//        {
		//            MAMOK09170UA salesFormTarget = new MAMOK09170UA();
		//            salesFormTarget.SalesTarget = salesTarget;
		//            salesFormTarget.Mode = 1;
		//            salesFormTarget.ShowDialog();

		//            if (salesFormTarget.DialogResult == DialogResult.OK)
		//            {
		//                return (true);
		//            }
		//            else
		//            {
		//                return (false);
		//            }
		//        }
		//    }

		//    return (false);
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���Ӑ�ڕW�ҏW��ʕ\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���Ӑ�ڕW�̕ҏW��ʂ�\�����܂��B</br>
		/// <br>Programmer	: 30167	���@�O�M</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private bool EditCustomerTarget()
		{
			if (this.Customer_uGrid.ActiveRow == null)
			{
				return (false);
			}
			
			this._customerCode = (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_CUSTOMERCODE].Value;
			
			foreach (SalesTarget salesTarget in this._customerTargetList)
			{
				// �I���O���b�h����
				//   �ڕW�Δ�敪, �Ǝ�R�[�h, �̔��G���A�R�[�h, ���Ӑ�R�[�h����v�����ꍇ
				if ((salesTarget.TargetContrastCd	== (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value)
					&&(salesTarget.BusinessTypeCode == (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_BUSINESSTYPECODE].Value)
					&&(salesTarget.SalesAreaCode	== (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESAREACODE].Value)
					&& (salesTarget.CustomerCode	== this._customerCode))
				{
					DCKHN09190UA customerTarget = new DCKHN09190UA();

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                    int BUSINESS_TYPE_GUIDE = 33;   // �Ǝ�R�[�h
                    int SALES_AREA_GUIDE = 21;      // �̔��G���A

                    // �Ǝ햼���擾
                    UserGdBd userGuideBdInfo;
                    int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, BUSINESS_TYPE_GUIDE, salesTarget.BusinessTypeCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesTarget.BusinessTypeName = userGuideBdInfo.GuideName;
                    }

                    // �̔��G���A�����擾
                    status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, SALES_AREA_GUIDE, salesTarget.SalesAreaCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesTarget.SalesAreaName = userGuideBdInfo.GuideName;
                    }

                    salesTarget.SectionCode = this._sectionCode;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END
					customerTarget.SalesTarget = salesTarget;
					customerTarget.Mode = 1;
					customerTarget.ShowDialog();

					if (customerTarget.DialogResult == DialogResult.OK)
					{
						return (true);
					}
					else
					{
						return (false);
					}
				}
			}

			return (false);
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�폜����
		/// </summary>
        /// <param name="salesTargetList">�ڕW�f�[�^���X�g</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^���폜���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private bool DeleteSalesTarget(List<SalesTarget> salesTargetList)
		{
			// �ڕW�f�[�^�X�V
			int status = this._salesTargetAcs.Delete(salesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        "���ɑ��[�����X�V����Ă��܂�",           // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					    // �\������{�^��
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        "���ɑ��[�����폜����Ă��܂�",		    // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					    // �\������{�^��
                    return (false);
                default:
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,			    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        ctPGNM, 		  �@�@					    // �v���O��������
                        "DeleteSalesTarget",						            // ��������
                        TMsgDisp.OPE_DELETE,					    // �I�y���[�V����
                        "�ڕW�f�[�^�폜���ɃG���[���������܂���",	// �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        this._salesTargetAcs,					    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,			  		    // �\������{�^��
                        MessageBoxDefaultButton.Button1);		    // �����\���{�^��
                    return (false);
            }

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڍזڕW�폜�O����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I�����ꂽ�ڍזڕW�f�[�^���폜���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private bool BeforeDeleteSalesTarget()
		{
			bool bStatus;
            switch (this.CustomerTarget_uTabControl.SelectedTab.Index)
			{
				case 0:
					// ���_�ڕW
					bStatus = DeleteSectionTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 1:
					// �]�ƈ��ڕW
					bStatus = DeleteEmployeeTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 2:
					// ���i�ڕW
					bStatus = DeleteGoodsTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
//----- ueno add---------- start 2007.11.21
				case 3:
					// ���Ӑ�ڕW
					bStatus = DeleteCustomerTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
//----- ueno add---------- end   2007.11.21
				//----- ueno del---------- start 2007.11.21
				//case 3:
				//    // ����`���ڕW
				//    bStatus = DeleteSalesFormalTarget();
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				//case 4:
				//    // �̔��`�ԖڕW
				//    bStatus = DeleteSalesFormTarget();
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				//----- ueno del---------- end   2007.11.21
			}
			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���_�ڕW�폜����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I���������_�ڕW���폜���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool DeleteSectionTarget()
		{
			if (this.Section_uGrid.ActiveRow == null)
			{
				return (false);
			}

			string msg;

			// ���ԖڕW
			if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				msg = this.ApplyStaDate_tDateEdit.GetDateYear().ToString() + "�N" +
					this.ApplyStaDate_tDateEdit.GetDateMonth().ToString() + "��" +
					"�̋��_�ڕW���폜���܂����A��낵���ł����H";
			}
			// �ʊ��ԖڕW
			else
			{
				msg = this.TargetDivideName_tEdit.DataText.TrimEnd() + "[" + this.TargetDivideCode_tEdit.DataText.TrimEnd() + "]" +
					"�̋��_�ڕW���폜���܂����A��낵���ł����H";
			}

			// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
			DialogResult res = TMsgDisp.Show(this,									// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_INFO, 										// �G���[���x��
				this.Name, 															// �A�Z���u���h�c
				msg,																// �\�����郁�b�Z�[�W
				0, 																	// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel);										// �\������{�^��

			switch (res)
			{
				case DialogResult.OK:
					{
						List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
						SalesTarget deleteSalesTarget = null;

						string sectionCode = (string)this.Section_uGrid.ActiveRow.Cells[COL_SALESTARGET_SECTIONCODE].Value;

						foreach (SalesTarget salesTarget in this._sectionSalesTargetList)
						{
							if (salesTarget.SectionCode == sectionCode)
							{
								deleteSalesTargetList.Add(salesTarget);
								deleteSalesTarget = salesTarget;
								break;
							}
						}

						// ���_�ڕW�폜
						bool bStatus = DeleteSalesTarget(deleteSalesTargetList);
						if (!bStatus)
						{
							return (false);
						}

						this._sectionSalesTargetList.Remove(deleteSalesTarget);
						break;
					}

				case DialogResult.Cancel:
					{
						this.DeleteSection_Button.Focus();
						return (false);
					}
			}

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �]�ƈ��ڕW�폜����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I�������]�ƈ��ڕW���폜���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool DeleteEmployeeTarget()
		{
			if (this.Employee_uGrid.ActiveRow == null)
			{
				return (false);
			}

			// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
			DialogResult res = TMsgDisp.Show(this,																	 // �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_INFO, 																		 // �G���[���x��
				this.Name, 																							 // �A�Z���u���h�c
				//----- ueno upd---------- start 2007.11.21
				"�I�����ꂽ�ڕW���폜���܂��B��낵���ł����H",
				//this._employeeName + "����" + "[" + this._employeeCode.TrimEnd() + "]" + " �̖ڕW���폜���܂����A��낵���ł����H", // �\�����郁�b�Z�[�W										  // �\�����郁�b�Z�[�W
				//----- ueno upd---------- end   2007.11.21
				0, 																									 // �X�e�[�^�X�l
				MessageBoxButtons.OKCancel);																		 // �\������{�^��

			switch (res)
			{
				case DialogResult.OK:
					{
						List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
						SalesTarget deleteSalesTarget = null;

						//----- ueno upd---------- start 2007.11.21
						//----- �L�[���ڑS�Ă���v������Y���f�[�^�Ƃ���
						foreach (SalesTarget salesTarget in this._employeeSalesTargetList)
						{
							if (( salesTarget.TargetContrastCd == this._empTargetConstrastCd)
								&& (salesTarget.EmployeeCode == this._employeeCode)
								&& (salesTarget.EmployeeDivCd == this._employeeDivCd)
								&& (salesTarget.SubSectionCode == this._subSectionCode)
								&& (salesTarget.MinSectionCode == this._minSectionCode))
							{
								deleteSalesTargetList.Add(salesTarget);
								deleteSalesTarget = salesTarget;
								break;
							}
						}
						//----- ueno upd---------- start 2007.11.21

						// �]�ƈ��ڕW�폜
						bool bStatus = DeleteSalesTarget(deleteSalesTargetList);
						if (!bStatus)
						{
							return (false);
						}

						this._employeeSalesTargetList.Remove(deleteSalesTarget);
						break;
					}

				case DialogResult.Cancel:
					{
						this.DeleteEmployee_Button.Focus();
						return (false);
					}
			}

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���i�ڕW�폜����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I���������i�ڕW���폜���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool DeleteGoodsTarget()
		{
			if (this.Goods_uGrid.ActiveRow == null)
			{
				return (false);
			}

			// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
			DialogResult res = TMsgDisp.Show(this,															   // �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_INFO, 																   // �G���[���x��
				this.Name, 																					   // �A�Z���u���h�c
				//----- ueno upd---------- start 2007.11.21
				"�I�����ꂽ�ڕW���폜���܂��B��낵���ł����H",
				//this._goodsName + "[" + this._goodsCode.TrimEnd() + "]" + " �̖ڕW���폜���܂����A��낵���ł����H", // �\�����郁�b�Z�[�W										  // �\�����郁�b�Z�[�W
				//----- ueno upd---------- end   2007.11.21
				0, 																							   // �X�e�[�^�X�l
				MessageBoxButtons.OKCancel);																   // �\������{�^��

			switch (res)
			{
				case DialogResult.OK:
					{
                        List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
						SalesTarget deleteSalesTarget = null;

						//----- ueno upd---------- start 2007.11.21
						//----- �L�[���ڑS�Ă���v������Y���f�[�^�Ƃ���
						foreach (SalesTarget salesTarget in this._goodsSalesTargetList)
						{
							if ((salesTarget.TargetContrastCd		== this._goodsTargetConstrastCd)
								&& (salesTarget.MakerCode			== this._makerCode)
								&& (salesTarget.GoodsCode.TrimEnd() == this._goodsCode.TrimEnd()))
							{
                                deleteSalesTargetList.Add(salesTarget);
								deleteSalesTarget = salesTarget;
								break;
							}
						}
						//----- ueno upd---------- end   2007.11.21

						// ���i�ڕW�폜
                        bool bStatus = DeleteSalesTarget(deleteSalesTargetList);
						if (!bStatus)
						{
							return (false);
						}

                        this._goodsSalesTargetList.Remove(deleteSalesTarget);
						break;
					}

				case DialogResult.Cancel:
					{
						this.DeleteGoods_Button.Focus();
						return (false);
					}
			}

			return (true);
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// ����`���ڕW�폜����
		///// </summary>
		///// <remarks>
		///// <br>Note		: �I����������`���ڕW���폜���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool DeleteSalesFormalTarget()
		//{
		//    if (this.SalesFormal_uGrid.ActiveRow == null)
		//    {
		//        return (false);
		//    }

		//    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
		//    DialogResult res = TMsgDisp.Show(this,								  // �e�E�B���h�E�t�H�[��
		//        emErrorLevel.ERR_LEVEL_INFO, 									  // �G���[���x��
		//        this.Name, 														  // �A�Z���u���h�c
		//        "����`��[" + this._salesFormalName + "]�̖ڕW���폜���܂����A��낵���ł����H", // �\�����郁�b�Z�[�W										  // �\�����郁�b�Z�[�W
		//        0, 																  // �X�e�[�^�X�l
		//        MessageBoxButtons.OKCancel);									  // �\������{�^��

		//    switch (res)
		//    {
		//        case DialogResult.OK:
		//            {
		//                List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
		//                SalesTarget deleteSalesTarget = null;

		//                int salesFormal = (int)this.SalesFormal_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMALCODE].Value;

		//                foreach (SalesTarget salesTarget in this._salesFormalSalesTargetList)
		//                {
		//                    if (salesTarget.SalesFormal == salesFormal)
		//                    {
		//                        deleteSalesTargetList.Add(salesTarget);
		//                        deleteSalesTarget = salesTarget;
		//                        break;
		//                    }
		//                }

		//                // ����`���ڕW�폜
		//                bool bStatus = DeleteSalesTarget(deleteSalesTargetList);
		//                if (!bStatus)
		//                {
		//                    return (false);
		//                }

		//                this._salesFormalSalesTargetList.Remove(deleteSalesTarget);
		//                break;
		//            }

		//        case DialogResult.Cancel:
		//            {
		//                this.DeleteSalesFormal_Button.Focus();
		//                return (false);
		//            }
		//    }

		//    return (true);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �̔��`�ԖڕW�폜����
		///// </summary>
		///// <remarks>
		///// <br>Note		: �I�������̔��`�ԖڕW���폜���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool DeleteSalesFormTarget()
		//{
		//    if (this.SalesForm_uGrid.ActiveRow == null)
		//    {
		//        return (false);
		//    }

		//    // �ۑ��m�F���b�Z�[�W��\��
		//    DialogResult res = TMsgDisp.Show(this,								// �e�E�B���h�E�t�H�[��
		//        emErrorLevel.ERR_LEVEL_INFO, 									// �G���[���x��
		//        this.Name, 														// �A�Z���u���h�c
		//        "�̔��`��[" + this._salesFormName + "]�̖ڕW���폜���܂����A��낵���ł����H", // �\�����郁�b�Z�[�W
		//        0, 																// �X�e�[�^�X�l
		//        MessageBoxButtons.OKCancel);									// �\������{�^��

		//    switch (res)
		//    {
		//        case DialogResult.OK:
		//            {
		//                List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
		//                SalesTarget deleteSalesTarget = null;

		//                int salesFormCode = (int)this.SalesForm_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMCODE].Value;

		//                foreach (SalesTarget salesTarget in this._salesFormSalesTargetList)
		//                {
		//                    if (salesTarget.SalesFormCode == salesFormCode)
		//                    {
		//                        deleteSalesTargetList.Add(salesTarget);
		//                        deleteSalesTarget = salesTarget;
		//                        break;
		//                    }
		//                }

		//                // �̔��`�ԖڕW�폜
		//                bool bStatus = DeleteSalesTarget(deleteSalesTargetList);
		//                if (!bStatus)
		//                {
		//                    return (false);
		//                }

		//                this._salesFormSalesTargetList.Remove(deleteSalesTarget);
		//                break;
		//            }

		//        case DialogResult.Cancel:
		//            {
		//                this.DeleteSalesForm_Button.Focus();
		//                return (false);
		//            }
		//    }

		//    return (true);
		//}
		#endregion del
		//----- ueno del---------- start 2007.11.21

//----- ueno add---------- start 2007.11.21
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���Ӑ�ڕW�폜����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I�������]�ƈ��ڕW���폜���܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private bool DeleteCustomerTarget()
		{
			if (this.Customer_uGrid.ActiveRow == null)
			{
				return (false);
			}

			// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
			DialogResult res = TMsgDisp.Show(this,																	 // �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_INFO, 																		 // �G���[���x��
				this.Name, 																							 // �A�Z���u���h�c
				"�I�����ꂽ�ڕW���폜���܂��B��낵���ł����H",
				//this._customerName + "����" + "[" + this._customerCode + "]" + " �̖ڕW���폜���܂����A��낵���ł����H", // �\�����郁�b�Z�[�W										  // �\�����郁�b�Z�[�W
				0, 																									 // �X�e�[�^�X�l
				MessageBoxButtons.OKCancel);																		 // �\������{�^��

			switch (res)
			{
				case DialogResult.OK:
					{
						List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
						SalesTarget deleteSalesTarget = null;

						//----- �L�[���ڑS�Ă���v������Y���f�[�^�Ƃ���
						foreach (SalesTarget salesTarget in this._customerTargetList)
						{
							if ((salesTarget.TargetContrastCd		== this._custTargetConstrastCd)
								&& (salesTarget.BusinessTypeCode	== this._businessTypeCode)
								&& (salesTarget.SalesAreaCode		== this._salesAreaCode)
								&& (salesTarget.CustomerCode		== this._customerCode))
							{
								deleteSalesTargetList.Add(salesTarget);
								deleteSalesTarget = salesTarget;
								break;
							}
						}

						// ���Ӑ�ڕW�폜
						bool bStatus = DeleteSalesTarget(deleteSalesTargetList);
						if (!bStatus)
						{
							return (false);
						}

						this._customerTargetList.Remove(deleteSalesTarget);
						break;
					}

				case DialogResult.Cancel:
					{
						this.DeleteCustomer_Button.Focus();
						return (false);
					}
			}

			return (true);
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW��������
		/// </summary>
        /// <param name="targetDivideCode">�ڕW�敪�R�[�h</param>
        /// <param name="salesTargetList">�ڕW�f�[�^���X�g</param>
		/// <remarks>
		/// <br>Note		: �ڕW���������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.19</br>
		/// </remarks>
		private bool SearchTarget(string targetDivideCode, out List<SalesTarget> salesTargetList)
		{
			SalesTargetAcs salesTargetAcs = new SalesTargetAcs();
			salesTargetList = new List<SalesTarget>();
			ExtrInfo_MAMOK09197EA extrInfo = new ExtrInfo_MAMOK09197EA();

			// ��ƃR�[�h
			extrInfo.EnterpriseCode = this._enterpriseCode;
			// ���_�R�[�h
			extrInfo.SelectSectCd = new string[1];
			extrInfo.SelectSectCd[0] = this._sectionCode;
			// �ڕW�ݒ�敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//extrInfo.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
            extrInfo.TargetSetCd = int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			// �K�p�J�n���i�J�n�j
			extrInfo.ApplyStaDateSt = new DateTime();
			// �K�p�J�n���i�I���j
			extrInfo.ApplyStaDateEd = new DateTime();
			// �K�p�I�����i�J�n�j
			extrInfo.ApplyEndDateSt = new DateTime();
			// �K�p�I�����i�I���j
			extrInfo.ApplyEndDateEd = new DateTime();
			// �ڕW�敪�R�[�h
			extrInfo.TargetDivideCode = targetDivideCode;

			// �ڕW�Δ�敪(���_)
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			if (salesTargetList.Count > 0)
			{
				return (true);
			}

			// �ڕW�Δ�敪(�]�ƈ�)
			//----- ueno upd---------- start 2007.11.21
			// �C�ӂ̏]�ƈ��ڕW�Δ�敪��ݒ�
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
			//----- ueno upd---------- end   2007.11.21

			salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			if (salesTargetList.Count > 0)
			{
				return (true);
			}

			// �ڕW�Δ�敪(���i)
			//----- ueno upd---------- start 2007.11.21
			// �C�ӂ̏��i�ڕW�Δ�敪��ݒ�
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods;
			//----- ueno upd---------- end   2007.11.21

			salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			if (salesTargetList.Count > 0)
			{
				return (true);
			}

//----- ueno add---------- start 2007.11.21

			// �ڕW�Δ�敪(���Ӑ�)
			// �C�ӂ̓��Ӑ�ڕW�Δ�敪��ݒ�
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;

			salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			if (salesTargetList.Count > 0)
			{
				return (true);
			}
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			#region del
			//// �ڕW�Δ�敪(����`��)
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
			//salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			//if (salesTargetList.Count > 0)
			//{
			//    return (true);
			//}

			//// �ڕW�Δ�敪(�̔��`��)
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;
			//salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			//if (salesTargetList.Count > 0)
			//{
			//    return (true);
			//}
			#endregion del
			//----- ueno del---------- end   2007.11.21


			TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�ڕW�敪�R�[�h [" + targetDivideCode + "] �ɊY������f�[�^�����݂��܂���",
					-1,
					MessageBoxButtons.OK);
			return (false);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڍזڕW��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ڍזڕW���������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.20</br>
		/// </remarks>
		private bool SearchAllSalesTarget()
		{
			// ���������`�F�b�N����
			bool status = CheckSearchCondition();
			if (!status)
			{
				return (false);
			}

			// �ʊ��ԖڕW�̏ꍇ�͖ڕW�敪�R�[�h�`�F�b�N
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 20)
            //if ((int)this.TargetSetCd_uOptionSet.Value == 20)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			{
				List<SalesTarget> salesTargetList;
				string targetDivideCode = this.TargetDivideCode_tEdit.DataText;

				status = SearchTarget(targetDivideCode, out salesTargetList);
				if (!status)
				{
					this.TargetDivideCode_tEdit.Focus();
					return (false);
				}

				this.ApplyStaDate_tDateEdit.SetDateTime(salesTargetList[0].ApplyStaDate);
				this.ApplyEndDate_tDateEdit.SetDateTime(salesTargetList[0].ApplyEndDate);
				this.TargetDivideName_tEdit.DataText = salesTargetList[0].TargetDivideName;
			}

			// ���_�ڕW�f�[�^����
			status = SearchSectionTarget();
			if (!status)
			{
				return (false);
			}

			// �]�ƈ��ڕW�f�[�^����
			status = SearchEmployeeTarget();
			if (!status)
			{
				return (false);
			}

			// ���i�ڕW�f�[�^����
			status = SearchGoodsTarget();
			if (!status)
			{
				return (false);
			}

//----- ueno add---------- start 2007.11.21
			// ���Ӑ�ڕW�f�[�^����
			status = SearchCustomerTarget();
			if (!status)
			{
				return (false);
			}
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			#region del
			//// ����`���ڕW�f�[�^����
			//status = SearchSalesFormalTarget();
			//if (!status)
			//{
			//    return (false);
			//}

			//// �̔��`�ԖڕW�f�[�^����
			//status = SearchSalesFormTarget();
			//if (!status)
			//{
			//    return (false);
			//}
			#endregion del
			//----- ueno del---------- end   2007.11.21

            // �����t���O
            this._searchFlag = true;


			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^����ʂɕ\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.20</br>
		/// </remarks>
		private void DispScreen()
		{
			// ��ʕ\��
			DispScreenSection_uGrid();
			DispScreenEmployee_uGrid();
			DispScreenGoods_uGrid();
//----- ueno add---------- start 2007.11.21
			DispScreenCustomer_uGrid();
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//DispScreenSalesFormal_uGrid();
			//DispScreenSalesForm_uGrid();
			//----- ueno del---------- end   2007.11.21

			// �O���b�h�X�^�C���ݒ�
			InitializeLayout_Section_uGrid();
			InitializeLayout_Employee_uGrid();
			InitializeLayout_Goods_uGrid();
//----- ueno add---------- start 2007.11.21
			InitializeLayout_Customer_uGrid();
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//InitializeLayout_SalesFormal_uGrid();
			//InitializeLayout_SalesForm_uGrid();
			//----- ueno del---------- end   2007.11.21

			if (this._searchFlag == true)
			{
				//----- ueno del---------- start 2007.11.21
				//// �䗦�v�Z
				//CalcFromRatioSalesDay(this.Section_uGrid);
				//CalcFromRatioSalesDay(this.Employee_uGrid);
				//CalcFromRatioSalesDay(this.Goods_uGrid);
				//CalcFromRatioSalesDay(this.SalesFormal_uGrid);
				//CalcFromRatioSalesDay(this.SalesForm_uGrid);
				//----- ueno del---------- end   2007.11.21

				// ���v�v�Z
				CalcTotalSalesTarget(this.Section_uGrid);
				CalcTotalSalesTarget(this.Employee_uGrid);
				CalcTotalSalesTarget(this.Goods_uGrid);
//----- ueno add---------- start 2007.11.21
				CalcTotalSalesTarget(this.Customer_uGrid);
//----- ueno add---------- end   2007.11.21
				//----- ueno del---------- start 2007.11.21
				//CalcTotalSalesTarget(this.SalesFormal_uGrid);
				//CalcTotalSalesTarget(this.SalesForm_uGrid);
				//----- ueno del---------- end   2007.11.21
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʏ��N���A����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʏ����N���A���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.13</br>
		/// </remarks>
		private void ClearScreen()
		{
			// �����t���O
			this._searchFlag = false;

			// �R���g���[���T�C�Y�ݒ�
			SetControlSize();

			// �R���g���[�����͌����ݒ�
			SetNumberOfControlChar();

			this.TargetDivideCode_tEdit.DataText = "";
			this.TargetDivideName_tEdit.DataText = "";
			this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());

			// �ڕW�f�[�^������
			this._sectionSalesTargetList = new List<SalesTarget>();
			this._employeeSalesTargetList = new List<SalesTarget>();
			this._goodsSalesTargetList = new List<SalesTarget>();
//----- ueno add---------- start 2007.11.21
			this._customerTargetList = new List<SalesTarget>();
//----- ueno add---------- start 2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this._salesFormalSalesTargetList = new List<SalesTarget>();
			//this._salesFormSalesTargetList = new List<SalesTarget>();
			//----- ueno del---------- end   2007.11.21

			// ��ʕ\��
			DispScreen();

			// �R���g���[������
			SetControlEnabled();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�ڕW�f�[�^��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �S�ڕW�f�[�^���������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
        //private void ShowAllSalesTarget()
        //{
        //    //// �}�X�^�e�[�u���ǂݍ���
        //    //int status = LoadMasterTable();
        //    //if (status != 0)
        //    //{
        //    //    return;
        //    //}

        //    //// �ڍזڕW�f�[�^����
        //    //bool bStatus = SearchAllSalesTarget();
        //    //if (!bStatus)
        //    //{
        //    //    return;
        //    //}

        //    //// ��ʕ\��
        //    //DispScreen();

        //    //// �R���g���[������
        //    //SetControlEnabled();
        //}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ҏW�O�A�N�e�B�u�s�擾����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ҏW�O�̃A�N�e�B�u�s���擾���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void SetBeforeActiveRow()
		{
			// �]�ƈ��ڕW
			if (this.Employee_uGrid.ActiveRow != null)
			{
//----- ueno add---------- start 2007.11.21
				this._empTargetConstrastCd = (int)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value;
				this._employeeDivCd = (int)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_EMPLOYEEDIVCD].Value;
				this._employeeDivNm = (string)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_EMPLOYEEDIVNM].Value;
				this._subSectionCode = (int)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_SUBSECTIONCODE].Value;
				this._subSectionName = (string)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_SUBSECTIONNAME].Value;
				//this._minSectionCode = (int)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_MINSECTIONCODE].Value;
				//this._minSectionName = (string)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_MINSECTIONNAME].Value;
//----- ueno add---------- end   2007.11.21
				this._employeeCode = (string)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_EMPLOYEECODE].Value;
				this._employeeName = (string)this.Employee_uGrid.ActiveRow.Cells[COL_SALESTARGET_NAME].Value;
			}
			// ���i�ڕW
			if (this.Goods_uGrid.ActiveRow != null)
			{
//----- ueno add---------- start 2007.11.21
				this._goodsTargetConstrastCd = (int)this.Goods_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value;
//----- ueno add---------- start 2007.11.21
				this._goodsCode = (string)this.Goods_uGrid.ActiveRow.Cells[COL_SALESTARGET_GOODSCODE].Value;
				this._goodsName = (string)this.Goods_uGrid.ActiveRow.Cells[COL_SALESTARGET_GOODSNAME].Value;
				this._makerCode = (int)this.Goods_uGrid.ActiveRow.Cells[COL_SALESTARGET_MAKERCODE].Value;
			}
//----- ueno add---------- start 2007.11.21
			// ���Ӑ�ڕW
			if (this.Customer_uGrid.ActiveRow != null)
			{
				this._custTargetConstrastCd = (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value;
				this._businessTypeCode = (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_BUSINESSTYPECODE].Value;
				this._businessTypeName = (string)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_BUSINESSTYPENAME].Value;
				this._salesAreaCode = (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESAREACODE].Value;
				this._salesAreaName = (string)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESAREANAME].Value;
				this._customerCode = (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_CUSTOMERCODE].Value;
				this._customerName = (string)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_CUSTOMERNAME].Value;
			}
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//// ����`���ڕW
			//if (this.SalesFormal_uGrid.ActiveRow != null)
			//{
			//    this._salesFormalCode = (int)this.SalesFormal_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMALCODE].Value;
			//    this._salesFormalName = (string)this.SalesFormal_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMAL].Value;
			//}
			//// �̔��`�ԖڕW
			//if (this.SalesForm_uGrid.ActiveRow != null)
			//{
			//    this._salesFormCode = (int)this.SalesForm_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMCODE].Value;
			//    this._salesFormName = (string)this.SalesForm_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORM].Value;
			//}
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ҏW��A�N�e�B�u�s�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ҏW��̃A�N�e�B�u�s��ݒ肵�܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void SetActiveRow()
		{
			// Employee_uGrid (���v�s�̓`�F�b�N���Ȃ�)
			for (int rowIndex = 0; rowIndex <= this.Employee_uGrid.Rows.Count - 2; rowIndex++)
			{
				//----- ueno upd---------- start 2007.11.21
				if (((int)this.Employee_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value == this._empTargetConstrastCd)
					&& ((string)this.Employee_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_EMPLOYEECODE].Value == this._employeeCode)
					&& ((int)this.Employee_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_EMPLOYEEDIVCD].Value == this._employeeDivCd)
					&& ((int)this.Employee_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_SUBSECTIONCODE].Value == this._subSectionCode))
					//&& ((int)this.Employee_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_MINSECTIONCODE].Value == this._minSectionCode))
				//----- ueno upd---------- start 2007.11.21
				{
					this.Employee_uGrid.Rows[rowIndex].Activate();
					break;
				}
			}
			// Goods_uGrid (���v�s�̓`�F�b�N���Ȃ�)
			for (int rowIndex = 0; rowIndex <= this.Goods_uGrid.Rows.Count - 2; rowIndex++)
			{
				//----- ueno upd---------- start 2007.11.21
				if (((int)this.Goods_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value == this._goodsTargetConstrastCd)
					&&(string)this.Goods_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_GOODSCODE].Value == this._goodsCode
					&&(int)this.Goods_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_MAKERCODE].Value == this._makerCode)
				//----- ueno upd---------- end   2007.11.21
				{
					this.Goods_uGrid.Rows[rowIndex].Activate();
					break;
				}
			}

//----- ueno add---------- start 2007.11.21
			// Customer_uGrid (���v�s�̓`�F�b�N���Ȃ�)
			for (int rowIndex = 0; rowIndex <= this.Customer_uGrid.Rows.Count - 2; rowIndex++)
			{
				if (((int)this.Customer_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value == this._custTargetConstrastCd)
					&&((int)this.Customer_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_BUSINESSTYPECODE].Value == this._businessTypeCode)
					&&((int)this.Customer_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_SALESAREACODE].Value == this._salesAreaCode)
					&&((int)this.Customer_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_CUSTOMERCODE].Value == this._customerCode))
				{
					this.Customer_uGrid.Rows[rowIndex].Activate();
					break;
				}
			}
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//// SalesFormal_uGrid (���v�s�̓`�F�b�N���Ȃ�)
			//for (int rowIndex = 0; rowIndex <= this.SalesFormal_uGrid.Rows.Count - 2; rowIndex++)
			//{
			//    if ((int)this.SalesFormal_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_SALESFORMALCODE].Value == this._salesFormalCode)
			//    {
			//        this.SalesFormal_uGrid.Rows[rowIndex].Activate();
			//        break;
			//    }
			//}
			//// SalesForm_uGrid (���v�s�̓`�F�b�N���Ȃ�)
			//for (int rowIndex = 0; rowIndex <= this.SalesForm_uGrid.Rows.Count - 2; rowIndex++)
			//{
			//    if ((int)this.SalesForm_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_SALESFORMCODE].Value == this._salesFormCode)
			//    {
			//        this.SalesForm_uGrid.Rows[rowIndex].Activate();
			//    }
			//}
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[�����䏈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���̐�����s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.20</br>
		/// </remarks>
		private void SetControlEnabled()
		{
			// ���ԖڕW
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			{
				this.NewSection_Button.Visible = false;
				this.EditSection_Button.Visible = false;
				this.DeleteSection_Button.Visible = false;
				this.ReferSection_Button.Visible = true;
			}
			// �ʊ��ԖڕW
			else
			{
				this.NewSection_Button.Visible = true;
				this.EditSection_Button.Visible = true;
				this.DeleteSection_Button.Visible = true;
				this.ReferSection_Button.Visible = false;
			}

			// �����O
			if (this._searchFlag == false)
			{
				this.TargetDivideCode_tEdit.Enabled = true;
				this.TargetGuide_Button.Enabled = true;
				this.Search_Button.Enabled = true;
				this.Edit_Button.Enabled = false;
				this.ReferSection_Button.Enabled = false;
				this.NewSection_Button.Enabled = true;
				this.EditSection_Button.Enabled = false;
				this.DeleteSection_Button.Enabled = false;
				this.NewEmployee_Button.Enabled = true;
				this.EditEmployee_Button.Enabled = false;
				this.DeleteEmployee_Button.Enabled = false;
				this.NewGoods_Button.Enabled = true;
				this.EditGoods_Button.Enabled = false;
				this.DeleteGoods_Button.Enabled = false;
//----- ueno add---------- start 2007.11.21
				this.NewCustomer_Button.Enabled = true;
				this.EditCustomer_Button.Enabled = false;
				this.DeleteCustomer_Button.Enabled = false;
//----- ueno add---------- end   2007.11.21
				//----- ueno del---------- start 2007.11.21
				//this.NewSalesFormal_Button.Enabled = true;
				//this.EditSalesFormal_Button.Enabled = false;
				//this.DeleteSalesFormal_Button.Enabled = false;
				//this.NewSalesForm_Button.Enabled = true;
				//this.EditSalesForm_Button.Enabled = false;
				//this.DeleteSalesForm_Button.Enabled = false;
				//----- ueno del---------- end   2007.11.21

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                //this.TargetSetCd_uOptionSet.Enabled = true;
                this.TargetSetCd_tComboEditor.Enabled = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			}
			// ������
			else
			{
				this.TargetDivideCode_tEdit.Enabled = false;
				this.TargetGuide_Button.Enabled = false;
				this.ReferSection_Button.Enabled = true;
				this.NewSection_Button.Enabled = true;
				this.EditSection_Button.Enabled = true;
				this.DeleteSection_Button.Enabled = true;
				this.NewEmployee_Button.Enabled = true;
				this.NewGoods_Button.Enabled = true;
//----- ueno add---------- start 2007.11.21
				this.NewCustomer_Button.Enabled = true;
//----- ueno add---------- end   2007.11.21
				//----- ueno del---------- start 2007.11.21
				//this.NewSalesFormal_Button.Enabled = true;
				//this.NewSalesForm_Button.Enabled = true;
				//----- ueno del---------- end   2007.11.21			
				this.Search_Button.Enabled = false;
				this.EditEmployee_Button.Enabled = true;
				this.DeleteEmployee_Button.Enabled = true;
				this.EditGoods_Button.Enabled = true;
				this.DeleteGoods_Button.Enabled = true;
//----- ueno add---------- start 2007.11.21
				this.EditCustomer_Button.Enabled = true;
				this.DeleteCustomer_Button.Enabled = true;
//----- ueno add---------- end   2007.11.21
				//----- ueno del---------- start 2007.11.21
				//this.EditSalesFormal_Button.Enabled = true;
				//this.DeleteSalesFormal_Button.Enabled = true;
				//this.EditSalesForm_Button.Enabled = true;
				//this.DeleteSalesForm_Button.Enabled = true;
				//----- ueno del---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
				//this.TargetSetCd_uOptionSet.Enabled = false;
                this.TargetSetCd_tComboEditor.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
				this.ApplyStaDate_tDateEdit.Enabled = false;
				this.ApplyEndDate_tDateEdit.Enabled = false;

				// ���ԖڕW
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
				//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
				{
					this.Edit_Button.Enabled = false;
				}
				// �ʊ��ԖڕW
				else
				{
					this.Edit_Button.Enabled = true;
				}
			}

			// ���_�ڕW
			if (this._sectionSalesTargetList != null && this._sectionSalesTargetList.Count > 0)
			{
				this.ReferSection_Button.Enabled = true;
				this.NewSection_Button.Enabled = false;
				this.EditSection_Button.Enabled = true;
				this.DeleteSection_Button.Enabled = true;
			}
			else
			{
				this.ReferSection_Button.Enabled = false;
				this.NewSection_Button.Enabled = true;
				this.EditSection_Button.Enabled = false;
				this.DeleteSection_Button.Enabled = false;
			}
			// �]�ƈ��ڕW
			if (this._employeeSalesTargetList != null && this._employeeSalesTargetList.Count > 0)
			{
				this.EditEmployee_Button.Enabled = true;
				this.DeleteEmployee_Button.Enabled = true;
			}
			else
			{
				this.EditEmployee_Button.Enabled = false;
				this.DeleteEmployee_Button.Enabled = false;
			}
			// ���i�ڕW
			if (this._goodsSalesTargetList != null && this._goodsSalesTargetList.Count > 0)
			{
				this.EditGoods_Button.Enabled = true;
				this.DeleteGoods_Button.Enabled = true;
			}
			else
			{
				this.EditGoods_Button.Enabled = false;
				this.DeleteGoods_Button.Enabled = false;
			}
//----- ueno add---------- start 2007.11.21
			// ���Ӑ�ڕW
			if (this._customerTargetList != null && this._customerTargetList.Count > 0)
			{
				this.EditCustomer_Button.Enabled = true;
				this.DeleteCustomer_Button.Enabled = true;
			}
			else
			{
				this.EditCustomer_Button.Enabled = false;
				this.DeleteCustomer_Button.Enabled = false;
			}
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//// ����`���ڕW
			//if (this._salesFormalSalesTargetList != null && this._salesFormalSalesTargetList.Count > 0)
			//{
			//    this.EditSalesFormal_Button.Enabled = true;
			//    this.DeleteSalesFormal_Button.Enabled = true;
			//}
			//else
			//{
			//    this.EditSalesFormal_Button.Enabled = false;
			//    this.DeleteSalesFormal_Button.Enabled = false;
			//}
			//// �̔��`�ԖڕW
			//if (this._salesFormSalesTargetList != null && this._salesFormSalesTargetList.Count > 0)
			//{
			//    this.EditSalesForm_Button.Enabled = true;
			//    this.DeleteSalesForm_Button.Enabled = true;
			//}
			//else
			//{
			//    this.EditSalesForm_Button.Enabled = false;
			//    this.DeleteSalesForm_Button.Enabled = false;
			//}
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[���T�C�Y�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���T�C�Y�̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void SetControlSize()
		{
			this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			this.TargetDivideName_tEdit.Size = new Size(290, 24);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[�����͌����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���̓��͌����̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void SetNumberOfControlChar()
		{
			this.TargetDivideCode_tEdit.MaxLength = 9;
			this.TargetDivideName_tEdit.MaxLength = 30;
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �O���b�h�t�H���g�T�C�Y�ύX����
        /// </summary>
        /// <param name="fontSize">�t�H���g�T�C�Y</param>
        /// <param name="cmbFontSize">�ύX�Ώۃt�H���g�T�C�Y���X�g</param>
        /// <param name="uGrid">�ΏۃO���b�h</param>
        /// <remarks>
        /// <br>Note		: �O���b�h�̃t�H���g�T�C�Y��ύX���܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.20</br>
        /// </remarks>
        private void ChangeFontSize(int fontSize, ref TComboEditor cmbFontSize, ref UltraGrid uGrid)
        {
            uGrid.DisplayLayout.Appearance.FontData.SizeInPoints = fontSize;

            if ((int)cmbFontSize.Value != fontSize)
            {
                cmbFontSize.Value = fontSize;
            }

            int rowHeight;

            switch (fontSize)
            {
                case 6:
                    rowHeight = 15;
                    break;
                case 8:
                    rowHeight = 18;
                    break;
                case 9:
                    rowHeight = 20;
                    break;
                case 10:
                    rowHeight = 21;
                    break;
                case 11:
                    rowHeight = 23;
                    break;
                case 12:
                    rowHeight = 24;
                    break;
                case 14:
                    rowHeight = 27;
                    break;
                default:
                    rowHeight = 23;
                    break;
            }

            for (int rowIndex = 0; rowIndex < uGrid.Rows.Count; rowIndex++)
            {
                uGrid.Rows[rowIndex].Height = rowHeight;
            }

            // �w�b�_�[�̍�������������
            uGrid.DisplayLayout.Bands[0].UseRowLayout = false;
            uGrid.DisplayLayout.Bands[0].UseRowLayout = true;
        }

//----- ueno add---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���喼�̎擾����
		/// </summary>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <return>���喼��</return>
		/// <remarks>
		/// Note	   : ���喼�̂��擾���܂��B<br />
		/// Programmer : 30167 ���@�O�M<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetSubSectionName(int subSectionCode)
		{
			SubSection subSection = null;
			string subSectionName = "";

			SubSectionAcs subSectionAcs = new SubSectionAcs();

			// �f�[�^���݃`�F�b�N
			int ret = subSectionAcs.Read(out subSection, this._enterpriseCode, this._sectionCode, subSectionCode);
			if (ret == 0)
			{
				subSectionName = subSection.SubSectionName;
			}
			return subSectionName;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ۖ��̎擾����
		/// </summary>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <param name="minSectionCode">�ۃR�[�h</param>
		/// <return>�ۖ���</return>
		/// <remarks>
		/// Note	   : �ۖ��̂��擾���܂��B<br />
		/// Programmer : 30167 ���@�O�M<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetMinSectionName(int subSectionCode, int minSectionCode)
		{
			MinSection minSection = null;
			string minSectionName = "";

			MinSectionAcs minSectionAcs = new MinSectionAcs();

			// �f�[�^���݃`�F�b�N
			int ret = minSectionAcs.Read(out minSection, this._enterpriseCode, this._sectionCode, subSectionCode, minSectionCode);
			if (ret == 0)
			{
				minSectionName = minSection.MinSectionName;
			}
			return minSectionName;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���Ӑ於�̎擾����
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <return>���Ӑ於��</return>
		/// <remarks>
		/// Note	   : ���Ӑ於�̂��擾���܂��B<br />
		/// Programmer : 30167 ���@�O�M<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetCustomerName(int customerCode)
		{
			CustomerInfo customerInfo = null;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
			string customerName = "";

			// �f�[�^���݃`�F�b�N
			int ret = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
							customerCode, out customerInfo);
			if (ret == 0)
			{
				customerName = customerInfo.Name;
			}
			return customerName;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�}�X�^�{�f�B�����X�g�擾����
		/// </summary>
		/// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�}�X�^�{�f�B���̃��X�g���擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public int GetUserGdBdList(out ArrayList userGdBdList, int guideDivCode)
		{
			userGdBdList = null;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				status = this._userGuideAcs.SearchAllDivCodeBody(out userGdBdList, this._enterpriseCode, guideDivCode, UserGuideAcsData.UserBodyData);
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.ToString(),
					"���[�U�[�K�C�h�i�w�b�_�j���̎擾�Ɏ��s���܂����B" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�{�f�B�f�[�^�ݒ菈��
		/// </summary>
		/// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�{�f�B�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public void SetUserGdBd(ref SortedList sList, ref ArrayList userGdBdList)
		{
			foreach (UserGdBd userGdBd in userGdBdList)
			{
				sList.Add(userGdBd.GuideCode, userGdBd.GuideName);
			}
		}

		/// <summary>
		/// ���[�U�[�K�C�h���̎擾����
		/// </summary>
		/// <param name="userGuideSList"></param>
		/// <param name="userGuideCode"></param>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�R�[�h���疼�̂��擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public string GetUserGdBdNm(ref SortedList userGuideSList, int userGuideCode)
		{
			string retStr = "";

			if (userGuideSList.ContainsKey(userGuideCode) == true)
			{
				retStr = userGuideSList[userGuideCode].ToString();
			}
			return retStr;
		}

//----- ueno add---------- end   2007.11.21

		# endregion Private Methods

		# region Control Events

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load �C�x���g����(MAMOK01310UA)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����[�h�������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void MAMOK01310UA_Load(object sender, EventArgs e)
		{
			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

            this.panel8.BackColor = Color.Blue;

			// ��ʃN���A
			ClearScreen();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//this.TargetSetCd_uOptionSet.Focus();
            this.TargetSetCd_tComboEditor.Focus();

            // �ڕW�敪�R�[�h����уK�C�h�{�^���͋��_��ݒ肷��܂�Enabled=false
            this.TargetDivideCode_tEdit.Enabled = false;
            this.TargetGuide_Button.Enabled = false;

            // ���_���擾
            SecInfoSet secInfoSet;
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            if (secInfoSet != null)
            {
                // ��ʏ�ɃZ�b�g
                this.SectionCode_tNedit.DataText = secInfoSet.SectionCode.TrimEnd();
                this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.TrimEnd();

                // �v���C�x�[�g�ϐ��ɃZ�b�g
                this._sectionCode = secInfoSet.SectionCode.TrimEnd();
                this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

                // ���_�R�[�h�����܂��擾�ł�����ڕW�敪���g�p�\�ɂ���
                this.TargetGuide_Button.Enabled = true;
                this.TargetDivideCode_tEdit.Enabled = true;
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

			// XML�f�[�^�Ǎ�
			LoadStateXmlData();

			// ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
			if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
		}

        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʃA�N�e�B�u�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note	   : ��ʂ��A�N�e�B�u�ɂȂ����Ƃ��̃C�x���g�����ł��B</br>
		/// <br>Programer  : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		private void MAMOK01310UA_Activated(object sender, EventArgs e)
		{
			// ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
			if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(TargetGuide_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void Search_Button_Click(object sender, EventArgs e)
		{
			//----- ueno del---------- start 2007.11.21
			//// �}�X�^�e�[�u���ǂݍ���
			//int status = LoadMasterTable();
			//if (status != 0)
			//{
			//    return;
			//}
			//----- ueno del---------- end   2007.11.21

            // �ڍזڕW�f�[�^����
            bool bStatus = SearchAllSalesTarget();
            if (!bStatus)
            {
                return;
            }

            // ��ʕ\��
            DispScreen();

            // �R���g���[������
            SetControlEnabled();

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(TargetGuide_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ڕW�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void TargetGuide_Button_Click(object sender, EventArgs e)
		{
			SalesTarget salesTarget;

			// ���_�I���t���O
			bool selectedSectionFlg = false;
            string[] selectSectCd;
            selectSectCd = new string[1];
            selectSectCd[0] = this._sectionCode;

			MAMOK09190UA targetGuide = new MAMOK09190UA();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//targetGuide.TargetSetCd = (int)TargetSetCd_uOptionSet.Value;
            targetGuide.TargetSetCd = int.Parse(TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
            DialogResult dialogResult = targetGuide.ShowGuide(this, out salesTarget, selectSectCd, selectedSectionFlg);

			if (dialogResult == DialogResult.OK)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
				//this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
                if (salesTarget.TargetSetCd == 10)
                {
                    this.TargetSetCd_tComboEditor.SelectedIndex = 0;
                }
                else
                {
                    this.TargetSetCd_tComboEditor.SelectedIndex = 1;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
				// ���ԖڕW
				if (salesTarget.TargetSetCd == 10)
				{
					this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
					this.ApplyEndDate_tDateEdit.Visible = false;
					this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate);
					this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate);
				}
				// �ʊ��ԖڕW
				else
				{
					this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
					this.ApplyEndDate_tDateEdit.Visible = true;
					this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate);
					this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate);
				}
				this.TargetDivideCode_tEdit.DataText = salesTarget.TargetDivideCode;
				this.TargetDivideName_tEdit.DataText = salesTarget.TargetDivideName;

				//----- ueno del---------- start 2007.11.21
				//// �}�X�^�e�[�u���ǂݍ���
				//int status = LoadMasterTable();
				//if (status != 0)
				//{
				//    return;
				//}
				//----- ueno del---------- end   2007.11.21

                // �ڍזڕW�f�[�^����
                bool bStatus = SearchAllSalesTarget();
                if (!bStatus)
                {
                    return;
                }

                // ��ʕ\��
                DispScreen();

                // �R���g���[������
                SetControlEnabled();

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(Refer_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Q�ƃ{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void ReferSection_Button_Click(object sender, EventArgs e)
		{
			// �ڍזڕW�ҏW
			bool bStatus = ReferSectionTarget();
			if (!bStatus)
			{
				return;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(NewTarget_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �V�K�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void NewTarget_Button_Click(object sender, EventArgs e)
		{
			SalesTarget salesTarget;

			// �ڕW�f�[�^�V�K�쐬
			CreateSalesTarget(out salesTarget, this._searchFlag);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            salesTarget.SectionCode = this._sectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

			// �A�N�e�B�u�s�擾
			SetBeforeActiveRow();

			// �V�K�ڕW�f�[�^�쐬
			bool bStatus = BeforeShowNewSalesTarget(salesTarget);
            //MessageBox.Show("�V�K�ڕW�f�[�^�쐬 : " + bStatus.ToString());
			if (!bStatus)
			{
				return;
			}

			//----- ueno del---------- start 2007.11.21
			//// �}�X�^�e�[�u���ǂݍ���
			//int status = LoadMasterTable();
			//if (status != 0)
			//{
			//    return;
			//}
			//----- ueno del---------- end   2007.11.21

            // ���i�ʂ���̏��͎擾
            this._bLCode = salesTarget.BLCode;
            this._bLGroupCode = salesTarget.BLGroupCode;
            this._salesCode = salesTarget.SalesTypeCode;
            this._enterpriseGanreCode = salesTarget.ItemTypeCode;

            // �ڍזڕW�f�[�^����
            bStatus = SearchAllSalesTarget();
            //MessageBox.Show("�ڍזڕW�f�[�^���� : " + bStatus.ToString());
            if (!bStatus)
            {
                return;
            }

            // ��ʕ\��
            DispScreen();

            // �R���g���[������
            SetControlEnabled();

			// �A�N�e�B�u�s�ݒ�
			SetActiveRow();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(Edit_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ҏW�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void Edit_Button_Click(object sender, EventArgs e)
		{
			// �ڕW�f�[�^�擾
			SalesTarget salesTarget;
			CreateSalesTarget(out salesTarget, this._searchFlag);

			MAMOK09190UB editTarget = new MAMOK09190UB();
			editTarget.SalesTarget = salesTarget;
			editTarget.ShowDialog();
			if (editTarget.DialogResult == DialogResult.OK)
			{
				this.TargetDivideName_tEdit.DataText = editTarget.SalesTarget.TargetDivideName;
				this.ApplyStaDate_tDateEdit.SetDateTime(editTarget.SalesTarget.ApplyStaDate);
				this.ApplyEndDate_tDateEdit.SetDateTime(editTarget.SalesTarget.ApplyEndDate);

				// �ڍזڕW�f�[�^����
				bool bStatus = SearchAllSalesTarget();
				if (!bStatus)
				{
					return;
				}

				// ��ʕ\��
				DispScreen();

				// �R���g���[������
				SetControlEnabled();

				// �A�N�e�B�u�s�ݒ�
				SetActiveRow();

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(EditTarget_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ҏW�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void EditTarget_Button_Click(object sender, EventArgs e)
		{
			// �ڕW�f�[�^�ҏW�O����
			BeforeEditSalesTarget();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(DeleteTarget_Button)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �폜�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void DeleteTarget_Button_Click(object sender, EventArgs e)
		{
			if (this._uGrid.ActiveRow == null)
			{
				return;
			}

			if (this._uGrid != this.Section_uGrid)
			{
				// ���v�s�������ꍇ
				if ((this._uGrid.ActiveRow.Index + 1) == this._uGrid.Rows.Count)
				{
					return;
				}
			}

			// �A�N�e�B�u�s�擾
			SetBeforeActiveRow();

			// �ڍזڕW�폜
			bool bStatus = BeforeDeleteSalesTarget();
			if (!bStatus)
			{
				return;
			}

			// ��ʕ\��
			DispScreen();

			// �R���g���[������
			SetControlEnabled();

			// �A�N�e�B�u�s�ݒ�
			SetActiveRow();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// DoubleClickRow �C�x���g����(Grid)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h�̍s���_�u���N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void Grid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
		{
			if (e.Row.Index + 1 == this._uGrid.Rows.Count)
			{
				return;
			}

			// ���ԖڕW
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			{
				if (this._uGrid == this.Section_uGrid)
				{
					// ���_�ڕW�Q��
					ReferSectionTarget();
				}
				else
				{
					// �ڕW�f�[�^�ҏW�O����
					BeforeEditSalesTarget();
				}
			}
			// �ʊ��ԖڕW
			else
			{
				// �ڕW�f�[�^�ҏW�O����
				BeforeEditSalesTarget();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// SelectedTabChanged �C�x���g����(SalesTarget_uTabControl)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �I���^�u���ύX���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void SalesTarget_uTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
            if (this._cmbFontSize != null)
            {
                this._cmbFontSize.ValueChanged -= new System.EventHandler(this.cmbFontSize_ValueChanged);
            }
            if (this._uceAutoFitCol != null)
            {
                this._uceAutoFitCol.CheckedChanged -= new EventHandler(this.uceAutoFitCol_CheckedChanged);
            }

			int status = this.CustomerTarget_uTabControl.SelectedTab.Index;
			switch (status)
			{
				case 0:
					// ���_�ڕW
					this._uGrid = this.Section_uGrid;
					this._cmbFontSize = this.Section_cmbFontSize;
					this._uceAutoFitCol = this.Section_uceAutoFitCol;
                    break;
				case 1:
					// �]�ƈ��ڕW
					this._uGrid = this.Employee_uGrid;
					this._cmbFontSize = this.Employee_cmbFontSize;
					this._uceAutoFitCol = this.Employee_uceAutoFitCol;
					break;
				case 2:
					// ���i�ڕW
					this._uGrid = this.Goods_uGrid;
					this._cmbFontSize = this.Goods_cmbFontSize;
					this._uceAutoFitCol = this.Goods_uceAutoFitCol;
					break;
//----- ueno add---------- start 2007.11.21
				case 3:
					// ���Ӑ�ڕW
					this._uGrid = this.Customer_uGrid;
					this._cmbFontSize = this.Customer_cmbFontSize;
					this._uceAutoFitCol = this.Customer_uceAutoFitCol;
					break;
//----- ueno add---------- end   2007.11.21
				//case 3:
				//    // ����`���ڕW
				//    this._uGrid = this.SalesFormal_uGrid;
				//    this._cmbFontSize = this.SalesFormal_cmbFontSize;
				//    this._uceAutoFitCol = this.SalesFormal_uceAutoFitCol;
				//    break;
				//case 4:
				//    // �̔��`�ԖڕW
				//    this._uGrid = SalesForm_uGrid;
				//    this._cmbFontSize = this.SalesForm_cmbFontSize;
				//    this._uceAutoFitCol = this.SalesForm_uceAutoFitCol;
				//    break;
			}

            this._cmbFontSize.ValueChanged += new System.EventHandler(this.cmbFontSize_ValueChanged);
            this._uceAutoFitCol.CheckedChanged += new EventHandler(this.uceAutoFitCol_CheckedChanged);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ValueChanged �C�x���g����(TargetDivideCode_uOptionSet)
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ڕW�ݒ�敪�̃`�F�b�N��ύX�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void TargetDivideCode_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			// ���ԖڕW
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			{
				this.ApplyDate_uLabel.Text = "�K�p�N��";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
				this.Range_uLabel.Visible = false;
				this.ApplyEndDate_tDateEdit.Visible = false;
			}
			// �ʖڕW
			else
			{
				this.ApplyDate_uLabel.Text = "�K�p����";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
				this.Range_uLabel.Visible = true;
				this.ApplyEndDate_tDateEdit.Visible = true;
			}

			this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());
			this.TargetDivideCode_tEdit.DataText = "";
			this.TargetDivideName_tEdit.DataText = "";

			// �R���g���[������
			SetControlEnabled();
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// AfterCellActivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�����A�N�e�B�u�ɂȂ�����ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.08</br>
        /// </remarks>
        private void uGrid_AfterCellActivate(object sender, EventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            uGrid.ActiveCell = null;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �t�H���g�T�C�Y�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H���g�T�C�Y�̒l���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.05</br>
        /// </remarks>
        private void cmbFontSize_ValueChanged(object sender, EventArgs e)
		{
            TComboEditor cmbFontSize = (TComboEditor)sender;
            int fontSize = (int)cmbFontSize.Value;

            // ���_�ڕW�O���b�h
            ChangeFontSize(fontSize, ref cmbFontSize, ref this.Section_uGrid);
            // �]�ƈ��ڕW�O���b�h
            ChangeFontSize(fontSize, ref cmbFontSize, ref this.Employee_uGrid);
            // ���i�ڕW�O���b�h
            ChangeFontSize(fontSize, ref cmbFontSize, ref this.Goods_uGrid);
//----- ueno add---------- start 2007.11.21
			// ���Ӑ�ڕW�O���b�h
			ChangeFontSize(fontSize, ref cmbFontSize, ref this.Customer_uGrid);
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//// ����`���ڕW�O���b�h
			//ChangeFontSize(fontSize, ref cmbFontSize, ref this.SalesFormal_uGrid);
			//// �̔��`�ԖڕW�O���b�h
			//ChangeFontSize(fontSize, ref cmbFontSize, ref this.SalesForm_uGrid);
			//----- ueno del---------- end   2007.11.21

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��T�C�Y�̎��������`�F�b�N�`�F���W�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �`�F�b�N�{�b�N�X�̃`�F�b�N��Ԃ��ύX���ꂽ�^�C�~���O�Ŕ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void uceAutoFitCol_CheckedChanged(object sender, EventArgs e)
		{
            UltraCheckEditor uceAutoFitCol = (UltraCheckEditor)sender;

			if (this._uGrid.DataSource != null)
			{
                // �`�F�b�N�L��
                if (uceAutoFitCol.Checked)
				{
					// ���_�ڕW�O���b�h
					this.Section_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					if (!this.Section_uceAutoFitCol.Checked)
					{
						this.Section_uceAutoFitCol.Checked = true;
					}

					// �]�ƈ��ڕW�O���b�h
					this.Employee_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					if (!this.Employee_uceAutoFitCol.Checked)
					{
						this.Employee_uceAutoFitCol.Checked = true;
					}

					// ���i�ڕW�O���b�h
					this.Goods_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					if (!this.Goods_uceAutoFitCol.Checked)
					{
						this.Goods_uceAutoFitCol.Checked = true;
					}

//----- ueno add---------- start 2007.11.21
					// ���Ӑ�ڕW�O���b�h
					this.Customer_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					if (!this.Customer_uceAutoFitCol.Checked)
					{
						this.Customer_uceAutoFitCol.Checked = true;
					}
//----- ueno add---------- end   2007.11.21
					//----- ueno del---------- start 2007.11.21
					//// ����`���ڕW�O���b�h
					//this.SalesFormal_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					//if (!this.SalesFormal_uceAutoFitCol.Checked)
					//{
					//    this.SalesFormal_uceAutoFitCol.Checked = true;
					//}

					//// �̔��`�ԖڕW�O���b�h
					//this.SalesForm_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					//if (!this.SalesForm_uceAutoFitCol.Checked)
					//{
					//    this.SalesForm_uceAutoFitCol.Checked = true;
					//}
					//----- ueno del---------- end   2007.11.21

				}
                // �`�F�b�N����
				else
				{
					// ���_�ڕW�O���b�h
					this.Section_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					if (this.Section_uceAutoFitCol.Checked)
					{
						this.Section_uceAutoFitCol.Checked = false;
					}
					InitializeLayout_Section_uGrid();

					// �]�ƈ��ڕW�O���b�h
					this.Employee_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					if (this.Employee_uceAutoFitCol.Checked)
					{
						this.Employee_uceAutoFitCol.Checked = false;
					}
					InitializeLayout_Employee_uGrid();

					// ���i�ڕW�O���b�h
					this.Goods_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					if (this.Goods_uceAutoFitCol.Checked)
					{
						this.Goods_uceAutoFitCol.Checked = false;
					}
					InitializeLayout_Goods_uGrid();

//----- ueno add---------- start 2007.11.21
					// ���Ӑ�ڕW�O���b�h
					this.Customer_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					if (this.Customer_uceAutoFitCol.Checked)
					{
						this.Customer_uceAutoFitCol.Checked = false;
					}
					InitializeLayout_Customer_uGrid();
//----- ueno add---------- end   2007.11.21
					//----- ueno del---------- start 2007.11.21
					//// ����`���ڕW�O���b�h
					//this.SalesFormal_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					//if (this.SalesFormal_uceAutoFitCol.Checked)
					//{
					//    this.SalesFormal_uceAutoFitCol.Checked = false;
					//}
					//InitializeLayout_SalesFormal_uGrid();

					//// �̔��`�ԖڕW�O���b�h
					//this.SalesForm_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					//if (this.SalesForm_uceAutoFitCol.Checked)
					//{
					//    this.SalesForm_uceAutoFitCol.Checked = false;
					//}
					//InitializeLayout_SalesForm_uGrid();
				}
				//----- ueno del---------- end   2007.11.21

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// tArrowKeyControlChangeFocus�C�x���g
		/// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            int rowCount = this._uGrid.Rows.Count;

            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "NewSection_Button":
                        if (e.Key == Keys.Right)
                        {
                            if (!this.EditSection_Button.Enabled)
                            {
                                e.NextCtrl = this.NewSection_Button;
                            }
                        }
                        break;
                    case "NewEmployee_Button":
                        if (e.Key == Keys.Right)
                        {
                            if (!this.EditEmployee_Button.Enabled)
                            {
                                e.NextCtrl = this.NewEmployee_Button;
                            }
                        }
                        break;
                    case "NewGoods_Button":
                        if (e.Key == Keys.Right)
                        {
                            if (!this.EditGoods_Button.Enabled)
                            {
                                e.NextCtrl = this.NewGoods_Button;
                            }
                        }
                        break;
//----- ueno add---------- start 2007.11.21
					case "NewCustomer_Button":
						if (e.Key == Keys.Right)
						{
							if (!this.EditCustomer_Button.Enabled)
							{
								e.NextCtrl = this.NewCustomer_Button;
							}
						}
						break;
//----- ueno add---------- end   2007.11.21
					//----- ueno del---------- start 2007.11.21
					//case "NewSalesFormal_Button":
					//    if (e.Key == Keys.Right)
					//    {
					//        if (!this.EditSalesFormal_Button.Enabled)
					//        {
					//            e.NextCtrl = this.NewSalesFormal_Button;
					//        }
					//    }
					//    break;
					//case "NewSalesForm_Button":
					//    if (e.Key == Keys.Right)
					//    {
					//        if (!this.EditSalesForm_Button.Enabled)
					//        {
					//            e.NextCtrl = this.NewSalesForm_Button;
					//        }
					//    }
					//    break;
					//----- ueno del---------- end   2007.11.21
				}
            }

            // Next�t�H�[�J�X���O���b�h�̏ꍇ
            if (e.NextCtrl == this._uGrid)
            {
                if (this._uGrid.Rows.Count > 0)
                {
                    if (this._uGrid.ActiveRow != null)
                    {
                        if (!this._uGrid.ActiveRow.Selected)
                        {
                            this._uGrid.ActiveRow.Selected = true;
                        }
                    }
                    else
                    {
                        this._uGrid.Rows[0].Activate();
                        this._uGrid.Rows[0].Selected = true;
                    }
                    return;
                }
                else
                {
                    if (e.Key == Keys.Up)
                    {
                        int status = this.CustomerTarget_uTabControl.SelectedTab.Index;
                        switch (status)
                        {
                            case 0:
                                // ���_�ڕW
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
                                {
                                    e.NextCtrl = this.CustomerTarget_uTabControl;
                                }
                                else
                                {
                                    e.NextCtrl = this.NewSection_Button;
                                }
                                break;
                            case 1:
                                // �]�ƈ��ڕW
                                e.NextCtrl = this.NewEmployee_Button;
                                break;
                            case 2:
                                // ���i�ڕW
                                e.NextCtrl = this.NewGoods_Button;
                                break;
//----- ueno add---------- start 2007.11.21
							case 3:
								// ���Ӑ�ڕW
								e.NextCtrl = this.NewCustomer_Button;
								break;
//----- ueno add---------- end   2007.11.21
							//----- ueno del---------- start 2007.11.21
							//case 3:
							//    // ����`���ڕW
							//    e.NextCtrl = this.NewSalesFormal_Button;
							//    break;
							//case 4:
							//    // �̔��`�ԖڕW
							//    e.NextCtrl = this.NewSalesForm_Button;
							//    break;
							//----- ueno del---------- end   2007.11.21
						}
                    }
                    else if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = this._cmbFontSize;
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this._cmbFontSize;
                    }
                }
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// KeyDown �C�x���g(Grid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �J�[�\���{�^�������������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.28</br>
		/// </remarks>
		private void Grid_KeyDown(object sender, KeyEventArgs e)
		{
			UltraGrid uGrid = (UltraGrid)sender;

			if (uGrid.Rows.Count < 1)
			{
				return;
			}

			int rowIndex = uGrid.ActiveRow.Index;
			int rowCount = uGrid.Rows.Count;

			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
			{
				if (rowIndex == 0)
				{
					if (uGrid == this.Section_uGrid)
					{
						this.ReferSection_Button.Focus();
					}
					else if (uGrid == this.Employee_uGrid)
					{
						this.NewEmployee_Button.Focus();
					}
					else if (uGrid == this.Goods_uGrid)
					{
						this.NewGoods_Button.Focus();
					}
//----- ueno add---------- start 2007.11.21
					else if (uGrid == this.Customer_uGrid)
					{
						this.NewCustomer_Button.Focus();
					}
//----- ueno add---------- end   2007.11.21
					//----- ueno del---------- start 2007.11.21
					//else if (uGrid == this.SalesFormal_uGrid)
					//{
					//    this.NewSalesFormal_Button.Focus();
					//}
					//else if (uGrid == this.SalesForm_uGrid)
					//{
					//    this.NewSalesForm_Button.Focus();
					//}
					//----- ueno del---------- end   2007.11.21
				}
			}
			else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
			{
				if (rowIndex + 2 == rowCount)
				{
					if (uGrid == this.Section_uGrid)
					{
						this.Section_cmbFontSize.Focus();
					}
					else if (uGrid == this.Employee_uGrid)
					{
						this.Employee_cmbFontSize.Focus();
					}
					else if (uGrid == this.Goods_uGrid)
					{
						this.Goods_cmbFontSize.Focus();
					}
//----- ueno add---------- start 2007.11.21
					else if (uGrid == this.Customer_uGrid)
					{
						this.Customer_cmbFontSize.Focus();
					}
//----- ueno add---------- end   2007.11.21
					//----- ueno del---------- start 2007.11.21
					//else if (uGrid == this.SalesFormal_uGrid)
					//{
					//    this.SalesFormal_cmbFontSize.Focus();
					//}
					//else if (uGrid == this.SalesForm_uGrid)
					//{
					//    this.SalesForm_cmbFontSize.Focus();
					//}
					//----- ueno del---------- end 2007.11.21
				}
			}
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START

        /// <summary>
        /// ���_�R�[�h���͗�Leave����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���_�R�[�h���͗���Leave�������ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.03</br>
        /// </remarks>
        private void SectionCode_tNedit_Leave(object sender, EventArgs e)
        {
            string sectionCode = this.SectionCode_tNedit.Text;

            if (!String.IsNullOrEmpty(sectionCode))
            {
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.SectionName_tEdit.DataText = sectionInfo.SectionGuideNm.TrimEnd();

                    // ���_�R�[�h�����܂��擾�ł�����ڕW�敪���g�p�\�ɂ���
                    this.TargetGuide_Button.Enabled = true;
                    this.TargetDivideCode_tEdit.Enabled = true;

                    // ���ʕϐ��ɕۑ�
                    this._sectionCode = sectionInfo.SectionCode.TrimEnd();
                    this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();

                }
            }
        }

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���i �r��</br>
        /// <br>Date		: 2008.07.03</br>
        /// </remarks>
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionCode_tNedit.DataText = sectionInfo.SectionCode.TrimEnd();
                this.SectionName_tEdit.DataText = sectionInfo.SectionGuideNm.TrimEnd();

                // ���_�R�[�h�����܂��擾�ł�����ڕW�敪���g�p�\�ɂ���
                this.TargetGuide_Button.Enabled = true;
                this.TargetDivideCode_tEdit.Enabled = true;

                // ���ʕϐ��ɕۑ�
                this._sectionCode = sectionInfo.SectionCode.TrimEnd();
                this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

		# endregion Control Events

	}
}