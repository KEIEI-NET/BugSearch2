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
	/// 売上目標設定(要素別)画面
	/// </summary>
	/// <remarks>
	/// <br>Note			 : 売上目標設定(要素別)を行う画面です。</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.04.23</br>
	/// <br>Update Note		 : 2007.11.21 上野 弘貴</br>
	/// <br>                   流通.DC用に変更（項目追加・削除）</br>
	/// <br>Update Note		 : 2008.03.07 上野 弘貴</br>
	/// <br>                   項目表示変更</br>
	/// </remarks>
	public partial class MAMOK01310UA : Form, ISalesMonDetailsTargetMDIChild
	{
		# region Private Constants

		// 画面状態保存用ファイル名
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

		// PG名称
		private const string ctPGNM = "売上目標設定(要素別)";

		// テーブル名称
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
		private const string VIEW_SALESTARGET_TARGETCONSTRASTNM = "目標対比区分";
//----- ueno add---------- end   2007.11.21
		private const string VIEW_SALESTARGET_SECTIONNAME = "拠点";
		private const string VIEW_SALESTARGET_EMPLOYEECODE = "従業員コード";
		private const string VIEW_SALESTARGET_NAME = "従業員名";
		private const string VIEW_SALESTARGET_GOODSCODE = "商品コード";
		private const string VIEW_SALESTARGET_GOODSNAME = "商品名";
		private const string VIEW_SALESTARGET_MAKERNAME = "メーカー名称";
//----- ueno add---------- start 2007.11.21
		private const string VIEW_SALESTARGET_MAKERCODE = "メーカーコード";
		private const string VIEW_SALESTARGET_EMPLOYEEDIVCD = "従業員区分";
		private const string VIEW_SALESTARGET_EMPLOYEEDIVNM = "従業員区分名称";
		private const string VIEW_SALESTARGET_SUBSECTIONCODE = "部門コード";
		private const string VIEW_SALESTARGET_SUBSECTIONNAME = "部門名称";
		private const string VIEW_SALESTARGET_MINSECTIONCODE = "課コード";
		private const string VIEW_SALESTARGET_MINSECTIONNAME = "課名称";
		private const string VIEW_SALESTARGET_BUSINESSTYPECODE = "業種コード";
		private const string VIEW_SALESTARGET_BUSINESSTYPENAME = "業種名称";
		private const string VIEW_SALESTARGET_SALESAREACODE = "販売エリアコード";
		private const string VIEW_SALESTARGET_SALESAREANAME = "販売エリア名称";
		private const string VIEW_SALESTARGET_CUSTOMERCODE = "得意先コード";
		private const string VIEW_SALESTARGET_CUSTOMERNAME = "得意先名称";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string VIEW_SALESTARGET_SALESFORMAL = "売上形式";
		//private const string VIEW_SALESTARGET_SALESFORM = "販売形態";
		//----- ueno del---------- end   2007.11.21
		private const string VIEW_SALESTARGET_MONEY_MONTH = "売上目標\n(円/月)";
        private const string VIEW_SALESTARGET_PROFIT_MONTH = "粗利目標\n(円/月)";

		//----- ueno upd ---------- start 2008.03.07 「台」削除
        private const string VIEW_SALESTARGET_COUNT_MONTH = "数量目標\n(月)";
		//----- ueno upd ---------- end 2008.03.07

        private const string VIEW_SALESTARGET_MONEY_TERM = "売上目標\n(円/期間)";
        private const string VIEW_SALESTARGET_PROFIT_TERM = "粗利目標\n(円/期間)";

		//----- ueno upd ---------- start 2008.03.07 「台」削除
        private const string VIEW_SALESTARGET_COUNT_TERM = "数量目標\n(期間)";
		//----- ueno upd ---------- end 2008.03.07

		//----- ueno del---------- start 2007.11.21
		#region del
		//private const string VIEW_SALESTARGET_MONEY_SUNDAY = "日曜売上目標\n(円/日)";
		//private const string VIEW_SALESTARGET_PROFIT_SUNDAY = "日曜粗利目標\n(円/日)";
		//private const string VIEW_SALESTARGET_COUNT_SUNDAY = "日曜数量目標\n(台/日)";
		//private const string VIEW_SALESTARGET_MONEY_MONDAY = "月曜売上目標\n(円/日)";
		//private const string VIEW_SALESTARGET_PROFIT_MONDAY = "月曜粗利目標\n(円/日)";
		//private const string VIEW_SALESTARGET_COUNT_MONDAY = "月曜数量目標\n(台/日)";
		//private const string VIEW_SALESTARGET_MONEY_TUESDAY = "火曜売上目標\n(円/日)";
		//private const string VIEW_SALESTARGET_PROFIT_TUESDAY = "火曜粗利目標\n(円/日)";
		//private const string VIEW_SALESTARGET_COUNT_TUESDAY = "火曜数量目標\n(台/日)";
		//private const string VIEW_SALESTARGET_MONEY_WEDNESDAY = "水曜売上目標\n(円/日)";
		//private const string VIEW_SALESTARGET_PROFIT_WEDNESDAY = "水曜粗利目標\n(円/日)";
		//private const string VIEW_SALESTARGET_COUNT_WEDNESDAY = "水曜数量目標\n(台/日)";
		//private const string VIEW_SALESTARGET_MONEY_THURSDAY = "木曜売上目標\n(円/日)";
		//private const string VIEW_SALESTARGET_PROFIT_THURSDAY = "木曜粗利目標\n(円/日)";
		//private const string VIEW_SALESTARGET_COUNT_THURSDAY = "木曜数量目標\n(台/日)";
		//private const string VIEW_SALESTARGET_MONEY_FRIDAY = "金曜売上目標\n(円/日)";
		//private const string VIEW_SALESTARGET_PROFIT_FRIDAY = "金曜粗利目標\n(円/日)";
		//private const string VIEW_SALESTARGET_COUNT_FRIDAY = "金曜数量目標\n(台/日)";
		//private const string VIEW_SALESTARGET_MONEY_SATURDAY = "土曜売上目標\n(円/日)";
		//private const string VIEW_SALESTARGET_PROFIT_SATURDAY = "土曜粗利目標\n(円/日)";
		//private const string VIEW_SALESTARGET_COUNT_SATURDAY = "土曜数量目標\n(台/日)";
		//private const string VIEW_SALESTARGET_MONEY_HOLIDAY = "祝祭日売上目標\n(円/日)";
		//private const string VIEW_SALESTARGET_PROFIT_HOLIDAY = "祝祭日粗利目標\n(円/日)";
		//private const string VIEW_SALESTARGET_COUNT_HOLIDAY = "祝祭日数量目標\n(台/日)";
		#endregion del
		//----- ueno del---------- end   2007.11.21
		private const string VIEW_SALESTARGET_TOTAL = "合計";

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
		private const int GUIDEDIVCD_BUSINESSTYPECODE = 33;	// ユーザーガイド区分（業種コード）
		private const int GUIDEDIVCD_SALESAREACODE = 21;	// ユーザーガイド区分（販売エリアコード）
//----- ueno add---------- end   2007.11.21

        private const string FORMAT_NUM = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

		// 拠点目標用従業員コード
		private const string EMPLOYEECODE_SECTION = "SECTION";

		//----- ueno del---------- start 2007.11.21
		//// 機種コードなし
		//private const string CELLPHONEMODELCODE_NONE = "none";
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
		private const int DUMMY_TARGETCONSTRASTCD = 99999;	// グリッドソート時使用（合計行にダミー設定）
//----- ueno add---------- end   2007.11.21

		# endregion Private Constants

		# region Private Members

		// タイトル
		private readonly string _title;
		// 元に戻すボタン
		private bool _undoButton;

		// 企業コード
		private string _enterpriseCode;
		// 拠点コード
		private string _sectionCode;
		// 拠点名
		private string _sectionName;

		// グリッド
		private UltraGrid _uGrid;
		// フォントサイズ
		private TComboEditor _cmbFontSize;
		// 列サイズ
		private UltraCheckEditor _uceAutoFitCol;

		// 目標マスタアクセスクラス
		private SalesTargetAcs _salesTargetAcs;

		// 目標データリスト
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
        // 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

//----- ueno add---------- start 2007.11.21
		// ユーザーガイドアクセスクラス
		private UserGuideAcs _userGuideAcs = null;

		// ユーザーガイドデータ格納用（業種コード）
		private SortedList _businessTypeCodeSList = null;

		// ユーザーガイドデータ格納用（販売エリアコード）
		private SortedList _salesAreaCodeSList = null;
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		//// 休業日設定マスタ
		//private Dictionary<SectionAndDate, HolidaySetting> _holidaySettingDic;

		//// 着地計算比率リスト
		//private List<LdgCalcRatioMng> _ldgCalcRatioMngList;
		//----- ueno del---------- end   2007.11.21

		// グリッド設定制御クラス
		private GridStateController _gridStateController;

		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 検索フラグ
		private bool _searchFlag;

		// 保管用従業員
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

		// 保管用商品
//----- ueno add---------- start 2007.11.21
		//private int _goodsTargetConstrastCd = 0;
        private int _goodsTargetConstrastCd = 43;
//----- ueno add---------- end   2007.11.21
		private string _goodsCode;
		private string _goodsName;
		private int _makerCode;

//----- ueno add---------- start 2007.11.21
		// 保管用得意先
		private int _custTargetConstrastCd = 0;
		private int _businessTypeCode;
		private string _businessTypeName;
		private int _salesAreaCode;
		private string _salesAreaName;
		private int _customerCode;
		private string _customerName = "";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//// 保管用売上形式
		//private int _salesFormalCode;
		//private string _salesFormalName;
		//// 保管用販売形態
		//private int _salesFormCode;
		//private string _salesFormName;
		//----- ueno del---------- end   2007.11.21

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
        // BLコード
        private int _bLCode;
        // BLグループコード
        private int _bLGroupCode;
        // 販売区分コード
        private int _salesCode;
        // 商品区分コード
        private int _enterpriseGanreCode;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAMOK01310UA()
		{
			InitializeComponent();

			// 元に戻す
			this._undoButton = true;

			// 企業コードを取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 拠点情報取得
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
            // 拠点アクセスクラス
            this._secInfoSetAcs = new SecInfoSetAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

//----- ueno add---------- start 2007.11.21
			// ユーザーガイドアクセスクラス
			this._userGuideAcs = new UserGuideAcs();

			// ユーザーガイドデータ格納用（業種コード）
			this._businessTypeCodeSList = new SortedList();

			// ユーザーガイドデータ格納用（販売エリアコード）
			this._salesAreaCodeSList = new SortedList();
//----- ueno add---------- end   2007.11.21

			// アイコン画像の設定

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // 拠点コードガイドボタン
            this.SectionCodeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END
			// 検索ボタン
			this.Search_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];
			// 目標ガイドボタン
			this.TargetGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			// 参照ボタン
			this.ReferSection_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW];
			// 新規ボタン
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
			
			// 編集ボタン
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
			
			// 削除ボタン
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

		# region ISalesMonDetailsTargetMDIChild メンバ

		/// <summary>
		/// タイトル
		/// </summary>
		public string Title
		{
			get
			{
				return (_title);
			}
		}

		/// <summary>
		/// 元に戻すボタン
		/// </summary>
		public bool UndoButton
		{
			get
			{
				return (_undoButton);
			}
		}

		/// <summary>
		/// 選択拠点取得イベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームにて選択されている拠点コードを取得します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		//public event GetSalesMonDetailsTargetSelectSectionCodeEventHandler GetSelectSectionCodeEvent;

		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <remarks>
		/// <br>Note		: フレームのボタン有効無効制御をしたい場合に発生させます。
		///					  (IPaymentInputMDIChildインターフェースの実装)</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public event ParentToolbarSalesMonDetailsTargetSettingEventHandler ParentToolbarSettingEvent;

		/// <summary>
		/// 拠点変更後処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: フレームにて拠点が変更された後に処理されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public void AfterSectionChange()
		{

		}

		/// <summary>
		/// 終了前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 画面を閉じる前に処理されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public int BeforeClose(object parameter)
		{
			// 画面状態を保存
			SaveStateXmlData();
			return (0);
		}

		/// <summary>
		/// 拠点変更前処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: フレームにて拠点が変更される前に処理されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public int BeforeSectionChange()
		{
			return (0);
		}

		/// <summary>
		/// タブ切替前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: フレームにてタブが切り替えられる前に処理されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public int BeforeTabChange(object parameter)
		{
			return (0);
		}

        /// <summary>
        /// フォーム初期化処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: フレームにてフォームが生成される前に処理されます。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.06.11</br>
        /// </remarks>
        public int InitializeForm()
        {
			//----- ueno del---------- start 2007.11.21
			//int status = LoadMasterTable();
			//if (status != 0)
			//{
			//    // ツールバー初期化
			//    this._undoButton = false;
			//    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
			//}
			//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
			int status = 0;
			
			// ユーザーガイドデータ取得
			ArrayList userGdBdList;
			
			// 業種コード取得
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_BUSINESSTYPECODE);
			SetUserGdBd(ref this._businessTypeCodeSList, ref userGdBdList);
			
			// 販売エリア取得
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_SALESAREACODE);
			SetUserGdBd(ref this._salesAreaCodeSList, ref userGdBdList);

