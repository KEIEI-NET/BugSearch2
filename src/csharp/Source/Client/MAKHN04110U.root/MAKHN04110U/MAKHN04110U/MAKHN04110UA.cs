using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品検索クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品の検索を行います。</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2007.01.09</br>
    /// <br>UpdateNote : 2008.02.27 30167　上野　弘貴</br>
    /// <br>           : ガイド起動制御（EXE起動：ｻｰﾊﾞｰ, ｴﾝﾄﾘｰ起動：ﾛｰｶﾙ）</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.06.18 20056 對馬 大輔</br>
    /// <br>           : PM.NS対応(コメント無し)</br>
    /// <br>UpdateNote : 2008.09.02 30452 上野 俊治</br>
    /// <br>           : 論理削除の表示制御追加</br>
    /// <br>           : 論理削除ボタンの追加</br>
    /// <br>UpdateNote : 2009/01/06 30414 忍 幸史</br>
    /// <br>           : 障害ID:6079対応</br>
    /// <br>UpdateNote : 2009/01/09 30414 忍 幸史</br>
    /// <br>           : 障害ID:9891対応</br>
    /// <br>UpdateNote : 2009.02.13 20056 對馬 大輔</br>
    /// <br>           : 商品検索速度アップ対応</br>
    /// <br>UpdateNote : 2009.02.18 20056 對馬 大輔</br>
    /// <br>           : 商品アクセスクラス共有化</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/13 30517 夏野 駿希</br>
    /// <br>           : 抽出条件・抽出結果データグリッドから品名カナを削除</br>
    /// <br>UpdateNote : 2011/12/08 丁建雄</br>
    /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
    /// <br>           : Redmine#26676 商品検索/検索モードの設定</br>
    /// <br>UpdateNote : 2012/02/15 yangmj</br>
    /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
    /// <br>           : Redmine#26676 商品検索/検索モードの設定</br>
    /// <br>Update Note: 2012/02/28 鄧潘ハン</br>
    /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
    /// <br>             Redmine#26676 検索タイプ不具合についての対応</br>
    /// <br>Update Note: 2012/12/01 zhangy3</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine #33231商品在庫マスタの仕様変更</br>
    /// <br>Update Note: 2013/02/08 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/26配信分</br>
    /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
    /// <br>Update Note: 2013/04/01 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
    /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
    /// <br>Update Note: 2013/05/02 王君</br>
    /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
    /// <br>           : Redmine#35434 古い商品在庫マスタの復活</br>
    /// </remarks>
    public partial class MAKHN04110UA : Form
    {
        //================================================================================
        //  コンストラクタ
        //================================================================================
        #region Constructor
        // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>
        /// 商品検索クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品検索クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434 古い商品在庫マスタの復活</br>
        /// </remarks>
        public MAKHN04110UA(int mode)
        {
            InitializeComponent();

            this._mode = mode;  
            //-----------------------------------------------------------------------------
            // 各種オブジェクトインスタンス生成
            //-----------------------------------------------------------------------------
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = false;

            //-----------------------------------------------------------------------------
            // 商品登録変更イベントの登録
            //-----------------------------------------------------------------------------
            this._goodsAcs.AddChangedGoodsDataEvent(new ChangedGoodsDataEventHandler(ChangedGoodsDataEvent));

            //-----------------------------------------------------------------------------
            // 値の初期化
            //-----------------------------------------------------------------------------
            this._imageList16 = IconResourceManagement.ImageList16;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
            }
            this._resultDataSet = new DataSet();
            this._resultDataView = new DataView();
            this._uiDataSet = new DataSet(); 

            //-----------------------------------------------------------------------------
            // 抽出条件関連
            //-----------------------------------------------------------------------------
            this._extractConditionItemControlDictionary = new Dictionary<string, Panel>();
            this._goodsCndtn = new GoodsCndtn();
            this._extractConditionList = new Stack<GoodsCndtn>();
            this._ultraTreeDrawFilter = new UltraTree_DropHightLight_DrawFilter_Class();
            this._ultraTreeDrawFilter.Invalidate += new EventHandler(this.UltraTree_DropHightLight_DrawFilter_Invalidate);
            this._ultraTreeDrawFilter.QueryStateAllowedForNode += new UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventHandler(this.UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode);

            // 起動モード制御
            _callMode = (int)emGoodsCallMode.MenuStartMode;
            _isMultiSelect = false;
            if (this._mode == 0) 
            {
                _acs = new GoodsStockInputConstructionAcs();
                if (_acs.KeepOnInfo[5] > 0)
                {
                    string ctPROCNM = "Initial_timer_Tick";
                    string msg;
                    // ガイド読み込み振り分け
                    if (this._callMode == (int)emGoodsCallMode.GuideMode)
                    {
                        // ガイドモード時はローカル読み込み固定
                        this._goodsAcs.IsLocalDBRead = true;
                    }
                    else
                    {
                        // メニューモード時はサーバー読み込み固定
                        this._goodsAcs.IsLocalDBRead = false;
                    }
                    // 初期値データ取得
                    int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
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
                                this.MsgDisp(msg, status, ctPROCNM);
                                break;
                            }
                    }
                }
            }
            else
            {
                _acs1 = new GoodsStockInputConstructionAcs1();
                if (_acs1.KeepOnInfo[5] > 0)
                {
                    string ctPROCNM = "Initial_timer_Tick";
                    string msg;
                    // ガイド読み込み振り分け
                    if (this._callMode == (int)emGoodsCallMode.GuideMode)
                    {
                        // ガイドモード時はローカル読み込み固定
                        this._goodsAcs.IsLocalDBRead = true;
                    }
                    else
                    {
                        // メニューモード時はサーバー読み込み固定
                        this._goodsAcs.IsLocalDBRead = false;
                    }
                    // 初期値データ取得
                    int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
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
                                this.MsgDisp(msg, status, ctPROCNM);
                                break;
                            }
                    }
                }
            }
        }
        // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
        #endregion

        #region Constructor
        /// <summary>
        /// 商品検索クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品検索クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.1.9</br>
        /// </remarks>
        public MAKHN04110UA() 
        {
            InitializeComponent();

            //-----------------------------------------------------------------------------
            // 各種オブジェクトインスタンス生成
            //-----------------------------------------------------------------------------
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = false;

            //-----------------------------------------------------------------------------
            // 商品登録変更イベントの登録
            //-----------------------------------------------------------------------------
            this._goodsAcs.AddChangedGoodsDataEvent(new ChangedGoodsDataEventHandler(ChangedGoodsDataEvent));

            //-----------------------------------------------------------------------------
            // 値の初期化
            //-----------------------------------------------------------------------------
            this._imageList16 = IconResourceManagement.ImageList16;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
            }
            this._resultDataSet = new DataSet();
            this._resultDataView = new DataView();
            this._uiDataSet = new DataSet();    //  ADD dingjx 2011/12/08 redmine#26676

            //-----------------------------------------------------------------------------
            // 抽出条件関連
            //-----------------------------------------------------------------------------
            this._extractConditionItemControlDictionary = new Dictionary<string, Panel>();
            this._goodsCndtn = new GoodsCndtn();
            this._extractConditionList = new Stack<GoodsCndtn>();
            this._ultraTreeDrawFilter = new UltraTree_DropHightLight_DrawFilter_Class();
            this._ultraTreeDrawFilter.Invalidate += new EventHandler(this.UltraTree_DropHightLight_DrawFilter_Invalidate);
            this._ultraTreeDrawFilter.QueryStateAllowedForNode += new UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventHandler(this.UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
            // 起動モード制御
            _callMode = (int)emGoodsCallMode.MenuStartMode;
            _isMultiSelect = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
            //Add Start 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
            _acs = new GoodsStockInputConstructionAcs();
            if (_acs.KeepOnInfo[5] > 0)
            {
                string ctPROCNM = "Initial_timer_Tick";
                string msg;
                // ガイド読み込み振り分け
                if (this._callMode == (int)emGoodsCallMode.GuideMode)
                {
                    // ガイドモード時はローカル読み込み固定
                    this._goodsAcs.IsLocalDBRead = true;
                }
                else
                {
                    // メニューモード時はサーバー読み込み固定
                    this._goodsAcs.IsLocalDBRead = false;
                }
                // 初期値データ取得
                int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
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
                            this.MsgDisp(msg, status, ctPROCNM);
                            break;
                        }
                }
            }
            //Add End   2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
        }
        #endregion

        //================================================================================
        //  内部メンバー
        //================================================================================
        #region Private Members

        // -------------------------------------------------------------------------------
        #region < 各種オブジェクト >

        /// <summary>商品入力アクセスクラス</summary>
        GoodsAcs _goodsAcs;

        /// <summary>商品入力画面クラス</summary>
        MAKHN09280UA _goodsInputForm;

        // ------ ADD 王君 2013/05/02 Redmine#35434 ------>>>>>
        /// <summary>商品在庫マスタⅡ</summary>
        PMKHN09380UA _goodsInputForm2;
        // ------ ADD 王君 2013/05/02 Redmine#35434 ------<<<<<

        /// <summary>複数商品選択画面クラス</summary>
        MAKHN04110UB _goodsSelForm;

        /// <summary>選択結果クラス</summary>
        GoodsUnitData _selGoodsUnitData;

        /// <summary>選択結果クラスリスト</summary>
        List<GoodsUnitData> _selGoodsUnitDataLst;

        /// <summary></summary>
        Employee _loginEmployee;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        private Dictionary<string, Control> _nextControlDic;
        private List<string> _nextControlList;
        private bool _inputClearCheck;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
        private GoodsStockInputConstructionAcs _acs;//Add 2012/12/01 zhangy3 for Redmine#33231

        private GoodsStockInputConstructionAcs1 _acs1; // ADD 王君 2013/05/02 Redmine#35434
        #endregion

        // -------------------------------------------------------------------------------
        #region < 各種フラグ >

        /// <summary>起動モード</summary>
        private int _callMode;

        /// <summary>起動カウンター</summary>
        private int _initialCount = 0;

        /// <summary>抽出属性指定検索モード</summary>
        private bool _isSpecifyConditionSearch = false;

        /// <summary>自動検索有無</summary>
        private bool _isAutoSearch = false;

        /// <summary>複数選択</summary>
        private bool _isMultiSelect = false;

        /// <summary>リサイズ有無</summary>
        private bool _isReSizeForm = false;

        //----- ADD 2013/04/01 田建委 Redmine#34640 ---------->>>>>
        /// <summary>検索ボタン押下フラグ</summary>
        private bool _searchButtonFlg = true;
        //----- ADD 2013/04/01 田建委 Redmine#34640 ----------<<<<<
        // ------ ADD 王君 2013/05/02 Redmine#35434 ------->>>>>
        /// <summary>1.商品在庫マスタ　2.商品在庫マスタⅡ</summary>
        private int _mode;　// 起動モード
        // ------ ADD 王君 2013/05/02 Redmine#35434-----<<<<<
        #endregion

        // -------------------------------------------------------------------------------
        #region < 画面表示用 >
        /// <summary>16x16サイズイメージリスト</summary>
        private ImageList _imageList16 = null;

        /// <summary>初期化中かどうか(true:初期化中, false:初期化終了)</summary>
        private bool _isInitializing = false;

        /// <summary>列表示状態コレクションクラス</summary>
        private GoodsInputColDisplayStatusCollection _colDisplayStatusCollection = null;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private delegate void settingHandler(int row);

        /// <summary>デフォルト行の外観設定</summary>
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        /// <summary>選択時の行外観設定</summary>
        private readonly Color _selBackColor = Color.FromArgb(251, 230, 148);
        private readonly Color _selBackColor2 = Color.FromArgb(238, 149, 21);
        private readonly Infragistics.Win.GradientStyle _selBackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

        #endregion

        // -------------------------------------------------------------------------------
        #region < 検索結果用 >
        /// <summary>抽出結果・商品入力DataSet</summary>
        private DataSet _resultDataSet = null;

        /// <summary>抽出結果・商品入力DataTable</summary>
        private DataTable _resultDataTable;

        /// <summary>抽出結果・商品入力DataView</summary>
        private DataView _resultDataView = null;

        // --- ADD dingjx 2011/12/08 redmine#26676 -------------------------------->>>>>
        /// <summary>前次選択の品番検索条件用DataSet</summary>
        private DataSet _uiDataSet = null;
        private string _preGoodsNo = string.Empty;
        // --- ADD dingjx 2011/12/08 redmine#26676 --------------------------------<<<<<
        // --- ADD YANGMJ 2012/02/15 REDMINE#26676 -------------------------------->>>>>
        private string _preMakerCode = string.Empty;
        private string _preGoodsName = string.Empty;
        private string _preGoodsLGroup = string.Empty;
        private string _preGoodsMGroup = string.Empty;
        private string _preBLGroupCode = string.Empty;
        // --- ADD YANGMJ 2012/02/15 redmine#26676 --------------------------------<<<<<

        /// <summary>商品表示順位</summary>
        /// <summary>メーカー　品番</summary>
        private string CT_Default_GoodsOdr = CT_MakerCode + " , " + CT_GoodsNo;
        #endregion

        // -------------------------------------------------------------------------------
        #region < 抽出条件用 >
        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>自拠点コード</summary>
        private string _loginSectionCode = "";

        /// <summary>商品入力抽出条件クラス</summary>
        private GoodsCndtn _goodsCndtn = null;

        /// <summary>抽出条件設定コレクション</summary>
        private GoodsExtractConditionItems _extractConditionItems = null;

        /// <summary>抽出条件履歴リスト</summary>
        private Stack<GoodsCndtn> _extractConditionList = null;

        /// <summary>抽出条件アイテムPanel格納Dictionary</summary>
        private Dictionary<string, Panel> _extractConditionItemControlDictionary = null;

        /// <summary>DropHighlight／DropLinesを描くためのDrawFilterクラス</summary>
        private UltraTree_DropHightLight_DrawFilter_Class _ultraTreeDrawFilter = null;

        #endregion

        #endregion

        //================================================================================
        //  列挙型
        //================================================================================
        #region Private Enum

        /// <summary>起動モード</summary>
        private enum emGoodsCallMode : int
        {
            MenuStartMode = 0,
            GuideMode = 1
        }

        #endregion

        //================================================================================
        //  定数定義
        //================================================================================
        #region Constant

        // -------------------------------------------------------------------------------
        #region < グリッド列用 >
        /// <summary>抽出結果・入庫入力テーブル</summary>
        private const string CT_TBL_RESULT_TITLE = "ResultTable";

        /// <summary>選択状態</summary>
        public const string CT_Select = "Select";

        /// <summary>メーカーコード</summary>
        public const string CT_MakerCode = "GoodsMakerCd";
        /// <summary>メーカー名称</summary>
        public const string CT_MakerName = "MakerName";
        /// <summary>品番</summary>
        public const string CT_GoodsNo = "GoodsNo";
        /// <summary>品名</summary>
        public const string CT_GoodsName = "GoodsName";
        /// <summary>品名カナ</summary>
        public const string CT_GoodsNameKana = "GoodsNameKana";
        /// <summary>JANコード</summary>
        public const string CT_JAN = "Jan";
        /// <summary>BLコード</summary>
        public const string CT_BLGoodsCode = "BLGoodsCode";
        /// <summary>BLコード名称</summary>
        public const string CT_BLGoodsFullName = "BLGoodsFullName";
        /// <summary>表示順位</summary>
        public const string CT_DisplayOrder = "DisplayOrder";
        /// <summary>大分類コード</summary>
        public const string CT_GoodsLGroup = "GoodsLGroup";
        /// <summary>大分類名称</summary>
        public const string CT_GoodsLGroupName = "GoodsLGroupName";
        /// <summary>中分類コード</summary>
        public const string CT_GoodsMGroup = "GoodsMGroup";
        /// <summary>中分類名称</summary>
        public const string CT_GoodsMGroupName = "GoodsMGroupName";
        /// <summary>BLグループコード</summary>
        public const string CT_BLGroupCode = "BLGroupCode";
        /// <summary>BLグループ名称</summary>
        public const string CT_BLGroupName = "BLGroupName";
        /// <summary>商品掛率ランク</summary>
        public const string CT_GoodsRateRank = "GoodsRateRank";
        /// <summary>ハイフン無品番</summary>
        public const string CT_GoodsNoNoneHyphen = "GoodsNoNoneHyphen";
        /// <summary>提供日付（商品）</summary>
        public const string CT_OfferDate = "OfferDate";
        /// <summary>商品属性</summary>
        public const string CT_GoodsKindCode = "GoodsKindCode";
        /// <summary>商品属性名称</summary>
        public const string CT_GoodsKindName = "GoodsKindName";
        /// <summary>商品備考１</summary>
        public const string CT_GoodsNote1 = "GoodsNote1";
        /// <summary>商品備考２</summary>
        public const string CT_GoodsNote2 = "GoodsNote2";
        /// <summary>商品規格・特記事項</summary>
        public const string CT_GoodsSpecialNote = "GoodsSpecialNote";
        /// <summary>自社分類コード</summary>
        public const string CT_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary>自社分類名称</summary>
        public const string CT_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary>更新年月日（商品）</summary>
        public const string CT_UpdateDate = "UpdateDate";
        /// <summary>価格開始日</summary>
        public const string CT_GoodsPricePriceStartDate = "GoodsPricePriceStartDate";
        /// <summary>標準価格</summary>
        public const string CT_GoodsPriceListPrice = "GoodsPriceListPrice";
        /// <summary>原価単価</summary>
        public const string CT_GoodsPriceSalesUnitCost = "GoodsPriceSalesUnitCost";
        /// <summary>仕入率</summary>
        public const string CT_GoodsPriceStockRate = "GoodsPriceStockRate";
        /// <summary>オープン価格区分</summary>
        public const string CT_GoodsPriceOpenPriceDiv = "GoodsPriceOpenPriceDiv";
        /// <summary>提供日付（価格）</summary>
        public const string CT_GoodsPriceOfferDate = "GoodsPriceOfferDate";
        /// <summary>更新年月日（価格）</summary>
        public const string CT_GoodsPriceUpdateDate = "GoodsPriceUpdateDate";
        /// <summary>倉庫コード</summary>
        public const string CT_WarehouseCode = "WarehouseCode";
        /// <summary>倉庫名称</summary>
        public const string CT_WarehouseName = "WarehouseName";
        /// <summary>出荷可能数</summary>
        public const string CT_ShipmentPosCnt = "ShipmentPosCnt";
        /// <summary>棚番</summary>
        public const string CT_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>商品連結データクラス格納</summary>
        public const string CT_GoodsUitData = "GoodsUitData";
        /// <summary>価格情報データオブジェクトリスト格納</summary>
        public const string CT_GoodsPriceList = "GoodsPriceList";
        /// <summary>該当行のDataRow</summary>
        public const string CT_DataRow = "DataRow";
        // --- ADD 2008/09/02 -------------------------------->>>>>
        /// <summary>削除日</summary>
        public const string CT_LogicalDeleteDate = "LogicalDeleteDate";
        // --- ADD 2008/09/02 --------------------------------<<<<<
        #endregion

        // -------------------------------------------------------------------------------
        #region  < ツールバー >
        /// <summary>ファイル</summary>
        private const string CT_POPUPMENUTOOL_FILE = "File_PopupMenuTool";
        /// <summary>終了</summary>
        private const string CT_BUTTONTOOL_CLOSE = "Close_ButtonTool";
        /// <summary>データ</summary>
        private const string CT_POPUPMENUTOOL_DATA = "Data_PopupMenuTool";
        /// <summary>ツール</summary>
        private const string CT_POPUPMENUTOOL_TOOL = "Tool_PopupMenuTool";
        /// <summary>ログイン担当者タイトル</summary>
        private const string CT_LABELTOOL_LOGINTITLE = "LoginTitle";
        /// <summary>ログイン担当者</summary>
        private const string CT_LABELTOOL_LOGINNAME = "LoginName_LabelTool";
        /// <summary>ダミー</summary>
        private const string CT_LABELTOOL_DUMMY = "Dummy_LabelTool";
        /// <summary>元に戻す</summary>
        private const string CT_BUTTONTOOL_UNDO = "Undo_ButtonTool";
        /// <summary>確定</summary>
        private const string CT_BUTTONTOOL_DECISION = "Decision_ButtonTool";
        /// <summary>新規</summary>
        private const string CT_BUTTONTOOL_NEW = "NewGoods_ButtonTool";
        // --- ADD 2009/01/06 障害ID:6079対応------------------------------------------------------>>>>>
        /// <summary>検索</summary>
        private const string CT_BUTTONTOOL_SEARCH = "Search_ButtonTool";
        // --- ADD 2009/01/06 障害ID:6079対応------------------------------------------------------<<<<<
        /// <summary>編集</summary>
        private const string CT_BUTTONTOOL_EDIT = "Edit_ButtonTool";
        // --- ADD 2008/09/02 -------------------------------->>>>>
        /// <summary>削除</summary>
        private const string CT_BUTTONTOOL_LOGICALDELETE = "LogicalDelete_ButtonTool";
        // --- ADD 2008/09/02 --------------------------------<<<<<
        /// <summary>データ入力</summary>
        private const string CT_BUTTONTOOL_DATAINPUT = "DataInput_ButtonTool";
        /// <summary>データ入力</summary>
        private const string CT_BUTTONTOOL_DATAOUTPUT = "DataOutput_ButtonTool";
        /// <summary>印刷</summary>
        private const string CT_BUTTONTOOL_PRINT = "Print_ButtonTool";
        #endregion

        // -------------------------------------------------------------------------------
        #region < ファイル名 >
        /// <summary>抽出条件セッティングXMLファイル名</summary>
        private const string CT_FILENAME_EXTRACTCONDITION = "MAKHN04110U_ExtractCondition1.XML";
        /// <summary>列表示状態セッティングXMLファイル名</summary>
        private const string CT_FILENAME_COLDISPLAYSTATUS = "MAKHN04110U_ColSetting1.DAT";
        // --- ADD dingjx 2011/12/08 redmine#26676 -------------------------------->>>>>
        /// <summary>前次選択の品番検索条件用XMLファイル</summary>
        private const string CT_FILENAME_GOODSNO = "MAKHN04110U_GoodsNO.XML";
        // --- ADD dingjx 2011/12/08 redmine#26676 --------------------------------<<<<<
        #endregion

        // -------------------------------------------------------------------------------
        #region < エクスプローラーバーグループ >
        /// <summary>抽出条件</summary>
        private const string CT_GROUP_EXTRACTCONDITION = "ExtractCondition";
        /// <summary>抽出条件設定</summary>
        private const string CT_GROUP_EXTRACTCONDITIONSETTING = "ExtractConditionSetting";
        #endregion

        // -------------------------------------------------------------------------------
        #region < UltraTree.Appearance >
        /// <summary>DropHighLightのAppearance</summary>
        private const string CT_APPEARANCE_DROPHIGHLIGHT = "DropHighLightAppearance";
        #endregion

        #endregion

        //================================================================================
        //  外部プロパティ
        //================================================================================
        #region Public Methods
        /// <summary>リサイズ有無</summary>
        /// <remarks>true:メインフォームに合わせてリサイズ false:初期サイズのまま</remarks>
        public bool IsReSizeForm
        {
            set { this._isReSizeForm = value; }
        }
        #endregion

        //================================================================================
        //  外部提供関数
        //================================================================================
        #region Public Methods

        #region < 商品ガイド起動 >

        /// <summary>
        /// 商品ガイド起動
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowGuide(IWin32Window owner, string enterpriseCode, out GoodsUnitData goodsUnitData)
        {

            // 各変数を初期化する
            this._isMultiSelect = false;
            this._selGoodsUnitData = null;
            this._goodsCndtn = new GoodsCndtn();

            goodsUnitData = null;

            this._isAutoSearch = false;
            this._isSpecifyConditionSearch = false;
            this._enterpriseCode = enterpriseCode;

            // 起動モードをガイドモードに設定する
            this._callMode = (int)emGoodsCallMode.GuideMode;

            // リモートアクセスモードにする
            this._goodsAcs.IsLocalDBRead = false;

            // 画面の設定
            this.ShowInTaskbar = false;

            if (this._isReSizeForm)
            {
                Form mainForm = owner as Form;

                if (mainForm == null)
                    mainForm = this.GetMainForm();

                if (mainForm != null)
                {
                    int afterHeight = Convert.ToInt32(mainForm.Height * 0.95);
                    int afterWidth = Convert.ToInt32(mainForm.Width * 0.95);

                    this.Size = new Size(afterWidth, afterHeight);
                }
            }
            DialogResult dr = base.ShowDialog(owner);
            if (dr == DialogResult.OK)
            {
                goodsUnitData = this._selGoodsUnitData.Clone();
                this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            }

            return dr;
        }

        /// <summary>
        /// 商品ガイド起動
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="isAutoSearch"></param>
        /// <param name="condtn"></param>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public DialogResult ShowGuide(IWin32Window owner, bool isAutoSearch, GoodsCndtn condtn, out GoodsUnitData goodsUnitData)
        {
            goodsUnitData = null;

            List<GoodsUnitData> goodsUnitDataList;
            DialogResult dr = this.ShowGuide(owner, false, isAutoSearch, condtn, out goodsUnitDataList);
            if (dr == DialogResult.OK)
            {
                if (goodsUnitDataList != null && goodsUnitDataList.Count == 1)
                {
                    goodsUnitData = goodsUnitDataList[0].Clone();
                    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);
                }
            }

            return dr;
        }

        /// <summary>
        /// 商品ガイド起動
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="isMultiSelect"></param>
        /// <param name="isAutoSearch"></param>
        /// <param name="condtn"></param>
        /// <param name="goodsUnitDataList"></param>
        /// <returns></returns>
        public DialogResult ShowGuide(IWin32Window owner, bool isMultiSelect, bool isAutoSearch, GoodsCndtn condtn, out List<GoodsUnitData> goodsUnitDataList)
        {
            this._isMultiSelect = isMultiSelect;
            this._isAutoSearch = isAutoSearch;
            this._isSpecifyConditionSearch = true;

            this._goodsCndtn = condtn.Clone();
            this._enterpriseCode = this._goodsCndtn.EnterpriseCode;

            // 各変数を初期化する
            goodsUnitDataList = null;
            this._selGoodsUnitDataLst = new List<GoodsUnitData>();

            // 起動モードをガイドモードに設定する
            this._callMode = (int)emGoodsCallMode.GuideMode;

            // リモートアクセスモードにする
            this._goodsAcs.IsLocalDBRead = false;

            // 画面の設定
            this.ShowInTaskbar = false;

            if (this._isReSizeForm)
            {
                Form mainForm = owner as Form;

                if (mainForm == null)
                    mainForm = this.GetMainForm();

                if (mainForm != null)
                {
                    int afterHeight = Convert.ToInt32(mainForm.Height * 0.95);
                    int afterWidth = Convert.ToInt32(mainForm.Width * 0.95);

                    this.Size = new Size(afterWidth, afterHeight);
                }
            }

            DialogResult dr = base.ShowDialog(owner);
            if (dr == DialogResult.OK)
            {
                if (isMultiSelect)
                {
                    if (this._selGoodsUnitDataLst != null)
                    {
                        List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>(this._selGoodsUnitDataLst);
                        goodsUnitDataList = new List<GoodsUnitData>();
                        foreach (GoodsUnitData goodsUnit in retGoodsUnitDataList)
                        {
                            GoodsUnitData gUnitData = new GoodsUnitData();
                            gUnitData = goodsUnit;
                            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref gUnitData);
                            goodsUnitDataList.Add(gUnitData);
                        }
                    }
                }
                else
                {
                    goodsUnitDataList = new List<GoodsUnitData>();
                    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref this._selGoodsUnitData);
                    goodsUnitDataList.Add(this._selGoodsUnitData);
                }
            }

            return dr;
        }

        #region < 商品検索(選択フォームあり) >
        /// <summary>
        /// 商品検索(選択フォームあり)
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="srchTyp">検索タイプ[0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索]</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        public int ReadGoods(IWin32Window owner, string enterpriseCode, int srchTyp, string goodsCode, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            return ReadGoods(owner, false, enterpriseCode, "", srchTyp, goodsCode, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// 商品検索(選択フォームあり)
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="srchTyp">検索タイプ[0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索]</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        public int ReadGoods(IWin32Window owner, string enterpriseCode, string sectionCode, int srchTyp, string goodsCode, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            return ReadGoods(owner, false, enterpriseCode, sectionCode, srchTyp, goodsCode, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// 商品検索(選択フォームあり)
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="isMultiSelect">商品複数選択</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="srchTyp">検索タイプ[0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索]</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        public int ReadGoods(IWin32Window owner, bool isMultiSelect, string enterpriseCode, int srchTyp, string goodsCode, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            return ReadGoods(owner, isMultiSelect, enterpriseCode, "", srchTyp, goodsCode, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// 商品検索(選択フォームあり)
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="isMultiSelect">商品複数選択</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="srchTyp">検索タイプ[0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索]</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        public int ReadGoods(IWin32Window owner, bool isMultiSelect, string enterpriseCode, string sectionCode, int srchTyp, string goodsCode, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = enterpriseCode;
            goodsCndtn.SectionCode = sectionCode;
            goodsCndtn.GoodsNoSrchTyp = srchTyp;
            goodsCndtn.GoodsNo = goodsCode;
            return ReadGoods(owner, isMultiSelect, goodsCndtn, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// 商品検索(選択フォームあり)
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="isMultiSelect">商品複数選択</param>
        /// <param name="cndtn">検索条件</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        public int ReadGoods(IWin32Window owner, bool isMultiSelect, GoodsCndtn goodsCndtn, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";
            goodsUnitDataList = new List<GoodsUnitData>();

            try
            {
                // リモートアクセスモードにする
                this._goodsAcs.IsLocalDBRead = false;

                // 検索条件設定
                GoodsCndtn cndtn = new GoodsCndtn();
                cndtn = goodsCndtn;
                cndtn.GoodsKindCode = 9; // 商品属性すべて対象
                cndtn.IsSettingSupplier = 1; // 2009.02.13

                // --- DEL 2008/09/02 -------------------------------->>>>>
                //status = this._goodsAcs.Search(cndtn, ConstantManagement.LogicalMode.GetData0, out goodsUnitDataList, out msg);
                // --- DEL 2008/09/02 --------------------------------<<<<< 

                // --- ADD 2008/09/02 -------------------------------->>>>>
                // 論理削除フラグ1(論理削除済)も取得するよう修正
                status = this._goodsAcs.Search(cndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out msg);
                // --- ADD 2008/09/02 --------------------------------<<<<< 

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                msg = "該当の商品はありません";
                                break;
                            }

                            if (goodsUnitDataList.Count > 1)
                            {
                                // 複数商品選択ガイドを起動する
                                if (this._goodsSelForm == null)
                                    this._goodsSelForm = new MAKHN04110UB();

                                this._goodsSelForm.IsMultiSelect = isMultiSelect;
                                DialogResult dr = this._goodsSelForm.SelectGoodsGuideShow(owner, ref goodsUnitDataList);
                                if (dr == DialogResult.OK)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else
                                {
                                    status = -1;
                                }
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        msg = "該当の商品はありません";
                        break;
                    default:
                        msg = "商品の取得でエラーが発生しました";
                        break;
                }

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "商品の取得にて例外が発生しました[" + ex.Message + "]";
            }

            return status;
        }

        #endregion

        #endregion

        #endregion

        //================================================================================
        //  内部関数
        //================================================================================
        #region Private Methods

        // --------------------------------------------------
        #region < 画面表示設定等 >

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.18</br>
        /// <br>Update Note: 2012/02/28 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#26676 検索タイプ不具合についての対応</br>
        /// </remarks>
        private void Initialize()
        {
            if (this._resultDataTable != null)
                this._resultDataTable.Rows.Clear();

            if (this._extractConditionList != null)
                this._extractConditionList.Clear();

            // 戻るボタン設定処理
            this.UndoButtonSetting();

            // 指定抽出条件検索モードでない場合
            if (!this._isSpecifyConditionSearch)
            {

                // 初期抽出条件設定処理
                this._goodsCndtn = new GoodsCndtn();
                this._goodsCndtn.EnterpriseCode = this._enterpriseCode;
                this._goodsCndtn.GoodsNoSrchTyp = 0;
                this._goodsCndtn.GoodsNameKanaSrchTyp = 0;

                // 画面情報を初期化する
                // ----------------------------------------
                // チェックボックスのイベントを解除
                this.GoodsKindCode_True_ultraCheckEditor.AfterCheckStateChanged -= new CheckEditor.AfterCheckStateChangedHandler(this.GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged);
                this.GoodsKindCode_False_ultraCheckEditor.AfterCheckStateChanged -= new CheckEditor.AfterCheckStateChangedHandler(this.GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged);

                // ----------------------------------------
                // オプションセットのイベント解除
                this.GoodsCodeSearchType_ultraOptionSet.ValueChanged -= new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);
                this.GoodsNameSearchType_ultraOptionSet.ValueChanged -= new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);
                //this.GoodsNameKanaSearchType_ultraOptionSet.ValueChanged -= new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);  // 2010/07/13 Del

                // ----------------------------------------
                // メーカー
                this.MakerCode_ULabel.Text = "";
                this.MakerName_tEdit.Clear();

                // ----------------------------------------
                // 商品大分類
                this.GoodsLGroup_ULabel.Text = "";
                this.GoodsLGroupName_tEdit.Clear();

                // ----------------------------------------
                // 商品中分類
                this.GoodsMGroup_ULabel.Text = "";
                this.GoodsMGroupName_tEdit.Clear();

                // ----------------------------------------
                // BLグループコード
                this.BLGroupCode_ULabel.Text = "";
                this.BLGroupName_tEdit.Clear();

                // ----------------------------------------
                // 品番
                this.GoodsNo_tEdit.Clear();
                //this.GoodsCodeSearchType_ultraOptionSet.CheckedIndex = 0; // DEL 鄧潘ハン 2012/02/28 Redmine#26676
                this.GoodsCodeSearchType_ultraOptionSet.CheckedIndex = this.GetGoodsNo(); //ADD 鄧潘ハン 2012/02/28 Redmine#26676

                // ----------------------------------------
                // 品名
                this.GoodsName_tEdit.Clear();
                this.GoodsNameSearchType_ultraOptionSet.CheckedIndex = 0;

                // ----------------------------------------
                // 品名カナ
                // 2010/07/13 Del >>>
                //this.GoodsNameKana_tEdit.Clear();
                //this.GoodsNameKanaSearchType_ultraOptionSet.CheckedIndex = 0;
                // 2010/07/13 Del <<<

                // ----------------------------------------
                // 商品属性検索区分
                this.GoodsKindCode_True_ultraCheckEditor.Checked = true;
                this.GoodsKindCode_False_ultraCheckEditor.Checked = true;

                // ----------------------------------------
                // オプションセットのイベントを再登録
                this.GoodsCodeSearchType_ultraOptionSet.ValueChanged += new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);
                this.GoodsNameSearchType_ultraOptionSet.ValueChanged += new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);
                //this.GoodsNameKanaSearchType_ultraOptionSet.ValueChanged += new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);  // 2010/07/13 Del

                // ----------------------------------------
                // チェックボックスのイベントを再登録
                this.GoodsKindCode_True_ultraCheckEditor.AfterCheckStateChanged += new CheckEditor.AfterCheckStateChangedHandler(this.GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged);
                this.GoodsKindCode_False_ultraCheckEditor.AfterCheckStateChanged += new CheckEditor.AfterCheckStateChangedHandler(this.GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged);

            }
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.10</br>
        /// <br>UpdateNote : 2011/12/08 丁建雄</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
        /// <br>           : Redmine#26676 商品検索/検索モードの設定</br>
        /// </remarks>
        private void InitializeDisplaySetting()
        {
            const string ctPROCNM = "InitializeDisplaySetting";

            try
            {
                // 初期化開始
                this._isInitializing = true;

                this._goodsCndtn.IsSettingSupplier = 1; // 2009.02.13

                // 初期抽出条件設定処理
                if (!this._isSpecifyConditionSearch)
                {
                    this._goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    this._goodsCndtn.GoodsNoSrchTyp = 0;
                    this._goodsCndtn.GoodsNameKanaSrchTyp = 0;
                }

                if (this._initialCount == 0)
                {

                    // 抽出条件コントロール初期設定処理
                    this.InitializeExtractConditionControlsSetting();

                    // 抽出条件エクスプローラーバー初期設定処理
                    this.InitializeExplorerBarSetting();

                    // ツールバー初期設定処理
                    this.InitializeToolbarsSetting();

                    // 戻るボタン設定処理
                    this.UndoButtonSetting();

                    // ステータスバー初期設定処理
                    this.InitializeStatusBarSetting();

                    // 抽出条件初期設定処理
                    this.InitializeExtractCondition();

                    // --- ADD dingjx 2011/12/08 redmine#26676 -------------------------------->>>>>
                    this.GoodsCodeSearchType_ultraOptionSet.CheckedIndex = this.GetGoodsNo();
                    // --- ADD dingjx 2011/12/08 redmine#26676 --------------------------------<<<<<

                    // 抽出結果・商品入力DataTable設定処理
                    this.ResultDataTableConstruction();

                    // UltraGridにデータをバインド
                    this.Result_ultraGrid.DataSource = this._resultDataView;

                    // グリッドキーマッピング作成
                    this.MakeGridKeyMapping(this.Result_ultraGrid);

                    //// 抽出結果・商品入力グリッドカラム情報設定処理
                    //this.SettingResultGridColumns(this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns, this.Result_ultraGrid);

                    // ラベルヘッダ外観設定
                    Broadleaf.Application.Common.CustomUltraGridAppearance cga = this._controlScreenSkin.GetGridAppearance();
                    if (cga != null)
                    {
                        this.Header_Title_ultraLabel.Appearance.BackColor = cga.GridHeaderAppearance.BackColor;
                        this.Header_Title_ultraLabel.Appearance.BackColor2 = cga.GridHeaderAppearance.BackColor2;
                        this.Header_Title_ultraLabel.Appearance.ForeColor = cga.GridHeaderAppearance.ForeColor;
                        this.Header_Background_ultraLabel.Appearance.BackColor = cga.GridHeaderAppearance.BackColor;
                        this.Header_Background_ultraLabel.Appearance.BackColor2 = cga.GridHeaderAppearance.BackColor2;
                        this.Header_Background_ultraLabel.Appearance.ForeColor = cga.GridHeaderAppearance.ForeColor;
                    }
                }
                else
                {
                    // UltraGridにデータをバインド
                    this.Result_ultraGrid.DataBind();

                    // 初期化
                    this.Initialize();
                }

                // 抽出結果・商品入力グリッドカラム情報設定処理
                this.SettingResultGridColumns(this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns, this.Result_ultraGrid);

                // --- ADD 2008/09/02 -------------------------------->>>>>
                // 論理削除行をフィルタ
                this.AddGridFiltering();
                // --- ADD 2008/09/02 --------------------------------<<<<<


                // ツールバーの初期状態設定
                this.ToolbarEnableSetting(0);

                // 選択ボタン制御
                this.SelUnSelButtonSetting(0);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                _nextControlDic = new Dictionary<string, Control>();
                _nextControlDic.Add(Condition_MakerCode_panel.Name, this.MakerName_tEdit);
                _nextControlDic.Add(Condition_GoodsNo_panel.Name, this.GoodsNo_tEdit);
                //_nextControlDic.Add(Condition_GoodsNameKana_panel.Name, this.GoodsNameKana_tEdit);    // 2010/07/13 Del
                _nextControlDic.Add(Condition_GoodsLGroup_panel.Name, this.GoodsLGroupName_tEdit);
                _nextControlDic.Add(Condition_GoodsMGroup_panel.Name, this.GoodsMGroupName_tEdit);
                _nextControlDic.Add(Condition_BLGroupCode_panel.Name, this.BLGroupName_tEdit);
                _nextControlDic.Add(Condition_GoodsKindCode_panel.Name, this.GoodsKindCode_True_ultraCheckEditor);
                _nextControlDic.Add(Condition_GoodsName_panel.Name, this.GoodsName_tEdit);

                _nextControlList = new List<string>();
                List<ExtractConditionItem> extractconditioItemList = this._extractConditionItems.GetExtractConditionItemList();
                for (int index = 0; index < extractconditioItemList.Count; index++)
                {
                    if (extractconditioItemList[index].IsDisplay())
                    {
                        _nextControlList.Add("Condition_" + extractconditioItemList[index].Key.TrimEnd() + "_panel");
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
            }
            catch (Exception ex)
            {
                // エラーメッセージ表示
                this.MsgDisp(-1, ctPROCNM, ex);

                this.Hide();
            }
            finally
            {
                // 起動カウンタアップ
                this._initialCount++;

                // 初期化終了
                this._isInitializing = false;
            }
        }

        /// <summary>
        /// 抽出条件コントロール初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件コントロールの初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void InitializeExtractConditionControlsSetting()
        {
            // ----------------------------------------
            // DrawFilterを抽出条件設定ツリーに設定する
            this.ExtractConditionSetting_ultraTree.DrawFilter = this._ultraTreeDrawFilter;
            this.ExtractConditionSetting_ultraTree.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.ExtendedAutoDrag;

            if (!this.ExtractConditionSetting_ultraTree.Appearances.Exists(CT_APPEARANCE_DROPHIGHLIGHT))
                this.ExtractConditionSetting_ultraTree.Appearances.Add(CT_APPEARANCE_DROPHIGHLIGHT);
            this.ExtractConditionSetting_ultraTree.Appearances[CT_APPEARANCE_DROPHIGHLIGHT].BackColor = Color.Cyan;

            // ----------------------------------------
            // イメージリスト設定
            this.Search_UButton.ImageList = this._imageList16;
            this.MakerGuide_UButton.ImageList = this._imageList16;
            this.GoodsLGroupGuide_UButton.ImageList = this._imageList16;
            this.GoodsMGroupGuide_UButton.ImageList = this._imageList16;
            this.BLGroupCodeGuide_UButton.ImageList = this._imageList16;
            this.AllSelect_uButton.ImageList = this._imageList16;
            this.AllUnSelect_uButton.ImageList = this._imageList16;
            this.DispSelect_uButton.ImageList = this._imageList16;
            this.DispUnSelect_uButton.ImageList = this._imageList16;

            // ----------------------------------------
            // アイコン設定
            this.Search_UButton.Appearance.Image = Size16_Index.SEARCH;
            this.GoodsLGroupGuide_UButton.Appearance.Image = Size16_Index.STAR1;
            this.MakerGuide_UButton.Appearance.Image = Size16_Index.STAR1;
            this.GoodsMGroupGuide_UButton.Appearance.Image = Size16_Index.STAR1;
            this.BLGroupCodeGuide_UButton.Appearance.Image = Size16_Index.STAR1;
            this.AllSelect_uButton.Appearance.Image = Size16_Index.ALLSELECT;
            this.AllUnSelect_uButton.Appearance.Image = Size16_Index.ALLCANCEL;
            this.DispSelect_uButton.Appearance.Image = Size16_Index.ALLSELECT;
            this.DispUnSelect_uButton.Appearance.Image = Size16_Index.ALLCANCEL;

        }

        /// <summary>
        /// エクスプローラバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : エクスプローラーバーの初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void InitializeExplorerBarSetting()
        {
            // イメージリスト設定
            this.Main_ultraExplorerBar.ImageListSmall = this._imageList16;

            // アイコン設定
            this.Main_ultraExplorerBar.Groups[CT_GROUP_EXTRACTCONDITION].Settings.AppearancesSmall.HeaderAppearance.Image = Size16_Index.PREVIEW;
            this.Main_ultraExplorerBar.Groups[CT_GROUP_EXTRACTCONDITIONSETTING].Settings.AppearancesSmall.HeaderAppearance.Image = Size16_Index.SETUP1;

            // 大きいアイコンは使用しない
            this.Main_ultraExplorerBar.UseLargeGroupHeaderImages = DefaultableBoolean.False;
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void InitializeToolbarsSetting()
        {
            // イメージリスト設定
            this.Main_ultraToolbarsManager.ImageListSmall = this._imageList16;

            // ログイン担当者タイトルラベルのアイコンを設定
            LabelTool loginTitleLabel = this.Main_ultraToolbarsManager.Tools[CT_LABELTOOL_LOGINTITLE] as LabelTool;
            if (loginTitleLabel != null)
            {
                loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            }

            // ログイン担当者名称設定
            LabelTool loginNameLabel = this.Main_ultraToolbarsManager.Tools[CT_LABELTOOL_LOGINNAME] as LabelTool;
            if ((loginNameLabel != null) &&
                (LoginInfoAcquisition.Employee != null))
            {
                loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // 終了ボタンのアイコン設定
            ButtonTool closeButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_CLOSE] as ButtonTool;
            if (closeButton != null)
            {
                if (this._callMode == (int)emGoodsCallMode.MenuStartMode)
                {
                    closeButton.SharedProps.Caption = "終了(&X)";
                    closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
                }
                else
                {
                    closeButton.SharedProps.Caption = "戻る(&X)";
                    closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
                }
            }

            // --- ADD 2009/01/06 障害ID:6079対応------------------------------------------------------>>>>>
            // 検索ボタンのアイコン設定
            ButtonTool searchButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_SEARCH] as ButtonTool;
            if (searchButton != null)
            {
                searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            }
            // --- ADD 2009/01/06 障害ID:6079対応------------------------------------------------------<<<<<

            // 新規ボタンのアイコン設定
            ButtonTool newButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_NEW] as ButtonTool;
            if (newButton != null)
            {
                newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            }

            // 編集ボタンのアイコン設定
            ButtonTool editButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_EDIT] as ButtonTool;
            if (editButton != null)
            {
                editButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EDITING;
            }

            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 削除ボタンのアイコン設定
            ButtonTool logicalDeleteButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_LOGICALDELETE] as ButtonTool;
            if (logicalDeleteButton != null)
            {
                logicalDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            }
            // --- ADD 2008/09/02 --------------------------------<<<<< 

            // 元に戻すボタンのアイコン設定
            ButtonTool undoButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_UNDO] as ButtonTool;
            if (undoButton != null)
            {
                //undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
                undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            }


            bool btnVisible = (this._callMode == (int)emGoodsCallMode.MenuStartMode);

            // 新規
            if (newButton != null)
            {
                newButton.SharedProps.Visible = btnVisible;
            }

            // 編集 
            if (editButton != null)
            {
                editButton.SharedProps.Visible = btnVisible;
            }

            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 削除 
            if (logicalDeleteButton != null)
            {
                logicalDeleteButton.SharedProps.Visible = btnVisible;
            }

            // --- ADD 2008/09/02 --------------------------------<<<<< 

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
            undoButton.SharedProps.Visible = true;
            undoButton.SharedProps.Enabled = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

            // 確定ボタンのアイコン設定
            ButtonTool decButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_DECISION] as ButtonTool;
            if (decButton != null)
            {
                // ガイド起動時のみ有効
                decButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
                decButton.SharedProps.Visible = !btnVisible;
            }

            // データポップアップボタンのアイコン設定
            PopupMenuTool dataPopupMenu = this.Main_ultraToolbarsManager.Tools[CT_POPUPMENUTOOL_DATA] as PopupMenuTool;
            if (dataPopupMenu != null)
            {
                dataPopupMenu.SharedProps.Visible = btnVisible;
            }

            // データ入力ボタンのアイコン設定
            ButtonTool dataInButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_DATAINPUT] as ButtonTool;
            if (dataInButton != null)
            {
                dataInButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVTAKING;
                dataInButton.SharedProps.Visible = btnVisible;

                dataInButton.SharedProps.Visible = false;
            }

            // データ出力ボタンのアイコン設定
            ButtonTool dataOutButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_DATAOUTPUT] as ButtonTool;
            if (dataOutButton != null)
            {
                dataOutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
                dataOutButton.SharedProps.Visible = btnVisible;

                dataOutButton.SharedProps.Visible = false;
            }

            // 印刷ボタンのアイコン設定
            ButtonTool printButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_PRINT] as ButtonTool;
            if (printButton != null)
            {
                printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
                printButton.SharedProps.Visible = btnVisible;

                printButton.SharedProps.Visible = false;
            }

        }

        /// <summary>
        /// 戻るボタン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 戻るボタンの設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void UndoButtonSetting()
        {
            //----- ADD YANGMJ 2012/02/15 REDMINE#26676 ----->>>>>
            this._preGoodsNo = string.Empty;
            this._preMakerCode = string.Empty;
            this._preGoodsName = string.Empty;
            this._preGoodsLGroup = string.Empty;
            this._preGoodsMGroup = string.Empty;
            this._preBLGroupCode = string.Empty;
            //----- ADD YANGMJ 2012/02/15 REDMINE#26676 -----<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
            //ButtonTool undoButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_UNDO] as ButtonTool;
            //if (undoButton != null)
            //{
            //    // 抽出条件履歴リストに2件以上データが存在する場合
            //    if (this._extractConditionList.Count > 1)
            //    {
            //        undoButton.SharedProps.Enabled = true;
            //    }
            //    else
            //    {
            //        undoButton.SharedProps.Enabled = false;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
        }

        /// <summary>
        /// ツールバー状態設定
        /// </summary>
        /// <param name="mode">0:初期,1:検索後</param>
        /// <remarks>
        /// <br>Note       : ツールバーの状態設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.18</br>
        /// </remarks>
        private void ToolbarEnableSetting(int mode)
        {
            bool btnEnabled = false;
            if (this._resultDataView != null && this._resultDataView.Count > 0)
            {
                btnEnabled = true;
            }

            // 編集ボタンの設定
            ButtonTool editButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_EDIT] as ButtonTool;
            if (editButton != null)
            {
                if (mode == 0)
                {
                    editButton.SharedProps.Enabled = false;
                }
                else
                {
                    editButton.SharedProps.Enabled = btnEnabled;
                }
            }

            // 確定ボタンの設定
            ButtonTool decButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_DECISION] as ButtonTool;
            if (decButton != null)
            {
                if (mode == 0)
                {
                    decButton.SharedProps.Enabled = false;
                }
                else
                {
                    decButton.SharedProps.Enabled = btnEnabled;
                }
            }

            // データ出力ボタンの設定
            ButtonTool dataOutButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_DATAOUTPUT] as ButtonTool;
            if (dataOutButton != null)
            {
                if (mode == 0)
                {
                    dataOutButton.SharedProps.Enabled = false;
                }
                else
                {
                    dataOutButton.SharedProps.Enabled = btnEnabled;
                }
            }

            // 印刷ボタンの設定
            ButtonTool printButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_PRINT] as ButtonTool;
            if (printButton != null)
            {
                if (mode == 0)
                {
                    printButton.SharedProps.Enabled = false;
                }
                else
                {
                    printButton.SharedProps.Enabled = btnEnabled;
                }
            }

            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 削除ボタンの設定
            ButtonTool logicalDeleteButton = this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_LOGICALDELETE] as ButtonTool;
            if (logicalDeleteButton != null)
            {
                if (mode == 0)
                {
                    logicalDeleteButton.SharedProps.Enabled = false;
                }
                else
                {
                    logicalDeleteButton.SharedProps.Enabled = btnEnabled;
                }
            }
            // --- ADD 2008/09/02 --------------------------------<<<<< 
        }

        /// <summary>
        /// 選択・非選択ボタン状態設定
        /// </summary>
        /// <param name="mode">0:初期,1:検索後</param>
        /// <remarks>
        /// <br>Note       : 選択・非選択ボタンの状態設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.5.10</br>
        /// </remarks>
        private void SelUnSelButtonSetting(int mode)
        {
            if (mode == 0)
            {
                if (this._isMultiSelect || this._callMode != (int)emGoodsCallMode.MenuStartMode)
                    this.TopButton_Panel.Visible = true;
                else
                    this.TopButton_Panel.Visible = false;
            }
        }

        /// <summary>
        /// ステータスバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ステータスバーの初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.17</br>
        /// </remarks>
        private void InitializeStatusBarSetting()
        {
            // フォントサイズ変更コンボボックスの設定
            this.FontSize_tComboEditor.MaxDropDownItems = this.FontSize_tComboEditor.Items.Count;
            this.FontSize_tComboEditor.Value = 10;
        }

        /// <summary>
        /// 抽出条件初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件の初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void InitializeExtractCondition()
        {
            // 抽出条件設定クラス配列XMLをデシリアライズ
            List<ExtractConditionItem> extractConditionItemList = GoodsExtractConditionItems.Deserialize(CT_FILENAME_EXTRACTCONDITION);

            // 抽出条件設定コレクションクラスをインスタンス化(入庫モード)
            this._extractConditionItems = new GoodsExtractConditionItems(extractConditionItemList);

            // 抽出条件設定ツリー構築処理
            this.ExtractConditionTreeConstruction(this._extractConditionItems.GetExtractConditionItemList());

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
            // XML内容が古い場合はtrueにして再生成する為のフラグ
            bool errorFlag = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

            // 抽出条件コントロール格納Dictionaryを生成
            foreach (ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
            {
                // パネル名称取得
                string panelName = this.GetExtractConditionPanelName(item);
                // 対象コントロール取得
                Control targetControl = FindControl(this, panelName);

                if ((targetControl != null) && (targetControl is Panel))
                {
                    this._extractConditionItemControlDictionary.Add(panelName, targetControl as Panel);
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                else
                {
                    // XMLファイルの中で１つでもＰＧ実装と合わない場合はエラー
                    errorFlag = true;
                    break;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
            if (errorFlag)
            {
                //--------------------------------------------
                // 再構築する
                //--------------------------------------------

                // 抽出条件設定クラス配列XMLをデシリアライズ
                extractConditionItemList = new List<ExtractConditionItem>();

                // 抽出条件設定コレクションクラスをインスタンス化(入庫モード)
                this._extractConditionItems = new GoodsExtractConditionItems(extractConditionItemList);

                // 抽出条件設定ツリー構築処理

                this.ExtractConditionTreeConstruction(this._extractConditionItems.GetExtractConditionItemList());

                // 抽出条件コントロール格納Dictionaryを生成
                this._extractConditionItemControlDictionary.Clear();
                foreach (ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
                {
                    // パネル名称取得
                    string panelName = this.GetExtractConditionPanelName(item);
                    // 対象コントロール取得
                    Control targetControl = FindControl(this, panelName);

                    if ((targetControl != null) && (targetControl is Panel))
                    {
                        this._extractConditionItemControlDictionary.Add(panelName, targetControl as Panel);
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

            // 抽出条件パネル構築処理
            this.ExtractConditionInputItemConstruction(this._extractConditionItems.GetExtractConditionItemList());
        }


        /// <summary>
        /// グリッドキーマッピング作成処理
        /// </summary>
        /// <param name="grid">対象グリッド</param>
        /// <remarks>
        /// <br>Note       : グリッドに対してキーマッピングを作成します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void MakeGridKeyMapping(UltraGrid grid)
        {
            GridKeyActionMapping wkKeyMapping = null;

            // Enterキー
            wkKeyMapping = new GridKeyActionMapping(
                Keys.Enter,
                UltraGridAction.NextCellByTab,
                0,
                UltraGridState.Cell,
                SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(wkKeyMapping);

            // Shift + Enterキー
            wkKeyMapping = new GridKeyActionMapping(
                Keys.Enter,
                UltraGridAction.PrevCellByTab,
                0,
                UltraGridState.Cell,
                SpecialKeys.AltCtrl,
                SpecialKeys.Shift);
            grid.KeyActionMappings.Add(wkKeyMapping);

            // ↑キー
            wkKeyMapping = new GridKeyActionMapping(
                Keys.Up,
                UltraGridAction.AboveCell,
                UltraGridState.IsDroppedDown,
                UltraGridState.InEdit,
                SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(wkKeyMapping);

            // ↓キー
            wkKeyMapping = new GridKeyActionMapping(
                Keys.Down,
                UltraGridAction.BelowCell,
                UltraGridState.IsDroppedDown,
                UltraGridState.InEdit,
                SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(wkKeyMapping);

            // PageUpキー
            wkKeyMapping = new GridKeyActionMapping(
                Keys.Prior,
                UltraGridAction.PageUpCell,
                0,
                UltraGridState.InEdit,
                SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(wkKeyMapping);

            // PageDownキー
            wkKeyMapping = new GridKeyActionMapping(
                Keys.Next,
                UltraGridAction.PageDownCell,
                0,
                UltraGridState.InEdit,
                SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(wkKeyMapping);
        }

        /// <summary>
        /// 抽出結果・商品入力グリッドカラム情報設定処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <param name="grid">設定対象グリッド</param>
        /// <remarks>
        /// <br>Note       : 抽出結果・商品入力グリッドのカラム情報の設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void SettingResultGridColumns(ColumnsCollection columns, UltraGrid grid)
        {
            //-------------------------------------------------------------
            // 一旦すべての列を非表示にし、表示位置を統一させる
            //-------------------------------------------------------------
            foreach (UltraGridColumn column in columns)
            {
                column.Hidden = true;

                //// セルの動作
                //column.CellActivation = Activation.Disabled;
                //// セルクリック時の動き
                //column.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

                column.CellAppearance.TextHAlign = HAlign.Left;
                column.CellAppearance.ImageHAlign = HAlign.Left;
                column.CellAppearance.ImageVAlign = VAlign.Middle;
            }

            //-------------------------------------------------------------
            // 可視化
            //-------------------------------------------------------------
            // 選択
            //if (this._isMultiSelect || this._callMode == (int)emGoodsCallMode.MenuStartMode)
            if (this._isMultiSelect) columns[CT_Select].Hidden = false;

            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 削除日 (削除表示チェックボタンにより制御)
            if (this.DeleteIndication_CheckEditor.Checked)
            {
                columns[CT_LogicalDeleteDate].Hidden = false;
            }
            else
            {
                columns[CT_LogicalDeleteDate].Hidden = true;
            }
            // --- ADD 2008/09/02 --------------------------------<<<<<

            // 品番
            columns[CT_GoodsNo].Hidden = false;
            // 品名
            columns[CT_GoodsName].Hidden = false;
            // 品名カナ
            // 2010/07/13 >>>
            //columns[CT_GoodsNameKana].Hidden = false;
            columns[CT_GoodsNameKana].Hidden = true;
            // 2010/07/13 <<<
            // 商品大分類名称
            columns[CT_GoodsLGroupName].Hidden = false;
            // 商品中分類名称
            columns[CT_GoodsMGroupName].Hidden = false;
            // BLグループコード
            columns[CT_BLGroupName].Hidden = false;
            // メーカー名
            columns[CT_MakerName].Hidden = false;
            // 価格開始日
            columns[CT_GoodsPricePriceStartDate].Hidden = false;
            // 標準価格
            columns[CT_GoodsPriceListPrice].Hidden = false;
            // オープン価格区分
            columns[CT_GoodsPriceOpenPriceDiv].Hidden = false;

            //-------------------------------------------------------------
            // 列幅
            //-------------------------------------------------------------
            // 選択
            columns[CT_Select].Width = 30;
            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 削除日
            columns[CT_LogicalDeleteDate].Width = 30;
            // --- ADD 2008/09/02 --------------------------------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
            columns[CT_LogicalDeleteDate].CellAppearance.ForeColor = Color.Red;
            columns[CT_LogicalDeleteDate].CellAppearance.ForeColorDisabled = Color.Red;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
            // 品番
            columns[CT_GoodsNo].Width = 100;
            // 品名
            columns[CT_GoodsName].Width = 150;
            // 品名カナ
            //columns[CT_GoodsNameKana].Width = 85;   // 2010/07/13 Del
            // 商品大分類名称
            columns[CT_GoodsLGroupName].Width = 315;
            // 商品中分類名称
            columns[CT_GoodsMGroupName].Width = 315;
            // BLグループコード名称
            columns[CT_BLGroupName].Width = 315;
            // メーカー名
            columns[CT_MakerName].Width = 160;
            // 価格開始日
            columns[CT_GoodsPricePriceStartDate].Width = 100;
            // 標準価格
            columns[CT_GoodsPriceListPrice].Width = 100;
            // オープン価格区分
            columns[CT_GoodsPriceOpenPriceDiv].Width = 100;

            //-------------------------------------------------------------
            // テキストの表示位置
            //-------------------------------------------------------------
            // 標準価格
            columns[CT_GoodsPriceListPrice].CellAppearance.TextHAlign = HAlign.Right;

            //-------------------------------------------------------------
            // 列幅固定
            //-------------------------------------------------------------


            //-------------------------------------------------------------
            // 列スタイル
            //-------------------------------------------------------------
            columns[CT_Select].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            columns[CT_Select].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            //-------------------------------------------------------------
            // タブストップ
            //-------------------------------------------------------------


            //-------------------------------------------------------------
            // ボーダー
            //-------------------------------------------------------------


            //-------------------------------------------------------------
            // 文字フォーマット
            //-------------------------------------------------------------
            // 標準価格
            columns[CT_GoodsPriceListPrice].Format = "#,##0;-#,##0;''";


            //-------------------------------------------------------------
            // 前回表示情報設定
            //-------------------------------------------------------------
            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = GoodsInputColDisplayStatusCollection.Deserialize(CT_FILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusCollection = new GoodsInputColDisplayStatusCollection(colDisplayStatusList);

            foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusCollection.GetColDisplayStatusList())
            {
                if (colDisplayStatus.Key == this.FontSize_tComboEditor.Name)
                {
                    this.FontSize_tComboEditor.Value = colDisplayStatus.Width;
                }
                else if (columns.Exists(colDisplayStatus.Key) == true)
                {
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                }
            }

        }

        /// <summary>
        /// 列表示状態クラスリスト構築処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.12</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // フォントサイズを格納
            ColDisplayStatus fontStatus = new ColDisplayStatus();
            fontStatus.Key = this.FontSize_tComboEditor.Name;
            fontStatus.VisiblePosition = -1;
            fontStatus.Width = (int)this.FontSize_tComboEditor.Value;
            colDisplayStatusList.Add(fontStatus);

            // グリッドから列表示状態クラスリストを構築
            // グループ内の各カラム
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                // 隠し列の情報も保存するようにする
                //if (column.Hidden == true)
                //{
                //  continue;
                //}

                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();
                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }
        #endregion

        // --------------------------------------------------
        #region < DataSet, DataTable, DataRow 作成 >

        /// <summary>
        /// 抽出結果・商品入力DataTable構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出結果・商品入力用のDataTableの構築を行います。</br>
        /// </remarks>
        private void ResultDataTableConstruction()
        {
            // ----------------------------------------
            // DataTableの作成
            this._resultDataTable = new DataTable(CT_TBL_RESULT_TITLE);

            // ----------------------------------------
            // DataColumnの作成

            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 削除日
            DataColumn LogicalDeleteDate = new DataColumn(CT_LogicalDeleteDate, typeof(string), "", MappingType.Element);
            LogicalDeleteDate.Caption = "削除日";
            // --- ADD 2008/09/02 --------------------------------<<<<<

            // 品番
            DataColumn GoodsNo = new DataColumn(CT_GoodsNo, typeof(string), "", MappingType.Element);
            GoodsNo.Caption = "品番";

            // 品名
            DataColumn GoodsName = new DataColumn(CT_GoodsName, typeof(string), "", MappingType.Element);
            GoodsName.Caption = "品名";

            // 品名カナ
            DataColumn GoodsNameKana = new DataColumn(CT_GoodsNameKana, typeof(string), "", MappingType.Element);
            GoodsNameKana.Caption = "品名ｶﾅ";

            // 商品大分類コード
            DataColumn GoodsLGroup = new DataColumn(CT_GoodsLGroup, typeof(string), "", MappingType.Element);
            GoodsLGroup.Caption = "商品大分類コード";

            // 商品大分類名称
            DataColumn GoodsLGroupName = new DataColumn(CT_GoodsLGroupName, typeof(string), "", MappingType.Element);
            GoodsLGroupName.Caption = "商品大分類名";

            // 商品中分類コード
            DataColumn GoodsMGroup = new DataColumn(CT_GoodsMGroup, typeof(string), "", MappingType.Element);
            GoodsMGroup.Caption = "商品中分類コード";

            // 商品中分類名称
            DataColumn GoodsMGroupName = new DataColumn(CT_GoodsMGroupName, typeof(string), "", MappingType.Element);
            GoodsMGroupName.Caption = "商品中分類名";

            // BLグループコード
            DataColumn BLGroupCode = new DataColumn(CT_BLGroupCode, typeof(string), "", MappingType.Element);
            BLGroupCode.Caption = "グループコード";

            // BLグループコード名称
            DataColumn BLGroupName = new DataColumn(CT_BLGroupName, typeof(string), "", MappingType.Element);
            BLGroupName.Caption = "グループコード名";

            // メーカーコード
            DataColumn MakerCode = new DataColumn(CT_MakerCode, typeof(Int32), "", MappingType.Element);
            MakerCode.Caption = "メーカーコード";

            // メーカー名
            DataColumn MakerName = new DataColumn(CT_MakerName, typeof(string), "", MappingType.Element);
            MakerName.Caption = "メーカー名";

            // JANコード
            DataColumn JAN = new DataColumn(CT_JAN, typeof(string), "", MappingType.Element);
            JAN.Caption = "JANコード";

            // 商品属性
            DataColumn GoodsKindCode = new DataColumn(CT_GoodsKindCode, typeof(Int32), "", MappingType.Element);
            GoodsKindCode.Caption = "商品属性";

            // 価格開始日
            DataColumn PriceStartDate = new DataColumn(CT_GoodsPricePriceStartDate, typeof(string), "", MappingType.Element);
            PriceStartDate.Caption = "価格開始日";

            // 標準価格
            DataColumn ListPrice = new DataColumn(CT_GoodsPriceListPrice, typeof(Int32), "", MappingType.Element);
            ListPrice.Caption = "標準価格";

            // オープン価格区分
            DataColumn OpenPriceDiv = new DataColumn(CT_GoodsPriceOpenPriceDiv, typeof(string), "", MappingType.Element);
            OpenPriceDiv.Caption = "オープン価格区分";

            // BL商品コード
            DataColumn BLGoodsCode = new DataColumn(CT_BLGoodsCode, typeof(Int32), "", MappingType.Element);
            BLGoodsCode.Caption = "BLコード";

            // 商品連結データクラス格納
            DataColumn GoodsUitData = new DataColumn(CT_GoodsUitData, typeof(GoodsUnitData), "", MappingType.Element);
            GoodsUitData.Caption = "商品連結データクラス格納";

            // 価格情報データテーブル格納
            DataColumn GoodsPriceList = new DataColumn(CT_GoodsPriceList, typeof(List<GoodsPrice>), "", MappingType.Element);
            GoodsPriceList.Caption = "価格情報データテーブル格納";

            // 選択状態
            DataColumn Select = new DataColumn(CT_Select, typeof(Boolean), "", MappingType.Element);
            Select.Caption = "選択";

            // DataRowの格納用
            DataColumn DataRow = new DataColumn(CT_DataRow, typeof(DataRow), "", MappingType.Element);
            DataRow.Caption = "";

            // ----------------------------------------
            // DataSetの初期化
            this._resultDataSet.Tables.AddRange(new DataTable[] { this._resultDataTable });

            // ----------------------------------------
            // DataTableの初期化
            this._resultDataTable.Columns.AddRange(new DataColumn[] {
				Select,
                // --- ADD 2008/09/02 -------------------------------->>>>>
                LogicalDeleteDate,
                // --- ADD 2008/09/02 --------------------------------<<<<<
				GoodsNo,
				GoodsName, 
				GoodsNameKana, 
                GoodsLGroup,
                GoodsLGroupName,
                GoodsMGroup,
                GoodsMGroupName,
                BLGroupCode,
                BLGroupName,
                MakerCode,
                MakerName,
                JAN,
				GoodsKindCode, 
                PriceStartDate,
                ListPrice,
                OpenPriceDiv,
                BLGoodsCode,
                GoodsUitData,
                GoodsPriceList,
                DataRow,
            });

            // ----------------------------------------
            // DataViewのテーブル設定
            this._resultDataView.Table = this._resultDataTable;
            this._resultDataView.Sort = CT_Default_GoodsOdr;
        }

        #endregion

        // --------------------------------------------------
        #region < UltraGrid関連の処理 >

        /// <summary>
        /// グリッドのセッティング描画処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.16</br>
        /// </remarks>
        private void SettingGridRowEditor()
        {
            int cnt = this.Result_ultraGrid.Rows.Count;

            if (this.InvokeRequired == false)
            {
                // 描画を一時停止
                this.Result_ultraGrid.BeginUpdate();
                try
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        SettingGridRowEditor(i);
                    }
                }
                finally
                {
                    // 描画を開始
                    this.Result_ultraGrid.EndUpdate();
                }
            }
            else
            {
                settingHandler _setting = new settingHandler(SettingGridRowEditor);
                for (int i = 0; i < cnt; i++)
                {
                    Object[] pList = { i };
                    this.BeginInvoke(_setting, pList);
                }

            }
        }

        /// <summary>
        /// 表示グリッド行単位でのセル描画処理
        /// </summary>
        /// <param name="row">指定行</param>
        /// <remarks>
        /// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.16</br>
        /// </remarks>
        private void SettingGridRowEditor(int row)
        {
            // デフォルト行の前景色
            this.Result_ultraGrid.Rows[row].Appearance.ForeColor = Color.Black;
            this.Result_ultraGrid.Rows[row].Appearance.ForeColorDisabled = Color.Black;

            /* --- DEL 2009/01/09 障害ID:9891対応------------------------------------------------------>>>>>
			if (row % 2 == 1)
				this.Result_ultraGrid.Rows[row].Appearance.BackColor = Color.Lavender;
			else
				this.Result_ultraGrid.Rows[row].Appearance.BackColor = Color.White;
               --- DEL 2009/01/09 障害ID:9891対応------------------------------------------------------<<<<<*/
            this.Result_ultraGrid.Rows[row].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
        }

        /// <summary>
        /// 商品データ選択処理
        /// </summary>
        /// <param name="selRow">選択された対象行</param>
        private void SelectRowData(Infragistics.Win.UltraWinGrid.UltraGridRow selRow)
        {
            if (selRow == null) return;

            GoodsUnitData selData = (selRow.Cells[CT_GoodsUitData].Value != DBNull.Value) ? (GoodsUnitData)selRow.Cells[CT_GoodsUitData].Value : null;

            if (selData.LogicalDeleteCode != 0)
            {
                this.MsgDisp("選択されているデータが存在しません。", emErrorLevel.ERR_LEVEL_INFO);
                return;
            }

            // 選択した行の商品連結クラスを返却値として設定
            this._selGoodsUnitData = selData;
            //ここ

            // 戻り値を設定
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 該当行背景色変更処理
        /// </summary>
        /// <param name="row">対象行インデックス</param>
        /// <remarks>
        /// <br>Note       : 対象行の背景色を変更します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.1.19</br>
        /// </remarks>
        private void ChangedRowBackColor(Infragistics.Win.UltraWinGrid.UltraGridRow row)
        {
            if ((Boolean)row.Cells[CT_Select].Value == true)
            {
                row.Appearance.BackColor = this._selBackColor;
                row.Appearance.BackColor2 = this._selBackColor2;
                row.Appearance.BackGradientStyle = this._selBackGradientStyle;
            }
            else
            {
                row.Appearance.BackColor = _defRowAppearance.BackColor;
                row.Appearance.BackColor2 = _defRowAppearance.BackColor2;
                row.Appearance.BackGradientStyle = _defRowAppearance.BackGradientStyle;
            }
        }

        // --- ADD 2008/09/02 -------------------------------->>>>>
        /// <summary>
        /// グリッドアクティブ行設定処理
        /// </summary>
        /// <param name="targetGrid">操作対象Grid</param>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブ行を検索し、選択状態にします。</br>
        /// <br>Note       : SFCMN09000よりコピー作成</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        private void SetActiveRow(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
        {
            if (targetGrid.ActiveRow != null)
            {
                bool setFlg = false;
                Infragistics.Win.UltraWinGrid.UltraGridRow nextRow = targetGrid.ActiveRow;
                while (nextRow != null)
                {
                    if (nextRow.IsFilteredOut)
                    {
                        int index = nextRow.Index;

                        // 選択行がフィルタリングされている場合Next行を選択
                        nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

                        // インデックスが同じ場合は、次が存在しないと判断してbreak;
                        if ((nextRow != null) && (index == nextRow.Index))
                        {
                            break;
                        }
                    }
                    else
                    {
                        targetGrid.ActiveRow = nextRow;
                        targetGrid.ActiveRow.Selected = true;
                        setFlg = true;
                        break;
                    }
                }

                if (setFlg == false)
                {
                    // 該当する行が存在しない場合は、最初から再度Next検索
                    nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First);
                    while (nextRow != null)
                    {
                        if (nextRow.IsFilteredOut)
                        {
                            int index = nextRow.Index;

                            // 選択行がフィルタリングされている場合Next行を選択
                            nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

                            // インデックスが同じ場合は、次が存在しないと判断してbreak;
                            if ((nextRow != null) && (index == nextRow.Index))
                            {
                                break;
                            }
                        }
                        else
                        {
                            targetGrid.ActiveRow = nextRow;
                            targetGrid.ActiveRow.Selected = true;
                            break;
                        }
                    }
                }
            }
            else if (targetGrid.Rows.Count > 0)
            {
                if (targetGrid.Rows[0] != null)
                {
                    targetGrid.ActiveRow = targetGrid.Rows[0];
                    targetGrid.ActiveRow.Selected = true;
                }
            }
        }
        // --- ADD 2008/09/02 --------------------------------<<<<< 

        #endregion

        // --------------------------------------------------
        #region < 抽出条件関連 >

        /// <summary>
        /// 抽出条件パネル名称取得処理
        /// </summary>
        /// <param name="extractConditionItem">抽出条件設定クラス</param>
        /// <returns>抽出条件パネル名称</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件設定クラスをもとに、抽出条件パネル名称を取得します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private string GetExtractConditionPanelName(ExtractConditionItem extractConditionItem)
        {
            return ("Condition_" + extractConditionItem.Key + "_panel");
        }

        /// <summary>
        /// コントロール取得処理
        /// </summary>
        /// <param name="parentControl">検索対象親コントロール</param>
        /// <param name="searchControlName">検索コントロール名称</param>
        /// <returns>検索コントロール</returns>
        /// <remarks>
        /// <br>Note       : 指定された親コントロールから、検索コントロール名称のコントロールを取得します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private static Control FindControl(Control parentControl, string searchControlName)
        {
            // 親コントロール内のすべてのコントロールを検索する
            foreach (Control childControl in parentControl.Controls)
            {
                // さらにコントロールを格納している場合は再帰呼び出しを行う
                if (childControl.HasChildren)
                {
                    Control findControl = FindControl(childControl, searchControlName);

                    // 再帰呼出先でコントロールが見つかった場合はそのまま返す
                    if (findControl != null)
                    {
                        return findControl;
                    }
                }

                // コントロール名が一致する場合はそのコントロールを返す
                if (childControl.Name == searchControlName)
                {
                    return childControl;
                }
            }

            return null;
        }

        /// <summary>
        /// 抽出条件設定ツリー構築処理
        /// </summary>
        /// <param name="extractConditionItemList">抽出条件設定クラスリスト</param>
        /// <remarks>
        /// <br>Note       : 抽出条件設定ツリーの構築を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void ExtractConditionTreeConstruction(List<ExtractConditionItem> extractConditionItemList)
        {
            // 抽出条件設定ツリーノードを初期化
            this.ExtractConditionSetting_ultraTree.Nodes.Clear();

            // 抽出条件設定クラスリストから抽出条件設定ツリーノードを構築
            foreach (ExtractConditionItem item in extractConditionItemList)
            {
                UltraTreeNode node = new UltraTreeNode(item.Key, item.Name);
                node.Override.NodeStyle = NodeStyle.CheckBox;

                // 表示状態からチェック状態を設定
                if (item.DisplayFlg)
                {
                    // 表示
                    node.CheckedState = CheckState.Checked;
                }
                else
                {
                    // 非表示
                    node.CheckedState = CheckState.Unchecked;
                }

                // ノードを追加
                this.ExtractConditionSetting_ultraTree.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 抽出条件設定クラスリスト構築処理
        /// </summary>
        /// <returns>抽出条件設定クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件設定ツリーを元に、抽出条件設定クラスリストを構築します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private List<ExtractConditionItem> ExtractConditionItemListConstruction()
        {
            List<ExtractConditionItem> retList = new List<ExtractConditionItem>();

            // 抽出条件設定ツリーのどから抽出条件設定クラスリストを構築
            int itemNo = 0;
            foreach (UltraTreeNode node in this.ExtractConditionSetting_ultraTree.Nodes)
            {
                ExtractConditionItem item = new ExtractConditionItem();
                item.Key = node.Key.ToString();
                item.No = ++itemNo;
                item.Name = node.Text;

                // チェック状態から表示状態を設定
                if (node.CheckedState == CheckState.Checked)
                {
                    // 表示
                    item.DisplayFlg = true;
                }
                else
                {
                    // 非表示
                    item.DisplayFlg = false;
                }

                retList.Add(item);
            }

            return retList;
        }

        /// <summary>
        /// 抽出条件アイテムパネル構築処理
        /// </summary>
        /// <param name="extractConditionItemList">抽出条件設定クラスリスト</param>
        /// <remarks>
        /// <br>Note       : 抽出条件設定クラスリストを元に抽出条件アイテムパネルの構築を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void ExtractConditionInputItemConstruction(List<ExtractConditionItem> extractConditionItemList)
        {
            try
            {
                this.Condition_panel.Visible = false;

                // 一度、すべてのパネルを非表示にする
                int tabIndex = 4;
                foreach (ExtractConditionItem item in extractConditionItemList)
                {
                    // パネル名称を取得
                    string panelName = this.GetExtractConditionPanelName(item);

                    // パネル名称からパネルを取得
                    if (!this._extractConditionItemControlDictionary.ContainsKey(panelName)) continue;

                    Panel targetPanel = this._extractConditionItemControlDictionary[panelName] as Panel;

                    if (targetPanel == null)
                    {
                        continue;
                    }

                    targetPanel.Visible = false;
                    targetPanel.Dock = DockStyle.Top;
                    targetPanel.TabIndex = tabIndex;
                }

                // 順番にパネルを表示していく
                foreach (ExtractConditionItem item in extractConditionItemList)
                {
                    // 表示・非表示の判定
                    if (item.IsDisplay() == false)
                    {
                        // 非表示
                        continue;
                    }

                    // パネル名称を取得
                    string panelName = this.GetExtractConditionPanelName(item);

                    // パネル名称からパネルを取得
                    if (!this._extractConditionItemControlDictionary.ContainsKey(panelName)) continue;

                    // パネル名称からパネルを取得
                    Panel targetPanel = this._extractConditionItemControlDictionary[panelName] as Panel;

                    if (targetPanel == null)
                    {
                        continue;
                    }

                    targetPanel.Visible = item.DisplayFlg;
                    // 最前面へ移動
                    targetPanel.BringToFront();
                    // タブインデックスを設定
                    targetPanel.TabIndex = tabIndex++;
                }

                // 抽出条件ヘッダパネルを最背面へ移動
                this.Condition_Header_panel.SendToBack();
            }
            finally
            {
                this.Condition_panel.Visible = true;
            }
        }

        /// <summary>
        /// 抽出条件アイテムパネルリスト取得処理
        /// </summary>
        /// <param name="visibleCheck">表示設定判定フラグ</param>
        /// <returns>抽出条件アイテムパネルリスト</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件設定クラスリストを元に、抽出条件アイテムパネルリストを取得します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private List<Control> GetExtractConditionPanelList(bool visibleCheck)
        {
            List<Control> controlList = new List<Control>();

            foreach (ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
            {
                string panelName = this.GetExtractConditionPanelName(item);
                Control targetControl = FindControl(this, panelName);

                if ((targetControl != null) && (targetControl is Panel))
                {
                    // 表示設定判定無し or パネルが表示されている場合
                    // 抽出条件アイテムパネルリストに追加
                    if ((visibleCheck == false) ||
                        (targetControl.Visible == true))
                    {
                        controlList.Add(targetControl);
                    }
                }
            }

            return controlList;
        }

        /// <summary>
        /// パネル上入力項目コントロール取得処理
        /// </summary>
        /// <param name="targetPanel">対象パネル</param>
        /// <returns>入力項目コントロール</returns>
        /// <remarks>
        /// <br>Note       : 指定されたパネル上の入力項目コントロールを取得します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.10.25</br>
        /// </remarks>
        private Control GetInputControlOnPanel(Panel targetPanel)
        {
            Control inputControl = null;

            if (targetPanel.HasChildren)
            {
                // TNEdit, TEdit, TDateEdit を入力項目とする
                foreach (Control control in targetPanel.Controls)
                {
                    if ((control is TNedit) ||
                        (control is TEdit) ||
                        (control is TDateEdit))
                    {
                        // 既に別のコントロールが見つかっている場合
                        if (inputControl != null)
                        {
                            // より左上のものを優先する
                            if ((control.Left < inputControl.Left) ||
                                (control.Top < inputControl.Top))
                            {
                                inputControl = control;
                            }
                        }
                        else
                        {
                            inputControl = control;
                        }
                    }
                }
            }

            return inputControl;
        }

        /// <summary>
        /// 抽出条件履歴リストレコード追加処理
        /// </summary>
        /// <param name="goodsCndtn">商品入力入力抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       : 抽出条件履歴リストに商品入力入力抽出条件クラスを追加します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void AddExtractConditionList(GoodsCndtn goodsCndtn)
        {
            // 0件の場合
            if (this._extractConditionList.Count == 0)
            {
                // データを追加
                this._extractConditionList.Push(goodsCndtn.Clone());
            }

            // 最終アイテムと値が違う場合のみ、新たに車両入出庫入力抽出条件クラスを追加する
            GoodsCndtn lastGoodsInputCndtn = this._extractConditionList.Peek();
            if ((lastGoodsInputCndtn == null) || (lastGoodsInputCndtn.Equals(goodsCndtn) == false))
            {
                // データを追加
                this._extractConditionList.Push(goodsCndtn.Clone());
            }
        }

        /// <summary>
        /// 商品入力抽出条件クラス設定処理
        /// </summary>
        /// <param name="goodsCndtn">商品入力抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       : 各抽出条件入力コントロールから商品入力抽出条件を設定します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void SettingExtractConditionClass(ref GoodsCndtn goodsCndtn)
        {
            if (goodsCndtn == null)
            {
                goodsCndtn = new GoodsCndtn();
            }

            // 企業コード
            goodsCndtn.EnterpriseCode = this._enterpriseCode;

            goodsCndtn.IsSettingSupplier = 1; // 2009.02.13

            //---------------------------------------------------
            // メーカー
            //---------------------------------------------------
            if (this.Condition_MakerCode_panel.Visible == true)
            {
                // メーカーコードが検索対象
                goodsCndtn.GoodsMakerCd = TStrConv.StrToIntDef(this.MakerCode_ULabel.Text, 0);
            }
            else
            {
                goodsCndtn.GoodsMakerCd = 0;
            }

            //---------------------------------------------------
            // 商品大分類
            //---------------------------------------------------
            if (this.Condition_GoodsLGroup_panel.Visible == true)
            {
                // 商品大分類が検索対象
                goodsCndtn.GoodsLGroup = TStrConv.StrToIntDef(this.GoodsLGroup_ULabel.Text, 0);
            }
            else
            {
                goodsCndtn.GoodsLGroup = 0;
            }

            //---------------------------------------------------
            // 商品中分類
            //---------------------------------------------------
            if (this.Condition_GoodsMGroup_panel.Visible == true)
            {
                // 商品中分類が検索対象
                goodsCndtn.GoodsMGroup = TStrConv.StrToIntDef(this.GoodsMGroup_ULabel.Text, 0);
            }
            else
            {
                goodsCndtn.GoodsMGroup = 0;
            }

            //---------------------------------------------------
            // BLグループコード
            //---------------------------------------------------
            if (this.Condition_BLGroupCode_panel.Visible == true)
            {
                // BLグループコードが検索対象
                goodsCndtn.BLGroupCode = TStrConv.StrToIntDef(this.BLGroupCode_ULabel.Text, 0);
            }
            else
            {
                goodsCndtn.BLGroupCode = 0;
            }

            //---------------------------------------------------
            // 品番
            //---------------------------------------------------
            if (this.Condition_GoodsNo_panel.Visible == true)
            {
                // 品番が検索対象
                goodsCndtn.GoodsNo = this.GoodsNo_tEdit.DataText;
                goodsCndtn.GoodsNoSrchTyp = (int)this.GoodsCodeSearchType_ultraOptionSet.CheckedItem.DataValue;
            }
            else
            {
                goodsCndtn.GoodsNo = "";
                goodsCndtn.GoodsNoSrchTyp = 0;
            }

            //---------------------------------------------------
            // 品名
            //---------------------------------------------------
            if (this.Condition_GoodsName_panel.Visible == true)
            {
                // 品名が検索対象
                goodsCndtn.GoodsName = this.GoodsName_tEdit.DataText;
                goodsCndtn.GoodsNameSrchTyp = (int)this.GoodsNameSearchType_ultraOptionSet.CheckedItem.DataValue;
            }
            else
            {
                goodsCndtn.GoodsName = "";
                goodsCndtn.GoodsNameSrchTyp = 0;
            }

            //---------------------------------------------------
            // 品名カナ
            //---------------------------------------------------
            // 2010/07/13 Del >>>
            //if (this.Condition_GoodsNameKana_panel.Visible == true)
            //{
            //    // 品名カナが検索対象
            //    goodsCndtn.GoodsNameKana = this.GoodsNameKana_tEdit.DataText;
            //    goodsCndtn.GoodsNameKanaSrchTyp = (int)this.GoodsNameKanaSearchType_ultraOptionSet.CheckedItem.DataValue;
            //}
            //else
            //{
            //    goodsCndtn.GoodsNameKana = "";
            //    goodsCndtn.GoodsNameKanaSrchTyp = 0;
            //}
            // 2010/07/13 Del <<<

            //---------------------------------------------------
            // 商品属性検索区分
            //---------------------------------------------------
            if (this.Condition_GoodsKindCode_panel.Visible == true)
            {

                // 商品属性が検索対象
                if (this.GoodsKindCode_True_ultraCheckEditor.Checked && this.GoodsKindCode_False_ultraCheckEditor.Checked)
                {
                    // 両方(0:純正 1:その他)
                    goodsCndtn.GoodsKindCode = 9;
                }
                else if (this.GoodsKindCode_False_ultraCheckEditor.Checked)
                {
                    // 1:その他
                    goodsCndtn.GoodsKindCode = 1;
                }
                else if (this.GoodsKindCode_True_ultraCheckEditor.Checked)
                {
                    // 0:純正
                    goodsCndtn.GoodsKindCode = 0;
                }
                else
                {
                    // 両方(0:純正 1:その他)
                    goodsCndtn.GoodsKindCode = 9;
                }

            }
            else
            {
                // 両方(0:純正 1:その他)
                goodsCndtn.GoodsKindCode = 9;
            }


        }

        /// <summary>
        /// 商品入力抽出条件クラスコントロール設定処理
        /// </summary>
        /// <param name="goodsCndtn">商品入力抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       : 抽出条件の内容を抽出条件入力コントロールにセットします。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        private void SettingExtractConditionItemInfo(GoodsCndtn goodsCndtn)
        {
            if (goodsCndtn == null)
            {
                return;
            }

            //---------------------------------------------------
            // チェックボックスのイベントを解除
            //---------------------------------------------------
            this.GoodsKindCode_True_ultraCheckEditor.AfterCheckStateChanged -= new CheckEditor.AfterCheckStateChangedHandler(this.GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged);
            this.GoodsKindCode_False_ultraCheckEditor.AfterCheckStateChanged -= new CheckEditor.AfterCheckStateChangedHandler(this.GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged);

            //---------------------------------------------------
            // オプションセットのイベント解除
            //---------------------------------------------------
            this.GoodsCodeSearchType_ultraOptionSet.ValueChanged -= new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);
            this.GoodsNameSearchType_ultraOptionSet.ValueChanged -= new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);
            //this.GoodsNameKanaSearchType_ultraOptionSet.ValueChanged -= new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);  // 2010/07/13 Del

            //---------------------------------------------------
            // メーカー
            //---------------------------------------------------
            if (this.Condition_MakerCode_panel.Visible == true)
            {
                this.MakerCode_ULabel.Text = goodsCndtn.GoodsMakerCd.ToString();
                this.MakerName_tEdit.Text = goodsCndtn.MakerName;
            }
            else
            {
                this.MakerCode_ULabel.Text = "";
                this.MakerName_tEdit.Clear();
            }

            //---------------------------------------------------
            // 商品大分類
            //---------------------------------------------------
            if (this.Condition_GoodsLGroup_panel.Visible == true)
            {
                this.GoodsLGroup_ULabel.Text = goodsCndtn.GoodsLGroup.ToString();
                this.GoodsLGroupName_tEdit.Text = goodsCndtn.GoodsLGroupName;
            }
            else
            {
                this.GoodsLGroup_ULabel.Text = "";
                this.GoodsLGroupName_tEdit.Clear();
            }

            //---------------------------------------------------
            // 商品中分類
            //---------------------------------------------------
            if (this.Condition_GoodsMGroup_panel.Visible == true)
            {
                this.GoodsMGroup_ULabel.Text = goodsCndtn.GoodsMGroup.ToString();
                this.GoodsMGroupName_tEdit.Text = goodsCndtn.GoodsMGroupName;
            }
            else
            {
                this.GoodsMGroup_ULabel.Text = "";
                this.GoodsMGroupName_tEdit.Clear();
            }

            //---------------------------------------------------
            // BLグループコード
            //---------------------------------------------------
            if (this.Condition_BLGroupCode_panel.Visible == true)
            {
                this.BLGroupCode_ULabel.Text = goodsCndtn.BLGroupCode.ToString();
                this.BLGroupName_tEdit.Text = goodsCndtn.BLGroupName;
            }
            else
            {
                this.BLGroupCode_ULabel.Text = "";
                this.BLGroupName_tEdit.Clear();
            }

            //---------------------------------------------------
            // 品番
            //---------------------------------------------------
            if (this.Condition_GoodsNo_panel.Visible == true)
            {
                this.GoodsNo_tEdit.DataText = goodsCndtn.GoodsNo.ToString();
                this.GoodsCodeSearchType_ultraOptionSet.CheckedIndex = this.GetSrchTypIndex(goodsCndtn.GoodsNoSrchTyp);
            }
            else
            {
                this.GoodsNo_tEdit.Clear();
                this.GoodsCodeSearchType_ultraOptionSet.CheckedIndex = 0;
            }

            //---------------------------------------------------
            // 品名
            //---------------------------------------------------
            if (this.Condition_GoodsName_panel.Visible == true)
            {
                this.GoodsName_tEdit.DataText = goodsCndtn.GoodsName;
                this.GoodsNameSearchType_ultraOptionSet.CheckedIndex = this.GetSrchTypIndex(goodsCndtn.GoodsNameSrchTyp);
            }
            else
            {
                // 2010/07/13 Del >>>
                //this.GoodsNameKana_tEdit.Clear();
                //this.GoodsNameKanaSearchType_ultraOptionSet.CheckedIndex = 0;
                // 2010/07/13 Del <<<
            }

            //---------------------------------------------------
            // 品名カナ
            //---------------------------------------------------
            // 2010/07/13 Del >>>
            //if (this.Condition_GoodsNameKana_panel.Visible == true)
            //{
            //    this.GoodsNameKana_tEdit.DataText = goodsCndtn.GoodsNameKana;
            //    this.GoodsNameKanaSearchType_ultraOptionSet.CheckedIndex = this.GetSrchTypIndex(goodsCndtn.GoodsNameKanaSrchTyp);
            //}
            //else
            //{
            //    this.GoodsNameKana_tEdit.Clear();
            //    this.GoodsNameKanaSearchType_ultraOptionSet.CheckedIndex = 0;
            //}
            // 2010/07/13 Del <<<

            //// ----------------------------------------
            //// 商品属性検索区分
            //if (this.Condition_GoodsKindCode_panel.Visible == true)
            //{
            //    switch (goodsCndtn.GoodsKindCode)
            //    {
            //        case 0:
            //            {
            //                // 0:純正のみ
            //                this.GoodsKindCode_True_ultraCheckEditor.Checked = true;
            //                this.GoodsKindCode_False_ultraCheckEditor.Checked = false;
            //                break;
            //            }
            //        case 1:
            //            {
            //                // 1:その他のみ
            //                this.GoodsKindCode_True_ultraCheckEditor.Checked = false;
            //                this.GoodsKindCode_False_ultraCheckEditor.Checked = true;
            //                break;
            //            }
            //        case 9:
            //            {
            //                // 両方(0:純正 1:その他)
            //                this.GoodsKindCode_True_ultraCheckEditor.Checked = true;
            //                this.GoodsKindCode_False_ultraCheckEditor.Checked = true;
            //                break;
            //            }
            //        default:
            //            {
            //                // 両方(0:純正 1:その他)
            //                this.GoodsKindCode_True_ultraCheckEditor.Checked = true;
            //                this.GoodsKindCode_False_ultraCheckEditor.Checked = true;
            //                break;
            //            }
            //    }
            //}

            //// ----------------------------------------
            //// 商品属性検索区分
            //if (this.Condition_GoodsKindSrchCode_panel.Visible == true)
            //{
            //    if (goodsCndtn.GoodsKindSrchCode == null || goodsCndtn.GoodsKindSrchCode.Length == 0)
            //    {
            //        this.GoodsKind_ultraTree.Nodes.Clear();
            //    }
            //    else
            //    {
            //        this.GoodsKind_ultraTree.Nodes.Clear();

            //        foreach (int goodsKindSrchCode in goodsCndtn.GoodsKindSrchCode)
            //        {
            //            GoodsKind goodsKind;
            //            int status = this._goodsAcs.GetGoodsKind(this._enterpriseCode, goodsKindSrchCode, out goodsKind);
            //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //            {
            //                this.GoodsKind_ultraTree.Nodes.Add(goodsKind.GoodsKindCode.ToString(), goodsKind.GoodsKindName);
            //            }
            //        }
            //    }
            //}

            //---------------------------------------------------
            // オプションセットのイベントを再登録
            //---------------------------------------------------
            this.GoodsCodeSearchType_ultraOptionSet.ValueChanged += new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);
            this.GoodsNameSearchType_ultraOptionSet.ValueChanged += new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);
            //this.GoodsNameKanaSearchType_ultraOptionSet.ValueChanged += new EventHandler(this.SearchType_ultraOptionSet_ValueChanged);  // 2010/07/13 Del

            //---------------------------------------------------
            // チェックボックスのイベントを再登録
            //---------------------------------------------------
            this.GoodsKindCode_True_ultraCheckEditor.AfterCheckStateChanged += new CheckEditor.AfterCheckStateChangedHandler(this.GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged);
            this.GoodsKindCode_False_ultraCheckEditor.AfterCheckStateChanged += new CheckEditor.AfterCheckStateChangedHandler(this.GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged);

        }

        /// <summary>
        /// 検索タイプインデックス取得処理
        /// </summary>
        /// <param name="srchTyp"></param>
        /// <returns></returns>
        private int GetSrchTypIndex(int srchTyp)
        {
            int ret = 0;

            switch (srchTyp)
            {
                // 完全一致検索
                case 0:
                    ret = 0;
                    break;
                // 前方一致検索
                case 1:
                    ret = 1;
                    break;
                // 後方一致検索
                case 2:
                    break;
                // 曖昧検索
                case 3:
                    ret = 2;
                    break;
                // ハイフン無し完全一致
                case 4:
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 抽出条件入力情報クラスセッティング有無取得処理
        /// </summary>
        /// <param name="conditionInfo">抽出条件入力情報クラス</param>
        /// <remarks>
        /// <br>Note       : 抽出条件入力情報クラスに値が設定されているかどうかを取得します</br>
        /// <br>Programmer : 18012　Y.Sasaki</br>
        /// <br>Date       : 2007.1.12</br>
        /// </remarks>
        private bool IsExtractionConditionClassSetting(GoodsCndtn conditionInfo)
        {

            if ((conditionInfo.GoodsMakerCd != 0) ||
                (conditionInfo.BLGroupCode != 0) ||
                (conditionInfo.GoodsMGroup != 0) ||
                (conditionInfo.GoodsLGroup != 0) ||
                (conditionInfo.GoodsNo != "") ||
                (conditionInfo.GoodsName != "") ||
                (conditionInfo.GoodsNameKana != ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 抽出条件アイテムパネル高さ合計値取得処理
        /// </summary>
        /// <returns>パネル高さ合計値</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件パネルの高さの合計値を取得します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.10.25</br>
        /// </remarks>
        private int GetExtractConditionPanelTotalHeight()
        {
            int totalHeight = this.Condition_Header_panel.Height;

            // 抽出条件設定クラス配列から高さの合計値を取得
            foreach (ExtractConditionItem item in this._extractConditionItems.GetExtractConditionItemList())
            {
                string panelName = this.GetExtractConditionPanelName(item);
                Control targetControl = FindControl(this, panelName);

                if ((targetControl != null) && (targetControl is Panel))
                {
                    if (targetControl.Visible == true)
                    {
                        totalHeight += targetControl.Height;
                    }
                }
            }

            return totalHeight;
        }

        /// <summary>
        /// 抽出条件入力コントロール表示位置設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : スクロールバーの有無によって抽出条件入力コントロールの表示位置を設定します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.12</br>
        /// </remarks>
        private void ExtractConditionItemPosSetting()
        {
            // 初期化中は処理しない
            if (this._isInitializing == true)
            {
                return;
            }

            // 抽出条件設定リストが読み込まれていない場合は処理しない
            if (this._extractConditionItems == null)
            {
                return;
            }

            // 抽出条件アイテムパネルパネル高さ合計値取得
            int totalHeight = this.GetExtractConditionPanelTotalHeight();

            if (totalHeight > this.Condition_panel.Height)
            {
                // スクロールバーが表示されている場合

                this.MakerName_tEdit.Left = 15;
                this.GoodsLGroupName_tEdit.Left = 15;
                this.GoodsMGroupName_tEdit.Left = 15;
                this.BLGroupName_tEdit.Left = 15;
                this.GoodsNo_tEdit.Left = 15;
                //this.GoodsNameKana_tEdit.Left = 15; // 2010/07/13 Del
                this.GoodsKindCode_True_ultraCheckEditor.Left = 15;
                this.GoodsKindCode_False_ultraCheckEditor.Left = 80;
            }
            else
            {
                this.MakerName_tEdit.Left = 25;
                this.GoodsLGroupName_tEdit.Left = 25;
                this.GoodsMGroupName_tEdit.Left = 25;
                this.BLGroupName_tEdit.Left = 25;
                this.GoodsNo_tEdit.Left = 25;
                //this.GoodsNameKana_tEdit.Left = 25; // 2010/07/13 Del
                this.GoodsKindCode_True_ultraCheckEditor.Left = 25;
                this.GoodsKindCode_False_ultraCheckEditor.Left = 90;
            }
        }

        /// <summary>
        /// 抽出条件画面入力チェック処理
        /// </summary>
        /// <returns>チェック結果 (true:OK ,false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 入力されている抽出条件のチェックを行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.10.25</br>
        /// </remarks>
        private bool CheckExtractConditionScreen()
        {
            bool result = true;

            return result;
        }

        /// <summary>
        /// 抽出条件設定処理(メーカー)
        /// </summary>
        /// <param name="data">メーカーデータクラス</param>
        /// <param name="cndtn">検索条件クラス</param>
        private void SetExtractionConditionFromMaker(MakerUMnt data, ref GoodsCndtn cndtn)
        {
            if (data != null)
            {
                cndtn.GoodsMakerCd = data.GoodsMakerCd;
                cndtn.MakerName = data.MakerName;
            }
            else
            {
                cndtn.GoodsMakerCd = 0;
                cndtn.MakerName = "";
            }
        }

        /// <summary>
        /// 抽出条件設定処理(商品大分類)
        /// </summary>
        /// <param name="data">ユーザーガイドマスタクラス</param>
        /// <param name="cndtn">検索条件クラス</param>
        private void SetExtractionConditionFromLGoodsGanre(UserGdBd data, ref GoodsCndtn cndtn)
        {
            if (data != null)
            {
                cndtn.GoodsLGroup = data.GuideCode;
                cndtn.GoodsLGroupName = data.GuideName;
            }
            else
            {
                cndtn.GoodsLGroup = 0;
                cndtn.GoodsLGroupName = "";
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        /// <summary>
        /// 抽出条件設定処理(商品大分類)
        /// </summary>
        /// <param name="data">ユーザーガイドマスタ(ﾕｰｻﾞｰ)クラス</param>
        /// <param name="cndtn">検索条件クラス</param>
        private void SetExtractionConditionFromLGoodsGanreU(UserGdBdU data, ref GoodsCndtn cndtn)
        {
            if (data != null)
            {
                cndtn.GoodsLGroup = data.GuideCode;
                cndtn.GoodsLGroupName = data.GuideName;
            }
            else
            {
                cndtn.GoodsLGroup = 0;
                cndtn.GoodsLGroupName = "";
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

        /// <summary>
        /// 抽出条件設定処理(中分類)
        /// </summary>
        /// <param name="data">商品区分データクラス</param>
        /// <param name="cndtn">検索条件クラス</param>
        private void SetExtractionConditionFromMGoodsGanre(GoodsGroupU data, ref GoodsCndtn cndtn)
        {
            if (data != null)
            {
                cndtn.GoodsMGroup = data.GoodsMGroup;
                cndtn.GoodsMGroupName = data.GoodsMGroupName;
            }
            else
            {
                cndtn.GoodsMGroup = 0;
                cndtn.GoodsMGroupName = "";
            }
        }

        /// <summary>
        /// 抽出条件設定処理(BLグループコード)
        /// </summary>
        /// <param name="data">BLグループコードデータクラス</param>
        /// <param name="cndtn">検索条件クラス</param>
        private void SetExtractionConditionFromDGoodsGanre(BLGroupU data, ref GoodsCndtn cndtn)
        {
            if (data != null)
            {
                cndtn.BLGroupCode = data.BLGroupCode;
                cndtn.BLGroupName = data.BLGroupName;
            }
            else
            {
                cndtn.BLGroupCode = 0;
                cndtn.BLGroupName = "";
            }
        }
        #endregion

        // --------------------------------------------------
        #region < 検索関連 >

        /// <summary>
        /// 商品検索処理
        /// </summary> 
        /// <remarks>       
	    /// <br>Update Note: 2013/02/08 田建委</br>
	    /// <br>管理番号   : 10806793-00 2013/03/26配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
	    /// </remarks>
        private void Search()
        {
            const string ctPROCNM = "Search";

            int status = 0;

            // テーブルクリア
            this._resultDataView.Table.Rows.Clear();

            try
            {
                string msg;
                List<GoodsUnitData> goodsUnitDataList;

                // --- DEL 2008/09/02 -------------------------------->>>>>
                // 検索実行
                //status = this._goodsAcs.Search(this._goodsCndtn, out goodsUnitDataList, out msg);
                // --- DEL 2008/09/02 --------------------------------<<<<< 
                // --- ADD 2008/09/02 -------------------------------->>>>>
                this._goodsCndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;// ADD 田建委 2013/02/08 Redmine#34640
                // 検索実行
                status = this._goodsAcs.Search(this._goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out msg);
                // --- ADD 2008/09/02 --------------------------------<<<<< 

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.SetScreenFromDataList(goodsUnitDataList);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            //----- ADD 2013/04/01 田建委 Redmine#34640 ---------->>>>>
                            if (this._searchButtonFlg)
                            {
                                this.MsgDisp("条件に合致するデータが存在しません。", emErrorLevel.ERR_LEVEL_INFO);
                            }
                            //----- ADD 2013/04/01 田建委 Redmine#34640 ----------<<<<<
                            break;
                        }
                    default:
                        {
                            this.MsgDisp(msg, status, ctPROCNM, null);
                            break;
                        }
                }
                this._searchButtonFlg = true; // ADD 2013/04/01 田建委 Redmine#34640
            }
            catch (Exception ex)
            {
                this._searchButtonFlg = true; // ADD 2013/04/01 田建委 Redmine#34640
                this.MsgDisp(-1, ctPROCNM, ex);
            }
        }


        /// <summary>
        /// 検索結果画面設定処理
        /// </summary>
        /// <param name="list">検索結果データリスト</param>
        private void SetScreenFromDataList(List<GoodsUnitData> list)
        {
            // 商品連結クラスをテーブルに追加
            if ((list != null) && (list.Count > 0))
            {
                foreach (GoodsUnitData data in list)
                {
                    DataRow row;

                    // DataRowにセット
                    this.GoodsUnitDataToDataRow(data, out row);

                    // テーブルに追加
                    this._resultDataTable.Rows.Add(row);
                }

                // --- ADD dingjx 2011/12/08 redmine#26676 -------------------------------->>>>>
                if (this.DeleteIndication_CheckEditor.Checked == false)
                {
                    List<GoodsUnitData> _tmpList = new List<GoodsUnitData>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].LogicalDeleteCode == 0)
                            _tmpList.Add(list[i]);
                    }

                    //if (_tmpList.Count != 1 || this.GoodsNo_tEdit.Value.ToString().Equals(_preGoodsNo)) //DEL YANGMJ 2012/02/15 REDMINE#26676
                    // --- ADD YANGMJ 2012/02/15 REDMINE#26676 -------------------------------->>>>>
                    if (_tmpList.Count != 1 ||
                        !((this.GoodsNo_tEdit.Value == null && !string.IsNullOrEmpty(this._preGoodsNo)) || (this.GoodsNo_tEdit.Value != null && !this.GoodsNo_tEdit.Value.ToString().Equals(_preGoodsNo))
                        || (this.MakerName_tEdit.Value == null && !string.IsNullOrEmpty(this._preMakerCode)) || (this.MakerName_tEdit.Value != null && !this.MakerName_tEdit.Value.ToString().Equals(_preMakerCode))
                        || (this.GoodsName_tEdit.Value == null && !string.IsNullOrEmpty(this._preGoodsName)) || (this.GoodsName_tEdit.Value != null && !this.GoodsName_tEdit.Value.ToString().Equals(_preGoodsName))
                        || (this.GoodsLGroupName_tEdit.Value == null && !string.IsNullOrEmpty(this._preGoodsLGroup)) || (this.GoodsLGroupName_tEdit.Value != null && !this.GoodsLGroupName_tEdit.Value.ToString().Equals(_preGoodsLGroup))
                        || (this.GoodsMGroupName_tEdit.Value == null && !string.IsNullOrEmpty(this._preGoodsMGroup)) || (this.GoodsMGroupName_tEdit.Value != null && !this.GoodsMGroupName_tEdit.Value.ToString().Equals(_preGoodsMGroup))
                        || (this.BLGroupName_tEdit.Value == null && !string.IsNullOrEmpty(this._preBLGroupCode)) || (this.BLGroupName_tEdit.Value != null && !this.BLGroupName_tEdit.Value.ToString().Equals(_preBLGroupCode))))
                     
                    // --- ADD YANGMJ 2012/02/15 REDMINE#26676 --------------------------------<<<<<
                        return;

                    int _index = 0;
                    for (int i = 0; i < Result_ultraGrid.Rows.Count; i++)
                    {
                        if (Result_ultraGrid.Rows[i].Hidden == false)
                            _index = i;
                    }

                    this.EditGoodsEntry(Result_ultraGrid.Rows[_index]);
                    //this._preGoodsNo = this.GoodsNo_tEdit.Value.ToString(); //DEL YANGMJ 2012/02/15 REDMINE#26676
                }
                // Checked
                else
                {
                    //if (list.Count != 1 || this.GoodsNo_tEdit.Value.ToString().Equals(_preGoodsNo)) //DEL YANGMJ 2012/02/15 REDMINE#26676
                    // --- ADD YANGMJ 2012/02/15 REDMINE#26676 -------------------------------->>>>>
                    if (list.Count != 1 ||
                        !((this.GoodsNo_tEdit.Value == null && !string.IsNullOrEmpty(this._preGoodsNo)) || (this.GoodsNo_tEdit.Value != null && !this.GoodsNo_tEdit.Value.ToString().Equals(_preGoodsNo))
                        || (this.MakerName_tEdit.Value == null && !string.IsNullOrEmpty(this._preMakerCode)) || (this.MakerName_tEdit.Value != null && !this.MakerName_tEdit.Value.ToString().Equals(_preMakerCode))
                        || (this.GoodsName_tEdit.Value == null && !string.IsNullOrEmpty(this._preGoodsName)) || (this.GoodsName_tEdit.Value != null && !this.GoodsName_tEdit.Value.ToString().Equals(_preGoodsName))
                        || (this.GoodsLGroupName_tEdit.Value == null && !string.IsNullOrEmpty(this._preGoodsLGroup)) || (this.GoodsLGroupName_tEdit.Value != null && !this.GoodsLGroupName_tEdit.Value.ToString().Equals(_preGoodsLGroup))
                        || (this.GoodsMGroupName_tEdit.Value == null && !string.IsNullOrEmpty(this._preGoodsMGroup)) || (this.GoodsMGroupName_tEdit.Value != null && !this.GoodsMGroupName_tEdit.Value.ToString().Equals(_preGoodsMGroup))
                        || (this.BLGroupName_tEdit.Value == null && !string.IsNullOrEmpty(this._preBLGroupCode)) || (this.BLGroupName_tEdit.Value != null && !this.BLGroupName_tEdit.Value.ToString().Equals(_preBLGroupCode))))
                        // --- ADD YANGMJ 2012/02/15 REDMINE#26676 --------------------------------<<<<<
                        return;

                    this.EditGoodsEntry(Result_ultraGrid.Rows[0]);
                    //this._preGoodsNo = this.GoodsNo_tEdit.Value.ToString(); //DEL YANGMJ 2012/02/15 REDMINE#26676
                }
                // --- ADD dingjx 2011/12/08 redmine#26676 --------------------------------<<<<<
            }
        }

        /// <summary>
        /// 商品連結データクラス→DataRowコピー処理
        /// </summary>
        /// <param name="data">商品連結データクラス</param>
        /// <param name="row">格納するDataRow</param>
        private void GoodsUnitDataToDataRow(GoodsUnitData data, out DataRow row)
        {
            row = this._resultDataTable.NewRow();

            //// 作成日時
            //row[CT_CreateDateTime] = data.CreateDateTime;

            //// 更新日時
            //row[CT_UpdateDateTime] = data.UpdateDateTime;

            //// 企業コード
            //row[CT_EnterpriseCode] = data.EnterpriseCode;

            //// GUID
            //row[CT_FileHeaderGuid] = data.FileHeaderGuid;

            //// 更新従業員コード
            //row[CT_UpdEmployeeCode] = data.UpdEmployeeCode;

            //// 更新アセンブリID1
            //row[CT_UpdAssemblyId1] = data.UpdAssemblyId1;

            //// 更新アセンブリID2
            //row[CT_UpdAssemblyId2] = data.UpdAssemblyId2;

            //// 論理削除区分
            //row[CT_LogicalDeleteCode] = data.LogicalDeleteCode;

            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 削除日
            if (data.LogicalDeleteCode == 0)
            {
                row[CT_LogicalDeleteDate] = "";
            }
            else
            {
                row[CT_LogicalDeleteDate] = data.UpdateDateTimeJpInFormal;
            }
            // --- ADD 2008/09/02 --------------------------------<<<<<


            // 品番
            row[CT_GoodsNo] = data.GoodsNo;
            // 品名
            row[CT_GoodsName] = data.GoodsName;
            // 品名カナ
            row[CT_GoodsNameKana] = data.GoodsNameKana;
            // 商品大分類コード
            row[CT_GoodsLGroup] = data.GoodsLGroup;
            // 商品大分類名称
            row[CT_GoodsLGroupName] = data.GoodsLGroupName;
            // 商品中分類コード
            row[CT_GoodsMGroup] = data.GoodsMGroup;
            // 商品中分類名称
            row[CT_GoodsMGroupName] = data.GoodsMGroupName;
            // BLグループコード
            row[CT_BLGroupCode] = data.BLGroupCode;
            // BLグループコード名称
            row[CT_BLGroupName] = data.BLGroupName;
            // メーカーコード
            row[CT_MakerCode] = data.GoodsMakerCd;
            // メーカー名
            row[CT_MakerName] = data.MakerName;
            // JANコード
            row[CT_JAN] = data.Jan;
            // 商品属性
            row[CT_GoodsKindCode] = data.GoodsKindCode;

            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, data.GoodsPriceList);
            if (goodsPrice != null)
            {
                // 価格開始日
                row[CT_GoodsPricePriceStartDate] = goodsPrice.PriceStartDate.Date.ToString("yyyy年MM月dd日");
                // 標準価格
                row[CT_GoodsPriceListPrice] = goodsPrice.ListPrice;
                // オープン価格区分
                if (goodsPrice.OpenPriceDiv == 0)
                {
                    // 通常
                    row[CT_GoodsPriceOpenPriceDiv] = "通常";
                }
                else
                {
                    // オープン価格
                    row[CT_GoodsPriceOpenPriceDiv] = "オープン";
                }
            }

            // 商品属性名
            //GoodsKind goodsKind;
            //int status = this._goodsAcs.GetGoodsKind(this._enterpriseCode, data.GoodsKindCode, out goodsKind); 
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //	row[CT_GoodsKindName] = goodsKind.GoodsKindName;

            //// データ種類
            //string goodsOfferNm = string.Empty;
            //switch (data.GoodsOfferCd)
            //{
            //    case (int)GoodsAcs.emGoodsOfferUser.Offer:
            //        // 提供
            //        goodsOfferNm = "提供分";
            //        break;
            //    case (int)GoodsAcs.emGoodsOfferUser.User:
            //        // ユーザー
            //        goodsOfferNm = "ユーザー分";
            //        break;
            //}
            //row[CT_GoodsOfferCd] = goodsOfferNm;

            //// 新価格開始日
            //string strkey = "00"; // 価格区分(00=定価)
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    if (((GoodsPrice)data.GoodsPriceList[strkey]).NewPriceStartDate != DateTime.MinValue)
            //    {
            //        row[CT_NewPriceStartDate] = ((GoodsPrice)data.GoodsPriceList[strkey]).NewPriceStartDate.Date.ToString("yyyy年MM月dd日");
            //    }
            //    else
            //    {
            //        row[CT_NewPriceStartDate] = "";
            //    }
            //}
            //else
            //{
            //    row[CT_NewPriceStartDate] = "";
            //}

            //// 新定価
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    row[CT_NewPrice] = ((GoodsPrice)data.GoodsPriceList[strkey]).NewPrice;
            //}
            //else
            //{
            //    row[CT_NewPrice] = 0;
            //}

            //// 新オープン価格区分
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    if (((GoodsPrice)data.GoodsPriceList[strkey]).OpenPriceDiv == 0)
            //    {
            //        // 通常
            //        row[CT_OpenPriceDiv] = "通常";
            //    }
            //    else
            //    {
            //        // オープン価格
            //        row[CT_OpenPriceDiv] = "オープン";
            //    }
            //}
            //else
            //{
            //    row[CT_OpenPriceDiv] = "未設定";
            //}

            //// 旧定価
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    row[CT_OldPrice] = ((GoodsPrice)data.GoodsPriceList[strkey]).OldPrice;
            //}
            //else
            //{
            //    row[CT_OldPrice] = 0;
            //}

            //// 旧オープン価格区分
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    if (((GoodsPrice)data.GoodsPriceList[strkey]).OldOpenPriceDiv == 0)
            //    {
            //        // 通常
            //        row[CT_OldOpenPriceDiv] = "通常";
            //    }
            //    else
            //    {
            //        // オープン価格
            //        row[CT_OldOpenPriceDiv] = "オープン";
            //    }
            //}
            //else
            //{
            //    row[CT_OldOpenPriceDiv] = "未設定";
            //}

            // BL商品コード
            row[CT_BLGoodsCode] = data.BLGoodsCode;

            // 商品連結データクラス
            row[CT_GoodsUitData] = data.Clone();

            // 価格情報データテーブル
            row[CT_GoodsPriceList] = data.GoodsPriceList;

            // 選択状態
            row[CT_Select] = false;

            // DataRowを格納
            row[CT_DataRow] = row;
        }

        // --- ADD 2009/09/02 -------------------------------->>>>>
        /// <summary>
        /// グリッドのフィルタリング処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 論理削除フラグによるグリッド列のフィルタリングを行います。
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        private void AddGridFiltering()
        {

            int index = -1;

            // 削除日列のindexを取得
            for (int i = 0; i < this._resultDataSet.Tables[CT_TBL_RESULT_TITLE].Columns.Count; i++)
            {
                if (_resultDataSet.Tables[CT_TBL_RESULT_TITLE].Columns[i].ColumnName == CT_LogicalDeleteDate)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                // 行フィルタがバンドに基づいている場合、バンドの列フィルタを外す。
                Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.Result_ultraGrid.DisplayLayout.Bands[0].ColumnFilters;
                columnFilters.ClearAllFilters();

                if (DeleteIndication_CheckEditor.Checked == false)
                {
                    // 空白とNull以外をフィルタに設定する
                    columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
                    columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
                    columnFilters[index].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
                }
            }
        }
        // --- ADD 2009/09/02 --------------------------------<<<<<

        #endregion

        // --------------------------------------------------
        #region < 商品入力関連 >

        /// <summary>
        /// 商品入力画面起動
        /// </summary>
        /// <param name="targetRow">編集する対象データ行</param>
        private void EditGoodsEntry(Infragistics.Win.UltraWinGrid.UltraGridRow targetRow)
        {
            if (targetRow == null) return;
            GoodsUnitData entryData = (targetRow.Cells[CT_GoodsUitData].Value != DBNull.Value) ? (GoodsUnitData)targetRow.Cells[CT_GoodsUitData].Value : null;

            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 論理削除チェック
            if (entryData.LogicalDeleteCode != 0 && entryData.LogicalDeleteCode != 1)
            {
                this.MsgDisp("選択した商品は既に削除されています。", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                return;
            }
            // --- ADD 2008/09/02 --------------------------------<<<<< 

            // 商品入力起動
            this.InputGoodsEntry(ref entryData);
        }

        /// <summary>
        /// 商品入力画面起動
        /// </summary>
        /// <param name="entryData">編集するデータ[null値は新規]</param>
        private void InputGoodsEntry(ref GoodsUnitData entryData)
        {
            // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
            if (this._mode == 0)
            {
                // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
            if (this._goodsInputForm == null)
            {
                // 2009.02.18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //this._goodsInputForm = new MAKHN09280UA();
                this._goodsInputForm = new MAKHN09280UA(this._goodsAcs);
                // 2009.02.18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                # region [マスメンＵＩ用初期読み込み]
                const string ctPROCNM = "InputGoodsEntry";
                string msg;
                int status = this._goodsAcs.SearchInitialForMst(this._enterpriseCode, this._loginSectionCode, out msg);
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
                            this.MsgDisp(msg, status, ctPROCNM);
                            break;
                        }
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
            }

            // 商品入力画面を起動する
            DialogResult dr = this._goodsInputForm.ShowDialog(this, ref entryData);
                // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
            }
            else
            {
                if (this._goodsInputForm2 == null)
                {
                    this._goodsInputForm2 = new PMKHN09380UA(this._goodsAcs);

                    # region [マスメンＵＩ用初期読み込み]
                    const string ctPROCNM = "InputGoodsEntry";
                    string msg;
                    int status = this._goodsAcs.SearchInitialForMst(this._enterpriseCode, this._loginSectionCode, out msg);
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
                                this.MsgDisp(msg, status, ctPROCNM);
                                break;
                            }
                    }
                    # endregion
                }
                DialogResult dr = this._goodsInputForm2.ShowDialog(this, ref entryData);
            }
            // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
        }

        #endregion

        // --- ADD 2008/09/02 -------------------------------->>>>>
        #region 論理削除
        /// <summary>
        /// 論理削除実行
        /// </summary>
        /// <param name="entryData">論理削除するデータ</param>
        private void LogicalDelete(Infragistics.Win.UltraWinGrid.UltraGridRow targetRow)
        {
            // 削除ボタンが押下不可であれば処理なし
            if (!this.Main_ultraToolbarsManager.Tools[CT_BUTTONTOOL_LOGICALDELETE].SharedProps.Enabled)
            {
                return;
            }

            // 選択行がなければ処理なし
            if (targetRow == null)
            {
                return;
            }

            // 選択行がフィルタされている場合は処理なし
            if (targetRow.IsFilteredOut)
            {
                return;
            }

            // 処理対象データの取得
            GoodsUnitData logicalDeleteData =
                    (targetRow.Cells[CT_GoodsUitData].Value != DBNull.Value) ? (GoodsUnitData)targetRow.Cells[CT_GoodsUitData].Value : null;

            // 選択行が既に削除済かチェック
            if (logicalDeleteData.LogicalDeleteCode != 0)
            {
                this.MsgDisp("選択した商品は既に削除されています。", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                return;
            }

            // 確認ダイアログ表示
            DialogResult result = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION,
            this.Name, "選択した行を削除しますか？", 0, MessageBoxButtons.YesNo,
            MessageBoxDefaultButton.Button2);

            // 論理削除処理実行
            if (result == DialogResult.Yes)
            {
                // リモートアクセスモードにする
                this._goodsAcs.IsLocalDBRead = false;

                GoodsUnitData deleteData =
                    (targetRow.Cells[CT_GoodsUitData].Value != DBNull.Value) ? (GoodsUnitData)targetRow.Cells[CT_GoodsUitData].Value : null;

                string msg;
                this._goodsAcs.Delete(ref deleteData, out msg);

                // フィルタ処理を再実行
                this.AddGridFiltering();
            }
        }

        #endregion
        // --- ADD 2008/09/02 --------------------------------<<<<<

        // --------------------------------------------------
        #region < イベント関連 >

        /// <summary>
        /// 商品データ変更イベント
        /// </summary>
        /// <param name="seder">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void ChangedGoodsDataEvent(object seder, GoodsAcsEventArgs e)
        {
            GoodsUnitData data = e.Data as GoodsUnitData;

            if (data == null) return;

            DataView dataView = new DataView(this._resultDataTable);
            dataView.RowFilter = String.Format("{0} = {1} AND {2} = '{3}'", CT_MakerCode, data.GoodsMakerCd, CT_GoodsNo, data.GoodsNo);

            if (dataView.Count == 0) return;

            //// 作成日時
            //row[CT_CreateDateTime] = data.CreateDateTime;

            //// 更新日時
            //row[CT_UpdateDateTime] = data.UpdateDateTime;

            //// 企業コード
            //row[CT_EnterpriseCode] = data.EnterpriseCode;

            //// GUID
            //row[CT_FileHeaderGuid] = data.FileHeaderGuid;

            //// 更新従業員コード
            //row[CT_UpdEmployeeCode] = data.UpdEmployeeCode;

            //// 更新アセンブリID1
            //row[CT_UpdAssemblyId1] = data.UpdAssemblyId1;

            //// 更新アセンブリID2
            //row[CT_UpdAssemblyId2] = data.UpdAssemblyId2;

            //// 論理削除区分
            //row[CT_LogicalDeleteCode] = data.LogicalDeleteCode;

            // --- ADD 2008/09/02 -------------------------------->>>>>
            // 論理削除列
            if (data.LogicalDeleteCode == 0)
            {
                dataView[0].Row[CT_LogicalDeleteDate] = "";
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            else if (data.LogicalDeleteCode == 3)
            {
                // 物理削除の場合
                _resultDataTable.Rows.Remove(dataView[0].Row);
                return;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD
            else
            {
                dataView[0].Row[CT_LogicalDeleteDate] = data.UpdateDateTimeJpInFormal;
            }

            // --- ADD 2008/09/02 --------------------------------<<<<<
            // 品番
            dataView[0].Row[CT_GoodsNo] = data.GoodsNo;
            // 品名
            dataView[0].Row[CT_GoodsName] = data.GoodsName;
            // 品名dカナ
            dataView[0].Row[CT_GoodsNameKana] = data.GoodsNameKana;
            // 商品大分類コード
            dataView[0].Row[CT_GoodsLGroup] = data.GoodsLGroup;
            // 商品大分類名称
            dataView[0].Row[CT_GoodsLGroupName] = data.GoodsLGroupName;
            // 商品中分類コード
            dataView[0].Row[CT_GoodsMGroup] = data.GoodsMGroup;
            // 商品中分類名称
            dataView[0].Row[CT_GoodsMGroupName] = data.GoodsMGroupName;
            // BLグループコード
            dataView[0].Row[CT_BLGroupCode] = data.BLGroupCode;
            // BLグループコード名称
            dataView[0].Row[CT_BLGroupName] = data.BLGroupName;
            // メーカーコード
            dataView[0].Row[CT_MakerCode] = data.GoodsMakerCd;
            // メーカー名
            dataView[0].Row[CT_MakerName] = data.MakerName;
            // JANコード
            dataView[0].Row[CT_JAN] = data.Jan;
            // 商品属性
            dataView[0].Row[CT_GoodsKindCode] = data.GoodsKindCode;

            GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, data.GoodsPriceList);
            if (goodsPrice != null)
            {
                // 価格開始日
                dataView[0][CT_GoodsPricePriceStartDate] = goodsPrice.PriceStartDate.Date.ToString("yyyy年MM月dd日");
                // 標準価格
                dataView[0][CT_GoodsPriceListPrice] = goodsPrice.ListPrice;
                // オープン価格区分
                if (goodsPrice.OpenPriceDiv == 0)
                {
                    // 通常
                    dataView[0][CT_GoodsPriceOpenPriceDiv] = "通常";
                }
                else
                {
                    // オープン価格
                    dataView[0][CT_GoodsPriceOpenPriceDiv] = "オープン";
                }
            }

            // 商品属性名
            //GoodsKind goodsKind;
            //int status = this._goodsAcs.GetGoodsKind(this._enterpriseCode, data.GoodsKindCode, out goodsKind);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //	dataView[0].Row[CT_GoodsKindName] = goodsKind.GoodsKindName;

            //// データ種類
            //string goodsOfferNm = string.Empty;
            //switch (data.GoodsOfferCd)
            //{
            //    case (int)GoodsAcs.emGoodsOfferUser.Offer:
            //        // 提供
            //        goodsOfferNm = "提供分";
            //        break;
            //    case (int)GoodsAcs.emGoodsOfferUser.User:
            //        // ユーザー
            //        goodsOfferNm = "ユーザー分";
            //        break;
            //}
            //dataView[0].Row[CT_GoodsOfferCd] = goodsOfferNm;

            //// 新価格開始日
            //string strkey = "00"; // 価格区分(00=定価)
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    if (((GoodsPrice)data.GoodsPriceList[strkey]).NewPriceStartDate != DateTime.MinValue)
            //    {
            //        dataView[0].Row[CT_NewPriceStartDate] = ((GoodsPrice)data.GoodsPriceList[strkey]).NewPriceStartDate.ToString("yyyy年MM月dd日");
            //    }
            //    else
            //    {
            //        dataView[0].Row[CT_NewPriceStartDate] = "";
            //    }
            //}
            //else
            //{
            //    dataView[0].Row[CT_NewPriceStartDate] = "";
            //}

            //// 新定価
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    dataView[0].Row[CT_NewPrice] = ((GoodsPrice)data.GoodsPriceList[strkey]).NewPrice;
            //}
            //else
            //{
            //    dataView[0].Row[CT_NewPrice] = "";
            //}

            //// 新オープン価格区分
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    if (((GoodsPrice)data.GoodsPriceList[strkey]).OpenPriceDiv == 0)
            //    {
            //        // 通常
            //        dataView[0].Row[CT_OpenPriceDiv] = "通常";
            //    }
            //    else
            //    {
            //        // オープン価格
            //        dataView[0].Row[CT_OpenPriceDiv] = "オープン";
            //    }
            //}
            //else
            //{
            //    dataView[0].Row[CT_OpenPriceDiv] = "未設定";
            //}

            //// 旧定価
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    dataView[0].Row[CT_OldPrice] = ((GoodsPrice)data.GoodsPriceList[strkey]).OldPrice;
            //}
            //else
            //{
            //    dataView[0].Row[CT_OldPrice] = 0;
            //}

            //// 旧オープン価格区分
            //if (data.GoodsPriceList.Contains(strkey))
            //{
            //    if (((GoodsPrice)data.GoodsPriceList[strkey]).OldOpenPriceDiv == 0)
            //    {
            //        // 通常
            //        dataView[0].Row[CT_OldOpenPriceDiv] = "通常";
            //    }
            //    else
            //    {
            //        // オープン価格
            //        dataView[0].Row[CT_OldOpenPriceDiv] = "オープン";
            //    }
            //}
            //else
            //{
            //    dataView[0].Row[CT_OldOpenPriceDiv] = "未設定";
            //}

            // BL商品コード
            dataView[0].Row[CT_BLGoodsCode] = data.BLGoodsCode;

            // 商品連結データクラス
            dataView[0].Row[CT_GoodsUitData] = data.Clone();

            // 価格情報データリスト
            dataView[0].Row[CT_GoodsPriceList] = data.GoodsPriceList;

        }

        #endregion

        // --------------------------------------------------
        #region < UltraTree関連 >>

        /// <summary>
        /// Invalidate メソッド
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 再描画が必要な場合に発生します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Note       : 2007.1.11</br>
        /// </remarks>
        private void UltraTree_DropHightLight_DrawFilter_Invalidate(object sender, EventArgs e)
        {
            // DropHightLightが変更した場合、コントロールに再描画の通知が必要となります。
            // ここではんトロールの再描画を通知します。
            this.ExtractConditionSetting_ultraTree.Invalidate();
        }

        /// <summary>
        /// QueryStateAllowedForNode
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : このイベントでは、特定のノードにおいてどのようなドロップ操作をするか、指定できます。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Note       : 2007.1.11</br>
        /// </remarks>
        private void UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode(object sender, UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventArgs e)
        {
            e.StatesAllowed = DropLinePositionEnum.AboveNode | DropLinePositionEnum.BelowNode;
        }

        /// <summary>
        /// IsAnyParentSelected メソッド
        /// </summary>
        /// <param name="node">対象ノード</param>
        /// <returns>選択・未選択</returns>
        private bool IsAnyParentSelected(UltraTreeNode node)
        {
            bool result = false;

            // 選択されている親元が選択されているかどうか確認する
            UltraTreeNode parentNode = null;

            parentNode = node.Parent;
            while (parentNode != null)
            {
                if (parentNode.Selected == true)
                {
                    result = true;
                    break;
                }
                else
                {
                    parentNode = parentNode.Parent;
                }
            }

            return result;
        }

        #endregion

        // --------------------------------------------------
        #region < メッセージ表示 >

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procNm">発生メソッドID</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.12</br>
        /// </remarks>
        private DialogResult MsgDisp(string message, int status, string procNm)
        {
            return this.MsgDisp(message, status, procNm, emErrorLevel.ERR_LEVEL_STOPDISP, null);
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="procNm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.12</br>
        /// </remarks>
        private DialogResult MsgDisp(int status, string procNm, Exception ex)
        {
            return this.MsgDisp("", status, procNm, emErrorLevel.ERR_LEVEL_STOPDISP, ex);
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procNm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.12</br>
        /// </remarks>
        private DialogResult MsgDisp(string message, int status, string procNm, Exception ex)
        {
            return this.MsgDisp(message, status, procNm, emErrorLevel.ERR_LEVEL_STOPDISP, ex);
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procNm">発生メソッドID</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="ex">例外情報</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.12</br>
        /// </remarks>
        private DialogResult MsgDisp(string message, int status, string procNm, emErrorLevel iLevel, Exception ex)
        {
            string errMessage = message;
            // 例外クラスがセットされている場合
            if (ex != null)
            {
                // メッセージがある場合は改行
                if (String.IsNullOrEmpty(message) == false)
                {
                    errMessage += "\r\n";
                }
                // 例外メッセージを結合
                errMessage += ex.Message;
            }

            // メッセージ表示
            return TMsgDisp.Show(
                iLevel,                               // エラーレベル
                this.GetType().ToString(),            // アセンブリＩＤまたはクラスＩＤ
                this.Text,                            // プログラム名称
                procNm,                               // 処理名称
                "",                                   // オペレーション
                errMessage,                           // 表示するメッセージ
                status,                               // ステータス値
                null,                                 // エラーが発生したオブジェクト
                MessageBoxButtons.OK,                 // 表示するボタン
                MessageBoxDefaultButton.Button1);    // 初期表示ボタン
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="iLevel">エラーレベル</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.12</br>
        /// </remarks>
        private DialogResult MsgDisp(string message, emErrorLevel iLevel)
        {
            // メッセージ表示
            return TMsgDisp.Show(
                this,                               // 親ウィンドウフォーム
                iLevel,                             // エラーレベル
                this.GetType().ToString(),          // アセンブリＩＤまたはクラスＩＤ
                message,                            // 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OK);             // 表示するボタン
        }

        #endregion

        // --------------------------------------------------
        #region < メッセージ表示 >

        /// <summary>
        /// メインフォーム取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note		:</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.03.20</br>
        /// <br></br>
        /// </remarks>
        private Form GetMainForm()
        {
            Form mainForm = null;

            IntPtr hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (hWnd != IntPtr.Zero)
            {
                Control control = Form.FromHandle(hWnd);
                if ((control != null) && (!control.IsDisposed))
                {
                    mainForm = (Form)control;
                }
            }

            if (mainForm == null)
            {
                mainForm = Form.ActiveForm;
                if (mainForm == null)
                {
                    if (System.Windows.Forms.Application.OpenForms.Count > 0)
                    {
                        mainForm = System.Windows.Forms.Application.OpenForms[0];
                    }

                    // メッセージをすべて処理してActiveForm取得
                    if (mainForm == null)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        mainForm = Form.ActiveForm;
                    }
                }
            }

            return mainForm;
        }

        #endregion

        // --------------------------------------------------
        #region < 終了 >

        /// <summary>
        /// 終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了処理を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.15</br>
        /// </remarks>
        private void EndProcess()
        {
            if (this.IsMdiChild)
            {
                this.MdiParent.Close();
            }
            else
            {
                if (this._callMode == (int)emGoodsCallMode.MenuStartMode)
                {
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        /// <summary>
        /// 終了前通知処理
        /// </summary>
        /// <param name="parameter">パラメータオブジェクト</param>
        /// <returns>0:OK, 0以外:NG (戻り値はMethodResult)</returns>
        /// <remarks>
        /// <br>Note       : 終了する前に、変更を許可するかの判断を行う。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.17</br>
        /// <br>UpdateNote : 2011/12/08 丁建雄</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
        /// <br>           : Redmine#26676 商品検索/検索モードの設定</br>
        /// </remarks>
        private void BeforeClosing()
        {

            // 初期化中は処理をしない(正常終了)
            if (this._isInitializing == true) return;

            // 設定保存処理

            // 抽出条件設定クラスリスト構築処理
            List<ExtractConditionItem> extractConditionItemList = this.ExtractConditionItemListConstruction();
            this._extractConditionItems.SetExtractConditionItemList(extractConditionItemList);

            // 抽出条件設定クラスリストをXMLにシリアライズする
            GoodsExtractConditionItems.Serialize(this._extractConditionItems.GetExtractConditionItemList(), CT_FILENAME_EXTRACTCONDITION);

            // --- ADD dingjx 2011/12/08 redmine#26676 -------------------------------->>>>>
            this.SetGoodsNo(this.GoodsCodeSearchType_ultraOptionSet.CheckedIndex);
            // --- ADD dingjx 2011/12/08 redmine#26676 --------------------------------<<<<<

            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns);
            this._colDisplayStatusCollection.SetColDisplayStatusList(colDisplayStatusList);

            // 列表示状態クラスリストをXMLにシリアライズする
            GoodsInputColDisplayStatusCollection.Serialize(this._colDisplayStatusCollection.GetColDisplayStatusList(), CT_FILENAME_COLDISPLAYSTATUS);
        }



        #endregion

        // --- ADD dingjx 2011/12/08 redmine#26676 -------------------------------->>>>>
        #region Redmine #26676
        /// <summary>
        /// 前次選択の品番検索条件を取得
        /// </summary>
        /// <returns>品番検索条件</returns>
        /// <remarks>
        /// <br>Note       : 前次選択の品番検索条件を取得</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/12/08</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分　Redmine#26676 商品検索/検索モードの設定</br>
        /// </remarks>
        private int GetGoodsNo()
        {
            int goodsNo = 0;
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_FILENAME_GOODSNO);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }

                    _uiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    goodsNo = Convert.ToInt32(_uiDataSet.Tables["GoodsNo"].Rows[0][0].ToString());
                }
            }
            catch { }
            return goodsNo;
        }

        /// <summary>
        /// 選択した品番検索条件をXMLファイルに保存
        /// </summary>
        /// <param name="goodsNo">品番検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択した品番検索条件をXMLファイルに保存</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/12/08</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分　Redmine#26676 商品検索/検索モードの設定</br>
        /// </remarks>
        private int SetGoodsNo(int goodsNo)
        {
            int status = 0;
            try
            {
                if (!string.IsNullOrEmpty(goodsNo.ToString()))
                {
                    string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_FILENAME_GOODSNO);
                    fileName = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName);
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }
                    if (_uiDataSet.Tables["GoodsNo"] == null)
                    {
                        DataTable dt = new DataTable("GoodsNo");
                        DataColumn col = new DataColumn("SelectedIndex", typeof(string));
                        dt.Columns.Add(col);
                        _uiDataSet.Tables.Add(dt);
                    }
                    _uiDataSet.Tables["GoodsNo"].Clear();
                    DataRow row = _uiDataSet.Tables["GoodsNo"].NewRow();
                    row[0] = goodsNo;
                    _uiDataSet.Tables["GoodsNo"].Rows.Add(row);
                    _uiDataSet.WriteXml(fileName);
                }
            }
            catch
            {
                status = 1000;
            }
            return status;
        }
        #endregion Redmine #26676
        // --- ADD dingjx 2011/12/08 redmine#26676 --------------------------------<<<<<

        #endregion

        //================================================================================
        //  コントロールイベント
        //================================================================================
        #region Control Event

        #region < Form_Loadイベント >

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAKHN04110UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // 画面初期設定処理
            this.InitializeDisplaySetting();

            // 初期フォーカスセット
            this.Initial_timer.Enabled = true;
        }

        #endregion

        #region < UltraButtonClick系イベント >

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Search_UButton_Click(object sender, EventArgs e)
        {
            // --- ADD 2009/01/06 障害ID:6079対応------------------------------------------------------>>>>>
            tRetKeyControl1_ChangeFocus(this.MakerName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.MakerName_tEdit, this.Search_UButton));
            tRetKeyControl1_ChangeFocus(this.GoodsNo_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsNo_tEdit, this.Search_UButton));
            tRetKeyControl1_ChangeFocus(this.GoodsName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsName_tEdit, this.Search_UButton));
            //tRetKeyControl1_ChangeFocus(this.GoodsNameKana_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsNameKana_tEdit, this.Search_UButton));    // 2010/07/13 Del
            tRetKeyControl1_ChangeFocus(this.GoodsLGroupName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsLGroupName_tEdit, this.Search_UButton));
            tRetKeyControl1_ChangeFocus(this.GoodsMGroupName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsMGroupName_tEdit, this.Search_UButton));
            tRetKeyControl1_ChangeFocus(this.BLGroupName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.BLGroupName_tEdit, this.Search_UButton));
            // --- ADD 2009/01/06 障害ID:6079対応------------------------------------------------------<<<<<

            this.Search_timer.Enabled = true;
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// </remarks>
        private void MakerGuide_UButton_Click(object sender, EventArgs e)
        {
            MakerUMnt maker;

            // ガイド起動
            int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            if (status != 0) return;

            if (!this.MultiSelect_ultraCheckEditor.Checked)
            {
                this._goodsCndtn = this._goodsCndtn.Create();
            }

            // 抽出条件入力情報クラス情報設定処理（メーカー名称クラスより）
            this.SetExtractionConditionFromMaker(maker, ref this._goodsCndtn);

            // 検索条件入力コントロール情報設定
            this.SettingExtractConditionItemInfo(this._goodsCndtn);

            if (this.AutoSearch_ultraCheckEditor.Checked)
            {
                this._searchButtonFlg = false; // ADD 2013/04/01 田建委 Redmine#34640
                this.Search_UButton_Click(this.Search_UButton, new EventArgs());
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
            // 次項目フォーカス移動
            Control nextControl = GetNextPanelControl(MakerName_tEdit);
            if (nextControl != null) nextControl.Focus();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
        }

        /// <summary>
        /// BLグループコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// </remarks>
        private void DetailGoodsGanreGuide_UButton_Click(object sender, EventArgs e)
        {
            // ガイド起動
            BLGroupU bLGroupU;

            int status = this._goodsAcs.ExecuteBLGroupGuid(this._enterpriseCode, out bLGroupU);

            if (status != 0) return;

            if (!this.MultiSelect_ultraCheckEditor.Checked)
            {
                this._goodsCndtn = this._goodsCndtn.Create();
            }

            // 抽出条件入力情報クラス情報設定処理
            this.SetExtractionConditionFromDGoodsGanre(bLGroupU, ref this._goodsCndtn);

            // 検索条件入力コントロール情報設定
            this.SettingExtractConditionItemInfo(this._goodsCndtn);

            if (this.AutoSearch_ultraCheckEditor.Checked)
            {
                this._searchButtonFlg = false; // ADD 2013/04/01 田建委 Redmine#34640
                this.Search_UButton_Click(this.Search_UButton, new EventArgs());
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
            // 次項目フォーカス移動
            Control nextControl = GetNextPanelControl(BLGroupName_tEdit);
            if (nextControl != null) nextControl.Focus();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
        }

        /// <summary>
        /// 商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// </remarks>
        private void MediumGoodsGanreGuide_UButton_Click(object sender, EventArgs e)
        {
            // ガイド起動
            GoodsGroupU goodsMGroup;

            int status = this._goodsAcs.ExecuteGoodsMGroupGuid(this._enterpriseCode, out goodsMGroup);

            if (status != 0) return;

            if (!this.MultiSelect_ultraCheckEditor.Checked)
            {
                this._goodsCndtn = this._goodsCndtn.Create();
            }

            // 抽出条件入力情報クラス情報設定処理
            this.SetExtractionConditionFromMGoodsGanre(goodsMGroup, ref this._goodsCndtn);

            // 検索条件入力コントロール情報設定
            this.SettingExtractConditionItemInfo(this._goodsCndtn);

            if (this.AutoSearch_ultraCheckEditor.Checked)
            {
                this._searchButtonFlg = false; // ADD 2013/04/01 田建委 Redmine#34640
                this.Search_UButton_Click(this.Search_UButton, new EventArgs());
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
            // 次項目フォーカス移動
            Control nextControl = GetNextPanelControl(GoodsMGroupName_tEdit);
            if (nextControl != null) nextControl.Focus();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
        }

        /// <summary>
        /// 商品大分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// </remarks>
        private void LargeGoodsGanreGuide_UButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGdBd;

            // ガイド起動
            int status = this._goodsAcs.ExecuteUserGuideGuid(this._enterpriseCode, out userGdBd, (int)GoodsAcs.emUserGuideCode.GoodsLGroup);

            if (status != 0) return;

            if (!this.MultiSelect_ultraCheckEditor.Checked)
            {
                this._goodsCndtn = this._goodsCndtn.Create();
            }

            // 抽出条件入力情報クラス情報設定処理（商品区分グループクラスより）
            this.SetExtractionConditionFromLGoodsGanre(userGdBd, ref this._goodsCndtn);

            // 検索条件入力コントロール情報設定
            this.SettingExtractConditionItemInfo(this._goodsCndtn);

            if (this.AutoSearch_ultraCheckEditor.Checked)
            {
                this._searchButtonFlg = false; // ADD 2013/04/01 田建委 Redmine#34640
                this.Search_UButton_Click(this.Search_UButton, new EventArgs());
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
            // 次項目フォーカス移動
            Control nextControl = GetNextPanelControl(GoodsLGroupName_tEdit);
            if (nextControl != null) nextControl.Focus();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
        }

        /// <summary>
        /// 全データ行選択・非選択ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllSelectUnSelect_uButton_Click(object sender, EventArgs e)
        {
            bool isSelected = false;

            if (sender == this.AllSelect_uButton)
                isSelected = true;
            else
                isSelected = false;

            for (int i = 0; i < this._resultDataView.Count; i++)
            {
                DataRow dataRow = this._resultDataView[i].Row;

                if ((bool)dataRow[CT_Select] != isSelected)
                {
                    dataRow[CT_Select] = isSelected;
                }
            }

        }

        /// <summary>
        /// 表示行選択・非選択ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispSelectUnSelect_uButton_Click(object sender, EventArgs e)
        {
            bool isSelected = false;

            if (sender == this.DispSelect_uButton)
                isSelected = true;
            else
                isSelected = false;

            // フィルター除外行を取得      
            Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                this.Result_ultraGrid.Rows.GetFilteredInNonGroupByRows();

            // 表示行は存在するか？j
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
            {
                DataRow row = (_row.Cells[CT_DataRow].Value != DBNull.Value) ? (DataRow)_row.Cells[CT_DataRow].Value : null;

                if (row != null && (bool)row[CT_Select] != isSelected)
                    row[CT_Select] = isSelected;

            }
        }

        #endregion

        #region < TComboEditorイベント >

        /// <summary>
        /// フォントサイズ変更イベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 文字サイズを変更
            this.Result_ultraGrid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.FontSize_tComboEditor.Value;

            // 初期化中は列幅調整しない
            if (this._isInitializing == false)
            {
                // リサイズ
                this.Resize_timer.Enabled = true;
            }
        }

        #endregion

        #region < UltraGrid系のイベント関連 >

        /// <summary>
        /// 抽出結果グリッドレイアウト初期化 イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : データソースからコントロールにデータがロードされるときなど、
        ///                   表示レイアウトが初期化されるときに発生します。 </br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2007.1.11</br>
        /// </remarks>
        private void Result_ultraGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            e.Layout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

            //// スクロールヒントの表示フィールド
            //e.Layout.Bands[0].ScrollTipField = CT_GoodsName;

            // 列ヘッダの表示スタイル
            e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

            // セルの境界線スタイルの設定 
            e.Layout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;

            // 行の境界線スタイルの設定 
            e.Layout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;

            // データ行の追加許可
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // データ行の削除許可
            e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            // データ行の更新許可
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            // 列移動の変更
            e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.Default;
            // 固定列ヘッダ
            e.Layout.UseFixedHeaders = true;

            // セルクリック時実行アクション
            e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;

            //// ActiveCellの外観設定
            //e.Layout.Override.ActiveCellAppearance.BackColor = Color.FromArgb(247, 227, 156);

            //// ヘッダーの外観設定
            //e.Layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            //e.Layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            //e.Layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //e.Layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            //e.Layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            //e.Layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            //// 行の外観設定
            //e.Layout.Override.RowAppearance.BackColor = Color.White;

            //// 行の境界線
            //e.Layout.Override.RowAppearance.BorderColor = Color.FromArgb(1, 68, 208);

            //// 1行おきの外観設定
            //e.Layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // 行セレクターの表示非表示
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            //// 行セレクターの外観設定
            //e.Layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            //e.Layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            //e.Layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //// 行選択設定 行選択無しモード(アクティブのみ)
            //e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            //e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            //e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
            //e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            //e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            //e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
            e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

            //// 選択行の外観設定
            //e.Layout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            //e.Layout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            //e.Layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //// 行選択時は、全ての列の文字色は黒とする(この記述ないと白色になって見難いとの批判があったため。)
            //e.Layout.Override.SelectedRowAppearance.ForeColor = Color.Black;

            // 行フィルターの設定
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

            // テキストのレンタリング設定
            e.Layout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.Character;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
            // シングルバンドタイプにする（行コネクタを非表示にする為）
            e.Layout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Result_ultraGrid_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.Result_ultraGrid.ActiveCell != null)
            {
                this.Result_ultraGrid.Selected.Rows.Clear();
                this.Result_ultraGrid.ActiveRow = this.Result_ultraGrid.ActiveCell.Row;
                this.Result_ultraGrid.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// グリッドダブルクリック イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : コントロールがダブルクリックされた際に発生します。 </br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2007.01.18</br>
        /// </remarks>
        private void Result_ultraGrid_DoubleClick(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
            //if (this._callMode != (int)emGoodsCallMode.GuideMode) return;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL

            # region [選択行の取得]
            // 複数選択モードの場合以外
            if (this._isMultiSelect) return;

            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスが入った最後の要素を取得します。
            Infragistics.Win.UIElement lastElementEntered = targetGrid.DisplayLayout.UIElement.LastElementEntered;

            // チェーン内に RowUIElement があるかどうかを調べます。
            Infragistics.Win.UltraWinGrid.RowUIElement rowElement;
            if (lastElementEntered is Infragistics.Win.UltraWinGrid.RowUIElement)
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered;
            else
            {
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered.GetAncestor(typeof(Infragistics.Win.UltraWinGrid.RowUIElement));
            }

            if (rowElement == null) return;

            // 要素から行を取得します。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow = (Infragistics.Win.UltraWinGrid.UltraGridRow)rowElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            // 行が返されなかった場合、マウスは行の上にありません。
            if (objRow == null)
                return;

            // マウスは行の上にあります。

            // この部分はオプションです。しかし、ユーザーが行セレクタ間の行を
            // ダブルクリックした場合、デフォルトで行のサイズを自動調整します。
            // その場合、通常、ダブルクリックコードは記述しません。

            // 現在のマウスポインタの位置を取得してグリッド座標に変換します。
            Point MousePosition = targetGrid.PointToClient(Control.MousePosition);
            // 座標点が AdjustableElement 上にあるかどうかを調べます。すなわち、
            // ユーザーが行セレクタ上の行をクリックしているかどうか。
            if (lastElementEntered.AdjustableElementFromPoint(MousePosition) != null)
                return;
            # endregion

            switch ((emGoodsCallMode)this._callMode)
            {
                case emGoodsCallMode.GuideMode:
                    {
                        if (objRow != null)
                        {
                            this.SelectRowData(objRow);
                        }
                    }
                    break;
                default:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                        if (objRow != null)
                        {
                            // マスメンＵＩ起動
                            this.EditGoodsEntry(objRow);
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                    }
                    break;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Result_ultraGrid_MouseClick(object sender, MouseEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                    (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
                if (objCell != null)
                {
                    // 選択列
                    if (objCell.Column.Key == CT_Select)
                    {
                        DataRow dataRow = (objRow.Cells[CT_DataRow].Value != DBNull.Value) ? (DataRow)objRow.Cells[CT_DataRow].Value : null;
                        if (dataRow != null)
                            dataRow[CT_Select] = !(bool)dataRow[CT_Select];
                    }
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Result_ultraGrid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                // スペースキー
                case Keys.Space:
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = this.Result_ultraGrid.ActiveRow;

                    if (gridRow != null)
                    {
                        DataRow dataRow = (gridRow.Cells[CT_DataRow].Value != DBNull.Value) ? (DataRow)gridRow.Cells[CT_DataRow].Value : null;
                        if (dataRow != null)
                            dataRow[CT_Select] = !(bool)dataRow[CT_Select];

                        e.Handled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Result_ultraGrid_MouseEnterElement(object sender, UIElementEventArgs e)
        {
            Infragistics.Win.UIElement element = e.Element;
            object oContextRow = null;
            object oContextCell = null;

            Infragistics.Win.UltraWinGrid.UltraGridRow objRow = null;
            Infragistics.Win.UltraWinGrid.UltraGridCell objCell = null;

            oContextRow = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
            oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            if (oContextCell != null)
            {
                objCell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
                objCell.Appearance.ForeColor = Color.Blue;
                objCell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
            }


            if (oContextRow != null)
            {
                objRow = (Infragistics.Win.UltraWinGrid.UltraGridRow)oContextRow;

                if (objRow != null)
                {
                    string tipString = "";
                    GoodsUnitData goodsUnitData = (objRow.Cells[CT_GoodsUitData].Value != DBNull.Value) ? (GoodsUnitData)objRow.Cells[CT_GoodsUitData].Value : null;

                    if (goodsUnitData != null)
                    {
                        int totalWidth = 7;

                        foreach (UltraGridColumn column in this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns)
                        {
                            if (column.Key.Equals(CT_Select)) continue;

                            if (!column.Hidden)
                            {
                                if (this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns.Exists(column.Key))
                                    tipString += "\r\n" + objRow.Cells[column.Key].Column.Header.Caption.PadRight(totalWidth, '　') + "：" + objRow.Cells[column.Key].Value.ToString();
                            }
                        }
                    }

                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
                    ultraToolTipInfo.ToolTipTitle = "商品情報";
                    ultraToolTipInfo.ToolTipText = tipString;

                    this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
                    this.uToolTipManager_Information.SetUltraToolTip(this.Result_ultraGrid, ultraToolTipInfo);
                    this.uToolTipManager_Information.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Result_ultraGrid_MouseLeaveElement(object sender, UIElementEventArgs e)
        {
            this.uToolTipManager_Information.Enabled = false;

            Infragistics.Win.UIElement element = e.Element;
            object oContextCell = null;

            oContextCell = element.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            if (oContextCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = (Infragistics.Win.UltraWinGrid.UltraGridCell)oContextCell;
                cell.Appearance.ForeColor = this.Result_ultraGrid.DisplayLayout.Override.CellAppearance.ForeColor;
                cell.Appearance.FontData.Underline = this.Result_ultraGrid.DisplayLayout.Override.CellAppearance.FontData.Underline;
            }
        }

        #endregion

        #region < UltraToolbarsManager系のイベント関連 >

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_ultraToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // -------------------------------------------------------------------------------
                // 終了
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_CLOSE:
                    {
                        this.EndProcess();
                        break;
                    }

                // -------------------------------------------------------------------------------
                // 元に戻す
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_UNDO:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
                        //// 履歴の件数が2件に満たない場合は何もしない
                        //if (this._extractConditionList.Count < 2)
                        //{
                        //    return;
                        //}

                        //// 最終アイテムを削除
                        //this._extractConditionList.Pop();

                        //// 現在の１つ前のアイテムを取得し、再検索を行う
                        //GoodsCndtn prevGoodsCndtn = this._extractConditionList.Peek();
                        //if (prevGoodsCndtn != null)
                        //{
                        //    // 現在から1つ前のアイテムと比較
                        //    if (prevGoodsCndtn.Equals(this._goodsCndtn) == false)
                        //    {
                        //        // 抽出条件入力コントロール条件設定処理
                        //        this.SettingExtractConditionItemInfo(prevGoodsCndtn);

                        //        this._goodsCndtn = prevGoodsCndtn.Clone();

                        //        this.Search();
                        //    }
                        //}

                        //// 戻るボタンを設定
                        //this.UndoButtonSetting();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                        // クリアする
                        _goodsCndtn = _goodsCndtn.Create();
                        // 初期化
                        this.Initialize();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                        break;
                    }

                // -------------------------------------------------------------------------------
                // 確定
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_DECISION:
                    {
                        if (!this._isMultiSelect)
                        {
                            if (this.Result_ultraGrid.ActiveRow != null)
                            {
                                this.SelectRowData(this.Result_ultraGrid.ActiveRow);
                            }
                        }
                        else
                        {
                            // 複数選択モードの場合
                            this._selGoodsUnitDataLst.Clear();

                            for (int i = 0; i < this._resultDataView.Count; i++)
                            {
                                // 「選択」対象商品の場合
                                if ((bool)this._resultDataView[i].Row[CT_Select])
                                {
                                    GoodsUnitData selData = (this._resultDataView[i].Row[CT_GoodsUitData] != DBNull.Value) ? (GoodsUnitData)this._resultDataView[i].Row[CT_GoodsUitData] : null;

                                    if (selData != null)
                                    {
                                        this._selGoodsUnitDataLst.Add(selData);
                                    }
                                }
                            }

                            if (this._selGoodsUnitDataLst.Count == 0)
                            {
                                this.MsgDisp("選択されているデータが存在しません。", emErrorLevel.ERR_LEVEL_INFO);
                            }
                            else
                            {
                                this.DialogResult = DialogResult.OK;
                            }
                        }

                        break;
                    }

                // --- ADD 2009/01/06 障害ID:6079対応------------------------------------------------------>>>>>
                // -------------------------------------------------------------------------------
                // 検索
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_SEARCH:
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;

                            //tRetKeyControl1_ChangeFocus(this.MakerName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.MakerName_tEdit, this.Search_UButton));
                            //tRetKeyControl1_ChangeFocus(this.GoodsNo_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsNo_tEdit, this.Search_UButton));
                            //tRetKeyControl1_ChangeFocus(this.GoodsName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsName_tEdit, this.Search_UButton));
                            //tRetKeyControl1_ChangeFocus(this.GoodsNameKana_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsNameKana_tEdit, this.Search_UButton));
                            //tRetKeyControl1_ChangeFocus(this.GoodsLGroupName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsLGroupName_tEdit, this.Search_UButton));
                            //tRetKeyControl1_ChangeFocus(this.GoodsMGroupName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.GoodsMGroupName_tEdit, this.Search_UButton));
                            //tRetKeyControl1_ChangeFocus(this.BLGroupName_tEdit, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.BLGroupName_tEdit, this.Search_UButton));

                            // 選択ボタンクリック処理
                            this.Search_UButton_Click(this.Search_UButton, EventArgs.Empty);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }
                        break;
                    }
                // --- ADD 2009/01/06 障害ID:6079対応------------------------------------------------------<<<<<

                // -------------------------------------------------------------------------------
                // 新規
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_NEW:
                    {
                        GoodsUnitData newData = new GoodsUnitData();
                        // 商品入力起動
                        this.InputGoodsEntry(ref newData);

                        break;
                    }

                // -------------------------------------------------------------------------------
                // 編集
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_EDIT:
                    {
                        // 商品入力起動
                        this.EditGoodsEntry(this.Result_ultraGrid.ActiveRow);

                        break;
                    }

                // -------------------------------------------------------------------------------
                // データ入力
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_DATAINPUT:
                    {
                        break;
                    }

                // -------------------------------------------------------------------------------
                // データ出力
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_DATAOUTPUT:
                    {
                        break;
                    }

                // -------------------------------------------------------------------------------
                // 印刷
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_PRINT:
                    {
                        break;
                    }
                // --- ADD 2008/09/02 -------------------------------->>>>>

                // -------------------------------------------------------------------------------
                // 論理削除
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_LOGICALDELETE:
                    {
                        // 論理削除実行
                        this.LogicalDelete(this.Result_ultraGrid.ActiveRow);

                        // アクティブ行の再設定
                        this.SetActiveRow(this.Result_ultraGrid);

                        break;
                    }
                // --- ADD 2008/09/02 --------------------------------<<<<<
                default:
                    break;
            }
        }


        #endregion

        #region < UltraTree系のイベント関連 >

        /// <summary>
        /// 抽出条件設定ツリーチェックボックスチェック後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ExtractConditionSetting_ultraTree_AfterCheck(object sender, NodeEventArgs e)
        {
            // 抽出条件設定クラスリスト構築処理
            List<ExtractConditionItem> extractConditionItemList = this.ExtractConditionItemListConstruction();
            this._extractConditionItems.SetExtractConditionItemList(extractConditionItemList);

            // 抽出条件設定入力項目構築処理
            this.ExtractConditionInputItemConstruction(this._extractConditionItems.GetExtractConditionItemList());
        }

        /// <summary>
        /// 抽出条件設定ツリーチェックボックスチェック前発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ExtractConditionSetting_ultraTree_BeforeCheck(object sender, BeforeCheckEventArgs e)
        {
            //// イベント発動不可の時は、処理しない
            //if (this._noBeforeCheckEvent == true)
            //{
            //  this._noBeforeCheckEvent = false;
            //  return;
            //}

            //// メーカーと車種のチェックボックスは、メーカーのチェックが無い状態で、車種のチェックのみある状態にはしない

            //// メーカーコードのチェックがはずされる場合は、車種も外す
            //if ((e.TreeNode.Key == ExtractConditionItems.CT_ITEM_MakerCode) &&
            //  ((System.Windows.Forms.CheckState)e.NewValue == System.Windows.Forms.CheckState.Unchecked))
            //{
            //  if (ExtractConditionSetting_UTree.Nodes[ExtractConditionItems.CT_ITEM_ModelCode].CheckedState != (System.Windows.Forms.CheckState)e.NewValue)
            //  {
            //    this._noBeforeCheckEvent = true;

            //    // 車種も同じチェックボックスとする
            //    ExtractConditionSetting_UTree.Nodes[ExtractConditionItems.CT_ITEM_ModelCode].CheckedState = (System.Windows.Forms.CheckState)e.NewValue;
            //  }
            //}

            //// 車種のチェックが付けられる場合、メーカーのチェックも付ける
            //if ((e.TreeNode.Key == ExtractConditionItems.CT_ITEM_ModelCode) &&
            //  ((System.Windows.Forms.CheckState)e.NewValue == System.Windows.Forms.CheckState.Checked))
            //{
            //  if (ExtractConditionSetting_UTree.Nodes[ExtractConditionItems.CT_ITEM_MakerCode].CheckedState != (System.Windows.Forms.CheckState)e.NewValue)
            //  {
            //    this._noBeforeCheckEvent = true;

            //    // メーカーも同じチェックボックスとする
            //    ExtractConditionSetting_UTree.Nodes[ExtractConditionItems.CT_ITEM_MakerCode].CheckedState = (System.Windows.Forms.CheckState)e.NewValue;
            //  }
            //}
        }

        /// <summary>
        /// 抽出条件設定ツリードラッグスタートイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ExtractConditionSetting_ultraTree_SelectionDragStart(object sender, EventArgs e)
        {
            // ドラッグドロップ操作開始イベント
            this.ExtractConditionSetting_ultraTree.DoDragDrop(this.ExtractConditionSetting_ultraTree.SelectedNodes, DragDropEffects.Move);
        }

        /// <summary>
        /// 抽出条件設定ツリードラッグドロップイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ExtractConditionSetting_ultraTree_DragDrop(object sender, DragEventArgs e)
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
            dropNode = this._ultraTreeDrawFilter.DropHightLightNode;

            // データを取得し、selectedNodesコレクションに保存します
            // これらはドラッグドロップされるノードです
            selectedNodes = (Infragistics.Win.UltraWinTree.SelectedNodesCollection)e.Data.GetData(typeof(Infragistics.Win.UltraWinTree.SelectedNodesCollection));
            selectedNodes = (Infragistics.Win.UltraWinTree.SelectedNodesCollection)selectedNodes.Clone();

            // 選択されたノードを表示位置順にソートします。
            // すなわち、移動後も同じ順で表示されるようにするためです
            selectedNodes.SortByPosition();

            // ドロップしている位置をDrawFilterのDropLinePositionから確認します
            switch (this._ultraTreeDrawFilter.DropLinePosition)
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
                            aNode.Reposition(dropNode, Infragistics.Win.UltraWinTree.NodePosition.Next);

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
                            aNode.Reposition(dropNode, Infragistics.Win.UltraWinTree.NodePosition.Previous);
                        }

                        break;
                    }
            }

            // ドロップ操作が完了したら、現在のドロップハイライトを消去する
            this._ultraTreeDrawFilter.ClearDropHighlight();

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
        private void ExtractConditionSetting_ultraTree_DragLeave(object sender, EventArgs e)
        {
            //マウスがコントロールの外にドラッグされた場合、DropHighLightを消去する
            this._ultraTreeDrawFilter.ClearDropHighlight();
        }

        /// <summary>
        /// 抽出条件設定ツリードラッグオーバーイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ExtractConditionSetting_ultraTree_DragOver(object sender, DragEventArgs e)
        {
            // 模擬ノード変数を宣言します
            Infragistics.Win.UltraWinTree.UltraTreeNode aNode;

            // マウスカーソルがあるツリー座標
            // このイベントでは、フォームのXとY座標を引き渡します
            System.Drawing.Point pointInTree;

            // ツリーにおけるマウスの位置を取得します
            pointInTree = this.ExtractConditionSetting_ultraTree.PointToClient(new Point(e.X, e.Y));

            // マウスポインタのあるノードを取得します
            aNode = this.ExtractConditionSetting_ultraTree.GetNodeFromPoint(pointInTree);

            // マウスポインタがノード上にあることを確認
            if (aNode == null)
            {
                // マウスがノード上にないので、ここではドロップ操作は許可しない
                e.Effect = DragDropEffects.None;

                // DropHighlightの消去
                this._ultraTreeDrawFilter.ClearDropHighlight();

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
                this._ultraTreeDrawFilter.ClearDropHighlight();

                // イベントを終了。
                return;
            }

            // この段階まで来たので、ドロップ操作を行います
            this._ultraTreeDrawFilter.SetDropHighlightNode(aNode, pointInTree);

            // ドロップ操作を有効に設定
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 抽出条件設定ツリードラッグイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ExtractConditionSetting_ultraTree_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            //ユーザーがESCを押下したか確認
            if (e.EscapePressed)
            {
                // ドラッグをキャンセルする
                e.Action = DragAction.Cancel;

                // ドロップハイライトを消去
                this._ultraTreeDrawFilter.ClearDropHighlight();
            }
        }

        #endregion

        #region < UltraOptionSet >
        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// </remarks>
        private void SearchType_ultraOptionSet_ValueChanged(object sender, EventArgs e)
        {
            GoodsCndtn goodsInputCndtnBuff = this._goodsCndtn.Clone();

            if (!this.MultiSelect_ultraCheckEditor.Checked)
            {
                goodsInputCndtnBuff = this._goodsCndtn.Create();
            }

            // 品番
            if (sender == this.GoodsCodeSearchType_ultraOptionSet)
            {
                goodsInputCndtnBuff.GoodsNo = this.GoodsNo_tEdit.Text;
                goodsInputCndtnBuff.GoodsNoSrchTyp = (int)this.GoodsCodeSearchType_ultraOptionSet.CheckedItem.DataValue;
            }
            // 品名
            else if (sender == this.GoodsNameSearchType_ultraOptionSet)
            {
                goodsInputCndtnBuff.GoodsName = this.GoodsName_tEdit.Text;
                goodsInputCndtnBuff.GoodsNameSrchTyp = (int)this.GoodsNameSearchType_ultraOptionSet.CheckedItem.DataValue;
            }
            // 品名カナ
            // 2010/07/13 Del >>>
            //else if (sender == this.GoodsNameKanaSearchType_ultraOptionSet)
            //{
            //    goodsInputCndtnBuff.GoodsNameKana = this.GoodsNameKana_tEdit.Text;
            //    goodsInputCndtnBuff.GoodsNameKanaSrchTyp = (int)this.GoodsNameKanaSearchType_ultraOptionSet.CheckedItem.DataValue;
            //}
            // 2010/07/13 Del <<<

            bool isSetting = this.IsExtractionConditionClassSetting(goodsInputCndtnBuff);

            if (isSetting)
            {
                // メモリ上の内容と比較する
                ArrayList arRetList = goodsInputCndtnBuff.Compare(this._goodsCndtn);

                if (arRetList.Count > 0)
                {
                    // 検索条件入力コントロール情報設定
                    this.SettingExtractConditionItemInfo(goodsInputCndtnBuff);

                    this._goodsCndtn = goodsInputCndtnBuff.Clone();

                    if (this.AutoSearch_ultraCheckEditor.Checked)
                    {
                        this._searchButtonFlg = false; // ADD 2013/04/01 田建委 Redmine#34640
                        this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                    }
                }
            }
            else
            {
                this._goodsCndtn = goodsInputCndtnBuff.Clone();
            }
        }
        #endregion

        #region < UltraCheckEditor >
        /// <summary>
        /// 商品属性チェックボックスチェック変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// </remarks>
        private void GoodsKindCode_ultraCheckEditor_AfterCheckStateChanged(object sender, EventArgs e)
        {
            if (!(sender is Infragistics.Win.UltraWinEditors.UltraCheckEditor))
            {
                return;
            }

            GoodsCndtn goodsCndtn = this._goodsCndtn.Clone();

            if (!this.MultiSelect_ultraCheckEditor.Checked)
            {
                goodsCndtn = this._goodsCndtn.Create();
            }

            ArrayList arWrk = new ArrayList();

            if (this.GoodsKindCode_True_ultraCheckEditor.Checked && this.GoodsKindCode_False_ultraCheckEditor.Checked)
            {
                goodsCndtn.GoodsKindCode = 9;
            }
            else if (this.GoodsKindCode_True_ultraCheckEditor.Checked)
            {
                goodsCndtn.GoodsKindCode = 1;
            }
            else if (this.GoodsKindCode_False_ultraCheckEditor.Checked)
            {
                goodsCndtn.GoodsKindCode = 0;
            }
            else
            {
                goodsCndtn.GoodsKindCode = 9;
            }

            bool isSetting = this.IsExtractionConditionClassSetting(goodsCndtn);

            if (isSetting)
            {
                // メモリ上の内容と比較する
                ArrayList arRetList = goodsCndtn.Compare(this._goodsCndtn);

                if (arRetList.Count > 0)
                {
                    // 検索条件入力コントロール情報設定
                    this.SettingExtractConditionItemInfo(goodsCndtn);

                    this._goodsCndtn = goodsCndtn.Clone();

                    if (this.AutoSearch_ultraCheckEditor.Checked)
                    {
                        this._searchButtonFlg = false; // ADD 2013/04/01 田建委 Redmine#34640
                        this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                    }
                }
            }
        }

        // --- ADD 2009/09/02 -------------------------------->>>>>
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
        /// <br>Date        : 2008.09.02</br>
        /// </remarks>
        private void DeleteIndication_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 DEL
            //// 0行の場合は処理なし
            //if (this._resultDataSet.Tables[CT_TBL_RESULT_TITLE].DefaultView.Count == 0)
            //{
            //    return;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 DEL

            // 列の表示設定
            if (this.DeleteIndication_CheckEditor.Checked)
            {
                this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns[CT_LogicalDeleteDate].Hidden = false;
            }
            else
            {
                this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns[CT_LogicalDeleteDate].Hidden = true;
            }

            // 論理削除フィルタ設定
            this.AddGridFiltering();

        }
        // --- ADD 2009/09/02 --------------------------------<<<<<

        #endregion

        #region < Timerイベント >

        /// <summary>
        ///初期表示タイマーイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// <br>Update Note: 2013/05/02 王君</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434 商品在庫マスタ起動区分の追加</br>
        /// </remarks>
        private void Initial_timer_Tick(object sender, EventArgs e)
        {
            this.Initial_timer.Enabled = false;

            try
            {
                string ctPROCNM = "Initial_timer_Tick";
                string msg;
                // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
                if (this._mode == 0)
                {
                    // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
                //Add Start 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
                if (_acs.KeepOnInfo[5] == 0)
                {
                //Add End   2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
                //----- ueno add ---------- start 2008.02.27				
                // ガイド読み込み振り分け
                if (this._callMode == (int)emGoodsCallMode.GuideMode)
                {
                    // ガイドモード時はローカル読み込み固定
                    this._goodsAcs.IsLocalDBRead = true;
                }
                else
                {
                    // メニューモード時はサーバー読み込み固定
                    this._goodsAcs.IsLocalDBRead = false;
                }
                //----- ueno add ---------- end 2008.02.27

                // 初期値データ取得
                int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
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
                            this.MsgDisp(msg, status, ctPROCNM);
                            break;
                        }
                }
            }//Add 2012/12/01 zhangy3 for Redmine#33231
                    // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
                }
                else
                {
                    if (_acs1.KeepOnInfo[5] == 0)
                    {
                        // ガイド読み込み振り分け
                        if (this._callMode == (int)emGoodsCallMode.GuideMode)
                        {
                            // ガイドモード時はローカル読み込み固定
                            this._goodsAcs.IsLocalDBRead = true;
                        }
                        else
                        {
                            // メニューモード時はサーバー読み込み固定
                            this._goodsAcs.IsLocalDBRead = false;
                        }

                        // 初期値データ取得
                        int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
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
                                    this.MsgDisp(msg, status, ctPROCNM);
                                    break;
                                }
                        }
                    }
                }
                // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
                //status = this._goodsAcs.SearchInitialForMst(this._enterpriseCode, this._loginSectionCode, out msg);
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        {
                //            break;
                //        }
                //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                //        {
                //            break;
                //        }
                //    default:
                //        {
                //            this.MsgDisp(msg, status, ctPROCNM);
                //            break;
                //        }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL

                // --- ADD dingjx 2011/12/08 redmine#26676 -------------------------------->>>>>
                int _goodsNo = this.GetGoodsNo();
                if (_goodsNo == 2)
                    this._goodsCndtn.GoodsNoSrchTyp = _goodsNo + 1;
                else
                    this._goodsCndtn.GoodsNoSrchTyp = _goodsNo;
                // --- ADD dingjx 2011/12/08 redmine#26676 --------------------------------<<<<<

                // 抽出条件を画面に設定する
                this.SettingExtractConditionItemInfo(this._goodsCndtn);

                // 自動検索モードの場合
                if (this._isAutoSearch)
                {
                    this._searchButtonFlg = false; // ADD 2013/04/01 田建委 Redmine#34640
                    this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                // 条件リスト取得
                List<ExtractConditionItem> list = this._extractConditionItems.GetExtractConditionItemList();
                if (list.Count > 0)
                {
                    # region [初期フォーカス設定]
                    switch (list[0].Key)
                    {
                        case "MakerCode":
                            {
                                MakerName_tEdit.Focus();
                            }
                            break;
                        case "GoodsNo":
                            {
                                GoodsNo_tEdit.Focus();
                            }
                            break;
                        case "GoodsNameKana":
                            {
                                //GoodsNameKana_tEdit.Focus();    // 2010/07/13 Del
                            }
                            break;
                        case "GoodsLGroup":
                            {
                                GoodsLGroupName_tEdit.Focus();
                            }
                            break;
                        case "GoodsMGroup":
                            {
                                GoodsMGroupName_tEdit.Focus();
                            }
                            break;
                        case "BLGroupCode":
                            {
                                BLGroupName_tEdit.Focus();
                            }
                            break;
                        case "GoodsKindCode":
                            {
                                GoodsKindCode_True_ultraCheckEditor.Focus();
                            }
                            break;
                        case "GoodsName":
                            {
                                GoodsName_tEdit.Focus();
                            }
                            break;
                        default:
                            {
                            }
                            break;
                    }
                    # endregion
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                
            }
            catch (Exception)
            {
            }
        }

        //Add Start 2012/12/01 zhangy3 for Redmine#33231 ----->>>>>
        /// <summary>
        /// 画面の設定によって、商品画面を表示する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の設定によって、商品画面を表示します。</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/12/01</br>
        /// <br>Update Note: 2013/05/02 王君</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434 古い商品在庫マスタの復活</br>
        /// </remarks>
        private void ShowGoodInfoBySetting()
        {
            // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
            if (this._mode == 0)
            {
            // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
            _acs = new GoodsStockInputConstructionAcs();
            if (_acs.KeepOnInfo.Count > 0 && _acs.KeepOnInfo.Count == 6)
            {
                if (_acs.KeepOnInfo[5] > 0)
                {
                    GoodsUnitData newData = new GoodsUnitData();
                    // 商品入力起動
                    this.InputGoodsEntry(ref newData);
                }
            }
            // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
            }
            else
            {
                _acs1 = new GoodsStockInputConstructionAcs1();
                if (_acs1.KeepOnInfo.Count > 0 && _acs1.KeepOnInfo.Count == 6)
                {
                    if (_acs1.KeepOnInfo[5] > 0)
                    {
                        GoodsUnitData newData = new GoodsUnitData();
                        // 商品入力起動
                        this.InputGoodsEntry(ref newData);
                    }
                }
            }
            // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
        }
        //Add End   2012/12/01 zhangy3 for Redmine#33231 -----<<<<<
        /// <summary>
        /// Timer.Tick イベント (Search_timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定したタイマの間隔が経過し、タイマが有効である場合に発生します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.15</br>
        /// </remarks>
        private void Search_timer_Tick(object sender, EventArgs e)
        {
            this.Search_timer.Enabled = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 商品入力抽出条件クラス設定処理
                this.SettingExtractConditionClass(ref this._goodsCndtn);

                if (this.IsExtractionConditionClassSetting(this._goodsCndtn))
                {
                    if (this._goodsCndtn == null)
                    {
                        return;
                    }
                }
                else
                {
                    // 検索対象がない場合

                    List<Control> panelList = this.GetExtractConditionPanelList(true);
                    if (panelList.Count > 0)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                        // 入力クリアした場合は未入力エラーメッセージを表示しない
                        if (_inputClearCheck == false)
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                        {
                            // 抽出条件未入力時はメッセージ表示
                            this.MsgDisp("抽出条件を設定してください。", emErrorLevel.ERR_LEVEL_EXCLAMATION);

                            // 抽出条件の先頭にフォーカス設定
                            Control inputControl = this.GetInputControlOnPanel(panelList[0] as Panel);

                            if (inputControl != null)
                            {
                                this.ActiveControl = inputControl;
                                inputControl.Focus();
                            }
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                        else
                        {
                            // 初期化
                            Initialize();
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                    }
                    else
                    {
                        // 抽出条件未設定はメッセージ表示
                        this.MsgDisp("抽出条件設定にて抽出条件を追加してください。", emErrorLevel.ERR_LEVEL_EXCLAMATION);
                        // 抽出条件設定を表示
                        this.Main_ultraExplorerBar.SelectedGroup = this.Main_ultraExplorerBar.Groups[CT_GROUP_EXTRACTCONDITIONSETTING];
                        // 抽出条件設定ツリーにフォーカス設定
                        this.ExtractConditionSetting_ultraTree.Focus();
                    }

                    return;
                }

                // 抽出条件履歴リストに追加
                this.AddExtractConditionList(this._goodsCndtn);

                // 商品検索
                this.Search();

                // 行の外観設定
                this.SettingGridRowEditor();

                // 戻るボタン設定
                this.UndoButtonSetting();

                // ツールバー状態設定
                this.ToolbarEnableSetting(1);

                // 対象データが存在する場合
                if (this.Result_ultraGrid.Rows.Count > 0)
                {
                    if (DeleteIndication_CheckEditor.Checked)
                    {
                        // 削除済みも表示する→無条件に「最初の行」を選択
                        this.Result_ultraGrid.Focus();
                        this.Result_ultraGrid.ActiveRow = this.Result_ultraGrid.Rows[0];
                        this.Result_ultraGrid.ActiveRow.Selected = true;
                    }
                    else
                    {
                        // 削除済みを表示しない→削除済みの行は除外して最初の行を選択
                        this.Result_ultraGrid.Focus();

                        foreach (UltraGridRow row in Result_ultraGrid.Rows)
                        {
                            if ((string)row.Cells[CT_LogicalDeleteDate].Value == string.Empty)
                            {
                                this.Result_ultraGrid.Focus();
                                this.Result_ultraGrid.ActiveRow = row;
                                this.Result_ultraGrid.ActiveRow.Selected = true;
                                break;
                            }
                        }
                    }
                }

                //-----ADD YANGMJ 2012/02/15 REDMINE#26676 ----->>>>>
                if (this.GoodsNo_tEdit.Value != null)
                {
                    this._preGoodsNo = this.GoodsNo_tEdit.Value.ToString();
                }
                if (this.GoodsMGroupName_tEdit.Value != null)
                {
                    this._preGoodsMGroup = this.GoodsMGroupName_tEdit.Value.ToString();
                }
                if (this.MakerName_tEdit.Value != null)
                {
                    this._preMakerCode = this.MakerName_tEdit.Value.ToString();
                }
                if (this.GoodsName_tEdit.Value != null)
                {
                    this._preGoodsName = this.GoodsName_tEdit.Value.ToString();
                }
                if (this.GoodsLGroupName_tEdit.Value != null)
                {
                    this._preGoodsLGroup = this.GoodsLGroupName_tEdit.Value.ToString();
                }
                if (this.BLGroupName_tEdit.Value != null)
                {
                    this._preBLGroupCode = this.BLGroupName_tEdit.Value.ToString();
                }
                //-----ADD YANGMJ 2012/02/15 REDMINE#26676 -----<<<<<
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// フォントサイズ変更タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Resize_timer_Tick(object sender, EventArgs e)
        {
            this.Resize_timer.Enabled = false;

            Cursor _localCursor = this.Cursor;

            // 列幅の調整
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Result_ultraGrid.BeginUpdate();

                for (int i = 0; i < this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns.Count; i++)
                {
                    this.Result_ultraGrid.DisplayLayout.Bands[CT_TBL_RESULT_TITLE].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
                }
            }
            finally
            {
                this.Result_ultraGrid.EndUpdate();
                this.Cursor = _localCursor;
            }

        }

        #endregion

        #region < tRetKeyControl1_ChangeFocus >

        /// <summary>
        /// RetKeyControlイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Update Note: 2013/04/01 田建委</br>
        /// <br>管理番号   : 10806793-00 2013/04/10配信分</br>
        /// <br>             Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (this._goodsCndtn == null) return;
            if (this._isInitializing) return;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");

            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                bool conditionInput = false;
                bool inputClearCheck = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                // 現時点での抽出条件入力情報クラスの情報を退避する
                GoodsCndtn goodsInputCndtnInfoBuff = this._goodsCndtn.Clone();

                switch (e.PrevCtrl.Name)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    case "Result_ultraGrid":
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    //case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            UltraGridRow objRow = Result_ultraGrid.ActiveRow;
                                            if (objRow != null)
                                            {
                                                // マスメンＵＩ起動
                                                this.EditGoodsEntry(objRow);
                                            }
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        break;
                                }
                            }
                            break;
                        }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                    // ----------------------------------------
                    // メーカーコード
                    case "MakerName_tEdit":
                        {
                            if (this._goodsCndtn.MakerName != this.MakerName_tEdit.Text)
                            {
                                // 数値のみが入力されているか？
                                if ((regex.IsMatch(this.MakerName_tEdit.Text)) && (this.MakerName_tEdit.Text.Length <= 6))
                                {
                                    MakerUMnt maker;

                                    // メーカー情報取得処理
                                    int status = this._goodsAcs.GetMaker(this._enterpriseCode, TStrConv.StrToIntDef(this.MakerName_tEdit.Text, 0), out maker);

                                    //if (status == 0)
                                    //{
                                    if (!this.MultiSelect_ultraCheckEditor.Checked)
                                    {
                                        goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                    }
                                    //}

                                    // メーカークラス→抽出条件入力情報クラス格納処理
                                    this.SetExtractionConditionFromMaker(maker, ref goodsInputCndtnInfoBuff);
                                }
                                else
                                {
                                    if (this.MakerName_tEdit.Text.Trim() == "")
                                    {
                                        // メーカー名称クラス→抽出条件入力情報クラス格納処理
                                        this.SetExtractionConditionFromMaker(null, ref goodsInputCndtnInfoBuff);
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                                        inputClearCheck = true;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                                    }
                                }

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                                conditionInput = true;
                            }

                            // NextCtrl制御
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                            if (!e.ShiftKey)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (this.MakerName_tEdit.Text.Trim() == "")
                                            {
                                                e.NextCtrl = this.MakerGuide_UButton;
                                            }
                                            else
                                            {
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                                                GetNextPanelControl(e);
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                                            }
                                            break;
                                        }
                                }
                            }
                            break;
                        }

                    // ----------------------------------------
                    // 品番
                    case "GoodsNo_tEdit":
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/20 DEL
                            //if ( this._goodsCndtn.GoodsNo != this.GoodsNo_tEdit.DataText )
                            //{
                            //    if ( !this.MultiSelect_ultraCheckEditor.Checked )
                            //    {
                            //        goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                            //    }

                            //    goodsInputCndtnInfoBuff.GoodsNo = this.GoodsNo_tEdit.DataText;

                            //    // 検索条件入力コントロール情報設定
                            //    this.SettingExtractConditionItemInfo( goodsInputCndtnInfoBuff );
                            //    conditionInput = true;
                            //}
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                            //else if ( this.GoodsNo_tEdit.Text == string.Empty )
                            //{
                            //    goodsInputCndtnInfoBuff.GoodsNo = this.GoodsNo_tEdit.DataText;

                            //    // 検索条件入力コントロール情報設定
                            //    this.SettingExtractConditionItemInfo( goodsInputCndtnInfoBuff );
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                            //    inputClearCheck = true;
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                            //}

                            //if ( !e.ShiftKey )
                            //{
                            //    GetNextPanelControl( e );
                            //}
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/20 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/20 ADD
                            if (this._goodsCndtn.GoodsNo != this.GoodsNo_tEdit.DataText)
                            {
                                if (!this.MultiSelect_ultraCheckEditor.Checked)
                                {
                                    goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                }

                                goodsInputCndtnInfoBuff.GoodsNo = this.GoodsNo_tEdit.DataText;

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                                conditionInput = true;

                                if (this.GoodsNo_tEdit.Text == string.Empty)
                                {
                                    inputClearCheck = true;
                                }
                            }

                            if (!e.ShiftKey)
                            {
                                GetNextPanelControl(e);
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/20 ADD
                            break;
                        }

                    // ----------------------------------------
                    // 品名
                    case "GoodsName_tEdit":
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/20 DEL
                            //if ( this._goodsCndtn.GoodsName != this.GoodsName_tEdit.DataText )
                            //{
                            //    if ( !this.MultiSelect_ultraCheckEditor.Checked )
                            //    {
                            //        goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                            //    }

                            //    goodsInputCndtnInfoBuff.GoodsName = this.GoodsName_tEdit.DataText;

                            //    // 検索条件入力コントロール情報設定
                            //    this.SettingExtractConditionItemInfo( goodsInputCndtnInfoBuff );
                            //    conditionInput = true;
                            //}
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                            //else if ( this.GoodsName_tEdit.Text == string.Empty )
                            //{
                            //    goodsInputCndtnInfoBuff.GoodsName = this.GoodsName_tEdit.DataText;

                            //    // 検索条件入力コントロール情報設定
                            //    this.SettingExtractConditionItemInfo( goodsInputCndtnInfoBuff );
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                            //    inputClearCheck = true;
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                            //}

                            //if ( !e.ShiftKey )
                            //{
                            //    GetNextPanelControl( e );
                            //}
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/20 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/20 ADD
                            if (this._goodsCndtn.GoodsName != this.GoodsName_tEdit.DataText)
                            {
                                if (!this.MultiSelect_ultraCheckEditor.Checked)
                                {
                                    goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                }

                                goodsInputCndtnInfoBuff.GoodsName = this.GoodsName_tEdit.DataText;

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                                conditionInput = true;

                                if (this.GoodsName_tEdit.Text == string.Empty)
                                {
                                    inputClearCheck = true;
                                }
                            }

                            if (!e.ShiftKey)
                            {
                                GetNextPanelControl(e);
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/20 ADD
                            break;
                        }

                    // ----------------------------------------
                    // 品名カナ
                    case "GoodsNameKana_tEdit":
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/20 DEL
                            //if ( this._goodsCndtn.GoodsNameKana != this.GoodsNameKana_tEdit.DataText )
                            //{
                            //    if ( !this.MultiSelect_ultraCheckEditor.Checked )
                            //    {
                            //        goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                            //    }

                            //    goodsInputCndtnInfoBuff.GoodsNameKana = this.GoodsNameKana_tEdit.DataText;

                            //    // 検索条件入力コントロール情報設定
                            //    this.SettingExtractConditionItemInfo( goodsInputCndtnInfoBuff );
                            //    conditionInput = true;
                            //}
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                            //else if ( this.GoodsNameKana_tEdit.Text == string.Empty )
                            //{
                            //    goodsInputCndtnInfoBuff.GoodsNameKana = this.GoodsNameKana_tEdit.DataText;

                            //    // 検索条件入力コントロール情報設定
                            //    this.SettingExtractConditionItemInfo( goodsInputCndtnInfoBuff );
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                            //    inputClearCheck = true;
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                            //}

                            //if ( !e.ShiftKey )
                            //{
                            //    GetNextPanelControl( e );
                            //}
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/20 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/20 ADD
                            // 2010/07/13 Del >>>
                            //if (this._goodsCndtn.GoodsNameKana != this.GoodsNameKana_tEdit.DataText)
                            //{
                            //    if (!this.MultiSelect_ultraCheckEditor.Checked)
                            //    {
                            //        goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                            //    }

                            //    goodsInputCndtnInfoBuff.GoodsNameKana = this.GoodsNameKana_tEdit.DataText;

                            //    // 検索条件入力コントロール情報設定
                            //    this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                            //    conditionInput = true;

                            //    if (this.GoodsNameKana_tEdit.Text == string.Empty)
                            //    {
                            //        inputClearCheck = true;
                            //    }
                            //}
                            // 2010/07/13 Del <<<

                            if (!e.ShiftKey)
                            {
                                GetNextPanelControl(e);
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/20 ADD
                            break;
                        }
                    // ----------------------------------------
                    // チェックエディタ系は
                    case "GoodsKindCode0_ultraCheckEditor":
                    case "GoodsKindCode1_ultraCheckEditor":
                    case "GoodsKindCode2_ultraCheckEditor":
                        {
                            return;
                        }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                    // 大分類
                    case "GoodsLGroupName_tEdit":
                        {
                            if (this._goodsCndtn.GoodsLGroupName != this.GoodsLGroupName_tEdit.Text)
                            {
                                // 数値のみが入力されているか？
                                if (regex.IsMatch(this.GoodsLGroupName_tEdit.Text))
                                {
                                    UserGdBdU userGdBdU;
                                    // 大分類情報取得処理
                                    int status = this._goodsAcs.GetGoodsLGroup(this._enterpriseCode, TStrConv.StrToIntDef(this.GoodsLGroupName_tEdit.Text, 0), out userGdBdU);

                                    //if ( status == 0 )
                                    //{
                                    if (!this.MultiSelect_ultraCheckEditor.Checked)
                                    {
                                        goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                    }
                                    //}

                                    // ユーザーガイドクラス→抽出条件入力情報クラス格納処理
                                    this.SetExtractionConditionFromLGoodsGanreU(userGdBdU, ref goodsInputCndtnInfoBuff);

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                                    // NextCtrl制御
                                    GetNextPanelControl(e);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                                }
                                else
                                {
                                    if (this.GoodsLGroupName_tEdit.Text.Trim() == string.Empty)
                                    {
                                        if (!this.MultiSelect_ultraCheckEditor.Checked)
                                        {
                                            goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                        }
                                        // ユーザーガイドクラス→抽出条件入力情報クラス格納処理
                                        this.SetExtractionConditionFromLGoodsGanreU(null, ref goodsInputCndtnInfoBuff);

                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                                        e.NextCtrl = this.GoodsLGroupGuide_UButton;
                                        inputClearCheck = true;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                                    }
                                }

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                                conditionInput = true;
                            }
                            else if (this.GoodsLGroupName_tEdit.Text == string.Empty)
                            {
                                // ユーザーガイドクラス→抽出条件入力情報クラス格納処理
                                this.SetExtractionConditionFromLGoodsGanreU(null, ref goodsInputCndtnInfoBuff);
                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                            }
                        }
                        break;
                    // 中分類
                    case "GoodsMGroupName_tEdit":
                        {
                            if (this._goodsCndtn.GoodsMGroupName != this.GoodsMGroupName_tEdit.Text)
                            {
                                // 数値のみが入力されているか？
                                if (regex.IsMatch(this.GoodsMGroupName_tEdit.Text))
                                {
                                    GoodsGroupU goodsGroupU;
                                    // 中分類情報取得処理
                                    int status = this._goodsAcs.GetGoodsMGroup(this._enterpriseCode, TStrConv.StrToIntDef(this.GoodsMGroupName_tEdit.Text, 0), out goodsGroupU);

                                    //if ( status == 0 )
                                    //{
                                    if (!this.MultiSelect_ultraCheckEditor.Checked)
                                    {
                                        goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                    }
                                    //}

                                    // 中分類クラス→抽出条件入力情報クラス格納処理
                                    this.SetExtractionConditionFromMGoodsGanre(goodsGroupU, ref goodsInputCndtnInfoBuff);

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                                    // NextCtrl制御
                                    GetNextPanelControl(e);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                                }
                                else
                                {
                                    if (this.GoodsMGroupName_tEdit.Text.Trim() == string.Empty)
                                    {
                                        if (!this.MultiSelect_ultraCheckEditor.Checked)
                                        {
                                            goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                        }
                                        // 中分類クラス→抽出条件入力情報クラス格納処理
                                        this.SetExtractionConditionFromMGoodsGanre(null, ref goodsInputCndtnInfoBuff);
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                                        inputClearCheck = true;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                                    }
                                }

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                                conditionInput = true;
                            }
                            else if (this.GoodsMGroupName_tEdit.Text == string.Empty)
                            {
                                // 中分類クラス→抽出条件入力情報クラス格納処理
                                this.SetExtractionConditionFromMGoodsGanre(null, ref goodsInputCndtnInfoBuff);
                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                            }
                        }
                        break;
                    // ＢＬグループ
                    case "BLGroupName_tEdit":
                        {
                            if (this._goodsCndtn.BLGroupName != this.BLGroupName_tEdit.Text)
                            {
                                // 数値のみが入力されているか？
                                if (regex.IsMatch(this.BLGroupName_tEdit.Text))
                                {
                                    BLGroupU bLGroupU;
                                    // ＢＬグループ情報取得処理
                                    int status = this._goodsAcs.GetBLGroup(this._enterpriseCode, TStrConv.StrToIntDef(this.BLGroupName_tEdit.Text, 0), out bLGroupU);

                                    //if ( status == 0 )
                                    //{
                                    if (!this.MultiSelect_ultraCheckEditor.Checked)
                                    {
                                        goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                    }
                                    //}

                                    // ＢＬグループクラス→抽出条件入力情報クラス格納処理
                                    this.SetExtractionConditionFromDGoodsGanre(bLGroupU, ref goodsInputCndtnInfoBuff);

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                                    // NextCtrl制御
                                    GetNextPanelControl(e);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                                }
                                else
                                {
                                    if (this.BLGroupName_tEdit.Text.Trim() == string.Empty)
                                    {
                                        if (!this.MultiSelect_ultraCheckEditor.Checked)
                                        {
                                            goodsInputCndtnInfoBuff = goodsInputCndtnInfoBuff.Create();
                                        }
                                        // ＢＬグループクラス→抽出条件入力情報クラス格納処理
                                        this.SetExtractionConditionFromDGoodsGanre(null, ref goodsInputCndtnInfoBuff);
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 ADD
                                        inputClearCheck = true;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 ADD
                                    }
                                }

                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                                conditionInput = true;
                            }
                            else if (this.BLGroupName_tEdit.Text == string.Empty)
                            {
                                // ＢＬグループクラス→抽出条件入力情報クラス格納処理
                                this.SetExtractionConditionFromDGoodsGanre(null, ref goodsInputCndtnInfoBuff);
                                // 検索条件入力コントロール情報設定
                                this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);
                            }
                        }
                        break;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                // フォーカス制御(調整)
                # region [フォーカス制御(調整)]
                if (e.NextCtrl == Result_ultraGrid && Result_ultraGrid.Rows.Count == 0)
                {
                    // グリッド行がなければグリッドに移動しない
                    e.NextCtrl = e.PrevCtrl;
                }
                else if (e.PrevCtrl == Search_UButton && e.Key == Keys.Up && !e.ShiftKey)
                {
                    e.NextCtrl = _nextControlDic[_nextControlList[_nextControlList.Count - 1]];
                }
                else if (e.PrevCtrl != null && e.PrevCtrl.Parent != null && !e.ShiftKey)
                {
                    bool nextCtrlSetted = false;

                    # region [フォーカス調整]
                    switch (e.PrevCtrl.Name)
                    {
                        case "GoodsNo_tEdit":
                            {
                                if (e.Key == Keys.Right)
                                {
                                    e.NextCtrl = GoodsCodeSearchType_ultraOptionSet;
                                    nextCtrlSetted = true;
                                }
                            }
                            break;
                        case "GoodsCodeSearchType_ultraOptionSet":
                            {
                                if (e.Key == Keys.Left || e.Key == Keys.Down)
                                {
                                    e.NextCtrl = GoodsNo_tEdit;
                                    nextCtrlSetted = true;
                                }
                            }
                            break;
                        // 2010/07/13 Del >>>
                        //case "GoodsNameKana_tEdit":
                        //    {
                        //        if (e.Key == Keys.Right)
                        //        {
                        //            e.NextCtrl = GoodsNameKanaSearchType_ultraOptionSet;
                        //            nextCtrlSetted = true;
                        //        }
                        //    }
                        //    break;
                        //case "GoodsNameKanaSearchType_ultraOptionSet":
                        //    {
                        //        if (e.Key == Keys.Left || e.Key == Keys.Down)
                        //        {
                        //            e.NextCtrl = GoodsNameKana_tEdit;
                        //            nextCtrlSetted = true;
                        //        }
                        //    }
                        //    break;
                        // 2010/07/13 Del <<<
                        case "GoodsName_tEdit":
                            {
                                if (e.Key == Keys.Right)
                                {
                                    e.NextCtrl = GoodsNameSearchType_ultraOptionSet;
                                    nextCtrlSetted = true;
                                }
                            }
                            break;
                        case "GoodsNameSearchType_ultraOptionSet":
                            {
                                if (e.Key == Keys.Left || e.Key == Keys.Down)
                                {
                                    e.NextCtrl = GoodsName_tEdit;
                                    nextCtrlSetted = true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    # endregion

                    if (!nextCtrlSetted)
                    {
                        if (e.NextCtrl == GoodsKindCode_False_ultraCheckEditor && (e.Key == Keys.Up || e.Key == Keys.Down))
                        {
                            e.NextCtrl = GoodsKindCode_True_ultraCheckEditor;
                        }
                        else
                        {
                            # region [条件となるパネル単位の移動を制御]
                            int panelIndex = _nextControlList.IndexOf(e.PrevCtrl.Parent.Name);
                            if (panelIndex >= 0)
                            {
                                if (e.Key == Keys.Up)
                                {
                                    if (panelIndex - 1 >= 0)
                                    {
                                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex - 1]];
                                    }
                                    else if (panelIndex == 0)
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                                else if (e.Key == Keys.Down)
                                {
                                    if (panelIndex + 1 <= _nextControlList.Count - 1)
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
                else if (e.PrevCtrl != null && e.PrevCtrl.Parent != null && e.ShiftKey)
                {
                    # region [フォーカス戻り制御]
                    if (e.PrevCtrl == _nextControlDic[_nextControlList[0]] && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                    else if (e.NextCtrl == GoodsCodeSearchType_ultraOptionSet && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        e.NextCtrl = GoodsNo_tEdit;
                    }
                    // 2010/07/13 Del >>>
                    //else if (e.NextCtrl == GoodsNameKanaSearchType_ultraOptionSet && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    //{
                    //    e.NextCtrl = GoodsNameKana_tEdit;
                    //}
                    // 2010/07/13 Del <<<
                    else if (e.NextCtrl == GoodsNameSearchType_ultraOptionSet && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        e.NextCtrl = GoodsName_tEdit;
                    }
                    # endregion
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD

                if (this.Main_ultraExplorerBar.SelectedGroup.Key == "ExtractCondition")
                {
                    // 商品検索パラメータクラス生成処理
                    this.SettingExtractConditionClass(ref goodsInputCndtnInfoBuff);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 DEL
                    //bool isSetting = this.IsExtractionConditionClassSetting(goodsInputCndtnInfoBuff);

                    //if (isSetting)
                    //{
                    //    // メモリ上の内容と比較する
                    //    ArrayList arRetList = goodsInputCndtnInfoBuff.Compare(this._goodsCndtn);

                    //    if (arRetList.Count > 0)
                    //    {
                    //        // 検索条件入力コントロール情報設定
                    //        this.SettingExtractConditionItemInfo(goodsInputCndtnInfoBuff);

                    //        this._goodsCndtn = goodsInputCndtnInfoBuff.Clone();

                    //        if (this.AutoSearch_ultraCheckEditor.Checked)
                    //        {
                    //            this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                    //        }
                    //    }
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD

                    // 条件を更新する
                    this._goodsCndtn = goodsInputCndtnInfoBuff.Clone();

                    // 条件入力されたか？
                    if (conditionInput)
                    {
                        // 検索
                        if (this.AutoSearch_ultraCheckEditor.Checked)
                        {
                            _inputClearCheck = inputClearCheck;
                            this._searchButtonFlg = false; // ADD 2013/04/01 田建委 Redmine#34640
                            this.Search_UButton_Click(this.Search_UButton, new EventArgs());
                        }
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// FormClosingイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAKHN04110UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ctPROCNM = "MAKHN04110UA_FormClosing";

            try
            {
                this.BeforeClosing();
            }
            catch (Exception ex)
            {
                // エラーメッセージ表示
                this.MsgDisp(-1, ctPROCNM, ex);

            }
        }

        /// <summary>
        /// フォーム起動後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <br>Update Note: 2012/12/01 zhangy3　</br>
        /// <br>           : 2013/01/16配信分 Redmine#33231 商品在庫マスタ</br>
        private void MAKHN04110UA_Shown(object sender, EventArgs e)
        {
            ShowGoodInfoBySetting();//Add 2012/12/01 zhangy3 for Redmine#33231
            //if ((this._callMode == (int)emGoodsCallMode.GuideMode) )
            //{
            //  Form mainForm = this.Owner;

            //  if (mainForm == null)
            //    mainForm = this.GetMainForm();

            //  if (mainForm != null)
            //  {
            //    int afterHeight = Convert.ToInt32(mainForm.Height * 0.95);
            //    int afterWidth = Convert.ToInt32(mainForm.Width * 0.95);

            //    this.Size = new Size(afterWidth, afterHeight);

            //    this.StartPosition = FormStartPosition.Manual;
            //    this.Left = mainForm.Left + (mainForm.Width - mainForm.Width) / 2;
            //    this.Top = mainForm.Top + (mainForm.Height - mainForm.Height) / 2;
            //  }
            //}
        }

        #endregion

        #region < ExtractConditionSetting_ultraTree_MouseClick >

        /// <summary>
        /// 抽出条件設定ツリーマウスクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        private void ExtractConditionSetting_ultraTree_MouseClick(object sender, MouseEventArgs e)
        {
            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = this.ExtractConditionSetting_ultraTree.PointToClient(point);

            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement objNodeCheckBoxElement = null;
            objElement = this.ExtractConditionSetting_ultraTree.UIElement.ElementFromPoint(point);

            objNodeCheckBoxElement = (Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement)objElement.GetAncestor(
                (typeof(Infragistics.Win.UltraWinTree.NodeCheckBoxUIElement)));

            // チェックボックスの場合は以下の処理をキャンセルする
            if (objNodeCheckBoxElement != null)
            {
                return;
            }

            Infragistics.Win.UltraWinTree.UltraTreeNode clickedNode =
                                            this.ExtractConditionSetting_ultraTree.GetNodeFromPoint(point);

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

        #endregion

        private void Main_ultraStatusBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        /// <summary>
        /// 次パネルフォーカス移動制御
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private void GetNextPanelControl(ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;
            if (e.PrevCtrl.Parent == null) return;


            int panelIndex = _nextControlList.IndexOf(e.PrevCtrl.Parent.Name);
            if (panelIndex >= 0)
            {
                if (e.Key == Keys.Up)
                {
                    if (panelIndex - 1 >= 0)
                    {
                        e.NextCtrl = _nextControlDic[_nextControlList[panelIndex - 1]];
                    }
                    else if (panelIndex == 0)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                else if (e.Key == Keys.Down || e.Key == Keys.Tab || e.Key == Keys.Return)
                {
                    if (panelIndex + 1 <= _nextControlList.Count - 1)
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
        private Control GetNextPanelControl(Control prevCtrl)
        {
            if (prevCtrl == null) return prevCtrl;
            if (prevCtrl.Parent == null) return prevCtrl;


            int panelIndex = _nextControlList.IndexOf(prevCtrl.Parent.Name);
            if (panelIndex >= 0)
            {
                if (panelIndex + 1 <= _nextControlList.Count - 1)
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
        /// アクティブグループ変更時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_ultraExplorerBar_ActiveGroupChanged(object sender, Infragistics.Win.UltraWinExplorerBar.GroupEventArgs e)
        {
            _nextControlList = new List<string>();
            List<ExtractConditionItem> extractconditioItemList = this._extractConditionItems.GetExtractConditionItemList();
            for (int index = 0; index < extractconditioItemList.Count; index++)
            {
                if (extractconditioItemList[index].IsDisplay())
                {
                    _nextControlList.Add("Condition_" + extractconditioItemList[index].Key.TrimEnd() + "_panel");
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
    }

}