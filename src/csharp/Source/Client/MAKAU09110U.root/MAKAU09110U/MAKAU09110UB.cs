//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先実績修正
// プログラム概要   ：得意先実績修正の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：21024 佐々木 健
// 修正日    2009/01/06     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/01/26     修正内容：障害ID:10441,10447対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/01/28     修正内容：障害ID:10447対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/06     修正内容：Mantis【13144】起動後の得意先追加時エラー対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/23     修正内容：Mantis【13484】請求書Noを追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2011/11/08     修正内容：実績修正を行うと請求一覧表の返品値引項目が0になる不具合修正
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
// SFTOK09241E...得意先情報データクラス
// SFTOK09242A...得意先情報取得アクセスクラス
// SFTOK09381E...従業員情報データクラス
// SFUKK01333D...締スケジュール取得データクラス
// SFUKK01334A...締スケジュール取得アクセスクラス

namespace Broadleaf.Windows.Forms
{
    /// **********************************************************************
    /// <summary>
	///	得意先実績修正フォームクラス
	/// </summary>
	/// <remarks> 
	/// <br>note       : 得意先の売掛・請求の実績修正を行います。</br>
    /// <br>Programmer : 30154 安藤　昌仁</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br></br>
    /// <br>note       : 流通.NS用に変更</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br></br>
    /// <br>Note       : PM.NS用に変更</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.01.06</br>
    /// <br></br>
    /// <br>Note       : 障害ID:10441,10447対応</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2009.01.26</br>
    /// <br></br>
    /// <br>Note       : 障害ID:10447対応</br>
    /// <br>Programmer : 30414 忍 幸史</br>
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
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>コンストラクタ</summary>
		public MAKAU09110UB()
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
			this._secInfoAcs          = new SecInfoAcs();
            this._custAccRecDmdPrcAcs = new CustAccRecDmdPrcAcs();

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
			this._targetCustomerCode = 0;
		
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
        private CustAccRec     _editCustAccRec    = null;       // 編集用
        private CustDmdPrc     _editCustDmdPrc    = null;       // 編集用
        private CustAccRec     _custAccRecClone   = null;       // 起動時バックアップ用
        private CustDmdPrc     _custDmdPrcClone   = null;       // 起動時バックアップ用

        // 2009.01.06 Add >>>
        private List<AccRecDepoTotal> _editAccRecDepoList = null;  // 編集用の入金集計データリスト
        private List<DmdDepoTotal> _editDmdDepoList = null;        // 編集用の入金集計データリスト
        private CustAccRec _custAccRecTotal = new CustAccRec();    // 集計レコード用
        private CustDmdPrc _custDmdPrcTotal = new CustDmdPrc();    // 集計レコード用
        private List<AccRecDepoTotal> _accRecDepoTotalList = null;  // 集計レコード用入金集計データリスト
        private List<DmdDepoTotal> _dmdDepoTotalList = null;        // 集計レコード用入金集計データリスト
        private DataTable _totalDisplayTable = null;            // 残高表示用

        private DataTable _depositDataTable = null;             // 入金内訳入力用
        private DataView _depositDataView = null;
        // 2009.01.06 Add <<<

		private int	           _logicalDeleteMode = -1;			// 画面起動モード


		private System.Globalization.Calendar    calendar;
		private System.Globalization.CultureInfo culture;

		private	DateTime									befTempDateTime ;

		private CustomerSearchAcs      _customerAcs         = null;		    // 得意先情報
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private CustomerInfoAcs        _customerInfoAcs     = null;         // 得意先アクセス
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		private SecInfoAcs             _secInfoAcs          = null;		    // 拠点情報
        private CustAccRecDmdPrcAcs    _custAccRecDmdPrcAcs = null;         // 得意先売掛金額マスタ更新
		private CustomerSearchRet      _prevCustomer;					    // 得意先情報Last
		
		private int                    _totalCount;						    // 件数
		private string                 _enterpriseCode      = "";	        // 企業コード
		private string                 _companySecCode      = "";           // 自拠点コード 

		private bool                   Opt_Section          = false;        // 拠点OP有無
        //private bool                   _autoAllUpDateMode   = false;        // 全拠点も同時に反映するか
		private bool                   _mainOfficeFuncFlag  = false;        // 本社機能フラグ

		private Hashtable _customerTable  = new Hashtable();  // 得意先
		private Hashtable _secInfSetTable = new Hashtable();  // 拠点情報
		private Hashtable _AllaccrecTable = new Hashtable();  // 売掛金額(全社計)
		private Hashtable _AlldmdprcTable = new Hashtable();  // 請求金額(全社計)

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


		private string _sectionCode;                    // 選択拠点コード
		private int    _targetCustomerCode;             // 選択得意先コード
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private int    _targetClaimCode;                // 選択請求先コード
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		private bool   _formBeingStarted = false;       // 画面起動完了 起動途中にClose等の処理エラー回避用
		private bool   _timerStarted     = false;		// 重複起動配慮

		private bool   _changeFlg        = false;       // 入力項目変更時

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // 2009.01.06 >>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
        //// 追加パネル表示位置
        ////private readonly Point _expansionPanelLocation = new Point(723,1);
        //// レイアウト変更により表示位置を修正
        //private readonly Point _expansionPanelLocation = new Point(5, 307);
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
        private readonly Point _expansionPanelLocation = new Point(4, 293);

        private readonly Point _balance3LabelLocation = new Point(5, 66);
        private readonly Point _balance3EditLocation = new Point(96, 66);

        private readonly Point _balance1LabelLocation = new Point(5, 128);
        private readonly Point _balance1EditLocation = new Point(96, 128);

        // 2009.01.06 <<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        private int     _targetDivType;                     // 指定区分（請求取得時に必要⇒public propertyで受取)
        private string  _mngSectionCode;                    // 管理営業所コード（請求設定呼び出し時に使用⇒public propertyで受取)
        private int     _condCustomerCode;                  // 検索用得意先コード
        private int     _condClaimCode;                     // 検索用請求先コード
        private string  _condSectionCode;                   // 検索用計上拠点コード

        // 指定区分プルダウン選択項目値設定
        private const int TARGET_DIV_CLAIM      = 0;      // 指定区分=請求先
        private const int TARGET_DIV_CUSTOMER   = 1;      // 指定区分=得意先
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

        // 2009.01.06 Add >>>
        private DepositRelDataAcs _depositRelDataAcs;
        // 2009.01.06 Add <<<

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

		// 得意先のView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string CUST_DELETE_DATE            = "削除日";
		private const string CUST_CODE_TITLE             = "コード";
		private const string CUST_KANA_TITLE             = "得意先カナ";
		private const string CUST_NAME1_TITLE            = "得意先名称１";
		private const string CUST_NAME2_TITLE            = "得意先名称２";
		private const string CUST_TOTALDAY_TITLE         = "締日";
		private const string CUST_CORPORATEDIVCODE_TITLE = "個人・法人";

		private const string CUST_GUID_TITLE             = "CUST_GUID";
		private const string CUSTOMER_TABLE              = "CUSTOMER";

		// 売掛・請求のView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string REC_SECCODE_TITLE           = "拠点コード";

