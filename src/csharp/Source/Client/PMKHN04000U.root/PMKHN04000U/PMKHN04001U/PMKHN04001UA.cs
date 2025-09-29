using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 得意先選択イベントハンドラ
	/// </summary>
	/// <param name="sender">対象オブジェクト</param>
	/// <param name="customerSearchRet">得意先検索戻り値クラス</param>
	public delegate void CustomerSelectEventHandler(object sender, CustomerSearchRet customerSearchRet);

	/// <summary>
	/// 得意先検索フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先検索フォームクラスです。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2007.02.12</br>
	/// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2008.08.28 20056 對馬 大輔</br>
    /// <br>             売上全体設定マスタアクセスクラス変更に伴う対応(メソッド引数の変更)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2008.09.04 30452 上野 俊治</br>
    /// <br>             削除行の表示制御追加</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/07/10 23012 畠中 啓次朗</br>
    /// <br>             明細表示順位の変更( 得意先カナの昇順から得意先コード昇順に変更 )</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/10/07 22018 鈴木 正臣</br>
    /// <br>             売上全体設定によらず、強制的にガイド表示できる機能の追加（得意先電子元帳の納入先ガイドで使用）</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 夏野 駿希</br>
    /// <br>             MANTIS:14720 得意先名検索追加</br>
    /// <br>             MANTIS:14721 得意先検索結果の表示項目に自宅FAXと勤務先FAXを追加</br>
    /// <br>             MANTIS:14678 自動検索，複数選択の初期値設定を可能とする</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2010/08/06 朱 猛</br>
    /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/16 周雨  連番 972,973,825</br>
    /// <br>             PM1107C:得意先ガイドの絞込条件修正</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/22 徐錦山   連番 826</br>
    /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/08/18 徐錦山   連番 826</br>
    /// <br>             PM1107C:得意先略称表示列修正(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	public partial class PMKHN04001UA : System.Windows.Forms.Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 得意先検索フォームフレームクラスデフォルトコンストラクタ
		/// </summary>
		public PMKHN04001UA()
		{
			InitializeComponent();

			// 変数初期化
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._searchDataView = new DataView();
			this._initialDataRead = new InitialDataReadHandler(this.InitialDataRead);
			this._extractConditionItemControlDictionary = new Dictionary<string, Panel>();
			this._extractionConditionInfo = new CustomerSearchExtractionConditionInfo();
			this._extractConditionList.Add(this._extractionConditionInfo.Clone());
			this._ultraTree_DropHightLight_DrawFilter = new UltraTree_DropHightLight_DrawFilter_Class();
			this._customerSearchSetUp = new CustomerSearchSetUp();
			this._customerSearchConstructionAcs = new CustomerSearchConstructionAcs();
			this._customerFormList = new List<PMKHN09000UA>();
			this._customerFormDictionary = new Dictionary<string, PMKHN09000UA>();
			this._employeeAcs = new EmployeeAcs();
			this._controlScreenSkin = new ControlScreenSkin();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._salesTtlStAcs = new SalesTtlStAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._paraMngSectionCode = string.Empty;
            this._paraMngSectionName = string.Empty;
            this._autoSearch = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
            this._forcedAutoSearch = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

			this._ultraTree_DropHightLight_DrawFilter.Invalidate += new EventHandler(this.UltraTree_DropHightLight_DrawFilter_Invalidate);
			this._ultraTree_DropHightLight_DrawFilter.QueryStateAllowedForNode += new UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventHandler(this.UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode);
		}

		/// <summary>
		/// 得意先検索フォームフレームクラスコンストラクタ
		/// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
		public PMKHN04001UA(int searchMode, int executeMode) : this()
		{
			this._searchMode = searchMode;
			this._executeMode = executeMode;
		}
		# endregion

		// ===================================================================================== //
		// インナークラス
		// ===================================================================================== //
		# region Inner Class
		/// <summary>
		/// セル結合条件クラス（IMergedCellEvaluator インタフェースをインプリメント）
		/// </summary>
		private class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
		{
			/// <summary>
			/// セル結合条件判定処理
			/// </summary>
			/// <param name="row1">行１</param>
			/// <param name="row2">行２</param>
			/// <param name="column">列</param>
			/// <returns>列に関連付けられたrow1とrow2のセルが結合される場合、Trueを返します</returns>
			public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
			{
				int customerCode1 = Convert.ToInt32(row1.Cells[SEARCH_COL_CustomerCode].Value);
				int customerCode2 = Convert.ToInt32(row2.Cells[SEARCH_COL_CustomerCode].Value);

				if ((customerCode1 == 0) || (customerCode2 == 0)) return false;
				return customerCode1 == customerCode2;
			}
		}
		# endregion

		// ===================================================================================== //
		// 列挙型
		// ===================================================================================== //
		# region Enum
		/// <summary>データ操作を行う対象の列挙型です。</summary>
		private enum DataControlType : int
		{
			Customer = 0
		}

		/// <summary>データの選択済み設定の列挙型です。</summary>
		private enum RowSelected : int
		{
			No = 0,
			Customer = 1
		}

		# endregion

        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		// ===================================================================================== //
		// 内部で使用する定数群
		// ===================================================================================== //
		#region Const
		// データテーブル列定義（得意先検索結果情報）
		internal const string SEARCH_TABLE							= "SEARCHTABLE";
		internal const string SEARCH_COL_EnterpriseCode				= "EnterpriseCode";				// 企業コード(カラム文字)
		internal const string SEARCH_COL_CustomerCode				= "CustomerCode";				// 得意先コード
		internal const string SEARCH_COL_CustomerSubCode			= "CustomerSubCode";			// 得意先サブコード
		internal const string SEARCH_COL_Name						= "Name";						// 名称
		internal const string SEARCH_COL_Name2						= "Name2";						// 名称２
        // 2011/7/22 XUJS ADD STA>>>>>>
        internal const string SEARCH_COL_Snm                        = "Snm";						// 略称
        // 2011/7/22 XUJS ADD END<<<<<<
		internal const string SEARCH_COL_Kana						= "Kana";						// カナ
		internal const string SEARCH_COL_SearchTelNo				= "SearchTelNo";				// 電話番号（検索用下4桁）
		internal const string SEARCH_COL_HomeTelNo					= "HomeTelNo";					// 電話番号（自宅）
		internal const string SEARCH_COL_OfficeTelNo				= "OfficeTelNo";				// 電話番号（勤務先）
		internal const string SEARCH_COL_PortableTelNo				= "PortableTelNo";				// 電話番号（携帯）
        // 2009/12/02 Add >>>
        internal const string SEARCH_COL_HomeFaxNo = "HomeFaxNo";					// FAX番号（自宅）
        internal const string SEARCH_COL_OfficeFaxNo = "OfficeFaxNo";				// FAX番号（勤務先）
        // 2009/12/02 Add <<<
		internal const string SEARCH_COL_PostNo						= "PostNo";						// 郵便番号
		internal const string SEARCH_COL_Address1					= "Address1";					// 住所１
		internal const string SEARCH_COL_Address3					= "Address3";					// 住所３
		internal const string SEARCH_COL_Address4					= "Address4";					// 住所４
		internal const string SEARCH_COL_Address					= "Address";					// 住所
		internal const string SEARCH_COL_CustomerSearchRet			= "CustomerSearchRet";			// 得意先検索戻り値クラス
		internal const string SEARCH_COL_HtmlString					= "HtmlString";					// 詳細表示用HTML文字列
		internal const string SEARCH_COL_SelectedFlg				= "SelectedFlg";				// 選択済みフラグ
		internal const string SEARCH_COL_LogicalDeleteCode			= "LogicalDeleteCode";			// 論理削除区分（得意先）
        // --- ADD 2008/09/04 -------------------------------->>>>>
        internal const string SEARCH_COL_LogicalDeleteDate          = "LogicalDeleteDate";			// 論理削除区分（得意先）
        // --- ADD 2008/09/04 --------------------------------<<<<< 

		private const string EXTRACT_CONDITION_XML_FILE_NAME = "PMKHN04001U_ExtractCondition.XML";	// 抽出条件セッティングＸＭＬファイルパス
		private const string FILENAME_COLDISPLAYSTATUS = "PMKHN04001U_ColSetting.DAT";				// 列表示状態セッティングXMLファイル名
		private const string TEMP_FOLDER_NAME = "Temp";												// Tempフォルダ名称
		private const string MESSAGE_NONDATA = "該当するデータが見つかりませんでした。";			// 該当データ無しメッセージ
		private const string RETURN_BUTTON_TOOLTIPTEXT	= "前回の抽出条件に戻します。";				// 戻すボタンツールチップテキスト

		private const int EXIST_CODE_CHECKED = 1;
		private const int EXIST_CODE_UNCHECKED = 0;
		# endregion

		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		#region Const
        /// <summary>SEARCHMODE 通常</summary>
		public const int SEARCHMODE_NORMAL = 0;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 DEL
        //public const int SEARCHMODE_SUPPLIER = 1;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 DEL
        /// <summary>SEARCHMODE 納入先</summary>
        public const int SEARCHMODE_RECEIVER = 2;   // 納入先
        /// <summary>SEARCHMODE 得意先のみ</summary>
        public const int SEARCHMODE_CUSTOMER_ONLY = 3;
        /// <summary>EXECUTEMODE 通常</summary>
        public const int EXECUTEMODE_NORMAL = 0;
        /// <summary>EXECUTEMODE ガイドのみ</summary>
        public const int EXECUTEMODE_GUIDE_ONLY = 1;
        /// <summary>EXECUTEMODE ガイド＋編集</summary>
        public const int EXECUTEMODE_GUIDE_AND_EDIT = 2;
		# endregion

		// ===================================================================================== //
		// スタティックな変数群
		// ===================================================================================== //
		# region Static Members
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = "";												// 企業コード
		private ImageList _imageList16 = null;												// イメージリスト
		private CustomerSearchExtractionConditionInfo _extractionConditionInfo = null;		// 抽出条件入力情報クラス
		private delegate void InitialDataReadHandler();
		InitialDataReadHandler _initialDataRead = null;
		private DataView _searchDataView = null;											// 得意先検索結果データビュー
		private string _initHtmlString = "";												// 初期詳細表示用ＨＴＭＬ文字列
		private ExtractConditionItems _extractConditionItems = null;						// 抽出条件設定コレクションクラス
		private Dictionary<string, Panel> _extractConditionItemControlDictionary = null;	// 抽出条件入力項目Dictionary
		private DetailViewForm _detailViewForm = null;										// 詳細表示用ダイアログ
		private List<CustomerSearchExtractionConditionInfo> _extractConditionList = new List<CustomerSearchExtractionConditionInfo>();	// 抽出条件履歴リスト
		private UltraTree_DropHightLight_DrawFilter_Class _ultraTree_DropHightLight_DrawFilter = new UltraTree_DropHightLight_DrawFilter_Class(); // DropHighlight／DropLinesを描くためのDrawFilterクラス
		private bool _noBeforeCheckEvent = false;											// ウルトラツリーチェックイベント強制中止フラグ
		private ColDisplayStatusList _colDisplayStatusList = null;							// 列表示状態コレクションクラス
		private int _selectedRowIndex = -1;													// 選択行Index
		private CustomerSearchConstructionAcs _customerSearchConstructionAcs;				// 得意先検索用設定情報アクセスクラス
		private CustomerSearchSetUp _customerSearchSetUp;									// 得意先検索用動作設定
		private List<PMKHN09000UA> _customerFormList;										// 得意先入力フォームリスト
		private Dictionary<string, PMKHN09000UA> _customerFormDictionary;					// 得意先入力フォームディクショナリ
		private EmployeeAcs _employeeAcs;													// 従業員アクセスクラス
		private int _searchMode = SEARCHMODE_NORMAL;										// 検索モード
		private int _executeMode = EXECUTEMODE_NORMAL;										// 起動モード
		private ControlScreenSkin _controlScreenSkin;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private SecInfoSetAcs _secInfoSetAcs = null;                                        // 拠点アクセスクラス
        private string _paraMngSectionCode;                                                 // （抽出条件）管理拠点コード
        private string _paraMngSectionName;                                                 // （抽出条件）管理拠点名称
        private bool _autoSearch;                                                           // 自動検索区分（ＵＩ制御）
        private SalesTtlStAcs _salesTtlStAcs = null;
        private Dictionary<string, Control> _nextControlDic;
        private List<string> _nextControlList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
        private bool _forcedAutoSearch;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
		# endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // ===================================================================================== //
        // パブリック　プロパティ
        // ===================================================================================== //
        # region Public Propaty
        /// <summary>
        /// 管理拠点コード　プロパティ
        /// </summary>
        public string MngSectionCode
        {
            get { return _paraMngSectionCode; }
            set { _paraMngSectionCode = value; }
        }
        /// <summary>
        /// 管理拠点名称　プロパティ
        /// </summary>
        public string MngSectionName
        {
            get { return _paraMngSectionName; }
            set { _paraMngSectionName = value; }
        }
        /// <summary>
        /// 自動検索開始区分　プロパティ
        /// </summary>
        public bool AutoSearch
        {
            get { return _autoSearch; }
            set { _autoSearch = value; }
        }
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
        /// <summary>
        /// 強制的自動検索実行（AutoSearchの制御によらず常に自動検索を実行する）
        /// </summary>
        public bool ForcedAutoSearch
        {
            get { return _forcedAutoSearch; }
            set { _forcedAutoSearch = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Events
		/// <summary>
		/// 得意先選択時イベント
		/// </summary>
		public event CustomerSelectEventHandler CustomerSelect;
		# endregion

		// ===================================================================================== //
		// デリゲート用メソッド
		// ===================================================================================== //
		# region Delegate Method
		/// <summary>
		/// 得意先情報変更イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
        /// <param name="customerInfo">得意先クラス</param>
		/// <remarks>
		/// <br>Note       : 得意先アクセスクラスで、得意先情報（Static領域）が変更された際にコールされるイベントです。</br>
		/// <br>Programer  : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void InfoCustomerChangeEvent(object sender, ref CustomerInfo customerInfo)
		{
		}

		/// <summary>
		/// 得意先情報削除イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
        /// <param name="customerInfo">得意先クラス</param>
		/// <remarks>
		/// <br>Note       : 得意先アクセスクラスで、得意先情報（Static領域）がDBから論理削除された際にコールされるイベントです。</br>
		/// <br>Programer  : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void InfoDeleteCustomerEvent(object sender, ref CustomerInfo customerInfo)
		{
		}
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// 得意先検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先検索処理を実行します。</br>
		/// <br>Programer  : 22018　鈴木正臣</br>
		/// <br>Date       : 2005.09.05</br>
		/// </remarks>
		public void Search()
		{
			this.Search_UButton_Click(this, new EventArgs());
		}

		/// <summary>
		/// 得意先検索処理（得意先コード指定）
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先コードを指定して得意先検索処理を実行します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.09.05</br>
		/// </remarks>
		public void Search(string enterpriseCode, int customerCode)
		{
			this.tNedit_CustomerCode.SetInt(customerCode);
			this.Search_UButton_Click(this, new EventArgs());
		}

		/// <summary>
		/// 選択情報（企業コード・得意先コード）取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS[0:取得成功 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : 現在選択中の企業コード、得意先コードを取得します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		public int GetSelectInfo(out string enterpriseCode, out int customerCode)
		{
			enterpriseCode = "";
			customerCode = 0;
			CustomerSearchRet customerSearchRet;

			int status = this.GetSelectInfo(out customerSearchRet);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				enterpriseCode = customerSearchRet.EnterpriseCode;
				customerCode = customerSearchRet.CustomerCode;
			}

			return status;
		}

		/// <summary>
		/// 選択情報（企業コード・得意先コード）取得処理
		/// </summary>
		/// <param name="customerSearchRet">得意先検索結果クラス</param>
		/// <returns>STATUS[0:取得成功 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : 現在選択中の得意先検索結果クラスを取得します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		public int GetSelectInfo(out CustomerSearchRet customerSearchRet)
		{
			customerSearchRet = null;

			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				return -1;
			}

			// 選択行のインデックスを取得
			CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
			int index = cm.Position;	

			// 指定行の内容を取得
			DataRow row = this._searchDataView[index].Row;

			// 得意先検索結果クラス取得処理（グリッド行より）
			customerSearchRet = this.DataRowToCustomerSearchRet(row);

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}

		/// <summary>
		/// 選択済み得意先コードリスト設定処理
		/// </summary>
		/// <param name="customerCodeList">得意先コードリスト</param>
		/// <remarks>
		/// <br>Note       : 現在ＭＤＩ親画面で表示されている得意先コードを設定します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		public void SetSelectedList(ArrayList customerCodeList)
		{
			// 選択済みフラグ設定処理
			this.SetSelectedFlg(customerCodeList);

			// グリッド行表示設定処理
			this.SettingGridRowAppearance();
		}
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// 初期設定系データリード処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 初期設定系データをリードします。非同期処理です。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void InitialDataRead()
		{
			//
		}

		/// <summary>
		/// 初期設定系データリード処理コールバックメソッド
		/// </summary>
		/// <remarks>
		/// <br>Note       : 初期設定系データリード処理が完了した後に実行されます。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void InitialDataReadCallBack(IAsyncResult ar)
		{
			InitialDataReadHandler initialDataReadHandler = (InitialDataReadHandler)ar.AsyncState;
			initialDataReadHandler.EndInvoke(ar);
		}

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : ツールバーの初期設定を行います</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void SetToolbar()
		{
			// イメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = this._imageList16;

			// ログイン担当者のアイコン設定
			Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginTitle_LabelTool"];
			loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			
			// 閉じるのアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
			closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

			// 戻るのアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Return_ButtonTool"];
			returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
			
			// 得意先新規のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool customerNewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerNew_ButtonTool"];
			customerNewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERNEW;
			
			// 得意先編集のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];
			customerEditButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERINPUT1;

			// 得意先削除のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool customerDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerDelete_ButtonTool"];
			customerDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CUSTOMERDELETE;
			
			// 得意先復元のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool customerRevivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerRevival_ButtonTool"];
			customerRevivalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

			// 設定のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["SetUp_ButtonTool"];
			setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

			// 詳細表示のアイコン設定
			Infragistics.Win.UltraWinToolbars.PopupMenuTool detailViewPopUpMenu = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)Main_ToolbarsManager.Tools["DetailView_PopupMenuTool"];
			detailViewPopUpMenu.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;

			// 選択のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
			selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

			// 取消のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool clearButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Clear_ButtonTool"];
			clearButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;

			// 検索のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool searchButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Search_ButtonTool"];
			searchButtonTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

			if (this._executeMode == EXECUTEMODE_GUIDE_ONLY)
			{
				selectButton.SharedProps.Visible = true;
				customerNewButton.SharedProps.Visible = false;
				customerEditButton.SharedProps.Visible = false;
				customerDeleteButton.SharedProps.Visible = false;
			}
			else if (this._executeMode == EXECUTEMODE_GUIDE_AND_EDIT)
			{
				selectButton.SharedProps.Visible = true;
				customerNewButton.SharedProps.Visible = true;
				customerEditButton.SharedProps.Visible = true;
				customerDeleteButton.SharedProps.Visible = true;
			}
			else
			{
				selectButton.SharedProps.Visible = false;
				customerNewButton.SharedProps.Visible = true;
				customerEditButton.SharedProps.Visible = true;
				customerDeleteButton.SharedProps.Visible = true;
			}
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.09.03</br>
		/// </remarks>
		private void InitialSetting()
		{
			// スキンロード
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
			CustomControlAppearance controlAppearance = this._controlScreenSkin.GetControlAppearance();

            //# region 桁数設定
            //this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            //this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            //this.tEdit_CustomerSubCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            //this.tEdit_CustomerKana.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 21, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            //this.SearchTelNo_TEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            //# endregion

			// イメージ設定
			this.Search_UButton.ImageList = this._imageList16;
			this.Search_UButton.Appearance.Image = Size16_Index.SEARCH;
			this.CustomerAgentCdGuide_UButton.ImageList = this._imageList16;
			this.CustomerAgentCdGuide_UButton.Appearance.Image = Size16_Index.STAR1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.MngSectionCodeGuide_UButton.ImageList = this._imageList16;
            this.MngSectionCodeGuide_UButton.Appearance.Image = Size16_Index.STAR1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			this.Main_ExplorerBar.ImageListSmall = _imageList16;
			this.Main_ExplorerBar.Groups["ExtractCondition"].Settings.AppearancesSmall.HeaderAppearance.Image = Size16_Index.PREVIEW;
			this.Main_ExplorerBar.Groups["ExtractConditionSetting"].Settings.AppearancesSmall.HeaderAppearance.Image = Size16_Index.SETUP1;
			this.Main_ExplorerBar.UseLargeGroupHeaderImages = Infragistics.Win.DefaultableBoolean.False;

			this.SearchResultHeader_ULabel.Appearance.BackColor = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.SearchResultHeader_ULabel.Appearance.BackColor2 = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.SearchResultHeader_ULabel.Appearance.BackGradientStyle = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.SearchResultHeader_ULabel.Appearance.ForeColor = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;

			// DrawFilterをツリーに設定する
			this.ExtractConditionSetting_UTree.DrawFilter = this._ultraTree_DropHightLight_DrawFilter;
			this.ExtractConditionSetting_UTree.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.ExtendedAutoDrag;

			this.ExtractConditionSetting_UTree.Appearances.Add("DropHighLightAppearance");
			this.ExtractConditionSetting_UTree.Appearances["DropHighLightAppearance"].BackColor = Color.Cyan;

			// ツールバー初期設定処理
			this.SetToolbar();

			// MDI／SDIフォーム設定処理
			this.MdiSdiFormSetting();

			// 各コントロール初期設定
			this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;
			this.GridFontSize_TComboEditor.Value = 10;
			
			if (controlAppearance != null)
			{
				this.Center_Splitter.BackColor = controlAppearance.BackColor;
			}

			Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if (LoginInfoAcquisition.Employee != null)
			{
				if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}

			// 得意先検索結果データテーブル設定処理
			this.SettingCustomerSearchDataTable();

			// 固定ヘッダー機能の有効にする
			this.SearchResult_UGrid.DisplayLayout.UseFixedHeaders = true;

			// 得意先検索結果グリッドカラム情報設定処理
			this.SettingSearchGridColumn(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);

			// 行サイズを設定
            this.SearchResult_UGrid.DisplayLayout.Override.DefaultRowHeight = 20;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            bool errorFlag = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            try
			{
				// 抽出条件設定情報ＸＭＬファイルをデシリアライズ
				List<ExtractConditionItem> extractConditionItemList = ExtractConditionItems.Deserialize(EXTRACT_CONDITION_XML_FILE_NAME);

				// 抽出条件設定コレクションクラスをインスタンス化
				this._extractConditionItems = new ExtractConditionItems(extractConditionItemList);
			}
			catch (Exception ex)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //MessageBox.Show(ex.Message + "\r\n" + "再度起動し直して下さい。");
                //return;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                errorFlag = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }

			// 抽出条件設定ツリー構築処理
			this.ExtractConditionTreeConstruction(this._extractConditionItems.GetExtractConditionItemList());

			// 抽出条件入力項目Dictionaryを生成
			foreach (ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
			{
				string name = this.GetExtractConditionPanelName(item);
				Control targetControl = FindControl(this, name);

                if ( (targetControl != null) && (targetControl is Panel) )
                {
                    this._extractConditionItemControlDictionary.Add( name, (Panel)targetControl );
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                else
                {
                    // １つでもＵＩ実装と合わない項目があればエラーとする
                    errorFlag = true;
                    break;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
			}
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            if ( errorFlag )
            {
                // エラーならば再生成する

                // 抽出条件設定情報ＸＭＬファイルをデシリアライズ
                List<ExtractConditionItem> extractConditionItemList = new List<ExtractConditionItem>();

                // 抽出条件設定コレクションクラスをインスタンス化
                this._extractConditionItems = new ExtractConditionItems( extractConditionItemList );

                // 抽出条件設定ツリー構築処理
                this.ExtractConditionTreeConstruction( this._extractConditionItems.GetExtractConditionItemList() );

                // 抽出条件入力項目Dictionaryを生成
                _extractConditionItemControlDictionary.Clear();
                foreach ( ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList() )
                {
                    string name = this.GetExtractConditionPanelName( item );
                    Control targetControl = FindControl( this, name );

                    if ( (targetControl != null) && (targetControl is Panel) )
                    {
                        this._extractConditionItemControlDictionary.Add( name, (Panel)targetControl );
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

			// 抽出条件入力パネルを全て非表示とする
			foreach (Control control in this.Condition_Panel.Controls)
			{
				if (!(control is Panel)) continue;

				control.Visible = false;
			}

			// 抽出条件設定入力項目構築処理
			this.ExtractConditionInputItemConstruction(this._extractConditionItems.GetExtractConditionItemList());

            // 修正 2009/07/10 >>>
			//this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            // 修正 2009/07/10 <<<

			this.DetailView_Panel.Visible = false;
			this.DetailView_Splitter.Visible = false;
			this.ExtractResult_Panel.Dock = DockStyle.Fill;

            // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 売上全体設定を参照
            //SalesTtlSt salesTtlSt;
            //// 2008.08.28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////int status = this._salesTtlStAcs.Read(out salesTtlSt, this._enterpriseCode);
            //int status = this._salesTtlStAcs.Read(out salesTtlSt, this._enterpriseCode, this._paraMngSectionCode);
            //// 2008.08.28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //if (status == 0)
            //{
            //    // 「自拠点のみ表示」の場合のみ、管理拠点自動入力ＯＮにする
            //    if ( salesTtlSt.CustGuideDispDiv == 1 )
            //    {
            //        // 管理拠点自動入力
            //        this._extractionConditionInfo.MngSectionCode = _paraMngSectionCode;
            //        this._extractionConditionInfo.MngSectionName = _paraMngSectionName;
                    
            //        // 複数選択チェック
            //        this.MultiSelect_UCheckEditor.Checked = true;

            //        this._paraMngSectionCode = string.Empty;
            //        this._paraMngSectionName = string.Empty;
            //    }
            //    else
            //    {
            //        // プロパティをクリアする
            //        this._paraMngSectionCode = string.Empty;
            //        this._paraMngSectionName = string.Empty;

            //        // 自動検索開始をキャンセルする
            //        this._autoSearch = false;
            //    }
            //}
            // 売上全体設定を参照
            bool existFlg = false;
            ArrayList retList;
            int status = this._salesTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (SalesTtlSt salesTtlSt in retList)
                {
                    if (salesTtlSt.SectionCode.Trim() == LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
                    {
                        // 「自拠点のみ表示」の場合のみ、管理拠点自動入力ＯＮにする
                        if (salesTtlSt.CustGuideDispDiv == 1)
                        {
                            // 管理拠点自動入力
                            this._extractionConditionInfo.MngSectionCode = _paraMngSectionCode;
                            this._extractionConditionInfo.MngSectionName = _paraMngSectionName;

                            // 複数選択チェック
                            this.MultiSelect_UCheckEditor.Checked = true;

                            this._paraMngSectionCode = string.Empty;
                            this._paraMngSectionName = string.Empty;
                        }
                        else
                        {
                            // プロパティをクリアする
                            this._paraMngSectionCode = string.Empty;
                            this._paraMngSectionName = string.Empty;

                            // 自動検索開始をキャンセルする
                            this._autoSearch = false;
                        }
                        existFlg = true;
                        break;
                    }
                }

                if (!existFlg)
                {
                    foreach (SalesTtlSt salesTtlSt in retList)
                    {
                        if (salesTtlSt.SectionCode.Trim() == "00")
                        {
                            // 「自拠点のみ表示」の場合のみ、管理拠点自動入力ＯＮにする
                            if (salesTtlSt.CustGuideDispDiv == 1)
                            {
                                // 管理拠点自動入力
                                this._extractionConditionInfo.MngSectionCode = _paraMngSectionCode;
                                this._extractionConditionInfo.MngSectionName = _paraMngSectionName;

                                // 複数選択チェック
                                this.MultiSelect_UCheckEditor.Checked = true;

                                this._paraMngSectionCode = string.Empty;
                                this._paraMngSectionName = string.Empty;
                            }
                            else
                            {
                                // プロパティをクリアする
                                this._paraMngSectionCode = string.Empty;
                                this._paraMngSectionName = string.Empty;

                                // 自動検索開始をキャンセルする
                                this._autoSearch = false;
                            }
                            break;
                        }
                    }
                }
            }
            // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<

            // 検索条件入力コントロール情報設定
            this.SettingExtractConditionItemInfo( this._extractionConditionInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // --- ADD 2008/09/04 -------------------------------->>>>>
            this.AddGridFiltering();
            // --- ADD 2008/09/04 --------------------------------<<<<<
		}

		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ツールバーボタン有効無効設定を行います</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.05.19</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting()
		{
			Infragistics.Win.UltraWinToolbars.ButtonTool returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Return_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool customerDeleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerDelete_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool customerRevivalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerRevival_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

			string enterpriseCode;
			int customerCode;
			Infragistics.Win.UltraWinGrid.UltraGridRow row = this.SearchResult_UGrid.ActiveRow;

			// 選択情報（企業コード・得意先コード）取得処理
			int status = this.GetSelectInfo(out enterpriseCode, out customerCode);
			
			if ((row == null) || (status != 0))
			{
				customerEditButton.SharedProps.Enabled = false;
				customerDeleteButton.SharedProps.Enabled = false;
				customerRevivalButton.SharedProps.Enabled = false;
				selectButton.SharedProps.Enabled = false;

			}
			else
			{
				// 得意先編集、得意先削除、得意先復旧ボタン制御
				if (customerCode == 0)
				{
					customerEditButton.SharedProps.Enabled = false;
					customerDeleteButton.SharedProps.Enabled = false;
					customerRevivalButton.SharedProps.Enabled = false;
					selectButton.SharedProps.Enabled = false;
				}
				else
				{
					int logicalDeleteCodeCustomer = Convert.ToInt32(row.Cells[SEARCH_COL_LogicalDeleteCode].Text.ToString());

                    /* --- DEL 2008/09/04 -------------------------------->>>>>
                    if (logicalDeleteCodeCustomer != 0)
					{
						customerEditButton.SharedProps.Enabled = false;
						customerDeleteButton.SharedProps.Enabled = false;
						customerRevivalButton.SharedProps.Enabled = true;
						selectButton.SharedProps.Enabled = false;
					}
					else
					{
						customerEditButton.SharedProps.Enabled = true;
						customerDeleteButton.SharedProps.Enabled = true;
						selectButton.SharedProps.Enabled = true;
						customerRevivalButton.SharedProps.Enabled = false;
					}
                     
                    --- DEL 2008/09/04 -------------------------------->>>>> */
                    // --- ADD 2008/09/04 -------------------------------->>>>>
                    if (logicalDeleteCodeCustomer == 0)
                    {
                        customerEditButton.SharedProps.Enabled = true;
                        customerDeleteButton.SharedProps.Enabled = true;
                        selectButton.SharedProps.Enabled = true;
                        customerRevivalButton.SharedProps.Enabled = false;
                    }
                    else if (logicalDeleteCodeCustomer == 1)
                    {
                        customerEditButton.SharedProps.Enabled = true;
                        customerDeleteButton.SharedProps.Enabled = false;
                        selectButton.SharedProps.Enabled = false;
                        customerRevivalButton.SharedProps.Enabled = true;
                    }
                    else
                    {
                        customerEditButton.SharedProps.Enabled = false;
                        customerDeleteButton.SharedProps.Enabled = false;
                        selectButton.SharedProps.Enabled = false;
                        customerRevivalButton.SharedProps.Enabled = false;
                    }
                    // --- ADD 2008/09/04 --------------------------------<<<<<

				}
			}

			// 戻るボタン制御
			if (this._extractConditionList.Count > 1)
			{
				if (returnButton != null)
				{
					returnButton.SharedProps.Enabled = true;

					int lastIndex = this._extractConditionList.Count - 1;
					returnButton.SharedProps.ToolTipText = RETURN_BUTTON_TOOLTIPTEXT + this._extractConditionList[lastIndex - 1].ToString();
				}
			}
			else
			{
				if (returnButton != null)
				{
					returnButton.SharedProps.Enabled = false;
					returnButton.SharedProps.ToolTipText = RETURN_BUTTON_TOOLTIPTEXT;
				}
			}
		}

		/// <summary>
		/// データ削除確認処理
		/// </summary>
		/// <returns>TRUE:チェック制御完了 FALSE:キャンセル</returns>
		/// <remarks>
		/// <br>Note       : データ削除確認処理を実行します。</br>
		/// <br>Programmer : 980079 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private bool DataDeleteDialogCheck()
		{
			bool result = true;
			string targetName = "得意先";

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"現在選択中の" + targetName + "を削除します。" + "\r\n" +
				"よろしいですか？",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			switch (dialogResult)
			{
				case (DialogResult.Yes):
				{
					result = true;
					break;
				}
				case (DialogResult.No):
				{
					result = false;
					break;
				}
				default:
				{
					result = false;
					break;
				}
			}

			return result;
		}
			
		/// <summary>
		/// データ復元確認処理
		/// </summary>
		/// <returns>TRUE:チェック制御完了 FALSE:キャンセル</returns>
		/// <remarks>
		/// <br>Note       : データ復元確認処理を実行します。</br>
		/// <br>Programmer : 980079 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private bool DataRevivalDialogCheck()
		{
			bool result = true;
			string targetName = "得意先";

			DialogResult dialogResult = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"現在選択中の" + targetName + "を復元します。" + "\r\n" +
				"よろしいですか？",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			switch (dialogResult)
			{
				case (DialogResult. Yes):
				{
					result = true;
					break;
				}
				case (DialogResult.No):
				{
					result = false;
					break;
				}
				default:
				{
					result = false;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// MDI／SDIフォーム設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : フォームのＭＤＩ／ＳＤＩスタイルに基づいた画面制御を行います。</br>
		/// <br>Programmer : 980079 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void MdiSdiFormSetting()
		{
			if (this.MdiParent == null)
			{
				// 閉じるのアイコン設定
				Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
				if (closeButton != null)
				{
					closeButton.SharedProps.Caption = "閉じる(&X)";
					closeButton.SharedProps.Visible = true;
				}

			}
			else
			{
				// 閉じるのアイコン設定
				Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
				if (closeButton != null)
				{
//					closeButton.SharedProps.Caption = "閉じる(&C)";
					closeButton.SharedProps.Visible = false;
				}
			}
		}


		/// <summary>
		/// 得意先検索結果データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先検索結果のデータテーブルを設定します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		internal void SettingCustomerSearchDataTable()
		{
			//--------------------------------------------------
			//  データセット、データテーブルの生成
			//--------------------------------------------------
			// データテーブルの作成
			DataTable searchTable = new DataTable(SEARCH_TABLE);

			//--------------------------------------------------
			// データカラム情報の生成
			//--------------------------------------------------
			// 企業コード
			DataColumn EnterpriseCode = new DataColumn(SEARCH_COL_EnterpriseCode, typeof(String), "", MappingType.Element);
			EnterpriseCode.Caption = "企業コード";
			
			// 得意先コード
            DataColumn CustomerCode = new DataColumn( SEARCH_COL_CustomerCode, typeof( Int32 ), "", MappingType.Element );
			CustomerCode.Caption = "得意先コード";

			// 得意先サブコード
			DataColumn CustomerSubCode = new DataColumn(SEARCH_COL_CustomerSubCode, typeof(String), "", MappingType.Element);
			CustomerSubCode.Caption = "得意先サブコード";

			// 名称
			DataColumn Name = new DataColumn(SEARCH_COL_Name, typeof(String), "", MappingType.Element);
			Name.Caption = "得意先名称";

			// 名称２
			DataColumn Name2 = new DataColumn(SEARCH_COL_Name2, typeof(String), "", MappingType.Element);
			Name.Caption = "得意先名称２";

            // 2011/7/22 XUJS ADD STA>>>>>>
            //得意先略称
            DataColumn Snm = new DataColumn(SEARCH_COL_Snm, typeof(String), "", MappingType.Element);
            Name.Caption = "得意先略称";
            // 2011/7/22 XUJS ADD END<<<<<<

			// カナ
			DataColumn Kana = new DataColumn(SEARCH_COL_Kana, typeof(String), "", MappingType.Element);
			Kana.Caption = "得意先名(ｶﾅ)";

			// 電話番号（検索用下4桁）
			DataColumn SearchTelNo = new DataColumn(SEARCH_COL_SearchTelNo, typeof(String), "", MappingType.Element);
			SearchTelNo.Caption = "電話番号（検索用下4桁）";

			// 電話番号（自宅）
			DataColumn HomeTelNo = new DataColumn(SEARCH_COL_HomeTelNo, typeof(String), "", MappingType.Element);
			HomeTelNo.Caption = PMKHN04001UA.GetTelNoDspName(0);

			// 電話番号（勤務先）
			DataColumn OfficeTelNo = new DataColumn(SEARCH_COL_OfficeTelNo, typeof(String), "", MappingType.Element);
			OfficeTelNo.Caption = PMKHN04001UA.GetTelNoDspName(1);

			// 電話番号（携帯）
			DataColumn PortableTelNo = new DataColumn(SEARCH_COL_PortableTelNo, typeof(String), "", MappingType.Element);
			PortableTelNo.Caption = PMKHN04001UA.GetTelNoDspName(2);

            // 2009/12/02 Add >>>
            // FAX番号（自宅）
            DataColumn HomeFaxNo = new DataColumn(SEARCH_COL_HomeFaxNo, typeof(String), "", MappingType.Element);
            HomeFaxNo.Caption = PMKHN04001UA.GetTelNoDspName(3);

            // FAX番号（勤務先）
            DataColumn OfficeFaxNo = new DataColumn(SEARCH_COL_OfficeFaxNo, typeof(String), "", MappingType.Element);
            OfficeFaxNo.Caption = PMKHN04001UA.GetTelNoDspName(4);
            // 2009/12/02 Add <<<

			// 郵便番号
			DataColumn PostNo = new DataColumn(SEARCH_COL_PostNo, typeof(String), "", MappingType.Element);
			PostNo.Caption = "郵便番号";

			// 住所１
			DataColumn Address1 = new DataColumn(SEARCH_COL_Address1, typeof(String), "", MappingType.Element);
			Address1.Caption = "住所１";

			// 住所３
			DataColumn Address3 = new DataColumn(SEARCH_COL_Address3, typeof(String), "", MappingType.Element);
			Address3.Caption = "住所３";

			// 住所４
			DataColumn Address4 = new DataColumn(SEARCH_COL_Address4, typeof(String), "", MappingType.Element);
			Address4.Caption = "住所４";

			// 住所
			DataColumn Address = new DataColumn(SEARCH_COL_Address, typeof(String), "", MappingType.Element);
			Address.Caption = "住所";

			// 得意先検索結果クラス
			DataColumn CustomerSearchRetCol = new DataColumn(SEARCH_COL_CustomerSearchRet, typeof(CustomerSearchRet), "", MappingType.Element);
			CustomerSearchRetCol.Caption = "得意先検索結果クラス";

			// 詳細表示用HTML文字列
			DataColumn HtmlString = new DataColumn(SEARCH_COL_HtmlString, typeof(String), "", MappingType.Element);
			HtmlString.Caption = "詳細表示用HTML文字列";

			// 選択済みフラグ
			DataColumn SelectedFlg = new DataColumn(SEARCH_COL_SelectedFlg, typeof(Int32), "", MappingType.Element);
			HtmlString.Caption = "選択済みフラグ";

			// 論理削除区分（得意先）
			DataColumn LogicalDeleteCodeCustomer = new DataColumn(SEARCH_COL_LogicalDeleteCode, typeof(Int32), "", MappingType.Element);
			HtmlString.Caption = "論理削除区分（得意先）";

            // --- ADD 2008/09/04 -------------------------------->>>>>
            // 削除日
            DataColumn LogicalDeleteDateCustomer = new DataColumn(SEARCH_COL_LogicalDeleteDate, typeof(string), "", MappingType.Element);
            HtmlString.Caption = "削除日";
            // --- ADD 2008/09/04 --------------------------------<<<<<

			//--------------------------------------------------
			//  データセット、データテーブルの初期化
			//--------------------------------------------------
			// データセットの初期化
			this.Search_DataSet.Tables.AddRange(new DataTable[] {searchTable});

			// データテーブルの初期化
			searchTable.Columns.AddRange(new DataColumn[] {
															  CustomerCode,					// 得意先コード
															  CustomerSubCode,				// 得意先サブコード
															  Name,							// 名称
                                                              // 2011/7/22 XUJS ADD STA>>>>>>
                                                              Snm,                          //略称
                                                              // 2011/7/22 XUJS ADD END<<<<<<
															  Kana,							// カナ
															  HomeTelNo,					// 電話番号（自宅）
															  OfficeTelNo,					// 電話番号（勤務先）
															  PortableTelNo,				// 電話番号（携帯）
                                                              // 2009/12/02 Add >>>
															  HomeFaxNo,					// 電話番号（自宅）
															  OfficeFaxNo,					// 電話番号（勤務先）
                                                              // 2009/12/02 Add <<<
															  EnterpriseCode,				// 企業コード(カラム文字)
															  Name2,						// 名称２
															  SearchTelNo,					// 電話番号（検索用下4桁）
															  PostNo,						// 郵便番号
															  Address1,						// 住所１
															  Address3,						// 住所３
															  Address4,						// 住所４
															  Address,						// 住所
															  CustomerSearchRetCol,			// 得意先検索結果クラス
															  HtmlString,					// 詳細表示用HTML文字列
															  SelectedFlg,					// 選択済みフラグ
															  LogicalDeleteCodeCustomer,	// 論理削除区分（得意先）
            // --- ADD 2008/09/04 -------------------------------->>>>>
															  LogicalDeleteDateCustomer,	// 削除日
            // --- ADD 2008/09/04 --------------------------------<<<<< 
															});

			this._searchDataView.Table = searchTable;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._searchDataView.RowFilter = string.Format( "{0}=0", SEARCH_COL_LogicalDeleteCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			//　グリッドにデータセットをバインド
			//this.SearchResult_UGrid.DataSource = this.Search_DataSet.Tables[SEARCH_TABLE];
            this.SearchResult_UGrid.DataSource = this._searchDataView;
		}

		/// <summary>
		/// 得意先検索結果クラス取得処理（グリッド行より）
		/// </summary>
		/// <param name="row">データ行情報</param>
		/// <returns>取得した得意先検索結果クラスデータ</returns>
		/// <remarks>
		/// <br>Note       : データ行の情報から得意先検索結果クラスを取得します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private CustomerSearchRet DataRowToCustomerSearchRet(DataRow row)
		{
			return (CustomerSearchRet)row[SEARCH_COL_CustomerSearchRet];
		}

		/// <summary>
		/// 詳細表示用HTML文字列取得処理（グリッド行より）
		/// </summary>
		/// <param name="row">データ行情報</param>
		/// <returns>取得した詳細表示用HTML文字列データ</returns>
		/// <remarks>
		/// <br>Note       : データ行の情報から詳細表示用HTML文字列を取得します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private string DataRowToHtmlString(DataRow row)
		{
			return (string)row[SEARCH_COL_HtmlString];
		}

		/// <summary>
		/// 詳細表示用文字列データ行設定処理
		/// </summary>
		/// <param name="row">データ行情報</param>
		/// <remarks>
		/// <br>Note       : 詳細表示用文字列をデータ行に設定します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private void SetHtmlStringToDataRow(DataRow row)
		{
			/*
			string enterpriseCode = (string)row[SEARCH_COL_EnterpriseCode];
			int customerCode = Convert.ToInt32(row[SEARCH_COL_CustomerCode]);

			SFCMN00017UA htmlViewDialog = new SFCMN00017UA();
			string htmlString = htmlViewDialog.GetHtmlString(enterpriseCode, customerCode, carMngNo);

			row[SEARCH_COL_HtmlString] = htmlString;
			*/
		}

		/// <summary>
		/// 選択済みフラグ設定処理
		/// </summary>
		/// <param name="customerCodeList">得意先コードリスト</param>
		/// <remarks>
		/// <br>Note       : 得意先コードリストを元に、選択済みフラグを設定します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private void SetSelectedFlg(ArrayList customerCodeList)
		{
			// 選択行のインデックスを取得
			for(int i = 0; i < this._searchDataView.Count; i++)
			{
				// 指定行の内容を取得
				DataRow row = this._searchDataView[i].Row;

				int customerCode = (int)row[SEARCH_COL_CustomerCode];

				row[SEARCH_COL_SelectedFlg] = (int)RowSelected.No;

				foreach(int listCustomerCode in customerCodeList)
				{
					if (customerCode == listCustomerCode)
					{
						row[SEARCH_COL_SelectedFlg] = (int)RowSelected.Customer;
						break;
					}
				}
			}
		}

		/// <summary>
		/// 得意先検索結果グリッド行設定処理
		/// </summary>
		/// <param name="searchRet">設定元の得意先検索結果クラス</param>
		/// <param name="row">設定先のデータ行</param>
		/// <returns>値が設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note       : 得意先検索結果クラスをデータ行へ設定します。</br>
		/// <br>Programer  : 22018　鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private DataRow CustomerSearchRetToDataRow(CustomerSearchRet searchRet, DataRow row)
		{
			if (row == null)
			{
				row = this.Search_DataSet.Tables[SEARCH_TABLE].NewRow();
			}

			row[SEARCH_COL_EnterpriseCode]				= searchRet.EnterpriseCode;					// 企業コード(カラム文字)
			row[SEARCH_COL_CustomerCode]				= searchRet.CustomerCode;					// 得意先コード
			row[SEARCH_COL_CustomerSubCode]				= searchRet.CustomerSubCode;				// 得意先サブコード
			row[SEARCH_COL_Name]						= searchRet.Name + " " + searchRet.Name2;	// 名称
			row[SEARCH_COL_Name2]						= searchRet.Name2;							// 名称２
            // 2011/7/22 XUJS ADD STA>>>>>>
            row[SEARCH_COL_Snm]                         = searchRet.Snm;	                        //略称
            // 2011/7/22 XUJS ADD END<<<<<<
			row[SEARCH_COL_Kana]						= searchRet.Kana;							// カナ
			row[SEARCH_COL_SearchTelNo]					= searchRet.SearchTelNo;					// 電話番号（検索用下4桁）
			row[SEARCH_COL_HomeTelNo]					= searchRet.HomeTelNo;						// 電話番号（自宅）
			row[SEARCH_COL_OfficeTelNo]					= searchRet.OfficeTelNo;					// 電話番号（勤務先）
			row[SEARCH_COL_PortableTelNo]				= searchRet.PortableTelNo;					// 電話番号（携帯）
            // 2009/12/02 Add >>>
            row[SEARCH_COL_HomeFaxNo] = searchRet.HomeFaxNo;                      // FAX番号（自宅）
            row[SEARCH_COL_OfficeFaxNo] = searchRet.OfficeFaxNo;                    // FAX番号（勤務先）
            // 2009/12/02 Add <<<
			row[SEARCH_COL_PostNo]						= searchRet.PostNo;							// 郵便番号
			row[SEARCH_COL_Address1]					= searchRet.Address1;						// 住所１
			row[SEARCH_COL_Address3]					= searchRet.Address3;						// 住所３
			row[SEARCH_COL_Address4]					= searchRet.Address4;						// 住所４
			row[SEARCH_COL_Address] =
				searchRet.Address1 +
				searchRet.Address3 +
				searchRet.Address4;																	// 住所
			row[SEARCH_COL_CustomerSearchRet]			= searchRet.Clone();						// 得意先検索戻り値クラス
			row[SEARCH_COL_HtmlString]					= "";										// 詳細表示用HTML文字列
			row[SEARCH_COL_SelectedFlg]					= (int)RowSelected.No;						// 選択済みフラグ
			row[SEARCH_COL_LogicalDeleteCode]			= searchRet.LogicalDeleteCode;				// 論理削除区分（得意先）
            // --- ADD 2008/09/04 -------------------------------->>>>>
            if (searchRet.LogicalDeleteCode == 0)
            {
                row[SEARCH_COL_LogicalDeleteDate]       = "";
            }
            else
            {
                // 更新日を削除日とする。
                row[SEARCH_COL_LogicalDeleteDate] = TDateTime.DateTimeToString("ggYY/MM/DD", searchRet.UpdateDate);
            }
            // --- ADD 2008/09/04 --------------------------------<<<<< 

			return row;
		}

		/// <summary>
		/// 得意先検索結果グリッドカラム情報設定処理
		/// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
		/// <remarks>
		/// <br>Note       : 得意先検索結果グリッドに表示するカラム情報を設定します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private void SettingSearchGridColumn(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            UiSet uiset;
            uiSetControl1.ReadUISet( out uiset, this.tNedit_CustomerCode.Name );
            string customerFormat = new string( '0', uiset.Column );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 一旦、全ての列を非表示に設定し、表示位置を統一させる
			foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				column.Hidden = true;
				column.CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageHAlign	= Infragistics.Win.HAlign.Left;
				column.CellAppearance.ImageVAlign	= Infragistics.Win.VAlign.Middle;
			}

            // 表示するカラム情報を設定する
            // 名称 列設定
            columns[SEARCH_COL_Name].Header.Caption = "得意先名";
            columns[SEARCH_COL_Name].Hidden = false;
            columns[SEARCH_COL_Name].Width = 150;

            // 2011/7/22 XUJS ADD STA>>>>>>
            // 得意先略称 列設定
            columns[SEARCH_COL_Snm].Header.Caption = "得意先略称";
            columns[SEARCH_COL_Snm].Hidden = false;
            columns[SEARCH_COL_Snm].Width = 120;
            // 2011/7/22 XUJS ADD END<<<<<<

            // 得意先コード 列設定
            columns[SEARCH_COL_CustomerCode].Header.Caption = "得意先コード";
            columns[SEARCH_COL_CustomerCode].Hidden = false;
            columns[SEARCH_COL_CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            columns[SEARCH_COL_CustomerCode].Format = customerFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 得意先サブコード 列設定
            columns[SEARCH_COL_CustomerSubCode].Header.Caption = "得意先サブコード";
            columns[SEARCH_COL_CustomerSubCode].Hidden = false;

            // 得意先カナ 列設定
            columns[SEARCH_COL_Kana].Header.Caption = "得意先名(ｶﾅ)";
            columns[SEARCH_COL_Kana].Hidden = false;

            // 自宅ＴＥＬ 列設定
            columns[SEARCH_COL_HomeTelNo].Header.Caption = PMKHN04001UA.GetTelNoDspName( 0 );
            columns[SEARCH_COL_HomeTelNo].Hidden = false;

            // 勤務先ＴＥＬ 列設定
            columns[SEARCH_COL_OfficeTelNo].Header.Caption = PMKHN04001UA.GetTelNoDspName( 1 );
            columns[SEARCH_COL_OfficeTelNo].Hidden = false;

            // 携帯ＴＥＬ 列設定
            columns[SEARCH_COL_PortableTelNo].Header.Caption = PMKHN04001UA.GetTelNoDspName( 2 );
            columns[SEARCH_COL_PortableTelNo].Hidden = false;

            // 2009/12/02 Add >>>
            // 自宅ＴＥＬ 列設定
            columns[SEARCH_COL_HomeFaxNo].Header.Caption = PMKHN04001UA.GetTelNoDspName(3);
            columns[SEARCH_COL_HomeFaxNo].Hidden = false;

            // 勤務先ＴＥＬ 列設定
            columns[SEARCH_COL_OfficeFaxNo].Header.Caption = PMKHN04001UA.GetTelNoDspName(4);
            columns[SEARCH_COL_OfficeFaxNo].Hidden = false;
            // 2009/12/02 Add <<<


            // 住所 列設定
            columns[SEARCH_COL_Address].Header.Caption = "住所";
            columns[SEARCH_COL_Address].Hidden = false;

            // --- ADD 2008/09/04 -------------------------------->>>>>
            // 削除日 列設定
            columns[SEARCH_COL_LogicalDeleteDate].Header.Caption = "削除日";
            columns[SEARCH_COL_LogicalDeleteDate].CellAppearance.ForeColor = Color.Red;
            if ( this.DeleteIndication_CheckEditor.Checked )
            {
                columns[SEARCH_COL_LogicalDeleteDate].Hidden = false;
            }
            else
            {
                columns[SEARCH_COL_LogicalDeleteDate].Hidden = true;
            }
            // --- ADD 2008/09/04 --------------------------------<<<<<

			// 列表示状態クラスリストXMLファイルをデシリアライズ
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(FILENAME_COLDISPLAYSTATUS);

			// 列表示状態コレクションクラスをインスタンス化
			this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList);

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (colDisplayStatus.Key == this.GridFontSize_TComboEditor.Name)
				{
					this.GridFontSize_TComboEditor.Value = colDisplayStatus.Width;
				}
				else if (columns.Exists(colDisplayStatus.Key))
				{
					columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
					columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
					columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
				}
			}
		}

		/// <summary>
		/// グリッド行表示設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッド行の表示設定を行います。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void SettingGridRowAppearance()
		{
			foreach(Infragistics.Win.UltraWinGrid.UltraGridRow row in this.SearchResult_UGrid.Rows)
			{
				int selectedFlg = Convert.ToInt32(row.Cells[SEARCH_COL_SelectedFlg].Text.ToString());

				switch (selectedFlg)
				{
					case (int)RowSelected.Customer:
					{
						row.Appearance.ForeColor = Color.Red;
						break;
					}
					default:
					{
						row.Appearance.ForeColor = Color.Black;
						break;
					}
				}

                /* --- DEL 2008/09/04 -------------------------------->>>>>
				int logicalDeleteCodeCustomer = Convert.ToInt32(row.Cells[SEARCH_COL_LogicalDeleteCode].Text.ToString());

				if (logicalDeleteCodeCustomer != 0)
				{
					row.Appearance.ForeColor = Color.DarkGray;
				}
				else
				{
					row.Appearance.ForeColor = Color.Black;
				}
                --- DEL 2008/09/04 -------------------------------->>>>> */
            }
		}

		/// <summary>
		/// 得意先検索結果配列→画面格納処理
		/// </summary>
		/// <param name="customerSearchRetArray">得意先検索結果配列</param>
		/// <remarks>
		/// <br>Note       : 得意先検索結果配列の情報を画面に表示します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void SetDisplayFormSearchRetArray(CustomerSearchRet[] customerSearchRetArray)
		{

			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();

			if ((customerSearchRetArray == null) || (customerSearchRetArray.Length == 0))
			{
				// データ無し
				this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = MESSAGE_NONDATA;
				this.MessageUnDisp_Timer.Enabled = true;
			}
			else
			{
				// 得意先検索結果グリッド行設定処理
				foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
				{
					DataRow dataRow = null;

					// 得意先検索結果グリッド行設定処理
					dataRow = this.CustomerSearchRetToDataRow(customerSearchRet, dataRow);
					this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Add(dataRow);
				}

                // --- DEL 2008/09/04 -------------------------------->>>>>
                //this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "抽出件数：" + this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Count.ToString() + " 件";
                // --- DEL 2008/09/04 --------------------------------<<<<<
			}

			if (this.SearchResult_UGrid.Rows.Count == 0)
			{
				this.DetailView_Timer.Enabled = true;
			}
			else
			{
				this.SearchResult_UGrid.ActiveRow = this.SearchResult_UGrid.Rows[0];
				this.SearchResult_UGrid.ActiveRow.Selected = true;

				this.DetailView_Timer.Enabled = true;
			}
		}

		/// <summary>
		/// 得意先検索処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先の検索処理を行います。(デリゲートより非同期実行します)</br>
		/// <br>Programmer : 22018　鈴木正臣</br>
		/// <br>Date       : 2005.05.24</br>
		/// </remarks>
		private int SearchCustomerData()
		{
			CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
			CustomerSearchPara para = new CustomerSearchPara();
			CustomerSearchRet[] retArray;
			
			// パラメータを生成
			para = this._extractionConditionInfo;

			// 検索処理実行
			int status = customerSearchAcs.Serch(out retArray, para);

			// 得意先検索結果配列→画面格納処理
			this.SetDisplayFormSearchRetArray(retArray);

			return status;
		}


		/// <summary>
		/// 抽出条件入力情報クラスセッティング処理
		/// </summary>
		/// <param name="conditionInfo">抽出条件入力情報クラス</param>
		/// <remarks>
		/// <br>Note       : 検索条件入力コントロールから抽出条件入力情報クラスを設定します</br>
		/// <br>Programmer : 22018　鈴木正臣</br>
		/// <br>Date       : 2005.05.24</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private void SettingExtractionConditionClass(ref CustomerSearchExtractionConditionInfo conditionInfo)
		{
			if (conditionInfo == null) conditionInfo = new CustomerSearchExtractionConditionInfo();

			// 企業コード
			conditionInfo.EnterpriseCode = this._enterpriseCode;

			// 得意先コード
			if (this.Condition_CustomerCode_Panel.Visible)
			{
				conditionInfo.CustomerCode = this.tNedit_CustomerCode.GetInt();
			}
			else
			{
				conditionInfo.CustomerCode = 0;
			}

			// 得意先サブコード
			if (this.Condition_CustomerSubCode_Panel.Visible)
			{
				conditionInfo.CustomerSubCode = this.tEdit_CustomerSubCode.DataText;

				if (this.CustomerSubCodeSearchType_UCheckEditor.Checked)
				{
					conditionInfo.CustomerSubCodeSearchType = 1;
				}
				else
				{
					conditionInfo.CustomerSubCodeSearchType = 0;
				}
			}
			else
			{
				conditionInfo.CustomerSubCode = "";
				conditionInfo.CustomerSubCodeSearchType = 0;
			}

			// 得意先カナ
			if (this.Condition_Kana_Panel.Visible)
			{
				conditionInfo.Kana = this.tEdit_CustomerKana.DataText;

				if (this.KanaSearchType_UCheckEditor.Checked)
				{
					conditionInfo.KanaSearchType = 1;
				}
				else
				{
					conditionInfo.KanaSearchType = 0;
				}
			}
			else
			{
				conditionInfo.Kana = "";
				conditionInfo.KanaSearchType = 0;
			}

			// 電話番号（電話番号下４桁）
			if (this.Condition_SearchTelNo_Panel.Visible)
			{
				conditionInfo.SearchTelNo = this.SearchTelNo_TEdit.DataText;
			}
			else
			{
				conditionInfo.SearchTelNo = "";
			}

			// 論理削除データ抽出区分
			conditionInfo.LogicalDeleteDataPickUp = 0;
			
			// 得意先種別
			this.SetCustomerDivStatus(ref conditionInfo);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 管理拠点
            //conditionInfo.MngSectionCode = this.MngSectionCode;
            //conditionInfo.MngSectionName = this.MngSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			//conditionInfo.SupplierDiv = this.GetCheckEditorValue(this.SupplierDiv_UCheckEditor, EXIST_CODE_CHECKED, EXIST_CODE_UNCHECKED);
			//conditionInfo.AcceptWholeSale = this.GetCheckEditorValue(this.AcceptWholeSale_UCheckEditor, EXIST_CODE_CHECKED, EXIST_CODE_UNCHECKED);

            // 2009/12/02 Add >>>
            // 得意先名
            if (this.Condition_Name_Panel.Visible)
            {
                conditionInfo.Name = this.tEdit_CustomerName.DataText;

                if (this.NameSearchType_UCheckEditor.Checked)
                {
                    conditionInfo.NameSearchType = 1;
                }
                else
                {
                    conditionInfo.NameSearchType = 0;
                }
            }
            else
            {
                conditionInfo.Name = "";
                conditionInfo.NameSearchType = 0;
            }
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            // 得意先略称
            if (this.Condition_CustomerSnm_Panel.Visible)
            {
                conditionInfo.CustomerSnm = this.tEdit_CustomerSnm.DataText;

                if (this.SnmSearchType_UCheckEditor.Checked)
                {
                    conditionInfo.CustomerSnmSearchType = 1;
                }
                else
                {
                    conditionInfo.CustomerSnmSearchType = 0;
                }
            }
            else
            {
                conditionInfo.CustomerSnm = "";
                conditionInfo.CustomerSnmSearchType = 0;
            }
            // 2011/7/22 XUJS ADD END<<<<<<

            // ---ADD 2010/08/06-------------------->>>
            // 電話番号
            if (this.Condition_TelNum_Panel.Visible)
            {
                conditionInfo.TelNum = this.tEdit_TelNum.DataText;

                if (this.TelNum_UCheckEditor.Checked)
                {
                    conditionInfo.TelNumSearchType = 1;
                }
                else
                {
                    conditionInfo.TelNumSearchType = 0;
                }
            }
            else
            {
                conditionInfo.TelNum = "";
                conditionInfo.TelNumSearchType = 0;
            }
            // ---ADD 2010/08/06--------------------<<<
            //ADD START 周雨 2011/07/16 連番 972,973,825
            if (conditionInfo.MngSectionCode.Length == 1)
                conditionInfo.MngSectionCode = "0" + conditionInfo.MngSectionCode;
            //ADD END 周雨 2011/07/16 連番 972,973,825
        }

		/// <summary>
		/// 抽出条件入力情報クラスセッティング有無取得処理
		/// </summary>
		/// <param name="conditionInfo">抽出条件入力情報クラス</param>
		/// <remarks>
		/// <br>Note       : 抽出条件入力情報クラスに値が設定されているかどうかを取得します</br>
		/// <br>Programmer : 22018　鈴木正臣</br>
		/// <br>Date       : 2005.05.24</br>
		/// </remarks>
		private bool IsExtractionConditionClassSetting(CustomerSearchExtractionConditionInfo conditionInfo)
		{
			/*
			if ((conditionInfo.CustomerCode != 0) ||				// 得意先コード
				(conditionInfo.CustomerSubCode != "") ||			// 得意先サブコード
				(conditionInfo.Kana != "") ||						// 得意先カナ
				(conditionInfo.SearchTelNo != "") ||				// 電話番号（電話番号下４桁）
				(conditionInfo.SupplierDiv != 0) ||					// 仕入先区分
				(conditionInfo.AcceptWholeSale != 0) ||				// 業販先区分
				(conditionInfo.CustAnalysCode1 != 0) ||				// 分析コード１
				(conditionInfo.CustAnalysCode2 != 0) ||				// 分析コード２
				(conditionInfo.CustAnalysCode3 != 0) ||				// 分析コード３
				(conditionInfo.CustAnalysCode4 != 0) ||				// 分析コード４
				(conditionInfo.CustAnalysCode5 != 0) ||				// 分析コード５
				(conditionInfo.CustAnalysCode6 != 0) ||				// 分析コード６
				(conditionInfo.CustomerAgentCd != "") ||			// 得意先担当
				((conditionInfo.CustomerSubCode != "") && (conditionInfo.CustomerSubCodeSearchType != 0)) ||		// 得意先サブコード検索タイプ
				((conditionInfo.Kana != "") && (conditionInfo.KanaSearchType != 0))									// 得意先カナ検索タイプ
				)
			{
				return true;
			}
			else
			{
				return false;
			}
			*/
			return true;
		}

		/// <summary>
		/// 検索条件入力コントロール情報設定
		/// </summary>
		/// <param name="conditionInfo">抽出条件入力情報クラス</param>
		/// <remarks>
		/// <br>Note       : 抽出条件入力情報クラスから検索条件入力コントロールに値を設定します。</br>
		/// <br>Programmer : 22018　鈴木正臣</br>
		/// <br>Date       : 2005.05.24</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private void SettingExtractConditionItemInfo(CustomerSearchExtractionConditionInfo conditionInfo)
		{
			if (conditionInfo == null) return;

			// イベントを解除
            //this.SupplierDiv_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.Customer_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.Receiver_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
			this.KanaSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2009/12/02 Add >>>
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2011/7/22 XUJS ADD END<<<<<<

			// 得意先コード
			if (this.Condition_CustomerCode_Panel.Visible)
			{
				this.tNedit_CustomerCode.SetInt(conditionInfo.CustomerCode);
			}
			else
			{
				this.tNedit_CustomerCode.Clear();
			}

			// 得意先サブコード
			if (this.Condition_CustomerSubCode_Panel.Visible)
			{
				this.tEdit_CustomerSubCode.DataText = conditionInfo.CustomerSubCode;

				if (conditionInfo.CustomerSubCodeSearchType == 1)
				{
					this.CustomerSubCodeSearchType_UCheckEditor.Checked = true;
				}
				else
				{
					this.CustomerSubCodeSearchType_UCheckEditor.Checked = false;
				}
			}
			else
			{
				this.tEdit_CustomerSubCode.Clear();
				this.CustomerSubCodeSearchType_UCheckEditor.Checked = false;
			}

			// 得意先カナ
			if (this.Condition_Kana_Panel.Visible)
			{
				this.tEdit_CustomerKana.DataText = conditionInfo.Kana;

				if (conditionInfo.KanaSearchType == 1)
				{
					this.KanaSearchType_UCheckEditor.Checked = true;
				}
				else
				{
					this.KanaSearchType_UCheckEditor.Checked = false;
				}
			}
			else
			{
				this.tEdit_CustomerKana.Clear();
				this.KanaSearchType_UCheckEditor.Checked = false;
			}

			// 電話番号（電話番号下４桁）
			if (this.Condition_SearchTelNo_Panel.Visible)
			{
				this.SearchTelNo_TEdit.DataText = conditionInfo.SearchTelNo;
			}
			else
			{
				this.SearchTelNo_TEdit.Clear();
			}

			// 得意先種別
			this.SetCustomerDivCheckEditor(conditionInfo);

			//this.SetCheckEditorChecked(this.SupplierDiv_UCheckEditor, EXIST_CODE_CHECKED, conditionInfo.SupplierDiv);			// 仕入先区分
			//this.SetCheckEditorChecked(this.AcceptWholeSale_UCheckEditor, EXIST_CODE_CHECKED, conditionInfo.AcceptWholeSale);	// 業販先区分

			// 分析コード
			this.CustAnalysCode1_TNedit.SetInt(conditionInfo.CustAnalysCode1);
			this.CustAnalysCode2_TNedit.SetInt(conditionInfo.CustAnalysCode2);
			this.CustAnalysCode3_TNedit.SetInt(conditionInfo.CustAnalysCode3);
			this.CustAnalysCode4_TNedit.SetInt(conditionInfo.CustAnalysCode4);
			this.CustAnalysCode5_TNedit.SetInt(conditionInfo.CustAnalysCode5);
			this.CustAnalysCode6_TNedit.SetInt(conditionInfo.CustAnalysCode6);

			// 得意先担当
			this.tEdit_EmployeeNm.Text = conditionInfo.CustomerAgentNm;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 管理拠点
            this.tEdit_MngSectionNm.Text = conditionInfo.MngSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            // 得意先名
            if (this.Condition_Name_Panel.Visible)
            {
                this.tEdit_CustomerName.DataText = conditionInfo.Name;

                if (conditionInfo.NameSearchType == 1)
                {
                    this.NameSearchType_UCheckEditor.Checked = true;
                }
                else
                {
                    this.NameSearchType_UCheckEditor.Checked = false;
                }
            }
            else
            {
                this.tEdit_CustomerName.Clear();
                this.NameSearchType_UCheckEditor.Checked = false;
            }
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            // 得意先略称
            if (this.Condition_CustomerSnm_Panel.Visible)
            {
                this.tEdit_CustomerSnm.DataText = conditionInfo.CustomerSnm;

                if (conditionInfo.CustomerSnmSearchType == 1)
                {
                    this.SnmSearchType_UCheckEditor.Checked = true;
                }
                else
                {
                    this.SnmSearchType_UCheckEditor.Checked = false;
                }
            }
            else
            {
                this.tEdit_CustomerSnm.Clear();
                this.SnmSearchType_UCheckEditor.Checked = false;
            }
            // 2011/7/22 XUJS ADD END<<<<<<

            // ---ADD 2010/08/06-------------------->>>
            // 電話番号
            if (this.Condition_TelNum_Panel.Visible)
            {
                this.tEdit_TelNum.DataText = conditionInfo.TelNum;

                if (conditionInfo.TelNumSearchType == 1)
                {
                    this.TelNum_UCheckEditor.Checked = true;
                }
                else
                {
                    this.TelNum_UCheckEditor.Checked = false;
                }
            }
            else
            {
                this.tEdit_TelNum.Clear();
                this.TelNum_UCheckEditor.Checked = false;
            }
            // ---ADD 2010/08/06--------------------<<<

			// イベントを再設定
            //this.SupplierDiv_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.Customer_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.Receiver_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
			this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
			this.KanaSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2009/12/02 Add >>>
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2011/7/22 XUJS ADD END<<<<<<


            // ---ADD 2010/08/06-------------------->>>
            this.TelNum_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.TelNum_UCheckEditor_AfterCheckStateChanged);
            // ---ADD 2010/08/06--------------------<<<
		}

		/// <summary>
		/// DrawFilterによるコントロールの再描画通知用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void UltraTree_DropHightLight_DrawFilter_Invalidate(object sender, System.EventArgs e)
		{
			// DropHighLightが変更した場合、コントロールに再描画の通知が必要になります
			// ここでは、コントロールの再描画を通知します
			this.ExtractConditionSetting_UTree.Invalidate();
		}

		//選択されているノードの親元が選択されているかを確認します。
		private bool IsAnyParentSelected(Infragistics.Win.UltraWinTree.UltraTreeNode Node) 
		{
			Infragistics.Win.UltraWinTree.UltraTreeNode parentNode;
			bool returnValue = false;

			parentNode = Node.Parent;
			while (parentNode != null)
			{
				if (parentNode.Selected)
				{
					returnValue = true;
					break;
				}
				else
				{
					parentNode = parentNode.Parent;
				}
			} 

			return returnValue;
		}

		//このイベントでは、特定のノードにおいてどのようなドロップ操作を
		//するか、指定できます。
		private void UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode(Object sender, UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventArgs e )
		{
			e.StatesAllowed = DropLinePositionEnum.AboveNode | DropLinePositionEnum.BelowNode;
		}

		/// <summary>
		/// 抽出条件設定ツリー構築処理
		/// </summary>
		/// <param name="extractConditionItemList">抽出条件設定クラスリスト</param>
		/// <remarks>
		/// <br>Note       : 抽出条件設定クラスリストを元に、抽出条件設定ツリーを構築します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void ExtractConditionTreeConstruction(List<ExtractConditionItem> extractConditionItemList)
		{
			// 抽出条件ツリーノードを初期化
			this.ExtractConditionSetting_UTree.Nodes.Clear();

			// 抽出条件クラスリストからツリーノードを構築
			foreach(ExtractConditionItem item in extractConditionItemList)
			{
				Infragistics.Win.UltraWinTree.UltraTreeNode node = new Infragistics.Win.UltraWinTree.UltraTreeNode(item.Key, item.Name);

				/*
				// 追加情報２タイトル変更
				if (item.Key == "CarNo")
				{
					node.Text = PMKHN04001UA.GetAddInfoDspName(2);
				}
				*/

				node.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;

				if (item.IsDisplay())
				{
					node.CheckedState = CheckState.Checked;
				}
				else
				{
					node.CheckedState = CheckState.Unchecked;
				}

				this.ExtractConditionSetting_UTree.Nodes.Add(node);
			}
		}

		/// <summary>
		/// 抽出条件設定入力項目構築処理
		/// </summary>
		/// <param name="extractConditionItemList">抽出条件設定クラスリスト</param>
		/// <remarks>
		/// <br>Note       : 抽出条件設定クラスリストを元に、抽出条件設定入力項目を構築します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private void ExtractConditionInputItemConstruction(List<ExtractConditionItem> extractConditionItemList)
		{
			foreach (ExtractConditionItem item in extractConditionItemList)
			{
				string name = this.GetExtractConditionPanelName(item);
				if (!(this._extractConditionItemControlDictionary.ContainsKey(name))) continue;

				Panel targetPanel = this._extractConditionItemControlDictionary[name];

				targetPanel.Visible = false;
				targetPanel.Dock = DockStyle.Top;
				targetPanel.TabIndex = 0;
			}

			int tabIndex = 0;
			foreach (ExtractConditionItem item in extractConditionItemList)
			{
				if (!item.IsDisplay()) continue;

				string name = this.GetExtractConditionPanelName(item);
				if (!(this._extractConditionItemControlDictionary.ContainsKey(name))) continue;

				Panel targetPanel = this._extractConditionItemControlDictionary[name];

				targetPanel.Visible = item.DisplayFlg;
				targetPanel.BringToFront();
				targetPanel.TabIndex = tabIndex++;
			}

			this.Condition_Header_Panel.SendToBack();
			this.Condition_CustomerCode_Panel.Refresh();
		}

		/// <summary>
		/// 抽出条件設定クラスリスト構築処理
		/// </summary>
		/// <returns>抽出条件設定クラスリスト</returns>
		/// <remarks>
		/// <br>Note       : 抽出条件設定ツリーを元に抽出条件設定クラスリストを構築します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		private List<ExtractConditionItem> ExtractConditionItemListConstruction()
		{
			List<ExtractConditionItem> extractConditionItemList = new List<ExtractConditionItem>();

			int no = 0;
			foreach (Infragistics.Win.UltraWinTree.UltraTreeNode node in this.ExtractConditionSetting_UTree.Nodes)
			{
				ExtractConditionItem item = new ExtractConditionItem();
				item.Key = node.Key.ToString();
				item.No = ++no;
				item.Name = node.Text;

				if (node.CheckedState == CheckState.Checked)
				{
					item.DisplayFlg = true;
				}
				else
				{
					item.DisplayFlg = false;
				}

				extractConditionItemList.Add(item);
			}

			return extractConditionItemList;
		}

		private string GetExtractConditionPanelName(ExtractConditionItem extractConditionItem)
		{
			return "Condition_" + extractConditionItem.Key + "_Panel";
		}

		private static Control FindControl(Control hParent, string nSearchName) 
		{
			// hParent 内のすべてのコントロールを列挙する
			foreach (Control hControl in hParent.Controls) 
			{
				// 列挙したコントロールにコントロールが含まれている場合は再帰呼び出しする
				if (hControl.HasChildren) 
				{
					Control hFindControl = FindControl(hControl, nSearchName);

					// 再帰呼び出し先でコントロールが見つかった場合はそのまま返す
					if (hFindControl != null) 
					{
						return hFindControl;
					}
				}

				// コントロール名が合致した場合はそのコントロールのインスタンスを返す
				if (hControl.Name == nSearchName) 
				{
					return hControl;
				}
			}

			return null;
		}

		/// <summary>
		/// 抽出条件入力項目パネル表示位置設定処理
		/// </summary>
		private void ExtractConditionItemPositionSetting()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            //// 抽出条件入力項目パネル高さ合計取得処理
            //int totalHeight = this.GetExtractConditionPanelTotalHeight();

            //if (totalHeight > this.Condition_Panel.Height)
            //{
            //    // 縦スクロールバーが表示されている場合
            //    this.tEdit_CustomerSubCode.Left = 15;
            //    this.SearchTelNo_TEdit.Left = 15;
            //    this.tNedit_CustomerCode.Left = 15;
            //    this.tEdit_CustomerKana.Left = 15;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //this.SupplierDiv_UCheckEditor.Left = 15;
            //    this.Customer_UCheckEditor.Left = 15;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    this.CustAnalysCode1_TNedit.Left = 15;
            //    this.tEdit_EmployeeNm.Left = 15;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    this.tEdit_MngSectionNm.Left = 15;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}
            //else
            //{
            //    // 縦スクロールバーが表示されていない場合
            //    this.tEdit_CustomerSubCode.Left = 25;
            //    this.SearchTelNo_TEdit.Left = 25;
            //    this.tNedit_CustomerCode.Left = 25;
            //    this.tEdit_CustomerKana.Left = 25;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //this.SupplierDiv_UCheckEditor.Left = 25;
            //    this.Customer_UCheckEditor.Left = 25;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //    this.CustAnalysCode1_TNedit.Left = 25;
            //    this.tEdit_EmployeeNm.Left = 25;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    this.tEdit_MngSectionNm.Left = 25;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////this.AcceptWholeSale_UCheckEditor.Left = this.SupplierDiv_UCheckEditor.Left + this.AcceptWholeSale_UCheckEditor.Width + 5;
            ////this.Customer_UCheckEditor.Left = this.AcceptWholeSale_UCheckEditor.Left + this.Customer_UCheckEditor.Width + 5;
            ////this.SupplierDiv_UCheckEditor.Left = this.Customer_UCheckEditor.Left + this.Customer_UCheckEditor.Width + 5;
            //this.Receiver_UCheckEditor.Left = this.Customer_UCheckEditor.Left + this.Customer_UCheckEditor.Width + 5;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //this.CustAnalysCode2_TNedit.Left = this.CustAnalysCode1_TNedit.Left + this.CustAnalysCode1_TNedit.Width + 3;
            //this.CustAnalysCode3_TNedit.Left = this.CustAnalysCode2_TNedit.Left + this.CustAnalysCode2_TNedit.Width + 3;
            //this.CustAnalysCode4_TNedit.Left = this.CustAnalysCode3_TNedit.Left + this.CustAnalysCode3_TNedit.Width + 3;
            //this.CustAnalysCode5_TNedit.Left = this.CustAnalysCode4_TNedit.Left + this.CustAnalysCode4_TNedit.Width + 3;
            //this.CustAnalysCode6_TNedit.Left = this.CustAnalysCode5_TNedit.Left + this.CustAnalysCode5_TNedit.Width + 3;
            //this.CustomerAgentCdGuide_UButton.Left = this.tEdit_EmployeeNm.Left + this.tEdit_EmployeeNm.Width + 2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.MngSectionCodeGuide_UButton.Left = this.tEdit_MngSectionNm.Left + this.tEdit_MngSectionNm.Width + 2;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/// <summary>
		/// 抽出条件入力項目パネル高さ合計取得処理
		/// </summary>
		/// <returns>高さ合計値</returns>
		private int GetExtractConditionPanelTotalHeight()
		{
			int totalHeight = this.Condition_Header_Panel.Height;

			// 抽出条件入力項目Dictionaryを生成
			foreach(ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
			{
				string name = this.GetExtractConditionPanelName(item);
				Control targetControl = FindControl(this, name);

				if ((targetControl != null) && (targetControl is Panel))
				{
					if (targetControl.Visible)
					{
						totalHeight = totalHeight + targetControl.Height;
					}
				}
			}

			return totalHeight;
		}

		/// <summary>
		/// 抽出条件入力項目パネルリスト取得処理
		/// </summary>
		/// <param name="visibleCheck">表示設定判定フラグ</param>
		/// <returns>抽出条件入力項目パネルリスト</returns>
		private List<Control> GetExtractConditionPanelList(bool visibleCheck)
		{
			List<Control> controlList = new List<Control>();

			// 抽出条件入力項目Dictionaryを生成
			foreach(ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
			{
				string name = this.GetExtractConditionPanelName(item);
				Control targetControl = FindControl(this, name);

				if ((targetControl != null) && (targetControl is Panel))
				{
					if (visibleCheck)
					{
						if (targetControl.Visible)
						{
							controlList.Add(targetControl);
						}
					}
					else
					{
						controlList.Add(targetControl);
					}
				}
			}

			return controlList;
		}

		/// <summary>
		/// 対象パネルコントロール取得処理（テキストエディタ）
		/// </summary>
		/// <param name="sender">対象パネル</param>
		/// <returns>テキストエディタオブジェクト</returns>
		private Infragistics.Win.UltraWinEditors.UltraTextEditor GetTextEditorOnPanel(Panel sender)
		{
			Infragistics.Win.UltraWinEditors.UltraTextEditor target = null;

			foreach (Control control in sender.Controls)
			{
				if (control is Infragistics.Win.UltraWinEditors.UltraTextEditor)
				{
					target = (Infragistics.Win.UltraWinEditors.UltraTextEditor)control;
					break;
				}
			}

			return target;
		}

		/// <summary>
		/// 抽出条件履歴リスト レコード追加処理
		/// </summary>
        /// <param name="para">抽出条件入力情報クラス</param>
		private void AddExtractConditionList(CustomerSearchExtractionConditionInfo para)
		{
			int count = this._extractConditionList.Count;
			if (count == 0)
			{
				this._extractConditionList.Add(para.Clone());
				return;
			}

			// 最終アイテムと情報が違う場合のみ、新たに抽出条件入力情報クラスを追加する
			CustomerSearchExtractionConditionInfo buff = this._extractConditionList[count - 1];

			if (!(buff.Equals(para)))
			{
				this._extractConditionList.Add(para.Clone());
			}
		}
			
		/// <summary>
		/// 列表示状態クラスリスト構築処理
		/// </summary>
		/// <param name="columns">グリッドのカラムコレクション</param>
		/// <returns>列表示状態クラスリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.05.31</br>
		/// </remarks>
		private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
			List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

			// フォントサイズを格納
			ColDisplayStatus fontStatus = new ColDisplayStatus();
			fontStatus.Key = this.GridFontSize_TComboEditor.Name;
			fontStatus.VisiblePosition = -1;
			fontStatus.Width = (int)this.GridFontSize_TComboEditor.Value;
			colDisplayStatusList.Add(fontStatus);

			// グリッドから列表示状態クラスリストを構築
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

				colDisplayStatus.Key = column.Key;
				colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
				colDisplayStatus.HeaderFixed = column.Header.Fixed;
				colDisplayStatus.Width = column.Width;

				colDisplayStatusList.Add(colDisplayStatus);
			}

			return colDisplayStatusList;
		}

		/// <summary>
		/// チェックエディタチェック数値設定処理
		/// </summary>
		/// <param name="sender">対象となるチェックエディタ</param>
		/// <param name="checkedValue">チェック有り時設定値</param>
		/// <param name="unCheckedValue">チェック無し時設定値</param>
		/// <returns>設定値</returns>
		private int GetCheckEditorValue(Infragistics.Win.UltraWinEditors.UltraCheckEditor sender, int checkedValue, int unCheckedValue)
		{
			if (sender.Checked)
			{
				return checkedValue;
			}
			else
			{
				return unCheckedValue;
			}
		}

		/// <summary>
		/// 得意先種別ステータス設定処理
		/// </summary>
		/// <param name="conditionInfo">抽出条件クラス</param>
		private void SetCustomerDivCheckEditor(CustomerSearchExtractionConditionInfo conditionInfo)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 DEL
            //if ((conditionInfo.SupplierDiv == -1) && (conditionInfo.AcceptWholeSale == -1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == 0) && (conditionInfo.AcceptWholeSale == 0))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = false;
            //}
            //else if ((conditionInfo.SupplierDiv == 1) && (conditionInfo.AcceptWholeSale == 1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //    this.Customer_UCheckEditor.Checked = true;
            //    this.Receiver_UCheckEditor.Checked = false;
            //}
            //else if ((conditionInfo.SupplierDiv == -1) && (conditionInfo.AcceptWholeSale == 0))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = true;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == 0) && (conditionInfo.AcceptWholeSale == 1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = true;
            //    this.Receiver_UCheckEditor.Checked = false;
            //}
            //else if ((conditionInfo.SupplierDiv == 1) && (conditionInfo.AcceptWholeSale == -1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == -1) && (conditionInfo.AcceptWholeSale == 1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = false;
            //    this.Customer_UCheckEditor.Checked = true;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == 0) && (conditionInfo.AcceptWholeSale == -1))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ((conditionInfo.SupplierDiv == 1) && (conditionInfo.AcceptWholeSale == 0))
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //    this.Customer_UCheckEditor.Checked = false;
            //    this.Receiver_UCheckEditor.Checked = false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
            if ( conditionInfo.AcceptWholeSale == 2 )
            {
                // 納入先
                this.Receiver_UCheckEditor.Checked = true;
                this.Customer_UCheckEditor.Checked = false;
            }
            else if ( conditionInfo.AcceptWholeSale == 1 )
            {
                // 得意先
                this.Customer_UCheckEditor.Checked = true;
                this.Receiver_UCheckEditor.Checked = false;
            }
            else
            {
                // 全て
                this.Customer_UCheckEditor.Checked = false;
                this.Receiver_UCheckEditor.Checked = false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
		}

		/// <summary>
		/// 得意先種別ステータス設定処理
		/// </summary>
		/// <param name="conditionInfo">抽出条件クラス</param>
		private void SetCustomerDivStatus(ref CustomerSearchExtractionConditionInfo conditionInfo)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 DEL
            //if ((!this.Receiver_UCheckEditor.Checked) && (!this.SupplierDiv_UCheckEditor.Checked) && (!this.Customer_UCheckEditor.Checked))
            //{
            //    conditionInfo.SupplierDiv = 0;
            //    conditionInfo.AcceptWholeSale = 0;
            //}
            //else if (this.Receiver_UCheckEditor.Checked)
            //{
            //    if (!this.SupplierDiv_UCheckEditor.Checked)
            //    {
            //        conditionInfo.SupplierDiv = -1;
            //    }
            //    else
            //    {
            //        conditionInfo.SupplierDiv = 0;
            //    }

            //    if (!this.Customer_UCheckEditor.Checked)
            //    {
            //        conditionInfo.AcceptWholeSale = -1;
            //    }
            //    else
            //    {
            //        conditionInfo.AcceptWholeSale = 0;
            //    }
            //}
            //else
            //{
            //    if (!this.SupplierDiv_UCheckEditor.Checked)
            //    {
            //        conditionInfo.SupplierDiv = 0;
            //    }
            //    else
            //    {
            //        conditionInfo.SupplierDiv = 1;
            //    }

            //    if (!this.Customer_UCheckEditor.Checked)
            //    {
            //        conditionInfo.AcceptWholeSale = 0;
            //    }
            //    else
            //    {
            //        conditionInfo.AcceptWholeSale = 1;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
            if ( this.Receiver_UCheckEditor.Checked )
            {
                if ( this.Customer_UCheckEditor.Checked )
                {
                    // 得意先・納入先の両方がチェック
                    conditionInfo.AcceptWholeSale = -1;
                }
                else
                {
                    // 納入先のみチェック
                    conditionInfo.AcceptWholeSale = 2;
                }
            }
            else if ( this.Customer_UCheckEditor.Checked )
            {
                // 得意先のみチェック
                conditionInfo.AcceptWholeSale = 1;
            }
            else
            {
                // どちらも未チェック
                conditionInfo.AcceptWholeSale = -1;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
		}

		/// <summary>
		/// チェックエディタチェック設定処理
		/// </summary>
		/// <param name="sender">対象となるチェックエディタ</param>
		/// <param name="checkedValue">チェックを付ける再の値</param>
		/// <param name="dataValue">設定値</param>
		private void SetCheckEditorChecked(Infragistics.Win.UltraWinEditors.UltraCheckEditor sender, int checkedValue, int dataValue)
		{
			if (checkedValue == dataValue)
			{
				sender.Checked = true;
			}
			else
			{
				sender.Checked = false;
			}
		}

		/// <summary>
		/// 詳細表示フォーム設定処理
		/// </summary>
		/// <param name="detailsFormType">詳細フォーム表示タイプ</param>
		private void SetDetailsFormSetting(int detailsFormType)
		{
			if (detailsFormType == CustomerSearchConstructionAcs.FIRST_DISPLAY_DETAILS_0)
			{
				this.DetailView_Panel.Controls.Add(this._detailViewForm.webBrowser_DetailView);
				this._detailViewForm.Hide();
				this.DetailView_Panel.Visible = true;
				this.DetailView_Splitter.Visible = true;
				this.ExtractResult_Panel.Dock = DockStyle.Top;

				this.DetailView_Timer.Enabled = true;
			}
			else if (detailsFormType == CustomerSearchConstructionAcs.FIRST_DISPLAY_DETAILS_1)
			{
				this._detailViewForm.Controls.Add(this._detailViewForm.webBrowser_DetailView);
				this._detailViewForm.Show();
				this.DetailView_Panel.Visible = false;
				this.DetailView_Splitter.Visible = false;
				this.ExtractResult_Panel.Dock = DockStyle.Fill;

				this.DetailView_Timer.Enabled = true;
			}
			else if (detailsFormType == CustomerSearchConstructionAcs.FIRST_DISPLAY_DETAILS_2)
			{
				this.DetailView_Panel.Visible = false;
				this.DetailView_Splitter.Visible = false;
				this._detailViewForm.Hide();
				this.ExtractResult_Panel.Dock = DockStyle.Fill;
			}
		}

		/// <summary>
		/// 全体項目表示名称マスタ取得処理
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称マスタ</param>
		/// <returns>ステータス</returns>
		private static int GetAlItmDspNm(out AlItmDspNm alItmDspNm)
		{
			// 表示名称設定
			AlItmDspNmAcs alItmDspNmAcs = new AlItmDspNmAcs();
			int status = alItmDspNmAcs.ReadStatic(out alItmDspNm, LoginInfoAcquisition.EnterpriseCode);

			if (alItmDspNm == null) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			return status;
		}

		/// <summary>
		/// 追加情報表示名称取得処理
		/// </summary>
		/// <param name="no">№</param>
		/// <returns>追加情報表示名称</returns>
		internal static string GetAddInfoDspName(int no)
		{
			string addInfoDspName = "";

			AlItmDspNm alItmDspNm;
			if (PMKHN04001UA.GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				switch (no)
				{
					case 1:
					{
						addInfoDspName = alItmDspNm.AddInfo1DspName;
						break;
					}
					case 2:
					{
						addInfoDspName = alItmDspNm.AddInfo2DspName;
						break;
					}
					case 3:
					{
						addInfoDspName = alItmDspNm.AddInfo3DspName;
						break;
					}
				}
			}

			return addInfoDspName;
		}

		/// <summary>
		/// 電話番号表示名称取得処理
		/// </summary>
		/// <param name="no">№</param>
		/// <returns>電話番号表示名称</returns>
		internal static string GetTelNoDspName(int no)
		{
			string telNoDspName = "";

			AlItmDspNm alItmDspNm;
			if (PMKHN04001UA.GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				switch (no)
				{
					case 0:
					{
						telNoDspName = alItmDspNm.HomeTelNoDspName;
						break;
					}
					case 1:
					{
						telNoDspName = alItmDspNm.OfficeTelNoDspName;
						break;
					}
					case 2:
					{
						telNoDspName = alItmDspNm.MobileTelNoDspName;
						break;
					}
					case 3:
					{
						telNoDspName = alItmDspNm.HomeFaxNoDspName;
						break;
					}
					case 4:
					{
						telNoDspName = alItmDspNm.OfficeFaxNoDspName;
						break;
					}
					case 5:
					{
						telNoDspName = alItmDspNm.OtherTelNoDspName;
						break;
					}
				}
			}

			return telNoDspName;
		}

		/// <summary>
		/// 得意先検索パラメータクラスチェック処理
		/// </summary>
		/// <param name="para">得意先検索パラメータクラス</param>
		/// <returns>true:チェックＯＫ false:チェックＮＧ</returns>
		private bool CheckCustomerSearchPara(CustomerSearchExtractionConditionInfo para)
		{
			if (!this.IsExtractionConditionClassSetting(para))
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"抽出条件を設定してください。",
					0,
					MessageBoxButtons.OK);

				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// 得意先新規入力起動処理
		/// </summary>
		private void ShowCustomerNew()
		{
			PMKHN09000UA customerInputForm = new PMKHN09000UA();
			customerInputForm.FormClosing += new FormClosingEventHandler(this.CustomerInputForm_FormClosing);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
            // データ更新イベント
            customerInputForm.AfterCustomerRecordUpdate += new PMKHN09000UA.AfterCustomerRecordUpdateEventHandler( this.CustomerInputForm_AfterCustomerRecordUpdate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

			this._customerFormList.Add(customerInputForm);
			this._customerFormDictionary.Add(customerInputForm.Key, customerInputForm);
			customerInputForm.Show();
		}

		/// <summary>
		/// 得意先編集起動処理
		/// </summary>
		/// <param name="sender">起動元オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		private void ShowCustomerEdit(object sender, string enterpriseCode, int customerCode)
		{
			this.Cursor = Cursors.AppStarting;
			bool exist = false;
			string key = this.GetKey(enterpriseCode, customerCode);

			foreach (PMKHN09000UA customerInputForm in this._customerFormList)
			{
				if (!customerInputForm.IsDisposed)
				{
					if (customerInputForm.GetSelectedInfoKey() == key)
					{
						customerInputForm.BringToFront();
						exist = true;
						break;
					}
				}
			}

			if (!exist)
			{
				PMKHN09000UA customerInputForm = new PMKHN09000UA(PMKHN09000UA.EXEC_MODE_EDIT, enterpriseCode, customerCode);
				customerInputForm.FormClosing += new FormClosingEventHandler(this.CustomerInputForm_FormClosing);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                // データ更新イベント
                customerInputForm.AfterCustomerRecordUpdate += new PMKHN09000UA.AfterCustomerRecordUpdateEventHandler( this.CustomerInputForm_AfterCustomerRecordUpdate );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

				this._customerFormList.Add(customerInputForm);
				customerInputForm.Show();
				customerInputForm.BringToFront();
			}
			this.Cursor = Cursors.Default;
		}

		/// <summary>
		/// クリア処理
		/// </summary>
		private void Clear()
		{
			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();
			this._extractConditionList.Clear();
			this._extractionConditionInfo = new CustomerSearchExtractionConditionInfo();

			// 検索条件入力コントロール情報設定
			this.SettingExtractConditionItemInfo(this._extractionConditionInfo);

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// 得意先入力フォーム終了イベント処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void CustomerInputForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!(sender is PMKHN09000UA)) return;

			if (this._customerFormDictionary.ContainsKey(((PMKHN09000UA)sender).Key))
			{
				try
				{
					this._customerFormList.Remove(this._customerFormDictionary[((PMKHN09000UA)sender).Key]);
					this._customerFormDictionary.Remove(((PMKHN09000UA)sender).Key);
				}
				catch { }
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        /// <summary>
        /// 得意先入力フォームデータ更新イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        private void CustomerInputForm_AfterCustomerRecordUpdate( object sender, CustomerSearchRet customerSearchRet )
        {
            if ( !(sender is PMKHN09000UA) ) return;

            // TODO:入力フォームでデータ更新されたらデータビューを更新する。
            DataRow targetRow = null;
            foreach ( DataRow row in this.Search_DataSet.Tables[SEARCH_TABLE].Rows )
            {
                if ( (Int32)row[SEARCH_COL_CustomerCode] == customerSearchRet.CustomerCode )
                {
                    targetRow = row;
                    break;
                }
            }
            // 対象行の更新
            if ( targetRow != null )
            {
                if ( customerSearchRet.LogicalDeleteCode != 3 )
                {
                    // 更新or論理削除
                    CustomerSearchRetToDataRow( customerSearchRet, targetRow );
                }
                else
                {
                    // 完全削除
                    this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Remove( targetRow );
                }
            }
            else
            {
                // 追加
                targetRow = CustomerSearchRetToDataRow( customerSearchRet, null );
                this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Add( targetRow );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

		/// <summary>
		/// キー文字列取得処理
		/// </summary>
		/// <returns>キー文字列</returns>
		private string GetKey(string enterpriseCode, int customerCode)
		{
			if (customerCode == 0)
			{
				return "";
			}
			else
			{
				return enterpriseCode + "-" + customerCode.ToString();
			}
		}

        // --- ADD 2009/09/02 -------------------------------->>>>>
        /// <summary>
        /// グリッドのフィルタリング処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 論理削除フラグによるグリッド列のフィルタリングを行います。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        private void AddGridFiltering()
        {

            int index = -1;

            // 削除日列のindexを取得
            for (int i = 0; i < this.Search_DataSet.Tables[SEARCH_TABLE].Columns.Count; i++)
            {
                if (Search_DataSet.Tables[SEARCH_TABLE].Columns[i].ColumnName == SEARCH_COL_LogicalDeleteDate)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                // 行フィルタがバンドに基づいている場合、バンドの列フィルタを外す。
                Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.SearchResult_UGrid.DisplayLayout.Bands[0].ColumnFilters;
                columnFilters.ClearAllFilters();

                this._searchDataView.RowFilter = string.Empty;

                if (DeleteIndication_CheckEditor.Checked == false)
                {
                    // 空白とNull以外をフィルタに設定する
                    columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                    columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                    columnFilters[index].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;

                    this._searchDataView.RowFilter = string.Format( "{0}=0", SEARCH_COL_LogicalDeleteCode );
                }
            }
        }
        // --- ADD 2009/09/02 --------------------------------<<<<<

		/// <summary>
		/// 従業員検索処理(SFTOK09382A.DLL)
		/// </summary>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="employeeName">従業員名称</param>
		/// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
		public int GetEmployeeFromEmployeeCode(string employeeCode, out string employeeName)
		{
			employeeName = "";
			Employee employee = new Employee();

			int status = this._employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				employeeName = employee.Name;
			}

			return status;
		}

		/// <summary>
		/// 従業員ガイド表示処理(SFTOK09382A.DLL)
		/// </summary>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="employeeName">従業員名称</param>
		/// <returns>STATUS [0:選択 0以外:未選択]</returns>
		public int ShowEmployeeGuide(out string employeeCode, out string employeeName)
		{
			Employee employee = new Employee();
			employeeCode = "";
			employeeName = "";

			int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				employeeCode = employee.EmployeeCode;
				employeeName = employee.Name;
			}

			return status;
		}

		/// <summary>
		/// 得意先編集ボタンクリック処理
		/// </summary>
		private void CustomerEditButtonClick()
		{
			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"得意先が選択されていません。",
					0,
					MessageBoxButtons.OK);
				return;
			}

			// 選択行のインデックスを取得
			CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
			int index = cm.Position;

			// 指定行の内容を取得
			DataRow row = this._searchDataView[index].Row;

			// 得意先検索結果クラス取得処理（グリッド行より）
			CustomerSearchRet customerSearchRet = this.DataRowToCustomerSearchRet(row);

			// 得意先編集起動処理
			this.ShowCustomerEdit(this, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);
		}

		/// <summary>
		/// 選択ボタンクリック処理
		/// </summary>
		private void SelectButtonClick()
		{
			CustomerSearchRet customerSearchRet;
			int stauts = this.GetSelectInfo(out customerSearchRet);

			if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (this.CustomerSelect != null)
				{
					this.CustomerSelect(this, customerSearchRet);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                    this.DialogResult = DialogResult.OK;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
					this.Close();
				}
			}
		}

		/// <summary>
		/// 最上位親フォーム取得処理
		/// </summary>
		/// <returns>最上位親フォームクラス</returns>
		private Form GetTopLevelOwnerForm()
		{
			bool exists = true;
			Form ownerForm = this.Owner;

			if (ownerForm != null)
			{
				while (exists)
				{
					if ((ownerForm.Owner != null) && (ownerForm.Owner is Form))
					{
						ownerForm = ownerForm.Owner;
					}
					else
					{
						break;
					}
				}

			}

			return ownerForm;
		}

		/// <summary>
		/// ログ出力(DEBUG)処理
		/// </summary>
		/// <param name="pMode">モード</param>
		/// <param name="pMsg">メッセージ</param>
		public static void LogWrt(int pMode, string pMsg)
		{
			#if DEBUG
			System.IO.FileStream _fs;										// ファイルストリーム
			System.IO.StreamWriter _sw;										// ストリームwriter
			_fs = new FileStream( "PMKHN04001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write );
			_sw = new System.IO.StreamWriter( _fs, System.Text.Encoding.GetEncoding( "shift_jis" ) );
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine( string.Format( "{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg ) );
			if( _sw != null )
				_sw.Close();
			if( _fs != null )
				_fs.Close();
			#endif
		}
		# endregion

		// ===================================================================================== //
		// 各コンポーネントイベント処理
		// ===================================================================================== //
		# region Component Event Methods
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void PMKHN04001UA_Load(object sender, System.EventArgs e)
		{
			// 画面初期化処理
			this.InitialSetting();

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/08/18 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列修正(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			// 初期フォーカス設定
			List<Control> controls = this.GetExtractConditionPanelList(true);
			
			if (controls.Count > 0)
			{
				Infragistics.Win.UltraWinEditors.UltraTextEditor textEditor = this.GetTextEditorOnPanel((Panel)controls[0]);

				if (textEditor != null)
				{
					this.Search_UButton.Focus();
					this.ActiveControl = textEditor;
					textEditor.Focus();
				}
			}

			this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
            this.KanaSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2009/12/02 Add >>>
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged -= new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2011/7/22 XUJS ADD END<<<<<<

			// 曖昧検索チェックボックス初期値設定
			if (this._customerSearchConstructionAcs.StringSearchInitialType == CustomerSearchConstructionAcs.STRING_SEARCH_INITIAL_TYPE_0)
			{
				this.CustomerSubCodeSearchType_UCheckEditor.Checked = false;
				this.KanaSearchType_UCheckEditor.Checked = false;

                // 2009/12/02 Add >>>
                this.NameSearchType_UCheckEditor.Checked = false;
                // 2009/12/02 Add <<<

                // 2011/7/22 XUJS ADD STA>>>>>>
                this.SnmSearchType_UCheckEditor.Checked = false;
                // 2011/7/22 XUJS ADD END<<<<<<

                // ---ADD 2010/08/06-------------------->>>
                this.TelNum_UCheckEditor.Checked = false;
                // ---ADD 2010/08/06--------------------<<<
            }
			else
			{
				this.CustomerSubCodeSearchType_UCheckEditor.Checked = true;
				this.KanaSearchType_UCheckEditor.Checked = true;

                // 2009/12/02 Add >>>
                this.NameSearchType_UCheckEditor.Checked = true;
                // 2009/12/02 Add <<<

                // 2011/7/22 XUJS ADD STA>>>>>>
                this.SnmSearchType_UCheckEditor.Checked = true;
                // 2011/7/22 XUJS ADD END<<<<<<

                // ---ADD 2010/08/06-------------------->>>
                this.TelNum_UCheckEditor.Checked = true;
                // ---ADD 2010/08/06--------------------<<<


				this._extractionConditionInfo.CustomerSubCodeSearchType = 1;
				this._extractionConditionInfo.KanaSearchType = 1;

                // 2009/12/02 Add >>>
                this._extractionConditionInfo.NameSearchType = 1;
                // 2009/12/02 Add <<<

                // ---ADD 2010/08/06-------------------->>>
                this._extractionConditionInfo.TelNumSearchType = 1;
                // ---ADD 2010/08/06--------------------<<<
			}

			this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
			this.KanaSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2009/12/02 Add >>>
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);

            // 2011/7/22 XUJS ADD STA>>>>>>
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 2011/7/22 XUJS ADD END<<<<<<


            // 自動検索チェックボックス初期値設定
            if (this._customerSearchConstructionAcs.AutoSearch == CustomerSearchConstructionAcs.AUTO_SEARCH_0)
            {
                this.AutoSearch_UCheckEditor.Checked = true;
            }
            else
            {
                this.AutoSearch_UCheckEditor.Checked = false;
            }

            // 複数選択チェックボックス初期値
            if (this._customerSearchConstructionAcs.MultiSelect == CustomerSearchConstructionAcs.MULTI_SEARCH_0)
            {
                this.MultiSelect_UCheckEditor.Checked = true;
            }
            else
            {
                this.MultiSelect_UCheckEditor.Checked = false;
            }
            // 2009/12/02 Add <<<


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 DEL
            //if ( this._searchMode == SEARCHMODE_SUPPLIER )
            //{
            //    this.SupplierDiv_UCheckEditor.Checked = true;
            //}
            //else if ( this._searchMode == SEARCHMODE_RECEIVER )
            //{
            //    this.Receiver_UCheckEditor.Checked = true;
            //}
            //else if ( this._searchMode == SEARCHMODE_CUSTOMER_ONLY )
            //{
            //    this.Customer_UCheckEditor.Checked = true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
            if ( this._searchMode == SEARCHMODE_RECEIVER )
            {
                this.Receiver_UCheckEditor.Checked = true;
            }
            else if ( this._searchMode == SEARCHMODE_CUSTOMER_ONLY )
            {
                this.Customer_UCheckEditor.Checked = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            _nextControlDic = new Dictionary<string, Control>();
            _nextControlDic.Add( Condition_CustAnalysCode_Panel.Name, this.CustAnalysCode1_TNedit );
            _nextControlDic.Add( Condition_CustomerAgentCd_Panel.Name, this.tEdit_EmployeeNm );
            _nextControlDic.Add( Condition_CustomerCode_Panel.Name, this.tNedit_CustomerCode );
            _nextControlDic.Add( Condition_CustomerKind_Panel.Name, this.Customer_UCheckEditor );
            _nextControlDic.Add( Condition_CustomerSubCode_Panel.Name, this.tEdit_CustomerSubCode );
            _nextControlDic.Add( Condition_Kana_Panel.Name, this.tEdit_CustomerKana );
            _nextControlDic.Add( Condition_MngSectionCode_Panel.Name, this.tEdit_MngSectionNm );
            _nextControlDic.Add( Condition_SearchTelNo_Panel.Name, this.SearchTelNo_TEdit );

            // 2009/12/02 Add >>>
            _nextControlDic.Add(Condition_Name_Panel.Name, this.tEdit_CustomerName);
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06------------------>>>
            _nextControlDic.Add(Condition_TelNum_Panel.Name, this.tEdit_TelNum);
            // ---ADD 2010/08/06------------------<<<

            // 2011/08/18 XUJS ADD STA------>>>>>>
            _nextControlDic.Add(Condition_CustomerSnm_Panel.Name, this.tEdit_CustomerSnm);
            // 2011/08/18 XUJS ADD END------<<<<<<

            _nextControlList = new List<string>();
            List<ExtractConditionItem> extractconditioItemList = this._extractConditionItems.GetExtractConditionItemList();
            for ( int index = 0; index < extractconditioItemList.Count; index++ )
            {
                if ( extractconditioItemList[index].IsDisplay() )
                {
                    _nextControlList.Add( "Condition_" + extractconditioItemList[index].Key.TrimEnd() + "_Panel" );
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 検索実行
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
            //if ( _autoSearch )
            if ( _autoSearch || _forcedAutoSearch )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD
            {
                //Search_Timer_Tick( this, new EventArgs() );
                SearchProc();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/// <summary>
		/// タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MessageUnDisp_Timer_Tick(object sender, System.EventArgs e)
		{
			this.MessageUnDisp_Timer.Enabled = false;
			this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "";
		}

		/// <summary>
		/// ツールバーツールクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Close_ButtonTool":
				{
					this.Close();
					break;
				}
				case "Setup_ButtonTool":
				{
					this._customerSearchSetUp.ShowDialog();
					break;
				}
				case "Return_ButtonTool":
				{
					int maxIndex = this._extractConditionList.Count - 1;
					if (maxIndex < 1) return;

					// 最終のアイテムを削除する
					CustomerSearchExtractionConditionInfo removeInfo = this._extractConditionList[maxIndex];
					this._extractConditionList.Remove(removeInfo);

					// 現在から１つ以前のアイテムを取得し、再検索を行う。
					CustomerSearchExtractionConditionInfo targetInfo = this._extractConditionList[maxIndex - 1];

					if (targetInfo != null)
					{
						this._extractionConditionInfo = targetInfo.Clone();

						// 検索条件入力コントロール情報設定
						this.SettingExtractConditionItemInfo(this._extractionConditionInfo);

						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
					}

					break;
				}
				case "CustomerNew_ButtonTool":
				{
					// 得意先新規入力起動処理 
					this.ShowCustomerNew();

					break;
				}
				case "Clear_ButtonTool":
				{
					// クリア処理
					this.Clear();

					break;
				}
				case "CustomerRevival_ButtonTool":
				{
					if (this.SearchResult_UGrid.ActiveRow == null)
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"得意先が選択されていません。",
							0,
							MessageBoxButtons.OK);
						return;
					}

					// 選択行のインデックスを取得
					CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
					int index = cm.Position;	

					// 指定行の内容を取得
					DataRow row = this._searchDataView[index].Row;

					// 得意先検索結果クラス取得処理（グリッド行より）
					CustomerSearchRet customerSearchRet = this.DataRowToCustomerSearchRet(row);

					// データ復元確認処理
					if (!this.DataRevivalDialogCheck()) return;

					// 得意先復元処理
					CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
					int status = customerInfoAcs.RevivalDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode);

					if (status == 0)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"得意先の復元に失敗しました。",
							status,
							MessageBoxButtons.OK);
					}

					break;
				}
				case "CustomerEdit_ButtonTool":
				{
					// 得意先編集ボタンクリック処理
					this.CustomerEditButtonClick();

					break;
				}
				case "CustomerDelete_ButtonTool":
				{
					if (this.SearchResult_UGrid.ActiveRow == null)
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"得意先が選択されていません。",
							0,
							MessageBoxButtons.OK);
						return;
					}

					// 選択行のインデックスを取得
					CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
					int index = cm.Position;	

					// 指定行の内容を取得
					DataRow row = this._searchDataView[index].Row;

					// 得意先検索結果クラス取得処理（グリッド行より）
					CustomerSearchRet customerSearchRet = this.DataRowToCustomerSearchRet(row);

					// データ削除確認処理
					if (!this.DataDeleteDialogCheck()) return;

					// 得意先削除チェック処理
					CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
					string message = "";
					bool checkFlg = false;
					int status = customerInfoAcs.DeleteCheck(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, out message, out checkFlg);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						if (!checkFlg)
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"得意先を削除することが出来ません。" + "\r\n" + "\r\n" + 
								message,
								status,
								MessageBoxButtons.OK);

							return;
						}
					}
					else
					{
						return;
					}

					status = customerInfoAcs.LogicalDeleteDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true);

					if (status == 0)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
					}
					else
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_STOPDISP,
							this.Name,
							"得意先の削除に失敗しました。",
							status,
							MessageBoxButtons.OK);
					}

					break;
				}
				case "Select_ButtonTool":
				{
					// 選択ボタンクリック処理
					this.SelectButtonClick();

					break;
				}
				case "Search_ButtonTool":
				{
					// 選択ボタンクリック処理
					this.Search_UButton_Click(this.Search_UButton, EventArgs.Empty);

					break;
				}
				// デバッグ用
				#if DEBUG 
				case "LoginTitle_LabelTool":
				{
					break;
				}
				# endif
			}
		}

		/// <summary>
		/// 検索ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Search_UButton_Click(object sender, System.EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.Search_Timer.Enabled = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            //*********************************************************************:
            // TimerTickを使用しないように変更
            // 
            // TimerTickを使用すると別スレッド化するので、
            // 検索条件入力→新規ボタン押下のようなオペレーションだと、
            // 場合によっては
            // 新規フォーム表示→検索画面にフォーカスが戻る、
            // という現象が発生し、好ましくない。
            //*********************************************************************:
            
            // 検索実行
            SearchProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        ///// <summary>
        ///// 検索タイマーイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        //private void Search_Timer_Tick(object sender, System.EventArgs e)
        //{
        //    this.Search_Timer.Enabled = false;
        //    SearchProc();
        //}
        /// <summary>
        /// 検索メイン処理
        /// </summary>
        private void SearchProc()
        {
            // ADD 2009/07/10 >>>
            SearchResult_UGrid.DisplayLayout.Bands[0].SortedColumns.Clear();
            SearchResult_UGrid.DisplayLayout.Bands[0].SortedColumns.Add(SEARCH_COL_CustomerCode, false);
            // ADD 2009/07/10 <<<

			this.Cursor = Cursors.WaitCursor;

			this._selectedRowIndex = -1;

			// 得意先検索パラメータクラス生成処理

			this.SettingExtractionConditionClass(ref this._extractionConditionInfo);

			if (this._extractionConditionInfo == null) return;

			//if (!this.CheckCustomerSearchPara(this._extractionConditionInfo)) return;

			// 抽出条件履歴リスト レコード追加処理
			this.AddExtractConditionList(this._extractionConditionInfo);

			// 得意先検索処理
			this.SearchCustomerData();

			// グリッド行表示設定処理
			this.SettingGridRowAppearance();

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			//this.ColSizeChange_Timer.Enabled = true;
			// 抽出後フォーカス設定
			if (!this.MultiSelect_UCheckEditor.Checked)
			{
				if (this.SearchResult_UGrid.Rows.Count > 0)
				{
					string firstColumnKey = "";

					foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns)
					{
						if (column.Header.VisiblePosition == 0)
						{
							firstColumnKey = column.Key;
                            break;
						}
					}

					try
					{
						this.SearchResult_UGrid.Focus();
						this.SearchResult_UGrid.ActiveCell = this.SearchResult_UGrid.Rows[0].Cells[firstColumnKey];
						this.SearchResult_UGrid.ActiveCell.Selected = true;
						this.SearchResult_UGrid.ActiveRow = this.SearchResult_UGrid.Rows[0];
						this.SearchResult_UGrid.ActiveRow.Selected = true;
					}
					catch { }
				}
			}
			this.Cursor = Cursors.Default;
		}

		/// <summary>
		/// 列サイズ変更タイマーイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ColSizeChange_Timer_Tick(object sender, System.EventArgs e)
		{
			this.ColSizeChange_Timer.Enabled = false;
			this.SearchResult_UGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

			for (int i = 0; i < this.SearchResult_UGrid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				this.SearchResult_UGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
			}
			this.SearchResult_UGrid.Refresh();
		}

		/// <summary>
		/// 抽出条件設定ツリードラッグスタートイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ExtractConditionSetting_UTree_SelectionDragStart(object sender, System.EventArgs e)
		{
			// ドラッグドロップ操作開始イベント
			this.ExtractConditionSetting_UTree.DoDragDrop(this.ExtractConditionSetting_UTree.SelectedNodes, DragDropEffects.Move); 
		}

		/// <summary>
		/// 抽出条件設定ツリードラッグドロップイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ExtractConditionSetting_UTree_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			// 模擬ノード変数を宣言します
			Infragistics.Win.UltraWinTree.UltraTreeNode aNode;
			
			// ドラッグされるノードSelectedNodesを保存するための変数
			Infragistics.Win.UltraWinTree.SelectedNodesCollection selectedNodes;
			
			// ドロップ先のノードを保存する変数
			Infragistics.Win.UltraWinTree.UltraTreeNode dropNode;
			
			// ループに使用する整数
			int i;

			// DropNodeを設定します。（ドロップするノード）
			dropNode = this._ultraTree_DropHightLight_DrawFilter.DropHightLightNode;

			// データを取得し、selectedNodesコレクションに保存します
			// これらはドラッグドロップされるノードです
			selectedNodes = (Infragistics.Win.UltraWinTree.SelectedNodesCollection)e.Data.GetData(typeof(Infragistics.Win.UltraWinTree.SelectedNodesCollection));
			selectedNodes = (Infragistics.Win.UltraWinTree.SelectedNodesCollection)selectedNodes.Clone();

			// 選択されたノードを表示位置順にソートします。
			// すなわち、移動後も同じ順で表示されるようにするためです
			selectedNodes.SortByPosition();

			// ドロップしている位置をDrawFilterのDropLinePositionから確認します
			switch (this._ultraTree_DropHightLight_DrawFilter.DropLinePosition)
			{
				// ノードにドロップした場合
				case DropLinePositionEnum.OnNode: 
				{
					// 何もしない
					break;
				}
				// ノードの下にドロップした場合
				case DropLinePositionEnum.BelowNode: 
				{					
					for (i = 0; i <= (selectedNodes.Count - 1); i++)
					{
						aNode = selectedNodes[i];						
						aNode.Reposition(dropNode,Infragistics.Win.UltraWinTree.NodePosition.Next);

						// dropNodeを位置変更されたノードに設定します
						// そうすることにより、次に追加されるノードは自動的にその下に追加されます
						dropNode = aNode;
					}	
					break;
				}
				case DropLinePositionEnum.AboveNode: // 新規インデックスはDropと同じでなければいけません
				{
					for (i = 0; i <= (selectedNodes.Count - 1); i++)
					{
						aNode = selectedNodes[i];						
						aNode.Reposition(dropNode,Infragistics.Win.UltraWinTree.NodePosition.Previous);
					}

					break;
				}
			}

			// ドロップ操作が完了したら、現在のドロップハイライトを消去する
			this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();

			// 抽出条件設定クラスリスト構築処理
			List<ExtractConditionItem> extractConditionItemList = this.ExtractConditionItemListConstruction();
			this._extractConditionItems.SetExtractConditionItemList(extractConditionItemList);

			// 抽出条件設定入力項目構築処理
			this.ExtractConditionInputItemConstruction(this._extractConditionItems.GetExtractConditionItemList());
		}

		/// <summary>
		/// 抽出条件設定ツリードラッグリーヴイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ExtractConditionSetting_UTree_DragLeave(object sender, System.EventArgs e)
		{
			//マウスがコントロールの外にドラッグされた場合、DropHighLightを消去する
			this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();
		}

		/// <summary>
		/// 抽出条件設定ツリードラッグオーバーイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ExtractConditionSetting_UTree_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			// 模擬ノード変数を宣言します
			Infragistics.Win.UltraWinTree.UltraTreeNode aNode;
			
			// マウスカーソルがあるツリー座標
			// このイベントでは、フォームのXとY座標を引き渡します
			System.Drawing.Point pointInTree;

			// ツリーにおけるマウスの位置を取得します
			pointInTree = this.ExtractConditionSetting_UTree.PointToClient(new Point(e.X, e.Y));

			// マウスポインタのあるノードを取得します
			aNode = this.ExtractConditionSetting_UTree.GetNodeFromPoint(pointInTree);

			// マウスポインタがノード上にあることを確認
			if (aNode == null)
			{
				// マウスがノード上にないので、ここではドロップ操作は許可しない
				e.Effect = DragDropEffects.None;

				// DropHighlightの消去
				this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();

				// イベントを終了
				return;
			}

			// 既に選択されているノードのチャイルドノードにドロップしているかを確認する
			//（同一のノードにドロップすることを未然に防止するため
			if (IsAnyParentSelected(aNode))
			{
				// 親ノードが既に選択されているノード上にマウスがある場合
				// ドロップ操作を無効に設定
				e.Effect = DragDropEffects.None;

				// DropHighlightを消去します。
				this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();
				
				// イベントを終了。
				return;
			}
			
			// この段階まで来たので、ドロップ操作を行います
			this._ultraTree_DropHightLight_DrawFilter.SetDropHighlightNode(aNode, pointInTree);

			// ドロップ操作を有効に設定
			e.Effect = DragDropEffects.Move;
		}

		/// <summary>
		/// 抽出条件設定ツリードラッグイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ExtractConditionSetting_UTree_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
		{
			//ユーザーがESCを押下したか確認
			if (e.EscapePressed)
			{
				// ドラッグをキャンセルする
				e.Action = DragAction.Cancel;

				// ドロップハイライトを消去
				this._ultraTree_DropHightLight_DrawFilter.ClearDropHighlight();
			}
		}

		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void PMKHN04001UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 抽出条件設定クラスリスト構築処理
			List<ExtractConditionItem> extractConditionItemList = this.ExtractConditionItemListConstruction();
			this._extractConditionItems.SetExtractConditionItemList(extractConditionItemList);

			// 抽出条件設定情報をＸＭＬファイルにシリアライズ
			ExtractConditionItems.Serialize(this._extractConditionItems.GetExtractConditionItemList(), EXTRACT_CONDITION_XML_FILE_NAME);

			// 列表示状態クラスリスト構築処理
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// 列表示状態クラスリストをXMLにシリアライズする
			ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
		}

		/// <summary>
		/// 抽出条件設定ツリーチェックボックスチェック後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ExtractConditionSetting_UTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
		{
			// 抽出条件設定クラスリスト構築処理
			List<ExtractConditionItem> extractConditionItemList = this.ExtractConditionItemListConstruction();
			this._extractConditionItems.SetExtractConditionItemList(extractConditionItemList);

			// 抽出条件設定入力項目構築処理
			this.ExtractConditionInputItemConstruction(this._extractConditionItems.GetExtractConditionItemList());
		}

		/// <summary>
		/// 抽出結果グリッドキーアップイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SearchResult_UGrid_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.DetailView_Timer.Enabled = true;
		}

		/// <summary>
		/// 抽出結果グリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SearchResult_UGrid_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				if ((this.SearchResult_UGrid.ActiveCell != null) &&
					(this.SearchResult_UGrid.ActiveCell.Row.Index == 0) && (this.SearchResult_UGrid.ActiveCell.Column.Header.VisiblePosition == 0))
				{
					List<Control> controls = this.GetExtractConditionPanelList(true);

					if (controls.Count > 0)
					{
						Infragistics.Win.UltraWinEditors.UltraTextEditor textEditor = this.GetTextEditorOnPanel((Panel)controls[0]);

						if (textEditor != null)
						{
							this.Search_UButton.Focus();
							this.ActiveControl = textEditor;
							textEditor.Focus();
						}
					}
				}
			}
		}

		/// <summary>
		/// 抽出結果グリッドマウスアップイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SearchResult_UGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.DetailView_Timer.Enabled = true;
		}

		/// <summary>
		/// 抽出条件パネルリサイズイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Condition_Panel_Resize(object sender, System.EventArgs e)
		{
			// 抽出条件入力項目パネル表示位置設定処理
			this.ExtractConditionItemPositionSetting();
		}

		/// <summary>
		/// データ表示タイマーイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void DetailView_Timer_Tick(object sender, System.EventArgs e)
		{
			this.DetailView_Timer.Enabled = false;

			if ((this._detailViewForm == null) || ((!this._detailViewForm.Visible) && (!this.DetailView_Panel.Visible))) return;

			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				Control activeControl = this.ActiveControl;
				
				try
				{
					this._detailViewForm.DataView(this._initHtmlString);
				}
				catch
				{
					// 例外は対処しない
				}
				finally
				{
					if ((activeControl != null) && (this.DetailView_Panel.Visible))
					{
						activeControl.Focus();
					}
				}
			}
			else
			{
				// 選択行のインデックスを取得
				CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
				int index = cm.Position;

				if (this._selectedRowIndex == index) return;

				this._selectedRowIndex = index;

				// 指定行の内容を取得
				DataRow row = this._searchDataView[index].Row;

				// 詳細表示用HTML文字列取得処理（グリッド行より）
				string htmlString = this.DataRowToHtmlString(row);

				if (htmlString == "")
				{
					// 詳細表示用文字列データ行設定処理
					this.SetHtmlStringToDataRow(row);

					// 詳細表示用HTML文字列取得処理（グリッド行より）
					htmlString = this.DataRowToHtmlString(row);
				}

				Control activeControl = this.ActiveControl;

				if (htmlString != "")
				{
					try
					{
						this._detailViewForm.DataView(htmlString);
					}
					catch
					{
						// 例外は対処しない
					}
					finally
					{
						if ((activeControl != null) && (this.DetailView_Panel.Visible))
						{
							if (activeControl == this.SearchResult_UGrid)
							{
								if (this.SearchResult_UGrid.Rows.Count > 0)
								{
									activeControl.Focus();
								}
							}
							else
							{
								activeControl.Focus();
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// 抽出結果グリッド行選択後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SearchResult_UGrid_AfterRowActivate(object sender, System.EventArgs e)
		{
			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();
		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (this._extractionConditionInfo == null) return;
			if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if ( _extractionConditionInfo == null ) return;

            try
            {
                // 現時点での抽出条件入力情報クラスの情報を退避する
                CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

                switch ( e.PrevCtrl.Name )
                {
                    // 得意先コード ============================================ //
                    case "tNedit_CustomerCode":
                        {
                            if ( this._extractionConditionInfo.CustomerCode != this.tNedit_CustomerCode.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                }

                                extractionConditionInfoBuff.CustomerCode = this.tNedit_CustomerCode.GetInt();

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // フォーカス制御
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // 得意先サブコード ======================================== //
                    case "tEdit_CustomerSubCode":
                        {
                            if ( this._extractionConditionInfo.CustomerSubCode != this.tEdit_CustomerSubCode.DataText )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                }

                                extractionConditionInfoBuff.CustomerSubCode = this.tEdit_CustomerSubCode.DataText;

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // フォーカス制御
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // カナ ==================================================== //
                    case "tEdit_CustomerKana":
                        {
                            if ( this._extractionConditionInfo.Kana != this.tEdit_CustomerKana.DataText )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                }

                                extractionConditionInfoBuff.Kana = this.tEdit_CustomerKana.DataText;

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // フォーカス制御
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // 電話番号（検索用下4桁） ================================= //
                    case "SearchTelNo_TEdit":
                        {
                            if ( this._extractionConditionInfo.SearchTelNo != this.SearchTelNo_TEdit.Text )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                }

                                extractionConditionInfoBuff.SearchTelNo = this.SearchTelNo_TEdit.Text;

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // フォーカス制御
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // 分析コード1 ============================================= //
                    case "CustAnalysCode1_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode1 != this.CustAnalysCode1_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // 分析コード2 ============================================= //
                    case "CustAnalysCode2_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode2 != this.CustAnalysCode2_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // 分析コード3 ============================================= //
                    case "CustAnalysCode3_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode3 != this.CustAnalysCode3_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // 分析コード4 ============================================= //
                    case "CustAnalysCode4_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode4 != this.CustAnalysCode4_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // 分析コード5 ============================================= //
                    case "CustAnalysCode5_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode5 != this.CustAnalysCode5_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // 分析コード6 ============================================= //
                    case "CustAnalysCode6_TNedit":
                        {
                            if ( this._extractionConditionInfo.CustAnalysCode6 != this.CustAnalysCode6_TNedit.GetInt() )
                            {
                                if ( !this.MultiSelect_UCheckEditor.Checked )
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );

                                    extractionConditionInfoBuff.CustAnalysCode1 = this.CustAnalysCode1_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode2 = this.CustAnalysCode2_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode3 = this.CustAnalysCode3_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode4 = this.CustAnalysCode4_TNedit.GetInt();
                                    extractionConditionInfoBuff.CustAnalysCode5 = this.CustAnalysCode5_TNedit.GetInt();
                                }

                                extractionConditionInfoBuff.CustAnalysCode6 = this.CustAnalysCode6_TNedit.GetInt();

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            // フォーカス制御
                            GetNextPanelControl( e );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            break;
                        }
                    // 得意先担当 ============================================== //
                    case "tEdit_EmployeeNm":
                        {
                            if ( this.tEdit_EmployeeNm.Text.TrimEnd() != string.Empty )
                            {
                                if ( this._extractionConditionInfo.CustomerAgentNm.CompareTo( this.tEdit_EmployeeNm.Text ) != 0 )
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    if ( !this.MultiSelect_UCheckEditor.Checked )
                                    {
                                        extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                                    string employeeName;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                                    //int status = this.GetEmployeeFromEmployeeCode( this.tEdit_EmployeeNm.Text.Trim(), out employeeName );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                                    string employeeCode = GetInputCode( tEdit_EmployeeNm );
                                    int status = this.GetEmployeeFromEmployeeCode( employeeCode, out employeeName );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                                        //extractionConditionInfoBuff.CustomerAgentCd = this.tEdit_EmployeeNm.Text;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                                        extractionConditionInfoBuff.CustomerAgentCd = employeeCode;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD
                                        extractionConditionInfoBuff.CustomerAgentNm = employeeName;

                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                        // フォーカス制御
                                        GetNextPanelControl( e );
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                    }
                                    else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                    {
                                        extractionConditionInfoBuff.CustomerAgentCd = string.Empty;
                                        extractionConditionInfoBuff.CustomerAgentNm = string.Empty;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_STOPDISP,
                                            this.Name,
                                            "従業員情報の取得に失敗しました。",
                                            status,
                                            MessageBoxButtons.OK );
                                    }

                                    // 検索条件入力コントロール情報設定
                                    this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                                }
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    // フォーカス制御
                                    GetNextPanelControl( e );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                }
                            }
                            else
                            {
                                // 入力クリア
                                extractionConditionInfoBuff.CustomerAgentCd = string.Empty;
                                extractionConditionInfoBuff.CustomerAgentNm = string.Empty;
                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // 管理拠点 ============================================== //
                    case "tEdit_MngSectionNm":
                        {

                            if ( this.tEdit_MngSectionNm.Text.Trim() != string.Empty )
                            {
                                if ( this._extractionConditionInfo.MngSectionName.CompareTo( this.tEdit_MngSectionNm.Text ) != 0 )
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    if ( !this.MultiSelect_UCheckEditor.Checked )
                                    {
                                        extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create( extractionConditionInfoBuff );
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                                    SecInfoSet secInfoSet;

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                                    //int status = this._secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, this.tEdit_MngSectionNm.Text.Trim() );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                                    int status = this._secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, GetInputCode( tEdit_MngSectionNm ) );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        extractionConditionInfoBuff.MngSectionCode = this.tEdit_MngSectionNm.Text;
                                        extractionConditionInfoBuff.MngSectionName = secInfoSet.SectionGuideNm;

                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                        // フォーカス制御
                                        GetNextPanelControl( e );
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                    }
                                    else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                    {
                                        extractionConditionInfoBuff.MngSectionCode = string.Empty;
                                        extractionConditionInfoBuff.MngSectionName = string.Empty;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_STOPDISP,
                                            this.Name,
                                            "拠点情報の取得に失敗しました。",
                                            status,
                                            MessageBoxButtons.OK );
                                    }

                                    // 検索条件入力コントロール情報設定
                                    this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                                }
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    // フォーカス制御
                                    GetNextPanelControl( e );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                }
                            }
                            else
                            {
                                // 入力クリア
                                extractionConditionInfoBuff.MngSectionCode = string.Empty;
                                extractionConditionInfoBuff.MngSectionName = string.Empty;
                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );
                            }

                            break;
                        }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


                    // 2009/12/02 Add >>>
                    // 得意先名 ==================================================== //
                    case "tEdit_CustomerName":
                        {
                            if (this._extractionConditionInfo.Name != this.tEdit_CustomerName.DataText)
                            {
                                if (!this.MultiSelect_UCheckEditor.Checked)
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
                                }

                                extractionConditionInfoBuff.Name = this.tEdit_CustomerName.DataText;

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);
                            }
                            // フォーカス制御
                            GetNextPanelControl(e);

                            break;
                        }
                    // 2009/12/02 Add <<<
                    /*
                    case "SupplierDiv_UCheckEditor":
                    case "AcceptWholeSale_UCheckEditor":
                    case "Customer_UCheckEditor":
                    {
                        return;
                        //break;
                    }
                    */
                    // 検索結果グリッド ======================================== //
                    case "SearchResult_UGrid":
                        {
                            if ( e.Key == Keys.Return )
                            {
                                Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
                                Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];

                                if ( selectButton.SharedProps.Visible )
                                {
                                    // 選択ボタンクリック処理
                                    this.SelectButtonClick();
                                }
                                else
                                {
                                    if ( customerEditButton.SharedProps.Enabled )
                                    {
                                        e.NextCtrl = null;

                                        // 得意先編集ボタンクリック処理
                                        this.CustomerEditButtonClick();
                                    }
                                }
                            }

                            break;
                        }
                    // ---ADD 2010/08/06-------------------->>>
                    // 電話番号 ======================================== //
                    case "tEdit_TelNum":
                        {
                            if (this._extractionConditionInfo.TelNum != this.tEdit_TelNum.Text)
                            {
                                if (!this.MultiSelect_UCheckEditor.Checked)
                                {
                                    extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
                                }

                                extractionConditionInfoBuff.TelNum = this.tEdit_TelNum.Text;

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);
                            }
                            // フォーカス制御
                            GetNextPanelControl(e);

                            break;
                        }
                    // ---ADD 2010/08/06--------------------<<<
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // フォーカス次項目補正
                # region [フォーカス次項目補正]
                if ( e.PrevCtrl == Search_UButton && e.Key == Keys.Up && !e.ShiftKey )
                {
                    e.NextCtrl = _nextControlDic[_nextControlList[_nextControlList.Count - 1]];
                }
                else if ( e.PrevCtrl != null && e.PrevCtrl.Parent != null && !e.ShiftKey )
                {
                    bool nextCtrlSetted = false;

                    # region [フォーカス調整]
                    switch ( e.PrevCtrl.Name )
                    {
                        case "tNedit_CustomerCode":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Right:
                                        e.NextCtrl = e.PrevCtrl;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "Receiver_UCheckEditor":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Right:
                                        e.NextCtrl = e.PrevCtrl;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "CustomerSubCodeSearchType_UCheckEditor":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_CustomerSubCode;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "tEdit_CustomerSubCode":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Right:
                                        e.NextCtrl = CustomerSubCodeSearchType_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "KanaSearchType_UCheckEditor":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_CustomerKana;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "tEdit_CustomerKana":
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Right:
                                        e.NextCtrl = KanaSearchType_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;

                        // 2009/12/02 Add >>>
                        case "NameSearchType_UCheckEditor":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_CustomerName;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "tEdit_CustomerName":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Right:
                                        e.NextCtrl = NameSearchType_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        // 2009/12/02 Add <<<

                        // 2011/7/22 XUJS ADD STA>>>>>>
                        case "SnmSearchType_UCheckEditor":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_CustomerSnm;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        case "tEdit_CustomerSnm":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Right:
                                        e.NextCtrl = SnmSearchType_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        // 2011/7/22 XUJS ADD END<<<<<<

                        // ---ADD 2010/08/06-------------------->>>
                        // 電話番号
                        case "tEdit_TelNum":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Right:
                                        e.NextCtrl = TelNum_UCheckEditor;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        // 電話番号曖昧検索
                        case "TelNum_UCheckEditor":
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                    case Keys.Down:
                                        e.NextCtrl = tEdit_TelNum;
                                        nextCtrlSetted = true;
                                        break;
                                }
                            }
                            break;
                        // ---ADD 2010/08/06--------------------<<<

                        default:
                            break;
                    }
                    # endregion

                    if ( !nextCtrlSetted )
                    {
                        if ( e.NextCtrl == Receiver_UCheckEditor && (e.Key == Keys.Up || e.Key == Keys.Down) )
                        {
                            e.NextCtrl = Customer_UCheckEditor;
                        }
                        else
                        {
                            # region [条件となるパネル単位の移動を制御]
                            int panelIndex = _nextControlList.IndexOf( e.PrevCtrl.Parent.Name );
                            if ( panelIndex >= 0 )
                            {
                                if ( e.Key == Keys.Up )
                                {
                                    if ( panelIndex - 1 >= 0 )
                                    {
                                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex - 1]];
                                    }
                                    else if ( panelIndex == 0 )
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                                else if ( e.Key == Keys.Down )
                                {
                                    if ( panelIndex + 1 <= _nextControlList.Count - 1 )
                                    {
                                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex + 1]];
                                    }
                                    else
                                    {
                                        e.NextCtrl = Search_UButton;
                                    }
                                }
                            }
                            # endregion
                        }
                    }
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if ( this.Main_ExplorerBar.SelectedGroup.Key == "ExtractCondition" )
                {
                    // 得意先検索パラメータクラス生成処理
                    this.SettingExtractionConditionClass( ref extractionConditionInfoBuff );

                    bool isSetting = this.IsExtractionConditionClassSetting( extractionConditionInfoBuff );

                    if ( isSetting )
                    {
                        // メモリ上の内容と比較する
                        ArrayList arRetList = extractionConditionInfoBuff.Compare( this._extractionConditionInfo );

                        if ( arRetList.Count > 0 )
                        {
                            // 検索条件入力コントロール情報設定
                            this.SettingExtractConditionItemInfo( extractionConditionInfoBuff );

                            this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                            if ( this.AutoSearch_UCheckEditor.Checked )
                            {
                                this.Search_UButton_Click( this.Search_UButton, new EventArgs() );
                                e.NextCtrl = SearchResult_UGrid;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
		}
        /// <summary>
        /// 次パネルフォーカス移動制御
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private void GetNextPanelControl( ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == null ) return;
            if ( e.PrevCtrl.Parent == null ) return;
            if ( _nextControlList == null ) return;
            if ( _nextControlDic == null ) return;

            int panelIndex = _nextControlList.IndexOf( e.PrevCtrl.Parent.Name );
            if ( panelIndex >= 0 )
            {
                if ( e.Key == Keys.Up )
                {
                    if ( panelIndex - 1 >= 0 )
                    {
                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex - 1]];
                    }
                    else if ( panelIndex == 0 )
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                else if ( e.Key == Keys.Down || e.Key == Keys.Tab || e.Key == Keys.Return )
                {
                    if ( panelIndex + 1 <= _nextControlList.Count - 1 )
                    {
                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex + 1]];
                    }
                    else
                    {
                        e.NextCtrl = Search_UButton;
                    }
                }
            }
        }
        /// <summary>
        /// 次パネルフォーカス移動制御（ガイド用）
        /// </summary>
        /// <param name="prevCtrl"></param>
        private Control GetNextPanelControl( Control prevCtrl )
        {
            if ( prevCtrl == null ) return prevCtrl;
            if ( prevCtrl.Parent == null ) return prevCtrl;


            int panelIndex = _nextControlList.IndexOf( prevCtrl.Parent.Name );
            if ( panelIndex >= 0 )
            {
                if ( panelIndex + 1 <= _nextControlList.Count - 1 )
                {
                    return _nextControlDic[_nextControlList[panelIndex + 1]];
                }
                else
                {
                    return Search_UButton;
                }
            }
            else
            {
                return prevCtrl;
            }
        }


		/// <summary>
		/// 抽出条件パネルペイントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Condition_Panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// 抽出条件入力項目パネル表示位置設定処理
			this.ExtractConditionItemPositionSetting();
		}

		/// <summary>
		/// 抽出条件設定ツリーチェックボックスチェック前発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ExtractConditionSetting_UTree_BeforeCheck(object sender, Infragistics.Win.UltraWinTree.BeforeCheckEventArgs e)
		{
			// イベント発動不可の時は、処理しない
			if (this._noBeforeCheckEvent == true) 
			{
				this._noBeforeCheckEvent = false;
				return;
			}
		}

		/// <summary>
		/// グリッドフォントサイズコンボエディタ値変更イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void GridFontSize_TComboEditor_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.GridFontSize_TComboEditor.Value is int)
			{
				int fontSize = (int)this.GridFontSize_TComboEditor.Value;

				if (fontSize != 0)
				{
					this.SearchResult_UGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
				}
			}
		}

		/// <summary>
		/// 得意先種別チェックボックスチェック変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void CustomerKind_AfterCheckStateChanged(object sender, EventArgs e)
		{
			if (!(sender is Infragistics.Win.UltraWinEditors.UltraCheckEditor))
			{
				return;
			}

			CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

			if (!this.MultiSelect_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
			}

			Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender;

			// 得意先種別
			this.SetCustomerDivStatus(ref extractionConditionInfoBuff);

			/*
			if (uCheckEditor == this.SupplierDiv_UCheckEditor)
			{
				extractionConditionInfoBuff.SupplierDiv = this.GetCheckEditorValue(this.SupplierDiv_UCheckEditor, EXIST_CODE_CHECKED, EXIST_CODE_UNCHECKED);
			}
			else if (uCheckEditor == this.AcceptWholeSale_UCheckEditor)
			{
				extractionConditionInfoBuff.AcceptWholeSale = this.GetCheckEditorValue(this.AcceptWholeSale_UCheckEditor, EXIST_CODE_CHECKED, EXIST_CODE_UNCHECKED);
			}
			*/

			bool isSetting = this.IsExtractionConditionClassSetting(extractionConditionInfoBuff);

			if (isSetting)
			{
				// メモリ上の内容と比較する
				ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

				if (arRetList.Count > 0)
				{
					// 検索条件入力コントロール情報設定
					this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

					this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

					if (this.AutoSearch_UCheckEditor.Checked)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
					}
				}
			}
		}

		/// <summary>
		/// 検索結果グリッドマウスエンターエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		private void SearchResult_UGrid_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			// 得意先情報をポップアップ表示
			Infragistics.Win.UIElement element = e.Element;
			object oContextRow = null;
			object oContextCell = null;

			oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = Color.Blue;
				cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
			}

			if (oContextRow != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                UiSet uiset;
                uiSetControl1.ReadUISet( out uiset, this.tNedit_CustomerCode.Name );
                string customerFormat = new string( '0', uiset.Column );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;
				string tipString = "";

				if (row.Cells[0] != null)
				{
					int totalWidth = 6;

					// 得意先名称
					tipString += this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Name].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Name].Value.ToString();

                    // 2011/7/22 XUJS ADD STA>>>>>>
                    //得意先略称
                    tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Snm].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Snm].Value.ToString();
                    // 2011/7/22 XUJS ADD END<<<<<<

					// カナ
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Kana].Value.ToString();

					// 得意先コード
                    tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].Header.Caption.PadRight( totalWidth, '　' ) + "：" + ((Int32)row.Cells[SEARCH_COL_CustomerCode].Value).ToString( customerFormat );

					// 得意先サブコード
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerSubCode].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_CustomerSubCode].Value.ToString();

					// 自宅TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_HomeTelNo].Header.Caption).PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_HomeTelNo].Value.ToString();

					// 勤務先TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_OfficeTelNo].Header.Caption).PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_OfficeTelNo].Value.ToString();

					// 携帯TEL
					tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_PortableTelNo].Header.Caption).PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_PortableTelNo].Value.ToString();

                    // 2009/12/02 Add >>>
                    // 自宅FAX
                    tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_HomeFaxNo].Header.Caption).PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_HomeFaxNo].Value.ToString();

                    // 勤務先FAX
                    tipString += "\r\n" + TStrConv.HankakuToZenkaku(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_OfficeFaxNo].Header.Caption).PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_OfficeFaxNo].Value.ToString();
                    // 2009/12/02 Add <<<

					// 住所
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Address].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Address].Value.ToString();
				}

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "得意先情報";
				ultraToolTipInfo.ToolTipText = tipString;

				this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
				this.uToolTipManager_Information.SetUltraToolTip(this.SearchResult_UGrid, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;

				return;
			}
		}

		/// <summary>
		/// 検索結果グリッドマウスリーブエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SearchResult_UGrid_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			this.uToolTipManager_Information.Enabled = false;

			Infragistics.Win.UIElement element = e.Element;
			object oContextCell = null;

			oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

			if (oContextCell != null)
			{
				Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
				cell.Appearance.ForeColor = this.SearchResult_UGrid.DisplayLayout.Override.CellAppearance.ForeColor;
				cell.Appearance.FontData.Underline = this.SearchResult_UGrid.DisplayLayout.Override.CellAppearance.FontData.Underline;
			}
		}

		/// <summary>
		/// グリッドセルアクティブ後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SearchResult_UGrid_AfterCellActivate(object sender, EventArgs e)
		{
			if (this.SearchResult_UGrid.ActiveCell != null)
			{
				this.SearchResult_UGrid.ActiveRow = this.SearchResult_UGrid.ActiveCell.Row;
				this.SearchResult_UGrid.ActiveRow.Selected = true;
			}
		}

		/// <summary>
		/// 得意先サブコード曖昧検索チェックエディタチェック確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
		{
			CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

			if (!this.MultiSelect_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
			}

			extractionConditionInfoBuff.CustomerSubCode = this.tEdit_CustomerSubCode.Text;

			if (this.CustomerSubCodeSearchType_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff.CustomerSubCodeSearchType = 1;
			}
			else
			{
				extractionConditionInfoBuff.CustomerSubCodeSearchType = 0;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //bool isSetting = this.IsExtractionConditionClassSetting(extractionConditionInfoBuff);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 得意先サブコードが入力済みならば、曖昧チェックボックス変更が検索結果に影響するので、検索を行う
            bool isSetting = (this.tEdit_CustomerSubCode.Text.TrimEnd() != string.Empty);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			if (isSetting)
			{
				// メモリ上の内容と比較する
				ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

				if (arRetList.Count > 0)
				{
					// 検索条件入力コントロール情報設定
					this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

					this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

					if (this.AutoSearch_UCheckEditor.Checked)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
					}
				}
			}
			else
			{
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
			}
		}

		/// <summary>
		/// 得意先カナ曖昧検索チェックエディタチェック確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void KanaSearchType_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
		{
			CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

			if (!this.MultiSelect_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
			}

			extractionConditionInfoBuff.Kana = this.tEdit_CustomerKana.Text;

			if (this.KanaSearchType_UCheckEditor.Checked)
			{
				extractionConditionInfoBuff.KanaSearchType = 1;
			}
			else
			{
				extractionConditionInfoBuff.KanaSearchType = 0;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //bool isSetting = this.IsExtractionConditionClassSetting(extractionConditionInfoBuff);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 得意先ｶﾅが入力済みならば、曖昧チェックボックス変更が検索結果に影響するので、検索する。
            bool isSetting = (this.tEdit_CustomerKana.Text.TrimEnd() != string.Empty);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			if (isSetting)
			{
				// メモリ上の内容と比較する
				ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

				if (arRetList.Count > 0)
				{
					// 検索条件入力コントロール情報設定
					this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

					this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

					if (this.AutoSearch_UCheckEditor.Checked)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
					}
				}
			}
			else
			{
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
			}
		}


        // 2009/12/02 Add >>>
        /// <summary>
        /// 得意先名曖昧検索チェックエディタチェック確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void NameSearchType_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
        {
            CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

            if (!this.MultiSelect_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
            }

            extractionConditionInfoBuff.Name = this.tEdit_CustomerName.Text;

            if (this.NameSearchType_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff.NameSearchType = 1;
            }
            else
            {
                extractionConditionInfoBuff.NameSearchType = 0;
            }

            // 得意先ｶﾅが入力済みならば、曖昧チェックボックス変更が検索結果に影響するので、検索する。
            bool isSetting = (this.tEdit_CustomerName.Text.TrimEnd() != string.Empty);

            if (isSetting)
            {
                // メモリ上の内容と比較する
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    // 検索条件入力コントロール情報設定
                    this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    if (this.AutoSearch_UCheckEditor.Checked)
                    {
                        this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
                    }
                }
            }
            else
            {
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
            }

        }
        // 2009/12/02 Add <<<


        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        // 2011/7/22 XUJS ADD STA>>>>>>
        /// <summary>
        /// 得意先略称曖昧検索チェックエディタチェック確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void SnmSearchType_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
        {
            CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

            if (!this.MultiSelect_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
            }

            extractionConditionInfoBuff.CustomerSnm = this.tEdit_CustomerSnm.Text;

            if (this.SnmSearchType_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff.CustomerSnmSearchType = 1;
            }
            else
            {
                extractionConditionInfoBuff.CustomerSnmSearchType = 0;
            }

            // 得意先ｶﾅが入力済みならば、曖昧チェックボックス変更が検索結果に影響するので、検索する。
            bool isSetting = (this.tEdit_CustomerSnm.Text.TrimEnd() != string.Empty);

            if (isSetting)
            {
                // メモリ上の内容と比較する
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    // 検索条件入力コントロール情報設定
                    this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    if (this.AutoSearch_UCheckEditor.Checked)
                    {
                        this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
                    }
                }
            }
            else
            {
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
            }
        }
        // 2011/7/22 XUJS ADD END<<<<<<

        // ---ADD 2010/08/06-------------------->>>
        /// <summary>
        /// 電話番号曖昧検索チェックエディタチェック確定後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void TelNum_UCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
        {
            CustomerSearchExtractionConditionInfo extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

            if (!this.MultiSelect_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff = CustomerSearchExtractionConditionInfo.Create(extractionConditionInfoBuff);
            }

            extractionConditionInfoBuff.TelNum = this.tEdit_TelNum.Text;

            if (this.TelNum_UCheckEditor.Checked)
            {
                extractionConditionInfoBuff.TelNumSearchType = 1;
            }
            else
            {
                extractionConditionInfoBuff.TelNumSearchType = 0;
            }

            // 電話番号が入力済みならば、曖昧チェックボックス変更が検索結果に影響するので、検索する。
            bool isSetting = (this.tEdit_TelNum.Text.TrimEnd() != string.Empty);

            if (isSetting)
            {
                // メモリ上の内容と比較する
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    // 検索条件入力コントロール情報設定
                    this.SettingExtractConditionItemInfo(extractionConditionInfoBuff);

                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    if (this.AutoSearch_UCheckEditor.Checked)
                    {
                        this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
                    }
                }
            }
            else
            {
                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
            }
        }
        // ---ADD 2010/08/06--------------------<<<

		/// <summary>
		/// フォーム終了中発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void PMKHN04001UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			List<PMKHN09000UA> customerFormList = new List<PMKHN09000UA>();
			foreach (PMKHN09000UA customerInputForm in this._customerFormList)
			{
				customerFormList.Add(customerInputForm);
			}

			foreach (PMKHN09000UA customerInputForm in customerFormList)
			{
				if ((customerInputForm == null) || (customerInputForm.IsDisposed)) continue;

				if ((this._executeMode == EXECUTEMODE_GUIDE_ONLY) ||
					(this._executeMode == EXECUTEMODE_GUIDE_AND_EDIT))
				{
					customerInputForm.Close();
				}
				else 
				{
					customerInputForm.Show();
					customerInputForm.BringToFront();

					int status = customerInputForm.DispClose();

					if (status == 1)
					{
						e.Cancel = true;
						return;
					}
				}
			}
		}

		/// <summary>
		/// 従業員ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void CustomerAgentCdGuide_UButton_Click(object sender, EventArgs e)
		{
			string employeeCode;
			string employeeName;

			// 従業員ガイド表示処理
			int status = this.ShowEmployeeGuide(out employeeCode, out employeeName);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                if ( !this.MultiSelect_UCheckEditor.Checked )
                {
                    _extractionConditionInfo = CustomerSearchExtractionConditionInfo.Create( _extractionConditionInfo );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				this._extractionConditionInfo.CustomerAgentCd = employeeCode;
				this._extractionConditionInfo.CustomerAgentNm = employeeName;

				// 検索条件入力コントロール情報設定
				this.SettingExtractConditionItemInfo(this._extractionConditionInfo);

				// 得意先検索パラメータクラス生成処理
				this.SettingExtractionConditionClass(ref this._extractionConditionInfo);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // フォーカス移動
                GetNextPanelControl( tEdit_EmployeeNm ).Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				bool isSetting = this.IsExtractionConditionClassSetting(this._extractionConditionInfo);

				if (isSetting)
				{
					if (this.AutoSearch_UCheckEditor.Checked)
					{
						this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        SearchResult_UGrid.Focus();
					}
				}
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

        /// <summary>
        /// 管理拠点コードガイドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MngSectionCodeGuide_UButton_Click( object sender, EventArgs e )
        {
            SecInfoSet secInfoSet;
            int status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out secInfoSet );

            if ( status == 0 )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                if ( !this.MultiSelect_UCheckEditor.Checked )
                {
                    _extractionConditionInfo = CustomerSearchExtractionConditionInfo.Create( _extractionConditionInfo );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                this._extractionConditionInfo.MngSectionCode = secInfoSet.SectionCode;
                this._extractionConditionInfo.MngSectionName = secInfoSet.SectionGuideNm;

                // 検索条件入力コントロール情報設定
                this.SettingExtractConditionItemInfo( this._extractionConditionInfo );

                // 得意先検索パラメータクラス生成処理
                this.SettingExtractionConditionClass( ref this._extractionConditionInfo );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // フォーカス移動
                GetNextPanelControl( tEdit_MngSectionNm ).Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                bool isSetting = this.IsExtractionConditionClassSetting( this._extractionConditionInfo );

                if ( isSetting )
                {
                    if ( this.AutoSearch_UCheckEditor.Checked )
                    {
                        this.Search_UButton_Click( this.Search_UButton, new EventArgs() );
                        SearchResult_UGrid.Focus();
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>
		/// グリッドダブルクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SearchResult_UGrid_DoubleClick(object sender, EventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
			objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

			objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// ヘッダ部の場合は以下の処理をキャンセルする
			if (objRowCellAreaUIElement == null)
			{
				return;
			}

			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
			Infragistics.Win.UltraWinToolbars.ButtonTool customerEditButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["CustomerEdit_ButtonTool"];

			if (selectButton.SharedProps.Visible)
			{
				// 選択ボタンクリック処理
				this.SelectButtonClick();
			}
			else
			{
				if (customerEditButton.SharedProps.Enabled)
				{
					// 得意先編集ボタンクリック処理
					this.CustomerEditButtonClick();
				}
			}

		}

		/// <summary>
		/// フォーム起動後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void PMKHN04001UA_Shown(object sender, EventArgs e)
		{
			if ((this._executeMode == EXECUTEMODE_GUIDE_AND_EDIT) || (this._executeMode == EXECUTEMODE_GUIDE_ONLY))
			{
				// 最上位親フォーム取得処理
				Form ownerForm = this.GetTopLevelOwnerForm();

				if (ownerForm != null)
				{
					if ((ownerForm.Height < this.Height) && (ownerForm.Width < this.Width)) return;

					int afterHeight = Convert.ToInt32(ownerForm.Height * 0.95);
					int afterWidth = Convert.ToInt32(ownerForm.Width * 0.95);

					int afterTop = Convert.ToInt32(ownerForm.Top + ((ownerForm.Height - afterHeight) * 0.5));
					int afterLeft = Convert.ToInt32(ownerForm.Left + ((ownerForm.Width - afterWidth) * 0.5));

					this.Size = new Size(afterWidth, afterHeight);
					this.Location = new Point(afterLeft, afterTop);
				}
			}
		}

		/// <summary>
		/// 抽出条件設定ツリーマウスクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ExtractConditionSetting_UTree_MouseClick(object sender, MouseEventArgs e)
		{
			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = this.ExtractConditionSetting_UTree.PointToClient(point);

			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement objNodeCheckBoxElement = null;
			objElement = this.ExtractConditionSetting_UTree.UIElement.ElementFromPoint(point);

			objNodeCheckBoxElement = (Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement)));

			// チェックボックスの場合は以下の処理をキャンセルする
			if (objNodeCheckBoxElement != null)
			{
				return;
			}

			Infragistics.Win.UltraWinTree.UltraTreeNode clickedNode =
											this.ExtractConditionSetting_UTree.GetNodeFromPoint(point);

			if (clickedNode == null) return;

			if (clickedNode.CheckedState == CheckState.Checked)
			{
				clickedNode.CheckedState = CheckState.Unchecked;
			}
			else
			{
				clickedNode.CheckedState = CheckState.Checked;
			}
		}

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>
        /// CheckEditor.CheckedChanged イベント(DeleteIndication_CheckEditor)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 削除済みデータを表示するチェックエディタコントロールのChecked
        ///					　プロパティが変更されるときに発生します。
        ///					　削除済みデータのフィルタを解除し、削除済みデータを表示します。</br>
        /// <br>Programmer  : 30452 上野 俊治</br>
        /// <br>Date        : 2008.09.04</br>
        /// </remarks>
        private void DeleteIndication_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // 0行の場合は処理なし
            if (this.Search_DataSet.Tables[SEARCH_TABLE].DefaultView.Count == 0)
            {
                return;
            }

            // 列の表示設定
            if (this.DeleteIndication_CheckEditor.Checked)
            {
                this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_LogicalDeleteDate].Hidden = false;
            }
            else
            {
                this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_LogicalDeleteDate].Hidden = true;
            }

            // 論理削除フィルタ設定
            this.AddGridFiltering();
        }
        // --- ADD 2008/09/04 --------------------------------<<<<< 

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// アクティブグループ変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_ExplorerBar_ActiveGroupChanged( object sender, Infragistics.Win.UltraWinExplorerBar.GroupEventArgs e )
        {
            // フォーカス移動用のコントロール一覧を更新する
            _nextControlList = new List<string>();
            List<ExtractConditionItem> extractconditioItemList = this._extractConditionItems.GetExtractConditionItemList();
            for ( int index = 0; index < extractconditioItemList.Count; index++ )
            {
                if ( extractconditioItemList[index].IsDisplay() )
                {
                    _nextControlList.Add( "Condition_" + extractconditioItemList[index].Key.TrimEnd() + "_Panel" );
                }
            }
        }

        /// <summary>
        /// チェック変更イベント処理（値が変わる前に発生）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customer_UCheckEditor_BeforeCheckStateChanged( object sender, CancelEventArgs e )
        {
            if ( sender == this.Customer_UCheckEditor )
            {
                if ( !Customer_UCheckEditor.Checked )
                {
                    // 得意先にチェックを付けて、納入先のチェックを外す
                    Customer_UCheckEditor.BeforeCheckStateChanged -= Customer_UCheckEditor_BeforeCheckStateChanged;
                    Customer_UCheckEditor.Checked = true;
                    Customer_UCheckEditor.BeforeCheckStateChanged += Customer_UCheckEditor_BeforeCheckStateChanged;

                    Receiver_UCheckEditor.BeforeCheckStateChanged -= Customer_UCheckEditor_BeforeCheckStateChanged;
                    Receiver_UCheckEditor.Checked = false;
                    Receiver_UCheckEditor.BeforeCheckStateChanged += Customer_UCheckEditor_BeforeCheckStateChanged;
                }
            }
            else if ( sender == this.Receiver_UCheckEditor )
            {
                if ( !Receiver_UCheckEditor.Checked )
                {
                    // 納入先にチェックを付けて、得意先のチェックを外す
                    Receiver_UCheckEditor.BeforeCheckStateChanged -= Customer_UCheckEditor_BeforeCheckStateChanged;
                    Receiver_UCheckEditor.Checked = true;
                    Receiver_UCheckEditor.BeforeCheckStateChanged += Customer_UCheckEditor_BeforeCheckStateChanged;
                    
                    Customer_UCheckEditor.BeforeCheckStateChanged -= Customer_UCheckEditor_BeforeCheckStateChanged;
                    Customer_UCheckEditor.Checked = false;
                    Customer_UCheckEditor.BeforeCheckStateChanged += Customer_UCheckEditor_BeforeCheckStateChanged;
                }
            }
        }

        /// <summary>
        /// グリッドからのフォーカス脱出イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResult_UGrid_Leave( object sender, EventArgs e )
        {
            if ( SearchResult_UGrid.ActiveRow != null )
            {
                SearchResult_UGrid.ActiveRow.Selected = false;
                SearchResult_UGrid.ActiveRow = null;
            }
        }
        /// <summary>
        /// グリッドへのフォーカス進入イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResult_UGrid_Enter( object sender, EventArgs e )
        {
            string firstColumnKey = "";

            foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns )
            {
                if ( column.Header.VisiblePosition == 0 )
                {
                    firstColumnKey = column.Key;
                    break;
                }
            }

            foreach ( Infragistics.Win.UltraWinGrid.UltraGridRow row in SearchResult_UGrid.Rows )
            {
                if ( (int)row.Cells[SEARCH_COL_LogicalDeleteCode].Value != 0 ) continue;
                
                this.SearchResult_UGrid.Focus();
                this.SearchResult_UGrid.ActiveCell = row.Cells[firstColumnKey];
                this.SearchResult_UGrid.ActiveCell.Selected = true;
                this.SearchResult_UGrid.ActiveRow = row;
                this.SearchResult_UGrid.ActiveRow.Selected = true;

                break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
        /// <summary>
        /// 文字列項目のコード変換処理(ｾﾞﾛ詰め対応)
        /// </summary>
        /// <param name="targetEdit"></param>
        /// <returns></returns>
        private string GetInputCode( TEdit targetEdit )
        {
            UiSet uiset;
            if ( uiSetControl1.ReadUISet( out uiset, targetEdit.Name ) == 0 )
            {
                // 設定に基づきゼロ詰め
                // （本来この処理を不要にする為のコンポーネントだが、入力方式が特殊なので手動対応する）

                return targetEdit.Text.TrimEnd().PadLeft( uiset.Column, '0' );
            }
            else
            {
                // 設定を取得できなかった場合はそのまま返す。
                return targetEdit.Text.TrimEnd();
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

        // ---ADD 2010/08/06-------------------->>>
        /// <summary>
        /// キー押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN04001UA_KeyDown(object sender, KeyEventArgs e)
        {
            // ESCキー押下による画面閉じる処理
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // ---ADD 2010/08/06--------------------<<<

		# endregion
	}
}
