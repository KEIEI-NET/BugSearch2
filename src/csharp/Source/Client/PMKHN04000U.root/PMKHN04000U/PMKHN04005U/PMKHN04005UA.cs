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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 得意先簡易検索フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先検索フォームクラスです。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2007.02.12</br>
	/// <br>Update Note: 明細表示順位の変更( 得意先カナの昇順から得意先コード昇順に変更 )</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009/07/10</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/25 徐錦山</br>
    /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/27 徐錦山</br>
    /// <br>             PM1107C:絞り込みフィルター追加(#9)</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    /// <br>Update Note: 2011/08/11 周雨</br>
    /// <br>             redmine #23479 絞り込みフィルター追加(#9)</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    ///<br>Update Note: 2011/08/19 黄海霞</br>
    /// <br>             redmine #23705 PCC自社用得意先ガイド追加 for #23705</br>
    /// <br>------------------------------------------------------------------------------------</br>  
    /// </remarks>
	public partial class PMKHN04005UA : System.Windows.Forms.Form
	{
        /// <summary>
        /// 得意先選択イベントデリゲート
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        public delegate void CustomerSelectEventHandler( object sender, CustomerSearchRet customerSearchRet );
        
        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 得意先検索フォームフレームクラスデフォルトコンストラクタ
		/// </summary>
		public PMKHN04005UA()
		{
			InitializeComponent();

			// 変数初期化
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._searchDataView = new DataView();
			this._initialDataRead = new InitialDataReadHandler(this.InitialDataRead);
			this._extractConditionItemControlDictionary = new Dictionary<string, Panel>();
            this._extractionConditionInfo = new CustomerSimpleSearchCndtn();
			this._extractConditionList.Add(this._extractionConditionInfo.Clone());
			this._controlScreenSkin = new ControlScreenSkin();
            this._salesTtlStAcs = new SalesTtlStAcs();
            this._paraMngSectionCode = string.Empty;
            this._paraMngSectionName = string.Empty;
            this._autoSearch = true;
            this._secInfoSetAcs = new SecInfoSetAcs();
		}

		/// <summary>
		/// 得意先検索フォームフレームクラスコンストラクタ
		/// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
		public PMKHN04005UA(int searchMode, int executeMode) : this()
		{
			this._searchMode = searchMode;
			this._executeMode = executeMode;
		}

        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
        /// <summary>
        /// PCC自社用得意先検索フォームフレームクラスコンストラクタ
        /// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
        public PMKHN04005UA(int searchMode, int executeMode, int pccuoeMode)
            : this()
        {
            this._searchMode = searchMode;
            this._executeMode = executeMode;
            this._pccuoeMode = pccuoeMode;
        }
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
		
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

		// ===================================================================================== //
		// 内部で使用する定数群
		// ===================================================================================== //
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 徐錦山</br>
        /// <br>             PM1107C:絞り込みフィルター追加(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
		#region Const
		// データテーブル列定義（得意先検索結果情報）
		internal const string SEARCH_TABLE							= "SEARCHTABLE";
		internal const string SEARCH_COL_EnterpriseCode				= "EnterpriseCode";				// 企業コード(カラム文字)
		internal const string SEARCH_COL_CustomerCode				= "CustomerCode";				// 得意先コード
		internal const string SEARCH_COL_CustomerSubCode			= "CustomerSubCode";			// 得意先サブコード
		internal const string SEARCH_COL_Name						= "Name";						// 名称
		internal const string SEARCH_COL_Name2						= "Name2";						// 名称２
        // 2011/7/25 XUJS ADD STA>>>>>>
        internal const string SEARCH_COL_Snm                        = "Snm";						// 略称
        // 2011/7/25 XUJS ADD END<<<<<<
		internal const string SEARCH_COL_Kana						= "Kana";						// カナ
		internal const string SEARCH_COL_CustomerSearchRet			= "CustomerSearchRet";			// 得意先検索戻り値クラス
		internal const string SEARCH_COL_HtmlString					= "HtmlString";					// 詳細表示用HTML文字列
		internal const string SEARCH_COL_SelectedFlg				= "SelectedFlg";				// 選択済みフラグ
		internal const string SEARCH_COL_LogicalDeleteCode			= "LogicalDeleteCode";			// 論理削除区分（得意先）

		private const string EXTRACT_CONDITION_XML_FILE_NAME = "PMKHN04005U_ExtractCondition.XML";	// 抽出条件セッティングＸＭＬファイルパス
		private const string FILENAME_COLDISPLAYSTATUS = "PMKHN04005U_ColSetting.DAT";				// 列表示状態セッティングXMLファイル名
		private const string TEMP_FOLDER_NAME = "Temp";												// Tempフォルダ名称
		//private const string MESSAGE_NONDATA = "該当するデータが見つかりませんでした。";			// 該当データ無しメッセージ  //DEL 2011/08/11
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
        /// <summary>SEARCHMODE 納入先</summary>
        public const int SEARCHMODE_RECEIVER = 2;   // 納入先
        /// <summary>SEARCHMODE 得意先のみ</summary>
        public const int SEARCHMODE_CUSTOMER_ONLY = 3;
        /// <summary>EXECUTEMODE 通常</summary>
        public const int EXECUTEMODE_NORMAL = 0;
        /// <summary>EXECUTEMODE ガイドのみ</summary>
        public const int EXECUTEMODE_GUIDE_ONLY = 1;
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
        /// <summary>
        /// 0:通常
        /// </summary>
        public const int PCCUOEN_NORMAL_ONLY = 0;
        /// <summary>
        /// 1:PCC自社用
        /// </summary>
        public const int PCCUOE_CMPNYST_ONLY = 1;
        /// <summary>
        /// 2:PCCマスメン用
        /// </summary>
        public const int PCCUOE_MASTER_ONLY = 2;
        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
        
        # endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = "";												// 企業コード
		private ImageList _imageList16 = null;												// イメージリスト
        private CustomerSimpleSearchCndtn _extractionConditionInfo = null;		// 抽出条件入力情報クラス
		private delegate void InitialDataReadHandler();
		InitialDataReadHandler _initialDataRead = null;
		private DataView _searchDataView = null;											// 得意先検索結果データビュー
		private Dictionary<string, Panel> _extractConditionItemControlDictionary = null;	// 抽出条件入力項目Dictionary
        private List<CustomerSimpleSearchCndtn> _extractConditionList = new List<CustomerSimpleSearchCndtn>();	// 抽出条件履歴リスト
		private ColDisplayStatusList _colDisplayStatusList = null;							// 列表示状態コレクションクラス
		private int _selectedRowIndex = -1;													// 選択行Index
		private int _searchMode = SEARCHMODE_NORMAL;										// 検索モード
		private int _executeMode = EXECUTEMODE_NORMAL;										// 起動モード
		private ControlScreenSkin _controlScreenSkin;
        private string _paraMngSectionCode;                                                 // （抽出条件）管理拠点コード
        private string _paraMngSectionName;                                                 // （抽出条件）管理拠点名称
        private bool _autoSearch;                                                           // 自動検索区分（ＵＩ制御）
        private SalesTtlStAcs _salesTtlStAcs = null;
        // 2011/07/27 XUJS ADD STA>>>>>>
        private SecInfoSetAcs _secInfoSetAcs = null;                                        // 拠点アクセスクラス
        private int _praCustomerCode = -1;
        // 2011/07/27 XUJS ADD END<<<<<<
        private int _pccuoeMode;                                                            //PCC自社用タイプ ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19
        
		# endregion

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

            //if (this._executeMode == EXECUTEMODE_GUIDE_ONLY)
            //{
            //    selectButton.SharedProps.Visible = true;
            //    customerNewButton.SharedProps.Visible = false;
            //    customerEditButton.SharedProps.Visible = false;
            //    customerDeleteButton.SharedProps.Visible = false;
            //}
            //else
            //{
            //    selectButton.SharedProps.Visible = false;
            //    customerNewButton.SharedProps.Visible = true;
            //    customerEditButton.SharedProps.Visible = true;
            //    customerDeleteButton.SharedProps.Visible = true;
            //}
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.09.03</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 徐錦山</br>
        /// <br>             PM1107C:絞り込みフィルター追加(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
		/// </remarks>
		private void InitialSetting()
		{
			// スキンロード
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
			CustomControlAppearance controlAppearance = this._controlScreenSkin.GetControlAppearance();

			this.SearchResultHeader_ULabel.Appearance.BackColor = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.SearchResultHeader_ULabel.Appearance.BackColor2 = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.SearchResultHeader_ULabel.Appearance.BackGradientStyle = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.SearchResultHeader_ULabel.Appearance.ForeColor = this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;

			// ツールバー初期設定処理
			this.SetToolbar();

			// MDI／SDIフォーム設定処理
			this.MdiSdiFormSetting();

			// 各コントロール初期設定
			this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;
			this.GridFontSize_TComboEditor.Value = 10;
			
			// 得意先検索結果データテーブル設定処理
			this.SettingCustomerSearchDataTable();

			// 固定ヘッダー機能の有効にする
			this.SearchResult_UGrid.DisplayLayout.UseFixedHeaders = true;

			// 得意先検索結果グリッドカラム情報設定処理
			this.SettingSearchGridColumn(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);

			// 行サイズを設定
            this.SearchResult_UGrid.DisplayLayout.Override.DefaultRowHeight = 20;

            // 修正 2009/07/10 >>>
			//this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            // 修正 2009/07/10 <<<

            // 2011/07/27 XUJS ADD STA>>>>>>
            this.FilterResult_Panel.Dock = DockStyle.Top;
            // 2011/07/27 XUJS ADD END<<<<<<
			this.ExtractResult_Panel.Dock = DockStyle.Fill;

            // 売上全体設定を参照
            SalesTtlSt salesTtlSt;
            // 2008.08.28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //int status = this._salesTtlStAcs.Read(out salesTtlSt, this._enterpriseCode);
            int status = this._salesTtlStAcs.Read(out salesTtlSt, this._enterpriseCode, this._paraMngSectionCode);
            // 2008.08.28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            if (status == 0)
            {
                // 「自拠点のみ表示」の場合のみ、管理拠点自動入力ＯＮにする
                if ( salesTtlSt.CustGuideDispDiv == 1 )
                {
                    // 管理拠点自動入力
                    this._extractionConditionInfo.MngSectionCode = _paraMngSectionCode;
                    this._extractionConditionInfo.MngSectionName = _paraMngSectionName;
                    
                    //// 複数選択チェック
                    //this.MultiSelect_UCheckEditor.Checked = true;

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
            }
            this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "F3：条件設定　F6：絞込　ESC：終了"; //ADD 2011/08/11
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
        /// <br>Update Note: 2011/07/25 徐錦山</br>
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
			DataColumn CustomerCode = new DataColumn(SEARCH_COL_CustomerCode, typeof(Int32), "", MappingType.Element);
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

            // 2011/7/25 XUJS ADD STA>>>>>>
            // 略称
            DataColumn Snm = new DataColumn(SEARCH_COL_Snm, typeof(String), "", MappingType.Element);
            Snm.Caption = "得意先略称";
            // 2011/7/25 XUJS ADD END<<<<<<

			// カナ
			DataColumn Kana = new DataColumn(SEARCH_COL_Kana, typeof(String), "", MappingType.Element);
			Kana.Caption = "得意先名(ｶﾅ)";

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
                                                              // 2011/7/25 XUJS ADD STA>>>>>>
                                                              Snm,                          // 略称
                                                              // 2011/7/25 XUJS ADD END<<<<<<
															  Kana,							// カナ
															  EnterpriseCode,				// 企業コード(カラム文字)
															  Name2,						// 名称２
															  CustomerSearchRetCol,			// 得意先検索結果クラス
															  HtmlString,					// 詳細表示用HTML文字列
															  SelectedFlg,					// 選択済みフラグ
															  LogicalDeleteCodeCustomer,	// 論理削除区分（得意先）
															});

			this._searchDataView.Table = searchTable;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._searchDataView.Sort = string.Format( "{0} ASC", SEARCH_COL_CustomerCode );
            this._searchDataView.RowFilter = string.Format( "{0}=0", SEARCH_COL_LogicalDeleteCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			//　グリッドにデータセットをバインド
			//this.SearchResult_UGrid.DataSource = this.Search_DataSet.Tables[SEARCH_TABLE];
            this.SearchResult_UGrid.DataSource = _searchDataView;

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
        /// <br>Update Note: 2011/07/25 徐錦山</br>
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
            // 2011/7/25 XUJS ADD STA>>>>>>
            row[SEARCH_COL_Snm]                         = searchRet.Snm;                            // 略称
            // 2011/7/25 XUJS ADD END<<<<<<
			row[SEARCH_COL_Kana]						= searchRet.Kana;							// カナ
			row[SEARCH_COL_CustomerSearchRet]			= searchRet.Clone();						// 得意先検索戻り値クラス
			row[SEARCH_COL_HtmlString]					= "";										// 詳細表示用HTML文字列
			row[SEARCH_COL_SelectedFlg]					= (int)RowSelected.No;						// 選択済みフラグ
			row[SEARCH_COL_LogicalDeleteCode]			= searchRet.LogicalDeleteCode;				// 論理削除区分（得意先）

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
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private void SettingSearchGridColumn(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            UiSet uiset;
            uiSetControl1.ReadUISet( out uiset, "tNedit_CustomerCode" );
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
			columns[SEARCH_COL_Name].Header.Caption							= "得意先名";
			columns[SEARCH_COL_Name].Hidden									= false;
			columns[SEARCH_COL_Name].Width									= 150;

            // 2011/7/25 XUJS ADD STA>>>>>>
            // 略称 列設定
            columns[SEARCH_COL_Snm].Header.Caption = "得意先略称";
            columns[SEARCH_COL_Snm].Hidden = false;
            columns[SEARCH_COL_Snm].Width = 120;
            // 2011/7/25 XUJS ADD END<<<<<<

			// 得意先コード 列設定
            columns[SEARCH_COL_CustomerCode].Header.Caption = "得意先コード";
			columns[SEARCH_COL_CustomerCode].Hidden							= false;
			columns[SEARCH_COL_CustomerCode].CellAppearance.TextHAlign		= Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            columns[SEARCH_COL_CustomerCode].Format = customerFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 得意先サブコード 列設定
            columns[SEARCH_COL_CustomerSubCode].Header.Caption = "得意先サブコード";
			columns[SEARCH_COL_CustomerSubCode].Hidden						= false;

			// 得意先カナ 列設定
			columns[SEARCH_COL_Kana].Header.Caption							= "得意先名(ｶﾅ)";
			columns[SEARCH_COL_Kana].Hidden									= false;

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

				int logicalDeleteCodeCustomer = Convert.ToInt32(row.Cells[SEARCH_COL_LogicalDeleteCode].Text.ToString());

				if (logicalDeleteCodeCustomer != 0)
				{
					row.Appearance.ForeColor = Color.DarkGray;
				}
				else
				{
					row.Appearance.ForeColor = Color.Black;
				}
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
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 徐錦山</br>
        /// <br>             PM1107C:絞り込みフィルター追加(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
		/// </remarks>
		private void SetDisplayFormSearchRetArray(CustomerSearchRet[] customerSearchRetArray)
		{
			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();

			if ((customerSearchRetArray == null) || (customerSearchRetArray.Length == 0))
			{
				// データ無し
				//this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = MESSAGE_NONDATA; //DEL 2011/08/11
				this.MessageUnDisp_Timer.Enabled = true;
			}
			else
			{
				// 得意先検索結果グリッド行設定処理
				foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
				{
					DataRow dataRow = null;

					// 得意先検索結果グリッド行設定処理
                    // 2011/07/27 XUJS ADD STA>>>>>>
                    if (_praCustomerCode != -1)
                    {
                        if (customerSearchRet.CustomerCode < _praCustomerCode) continue;
                    }
                    // 2011/07/27 XUJS ADD END<<<<<<
					dataRow = this.CustomerSearchRetToDataRow(customerSearchRet, dataRow);
					this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Add(dataRow);
				}

				//this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "抽出件数：" + this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Count.ToString() + " 件";
                //this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "抽出件数：" + _searchDataView.Count + " 件"; //DEL 2011/08/11
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
        /// <br>Update Note: 2011.08.19 黄海霞</br>
        /// <br>             PCC自社用得意先ガイド追加 for #23705</br>
		/// </remarks>
        private void SettingExtractionConditionClass( ref CustomerSimpleSearchCndtn conditionInfo )
		{
            if ( conditionInfo == null ) conditionInfo = new CustomerSimpleSearchCndtn();

			// 企業コード
			conditionInfo.EnterpriseCode = this._enterpriseCode;

			// 論理削除データ抽出区分
			conditionInfo.LogicalDeleteDataPickUp = 0;

            // 業販先区分
            switch ( _searchMode )
            {
                case SEARCHMODE_CUSTOMER_ONLY:
                    {
                        conditionInfo.AcceptWholeSale = 1;  // 得意先（のみ）
                    }
                    break;
                case SEARCHMODE_RECEIVER:
                    {
                        conditionInfo.AcceptWholeSale = 2;  // 納入先（のみ）
                    }
                    break;
                case SEARCHMODE_NORMAL:
                default:
                    {
                        conditionInfo.AcceptWholeSale = -1; // ＡＬＬ
                    }
                    break;
            }
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
            //PCC自社用タイプ
            switch (_pccuoeMode)
            {
                case PCCUOE_CMPNYST_ONLY:
                    {
                        conditionInfo.PccuoeMode = 1;  // 1:PCC自社用
                    }
                    break;
                case PCCUOE_MASTER_ONLY:
                    {
                        conditionInfo.PccuoeMode = 2;  // 2:PCCマスメン用
                    }
                    break;
                default:
                    {
                        conditionInfo.PccuoeMode = 0; // ＡＬＬ
                    }
                    break;
            }
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<

            // 2008.08.28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 拠点コード
            //conditionInfo.MngSectionCode = this.MngSectionCode;
            // 2008.08.28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
		/// クリア処理
		/// </summary>
		private void Clear()
		{
			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();
			this._extractConditionList.Clear();
            this._extractionConditionInfo = new CustomerSimpleSearchCndtn();

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			this.Initial_Timer.Enabled = true;
		}

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
			_fs = new FileStream( "PMKHN04005U.Log", FileMode.Append, FileAccess.Write, FileShare.Write );
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
		private void PMKHN04005UA_Load(object sender, System.EventArgs e)
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
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

            // 検索実行
            if ( _autoSearch )
            {
                Search_Timer_Tick( this, new EventArgs() );
            }
		}

		/// <summary>
		/// タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MessageUnDisp_Timer_Tick(object sender, System.EventArgs e)
		{
			this.MessageUnDisp_Timer.Enabled = false;
			//this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = ""; //DEL 2011/08/11
		}

		/// <summary>
		/// ツールバーツールクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
            switch ( e.Tool.Key )
            {
                case "Close_ButtonTool":
                    {
                        this.Close();
                        break;
                    }
                case "Return_ButtonTool":
                    {
                        int maxIndex = this._extractConditionList.Count - 1;
                        if ( maxIndex < 1 ) return;

                        // 最終のアイテムを削除する
                        CustomerSimpleSearchCndtn removeInfo = this._extractConditionList[maxIndex];
                        this._extractConditionList.Remove( removeInfo );

                        // 現在から１つ以前のアイテムを取得し、再検索を行う。
                        CustomerSimpleSearchCndtn targetInfo = this._extractConditionList[maxIndex - 1];

                        if ( targetInfo != null )
                        {
                            this._extractionConditionInfo = targetInfo.Clone();
                        }

                        break;
                    }
                case "Clear_ButtonTool":
                    {
                        // クリア処理
                        this.Clear();

                        break;
                    }
                case "Select_ButtonTool":
                    {
                        // 選択ボタンクリック処理
                        this.SelectButtonClick();

                        break;
                    }
            }
        }

		/// <summary>
		/// 検索ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Search_UButton_Click(object sender, System.EventArgs e)
		{
			this.Search_Timer.Enabled = true;
		}

		/// <summary>
		/// 検索タイマーイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void Search_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Search_Timer.Enabled = false;

			this.Cursor = Cursors.WaitCursor;

			this._selectedRowIndex = -1;

			// 得意先検索パラメータクラス生成処理
			this.SettingExtractionConditionClass(ref this._extractionConditionInfo);

			if (this._extractionConditionInfo == null) return;


			// 得意先検索処理
			this.SearchCustomerData();

			// グリッド行表示設定処理
			this.SettingGridRowAppearance();

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

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
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void PMKHN04005UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 列表示状態クラスリスト構築処理
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// 列表示状態クラスリストをXMLにシリアライズする
			ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
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
            if ( !e.Shift )
            {
                switch ( e.KeyCode )
                {
                    case Keys.Return:
                        {
                            Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

                            if ( selectButton.SharedProps.Visible )
                            {
                                // 選択ボタンクリック処理
                                this.SelectButtonClick();

                            }
                            break;  //ADD 2011/08/11
                        }
                    // -------------------- ADD 2011/08/11 --------------->>>>>
                    case Keys.F3:
                        {
                            this.ActiveControl = this.TEdit_Kana;
                            this.TEdit_Kana.Focus();
                            break;
                        }
                    default:
                    // -------------------- ADD 2011/08/11 ---------------<<<<<
                        break;
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
		/// データ表示タイマーイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void DetailView_Timer_Tick(object sender, System.EventArgs e)
		{
			this.DetailView_Timer.Enabled = false;

			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				Control activeControl = this.ActiveControl;
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

        ///// <summary>
        ///// フォーカスコントロールイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        //private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        //{
        //    if (this._extractionConditionInfo == null) return;
        //    if (e.PrevCtrl == null || e.NextCtrl == null) return;

        //    switch ( e.PrevCtrl.Name )
        //    {
        //        // Grid
        //        case "SearchResult_UGrid":
        //            {
        //                if ( e.Key == Keys.Return )
        //                {
        //                    Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

        //                    if ( selectButton.SharedProps.Visible )
        //                    {
        //                        // 選択ボタンクリック処理
        //                        this.SelectButtonClick();

        //                    }
        //                }
        //            }
        //            break;
        //    }
        //}

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
		/// 検索結果グリッドマウスエンターエレメントイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 徐錦山</br>
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
				Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;
				string tipString = "";

				if (row.Cells[0] != null)
				{
					int totalWidth = 6;

					// 得意先名称
					tipString += this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Name].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Name].Value.ToString();

                    // 2011/7/25 XUJS ADD STA>>>>>>
                    // 得意先略称
                    tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Snm].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Snm].Value.ToString();
                    // 2011/7/25 XUJS ADD END<<<<<<

					// カナ
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_Kana].Value.ToString();

					// 得意先コード
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerCode].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_CustomerCode].Value.ToString();

					// 得意先サブコード
					tipString += "\r\n" + this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerSubCode].Header.Caption.PadRight(totalWidth, '　') + "：" + row.Cells[SEARCH_COL_CustomerSubCode].Value.ToString();
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
			}

		}

		/// <summary>
		/// フォーム起動後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void PMKHN04005UA_Shown(object sender, EventArgs e)
		{
		}
		# endregion

        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/27 徐錦山</br>
        /// <br>             PM1107C:絞り込みフィルター追加(#9)</br>
        /// <br>------------------------------------------------------------------------------------</br> 
        // 2011/07/27 XUJS ADD STA>>>>>>
        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //todo
            if (this._extractionConditionInfo == null) return;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if (_extractionConditionInfo == null) return;

            try
            {
                CustomerSimpleSearchCndtn extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

                switch (e.PrevCtrl.Name)
                {
                    // 得意先名称（カナ） ============================================ //
                    case "TEdit_Kana":
                        {
                            if (this._extractionConditionInfo.Kana != this.TEdit_Kana.DataText)
                            {
                                extractionConditionInfoBuff.Kana = this.TEdit_Kana.DataText;
                                extractionConditionInfoBuff.KanaSearchType = 1;
                            }
                            break;
                        }
                    // 得意先名称 ============================================ //
                    case "TEdit_Name":
                        {
                            if (this._extractionConditionInfo.Name != this.TEdit_Name.DataText)
                            {
                                extractionConditionInfoBuff.Name = this.TEdit_Name.DataText;
                                extractionConditionInfoBuff.NameSearchType = 1;
                            }
                            break;
                        }
                    // 得意先名称（略称） ============================================ //
                    case "TEdit_Snm":
                        {
                            if (this._extractionConditionInfo.CustomerSnm != this.TEdit_Snm.DataText)
                            {
                                extractionConditionInfoBuff.CustomerSnm = this.TEdit_Snm.DataText;
                                extractionConditionInfoBuff.CustomerSnmSearchType = 1;
                            }
                            break;
                        }
                    // 開始コード ============================================ //
                    case "TEdit_Code":
                        {
                            int tempCode = _praCustomerCode;
                            if (this.TEdit_Code.DataText.Trim() != string.Empty)
                            {
                                _praCustomerCode = Convert.ToInt32(this.TEdit_Code.DataText.Trim());
                                if (_praCustomerCode == 0)
                                {
                                    this.TEdit_Code.DataText = string.Empty;
                                    _praCustomerCode = -1;
                                }
                                else
                                    this.TEdit_Code.DataText = GetInputCode(TEdit_Code);
                            }
                            else
                            {
                                _praCustomerCode = -1;
                            }
                            if (tempCode != _praCustomerCode)
                            {
                                this.Search();
                                //e.NextCtrl = SearchResult_UGrid; //DEL 2011/08/11
                            }
                            //return;  //DEL 2011/08/11
                            break;
                        }
                    // 管理拠点 ============================================ //
                    case "TEdit_MngSectionNm":
                        {

                            if (this.TEdit_MngSectionNm.DataText.Trim() != string.Empty)
                            {
                                if (this._extractionConditionInfo.MngSectionName.CompareTo(this.TEdit_MngSectionNm.DataText.Trim()) != 0)
                                {
                                    SecInfoSet secInfoSet;
                                    string section = GetInputCode(TEdit_MngSectionNm);
                                    int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, section);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        extractionConditionInfoBuff.MngSectionCode = section;
                                        extractionConditionInfoBuff.MngSectionName = secInfoSet.SectionGuideNm;
                                        this.TEdit_MngSectionNm.DataText = extractionConditionInfoBuff.MngSectionName;
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        extractionConditionInfoBuff.MngSectionCode = string.Empty;
                                        extractionConditionInfoBuff.MngSectionName = string.Empty;
                                        this.TEdit_MngSectionNm.DataText = string.Empty;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_STOPDISP,
                                            this.Name,
                                            "拠点情報の取得に失敗しました。",
                                            status,
                                            MessageBoxButtons.OK);
                                    }
                                }
                            }
                            else
                            {
                                // 入力クリア
                                extractionConditionInfoBuff.MngSectionCode = string.Empty;
                                extractionConditionInfoBuff.MngSectionName = string.Empty;
                                this.TEdit_MngSectionNm.DataText = string.Empty;
                            }

                            break;
                        }
                    //--------------------ADD 2011/08/11--------------->>>>>
                    // 検索結果グリッド ======================================== //
                    case "SearchResult_UGrid":
                        {
                            if (e.Key == Keys.Return)
                            {
                                Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

                                if (selectButton.SharedProps.Visible)
                                {
                                    // 選択ボタンクリック処理
                                    this.SelectButtonClick();
                                }
                            }
                            break;
                        }
                    //--------------------ADD 2011/08/11---------------<<<<<
                }

                // 得意先検索パラメータクラス生成処理
                this.SettingExtractionConditionClass(ref extractionConditionInfoBuff);

                // メモリ上の内容と比較する
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    this.Search();
                    //e.NextCtrl = SearchResult_UGrid;  //DEL 2011/08/11
                }
            }
            catch { 
            }
            finally { 
            }
        }

        /// <summary>
        /// 文字列項目のコード変換処理(ｾﾞﾛ詰め対応)
        /// </summary>
        /// <param name="targetEdit"></param>
        /// <returns></returns>
        private string GetInputCode(TEdit targetEdit)
        {
            // 設定に基づきゼロ詰め
            // （本来この処理を不要にする為のコンポーネントだが、入力方式が特殊なので手動対応する）
            return targetEdit.DataText.TrimEnd().PadLeft(targetEdit.ExtEdit.Column, '0');
        }
        // 2011/07/27 XUJS ADD END<<<<<<

        //--------------------ADD 2011/08/11--------------->>>>>
        /// <summary>
        /// グリッドへのフォーカス進入イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchResult_UGrid_Enter(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in SearchResult_UGrid.Rows)
            {
                this.SearchResult_UGrid.Focus();
                this.SearchResult_UGrid.ActiveRow = row;
                this.SearchResult_UGrid.ActiveRow.Selected = true;

                break;
            }
        }

        /// <summary>
        /// キー押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN04005UA_KeyDown(object sender, KeyEventArgs e)
        {
            // ESCキー押下による画面閉じる処理
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            //F6キー押下
            if (e.KeyCode == Keys.F6)
            {
                CustomerSimpleSearchCndtn extractionConditionInfoBuff = this._extractionConditionInfo.Clone();

                // 得意先名称（カナ
                if (this._extractionConditionInfo.Kana != this.TEdit_Kana.DataText)
                {
                    extractionConditionInfoBuff.Kana = this.TEdit_Kana.DataText;
                    extractionConditionInfoBuff.KanaSearchType = 1;
                }

                // 得意先名称
                if (this._extractionConditionInfo.Name != this.TEdit_Name.DataText)
                {
                    extractionConditionInfoBuff.Name = this.TEdit_Name.DataText;
                    extractionConditionInfoBuff.NameSearchType = 1;
                }

                // 得意先名称（略称）
                if (this._extractionConditionInfo.CustomerSnm != this.TEdit_Snm.DataText)
                {
                    extractionConditionInfoBuff.CustomerSnm = this.TEdit_Snm.DataText;
                    extractionConditionInfoBuff.CustomerSnmSearchType = 1;
                }

                // 開始コード
                int tempCode = _praCustomerCode;
                if (this.TEdit_Code.DataText.Trim() != string.Empty)
                {
                    _praCustomerCode = Convert.ToInt32(this.TEdit_Code.DataText.Trim());
                    if (_praCustomerCode == 0)
                    {
                        this.TEdit_Code.DataText = string.Empty;
                        _praCustomerCode = -1;
                    }
                    else
                        this.TEdit_Code.DataText = GetInputCode(TEdit_Code);
                }
                else
                {
                    _praCustomerCode = -1;
                }

                // 管理拠点
                if (this.TEdit_MngSectionNm.DataText.Trim() != string.Empty)
                {
                    if (this._extractionConditionInfo.MngSectionName.CompareTo(this.TEdit_MngSectionNm.DataText.Trim()) != 0)
                    {
                        SecInfoSet secInfoSet;
                        string section = GetInputCode(TEdit_MngSectionNm);
                        int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, section);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            extractionConditionInfoBuff.MngSectionCode = section;
                            extractionConditionInfoBuff.MngSectionName = secInfoSet.SectionGuideNm;
                            this.TEdit_MngSectionNm.DataText = extractionConditionInfoBuff.MngSectionName;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            extractionConditionInfoBuff.MngSectionCode = string.Empty;
                            extractionConditionInfoBuff.MngSectionName = string.Empty;
                            this.TEdit_MngSectionNm.DataText = string.Empty;
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "拠点情報の取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    // 入力クリア
                    extractionConditionInfoBuff.MngSectionCode = string.Empty;
                    extractionConditionInfoBuff.MngSectionName = string.Empty;
                    this.TEdit_MngSectionNm.DataText = string.Empty;
                }

                // 得意先検索パラメータクラス生成処理
                this.SettingExtractionConditionClass(ref extractionConditionInfoBuff);

                this._extractionConditionInfo = extractionConditionInfoBuff.Clone();
                this.Search();
                this.SearchResult_UGrid.Focus();
            }
        }
        //--------------------ADD 2011/08/11---------------<<<<<
	}
}