//----- ueno add---------- end   2007.11.21

            return (status);

        }

		/// <summary>
		/// モードレス表示処理（パラメータ有り）
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <remarks>
		/// <br>Note		: 通常起動時にフレームから呼び出されます。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		public void Show(object parameter)
		{
			this.Show();
		}

		/// <summary>
		/// 元に戻す処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面をクリアします</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public void UndoSalesMonTargetProc()
		{
			if (this._searchFlag == false)
			{
				return;
			}

			string Msg = "画面情報をクリアしますが、よろしいですか？";
			DialogResult res = TMsgDisp.Show(
										this, 							// 親ウィンドウフォーム
										emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
										this.Name,						// アセンブリID
										Msg, 							// 表示するメッセージ
										0,								// ステータス値
										MessageBoxButtons.OKCancel);	// 表示するボタン

			switch (res)
			{
				case DialogResult.OK:
					{
						// 画面クリア
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

		# endregion ISalesMonDetailsTargetMDIChild メンバ

		# region Private Methods

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// マスタ読込処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 各マスタを読み込みます。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.24</br>
		///// </remarks>
		//private int LoadMasterTable()
		//{
		//    int status;

		//    // 休業日設定マスタ
		//    status = LoadHolidaySettingTable(this._sectionCode);
		//    if (status != 0)
		//    {
		//        return (status);
		//    }


		//    // 着地計算比率管理マスタ
		//    status = LoadLdgCalcRatioMngTable(this._sectionCode);

		//    if (status != 0)
		//    {
		//        return (status);
		//    }
		//    return (0);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 休業日設定マスタ読み込み処理
		///// </summary>
		///// <param name="sectionCode">拠点コード</param>
		///// <remarks>
		///// <br>Note		: 休業日設定マスタを読み込み休業日適用区分を取得します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.11</br>
		///// </remarks>
		//private int LoadHolidaySettingTable(string sectionCode)
		//{
		//    int status;
		//    ArrayList retList;

		//    _holidaySettingDic = new Dictionary<SectionAndDate, HolidaySetting>();

		//    // 休業日設定マスタからデータを取得
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
		//                this,										// 親ウィンドウフォーム
		//                emErrorLevel.ERR_LEVEL_STOP,				// エラーレベル
		//                this.Name,									// アセンブリID
		//                ctPGNM,  　　								// プログラム名称
		//                "LoadHolidaySettingTable",					// 処理名称
		//                TMsgDisp.OPE_GET,							// オペレーション
		//                "休業日設定マスタの読み込みに失敗しました",					// 表示するメッセージ
		//                status,										// ステータス値
		//                holidaySettingAcs,							// エラーが発生したオブジェクト
		//                MessageBoxButtons.OK,			  			// 表示するボタン
		//                MessageBoxDefaultButton.Button1);			// 初期表示ボタン
		//            return (status);
		//    }

		//    // リスト作成
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
		///// 着地計算比率管理マスタ読み込み処理
		///// </summary>
		///// <param name="sectionCode">拠点コード</param>
		///// <remarks>
		///// <br>Note		: 着地計算比率管理マスタを読み込み各曜日の比率を取得します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.12</br>
		///// </remarks>
		//private int LoadLdgCalcRatioMngTable(string sectionCode)
		//{
		//    LdgCalcRatioMngAcs ldgCalcRatioMngAcs = new LdgCalcRatioMngAcs();
		//    this._ldgCalcRatioMngList = new List<LdgCalcRatioMng>();

		//    string[] sectionCodeList = new string[1];
		//    sectionCodeList[0] = sectionCode;

		//    // 着地計算比率管理マスタ取得
		//    int status = ldgCalcRatioMngAcs.Search(out this._ldgCalcRatioMngList, this._enterpriseCode, sectionCodeList);
		//    switch (status)
		//    {
		//        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//        case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//            // 正常
		//            break;
		//        default:
		//            // エラー
		//            return (status);
		//    }

		//    return (0);
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ＸＭＬデータの保存処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面状態保持用のＸＭＬの保存処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void SaveStateXmlData()
		{
			// グリッド情報を保存
			this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this._uGrid);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ＸＭＬデータの読込処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
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
					// フォントサイズ
					this._cmbFontSize.Value = (int)gridStateInfo.FontSize;
					// 列の自動調整
					this._uceAutoFitCol.Checked = gridStateInfo.AutoFit;
				}
				else
				{
					status = 4;
				}
			}
			if (status != 0)
			{
				// フォントサイズ
				this._cmbFontSize.Value = 10;
				// 列の自動調整
				this._uceAutoFitCol.Checked = false;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 列追加（共通部分）処理
		/// </summary>
        /// <param name="dataTable">データテーブル</param>
		/// <remarks>
		/// <br>Note		: テーブルに列（共通部分）を追加します。</br>
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
		/// データ設定（共通部分）処理
		/// </summary>
        /// <param name="dataRow">データロウ</param>
        /// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// <br>Note		: データ設定（共通部分）を行います。</br>
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
		/// 目標データ（拠点）グリッド表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 目標データ（拠点）をグリッドに表示します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void DispScreenSection_uGrid()
		{
			// データ追加用
			DataRow dataRow;

			// テーブルの定義
			DataTable dataTable = new DataTable(SECTION_SALESTARGET);

			dataTable.Columns.Add(COL_SALESTARGET_SECTIONCODE, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_SECTIONNAME, typeof(string));
			// 列追加（共通部分）
			DispScreenCommonColumn(ref dataTable);

			foreach (SalesTarget salesTarget in this._sectionSalesTargetList)
			{
				dataRow = dataTable.NewRow();

				dataRow[COL_SALESTARGET_SECTIONCODE] = this._sectionCode;
				dataRow[COL_SALESTARGET_SECTIONNAME] = this._sectionName;
				// データ設定（共通部分）
				DispScreenCommonRow(ref dataRow, salesTarget);

				// データ追加
				dataTable.Rows.Add(dataRow);
			}

			// 合計行追加
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

				// データ追加
				dataTable.Rows.Add(dataRow);
			}

			this.Section_uGrid.DataSource = dataTable;
			this.Section_uGrid.DataBind();
		}
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ（従業員）グリッド表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 目標データ（従業員）をグリッドに表示します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void DispScreenEmployee_uGrid()
		{
			// データ追加用
			DataRow dataRow;

			// テーブルの定義
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

			// 列追加（共通部分）
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
				
				// データ設定（共通部分）
				DispScreenCommonRow(ref dataRow, salesTarget);

				// データ追加
				dataTable.Rows.Add(dataRow);
			}

			// 合計行追加
			if (this._employeeSalesTargetList.Count > 0)
			{
				dataRow = dataTable.NewRow();

//----- ueno upd---------- start 2007.11.21
				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = DUMMY_TARGETCONSTRASTCD;	// ソート用
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

				// データ追加
				dataTable.Rows.Add(dataRow);
			}

//----- ueno add---------- start 2007.11.21
			this.Employee_uGrid.DataSource = dataTable.DefaultView;

			// ソート（目標対比区分, 従業員区分, 部門コード, 課コード, 従業員コード昇順）
			string sortStr = string.Format("{0} ASC, {1} ASC, {2} ASC, {3} ASC",//, {4} ASC",
				COL_SALESTARGET_TARGETCONSTRASTCD, COL_SALESTARGET_EMPLOYEEDIVCD,
				COL_SALESTARGET_SUBSECTIONCODE, COL_SALESTARGET_EMPLOYEECODE);//, COL_SALESTARGET_MINSECTIONCODE, COL_SALESTARGET_EMPLOYEECODE);

			dataTable.DefaultView.Sort = sortStr;
//----- ueno add---------- end   2007.11.21

			this.Employee_uGrid.DataBind();
		}
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ（商品）グリッド表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 目標データ（商品）をグリッドに表示します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void DispScreenGoods_uGrid()
		{
			// データ追加用
			DataRow dataRow;

			// テーブルの定義
			DataTable dataTable = new DataTable(GOODS_SALESTARGET);

//----- ueno add---------- start 2007.11.21
			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTCD, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTNM, typeof(string));
