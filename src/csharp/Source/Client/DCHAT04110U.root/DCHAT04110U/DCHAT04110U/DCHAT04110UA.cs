//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 発注残照会
// プログラム概要   : 発注残照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2008/10/27  修正内容 : PM.NS対応、各種保守対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/02/05  修正内容 : 障害対応7965(発注番号、行番号を削除)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/02/16  修正内容 : 障害対応11548(複数倉庫選択フラグを追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/03/12  修正内容 : 障害対応12307
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/04/03  修正内容 : 障害対応13085
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/15  修正内容 : 障害対応13174
//----------------------------------------------------------------------------//
// 管理番号　11070071-00 作成担当 : 鄧潘ハン
// 修 正 日　2014/04/24  修正内容 : 11070071-00 システムテスト障害一覧No.2312の対応
//                                  Redmine#42258、仕入伝票入力で該当データなしになる件の修正
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 発注残照会入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 発注残照会のUIクラスです。</br>
	/// <br>Programmer	: 21024　佐々木 健</br>
	/// <br>Date		: 2007.10.15</br>
    /// <br>---------------------------------------------------</br>
    /// <br>UpdateNote: 2008.10.27　鈴木 正臣</br>
    /// <br>          　①PM.NS対応、各種保守対応</br>
    /// <br>UpdateNote: 2009.02.05　上野 俊治</br>
    /// <br>          　①障害対応7965(発注番号、行番号を削除)</br>
    /// <br>UpdateNote: 2009.02.16　忍 幸史</br>
    /// <br>          　①障害対応11548(複数倉庫選択フラグを追加)</br>
    /// <br>UpdateNote: 2009.03.12　忍 幸史</br>
    /// <br>          　①障害対応12307</br>
    /// <br>UpdateNote: 2009/04.03　上野 俊治</br>
    /// <br>          　①障害対応13085</br>
    /// <br>UpdateNote: 2014/04/24　鄧潘ハン</br>
    /// <br>管理番号  : 11070071-00 システムテスト障害一覧No.2312の対応</br>
    /// <br>            Redmine#42258　仕入伝票入力で該当データなしになる件の修正</br>
    /// </remarks>
	public partial class DCHAT04110UA : Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		#region ■Constructor
		public DCHAT04110UA()
		{
			InitializeComponent();

			// 変数初期化
			this._orderRemainReferenceAcs = new DCHAT04112AA();
			this._orderRemainReferenceAcs.SelectedRowChanged += new EventHandler(SelectedRowChanged);
            this._dataSet = _orderRemainReferenceAcs.DataSet;
            this._imageList16 = IconResourceManagement.ImageList16;
			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
			this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
			this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"];
			this._previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Preview"];
			this._controlScreenSkin = new ControlScreenSkin();

            this._orderListCndtnCache_Display = new OrderListCndtnWork();

			// 変数初期化
			this._detailForm = new DCHAT04110UB(this._orderRemainReferenceAcs);

            this._detailForm.StatusBarMessageSetting += new DCHAT04110UB.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
			this._orderRemainReferenceAcs.StatusBarMessageSetting += new DCHAT04112AA.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
            this._detailForm.CloseMain += new DCHAT04110UB.CloseMainEventHandler(this.CloseForm);
			this._detailForm.SetMainDialogResult += new DCHAT04110UB.SetDialogResEventHandler(this.SetDialogRes);
			this._detailForm.DecisionButtonEnableSet += new DCHAT04110UB.SettingDecisionButtonEnableEventHandler(this.ChangeDecisionButtonEnable);
			this._detailForm.GridKeyDownTopRow += new EventHandler(this.DetailForm_GridKeyDownTopRow);
			//this._detailForm.OrderRemainReferenceAcs = this._orderRemainReferenceAcs;

			this._orderRemainReferenceAcs.GetNameList += new DCHAT04112AA.GetNameListEventHandler(this.GetDisplayNameList);

			// 企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 自拠点コードを取得する
			this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            if ( _loginSectionCode != string.Empty )
            {
                _loginSectionCode = _loginSectionCode.Trim();
            }

            // 入荷状況
            tComboEditor_AddUpRemDiv.SelectedIndex = 0;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
			// 拠点オプション有無を取得する
			this._optSection = ( (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0 );
			// 本社/拠点情報を取得する
			this._mainOfficeFunc = this._orderRemainReferenceAcs.IsMainOfficeFunc();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // 締日算出モジュール
            _totalDayCalculator = TotalDayCalculator.GetInstance();

            // 特殊フォーカス制御
            _irrFocusCtrl = new IrregularFocusControl();
            # region [Focus]
            _irrFocusCtrl.AddFocusDictionary( tEdit_GoodsName, false, Keys.Up, 0, tEdit_StockInputCode );
            _irrFocusCtrl.AddFocusDictionary( uButton_GoodsMakerGuide, false, Keys.Up, 0, tComboEditor_AddUpRemDiv );
            //_irrFocusCtrl.AddFocusDictionary(uButton_StockCustomerGuide, false, Keys.Down, 0, tEdit_OrderNumber); // DEL 2009/02/05
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
		}
		#endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		#region ■Private Members
		private DCHAT04110UB _detailForm;

		private DCHAT04112AA _orderRemainReferenceAcs;
        private OrderRemainDataSet _dataSet;
		private DisplayType _displayType = DisplayType.DisplayOnly;
		private int _supplierCode = 0;
		private DCCMN04000UA _printControl = null;
        private OrderListCndtnWork _orderListCndtnCache_Display;
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();
		private WarehouseAcs _warehouseAcs = new WarehouseAcs();

        // 検索区分 0:全て, 1:非オンライン(在庫仕入入力から呼び出された時のみ)
        private Int32 _searchDiv = 0;

        private string _enterpriseCode;             // 企業コード
        private string _loginSectionCode;           // 自拠点コード
        private bool _optSection;                   // 拠点オプション有無フラグ
        private bool _mainOfficeFunc;               // 本社/拠点判断フラグ
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;		// 印刷ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _previewButton;	// 印刷ボタン
		private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogRes = DialogResult.Cancel;
		private bool _isCacheClear = false;
		private bool _isMultiSelect = false;

        // --- ADD 2009/02/16 障害ID:11548対応------------------------------------------------------>>>>>
        private bool _isMultiWarehouseSelect = true;
        // --- ADD 2009/02/16 障害ID:11548対応------------------------------------------------------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        private SupplierAcs _supplierAcs;               // 仕入先アクセスクラス
        private IrregularFocusControl _irrFocusCtrl;    // 特殊フォーカス制御クラス
        private DateGetAcs _dateGet;                    // 日付算出部品
        private TotalDayCalculator _totalDayCalculator; // 締日算出モジュール
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD


        private const string MESSAGE_StartEndError = "開始≦終了となるよう設定してください。";
        private const string MESSAGE_NoInput = "必須入力項目です。";
        private const string MESSAGE_InvalidDate = "有効な日付ではありません。";

		private const string cTAB_MAIN = "Main";
		private const string cTAB_PREVIEW = "Preview";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        private const string ct_AllSectionName = "全社";
        //エラー条件メッセージ
        const string ct_InputError = "の入力が不正です";
        const string ct_NoInput = "を入力して下さい";
        const string ct_RangeError = "の範囲指定に誤りがあります";
        const string ct_RangeOverError = "は３ヶ月の範囲内で入力して下さい。";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

        // 2009.03.03 30413 犬飼 ダイアログ呼出のアセンブリIDを設定 >>>>>>START
        private const string ct_MAZAI04360UA = "MAZAI04360UA";
        private const string ct_MAKON01110UB = "MAKON01110UB";
        // 2009.03.03 30413 犬飼 ダイアログ呼出のアセンブリIDを設定 <<<<<<END
        
		#endregion

		// ===================================================================================== //
		// 列挙体
		// ===================================================================================== //
		# region ■Enums
		/// <summary>
		/// 表示タイプ
		/// </summary>
		public enum DisplayType : int
		{
			/// <summary>表示のみ</summary>
			DisplayOnly = 0,
			/// <summary>表示,選択機能</summary>
			DisplayAndSelect = 1,
		}
		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		#region ■Properties

		/// <summary>選択伝票データ取得プロパティ</summary>
		public List<OrderListResultWork> orderListResultWorkList
		{
			get { return this._orderRemainReferenceAcs.GetSelectedRowData(); }
		}

		/// <summary>拠点コードプロパティ</summary>
		public string SectionCode
		{
			get { return this.tEdit_SectionCodeAllowZero.Text; }
			set { this.tEdit_SectionCodeAllowZero.Text = value; }
		}
		/// <summary>拠点名称プロパティ</summary>
		public string SectionName
		{
			get { return this.uLabel_SectionNm.Text; }
			set { this.uLabel_SectionNm.Text = value; }
		}
		/// <summary>発注先コードプロパティ</summary>
		public int SupplierCode
		{
			get { return this.tNedit_SupplierCd.GetInt(); }
			set { this.tNedit_SupplierCd.SetInt(value); }
		}
		/// <summary>発注先名称プロパティ</summary>
		public string SupplierName
		{
			get { return this.uLabel_SupplierName.Text; }
			set { this.uLabel_SupplierName.Text = value; }
		}

		/// <summary>商品コードプロパティ</summary>
		public string GoodsNo
		{
			get { return this.tEdit_GoodsNo.Text; }
			set { this.tEdit_GoodsNo.Text = value; }
		}

		/// <summary>商品名称プロパティ</summary>
		public string GoodsName
		{
            get { return this.tEdit_GoodsName.Text; }
            set { this.tEdit_GoodsName.Text = value; }
		}

		/// <summary>メーカーコードプロパティ</summary>
		public int GoodsMakerCode
		{
			get { return this.tNedit_GoodsMakerCd.GetInt(); }
			set { this.tNedit_GoodsMakerCd.SetInt(value); }
		}
		/// <summary>メーカー名称プロパティ</summary>
		public string GoodsMakerName
		{
			get { return this.uLabel_MakerName.Text; }
			set { this.uLabel_MakerName.Text = value; }
		}

		/// <summary>発注日（開始）プロパティ</summary>
		public DateTime OrderDateStart
		{
			get { return this.tDateEdit_SalesOrderDateSt.GetDateTime(); }
			set { this.tDateEdit_SalesOrderDateSt.SetDateTime(value); }
		}

		/// <summary>発注日（終了）プロパティ</summary>
		public DateTime OrderDateEnd
		{
			get { return this.tDateEdit_SalesOrderDateEd.GetDateTime(); }
			set { this.tDateEdit_SalesOrderDateEd.SetDateTime(value); }
		}

		/// <summary>複数選択プロパティ</summary>
		public bool IsMultiSelect
		{
			get { return this._isMultiSelect; }
			set { this._isMultiSelect = value;}
		}

		/// <summary>キャッシュクリア有無プロパティ</summary>
		public bool IsCacheClear
		{
			get { return _isCacheClear; }
			set { _isCacheClear = value; }
		}

		/// <summary>
		/// 検索条件の表示有無
		/// </summary>
		public bool SearchConditionDsp
		{
			set { this.Standard_UGroupBox.Expanded = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        /// <summary>
        /// 選択可能件数
        /// </summary>
        public int MaxSelectCount
        {
            get { return _detailForm.MaxSelectCount; }
            set 
            { 
                _detailForm.MaxSelectCount = value;
                _orderRemainReferenceAcs.MaxSelectCount = value;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

        // --- ADD 2009/02/16 障害ID:11548対応------------------------------------------------------>>>>>
        /// <summary>複数倉庫選択プロパティ</summary>
        public bool IsMultiWarehouseSelect
        {
            get { return this._isMultiWarehouseSelect; }
            set { this._isMultiWarehouseSelect = value; }
        }
        // --- ADD 2009/02/16 障害ID:11548対応------------------------------------------------------<<<<<

		#endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		#region ■Public Methods
		/// <summary>
		/// 呼出制御処理
		/// </summary>
		/// <param name="owner">呼出元オブジェクト</param>
		/// <param name="displayType">画面タイプ</param>
		public DialogResult ShowDialog( IWin32Window owner, DisplayType displayType )
		{
			this._displayType = displayType;
			this._supplierCode = 0;

            // ShowDialogで呼ばれるのは在庫仕入入力のみ
            this._searchDiv = 1;

            // 2009.03.03 30413 犬飼 ダイアログ呼出時は、入荷状況を"未計上"で変更不可とする >>>>>>START
            string srcPGID = owner.ToString();
            if ((srcPGID.Contains(ct_MAZAI04360UA)) || (srcPGID.Contains(ct_MAKON01110UB)))
            {
                // 在庫仕入伝票入力または仕入伝票入力
                // 入荷状況
                tComboEditor_AddUpRemDiv.SelectedIndex = 2;
                tComboEditor_AddUpRemDiv.Enabled = false;
            }
            // 2009.03.03 30413 犬飼 ダイアログ呼出時は、入荷状況を"未計上"で変更不可とする <<<<<<END
            
			return this.ShowDialog(owner);
		}

		/// <summary>
		/// 呼出制御処理
		/// </summary>
		/// <param name="owner">呼出元オブジェクト</param>
		/// <param name="displayType">画面タイプ</param>
		/// <param name="supplierCode">発注先コード</param>
		public DialogResult ShowDialog( IWin32Window owner, DisplayType displayType, int customerCode )
		{
			this._displayType = displayType;
			this._supplierCode = customerCode;

            // ShowDialogで呼ばれるのは在庫仕入入力のみ
            // 仕入伝票入力からも呼び出される
            this._searchDiv = 1;

            // 2009.03.03 30413 犬飼 ダイアログ呼出時は、入荷状況を"未計上"で変更不可とする >>>>>>START
            string srcPGID = owner.ToString();
            if ((srcPGID.Contains(ct_MAZAI04360UA)) || (srcPGID.Contains(ct_MAKON01110UB)))
            {
                // 在庫仕入伝票入力または仕入伝票入力
                // 入荷状況
                tComboEditor_AddUpRemDiv.SelectedIndex = 2;
                tComboEditor_AddUpRemDiv.Enabled = false;
            }
            // 2009.03.03 30413 犬飼 ダイアログ呼出時は、入荷状況を"未計上"で変更不可とする <<<<<<END

			return this.ShowDialog(owner);
		}


        // --- ADD 2014/04/24 仕入伝票入力で該当データなしになる件 システムテスト障害一覧No.2312とRedmine#42258 ---------->>>>>
        /// <summary>
        /// 発注残データ検索処理条件更新
        /// </summary>
        /// <param name="displayType">画面タイプ</param>
        /// <remarks>
        /// <br>Note		: 注残データ検索処理条件更新</br>
        /// <br>Programmer	: 鄧潘ハン</br>
        /// <br>Date		: 2014/04/24</br>
        /// <br>管理番号    : 11070071-00 システムテスト障害一覧No.2312の対応</br>
        /// <br>              Redmine#42258　仕入伝票入力で該当データなしになる件の修正</br>
        /// </remarks>
        public void SearchOrderRemainDataCndn(DisplayType displayType)
        {
            this._displayType = displayType;
            this._supplierCode = 0;

            // 検索区分 0:全て, 1:非オンライン(在庫仕入入力から呼び出された時のみ)
            this._searchDiv = 1;

            // 仕入伝票入力
            // 入荷状況:未計上文
            tComboEditor_AddUpRemDiv.SelectedIndex = 2;
            tComboEditor_AddUpRemDiv.Enabled = false;
           
        }
        // --- ADD 2014/04/24 仕入伝票入力で該当データなしになる件 システムテスト障害一覧No.2312とRedmine#42258 ----------<<<<<

		/// <summary>
		/// 発注残データ検索処理
		/// </summary>
		/// <returns>読み込みステータス</returns>
		public int SearchOrderRemainData()
		{
			// 検索条件、検索結果のキャッシュをクリアする
			this._orderRemainReferenceAcs.ClearOrderListResultDataTable();

			OrderListCndtnWork orderListCndtnWork = new OrderListCndtnWork();
			bool setEnable = false;

			// 読込条件パラメータクラス設定処理
			this.SetReadPara(out orderListCndtnWork);

			// 伝票情報読込・データセット格納処理
			int status = this._orderRemainReferenceAcs.SetSearchData(orderListCndtnWork);

			setEnable = this._detailForm.SetGridEnable();

			if (setEnable == true)
			{
				this._detailForm.uGrid_Details.Focus();
				this._detailForm.timer_GridSetFocus.Enabled = true;
				this._printButton.SharedProps.Enabled = true;
				this._previewButton.SharedProps.Enabled = true;
			}
			else
			{
				this._printButton.SharedProps.Enabled = false;
				this._previewButton.SharedProps.Enabled = false;
			}

			return status;
		}
        #endregion

		/// <summary>
        /// 画面初期情報設定処理
        /// </summary>
        private void SetInitialInput()
        {
			OrderRemainDataSet.OrderListResultDataTable orderListResult = this._orderRemainReferenceAcs.GetStockSlipTableCache();

            // 拠点情報表示切替
            if (this._optSection == false)
            {
                // 拠点オプション無し
                ChangeSectionDisplay(false,false);
            }
            else
            {
                if (this._mainOfficeFunc == false)
                {
                    // 拠点設定
                    ChangeSectionDisplay(true, false);
                }
                else
                {
                    // 本社設定
                    ChangeSectionDisplay(true, true);
                }
            }

            // 前回検索情報有無判断
			if (( orderListResult == null ) || ( orderListResult.Count == 0 ))
			{
				// グリッド情報クリア
				this._orderRemainReferenceAcs.ClearOrderListResultDataTable();

				// ヘッダ情報クリア処理
				this.ClearDisplayHeader();

				// ヘッダ初期表示処理
				this.SetDisplayHeaderInfo();
			}
			else
			{
				// 前回起動ヘッダ情報設定処理
				this.SetPrevHeader();

				// グリッドに初期フォーカスを設定
				this._detailForm.timer_GridSetFocus.Enabled = true;
			}
        }

        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplayHeader()
        {
			this.tEdit_SectionCodeAllowZero.Clear();					// 拠点
			this.tEdit_StockInputCode.Clear();				// 仕入担当
			this.uLabel_StockInputName.Text = "";			// 仕入担当名

			this.tNedit_GoodsMakerCd.Clear();				// メーカーコード
			this.uLabel_MakerName.Text = "";				// メーカー名

			this.tNedit_SupplierCd.Clear();               // 仕入先コード
            this.uLabel_SupplierName.Text = "";             // 仕入先名

            this.tDateEdit_SalesOrderDateSt.Clear();		// 仕入日(開始)

            this.tEdit_GoodsNo.Clear();			            // 商品コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.uLabel_GoodsName.Text = "";				// 商品名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

			this.tEdit_StockAgentCode.Clear();				// 発注者
			this.uLabel_StockAgentName.Text = "";			// 発注者名

            //this.tEdit_OrderNumber.Clear();					// 発注番号 // DEL 2009/02/05

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.11 TOKUNAGA ADD START
            this.tEdit_GoodsName.Clear();                   // 品名検索

            this.tDateEdit_InputDateSt.Clear();             // 入力日(開始)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.11 TOKUNAGA ADD END

            this.ChangeDecisionButtonEnable(false);

            this.timer_InitialSetFocus.Enabled = true;
        }

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        private void SetDisplayHeaderInfo()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //// 仕入日
            //this.tDateEdit_SalesOrderDateSt.SetDateTime(DateTime.MinValue);
            //this.tDateEdit_SalesOrderDateEd.SetDateTime(DateTime.Today);
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.11 TOKUNAGA ADD START
            //// 入力日
            //this.tDateEdit_InputDateSt.SetDateTime(DateTime.MinValue);
            //this.tDateEdit_InputDateEd.SetDateTime(DateTime.Today);
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.11 TOKUNAGA ADD END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            // 発注日
            this.tDateEdit_SalesOrderDateSt.SetDateTime( GetPrevTotalDayNextDay( _loginSectionCode ) );
            this.tDateEdit_SalesOrderDateEd.SetDateTime( DateTime.Today );

            // 入力日
            this.tDateEdit_InputDateSt.SetDateTime( DateTime.MinValue );
            this.tDateEdit_InputDateEd.SetDateTime( DateTime.MinValue );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

            // 拠点設定
            this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode;

            SecInfoSet secInfoSet;
			int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
			}

			if (this._supplierCode != 0)
			{
				this.SettingCustomerInfo(this._supplierCode, false);
			}

			this.SetReadPara(out this._orderListCndtnCache_Display);
        }

		/// <summary>
		/// グリッド先頭行でのキーダウンイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DetailForm_GridKeyDownTopRow( object sender, EventArgs e )
		{
			this.tDateEdit_SalesOrderDateSt.Focus();
		}

        /// <summary>
        /// 拠点 表示切替処理
        /// </summary>
        private void ChangeSectionDisplay(bool visible,bool enabled)
        {
#if False
			this.uLabel_SectionTitle.Visible = visible;
            this.tEdit_SectionCodeAllowZero.Visible = visible;
            this.uLabel_SectionNm.Visible = visible;
            this.uButton_SectionGuide.Visible = visible;

            this.uLabel_SectionTitle.Enabled = enabled;
            this.tEdit_SectionCodeAllowZero.Enabled = enabled;
            this.uLabel_SectionNm.Enabled = enabled;
            this.uButton_SectionGuide.Enabled = enabled;
#endif
		}

        /// <summary>
        /// 前回起動ヘッダ情報設定処理
        /// </summary>
        private void SetPrevHeader()
        {
			OrderListCndtnWork orderListCndtn = this._orderRemainReferenceAcs.GetOrderListCndtnCache();

			if (orderListCndtn == null)
			{
				return;
			}

			SortedList nameList = this._orderRemainReferenceAcs.GetCacheNmaeList();

			if (nameList == null)
			{
				return;
			}
            
			// 拠点情報
			if (( orderListCndtn.SectionCodes != null ) && ( orderListCndtn.SectionCodes.Length > 0 ))
			{
				this.tEdit_SectionCodeAllowZero.Text = orderListCndtn.SectionCodes[0];

                // ADD 2009/04/19 ------>>>
                if ((this._orderListCndtnCache_Display.SectionCodes == null) ||
                    (this._orderListCndtnCache_Display.SectionCodes.Length == 0))
                {
                    this._orderListCndtnCache_Display.SectionCodes = new string[] { orderListCndtn.SectionCodes[0] };
                }
                // ADD 2009/04/19 ------<<<
            }
			this.uLabel_SectionNm.Text = (string)nameList["SectionNm"];

			// 発注先
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.tNedit_SupplierCd.SetInt(orderListCndtn.St_SupplierCd);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            this.tNedit_SupplierCd.SetInt( orderListCndtn.SupplierCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

            // ADD 2009/04/19 ------>>>
            if (this._orderListCndtnCache_Display.SupplierCd != orderListCndtn.SupplierCd)
            {
                this._orderListCndtnCache_Display.SupplierCd = orderListCndtn.SupplierCd;
            }
            // ADD 2009/04/19 ------<<<

			this.uLabel_SupplierName.Text = (string)nameList["SupplierName"];

			// 発注番号
            //this.tEdit_OrderNumber.Text = orderListCndtn.OrderNumber; // DEL 2009/02/05

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //// 発注日
            //this.tDateEdit_SalesOrderDateSt.SetDateTime(orderListCndtn.St_OrderFormPrintDate);
            //this.tDateEdit_SalesOrderDateEd.SetDateTime(orderListCndtn.Ed_OrderFormPrintDate);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

			// 商品
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.tEdit_GoodsNo.Text = orderListCndtn.St_GoodsNo;
            //this.uLabel_GoodsName.Text = (string)nameList["GoodsName"];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            this.tEdit_GoodsNo.Text = orderListCndtn.GoodsNo;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

			// メーカー
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.tNedit_GoodsMakerCd.SetInt(orderListCndtn.St_GoodsMakerCd);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            this.tNedit_GoodsMakerCd.SetInt( orderListCndtn.GoodsMakerCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

            // ADD 2009/04/19 ------>>>
            if (this._orderListCndtnCache_Display.GoodsMakerCd != orderListCndtn.GoodsMakerCd)
            {
                this._orderListCndtnCache_Display.GoodsMakerCd = orderListCndtn.GoodsMakerCd;
            }
            // ADD 2009/04/19 ------<<<
            
            this.uLabel_MakerName.Text = (string)nameList["MakerName"];

			// 担当者
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.tEdit_StockAgentCode.Text = orderListCndtn.St_StockAgentCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            this.tEdit_StockAgentCode.Text = orderListCndtn.StockAgentCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

            // ADD 2009/04/19 ------>>>
            if (this._orderListCndtnCache_Display.StockAgentCode != orderListCndtn.StockAgentCode)
            {
                this._orderListCndtnCache_Display.StockAgentCode = orderListCndtn.StockAgentCode;
            }
            // ADD 2009/04/19 ------<<<

            this.uLabel_StockAgentName.Text = (string)nameList["StockAgentName"];

			// 入力者
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.tEdit_StockInputCode.Text = orderListCndtn.St_StockInputCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            this.tEdit_StockInputCode.Text = orderListCndtn.StockInputCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

            // ADD 2009/04/19 ------>>>
            if (this._orderListCndtnCache_Display.StockInputCode != orderListCndtn.StockInputCode)
            {
                this._orderListCndtnCache_Display.StockInputCode = orderListCndtn.StockInputCode;
            }
            // ADD 2009/04/19 ------<<<

			this.uLabel_StockInputName.Text = (string)nameList["StockInputName"];

			//orderListCndtnWork.St_StockAgentCode = this.tEdit_StockAgentCode.Text;						// 開始仕入担当者コード
			//orderListCndtnWork.Ed_StockAgentCode = this.tEdit_StockAgentCode.Text;						// 終了仕入担当者コード
			//orderListCndtnWork.St_StockInputCode = this.tEdit_StockInputCode.Text;						// 開始仕入入力者コード
			//orderListCndtnWork.Ed_StockInputCode = this.tEdit_StockInputCode.Text;						// 終了仕入入力者コード

			//nameList.Add("", this.uLabel_SupplierName.Text);
			//nameList.Add("", this.uLabel_GoodsName.Text);
			//nameList.Add("", this.uLabel_MakerName.Text);
			//nameList.Add("", this.uLabel_StockAgentName.Text);
			//nameList.Add("", this.uLabel_StockInputName.Text);

		}


		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.11 TOKUNAGA MODIFY START
			//this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.11 TOKUNAGA MODIFY END
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
			this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
			this._previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

			//imageList16
			this.uButton_EmployeeGuide.ImageList = this._imageList16;
			this.uButton_GoodsMakerGuide.ImageList = this._imageList16;
			this.uButton_StockCustomerGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.ImageList = this._imageList16;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.uButton_GoodsGuide.ImageList = this._imageList16;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			this.uButton_StockAgentGuide.ImageList = this._imageList16;
            // 2009.03.03 30413 犬飼 倉庫ガイドボタンの追加 >>>>>>START
            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            // 2009.03.03 30413 犬飼 倉庫ガイドボタンの追加 <<<<<<END
        
			//STAR1
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_StockCustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.uButton_GoodsGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			this.uButton_StockAgentGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // 2009.03.03 30413 犬飼 倉庫ガイドボタンの追加 >>>>>>START
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // 2009.03.03 30413 犬飼 倉庫ガイドボタンの追加 <<<<<<END

			if (this._displayType == DisplayType.DisplayOnly)
			{
				this._decisionButton.SharedProps.Visible = false;
			}
			else
			{
				this._decisionButton.SharedProps.Visible = true;
			}

			this._printButton.SharedProps.Enabled = false;
			this._previewButton.SharedProps.Enabled = false;
		}


        /// <summary>
        /// 終了項目値自動設定処理(TEdit)
        /// </summary>
        /// <param name="startDate">開始日付項目TEdit</param>
        /// <param name="endDate">終了日付項目TEdit</param>
        private void AutoSetEndValue(TEdit startEdit, TEdit endEdit)
        {
            if (endEdit.Text == "")
            {
                endEdit.Text = startEdit.Text;
            }
        }

        /// <summary>
        /// 読込条件パラメータ設定処理
        /// </summary>
        /// </return> 読込条件パラメータクラス
        public void SetReadPara(out OrderListCndtnWork orderListCndtnWork)
        {
			orderListCndtnWork = new OrderListCndtnWork();

			orderListCndtnWork.EnterpriseCode = this._enterpriseCode;									// 企業コード
			// 拠点コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text))
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            if ( string.IsNullOrEmpty( this.tEdit_SectionCodeAllowZero.Text ) || tEdit_SectionCodeAllowZero.Text.Trim() == GetSectionCodeZero())
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
			{
				orderListCndtnWork.SectionCodes = null;													
			}
			else
			{
				orderListCndtnWork.SectionCodes = new string[] { this.tEdit_SectionCodeAllowZero.Text };			
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.11 TOKUNAGA MODIFY START
            //orderListCndtnWork.St_OrderDataCreateDate = DateTime.MinValue;	// 開始発注データ作成日
            //orderListCndtnWork.Ed_OrderDataCreateDate = DateTime.MinValue;	// 終了発注データ作成日
            orderListCndtnWork.St_OrderDataCreateDate = tDateEdit_InputDateSt.GetDateTime();	// 開始発注データ作成日
            orderListCndtnWork.Ed_OrderDataCreateDate = tDateEdit_InputDateEd.GetDateTime();	// 終了発注データ作成日
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.11 TOKUNAGA MODIFY END

            //orderListCndtnWork.OrderNumber = this.tEdit_OrderNumber.Text.Trim();						// 発注番号の指定 // DEL 2009/02/05
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            ////orderListCndtnWork.St_OrderFormPrintDate = this.tDateEdit_SalesOrderDateSt.GetDateTime();	// 開始発注書発行日
            ////orderListCndtnWork.Ed_OrderFormPrintDate = this.tDateEdit_SalesOrderDateEd.GetDateTime();	// 終了発注書発行日
            //orderListCndtnWork.St_ExpectDeliveryDate = DateTime.MinValue;								// 開始希望納期
            //orderListCndtnWork.Ed_ExpectDeliveryDate = DateTime.MinValue;								// 終了希望納期
            //orderListCndtnWork.OrderFormIssuedDivs = new int[] { 1, 0 };								// 発注書発行済み区分（複数指定）
            //orderListCndtnWork.StockOrderDivCds = new int[] { 1, 0 };									// 仕入在庫取寄せ区分（複数指定）
            //orderListCndtnWork.ArrivalStateDivs = new int[] { 0, 1 };									// 入荷状況区分（複数指定）
            //orderListCndtnWork.St_StockAgentCode = this.tEdit_StockAgentCode.Text;						// 開始仕入担当者コード
            //orderListCndtnWork.Ed_StockAgentCode = this.tEdit_StockAgentCode.Text;						// 終了仕入担当者コード
            //orderListCndtnWork.St_StockInputCode = this.tEdit_StockInputCode.Text;						// 開始仕入入力者コード
            //orderListCndtnWork.Ed_StockInputCode = this.tEdit_StockInputCode.Text;						// 終了仕入入力者コード
            //orderListCndtnWork.St_SupplierCd = this.tNedit_SupplierCd.GetInt();						// 開始仕入先コード
            //orderListCndtnWork.Ed_SupplierCd = ( this.tNedit_SupplierCd.GetInt() == 0 ) ? 999999999 : this.tNedit_SupplierCd.GetInt();	// 終了仕入先コード
            //orderListCndtnWork.St_WarehouseCode = String.Empty;											// 開始倉庫コード
            //orderListCndtnWork.Ed_WarehouseCode = String.Empty;											// 終了倉庫コード
            //orderListCndtnWork.St_GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();						// 開始商品メーカーコード
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            ////orderListCndtnWork.St_EnterpriseGanreCode = 0;
            ////orderListCndtnWork.Ed_EnterpriseGanreCode = 999999;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            //orderListCndtnWork.Ed_GoodsMakerCd = ( this.tNedit_GoodsMakerCd.GetInt() == 0 ) ? 999999 : this.tNedit_GoodsMakerCd.GetInt();	// 終了商品メーカーコード
            //orderListCndtnWork.St_GoodsNo = this.tEdit_GoodsNo.Text;									// 開始商品番号
            //orderListCndtnWork.Ed_GoodsNo = this.tEdit_GoodsNo.Text;									// 終了商品番号
            ////orderListCndtnWork.DebitNoteDivs = new int[] { 0, 1, 2 };									// 赤伝区分(複数指定)
            //orderListCndtnWork.DebitNoteDivs = null;													// 赤伝区分(複数指定)
            ////orderListCndtnWork.SupplierSlipCds = new int[] { 10, 20 };									// 仕入伝票区分(複数指定)
            //orderListCndtnWork.SupplierSlipCds = null;													// 仕入伝票区分(複数指定)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            string searchText;
            int searchType;

            orderListCndtnWork.St_OrderDataCreateDate = this.tDateEdit_SalesOrderDateSt.GetDateTime();	// 開始発注書発行日
            orderListCndtnWork.Ed_OrderDataCreateDate = this.tDateEdit_SalesOrderDateEd.GetDateTime();	// 終了発注書発行日
            orderListCndtnWork.St_InputDay = this.tDateEdit_InputDateSt.GetDateTime(); // 開始入力日
            orderListCndtnWork.Ed_InputDay = this.tDateEdit_InputDateEd.GetDateTime(); // 終了入力日
            orderListCndtnWork.AddUpRemDiv = (int)tComboEditor_AddUpRemDiv.Value; // 入荷状況
            orderListCndtnWork.StockAgentCode = this.tEdit_StockAgentCode.Text;						// 開始仕入担当者コード
            orderListCndtnWork.StockInputCode = this.tEdit_StockInputCode.Text;						// 開始仕入入力者コード
            orderListCndtnWork.SupplierCd = this.tNedit_SupplierCd.GetInt();						// 開始仕入先コード
            // 2009.03.03 30413 犬飼 倉庫コードを検索条件に追加 >>>>>>START
            //orderListCndtnWork.WarehouseCode = String.Empty;											// 開始倉庫コード
            orderListCndtnWork.WarehouseCode = this.tEdit_WarehouseCode.Text;							// 開始倉庫コード
            // 2009.03.03 30413 犬飼 倉庫コードを検索条件に追加 <<<<<<END
            orderListCndtnWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();						// 開始商品メーカーコード

            // 品番
            // 2008.11.19 modify start [7964]
            if (!this.tEdit_GoodsNo.Text.Trim().Equals("*"))
            {
                GetSearchType(this.tEdit_GoodsNo.Text, out searchText, out searchType);
                orderListCndtnWork.GoodsNo = searchText;
                orderListCndtnWork.GoodsNoSrchTyp = searchType;
            }
            
            // 品名
            if (!this.tEdit_GoodsName.Text.Trim().Equals("*"))
            {
                GetSearchType(this.tEdit_GoodsName.Text, out searchText, out searchType);
                orderListCndtnWork.GoodsName = searchText;
                orderListCndtnWork.GoodsNameSrchTyp = searchType;
            }
            // 2008.11.19 modify end [7964]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

            // 検索区分を設定
            orderListCndtnWork.SearchDiv = this._searchDiv;

			this._detailForm._orderListCndtnWork = orderListCndtnWork;
		}

        /// <summary>
        /// Valueチェック処理（int）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        /// <remarks>
        /// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer	: 21024　佐々木 健</br>
        /// <br>Date		: 2007.10.15</br>
        /// </remarks>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                dest = Convert.ToInt32(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// 画面名称リスト取得処理
        /// </summary>
        /// <returns>画面名称値リスト</returns>
        private SortedList GetDisplayNameList()
        {
            SortedList nameList = new SortedList();

			nameList.Add("SectionNm", this.uLabel_SectionNm.Text);
			nameList.Add("SupplierName", this.uLabel_SupplierName.Text);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //nameList.Add("GoodsName", this.uLabel_GoodsName.Text);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			nameList.Add("MakerName", this.uLabel_MakerName.Text);
			nameList.Add("StockAgentName", this.uLabel_StockAgentName.Text);
			nameList.Add("StockInputName", this.uLabel_StockInputName.Text);
            return nameList;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        /// <summary>
        /// 発注先情報設定処理
        /// </summary>
        /// <param name="supplierCode">発注先コード</param>
        /// <param name="errorDsp">true:得意先マスタ読み込みエラー時メッセージ表示する</param>
        /// <returns></returns>
        /// <remarks>項目名は発注先だが仕入先</remarks>
        private bool SettingCustomerInfo( int supplierCode, bool errorDsp )
        {
            bool ret = false;
            Supplier supplierInfo;
            SupplierAcs supplierInfoAcs = new SupplierAcs();
            int status = supplierInfoAcs.Read( out supplierInfo, this._enterpriseCode, supplierCode );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInfo != null && supplierInfo.LogicalDeleteCode == 0 )
            {
                // 仕入先コード・名称セット
                this._orderListCndtnCache_Display.SupplierCd = supplierInfo.SupplierCd;
                ret = true;

                this.tNedit_SupplierCd.SetInt( supplierCode );
                this.uLabel_SupplierName.Text = supplierInfo.SupplierSnm;
            }
            else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
            {
                if ( errorDsp )
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "仕入先が存在しません。",
                        -1,
                        MessageBoxButtons.OK );
                }

                this.uLabel_SupplierName.Text = "";
            }
            else
            {
                if ( errorDsp )
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "仕入先の取得に失敗しました。",
                        status,
                        MessageBoxButtons.OK );
                }
                this.uLabel_SupplierName.Text = "";
            }

            return ret;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// 発注先情報設定処理
        ///// </summary>
        ///// <param name="supplierCode">発注先コード</param>
        ///// <param name="errorDsp">true:得意先マスタ読み込みエラー時メッセージ表示する</param>
        ///// <returns></returns>
        ///// <remarks>項目名は発注先だが仕入先</remarks>
        //private bool SettingCustomerInfo( int supplierCode, bool errorDsp)
        //{
        //    bool ret = false;
        //    Supplier supplierInfo;
        //    //CustomerInfo customerInfo;
        //    //CustSuppli custSuppli;
        //    SupplierAcs supplierInfoAcs = new SupplierAcs();
        //    //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
        //    int status = supplierInfoAcs.Read(out supplierInfo, this._enterpriseCode, supplierCode);
        //    //int status = customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, supplierCode, true, out customerInfo, out custSuppli);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        if (supplierInfo == null)
        //        {
        //            if (errorDsp)
        //            {
        //                TMsgDisp.Show(
        //                    this,
        //                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                    this.Name,
        //                    "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
        //                    status,
        //                    MessageBoxButtons.OK);
        //            }
        //            ret = false;
        //        }
        //        else
        //        {
        //            // 仕入先コード・名称セット
        //            this._orderListCndtnCache_Display.St_SupplierCd = supplierInfo.SupplierCd;
        //            this._orderListCndtnCache_Display.Ed_SupplierCd = supplierInfo.SupplierCd;

        //            ret = true;
        //        }
        //        //if (custSuppli == null)
        //        //{
        //        //    if (errorDsp)
        //        //    {
        //        //        TMsgDisp.Show(
        //        //            this,
        //        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //        //            this.Name,
        //        //            "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
        //        //            status,
        //        //            MessageBoxButtons.OK);
        //        //    }
        //        //    customerInfo = new CustomerInfo();
        //        //    ret = false;
        //        //}
        //        //else
        //        //{
        //        //    // 仕入先コード・名称セット
        //        //    this._orderListCndtnCache_Display.St_SupplierCd = customerInfo.CustomerCode;
        //        //    this._orderListCndtnCache_Display.Ed_SupplierCd = customerInfo.CustomerCode;

        //        //    ret = true;
        //        //}
        //        this.tNedit_SupplierCd.SetInt(supplierCode);
        //        //this.uLabel_SupplierName.Text = customerInfo.CustomerSnm;
        //        this.uLabel_SupplierName.Text = supplierInfo.SupplierSnm;
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        if (errorDsp)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_INFO,
        //                this.Name,
        //                "仕入先が存在しません。",
        //                -1,
        //                MessageBoxButtons.OK);
        //        }

        //        this.uLabel_SupplierName.Text = "";
        //    }
        //    else
        //    {
        //        if (errorDsp)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_STOPDISP,
        //                this.Name,
        //                "仕入先の取得に失敗しました。",
        //                status,
        //                MessageBoxButtons.OK);
        //        }
        //        this.uLabel_SupplierName.Text = "";
        //    }

        //    return ret;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        public Control SetInitFocus(object sender)
        {
			if (this._supplierCode == 0)
			{
				this.tNedit_SupplierCd.Focus();
			}
			else
			{
                //this.tEdit_OrderNumber.Focus(); // DEL 2009/02/05
                this.tComboEditor_AddUpRemDiv.Focus(); // ADD 2009/02/05
			}
			return this.tNedit_SupplierCd;
        }
       
        /// <summary>
        /// 画面終了処理
        /// </summary>
        public void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        private Control CheckInputPara()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //// 大小チェック
            //// 発注日
            //if (( this.tDateEdit_SalesOrderDateSt.LongDate != 0 ) && ( this.tDateEdit_SalesOrderDateEd.LongDate != 0 ))
            //{
            //    if (this.tDateEdit_SalesOrderDateSt.LongDate > this.tDateEdit_SalesOrderDateEd.LongDate)
            //    {
            //        this.tDateEdit_SalesOrderDateSt.Focus();
            //        SetStatusBarMessage(this, MESSAGE_StartEndError);
            //        return tDateEdit_SalesOrderDateSt;
            //    }
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.11 TOKUNAGA ADD START
            //// 入力日
            //if ((this.tDateEdit_InputDateSt.LongDate != 0) && (this.tDateEdit_InputDateEd.LongDate != 0))
            //{
            //    if (this.tDateEdit_InputDateSt.LongDate > this.tDateEdit_InputDateEd.LongDate)
            //    {
            //        this.tDateEdit_InputDateSt.Focus();
            //        SetStatusBarMessage(this, MESSAGE_StartEndError);
            //        return tDateEdit_InputDateSt;
            //    }
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.11 TOKUNAGA ADD END

            //// 有効チェック
            //DateTime retDateTime = new DateTime();

            //// 開始日
            //if (this.tDateEdit_SalesOrderDateSt.LongDate != 0)
            //{
            //    if (DateTime.TryParse(this.tDateEdit_SalesOrderDateSt.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            //    {
            //        this.tDateEdit_SalesOrderDateSt.Focus();
            //        SetStatusBarMessage(this, MESSAGE_InvalidDate);
            //        return tDateEdit_SalesOrderDateSt;
            //    }
            //}

            //if (this.tDateEdit_SalesOrderDateEd.LongDate != 0)
            //{
            //    if (DateTime.TryParse(this.tDateEdit_SalesOrderDateEd.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            //    {
            //        this.tDateEdit_SalesOrderDateEd.Focus();
            //        SetStatusBarMessage(this, MESSAGE_InvalidDate);
            //        return tDateEdit_SalesOrderDateEd;
            //    }
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.11 TOKUNAGA ADD START
            //if (this.tDateEdit_InputDateSt.LongDate != 0)
            //{
            //    if (DateTime.TryParse(this.tDateEdit_InputDateSt.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            //    {
            //        this.tDateEdit_InputDateSt.Focus();
            //        SetStatusBarMessage(this, MESSAGE_InvalidDate);
            //        return tDateEdit_InputDateSt;
            //    }
            //}

            //if (this.tDateEdit_InputDateEd.LongDate != 0)
            //{
            //    if (DateTime.TryParse(this.tDateEdit_InputDateEd.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
            //    {
            //        this.tDateEdit_InputDateEd.Focus();
            //        SetStatusBarMessage(this, MESSAGE_InvalidDate);
            //        return tDateEdit_InputDateEd;
            //    }
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.11 TOKUNAGA ADD END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            string kbnNm = uLabel_Date1Title.Text;
            string errMessage = string.Empty;
            Control errComponent = null;
            DateGetAcs.CheckDateRangeResult cdrResult;

            // 発注日付（開始～終了）
            //if ( CallCheckDateRange( out cdrResult, ref tDateEdit_SalesOrderDateSt, ref tDateEdit_SalesOrderDateEd, false, 3 ) == false ) // DEL 2009/04/03
            if (CallCheckDateRangeAllowNoInput(out cdrResult, ref tDateEdit_SalesOrderDateSt, ref tDateEdit_SalesOrderDateEd) == false) // ADD 2009/04/03
            {
                switch ( cdrResult )
                {
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format( "開始" + kbnNm + "{0}", ct_NoInput );
                    //        errComponent = this.tDateEdit_SalesOrderDateSt;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format( "開始" + kbnNm + "{0}", ct_InputError );
                            errComponent = this.tDateEdit_SalesOrderDateSt;
                        }
                        break;
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format( "終了" + kbnNm + "{0}", ct_NoInput );
                    //        errComponent = this.tDateEdit_SalesOrderDateEd;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format( "終了" + kbnNm + "{0}", ct_InputError );
                            errComponent = this.tDateEdit_SalesOrderDateEd;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        // --- ADD 2009/04/03 -------------------------------->>>>>
                        {
                            errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                            errComponent = this.tDateEdit_SalesOrderDateSt;
                        }
                        break;
                    // --- ADD 2009/04/03 --------------------------------<<<<<
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        // 2008.11.17 modify start [7915]
                    //        //errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                    //        errMessage = string.Format(kbnNm + "{0}", ct_RangeOverError);
                    //        // 2008.11.17 modify end [7915]
                    //        errComponent = this.tDateEdit_SalesOrderDateSt;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                }
                errComponent.Focus();
                // 2008.12.03 modify start [7915]
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    errMessage , 0, MessageBoxButtons.OK);
                //SetStatusBarMessage( this, errMessage );
                // 2008.12.03 modify end [7915]
                return errComponent;
            }
            // 入力日付（開始～終了）,
            if ( CallCheckDateRangeAllowNoInput( out cdrResult, ref tDateEdit_InputDateSt, ref tDateEdit_InputDateEd ) == false )
            {
                switch ( cdrResult )
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format( "開始入力日{0}", ct_InputError );
                            errComponent = this.tDateEdit_InputDateSt;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format( "終了入力日{0}", ct_InputError );
                            errComponent = this.tDateEdit_InputDateEd;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format( "入力日{0}", ct_RangeError );
                            errComponent = this.tDateEdit_InputDateSt;
                        }
                        break;
                }
                errComponent.Focus();
                // 2008.12.03 modify start [7915]
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    errMessage, 0, MessageBoxButtons.OK);
                //SetStatusBarMessage( this, errMessage );
                // 2008.12.03 modify end [7915]
                return errComponent;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

			return null;
        }

        /// <summary>
        /// 伝票検索実行処理
        /// </summary>
        private Control SearchData()
        {
			// 入力項目チェック処理
			Control control = this.CheckInputPara();

			if (control != null)
			{
				return control;
			}

			OrderListCndtnWork orderListCndtnWork = new OrderListCndtnWork();
			bool setEnable = false;

			// 読込条件パラメータクラス設定処理
			this.SetReadPara(out orderListCndtnWork);

			// 伝票情報読込・データセット格納処理
			this._orderRemainReferenceAcs.SetSearchData(orderListCndtnWork);

			setEnable = this._detailForm.SetGridEnable();

			if (setEnable == true)
			{
				this._detailForm.uGrid_Details.Focus();
				this._detailForm.timer_GridSetFocus.Enabled = true;
				this._printButton.SharedProps.Enabled = true;
				this._previewButton.SharedProps.Enabled = true;
			}
			else
			{
				this._printButton.SharedProps.Enabled = false;
				this._previewButton.SharedProps.Enabled = false;
			}


			return null;
        }

		/// <summary>
		/// 印刷処理
		/// </summary>
		private void Print(bool preview)
		{
			SFCMN06002C printInfo = new SFCMN06002C();
			if (this._printControl == null)
				this._printControl = new DCCMN04000UA();

			printInfo.printmode = ( preview ) ? 2 : 3;
			printInfo.pdfopen = false;
			printInfo.pdftemppath = "";

			// 直接印刷バージョン
			printInfo.enterpriseCode = this._enterpriseCode;
			printInfo.kidopgid = "DCHAT04110U";				// 起動PGID

			OrderListCndtnWork cndtn = this._orderRemainReferenceAcs.GetOrderListCndtnCache();
			// PDF出力履歴用
			printInfo.key = "f98bd70a-5c60-4ed4-b958-90300e0b0767";
			printInfo.prpnm = "";
			printInfo.PrintPaperSetCd = 0;

			printInfo.jyoken = cndtn;

			printInfo.rdData = this._orderRemainReferenceAcs.DataSet.Tables[0];

			int status = _printControl.Print(printInfo);

			if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				if (preview)
				{
					this._printControl.PDFViewer.Dock = DockStyle.Fill;
					this.uTab_View.Controls.Add(this._printControl.PDFViewer);
					this.uTabControl.Tabs[cTAB_PREVIEW].Visible = true;
					this.uTabControl.SelectedTab = this.uTabControl.Tabs[cTAB_PREVIEW];
				}
			}
		}

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        public void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