        private const string REC_ADDUPYEARMONTH_TITLE    = "_計上年月";
        private const string REC_ADDUPDATE_TITLE         = "_計上年月日";
        private const string REC_ADDUPYEARMONTHJP_TITLE  = "計上年月";
        private const string REC_ADDUPDATEJP_TITLE       = "計上年月日";
        private const string REC_TOTAL3_BEF_TITLE        = "前々々回残高";
        private const string REC_TOTAL2_BEF_TITLE        = "前々回残高";
        private const string REC_TOTAL1_BEF_TITLE        = "前回残高";
        private const string REC_THISTIMESALES_TITLE     = "今回売上";
        private const string REC_CONSTAX_TITLE           = "消費税";
        private const string REC_THISTIMEPAYM_TITLE      = "今回支払";
        private const string REC_PAYMCONSTAX_TITLE       = "支払消費税";
        private const string REC_THISTIMEDEPO_TITLE      = "今回入金";
        private const string REC_ACCRECBLNCE_TITLE       = "売掛残高";
        private const string REC_DMDPRCBLNCE_TITLE       = "請求残高";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private const string REC_BALANCEADJUST_TITLE     = "残高調整額";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
        private const string REC_TOTALADJUST_TITLE       = "残高調整額表示";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

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
            this.uGrid_DemandInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_DemandInfo.Location = new System.Drawing.Point(7, 145);
            this.uGrid_DemandInfo.Name = "uGrid_DemandInfo";
            this.uGrid_DemandInfo.Size = new System.Drawing.Size(963, 47);
            this.uGrid_DemandInfo.TabIndex = 1342;
            this.uGrid_DemandInfo.TabStop = false;
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel46.Text = "請求先";
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
            this.DemandSalesInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DemandSalesInfo_Title_Label.Location = new System.Drawing.Point(4, 83);
            this.DemandSalesInfo_Title_Label.Name = "DemandSalesInfo_Title_Label";
            this.DemandSalesInfo_Title_Label.Size = new System.Drawing.Size(204, 24);
            this.DemandSalesInfo_Title_Label.TabIndex = 8;
            this.DemandSalesInfo_Title_Label.Text = "請求売上情報";
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
            this.tLine27.Size = new System.Drawing.Size(3, 168);
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
            this.CustomerTittle_Label.Text = "得意先";
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
            this.CustomerInfo_Title_Label.Text = "得意先情報";
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
            this.SecInf_Tittle_Label.Text = "入力拠点";
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
            this.AddUpADate_Tittle_Label.Text = "締日";
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
            this.AddUpADate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Undo_Button.TabIndex = 71;
            this.Undo_Button.Text = "取消(&U)";
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
            this.Cancel_Button.TabIndex = 74;
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
            this.Delete_Button.TabIndex = 72;
            this.Delete_Button.Text = "完全削除(&D)";
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
            this.OffsetOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.BillPrintDate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel22.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel20.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.OfsThisTimeSalesTaxInc_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel7.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel23.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel23.Location = new System.Drawing.Point(5, 227);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel23.TabIndex = 621;
            this.ultraLabel23.Text = "税込金額";
            // 
            // DisTotal_Label
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance52.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance52.TextHAlignAsString = "Right";
            appearance52.TextVAlignAsString = "Middle";
            this.DisTotal_Label.Appearance = appearance52;
            this.DisTotal_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DisTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.RetTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.SalesTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.OfsThisSalesTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.OfsThisTimeSales_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ItdedOffsetTaxFree_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ItdedOffsetOutTax_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.SaleslSlipCount_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Label101.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label101.Location = new System.Drawing.Point(5, 263);
            this.Label101.Name = "Label101";
            this.Label101.Size = new System.Drawing.Size(85, 22);
            this.Label101.TabIndex = 607;
            this.Label101.Text = "売上伝票枚数";
            // 
            // ultraLabel30
            // 
            appearance188.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel30.Appearance = appearance188;
            this.ultraLabel30.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel30.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel30.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlItdedRetTaxFree_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlItdedRetOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlItdedDisTaxFree_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlItdedDisOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.RowSalesTotal_Tittle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RowSalesTotal_Tittle_Label.Location = new System.Drawing.Point(5, 128);
            this.RowSalesTotal_Tittle_Label.Name = "RowSalesTotal_Tittle_Label";
            this.RowSalesTotal_Tittle_Label.Size = new System.Drawing.Size(85, 22);
            this.RowSalesTotal_Tittle_Label.TabIndex = 571;
            this.RowSalesTotal_Tittle_Label.Text = "値引";
            // 
            // Paym_Title_Label
            // 
            appearance132.TextHAlignAsString = "Left";
            appearance132.TextVAlignAsString = "Middle";
            this.Paym_Title_Label.Appearance = appearance132;
            this.Paym_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Paym_Title_Label.Location = new System.Drawing.Point(5, 97);
            this.Paym_Title_Label.Name = "Paym_Title_Label";
            this.Paym_Title_Label.Size = new System.Drawing.Size(85, 22);
            this.Paym_Title_Label.TabIndex = 570;
            this.Paym_Title_Label.Text = "返品";
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
            this.ItdedSalesTaxFree_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ItdedTaxFree_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedTaxFree_Title_Label.Location = new System.Drawing.Point(202, 35);
            this.ItdedTaxFree_Title_Label.Name = "ItdedTaxFree_Title_Label";
            this.ItdedTaxFree_Title_Label.Size = new System.Drawing.Size(101, 25);
            this.ItdedTaxFree_Title_Label.TabIndex = 577;
            this.ItdedTaxFree_Title_Label.Text = "非課税対象額";
            // 
            // Sales_Title_Label
            // 
            appearance139.TextHAlignAsString = "Left";
            appearance139.TextVAlignAsString = "Middle";
            this.Sales_Title_Label.Appearance = appearance139;
            this.Sales_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Sales_Title_Label.Location = new System.Drawing.Point(5, 66);
            this.Sales_Title_Label.Name = "Sales_Title_Label";
            this.Sales_Title_Label.Size = new System.Drawing.Size(85, 22);
            this.Sales_Title_Label.TabIndex = 569;
            this.Sales_Title_Label.Text = "売上";
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
            this.SalesPaymInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesPaymInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.SalesPaymInfo_Title_Label.Name = "SalesPaymInfo_Title_Label";
            this.SalesPaymInfo_Title_Label.Size = new System.Drawing.Size(413, 24);
            this.SalesPaymInfo_Title_Label.TabIndex = 568;
            this.SalesPaymInfo_Title_Label.Text = "売上情報";
            // 
            // OutTax_Title_Label
            // 
            appearance37.TextHAlignAsString = "Left";
            appearance37.TextVAlignAsString = "Middle";
            this.OutTax_Title_Label.Appearance = appearance37;
            this.OutTax_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OutTax_Title_Label.Location = new System.Drawing.Point(5, 193);
            this.OutTax_Title_Label.Name = "OutTax_Title_Label";
            this.OutTax_Title_Label.Size = new System.Drawing.Size(85, 22);
            this.OutTax_Title_Label.TabIndex = 573;
            this.OutTax_Title_Label.Text = "消費税額";
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
            this.ItdedSalesOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ColSalesTotal_Tittle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColSalesTotal_Tittle_Label.Location = new System.Drawing.Point(5, 162);
            this.ColSalesTotal_Tittle_Label.Name = "ColSalesTotal_Tittle_Label";
            this.ColSalesTotal_Tittle_Label.Size = new System.Drawing.Size(85, 22);
            this.ColSalesTotal_Tittle_Label.TabIndex = 578;
            this.ColSalesTotal_Tittle_Label.Text = "合計";
            // 
            // ultraLabel12
            // 
            appearance181.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel12.Appearance = appearance181;
            this.ultraLabel12.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel12.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel18.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel19.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel17.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel36.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ItdedOutTax_Tittle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ItdedOutTax_Tittle_Label.Location = new System.Drawing.Point(95, 32);
            this.ItdedOutTax_Tittle_Label.Name = "ItdedOutTax_Tittle_Label";
            this.ItdedOutTax_Tittle_Label.Size = new System.Drawing.Size(101, 30);
            this.ItdedOutTax_Tittle_Label.TabIndex = 572;
            this.ItdedOutTax_Tittle_Label.Text = "課税対象額";
            // 
            // ultraLabel3
            // 
            appearance168.TextHAlignAsString = "Center";
            appearance168.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance168;
            this.ultraLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(317, 33);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(101, 29);
            this.ultraLabel3.TabIndex = 608;
            this.ultraLabel3.Text = "合計";
            // 
            // ultraLabel13
            // 
            appearance182.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel13.Appearance = appearance182;
            this.ultraLabel13.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel13.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel13.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.DepositInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DepositInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.DepositInfo_Title_Label.Name = "DepositInfo_Title_Label";
            this.DepositInfo_Title_Label.Size = new System.Drawing.Size(229, 24);
            this.DepositInfo_Title_Label.TabIndex = 599;
            this.DepositInfo_Title_Label.Text = "入金情報";
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
            this.grdDepositKind.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
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
            this.ultraLabel41.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.NrmlTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ColDepoTotal_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColDepoTotal_Title_Label.Location = new System.Drawing.Point(5, 238);
            this.ColDepoTotal_Title_Label.Name = "ColDepoTotal_Title_Label";
            this.ColDepoTotal_Title_Label.Size = new System.Drawing.Size(80, 22);
            this.ColDepoTotal_Title_Label.TabIndex = 596;
            this.ColDepoTotal_Title_Label.Text = "入金合計";
            // 
            // ultraLabel9
            // 
            appearance55.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel9.Appearance = appearance55;
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel9.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel9.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel21.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.DisNrml_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Discount_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Discount_Title_Label.Location = new System.Drawing.Point(5, 204);
            this.Discount_Title_Label.Name = "Discount_Title_Label";
            this.Discount_Title_Label.Size = new System.Drawing.Size(80, 22);
            this.Discount_Title_Label.TabIndex = 592;
            this.Discount_Title_Label.Text = "値引額";
            // 
            // ultraLabel8
            // 
            appearance79.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel8.Appearance = appearance79;
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.FeeNrml_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Fee_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Fee_Title_Label.Location = new System.Drawing.Point(5, 173);
            this.Fee_Title_Label.Name = "Fee_Title_Label";
            this.Fee_Title_Label.Size = new System.Drawing.Size(80, 22);
            this.Fee_Title_Label.TabIndex = 589;
            this.Fee_Title_Label.Text = "手数料額";
            // 
            // ultraLabel4
            // 
            appearance92.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel4.Appearance = appearance92;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel31.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel32.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel32.Location = new System.Drawing.Point(1, 74);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(91, 24);
            this.ultraLabel32.TabIndex = 590;
            this.ultraLabel32.Text = "消費税調整額";
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
            this.TaxAdjust_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.BalanceAdjust_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel27.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel27.Location = new System.Drawing.Point(3, 39);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(89, 24);
            this.ultraLabel27.TabIndex = 589;
            this.ultraLabel27.Text = "残高調整額";
            // 
            // ultraLabel57
            // 
            appearance200.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel57.Appearance = appearance200;
            this.ultraLabel57.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel57.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel57.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel10.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(3, 4);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(206, 24);
            this.ultraLabel10.TabIndex = 535;
            this.ultraLabel10.Text = "残高調整情報";
            // 
            // ultraLabel58
            // 
            appearance202.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel58.Appearance = appearance202;
            this.ultraLabel58.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel58.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel58.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel56.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.BlTotal_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.LtBlInfo_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LtBlInfo_Title_Label.Location = new System.Drawing.Point(5, 5);
            this.LtBlInfo_Title_Label.Name = "LtBlInfo_Title_Label";
            this.LtBlInfo_Title_Label.Size = new System.Drawing.Size(192, 24);
            this.LtBlInfo_Title_Label.TabIndex = 589;
            this.LtBlInfo_Title_Label.Text = "前回残高情報";
            // 
            // ultraLabel34
            // 
            appearance190.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel34.Appearance = appearance190;
            this.ultraLabel34.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel34.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel34.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.BlTotalTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BlTotalTitle_Label.Location = new System.Drawing.Point(5, 162);
            this.BlTotalTitle_Label.Name = "BlTotalTitle_Label";
            this.BlTotalTitle_Label.Size = new System.Drawing.Size(89, 22);
            this.BlTotalTitle_Label.TabIndex = 587;
            this.BlTotalTitle_Label.Text = "残高合計";
            // 
            // ultraLabel33
            // 
            appearance95.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel33.Appearance = appearance95;
            this.ultraLabel33.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel33.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel33.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel28.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel29.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel29.Location = new System.Drawing.Point(96, 40);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(101, 18);
            this.ultraLabel29.TabIndex = 578;
            this.ultraLabel29.Text = "残高";
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
            this.Bf2TmBl_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Bf3TmBl_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.LMBl_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Bf3TmBl_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf3TmBl_Label.Location = new System.Drawing.Point(5, 66);
            this.Bf3TmBl_Label.Name = "Bf3TmBl_Label";
            this.Bf3TmBl_Label.Size = new System.Drawing.Size(88, 22);
            this.Bf3TmBl_Label.TabIndex = 567;
            this.Bf3TmBl_Label.Text = "前々々回残高";
            // 
            // Bf2TmBl_Label
            // 
            appearance179.TextHAlignAsString = "Left";
            appearance179.TextVAlignAsString = "Middle";
            this.Bf2TmBl_Label.Appearance = appearance179;
            this.Bf2TmBl_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Bf2TmBl_Label.Location = new System.Drawing.Point(5, 97);
            this.Bf2TmBl_Label.Name = "Bf2TmBl_Label";
            this.Bf2TmBl_Label.Size = new System.Drawing.Size(89, 22);
            this.Bf2TmBl_Label.TabIndex = 569;
            this.Bf2TmBl_Label.Text = "前々回残高";
            // 
            // LMBl_Label
            // 
            appearance180.TextHAlignAsString = "Left";
            appearance180.TextVAlignAsString = "Middle";
            this.LMBl_Label.Appearance = appearance180;
            this.LMBl_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LMBl_Label.Location = new System.Drawing.Point(5, 128);
            this.LMBl_Label.Name = "LMBl_Label";
            this.LMBl_Label.Size = new System.Drawing.Size(89, 22);
            this.LMBl_Label.TabIndex = 571;
            this.LMBl_Label.Text = "前回残高";
            // 
            // ultraLabel26
            // 
            appearance189.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel26.Appearance = appearance189;
            this.ultraLabel26.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel26.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel26.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel24.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel25.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ExpectedDepositDate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.CollectCondValue_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.CollectCond_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel52.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel52.Location = new System.Drawing.Point(5, 74);
            this.ultraLabel52.Name = "ultraLabel52";
            this.ultraLabel52.Size = new System.Drawing.Size(96, 24);
            this.ultraLabel52.TabIndex = 566;
            this.ultraLabel52.Text = "回収条件";
            // 
            // ultraLabel51
            // 
            appearance58.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel51.Appearance = appearance58;
            this.ultraLabel51.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel51.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel51.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel50.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel50.Location = new System.Drawing.Point(3, 41);
            this.ultraLabel50.Name = "ultraLabel50";
            this.ultraLabel50.Size = new System.Drawing.Size(96, 24);
            this.ultraLabel50.TabIndex = 564;
            this.ultraLabel50.Text = "入金予定日";
            // 
            // ultraLabel49
            // 
            appearance80.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel49.Appearance = appearance80;
            this.ultraLabel49.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel49.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel49.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(4, 6);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(248, 24);
            this.ultraLabel1.TabIndex = 545;
            this.ultraLabel1.Text = "請求・回収情報";
            // 
            // ultraLabel39
            // 
            appearance84.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel39.Appearance = appearance84;
            this.ultraLabel39.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel39.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel39.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel48.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel48.Location = new System.Drawing.Point(7, 402);
            this.ultraLabel48.Name = "ultraLabel48";
            this.ultraLabel48.Size = new System.Drawing.Size(96, 24);
            this.ultraLabel48.TabIndex = 561;
            this.ultraLabel48.Text = "請求書発行日";
            this.ultraLabel48.Visible = false;
            // 
            // ultraLabel47
            // 
            appearance82.BackColor2 = System.Drawing.Color.Transparent;
            this.ultraLabel47.Appearance = appearance82;
            this.ultraLabel47.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel47.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel47.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlItdedDisInTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ItdedSalesInTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.SalesInTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlRetInnerTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlDisInnerTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlRetOuterTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlItdedRetInTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.SalesOutTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.TtlDisOuterTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.BillNo_uLabel.Text = "請求書No";
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
            this.BillNo_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tLine6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKAU09110UB";
            this.Text = "得意先実績修正";
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
		/// <summary>選択された得意先コードプロパティ</summary>
		/// <value>画面で選択された得意先コードを取得します。</value>
		public int TargetCustomerCode
		{
			get{ return this._targetCustomerCode; }
			set{ this._targetCustomerCode = value; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>選択された請求先コードプロパティ</summary>
        /// <value>画面で選択された請求先コードを取得します</value>
        public int TargetClaimCode
        {
            get { return this._targetClaimCode; }
            set { this._targetClaimCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        /// <summary>指定区分設定プロパティ</summary>
        /// <value>設定画面上の「指定区分」プルダウンの値を設定します。</value>
        public int TargetDivType
        {
            get { return this._targetDivType; }
            set { this._targetDivType = value; }
        }

        /// <summary>請求書コードの管理営業所コード</summary>
        /// <value>請求設定に使用する管理営業所コードを設定します。</value>
        public string MngSectionCode
        {
            get { return this._mngSectionCode; }
            set { this._mngSectionCode = value; }
        }

        /// <summary>検索用請求先コード</summary>
        /// <value>検索で使用する請求先コードを取得します。選択請求先コードは再検索時のみ使用</value>
        public int CondClaimCode
        {
            get { return this._condClaimCode; }
            set { this._condClaimCode = value; }
        }

        /// <summary>検索用得意先コード</summary>
        /// <value>検索で使用する得意先コードを取得します。選択得意先コードは再検索時のみ使用</value>
        public int CondCustomerCode
        {
            get { return this._condCustomerCode; }
            set { this._condCustomerCode = value; }
        }

        /// <summary>検索用計上拠点コード</summary>
        /// <value>検索で使用する計上拠点コードを取得します。選択拠点コードは再検索時のみ使用</value>
        public string CondSectionCode
        {
            get { return this._condSectionCode; }
            set { this._condSectionCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

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
		# endregion

        private Form _invokerForm;
        public Form InvokerForm
        {
            get { return this._invokerForm; }
            set { this._invokerForm = value; }
        }

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
			blRet[0] = false;     // 売掛
			blRet[1] = false;     // 請求
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
			// 売掛グリッドの列外観情報設定
			Hashtable	accTable = new Hashtable();

			// Addを行う順番が、列の表示順位となります。
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

			// 請求グリッドの列外観情報設定
			Hashtable	dmdTable = new Hashtable();
			// Addを行う順番が、列の表示順位となります。
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
            this.Bind_DataSet = this._custAccRecDmdPrcAcs.BindDataSet;
			bindDataSet = this.Bind_DataSet;
            // テーブル名取得
			string[] strRet = new string[2];
			strRet[0] = CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE;
			strRet[1] = CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE;
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

		/// <summary>得意先データ検索処理</summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 得意先データを検索します。</br>
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
                        // 最終の得意先オブジェクトを退避する
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
						          "MAKAU09110U", 						    // アセンブリＩＤまたはクラスＩＤ
						          "得意先実績修正",					        // プログラム名称
						          "MAKAU09110U", 						    // 処理名称
						          TMsgDisp.OPE_GET, 					    // オペレーション
						          "得意先情報読み込みに失敗しました。", 	// 表示するメッセージ
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

		/// <summary>指定得意先データ情報読み込み処理</summary>
        /// <param name="customerRet">得意先情報</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定得意先コードのデータを検索します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
                // UI画面を開いた状態で得意先を追加した場合、
                // 検索が失敗するので再検索処理を追加
                CustomerSearchPara para = new CustomerSearchPara();
                CustomerSearchRet[] retArray = null;
                para.EnterpriseCode = this._enterpriseCode;
                para.CustomerCode = customerCode;
                // 再検索
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
			// 自拠点情報取得
			status = ReadCompanySecInfoSetInfo();
			return status;
		}

		/// <summary>請求金額情報のデータ検索処理</summary>
        /// <param name="claimCode">請求先コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
        /// <param name="targetDivType">指定区分タイプ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 請求金額情報を取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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

		/// <summary>売掛金額情報のデータ検索処理</summary>
        /// <param name="claimCode">請求先コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 売掛金額情報を取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
            LABELList[3] = REC_THISTIMESALES_TITLE;     // 今回売上
            LABELList[4] = REC_CONSTAX_TITLE;           // 消費税
            LABELList[5] = REC_THISTIMEPAYM_TITLE;      // 今回支払
            LABELList[6] = REC_PAYMCONSTAX_TITLE;       // 支払消費税
            LABELList[7] = REC_THISTIMEDEPO_TITLE;      // 今回入金
            LABELList[8] = REC_ACCRECBLNCE_TITLE;       // 残高
        }


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START

        /// <summary>
        /// 新規画面を作成する際に、受け取った得意先コードを元に得意先の情報を取得する
        /// </summary>
        /// <remarks>テーブル上に「得意先名」「得意先名２」などが
        /// セットされていない原因を解消するための処置（もともとの設計の問題）
        /// データベースおよびアプリケーションの表示上は問題ない模様（表示されない）</remarks>
        public void GetSettledCustomerData()
        {
            int status;
            CustomerInfo customerInfo;

            // Public Propertyで受け取った得意先コードを元に得意先情報を取得する
            status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, this._targetCustomerCode, out customerInfo);

            // 得意先情報を取得できたときのみ情報を抽出
            if (customerInfo != null)
            {
                this.CustomerName_Label.Text = customerInfo.Name;
                this.CustomerName2_Label.Text = customerInfo.Name2;

                // 請求先情報も抽出しておく
                this.ClaimName_Label.Text = customerInfo.ClaimName;
                this.ClaimName2_Label.Text = customerInfo.ClaimName2;
                this.ClaimSnm_Label.Text = customerInfo.ClaimSnm;
            }

        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
        # endregion

        // ===================================================================================== //
		// 内部メソッド（DB関連）
		// ===================================================================================== //
		# region Private Methods_DB_Relation

		/// <summary>HashTableに得意先情報格納</summary>
        /// <param name="customerRet">得意先情報</param>
		/// <remarks>
		/// <br>Note       : 渡された得意先情報をHashTableに格納します。</br>
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

        /// <summary>売掛金額情報取得処理</summary>
        /// <param name="claimCode">請求先コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
		/// <param name="retAccRecTable">売掛金額情報取得結果</param>
		/// <param name="BindDataSetMode">DataSetへの設定有無（HashTableのみならfalse）</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 売掛金額を取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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

            // 全社が選択されている場合
            if (addUpSecCode == ALLSECCODE)
            {
                addUpSecCode = null;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            if (targetDivType == TARGET_DIV_CLAIM)
            {
                // 指定区分：請求先の時
                // 得意先・請求先コード：画面上の得意先コード
                // 計上拠点コード：画面の拠点コード
                // 2009.01.06 >>>
                //status = this._custAccRecDmdPrcAcs.SearchCustAccRec(out totalCount, this._enterpriseCode, addUpSecCode, customerCode, customerCode);
                status = this._custAccRecDmdPrcAcs.SearchCustAccRec(out totalCount, this._enterpriseCode, addUpSecCode, customerCode, 0);
                // 2009.01.06 <<<
            }
            else
            {
                // 指定区分：得意先の時
                // 請求先コード：得意先に対する請求先コード
                // 得意先コード：画面上の得意先コード
                // 計上拠点コード：請求先の管理営業所コード
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
                        TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP, 		    // エラーレベル
                                      "MAKAU09110U", 						// アセンブリＩＤまたはクラスＩＤ
                                      "得意先実績修正",					    // プログラム名称
                                      "SearchAccPrcInfo", 					// 処理名称
                                      TMsgDisp.OPE_GET, 					// オペレーション
                                      "売掛情報読み込みに失敗しました。", 	// 表示するメッセージ
                                      status, 							    // ステータス値
                                      this._custAccRecDmdPrcAcs,			// エラーが発生したオブジェクト
                                      MessageBoxButtons.OK, 				// 表示するボタン
                                      MessageBoxDefaultButton.Button1);	    // 初期表示ボタン
                        break;
                    }
            }

			return status;
		}

        /// <summary>請求金額情報取得処理</summary>
        /// <param name="claimCode">請求先コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="addUpSecCode">計上拠点コード</param>
		/// <param name="retDmdRecTable">請求金額情報取得結果</param>
		/// <param name="BindDataSetMode">DataSetへの設定有無（HashTableのみならfalse）</param>
        /// <param name="targetDivType">指定区分タイプ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 請求金額を取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private int SearchDmdRecInfo(int claimCode, int customerCode,string addUpSecCode, out Hashtable retDmdRecTable,bool BindDataSetMode, int targetDivType)
		{
			int status = 0;
            int totalCount = 0;
			
			retDmdRecTable = new Hashtable();

            // 全社が選択されている場合
            if (addUpSecCode == ALLSECCODE)
            {
                addUpSecCode = null;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            if (targetDivType == TARGET_DIV_CLAIM) 
            {
                // 指定区分＝「請求先」の時は計上拠点・実績拠点に画面の拠点コードをセットして検索
                // 対象となる得意先・請求先コードは請求先コード
                // 2009.01.06 >>>
                //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, addUpSecCode, addUpSecCode, customerCode, customerCode);
                status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, addUpSecCode, string.Empty, customerCode, 0);
                // 2009.01.06 <<<
                //status = this._custAccRecDmdPrcAcs.SearchCustDmdPrc(out totalCount, this._enterpriseCode, addUpSecCode, string.Empty, claimCode, customerCode);
            }
            else
            {
                // 指定区分＝「得意先」の時は実績拠点に画面の拠点コード、計上拠点に管理営業所コードをセットして検索
                // 対象となる得意先コードは得意先コード,請求先コードは得意先に対する請求先コード
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
                        TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP, 		    // エラーレベル
                                      "MAKAU09110U", 						// アセンブリＩＤまたはクラスＩＤ
                                      "得意先実績修正",					    // プログラム名称
                                      "SearchDmdRecInfo", 					// 処理名称
                                      TMsgDisp.OPE_GET, 					// オペレーション
                                      "請求情報読み込みに失敗しました。", 	// 表示するメッセージ
                                      status, 							    // ステータス値
                                      this._custAccRecDmdPrcAcs,			// エラーが発生したオブジェクト
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
								          "MAKAU09110U", 						// アセンブリＩＤまたはクラスＩＤ
								          "得意先実績修正",					    // プログラム名称
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
								          "MAKAU09110U", 						// アセンブリＩＤまたはクラスＩＤ
								          "得意先実績修正",					    // プログラム名称
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
            this._mainOfficeFuncFlag = true;    // 本社機能固定

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
            //                      "MAKAU09110U",		  						    // アセンブリＩＤまたはクラスＩＤ
            //                      " 拠点制御情報に登録されていません。",			// 表示するメッセージ 
            //                      0,												// ステータス値
            //                      MessageBoxButtons.OK);							// 表示するボタン
            //        break;
            //    }
            //    default:
            //    {
            //        TMsgDisp.Show(this,											    // 親ウィンドウフォーム
            //                      emErrorLevel.ERR_LEVEL_STOP,					    // エラーレベル
            //                      "MAKAU09110U",									// アセンブリＩＤまたはクラスＩＤ
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
						          "MAKAU09110U",						    // アセンブリID
						          "既に他端末より更新されています。",	    // 表示するメッセージ
						          status,									// ステータス値
						          MessageBoxButtons.OK);					// 表示するボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show(this,                                     // 親ウィンドウフォーム
						          emErrorLevel.ERR_LEVEL_EXCLAMATION,       // エラーレベル
						          "MAKAU09110U",						    // アセンブリID
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
		/// <param name="HeaderClear">得意先・拠点のクリア有無 true:クリア false:クリアしない</param>
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
				// 得意先情報（コード・名称・締日)
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
				// 拠点情報
				this.demandAddUpSecCd_Label.Text   = "";
				this.demandAddUpSecName_Label.Text = "";
			}

			// 計上日付
            this.AddUpADate_tDateEdit.SetDateTime(DateTime.MinValue);

            // ADD 2009/06/23 ------>>>
            this.BillNo_tNedit.Text = "";   // 請求書No
            // ADD 2009/06/23 ------<<<
			
			// ----- 鑑項目 -----
            // 2009.01.06 >>>
            //// 前回情報
            //this.TtlBf3TmBl_Label.Text = "";        // ３回以前残高
            //this.TtlBf2TmBl_Label.Text = "";        // ２回以前残高
            //this.TtlLMBl_Label.Text    = "";        // 前回残高

            ////カンマ編集前の値を設定
            //this.TtlBf3TmBl_Label.Tag  = 0;         // ３回以前残高
            //this.TtlBf2TmBl_Label.Tag  = 0;         // ２回以前残高
            //this.TtlLMBl_Label.Tag     = 0;         // 前回残高

            //this.TtlSales_Label.Text   = "";        // 今回売上
            //this.TtlTax_Label.Text     = "";        // 消費税
            //this.TtlDepo_Label.Text    = "";        // 今回入金
            //this.TtlBl_Label.Text      = "";        // 売掛残高残高

            this._totalDisplayTable.Rows.Clear();
            this._totalDisplayTable.Rows.Add(this._totalDisplayTable.NewRow());
            // 2009.01.06 <<<

            // ----- 詳細情報画面項目 -----
			// 売上・支払情報
            this.ItdedSalesOutTax_tNedit.Clear();   // 売上外税対象額
            this.SalesOutTax_tNedit.Clear();        // 売上外税額
            this.ItdedSalesInTax_tNedit.Clear();    // 売上内税対象額
            this.SalesInTax_tNedit.Clear();         // 売上内税額
            this.ItdedSalesTaxFree_tNedit.Clear();  // 売上非課税対象額
            this.SalesTotal_Label.Text        = ""; // 売上合計額     
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
            //// 現金売上
            //this.ThisCashSalePrice_tNedit.Clear();  // 現金売上金額
            //this.ThisCashSaleTax_tNedit.Clear();    // 現金売上消費税

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // 未決済金額
            //this.NonStmntAppearance_tNedit.Clear();  // 未決済金額（自振）
            //this.NonStmntIsdone_tNedit.Clear();      // 未決済金額（廻し）
            // 決済金額
            //this.StmntAppearance_tNedit.Clear();    // 決済金額（自振）
            //this.StmntIsdone_tNedit.Clear();        // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

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
            // 入金情報
            //this.DepoNrml_tNedit.Clear();           // 通常入金金額   // 2009.01.06 Del
            this.FeeNrml_tNedit.Clear();            // 通常手数料額
            this.DisNrml_tNedit.Clear();            // 通常値引額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.Clear();            // 通常リベート額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.NrmlTotal_Label.Text    = "";      // 通常合計額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.Depo_tNedit.Clear();               // 預り金入金金額
            //this.FeeDepo_tNedit.Clear();            // 預り金手数料額
            //this.DisDepo_tNedit.Clear();            // 預り金値引額
            //this.RbtDepo_tNedit.Clear();            // 預り金リベート額
            //this.DepoTotal_Label.Text    = "";      // 預り金合計額
            //this.DepoPrcTotal_Label.Text = "";      // 入金金額合計
            //this.FeeTotal_Label.Text     = "";      // 手数料額合計
            //this.DisTotal_Label.Text     = "";      // 値引額合計
            //this.RbtTotal_Label.Text     = "";      // リベート額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 前回残高
            this.Bf3TmBl_tNedit.Clear();            // ３回以前残高
            this.Bf2TmBl_tNedit.Clear();            // ２回以前残高
            this.LMBl_tNedit.Clear();               // 前回残高

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 支払金額
            //this.ItdedPaymOutTax_tNedit.Clear();    // 支払外税対象額
            //this.PaymentOutTax_tNedit.Clear();      // 支払外税額
            //this.ItdedPaymInTax_tNedit.Clear();     // 支払内税対象額
            //this.PaymentInTax_tNedit.Clear();       // 支払内税額
            //this.ItdedPaymTaxFree_tNedit.Clear();   // 支払非課税対象額
            //this.ItdedPaymTotal_Label.Text = string.Empty;  // 支払額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

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
			// 売上・支払情報
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
            // 入金
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
			// 前回残
			this.LMBl_tNedit.Enabled              = enabled;
            this.Bf2TmBl_tNedit.Enabled           = enabled;
            this.Bf3TmBl_tNedit.Enabled           = enabled;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 支払
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
        /// <summary>画面入力許可制御処理_請求書No</summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 請求書Noの入力許可を制御します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl_BillNo(bool enabled)
        {
            // 請求情報のみ表示
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                // 売掛情報
                this.BillNo_uLabel.Visible = false;
                this.BillNo_tNedit.Visible = false;
            }
            else
            {
                // 請求情報
                this.BillNo_uLabel.Visible = true;
                this.BillNo_tNedit.Visible = true;
                this.BillNo_tNedit.Enabled = enabled;
            }
        }
        // ADD 2009/06/23 ------<<<
        
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
			this.Text = "得意先実績修正";

            CustomerSearchRet customerRet = (CustomerSearchRet)this._customerTable[this._targetCustomerCode];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            CustomerInfo customerInfo;
            this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerRet.CustomerCode);