//----- ueno add---------- end   2007.11.21

			dataTable.Columns.Add(COL_SALESTARGET_MAKERCODE, typeof(int));
			dataTable.Columns.Add(COL_SALESTARGET_MAKERNAME, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_GOODSCODE, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_GOODSNAME, typeof(string));
			// 列追加（共通部分）
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

				// データ設定（共通部分）
				DispScreenCommonRow(ref dataRow, salesTarget);

				// データ追加
				dataTable.Rows.Add(dataRow);
			}

			// 合計行追加
			if (this._goodsSalesTargetList.Count > 0)
			{
				dataRow = dataTable.NewRow();

//----- ueno upd---------- start 2007.11.21
				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = DUMMY_TARGETCONSTRASTCD;	// ソート用
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

				// データ追加
				dataTable.Rows.Add(dataRow);
			}

//----- ueno add---------- start 2007.11.21
			this.Goods_uGrid.DataSource = dataTable.DefaultView;

			// ソート（目標対比区分, メーカーコード, 商品コード昇順）
			string sortStr = string.Format("{0} ASC, {1} ASC, {2} ASC", COL_SALESTARGET_TARGETCONSTRASTCD, COL_SALESTARGET_MAKERCODE, COL_SALESTARGET_GOODSCODE);
			dataTable.DefaultView.Sort = sortStr;
			
