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
    /// お買得商品グループ検索フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : お買得商品グループ検索フォームクラスです。</br>
	/// <br>Programmer : 20073 西 毅</br>
	/// <br>Date       : 2015.02.24</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/05 鹿庭 一郎</br>
    /// <br>             RedMine#331:ユーザー設定分が取得されない</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/06 小栗 大介</br>
    /// <br>             RedMine#331:リモートを正しく呼ぶように修正</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/06 鹿庭 一郎</br>
    /// <br>             RedMine#331:通常モードでの得意先初期設定を表示</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/09 脇田 靖之</br>
    /// <br>            　　　　　　:通常モードの場合、得意先を使用不可に設定</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/11 小栗 大介</br>
    /// <br>                        :通常モードの場合にEnterで確定できない現象を修正</br>
    /// <br>                         照会モードで得意先の絞込が行えない現象を修正</br>
    /// <br>                         通常モードの場合にグリッド先頭行から上を押すとフォーカスが</br>
    /// <br>                         失われる現象を修正</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/03/19 脇田 靖之</br>
    /// <br>                        :品証Redmine#3295 課題管理表№38</br>
    /// <br>                         ユーザー登録分とBL提供分が重複している場合、</br>
    /// <br>                         ユーザー登録分を優先して表示する</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	public partial class PMREC09030UA : System.Windows.Forms.Form
	{
        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
        /// お買得商品グループ検索フォームフレームクラスデフォルトコンストラクタ
		/// </summary>
		public PMREC09030UA()
		{
			InitializeComponent();

			// 変数初期化
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._searchDataView = new DataView();
			this._initialDataRead = new InitialDataReadHandler(this.InitialDataRead);
			this._extractConditionItemControlDictionary = new Dictionary<string, Panel>();
            //this._extractionConditionInfo = new CustomerSimpleSearchCndtn();
			//this._extractConditionList.Add(this._extractionConditionInfo.Clone());
			//this._controlScreenSkin = new ControlScreenSkin();
            //this._salesTtlStAcs = new SalesTtlStAcs();
            this._paraMngSectionCode = string.Empty;
            this._paraMngSectionName = string.Empty;
            this._autoSearch = true;
            //this._secInfoSetAcs = new SecInfoSetAcs();
            this._customerCodeList = new ArrayList();
            this._customerSearchAcs = new CustomerSearchAcs();
            this.GridKeyUpTopRow += new EventHandler(this.GriedDetail_GridKeyUpTopRow);
            this._controlScreenSkin = new ControlScreenSkin();
        }

		/// <summary>
        /// お買得商品グループ検索フォームフレームクラスコンストラクタ
		/// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
        public PMREC09030UA(int GuideType, int CustomerCode)
            : this()
		{
            this._guideType = GuideType;
            this._customerCode = CustomerCode;
            //------ ADD 2015/03/06 小栗 ----->>>>>>
            this._praCustomerCode = this._customerCode;
            //------ ADD 2015/03/06 小栗 -----<<<<<<

        }

        //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
        /// <summary>
        /// お買得商品グループ検索フォームフレームクラスコンストラクタ（得意先リスト渡し）
        /// </summary>
        /// <param name="searchMode"></param>
        /// <param name="executeMode"></param>
        public PMREC09030UA(int GuideType, int CustomerCode, ArrayList customerCodeList)
            : this()
        {
            this._guideType = GuideType;
            this._customerCode = CustomerCode;
            //------ ADD 2015/03/06 小栗 ----->>>>>>
            this._praCustomerCode = this._customerCode;
            //------ ADD 2015/03/06 小栗 -----<<<<<<
            this._customerCodeList = customerCodeList;
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
                /*
				int customerCode1 = Convert.ToInt32(row1.Cells[SEARCH_COL_CustomerCode].Value);
				int customerCode2 = Convert.ToInt32(row2.Cells[SEARCH_COL_CustomerCode].Value);

				if ((customerCode1 == 0) || (customerCode2 == 0)) return false;
				return customerCode1 == customerCode2;
                 */
                return true;
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
        // データテーブル列定義（お買得商品グループ検索結果情報）
		internal const string SEARCH_TABLE							= "SEARCHTABLE";
        internal const string SEARCH_COL_CustomerName = "CustomerName";				// 得意先コード
        internal const string SEARCH_COL_BrgnGoodsGrpCode = "BrgnGoodsGrpCode";			// 得意先サブコード
        internal const string SEARCH_COL_BrgnGoodsGrpTitle = "BrgnGoodsGrpTitle";						// 名称
        internal const string SEARCH_COL_BrgnGoodsGrpComment = "BrgnGoodsGrpComment";						// 名称２
        internal const string SEARCH_COL_LogicalDeleteCode = "LogicalDeleteCode";						// 名称２
        internal const string SEARCH_COL_SelectedFlg = "SelectedFlg";						// 名称２

		private const string EXTRACT_CONDITION_XML_FILE_NAME = "PMREC09030U_ExtractCondition.XML";	// 抽出条件セッティングＸＭＬファイルパス
		private const string FILENAME_COLDISPLAYSTATUS = "PMREC09030U_ColSetting.DAT";				// 列表示状態セッティングXMLファイル名
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
        public const int GUIDETYPE_NORMAL = 0;
        /// <summary>SEARCHMODE 納入先</summary>
        public const int GUIDETYPE_READONLY = 1;   // 読取専用
        
        # endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members

        /// <summary> 企業コード</summary>
        private string _enterpriseCode = "";												// 企業コード
        /// <summary> イメージリスト</summary>
        private ImageList _imageList16 = null;												// イメージリスト

        //private CustomerSimpleSearchCndtn _extractionConditionInfo = null;		// 抽出条件入力情報クラス
        //private List<CustomerSimpleSearchCndtn> _extractConditionList = new List<CustomerSimpleSearchCndtn>();	// 抽出条件履歴リスト

        /// <summary> お買得商品グループ検索結果データビュー</summary>
        private DataView _searchDataView = null;
        /// <summary> 抽出条件入力項目Dictionary</summary>
        private Dictionary<string, Panel> _extractConditionItemControlDictionary = null;
        /// <summary> 列表示状態コレクションクラス</summary>
        private ColDisplayStatusList _colDisplayStatusList = null;
        /// <summary> 選択行Index</summary>
        private int _selectedRowIndex = -1;													// 選択行Index

        InitialDataReadHandler _initialDataRead = null;
        private ControlScreenSkin _controlScreenSkin;

        #region コンストラクタ引数格納用

        /// <summary> 検索タイプ（0:通常のガイド、1:お買得商品グループ状況照会） </summary>
        private int _guideType = GUIDETYPE_NORMAL;
        /// <summary> 得意先コード </summary>
		private int _customerCode = 0;
        /// <summary> 得意先リスト </summary>
        private ArrayList _customerCodeList;

        #endregion

        #region 抽出条件

        private string _paraMngSectionCode;                                                 // （抽出条件）管理拠点コード
        private string _paraMngSectionName;                                                 // （抽出条件）管理拠点名称
        private bool _autoSearch;                                                           // 自動検索区分（ＵＩ制御）
        //private SalesTtlStAcs _salesTtlStAcs = null;
        // 2011/07/27 XUJS ADD STA>>>>>>
        //private SecInfoSetAcs _secInfoSetAcs = null;                                        // 拠点アクセスクラス
        private int _praCustomerCode = -1;
        // 2011/07/27 XUJS ADD END<<<<<<
        //private int _pccuoeMode;                                                            //PCC自社用タイプ ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19
        private CustomerSearchAcs _customerSearchAcs;

        private bool _cusotmerGuideSelected; // 得意先ガイド選択フラグ

        # endregion

        #endregion

        // ===================================================================================== //
        // パブリック　プロパティ
        // ===================================================================================== //
        # region Public Propaty
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
        #region Event Hndlers

        /// <summary> お買得商品グループ選択イベント </summary>
        public event RecBgnGrpSelectEventHandler RecBgnGrpSelect;
        /// <summary> お買得商品グループ選択イベントデリゲート </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">お買得商品グループ検索戻り値クラス</param>
        public delegate void RecBgnGrpSelectEventHandler(object sender, RecBgnGrpRet recBgnGrpRet);
        /// <summary>フォーカスの変化</summary>
        internal event EventHandler GridKeyUpTopRow;
        /// <summary></summary>
        private delegate void InitialDataReadHandler();

        # endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
        /// お買得商品グループ検索処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : お買得商品グループ検索処理を実行します。</br>
		/// <br>Programer  : 22018　鈴木正臣</br>
		/// <br>Date       : 2005.09.05</br>
		/// </remarks>
		public void Search()
		{
			this.Search_UButton_Click(this, new EventArgs());
		}

		/// <summary>
		/// 選択情報（企業コード・得意先コード）取得処理
		/// </summary>
        /// <param name="customerSearchRet">お買得商品グループ検索結果クラス</param>
		/// <returns>STATUS[0:取得成功 0以外:取得失敗]</returns>
		/// <remarks>
        /// <br>Note       : 現在選択中のお買得商品グループ検索結果クラスを取得します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
        public int GetSelectInfo(out RecBgnGrpRet recBgnGrpRet)
		{

            recBgnGrpRet = null;

			if (this.SearchResult_UGrid.ActiveRow == null)
			{
				return -1;
			}

			// 選択行のインデックスを取得
			CurrencyManager cm = (CurrencyManager)BindingContext[this.SearchResult_UGrid.DataSource];
			int index = cm.Position;	

			// 指定行の内容を取得
			DataRow row = this._searchDataView[index].Row;

			// お買得商品グループ検索結果クラス取得処理（グリッド行より）
            recBgnGrpRet = this.DataRowTorecBgnGrpRet(row);

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //recBgnGrpRet = null;
            //return 0;
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
			// 閉じるのアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Close_ButtonTool"];
			closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // 選択のアイコン設定
			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];
			selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
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

			// ツールバー初期設定処理
			this.SetToolbar();

			// MDI／SDIフォーム設定処理
			this.MdiSdiFormSetting();

			// 各コントロール初期設定
			this.Main_StatusBar.Panels["StatusBarPanel_Progress"].Visible = false;
			this.GridFontSize_TComboEditor.Value = 10;

            // お買得商品グループ検索結果データテーブル設定処理
			this.SettingCustomerSearchDataTable();

			// 固定ヘッダー機能の有効にする
			this.SearchResult_UGrid.DisplayLayout.UseFixedHeaders = true;

            // お買得商品グループ検索結果グリッドカラム情報設定処理
			this.SettingSearchGridColumn(this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns);

			// 行サイズを設定
            this.SearchResult_UGrid.DisplayLayout.Override.DefaultRowHeight = 20;

            // 修正 2009/07/10 >>>
			//this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_Kana].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            this.SearchResult_UGrid.DisplayLayout.Bands[SEARCH_TABLE].Columns[SEARCH_COL_CustomerName].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending;
            // 修正 2009/07/10 <<<

            // 2011/07/27 XUJS ADD STA>>>>>>
            this.FilterResult_Panel.Dock = DockStyle.Top;
            // 2011/07/27 XUJS ADD END<<<<<<
			this.ExtractResult_Panel.Dock = DockStyle.Fill;
            //this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "F3：条件設定　F6：絞込　ESC：終了"; //ADD 2011/08/11
            this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = "F3：条件設定　F5：ｶﾞｲﾄﾞ　F6：絞込　ESC：終了"; //ADD 2011/08/11
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
			Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

            //string enterpriseCode;
			Infragistics.Win.UltraWinGrid.UltraGridRow row = this.SearchResult_UGrid.ActiveRow;

            if (this._guideType == GUIDETYPE_READONLY)
            {
                selectButton.SharedProps.Enabled = false;
            }
            else
            {
                if (row == null)
                {
                    selectButton.SharedProps.Enabled = false;

                }
                else
                {
                    selectButton.SharedProps.Enabled = true;
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
        /// お買得商品グループ検索結果データテーブル設定処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : お買得商品グループ検索結果のデータテーブルを設定します。</br>
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
			// 名称
            DataColumn CustomerName = new DataColumn(SEARCH_COL_CustomerName, typeof(String), "", MappingType.Element);
            CustomerName.Caption = "得意先名称";

            //  
            DataColumn BrgnGoodsGrpCode = new DataColumn(SEARCH_COL_BrgnGoodsGrpCode, typeof(String), "", MappingType.Element);
            BrgnGoodsGrpCode.Caption = "コード";

            // お買得商品グループタイトル
            DataColumn BrgnGoodsGrpTitle = new DataColumn(SEARCH_COL_BrgnGoodsGrpTitle, typeof(String), "", MappingType.Element);
            BrgnGoodsGrpTitle.Caption = "お買得商品グループタイトル";

            // お買得商品グループコメント
            DataColumn BrgnGoodsGrpComment = new DataColumn(SEARCH_COL_BrgnGoodsGrpComment, typeof(String), "", MappingType.Element);
            BrgnGoodsGrpComment.Caption = "お買得商品グループコメント";
            /*
			// お買得商品グループ検索結果クラス
            DataColumn CustomerSearchRetCol = new DataColumn(SEARCH_COL_CustomerSearchRet, typeof(RecBgnGrpRet), "", MappingType.Element);
			CustomerSearchRetCol.Caption = "お買得商品グループ検索結果クラス";

			// 詳細表示用HTML文字列
			DataColumn HtmlString = new DataColumn(SEARCH_COL_HtmlString, typeof(String), "", MappingType.Element);
			HtmlString.Caption = "詳細表示用HTML文字列";

            */
            // 選択済みフラグ
			DataColumn SelectedFlg = new DataColumn(SEARCH_COL_SelectedFlg, typeof(Int32), "", MappingType.Element);
            SelectedFlg.Caption = "選択済みフラグ";

			// 論理削除区分（得意先）
			DataColumn LogicalDeleteCodeCustomer = new DataColumn(SEARCH_COL_LogicalDeleteCode, typeof(Int32), "", MappingType.Element);
            LogicalDeleteCodeCustomer.Caption = "論理削除区分（得意先）";
			//--------------------------------------------------
			//  データセット、データテーブルの初期化
			//--------------------------------------------------
			// データセットの初期化
			this.Search_DataSet.Tables.AddRange(new DataTable[] {searchTable});

			// データテーブルの初期化
			searchTable.Columns.AddRange(new DataColumn[] {
															  CustomerName,					// 得意先コード
															  BrgnGoodsGrpCode,				// 得意先サブコード
															  BrgnGoodsGrpTitle,							// 名称
                                                              BrgnGoodsGrpComment,
                                                              SelectedFlg,
                                                              LogicalDeleteCodeCustomer
															});

			this._searchDataView.Table = searchTable;
            this._searchDataView.Sort = string.Format("{0} ASC", SEARCH_COL_CustomerName);
            //this._searchDataView.RowFilter = string.Format( "{0}=0", SEARCH_COL_LogicalDeleteCode );

			//　グリッドにデータセットをバインド
			//this.SearchResult_UGrid.DataSource = this.Search_DataSet.Tables[SEARCH_TABLE];
            this.SearchResult_UGrid.DataSource = _searchDataView;

		}

		/// <summary>
        /// お買得商品グループ検索結果クラス取得処理（グリッド行より）
		/// </summary>
		/// <param name="row">データ行情報</param>
        /// <returns>取得したお買得商品グループ検索結果クラスデータ</returns>
		/// <remarks>
        /// <br>Note       : データ行の情報からお買得商品グループ検索結果クラスを取得します。</br>
		/// <br>Programer  : 22018  鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
        private RecBgnGrpRet DataRowTorecBgnGrpRet(DataRow row)
		{
            /*
            if (_customerSearchRetDic.ContainsKey(customerCode))
            {
                retCustomerInfo = _customerSearchRetDic[customerCode];
            }
            */
            RecBgnGrpRet recBgnGrpRet = new RecBgnGrpRet();
            Int16 brgnGoodsGrpCode = 0;
            Int16.TryParse(row[SEARCH_COL_BrgnGoodsGrpCode].ToString(), out brgnGoodsGrpCode);
            recBgnGrpRet.BrgnGoodsGrpCode = brgnGoodsGrpCode;
            recBgnGrpRet.BrgnGoodsGrpComment = row[SEARCH_COL_BrgnGoodsGrpComment].ToString();
            recBgnGrpRet.BrgnGoodsGrpTitle = row[SEARCH_COL_BrgnGoodsGrpTitle].ToString();

            return recBgnGrpRet;
        }

		/// <summary>
        /// お買得商品グループ検索結果グリッド行設定処理
		/// </summary>
        /// <param name="searchRet">設定元のお買得商品グループ検索結果クラス</param>
		/// <param name="row">設定先のデータ行</param>
		/// <returns>値が設定されたデータ行</returns>
		/// <remarks>
        /// <br>Note       : お買得商品グループ検索結果クラスをデータ行へ設定します。</br>
		/// <br>Programer  : 22018　鈴木正臣</br>
		/// <br>Date       : 2005.08.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/25 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        private DataRow RecBgnGrpRetToDataRow(RecBgnGrpRet searchRet, DataRow row)
		{
			if (row == null)
			{
				row = this.Search_DataSet.Tables[SEARCH_TABLE].NewRow();
			}

            //row[SEARCH_COL_EnterpriseCode] = searchRet.LogicalDeleteCode.ToString();					// 論理削除区分
            //row[SEARCH_COL_CustomerCode] = searchRet.InqOriginalEpCd;					// 問合せ元企業コード
            //row[SEARCH_COL_CustomerSubCode] = searchRet.InqOriginalSecCd;				// 問合せ元拠点コード
            row[SEARCH_COL_BrgnGoodsGrpCode] = searchRet.BrgnGoodsGrpCode.ToString().PadLeft(4,'0');	// お買得商品グループコード
            //row[SEARCH_COL_Name2] = searchRet.DisplayOrder;							// 表示順位
            row[SEARCH_COL_BrgnGoodsGrpTitle] = searchRet.BrgnGoodsGrpTitle;                            // お買得商品グループタイトル
            //row[SEARCH_COL_Kana] = searchRet.BrgnGoodsGrpTag;							// お買得商品グループコメントタグ
            row[SEARCH_COL_BrgnGoodsGrpComment] = searchRet.BrgnGoodsGrpComment;						// お買得商品グループコメント

            if (searchRet.InqOriginalEpCd == ""
             && searchRet.InqOriginalSecCd == "")
            {
                row[SEARCH_COL_CustomerName] = "共通";
            }
            else
            {
                foreach (CustomerSearchRet customerSearchRet in _customerCodeList)
                {
                    if (customerSearchRet.LogicalDeleteCode == 0)
                    {
                        if (customerSearchRet.CustomerEpCode == searchRet.InqOriginalEpCd
                         && customerSearchRet.CustomerSecCode == searchRet.InqOriginalSecCd)
                        {
                            row[SEARCH_COL_CustomerName] = customerSearchRet.Snm;
                            break;
                        }
                    }
                }
            }

			return row;
		}

		/// <summary>
        /// お買得商品グループ検索結果グリッドカラム情報設定処理
		/// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
		/// <remarks>
        /// <br>Note       : お買得商品グループ検索結果グリッドに表示するカラム情報を設定します。</br>
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
			columns[SEARCH_COL_CustomerName].Header.Caption							= "得意先";
            columns[SEARCH_COL_CustomerName].Hidden = false;
            columns[SEARCH_COL_CustomerName].Width = 150;

            // 2011/7/25 XUJS ADD STA>>>>>>
            // 略称 列設定
            columns[SEARCH_COL_BrgnGoodsGrpCode].Header.Caption = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
            columns[SEARCH_COL_BrgnGoodsGrpCode].Hidden = false;
            columns[SEARCH_COL_BrgnGoodsGrpCode].Width = 120;
            // 2011/7/25 XUJS ADD END<<<<<<

			// 得意先コード 列設定
            columns[SEARCH_COL_BrgnGoodsGrpTitle].Header.Caption = "タイトル";
            columns[SEARCH_COL_BrgnGoodsGrpTitle].Hidden = false;
            columns[SEARCH_COL_BrgnGoodsGrpTitle].Format = customerFormat;

			// 得意先サブコード 列設定
            columns[SEARCH_COL_BrgnGoodsGrpComment].Header.Caption = "コメント";
            columns[SEARCH_COL_BrgnGoodsGrpComment].Hidden = false;


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
            /*
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
             */ 
		}

		/// <summary>
        /// お買得商品グループ検索結果配列→画面格納処理
		/// </summary>
        /// <param name="customerSearchRetArray">お買得商品グループ検索結果配列</param>
		/// <remarks>
        /// <br>Note       : お買得商品グループ検索結果配列の情報を画面に表示します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2005.07.19</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        private void SetDisplayFormSearchRetArray(RecBgnGrpRet[] recBgnGrpRetArray)
		{
			this.Search_DataSet.Tables[SEARCH_TABLE].Rows.Clear();

            if ((recBgnGrpRetArray == null) || (recBgnGrpRetArray.Length == 0))
			{
				// データ無し
				//this.Main_StatusBar.Panels["StatusBarPanel_Text"].Text = MESSAGE_NONDATA; //DEL 2011/08/11
				this.MessageUnDisp_Timer.Enabled = true;
			}
			else
			{
                // お買得商品グループ検索結果グリッド行設定処理
                foreach (RecBgnGrpRet recBgnGrpRet in recBgnGrpRetArray)
				{
					DataRow dataRow = null;
                    // お買得商品グループ検索結果グリッド行設定処理
                    /*
                    // 2011/07/27 XUJS ADD STA>>>>>>
                    if (_praCustomerCode != -1)
                    {
                        if (recBgnGrpRet.CustomerCode < _praCustomerCode) continue;
                    }
                    // 2011/07/27 XUJS ADD END<<<<<<
                     */

                    // --- ADD 2015/03/19 Y.Wakita ---------->>>>>
                    if (0 < this._praCustomerCode)
                    {
                        // 提供データの場合、ユーザーデータと重複チェックする
                        if (string.IsNullOrEmpty(recBgnGrpRet.InqOriginalEpCd) &&
                            string.IsNullOrEmpty(recBgnGrpRet.InqOriginalSecCd))
                        {
                            // 提供データの場合
                            bool flg = false;
                            foreach (RecBgnGrpRet recBgnGrpRet2 in recBgnGrpRetArray)
                            {
                                if (string.IsNullOrEmpty(recBgnGrpRet2.InqOriginalEpCd) &&
                                    string.IsNullOrEmpty(recBgnGrpRet2.InqOriginalSecCd))
                                {
                                    // 提供データ同士はチェックしない
                                    continue;
                                }

                                if (recBgnGrpRet.BrgnGoodsGrpCode == recBgnGrpRet2.BrgnGoodsGrpCode)
                                {
                                    // 提供データとユーザーデータが同一の場合
                                    flg = true;
                                    break;
                                }
                            }

                            if (flg) continue;
                        }
                    }
                    // --- ADD 2015/03/19 Y.Wakita ----------<<<<<

                    dataRow = this.RecBgnGrpRetToDataRow(recBgnGrpRet, dataRow);
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
        /// お買得商品グループ検索処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : お買得商品グループの検索処理を行います。(デリゲートより非同期実行します)</br>
        /// <br>Programmer : 20073　西 毅</br>
        /// <br>Date       : 2005.05.24</br>
        /// </remarks>
        private int SearchRecBgnGrpData()
        {
            RecBgnGrpAcs recBgnGrpAcs = new RecBgnGrpAcs();
            RecBgnGrpPara para = new RecBgnGrpPara();
            RecBgnGrpRet[] retArray;
            int status = 0;

            // パラメータを生成
            //para = this._extractionConditionInfo;

            // --- DEL 2015/03/05 Kaniwa Redmine#331 ---------->>>>>
            //para.InqOriginalEpCd = _enterpriseCode;
            // --- DEL 2015/03/05 Kaniwa Redmine#331 ----------<<<<<

            //得意先コードが設定されている場合は、得意先ディクショナリから接続先情報を取得する。
            if (this._praCustomerCode > 0)
            {
                foreach (CustomerSearchRet customerSearchRet in _customerCodeList)
                {
                    if (customerSearchRet.LogicalDeleteCode == 0)
                    {
                        if (customerSearchRet.CustomerCode == this._praCustomerCode)
                        {
                            para.InqOriginalEpCd = customerSearchRet.CustomerEpCode;
                            para.InqOriginalSecCd = customerSearchRet.CustomerSecCode;
                        }
                    }
                }
            }

            //------ UPD 2015/03/11 小栗 ----->>>>>>
            //if (this._guideType == GUIDETYPE_READONLY) 
            if ((this._guideType == GUIDETYPE_READONLY) & (para.InqOriginalEpCd.Trim() == string.Empty))
            //------ UPD 2015/03/11 小栗 -----<<<<<<
            {
                // 検索処理実行
                //------ UPD 2015/03/06 小栗 ----->>>>>>
                //status = recBgnGrpAcs.Search(out retArray, para);
                status = recBgnGrpAcs.Search(out retArray, _enterpriseCode);
                //------ UPD 2015/03/06 小栗 -----<<<<<<
            }
            else
            {
                // 検索処理実行
                //------ UPD 2015/03/06 小栗 ----->>>>>>
                //status = recBgnGrpAcs.Search(out retArray, new RecBgnGrpPara());
                status = recBgnGrpAcs.Search(out retArray, para);
                //------ UPD 2015/03/06 小栗 -----<<<<<<
            }

            // お買得商品グループ検索結果配列→画面格納処理
            this.SetDisplayFormSearchRetArray(retArray);

            return status;
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
			//this._extractConditionList.Clear();
            //this._extractionConditionInfo = new CustomerSimpleSearchCndtn();

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
            RecBgnGrpRet recBgnGrpRet;
            int stauts = this.GetSelectInfo(out recBgnGrpRet);

			if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                if (this.RecBgnGrpSelect != null)
				{
                    this.RecBgnGrpSelect(this, recBgnGrpRet);
                    this.DialogResult = DialogResult.OK;
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
			_fs = new FileStream( "PMREC09030U.Log", FileMode.Append, FileAccess.Write, FileShare.Write );
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
		private void PMREC09030UA_Load(object sender, System.EventArgs e)
		{
            // Skin設定
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            
            // 画面初期化処理
			this.InitialSetting();

			// ツールバーボタン有効無効設定処理
			this.ToolBarButtonEnabledSetting();

			this.Initial_Timer.Enabled = true;
            if (this._customerCodeList.Count == 0)
            {
                // 得意先情報読込処理
                this.ReadCustomerSearchRet();
            }

            // 通常モードは得意先コード未入力
            if (this._guideType==GUIDETYPE_NORMAL)
            {
                // --- ADD 2015/03/09 Y.Wakita ---------->>>>>
                tNedit_CustomerCodeAllowZero.Enabled = false;
                uButton_CustomerGuide.Enabled = false;
                // --- ADD 2015/03/09 Y.Wakita ----------<<<<<
                
                if (this._customerCode != 0)
                {
                    tNedit_CustomerCodeAllowZero.Text = this._customerCode.ToString().PadLeft(8, '0');
                    //tNedit_CustomerCodeAllowZero.Enabled = false;   // --- DEL 2015/03/09 Y.Wakita

                    //------ ADD 2015/03/06 鹿庭 ----->>>>>>
                    //uButton_CustomerGuide.Enabled = false;    // --- DEL 2015/03/09 Y.Wakita
                    this.CustomerCheck(this._customerCode);
                    //------ ADD 2015/03/06 鹿庭 -----<<<<<<
                }
            }

            //if (this._customerCode != 0)
            //{
            //    tNedit_CustomerCodeAllowZero.Enabled = false;
            //}
        }

        /// <summary>
        /// 得意先情報読込処理
        /// </summary>
        private void ReadCustomerSearchRet()
        {
            //this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            //ArrayList _customerCodeList = new ArrayList();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            _customerCodeList.Add(ret);

                        }
                    }
                }
            }
            catch
            {
                //this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
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

			// お買得商品グループ検索処理
            this.SearchRecBgnGrpData();

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
		private void PMREC09030UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

            //------ ADD 2015/03/11 小栗 ----->>>>>>
            if (tNedit_CustomerCodeAllowZero.Enabled == false)
            {
                if (!e.Shift)
                {
                    if (e.KeyCode == Keys.Return)
                    {
                                Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Select_ButtonTool"];

                                if (selectButton.SharedProps.Visible)
                                {
                                    // 選択ボタンクリック処理
                                    this.SelectButtonClick();
                                }
                    }
                }
            }
            //------ ADD 2015/03/11 小栗 -----<<<<<<
            
           
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
                            break;
                        }
                    case Keys.Up:
                        {
                            if (this.SearchResult_UGrid.ActiveRow != null)
                            {
                                if (this.SearchResult_UGrid.ActiveRow.Selected && this.SearchResult_UGrid.ActiveRow.Index == 0)
                                {
                                    if (e.KeyCode == Keys.Up)
                                    {
                                        //------ ADD 2015/03/11 小栗 ----->>>>>>
                                        //if (this.GridKeyUpTopRow != null)
                                        if ((this.GridKeyUpTopRow != null) & (tNedit_CustomerCodeAllowZero.Enabled == true))
                                        //------ ADD 2015/03/11 小栗 -----<<<<<<
                                        {
                                            this.GridKeyUpTopRow(this, new EventArgs());
                                            this.SearchResult_UGrid.ActiveRow.Selected = false;
                                            this.SearchResult_UGrid.ActiveRow = null;
                                            e.Handled = true;
                                        }
                                    }
                                }
                            }
                            if (this.SearchResult_UGrid.ActiveCell == null)
                            {
                                return;
                            }
                            //if (this.GridKeyUpTopRow != null)
                            //{
                            //    this.GridKeyUpTopRow(this, new EventArgs());
                            //    e.Handled = true;
                            //}
                            break;
                        }
                    // -------------------- ADD 2011/08/11 --------------->>>>>
                    case Keys.F3:
                        {
                            this.ActiveControl = this.tNedit_CustomerCodeAllowZero;
                            this.tNedit_CustomerCodeAllowZero.Focus();
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
            //MessageBox.Show("SearchResult_UGrid_MouseEnterElement");
            /*
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
             */ 
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
		private void PMREC09030UA_Shown(object sender, EventArgs e)
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
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            try
            {
                switch (e.PrevCtrl.Name)
                {
                    // 開始コード ============================================ //
                    case "tNedit_CustomerCodeAllowZero":
                        {
                            int tempCode = _praCustomerCode;
                            if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() != string.Empty)
                            {
                                _praCustomerCode = Convert.ToInt32(this.tNedit_CustomerCodeAllowZero.DataText.Trim());
                                if (_praCustomerCode == 0)
                                {
                                    this.tNedit_CustomerCodeAllowZero.DataText = string.Empty;
                                    _praCustomerCode = -1;
                                }
                            }
                            //------ UPD 2015/03/11 小栗 ----->>>>>>
                            else
                            {
                              _praCustomerCode = -1;
                            }
                            //------ UPD 2015/03/11 小栗 -----<<<<<<

                            if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()) == false)
                            {
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }

                            if (tempCode != _praCustomerCode)
                            {
                                this.Search();
                            }
                            break;
                        }
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
                            if (e.Key == Keys.Up)
                            {

                            }
                            break;
                        }
                }

                /*
                // メモリ上の内容と比較する
                ArrayList arRetList = extractionConditionInfoBuff.Compare(this._extractionConditionInfo);

                if (arRetList.Count > 0)
                {
                    this._extractionConditionInfo = extractionConditionInfoBuff.Clone();

                    this.Search();
                }
                 */ 
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
        private void PMREC09030UA_KeyDown(object sender, KeyEventArgs e)
        {
            // ESCキー押下による画面閉じる処理
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            //F5キー押下
            if (e.KeyCode == Keys.F5)
            {
                this.Cursor = Cursors.WaitCursor;
                this._cusotmerGuideSelected = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // フォーカス設定
                if (this._cusotmerGuideSelected == true)
                {
                    if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()))
                    {
                        //tEdit_BlGoodsCodeSt.Focus();
                        this.Search();
                        this.SearchResult_UGrid.Focus();
                    }
                }
            }
            //F6キー押下
            if (e.KeyCode == Keys.F6)
            {

                //得意先コード
                int tempCode = _praCustomerCode;
                if (this.tNedit_CustomerCodeAllowZero.DataText.Trim() != string.Empty)
                {
                    _praCustomerCode = Convert.ToInt32(this.tNedit_CustomerCodeAllowZero.DataText.Trim());
                    if (_praCustomerCode == 0)
                    {
                        this.tNedit_CustomerCodeAllowZero.DataText = string.Empty;
                        _praCustomerCode = -1;
                    }
                    else
                        this.tNedit_CustomerCodeAllowZero.DataText = GetInputCode(tNedit_CustomerCodeAllowZero);
                }
                else
                {
                    _praCustomerCode = -1;
                }

                this.Search();
                this.SearchResult_UGrid.Focus();
            }
        }

        /// <summary>
        /// 得意先ガイドボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタン</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        /// <summary>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // フォーカス設定
                if (this._cusotmerGuideSelected == true)
                {
                    if (this.CustomerCheck(this.tNedit_CustomerCodeAllowZero.GetInt()))
                    {
                        //tEdit_BlGoodsCodeSt.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先チェック処理
        /// </summary>
        public bool CustomerCheck(int customerCode)
        {
            string errMsg;
            CustomerSearchRet retCustomerInfo;

            bool checkResult = this.CheckCustomer(customerCode, out errMsg, out retCustomerInfo);
            if (checkResult)
            {
                //得意先クリア
                this.tNedit_CustomerCodeAllowZero.Clear();
                this.uLabel_CustomerName.Text = "";

                //this._prevCusotmerCd = 0;
                if (customerCode == 0)
                {
                    this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //得意先コード
                    this.uLabel_CustomerName.Text = "全得意先"; //得意先略称
                }
                else if (retCustomerInfo != null)
                {
                    //this._prevCusotmerCd = customerCode;
                    this.tNedit_CustomerCodeAllowZero.SetInt(customerCode);      //得意先コード
                    this.uLabel_CustomerName.Text = retCustomerInfo.Snm; //得意先略称
                }
            }
            else
            {
                TMsgDisp.Show(this
                             , emErrorLevel.ERR_LEVEL_EXCLAMATION
                             , this.Name
                             , errMsg
                             , 0
                             , MessageBoxButtons.OK);

                //this.tNedit_CustomerCodeAllowZero.SetInt(this._prevCusotmerCd);
            }
            return checkResult;
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 得意先コード
            this.tNedit_CustomerCodeAllowZero.SetInt(customerSearchRet.CustomerCode);

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// 得意先チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="chkFlg">必須チェック区分(ture:有,false:無)</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckCustomer(int customerCode, out string errMsg, out CustomerSearchRet retCustomerInfo)
        {
            retCustomerInfo = null;

            bool bRet = true;
            errMsg = string.Empty;

            if (customerCode == 0)
            {
                return true;
            }
            else
            {
                if (GetCustomerInfo(customerCode, out retCustomerInfo) == false )
                {
                    bRet = false;
                    errMsg = "得意先が存在しません。";
                }
                else
                {
                    if (retCustomerInfo.OnlineKindDiv == 0       //オンライン種別区分
                     || retCustomerInfo.CustomerEpCode == null   //得意先企業コード
                     || retCustomerInfo.CustomerSecCode == null) //得意先拠点コード
                    {
                        // SCM企業連結データ該当チェック
                        bRet = false;
                        errMsg = "連携している得意先ではありません。";
                    }
                    else 
                    {
                        /*
                        foreach (ScmEpScCnt wk in this._scmEpScCntList)
                        {
                            if (!wk.LogicalDeleteCode.Equals(0)) continue;                              // 論理削除：有効以外
                            if (wk.DiscDivCd.Equals(1)) continue;                                       // 連結無効
                            if (wk.ScmCommMethod.Equals(0) && wk.PccUoeCommMethod.Equals(0)) continue;  // 通信方式が無効

                            // オンライン種別区分、得意先企業コード、得意先拠点コードの判定
                            if (retCustomerInfo.OnlineKindDiv == 10  // 10:SCM
                               && retCustomerInfo.CustomerEpCode.Trim().Equals(wk.CnectOriginalEpCd.Trim())
                               && retCustomerInfo.CustomerSecCode.Trim().Equals(wk.CnectOriginalSecCd.Trim())
                                 )
                            {
                         */
                                bRet = true;
//                                break;
                            //}
//                        }
                    }
                }
            }
            return bRet;
        }

        /// <summary>
        /// 得意先情報取得処理（得意先コード入力パラ）
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool GetCustomerInfo(int customerCode, out CustomerSearchRet retCustomerInfo)
        {
            retCustomerInfo = null;
            foreach (CustomerSearchRet customerSearchRet in _customerCodeList)
            {
                if (customerSearchRet.LogicalDeleteCode == 0)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        retCustomerInfo = customerSearchRet;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 詳細グリッド最上位行アプイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 詳細グリッド最上位行アプウン時に発生します。</br>      
        /// <br>Programmer : 宮本利明</br>                                  
        /// <br>Date       : 2015/01/20</br> 
        /// </remarks> 
        private void GriedDetail_GridKeyUpTopRow(object sender, EventArgs e)
        {
            tNedit_CustomerCodeAllowZero.Focus();
            //e._prevControl = this.ActiveControl;
        }
    }
}