            // (※現状の処理の流れ上発生しないが、念の為staticにない場合はリモート呼び出しする処理を記述)
            if (customerInfo.CustomerCode != customerRet.CustomerCode) {
                this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerRet.CustomerCode,out customerInfo);
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 得意先・拠点情報を表示
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

            // 2009.01.06 Add >>>
            this._totalDisplayTable.Rows.Clear();
            this._totalDisplayTable.Rows.Add(this._totalDisplayTable.NewRow());
            // 2009.01.06 Add <<<

			// 売掛
			if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
                CustAccRec custAccRec = new CustAccRec();
                // 2009.01.06 Add >>>
                CustAccRec custAccRecTotal = new CustAccRec();
                List<AccRecDepoTotal> accRecDepoList = new List<AccRecDepoTotal>();
                List<AccRecDepoTotal> accRecDepoTotalList = new List<AccRecDepoTotal>();
                // 2009.01.06 Add <<<
				// 新規
				if(this._accRecDataIndex < 0 )
				{
					// 新規
					this.Mode_Label.Text = INSERT_MODE;
					_logicalDeleteMode = -1;
					focusControl = this.AddUpADate_tDateEdit;		
				}
				else
				{
					// 更新モード
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
				// 画面表示		
                DetailsAccRecToScreen(this._editCustAccRec);
			
				this._accRecIndexBuf  = this._accRecDataIndex;
				this._dmdPrcIndexBuf  = -2;
                //this.TtlBl_Title_Label.Text         = "売掛残高";     // 2009.01.06 Del
                this.SalesPaymInfo_Title_Label.Text = "売掛情報";

            }
			else
			{
                CustDmdPrc custDmdPrc = new CustDmdPrc();
                // 2009.01.06 Add >>>
                CustDmdPrc custDmdTotalPrc = new CustDmdPrc();
                List<DmdDepoTotal> dmdDepoList = new List<DmdDepoTotal>();
                List<DmdDepoTotal> dmdDepoTotalList = new List<DmdDepoTotal>();
                // 2009.01.06 Add <<<
				// 得意先コード未設定
				if(this._dmdPrcDataIndex < 0 )
				{
					// 新規
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
                    // 更新モード
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

				// 画面表示		
                DetailsDmdPrcToScreen(this._editCustDmdPrc);

				this._accRecIndexBuf  = -2;
				this._dmdPrcIndexBuf  = this._dmdPrcDataIndex;
                //this.TtlBl_Title_Label.Text         = "請求残高";     // 2009.01.06 Del
                this.SalesPaymInfo_Title_Label.Text = "請求売上情報";
            }

			// 入力受付制御
			ScreenInputPermissionControl_Date(_logicalDeleteMode == -1);
			ScreenInputPermissionControl_Details((_logicalDeleteMode == -1) || (_logicalDeleteMode == 0));
            ScreenInputPermissionControl_BillNo((_logicalDeleteMode == -1) || (_logicalDeleteMode == 0));  // ADD 2009/06/23

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
            this._customerCodeBuf = customerRet.CustomerCode;
			this._targetTableBuf  = this._targetTableName;

            // 売上合計金額ラベルの反映
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                // 2009.01.06 >>>
                //DetailsAccRecToClaim_panel(this._editCustAccRec);
                // 請求先指定時は画面表示金額の集計分を表示し、得意先指定時は退避している集計レコードから表示する
                DetailsAccRecToClaim_panel(( this._targetDivType == 1 ) ? this._custAccRecTotal : this._editCustAccRec);
                // 2009.01.06 <<<
                getKinSetInfo_Acc(ref this._editCustAccRec);
                // 鑑情報を再計算(オリジナルデータ)
                // ※これを行わないと編集中データとの整合性がとれなくなり、編集していないのに編集中とされるため
                getKinSetInfo_Acc(ref this._custAccRecClone);
            }
            else
            {
                // 2009.01.06 >>>
                //DetailsDmdPrcToClaim_panel(this._editCustDmdPrc);
                // 請求先指定時は画面表示金額の集計分を表示し、得意先指定時は退避している集計レコードから表示する
                DetailsDmdPrcToClaim_panel(( this._targetDivType == 1 ) ? this._custDmdPrcTotal : this._editCustDmdPrc);
                // 2009.01.06 <<<
                getKinSetInfo_Dmd(ref this._editCustDmdPrc);
                // 鑑情報を再計算(オリジナルデータ)
                // ※これを行わないと編集中データとの整合性がとれなくなり、編集していないのに編集中とされるため
                getKinSetInfo_Dmd(ref this._custDmdPrcClone);
            }