#if False
        /// <summary>
        /// 検索条件クラス(変更判断用) クリア処理
        /// </summary>
        private void ClearParaStockSlip_Display()
        {
            // 検索条件値
            if (_paraStockSlipCache_Display == null)
            {
                return;
            }
            _paraStockSlipCache_Display.CustomerCode = 0;      // 仕入先
            //_paraStockSlipCache_Display.CarrierEpCode = 0;     // 事業者
            _paraStockSlipCache_Display.StockAgentCode = "";   // 担当者
            _paraStockSlipCache_Display.WarehouseCode = "";    // 倉庫
            _paraStockSlipCache_Display.SectionCd = "";   // 拠点
            _paraStockSlipCache_Display.GoodsNo = "";        // 商品
        }
#endif

#if False
        /// <summary>
        /// 前回/今回検索条件比較処理
        /// </summary>
        /// <param name="">検索条件クラス(今回条件)</param>
        /// <returns>true:一致、false:不一致</returns>
        private bool CheckSearchParam(StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            // 前回検索条件の取得
            StcHisRefExtraParamWork prevSearchParaStockSlip = this._searchSlipAcs.GetParaStockSlipCache();
            if (prevSearchParaStockSlip == null)
            {
                return false;
            }

            // 仕入形式
            if (stcHisRefExtraParamWork.SupplierFormal != prevSearchParaStockSlip.SupplierFormal)
            {
                return false;
            }

            // 伝票区分
            if (stcHisRefExtraParamWork.SupplierSlipCd != prevSearchParaStockSlip.SupplierSlipCd)
            {
                return false;
            }

            // 赤伝区分
            if (stcHisRefExtraParamWork.DebitNoteDiv != prevSearchParaStockSlip.DebitNoteDiv)
            {
                return false;
            }

            // 商品区分
            if (stcHisRefExtraParamWork.StockGoodsCd != prevSearchParaStockSlip.StockGoodsCd)
            {
                return false;
            }

            // 買掛区分
            if (stcHisRefExtraParamWork.AccPayDivCd != prevSearchParaStockSlip.AccPayDivCd)
            {
                return false;
            }

            // 拠点
            if (stcHisRefExtraParamWork.SectionCd != prevSearchParaStockSlip.StockSectionCd)
            {
                return false;
            }

            // 入荷日
            if ((stcHisRefExtraParamWork.ArrivalGoodsDayStart != prevSearchParaStockSlip.ArrivalGoodsDayStart) ||
                (stcHisRefExtraParamWork.ArrivalGoodsDayEnd != prevSearchParaStockSlip.ArrivalGoodsDayEnd))
            {
                return false;
            }

            // 計上日
            if ((stcHisRefExtraParamWork.StockAddUpADateStart != prevSearchParaStockSlip.StockAddUpADateStart) ||
                (stcHisRefExtraParamWork.StockAddUpADateEnd != prevSearchParaStockSlip.StockAddUpADateEnd))
            {
                return false;
            }

            // 仕入先
            if (stcHisRefExtraParamWork.CustomerCode != prevSearchParaStockSlip.CustomerCode)
            {
                return false;
            }

            // 事業者
            //if (stcHisRefExtraParamWork.CarrierEpCode != prevSearchParaStockSlip.CarrierEpCode)
            //{
            //    return false;
            //}

            // 仕入先担当
            if (stcHisRefExtraParamWork.StockAgentCode != prevSearchParaStockSlip.StockAgentCode)
            {
                return false;
            }

            // 倉庫
            if (stcHisRefExtraParamWork.WarehouseCode != prevSearchParaStockSlip.WarehouseCode)
            {
                return false;
            }

            // 相手先伝番
            if (stcHisRefExtraParamWork.PartySaleSlipNum != prevSearchParaStockSlip.PartySaleSlipNum)
            {
                return false;
            }

			// 伝票番号
			if (stcHisRefExtraParamWork.SupplierSlipNo != prevSearchParaStockSlip.SupplierSlipNo)
			{
				return false;
			}


            // 商品
            if (stcHisRefExtraParamWork.GoodsNo!= prevSearchParaStockSlip.GoodsCode)
            {
                return false;
            }

            return true;
        }
