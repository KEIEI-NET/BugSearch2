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

// SFCMN00001U...コンポーネント
// SFCMN00002C...TDateTime
// SFCMN00006C...ConstantManagement
// SFCMN00008C...ボタン画像関連
// SFCMN00011I...HFileHeader
// SFCMN00013C...TStrConv
// SFCMN00212I
// SFCMN00615C...オプションコード
// SFCMN00651C...ログイン情報取得
// SFCMN00654D...オプション取得データクラス
// SFCMN09003I...マスタメンテ用
// SFCMN09004C...マスタメンテ用
// SFKTN01210A...拠点情報SecInfoAcsアクセスクラス
// SFKTN09001E...拠点情報SecInfoSet
// SFTOK01136E...CustomerCarSearch
// SFTOK01180U...顧客検索ガイド
// SFTOK09241E...仕入先情報データクラス
// SFTOK09242A...仕入先情報取得アクセスクラス
// SFTOK09381E...従業員情報データクラス
// SFUKK01333D...締スケジュール取得データクラス
// SFUKK01334A...締スケジュール取得アクセスクラス

namespace Broadleaf.Windows.Forms
{
    /// **********************************************************************
    /// <summary>
	///	仕入先実績修正フォームクラス
	/// </summary>
	/// <remarks> 
	/// <br>note       : 仕入先の買掛・支払の実績修正を行います。</br>
    /// <br>Programmer : 30154 安藤　昌仁</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br></br>
    /// <br>note       : 流通.NS用に変更</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br>-----------------------</br>
    /// <br>note       : 仕様変更対応</br>
    /// <br>Modifier   : 徳永 俊詞</br>
    /// <br>Date       : 2008.06.25</br>
    /// <br>-----------------------</br>
    /// <br>Note       : PM.NS用に変更</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.01.14</br>
    /// <br>-----------------------</br>
    /// <br>Note       : 障害ID:10443,10446対応</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2009.01.26</br>
    /// <br>-----------------------</br>
    /// <br>Note       : 仕入先総括対応に伴う対応</br>
    /// <br>Programmer : FSI今野 利裕</br>
    /// <br>Date       : 2012/09/18</br>
    /// <br>-----------------------</br>
    /// <br>Note       : すべて0の値でも登録可能に修正対応</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2023/11/22</br>
    /// </remarks>
    /// **********************************************************************
	public class MAKAU09130UB : System.Windows.Forms.Form, IMasterMaintenanceAccDmdType
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
        private TNedit TtlItdedStcTaxFree_tNedit;
        private TNedit TtlStockInnerTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel InTax_Title_Label;
        private TNedit Bf2TmBl_tNedit;
        private TNedit Bf3TmBl_tNedit;
        private TNedit TtlStockOuterTax_tNedit;
        private TNedit LMBl_tNedit;
        private Infragistics.Win.Misc.UltraLabel LtBlInfo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel OutTax_Title_Label;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private TNedit TtlItdedStcInTax_tNedit;
        private TNedit TtlItdedStcOutTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel ItdedInTax_Title_Label;
        private Infragistics.Win.Misc.UltraButton Undo_Button;
        private Panel SuplierPay_panel;
        private TNedit TtlItdedDisTaxFree_tNedit;
        private TNedit TtlDisInnerTax_tNedit;
        private TNedit TtlDisOuterTax_tNedit;
        private TNedit TtlItdedDisInTax_tNedit;
        private TNedit TtlItdedDisOutTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel PayeeSnm_Label;
        private Infragistics.Win.Misc.UltraLabel claimCode_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel46;
        private TNedit TtlItdedRetTaxFree_tNedit;
        private TNedit TtlRetInnerTax_tNedit;
        private TNedit TtlRetOuterTax_tNedit;
        private TNedit TtlItdedRetInTax_tNedit;
        private TNedit TtlItdedRetOutTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel39;
        private Infragistics.Win.Misc.UltraLabel ultraLabel50;
        private TDateEdit PaymentSchedule_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel49;
        private Infragistics.Win.Misc.UltraLabel PayeeName_Label;
        private Infragistics.Win.Misc.UltraLabel PayeeName2_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerName_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerName2_Label;
        private UiSetControl uiSetControl1;
        private TNedit StockSlipCount_tNedit;
        private TNedit PaymentCondValue_tNedit;
        private Infragistics.Win.Misc.UltraLabel PaymentCond_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel52;
        private Panel SalesInfo_Pnl;
        private Infragistics.Win.Misc.UltraLabel ItdedTaxFree_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ItdedOutTax_Tittle_Label;
        private Infragistics.Win.Misc.UltraLabel SalesPaymInfo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel33;
        private Infragistics.Win.Misc.UltraLabel ultraLabel34;
        private Infragistics.Win.Misc.UltraLabel OfsThisTimeSalesTaxInc_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel35;
        private TNedit OfsThisStockTax_tNedit;
        private Infragistics.Win.Misc.UltraLabel ItdedOffsetTaxFree_Label;
        private Infragistics.Win.Misc.UltraLabel ItdedOffsetOutTax_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel43;
        private Infragistics.Win.Misc.UltraLabel ultraLabel55;
        private Infragistics.Win.Misc.UltraLabel ultraLabel56;
        private Infragistics.Win.Misc.UltraLabel ultraLabel57;
        private Infragistics.Win.Misc.UltraLabel ultraLabel58;
        private Infragistics.Win.Misc.UltraLabel ultraLabel59;
        private Infragistics.Win.Misc.UltraLabel ultraLabel60;
        private Infragistics.Win.Misc.UltraLabel ultraLabel61;
        private Infragistics.Win.Misc.UltraLabel ultraLabel64;
        private Infragistics.Win.Misc.UltraLabel Paym_Title_Label;
        private Infragistics.Win.Misc.UltraLabel Sales_Title_Label;
        private Infragistics.Win.Misc.UltraLabel DisTotal_Label;
        private Infragistics.Win.Misc.UltraLabel RetTotal_Label;
        private Infragistics.Win.Misc.UltraLabel SalesTotal_Label;
        private Infragistics.Win.Misc.UltraLabel ColSalesTotal_Tittle_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel37;
        private Infragistics.Win.Misc.UltraLabel ultraLabel40;
        private Infragistics.Win.Misc.UltraLabel ultraLabel38;
        private Infragistics.Win.Misc.UltraLabel Label101;
        private Infragistics.Win.Misc.UltraLabel RowSalesTotal_Tittle_Label;
        private Panel LtBlInfo_Pnl;
        private Infragistics.Win.Misc.UltraLabel Bf3TmBl_Label;
        private Infragistics.Win.Misc.UltraLabel Bf2TmBl_Label;
        private Infragistics.Win.Misc.UltraLabel LMBl_Label;
        private Infragistics.Win.Misc.UltraLabel BlTotal_Label;
        private Infragistics.Win.Misc.UltraLabel BlTotalTitle_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Infragistics.Win.Misc.UltraLabel ultraLabel24;
        private Infragistics.Win.Misc.UltraLabel ultraLabel41;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Panel AjustInfo_Pnl;
        private TNedit TaxAdjust_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private TNedit BalanceAdjust_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private Panel DepositInfo_Pnl;
        private Infragistics.Win.Misc.UltraLabel Fee_Title_Label;
        private Infragistics.Win.Misc.UltraLabel DepositInfo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private Infragistics.Win.Misc.UltraLabel ultraLabel30;
        private Infragistics.Win.Misc.UltraLabel ultraLabel32;
        private Infragistics.Win.Misc.UltraLabel ultraLabel44;
        private TNedit DisNrml_tNedit;
        private TNedit FeeNrml_tNedit;
        private Infragistics.Win.Misc.UltraLabel Discount_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ColDepoTotal_Title_Label;
        private Infragistics.Win.Misc.UltraLabel NrmlTotal_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel OfsThisTimeSales_Label;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_DemandInfo;
        private TLine tLine4;
        private TNedit OffsetOutTax_tNedit;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdPaymentKind;
		private System.ComponentModel.IContainer components;

		# endregion
		
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>コンストラクタ</summary>
		public MAKAU09130UB()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			// Culture情報初期設定
			this.calendar = new System.Globalization.JapaneseCalendar();
			this.culture  = new System.Globalization.CultureInfo("ja-JP");
			this.culture.DateTimeFormat.Calendar = this.calendar;

			// データセット列情報構築処理
            //DataSetColumnConstruction();

            //　企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			
            // 担当者の機能制御処理取得


			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = true;		// デフォルト:true固定
			this._canNew   = true;

			this._canDelete                         = false;
			this._canLogicalDeleteDataExtraction    = false;
			this._defaultAutoFillToAccRecGridColumn = true;
			this._defaultAutoFillToDmdPrcGridColumn = true;

			// 変数初期化
			this._customerAcs         = new CustomerSearchAcs();
            this._customerInfoAcs     = new CustomerInfoAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._suplAccPayAcs = new SuplAccPayAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
            this._supplierAcs = new SupplierAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END


			this._accRecDataIndex   = -1;
			this._dmdPrcDataIndex   = -1;
	
			this._totalCount = 0;
			
			this._customerTable  = new Hashtable();
			this._secInfSetTable = new Hashtable();

			// GridIndexバッファ（メインフレーム最小化対応）
			this._accRecIndexBuf	= -2;
			this._dmdPrcIndexBuf	= -2;
			this._customerCodeBuf	= -2;
			this._targetTableBuf	= "";
			
			this._sectionCode        = "";
			//this._targetSupplierCode = 0;
		
			this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
			this._targetTableName          = "";

			this._formBeingStarted = false;   // 画面起動完了FLG

			// 拠点オプション
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
			//拠点オプション無し
    		// ログイン担当者情報
			if ( LoginInfoAcquisition.Employee != null) 
			{
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;
				int employeeMode = employee.UserAdminFlag;  //ユーザー管理者FLG
			}

            // 2009.01.14 Add >>>
            AccPayBalanceDispayTable.CreateTable(ref this._totalDisplayTable);
            this._totalDisplayTable.Rows.Add(this._totalDisplayTable.NewRow());

            this._paymentSetAcs = new PaymentSetAcs();
            this._moneyKindAcs = new MoneyKindAcs();
            string msg;
            // 2009.01.14 Add <<<
        }

		# endregion

        // ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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
		// イベント
		// ===================================================================================== //
		# region Events
		/// <summary>
		/// 画面非表示イベント
		/// 画面が非表示状態になった際に発生します。
		/// </summary>
		public event MasterMaintenanceAccDmdTypeUnDisplayingEventHandler UnDisplaying;
        
		# endregion

		// ===================================================================================== //
		// プライベートメンバー
		// ===================================================================================== //
		#region Private Menbers
		// 編集情報
        private SuplAccPay     _editSuplAccPay    = null;       // 編集用
        private SuplierPay     _editSuplierPay    = null;       // 編集用
        private SuplAccPay     _suplAccPayClone   = null;       // 起動時バックアップ用
        private SuplierPay     _suplierPayClone   = null;       // 起動時バックアップ用

		private int	           _logicalDeleteMode = -1;			// 画面起動モード

        // 2009.01.14 Add >>>
        private List<ACalcPayTotal> _editACalcPayTotalList = null;  // 編集用の入金集計データリスト
        private List<AccPayTotal> _editAccPayTotalList = null;      // 編集用の入金集計データリスト
        private SuplAccPay _suplAccPayTotal = new SuplAccPay();     // 集計レコード用
        private SuplierPay _suplierPayTotal = new SuplierPay();     // 集計レコード用
        private List<ACalcPayTotal> _aCalcPayTotalList = null;      // 集計レコード用入金集計データリスト
        private List<AccPayTotal> _accPayTotalList = null;          // 集計レコード用入金集計データリスト
        private DataTable _totalDisplayTable = null;                // 残高表示用

        private DataTable _payeeDataTable = null;                   // 支払内訳入力用
        private DataView _payeeDataView = null;
        // 2009.01.14 Add <<<

		private System.Globalization.Calendar    calendar;
		private System.Globalization.CultureInfo culture;

		private	DateTime									befTempDateTime ;

        private CustomerSearchAcs       _customerAcs = null;		                // 仕入先情報←得意先のみ
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private CustomerInfoAcs         _customerInfoAcs     = null;                // 仕入先アクセス←得意先のみ
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        private SecInfoAcs             _secInfoAcs          = null;		    // 拠点情報
        private SuplAccPayAcs           _suplAccPayAcs = null;         // 仕入先買掛金額マスタ更新
		private CustomerSearchRet      _prevCustomer;					    // 仕入先情報Last
		
		private int                    _totalCount;						    // 件数
		private string                 _enterpriseCode      = "";	        // 企業コード
		private string                 _companySecCode      = "";           // 自拠点コード 

		private bool                   Opt_Section          = false;        // 拠点OP有無
        //private bool                   _autoAllUpDateMode   = false;        // 全拠点も同時に反映するか
		private bool                   _mainOfficeFuncFlag  = false;        // 本社機能フラグ

		private Hashtable _customerTable  = new Hashtable();  // 仕入先
		private Hashtable _secInfSetTable = new Hashtable();  // 拠点情報
		private Hashtable _AllaccrecTable = new Hashtable();  // 買掛金額(全社計)
		private Hashtable _AlldmdprcTable = new Hashtable();  // 支払金額(全社計)

		// プロパティ用
		private bool   _canPrint;
		private bool   _canLogicalDeleteDataExtraction;
		private bool   _canClose;
		private bool   _canNew;
		private bool   _canDelete;
	
		private string _targetTableName;
		private int    _accRecDataIndex;
		private int    _dmdPrcDataIndex;
	
		//_GridIndexバッファ（メインフレーム最小化対応）
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


		private string      _sectionCode;                               // 選択拠点コード
		private int         _targetSupplierCode;                        // 選択仕入先コード
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private int         _targetPayeeCode;                           // 選択支払先コード
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		private bool   _formBeingStarted = false;       // 画面起動完了 起動途中にClose等の処理エラー回避用
		private bool   _timerStarted     = false;		// 重複起動配慮

		private bool   _changeFlg        = false;       // 入力項目変更時

        // 追加パネル表示位置
        //private readonly Point _expansionPanelLocation = new Point(723,1);
        // 2009.01.14 >>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA MODIFY START
        //private readonly Point _expansionPanelLocation = new Point(5, 304);
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.25 TOKUNAGA MODIFY END

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA ADD START

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        private readonly Point _expansionPanelLocation = new Point(4, 293);
        private readonly Point _balance3LabelLocation = new Point(5, 67);
        private readonly Point _balance3EditLocation = new Point(96, 67);

        private readonly Point _balance1LabelLocation = new Point(5, 129);
        private readonly Point _balance1EditLocation = new Point(96, 129);
        // 2009.01.14 <<<
        private SupplierAcs _supplierAcs = null;            // 仕入先アクセス
        private int _targetDivType;                         // 指定区分（請求取得時に必要⇒public propertyで受取)

        // 検索用変数は何れもパブリック プロパティを使用して授受を行う
        private int     _condSupplierCode;                  // 検索用仕入先コード
        private int     _condPayeeCode;                     // 検索用支払先コード
        private string  _condSectionCode;                   // 検索用支払拠点コード
        private string  _condPaymentSectionCode;            // 検索用計上拠点コード

        // 指定区分プルダウン選択項目値設定
        private const int TARGET_DIV_PAYEE = 0;             // 指定区分=請求先
        private const int TARGET_DIV_SUPPLIER = 1;          // 指定区分=得意先
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.25 TOKUNAGA ADD END

        // 2009.01.14 Add >>>
        // 支払設定マスタアクセスクラス
        private PaymentSetAcs _paymentSetAcs;
        // 支払内訳リスト
        private Dictionary<Int32, String> _dicPaymentSetKind;
        // 金種情報マスタアクセスクラス
        private MoneyKindAcs _moneyKindAcs;
        // 金種情報リスト
        private Dictionary<Int32, MoneyKind> _dicMoneyKind;

        private const string ctMoneyKindDiv = "MoneyKindDiv";
        private const string ctMoneyKindCode = "MoneyKindCode";
        private const string ctMoneyKindName = "MoneyKindName";
        private const string ctPayment = "Payment";

        // 2009.01.14 Add <<<

        // --- ADD 2012/09/18 ---------->>>>>
        // 仕入先総括のオプションコード利用可否設定用フラグ
        // true → 仕入先総括使用する。 false → 仕入先総括使用しない。
        private bool _sumSuppEnable = false;
        // --- ADD 2012/09/18 ----------<<<<<

        # endregion

        // ===================================================================================== //
		// 定数定義
		// ===================================================================================== //
		#region Private Constant

		// 編集モード
		private const string INSERT_MODE                 = "新規モード";
		private const string REFER_MODE                  = "参照モード";
		private const string UPDATE_MODE                 = "更新モード";
		private const string DELETE_MODE                 = "削除モード";

		// 仕入先のView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string CUST_DELETE_DATE            = "削除日";
		private const string CUST_CODE_TITLE             = "コード";
		private const string CUST_KANA_TITLE             = "仕入先カナ";
		private const string CUST_NAME1_TITLE            = "仕入先名称１";
		private const string CUST_NAME2_TITLE            = "仕入先名称２";
		private const string CUST_TOTALDAY_TITLE         = "締日";
		private const string CUST_CORPORATEDIVCODE_TITLE = "個人・法人";

		private const string CUST_GUID_TITLE             = "CUST_GUID";
		private const string CUSTOMER_TABLE              = "CUSTOMER";

		// 買掛・支払のView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string REC_SECCODE_TITLE           = "拠点コード";

        private const string REC_ADDUPYEARMONTH_TITLE    = "_計上年月";
        private const string REC_ADDUPDATE_TITLE         = "_計上日";
        private const string REC_ADDUPYEARMONTHJP_TITLE  = "計上年月";
        private const string REC_ADDUPDATEJP_TITLE       = "計上日";
        private const string REC_TOTAL3_BEF_TITLE = "前々々回残高";
        private const string REC_TOTAL2_BEF_TITLE = "前々回残高";
        private const string REC_TOTAL1_BEF_TITLE        = "前回残高";
        private const string REC_THISTIMESALES_TITLE     = "今回仕入";
        private const string REC_CONSTAX_TITLE           = "消費税";
        private const string REC_THISTIMEPAYM_TITLE      = "今回支払";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private const string REC_PAYMCONSTAX_TITLE       = "支払消費税";
        //private const string REC_THISTIMEDEPO_TITLE      = "今回支払";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        private const string REC_ACCRECBLNCE_TITLE       = "買掛残高";
        private const string REC_DMDPRCBLNCE_TITLE       = "支払残高";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private const string REC_BALANCEADJUST_TITLE     = "残高調整額";
        private const string REC_TOTALADJUST_TITLE       = "残高調整額表示";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		// Format定義
		private const string DATE_FORMAT                 = "gyy/MM/dd";
		private const string LONG_FORMAT                 = "###,###,##0円";
		private const string MASK_MONEY                  = "#,##0;-#,##0;''";
		private const string MASK_CNT                    = "#,##0.00;-#,##0.00;''";
		private const string MASK_CODE                   = "#0;-#0;''";

		// 全社拠点コード
		private const string ALLSECCODE                  = "000000";
		
		// ソート用キー
		private const string viewGridFilterDefault		 = "";
		private const string viewGridSortDefault		 = REC_ADDUPDATE_TITLE + " DESC";

        private Form _invokerForm;                      // 2009.01.14 Add

		#endregion

		// ===================================================================================== //
		// Windows フォーム デザイナ
		// ===================================================================================== //
		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance179 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance211 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance221 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance220 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance199 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance219 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance175 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance217 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance200 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance203 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance206 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance205 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance178 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance191 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance190 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance189 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance192 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance193 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance185 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance186 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance170 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance171 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance180 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance156 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance188 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance187 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance215 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance216 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU09130UB));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.CustomerInfo_Panel = new System.Windows.Forms.Panel();
            this.tLine4 = new Broadleaf.Library.Windows.Forms.TLine();
            this.uGrid_DemandInfo = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.PayeeName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayeeName2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayeeSnm_Label = new Infragistics.Win.Misc.UltraLabel();
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
            this.ItdedInTax_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlItdedStcOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedStcInTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.OutTax_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.LtBlInfo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.LMBl_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlStockOuterTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Bf3TmBl_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Bf2TmBl_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.InTax_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlStockInnerTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedStcTaxFree_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DmdSalesInfo_Panel = new System.Windows.Forms.Panel();
            this.OffsetOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositInfo_Pnl = new System.Windows.Forms.Panel();
            this.grdPaymentKind = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ColDepoTotal_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.NrmlTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DisNrml_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.FeeNrml_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Discount_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Fee_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositInfo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel44 = new Infragistics.Win.Misc.UltraLabel();
            this.LtBlInfo_Pnl = new System.Windows.Forms.Panel();
            this.Bf3TmBl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Bf2TmBl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.LMBl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BlTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BlTotalTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel41 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.AjustInfo_Pnl = new System.Windows.Forms.Panel();
            this.TaxAdjust_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.BalanceAdjust_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesInfo_Pnl = new System.Windows.Forms.Panel();
            this.OfsThisTimeSales_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel38 = new Infragistics.Win.Misc.UltraLabel();
            this.Label101 = new Infragistics.Win.Misc.UltraLabel();
            this.RowSalesTotal_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Paym_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Sales_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DisTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RetTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.StockSlipCount_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SalesTotal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ColSalesTotal_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedTaxFree_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedOutTax_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SalesPaymInfo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.TtlItdedRetTaxFree_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.OfsThisTimeSalesTaxInc_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel35 = new Infragistics.Win.Misc.UltraLabel();
            this.OfsThisStockTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ItdedOffsetTaxFree_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlItdedDisTaxFree_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ItdedOffsetOutTax_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlItdedRetOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedDisOutTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel43 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel55 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel58 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel59 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel60 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel61 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel64 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel56 = new Infragistics.Win.Misc.UltraLabel();
            this.SuplierPay_panel = new System.Windows.Forms.Panel();
            this.PaymentCondValue_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PaymentCond_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel52 = new Infragistics.Win.Misc.UltraLabel();
            this.PaymentSchedule_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel50 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel49 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.TtlRetInnerTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlRetOuterTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedRetInTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlDisInnerTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlDisOuterTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TtlItdedDisInTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.CustomerInfo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_DemandInfo)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedStcOutTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedStcInTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMBl_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlStockOuterTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bf3TmBl_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bf2TmBl_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlStockInnerTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedStcTaxFree_tNedit)).BeginInit();
            this.DmdSalesInfo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetOutTax_tNedit)).BeginInit();
            this.DepositInfo_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisNrml_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeeNrml_tNedit)).BeginInit();
            this.LtBlInfo_Pnl.SuspendLayout();
            this.AjustInfo_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaxAdjust_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAdjust_tNedit)).BeginInit();
            this.SalesInfo_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetTaxFree_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisTaxFree_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetOutTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisOutTax_tNedit)).BeginInit();
            this.SuplierPay_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCondValue_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlRetInnerTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlRetOuterTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetInTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlDisInnerTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlDisOuterTax_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisInTax_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 637);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(978, 23);
            this.ultraStatusBar1.TabIndex = 3;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // CustomerInfo_Panel
            // 
            this.CustomerInfo_Panel.Controls.Add(this.tLine4);
            this.CustomerInfo_Panel.Controls.Add(this.uGrid_DemandInfo);
            this.CustomerInfo_Panel.Controls.Add(this.PayeeName_Label);
            this.CustomerInfo_Panel.Controls.Add(this.PayeeName2_Label);
            this.CustomerInfo_Panel.Controls.Add(this.CustomerName_Label);
            this.CustomerInfo_Panel.Controls.Add(this.CustomerName2_Label);
            this.CustomerInfo_Panel.Controls.Add(this.PayeeSnm_Label);
            this.CustomerInfo_Panel.Controls.Add(this.claimCode_Label);
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
            this.CustomerInfo_Panel.Controls.Add(this.AddUpADate_Tittle_Label);
            this.CustomerInfo_Panel.Controls.Add(this.AddUpADate_tDateEdit);
            this.CustomerInfo_Panel.Controls.Add(this.tLine2);
            this.CustomerInfo_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CustomerInfo_Panel.Location = new System.Drawing.Point(0, 0);
            this.CustomerInfo_Panel.Name = "CustomerInfo_Panel";
            this.CustomerInfo_Panel.Size = new System.Drawing.Size(978, 203);
            this.CustomerInfo_Panel.TabIndex = 40;
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine4.Location = new System.Drawing.Point(4, 196);
            this.tLine4.Name = "tLine4";
            this.tLine4.Size = new System.Drawing.Size(969, 4);
            this.tLine4.TabIndex = 1344;
            this.tLine4.Text = "tLine4";
            // 
            // uGrid_DemandInfo
            // 
            appearance30.BackColor = System.Drawing.Color.White;
            appearance30.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_DemandInfo.DisplayLayout.Appearance = appearance30;
            this.uGrid_DemandInfo.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_DemandInfo.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_DemandInfo.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_DemandInfo.DisplayLayout.MaxRowScrollRegions = 1;
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.uGrid_DemandInfo.DisplayLayout.Override.ActiveCellAppearance = appearance31;
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
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance46.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance46.ForeColor = System.Drawing.Color.White;
            appearance46.TextHAlignAsString = "Center";
            appearance46.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_DemandInfo.DisplayLayout.Override.HeaderAppearance = appearance46;
            appearance48.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowAlternateAppearance = appearance48;
            appearance22.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance22.TextVAlignAsString = "Middle";
            this.uGrid_DemandInfo.DisplayLayout.Override.RowAppearance = appearance22;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance49.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance49.ForeColor = System.Drawing.Color.White;
            this.uGrid_DemandInfo.DisplayLayout.Override.RowSelectorAppearance = appearance49;
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
            this.uGrid_DemandInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_DemandInfo.Location = new System.Drawing.Point(7, 145);
            this.uGrid_DemandInfo.Name = "uGrid_DemandInfo";
            this.uGrid_DemandInfo.Size = new System.Drawing.Size(963, 47);
            this.uGrid_DemandInfo.TabIndex = 1343;
            this.uGrid_DemandInfo.TabStop = false;
            // 
            // PayeeName_Label
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.PayeeName_Label.Appearance = appearance1;
            this.PayeeName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.PayeeName_Label.Location = new System.Drawing.Point(721, 56);
            this.PayeeName_Label.Name = "PayeeName_Label";
            this.PayeeName_Label.Size = new System.Drawing.Size(18, 24);
            this.PayeeName_Label.TabIndex = 395;
            this.PayeeName_Label.Visible = false;
            // 
            // PayeeName2_Label
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.PayeeName2_Label.Appearance = appearance2;
            this.PayeeName2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.PayeeName2_Label.Location = new System.Drawing.Point(700, 56);
            this.PayeeName2_Label.Name = "PayeeName2_Label";
            this.PayeeName2_Label.Size = new System.Drawing.Size(18, 24);
            this.PayeeName2_Label.TabIndex = 394;
            this.PayeeName2_Label.Visible = false;
            // 
            // CustomerName_Label
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.CustomerName_Label.Appearance = appearance3;
            this.CustomerName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerName_Label.Location = new System.Drawing.Point(721, 31);
            this.CustomerName_Label.Name = "CustomerName_Label";
            this.CustomerName_Label.Size = new System.Drawing.Size(18, 24);
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
            this.CustomerName2_Label.Location = new System.Drawing.Point(700, 31);
            this.CustomerName2_Label.Name = "CustomerName2_Label";
            this.CustomerName2_Label.Size = new System.Drawing.Size(18, 24);
            this.CustomerName2_Label.TabIndex = 392;
            this.CustomerName2_Label.Visible = false;
            // 
            // PayeeSnm_Label
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.PayeeSnm_Label.Appearance = appearance5;
            this.PayeeSnm_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.PayeeSnm_Label.Location = new System.Drawing.Point(162, 56);
            this.PayeeSnm_Label.Name = "PayeeSnm_Label";
            this.PayeeSnm_Label.Size = new System.Drawing.Size(496, 24);
            this.PayeeSnm_Label.TabIndex = 3;
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
            this.claimCode_Label.Size = new System.Drawing.Size(54, 24);
            this.claimCode_Label.TabIndex = 2;
            // 
            // ultraLabel46
            // 
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel46.Appearance = appearance7;
            this.ultraLabel46.Location = new System.Drawing.Point(12, 56);
            this.ultraLabel46.Name = "ultraLabel46";
            this.ultraLabel46.Size = new System.Drawing.Size(66, 24);
            this.ultraLabel46.TabIndex = 391;
            this.ultraLabel46.Text = "支払先";
            // 
            // tLine24
            // 
            this.tLine24.BackColor = System.Drawing.Color.Transparent;
            this.tLine24.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tLine23.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tLine22.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine22.ForeColor = System.Drawing.Color.Black;
            this.tLine22.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine22.Location = new System.Drawing.Point(797, 107);
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
            this.DemandSalesInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DemandSalesInfo_Title_Label.Location = new System.Drawing.Point(4, 83);
            this.DemandSalesInfo_Title_Label.Name = "DemandSalesInfo_Title_Label";
            this.DemandSalesInfo_Title_Label.Size = new System.Drawing.Size(204, 24);
            this.DemandSalesInfo_Title_Label.TabIndex = 8;
            this.DemandSalesInfo_Title_Label.Text = "支払仕入情報";
            // 
            // tLine15
            // 
            this.tLine15.BackColor = System.Drawing.Color.Transparent;
            this.tLine15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine15.Location = new System.Drawing.Point(4, 106);
            this.tLine15.Name = "tLine15";
            this.tLine15.Size = new System.Drawing.Size(968, 4);
            this.tLine15.TabIndex = 387;
            this.tLine15.Text = "tLine15";
            // 
            // tLine41
            // 
            this.tLine41.BackColor = System.Drawing.Color.Transparent;
            this.tLine41.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tLine27.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine27.ForeColor = System.Drawing.Color.Black;
            this.tLine27.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine27.Location = new System.Drawing.Point(972, 27);
            this.tLine27.Name = "tLine27";
            this.tLine27.Size = new System.Drawing.Size(3, 169);
            this.tLine27.TabIndex = 365;
            this.tLine27.Text = "tLine27";
            // 
            // tLine26
            // 
            this.tLine26.BackColor = System.Drawing.Color.Transparent;
            this.tLine26.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.customerCode_Label.Appearance = appearance9;
            this.customerCode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.customerCode_Label.Location = new System.Drawing.Point(105, 31);
            this.customerCode_Label.Name = "customerCode_Label";
            this.customerCode_Label.Size = new System.Drawing.Size(54, 24);
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
            this.Mode_Label.Text = "更新モード";
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
            this.ultraLabel6.Text = "日";
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
            this.TotalDay_Tittle_Label.Text = "締日";
            // 
            // CustomerSnm_Label
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance50.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance50.TextHAlignAsString = "Left";
            appearance50.TextVAlignAsString = "Middle";
            this.CustomerSnm_Label.Appearance = appearance50;
            this.CustomerSnm_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerSnm_Label.Location = new System.Drawing.Point(162, 31);
            this.CustomerSnm_Label.Name = "CustomerSnm_Label";
            this.CustomerSnm_Label.Size = new System.Drawing.Size(496, 24);
            this.CustomerSnm_Label.TabIndex = 1;
            // 
            // tLine17
            // 
            this.tLine17.BackColor = System.Drawing.Color.Transparent;
            this.tLine17.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine17.Location = new System.Drawing.Point(4, 27);
            this.tLine17.Name = "tLine17";
            this.tLine17.Size = new System.Drawing.Size(968, 4);
            this.tLine17.TabIndex = 118;
            this.tLine17.Text = "tLine17";
            // 
            // tLine5
            // 
            this.tLine5.BackColor = System.Drawing.Color.Transparent;
            this.tLine5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tLine3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLine3.Location = new System.Drawing.Point(4, 83);
            this.tLine3.Name = "tLine3";
            this.tLine3.Size = new System.Drawing.Size(968, 4);
            this.tLine3.TabIndex = 34;
            this.tLine3.Text = "tLine3";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.CustomerTittle_Label.Text = "仕入先";
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
            this.CustomerInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerInfo_Title_Label.Location = new System.Drawing.Point(4, 4);
            this.CustomerInfo_Title_Label.Name = "CustomerInfo_Title_Label";
            this.CustomerInfo_Title_Label.Size = new System.Drawing.Size(204, 24);
            this.CustomerInfo_Title_Label.TabIndex = 0;
            this.CustomerInfo_Title_Label.Text = "仕入先情報";
            // 
            // TotalDay_Label
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance51.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance51.TextHAlignAsString = "Right";
            appearance51.TextVAlignAsString = "Middle";
            this.TotalDay_Label.Appearance = appearance51;
            this.TotalDay_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.TotalDay_Label.Location = new System.Drawing.Point(888, 55);
            this.TotalDay_Label.Name = "TotalDay_Label";
            this.TotalDay_Label.Size = new System.Drawing.Size(32, 24);
            this.TotalDay_Label.TabIndex = 4;
            // 
            // demandAddUpSecCd_Label
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance58.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance58.TextHAlignAsString = "Left";
            appearance58.TextVAlignAsString = "Middle";
            this.demandAddUpSecCd_Label.Appearance = appearance58;
            this.demandAddUpSecCd_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.demandAddUpSecCd_Label.Location = new System.Drawing.Point(407, 111);
            this.demandAddUpSecCd_Label.Name = "demandAddUpSecCd_Label";
            this.demandAddUpSecCd_Label.Size = new System.Drawing.Size(25, 24);
            this.demandAddUpSecCd_Label.TabIndex = 6;
            // 
            // demandAddUpSecName_Label
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            this.demandAddUpSecName_Label.Appearance = appearance29;
            this.demandAddUpSecName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.demandAddUpSecName_Label.Location = new System.Drawing.Point(435, 111);
            this.demandAddUpSecName_Label.Name = "demandAddUpSecName_Label";
            this.demandAddUpSecName_Label.Size = new System.Drawing.Size(296, 24);
            this.demandAddUpSecName_Label.TabIndex = 7;
            this.demandAddUpSecName_Label.Tag = "";
            // 
            // SecInf_Tittle_Label
            // 
            appearance41.TextHAlignAsString = "Center";
            appearance41.TextVAlignAsString = "Middle";
            this.SecInf_Tittle_Label.Appearance = appearance41;
            this.SecInf_Tittle_Label.Location = new System.Drawing.Point(325, 111);
            this.SecInf_Tittle_Label.Name = "SecInf_Tittle_Label";
            this.SecInf_Tittle_Label.Size = new System.Drawing.Size(80, 24);
            this.SecInf_Tittle_Label.TabIndex = 12;
            this.SecInf_Tittle_Label.Text = "入力拠点";
            // 
            // AddUpADate_Tittle_Label
            // 
            appearance42.TextHAlignAsString = "Left";
            appearance42.TextVAlignAsString = "Middle";
            this.AddUpADate_Tittle_Label.Appearance = appearance42;
            this.AddUpADate_Tittle_Label.Location = new System.Drawing.Point(12, 111);
            this.AddUpADate_Tittle_Label.Name = "AddUpADate_Tittle_Label";
            this.AddUpADate_Tittle_Label.Size = new System.Drawing.Size(87, 24);
            this.AddUpADate_Tittle_Label.TabIndex = 9;
            this.AddUpADate_Tittle_Label.Text = "計上日";
            // 
            // AddUpADate_tDateEdit
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            this.AddUpADate_tDateEdit.ActiveEditAppearance = appearance43;
            this.AddUpADate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.AddUpADate_tDateEdit.CalendarDisp = true;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            appearance44.TextHAlignAsString = "Left";
            appearance44.TextVAlignAsString = "Middle";
            this.AddUpADate_tDateEdit.EditAppearance = appearance44;
            this.AddUpADate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.AddUpADate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AddUpADate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AddUpADate_tDateEdit.ForeColor = System.Drawing.Color.Black;
            appearance45.ForeColor = System.Drawing.Color.Black;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextHAlignAsString = "Left";
            appearance45.TextVAlignAsString = "Middle";
            this.AddUpADate_tDateEdit.LabelAppearance = appearance45;
            this.AddUpADate_tDateEdit.Location = new System.Drawing.Point(105, 111);
            this.AddUpADate_tDateEdit.Name = "AddUpADate_tDateEdit";
            this.AddUpADate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.AddUpADate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.AddUpADate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.AddUpADate_tDateEdit.TabIndex = 1;
            this.AddUpADate_tDateEdit.TabStop = true;
            this.AddUpADate_tDateEdit.ValueChanged += new System.EventHandler(this.AddUpADate_tDateEdit_ValueChanged);
            this.AddUpADate_tDateEdit.Enter += new System.EventHandler(this.Control_Enter);
            this.AddUpADate_tDateEdit.Leave += new System.EventHandler(this.AddUpADate_tDateEdit_Leave);
            // 
            // tLine2
            // 
            this.tLine2.BackColor = System.Drawing.Color.Transparent;
            this.tLine2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Undo_Button.TabIndex = 91;
            this.Undo_Button.Text = "取消(&U)";
            this.Undo_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Undo_Button.Visible = false;
            this.Undo_Button.Click += new System.EventHandler(this.Undo_Button_Click);
            // 
            // ItdedInTax_Title_Label
            // 
            appearance88.TextHAlignAsString = "Left";
            appearance88.TextVAlignAsString = "Middle";
            this.ItdedInTax_Title_Label.Appearance = appearance88;
            this.ItdedInTax_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedInTax_Title_Label.Location = new System.Drawing.Point(550, 331);
            this.ItdedInTax_Title_Label.Name = "ItdedInTax_Title_Label";
            this.ItdedInTax_Title_Label.Size = new System.Drawing.Size(90, 24);
            this.ItdedInTax_Title_Label.TabIndex = 6;
            this.ItdedInTax_Title_Label.Text = "内税対象額";
            this.ItdedInTax_Title_Label.Visible = false;
            // 
            // TtlItdedStcOutTax_tNedit
            // 
            appearance179.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance179.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance179.ForeColorDisabled = System.Drawing.Color.Black;
            appearance179.TextHAlignAsString = "Right";
            this.TtlItdedStcOutTax_tNedit.ActiveAppearance = appearance179;
            appearance87.BackColor = System.Drawing.Color.White;
            appearance87.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance87.ForeColor = System.Drawing.Color.Black;
            appearance87.ForeColorDisabled = System.Drawing.Color.Black;
            appearance87.TextHAlignAsString = "Right";
            this.TtlItdedStcOutTax_tNedit.Appearance = appearance87;
            this.TtlItdedStcOutTax_tNedit.AutoSelect = true;
            this.TtlItdedStcOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedStcOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedStcOutTax_tNedit.DataText = "";
            this.TtlItdedStcOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedStcOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedStcOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedStcOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedStcOutTax_tNedit.Location = new System.Drawing.Point(95, 66);
            this.TtlItdedStcOutTax_tNedit.MaxLength = 13;
            this.TtlItdedStcOutTax_tNedit.Name = "TtlItdedStcOutTax_tNedit";
            this.TtlItdedStcOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedStcOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlItdedStcOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedStcOutTax_tNedit.TabIndex = 0;
            this.TtlItdedStcOutTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedStcOutTax_tNedit.Leave += new System.EventHandler(this.Sales_tNedit_Leave);
            this.TtlItdedStcOutTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedStcOutTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedStcInTax_tNedit
            // 
            appearance211.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance211.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance211.ForeColorDisabled = System.Drawing.Color.Black;
            appearance211.TextHAlignAsString = "Right";
            this.TtlItdedStcInTax_tNedit.ActiveAppearance = appearance211;
            appearance160.BackColor = System.Drawing.Color.White;
            appearance160.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance160.ForeColor = System.Drawing.Color.Black;
            appearance160.ForeColorDisabled = System.Drawing.Color.Black;
            appearance160.TextHAlignAsString = "Right";
            this.TtlItdedStcInTax_tNedit.Appearance = appearance160;
            this.TtlItdedStcInTax_tNedit.AutoSelect = true;
            this.TtlItdedStcInTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedStcInTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedStcInTax_tNedit.DataText = "";
            this.TtlItdedStcInTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedStcInTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedStcInTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedStcInTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedStcInTax_tNedit.Location = new System.Drawing.Point(646, 332);
            this.TtlItdedStcInTax_tNedit.MaxLength = 13;
            this.TtlItdedStcInTax_tNedit.Name = "TtlItdedStcInTax_tNedit";
            this.TtlItdedStcInTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedStcInTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedStcInTax_tNedit.TabIndex = 2;
            this.TtlItdedStcInTax_tNedit.Visible = false;
            this.TtlItdedStcInTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedStcInTax_tNedit.Leave += new System.EventHandler(this.Sales_tNedit_Leave);
            this.TtlItdedStcInTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedStcInTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(720, 389);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 93;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(845, 389);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 94;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(595, 389);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 92;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // OutTax_Title_Label
            // 
            appearance157.TextHAlignAsString = "Left";
            appearance157.TextVAlignAsString = "Middle";
            this.OutTax_Title_Label.Appearance = appearance157;
            this.OutTax_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OutTax_Title_Label.Location = new System.Drawing.Point(550, 298);
            this.OutTax_Title_Label.Name = "OutTax_Title_Label";
            this.OutTax_Title_Label.Size = new System.Drawing.Size(90, 24);
            this.OutTax_Title_Label.TabIndex = 5;
            this.OutTax_Title_Label.Text = "外税額";
            this.OutTax_Title_Label.Visible = false;
            // 
            // LtBlInfo_Title_Label
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance90.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance90.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance90.BorderColor = System.Drawing.Color.Black;
            appearance90.TextHAlignAsString = "Center";
            appearance90.TextVAlignAsString = "Middle";
            this.LtBlInfo_Title_Label.Appearance = appearance90;
            this.LtBlInfo_Title_Label.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.LtBlInfo_Title_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.LtBlInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LtBlInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.LtBlInfo_Title_Label.Name = "LtBlInfo_Title_Label";
            this.LtBlInfo_Title_Label.Size = new System.Drawing.Size(192, 24);
            this.LtBlInfo_Title_Label.TabIndex = 50;
            this.LtBlInfo_Title_Label.Text = "前回残高情報";
            // 
            // LMBl_tNedit
            // 
            appearance141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance141.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance141.ForeColorDisabled = System.Drawing.Color.Black;
            appearance141.TextHAlignAsString = "Right";
            this.LMBl_tNedit.ActiveAppearance = appearance141;
            appearance142.BackColor = System.Drawing.Color.White;
            appearance142.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance142.ForeColor = System.Drawing.Color.Black;
            appearance142.ForeColorDisabled = System.Drawing.Color.Black;
            appearance142.TextHAlignAsString = "Right";
            this.LMBl_tNedit.Appearance = appearance142;
            this.LMBl_tNedit.AutoSelect = true;
            this.LMBl_tNedit.BackColor = System.Drawing.Color.White;
            this.LMBl_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.LMBl_tNedit.DataText = "";
            this.LMBl_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.LMBl_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.LMBl_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LMBl_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.LMBl_tNedit.Location = new System.Drawing.Point(96, 129);
            this.LMBl_tNedit.MaxLength = 13;
            this.LMBl_tNedit.Name = "LMBl_tNedit";
            this.LMBl_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.LMBl_tNedit.Size = new System.Drawing.Size(101, 22);
            this.LMBl_tNedit.TabIndex = 2;
            this.LMBl_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.LMBl_tNedit.Leave += new System.EventHandler(this.AcpOdrTtlLMBlDmd_tNedit_Leave);
            this.LMBl_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.LMBl_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlStockOuterTax_tNedit
            // 
            appearance221.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance221.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance221.ForeColorDisabled = System.Drawing.Color.Black;
            appearance221.TextHAlignAsString = "Right";
            this.TtlStockOuterTax_tNedit.ActiveAppearance = appearance221;
            appearance140.BackColor = System.Drawing.Color.White;
            appearance140.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance140.ForeColor = System.Drawing.Color.Black;
            appearance140.ForeColorDisabled = System.Drawing.Color.Black;
            appearance140.TextHAlignAsString = "Right";
            this.TtlStockOuterTax_tNedit.Appearance = appearance140;
            this.TtlStockOuterTax_tNedit.AutoSelect = true;
            this.TtlStockOuterTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlStockOuterTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlStockOuterTax_tNedit.DataText = "";
            this.TtlStockOuterTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlStockOuterTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlStockOuterTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlStockOuterTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlStockOuterTax_tNedit.Location = new System.Drawing.Point(646, 300);
            this.TtlStockOuterTax_tNedit.MaxLength = 13;
            this.TtlStockOuterTax_tNedit.Name = "TtlStockOuterTax_tNedit";
            this.TtlStockOuterTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlStockOuterTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlStockOuterTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlStockOuterTax_tNedit.TabIndex = 1;
            this.TtlStockOuterTax_tNedit.Visible = false;
            this.TtlStockOuterTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlStockOuterTax_tNedit.Leave += new System.EventHandler(this.Sales_tNedit_Leave);
            this.TtlStockOuterTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlStockOuterTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // Bf3TmBl_tNedit
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance73.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance73.ForeColorDisabled = System.Drawing.Color.Black;
            appearance73.TextHAlignAsString = "Right";
            this.Bf3TmBl_tNedit.ActiveAppearance = appearance73;
            appearance138.BackColor = System.Drawing.Color.White;
            appearance138.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance138.ForeColor = System.Drawing.Color.Black;
            appearance138.ForeColorDisabled = System.Drawing.Color.Black;
            appearance138.TextHAlignAsString = "Right";
            this.Bf3TmBl_tNedit.Appearance = appearance138;
            this.Bf3TmBl_tNedit.AutoSelect = true;
            this.Bf3TmBl_tNedit.BackColor = System.Drawing.Color.White;
            this.Bf3TmBl_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.Bf3TmBl_tNedit.DataText = "";
            this.Bf3TmBl_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Bf3TmBl_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.Bf3TmBl_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf3TmBl_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Bf3TmBl_tNedit.Location = new System.Drawing.Point(96, 67);
            this.Bf3TmBl_tNedit.MaxLength = 13;
            this.Bf3TmBl_tNedit.Name = "Bf3TmBl_tNedit";
            this.Bf3TmBl_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.Bf3TmBl_tNedit.Size = new System.Drawing.Size(101, 22);
            this.Bf3TmBl_tNedit.TabIndex = 0;
            this.Bf3TmBl_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.Bf3TmBl_tNedit.Leave += new System.EventHandler(this.AcpOdrTtlLMBlDmd_tNedit_Leave);
            this.Bf3TmBl_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.Bf3TmBl_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // Bf2TmBl_tNedit
            // 
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance93.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance93.ForeColorDisabled = System.Drawing.Color.Black;
            appearance93.TextHAlignAsString = "Right";
            this.Bf2TmBl_tNedit.ActiveAppearance = appearance93;
            appearance136.BackColor = System.Drawing.Color.White;
            appearance136.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance136.ForeColor = System.Drawing.Color.Black;
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            appearance136.TextHAlignAsString = "Right";
            this.Bf2TmBl_tNedit.Appearance = appearance136;
            this.Bf2TmBl_tNedit.AutoSelect = true;
            this.Bf2TmBl_tNedit.BackColor = System.Drawing.Color.White;
            this.Bf2TmBl_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.Bf2TmBl_tNedit.DataText = "";
            this.Bf2TmBl_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Bf2TmBl_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.Bf2TmBl_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf2TmBl_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Bf2TmBl_tNedit.Location = new System.Drawing.Point(96, 98);
            this.Bf2TmBl_tNedit.MaxLength = 13;
            this.Bf2TmBl_tNedit.Name = "Bf2TmBl_tNedit";
            this.Bf2TmBl_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.Bf2TmBl_tNedit.Size = new System.Drawing.Size(101, 22);
            this.Bf2TmBl_tNedit.TabIndex = 1;
            this.Bf2TmBl_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.Bf2TmBl_tNedit.Leave += new System.EventHandler(this.AcpOdrTtlLMBlDmd_tNedit_Leave);
            this.Bf2TmBl_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.Bf2TmBl_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // InTax_Title_Label
            // 
            appearance220.TextHAlignAsString = "Left";
            appearance220.TextVAlignAsString = "Middle";
            this.InTax_Title_Label.Appearance = appearance220;
            this.InTax_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.InTax_Title_Label.Location = new System.Drawing.Point(550, 364);
            this.InTax_Title_Label.Name = "InTax_Title_Label";
            this.InTax_Title_Label.Size = new System.Drawing.Size(90, 24);
            this.InTax_Title_Label.TabIndex = 7;
            this.InTax_Title_Label.Text = "内税額";
            this.InTax_Title_Label.Visible = false;
            // 
            // TtlStockInnerTax_tNedit
            // 
            appearance199.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance199.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance199.ForeColorDisabled = System.Drawing.Color.Black;
            appearance199.TextHAlignAsString = "Right";
            this.TtlStockInnerTax_tNedit.ActiveAppearance = appearance199;
            appearance219.BackColor = System.Drawing.Color.White;
            appearance219.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance219.ForeColor = System.Drawing.Color.Black;
            appearance219.ForeColorDisabled = System.Drawing.Color.Black;
            appearance219.TextHAlignAsString = "Right";
            this.TtlStockInnerTax_tNedit.Appearance = appearance219;
            this.TtlStockInnerTax_tNedit.AutoSelect = true;
            this.TtlStockInnerTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlStockInnerTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlStockInnerTax_tNedit.DataText = "";
            this.TtlStockInnerTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlStockInnerTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlStockInnerTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlStockInnerTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlStockInnerTax_tNedit.Location = new System.Drawing.Point(646, 365);
            this.TtlStockInnerTax_tNedit.MaxLength = 13;
            this.TtlStockInnerTax_tNedit.Name = "TtlStockInnerTax_tNedit";
            this.TtlStockInnerTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlStockInnerTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlStockInnerTax_tNedit.TabIndex = 3;
            this.TtlStockInnerTax_tNedit.Visible = false;
            this.TtlStockInnerTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlStockInnerTax_tNedit.Leave += new System.EventHandler(this.Sales_tNedit_Leave);
            this.TtlStockInnerTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlStockInnerTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedStcTaxFree_tNedit
            // 
            appearance174.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance174.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance174.ForeColorDisabled = System.Drawing.Color.Black;
            appearance174.TextHAlignAsString = "Right";
            this.TtlItdedStcTaxFree_tNedit.ActiveAppearance = appearance174;
            appearance175.BackColor = System.Drawing.Color.White;
            appearance175.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance175.ForeColor = System.Drawing.Color.Black;
            appearance175.ForeColorDisabled = System.Drawing.Color.Black;
            appearance175.TextHAlignAsString = "Right";
            this.TtlItdedStcTaxFree_tNedit.Appearance = appearance175;
            this.TtlItdedStcTaxFree_tNedit.AutoSelect = true;
            this.TtlItdedStcTaxFree_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedStcTaxFree_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedStcTaxFree_tNedit.DataText = "";
            this.TtlItdedStcTaxFree_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedStcTaxFree_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedStcTaxFree_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedStcTaxFree_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedStcTaxFree_tNedit.Location = new System.Drawing.Point(202, 66);
            this.TtlItdedStcTaxFree_tNedit.MaxLength = 13;
            this.TtlItdedStcTaxFree_tNedit.Name = "TtlItdedStcTaxFree_tNedit";
            this.TtlItdedStcTaxFree_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedStcTaxFree_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedStcTaxFree_tNedit.TabIndex = 3;
            this.TtlItdedStcTaxFree_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedStcTaxFree_tNedit.Leave += new System.EventHandler(this.Sales_tNedit_Leave);
            this.TtlItdedStcTaxFree_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedStcTaxFree_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // DmdSalesInfo_Panel
            // 
            this.DmdSalesInfo_Panel.Controls.Add(this.OffsetOutTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.DepositInfo_Pnl);
            this.DmdSalesInfo_Panel.Controls.Add(this.LtBlInfo_Pnl);
            this.DmdSalesInfo_Panel.Controls.Add(this.AjustInfo_Pnl);
            this.DmdSalesInfo_Panel.Controls.Add(this.SalesInfo_Pnl);
            this.DmdSalesInfo_Panel.Controls.Add(this.SuplierPay_panel);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlRetInnerTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlRetOuterTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlItdedRetInTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlDisInnerTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlDisOuterTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlItdedDisInTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlStockInnerTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.InTax_Title_Label);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlStockOuterTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.OutTax_Title_Label);
            this.DmdSalesInfo_Panel.Controls.Add(this.Delete_Button);
            this.DmdSalesInfo_Panel.Controls.Add(this.Cancel_Button);
            this.DmdSalesInfo_Panel.Controls.Add(this.Ok_Button);
            this.DmdSalesInfo_Panel.Controls.Add(this.TtlItdedStcInTax_tNedit);
            this.DmdSalesInfo_Panel.Controls.Add(this.ItdedInTax_Title_Label);
            this.DmdSalesInfo_Panel.Controls.Add(this.Undo_Button);
            this.DmdSalesInfo_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DmdSalesInfo_Panel.Location = new System.Drawing.Point(0, 203);
            this.DmdSalesInfo_Panel.Name = "DmdSalesInfo_Panel";
            this.DmdSalesInfo_Panel.Size = new System.Drawing.Size(978, 434);
            this.DmdSalesInfo_Panel.TabIndex = 2;
            // 
            // OffsetOutTax_tNedit
            // 
            appearance217.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance217.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance217.ForeColorDisabled = System.Drawing.Color.Black;
            appearance217.TextHAlignAsString = "Right";
            this.OffsetOutTax_tNedit.ActiveAppearance = appearance217;
            appearance218.BackColor = System.Drawing.Color.White;
            appearance218.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance218.ForeColor = System.Drawing.Color.Black;
            appearance218.ForeColorDisabled = System.Drawing.Color.Black;
            appearance218.TextHAlignAsString = "Right";
            this.OffsetOutTax_tNedit.Appearance = appearance218;
            this.OffsetOutTax_tNedit.AutoSelect = true;
            this.OffsetOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.OffsetOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.OffsetOutTax_tNedit.DataText = "";
            this.OffsetOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OffsetOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.OffsetOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OffsetOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.OffsetOutTax_tNedit.Location = new System.Drawing.Point(443, 317);
            this.OffsetOutTax_tNedit.MaxLength = 13;
            this.OffsetOutTax_tNedit.Name = "OffsetOutTax_tNedit";
            this.OffsetOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.OffsetOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OffsetOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.OffsetOutTax_tNedit.TabIndex = 577;
            this.OffsetOutTax_tNedit.Visible = false;
            // 
            // DepositInfo_Pnl
            // 
            this.DepositInfo_Pnl.Controls.Add(this.grdPaymentKind);
            this.DepositInfo_Pnl.Controls.Add(this.ColDepoTotal_Title_Label);
            this.DepositInfo_Pnl.Controls.Add(this.NrmlTotal_Label);
            this.DepositInfo_Pnl.Controls.Add(this.DisNrml_tNedit);
            this.DepositInfo_Pnl.Controls.Add(this.FeeNrml_tNedit);
            this.DepositInfo_Pnl.Controls.Add(this.Discount_Title_Label);
            this.DepositInfo_Pnl.Controls.Add(this.Fee_Title_Label);
            this.DepositInfo_Pnl.Controls.Add(this.DepositInfo_Title_Label);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel12);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel19);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel28);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel30);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel32);
            this.DepositInfo_Pnl.Controls.Add(this.ultraLabel44);
            this.DepositInfo_Pnl.Location = new System.Drawing.Point(432, 1);
            this.DepositInfo_Pnl.Name = "DepositInfo_Pnl";
            this.DepositInfo_Pnl.Size = new System.Drawing.Size(243, 279);
            this.DepositInfo_Pnl.TabIndex = 1;
            // 
            // grdPaymentKind
            // 
            this.grdPaymentKind.Cursor = System.Windows.Forms.Cursors.Default;
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.Color.Blue;
            this.grdPaymentKind.DisplayLayout.Appearance = appearance13;
            appearance94.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance94.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance94.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPaymentKind.DisplayLayout.GroupByBox.Appearance = appearance94;
            appearance137.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdPaymentKind.DisplayLayout.GroupByBox.BandLabelAppearance = appearance137;
            this.grdPaymentKind.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPaymentKind.DisplayLayout.GroupByBox.Hidden = true;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdPaymentKind.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.grdPaymentKind.DisplayLayout.MaxColScrollRegions = 1;
            this.grdPaymentKind.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPaymentKind.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            this.grdPaymentKind.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdPaymentKind.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdPaymentKind.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdPaymentKind.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdPaymentKind.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            this.grdPaymentKind.DisplayLayout.Override.CardAreaAppearance = appearance18;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdPaymentKind.DisplayLayout.Override.CellAppearance = appearance19;
            this.grdPaymentKind.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdPaymentKind.DisplayLayout.Override.CellPadding = 0;
            appearance20.BackColor = System.Drawing.SystemColors.Control;
            appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance20.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPaymentKind.DisplayLayout.Override.GroupByRowAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance21.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.ForeColor = System.Drawing.Color.White;
            appearance21.TextHAlignAsString = "Left";
            appearance21.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdPaymentKind.DisplayLayout.Override.HeaderAppearance = appearance21;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.grdPaymentKind.DisplayLayout.Override.RowAppearance = appearance23;
            this.grdPaymentKind.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance24.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance24.ForeColor = System.Drawing.Color.Black;
            this.grdPaymentKind.DisplayLayout.Override.SelectedRowAppearance = appearance24;
            this.grdPaymentKind.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdPaymentKind.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdPaymentKind.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdPaymentKind.DisplayLayout.Override.TemplateAddRowAppearance = appearance25;
            this.grdPaymentKind.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black;
            this.grdPaymentKind.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.grdPaymentKind.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdPaymentKind.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdPaymentKind.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.grdPaymentKind.Location = new System.Drawing.Point(5, 35);
            this.grdPaymentKind.Name = "grdPaymentKind";
            this.grdPaymentKind.Size = new System.Drawing.Size(229, 131);
            this.grdPaymentKind.TabIndex = 0;
            this.grdPaymentKind.AfterExitEditMode += new System.EventHandler(this.grdPaymentKind_AfterExitEditMode);
            this.grdPaymentKind.AfterEnterEditMode += new System.EventHandler(this.grdPaymentKind_AfterEnterEditMode);
            this.grdPaymentKind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdPaymentKind_KeyPress);
            this.grdPaymentKind.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdPaymentKind_CellChange);
            this.grdPaymentKind.Leave += new System.EventHandler(this.grdPaymentKind_Leave);
            this.grdPaymentKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdPaymentKind_KeyDown);
            // 
            // ColDepoTotal_Title_Label
            // 
            appearance209.TextHAlignAsString = "Left";
            appearance209.TextVAlignAsString = "Middle";
            this.ColDepoTotal_Title_Label.Appearance = appearance209;
            this.ColDepoTotal_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColDepoTotal_Title_Label.Location = new System.Drawing.Point(6, 239);
            this.ColDepoTotal_Title_Label.Name = "ColDepoTotal_Title_Label";
            this.ColDepoTotal_Title_Label.Size = new System.Drawing.Size(79, 22);
            this.ColDepoTotal_Title_Label.TabIndex = 605;
            this.ColDepoTotal_Title_Label.Text = "支払合計";
            // 
            // NrmlTotal_Label
            // 
            appearance200.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance200.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance200.TextHAlignAsString = "Right";
            appearance200.TextVAlignAsString = "Middle";
            this.NrmlTotal_Label.Appearance = appearance200;
            this.NrmlTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.NrmlTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NrmlTotal_Label.Location = new System.Drawing.Point(115, 239);
            this.NrmlTotal_Label.Name = "NrmlTotal_Label";
            this.NrmlTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.NrmlTotal_Label.TabIndex = 604;
            // 
            // DisNrml_tNedit
            // 
            appearance201.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance201.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance201.ForeColorDisabled = System.Drawing.Color.Black;
            appearance201.TextHAlignAsString = "Right";
            this.DisNrml_tNedit.ActiveAppearance = appearance201;
            appearance202.BackColor = System.Drawing.Color.White;
            appearance202.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance202.ForeColor = System.Drawing.Color.Black;
            appearance202.ForeColorDisabled = System.Drawing.Color.Black;
            appearance202.TextHAlignAsString = "Right";
            this.DisNrml_tNedit.Appearance = appearance202;
            this.DisNrml_tNedit.AutoSelect = true;
            this.DisNrml_tNedit.BackColor = System.Drawing.Color.White;
            this.DisNrml_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DisNrml_tNedit.DataText = "";
            this.DisNrml_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DisNrml_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.DisNrml_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DisNrml_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DisNrml_tNedit.Location = new System.Drawing.Point(115, 205);
            this.DisNrml_tNedit.MaxLength = 13;
            this.DisNrml_tNedit.Name = "DisNrml_tNedit";
            this.DisNrml_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DisNrml_tNedit.Size = new System.Drawing.Size(101, 22);
            this.DisNrml_tNedit.TabIndex = 2;
            this.DisNrml_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.DisNrml_tNedit.Leave += new System.EventHandler(this.Normal_tNedit_Leave);
            this.DisNrml_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.DisNrml_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // FeeNrml_tNedit
            // 
            appearance203.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance203.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance203.ForeColorDisabled = System.Drawing.Color.Black;
            appearance203.TextHAlignAsString = "Right";
            this.FeeNrml_tNedit.ActiveAppearance = appearance203;
            appearance206.BackColor = System.Drawing.Color.White;
            appearance206.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance206.ForeColor = System.Drawing.Color.Black;
            appearance206.ForeColorDisabled = System.Drawing.Color.Black;
            appearance206.TextHAlignAsString = "Right";
            this.FeeNrml_tNedit.Appearance = appearance206;
            this.FeeNrml_tNedit.AutoSelect = true;
            this.FeeNrml_tNedit.BackColor = System.Drawing.Color.White;
            this.FeeNrml_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.FeeNrml_tNedit.DataText = "";
            this.FeeNrml_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.FeeNrml_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.FeeNrml_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FeeNrml_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.FeeNrml_tNedit.Location = new System.Drawing.Point(115, 174);
            this.FeeNrml_tNedit.MaxLength = 13;
            this.FeeNrml_tNedit.Name = "FeeNrml_tNedit";
            this.FeeNrml_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.FeeNrml_tNedit.Size = new System.Drawing.Size(101, 22);
            this.FeeNrml_tNedit.TabIndex = 1;
            this.FeeNrml_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.FeeNrml_tNedit.Leave += new System.EventHandler(this.Normal_tNedit_Leave);
            this.FeeNrml_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.FeeNrml_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // Discount_Title_Label
            // 
            appearance210.TextHAlignAsString = "Left";
            appearance210.TextVAlignAsString = "Middle";
            this.Discount_Title_Label.Appearance = appearance210;
            this.Discount_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Discount_Title_Label.Location = new System.Drawing.Point(6, 205);
            this.Discount_Title_Label.Name = "Discount_Title_Label";
            this.Discount_Title_Label.Size = new System.Drawing.Size(79, 22);
            this.Discount_Title_Label.TabIndex = 601;
            this.Discount_Title_Label.Text = "値引額";
            // 
            // Fee_Title_Label
            // 
            appearance205.TextHAlignAsString = "Left";
            appearance205.TextVAlignAsString = "Middle";
            this.Fee_Title_Label.Appearance = appearance205;
            this.Fee_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Fee_Title_Label.Location = new System.Drawing.Point(6, 174);
            this.Fee_Title_Label.Name = "Fee_Title_Label";
            this.Fee_Title_Label.Size = new System.Drawing.Size(79, 22);
            this.Fee_Title_Label.TabIndex = 600;
            this.Fee_Title_Label.Text = "手数料額";
            // 
            // DepositInfo_Title_Label
            // 
            appearance165.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance165.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance165.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance165.BorderColor = System.Drawing.Color.Black;
            appearance165.TextHAlignAsString = "Center";
            appearance165.TextVAlignAsString = "Middle";
            this.DepositInfo_Title_Label.Appearance = appearance165;
            this.DepositInfo_Title_Label.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.DepositInfo_Title_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DepositInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DepositInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.DepositInfo_Title_Label.Name = "DepositInfo_Title_Label";
            this.DepositInfo_Title_Label.Size = new System.Drawing.Size(229, 24);
            this.DepositInfo_Title_Label.TabIndex = 599;
            this.DepositInfo_Title_Label.Text = "支払情報";
            // 
            // ultraLabel12
            // 
            appearance178.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel12.Appearance = appearance178;
            this.ultraLabel12.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel12.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(239, 34);
            this.ultraLabel12.TabIndex = 583;
            // 
            // ultraLabel19
            // 
            appearance55.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel19.Appearance = appearance55;
            this.ultraLabel19.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel19.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel19.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel19.Location = new System.Drawing.Point(0, 234);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(239, 32);
            this.ultraLabel19.TabIndex = 598;
            // 
            // ultraLabel28
            // 
            appearance61.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel28.Appearance = appearance61;
            this.ultraLabel28.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel28.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel28.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel28.Location = new System.Drawing.Point(0, 231);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(239, 4);
            this.ultraLabel28.TabIndex = 595;
            // 
            // ultraLabel30
            // 
            appearance79.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel30.Appearance = appearance79;
            this.ultraLabel30.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel30.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel30.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel30.Location = new System.Drawing.Point(0, 200);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(239, 32);
            this.ultraLabel30.TabIndex = 594;
            // 
            // ultraLabel32
            // 
            appearance92.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel32.Appearance = appearance92;
            this.ultraLabel32.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel32.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel32.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel32.Location = new System.Drawing.Point(0, 169);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(239, 32);
            this.ultraLabel32.TabIndex = 591;
            // 
            // ultraLabel44
            // 
            appearance27.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel44.Appearance = appearance27;
            this.ultraLabel44.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel44.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel44.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel44.Location = new System.Drawing.Point(0, 33);
            this.ultraLabel44.Name = "ultraLabel44";
            this.ultraLabel44.Size = new System.Drawing.Size(239, 137);
            this.ultraLabel44.TabIndex = 582;
            // 
            // LtBlInfo_Pnl
            // 
            this.LtBlInfo_Pnl.Controls.Add(this.Bf3TmBl_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.Bf2TmBl_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.LMBl_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.BlTotal_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.BlTotalTitle_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel14);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel15);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel16);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel24);
            this.LtBlInfo_Pnl.Controls.Add(this.LtBlInfo_Title_Label);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel13);
            this.LtBlInfo_Pnl.Controls.Add(this.Bf2TmBl_tNedit);
            this.LtBlInfo_Pnl.Controls.Add(this.Bf3TmBl_tNedit);
            this.LtBlInfo_Pnl.Controls.Add(this.LMBl_tNedit);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel20);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel41);
            this.LtBlInfo_Pnl.Controls.Add(this.ultraLabel42);
            this.LtBlInfo_Pnl.Location = new System.Drawing.Point(676, 1);
            this.LtBlInfo_Pnl.Name = "LtBlInfo_Pnl";
            this.LtBlInfo_Pnl.Size = new System.Drawing.Size(207, 210);
            this.LtBlInfo_Pnl.TabIndex = 2;
            // 
            // Bf3TmBl_Label
            // 
            appearance89.TextHAlignAsString = "Left";
            appearance89.TextVAlignAsString = "Middle";
            this.Bf3TmBl_Label.Appearance = appearance89;
            this.Bf3TmBl_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf3TmBl_Label.Location = new System.Drawing.Point(5, 67);
            this.Bf3TmBl_Label.Name = "Bf3TmBl_Label";
            this.Bf3TmBl_Label.Size = new System.Drawing.Size(89, 22);
            this.Bf3TmBl_Label.TabIndex = 599;
            this.Bf3TmBl_Label.Text = "前々々回残高";
            // 
            // Bf2TmBl_Label
            // 
            appearance54.TextHAlignAsString = "Left";
            appearance54.TextVAlignAsString = "Middle";
            this.Bf2TmBl_Label.Appearance = appearance54;
            this.Bf2TmBl_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf2TmBl_Label.Location = new System.Drawing.Point(5, 98);
            this.Bf2TmBl_Label.Name = "Bf2TmBl_Label";
            this.Bf2TmBl_Label.Size = new System.Drawing.Size(89, 22);
            this.Bf2TmBl_Label.TabIndex = 600;
            this.Bf2TmBl_Label.Text = "前々回残高";
            // 
            // LMBl_Label
            // 
            appearance78.TextHAlignAsString = "Left";
            appearance78.TextVAlignAsString = "Middle";
            this.LMBl_Label.Appearance = appearance78;
            this.LMBl_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LMBl_Label.Location = new System.Drawing.Point(5, 129);
            this.LMBl_Label.Name = "LMBl_Label";
            this.LMBl_Label.Size = new System.Drawing.Size(89, 22);
            this.LMBl_Label.TabIndex = 601;
            this.LMBl_Label.Text = "前回残高";
            // 
            // BlTotal_Label
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance40.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance40.TextHAlignAsString = "Right";
            appearance40.TextVAlignAsString = "Middle";
            this.BlTotal_Label.Appearance = appearance40;
            this.BlTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.BlTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BlTotal_Label.Location = new System.Drawing.Point(96, 163);
            this.BlTotal_Label.Name = "BlTotal_Label";
            this.BlTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.BlTotal_Label.TabIndex = 598;
            // 
            // BlTotalTitle_Label
            // 
            appearance72.TextHAlignAsString = "Left";
            appearance72.TextVAlignAsString = "Middle";
            this.BlTotalTitle_Label.Appearance = appearance72;
            this.BlTotalTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BlTotalTitle_Label.Location = new System.Drawing.Point(5, 163);
            this.BlTotalTitle_Label.Name = "BlTotalTitle_Label";
            this.BlTotalTitle_Label.Size = new System.Drawing.Size(89, 22);
            this.BlTotalTitle_Label.TabIndex = 587;
            this.BlTotalTitle_Label.Text = "残高合計";
            // 
            // ultraLabel14
            // 
            appearance95.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel14.Appearance = appearance95;
            this.ultraLabel14.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel14.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel14.Location = new System.Drawing.Point(0, 158);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(202, 32);
            this.ultraLabel14.TabIndex = 586;
            // 
            // ultraLabel15
            // 
            appearance96.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel15.Appearance = appearance96;
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel15.Location = new System.Drawing.Point(0, 155);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(202, 4);
            this.ultraLabel15.TabIndex = 573;
            // 
            // ultraLabel16
            // 
            appearance98.BackColor = System.Drawing.Color.Transparent;
            appearance98.TextHAlignAsString = "Center";
            appearance98.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance98;
            this.ultraLabel16.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel16.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel16.Location = new System.Drawing.Point(96, 40);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(101, 18);
            this.ultraLabel16.TabIndex = 578;
            this.ultraLabel16.Text = "残高";
            // 
            // ultraLabel24
            // 
            appearance191.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel24.Appearance = appearance191;
            this.ultraLabel24.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel24.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel24.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel24.Location = new System.Drawing.Point(0, 33);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(202, 30);
            this.ultraLabel24.TabIndex = 582;
            // 
            // ultraLabel13
            // 
            appearance190.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel13.Appearance = appearance190;
            this.ultraLabel13.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel13.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel13.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel13.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(202, 34);
            this.ultraLabel13.TabIndex = 583;
            // 
            // ultraLabel20
            // 
            appearance189.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel20.Appearance = appearance189;
            this.ultraLabel20.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel20.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel20.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel20.Location = new System.Drawing.Point(0, 124);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(202, 32);
            this.ultraLabel20.TabIndex = 577;
            // 
            // ultraLabel41
            // 
            appearance192.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel41.Appearance = appearance192;
            this.ultraLabel41.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel41.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel41.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel41.Location = new System.Drawing.Point(0, 62);
            this.ultraLabel41.Name = "ultraLabel41";
            this.ultraLabel41.Size = new System.Drawing.Size(202, 32);
            this.ultraLabel41.TabIndex = 584;
            // 
            // ultraLabel42
            // 
            appearance193.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel42.Appearance = appearance193;
            this.ultraLabel42.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel42.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel42.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel42.Location = new System.Drawing.Point(0, 93);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(202, 32);
            this.ultraLabel42.TabIndex = 585;
            // 
            // AjustInfo_Pnl
            // 
            this.AjustInfo_Pnl.Controls.Add(this.TaxAdjust_tNedit);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel26);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel25);
            this.AjustInfo_Pnl.Controls.Add(this.BalanceAdjust_tNedit);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel27);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel10);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel22);
            this.AjustInfo_Pnl.Controls.Add(this.ultraLabel23);
            this.AjustInfo_Pnl.Location = new System.Drawing.Point(732, 186);
            this.AjustInfo_Pnl.Name = "AjustInfo_Pnl";
            this.AjustInfo_Pnl.Size = new System.Drawing.Size(238, 106);
            this.AjustInfo_Pnl.TabIndex = 574;
            this.AjustInfo_Pnl.Visible = false;
            // 
            // TaxAdjust_tNedit
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance37.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextHAlignAsString = "Right";
            this.TaxAdjust_tNedit.ActiveAppearance = appearance37;
            appearance125.BackColor = System.Drawing.Color.White;
            appearance125.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance125.ForeColor = System.Drawing.Color.Black;
            appearance125.ForeColorDisabled = System.Drawing.Color.Black;
            appearance125.TextHAlignAsString = "Right";
            this.TaxAdjust_tNedit.Appearance = appearance125;
            this.TaxAdjust_tNedit.AutoSelect = true;
            this.TaxAdjust_tNedit.BackColor = System.Drawing.Color.White;
            this.TaxAdjust_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxAdjust_tNedit.DataText = "";
            this.TaxAdjust_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxAdjust_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TaxAdjust_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TaxAdjust_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxAdjust_tNedit.Location = new System.Drawing.Point(110, 74);
            this.TaxAdjust_tNedit.MaxLength = 10;
            this.TaxAdjust_tNedit.Name = "TaxAdjust_tNedit";
            this.TaxAdjust_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxAdjust_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TaxAdjust_tNedit.TabIndex = 568;
            // 
            // ultraLabel26
            // 
            appearance52.TextHAlignAsString = "Center";
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance52;
            this.ultraLabel26.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel26.Location = new System.Drawing.Point(4, 72);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(89, 24);
            this.ultraLabel26.TabIndex = 574;
            this.ultraLabel26.Text = "消費税調整額";
            // 
            // ultraLabel25
            // 
            appearance107.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel25.Appearance = appearance107;
            this.ultraLabel25.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel25.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel25.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel25.Location = new System.Drawing.Point(0, 68);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(219, 34);
            this.ultraLabel25.TabIndex = 573;
            // 
            // BalanceAdjust_tNedit
            // 
            appearance97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance97.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance97.ForeColorDisabled = System.Drawing.Color.Black;
            appearance97.TextHAlignAsString = "Right";
            this.BalanceAdjust_tNedit.ActiveAppearance = appearance97;
            appearance129.BackColor = System.Drawing.Color.White;
            appearance129.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance129.ForeColor = System.Drawing.Color.Black;
            appearance129.ForeColorDisabled = System.Drawing.Color.Black;
            appearance129.TextHAlignAsString = "Right";
            this.BalanceAdjust_tNedit.Appearance = appearance129;
            this.BalanceAdjust_tNedit.AutoSelect = true;
            this.BalanceAdjust_tNedit.BackColor = System.Drawing.Color.White;
            this.BalanceAdjust_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.BalanceAdjust_tNedit.DataText = "";
            this.BalanceAdjust_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BalanceAdjust_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.BalanceAdjust_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BalanceAdjust_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BalanceAdjust_tNedit.Location = new System.Drawing.Point(110, 41);
            this.BalanceAdjust_tNedit.MaxLength = 13;
            this.BalanceAdjust_tNedit.Name = "BalanceAdjust_tNedit";
            this.BalanceAdjust_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.BalanceAdjust_tNedit.Size = new System.Drawing.Size(101, 22);
            this.BalanceAdjust_tNedit.TabIndex = 567;
            // 
            // ultraLabel27
            // 
            appearance185.TextHAlignAsString = "Center";
            appearance185.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance185;
            this.ultraLabel27.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel27.Location = new System.Drawing.Point(3, 39);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(89, 24);
            this.ultraLabel27.TabIndex = 572;
            this.ultraLabel27.Text = "残高調整額";
            // 
            // ultraLabel10
            // 
            appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance131.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance131.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance131.BorderColor = System.Drawing.Color.Black;
            appearance131.TextHAlignAsString = "Center";
            appearance131.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance131;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraLabel10.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel10.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(3, 8);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(212, 24);
            this.ultraLabel10.TabIndex = 571;
            this.ultraLabel10.Text = "残高調整情報";
            // 
            // ultraLabel22
            // 
            appearance47.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel22.Appearance = appearance47;
            this.ultraLabel22.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel22.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel22.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel22.Location = new System.Drawing.Point(0, 4);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(219, 32);
            this.ultraLabel22.TabIndex = 569;
            // 
            // ultraLabel23
            // 
            appearance186.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel23.Appearance = appearance186;
            this.ultraLabel23.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel23.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel23.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel23.Location = new System.Drawing.Point(0, 35);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(219, 34);
            this.ultraLabel23.TabIndex = 570;
            // 
            // SalesInfo_Pnl
            // 
            this.SalesInfo_Pnl.Controls.Add(this.OfsThisTimeSales_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel37);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel40);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel38);
            this.SalesInfo_Pnl.Controls.Add(this.Label101);
            this.SalesInfo_Pnl.Controls.Add(this.RowSalesTotal_Tittle_Label);
            this.SalesInfo_Pnl.Controls.Add(this.Paym_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.Sales_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.DisTotal_Label);
            this.SalesInfo_Pnl.Controls.Add(this.RetTotal_Label);
            this.SalesInfo_Pnl.Controls.Add(this.StockSlipCount_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.SalesTotal_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ColSalesTotal_Tittle_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedTaxFree_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedOutTax_Tittle_Label);
            this.SalesInfo_Pnl.Controls.Add(this.SalesPaymInfo_Title_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel33);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedRetTaxFree_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel34);
            this.SalesInfo_Pnl.Controls.Add(this.OfsThisTimeSalesTaxInc_Label);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel35);
            this.SalesInfo_Pnl.Controls.Add(this.OfsThisStockTax_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedOffsetTaxFree_Label);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedDisTaxFree_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.ItdedOffsetOutTax_Label);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedRetOutTax_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedDisOutTax_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel43);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedStcTaxFree_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel55);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel57);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel58);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel59);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel60);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel61);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel64);
            this.SalesInfo_Pnl.Controls.Add(this.TtlItdedStcOutTax_tNedit);
            this.SalesInfo_Pnl.Controls.Add(this.ultraLabel56);
            this.SalesInfo_Pnl.Location = new System.Drawing.Point(4, 1);
            this.SalesInfo_Pnl.Name = "SalesInfo_Pnl";
            this.SalesInfo_Pnl.Size = new System.Drawing.Size(427, 292);
            this.SalesInfo_Pnl.TabIndex = 0;
            // 
            // OfsThisTimeSales_Label
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance39.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance39.TextHAlignAsString = "Right";
            appearance39.TextVAlignAsString = "Middle";
            this.OfsThisTimeSales_Label.Appearance = appearance39;
            this.OfsThisTimeSales_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.OfsThisTimeSales_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OfsThisTimeSales_Label.Location = new System.Drawing.Point(317, 162);
            this.OfsThisTimeSales_Label.Name = "OfsThisTimeSales_Label";
            this.OfsThisTimeSales_Label.Size = new System.Drawing.Size(101, 22);
            this.OfsThisTimeSales_Label.TabIndex = 638;
            // 
            // ultraLabel37
            // 
            appearance126.TextHAlignAsString = "Left";
            appearance126.TextVAlignAsString = "Middle";
            this.ultraLabel37.Appearance = appearance126;
            this.ultraLabel37.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel37.Location = new System.Drawing.Point(5, 227);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(86, 22);
            this.ultraLabel37.TabIndex = 637;
            this.ultraLabel37.Text = "税込金額";
            // 
            // ultraLabel40
            // 
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.ultraLabel40.Appearance = appearance32;
            this.ultraLabel40.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel40.Location = new System.Drawing.Point(5, 193);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(86, 22);
            this.ultraLabel40.TabIndex = 636;
            this.ultraLabel40.Text = "消費税額";
            // 
            // ultraLabel38
            // 
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel38.Appearance = appearance33;
            this.ultraLabel38.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel38.Location = new System.Drawing.Point(5, 162);
            this.ultraLabel38.Name = "ultraLabel38";
            this.ultraLabel38.Size = new System.Drawing.Size(86, 22);
            this.ultraLabel38.TabIndex = 635;
            this.ultraLabel38.Text = "合計";
            // 
            // Label101
            // 
            appearance155.TextHAlignAsString = "Left";
            appearance155.TextVAlignAsString = "Middle";
            this.Label101.Appearance = appearance155;
            this.Label101.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label101.Location = new System.Drawing.Point(5, 263);
            this.Label101.Name = "Label101";
            this.Label101.Size = new System.Drawing.Size(86, 22);
            this.Label101.TabIndex = 634;
            this.Label101.Text = "仕入伝票枚数";
            // 
            // RowSalesTotal_Tittle_Label
            // 
            appearance28.TextHAlignAsString = "Left";
            appearance28.TextVAlignAsString = "Middle";
            this.RowSalesTotal_Tittle_Label.Appearance = appearance28;
            this.RowSalesTotal_Tittle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RowSalesTotal_Tittle_Label.Location = new System.Drawing.Point(5, 128);
            this.RowSalesTotal_Tittle_Label.Name = "RowSalesTotal_Tittle_Label";
            this.RowSalesTotal_Tittle_Label.Size = new System.Drawing.Size(86, 22);
            this.RowSalesTotal_Tittle_Label.TabIndex = 633;
            this.RowSalesTotal_Tittle_Label.Text = "値引";
            // 
            // Paym_Title_Label
            // 
            appearance66.TextHAlignAsString = "Left";
            appearance66.TextVAlignAsString = "Middle";
            this.Paym_Title_Label.Appearance = appearance66;
            this.Paym_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Paym_Title_Label.Location = new System.Drawing.Point(4, 97);
            this.Paym_Title_Label.Name = "Paym_Title_Label";
            this.Paym_Title_Label.Size = new System.Drawing.Size(86, 22);
            this.Paym_Title_Label.TabIndex = 632;
            this.Paym_Title_Label.Text = "返品";
            // 
            // Sales_Title_Label
            // 
            appearance170.TextHAlignAsString = "Left";
            appearance170.TextVAlignAsString = "Middle";
            this.Sales_Title_Label.Appearance = appearance170;
            this.Sales_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Sales_Title_Label.Location = new System.Drawing.Point(5, 66);
            this.Sales_Title_Label.Name = "Sales_Title_Label";
            this.Sales_Title_Label.Size = new System.Drawing.Size(85, 22);
            this.Sales_Title_Label.TabIndex = 631;
            this.Sales_Title_Label.Text = "仕入";
            // 
            // DisTotal_Label
            // 
            appearance171.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance171.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance171.TextHAlignAsString = "Right";
            appearance171.TextVAlignAsString = "Middle";
            this.DisTotal_Label.Appearance = appearance171;
            this.DisTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DisTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DisTotal_Label.Location = new System.Drawing.Point(317, 128);
            this.DisTotal_Label.Name = "DisTotal_Label";
            this.DisTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.DisTotal_Label.TabIndex = 630;
            // 
            // RetTotal_Label
            // 
            appearance108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance108.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance108.TextHAlignAsString = "Right";
            appearance108.TextVAlignAsString = "Middle";
            this.RetTotal_Label.Appearance = appearance108;
            this.RetTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.RetTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RetTotal_Label.Location = new System.Drawing.Point(317, 97);
            this.RetTotal_Label.Name = "RetTotal_Label";
            this.RetTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.RetTotal_Label.TabIndex = 629;
            // 
            // StockSlipCount_tNedit
            // 
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance132.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance132.ForeColorDisabled = System.Drawing.Color.Black;
            appearance132.TextHAlignAsString = "Right";
            this.StockSlipCount_tNedit.ActiveAppearance = appearance132;
            appearance135.BackColor = System.Drawing.Color.White;
            appearance135.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance135.ForeColor = System.Drawing.Color.Black;
            appearance135.ForeColorDisabled = System.Drawing.Color.Black;
            appearance135.TextHAlignAsString = "Right";
            this.StockSlipCount_tNedit.Appearance = appearance135;
            this.StockSlipCount_tNedit.AutoSelect = true;
            this.StockSlipCount_tNedit.BackColor = System.Drawing.Color.White;
            this.StockSlipCount_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.StockSlipCount_tNedit.DataText = "";
            this.StockSlipCount_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.StockSlipCount_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.StockSlipCount_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StockSlipCount_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.StockSlipCount_tNedit.Location = new System.Drawing.Point(95, 263);
            this.StockSlipCount_tNedit.MaxLength = 13;
            this.StockSlipCount_tNedit.Name = "StockSlipCount_tNedit";
            this.StockSlipCount_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.StockSlipCount_tNedit.Size = new System.Drawing.Size(101, 22);
            this.StockSlipCount_tNedit.TabIndex = 7;
            // 
            // SalesTotal_Label
            // 
            appearance158.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance158.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance158.TextHAlignAsString = "Right";
            appearance158.TextVAlignAsString = "Middle";
            this.SalesTotal_Label.Appearance = appearance158;
            this.SalesTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SalesTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesTotal_Label.Location = new System.Drawing.Point(317, 66);
            this.SalesTotal_Label.Name = "SalesTotal_Label";
            this.SalesTotal_Label.Size = new System.Drawing.Size(101, 22);
            this.SalesTotal_Label.TabIndex = 628;
            // 
            // ColSalesTotal_Tittle_Label
            // 
            appearance163.TextHAlignAsString = "Center";
            appearance163.TextVAlignAsString = "Middle";
            this.ColSalesTotal_Tittle_Label.Appearance = appearance163;
            this.ColSalesTotal_Tittle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColSalesTotal_Tittle_Label.Location = new System.Drawing.Point(317, 35);
            this.ColSalesTotal_Tittle_Label.Name = "ColSalesTotal_Tittle_Label";
            this.ColSalesTotal_Tittle_Label.Size = new System.Drawing.Size(101, 25);
            this.ColSalesTotal_Tittle_Label.TabIndex = 627;
            this.ColSalesTotal_Tittle_Label.Text = "合計";
            // 
            // ItdedTaxFree_Title_Label
            // 
            appearance180.TextHAlignAsString = "Center";
            appearance180.TextVAlignAsString = "Middle";
            this.ItdedTaxFree_Title_Label.Appearance = appearance180;
            this.ItdedTaxFree_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedTaxFree_Title_Label.Location = new System.Drawing.Point(202, 35);
            this.ItdedTaxFree_Title_Label.Name = "ItdedTaxFree_Title_Label";
            this.ItdedTaxFree_Title_Label.Size = new System.Drawing.Size(101, 25);
            this.ItdedTaxFree_Title_Label.TabIndex = 626;
            this.ItdedTaxFree_Title_Label.Text = "非課税対象額";
            // 
            // ItdedOutTax_Tittle_Label
            // 
            appearance164.TextHAlignAsString = "Center";
            appearance164.TextVAlignAsString = "Middle";
            this.ItdedOutTax_Tittle_Label.Appearance = appearance164;
            this.ItdedOutTax_Tittle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedOutTax_Tittle_Label.Location = new System.Drawing.Point(95, 35);
            this.ItdedOutTax_Tittle_Label.Name = "ItdedOutTax_Tittle_Label";
            this.ItdedOutTax_Tittle_Label.Size = new System.Drawing.Size(101, 25);
            this.ItdedOutTax_Tittle_Label.TabIndex = 625;
            this.ItdedOutTax_Tittle_Label.Text = "課税対象額";
            // 
            // SalesPaymInfo_Title_Label
            // 
            appearance156.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance156.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance156.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance156.BorderColor = System.Drawing.Color.Black;
            appearance156.TextHAlignAsString = "Center";
            appearance156.TextVAlignAsString = "Middle";
            this.SalesPaymInfo_Title_Label.Appearance = appearance156;
            this.SalesPaymInfo_Title_Label.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.SalesPaymInfo_Title_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SalesPaymInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesPaymInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.SalesPaymInfo_Title_Label.Name = "SalesPaymInfo_Title_Label";
            this.SalesPaymInfo_Title_Label.Size = new System.Drawing.Size(413, 24);
            this.SalesPaymInfo_Title_Label.TabIndex = 624;
            this.SalesPaymInfo_Title_Label.Text = "仕入情報";
            // 
            // ultraLabel33
            // 
            appearance159.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel33.Appearance = appearance159;
            this.ultraLabel33.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel33.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel33.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel33.Location = new System.Drawing.Point(0, 219);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(423, 4);
            this.ultraLabel33.TabIndex = 620;
            // 
            // TtlItdedRetTaxFree_tNedit
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance56.ForeColorDisabled = System.Drawing.Color.Black;
            appearance56.TextHAlignAsString = "Right";
            this.TtlItdedRetTaxFree_tNedit.ActiveAppearance = appearance56;
            appearance76.BackColor = System.Drawing.Color.White;
            appearance76.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance76.ForeColor = System.Drawing.Color.Black;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            appearance76.TextHAlignAsString = "Right";
            this.TtlItdedRetTaxFree_tNedit.Appearance = appearance76;
            this.TtlItdedRetTaxFree_tNedit.AutoSelect = true;
            this.TtlItdedRetTaxFree_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedRetTaxFree_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedRetTaxFree_tNedit.DataText = "";
            this.TtlItdedRetTaxFree_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedRetTaxFree_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedRetTaxFree_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedRetTaxFree_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedRetTaxFree_tNedit.Location = new System.Drawing.Point(202, 97);
            this.TtlItdedRetTaxFree_tNedit.MaxLength = 13;
            this.TtlItdedRetTaxFree_tNedit.Name = "TtlItdedRetTaxFree_tNedit";
            this.TtlItdedRetTaxFree_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedRetTaxFree_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedRetTaxFree_tNedit.TabIndex = 4;
            this.TtlItdedRetTaxFree_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedRetTaxFree_tNedit.Leave += new System.EventHandler(this.Ret_tNedit_Leave);
            this.TtlItdedRetTaxFree_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedRetTaxFree_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // ultraLabel34
            // 
            appearance36.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel34.Appearance = appearance36;
            this.ultraLabel34.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel34.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel34.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel34.Location = new System.Drawing.Point(0, 154);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(423, 4);
            this.ultraLabel34.TabIndex = 605;
            // 
            // OfsThisTimeSalesTaxInc_Label
            // 
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance124.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance124.TextHAlignAsString = "Right";
            appearance124.TextVAlignAsString = "Middle";
            this.OfsThisTimeSalesTaxInc_Label.Appearance = appearance124;
            this.OfsThisTimeSalesTaxInc_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.OfsThisTimeSalesTaxInc_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OfsThisTimeSalesTaxInc_Label.Location = new System.Drawing.Point(317, 227);
            this.OfsThisTimeSalesTaxInc_Label.Name = "OfsThisTimeSalesTaxInc_Label";
            this.OfsThisTimeSalesTaxInc_Label.Size = new System.Drawing.Size(101, 22);
            this.OfsThisTimeSalesTaxInc_Label.TabIndex = 623;
            // 
            // ultraLabel35
            // 
            appearance130.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel35.Appearance = appearance130;
            this.ultraLabel35.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel35.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel35.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel35.Location = new System.Drawing.Point(308, 33);
            this.ultraLabel35.Name = "ultraLabel35";
            this.ultraLabel35.Size = new System.Drawing.Size(4, 221);
            this.ultraLabel35.TabIndex = 610;
            // 
            // OfsThisStockTax_tNedit
            // 
            appearance122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance122.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance122.ForeColorDisabled = System.Drawing.Color.Black;
            appearance122.TextHAlignAsString = "Right";
            this.OfsThisStockTax_tNedit.ActiveAppearance = appearance122;
            appearance123.BackColor = System.Drawing.Color.White;
            appearance123.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance123.ForeColor = System.Drawing.Color.Black;
            appearance123.ForeColorDisabled = System.Drawing.Color.Black;
            appearance123.TextHAlignAsString = "Right";
            this.OfsThisStockTax_tNedit.Appearance = appearance123;
            this.OfsThisStockTax_tNedit.AutoSelect = true;
            this.OfsThisStockTax_tNedit.BackColor = System.Drawing.Color.White;
            this.OfsThisStockTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.OfsThisStockTax_tNedit.DataText = "";
            this.OfsThisStockTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OfsThisStockTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.OfsThisStockTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OfsThisStockTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.OfsThisStockTax_tNedit.Location = new System.Drawing.Point(317, 193);
            this.OfsThisStockTax_tNedit.MaxLength = 13;
            this.OfsThisStockTax_tNedit.Name = "OfsThisStockTax_tNedit";
            this.OfsThisStockTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.OfsThisStockTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OfsThisStockTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.OfsThisStockTax_tNedit.TabIndex = 6;
            this.OfsThisStockTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.OfsThisStockTax_tNedit.Leave += new System.EventHandler(this.OfsThisStockTax_tNedit_Leave);
            this.OfsThisStockTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.OfsThisStockTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // ItdedOffsetTaxFree_Label
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance34.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance34.TextHAlignAsString = "Right";
            appearance34.TextVAlignAsString = "Middle";
            this.ItdedOffsetTaxFree_Label.Appearance = appearance34;
            this.ItdedOffsetTaxFree_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ItdedOffsetTaxFree_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedOffsetTaxFree_Label.Location = new System.Drawing.Point(202, 162);
            this.ItdedOffsetTaxFree_Label.Name = "ItdedOffsetTaxFree_Label";
            this.ItdedOffsetTaxFree_Label.Size = new System.Drawing.Size(101, 22);
            this.ItdedOffsetTaxFree_Label.TabIndex = 614;
            // 
            // TtlItdedDisTaxFree_tNedit
            // 
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance113.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance113.ForeColorDisabled = System.Drawing.Color.Black;
            appearance113.TextHAlignAsString = "Right";
            this.TtlItdedDisTaxFree_tNedit.ActiveAppearance = appearance113;
            appearance114.BackColor = System.Drawing.Color.White;
            appearance114.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance114.ForeColor = System.Drawing.Color.Black;
            appearance114.ForeColorDisabled = System.Drawing.Color.Black;
            appearance114.TextHAlignAsString = "Right";
            this.TtlItdedDisTaxFree_tNedit.Appearance = appearance114;
            this.TtlItdedDisTaxFree_tNedit.AutoSelect = true;
            this.TtlItdedDisTaxFree_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedDisTaxFree_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedDisTaxFree_tNedit.DataText = "";
            this.TtlItdedDisTaxFree_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedDisTaxFree_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedDisTaxFree_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedDisTaxFree_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedDisTaxFree_tNedit.Location = new System.Drawing.Point(202, 128);
            this.TtlItdedDisTaxFree_tNedit.MaxLength = 13;
            this.TtlItdedDisTaxFree_tNedit.Name = "TtlItdedDisTaxFree_tNedit";
            this.TtlItdedDisTaxFree_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedDisTaxFree_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedDisTaxFree_tNedit.TabIndex = 5;
            this.TtlItdedDisTaxFree_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedDisTaxFree_tNedit.Leave += new System.EventHandler(this.Dis_tNedit_Leave);
            this.TtlItdedDisTaxFree_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedDisTaxFree_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // ItdedOffsetOutTax_Label
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance91.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance91.TextHAlignAsString = "Right";
            appearance91.TextVAlignAsString = "Middle";
            this.ItdedOffsetOutTax_Label.Appearance = appearance91;
            this.ItdedOffsetOutTax_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ItdedOffsetOutTax_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedOffsetOutTax_Label.Location = new System.Drawing.Point(95, 162);
            this.ItdedOffsetOutTax_Label.Name = "ItdedOffsetOutTax_Label";
            this.ItdedOffsetOutTax_Label.Size = new System.Drawing.Size(101, 22);
            this.ItdedOffsetOutTax_Label.TabIndex = 609;
            // 
            // TtlItdedRetOutTax_tNedit
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance111.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance111.ForeColorDisabled = System.Drawing.Color.Black;
            appearance111.TextHAlignAsString = "Right";
            this.TtlItdedRetOutTax_tNedit.ActiveAppearance = appearance111;
            appearance112.BackColor = System.Drawing.Color.White;
            appearance112.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance112.ForeColor = System.Drawing.Color.Black;
            appearance112.ForeColorDisabled = System.Drawing.Color.Black;
            appearance112.TextHAlignAsString = "Right";
            this.TtlItdedRetOutTax_tNedit.Appearance = appearance112;
            this.TtlItdedRetOutTax_tNedit.AutoSelect = true;
            this.TtlItdedRetOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedRetOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedRetOutTax_tNedit.DataText = "";
            this.TtlItdedRetOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedRetOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedRetOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedRetOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedRetOutTax_tNedit.Location = new System.Drawing.Point(95, 97);
            this.TtlItdedRetOutTax_tNedit.MaxLength = 13;
            this.TtlItdedRetOutTax_tNedit.Name = "TtlItdedRetOutTax_tNedit";
            this.TtlItdedRetOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedRetOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlItdedRetOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedRetOutTax_tNedit.TabIndex = 1;
            this.TtlItdedRetOutTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedRetOutTax_tNedit.Leave += new System.EventHandler(this.Ret_tNedit_Leave);
            this.TtlItdedRetOutTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedRetOutTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedDisOutTax_tNedit
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextHAlignAsString = "Right";
            this.TtlItdedDisOutTax_tNedit.ActiveAppearance = appearance59;
            appearance60.BackColor = System.Drawing.Color.White;
            appearance60.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.ForeColorDisabled = System.Drawing.Color.Black;
            appearance60.TextHAlignAsString = "Right";
            this.TtlItdedDisOutTax_tNedit.Appearance = appearance60;
            this.TtlItdedDisOutTax_tNedit.AutoSelect = true;
            this.TtlItdedDisOutTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedDisOutTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedDisOutTax_tNedit.DataText = "";
            this.TtlItdedDisOutTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedDisOutTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedDisOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedDisOutTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedDisOutTax_tNedit.Location = new System.Drawing.Point(95, 128);
            this.TtlItdedDisOutTax_tNedit.MaxLength = 13;
            this.TtlItdedDisOutTax_tNedit.Name = "TtlItdedDisOutTax_tNedit";
            this.TtlItdedDisOutTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedDisOutTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlItdedDisOutTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedDisOutTax_tNedit.TabIndex = 2;
            this.TtlItdedDisOutTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedDisOutTax_tNedit.Leave += new System.EventHandler(this.Dis_tNedit_Leave);
            this.TtlItdedDisOutTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedDisOutTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // ultraLabel43
            // 
            appearance188.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel43.Appearance = appearance188;
            this.ultraLabel43.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel43.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel43.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel43.Location = new System.Drawing.Point(0, 258);
            this.ultraLabel43.Name = "ultraLabel43";
            this.ultraLabel43.Size = new System.Drawing.Size(204, 32);
            this.ultraLabel43.TabIndex = 606;
            // 
            // ultraLabel55
            // 
            appearance181.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel55.Appearance = appearance181;
            this.ultraLabel55.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel55.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel55.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel55.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel55.Name = "ultraLabel55";
            this.ultraLabel55.Size = new System.Drawing.Size(423, 34);
            this.ultraLabel55.TabIndex = 598;
            // 
            // ultraLabel57
            // 
            appearance184.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel57.Appearance = appearance184;
            this.ultraLabel57.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel57.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel57.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel57.Location = new System.Drawing.Point(0, 92);
            this.ultraLabel57.Name = "ultraLabel57";
            this.ultraLabel57.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel57.TabIndex = 601;
            // 
            // ultraLabel58
            // 
            appearance187.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel58.Appearance = appearance187;
            this.ultraLabel58.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel58.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel58.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel58.Location = new System.Drawing.Point(0, 123);
            this.ultraLabel58.Name = "ultraLabel58";
            this.ultraLabel58.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel58.TabIndex = 603;
            // 
            // ultraLabel59
            // 
            appearance35.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel59.Appearance = appearance35;
            this.ultraLabel59.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel59.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel59.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel59.Location = new System.Drawing.Point(0, 157);
            this.ultraLabel59.Name = "ultraLabel59";
            this.ultraLabel59.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel59.TabIndex = 604;
            // 
            // ultraLabel60
            // 
            appearance38.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel60.Appearance = appearance38;
            this.ultraLabel60.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel60.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel60.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel60.Location = new System.Drawing.Point(0, 188);
            this.ultraLabel60.Name = "ultraLabel60";
            this.ultraLabel60.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel60.TabIndex = 619;
            // 
            // ultraLabel61
            // 
            appearance57.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel61.Appearance = appearance57;
            this.ultraLabel61.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel61.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel61.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel61.Location = new System.Drawing.Point(0, 222);
            this.ultraLabel61.Name = "ultraLabel61";
            this.ultraLabel61.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel61.TabIndex = 622;
            // 
            // ultraLabel64
            // 
            appearance182.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel64.Appearance = appearance182;
            this.ultraLabel64.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel64.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel64.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel64.Location = new System.Drawing.Point(0, 32);
            this.ultraLabel64.Name = "ultraLabel64";
            this.ultraLabel64.Size = new System.Drawing.Size(423, 30);
            this.ultraLabel64.TabIndex = 599;
            // 
            // ultraLabel56
            // 
            appearance183.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel56.Appearance = appearance183;
            this.ultraLabel56.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel56.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel56.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel56.Location = new System.Drawing.Point(0, 61);
            this.ultraLabel56.Name = "ultraLabel56";
            this.ultraLabel56.Size = new System.Drawing.Size(423, 32);
            this.ultraLabel56.TabIndex = 600;
            // 
            // SuplierPay_panel
            // 
            this.SuplierPay_panel.Controls.Add(this.PaymentCondValue_tNedit);
            this.SuplierPay_panel.Controls.Add(this.PaymentCond_Label);
            this.SuplierPay_panel.Controls.Add(this.ultraLabel52);
            this.SuplierPay_panel.Controls.Add(this.PaymentSchedule_tDateEdit);
            this.SuplierPay_panel.Controls.Add(this.ultraLabel50);
            this.SuplierPay_panel.Controls.Add(this.ultraLabel49);
            this.SuplierPay_panel.Controls.Add(this.ultraLabel1);
            this.SuplierPay_panel.Controls.Add(this.ultraLabel39);
            this.SuplierPay_panel.Controls.Add(this.ultraLabel9);
            this.SuplierPay_panel.Location = new System.Drawing.Point(4, 293);
            this.SuplierPay_panel.Name = "SuplierPay_panel";
            this.SuplierPay_panel.Size = new System.Drawing.Size(263, 111);
            this.SuplierPay_panel.TabIndex = 3;
            // 
            // PaymentCondValue_tNedit
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance62.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance62.ForeColorDisabled = System.Drawing.Color.Black;
            appearance62.TextHAlignAsString = "Right";
            this.PaymentCondValue_tNedit.ActiveAppearance = appearance62;
            appearance63.BackColor = System.Drawing.Color.White;
            appearance63.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance63.ForeColor = System.Drawing.Color.Black;
            appearance63.ForeColorDisabled = System.Drawing.Color.Black;
            appearance63.TextHAlignAsString = "Right";
            this.PaymentCondValue_tNedit.Appearance = appearance63;
            this.PaymentCondValue_tNedit.AutoSelect = true;
            this.PaymentCondValue_tNedit.BackColor = System.Drawing.Color.White;
            this.PaymentCondValue_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PaymentCondValue_tNedit.DataText = "";
            this.PaymentCondValue_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PaymentCondValue_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 0, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.PaymentCondValue_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PaymentCondValue_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PaymentCondValue_tNedit.Location = new System.Drawing.Point(230, 74);
            this.PaymentCondValue_tNedit.MaxLength = 0;
            this.PaymentCondValue_tNedit.Name = "PaymentCondValue_tNedit";
            this.PaymentCondValue_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PaymentCondValue_tNedit.Size = new System.Drawing.Size(11, 22);
            this.PaymentCondValue_tNedit.TabIndex = 28;
            this.PaymentCondValue_tNedit.Visible = false;
            // 
            // PaymentCond_Label
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance64.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance64.TextHAlignAsString = "Left";
            appearance64.TextVAlignAsString = "Middle";
            this.PaymentCond_Label.Appearance = appearance64;
            this.PaymentCond_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.PaymentCond_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PaymentCond_Label.Location = new System.Drawing.Point(95, 73);
            this.PaymentCond_Label.Name = "PaymentCond_Label";
            this.PaymentCond_Label.Size = new System.Drawing.Size(117, 22);
            this.PaymentCond_Label.TabIndex = 28;
            this.PaymentCond_Label.WrapText = false;
            // 
            // ultraLabel52
            // 
            appearance65.TextHAlignAsString = "Left";
            appearance65.TextVAlignAsString = "Middle";
            this.ultraLabel52.Appearance = appearance65;
            this.ultraLabel52.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel52.Location = new System.Drawing.Point(5, 73);
            this.ultraLabel52.Name = "ultraLabel52";
            this.ultraLabel52.Size = new System.Drawing.Size(84, 22);
            this.ultraLabel52.TabIndex = 569;
            this.ultraLabel52.Text = "支払条件";
            // 
            // PaymentSchedule_tDateEdit
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance68.ForeColor = System.Drawing.Color.Black;
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            this.PaymentSchedule_tDateEdit.ActiveEditAppearance = appearance68;
            this.PaymentSchedule_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.PaymentSchedule_tDateEdit.CalendarDisp = true;
            appearance69.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.ForeColorDisabled = System.Drawing.Color.Black;
            appearance69.TextHAlignAsString = "Left";
            appearance69.TextVAlignAsString = "Middle";
            this.PaymentSchedule_tDateEdit.EditAppearance = appearance69;
            this.PaymentSchedule_tDateEdit.Enabled = false;
            this.PaymentSchedule_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.PaymentSchedule_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PaymentSchedule_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PaymentSchedule_tDateEdit.ForeColor = System.Drawing.Color.Black;
            appearance70.ForeColor = System.Drawing.Color.Black;
            appearance70.ForeColorDisabled = System.Drawing.Color.Black;
            appearance70.TextHAlignAsString = "Left";
            appearance70.TextVAlignAsString = "Middle";
            this.PaymentSchedule_tDateEdit.LabelAppearance = appearance70;
            this.PaymentSchedule_tDateEdit.Location = new System.Drawing.Point(95, 40);
            this.PaymentSchedule_tDateEdit.Name = "PaymentSchedule_tDateEdit";
            this.PaymentSchedule_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.PaymentSchedule_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.PaymentSchedule_tDateEdit.Size = new System.Drawing.Size(156, 22);
            this.PaymentSchedule_tDateEdit.TabIndex = 0;
            this.PaymentSchedule_tDateEdit.TabStop = true;
            this.PaymentSchedule_tDateEdit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.PaymentSchedule_tDateEdit.Enter += new System.EventHandler(this.Control_Enter);
            this.PaymentSchedule_tDateEdit.Leave += new System.EventHandler(this.DateEdit_Leave);
            // 
            // ultraLabel50
            // 
            appearance67.TextHAlignAsString = "Left";
            appearance67.TextVAlignAsString = "Middle";
            this.ultraLabel50.Appearance = appearance67;
            this.ultraLabel50.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel50.Location = new System.Drawing.Point(5, 40);
            this.ultraLabel50.Name = "ultraLabel50";
            this.ultraLabel50.Size = new System.Drawing.Size(84, 22);
            this.ultraLabel50.TabIndex = 564;
            this.ultraLabel50.Text = "支払予定日";
            // 
            // ultraLabel49
            // 
            appearance74.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel49.Appearance = appearance74;
            this.ultraLabel49.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel49.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel49.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel49.Location = new System.Drawing.Point(0, 34);
            this.ultraLabel49.Name = "ultraLabel49";
            this.ultraLabel49.Size = new System.Drawing.Size(256, 34);
            this.ultraLabel49.TabIndex = 562;
            // 
            // ultraLabel1
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance53.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance53.BorderColor = System.Drawing.Color.Black;
            appearance53.TextHAlignAsString = "Center";
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance53;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(5, 6);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(246, 24);
            this.ultraLabel1.TabIndex = 545;
            this.ultraLabel1.Text = "支払予定情報";
            // 
            // ultraLabel39
            // 
            appearance215.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel39.Appearance = appearance215;
            this.ultraLabel39.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel39.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel39.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel39.Location = new System.Drawing.Point(0, 1);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(256, 34);
            this.ultraLabel39.TabIndex = 544;
            // 
            // ultraLabel9
            // 
            appearance71.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel9.Appearance = appearance71;
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel9.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel9.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(0, 67);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(256, 34);
            this.ultraLabel9.TabIndex = 570;
            // 
            // TtlRetInnerTax_tNedit
            // 
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance101.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance101.ForeColorDisabled = System.Drawing.Color.Black;
            appearance101.TextHAlignAsString = "Right";
            this.TtlRetInnerTax_tNedit.ActiveAppearance = appearance101;
            appearance102.BackColor = System.Drawing.Color.White;
            appearance102.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance102.ForeColor = System.Drawing.Color.Black;
            appearance102.ForeColorDisabled = System.Drawing.Color.Black;
            appearance102.TextHAlignAsString = "Right";
            this.TtlRetInnerTax_tNedit.Appearance = appearance102;
            this.TtlRetInnerTax_tNedit.AutoSelect = true;
            this.TtlRetInnerTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlRetInnerTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlRetInnerTax_tNedit.DataText = "";
            this.TtlRetInnerTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlRetInnerTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlRetInnerTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlRetInnerTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlRetInnerTax_tNedit.Location = new System.Drawing.Point(750, 365);
            this.TtlRetInnerTax_tNedit.MaxLength = 13;
            this.TtlRetInnerTax_tNedit.Name = "TtlRetInnerTax_tNedit";
            this.TtlRetInnerTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlRetInnerTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlRetInnerTax_tNedit.TabIndex = 9;
            this.TtlRetInnerTax_tNedit.Visible = false;
            this.TtlRetInnerTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlRetInnerTax_tNedit.Leave += new System.EventHandler(this.Ret_tNedit_Leave);
            this.TtlRetInnerTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlRetInnerTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlRetOuterTax_tNedit
            // 
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance105.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance105.ForeColorDisabled = System.Drawing.Color.Black;
            appearance105.TextHAlignAsString = "Right";
            this.TtlRetOuterTax_tNedit.ActiveAppearance = appearance105;
            appearance106.BackColor = System.Drawing.Color.White;
            appearance106.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance106.ForeColor = System.Drawing.Color.Black;
            appearance106.ForeColorDisabled = System.Drawing.Color.Black;
            appearance106.TextHAlignAsString = "Right";
            this.TtlRetOuterTax_tNedit.Appearance = appearance106;
            this.TtlRetOuterTax_tNedit.AutoSelect = true;
            this.TtlRetOuterTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlRetOuterTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlRetOuterTax_tNedit.DataText = "";
            this.TtlRetOuterTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlRetOuterTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlRetOuterTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlRetOuterTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlRetOuterTax_tNedit.Location = new System.Drawing.Point(750, 300);
            this.TtlRetOuterTax_tNedit.MaxLength = 13;
            this.TtlRetOuterTax_tNedit.Name = "TtlRetOuterTax_tNedit";
            this.TtlRetOuterTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlRetOuterTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlRetOuterTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlRetOuterTax_tNedit.TabIndex = 7;
            this.TtlRetOuterTax_tNedit.Visible = false;
            this.TtlRetOuterTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlRetOuterTax_tNedit.Leave += new System.EventHandler(this.Ret_tNedit_Leave);
            this.TtlRetOuterTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlRetOuterTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedRetInTax_tNedit
            // 
            appearance109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance109.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance109.ForeColorDisabled = System.Drawing.Color.Black;
            appearance109.TextHAlignAsString = "Right";
            this.TtlItdedRetInTax_tNedit.ActiveAppearance = appearance109;
            appearance110.BackColor = System.Drawing.Color.White;
            appearance110.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance110.ForeColor = System.Drawing.Color.Black;
            appearance110.ForeColorDisabled = System.Drawing.Color.Black;
            appearance110.TextHAlignAsString = "Right";
            this.TtlItdedRetInTax_tNedit.Appearance = appearance110;
            this.TtlItdedRetInTax_tNedit.AutoSelect = true;
            this.TtlItdedRetInTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedRetInTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedRetInTax_tNedit.DataText = "";
            this.TtlItdedRetInTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedRetInTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedRetInTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedRetInTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedRetInTax_tNedit.Location = new System.Drawing.Point(750, 332);
            this.TtlItdedRetInTax_tNedit.MaxLength = 13;
            this.TtlItdedRetInTax_tNedit.Name = "TtlItdedRetInTax_tNedit";
            this.TtlItdedRetInTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedRetInTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedRetInTax_tNedit.TabIndex = 8;
            this.TtlItdedRetInTax_tNedit.Visible = false;
            this.TtlItdedRetInTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedRetInTax_tNedit.Leave += new System.EventHandler(this.Ret_tNedit_Leave);
            this.TtlItdedRetInTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedRetInTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlDisInnerTax_tNedit
            // 
            appearance115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance115.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance115.ForeColorDisabled = System.Drawing.Color.Black;
            appearance115.TextHAlignAsString = "Right";
            this.TtlDisInnerTax_tNedit.ActiveAppearance = appearance115;
            appearance216.BackColor = System.Drawing.Color.White;
            appearance216.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance216.ForeColor = System.Drawing.Color.Black;
            appearance216.ForeColorDisabled = System.Drawing.Color.Black;
            appearance216.TextHAlignAsString = "Right";
            this.TtlDisInnerTax_tNedit.Appearance = appearance216;
            this.TtlDisInnerTax_tNedit.AutoSelect = true;
            this.TtlDisInnerTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlDisInnerTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlDisInnerTax_tNedit.DataText = "";
            this.TtlDisInnerTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlDisInnerTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlDisInnerTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlDisInnerTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlDisInnerTax_tNedit.Location = new System.Drawing.Point(854, 365);
            this.TtlDisInnerTax_tNedit.MaxLength = 13;
            this.TtlDisInnerTax_tNedit.Name = "TtlDisInnerTax_tNedit";
            this.TtlDisInnerTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlDisInnerTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlDisInnerTax_tNedit.TabIndex = 15;
            this.TtlDisInnerTax_tNedit.Visible = false;
            this.TtlDisInnerTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlDisInnerTax_tNedit.Leave += new System.EventHandler(this.Dis_tNedit_Leave);
            this.TtlDisInnerTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlDisInnerTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlDisOuterTax_tNedit
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            appearance75.TextHAlignAsString = "Right";
            this.TtlDisOuterTax_tNedit.ActiveAppearance = appearance75;
            appearance26.BackColor = System.Drawing.Color.White;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Right";
            this.TtlDisOuterTax_tNedit.Appearance = appearance26;
            this.TtlDisOuterTax_tNedit.AutoSelect = true;
            this.TtlDisOuterTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlDisOuterTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlDisOuterTax_tNedit.DataText = "";
            this.TtlDisOuterTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlDisOuterTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlDisOuterTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlDisOuterTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlDisOuterTax_tNedit.Location = new System.Drawing.Point(854, 300);
            this.TtlDisOuterTax_tNedit.MaxLength = 13;
            this.TtlDisOuterTax_tNedit.Name = "TtlDisOuterTax_tNedit";
            this.TtlDisOuterTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlDisOuterTax_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TtlDisOuterTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlDisOuterTax_tNedit.TabIndex = 13;
            this.TtlDisOuterTax_tNedit.Visible = false;
            this.TtlDisOuterTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlDisOuterTax_tNedit.Leave += new System.EventHandler(this.Dis_tNedit_Leave);
            this.TtlDisOuterTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlDisOuterTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // TtlItdedDisInTax_tNedit
            // 
            appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance120.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance120.ForeColorDisabled = System.Drawing.Color.Black;
            appearance120.TextHAlignAsString = "Right";
            this.TtlItdedDisInTax_tNedit.ActiveAppearance = appearance120;
            appearance121.BackColor = System.Drawing.Color.White;
            appearance121.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance121.ForeColor = System.Drawing.Color.Black;
            appearance121.ForeColorDisabled = System.Drawing.Color.Black;
            appearance121.TextHAlignAsString = "Right";
            this.TtlItdedDisInTax_tNedit.Appearance = appearance121;
            this.TtlItdedDisInTax_tNedit.AutoSelect = true;
            this.TtlItdedDisInTax_tNedit.BackColor = System.Drawing.Color.White;
            this.TtlItdedDisInTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TtlItdedDisInTax_tNedit.DataText = "";
            this.TtlItdedDisInTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TtlItdedDisInTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 13, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TtlItdedDisInTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlItdedDisInTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TtlItdedDisInTax_tNedit.Location = new System.Drawing.Point(854, 332);
            this.TtlItdedDisInTax_tNedit.MaxLength = 13;
            this.TtlItdedDisInTax_tNedit.Name = "TtlItdedDisInTax_tNedit";
            this.TtlItdedDisInTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TtlItdedDisInTax_tNedit.Size = new System.Drawing.Size(101, 22);
            this.TtlItdedDisInTax_tNedit.TabIndex = 14;
            this.TtlItdedDisInTax_tNedit.Visible = false;
            this.TtlItdedDisInTax_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.TtlItdedDisInTax_tNedit.Leave += new System.EventHandler(this.Dis_tNedit_Leave);
            this.TtlItdedDisInTax_tNedit.Enter += new System.EventHandler(this.Control_Enter);
            this.TtlItdedDisInTax_tNedit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNedit_KeyPress);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // MAKAU09130UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(978, 660);
            this.Controls.Add(this.DmdSalesInfo_Panel);
            this.Controls.Add(this.CustomerInfo_Panel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKAU09130UB";
            this.Text = "仕入先実績修正";
            this.Load += new System.EventHandler(this.MAKAU09130UB_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKAU09130UB_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKAU09130UB_Closing);
            this.CustomerInfo_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_DemandInfo)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedStcOutTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedStcInTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMBl_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlStockOuterTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bf3TmBl_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bf2TmBl_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlStockInnerTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedStcTaxFree_tNedit)).EndInit();
            this.DmdSalesInfo_Panel.ResumeLayout(false);
            this.DmdSalesInfo_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetOutTax_tNedit)).EndInit();
            this.DepositInfo_Pnl.ResumeLayout(false);
            this.DepositInfo_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisNrml_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeeNrml_tNedit)).EndInit();
            this.LtBlInfo_Pnl.ResumeLayout(false);
            this.LtBlInfo_Pnl.PerformLayout();
            this.AjustInfo_Pnl.ResumeLayout(false);
            this.AjustInfo_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaxAdjust_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAdjust_tNedit)).EndInit();
            this.SalesInfo_Pnl.ResumeLayout(false);
            this.SalesInfo_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetTaxFree_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisTaxFree_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetOutTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisOutTax_tNedit)).EndInit();
            this.SuplierPay_panel.ResumeLayout(false);
            this.SuplierPay_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCondValue_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlRetInnerTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlRetOuterTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedRetInTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlDisInnerTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlDisOuterTax_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlItdedDisInTax_tNedit)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get{ return this._canLogicalDeleteDataExtraction; }
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get{ return this._canClose; }
			set{ this._canClose = value; }
		}

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get{ return this._canNew; }
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get{ return this._canDelete; }
		}

		/// <summary>グリッドのデフォルト表示位置プロパティ</summary>
		/// <value>グリッドのデフォルト表示位置を取得します。</value>
		public MGridDisplayLayout DefaultGridDisplayLayout
		{
			get{ return this._defaultGridDisplayLayout; }
		}

		/// <summary>操作対象データテーブル名称プロパティ</summary>
		/// <value>操作対象データのテーブル名称を取得または設定します。</value>
		public string TargetTableName
		{
			get{ return this._targetTableName; }
			set{ this._targetTableName = value; }
		}
		
		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int AccRecDataIndex
		{
			get{ return this._accRecDataIndex; }
			set{ this._accRecDataIndex = value; }
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DmdPrcDataIndex
		{
			get{ return this._dmdPrcDataIndex; }
			set{ this._dmdPrcDataIndex = value; }
		}

		/// <summary>メイングリッド列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>メイングリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToAccRecGridColumn
		{
			get{ return this._defaultAutoFillToAccRecGridColumn; }
		}

		/// <summary>明細グリッド列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>明細グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToDmdPrcGridColumn
		{
			get{ return this._defaultAutoFillToDmdPrcGridColumn; }
		}
		/// <summary>選択された拠点コードプロパティ</summary>
		/// <value>画面で選択された拠点コードを取得します。</value>
		public string SectionCodeData
		{
			get{ return this._sectionCode; }
			set{ this._sectionCode = value; }
		}
        ///// <summary>選択された仕入先コードプロパティ</summary>
        /// <value>画面で選択された仕入先コードを取得します。</value>
        public int TargetCustomerCode
        {
            get { return this._targetSupplierCode; }
            set { this._targetSupplierCode = value; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>選択された支払先コードプロパティ</summary>
        /// <value>画面で選択された支払先コードを取得します</value>
        public int TargetPayeeCode
        {
            get { return this._targetPayeeCode; }
            set { this._targetPayeeCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA ADD START
        /// <summary>指定区分設定プロパティ</summary>
        /// <value>設定画面上の「指定区分」プルダウンの値を設定します。</value>
        public int TargetDivType
        {
            get { return this._targetDivType; }
            set { this._targetDivType = value; }
        }

        /// <summary>検索用支払先コード</summary>
        /// <value>検索で使用する支払先コードを取得します。選択支払先コードは再検索時のみ使用</value>
        public int CondPayeeCode
        {
            get { return this._condPayeeCode; }
            set { this._condPayeeCode = value; }
        }

        /// <summary>検索用仕入先コード</summary>
        /// <value>検索で使用する仕入先コードを取得します。選択仕入先コードは再検索時のみ使用</value>
        public int CondSupplierCode
        {
            get { return this._condSupplierCode; }
            set { this._condSupplierCode = value; }
        }

        /// <summary>検索用計上拠点コード</summary>
        /// <value>検索で使用する計上拠点コードを取得します。選択拠点コードは再検索時のみ使用</value>
        public string CondSectionCode
        {
            get { return this._condSectionCode; }
            set { this._condSectionCode = value; }
        }

        /// <summary>検索用支払拠点コード</summary>
        /// <value>検索で使用する支払拠点コードを取得します。支払拠点コードは再検索時のみ使用</value>
        public string CondPaymentSectionCode
        {
            get { return this._condPaymentSectionCode; }
            set { this._condPaymentSectionCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.25 TOKUNAGA ADD END

		/// <summary>拠点情報画面を表示するかの有無プロパティ</summary>
		/// <value>拠点オプションを取得します。</value>
		public bool Opt_SectionInfo
		{
			get{ return this.Opt_Section; }
		}

		/// <summary>自拠点コードプロパティ</summary>
		/// <value>自拠点コードを取得します。</value>
		public string GetCompanySectionCode
		{
			get{ return this._companySecCode; }
		}
		/// <summary>本社機能フラグプロパティ</summary>
		/// <value>本社機能フラグを取得します。</value>
		public bool GetMainOfficeFuncMode
		{
			get{ return this._mainOfficeFuncFlag; }
		}

        // 2009.01.14 Add >>>
        public Form InvokerForm
        {
            get { return _invokerForm; }
            set { _invokerForm = value; }
        }
        // 2009.01.14 Add <<<

        // --- ADD 2012/09/18 ---------->>>>>
        /// <summary>仕入先総括オプション情報プロパティ</summary>
        /// <value>オプション情報を取得します。</value>
        public bool Opt_sumSuppEnable
        {
            get { return this._sumSuppEnable; }
            set { this._sumSuppEnable = value; }
        }
        // --- ADD 2012/09/18 ----------<<<<<
        # endregion

		// ===================================================================================== //
		// 外部メソッド
		// ===================================================================================== //
		# region Public Methods

		/// <summary>論理削除データ抽出可能設定リスト取得</summary>
		/// <returns>論理削除可否設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 論理削除データ抽出の可・不可をリストにて取得</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = false;     // 買掛
			blRet[1] = false;     // 支払
			return blRet;
		}

		/// <summary>自動列幅調整設定リスト取得</summary>
		/// <returns>自動列幅調整有無リスト</returns>
		/// <remarks>
		/// <br>Note       : 自動列幅調整の有無をリストにて取得</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetDefaultAutoFillToGridColumnList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;   
			blRet[1] = true;   
			return blRet;
		}

		/// <summary>新規ボタン表示設定リスト取得</summary>
		/// <returns>新規ボタン表示有無設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 新規ボタンの表示の有無設定をリストにて取得します</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;   
			blRet[1] = true;
			return blRet;
		}

		/// <summary>削除ボタン表示設定リスト取得</summary>
		/// <returns>削除ボタン表示有無設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 削除ボタンの表示の有無設定をリストにて取得します</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = false;  
			blRet[1] = false;
			
			return blRet;
		}

		/// <summary>修正ボタン表示設定リスト取得</summary>
		/// <returns>修正ボタン表示有無設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 修正ボタンの表示の有無設定をリストにて取得します</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;    
			blRet[1] = true;
			return blRet;
		}

		/// <summary>各テーブルタイトル取得</summary>
		/// <returns>各テーブルタイトル</returns>
		/// <remarks>
		/// <br>Note       : 各テーブル内容を表示するグリッドのタイトルを取得する</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public string[] GetGridTitleList()
		{
			string[] strRet = new string[2];
			strRet[0] = this._mainGridTitle;
			strRet[1] = this._detailsGridTitle;
			return strRet;
		}

		/// <summary>各テーブル表示アイコン取得</summary>
		/// <returns>各テーブル表示アイコン</returns>
		/// <remarks>
		/// <br>Note       : 各テーブル内容を表示するグリッドのアイコンを取得する</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public Image[] GetGridIconList()
		{
			Image[] objRet = new Image[2];
			objRet[0] = this._mainGridIcon;
			objRet[1] = this._detailsGridIcon;
			return objRet;
		}

		/// <summary>データ削除処理</summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int Delete()
		{
			// 未実装
			return 0;
		}

		/// <summary>印刷処理</summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}
	
		/// <summary>グリッド列外観情報取得処理</summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			appearanceTable = new Hashtable[2];
			// 買掛グリッドの列外観情報設定
			Hashtable	accTable = new Hashtable();

			// Addを行う順番が、列の表示順位となります。
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accTable.Add( SuplAccPayAcs.COL_CREATEDATETIME, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            accTable.Add( SuplAccPayAcs.COL_UPDATEDATETIME, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(SuplAccPayAcs.COL_DELETEDATE_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ADDUPSECCODE_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            accTable.Add(SuplAccPayAcs.COL_SUPPLIERCODE_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_SUPPLIERNAME_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_SUPPLIERNAME2_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accTable.Add(SuplAccPayAcs.COL_SUPPLIERSNM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END
            accTable.Add(SuplAccPayAcs.COL_PAYEECODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_PAYEENAME_TITLE,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_PAYEENAME2_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_PAYEESNM_TITLE,             new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(SuplAccPayAcs.COL_ADDUPDATE_TITLE,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ADDUPYEARMONTH_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ADDUPDATEJP_TITLE,          new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ADDUPYEARMONTHJP_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_THISTIMEPAYNRML_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_THISTIMEFEEPAYNRML_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_THISTIMEDISPAYNRML_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //accTable.Add(SuplAccPayAcs.COL_THISTIMERBTDMDNRML_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_THISTIMEDMDDEPO_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_THISTIMEFEEDMDDEPO_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_THISTIMEDISDMDDEPO_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_THISTIMERBTDMDDEPO_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(SuplAccPayAcs.COL_THISTIMETTLBLCACPAY_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_THISNETSTCKPRICE_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_THISNETSTCPRCTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ITDEDOFFSETOUTTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ITDEDOFFSETINTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ITDEDOFFSETTAXFREE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_OFFSETOUTTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_OFFSETINTAX_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ITDEDSTCOUTTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ITDEDSTCINTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_ITDEDSTCTAXFREE_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLSTOCKOUTERTAX_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLSTOCKINNERTAX_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //accTable.Add(SuplAccPayAcs.COL_ITDEDPAYMOUTTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_ITDEDPAYMINTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_ITDEDPAYMTAXFREE_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_PAYMENTOUTTAX_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_PAYMENTINTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(SuplAccPayAcs.COL_SUPPCTAXLAYCD_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_SUPPLIERCONSTAXRATE_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_FRACTIONPROCCD_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_MONTHADDUPEXPDATE_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_GUID_TITLE,                 new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            // 2009.01.14 Del >>>
            //accTable.Add(SuplAccPayAcs.COL_STCKTTL3TMBFBLACCPAY_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_STCKTTL2TMBFBLACCPAY_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            accTable.Add(SuplAccPayAcs.COL_STCKTTL3TMBFBLACCPAY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_STCKTTL2TMBFBLACCPAY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.14 Del <<<
            accTable.Add(SuplAccPayAcs.COL_LASTTIMEACCPAY_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_THISTIMESTOCKPRICE_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_THISSTCPRCTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accTable.Add(SuplAccPayAcs.COL_OFSTHISTIMESTOCK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_OFSTHISSTOCKTAX_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //accTable.Add(SuplAccPayAcs.COL_TTLINCDTBTTAXEXC_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_TTLINCDTBTTAX_TITLE,        new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            accTable.Add(SuplAccPayAcs.COL_TTLITDEDRETOUTTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLITDEDRETINTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLITDEDRETTAXFREE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLRETOUTERTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLRETINNERTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLITDEDDISOUTTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLITDEDDISINTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLITDEDDISTAXFREE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLDISOUTERTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TTLDISINNERTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            //accTable.Add( SuplAccPayAcs.COL_THISRECVOFFSET_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( SuplAccPayAcs.COL_THISRECVOFFSETTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( SuplAccPayAcs.COL_THISRECVOUTTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( SuplAccPayAcs.COL_THISRECVINTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( SuplAccPayAcs.COL_THISRECVTAXFREE_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( SuplAccPayAcs.COL_THISRECVOUTERTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //accTable.Add( SuplAccPayAcs.COL_THISRECVINNERTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            accTable.Add(SuplAccPayAcs.COL_BALANCEADJUST_TITLE,        new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            accTable.Add(SuplAccPayAcs.COL_TAXADJUST_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.14 >>>
            //accTable.Add(SuplAccPayAcs.COL_TOTALADJUST_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_TOTALADJUST_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.14 <<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            accTable.Add(SuplAccPayAcs.COL_NONSTMNTAPPEARANCE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_NONSTMNTISDONE_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_STMNTAPPEARANCE_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_STMNTISDONE_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_THISCASHSTOCKPRICE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //accTable.Add(SuplAccPayAcs.COL_THISCASHSTOCKTAX,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_STOCKSLIPCOUNT,             new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_BILLPRINTDATE,              new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_PAYMENTSCHEDULE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_PAYMENTCOND,                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            accTable.Add(SuplAccPayAcs.COL_THISTIMEPAYMENT_TITLE,      new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_STCKTTLACCPAYBALANCE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // 2009.01.14 Add >>>
            accTable.Add(SuplAccPayAcs.COL_STMONCADDUPUPDDATE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_LAMONCADDUPUPDDATE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            accTable.Add(SuplAccPayAcs.COL_PAYTOTAL, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.14 Add <<<

            appearanceTable[0] = accTable;

			// 支払グリッドの列外観情報設定
			Hashtable	dmdTable = new Hashtable();
			// Addを行う順番が、列の表示順位となります。
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdTable.Add( SuplAccPayAcs.COL_CREATEDATETIME, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            dmdTable.Add( SuplAccPayAcs.COL_UPDATEDATETIME, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dmdTable.Add( SuplAccPayAcs.COL_DELETEDATE_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) );
            dmdTable.Add(SuplAccPayAcs.COL_ADDUPSECCODE_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            dmdTable.Add(SuplAccPayAcs.COL_SUPPLIERCODE_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_SUPPLIERNAME_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_SUPPLIERNAME2_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdTable.Add(SuplAccPayAcs.COL_SUPPLIERSNM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
            dmdTable.Add(SuplAccPayAcs.COL_RESULTSECCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END

            dmdTable.Add(SuplAccPayAcs.COL_PAYEECODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_PAYEENAME_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_PAYEENAME2_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_PAYEESNM_TITLE,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dmdTable.Add(SuplAccPayAcs.COL_ADDUPDATE_TITLE,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ADDUPYEARMONTH_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ADDUPDATEJP_TITLE,         new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft,  "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ADDUPYEARMONTHJP_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_THISTIMEPAYNRML_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_THISTIMEFEEPAYNRML_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_THISTIMEDISPAYNRML_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dmdTable.Add(SuplAccPayAcs.COL_THISTIMERBTDMDNRML_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_THISTIMEDMDDEPO_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_THISTIMEFEEDMDDEPO_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_THISTIMEDISDMDDEPO_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_THISTIMERBTDMDDEPO_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dmdTable.Add(SuplAccPayAcs.COL_THISTIMETTLBLCDMD_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_THISNETSTCKPRICE_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_THISNETSTCPRCTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ITDEDOFFSETOUTTAX_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ITDEDOFFSETINTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ITDEDOFFSETTAXFREE_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_OFFSETOUTTAX_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_OFFSETINTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ITDEDSTCOUTTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ITDEDSTCINTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ITDEDSTCTAXFREE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLSTOCKOUTERTAX_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLSTOCKINNERTAX_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dmdTable.Add(SuplAccPayAcs.COL_ITDEDPAYMOUTTAX_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_ITDEDPAYMINTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_ITDEDPAYMTAXFREE_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_PAYMENTOUTTAX_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_PAYMENTINTAX_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dmdTable.Add( SuplAccPayAcs.COL_THISRECVOFFSET_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( SuplAccPayAcs.COL_THISRECVOFFSETTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( SuplAccPayAcs.COL_THISRECVOUTTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( SuplAccPayAcs.COL_THISRECVINTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( SuplAccPayAcs.COL_THISRECVTAXFREE_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( SuplAccPayAcs.COL_THISRECVOUTERTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            //dmdTable.Add( SuplAccPayAcs.COL_THISRECVINNERTAX_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

            dmdTable.Add( SuplAccPayAcs.COL_SUPPCTAXLAYCD_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black ) );
            dmdTable.Add(SuplAccPayAcs.COL_SUPPLIERCONSTAXRATE_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_FRACTIONPROCCD_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_CADDUPUPDEXECDATE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_DMDPROCNUM_TITLE,          new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_GUID_TITLE,                new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ACPODRTTL3TMBFBLDMD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_ACPODRTTL2TMBFBLDMD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_LASTTIMEDEMAND_TITLE,      new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_THISTIMESTOCKPRICE_TITLE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_THISSTCPRCTAX_TITLE,        new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdTable.Add(SuplAccPayAcs.COL_OFSTHISTIMESTOCK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_OFSTHISSTOCKTAX_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));            
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dmdTable.Add(SuplAccPayAcs.COL_TTLINCDTBTTAXEXC_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_TTLINCDTBTTAX_TITLE,       new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdTable.Add(SuplAccPayAcs.COL_TTLITDEDRETOUTTAX_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLITDEDRETINTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLITDEDRETTAXFREE_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLRETOUTERTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLRETINNERTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLITDEDDISOUTTAX_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLITDEDDISINTAX_TITLE,    new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLITDEDDISTAXFREE_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLDISOUTERTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TTLDISINNERTAX_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            dmdTable.Add(SuplAccPayAcs.COL_BALANCEADJUST_TITLE,       new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            dmdTable.Add(SuplAccPayAcs.COL_TAXADJUST_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.14 >>>
            //dmdTable.Add(SuplAccPayAcs.COL_TOTALADJUST_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_TOTALADJUST_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.14 <<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            dmdTable.Add(SuplAccPayAcs.COL_NONSTMNTAPPEARANCE_TITLE,  new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_NONSTMNTISDONE_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_STMNTAPPEARANCE_TITLE,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_STMNTISDONE_TITLE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_THISCASHSTOCKPRICE,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //dmdTable.Add(SuplAccPayAcs.COL_THISCASHSTOCKTAX,           new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_STOCKSLIPCOUNT,            new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_BILLPRINTDATE,             new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_PAYMENTSCHEDULE,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_PAYMENTCOND,               new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            dmdTable.Add(SuplAccPayAcs.COL_THISTIMEPAYMENT_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_AFCALDEMANDPRICE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // 2009.01.14 Add >>>
            dmdTable.Add(SuplAccPayAcs.COL_STARTCADDUPUPDDATE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_LASTCADDUPUPDDATE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            dmdTable.Add(SuplAccPayAcs.COL_PAYTOTAL, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2009.01.14 Add <<<

            appearanceTable[1] = dmdTable;
		}

		/// <summary>グリッド列外観情報取得（詳細）</summary>
		/// <param name="targetGrid">グリッド列外観情報</param>
		/// <param name="TABLE_NAME">該当テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドの列の外観情報を設定を作成</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public void GetDisPlayDisplayLayoutTable(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, string TABLE_NAME)
		{
			targetGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

			// 固定列の設定
			targetGrid.DisplayLayout.UseFixedHeaders               = false;
			targetGrid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			targetGrid.DisplayLayout.Override.CellClickAction      = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			targetGrid.DisplayLayout.Override.SelectTypeCell       = Infragistics.Win.UltraWinGrid.SelectType.None;
			targetGrid.DisplayLayout.Override.AllowUpdate          = Infragistics.Win.DefaultableBoolean.False;

			// 列外観情報設定
			// 編集不可設定
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
                    case REC_ACCRECBLNCE_TITLE:
                    case REC_THISTIMEPAYM_TITLE:
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

		/// <summary>バインドデータセット取得処理</summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="TableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] TableName)
		{
			// データセット
            this.Bind_DataSet = this._suplAccPayAcs.BindDataSet;
			bindDataSet = this.Bind_DataSet;
            // テーブル名取得
			string[] strRet = new string[2];
			strRet[0] = SuplAccPayAcs.TBL_CUSTACCREC_TITLE;
			strRet[1] = SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE;
			TableName = strRet;
		}

		/// <summary>テーブルの選択データインデックスリスト設定処理</summary>
		/// <param name="indexList">データテーブルの選択データインデックスリスト</param>
		/// <remarks>
		/// <br>Note       : データテーブルの選択データインデックスを設定します</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public void SetDataIndexList(int[] indexList)
		{
			this._accRecDataIndex    = indexList[0];
			this._dmdPrcDataIndex    = indexList[1];
		}

		/// <summary>Labelに表示する金額カンマ処理</summary>
		/// <param name="val">金額</param>
		/// <param name="checkMode">結果文字数が12桁を超えた時にカンマ編集しないチェック有無 true:ﾁｪｯｸする flase:ﾁｪｯｸしない</param>
		/// <returns>文字</returns>
		/// <remarks>
		/// <br>Note       : 渡された金額をLabel用にカンマ編集します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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

		/// <summary>仕入先データ検索処理</summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 仕入先データを検索します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int CustomerData_Search(ref int totalCount, int readCount)
		{
			int status = 0;
            CustomerSearchPara  para = new CustomerSearchPara();
            CustomerSearchRet[] retArray = null;

			if (readCount == 0)
			{
				// 抽出対象件数が0の場合は全件抽出を実行する
                para.EnterpriseCode = this._enterpriseCode;
                status = this._customerAcs.Serch(out retArray, para);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( retArray.Length > 0 ) 
					{
						// 最終の仕入先オブジェクトを退避する
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
					TMsgDisp.Show(this, 								    // 親ウィンドウフォーム
						          emErrorLevel.ERR_LEVEL_STOP, 		        // エラーレベル
						          "MAKAU09130U", 						    // アセンブリＩＤまたはクラスＩＤ
						          "仕入先実績修正",					        // プログラム名称
						          "MAKAU09130U", 						    // 処理名称
						          TMsgDisp.OPE_GET, 					    // オペレーション
						          "仕入先情報読み込みに失敗しました。", 	// 表示するメッセージ
						          status, 							        // ステータス値
						          this._customerAcs,	 				    // エラーが発生したオブジェクト
						          MessageBoxButtons.OK, 				    // 表示するボタン
						          MessageBoxDefaultButton.Button1 );	    // 初期表示ボタン
					break;
				}
			}

			totalCount = this._totalCount;

			return status;
		}

		/// <summary>指定仕入先データ情報読み込み処理</summary>
        /// <param name="customerRet">仕入先情報</param>
		/// <param name="supplierCode">仕入先コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定仕入先コードのデータを検索します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int ReadCustomerData(out CustomerSearchRet customerRet, int customerCode)
		{
            customerRet = (CustomerSearchRet)this._customerTable[customerCode];

            this._AllaccrecTable.Clear();
			this._AlldmdprcTable.Clear();
            this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE].Clear();
            this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTACCREC_TITLE].Clear();

            if (customerRet == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}

		/// <summary>拠点情報のデータ検索処理</summary>
		/// <param name="retSecInfSetList">拠点情報格納</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報を全件取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		public int SecInf_Search(out ArrayList retSecInfSetList)
		{
			int status = 0;
			// データの抽出処理を実行する
			// 拠点情報を取得
		
			status  =  SearchAllSecInfSetInfo(out retSecInfSetList, true, true);

			switch (status)
			{
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					foreach( SecInfoSet secInfSet in retSecInfSetList)
					{
						if (this._secInfSetTable.ContainsKey(secInfSet.SectionCode.Trim()) == true)
						{
							this._secInfSetTable.Remove(secInfSet.SectionCode);
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
			// 自拠点情報取得
			status = ReadCompanySecInfoSetInfo();
			return status;
		}

		/// <summary>支払金額情報のデータ検索処理</summary>
        /// <param name="payeeCode">支払先コード</param>
		/// <param name="supplierCode">仕入先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 支払金額情報を取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>-----------------------</br>
        /// <br>Note       : 指定区分を追加</br>
        /// <br>Modifier   : 徳永 俊詞</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
		public int DmdRec_Data_Search(int payeeCode, int supplierCode, string addUpSecCode, int targetDivType)
		{
			int status = 0;
			Hashtable retHash = new Hashtable();
			this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE].Clear();

            if ((supplierCode != 0) && (addUpSecCode != ""))
            {
                status = SearchDmdRecInfo(payeeCode, supplierCode, addUpSecCode, out retHash, true, targetDivType);
            }
			return status ;
		}

		/// <summary>買掛金額情報のデータ検索処理</summary>
        /// <param name="payeeCode">支払先コード</param>
		/// <param name="supplierCode">仕入先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 買掛金額情報を取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>-----------------------</br>
        /// <br>Note       : 指定区分を追加</br>
        /// <br>Modifier   : 徳永 俊詞</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        public int AccRec_Data_Search(int claimCode, int customerCode, string addUpSecCode, int targetDivType)
		{
			int status = 0;
			Hashtable retHash = new Hashtable();
			this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTACCREC_TITLE].Clear();
            if ((customerCode != 0) && (addUpSecCode != ""))
            {
                status = SearchAccPrcInfo(claimCode, customerCode, addUpSecCode, out retHash, true, targetDivType);
            }
			return status ;
		}

        /// <summary>鑑編集用の対応する列名称取得</summary>
		/// <param name="LABELList">列名称配列</param>
		/// <remarks>
		/// <br>Note       : 鑑編集用の対応する列名称を返します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        public void ReadTabelData_claim_panelSet(out string[] LABELList)
        {
            LABELList = new string[15];

            // 鑑に情報を反映
            LABELList[0] = REC_TOTAL3_BEF_TITLE;        // ３回以前残高
            LABELList[1] = REC_TOTAL2_BEF_TITLE;        // ２回以前残高
            LABELList[2] = REC_TOTAL1_BEF_TITLE;        // 前回残高
            LABELList[3] = REC_THISTIMESALES_TITLE;     // 今回仕入
            LABELList[4] = REC_CONSTAX_TITLE;           // 消費税
            LABELList[5] = REC_THISTIMEPAYM_TITLE;      // 今回支払
            LABELList[6] = "";       // 支払消費税
            LABELList[7] = "";      // 今回支払
            LABELList[8] = REC_ACCRECBLNCE_TITLE;       // 残高
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START

        /// <summary>
        /// 新規画面を作成する際に、受け取った仕入先コードを元に仕入先の情報を取得する
        /// </summary>
        /// <remarks>テーブル上に「仕入先名」「仕入先名２」などが
        /// セットされていない原因を解消するための処置（もともとの設計の問題）
        /// データベースおよびアプリケーションの表示上は問題ない模様（表示されない）</remarks>
        public void GetSettledSupplierData()
        {
            int status;
            Supplier supplierInfo;

            // Public Propertyで受け取った仕入先コードを元に仕入先情報を取得する
            //status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, this._targetSupplierCode);
            status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, this._condSupplierCode);


            // 得意先情報を取得できたときのみ情報を抽出
            if (supplierInfo != null)
            {
                this.CustomerName_Label.Text = supplierInfo.SupplierNm1;
                this.CustomerName2_Label.Text = supplierInfo.SupplierNm2;

                // 支払先情報も抽出しておく
                this.PayeeName_Label.Text = supplierInfo.PayeeName;
                this.PayeeName2_Label.Text = supplierInfo.PayeeName2;
                this.PayeeSnm_Label.Text = supplierInfo.PayeeSnm;
                // --- ADD 2012/09/18 ---------->>>>>
                if (this._sumSuppEnable)
                {
                    // 支払先情報を仕入先情報で上書きする
                    this.PayeeName_Label.Text = supplierInfo.SupplierNm1;
                    this.PayeeName2_Label.Text = supplierInfo.SupplierNm2;
                    this.PayeeSnm_Label.Text = supplierInfo.SupplierSnm;
                }
                // --- ADD 2012/09/18 ----------<<<<<
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END


        # endregion

        // ===================================================================================== //
		// 内部メソッド（DB関連）
		// ===================================================================================== //
		# region Private Methods_DB_Relation

		/// <summary>HashTableに仕入先情報格納</summary>
        /// <param name="customerRet">仕入先情報</param>
		/// <remarks>
		/// <br>Note       : 渡された仕入先情報をHashTableに格納します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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

        /// <summary>買掛金額情報取得処理</summary>
        /// <param name="payeeCode">支払先コード</param>
		/// <param name="supplierCode">仕入先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
		/// <param name="retAccRecTable">買掛金額情報取得結果</param>
		/// <param name="BindDataSetMode">DataSetへの設定有無（HashTableのみならfalse）</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 買掛金額を取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private int SearchAccPrcInfo(int payeeCode, int supplierCode, string addUpSecCode, out Hashtable retAccRecTable, bool BindDataSetMode, int targetDivType)
		{	
			int status = 0;
			int totalCount = 0;

			retAccRecTable = new Hashtable();

            // 全社が選択されている場合
            if (addUpSecCode == ALLSECCODE)
            {
                addUpSecCode = null;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            if (targetDivType == TARGET_DIV_PAYEE)
            {
                // 指定区分：支払先の時
                // 仕入先・支払先コード：画面上の仕入先コード
                // 計上拠点コード：画面の拠点コード
                // 2009.01.14 >>>
                //status = this._suplAccPayAcs.SearchSuplAccPay(out totalCount, this._enterpriseCode, addUpSecCode, supplierCode, supplierCode);
                status = this._suplAccPayAcs.SearchSuplAccPay(out totalCount, this._enterpriseCode, addUpSecCode, supplierCode, 0);
                // 2009.01.14 <<<
            }
            else
            {
                // 指定区分：仕入先の時
                // 支払先コード：仕入先に対する支払先コード
                // 仕入先コード：画面上の仕入先コード
                // 計上拠点コード：仕入先の支払拠点コード

                // --- DEL 2012/09/18 ---------------------------->>>>>
                // 仕入先情報を取得
                //Supplier supplierInfo;
                //status = _supplierAcs.Read(out supplierInfo, this._enterpriseCode, supplierCode);

                //// 検索実行
                //// 2009.01.14 >>>
                ////status = this._suplAccPayAcs.SearchSuplAccPay(out totalCount, this._enterpriseCode, supplierInfo.PaymentSectionCode, supplierInfo.PayeeCode, supplierCode);
                //status = this._suplAccPayAcs.SearchSuplAccPay(out totalCount, this._enterpriseCode, addUpSecCode, supplierInfo.PayeeCode, supplierCode);
                //// 2009.01.14 <<<
                ////status = this._custAccRecDmdPrcAcs.SearchCustAccRec(out totalCount, this._enterpriseCode, addUpSecCode, , supplierCode);
                ////status = this._suplAccPayAcs.SearchSuplAccPay(out totalCount, this._enterpriseCode, addUpSecCode, payeeCode, supplierCode);
                // --- DEL 2012/09/18 ----------------------------<<<<<
                // --- ADD 2012/09/18 ---------------------------->>>>>
                if (this._sumSuppEnable)
                {
                    // 仕入総括有効時の処理
                    status = this._suplAccPayAcs.SearchSuplAccPay(out totalCount, this._enterpriseCode, addUpSecCode, payeeCode, supplierCode);
                }
                else
                {
                    // 仕入先情報を取得
                    Supplier supplierInfo;
                    status = _supplierAcs.Read(out supplierInfo, this._enterpriseCode, supplierCode);

                    // 既存の処理を実行
                    status = this._suplAccPayAcs.SearchSuplAccPay(out totalCount, this._enterpriseCode, addUpSecCode, supplierInfo.PayeeCode, supplierCode);
                }
                // --- ADD 2012/09/18 ----------------------------<<<<<
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
                        TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP, 		    // エラーレベル
                                      "MAKAU09130U", 						// アセンブリＩＤまたはクラスＩＤ
                                      "仕入先実績修正",					    // プログラム名称
                                      "SearchAccPrcInfo", 					// 処理名称
                                      TMsgDisp.OPE_GET, 					// オペレーション
                                      "買掛情報読み込みに失敗しました。", 	// 表示するメッセージ
                                      status, 							    // ステータス値
                                      this._suplAccPayAcs,			// エラーが発生したオブジェクト
                                      MessageBoxButtons.OK, 				// 表示するボタン
                                      MessageBoxDefaultButton.Button1);	    // 初期表示ボタン
                        break;
                    }
            }

			return status;
		}

        /// <summary>支払金額情報取得処理</summary>
        /// <param name="payeeCode">支払先コード</param>
		/// <param name="supplierCode">仕入先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
		/// <param name="retDmdRecTable">支払金額情報取得結果</param>
		/// <param name="BindDataSetMode">DataSetへの設定有無（HashTableのみならfalse）</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 支払金額を取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private int SearchDmdRecInfo(int payeeCode, int supplierCode, string addUpSecCode, out Hashtable retDmdRecTable, bool BindDataSetMode, int targetDivType)
		{
			int status = 0;
            int totalCount = 0;
			
			retDmdRecTable = new Hashtable();

            // 全社が選択されている場合
            if (addUpSecCode == ALLSECCODE)
            {
                addUpSecCode = null;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            if (targetDivType == TARGET_DIV_PAYEE)
            {
                // 指定区分　　　　　：[支払先]
                // 計上拠点・実績拠点：画面上の拠点コード
                // 仕入先・支払先　　：仕入先コード
                // 2009.01.14 >>>
                //status = this._suplAccPayAcs.SearchSuplierPay(out totalCount, this._enterpriseCode, addUpSecCode, supplierCode, addUpSecCode, supplierCode);
                ////status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, addUpSecCode, string.Empty, payeeCode, supplierCode);

                status = this._suplAccPayAcs.SearchSuplierPay(out totalCount, this._enterpriseCode, addUpSecCode, supplierCode, string.Empty, 0);
                // 2009.01.14 <<<
            }
            else
            {
                // 指定区分　　　　　：[仕入先]
                // 実績拠点　　　　　：画面上の拠点コード
                // 計上拠点　　　　　：仕入先の支払拠点コード
                // 仕入先コード　　　：仕入先コード
                // 支払先コード　　　：仕入先に対する支払先コード

                // --- DEL 2012/09/18 ---------------------------->>>>>
                //// 仕入先情報を取得
                //Supplier supplierInfo;
                //status = _supplierAcs.Read(out supplierInfo, this._enterpriseCode, supplierCode);

                ////System.Windows.Forms.MessageBox.Show("計上:" + supplierInfo.PaymentSectionCode + "/支払:" + supplierInfo.PayeeCode.ToString() + "/実績:" + addUpSecCode + "/仕入:" + supplierCode.ToString());

                //status = this._suplAccPayAcs.SearchSuplierPay(out totalCount, this._enterpriseCode, supplierInfo.PaymentSectionCode, supplierInfo.PayeeCode, addUpSecCode, supplierCode);
                // --- DEL 2012/09/18 ----------------------------<<<<<
                // --- ADD 2012/09/18 ---------------------------->>>>>
                if (this._sumSuppEnable)
                {
                    // 仕入総括有効時の処理
                    status = this._suplAccPayAcs.SearchSuplierPay(out totalCount, this._enterpriseCode, addUpSecCode, payeeCode, addUpSecCode, supplierCode);
                }
                else
                {
                    // 仕入先情報を取得
                    Supplier supplierInfo;
                    status = _supplierAcs.Read(out supplierInfo, this._enterpriseCode, supplierCode);

                    // 既存の処理を実行
                    status = this._suplAccPayAcs.SearchSuplierPay(out totalCount, this._enterpriseCode, supplierInfo.PaymentSectionCode, supplierInfo.PayeeCode, addUpSecCode, supplierCode);
                }
                // --- ADD 2012/09/18 ----------------------------<<<<<
                //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, this._condPaymentSectionCode, addUpSecCode, this.TargetClaimCode, supplierCode);
                //status = this._suplAccPayAcs.SearchSuplierPay(out totalCount, this._enterpriseCode, this._condPaymentSectionCode, addUpSecCode, payeeCode, supplierCode);
                //status = this._suplAccPayAcs.SearchSuplierPay(out totalCount, this._enterpriseCode, addUpSecCode, payeeCode, supplierCode);
            }
            //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, string.Empty, addUpSecCode, payeeCode, supplierCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END

            
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
                        TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP, 		    // エラーレベル
                                      "MAKAU09130U", 						// アセンブリＩＤまたはクラスＩＤ
                                      "仕入先実績修正",					    // プログラム名称
                                      "SearchDmdRecInfo", 					// 処理名称
                                      TMsgDisp.OPE_GET, 					// オペレーション
                                      "支払情報読み込みに失敗しました。", 	// 表示するメッセージ
                                      status, 							    // ステータス値
                                      this._suplAccPayAcs,			// エラーが発生したオブジェクト
                                      MessageBoxButtons.OK, 				// 表示するボタン
                                      MessageBoxDefaultButton.Button1);	    // 初期表示ボタン
                        break;
                    }
            }

			return status;
		}

        /// <summary>拠点情報変更処理</summary>
		/// <param name="retSecInfSet">拠点情報マスタクラスオブジェクト</param>
		/// <param name="showMessage">メッセージの表示(true:表示, false:非表示)</param>
		/// <param name="dataOutPutMode">データを画面に出力する区分(true:表示, false:非表示)</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報を参照します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
							TMsgDisp.Show(this, 								// 親ウィンドウフォーム
								          emErrorLevel.ERR_LEVEL_STOP, 		    // エラーレベル
								          "MAKAU09130U", 						// アセンブリＩＤまたはクラスＩＤ
								          "仕入先実績修正",					    // プログラム名称
								          "SearchAllSecInfSetInfo", 			// 処理名称
								          TMsgDisp.OPE_GET, 					// オペレーション
								          "拠点情報が登録されていません。", 	// 表示するメッセージ
								          status, 							    // ステータス値
								          this._secInfoAcs,	 				    // エラーが発生したオブジェクト
								          MessageBoxButtons.OK, 				// 表示するボタン
								          MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
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
							TMsgDisp.Show(this, 								// 親ウィンドウフォーム
								          emErrorLevel.ERR_LEVEL_STOP, 		    // エラーレベル
								          "MAKAU09130U", 						// アセンブリＩＤまたはクラスＩＤ
								          "仕入先実績修正",					    // プログラム名称
								          "SearchAllSecInfSetInfo", 			// 処理名称
								          TMsgDisp.OPE_GET, 					// オペレーション
								          "拠点情報読み込みに失敗しました。",   // 表示するメッセージ
								          status, 							    // ステータス値
								          this._secInfoAcs,	 				    // エラーが発生したオブジェクト
								          MessageBoxButtons.OK, 				// 表示するボタン
								          MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
						}
					}
					break;
				}
			}

			return status;
		}

		/// <summary>自拠点情報取得処理</summary>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報を参照します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private int ReadCompanySecInfoSetInfo()
		{	
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            this._mainOfficeFuncFlag = true; // 本社限定

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
            //        // 自拠点が本社機能有無
            //        this._mainOfficeFuncFlag = Convert.ToBoolean(this._secInfoAcs.GetMainOfficeFuncFlag(this._companySecCode)); 
            //        break;
            //    }
            //    case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
            //    {
            //        TMsgDisp.Show(this,											    // 親ウィンドウフォーム
            //                      emErrorLevel.ERR_LEVEL_EXCLAMATION,				// エラーレベル
            //                      "MAKAU09130U",		  						    // アセンブリＩＤまたはクラスＩＤ
            //                      " 拠点制御情報に登録されていません。",			// 表示するメッセージ 
            //                      0,												// ステータス値
            //                      MessageBoxButtons.OK);							// 表示するボタン
            //        break;
            //    }
            //    default:
            //    {
            //        TMsgDisp.Show(this,											    // 親ウィンドウフォーム
            //                      emErrorLevel.ERR_LEVEL_STOP,					    // エラーレベル
            //                      "MAKAU09130U",									// アセンブリＩＤまたはクラスＩＤ
            //                      this.Text,										// プログラム名称
            //                      "ReadCompanySecInfoSetInfo",				        // 処理名称
            //                      TMsgDisp.OPE_GET,								    // オペレーション
            //                      "拠点制御情報の読み込みに失敗しました。",		    // 表示するメッセージ 
            //                      status,											// ステータス値
            //                      this._secInfoAcs,			  			   		    // エラーが発生したオブジェクト
            //                      MessageBoxButtons.OK,							    // 表示するボタン
            //                      MessageBoxDefaultButton.Button1);			  	    // 初期表示ボタン
            //        break;
            //    }
            //}

			return status;
		}
		
        /// <summary>排他処理</summary>
		/// <param name="status">status</param>
		/// <remarks>
		/// <br>Note       : 排他処理</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show(this,                                     // 親ウィンドウフォーム
						          emErrorLevel.ERR_LEVEL_EXCLAMATION,       // エラーレベル
						          "MAKAU09130U",						    // アセンブリID
						          "既に他端末より更新されています。",	    // 表示するメッセージ
						          status,									// ステータス値
						          MessageBoxButtons.OK);					// 表示するボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show(this,                                     // 親ウィンドウフォーム
						          emErrorLevel.ERR_LEVEL_EXCLAMATION,       // エラーレベル
						          "MAKAU09130U",						    // アセンブリID
						          "既に他端末より削除されています。",	    // 表示するメッセージ
						          status,									// ステータス値
						          MessageBoxButtons.OK);					// 表示するボタン
					break;
				}
			}
		}

		# endregion	

        // ===================================================================================== //
		// 内部メソッド（画面関連）
		// ===================================================================================== //
		# region Private Methods_Screen

        /// <summary>画面クリア処理</summary>
		/// <param name="HeaderClear">仕入先・拠点のクリア有無 true:クリア false:クリアしない</param>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenClear( bool HeaderClear )
		{
			this._formBeingStarted = false;

			if ( HeaderClear == true )
			{
				// 仕入先情報（コード・名称・締日)
				this.customerCode_Label.Text       = "";
				this.CustomerName_Label.Text       = "";
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                this.CustomerName2_Label.Text      = "";
                this.CustomerSnm_Label.Text = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                this.claimCode_Label.Text          = "";
                this.PayeeName_Label.Text          = "";
                this.PayeeName2_Label.Text         = "";
                this.PayeeSnm_Label.Text           = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				this.TotalDay_Label.Text           = "";
				// 拠点情報
				this.demandAddUpSecCd_Label.Text   = "";
				this.demandAddUpSecName_Label.Text = "";
			}

			// 計上日付
            this.AddUpADate_tDateEdit.SetDateTime(DateTime.MinValue);
			
			// ----- 鑑項目 -----
            // 2009.01.14 Del >>>
            //// 前回情報
            //this.TtlBf3TmBl_Label.Text = "";        // ３回以前残高
            //this.TtlBf2TmBl_Label.Text = "";        // ２回以前残高
            //this.TtlLMBl_Label.Text    = "";        // 前回残高

            ////カンマ編集前の値を設定
            //this.TtlBf3TmBl_Label.Tag  = 0;         // ３回以前残高
            //this.TtlBf2TmBl_Label.Tag  = 0;         // ２回以前残高
            //this.TtlLMBl_Label.Tag     = 0;         // 前回残高

            //this.TtlSales_Label.Text   = "";        // 今回仕入
            //this.TtlTax_Label.Text     = "";        // 消費税
            //this.TtlDepo_Label.Text    = "";        // 今回支払
            //this.TtlBl_Label.Text      = "";        // 買掛残高残高

            this._totalDisplayTable.Rows.Clear();
            this._totalDisplayTable.Rows.Add(this._totalDisplayTable.NewRow());
            // 2009.01.14 Del <<<

            // ----- 詳細情報画面項目 -----
			// 仕入・支払情報
            this.TtlItdedStcOutTax_tNedit.Clear();   // 仕入外税対象額
            this.TtlStockOuterTax_tNedit.Clear();        // 仕入外税額
            this.TtlItdedStcInTax_tNedit.Clear();    // 仕入内税対象額
            this.TtlStockInnerTax_tNedit.Clear();         // 仕入内税額
            this.TtlItdedStcTaxFree_tNedit.Clear();  // 仕入非課税対象額
            this.StockSlipCount_tNedit.Clear();     // 伝票枚数
            this.SalesTotal_Label.Text        = ""; // 仕入合計額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            this.TtlItdedRetOutTax_tNedit.Clear();  // 返品外税対象額
            this.TtlRetOuterTax_tNedit.Clear();     // 返品外税額
            this.TtlItdedRetInTax_tNedit.Clear();   // 返品内税対象額
            this.TtlRetInnerTax_tNedit.Clear();     // 返品内税額
            this.TtlItdedRetTaxFree_tNedit.Clear(); // 返品非課税対象額
            this.RetTotal_Label.Text = "";          // 返品合計額
            // 値引
            this.TtlItdedDisOutTax_tNedit.Clear();  // 値引外税対象額
            this.TtlDisOuterTax_tNedit.Clear();     // 値引外税額
            this.TtlItdedDisInTax_tNedit.Clear();   // 値引内税対象額
            this.TtlDisInnerTax_tNedit.Clear();     // 値引内税額
            this.TtlItdedDisTaxFree_tNedit.Clear(); // 値引非課税対象額
            this.DisTotal_Label.Text = "";          // 値引合計額
            // 残高調整
            this.BalanceAdjust_tNedit.Clear();      // 残高調整額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 現金仕入
            //this.ThisCashStockPrice_tNedit.Clear();  // 現金仕入金額
            //this.ThisCashStockTax_tNedit.Clear();    // 現金仕入消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // 未決済金額
            //this.NonStmntAppearance_tNedit.Clear();  // 未決済金額（自振）
            //this.NonStmntIsdone_tNedit.Clear();      // 未決済金額（廻し）
            // 決済金額
            //this.StmntAppearance_tNedit.Clear();    // 決済金額（自振）
            //this.StmntIsdone_tNedit.Clear();        // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ItdedPaymOutTax_tNedit.Clear();    // 支払外税対象額
            //this.PaymentOutTax_tNedit.Clear();      // 支払外税額
            //this.ItdedPaymInTax_tNedit.Clear();     // 支払内税対象額
            //this.PaymentInTax_tNedit.Clear();       // 支払内税額
            //this.ItdedPaymTaxFree_tNedit.Clear();   // 支払非課税対象額
            //this.PaymTotal_Label.Text         = ""; // 支払合計額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ItdedOutTaxTotal_Label.Text  = ""; // 外税対象額合計
            //this.OutTaxTotal_Label.Text       = ""; // 外税額合計
            //this.ItdedInTaxTotal_Label.Text   = ""; // 内税対象額合計
            //this.InTaxTotal_Label.Text        = ""; // 内税額合計
            //this.ItdedTaxFreeTotal_Label.Text = ""; // 非課税対象額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 支払情報
            //this.DepoNrml_tNedit.Clear();           // 通常支払金額   // 2009.01.14 Del
            this.FeeNrml_tNedit.Clear();            // 通常手数料額
            this.DisNrml_tNedit.Clear();            // 通常値引額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.Clear();            // 通常リベート額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.NrmlTotal_Label.Text    = "";      // 通常合計額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.Depo_tNedit.Clear();               // 預り金支払金額
            //this.FeeDepo_tNedit.Clear();            // 預り金手数料額
            //this.DisDepo_tNedit.Clear();            // 預り金値引額
            //this.RbtDepo_tNedit.Clear();            // 預り金リベート額
            //this.DepoTotal_Label.Text    = "";      // 預り金合計額
            //this.DepoPrcTotal_Label.Text = "";      // 支払金額合計
            //this.FeeTotal_Label.Text     = "";      // 手数料額合計
            //this.DisTotal_Label.Text     = "";      // 値引額合計
            //this.RbtTotal_Label.Text     = "";      // リベート額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 前回残高
            this.Bf3TmBl_tNedit.Clear();            // ３回以前残高
            this.Bf2TmBl_tNedit.Clear();            // ２回以前残高
            this.LMBl_tNedit.Clear();               // 前回残高

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 受取
            //this.ThisRecvInnerTax_tNedit.Clear();
            //this.ThisRecvInTax_tNedit.Clear();
            //this.ThisRecvOuterTax_tNedit.Clear();
            //this.ThisRecvOutTax_tNedit.Clear();
            //this.ThisRecvTaxFree_tNedit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

            this._formBeingStarted = true;
		}

        /// <summary>画面入力許可制御処理_計上日付</summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 計上日付の入力許可を制御します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenInputPermissionControl_Date( bool enabled )
		{
			// 新規の時のみ
			// 計上日付
			this.AddUpADate_tDateEdit.Enabled = enabled;
		}

        /// <summary>画面入力許可制御処理_拠点</summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 拠点の項目の表示・非表示を制御します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenInputPermissionControl_Section( bool enabled )
		{
			this.SecInf_Tittle_Label.Visible      = enabled;
			this.demandAddUpSecCd_Label.Visible   = enabled;
			this.demandAddUpSecName_Label.Visible = enabled;
			this.tLine23.Visible                  = enabled;
		}

		/// <summary>画面入力許可制御処理_詳細</summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 金額関連の入力許可を制御します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenInputPermissionControl_Details( bool enabled )
		{
			// ----- 詳細情報画面項目 -----
			// 仕入・支払情報
            this.TtlItdedStcOutTax_tNedit.Enabled  = enabled;
            this.TtlStockOuterTax_tNedit.Enabled       = enabled;
            this.TtlItdedStcInTax_tNedit.Enabled   = enabled;
            this.TtlStockInnerTax_tNedit.Enabled        = enabled;
            this.TtlItdedStcTaxFree_tNedit.Enabled = enabled;
            this.SalesTotal_Label.Enabled         = enabled;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ItdedPaymOutTax_tNedit.Enabled   = enabled;
            //this.PaymentOutTax_tNedit.Enabled     = enabled;
            //this.ItdedPaymInTax_tNedit.Enabled    = enabled;
            //this.TtlItdedStcInTax_tNedit.Enabled   = enabled;
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
            // 支払
            //this.DepoNrml_tNedit.Enabled          = enabled;  // 2009.01.14 Del
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
			// 前回残
			this.LMBl_tNedit.Enabled              = enabled;
            this.Bf2TmBl_tNedit.Enabled           = enabled;
            this.Bf3TmBl_tNedit.Enabled           = enabled;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 受取
            //this.ThisRecvInnerTax_tNedit.Enabled = enabled;
            //this.ThisRecvInTax_tNedit.Enabled = enabled;
            //this.ThisRecvOuterTax_tNedit.Enabled = enabled;
            //this.ThisRecvOutTax_tNedit.Enabled = enabled;
            //this.ThisRecvTaxFree_tNedit.Enabled = enabled;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

		}

        /// <summary>画面再構築処理</summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			_logicalDeleteMode = -1;
			Control focusControl = null;   // フォーカスセットコントロール

			// 期首残設定
			this.Text = "仕入先実績修正";

            Supplier supplierInfo;
            //int status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, this._targetSupplierCode);
            int status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, this._condSupplierCode);
            if (supplierInfo != null)
            {
                // 仕入先・拠点情報を表示
                //2008.11.20 modify start [7973]
                //this.customerCode_Label.Text = supplierInfo.SupplierCd.ToString().PadLeft(8, '0');
                this.customerCode_Label.Text = supplierInfo.SupplierCd.ToString().PadLeft(6, '0');
                //2008.11.20 modify end [7973]
                this.CustomerName_Label.Text = supplierInfo.SupplierNm1.ToString().TrimEnd();
                this.CustomerName2_Label.Text = supplierInfo.SupplierNm2.ToString().TrimEnd();
                this.CustomerSnm_Label.Text = supplierInfo.SupplierSnm.ToString().TrimEnd();

                //2008.11.20 modify start [7973]
                //this.claimCode_Label.Text = supplierInfo.PayeeCode.ToString().PadLeft(8, '0');
                this.claimCode_Label.Text = supplierInfo.PayeeCode.ToString().PadLeft(6, '0');
                //2008.11.20 modify end [7973]
                this.PayeeName_Label.Text = supplierInfo.PayeeName.ToString().TrimEnd();
                this.PayeeName2_Label.Text = supplierInfo.PayeeName2.ToString().TrimEnd();
                this.PayeeSnm_Label.Text = supplierInfo.PayeeSnm.ToString().TrimEnd();
                // --- ADD 2012/09/18 ---------->>>>>
                if (this._sumSuppEnable)
                {
                    // 支払先情報を仕入先情報で上書きする
                    this.claimCode_Label.Text = supplierInfo.SupplierCd.ToString().PadLeft(6, '0');
                    this.PayeeName_Label.Text = supplierInfo.SupplierNm1.ToString().TrimEnd();
                    this.PayeeName2_Label.Text = supplierInfo.SupplierNm2.ToString().TrimEnd();
                    this.PayeeSnm_Label.Text = supplierInfo.SupplierSnm.ToString().TrimEnd();
                }
                // --- ADD 2012/09/18 ----------<<<<<

                this.TotalDay_Label.Text = supplierInfo.PaymentTotalDay.ToString();
            }
            // 2009.01.14 Add >>>
            this.ClearPaymentKindDataTable();
            this.SettingPaymentInfoGrid();
            // 2009.01.14 Add <<<

            //CustomerSearchRet customerRet = (CustomerSearchRet)this._customerTable[this._targetSupplierCode];
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //CustomerInfo customerInfo;
            
            ////CustSuppli custSuppli;
            //this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerRet.CustomerCode);
            ////this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, out custSuppli, this._enterpriseCode, customerRet.CustomerCode);

            //if ( custSuppli.CustomerCode != customerRet.CustomerCode ) {
            //    this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0,this._enterpriseCode,customerRet.CustomerCode,true,out customerInfo,out custSuppli);
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //// 仕入先・拠点情報を表示
            //this.customerCode_Label.Text  = customerRet.CustomerCode.ToString();
            //this.CustomerName_Label.Text = customerRet.Name.ToString().TrimEnd();
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.CustomerName2_Label.Text = customerRet.Name2.ToString().TrimEnd();
            //this.CustomerSnm_Label.Text = customerRet.Snm.ToString().TrimEnd();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.claimCode_Label.Text = custSuppli.PayeeCode.ToString();

            //int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerRet.CustomerCode);
            //if ( status != 0 ) {
            //    status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerRet.EnterpriseCode, customerRet.CustomerCode, true, out customerInfo);
            //}

            //this.PayeeName_Label.Text = customerInfo.Name.ToString().TrimEnd();
            //this.PayeeName2_Label.Text = customerInfo.Name2.ToString().TrimEnd();
            //this.PayeeSnm_Label.Text = customerInfo.CustomerSnm.ToString().TrimEnd();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //this.TotalDay_Label.Text      = customerRet.TotalDay.ToString();
			
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
                    this.demandAddUpSecName_Label.Text = "全社";
                }
                else
                {
                    this.demandAddUpSecName_Label.Text = "拠点情報 未設定";
                }
			}
			else 
			{
				this.demandAddUpSecCd_Label.Text   = "";
				this.demandAddUpSecName_Label.Text = "全社";
			}

            // 2009.01.14 Add >>>
            this._totalDisplayTable.Rows.Clear();
            this._totalDisplayTable.Rows.Add(this._totalDisplayTable.NewRow());
            // 2009.01.14 Add <<<

			// 買掛
			if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
			{
                SuplAccPay suplAccPay = new SuplAccPay();
                // 2009.01.14 Add >>>
                SuplAccPay suplAccPaytotal = new SuplAccPay();
                List<ACalcPayTotal> aCalcPayList = new List<ACalcPayTotal>();
                List<ACalcPayTotal> aCalcPaylTotalList = new List<ACalcPayTotal>();
                // 2009.01.14 Add <<<

				// 新規
				if(this._accRecDataIndex < 0 )
				{
					// 新規
					this.Mode_Label.Text = INSERT_MODE;
					_logicalDeleteMode = -1;
					focusControl = this.AddUpADate_tDateEdit;
                    // 2009.01.14 Add >>>
                    suplAccPay.EnterpriseCode = this._enterpriseCode;
                    suplAccPay.AddUpSecCode = this._condPaymentSectionCode;
                    suplAccPay.SupplierCd = this._condSupplierCode;
                    suplAccPay.PayeeCode = this._condPayeeCode;
                    // 2009.01.14 Add <<<
				}
				else
				{
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;
					_logicalDeleteMode = 0;
					focusControl = this.TtlItdedStcOutTax_tNedit;
                    // 2009.01.14 >>>
                    //DataRowToSuplAccPay(this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTACCREC_TITLE].Rows[this._accRecDataIndex], suplAccPay);
                    DataRowToSuplAccPay(this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTACCREC_TITLE].Rows[this._accRecDataIndex], out suplAccPay, out aCalcPayList);

                    this.GetTotalSuplAccPayRecFromTable(suplAccPay, out suplAccPaytotal, out aCalcPaylTotalList);
                    // 2009.01.14 <<<
                }

                // 2009.01.14 >>>
                //this._editSuplAccPay  = suplAccPay_Clone(suplAccPay);
                //this._suplAccPayClone = suplAccPay_Clone(suplAccPay);

                this._editSuplAccPay = suplAccPay.Clone();
                this._suplAccPayClone = suplAccPay.Clone();

                this._editACalcPayTotalList = new List<ACalcPayTotal>();
                foreach (ACalcPayTotal accRecDepoTotal in aCalcPayList)
                {
                    this._editACalcPayTotalList.Add(accRecDepoTotal.Clone());
                }
                this.ACalcPayTotalListToTable(this._editACalcPayTotalList);

                this._suplAccPayTotal = suplAccPaytotal.Clone();
                this._aCalcPayTotalList = new List<ACalcPayTotal>();
                foreach (ACalcPayTotal aCalcPayTotal in aCalcPaylTotalList)
                {
                    this._aCalcPayTotalList.Add(aCalcPayTotal.Clone());
                }
                // 2009.01.14 <<<

				// 画面表示
                DetailsAccRecToScreen(this._editSuplAccPay);

                // 2009.01.14 Del >>>
                //// 2008.11.21 add start [8021]
                //// 画面を更新（しないと合計額がおかしくなる：理由不明）
                //upDateClaim_PanelTextData();
                //// 2008.11.21 add endt [8021]
                // 2009.01.14 Del <<<
	
				this._accRecIndexBuf  = this._accRecDataIndex;
				this._dmdPrcIndexBuf  = -2;
                //this.TtlBl_Title_Label.Text         = "買掛残高";     // 2009.01.14 Del 
                this.SalesPaymInfo_Title_Label.Text = "買掛情報";

            }
			else
			{
                SuplierPay suplierPay = new SuplierPay();
                // 2009.01.14 Add >>>
                SuplierPay suplierPayTotal = new SuplierPay();
                List<AccPayTotal> accPayList = new List<AccPayTotal>();
                List<AccPayTotal> accPayTotalList = new List<AccPayTotal>();
                // 2009.01.14 Add <<<
				// 仕入先コード未設定
				if(this._dmdPrcDataIndex < 0 )
				{
					// 新規
					this.Mode_Label.Text = INSERT_MODE;
					_logicalDeleteMode = -1;
					focusControl = this.AddUpADate_tDateEdit;
                    suplierPay.EnterpriseCode = this._enterpriseCode; // 2009.01.14 Add
                }
				else
				{
                    // 更新モード
					this.Mode_Label.Text = UPDATE_MODE;
					_logicalDeleteMode = 0;
					focusControl = this.TtlItdedStcOutTax_tNedit;
                    // 2009.01.14 >>>
                    //DataRowToSuplierPay(this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE].Rows[this._dmdPrcDataIndex], suplierPay);
                    DataRowToSuplierPay(this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE].Rows[this._dmdPrcDataIndex], out suplierPay, out accPayList);

                    this.GetTotalSuplierPayFromTable(suplierPay, out suplierPayTotal, out accPayTotalList);
                    // 2009.01.14 <<<
                }
                // 2009.01.14 >>>
                //this._editSuplierPay  = custdmdRec_Clone(suplierPay);
                //this._suplierPayClone = custdmdRec_Clone(suplierPay);
                this._editSuplierPay = suplierPay.Clone();
                this._suplierPayClone = suplierPay.Clone();

                this._editAccPayTotalList = new List<AccPayTotal>();
                foreach (AccPayTotal accPayTotal in accPayList)
                {
                    this._editAccPayTotalList.Add(accPayTotal.Clone());
                }
                this.AccPayTotalListToTable(this._editAccPayTotalList);

                // 集計レコード情報の退避
                this._suplierPayTotal = suplierPayTotal.Clone();
                this._accPayTotalList = new List<AccPayTotal>();
                foreach (AccPayTotal accPayTotal in accPayTotalList)
                {
                    this._accPayTotalList.Add(accPayTotal.Clone());
                }

                // 2009.01.14 <<<

                // 画面表示		
                DetailsDmdPrcToScreen(this._suplierPayClone);

                // 2009.01.14 Del >>>
                //// 2008.11.21 add start [8021]
                //// 画面を更新（しないと合計額がおかしくなる：理由不明）
                //upDateClaim_PanelTextData();
                //// 2008.11.21 add endt [8021]
                // 2009.01.14 Del <<<

				this._accRecIndexBuf  = -2;
				this._dmdPrcIndexBuf  = this._dmdPrcDataIndex;
                //this.TtlBl_Title_Label.Text         = "支払残高";     // 2009.01.14 Del
                this.SalesPaymInfo_Title_Label.Text = "支払仕入情報";
            }

			// 入力受付制御
			ScreenInputPermissionControl_Date(_logicalDeleteMode == -1);
			ScreenInputPermissionControl_Details((_logicalDeleteMode == -1) || (_logicalDeleteMode == 0));

			// 拠点の機能かつ本社機能ならば拠点画面表示
            ScreenInputPermissionControl_Section((Opt_Section == true));
			
			// ボタン表示・非表示
			this.Cancel_Button.Visible = true;
			this.Ok_Button.Visible     = ((_logicalDeleteMode == -1)||(_logicalDeleteMode == 0));
			this.Delete_Button.Visible = (_logicalDeleteMode == 0);
			
			// モード・その他のデータ状態による項目の表示・非表示
			focusControl.Focus();
            if (focusControl is TEdit)
            {
                ((TEdit)focusControl).SelectAll();
            }
            if (focusControl is TNedit)
            {
                ((TNedit)focusControl).SelectAll();
            }

			// 起動した時の情報を格納
            //this._customerCodeBuf = customerRet.CustomerCode;
			this._targetTableBuf  = this._targetTableName;

            // 2009.01.14 Add >>>
            if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
            {
                // 画面を更新（しないと合計額がおかしくなる：理由不明）
                upDateClaim_PanelTextData();

                // 鑑情報を再計算(オリジナルデータ)
                // ※これを行わないと編集中データとの整合性がとれなくなり、編集していないのに編集中とされるため
                getKinSetInfo_Acc(ref this._suplAccPayClone);
            }
            else
            {
                // 画面を更新（しないと合計額がおかしくなる：理由不明）
                upDateClaim_PanelTextData();

                // 鑑情報を再計算(オリジナルデータ)
                // ※これを行わないと編集中データとの整合性がとれなくなり、編集していないのに編集中とされるため
                getKinSetInfo_Dmd(ref this._suplierPayClone);
            }
            // 2009.01.14 Add <<<
		}

		/// <summary>画面に買掛金額情報設定</summary>
        /// <param name="suplAccPay">買掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 画面に買掛金額情報を設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsAccRecToScreen(SuplAccPay suplAccPay)
		{
			// 計上日付
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (TDateTime.LongDateToDateTime(suplAccPay.AddUpYearMonth) == DateTime.MinValue)
            if ( suplAccPay.AddUpYearMonth == DateTime.MinValue )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                this.AddUpADate_tDateEdit.SetDateTime(DateTime.MinValue);
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.AddUpADate_tDateEdit.SetDateTime(TDateTime.LongDateToDateTime(suplAccPay.AddUpDate));
                this.AddUpADate_tDateEdit.SetDateTime(suplAccPay.AddUpDate);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            this.AddUpADate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;

			// 鑑に情報を反映
            // 2009.01.14 >>>
            //DetailsAccRecToClaim_panel(suplAccPay);
            DetailsAccRecToClaim_panel(( this._targetDivType == 1 ) ? this._suplAccPayTotal : suplAccPay);
            // 2009.01.14 <<<
	
			// ----- 詳細情報画面項目 -----
			// 前回残高情報
            this.LMBl_tNedit.SetValue(suplAccPay.LastTimeAccPay);
            this.Bf2TmBl_tNedit.SetValue(suplAccPay.StckTtl2TmBfBlAccPay);
            this.Bf3TmBl_tNedit.SetValue(suplAccPay.StckTtl3TmBfBlAccPay);

			// 仕入・支払情報
            // 仕入
            this.TtlItdedStcOutTax_tNedit.SetValue(suplAccPay.TtlItdedStcOutTax);
            this.TtlStockOuterTax_tNedit.SetValue(suplAccPay.TtlStockOuterTax);
            this.TtlItdedStcInTax_tNedit.SetValue(suplAccPay.TtlItdedStcInTax);
            this.TtlStockInnerTax_tNedit.SetValue(suplAccPay.TtlStockInnerTax);
            this.StockSlipCount_tNedit.SetValue(suplAccPay.StockSlipCount);
            this.TtlItdedStcTaxFree_tNedit.SetValue(suplAccPay.TtlItdedStcTaxFree);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            this.TtlItdedRetOutTax_tNedit.SetValue( -1 * suplAccPay.TtlItdedRetOutTax );
            this.TtlRetOuterTax_tNedit.SetValue( -1 * suplAccPay.TtlRetOuterTax );
            this.TtlItdedRetInTax_tNedit.SetValue( -1 * suplAccPay.TtlItdedRetInTax );
            this.TtlRetInnerTax_tNedit.SetValue( -1 * suplAccPay.TtlRetInnerTax );
            this.TtlItdedRetTaxFree_tNedit.SetValue( -1 * suplAccPay.TtlItdedRetTaxFree );
            // 値引
            this.TtlItdedDisOutTax_tNedit.SetValue( -1 * suplAccPay.TtlItdedDisOutTax );
            this.TtlDisOuterTax_tNedit.SetValue( -1 * suplAccPay.TtlDisOuterTax );
            this.TtlItdedDisInTax_tNedit.SetValue( -1 * suplAccPay.TtlItdedDisInTax );
            this.TtlDisInnerTax_tNedit.SetValue( -1 * suplAccPay.TtlDisInnerTax );
            this.TtlItdedDisTaxFree_tNedit.SetValue( -1 * suplAccPay.TtlItdedDisTaxFree );
            // 残高調整
            this.BalanceAdjust_tNedit.SetValue(suplAccPay.BalanceAdjust);
            // 消費税調整額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            this.TaxAdjust_tNedit.SetValue(suplAccPay.TaxAdjust);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 現金仕入金額
            //this.ThisCashStockPrice_tNedit.SetValue(suplAccPay.ThisCashStockPrice);
            //this.ThisCashStockTax_tNedit.SetValue(suplAccPay.ThisCashStockTax);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // 未決済金額
            //this.NonStmntAppearance_tNedit.SetValue(suplAccPay.NonStmntAppearance);
            //this.NonStmntIsdone_tNedit.SetValue(suplAccPay.NonStmntIsdone);
            // 決済金額
            //this.StmntAppearance_tNedit.SetValue(suplAccPay.StmntAppearance);
            //this.StmntIsdone_tNedit.SetValue(suplAccPay.StmntIsdone);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END


            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 支払
            //this.ItdedPaymOutTax_tNedit.SetValue(suplAccPay.ItdedPaymOutTax);
            //this.PaymentOutTax_tNedit.SetValue(suplAccPay.PaymentOutTax);
            //this.ItdedPaymInTax_tNedit.SetValue(suplAccPay.ItdedPaymInTax);
            //this.PaymentInTax_tNedit.SetValue(suplAccPay.PaymentInTax);
            //this.ItdedPaymTaxFree_tNedit.SetValue(suplAccPay.ItdedPaymTaxFree);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 受取
            //this.ThisRecvInnerTax_tNedit.SetValue( -1 * suplAccPay.ThisRecvInnerTax );
            //this.ThisRecvInTax_tNedit.SetValue( -1 * suplAccPay.ThisRecvInTax );
            //this.ThisRecvOuterTax_tNedit.SetValue( -1 * suplAccPay.ThisRecvOuterTax );
            //this.ThisRecvOutTax_tNedit.SetValue( -1 * suplAccPay.ThisRecvOutTax );
            //this.ThisRecvTaxFree_tNedit.SetValue( -1 * suplAccPay.ThisRecvTaxFree );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

            // 2009.01.14 Add >>>
            // 相殺後消費税
            this.OfsThisStockTax_tNedit.SetValue(suplAccPay.OfsThisStockTax);
            this.OffsetOutTax_tNedit.SetValue(suplAccPay.OffsetOutTax);
            // 2009.01.14 Add <<<

            // 支払情報
            // 通常支払
            //this.DepoNrml_tNedit.SetValue(suplAccPay.ThisTimePayNrml);    // 2009.01.14
            this.FeeNrml_tNedit.SetValue(suplAccPay.ThisTimeFeePayNrml);
            this.DisNrml_tNedit.SetValue(suplAccPay.ThisTimeDisPayNrml);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.SetValue(suplAccPay.ThisTimeRbtDmdNrml);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 預り金
            //this.Depo_tNedit.SetValue(suplAccPay.ThisTimeDmdDepo);
            //this.FeeDepo_tNedit.SetValue(suplAccPay.ThisTimeFeeDmdDepo);
            //this.DisDepo_tNedit.SetValue(suplAccPay.ThisTimeDisDmdDepo);
            //this.RbtDepo_tNedit.SetValue(suplAccPay.ThisTimeRbtDmdDepo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 各合計欄に合計金額を反映
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_ItdedOutTaxTotalLabel();     // 外税対象金額合計
            //update_OutTaxTotalLabel();          // 外税金額合計
            //update_ItdedInTaxTotalLabel();      // 内税対象金額合計
            //update_InTaxTotalLabel();           // 内税金額合計
            //update_ItdedTaxFreeTotalLabel();    // 非課税対象金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_SalesTotalLabel();           // 仕入額合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_RetTotalLabel();             // 返品金額合計
            update_DisTotalLabel();             // 値引金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_PaymTotalLabel();            // 支払額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoPrcTotalLabel();         // 支払金額合計
            //update_FeeTotalLabel();             // 手数料額合計
            //update_DisTotalLabel();             // 値引額合計
            //update_RbtTotalLabel();             // リベート額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_NormalTotalLabel();          // 通常支払合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoTotalLabel();            // 預り金合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_RecvTotalLabel(); // 受取合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            // 2009.01.14 Add >>>
            // 相殺後仕入外税対象額ラベルの反映
            this.update_ItdedOffsetOutTaxLabel();
            // 相殺後非課税対象額ラベルの反映
            this.update_ItdedOffsetTaxFreeLabel();
            // 相殺後仕入合計ラベルの反映
            this.update_OfsThisTimeSalesTotalLabel();
            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 残高合計ラベルの反映
            this.update_BlTotalLabel();
            // 2009.01.14 Add <<<

		}

		/// <summary>鑑に買掛金額情報設定</summary>
        /// <param name="suplAccPay">買掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 鑑画面に買掛金額情報を設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsAccRecToClaim_panel(SuplAccPay suplAccPay)
		{
			// 鑑に情報を反映
            // 2009.01.14 >>>
#if false
            // 前回情報
            this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(suplAccPay.StckTtl3TmBfBlAccPay, true);
            this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(suplAccPay.StckTtl2TmBfBlAccPay, true);
            this.TtlLMBl_Label.Text    = Claim_panelDataFormat(suplAccPay.LastTimeAccPay,       true);

            this.TtlBf3TmBl_Label.Tag = suplAccPay.StckTtl3TmBfBlAccPay;
            this.TtlBf2TmBl_Label.Tag = suplAccPay.StckTtl2TmBfBlAccPay;
            this.TtlLMBl_Label.Tag    = suplAccPay.LastTimeAccPay;

			// 今回仕入
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.TtlSales_Label.Text   = Claim_panelDataFormat(suplAccPay.ThisTimeStockPrice, true);
            this.TtlSales_Label.Text    = Claim_panelDataFormat(suplAccPay.OfsThisTimeStock,true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.TtlTax_Label.Text     = Claim_panelDataFormat(suplAccPay.ThisStcPrcTax, true);
            this.TtlTax_Label.Text      = Claim_panelDataFormat(suplAccPay.OfsThisStockTax,true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回支払
            //this.TtlPaym_Label.Text    = Claim_panelDataFormat(suplAccPay.TtlIncDtbtTaxExc, true);
            //// 支払消費税
            //this.TtlPaymTax_Label.Text = Claim_panelDataFormat(suplAccPay.TtlIncDtbtTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回支払
            //Int64 DepoTotal = suplAccPay.ThisTimePayNrml    +       // 通常支払金額
            //                  suplAccPay.ThisTimeFeePayNrml +       // 通常手数料額
            //                  suplAccPay.ThisTimeDisPayNrml +       // 通常値引額
            //                  suplAccPay.ThisTimeRbtDmdNrml +       // 通常リベート額
            //                  suplAccPay.ThisTimeDmdDepo    +       // 預り金支払金額
            //                  suplAccPay.ThisTimeFeeDmdDepo +       // 預り金手数料額
            //                  suplAccPay.ThisTimeDisDmdDepo +       // 預り金値引額
            //                  suplAccPay.ThisTimeRbtDmdDepo;        // 預り金リベート額
            //this.TtlDepo_Label.Text   = Claim_panelDataFormat(DepoTotal, true);

            // 今回支払
            // 2008.11.25 modify start [8194]
            //Int64 DepoTotal = suplAccPay.ThisTimePayNrml +       // 通常支払金額
            //      suplAccPay.ThisTimeFeePayNrml +       // 通常手数料額
            //      suplAccPay.ThisTimeDisPayNrml;       // 通常値引額
            Int64 DepoTotal = suplAccPay.ThisTimePayNrml;      // 通常支払金額
            // 2008.11.25 modify end [8194]
            this.TtlDepo_Label.Text = Claim_panelDataFormat(DepoTotal, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            // 残高調整額
            //this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(suplAccPay.BalanceAdjust,true);
            this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(suplAccPay.BalanceAdjust + suplAccPay.TaxAdjust, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 残高
            // 2008.11.17 modify start [5045]
            this.TtlBl_Label.Text = Claim_panelDataFormat(suplAccPay.StckTtlAccPayBalance + suplAccPay.BalanceAdjust + suplAccPay.TaxAdjust, true);
			//this.TtlBl_Label.Text     = Claim_panelDataFormat(suplAccPay.StckTtlAccPayBalance, true);
            // 2008.11.17 modify end [5045]
            //this.TtlBl_Label.Text = Claim_panelDataFormat(suplAccPay.StckTtlAccPayBalance + suplAccPay.BalanceAdjust + suplAccPay.TaxAdjust, true);
#endif
            DataRow row = this._totalDisplayTable.Rows[0];

            // 残高情報
            row[AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF] = suplAccPay.StckTtl3TmBfBlAccPay;
            row[AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF] = suplAccPay.StckTtl2TmBfBlAccPay;
            row[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF] = suplAccPay.LastTimeAccPay;

            // 今回仕入
            row[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK] = suplAccPay.OfsThisTimeStock;
            // 消費税
            row[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX] = suplAccPay.OfsThisStockTax;
            // 今回支払
            Int64 depoTotal = suplAccPay.ThisTimePayNrml;       // 今回支払金額（通常支払）
            row[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM] = depoTotal;

            // 残高
            row[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE] = suplAccPay.StckTtlAccPayBalance;
            // 2009.01.14 <<<
		}

		/// <summary>画面に支払金額情報設定</summary>
        /// <param name="suplierPay">支払金額情報</param>
		/// <remarks>
		/// <br>Note       : 画面に支払金額情報を設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsDmdPrcToScreen(SuplierPay suplierPay)
		{
			// 計上日付
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (TDateTime.LongDateToDateTime(suplierPay.AddUpDate) == DateTime.MinValue)
            if ( suplierPay.AddUpDate == DateTime.MinValue )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                this.AddUpADate_tDateEdit.SetDateTime(DateTime.MinValue);
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.AddUpADate_tDateEdit.SetDateTime(TDateTime.LongDateToDateTime(suplierPay.AddUpDate));
                this.AddUpADate_tDateEdit.SetDateTime(suplierPay.AddUpDate);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
			this.AddUpADate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;

			// 鑑に情報を反映
            // 2009.01.14 >>>
            //DetailsDmdPrcToClaim_panel(suplierPay);
            DetailsDmdPrcToClaim_panel(( this._targetDivType == 1 ) ? this._suplierPayTotal : suplierPay);
            // 2009.01.14 <<<
	
			// ----- 詳細情報画面項目 -----
			// 前回残高情報
            this.LMBl_tNedit.SetValue(suplierPay.LastTimePayment);
            this.Bf2TmBl_tNedit.SetValue(suplierPay.StockTtl2TmBfBlPay);
            this.Bf3TmBl_tNedit.SetValue(suplierPay.StockTtl3TmBfBlPay);

			// 仕入・支払情報
            // 仕入
            this.TtlItdedStcOutTax_tNedit.SetValue(suplierPay.TtlItdedStcOutTax);
            this.TtlStockOuterTax_tNedit.SetValue(suplierPay.TtlStockOuterTax);
            this.TtlItdedStcInTax_tNedit.SetValue(suplierPay.TtlItdedStcInTax);
            this.TtlStockInnerTax_tNedit.SetValue(suplierPay.TtlStockInnerTax);
            this.TtlItdedStcTaxFree_tNedit.SetValue(suplierPay.TtlItdedStcTaxFree);
            // 2008.11.17 add start [5047]
            this.StockSlipCount_tNedit.SetValue(suplierPay.StockSlipCount);
            // 2008.11.17 add end [5047]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            this.TtlItdedRetOutTax_tNedit.SetValue( -1 * suplierPay.TtlItdedRetOutTax );
            this.TtlRetOuterTax_tNedit.SetValue( -1 * suplierPay.TtlRetOuterTax );
            this.TtlItdedRetInTax_tNedit.SetValue( -1 * suplierPay.TtlItdedRetInTax );
            this.TtlRetInnerTax_tNedit.SetValue( -1 * suplierPay.TtlRetInnerTax );
            this.TtlItdedRetTaxFree_tNedit.SetValue( -1 * suplierPay.TtlItdedRetTaxFree );
            // 値引
            this.TtlItdedDisOutTax_tNedit.SetValue( -1 * suplierPay.TtlItdedDisOutTax );
            this.TtlDisOuterTax_tNedit.SetValue( -1 * suplierPay.TtlDisOuterTax );
            this.TtlItdedDisInTax_tNedit.SetValue( -1 * suplierPay.TtlItdedDisInTax );
            this.TtlDisInnerTax_tNedit.SetValue( -1 * suplierPay.TtlDisInnerTax );
            this.TtlItdedDisTaxFree_tNedit.SetValue( -1 * suplierPay.TtlItdedDisTaxFree );
            // 残高調整
            this.BalanceAdjust_tNedit.SetValue(suplierPay.BalanceAdjust);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            this.TaxAdjust_tNedit.SetValue(suplierPay.TaxAdjust);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 現金仕入金額 (クリアする)
            //this.ThisCashStockPrice_tNedit.Clear();
            //this.ThisCashStockTax_tNedit.Clear();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 未決済金額 (クリアする)
            //this.NonStmntAppearance_tNedit.Clear();
            //this.NonStmntIsdone_tNedit.Clear();
            // 決済金額 (クリアする)
            //this.StmntAppearance_tNedit.Clear();
            //this.StmntIsdone_tNedit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 支払
            //this.ItdedPaymOutTax_tNedit.SetValue(suplierPay.ItdedPaymOutTax);
            //this.PaymentOutTax_tNedit.SetValue(suplierPay.PaymentOutTax);
            //this.ItdedPaymInTax_tNedit.SetValue(suplierPay.ItdedPaymInTax);
            //this.PaymentInTax_tNedit.SetValue(suplierPay.PaymentInTax);
            //this.ItdedPaymTaxFree_tNedit.SetValue(suplierPay.ItdedPaymTaxFree);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 受取
            //this.ThisRecvInnerTax_tNedit.SetValue( -1 * suplierPay.ThisRecvInnerTax );
            //this.ThisRecvInTax_tNedit.SetValue( -1 * suplierPay.ThisRecvInTax );
            //this.ThisRecvOuterTax_tNedit.SetValue( -1 * suplierPay.ThisRecvOuterTax );
            //this.ThisRecvOutTax_tNedit.SetValue( -1 * suplierPay.ThisRecvOutTax );
            //this.ThisRecvTaxFree_tNedit.SetValue( -1 * suplierPay.ThisRecvTaxFree );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

            // 2009.01.14 Add >>>
            this.OfsThisStockTax_tNedit.SetValue(suplierPay.OfsThisStockTax);
            this.OffsetOutTax_tNedit.SetValue(suplierPay.OffsetOutTax);
            // 2009.01.14 Add <<<

            // 支払情報
            // 通常支払
            //this.DepoNrml_tNedit.SetValue(suplierPay.ThisTimePayNrml);    // 2009.01.14 Del
            this.FeeNrml_tNedit.SetValue(suplierPay.ThisTimeFeePayNrml);
            this.DisNrml_tNedit.SetValue(suplierPay.ThisTimeDisPayNrml);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.SetValue(suplierPay.ThisTimeRbtDmdNrml);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 預り金
            //this.Depo_tNedit.SetValue(suplierPay.ThisTimeDmdDepo);
            //this.FeeDepo_tNedit.SetValue(suplierPay.ThisTimeFeeDmdDepo);
            //this.DisDepo_tNedit.SetValue(suplierPay.ThisTimeDisDmdDepo);
            //this.RbtDepo_tNedit.SetValue(suplierPay.ThisTimeRbtDmdDepo);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.09.10 TOKUNAGA ADD START
            // 支払条件
            if (suplierPay.PaymentCond == 0)
            {
                // 支払先マスタ参照
                Supplier supplierInfo;
                this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, this._targetSupplierCode);
                suplierPay.PaymentCond = supplierInfo.PaymentCond;
            }
            // 2009.01.14 >>>
            //this.PaymentCond_Label.Text = Supplier.GetPaymentCondName(suplierPay.PaymentCond);
            this.PaymentCond_Label.Text = this._suplAccPayAcs.GetDepsitStKindNm(this._enterpriseCode, suplierPay.PaymentCond);
            // 2009.01.14 <<<

            this.PaymentCondValue_tNedit.SetValue(suplierPay.PaymentCond);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.09.10 TOKUNAGA ADD END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 仕入伝票枚数
            this.StockSlipCount_tNedit.SetValue(suplierPay.StockSlipCount);

            // 支払予定日
            this.PaymentSchedule_tDateEdit.SetDateTime(suplierPay.PaymentSchedule);
            
            // 回収条件
            if (suplierPay.PaymentCond > 0) {


                // 仕入先マスタ参照
                //CustomerInfo customerInfo;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
                // CustSuppliクラス⇒Supplierクラスに変更
                // 同時に_customerInfoAcsクラスで取得することが不可能に
                //Supplier supplierInfo;
                //int status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, suplierPay.SupplierCd);
                //supplierInfo

                // 2009.01.14 >>>
                //this.PaymentCond_Label.Text = Supplier.GetPaymentCondName(suplierPay.PaymentCond);
                this.PaymentCond_Label.Text = this._suplAccPayAcs.GetDepsitStKindNm(this._enterpriseCode, suplierPay.PaymentCond);
                // 2009.01.14 <<<
                this.PaymentCondValue_tNedit.SetValue(suplierPay.PaymentCond);


                //CustSuppli custSuppli;
                // 呼び出し関数定義変更
                // ArrayListでSupplierの固まりを戻すように変更
                //this._supplierAcs.Search(out aList, this._enterpriseCode);
                //this._customerInfoAcs.ReadStaticMemoryData(out aList, this._enterpriseCode, this.TargetCustomerCode);
                //this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, this.TargetCustomerCode);

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END
                //this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, out custSuppli, this._enterpriseCode, this.TargetCustomerCode);
                //this._customerInfoAcs.ReadCacheMemoryData(out customerInfo, this._enterpriseCode, this._targetSupplierCode);
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 各合計欄に合計金額を反映
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_ItdedOutTaxTotalLabel();     // 外税対象金額合計
            //update_OutTaxTotalLabel();          // 外税金額合計
            //update_ItdedInTaxTotalLabel();      // 内税対象金額合計
            //update_InTaxTotalLabel();           // 内税金額合計
            //update_ItdedTaxFreeTotalLabel();    // 非課税対象金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_SalesTotalLabel();           // 仕入額合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_RetTotalLabel();             // 返品金額合計
            update_DisTotalLabel();             // 値引金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_PaymTotalLabel();            // 支払額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoPrcTotalLabel();         // 支払金額合計
            //update_FeeTotalLabel();             // 手数料額合計
            //update_DisTotalLabel();             // 値引額合計
            //update_RbtTotalLabel();             // リベート額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_NormalTotalLabel();          // 通常支払合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoTotalLabel();            // 預り金合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_RecvTotalLabel(); // 受取合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.14 >>>
            // 相殺後仕入外税対象額ラベルの反映
            this.update_ItdedOffsetOutTaxLabel();
            // 相殺後非課税対象額ラベルの反映
            this.update_ItdedOffsetTaxFreeLabel();
            // 相殺後仕入合計ラベルの反映
            this.update_OfsThisTimeSalesTotalLabel();
            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 残高合計ラベルの反映
            this.update_BlTotalLabel();
            // 2009.01.14 <<<

        }

        /// <summary>鑑画面に支払金額情報設定</summary>
        /// <param name="suplierPay">支払金額情報</param>
		/// <remarks>
		/// <br>Note       : 鑑画面に支払金額情報を設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsDmdPrcToClaim_panel(SuplierPay suplierPay)
		{
            // 2009.01.14 >>>
#if false
			// 鑑に情報を反映
			// 前回情報
            this.TtlBf3TmBl_Label.Text  = Claim_panelDataFormat(suplierPay.StockTtl3TmBfBlPay, true);
            this.TtlBf2TmBl_Label.Text  = Claim_panelDataFormat(suplierPay.StockTtl2TmBfBlPay, true);
			this.TtlLMBl_Label.Text     = Claim_panelDataFormat(suplierPay.LastTimePayment,      true);

            this.TtlBf3TmBl_Label.Tag  = suplierPay.StockTtl3TmBfBlPay;
            this.TtlBf2TmBl_Label.Tag  = suplierPay.StockTtl2TmBfBlPay;
			this.TtlLMBl_Label.Tag     = suplierPay.LastTimePayment;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回仕入
            //this.TtlSales_Label.Text   = Claim_panelDataFormat(suplierPay.ThisTimeStockPrice, true);
            //// 消費税
            //this.TtlTax_Label.Text     = Claim_panelDataFormat(suplierPay.ThisStcPrcTax, true);
            // 今回仕入
            this.TtlSales_Label.Text = Claim_panelDataFormat( suplierPay.OfsThisTimeStock, true );
            // 消費税
            this.TtlTax_Label.Text = Claim_panelDataFormat( suplierPay.OfsThisStockTax, true );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回支払
            //this.TtlPaym_Label.Text    = Claim_panelDataFormat(suplierPay.TtlIncDtbtTaxExc, true);
            //// 支払消費税
            //this.TtlPaymTax_Label.Text = Claim_panelDataFormat(suplierPay.TtlIncDtbtTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回支払
            //Int64 DepoTotal = suplierPay.ThisTimePayNrml    +       // 通常支払金額
            //                  suplierPay.ThisTimeFeePayNrml +       // 通常手数料額
            //                  suplierPay.ThisTimeDisPayNrml +       // 通常値引額
            //                  suplierPay.ThisTimeRbtDmdNrml +       // 通常リベート額
            //                  suplierPay.ThisTimeDmdDepo    +       // 預り金支払金額
            //                  suplierPay.ThisTimeFeeDmdDepo +       // 預り金手数料額
            //                  suplierPay.ThisTimeDisDmdDepo +       // 預り金値引額
            //                  suplierPay.ThisTimeRbtDmdDepo;        // 預り金リベート額
            //this.TtlDepo_Label.Text   = Claim_panelDataFormat(DepoTotal, true);
            // 今回支払
            // 2008.11.25 modify start [8194]
            //Int64 DepoTotal = suplierPay.ThisTimePayNrml +       // 通常支払金額
                              //suplierPay.ThisTimeFeePayNrml +       // 通常手数料額
                              //suplierPay.ThisTimeDisPayNrml;       // 通常値引額
            Int64 DepoTotal = suplierPay.ThisTimePayNrml;       // 通常支払金額
            // 2008.11.25 modify end [8194]
            this.TtlDepo_Label.Text = Claim_panelDataFormat(DepoTotal, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            // 残高調整
            //this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(suplierPay.BalanceAdjust, true);
            this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(suplierPay.BalanceAdjust + suplierPay.TaxAdjust, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			// 残高
            // 2008.11.17 modify start [5045]
            this.TtlBl_Label.Text = Claim_panelDataFormat(suplierPay.StockTotalPayBalance + suplierPay.BalanceAdjust + suplierPay.TaxAdjust, true);
			//this.TtlBl_Label.Text     = Claim_panelDataFormat(suplierPay.StockTotalPayBalance, true);
            // 2008.11.17 modify end [5045]
            //this.TtlBl_Label.Text = Claim_panelDataFormat(suplierPay.StockTotalPayBalance + suplierPay.BalanceAdjust + suplierPay.TaxAdjust, true);
#endif

            DataRow row = this._totalDisplayTable.Rows[0];

            // 残高情報
            row[AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF] = suplierPay.StockTtl3TmBfBlPay;
            row[AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF] = suplierPay.StockTtl2TmBfBlPay;
            row[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF] = suplierPay.LastTimePayment;

            // 今回仕入
            row[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK] = suplierPay.OfsThisTimeStock;
            // 消費税
            row[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX] = suplierPay.OfsThisStockTax;
            // 今回支払
            Int64 depoTotal = suplierPay.ThisTimePayNrml;       // 今回支払金額（通常支払）
            row[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM] = depoTotal;

            // 残高
            row[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE] = suplierPay.StockTotalPayBalance;
            // 2009.01.14 <<<

		}

        /// <summary>鑑画面の再計算処理</summary>
		/// <remarks>
		/// <br>Note       : 入力された項目で鑑情報を再計算します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void upDateClaim_PanelTextData()
		{
			// 買掛
			if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
			{
                SuplAccPay suplAccPay = this._editSuplAccPay;
                ScreenToSuplAccPay(ref suplAccPay);
                getKinSetInfo_Acc(ref suplAccPay);
                // かがみに情報を反映する
                // 2009.01.14 >>>
                //DetailsAccRecToClaim_panel(suplAccPay);
                DetailsAccRecToClaim_panel(( this._targetDivType == 1 ) ? this._suplAccPayTotal : suplAccPay);
                // 2009.01.14 <<<
            }
			else
			{
                SuplierPay suplierPay = this._editSuplierPay;
                ScreenToSuplierPay(ref suplierPay);
                getKinSetInfo_Dmd(ref suplierPay);
                // かがみに情報を反映する
                // 2009.01.14 >>>
                //DetailsDmdPrcToClaim_panel(suplierPay);
                DetailsDmdPrcToClaim_panel(( this._targetDivType == 1 ) ? this._suplierPayTotal : suplierPay);
                // 2009.01.14 <<<
            }
		}

		/// <summary>買掛金額KINSET処理</summary>
		/// <param name="suplAccPay">買掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 買掛金額のKINSET処理を実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void getKinSetInfo_Acc(ref SuplAccPay suplAccPay)
		{
            // 2009.01.14 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////Int64 TotalDepo = suplAccPay.ThisTimePayNrml    +
            ////                  suplAccPay.ThisTimeFeePayNrml +
            ////                  suplAccPay.ThisTimeDisPayNrml +
            ////                  suplAccPay.ThisTimeRbtDmdNrml +
            ////                  suplAccPay.ThisTimeDmdDepo    +
            ////                  suplAccPay.ThisTimeFeeDmdDepo +
            ////                  suplAccPay.ThisTimeDisDmdDepo +
            ////                  suplAccPay.ThisTimeRbtDmdDepo;
            //Int64 TotalDepo = suplAccPay.ThisTimePayNrml +
            //                  suplAccPay.ThisTimeFeePayNrml +
            //                  suplAccPay.ThisTimeDisPayNrml ;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 支払金額は、今回支払金額（通常支払）をそのまま使用する
            Int64 TotalDepo = suplAccPay.ThisTimePayNrml;
            // 2009.01.14 <<<

            // 2008.11.21 modify start [8040]
            //suplAccPay.ThisTimeTtlBlcAcPay    = suplAccPay.LastTimeAccPay - TotalDepo;
            suplAccPay.ThisTimeTtlBlcAcPay = suplAccPay.LastTimeAccPay + suplAccPay.StckTtl2TmBfBlAccPay + suplAccPay.StckTtl3TmBfBlAccPay - TotalDepo;
            // 2008.11.21 modify end [8040]
            suplAccPay.ThisTimeStockPrice        = suplAccPay.TtlItdedStcOutTax +
                                              suplAccPay.TtlItdedStcInTax  +
                                              suplAccPay.TtlItdedStcTaxFree;

            suplAccPay.ThisStcPrcTax         = suplAccPay.TtlStockOuterTax + suplAccPay.TtlStockInnerTax;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplAccPay.ThisStckPricRgds    = suplAccPay.TtlItdedRetOutTax +
                                              suplAccPay.TtlItdedRetInTax +
                                              suplAccPay.TtlItdedRetTaxFree;
            suplAccPay.ThisStcPrcTaxRgds  = suplAccPay.TtlRetOuterTax + suplAccPay.TtlRetInnerTax;
            suplAccPay.ThisStckPricDis     = suplAccPay.TtlItdedDisOutTax +
                                              suplAccPay.TtlItdedDisInTax +
                                              suplAccPay.TtlItdedDisTaxFree;
            suplAccPay.ThisStcPrcTaxDis   = suplAccPay.TtlDisOuterTax + suplAccPay.TtlDisInnerTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.TtlIncDtbtTaxExc     = suplAccPay.ItdedPaymOutTax +
            //                                  suplAccPay.ItdedPaymInTax  +
            //                                  suplAccPay.ItdedPaymTaxFree;
            //suplAccPay.TtlIncDtbtTax        = suplAccPay.PaymentOutTax + suplAccPay.PaymentInTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ItdedOffsetOutTax = suplAccPay.TtlItdedStcOutTax - suplAccPay.ItdedPaymOutTax;
            //suplAccPay.ItdedOffsetInTax = suplAccPay.TtlItdedStcInTax - suplAccPay.ItdedPaymInTax;
            //suplAccPay.ItdedOffsetTaxFree   = suplAccPay.TtlItdedStcTaxFree - suplAccPay.ItdedPaymTaxFree;
            //suplAccPay.OffsetOutTax         = suplAccPay.TtlStockOuterTax       - suplAccPay.PaymentOutTax;
            //suplAccPay.OffsetInTax          = suplAccPay.TtlStockInnerTax        - suplAccPay.PaymentInTax;
            suplAccPay.ItdedOffsetOutTax = suplAccPay.TtlItdedStcOutTax
                                            + suplAccPay.TtlItdedDisOutTax
                                            + suplAccPay.TtlItdedRetOutTax;
                                            //+ suplAccPay.ThisRecvOutTax;
            suplAccPay.ItdedOffsetInTax = suplAccPay.TtlItdedStcInTax
                                            + suplAccPay.TtlItdedDisInTax
                                            + suplAccPay.TtlItdedRetInTax;
                                            //+ suplAccPay.ThisRecvInTax;
            suplAccPay.ItdedOffsetTaxFree = suplAccPay.TtlItdedStcTaxFree
                                            + suplAccPay.TtlItdedDisTaxFree
                                            + suplAccPay.TtlItdedRetTaxFree;
                                            //+ suplAccPay.ThisRecvTaxFree;
            // 2009.01.14 Del >>>
            //suplAccPay.OffsetOutTax = suplAccPay.TtlStockOuterTax
            //                                + suplAccPay.TtlDisOuterTax
            //                                + suplAccPay.TtlRetOuterTax;
            //                                //+ suplAccPay.ThisRecvOuterTax;
            // 2009.01.14 Del <<<
            suplAccPay.OffsetInTax = suplAccPay.TtlStockInnerTax
                                            + suplAccPay.TtlDisInnerTax
                                            + suplAccPay.TtlRetInnerTax;
                                            //+ suplAccPay.ThisRecvInnerTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplAccPay.OfsThisTimeStock = suplAccPay.ItdedOffsetOutTax
                                              + suplAccPay.ItdedOffsetInTax
                                              + suplAccPay.ItdedOffsetTaxFree;
                                              //- suplAccPay.ThisStckPricRgds
                                              //- suplAccPay.ThisStckPricDis
                                              //+ suplAccPay.ThisCashStockPrice;
            // 2009.01.14 Del >>>
            //suplAccPay.OfsThisStockTax = suplAccPay.OffsetOutTax
            //                                  + suplAccPay.OffsetInTax;
            //                                  //- suplAccPay.ThisStcPrcTaxRgds
            //                                  //- suplAccPay.ThisStcPrcTaxDis 
            //                                  //+ suplAccPay.ThisCashStockTax;
            // 2009.01.14 Del <<<

            // 2009.01.14 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPay.StckTtlAccPayBalance    = suplAccPay.ThisTimeTtlBlcAcPay +
            ////                                  suplAccPay.ThisNetStckPrice  +
            ////                                  suplAccPay.ThisNetStcPrcTax;
            //suplAccPay.StckTtlAccPayBalance = suplAccPay.ThisTimeTtlBlcAcPay
            //                                    + suplAccPay.OfsThisTimeStock
            //                                    + suplAccPay.ThisStcPrcTax;
            //                                  //+ suplAccPay.OfsThisStockTax;
            //                                  //+ suplAccPay.BalanceAdjust;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            suplAccPay.StckTtlAccPayBalance = suplAccPay.ThisTimeTtlBlcAcPay
                                                + suplAccPay.OfsThisTimeStock
                                                + suplAccPay.OfsThisStockTax;
            // 2009.01.14 <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ThisRecvOffset = suplAccPay.ThisRecvOutTax
                                        //+ suplAccPay.ThisRecvInTax
                                        //+ suplAccPay.ThisRecvTaxFree;
            //suplAccPay.ThisRecvOffsetTax = suplAccPay.ThisRecvOuterTax
                                            //+ suplAccPay.ThisRecvInnerTax;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>支払金額KINSET処理</summary>
		/// <param name="suplierPay">支払金額情報</param>
		/// <remarks>
		/// <br>Note       : 支払金額のKINSET処理を実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private  void getKinSetInfo_Dmd(ref SuplierPay suplierPay)
		{
            // 2009.01.14 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////Int64 TotalDepo = suplierPay.ThisTimePayNrml    +
            ////                  suplierPay.ThisTimeFeePayNrml +
            ////                  suplierPay.ThisTimeDisPayNrml +
            ////                  suplierPay.ThisTimeRbtDmdNrml +
            ////                  suplierPay.ThisTimeDmdDepo    +
            ////                  suplierPay.ThisTimeFeeDmdDepo +
            ////                  suplierPay.ThisTimeDisDmdDepo +
            ////                  suplierPay.ThisTimeRbtDmdDepo;
            //Int64 TotalDepo = suplierPay.ThisTimePayNrml +
            //                  suplierPay.ThisTimeFeePayNrml +
            //                  suplierPay.ThisTimeDisPayNrml ;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 支払金額には今回支払金額（通常支払）をそのまま使用する
            Int64 TotalDepo = suplierPay.ThisTimePayNrml;
            // 2009.01.14 <<<

            // 2008.11.21 modify start [8040]
            //suplierPay.ThisTimeTtlBlcPay    = suplierPay.LastTimePayment - TotalDepo;
            suplierPay.ThisTimeTtlBlcPay = suplierPay.LastTimePayment + suplierPay.StockTtl2TmBfBlPay + suplierPay.StockTtl3TmBfBlPay- TotalDepo;
            // 2008.11.21 modify end [8040]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplierPay.ThisTimeStockPrice = suplierPay.TtlItdedStcOutTax +
                                       suplierPay.TtlItdedStcInTax +
                                       suplierPay.TtlItdedStcTaxFree;
            suplierPay.ThisStcPrcTax = suplierPay.TtlStockOuterTax + suplierPay.TtlStockInnerTax;

            // 2009.01.14 Add >>>
            suplierPay.ThisStckPricRgds = suplierPay.TtlItdedRetOutTax +
                                          suplierPay.TtlItdedRetInTax +
                                          suplierPay.TtlItdedRetTaxFree;
            suplierPay.ThisStcPrcTaxRgds = suplierPay.TtlRetOuterTax + suplierPay.TtlRetInnerTax;
            suplierPay.ThisStckPricDis = suplierPay.TtlItdedDisOutTax +
                                         suplierPay.TtlItdedDisInTax +
                                         suplierPay.TtlItdedDisTaxFree;
            suplierPay.ThisStcPrcTaxDis = suplierPay.TtlDisOuterTax + suplierPay.TtlDisInnerTax;
            // 2009.01.14 Add <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.TtlIncDtbtTaxExc     = suplierPay.ItdedPaymOutTax +
            //                                  suplierPay.ItdedPaymInTax  +
            //                                  suplierPay.ItdedPaymTaxFree;
            //suplierPay.TtlIncDtbtTax        = suplierPay.PaymentOutTax + suplierPay.PaymentInTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.ItdedOffsetOutTax = suplierPay.TtlItdedStcOutTax - suplierPay.ItdedPaymOutTax;
            //suplierPay.ItdedOffsetInTax     = suplierPay.TtlItdedStcInTax   - suplierPay.ItdedPaymInTax;
            //suplierPay.ItdedOffsetTaxFree   = suplierPay.TtlItdedStcTaxFree - suplierPay.ItdedPaymTaxFree;
            //suplierPay.OffsetOutTax         = suplierPay.TtlStockOuterTax       - suplierPay.PaymentOutTax;
            //suplierPay.OffsetInTax          = suplierPay.TtlStockInnerTax        - suplierPay.PaymentInTax;
            suplierPay.ItdedOffsetOutTax = suplierPay.TtlItdedStcOutTax
                                            + suplierPay.TtlItdedDisOutTax
                                            + suplierPay.TtlItdedRetOutTax;
                                            //+ suplierPay.ThisRecvOutTax;
            suplierPay.ItdedOffsetInTax = suplierPay.TtlItdedStcInTax
                                            + suplierPay.TtlItdedDisInTax
                                            + suplierPay.TtlItdedRetInTax;
                                            //+ suplierPay.ThisRecvInTax;
            suplierPay.ItdedOffsetTaxFree = suplierPay.TtlItdedStcTaxFree
                                            + suplierPay.TtlItdedDisTaxFree
                                            + suplierPay.TtlItdedRetTaxFree;
                                            //+ suplierPay.ThisRecvTaxFree;
            // 2009.01.14 Del >>>
            //suplierPay.OffsetOutTax = suplierPay.TtlStockOuterTax
            //                                + suplierPay.TtlDisOuterTax
            //                                + suplierPay.TtlRetOuterTax;
            //                                //+ suplierPay.ThisRecvOuterTax;
            // 2009.01.14 Del <<<
            suplierPay.OffsetInTax = suplierPay.TtlStockInnerTax
                                            + suplierPay.TtlDisInnerTax
                                            + suplierPay.TtlRetInnerTax;
                                            //+ suplierPay.ThisRecvInnerTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplierPay.OfsThisTimeStock = suplierPay.ItdedOffsetOutTax
                                              + suplierPay.ItdedOffsetInTax
                                              + suplierPay.ItdedOffsetTaxFree;
                                              //- suplierPay.ThisStckPricRgds
                                              //- suplierPay.ThisStckPricDis;
            // 2009.01.14 Del >>>
            //suplierPay.OfsThisStockTax = suplierPay.OffsetOutTax
            //                                  + suplierPay.OffsetInTax;
            //                                  //- suplierPay.ThisStcPrcTaxRgds
            //                                  //- suplierPay.ThisStcPrcTaxDis;
            // 2009.01.14 Del <<<
            suplierPay.StockTotalPayBalance = suplierPay.ThisTimeTtlBlcPay
                                              + suplierPay.OfsThisTimeStock
                                                +suplierPay.OfsThisStockTax;
                                              //+ suplierPay.OfsThisStockTax;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.ThisRecvOffset = suplierPay.ThisRecvOutTax
                                        //+ suplierPay.ThisRecvInTax
                                        //+ suplierPay.ThisRecvTaxFree;
            //suplierPay.ThisRecvOffsetTax = suplierPay.ThisRecvOuterTax
                                            //+ suplierPay.ThisRecvInnerTax;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END
        }

		/// <summary>画面情報を買掛金額に反映処理</summary>
		/// <param name="suplAccPay">買掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 画面項目情報を買掛金額に設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void ScreenToSuplAccPay(ref SuplAccPay suplAccPay)
		{
            suplAccPay.EnterpriseCode       = this._enterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            // 仕入先
            suplAccPay.SupplierCd = Int32.Parse(this.customerCode_Label.Text);
            suplAccPay.SupplierNm1 = this.CustomerName_Label.Text;
            suplAccPay.SupplierNm2 = this.CustomerName2_Label.Text;
            suplAccPay.SupplierSnm = this.CustomerSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END
            // 支払先
            suplAccPay.PayeeCode = Int32.Parse(this.claimCode_Label.Text);
            suplAccPay.PayeeName = this.PayeeName_Label.Text;
            suplAccPay.PayeeName2 = this.PayeeName2_Label.Text;
            suplAccPay.PayeeSnm = this.PayeeSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // --- ADD 2012/09/18 ---------->>>>>
            if (this._sumSuppEnable)
            {
                // 支払先情報を仕入先情報で上書きする
                suplAccPay.PayeeCode = Int32.Parse(this.customerCode_Label.Text);
                suplAccPay.PayeeName = this.CustomerName_Label.Text;
                suplAccPay.PayeeName2 = this.CustomerName2_Label.Text;
                suplAccPay.PayeeSnm = this.CustomerSnm_Label.Text;
            }
            // --- ADD 2012/09/18 ----------<<<<<

			// 計上日付
			if ( this.AddUpADate_tDateEdit.Enabled == true )
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //suplAccPay.AddUpYearMonth = this.AddUpADate_tDateEdit.GetLongDate();
                //suplAccPay.AddUpDate      = this.AddUpADate_tDateEdit.GetLongDate();
                suplAccPay.AddUpYearMonth = this.AddUpADate_tDateEdit.GetDateTime();
                suplAccPay.AddUpDate = this.AddUpADate_tDateEdit.GetDateTime();                
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
			// 仕入
			suplAccPay.TtlItdedStcOutTax     = (Int64)this.TtlItdedStcOutTax_tNedit.GetValue();
			suplAccPay.TtlStockOuterTax          = (Int64)this.TtlStockOuterTax_tNedit.GetValue();
            suplAccPay.TtlItdedStcInTax      = (Int64)this.TtlItdedStcInTax_tNedit.GetValue();
            suplAccPay.TtlStockInnerTax           = (Int64)this.TtlStockInnerTax_tNedit.GetValue();
            suplAccPay.TtlItdedStcTaxFree    = (Int64)this.TtlItdedStcTaxFree_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            suplAccPay.TtlItdedRetOutTax = -1 * (Int64)this.TtlItdedRetOutTax_tNedit.GetValue();
            suplAccPay.TtlRetOuterTax = -1 * (Int64)this.TtlRetOuterTax_tNedit.GetValue();
            suplAccPay.TtlItdedRetInTax = -1 * (Int64)this.TtlItdedRetInTax_tNedit.GetValue();
            suplAccPay.TtlRetInnerTax = -1 * (Int64)this.TtlRetInnerTax_tNedit.GetValue();
            suplAccPay.TtlItdedRetTaxFree = -1 * (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue();
            // 値引
            suplAccPay.TtlItdedDisOutTax = -1 * (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();
            suplAccPay.TtlDisOuterTax = -1 * (Int64)this.TtlDisOuterTax_tNedit.GetValue();
            suplAccPay.TtlItdedDisInTax = -1 * (Int64)this.TtlItdedDisInTax_tNedit.GetValue();
            suplAccPay.TtlDisInnerTax = -1 * (Int64)this.TtlDisInnerTax_tNedit.GetValue();
            suplAccPay.TtlItdedDisTaxFree = -1 * (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();
            // 残高調整
            suplAccPay.BalanceAdjust        = (Int64)this.BalanceAdjust_tNedit.GetValue();

            // 消費税調整額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            suplAccPay.TaxAdjust = (Int64)this.TaxAdjust_tNedit.GetValue();
            suplAccPay.StockSlipCount = (Int32)this.StockSlipCount_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // 未決済金額
            //suplAccPay.NonStmntAppearance   = (Int64)this.NonStmntAppearance_tNedit.GetValue();
            //suplAccPay.NonStmntIsdone       = (Int64)this.NonStmntIsdone_tNedit.GetValue();
            // 決済金額
            //suplAccPay.StmntAppearance      = (Int64)this.StmntAppearance_tNedit.GetValue();
            //suplAccPay.StmntIsdone          = (Int64)this.StmntIsdone_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

            //// 現金仕入
            //suplAccPay.ThisCashStockPrice    = (Int64)this.ThisCashStockPrice_tNedit.GetValue();
            //suplAccPay.ThisCashStockTax      = (Int64)this.ThisCashStockTax_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 支払
            //suplAccPay.ItdedPaymOutTax      = (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //suplAccPay.PaymentOutTax        = (Int64)this.PaymentOutTax_tNedit.GetValue();
            //suplAccPay.ItdedPaymInTax       = (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //suplAccPay.PaymentInTax         = (Int64)this.PaymentInTax_tNedit.GetValue();
            //suplAccPay.ItdedPaymTaxFree     = (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 支払
            //suplAccPay.ThisTimePayNrml      = (Int64)this.DepoNrml_tNedit.GetValue();     // 2009.01.14 Del
			suplAccPay.ThisTimeFeePayNrml   = (Int64)this.FeeNrml_tNedit.GetValue();
			suplAccPay.ThisTimeDisPayNrml   = (Int64)this.DisNrml_tNedit.GetValue();

            // 2009.01.14 Add >>>
            // 支払内訳の合計を加算
            object value = this._payeeDataTable.Compute(string.Format("SUM({0})", ctPayment), string.Empty);
            Int64 total = ( value is DBNull ) ? 0 : (Int64)value;
            suplAccPay.ThisTimePayNrml = total + suplAccPay.ThisTimeFeePayNrml + suplAccPay.ThisTimeDisPayNrml;

            // 消費税
            suplAccPay.OfsThisStockTax = (Int64)this.OfsThisStockTax_tNedit.GetValue();
            suplAccPay.OffsetOutTax = (Int64)this.OffsetOutTax_tNedit.GetValue();
            // 2009.01.14 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ThisTimeRbtDmdNrml   = (Int64)this.RbtNrml_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ThisTimeDmdDepo      = (Int64)this.Depo_tNedit.GetValue();
            //suplAccPay.ThisTimeFeeDmdDepo   = (Int64)this.FeeDepo_tNedit.GetValue();
            //suplAccPay.ThisTimeDisDmdDepo   = (Int64)this.DisDepo_tNedit.GetValue();
            //suplAccPay.ThisTimeRbtDmdDepo   = (Int64)this.RbtDepo_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 受取
            //suplAccPay.ThisRecvInnerTax = -1 * (Int64)this.ThisRecvInnerTax_tNedit.GetValue();
            //suplAccPay.ThisRecvInTax = -1 * (Int64)this.ThisRecvInTax_tNedit.GetValue();
            //suplAccPay.ThisRecvOuterTax = -1 * (Int64)this.ThisRecvOuterTax_tNedit.GetValue();
            //suplAccPay.ThisRecvOutTax = -1 * (Int64)this.ThisRecvOutTax_tNedit.GetValue();
            //suplAccPay.ThisRecvTaxFree = -1 * (Int64)this.ThisRecvTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

			// かがみ情報
			// 前回情報
			suplAccPay.StckTtl3TmBfBlAccPay = (Int64)Bf3TmBl_tNedit.GetValue();
			suplAccPay.StckTtl2TmBfBlAccPay = (Int64)Bf2TmBl_tNedit.GetValue(); 
			suplAccPay.LastTimeAccPay       = (Int64)LMBl_tNedit.GetValue();

            // 2009.01.14 Add >>>
            if (this._targetDivType == 0)
            {
                suplAccPay.SupplierCd = 0;
                suplAccPay.SupplierNm1 = "";
                suplAccPay.SupplierNm2 = "";
                suplAccPay.SupplierSnm= "";
            }
            // 2009.01.14 Add <<<
		}

        /// <summary>画面情報を支払金額に反映処理</summary>
		/// <param name="suplierPay">支払金額情報</param>
		/// <remarks>
		/// <br>Note       : 画面項目情報を支払金額に設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void ScreenToSuplierPay(ref SuplierPay suplierPay)
		{
            suplierPay.EnterpriseCode      = this._enterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 仕入先
            suplierPay.SupplierCd = Int32.Parse(this.customerCode_Label.Text);
            suplierPay.SupplierNm1 = this.CustomerName_Label.Text;
            suplierPay.SupplierNm2 = this.CustomerName2_Label.Text;
            suplierPay.SupplierSnm = this.CustomerSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END

            // 支払先
            suplierPay.PayeeCode = Int32.Parse(this.claimCode_Label.Text);
            suplierPay.PayeeName = this.PayeeName_Label.Text;
            suplierPay.PayeeName2 = this.PayeeName2_Label.Text;
            suplierPay.PayeeSnm = this.PayeeSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // --- ADD 2012/09/18 ---------->>>>>
            if (this._sumSuppEnable)
            {
                // 支払先情報を仕入先情報で上書きする
                suplierPay.PayeeCode = Int32.Parse(this.customerCode_Label.Text);
                suplierPay.PayeeName = this.CustomerName_Label.Text;
                suplierPay.PayeeName2 = this.CustomerName2_Label.Text;
                suplierPay.PayeeSnm = this.CustomerSnm_Label.Text;
            }
            // --- ADD 2012/09/18 ----------<<<<<

			// 計上日付
			if ( this.AddUpADate_tDateEdit.Enabled == true )
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //suplierPay.AddUpYearMonth = this.AddUpADate_tDateEdit.GetLongDate();
                //suplierPay.AddUpDate      = this.AddUpADate_tDateEdit.GetLongDate();
                suplierPay.AddUpYearMonth = this.AddUpADate_tDateEdit.GetDateTime();
                suplierPay.AddUpDate = this.AddUpADate_tDateEdit.GetDateTime();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
			// 仕入
			suplierPay.TtlItdedStcOutTax    = (Int64)this.TtlItdedStcOutTax_tNedit.GetValue();
			suplierPay.TtlStockOuterTax         = (Int64)this.TtlStockOuterTax_tNedit.GetValue();
            suplierPay.TtlItdedStcInTax     = (Int64)this.TtlItdedStcInTax_tNedit.GetValue();
            suplierPay.TtlStockInnerTax          = (Int64)this.TtlStockInnerTax_tNedit.GetValue();
            suplierPay.TtlItdedStcTaxFree   = (Int64)this.TtlItdedStcTaxFree_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            suplierPay.TtlItdedRetOutTax   = -1 * (Int64)this.TtlItdedRetOutTax_tNedit.GetValue();
            suplierPay.TtlRetOuterTax = -1 * (Int64)this.TtlRetOuterTax_tNedit.GetValue();
            suplierPay.TtlItdedRetInTax = -1 * (Int64)this.TtlItdedRetInTax_tNedit.GetValue();
            suplierPay.TtlRetInnerTax = -1 * (Int64)this.TtlRetInnerTax_tNedit.GetValue();
            suplierPay.TtlItdedRetTaxFree = -1 * (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue();
            // 値引
            suplierPay.TtlItdedDisOutTax = -1 * (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();
            suplierPay.TtlDisOuterTax = -1 * (Int64)this.TtlDisOuterTax_tNedit.GetValue();
            suplierPay.TtlItdedDisInTax = -1 * (Int64)this.TtlItdedDisInTax_tNedit.GetValue();
            suplierPay.TtlDisInnerTax = -1 * (Int64)this.TtlDisInnerTax_tNedit.GetValue();
            suplierPay.TtlItdedDisTaxFree = -1 * (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();
            // 残高調整
            suplierPay.BalanceAdjust       = (Int64)this.BalanceAdjust_tNedit.GetValue();

            // 消費税調整額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            suplierPay.TaxAdjust = (Int64)this.TaxAdjust_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // 仕入伝票枚数
            suplierPay.StockSlipCount     = (Int32)this.StockSlipCount_tNedit.GetValue();

            // 支払予定日
            // --- CHG 2009/01/28 障害ID:10446対応------------------------------------------------------>>>>>
            //suplierPay.PaymentSchedule = this.PaymentSchedule_tDateEdit.GetDateTime();
            if (this._dmdPrcDataIndex < 0)
            {
                Supplier supplierInfo;
                this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, this._targetSupplierCode);

                DateTime paymentSchedule = suplierPay.AddUpDate;
                switch (supplierInfo.PaymentMonthCode) // 0:当月,1:翌月,2:翌々月,3翌々々月
                {
                    case 1:
                        paymentSchedule = paymentSchedule.AddMonths(1);
                        break;
                    case 2:
                        paymentSchedule = paymentSchedule.AddMonths(2);
                        break;
                    case 3:
                        paymentSchedule = paymentSchedule.AddMonths(3);
                        break;
                }
                // 28日以降は末日とする
                if (supplierInfo.PaymentDay >= 28)
                {
                    paymentSchedule = new DateTime(paymentSchedule.Year, paymentSchedule.Month, 1);
                    paymentSchedule = paymentSchedule.AddMonths(1);
                    paymentSchedule = paymentSchedule.AddDays(-1);
                }
                else
                {
                    paymentSchedule = new DateTime(paymentSchedule.Year, paymentSchedule.Month, supplierInfo.PaymentDay);
                }
                suplierPay.PaymentSchedule = paymentSchedule;　// 支払予定日
            }
            else
            {
                suplierPay.PaymentSchedule = this.PaymentSchedule_tDateEdit.GetDateTime();
            }
            // --- CHG 2009/01/28 障害ID:10446対応------------------------------------------------------<<<<<

            // 回収条件
            suplierPay.PaymentCond         = (Int32)this.PaymentCondValue_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 支払
            //suplierPay.ItdedPaymOutTax     = (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //suplierPay.PaymentOutTax       = (Int64)this.PaymentOutTax_tNedit.GetValue();
            //suplierPay.ItdedPaymInTax      = (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //suplierPay.PaymentInTax        = (Int64)this.PaymentInTax_tNedit.GetValue();
            //suplierPay.ItdedPaymTaxFree    = (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 支払
            //suplierPay.ThisTimePayNrml = (Int64)this.DepoNrml_tNedit.GetValue();    // 2009.01.14 Del
            // --- DEL 2012/09/18 ---------->>>>>
            //suplierPay.ThisTimeFeePayNrml = (Int64)this.DisNrml_tNedit.GetValue();
            //suplierPay.ThisTimeDisPayNrml = (Int64)this.FeeNrml_tNedit.GetValue();
            // --- DEL 2012/09/18 ----------<<<<<
            // --- ADD 2012/09/18 ---------->>>>>
            suplierPay.ThisTimeFeePayNrml = (Int64)this.FeeNrml_tNedit.GetValue();
            suplierPay.ThisTimeDisPayNrml = (Int64)this.DisNrml_tNedit.GetValue();
            // --- ADD 2012/09/18 ----------<<<<<

            // 2009.01.14 Add >>>
            object value = this._payeeDataTable.Compute(string.Format("SUM({0})", ctPayment), string.Empty);
            Int64 total = ( value is DBNull ) ? 0 : (Int64)value;
            suplierPay.ThisTimePayNrml = total + suplierPay.ThisTimeFeePayNrml + suplierPay.ThisTimeDisPayNrml;

            suplierPay.OfsThisStockTax = (Int64)this.OfsThisStockTax_tNedit.GetValue();
            suplierPay.OffsetOutTax = (Int64)this.OffsetOutTax_tNedit.GetValue();
            // 2009.01.14 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.ThisTimeRbtDmdNrml  = (Int64)this.RbtNrml_tNedit.GetValue();
            //suplierPay.ThisTimeDmdDepo     = (Int64)this.Depo_tNedit.GetValue();
            //suplierPay.ThisTimeFeeDmdDepo  = (Int64)this.DisDepo_tNedit.GetValue();
            //suplierPay.ThisTimeDisDmdDepo  = (Int64)this.FeeDepo_tNedit.GetValue();
            //suplierPay.ThisTimeRbtDmdDepo  = (Int64)this.RbtDepo_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 受取
            //suplierPay.ThisRecvInnerTax = -1 * (Int64)this.ThisRecvInnerTax_tNedit.GetValue();
            //suplierPay.ThisRecvInTax = -1 * (Int64)this.ThisRecvInTax_tNedit.GetValue();
            //suplierPay.ThisRecvOuterTax = -1 * (Int64)this.ThisRecvOuterTax_tNedit.GetValue();
            //suplierPay.ThisRecvOutTax = -1 * (Int64)this.ThisRecvOutTax_tNedit.GetValue();
            //suplierPay.ThisRecvTaxFree = -1 * (Int64)this.ThisRecvTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END

			// かがみ情報
			// 前回情報
			suplierPay.StockTtl3TmBfBlPay = (Int64)Bf3TmBl_tNedit.GetValue();
			suplierPay.StockTtl2TmBfBlPay = (Int64)Bf2TmBl_tNedit.GetValue(); 
			suplierPay.LastTimePayment      = (Int64)LMBl_tNedit.GetValue();

            // 2009.01.14 Add >>>
            if (this._targetDivType == 0)
            {
                suplierPay.SupplierCd = 0;
                suplierPay.SupplierNm1 = "";
                suplierPay.SupplierNm2 = "";
                suplierPay.SupplierSnm = "";
                suplierPay.ResultsSectCd = SuplAccPayAcs.ALL_SECTION;
            }
            else
            {

            }
            // 2009.01.14 Add <<<
        }

        // 2009.01.14 Add >>>
        /// <summary>
        /// 精算支払集計データリスト取得処理
        /// </summary>
        /// <returns></returns>
        private List<AccPayTotal> GetAccPayTotalList()
        {
            List<AccPayTotal> returnList = new List<AccPayTotal>();

            DataRow[] paymentRows = this.GetPaymentRows();

            if (( paymentRows != null ) && ( paymentRows.Length > 0 ))
            {
                foreach (DataRow row in paymentRows)
                {
                    AccPayTotal accPayTotal = new AccPayTotal();
                    accPayTotal.MoneyKindCode = (Int32)row[ctMoneyKindCode];   // 金種コード
                    accPayTotal.MoneyKindName = (string)row[ctMoneyKindName];  // 金種名称
                    accPayTotal.MoneyKindDiv = (Int32)row[ctMoneyKindDiv];     // 金種区分
                    accPayTotal.Payment = (Int64)row[ctPayment];               // 支払金額
                    returnList.Add(accPayTotal);
                }
            }

            return returnList;
        }

        /// <summary>
        /// 買掛支払集計データリスト取得処理
        /// </summary>
        /// <returns></returns>
        private List<ACalcPayTotal> GetACalcPayTotalList()
        {
            List<ACalcPayTotal> returnList = new List<ACalcPayTotal>();

            DataRow[] paymentRows = this.GetPaymentRows();

            if (( paymentRows != null ) && ( paymentRows.Length > 0 ))
            {
                foreach (DataRow row in paymentRows)
                {
                    ACalcPayTotal aCalcPayTotal = new ACalcPayTotal();
                    aCalcPayTotal.MoneyKindCode = (Int32)row[ctMoneyKindCode];   // 金種コード
                    aCalcPayTotal.MoneyKindName = (string)row[ctMoneyKindName];  // 金種名称
                    aCalcPayTotal.MoneyKindDiv = (Int32)row[ctMoneyKindDiv];     // 金種区分
                    aCalcPayTotal.Payment = (Int64)row[ctPayment];               // 支払金額
                    returnList.Add(aCalcPayTotal);
                }
            }

            return returnList;
        }
        // 2009.01.14 Add <<<

        # endregion

		// ===================================================================================== //
		// 内部メソッド（保存・削除関連）
		// ===================================================================================== //
		#region Privete Methods WriteAndDelete_Relation Methods

        /// <summary>画面入力情報不正チェック処理</summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool CheckScreenData(ref Control control, ref string message)
		{
			bool result = true;

            // GetDateTimeを使用すると不正なデータでもMinValueになる為、LongDateを使用する
			if ( this.AddUpADate_tDateEdit.LongDate == 0 )
            {
				control = AddUpADate_tDateEdit;
				message = this.AddUpADate_Tittle_Label.Text + "を入力して下さい。";
				//result = false;
                return false;
			}
    		// 日付の入力チェック追加 
			else if (( this.AddUpADate_tDateEdit.LongDate != 0  ) && 
                     (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(this.AddUpADate_tDateEdit.LongDate)) == false))
			{
				control = AddUpADate_tDateEdit;
				message = this.AddUpADate_Tittle_Label.Text + "が不正です。正しい日付を入力して下さい。";
				//result = false;
                return false;
			}

            // --- ADD 2009/01/28 障害ID:10446対応------------------------------------------------------>>>>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.09.10 TOKUNAGA ADD START
            //if (this.SuplierPay_panel.Visible == true)
            //{
            //    // 日付の入力チェック追加 
            //    if (this.PaymentSchedule_tDateEdit.LongDate == 0)
            //    {
            //        control = PaymentSchedule_tDateEdit;
            //        message = this.ultraLabel50.Text + "を入力して下さい。";
            //        //result = false;
            //        return false;
            //    }
            //    else if ((this.PaymentSchedule_tDateEdit.LongDate != 0) &&
            //             (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(this.PaymentSchedule_tDateEdit.LongDate)) == false))
            //    {
            //        control = PaymentSchedule_tDateEdit;
            //        message = this.ultraLabel50.Text + "が不正です。正しい日付を入力して下さい。";
            //        //result = false;
            //        return false;
            //    }
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.09.10 TOKUNAGA ADD END
            ////else
            ////{
            // --- ADD 2009/01/28 障害ID:10446対応------------------------------------------------------<<<<<

            DataRow[] rows = this.GetPaymentRows();         // 2009.01.14
            
                // 項目チェック
                if (
                    // 残高
                    // 2009.01.14 Del >>>
                    //((Int64)this.TtlBf3TmBl_Label.Tag == 0) &&
                    //((Int64)this.TtlBf2TmBl_Label.Tag == 0) &&
                    //((Int64)this.TtlLMBl_Label.Tag == 0) &&
                    // 2009.01.14 Del <<<
                    // 仕入
                    (this.TtlItdedStcOutTax_tNedit.GetValue() == 0) &&
                    (this.TtlStockOuterTax_tNedit.GetValue() == 0) &&
                    (this.TtlItdedStcInTax_tNedit.GetValue() == 0) &&
                    (this.TtlStockInnerTax_tNedit.GetValue() == 0) &&
                    (this.TtlItdedStcTaxFree_tNedit.GetValue() == 0) &&
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // 返品
                    (this.TtlItdedRetOutTax_tNedit.GetValue() == 0) &&
                    (this.TtlRetOuterTax_tNedit.GetValue() == 0) &&
                    (this.TtlItdedRetInTax_tNedit.GetValue() == 0) &&
                    (this.TtlRetInnerTax_tNedit.GetValue() == 0) &&
                    (this.TtlItdedRetTaxFree_tNedit.GetValue() == 0) &&
                    // 値引
                    (this.TtlItdedDisOutTax_tNedit.GetValue() == 0) &&
                    (this.TtlDisOuterTax_tNedit.GetValue() == 0) &&
                    (this.TtlItdedDisInTax_tNedit.GetValue() == 0) &&
                    (this.TtlDisInnerTax_tNedit.GetValue() == 0) &&
                    (this.TtlItdedDisTaxFree_tNedit.GetValue() == 0) &&
                    // 残高
                    ( this.Bf3TmBl_tNedit.GetValue() == 0 ) &&
                    ( this.Bf2TmBl_tNedit.GetValue() == 0 ) &&
                    ( this.LMBl_tNedit.GetValue() == 0 ) &&
                    // 残高調整
                    (this.BalanceAdjust_tNedit.GetValue() == 0) &&
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 現金仕入
                    //( this.ThisCashStockPrice_tNedit.GetValue() == 0) &&
                    //( this.ThisCashStockTax_tNedit.GetValue() == 0) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuk

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
                    // 未決済金額
                    //( this.NonStmntAppearance_tNedit.GetValue() == 0 ) &&
                    //( this.NonStmntIsdone_tNedit.GetValue() == 0 ) &&
                    // 決済金額
                    //( this.StmntAppearance_tNedit.GetValue() == 0 ) &&
                    //( this.StmntIsdone_tNedit.GetValue() == 0 ) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 支払
                    //(this.ItdedPaymOutTax_tNedit.GetValue()   == 0) &&
                    //(this.PaymentOutTax_tNedit.GetValue()     == 0) &&
                    //(this.ItdedPaymInTax_tNedit.GetValue()    == 0) &&
                    //(this.PaymentInTax_tNedit.GetValue()      == 0) &&
                    //(this.ItdedPaymTaxFree_tNedit.GetValue()  == 0) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // 通常支払
                    // 2009.01.14 >>>
                    //(this.DepoNrml_tNedit.GetValue() == 0) &&    
                    ( ( rows == null ) || ( rows.Length == 0 ) ) &&
                    // 2009.01.14 <<<
                    ( this.FeeNrml_tNedit.GetValue() == 0 ) &&
                    // --- DEL 2012/09/18 ---------->>>>>
                    //(this.DisNrml_tNedit.GetValue() == 0))// &&
                    // --- DEL 2012/09/18 ----------<<<<<
                    // --- ADD 2012/09/18 ---------->>>>>
                    (this.DisNrml_tNedit.GetValue() == 0) &&
                    !_sumSuppEnable)
                    // --- ADD 2012/09/18 ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //(this.RbtNrml_tNedit.GetValue()           == 0) &&
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 預り金支払
                //(this.Depo_tNedit.GetValue()              == 0) &&
                //(this.FeeDepo_tNedit.GetValue()           == 0) &&
                //(this.DisDepo_tNedit.GetValue()           == 0) &&
                //(this.RbtDepo_tNedit.GetValue()           == 0))
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
                // 今回受取
                //(this.ThisRecvOutTax_tNedit.GetValue() == 0) &&
                //(this.ThisRecvInTax_tNedit.GetValue() == 0) &&
                //(this.ThisRecvTaxFree_tNedit.GetValue() == 0) &&
                //(this.ThisRecvOuterTax_tNedit.GetValue() == 0) &&
                //(this.ThisRecvInnerTax_tNedit.GetValue() == 0))
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END
                {
                    //---DEL 2023/11/22 陳艶丹 すべて0の値でも登録可能に修正対応--->>>>>
                    //control = this.TtlItdedStcOutTax_tNedit;
                    //message = "全ての金額が未入力での更新はできません。";
                    //result = false;
                    //---DEL 2023/11/22 陳艶丹 すべて0の値でも登録可能に修正対応---<<<<<
                }
            //}
		
			return result;
		}

        /// <summary>保存処理</summary>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の保存処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool SaveProc()
		{
			bool result = false;
			
			Control control = null;
			string errmsg = "";

            // 2009.01.14 Add >>>
            List<ACalcPayTotal> aCalcPayTotalList = new List<ACalcPayTotal>();
            List<AccPayTotal> accPayTotalList = new List<AccPayTotal>();
            // 2009.01.14 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE)) //支払時のみ
            {
                this._editSuplierPay.AddUpSecCode = this._condPaymentSectionCode;
                this._editSuplierPay.SupplierCd = this._condSupplierCode;
                this._editSuplierPay.PayeeCode = this._condPayeeCode;
                this._editSuplierPay.ResultsSectCd = this._condSectionCode;

                ScreenToSuplierPay(ref _editSuplierPay);

                // 2009.01.14 Add >>>
                if (this._targetDivType == 0)
                {
                    accPayTotalList = this.GetAccPayTotalList();
                }
                // 2009.01.14 Add <<<
            }
            else
            {
                this._editSuplAccPay.AddUpSecCode = this._condPaymentSectionCode;
                this._editSuplAccPay.SupplierCd = this._condSupplierCode;
                this._editSuplAccPay.PayeeCode = this._condPayeeCode;

                ScreenToSuplAccPay(ref _editSuplAccPay);

                // 2009.01.14 Add >>>
                if (this._targetDivType == 0)
                {
                    aCalcPayTotalList = this.GetACalcPayTotalList();
                }
                // 2009.01.14 Add <<<
            }
           
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

			// 更新前チェック処理
			// 画面入力情報不正チェック処理
			if (!CheckScreenData(ref control, ref errmsg))
			{
				TMsgDisp.Show(this,										// 親ウィンドウフォーム
					          emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
					          "MAKAU09130U",						// アセンブリＩＤまたはクラスＩＤ
					          errmsg,									// 表示するメッセージ 
					          0,										// ステータス値
					          MessageBoxButtons.OK);					// 表示するボタン

				control.Focus();
				if(control is TEdit)   ((TEdit)control).SelectAll();
				if(control is TNedit)  ((TNedit)control).SelectAll();
				return result;
			}
            // 2009.01.14 >>>
            //result = SaveDetailsProc(ref this._editSuplAccPay, ref this._editSuplierPay);
            result = SaveDetailsProc(ref this._editSuplAccPay, ref this._editSuplierPay, ref aCalcPayTotalList, ref accPayTotalList);
            // 2009.01.14 <<<

#if false
			// オプションが存在しない場合は、全社計も更新する
			if (( this.Opt_Section == false ) && ( result  == true )&& (this._autoAllUpDateMode == true ))
			{
				// 全社計を取得し、画面情報を反映する
				SuplAccPay allAccRec = new SuplAccPay();
				SuplierPay allDmdPrc = new SuplierPay(); 
				
				// 拠点無しの時ように全社計を取得し、画面情報を反映する
				ReadAllSecCodeAndSetScreenInformation(ref allAccRec, ref allDmdPrc, true);
				
				result = SaveDetailsProc( ref allAccRec, ref allDmdPrc );
			}
#endif 
			if ( result  == true )
			{
				if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
				{
					// データ再読み込み処理
                    AccRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._condPaymentSectionCode, this._targetDivType);
                    //AccRec_Data_Search(this._condPayeeCode, this._condSupplierCode, this.SectionCodeData, this._targetDivType);
					this._accRecIndexBuf = -2;
				}
    			// 支払金額
				else
				{
					// データ再読み込み処理
                    //MessageBox.Show("支払:" + this._targetPayeeCode.ToString() + "/仕入:" + this._targetSupplierCode.ToString() + "/拠点:" + this._condSectionCode + "/区分:" + this._targetDivType.ToString());
                    DmdRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._condPaymentSectionCode, this._targetDivType);
                    //DmdRec_Data_Search(this._condPayeeCode, this._condSupplierCode, this._condPaymentSectionCode, this._targetDivType);
					this._dmdPrcIndexBuf = -2;
				}
			}
			return result;
		}
                
		/// <summary>保存処理</summary>
		/// <param name="suplAccPay">買掛金額情報</param>
		/// <param name="suplierPay">支払金額情報</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の保存処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        // 2009.01.14 >>>
		//private bool SaveDetailsProc(ref SuplAccPay suplAccPay ,ref SuplierPay suplierPay)
        private bool SaveDetailsProc(ref SuplAccPay suplAccPay, ref SuplierPay suplierPay, ref List<ACalcPayTotal> aCalcPayTotalList, ref List<AccPayTotal> accPayTotalList)
        // 2009.01.14 <<<
        {
			bool result = false;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			string errmsg = "";

			// 買掛金額
			if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
			{
				// 必須入力項目の確認
				WriteInputDataCheck_ACC(ref suplAccPay );
				// (最終レコード検索して更新する)
                // 2009.01.14 >>>
                //status = this._suplAccPayAcs.WriteSuplAccPay(suplAccPay, out errmsg);
                status = this._suplAccPayAcs.WriteSuplAccPay(suplAccPay, aCalcPayTotalList, out errmsg);
                // 2009.01.14 <<<
            }
			// 支払金額
			else
			{
				// 必須入力項目の確認
				WriteInputDataCheck_DMD(ref suplierPay);
				// (最終レコード検索して更新する)
                // 2009.01.14 >>>
                //status = this._suplAccPayAcs.WriteSuplierPay(suplierPay, out errmsg);
                status = this._suplAccPayAcs.WriteSuplierPay(suplierPay, accPayTotalList, out errmsg);
                // 2009.01.14 <<<
            }

			//処理後の対応追加
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					result = true;
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
                    TMsgDisp.Show(this,											  // 親ウィンドウフォーム
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,	          // エラーレベル
                                  "MAKAU09130U",							      // アセンブリＩＤまたはクラスＩＤ
                                  this.Text,									  // プログラム名称
                                  "Save_Button_Click",							  // 処理名称
                                  TMsgDisp.OPE_UPDATE,							  // オペレーション
                                  "既に同一の計上日でデータが存在するため新規では作成できません。",   // 表示するメッセージ 
                                  status,										  // ステータス値
                                  this._suplAccPayAcs,					  // エラーが発生したオブジェクト
                                  MessageBoxButtons.OK,							  // 表示するボタン
                                  MessageBoxDefaultButton.Button1);			  	  // 初期表示ボタン
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
                        errmsg = "登録に失敗しました。";
                    }
					TMsgDisp.Show(this,											  // 親ウィンドウフォーム
						          emErrorLevel.ERR_LEVEL_STOP,				      // エラーレベル
						          "MAKAU09130U",							  // アセンブリＩＤまたはクラスＩＤ
						          this.Text,									  // プログラム名称
						          "Save_Button_Click",							  // 処理名称
						          TMsgDisp.OPE_UPDATE,							  // オペレーション
						          errmsg,						                  // 表示するメッセージ 
						          status,										  // ステータス値
                                  this._suplAccPayAcs,					  // エラーが発生したオブジェクト
						          MessageBoxButtons.OK,							  // 表示するボタン
						          MessageBoxDefaultButton.Button1);			  	  // 初期表示ボタン
					this.DialogResult = DialogResult.Cancel;
					break;
				}
			}

			return result;
		}

        /// <summary>全拠点計の取得及び画面情報反映処理</summary>
		/// <param name="allAccRec">買掛金額情報</param>
		/// <param name="allDmdPrc">支払金額情報</param>
		/// <param name="reflectedMode">画面情報を反映するかの有無</param>
		/// <remarks>
		/// <br>Note       : 画面入力情報の保存処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ReadAllSecCodeAndSetScreenInformation(ref SuplAccPay allAccRec, ref SuplierPay allDmdPrc, bool reflectedMode )
		{
			if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
			{
				bool selectData = false;
				this._AllaccrecTable.Clear();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
                //SearchAccPrcInfo(this._targetPayeeCode, this._targetSupplierCode, "", out this._AllaccrecTable, false, this._targetDivType);
                SearchAccPrcInfo(this._condPayeeCode, this._condSupplierCode, "", out this._AllaccrecTable, false, this._targetDivType);
                //SearchAccPrcInfo(this._targetPayeeCode, this._targetSupplierCode, "", out this._AllaccrecTable, false)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END
				foreach( SuplAccPay _accRec in this._AllaccrecTable.Values)
				{
                    if (_accRec.AddUpDate == this._editSuplAccPay.AddUpDate)
					{
						allAccRec = suplAccPay_Clone(_accRec);
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
					//画面情報を反映し更新する
					ScreenToSuplAccPay(ref allAccRec);
					getKinSetInfo_Acc(ref allAccRec);
				}
			}
			else
			{
				bool selectData = false;
				this._AlldmdprcTable.Clear();


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
                //SearchDmdRecInfo(this._targetPayeeCode, this._targetSupplierCode, null, out this._AlldmdprcTable, false, this._targetDivType);
                SearchDmdRecInfo(this._condPayeeCode, this._condSupplierCode, null, out this._AlldmdprcTable, false, this._targetDivType);
                //SearchDmdRecInfo(this._targetPayeeCode, this._targetSupplierCode, null, out this._AlldmdprcTable, false);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END
				
				foreach( SuplierPay _dmdPrc in this._AlldmdprcTable.Values)
				{
                    if (_dmdPrc.AddUpDate == this._editSuplierPay.AddUpDate)
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
					//画面情報を反映し更新する
					ScreenToSuplierPay(ref allDmdPrc);
					getKinSetInfo_Dmd(ref allDmdPrc);
				}
			}
		}

        /// <summary>必須入力項目等のチェック処理</summary>
		/// <param name="accRec">買掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 保存で必要な必須項目をセットします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void WriteInputDataCheck_ACC(ref SuplAccPay accRec)
		{
            if ((accRec.EnterpriseCode == null) || (accRec.EnterpriseCode == ""))
            {
                accRec.EnterpriseCode = this._enterpriseCode;
            }

            // 2009.01.14 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            //if (accRec.SupplierCd == 0)
            //{
            //    //accRec.SupplierCd  = this._targetSupplierCode;
            //    accRec.SupplierCd = this._condSupplierCode;
            //    accRec.SupplierNm1  = this.CustomerName_Label.Text;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    accRec.SupplierNm2= this.CustomerName2_Label.Text;
            //    accRec.SupplierSnm = this.CustomerSnm_Label.Text;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END

            if (this._targetDivType == 1)
            {
                if (accRec.SupplierCd == 0)
                {
                    accRec.SupplierCd = this._condSupplierCode;
                    accRec.SupplierNm1 = this.CustomerName_Label.Text;
                    accRec.SupplierNm2 = this.CustomerName2_Label.Text;
                    accRec.SupplierSnm = this.CustomerSnm_Label.Text;
                }
            }
            else
            {
                accRec.SupplierCd = 0;
                accRec.SupplierNm1 = "";
                accRec.SupplierNm2 = "";
                accRec.SupplierSnm = "";
            }
            // 2009.01.14 <<<

            if ((accRec.AddUpSecCode == null) || (accRec.AddUpSecCode == ""))
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
            accRec.PayeeCode = this._condPayeeCode;
            //accRec.PayeeCode = this._targetPayeeCode;
            accRec.PayeeName = this.PayeeName_Label.Text;
            accRec.PayeeName2 = this.PayeeName2_Label.Text;
            accRec.PayeeSnm = this.PayeeSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		}

        /// <summary>必須入力項目等のチェック処理</summary>
		/// <param name="dmdPrc">支払金額情報</param>
		/// <remarks>
		/// <br>Note       : 保存で必要な必須項目をセットします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void WriteInputDataCheck_DMD(ref SuplierPay dmdPrc)
		{
            if ((dmdPrc.EnterpriseCode == null) || (dmdPrc.EnterpriseCode == ""))
            {
                dmdPrc.EnterpriseCode = this._enterpriseCode;
            }

            // 2009.01.14 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            //if (dmdPrc.SupplierCd == 0)
            //{
            //    //dmdPrc.SupplierCd  = this._targetSupplierCode;
            //    dmdPrc.SupplierCd = this._condSupplierCode;
            //    dmdPrc.SupplierNm1  = this.CustomerName_Label.Text;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    dmdPrc.SupplierNm2 = this.CustomerName2_Label.Text;
            //    dmdPrc.SupplierSnm = this.CustomerSnm_Label.Text;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END

            if (this._targetDivType == 1)
            {
                if (dmdPrc.SupplierCd == 0)
                {
                    dmdPrc.SupplierCd = this._condSupplierCode;
                    dmdPrc.SupplierNm1 = this.CustomerName_Label.Text;
                    dmdPrc.SupplierNm2 = this.CustomerName2_Label.Text;
                    dmdPrc.SupplierSnm = this.CustomerSnm_Label.Text;
                }
            }
            else
            {
                dmdPrc.SupplierCd = 0;
                dmdPrc.SupplierNm1 = "";
                dmdPrc.SupplierNm2 = "";
                dmdPrc.SupplierSnm = "";
            }
            // 2009.01.14 <<<

            if ((dmdPrc.AddUpSecCode == null) || (dmdPrc.AddUpSecCode == ""))
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dmdPrc.PayeeCode = this._condPayeeCode;
            //dmdPrc.PayeeCode = this._targetPayeeCode;
            dmdPrc.PayeeName = this.PayeeName_Label.Text;
            dmdPrc.PayeeName2 = this.PayeeName2_Label.Text;
            dmdPrc.PayeeSnm = this.PayeeSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>削除処理</summary>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面情報で指定された情報の削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private bool DeleteProc()
        {
            bool result = false;

            result = DeleteDetailsProc(this._suplAccPayClone, this._suplierPayClone);

#if false
            // オプションが存在しない場合は、全社計も更新する
            if ((this.Opt_Section == false) && (result == true) && (this._autoAllUpDateMode == true))
            {
                // 全社計を取得し、画面情報を反映する
                SuplAccPay allAccRec = new SuplAccPay();
                SuplierPay allDmdPrc = new SuplierPay();

                // 拠点無しの時ように全社計を取得し、画面情報を反映する
                ReadAllSecCodeAndSetScreenInformation(ref allAccRec, ref allDmdPrc, false);

                result = DeleteDetailsProc(allAccRec, allDmdPrc);
            }
#endif
            if (result == true)
            {
                if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
                {
                    // データ再読み込み処理
                    AccRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._condPaymentSectionCode, this._targetDivType);
                    //AccRec_Data_Search(this._condPayeeCode, this._condSupplierCode, this._sectionCode, this._targetDivType);
                    this._accRecIndexBuf = -2;
                }
                // 支払金額
                else
                {
                    // データ再読み込み処理
                    DmdRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._condPaymentSectionCode, this._targetDivType);
                    //DmdRec_Data_Search(this._condPayeeCode, this._condSupplierCode, this._sectionCode, this._targetDivType);
                    this._dmdPrcIndexBuf = -2;
                }
            }
            return result;
        }

        /// <summary>削除詳細処理</summary>
		/// <param name="suplAccPay">買掛金額情報</param>
		/// <param name="suplierPay">支払金額情報</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面情報で指定された情報の削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private bool DeleteDetailsProc(SuplAccPay suplAccPay, SuplierPay suplierPay)
        {
            bool result = false;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // 買掛金額(最終レコード検索して更新する)
            if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
            {
                status = this._suplAccPayAcs.DeleteSuplAccPay(suplAccPay);
            }
            // 支払金額(最終レコード検索して更新する)
            else
            {
                status = this._suplAccPayAcs.DeleteSuplierPay(suplierPay);
            }

            //処理後の対応追加
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
                        TMsgDisp.Show(this,											  // 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP,				      // エラーレベル
                                      "MAKAU09130U",							  // アセンブリＩＤまたはクラスＩＤ
                                      this.Text,									  // プログラム名称
                                      "Delete_Button_Click",						  // 処理名称
                                      TMsgDisp.OPE_UPDATE,							  // オペレーション
                                      "登録に失敗しました。",						  // 表示するメッセージ 
                                      status,										  // ステータス値
                                      this._suplAccPayAcs,					  // エラーが発生したオブジェクト
                                      MessageBoxButtons.OK,							  // 表示するボタン
                                      MessageBoxDefaultButton.Button1);			  	  // 初期表示ボタン
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }
            }

            return result;
        }

        # endregion

        // ===================================================================================== //
		// 内部メソッド（買掛・支払情報Clone作成 & Equals）
		// ===================================================================================== //
		#region  Privete Methods AccPrcAndDmdPrcClone&Equals

		/// <summary>買掛金額のクローン作成処理</summary>
		/// <param name="targetSuplAccPay">買掛金額情報</param>
		/// <returns>買掛金額情報</returns>
		/// <remarks>
		/// <br>Note       : 渡された買掛金額情報のクローンデータを作成します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private SuplAccPay suplAccPay_Clone(SuplAccPay targetSuplAccPay)
		{
            SuplAccPay suplAccPay = new SuplAccPay();
			// データクラスのTypeオブジェクトを取得する
            Type myType2 = typeof(SuplAccPay);
			// データクラスのプロパティを取得
			PropertyInfo[] propertyInfoList2 = myType2.GetProperties(); 

			if (propertyInfoList2 != null)
			{
				foreach (PropertyInfo propertyInfo in propertyInfoList2)
				{
					PropertyInfo propertyInfo2 = propertyInfo;
                    propertyInfo.SetValue(suplAccPay, propertyInfo2.GetValue(targetSuplAccPay, null), null);
				}
			}
            return suplAccPay;
		}

		/// <summary>支払金額のクローン作成処理</summary>
		/// <param name="targetSuplierPay">支払金額情報</param>
		/// <returns>支払金額情報</returns>
		/// <remarks>
		/// <br>Note       : 渡された支払金額情報のクローンデータを作成します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private SuplierPay custdmdRec_Clone(SuplierPay targetSuplierPay)
		{
			SuplierPay suplierPay = new SuplierPay();
			
			// データクラスのTypeオブジェクトを取得する
            Type myType2 = typeof(SuplierPay);
			// データクラスのプロパティを取得
			PropertyInfo[] propertyInfoList2 = myType2.GetProperties();

			if (propertyInfoList2 != null)
			{
				foreach (PropertyInfo propertyInfo in propertyInfoList2)
				{
					PropertyInfo propertyInfo2 = propertyInfo;
                    propertyInfo.SetValue(suplierPay, propertyInfo2.GetValue(targetSuplierPay, null), null);
				}
			}
            return suplierPay;
		}

		/// <summary>買掛金額情報比較処理</summary>
		/// <param name="targetSuplAccPay">買掛金額情報A</param>
		/// <param name="compSuplAccPay">買掛金額情報B</param>
		/// <returns>チェック結果（true:同じ／false:異なる）</returns>
		/// <remarks>
		/// <br>Note       : 買掛金額情報Aと買掛金額情報Bの内容を比較します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private  bool suplAccPay_Equals(SuplAccPay targetSuplAccPay, SuplAccPay compSuplAccPay)
		{
			bool result = true;
			// データクラスのTypeオブジェクトを取得する
			Type myType2 = typeof(SuplAccPay);
			// データクラスのプロパティを取得
			PropertyInfo[] propertyInfoList2 = myType2.GetProperties();

			if (propertyInfoList2 != null)
			{
				foreach (PropertyInfo propertyInfo in propertyInfoList2)
				{
					PropertyInfo propertyInfo2 = propertyInfo;

					if ( propertyInfo.GetValue(compSuplAccPay,null ).Equals(propertyInfo2.GetValue(targetSuplAccPay,null)) == false )
					{
						result = false;
						break;
					}
				}
			}
			return result ;
		}

		/// <summary>支払金額情報比較処理</summary>
		/// <param name="targetSuplierPay">支払金額情報A</param>
		/// <param name="compSuplierPay">支払金額情報B</param>
		/// <returns>チェック結果（true:同じ／false:異なる）</returns>
		/// <remarks>
		/// <br>Note       : 支払金額情報Aと支払金額情報Bの内容を比較します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private  bool suplierPay_Equals(SuplierPay targetSuplierPay, SuplierPay compSuplierPay)
		{
			bool result = true;
			// データクラスのTypeオブジェクトを取得する
			Type myType2 = typeof(SuplierPay);
			// データクラスのプロパティを取得
			PropertyInfo[] propertyInfoList2 = myType2.GetProperties();

			if (propertyInfoList2 != null)
			{
				foreach (PropertyInfo propertyInfo in propertyInfoList2)
				{
					PropertyInfo propertyInfo2 = propertyInfo;

					if ( propertyInfo.GetValue(compSuplierPay, null).Equals(propertyInfo2.GetValue(targetSuplierPay, null)) == false )
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
		// コントロールイベント
		// ===================================================================================== //
		#region Control Events
		# endregion

		// ===================================================================================== //
		// 画面イベント
		// ===================================================================================== //
		# region Control Form Events

        /// <summary>Form.Load イベント(MAKAU09130UB)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09130UB_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
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

            // 2009.01.14 Add >>>
            // 金種情報マスタ取得
            this.GetMoneyKind();

            // 支払設定マスタ取得
            this.GetPaymentSet();

            // 支払入力グリッドの初期設定
            this.PaymentKindGridInitialSetting();

            this.uGrid_DemandInfo.DataSource = this._totalDisplayTable;
            // 2009.01.14 Add <<<
        }

		/// <summary>VisibleChanged イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09130UB_VisibleChanged(object sender, System.EventArgs e)
		{
			if (this.Visible == false)
			{
				return;
			}

			// ターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._targetTableName == SuplAccPayAcs.TBL_CUSTACCREC_TITLE)
			{
				// ターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
				if ((this._accRecIndexBuf  == this._accRecDataIndex) &&
					//(this._customerCodeBuf == this._targetSupplierCode) &&
                    (this._customerCodeBuf == this._condSupplierCode) &&
					(this._targetTableBuf  == this._targetTableName))
				{
					return;
				}
			}
			if (this._targetTableName == SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE)
			{
				// ターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
				if ((this._dmdPrcIndexBuf  == this._dmdPrcDataIndex) &&
					//(this._customerCodeBuf == this._targetSupplierCode)	&&
                    (this._customerCodeBuf == this._condSupplierCode) &&
					(this._targetTableBuf  == this._targetTableName))
				{
					return;
				}
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE) ) {
                // <買掛情報固有項目> を表示
                //this.SuplAccPay_panel.Visible = true;
                // <支払情報固有項目> を非表示
                this.SuplierPay_panel.Visible = false;

                //this.SuplAccPay_panel.Location = this._expansionPanelLocation;

                // 2009.01.14 Add >>>
                this.LMBl_tNedit.Location = this._balance3EditLocation;
                this.LMBl_Label.Location = this._balance3LabelLocation;
                this.ultraLabel42.Visible = false;
                this.ultraLabel20.Visible = false;
                this.ultraLabel15.Visible = false;
                this.ultraLabel14.Visible = false;
                this.Bf3TmBl_Label.Visible = false;
                this.Bf3TmBl_tNedit.Visible = false;
                this.Bf2TmBl_Label.Visible = false;
                this.Bf2TmBl_tNedit.Visible = false;
                this.BlTotalTitle_Label.Visible = false;
                this.BlTotal_Label.Visible = false;
                // 2009.01.14 Add <<<
            }
            else {
                // <買掛情報固有項目> を非表示
                //this.SuplAccPay_panel.Visible = false;
                // <支払情報固有項目> を表示
                this.SuplierPay_panel.Visible = true;

                this.SuplierPay_panel.Location = this._expansionPanelLocation;

                // 2009.01.14 Add >>>
                this.LMBl_tNedit.Location = this._balance1EditLocation;
                this.LMBl_Label.Location = this._balance1LabelLocation;

                this.ultraLabel42.Visible = true;
                this.ultraLabel20.Visible = true;
                this.ultraLabel15.Visible = true;
                this.ultraLabel14.Visible = true;
                this.Bf3TmBl_Label.Visible = true;
                this.Bf3TmBl_tNedit.Visible = true;
                this.Bf2TmBl_Label.Visible = true;
                this.Bf2TmBl_tNedit.Visible = true;
                this.BlTotalTitle_Label.Visible = true;
                this.BlTotal_Label.Visible = true;
                // 2009.01.14 Add <<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.14 Add >>>
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
            // 2009.01.14 Add <<<

			ScreenClear(true);

			// 画面初期化
			Initial_Timer.Enabled = true;
		}

		/// <summary>Closing イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォーム終了時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09130UB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._accRecIndexBuf  = -2;
			this._dmdPrcIndexBuf  = -2;
			this._targetTableBuf  = "";
			this._customerCodeBuf = -2;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
			//（フォームの「×」をクリックされた場合の対応です。）
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

        /// <summary>Timer.Tick イベント イベント(Initial_Timer)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定された間隔の時間が経過したときに発生します。
		///	                 この処理は、システムが提供するスレッド プール
		///	                 スレッドで実行されます。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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

        /// <summary>Control.ChangeFocus イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォーカス移動時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null) return;
			if (e.NextCtrl == null) return;

            // 名称取得 ============================================ //
            switch (e.Key)
            {
                //case Keys.Return:
                //case Keys.Tab:
                //case Keys.Down:
                //    {
                //        switch (e.PrevCtrl.Name)
                //        {
                //            case "AddUpADate_tDateEdit":
                //                {
                //                    e.NextCtrl = this.ultraButton1;
                //                    break;
                //                }
                //            case "PaymentSchedule_tDateEdit":
                //                {
                //                    if (this.Undo_Button.Visible)
                //                    {
                //                        e.NextCtrl = this.Undo_Button;
                //                    }
                //                    else
                //                    {
                //                        e.NextCtrl = this.Delete_Button;
                //                    }
                //                    break;
                //                }
                //        }
                //    }
                //    break;
                default: break;
            }
            # region    ********** Unnecessary(不要) **********
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
            //    // リターンキーの時
            //    if ((e.Key == Keys.Return) ||
            //        (e.Key == Keys.Tab))
            //    {
            //        Control _nextCtrl = e.NextCtrl;
            //        e.NextCtrl = null;
			
            //        if (this.VarCstList_Grid.ActiveCell != null)
            //        {
            //            // アクティブセルがエディットモードになっていない場合はエディットモードにする
            //            // アクティブセルがエディットモードになっていない場合はエディットモードにする
            //            if ((this.VarCstList_Grid.ActiveCell.IsInEditMode == false) && (this.VarCstList_Grid.ActiveCell.Activation != Infragistics.Win.UltraWinGrid.Activation.NoEdit)
            //                && (this.VarCstList_Grid.ActiveCell.Activation != Infragistics.Win.UltraWinGrid.Activation.Disabled))
            //            {
            //                this.VarCstList_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            //                return;
            //            }
            //            // 最終セルの時
            //            if ((this.VarCstList_Grid.ActiveCell.Row.Index == this.VarCstList_Grid.Rows.Count - 1) &&
            //                (this.VarCstList_Grid.ActiveCell.Column.Index == this.VarCstList_Grid.DisplayLayout.Bands[VARCST_TABLE].Columns.Count -1 ))
            //            {	
            //                e.NextCtrl =_nextCtrl ;
            //            }
            //            else
            //            {
            //                // 次のセルにフォーカス遷移
            //                this.VarCstList_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
            //            }
            //        }
            //    }
            //}
            # endregion ********** Unnecessary(不要) **********

            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            // 2009.01.14 Add >>>
            switch (e.PrevCtrl.Name)
            {
                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                case "AddUpADate_tDateEdit":
                    {
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else
                        {
                            int index;
                            if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
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
                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                case "grdPaymentKind":

                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            if (grdPaymentKind.ActiveCell == null)
                            {
                                return;
                            }
                            int rowIndex = grdPaymentKind.ActiveCell.Row.Index;
                            // Shiftキーが押されてない場合
                            if (!e.ShiftKey)
                            {
                                if (rowIndex == grdPaymentKind.Rows.Count - 1)
                                {
                                    e.NextCtrl = this.FeeNrml_tNedit;
                                    grdPaymentKind.ActiveCell = null;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    grdPaymentKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                    grdPaymentKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                            }
                            else
                            {
                                if (rowIndex == 0)
                                {
                                    e.NextCtrl = this.StockSlipCount_tNedit;
                                    grdPaymentKind.ActiveCell = null;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    grdPaymentKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                    grdPaymentKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

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
                case "grdPaymentKind":

                    // フォーカスを入れることができない場合の処理
                    if (( grdPaymentKind.Rows.Count == 0 ) ||
                        ( this.grdPaymentKind.Rows[0].Activation == Infragistics.Win.UltraWinGrid.Activation.Disabled ))
                    {
                        if (( ( !e.ShiftKey ) && ( ( e.Key == Keys.Return ) || ( e.Key == Keys.Tab ) ) ) ||
                              ( e.Key == Keys.Right ) || ( e.Key == Keys.Left ))
                        {
                            e.NextCtrl = this.FeeNrml_tNedit;
                            break;
                        }
                        else if (( e.ShiftKey ) && ( ( e.Key == Keys.Return ) || ( e.Key == Keys.Tab ) ))
                        {
                            e.NextCtrl = this.StockSlipCount_tNedit;
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
                            this.grdPaymentKind.DisplayLayout.Rows[grdPaymentKind.Rows.Count - 1].Cells[ctPayment].Activate();
                            this.grdPaymentKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            break;
                        case Keys.Tab:
                        case Keys.Return:
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = null;
                                this.grdPaymentKind.DisplayLayout.Rows[grdPaymentKind.Rows.Count - 1].Cells[ctPayment].Activate();
                                this.grdPaymentKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                e.NextCtrl = null;
                                this.grdPaymentKind.DisplayLayout.Rows[0].Cells[ctPayment].Activate();
                                this.grdPaymentKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            }
                            break;

                        default:
                            e.NextCtrl = null;
                            this.grdPaymentKind.DisplayLayout.Rows[0].Cells[ctPayment].Activate();
                            this.grdPaymentKind.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            break;
                    }
                    break;
                default:
                    break;
            }
            // 2009.01.14 Add <<<
        }

        # endregion

		// ===================================================================================== //
		// ボタンイベント
		// ===================================================================================== //
		#region Control Button Events

        /// <summary>Control.Click イベント(Cancel_Button)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンコントロールがクリックされたときに
		///	                 発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			Cancel_Button.Focus();
		
			bool chgMode = false;
			// 画面起動が終了していたら
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if ((this._formBeingStarted == true) &&
				((this.Mode_Label.Text != DELETE_MODE) &&
				(this.Mode_Label.Text != REFER_MODE)))
			{
				if ( this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
				{
					SuplAccPay compareSuplAccPay = new SuplAccPay();
					compareSuplAccPay = this._suplAccPayClone;  // clone
                    if (suplAccPay_Equals(this._editSuplAccPay, compareSuplAccPay) == false)
                    {
                        chgMode = true;
                    }
				}
				else
				{
					SuplierPay compareSuplierPay = new SuplierPay();
					compareSuplierPay = this._suplierPayClone;  // clone
                    if (suplierPay_Equals(this._editSuplierPay, compareSuplierPay) == false)
                    {
                        chgMode = true;
                    }
				}
				
				// 保存確認
				// 最初に取得した画面情報と比較
				if (chgMode == true)	
				{
					// 画面情報が変更されていた場合は、保存確認メッセージを表示する
					DialogResult res = TMsgDisp.Show(this,                                  // 親ウィンドウフォーム
						                             emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // エラーレベル
						                             "SFUUKK01540U.DLL",		            // アセンブリＩＤまたはクラスＩＤ
						                             null, 					                // 表示するメッセージ
						                             0, 					                // ステータス値
						                             MessageBoxButtons.YesNoCancel);	    // 表示するボタン
					switch(res)
					{
						case DialogResult.Yes:
						{
							// 全画面に反映する処理
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
                            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            if (_modeFlg)
                            {
                                AddUpADate_tDateEdit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END

							return;
						}
					}
				}
			}

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// 最小化判定フラグの初期化
			this._accRecIndexBuf = -2;
			this._dmdPrcIndexBuf = -2;

			ScreenClear(true);
			
			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

            this._invokerForm.Focus();      // 2009.01.14 Add
		}

		/// <summary>Control.Click イベント(Ok_Button)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// 画面起動が完了していたら
			if (this._formBeingStarted == true )
			{
				// 画面情報をテーブルに格納する
				if (SaveProc() == false)
				{
					return;
				}
			}

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 最小化判定フラグの初期化
			this._accRecIndexBuf = -2;
			this._dmdPrcIndexBuf = -2;

			ScreenClear(true);

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
            this._invokerForm.Focus();      // 2009.01.14 Add
		}

        /// <summary>Control.Click イベント(Delete_Button)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // データ削除
            // 新規ならば無視
            if (this._logicalDeleteMode == -1) return;

            // 本当に削除してよいかのチェック画面を表示します。
            DialogResult result = TMsgDisp.Show(this,
                                                emErrorLevel.ERR_LEVEL_QUESTION,
                                                "MAKAU09130U",
                                                " 削除してもよろしいですか？",
                                                0,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }

            // 削除処理
            DeleteProc();

            this.DialogResult = DialogResult.OK;

            ScreenClear(true);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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

		/// <summary>Control.Click イベント(Undo_Button)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 取消ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Undo_Button_Click(object sender, System.EventArgs e)
		{
			// 起動時に戻す
			ScreenClear(false);

			if ( this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
			{
				// 画面表示		
				DetailsAccRecToScreen(this._suplAccPayClone);
			}
			else
			{
				// 画面表示		
				DetailsDmdPrcToScreen(this._suplierPayClone);
			}
			// 画面初期化
			Initial_Timer.Enabled = true;
		}

        // 2009.01.14 Del >>>
#if false
        /// <summary>Control.Click イベント(ultraButton1)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 前回残高取得ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ultraButton1_Click(object sender, System.EventArgs e)
		{
			// 前回残高取得処理
			// 現在、表示している計上日付よりも前３回分の残高を取得し、設定する
			// 新規モード
			if (_logicalDeleteMode == -1 )
			{
				// 入力されている日付を基準とする
				if ( this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
				{
					// 正しい日付かチェック
                    if (TDateTime.IsAvailableDate(this.AddUpADate_tDateEdit.GetDateTime()) == false)
                    {
						// 入力されている日付が正しくない
						return;
					}
				}
				else
				{
					// 正しい日付かチェック
                    if (TDateTime.IsAvailableDate(this.AddUpADate_tDateEdit.GetDateTime()) == false)
                        {
						// 入力されている日付が正しくない
						return;
					}
				}
			}

            DateTime AddUpADate_Edit = this.AddUpADate_tDateEdit.GetDateTime();
			
			//---------------------------------
			// 買掛
			//---------------------------------
			// 既存データをチェックする
			if ( this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
			{
				// データが１件の場合、前回データが存在しないので取得はできないため、終了
                if ((this._logicalDeleteMode != -1) && (this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTACCREC_TITLE].Rows.Count == 1)) return;
			
				// ソートして検索開始日付より前の情報を取得する
                string selectCmd = REC_ADDUPDATE_TITLE + " < " + this.AddUpADate_tDateEdit.GetLongDate().ToString();
                DataRow[] dataRows = this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTACCREC_TITLE].Select(selectCmd, viewGridSortDefault);

                // 最新のレコードを取得
                SuplAccPay suplAccPay = new SuplAccPay();
                if (dataRows.Length > 0)
                {
                    DataRowToSuplAccPay(dataRows[0], suplAccPay);
                }

                this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(suplAccPay.StckTtl2TmBfBlAccPay, true);
                this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(suplAccPay.LastTimeAccPay, true);
                this.TtlLMBl_Label.Text    = Claim_panelDataFormat(suplAccPay.StckTtlAccPayBalance, true);

                this.TtlBf3TmBl_Label.Tag = suplAccPay.StckTtl2TmBfBlAccPay;
                this.TtlBf2TmBl_Label.Tag = suplAccPay.LastTimeAccPay;
                this.TtlLMBl_Label.Tag    = suplAccPay.StckTtlAccPayBalance;

                this.LMBl_tNedit.SetValue(suplAccPay.StckTtlAccPayBalance);
                this.Bf2TmBl_tNedit.SetValue(suplAccPay.LastTimeAccPay);
                this.Bf3TmBl_tNedit.SetValue(suplAccPay.StckTtl2TmBfBlAccPay);
                
                //取得した前回残と当月情報を元に_KINSETを実行
				upDateClaim_PanelTextData();
			}

            //---------------------------------
			// 支払
			//---------------------------------
			else
			{
				// データが１件の場合、前回データが存在しないので取得はできないため、終了
                if ((this._logicalDeleteMode != -1) && (this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE].Rows.Count == 1)) return;

				// ソートして検索開始日付より前の情報を取得する
                string selectCmd = REC_ADDUPDATE_TITLE + " < " + this.AddUpADate_tDateEdit.GetLongDate().ToString();
                DataRow[] dataRows = this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTDMDPRC_TITLE].Select(selectCmd, viewGridSortDefault);

                // 最新のレコードを取得
                SuplierPay suplierPay = new SuplierPay();
                if (dataRows.Length > 0)
                {
                    DataRowToSuplierPay(dataRows[0], suplierPay);
                }

                this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(suplierPay.StockTtl2TmBfBlPay, true);
                this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(suplierPay.LastTimePayment, true);
                this.TtlLMBl_Label.Text    = Claim_panelDataFormat(suplierPay.StockTotalPayBalance, true);

                this.TtlBf3TmBl_Label.Tag = suplierPay.StockTtl2TmBfBlPay;
                this.TtlBf2TmBl_Label.Tag = suplierPay.LastTimePayment;
                this.TtlLMBl_Label.Tag    = suplierPay.StockTotalPayBalance;

                this.LMBl_tNedit.SetValue(suplierPay.StockTotalPayBalance);
                this.Bf2TmBl_tNedit.SetValue(suplierPay.LastTimePayment);
                this.Bf3TmBl_tNedit.SetValue(suplierPay.StockTtl2TmBfBlPay);
                
                //取得した前回残と当月情報を元に_KINSETを実行
				upDateClaim_PanelTextData();
			}
		}
#endif
        // 2009.01.14 Del <<<

        # endregion

		// ===================================================================================== //
		// 項目イベント
		// ===================================================================================== //
		#region Control Component Events

        /// <summary>Enter イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブになった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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

        /// <summary>ValueChanged イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 入力内容に変更が発生したときに実行されます。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Control_ValueChanged(object sender, System.EventArgs e)
        {
            if (this._formBeingStarted == false) return;
            this._changeFlg = true;
        }

        /// <summary>Leave イベント(仕入)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Sales_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // 仕入合計金額ラベルの反映
            update_SalesTotalLabel();

            // 2009.01.14 Add >>>
            // 相殺後売上外税対象額ラベルの反映
            if (sender == this.TtlItdedStcOutTax_tNedit)
            {
                this.update_ItdedOffsetOutTaxLabel();
            }
            // 相殺後非課税対象額ラベルの反映
            else if (sender == this.TtlItdedStcTaxFree_tNedit)
            {
                this.update_ItdedOffsetTaxFreeLabel();
            }
            // 相殺後売上合計ラベルの反映
            this.update_OfsThisTimeSalesTotalLabel();
            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 2009.01.14 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (ctrlTNedit.Name == "TtlItdedStcOutTax_tNedit")
            //{
            //    update_ItdedOutTaxTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "TtlStockOuterTax_tNedit")
            //{
            //    update_OutTaxTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "TtlItdedStcInTax_tNedit")
            //{
            //    update_ItdedInTaxTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "TtlStockInnerTax_tNedit")
            //{
            //    update_InTaxTotalLabel();
            //}
            //else if (ctrlTNedit.Name == "TtlItdedStcTaxFree_tNedit")
            //{
            //    update_ItdedTaxFreeTotalLabel();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 鑑への反映
            upDateClaim_PanelTextData();
        }

        /// <summary>Leave イベント(返品)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void Ret_tNedit_Leave ( object sender, System.EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = ( TNedit ) sender;

            if ( ctrlTNedit == null ) return;

            // 返品合計金額ラベルの反映
            update_RetTotalLabel();

            // 2009.01.14 Add >>>
            // 相殺後売上外税対象額ラベルの反映
            if (sender == this.TtlItdedRetOutTax_tNedit)
            {
                this.update_ItdedOffsetOutTaxLabel();
            }
            // 相殺後非課税対象額ラベルの反映
            else if (sender == TtlItdedRetTaxFree_tNedit)
            {
                this.update_ItdedOffsetTaxFreeLabel();
            }
            // 相殺後売上合計ラベルの反映
            this.update_OfsThisTimeSalesTotalLabel();
            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 2009.01.14 Add <<<

            // 鑑への反映
            upDateClaim_PanelTextData();
        }
        /// <summary>Leave イベント(値引)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void Dis_tNedit_Leave ( object sender, System.EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = ( TNedit ) sender;

            if ( ctrlTNedit == null ) return;

            // 値引合計金額ラベルの反映
            update_DisTotalLabel();

            // 2009.01.14 Add >>>
            // 相殺後売上外税対象額ラベルの反映
            if (sender == this.TtlItdedDisOutTax_tNedit)
            {
                this.update_ItdedOffsetOutTaxLabel();
            }
            // 相殺後非課税対象額ラベルの反映
            else if (sender == this.TtlItdedDisTaxFree_tNedit)
            {
                this.update_ItdedOffsetTaxFreeLabel();
            }
            // 相殺後売上合計ラベルの反映
            this.update_OfsThisTimeSalesTotalLabel();
            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 2009.01.14 Add <<<

            // 鑑への反映
            upDateClaim_PanelTextData();
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>Leave イベント(受取)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void Recv_tNedit_Leave( object sender, EventArgs e )
        {
            if ( this._changeFlg == false )
                return;

            TNedit ctrlTNedit = (TNedit)sender;

            if ( ctrlTNedit == null )
                return;

            // 受取合計金額ラベルの反映
            update_RecvTotalLabel();

            // 鑑への反映
            upDateClaim_PanelTextData();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>Leave イベント(そのほか)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Other_tNedit_Leave ( object sender, System.EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = ( TNedit ) sender;

            if ( ctrlTNedit == null ) return;

            // 鑑への反映
            upDateClaim_PanelTextData();
        }
        /// <summary>Leave イベント(日付)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void DateEdit_Leave ( object sender, EventArgs e )
        {
            // 鏡への反映
            upDateClaim_PanelTextData();
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>Leave イベント(支払)</summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void Payment_tNedit_Leave(object sender, System.EventArgs e)
        //{
        //    if (this._changeFlg == false) return;

        //    TNedit ctrlTNedit = (TNedit)sender;

        //    if (ctrlTNedit == null) return;

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// 支払合計金額ラベルの反映
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

        //    // 鑑への反映
        //    upDateClaim_PanelTextData();
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>Leave イベント(通常支払)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void Normal_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // 支払合計金額ラベルの反映
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

            // 鑑への反映
            upDateClaim_PanelTextData();
        }

        ///// <summary>Leave イベント(預り金)</summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void Deposit_tNedit_Leave(object sender, System.EventArgs e)
        //{
        //    if (this._changeFlg == false) return;

        //    TNedit ctrlTNedit = (TNedit)sender;

        //    if (ctrlTNedit == null) return;

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// 支払合計金額ラベルの反映
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

        //    // 鑑への反映
        //    upDateClaim_PanelTextData();
        //}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>Leave イベント(在庫調整)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void BalanceAdjust_tNedit_Leave ( object sender, System.EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = ( TNedit ) sender;

            if ( ctrlTNedit == null ) return;

            // 鑑への反映
            upDateClaim_PanelTextData();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>Leave イベント(AcpOdrTtlLMBlDmd_tNedit)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AcpOdrTtlLMBlDmd_tNedit_Leave(object sender, System.EventArgs e)
		{
			if ( this._changeFlg == false ) return;

            // 2009.01.14 >>>
            //// 前回残高
            //double acpOdrTtlLMBl  = this.LMBl_tNedit.GetValue();
            //TtlLMBl_Label.Text    = Claim_panelDataFormat((Int64)acpOdrTtlLMBl, true);
            //// 2回以前残高
            //double acpOdrTtlLMBl2 = this.Bf2TmBl_tNedit.GetValue();
            //TtlBf2TmBl_Label.Text = Claim_panelDataFormat((Int64)acpOdrTtlLMBl2, true);
            //// 3回以前残高
            //double acpOdrTtlLMBl3 = this.Bf3TmBl_tNedit.GetValue();
            //TtlBf3TmBl_Label.Text = Claim_panelDataFormat((Int64)acpOdrTtlLMBl3, true);

            // 前回残高
            if (sender == LMBl_tNedit)
            {
                double acpOdrTtlLMBl = this.LMBl_tNedit.GetValue();
                this._totalDisplayTable.Rows[0][AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF] = (Int64)acpOdrTtlLMBl;
            }

            // 2回以前残高
            if (sender == Bf2TmBl_tNedit)
            {
                double acpOdrTtlLMBl2 = this.Bf2TmBl_tNedit.GetValue();
                this._totalDisplayTable.Rows[0][AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF] = (Int64)acpOdrTtlLMBl2;
            }

            // 3回以前残高
            if (sender == Bf3TmBl_tNedit)
            {
                double acpOdrTtlLMBl3 = this.Bf3TmBl_tNedit.GetValue();
                this._totalDisplayTable.Rows[0][AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF] = (Int64)acpOdrTtlLMBl3;
            }

            // 残高合計の更新
            this.update_BlTotalLabel();
            // 2009.01.14 <<<
            
			upDateClaim_PanelTextData();
		}

        private bool  _leave = false;
        /// <summary>Leave イベント(AddUpADate_tDateEdit)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AddUpADate_tDateEdit_Leave(object sender, System.EventArgs e)
		{
            if (this._leave) return;
            try
            {
                this._leave = true;
                if (this.AddUpADate_tDateEdit.LongDate == 0) return;
                if (this._changeFlg == false) return;// 2009.01.14 Add
                // 買掛
                //if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
                //{
                //    this.AddUpADate_tDateEdit.SetLongDate(this.AddUpADate_tDateEdit.LongDate + 1);
                //}

                if (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(this.AddUpADate_tDateEdit.LongDate)) == false)
                {
                    TMsgDisp.Show(this,											// 親ウィンドウフォーム
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,			// エラーレベル
                                  "",											// アセンブリＩＤまたはクラスＩＤ
                                  "正しい日付を設定して下さい。",				// 表示するメッセージ 
                                  0,											// ステータス値
                                  MessageBoxButtons.OK);						// 表示するボタン

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
                this._leave = false;
            }
        }

        /// <summary>KeyPress イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キー入力された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void tNedit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Gridの入力方式に合わせる処理 Gridの桁数にはマイナス符号を含まない桁数で処理している為、
            // Editは桁数はマイナス符号を含む桁数とし、入力された桁数がマイナスがなければ1桁減らした桁数とする処理をする
            TNedit chk_tNedit = (TNedit)sender;

            int selstart = 0;
            int sellength = chk_tNedit.TextLength;
            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (chk_tNedit.TextLength > 0)
            {
                _strResult = chk_tNedit.Text.Substring(0, selstart) + chk_tNedit.Text.Substring(selstart + sellength, chk_tNedit.Text.Length - (selstart + sellength));
            }
            else
            {
                _strResult = chk_tNedit.Text;
            }

            // キーが押された結果の文字列を生成する。
            _strResult = chk_tNedit.Text.Substring(0, selstart)
                       + e.KeyChar
                       + chk_tNedit.Text.Substring(selstart + sellength, chk_tNedit.Text.Length - (selstart + sellength));

            // 桁数チェック！
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
        // 内部メソッド(合計計算)
        // ===================================================================================== //
        # region Private Methods_Total_Calculate

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>外税対象額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 外税対象額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_ItdedOutTaxTotalLabel()
        //{
        //    double ItdedOutTaxTotal = this.TtlItdedStcOutTax_tNedit.GetValue() -       // 仕入外税対象額
        //                              this.ItdedPaymOutTax_tNedit.GetValue();         // 支払外税対象額
        //    this.ItdedOutTaxTotal_Label.Text = Claim_panelDataFormat((Int64)ItdedOutTaxTotal, false);
        //}

        ///// <summary>外税額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 外税額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_OutTaxTotalLabel()
        //{
        //    double OutTaxTotal = this.TtlStockOuterTax_tNedit.GetValue() -       // 仕入外税額
        //                         this.PaymentOutTax_tNedit.GetValue();      // 支払外税額
        //    this.OutTaxTotal_Label.Text = Claim_panelDataFormat((Int64)OutTaxTotal, false);
        //}

        ///// <summary>内税対象額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 内税対象額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_ItdedInTaxTotalLabel()
        //{
        //    double ItdedInTaxTotal = this.TtlItdedStcInTax_tNedit.GetValue() -       // 仕入内税対象額
        //                             this.ItdedPaymInTax_tNedit.GetValue();         // 支払内税対象額
        //    this.ItdedInTaxTotal_Label.Text = Claim_panelDataFormat((Int64)ItdedInTaxTotal, false);
        //}

        ///// <summary>内税額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 内税額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_InTaxTotalLabel()
        //{
        //    double InTaxTotal = this.TtlStockInnerTax_tNedit.GetValue() -       // 仕入内税額
        //                        this.PaymentInTax_tNedit.GetValue();      // 支払内税額
        //    this.InTaxTotal_Label.Text = Claim_panelDataFormat((Int64)InTaxTotal, false);
        //}

        ///// <summary>非課税対象額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 非課税対象額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_ItdedTaxFreeTotalLabel()
        //{
        //    double ItdedTaxFreeTotal = this.TtlItdedStcTaxFree_tNedit.GetValue() -       // 仕入非課税対象額
        //                               this.ItdedPaymTaxFree_tNedit.GetValue();         // 支払非課税対象額
        //    this.ItdedTaxFreeTotal_Label.Text = Claim_panelDataFormat((Int64)ItdedTaxFreeTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>支払金額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 支払金額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_DepoPrcTotalLabel()
        //{
        //    double DepoPrcTotal = this.DepoNrml_tNedit.GetValue() +     // 通常支払金額
        //                          this.Depo_tNedit.GetValue();          // 預り金支払金額
        //    this.DepoPrcTotal_Label.Text = Claim_panelDataFormat((Int64)DepoPrcTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>手数料額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 手数料額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_FeeTotalLabel()
        //{
        //    double FeeTotal = this.FeeNrml_tNedit.GetValue() +          // 通常手数料額
        //                      this.FeeDepo_tNedit.GetValue();           // 預り金手数料額
        //    this.FeeTotal_Label.Text = Claim_panelDataFormat((Int64)FeeTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>値引額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 値引額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_DisTotalLabel()
        //{
        //    double DisTotal = this.DisNrml_tNedit.GetValue() +          // 通常値引額
        //                      this.DisDepo_tNedit.GetValue();           // 預り金値引額
        //    this.DisTotal_Label.Text = Claim_panelDataFormat((Int64)DisTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>リベート額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : リベート額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_RbtTotalLabel()
        //{
        //    double RbtTotal = this.RbtNrml_tNedit.GetValue() +          // 通常リベート額
        //                      this.RbtDepo_tNedit.GetValue();           // 預り金リベート額
        //    this.RbtTotal_Label.Text = Claim_panelDataFormat((Int64)RbtTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>仕入額合計計算</summary>
        /// <remarks>
        /// <br>Note       : 仕入額の合計計算を行う</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void update_SalesTotalLabel()
        {
            // 2009.01.14 >>>
            //double salesTotal = this.TtlItdedStcOutTax_tNedit.GetValue() +       // 仕入外税対象額
            //                    this.TtlStockOuterTax_tNedit.GetValue()      +       // 仕入外税額
            //                    this.TtlItdedStcInTax_tNedit.GetValue()  +       // 仕入内税対象額
            //                    this.TtlStockInnerTax_tNedit.GetValue()       +       // 仕入内税額
            //                    this.TtlItdedStcTaxFree_tNedit.GetValue();       // 仕入非課税対象額

            double salesTotal = this.TtlItdedStcOutTax_tNedit.GetValue() +      // 仕入外税対象額
                                this.TtlItdedStcInTax_tNedit.GetValue() +       // 仕入内税対象額
                                this.TtlItdedStcTaxFree_tNedit.GetValue();      // 仕入非課税対象額
            // 2009.01.14 <<<
            SalesTotal_Label.Text = Claim_panelDataFormat((Int64)salesTotal, false);
        }
        /// <summary>返品額合計計算</summary>
        /// <remarks>
        /// <br>Note       : 返品額の合計計算を行う</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void update_RetTotalLabel ()
        {
            // 2009.01.14 >>>
            //double retTotal   = this.TtlItdedRetOutTax_tNedit.GetValue() +       // 返品外税対象額
            //                    this.TtlRetOuterTax_tNedit.GetValue() +          // 返品外税額
            //                    this.TtlItdedRetInTax_tNedit.GetValue() +        // 返品内税対象額
            //                    this.TtlRetInnerTax_tNedit.GetValue() +          // 返品内税額
            //                    this.TtlItdedRetTaxFree_tNedit.GetValue();       // 返品非課税対象額

            double retTotal = this.TtlItdedRetOutTax_tNedit.GetValue() +       // 返品外税対象額
                              this.TtlItdedRetInTax_tNedit.GetValue() +        // 返品内税対象額
                              this.TtlItdedRetTaxFree_tNedit.GetValue();       // 返品非課税対象額
            // 2009.01.14 <<<
            RetTotal_Label.Text = Claim_panelDataFormat((Int64)retTotal, false);
        }
        /// <summary>値引額合計計算</summary>
        /// <remarks>
        /// <br>Note       : 値引額の合計計算を行う</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void update_DisTotalLabel ()
        {
            // 2009.01.14 >>>
            //double disTotal   = this.TtlItdedDisOutTax_tNedit.GetValue() +       // 値引外税対象額
            //                    this.TtlDisOuterTax_tNedit.GetValue() +          // 値引外税額
            //                    this.TtlItdedDisInTax_tNedit.GetValue() +        // 値引内税対象額
            //                    this.TtlDisInnerTax_tNedit.GetValue() +          // 値引内税額
            //                    this.TtlItdedDisTaxFree_tNedit.GetValue();       // 値引非課税対象額

            double disTotal = this.TtlItdedDisOutTax_tNedit.GetValue() +       // 値引外税対象額
                              this.TtlItdedDisInTax_tNedit.GetValue() +        // 値引内税対象額
                              this.TtlItdedDisTaxFree_tNedit.GetValue();       // 値引非課税対象額
            // 2009.01.14 <<<
            DisTotal_Label.Text = Claim_panelDataFormat((Int64)disTotal, false);
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>受取額合計計算</summary>
        /// <remarks>
        /// <br>Note       : 受取額の合計計算を行う</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void update_RecvTotalLabel()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
            double recvTotal = //this.ThisRecvOutTax_tNedit.GetValue() +       // 受取外税対象額
                                //this.ThisRecvOuterTax_tNedit.GetValue() +          // 受取外税額
                                this.TtlItdedDisInTax_tNedit.GetValue();// +        // 受取内税対象額
                                //this.ThisRecvInnerTax_tNedit.GetValue() +          // 受取内税額
                                //this.ThisRecvTaxFree_tNedit.GetValue();       // 受取非課税対象額
            //RecvTotal_Label.Text = Claim_panelDataFormat( (Int64)recvTotal, false );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>支払額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 支払額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_PaymTotalLabel()
        //{
        //    double PaymTotal = this.ItdedPaymOutTax_tNedit.GetValue() +     // 支払外税対象額
        //                       this.PaymentOutTax_tNedit.GetValue()   +     // 支払外税額
        //                       this.ItdedPaymInTax_tNedit.GetValue()  +     // 支払内税対象額
        //                       this.PaymentInTax_tNedit.GetValue()    +     // 支払内税額
        //                       this.ItdedPaymTaxFree_tNedit.GetValue();     // 支払非課税対象額
        //    PaymTotal_Label.Text = Claim_panelDataFormat((Int64)PaymTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>通常支払合計計算</summary>
        /// <remarks>
        /// <br>Note       : 通常支払の合計計算を行う</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void update_NormalTotalLabel()
        {
            // 2009.01.14 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////double NormalTotal = this.DepoNrml_tNedit.GetValue() +     // 通常支払金額
            ////                     this.FeeNrml_tNedit.GetValue()  +     // 通常手数料額
            ////                     this.DisNrml_tNedit.GetValue()  +     // 通常値引額
            ////                     this.RbtNrml_tNedit.GetValue();       // 通常リベート額
            //double NormalTotal = this.DepoNrml_tNedit.GetValue() +     // 通常支払金額
            //                     this.FeeNrml_tNedit.GetValue() +     // 通常手数料額
            //                     this.DisNrml_tNedit.GetValue() ;     // 通常値引額
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //NrmlTotal_Label.Text = Claim_panelDataFormat((Int64)NormalTotal, false);

            // 内訳の合計
            object value = this._payeeDataTable.Compute(string.Format("SUM({0})", ctPayment), string.Empty);
            Int64 total = ( value is DBNull ) ? 0 : (Int64)value;

            total += (Int64)this.FeeNrml_tNedit.GetValue() + (Int64)this.DisNrml_tNedit.GetValue();

            NrmlTotal_Label.Text = Claim_panelDataFormat(total, false);
            // 2009.01.14 <<<
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>預り金合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 預り金の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_DepoTotalLabel()
        //{
        //    double DepositTotal = this.Depo_tNedit.GetValue()    +     // 預り金支払金額
        //                          this.FeeDepo_tNedit.GetValue() +     // 預り金手数料額
        //                          this.DisDepo_tNedit.GetValue() +     // 預り金値引額
        //                          this.RbtDepo_tNedit.GetValue();      // 預り金リベート額
        //    DepoTotal_Label.Text = Claim_panelDataFormat((Int64)DepositTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // 2009.01.14 Add >>>
        /// <summary>相殺後外税対象額計算</summary>
        /// <remarks>
        /// <br>Note       : 相殺後外税対象額の計算を行う</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void update_ItdedOffsetOutTaxLabel()
        {
            long total = (Int64)this.TtlItdedStcOutTax_tNedit.GetValue() -      // 仕入外税対象額
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // 返品外税対象額
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();       // 値引外税対象額
            ItdedOffsetOutTax_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>相殺後非課税対象額計算</summary>
        /// <remarks>
        /// <br>Note       : 相殺後非課税対象額の計算を行う</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void update_ItdedOffsetTaxFreeLabel()
        {
            long total = (Int64)this.TtlItdedStcTaxFree_tNedit.GetValue() -     // 仕入非課税対象額
                         (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue() -     // 返品非課税対象額
                         (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();      // 値引非課税対象額
            ItdedOffsetTaxFree_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>相殺後今回仕入金額計算</summary>
        /// <remarks>
        /// <br>Note       : 相殺後非課税対象額の計算を行う</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void update_OfsThisTimeSalesTotalLabel()
        {
            long total = (Int64)this.TtlItdedStcOutTax_tNedit.GetValue() -      // 仕入外税対象額
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // 返品外税対象額
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue() +      // 値引外税対象額
                         (Int64)this.TtlItdedStcInTax_tNedit.GetValue() -       // 仕入内税対象額
                         (Int64)this.TtlItdedRetInTax_tNedit.GetValue() -       // 返品内税対象額
                         (Int64)this.TtlItdedDisInTax_tNedit.GetValue() +       // 値引内税対象額
                         (Int64)this.TtlItdedStcTaxFree_tNedit.GetValue() -     // 仕入非課税対象額
                         (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue() -     // 返品非課税対象額
                         (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();      // 値引非課税対象額
            OfsThisTimeSales_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>
        /// 残高合計計算
        /// </summary>
        /// <remarks>
        /// <br>Note       : 残高合計の計算を行う</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void update_BlTotalLabel()
        {
            long total = (Int64)this.Bf3TmBl_tNedit.GetValue() +    // 前々々回残高
                         (Int64)this.Bf2TmBl_tNedit.GetValue() +    // 前々回残高
                         (Int64)this.LMBl_tNedit.GetValue();        // 前回残高
            this.BlTotal_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>
        /// 税込金額計算
        /// </summary>
        /// <remarks>
        /// <br>Note       : 税込合計の計算を行う</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void update_OfsThisTimeSalesTaxIncLabel()
        {
            long total = (Int64)this.TtlItdedStcOutTax_tNedit.GetValue() -      // 仕入外税対象額
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // 返品外税対象額
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue() +      // 値引外税対象額
                         (Int64)this.TtlItdedStcInTax_tNedit.GetValue() -       // 仕入内税対象額
                         (Int64)this.TtlItdedRetInTax_tNedit.GetValue() -       // 返品内税対象額
                         (Int64)this.TtlItdedDisInTax_tNedit.GetValue() +       // 値引内税対象額
                         (Int64)this.TtlItdedStcTaxFree_tNedit.GetValue() -     // 仕入非課税対象額
                         (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue() -     // 返品非課税対象額
                         (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue() +     // 値引非課税対象額
                         (Int64)this.OfsThisStockTax_tNedit.GetValue();         // 消費税合計

            this.OfsThisTimeSalesTaxInc_Label.Text = Claim_panelDataFormat(total, false);
        }
        // 2009.01.14 Add <<<
        # endregion

        /// <summary>DataRow仕入先買掛金額マスタオブジェクト展開処理</summary>
        /// <param name="dr">仕入先買掛金額情報DataTableのDataRow</param>
        /// <param name="suplAccPay">仕入先買掛金額マスタクラス</param>
        /// <param name="aCalcPayTotalList">買掛支払集計データリスト</param>
        /// <remarks>
        /// <br>Note       : 対象のDataRowから仕入先買掛金額マスタオブジェクトへ格納する</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        // 2009.01.14 >>>
        //private void DataRowToSuplAccPay(DataRow dr, SuplAccPay suplAccPay)
        private void DataRowToSuplAccPay(DataRow dr, out  SuplAccPay suplAccPay, out List<ACalcPayTotal> aCalcPayTotalList)
        // 2009.01.14 <<<
        {
            // 2009.01.14 Add >>>
            suplAccPay = new SuplAccPay();
            aCalcPayTotalList = new List<ACalcPayTotal>();
            // 2009.01.14 Add <<<

            suplAccPay.EnterpriseCode       = this._enterpriseCode;
            suplAccPay.AddUpSecCode         = dr[SuplAccPayAcs.COL_ADDUPSECCODE_TITLE].ToString();
            suplAccPay.SupplierCd         = Int32.Parse(dr[SuplAccPayAcs.COL_SUPPLIERCODE_TITLE].ToString());
            suplAccPay.SupplierNm1 = dr[SuplAccPayAcs.COL_SUPPLIERNAME_TITLE].ToString();
            suplAccPay.SupplierNm2 = dr[SuplAccPayAcs.COL_SUPPLIERNAME2_TITLE].ToString();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplAccPay.SupplierSnm = dr[SuplAccPayAcs.COL_SUPPLIERSNM_TITLE].ToString();
            suplAccPay.PayeeCode            = Int32.Parse(dr[SuplAccPayAcs.COL_PAYEECODE_TITLE].ToString());
            suplAccPay.PayeeName            = dr[SuplAccPayAcs.COL_PAYEENAME_TITLE].ToString();
            suplAccPay.PayeeName2           = dr[SuplAccPayAcs.COL_PAYEENAME2_TITLE].ToString();
            suplAccPay.PayeeSnm             = dr[SuplAccPayAcs.COL_PAYEESNM_TITLE].ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.AddUpDate            = Int32.Parse(dr[SuplAccPayAcs.COL_ADDUPDATE_TITLE].ToString());
            //suplAccPay.AddUpYearMonth       = Int32.Parse(dr[SuplAccPayAcs.COL_ADDUPYEARMONTH_TITLE].ToString());
            suplAccPay.AddUpDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_ADDUPDATE_TITLE].ToString()));
            suplAccPay.AddUpYearMonth = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_ADDUPYEARMONTH_TITLE].ToString()));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplAccPay.LastTimeAccPay       = Int64.Parse(dr[SuplAccPayAcs.COL_LASTTIMEACCPAY_TITLE].ToString());
            suplAccPay.ThisTimePayNrml      = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEPAYNRML_TITLE].ToString());
            suplAccPay.ThisTimeFeePayNrml   = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEFEEPAYNRML_TITLE].ToString());
            suplAccPay.ThisTimeDisPayNrml   = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEDISPAYNRML_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ThisTimeRbtDmdNrml   = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMERBTDMDNRML_TITLE].ToString());
            //suplAccPay.ThisTimeDmdDepo      = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEDMDDEPO_TITLE].ToString());
            //suplAccPay.ThisTimeFeeDmdDepo   = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEFEEDMDDEPO_TITLE].ToString());
            //suplAccPay.ThisTimeDisDmdDepo   = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEDISDMDDEPO_TITLE].ToString());
            //suplAccPay.ThisTimeRbtDmdDepo   = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMERBTDMDDEPO_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplAccPay.ThisTimeTtlBlcAcPay    = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMETTLBLCACPAY_TITLE].ToString());
            suplAccPay.ThisTimeStockPrice        = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMESTOCKPRICE_TITLE].ToString());
            suplAccPay.ThisStcPrcTax         = Int64.Parse(dr[SuplAccPayAcs.COL_THISSTCPRCTAX_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.TtlIncDtbtTaxExc     = Int64.Parse(dr[SuplAccPayAcs.COL_TTLINCDTBTTAXEXC_TITLE].ToString());
            //suplAccPay.TtlIncDtbtTax        = Int64.Parse(dr[SuplAccPayAcs.COL_TTLINCDTBTTAX_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ThisNetStckPrice     = Int64.Parse(dr[SuplAccPayAcs.COL_THISNETSTCKPRICE_TITLE].ToString());
            //suplAccPay.ThisNetStcPrcTax      = Int64.Parse(dr[SuplAccPayAcs.COL_THISNETSTCPRCTAX_TITLE].ToString());
            suplAccPay.OfsThisTimeStock = Int64.Parse( dr[SuplAccPayAcs.COL_OFSTHISTIMESTOCK_TITLE].ToString() );
            suplAccPay.OfsThisStockTax = Int64.Parse( dr[SuplAccPayAcs.COL_OFSTHISSTOCKTAX_TITLE].ToString() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplAccPay.ItdedOffsetOutTax    = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDOFFSETOUTTAX_TITLE].ToString());
            suplAccPay.ItdedOffsetInTax     = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDOFFSETINTAX_TITLE].ToString());
            suplAccPay.ItdedOffsetTaxFree   = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDOFFSETTAXFREE_TITLE].ToString());
            suplAccPay.OffsetOutTax         = Int64.Parse(dr[SuplAccPayAcs.COL_OFFSETOUTTAX_TITLE].ToString());
            suplAccPay.OffsetInTax          = Int64.Parse(dr[SuplAccPayAcs.COL_OFFSETINTAX_TITLE].ToString());
            suplAccPay.TtlItdedStcOutTax     = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDSTCOUTTAX_TITLE].ToString());
            suplAccPay.TtlItdedStcInTax      = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDSTCINTAX_TITLE].ToString());
            suplAccPay.TtlItdedStcTaxFree    = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDSTCTAXFREE_TITLE].ToString());
            suplAccPay.TtlStockOuterTax          = Int64.Parse(dr[SuplAccPayAcs.COL_TTLSTOCKOUTERTAX_TITLE].ToString());
            suplAccPay.TtlStockInnerTax           = Int64.Parse(dr[SuplAccPayAcs.COL_TTLSTOCKINNERTAX_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplAccPay.TtlItdedRetOutTax    = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDRETOUTTAX_TITLE].ToString());
            suplAccPay.TtlItdedRetInTax     = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDRETINTAX_TITLE].ToString());
            suplAccPay.TtlItdedRetTaxFree   = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDRETTAXFREE_TITLE].ToString());
            suplAccPay.TtlRetOuterTax       = Int64.Parse(dr[SuplAccPayAcs.COL_TTLRETOUTERTAX_TITLE].ToString());
            suplAccPay.TtlRetInnerTax       = Int64.Parse(dr[SuplAccPayAcs.COL_TTLRETINNERTAX_TITLE].ToString());
            suplAccPay.TtlItdedDisOutTax    = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDDISOUTTAX_TITLE].ToString());
            suplAccPay.TtlItdedDisInTax     = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDDISINTAX_TITLE].ToString());
            suplAccPay.TtlItdedDisTaxFree   = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDDISTAXFREE_TITLE].ToString());
            suplAccPay.TtlDisOuterTax       = Int64.Parse(dr[SuplAccPayAcs.COL_TTLDISOUTERTAX_TITLE].ToString());
            suplAccPay.TtlDisInnerTax       = Int64.Parse(dr[SuplAccPayAcs.COL_TTLDISINNERTAX_TITLE].ToString());
            suplAccPay.BalanceAdjust        = Int64.Parse(dr[SuplAccPayAcs.COL_BALANCEADJUST_TITLE].ToString());

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            suplAccPay.TaxAdjust = Int64.Parse(dr[SuplAccPayAcs.COL_TAXADJUST_TITLE].ToString());
            suplAccPay.StockSlipCount = Int32.Parse(dr[SuplAccPayAcs.COL_STOCKSLIPCOUNT].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            //suplAccPay.NonStmntAppearance   = Int64.Parse(dr[SuplAccPayAcs.COL_NONSTMNTAPPEARANCE_TITLE].ToString());
            //suplAccPay.NonStmntIsdone       = Int64.Parse(dr[SuplAccPayAcs.COL_NONSTMNTISDONE_TITLE].ToString());
            //suplAccPay.StmntAppearance      = Int64.Parse(dr[SuplAccPayAcs.COL_STMNTAPPEARANCE_TITLE].ToString());
            //suplAccPay.StmntIsdone          = Int64.Parse(dr[SuplAccPayAcs.COL_STMNTISDONE_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ThisRecvInnerTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVINNERTAX_TITLE].ToString() );
            //suplAccPay.ThisRecvInTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVINTAX_TITLE].ToString() );
            //suplAccPay.ThisRecvOffset = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVOFFSET_TITLE].ToString() );
            //suplAccPay.ThisRecvOffsetTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVOFFSETTAX_TITLE].ToString() );
            //suplAccPay.ThisRecvOuterTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVOUTERTAX_TITLE].ToString() );
            //suplAccPay.ThisRecvOutTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVOUTTAX_TITLE].ToString() );
            //suplAccPay.ThisRecvTaxFree = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVTAXFREE_TITLE].ToString() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ThisCashStockPrice    = Int64.Parse(dr[SuplAccPayAcs.COL_THISCASHSTOCKPRICE].ToString());
            //suplAccPay.ThisCashStockTax      = Int64.Parse(dr[SuplAccPayAcs.COL_THISCASHSTOCKTAX].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.ItdedPaymOutTax      = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDPAYMOUTTAX_TITLE].ToString());
            //suplAccPay.ItdedPaymInTax       = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDPAYMINTAX_TITLE].ToString());
            //suplAccPay.ItdedPaymTaxFree     = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDPAYMTAXFREE_TITLE].ToString());
            //suplAccPay.PaymentOutTax        = Int64.Parse(dr[SuplAccPayAcs.COL_PAYMENTOUTTAX_TITLE].ToString());
            //suplAccPay.PaymentInTax         = Int64.Parse(dr[SuplAccPayAcs.COL_PAYMENTINTAX_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplAccPay.SuppCTaxLayCd     = Int32.Parse(dr[SuplAccPayAcs.COL_SUPPCTAXLAYCD_TITLE].ToString());
            suplAccPay.SupplierConsTaxRate          = Double.Parse(dr[SuplAccPayAcs.COL_SUPPLIERCONSTAXRATE_TITLE].ToString());
            suplAccPay.FractionProcCd       = Int32.Parse(dr[SuplAccPayAcs.COL_FRACTIONPROCCD_TITLE].ToString());
            suplAccPay.StckTtlAccPayBalance = Int64.Parse(dr[SuplAccPayAcs.COL_STCKTTLACCPAYBALANCE_TITLE].ToString());// -Int64.Parse(dr[SuplAccPayAcs.COL_BALANCEADJUST_TITLE].ToString()) - Int64.Parse(dr[SuplAccPayAcs.COL_TAXADJUST_TITLE].ToString());
            suplAccPay.StckTtl2TmBfBlAccPay = Int64.Parse(dr[SuplAccPayAcs.COL_STCKTTL2TMBFBLACCPAY_TITLE].ToString());
            suplAccPay.StckTtl3TmBfBlAccPay = Int64.Parse(dr[SuplAccPayAcs.COL_STCKTTL3TMBFBLACCPAY_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPay.MonthAddUpExpDate    = Int32.Parse(dr[SuplAccPayAcs.COL_MONTHADDUPEXPDATE_TITLE].ToString());
            suplAccPay.MonthAddUpExpDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_MONTHADDUPEXPDATE_TITLE].ToString()));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplAccPay.FileHeaderGuid       = (Guid)dr[SuplAccPayAcs.COL_GUID_TITLE];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplAccPay.CreateDateTime = (DateTime)dr[SuplAccPayAcs.COL_CREATEDATETIME];
            suplAccPay.UpdateDateTime = (DateTime)dr[SuplAccPayAcs.COL_UPDATEDATETIME];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.14 Add >>>
            suplAccPay.StMonCAddUpUpdDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_STMONCADDUPUPDDATE_TITLE].ToString()));
            suplAccPay.LaMonCAddUpUpdDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_LAMONCADDUPUPDDATE_TITLE].ToString()));
            aCalcPayTotalList = (List<ACalcPayTotal>)dr[SuplAccPayAcs.COL_PAYTOTAL];
            // 2009.01.14 Add <<<
        }

        /// <summary>DataRow仕入先支払金額マスタオブジェクト展開処理</summary>
        /// <param name="dr">仕入先支払金額情報DataTableのDataRow</param>
        /// <param name="suplierPay">仕入先支払金額マスタクラス</param>
        /// <param name="accPayTotalList">精算支払集計データリスト</param>
        /// <remarks>
        /// <br>Note       : 対象のDataRowから仕入先支払金額マスタオブジェクトへ格納する</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        // 2009.01.14 >>>
        //private void DataRowToSuplierPay(DataRow dr, SuplierPay suplierPay)
        private void DataRowToSuplierPay(DataRow dr, out  SuplierPay suplierPay, out List<AccPayTotal> accPayTotalList)
        // 2009.01.14 <<<
        {
            // 2009.01.14 Add >>>
            suplierPay = new SuplierPay();
            accPayTotalList = new List<AccPayTotal>();
            // 2009.01.14 Add <<<

            suplierPay.EnterpriseCode      = this._enterpriseCode;
            suplierPay.AddUpSecCode        = dr[SuplAccPayAcs.COL_ADDUPSECCODE_TITLE].ToString();
            suplierPay.SupplierCd        = Int32.Parse(dr[SuplAccPayAcs.COL_SUPPLIERCODE_TITLE].ToString());
            suplierPay.SupplierNm1 = dr[SuplAccPayAcs.COL_SUPPLIERNAME_TITLE].ToString();
            suplierPay.SupplierNm2 = dr[SuplAccPayAcs.COL_SUPPLIERNAME2_TITLE].ToString();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplierPay.SupplierSnm = dr[SuplAccPayAcs.COL_SUPPLIERSNM_TITLE].ToString();

            // 2009.01.14 >>>
            //suplierPay.ResultsSectCd = dr[SuplAccPayAcs.COL_RESULTSECCODE_TITLE].ToString();
            suplierPay.ResultsSectCd = dr[SuplAccPayAcs.COL_RESULTSECCODE_TITLE].ToString().Trim();
            // 2009.01.14 <<<

            suplierPay.PayeeCode           = Int32.Parse(dr[SuplAccPayAcs.COL_PAYEECODE_TITLE].ToString());
            suplierPay.PayeeName           = dr[SuplAccPayAcs.COL_PAYEENAME_TITLE].ToString();
            suplierPay.PayeeName2          = dr[SuplAccPayAcs.COL_PAYEENAME2_TITLE].ToString();
            suplierPay.PayeeSnm            = dr[SuplAccPayAcs.COL_PAYEESNM_TITLE].ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.AddUpDate           = Int32.Parse(dr[SuplAccPayAcs.COL_ADDUPDATE_TITLE].ToString());
            //suplierPay.AddUpYearMonth      = Int32.Parse(dr[SuplAccPayAcs.COL_ADDUPYEARMONTH_TITLE].ToString());
            suplierPay.AddUpDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_ADDUPDATE_TITLE].ToString()));
            suplierPay.AddUpYearMonth = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_ADDUPYEARMONTH_TITLE].ToString()));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplierPay.LastTimePayment      = Int64.Parse(dr[SuplAccPayAcs.COL_LASTTIMEDEMAND_TITLE].ToString());
            suplierPay.ThisTimePayNrml     = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEPAYNRML_TITLE].ToString());
            suplierPay.ThisTimeFeePayNrml  = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEFEEPAYNRML_TITLE].ToString());
            suplierPay.ThisTimeDisPayNrml  = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEDISPAYNRML_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.ThisTimeRbtDmdNrml  = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMERBTDMDNRML_TITLE].ToString());
            //suplierPay.ThisTimeDmdDepo     = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEDMDDEPO_TITLE].ToString());
            //suplierPay.ThisTimeFeeDmdDepo  = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEFEEDMDDEPO_TITLE].ToString());
            //suplierPay.ThisTimeDisDmdDepo  = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMEDISDMDDEPO_TITLE].ToString());
            //suplierPay.ThisTimeRbtDmdDepo  = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMERBTDMDDEPO_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplierPay.ThisTimeTtlBlcPay   = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMETTLBLCDMD_TITLE].ToString());
            suplierPay.ThisTimeStockPrice       = Int64.Parse(dr[SuplAccPayAcs.COL_THISTIMESTOCKPRICE_TITLE].ToString());
            suplierPay.ThisStcPrcTax        = Int64.Parse(dr[SuplAccPayAcs.COL_THISSTCPRCTAX_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.TtlIncDtbtTaxExc    = Int64.Parse(dr[SuplAccPayAcs.COL_TTLINCDTBTTAXEXC_TITLE].ToString());
            //suplierPay.TtlIncDtbtTax       = Int64.Parse(dr[SuplAccPayAcs.COL_TTLINCDTBTTAX_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.ThisNetStckPrice    = Int64.Parse(dr[SuplAccPayAcs.COL_THISNETSTCKPRICE_TITLE].ToString());
            //suplierPay.ThisNetStcPrcTax     = Int64.Parse(dr[SuplAccPayAcs.COL_THISNETSTCPRCTAX_TITLE].ToString());
            suplierPay.OfsThisTimeStock = Int64.Parse( dr[SuplAccPayAcs.COL_OFSTHISTIMESTOCK_TITLE].ToString() );
            suplierPay.OfsThisStockTax = Int64.Parse( dr[SuplAccPayAcs.COL_OFSTHISSTOCKTAX_TITLE].ToString() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplierPay.ItdedOffsetOutTax   = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDOFFSETOUTTAX_TITLE].ToString());
            suplierPay.ItdedOffsetInTax    = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDOFFSETINTAX_TITLE].ToString());
            suplierPay.ItdedOffsetTaxFree  = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDOFFSETTAXFREE_TITLE].ToString());
            suplierPay.OffsetOutTax        = Int64.Parse(dr[SuplAccPayAcs.COL_OFFSETOUTTAX_TITLE].ToString());
            suplierPay.OffsetInTax         = Int64.Parse(dr[SuplAccPayAcs.COL_OFFSETINTAX_TITLE].ToString());
            suplierPay.TtlItdedStcOutTax    = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDSTCOUTTAX_TITLE].ToString());
            suplierPay.TtlItdedStcInTax     = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDSTCINTAX_TITLE].ToString());
            suplierPay.TtlItdedStcTaxFree   = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDSTCTAXFREE_TITLE].ToString());
            suplierPay.TtlStockOuterTax         = Int64.Parse(dr[SuplAccPayAcs.COL_TTLSTOCKOUTERTAX_TITLE].ToString());
            suplierPay.TtlStockInnerTax          = Int64.Parse(dr[SuplAccPayAcs.COL_TTLSTOCKINNERTAX_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplierPay.TtlItdedRetOutTax   = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDRETOUTTAX_TITLE].ToString());
            suplierPay.TtlItdedRetInTax    = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDRETINTAX_TITLE].ToString());
            suplierPay.TtlItdedRetTaxFree  = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDRETTAXFREE_TITLE].ToString());
            suplierPay.TtlRetOuterTax      = Int64.Parse(dr[SuplAccPayAcs.COL_TTLRETOUTERTAX_TITLE].ToString());
            suplierPay.TtlRetInnerTax      = Int64.Parse(dr[SuplAccPayAcs.COL_TTLRETINNERTAX_TITLE].ToString());
            suplierPay.TtlItdedDisOutTax   = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDDISOUTTAX_TITLE].ToString());
            suplierPay.TtlItdedDisInTax    = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDDISINTAX_TITLE].ToString());
            suplierPay.TtlItdedDisTaxFree  = Int64.Parse(dr[SuplAccPayAcs.COL_TTLITDEDDISTAXFREE_TITLE].ToString());
            suplierPay.TtlDisOuterTax      = Int64.Parse(dr[SuplAccPayAcs.COL_TTLDISOUTERTAX_TITLE].ToString());
            suplierPay.TtlDisInnerTax      = Int64.Parse(dr[SuplAccPayAcs.COL_TTLDISINNERTAX_TITLE].ToString());
            suplierPay.BalanceAdjust       = Int64.Parse(dr[SuplAccPayAcs.COL_BALANCEADJUST_TITLE].ToString());

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            suplierPay.TaxAdjust = Int64.Parse(dr[SuplAccPayAcs.COL_TAXADJUST_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            suplierPay.StockSlipCount     = Int32.Parse(dr[SuplAccPayAcs.COL_STOCKSLIPCOUNT].ToString());
            suplierPay.PaymentSchedule = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_PAYMENTSCHEDULE].ToString()));
            suplierPay.PaymentCond         = Int32.Parse(dr[SuplAccPayAcs.COL_PAYMENTCOND].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.ThisRecvInnerTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVINNERTAX_TITLE].ToString() );
            //suplierPay.ThisRecvInTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVINTAX_TITLE].ToString() );
            //suplierPay.ThisRecvOffset = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVOFFSET_TITLE].ToString() );
            //suplierPay.ThisRecvOffsetTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVOFFSETTAX_TITLE].ToString() );
            //suplierPay.ThisRecvOuterTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVOUTERTAX_TITLE].ToString() );
            //suplierPay.ThisRecvOutTax = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVOUTTAX_TITLE].ToString() );
            //suplierPay.ThisRecvTaxFree = Int64.Parse( dr[SuplAccPayAcs.COL_THISRECVTAXFREE_TITLE].ToString() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.ItdedPaymOutTax     = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDPAYMOUTTAX_TITLE].ToString());
            //suplierPay.ItdedPaymInTax      = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDPAYMINTAX_TITLE].ToString());
            //suplierPay.ItdedPaymTaxFree    = Int64.Parse(dr[SuplAccPayAcs.COL_ITDEDPAYMTAXFREE_TITLE].ToString());
            //suplierPay.PaymentOutTax       = Int64.Parse(dr[SuplAccPayAcs.COL_PAYMENTOUTTAX_TITLE].ToString());
            //suplierPay.PaymentInTax        = Int64.Parse(dr[SuplAccPayAcs.COL_PAYMENTINTAX_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplierPay.SuppCTaxLayCd    = Int32.Parse(dr[SuplAccPayAcs.COL_SUPPCTAXLAYCD_TITLE].ToString());
            suplierPay.SupplierConsTaxRate         = Double.Parse(dr[SuplAccPayAcs.COL_SUPPLIERCONSTAXRATE_TITLE].ToString());
            suplierPay.FractionProcCd      = Int32.Parse(dr[SuplAccPayAcs.COL_FRACTIONPROCCD_TITLE].ToString());
            suplierPay.StockTotalPayBalance = Int64.Parse(dr[SuplAccPayAcs.COL_AFCALDEMANDPRICE_TITLE].ToString());
            suplierPay.StockTtl2TmBfBlPay = Int64.Parse(dr[SuplAccPayAcs.COL_ACPODRTTL2TMBFBLDMD_TITLE].ToString());
            suplierPay.StockTtl3TmBfBlPay = Int64.Parse(dr[SuplAccPayAcs.COL_ACPODRTTL3TMBFBLDMD_TITLE].ToString());
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.CAddUpUpdExecDate   = Int32.Parse(dr[SuplAccPayAcs.COL_CADDUPUPDEXECDATE_TITLE].ToString());
            suplierPay.CAddUpUpdExecDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_CADDUPUPDEXECDATE_TITLE].ToString()));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPay.DmdProcNum          = Int32.Parse(dr[SuplAccPayAcs.COL_DMDPROCNUM_TITLE].ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            suplierPay.FileHeaderGuid      = (Guid)dr[SuplAccPayAcs.COL_GUID_TITLE];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplierPay.CreateDateTime = (DateTime)dr[SuplAccPayAcs.COL_CREATEDATETIME];
            suplierPay.UpdateDateTime = (DateTime)dr[SuplAccPayAcs.COL_UPDATEDATETIME];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.14 Add >>>
            suplierPay.StartCAddUpUpdDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_STARTCADDUPUPDDATE_TITLE].ToString()));
            suplierPay.LastCAddUpUpdDate = TDateTime.LongDateToDateTime(Int32.Parse(dr[SuplAccPayAcs.COL_LASTCADDUPUPDDATE_TITLE].ToString()));
            accPayTotalList = (List<AccPayTotal>)dr[SuplAccPayAcs.COL_PAYTOTAL];
            // 2009.01.14 Add <<<
        }


        private void TaxAdjust_tNedit_Leave(object sender, EventArgs e)
        {
            if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // 鑑への反映
            upDateClaim_PanelTextData();
        }

        private void AddUpADate_tDateEdit_ValueChanged(object sender, EventArgs e)
        {
            //this.AddUpADate_tDateEdit.Focus();
            this._changeFlg = true;     // 2009.01.14 Add
        }

        // 2009.01.14 Add >>>

        #region 支払内訳グリッド表示設定処理
        /// <summary>
        /// 支払内訳グリッド表示設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 支払内訳グリッドの表示設定を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void PaymentKindGridInitialSetting()
        {
            try
            {
                // データテーブルの列定義
                _payeeDataTable = new DataTable();

                // Addを行う順番が、列の表示順位となります。
                _payeeDataTable.Columns.Add(ctMoneyKindDiv, typeof(Int32));       // 金種区分
                _payeeDataTable.Columns.Add(ctMoneyKindCode, typeof(Int32));      // 金種コード
                _payeeDataTable.Columns.Add(ctMoneyKindName, typeof(string));     // 支払内訳
                _payeeDataTable.Columns.Add(ctPayment, typeof(Int64));            // 支払金額


                _payeeDataTable.PrimaryKey = new DataColumn[] { _payeeDataTable.Columns[ctMoneyKindCode] };

                this._payeeDataView = this._payeeDataTable.DefaultView;

                this.grdPaymentKind.DataSource = this._payeeDataView;
                this._payeeDataView.Sort = ctMoneyKindCode;

                string moneyFormat = "#,##0;-#,##0;''";

                // --- 入金内訳バンド --- //
                Infragistics.Win.UltraWinGrid.ColumnsCollection pareColumns = this.grdPaymentKind.DisplayLayout.Bands[0].Columns;

                // 金種コード
                pareColumns[ctMoneyKindDiv].Header.Caption = "金種コード";
                pareColumns[ctMoneyKindDiv].Hidden = true;

                // 金種コード
                pareColumns[ctMoneyKindCode].Header.Caption = "金種コード";
                pareColumns[ctMoneyKindCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                //pareColumns[ctMoneyKindCode].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                pareColumns[ctMoneyKindCode].Hidden = true;

                // 金種名称
                pareColumns[ctMoneyKindName].Header.Caption = "支払内訳";
                pareColumns[ctMoneyKindName].Header.Appearance.FontData.SizeInPoints = 10;
                pareColumns[ctMoneyKindName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                pareColumns[ctMoneyKindName].CellAppearance.ForeColorDisabled = Color.Black;
                pareColumns[ctMoneyKindName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                pareColumns[ctMoneyKindName].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                //pareColumns[ctMoneyKindName].CellAppearance.FontData.SizeInPoints = 10;
                pareColumns[ctMoneyKindName].Width = 105;

                // 支払金額
                pareColumns[ctPayment].Header.Caption = "支払金額";
                pareColumns[ctPayment].Header.Appearance.FontData.SizeInPoints = 10;
                pareColumns[ctPayment].CellAppearance.ForeColorDisabled = Color.Black;
                pareColumns[ctPayment].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                pareColumns[ctPayment].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                pareColumns[ctPayment].CellAppearance.FontData.SizeInPoints = 10;
                pareColumns[ctPayment].Width = 105;
                pareColumns[ctPayment].Format = moneyFormat;
            }
            finally
            {
                this._payeeDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.PaymenttChanged);
            }
        }
        #endregion


        #region 支払内訳データColumnChangedイベント
        /// <summary>
        /// 入金内訳テーブル ColumnChangeイベント
        /// </summary>
        /// <returns></returns>
        private void PaymenttChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == ctPayment)
            {
                // 入金合計ラベルへ反映
                this.update_NormalTotalLabel();
                // 鑑への反映
                upDateClaim_PanelTextData();
            }
        }

        #endregion

        #region 金種情報マスタ処理
        /// <summary>
        /// 金種情報マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 金種情報マスタを取得します。</br>
        /// <br>Programmer	: 21024 佐々木 健</br>
        /// <br>Date		: 2009.01.14</br>
        /// </remarks>
        private void GetMoneyKind()
        {
            int status;
            ArrayList retList = new ArrayList();

            status = this._moneyKindAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                this._dicMoneyKind = new Dictionary<int, MoneyKind>();

                foreach (MoneyKind moneyKind in retList)
                {
                    // 金額設定区分が「0:入金」を使用
                    if (( moneyKind.LogicalDeleteCode == 0 ) && ( moneyKind.PriceStCode == 0 ))
                    {
                        this._dicMoneyKind.Add(moneyKind.MoneyKindCode, moneyKind);
                    }
                }

                return;
            }

            this._dicMoneyKind = new Dictionary<int, MoneyKind>();
        }
        #endregion

        #region 支払設定マスタ処理
        /// <summary>
        /// 支払設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払設定マスタを取得します。</br>
        /// <br>Programmer	: 21024 佐々木 健</br>
        /// <br>Date		: 2009.01.14</br>
        /// </remarks>
        private void GetPaymentSet()
        {
            int status;
            PaymentSet paymentSet = new PaymentSet();

            status = this._paymentSetAcs.Read(out paymentSet, this._enterpriseCode, 0);
            if (status == 0)
            {
                this._dicPaymentSetKind = new Dictionary<int, string>();

                if (( paymentSet.PayStMoneyKindCd1 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd1) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd1, this._dicMoneyKind[paymentSet.PayStMoneyKindCd1].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd2 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd2) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd2, this._dicMoneyKind[paymentSet.PayStMoneyKindCd2].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd3 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd3) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd3, this._dicMoneyKind[paymentSet.PayStMoneyKindCd3].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd4 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd4) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd4, this._dicMoneyKind[paymentSet.PayStMoneyKindCd4].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd5 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd5) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd5, this._dicMoneyKind[paymentSet.PayStMoneyKindCd5].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd6 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd6) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd6, this._dicMoneyKind[paymentSet.PayStMoneyKindCd6].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd7 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd7) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd7, this._dicMoneyKind[paymentSet.PayStMoneyKindCd7].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd8 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd8) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd8, this._dicMoneyKind[paymentSet.PayStMoneyKindCd8].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd9 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd9) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd9, this._dicMoneyKind[paymentSet.PayStMoneyKindCd9].MoneyKindName.Trim());
                }
                if (( paymentSet.PayStMoneyKindCd10 != 0 ) &&
                    ( this._dicMoneyKind.ContainsKey(paymentSet.PayStMoneyKindCd10) ))
                {
                    this._dicPaymentSetKind.Add(paymentSet.PayStMoneyKindCd10, this._dicMoneyKind[paymentSet.PayStMoneyKindCd10].MoneyKindName.Trim());
                }

                return;
            }

            this._dicPaymentSetKind = new Dictionary<int, string>();
        }
        #endregion

        #region 残高情報表示グリッドの初期設定
        /// <summary>
        /// 残高情報表示グリッドの初期セッティング
        /// </summary>
        /// <remarks>
        /// <br>Note       : 残高情報表示グリッドの表示設定を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void SettingPaymentInfoGrid()
        {
            string moneyFormat = "#,##0;-#,##0";
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_DemandInfo.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.Header.Fixed = false;
                //入力許可設定
                //column.AutoEdit = false;
            }

            int visiblePosition = 1;

            // 売掛表示
            if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
            {
                // 前回残高
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Header.Caption = REC_TOTAL1_BEF_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Width = 200;

                // 今回仕入
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Header.Caption = REC_THISTIMESALES_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Width = 200;

                // 消費税
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Header.Caption = REC_CONSTAX_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Width = 200;

                // 今回支払
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Header.Caption = REC_THISTIMEPAYM_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Width = 200;

                // 売掛残高
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Header.Caption = REC_ACCRECBLNCE_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Width = 200;

            }
            else
            {

                // 前々回残高
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF].Header.Caption = REC_TOTAL3_BEF_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL3_BEF].Width = 200;

                // 前々回残高
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF].Header.Caption = REC_TOTAL2_BEF_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL2_BEF].Width = 200;

                // 前回残高
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Header.Caption = REC_TOTAL1_BEF_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_TOTAL1_BEF].Width = 200;

                // 今回仕入
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Header.Caption = REC_THISTIMESALES_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISTIMESTOCK].Width = 200;

                // 消費税
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Header.Caption = REC_CONSTAX_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_OFSTHISSTOCKTAX].Width = 200;

                // 今回支払
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Header.Caption = REC_THISTIMEPAYM_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_THISTIMEPAYM].Width = 200;

                // 買掛残高
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Hidden = false;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Header.VisiblePosition = visiblePosition++;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Format = moneyFormat;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Header.Caption = REC_DMDPRCBLNCE_TITLE;
                Columns[AccPayBalanceDispayTable.ct_Col_ACCRECBLNCE].Width = 200;
            }

            // 固定列区切り線設定
            this.uGrid_DemandInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_DemandInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_DemandInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }
        #endregion

        #region 支払内訳テーブルクリア
        /// <summary>
        /// 支払内訳テーブルクリア
        /// </summary>
        private void ClearPaymentKindDataTable()
        {
            try
            {
                this._payeeDataTable.ColumnChanged -= new DataColumnChangeEventHandler(this.PaymenttChanged);

                this._payeeDataTable.Rows.Clear();

                DataRow dataRow;

                foreach (int key in this._dicPaymentSetKind.Keys)
                {
                    dataRow = this._payeeDataTable.NewRow();

                    dataRow[ctMoneyKindDiv] = (int)this._dicMoneyKind[key].MoneyKindDiv;
                    dataRow[ctMoneyKindCode] = key;
                    dataRow[ctMoneyKindName] = (string)this._dicMoneyKind[key].MoneyKindName.Trim();
                    dataRow[ctPayment] = 0;

                    _payeeDataTable.Rows.Add(dataRow);
                }
            }
            finally
            {
                this._payeeDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.PaymenttChanged);
            }

        }
        #endregion


        #region 買掛支払集計データ→入金内訳テーブル設定

        /// <summary>
        /// 買掛支払集計データ→入金内訳テーブル設定処理
        /// </summary>
        /// <param name="aCalcPayTotalList">買掛支払集計データリスト</param>
        private void ACalcPayTotalListToTable(List<ACalcPayTotal> aCalcPayTotalList)
        {
            if (aCalcPayTotalList == null) return;

            try
            {
                this._payeeDataTable.ColumnChanged -= new DataColumnChangeEventHandler(this.PaymenttChanged);


                foreach (ACalcPayTotal aCalcPayTotal in aCalcPayTotalList)
                {
                    DataRow row = this._payeeDataTable.Rows.Find(aCalcPayTotal.MoneyKindCode);
                    if (row == null)
                    {
                        row = this._payeeDataTable.NewRow();
                        row[ctMoneyKindDiv] = aCalcPayTotal.MoneyKindDiv;
                        row[ctMoneyKindCode] = aCalcPayTotal.MoneyKindCode;
                        row[ctMoneyKindName] = aCalcPayTotal.MoneyKindName;
                        this._payeeDataTable.Rows.Add(row);
                    }
                    row[ctPayment] = aCalcPayTotal.Payment;
                }
            }
            finally
            {
                this._payeeDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.PaymenttChanged);
            }
        }
        #endregion

        #region 買掛支払集計データ→入金内訳テーブル設定

        /// <summary>
        /// 請求入金集計データ→入金内訳テーブル設定処理
        /// </summary>
        /// <param name="dmdDepoTotalList">請求入金集計データリスト</param>
        private void AccPayTotalListToTable(List<AccPayTotal> accPayTotalList)
        {
            if (accPayTotalList == null) return;

            try
            {
                this._payeeDataTable.ColumnChanged -= new DataColumnChangeEventHandler(this.PaymenttChanged);

                foreach (AccPayTotal accPayTotal in accPayTotalList)
                {
                    DataRow row = this._payeeDataTable.Rows.Find(accPayTotal.MoneyKindCode);
                    if (row == null)
                    {
                        row = this._payeeDataTable.NewRow();
                        row[ctMoneyKindDiv] = accPayTotal.MoneyKindDiv;
                        row[ctMoneyKindCode] = accPayTotal.MoneyKindCode;
                        row[ctMoneyKindName] = accPayTotal.MoneyKindName;

                        this._payeeDataTable.Rows.Add(row);
                    }
                    row[ctPayment] = accPayTotal.Payment;
                }

            }
            finally
            {
                this._payeeDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.PaymenttChanged);
            }
        }
        #endregion

        #region 金額入力済みの支払DataRow取得
        /// <summary>
        /// 金額入力済みの支払データのDataRowを取得します。
        /// </summary>
        /// <returns></returns>
        private DataRow[] GetPaymentRows()
        {
            return this._payeeDataTable.Select(string.Format("{0}<>0", ctPayment));
        }
        #endregion

        #region 集計レコードの仕入先買掛金額マスタ、買掛支払集計データを取得

        /// <summary>
        /// 集計レコードの仕入先買掛金額マスタ、買掛支払集計データを取得します。
        /// </summary>
        /// <param name="suplAccPay"></param>
        /// <param name="suplAccPayTotal"></param>
        /// <param name="aCalcPayTotalList"></param>
        private void GetTotalSuplAccPayRecFromTable(SuplAccPay suplAccPay, out SuplAccPay suplAccPayTotal, out List<ACalcPayTotal> aCalcPayTotalList)
        {
            suplAccPayTotal = null;
            aCalcPayTotalList = null;
            string select = string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                SuplAccPayAcs.COL_ADDUPSECCODE_TITLE, suplAccPay.AddUpSecCode,
                SuplAccPayAcs.COL_PAYEECODE_TITLE, suplAccPay.PayeeCode,
                SuplAccPayAcs.COL_ADDUPDATE_TITLE, TDateTime.DateTimeToLongDate(suplAccPay.AddUpDate));
            DataRow[] rows = this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTACCRECTOTAL_TITLE].Select(select);

            if (( rows != null ) && ( rows.Length > 0 ))
            {
                this.DataRowToSuplAccPay(rows[0], out suplAccPayTotal, out aCalcPayTotalList);
            }
            else
            {
                suplAccPayTotal = new SuplAccPay();
                aCalcPayTotalList = new List<ACalcPayTotal>();
            }

        }

        #endregion

        #region 集計レコードの仕入先支払金額マスタ、精算支払集計データを取得
        /// <summary>
        /// 集計レコードの仕入先支払金額マスタ、精算支払集計データを取得します。
        /// </summary>
        /// <param name="suplierPay"></param>
        /// <param name="suplierPayTotal"></param>
        /// <param name="accPayTotalList"></param>
        private void GetTotalSuplierPayFromTable(SuplierPay suplierPay, out SuplierPay suplierPayTotal, out List<AccPayTotal> accPayTotalList)
        {
            suplierPayTotal = null;
            accPayTotalList = null;
            string select = string.Format("{0}='{1}' AND {2}={3} AND {4}={5}",
                SuplAccPayAcs.COL_ADDUPSECCODE_TITLE, suplierPay.AddUpSecCode,
                SuplAccPayAcs.COL_PAYEECODE_TITLE, suplierPay.PayeeCode,
                SuplAccPayAcs.COL_ADDUPDATE_TITLE, TDateTime.DateTimeToLongDate(suplierPay.AddUpDate));
            DataRow[] rows = this.Bind_DataSet.Tables[SuplAccPayAcs.TBL_CUSTDMDPRCTOTAL_TITLE].Select(select);

            if (( rows != null ) && ( rows.Length > 0 ))
            {
                this.DataRowToSuplierPay(rows[0], out suplierPayTotal, out accPayTotalList);
            }
            else
            {
                suplierPayTotal = new SuplierPay();
                accPayTotalList = new List<AccPayTotal>();
            }
        }
        #endregion

        #region 支払内訳グリッドのイベント
        /// <summary>
        /// KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPaymentKind_KeyDown(object sender, KeyEventArgs e)
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
            // カーソルキー押下時のフォーカス制御を行います
            // -------------------------------------------
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (rowIndex == 0)
                    {
                        //// 入金日にフォーカス設定
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
                        // 手数料にフォーカス設定
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
                            // 相殺後消費税にフォーカス設定
                            e.Handled = true;
                            uGrid.ActiveCell = null;
                            uGrid.ActiveRow = null;
                            this.OfsThisStockTax_tNedit.Focus();
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
        /// KeyPressイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPaymentKind_KeyPress(object sender, KeyPressEventArgs e)
        {
            // --- ADD 2009/01/26 障害ID:10443対応------------------------------------------------------>>>>>
            if (this.grdPaymentKind.ActiveCell == null)
            {
                return;
            }
            // --- ADD 2009/01/26 障害ID:10443対応------------------------------------------------------<<<<<

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.grdPaymentKind.ActiveCell;
            if (cell.Column.Key == ctPayment)
            {
                // 編集モード中？
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
        /// AfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPaymentKind_AfterEnterEditMode(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// AfterExitEditModeイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPaymentKind_AfterExitEditMode(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// CellChangeイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPaymentKind_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {

        }

        /// <summary>
        /// Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPaymentKind_Leave(object sender, EventArgs e)
        {
            this.grdPaymentKind.ActiveCell = null;
            this.grdPaymentKind.ActiveRow = null;
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                if (( key != '.' ) && ( key != '-' ))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - ( selstart + sellength ));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if (( minusFlg == false ) || ( selstart > 0 ) || ( _strResult.IndexOf('-') != -1 ))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if (( priod <= 0 ) || ( _strResult.IndexOf('.') != -1 ))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - ( selstart + sellength ));

            // 桁数チェック！
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

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = ( _strResult[0] == '-' ) ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
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

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 相殺金額TNedit_Leave伊部のｔ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OfsThisStockTax_tNedit_Leave(object sender, EventArgs e)
        {
            if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 鑑への反映
            upDateClaim_PanelTextData();
        }
        // 2009.01.14 Add <<<

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 締日
            int addUpADate = AddUpADate_tDateEdit.GetLongDate();

            for (int i = 0; i < this.Bind_DataSet.Tables[this._targetTableName].Rows.Count; i++)
            {
                // データセットと比較
                int dsAddUpADate = (int)this.Bind_DataSet.Tables[this._targetTableName].Rows[i][SuplAccPayAcs.COL_ADDUPDATE_TITLE];
                if (addUpADate == dsAddUpADate)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[this._targetTableName].Rows[i][SuplAccPayAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "MAKAU09130U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの仕入先実績修正情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 締日のクリア
                        AddUpADate_tDateEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "MAKAU09130U",                          // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの仕入先実績修正情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                if (this._targetTableName.Equals(SuplAccPayAcs.TBL_CUSTACCREC_TITLE))
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
                                // 締日のクリア
                                AddUpADate_tDateEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}