            //TtlBl_Label.Text = Claim_panelDataFormat(this.custAccRec.AfCalTMonthAccRec + custAccRec.BalanceAdjust + custAccRec.TaxAdjust, true);
		}

		/// <summary>画面に売掛金額情報設定</summary>
        /// <param name="custAccRec">売掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 画面に売掛金額情報を設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsAccRecToScreen(CustAccRec custAccRec)
		{
			// 計上日付
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

            // 鑑に情報を反映
            // 2009.01.06 >>>
            //DetailsAccRecToClaim_panel(custAccRec);
            // 請求先指定時は画面表示金額の集計分を表示し、得意先指定時は退避している集計レコードから表示する
            DetailsAccRecToClaim_panel(( this._targetDivType == 1 ) ? this._custAccRecTotal : custAccRec);
            // 2009.01.06 <<<
	
			// ----- 詳細情報画面項目 -----
			// 前回残高情報
            this.LMBl_tNedit.SetValue(custAccRec.LastTimeAccRec);
            this.Bf2TmBl_tNedit.SetValue(custAccRec.AcpOdrTtl2TmBfAccRec);
            this.Bf3TmBl_tNedit.SetValue(custAccRec.AcpOdrTtl3TmBfAccRec);

			// 売上・支払情報
            // 売上
            this.ItdedSalesOutTax_tNedit.SetValue(custAccRec.ItdedSalesOutTax);
            this.SalesOutTax_tNedit.SetValue(custAccRec.SalesOutTax);
            this.ItdedSalesInTax_tNedit.SetValue(custAccRec.ItdedSalesInTax);
            this.SalesInTax_tNedit.SetValue(custAccRec.SalesInTax);
            this.ItdedSalesTaxFree_tNedit.SetValue(custAccRec.ItdedSalesTaxFree);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            this.TtlItdedRetOutTax_tNedit.SetValue( -1 * custAccRec.TtlItdedRetOutTax );
            this.TtlRetOuterTax_tNedit.SetValue(-1 * custAccRec.TtlRetOuterTax);
            this.TtlItdedRetInTax_tNedit.SetValue( -1 * custAccRec.TtlItdedRetInTax );
            this.TtlRetInnerTax_tNedit.SetValue( -1 * custAccRec.TtlRetInnerTax );
            this.TtlItdedRetTaxFree_tNedit.SetValue( -1 * custAccRec.TtlItdedRetTaxFree );
            // 値引
            this.TtlItdedDisOutTax_tNedit.SetValue( -1 * custAccRec.TtlItdedDisOutTax );
            this.TtlDisOuterTax_tNedit.SetValue(-1 * custAccRec.TtlDisOuterTax);
            this.TtlItdedDisInTax_tNedit.SetValue( -1 * custAccRec.TtlItdedDisInTax );
            this.TtlDisInnerTax_tNedit.SetValue( -1 * custAccRec.TtlDisInnerTax );
            this.TtlItdedDisTaxFree_tNedit.SetValue( -1 * custAccRec.TtlItdedDisTaxFree );
            // 残高調整
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            this.BalanceAdjust_tNedit.SetValue(custAccRec.BalanceAdjust);
            this.TaxAdjust_tNedit.SetValue(custAccRec.TaxAdjust);
            this.SaleslSlipCount_tNedit.SetValue(custAccRec.SalesSlipCount);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
            //// 現金売上金額
            //this.ThisCashSalePrice_tNedit.SetValue(custAccRec.ThisCashSalePrice);
            //this.ThisCashSaleTax_tNedit.SetValue(custAccRec.ThisCashSaleTax);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // 未決済金額
            //this.NonStmntAppearance_tNedit.SetValue(custAccRec.NonStmntAppearance);
            //this.NonStmntIsdone_tNedit.SetValue(custAccRec.NonStmntIsdone);
            // 決済金額
            //this.StmntAppearance_tNedit.SetValue(custAccRec.StmntAppearance);
            //this.StmntIsdone_tNedit.SetValue(custAccRec.StmntIsdone);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 支払
            //this.ItdedPaymOutTax_tNedit.SetValue(custAccRec.ItdedPaymOutTax);
            //this.PaymentOutTax_tNedit.SetValue(custAccRec.PaymentOutTax);
            //this.ItdedPaymInTax_tNedit.SetValue(custAccRec.ItdedPaymInTax);
            //this.PaymentInTax_tNedit.SetValue(custAccRec.PaymentInTax);
            //this.ItdedPaymTaxFree_tNedit.SetValue(custAccRec.ItdedPaymTaxFree);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 支払
            //this.ItdedPaymOutTax_tNedit.SetValue( -1 * custAccRec.ItdedPaymOutTax);
            //this.PaymentOutTax_tNedit.SetValue( -1 * custAccRec.PaymentOutTax );
            //this.ItdedPaymInTax_tNedit.SetValue( -1 * custAccRec.ItdedPaymInTax );
            //this.PaymentInTax_tNedit.SetValue( -1 * custAccRec.PaymentInTax );
            //this.ItdedPaymTaxFree_tNedit.SetValue( -1 * custAccRec.ItdedPaymTaxFree );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // 2009.01.06 Add >>>
            // 相殺後消費税
            this.OfsThisSalesTax_tNedit.SetValue(custAccRec.OfsThisSalesTax);
            this.OffsetOutTax_tNedit.SetValue(custAccRec.OffsetOutTax);
            // 2009.01.06 Add <<<

            // 入金情報
            // 通常入金
            //this.DepoNrml_tNedit.SetValue(custAccRec.ThisTimeDmdNrml);    // 2009.01.06 Del
            this.FeeNrml_tNedit.SetValue(custAccRec.ThisTimeFeeDmdNrml);
            this.DisNrml_tNedit.SetValue(custAccRec.ThisTimeDisDmdNrml);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.SetValue(custAccRec.ThisTimeRbtDmdNrml);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 預り金
            //this.Depo_tNedit.SetValue(custAccRec.ThisTimeDmdDepo);
            //this.FeeDepo_tNedit.SetValue(custAccRec.ThisTimeFeeDmdDepo);
            //this.DisDepo_tNedit.SetValue(custAccRec.ThisTimeDisDmdDepo);
            //this.RbtDepo_tNedit.SetValue(custAccRec.ThisTimeRbtDmdDepo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 各合計欄に合計金額を反映
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_ItdedOutTaxTotalLabel();     // 外税対象金額合計
            //update_OutTaxTotalLabel();          // 外税金額合計
            //update_ItdedInTaxTotalLabel();      // 内税対象金額合計
            //update_InTaxTotalLabel();           // 内税金額合計
            //update_ItdedTaxFreeTotalLabel();    // 非課税対象金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_SalesTotalLabel();           // 売上額合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_RetTotalLabel();             // 返品金額合計
            update_DisTotalLabel();             // 値引金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_PaymTotalLabel();            // 支払額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoPrcTotalLabel();         // 入金金額合計
            //update_FeeTotalLabel();             // 手数料額合計
            //update_DisTotalLabel();             // 値引額合計
            //update_RbtTotalLabel();             // リベート額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_NormalTotalLabel();          // 通常入金合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoTotalLabel();            // 預り金合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_ItdedPaymTotalLabel();   // 支払金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            // 相殺後売上外税対象額ラベルの反映
            this.update_ItdedOffsetOutTaxLabel();
            // 相殺後非課税対象額ラベルの反映
            this.update_ItdedOffsetTaxFreeLabel();
            // 相殺後売上合計ラベルの反映
            this.update_OfsThisTimeSalesTotalLabel();
            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 残高合計ラベルの反映
            this.update_BlTotalLabel();
            // 2009.01.06 Add <<<
		}

		/// <summary>鑑に売掛金額情報設定</summary>
        /// <param name="custAccRec">売掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 鑑画面に売掛金額情報を設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsAccRecToClaim_panel(CustAccRec custAccRec)
		{
			// 鑑に情報を反映
            // 2009.01.06 >>>
#if false
            // 前回情報
            this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(custAccRec.AcpOdrTtl3TmBfAccRec, true);
            this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(custAccRec.AcpOdrTtl2TmBfAccRec, true);
            this.TtlLMBl_Label.Text = Claim_panelDataFormat(custAccRec.LastTimeAccRec, true);

            this.TtlBf3TmBl_Label.Tag = custAccRec.AcpOdrTtl3TmBfAccRec;
            this.TtlBf2TmBl_Label.Tag = custAccRec.AcpOdrTtl2TmBfAccRec;
            this.TtlLMBl_Label.Tag = custAccRec.LastTimeAccRec;

            // 今回売上
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.TtlSales_Label.Text   = Claim_panelDataFormat(custAccRec.ThisTimeSales, true);
            this.TtlSales_Label.Text = Claim_panelDataFormat(custAccRec.OfsThisTimeSales, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.TtlTax_Label.Text     = Claim_panelDataFormat(custAccRec.ThisSalesTax, true);
            this.TtlTax_Label.Text = Claim_panelDataFormat(custAccRec.OfsThisSalesTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回支払
            //this.TtlPaym_Label.Text    = Claim_panelDataFormat(custAccRec.TtlIncDtbtTaxExc, true);
            //// 支払消費税
            //this.TtlPaymTax_Label.Text = Claim_panelDataFormat(custAccRec.TtlIncDtbtTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回入金
            //Int64 DepoTotal = custAccRec.ThisTimeDmdNrml    +       // 通常入金金額
            //                  custAccRec.ThisTimeFeeDmdNrml +       // 通常手数料額
            //                  custAccRec.ThisTimeDisDmdNrml +       // 通常値引額
            //                  custAccRec.ThisTimeRbtDmdNrml +       // 通常リベート額
            //                  custAccRec.ThisTimeDmdDepo    +       // 預り金入金金額
            //                  custAccRec.ThisTimeFeeDmdDepo +       // 預り金手数料額
            //                  custAccRec.ThisTimeDisDmdDepo +       // 預り金値引額
            //                  custAccRec.ThisTimeRbtDmdDepo;        // 預り金リベート額
            //this.TtlDepo_Label.Text   = Claim_panelDataFormat(DepoTotal, true);

            // 今回入金
            // 2008.11.25 modify start [8193]
            //Int64 DepoTotal = custAccRec.ThisTimeDmdNrml +       // 通常入金金額
            //custAccRec.ThisTimeFeeDmdNrml +       // 通常手数料額
            //custAccRec.ThisTimeDisDmdNrml ;       // 通常値引額
            Int64 DepoTotal = custAccRec.ThisTimeDmdNrml;       // 通常入金金額
            // 2008.11.25 modify end [8193]
            this.TtlDepo_Label.Text = Claim_panelDataFormat(DepoTotal, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            // 残高調整額
            this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(custAccRec.BalanceAdjust + custAccRec.TaxAdjust, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

            // 残高
            this.TtlBl_Label.Text = Claim_panelDataFormat(custAccRec.AfCalTMonthAccRec, true);
            //this.TtlBl_Label.Text = Claim_panelDataFormat(custAccRec.AfCalTMonthAccRec + custAccRec.BalanceAdjust + custAccRec.TaxAdjust, true);
#endif
            DataRow row = this._totalDisplayTable.Rows[0];

            // 残高情報
            row[BalanceDisplayTable.ct_Col_TOTAL3_BEF] = custAccRec.AcpOdrTtl3TmBfAccRec;
            row[BalanceDisplayTable.ct_Col_TOTAL2_BEF] = custAccRec.AcpOdrTtl2TmBfAccRec;
            row[BalanceDisplayTable.ct_Col_TOTAL1_BEF] = custAccRec.LastTimeAccRec;

            // 今回売上
            row[BalanceDisplayTable.ct_Col_THISTIMESALES] = custAccRec.OfsThisTimeSales;
            // 消費税
            row[BalanceDisplayTable.ct_Col_CONSTAX] = custAccRec.OfsThisSalesTax;
            // 今回入金
            Int64 depoTotal = custAccRec.ThisTimeDmdNrml;       // 通常入金金額
            row[BalanceDisplayTable.ct_Col_THISTIMEDEPO] = depoTotal;

            // 残高
            row[BalanceDisplayTable.ct_Col_ACCRECBLNCE] = custAccRec.AfCalTMonthAccRec;
            // 2009.01.06 <<<
        }

		/// <summary>画面に請求金額情報設定</summary>
        /// <param name="custDmdPrc">請求金額情報</param>
		/// <remarks>
		/// <br>Note       : 画面に請求金額情報を設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsDmdPrcToScreen(CustDmdPrc custDmdPrc)
		{
			// 計上日付
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
            // 請求書No
            this.BillNo_tNedit.SetInt(custDmdPrc.BillNo);
            // ADD 2009/06/23 ------<<<

			// 鑑に情報を反映
            // 2009.01.06 >>>
            //DetailsDmdPrcToClaim_panel(custDmdPrc);
            // 請求先指定時は画面表示金額の集計分を表示し、得意先指定時は退避している集計レコードから表示する
            DetailsDmdPrcToClaim_panel(( this._targetDivType == 1 ) ? this._custDmdPrcTotal : custDmdPrc);
            // 2009.01.06 <<<

	
			// ----- 詳細情報画面項目 -----
			// 前回残高情報
            this.LMBl_tNedit.SetValue(custDmdPrc.LastTimeDemand);
            this.Bf2TmBl_tNedit.SetValue(custDmdPrc.AcpOdrTtl2TmBfBlDmd);
            this.Bf3TmBl_tNedit.SetValue(custDmdPrc.AcpOdrTtl3TmBfBlDmd);

			// 売上・支払情報
            // 売上
            this.ItdedSalesOutTax_tNedit.SetValue(custDmdPrc.ItdedSalesOutTax);
            this.SalesOutTax_tNedit.SetValue(custDmdPrc.SalesOutTax);
            this.ItdedSalesInTax_tNedit.SetValue(custDmdPrc.ItdedSalesInTax);
            this.SalesInTax_tNedit.SetValue(custDmdPrc.SalesInTax);
            this.ItdedSalesTaxFree_tNedit.SetValue(custDmdPrc.ItdedSalesTaxFree);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            this.TtlItdedRetOutTax_tNedit.SetValue( -1 * custDmdPrc.TtlItdedRetOutTax );
            this.TtlRetOuterTax_tNedit.SetValue( -1 * custDmdPrc.TtlRetOuterTax );
            this.TtlItdedRetInTax_tNedit.SetValue( -1 * custDmdPrc.TtlItdedRetInTax );
            this.TtlRetInnerTax_tNedit.SetValue( -1 * custDmdPrc.TtlRetInnerTax );
            this.TtlItdedRetTaxFree_tNedit.SetValue( -1 * custDmdPrc.TtlItdedRetTaxFree );
            // 値引
            this.TtlItdedDisOutTax_tNedit.SetValue( -1 * custDmdPrc.TtlItdedDisOutTax );
            this.TtlDisOuterTax_tNedit.SetValue( -1 * custDmdPrc.TtlDisOuterTax );
            this.TtlItdedDisInTax_tNedit.SetValue( -1 * custDmdPrc.TtlItdedDisInTax );
            this.TtlDisInnerTax_tNedit.SetValue( -1 * custDmdPrc.TtlDisInnerTax );
            this.TtlItdedDisTaxFree_tNedit.SetValue( -1 * custDmdPrc.TtlItdedDisTaxFree );
            // 残高調整
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            //this.BalanceAdjust_tNedit.SetValue(custDmdPrc.BalanceAdjust);
            this.BalanceAdjust_tNedit.SetValue(custDmdPrc.BalanceAdjust);
            this.TaxAdjust_tNedit.SetValue(custDmdPrc.TaxAdjust);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

            //// 現金売上金額 (クリアする)
            //this.ThisCashSalePrice_tNedit.Clear();
            //this.ThisCashSaleTax_tNedit.Clear();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // 未決済金額 (クリアする)
            //this.NonStmntAppearance_tNedit.Clear();
            //this.NonStmntIsdone_tNedit.Clear();
            // 決済金額 (クリアする)
            //this.StmntAppearance_tNedit.Clear();
            //this.StmntIsdone_tNedit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 支払
            //this.ItdedPaymOutTax_tNedit.SetValue(custDmdPrc.ItdedPaymOutTax);
            //this.PaymentOutTax_tNedit.SetValue(custDmdPrc.PaymentOutTax);
            //this.ItdedPaymInTax_tNedit.SetValue(custDmdPrc.ItdedPaymInTax);
            //this.PaymentInTax_tNedit.SetValue(custDmdPrc.PaymentInTax);
            //this.ItdedPaymTaxFree_tNedit.SetValue(custDmdPrc.ItdedPaymTaxFree);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 支払
            //this.ItdedPaymOutTax_tNedit.SetValue( -1 * custDmdPrc.ItdedPaymOutTax );
            //this.PaymentOutTax_tNedit.SetValue( -1 * custDmdPrc.PaymentOutTax );
            //this.ItdedPaymInTax_tNedit.SetValue( -1 * custDmdPrc.ItdedPaymInTax );
            //this.PaymentInTax_tNedit.SetValue( -1 * custDmdPrc.PaymentInTax );
            //this.ItdedPaymTaxFree_tNedit.SetValue( -1 * custDmdPrc.ItdedPaymTaxFree );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // 2009.01.06 Add >>>
            // 相殺後消費税をセット
            this.OfsThisSalesTax_tNedit.SetValue(custDmdPrc.OfsThisSalesTax);
            this.OffsetOutTax_tNedit.SetValue(custDmdPrc.OffsetOutTax);
            // 2009.01.06 Add <<<

            // 入金情報
            // 通常入金
            //this.DepoNrml_tNedit.SetValue(custDmdPrc.ThisTimeDmdNrml);        // 2009.01.06 Del
            this.FeeNrml_tNedit.SetValue(custDmdPrc.ThisTimeFeeDmdNrml);
            this.DisNrml_tNedit.SetValue(custDmdPrc.ThisTimeDisDmdNrml);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.RbtNrml_tNedit.SetValue(custDmdPrc.ThisTimeRbtDmdNrml);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 預り金
            //this.Depo_tNedit.SetValue(custDmdPrc.ThisTimeDmdDepo);
            //this.FeeDepo_tNedit.SetValue(custDmdPrc.ThisTimeFeeDmdDepo);
            //this.DisDepo_tNedit.SetValue(custDmdPrc.ThisTimeDisDmdDepo);
            //this.RbtDepo_tNedit.SetValue(custDmdPrc.ThisTimeRbtDmdDepo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 売上伝票枚数
            this.SaleslSlipCount_tNedit.SetValue(custDmdPrc.SalesSlipCount);

            // 請求書発行日
            this.BillPrintDate_tDateEdit.SetDateTime( custDmdPrc.BillPrintDate );

            // 入金予定日
            this.ExpectedDepositDate_tDateEdit.SetDateTime(custDmdPrc.ExpectedDepositDate);
            
            // 回収条件
            if (custDmdPrc.CollectCond == 0) {
                // 得意先マスタ参照
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

            // 各合計欄に合計金額を反映
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_ItdedOutTaxTotalLabel();     // 外税対象金額合計
            //update_OutTaxTotalLabel();          // 外税金額合計
            //update_ItdedInTaxTotalLabel();      // 内税対象金額合計
            //update_InTaxTotalLabel();           // 内税金額合計
            //update_ItdedTaxFreeTotalLabel();    // 非課税対象金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_SalesTotalLabel();           // 売上額合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_RetTotalLabel();             // 返品金額合計
            update_DisTotalLabel();             // 値引金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_PaymTotalLabel();            // 支払額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoPrcTotalLabel();         // 入金金額合計
            //update_FeeTotalLabel();             // 手数料額合計
            //update_DisTotalLabel();             // 値引額合計
            //update_RbtTotalLabel();             // リベート額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            update_NormalTotalLabel();          // 通常入金合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //update_DepoTotalLabel();            // 預り金合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            update_ItdedPaymTotalLabel();       // 支払金額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            // 相殺後売上外税対象額ラベルの反映
            this.update_ItdedOffsetOutTaxLabel();
            // 相殺後非課税対象額ラベルの反映
            this.update_ItdedOffsetTaxFreeLabel();
            // 相殺後売上合計ラベルの反映
            this.update_OfsThisTimeSalesTotalLabel();
            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 残高合計ラベルの反映
            this.update_BlTotalLabel();
            // 2009.01.06 Add <<<
        }

        /// <summary>鑑画面に請求金額情報設定</summary>
        /// <param name="custDmdPrc">請求金額情報</param>
		/// <remarks>
		/// <br>Note       : 鑑画面に請求金額情報を設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void DetailsDmdPrcToClaim_panel(CustDmdPrc custDmdPrc)
		{
			// 鑑に情報を反映
            // 2009.01.06 >>>
#if false
            // 前回情報
            this.TtlBf3TmBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AcpOdrTtl3TmBfBlDmd, true);
            this.TtlBf2TmBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AcpOdrTtl2TmBfBlDmd, true);
            this.TtlLMBl_Label.Text = Claim_panelDataFormat(custDmdPrc.LastTimeDemand, true);

            this.TtlBf3TmBl_Label.Tag = custDmdPrc.AcpOdrTtl3TmBfBlDmd;
            this.TtlBf2TmBl_Label.Tag = custDmdPrc.AcpOdrTtl2TmBfBlDmd;
            this.TtlLMBl_Label.Tag = custDmdPrc.LastTimeDemand;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回売上
            //this.TtlSales_Label.Text   = Claim_panelDataFormat(custDmdPrc.ThisTimeSales, true);
            //// 消費税
            //this.TtlTax_Label.Text     = Claim_panelDataFormat(custDmdPrc.ThisSalesTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 今回売上
            this.TtlSales_Label.Text = Claim_panelDataFormat(custDmdPrc.OfsThisTimeSales, true);
            // 消費税
            this.TtlTax_Label.Text = Claim_panelDataFormat(custDmdPrc.OfsThisSalesTax, true);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回支払
            //this.TtlPaym_Label.Text    = Claim_panelDataFormat(custDmdPrc.TtlIncDtbtTaxExc, true);
            //// 支払消費税
            //this.TtlPaymTax_Label.Text = Claim_panelDataFormat(custDmdPrc.TtlIncDtbtTax, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 今回入金
            //Int64 DepoTotal = custDmdPrc.ThisTimeDmdNrml    +       // 通常入金金額
            //                  custDmdPrc.ThisTimeFeeDmdNrml +       // 通常手数料額
            //                  custDmdPrc.ThisTimeDisDmdNrml +       // 通常値引額
            //                  custDmdPrc.ThisTimeRbtDmdNrml +       // 通常リベート額
            //                  custDmdPrc.ThisTimeDmdDepo    +       // 預り金入金金額
            //                  custDmdPrc.ThisTimeFeeDmdDepo +       // 預り金手数料額
            //                  custDmdPrc.ThisTimeDisDmdDepo +       // 預り金値引額
            //                  custDmdPrc.ThisTimeRbtDmdDepo;        // 預り金リベート額
            //this.TtlDepo_Label.Text   = Claim_panelDataFormat(DepoTotal, true);
            // 今回入金
            // 2008.11.25 modify start [8193]
            //Int64 DepoTotal = custDmdPrc.ThisTimeDmdNrml +       // 通常入金金額
            //custDmdPrc.ThisTimeFeeDmdNrml +       // 通常手数料額
            //custDmdPrc.ThisTimeDisDmdNrml;       // 通常値引額
            Int64 DepoTotal = custDmdPrc.ThisTimeDmdNrml;       // 通常入金金額
            // 2008.11.25 modify end [8193]
            this.TtlDepo_Label.Text = Claim_panelDataFormat(DepoTotal, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
            // 残高調整
            //this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(custDmdPrc.BalanceAdjust,true);
            this.TtlBalanceAdjust_Label.Text = Claim_panelDataFormat(custDmdPrc.BalanceAdjust + custDmdPrc.TaxAdjust, true);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 残高
            this.TtlBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AfCalDemandPrice, true);
            //this.TtlBl_Label.Text = Claim_panelDataFormat(custDmdPrc.AfCalDemandPrice + custDmdPrc.BalanceAdjust + custDmdPrc.TaxAdjust, true);
#endif
            DataRow row = this._totalDisplayTable.Rows[0];

            // 残高情報
            row[BalanceDisplayTable.ct_Col_TOTAL3_BEF] = custDmdPrc.AcpOdrTtl3TmBfBlDmd;
            row[BalanceDisplayTable.ct_Col_TOTAL2_BEF] = custDmdPrc.AcpOdrTtl2TmBfBlDmd;
            row[BalanceDisplayTable.ct_Col_TOTAL1_BEF] = custDmdPrc.LastTimeDemand;

            // 今回売上
            row[BalanceDisplayTable.ct_Col_THISTIMESALES] = custDmdPrc.OfsThisTimeSales;
            // 消費税
            row[BalanceDisplayTable.ct_Col_CONSTAX] = custDmdPrc.OfsThisSalesTax;
            // 今回入金
            Int64 depoTotal = custDmdPrc.ThisTimeDmdNrml;       // 通常入金金額
            row[BalanceDisplayTable.ct_Col_THISTIMEDEPO] = depoTotal;

            // 残高
            row[BalanceDisplayTable.ct_Col_ACCRECBLNCE] = custDmdPrc.AfCalDemandPrice;
            // 2009.01.06 <<<
		}

        /// <summary>鑑画面の再計算処理</summary>
		/// <remarks>
		/// <br>Note       : 入力された項目で鑑情報を再計算します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void upDateClaim_PanelTextData()
		{
			// 売掛
			if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
                CustAccRec custAccRec = this._editCustAccRec;
                ScreenToCustAccRec(ref custAccRec);
                getKinSetInfo_Acc(ref custAccRec);
                // かがみに情報を反映する
                // 2009.01.06 >>>
                //DetailsAccRecToClaim_panel(custAccRec);
                // 請求先指定時は画面表示金額の集計分を表示し、得意先指定時は退避している集計レコードから表示する
                DetailsAccRecToClaim_panel(( this._targetDivType == 1 ) ? this._custAccRecTotal : custAccRec);

                // 2009.01.06 <<<
            }
			else
			{
                CustDmdPrc custDmdPrc = this._editCustDmdPrc;
                ScreenToCustDmdPrc(ref custDmdPrc);
                getKinSetInfo_Dmd(ref custDmdPrc);
                // かがみに情報を反映する
                // 2009.01.06 >>>
                //DetailsDmdPrcToClaim_panel(custDmdPrc);
                // 請求先指定時は画面表示金額の集計分を表示し、得意先指定時は退避している集計レコードから表示する
                DetailsDmdPrcToClaim_panel(( this._targetDivType == 1 ) ? this._custDmdPrcTotal : custDmdPrc);
                // 2009.01.06 <<<
			}
		}

		/// <summary>売掛金額KINSET処理</summary>
		/// <param name="custAccRec">売掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 売掛金額のKINSET処理を実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
            Int64 TotalDepo = custAccRec.ThisTimeDmdNrml;       // 入金合計は今回入金金額をそのまま使用する
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

        /// <summary>請求金額KINSET処理</summary>
		/// <param name="custDmdPrc">請求金額情報</param>
		/// <remarks>
		/// <br>Note       : 請求金額のKINSET処理を実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
            Int64 TotalDepo = custDmdPrc.ThisTimeDmdNrml;   // 入金合計は今回入金金額をそのまま使用する
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

		/// <summary>画面情報を売掛金額に反映処理</summary>
		/// <param name="custAccRec">売掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 画面項目情報を売掛金額に設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void ScreenToCustAccRec(ref CustAccRec custAccRec)
		{
            custAccRec.EnterpriseCode       = this._enterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 得意先
            custAccRec.CustomerCode = Int32.Parse(this.customerCode_Label.Text);
            custAccRec.CustomerName = this.CustomerName_Label.Text;
            custAccRec.CustomerName2 = this.CustomerName2_Label.Text;
            custAccRec.CustomerSnm = this.CustomerSnm_Label.Text;
            // 請求先
            custAccRec.ClaimCode = Int32.Parse(this.claimCode_Label.Text);
            custAccRec.ClaimName = this.ClaimName_Label.Text;
            custAccRec.ClaimName2 = this.ClaimName2_Label.Text;
            custAccRec.ClaimSnm = this.ClaimSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 計上日付
			if ( this.AddUpADate_tDateEdit.Enabled == true )
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //custAccRec.AddUpYearMonth = this.AddUpADate_tDateEdit.GetLongDate();
                //custAccRec.AddUpDate      = this.AddUpADate_tDateEdit.GetLongDate();
                custAccRec.AddUpYearMonth = this.AddUpADate_tDateEdit.GetDateTime();
                custAccRec.AddUpDate = this.AddUpADate_tDateEdit.GetDateTime();                
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
			// 売上
			custAccRec.ItdedSalesOutTax     = (Int64)this.ItdedSalesOutTax_tNedit.GetValue();
			custAccRec.SalesOutTax          = (Int64)this.SalesOutTax_tNedit.GetValue();
            custAccRec.ItdedSalesInTax      = (Int64)this.ItdedSalesInTax_tNedit.GetValue();
            custAccRec.SalesInTax           = (Int64)this.SalesInTax_tNedit.GetValue();
            custAccRec.ItdedSalesTaxFree    = (Int64)this.ItdedSalesTaxFree_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            custAccRec.TtlItdedRetOutTax = -1 * (Int64)this.TtlItdedRetOutTax_tNedit.GetValue();
            custAccRec.TtlRetOuterTax = -1 * (Int64)this.TtlRetOuterTax_tNedit.GetValue();
            custAccRec.TtlItdedRetInTax = -1 * (Int64)this.TtlItdedRetInTax_tNedit.GetValue();
            custAccRec.TtlRetInnerTax = -1 * (Int64)this.TtlRetInnerTax_tNedit.GetValue();
            custAccRec.TtlItdedRetTaxFree = -1 * (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue();
            // 値引
            custAccRec.TtlItdedDisOutTax = -1 * (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();
            custAccRec.TtlDisOuterTax = -1 * (Int64)this.TtlDisOuterTax_tNedit.GetValue();
            custAccRec.TtlItdedDisInTax = -1 * (Int64)this.TtlItdedDisInTax_tNedit.GetValue();
            custAccRec.TtlDisInnerTax = -1 * (Int64)this.TtlDisInnerTax_tNedit.GetValue();
            custAccRec.TtlItdedDisTaxFree = -1 * (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();
            // 残高調整
            custAccRec.BalanceAdjust        = (Int64)this.BalanceAdjust_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            custAccRec.TaxAdjust = (Int64)this.TaxAdjust_tNedit.GetValue();
            custAccRec.SalesSlipCount = (Int32)this.SaleslSlipCount_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // 未決済金額
            //custAccRec.NonStmntAppearance   = (Int64)this.NonStmntAppearance_tNedit.GetValue();
            //custAccRec.NonStmntIsdone       = (Int64)this.NonStmntIsdone_tNedit.GetValue();
            // 決済金額
            //custAccRec.StmntAppearance      = (Int64)this.StmntAppearance_tNedit.GetValue();
            //custAccRec.StmntIsdone          = (Int64)this.StmntIsdone_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //// 現金売上
            //custAccRec.ThisCashSalePrice    = (Int64)this.ThisCashSalePrice_tNedit.GetValue();
            //custAccRec.ThisCashSaleTax      = (Int64)this.ThisCashSaleTax_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 支払
            //custAccRec.ItdedPaymOutTax      = (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //custAccRec.PaymentOutTax        = (Int64)this.PaymentOutTax_tNedit.GetValue();
            //custAccRec.ItdedPaymInTax       = (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //custAccRec.PaymentInTax         = (Int64)this.PaymentInTax_tNedit.GetValue();
            //custAccRec.ItdedPaymTaxFree     = (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 入金
            //custAccRec.ThisTimeDmdNrml      = (Int64)this.DepoNrml_tNedit.GetValue();     // 2009.01.06 Del
            custAccRec.ThisTimeFeeDmdNrml = (Int64)this.FeeNrml_tNedit.GetValue();
			custAccRec.ThisTimeDisDmdNrml   = (Int64)this.DisNrml_tNedit.GetValue();
            // 2009.01.06 Add >>>
            object value = this._depositDataTable.Compute(string.Format("SUM({0})", DepositRelDataAcs.ctDeposit), string.Empty);
            Int64 total = ( value is DBNull ) ? 0 : (Int64)value;
            custAccRec.ThisTimeDmdNrml = total + custAccRec.ThisTimeFeeDmdNrml + custAccRec.ThisTimeDisDmdNrml;

            // 相殺今回売上消費税
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
            // 支払
            //custAccRec.ItdedPaymOutTax = -1 * (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //custAccRec.PaymentOutTax = -1 * (Int64)this.PaymentOutTax_tNedit.GetValue();
            //custAccRec.ItdedPaymInTax = -1 * (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //custAccRec.PaymentInTax = -1 * (Int64)this.PaymentInTax_tNedit.GetValue();
            //custAccRec.ItdedPaymTaxFree = -1 * (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

			// かがみ情報
			// 前回情報
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

        /// <summary>画面情報を請求金額に反映処理</summary>
		/// <param name="custDmdPrc">請求金額情報</param>
		/// <remarks>
		/// <br>Note       : 画面項目情報を請求金額に設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void ScreenToCustDmdPrc(ref CustDmdPrc custDmdPrc)
		{
            custDmdPrc.EnterpriseCode      = this._enterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 得意先
            custDmdPrc.CustomerCode = Int32.Parse(this.customerCode_Label.Text);
            custDmdPrc.CustomerName = this.CustomerName_Label.Text;
            custDmdPrc.CustomerName2 = this.CustomerName2_Label.Text;
            custDmdPrc.CustomerSnm = this.CustomerSnm_Label.Text;
            // 請求先
            custDmdPrc.ClaimCode = Int32.Parse(this.claimCode_Label.Text);
            custDmdPrc.ClaimName = this.ClaimName_Label.Text;
            custDmdPrc.ClaimName2 = this.ClaimName2_Label.Text;
            custDmdPrc.ClaimSnm = this.ClaimSnm_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 計上日付
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
            // 請求書No
            custDmdPrc.BillNo = this.BillNo_tNedit.GetInt();
            // ADD 2009/06/23 ------<<<
            
			// 売上
			custDmdPrc.ItdedSalesOutTax    = (Int64)this.ItdedSalesOutTax_tNedit.GetValue();
			custDmdPrc.SalesOutTax         = (Int64)this.SalesOutTax_tNedit.GetValue();
            custDmdPrc.ItdedSalesInTax     = (Int64)this.ItdedSalesInTax_tNedit.GetValue();
            custDmdPrc.SalesInTax          = (Int64)this.SalesInTax_tNedit.GetValue();
            custDmdPrc.ItdedSalesTaxFree   = (Int64)this.ItdedSalesTaxFree_tNedit.GetValue();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 返品
            custDmdPrc.TtlItdedRetOutTax = -1 * (Int64)this.TtlItdedRetOutTax_tNedit.GetValue();
            custDmdPrc.TtlRetOuterTax = -1 * (Int64)this.TtlRetOuterTax_tNedit.GetValue();
            custDmdPrc.TtlItdedRetInTax = -1 * (Int64)this.TtlItdedRetInTax_tNedit.GetValue();
            custDmdPrc.TtlRetInnerTax = -1 * (Int64)this.TtlRetInnerTax_tNedit.GetValue();
            custDmdPrc.TtlItdedRetTaxFree = -1 * (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue();
            // 値引
            custDmdPrc.TtlItdedDisOutTax = -1 * (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();
            custDmdPrc.TtlDisOuterTax = -1 * (Int64)this.TtlDisOuterTax_tNedit.GetValue();
            custDmdPrc.TtlItdedDisInTax = -1 * (Int64)this.TtlItdedDisInTax_tNedit.GetValue();
            custDmdPrc.TtlDisInnerTax = -1 * (Int64)this.TtlDisInnerTax_tNedit.GetValue();
            custDmdPrc.TtlItdedDisTaxFree = -1 * (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();
            // 残高調整
            custDmdPrc.BalanceAdjust       = (Int64)this.BalanceAdjust_tNedit.GetValue();
            custDmdPrc.TaxAdjust = (Int64)this.TaxAdjust_tNedit.GetValue();
            // 売上伝票枚数
            custDmdPrc.SalesSlipCount     = (Int32)this.SaleslSlipCount_tNedit.GetValue();

            // 請求書発行日
            custDmdPrc.BillPrintDate       = this.BillPrintDate_tDateEdit.GetDateTime();

            // 入金予定日
            // --- CHG 2009/01/28 障害ID:10447対応------------------------------------------------------>>>>>
            //custDmdPrc.ExpectedDepositDate = this.ExpectedDepositDate_tDateEdit.GetDateTime();
            if (this._dmdPrcDataIndex < 0)
            {
                // 得意先マスタ参照
                CustomerInfo customerInfo;
                this._customerInfoAcs.ReadCacheMemoryData(out customerInfo, this._enterpriseCode, this._targetCustomerCode);

                DateTime collectMoneyDate = custDmdPrc.AddUpDate;
                switch (customerInfo.CollectMoneyCode) // 0:当月,1:翌月,2:翌々月,3翌々々月
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
                // 28日以降は末日とする
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
                custDmdPrc.ExpectedDepositDate = collectMoneyDate;　// 入金予定日
            }
            else
            {
                custDmdPrc.ExpectedDepositDate = this.ExpectedDepositDate_tDateEdit.GetDateTime();
            }
            // --- CHG 2009/01/28 障害ID:10447対応------------------------------------------------------<<<<<

            // 回収条件
            custDmdPrc.CollectCond         = (Int32)this.CollectCondValue_tNedit.GetValue();


            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 支払
            //custDmdPrc.ItdedPaymOutTax     = (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //custDmdPrc.PaymentOutTax       = (Int64)this.PaymentOutTax_tNedit.GetValue();
            //custDmdPrc.ItdedPaymInTax      = (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //custDmdPrc.PaymentInTax        = (Int64)this.PaymentInTax_tNedit.GetValue();
            //custDmdPrc.ItdedPaymTaxFree    = (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 入金
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
            // 支払
            //custDmdPrc.ItdedPaymOutTax = -1 * (Int64)this.ItdedPaymOutTax_tNedit.GetValue();
            //custDmdPrc.PaymentOutTax = -1 * (Int64)this.PaymentOutTax_tNedit.GetValue();
            //custDmdPrc.ItdedPaymInTax = -1 * (Int64)this.ItdedPaymInTax_tNedit.GetValue();
            //custDmdPrc.PaymentInTax = -1 * (Int64)this.PaymentInTax_tNedit.GetValue();
            //custDmdPrc.ItdedPaymTaxFree = -1 * (Int64)this.ItdedPaymTaxFree_tNedit.GetValue();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

			// かがみ情報
			// 前回情報
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
				result = false;
			}
    		// 日付の入力チェック追加 
			else if (( this.AddUpADate_tDateEdit.LongDate != 0  ) && 
                     (TDateTime.IsAvailableDate(TDateTime.LongDateToDateTime(this.AddUpADate_tDateEdit.LongDate)) == false))
			{
				control = AddUpADate_tDateEdit;
				message = this.AddUpADate_Tittle_Label.Text + "が不正です。正しい日付を入力して下さい。";
				result = false;
			}
			else
			{
                DataRow[] rows = this.GetDepositRows();         // 2009.01.06 Add
                
				// 項目チェック
				if (
					// 残高
                    // 2009.01.06 Del >>>
                    //((Int64)this.TtlBf3TmBl_Label.Tag         == 0) && 
                    //((Int64)this.TtlBf2TmBl_Label.Tag         == 0) &&
                    //((Int64)this.TtlLMBl_Label.Tag            == 0) &&
                    // 2009.01.06 Del <<<
                    // 売上
					(this.ItdedSalesOutTax_tNedit.GetValue()  == 0) &&
					(this.SalesOutTax_tNedit.GetValue()       == 0) &&
                    (this.ItdedSalesInTax_tNedit.GetValue()   == 0) &&
                    (this.SalesInTax_tNedit.GetValue()        == 0) &&
                    (this.ItdedSalesTaxFree_tNedit.GetValue() == 0) &&
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // 返品
                    ( this.TtlItdedRetOutTax_tNedit.GetValue()  == 0 ) &&
                    ( this.TtlRetOuterTax_tNedit.GetValue()     == 0 ) &&
                    ( this.TtlItdedRetInTax_tNedit.GetValue()   == 0 ) &&
                    ( this.TtlRetInnerTax_tNedit.GetValue()     == 0 ) &&
                    ( this.TtlItdedRetTaxFree_tNedit.GetValue() == 0 ) &&
                    // 値引
                    ( this.TtlItdedDisOutTax_tNedit.GetValue()  == 0 ) &&
                    ( this.TtlDisOuterTax_tNedit.GetValue()     == 0 ) &&
                    ( this.TtlItdedDisInTax_tNedit.GetValue()   == 0 ) &&
                    ( this.TtlDisInnerTax_tNedit.GetValue()     == 0 ) &&
                    ( this.TtlItdedDisTaxFree_tNedit.GetValue() == 0 ) &&
                    // 残高
                    ( this.Bf3TmBl_tNedit.GetValue() == 0 ) &&
                    ( this.Bf2TmBl_tNedit.GetValue() == 0 ) &&
                    ( this.LMBl_tNedit.GetValue() == 0 ) &&
                    // 残高調整
                    ( this.BalanceAdjust_tNedit.GetValue() == 0 ) &&
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
                    ( this.TaxAdjust_tNedit.GetValue() == 0) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
                    //// 現金売上
                    //( this.ThisCashSalePrice_tNedit.GetValue() == 0) &&
                    //( this.ThisCashSaleTax_tNedit.GetValue() == 0) &&

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
                    // 未決済金額
                    //( this.NonStmntAppearance_tNedit.GetValue() == 0 ) &&
                    //( this.NonStmntIsdone_tNedit.GetValue() == 0 ) &&
                    // 決済金額
                    //( this.StmntAppearance_tNedit.GetValue() == 0 ) &&
                    //( this.StmntIsdone_tNedit.GetValue() == 0 ) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 支払
                    //(this.ItdedPaymOutTax_tNedit.GetValue()   == 0) &&
                    //(this.PaymentOutTax_tNedit.GetValue()     == 0) &&
                    //(this.ItdedPaymInTax_tNedit.GetValue()    == 0) &&
                    //(this.PaymentInTax_tNedit.GetValue()      == 0) &&
                    //(this.ItdedPaymTaxFree_tNedit.GetValue()  == 0) &&
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // 通常入金
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
                    //// 預り金入金
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
					message = "全ての金額が未入力での更新はできません。";
					result = false;
				}
			}
		
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

			// 更新前チェック処理
			// 画面入力情報不正チェック処理
			if (!CheckScreenData(ref control, ref errmsg))
			{
				TMsgDisp.Show(this,										// 親ウィンドウフォーム
					          emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
					          "MAKAU09110U",						    // アセンブリＩＤまたはクラスＩＤ
					          errmsg,									// 表示するメッセージ 
					          0,										// ステータス値
					          MessageBoxButtons.OK);					// 表示するボタン

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
			// オプションが存在しない場合は、全社計も更新する
			if (( this.Opt_Section == false ) && ( result  == true )&& (this._autoAllUpDateMode == true ))
			{
				// 全社計を取得し、画面情報を反映する
				CustAccRec allAccRec = new CustAccRec();
				CustDmdPrc allDmdPrc = new CustDmdPrc(); 
				
				// 拠点無しの時ように全社計を取得し、画面情報を反映する
				ReadAllSecCodeAndSetScreenInformation(ref allAccRec, ref allDmdPrc, true);
				
				result = SaveDetailsProc( ref allAccRec, ref allDmdPrc );
			}
#endif 
			if ( result  == true )
			{
				if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
				{
					// データ再読み込み処理
					AccRec_Data_Search(this._targetClaimCode,this._targetCustomerCode, this._sectionCode, this._targetDivType);
					this._accRecIndexBuf = -2;
				}
    			// 請求金額
				else
				{
					// データ再読み込み処理
					DmdRec_Data_Search(this._targetClaimCode, this._targetCustomerCode, this._sectionCode, this._targetDivType);
					this._dmdPrcIndexBuf = -2;
				}
			}
			return result;
		}

		/// <summary>保存処理</summary>
		/// <param name="custAccRec">売掛金額情報</param>
		/// <param name="custDmdPrc">請求金額情報</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の保存処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
		
			// 売掛金額
			if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
                // 2009.01.06 >>>
                //// 必須入力項目の確認
                //WriteInputDataCheck_ACC(ref custAccRec );
                //// (最終レコード検索して更新する)
                //status = this._custAccRecDmdPrcAcs.WriteCustAccRec(custAccRec, out errmsg);
                try
                {
                    // 必須入力項目の確認
                    WriteInputDataCheck_ACC(ref custAccRec );
                    // (最終レコード検索して更新する)
                    status = this._custAccRecDmdPrcAcs.WriteCustAccRec(custAccRec, accRecDepoTotalList, out errmsg);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                // 2009.01.06 <<<
            }
			// 請求金額
			else
			{
                try
                {
                    // 必須入力項目の確認
                    WriteInputDataCheck_DMD(ref custDmdPrc);
                    // (最終レコード検索して更新する)
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
                                  "MAKAU09110U",							      // アセンブリＩＤまたはクラスＩＤ
                                  this.Text,									  // プログラム名称
                                  "Save_Button_Click",							  // 処理名称
                                  TMsgDisp.OPE_UPDATE,							  // オペレーション
                                  "既に同一の計上日でデータが存在するため新規では作成できません。",   // 表示するメッセージ 
                                  status,										  // ステータス値
                                  this._custAccRecDmdPrcAcs,					  // エラーが発生したオブジェクト
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
						          "MAKAU09110U",							  // アセンブリＩＤまたはクラスＩＤ
						          this.Text,									  // プログラム名称
						          "Save_Button_Click",							  // 処理名称
						          TMsgDisp.OPE_UPDATE,							  // オペレーション
						          errmsg,						                  // 表示するメッセージ 
						          status,										  // ステータス値
                                  this._custAccRecDmdPrcAcs,					  // エラーが発生したオブジェクト
						          MessageBoxButtons.OK,							  // 表示するボタン
						          MessageBoxDefaultButton.Button1);			  	  // 初期表示ボタン
					this.DialogResult = DialogResult.Cancel;
					break;
				}
			}

			return result;
		}

        /// <summary>全拠点計の取得及び画面情報反映処理</summary>
		/// <param name="allAccRec">売掛金額情報</param>
		/// <param name="allDmdPrc">請求金額情報</param>
		/// <param name="reflectedMode">画面情報を反映するかの有無</param>
		/// <remarks>
		/// <br>Note       : 画面入力情報の保存処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
					//画面情報を反映し更新する
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
					//画面情報を反映し更新する
					ScreenToCustDmdPrc(ref allDmdPrc);
					getKinSetInfo_Dmd(ref allDmdPrc);
				}
			}
		}

        /// <summary>必須入力項目等のチェック処理</summary>
		/// <param name="accRec">売掛金額情報</param>
		/// <remarks>
		/// <br>Note       : 保存で必要な必須項目をセットします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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

        /// <summary>必須入力項目等のチェック処理</summary>
		/// <param name="dmdPrc">請求金額情報</param>
		/// <remarks>
		/// <br>Note       : 保存で必要な必須項目をセットします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
            // 「得意先」指定時は、実績計上拠点、得意先コードは必須
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

            result = DeleteDetailsProc(this._custAccRecClone, this._custDmdPrcClone);

#if false
            // オプションが存在しない場合は、全社計も更新する
            if ((this.Opt_Section == false) && (result == true) && (this._autoAllUpDateMode == true))
            {
                // 全社計を取得し、画面情報を反映する
                CustAccRec allAccRec = new CustAccRec();
                CustDmdPrc allDmdPrc = new CustDmdPrc();

                // 拠点無しの時ように全社計を取得し、画面情報を反映する
                ReadAllSecCodeAndSetScreenInformation(ref allAccRec, ref allDmdPrc, false);

                result = DeleteDetailsProc(allAccRec, allDmdPrc);
            }
#endif
            if (result == true)
            {
                if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
                {
                    // データ再読み込み処理
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                    //AccRec_Data_Search(this._condClaimCode, this._condCustomerCode, this._condSectionCode, this._targetDivType);
                    AccRec_Data_Search(this._targetClaimCode, this._targetCustomerCode, this._sectionCode, this._targetDivType);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
                    this._accRecIndexBuf = -2;
                }
                // 請求金額
                else
                {
                    // データ再読み込み処理
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                    //DmdRec_Data_Search(this._condClaimCode, this._condCustomerCode, this._condSectionCode, this._targetDivType);
                    DmdRec_Data_Search(this._targetClaimCode, this._targetCustomerCode, this._sectionCode,  this._targetDivType);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
                    this._dmdPrcIndexBuf = -2;
                }
            }
            return result;
        }

        /// <summary>削除詳細処理</summary>
		/// <param name="custAccRec">売掛金額情報</param>
		/// <param name="custDmdPrc">請求金額情報</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面情報で指定された情報の削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private bool DeleteDetailsProc(CustAccRec custAccRec, CustDmdPrc custDmdPrc)
        {
            bool result = false;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // 売掛金額(最終レコード検索して更新する)
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                status = this._custAccRecDmdPrcAcs.DeleteCustAccRec(custAccRec);
            }
            // 請求金額(最終レコード検索して更新する)
            else
            {
                status = this._custAccRecDmdPrcAcs.DeleteCustDmdPrc(custDmdPrc);
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
                                      "MAKAU09110U",							  // アセンブリＩＤまたはクラスＩＤ
                                      this.Text,									  // プログラム名称
                                      "Delete_Button_Click",						  // 処理名称
                                      TMsgDisp.OPE_UPDATE,							  // オペレーション
                                      "登録に失敗しました。",						  // 表示するメッセージ 
                                      status,										  // ステータス値
                                      this._custAccRecDmdPrcAcs,					  // エラーが発生したオブジェクト
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
		// 内部メソッド（売掛・請求情報Clone作成 & Equals）
		// ===================================================================================== //
		#region  Privete Methods AccPrcAndDmdPrcClone&Equals

		/// <summary>売掛金額のクローン作成処理</summary>
		/// <param name="targetCustAccRec">売掛金額情報</param>
		/// <returns>売掛金額情報</returns>
		/// <remarks>
		/// <br>Note       : 渡された売掛金額情報のクローンデータを作成します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private CustAccRec custAccRec_Clone(CustAccRec targetCustAccRec)
		{
            CustAccRec custAccRec = new CustAccRec();
			// データクラスのTypeオブジェクトを取得する
            Type myType2 = typeof(CustAccRec);
			// データクラスのプロパティを取得
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

		/// <summary>請求金額のクローン作成処理</summary>
		/// <param name="targetCustDmdPrc">請求金額情報</param>
		/// <returns>請求金額情報</returns>
		/// <remarks>
		/// <br>Note       : 渡された請求金額情報のクローンデータを作成します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private CustDmdPrc custdmdRec_Clone(CustDmdPrc targetCustDmdPrc)
		{
			CustDmdPrc custDmdPrc = new CustDmdPrc();
			
			// データクラスのTypeオブジェクトを取得する
            Type myType2 = typeof(CustDmdPrc);
			// データクラスのプロパティを取得
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

		/// <summary>売掛金額情報比較処理</summary>
		/// <param name="targetCustAccRec">売掛金額情報A</param>
		/// <param name="compCustAccRec">売掛金額情報B</param>
		/// <returns>チェック結果（true:同じ／false:異なる）</returns>
		/// <remarks>
		/// <br>Note       : 売掛金額情報Aと売掛金額情報Bの内容を比較します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private  bool custAccRec_Equals(CustAccRec targetCustAccRec, CustAccRec compCustAccRec)
		{
			bool result = true;
			// データクラスのTypeオブジェクトを取得する
			Type myType2 = typeof(CustAccRec);
			// データクラスのプロパティを取得
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

		/// <summary>請求金額情報比較処理</summary>
		/// <param name="targetCustDmdPrc">請求金額情報A</param>
		/// <param name="compCustDmdPrc">請求金額情報B</param>
		/// <returns>チェック結果（true:同じ／false:異なる）</returns>
		/// <remarks>
		/// <br>Note       : 請求金額情報Aと請求金額情報Bの内容を比較します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private  bool custDmdPrc_Equals(CustDmdPrc targetCustDmdPrc, CustDmdPrc compCustDmdPrc)
		{
			bool result = true;
			// データクラスのTypeオブジェクトを取得する
			Type myType2 = typeof(CustDmdPrc);
			// データクラスのプロパティを取得
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
		// コントロールイベント
		// ===================================================================================== //
		#region Control Events
		# endregion

		// ===================================================================================== //
		// 画面イベント
		// ===================================================================================== //
		# region Control Form Events

        /// <summary>Form.Load イベント(MAKAU09110UB)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09110UB_Load(object sender, System.EventArgs e)
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.28 TOKUNAGA ADD START
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                this.DemandSalesInfo_Title_Label.Text = "売掛情報";
            }
            else
            {
                this.DemandSalesInfo_Title_Label.Text = "請求情報";
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.28 TOKUNAGA ADD END

            // 2009.01.06 Add >>>
            //this.uGrid_DemandInfo.DataSource = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCRECTOTAL_TITLE];
            this.uGrid_DemandInfo.DataSource = this._totalDisplayTable;
            this.SettingDemandInfoGrid();

            this.ClearDepositDataTable();
            // 2009.01.06 Add <<<
    	}

		/// <summary>VisibleChanged イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09110UB_VisibleChanged(object sender, System.EventArgs e)
		{
			if (this.Visible == false)
			{
				return;
			}

			// ターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._targetTableName == CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE)
			{
				// ターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
				if ((this._accRecIndexBuf  == this._accRecDataIndex) &&
					(this._customerCodeBuf == this._targetCustomerCode) &&
					(this._targetTableBuf  == this._targetTableName))
				{
					return;
				}
			}
			if (this._targetTableName == CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE)
			{
				// ターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
				if ((this._dmdPrcIndexBuf  == this._dmdPrcDataIndex) &&
					(this._customerCodeBuf == this._targetCustomerCode)	&&
					(this._targetTableBuf  == this._targetTableName))
				{
					return;
				}
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE) ) {
                // <売掛情報固有項目> を表示
                //this.CustAccRec_panel.Visible = true;
                // <請求情報固有項目> を非表示
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
                // <売掛情報固有項目> を非表示
                //this.CustAccRec_panel.Visible = false;
                // <請求情報固有項目> を表示
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
            // なんでクリアしてるの？
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
		private void MAKAU09110UB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            // 2009.01.06 Add >>>
            switch (e.PrevCtrl.Name)
            {
                // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
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
                // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END
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
                            // Shiftキーが押されてない場合
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

                    // フォーカスを入れることができない場合の処理
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
                            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            if (_modeFlg)
                            {
                                AddUpADate_tDateEdit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

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

            this._invokerForm.Focus();
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
            this._invokerForm.Focus();
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
                                                "MAKAU09110U",
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

			if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
				// 画面表示		
				DetailsAccRecToScreen(this._custAccRecClone);
			}
			else
			{
				// 画面表示		
				DetailsDmdPrcToScreen(this._custDmdPrcClone);
			}
			// 画面初期化
			Initial_Timer.Enabled = true;
		}
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
				if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
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
			// 売掛
			//---------------------------------
			// 既存データをチェックする
			if ( this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
			{
				// データが１件の場合、前回データが存在しないので取得はできないため、終了
                if ((this._logicalDeleteMode != -1) && (this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Rows.Count == 1)) return;
			
				// ソートして検索開始日付より前の情報を取得する
                string selectCmd = REC_ADDUPDATE_TITLE + " < " + this.AddUpADate_tDateEdit.GetLongDate().ToString();
                DataRow[] dataRows = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE].Select(selectCmd, viewGridSortDefault);

                // 最新のレコードを取得
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
                
                //取得した前回残と当月情報を元に_KINSETを実行
				upDateClaim_PanelTextData();
			}

            //---------------------------------
			// 請求
			//---------------------------------
			else
			{
				// データが１件の場合、前回データが存在しないので取得はできないため、終了
                if ((this._logicalDeleteMode != -1) && (this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Rows.Count == 1)) return;

				// ソートして検索開始日付より前の情報を取得する
                string selectCmd = REC_ADDUPDATE_TITLE + " < " + this.AddUpADate_tDateEdit.GetLongDate().ToString();
                DataRow[] dataRows = this.Bind_DataSet.Tables[CustAccRecDmdPrcAcs.TBL_CUSTDMDPRC_TITLE].Select(selectCmd, viewGridSortDefault);

                // 最新のレコードを取得
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
                
                //取得した前回残と当月情報を元に_KINSETを実行
				upDateClaim_PanelTextData();
			}
		}
#endif
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

        /// <summary>Leave イベント(売上)</summary>
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

            // 売上合計金額ラベルの反映
            update_SalesTotalLabel();

            // 2009.01.06 Add >>>
            // 相殺後売上外税対象額ラベルの反映
            if (sender == this.ItdedSalesOutTax_tNedit)
            {
                this.update_ItdedOffsetOutTaxLabel();
            }
            // 相殺後非課税対象額ラベルの反映
            else if (sender == this.ItdedSalesTaxFree_tNedit)
            {
                this.update_ItdedOffsetTaxFreeLabel();
            }
            // 相殺後売上合計ラベルの反映
            this.update_OfsThisTimeSalesTotalLabel();
            // 税込み合計ラベルの反映
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

            // 2009.01.06 Add >>>
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
            // 2009.01.06 Add <<<

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

            // 2009.01.06 Add >>>
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
            // 2009.01.06 Add <<<


            // 鑑への反映
            upDateClaim_PanelTextData();
        }
        /// <summary>Leave イベント(支払)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがアクティブでなくなった時に発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private void ItdedPaym_tNedit_Leave( object sender, EventArgs e )
        {
            if ( this._changeFlg == false ) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if ( ctrlTNedit == null ) return;

            // 相殺仕入金額ラベルの反映
            update_ItdedPaymTotalLabel();

            // 鑑への反映
            upDateClaim_PanelTextData();
        }

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

        /// <summary>Leave イベント(通常入金)</summary>
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

            // 入金合計金額ラベルの反映
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
        //    //// 入金合計金額ラベルの反映
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
            //this._editCustAccRec.AfCalTMonthAccRec
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

            // 2009.01.06 >>>
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
                this._totalDisplayTable.Rows[0][BalanceDisplayTable.ct_Col_TOTAL1_BEF] = (Int64)acpOdrTtlLMBl;
            }
            // 2回以前残高
            if (sender == Bf2TmBl_tNedit)
            {
                double acpOdrTtlLMBl2 = this.Bf2TmBl_tNedit.GetValue();
                this._totalDisplayTable.Rows[0][BalanceDisplayTable.ct_Col_TOTAL2_BEF] = (Int64)acpOdrTtlLMBl2;
            }
            // 3回以前残高
            if (sender == Bf3TmBl_tNedit)
            {
                double acpOdrTtlLMBl3 = this.Bf3TmBl_tNedit.GetValue();
                this._totalDisplayTable.Rows[0][BalanceDisplayTable.ct_Col_TOTAL3_BEF] = (Int64)acpOdrTtlLMBl3;
            }

            // 残高合計の更新

            this.update_BlTotalLabel();
            // 2009.01.06 <<<

			upDateClaim_PanelTextData();
		}

        private bool _addUpADateLeaving = false;
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
            if (this._addUpADateLeaving) return;

            try
            {
                this._addUpADateLeaving = true;
                if (this.AddUpADate_tDateEdit.LongDate == 0) return;

                // 売掛
                //if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
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
                this._addUpADateLeaving = false;
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

            int selstart = chk_tNedit.SelectionStart;// 0;
            int sellength = chk_tNedit.TextLength - chk_tNedit.SelectionStart;
            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";

            // ↓の処理と全く同じ変数を使っているため削除 2008.10.14
            //if (chk_tNedit.TextLength > 0)
            //{
            //    _strResult = chk_tNedit.Text.Substring(0, selstart) + chk_tNedit.Text.Substring(selstart + sellength, chk_tNedit.Text.Length - (selstart + sellength));
            //}
            //else
            //{
            //    _strResult = chk_tNedit.Text;
            //}

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
        //    double ItdedOutTaxTotal = this.ItdedSalesOutTax_tNedit.GetValue() -       // 売上外税対象額
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
        //    double OutTaxTotal = this.SalesOutTax_tNedit.GetValue() -       // 売上外税額
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
        //    double ItdedInTaxTotal = this.ItdedSalesInTax_tNedit.GetValue() -       // 売上内税対象額
        //                             this.ItdedPaymInTax_tNedit.GetValue();         // 支払内税対象額
        //    this.ItdedInTaxTotal_Label.Text = Claim_panelDataat((Int64)ItdedInTaxTotal, false);
        //}

        ///// <summary>内税額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 内税額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_InTaxTotalLabel()
        //{
        //    double InTaxTotal = this.SalesInTax_tNedit.GetValue() -       // 売上内税額
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
        //    double ItdedTaxFreeTotal = this.ItdedSalesTaxFree_tNedit.GetValue() -       // 売上非課税対象額
        //                               this.ItdedPaymTaxFree_tNedit.GetValue();         // 支払非課税対象額
        //    this.ItdedTaxFreeTotal_Label.Text = Claim_panelDataFormat((Int64)ItdedTaxFreeTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>入金金額合計計算</summary>
        ///// <remarks>
        ///// <br>Note       : 入金金額の合計計算を行う</br>
        ///// <br>Programmer : 30154 安藤　昌仁</br>
        ///// <br>Date       : 2007.04.18</br>
        ///// </remarks>
        //private void update_DepoPrcTotalLabel()
        //{
        //    double DepoPrcTotal = this.DepoNrml_tNedit.GetValue() +     // 通常入金金額
        //                          this.Depo_tNedit.GetValue();          // 預り金入金金額
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

        // 2009.01.06 Del >>>
        //public void update_TtlBl_Label()
        //{
        //    double salesTotal = this.ItdedSalesOutTax_tNedit.GetValue() +       // 売上外税対象額
        //                        this.SalesOutTax_tNedit.GetValue() +       // 売上外税額
        //                        this.ItdedSalesInTax_tNedit.GetValue() +       // 売上内税対象額
        //                        this.SalesInTax_tNedit.GetValue() +       // 売上内税額
        //                        this.ItdedSalesTaxFree_tNedit.GetValue();       // 売上非課税対象額
        //    TtlBl_Label.Text = Claim_panelDataFormat((Int64)salesTotal, false);
        //}
        // 2009.01.06 Del <<<

        /// <summary>売上額合計計算</summary>
        /// <remarks>
        /// <br>Note       : 売上額の合計計算を行う</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void update_SalesTotalLabel()
        {
            // 2009.01.06 >>>
            //double salesTotal = this.ItdedSalesOutTax_tNedit.GetValue() +       // 売上外税対象額
            //                    this.SalesOutTax_tNedit.GetValue()      +       // 売上外税額
            //                    this.ItdedSalesInTax_tNedit.GetValue()  +       // 売上内税対象額
            //                    this.SalesInTax_tNedit.GetValue()       +       // 売上内税額
            //                    this.ItdedSalesTaxFree_tNedit.GetValue();       // 売上非課税対象額
            double salesTotal = this.ItdedSalesOutTax_tNedit.GetValue() +       // 売上外税対象額
                                this.ItdedSalesInTax_tNedit.GetValue() +        // 売上内税対象額
                                this.ItdedSalesTaxFree_tNedit.GetValue();       // 売上非課税対象額
            // 2009.01.06 <<<
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
            // 2009.01.06 >>>
            //double retTotal   = this.TtlItdedRetOutTax_tNedit.GetValue() +       // 返品外税対象額
            //                    this.TtlRetOuterTax_tNedit.GetValue() +          // 返品外税額
            //                    this.TtlItdedRetInTax_tNedit.GetValue() +        // 返品内税対象額
            //                    this.TtlRetInnerTax_tNedit.GetValue() +          // 返品内税額
            //                    this.TtlItdedRetTaxFree_tNedit.GetValue();       // 返品非課税対象額
            double retTotal = this.TtlItdedRetOutTax_tNedit.GetValue() +       // 返品外税対象額
                                this.TtlItdedRetInTax_tNedit.GetValue() +        // 返品内税対象額
                                this.TtlItdedRetTaxFree_tNedit.GetValue();       // 返品非課税対象額
            // 2009.01.06 <<<
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
            // 2009.01.06 >>>
            //double disTotal   = this.TtlItdedDisOutTax_tNedit.GetValue() +       // 値引外税対象額
            //                    this.TtlDisOuterTax_tNedit.GetValue() +          // 値引外税額
            //                    this.TtlItdedDisInTax_tNedit.GetValue() +        // 値引内税対象額
            //                    this.TtlDisInnerTax_tNedit.GetValue() +          // 値引内税額
            //                    this.TtlItdedDisTaxFree_tNedit.GetValue();       // 値引非課税対象額

            double disTotal = this.TtlItdedDisOutTax_tNedit.GetValue() +       // 値引外税対象額
                                this.TtlItdedDisInTax_tNedit.GetValue() +        // 値引内税対象額
                                this.TtlItdedDisTaxFree_tNedit.GetValue();       // 値引非課税対象額
            // 2009.01.06 <<<
            DisTotal_Label.Text = Claim_panelDataFormat((Int64)disTotal, false);
        }

        // 2009.01.06 Add >>>
        /// <summary>相殺後外税対象額計算</summary>
        /// <remarks>
        /// <br>Note       : 相殺後外税対象額の計算を行う</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_ItdedOffsetOutTaxLabel()
        {
            long total = (Int64)this.ItdedSalesOutTax_tNedit.GetValue() -       // 売上外税対象額
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // 返品外税対象額
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue();       // 値引外税対象額
            ItdedOffsetOutTax_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>相殺後非課税対象額計算</summary>
        /// <remarks>
        /// <br>Note       : 相殺後非課税対象額の計算を行う</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_ItdedOffsetTaxFreeLabel()
        {
            long total = (Int64)this.ItdedSalesTaxFree_tNedit.GetValue() -      // 売上非課税対象額
                         (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue() -     // 返品非課税対象額
                         (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue();      // 値引非課税対象額
            ItdedOffsetTaxFree_Label.Text = Claim_panelDataFormat(total, false);
        }

        /// <summary>相殺後今回売上金額計算</summary>
        /// <remarks>
        /// <br>Note       : 相殺後非課税対象額の計算を行う</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_OfsThisTimeSalesTotalLabel()
        {
            long total = (Int64)this.ItdedSalesOutTax_tNedit.GetValue() -       // 売上外税対象額
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // 返品外税対象額
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue() +      // 値引外税対象額
                         (Int64)this.ItdedSalesInTax_tNedit.GetValue() -        // 売上内税対象額
                         (Int64)this.TtlItdedRetInTax_tNedit.GetValue() -       // 返品内税対象額
                         (Int64)this.TtlItdedDisInTax_tNedit.GetValue() +       // 値引内税対象額
                         (Int64)this.ItdedSalesTaxFree_tNedit.GetValue() -      // 売上非課税対象額
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
        /// <br>Date       : 2009.01.06</br>
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
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void update_OfsThisTimeSalesTaxIncLabel()
        {
            long total = (Int64)this.ItdedSalesOutTax_tNedit.GetValue() -       // 売上外税対象額
                         (Int64)this.TtlItdedRetOutTax_tNedit.GetValue() -      // 返品外税対象額
                         (Int64)this.TtlItdedDisOutTax_tNedit.GetValue() +      // 値引外税対象額
                         (Int64)this.ItdedSalesInTax_tNedit.GetValue() -        // 売上内税対象額
                         (Int64)this.TtlItdedRetInTax_tNedit.GetValue() -       // 返品内税対象額
                         (Int64)this.TtlItdedDisInTax_tNedit.GetValue() +       // 値引内税対象額
                         (Int64)this.ItdedSalesTaxFree_tNedit.GetValue() -      // 売上非課税対象額
                         (Int64)this.TtlItdedRetTaxFree_tNedit.GetValue() -     // 返品非課税対象額
                         (Int64)this.TtlItdedDisTaxFree_tNedit.GetValue() +     // 値引非課税対象額
                         (Int64)this.OfsThisSalesTax_tNedit.GetValue();         // 消費税合計

            this.OfsThisTimeSalesTaxInc_Label.Text = Claim_panelDataFormat(total, false);
        }
        // 2009.01.06 Add <<<
        /// <summary>相殺支払合計計算</summary>
        /// <remarks>
        /// <br>Note       : 相殺支払額の合計計算を行う</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.12.21</br>
        /// </remarks>
        private void update_ItdedPaymTotalLabel ()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //double itdedPaymTotal = this.ItdedPaymOutTax_tNedit.GetValue() +    // 支払外税対象額
                                    //this.PaymentOutTax_tNedit.GetValue() +      // 支払外税額
                                    //this.ItdedPaymInTax_tNedit.GetValue() +     // 支払内税対象額
                                    //this.PaymentInTax_tNedit.GetValue() +       // 支払内税額
                                    //this.ItdedPaymTaxFree_tNedit.GetValue();    // 支払非課税対象額

            //ItdedPaymTotal_Label.Text = Claim_panelDataFormat( (Int64)itdedPaymTotal, false );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

        }
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

        /// <summary>通常入金合計計算</summary>
        /// <remarks>
        /// <br>Note       : 通常入金の合計計算を行う</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void update_NormalTotalLabel()
        {
            // 2009.01.06 >>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////double NormalTotal = this.DepoNrml_tNedit.GetValue() +     // 通常入金金額
            ////                     this.FeeNrml_tNedit.GetValue()  +     // 通常手数料額
            ////                     this.DisNrml_tNedit.GetValue()  +     // 通常値引額
            ////                     this.RbtNrml_tNedit.GetValue();       // 通常リベート額
            //double NormalTotal = this.DepoNrml_tNedit.GetValue() +     // 通常入金金額
            //                     this.FeeNrml_tNedit.GetValue() +     // 通常手数料額
            //                     this.DisNrml_tNedit.GetValue();     // 通常値引額
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //NrmlTotal_Label.Text = Claim_panelDataFormat((Int64)NormalTotal, false);

            // 内訳の合計
            object value = this._depositDataTable.Compute(string.Format("SUM({0})", DepositRelDataAcs.ctDeposit), string.Empty);
            Int64 total = ( value is DBNull ) ? 0 : (Int64)value;

            total += (Int64)this.FeeNrml_tNedit.GetValue() + (long)this.DisNrml_tNedit.GetValue();

            NrmlTotal_Label.Text = Claim_panelDataFormat(total, false);
            // 2009.01.06 <<<
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
        //    double DepositTotal = this.Depo_tNedit.GetValue()    +     // 預り金入金金額
        //                          this.FeeDepo_tNedit.GetValue() +     // 預り金手数料額
        //                          this.DisDepo_tNedit.GetValue() +     // 預り金値引額
        //                          this.RbtDepo_tNedit.GetValue();      // 預り金リベート額
        //    DepoTotal_Label.Text = Claim_panelDataFormat((Int64)DepositTotal, false);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        # endregion

        /// <summary>DataRow得意先売掛金額マスタオブジェクト展開処理</summary>
        /// <param name="dr">得意先売掛金額情報DataTableのDataRow</param>
        /// <param name="custAccRec">得意先売掛金額マスタクラス</param>
        /// <param name="accRecDepoTotalList">売掛入金集計データリスト</param>
        /// <remarks>
        /// <br>Note       : 対象のDataRowから得意先売掛金額マスタオブジェクトへ格納する</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
            //custAccRec.ThisPayOffset = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_THISPAYOFFSET_TITLE].ToString() ); // 今回支払相殺金額
            //custAccRec.ThisPayOffsetTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_THISPAYOFFSETTAX_TITLE].ToString() ); // 今回支払相殺消費税
            //custAccRec.ItdedPaymOutTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE].ToString() ); // 支払外税対象額
            //custAccRec.ItdedPaymInTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE].ToString() ); // 支払内税対象額
            //custAccRec.ItdedPaymTaxFree = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE].ToString() ); // 支払非課税対象額
            //custAccRec.PaymentOutTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE].ToString() ); // 支払外税消費税
            //custAccRec.PaymentInTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE].ToString() ); // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            custAccRec.TaxAdjust = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE].ToString() ); // 消費税調整額
            custAccRec.SalesSlipCount = Int32.Parse( dr[CustAccRecDmdPrcAcs.COL_SALESSLIPCOUNT_TITLE].ToString() ); // 売上伝票枚数
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

        /// <summary>DataRow得意先請求金額マスタオブジェクト展開処理</summary>
        /// <param name="dr">得意先請求金額情報DataTableのDataRow</param>
        /// <param name="custDmdPrc">得意先請求金額マスタクラス</param>
        /// <param name="dmdDepoTotalList">請求入金入金集計データリスト</param>
        /// <remarks>
        /// <br>Note       : 対象のDataRowから得意先請求金額マスタオブジェクトへ格納する</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
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
            //custDmdPrc.ThisPayOffset = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_THISPAYOFFSET_TITLE].ToString() ); // 今回支払相殺金額
            //custDmdPrc.ThisPayOffsetTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_THISPAYOFFSETTAX_TITLE].ToString() ); // 今回支払相殺消費税
            //custDmdPrc.ItdedPaymOutTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMOUTTAX_TITLE].ToString() ); // 支払外税対象額
            //custDmdPrc.ItdedPaymInTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMINTAX_TITLE].ToString() ); // 支払内税対象額
            //custDmdPrc.ItdedPaymTaxFree = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_ITDEDPAYMTAXFREE_TITLE].ToString() ); // 支払非課税対象額
            //custDmdPrc.PaymentOutTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_PAYMENTOUTTAX_TITLE].ToString() ); // 支払外税消費税
            //custDmdPrc.PaymentInTax = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_PAYMENTINTAX_TITLE].ToString() ); // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            custDmdPrc.TaxAdjust = Int64.Parse( dr[CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE].ToString() ); // 消費税調整額
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
            custDmdPrc.BillNo = Int32.Parse(dr[CustAccRecDmdPrcAcs.COL_BILLNO_TITLE].ToString());       // 請求書No
            // ADD 2009/06/23 ------<<<
        }

        private void TaxAdjust_tNedit_Leave(object sender, EventArgs e)
        {
            //if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // 鑑への反映
            upDateClaim_PanelTextData();
        }

        // 2009.01.06 Add >>>

        /// <summary>
        /// 集計レコードの請求金額マスタを取得します。
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
        /// 集計レコードの売掛金額マスタを取得します。
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
        /// 残高情報表示グリッドの初期セッティング
        /// </summary>
        /// <remarks>
        /// <br>Note       : 残高情報表示グリッドの表示設定を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void SettingDemandInfoGrid()
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
            if (this._targetTableName.Equals(CustAccRecDmdPrcAcs.TBL_CUSTACCREC_TITLE))
            {
                // 前回残高
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Header.Caption = REC_TOTAL1_BEF_TITLE;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Width = 200;

                // 今回売上
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Header.Caption = REC_THISTIMESALES_TITLE;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Width = 200;

                // 消費税
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Header.Caption = REC_CONSTAX_TITLE;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Width = 200;

                // 今回入金
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Header.Caption = REC_THISTIMEDEPO_TITLE;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Width = 200;

                // 売掛残高
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Header.Caption = REC_ACCRECBLNCE_TITLE;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Width = 200;

            }
            else
            {

                // 前々回残高
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Header.Caption = REC_TOTAL3_BEF_TITLE;
                Columns[BalanceDisplayTable.ct_Col_TOTAL3_BEF].Width = 200;

                // 前々回残高
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Header.Caption = REC_TOTAL2_BEF_TITLE;
                Columns[BalanceDisplayTable.ct_Col_TOTAL2_BEF].Width = 200;

                // 前回残高
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Header.Caption = REC_TOTAL1_BEF_TITLE;
                Columns[BalanceDisplayTable.ct_Col_TOTAL1_BEF].Width = 200;

                // 今回売上
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Header.Caption = REC_THISTIMESALES_TITLE;
                Columns[BalanceDisplayTable.ct_Col_THISTIMESALES].Width = 200;

                // 消費税
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Header.Caption = REC_CONSTAX_TITLE;
                Columns[BalanceDisplayTable.ct_Col_CONSTAX].Width = 200;

                // 今回入金
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Header.Caption = REC_THISTIMEDEPO_TITLE;
                Columns[BalanceDisplayTable.ct_Col_THISTIMEDEPO].Width = 200;

                // 請求残高
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Hidden = false;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Header.VisiblePosition = visiblePosition++;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Format = moneyFormat;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Header.Caption = REC_DMDPRCBLNCE_TITLE;
                Columns[BalanceDisplayTable.ct_Col_ACCRECBLNCE].Width = 200;
            }

            // 固定列区切り線設定
            this.uGrid_DemandInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_DemandInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_DemandInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        /// <summary>
        /// 入金内訳グリッド表示設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金内訳グリッドの表示設定を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void DepositKindGridInitialSetting()
        {
            try
            {
                // データテーブルの列定義
                _depositDataTable = new DataTable();

                // Addを行う順番が、列の表示順位となります。
                _depositDataTable.Columns.Add(DepositRelDataAcs.ctDepositKindDiv, typeof(Int32));      // 金種区分
                _depositDataTable.Columns.Add(DepositRelDataAcs.ctDepositKindCode, typeof(Int32));      // 金種コード
                _depositDataTable.Columns.Add(DepositRelDataAcs.ctDepositKindName, typeof(string));     // 入金内訳
                _depositDataTable.Columns.Add(DepositRelDataAcs.ctDeposit, typeof(Int64));              // 入金金額


                _depositDataTable.PrimaryKey = new DataColumn[] { _depositDataTable.Columns[DepositRelDataAcs.ctDepositKindCode] };

                this._depositDataView = this._depositDataTable.DefaultView;

                this.grdDepositKind.DataSource = this._depositDataView;
                this._depositDataView.Sort = DepositRelDataAcs.ctDepositKindDiv;

                string moneyFormat = "#,##0;-#,##0;''";

                // --- 入金内訳バンド --- //
                Infragistics.Win.UltraWinGrid.ColumnsCollection pareColumns = this.grdDepositKind.DisplayLayout.Bands[0].Columns;

                // 金種コード
                pareColumns[DepositRelDataAcs.ctDepositKindDiv].Header.Caption = "金種コード";
                pareColumns[DepositRelDataAcs.ctDepositKindDiv].Hidden = true;

                // 金種コード
                pareColumns[DepositRelDataAcs.ctDepositKindCode].Header.Caption = "金種コード";
                pareColumns[DepositRelDataAcs.ctDepositKindCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                //pareColumns[DepositRelDataAcs.ctDepositKindCode].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                pareColumns[DepositRelDataAcs.ctDepositKindCode].Hidden = true;

                // 金種名称
                pareColumns[DepositRelDataAcs.ctDepositKindName].Header.Caption = "入金内訳";
                pareColumns[DepositRelDataAcs.ctDepositKindName].Header.Appearance.FontData.SizeInPoints = 10;
                pareColumns[DepositRelDataAcs.ctDepositKindName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                pareColumns[DepositRelDataAcs.ctDepositKindName].CellAppearance.ForeColorDisabled = Color.Black;
                pareColumns[DepositRelDataAcs.ctDepositKindName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                pareColumns[DepositRelDataAcs.ctDepositKindName].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                //pareColumns[DepositRelDataAcs.ctDepositKindName].CellAppearance.FontData.SizeInPoints = 10;
                pareColumns[DepositRelDataAcs.ctDepositKindName].Width = 105;

                // 入金額
                pareColumns[DepositRelDataAcs.ctDeposit].Header.Caption = "入金金額";
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
        /// 入金内訳テーブル ColumnChangeイベント
        /// </summary>
        /// <returns></returns>
        private  void DepositChanged(object sender,DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == DepositRelDataAcs.ctDeposit)
            {
                // 入金合計ラベルへ反映
                this.update_NormalTotalLabel();
                // 鑑への反映
                upDateClaim_PanelTextData();
            }
        }

        /// <summary>
        /// 入金内訳テーブルクリア
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
        /// 請求入金集計データ→入金内訳テーブル設定処理
        /// </summary>
        /// <param name="dmdDepoTotalList">請求入金集計データリスト</param>
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
        /// 売掛入金集計データ→入金内訳テーブル設定処理
        /// </summary>
        /// <param name="accRecDepoTotalList">売掛入金集計データリスト</param>
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
        /// 請求入金データ取得処理
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
                    dmdDepoTotal.MoneyKindCode = (Int32)row[DepositRelDataAcs.ctDepositKindCode];   // 金種コード
                    dmdDepoTotal.MoneyKindName = (string)row[DepositRelDataAcs.ctDepositKindName];  // 金種名称
                    dmdDepoTotal.MoneyKindDiv = (Int32)row[DepositRelDataAcs.ctDepositKindDiv];     // 金種区分
                    dmdDepoTotal.Deposit = (Int64)row[DepositRelDataAcs.ctDeposit];                 // 入金金額
                    returnList.Add(dmdDepoTotal);
                }
            }

            return returnList;
        }

        /// <summary>
        /// 請求入金データ取得処理
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
                    accRecDepoTotal.MoneyKindCode = (Int32)row[DepositRelDataAcs.ctDepositKindCode];    // 金種コード
                    accRecDepoTotal.MoneyKindName = (string)row[DepositRelDataAcs.ctDepositKindName];   // 金種名称
                    accRecDepoTotal.MoneyKindDiv = (Int32)row[DepositRelDataAcs.ctDepositKindDiv];      // 金種区分
                    accRecDepoTotal.Deposit = (Int64)row[DepositRelDataAcs.ctDeposit];                  // 入金金額
                    returnList.Add(accRecDepoTotal);
                }
            }

            return returnList;
        }

        /// <summary>
        /// 金額入力済みの入金データのDataRowを取得します。
        /// </summary>
        /// <returns></returns>
        private DataRow[] GetDepositRows()
        {
            return this._depositDataTable.Select(string.Format("{0}<>0", DepositRelDataAcs.ctDeposit));
        }

        /// <summary>
        /// 入金内訳グリッド KeyDownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
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
        /// 入金内訳グリッド KeyPressイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void grdDepositKind_KeyPress(object sender, KeyPressEventArgs e)
        {
            // --- ADD 2009/01/26 障害ID:10441対応------------------------------------------------------>>>>>
            if (this.grdDepositKind.ActiveCell == null)
            {
                return;
            }
            // --- ADD 2009/01/26 障害ID:10441対応------------------------------------------------------<<<<<

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.grdDepositKind.ActiveCell;
            if (cell.Column.Key == DepositRelDataAcs.ctDeposit)
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
        /// 入金内訳グリッド AfterEnterEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void grdDepositKind_AfterEnterEditMode(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 入金内訳グリッド AfterExitEditModeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void grdDepositKind_AfterExitEditMode(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 入金内訳グリッド CellChangeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void grdDepositKind_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {

        }

        /// <summary>
        /// 入金内訳グリッド Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void grdDepositKind_Leave(object sender, EventArgs e)
        {
            this.grdDepositKind.ActiveCell = null;
            this.grdDepositKind.ActiveRow = null;
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

        /// <summary>
        /// 相殺後金額TNedit_Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Offset_tNedit_Leave(object sender, EventArgs e)
        {
            if (this._changeFlg == false) return;

            TNedit ctrlTNedit = (TNedit)sender;

            if (ctrlTNedit == null) return;

            // 税込み合計ラベルの反映
            this.update_OfsThisTimeSalesTaxIncLabel();
            // 鑑への反映
            upDateClaim_PanelTextData();
        }

        // 2009.01.06 Add <<<

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 >>>>>>START
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
                int dsAddUpADate = (int)this.Bind_DataSet.Tables[this._targetTableName].Rows[i][CustAccRecDmdPrcAcs.COL_ADDUPDATE_TITLE];
                if (addUpADate == dsAddUpADate)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[this._targetTableName].Rows[i][CustAccRecDmdPrcAcs.COL_DELETEDATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "MAKAU09110U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの得意先実績修正情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 締日のクリア
                        AddUpADate_tDateEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "MAKAU09110U",                          // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの得意先実績修正情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
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

        // 2009.03.30 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // ADD 2009/06/23 ------>>>
        /// <summary>
        /// BillNo_tNedit_BeforeEnterEditModeイベント
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