#endif

        /// <summary>
        /// 「確定」ボタン表示変更処理
        /// </summary>
        /// <param name="enable">表示設定(true:表示、false:非表示)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
            this._decisionButton.SharedProps.Enabled = enableSet;
        }



        # region 各コントロールイベント処理

		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DCHAT04110UA_Load( object sender, EventArgs e )
		{
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();
			//this.Form1_Fill_Panel.Visible = false;

			// スキン変更除外設定
			List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add( this.Standard_UGroupBox.Name );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            excCtrlNm.Add( this.uGroupBox_Detail.Name );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
			//excCtrlNm.Add(this.Detail_UGroupBox.Name);
			this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);
			this._controlScreenSkin.SettingScreenSkin(this._detailForm);

			// DCHAT04110UB を、panel_Detailを親としたコントロールにする
			this._detailForm.IsMultiSelect = this._isMultiSelect;
			this._detailForm.IsSelect = ( this._displayType == DisplayType.DisplayAndSelect ) ? true : false;
			this._detailForm.DisplayModeSetting();
			this.panel_Detail.Controls.Add(this._detailForm);
			this._detailForm.Dock = DockStyle.Fill;

			// ボタン初期設定処理
			this.ButtonInitialSetting();

			if (this._isCacheClear)
			{
				// 検索条件、検索結果のキャッシュをクリアする
				this._orderRemainReferenceAcs.ClearOrderListResultDataTable();
			}

			// 画面初期情報設定処理
			this.SetInitialInput();

			this.uTabControl.Tabs[cTAB_PREVIEW].Visible = false;

			//this.Form1_Fill_Panel.Visible = true;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            if ( !_isMultiSelect )
            {
                this.MaxSelectCount = 1;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
		}

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // 終了処理
                        this.CloseForm();
                        break;
                    }
				case "ButtonTool_Decision":
					{
                        // --- ADD 2009/02/16 障害ID:11548対応------------------------------------------------------>>>>>
                        if (this._isMultiWarehouseSelect == false)
                        {
                            Dictionary<string, OrderListResultWork> warehouseDic = new Dictionary<string, OrderListResultWork>();
                            foreach (OrderListResultWork result in orderListResultWorkList)
                            {
                                if (!warehouseDic.ContainsKey(result.WarehouseCode.Trim()))
                                {
                                    warehouseDic.Add(result.WarehouseCode.Trim(), result);
                                }
                            }

                            if (warehouseDic.Count > 1)
                            {
                                TMsgDisp.Show(this, 
                                              emErrorLevel.ERR_LEVEL_INFO, 
                                              this.Name,
                                              "異なる倉庫の選択はできません。", 
                                              0, 
                                              MessageBoxButtons.OK);

                                return;
                            }
                        }
                        // --- ADD 2009/02/16 障害ID:11548対応------------------------------------------------------<<<<<

						this.SetDialogRes(DialogResult.OK);
						this.CloseForm();
						break;
					}
                case "ButtonTool_Undo":
                    {
                        // 元に戻す処理
                        this.ClearDisplayHeader();
                        this.SetDisplayHeaderInfo();
                        this._orderRemainReferenceAcs.ClearOrderListResultDataTable();
						this._printButton.SharedProps.Enabled = false;
						this._previewButton.SharedProps.Enabled = false;

                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        SearchData();

                        break;
                    }
				case "ButtonTool_Print":
					{
						// 印刷処理
						Print(false);

						break;
					}
				case "ButtonTool_Preview":
					{
						// 印刷処理
						Print(true);
						break;
					}
			}
        }

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Search_Button_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void SetStatusBarMessage(object sender, string message)
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SetStatusBarMessage(this, "");

            // フォーカス制御 ============================================ //
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //if (
            //    (e.PrevCtrl == this.tEdit_StockInputCode) ||
            //    (e.PrevCtrl == this.uButton_EmployeeGuide))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        e.NextCtrl = this._detailForm.uGrid_Details; ;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

            if (((e.PrevCtrl.Parent.Parent == this.Standard_UGroupBox) //||
                //(e.PrevCtrl.Parent.Parent == this.Detail_UGroupBox)
				//|| (e.PrevCtrl.Parent.Parent == this.Select_UGroupBox)
				) &&
                ((e.NextCtrl.Parent == this.panel_Detail) ||
                 (e.NextCtrl == this._detailForm.uGrid_Details)))
            {
                //Control control = SearchData();
                //if ((this._detailForm.uGrid_Details.Rows.Count > 0) &&
                //   (this._detailForm.uGrid_Details.Enabled == true))
                //{
                //    e.NextCtrl = this._detailForm.uGrid_Details;
                //}
                //else
                //{
                //    if (control == null)
                //    {
                //        e.NextCtrl = e.PrevCtrl;
                //    }
                //    else
                //    {
                //        e.NextCtrl = control;
                //    }
                //}
            }
			else if ( e.PrevCtrl == this._detailForm.UnSelect_Button )
			{
				switch (e.Key)
				{
					case Keys.Up:
						{
							e.NextCtrl = this.tDateEdit_SalesOrderDateSt;
							break;
						}
					case Keys.Left:
						{
							e.NextCtrl = e.PrevCtrl;
							break;
						}
					default:
						{
							break;
						}
				}
			}
			else if (e.PrevCtrl == this._detailForm.Select_Button)
			{
				switch (e.Key)
				{
					case Keys.Up:
						{
							e.NextCtrl = this.tDateEdit_SalesOrderDateSt;
							break;
						}
					case Keys.Right:
						{
							e.NextCtrl = this._detailForm.uGrid_Details;
							break;
						}
					default:
						{
							break;
						}
				}
			}

			// 入力支援 ============================================ //
			//// 入荷日
			//if ((e.PrevCtrl == this.tDateEdit_SalesOrderDate) ||
			//    (e.PrevCtrl == this.tDateEdit_Date1End))
			//{
			//    AutoSetEndValue(this.tDateEdit_SalesOrderDate,this.tDateEdit_Date1End);
			//}

			// 名称取得 ============================================ //
            switch (e.PrevCtrl.Name)
			{

				#region 拠点
				// 拠点
				case "tEdit_SectionCodeAllowZero":
					{
						bool canChangeFocus = true;
						string code = this.tEdit_SectionCodeAllowZero.Text.Trim();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                        //string name = "";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        string name = uLabel_SectionNm.Text.Trim();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        // 拠点コードゼロ取得
                        string sectionCodeZero = this.GetSectionCodeZero();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

						//if (this._orderListCndtnCache_Display.SectionCodes[0].Trim() != code)
						if (( this._orderListCndtnCache_Display.SectionCodes.Length == 0 ) ||
							( ( this._orderListCndtnCache_Display.SectionCodes.Length > 0 ) && ( this._orderListCndtnCache_Display.SectionCodes[0].Trim() != code ) ))
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                            //if (code == "")
                            //{
                            //    this._orderListCndtnCache_Display.SectionCodes = new string[] { };
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            if ( code.Trim() == sectionCodeZero.Trim() )
                            {
                                this._orderListCndtnCache_Display.SectionCodes = new string[] { };
                                code = sectionCodeZero;
                                name = ct_AllSectionName;
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
							else
							{
								SecInfoSet secInfoSet = new SecInfoSet();
								SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
								int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, code);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									name = secInfoSet.SectionGuideNm;
									this._orderListCndtnCache_Display.SectionCodes = new string[] { code };
								}
								else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"拠点が存在しません。",
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;

								}
								else
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_STOPDISP,
										this.Name,
										"拠点の取得に失敗しました。",
										status,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
							}
							// 拠点コード・名称セット
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                            //this.tEdit_SectionCodeAllowZero.Text = code;
                            //this.uLabel_SectionNm.Text = name;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            if ( _orderListCndtnCache_Display.SectionCodes != null && _orderListCndtnCache_Display.SectionCodes.Length > 0 )
                            {
                                this.tEdit_SectionCodeAllowZero.Text = _orderListCndtnCache_Display.SectionCodes[0];
                                this.uLabel_SectionNm.Text = name;
                            }
                            else
                            {
                                this.tEdit_SectionCodeAllowZero.Text = sectionCodeZero;
                                this.uLabel_SectionNm.Text = ct_AllSectionName;
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                            //e.NextCtrl = this.uButton_SectionGuide;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                            if ( tEdit_SectionCodeAllowZero.Text.Trim() == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SupplierCd;
                                            }
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                                            break;
                                        }
                                }
                            }
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            tEdit_SectionCodeAllowZero.SelectAll();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
						}

						break;
					}
				#endregion

				#region 従業員
				// 従業員
				case "tEdit_StockAgentCode":
                    {
						bool canChangeFocus = true;
						string code = this.tEdit_StockAgentCode.Text.Trim();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                        //string name = "";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        string name = uLabel_StockAgentName.Text.Trim();
                        string getName = string.Empty;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                        //if (this._orderListCndtnCache_Display.St_StockAgentCode.Trim() != code)
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        if ( this._orderListCndtnCache_Display.StockAgentCode.Trim() != code )
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
						{
							if (code == "")
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //this._orderListCndtnCache_Display.St_StockAgentCode = code;
                                //this._orderListCndtnCache_Display.Ed_StockAgentCode = code;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                this._orderListCndtnCache_Display.StockAgentCode = code;
                                name = string.Empty;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
							}
							else
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //name = this._orderRemainReferenceAcs.GetName_FromEmployee(code);
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                getName = this._orderRemainReferenceAcs.GetName_FromEmployee( code );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //if (name.Trim() == "")
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                if ( getName.Trim() == string.Empty )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "担当者が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                    //this._orderListCndtnCache_Display.St_StockAgentCode = code;
                                    //this._orderListCndtnCache_Display.Ed_StockAgentCode = code;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                    this._orderListCndtnCache_Display.StockAgentCode = code;
                                    name = getName;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                                }
							}
							// 従業員コード・名称セット
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                            //this.tEdit_StockAgentCode.Text = code;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            this.tEdit_StockAgentCode.Text = _orderListCndtnCache_Display.StockAgentCode;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
							this.uLabel_StockAgentName.Text = name;
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                            //if (this.tEdit_StockAgentCode.Text.Trim() == String.Empty)
                                            //    e.NextCtrl = this.uButton_StockAgentGuide;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                            if ( this.tEdit_StockAgentCode.Text.Trim() == String.Empty )
                                            {
                                                e.NextCtrl = this.uButton_StockAgentGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_StockInputCode;
                                            }
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                                            break;
                                        }
                                }
                            }
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            tEdit_StockAgentCode.SelectAll();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
						}

						break;
					}
				#endregion

				#region 発注者
				// 発注者
				case "tEdit_StockInputCode":
					{
						bool canChangeFocus = true;
						string code = this.tEdit_StockInputCode.Text.Trim();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                        //string name = "";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        string name = uLabel_StockInputName.Text.Trim();
                        string getName = string.Empty;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                        //if (this._orderListCndtnCache_Display.St_StockInputCode.Trim() != code)
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        if ( this._orderListCndtnCache_Display.StockInputCode.Trim() != code )
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
						{
							if (code == "")
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //this._orderListCndtnCache_Display.St_StockInputCode = code;
                                //this._orderListCndtnCache_Display.Ed_StockInputCode = code;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                this._orderListCndtnCache_Display.StockInputCode = code;
                                name = string.Empty;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
							}
							else
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //name = this._orderRemainReferenceAcs.GetName_FromEmployee(code);
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                getName = this._orderRemainReferenceAcs.GetName_FromEmployee( code );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //if (name.Trim() == "")
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                if ( getName.Trim() == "" )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"発注者が存在しません。",
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                    //this._orderListCndtnCache_Display.St_StockInputCode = code;
                                    //this._orderListCndtnCache_Display.Ed_StockInputCode = code;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                    this._orderListCndtnCache_Display.StockInputCode = code;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                    name = getName;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
								}
							}
							// 従業員コード・名称セット
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                            //this.tEdit_StockInputCode.Text = code;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            this.tEdit_StockInputCode.Text = _orderListCndtnCache_Display.StockInputCode;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
							this.uLabel_StockInputName.Text = name;
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                            //if (this.tEdit_StockAgentCode.Text.Trim() == String.Empty)
                                            //    e.NextCtrl = this.uButton_EmployeeGuide;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                            if ( this.tEdit_StockAgentCode.Text.Trim() == String.Empty )
                                            {
                                                e.NextCtrl = this.uButton_EmployeeGuide;
                                            }
                                            else
                                            {
                                                if ( uGroupBox_Detail.Expanded )
                                                {
                                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = _detailForm;
                                                }
                                            }
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                                            break;
                                        }
                                }
                            }
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            tEdit_StockInputCode.SelectAll();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
						}

						break;
					}
				#endregion

				#region メーカー
				// メーカー
				case "tNedit_GoodsMakerCd":
					{
						bool canChangeFocus = true;
						int code = this.tNedit_GoodsMakerCd.GetInt();
						string name = this.uLabel_MakerName.Text;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                        //if (this._orderListCndtnCache_Display.St_GoodsMakerCd != code)
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        if ( this._orderListCndtnCache_Display.GoodsMakerCd != code )
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
						{
							if (code == 0)
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //this._orderListCndtnCache_Display.St_GoodsMakerCd = code;
                                //this._orderListCndtnCache_Display.Ed_GoodsMakerCd = code;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                this._orderListCndtnCache_Display.GoodsMakerCd = code;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                                this.tNedit_GoodsMakerCd.Clear();
								name = "";
							}
							else
							{
								name = this._orderRemainReferenceAcs.GetName_FromGoodsMaker(code);

								if (name.Trim() == "")
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"メーカーが存在しません。",
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                    //this._orderListCndtnCache_Display.St_GoodsMakerCd = code;
                                    //this._orderListCndtnCache_Display.Ed_GoodsMakerCd = code;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                    this._orderListCndtnCache_Display.GoodsMakerCd = code;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
								}
							}
							// メーカーコード・名称セット
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                            //this.tNedit_GoodsMakerCd.SetInt(code);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            this.tNedit_GoodsMakerCd.SetInt( _orderListCndtnCache_Display.GoodsMakerCd );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
							this.uLabel_MakerName.Text = name;
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                            //e.NextCtrl = this.uButton_GoodsMakerGuide;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                            if ( tNedit_GoodsMakerCd.GetInt() == 0 )
                                            {
                                                e.NextCtrl = this.uButton_GoodsMakerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_GoodsNo;
                                            }
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                                            break;
                                        }
                                }
                            }
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
						}

						break;
					}
				#endregion

				#region 仕入先
				// 仕入先
                case "tNedit_SupplierCd":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_SupplierCd.GetInt();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        string name = uLabel_SupplierName.Text;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                        //if (this._orderListCndtnCache_Display.St_SupplierCd != code)
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                        if ( this._orderListCndtnCache_Display.SupplierCd != code )
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                        {
							if (code == 0)
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //this._orderListCndtnCache_Display.St_SupplierCd = code;
                                //this._orderListCndtnCache_Display.Ed_SupplierCd = code;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                this._orderListCndtnCache_Display.SupplierCd = code;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
								this.tNedit_SupplierCd.Clear();
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //this.uLabel_SupplierName.Text = "";
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                name = string.Empty;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
							}
							else
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                //if (!this.SettingCustomerInfo(code, true))
                                //{
                                //    canChangeFocus = false;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD

                                if (_supplierAcs == null)
                                {
                                    _supplierAcs = new SupplierAcs();
                                }
                                Supplier supplier;
                                int status = _supplierAcs.Read( out supplier, this._enterpriseCode, code );

                                if ( status != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "仕入先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                    //this._orderListCndtnCache_Display.St_SupplierCd = supplier.SupplierCd;
                                    //this._orderListCndtnCache_Display.Ed_SupplierCd = supplier.SupplierCd;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                    this._orderListCndtnCache_Display.SupplierCd = supplier.SupplierCd;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                                    name = supplier.SupplierSnm;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
							}
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                            // 仕入先コード・名称セット
                            tNedit_SupplierCd.SetInt( _orderListCndtnCache_Display.SupplierCd );
                            uLabel_SupplierName.Text = name;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
                        }


                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tNedit_SupplierCd.GetInt() == 0 )
                                            {
                                                e.NextCtrl = this.uButton_StockCustomerGuide;
                                            }
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                            else
                                            {
                                                //e.NextCtrl = this.tEdit_OrderNumber; // DEL 2009/02/05
                                                e.NextCtrl = this.tComboEditor_AddUpRemDiv; // ADD 2009/02/05
                                            }
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
					}

				#endregion

				#region 品番
                // 品番
                case "tEdit_GoodsNo":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_GoodsNo.Text.Trim();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                        //string name = this.uLabel_GoodsName.Text.Trim();
                        //bool existFlg = false;

                        //if (this._orderListCndtnCache_Display.St_GoodsNo.Trim() != code)
                        //{
                        //    if (code == "")
                        //    {
                        //        this._orderListCndtnCache_Display.St_GoodsNo = code;
                        //        this._orderListCndtnCache_Display.Ed_GoodsNo = code;
                        //        name = "";
                        //    }
                        //    else
                        //    {
                        //        existFlg = this._orderRemainReferenceAcs.CheckGoodsExist(code, out name);

                        //        if (existFlg == false)
                        //        {
                        //            TMsgDisp.Show(
                        //                this,
                        //                emErrorLevel.ERR_LEVEL_INFO,
                        //                this.Name,
                        //                "商品が存在しません。",
                        //                -1,
                        //                MessageBoxButtons.OK);

                        //            canChangeFocus = false;
                        //        }
                        //        else
                        //        {
                        //            this._orderListCndtnCache_Display.St_GoodsNo = code;
                        //            this._orderListCndtnCache_Display.Ed_GoodsNo = code;
                        //        }
                        //    }
                        //    // 品番・品名セット
                        //    this.tEdit_GoodsNo.Text = code;
                        //    this.uLabel_GoodsName.Text = name;
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL


                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                                            //e.NextCtrl = this.uButton_GoodsGuide;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                                            e.NextCtrl = this.tEdit_GoodsName;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
					}
				#endregion

                // 2009.03.03 30413 犬飼 倉庫ガイドボタンの追加 >>>>>>START
                #region 倉庫
				// 倉庫
                case "tEdit_WarehouseCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_WarehouseCode.Text.Trim();
                        string name = this.uLabel_WarehouseName.Text.Trim();
                        string getName = string.Empty;

                        if (this._orderListCndtnCache_Display.WarehouseCode.Trim() != code)
                        {
                            if (code == "")
                            {
                                this._orderListCndtnCache_Display.WarehouseCode = code;
                                name = string.Empty;
                            }
                            else
                            {
                                getName = this.GetName_Warehouse(code);
                                if (getName.Trim() == string.Empty)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "倉庫が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    this._orderListCndtnCache_Display.WarehouseCode = code;
                                    name = getName;
                                }
                            }
                            // 倉庫コード・名称セット
                            this.tEdit_WarehouseCode.Text = this._orderListCndtnCache_Display.WarehouseCode;
                            this.uLabel_WarehouseName.Text = name;
                        }
                        // NextCtrl制御
                        if (canChangeFocus)
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (this.tEdit_WarehouseCode.Text.Trim() == String.Empty)
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this._detailForm;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            tEdit_WarehouseCode.SelectAll();
                        }
                        break;
                    }
                #endregion
                // 2009.03.03 30413 犬飼 倉庫ガイドボタンの追加 <<<<<<END
            
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            // 特殊フォーカス制御
            _irrFocusCtrl.ReflectIrregularNextControl( e );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

            // RetKeyControl用処理
            if ((e.Key == Keys.Return) ||
                (e.Key == Keys.Tab))
            {
                // MAKON01320UBのグリッドでのEnterキー押下処理で、MAKON01320UAのtRetKeyControlに制御を奪われるため
                // イベントが発生しなくなる現象の回避策
                if (e.PrevCtrl == this._detailForm.uGrid_Details)
                {
                    // グリッド上でのEnterキー押下では、他コントロールにフォーカスを移さない
                    e.NextCtrl = e.PrevCtrl;
					if (this._displayType != DisplayType.DisplayOnly)
					{
						// グリッド行選択処理タイマー発動
						this._detailForm.timer_SelectRow.Enabled = true;
					}
                }
				if (e.NextCtrl.Parent == this.panel_Detail)
				{
					Control control = SearchData();

					if (( this._detailForm.uGrid_Details.Rows.Count > 0 ) &&
					   ( this._detailForm.uGrid_Details.Enabled == true ))
					{
						e.NextCtrl = this._detailForm.uGrid_Details;
					}
					else
					{
						if (control == null)
						{
							e.NextCtrl = e.PrevCtrl;
						}
						else
						{
							e.NextCtrl = control;
						}
					}
				}
            }
        }

		/// <summary>
		/// 選択行変更イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SelectedRowChanged( object sender, EventArgs e )
		{
			int selectedCount = this._orderRemainReferenceAcs.GetSelectedRowCount();

			if (selectedCount > 0)
			{
				this._decisionButton.SharedProps.Enabled = true;
			}
			else
			{
				this._decisionButton.SharedProps.Enabled = false;
			}
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            // 表示更新
            _detailForm.SetSelectedCount( selectedCount );

            // 変更結果を取得する
            if ( _orderRemainReferenceAcs.RowChangeStatus == false )
            {
                SetStatusBarMessage( this, "選択可能数を超えています。" );
            }
            else
            {
                SetStatusBarMessage( this, "" );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
		}

        /// <summary>
        /// 初期フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;

            this.SetInitFocus(this);
            this._detailForm.uGrid_Details.Enabled = false;
        }

        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void DCHAT04110UA_FormClosed(object sender, FormClosedEventArgs e)
        {
			if (this._printControl != null)
			{
				this._printControl.Dispose();
			}

            DialogResult = _dialogRes;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DCHAT04110UA_FormClosing( object sender, FormClosingEventArgs e )
		{
			try
			{
				this._detailForm.Closing();
			}
			catch (NullReferenceException)
			{
				//
			}

		}


        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionNm.Text = secInfoSet.SectionGuideNm.Trim();
				this._orderListCndtnCache_Display.SectionCodes = new string[] { secInfoSet.SectionCode.Trim() };

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                // 次フォーカス
                tNedit_SupplierCd.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
            }
        }


        /// <summary>
        /// 従業員ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
				if (sender == uButton_StockAgentGuide)
				{
					tEdit_StockAgentCode.Text = employee.EmployeeCode.Trim();
					uLabel_StockAgentName.Text = employee.Name.Trim();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                    //this._orderListCndtnCache_Display.St_StockAgentCode = employee.EmployeeCode.Trim();
                    //this._orderListCndtnCache_Display.Ed_StockAgentCode = employee.EmployeeCode.Trim();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                    this._orderListCndtnCache_Display.StockAgentCode = employee.EmployeeCode.Trim();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                    // 次フォーカス
                    tEdit_StockInputCode.Focus();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
				}
				else
				{
					tEdit_StockInputCode.Text = employee.EmployeeCode.Trim();
					uLabel_StockInputName.Text = employee.Name.Trim();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                    //this._orderListCndtnCache_Display.St_StockInputCode = employee.EmployeeCode.Trim();
                    //this._orderListCndtnCache_Display.Ed_StockInputCode = employee.EmployeeCode.Trim();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                    this._orderListCndtnCache_Display.StockInputCode = employee.EmployeeCode.Trim();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                    // 次フォーカス
                    if ( uGroupBox_Detail.Expanded )
                    {
                        tNedit_GoodsMakerCd.Focus();
                    }
                    else
                    {
                        _detailForm.Focus();
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
				}
                //this._orderListCndtnCache_Display.StockAgentCode = employee.EmployeeCode.Trim();
            }
        }

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_StockCustomerGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            if ( _supplierAcs == null )
            {
                _supplierAcs = new SupplierAcs();
            }

            Supplier supplier;
            int status = _supplierAcs.ExecuteGuid( out supplier, this._enterpriseCode, string.Empty );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                tNedit_SupplierCd.SetInt( supplier.SupplierCd );
                // 2008.11.21 add start [7941]
                this._orderListCndtnCache_Display.SupplierCd = supplier.SupplierCd;
                // 2008.11.21 add end [7941]
                uLabel_SupplierName.Text = supplier.SupplierSnm.Trim();

                // 次フォーカス
                //tEdit_OrderNumber.Focus(); // DEL 2009/02/05
                this.tComboEditor_AddUpRemDiv.Focus(); // ADD 2009/02/05
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
        }

		/// <summary>
		/// メーカーガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;
			int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //tNedit_GoodsMakerCd.Text = makerUMnt.GoodsMakerCd.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                tNedit_GoodsMakerCd.SetInt( makerUMnt.GoodsMakerCd );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
				uLabel_MakerName.Text = makerUMnt.MakerName.Trim();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //this._orderListCndtnCache_Display.St_GoodsMakerCd = makerUMnt.GoodsMakerCd;
                //this._orderListCndtnCache_Display.Ed_GoodsMakerCd = makerUMnt.GoodsMakerCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                this._orderListCndtnCache_Display.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                // 次フォーカス
                tEdit_GoodsNo.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
			}
		}

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            Warehouse wareHouse = new Warehouse();
            if (this._warehouseAcs == null)
            {
                this._warehouseAcs = new WarehouseAcs();
            }

            status = this._warehouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_WarehouseCode.Text = wareHouse.WarehouseCode.Trim();         // 倉庫コード
                this.uLabel_WarehouseName.Text = wareHouse.WarehouseName.Trim();        // 倉庫名称

                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// 商品ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="message">メッセージ</param>
        //private void uButton_GoodsGuide_Click(object sender, EventArgs e)
        //{
        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //    GoodsUnitData goodsUnitData;
        //    DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

        //    if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
        //    {
        //        // 商品コード設定処理
        //        this.tEdit_GoodsNo.Text = goodsUnitData.GoodsNo;
        //        this.uLabel_GoodsName.Text = goodsUnitData.GoodsName;
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// 得意先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustSuppli custSuppli;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        if (custSuppli == null)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
        //                status,
        //                MessageBoxButtons.OK);

        //            return;
        //        }
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した仕入先は既に削除されています。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    this.tNedit_SupplierCd.SetInt(customerSearchRet.CustomerCode);
        //    this.uLabel_SupplierName.Text = customerSearchRet.Snm;
        //    this._orderListCndtnCache_Display.St_SupplierCd = customerSearchRet.CustomerCode;
        //    this._orderListCndtnCache_Display.Ed_SupplierCd = customerSearchRet.CustomerCode;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        /// <summary>
        /// 前回月次締処理日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay( string sectionCode )
        {
            DateTime prevTotalDay;
            int status = _totalDayCalculator.GetHisTotalDayMonthlyAccPay( sectionCode.Trim(), out prevTotalDay );

            // 取得日が不正な場合は３ヶ月前をセット
            if ( status != 0 || prevTotalDay == DateTime.MinValue || prevTotalDay > DateTime.Today )
            {
                prevTotalDay = DateTime.Today.AddMonths( -3 );
            }
            // 翌日取得
            prevTotalDay = prevTotalDay.AddDays( 1 );

            return prevTotalDay;
        }
        /// <summary>
        /// 文字列あいまい検索情報取得
        /// </summary>
        /// <param name="originText">元の入力文字列</param>
        /// <param name="searchText">リモートアセンブリに渡す検索文字列</param>
        /// <param name="searchType">リモートアセンブリに渡す検索タイプ</param>
        /// <returns></returns>
        private static void GetSearchType( string originText, out string searchText, out int searchType )
        {
            searchText = originText;
            bool stLike = originText.StartsWith( "*" );
            bool edLike = originText.EndsWith( "*" );

            if ( stLike )
            {
                // 先頭の * を取り除く
                searchText = searchText.Substring( 1 );
            }
            if ( edLike )
            {
                // 末尾の * を取り除く
                searchText = searchText.Substring( 0, searchText.Length - 1 );
            }

            // 先頭＆末尾の*を取り除いてもまだ*がある場合→3:あいまい
            if ( searchText.Contains( "*" ) )
            {
                searchText = searchText.Replace( "*", "" );
                searchType = 3;
                return;
            }


            // 検索タイプの判定
            if ( stLike )
            {
                if ( edLike )
                {
                    // 3:あいまい
                    searchType = 3;
                }
                else
                {
                    // 2:後方一致
                    searchType = 2;
                }
            }
            else
            {
                if ( edLike )
                {
                    // 1:前方一致
                    searchType = 1;
                }
                else
                {
                    // 0:完全一致
                    searchType = 0;
                }
            }
        }
        /// <summary>
        /// 拠点コードゼロ取得処理
        /// </summary>
        /// <returns></returns>
        private string GetSectionCodeZero()
        {
            UiSet uiset;
            uiSetControl1.ReadUISet( out uiset, tEdit_SectionCodeAllowZero.Name );
            if ( uiset != null )
            {
                return new string( '0', uiset.Column );
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St, ref TDateEdit tde_Ed, bool mode, int ym )
        {
            cdrResult = _dateGet.CheckDateRange( DateGetAcs.YmdType.YearMonth, ym, ref tde_St, ref tde_Ed, mode );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        /// <summary>
        /// 日付チェック(未入力可能)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St"></param>
        /// <param name="tde_Ed"></param>
        /// <param name="mode"></param>
        /// <param name="ym"></param>
        /// <returns></returns>
        private bool CallCheckDateRangeAllowNoInput( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St, ref TDateEdit tde_Ed )
        {
            cdrResult = DateGetAcs.CheckDateRangeResult.OK;

            // 開始日
            if ( _dateGet.CheckDate( ref tde_St, true ) == DateGetAcs.CheckDateResult.ErrorOfInvalid )
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid;
                return false;
            }
            // 終了日
            if ( _dateGet.CheckDate( ref tde_Ed, true ) == DateGetAcs.CheckDateResult.ErrorOfInvalid )
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid;
                return false;
            }
            // 大小チェック
            if ( tde_St.GetLongDate() > 0 &&
                 tde_Ed.GetLongDate() > 0 &&
                 tde_St.GetDateTime() > tde_Ed.GetDateTime() )
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfReverse;
                return false;
            }

            return true;
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

		# endregion

        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        private string GetName_Warehouse(string warehouseCode)
        {
            if (this._warehouseAcs == null)
            {
                this._warehouseAcs = new WarehouseAcs();
            }
            Warehouse warehouse;
            string sectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, sectionCd, warehouseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return warehouse.WarehouseName.Trim();
            }
            else
            {
                return "";
            }
        }
    }

    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
    # region [変則フォーカス制御]
    /// <summary>
    /// 変則フォーカス制御クラス
    /// </summary>
    internal class IrregularFocusControl
    {
        /// <summary>
        /// 変則フォーカス制御ディクショナリ　 
        /// </summary>
        private Dictionary<IrregularFocusControlKey, Control> _irregularFocusControlDic;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IrregularFocusControl()
        {
            _irregularFocusControlDic = new Dictionary<IrregularFocusControlKey, Control>();
        }

        # region [public メソッド]
        /// <summary>
        /// 変則フォーカス制御ディクショナリ追加
        /// </summary>
        /// <param name="prevCtrl"></param>
        /// <param name="shiftKey"></param>
        /// <param name="key"></param>
        /// <param name="priority"></param>
        /// <param name="nextControl"></param>
        public void AddFocusDictionary( Control prevCtrl, bool shiftKey, Keys key, int priority, Control nextControl )
        {
            _irregularFocusControlDic.Add( new IrregularFocusControlKey( prevCtrl.Name, shiftKey, key, priority ), nextControl );
        }
        /// <summary>
        /// 変則フォーカス制御ディクショナリクリア
        /// </summary>
        public void ClearFocusDictionary()
        {
            _irregularFocusControlDic.Clear();
        }
        /// <summary>
        /// 変則的次フォーカス項目取得処理
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool ReflectIrregularNextControl( Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if ( e == null || e.PrevCtrl == null ) return false;
            if ( e.NextCtrl == e.PrevCtrl ) return false;

            bool result = false;

            Control wkControl = GetIrregularNextControl( e.PrevCtrl.Name, e.Key, e.ShiftKey );
            if ( wkControl != null )
            {
                e.NextCtrl = wkControl;
                result = true;
            }

            return result;
        }
        # endregion

        # region [private メソッド]
        /// <summary>
        /// 変則的次フォーカス項目取得処理
        /// </summary>
        /// <param name="prevCtrlName"></param>
        /// <param name="key"></param>
        /// <param name="shiftKey"></param>
        /// <returns></returns>
        private Control GetIrregularNextControl( string prevCtrlName, Keys key, bool shiftKey )
        {
            Control irregularNextCtrl = null;

            if ( _irregularFocusControlDic == null )
            {
                return null;
            }

            int priority = 0;
            IrregularFocusControlKey dicKey = new IrregularFocusControlKey( prevCtrlName, shiftKey, key, priority );
            while ( _irregularFocusControlDic.ContainsKey( dicKey ) )
            {
                Control wkNextCtrl = _irregularFocusControlDic[dicKey];
                if ( wkNextCtrl.Enabled == true && wkNextCtrl.Visible == true )
                {
                    // Enabled=trueならば確定
                    irregularNextCtrl = wkNextCtrl;
                    break;
                }
                else
                {
                    // Enabled=falseならば次の候補へ
                    priority++;
                    dicKey = new IrregularFocusControlKey( prevCtrlName, shiftKey, key, priority );
                }
            }

            return irregularNextCtrl;
        }
        # endregion

        # region [フォーカス制御キー]
        /// <summary>
        /// フォーカス制御キー
        /// </summary>
        private struct IrregularFocusControlKey
        {
            /// <summary>前コントロール名</summary>
            private string _prevCtrlName;
            /// <summary>押下キーシフト</summary>
            private bool _shiftKey;
            /// <summary>押下キー</summary>
            private Keys _key;
            /// <summary>優先順</summary>
            private int _priority;
            /// <summary>
            /// 前コントロール名
            /// </summary>
            public string PrevCtrlName
            {
                get { return _prevCtrlName; }
                set { _prevCtrlName = value; }
            }
            /// <summary>
            /// 押下キーシフト
            /// </summary>
            /// <remarks>True:Shift押下</remarks>
            public bool ShiftKey
            {
                get { return _shiftKey; }
                set { _shiftKey = value; }
            }
            /// <summary>
            /// 押下キー
            /// </summary>
            public Keys Key
            {
                get { return _key; }
                set { _key = value; }
            }
            /// <summary>
            /// 優先順
            /// </summary>
            /// <remarks>通常は0を指定。フォーカス移動先がEnabled=falseなら1,2,3…と順番に参照する。</remarks>
            public int Priority
            {
                get { return _priority; }
                set { _priority = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="prevCtrlName">前コントロール名</param>
            /// <param name="shiftKey">押下キーシフト</param>
            /// <param name="key">押下キー</param>
            /// <param name="priority">優先順</param>
            public IrregularFocusControlKey( string prevCtrlName, bool shiftKey, Keys key, int priority )
            {
                _prevCtrlName = prevCtrlName;
                _shiftKey = shiftKey;
                _key = key;
                _priority = priority;
            }
        }
        # endregion
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
}