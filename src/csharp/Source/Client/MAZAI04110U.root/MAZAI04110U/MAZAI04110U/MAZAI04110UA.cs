//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫照会
// プログラム概要   : 在庫照会で使用するデータの取得を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Y.Sasaki
// 作 成 日  2007/01/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Y.Sasaki
// 修 正 日  2007/06/25  修正内容 : 検索条件の「ゼロ在庫表示」は、在庫検索時のみ有効
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Y.Sasaki
// 修 正 日  2007/07/09  修正内容 : 文字列検索タイプのコントロールで一度検索条件を入れて検索をかけると、
//　　　　　　　　　　　　　　　　　検索条件をクリアすると'0'で検索される障害解除。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 修 正 日  2007/09/05  修正内容 : 流通.NS用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 修 正 日  2008/04/24  修正内容 : PM.NS 共通修正 得意先・仕入先分離対応
//                                  PM.NS 共通修正 拠点制御設定マスタ削除対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徳永 俊詞
// 修 正 日  2008/08/04  修正内容 : PM.NS 仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/02/09  修正内容 : 障害ID:11216対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/09  修正内容 : 障害ID:12242対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/03/11  修正内容 : 障害ID:12315対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/03/12  修正内容 : 障害ID:12298対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/01  修正内容 : 不具合対応[12835][12837]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/02  修正内容 : 不具合対応[12838]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/26  修正内容 : 不具合[12838]修正ミスの為、修正
//                                  不具合対応[13386][13387][13389]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 修 正 日  2009/09/07  修正内容 : PM.NS-2-B 保守依頼①
//                                  表示データが存在するが「該当データなし」となる為、修正
//                                  tEdit_WarehouseCode_Enterのイベントを削除する
//                                  tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2009/11/05  修正内容 : PM.NS-2-B 保守依頼①
//                                  Redmine#1114対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李侠
// 修 正 日  2009/12/18  修正内容 : PM.NS-5-C 保守依頼④
//                                  検索条件の拠点ガイドへ全社を追加
//                                  マスタ未登録時の処理を変更    
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 王飛３
// 修 正 日  2011/07/07  修正内容 : 連番36 在庫照会の抽出中の中断機能が欲しい 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/21  修正内容 : Redmine7864の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20073 西 毅
// 修 正 日  2012/04/10  修正内容 : 起動、抽出の速度改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI斎藤 和宏
// 修 正 日  2012/09/18  修正内容 : テキスト出力機能追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI斎藤 和宏
// 修 正 日  2012/09/26  修正内容 : 仕入先コードの検索条件が無効となる障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI斎藤 和宏
// 修 正 日  2012/11/06  修正内容 : 仕入先コード入力時の抽出速度改善対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
using System.Threading;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

// --- ADD 2012/09/18 ---------->>>>>
// 操作制限制御に必要
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Application.Resources;
// 設定画面表示に必要
using Broadleaf.Windows.Forms;
// --- ADD 2012/09/18 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫検索ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品在庫の検索を行うＵＩフォームクラスです。</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2007.1.10</br>
    /// <br>Update Note: 2007.06.25 Y.Sasaki</br>
    /// <br>           : 1. 検索条件の「ゼロ在庫表示」は、在庫検索時のみ有効</br>
    /// <br>Update Note: 2007.07.09 Y.Sasaki</br>
    /// <br>           : 1. 文字列検索タイプのコントロールで一度検索条件を入れて検索をかけると、</br>
    /// <br>           :    検索条件をクリアすると'0'で検索される障害解除。</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.05 鈴木 正臣</br>
    /// <br>           : 流通.NS用に変更</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.24 20056 對馬 大輔</br>
    ///	<br>		   : PM.NS 共通修正 得意先・仕入先分離対応</br>
    ///	<br>		   : PM.NS 共通修正 拠点制御設定マスタ削除対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.08.04 30418 徳永 俊詞</br>
    ///	<br>		   : PM.NS 仕様変更対応</br>
    /// <br>Update Note: 2009.02.09 30414 忍 幸史</br>
    ///	<br>		   : 障害ID:11216対応</br>
    /// <br>Update Note: 2009/03/09 30452 上野 俊治</br>
    ///	<br>		   : 障害ID:12242対応</br>
    /// <br>Update Note: 2009/03/11 30414 忍 幸史</br>
    ///	<br>		   : 障害ID:12315対応</br>
    /// <br>Update Note: 2009/03/12 30414 忍 幸史</br>
    ///	<br>		   : 障害ID:12298対応</br>
    /// <br>Update Note: 2009/04/01       照田 貴志</br>
    ///	<br>		   : 不具合対応[12835][12837]</br>
    /// <br>Update Note: 2009/04/02       照田 貴志</br>
    ///	<br>		   : 不具合対応[12838]</br>
    /// <br>Update Note: 2009/05/26       照田 貴志</br>
    ///	<br>		   : 不具合[12838]修正ミスの為、修正</br>
    /// <br>           : 不具合対応[13386][13387][13389]</br>
    /// <br>Update Note: 2009/09/07       汪千来</br>
    ///	<br>		   : 表示データが存在するが「該当データなし」となる為、修正</br>
    /// <br>		   : tEdit_WarehouseCode_Enterのイベントを削除する</br>
    /// <br>Update Note: 2009/11/05       呉元嘯</br>
    ///	<br>		   : Redmine#1114対応</br>
    /// <br>Update Note: 2009/12/18       李侠</br>
    ///	<br>		   : PM.NS-5-C 保守依頼④対応</br>
    /// <br>Update Note: 2011/07/07       王飛３ </br>
    /// <br>               : 連番36   在庫照会の抽出中の中断機能が欲しい </br>
    /// </remarks>
    public partial class StockSearchGuide : Form
    {
        //================================================================================
        //  コンストラクタ
        //================================================================================
        #region Constructor
        /// <summary>
        /// 在庫検索ＵＩクラスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 18012  Y.Sasaki</br>
        /// <br>Date       : 2007.01.10</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// <br>Update Note: 2009/09/07       汪千来</br>
        /// <br>           : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// </remarks>
        public StockSearchGuide()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
            // 在庫商品情報取得スレッド
            StockAcsThreadStart();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD
            InitializeComponent();

            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
                this._loginSectionCode = this._loginEmployee.BelongSectionCode.Trim();
            }

            // --- ADD 2012/09/18 ---------->>>>>
            // 設定フォーム生成
            _settingForm = new MAZAI04110UB();

            // グリッド内の設定初期化イベント定義
            _settingForm.ClearSettingStockGrid += new EventHandler(SettingForm_ClearSettingStockGrid);
            
            // 設定読み込み
            _settingForm.Deserialize();
            // --- ADD 2012/09/18 ----------<<<<<

            // 各アクセスクラスのインスタンス化
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
            // エンプラコードとセクションコードを渡すように
            //this._searchStockAcs = new SearchStockAcs();
            //this._searchStockAcs = new SearchStockAcs();
            //this._searchStockAcs = new SearchStockAcs(LoginInfoAcquisition.EnterpriseCode, this._loginSectionCode);  // T.Nishi 2012/04/10 DEL
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END

            //this._goodsAcs = new GoodsAcs(); // ddd
            //this._goodsAcs = this._searchStockAcs.GoodsAcs; // ddd  //T.Nishi 2012/04/10 DEL

            this._secInfoAcs = new SecInfoAcs();
            this._warehouseAcs = new WarehouseAcs();
            //this._customerInfoAcs = new CustomerInfoAcs(); // DEL 2008.04.24
            this._supplierAcs = new SupplierAcs(); // ADD 2008.04.24
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._carrierEpAcs = new CarrierEpAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._UserGuideAcs = new UserGuideAcs();
            this._dGoodsGanreAcs = new DGoodsGanreAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.01 TOKUNAGA ADD START
            // 拠点アクセスクラス(ガイドボタン＋自動検索用)
            this._secInfoSetAcs = new SecInfoSetAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.01 TOKUNAGA ADD END

            this._gridStateController = new GridStateController();
            this._controlScreenSkin = new ControlScreenSkin();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 拠点名称ディクショナリ生成
            _sectionNameDic = new Dictionary<string, string>();
            foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
            {
                _sectionNameDic.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideNm);
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 初期ﾌｫｰｶｽｺﾝﾄﾛｰﾙ
            //2008.10.10 stokunaga modify start
            //_firstControl = this.uLabel_WarehouseName;
            //_firstControl = this.tEdit_SectionCode;// DEL 2009/09/07  
            _firstControl = this.tEdit_SectionCodeAllowZero;// ADD 2009/09/07
            //2008.10.10 stokunaga modify end

            // 照会モード初期化
            _isReference = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 前回ヘッダ情報退避用
            _prevHeaderInfo = new HeaderInfo();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ADD 2008/10/09 不具合対応[6382] ---------->>>>>
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools["ButtonTool_Decision"];
            this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools["ButtonTool_Undo"];

            //ChangeDecisionButtonEnable(false);  // T.Nishi 2012/04/10 DEL
            // ADD 2008/10/09 不具合対応[6382] ----------<<<<<
        }

        #endregion

        // ===============================================================================
        // プライベートメンバー
        // ===============================================================================
        #region Private member

        // -------------------------------------------------------------------------------
        #region < 画面表示用 >
        /// <summary>イベントフラグ</summary>
        private bool _isEvent = false;
        private ImageList _imageList16;
        /// <summary>文字サイズ</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>ログイン従業員</summary>
        private Employee _loginEmployee;
        /// <summary>ログイン拠点コード</summary>
        private string _loginSectionCode = string.Empty;
        /// <summary>起動回数</summary>
        private int _initialCounter;
        /// <summary>タイトル</summary>
        private string _title = "";
        ///// <summary>詳細ガイド用</summary>
        //private StockSearchGuide _detailGuide;
        /// <summary>スキン変更部品</summary>
        private ControlScreenSkin _controlScreenSkin;

        /// <summary>デフォルト外観</summary>
        private Infragistics.Win.Appearance _defButtonAppearance;
        /// <summary>表示順ボタン選択背景色</summary>
        private readonly Color _selSortBtnBackColor = Color.FromArgb(247, 227, 156);
        /// <summary>表示順ボタン選択フォント色</summary>
        private readonly Color _selSortBtnForeColor = Color.Blue;
        private delegate void settingHandler(int row);

        /// <summary>初期フォーカスコントロール</summary>
        private Control _firstControl;

        /// <summary>前回ヘッダ情報</summary>
        private HeaderInfo _prevHeaderInfo;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        // 在庫商品初期化スレッド
        private Thread StockAcsThread;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        private int _paraSupplierCd = 0;
        private bool _extractCancelFlag;
        private bool _extractPauseFlag = false;

        /// <summary>在庫検索結果格納格納バッファ</summary>
        private Dictionary<string, Dictionary<string, StockExpansion>> _drStockSearchRet;

        private double gtotalStockCount;
        private long gtotalStockValue;
        private int growCount;
        private int gMaxCount;

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        // --- ADD 2012/09/18 ---------->>>>>
        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_TextOutput;
        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority _operationAuthority;
        /// <summary>操作権限の制御リスト</summary>
        private Dictionary<OperationCode, bool> _operationAuthorityList;
        // --- ADD 2012/09/18 ----------<<<<<

        #endregion

        // -------------------------------------------------------------------------------
        #region < 抽出条件格納用 >

        /// <summary>抽出条件入力</summary>
        private bool _isInputSearchParam = true;

        ///// <summary>在庫状態</summary>
        //private Int32[] _defStockState = null;
        ///// <summary>移動状態状態</summary>
        //private Int32[] _defMoveStatus = null;
        ///// <summary>商品状態</summary>
        //private Int32[] _defGoodsCodeStatus = null;
        ///// <summary>製造番号検索区分</summary>
        //private Int32 _defProductNumberSrchDivCd;

        /// <summary>指定された抽出条件</summary>
        private StockSearchPara _setSearchParam;
        /// <summary>前回抽出条件</summary>
        private StockSearchPara _prevSearchParam;

        // ---ADD 2009/04/02 不具合対応[12838] ---------------------------->>>>>
        /// <summary>表示順前回値</summary>
        private int _prevSortDiv;
        // ---ADD 2009/04/02 不具合対応[12838] ----------------------------<<<<<

        /// <summary>抽出条件固定(拠点)</summary>
        private bool _isFixedSection = false;
        /// <summary>抽出条件固定(キャリア)</summary>
        private bool _isFixedCarrierCode = false;
        /// <summary>抽出条件固定(倉庫)</summary>
        private bool _isFixedWarehouseCode = false;
        /// <summary>抽出条件固定(ゼロ在庫表示)</summary>
        private bool _isFixedStockZero = false;
        /// <summary>クリアされたフラグ</summary>
        private bool _cleared = false;

        #endregion

        private SFCMN00299CA _processingDialog = null;//ADD 2011/07/07

        // -------------------------------------------------------------------------------
        #region < アクセスクラス >

        /// <summary>在庫検索アクセスクラス</summary>
        private SearchStockAcs _searchStockAcs;
        /// <summary>商品アクセスクラス</summary>
        private GoodsAcs _goodsAcs;
        /// <summary>拠点アクセスクラス</summary>
        private SecInfoAcs _secInfoAcs;
        /// <summary>倉庫アクセスクラス</summary>
        private WarehouseAcs _warehouseAcs;
        ///// <summary>得意先アクセスクラス</summary> // DEL 2008.04.24
        //private CustomerInfoAcs _customerInfoAcs; // DEL 2008.04.24
        /// <summary>仕入先アクセスクラス</summary> // ADD 2008.04.24
        private SupplierAcs _supplierAcs; // ADD 2008.04.24
        ///// <summary>得意先検索ガイド</summary> // DEL 2008.04.24
        //private SFTOK01370UA _customerSearchForm; // DEL 2008.04.24

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.01 TOKUNAGA ADD START
        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.01 TOKUNAGA ADD END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>事業者検索ガイド</summary>
        //private CarrierEpAcs _carrierEpAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>ＢＬ商品コード検索ガイド</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>商品区分詳細検索ガイド</summary>
        private DGoodsGanreAcs _dGoodsGanreAcs;
        /// <summary>ユーザーガイド</summary>
        private UserGuideAcs _UserGuideAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion

        // -------------------------------------------------------------------------------
        #region < グリッド関連用 >

        /// <summary>グリッド設定制御クラス</summary>
        private GridStateController _gridStateController;

        private DataSet _stockDataSet;

        private DataTable _stockDataTable;
        private DataView _stockDataView;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private DataTable _productStockDataTable;
        //private DataView _productStockDataView;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //		private DataRelation _relationStockProductStock;

        private DataView _gridBindDataView;

        /// <summary>複数選択可能フラグ</summary>
        private bool _isMultiSelect = false;

        /// <summary>タッチパネルフラグ</summary>
        private bool _isTouchPanel = false;

        private Infragistics.Win.ValueList _fontSizeValueList;

        /// <summary>
        /// 選択グリッド行BackColor
        /// </summary>
        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);

        /* ---DEL 2009/04/02 不具合対応[12838] ----------------------------------------->>>>>
        private readonly string _defaultStokSort = CT_MakerCode + " , " + CT_GoodsCode;
        //private readonly string _defaultProductSort = CT_MakerCode + "," + CT_GoodsCode;
           ---DEL 2009/04/02 不具合対応[12838] -----------------------------------------<<<<< */
        private readonly string _defaultStokSort = CT_WarehouseCode + "," + CT_GoodsCode + " , " + CT_MakerCode;        //ADD 2009/04/02 不具合対応[12838]


        // 拠点名称ディクショナリ
        private Dictionary<string, string> _sectionNameDic;

        // 照会表示モード
        private bool _isReference;

        #endregion

        // -------------------------------------------------------------------------------
        #region < 選択結果格納用バッファ >

        /// <summary>選択された在庫情報</summary>
        private List<StockExpansion> _selStock;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
        private List<Stock> _selectedStockList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>選択された製番情報</summary>
        //private List<ProductStock> _selProduct;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion

        // -------------------------------------------------------------------------------
        #region < イベント用のフラグ >

        /// <summary>
        /// 初期化中フラグ
        /// </summary>
        private Boolean _isInitialize = true;

        /// <summary>
        /// 自動検索モード[True:自動検索する,False:自動検索しない]
        /// </summary>
        private Boolean _isAutoSearch = false;

        /// <summary>
        /// 列サイズ調整イベント可能フラグ(T:可,F:不可)
        /// </summary>
        private Boolean _isEventAutoFillColumn = true;

        /// <summary>
        /// ボタンクリックイベント可能フラグ(T:可,F:不可)
        /// </summary>
        private Boolean _isButtonClick = true;
        #endregion

        /// <summary>
        /// 商品検索モード
        /// </summary>
        private int _searchMode = 0;

        // ADD 2008/10/09 不具合対応[6382] ↓
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン

        // --- ADD 2012/09/18 ---------->>>>>
        #region <設定画面用>
        /// <summary>MAZAI04110UB 設定フォーム</summary>
        private MAZAI04110UB _settingForm;
        #endregion

        #region <テキスト出力用>
        /// <summary>出力設定XMLからの取得設定</summary>
        private StockUserConst _userSetting;
        /// <summary>設定値</summary>
        private string[] _patternSetting;
        /// <summary>出力カラム名</summary>
        private List<String> _exportColumnNameList;
        #endregion
        // --- ADD 2012/09/18 ----------<<<<<
        #endregion

        // ===============================================================================
        // プライベート定数
        // ===============================================================================
        #region Private Constant
        private const string CT_PGID = "MAZAI04110U";

        // グリッド初期フォントサイズ
        private const int CT_Default_FontSize = 11;

        // 最大表示行数
        private const int CT_MaxRowCount = 10000;

        // ボタン表示幅
        private const int CT_ButtonColWidth = 50;

        // -------------------------------------------------------------------------------
        #region < ツールーバーボタン用 >
        /// <summary>確定</summary>
        private const string CT_BUTTONTOOL_Decision = "Decision_ButtonTool";
        /// <summary>戻る</summary>
        private const string CT_BUTTONTOOL_Back = "Back_ButtonTool";
        /// <summary>取消</summary>
        private const string CT_BUTTONTOOL_Undo = "Undo_ButtonTool";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>終了</summary>
        private const string CT_BUTTONTOOL_Quit = "Quit_ButtonTool";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
        /// <summary>検索</summary>
        private const string CT_BUTTONTOOL_Search = "Search_ButtonTool";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
        //2012/04/10 T.Nishi >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private const string CT_BUTTONTOOL_Stop = "Stop_ButtonTool";
        private const string CT_BUTTONTOOL_Pause = "Pause_ButtonTool";
        private const string CT_BUTTONTOOL_ReStart = "ReStart_ButtonTool";
        private const string CT_BUTTONTOOL_PopDecision = "ButtonTool_Decision";
        private const string CT_BUTTONTOOL_PopUndo = "ButtonTool_Undo";
        //2012/04/10 T.Nishi <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2012/09/18 ---------->>>>>
        /// <summary>ﾃｷｽﾄ出力</summary>
        private const string CT_BUTTONTOOL_ExtractText   = "ExtractText_ButtonTool";
        /// <summary>Excel出力</summary>
        private const string CT_BUTTONTOOL_ExtractExcel  = "ExtractExcel_ButtonTool";
        /// <summary>設定</summary>
        private const string CT_BUTTONTOOL_Configuration = "Configuration_ButtonTool";
        // --- ADD 2012/09/18 ----------<<<<<

        /// <summary>製番順</summary>
        private const string CT_CONTROLTOOL_ProductOder = "ProductOder_ControlContainerTool";
        /// <summary>仕入日　　降順</summary>
        private const string CT_CONTROLTOOL_StockDateDec = "StockDateDec_ControlContainerTool";
        /// <summary>仕入日　　昇順</summary>
        private const string CT_CONTROLTOOL_StockDateAsc = "StockDateAsc_ControlContainerTool";
        /// <summary>仕入単価　降順</summary>
        private const string CT_CONTROLTOOL_UnitPriceDec = "UnitPriceDec_ControlContainerTool";
        /// <summary>仕入単価　昇順</summary>
        private const string CT_CONTROLTOOL_UnitPriceAsc = "UnitPriceAsc_ControlContainerTool";
        #endregion

        // -------------------------------------------------------------------------------
        #region < コントロール表示位置用 >

        #region グループボックス１の表示位置用

        /// <summary>１列目のタイトルX座標 </summary>
        private const int CT_GROUP1_COL1_TITLE_START_X = 9;
        /// <summary>１列目のタイトルY座標 </summary>
        private const int CT_GROUP1_COL1_TITLE_START_Y = 16;
        /// <summary>１列目のコントロールX座標 </summary>
        private const int CT_GROUP1_COL1_CONTROL_START_X = 115;
        /// <summary>１列目のコントロールY座標 </summary>
        private const int CT_GROUP1_COL1_CONTROL_START_Y = 16;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
        /// <summary>２列目のタイトルX座標 </summary>
        private const int CT_GROUP1_COL2_TITLE_START_X = 456;
        /// <summary>２列目のタイトルY座標 </summary>
        //private const int CT_GROUP1_COL2_TITLE_START_Y = 76;
        private const int CT_GROUP1_COL2_TITLE_START_Y = 16;
        /// <summary>２列目のコントロールX座標 </summary>
        private const int CT_GROUP1_COL2_CONTROL_START_X = 562;
        /// <summary>２列目のコントロールY座標 </summary>
        //private const int CT_GROUP1_COL2_CONTROL_START_Y = 76;
        private const int CT_GROUP1_COL2_CONTROL_START_Y = 16;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

        #endregion

        #region グループボックス２の表示位置用

        /// <summary>１列目のタイトルX座標 </summary>
        private const int CT_GROUP2_COL1_TITLE_START_X = 9;
        /// <summary>１列目のタイトルY座標 </summary>
        private const int CT_GROUP2_COL1_TITLE_START_Y = 9;
        /// <summary>１列目のコントロールX座標 </summary>
        private const int CT_GROUP2_COL1_CONTROL_START_X = 115;
        /// <summary>１列目のコントロールY座標 </summary>
        private const int CT_GROUP2_COL1_CONTROL_START_Y = 9;

        /// <summary>２列目のタイトルX座標 </summary>
        private const int CT_GROUP2_COL2_TITLE_START_X = 456;
        /// <summary>２列目のタイトルY座標 </summary>
        private const int CT_GROUP2_COL2_TITLE_START_Y = 9;
        /// <summary>２列目のコントロールX座標 </summary>
        private const int CT_GROUP2_COL2_CONTROL_START_X = 562;
        /// <summary>２列目のコントロールY座標 </summary>
        private const int CT_GROUP2_COL2_CONTROL_START_Y = 9;

        #endregion

        /// <summary>行間隔 </summary>
        private const int CT_GUIDEBUTTON_INTERVAL = 2;

        /// <summary>行間隔 </summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
        //private const int CT_ROW_INTERVAL = 30;
        private const int CT_ROW_INTERVAL = 27;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

        #endregion

        // -------------------------------------------------------------------------------
        #region < グリッド系関連の定数定義 >
        // -------------------------------------------------------------------------------
        #region < テーブル共通列定義 >

        private const string CT_Select = "Select";                 // 選択用セル
        private const string CT_SelectButton = "SelectButton";           // 選択用セルボタン
        private const string CT_RowNo = "RowNo";                  // 行No
        private const string CT_SectionCode = "SectionCode";            // 拠点コード
        private const string CT_SectionName = "SectionName";            // 拠点名
        private const string CT_GoodsCode = "GoodsCode";              // 商品コード
        private const string CT_GoodsName = "GoodsName";              // 商品名称
        private const string CT_MakerCode = "MakerCode";              // メーカーコード
        private const string CT_MakerName = "MakerName";              // メーカ名

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //// キャリア名称
        //private const string CT_CarrierName = "CarrierName";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        // -------------------------------------------------------------------------------
        #region < 在庫テーブル列定義 >

        #region del by s.tokunaga
        private const string CT_TrustCount = "TrustCount";             // 受託数
        private const string CT_EntrustCnt = "EntrustCnt";             // 委託数(自)
        private const string CT_ShipmentPosCnt = "ShipmentPosCnt";         // 出荷可能数
        private const string CT_StockSearchRet = "Stock";                  // 選択用データ格納用
        #endregion // del by s.tokunaga

        private const string CT_SupplierStock = "SupplierStock";          // 現在庫(仕)
        private const string CT_MovingSupliStock = "MovingSupliStock";       // 移動数

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        private const string CT_ShipmentCnt = "ShipmentCnt";            // 出荷数（未計上）
        private const string CT_ArrivalCnt = "ArrivalCnt";             // 入荷数（未計上）
        private const string CT_AcpOdrCount = "AcpOdrCount";            // 受注数
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #region del by m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //// 予約数
        //private const string CT_ReservedCount = "ReservedCount";

        //// 引当在庫数
        //private const string CT_AllowStockCnt = "AllowStockCnt";

        //// 委託数(受)
        //private const string CT_TrustEntrustCnt = "TrustEntrustCnt";

        //// 売切数
        //private const string CT_SoldCnt = "SoldCnt";

        //// 移動中受託在庫数
        //private const string CT_MovingTrustStock = "MovingTrustStock";

        //// 詳細製番ボタン
        //private const string CT_ProductButton = "ProductButton";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion // del by m.suzuki

        #endregion

        // -------------------------------------------------------------------------------
        #region < 製番在庫テーブル列定義 >

        private const string CT_StockDivNm = "StockDivNm";             // 在庫区分名
        private const string CT_WarehouseName = "WarehouseName";          // 倉庫名称
        private const string CT_WarehouseCode = "WarehouseCode";          // 倉庫コード
        private const string CT_CustomerName = "CustomerName";           // 得意先名称
        private const string CT_StockDate = "StockDate";              // 仕入日
        private const string CT_StockDateDisp = "StockDateDisp";          // 仕入日(文字列)
        private const string CT_StockUnitPrice = "StockUnitPrice";         // 仕入単価

        #region del by m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //// 製造番号
        //private const string CT_ProductNumber = "ProductNumber";

        //// 在庫状態
        //private const string CT_StockStateNm = "StockStateNm";

        //// 移動状態
        //private const string CT_MoveStatusNm = "MoveStatusNm";

        //// 商品状態
        //private const string CT_GoodsCodeStatusNm = "GoodsCodeStatusNm";

        //// 商品電話番号1
        //private const string CT_StockTelNo1 = "StockTelNo1";

        //// 商品電話番号2
        //private const string CT_StockTelNo2 = "StockTelNo2";

        //// ロム区分
        //private const string CT_RomDivNm = "RomDivNm";

        //// 選択製番在庫格納用
        //private const string CT_ProductStockSearchRet = "ProductStock";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion // del by m.suzuki

        #endregion

        // -------------------------------------------------------------------------------
        #region < PM.NS対応テーブル列定義追加 >

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
        private const string CT_WarehouseShelfNo = "WarehouseShelfNo";       // 棚番
        private const string CT_MinimumStockCnt = "MinimumStockCnt";        // 最低在庫数
        private const string CT_MaximumStockCnt = "MaximumStockCnt";        // 最高在庫数
        private const string CT_SalesOrderCount = "SalesOrderCount";        // 発注残
        private const string CT_SupplierLot = "SupplierLot";            // 発注ロット
        private const string CT_GoodsSpecialNote = "GoodsSpecialNote";       // 規格・特記事項
        private const string CT_BLGoodsCode = "BLGoodsCode";            // BL商品コード
        private const string CT_GoodsNameKana = "GoodsNameKana";          // 商品名称カナ
        private const string CT_DuplicationShelfNo1 = "DuplicationShelfNo1";    // 棚番1
        private const string CT_DuplicationShelfNo2 = "DuplicationShelfNo2";    // 棚番2
        private const string CT_SupplierCd = "SupplierCd";             // 仕入先コード
        private const string CT_SupplierSnm = "SupplierSnm";            // 仕入先略称
        private const string CT_ListPrice = "ListPrice";              // 標準価格
        private const string CT_StockTotalPrice = "StockTotalPrice";        // 在庫金額
        private const string CT_UpdateDate = "UpdateDate";             // 更新日付
        private const string CT_UpdateDateString = "UpdateDateString";       // 更新日付(フォーマット)
        private const string CT_StockCreateDate = "StockCreateDate";        // 登録日付
        private const string CT_StockCreateDateString = "StockCreateDateString";// 登録日付(フォーマット)

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

        #endregion

        // -------------------------------------------------------------------------------
        #region < グリッド設定ファイル名 >
        private const string CT_GRIDSTATEINFO_GOODS = "MAZAI04110UA_Goods.dat";
        private const string CT_GRIDSTATEINFO_STOCK = "MAZAI04110UA_Stock.dat";
        private const string CT_GRIDSTATEINFO_PRODUCT = "MAZAI04110UA_Product.dat";
        private const string CT_GRIDSTATEINFO_STOCKPRODUCT = "MAZAI04110UA_StockProduct.dat";
        #endregion

        #endregion

        // --- ADD 2012/09/18 ---------->>>>>
        #region < テキスト出力・Excel出力のメッセージ>
        /// <summary>チェック時メッセージ「出力ファイル名が指定されていません。設定ボタンから設定を行ってください。」</summary>
        private const string MSG_OUTPUTFILENAME_NOTFOUND = "出力ファイル名が指定されていません。設定ボタンから設定を行ってください。";
        /// <summary>チェック時メッセージ「出力パターンが設定されていません。設定ボタンから設定を行ってください。」</summary>
        private const string MSG_OUTPUTFILEPATTERN_NOTFOUND = "出力パターンが設定されていません。設定ボタンから設定を行ってください。";
        /// <summary>チェック時メッセージ「ファイルへの出力に失敗しました。」</summary>
        private const string MSG_OUTPUTFILE_FAILED = "ファイルへの出力に失敗しました。";

        /// <summary>テキストエクスポート成功時メッセージ「 行のデータをファイルへ出力しました。」</summary>
        private const string MSG_OUTPUTFILE_SUCCEEDED = "行のデータをファイルへ出力しました。";

        /// <summary>チェック時メッセージ「出力ファイル名が指定されていません。」</summary>
        private const string MSG_OUTPUTEXCEL_NOFILENAME = "出力ファイル名が指定されていません。";

        /// <summary>EXCELエクスポート成功時メッセージ「EXCELデータを出力しました。」</summary>
        private const string MSG_OUTPUTEXCEL_SUCCEEDED = "EXCELデータを出力しました。";        
        #endregion
        // --- ADD 2012/09/18 ----------<<<<<

        #endregion

        // ===============================================================================
        // プライベートstruct
        // ===============================================================================
        # region Private Struct
        /// <summary>
        /// ヘッダ情報　構造体
        /// </summary>
        private struct HeaderInfo
        {
            # region [private fields]

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            private string _sectionCode;
            private string _sectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            private int _goodsMakerCd;
            private string _goodsNo;
            private string _goodsName;
            private string _goodsNameKana;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            private Int32 _goodsNoSrchTyp;
            private Int32 _goodsNameSrchTyp;
            private Int32 _goodsNameKanaSrchTyp;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            private int _bLGoodsCode;
            private string _bLGoodsCodeName;
            private string _warehouseCode;
            private string _warehouseName;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            private int _zeroStockDsp;
            private string _warehouseShelfNo;
            private Int32 _warehouseShelfNoSrchTyp;
            private Int32 _dateDiv;
            private int _stDate;
            private int _edDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            private string _makerName;
            private int _supplierCode;
            private string _supplierName;
            private int _enterpriseGanreCode;

            //  ** support for interchangeability ** 
            // 以下は画面上存在しないが、他アプリケーションからセットされるかもしれないので残しておく
            // 使用されないことが判明したら削除してください
            // 「** support for interchangeability **」タグで検索して削除できます

            //private string _enterpriseGanreName;
            //private string _largeGoodsGanreCode;
            //private string _largeGoodsGanreName;
            //private string _mediumGoodsGanreCode;
            //private string _mediumGoodsGanreName;
            //private string _detailGoodsGanreCode;
            //private string _detailGoodsGanreName;

            # endregion

            # region [public propaties]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            /// <summary>拠点コード</summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>拠点名称</summary>
            public string SectionName
            {
                get { return _sectionName; }
                set { _sectionName = value; }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            /// <summary>メーカーコード</summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>品番</summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>品名</summary>
            public string GoodsName
            {
                get { return _goodsName; }
                set { _goodsName = value; }
            }
            /// <summary>品名カナ</summary>
            public string GoodsNameKana
            {
                get { return _goodsNameKana; }
                set { _goodsNameKana = value; }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            /// <summary>品番検索タイプ</summary>
            public Int32 GoodsNoSrchTyp
            {
                get { return _goodsNoSrchTyp; }
                set { _goodsNoSrchTyp = value; }
            }
            /// <summary>品名検索タイプ</summary>
            public Int32 GoodsNameSrchTyp
            {
                get { return _goodsNameSrchTyp; }
                set { _goodsNameSrchTyp = value; }
            }
            /// <summary>品名カナ検索タイプ</summary>
            public Int32 GoodsNameKanaSrchTyp
            {
                get { return _goodsNameKanaSrchTyp; }
                set { _goodsNameKanaSrchTyp = value; }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            /// <summary>BLコード</summary>
            public int BLGoodsCode
            {
                get { return _bLGoodsCode; }
                set { _bLGoodsCode = value; }
            }
            /// <summary>BLコード名称</summary>
            public string BLGoodsCodeName
            {
                get { return _bLGoodsCodeName; }
                set { _bLGoodsCodeName = value; }
            }
            /// <summary>倉庫コード</summary>
            public string WarehouseCode
            {
                get { return _warehouseCode; }
                set { _warehouseCode = value; }
            }
            /// <summary>倉庫名称</summary>
            public string WarehouseName
            {
                get { return _warehouseName; }
                set { _warehouseName = value; }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            /// <summary>ゼロ在庫表示区分</summary>
            public Int32 ZeroStockDsp
            {
                get { return _zeroStockDsp; }
                set { _zeroStockDsp = value; }
            }
            /// <summary>棚番</summary>
            public string WarehouseShelfNo
            {
                get { return _warehouseShelfNo; }
                set { _warehouseShelfNo = value; }
            }
            /// <summary>棚番検索タイプ</summary>
            public Int32 WarehouseShelfNoSrchTyp
            {
                get { return _warehouseShelfNoSrchTyp; }
                set { _warehouseShelfNoSrchTyp = value; }
            }
            /// <summary>対象日付区分</summary>
            public Int32 DateDiv
            {
                get { return _dateDiv; }
                set { _dateDiv = value; }
            }
            /// <summary>開始対象日付</summary>
            public Int32 St_Date
            {
                get { return _stDate; }
                set { _stDate = value; }
            }
            /// <summary>終了対象日付</summary>
            public Int32 Ed_Date
            {
                get { return _edDate; }
                set { _edDate = value; }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // 以下はパラメータにはないが、前回使用情報ということでプロパティに持っておく

            /// <summary>メーカー名称</summary>
            public string MakerName
            {
                get { return _makerName; }
                set { _makerName = value; }
            }
            /// <summary>仕入先コード</summary>
            public int SupplierCode
            {
                get { return _supplierCode; }
                set { _supplierCode = value; }
            }
            /// <summary>仕入先名称</summary>
            public string SupplierName
            {
                get { return _supplierName; }
                set { _supplierName = value; }
            }
            /// <summary>自社分類コード</summary>
            public int EnterpriseGanreCode
            {
                get { return _enterpriseGanreCode; }
                set { _enterpriseGanreCode = value; }
            }
            // ** support for interchangeability **
            // 以下は互換性確保のために残しておく


            ///// <summary>自社分類名称</summary>
            //public string EnterpriseGanreName
            //{
            //    get { return _enterpriseGanreName; }
            //    set { _enterpriseGanreName = value; }
            //}
            ///// <summary>商品区分グループコード</summary>
            //public string LargeGoodsGanreCode
            //{
            //    get { return _largeGoodsGanreCode; }
            //    set { _largeGoodsGanreCode = value; }
            //}
            ///// <summary>商品区分グループ名称</summary>
            //public string LargeGoodsGanreName
            //{
            //    get { return _largeGoodsGanreName; }
            //    set { _largeGoodsGanreName = value; }
            //}
            ///// <summary>商品区分コード</summary>
            //public string MediumGoodsGanreCode
            //{
            //    get { return _mediumGoodsGanreCode; }
            //    set { _mediumGoodsGanreCode = value; }
            //}
            ///// <summary>商品区分名称</summary>
            //public string MediumGoodsGanreName
            //{
            //    get { return _mediumGoodsGanreName; }
            //    set { _mediumGoodsGanreName = value; }
            //}
            ///// <summary>商品区分詳細コード</summary>
            //public string DetailGoodsGanreCode
            //{
            //    get { return _detailGoodsGanreCode; }
            //    set { _detailGoodsGanreCode = value; }
            //}
            ///// <summary>商品区分詳細名称</summary>
            //public string DetailGoodsGanreName
            //{
            //    get { return _detailGoodsGanreName; }
            //    set { _detailGoodsGanreName = value; }
            //}
            # endregion
        }
        # endregion

        // --- ADD 2012/09/18 ---------->>>>>
        // ===============================================================================
        // プライベートプロパティ
        // ===============================================================================
        #region Private propaties
        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("PMZAI04600U", this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>操作権限の制御リスト</summary>
        private Dictionary<OperationCode, bool> OpeAuthDictionary
        {
            get
            {
                if (_operationAuthorityList == null)
                {
                    _operationAuthorityList = new Dictionary<OperationCode, bool>();
                    _operationAuthorityList.Add(OperationCode.TextOut, !MyOpeCtrl.Disabled((int)OperationCode.TextOut));
                    _operationAuthorityList.Add(OperationCode.ExcelOut, !MyOpeCtrl.Disabled((int)OperationCode.ExcelOut));
                }
                return _operationAuthorityList;
            }
        }
        #endregion
        // --- ADD 2012/09/18 ----------<<<<<

        // ===============================================================================
        // 外部列挙型
        // ===============================================================================
        #region Public Enum

        /// <summary>
        /// ガイドモード
        /// </summary>
        public enum emSearchMode : int
        {
            /// <summary>在庫 (単一行選択)</summary>
            Stock = 0,
            /// <summary>商品在庫 (複数行選択)</summary>
            GoodsStock = 1,
            /// <summary>商品</summary>
            Goods = 3,
            /// <summary>在庫結果表示</summary>
            ResultStock = 5,
        }

        // --- ADD 2012/09/18 ---------->>>>>
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }

        /// <summary>
        /// オペレーションコード
        /// </summary>
        public enum OperationCode : int
        {
            /// <summary>テキスト出力</summary>
            TextOut = 1,
            /// <summary>エクセル出力</summary>
            ExcelOut = 2,
            /// <summary>再発行</summary>
            ReissueSlip = 3
        }
        // --- ADD 2012/09/18 ----------<<<<<

        #endregion

        // ===============================================================================
        // 外部プロパティ
        // ===============================================================================
        #region Public Property

        /// <summary>
        /// タイトルテキスト
        /// </summary>
        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        /// <summary>
        /// 複数選択可能
        /// </summary>
        public bool IsMultiSelect
        {
            get { return this._isMultiSelect; }
            set { this._isMultiSelect = value; }
        }

        /// <summary>
        /// タッチパネル
        /// </summary>
        public bool IsTouchPanel
        {
            get { return this._isTouchPanel; }
            set { this._isTouchPanel = value; }
        }

        /// <summary>
        /// 抽出条件入力
        /// </summary>
        public bool IsInputSearchParam
        {
            get { return this._isInputSearchParam; }
            set { this._isInputSearchParam = value; }
        }


        /// <summary>
        /// 抽出条件固定(拠点)
        /// </summary>
        public bool IsFixedSection
        {
            set { this._isFixedSection = value; }
        }

        /// <summary>
        /// 抽出条件固定(キャリア)
        /// </summary>
        public bool IsFixedCarrierCod
        {
            set { this._isFixedCarrierCode = value; }
        }

        /// <summary>
        /// 抽出条件固定(倉庫)
        /// </summary>
        public bool IsFixedWarehouseCode
        {
            set { this._isFixedWarehouseCode = value; }
        }

        /// <summary>
        /// 抽出条件固定(ゼロ在庫表示)
        /// </summary>
        public bool IsFixedStockZero
        {
            set { this._isFixedStockZero = value; }
        }

        #endregion

        // ===============================================================================
        // 外部提供関数
        // ===============================================================================
        #region Public Method

        #region <  在庫検索ガイド >

        /// <summary>
        /// 在庫検索ガイド
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="searchMode">検索モード列挙型</param>
        /// <param name="isAutoSearch">自動検索モード[true:自動検索する,false:自動検索しない]</param>
        /// <param name="para">検索パラメータ</param>
        /// <param name="retObject">検索モードに応じた結果リスト</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowGuide(IWin32Window owner, emSearchMode searchMode, bool isAutoSearch, StockSearchPara para, out object retObject)
        {
            retObject = null;

            this._isAutoSearch = isAutoSearch;
            this._enterpriseCode = para.EnterpriseCode;
            this._searchMode = (int)searchMode;

            // 選択結果リスト初期化
            if (this._selStock == null)
                this._selStock = new List<StockExpansion>();
            else
                this._selStock.Clear();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this._selProduct == null)
            //    this._selProduct = new List<ProductStock>();
            //else
            //    this._selProduct.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            // 抽出条件パラメータを設定する
            this._setSearchParam = para.Clone();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 在庫状態
            //if (para.StockState != null && para.StockState.Length > 0)
            //{
            //    this._defStockState = new Int32[para.StockState.Length];
            //    para.StockState.CopyTo(this._defStockState, 0);
            //}
            //else
            //{
            //    this._defStockState = new Int32[0];
            //}

            //// 移動状態状態
            //if (para.MoveStatus != null && para.MoveStatus.Length > 0)
            //{
            //    this._defMoveStatus = new Int32[para.MoveStatus.Length];
            //    para.MoveStatus.CopyTo(this._defMoveStatus, 0);
            //}
            //else
            //{
            //    this._defMoveStatus = new Int32[0];
            //}

            //// 商品状態
            //if (para.MoveStatus != null && para.MoveStatus.Length > 0)
            //{
            //    this._defGoodsCodeStatus = new Int32[para.GoodsCodeStatus.Length];
            //    para.GoodsCodeStatus.CopyTo(this._defGoodsCodeStatus, 0);
            //}
            //else
            //{
            //    this._defGoodsCodeStatus = new Int32[0];
            //}

            //// 製造番号検索区分
            //this._defProductNumberSrchDivCd = para.ProductNumberSrchDivCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            Infragistics.Win.UltraWinToolbars.ButtonTool quitButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo];
            Infragistics.Win.UltraWinToolbars.ButtonTool decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
            Infragistics.Win.UltraWinToolbars.ButtonTool PopdecisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_PopDecision];  // T.Nishi 2012/04/10 ADD
            Infragistics.Win.UltraWinToolbars.ButtonTool backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Back];
            //Infragistics.Win.UltraWinToolbars.ButtonTool undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo];  // T.Nishi 2012/04/10 DEL
            Infragistics.Win.UltraWinToolbars.ButtonTool undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_PopUndo];  // T.Nishi 2012/04/10 ADD

            quitButton.SharedProps.Visible = false;
            decisionButton.SharedProps.Visible = true;
            PopdecisionButton.SharedProps.Visible = true;  // T.Nishi 2012/04/10 ADD
            backButton.SharedProps.Visible = true;
            undoButton.SharedProps.Visible = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search];
            searchButton.SharedProps.Visible = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            DialogResult dr = DialogResult.Cancel;

            dr = base.ShowDialog(owner);
            if (dr == DialogResult.OK)
            {
                switch (this._searchMode)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //case (int)emSearchMode.Goods:
                    //    // 商品検索の場合

                    //    break;
                    //case (int)emSearchMode.GoodsStock:
                    //case (int)emSearchMode.ResultStockNoButton:
                    //    // 在庫検索の場合
                    //    List<Stock> retStockList = new List<Stock>(this._selStock);
                    //    retObject = retStockList;

                    //    break;
                    //case (int)emSearchMode.Product:
                    //case (int)emSearchMode.ResultProduct:
                    //    // 製番検索の場合
                    //    List<ProductStock> retProductList = new List<ProductStock>(this._selProduct);
                    //    retObject = retProductList;

                    //    break;
                    //case (int)emSearchMode.ProductwitchStock:
                    //case (int)emSearchMode.Stock:
                    //case (int)emSearchMode.ResultStock:
                    //case (int)emSearchMode.ResultProductwitchStock:
                    //    // 在庫＆製番検索の場合
                    //    List<Stock> retStockList2 = new List<Stock>(this._selStock);
                    //    List<ProductStock> retProductList2 = new List<ProductStock>(this._selProduct);

                    //    ArrayList retList = new ArrayList(2);
                    //    retList.Add(retStockList2);
                    //    retList.Add(retProductList2);

                    //    retObject = retList;

                    //    break;

                    case (int)emSearchMode.Goods:
                        // 商品検索の場合

                        break;
                    case (int)emSearchMode.GoodsStock:
                    case (int)emSearchMode.ResultStock:
                    case (int)emSearchMode.Stock:
                        // 在庫検索の場合
                        // TODO 外部に返すオブジェクトはstockクラスを使用する
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA MODIFY START
                        List<StockExpansion> retStockListEx = new List<StockExpansion>(this._selStock);
                        List<Stock> retStockList = new List<Stock>();

                        // 全てのStockExpantionクラスをStockクラスに変換する
                        foreach (StockExpansion stockEx in retStockListEx)
                        {
                            retStockList.Add(StockExpansion.ConvertToStock(stockEx));
                        }

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA MODIFY END
                        retObject = retStockList;

                        break;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
            }

            return dr;
        }

        /// <summary>
        /// 在庫検索ガイド
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="searchMode">検索モード列挙型</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retObject">検索モードに応じた結果リスト</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowGuide(IWin32Window owner, emSearchMode searchMode, string enterpriseCode, out object retObject)
        {
            // 検索条件設定
            StockSearchPara para = new StockSearchPara();
            para.EnterpriseCode = enterpriseCode;

            return ShowGuide(owner, searchMode, false, para, out retObject);
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 照会表示
        /// </summary>
        public void ShowReference(emSearchMode searchMode, string enterpriseCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._searchMode = (int)searchMode;
            this._isAutoSearch = false;

            // 選択結果リスト初期化
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA MODIFY START
            //if ( this._selStock == null )
            //this._selStock = new List<StockExpansion>();
            //else
            //this._selStock.Clear();
            if (this._selectedStockList == null)
            {
                this._selectedStockList = new List<Stock>();
            }
            else
            {
                this._selectedStockList.Clear();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA MODIFY END

            // 抽出条件パラメータを設定する
            this._setSearchParam = new StockSearchPara();
            this._setSearchParam.EnterpriseCode = enterpriseCode;

            Infragistics.Win.UltraWinToolbars.ButtonTool quitButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo];
            Infragistics.Win.UltraWinToolbars.ButtonTool decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
            Infragistics.Win.UltraWinToolbars.ButtonTool PopdecisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_PopDecision];  // T.Nishi 2012/04/10 ADD
            Infragistics.Win.UltraWinToolbars.ButtonTool backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Back];
            Infragistics.Win.UltraWinToolbars.ButtonTool undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo];

            quitButton.SharedProps.Visible = true;
            decisionButton.SharedProps.Visible = false;
            PopdecisionButton.SharedProps.Visible = false;  // T.Nishi 2012/04/10 ADD
            backButton.SharedProps.Visible = false;
            undoButton.SharedProps.Visible = true;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search];
            searchButton.SharedProps.Visible = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // 照会モードセット
            _isReference = true;

            // Form表示
            this.Show();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion

        #region <　在庫データ移行処理　>

        /// <summary>
        /// 在庫データ移行処理
        /// </summary>
        /// <param name="stockSearchRetLst">該当のデータリスト</param>
        public void ShiftStockData(List<StockExpansion> stockSearchRetLst)
        //public void ShiftStockData(List<Stock> stockSearchRetLst)
        {
            this.SettingDataSet();

            // テーブルを初期化する
            if (this._stockDataTable != null)
                this._stockDataTable.Rows.Clear();

            //if (this._productStockDataTable != null)
            //  this._productStockDataTable.Rows.Clear();

            // データ設定
            string msg;
            if (this.SetStockDataTable(stockSearchRetLst, out msg) != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, -1, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 在庫データ移行処理
        /// </summary>
        /// <param name="dataView">該当のデータビュー</param>
        public void ShiftStockData(DataView dataView)
        {
            this.SettingDataSet();

            // テーブルを初期化する
            if (this._stockDataTable != null)
                this._stockDataTable.Rows.Clear();

            //if (this._productStockDataTable != null)
            //  this._productStockDataTable.Rows.Clear();

            // データコピー
            for (int i = 0; i < dataView.Count; i++)
            {
                object[] itemObj = dataView[i].Row.ItemArray;
                DataRow row = this._stockDataTable.NewRow();
                row.ItemArray = itemObj;

                this._stockDataTable.Rows.Add(row);
            }
        }

        #endregion

        #region <　製番在庫データ移行処理　>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 在庫データ移行処理
        ///// </summary>
        ///// <param name="productStockRetLst">該当のデータリスト</param>
        //public void ShiftProductData(List<ProductStock> productStockRetLst)
        //{
        //    this.SettingDataSet();

        //    // テーブルを初期化する
        //    //if (this._stockDataTable != null)
        //    //  this._stockDataTable.Rows.Clear();

        //    if (this._productStockDataTable != null)
        //        this._productStockDataTable.Rows.Clear();

        //    // データ設定
        //    string msg;
        //    if (this.SetProductStockDataTable(productStockRetLst, out msg) != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
        //    {
        //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, -1, MessageBoxButtons.OK);
        //    }
        //}


        ///// <summary>
        ///// 製番在庫データ移行処理
        ///// </summary>
        ///// <param name="dataView">該当のデータビュー</param>
        //public void ShiftProductData(DataView dataView)
        //{
        //    this.SettingDataSet();

        //    // テーブルを初期化する
        //    //if (this._stockDataTable != null)
        //    //  this._stockDataTable.Rows.Clear();

        //    if (this._productStockDataTable != null)
        //        this._productStockDataTable.Rows.Clear();

        //    // データコピー
        //    for (int i = 0; i < dataView.Count; i++)
        //    {
        //        object[] itemObj = dataView[i].Row.ItemArray;
        //        DataRow row = this._productStockDataTable.NewRow();
        //        row.ItemArray = itemObj;

        //        this._productStockDataTable.Rows.Add(row);
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #region <　在庫+製番在庫データ移行処理　>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 在庫データ移行処理
        ///// </summary>
        ///// <param name="stockRetLst">該当の在庫データリスト</param>
        ///// <param name="productStockRetLst">該当の製番在庫データリスト</param>
        //public void ShiftData(List<Stock> stockRetLst, List<ProductStock> productStockRetLst)
        //{
        //    this.SettingDataSet();

        //    // テーブルを初期化する
        //    if (this._stockDataTable != null)
        //        this._stockDataTable.Rows.Clear();

        //    if (this._productStockDataTable != null)
        //        this._productStockDataTable.Rows.Clear();

        //    // データ設定
        //    string msg;

        //    if (this.SetStockDataTable(stockRetLst, out msg) != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
        //    {
        //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, -1, MessageBoxButtons.OK);
        //    }

        //    if (this.SetProductStockDataTable(productStockRetLst, out msg) != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
        //    {
        //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, -1, MessageBoxButtons.OK);
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #region <　在庫検索(選択フォームあり)　>

        /// <summary>
        /// 在庫検索(選択フォームあり)②
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="stockSearchPara">検索条件パラメータ</param>
        /// <param name="retObject">検索結果リスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.MethodResult</returns>
        public int ReadStock(IWin32Window owner, StockSearchPara stockSearchPara, out object retObject, out string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            msg = "";
            retObject = new List<StockExpansion>();
            List<StockExpansion> workRetList;
            //List<Stock> workRetList;

            try
            {
                // 検索条件設定
                StockSearchPara para = stockSearchPara.Clone();

                status = this._searchStockAcs.Search(para, out workRetList, out msg);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (workRetList == null || workRetList.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                msg = "該当のデータはありません";
                                break;
                            }

                            if (workRetList.Count > 1)
                            {
                                // 該当が複数件ある場合は選択ガイドを起動

                                // 在庫選択ガイド生成
                                StockSearchGuide selGuide = new StockSearchGuide();

                                // ガイドデータを渡す
                                selGuide.ShiftStockData(workRetList);

                                selGuide.Title = "在庫選択";

                                emSearchMode searchMode = emSearchMode.ResultStock;
                                selGuide.IsMultiSelect = this.IsMultiSelect;

                                // ガイド表示
                                DialogResult dr = selGuide.ShowGuide(this, searchMode, false, para.Clone(), out retObject);

                                if (dr == DialogResult.OK)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                }
                                else
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                }
                            }
                            else if (workRetList.Count == 1)
                            {
                                // １件のみの場合はそのまま確定してreturn
                                retObject = workRetList;
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        msg = "該当のデータはありません";
                        break;
                    default:
                        msg = "在庫の取得でエラーが発生しました";
                        break;
                }

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                msg = "在庫の取得にて例外が発生しました[" + ex.Message + "]";
            }

            return status;
        }


        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //#region < 倉庫毎在庫検索(選択フォームあり)　>

        ///// <summary>
        ///// 倉庫毎在庫検索(選択フォームあり)
        ///// </summary>
        ///// <param name="owner">オーナーフォーム</param>
        ///// <param name="isMultiSelect">商品複数選択</param>
        ///// <param name="stockSearchPara">検索条件パラメータ</param>
        ///// <param name="retObject">検索結果リスト</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns>ConstantManagement.MethodResult</returns>
        //public int ReadStockByWarehouse(IWin32Window owner, bool isMultiSelect, StockSearchPara stockSearchPara, out object retObject, out string msg)
        //{
        //    int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

        //    // テーブルの初期化
        //    this.SettingDataSet();
        //    this._stockDataTable.Rows.Clear();
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //this._productStockDataTable.Rows.Clear();
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    msg = "";
        //    List<StockExpansion> stockList;
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //List<ProductStock> productStockList;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    retObject = null;

        //    try
        //    {
        //        // 検索条件設定
        //        StockSearchPara para = stockSearchPara.Clone();

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        // 保留

        //        //// 拠点コード＆倉庫コード未設定は検索できないので対象外
        //        //if (para.SectionCode.Equals(string.Empty) || string.IsNullOrEmpty(para.WarehouseCode))
        //        //    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //// データ取得区分(0:全て(在庫+製番在庫),1:在庫,2:製番在庫)
        //        //para.DataAcqrDiv = 0;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //status = this._searchStockAcs.Search(para, out stockList, out productStockList, out msg);
        //        status = this._searchStockAcs.Search(para, out stockList, out msg);
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                {
        //                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //                    //if (productStockList == null || productStockList.Count == 0)
        //                    if ( stockList == null || stockList.Count == 0 )
        //                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //                    {
        //                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                        msg = "該当のデータはありません";
        //                        break;
        //                    }

        //                    bool isWarningMsg = false;

        //                    // 在庫
        //                    status = this.SetStockDataTable(stockList, out msg);
        //                    switch (status)
        //                    {
        //                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
        //                            break;
        //                        case (int)ConstantManagement.MethodResult.ctFNC_WARNING:
        //                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
        //                            isWarningMsg = true;
        //                            break;
        //                        default:
        //                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, 0, MessageBoxButtons.OK);
        //                            break;

        //                    }

        //                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //                    //// 製番
        //                    //status = this.SetProductStockDataTable(productStockList, out msg);
        //                    //switch (status)
        //                    //{
        //                    //    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
        //                    //        break;
        //                    //    case (int)ConstantManagement.MethodResult.ctFNC_WARNING:
        //                    //        if (!isWarningMsg)
        //                    //            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
        //                    //        break;
        //                    //    default:
        //                    //        if (!isWarningMsg)
        //                    //            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, 0, MessageBoxButtons.OK);
        //                    //        break;
        //                    //}
        //                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //                    // 倉庫毎再計算
        //                    this.CalculationStockByWarehouse();

        //                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //                    //if (this._stockDataView.Count > 1)
        //                    //{
        //                    //    // 製番選択ガイドを起動する
        //                    //    StockSearchGuide selGuide = new StockSearchGuide();

        //                    //    stockList = this.GetStockListDataTable();
        //                    //    productStockList = this.GetProductStockListDataTable();

        //                    //    // データを移行してあげる
        //                    //    selGuide.ShiftData(stockList, productStockList);

        //                    //    selGuide.Title = "在庫選択";
        //                    //    selGuide.IsMultiSelect = this.IsMultiSelect;

        //                    //    DialogResult dr = selGuide.ShowGuide(this, emSearchMode.ResultStock, false, para.Clone(), out retObject);
        //                    //    if (dr == DialogResult.OK)
        //                    //    {
        //                    //        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //                    //    }
        //                    //}
        //                    //else if (this._stockDataView.Count == 1)
        //                    //{
        //                    //    stockList = new List<Stock>();
        //                    //    Stock stockEx = (this._stockDataView[0].Row[CT_StockSearchRet] != DBNull.Value) ? (Stock)this._stockDataView[0].Row[CT_StockSearchRet] : null;
        //                    //    stockList.Add(stockEx);
        //                    //    retObject = stockList; 
        //                    //}

        //                    if (this._stockDataView.Count > 0)
        //                    {
        //                        stockList = new List<StockExpansion>();
        //                        StockExpansion stockEx = (this._stockDataView[0].Row[CT_StockSearchRet] != DBNull.Value) ? (StockExpansion)this._stockDataView[0].Row[CT_StockSearchRet] : null;
        //                        stockList.Add(stockEx);
        //                        retObject = stockList; 
        //                    }
        //                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


        //                    break;
        //                }
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                msg = "該当のデータはありません";
        //                break;
        //            default:
        //                msg = "在庫の取得でエラーが発生しました";
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR; ;
        //        msg = "在庫の取得にて例外が発生しました[" + ex.Message + "]";
        //    }

        //    return status;


        //}

        //#endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #region <　製番検索(選択フォームあり)　>

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 製番検索(選択フォームあり)
        ///// </summary>
        ///// <param name="owner">オーナーフォーム</param>
        ///// <param name="isMultiSelect">商品複数選択</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="srchTyp">検索タイプ[0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索]</param>
        ///// <param name="productNumber">製番コード</param>
        ///// <param name="retList">製番在庫リスト</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns>ConstantManagement.MethodResult</returns>
        //public int ReadProduct(IWin32Window owner, bool isMultiSelect, string enterpriseCode, int srchTyp, string productNumber, out List<ProductStock> retList, out string msg)
        //{
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    stockSearchPara.EnterpriseCode = enterpriseCode;
        //    stockSearchPara.ProductNumber = productNumber;
        //    stockSearchPara.ProductNumberSrchTyp = srchTyp;

        //    return ReadProduct(owner, isMultiSelect, stockSearchPara, out retList, out msg);
        //}


        ///// <summary>
        ///// 製番検索(選択フォームあり)
        ///// </summary>
        ///// <param name="owner">オーナーフォーム</param>
        ///// <param name="stockSearchPara">検索条件パラメータ</param>
        ///// <param name="retList">製番在庫リスト</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns>ConstantManagement.MethodResult</returns>
        //public int ReadProduct(IWin32Window owner, StockSearchPara stockSearchPara, out List<ProductStock> retList, out string msg)
        //{
        //    return ReadProduct(owner, false, stockSearchPara, out retList, out msg);
        //}

        ///// <summary>
        ///// 製番検索(選択フォームあり)
        ///// </summary>
        ///// <param name="owner">オーナーフォーム</param>
        ///// <param name="isMultiSelect">商品複数選択</param>
        ///// <param name="stockSearchPara">検索条件パラメータ</param>
        ///// <param name="retList">製番在庫リスト</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns>ConstantManagement.MethodResult</returns>
        //public int ReadProduct(IWin32Window owner, bool isMultiSelect, StockSearchPara stockSearchPara, out List<ProductStock> retList, out string msg)
        //{
        //    int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

        //    msg = "";
        //    List<Stock> stockList;
        //    retList = null;

        //    try
        //    {
        //        // 検索条件設定
        //        StockSearchPara para = stockSearchPara.Clone();
        //        // データ取得区分(0:全て(在庫+製番在庫),1:在庫,2:製番在庫)
        //        para.DataAcqrDiv = 2;

        //        status = this._searchStockAcs.Search(para, out stockList, out retList, out msg);
        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                {
        //                    if (retList == null || retList.Count == 0)
        //                    {
        //                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                        msg = "該当のデータはありません";
        //                        break;
        //                    }

        //                    if (retList.Count > 1)
        //                    {
        //                        // 製番選択ガイドを起動する
        //                        StockSearchGuide selGuide = new StockSearchGuide();

        //                        // データを移行してあげる
        //                        selGuide.ShiftProductData(retList);

        //                        selGuide.Title = "製番選択";
        //                        selGuide.IsMultiSelect = this.IsMultiSelect;

        //                        object retObject; 

        //                        DialogResult dr = selGuide.ShowGuide(this, emSearchMode.ResultProduct, false, para.Clone(), out retObject);
        //                        if (dr == DialogResult.OK)
        //                        {
        //                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

        //                            retList = retObject as List<ProductStock>; 
        //                        }
        //                        else
        //                        {
        //                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //                        }
        //                    }

        //                    break;
        //                }
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                msg = "該当のデータはありません";
        //                break;
        //            default:
        //                msg = "在庫の取得でエラーが発生しました";
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;;
        //        msg = "在庫の取得にて例外が発生しました[" + ex.Message + "]";
        //    }

        //    return status;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion

        #region <　製番(+製番在庫)検索(選択フォームあり)　>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 製番(+製番在庫)検索(選択フォームあり)
        ///// </summary>
        ///// <param name="owner">オーナーフォーム</param>
        ///// <param name="isMultiSelect">商品複数選択</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="srchTyp">検索タイプ[0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索]</param>
        ///// <param name="productNumber">製番コード</param>
        ///// <param name="retObject">検索結果オブジェクト</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns>ConstantManagement.MethodResult</returns>
        //public int ReadProduct(IWin32Window owner, bool isMultiSelect, string enterpriseCode, int srchTyp, string productNumber, out object retObject, out string msg)
        //{
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    stockSearchPara.EnterpriseCode = enterpriseCode;
        //    stockSearchPara.ProductNumber = productNumber;
        //    stockSearchPara.ProductNumberSrchTyp = srchTyp;

        //    return ReadProduct(owner, isMultiSelect, stockSearchPara, out retObject, out msg);
        //}

        ///// <summary>
        ///// 製番(+製番在庫)検索(選択フォームあり)
        ///// </summary>
        ///// <param name="owner">オーナーフォーム</param>
        ///// <param name="stockSearchPara">検索条件パラメータ</param>
        ///// <param name="retObject">検索結果オブジェクト</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns>ConstantManagement.MethodResult</returns>
        //public int ReadProduct(IWin32Window owner, StockSearchPara stockSearchPara, out object retObject, out string msg)
        //{
        //    return ReadProduct(owner, false, stockSearchPara, out retObject, out msg);
        //}

        ///// <summary>
        ///// 製番(+製番在庫)検索(選択フォームあり)
        ///// </summary>
        ///// <param name="owner">オーナーフォーム</param>
        ///// <param name="isMultiSelect">商品複数選択</param>
        ///// <param name="stockSearchPara">検索条件パラメータ</param>
        ///// <param name="retObject">検索結果オブジェクト</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns>ConstantManagement.MethodResult</returns>
        //public int ReadProduct(IWin32Window owner, bool isMultiSelect, StockSearchPara stockSearchPara, out object retObject, out string msg)
        //{
        //    int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

        //    msg = "";
        //    List<Stock> stockList;
        //    List<ProductStock> pruductStockList;
        //    retObject = null;

        //    try
        //    {
        //        // 検索条件設定
        //        StockSearchPara para = stockSearchPara.Clone();
        //        // データ取得区分(0:全て(在庫+製番在庫),1:在庫,2:製番在庫)
        //        para.DataAcqrDiv = 0;

        //        status = this._searchStockAcs.Search(para, out stockList, out pruductStockList, out msg);
        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                {
        //                    if (pruductStockList == null || pruductStockList.Count == 0)
        //                    {
        //                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                        msg = "該当のデータはありません";
        //                        break;
        //                    }

        //                    if (pruductStockList.Count > 1)
        //                    {
        //                        // 製番選択ガイドを起動する
        //                        StockSearchGuide selGuide = new StockSearchGuide();

        //                        // データを移行してあげる
        //                        selGuide.ShiftData(stockList, pruductStockList);

        //                        selGuide.Title = "製番選択";
        //                        selGuide.IsMultiSelect = this.IsMultiSelect;

        //                        DialogResult dr = selGuide.ShowGuide(this, emSearchMode.ResultProductwitchStock, false, para.Clone(), out retObject);
        //                        if (dr == DialogResult.OK)
        //                        {
        //                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //                        }
        //                        else
        //                        {
        //                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ArrayList retList = new ArrayList();

        //                        if (stockList != null)
        //                            retList.Add(stockList);
        //                        if (pruductStockList != null)
        //                            retList.Add(pruductStockList);

        //                        retObject = retList;
        //                    }

        //                    break;
        //                }
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
        //                msg = "該当のデータはありません";
        //                break;
        //            default:
        //                msg = "在庫の取得でエラーが発生しました";
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR; ;
        //        msg = "在庫の取得にて例外が発生しました[" + ex.Message + "]";
        //    }

        //    return status;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #endregion

        //================================================================================
        //  内部関数
        //================================================================================
        #region Private Methods

        // --------------------------------------------------
        #region < 画面表示設定等 >

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.10</br>
        /// <br>--------------------------------------</br>
        /// <br>Update Note: PM.NS対応。</br>
        /// <br>Date       : 2008.8.04</br>
        /// <br>Programmer : 30418 S.Tokunaga</br>
        /// <br>Update Note: 2009/09/07       汪千来</br>
        /// <br>           : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// </remarks>
        private void InitialSetting()
        {
            // アイコンの設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //this.Search_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SEARCH];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.CellphoneModelGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            //this.CarrierGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            //this.CarrierEpGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.07 TOKUNAGA ADD START
            this.uButton_SectionGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.07 TOKUNAGA ADD END
            this.BLGoodsCodeGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.DetailGoodsGanreGide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.EnterpriseGanreCodeGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.LargeGoodsGanreCodeGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.MediumGoodsGanreGide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];

            this.MakerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_SupplierGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_WarehouseGuide.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];

            // 自拠点コードを取得する
            //this.tEdit_SectionCode.Text = LoginInfoAcquisition.Employee.BelongSectionCode; // DEL 2009/03/09
            //this.tEdit_SectionCode.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'); // ADD 2009/03/09 // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.Text = LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'); // ADD 2009/09/07
            //this.tEdit_SectionCode_Leave(null, null);// DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero_Leave(null, null);// ADD 2009/09/07

            // 拠点はコンボボックス→入力＋ガイドボタンに変更
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            // 拠点情報の設定
            //if (this._secInfoAcs.SecInfoSetList != null && this._secInfoAcs.SecInfoSetList.Length > 0)
            //{
            //    // 複数拠点ありの場合は「全拠点」を設定しておく
            //    if (this._secInfoAcs.SecInfoSetList.Length > 1)
            //    {
            //        this.Section_ComboEditor.Items.Add("", "全拠点");
            //    }

            //    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            //    {
            //        this.Section_ComboEditor.Items.Add(secInfoSet.SectionCode.Trim(), secInfoSet.SectionGuideNm);
            //    }

            //    this.Section_ComboEditor.Value = this._loginSectionCode;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            //string msg;

            //>>>ddd
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 商品アクセスクラス初期化
            //int status = this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);
            //if ( status != ( int ) ConstantManagement.DB_Status.ctDB_NORMAL ) {
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, status, MessageBoxButtons.OK);
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //<<<ddd

            // ADD 2008/10/09 不具合対応[6382] ---------->>>>>
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // ADD 2008/10/09 不具合対応[6382] ----------<<<<<

#if false			
			// キャリア情報を取得する
			List<Carrier> carrierLst;
			status = this._goodsAcs.GetOwnDispCarrier(this._enterpriseCode, this._loginSectionCode, out carrierLst);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (carrierLst != null && carrierLst.Count > 0)
				{
					// 複数キャリアありの場合は「全キャリア」を設定しておく
					if (carrierLst.Count > 0)
					{
						this.CarrierName_tEdit.Items.Add(0, "全キャリア");
					}

					int selCarrierCode = 0;
					bool isFirst = false;
					foreach (Carrier carrier in carrierLst)
					{
						if (!isFirst)
							selCarrierCode = carrier.CarrierCode; 

						this.CarrierName_tEdit.Items.Add(carrier.CarrierCode, carrier.CarrierName);
						isFirst = true;
					}

					this.CarrierName_tEdit.Value = selCarrierCode;
				}
			}
#endif

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 製番表示の場合の列調整デフォルト
            //if (this._searchMode == (int)emSearchMode.Product ||
            //    this._searchMode == (int)emSearchMode.ProductwitchStock ||
            //    this._searchMode == (int)emSearchMode.ResultProduct ||
            //    this._searchMode== (int)emSearchMode.ResultProductwitchStock)
            //{
            //    this.gridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            //    this.AutoFillToGridColumn_CheckEditor.Checked = false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 抽出条件非表示
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if (this._searchMode == (int)emSearchMode.ResultProduct || 
            //    this._searchMode == (int)emSearchMode.ResultProductwitchStock ||
            //    this._searchMode == (int)emSearchMode.ResultStock ||
            //    this._searchMode == (int)emSearchMode.ResultStockNoButton)
            if (this._searchMode == (int)emSearchMode.ResultStock)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            {
                this.Standard_UGroupBox.Visible = false;
                this.Detail_UGroupBox.Visible = false;
            }

            // タッチパネル対応の場合
            if (this._isTouchPanel)
            {
                RightScrol_panel.Visible = true;
                BottomScrol_panel.Visible = true;
            }
            else
            {
                RightScrol_panel.Visible = false;
                BottomScrol_panel.Visible = false;
            }

        }

        /// <summary>
        /// 検索モードによる抽出条件コントロール制御
        /// </summary>
        /// <param name="searchMode"></param>
        private void DispChangeControl(int searchMode)
        {
            this.ProductOder_tToolbarsManager.Visible = false;

            // タブ表示順位
            int tabIndex = 0;

#if false
			// 起動モード別に表示するコントロールを制御する
			switch (this._searchMode)
			{
				// 商品在庫
				case (int)emSearchMode.GoodsStock: {
            #region << 基本条件のコントロール配置 >>

                        // 拠点
                        this.Section_Title_ULabel.Visible = true;
                        this.Section_Title_ULabel.Location = new Point(CT_GROUP1_COL1_TITLE_START_X, CT_GROUP1_COL1_TITLE_START_Y);

                        this.Section_ComboEditor.Visible = true;
                        this.Section_ComboEditor.Enabled = this._isInputSearchParam;

                        // 拠点固定
                        if ( this.Section_ComboEditor.Enabled ) {
                            if ( this._isFixedSection )
                                this.Section_ComboEditor.Enabled = false;
                            else
                                this.Section_ComboEditor.Enabled = true;
                        }

                        this.Section_ComboEditor.Location = new Point(CT_GROUP1_COL1_CONTROL_START_X, CT_GROUP1_COL1_CONTROL_START_Y);
                        this.Section_ComboEditor.TabIndex = tabIndex;

                        // 商品コード
                        this.GoodsCode_Title_ULabel.Visible = true;
                        this.GoodsCode_Title_ULabel.Location = this.NextPosition(this.Section_ComboEditor.Location.X, this.Section_ComboEditor.Location.Y);

                        this.GoodsCode_tEdit.Visible = true;
                        this.GoodsCode_tEdit.Enabled = this._isInputSearchParam;
                        this.GoodsCode_tEdit.Location = this.NextPosition(this.Section_ComboEditor.Location.X, this.Section_ComboEditor.Location.Y);
                        this.GoodsCode_tEdit.TabIndex = ++tabIndex;

                        // 商品カナ
                        this.GoodsNameKana_Title_ULabel.Visible = true;
                        this.GoodsNameKana_Title_ULabel.Location = this.NextPosition(this.GoodsCode_Title_ULabel.Location.X, this.GoodsCode_Title_ULabel.Location.Y);

                        this.GoodsNameKana_tEdit.Visible = true;
                        this.GoodsNameKana_tEdit.Enabled = this._isInputSearchParam;
                        this.GoodsNameKana_tEdit.Location = this.NextPosition(this.GoodsCode_tEdit.Location.X, this.GoodsCode_tEdit.Location.Y);
                        this.GoodsNameKana_tEdit.TabIndex = ++tabIndex;

                        // ゼロ在庫表示
                        this.StockZero_Title_Label.Visible = true;
                        this.StockZero_Title_Label.Location = new Point(CT_GROUP1_COL2_TITLE_START_X, CT_GROUP1_COL2_TITLE_START_Y);

                        this.StockZero_tComboEditor.Visible = true;
                        this.StockZero_tComboEditor.Enabled = this._isInputSearchParam;

                        // ゼロ在庫表示固定
                        if ( this.StockZero_tComboEditor.Enabled ) {
                            if ( this._isFixedStockZero )
                                this.StockZero_tComboEditor.Enabled = false;
                            else
                                this.StockZero_tComboEditor.Enabled = true;
                        }

                        this.StockZero_tComboEditor.Location = new Point(CT_GROUP1_COL2_CONTROL_START_X, CT_GROUP1_COL2_CONTROL_START_Y);
                        this.StockZero_tComboEditor.TabIndex = ++tabIndex;

                        #endregion

            #region << 詳細条件のコントロール配置 >>

                        // タブ順を初期値に設定する
                        tabIndex = 0;

                        // メーカー
                        this.MakerCode_Title_Label.Visible = true;
                        this.MakerCode_Title_Label.Location = new Point(CT_GROUP2_COL1_TITLE_START_X, CT_GROUP2_COL1_TITLE_START_Y);

                        this.MakerName_tEdit.Visible = true;
                        this.MakerName_tEdit.Enabled = this._isInputSearchParam;
                        this.MakerName_tEdit.Location = new Point(CT_GROUP2_COL1_CONTROL_START_X, CT_GROUP2_COL1_CONTROL_START_Y);
                        this.MakerName_tEdit.TabIndex = tabIndex;

                        this.MakerGuide_Button.Visible = true;
                        this.MakerGuide_Button.Location = new Point(this.MakerName_tEdit.Location.X + this.MakerName_tEdit.Width + CT_GUIDEBUTTON_INTERVAL,
                            this.MakerName_tEdit.Location.Y);
                        this.MakerGuide_Button.TabIndex = ++tabIndex;

                        // 商品グループ
                        this.LargeGoodsGanreCodeName_Title_Label.Visible = true;
                        this.LargeGoodsGanreCodeName_Title_Label.Location = this.NextPosition(this.MakerCode_Title_Label.Location.X, this.MakerCode_Title_Label.Location.Y);

                        this.LargeGoodsGanreName_tEdit.Visible = true;
                        this.LargeGoodsGanreName_tEdit.Enabled = this._isInputSearchParam;
                        this.LargeGoodsGanreName_tEdit.Location = this.NextPosition(this.MakerName_tEdit.Location.X, this.MakerName_tEdit.Location.Y);
                        this.LargeGoodsGanreName_tEdit.TabIndex = ++tabIndex;

                        this.LargeGoodsGanreCodeGuide_Button.Visible = true;
                        this.LargeGoodsGanreCodeGuide_Button.Location = new Point(this.LargeGoodsGanreName_tEdit.Location.X + this.LargeGoodsGanreName_tEdit.Width + CT_GUIDEBUTTON_INTERVAL,
                            this.LargeGoodsGanreName_tEdit.Location.Y);
                        this.LargeGoodsGanreCodeGuide_Button.TabIndex = ++tabIndex;

                        // 商品区分
                        this.MediumGoodsGanreCode_Title_Label.Visible = true;
                        this.MediumGoodsGanreCode_Title_Label.Location = this.NextPosition(this.LargeGoodsGanreCodeName_Title_Label.Location.X, this.LargeGoodsGanreCodeName_Title_Label.Location.Y);

                        this.MediumGoodsGanreName_tEdit.Visible = true;
                        this.MediumGoodsGanreName_tEdit.Enabled = this._isInputSearchParam;
                        this.MediumGoodsGanreName_tEdit.Location = this.NextPosition(this.LargeGoodsGanreName_tEdit.Location.X, this.LargeGoodsGanreName_tEdit.Location.Y);
                        this.MediumGoodsGanreName_tEdit.TabIndex = ++tabIndex;

                        this.MediumGoodsGanreGide_Button.Visible = true;
                        this.MediumGoodsGanreGide_Button.Enabled = this._isInputSearchParam;
                        this.MediumGoodsGanreGide_Button.Location = new Point(this.MediumGoodsGanreName_tEdit.Location.X + this.MediumGoodsGanreName_tEdit.Width + CT_GUIDEBUTTON_INTERVAL,
                            this.MediumGoodsGanreName_tEdit.Location.Y);
                        this.MediumGoodsGanreGide_Button.TabIndex = ++tabIndex;

                        #endregion

                        break;
                    }
                // 在庫
                case (int)emSearchMode.ResultStock:
                case (int)emSearchMode.StockProduct:
					{
#endif
            #region << 基本条件のコントロール配置 >>

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // 複数選択
            //this.Multi_UGroupBox.TabIndex = tabIndex;

            #region   <基本条件・左側>

            // 拠点
            this.Section_Title_ULabel.Visible = true;
            this.Section_Title_ULabel.Location = new Point(CT_GROUP1_COL1_TITLE_START_X, CT_GROUP1_COL1_TITLE_START_Y);

            //this.tEdit_SectionCode.Visible = true;    // DEL 2009/09/07
            //this.tEdit_SectionCode.Enabled = this._isInputSearchParam;    // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.Visible = true; // ADD 2009/09/07
            this.tEdit_SectionCodeAllowZero.Enabled = this._isInputSearchParam; // ADD 2009/09/07
            this.uLabel_SectionNm.Visible = true;
            this.uLabel_SectionNm.Enabled = this._isInputSearchParam;
            this.uButton_SectionGuide.Visible = true;
            this.uButton_SectionGuide.Enabled = this._isInputSearchParam;
            //this.Section_ComboEditor.Visible = true;
            //this.Section_ComboEditor.Enabled = this._isInputSearchParam;

            // 拠点固定
            //if (this.tEdit_SectionCode.Enabled)   // DEL 2009/09/07
            if (this.tEdit_SectionCodeAllowZero.Enabled)    // ADD 2009/09/07
            //if (this.Section_ComboEditor.Enabled)
            {
                if (this._isFixedSection)
                {
                    //this.tEdit_SectionCode.Enabled = false;   // DEL 2009/09/07
                    this.tEdit_SectionCodeAllowZero.Enabled = false;    // ADD 2009/09/07
                    this.uLabel_SectionNm.Enabled = false;
                    this.uButton_SectionGuide.Enabled = false;
                    //this.Section_ComboEditor.Enabled = false;
                }
                else
                {
                    //this.tEdit_SectionCode.Enabled = true;    // DEL 2009/09/07
                    this.tEdit_SectionCodeAllowZero.Enabled = true;     // ADD 2009/09/07
                    this.uLabel_SectionNm.Enabled = true;
                    this.uButton_SectionGuide.Enabled = true;
                    //this.Section_ComboEditor.Enabled = true;
                }
            }

            // コントロールの位置指定
            // TODO 項目あたりのコントロール数が増えたため非常に分かりにくい。デザイナでレイアウトしたほうがいいのではないか？
            //this.tEdit_SectionCode.Location = new Point(CT_GROUP1_COL1_CONTROL_START_X, CT_GROUP1_COL1_CONTROL_START_Y);  // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.Location = new Point(CT_GROUP1_COL1_CONTROL_START_X, CT_GROUP1_COL1_CONTROL_START_Y);   // ADD 2009/09/07
            //this.tEdit_SectionCode.TabIndex = ++tabIndex;     // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.TabIndex = ++tabIndex;      // ADD 2009/09/07
            //this.uLabel_SectionNm.Location = new Point(this.tEdit_SectionCode.Location.X + this.tEdit_SectionCode.Width + CT_GUIDEBUTTON_INTERVAL, this.tEdit_SectionCode.Location.Y);    // DEL 2009/09/07
            this.uLabel_SectionNm.Location = new Point(this.tEdit_SectionCodeAllowZero.Location.X + this.tEdit_SectionCodeAllowZero.Width + CT_GUIDEBUTTON_INTERVAL, this.tEdit_SectionCodeAllowZero.Location.Y);   // ADD 2009/09/07
            //this.uLabel_SectionNm.TabIndex = ++tabIndex;
            //this.uButton_SectionGuide.Location = new Point(this.uLabel_SectionNm.Location.X + this.uLabel_SectionNm.Width + CT_GUIDEBUTTON_INTERVAL, this.tEdit_SectionCode.Location.Y);     // DEL 2009/09/07
            this.uButton_SectionGuide.Location = new Point(this.uLabel_SectionNm.Location.X + this.uLabel_SectionNm.Width + CT_GUIDEBUTTON_INTERVAL, this.tEdit_SectionCodeAllowZero.Location.Y);   // ADD 2009/09/07
            this.uButton_SectionGuide.TabIndex = ++tabIndex;

            //this.Section_ComboEditor.Location = new Point(CT_GROUP1_COL1_CONTROL_START_X, CT_GROUP1_COL1_CONTROL_START_Y);
            //this.Section_ComboEditor.TabIndex = ++tabIndex;


            // 倉庫
            this.WarehouseCode_Title_Label.Visible = true;
            this.WarehouseCode_Title_Label.Location = this.NextPosition(this.Section_Title_ULabel.Location.X, this.Section_Title_ULabel.Location.Y);

            this.tEdit_WarehouseCode.Visible = true;
            this.tEdit_WarehouseCode.Enabled = this._isInputSearchParam;
            this.uLabel_WarehouseName.Visible = true;
            this.uLabel_WarehouseName.Enabled = this._isInputSearchParam;
            this.uButton_WarehouseGuide.Visible = true;
            this.uButton_WarehouseGuide.Enabled = this._isInputSearchParam;

            // 倉庫固定
            if (this.tEdit_WarehouseCode.Enabled)
            {
                if (this._isFixedWarehouseCode)
                {
                    this.tEdit_WarehouseCode.Enabled = false;
                    this.uLabel_WarehouseName.Enabled = false;
                    this.uButton_WarehouseGuide.Enabled = false;
                }
                else
                {
                    this.tEdit_WarehouseCode.Enabled = true;
                    this.uLabel_WarehouseName.Enabled = true;
                    this.uButton_WarehouseGuide.Enabled = true;
                }
            }

            //this.tEdit_WarehouseCode.Location = this.NextPosition(this.tEdit_SectionCode.Location.X, this.tEdit_SectionCode.Location.Y);      // DEL 2009/09/07
            this.tEdit_WarehouseCode.Location = this.NextPosition(this.tEdit_SectionCodeAllowZero.Location.X, this.tEdit_SectionCodeAllowZero.Location.Y);      // ADD 2009/09/07
            this.tEdit_WarehouseCode.TabIndex = ++tabIndex;
            this.uLabel_WarehouseName.Location = new Point(this.tEdit_WarehouseCode.Location.X + this.tEdit_WarehouseCode.Width + CT_GUIDEBUTTON_INTERVAL, this.tEdit_WarehouseCode.Location.Y);
            //this.uLabel_WarehouseName.TabIndex = ++tabIndex;
            this.uButton_WarehouseGuide.Location = new Point(this.uLabel_WarehouseName.Location.X + this.uLabel_WarehouseName.Width + CT_GUIDEBUTTON_INTERVAL, this.tEdit_WarehouseCode.Location.Y);
            this.uButton_WarehouseGuide.TabIndex = ++tabIndex;


            // 棚番
            this.uLabel_ShelfNo_Title.Visible = true;
            this.uLabel_ShelfNo_Title.Location = this.NextPosition(this.WarehouseCode_Title_Label.Location.X, this.WarehouseCode_Title_Label.Location.Y);

            this.tEdit_WarehouseShelfNo.Visible = true;
            this.tEdit_WarehouseShelfNo.Enabled = this._isInputSearchParam;
            this.tEdit_WarehouseShelfNo.Location = this.NextPosition(this.tEdit_WarehouseCode.Location.X, this.tEdit_WarehouseCode.Location.Y);
            this.tEdit_WarehouseShelfNo.TabIndex = ++tabIndex;


            // ゼロ在庫表示
            this.StockZero_Title_Label.Visible = true;
            this.StockZero_Title_Label.Location = this.NextPosition(this.uLabel_ShelfNo_Title.Location.X, this.uLabel_ShelfNo_Title.Location.Y);

            this.StockZero_tComboEditor.Visible = true;
            this.StockZero_tComboEditor.Enabled = this._isInputSearchParam;

            // ゼロ在庫表示固定
            if (this.StockZero_tComboEditor.Enabled)
            {
                if (this._isFixedStockZero)
                    this.StockZero_tComboEditor.Enabled = false;
                else
                    this.StockZero_tComboEditor.Enabled = true;
            }

            this.StockZero_tComboEditor.Location = this.NextPosition(this.tEdit_WarehouseShelfNo.Location.X, this.tEdit_WarehouseShelfNo.Location.Y);
            this.StockZero_tComboEditor.TabIndex = ++tabIndex;

            // ---ADD 2009/04/02 不具合対応[12838] ---------------------------------------------------------------------------------------------->>>>>
            // 表示順表示
            this.SortDiv_Title_Label.Visible = true;
            this.SortDiv_Title_Label.Location = this.NextPosition(this.StockZero_Title_Label.Location.X, this.StockZero_Title_Label.Location.Y);

            this.SortDiv_tComboEditor.Visible = true;
            this.SortDiv_tComboEditor.Enabled = this._isInputSearchParam;
            this.SortDiv_tComboEditor.Location = this.NextPosition(this.StockZero_tComboEditor.Location.X, this.StockZero_tComboEditor.Location.Y);
            this.SortDiv_tComboEditor.TabIndex = ++tabIndex;
            // ---ADD 2009/04/02 不具合対応[12838] ----------------------------------------------------------------------------------------------<<<<<
            #endregion  <基本条件・左側>

            #region  <基本条件・右側>

            // 対象日付
            this.uLabel_Date1Title.Visible = true;
            this.uLabel_Date1Title.Location = new Point(CT_GROUP1_COL2_TITLE_START_X, CT_GROUP1_COL2_TITLE_START_Y);

            this.tComboEditor_DateDiv.Visible = true;
            this.tComboEditor_DateDiv.Enabled = this._isInputSearchParam;
            this.tComboEditor_DateDiv.Location = new Point(CT_GROUP1_COL2_CONTROL_START_X, CT_GROUP1_COL2_CONTROL_START_Y);
            this.tComboEditor_DateDiv.TabIndex = ++tabIndex;

            this.tDateEdit_Date1Start.Visible = true;
            this.tDateEdit_Date1Start.Enabled = this._isInputSearchParam;
            this.tDateEdit_Date1End.Visible = true;
            this.tDateEdit_Date1End.Enabled = this._isInputSearchParam;
            this.uLabel_Date1Coda.Visible = true;

            this.tDateEdit_Date1Start.Location = this.NextPosition(this.tComboEditor_DateDiv.Location.X, this.tComboEditor_DateDiv.Location.Y);
            this.tDateEdit_Date1Start.TabIndex = ++tabIndex;

            this.uLabel_Date1Coda.Location = new Point(this.tDateEdit_Date1Start.Location.X + this.tDateEdit_Date1Start.Width + CT_GUIDEBUTTON_INTERVAL, this.tDateEdit_Date1Start.Location.Y);

            this.tDateEdit_Date1End.Location = new Point(this.uLabel_Date1Coda.Location.X + this.uLabel_Date1Coda.Width + CT_GUIDEBUTTON_INTERVAL, this.tDateEdit_Date1Start.Location.Y);
            this.tDateEdit_Date1End.TabIndex = ++tabIndex;

            // メーカー
            this.MakerCode_Title_Label.Visible = true;
            Point blank = this.NextPosition(this.uLabel_Date1Title.Location.X, this.uLabel_Date1Title.Location.Y);
            this.MakerCode_Title_Label.Location = this.NextPosition(blank.X, blank.Y);

            this.tNedit_GoodsMakerCd.Visible = true;
            this.tNedit_GoodsMakerCd.Enabled = this._isInputSearchParam;
            this.uLabel_MakerName.Visible = true;
            this.uLabel_MakerName.Enabled = this._isInputSearchParam;
            this.MakerGuide_Button.Visible = true;
            this.MakerGuide_Button.Enabled = this._isInputSearchParam;

            this.tNedit_GoodsMakerCd.Location = this.NextPosition(this.tDateEdit_Date1Start.Location.X, this.tDateEdit_Date1Start.Location.Y);
            this.tNedit_GoodsMakerCd.TabIndex = ++tabIndex;
            this.uLabel_MakerName.Location = new Point(this.tNedit_GoodsMakerCd.Location.X + this.tNedit_GoodsMakerCd.Width + CT_GUIDEBUTTON_INTERVAL, this.tNedit_GoodsMakerCd.Location.Y);
            this.MakerGuide_Button.Location = new Point(this.uLabel_MakerName.Location.X + this.uLabel_MakerName.Width + CT_GUIDEBUTTON_INTERVAL, this.tNedit_GoodsMakerCd.Location.Y);
            this.MakerGuide_Button.TabIndex = ++tabIndex;

            // 品番
            this.GoodsCode_Title_ULabel.Visible = true;
            this.GoodsCode_Title_ULabel.Location = this.NextPosition(this.MakerCode_Title_Label.Location.X, this.MakerCode_Title_Label.Location.Y);

            this.tEdit_GoodsNo.Visible = true;
            this.tEdit_GoodsNo.Enabled = this._isInputSearchParam;
            this.tEdit_GoodsNo.Location = this.NextPosition(this.tNedit_GoodsMakerCd.Location.X, this.tNedit_GoodsMakerCd.Location.Y);
            this.tEdit_GoodsNo.TabIndex = ++tabIndex;

            // 品名
            this.GoodsName_Title_ULabel.Visible = true;
            this.GoodsName_Title_ULabel.Location = this.NextPosition(this.GoodsCode_Title_ULabel.Location.X, this.GoodsCode_Title_ULabel.Location.Y);

            this.tEdit_GoodsName.Visible = true;
            this.tEdit_GoodsName.Enabled = this._isInputSearchParam;
            this.tEdit_GoodsName.Location = this.NextPosition(this.tEdit_GoodsNo.Location.X, this.tEdit_GoodsNo.Location.Y);
            this.tEdit_GoodsName.TabIndex = ++tabIndex;

            // 品名カナ
            this.GoodsNameKana_Title_ULabel.Visible = true;
            this.GoodsNameKana_Title_ULabel.Location = this.NextPosition(this.GoodsName_Title_ULabel.Location.X, this.GoodsName_Title_ULabel.Location.Y);

            this.GoodsNameKana_tEdit.Visible = true;
            this.GoodsNameKana_tEdit.Enabled = this._isInputSearchParam;
            this.GoodsNameKana_tEdit.Location = this.NextPosition(this.tEdit_GoodsName.Location.X, this.tEdit_GoodsName.Location.Y);
            this.GoodsNameKana_tEdit.TabIndex = ++tabIndex;

            // ボタン
            //this.Search_Button.TabIndex = ++tabIndex;

            #endregion 　<基本条件・右側>

            #endregion

            #region << 詳細条件のコントロール配置 >>

            // タブ順を初期値に設定する
            tabIndex = 0;

            #region  <詳細条件・左側>

            // 仕入先
            this.uLabel_SupplierCode_Title.Visible = true;
            this.uLabel_SupplierCode_Title.Location = new Point(CT_GROUP2_COL1_TITLE_START_X, CT_GROUP2_COL1_TITLE_START_Y);

            this.tNedit_SupplierCd.Visible = true;
            this.tNedit_SupplierCd.Enabled = this._isInputSearchParam;
            this.tNedit_SupplierCd.Location = new Point(CT_GROUP2_COL1_CONTROL_START_X, CT_GROUP2_COL1_CONTROL_START_Y);
            this.tNedit_SupplierCd.TabIndex = ++tabIndex;

            this.tEdit_SupplierName.Visible = true;
            this.tEdit_SupplierName.Enabled = this._isInputSearchParam;
            this.tEdit_SupplierName.Location = new Point(this.tNedit_SupplierCd.Location.X + this.tNedit_SupplierCd.Width + CT_GUIDEBUTTON_INTERVAL, this.tNedit_SupplierCd.Location.Y);

            this.uButton_SupplierGuide.Visible = true;
            this.uButton_SupplierGuide.Enabled = this._isInputSearchParam;
            this.uButton_SupplierGuide.Location = new Point(this.tEdit_SupplierName.Location.X + this.tEdit_SupplierName.Width + CT_GUIDEBUTTON_INTERVAL, this.tNedit_SupplierCd.Location.Y);
            this.uButton_SupplierGuide.TabIndex = ++tabIndex;

            #endregion  <詳細条件・左側>

            #region  <詳細条件・右側>

            // ＢＬコード
            this.BLGoodsCode_Title_Label.Visible = true;
            this.BLGoodsCode_Title_Label.Location = new Point(CT_GROUP2_COL2_TITLE_START_X, CT_GROUP2_COL2_TITLE_START_Y);
            //this.BLGoodsCode_Title_Label.Location = this.NextPosition(this.uLabel_SupplierCode_Title.Location.X, this.uLabel_SupplierCode_Title.Location.Y);

            this.tNedit_BLGoodsCode.Visible = true;
            this.tNedit_BLGoodsCode.Enabled = this._isInputSearchParam;
            this.tNedit_BLGoodsCode.Location = new Point(CT_GROUP2_COL2_CONTROL_START_X, CT_GROUP2_COL2_CONTROL_START_Y);
            //this.tEdit_BLGoodsName.Location = this.NextPosition(this.tEdit_SupplierName.Location.X, this.tEdit_SupplierName.Location.Y);

            this.tEdit_BLGoodsName.Visible = true;
            this.tEdit_BLGoodsName.Enabled = this._isInputSearchParam;
            this.tEdit_BLGoodsName.Location = new Point(this.tNedit_BLGoodsCode.Location.X + this.tNedit_BLGoodsCode.Width + CT_GUIDEBUTTON_INTERVAL, this.tNedit_BLGoodsCode.Location.Y);
            //this.tEdit_BLGoodsName.TabIndex = ++tabIndex;

            this.BLGoodsCodeGuide_Button.Visible = true;
            this.BLGoodsCodeGuide_Button.Enabled = this._isInputSearchParam;
            this.BLGoodsCodeGuide_Button.Location = new Point(this.tEdit_BLGoodsName.Location.X + this.tEdit_BLGoodsName.Width + CT_GUIDEBUTTON_INTERVAL, this.tNedit_BLGoodsCode.Location.Y);
            this.BLGoodsCodeGuide_Button.TabIndex = ++tabIndex;

            #endregion  <詳細条件・右側>

            #region deleted

            //// 自社分類コード
            //this.EnterpriseGanreCode_Title_Label.Visible = true;
            //this.EnterpriseGanreCode_Title_Label.Location = this.NextPosition(this.BLGoodsCode_Title_Label.Location.X, this.BLGoodsCode_Title_Label.Location.Y);

            //this.EnterpriseGanreCode_tEdit.Visible = true;
            //this.EnterpriseGanreCode_tEdit.Enabled = this._isInputSearchParam;
            //this.EnterpriseGanreCode_tEdit.Location = this.NextPosition(this.tEdit_BLGoodsName.Location.X, this.tEdit_BLGoodsName.Location.Y);
            //this.EnterpriseGanreCode_tEdit.TabIndex = ++tabIndex;

            //this.EnterpriseGanreCodeGuide_Button.Visible = true;
            //this.EnterpriseGanreCodeGuide_Button.Enabled = this._isInputSearchParam;
            //this.EnterpriseGanreCodeGuide_Button.Location = new Point(this.EnterpriseGanreCode_tEdit.Location.X + this.EnterpriseGanreCode_tEdit.Width + CT_GUIDEBUTTON_INTERVAL,
            //    this.EnterpriseGanreCode_tEdit.Location.Y);
            //this.EnterpriseGanreCodeGuide_Button.TabIndex = ++tabIndex;

            //// 商品区分グループ
            //this.LargeGoodsGanreCodeName_Title_Label.Visible = true;
            //this.LargeGoodsGanreCodeName_Title_Label.Location = new Point(CT_GROUP2_COL2_TITLE_START_X, CT_GROUP2_COL2_TITLE_START_Y);

            //this.LargeGoodsGanreName_tEdit.Visible = true;
            //this.LargeGoodsGanreName_tEdit.Enabled = this._isInputSearchParam;
            //this.LargeGoodsGanreName_tEdit.Location = new Point(CT_GROUP2_COL2_CONTROL_START_X, CT_GROUP2_COL2_CONTROL_START_Y);
            //this.LargeGoodsGanreName_tEdit.TabIndex = ++tabIndex;

            //this.LargeGoodsGanreCodeGuide_Button.Visible = true;
            //this.LargeGoodsGanreCodeGuide_Button.Enabled = this._isInputSearchParam;
            //this.LargeGoodsGanreCodeGuide_Button.Location = new Point(this.LargeGoodsGanreName_tEdit.Location.X + this.LargeGoodsGanreName_tEdit.Width + CT_GUIDEBUTTON_INTERVAL,
            //    this.LargeGoodsGanreName_tEdit.Location.Y);
            //this.LargeGoodsGanreCodeGuide_Button.TabIndex = ++tabIndex;

            //// 商品区分
            //this.MediumGoodsGanreCode_Title_Label.Visible = true;
            //this.MediumGoodsGanreCode_Title_Label.Location = this.NextPosition(this.LargeGoodsGanreCodeName_Title_Label.Location.X, this.LargeGoodsGanreCodeName_Title_Label.Location.Y);

            //this.MediumGoodsGanreName_tEdit.Visible = true;
            //this.MediumGoodsGanreName_tEdit.Enabled = this._isInputSearchParam;
            //this.MediumGoodsGanreName_tEdit.Location = this.NextPosition(this.LargeGoodsGanreName_tEdit.Location.X, this.LargeGoodsGanreName_tEdit.Location.Y);
            //this.MediumGoodsGanreName_tEdit.TabIndex = ++tabIndex;

            //this.MediumGoodsGanreGide_Button.Visible = true;
            //this.MediumGoodsGanreGide_Button.Enabled = this._isInputSearchParam;
            //this.MediumGoodsGanreGide_Button.Location = new Point(this.MediumGoodsGanreName_tEdit.Location.X + this.MediumGoodsGanreName_tEdit.Width + CT_GUIDEBUTTON_INTERVAL,
            //    this.MediumGoodsGanreName_tEdit.Location.Y);
            //this.MediumGoodsGanreGide_Button.TabIndex = ++tabIndex;

            //// 商品区分詳細
            //this.DetailGoodsGanreCode_Title_Label.Visible = true;
            //this.DetailGoodsGanreCode_Title_Label.Location = this.NextPosition(this.MediumGoodsGanreCode_Title_Label.Location.X, this.MediumGoodsGanreCode_Title_Label.Location.Y);

            //this.DetailGoodsGanreName_tEdit.Visible = true;
            //this.DetailGoodsGanreName_tEdit.Enabled = this._isInputSearchParam;
            //this.DetailGoodsGanreName_tEdit.Location = this.NextPosition(this.MediumGoodsGanreName_tEdit.Location.X, this.MediumGoodsGanreName_tEdit.Location.Y);
            //this.DetailGoodsGanreName_tEdit.TabIndex = ++tabIndex;

            //this.DetailGoodsGanreGide_Button.Visible = true;
            //this.DetailGoodsGanreGide_Button.Enabled = this._isInputSearchParam;
            //this.DetailGoodsGanreGide_Button.Location = new Point(this.DetailGoodsGanreName_tEdit.Location.X + this.DetailGoodsGanreName_tEdit.Width + CT_GUIDEBUTTON_INTERVAL,
            //    this.DetailGoodsGanreGide_Button.Location.Y);
            //this.DetailGoodsGanreGide_Button.TabIndex = ++tabIndex;

            #endregion // deleted

            #endregion
#if false
                        break;
					}
				// 商品
				case (int)emSearchMode.Goods:
					{
						break;
					}
			}
#endif
        }

        /// <summary>
        /// コントロール表示制御
        /// </summary>
        /// <param name="visibled"></param>
        /// <param name="owner"></param>
        private void UnDisplayControl(bool visibled, Control owner)
        {

            for (int i = 0; i < owner.Controls.Count; i++)
            {
                // TEdit
                if (owner.Controls[i] is Broadleaf.Library.Windows.Forms.TEdit)
                {
                    if (((Broadleaf.Library.Windows.Forms.TEdit)owner.Controls[i]).Tag != null)
                    {
                        if (((Broadleaf.Library.Windows.Forms.TEdit)owner.Controls[i]).Tag.ToString().Equals("False"))
                        {
                            continue;
                        }
                    }
                    ((Broadleaf.Library.Windows.Forms.TEdit)owner.Controls[i]).Visible = visibled;
                }
                // TDateEdit
                if (owner.Controls[i] is Broadleaf.Library.Windows.Forms.TDateEdit)
                {
                    if (((Broadleaf.Library.Windows.Forms.TDateEdit)owner.Controls[i]).Tag != null)
                    {
                        if (((Broadleaf.Library.Windows.Forms.TDateEdit)owner.Controls[i]).Tag.ToString().Equals("False"))
                        {
                            continue;
                        }
                    }
                    ((Broadleaf.Library.Windows.Forms.TDateEdit)owner.Controls[i]).Visible = visibled;
                }
                // TComboEditor
                if (owner.Controls[i] is Broadleaf.Library.Windows.Forms.TComboEditor)
                {
                    if (((Broadleaf.Library.Windows.Forms.TComboEditor)owner.Controls[i]).Tag != null)
                    {
                        if (((Broadleaf.Library.Windows.Forms.TComboEditor)owner.Controls[i]).Tag.ToString().Equals("False"))
                        {
                            continue;
                        }
                    }
                    ((Broadleaf.Library.Windows.Forms.TComboEditor)owner.Controls[i]).Visible = visibled;
                }
                // UltraOptionSet
                if (owner.Controls[i] is Infragistics.Win.UltraWinEditors.UltraOptionSet)
                {
                    if (((Infragistics.Win.UltraWinEditors.UltraOptionSet)owner.Controls[i]).Tag != null)
                    {
                        if (((Infragistics.Win.UltraWinEditors.UltraOptionSet)owner.Controls[i]).Tag.ToString().Equals("False"))
                        {
                            continue;
                        }
                    }
                    ((Infragistics.Win.UltraWinEditors.UltraOptionSet)owner.Controls[i]).Visible = visibled;
                }
                // ListBox
                if (owner.Controls[i] is System.Windows.Forms.ListBox)
                {
                    if (((System.Windows.Forms.ListBox)owner.Controls[i]).Tag != null)
                    {
                        if (((System.Windows.Forms.ListBox)owner.Controls[i]).Tag.ToString().Equals("False"))
                        {
                            continue;
                        }
                    }
                    ((System.Windows.Forms.ListBox)owner.Controls[i]).Visible = visibled;
                }
                // UltraButton
                if (owner.Controls[i] is Infragistics.Win.Misc.UltraButton)
                {
                    if (((Infragistics.Win.Misc.UltraButton)owner.Controls[i]).Tag != null)
                    {
                        if (((Infragistics.Win.Misc.UltraButton)owner.Controls[i]).Tag.ToString().Equals("False"))
                        {
                            continue;
                        }
                    }
                    ((Infragistics.Win.Misc.UltraButton)owner.Controls[i]).Visible = visibled;
                }
                // UltraButton
                if (owner.Controls[i] is Infragistics.Win.Misc.UltraLabel)
                {
                    if (((Infragistics.Win.Misc.UltraLabel)owner.Controls[i]).Tag != null)
                    {
                        if (((Infragistics.Win.Misc.UltraLabel)owner.Controls[i]).Tag.ToString().Equals("False"))
                        {
                            continue;
                        }
                    }
                    ((Infragistics.Win.Misc.UltraLabel)owner.Controls[i]).Visible = visibled;
                }
                // Form以外のコンテナ（Tab,Panel等）がある場合はその内部のコントロールも対象とする
                if (!(owner.Controls[i] is System.Windows.Forms.Form))
                {
                    UnDisplayControl(visibled, owner.Controls[i]);
                }
            }
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <param name="initMode">初期化モード[0:初回,1:取消,3:結果表示]</param>
        /// <br>Update Note: 2009/09/07       汪千来</br>
        /// <br>           : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        private void InitialDisplay(int initMode)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //if (initMode == 0)
            //{
            //    // 複数条件指定
            //    this.Multi_CheckEditor.Checked = false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// キャリアコード
            //if (this.CarrierName_tEdit.Enabled)
            //{
            //    this.CarrierName_tEdit.Clear();
            //    this.CarrierName_tEdit.Tag = null;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 拠点
            //this.tEdit_SectionCode.Clear();      // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.Clear();    // ADD 2009/09/07
            //this.tEdit_SectionCode.Tag = string.Empty;   // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.Tag = string.Empty;     // ADD 2009/09/07
            // TODO --> Tagは何に使っている？

            this.uLabel_SectionNm.Text = "";
            this.uLabel_SectionNm.Tag = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            //2008.10.10 stokunaga add start
            // 初期コードをセット
            //this.tEdit_SectionCode.Text = this._loginSectionCode.PadLeft(2, '0');    // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode.PadLeft(2, '0');  // ADD 2009/09/07
            //this.tEdit_SectionCode_Leave(null, null);    // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero_Leave(null, null);  // ADD 2009/09/07
            //2008.10.10 stokunaga add end


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // 倉庫
            if (this.tEdit_WarehouseCode.Enabled)
            {
                this.tEdit_WarehouseCode.Clear();
                //this.tEdit_WarehouseCode.Tag = string.Empty;

                this.uLabel_WarehouseName.Text = "";
                //this.uLabel_WarehouseName.Tag = null;
                //this.uLabel_WarehouseName.Tag = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 棚番
            this.tEdit_WarehouseShelfNo.Clear();
            this.tEdit_WarehouseShelfNo.Tag = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // ゼロ在庫
            if (this.StockZero_tComboEditor.Enabled)
            {
                this.StockZero_tComboEditor.Value = 0;
            }

            // ---ADD 2009/04/02 不具合対応[12838] ------------------->>>>>
            // 表示順
            if (this.SortDiv_tComboEditor.Enabled)
            {
                this.SortDiv_tComboEditor.Value = 0;
            }
            // ---ADD 2009/04/02 不具合対応[12838] -------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 対象日付区分
            this.tComboEditor_DateDiv.SelectedIndex = 0;    // 更新日付
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            // ---ADD 2009/05/26 不具合対応[13386] ------------------->>>>>
            // 対象日付
            this.tDateEdit_Date1Start.Clear();              //対象日From
            this.tDateEdit_Date1End.Clear();                //対象日To
            // ---ADD 2009/05/26 不具合対応[13386] -------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // メーカー
            this.tNedit_GoodsMakerCd.Clear();
            //this.tNedit_GoodsMakerCd.Tag = null;
            this.tNedit_GoodsMakerCd.Tag = string.Empty;

            this.uLabel_MakerName.Text = "";
            this.uLabel_MakerName.Tag = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // 品番
            this.tEdit_GoodsNo.Clear();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 品名
            this.tEdit_GoodsName.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // 品名カナ
            this.GoodsNameKana_tEdit.Clear();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 機種コード
            //this.CellphoneModelCode_tEdit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 事業者
            //this.CarrierEpName_tEdit.Clear();
            //this.CarrierEpName_tEdit.Tag = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 仕入先
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            this.tNedit_SupplierCd.Clear();
            this.tNedit_SupplierCd.Tag = string.Empty;

            this.tEdit_SupplierName.Clear();
            //this.tEdit_SupplierName.Tag = null;
            this.tEdit_SupplierName.Tag = string.Empty;

            // ＢＬ商品コード
            this.tNedit_BLGoodsCode.Clear();
            this.tNedit_BLGoodsCode.Tag = string.Empty;

            this.tEdit_BLGoodsName.Clear();
            this.tEdit_BLGoodsName.Tag = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //// 商品グループ
            //this.LargeGoodsGanreName_tEdit.Clear();
            ////this.LargeGoodsGanreName_tEdit.Tag = null;
            //this.LargeGoodsGanreName_tEdit.Tag = string.Empty;

            //// 商品区分
            //this.MediumGoodsGanreName_tEdit.Clear();
            ////this.MediumGoodsGanreName_tEdit.Tag = null;
            //this.MediumGoodsGanreName_tEdit.Tag = string.Empty;

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 商品区分詳細
            //this.DetailGoodsGanreName_tEdit.Clear();
            //this.DetailGoodsGanreName_tEdit.Tag = string.Empty;

            //// 自社分類
            //this.EnterpriseGanreCode_tEdit.Clear();
            //this.EnterpriseGanreCode_tEdit.Tag = string.Empty;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // 2008.10.10 stokunaga add start
            // 合計金額をクリア
            this.uLabel_TotalStockCount.Text = "0.00";
            this.uLabel_TotalStockValue.Text = "\\0";
            // 2008.10.10 stokunaga add end

            // --- ADD 2012/09/18 ---------->>>>>
            // テキスト出力ボタンとExcel出力ボタンを無効
            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText].SharedProps.Enabled = false;
            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel].SharedProps.Enabled = false;
            // --- ADD 2012/09/18 ----------<<<<<

            // 結果表示モードでない場合、初期化
            if (initMode != 3)
            {
                // ---DEL 2009/05/26 不具合対応[13386] -------->>>>>
                //// 在庫テーブル
                //if (this._stockDataTable != null)
                //    this._stockDataTable.Rows.Clear();
                // ---DEL 2009/05/26 不具合対応[13386] --------<<<<<
                // ---ADD 2009/05/26 不具合対応[13386] -------->>>>>
                if (this._stockDataTable != null)
                {
                    this._stockDataTable.Rows.Clear();
                    this._stockDataView.Table = this._stockDataTable;
                }
                // ---ADD 2009/05/26 不具合対応[13386] --------<<<<<


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 製番在庫テーブル
                //if (this._productStockDataTable != null)
                //    this._productStockDataTable.Rows.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

            this._prevSearchParam = this.GetSearchParameter();

            this._prevSortDiv = 0;           //ADD 2009/04/02 不具合対応[12838]

            // 本来はこんなフラグはいらない
            this._cleared = true;
            //this._prevSearchParam = null;

            // 初期フォーカス位置を設定する
            if (initMode == 0 || initMode == 1)
            {
                //this.tEdit_GoodsNo.Focus();
                _firstControl.Focus();
            }
            else
            {
                if (this.gridResult.Rows.Count > 0)
                {
                    // 結果表示モード時は、グリッドに位置づけ
                    this.gridResult.Focus();
                    this.gridResult.Rows[0].Activate();
                    this.gridResult.Rows[0].Selected = true;
                }
                else
                {
                    //this.tEdit_GoodsNo.Focus();
                    _firstControl.Focus();
                }
            }
        }

        /// <summary>
        /// 次行位置算出
        /// </summary>
        /// <param name="nowX">現在のX座標</param>
        /// <param name="nowY">現在のY座標</param>
        /// <returns>算出後ポジション</returns>
        private Point NextPosition(int nowX, int nowY)
        {
            return new Point(nowX, nowY + CT_ROW_INTERVAL);
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.10</br>
        /// </remarks>
        private void InitSettingToolBar()
        {

            this.Main_UToolbarsManager.ImageListSmall = this._imageList16;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            Infragistics.Win.UltraWinToolbars.ButtonTool quitButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Quit];
            if (quitButton != null)
            {
                quitButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            Infragistics.Win.UltraWinToolbars.ButtonTool decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
            if (decisionButton != null)
            {
                decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            }

            Infragistics.Win.UltraWinToolbars.ButtonTool backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Back];
            if (backButton != null)
            {
                backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            }

            Infragistics.Win.UltraWinToolbars.ButtonTool undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo];
            if (undoButton != null)
            {
                undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search];
            if (searchButton != null)
            {
                searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // 2012/04/10 T.Nishi >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            Infragistics.Win.UltraWinToolbars.ButtonTool stopButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Stop];
            if (stopButton != null)
            {
                stopButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INTERRUPTION;
            }

            Infragistics.Win.UltraWinToolbars.ButtonTool pauseButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Pause];
            if (pauseButton != null)
            {
                pauseButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INTERRUPTION;
            }

            Infragistics.Win.UltraWinToolbars.ButtonTool restartButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ReStart];
            if (restartButton != null)
            {
                restartButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            }

            stopButton.SharedProps.Visible = false;
            pauseButton.SharedProps.Visible = true;
            pauseButton.SharedProps.Enabled = false;
            restartButton.SharedProps.Visible = false;
            // 2012/04/10 T.Nishi <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // --- ADD 2012/09/18 ---------->>>>>
            // テキスト出力・Excel出力・設置ボタンのImageセット
            Infragistics.Win.UltraWinToolbars.ButtonTool extractTextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText];
            if (extractTextButton != null)
            {
                extractTextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            }

            Infragistics.Win.UltraWinToolbars.ButtonTool extractExcelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel];
            if (extractExcelButton != null)
            {
                extractExcelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            }

            Infragistics.Win.UltraWinToolbars.ButtonTool configurationButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Configuration];
            if (configurationButton != null)
            {
                configurationButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            
            }

            // ExportボタンのVisibleをセット
            this.SetExportToolButtonVisible();

            // --- ADD 2012/09/18 ----------<<<<<
        }

        // ADD 2008/10/09 不具合対応[6382] ---------->>>>>
        /// <summary>
        /// 「確定」ボタン表示変更処理
        /// </summary>
        /// <param name="enable">表示設定(true:表示、false:非表示)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
            this._decisionButton.SharedProps.Enabled = enableSet;
        }
        // ADD 2008/10/09 不具合対応[6382] ----------<<<<<

        // --- ADD 2012/09/18 ---------->>>>>
        /// <summary>
        /// テキスト出力関連ボタンの利用可否セット処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力関連ボタンの利用可否セット処理</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void SetExportToolButtonVisible()
        {
            // オプションコードのテキスト出力を参照
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TextOutput = (int)Option.ON;
            }
            else
            {
                this._opt_TextOutput = (int)Option.OFF;
            }

            // オプションコードで利用可
            if (this._opt_TextOutput == (int)Option.ON)
            {
                // テキスト出力セキュリティ権限参照
                if (OpeAuthDictionary[OperationCode.TextOut] &&
                    this._searchMode == (int)emSearchMode.Stock)
                {
                    // テキスト出力ボタン表示
                    // Enableは検索後にtrueにする
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText].SharedProps.Visible = true;
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText].SharedProps.Enabled = false;

                    // 設定ボタン表示
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Configuration].SharedProps.Visible = true;
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Configuration].SharedProps.Enabled = true;
                }
                else
                {
                    // テキスト出力ボタン設定ボタン非表示
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText].SharedProps.Visible   = false;
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Configuration].SharedProps.Visible = false;
                }
                // EXCEL出力セキュリティ権限
                if (OpeAuthDictionary[OperationCode.ExcelOut] &&
                    this._searchMode == (int)emSearchMode.Stock)
                {
                    // EXCEL出力ボタン表示
                    // Enableは検索後にtrueにする
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel].SharedProps.Visible = true;
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel].SharedProps.Enabled = false;
                }
                else
                {
                    // EXCEL出力
                    this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel].SharedProps.Visible = false;
                }
            }
            //テキスト出力オプションが無効の場合
            else
            {
                // テキスト出力・EXCEL出力・設定ボタン非表示
                this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText].SharedProps.Visible   = false;
                this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel].SharedProps.Visible  = false;
                this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Configuration].SharedProps.Visible = false;
            }

            return;
        }

        /// <summary>
        /// グリッド情報初期化イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : グリッド情報初期化イベント</br>
        /// <br>           : 設定画面から初期化ボタンが押下された場合に実行されるイベント</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void SettingForm_ClearSettingStockGrid(object sender, EventArgs e)
        {
            this.InitializeGridColumns();

            // 列幅も調整
            if (this.AutoFillToGridColumn_CheckEditor.Checked == true)
            {
                this.AutoFillToGridColumn_CheckEditor.Checked = false;
                this.AutoFillToGridColumn_CheckEditor.Checked = true;
            }
            else
            {
                this.AutoFillToGridColumn_CheckEditor.Checked = true;
                this.AutoFillToGridColumn_CheckEditor.Checked = false;
            }

            return;
        }

        /// <summary>
        /// グリッド列順番の初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列順番の初期化。</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void InitializeGridColumns()
        {
            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.gridResult.DisplayLayout.Bands[0].Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            // 表示される順番
            int position = 0;

            #region 初期化の順番割振り
            // 3743行目周辺の順にVisiblePositionをセット
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_SelectButton].Header.VisiblePosition = position;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_Select].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_RowNo].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_WarehouseCode].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_WarehouseShelfNo].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_MakerCode].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_GoodsName].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_GoodsCode].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_SupplierStock].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_MinimumStockCnt].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_MaximumStockCnt].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_SalesOrderCount].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_ShipmentPosCnt].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_MovingSupliStock].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_ShipmentCnt].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_ArrivalCnt].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_AcpOdrCount].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_GoodsSpecialNote].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_BLGoodsCode].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_GoodsNameKana].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_DuplicationShelfNo1].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_DuplicationShelfNo2].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_MakerName].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_SupplierCd].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_SupplierSnm].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_ListPrice].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_StockUnitPrice].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_StockTotalPrice].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_UpdateDateString].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_StockCreateDateString].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_SectionCode].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_SectionName].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_WarehouseName].Header.VisiblePosition = position++;
            this.gridResult.DisplayLayout.Bands[0].Columns[CT_StockSearchRet].Header.VisiblePosition = position++;
            #endregion

            // 全て表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.gridResult.DisplayLayout.Bands[0].Columns)
            {
                // 元々非表示のものは非表示のまま
                if (column.Key == CT_SelectButton ||
                    column.Key == CT_Select ||
                    column.Key == CT_StockSearchRet)
                {
                    continue;
                }
                else
                {
                    // 表示設定
                    column.Hidden = false;
                }
            }

            return;
        }
        // --- ADD 2012/09/18 ----------<<<<<

        #endregion

        // --------------------------------------------------
        #region < DataSet, DataTable 作成 >

        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面用のデータセット、テーブルを作成します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.12.26</br>
        /// </remarks>
        private void SettingDataSet()
        {
            try
            {
                if (this._stockDataSet == null)
                {
                    this._stockDataSet = new DataSet("StockDataSet");

                    // 在庫テーブル作成
                    CreateStockTable();

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 製番在庫テーブル作成
                    //CreateProductStockTable();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // --- ADD 2012/09/18 ---------->>>>>
                    // DataSetを生成したタイミングで設定画面で使用するDataSetも生成する
                    if (this._stockDataSet.Tables.Count > 0)
                    {
                        this._settingForm.StockDataSet = this._stockDataSet;
                    }
                    // --- ADD 2012/09/18 ----------<<<<<

                }
                else
                {
                    // 結果表示モードじゃない場合
                    switch (this._searchMode)
                    {
                        case (int)emSearchMode.ResultStock:
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            //case (int)emSearchMode.ResultStockNoButton:
                            //case (int)emSearchMode.ResultProduct:
                            //case (int)emSearchMode.ResultProductwitchStock:
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                            break;
                        default:
                            {
                                if (this._stockDataTable != null)
                                    this._stockDataTable.Rows.Clear();

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                //if (this._productStockDataTable != null)
                                //    this._productStockDataTable.Rows.Clear();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = (ex.InnerException == null) ? ex.Message : String.Format("{0}[{1}]", ex.Message, ex.InnerException.Message);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, errorMsg, -1, MessageBoxButtons.OK);
            }
        }

        #region ●　在庫テーブル作成処理
        /// <summary>
        /// 在庫テーブル作成処理
        /// </summary>
        private void CreateStockTable()
        {
            this._stockDataTable = new DataTable("StockDataTable");
            this._stockDataView = new DataView(this._stockDataTable);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 詳細製番
            //DataColumn ProductButton = new DataColumn(CT_ProductButton, typeof(string), "", MappingType.Element);
            //ProductButton.Caption = "製番別";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            // 行No
            DataColumn RowNo = new DataColumn(CT_RowNo, typeof(Int32), "", MappingType.Element);
            //RowNo.Caption = "";           //DEL 2009/04/01 不具合対応[12837]
            RowNo.Caption = "No.";          //ADD 2009/04/01 不具合対応[12837]

            // 選択用のセル
            DataColumn Select = new DataColumn(CT_Select, typeof(bool), "", MappingType.Element);
            Select.Caption = "";

            // 選択用のセルボタン
            DataColumn SelectButton = new DataColumn(CT_SelectButton, typeof(string), "", MappingType.Element);
            SelectButton.Caption = "選択/非選択";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // 列設定を追加

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // 倉庫コード
            DataColumn WarehouseCode = new DataColumn(CT_WarehouseCode, typeof(string), "", MappingType.Element);
            WarehouseCode.Caption = "倉庫コード";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            DataColumn WarehouseShelfNo = new DataColumn(CT_WarehouseShelfNo, typeof(string), "", MappingType.Element);
            WarehouseShelfNo.Caption = "棚番";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // メーカーコード
            //DataColumn MakerCode = new DataColumn(CT_MakerCode, typeof(Int32), "", MappingType.Element);          //DEL 2009/04/01 不具合対応[12835]
            DataColumn MakerCode = new DataColumn(CT_MakerCode, typeof(string), "", MappingType.Element);           //ADD 2009/04/01 不具合対応[12835]
            MakerCode.Caption = "メーカーコード";

            // 品名
            DataColumn GoodsName = new DataColumn(CT_GoodsName, typeof(string), "", MappingType.Element);
            GoodsName.Caption = "品名";

            // 品番
            DataColumn GoodsCode = new DataColumn(CT_GoodsCode, typeof(string), "", MappingType.Element);
            GoodsCode.Caption = "品番";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 現在庫(仕)
            DataColumn SupplierStock = new DataColumn(CT_SupplierStock, typeof(Double), "", MappingType.Element);
            /* ---DEL 2009/04/01 不具合対応[12837] --------------------------------->>>>>
            //SupplierStock.Caption = "仕入";
            SupplierStock.Caption = "現在庫(仕)";
               ---DEL 2009/04/01 不具合対応[12837] ---------------------------------<<<<< */
            SupplierStock.Caption = "仕入在庫数";       //ADD 2009/04/01 不具合対応[12837]

            // 最低在庫
            DataColumn MinimumStockCnt = new DataColumn(CT_MinimumStockCnt, typeof(Double), "", MappingType.Element);
            //MinimumStockCnt.Caption = "最低在庫";     //DEL 2009/04/01 不具合対応[12837]
            MinimumStockCnt.Caption = "最低在庫数";     //ADD 2009/04/01 不具合対応[12837]

            // 最高在庫
            DataColumn MaximumStockCnt = new DataColumn(CT_MaximumStockCnt, typeof(Double), "", MappingType.Element);
            //MaximumStockCnt.Caption = "最高在庫";     //DEL 2009/04/01 不具合対応[12837]
            MaximumStockCnt.Caption = "最高在庫数";     //ADD 2009/04/01 不具合対応[12837]

            // 発注残
            DataColumn SalesOrderCount = new DataColumn(CT_SalesOrderCount, typeof(Double), "", MappingType.Element);
            SalesOrderCount.Caption = "発注残";

            // 発注ロット
            DataColumn SupplierLot = new DataColumn(CT_SupplierLot, typeof(Int32), "", MappingType.Element);
            SupplierLot.Caption = "発注ロット";

            // 出荷可能数
            DataColumn ShipmentPosCnt = new DataColumn(CT_ShipmentPosCnt, typeof(Double), "", MappingType.Element);
            //ShipmentPosCnt.Caption = "出荷可能";      //DEL 2009/04/01 不具合対応[12837]
            ShipmentPosCnt.Caption = "現在庫数";        //ADD 2009/04/01 不具合対応[12837]

            // 移動中在庫数
            DataColumn MovingSupliStock = new DataColumn(CT_MovingSupliStock, typeof(Double), "", MappingType.Element);
            //MovingSupliStock.Caption = "移動数";          //DEL 2009/04/01 不具合対応[12837]
            MovingSupliStock.Caption = "移動中仕入在庫数";  //ADD 2009/04/01 不具合対応[12837]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // 出荷数（未計上）
            DataColumn ShipmentCnt = new DataColumn(CT_ShipmentCnt, typeof(double), "", MappingType.Element);
            //ShipmentCnt.Caption = "出荷数(未計上)";   //DEL 2009/04/01 不具合対応[12837]
            ShipmentCnt.Caption = "貸出数(未計上)";     //ADD 2009/04/01 不具合対応[12837]

            // 入荷数（未計上）
            DataColumn ArrivalCnt = new DataColumn(CT_ArrivalCnt, typeof(double), "", MappingType.Element);
            ArrivalCnt.Caption = "入荷数(未計上)";

            // 受注数
            DataColumn AcpOdrCount = new DataColumn(CT_AcpOdrCount, typeof(double), "", MappingType.Element);
            AcpOdrCount.Caption = "受注数";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 規格・特記事項
            DataColumn GoodsSpecialNote = new DataColumn(CT_GoodsSpecialNote, typeof(string), "", MappingType.Element);
            GoodsSpecialNote.Caption = "規格・特記事項";

            // BLコード
            //DataColumn BLGoodsCode = new DataColumn(CT_BLGoodsCode, typeof(Int32), "", MappingType.Element);          //DEL 2009/04/01 不具合対応[12835]
            DataColumn BLGoodsCode = new DataColumn(CT_BLGoodsCode, typeof(string), "", MappingType.Element);           //ADD 2009/04/01 不具合対応[12835]
            BLGoodsCode.Caption = "BLコード";

            // 商品名称カナ
            DataColumn GoodsNameKana = new DataColumn(CT_GoodsNameKana, typeof(string), "", MappingType.Element);
            //GoodsNameKana.Caption = "商品名称カナ";   //DEL 2009/04/01 不具合対応[12837]
            GoodsNameKana.Caption = "品名カナ";         //ADD 2009/04/01 不具合対応[12837]

            // 棚番1
            DataColumn DuplicationShelfNo1 = new DataColumn(CT_DuplicationShelfNo1, typeof(string), "", MappingType.Element);
            //DuplicationShelfNo1.Caption = "棚番1";    //DEL 2009/04/01 不具合対応[12837]
            DuplicationShelfNo1.Caption = "重複棚番1";  //ADD 2009/04/01 不具合対応[12837]

            // 棚番2
            DataColumn DuplicationShelfNo2 = new DataColumn(CT_DuplicationShelfNo2, typeof(string), "", MappingType.Element);
            //DuplicationShelfNo2.Caption = "棚番2";    //DEL 2009/04/01 不具合対応[12837]
            DuplicationShelfNo2.Caption = "重複棚番2";  //ADD 2009/04/01 不具合対応[12837]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // メーカー名称
            DataColumn MakerName = new DataColumn(CT_MakerName, typeof(string), "", MappingType.Element);
            MakerName.Caption = "メーカー名";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 仕入先コード
            DataColumn SupplierCd = new DataColumn(CT_SupplierCd, typeof(string), "", MappingType.Element);
            SupplierCd.Caption = "仕入先コード";

            // 仕入先名称
            DataColumn SupplierSnm = new DataColumn(CT_SupplierSnm, typeof(string), "", MappingType.Element);
            //SupplierSnm.Caption = "仕入先名称";       //DEL 2009/04/01 不具合対応[12837]
            SupplierSnm.Caption = "仕入先名";           //ADD 2009/04/01 不具合対応[12837]

            // 標準価格
            // --- CHG 2009/02/09 障害ID:11216対応------------------------------------------------------>>>>>
            //DataColumn ListPrice = new DataColumn(CT_ListPrice, typeof(Double), "", MappingType.Element);
            DataColumn ListPrice = new DataColumn(CT_ListPrice, typeof(Int64), "", MappingType.Element);
            // --- CHG 2009/02/09 障害ID:11216対応------------------------------------------------------<<<<<
            ListPrice.Caption = "標準価格";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // 仕入単価
            // --- CHG 2009/02/09 障害ID:11216対応------------------------------------------------------>>>>>
            //DataColumn StockUnitPrice = new DataColumn(CT_StockUnitPrice, typeof(Int64), "", MappingType.Element);
            //StockUnitPrice.Caption = "仕入単価";
            DataColumn StockUnitPrice = new DataColumn(CT_StockUnitPrice, typeof(Double), "", MappingType.Element);
            StockUnitPrice.Caption = "原単価";
            // --- CHG 2009/02/09 障害ID:11216対応------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 在庫金額
            DataColumn StockTotalPrice = new DataColumn(CT_StockTotalPrice, typeof(Double), "", MappingType.Element);
            StockTotalPrice.Caption = "在庫金額";

            // 更新日付
            //DataColumn UpdateDate = new DataColumn(CT_UpdateDate, typeof(Int32), "", MappingType.Element);
            DataColumn UpdateDateString = new DataColumn(CT_UpdateDateString, typeof(string), "", MappingType.Element);
            UpdateDateString.Caption = "更新日";

            // 登録日付
            //DataColumn StockCreateDate = new DataColumn(CT_StockCreateDate, typeof(Int32), "", MappingType.Element);
            DataColumn StockCreateDateString = new DataColumn(CT_StockCreateDateString, typeof(string), "", MappingType.Element);
            StockCreateDateString.Caption = "登録日";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // 拠点コード
            DataColumn SectionCode = new DataColumn(CT_SectionCode, typeof(string), "", MappingType.Element);
            SectionCode.Caption = "拠点コード";

            // 拠点名称
            DataColumn SectionName = new DataColumn(CT_SectionName, typeof(string), "", MappingType.Element);
            SectionName.Caption = "拠点名";

            // 倉庫名称
            DataColumn WarehouseName = new DataColumn(CT_WarehouseName, typeof(string), "", MappingType.Element);
            WarehouseName.Caption = "倉庫名";

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END


            #region deleted
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START

            //// 受託数
            //DataColumn TrustCount = new DataColumn( CT_TrustCount, typeof( Double ), "", MappingType.Element );
            //TrustCount.Caption = "受託";

            //// 委託数
            //DataColumn EntrustCnt = new DataColumn(CT_EntrustCnt, typeof(Double), "", MappingType.Element);
            //EntrustCnt.Caption = "委託";

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 売切数
            //DataColumn SoldCnt = new DataColumn(CT_SoldCnt, typeof(Int64), "", MappingType.Element);
            //SoldCnt.Caption = "売切";

            //// 委託数(自)
            //DataColumn EntrustCnt = new DataColumn(CT_EntrustCnt, typeof(Int64), "", MappingType.Element);
            //EntrustCnt.Caption = "委(自)";

            //// 委託数(受)
            //DataColumn TrustEntrustCnt = new DataColumn(CT_TrustEntrustCnt, typeof(Int64), "", MappingType.Element);
            //TrustEntrustCnt.Caption = "委(受)";

            //// 移動中仕入在庫数
            //DataColumn MovingSupliStock = new DataColumn(CT_MovingSupliStock, typeof(Int64), "", MappingType.Element);
            //MovingSupliStock.Caption = "移(仕)";

            //// 移動中受託在庫数
            //DataColumn MovingTrustStock = new DataColumn(CT_MovingTrustStock, typeof(Int64), "", MappingType.Element);
            //MovingTrustStock.Caption = "移(受)";

            //// 引当在庫数
            //DataColumn AllowStockCnt = new DataColumn(CT_AllowStockCnt, typeof(Int64), "", MappingType.Element);
            //AllowStockCnt.Caption = "引当";

            //// 予約数
            //DataColumn ReservedCount = new DataColumn(CT_ReservedCount, typeof(Int64), "", MappingType.Element);
            //ReservedCount.Caption = "予約";

            //// キャリア名称
            //DataColumn CarrierName = new DataColumn(CT_CarrierName, typeof(string), "", MappingType.Element);
            //CarrierName.Caption = "キャリア";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            #endregion // deleted

            // 選択用データ格納
            DataColumn Stock = new DataColumn(CT_StockSearchRet, typeof(StockExpansion), "", MappingType.Element);

            this._stockDataTable.Columns.AddRange(new DataColumn[]{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
                SelectButton,
                Select,
                RowNo,
                WarehouseCode,
                WarehouseShelfNo,
                MakerCode,
                GoodsName,
                GoodsCode,
                SupplierStock,
                MinimumStockCnt,
                MaximumStockCnt,
                SalesOrderCount,
                SupplierLot,
                ShipmentPosCnt,
                MovingSupliStock,
                ShipmentCnt,
                ArrivalCnt,
                AcpOdrCount,
                GoodsSpecialNote,
                BLGoodsCode,
                GoodsNameKana,
                DuplicationShelfNo1,
                DuplicationShelfNo2,
                MakerName,
                SupplierCd,
                SupplierSnm,
                ListPrice,
                StockUnitPrice,
                StockTotalPrice,
                UpdateDateString,
                StockCreateDateString,
                SectionCode,
                SectionName,
                WarehouseName,
                Stock

                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////ProductButton,
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                
                //WarehouseName,
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //MakerName,
                //MakerCode,
                //GoodsCode,
                //GoodsName,
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //SectionCode,
                //SectionName,
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //ShipmentPosCnt,
                //SupplierStock,			
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //TrustCount,
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////SoldCnt,
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //EntrustCnt,
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////TrustEntrustCnt,
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //MovingSupliStock,
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////MovingTrustStock,
                ////AllowStockCnt,
                ////ReservedCount,
                ////CarrierName,
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //Stock,
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //ShipmentCnt,
                //ArrivalCnt,
                //AcpOdrCount
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
		  });
            this._stockDataSet.Tables.Add(this._stockDataTable);

            // 在庫データ表示順を設定する
            //this._stockDataView.Sort = this._defaultStokSort;  // T.Nishi 2012/04/10 DEL

        }

        #endregion

        #region deleted

        #region ●　製番在庫テーブル作成処理
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 製番在庫テーブル作成処理
        ///// </summary>
        //private void CreateProductStockTable()
        //{
        //    this._productStockDataTable = new DataTable("ProductStockDataTable");
        //    this._productStockDataView = new DataView(this._productStockDataTable);

        //    // 選択用のセル
        //    DataColumn Select = new DataColumn(CT_Select, typeof(bool), "", MappingType.Element);
        //    Select.Caption = "";

        //    // 選択用のセルボタン
        //    DataColumn SelectButton = new DataColumn(CT_SelectButton, typeof(string), "", MappingType.Element);
        //    SelectButton.Caption = "選択/非選択";

        //    // 拠点コード
        //    DataColumn SectionCode = new DataColumn(CT_SectionCode, typeof(string), "", MappingType.Element);
        //    SectionCode.Caption = "拠点コード";

        //    // メーカーコード
        //    DataColumn MakerCode = new DataColumn(CT_MakerCode, typeof(int), "", MappingType.Element);
        //    MakerCode.Caption = "メーカーコード";

        //    // 商品コード
        //    DataColumn GoodsCode = new DataColumn(CT_GoodsCode, typeof(string), "", MappingType.Element);
        //    GoodsCode.Caption = "商品コード";

        //    // 商品名称
        //    DataColumn GoodsName = new DataColumn(CT_GoodsName, typeof(string), "", MappingType.Element);
        //    GoodsName.Caption = "商品名称";

        //    // 出荷可能数
        //    DataColumn ShipmentPosCnt = new DataColumn(CT_ShipmentPosCnt, typeof(Int64), "", MappingType.Element);
        //    ShipmentPosCnt.Caption = "可能";
        //    ShipmentPosCnt.DefaultValue = 0;

        //    // 仕入在庫数
        //    DataColumn SupplierStock = new DataColumn(CT_SupplierStock, typeof(Int64), "", MappingType.Element);
        //    SupplierStock.Caption = "仕入";
        //    SupplierStock.DefaultValue = 0;

        //    // 受託数
        //    DataColumn TrustCount = new DataColumn(CT_TrustCount, typeof(Int64), "", MappingType.Element);
        //    TrustCount.Caption = "受託";
        //    TrustCount.DefaultValue = 0;

        //    // 売切数
        //    DataColumn SoldCnt = new DataColumn(CT_SoldCnt, typeof(Int64), "", MappingType.Element);
        //    SoldCnt.Caption = "売切";
        //    SoldCnt.DefaultValue = 0;

        //    // 委託数(自)
        //    DataColumn EntrustCnt = new DataColumn(CT_EntrustCnt, typeof(Int64), "", MappingType.Element);
        //    EntrustCnt.Caption = "委(自)";
        //    EntrustCnt.DefaultValue = 0;

        //    // 委託数(受)
        //    DataColumn TrustEntrustCnt = new DataColumn(CT_TrustEntrustCnt, typeof(Int64), "", MappingType.Element);
        //    TrustEntrustCnt.Caption = "委(受)";
        //    TrustEntrustCnt.DefaultValue = 0;

        //    // 移動中仕入在庫数
        //    DataColumn MovingSupliStock = new DataColumn(CT_MovingSupliStock, typeof(Int64), "", MappingType.Element);
        //    MovingSupliStock.Caption = "移(仕)";
        //    MovingSupliStock.DefaultValue = 0;

        //    // 移動中受託在庫数
        //    DataColumn MovingTrustStock = new DataColumn(CT_MovingTrustStock, typeof(Int64), "", MappingType.Element);
        //    MovingTrustStock.Caption = "移(受)";
        //    MovingTrustStock.DefaultValue = 0;

        //    // 引当在庫数
        //    DataColumn AllowStockCnt = new DataColumn(CT_AllowStockCnt, typeof(Int64), "", MappingType.Element);
        //    AllowStockCnt.Caption = "引当";
        //    AllowStockCnt.DefaultValue = 0;

        //    // 予約数
        //    DataColumn ReservedCount = new DataColumn(CT_ReservedCount, typeof(Int64), "", MappingType.Element);
        //    ReservedCount.Caption = "予約";
        //    ReservedCount.DefaultValue = 0;

        //    // 製造番号
        //    DataColumn ProductNumber = new DataColumn(CT_ProductNumber, typeof(string), "", MappingType.Element);
        //    ProductNumber.Caption = "製造番号";

        //  // 在庫区分名
        //    DataColumn StockDivNm = new DataColumn(CT_StockDivNm, typeof(string), "", MappingType.Element);
        //    StockDivNm.Caption = "自/受";

        //    // 倉庫名称
        //    DataColumn WarehouseName = new DataColumn(CT_WarehouseName, typeof(string), "", MappingType.Element);
        //    WarehouseName.Caption = "倉庫";

        //    // 倉庫コード
        //    DataColumn WarehouseCode = new DataColumn(CT_WarehouseCode, typeof(string), "", MappingType.Element);
        //    WarehouseCode.Caption = "倉庫コード";

        //    // 仕入先
        //    DataColumn CustomerName = new DataColumn(CT_CustomerName, typeof(string), "", MappingType.Element);
        //    CustomerName.Caption = "仕入先";

        //    // 仕入日
        //    DataColumn StockDate = new DataColumn(CT_StockDate, typeof(int), "", MappingType.Element);
        //    StockDate.Caption = "仕入日";

        //    // 仕入日(文字列)
        //    DataColumn StockDateDisp = new DataColumn(CT_StockDateDisp, typeof(string), "", MappingType.Element);
        //    StockDateDisp.Caption = "仕入日";

        //    // 仕入単価
        //    DataColumn StockUnitPrice = new DataColumn(CT_StockUnitPrice, typeof(Int64), "", MappingType.Element);
        //    StockUnitPrice.Caption = "仕入単価";

        //    // 在庫状態
        //    DataColumn StockStateNm = new DataColumn(CT_StockStateNm, typeof(string), "", MappingType.Element);
        //    StockStateNm.Caption = "状態";

        //    // 移動状態
        //    DataColumn MoveStatusNm = new DataColumn(CT_MoveStatusNm, typeof(string), "", MappingType.Element);
        //    MoveStatusNm.Caption = "移";

        //    // 商品状態
        //    DataColumn GoodsCodeStatusNm = new DataColumn(CT_GoodsCodeStatusNm, typeof(string), "", MappingType.Element);
        //    GoodsCodeStatusNm.Caption = "商品状態";

        //    // 商品電話番号1
        //    DataColumn StockTelNo1 = new DataColumn(CT_StockTelNo1, typeof(string), "", MappingType.Element);
        //    StockTelNo1.Caption = "電話番号1";

        //    // 商品電話番号2
        //    DataColumn StockTelNo2 = new DataColumn(CT_StockTelNo2, typeof(string), "", MappingType.Element);
        //    StockTelNo2.Caption = "電話番号2";

        //    // ロム区分
        //    DataColumn RomDivNm = new DataColumn(CT_RomDivNm, typeof(string), "", MappingType.Element);
        //    RomDivNm.Caption = "ロム区分";

        //    // メーカ
        //    DataColumn MakerName = new DataColumn(CT_MakerName, typeof(string), "", MappingType.Element);
        //    MakerName.Caption = "メーカー";

        //    // キャリア名称
        //    DataColumn CarrierName = new DataColumn(CT_CarrierName, typeof(string), "", MappingType.Element);
        //    CarrierName.Caption = "キャリア";

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //// 選択用製番在庫格納用
        //    //DataColumn ProductStock = new DataColumn(CT_ProductStockSearchRet, typeof(ProductStock), "", MappingType.Element);
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    // 選択用在庫データ格納
        //    DataColumn Stock = new DataColumn(CT_StockSearchRet, typeof(Stock), "", MappingType.Element);

        //    this._productStockDataTable.Columns.AddRange(new DataColumn[]{
        //        SelectButton,
        //        Select,
        //        MakerName,
        //        MakerCode,
        //        GoodsCode,			
        //        GoodsName,
        //        ShipmentPosCnt,
        //        SupplierStock,
        //        TrustCount,
        //        SoldCnt,
        //        EntrustCnt,
        //        TrustEntrustCnt,
        //        MovingSupliStock,
        //        MovingTrustStock,
        //        AllowStockCnt,
        //        ReservedCount,
        //        ProductNumber,
        //        WarehouseCode,
        //        WarehouseName,
        //        CustomerName,
        //        StockDate,
        //        StockDateDisp,
        //        StockUnitPrice,
        //        StockDivNm,
        //        StockStateNm,
        //        MoveStatusNm,			
        //        GoodsCodeStatusNm,
        //        StockTelNo1,
        //        StockTelNo2,			
        //        RomDivNm,			
        //        CarrierName,
        //        SectionCode,
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //ProductStock,
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //        Stock
        //  });

        //    this._stockDataSet.Tables.Add(this._productStockDataTable);

        //    this._productStockDataView.Sort = CT_MakerCode + "," + CT_GoodsCode + "," + CT_ProductNumber;

        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #endregion // deleted

        #endregion

        // --------------------------------------------------
        #region < UltraGrid関連の処理 >

        #region ◆　グリッド共通レイアウト設定
        /// <summary>
        /// グリッド共通レイアウト設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド共通のレイアウト設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.12.25</br>
        /// </remarks>
        private void InitializeLayoutGridCommon(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = sender as Infragistics.Win.UltraWinGrid.UltraGrid;
            if (grid == null) return;

            // スクロールバースタイル
            e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            e.Layout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

            // 列ヘッダの表示スタイル
            e.Layout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Default;

            // セルの境界線スタイルの設定 
            e.Layout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Default;

            // 行の境界線スタイルの設定 
            e.Layout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Default;

            // データ行の追加許可
            e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // データ行の削除許可
            e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            // データ行の更新許可
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            // 列移動の変更
            e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.Default;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 固定列ヘッダ
            //e.Layout.UseFixedHeaders = false;
            e.Layout.UseFixedHeaders = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // セルクリック時実行アクション
            e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;

            //// ActiveCellの外観設定
            //e.Layout.Override.ActiveCellAppearance.BackColor = Color.FromArgb(247, 227, 156);

            //// ヘッダーの外観設定
            //e.Layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            //e.Layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            //e.Layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //e.Layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            //e.Layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            //e.Layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            //if (e.Layout.Bands.Count > 1)
            //{
            //  e.Layout.Bands[1].Override.HeaderAppearance.BackColor = Color.FromArgb(247, 247, 249);
            //  e.Layout.Bands[1].Override.HeaderAppearance.BackColor2 = Color.FromArgb(168, 167, 191);
            //  e.Layout.Bands[1].Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //  e.Layout.Bands[1].Override.HeaderAppearance.ForeColor = System.Drawing.Color.Black;
            //  e.Layout.Bands[1].Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            //  e.Layout.Bands[1].Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            //}

            // ヘッダクリックアクションの設定
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

            //// 行の外観設定
            //e.Layout.Override.RowAppearance.BackColor = Color.White;
            //e.Layout.Override.RowAppearance.BorderColor = Color.FromArgb(1, 68, 208);

            //// セルの外観設定
            //e.Layout.Override.CellAppearance.ForeColorDisabled = Color.Black;

            // 1行おきの外観設定
            e.Layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // 行セレクターの表示非表示
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            //// 行セレクターの外観設定
            //e.Layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            //e.Layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            //e.Layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //e.Layout.Override.RowSelectorAppearance.ForeColor = System.Drawing.Color.White;

            //if (e.Layout.Bands.Count > 1)
            //{
            //  e.Layout.Bands[1].Override.RowSelectorAppearance.BackColor = Color.FromArgb(247, 247, 249);
            //  e.Layout.Bands[1].Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(168, 167, 191);
            //  e.Layout.Bands[1].Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //  e.Layout.Bands[1].Override.RowSelectorAppearance.ForeColor = System.Drawing.Color.Black;
            //}


            // 行選択設定 行選択無しモード(アクティブのみ)
            e.Layout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            e.Layout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            e.Layout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;

            //// 選択行の外観設定
            //e.Layout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            //e.Layout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            //e.Layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //// 行選択時は、全ての列の文字色は黒とする(この記述ないと白色になって見難いとの批判があったため。)
            //e.Layout.Override.SelectedRowAppearance.ForeColor = Color.Black;

            // 行フィルターの設定
            //e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

            // テキストのレンタリング設定
            e.Layout.Override.CellAppearance.TextTrimming = Infragistics.Win.TextTrimming.Character;
        }

        #endregion

        #region ◆　グリッドの列設定
        /// <summary>
        /// 在庫グリッドの列設定
        /// </summary>
        /// <remarks>
        /// <br>Note      : グリッドの列設定を行います。</br>
        /// <br>Programmer: 18012 Y.Sasaki</br>
        /// <br>Date      : 2007.2.6</br>
        /// </remarks>
        private void SettingStockGridColumns()
        {
            // バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band0 = this.gridResult.DisplayLayout.Bands[0];
            Infragistics.Win.UltraWinGrid.ColumnsCollection clmns0 = band0.Columns;

            // 列の表示・非表示制御
            for (int i = 0; i < band0.Columns.Count; i++)
            {
                // アクティブ時動作 
                band0.Columns[i].Header.VisiblePosition = i;
                band0.Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                // セルクリック時のアクション
                band0.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                band0.Columns[i].Hidden = true;
                // 固定列クリップボタンを表示しない
                band0.Columns[i].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;


                switch (band0.Columns[i].Key)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 製番詳細
                    //case CT_ProductButton:
                    //    {
                    //        switch (this._searchMode)
                    //        {
                    //            // 商品在庫製番
                    //            case ( int ) emSearchMode.Stock:
                    //            // 在庫結果表示
                    //            case (int)emSearchMode.ResultStock:
                    //                {
                    //                    band0.Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    //                    band0.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
                    //                    band0.Columns[i].Hidden = false;
                    //                    break;
                    //                }
                    //            // 商品在庫
                    //            case (int)emSearchMode.GoodsStock:
                    //            // 製番
                    //            case ( int ) emSearchMode.Product:
                    //            // 商品
                    //            case (int)emSearchMode.Goods:
                    //            // 製番結果表示
                    //            case ( int ) emSearchMode.ResultProduct:
                    //            // 製番(在庫情報含む)
                    //            case ( int ) emSearchMode.ProductwitchStock:
                    //            // 製番結果表示(在庫情報含む)
                    //            case ( int ) emSearchMode.ResultProductwitchStock:
                    //            case ( int ) emSearchMode.ResultStockNoButton:
                    //                break;
                    //        }

                    //        break;
                    //    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
                    // 選択
                    case CT_SelectButton:
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            //if (this._isMultiSelect && this._searchMode != (int)emSearchMode.Stock && this._searchMode != (int)emSearchMode.ResultStock)
                            //..if ( this._isMultiSelect && this._searchMode != ( int ) emSearchMode.Stock && this._searchMode != ( int ) emSearchMode.ResultStock )
                            if (this._isMultiSelect)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                            {
                                band0.Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                band0.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
                                band0.Columns[i].Hidden = false;
                            }
                            band0.Columns[i].Header.Fixed = true;
                            break;
                        }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
                    case CT_RowNo:
                    case CT_GoodsName:      // 品名
                    case CT_GoodsCode:      // 品番
                    case CT_MakerName:      // メーカー名
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// キャリア
                    //case CT_CarrierName:
                    //    {
                    //        band0.Columns[i].Hidden = false;
                    //        break;
                    //    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    case CT_SupplierStock:      // 現在庫(仕)
                    case CT_MovingSupliStock:   // 移動数
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    case CT_ShipmentPosCnt:   // 出荷可能数
                    //case CT_TrustCount:       // 受託数
                    //case CT_SoldCnt:          // 売切数
                    //case CT_EntrustCnt:       // 委託数(自)
                    //case CT_TrustEntrustCnt:  // 委託数(受)
                    //case CT_MovingTrustStock: // 移動中受託在庫数
                    //case CT_AllowStockCnt:    // 引当在庫数
                    //case CT_ReservedCount:    // 予約数
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    case CT_ShipmentCnt:        // 出荷数（未計上）
                    case CT_ArrivalCnt:         // 入荷数（未計上）
                    case CT_AcpOdrCount:        // 受注数
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        {
                            if (this._searchMode != (int)emSearchMode.Goods)
                                band0.Columns[i].Hidden = false;
                            else
                                band0.Columns[i].Hidden = true;
                            break;
                        }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    case CT_WarehouseCode:  // 倉庫コード
                    case CT_WarehouseName:  // 倉庫名称
                        {
                            if (this._isFixedWarehouseCode == false)
                            {
                                band0.Columns[i].Hidden = false;
                            }
                            else
                            {
                                band0.Columns[i].Hidden = true;
                            }
                            break;
                        }

                    case CT_SectionCode:    // 拠点コード
                    case CT_SectionName:    // 拠点名称
                        {
                            if (this._isFixedSection == false)
                            {
                                band0.Columns[i].Hidden = false;
                            }
                            else
                            {
                                band0.Columns[i].Hidden = true;
                            }
                            break;
                        }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                    case CT_WarehouseShelfNo:
                    case CT_MakerCode:
                    //case CT_SupplierStock:
                    case CT_MinimumStockCnt:
                    case CT_MaximumStockCnt:
                    case CT_SalesOrderCount:
                    case CT_SupplierLot:
                    //case CT_MovingSupliStock:
                    //case CT_ShipmentCnt:
                    //case CT_ArrivalCnt:
                    case CT_GoodsSpecialNote:
                    case CT_BLGoodsCode:
                    case CT_GoodsNameKana:
                    case CT_DuplicationShelfNo1:
                    case CT_DuplicationShelfNo2:
                    case CT_SupplierCd:
                    case CT_SupplierSnm:
                    case CT_ListPrice:
                    case CT_StockUnitPrice:
                    case CT_StockTotalPrice:
                    case CT_UpdateDateString:
                    case CT_StockCreateDateString:
                        {
                            // セル表示
                            band0.Columns[i].Hidden = false;
                            break;
                        }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
                    case CT_StockSearchRet:
                    default:
                        // セル非表示
                        band0.Columns[i].Hidden = true;

                        break;
                }
            }

            //---------------------------------------------------------------------
            //  固定列
            //---------------------------------------------------------------------
            // 固定列区切り線設定
            this.gridResult.DisplayLayout.Override.FixedCellSeparatorColor = this.gridResult.DisplayLayout.Override.HeaderAppearance.BackColor2;

            //---------------------------------------------------------------------
            //　列スタイルの設定
            //---------------------------------------------------------------------
            // ※　列のスタイルを設定します
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_ProductButton].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            clmns0[CT_SelectButton].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            //---------------------------------------------------------------------
            //　セルボタンの表示スタイル
            //---------------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_ProductButton].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            clmns0[CT_SelectButton].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            //セルボタンの外観
            band0.Override.CellButtonAppearance = this.Layout1_Label.Appearance;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            //---------------------------------------------------------------------
            //　列フォントの設定
            //---------------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_ProductButton].CellAppearance.ForeColor = Color.Blue;
            //clmns0[CT_ProductButton].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //---------------------------------------------------------------------
            //　アクティブ時動作
            //---------------------------------------------------------------------

            //---------------------------------------------------------------------
            //　列幅
            //---------------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            clmns0[CT_RowNo].Width = 20;
            clmns0[CT_SelectButton].Width = 50;
            // 列幅は仕様書のイメージより
            clmns0[CT_WarehouseCode].Width = 60;        //
            clmns0[CT_WarehouseShelfNo].Width = 70;     //
            clmns0[CT_MakerCode].Width = 90;            //
            clmns0[CT_GoodsName].Width = 90;            //
            clmns0[CT_GoodsCode].Width = 90;            //
            clmns0[CT_SupplierStock].Width = 60;        //
            clmns0[CT_MinimumStockCnt].Width = 50;      //
            clmns0[CT_MaximumStockCnt].Width = 50;      //
            clmns0[CT_SalesOrderCount].Width = 50;      //
            clmns0[CT_SupplierLot].Width = 60;          //
            clmns0[CT_ShipmentPosCnt].Width = 60;       //
            clmns0[CT_MovingSupliStock].Width = 60;     //
            clmns0[CT_ShipmentCnt].Width = 90;          //
            clmns0[CT_ArrivalCnt].Width = 90;           //
            clmns0[CT_AcpOdrCount].Width = 50;          //
            clmns0[CT_GoodsSpecialNote].Width = 100;    //
            clmns0[CT_BLGoodsCode].Width = 70;          //
            clmns0[CT_GoodsNameKana].Width = 90;        //
            clmns0[CT_DuplicationShelfNo1].Width = 50;  //
            clmns0[CT_DuplicationShelfNo2].Width = 50;  //
            clmns0[CT_MakerName].Width = 80;            //
            clmns0[CT_SupplierCd].Width = 80;           //
            clmns0[CT_SupplierSnm].Width = 70;          //
            clmns0[CT_ListPrice].Width = 60;            //
            clmns0[CT_StockUnitPrice].Width = 70;       //
            clmns0[CT_StockTotalPrice].Width = 70;      //
            clmns0[CT_UpdateDateString].Width = 80;     //
            clmns0[CT_StockCreateDateString].Width = 80;//
            clmns0[CT_SectionCode].Width = 60;          //
            clmns0[CT_SectionName].Width = 60;          //
            clmns0[CT_WarehouseName].Width = 60;        //
            //clmns0[CT_StockSearchRet].Width = 100;               // TODO ←表示項目？


            //clmns0[CT_SelectButton].Header.VisiblePosition = 0;
            //clmns0[CT_RowNo].Header.VisiblePosition = 1;
            //// 列幅は仕様書のイメージより
            //clmns0[CT_WarehouseCode].Header.VisiblePosition = 2;
            //clmns0[CT_WarehouseShelfNo].Header.VisiblePosition = 3;
            //clmns0[CT_MakerCode].Header.VisiblePosition = 4;
            //clmns0[CT_GoodsName].Header.VisiblePosition = 5;
            //clmns0[CT_GoodsCode].Header.VisiblePosition = 6;
            //clmns0[CT_SupplierStock].Header.VisiblePosition = 7;
            //clmns0[CT_MinimumStockCnt].Header.VisiblePosition = 8;
            //clmns0[CT_MaximumStockCnt].Header.VisiblePosition = 9;
            //clmns0[CT_SalesOrderCount].Header.VisiblePosition = 10;
            //clmns0[CT_SupplierLot].Header.VisiblePosition = 11;
            //clmns0[CT_ShipmentPosCnt].Header.VisiblePosition = 12;
            //clmns0[CT_MovingSupliStock].Header.VisiblePosition = 13;
            //clmns0[CT_ShipmentCnt].Header.VisiblePosition = 14;
            //clmns0[CT_ArrivalCnt].Header.VisiblePosition = 15;
            //clmns0[CT_AcpOdrCount].Header.VisiblePosition = 16;
            //clmns0[CT_GoodsSpecialNote].Header.VisiblePosition = 17;
            //clmns0[CT_BLGoodsCode].Header.VisiblePosition = 18;
            //clmns0[CT_GoodsNameKana].Header.VisiblePosition = 19;
            //clmns0[CT_DuplicationShelfNo1].Header.VisiblePosition = 20;
            //clmns0[CT_DuplicationShelfNo2].Header.VisiblePosition = 21;
            //clmns0[CT_MakerName].Header.VisiblePosition = 22;
            //clmns0[CT_SupplierCd].Header.VisiblePosition = 23;
            //clmns0[CT_SupplierSnm].Header.VisiblePosition = 24;
            //clmns0[CT_ListPrice].Header.VisiblePosition = 25;
            //clmns0[CT_StockUnitPrice].Header.VisiblePosition = 26;
            //clmns0[CT_StockTotalPrice].Header.VisiblePosition = 27;
            //clmns0[CT_UpdateDateString].Header.VisiblePosition = 28;
            //clmns0[CT_StockCreateDateString].Header.VisiblePosition = 29;
            //clmns0[CT_SectionCode].Header.VisiblePosition = 30;
            //clmns0[CT_SectionName].Header.VisiblePosition = 31;
            //clmns0[CT_WarehouseName].Header.VisiblePosition = 32;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_ProductButton].Width = 50;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //clmns0[CT_GoodsCode].Width = 90;
            //clmns0[CT_GoodsName].Width = 90;
            //clmns0[CT_ShipmentPosCnt].Width = 60;
            //clmns0[CT_SupplierStock].Width = 60;
            //clmns0[CT_TrustCount].Width = 60;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_SoldCnt].Width = 49;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //clmns0[CT_EntrustCnt].Width = 60;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_TrustEntrustCnt].Width = 59;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //clmns0[CT_MovingSupliStock].Width = 60;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_MovingTrustStock].Width = 59;
            //clmns0[CT_AllowStockCnt].Width = 49;
            //clmns0[CT_ReservedCount].Width = 30;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //clmns0[CT_MakerName].Width = 80;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_CarrierName].Width = 89;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_WarehouseCode].Width = 60;
            //clmns0[CT_WarehouseName].Width = 60;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_SectionCode].Width = 60;
            //clmns0[CT_SectionName].Width = 60;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            ////---------------------------------------------------------------------
            ////　列幅の固定
            ////---------------------------------------------------------------------
            //clmns0[CT_ProductButton].LockedWidth = true;
            clmns0[CT_SelectButton].LockedWidth = true;
            //clmns0[CT_RowNo].LockedWidth = true;

            //---------------------------------------------------------------------
            //　テキストの表示位置
            //---------------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            clmns0[CT_RowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_WarehouseCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_WarehouseShelfNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_MakerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_GoodsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_SupplierStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_MinimumStockCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_MaximumStockCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_SalesOrderCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_SupplierLot].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_ShipmentPosCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_MovingSupliStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_ShipmentCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_ArrivalCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_AcpOdrCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_GoodsSpecialNote].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_BLGoodsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_GoodsNameKana].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_DuplicationShelfNo1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_DuplicationShelfNo2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_SupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_SupplierSnm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_ListPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_StockUnitPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_StockTotalPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            clmns0[CT_UpdateDateString].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            clmns0[CT_StockCreateDateString].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            clmns0[CT_SectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_SectionName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            clmns0[CT_WarehouseName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //clmns0[CT_StockSearchRet].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;    // TODO ←表示項目？
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_ProductButton].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            clmns0[CT_SelectButton].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //clmns0[CT_GoodsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //clmns0[CT_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //				clmns0["CustomerName"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //clmns0[CT_ShipmentPosCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //clmns0[CT_SupplierStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //clmns0[CT_TrustCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_SoldCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //clmns0[CT_EntrustCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_TrustEntrustCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //clmns0[CT_MovingSupliStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_MovingTrustStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //clmns0[CT_AllowStockCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //clmns0[CT_ReservedCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //clmns0[CT_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_CarrierName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_WarehouseCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //clmns0[CT_WarehouseName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //clmns0[CT_ShipmentCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //clmns0[CT_ArrivalCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //clmns0[CT_AcpOdrCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //---------------------------------------------------------------------
            //　フォーマットの設定
            //---------------------------------------------------------------------
            // --- CHG 2009/03/11 障害ID:12315対応------------------------------------------------------>>>>>
            //string decimalFormat = "#,##0.00;-#,##0.00;''";
            string decimalFormat = "N";
            // --- CHG 2009/03/11 障害ID:12315対応------------------------------------------------------<<<<<
            string longformat = "#,##0;";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            clmns0[CT_SupplierStock].Format = decimalFormat;
            clmns0[CT_MinimumStockCnt].Format = decimalFormat;
            clmns0[CT_MaximumStockCnt].Format = decimalFormat;
            clmns0[CT_SalesOrderCount].Format = decimalFormat;
            clmns0[CT_ShipmentPosCnt].Format = decimalFormat;
            clmns0[CT_MovingSupliStock].Format = decimalFormat;
            clmns0[CT_ShipmentCnt].Format = decimalFormat;
            clmns0[CT_ArrivalCnt].Format = decimalFormat;
            clmns0[CT_AcpOdrCount].Format = decimalFormat;
            // --- CHG 2009/02/09 障害ID:11217対応------------------------------------------------------>>>>>
            //clmns0[CT_ListPrice].Format = decimalFormat;
            clmns0[CT_ListPrice].Format = longformat;
            // --- CHG 2009/02/09 障害ID:11217対応------------------------------------------------------<<<<<
            clmns0[CT_StockUnitPrice].Format = decimalFormat;
            /* ---DEL 2009/04/01 不具合対応[12837] ---------------------------------------------------------->>>>>
            // --- CHG 2009/02/09 障害ID:11217対応------------------------------------------------------>>>>>
            //clmns0[CT_StockTotalPrice].Format = longformat;
            clmns0[CT_StockTotalPrice].Format = decimalFormat;
            // --- CHG 2009/02/09 障害ID:11217対応------------------------------------------------------<<<<<
            //clmns0[CT_StockTotalPrice].Format = decimalFormat;
               ---DEL 2009/04/01 不具合対応[12837] ----------------------------------------------------------<<<<< */
            clmns0[CT_StockTotalPrice].Format = longformat;     //ADD 2009/04/01 不具合対応[12837]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //clmns0[CT_ShipmentPosCnt].Format = decimalFormat;
            //clmns0[CT_SupplierStock].Format = decimalFormat;
            //clmns0[CT_TrustCount].Format = decimalFormat;
            //clmns0[CT_EntrustCnt].Format = decimalFormat;
            //clmns0[CT_MovingSupliStock].Format = decimalFormat;
            //clmns0[CT_ShipmentCnt].Format = decimalFormat;
            //clmns0[CT_ArrivalCnt].Format = decimalFormat;
            //clmns0[CT_AcpOdrCount].Format = decimalFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
        }

        #region deleted
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 製番在庫グリッドの列設定
        ///// </summary>
        ///// <remarks>
        ///// <br>Note      : グリッドの列設定を行います。</br>
        ///// <br>Programmer: 18012 Y.Sasaki</br>
        ///// <br>Date      : 2007.2.6</br>
        ///// </remarks>
        //private void SettingProductGridColumns()
        //{
        //    string _moneyFormat = "#,##0;-#,##0;''";

        //    // バンドを取得
        //    Infragistics.Win.UltraWinGrid.UltraGridBand band0 = this.gridResult.DisplayLayout.Bands[0];
        //    Infragistics.Win.UltraWinGrid.ColumnsCollection clmns0 = band0.Columns;

        //    // 列の表示・非表示制御
        //    for (int i = 0; i < band0.Columns.Count; i++)
        //    {
        //        // アクティブ時動作 
        //        band0.Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
        //        //　セルクリック時のアクション
        //        band0.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
        //        band0.Columns[i].Hidden = true;

        //        switch (band0.Columns[i].Key)
        //        {
        //            // 選択
        //            case CT_SelectButton:
        //                {
        //                    if (this._isMultiSelect)
        //                    {
        //                        band0.Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
        //                        band0.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
        //                        band0.Columns[i].Hidden = false;
        //                    }
        //                    break;
        //                }
        //            // 商品コード
        //            case CT_GoodsCode:
        //            // 商品名
        //            case CT_GoodsName:
        //            //// 出荷可能数
        //            //case CT_ShipmentPosCnt:
        //            // 製造番号
        //            case CT_ProductNumber:
        //            // 倉庫
        //            case CT_WarehouseName:
        //            // 仕入先
        //            case CT_CustomerName:
        //            // 在庫区分名
        //            case CT_StockDivNm:
        //            // 在庫状態名
        //            case CT_StockStateNm:
        //            // 移動状態名
        //            case CT_MoveStatusNm:
        //            // 商品電話番号1
        //            case CT_StockTelNo1:
        //            // 商品電話番号2
        //            case CT_StockTelNo2:
        //            // 仕入日
        //            case CT_StockDateDisp:
        //            // 仕入単価
        //            case CT_StockUnitPrice:
        //                band0.Columns[i].Hidden = false;
        //                break;
        //            default:
        //                band0.Columns[i].Hidden = true;
        //                break;
        //        }
        //    }

        //    //---------------------------------------------------------------------
        //    //　列スタイルの設定
        //    //---------------------------------------------------------------------
        //    // ※　列のスタイルを設定します
        //    clmns0[CT_SelectButton].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

        //    //---------------------------------------------------------------------
        //    //　セルボタンの表示いスタイル
        //    //---------------------------------------------------------------------
        //    clmns0[CT_SelectButton].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

        //    //セルボタンの外観
        //    band0.Override.CellButtonAppearance = this.Layout1_Label.Appearance;

        //    //---------------------------------------------------------------------
        //    //　列幅
        //    //---------------------------------------------------------------------
        //    // 選択
        //    clmns0[CT_SelectButton].Width = 77;
        //    // 商品コード
        //    clmns0[CT_GoodsCode].Width = 102;
        //    // 商品名
        //    clmns0[CT_GoodsName].Width = 87;
        //    //// 出荷可能
        //    //clmns0[CT_ShipmentPosCnt].Width = 38;
        //    // 製造番号
        //    clmns0[CT_ProductNumber].Width = 129;
        //    // 倉庫
        //    clmns0[CT_WarehouseName].Width = 126;
        //    // 仕入先名
        //    clmns0[CT_CustomerName].Width = 108;
        //    // 仕入日
        //    clmns0[CT_StockDateDisp].Width = 96;
        //    // 仕入単価
        //    clmns0[CT_StockUnitPrice].Width = 94;
        //    // 在庫区分名
        //    clmns0[CT_StockDivNm].Width = 45;
        //    // 在庫状態名
        //    clmns0[CT_StockStateNm].Width = 50;
        //    // 移動状態名
        //    clmns0[CT_MoveStatusNm].Width = 50;
        //    // 商品電話番号1
        //    clmns0[CT_StockTelNo1].Width = 75;
        //    // 商品電話番号2
        //    clmns0[CT_StockTelNo2].Width = 75;

        //    //---------------------------------------------------------------------
        //    //　列幅の固定
        //    //---------------------------------------------------------------------
        //    clmns0[CT_SelectButton].LockedWidth = true;

        //    //---------------------------------------------------------------------
        //    //　テキストの表示位置
        //    //---------------------------------------------------------------------
        //    clmns0[CT_SelectButton].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    clmns0[CT_ProductNumber].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
        //    clmns0[CT_WarehouseName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
        //    clmns0[CT_ShipmentPosCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    clmns0[CT_SupplierStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    clmns0[CT_TrustCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //clmns0[CT_SoldCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    clmns0[CT_EntrustCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //clmns0[CT_TrustEntrustCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    clmns0[CT_MovingSupliStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    //clmns0[CT_MovingTrustStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    //clmns0[CT_AllowStockCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    //clmns0[CT_ReservedCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //    clmns0[CT_StockTelNo1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
        //    clmns0[CT_StockTelNo2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
        //    clmns0[CT_StockDateDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //    clmns0[CT_StockUnitPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

        //    //---------------------------------------------------------------------
        //    //　フォーマットの設定
        //    //---------------------------------------------------------------------
        //    clmns0[CT_StockUnitPrice].Format = _moneyFormat;

        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion // deleted

        #endregion

        #region ◆　カラム列幅調整
        /// <summary>
        /// カラム列幅調整
        /// </summary>
        /// <remarks>
        /// <br>Note       : カラムの列幅を調整します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.2.2</br>
        /// </remarks>
        private void ColumnPerformAutoResize()
        {
            if (!this._isEventAutoFillColumn) return;

            this._isEventAutoFillColumn = false;

            try
            {
                bool isAutoCol = this.AutoFillToGridColumn_CheckEditor.Checked;

                if (isAutoCol) return;

                this.AutoFillToGridColumn_CheckEditor.Checked = false;

                for (int i = 0; i < this.gridResult.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.gridResult.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
                }

                this.AutoFillToGridColumn_CheckEditor.Checked = isAutoCol;
            }
            finally
            {
                this._isEventAutoFillColumn = true;
            }
        }
        #endregion

        #region ◆　選択・非選択変更処理

        /// <summary>
        /// 選択・非選択変更処理
        /// </summary>
        /// <param name="isSelected">[T:選択,F:非選択]</param>
        /// <param name="gridRow">対象のグリッド行</param>
        private void ChangedSelect(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            // 対象行の選択色を設定する
            if (isSelected)
            {
                gridRow.Appearance.BackColor = _selectedBackColor;
                gridRow.Appearance.BackColor2 = _selectedBackColor2;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
                gridRow.Cells[CT_SelectButton].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
            }
            else
            {
                if (gridRow.Index % 2 == 1)
                    gridRow.Appearance.BackColor = Color.Lavender;
                else
                    gridRow.Appearance.BackColor = Color.White;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
                gridRow.Cells[CT_SelectButton].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.Default;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
            }

            // 選択・非選択
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            gridRow.Cells[CT_SelectButton].Value = isSelected ? "選択" : "";
            gridRow.Cells[CT_Select].Value = isSelected;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
        }

        #endregion

        #region ◆　グリッドの描画処理
        /// <summary>
        /// グリッドのセッティング描画処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド全体のセルスタイル・文字色を設定する。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.02.07</br>
        /// </remarks>
        private void SettingGridRowEditor()
        {
            int cnt = this.gridResult.Rows.Count;

            if (this.InvokeRequired == false)
            {
                // 描画を一時停止
                this.gridResult.BeginUpdate();
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
                    this.gridResult.EndUpdate();
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
        /// <br>Date       : 2007.02.07</br>
        /// </remarks>
        private void SettingGridRowEditor(int row)
        {


        }
        #endregion

        #region ◆　グリッドキーマッピング設定
        /// <summary>
        /// グリッドのキーマッピングを設定します。
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        /// <remarks>
        /// <br>Note       : グリッドに追加キーをマッピングします</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.02.13</br>
        /// </remarks>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0);
            grid.KeyActionMappings.Add(enterMap);

        }
        #endregion

        #endregion

        // --------------------------------------------------
        #region < 抽出条件関連の処理 >

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// キャリア条件設定
        ///// </summary>
        ///// <param name="data">キャリアデータクラス</param>
        ///// <param name="para">検索条件クラス</param>
        ///// <remarks>
        ///// <br>Note		: データクラスから検索パラメータを設定します。</br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2007.2.2</br>
        ///// </remarks>
        //private void SetSearchParaFromCarrier(Carrier data, ref StockSearchPara para)
        //{
        //    if (data != null)
        //    {
        //        para.CarrierCode = data.CarrierCode;
        //        para.CarrierName = data.CarrierName;

        //        this.CarrierName_tEdit.DataText = data.CarrierName;
        //        this.CarrierName_tEdit.Tag = data.CarrierCode;
        //    }
        //    else
        //    {
        //        para.CarrierCode = 0;
        //        para.CarrierName = "";

        //        this.CarrierName_tEdit.Clear();
        //        this.CarrierName_tEdit.Tag = null;
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// メーカー条件設定
        /// </summary>
        /// <param name="data">メーカークラス</param>
        /// <param name="para">検索条件クラス</param>
        /// <remarks>
        /// <br>Note		: データクラスから検索パラメータを設定します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.2</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private void SetSearchParaFromMaker(Maker data, ref StockSearchPara para)
        private void SetSearchParaFromMaker(MakerUMnt data, ref StockSearchPara para)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        {
            if (data != null)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //para.MakerCode = data.MakerCode;
                para.GoodsMakerCd = data.GoodsMakerCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //para.MakerName = data.MakerName;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
                this.tNedit_GoodsMakerCd.SetInt(data.GoodsMakerCd);
                this.tNedit_GoodsMakerCd.Tag = data.GoodsMakerCd.ToString();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this.tNedit_GoodsMakerCd.Tag = data.MakerCode.ToString();
                this.uLabel_MakerName.Tag = data.GoodsMakerCd.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                this.uLabel_MakerName.Text = data.MakerName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
            }
            else
            {
                para.GoodsMakerCd = 0;
                //para.MakerName = "";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
                //this.tNedit_GoodsMakerCd.Tag = null;
                this.tNedit_GoodsMakerCd.Tag = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
                this.tNedit_GoodsMakerCd.DataText = "";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                this.uLabel_MakerName.Tag = string.Empty;
                this.uLabel_MakerName.Text = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// BL商品コード条件設定
        /// </summary>
        /// <param name="data">メーカークラス</param>
        /// <param name="para">検索条件クラス</param>
        /// <remarks>
        /// <br>Note         : データクラスから検索パラメータを設定します。</br>
        /// <br>Programmer   : 22018 鈴木正臣</br>
        /// <br>Date         : 2008.2.13</br>
        /// </remarks>
        private void SetSearchParaFromBLGoods(BLGoodsCdUMnt data, ref StockSearchPara para)
        {
            if (data != null)
            {
                para.BLGoodsCode = data.BLGoodsCode;
                para.BLGoodsName = data.BLGoodsName;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                this.tNedit_BLGoodsCode.SetInt(data.BLGoodsCode);
                this.tNedit_BLGoodsCode.Tag = data.BLGoodsCode.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

                this.tEdit_BLGoodsName.Tag = data.BLGoodsCode.ToString();
                this.tEdit_BLGoodsName.DataText = data.BLGoodsFullName.TrimEnd();
            }
            else
            {
                para.BLGoodsCode = 0;
                para.BLGoodsName = string.Empty;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                this.tNedit_BLGoodsCode.DataText = string.Empty;
                this.tNedit_BLGoodsCode.Tag = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

                this.tEdit_BLGoodsName.Tag = string.Empty;
                this.tEdit_BLGoodsName.DataText = string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 事業者条件設定
        ///// </summary>
        ///// <param name="data">メーカークラス</param>
        ///// <param name="para">検索条件クラス</param>
        ///// <remarks>
        ///// <br>Note		: データクラスから検索パラメータを設定します。</br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2007.2.2</br>
        ///// </remarks>
        //private void SetSearchParaFromCarrierEp(CarrierEp data, ref StockSearchPara para)
        //{
        //    if (data != null)
        //    {
        //        para.CarrierEpCode = data.CarrierEpCode;
        //        para.CarrierEpName = data.CarrierEpName;

        //        this.CarrierEpName_tEdit.Tag = data.CarrierEpCode.ToString();
        //        this.CarrierEpName_tEdit.Tag = data.CarrierEpName;
        //    }
        //    else
        //    {
        //        para.CarrierEpCode = 0;
        //        para.CarrierEpName = "";

        //        this.CarrierEpName_tEdit.Tag = null;
        //        this.CarrierEpName_tEdit.Clear();
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
        //        /// <summary>
        //        /// 商品商品グループ条件設定
        //        /// </summary>
        //        /// <param name="data">商品商品グループクラス</param>
        //        /// <param name="para">検索条件クラス</param>
        //        /// <remarks>
        //        /// <br>Note		: データクラスから検索パラメータを設定します。</br>
        //        /// <br>Programmer	: 18012 Y.Sasaki</br>
        //        /// <br>Date		: 2007.2.2</br>
        //        /// </remarks>
        //        private void SetSearchParaFromLGoodsGanre(LGoodsGanre data, ref StockSearchPara para)
        //        {
        //            if (data != null)
        //            {
        //                para.LargeGoodsGanreCode = data.LargeGoodsGanreCode;
        //                para.LargeGoodsGanreName = data.LargeGoodsGanreName;

        //                this.LargeGoodsGanreName_tEdit.Tag = data.LargeGoodsGanreCode.ToString();
        //                this.LargeGoodsGanreName_tEdit.DataText = data.LargeGoodsGanreName;
        //            }
        //            else
        //            {
        //                para.LargeGoodsGanreCode = "";
        //                para.LargeGoodsGanreName = "";

        //                // >>>>> 2007.07.09 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        ////				this.LargeGoodsGanreName_tEdit.Tag = 0;
        //                this.LargeGoodsGanreName_tEdit.Tag = null;
        //                // <<<<< 2007.07.09 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        //                this.LargeGoodsGanreName_tEdit.DataText = string.Empty;
        //            }

        //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ////            // 商品商品区分をクリアする
        ////            para.MediumGoodsGanreCode = "";
        ////            para.MediumGoodsGanreName = "";

        ////            // >>>>> 2007.07.09 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        //////			this.MediumGoodsGanreName_tEdit.Tag = 0;
        ////            this.MediumGoodsGanreName_tEdit.Tag = null;
        ////            // <<<<< 2007.07.09 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        ////            this.MediumGoodsGanreName_tEdit.DataText = string.Empty;
        //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //        }

        //        /// <summary>
        //        /// 商品商品区分条件設定
        //        /// </summary>
        //        /// <param name="data">商品商品区分クラス</param>
        //        /// <param name="para">検索条件クラス</param>
        //        /// <remarks>
        //        /// <br>Note		: データクラスから検索パラメータを設定します。</br>
        //        /// <br>Programmer	: 18012 Y.Sasaki</br>
        //        /// <br>Date		: 2007.2.2</br>
        //        /// </remarks>
        //        private void SetSearchParaFromMGoodsGanre(MGoodsGanre data, ref StockSearchPara para)
        //        {
        //            if (data != null)
        //            {
        //                para.MediumGoodsGanreCode = data.MediumGoodsGanreCode;
        //                para.MediumGoodsGanreName = data.MediumGoodsGanreName;

        //                this.MediumGoodsGanreName_tEdit.Tag = data.MediumGoodsGanreCode.ToString();
        //                this.MediumGoodsGanreName_tEdit.DataText = data.MediumGoodsGanreName;
        //            }
        //            else
        //            {
        //                para.MediumGoodsGanreCode = "";
        //                para.MediumGoodsGanreName = "";

        //                // >>>>> 2007.07.09 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        ////				this.MediumGoodsGanreName_tEdit.Tag = 0;
        //                this.MediumGoodsGanreName_tEdit.Tag = null;
        //                // <<<<< 2007.07.09 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        //                this.MediumGoodsGanreName_tEdit.DataText = string.Empty;
        //            }
        //        }
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        /// <summary>
        //        /// 商品区分詳細条件設定
        //        /// </summary>
        //        /// <param name="data">商品商品区分詳細クラス</param>
        //        /// <param name="para">検索条件クラス</param>
        //        /// <remarks>
        //        /// <br>Note		: データクラスから検索パラメータを設定します。</br>
        //        /// <br>Programmer	: 22018 鈴木 正臣</br>
        //        /// <br>Date		: 2007.09.10</br>
        //        /// </remarks>
        //        private void SetSearchParaFromDGoodsGanre ( DGoodsGanre data, ref StockSearchPara para )
        //        {
        //            if ( data != null ) {
        //                para.DetailGoodsGanreCode = data.DetailGoodsGanreCode;
        //                para.DetailGoodsGanreName = data.DetailGoodsGanreName;

        //                this.DetailGoodsGanreName_tEdit.Tag = data.DetailGoodsGanreCode.ToString();
        //                this.DetailGoodsGanreName_tEdit.DataText = data.DetailGoodsGanreName.TrimEnd();
        //            }
        //            else {
        //                para.DetailGoodsGanreCode = "";
        //                para.DetailGoodsGanreName = "";

        //                this.DetailGoodsGanreName_tEdit.Tag = null;
        //                this.DetailGoodsGanreName_tEdit.DataText = string.Empty;
        //            }
        //        }

        //        /// <summary>
        //        /// 自社分類コード条件設定
        //        /// </summary>
        //        /// <param name="userGdBd">ユーザーガイドクラス</param>
        //        /// <param name="para">検索条件クラス</param>
        //        /// <remarks>
        //        /// <br>Note		: データクラスから検索パラメータを設定します。</br>
        //        /// <br>Programmer	: 22018 鈴木 正臣</br>
        //        /// <br>Date		: 2007.09.10</br>
        //        /// </remarks>
        //        private void SetSearchParaFromEnterpriseGanre ( UserGdBd userGdBd, ref StockSearchPara para )
        //        {
        //            if ( userGdBd != null) {
        //                para.EnterpriseGanreCode = userGdBd.GuideCode;
        //                para.EnterpriseGanreName = userGdBd.GuideName;

        //                this.EnterpriseGanreCode_tEdit.Tag = userGdBd.GuideCode.ToString();
        //                this.EnterpriseGanreCode_tEdit.DataText = userGdBd.GuideName;
        //            }
        //            else {
        //                para.EnterpriseGanreCode = 0;
        //                para.EnterpriseGanreName = "";

        //                this.EnterpriseGanreCode_tEdit.Tag = null;
        //                this.EnterpriseGanreCode_tEdit.DataText = string.Empty;
        //            }
        //        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// 倉庫条件設定
        /// </summary>
        /// <param name="data">倉庫データ</param>
        /// <param name="para">検索条件クラス</param>
        /// <br>Update Note: 2009/09/07       汪千来</br>
        /// <br>           : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        private void SetSearchParaFromWarehouse(Warehouse data, ref StockSearchPara para)
        {
            if (data != null)
            {
                para.WarehouseCode = data.WarehouseCode;
                para.WarehouseName = data.WarehouseName;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                //this.tEdit_WarehouseCode.Text = data.WarehouseCode.PadLeft(4, '0');     // DEL 2009/09/07
                this.tEdit_WarehouseCode.Text = data.WarehouseCode.TrimEnd().PadLeft(4, '0');      // ADD 2009/09/07
                //this.tEdit_WarehouseCode.DataText = data.WarehouseCode;
                this.tEdit_WarehouseCode.Tag = data.WarehouseCode.PadLeft(4, '0');
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

                //this.uLabel_WarehouseName.Tag = data.WarehouseCode;
                this.uLabel_WarehouseName.Text = data.WarehouseName;
            }
            else
            {
                para.WarehouseCode = "";
                para.WarehouseName = "";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                this.tEdit_WarehouseCode.DataText = string.Empty;
                this.tEdit_WarehouseCode.Tag = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

                // >>>>> 2007.07.09 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                //this.uLabel_WarehouseName.Tag = 0;
                //this.uLabel_WarehouseName.Tag = string.Empty;
                // <<<<< 2007.07.09 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                this.uLabel_WarehouseName.Text = string.Empty;
            }
        }

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 得意先情報設定
        ///// </summary>
        ///// <param name="data">得意先情報データ</param>
        ///// <param name="para">検索条件クラス</param>
        //private void SetSearchParaFromCustomerInfo(CustomerInfo data, ref StockSearchPara para)
        //{
        //    if (data != null)
        //    {
        //        para.CustomerCode = data.CustomerCode;
        //        para.CustomerName = data.Name;

        //        this.tEdit_SupplierName.Tag = data.CustomerCode.ToString();
        //        this.tEdit_SupplierName.DataText = data.Name;
        //    }
        //    else
        //    {
        //        para.CustomerCode = 0;
        //        para.CustomerName = "";

        //        this.tEdit_SupplierName.Tag = 0;
        //        this.tEdit_SupplierName.DataText = string.Empty;
        //    }
        //}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
        // 仕入先情報はパラメータファイルから完全に削除された。
        // アクセスクラス内で絞り込みをする必要がある
        /// <summary>
        /// 仕入先情報設定
        /// </summary>
        /// <param name="data">仕入先情報データ</param>
        /// <param name="para">検索条件クラス</param>
        private void SetSearchParaFromSupplier(Supplier data, ref StockSearchPara para)
        {
            if (data != null)
            {
                //para.CustomerCode = data.SupplierCd;
                //para.CustomerName = data.SupplierNm1;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                this.tNedit_SupplierCd.Tag = data.SupplierCd.ToString();
                this.tNedit_SupplierCd.DataText = data.SupplierCd.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

                this.tEdit_SupplierName.Tag = data.SupplierCd.ToString();
                this.tEdit_SupplierName.DataText = data.SupplierNm1;
            }
            else
            {
                //para.CustomerCode = 0;
                //para.CustomerName = "";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                this.tNedit_SupplierCd.Tag = 0;
                this.tNedit_SupplierCd.DataText = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

                this.tEdit_SupplierName.Tag = 0;
                this.tEdit_SupplierName.DataText = string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 検索条件設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 検索パラメータより画面に設定します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.2</br>
        /// <br>Update Note : 2009/09/07       汪千来</br>
        /// <br>            : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// </remarks>
        private void SetSearchParameter(StockSearchPara stockSearchPara)
        {
            int status = 0;

            // 拠点コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //this.Section_ComboEditor.Value = stockSearchPara.SectionCode.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            //this.tEdit_SectionCode.DataText = stockSearchPara.SectionCode.Trim(); // DEL 2009/03/09
            //this.tEdit_SectionCode.Text = stockSearchPara.SectionCode.Trim().PadLeft(2, '0'); // ADD 2009/03/09 // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.Text = stockSearchPara.SectionCode.Trim().PadLeft(2, '0'); // ADD 2009/09/07
            //this.tEdit_SectionCode.Tag = stockSearchPara.SectionCode.Trim();   // DEL 2009/09/07
            this.tEdit_SectionCodeAllowZero.Tag = stockSearchPara.SectionCode.Trim();   // ADD 2009/09/07

            // 拠点名称取得
            if (stockSearchPara.SectionCode == "00")
            {
                this.uLabel_SectionNm.Text = "全社";
                this.uLabel_SectionNm.Tag = stockSearchPara.SectionCode.Trim();
            }
            else
            {
                if (!string.IsNullOrEmpty(stockSearchPara.SectionCode))
                {
                    SecInfoSet secInfo;
                    status = this._secInfoSetAcs.Read(out secInfo, this._enterpriseCode, stockSearchPara.SectionCode.Trim());
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.uLabel_SectionNm.Text = secInfo.SectionGuideSnm;
                        this.uLabel_SectionNm.Tag = stockSearchPara.SectionCode.Trim();
                    }
                    else
                    {
                        this.uLabel_SectionNm.Text = "";
                        this.uLabel_SectionNm.Tag = string.Empty;
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // メーカーコード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            this.tNedit_GoodsMakerCd.SetInt(stockSearchPara.GoodsMakerCd);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            this.tNedit_GoodsMakerCd.Tag = stockSearchPara.GoodsMakerCd.ToString();

            // メーカー名称取得
            if (stockSearchPara.GoodsMakerCd != 0)
            {
                MakerUMnt makerInfo;
                status = this._goodsAcs.GetMaker(this._enterpriseCode, stockSearchPara.GoodsMakerCd, out makerInfo);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
                //if (status == 0)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //stockSearchPara.MakerName = makerInfo.MakerName; // MakerNameというプロパティはなくなった
                    this.uLabel_MakerName.Text = makerInfo.MakerName.Trim();
                    this.uLabel_MakerName.Tag = stockSearchPara.GoodsMakerCd.ToString();
                }
                else
                {
                    this.uLabel_MakerName.Text = "";
                    this.uLabel_MakerName.Tag = string.Empty;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
            }

            // 商品コード
            this.tEdit_GoodsNo.DataText = stockSearchPara.GoodsNo;

            // 商品名称カナ
            this.GoodsNameKana_tEdit.DataText = stockSearchPara.GoodsNameKana;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //// 商品区分グループコード
            //this.LargeGoodsGanreName_tEdit.Tag = stockSearchPara.LargeGoodsGanreCode;

            //if ( !String.IsNullOrEmpty(stockSearchPara.LargeGoodsGanreCode) ) {

            //    LGoodsGanre lGoodsGanre;
            //    status = this._goodsAcs.GetLargeGoodsGanreCode(this._enterpriseCode, stockSearchPara.LargeGoodsGanreCode, out lGoodsGanre);
            //    if ( status == 0 )
            //        stockSearchPara.LargeGoodsGanreName = lGoodsGanre.LargeGoodsGanreName;
            //}
            //this.LargeGoodsGanreName_tEdit.DataText = stockSearchPara.LargeGoodsGanreName;


            //// 商品区分コード
            //this.MediumGoodsGanreName_tEdit.Tag = stockSearchPara.MediumGoodsGanreCode;
            //if ( !String.IsNullOrEmpty( stockSearchPara.MediumGoodsGanreCode ) ) {
            //    MGoodsGanre mGoodsGanre;
            //    status = this._goodsAcs.GetMediumGoodsGanreCode(this._enterpriseCode, stockSearchPara.MediumGoodsGanreCode, out mGoodsGanre);
            //    if ( status == 0 )
            //        stockSearchPara.MediumGoodsGanreName = mGoodsGanre.MediumGoodsGanreName;
            //}
            //this.MediumGoodsGanreName_tEdit.DataText = stockSearchPara.MediumGoodsGanreName;


            //// 商品区分詳細コード
            //this.DetailGoodsGanreName_tEdit.Tag = stockSearchPara.DetailGoodsGanreCode;
            //if ( !String.IsNullOrEmpty(stockSearchPara.DetailGoodsGanreCode) ) {
            //    DGoodsGanre dGoodsGanre;
            //    status = this._goodsAcs.GetDetailGoodsGanreCode(this._enterpriseCode, stockSearchPara.DetailGoodsGanreCode, out dGoodsGanre);
            //    if ( status == 0 )
            //        stockSearchPara.DetailGoodsGanreName = dGoodsGanre.DetailGoodsGanreName;
            //}
            //this.DetailGoodsGanreName_tEdit.DataText = stockSearchPara.DetailGoodsGanreName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // 倉庫コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            if (String.IsNullOrEmpty(stockSearchPara.WarehouseCode.Replace("0", "").Trim()))
            {
                this.tEdit_WarehouseCode.Text = string.Empty;
                this.tEdit_WarehouseCode.Tag = string.Empty;
            }
            else
            {
                this.tEdit_WarehouseCode.Text = stockSearchPara.WarehouseCode.PadLeft(4, '0');
                this.tEdit_WarehouseCode.Tag = stockSearchPara.WarehouseCode.PadLeft(4, '0');
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            if (!String.IsNullOrEmpty(stockSearchPara.WarehouseCode))
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
                string sectionCode = stockSearchPara.SectionCode;

                // 拠点コードがある場合のみ
                if (!string.IsNullOrEmpty(sectionCode))
                {
                    Warehouse warehouseInfo;
                    status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, sectionCode, stockSearchPara.WarehouseCode);
                    //if (status == 0)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // stockSearchPara.WarehouseName = warehouseInfo.WarehouseName;
                        this.uLabel_WarehouseName.Tag = stockSearchPara.WarehouseCode;
                        this.uLabel_WarehouseName.Text = warehouseInfo.WarehouseName.Trim();
                    }
                    else
                    {
                        this.uLabel_WarehouseName.Tag = string.Empty;
                        this.uLabel_WarehouseName.Text = "";
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
            }

            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 得意先コード
            //this.tEdit_SupplierName.Tag = stockSearchPara.CustomerCode.ToString();
            //if (stockSearchPara.CustomerCode != 0)
            //{
            //    CustomerInfo customerInfo;
            //    CustSuppli custSuppli;

            //    status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0,
            //        this._enterpriseCode, stockSearchPara.CustomerCode, false, out customerInfo, out custSuppli);
            //    if (status == 0)
            //    {
            //        stockSearchPara.CustomerName = customerInfo.Name;
            //    }
            //}
            //this.tEdit_SupplierName.DataText = stockSearchPara.CustomerName;

            // 仕入先コード
            // パラメータオブジェクトから仕入先コードは削除された
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //this.tEdit_SupplierName.Tag = stockSearchPara.CustomerCode.ToString();
            //if (stockSearchPara.CustomerCode != 0)
            //{
            //    Supplier supplier;
            //    status = this._supplierAcs.Read(out supplier, this._enterpriseCode, stockSearchPara.CustomerCode);

            //    if (status == 0)
            //    {
            //        stockSearchPara.CustomerName = supplier.SupplierNm1;
            //    }
            //}
            //this.tEdit_SupplierName.DataText = stockSearchPara.CustomerName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ゼロ在庫表示
            this.StockZero_tComboEditor.Value = stockSearchPara.ZeroStckDsp;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 前回情報退避
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            _prevHeaderInfo.SectionCode = stockSearchPara.SectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            _prevHeaderInfo.GoodsMakerCd = stockSearchPara.GoodsMakerCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //_prevHeaderInfo.MakerName = stockSearchPara.MakerName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
            _prevHeaderInfo.GoodsNo = stockSearchPara.GoodsNo;
            _prevHeaderInfo.GoodsName = stockSearchPara.GoodsName;
            _prevHeaderInfo.GoodsNameKana = stockSearchPara.GoodsNameKana;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            _prevHeaderInfo.GoodsNoSrchTyp = stockSearchPara.GoodsNoSrchTyp;
            _prevHeaderInfo.GoodsNameSrchTyp = stockSearchPara.GoodsNameSrchTyp;
            _prevHeaderInfo.GoodsNameKanaSrchTyp = stockSearchPara.GoodsNameKanaSrchTyp;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //_prevHeaderInfo.SupplierCode = stockSearchPara.CustomerCode;
            //_prevHeaderInfo.SupplierName = stockSearchPara.CustomerName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
            _prevHeaderInfo.BLGoodsCode = stockSearchPara.BLGoodsCode;
            _prevHeaderInfo.BLGoodsCodeName = stockSearchPara.BLGoodsName;
            _prevHeaderInfo.WarehouseCode = stockSearchPara.WarehouseCode;
            _prevHeaderInfo.WarehouseName = stockSearchPara.WarehouseName;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            _prevHeaderInfo.ZeroStockDsp = stockSearchPara.ZeroStckDsp;
            _prevHeaderInfo.WarehouseShelfNo = stockSearchPara.WarehouseShelfNo;
            _prevHeaderInfo.WarehouseShelfNoSrchTyp = stockSearchPara.WarehouseShelfNoSrchTyp;
            _prevHeaderInfo.DateDiv = stockSearchPara.DateDiv;
            _prevHeaderInfo.St_Date = stockSearchPara.St_Date;
            _prevHeaderInfo.Ed_Date = stockSearchPara.Ed_Date;
            _prevHeaderInfo.EnterpriseGanreCode = stockSearchPara.EnterpriseGanreCode;
            //// 以下の情報はパラメータにはないが画面上から取得して保存しておく(復元なのでなし)
            //_prevHeaderInfo.MakerName = this.uLabel_MakerName.Text;
            //_prevHeaderInfo.SupplierCode = int.Parse(this.tNedit_SupplierCd.Text.Trim());
            //_prevHeaderInfo.SupplierName = this.tEdit_SupplierName.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //_prevHeaderInfo.LargeGoodsGanreCode = stockSearchPara.LargeGoodsGanreCode;
            //_prevHeaderInfo.LargeGoodsGanreName = stockSearchPara.LargeGoodsGanreName;
            //_prevHeaderInfo.MediumGoodsGanreCode = stockSearchPara.MediumGoodsGanreCode;
            //_prevHeaderInfo.MediumGoodsGanreName = stockSearchPara.MediumGoodsGanreName;
            //_prevHeaderInfo.DetailGoodsGanreCode = stockSearchPara.DetailGoodsGanreCode;
            //_prevHeaderInfo.DetailGoodsGanreName = stockSearchPara.DetailGoodsGanreName;
            //_prevHeaderInfo.EnterpriseGanreCode = stockSearchPara.EnterpriseGanreCode;
            //_prevHeaderInfo.EnterpriseGanreName = stockSearchPara.EnterpriseGanreName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
        }

        /// <summary>
        /// 検索条件取得処理
        /// </summary>
        /// <returns>検索条件マスタ</returns>
        /// <remarks>
        /// <br>Note		: 画面から検索パラメータを取得します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.1.31</br>
        /// <br>Update Note : 2009/09/07       汪千来</br>
        /// <br>            : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// </remarks>
        private StockSearchPara GetSearchParameter()
        {
            StockSearchPara stockSearchPara = new StockSearchPara();

            // 企業コード
            stockSearchPara.EnterpriseCode = this._enterpriseCode;

            //// データ取得区分
            //stockSearchPara.DataAcqrDiv = 0;

            // 拠点コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            //if (this.Section_ComboEditor.Value != null)
            //    stockSearchPara.SectionCode = this.Section_ComboEditor.Value.ToString();
            //else
            //    stockSearchPara.SectionCode = string.Empty;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
            //stockSearchPara.SectionCode = this.tEdit_SectionCode.Text.Trim();    // DEL 2009/09/07
            stockSearchPara.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();      // ADD 2009/09/07
            if (stockSearchPara.SectionCode == "00")
            {
                stockSearchPara.SectionCode = string.Empty;
            }

            // メーカーコード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // ** Tagを使用する必要はなくなった? **
            stockSearchPara.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            //if (this.tNedit_GoodsMakerCd.Tag != null)
            //{
            //    stockSearchPara.GoodsMakerCd = TStrConv.StrToIntDef(this.tNedit_GoodsMakerCd.Tag.ToString(), 0);
            //    stockSearchPara.MakerName = this.tNedit_GoodsMakerCd.DataText;
            //}
            //else
            //{
            //    stockSearchPara.GoodsMakerCd = 0;
            //    stockSearchPara.MakerName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // 品番
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //stockSearchPara.GoodsNo = this.tEdit_GoodsNo.DataText;
            //stockSearchPara.GoodsNo = this.tEdit_GoodsNo.DataText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // 入力された文字列から曖昧検索条件を割り出す
            string goodsNo = this.tEdit_GoodsNo.DataText;
            int targetIndex = goodsNo.IndexOf("*");

            if (targetIndex == -1)
            {
                // 完全一致
                stockSearchPara.GoodsNoSrchTyp = 0;
                stockSearchPara.GoodsNo = goodsNo;
            }
            else if (goodsNo.StartsWith("*") && goodsNo.EndsWith("*"))
            {
                // 曖昧検索
                stockSearchPara.GoodsNoSrchTyp = 3;
                stockSearchPara.GoodsNo = goodsNo.Replace("*", "");
            }
            else if (goodsNo.EndsWith("*"))
            {
                // 前方一致
                stockSearchPara.GoodsNoSrchTyp = 1;
                stockSearchPara.GoodsNo = goodsNo.Replace("*", "");
            }
            else if (goodsNo.StartsWith("*"))
            {
                // 後方一致
                stockSearchPara.GoodsNoSrchTyp = 2;
                stockSearchPara.GoodsNo = goodsNo.Replace("*", "");
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // 商品名称カナ
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            //stockSearchPara.GoodsNameKana = this.GoodsNameKana_tEdit.DataText;
            // 入力された文字列から曖昧検索条件を割り出す
            string goodsNameKana = this.GoodsNameKana_tEdit.DataText;
            targetIndex = goodsNameKana.IndexOf("*");

            if (targetIndex == -1)
            {
                // 完全一致
                stockSearchPara.GoodsNameKanaSrchTyp = 0;
                stockSearchPara.GoodsNameKana = goodsNameKana;
            }
            else if (goodsNameKana.StartsWith("*") && goodsNameKana.EndsWith("*"))
            {
                // 曖昧検索
                stockSearchPara.GoodsNameKanaSrchTyp = 3;
                stockSearchPara.GoodsNameKana = goodsNameKana.Replace("*", "");
            }
            else if (goodsNameKana.EndsWith("*"))
            {
                // 前方一致
                stockSearchPara.GoodsNameKanaSrchTyp = 1;
                stockSearchPara.GoodsNameKana = goodsNameKana.Replace("*", "");
            }
            else if (goodsNameKana.StartsWith("*"))
            {
                // 後方一致
                stockSearchPara.GoodsNameKanaSrchTyp = 2;
                stockSearchPara.GoodsNameKana = goodsNameKana.Replace("*", "");
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 商品名称
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            //stockSearchPara.GoodsName = this.tEdit_GoodsName.DataText;
            // 入力された文字列から曖昧検索条件を割り出す
            string goodsName = this.tEdit_GoodsName.DataText;
            targetIndex = goodsName.IndexOf("*");

            if (targetIndex == -1)
            {
                // 完全一致
                stockSearchPara.GoodsNameSrchTyp = 0;
                stockSearchPara.GoodsName = goodsName;
            }
            else if (goodsName.StartsWith("*") && goodsName.EndsWith("*"))
            {
                // 曖昧検索
                stockSearchPara.GoodsNameSrchTyp = 3;
                stockSearchPara.GoodsName = goodsName.Replace("*", "");
            }
            else if (goodsName.EndsWith("*"))
            {
                // 前方一致
                stockSearchPara.GoodsNameSrchTyp = 1;
                stockSearchPara.GoodsName = goodsName.Replace("*", "");
            }
            else if (goodsName.StartsWith("*"))
            {
                // 後方一致
                stockSearchPara.GoodsNameSrchTyp = 2;
                stockSearchPara.GoodsName = goodsName.Replace("*", "");
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 機種コード
            //stockSearchPara.CellphoneModelCode = this.CellphoneModelCode_tEdit.DataText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //// 商品グループコード
            //if (this.LargeGoodsGanreName_tEdit.Tag != null)
            //{
            //    stockSearchPara.LargeGoodsGanreCode = this.LargeGoodsGanreName_tEdit.Tag.ToString();
            //    stockSearchPara.LargeGoodsGanreName = this.LargeGoodsGanreName_tEdit.DataText;
            //}
            //else
            //{
            //    stockSearchPara.LargeGoodsGanreCode = string.Empty;
            //    stockSearchPara.LargeGoodsGanreName = string.Empty;
            //}

            //// 商品区分コード
            //if (this.MediumGoodsGanreName_tEdit.Tag != null)
            //{
            //    stockSearchPara.MediumGoodsGanreCode = this.MediumGoodsGanreName_tEdit.Tag.ToString();
            //    stockSearchPara.MediumGoodsGanreName = this.MediumGoodsGanreName_tEdit.DataText;
            //}
            //else
            //{
            //    stockSearchPara.MediumGoodsGanreCode = string.Empty;
            //    stockSearchPara.MediumGoodsGanreName = string.Empty;
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 商品区分詳細コード
            //if ( this.DetailGoodsGanreName_tEdit.Tag != null ) {
            //    stockSearchPara.DetailGoodsGanreCode = this.DetailGoodsGanreName_tEdit.Tag.ToString();
            //    stockSearchPara.DetailGoodsGanreName = this.DetailGoodsGanreName_tEdit.DataText;
            //}
            //else {
            //    stockSearchPara.DetailGoodsGanreCode = string.Empty;
            //    stockSearchPara.DetailGoodsGanreName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // ＢＬ商品コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            stockSearchPara.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            stockSearchPara.BLGoodsName = this.tEdit_BLGoodsName.DataText.Trim();
            //if ( this.tEdit_BLGoodsName.Tag != null ) {
            //    stockSearchPara.BLGoodsCode = Broadleaf.Library.Text.TStrConv.StrToIntDef(this.tEdit_BLGoodsName.Tag.ToString(),0);
            //    stockSearchPara.BLGoodsName = this.tEdit_BLGoodsName.DataText;
            //}
            //else {
            //    stockSearchPara.BLGoodsCode = 0;
            //    stockSearchPara.BLGoodsName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            // 自社分類コード
            //if ( this.EnterpriseGanreCode_tEdit.Tag != null ) {
            //    stockSearchPara.EnterpriseGanreCode = Broadleaf.Library.Text.TStrConv.StrToIntDef(this.EnterpriseGanreCode_tEdit.Tag.ToString(), 0);
            //    stockSearchPara.EnterpriseGanreName = this.EnterpriseGanreCode_tEdit.DataText;
            //}
            //else {
            //    stockSearchPara.EnterpriseGanreCode = 0;
            //    stockSearchPara.EnterpriseGanreName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// キャリアコード
            //if (this.CarrierName_tEdit.Tag != null)
            //{
            //    stockSearchPara.CarrierCode = TStrConv.StrToIntDef(this.CarrierName_tEdit.Tag.ToString(), 0);
            //    stockSearchPara.CarrierName = this.CarrierName_tEdit.DataText;
            //}
            //else
            //{
            //    stockSearchPara.CarrierCode = 0;
            //    stockSearchPara.CarrierName = string.Empty;
            //}

            //// 事業者コード
            //if (this.CarrierEpName_tEdit.Tag != null)
            //{
            //    stockSearchPara.CarrierEpCode = TStrConv.StrToIntDef(this.CarrierEpName_tEdit.Tag.ToString(), 0);
            //    stockSearchPara.CarrierEpName = this.CarrierEpName_tEdit.DataText;
            //}
            //else
            //{
            //    stockSearchPara.CarrierEpCode = 0;
            //    stockSearchPara.CarrierEpName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 倉庫コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            //stockSearchPara.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();     // DEL 2009/09/07
            //stockSearchPara.WarehouseName = this.uLabel_WarehouseName.Text.Trim();    // DEL 2009/09/07
            // --- ADD 2009/09/07 ---------->>>>>
            if (!string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text))
            {
                stockSearchPara.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0');
                this.tEdit_WarehouseCode.Text = stockSearchPara.WarehouseCode;
                stockSearchPara.WarehouseName = this.uLabel_WarehouseName.Text.Trim();
            }
            else
            {
                stockSearchPara.WarehouseCode = string.Empty;
                stockSearchPara.WarehouseName = string.Empty;
            }
            // --- ADD 2009/09/07 ----------<<<<<
            //if (this.uLabel_WarehouseName.Tag != null)
            //{
            //    stockSearchPara.WarehouseCode = this.uLabel_WarehouseName.Tag.ToString();
            //    stockSearchPara.WarehouseName = this.uLabel_WarehouseName.DataText;
            //}
            //else
            //{
            //    stockSearchPara.WarehouseCode = string.Empty;
            //    stockSearchPara.WarehouseName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // 得意先コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //if (this.tEdit_SupplierName.Tag != null)
            //{
            //    stockSearchPara.CustomerCode = TStrConv.StrToIntDef(this.tEdit_SupplierName.Tag.ToString(), 0);
            //    stockSearchPara.CustomerName = this.tEdit_SupplierName.DataText;
            //}
            //else
            //{
            //    stockSearchPara.CustomerCode = 0;
            //    stockSearchPara.CustomerName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 製造番号
            //stockSearchPara.ProductNumber = this.ProductNumber_tEdit.DataText;

            //// 商品電話番号
            //stockSearchPara.StockTelNo = this.StockTelNo_tEdit.DataText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ゼロ在庫表示
            stockSearchPara.ZeroStckDsp = this.StrToIntDefOfValue(this.StockZero_tComboEditor.Value, 0);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 棚番
            // 入力された文字列から曖昧検索条件を割り出す
            string warehouseShelfNo = this.tEdit_WarehouseShelfNo.DataText;
            targetIndex = warehouseShelfNo.IndexOf("*");

            if (targetIndex == -1)
            {
                // 完全一致
                stockSearchPara.WarehouseShelfNoSrchTyp = 0;
                stockSearchPara.WarehouseShelfNo = warehouseShelfNo;
            }
            else if (warehouseShelfNo.StartsWith("*") && warehouseShelfNo.EndsWith("*"))
            {
                // 曖昧検索
                stockSearchPara.WarehouseShelfNoSrchTyp = 3;
                stockSearchPara.WarehouseShelfNo = warehouseShelfNo.Replace("*", "");
            }
            else if (warehouseShelfNo.EndsWith("*"))
            {
                // 前方一致
                stockSearchPara.WarehouseShelfNoSrchTyp = 1;
                stockSearchPara.WarehouseShelfNo = warehouseShelfNo.Replace("*", "");
            }
            else if (warehouseShelfNo.StartsWith("*"))
            {
                // 後方一致
                stockSearchPara.WarehouseShelfNoSrchTyp = 2;
                stockSearchPara.WarehouseShelfNo = warehouseShelfNo.Replace("*", "");
            }

            // 仕入コード
            stockSearchPara.SupplierCd = this.tNedit_SupplierCd.GetInt();

            // --- ADD 2012/09/26 ---------->>>>>
            // 仕入先コード
            this._paraSupplierCd = this.tNedit_SupplierCd.GetInt();
            // --- ADD 2012/09/26 ----------<<<<<

            // 対象日付区分
            stockSearchPara.DateDiv = int.Parse(this.tComboEditor_DateDiv.SelectedItem.DataValue.ToString());
            // 開始対象日付
            stockSearchPara.St_Date = this.tDateEdit_Date1Start.GetLongDate();
            // 終了対象日付
            stockSearchPara.Ed_Date = this.tDateEdit_Date1End.GetLongDate();

            // 自社分類コード(UIからは消えたがパラメータには残っている：0固定)
            stockSearchPara.EnterpriseGanreCode = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            return stockSearchPara;
        }

        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <param name="control">クリア対象外にするコントロールの名称</param>
        /// <param name="stockSearchPara">検索条件クラス</param>
        /// <remarks>
        /// <br>Note		: 入力項目をクリアします。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.01.31</br>
        /// <br>Update Note : 2009/09/07       汪千来</br>
        /// <br>            : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// </remarks>
        private int ClearControlBeforeSearch(Control control, StockSearchPara stockSearchPara)
        {
            if (control is TNedit)
            {
                Broadleaf.Library.Windows.Forms.TNedit tNedit = (Broadleaf.Library.Windows.Forms.TNedit)control;
                if (tNedit.GetInt().Equals(0)) return -1;
            }
            else if (control is TEdit)
            {
                Broadleaf.Library.Windows.Forms.TEdit tEdit = (Broadleaf.Library.Windows.Forms.TEdit)control;
                if (tEdit.Text.Equals(string.Empty)) return -1;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 拠点
            //if (!control.Equals(this.tEdit_SectionCode))      // DEL 2009/09/07
            if (!control.Equals(this.tEdit_SectionCodeAllowZero))   // ADD 2009/09/07
            {
                //this.tEdit_SectionCode.Clear();    // DEL 2009/09/07
                this.tEdit_SectionCodeAllowZero.Clear();    // ADD 2009/09/07
                this.uLabel_SectionNm.Text = "";
                stockSearchPara.SectionCode = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // 倉庫
            if (!control.Equals(this.tEdit_WarehouseCode))
            {
                this.tEdit_WarehouseCode.Clear();
                this.uLabel_WarehouseName.Text = "";
                //this.uLabel_WarehouseName.Tag = null;
                //this.tEdit_WarehouseCode.Tag = string.Empty;

                stockSearchPara.WarehouseCode = string.Empty;
                stockSearchPara.WarehouseName = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 棚番
            if (!control.Equals(this.tEdit_WarehouseShelfNo))
            {
                this.tEdit_WarehouseShelfNo.Clear();

                stockSearchPara.WarehouseShelfNo = string.Empty;
                stockSearchPara.WarehouseShelfNoSrchTyp = 0;
            }

            // ゼロ在庫表示
            if (!control.Equals(this.StockZero_tComboEditor))
            {
                this.StockZero_tComboEditor.SelectedIndex = 0;
                stockSearchPara.ZeroStckDsp = 0;
            }

            // ---ADD 2009/04/02 不具合対応[12838] --------------------------->>>>>
            // 表示順
            if (!control.Equals(this.SortDiv_tComboEditor))
            {
                this.SortDiv_tComboEditor.SelectedIndex = 0;
            }
            // ---ADD 2009/04/02 不具合対応[12838] ---------------------------<<<<<

            // 対象日付区分
            if (!control.Equals(this.tComboEditor_DateDiv))
            {
                this.tComboEditor_DateDiv.SelectedIndex = 0;
                stockSearchPara.DateDiv = 0;
            }

            // 開始対象日付
            if (!control.Equals(this.tDateEdit_Date1Start))
            {
                this.tDateEdit_Date1Start.Clear();
                stockSearchPara.St_Date = 0;
            }

            // 終了対象日付
            if (!control.Equals(this.tDateEdit_Date1End))
            {
                this.tDateEdit_Date1End.Clear();
                stockSearchPara.Ed_Date = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // メーカー
            if (!control.Equals(this.tNedit_GoodsMakerCd))
            {
                this.tNedit_GoodsMakerCd.Clear();
                this.uLabel_MakerName.Text = "";
                //this.tNedit_GoodsMakerCd.Tag = null;
                //this.tNedit_GoodsMakerCd.Tag = string.Empty;

                stockSearchPara.GoodsMakerCd = 0;
                //stockSearchPara.MakerName = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// キャリア
            //if (!control.Equals(this.CarrierName_tEdit))
            //{
            //    this.CarrierName_tEdit.Clear();
            //    this.CarrierName_tEdit.Tag = null;

            //    stockSearchPara.CarrierCode = 0;
            //    stockSearchPara.CarrierName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // 品番
            if (!control.Equals(this.tEdit_GoodsNo))
            {
                this.tEdit_GoodsNo.Clear();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //stockSearchPara.GoodsNo = string.Empty;
                stockSearchPara.GoodsNo = string.Empty;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                stockSearchPara.GoodsNoSrchTyp = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            // 品名
            if (!control.Equals(this.tEdit_GoodsName))
            {
                this.tEdit_GoodsName.Clear();

                stockSearchPara.GoodsName = string.Empty;
                stockSearchPara.GoodsNameSrchTyp = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            // 品名カナ
            if (!control.Equals(this.GoodsNameKana_tEdit))
            {
                this.GoodsNameKana_tEdit.Clear();

                stockSearchPara.GoodsNameKana = string.Empty;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                stockSearchPara.GoodsNameKanaSrchTyp = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 機種
            //if (!control.Equals(this.CellphoneModelCode_tEdit))
            //{
            //    this.CellphoneModelCode_tEdit.Clear();
            //    stockSearchPara.CellphoneModelCode = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 仕入先
            if (!control.Equals(this.tNedit_SupplierCd))
            {
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();

                // this.tEdit_SupplierName.Tag = null;
                //this.tEdit_SupplierName.Tag = string.Empty;
                //stockSearchPara.CustomerCode = 0;
                //stockSearchPara.CustomerName = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 事業者
            //if (!control.Equals(this.CarrierEpName_tEdit))
            //{
            //    this.CarrierEpName_tEdit.Clear();
            //    this.CarrierEpName_tEdit.Tag = null;

            //    stockSearchPara.CarrierEpCode = 0;
            //    stockSearchPara.CarrierEpName = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 製造番号
            //if (!control.Equals(this.ProductNumber_tEdit))
            //{
            //    this.ProductNumber_tEdit.Clear();
            //    stockSearchPara.ProductNumber = string.Empty;
            //}
            //// 電話番号
            //if (!control.Equals(this.StockTelNo_tEdit))
            //{
            //    this.StockTelNo_tEdit.Clear();
            //    stockSearchPara.StockTelNo = string.Empty;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
            //// 商品商品グループ
            //if (!control.Equals(this.LargeGoodsGanreName_tEdit))
            //{
            //    this.LargeGoodsGanreName_tEdit.Clear();
            //    //this.LargeGoodsGanreName_tEdit.Tag = null;
            //    this.LargeGoodsGanreName_tEdit.Tag = string.Empty;

            //    stockSearchPara.LargeGoodsGanreCode = string.Empty;
            //    stockSearchPara.LargeGoodsGanreName = string.Empty;
            //}
            //// 商品商品区分
            //if (!control.Equals(this.MediumGoodsGanreName_tEdit))
            //{
            //    this.MediumGoodsGanreName_tEdit.Clear();
            //    //this.MediumGoodsGanreName_tEdit.Tag = null;
            //    this.MediumGoodsGanreName_tEdit.Tag = string.Empty;

            //    stockSearchPara.MediumGoodsGanreCode = string.Empty;
            //    stockSearchPara.MediumGoodsGanreName = string.Empty;
            //}
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 商品区分詳細
            //if ( !control.Equals( this.DetailGoodsGanreName_tEdit ) )
            //{
            //    this.DetailGoodsGanreName_tEdit.Clear();
            //    this.DetailGoodsGanreName_tEdit.Tag = string.Empty;

            //    stockSearchPara.DetailGoodsGanreCode = string.Empty;
            //    stockSearchPara.DetailGoodsGanreName = string.Empty;
            //}
            // 自社分類
            //if ( !control.Equals( this.EnterpriseGanreCode_tEdit ) )
            //{
            //    this.EnterpriseGanreCode_tEdit.Clear();
            //    this.EnterpriseGanreCode_tEdit.Tag = string.Empty;

            //    stockSearchPara.EnterpriseGanreCode = 0;
            //    stockSearchPara.EnterpriseGanreName = string.Empty;
            //}
            stockSearchPara.EnterpriseGanreCode = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END

            // ＢＬ商品コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            if (!control.Equals(this.tNedit_BLGoodsCode))
            {
                this.tNedit_BLGoodsCode.Clear();
                this.tEdit_BLGoodsName.Clear();
                //this.tEdit_BLGoodsName.Tag = string.Empty;

                stockSearchPara.BLGoodsCode = 0;
                stockSearchPara.BLGoodsName = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END

            // ※前回情報にセット
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
            _prevHeaderInfo.SectionCode = stockSearchPara.SectionCode;
            _prevHeaderInfo.GoodsNoSrchTyp = stockSearchPara.GoodsNoSrchTyp;
            _prevHeaderInfo.GoodsNameSrchTyp = stockSearchPara.GoodsNameSrchTyp;
            _prevHeaderInfo.GoodsNameKanaSrchTyp = stockSearchPara.GoodsNameKanaSrchTyp;
            _prevHeaderInfo.ZeroStockDsp = stockSearchPara.ZeroStckDsp;
            _prevHeaderInfo.WarehouseShelfNo = stockSearchPara.WarehouseShelfNo;
            _prevHeaderInfo.WarehouseShelfNoSrchTyp = stockSearchPara.WarehouseShelfNoSrchTyp;
            _prevHeaderInfo.DateDiv = stockSearchPara.DateDiv;
            _prevHeaderInfo.St_Date = stockSearchPara.St_Date;
            _prevHeaderInfo.Ed_Date = stockSearchPara.Ed_Date;
            _prevHeaderInfo.EnterpriseGanreCode = stockSearchPara.EnterpriseGanreCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END

            _prevHeaderInfo.WarehouseCode = stockSearchPara.WarehouseCode;
            _prevHeaderInfo.WarehouseName = stockSearchPara.WarehouseName;
            _prevHeaderInfo.GoodsMakerCd = stockSearchPara.GoodsMakerCd;
            //_prevHeaderInfo.MakerName = stockSearchPara.MakerName;
            _prevHeaderInfo.GoodsNo = stockSearchPara.GoodsNo;
            _prevHeaderInfo.GoodsName = stockSearchPara.GoodsName;
            _prevHeaderInfo.GoodsNameKana = stockSearchPara.GoodsNameKana;
            //_prevHeaderInfo.SupplierCode = stockSearchPara.CustomerCode;
            //_prevHeaderInfo.SupplierName = stockSearchPara.CustomerName;
            _prevHeaderInfo.BLGoodsCode = stockSearchPara.BLGoodsCode;
            _prevHeaderInfo.BLGoodsCodeName = stockSearchPara.BLGoodsName;
            _prevHeaderInfo.EnterpriseGanreCode = stockSearchPara.EnterpriseGanreCode;

            //_prevHeaderInfo.LargeGoodsGanreCode = stockSearchPara.LargeGoodsGanreCode;
            //_prevHeaderInfo.LargeGoodsGanreName = stockSearchPara.LargeGoodsGanreName;
            //_prevHeaderInfo.MediumGoodsGanreCode = stockSearchPara.MediumGoodsGanreCode;
            //_prevHeaderInfo.MediumGoodsGanreName = stockSearchPara.MediumGoodsGanreName;
            //_prevHeaderInfo.DetailGoodsGanreCode = stockSearchPara.DetailGoodsGanreCode;
            //_prevHeaderInfo.DetailGoodsGanreName = stockSearchPara.DetailGoodsGanreName;
            //_prevHeaderInfo.EnterpriseGanreName = stockSearchPara.EnterpriseGanreName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return 0;
        }

        /// <summary>
        /// 検索前チェック処理
        /// </summary>
        /// <param name="sender">トリガーを引いたコントロール</param>
        /// <param name="stockSearchPara">検索条件クラス</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note		: 検索前のチェックを行います。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.1.31</br>
        /// </remarks>
        private bool CheckBeforeSearch(object sender, StockSearchPara stockSearchPara)
        {
            // 複数条件指定ではない場合
            if (!(sender is Infragistics.Win.Misc.UltraButton))
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // エラー発生を防ぐ為、Nullは補正

                // (指定条件)
                if (stockSearchPara.SectionCode == null) stockSearchPara.SectionCode = string.Empty;
                if (stockSearchPara.GoodsNo == null) stockSearchPara.GoodsNo = string.Empty;
                if (stockSearchPara.GoodsNameKana == null) stockSearchPara.GoodsNameKana = string.Empty;
                if (stockSearchPara.WarehouseCode == null) stockSearchPara.WarehouseCode = string.Empty;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                if (stockSearchPara.GoodsName == null) stockSearchPara.GoodsName = string.Empty;
                if (stockSearchPara.WarehouseShelfNo == null) stockSearchPara.WarehouseShelfNo = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
                //if ( stockSearchPara.LargeGoodsGanreCode == null ) stockSearchPara.LargeGoodsGanreCode = string.Empty;
                //if ( stockSearchPara.MediumGoodsGanreCode == null ) stockSearchPara.MediumGoodsGanreCode = string.Empty;
                //if ( stockSearchPara.DetailGoodsGanreCode == null ) stockSearchPara.DetailGoodsGanreCode = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
                if (stockSearchPara.EnterpriseCode == null) stockSearchPara.EnterpriseCode = string.Empty;

                // (前回条件)
                if (_prevSearchParam.SectionCode == null) _prevSearchParam.SectionCode = string.Empty;
                if (_prevSearchParam.GoodsNo == null) _prevSearchParam.GoodsNo = string.Empty;
                if (_prevSearchParam.GoodsNameKana == null) _prevSearchParam.GoodsNameKana = string.Empty;
                if (_prevSearchParam.WarehouseCode == null) _prevSearchParam.WarehouseCode = string.Empty;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                if (_prevSearchParam.GoodsName == null) _prevSearchParam.GoodsName = string.Empty;
                if (_prevSearchParam.WarehouseShelfNo == null) _prevSearchParam.WarehouseShelfNo = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA DEL START
                //if ( _prevSearchParam.LargeGoodsGanreCode == null ) _prevSearchParam.LargeGoodsGanreCode = string.Empty;
                //if ( _prevSearchParam.MediumGoodsGanreCode == null ) _prevSearchParam.MediumGoodsGanreCode = string.Empty;
                //if ( _prevSearchParam.DetailGoodsGanreCode == null ) _prevSearchParam.DetailGoodsGanreCode = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA DEL END
                if (_prevSearchParam.EnterpriseCode == null) _prevSearchParam.EnterpriseCode = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //// 検索条件が初期状態ではないかチェック
                // 必須条件がなくなったため不要
                //if ( (stockSearchPara.SectionCode.Trim().Equals( string.Empty )) &&
                //    (stockSearchPara.GoodsNo.Trim().Equals( string.Empty )) &&
                //    (stockSearchPara.GoodsNameKana.Trim().Equals( string.Empty )) &&
                //    (stockSearchPara.WarehouseCode.Trim().Equals( string.Empty )) &&
                //    //(stockSearchPara.CustomerCode.Equals( 0 )) &&
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                //    (stockSearchPara.GoodsName.Trim().Equals(string.Empty)) &&
                //    (stockSearchPara.BLGoodsCode.Equals( 0 )) &&
                //    //(stockSearchPara.ZeroStckDsp.Equals(0)) &&
                //    //(stockSearchPara.DateDiv.Equals(0)) &&
                //    (stockSearchPara.St_Date.Equals(0)) &&
                //    (stockSearchPara.Ed_Date.Equals(0)) &&
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
                //    (stockSearchPara.GoodsMakerCd.Equals( 0 )) )//&&
                //    //(stockSearchPara.LargeGoodsGanreCode.Equals( string.Empty )) &&
                //    //(stockSearchPara.MediumGoodsGanreCode.Equals( string.Empty )) &&
                //    //(stockSearchPara.DetailGoodsGanreCode.Equals( string.Empty)) )
                //{
                //    return false;
                //}

                // 検索条件が変更されているかチェック
                // 検索条件が初期状態ではないかチェック
                if (!this._cleared)  // クリアされた初回は常に検索
                {
                    if ((stockSearchPara.SectionCode.Trim().Equals(this._prevSearchParam.SectionCode.Trim())) &&
                        (stockSearchPara.GoodsNo.Trim().Equals(this._prevSearchParam.GoodsNo.Trim())) &&
                        (stockSearchPara.GoodsNameKana.Trim().Equals(this._prevSearchParam.GoodsNameKana.Trim())) &&
                        (stockSearchPara.WarehouseCode.Trim().Equals(this._prevSearchParam.WarehouseCode.Trim())) &&
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA ADD START
                        (stockSearchPara.BLGoodsCode.Equals(this._prevSearchParam.BLGoodsCode)) &&
                        (stockSearchPara.GoodsName.Trim().Equals(this._prevSearchParam.GoodsName.Trim())) &&
                        (stockSearchPara.WarehouseShelfNo.Trim().Equals(this._prevSearchParam.WarehouseShelfNo.Trim())) &&
                        (stockSearchPara.ZeroStckDsp.Equals(this._prevSearchParam.ZeroStckDsp)) &&
                        (stockSearchPara.DateDiv.Equals(this._prevSearchParam.DateDiv)) &&
                        (stockSearchPara.St_Date.Equals(this._prevSearchParam.St_Date)) &&
                        (stockSearchPara.Ed_Date.Equals(this._prevSearchParam.Ed_Date)) &&
                        (stockSearchPara.SupplierCd.Equals(this._prevSearchParam.SupplierCd)) &&
                        ((int)this.SortDiv_tComboEditor.Value == this._prevSortDiv) &&                  //ADD 2009/04/02 不具合対応[12838] 
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA ADD END
                        //(stockSearchPara.CustomerCode.Equals(this._prevSearchParam.CustomerCode)) &&
                        (stockSearchPara.GoodsMakerCd.Equals(this._prevSearchParam.GoodsMakerCd)))//&&
                    //(stockSearchPara.LargeGoodsGanreCode.Equals(this._prevSearchParam.LargeGoodsGanreCode)) &&
                    //(stockSearchPara.MediumGoodsGanreCode.Equals(this._prevSearchParam.MediumGoodsGanreCode)))
                    {
                        return false;
                    }
                }
                else
                {
                    this._cleared = false;
                }
            }

            return true;
        }

        #endregion

        // --------------------------------------------------
        #region < 検索処理 >

        /// <summary>
        /// 検索メイン処理
        /// </summary>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note		: 検索のメイン処理です。</br>
        /// <br>Programmer	: 18012 Y.Saaski</br>
        /// <br>Date		: 2007.1.31</br>
        /// </remarks>
        private int SearchMainProc(Control ctrl)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 検索条件取得
            StockSearchPara searchPara = this.GetSearchParameter();

            // 検索条件はすべて有効
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.04 TOKUNAGA MODIFY START
            // 現在アクティブとなっている条件以外削除
            //if (this.ClearControlBeforeSearch(ctrl, searchPara) == 0)
            //{
            //if (this.CheckBeforeSearch(ctrl, searchPara)) // T.Nishi 2012/04/10 DEL
            //{ // T.Nishi 2012/04/10 DEL
                status = this.SearchMainProc(searchPara);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.gridResult.Focus();
                            this.gridResult.Rows[0].Activate();
                            this.gridResult.Rows[0].Selected = true; ;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            this.ultraStatusBar.Focus();
                            break;
                        }
                }
            //} // T.Nishi 2012/04/10 DEL
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.04 TOKUNAGA MODIFY END


            return status;

        }

        /// <summary>
        /// 検索メイン処理
        /// </summary>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note		: 検索のメイン処理です。</br>
        /// <br>Programmer	: 18012 Y.Saaski</br>
        /// <br>Date		: 2007.1.31</br>
        /// <br>UpdateNote : 2011/07/07       王飛３ </br>
        /// <br>           : 管理No.17501   在庫照会の抽出中の中断機能が欲しい </br>
        /// </remarks>
        private int SearchMainProc(StockSearchPara searchPara)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
            while (StockAcsThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            System.Windows.Forms.Application.DoEvents();

            //// 共通処理中画面生成
            //SFCMN00299CA progressForm = new SFCMN00299CA();
            //progressForm.DispCancelButton = false;
            //progressForm.Title = "データ抽出中";
            //progressForm.Message = "現在、データ抽出中です．．．";

            // --- UPD 2011/07/07 ----->>>>>
            // 共通処理中画面生成
            //_processingDialog = new SFCMN00299CA(); // T.Nishi 2012/04/10 DEL
            // --- UPD 2011/07/07 -----<<<<<

            try
            {
                //progressForm.Show(this); // DEL 2011/07/07 


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 在庫状態、移動状態、商品状態の固定設定項目を設定する
                //// 在庫状態
                //if (this._defStockState != null && this._defStockState.Length > 0)
                //{
                //    sarchPara.StockState = new Int32[this._defStockState.Length];
                //    this._defStockState.CopyTo(sarchPara.StockState, 0);
                //}
                //else
                //{
                //    sarchPara.StockState = new Int32[0];
                //}

                //// 移動状態状態
                //if (sarchPara.MoveStatus != null && this._defMoveStatus.Length > 0)
                //{
                //    sarchPara.MoveStatus = new Int32[this._defMoveStatus.Length];
                //    this._defMoveStatus.CopyTo(sarchPara.MoveStatus, 0);
                //}
                //else
                //{
                //    sarchPara.MoveStatus = new Int32[0];
                //}

                //// 商品状態
                //if (sarchPara.GoodsCodeStatus != null && this._defGoodsCodeStatus.Length > 0)
                //{
                //    sarchPara.GoodsCodeStatus = new Int32[this._defGoodsCodeStatus.Length];
                //    this._defGoodsCodeStatus.CopyTo(sarchPara.GoodsCodeStatus, 0);
                //}
                //else
                //{
                //    sarchPara.GoodsCodeStatus = new Int32[0];
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 製造番号検索区分
                //sarchPara.ProductNumberSrchDivCd = this._defProductNumberSrchDivCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 今回の検索条件を保持
                this._prevSearchParam = searchPara.Clone();

                // 検索処理

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 検索モード設定
                //switch (this._searchMode)
                //{
                //    // 商品
                //    case (int)emSearchMode.Goods:
                //        sarchPara.DataAcqrDiv = 3;
                //        break;
                //    // 商品在庫
                //    // 商品在庫製番
                //    case (int)emSearchMode.GoodsStock:
                //        sarchPara.DataAcqrDiv = 1;
                //        break;
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //    //case (int)emSearchMode.Stock:
                //    //    sarchPara.DataAcqrDiv = 0;
                //    //    break;
                //    //// 製番
                //    //case (int)emSearchMode.Product:
                //    //    sarchPara.DataAcqrDiv = 2;
                //    //    break;
                //    //case (int)emSearchMode.ProductwitchStock:
                //    //    sarchPara.DataAcqrDiv = 0;
                //    //    break;

                //    case ( int ) emSearchMode.Stock:
                //        sarchPara.DataAcqrDiv = 0;
                //        break;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //// 検索処理
                //string msg;
                //List<StockExpansion> retStockList;
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////List<ProductStock> retProductList;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////status = this._searchStockAcs.Search(sarchPara, out retStockList, out retProductList, out msg);
                //status = this._searchStockAcs.Search(searchPara, out retStockList, out msg);
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // --- ADD 2011/07/07 ----->>>>>
                // 検索処理
                string msg = "";
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                // 抽出結果をクリア
                this._stockDataTable.Rows.Clear();
                this._stockDataView.Table = this._stockDataTable;

                // 合計金額をクリア
                this.uLabel_TotalStockCount.Text = "0.00";
                this.uLabel_TotalStockValue.Text = "\\0";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD
                List<StockExpansion> retStockList = null;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                gtotalStockCount = 0;
                gtotalStockValue = 0;
                growCount = 0;
                gMaxCount = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

                // --- ADD 2012/09/26 ---------->>>>>
                // ラベルを非表示
                this.progressBar1.Visible = false;
                this.ultraLabel1.Visible = false;
                this.ultraLabel2.Visible = false;
                // --- ADD 2012/09/26 ----------<<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 UPD
                //status = this._searchStockAcs.StopSearch(searchPara, out retStockList, out msg, ref _processingDialog);
                status = this.StopSearch2(searchPara, out retStockList, out msg);

                if (_extractCancelFlag == true)
                {
                    return status;
                }

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 UPD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                //if (_searchStockAcs.ExtractCancelFlag == true)
                //{
                //    _processingDialog.Close();
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                //        "処理を中断しました。",
                //        status, MessageBoxButtons.OK);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
                // --- ADD 2011/07/07 -----<<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                //// 抽出結果をクリア
                //this._stockDataTable.Rows.Clear();
                //this._stockDataView.Table = this._stockDataTable;       //ADD 2009/05/26 不具合対応[13389]

                //// 合計金額をクリア
                //this.uLabel_TotalStockCount.Text = "0.00";
                //this.uLabel_TotalStockValue.Text = "\\0";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this._productStockDataTable.Rows.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 共通処理中画面終了
                //progressForm.Close();//DEL 2011/07/07
                //_processingDialog.Close();// ADD 2011/07/07  // T.Nishi 2012/04/10 DEL
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            //// 抽出結果を保持
                            //bool isWarningMsg = false;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                            // 検索モード設定
                            //status = this.SetStockDataTable(retStockList, out msg);
                            //switch (status)
                            //{
                            //    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            //        break;
                            //    case (int)ConstantManagement.MethodResult.ctFNC_WARNING:
                            //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            //        //isWarningMsg = true;
                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                            //        break;
                            //    default:
                            //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, 0, MessageBoxButtons.OK);
                            //        break;

                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                            // 合計行を追加
                            this.uLabel_TotalStockCount.Text = string.Format("{0:###,###,##0.00}", gtotalStockCount);        // 在庫合計数
                            this.uLabel_TotalStockValue.Text = "\\" + string.Format("{0:###,###,##0}", gtotalStockValue);      // 在庫金額

                            // 大文字小文字区別
                            this._stockDataView.Table.CaseSensitive = true;

                            // 表示順に従ってソート
                            this.SetGridSort();

                            // No.振り直し
                            DataTable dt = this._stockDataView.ToTable();
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                dt.Rows[i][CT_RowNo] = i + 1;
                            }

                            this._stockDataView.Table = dt;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            //status = this.SetProductStockDataTable(retProductList, out msg);
                            //switch (status)
                            //{
                            //    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                            //        break;
                            //    case (int)ConstantManagement.MethodResult.ctFNC_WARNING:
                            //        if (!isWarningMsg)
                            //            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
                            //        break;
                            //    default:
                            //        if (!isWarningMsg)
                            //            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, 0, MessageBoxButtons.OK);
                            //        break;

                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            this.ColReSize_Timer.Enabled = true;

                            // 検索モードにより該当件数の有無を判定する
                            switch (this._searchMode)
                            {
                                // 商品
                                case (int)emSearchMode.Goods:
                                    break;
                                // 商品在庫
                                // 商品在庫製番
                                case (int)emSearchMode.GoodsStock:
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                //case (int)emSearchMode.Stock:
                                case (int)emSearchMode.Stock:
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                    {
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                        //if (this._stockDataView.Count == 0 && this._productStockDataView.Count == 0)
                                        if (this._stockDataView.Count == 0)
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                        {
                                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, "該当するデータが見つかりませんでした。", 0, MessageBoxButtons.OK);
                                        }
                                        else
                                        {
                                            // 倉庫指定がされているとき
                                            if (!searchPara.WarehouseCode.Equals(string.Empty))
                                            {
                                                // 在庫情報再更新
                                                this.CalculationStockByWarehouse();
                                            }
                                            this.gridResult.Focus();// ADD 2011/07/07
                                        }
                                        break;
                                    }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                //// 製番
                                //case (int)emSearchMode.Product:
                                //case (int)emSearchMode.ProductwitchStock:
                                //    if (this._productStockDataView.Count == 0)
                                //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, "該当するデータが見つかりませんでした。", 0, MessageBoxButtons.OK);
                                //    break;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                            }

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                            gMaxCount = retStockList.Count;
                            progressBar1.Maximum = gMaxCount;

                            Infragistics.Win.UltraWinToolbars.ButtonTool undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo];
                            Infragistics.Win.UltraWinToolbars.ButtonTool pauseButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Pause];
                            Infragistics.Win.UltraWinToolbars.ButtonTool popUndoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_PopUndo];
                            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search];
                            Infragistics.Win.UltraWinToolbars.ButtonTool stopButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Stop];

                            undoButton.SharedProps.Enabled = true;
                            pauseButton.SharedProps.Enabled = false;
                            searchButton.SharedProps.Visible = true;
                            stopButton.SharedProps.Visible = false;
                            popUndoButton.SharedProps.Enabled = true;
                            this.setItemsEnable(true);

                            if (_searchStockAcs.ExtractCancelFlag == true)
                            {
                                ultraLabel1.Text = "データ抽出が中断しました。";
                            }
                            else
                            {
                            ultraLabel1.Text = "データ抽出が終了しました。";
                            }
                            ultraLabel2.Text = growCount.ToString() + "件";
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            if (_searchStockAcs.ExtractCancelFlag == false)
                            {
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, "該当するデータが見つかりませんでした。", 0, MessageBoxButtons.OK);
                            }
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, status, MessageBoxButtons.OK);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, status, MessageBoxButtons.OK);
            }
            finally
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 共通処理中画面終了
                //progressForm.Close();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

            return status;
        }

        // --- ADD 2011/07/07 ----->>>>>t
        /// <summary>
        /// 中断ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processingDialog_CancelButtonClick(object sender, EventArgs e)
        {
            // 抽出キャンセル
            CancelExtract();
        }
        /// <summary>
        /// 抽出キャンセル
        /// </summary>
        private void CancelExtract()
        {
            // 抽出キャンセル
            _searchStockAcs.ExtractCancelFlag = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
            //if (_processingDialog != null)
            //{
                //_processingDialog.Message = "中断します。";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
        }
        // --- ADD 2011/07/07 -----<<<<<

        /// <summary>
        /// 在庫データテーブル設定処理
        /// </summary>
        /// <param name="stockList">在庫クラスリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        private int SetStockDataTable(List<StockExpansion> stockList, out string msg)
        //private int SetStockDataTable(List<Stock> stockList, out string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            msg = "";

            if (stockList == null) return 0;
            if (stockList.Count == 0) return 0;

            double totalStockCount = 0;
            long totalStockValue = 0;
            int rowCount = 1;

            this._stockDataTable.BeginLoadData();

            try
            {
                foreach (StockExpansion stockEx in stockList)
                //foreach (Stock stockEx in stockList)
                {

                    if (this._stockDataTable.Rows.Count >= CT_MaxRowCount)
                    {
                        msg = "表示最大行数になりました。検索条件を絞って検索して下さい";
                        status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                        return status;
                    }

                    DataRow row = this._stockDataTable.NewRow();

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 列選択
                    //row[CT_ProductButton] = "詳細";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA DEL START
                    // 行No
                    //row[CT_RowNo] = rowCount;             //DEL 2009/04/02 不具合対応[12838]
                    // 列選択
                    row[CT_Select] = false;
                    // 列未選択
                    row[CT_SelectButton] = "";
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA DEL END

                    // --- ADD 2012/09/18 ---------->>>>>
                    // テキスト出力時に余計なスペースが出力されないようにする
                    // row[CT_WarehouseCode] = stockEx.WarehouseCode;              // 倉庫コード
                    row[CT_WarehouseCode] = stockEx.WarehouseCode.Trim();              // 倉庫コード
                    // --- ADD 2012/09/18 ----------<<<<<

                    row[CT_WarehouseShelfNo] = stockEx.WarehouseShelfNo;        // 棚番
                    //row[CT_MakerCode] = stockEx.GoodsMakerCd;                   // メーカーコード     //DEL 2009/04/01 不具合対応[12835]
                    // ---ADD 2009/04/01 不具合対応[12835] ------------------------------------->>>>>
                    // 仕入先コード
                    if (stockEx.GoodsMakerCd == 0)
                    {
                        row[CT_MakerCode] = string.Empty;
                    }
                    else
                    {
                        row[CT_MakerCode] = stockEx.GoodsMakerCd.ToString("0000");
                    }
                    // ---ADD 2009/04/01 不具合対応[12835] -------------------------------------<<<<<
                    row[CT_GoodsName] = stockEx.GoodsName;                      // 品名
                    row[CT_GoodsCode] = stockEx.GoodsNo;                        // 品番
                    row[CT_SupplierStock] = stockEx.SupplierStock;              // 現在庫(仕)
                    row[CT_MinimumStockCnt] = stockEx.MinimumStockCnt;          // 最低在庫
                    row[CT_MaximumStockCnt] = stockEx.MaximumStockCnt;          // 最高在庫
                    row[CT_SalesOrderCount] = stockEx.SalesOrderCount;          // 発注残
                    row[CT_SupplierLot] = stockEx.SupplierLot;                  // 発注ロット
                    row[CT_ShipmentPosCnt] = stockEx.ShipmentPosCnt;            // 出荷可能数
                    row[CT_MovingSupliStock] = stockEx.MovingSupliStock;        // 移動数
                    row[CT_ShipmentCnt] = stockEx.ShipmentCnt;                  // 出荷数（未計上）
                    row[CT_ArrivalCnt] = stockEx.ArrivalCnt;                    // 入荷数（未計上）
                    row[CT_AcpOdrCount] = stockEx.AcpOdrCount;                  // 受注数
                    row[CT_GoodsSpecialNote] = stockEx.GoodsSpecialNote;        // 規格・特記事項
                    //2008.10.03 stokunaga ADD start
                    if (stockEx.BLGoodsCode == 0)
                    {
                        row[CT_BLGoodsCode] = DBNull.Value;                  // BLコード
                    }
                    else
                    {
                        //row[CT_BLGoodsCode] = stockEx.BLGoodsCode;                  // BLコード       //DEL 2009/04/01 不具合対応[12835]
                        row[CT_BLGoodsCode] = stockEx.BLGoodsCode.ToString("00000");                    //ADD 2009/04/01 不具合対応[12835]
                    }
                    //2008.10.03 stokunaga ADD end
                    row[CT_GoodsNameKana] = stockEx.GoodsNameKana;              // 商品名称カナ
                    row[CT_DuplicationShelfNo1] = stockEx.DuplicationShelfNo1;  // 棚番1
                    row[CT_DuplicationShelfNo2] = stockEx.DuplicationShelfNo2;  // 棚番2
                    row[CT_MakerName] = stockEx.MakerName;                      // メーカー名称
                    //row[CT_SupplierCd] = stockEx.SupplierCd.ToString("000000");                    // 仕入先コード        //DEL 2009/04/01 不具合対応[12835]
                    // ---ADD 2009/04/01 不具合対応[12835] ------------------------------------->>>>>
                    // 仕入先コード
                    if (stockEx.SupplierCd == 0)
                    {
                        row[CT_SupplierCd] = string.Empty;
                    }
                    else
                    {
                        row[CT_SupplierCd] = stockEx.SupplierCd.ToString("000000");                    
                    }
                    // ---ADD 2009/04/01 不具合対応[12835] -------------------------------------<<<<<

                    row[CT_SupplierSnm] = stockEx.SupplierSnm;                  // 仕入先略名
                    row[CT_ListPrice] = stockEx.ListPrice;                      // 標準価格
                    row[CT_StockUnitPrice] = stockEx.StockUnitPriceFl;          // 仕入単価
                    row[CT_StockTotalPrice] = stockEx.StockTotalPrice;          // 在庫金額
                    row[CT_UpdateDateString] = stockEx.UpdateDateString;        // 更新日付
                    row[CT_StockCreateDateString] = stockEx.StockCreateDateString;  // 登録日付
                    
                    // --- ADD 2012/09/18 ---------->>>>>
                    // テキスト出力時に余計なスペースが出力されないようにする
                    // row[CT_SectionCode] = stockEx.SectionCode;                  // 拠点コード
                    row[CT_SectionCode] = stockEx.SectionCode.Trim();                  // 拠点コード
                    // --- ADD 2012/09/18 ----------<<<<<

                    row[CT_SectionName] = stockEx.SectionGuideNm;               // 拠点名
                    //if (_sectionNameDic.ContainsKey(stockEx.SectionCode))
                    //{
                    //    row[CT_SectionName] = _sectionNameDic[stockEx.SectionCode];
                    //}
                    row[CT_WarehouseName] = stockEx.WarehouseName;              // 倉庫名


                    // 受託数
                    //row[CT_TrustCount] = stockEx.TrustCount;
                    //// 予約数
                    //row[CT_ReservedCount] = stockEx.ReservedCount;
                    //// 引当在庫数
                    //row[CT_AllowStockCnt] = stockEx.AllowStockCnt;
                    // 委託数(自)
                    //row[CT_EntrustCnt] = stockEx.EntrustCnt;
                    //// 委託数(在)
                    //row[CT_TrustEntrustCnt] = stockEx.TrustEntrustCnt;
                    //// 売切数
                    //row[CT_SoldCnt] = stockEx.SoldCnt;
                    //// 移動中受託在庫数
                    //row[CT_MovingTrustStock] = stockEx.MovingTrustStock;
                    //// キャリア名称
                    //row[CT_CarrierName] = stockEx.CarrierName;


                    // 選択用在庫データ格納
                    row[CT_StockSearchRet] = stockEx.Clone();

                    //totalStockCount = totalStockCount + stockEx.SupplierStock;        //DEL 2009/04/01 不具合対応[12837]
                    totalStockCount = totalStockCount + stockEx.ShipmentPosCnt;         //ADD 2009/04/01 不具合対応[12837]
                    totalStockValue = totalStockValue + stockEx.StockTotalPrice;

                    this._stockDataTable.Rows.Add(row);
                    rowCount++;

                }

                // 合計行を追加
                this.uLabel_TotalStockCount.Text = string.Format("{0:###,###,##0.00}", totalStockCount);        // 在庫合計数
                this.uLabel_TotalStockValue.Text = "\\" + string.Format("{0:###,###,##0}", totalStockValue);      // 在庫金額

                // ---ADD 2009/04/02 不具合対応[12838] -------------------------------------->>>>>
                // 大文字小文字区別
                this._stockDataView.Table.CaseSensitive = true;

                // 表示順に従ってソート
                this.SetGridSort();

                // No.振り直し
                DataTable dt = this._stockDataView.ToTable();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dt.Rows[i][CT_RowNo] = i + 1;
                }

                this._stockDataView.Table = dt;
                // ---ADD 2009/04/02 不具合対応[12838] --------------------------------------<<<<<

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                msg = "在庫テーブル作成中にて例外が発生しました[" + ex.Message + "]";
            }
            finally
            {
                this._stockDataTable.EndLoadData();
            }

            return status;
        }

        // ---ADD 2009/04/02 不具合対応[12838] ---------------------------------------------------->>>>>
        /// <summary>
        /// グリッド表示順設定
        /// </summary>
        private void SetGridSort()
        {
            this._stockDataView.Table.CaseSensitive = true;

            // 在庫データ表示順を設定する
            if ((int)this.SortDiv_tComboEditor.Value == 0)
            {
                //倉庫＋品番＋メーカー
                this._stockDataView.Sort = CT_WarehouseCode + "," + CT_GoodsCode + "," + CT_MakerCode;
            }
            else if ((int)this.SortDiv_tComboEditor.Value == 1)
            {
                //品番＋メーカー＋倉庫
                this._stockDataView.Sort = CT_GoodsCode + "," + CT_MakerCode + "," + CT_WarehouseCode;
            }
            else if ((int)this.SortDiv_tComboEditor.Value == 2)
            {
                //拠点＋倉庫＋棚番
                this._stockDataView.Sort = CT_SectionCode + "," + CT_WarehouseCode + "," + CT_WarehouseShelfNo;
            }
            else if ((int)this.SortDiv_tComboEditor.Value == 3)
            {
                // ---DEL 2009/05/26 不具合[12838]修正ミスの為 --------------------->>>>>
                ////商品名称カナ＋品番
                //this._stockDataView.Sort = CT_GoodsNameKana + "," + CT_GoodsCode;
                // ---DEL 2009/05/26 不具合[12838]修正ミスの為 ---------------------<<<<<
                //品名カナ＋メーカー
                this._stockDataView.Sort = CT_GoodsNameKana + "," + CT_MakerCode;       //ADD 2009/05/26 不具合[12838]修正ミスの為
            }
            else if ((int)this.SortDiv_tComboEditor.Value == 4)
            {
                //倉庫＋メーカー＋品番
                this._stockDataView.Sort = CT_WarehouseCode + "," + CT_MakerCode + "," + CT_GoodsCode;
            }
            else
            {
                //倉庫＋品番＋メーカー
                this._stockDataView.Sort = CT_WarehouseCode + "," + CT_GoodsCode + "," + CT_MakerCode;
            }
        }
        // ---ADD 2009/04/02 不具合対応[12838] ----------------------------------------------------<<<<<

        /// <summary>
        /// 在庫リスト取得
        /// </summary>
        /// <remarks>呼び出し元がすべてコメントアウトされているので、使われていない？</remarks>
        /// <returns></returns>
        private List<StockExpansion> GetStockListDataTable()
        //private List<Stock> GetStockListDataTable()
        {
            List<StockExpansion> retList = new List<StockExpansion>();

            try
            {
                if (this._stockDataView.Count > 0)
                {
                    for (int i = 0; i < this._stockDataView.Count; ++i)
                    {
                        StockExpansion stock = this._stockDataView[i].Row[CT_StockSearchRet] != DBNull.Value ? ((StockExpansion)this._stockDataView[i].Row[CT_StockSearchRet]).Clone() : null;
                        if (stock != null)
                            retList.Add(stock);
                    }
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                //List<Stock> retListStk = new List<Stock>();
                //foreach (StockExpansion stockEx in retList)
                //{
                //    retListStk.Add(StockExpansion.ConvertToStock(stockEx));
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

            }
            catch (Exception)
            {
            }
            return retList;
            //return retListStk;
        }

        #region deleted
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        /// <summary>
        //        /// 製番在庫データテーブル設定処理
        //        /// </summary>
        //        /// <param name="productList">製番在庫クラスリスト</param>
        //        /// <param name="msg">エラーメッセージ</param>
        //        private int SetProductStockDataTable(List<ProductStock> productList, out string msg)
        //        {
        //            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //            msg = "";
        //            if (productList == null) return 0;
        //            if (productList.Count == 0) return 0;

        //            this._productStockDataTable.BeginLoadData();

        //            // 検索用のデータビューの作成
        //            DataView dataView = new DataView(this._stockDataTable);

        //            try
        //            {
        //                foreach (ProductStock product in productList)
        //                {
        //                    //if (this._productStockDataTable.Rows.Count >= CT_MaxRowCount)
        //                    //{
        //                    //  msg = "表示最大行数になりました。検索条件を絞って検索して下さい";
        //                    //  status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;
        //                    //  return status;
        //                    //}
        //                    DataRow row;
        //                    row = this._productStockDataTable.NewRow();

        //#if false
        //                    // 製造番号がない商品は合算して表示する
        //                    if (product.ProductNumber.Equals(string.Empty))
        //                    {
        //                        dataView.RowFilter = String.Format("{0} = '{1}' AND {2} = {3} AND {4} = '{5}' AND {6} IS NULL",
        //                            CT_SectionCode,
        //                            product.SectionCode,
        //                            CT_MakerCode,
        //                            product.MakerCode,
        //                            CT_GoodsCode,
        //                            product.GoodsCode,
        //                            CT_ProductNumber);

        //                        if (dataView.Count != 0)
        //                        {
        //                            row = dataView[0].Row;
        //                            isInsert = false;
        //                        }
        //                        else
        //                        {
        //                            row = this._productStockDataTable.NewRow();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        row = this._productStockDataTable.NewRow();
        //                    }
        //#endif

        //                    // 列選択
        //                    row[CT_Select] = false;

        //                    // 列選択ボタン
        //                    row[CT_SelectButton] = "";

        //                    // 製造番号
        //                    if (product.ProductNumber.Equals(string.Empty))
        //                    {
        //                        row[CT_ProductNumber] = "";
        //                    }
        //                    else
        //                    {
        //                        row[CT_ProductNumber] = product.ProductNumber;
        //                    }

        //                    // 商品コード
        //                    row[CT_GoodsCode] = product.GoodsCode;

        //                    // 商品名称
        //                    row[CT_GoodsName] = product.GoodsName;

        //                    // 拠点コード
        //                    row[CT_SectionCode] = product.SectionCode;

        //                    // メーカーコード
        //                    row[CT_MakerCode] = product.MakerCode;

        //                    // メーカーコード
        //                    row[CT_MakerName] = product.MakerName;

        //                    // 在庫区分
        //                    string stockDivNm = string.Empty;
        //                    switch (product.StockDiv)
        //                    {
        //                        case 0: stockDivNm = "自"; break;
        //                        case 1: stockDivNm = "受"; break;
        //                    }
        //                    row[CT_StockDivNm] = stockDivNm;

        //                    // 倉庫
        //                    row[CT_WarehouseName] = product.WarehouseName;

        //                    // 倉庫コード
        //                    row[CT_WarehouseCode] = product.WarehouseCode;

        //                    // 仕入先
        //                    row[CT_CustomerName] = product.CustomerName;

        //                    // 仕入日
        //                    row[CT_StockDate] = TDateTime.DateTimeToLongDate(product.StockDate);

        //                    // 仕入日
        //                    row[CT_StockDateDisp] = TDateTime.DateTimeToString("YYYY.MM.DD", product.StockDate);

        //                    // 仕入単価
        //                    row[CT_StockUnitPrice] = product.StockUnitPrice;

        //#if fallse					
        //                    // 在庫状態から数量を足しこみ
        //                    if (product.MoveStatus == 0 || product.MoveStatus == 9)
        //                    {
        //                        switch (product.StockState)
        //                        {
        //                            case 0:		// 在庫
        //                                {
        //                                    Int64 shipmentPosCnt = (row[CT_ShipmentPosCnt] != DBNull.Value) ? (Int64)row[CT_ShipmentPosCnt] : 0;
        //                                    row[CT_ShipmentPosCnt] = ++shipmentPosCnt;
        //                                    break;
        //                                }
        //                            case 10:	// 受託中
        //                                {
        //                                    Int64 trustCount = (row[CT_TrustCount] != DBNull.Value) ? (Int64)row[CT_TrustCount] : 0;
        //                                    row[CT_TrustCount] = ++trustCount; 
        //                                    break;
        //                                }
        //                            case 20:	// 委託中
        //                                {
        //                                    Int64 entrustCnt = (row[CT_EntrustCnt] != DBNull.Value) ? (Int64)row[CT_EntrustCnt] : 0;
        //                                    row[CT_EntrustCnt] = ++entrustCnt; 
        //                                    break;
        //                                }
        //                            case 30:	// 売切
        //                                {
        //                                    Int64 soldCnt = (row[CT_SoldCnt] != DBNull.Value) ? (Int64)row[CT_SoldCnt] : 0;
        //                                    row[CT_SoldCnt] = ++soldCnt; 
        //                                    break;
        //                                }
        //                            //						case 50: stockStateNm = "計上済"; break;
        //                            case 60:	// 予約中
        //                                {
        //                                    Int64 reservedCount = (row[CT_ReservedCount] != DBNull.Value) ? (Int64)row[CT_ReservedCount] : 0;
        //                                    row[CT_ReservedCount] = ++reservedCount; 
        //                                    break;
        //                                }
        //                            //						case 70: stockStateNm = "返品"; break;
        //                            //						case 80: stockStateNm = "抜出"; break;
        //                            //						case 81: stockStateNm = "消去"; break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // ステータスが移動中のもの
        //                        if (product.MoveStatus == 2)
        //                        {
        //                            // 自社分
        //                            if (product.StockDiv == 0)
        //                            {
        //                                Int64 movingSupliStock = (row[CT_MovingSupliStock] != DBNull.Value) ? (Int64)row[CT_MovingSupliStock] : 0;
        //                                // 移動中仕入在庫数
        //                                row[CT_MovingSupliStock] = ++movingSupliStock;
        //                            }
        //                            // 受託分
        //                            else if (product.StockDiv == 1)
        //                            {
        //                                Int64 movingTrustStock = (row[CT_MovingTrustStock] != DBNull.Value) ? (Int64)row[CT_MovingTrustStock] : 0;
        //                                // 移動中受託在庫数
        //                                row[CT_MovingTrustStock] = ++movingTrustStock;
        //                            }
        //                        }
        //                    }

        //#endif
        //                    // 各数量
        //                    // 在庫区分をみて自社・受託でカウントする
        //                    if (product.StockDiv == 0)
        //                    {
        //                        // 自社
        //                        row[CT_SupplierStock] = 1;
        //                    }
        //                    else if (product.StockDiv == 1)
        //                    {
        //                        // 受託
        //                        row[CT_TrustCount] = 1;
        //                    }

        //                    // 移動中状態
        //                    if (product.MoveStatus == 1 || product.MoveStatus == 2)
        //                    {
        //                        if (product.StockDiv == 0)
        //                        {
        //                            row[CT_MovingSupliStock] = 1;
        //                        }
        //                        else if (product.StockDiv == 1)
        //                        {
        //                            row[CT_MovingSupliStock] = 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        switch (product.StockState)
        //                        {
        //                            case 0:		// 在庫
        //                                {
        //                                    row[CT_ShipmentPosCnt] = 1;
        //                                    break;
        //                                }
        //                            case 10:	// 受託中
        //                                {
        //                                    row[CT_ShipmentPosCnt] = 1;
        //                                    break;
        //                                }
        //                            case 20:	// 委託中
        //                                {
        //                                    if (product.StockDiv == 0)
        //                                    {
        //                                        row[CT_EntrustCnt] = 1;
        //                                    }
        //                                    else if (product.StockDiv == 1)
        //                                    {
        //                                        row[CT_TrustEntrustCnt] = 1;
        //                                    }
        //                                    break;
        //                                }
        //                            case 30:	// 売切
        //                                {
        //                                    row[CT_SoldCnt] = 1;
        //                                    break;

        //                                }
        //                            case 60:	// 予約
        //                                {
        //                                    row[CT_ReservedCount] = 1;
        //                                    row[CT_AllowStockCnt] = 1;
        //                                    break;
        //                                }
        //                        }
        //                    }

        //                    // 在庫状態
        //                    string stockStateNm = string.Empty;
        //                    switch (product.StockState)
        //                    {
        //                        case 0:
        //                            {
        //                                stockStateNm = "在庫";
        //                                break;
        //                            }
        //                        case 10:
        //                            {
        //                                stockStateNm = "受託";
        //                                break;
        //                            }
        //                        case 20:
        //                            {
        //                                stockStateNm = "委託";
        //                                break;
        //                            }
        //                        case 30:
        //                            {
        //                                stockStateNm = "売切";
        //                                break;

        //                            }
        //                        case 50:
        //                            {
        //                                stockStateNm = "計上済"; break;
        //                            }
        //                        case 60:
        //                            {
        //                                stockStateNm = "予約"; break;
        //                            }
        //                        case 70:
        //                            {
        //                                stockStateNm = "返品"; break;
        //                            }
        //                        case 80:
        //                            {
        //                                stockStateNm = "抜出"; break;
        //                            }
        //                        case 81:
        //                            {
        //                                stockStateNm = "消去"; break;
        //                            }
        //                    }
        //                    row[CT_StockStateNm] = stockStateNm;

        //                    // 移動状態
        //                    //0:移動対象外,1:未出荷状態,2:移動中,9:入荷済
        //                    string moveStatusNm = string.Empty;
        //                    switch (product.MoveStatus)
        //                    {
        //                        case 0: moveStatusNm = ""; break;
        //                        case 1: moveStatusNm = "未出荷"; break;
        //                        case 2: moveStatusNm = "移動中"; break;
        //                        case 9: moveStatusNm = ""; break;
        //                    }
        //                    row[CT_MoveStatusNm] = moveStatusNm;

        //                    // 商品状態
        //                    string goodsCodeStatusNm = string.Empty;
        //                    switch (product.GoodsCodeStatus)
        //                    {
        //                        case 1: goodsCodeStatusNm = "不良品"; break;
        //                    }
        //                    row[CT_GoodsCodeStatusNm] = goodsCodeStatusNm;

        //                    // キャリア
        //                    row[CT_CarrierName] = product.CarrierName;

        //                    // 商品電話番号1
        //                    row[CT_StockTelNo1] = product.StockTelNo1;

        //                    // 商品電話番号2
        //                    row[CT_StockTelNo2] = product.StockTelNo2;

        //                    // 仕入日
        //row[CT_StockDateDisp] = TDateTime.DateTimeToString("YYYY.MM.DD", product.StockDate);

        //                    // 選択用製番クラス格納
        //                    row[CT_ProductStockSearchRet] = product.Clone();

        //                    if (dataView != null || dataView.Count > 0)
        //                    {
        //                        // PrimaryKeyで検索を行う
        //                        dataView.RowFilter = String.Format("{0} = '{1}' AND {2} = {3} AND {4} = '{5}'",
        //                            CT_SectionCode,
        //                            product.SectionCode,
        //                            CT_MakerCode,
        //                            product.MakerCode,
        //                            CT_GoodsCode,
        //                            product.GoodsCode);

        //                        if (this._stockDataView.Count > 0)
        //                        {
        //                            // 選択用在庫クラス格納
        //                            Stock stockEx = (dataView[0][CT_StockSearchRet] != DBNull.Value) ? (Stock)dataView[0][CT_StockSearchRet] : null;
        //                            if (stockEx != null)
        //                                row[CT_StockSearchRet] = stockEx.Clone();
        //                        }
        //                    }

        //                    this._productStockDataTable.Rows.Add(row);
        //                }

        //                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //            }
        //            catch (Exception ex)
        //            {
        //                msg = "製番在庫テーブル作成中にて例外が発生しました[" + ex.Message + "]";
        //            }
        //            finally
        //            {
        //                this._productStockDataTable.EndLoadData();
        //            }
        //            return status;
        //        }

        //        /// <summary>
        //        /// 製番在庫リスト取得
        //        /// </summary>
        //        /// <returns></returns>
        //        private List<ProductStock> GetProductStockListDataTable()
        //        {
        //            List<ProductStock> retList = new List<ProductStock>();

        //            try
        //            {
        //                if (this._productStockDataView.Count > 0)
        //                {
        //                    for (int i = 0; i < this._productStockDataView.Count; ++i)
        //                    {
        //                        ProductStock product = this._productStockDataView[i].Row[CT_ProductStockSearchRet] != DBNull.Value ? ((ProductStock)this._productStockDataView[i].Row[CT_ProductStockSearchRet]).Clone() : null;
        //                        if (product != null)
        //                            retList.Add(product);
        //                    }
        //                }
        //            }
        //            catch (Exception)
        //            {
        //            }
        //            return retList;
        //        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion // deleted

        /// <summary>
        /// 検索結果データ選択処理
        /// </summary>
        /// <param name="selRow">選択された対象行</param>
        private void SelectRowData(Infragistics.Win.UltraWinGrid.UltraGridRow selRow)
        {
            if (selRow == null) return;

            // 検索モード設定
            switch (this._searchMode)
            {
                // 商品
                case (int)emSearchMode.Goods:
                    {
                        break;
                    }
                // 商品在庫
                // 商品在庫製番
                case (int)emSearchMode.GoodsStock:
                case (int)emSearchMode.ResultStock:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //case (int)emSearchMode.ResultStockNoButton:
                //case (int)emSearchMode.Stock:
                case (int)emSearchMode.Stock:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    {
                        if (this._selStock == null)
                            this._selStock = new List<StockExpansion>();

                        StockExpansion stockSearchRet = (selRow.Cells[CT_StockSearchRet].Value != DBNull.Value) ? (StockExpansion)selRow.Cells[CT_StockSearchRet].Value : null;

                        // 選択した行を選択在庫情報の追加
                        this._selStock.Add(stockSearchRet.Clone());

                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 製番
                //case (int)emSearchMode.Product:
                //case (int)emSearchMode.ResultProduct:
                //    {
                //        if (this._selProduct == null)
                //            this._selProduct = new List<ProductStock>();

                //        ProductStock productStockSearchRet = (selRow.Cells[CT_ProductStockSearchRet].Value != DBNull.Value) ? (ProductStock)selRow.Cells[CT_ProductStockSearchRet].Value : null;

                //        // 選択した行を選択在庫情報の追加
                //        this._selProduct.Add(productStockSearchRet.Clone());
                //        break;
                //    }
                //// 製番(＋在庫)
                //case (int)emSearchMode.ResultProductwitchStock:
                //case (int)emSearchMode.ProductwitchStock:
                //    {
                //        if (this._selStock == null)
                //            this._selStock = new List<Stock>();

                //        if (this._selProduct == null)
                //            this._selProduct = new List<ProductStock>();


                //        ProductStock product = (selRow.Cells[CT_ProductStockSearchRet].Value != DBNull.Value) ? (ProductStock)selRow.Cells[CT_ProductStockSearchRet].Value : null;
                //        Stock stockEx = (selRow.Cells[CT_StockSearchRet].Value != DBNull.Value) ? (Stock)selRow.Cells[CT_StockSearchRet].Value : null;

                //        // 選択した行を選択在庫情報の追加
                //        if (product != null)
                //            this._selProduct.Add(product.Clone());
                //        if (stockEx != null)
                //            this._selStock.Add(stockEx.Clone());

                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

        }

        /// <summary>
        /// 検索結果データ選択処理
        /// </summary>
        private void MultiSelectRowData()
        {
            // 検索モード設定
            switch (this._searchMode)
            {
                // 商品
                case (int)emSearchMode.Goods:
                    {
                        break;
                    }
                // 商品在庫
                case (int)emSearchMode.GoodsStock:
                case (int)emSearchMode.ResultStock:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //case (int)emSearchMode.ResultStockNoButton:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                case (int)emSearchMode.Stock:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    {
                        if (this._selStock == null)
                            this._selStock = new List<StockExpansion>();

                        for (int i = 0; i < this._stockDataView.Count; i++)
                        {

                            bool isSelect = (this._stockDataView[i].Row[CT_Select] != DBNull.Value) ? (bool)this._stockDataView[i].Row[CT_Select] : false;

                            if (isSelect)
                            {
                                StockExpansion stockSearchRet = (this._stockDataView[i].Row[CT_StockSearchRet] != DBNull.Value) ? (StockExpansion)this._stockDataView[i].Row[CT_StockSearchRet] : null;
                                // 選択した行を選択在庫情報の追加
                                if (stockSearchRet != null)
                                    this._selStock.Add(stockSearchRet.Clone());
                            }
                        }

                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 製番
                //case (int)emSearchMode.Product:
                //case (int)emSearchMode.ResultProduct:
                //    {
                //        if (this._selStock == null)
                //            this._selStock = new List<Stock>();

                //        if (this._selProduct == null)
                //            this._selProduct = new List<ProductStock>();

                //        for (int i = 0; i < this._productStockDataView.Count; i++)
                //        {

                //            bool isSelect = (this._productStockDataView[i].Row[CT_Select] != DBNull.Value) ? (bool)this._productStockDataView[i].Row[CT_Select] : false;

                //            if (isSelect)
                //            {
                //                ProductStock productStockSearchRet = (this._productStockDataView[i].Row[CT_ProductStockSearchRet] != DBNull.Value) ? (ProductStock)this._productStockDataView[i].Row[CT_ProductStockSearchRet] : null;

                //                // 選択した行を選択在庫情報の追加
                //                if (productStockSearchRet != null)
                //                    this._selProduct.Add(productStockSearchRet.Clone());
                //            }
                //        }

                //        break;
                //    }
                //// 商品在庫製番
                //case (int)emSearchMode.Stock:
                //    {
                //        break;
                //    }
                //// 製番(＋在庫)
                //case (int)emSearchMode.ProductwitchStock:
                //case (int)emSearchMode.ResultProductwitchStock:
                //    {
                //        if (this._selStock == null)
                //            this._selStock = new List<Stock>();

                //        if (this._selProduct == null)
                //            this._selProduct = new List<ProductStock>();

                //        Dictionary<string, string> selStockKey = new Dictionary<string, string>();

                //        for (int i = 0; i < this._productStockDataView.Count; i++)
                //        {

                //            bool isSelect = (this._productStockDataView[i].Row[CT_Select] != DBNull.Value) ? (bool)this._productStockDataView[i].Row[CT_Select] : false;

                //            if (isSelect)
                //            {
                //                Stock stockEx = (this._productStockDataView[i].Row[CT_StockSearchRet] != DBNull.Value) ? (Stock)this._productStockDataView[i].Row[CT_StockSearchRet] : null;
                //                ProductStock product = (this._productStockDataView[i].Row[CT_ProductStockSearchRet] != DBNull.Value) ? (ProductStock)this._productStockDataView[i].Row[CT_ProductStockSearchRet] : null;

                //                // 選択した行を選択在庫情報の追加
                //                if (stockEx != null)
                //                {
                //                    // 既に設定済か判定する(拠点コード - メーカーコード - 商品コード)
                //                    string key = String.Format("{0}-{1}-{2}",
                //                        stockEx.SectionCode,
                //                        stockEx.MakerCode,
                //                        stockEx.GoodsCode);

                //                    if (!selStockKey.ContainsKey(key))
                //                    {
                //                        this._selStock.Add(stockEx.Clone());
                //                        selStockKey.Add(key, key);
                //                    }
                //                }

                //                if (product != null)
                //                    this._selProduct.Add(product.Clone());
                //            }
                //        }

                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 詳細ガイド表示
        ///// </summary>
        ///// <param name="targetRow">対象行</param>
        ///// <returns>DialogResult</returns>
        ///// <remarks>
        ///// <br>Note       : 詳細ガイド画面を表示します。</br>
        ///// <br>Programmer : 18012 Y.Sasaki</br>
        ///// <br>Date       : 2007.02.06</br>
        ///// </remarks>
        //private DialogResult ShowDetail(Infragistics.Win.UltraWinGrid.UltraGridRow targetRow)
        //{
        //    DialogResult dResult = DialogResult.None;

        //    string sectionCode = (targetRow.Cells[CT_SectionCode].Value != DBNull.Value) ? (string)targetRow.Cells[CT_SectionCode].Value : string.Empty;
        //    int makerCode = (targetRow.Cells[CT_MakerCode].Value != DBNull.Value) ? (int)targetRow.Cells[CT_MakerCode].Value : 0;
        //    string goodsCode = (targetRow.Cells[CT_GoodsCode].Value != DBNull.Value) ? (string)targetRow.Cells[CT_GoodsCode].Value : string.Empty;

        //    StockSearchPara para = this._prevSearchParam.Clone();
        //    para.MakerCode = makerCode;
        //    para.GoodsCode = goodsCode;
        //    para.SectionCode = sectionCode;
        //    // データ取得区分(0:全て(在庫+製番在庫),1:在庫,2:製番在庫)
        //    para.DataAcqrDiv = 2;

        //    this._productStockDataTable.Rows.Clear();			

        //    //*******************************************************************************
        //    // 製番情報を検索する 
        //    //*******************************************************************************
        //    //if (this._productStockDataTable == null || this._productStockDataTable.Rows.Count == 0)
        //    //{
        //        string msg;

        //        List<Stock> retStockList;
        //        List<ProductStock> retProductList;

        //        int status = this._searchStockAcs.Search(para, out retStockList, out retProductList, out msg);

        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                {
        //                    // 抽出結果を保持
        //                    status = this.SetProductStockDataTable(retProductList, out msg);
        //                    switch (status)
        //                    {
        //                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
        //                            break;
        //                        case (int)ConstantManagement.MethodResult.ctFNC_WARNING:
        //                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
        //                            break;
        //                        default:
        //                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, 0, MessageBoxButtons.OK);
        //                            return dResult;
        //                    }
        //                    break;
        //                }
        //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                {
        //                    return dResult;
        //                }
        //            default:
        //                {
        //                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, msg, status, MessageBoxButtons.OK);
        //                    return dResult;
        //                }
        //        }
        //    //}

        //    // クエリ作成
        //    DataView dataView = new DataView(this._productStockDataTable);
        //    dataView.RowFilter = String.Format("{0} = '{1}' AND {2} = {3} AND {4} = '{5}'",
        //        CT_SectionCode,
        //        sectionCode,
        //        CT_MakerCode,
        //        makerCode,
        //        CT_GoodsCode,
        //        goodsCode);

        //    if (dataView.Count > 0)
        //    {
        //        // 製番ガイド
        //        this._detailGuide = new StockSearchGuide();

        //        // データを移行してあげる
        //        this._detailGuide.ShiftProductData(dataView);

        //        // 製番ガイドを起動する
        //        this._detailGuide.Title = "製番選択";
        //        para = this._prevSearchParam.Clone();
        //        object retObject;

        //        this._detailGuide.IsMultiSelect = this.IsMultiSelect;

        //        dResult = this._detailGuide.ShowGuide(this, emSearchMode.ResultProduct, false, para, out retObject);
        //        if (dResult == DialogResult.OK)
        //        {
        //            // 製番を確定させる
        //            List<ProductStock> productRet = retObject as List<ProductStock>;
        //            if (productRet != null)
        //            {
        //                this._selProduct.AddRange(productRet);
        //            }

        //            // 在庫を確定させる
        //            Stock stockRet = (targetRow.Cells[CT_StockSearchRet].Value != DBNull.Value) ? (Stock)targetRow.Cells[CT_StockSearchRet].Value : null;
        //            if (stockRet != null)
        //            {
        //              this._selStock.Add(stockRet.Clone());
        //            }
        //        }
        //    }
        //    //else
        //    //{
        //    //  // 単一選択の場合
        //    //  this.SelectRowData(targetRow);
        //    //  dResult = DialogResult.OK;
        //    //}


        //    return dResult;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// 在庫情報再計算処理
        /// </summary>
        private void CalculationStockByWarehouse()
        {
            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this._productStockDataView.RowFilter = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (this._stockDataView.Count == 0 || this._productStockDataView.Count == 0) return;
                if (this._stockDataView.Count == 0) return;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this._productStockDataView.Sort = CT_SectionCode + " , " + CT_WarehouseCode + " , " + CT_MakerCode + " , " + CT_GoodsCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                string pSectionCode = string.Empty;
                string pWarehouseCode = string.Empty;
                int pMakerCode = 0;
                string pGoodsCode = string.Empty;

                // 仕入在庫数
                Int64 sumSupplierStock = 0;

                // 受託数
                Int64 sumTrustCount = 0;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 予約数
                //Int64 sumReservedCount = 0;

                //// 引当在庫数
                //Int64 sumAllowStockCnt = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 委託数(自)
                Int64 sumEntrustCnt = 0;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 委託数(受)
                //Int64 sumTrustEntrustCnt = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 売切数
                //Int64 sumSoldCnt = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 移動中仕入在庫数
                Int64 sumMovingSupliStock = 0;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 移動中受託在庫数
                //Int64 sumMovingTrustStock = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 出荷可能数
                Int64 sumShipmentPosCnt = 0;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 先頭レコードのデータを取得
                //ProductStock product = (this._productStockDataView[0].Row[CT_ProductStockSearchRet] != DBNull.Value) ? (ProductStock)this._productStockDataView[0].Row[CT_ProductStockSearchRet] : null;
                //if (product != null)
                //{
                //    // 前回情報を保持しておく
                //    pSectionCode = product.SectionCode;
                //    pWarehouseCode = product.WarehouseCode;
                //    pMakerCode = product.MakerCode;
                //    pGoodsCode = product.GoodsCode;

                //    // 仕入在庫数
                //    sumSupplierStock += (this._productStockDataView[0].Row[CT_SupplierStock] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_SupplierStock] : 0;
                //    // 受託数
                //    sumTrustCount += (this._productStockDataView[0].Row[CT_TrustCount] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_TrustCount] : 0;
                //    // 予約数
                //    sumReservedCount += (this._productStockDataView[0].Row[CT_ReservedCount] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_ReservedCount] : 0;
                //    // 引当在庫数
                //    sumAllowStockCnt += (this._productStockDataView[0].Row[CT_AllowStockCnt] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_AllowStockCnt] : 0;
                //    // 委託数(自)
                //    sumEntrustCnt += (this._productStockDataView[0].Row[CT_EntrustCnt] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_EntrustCnt] : 0;
                //    // 委託数(受)
                //    sumTrustEntrustCnt += (this._productStockDataView[0].Row[CT_TrustEntrustCnt] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_TrustEntrustCnt] : 0;
                //    // 売切数
                //    sumSoldCnt += (this._productStockDataView[0].Row[CT_SoldCnt] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_SoldCnt] : 0;
                //    // 移動中仕入在庫数
                //    sumMovingSupliStock += (this._productStockDataView[0].Row[CT_MovingSupliStock] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_MovingSupliStock] : 0;
                //    // 移動中受託在庫数
                //    sumMovingTrustStock += (this._productStockDataView[0].Row[CT_MovingTrustStock] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_MovingTrustStock] : 0;
                //    // 出荷可能数
                //    sumShipmentPosCnt += (this._productStockDataView[0].Row[CT_ShipmentPosCnt] != DBNull.Value) ? (Int64)this._productStockDataView[0].Row[CT_ShipmentPosCnt] : 0;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //for (int i = 1; i < this._productStockDataView.Count; i++)
                //{
                //    product = (this._productStockDataView[i].Row[CT_ProductStockSearchRet] != DBNull.Value) ? (ProductStock)this._productStockDataView[i].Row[CT_ProductStockSearchRet] : null;
                //    if (product == null) continue;

                //    // 前回条件と異なる場合
                //    if (!product.SectionCode.Equals(pSectionCode) ||
                //        !product.WarehouseCode.Equals(pWarehouseCode) ||
                //        product.MakerCode != pMakerCode ||
                //        !product.GoodsCode.Equals(pGoodsCode))
                //    {
                //        // 在庫情報を検索する
                //        string filter = string.Empty;

                //        filter = String.Format("{0} = '{1}' AND {2} = {3} AND {4} = '{5}'",
                //            CT_SectionCode,
                //            pSectionCode,
                //            CT_MakerCode,
                //            pMakerCode,
                //            CT_GoodsCode,
                //            pGoodsCode);

                //        this._stockDataView.RowFilter = filter;

                //        if (this._stockDataView.Count != 0)
                //        {
                //            Stock stockEx = this._stockDataView[0].Row[CT_StockSearchRet] != DBNull.Value ? (Stock)this._stockDataView[0].Row[CT_StockSearchRet] : null;
                //            if (stockEx == null) continue;


                //            // 仕入在庫数
                //            this._stockDataView[0].Row[CT_SupplierStock] = sumSupplierStock;
                //            stockEx.SupplierStock = sumSupplierStock;

                //            // 受託数
                //            this._stockDataView[0].Row[CT_TrustCount] = sumTrustCount;
                //            stockEx.TrustCount = sumTrustCount;

                //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //            //// 予約数
                //            //this._stockDataView[0].Row[CT_ReservedCount] = sumReservedCount;
                //            //stockEx.ReservedCount = (Int32)sumReservedCount;

                //            //// 引当在庫数
                //            //this._stockDataView[0].Row[CT_AllowStockCnt] = sumAllowStockCnt;
                //            //stockEx.AllowStockCnt = sumAllowStockCnt;
                //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //            // 委託数(自)
                //            this._stockDataView[0].Row[CT_EntrustCnt] = sumEntrustCnt;
                //            stockEx.EntrustCnt = sumEntrustCnt;

                //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //            //// 委託数(受)
                //            //this._stockDataView[0].Row[CT_TrustEntrustCnt] = sumTrustEntrustCnt;
                //            //stockEx.TrustEntrustCnt = sumTrustEntrustCnt;
                //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //            // 売切数
                //            this._stockDataView[0].Row[CT_SoldCnt] = sumSoldCnt;
                //            stockEx.SoldCnt = sumSoldCnt;

                //            // 移動中仕入在庫数
                //            this._stockDataView[0].Row[CT_MovingSupliStock] = sumMovingSupliStock;
                //            stockEx.MovingSupliStock = sumMovingSupliStock;

                //            // 移動中受託在庫数
                //            this._stockDataView[0].Row[CT_MovingTrustStock] = sumMovingTrustStock;
                //            stockEx.MovingTrustStock = sumMovingTrustStock;

                //            // 出荷可能数
                //            this._stockDataView[0].Row[CT_ShipmentPosCnt] = sumShipmentPosCnt;
                //            stockEx.ShipmentPosCnt = sumShipmentPosCnt;

                //            // 初期化する 
                //            sumSupplierStock = 0;
                //            sumTrustCount = 0;
                //            sumReservedCount = 0;
                //            sumAllowStockCnt = 0;
                //            sumEntrustCnt = 0;
                //            sumTrustEntrustCnt = 0;
                //            sumSoldCnt = 0;
                //            sumMovingSupliStock = 0;
                //            sumMovingTrustStock = 0;
                //            sumShipmentPosCnt = 0;
                //        }
                //    }

                //    // 仕入在庫数
                //    sumSupplierStock += (this._productStockDataView[i].Row[CT_SupplierStock] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_SupplierStock] : 0;
                //    // 受託数
                //    sumTrustCount += (this._productStockDataView[i].Row[CT_TrustCount] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_TrustCount] : 0;
                //    // 予約数
                //    sumReservedCount += (this._productStockDataView[i].Row[CT_ReservedCount] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_ReservedCount] : 0;
                //    // 引当在庫数
                //    sumAllowStockCnt += (this._productStockDataView[i].Row[CT_AllowStockCnt] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_AllowStockCnt] : 0;
                //    // 委託数(自)
                //    sumEntrustCnt += (this._productStockDataView[i].Row[CT_EntrustCnt] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_EntrustCnt] : 0;
                //    // 委託数(受)
                //    sumTrustEntrustCnt += (this._productStockDataView[i].Row[CT_TrustEntrustCnt] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_TrustEntrustCnt] : 0;
                //    // 売切数
                //    sumSoldCnt += (this._productStockDataView[i].Row[CT_SoldCnt] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_SoldCnt] : 0;
                //    // 移動中仕入在庫数
                //    sumMovingSupliStock += (this._productStockDataView[i].Row[CT_MovingSupliStock] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_MovingSupliStock] : 0;
                //    // 移動中受託在庫数
                //    sumMovingTrustStock += (this._productStockDataView[i].Row[CT_MovingTrustStock] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_MovingTrustStock] : 0;
                //    // 出荷可能数
                //    sumShipmentPosCnt += (this._productStockDataView[i].Row[CT_ShipmentPosCnt] != DBNull.Value) ? (Int64)this._productStockDataView[i].Row[CT_ShipmentPosCnt] : 0;


                //    pSectionCode = product.SectionCode;
                //    pWarehouseCode = product.WarehouseCode;
                //    pMakerCode = product.MakerCode;
                //    pGoodsCode = product.GoodsCode;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 最終レコードを更新する
                // 在庫情報を検索する
                string filter2 = string.Empty;

                filter2 = String.Format("{0} = '{1}' AND {2} = {3} AND {4} = '{5}'",
                    CT_SectionCode,
                    pSectionCode,
                    CT_MakerCode,
                    pMakerCode,
                    CT_GoodsCode,
                    pGoodsCode);

                this._stockDataView.RowFilter = filter2;

                if (this._stockDataView.Count != 0)
                {
                    StockExpansion stock = this._stockDataView[0].Row[CT_StockSearchRet] != DBNull.Value ? (StockExpansion)this._stockDataView[0].Row[CT_StockSearchRet] : null;
                    if (stock != null)
                    {
                        // 仕入在庫数
                        this._stockDataView[0].Row[CT_SupplierStock] = sumSupplierStock;
                        stock.SupplierStock = sumSupplierStock;

                        // 受託数
                        this._stockDataView[0].Row[CT_TrustCount] = sumTrustCount;
                        stock.TrustCount = sumTrustCount;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //// 予約数
                        //this._stockDataView[0].Row[CT_ReservedCount] = sumReservedCount;
                        //stockEx.ReservedCount = (Int32)sumReservedCount;

                        //// 引当在庫数
                        //this._stockDataView[0].Row[CT_AllowStockCnt] = sumAllowStockCnt;
                        //stockEx.AllowStockCnt = sumAllowStockCnt;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                        // 委託数(自)
                        this._stockDataView[0].Row[CT_EntrustCnt] = sumEntrustCnt;
                        stock.EntrustCnt = sumEntrustCnt;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //// 委託数(受)
                        //this._stockDataView[0].Row[CT_TrustEntrustCnt] = sumTrustEntrustCnt;
                        //stockEx.TrustEntrustCnt = sumTrustEntrustCnt;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //// 売切数
                        //this._stockDataView[0].Row[CT_SoldCnt] = sumSoldCnt;
                        //stockEx.SoldCnt = sumSoldCnt;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                        // 移動中仕入在庫数
                        this._stockDataView[0].Row[CT_MovingSupliStock] = sumMovingSupliStock;
                        stock.MovingSupliStock = sumMovingSupliStock;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //// 移動中受託在庫数
                        //this._stockDataView[0].Row[CT_MovingTrustStock] = sumMovingTrustStock;
                        //stockEx.MovingTrustStock = sumMovingTrustStock;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                        // 出荷可能数
                        this._stockDataView[0].Row[CT_ShipmentPosCnt] = sumShipmentPosCnt;
                        stock.ShipmentPosCnt = sumShipmentPosCnt;
                    }
                }

                this._stockDataView.RowFilter = string.Empty;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //this._productStockDataView.RowFilter = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
            catch (Exception)
            {
            }
        }


        #endregion

        // --------------------------------------------------
        #region < その他処理 >

        /// <summary>
        /// 文字列→数値（Int32）変換処理（Object型が対象）
        /// </summary>
        /// <param name="obj">変換対象Object</param>
        /// <param name="defaultNo">初期値</param>
        /// <returns>int</returns>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }

        /// <summary>
        /// 並び順ボタンの表示スタイル変更
        /// </summary>
        /// <param name="button"></param>
        private void ChangeOderButtonStyle(Infragistics.Win.Misc.UltraButton button)
        {
            if (button.ButtonStyle == Infragistics.Win.UIElementButtonStyle.WindowsXPCommandButton)
            {
                button.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ButtonSoft;
                button.Appearance.BackColor = this._selSortBtnBackColor;
                button.Appearance.ForeColor = this._selSortBtnForeColor;
            }
            else
            {
                button.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsXPCommandButton;
                button.Appearance = (Infragistics.Win.Appearance)_defButtonAppearance.Clone();
            }
        }

        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 仕入先検索選択結果イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="customerSearchRet"></param>
        //private void CustomerSelected(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    try
        //    {
        //        if (this.tEdit_SupplierName.Tag == null || TStrConv.StrToIntDef(this.tEdit_SupplierName.Tag.ToString(), 0) != customerSearchRet.CustomerCode)
        //        {
        //            this.tEdit_SupplierName.Tag = customerSearchRet.CustomerCode.ToString();
        //            this.tEdit_SupplierName.DataText = customerSearchRet.Name;

        //            // 前回情報退避
        //            _prevHeaderInfo.SupplierCode = customerSearchRet.CustomerCode;
        //            _prevHeaderInfo.SupplierName = customerSearchRet.Name;


        //            // 複数条件指定でなければ
        //            if (!this.Multi_CheckEditor.Checked)
        //            {
        //                // 検索処理
        //                this.SearchMainProc(this.tEdit_SupplierName);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        this._isButtonClick = true;
        //    }
        //}

        /// <summary>
        /// 仕入先検索選択結果イベント
        /// </summary>
        /// <param name="supplier"></param>
        /// <remarks>
        /// <br>Update Note : 2009/11/05       呉元嘯</br>
        /// <br>	        : Redmine#1114対応</br>
        /// </remarks>
        private void SupplierSelected(Supplier supplier)
        {
            try
            {
                if (this.tEdit_SupplierName.Tag == null || TStrConv.StrToIntDef(this.tEdit_SupplierName.Tag.ToString(), 0) != supplier.SupplierCd)
                {

                    this.tEdit_SupplierName.Tag = supplier.SupplierCd.ToString();
                    this.tEdit_SupplierName.DataText = supplier.SupplierNm1;
                    // this.tNedit_SupplierCd.Text = supplier.SupplierCd.ToString().Trim(); // DEL 2009/11/05
                    this.tNedit_SupplierCd.SetInt(supplier.SupplierCd); // ADD 2009/11/05

                    // 前回情報退避
                    _prevHeaderInfo.SupplierCode = supplier.SupplierCd;
                    _prevHeaderInfo.SupplierName = supplier.SupplierNm1;

                    // 複数条件指定でなければ
                    if (!this.Multi_CheckEditor.Checked)
                    {
                        // 検索処理
                        this.SearchMainProc(this.tEdit_SupplierName);
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this._isButtonClick = true;
            }
        }
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #endregion

        // ===============================================================================
        // コントロールイベント
        // ===============================================================================
        #region Control Event

        #region < Form_Loadイベント >

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 画面がロードされた際、発生するイベントです。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2007.1.10</br>
        /// </remarks>
        private void GoodsStockSearchGuide_Load(object sender, EventArgs e)
        {
            this._isInitialize = true;
            this._isEvent = false;

            // 列サイズ調整イベント不可
            this._isEventAutoFillColumn = false;

            // 初回起動時のみ
            if (this._initialCounter == 0)
            {
                // 画面のスキンを設定する
                this._controlScreenSkin.LoadSkin();

                List<string> excCtrlNm = new List<string>();
                excCtrlNm.Add(this.Standard_UGroupBox.Name);
                excCtrlNm.Add(this.Detail_UGroupBox.Name);
                excCtrlNm.Add(this.Multi_UGroupBox.Name);

                this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
                this._controlScreenSkin.SettingScreenSkin(this);

                this.Standard_UGroupBox.BackColor = this.Form1_Fill_Panel.BackColor;
                this.Detail_UGroupBox.BackColor = this.Form1_Fill_Panel.BackColor;
                this.Multi_UGroupBox.BackColor = this.Form1_Fill_Panel.BackColor;

                // デフォルトのボタン外観情報取得
                this._defButtonAppearance = (Infragistics.Win.Appearance)this.ProductOder_uButton.Appearance.Clone();

                // アイコンイメージリストの設定
                this._imageList16 = IconResourceManagement.ImageList16;

                // 画面の初期設定
                this.InitialSetting();

                // ツールバーの初期設定
                this.InitSettingToolBar();

                this._fontSizeValueList = new Infragistics.Win.ValueList();

                // 文字サイズ設定
                for (int i = 0; i < this._fontpitchSize.Length; i++)
                {
                    this.FontSize_tComboEditor.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
                }

                // キーマッピングの設定
                this.MakeKeyMappingForGrid(this.gridResult);

            }

            // 全てのグループ内のコントロールを非表示にする
            this.UnDisplayControl(false, this.Standard_UGroupBox);
            this.UnDisplayControl(false, this.Detail_UGroupBox);

            // グリッドのバインドを解除しておく
            this.gridResult.DataSource = null;

            switch (this._searchMode)
            {
                case (int)emSearchMode.Goods:
                    this.Text = "商品検索";
                    break;
                case (int)emSearchMode.GoodsStock:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                case (int)emSearchMode.Stock:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    this.Text = "在庫検索";
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //case (int)emSearchMode.Product:
                //case (int)emSearchMode.ProductwitchStock:
                //    this.Text = "製番検索";
                //    break;
                //case (int)emSearchMode.Stock:
                //    this.Text = "在庫製番検索";
                //    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                case (int)emSearchMode.ResultStock:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //case (int)emSearchMode.ResultStockNoButton:
                    //case (int)emSearchMode.ResultProduct:
                    //case (int)emSearchMode.ResultProductwitchStock:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    this.Text = this._title;
                    break;
            }

            // 検索モードによる抽出条件コントロール変更
            this.DispChangeControl(this._searchMode);

            this.Initial_Timer.Enabled = true;
        }

        #endregion

        #region < FormClosedイベント >

        /// <summary>
        /// 画面Closedイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 画面が閉じられた後、発生するイベントです。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2007.2.7</br>
        /// </remarks>
        private void StockSearchGuide_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string saveFileNm = string.Empty;
                switch (this._searchMode)
                {
                    // 商品在庫
                    case (int)emSearchMode.GoodsStock:
                    case (int)emSearchMode.ResultStock:
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //case (int)emSearchMode.ResultStockNoButton:
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        saveFileNm = CT_GRIDSTATEINFO_STOCK;
                        break;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 商品在庫製番
                    //case (int)emSearchMode.Stock:
                    //    saveFileNm = CT_GRIDSTATEINFO_STOCKPRODUCT;
                    //    break;
                    //// 製番
                    //case (int)emSearchMode.Product:
                    //case (int)emSearchMode.ResultProduct:
                    //case (int)emSearchMode.ResultProductwitchStock:
                    //case (int)emSearchMode.ProductwitchStock:
                    //    saveFileNm = CT_GRIDSTATEINFO_PRODUCT;
                    //    break;

                    // 商品在庫製番
                    case (int)emSearchMode.Stock:
                        saveFileNm = CT_GRIDSTATEINFO_STOCK;
                        break;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // 商品
                    case (int)emSearchMode.Goods:
                        saveFileNm = CT_GRIDSTATEINFO_GOODS;
                        break;
                }

                if (!saveFileNm.Equals(string.Empty))
                    // グリッド設定をファイルに保存
                    this._gridStateController.SaveGridState(saveFileNm, ref this.gridResult);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                _extractPauseFlag = false;
                _extractCancelFlag = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

            }
            catch (Exception)
            {
            }        
        }

        #endregion

        #region < Timerイベント >

        /// <summary>
        /// 起動タイマーイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2007.1.10</br>
        /// <br>Update Note : 2009/09/07       汪千来</br>
        /// <br>            : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            this._isEventAutoFillColumn = false;

            try
            {
                // バインドをはずす
                this.gridResult.DataSource = null;

                // 初回起動時のみ処理を行います
                if (this._initialCounter == 0)
                {
                }

                // データセット・データテーブルの作成
                this.SettingDataSet();

                switch (this._searchMode)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 商品在庫製番
                    //case (int)emSearchMode.Stock:
                    //    {
                    //        // グリッド設定のロード
                    //        this._gridStateController.LoadGridState(CT_GRIDSTATEINFO_STOCKPRODUCT);

                    //        this._gridBindDataView = this._stockDataView;

                    //        break;
                    //    }

                    // 在庫
                    case (int)emSearchMode.Stock:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // 商品在庫
                    case (int)emSearchMode.GoodsStock:
                    case (int)emSearchMode.ResultStock:
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //case (int)emSearchMode.ResultStockNoButton:
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        {
                            // グリッド設定のロード
                            this._gridStateController.LoadGridState(CT_GRIDSTATEINFO_STOCK, ref this.gridResult);

                            this._gridBindDataView = this._stockDataView;
                        }
                        break;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //// 製番
                    //case (int)emSearchMode.Product:
                    //case (int)emSearchMode.ResultProduct:
                    //case (int)emSearchMode.ResultProductwitchStock:
                    //case (int)emSearchMode.ProductwitchStock:
                    //    {
                    //        // グリッド設定のロード
                    //        this._gridStateController.LoadGridState(CT_GRIDSTATEINFO_PRODUCT);

                    //        this._gridBindDataView = this._productStockDataView;
                    //    }
                    //    break;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // 商品
                    case (int)emSearchMode.Goods:
                        {
                            // グリッド設定のロード
                            this._gridStateController.LoadGridState(CT_GRIDSTATEINFO_GOODS);

                        }
                        break;
                }

                // グリッドにデータビューをバインドする
                this.gridResult.DataSource = this._gridBindDataView;

                // グリッド列設定
                switch (this._searchMode)
                {
                    case (int)emSearchMode.Goods:
                        break;
                    case (int)emSearchMode.GoodsStock:
                    case (int)emSearchMode.ResultStock:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //case (int)emSearchMode.ResultStockNoButton:
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    case (int)emSearchMode.Stock:
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        this.SettingStockGridColumns();
                        break;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //case (int)emSearchMode.Product:
                    //case (int)emSearchMode.ResultProduct:
                    //case (int)emSearchMode.ResultProductwitchStock:
                    //case (int)emSearchMode.ProductwitchStock:
                    //    this.SettingProductGridColumns();
                    //    break;
                    //case (int)emSearchMode.Stock:
                    //    this.SettingStockGridColumns();
                    //    break;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }

                // グリッド設定情報取得
                GridStateController.GridStateInfo gridStateInfo =
                    this._gridStateController.GetGridStateInfo(ref this.gridResult);

                if (gridStateInfo != null)
                {
                    // グリッドに設定
                    this._gridStateController.SetGridStateToGrid(ref this.gridResult);
                    // フォントサイズ反映
                    this.FontSize_tComboEditor.Value = (int)gridStateInfo.FontSize;
                    this.AutoFillToGridColumn_CheckEditor.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    // フォントサイズ反映
                    this.FontSize_tComboEditor.Value = CT_Default_FontSize;
                    if (this.AutoFillToGridColumn_CheckEditor.Checked)
                    {
                        this.gridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                    }
                    else
                    {
                        this.gridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                    }
                }


                // グリッドの表示制御を行う
                Infragistics.Win.UltraWinGrid.ColumnsCollection columns =
                    this.gridResult.DisplayLayout.Bands[0].Columns;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (columns.Exists(CT_ProductButton))
                //    columns[CT_ProductButton].Width = CT_ButtonColWidth;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                if (columns.Exists(CT_SelectButton))
                    columns[CT_SelectButton].Width = CT_ButtonColWidth;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //switch (this._searchMode)
                //{
                //    case (int)emSearchMode.ResultStock:
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //    //case (int)emSearchMode.Stock: 
                //    case (int)emSearchMode.Stock:
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //        {
                //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //            //if ( columns.Exists(CT_ProductButton) ) {
                //            //    columns[CT_ProductButton].Hidden = false;
                //            //}
                //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //            if ( columns.Exists(CT_SelectButton) ) {
                //                columns[CT_SelectButton].Hidden = true;
                //            }
                //            break;
                //        }
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //    default:
                //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //        //if (columns.Exists(CT_ProductButton))
                //        //{
                //        //    columns[CT_ProductButton].Hidden = true;
                //        //}
                //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //        if (columns.Exists(CT_SelectButton))
                //        {
                //            columns[CT_SelectButton].Hidden = !this.IsMultiSelect;
                //        }
                //        break;
                //}

                if (columns.Exists(CT_SelectButton))
                {
                    columns[CT_SelectButton].Hidden = !this.IsMultiSelect;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 倉庫の表示有無 (ヘッダの倉庫固定の場合は明細に倉庫を表示しない)
                if (this._isFixedWarehouseCode == false)
                {
                    columns[CT_WarehouseCode].Hidden = false;
                    columns[CT_WarehouseName].Hidden = false;
                }
                else
                {
                    columns[CT_WarehouseCode].Hidden = true;
                    columns[CT_WarehouseName].Hidden = true;
                }
                // 拠点の表示有無 (ヘッダの拠点固定の場合は明細に拠点を表示しない)
                if (this._isFixedSection == false)
                {
                    columns[CT_SectionCode].Hidden = false;
                    columns[CT_SectionName].Hidden = false;
                }
                else
                {
                    columns[CT_SectionCode].Hidden = true;
                    columns[CT_SectionName].Hidden = true;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 画面初期設定
                switch (this._searchMode)
                {
                    case (int)emSearchMode.ResultStock:
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //case (int)emSearchMode.ResultStockNoButton:
                        //case (int)emSearchMode.ResultProduct:
                        //case (int)emSearchMode.ResultProductwitchStock:
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        {
                            this.InitialDisplay(3);
                            break;
                        }
                    default:
                        {
                            this.InitialDisplay(0);
                            break;
                        }
                }

                // デフォルト拠点を設定しておく
                if (this._setSearchParam.SectionCode.Equals(string.Empty))
                {
                    this.Section_ComboEditor.Value = this._loginSectionCode;

                    // 抽出条件を設定しておく
                    this._setSearchParam.SectionCode = this._loginSectionCode;
                }

                this.Section_ComboEditor.Enabled = false;

                // 本社機能かどうかチェックする
                SecInfoSet secInfoSet;

                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //int status = this._secInfoAcs.GetSecInfo(this._setSearchParam.SectionCode, SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
                int status = this._secInfoAcs.GetSecInfo(this._setSearchParam.SectionCode, out secInfoSet);
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (status == 0)
                {
                    if (secInfoSet != null && secInfoSet.MainOfficeFuncFlag == 1)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                        //this.Section_ComboEditor.Enabled = true;
                        //this.tEdit_SectionCode.Enabled = true;      // DEL 2009/09/07
                        this.tEdit_SectionCodeAllowZero.Enabled = true;         // ADD 2009/09/07
                        this.uButton_SectionGuide.Enabled = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
                    }
                }

                // 抽出条件を画面に設定
                this.SetSearchParameter(this._setSearchParam);

                // 前回条件にも同様に設定
                this._prevSearchParam = this._setSearchParam.Clone();

                // 自動検索モードの場合は、検索処理を行う
                if (this._isAutoSearch)
                {
                    // 複数条件指定のチェックをつける
                    this.Multi_CheckEditor.Checked = true;

                    // 検索ボタンクリックイベントを発生させる
                    EventArgs eventArgs = new EventArgs();
                    this.Search_Button_Click(this.Search_Button, eventArgs);
                }

                // 起動回数カウントアップ
                this._initialCounter++;

                // --- ADD 2012/09/18 ---------->>>>>
                // 設定フォームへのカラム一覧渡し
                this._settingForm.SlipColCollection = this.gridResult.DisplayLayout.Bands[0].Columns;
                // --- ADD 2012/09/18 ----------<<<<<

            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message + "\n\r" + ex.StackTrace, -1, MessageBoxButtons.OK);
            }
            finally
            {
                this._isEvent = true;
                this._isInitialize = false;
                this._isEventAutoFillColumn = true;
            }
        }

        /// <summary>
        /// グリッドリサイズタイマーイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2007.3.30</br>
        /// </remarks>
        private void ColReSize_Timer_Tick(object sender, EventArgs e)
        {
            this.ColReSize_Timer.Enabled = false;

            this.gridResult.Refresh();
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
        /// <br>Date        : 2007.2.11</br>
        /// </remarks>
        private void gridResult_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.InitializeLayoutGridCommon(this.gridResult, e);
        }

        /// <summary>
        /// 検索結果グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 検索結果グリッド上でキーが押下された時に発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.1</br>
        /// </remarks>
        private void gridResult_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if ((this.gridResult.ActiveRow != null) &&
                            (this.gridResult.ActiveRow.Index == 0))
                        {
                            if (this.Standard_UGroupBox.Visible == false &&
                                this.Detail_UGroupBox.Visible == false)
                            {
                                return;
                            }

                            this.gridResult.ActiveRow.Selected = false;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                            //this.gridResult.ActiveRow = null;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                            if (this.Detail_UGroupBox.Expanded)
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                //switch ( this._searchMode )
                                //{
                                //    case ( int ) emSearchMode.GoodsStock:			// 商品在庫
                                //    case ( int ) emSearchMode.Goods:						// 商品
                                //        {
                                //            this.MediumGoodsGanreName_tEdit.Focus();
                                //            break;
                                //        }
                                //    case ( int ) emSearchMode.Product:					// 製番
                                //    case ( int ) emSearchMode.Stock:		// 在庫＆製番
                                //    case ( int ) emSearchMode.ProductwitchStock: {
                                //            this.StockTelNo_tEdit.Focus();
                                //            break;
                                //        }
                                //}
                                this.EnterpriseGanreCode_tEdit.Focus();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                            }
                            else
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                //this.CellphoneModelCode_tEdit.Focus();
                                this.GoodsNameKana_tEdit.Focus();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                            }
                        }
                        break;
                    }
                // ------- DEL BY 凌小青 on 2011/11/21 ------->>>>>>>>>>>>>
                //case Keys.Down:
                //    {
                //        if ((this.gridResult.ActiveRow != null) &&
                //            (this.gridResult.ActiveRow.Index == this.gridResult.Rows.Count - 1))
                //        {
                //            this.gridResult.ActiveRow.Selected = false;
                //            this.gridResult.ActiveRow = null;

                //            this.AutoFillToGridColumn_CheckEditor.Focus();
                //        }
                //        break;
                //    }
                // ------- DEL BY 凌小青 on 2011/11/21 -------<<<<<<<<<<<<<<
                // 2008.10.03 STOKUNAGA ADD START
                case Keys.Right:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        // グリッド表示を右にスクロール
                        this.gridResult.DisplayLayout.ColScrollRegions[0].Position = this.gridResult.DisplayLayout.ColScrollRegions[0].Position + 40;
                        break;
                    }
                case Keys.Left:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        // グリッド表示を左にスクロール
                        this.gridResult.DisplayLayout.ColScrollRegions[0].Position = this.gridResult.DisplayLayout.ColScrollRegions[0].Position - 40;
                        break;
                    }
                // 2008.10.03 STOKUNAGA ADD END
                case Keys.Enter:
                    {

#if false
						if (this._searchMode == (int)emSearchMode.StockProduct)
						{
							// 製番＆在庫モード
							DialogResult dr = this.ShowDetail(this.gridResult.ActiveRow);

							if (dr == DialogResult.OK)
								this.DialogResult = DialogResult.OK;
						}
						else
						{
							// 複数選択ありの場合は処理しない
							if (this.IsMultiSelect) return;

							Infragistics.Win.UltraWinToolbars.ButtonTool decideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
							if (decideButton.SharedProps.Enabled)
							{
								Infragistics.Win.UltraWinGrid.UltraGridRow row = this.gridResult.ActiveRow;
								if (row != null)
								{
									this.SelectRowData(row);
									this.DialogResult = DialogResult.OK;
								}
							}
						}
#endif
                        // 複数選択ありの場合は処理しない
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //if ( this._searchMode != ( int ) emSearchMode.Stock && this.IsMultiSelect ) return;
                        if (this.IsMultiSelect) return;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                        Infragistics.Win.UltraWinToolbars.ButtonTool decideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
                        if (decideButton.SharedProps.Enabled)
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.gridResult.ActiveRow;
                            if (row != null)
                            {
                                this.SelectRowData(row);
                                this.DialogResult = DialogResult.OK;
                            }
                        }


                        //if (this._searchMode != (int)emSearchMode.Stock && this.IsMultiSelect) return;

                        //Infragistics.Win.UltraWinToolbars.ButtonTool decideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Decision];
                        //if (decideButton.SharedProps.Enabled)
                        //{
                        //  Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow = this.gridResult.ActiveRow;
                        //  if (ultraGridRow != null)
                        //  {
                        //    this.SelectRowData(ultraGridRow);

                        //    this.DialogResult = DialogResult.OK;
                        //    this.Close();
                        //  }
                        //}
                        break;
                    }
                case Keys.Space:
                    {
                        if (!this.IsMultiSelect) return;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //if (this._searchMode == (int)emSearchMode.Stock) return;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                        Infragistics.Win.UltraWinGrid.UltraGridRow row = this.gridResult.ActiveRow;
                        if (row != null)
                        {
                            bool isSelected = (bool)row.Cells[CT_Select].Value;

                            // 選択・非選択状態を変更します
                            this.ChangedSelect(!isSelected, row);
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 検索結果グリッド上でクリックされた時に発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.5</br>
        /// </remarks>
        private void gridResult_Click(object sender, EventArgs e)
        {
            // イベントソースの取得
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            try
            {
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

                if (objRow == null) return;

                // マウスポインターが行の上にあるかチェック。
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                    (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

                // 選択・非選択セル以外はキャンセル
                if (objCell == null || objCell.Column.Key != CT_Select) return;

                bool isSelected = (bool)objRow.Cells[CT_Select].Value;

                // 選択・非選択状態を変更します
                this.ChangedSelect(!isSelected, objRow);
            }
            catch
            {
            }
        }

        private void gridResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// グリッドダブルクリック イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : コントロールがダブルクリックされた際に発生します。 </br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2007.02.05</br>
        /// </remarks>
        private void gridResult_DoubleClick(object sender, EventArgs e)
        {
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

            if (objRow != null)
            {
#if false				
				// 製番 ＆ 在庫検索の場合
				if (this._searchMode == (int)emSearchMode.StockProduct)
				{
					// 製番選択画面起動
					DialogResult dr = this.ShowDetail(objRow);
				
					if (dr == DialogResult.OK)
						this.DialogResult = DialogResult.OK;
				}
				// それ以外
				else
				{
					// 複数選択でない場合
					if (!this.IsMultiSelect)
					{
						this.SelectRowData(objRow);
						this.DialogResult = DialogResult.OK;
					}
				}
#endif
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (!this.IsMultiSelect || this._searchMode == (int)emSearchMode.Stock)
                if (!this.IsMultiSelect)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                {
                    this.SelectRowData(objRow);
                    this.DialogResult = DialogResult.OK;
                }

            }
        }

        /// <summary>
        /// セルボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : セル上のボタンをクリックした際に発生します。</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.02.07</br>
        /// </remarks>
        private void gridResult_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 詳細製番列の場合
            //if (e.Cell.Column.Key == CT_ProductButton)
            //{
            //    // 製番選択画面起動
            //    DialogResult dr = this.ShowDetail(e.Cell.Row);

            //    if (dr == DialogResult.OK)
            //        this.DialogResult = DialogResult.OK;
            //}
            //// 選択ボタンの場合
            //else if (e.Cell.Column.Key == CT_SelectButton)
            //{
            //    bool isSelected = (bool)e.Cell.Row.Cells[CT_Select].Value;

            //    // 選択・非選択状態を変更します
            //    this.ChangedSelect(!isSelected, e.Cell.Row);
            //}

            bool isSelected = (bool)e.Cell.Row.Cells[CT_Select].Value;
            // 選択・非選択状態を変更します
            this.ChangedSelect(!isSelected, e.Cell.Row);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        #endregion

        #region < UltraButtonのイベント関連 >

        /// <summary>
        /// 機種ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 機種ガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.1</br>
        /// </remarks>
        private void CellphoneModelGuide_Button_Click(object sender, EventArgs e)
        {
            //CellphoneModel cellphoneModel;

            //// ガイド起動
            //int status = this._goodsAcs.ExecuteCellphoneModelGuid(this._enterpriseCode,
            //  this.StrToIntDefOfValue(this.CarrierName_tEdit.Value,0),
            //  out cellphoneModel);
            //if (status != 0) return;

            //if (!this.CellphoneModelCode_tEdit.DataText.Trim().Equals(cellphoneModel.CellphoneModelCode.Trim()))
            //{
            //  this.CellphoneModelCode_tEdit.DataText = cellphoneModel.CellphoneModelCode;

            //  // 検索処理
            //  this.SearchMainProc(this.CellphoneModelGuide_Button);
            //}
        }

        #region ___FIXED___

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 倉庫ガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.1</br>
        /// <br>Update Note : 2009/09/07       汪千来</br>
        /// <br>	        : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// </remarks>
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._isButtonClick) return;
                this._isButtonClick = false;

                Warehouse warehouse;

                // ガイド起動
                string sectionCode = string.Empty;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.01 TOKUNAGA MODIFY START
                //if (this.Section_ComboEditor.Value != null)
                //    sectionCode = this.Section_ComboEditor.Value.ToString();
                //sectionCode = this.tEdit_SectionCode.Text.Trim();    // DEL 2009/09/07
                sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();      // ADD 2009/09/07
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.01 TOKUNAGA MODIFY END

                int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, sectionCode);
                if (status != 0) return;

                if (this.uLabel_WarehouseName.Tag == null || !this.uLabel_WarehouseName.Tag.Equals(warehouse.WarehouseCode))
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.07 TOKUNAGA ADD START
                    //this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.ToString().PadLeft(4, '0');   // DEL 2009/09/07
                    this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.Trim().ToString().PadLeft(4, '0');  // ADD 2009/09/07
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.07 TOKUNAGA ADD END

                    this.uLabel_WarehouseName.Tag = warehouse.WarehouseCode.ToString();
                    this.uLabel_WarehouseName.Text = warehouse.WarehouseName;

                    // 前回情報退避
                    //_prevHeaderInfo.WarehouseCode = warehouse.WarehouseCode;      // DEL 2009/09/07
                    _prevHeaderInfo.WarehouseCode = warehouse.WarehouseCode.Trim();     // ADD 2009/09/07
                    _prevHeaderInfo.WarehouseName = warehouse.WarehouseName;

                    // 複数条件指定でなければ
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.01 TOKUNAGA MODIFY START
                    //if (!this.Multi_CheckEditor.Checked)
                    // 複数条件指定チェックは常にON(UI上には表示しない)
                    if (false)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.01 TOKUNAGA MODIFY END
                    {
                        // 検索処理
                        this.SearchMainProc(this.uLabel_WarehouseName);
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this._isButtonClick = true;
            }
        }

        #endregion // ___FIXED___

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 仕入先ガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.1</br>
        /// <br>Update Note : 2009/11/05       呉元嘯</br>
        /// <br>	        : Redmine#1114対応</br>
        /// </remarks>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._isButtonClick) return;
                this._isButtonClick = false;

                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //this._customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
                //this._customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSelected);
                //this._customerSearchForm.ShowDialog(this);

                Supplier supplier;
                //----------UPD 2009/11/05---------->>>>>
                // this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
                int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
                if (status != 0) return;
                //----------UPD 2009/11/05----------<<<<<
                this.SupplierSelected(supplier);
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            catch (Exception)
            {
            }
            finally
            {
                this._isButtonClick = true;
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// 事業者ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">イベントソース</param>
        ///// <param name="e">イベントデータ</param>
        ///// <remarks>
        ///// <br>Note		: 事業者ガイドボタンをクリックしたタイミングで発生します。</br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2007.2.1</br>
        ///// </remarks>
        //private void CarrierEpGuide_Button_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!this._isButtonClick) return;
        //        this._isButtonClick = false;

        //        CarrierEp carrierEp;

        //        // ガイド起動
        //        int status = this._carrierEpAcs.ExecuteGuid(this._enterpriseCode, out carrierEp);
        //        if (status != 0) return;

        //        if (this.CarrierEpName_tEdit.Tag == null || TStrConv.StrToIntDef(this.CarrierEpName_tEdit.Tag.ToString(), 0) != carrierEp.CarrierEpCode)
        //        {
        //            this.CarrierEpName_tEdit.Tag = carrierEp.CarrierEpCode.ToString();
        //            this.CarrierEpName_tEdit.DataText = carrierEp.CarrierEpName;

        //            // 複数条件指定でなければ
        //            if (!this.Multi_CheckEditor.Checked)
        //            {
        //                // 検索処理
        //                this.SearchMainProc(this.CarrierEpName_tEdit);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        this._isButtonClick = true;
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// キャリアガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CarrierGuide_Button_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!this._isButtonClick) return;
        //        this._isButtonClick = false;

        //        Carrier carrier;

        //        // ガイド起動
        //        int status = this._goodsAcs.ExecuteCarrierGuid(this._enterpriseCode, out carrier);
        //        if (status != 0) return;

        //        if (this.CarrierName_tEdit.Tag == null || TStrConv.StrToIntDef(this.CarrierName_tEdit.Tag.ToString(), 0) != carrier.CarrierCode)
        //        {
        //            this.CarrierName_tEdit.Tag = carrier.CarrierCode.ToString();
        //            this.CarrierName_tEdit.DataText = carrier.CarrierName;

        //            // 複数条件指定でなければ
        //            if (!this.Multi_CheckEditor.Checked)
        //            {
        //                // 検索処理
        //                this.SearchMainProc(this.CarrierName_tEdit);
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        this._isButtonClick = true;
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// ＢＬ商品コードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGoodsCodeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._isButtonClick) return;
                this._isButtonClick = false;

                BLGoodsCdUMnt blGoodsCdUMnt;
                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status != 0) return;

                if (this.tEdit_BLGoodsName.Tag == null || TStrConv.StrToIntDef(this.tEdit_BLGoodsName.Tag.ToString(), 0) != blGoodsCdUMnt.BLGoodsCode)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.07 TOKUNAGA MODIFY START
                    this.tEdit_BLGoodsName.Tag = blGoodsCdUMnt.BLGoodsCode.ToString();
                    this.tEdit_BLGoodsName.DataText = blGoodsCdUMnt.BLGoodsFullName;
                    this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.07 TOKUNAGA MODIFY END

                    // 前回情報退避

                    _prevHeaderInfo.BLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                    _prevHeaderInfo.BLGoodsCodeName = blGoodsCdUMnt.BLGoodsFullName;

                    // 複数条件指定でなければ
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                    //if ( !this.Multi_CheckEditor.Checked ) {
                    if (false)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
                    {
                        // 検索処理
                        this.SearchMainProc(this.tEdit_BLGoodsName);
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this._isButtonClick = true;
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA DEL START
        ///// <summary>
        ///// 商品区分詳細ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void DetailGoodsGanreGide_Button_Click(object sender, EventArgs e)
        {
            //    try {
            //        if ( !this._isButtonClick ) return;
            //        this._isButtonClick = false;

            //        DGoodsGanre dGoodsGanre;

            //        int status = this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre);
            //        if ( status != 0 ) return;

            //        if ( this.DetailGoodsGanreName_tEdit.Tag == null || this.DetailGoodsGanreName_tEdit.Tag.ToString() != dGoodsGanre.DetailGoodsGanreCode ) {
            //            this.DetailGoodsGanreName_tEdit.Tag = dGoodsGanre.DetailGoodsGanreCode;
            //            this.DetailGoodsGanreName_tEdit.DataText = dGoodsGanre.DetailGoodsGanreName;

            //            if ( this.Multi_CheckEditor.Checked )
            //            {
            //                // 商品区分グループに適用
            //                this.LargeGoodsGanreName_tEdit.Tag = dGoodsGanre.LargeGoodsGanreCode;
            //                this.LargeGoodsGanreName_tEdit.DataText = dGoodsGanre.LargeGoodsGanreName;
            //                _prevHeaderInfo.LargeGoodsGanreCode = dGoodsGanre.LargeGoodsGanreCode;
            //                _prevHeaderInfo.LargeGoodsGanreName = dGoodsGanre.LargeGoodsGanreName;

            //                // 商品区分に適用
            //                this.MediumGoodsGanreName_tEdit.Tag = dGoodsGanre.MediumGoodsGanreCode;
            //                this.MediumGoodsGanreName_tEdit.DataText = dGoodsGanre.MediumGoodsGanreName;
            //                _prevHeaderInfo.MediumGoodsGanreCode = dGoodsGanre.MediumGoodsGanreCode;
            //                _prevHeaderInfo.MediumGoodsGanreName = dGoodsGanre.MediumGoodsGanreName;
            //            }

            //            // 前回情報退避
            //            _prevHeaderInfo.DetailGoodsGanreCode = dGoodsGanre.DetailGoodsGanreCode;
            //            _prevHeaderInfo.DetailGoodsGanreName = dGoodsGanre.DetailGoodsGanreName;

            //            // 複数条件指定でなければ
            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
            //            //if ( !this.Multi_CheckEditor.Checked )
            //            if ( false )
            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
            //            {
            //                // 検索処理
            //                this.SearchMainProc(this.DetailGoodsGanreName_tEdit);
            //            }
            //        }
            //    }
            //    catch ( Exception ) {
            //    }
            //    finally {
            //        this._isButtonClick = true;
            //    }
        }
        ///// <summary>
        ///// 自社分類コードガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void EnterpriseGanreCodeGuide_Button_Click(object sender, EventArgs e)
        {
            //    try {
            //        if ( !this._isButtonClick ) return;
            //        this._isButtonClick = false;

            //        UserGdBd userGdBd;
            //        int status = this._searchStockAcs.ExecuteUserGuideGuid(this._enterpriseCode, out userGdBd);
            //        if ( status != 0 ) return;

            //        if ( this.EnterpriseGanreCode_tEdit.Tag == null || this.EnterpriseGanreCode_tEdit.Tag.ToString() != userGdBd.GuideCode.ToString() ) {
            //            this.EnterpriseGanreCode_tEdit.Tag = userGdBd.GuideCode;
            //            this.EnterpriseGanreCode_tEdit.DataText = userGdBd.GuideName;

            //            // 前回情報退避
            //            _prevHeaderInfo.EnterpriseGanreCode = userGdBd.GuideCode;
            //            _prevHeaderInfo.EnterpriseGanreName = userGdBd.GuideName;

            //            // 複数条件指定でなければ
            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
            //            //if ( !this.Multi_CheckEditor.Checked )
            //            // このメソッド自体必要なくなるかも（ボタンがなくなる）
            //            if (false)
            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
            //            {
            //                // 検索処理
            //                this.SearchMainProc(this.EnterpriseGanreCode_tEdit);
            //            }
            //        }
            //    }
            //    catch ( Exception ) {
            //    }
            //    finally {
            //        this._isButtonClick = true;
            //    }
        }
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA DEL END

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: メーカーガイドボタンをクリックしたタイミングで発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.1</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this._isButtonClick) return;
                this._isButtonClick = false;

                MakerUMnt maker;

                // ガイド起動
                int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
                if (status != 0) return;

                if (this.tNedit_GoodsMakerCd.Tag == null || TStrConv.StrToIntDef(this.tNedit_GoodsMakerCd.Tag.ToString(), 0) != maker.GoodsMakerCd)
                {
                    this.tNedit_GoodsMakerCd.Tag = maker.GoodsMakerCd.ToString();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.07 TOKUNAGA MODIFY START
                    this.tNedit_GoodsMakerCd.Text = maker.GoodsMakerCd.ToString();
                    this.uLabel_MakerName.Text = maker.MakerName;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.07 TOKUNAGA MODIFY END

                    // 前回情報退避
                    _prevHeaderInfo.GoodsMakerCd = maker.GoodsMakerCd;
                    _prevHeaderInfo.MakerName = maker.MakerName;

                    // 複数条件指定でなければ
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                    //if ( !this.Multi_CheckEditor.Checked )
                    if (false)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
                    {
                        // 検索処理
                        this.SearchMainProc(this.tNedit_GoodsMakerCd);
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this._isButtonClick = true;
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA DEL START
        ///// <summary>
        ///// 商品グループガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">イベントソース</param>
        ///// <param name="e">イベントデータ</param>
        ///// <remarks>
        ///// <br>Note		: 商品グループガイドボタンをクリックしたタイミングで発生します。</br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2007.2.1</br>
        ///// </remarks>
        private void LargeGoodsGanreCodeGuide_uButton_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            //        if (!this._isButtonClick) return;
            //        this._isButtonClick = false;

            //        LGoodsGanre lGoodsGanre;

            //        // ガイド起動
            //        int status = this._goodsAcs.ExecuteLGoodsGanreGuid(this._enterpriseCode, out lGoodsGanre);
            //        if (status != 0) return;

            //        if (this.LargeGoodsGanreName_tEdit.Tag == null || !this.LargeGoodsGanreName_tEdit.Tag.Equals(lGoodsGanre.LargeGoodsGanreCode))
            //        {
            //            this.LargeGoodsGanreName_tEdit.Tag = lGoodsGanre.LargeGoodsGanreCode;
            //            this.LargeGoodsGanreName_tEdit.DataText = lGoodsGanre.LargeGoodsGanreName;

            //            // 前回情報退避
            //            _prevHeaderInfo.LargeGoodsGanreCode = lGoodsGanre.LargeGoodsGanreCode;
            //            _prevHeaderInfo.LargeGoodsGanreName = lGoodsGanre.LargeGoodsGanreName;

            //            // 複数条件指定でなければ
            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
            //            //if ( !this.Multi_CheckEditor.Checked )
            //            // このメソッド自体必要なくなるかも（ボタンがなくなる）
            //            if (false)
            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
            //            {
            //                // 検索処理
            //                this.SearchMainProc(this.LargeGoodsGanreName_tEdit);
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    finally
            //    {
            //        this._isButtonClick = true;
            //    }
        }

        ///// <summary>
        ///// 商品区分ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">イベントソース</param>
        ///// <param name="e">イベントデータ</param>
        ///// <remarks>
        ///// <br>Note		: 商品区分ガイドボタンをクリックしたタイミングで発生します。</br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2007.2.1</br>
        ///// </remarks>
        private void MediumGoodsGanreGide_Button_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            //        if (!this._isButtonClick) return;
            //        this._isButtonClick = false;

            //        MGoodsGanre mGoodsGanre;

            //        string lGoodsGanreCode = string.Empty;

            //        // 複数条件指定時のみ商品グループコードを取得する
            //        if (this.Multi_CheckEditor.Checked)
            //        {
            //            if (this.LargeGoodsGanreName_tEdit.Tag != null)

            //                lGoodsGanreCode = this.LargeGoodsGanreName_tEdit.Tag.ToString();
            //        }

            //        // ガイド起動
            //        int status = this._goodsAcs.ExecuteMGoodsGanreGuid(this._enterpriseCode,
            //            lGoodsGanreCode,
            //            out mGoodsGanre);
            //        if (status != 0) return;

            //        if (this.MediumGoodsGanreName_tEdit.Tag == null || !this.MediumGoodsGanreName_tEdit.Tag.ToString().Equals(mGoodsGanre.MediumGoodsGanreCode))
            //        {

            //            //if (this.Multi_CheckEditor.Checked && this.LargeGoodsGanreName_tEdit.Tag != null &&
            //            //    !this.LargeGoodsGanreName_tEdit.Tag.ToString().Equals(string.Empty))
            //            //{
            //            //    this.LargeGoodsGanreName_tEdit.Tag = mGoodsGanre.LargeGoodsGanreCode;
            //            //    this.LargeGoodsGanreName_tEdit.DataText = mGoodsGanre.LargeGoodsGanreName;
            //            //}

            //            if ( this.Multi_CheckEditor.Checked )
            //            {
            //                // 商品区分グループに適用
            //                this.LargeGoodsGanreName_tEdit.Tag = mGoodsGanre.LargeGoodsGanreCode;
            //                this.LargeGoodsGanreName_tEdit.DataText = mGoodsGanre.LargeGoodsGanreName;
            //                _prevHeaderInfo.LargeGoodsGanreCode = mGoodsGanre.LargeGoodsGanreCode;
            //                _prevHeaderInfo.LargeGoodsGanreName = mGoodsGanre.LargeGoodsGanreName;
            //            }

            //            this.MediumGoodsGanreName_tEdit.Tag = mGoodsGanre.MediumGoodsGanreCode;
            //            this.MediumGoodsGanreName_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;

            //            // 前回情報退避
            //            _prevHeaderInfo.MediumGoodsGanreCode = mGoodsGanre.MediumGoodsGanreCode;
            //            _prevHeaderInfo.MediumGoodsGanreName = mGoodsGanre.MediumGoodsGanreName;


            //            // 複数条件指定でなければ
            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
            //            //if ( !this.Multi_CheckEditor.Checked )
            //            // このメソッド自体必要なくなるかも（ボタンがなくなる）
            //            if (false)
            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
            //            {
            //                // 検索処理
            //                this.SearchMainProc(this.MediumGoodsGanreName_tEdit);
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    finally
            //    {
            //        this._isButtonClick = true;
            //    }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA DEL END

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 検索ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.1</br>
        /// </remarks>
        private void Search_Button_Click(object sender, EventArgs e)
        {

            Control nextCtrl = null;
            // 検索条件取得
            StockSearchPara searchPara = this.GetSearchParameter();
            //if (this.CheckBeforeSearch(sender, searchPara))  // T.Nishi 2012/04/10 DEL
            //{      // T.Nishi 2012/04/10 DEL
                // 今回の検索条件を保持
                this._prevSearchParam = searchPara.Clone();
                this._prevSortDiv = (int)this.SortDiv_tComboEditor.Value;           //ADD 2009/04/02 不具合対応[12838]

                int status = this.SearchMainProc(searchPara);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.gridResult.Focus();
                            if (this.gridResult.Rows.Count > 0)
                            {
                                // --- ADD 2012/09/18 ---------->>>>>
                                this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText].SharedProps.Enabled  = true;
                                this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel].SharedProps.Enabled = true;
                                // --- ADD 2012/09/18 ----------<<<<<

                                this.gridResult.ActiveRow = this.gridResult.Rows[0];
                                this.gridResult.Rows[0].Selected = true;
                            }
                            break;
                        }
                }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
            //}
            //else
            //{
            //    if (nextCtrl != null)
            //        nextCtrl.Focus();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
        }

        /// <summary>
        /// ソート順変更ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		　: ソート順ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer: 18012 Y.Sasaki</br>
        /// <br>Date		　: 2007.2.9</br>
        /// </remarks>
        private void Oder_uButton_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( this._searchMode == ( int ) emSearchMode.Product || 
            //    this._searchMode == (int)emSearchMode.ResultProduct ||
            //    this._searchMode == (int)emSearchMode.ResultProductwitchStock ||
            //    this._searchMode == (int)emSearchMode.ProductwitchStock)
            //{

            //    Infragistics.Win.Misc.UltraButton button = sender as Infragistics.Win.Misc.UltraButton;

            //    if (button == null) return;

            //    //// ボタンスタイルの変更
            //    //this.ChangeOderButtonStyle(button);

            //    int oderNo = TStrConv.StrToIntDef(button.Tag.ToString(), 0);

            //    switch (oderNo)
            //    {
            //        case 1:
            //            {
            //                // 製番順
            //                this._productStockDataView.Sort = this._defaultProductSort + ',' + CT_ProductNumber;
            //                break;
            //            }
            //        case 2:
            //            {
            //                // 仕入日　降順
            //                this._productStockDataView.Sort = this._defaultProductSort + ',' + CT_StockDate + " DESC" + ',' + CT_ProductNumber;
            //                break;
            //            }
            //        case 3:
            //            {
            //                // 仕入日　昇順
            //                this._productStockDataView.Sort = this._defaultProductSort + ',' + CT_StockDate + ',' + CT_ProductNumber;
            //                break;
            //            }
            //        case 4:
            //            {
            //                // 仕入単価　降順
            //                this._productStockDataView.Sort = this._defaultProductSort + ',' + CT_StockUnitPrice + " DESC" + ',' + CT_ProductNumber;
            //                break;
            //            }
            //        case 5:
            //            {
            //                // 仕入日　昇順
            //                this._productStockDataView.Sort = this._defaultProductSort + ',' + CT_StockUnitPrice + ',' + CT_ProductNumber;
            //                break;
            //            }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>
        /// 先頭ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		　: 先頭ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer: 18012 Y.Sasaki</br>
        /// <br>Date		　: 2007.2.13</br>
        /// </remarks>
        private void Top_uButton_Click(object sender, EventArgs e)
        {
            if (this.gridResult.Rows.Count == 0) return;

            // 先頭行へ配置
            this.gridResult.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, false, false);
        }

        /// <summary>
        /// 最後尾ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		　: 最後尾行ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer: 18012 Y.Sasaki</br>
        /// <br>Date		　: 2007.2.13</br>
        /// </remarks>
        private void Last_uButton_Click(object sender, EventArgs e)
        {
            if (this.gridResult.Rows.Count == 0) return;

            this.gridResult.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid, false, false);

        }

        /// <summary>
        /// 上ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		　: 上ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer: 18012 Y.Sasaki</br>
        /// <br>Date		　: 2007.2.13</br>
        /// </remarks>
        private void Up_uButton_Click(object sender, EventArgs e)
        {
            if (this.gridResult.Rows.Count == 0) return;
            this.gridResult.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpRow, false, false);
        }

        /// <summary>
        /// 下ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		　: 上ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer: 18012 Y.Sasaki</br>
        /// <br>Date		　: 2007.2.13</br>
        /// </remarks>
        private void Down_uButton_Click(object sender, EventArgs e)
        {
            if (this.gridResult.Rows.Count == 0) return;
            this.gridResult.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownRow, false, false);
        }

        /// <summary>
        /// 左端ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		　: 左端ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer: 18012 Y.Sasaki</br>
        /// <br>Date		　: 2007.2.13</br>
        /// </remarks>
        private void LeftFirst_uButton_Click(object sender, EventArgs e)
        {
            if (this.gridResult.Rows.Count == 0) return;

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.gridResult.DisplayLayout.Bands[0];

            // 最左端のセル名を取得する
            string columnNm = string.Empty;
            for (int i = 0; i < band.Columns.Count - 1; i++)
            {
                if (band.Columns[i].Hidden == false)
                {
                    columnNm = band.Columns[i].Key.ToString();
                    break;
                }
            }

            // 可動初期位置設定
            if (!columnNm.Equals(string.Empty))
                this.gridResult.ActiveColScrollRegion.ScrollColIntoView(band.Columns[columnNm], true);
        }

        /// <summary>
        /// 右端ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		　: 右端ボタンが押下されたタイミングで発生します。</br>
        /// <br>Programmer: 18012 Y.Sasaki</br>
        /// <br>Date		　: 2007.2.13</br>
        /// </remarks>
        private void RightLast_uButton_Click(object sender, EventArgs e)
        {
            if (this.gridResult.Rows.Count == 0) return;

            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.gridResult.DisplayLayout.Bands[0];

            // 最左端のセル名を取得する
            string columnNm = string.Empty;
            for (int i = band.Columns.Count - 1; i >= 0; i--)
            {
                if (band.Columns[i].Hidden == false)
                {
                    columnNm = band.Columns[i].Key.ToString();
                    break;
                }
            }

            // 可動初期位置設定
            if (!columnNm.Equals(string.Empty))
                this.gridResult.ActiveColScrollRegion.ScrollColIntoView(band.Columns[columnNm], true);
        }

        #endregion

        #region < UltraCheckEditor系のイベント関連 >

        /// <summary>
        /// 自動調整チェック変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 列の自動調整のチェックが切り替わったタイミングで発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.2.2</br>
        /// </remarks>
        private void AutoFillToGridColumn_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this._isInitialize) return;
            if (!this._isEventAutoFillColumn) return;

            if (this.AutoFillToGridColumn_CheckEditor.Checked)
            {
                // 列幅をオートに設定
                this.gridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.gridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                this.gridResult.Refresh();
            }
            // カラムサイズ調整
            this.ColumnPerformAutoResize();

        }

        #endregion

        #region < tComboEditor系のイベント関連 >
        /// <summary>
        /// フォントサイズコンボの値変更イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2007.2.2</br>
        /// </remarks>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.FontSize_tComboEditor.Value, CT_Default_FontSize);
            float fontPoint = (float)a;

            this.gridResult.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            this.gridResult.Refresh();
            this.ColumnPerformAutoResize();

        }
        #endregion

        #region < UltraToolbarsManagerのイベント関連 >

        /// <summary>
        /// UltraToolbarのクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <br>Update Note: 2009/09/07       汪千来</br>
        ///	<br>		   : 表示データが存在するが「該当データなし」となる為、修正</br>
        /// <br>	       : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        private void Main_UToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // ---ADD 2009/09/07  ----->>>>>
            // 一括ゼロ詰め処理	
            uiSetControl1.SettingAllControlsZeroPaddedText();
            // ---ADD 2009/09/07  -----<<<<<

            switch (e.Tool.Key)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // -------------------------------------------------------------------------------
                // 終了（閉じる）
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Quit:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                        _extractPauseFlag = false;
                        _extractCancelFlag = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // -------------------------------------------------------------------------------
                // 終了
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Back:
                    {
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }

                // -------------------------------------------------------------------------------
                // 取消
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Undo:
                    {
                        // 画面を初期化する
                        this.InitialDisplay(1);

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                        progressBar1.Visible = false;
                        ultraLabel1.Visible = false;
                        ultraLabel2.Visible = false;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

                        // 検索モードにより初期フォーカス位置を設定する
                        switch (this._searchMode)
                        {

                            case (int)emSearchMode.Goods:
                                // 商品検索の場合
                                //this.tEdit_GoodsNo.Focus();
                                _firstControl.Focus();
                                break;
                            case (int)emSearchMode.GoodsStock:
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                //case (int)emSearchMode.Product:
                                //case (int)emSearchMode.Stock:
                                //case (int)emSearchMode.ProductwitchStock:
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                // 在庫検索の場合
                                // 製番検索の場合
                                // 在庫＆製番検索の場合
                                //this.tEdit_GoodsNo.Focus();
                                _firstControl.Focus();

                                break;

                            case (int)emSearchMode.ResultStock:
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                //case (int)emSearchMode.ResultStockNoButton:
                                //case (int)emSearchMode.ResultProduct:
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                this.gridResult.Focus();
                                break;
                        }

                        break;
                    }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // -------------------------------------------------------------------------------
                // 検索
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Search:
                    {
                        //if (this.tEdit_SectionCode.Focused) tEdit_SectionCode_Leave(null, null);      // DEL 2009/09/07
                        if (this.tEdit_SectionCodeAllowZero.Focused) tEdit_SectionCodeAllowZero_Leave(null, null);      // ADD 2009/09/07
                        Control nextCtrl = null;
                        // 検索条件取得
                        StockSearchPara searchPara = this.GetSearchParameter();
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                            //if (this.CheckBeforeSearch(sender, searchPara))
                            //{
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
                            // 今回の検索条件を保持
                            this._prevSearchParam = searchPara.Clone();
                            this._prevSortDiv = (int)this.SortDiv_tComboEditor.Value;           //ADD 2009/04/02 不具合対応[12838]

                            // --- ADD 2012/09/18 ---------->>>>>
                            // テキスト出力ボタンとExcel出力ボタンを無効
                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText].SharedProps.Enabled = false;
                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel].SharedProps.Enabled = false;
                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Configuration].SharedProps.Enabled = false;
                            // --- ADD 2012/09/18 ----------<<<<<

                            int status = this.SearchMainProc(searchPara);

                            // --- ADD 2012/09/18 ---------->>>>>
                            // 検索処理が終わったら設定ボタンは有効
                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Configuration].SharedProps.Enabled = true;
                            // --- ADD 2012/09/18 ----------<<<<<

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                            if (_extractCancelFlag == true)
                            {
                                return;
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                            switch (status)
                            {
                                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                    {
                                        this.gridResult.Focus();
                                        if (this.gridResult.Rows.Count > 0)
                                        {
                                            // --- ADD 2012/09/18 ---------->>>>>
                                            // テキスト出力ボタンとExcel出力ボタンを有効
                                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractText].SharedProps.Enabled = true;
                                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ExtractExcel].SharedProps.Enabled = true;
                                            // --- ADD 2012/09/18 ----------<<<<<

                                            this.gridResult.ActiveRow = this.gridResult.Rows[0];
                                            this.gridResult.Rows[0].Selected = true;
                                        }
                                        break;
                                    }
                            }
// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                         //}
                        //else
                        //{
                       //     if (nextCtrl != null)
                       //         nextCtrl.Focus();
                      // }
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

                //2012/04/10 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 

                // -------------------------------------------------------------------------------
                // 中断
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Stop:
                    {
                        _searchStockAcs.ExtractCancelFlag = true;
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 停止
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Pause:
                    {
                        _extractPauseFlag = true;
                        Infragistics.Win.UltraWinToolbars.ButtonTool pauseButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Pause];
                        pauseButton.SharedProps.Visible = false;
                        Infragistics.Win.UltraWinToolbars.ButtonTool restartButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ReStart];
                        restartButton.SharedProps.Visible = true;
                        Infragistics.Win.UltraWinToolbars.ButtonTool stopButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Stop];
                        stopButton.SharedProps.Enabled = false;
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 再開
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_ReStart:
                    {
                        _extractPauseFlag = false;
                        Infragistics.Win.UltraWinToolbars.ButtonTool restartButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_ReStart];
                        restartButton.SharedProps.Visible = false;
                        Infragistics.Win.UltraWinToolbars.ButtonTool pauseButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Pause];
                        pauseButton.SharedProps.Visible = true;
                        Infragistics.Win.UltraWinToolbars.ButtonTool stopButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Stop];
                        stopButton.SharedProps.Enabled = true;
                        break;
                    }
                //2012/04/10 T.Nishi ADD<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // -------------------------------------------------------------------------------
                // 確定
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Decision:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //if (this._searchMode != (int)emSearchMode.Stock && this._isMultiSelect)
                        if (this._isMultiSelect)
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                        {
                            // 複数選択の場合
                            this.MultiSelectRowData();
                        }
                        else
                        {
                            // 単一選択の場合
                            if (this.gridResult.ActiveRow != null)
                            {
                                this.SelectRowData(this.gridResult.ActiveRow);
                            }
                        }

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                        _extractPauseFlag = false;
                        _extractCancelFlag = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

                        this.DialogResult = DialogResult.OK;

                        break;
                    }
                // ADD 2008/10/09 不具合対応[6382] ---------->>>>>
                case "ButtonTool_Decision":
                    {
                        if (this._isMultiSelect)
                        {
                            // 複数選択の場合
                            this.MultiSelectRowData();
                        }
                        else
                        {
                            // 単一選択の場合
                            if (this.gridResult.ActiveRow != null)
                            {
                                this.SelectRowData(this.gridResult.ActiveRow);
                            }
                        }

                        this.DialogResult = DialogResult.OK;

                        break;
                    }
                case "ButtonTool_Close":
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 画面を初期化する
                        this.InitialDisplay(1);

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
                        progressBar1.Visible = false;
                        ultraLabel1.Visible = false;
                        ultraLabel2.Visible = false;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

                        // 検索モードにより初期フォーカス位置を設定する
                        switch (this._searchMode)
                        {

                            case (int)emSearchMode.Goods:
                                // 商品検索の場合
                                //this.tEdit_GoodsNo.Focus();
                                _firstControl.Focus();
                                break;
                            case (int)emSearchMode.GoodsStock:
                                // 在庫検索の場合
                                // 製番検索の場合
                                // 在庫＆製番検索の場合
                                //this.tEdit_GoodsNo.Focus();
                                _firstControl.Focus();

                                break;

                            case (int)emSearchMode.ResultStock:
                                this.gridResult.Focus();
                                break;
                        }

                        break;
                        
                        break;
                    }
                // ADD 2008/10/09 不具合対応[6382] ----------<<<<<

                // --- ADD 2012/09/18 ---------->>>>>
                // -------------------------------------------------------------------------------
                // テキスト出力
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_ExtractText:
                    {
                        // テキスト出力処理
                        exportIntoTextFile();
                        break;
                    }
                // -------------------------------------------------------------------------------
                // Excel出力
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_ExtractExcel:
                    {
                        // エクセル出力処理
                        exportIntoExcelData();
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 設定
                // -------------------------------------------------------------------------------
                case CT_BUTTONTOOL_Configuration:
                    {
                        // 設定画面呼出処理
                        openSetting();
                        break;
                    }
                // --- ADD 2012/09/18 ----------<<<<<

                default:
                    break;
            }
        }

        // --- ADD 2012/09/18 ---------->>>>>
        #region <テキスト出力>
        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力処理</br>
        /// <br>Programmer : FSI 斎藤和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void exportIntoTextFile()
        {
            MAZAI04110UB settingConstForm = this._settingForm;

            // 設定オブジェクトを取得
            this._userSetting = settingConstForm.UserSetting;
            string outputFileName = this._userSetting.OutputFileName;
            if (String.IsNullOrEmpty(this._userSetting.OutputFileName))
            {
                // ファイル名が指定されていないとエラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILENAME_NOTFOUND, -1, MessageBoxButtons.OK);

                return;
            }

            // 確認ダイアログ生成・表示
            MAZAI04110UC textOutDialog = new MAZAI04110UC();
            textOutDialog.UserSetting = _userSetting;
            if (textOutDialog.ShowDialog() != DialogResult.OK)
            {
                // 中止
                return;
            }

            // ShowDialogにより、_userSettingは書き変わっているので設定XML更新
            settingConstForm.Serialize();

            String typeStr = string.Empty;
            Char typeChar = new char();
            Byte typeByte = new byte();
            DateTime typeDate = new DateTime();

            Int16 typeInt16 = new short();
            Int32 typeInt32 = new int();
            Int64 typeInt64 = new long();
            Single typeSingle = new float();
            Double typeDouble = new double();
            Decimal typeDecimal = new decimal();

            FormattedTextWriter tw = new FormattedTextWriter();

            // パターンを分解
            _patternSetting = new string[9];
            settingConstForm.Degradation(this._userSetting.SelectedPatternName, out _patternSetting);

            // パターンの構成
            // 区切り文字(タブ・任意・固定長）/区切り文字任意/  0-1
            // 括り文字(”・任意）/括り文字任意/                2-3
            // 数値括り（する／しない)                          4
            // 文字括り（する／しない)                          5
            // タイトル行（あり／なし）                         6
            // 出力項目リスト (35項目x4文字) 基本的に表示順の数字,非表示の場合は99, 必ずExportColumnDataSet.SalesListの順に並んでいる   7
            // パターン形式(.CSV/.TXT/.PRN/カスタム)            8

            // カラム名一覧を作成
            // 明細
            _exportColumnNameList = settingConstForm.GetColumnNameList(_patternSetting[7], false);

            if (_exportColumnNameList.Count == 0)
            {
                // 列情報取得失敗(初期値から取得した場合)
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILEPATTERN_NOTFOUND, -1, MessageBoxButtons.OK);
                return;
            }

            string[] gridSetting;
            getGridSettingPattern(_patternSetting[7], out gridSetting);
            List<String> schemeList;
            getSchemeList(gridSetting, out schemeList);

            // 出力項目名
            tw.SchemeList = schemeList;

            // 固定長：明細
            SalesDtlMaxLength(ref tw);

            // TextWriterのDataSourceセット
            tw.DataSource = this.gridResult.DataSource;

            // グリッドのソート情報を適用する
            if (tw.DataSource is DataView)
            {
                (tw.DataSource as DataView).Sort = GetSortingColumns(this.gridResult);
            }

            # region [フォーマットリスト]
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.gridResult.DisplayLayout.Bands[0].Columns)
            {
                formatList.Add(col.Key, col.Format);
            }
            tw.FormatList = formatList;
            # endregion

            #region オプションセット
            // ファイル名
            tw.OutputFileName = this._userSetting.OutputFileName;
            // 区切り文字
            if (this._patternSetting[0] == "0")
            {
                tw.Splitter = "\t";
            }
            else if (this._patternSetting[0] == "1")
            {
                tw.Splitter = this._patternSetting[1];
            }
            else
            {
                tw.Splitter = string.Empty;
            }
            // 項目括り文字
            if (this._patternSetting[2] == "0")
            {
                tw.Encloser = "\"";
            }
            else if (this._patternSetting[2] == "1")
            {
                tw.Encloser = this._patternSetting[3];
            }
            // 固定幅
            if (this._patternSetting[0] == "2")
            {
                tw.FixedLength = true;
            }
            else
            {
                tw.FixedLength = false;
            }
            // タイトル行出力
            if (this._patternSetting[6] == "1")
            {
                tw.CaptionOutput = false;
            }
            else
            {
                tw.CaptionOutput = true;
            }
            // 項目括り適用
            List<Type> enclosingList = new List<Type>();
            if (this._patternSetting[4] == "0")
            {
                enclosingList.Add(typeInt16.GetType());
                enclosingList.Add(typeInt32.GetType());
                enclosingList.Add(typeInt64.GetType());
                enclosingList.Add(typeDouble.GetType());
                enclosingList.Add(typeDecimal.GetType());
                enclosingList.Add(typeSingle.GetType());
            }
            if (this._patternSetting[5] == "0")
            {
                enclosingList.Add(typeStr.GetType());
                enclosingList.Add(typeChar.GetType());
                enclosingList.Add(typeByte.GetType());
                enclosingList.Add(typeDate.GetType());
            }
            tw.EnclosingTypeList = enclosingList;
            #endregion

            int outputCount = 0;
            int status = tw.TextOut(out outputCount);

            if (status == 9)// 異常終了
            {
                // 出力失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILE_FAILED, -1, MessageBoxButtons.OK);
            }
            else
            {
                // 出力成功
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + MSG_OUTPUTFILE_SUCCEEDED, -1, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// グリッドのセッティングを文字列から取り出す
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <remarks>
        /// <br>Note       : グリッドのセッティングを文字列から取り出す。</br>
        /// <br>Programmer : FSI 斎藤和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// <br></br>
        /// </remarks>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting)
        {
            int count = patternStr.Length / (MAZAI04110UB.ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for (int i = 0; i < count; i++)
            {
                gridSetting[i] = patternStr.Substring(i * (MAZAI04110UB.ct_ColumnCountLength + 1), (MAZAI04110UB.ct_ColumnCountLength + 1));
            }
        }

        /// <summary>
        /// スキーマリストを取得する
        /// </summary>
        /// <param name="gridSetting"></param>
        /// <param name="schemeList"></param>
        /// <remarks>
        /// <br>Note       : スキーマリストを取得する。</br>
        /// <br>Programmer : FSI 斎藤和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// <br></br>
        /// </remarks>
        private bool getSchemeList(string[] gridSetting, out List<String> schemeList)
        {
            schemeList = new List<string>();

            Dictionary<int, string> sortList = new Dictionary<int, string>();
            string displayFlag = string.Empty;
            string displayOrder = string.Empty;
            int columnOrder = 0;
            DataTable targetTable;
            targetTable = this._stockDataTable;

            foreach (string settings in gridSetting)
            {
                if (targetTable.Columns.Count <= columnOrder) break;

                // ４桁の数値なので１＋３に分割
                displayFlag = settings.Substring(0, 1);
                displayOrder = settings.Substring(1, MAZAI04110UB.ct_ColumnCountLength);

                // 表示するであればDictionaryに追加
                if (displayFlag == "0")
                {
                    sortList.Add(int.Parse(displayOrder), targetTable.Columns[columnOrder].ColumnName);
                }
                columnOrder++;
            }

            List<int> keyList = new List<int>(sortList.Keys);
            keyList.Sort();

            foreach (int key in keyList)
            {
                schemeList.Add(sortList[key]);
            }

            return true;
        }

        /// <summary>
        /// 固定長選択時の桁数セット処理
        /// </summary>
        /// <param name="tw"></param>
        /// <remarks>
        /// <br>Note       : 固定長選択時の桁数セット処理</br>
        /// <br>Programmer : FSI 斎藤和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void SalesDtlMaxLength(ref FormattedTextWriter tw)
        {
            #region 固定長選択時の最大桁数をbyte数でセット
            tw.MaxLengthList = new Dictionary<string, int>();
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_WarehouseCode].ColumnName, 10);         //倉庫コード
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_WarehouseShelfNo].ColumnName, 8);       //棚番
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_MakerCode].ColumnName, 14);             //メーカコード
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_GoodsName].ColumnName, 80);             //商品名
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_GoodsCode].ColumnName, 24);             //品番
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_SupplierStock].ColumnName, 10);         //仕入在庫数
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_MinimumStockCnt].ColumnName, 10);       //最低在庫数
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_MaximumStockCnt].ColumnName, 10);       //最高在庫数
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_SalesOrderCount].ColumnName, 10);       //発注残
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_SupplierLot].ColumnName, 10);           //発注ロット
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_ShipmentPosCnt].ColumnName, 10);        //現在庫数
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_MovingSupliStock].ColumnName, 16);      //移動中仕入在庫数
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_ShipmentCnt].ColumnName, 14);           //出荷数(未計上)
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_ArrivalCnt].ColumnName, 14);            //入荷数(未計上)
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_AcpOdrCount].ColumnName, 6);            //受注数
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_GoodsSpecialNote].ColumnName, 80);      //商品規格・特記事項
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_BLGoodsCode].ColumnName, 8);            //BLコード
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_GoodsNameKana].ColumnName, 40);         //品名カナ
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_DuplicationShelfNo1].ColumnName, 9);    //重複棚番1
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_DuplicationShelfNo2].ColumnName, 9);    //重複棚番2
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_MakerName].ColumnName, 60);             //メーカ名
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_SupplierCd].ColumnName, 12);            //仕入先コード
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_SupplierSnm].ColumnName, 60);           //仕入先名
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_ListPrice].ColumnName, 9);              //標準価格
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_StockUnitPrice].ColumnName, 12);        //原単価
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_StockTotalPrice].ColumnName, 12);       //在庫金額
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_UpdateDateString].ColumnName, 14);      //更新日
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_StockCreateDateString].ColumnName, 14); //登録日
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_SectionCode].ColumnName, 10);           //拠点コード
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_SectionName].ColumnName, 12);           //拠点名
            tw.MaxLengthList.Add(this._stockDataTable.Columns[CT_WarehouseName].ColumnName, 40);         //倉庫名
            #endregion
        }

        /// <summary>
        /// 現在ソート中カラム取得処理
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 現在ソート中カラム取得処理。</br>
        /// <br>Programmer : FSI 斎藤和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private string GetSortingColumns(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            string sortText = string.Empty;
            bool firstCol = true;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].SortedColumns)
            {
                if (firstCol == false)
                {
                    sortText += ",";
                }

                // 列名を取得
                sortText += ultraGridColumn.Key;

                // 列のソート方向(昇順,降順)を取得
                if (ultraGridColumn.SortIndicator == Infragistics.Win.UltraWinGrid.SortIndicator.Ascending)
                {
                    sortText += " ASC";
                }
                else
                {
                    sortText += " DESC";
                }

                firstCol = false;
            }

            return sortText;
        }
        #endregion <テキスト出力>

        #region <Excel出力>
        /// <summary>
        /// Excel出力処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : Excel出力処理</br>
        /// <br>Programmer : FSI 斎藤和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void exportIntoExcelData()
        {
            string fileName = string.Empty;

            // ファイル保存ダイアログ表示
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = "Excelファイル(*.xls) | *.xls";
            this.openFileDialog.FilterIndex = 0;

            fileName = string.Empty;

            // ファイル選択
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }

            if (String.IsNullOrEmpty(fileName))
            {
                // ファイル名が指定されていない
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTEXCEL_NOFILENAME, -1, MessageBoxButtons.OK);

                return;
            }

            try
            {
                if (this.ultraGridExcelExporter.Export(this.gridResult, fileName) != null)
                {
                    // 成功
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        MSG_OUTPUTEXCEL_SUCCEEDED, -1, MessageBoxButtons.OK);
                };
            }
            catch (Exception e)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    e.Message, -1, MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// Excelエクスポート・カラム初期化イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : Excelエクスポート・カラム初期化イベント処理。</br>
        /// <br>Programmer : FSI 斎藤和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// <br></br>
        /// </remarks>
        private void ultraGridExcelExporter_InitializeColumn(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.InitializeColumnEventArgs e)
        {
            string format = e.Column.Format;

            // format文字列をExcel用に補正
            if (!string.IsNullOrEmpty(format))
            {
                // 金額のフォーマット文字列はExcel用に補正する
                if (format.Equals("#,##0;"))
                {
                    // 「#,##0;」→「#,##0」(4540行目周辺で定義している値がExcelに適していない)
                    format = "#,##0";
                }
                else if (format.Equals("N"))
                {
                    // 「N」→「#,##0.00」(4540行目周辺で設定している値がExcelに適していない)
                    format = "#,##0.00";
                }
                else
                {
                    format = string.Empty;
                }
            }
            else
            {
                format = string.Empty;
            }

            e.ExcelFormatStr = format;
        }

        #endregion <Excel出力>

        #region <設定>
        /// <summary>
        /// 設定画面呼出処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 設定画面呼出処理</br>
        /// <br>Programmer : FSI 斎藤和宏</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void openSetting()
        {
            DialogResult dialogResult = _settingForm.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                // 復帰時に行う処理があればここで
            }

            return;
        }
        #endregion
        // --- ADD 2012/09/18 ----------<<<<<

        #endregion

        #region < tArrowKeyControl1_ChangeFocus >

        /// <summary>
        /// tArrowKeyControl1チェンジフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォーカスが遷移したタイミングで発生します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2007.1.31</br>
        /// <br>Update Note : 2009/09/07       汪千来</br>
        /// <br>	        : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (!this._isEvent) return;

            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            if (e.NextCtrl == this.gridResult)
            {
                switch (e.Key)
                {
                    case Keys.Enter:
                        {
                            if (this.gridResult.Rows.Count == 0)
                            {
                                if (e.ShiftKey)
                                    e.NextCtrl = this.Multi_CheckEditor;
                                else
                                    e.NextCtrl = this.FontSize_tComboEditor;
                            }
                            break;
                        }
                    case Keys.Up:
                        {
                            if (this.gridResult.Rows.Count == 0)
                            {
                                switch (this._searchMode)
                                {
                                    case (int)emSearchMode.GoodsStock:			// 商品在庫
                                    case (int)emSearchMode.Goods:						// 商品
                                        {
                                            e.NextCtrl = this.MediumGoodsGanreName_tEdit;
                                            break;
                                        }
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    //case (int)emSearchMode.Product:					// 製番
                                    //case (int)emSearchMode.ResultProduct:		// 製番結果表示
                                    //case (int)emSearchMode.Stock:		// 在庫＆製番
                                    //case (int)emSearchMode.ProductwitchStock:// 製番(＋在庫)
                                    //    {
                                    //        e.NextCtrl = this.StockTelNo_tEdit;
                                    //        break;
                                    //    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                }
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            if (this.gridResult.Rows.Count == 0)
                                //e.NextCtrl = this.FontSize_tComboEditor;//DEL BY 凌小青 on 2011/11/21
                                  e.NextCtrl = e.PrevCtrl;                //ADD BY 凌小青 on 2011/11/21
                            break;
                        }
                }
            }
            // ------- ADD BY 凌小青 on 2011/11/21 ------->>>>>>>>>>>>>
            if (e.PrevCtrl == tNedit_BLGoodsCode 
                && e.NextCtrl == this.Multi_CheckEditor 
                && this.gridResult.Rows.Count == 0)
            {
                e.NextCtrl = e.PrevCtrl;
            }
           // ------- ADD BY 凌小青 on 2011/11/21 -------<<<<<<<<<<<<<

            // グリッド上でEnterキーが押下された場合は確定と同じ動きを行う
            if (e.NextCtrl.Equals(this.gridResult))
            {
                // 照会モードは除外
                if (!_isReference)
                {
                    // 入力されたキーで判定
                    // Enterキー
                    if ((e.Key == Keys.Enter) &&
                        ((e.ShiftKey == false) && (e.ControlKey == false) && (e.AltKey == false)))
                    {
                        e.NextCtrl = null;

                        if (this.gridResult.Rows.Count > 0)
                        {
                            this.gridResult.Rows[0].Activate();
                            this.gridResult.Rows[0].Selected = true;
                        }
                    }
                }
            }

            int status = 0;
            StockSearchPara searchPara = new StockSearchPara();
            if (this._prevSearchParam != null)
                searchPara = this._prevSearchParam.Clone();

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");

            switch (e.PrevCtrl.Name)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// ----------------------------------------
                //// キャリアコード
                //case "CarrierName_tEdit":
                //    {
                //        if ((regex.IsMatch(this.CarrierName_tEdit.Text)) && searchPara.CarrierName != this.CarrierName_tEdit.Text)
                //        {
                //            if (this.CarrierName_tEdit.Text.Length <= 9)
                //            {
                //                Carrier carrier;
                //                status = this._goodsAcs.GetCarrier(this._enterpriseCode, TStrConv.StrToIntDef(this.CarrierName_tEdit.Text, 0), out carrier);
                //                if (status == 0)
                //                {
                //                    this.SetSearchParaFromCarrier(carrier, ref searchPara);
                //                }
                //                else
                //                {
                //                    this.SetSearchParaFromCarrier(null, ref searchPara);
                //                }
                //            }
                //            else
                //            {
                //                if (this.CarrierName_tEdit.Text.Trim() == "")
                //                {
                //                    // 抽出条件入力情報クラス格納処理
                //                    this.SetSearchParaFromCarrier(null, ref searchPara);
                //                }
                //            }
                //        }
                //        else
                //        {
                //            if (this.CarrierName_tEdit.Text.Trim() == "")
                //            {
                //                this.SetSearchParaFromCarrier(null, ref searchPara);
                //            }
                //        }

                //        // NextCtrl制御
                //        switch (e.Key)
                //        {
                //            case Keys.Return:
                //            case Keys.Tab:
                //                {
                //                    if (this.CarrierName_tEdit.Text.Trim() == "")
                //                    {
                //                        e.NextCtrl = this.CarrierGuide_Button;
                //                    }
                //                    break;
                //                }
                //        }
                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                // ----------------------------------------
                // 拠点コード
                // BLコード → BLコードガイドボタン → [ 拠点コード ] → 拠点ガイドボタン → 倉庫コード
                //case "Section_ComboEditor":
                //case "tEdit_SectionCode":     // DEL 2009/09/07
                case "tEdit_SectionCodeAllowZero":      // ADD 2009/09/07
                    {
                        // 拠点検索


                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        //if (this.tEdit_SectionCode.Text.Trim() == "")     // DEL 2009/09/07
                                        if (this.tEdit_SectionCodeAllowZero.Text.Trim() == "")      // ADD 2009/09/07
                                        {
                                            // 入力がなければガイドボタンへ
                                            e.NextCtrl = uButton_SectionGuide;
                                        }
                                        else
                                        {
                                            // 倉庫コード
                                            e.NextCtrl = this.tEdit_WarehouseCode;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // BLコード
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                    }
                                    break;
                            }

                        }
                    }
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // ----------------------------------------
                // 拠点ガイドボタン
                // BLコードガイドボタン → 拠点コード → [ 拠点ガイドボタン ] → 倉庫コード → 倉庫ガイドボタン
                case "uButton_SectionGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 倉庫コード
                                        e.NextCtrl = tEdit_WarehouseCode;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 拠点コード
                                        //e.NextCtrl = this.tEdit_SectionCode;      // DEL 2009/09/07
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;       // ADD 2009/09/07
                                    }
                                    break;
                            }

                        }
                    }
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                // ----------------------------------------
                // 倉庫コード
                // 拠点コード → 拠点ガイドボタン → [ 倉庫コード ] → 倉庫ガイドボタン → 棚番
                //case "uLabel_WarehouseName":
                case "tEdit_WarehouseCode":
                    {
                        // 倉庫読み込み
                        status = ReadWarehouse(ref searchPara);

                        if (status != 0)
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            //if ( this.uLabel_WarehouseName.Text.Trim() == string.Empty )
                                            if (this.tEdit_WarehouseCode.Text.Trim() == string.Empty)
                                            {
                                                // 入力がなければガイドボタンへ
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                // 棚番
                                                e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 拠点コード
                                            //e.NextCtrl = this.tEdit_SectionCode;      // DEL 2009/09/07
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;       // ADD 2009/09/07
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // ----------------------------------------
                // 倉庫ガイドボタン
                // 拠点ガイドボタン → 倉庫コード → [ 倉庫ガイドボタン ] → 棚番 → ゼロ在庫区分
                case "uButton_WarehouseGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                //case Keys.Space:
                                //    {
                                //        EventArgs ev = new EventArgs();
                                //        WarehouseGuide_Button_Click(this.uButton_WarehouseGuide, ev);
                                //    }
                                //    break;
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 棚番
                                        e.NextCtrl = tEdit_WarehouseShelfNo;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 倉庫コード
                                        e.NextCtrl = this.tEdit_WarehouseCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                // ----------------------------------------
                // 棚番
                // 倉庫コード → 倉庫ガイドボタン → [ 棚番 ] → ゼロ在庫区分 → 対象日付開始
                case "tEdit_WarehouseShelfNo":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // ゼロ在庫区分
                                        e.NextCtrl = this.StockZero_tComboEditor;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 倉庫コード
                                        e.NextCtrl = this.tEdit_WarehouseCode;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                // ----------------------------------------
                // ゼロ在庫区分
                // 倉庫ガイドボタン → 棚番 → [ ゼロ在庫区分 ] → 対象日付開始 → 対象日付終了
                case "StockZero_tComboEditor":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 対象日付開始
                                        //e.NextCtrl = this.tDateEdit_Date1Start;           //DEL 2009/04/02 不具合対応[12838]
                                        e.NextCtrl = this.SortDiv_tComboEditor;             //ADD 2009/04/02 不具合対応[12838]

                                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                        ////if (this.CarrierEpName_tEdit.Visible)
                                        ////{
                                        ////    e.NextCtrl = this.CarrierEpName_tEdit;
                                        ////}
                                        ////else if (this.tNedit_GoodsMakerCd.Visible)
                                        ////{
                                        ////    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                        ////}
                                        //if (this.Detail_UGroupBox.Expanded)
                                        //{
                                        //    e.NextCtrl = this.tEdit_SupplierName;
                                        //}
                                        //else
                                        //{
                                        //    e.NextCtrl = this.Search_Button;
                                        //}
                                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 棚番
                                        e.NextCtrl = this.tEdit_WarehouseShelfNo;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END

                // ---ADD 2009/04/02 不具合対応[12838] ------------------------------------------->>>>>
                // ----------------------------------------
                // 表示順
                // 棚番 → ゼロ在庫区分 → [ 表示順 ] → 対象日 → 対象日付開始
                case "SortDiv_tComboEditor":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 対象日
                                        e.NextCtrl = this.tComboEditor_DateDiv;
                                    }
                                    break;
                                //------ADD BY 凌小青 on 2011/11/21 for Redmine7864 ------->>>>>>>>>>
                                case Keys.Down:
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    break;
                                //------ADD BY 凌小青 on 2011/11/21 for Redmine7864 -------<<<<<<<<<<
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // ゼロ在庫区分
                                        e.NextCtrl = this.StockZero_tComboEditor;
                                    }
                                    break;
                            }
                        }
                        break;
                    }

                // ----------------------------------------
                // 対象日
                // ゼロ在庫区分 → 表示順 → [ 対象日 ] → 対象日付開始 → 対象日付終了
                case "tComboEditor_DateDiv":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 対象日付開始
                                        e.NextCtrl = this.tDateEdit_Date1Start;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 表示順
                                        e.NextCtrl = this.SortDiv_tComboEditor;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // ---ADD 2009/04/02 不具合対応[12838] ------------------------------------------->>>>>

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // ----------------------------------------
                // 対象日付開始
                // 棚番 → ゼロ在庫区分 → [ 対象日付開始 ] → 対象日付終了 → メーカーコード
                case "tDateEdit_Date1Start":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 対象日付終了
                                        e.NextCtrl = this.tDateEdit_Date1End;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // ゼロ在庫区分
                                        //e.NextCtrl = this.StockZero_tComboEditor;         //DEL 2009/04/02 不具合対応[12838]
                                        e.NextCtrl = this.tComboEditor_DateDiv;             //ADD 2009/04/02 不具合対応[12838]        
                                    }
                                    break;
                            }
                        }
                        break;
                    }

                // ----------------------------------------
                // 対象日付終了
                // ゼロ在庫区分 → 対象日付開始 → [ 対象日付終了 ] → メーカーコード → メーカーガイドボタン
                case "tDateEdit_Date1End":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // メーカーコード
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 対象日付開始
                                        e.NextCtrl = this.tDateEdit_Date1Start;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

                // ----------------------------------------
                // メーカーコード
                // 対象日付開始 → 対象日付終了 → [ メーカーコード ] → メーカーガイドボタン → 品番
                case "tNedit_GoodsMakerCd":
                    {
                        // メーカー読み込み
                        status = ReadMaker(ref searchPara);

                        if (status != 0)
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            // NextCtrl制御
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (this.tNedit_GoodsMakerCd.Text.Trim() == "")
                                            {
                                                // 入力がなければガイドボタンへ
                                                e.NextCtrl = this.MakerGuide_Button;
                                            }
                                            else
                                            {
                                                // 品番
                                                e.NextCtrl = this.tEdit_GoodsNo;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 対象日付終了
                                            e.NextCtrl = this.tDateEdit_Date1End;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // ----------------------------------------
                // メーカーガイドボタン
                // 対象日付終了 → メーカーコード → [ メーカーガイドボタン ] → 品番 → 品名
                case "MakerGuide_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 品番
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // メーカーコード
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                // ----------------------------------------
                // 品番
                // メーカーコード → メーカーガイドボタン → [ 品番 ] → 品名 → 品名カナ
                case "tEdit_GoodsNo":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 品名
                                        e.NextCtrl = this.tEdit_GoodsName;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // メーカーコード
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                // ----------------------------------------
                // 品名
                // メーカーガイドボタン → 品番 → [ 品名 ] → 品名カナ → 仕入先コード
                case "tEdit_GoodsName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 品名カナ
                                        e.NextCtrl = this.GoodsNameKana_tEdit;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 品番
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                // ----------------------------------------
                // 品名カナ
                // 品番 → 品名 → [ 品名カナ ] → 仕入先コード → 仕入先ガイドボタン
                case "GoodsNameKana_tEdit":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.Detail_UGroupBox.Expanded)
                                        {
                                            // 仕入先コード
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                        }
                                        else
                                        {
                                            // 詳細条件が展開していなければ拠点コードに戻る
                                            //e.NextCtrl = this.tEdit_SectionCode;     // DEL 2009/09/07
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;   // ADD 2009/09/07
                                        }
                                    }
                                    break;
                                //------ADD BY 凌小青 on 2011/11/21 for Redmine7864 ------->>>>>>>>>>
                                case Keys.Down:
                                    e.NextCtrl = this.tNedit_BLGoodsCode;
                                    break;
                                //------ADD BY 凌小青 on 2011/11/21 for Redmine7864 -------<<<<<<<<<<
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 品名
                                        e.NextCtrl = this.tEdit_GoodsName;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                // ----------------------------------------
                // 仕入先コード
                // 品名 → [ 品名カナ ] → [ 仕入先コード ] → 仕入先ガイドボタン → BLコード
                //case "tEdit_SupplierName":
                case "tNedit_SupplierCd":
                    {
                        // 仕入先読み込み処理
                        status = ReadCustomer(ref searchPara);

                        if (status != 0)
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            // NextCtrl制御
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                                            if (this.tNedit_SupplierCd.Text.Trim() == "")
                                            //if (this.tEdit_SupplierName.Text.Trim() == "")
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
                                            {
                                                // 入力されていなければガイドボタンへ
                                                e.NextCtrl = this.uButton_SupplierGuide;
                                            }
                                            else
                                            {
                                                // BLコード
                                                // e.NextCtrl = this.ModelName_TEdit;
                                                e.NextCtrl = this.tNedit_BLGoodsCode;
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                                            // ゼロ在庫表示区分に戻る
                                            //e.NextCtrl = StockZero_tComboEditor;
                                            // 品名カナに戻る
                                            e.NextCtrl = this.GoodsNameKana_tEdit;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // ----------------------------------------
                // 仕入先ガイドボタン
                // 品名カナ → 仕入先コード → [ 仕入先ガイドボタン ] → BLコード → BLコードガイド
                case "uButton_SupplierGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // BLコード
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // 仕入先コード
                                        e.NextCtrl = this.tNedit_SupplierCd;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA MODIFY START
                // ----------------------------------------
                // ＢＬコード
                // 仕入先コード → 仕入先ガイドボタン → [ BLコード ] → BLコードガイド → 拠点コード
                case "tNedit_BLGoodsCode":
                    {
                        // BL商品コード読み込み
                        status = ReadBLGoods(ref searchPara);

                        if (status != 0)
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            // NextCtrl制御
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (this.tEdit_BLGoodsName.Text.Trim() == "")
                                            {
                                                // 入力がなければガイドボタンへ
                                                e.NextCtrl = this.BLGoodsCodeGuide_Button;
                                            }
                                            else
                                            {
                                                // 拠点コードへ
                                                //e.NextCtrl = this.tEdit_SectionCode;      // DEL 2009/09/07
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;       // ADD 2009/09/07
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            // 仕入先コード
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA MODIFY END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // ----------------------------------------
                // BLコードガイドボタン
                // 仕入先ガイドボタン → BLコード → [ BLコードガイド ] → 拠点コード → 拠点コードガイドボタン
                case "BLGoodsCodeGuide_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // 拠点コード
                                        //e.NextCtrl = this.tEdit_SectionCode;      // DEL 2009/09/07
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;       // ADD 2009/09/07
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // BLコード
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // ----------------------------------------
                //// 事業者コード
                //case "CarrierEpName_tEdit":
                //    {
                //        if (searchPara.CarrierEpName != this.CarrierEpName_tEdit.Text)
                //        {
                //            // 数値のみが入力されているか？
                //            if ((regex.IsMatch(this.CarrierEpName_tEdit.Text)) && (this.CarrierEpName_tEdit.Text.Length <= 9))
                //            {
                //                CarrierEp carrierEp;
                //                status = this._carrierEpAcs.Read( out carrierEp, this._enterpriseCode, TStrConv.StrToIntDef(this.CarrierEpName_tEdit.Text,0));
                //                if (status == 0)
                //                {
                //                    this.SetSearchParaFromCarrierEp(carrierEp, ref searchPara);
                //                }
                //                else
                //                {
                //                    this.SetSearchParaFromCarrierEp(null, ref searchPara);
                //                }
                //            }
                //            else
                //            {
                //                if (this.CarrierEpName_tEdit.Text.Trim() == "")
                //                {
                //                    this.SetSearchParaFromCarrierEp(null, ref searchPara);
                //                }
                //            }
                //        }

                //        // NextCtrl制御
                //        switch (e.Key)
                //        {
                //            case Keys.Return:
                //            case Keys.Tab:
                //                {
                //                    if (this.CarrierEpName_tEdit.Text.Trim() == "")
                //                    {
                //                        e.NextCtrl = this.CarrierEpGuide_Button;
                //                    }
                //                    else
                //                    {
                //                        // e.NextCtrl = this.ModelName_TEdit;
                //                    }
                //                    break;
                //                }
                //        }

                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA DEL START
                //// ----------------------------------------
                //// 商品区分グループコード
                //case "LargeGoodsGanreName_tEdit":
                //    {
                //        // 商品区分グループ読み込み
                //        status = ReadLargeGoodsGanre( ref searchPara );

                //        if ( status != 0 )
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }
                //        else
                //        {
                //            // NextCtrl制御
                //            if ( !e.ShiftKey )
                //            {
                //                switch ( e.Key )
                //                {
                //                    case Keys.Return:
                //                    case Keys.Tab:
                //                        {
                //                            if ( this.LargeGoodsGanreName_tEdit.Text.Trim() == "" )
                //                            {
                //                                e.NextCtrl = this.LargeGoodsGanreCodeGuide_Button;
                //                            }
                //                            else
                //                            {
                //                                // e.NextCtrl = this.ModelName_TEdit;
                //                            }
                //                            break;
                //                        }
                //                }
                //            }
                //        }
                //        break;
                //    }

                //// ----------------------------------------
                //// 商品区分コード
                //case "MediumGoodsGanreName_tEdit":
                //    {
                //        // 商品区分読み込み
                //        status = ReadMediumGoodsGanre( ref searchPara );

                //        if ( status != 0 )
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }
                //        else
                //        {
                //            // NextCtrl制御
                //            if ( !e.ShiftKey )
                //            {
                //                switch ( e.Key )
                //                {
                //                    case Keys.Return:
                //                    case Keys.Tab:
                //                        {
                //                            if ( this.MediumGoodsGanreName_tEdit.Text.Trim() == "" )
                //                            {
                //                                e.NextCtrl = this.MediumGoodsGanreGide_Button;
                //                            }
                //                            else
                //                            {
                //                                // e.NextCtrl = this.ModelName_TEdit;
                //                            }
                //                            break;
                //                        }
                //                }
                //            }
                //        }
                //        break;
                //    }
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 商品区分詳細コード
                //case "DetailGoodsGanreName_tEdit": 
                //    {
                //        // 商品区分詳細読み込み
                //        status = ReadDetailGoodsGanre( ref searchPara );

                //        if ( status != 0 )
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }
                //        else
                //        {
                //            // NextCtrl制御
                //            if ( !e.ShiftKey )
                //            {
                //                switch ( e.Key )
                //                {
                //                    case Keys.Return:
                //                    case Keys.Tab:
                //                        {
                //                            if ( this.DetailGoodsGanreName_tEdit.Text.Trim() == "" )
                //                            {
                //                                e.NextCtrl = this.DetailGoodsGanreGide_Button;
                //                            }
                //                            else
                //                            {
                //                                // e.NextCtrl = this.ModelName_TEdit;
                //                            }
                //                            break;
                //                        }
                //                }
                //            }
                //        }

                //        break;
                //    }     
                //// 自社分類コード
                //case "EnterpriseGanreCode_tEdit":
                //    {
                //        // 自社分類読み込み
                //        status = ReadEnterpriseGanre( ref searchPara );

                //        if ( status != 0 )
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }
                //        else
                //        {
                //            // NextCtrl制御
                //            if ( !e.ShiftKey )
                //            {
                //                switch ( e.Key )
                //                {
                //                    case Keys.Return:
                //                    case Keys.Tab:
                //                        {
                //                            if ( this.EnterpriseGanreCode_tEdit.Text.Trim() == "" )
                //                            {
                //                                e.NextCtrl = this.EnterpriseGanreCodeGuide_Button;
                //                            }
                //                            else
                //                            {
                //                                // e.NextCtrl = this.ModelName_TEdit;
                //                            }
                //                            break;
                //                        }
                //                }
                //            }
                //        }
                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA DEL END

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

            if (e.NextCtrl == this.gridResult)
            {
                switch (e.Key)
                {
                    case Keys.Enter:
                        {
                            if (this.gridResult.Rows.Count == 0)
                            {
                                if (e.ShiftKey)
                                    e.NextCtrl = this.Multi_CheckEditor;
                                //else
                                //  e.NextCtrl = this.cmbFontSize;
                            }
                            break;
                        }
                    case Keys.Up:
                        {
                            if (this.gridResult.Rows.Count == 0)
                            {
                                if (this.Detail_UGroupBox.Expanded)
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    //e.NextCtrl = this.StockTelNo_tEdit;
                                    e.NextCtrl = this.tEdit_BLGoodsName;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                }
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                                    //e.NextCtrl = this.CellphoneModelCode_tEdit;
                                    e.NextCtrl = this.GoodsNameKana_tEdit;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                                }
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            //if (this.gridResult.Rows.Count == 0)
                            //  e.NextCtrl = this.cmbFontSize;
                            break;
                        }
                }
            }

            // グリッド上でEnterキーが押下された場合は確定と同じ動きを行う
            if ((e.PrevCtrl == this.gridResult) &&
                (e.Key == Keys.Enter))
            {
                // 照会モードならば除外（以後の検索動作もキャンセルする）
                if (_isReference) return;

                e.NextCtrl = null;

                KeyEventArgs keyEvent = new KeyEventArgs(e.Key);
                this.gridResult_KeyDown(sender, keyEvent);
            }


            // 複数条件検索しない場合
            if (false) // 複数条件は必ずON
            {
                if ((!this.Multi_CheckEditor.Checked) &&
                    (e.Key == Keys.Enter))
                {
                    if ((e.PrevCtrl != null) &&
                        (!(e.PrevCtrl is Infragistics.Win.Misc.UltraButton)) &&
                        (!(e.PrevCtrl is Broadleaf.Library.Windows.Forms.TComboEditor)) &&
                        (!(e.PrevCtrl is Infragistics.Win.UltraWinEditors.UltraCheckEditor)))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        // 検索条件取得
                        StockSearchPara sarchPara = this.GetSearchParameter();

                        // 現在アクティブとなっている条件以外削除
                        if (this.ClearControlBeforeSearch(e.PrevCtrl, sarchPara) == 0)
                        {
                            Control nextCtrl = e.NextCtrl;
                            //if (this.CheckBeforeSearch(e.PrevCtrl, sarchPara))  //2012/04/10 T.Nishi DEL
                            //{  //2012/04/10 T.Nishi DEL
                                status = this.SearchMainProc(sarchPara);
                                switch (status)
                                {
                                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                        {
                                            e.NextCtrl = this.gridResult;
                                            break;
                                        }
                                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                        {
                                            this.ultraStatusBar.Focus();
                                            e.NextCtrl = e.PrevCtrl;
                                            break;
                                        }
                                }
                            //2012/04/10 T.Nishi DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //}
                            //else
                            //{
                            //    e.NextCtrl = nextCtrl;
                            //}
                            //2012/04/10 T.Nishi DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }

                    }
                }
            }
        }

        /// <summary>
        /// ＢＬ商品コード読み込み処理
        /// </summary>
        /// <param name="searchPara"></param>
        /// <returns></returns>
        /// <br>Update Note: 2009/12/18 李侠</br>
        /// <br>             PM.NS-5・保守依頼④未登録のコードを入力時、コードを前回入力値に戻すように変更する</br>
        private int ReadBLGoods(ref StockSearchPara searchPara)
        {
            int status = 0;

            //if (this.tNedit_BLGoodsCode.GetInt() == _prevHeaderInfo.BLGoodsCode)
            //{
            //    // 前回名称のまま→そのまま
            //}
            //else 
            if (this.tNedit_BLGoodsCode.GetInt() == _prevHeaderInfo.BLGoodsCode)
            {
                // 前回コードを同じ→名称に置き換える
                this.tNedit_BLGoodsCode.SetInt(_prevHeaderInfo.BLGoodsCode);
                this.tEdit_BLGoodsName.Text = _prevHeaderInfo.BLGoodsCodeName;
            }
            else
            {
                // 入力されているか？
                if (this.tNedit_BLGoodsCode.GetInt() != 0)
                {
                    BLGoodsCdUMnt blGoods;

                    //string blGoodsCode = this.tNedit_BLGoodsCode.GetInt().ToString().TrimEnd();

                    // ＢＬ商品コード情報取得処理
                    status = this._blGoodsCdAcs.Read(out blGoods, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());//TStrConv.StrToIntDef(blGoodsCode, 0));
                    if (status == 0)
                    {
                        // 入力値セット
                        this.SetSearchParaFromBLGoods(blGoods, ref searchPara);

                        // 前回情報を更新
                        _prevHeaderInfo.BLGoodsCode = blGoods.BLGoodsCode;
                        _prevHeaderInfo.BLGoodsCodeName = blGoods.BLGoodsFullName;
                    }
                    else
                    {
                        // 入力エラー
                        //this.SetSearchParaFromBLGoods( null, ref searchPara );

                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
                                        string.Format("ＢＬ商品コード[{0}]に該当するデータが存在しません。", this.tNedit_BLGoodsCode.GetInt().ToString()),//blGoodsCode ),
                                        -1, MessageBoxButtons.OK);
                        // 前回値に戻す
                        this.tEdit_BLGoodsName.Text = _prevHeaderInfo.BLGoodsCodeName;
                        this.tEdit_BLGoodsName.Tag = _prevHeaderInfo.BLGoodsCode;
                        searchPara.BLGoodsCode = _prevHeaderInfo.BLGoodsCode;
                        searchPara.BLGoodsName = _prevHeaderInfo.BLGoodsCodeName;
                        // --- ADD 2009/12/18 ---------->>>>>
                        this.tNedit_BLGoodsCode.SetInt(_prevHeaderInfo.BLGoodsCode);
                        // --- ADD 2009/12/18 ----------<<<<<
                    }
                }
                else
                {
                    // 入力クリア
                    this.SetSearchParaFromBLGoods(null, ref searchPara);

                    // 前回情報をクリア
                    _prevHeaderInfo.BLGoodsCode = 0;
                    _prevHeaderInfo.BLGoodsCodeName = string.Empty;
                }
            }
            return status;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA DEL START
        ///// <summary>
        ///// 自社分類読み込み処理
        ///// </summary>
        ///// <param name="searchPara"></param>
        ///// <returns></returns>
        //private int ReadEnterpriseGanre( ref StockSearchPara searchPara )
        //{
        //    int status = 0;

        //    if ( this.EnterpriseGanreCode_tEdit.Text.TrimEnd() == _prevHeaderInfo.EnterpriseGanreName )
        //    {
        //        // 前回名称と同じ→そのまま
        //    }
        //    else if ( TStrConv.StrToIntDef( this.EnterpriseGanreCode_tEdit.Text.TrimEnd(), 0) == _prevHeaderInfo.EnterpriseGanreCode )
        //    {
        //        // 前回コードと同じ→名称に置き換える
        //        this.EnterpriseGanreCode_tEdit.Text = _prevHeaderInfo.EnterpriseGanreName;
        //    }
        //    else
        //    {
        //            // 数値のみが入力されているか？
        //            if ( this.EnterpriseGanreCode_tEdit.Text.Trim() != string.Empty )
        //            {
        //                int EnterpriseGanreCode = Broadleaf.Library.Text.TStrConv.StrToIntDef( EnterpriseGanreCode_tEdit.DataText, 0 );
        //                UserGdBd userGdBd;

        //                // 自社分類情報取得処理
        //                status = this._searchStockAcs.GetEnterpriseGanreCode( this._enterpriseCode, EnterpriseGanreCode, out userGdBd );

        //                if ( status == 0 )
        //                {
        //                    // 入力セット
        //                    this.SetSearchParaFromEnterpriseGanre( userGdBd, ref searchPara );

        //                    // 前回情報の更新
        //                    _prevHeaderInfo.EnterpriseGanreCode = userGdBd.GuideCode;
        //                    _prevHeaderInfo.EnterpriseGanreName = userGdBd.GuideName;
        //                }
        //                else
        //                {
        //                    // 入力エラー
        //                    //this.SetSearchParaFromEnterpriseGanre( null, ref searchPara );

        //                    TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
        //                                    string.Format( "自社分類コード[{0}]に該当するデータが存在しません。", this.EnterpriseGanreCode_tEdit.Text.TrimEnd() ),
        //                                    -1, MessageBoxButtons.OK );
        //                    // 前回値に戻す
        //                    this.EnterpriseGanreCode_tEdit.Text = _prevHeaderInfo.EnterpriseGanreName;
        //                    this.EnterpriseGanreCode_tEdit.Tag = _prevHeaderInfo.EnterpriseGanreCode;
        //                    searchPara.DetailGoodsGanreCode = _prevHeaderInfo.EnterpriseGanreCode.ToString().TrimEnd();
        //                    searchPara.DetailGoodsGanreName = _prevHeaderInfo.EnterpriseGanreName;
        //                }
        //            }
        //            else
        //            {
        //                // 入力クリア
        //                this.SetSearchParaFromEnterpriseGanre( null, ref searchPara );

        //                // 前回情報のクリア
        //                _prevHeaderInfo.EnterpriseGanreCode = 0;
        //                _prevHeaderInfo.EnterpriseGanreName = string.Empty;
        //            }

        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 商品区分詳細読み込み
        ///// </summary>
        ///// <param name="searchPara"></param>
        ///// <returns></returns>
        //private int ReadDetailGoodsGanre( ref StockSearchPara searchPara )
        //{
        //    int status = 0;

        //    if ( this.DetailGoodsGanreName_tEdit.Text == _prevHeaderInfo.DetailGoodsGanreName )
        //    {
        //        // 前回名称と同じ
        //    }
        //    else if ( this.DetailGoodsGanreName_tEdit.Text == _prevHeaderInfo.DetailGoodsGanreName )
        //    {
        //        // 前回コードと同じ→名称に置き換え
        //        this.DetailGoodsGanreName_tEdit.Text = _prevHeaderInfo.DetailGoodsGanreName;
        //    }
        //    else
        //    {
        //        // 数値のみが入力されているか？
        //        if ( this.DetailGoodsGanreName_tEdit.Text.Trim() != string.Empty )
        //        {
        //            DGoodsGanre dGoodsGanre;

        //            // 商品区分情報取得処理
        //            status = this._goodsAcs.GetDetailGoodsGanreCode( this._enterpriseCode,
        //                this.DetailGoodsGanreName_tEdit.DataText,
        //                out dGoodsGanre );

        //            if ( status == 0 )
        //            {
        //                // 入力セット
        //                this.SetSearchParaFromDGoodsGanre( dGoodsGanre, ref searchPara );

        //                // 前回情報更新
        //                _prevHeaderInfo.DetailGoodsGanreCode = dGoodsGanre.DetailGoodsGanreCode;
        //                _prevHeaderInfo.DetailGoodsGanreName = dGoodsGanre.DetailGoodsGanreName;
        //            }
        //            else
        //            {
        //                // 入力エラー
        //                //this.SetSearchParaFromDGoodsGanre( null, ref searchPara );

        //                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
        //                                string.Format( "商品区分詳細コード[{0}]に該当するデータが存在しません。", this.DetailGoodsGanreName_tEdit.Text.TrimEnd() ),
        //                                -1, MessageBoxButtons.OK );
        //                // 前回値に戻す
        //                this.DetailGoodsGanreName_tEdit.Text = _prevHeaderInfo.DetailGoodsGanreName;
        //                this.DetailGoodsGanreName_tEdit.Tag = _prevHeaderInfo.DetailGoodsGanreCode;
        //                searchPara.DetailGoodsGanreCode = _prevHeaderInfo.DetailGoodsGanreCode;
        //                searchPara.DetailGoodsGanreName = _prevHeaderInfo.DetailGoodsGanreName;
        //            }
        //        }
        //        else
        //        {
        //            // 入力クリア
        //            this.SetSearchParaFromDGoodsGanre( null, ref searchPara );

        //            // 前回情報クリア
        //            _prevHeaderInfo.DetailGoodsGanreCode = string.Empty;
        //            _prevHeaderInfo.DetailGoodsGanreName = string.Empty;
        //        }
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// 商品区分読み込み処理
        ///// </summary>
        ///// <param name="searchPara"></param>
        ///// <returns></returns>
        //private int ReadMediumGoodsGanre( ref StockSearchPara searchPara )
        //{
        //    int status = 0;

        //    if ( this.MediumGoodsGanreName_tEdit.Text == _prevHeaderInfo.MediumGoodsGanreName )
        //    {
        //        // 前回名称のまま→そのまま
        //    }
        //    else if ( this.MediumGoodsGanreName_tEdit.Text == _prevHeaderInfo.MediumGoodsGanreCode )
        //    {
        //        // 前回コードと同じ→名称に置き換える
        //        this.MediumGoodsGanreName_tEdit.Text = _prevHeaderInfo.MediumGoodsGanreName;
        //    }
        //    else
        //    {
        //        // 入力されているか？
        //        if ( this.MediumGoodsGanreName_tEdit.Text.Trim() != string.Empty )
        //        {
        //            MGoodsGanre mGoodsGanre;

        //            // 商品区分情報取得処理
        //            status = this._goodsAcs.GetMediumGoodsGanreCode( this._enterpriseCode,
        //                this.MediumGoodsGanreName_tEdit.DataText,
        //                out mGoodsGanre );

        //            if ( status == 0 )
        //            {
        //                this.SetSearchParaFromMGoodsGanre( mGoodsGanre, ref searchPara );

        //                // 前回情報の更新
        //                _prevHeaderInfo.MediumGoodsGanreCode = mGoodsGanre.MediumGoodsGanreCode;
        //                _prevHeaderInfo.MediumGoodsGanreName = mGoodsGanre.MediumGoodsGanreName;
        //            }
        //            else
        //            {
        //                // 入力エラー
        //                // this.SetSearchParaFromMGoodsGanre( null, ref searchPara );

        //                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
        //                                string.Format( "商品区分コード[{0}]に該当するデータが存在しません。", this.MediumGoodsGanreName_tEdit.Text.TrimEnd() ),
        //                                -1, MessageBoxButtons.OK );
        //                // 前回値に戻す
        //                this.MediumGoodsGanreName_tEdit.Text = _prevHeaderInfo.MediumGoodsGanreName;
        //                this.MediumGoodsGanreName_tEdit.Tag = _prevHeaderInfo.MediumGoodsGanreCode;
        //                searchPara.MediumGoodsGanreCode = _prevHeaderInfo.MediumGoodsGanreCode;
        //                searchPara.MediumGoodsGanreName = _prevHeaderInfo.MediumGoodsGanreName;
        //            }
        //        }
        //        else
        //        {
        //            // 入力クリア
        //            this.SetSearchParaFromMGoodsGanre( null, ref searchPara );

        //            // 前回情報クリア
        //            _prevHeaderInfo.MediumGoodsGanreCode = string.Empty;
        //            _prevHeaderInfo.MediumGoodsGanreName = string.Empty;
        //        }
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// 商品区分グループ読み込み
        ///// </summary>
        ///// <param name="searchPara"></param>
        ///// <returns></returns>
        //private int ReadLargeGoodsGanre( ref StockSearchPara searchPara )
        //{
        //    int status = 0;

        //    if ( this.LargeGoodsGanreName_tEdit.Text.TrimEnd() == _prevHeaderInfo.LargeGoodsGanreName )
        //    {
        //        // 前回名称のまま→そのまま
        //    }
        //    else if ( this.LargeGoodsGanreName_tEdit.Text.TrimEnd() == _prevHeaderInfo.LargeGoodsGanreCode )
        //    {
        //        // 前回コードを同じ→名称に置き換える
        //        this.LargeGoodsGanreName_tEdit.Text = _prevHeaderInfo.LargeGoodsGanreName;
        //    }
        //    else
        //    {
        //        // 入力されているか？
        //        if ( this.LargeGoodsGanreName_tEdit.Text.Trim() != string.Empty )
        //        {
        //            LGoodsGanre lGoodsGanre;

        //            //  商品商品グループ取得処理
        //            status = this._goodsAcs.GetLargeGoodsGanreCode( this._enterpriseCode, this.LargeGoodsGanreName_tEdit.Text, out lGoodsGanre );
        //            if ( status == 0 )
        //            {
        //                // 結果セット
        //                this.SetSearchParaFromLGoodsGanre( lGoodsGanre, ref searchPara );

        //                // 前回入力更新
        //                _prevHeaderInfo.LargeGoodsGanreCode = lGoodsGanre.LargeGoodsGanreCode;
        //                _prevHeaderInfo.LargeGoodsGanreName = lGoodsGanre.LargeGoodsGanreName;
        //            }
        //            else
        //            {
        //                // 入力エラー
        //                //this.SetSearchParaFromLGoodsGanre(null, ref searchPara);

        //                TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
        //                                string.Format( "商品区分グループコード[{0}]に該当するデータが存在しません。", this.LargeGoodsGanreName_tEdit.Text.TrimEnd() ),
        //                                -1, MessageBoxButtons.OK );
        //                // 前回値に戻す
        //                this.LargeGoodsGanreName_tEdit.Text = _prevHeaderInfo.LargeGoodsGanreName;
        //                this.LargeGoodsGanreName_tEdit.Tag = _prevHeaderInfo.LargeGoodsGanreCode;
        //                searchPara.LargeGoodsGanreCode = _prevHeaderInfo.LargeGoodsGanreCode;
        //                searchPara.LargeGoodsGanreName = _prevHeaderInfo.LargeGoodsGanreName;
        //            }
        //        }
        //        else
        //        {
        //            // 入力クリア
        //            this.SetSearchParaFromLGoodsGanre( null, ref searchPara );

        //            // 前回情報クリア
        //            _prevHeaderInfo.LargeGoodsGanreCode = string.Empty;
        //            _prevHeaderInfo.LargeGoodsGanreName = string.Empty;
        //        }
        //    }

        //    return status;
        //}

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA DEL END
        /// <summary>
        /// メーカー読み込み処理
        /// </summary>
        /// <param name="searchPara"></param>
        /// <returns></returns>
        /// <br>Update Note: 2009/12/18 李侠</br>
        /// <br>             PM.NS-5・保守依頼④未登録のコードを入力時、コードを前回入力値に戻すように変更する</br>
        private int ReadMaker(ref StockSearchPara searchPara)
        {
            int status = 0;

            if (this.tNedit_GoodsMakerCd.GetInt() == _prevHeaderInfo.GoodsMakerCd)//.MakerName )
            {
                // 前回名称のまま→そのまま
            }
            else if (TStrConv.StrToIntDef(this.tNedit_GoodsMakerCd.Text.TrimEnd(), -1) == _prevHeaderInfo.GoodsMakerCd)
            {
                // 前回コードを同じ→名称に置き換える
                this.tNedit_GoodsMakerCd.SetInt(_prevHeaderInfo.GoodsMakerCd);
                this.uLabel_MakerName.Text = _prevHeaderInfo.MakerName;
            }
            else
            {
                // 入力されているか？
                if (this.tNedit_GoodsMakerCd.Text.Trim() != string.Empty)
                {
                    MakerUMnt maker;

                    string makerCode = this.tNedit_GoodsMakerCd.Text;

                    // メーカー情報取得処理
                    status = this._goodsAcs.GetMaker(this._enterpriseCode, TStrConv.StrToIntDef(makerCode, 0), out maker);
                    if (status == 0)
                    {
                        // 入力値セット
                        this.SetSearchParaFromMaker(maker, ref searchPara);

                        // 前回情報を更新
                        _prevHeaderInfo.GoodsMakerCd = maker.GoodsMakerCd;
                        _prevHeaderInfo.MakerName = maker.MakerName;
                    }
                    else
                    {
                        // 入力エラー
                        //this.SetSearchParaFromMaker( null, ref searchPara );

                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
                                        string.Format("メーカーコード[{0}]に該当するデータが存在しません。", makerCode),
                                        -1, MessageBoxButtons.OK);
                        // 前回値に戻す
                        this.tNedit_GoodsMakerCd.Text = _prevHeaderInfo.MakerName;
                        this.tNedit_GoodsMakerCd.Tag = _prevHeaderInfo.GoodsMakerCd;
                        searchPara.GoodsMakerCd = _prevHeaderInfo.GoodsMakerCd;
                        //searchPara.MakerName = _prevHeaderInfo.MakerName;
                        // --- ADD 2009/12/18 ---------->>>>>
                        this.tNedit_GoodsMakerCd.SetInt(_prevHeaderInfo.GoodsMakerCd);
                        // --- ADD 2009/12/18 ----------<<<<<
                    }
                }
                else
                {
                    // 入力クリア
                    this.SetSearchParaFromMaker(null, ref searchPara);

                    // 前回情報をクリア
                    _prevHeaderInfo.GoodsMakerCd = 0;
                    _prevHeaderInfo.MakerName = string.Empty;
                }
            }

            return status;
        }
        /// <summary>
        /// 仕入先読み込み処理
        /// </summary>
        /// <param name="searchPara"></param>
        /// <returns></returns>
        /// <br>Update Note: 2009/12/18 李侠</br>
        /// <br>             PM.NS-5・保守依頼④未登録のコードを入力時、コードを前回入力値に戻すように変更する</br>
        private int ReadCustomer(ref StockSearchPara searchPara)
        {
            int status = 0;

            if (this.tNedit_SupplierCd.GetInt() == _prevHeaderInfo.SupplierCode && _prevHeaderInfo.SupplierCode != 0)
            {
                // 前回名称のまま→そのまま
            }
            //else if ( this.tNedit_SupplierCd.Text.Trim() == _prevHeaderInfo.SupplierCode.ToString() )
            //{
            //    // 前回コードと同じ→名称に置き換える
            //    this.tEdit_SupplierName.Text = _prevHeaderInfo.SupplierName;
            //}
            else
            {
                // 入力されているか？
                if (!string.IsNullOrEmpty(this.tNedit_SupplierCd.Text.Trim()))
                {
                    // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //CustomerInfo customerInfo;
                    //CustSuppli custSuppli;

                    //string supplierCode = this.tEdit_SupplierName.Text.TrimEnd();

                    //status = this._customerInfoAcs.ReadDBDataWithCustSuppli( ConstantManagement.LogicalMode.GetData0,
                    //    this._enterpriseCode, TStrConv.StrToIntDef( supplierCode, 0 ), false, out customerInfo, out custSuppli );
                    //if ( status == 0 )
                    //{
                    //    // 抽出条件入力情報クラス格納処理
                    //    this.SetSearchParaFromCustomerInfo( customerInfo, ref searchPara );

                    //    // 前回情報更新
                    //    _prevHeaderInfo.SupplierCode = customerInfo.CustomerCode;
                    //    _prevHeaderInfo.SupplierName = customerInfo.Name;
                    //}
                    //else
                    //{
                    //    // 入力エラー
                    //    //this.SetSearchParaFromCustomerInfo( null, ref searchPara );

                    //    TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
                    //                    string.Format( "仕入先コード[{0}]に該当するデータが存在しません。", supplierCode ),
                    //                    -1, MessageBoxButtons.OK );
                    //    // 前回値に戻す
                    //    this.tEdit_SupplierName.Text = _prevHeaderInfo.SupplierName;
                    //    this.tEdit_SupplierName.Tag = _prevHeaderInfo.SupplierCode;
                    //    searchPara.CustomerCode = _prevHeaderInfo.SupplierCode;
                    //    searchPara.CustomerName = _prevHeaderInfo.SupplierName;
                    //}

                    Supplier supplier;
                    string supplierCode = this.tNedit_SupplierCd.Text.TrimEnd();

                    status = this._supplierAcs.Read(out supplier, this._enterpriseCode, TStrConv.StrToIntDef(supplierCode, 0));
                    if (status == 0)
                    {
                        // 抽出条件入力情報クラス格納処理
                        this.SetSearchParaFromSupplier(supplier, ref searchPara);

                        // 前回情報更新
                        _prevHeaderInfo.SupplierCode = supplier.SupplierCd;
                        _prevHeaderInfo.SupplierName = supplier.SupplierNm1;
                    }
                    else
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
                                        string.Format("仕入先コード[{0}]に該当するデータが存在しません。", supplierCode),
                                        -1, MessageBoxButtons.OK);
                        // 前回値に戻す
                        this.tEdit_SupplierName.Text = _prevHeaderInfo.SupplierName;
                        this.tEdit_SupplierName.Tag = _prevHeaderInfo.SupplierCode;
                        //searchPara.CustomerCode = _prevHeaderInfo.SupplierCode;
                        //searchPara.CustomerName = _prevHeaderInfo.SupplierName;
                        // --- ADD 2009/12/18 ---------->>>>>
                        this.tNedit_SupplierCd.DataText = _prevHeaderInfo.SupplierCode.ToString();
                        // --- ADD 2009/12/18 ----------<<<<<
                    }
                    // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                else
                {
                    // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// クリア
                    //this.SetSearchParaFromCustomerInfo(null, ref searchPara);
                    // クリア
                    this.SetSearchParaFromSupplier(null, ref searchPara);
                    // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 前回情報クリア
                    _prevHeaderInfo.SupplierCode = 0;
                    _prevHeaderInfo.SupplierName = string.Empty;
                }
            }

            return status;
        }

        /// <summary>
        /// 倉庫読み込み
        /// </summary>
        /// <br>Update Note: 2009/09/07       汪千来</br>
        /// <br>	       : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// <returns></returns>
        /// <br>Update Note: 2009/12/18 李侠</br>
        /// <br>             PM.NS-5・保守依頼④未登録のコードを入力時、コードを前回入力値に戻すように変更する</br>
        private int ReadWarehouse(ref StockSearchPara searchPara)
        {
            int status = 0;

            if (_prevHeaderInfo.WarehouseCode == this.tEdit_WarehouseCode.Text && _prevHeaderInfo.WarehouseCode != "")
            {
                // 前回のコードのまま→なにもしない
            }
            //else if ( _prevHeaderInfo.WarehouseCode == this.tEdit_WarehouseCode.Text.Trim() )
            //{
            //    // 前回と同じコード→名称に置き換える
            //    this.tEdit_WarehouseCode.Text = _prevHeaderInfo.WarehouseName;
            //}
            else
            {
                // 入力変更

                if (this.tEdit_WarehouseCode.Text.Trim() != string.Empty)
                {
                    Warehouse warehouse;
                    //string sectionCode = string.Empty;
                    //if ( this.Section_ComboEditor.Value != null )
                    //{
                    //    sectionCode = this.Section_ComboEditor.Value.ToString();
                    //}
                    //string sectionCode = this.tEdit_SectionCode.Text.TrimEnd();       // DEL 2009/09/07
                    string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();        // ADD 2009/09/07
                    string warehouseCode = this.tEdit_WarehouseCode.Text.TrimEnd();
                    if (sectionCode.Length > 0)
                    {
                        status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, sectionCode, warehouseCode);
                        if (status == 0)
                        {
                            // 抽出条件入力情報クラス格納処理
                            this.SetSearchParaFromWarehouse(warehouse, ref searchPara);

                            // 前回情報更新
                            //_prevHeaderInfo.WarehouseCode = warehouseCode.PadLeft(4, '0');        // DEL 2009/09/07
                            _prevHeaderInfo.WarehouseCode = warehouseCode.Trim().PadLeft(4, '0');       // ADD 2009/09/07
                            _prevHeaderInfo.WarehouseName = warehouse.WarehouseName.TrimEnd();
                        }
                        else
                        {
                            // 入力エラー
                            //this.SetSearchParaFromWarehouse( null, ref searchPara );

                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID,
                                            string.Format("倉庫コード[{0}]に該当するデータが存在しません。", warehouseCode),
                                            -1, MessageBoxButtons.OK);

                            // 前回値に戻す
                            searchPara.WarehouseCode = _prevHeaderInfo.WarehouseCode.PadLeft(4, '0');
                            searchPara.WarehouseName = _prevHeaderInfo.WarehouseName;
                            this.uLabel_WarehouseName.Text = _prevHeaderInfo.WarehouseName;
                            this.uLabel_WarehouseName.Tag = _prevHeaderInfo.WarehouseCode.PadLeft(4, '0');
                            // --- ADD 2009/12/18 ---------->>>>>
                            this.tEdit_WarehouseCode.Text = _prevHeaderInfo.WarehouseCode.TrimEnd();
                            // --- ADD 2009/12/18 ----------<<<<<
                        }
                    }
                }
                else
                {
                    // クリア
                    this.SetSearchParaFromWarehouse(null, ref searchPara);

                    // 前回情報クリア
                    _prevHeaderInfo.WarehouseCode = string.Empty;
                    _prevHeaderInfo.WarehouseName = string.Empty;
                }
            }

            return status;
        }

        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.01 TOKUNAGA ADD START

        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2009/09/07       汪千来</br>
        /// <br>	       : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// <br>Update Note: 2009/11/05       呉元嘯</br>
        /// <br>	       : Redmine#1114対応</br>
        /// <br>Update Note: 2009/12/18 李侠</br>
        /// <br>             PM.NS-5・保守依頼④のガイドに拠点00：全社が表示される</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            // --- UPD 2009/12/18 ---------->>>>>
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            // --- UPD 2009/12/18 ----------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //this.tEdit_SectionCode.Text = sectionInfo.SectionCode.TrimEnd(); // DEL 2009/03/09
                //this.tEdit_SectionCode.Text = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0'); // ADD 2009/03/09　// DEL 2009/09/07
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0'); // ADD 2009/09/07
                this.uLabel_SectionNm.Text = sectionInfo.SectionGuideNm.TrimEnd();
                // --- ADD 2009/12/18 ---------->>>>>
                _prevHeaderInfo.SectionCode = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0');
                _prevHeaderInfo.SectionName = sectionInfo.SectionGuideNm.TrimEnd();
                // --- ADD 2009/12/18 ----------<<<<<
            }
            //-------UPD 2009/11/05------->>>>>
            //else
            //{
            //    //this.tEdit_SectionCode.Clear();       // DEL 2009/09/07
            //    this.tEdit_SectionCodeAllowZero.Clear();    // ADD 2009/09/07
            //    this.uLabel_SectionNm.Text = "";
            //}
            //-------UPD 2009/11/05-------<<<<<
        }

        /// <summary>
        /// 拠点コード検索
        /// </summary>
        /// <param name="sender"></param>
        /// <br>Update Note: 2009/09/07       汪千来</br>
        /// <br>	       : tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero</br>
        /// <param name="e"></param>
        /// <br>Update Note: 2009/12/18 李侠</br>
        /// <br>             PM.NS-5・保守依頼④ 未登録の拠点コードを入力時、コードを前回入力値に戻す</br>
        //private void tEdit_SectionCode_Leave(object sender, EventArgs e) // DEL 2009/09/07
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)   // ADD 2009/09/07
        {
            // 拠点コード入力値を取得
            //string sectionCode = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0');      // DEL 2009/09/07
            string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');       // ADD 2009/09/07

            if (sectionCode == "00" || String.IsNullOrEmpty(sectionCode))
            {
                //this.tEdit_SectionCode.Text = "00";      // DEL 2009/09/07
                this.tEdit_SectionCodeAllowZero.Text = "00";        // ADD 2009/09/07
                this.uLabel_SectionNm.Text = "全社";
                // 2008.10.10 stokunaga add start
                this.tEdit_WarehouseCode.Focus();
                // 2008.10.10 stokunaga add end
                // --- ADD 2009/12/18 ---------->>>>>
                _prevHeaderInfo.SectionCode = "00";
                _prevHeaderInfo.SectionName = "全社";
                // --- ADD 2009/12/18 ----------<<<<<
            }
            else
            {
                // 拠点コードが入力されている場合のみ変換
                if (!String.IsNullOrEmpty(sectionCode))
                {
                    SecInfoSet sectionInfo;
                    int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //this.tEdit_SectionCode.Text = sectionCode;    // DEL 2009/09/07
                        this.tEdit_SectionCodeAllowZero.Text = sectionCode;     // ADD 2009/09/07
                        this.uLabel_SectionNm.Text = sectionInfo.SectionGuideNm.TrimEnd();
                        // --- ADD 2009/12/18 ---------->>>>>
                        _prevHeaderInfo.SectionCode = sectionCode;
                        _prevHeaderInfo.SectionName = sectionInfo.SectionGuideNm.TrimEnd();
                        // --- ADD 2009/12/18 ----------<<<<<
                    }
                    else
                    {
                        // 警告を出す？
                        TMsgDisp.Show(
                                  this,
                                  emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  // --- UPD 2009/12/18 ---------->>>>>
                                  //"入力された拠点は存在しません。",
                                  "拠点コード [" + sectionCode + "] に該当するデータが存在しません。",
                                  // --- UPD 2009/12/18 ----------<<<<<
                                  -1,
                                  MessageBoxButtons.OK);
                        // --- UPD 2009/12/18 ---------->>>>>
                        //this.uLabel_SectionNm.Text = "";
                        this.tEdit_SectionCodeAllowZero.Text = _prevHeaderInfo.SectionCode;
                        this.uLabel_SectionNm.Text = _prevHeaderInfo.SectionName;
                        this.tEdit_SectionCodeAllowZero.Focus();
                        // --- UPD 2009/12/18 ----------<<<<<
                    }
                }
            }
        }

        // ---DEL 2009/09/07  ----->>>>>
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tEdit_WarehouseCode_Enter(object sender, EventArgs e)
        //{
        //    // 入力されていれば
        //    if (!String.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim()))
        //    {
        //        this.tEdit_WarehouseCode.Text = this.tEdit_WarehouseCode.Text.Replace("0", "").Trim();
        //    }
        //    else
        //    {
        //        this.tEdit_WarehouseCode.Text = string.Empty;
        //    }
        //}
        // ---DEL 2009/09/07  -----<<<<<

        //private void tNedit_BLGoodsCode_Leave(object sender, EventArgs e)
        //{
        //    // 入力値を取得
        //    string inputValue = this.tNedit_BLGoodsCode.Text.Trim();

        //    // 空でなければ処理開始
        //    int blcode = int.Parse(inputValue);
        //    if (!string.IsNullOrEmpty(inputValue))
        //    {
        //        // コードから名称へ変換
        //        BLGoodsCdUMnt blGoodsUnit;
        //        int status = this._blGoodsCdAcs.Read(out blGoodsUnit, this._enterpriseCode, blcode);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            this.tEdit_BLGoodsName.Text = blGoodsUnit.BLGoodsFullName;
        //        }
        //        else
        //        {
        //            // 文字が不正な場合は項目をクリア
        //            this.tNedit_BLGoodsCode.Clear();
        //            this.tEdit_BLGoodsName.Clear();
        //        }
        //    }
        //}

        //private void tNedit_SupplierCd_Leave(object sender, EventArgs e)
        //{
        //    // 入力値を取得
        //    string inputValue = this.tNedit_SupplierCd.Text.Trim();

        //    // 空でなければ処理開始
        //    if (!string.IsNullOrEmpty(inputValue))
        //    {
        //        try
        //        {
        //            // コード変換
        //            int suppliercd = int.Parse(inputValue);

        //            // コードから名称へ変換
        //            Supplier supplierInfo;
        //            int status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, suppliercd);
        //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                this.tEdit_SupplierName.Text = supplierInfo.SupplierSnm;
        //            }
        //        }
        //        catch
        //        {
        //            // 文字が不正な場合は項目をクリア
        //            this.tNedit_SupplierCd.Clear();
        //            this.tEdit_SupplierName.Clear();
        //        }
        //    }
        //}

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.01 TOKUNAGA ADD END

        #endregion

        //private void ultraStatusBar_DoubleClick(object sender, EventArgs e)
        //{
        //  string workstr = string.Empty;

        //  Infragistics.Win.UltraWinGrid.UltraGridBand band0 = this.gridResult.DisplayLayout.Bands[0];
        //  Infragistics.Win.UltraWinGrid.ColumnsCollection clmns0 = band0.Columns;

        //  // 列の表示・非表示制御
        //  for (int i = 0; i < band0.Columns.Count; i++)
        //  {
        //    if (!band0.Columns[i].Hidden)
        //      workstr += String.Format("{0} = {1}", band0.Columns[i].Key, band0.Columns[i].Width) + "\n\r";
        //  }

        //  MessageBox.Show(workstr);

        //}


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        #region スレッド作成処理
        /// <summary>
        /// 初期化スレッド開始処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 商品アクセスクラスの取得を別スレッドにて行います。</br>
        /// <br>Programmer	: 20073 西 毅</br>
        /// <br>Date		: 2012/04/10</br>
        /// </remarks>
        private void StockAcsThreadStart()
        {
            // スレッドが実行中だったら処理を中断させる
            if ((StockAcsThread != null) && (StockAcsThread.ThreadState == System.Threading.ThreadState.Running))
            {
                StockAcsThread.Abort();
            }

            // Threadオブジェクトを作成する
            StockAcsThread = new Thread(new ThreadStart(StartThread));

            // スレッドを開始する
            StockAcsThread.Start();
        }
        #endregion
        #region ■ Private Method

        /// <summary>
        /// スレッドで開始するメソッド
        /// </summary>
        private void StartThread()
        {
            this._searchStockAcs = new SearchStockAcs(LoginInfoAcquisition.EnterpriseCode, this._loginSectionCode);

            this._goodsAcs = this._searchStockAcs.GoodsAcs;
        }
        #endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD



        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD

        // 在庫照会抽出用の専用メソッド
        /// <summary>
        /// 在庫検索（中断用）
        /// </summary>
        /// <param name="searchPara">在庫検索条件</param>
        /// <param name="stockSearchRetList">在庫結果データリスト(StockExpansion)</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note		: 在庫検索（中断用）を行う</br>
        /// <br>Programmer	: wf</br>
        /// <br>Date	    : 2012/04/10</br>
        /// </remarks>
        private int StopSearch2(StockSearchPara searchPara, out List<StockExpansion> stockSearchRetList, out string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";
            stockSearchRetList = new List<StockExpansion>();
            _extractCancelFlag = false;

            object retObj;

            try
            {
                // バッファクリア
                if (this._drStockSearchRet == null)
                    this._drStockSearchRet = new Dictionary<string, Dictionary<string, StockExpansion>>();
                else
                    this._drStockSearchRet.Clear();

                // 検索
                status = this._searchStockAcs.StopSearch2(searchPara, out retObj, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;

                            // 取得データを変換
                            if (retList != null)
                            {
                                ArrayList list = retList[0] as ArrayList;

                                gMaxCount = list.Count;
                                progressBar1.Maximum = gMaxCount;
                                progressBar1.Visible = true;
                                ultraLabel1.Visible = true;
                                ultraLabel2.Visible = true;

                                Infragistics.Win.UltraWinToolbars.ButtonTool undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo];
                                Infragistics.Win.UltraWinToolbars.ButtonTool pauseButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Pause];
                                Infragistics.Win.UltraWinToolbars.ButtonTool popUndoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_PopUndo];

                                pauseButton.SharedProps.Enabled = true;
                                undoButton.SharedProps.Enabled = false;
                                popUndoButton.SharedProps.Enabled = false;
                                this.setItemsEnable(false);


                                Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search];
                                Infragistics.Win.UltraWinToolbars.ButtonTool stopButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Stop];


                                searchButton.SharedProps.Visible = false;
                                stopButton.SharedProps.Visible = true;

                                ultraLabel1.Text = "現在、データ抽出中です。";


                                // 在庫データの取得
                                status = GetStockWorkToUIdata2(retList, out stockSearchRetList);

                                // 処理中断
                                if (_extractCancelFlag == true)
                                {
                                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }

                                switch (status)
                                {
                                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                        {
                                            foreach (StockExpansion stockSearchRet in stockSearchRetList)
                                            {
                                                Dictionary<string, StockExpansion> stock;

                                                // 拠点コード毎の在庫リストを取得する
                                                if (this._drStockSearchRet.ContainsKey(stockSearchRet.SectionCode))
                                                {
                                                    stock = this._drStockSearchRet[stockSearchRet.SectionCode];
                                                }
                                                else
                                                {
                                                    stock = new Dictionary<string, StockExpansion>();
                                                    this._drStockSearchRet.Add(stockSearchRet.SectionCode, stock);
                                                }

                                                // プライマリキーを作成
                                                string primaryKey = this.GetPrimaryKeyStock(stockSearchRet.SectionCode,
                                                                                             stockSearchRet.WarehouseCode,
                                                                                             stockSearchRet.GoodsMakerCd,
                                                                                             stockSearchRet.GoodsNo
                                                                                           );

                                                if (stock.ContainsKey(primaryKey))
                                                {
                                                    // 在庫データを更新
                                                    stock[primaryKey] = stockSearchRet.Clone();
                                                }
                                                else
                                                {
                                                    // 在庫データを追加
                                                    stock.Add(primaryKey, stockSearchRet.Clone());
                                                }
                                            }

                                            break;
                                        }
                                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                        {
                                            // --- ADD 2012/09/26 ---------->>>>>
                                            // ツールボタンを戻す
                                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo].SharedProps.Enabled = true;
                                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Pause].SharedProps.Enabled = false;
                                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search].SharedProps.Visible = true;
                                            this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Stop].SharedProps.Visible = false;

                                            // 検索条件を入力可能にする
                                            this.setItemsEnable(true);

                                            // 合計金額をクリア
                                            this.uLabel_TotalStockCount.Text = "0.00";
                                            this.uLabel_TotalStockValue.Text = "\\0";

                                            // ラベル文字列を非表示
                                            this.progressBar1.Visible = false;
                                            this.ultraLabel1.Visible = false;
                                            this.ultraLabel2.Visible = false;
                                            // --- ADD 2012/09/26 ----------<<<<<
                                            break;
                                        }
                                    default:
                                        msg = "在庫データの取得でエラーが発生しました";
                                        return status;
                                }

                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    default:
                        msg = "在庫データの取得に失敗しました";
                        return status;
                }

                int ret1, ret2 = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                ret1 = ret2 = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                // 在庫検索結果
                if (this._drStockSearchRet != null && this._drStockSearchRet.Count > 0)
                {
                    stockSearchRetList = new List<StockExpansion>();

                    foreach (KeyValuePair<string, Dictionary<string, StockExpansion>> kvP in this._drStockSearchRet)
                    {
                        stockSearchRetList.AddRange(kvP.Value.Values);
                    }

                    ret1 = (stockSearchRetList.Count != 0) ? (int)ConstantManagement.DB_Status.ctDB_NORMAL : (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                if (ret1 == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && ret2 == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "在庫検索で例外が発生しました[" + ex.Message + "]";
                msg = ex.Message;
            }


            this.gridResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            this.gridResult.Refresh();
            // カラムサイズ調整
            this.ColumnPerformAutoResize();

            return status;
        }

        /// <summary>
        /// CustomSerializeArrayList →　在庫クラス取得
        /// </summary>
        /// <param name="retList">WORK型データリスト</param>
        /// <param name="uiList">在庫クラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        private int GetStockWorkToUIdata2(CustomSerializeArrayList retList, out List<StockExpansion> uiList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            uiList = null;

            try
            {
                foreach (ArrayList arList in retList)
                {
                    if (_extractCancelFlag == true)
                    {
                        break;
                    }
                    if (arList != null && arList.Count > 0)
                    {
                        if (arList[0] is StockEachWarehouseWork)
                        {
                            // クラスメンバーコピー処理
                            uiList = this.CopyToStockFromStockWork3(arList);


                            status = (uiList.Count != 0) ? (int)ConstantManagement.DB_Status.ctDB_NORMAL : (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // 例外を発生させる
                string message = "在庫データクラス取得で例外が発生しました[" + ex.Message + "]";
                throw new SearchStockAcsException(message, -1);
            }

            return status;
        }

        /// <summary>
        /// 在庫プライマリーキー情報取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsCode">商品コード</param>
        /// <returns>プライマリキー情報</returns>
        private string GetPrimaryKeyStock(string sectionCode, string warehouseCode, int makerCode, string goodsCode)
        {
            string primaryKey = String.Empty;

            // 拠点コード + 倉庫コード + メーカーコード + 商品コードで辞書キーを作成する
            primaryKey = sectionCode.PadRight(6, ' ') + warehouseCode.PadRight(6, ' ') + makerCode.ToString("000000") + goodsCode;

            return primaryKey;
        }

        /// <summary>
        /// クラスメンバーコピー処理（在庫ワークリスト⇒在庫クラス(List<T>)）
        /// </summary>
        /// <param name="workList">在庫ワークリスト</param>
        /// <returns>在庫クラス(List)</returns>
        private List<StockExpansion> CopyToStockFromStockWork3(ArrayList workList)
        {
            // ご提案シートタイプリスト
            List<StockExpansion> stockRetList = null;

            // 商品管理在庫クラスから仕入れ情報を取得し、ない場合は結果として返さない
            List<GoodsUnitData> unitDataList = new List<GoodsUnitData>();
            SupplierAcs supplierAcs = new SupplierAcs();
            string msg = string.Empty;

            if (workList != null)
            {
                stockRetList = new List<StockExpansion>();
                StockExpansion stockEx = null;

                foreach (StockEachWarehouseWork wrk in workList)
                {
                    if (_searchStockAcs.ExtractCancelFlag == true)
                    {
                        int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            "処理を中断しました。",
                            status,
                            MessageBoxButtons.OK);

                        Infragistics.Win.UltraWinToolbars.ButtonTool undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Undo];
                        Infragistics.Win.UltraWinToolbars.ButtonTool pauseButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Pause];
                        Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Search];
                        Infragistics.Win.UltraWinToolbars.ButtonTool stopButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_UToolbarsManager.Tools[CT_BUTTONTOOL_Stop];


                        undoButton.SharedProps.Enabled = true;
                        pauseButton.SharedProps.Enabled = false;

                        searchButton.SharedProps.Visible = true;
                        stopButton.SharedProps.Visible = false;

                        this.setItemsEnable(true);

                        break;
                    }

                    if (_extractPauseFlag == true)
                    {
                        int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            "処理を停止しました。",
                            status,
                            MessageBoxButtons.OK);
                        while (_extractPauseFlag == true)
                        {
                            Thread.Sleep(100);
                            System.Windows.Forms.Application.DoEvents();
                        }
                    }

                    if (_extractCancelFlag == true)
                    {
                        break;
                    }
                    //GoodsunitDataクラスに値をセットして掛率を取得
                    GoodsUnitData unitData = new GoodsUnitData();
                    unitData.BLGoodsCode = wrk.BLGoodsCode;
                    unitData.CreateDateTime = wrk.CreateDateTime;
                    unitData.DisplayOrder = wrk.DisplayOrder;
                    unitData.EnterpriseCode = wrk.EnterpriseCode;
                    unitData.EnterpriseGanreCode = wrk.EnterpriseGanreCode;
                    unitData.FileHeaderGuid = wrk.FileHeaderGuid;
                    unitData.GoodsKindCode = wrk.GoodsKindCode;
                    unitData.GoodsMakerCd = wrk.GoodsMakerCd;
                    unitData.GoodsName = wrk.GoodsName;
                    unitData.GoodsNameKana = wrk.GoodsNameKana;
                    unitData.GoodsNo = wrk.GoodsNo;
                    unitData.GoodsNoNoneHyphen = wrk.GoodsNoNoneHyphen;
                    unitData.GoodsNote1 = wrk.GoodsNote1;
                    unitData.GoodsNote2 = wrk.GoodsNote2;
                    unitData.GoodsRateRank = wrk.GoodsRateRank;
                    unitData.GoodsSpecialNote = wrk.GoodsSpecialNote;
                    unitData.Jan = wrk.Jan;
                    unitData.LogicalDeleteCode = wrk.LogicalDeleteCode;
                    unitData.SectionCode = wrk.SectionCode;
                    unitData.TaxationDivCd = wrk.TaxationDivCd;
                    unitData.UpdAssemblyId1 = wrk.UpdAssemblyId1;
                    unitData.UpdAssemblyId2 = wrk.UpdAssemblyId2;
                    unitData.UpdateDate = wrk.UpdateDate;
                    unitData.UpdateDateTime = wrk.UpdateDateTime;
                    unitData.UpdEmployeeCode = wrk.UpdEmployeeCode;

                    List<GoodsPrice> goodsPriceList;
                    goodsPriceList = new List<GoodsPrice>();
                    GoodsPrice goodsPrice = new GoodsPrice();
                    goodsPrice.GoodsNo = wrk.GoodsNo;
                    goodsPrice.ListPrice = wrk.ListPrice;
                    goodsPrice.PriceStartDate = TDateTime.LongDateToDateTime(wrk.PriceStartDate);
                    goodsPrice.StockRate = wrk.StockRate;
                    goodsPrice.EnterpriseCode = wrk.EnterpriseCode;
                    goodsPrice.GoodsMakerCd = wrk.GoodsMakerCd;
                    goodsPrice.LogicalDeleteCode = 0; // 論理削除区分
                    goodsPrice.SalesUnitCost = wrk.SalesUnitCost;
                    goodsPriceList.Add(goodsPrice);
                    unitData.GoodsPriceList = goodsPriceList;

                    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData);

                    // --- ADD 2012/11/06 ---------->>>>>
                    if (this._paraSupplierCd > 0)
                    {
                        if (this._paraSupplierCd != unitData.SupplierCd)
                        {
                            continue;
                        }
                    }
                    // --- ADD 2012/11/06 ----------<<<<<

                    stockEx = CopyToStockExpansionFromStockEachWarehouseWork(wrk);
                    stockEx.SupplierCd = unitData.SupplierCd;   // 仕入先コード
                    stockEx.SupplierSnm = unitData.SupplierSnm; // 仕入先略称
                    stockEx.MakerName = unitData.MakerName;     // メーカー名称

                    stockEx.ListPrice = wrk.ListPrice;
                    stockEx.StockUnitPriceFl = GetStockUnitPrice(unitData);
                    stockEx.StockTotalPrice = this.StockTotalPriceToLong(stockEx);

                    // RetListに追加
                    stockRetList.Add(stockEx);
                    // 画面に展開
                    int sts = SetStockDataTable2(stockEx, out msg);

                    if (sts != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, -1, MessageBoxButtons.OK);
                        break;
                    }

                    // --- DEL 2012/09/26 ---------->>>>>
                    //// 検索条件と同じであれば追加
                    //if (this._paraSupplierCd > 0)
                    //{
                    //    if (this._paraSupplierCd == stockEx.SupplierCd) stockRetList.Add(stockEx);
                    //}
                    //else
                    //{
                    //    // 検索条件がなければ無条件で追加
                    //    stockRetList.Add(stockEx);
                    //}

                    //int sts = SetStockDataTable2(stockEx, out msg);

                    //if (sts != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //{
                    //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, -1, MessageBoxButtons.OK);
                    //    break;
                    //}
                    // --- DEL 2012/09/26 ----------<<<<<

                    // --- DEL 2012/11/06 ---------->>>>>
                    // --- ADD 2012/09/26 ---------->>>>>
                    //int sts = 0;

                    //// 検索条件と同じであれば追加
                    //if (this._paraSupplierCd > 0)
                    //{
                    //    if (this._paraSupplierCd == stockEx.SupplierCd)
                    //    {
                    //        // RetListに追加
                    //        stockRetList.Add(stockEx);
                    //        // 画面に展開
                    //        sts = SetStockDataTable2(stockEx, out msg);

                    //        if (sts != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //        {
                    //            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, -1, MessageBoxButtons.OK);
                    //            break;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    // 検索条件がなければ無条件で追加
                    //    stockRetList.Add(stockEx);

                    //    // 画面に展開
                    //    sts = SetStockDataTable2(stockEx, out msg);

                    //    if (sts != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //    {
                    //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, -1, MessageBoxButtons.OK);
                    //        break;
                    //    }
                    //}
                    // --- ADD 2012/09/26 ----------<<<<<
                    // --- DEL 2012/11/06 ----------<<<<<
                }
            }

            return stockRetList;
        }

        /// <summary>
        /// クラスメンバーコピー処理（在庫ワーククラス(在庫)⇒商品在庫情報クラス(在庫)）
        /// </summary>
        /// <param name="stockWork">在庫ワーククラス(在庫)</param>
        /// <returns>在庫クラス(在庫)</returns>
        private StockExpansion CopyToStockExpansionFromStockEachWarehouseWork(StockEachWarehouseWork stockWork)
        {
            StockExpansion stock = new StockExpansion();

            if (stockWork != null)
            {
                // 作成日時
                stock.CreateDateTime = stockWork.CreateDateTime;

                // 更新日時
                stock.UpdateDateTime = stockWork.UpdateDateTime;

                // 企業コード
                stock.EnterpriseCode = stockWork.EnterpriseCode;

                // GUID
                stock.FileHeaderGuid = stockWork.FileHeaderGuid;

                // 更新従業員コード
                stock.UpdEmployeeCode = stockWork.UpdEmployeeCode;

                // 更新アセンブリID1
                stock.UpdAssemblyId1 = stockWork.UpdAssemblyId1;

                // 更新アセンブリID2
                stock.UpdAssemblyId2 = stockWork.UpdAssemblyId2;

                // 論理削除区分
                stock.LogicalDeleteCode = stockWork.LogicalDeleteCode;

                // 倉庫コード
                stock.WarehouseCode = stockWork.WarehouseCode;

                // 棚番
                stock.WarehouseShelfNo = stockWork.WarehouseShelfNo;

                // メーカーコード
                stock.GoodsMakerCd = stockWork.GoodsMakerCd;

                // 品名
                stock.GoodsName = stockWork.GoodsName;

                // 品番
                stock.GoodsNo = stockWork.GoodsNo;

                // 現在庫(仕)
                stock.SupplierStock = stockWork.SupplierStock;

                // 最低在庫数
                stock.MinimumStockCnt = stockWork.MinimumStockCnt;

                // 最高在庫数
                stock.MaximumStockCnt = stockWork.MaximumStockCnt;

                // 発注残
                stock.SalesOrderCount = stockWork.SalesOrderCount;

                // 出荷可能数
                stock.ShipmentPosCnt = stockWork.ShipmentPosCnt;

                // 移動数
                stock.MovingSupliStock = stockWork.MovingSupliStock;

                // 出荷数（未計上）
                stock.ShipmentCnt = stockWork.ShipmentCnt;

                // 入荷数（未計上）
                stock.ArrivalCnt = stockWork.ArrivalCnt;

                // 受注数
                stock.AcpOdrCount = stockWork.AcpOdrCount;

                // 規格・特記事項
                stock.GoodsSpecialNote = stockWork.GoodsSpecialNote;

                // ＢＬコード
                stock.BLGoodsCode = stockWork.BLGoodsCode;

                // 品名カナ
                stock.GoodsNameKana = stockWork.GoodsNameKana;

                // 棚番１
                stock.DuplicationShelfNo1 = stockWork.DuplicationShelfNo1;

                // 棚番２
                stock.DuplicationShelfNo2 = stockWork.DuplicationShelfNo2;

                // 仕入単価
                stock.StockUnitPriceFl = stockWork.StockUnitPriceFl;

                // 在庫金額
                stock.StockTotalPrice = stockWork.StockTotalPrice;

                // 登録日付
                stock.StockCreateDate = stockWork.StockCreateDate;

                // 更新日付
                stock.UpdateDate = TDateTime.DateTimeToLongDate(stockWork.UpdateDate);

                // 拠点コード
                stock.SectionCode = stockWork.SectionCode;

                // 拠点ガイド名称
                stock.SectionGuideNm = stockWork.SectionGuideNm;

                // 倉庫名称
                stock.WarehouseName = stockWork.WarehouseName;

                // 発注ロット
                stock.SupplierLot = stockWork.SalesOrderUnit;
                

                // ここまで表示項目
                // 以下は整合性確保のために必要

                // M/O発注数
                stock.MonthOrderCount = stockWork.MonthOrderCount;

                // 最終仕入年月日
                stock.LastStockDate = stockWork.LastStockDate;

                // 最終売上日
                stock.LastSalesDate = stockWork.LastSalesDate;

                // 最終棚卸更新日
                stock.LastInventoryUpdate = stockWork.LastInventoryUpdate;


                // 基準発注数
                stock.NmlSalOdrCount = stockWork.NmlSalOdrCount;

                // 発注単位
                stock.SalesOrderUnit = stockWork.SalesOrderUnit;

                // ハイフン無商品番号
                stock.GoodsNoNoneHyphen = stockWork.GoodsNoNoneHyphen;

                // 部品管理区分１
                stock.PartsManagementDivide1 = stockWork.PartsManagementDivide1;

                // 部品管理区分２
                stock.PartsManagementDivide2 = stockWork.PartsManagementDivide2;

                // 在庫備考１
                stock.StockNote1 = stockWork.StockNote1;

                // 在庫備考２
                stock.StockNote2 = stockWork.StockNote2;

            }

            return stock;
        }

        /// <summary>
        /// 原単価取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>原単価</returns>
        private Double GetStockUnitPrice(GoodsUnitData goodsUnitData)
        {
            Double stockUnitPrice = 0;

            // 商品連結データから単価算出結果オブジェクトを取得
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData);

            // 単価算出結果オブジェクトより原単価取得
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }
        /// <summary>
        /// 在庫金額算出(Long型で返す)
        /// </summary>
        /// <param name="stockEx"></param>
        /// <returns>在庫金額</returns>
        private long StockTotalPriceToLong(StockExpansion stockEx)
        {
            long longStockTotalPrice = 0;
            double doubleStockTotalPrice = stockEx.StockUnitPriceFl * stockEx.ShipmentPosCnt;       // 原単価×現在庫数

            // 在庫全体管理設定の端数処理区分に従う
            switch (this._searchStockAcs.StockMngTtlSt.FractionProcCd)
            {
                case 1:
                    {
                        // 切り捨て
                        longStockTotalPrice = (long)(doubleStockTotalPrice / 1);
                        break;
                    }
                case 2:
                    {
                        // 四捨五入
                        if (doubleStockTotalPrice >= 0)
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);
                        }
                        else
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice - 0.5) / 1);
                        }

                        break;
                    }
                case 3:
                    {
                        // 切り上げ
                        if (doubleStockTotalPrice % 1 == 0)
                        {
                            longStockTotalPrice = (long)(doubleStockTotalPrice);
                        }
                        else
                        {
                            if (doubleStockTotalPrice >= 0)
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);
                            }
                            else
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice - 1) / 1);
                            }
                        }
                        break;
                    }
                default:
                    {
                        longStockTotalPrice = (long)(doubleStockTotalPrice);
                        break;
                    }
            }

            return longStockTotalPrice;
        }

        /// <summary>
        /// 在庫データテーブル設定処理
        /// </summary>
        /// <param name="stockList">在庫クラスリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        private int SetStockDataTable2(StockExpansion stockEx, out string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            msg = "";

            if (stockEx == null) return 0;

            try
            {

                this._stockDataTable.BeginLoadData();
                if (this._stockDataTable.Rows.Count >= CT_MaxRowCount)
                {
                    msg = "表示最大行数になりました。検索条件を絞って検索して下さい";
                    status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                    return status;
                }

                DataRow row = this._stockDataTable.NewRow();

                // 列選択
                row[CT_Select] = false;
                // 列未選択
                row[CT_SelectButton] = "";


                // --- ADD 2012/09/18 ---------->>>>>
                // テキスト出力時に余計なスペースが出力されないようにする
                // row[CT_WarehouseCode] = stockEx.WarehouseCode;              // 倉庫コード
                row[CT_WarehouseCode] = stockEx.WarehouseCode.Trim();              // 倉庫コード
                // --- ADD 2012/09/18 ----------<<<<<

                row[CT_WarehouseShelfNo] = stockEx.WarehouseShelfNo;        // 棚番

                // 仕入先コード
                if (stockEx.GoodsMakerCd == 0)
                {
                    row[CT_MakerCode] = string.Empty;
                }
                else
                {
                    row[CT_MakerCode] = stockEx.GoodsMakerCd.ToString("0000");
                }

                row[CT_GoodsName] = stockEx.GoodsName;                      // 品名
                row[CT_GoodsCode] = stockEx.GoodsNo;                        // 品番
                row[CT_SupplierStock] = stockEx.SupplierStock;              // 現在庫(仕)
                row[CT_MinimumStockCnt] = stockEx.MinimumStockCnt;          // 最低在庫
                row[CT_MaximumStockCnt] = stockEx.MaximumStockCnt;          // 最高在庫
                row[CT_SalesOrderCount] = stockEx.SalesOrderCount;          // 発注残
                row[CT_SupplierLot] = stockEx.SupplierLot;                  // 発注ロット
                row[CT_ShipmentPosCnt] = stockEx.ShipmentPosCnt;            // 出荷可能数
                row[CT_MovingSupliStock] = stockEx.MovingSupliStock;        // 移動数
                row[CT_ShipmentCnt] = stockEx.ShipmentCnt;                  // 出荷数（未計上）
                row[CT_ArrivalCnt] = stockEx.ArrivalCnt;                    // 入荷数（未計上）
                row[CT_AcpOdrCount] = stockEx.AcpOdrCount;                  // 受注数
                row[CT_GoodsSpecialNote] = stockEx.GoodsSpecialNote;        // 規格・特記事項
                //2008.10.03 stokunaga ADD start
                if (stockEx.BLGoodsCode == 0)
                {
                    row[CT_BLGoodsCode] = DBNull.Value;                  // BLコード
                }
                else
                {
                    row[CT_BLGoodsCode] = stockEx.BLGoodsCode.ToString("00000");
                }

                row[CT_GoodsNameKana] = stockEx.GoodsNameKana;              // 商品名称カナ
                row[CT_DuplicationShelfNo1] = stockEx.DuplicationShelfNo1;  // 棚番1
                row[CT_DuplicationShelfNo2] = stockEx.DuplicationShelfNo2;  // 棚番2
                row[CT_MakerName] = stockEx.MakerName;                      // メーカー名称

                // 仕入先コード
                if (stockEx.SupplierCd == 0)
                {
                    row[CT_SupplierCd] = string.Empty;
                }
                else
                {
                    row[CT_SupplierCd] = stockEx.SupplierCd.ToString("000000");
                }

                row[CT_SupplierSnm] = stockEx.SupplierSnm;                  // 仕入先略名
                row[CT_ListPrice] = stockEx.ListPrice;                      // 標準価格
                row[CT_StockUnitPrice] = stockEx.StockUnitPriceFl;          // 仕入単価
                row[CT_StockTotalPrice] = stockEx.StockTotalPrice;          // 在庫金額
                row[CT_UpdateDateString] = stockEx.UpdateDateString;        // 更新日付
                row[CT_StockCreateDateString] = stockEx.StockCreateDateString;  // 登録日付

                // --- ADD 2012/09/18 ---------->>>>>
                // テキスト出力時に余計なスペースが出力されないようにする
                // row[CT_SectionCode] = stockEx.SectionCode;                  // 拠点コード
                row[CT_SectionCode] = stockEx.SectionCode.Trim();                  // 拠点コード
                // --- ADD 2012/09/18 ----------<<<<<

                row[CT_SectionName] = stockEx.SectionGuideNm;               // 拠点名

                row[CT_WarehouseName] = stockEx.WarehouseName;              // 倉庫名


                // 選択用在庫データ格納
                row[CT_StockSearchRet] = stockEx.Clone();

                gtotalStockCount = gtotalStockCount + stockEx.ShipmentPosCnt;        
                gtotalStockValue = gtotalStockValue + stockEx.StockTotalPrice;

                this._stockDataTable.Rows.Add(row);
                growCount++;
                progressBar1.Value = growCount;
                if (growCount % 10 == 0)
                {
                    switch (growCount % 50)
                    //switch ((growCount / 100) % 5)
                    {
                        case 0:
                            ultraLabel1.Text = "現在、データ抽出中です・";
                            break;
                        case 10:
                            ultraLabel1.Text = "現在、データ抽出中です・・";
                            break;
                        case 20:
                            ultraLabel1.Text = "現在、データ抽出中です・・・";
                            break;
                        case 30:
                            ultraLabel1.Text = "現在、データ抽出中です・・・・";
                            break;
                        case 40:
                            ultraLabel1.Text = "現在、データ抽出中です・・・・・";
                            break;
                    }
                    ultraLabel2.Text = growCount.ToString() + "/" + gMaxCount.ToString() + "件";
                    this.Refresh();
                    this.Update();
                    this.Invalidate();
                }
                System.Windows.Forms.Application.DoEvents();

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                msg = "在庫テーブル作成中にて例外が発生しました[" + ex.Message + "]";
            }
            finally
            {
                this._stockDataTable.EndLoadData();
            }

            return status;
        }

        /// <summary>
        /// 単価算出結果オブジェクト取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>単価算出結果オブジェクト</returns>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                              // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._searchStockAcs.TaxRateSet, DateTime.Today);         // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._searchStockAcs.UnitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// 各条件項目のEnabledを設定
        /// </summary>
        /// <param name="value">項目のEnabledの設定値</param>
        private void setItemsEnable(Boolean value)
        {
            this.tEdit_SectionCodeAllowZero.Enabled = value;
            this.uButton_SectionGuide.Enabled = value;
            this.tComboEditor_DateDiv.Enabled = value;
            this.tEdit_WarehouseCode.Enabled = value;
            this.uButton_WarehouseGuide.Enabled = value;
            this.tDateEdit_Date1Start.Enabled = value;
            this.tDateEdit_Date1End.Enabled = value;
            this.tEdit_WarehouseShelfNo.Enabled = value;
            this.tNedit_GoodsMakerCd.Enabled = value;
            this.MakerGuide_Button.Enabled = value;
            this.StockZero_tComboEditor.Enabled = value;
            this.tEdit_GoodsNo.Enabled = value;
            this.SortDiv_tComboEditor.Enabled = value;
            this.tEdit_GoodsName.Enabled = value;
            this.GoodsNameKana_tEdit.Enabled = value;
            this.tNedit_SupplierCd.Enabled = value;
            this.uButton_SupplierGuide.Enabled = value;
            this.tNedit_BLGoodsCode.Enabled = value;
            this.BLGoodsCodeGuide_Button.Enabled = value;
        }

        // ===============================================================================
        // 例外クラス
        // ===============================================================================
        #region ◆　SearchStockAcsException例外
        public class SearchStockAcsException : ApplicationException
        {
            private int _status;

            #region constructor
            public SearchStockAcsException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region public property
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

    }


}