//----- ueno add---------- end   2007.11.21

			this.Goods_uGrid.DataBind();
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 目標データ（売上形式）グリッド表示処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 目標データ（売上形式）をグリッドに表示します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void DispScreenSalesFormal_uGrid()
		//{
		//    // データ追加用
		//    DataRow dataRow;

		//    // テーブルの定義
		//    DataTable dataTable = new DataTable(SALESFORMAL_SALESTARGET);

		//    dataTable.Columns.Add(COL_SALESTARGET_SALESFORMALCODE, typeof(int));
		//    dataTable.Columns.Add(COL_SALESTARGET_SALESFORMAL, typeof(string));
		//    // 列追加（共通部分）
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

		//        // データ設定（共通部分）
		//        DispScreenCommonRow(ref dataRow, salesTarget);

		//        // データ追加
		//        dataTable.Rows.Add(dataRow);
		//    }

		//    // 合計行追加
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

		//        // データ追加
		//        dataTable.Rows.Add(dataRow);
		//    }

		//    this.SalesFormal_uGrid.DataSource = dataTable;
		//    this.SalesFormal_uGrid.DataBind();
		//}
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 目標データ（販売目標）グリッド表示処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 目標データ（販売目標）をグリッドに表示します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void DispScreenSalesForm_uGrid()
		//{
		//    // データ追加用
		//    DataRow dataRow;

		//    // テーブルの定義
		//    DataTable dataTable = new DataTable(SALESFORM_SALESTARGET);

		//    dataTable.Columns.Add(COL_SALESTARGET_SALESFORMCODE, typeof(int));
		//    dataTable.Columns.Add(COL_SALESTARGET_SALESFORM, typeof(string));
		//    // 列追加（共通部分）
		//    DispScreenCommonColumn(ref dataTable);

		//    foreach (SalesTarget salesTarget in this._salesFormSalesTargetList)
		//    {
		//        dataRow = dataTable.NewRow();

		//        dataRow[COL_SALESTARGET_SALESFORMCODE] = salesTarget.SalesFormCode;
		//        dataRow[COL_SALESTARGET_SALESFORM] = salesTarget.SalesFormName;

		//        // データ設定（共通部分）
		//        DispScreenCommonRow(ref dataRow, salesTarget);

		//        // データ追加
		//        dataTable.Rows.Add(dataRow);
		//    }

		//    // 合計行追加
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

		//        // データ追加
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
		/// 目標データ（得意先）グリッド表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 目標データ（得意先）をグリッドに表示します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private void DispScreenCustomer_uGrid()
		{
			// データ追加用
			DataRow dataRow;

			// テーブルの定義
			DataTable dataTable = new DataTable(CUSTOMER_SALESTARGET);

			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTCD, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_TARGETCONSTRASTNM, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_BUSINESSTYPECODE, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_BUSINESSTYPENAME, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_SALESAREACODE, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_SALESAREANAME, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_CUSTOMERCODE, typeof(Int32));
			dataTable.Columns.Add(COL_SALESTARGET_CUSTOMERNAME, typeof(string));
			
			// 列追加（共通部分）
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
				
				// データ設定（共通部分）
				DispScreenCommonRow(ref dataRow, salesTarget);

				// データ追加
				dataTable.Rows.Add(dataRow);
			}

			// 合計行追加
			if (this._customerTargetList.Count > 0)
			{
				dataRow = dataTable.NewRow();

				dataRow[COL_SALESTARGET_TARGETCONSTRASTCD] = DUMMY_TARGETCONSTRASTCD;	// ソート用
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

				// データ追加
				dataTable.Rows.Add(dataRow);
			}
			this.Customer_uGrid.DataSource = dataTable.DefaultView;

			// ソート（目標対比区分, 得意先コード, 業種コード, 販売エリアコード昇順）
			string sortStr = string.Format("{0} ASC, {1} ASC, {2} ASC, {3} ASC",
				COL_SALESTARGET_TARGETCONSTRASTCD, COL_SALESTARGET_CUSTOMERCODE, COL_SALESTARGET_BUSINESSTYPECODE, COL_SALESTARGET_SALESAREACODE);

			dataTable.DefaultView.Sort = sortStr;

			this.Customer_uGrid.DataBind();
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// グリッドレイアウト設定（共通部分）処理
		/// </summary>
        /// <param name="uGrid">グリッド</param>
		/// <remarks>
		/// <br>Note		: グリッドのレイアウト設定（共通部分）を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void GridCommonInitializeLayout(UltraGrid uGrid)
		{
			// 売上
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Width = WIDTH_SALESTARGET_MONEY;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].CellActivation = Activation.NoEdit;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MONEY].Format = FORMAT_NUM;

			// 粗利
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Width = WIDTH_SALESTARGET_PROFIT;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].CellActivation = Activation.NoEdit;
			uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_PROFIT].Format = FORMAT_NUM;

			// 数量
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
			//// 日曜売上
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

			//// 日曜粗利
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

			//// 日曜数量
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

			//// 月曜売上
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


			//// 月曜粗利
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

			//// 月曜数量
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

			//// 火曜売上
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

			//// 火曜粗利
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

			//// 火曜数量
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

			//// 水曜売上
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

			//// 水曜粗利
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

			//// 水曜数量
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

			//// 木曜売上
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

			//// 木曜粗利
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

			//// 木曜数量
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

			//// 金曜売上
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

			//// 金曜粗利
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

			//// 金曜数量
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

			//// 土曜売上
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

			//// 土曜粗利
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

			//// 土曜数量
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

			//// 祝祭日売上
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

			//// 祝祭日粗利
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

			//// 祝祭日数量
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

			// ヘッダーキャプション
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

			// 合計行追加
			if (rowIndex > 0)
			{
				uGrid.DisplayLayout.Rows[rowIndex - 1].Activation = Activation.Disabled;
                uGrid.DisplayLayout.Rows[rowIndex - 1].Appearance.BackColor = COLOR_TOTAL;
				uGrid.DisplayLayout.Rows[rowIndex - 1].Appearance.ForeColorDisabled = Color.Black;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// グリッドレイアウト設定（拠点）処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッドのレイアウト設定（拠点）を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void InitializeLayout_Section_uGrid()
		{
			this.Section_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTIONCODE].Hidden = true;

			// 拠点名称
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
		/// グリッドレイアウト設定（従業員）処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッドのレイアウト設定（従業員）を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void InitializeLayout_Employee_uGrid()
		{
//----- ueno add---------- start 2007.11.21
			// 目標対比区分コード
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTCD].Hidden = true;
			
			// 目標対比区分名称
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Width = WIDTH_SALESTARGET_TARGETCONSTRASTNM;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Caption = VIEW_SALESTARGET_TARGETCONSTRASTNM;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellActivation = Activation.NoEdit;

			// 従業員区分コード
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
			
			// 従業員区分名称
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].Width = WIDTH_SALESTARGET_EMPLOYEEDIVNM;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].Header.Caption = VIEW_SALESTARGET_EMPLOYEEDIVNM;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEEDIVNM].CellActivation = Activation.NoEdit;
			
			// 部門コード
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
			
			// 部門名称
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].Width = WIDTH_SALESTARGET_SUBSECTIONNAME;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].Header.Caption = VIEW_SALESTARGET_SUBSECTIONNAME;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SUBSECTIONNAME].CellActivation = Activation.NoEdit;
			
			// 課コード
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
			
			// 課名称
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

			// 従業員コード
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].Width = WIDTH_SALESTARGET_EMPLOYEECODE;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].Header.Caption = VIEW_SALESTARGET_EMPLOYEECODE;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Employee_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEECODE].CellActivation = Activation.NoEdit;

			// 従業員名称
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
		/// グリッドレイアウト設定（商品）処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッドのレイアウト設定（商品）を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void InitializeLayout_Goods_uGrid()
		{
//----- ueno add---------- start 2007.11.21
			// 目標対比区分コード
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTCD].Hidden = true;

			// 目標対比区分名称
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

			// メーカーコード
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

			// メーカー名称
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].Width = WIDTH_SALESTARGET_MAKERNAME;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].Header.Caption = VIEW_SALESTARGET_MAKERNAME;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Goods_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_MAKERNAME].CellActivation = Activation.NoEdit;

			// 商品コード
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

			// 商品名称
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
		///// グリッドレイアウト設定（売上形式）処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: グリッドのレイアウト設定（売上形式）を行います。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void InitializeLayout_SalesFormal_uGrid()
		//{
		//    // 売上形式コード
		//    this.SalesFormal_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMALCODE].Hidden = true;

		//    // 売上形式
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
		///// グリッドレイアウト設定（販売形態）処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: グリッドのレイアウト設定（販売形態）を行います。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private void InitializeLayout_SalesForm_uGrid()
		//{
		//    // 販売形態コード
		//    this.SalesForm_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMCODE].Hidden = true;

		//    // 販売形態名称
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
		/// グリッドレイアウト設定（得意先）処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: グリッドのレイアウト設定（得意先）を行います。</br>
		/// <br>Programmer	: 30167</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void InitializeLayout_Customer_uGrid()
		{
			// 目標対比区分コード
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTCD].Hidden = true;

			// 目標対比区分名称
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Width = WIDTH_SALESTARGET_TARGETCONSTRASTNM;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Caption = VIEW_SALESTARGET_TARGETCONSTRASTNM;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETCONSTRASTNM].CellActivation = Activation.NoEdit;

			// 得意先コード
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
			
			// 得意先名称
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].Width = WIDTH_SALESTARGET_CUSTOMERNAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].Header.Caption = VIEW_SALESTARGET_CUSTOMERNAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMERNAME].CellActivation = Activation.NoEdit;

			// 業種コード
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

			// 業種名称
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].RowLayoutColumnInfo.AllowLabelSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].RowLayoutColumnInfo.AllowCellSizing = RowLayoutSizing.Horizontal;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].Width = WIDTH_SALESTARGET_BUSINESSTYPENAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].Header.Caption = VIEW_SALESTARGET_BUSINESSTYPENAME;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Customer_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_BUSINESSTYPENAME].CellActivation = Activation.NoEdit;

			// 販売エリアコード
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
			
			// 販売エリア名称
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
		/// 検索条件チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 検索条件の入力チェックを行います。</br>
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
					errMsg = "目標区分コードを入力してください";
					this.TargetDivideCode_tEdit.Focus();
					return (false);
				}
				// 月間目標
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
				{
					targetDivideCode = this.TargetDivideCode_tEdit.DataText.TrimEnd();
					if (targetDivideCode.Length != 6)
					{
						errMsg = "月間目標は、目標区分コードを年月の形で入力してください\nex.2007年1月の場合→200701";
						this.TargetDivideCode_tEdit.Focus();
						return (false);
					}


                    if (targetDivideCode == "000101")
                    {
                        errMsg = "目標区分コードを正しく設定してください";
                        this.TargetDivideCode_tEdit.Focus();
                        return (false);
                    }
                    //int num;
                    //if (!int.TryParse(targetDivideCode, out num))
                    //{
                    //    errMsg = "月間目標は、目標区分コードを年月の形で入力してください\nex.2007年1月の場合→200701";
                    //    this.TargetDivideCode_tEdit.Focus();
                    //    return (false);
                    //}

                    //month = int.Parse(targetDivideCode.Substring(4, 2));
                    //if (month < 1 || month > 12)
                    //{
                    //    errMsg = "月間目標は、目標区分コードを年月の形で入力してください\nex.2007年1月の場合→200701";
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
                            errMsg = "月間目標は、目標区分コードを年月の形で入力してください\nex.2007年1月の場合→200701";
                            this.TargetDivideCode_tEdit.Focus();
                            return (false);
                        }
                        result = CheckNum(month.ToCharArray());
                        if (!result)
                        {
                            errMsg = "月間目標は、目標区分コードを年月の形で入力してください\nex.2007年1月の場合→200701";
                            this.TargetDivideCode_tEdit.Focus();
                            return (false);
                        }
                        DateTime targetDate = new DateTime(int.Parse(year), int.Parse(month), 1);

                        if (targetDate.Year < 1900)
                        {
                            errMsg = "目標区分コードを正しく設定してください";
                            this.TargetDivideCode_tEdit.Focus();
                            return (false);
                        }
                    }
                    catch
                    {
                        errMsg = "月間目標は、目標区分コードを年月の形で入力してください\nex.2007年1月の場合→200701";
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
							this, 							// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO, 	// エラーレベル
							this.Name,						// アセンブリID
							errMsg, 						// 表示するメッセージ
							0,								// ステータス値
							MessageBoxButtons.OK);			// 表示するボタン
				}
			}

			// 月間目標
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
        /// 数値変換チェック
        /// </summary>
        /// <param name="str">チェック文字列</param>
        /// <returns>True:数値変換可能(数値のみ)、False:数値変換不可</returns>
        /// <remarks>
        /// <br>Note		: 数値変換可能かチェックします。</br>
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
		/// 検索条件設定処理
		/// </summary>
        /// <param name="extrInfo">検索条件</param>
		/// <remarks>
		/// <br>Note		: 検索条件の設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void GetExtrInfo(out ExtrInfo_MAMOK09197EA extrInfo)
		{
			extrInfo = new ExtrInfo_MAMOK09197EA();

			// 企業コード
			extrInfo.EnterpriseCode = this._enterpriseCode;
			// 拠点コード
			extrInfo.SelectSectCd = new string[1];
			extrInfo.SelectSectCd[0] = this._sectionCode;
			// 目標設定区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            extrInfo.TargetSetCd = int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            //extrInfo.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			// 目標区分コード
			extrInfo.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
			// 目標区分名称
			extrInfo.TargetDivideName = this.TargetDivideName_tEdit.DataText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ検索処理
		/// </summary>
        /// <param name="salesTargetList">目標データリスト</param>
        /// <param name="extrInfo">検索条件</param>
		/// <remarks>
		/// <br>Note		: 目標データを検索します。</br>
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
					TMsgDisp.Show(this, 						// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						this.Name,								// アセンブリID
						ctPGNM, 			 　　				// プログラム名称
						"Search",								// 処理名称
						TMsgDisp.OPE_GET,						// オペレーション
						"目標データの読み込みに失敗しました", // 表示するメッセージ
						status,									// ステータス値
						this._salesTargetAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					return (false);
			}
			return (true);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 拠点目標データ検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 拠点目標データを設定します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool SearchSectionTarget()
		{
			ExtrInfo_MAMOK09197EA extrInfo;

			// 検索条件設定
			GetExtrInfo(out extrInfo);
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;

			// 目標データ検索
			bool bStatus = SearchSalesTarget(out this._sectionSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 従業員目標データ検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 従業員目標データを設定します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool SearchEmployeeTarget()
		{
			ExtrInfo_MAMOK09197EA extrInfo;

			// 検索条件設定
			GetExtrInfo(out extrInfo);
			//----- ueno upd---------- start 2007.11.21
			// 任意の従業員目標対比区分を設定
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
			//----- ueno upd---------- end   2007.11.21

			// 目標データ検索
			bool bStatus = SearchSalesTarget(out this._employeeSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 商品目標データ検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 商品目標データを設定します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool SearchGoodsTarget()
		{
			ExtrInfo_MAMOK09197EA extrInfo;

			// 検索条件設定
			GetExtrInfo(out extrInfo);
			//----- ueno upd---------- start 2007.11.21
			// 任意の商品目標対比区分を設定
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods;
            extrInfo.TargetContrastCd = this._goodsTargetConstrastCd;

            //↑これのせいで一覧に何も出ない！！！！！！！
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

			// 目標データ検索
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
		///// 売上形式目標データ検索処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 売上形式目標データを設定します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool SearchSalesFormalTarget()
		//{
		//    ExtrInfo_MAMOK09197EA extrInfo;

		//    // 検索条件設定
		//    GetExtrInfo(out extrInfo);
		//    extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;

		//    // 目標データ検索
		//    bool bStatus = SearchSalesTarget(out this._salesFormalSalesTargetList, extrInfo);
		//    if (!bStatus)
		//    {
		//        return (false);
		//    }

		//    return (true);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 販売形態目標データ検索処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 販売形態目標データを設定します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool SearchSalesFormTarget()
		//{
		//    ExtrInfo_MAMOK09197EA extrInfo;

		//    // 検索条件設定
		//    GetExtrInfo(out extrInfo);
		//    extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;

		//    // 目標データ検索
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
		/// 得意先目標データ検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 得意先目標データを設定します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private bool SearchCustomerTarget()
		{
			ExtrInfo_MAMOK09197EA extrInfo;

			// 検索条件設定
			GetExtrInfo(out extrInfo);
			// 任意の得意先目標対比区分を設定
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;

			// 目標データ検索
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
		/// 目標データ新規作成処理
		/// </summary>
        /// <param name="salesTarget">目標データ</param>
        /// <param name="searchFlag">検索フラグ</param>
		/// <remarks>
		/// <br>Note		: 目標データを新規に作成します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void CreateSalesTarget(out SalesTarget salesTarget, bool searchFlag)
		{
			salesTarget = new SalesTarget();

			// 企業コード
			salesTarget.EnterpriseCode = this._enterpriseCode;
			// 拠点
			salesTarget.SectionCode = this._sectionCode;

			if (searchFlag == true)
			{
				// 月間目標
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
				{
					// 適用期間（開始）
					salesTarget.ApplyStaDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), 1);
					// 適用期間（終了）
					int days = DateTime.DaysInMonth(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth());
					salesTarget.ApplyEndDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), days);
				}
				// 個別目標
				else
				{
					// 適用期間（開始）
					salesTarget.ApplyStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
					// 適用期間（終了）
					salesTarget.ApplyEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();
				}

				// 目標区分コード
				salesTarget.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
				// 目標区分名称
				salesTarget.TargetDivideName = this.TargetDivideName_tEdit.DataText;

			}
			else
			{
				// 適用期間（開始）
				salesTarget.ApplyStaDate = new DateTime();
				// 適用期間（終了）
				salesTarget.ApplyEndDate = new DateTime();
				// 適用期間（開始）
				salesTarget.ApplyStaDate = new DateTime();
				// 適用期間（終了）
				salesTarget.ApplyEndDate = new DateTime();

				// 目標区分コード
				salesTarget.TargetDivideCode = "";
				// 目標区分名称
				salesTarget.TargetDivideName = "";

			}
			// 目標設定区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            salesTarget.TargetSetCd = int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            //salesTarget.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
            //// 平日比率
            //salesTarget.WeekdayRatio = RATIO;
            //// 土日比率
            //salesTarget.SatSunRatio = RATIO;
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// 比率計算結果表示処理（日別）
		///// </summary>
		///// <param name="uGrid">グリッド</param>
		///// <remarks>
		///// <br>Note		: 比率から目標（日別）を計算し表示します。</br>
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
		//            // 比率計算
		//            SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//                out salesTargetDayOfWeek,
		//                salesTarget,
		//                0,
		//                targetDateSt,
		//                targetDateEd,
		//                this._sectionCode,
		//                this._ldgCalcRatioMngList,
		//                this._holidaySettingDic);

		//            // 日曜売上
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_SUNDAY].Value = salesTargetDayOfWeek[0];
		//            // 月曜売上
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_MONDAY].Value = salesTargetDayOfWeek[1];
		//            // 火曜売上
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_TUESDAY].Value = salesTargetDayOfWeek[2];
		//            // 水曜売上
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_WEDNESDAY].Value = salesTargetDayOfWeek[3];
		//            // 木曜売上
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_THURSDAY].Value = salesTargetDayOfWeek[4];
		//            // 金曜売上
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_FRIDAY].Value = salesTargetDayOfWeek[5];
		//            // 土曜売上
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_SATURDAY].Value = salesTargetDayOfWeek[6];
		//            // 祝祭日売上
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_MONEY_HOLIDAY].Value = salesTargetDayOfWeek[7];
		//        }

		//        if (uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT].Text != "")
		//        {
		//            salesTarget = double.Parse(uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT].Text);
		//            // 比率計算
		//            SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//                out salesTargetDayOfWeek,
		//                salesTarget,
		//                0,
		//                targetDateSt,
		//                targetDateEd,
		//                this._sectionCode,
		//                this._ldgCalcRatioMngList,
		//                this._holidaySettingDic);

		//            // 日曜粗利
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_SUNDAY].Value = salesTargetDayOfWeek[0];
		//            // 月曜粗利
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_MONDAY].Value = salesTargetDayOfWeek[1];
		//            // 火曜粗利
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_TUESWDAY].Value = salesTargetDayOfWeek[2];
		//            // 水曜粗利
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_WEDNESDAY].Value = salesTargetDayOfWeek[3];
		//            // 木曜粗利
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_THURSDAY].Value = salesTargetDayOfWeek[4];
		//            // 金曜粗利
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_FRIDAY].Value = salesTargetDayOfWeek[5];
		//            // 土曜粗利
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_SATURDAY].Value = salesTargetDayOfWeek[6];
		//            // 祝祭日粗利
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_PROFIT_HOLIDAY].Value = salesTargetDayOfWeek[7];
		//        }

		//        if (uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT].Text != "")
		//        {
		//            salesTarget = double.Parse(uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT].Text);
		//            // 比率計算
		//            SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//                out salesTargetDayOfWeek,
		//                salesTarget,
		//                1,
		//                targetDateSt,
		//                targetDateEd,
		//                this._sectionCode,
		//                this._ldgCalcRatioMngList,
		//                this._holidaySettingDic);

		//            // 日曜数量
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_SUNDAY].Value = salesTargetDayOfWeek[0];
		//            // 月曜数量
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_MONDAY].Value = salesTargetDayOfWeek[1];
		//            // 火曜数量
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_TUESDAY].Value = salesTargetDayOfWeek[2];
		//            // 水曜数量
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_WEDNESDAY].Value = salesTargetDayOfWeek[3];
		//            // 木曜数量
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_THURSDAY].Value = salesTargetDayOfWeek[4];
		//            // 金曜数量
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_FRIDAY].Value = salesTargetDayOfWeek[5];
		//            // 土曜数量
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_SATURDAY].Value = salesTargetDayOfWeek[6];
		//            // 祝祭日数量
		//            uGrid.Rows[index].Cells[COL_SALESTARGET_COUNT_HOLIDAY].Value = salesTargetDayOfWeek[7];
		//        }
		//    }
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 目標データ合計計算処理
		/// </summary>
        /// <param name="uGrid">グリッド</param>
		/// <remarks>
		/// <br>Note		: 目標データの合計を計算します。</br>
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
		/// 目標データ新規作成処理
		/// </summary>
        /// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// <br>Note		: 目標データを新規作成します。</br>
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
					// 拠点目標
					bStatus = ShowSectionTarget(ref salesTarget);
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 1:
					// 従業員目標
					bStatus = ShowEmployeeTarget(ref salesTarget);
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 2:
					// 商品目標
					bStatus = ShowGoodsTarget(ref salesTarget);
					if (!bStatus)
					{
						return (false);
					}
					break;

//----- ueno add---------- start 2007.11.21
				case 3:
					// 得意先目標
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
				//    // 売上形式目標
				//    bStatus = ShowSalesFormalTarget(ref salesTarget);
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				//case 4:
				//    // 販売形態目標
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
		/// 拠点目標入力画面表示処理
		/// </summary>
        /// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// <br>Note		: 新規拠点目標の入力画面を表示します。</br>
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
		/// 従業員目標入力画面表示処理
		/// </summary>
        /// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// <br>Note		: 新規従業員目標の入力画面を表示します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool ShowEmployeeTarget(ref SalesTarget salesTarget)
		{
			MAMOK09110UA employeeTarget = new MAMOK09110UA();
			//----- ueno upd---------- start 2007.11.21
			// 目標対比区分設定（0:検索前新規, 0以外:検索後新規）
			if (this._empTargetConstrastCd == 0)
			{
				// 検索前新規時はデフォルト設定
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
		/// 商品目標入力画面表示処理
		/// </summary>
        /// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// <br>Note		: 新規商品目標の入力画面を表示します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool ShowGoodsTarget(ref SalesTarget salesTarget)
		{
			MAMOK09130UA goodsTarget = new MAMOK09130UA();

			//----- ueno upd---------- start 2007.11.21
			// 目標対比区分設定（0:検索前新規, 0以外:検索後新規）
			if (this._goodsTargetConstrastCd == 0)
			{
				// 検索前新規時はデフォルト設定
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
		///// 売上形式目標入力画面表示処理
		///// </summary>
		///// <param name="salesTarget">目標データ</param>
		///// <remarks>
		///// <br>Note		: 新規売上形式目標の入力画面を表示します。</br>
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
		///// 販売形態目標入力画面表示処理
		///// </summary>
		///// <param name="salesTarget">目標データ</param>
		///// <remarks>
		///// <br>Note		: 新規販売形態目標の入力画面を表示します。</br>
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
		/// 得意先目標入力画面表示処理
		/// </summary>
		/// <param name="salesTarget">目標データ</param>
		/// <remarks>
		/// <br>Note		: 新規得意先目標の入力画面を表示します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private bool ShowCustomerTarget(ref SalesTarget salesTarget)
		{
			DCKHN09190UA customerTarget = new DCKHN09190UA();

			// 目標対比区分設定（0:検索前新規, 0以外:検索後新規）
			if (this._custTargetConstrastCd == 0)
			{
				// 検索前新規時はデフォルト設定
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
		/// 拠点目標参照画面表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 拠点目標の参照画面を表示します。</br>
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
		/// 詳細目標編集前処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択された詳細目標データを編集します。</br>
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
				// 合計行だった場合
				if ((this._uGrid.ActiveRow.Index + 1) == this._uGrid.Rows.Count)
				{
					return;
				}
			}
			// アクティブ行取得
			SetBeforeActiveRow();

            int scrollRegionPosition = this._uGrid.DisplayLayout.RowScrollRegions[0].ScrollPosition;

			// 詳細目標編集
			bool bStatus = EditSalesTarget();
			if (!bStatus)
			{
				return;
			}

			//----- ueno del---------- start 2007.11.21
			//// マスタテーブル読み込み
			//int status = LoadMasterTable();
			//if (status != 0)
			//{
			//    return;
			//}
			//----- ueno del---------- end   2007.11.21

			// 詳細目標データ検索
			bStatus = SearchAllSalesTarget();
			if (!bStatus)
			{
				return;
			}

			// 画面表示
			DispScreen();

            // スクロールバーの位置設定
            this._uGrid.DisplayLayout.RowScrollRegions[0].ScrollPosition = scrollRegionPosition;

			// コントロール制御
			SetControlEnabled();

			// アクティブ行設定
			SetActiveRow();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 詳細目標編集処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択された詳細目標データを編集します。</br>
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
					// 拠点目標
					bStatus = EditSectionTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 1:
					// 従業員目標
					bStatus = EditEmployeeTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 2:
					// 商品目標
					bStatus = EditGoodsTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
//----- ueno add---------- start 2007.11.21
				case 3:
					// 得意先目標
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
				//    // 売上形式目標
				//    bStatus = EditSalesFormalTarget();
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				//case 4:
				//    // 販売形態目標
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
		/// 拠点目標編集画面表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 拠点目標の編集画面を表示します。</br>
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
		/// 従業員目標編集画面表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 従業員目標の編集画面を表示します。</br>
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
				// 選択グリッド判定
				//   目標対比区分, 従業員区分コード, 部門コード, 課コード, 従業員コードが一致した場合
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
		/// 商品目標編集画面表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 商品目標の編集画面を表示します。</br>
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
				
				// 選択グリッド判定
				//   目標対比区分, メーカーコード, 商品コードが一致した場合
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
		///// 売上形式目標編集画面表示処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 売上形式目標の編集画面を表示します。</br>
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
		///// 販売形態目標編集画面表示処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 販売形態目標の編集画面を表示します。</br>
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
		/// 得意先目標編集画面表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 得意先目標の編集画面を表示します。</br>
		/// <br>Programmer	: 30167	上野　弘貴</br>
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
				// 選択グリッド判定
				//   目標対比区分, 業種コード, 販売エリアコード, 得意先コードが一致した場合
				if ((salesTarget.TargetContrastCd	== (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETCONSTRASTCD].Value)
					&&(salesTarget.BusinessTypeCode == (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_BUSINESSTYPECODE].Value)
					&&(salesTarget.SalesAreaCode	== (int)this.Customer_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESAREACODE].Value)
					&& (salesTarget.CustomerCode	== this._customerCode))
				{
					DCKHN09190UA customerTarget = new DCKHN09190UA();

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                    int BUSINESS_TYPE_GUIDE = 33;   // 業種コード
                    int SALES_AREA_GUIDE = 21;      // 販売エリア

                    // 業種名を取得
                    UserGdBd userGuideBdInfo;
                    int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, BUSINESS_TYPE_GUIDE, salesTarget.BusinessTypeCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesTarget.BusinessTypeName = userGuideBdInfo.GuideName;
                    }

                    // 販売エリア名を取得
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
		/// 目標データ削除処理
		/// </summary>
        /// <param name="salesTargetList">目標データリスト</param>
		/// <remarks>
		/// <br>Note		: 目標データを削除します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private bool DeleteSalesTarget(List<SalesTarget> salesTargetList)
		{
			// 目標データ更新
			int status = this._salesTargetAcs.Delete(salesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // エラーレベル
                        this.Name,								    // アセンブリID
                        "既に他端末より更新されています",           // 表示するメッセージ
                        status,									    // ステータス値
                        MessageBoxButtons.OK);					    // 表示するボタン
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // エラーレベル
                        this.Name,								    // アセンブリID
                        "既に他端末より削除されています",		    // 表示するメッセージ
                        status,									    // ステータス値
                        MessageBoxButtons.OK);					    // 表示するボタン
                    return (false);
                default:
                    TMsgDisp.Show(
                        this, 						                // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,			    // エラーレベル
                        this.Name,								    // アセンブリID
                        ctPGNM, 		  　　					    // プログラム名称
                        "DeleteSalesTarget",						            // 処理名称
                        TMsgDisp.OPE_DELETE,					    // オペレーション
                        "目標データ削除時にエラーが発生しました",	// 表示するメッセージ
                        status,									    // ステータス値
                        this._salesTargetAcs,					    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,			  		    // 表示するボタン
                        MessageBoxDefaultButton.Button1);		    // 初期表示ボタン
                    return (false);
            }

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 詳細目標削除前処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択された詳細目標データを削除します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private bool BeforeDeleteSalesTarget()
		{
			bool bStatus;
            switch (this.CustomerTarget_uTabControl.SelectedTab.Index)
			{
				case 0:
					// 拠点目標
					bStatus = DeleteSectionTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 1:
					// 従業員目標
					bStatus = DeleteEmployeeTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
				case 2:
					// 商品目標
					bStatus = DeleteGoodsTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
//----- ueno add---------- start 2007.11.21
				case 3:
					// 得意先目標
					bStatus = DeleteCustomerTarget();
					if (!bStatus)
					{
						return (false);
					}
					break;
//----- ueno add---------- end   2007.11.21
				//----- ueno del---------- start 2007.11.21
				//case 3:
				//    // 売上形式目標
				//    bStatus = DeleteSalesFormalTarget();
				//    if (!bStatus)
				//    {
				//        return (false);
				//    }
				//    break;
				//case 4:
				//    // 販売形態目標
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
		/// 拠点目標削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択した拠点目標を削除します。</br>
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

			// 月間目標
			if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				msg = this.ApplyStaDate_tDateEdit.GetDateYear().ToString() + "年" +
					this.ApplyStaDate_tDateEdit.GetDateMonth().ToString() + "月" +
					"の拠点目標を削除しますが、よろしいですか？";
			}
			// 個別期間目標
			else
			{
				msg = this.TargetDivideName_tEdit.DataText.TrimEnd() + "[" + this.TargetDivideCode_tEdit.DataText.TrimEnd() + "]" +
					"の拠点目標を削除しますが、よろしいですか？";
			}

			// 画面情報が変更されていた場合は、保存確認メッセージを表示
			DialogResult res = TMsgDisp.Show(this,									// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO, 										// エラーレベル
				this.Name, 															// アセンブリＩＤ
				msg,																// 表示するメッセージ
				0, 																	// ステータス値
				MessageBoxButtons.OKCancel);										// 表示するボタン

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

						// 拠点目標削除
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
		/// 従業員目標削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択した従業員目標を削除します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool DeleteEmployeeTarget()
		{
			if (this.Employee_uGrid.ActiveRow == null)
			{
				return (false);
			}

			// 画面情報が変更されていた場合は、保存確認メッセージを表示
			DialogResult res = TMsgDisp.Show(this,																	 // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO, 																		 // エラーレベル
				this.Name, 																							 // アセンブリＩＤ
				//----- ueno upd---------- start 2007.11.21
				"選択された目標を削除します。よろしいですか？",
				//this._employeeName + "さん" + "[" + this._employeeCode.TrimEnd() + "]" + " の目標を削除しますが、よろしいですか？", // 表示するメッセージ										  // 表示するメッセージ
				//----- ueno upd---------- end   2007.11.21
				0, 																									 // ステータス値
				MessageBoxButtons.OKCancel);																		 // 表示するボタン

			switch (res)
			{
				case DialogResult.OK:
					{
						List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
						SalesTarget deleteSalesTarget = null;

						//----- ueno upd---------- start 2007.11.21
						//----- キー項目全てが一致したら該当データとする
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

						// 従業員目標削除
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
		/// 商品目標削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択した商品目標を削除します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private bool DeleteGoodsTarget()
		{
			if (this.Goods_uGrid.ActiveRow == null)
			{
				return (false);
			}

			// 画面情報が変更されていた場合は、保存確認メッセージを表示
			DialogResult res = TMsgDisp.Show(this,															   // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO, 																   // エラーレベル
				this.Name, 																					   // アセンブリＩＤ
				//----- ueno upd---------- start 2007.11.21
				"選択された目標を削除します。よろしいですか？",
				//this._goodsName + "[" + this._goodsCode.TrimEnd() + "]" + " の目標を削除しますが、よろしいですか？", // 表示するメッセージ										  // 表示するメッセージ
				//----- ueno upd---------- end   2007.11.21
				0, 																							   // ステータス値
				MessageBoxButtons.OKCancel);																   // 表示するボタン

			switch (res)
			{
				case DialogResult.OK:
					{
                        List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
						SalesTarget deleteSalesTarget = null;

						//----- ueno upd---------- start 2007.11.21
						//----- キー項目全てが一致したら該当データとする
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

						// 商品目標削除
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
		///// 売上形式目標削除処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 選択した売上形式目標を削除します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool DeleteSalesFormalTarget()
		//{
		//    if (this.SalesFormal_uGrid.ActiveRow == null)
		//    {
		//        return (false);
		//    }

		//    // 画面情報が変更されていた場合は、保存確認メッセージを表示
		//    DialogResult res = TMsgDisp.Show(this,								  // 親ウィンドウフォーム
		//        emErrorLevel.ERR_LEVEL_INFO, 									  // エラーレベル
		//        this.Name, 														  // アセンブリＩＤ
		//        "売上形式[" + this._salesFormalName + "]の目標を削除しますが、よろしいですか？", // 表示するメッセージ										  // 表示するメッセージ
		//        0, 																  // ステータス値
		//        MessageBoxButtons.OKCancel);									  // 表示するボタン

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

		//                // 売上形式目標削除
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
		///// 販売形態目標削除処理
		///// </summary>
		///// <remarks>
		///// <br>Note		: 選択した販売形態目標を削除します。</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.11</br>
		///// </remarks>
		//private bool DeleteSalesFormTarget()
		//{
		//    if (this.SalesForm_uGrid.ActiveRow == null)
		//    {
		//        return (false);
		//    }

		//    // 保存確認メッセージを表示
		//    DialogResult res = TMsgDisp.Show(this,								// 親ウィンドウフォーム
		//        emErrorLevel.ERR_LEVEL_INFO, 									// エラーレベル
		//        this.Name, 														// アセンブリＩＤ
		//        "販売形態[" + this._salesFormName + "]の目標を削除しますが、よろしいですか？", // 表示するメッセージ
		//        0, 																// ステータス値
		//        MessageBoxButtons.OKCancel);									// 表示するボタン

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

		//                // 販売形態目標削除
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
		/// 得意先目標削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 選択した従業員目標を削除します。</br>
		/// <br>Programmer	: 30167 上野　弘貴</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private bool DeleteCustomerTarget()
		{
			if (this.Customer_uGrid.ActiveRow == null)
			{
				return (false);
			}

			// 画面情報が変更されていた場合は、保存確認メッセージを表示
			DialogResult res = TMsgDisp.Show(this,																	 // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO, 																		 // エラーレベル
				this.Name, 																							 // アセンブリＩＤ
				"選択された目標を削除します。よろしいですか？",
				//this._customerName + "さん" + "[" + this._customerCode + "]" + " の目標を削除しますが、よろしいですか？", // 表示するメッセージ										  // 表示するメッセージ
				0, 																									 // ステータス値
				MessageBoxButtons.OKCancel);																		 // 表示するボタン

			switch (res)
			{
				case DialogResult.OK:
					{
						List<SalesTarget> deleteSalesTargetList = new List<SalesTarget>();
						SalesTarget deleteSalesTarget = null;

						//----- キー項目全てが一致したら該当データとする
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

						// 得意先目標削除
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
		/// 目標検索処理
		/// </summary>
        /// <param name="targetDivideCode">目標区分コード</param>
        /// <param name="salesTargetList">目標データリスト</param>
		/// <remarks>
		/// <br>Note		: 目標を検索します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.19</br>
		/// </remarks>
		private bool SearchTarget(string targetDivideCode, out List<SalesTarget> salesTargetList)
		{
			SalesTargetAcs salesTargetAcs = new SalesTargetAcs();
			salesTargetList = new List<SalesTarget>();
			ExtrInfo_MAMOK09197EA extrInfo = new ExtrInfo_MAMOK09197EA();

			// 企業コード
			extrInfo.EnterpriseCode = this._enterpriseCode;
			// 拠点コード
			extrInfo.SelectSectCd = new string[1];
			extrInfo.SelectSectCd[0] = this._sectionCode;
			// 目標設定区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//extrInfo.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
            extrInfo.TargetSetCd = int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			// 適用開始日（開始）
			extrInfo.ApplyStaDateSt = new DateTime();
			// 適用開始日（終了）
			extrInfo.ApplyStaDateEd = new DateTime();
			// 適用終了日（開始）
			extrInfo.ApplyEndDateSt = new DateTime();
			// 適用終了日（終了）
			extrInfo.ApplyEndDateEd = new DateTime();
			// 目標区分コード
			extrInfo.TargetDivideCode = targetDivideCode;

			// 目標対比区分(拠点)
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			if (salesTargetList.Count > 0)
			{
				return (true);
			}

			// 目標対比区分(従業員)
			//----- ueno upd---------- start 2007.11.21
			// 任意の従業員目標対比区分を設定
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
			//----- ueno upd---------- end   2007.11.21

			salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			if (salesTargetList.Count > 0)
			{
				return (true);
			}

			// 目標対比区分(商品)
			//----- ueno upd---------- start 2007.11.21
			// 任意の商品目標対比区分を設定
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods;
			//----- ueno upd---------- end   2007.11.21

			salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			if (salesTargetList.Count > 0)
			{
				return (true);
			}

//----- ueno add---------- start 2007.11.21

			// 目標対比区分(得意先)
			// 任意の得意先目標対比区分を設定
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;

			salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			if (salesTargetList.Count > 0)
			{
				return (true);
			}
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			#region del
			//// 目標対比区分(売上形式)
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
			//salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			//if (salesTargetList.Count > 0)
			//{
			//    return (true);
			//}

			//// 目標対比区分(販売形態)
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
					"目標区分コード [" + targetDivideCode + "] に該当するデータが存在しません",
					-1,
					MessageBoxButtons.OK);
			return (false);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 詳細目標検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 詳細目標を検索します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.20</br>
		/// </remarks>
		private bool SearchAllSalesTarget()
		{
			// 検索条件チェック処理
			bool status = CheckSearchCondition();
			if (!status)
			{
				return (false);
			}

			// 個別期間目標の場合は目標区分コードチェック
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

			// 拠点目標データ検索
			status = SearchSectionTarget();
			if (!status)
			{
				return (false);
			}

			// 従業員目標データ検索
			status = SearchEmployeeTarget();
			if (!status)
			{
				return (false);
			}

			// 商品目標データ検索
			status = SearchGoodsTarget();
			if (!status)
			{
				return (false);
			}

//----- ueno add---------- start 2007.11.21
			// 得意先目標データ検索
			status = SearchCustomerTarget();
			if (!status)
			{
				return (false);
			}
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			#region del
			//// 売上形式目標データ検索
			//status = SearchSalesFormalTarget();
			//if (!status)
			//{
			//    return (false);
			//}

			//// 販売形態目標データ検索
			//status = SearchSalesFormTarget();
			//if (!status)
			//{
			//    return (false);
			//}
			#endregion del
			//----- ueno del---------- end   2007.11.21

            // 検索フラグ
            this._searchFlag = true;


			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 目標データを画面に表示します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.20</br>
		/// </remarks>
		private void DispScreen()
		{
			// 画面表示
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

			// グリッドスタイル設定
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
				//// 比率計算
				//CalcFromRatioSalesDay(this.Section_uGrid);
				//CalcFromRatioSalesDay(this.Employee_uGrid);
				//CalcFromRatioSalesDay(this.Goods_uGrid);
				//CalcFromRatioSalesDay(this.SalesFormal_uGrid);
				//CalcFromRatioSalesDay(this.SalesForm_uGrid);
				//----- ueno del---------- end   2007.11.21

				// 合計計算
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
		/// 画面情報クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面情報をクリアします。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.13</br>
		/// </remarks>
		private void ClearScreen()
		{
			// 検索フラグ
			this._searchFlag = false;

			// コントロールサイズ設定
			SetControlSize();

			// コントロール入力桁数設定
			SetNumberOfControlChar();

			this.TargetDivideCode_tEdit.DataText = "";
			this.TargetDivideName_tEdit.DataText = "";
			this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());

			// 目標データ初期化
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

			// 画面表示
			DispScreen();

			// コントロール制御
			SetControlEnabled();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 全目標データ検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 全目標データを検索します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
        //private void ShowAllSalesTarget()
        //{
        //    //// マスタテーブル読み込み
        //    //int status = LoadMasterTable();
        //    //if (status != 0)
        //    //{
        //    //    return;
        //    //}

        //    //// 詳細目標データ検索
        //    //bool bStatus = SearchAllSalesTarget();
        //    //if (!bStatus)
        //    //{
        //    //    return;
        //    //}

        //    //// 画面表示
        //    //DispScreen();

        //    //// コントロール制御
        //    //SetControlEnabled();
        //}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 編集前アクティブ行取得処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 編集前のアクティブ行を取得します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void SetBeforeActiveRow()
		{
			// 従業員目標
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
			// 商品目標
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
			// 得意先目標
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
			//// 売上形式目標
			//if (this.SalesFormal_uGrid.ActiveRow != null)
			//{
			//    this._salesFormalCode = (int)this.SalesFormal_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMALCODE].Value;
			//    this._salesFormalName = (string)this.SalesFormal_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMAL].Value;
			//}
			//// 販売形態目標
			//if (this.SalesForm_uGrid.ActiveRow != null)
			//{
			//    this._salesFormCode = (int)this.SalesForm_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORMCODE].Value;
			//    this._salesFormName = (string)this.SalesForm_uGrid.ActiveRow.Cells[COL_SALESTARGET_SALESFORM].Value;
			//}
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 編集後アクティブ行設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 編集後のアクティブ行を設定します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void SetActiveRow()
		{
			// Employee_uGrid (合計行はチェックしない)
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
			// Goods_uGrid (合計行はチェックしない)
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
			// Customer_uGrid (合計行はチェックしない)
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
			//// SalesFormal_uGrid (合計行はチェックしない)
			//for (int rowIndex = 0; rowIndex <= this.SalesFormal_uGrid.Rows.Count - 2; rowIndex++)
			//{
			//    if ((int)this.SalesFormal_uGrid.Rows[rowIndex].Cells[COL_SALESTARGET_SALESFORMALCODE].Value == this._salesFormalCode)
			//    {
			//        this.SalesFormal_uGrid.Rows[rowIndex].Activate();
			//        break;
			//    }
			//}
			//// SalesForm_uGrid (合計行はチェックしない)
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
		/// コントロール制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールの制御を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.20</br>
		/// </remarks>
		private void SetControlEnabled()
		{
			// 月間目標
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
			// 個別期間目標
			else
			{
				this.NewSection_Button.Visible = true;
				this.EditSection_Button.Visible = true;
				this.DeleteSection_Button.Visible = true;
				this.ReferSection_Button.Visible = false;
			}

			// 検索前
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
			// 検索後
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

				// 月間目標
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
				//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
				{
					this.Edit_Button.Enabled = false;
				}
				// 個別期間目標
				else
				{
					this.Edit_Button.Enabled = true;
				}
			}

			// 拠点目標
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
			// 従業員目標
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
			// 商品目標
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
			// 得意先目標
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
			//// 売上形式目標
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
			//// 販売形態目標
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
		/// コントロールサイズ設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールサイズの設定を行います。</br>
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
		/// コントロール入力桁数設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: コントロールの入力桁数の設定を行います。</br>
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
        /// グリッドフォントサイズ変更処理
        /// </summary>
        /// <param name="fontSize">フォントサイズ</param>
        /// <param name="cmbFontSize">変更対象フォントサイズリスト</param>
        /// <param name="uGrid">対象グリッド</param>
        /// <remarks>
        /// <br>Note		: グリッドのフォントサイズを変更します。</br>
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

            // ヘッダーの高さを自動調整
            uGrid.DisplayLayout.Bands[0].UseRowLayout = false;
            uGrid.DisplayLayout.Bands[0].UseRowLayout = true;
        }

//----- ueno add---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 部門名称取得処理
		/// </summary>
		/// <param name="subSectionCode">部門コード</param>
		/// <return>部門名称</return>
		/// <remarks>
		/// Note	   : 部門名称を取得します。<br />
		/// Programmer : 30167 上野　弘貴<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetSubSectionName(int subSectionCode)
		{
			SubSection subSection = null;
			string subSectionName = "";

			SubSectionAcs subSectionAcs = new SubSectionAcs();

			// データ存在チェック
			int ret = subSectionAcs.Read(out subSection, this._enterpriseCode, this._sectionCode, subSectionCode);
			if (ret == 0)
			{
				subSectionName = subSection.SubSectionName;
			}
			return subSectionName;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 課名称取得処理
		/// </summary>
		/// <param name="subSectionCode">部門コード</param>
		/// <param name="minSectionCode">課コード</param>
		/// <return>課名称</return>
		/// <remarks>
		/// Note	   : 課名称を取得します。<br />
		/// Programmer : 30167 上野　弘貴<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetMinSectionName(int subSectionCode, int minSectionCode)
		{
			MinSection minSection = null;
			string minSectionName = "";

			MinSectionAcs minSectionAcs = new MinSectionAcs();

			// データ存在チェック
			int ret = minSectionAcs.Read(out minSection, this._enterpriseCode, this._sectionCode, subSectionCode, minSectionCode);
			if (ret == 0)
			{
				minSectionName = minSection.MinSectionName;
			}
			return minSectionName;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 得意先名称取得処理
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <return>得意先名称</return>
		/// <remarks>
		/// Note	   : 得意先名称を取得します。<br />
		/// Programmer : 30167 上野　弘貴<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetCustomerName(int customerCode)
		{
			CustomerInfo customerInfo = null;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
			string customerName = "";

			// データ存在チェック
			int ret = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
							customerCode, out customerInfo);
			if (ret == 0)
			{
				customerName = customerInfo.Name;
			}
			return customerName;
		}

		/// <summary>
		/// ユーザーガイドマスタボディ部リスト取得処理
		/// </summary>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドマスタボディ部のリストを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
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
					"ユーザーガイド（ヘッダ）情報の取得に失敗しました。" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ユーザーガイドボディデータ設定処理
		/// </summary>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドボディデータを設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
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
		/// ユーザーガイド名称取得処理
		/// </summary>
		/// <param name="userGuideSList"></param>
		/// <param name="userGuideCode"></param>
		/// <remarks>
		/// <br>Note       : ユーザーガイドコードから名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
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
		/// Form_Load イベント処理(MAMOK01310UA)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームロード処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void MAMOK01310UA_Load(object sender, EventArgs e)
		{
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

            this.panel8.BackColor = Color.Blue;

			// 画面クリア
			ClearScreen();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//this.TargetSetCd_uOptionSet.Focus();
            this.TargetSetCd_tComboEditor.Focus();

            // 目標区分コードおよびガイドボタンは拠点を設定するまでEnabled=false
            this.TargetDivideCode_tEdit.Enabled = false;
            this.TargetGuide_Button.Enabled = false;

            // 拠点情報取得
            SecInfoSet secInfoSet;
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            if (secInfoSet != null)
            {
                // 画面上にセット
                this.SectionCode_tNedit.DataText = secInfoSet.SectionCode.TrimEnd();
                this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.TrimEnd();

                // プライベート変数にセット
                this._sectionCode = secInfoSet.SectionCode.TrimEnd();
                this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

                // 拠点コードがうまく取得できたら目標区分を使用可能にする
                this.TargetGuide_Button.Enabled = true;
                this.TargetDivideCode_tEdit.Enabled = true;
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

			// XMLデータ読込
			LoadStateXmlData();

			// メインフレームにツールバー設定通知
			if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
		}

        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 画面アクティブイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note	   : 画面がアクティブになったときのイベント処理です。</br>
		/// <br>Programer  : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		private void MAMOK01310UA_Activated(object sender, EventArgs e)
		{
			// メインフレームにツールバー設定通知
			if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(TargetGuide_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 検索ボタンをクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void Search_Button_Click(object sender, EventArgs e)
		{
			//----- ueno del---------- start 2007.11.21
			//// マスタテーブル読み込み
			//int status = LoadMasterTable();
			//if (status != 0)
			//{
			//    return;
			//}
			//----- ueno del---------- end   2007.11.21

            // 詳細目標データ検索
            bool bStatus = SearchAllSalesTarget();
            if (!bStatus)
            {
                return;
            }

            // 画面表示
            DispScreen();

            // コントロール制御
            SetControlEnabled();

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(TargetGuide_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 目標ガイドボタンをクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void TargetGuide_Button_Click(object sender, EventArgs e)
		{
			SalesTarget salesTarget;

			// 拠点選択フラグ
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
				// 月間目標
				if (salesTarget.TargetSetCd == 10)
				{
					this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
					this.ApplyEndDate_tDateEdit.Visible = false;
					this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate);
					this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate);
				}
				// 個別期間目標
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
				//// マスタテーブル読み込み
				//int status = LoadMasterTable();
				//if (status != 0)
				//{
				//    return;
				//}
				//----- ueno del---------- end   2007.11.21

                // 詳細目標データ検索
                bool bStatus = SearchAllSalesTarget();
                if (!bStatus)
                {
                    return;
                }

                // 画面表示
                DispScreen();

                // コントロール制御
                SetControlEnabled();

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Refer_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 参照ボタンをクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void ReferSection_Button_Click(object sender, EventArgs e)
		{
			// 詳細目標編集
			bool bStatus = ReferSectionTarget();
			if (!bStatus)
			{
				return;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(NewTarget_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 新規ボタンをクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void NewTarget_Button_Click(object sender, EventArgs e)
		{
			SalesTarget salesTarget;

			// 目標データ新規作成
			CreateSalesTarget(out salesTarget, this._searchFlag);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            salesTarget.SectionCode = this._sectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

			// アクティブ行取得
			SetBeforeActiveRow();

			// 新規目標データ作成
			bool bStatus = BeforeShowNewSalesTarget(salesTarget);
            //MessageBox.Show("新規目標データ作成 : " + bStatus.ToString());
			if (!bStatus)
			{
				return;
			}

			//----- ueno del---------- start 2007.11.21
			//// マスタテーブル読み込み
			//int status = LoadMasterTable();
			//if (status != 0)
			//{
			//    return;
			//}
			//----- ueno del---------- end   2007.11.21

            // 商品別からの情報は取得
            this._bLCode = salesTarget.BLCode;
            this._bLGroupCode = salesTarget.BLGroupCode;
            this._salesCode = salesTarget.SalesTypeCode;
            this._enterpriseGanreCode = salesTarget.ItemTypeCode;

            // 詳細目標データ検索
            bStatus = SearchAllSalesTarget();
            //MessageBox.Show("詳細目標データ検索 : " + bStatus.ToString());
            if (!bStatus)
            {
                return;
            }

            // 画面表示
            DispScreen();

            // コントロール制御
            SetControlEnabled();

			// アクティブ行設定
			SetActiveRow();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(Edit_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 編集ボタンをクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void Edit_Button_Click(object sender, EventArgs e)
		{
			// 目標データ取得
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

				// 詳細目標データ検索
				bool bStatus = SearchAllSalesTarget();
				if (!bStatus)
				{
					return;
				}

				// 画面表示
				DispScreen();

				// コントロール制御
				SetControlEnabled();

				// アクティブ行設定
				SetActiveRow();

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(EditTarget_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 編集ボタンをクリックされた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void EditTarget_Button_Click(object sender, EventArgs e)
		{
			// 目標データ編集前処理
			BeforeEditSalesTarget();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click イベント処理(DeleteTarget_Button)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 削除ボタンをクリックされた時に発生します。</br>
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
				// 合計行だった場合
				if ((this._uGrid.ActiveRow.Index + 1) == this._uGrid.Rows.Count)
				{
					return;
				}
			}

			// アクティブ行取得
			SetBeforeActiveRow();

			// 詳細目標削除
			bool bStatus = BeforeDeleteSalesTarget();
			if (!bStatus)
			{
				return;
			}

			// 画面表示
			DispScreen();

			// コントロール制御
			SetControlEnabled();

			// アクティブ行設定
			SetActiveRow();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// DoubleClickRow イベント処理(Grid)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッドの行をダブルクリックした時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void Grid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
		{
			if (e.Row.Index + 1 == this._uGrid.Rows.Count)
			{
				return;
			}

			// 月間目標
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			{
				if (this._uGrid == this.Section_uGrid)
				{
					// 拠点目標参照
					ReferSectionTarget();
				}
				else
				{
					// 目標データ編集前処理
					BeforeEditSalesTarget();
				}
			}
			// 個別期間目標
			else
			{
				// 目標データ編集前処理
				BeforeEditSalesTarget();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// SelectedTabChanged イベント処理(SalesTarget_uTabControl)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 選択タブが変更された時に発生します。</br>
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
					// 拠点目標
					this._uGrid = this.Section_uGrid;
					this._cmbFontSize = this.Section_cmbFontSize;
					this._uceAutoFitCol = this.Section_uceAutoFitCol;
                    break;
				case 1:
					// 従業員目標
					this._uGrid = this.Employee_uGrid;
					this._cmbFontSize = this.Employee_cmbFontSize;
					this._uceAutoFitCol = this.Employee_uceAutoFitCol;
					break;
				case 2:
					// 商品目標
					this._uGrid = this.Goods_uGrid;
					this._cmbFontSize = this.Goods_cmbFontSize;
					this._uceAutoFitCol = this.Goods_uceAutoFitCol;
					break;
//----- ueno add---------- start 2007.11.21
				case 3:
					// 得意先目標
					this._uGrid = this.Customer_uGrid;
					this._cmbFontSize = this.Customer_cmbFontSize;
					this._uceAutoFitCol = this.Customer_uceAutoFitCol;
					break;
//----- ueno add---------- end   2007.11.21
				//case 3:
				//    // 売上形式目標
				//    this._uGrid = this.SalesFormal_uGrid;
				//    this._cmbFontSize = this.SalesFormal_cmbFontSize;
				//    this._uceAutoFitCol = this.SalesFormal_uceAutoFitCol;
				//    break;
				//case 4:
				//    // 販売形態目標
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
		/// ValueChanged イベント処理(TargetDivideCode_uOptionSet)
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 目標設定区分のチェックを変更した時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		private void TargetDivideCode_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			// 月間目標
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
			//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
			{
				this.ApplyDate_uLabel.Text = "適用年月";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
				this.Range_uLabel.Visible = false;
				this.ApplyEndDate_tDateEdit.Visible = false;
			}
			// 個別目標
			else
			{
				this.ApplyDate_uLabel.Text = "適用期間";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
				this.Range_uLabel.Visible = true;
				this.ApplyEndDate_tDateEdit.Visible = true;
			}

			this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());
			this.TargetDivideCode_tEdit.DataText = "";
			this.TargetDivideName_tEdit.DataText = "";

			// コントロール制御
			SetControlEnabled();
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// AfterCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セルがアクティブになった後に発生します。</br>
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
        /// フォントサイズ変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォントサイズの値が変更された後に発生します。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.04.05</br>
        /// </remarks>
        private void cmbFontSize_ValueChanged(object sender, EventArgs e)
		{
            TComboEditor cmbFontSize = (TComboEditor)sender;
            int fontSize = (int)cmbFontSize.Value;

            // 拠点目標グリッド
            ChangeFontSize(fontSize, ref cmbFontSize, ref this.Section_uGrid);
            // 従業員目標グリッド
            ChangeFontSize(fontSize, ref cmbFontSize, ref this.Employee_uGrid);
            // 商品目標グリッド
            ChangeFontSize(fontSize, ref cmbFontSize, ref this.Goods_uGrid);
//----- ueno add---------- start 2007.11.21
			// 得意先目標グリッド
			ChangeFontSize(fontSize, ref cmbFontSize, ref this.Customer_uGrid);
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//// 売上形式目標グリッド
			//ChangeFontSize(fontSize, ref cmbFontSize, ref this.SalesFormal_uGrid);
			//// 販売形態目標グリッド
			//ChangeFontSize(fontSize, ref cmbFontSize, ref this.SalesForm_uGrid);
			//----- ueno del---------- end   2007.11.21

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 列サイズの自動調整チェックチェンジイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: チェックボックスのチェック状態が変更されたタイミングで発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void uceAutoFitCol_CheckedChanged(object sender, EventArgs e)
		{
            UltraCheckEditor uceAutoFitCol = (UltraCheckEditor)sender;

			if (this._uGrid.DataSource != null)
			{
                // チェック有り
                if (uceAutoFitCol.Checked)
				{
					// 拠点目標グリッド
					this.Section_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					if (!this.Section_uceAutoFitCol.Checked)
					{
						this.Section_uceAutoFitCol.Checked = true;
					}

					// 従業員目標グリッド
					this.Employee_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					if (!this.Employee_uceAutoFitCol.Checked)
					{
						this.Employee_uceAutoFitCol.Checked = true;
					}

					// 商品目標グリッド
					this.Goods_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					if (!this.Goods_uceAutoFitCol.Checked)
					{
						this.Goods_uceAutoFitCol.Checked = true;
					}

//----- ueno add---------- start 2007.11.21
					// 得意先目標グリッド
					this.Customer_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					if (!this.Customer_uceAutoFitCol.Checked)
					{
						this.Customer_uceAutoFitCol.Checked = true;
					}
//----- ueno add---------- end   2007.11.21
					//----- ueno del---------- start 2007.11.21
					//// 売上形式目標グリッド
					//this.SalesFormal_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					//if (!this.SalesFormal_uceAutoFitCol.Checked)
					//{
					//    this.SalesFormal_uceAutoFitCol.Checked = true;
					//}

					//// 販売形態目標グリッド
					//this.SalesForm_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
					//if (!this.SalesForm_uceAutoFitCol.Checked)
					//{
					//    this.SalesForm_uceAutoFitCol.Checked = true;
					//}
					//----- ueno del---------- end   2007.11.21

				}
                // チェック無し
				else
				{
					// 拠点目標グリッド
					this.Section_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					if (this.Section_uceAutoFitCol.Checked)
					{
						this.Section_uceAutoFitCol.Checked = false;
					}
					InitializeLayout_Section_uGrid();

					// 従業員目標グリッド
					this.Employee_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					if (this.Employee_uceAutoFitCol.Checked)
					{
						this.Employee_uceAutoFitCol.Checked = false;
					}
					InitializeLayout_Employee_uGrid();

					// 商品目標グリッド
					this.Goods_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					if (this.Goods_uceAutoFitCol.Checked)
					{
						this.Goods_uceAutoFitCol.Checked = false;
					}
					InitializeLayout_Goods_uGrid();

//----- ueno add---------- start 2007.11.21
					// 得意先目標グリッド
					this.Customer_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					if (this.Customer_uceAutoFitCol.Checked)
					{
						this.Customer_uceAutoFitCol.Checked = false;
					}
					InitializeLayout_Customer_uGrid();
//----- ueno add---------- end   2007.11.21
					//----- ueno del---------- start 2007.11.21
					//// 売上形式目標グリッド
					//this.SalesFormal_uGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
					//if (this.SalesFormal_uceAutoFitCol.Checked)
					//{
					//    this.SalesFormal_uceAutoFitCol.Checked = false;
					//}
					//InitializeLayout_SalesFormal_uGrid();

					//// 販売形態目標グリッド
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
		/// tArrowKeyControlChangeFocusイベント
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
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

            // Nextフォーカスがグリッドの場合
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
                                // 拠点目標
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
                                // 従業員目標
                                e.NextCtrl = this.NewEmployee_Button;
                                break;
                            case 2:
                                // 商品目標
                                e.NextCtrl = this.NewGoods_Button;
                                break;
//----- ueno add---------- start 2007.11.21
							case 3:
								// 得意先目標
								e.NextCtrl = this.NewCustomer_Button;
								break;
//----- ueno add---------- end   2007.11.21
							//----- ueno del---------- start 2007.11.21
							//case 3:
							//    // 売上形式目標
							//    e.NextCtrl = this.NewSalesFormal_Button;
							//    break;
							//case 4:
							//    // 販売形態目標
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
		/// KeyDown イベント(Grid)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: カーソルボタンを押した時に発生します。</br>
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
        /// 拠点コード入力欄Leave処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 拠点コード入力欄をLeaveした時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
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

                    // 拠点コードがうまく取得できたら目標区分を使用可能にする
                    this.TargetGuide_Button.Enabled = true;
                    this.TargetDivideCode_tEdit.Enabled = true;

                    // 共通変数に保存
                    this._sectionCode = sectionInfo.SectionCode.TrimEnd();
                    this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();

                }
            }
        }

        /// <summary>
        /// 拠点ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
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

                // 拠点コードがうまく取得できたら目標区分を使用可能にする
                this.TargetGuide_Button.Enabled = true;
                this.TargetDivideCode_tEdit.Enabled = true;

                // 共通変数に保存
                this._sectionCode = sectionInfo.SectionCode.TrimEnd();
                this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

		# endregion Control Events

	}
}