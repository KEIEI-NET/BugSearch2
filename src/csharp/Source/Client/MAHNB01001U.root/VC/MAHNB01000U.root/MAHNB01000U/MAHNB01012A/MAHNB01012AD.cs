using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
//using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Reflection;// ADD 鄧潘ハン K2014/02/17

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上入力用初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の初期値取得データ制御を行います。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 對馬 大輔  新規作成</br>
    /// <br>2009.07.15 22018 鈴木 正臣 MANTIS[0013801] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// <br>Update Note  : 2009/09/08 張凱</br>
    /// <br>               PM.NS-2-A・車輌管理</br>
    /// <br>               車輌管理機能の追加</br>
    /// <br>Update Note  : 2009/10/19 張凱</br>
    /// <br>               PM.NS-3-A・保守依頼②</br>
    /// <br>               保守依頼②機能の追加</br>
    /// <br>Update Note :  2009/11/13 李占川</br>
    /// <br>               PM.NS-4-A・保守依頼③</br>
    /// <br>               TBO検索ボタンからTBO検索の修正</br>
    /// <br>Update Note :  2009/12/23 張凱</br>
    /// <br>               PM.NS-3-A・PM.NS保守依頼④</br>
    /// <br>               PM.NS保守依頼④を追加</br>
    /// <br>Update Note : 2010/02/26 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note : 2010/03/01 李占川 PM.NS保守依頼５次改良対応</br>
    /// <br>              単価モジュールの掛率優先管理マスタキャッシュ処理を使用するように変更</br>
    /// <br>Update Note : 2010/04/28 20056 對馬 大輔</br>
    /// <br>              検索速度アップ対応</br>
    /// <br>Update Note : 2010/05/30 20056 對馬 大輔 </br>
    /// <br>              成果物統合(６次改良＋７次改良＋自由検索＋SCM)</br>
    /// <br>Update Note : 2010/06/02 譚洪 PM.NS障害・改良対応（７月リリース案件）</br>
    /// <br>Update Note : 2010/06/26 李占川 </br>
    /// <br>              BLコード変換処理のロジックの削除</br>
    /// <br>Update Note : 2010/07/29 20056 對馬 大輔 </br>
    /// <br>              表示区分マスタが特定タイミングに取得できない件の対応(初期取得マスタ最終時にリストがnullの場合、再取得する)</br>
    /// <br>Update Note : 2010/08/30 20056 對馬 大輔 </br>
    /// <br>              税率設定範囲チェック追加</br>
    /// <br>Update Note : 2011/09/27 20056 對馬 大輔</br>
    /// <br>              在庫数表示区分を参照し、現在庫数の表示制御を行う</br>
    /// <br>Update Note : 2012/06/14 20073 西 毅 </br>
    /// <br>              倉庫マスタエラー修正</br>
    /// <br>Update Note : 2012/11/13 宮本 利明</br>
    /// <br>管理番号    : 10801804-00 №1668</br>
    /// <br>              売上過去日付制御を個別オプション化（イスコまたはオプションありで日付制御）</br>
    /// <br>Update Note : 2012/12/19 西 毅</br>
    /// <br>管理番号    : 10801804-00</br>
    /// <br>              MAHNB01001U.Logが存在する場合ログを出力するように変更</br>
    /// <br>Update Note : 2012/12/21 宮本 利明</br>
    /// <br>管理番号    : 10801804-00</br>
    /// <br>              山形部品オプション対応</br>
    /// <br>Update Note : 2013/02/13 脇田 靖之</br>
    /// <br>管理番号    : 10801804-00</br>
    /// <br>              結合検索時のSearchInitialメソッドを修正（速度改善）</br>
    /// <br>Update Note: K2013/09/20 宮本 利明</br>
    /// <br>             ㈱フタバオプション対応（個別）</br>
    /// <br>Update Note : 2013/05/09 西 毅</br>
    /// <br>管理番号    : 10902175-00 仕掛一覧№935(#30784) </br>
    /// <br>              売上全体設定のＢＬコード枝番区分が「枝番あり」で設定する時、画面起動する後、ＢＬコード検索できない</br>
    /// <br>Update Note : 2013/09/13 湯上</br>
    /// <br>管理番号    : 10801804-00</br>
    /// <br>              SCM仕掛一覧№10571対応　参照倉庫追加</br>
    /// <br>Update Note : K2014/01/22 譚洪</br>
    /// <br>管理番号    : 10970602-00</br>
    /// <br>              登戸個別特販区分の変更対応</br>
    /// <br>Update Note : K2014/02/17 鄧潘ハン</br>
    /// <br>管理番号    : 10970602-00</br>
    /// <br>              ＵＳＢ登戸個別オプションＯＮ ＡＮＤ 特販管理マスタの個別</br>
    /// <br>              アセンブリが動作環境に存在する場合 ⇒オプションＯＮの対応</br>
    /// <br>Update Note: 2014/08/11 duzg</br>
    /// <br>管理番号   : </br>
    /// <br>             検証／総合テスト障害No.5</br>
    /// <br>Update Note: 2015/02/18  30744 湯上</br>
    /// <br>管理番号   : 11070266-00</br>
    /// <br>           : SCM高速化Redmine#243対応</br>
    /// <br>Update Note: 2015/03/18  31065 豊沢</br>
    /// <br>管理番号   : 11070266-00</br>
    /// <br>           : SCM高速化 メーカー希望小売価格対応</br>
    /// <br>Update Note: K2015/04/01 高騁 </br>
    /// <br>管理番号   : 11100713-00</br>
    /// <br>           : 森川部品個別依頼の改良作業全拠点在庫情報一覧機能追加</br>
    /// <br>Update Note: 2015/04/06 30757 佐々木 貴英</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>             仕掛№2405 得意先変更時表示区分再取得対応</br>
    /// <br>Update Note: K2015/04/29 黄興貴</br>
    /// <br>管理番号   : 11100543-00 富士ジーワイ商事㈱ UOE取込対応</br>
    /// <br>Update Note: K2015/06/18 紀飛</br>
    /// <br>管理番号   : 11101427-00 ㈱メイゴ　WebUOE発注回答取込対応</br>
    /// <br>Update Note: K2016/11/01 譚洪</br>
    /// <br>管理番号   : 11202099-00 売上伝票入力から外部PGを起動して売単価を算出の対応</br>
    /// <br>             ㈱コーエイオプション（個別）</br>
    /// <br>Update Note: K2016/12/14  時シン</br>
    /// <br>管理番号   : 11202330-00</br>
    /// <br>           : 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応</br>
    /// <br>Update Note: K2016/12/26 譚洪</br>
    /// <br>管理番号   : 11270116-00 売上伝票入力パッケージ出荷用ソースのマージ</br>
    /// <br>             ㈱福田部品オプション（個別）</br>
    /// <br>Update Note: K2016/12/30 譚洪</br>
    /// <br>管理番号   : 11202452-00</br>
    /// <br>             水野商工様個別変更内容をPM.NSにて実現するため、第二売価の対応行います。</br>
    /// <br>Update Note: 2020/02/24 譚洪</br>
    /// <br>管理番号   : 11570208-00</br>
    /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
    /// <br>Update Note: 2020/11/20 陳艶丹</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// <br>Update Note: 2021/03/16 陳艶丹</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
    /// <br>Update Note: 2021/08/23 陳艶丹</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4178 税率のログ追加</br> 
    /// <br>Update Note: 2021/09/10 呉元嘯</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応</br> 
    /// <br>Update Note: 2021/10/09 田建委</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4192 伝票入力後の処理が遅い件の調査</br> 
    /// <br>Update Note: 2022/01/05 陳艶丹</br>
    /// <br>管理番号   : 11800082-00</br>
    /// <br>           : PMKOBETSU-4148 メーカー名と仕入先名チェック追加</br> 
    /// </remarks>
    public partial class SalesSlipInputInitDataAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private SalesSlipInputInitDataAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static SalesSlipInputInitDataAcs GetInstance()
        {
            if (_salesSlipInputInitDataAcs == null)
            {
                _salesSlipInputInitDataAcs = new SalesSlipInputInitDataAcs();
            }
            return _salesSlipInputInitDataAcs;
        }
        # endregion

        #region ■プライベート変数
        private static SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private int _employeeCodeMaxLength = 4;
        // --- ADD 2009/12/23 ---------->>>>>
        /// <summary>伝票備考桁数</summary>
        private Int32 _slipNoteCharCnt;

        /// <summary>伝票備考２桁数</summary>
        private Int32 _slipNote2CharCnt;

        /// <summary>伝票備考３桁数</summary>
        private Int32 _slipNote3CharCnt;
        // --- ADD 2009/12/23 ----------<<<<<
        private UserGuideAcs _userGuideAcs;
        private GoodsAcs _goodsAcs;
        private List<SalesProcMoney> _salesProcMoneyList = null;
        private List<StockProcMoney> _stockProcMoneyList = null;
        private List<RateProtyMng> _rateProtyMngList = null; // ADD 2010/03/01

        private AllDefSet _allDefSet = null;                   // 全体初期値設定マスタ
        private StockTtlSt _stockTtlSt = null;                 // 仕入在庫全体設定マスタ
        private AcptAnOdrTtlSt _acptAnOdrTtlSt = null;         // 受発注全体管理設定マスタ
        private SalesTtlSt _salesTtlSt = null;                 // 売上全体設定マスタ
        private EstimateDefSet _estimateDefSet = null;         // 見積初期値設定マスタ
        private TaxRateSet _taxRateSet = null;                 // 税率設定マスタ
        private List<SlipPrtSet> _slipPrtSetList = null;       // 伝票印刷設定マスタリスト
        private List<CustSlipMng> _custSlipMngList = null;     // 得意先マスタ（伝票管理）リスト
        private List<UOEGuideName> _uoeGuideNameList = null;   // ＵＯＥガイド名称マスタリスト
        private List<Warehouse> _warehouseList = null;         // 倉庫コードマスタリスト
        private List<SubSection> _subSectionList = null;       // 部門マスタリスト
        private List<Employee> _employeeList = null;           // 従業員マスタリスト
        private List<EmployeeDtl> _employeeDtlList = null;     // 従業員詳細マスタリスト
        private List<MakerUMnt> _makerUMntList = null;         // メーカーマスタリスト
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList = null; // ＢＬコードマスタリスト
        private List<UserGdBd> _userGdBdList = null;           // ユーザーガイドマスタリスト
        private CompanyInf _companyInf = null;                 // 自社情報
        private UOESetting _uoeSetting = null;                 // UOE自社マスタ
        private PosTerminalMg _posTerminalMg = null;
        // --- ADD 2009/10/19 ---------->>>>>
        private ArrayList _allCustRateGroupList = null;        // 得意先マスタ全件リスト
        private List<PriceSelectSet> _displayDivList = null;              // 表示区分リスト
        // --- ADD 2009/10/19 ----------<<<<<
        private List<NoteGuidBd> _noteGuidList = null;              // 備考ガイド全件リスト ADD 2009/12/23
        private double _taxRate = 0;
        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>
        private double _taxRateInput = 0;
        private int _consTaxLayMethod = -1;
        private int _taxRateDiv = 0;
        private double _taxRateMst = 0;
        private bool _rentSyncSupSlipFlag = false;
        private bool _slipSrcTaxFlg = false;
        // 貸出同時仕入伝票Flg
        private bool _rentSyncSupFlg = false;
        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<
        private IWin32Window _owner = null;
        //>>>2010/02/26
        private SCMTtlSt _scmTtlSt = null;                     // SCM全体設定マスタ
        private List<SCMDeliDateSt> _scmDeliDateStList = null; // SCM納期設定マスタリスト
        private List<TbsPartsCodeWork> _tbsPartsCodeList = null; // 提供ＢＬコードマスタリスト
        //private List<TbsPartsCdChgWork> _tbsPartsCdChgWorkList = null; // BLコード変換マスタリスト // 2010/06/26
        //<<<2010/02/26
        private StockMngTtlSt _stockMngTtlSt = null; // 在庫管理全体設定 // 2011/09/27

        /// <summary> 入力モード</summary>
        private int _inputMode;

        /// <summary>オプション情報</summary>
        private int _opt_CarMng;
        private int _opt_FreeSearch;
        private int _opt_PCC;
        private int _opt_RCLink;
        private int _opt_UOE;
        private int _opt_StockingPayment;
        private int _opt_SCM; // 2010/02/26
        private int _opt_QRMail; // 2010/06/26
        private int _opt_DateCtrl; // 2012/11/13 T.Miyamoto ADD
        private int _opt_NoBuTo; // K2014/01/22 譚洪 ADD
        // ---ADD 鄧潘ハン K2014/02/17--------------->>>>>
        private MethodInfo _myMethodNobuto; // 参照用方法コール
        private object _objNobuto;          // 参照用object
        // ---ADD 鄧潘ハン K2014/02/17---------------<<<<<
        private int _opt_FuJi;   // 富士ジーワイ商事㈱オプション（個別）// ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱
        private int _opt_MeiGo;   // ㈱メイゴオプション（個別）// ADD K2015/06/18 紀飛 ㈱メイゴ WebUOE発注回答取込
        private int _opt_Mizuno2ndSellPriceCtl;  // ADD K2016/12/30 譚洪 水野商工㈱
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        private int _opt_StockEntCtrl;  // 売仕入同時入力制御オプション    (OPT-CPM0050)
        private int _opt_StockDateCtrl; // 仕入日付フォーカス制御オプション(OPT-CPM0060)
        private int _opt_SalesCostCtrl; // 原価修正制御オプション          (OPT-CPM0070)
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        private int _opt_BLPPriWarehouse; // BLP参照倉庫追加オプション     (OPT-PM00230)
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        private int _opt_Cpm_FutabaSlipPrtCtl; // フタバ伝票印刷制御オプション（個別）：OPT-CPM0090
        private int _opt_Cpm_FutabaWarehAlloc; // フタバ倉庫引当てオプション  （個別）：OPT-CPM0100
        private int _opt_Cpm_FutabaUOECtl;     // フタバUOEオプション         （個別）：OPT-CPM0110
        private int _opt_Cpm_FutabaOutSlipCtl; // フタバ出力済伝票制御        （個別）：OPT-CPM0120

        private int _opt_BLPRefWarehouse;   // BLP参照倉庫追加オプション：OPT-PM00230
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
        private int _opt_MoriKawa;   // 森川部品オプション（個別）// ADD K2015/04/01 高騁 森川部品個別依頼
        private int _opt_YamagataCustom;   // 山形部品㈱ 売上伝票入力(価格・売価変更ロック)(個別)  //  ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応

        private int _opt_PermitForKoei;  // ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ

        private int _opt_FukudaCustom;  // ADD 譚洪 K2016/12/26 ㈱福田部品
        private int _opt_PM_EBooks;   // 電子帳簿連携オプション // ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応


        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        /// <summary>離島価格設定リスト</summary>
        private List<IsolIslandPrcWork> _isolIslandList;
        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        private int _opt_TSP;
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<

        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
        // 制御XMLファイル
        private const string ProcessControlSettingFile = "MAHNB01000U_ProcessControlSetting.xml";
        // 出力制御XML
        private ProcessControlSetting _processControlSetting;
        public ProcessControlSetting ProcessControlSetting
        {
            get
            {
                return this._processControlSetting;
            }
        }

        /// <summary>
        /// 出力フラグ
        /// </summary>
        public enum OutFlgType : int
        {
            /// <summary>出力しない</summary>
            noOutput = 0,
            /// <summary>出力する</summary>
            Output = 1,
        }
        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<

        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 --->>>>>
        private SupplierAcs _supplierAcs;
        private List<Supplier> _supplierList = null;
        private const string LOGWRITESUPPLIER = "１ 仕入先リストを取得";
        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 ---<<<<<
        #endregion

        #region ■デリゲート
        /// <summary>売上金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>仕入金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        // --- ADD 2010/03/01 ---------->>>>>
        /// <summary>掛率優先管理マスタキャッシュデリゲート</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);
        // --- ADD 2010/03/01 ----------<<<<<
        #endregion

        #region ■イベント
        /// <summary>売上金額処理区分設定キャッシュイベント</summary>
        public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
        /// <summary>仕入金額処理区分設定セットイベント</summary>
        public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;

        // --- ADD 2010/03/01 ---------->>>>>
        /// <summary>掛率優先管理マスタセットイベント</summary>
        public event CacheRateProtyMngListEventHandler CacheRateProtyMngList;
        // --- ADD 2010/03/01 ----------<<<<<
        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
        /// <br>Update Note: 2009/09/08 張凱 車輌管理機能対応</br>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
        public static int _Log_Check = 0; // 2012/12/19 T.Nishi ADD

        /// <summary>ユーザーガイド区分コード（返品理由）</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_RetGoodsReason = 91;
        /// <summary>ユーザーガイド区分コード（納品区分）</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_DeliveredGoodsDiv = 48;
        /// <summary>ユーザーガイド区分コード（販売区分）</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_SalesCode= 71;

        /// <summary>備考ガイド区分コード１</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_1 = 101;//伝票備考１
        /// <summary>備考ガイド区分コード２</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_2 = 102;//伝票備考２
        /// <summary>備考ガイド区分コード３</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_3 = 106;//伝票備考２

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>車輌備考ガイド区分コード</summary>
        public static readonly int ctDIVCODE_CarNoteGuideDivCd = 201;//車輌備考
        // --- ADD 2009/09/08 ----------<<<<<

        /// <summary>品番必須モード</summary>
        public static readonly int ctINPUTMODE_NecessaryGoodsNo = 1;
        /// <summary>品番任意モード</summary>
        // --- UPD 2009/10/19 ---------->>>>>
        //public static readonly int ctINPUTMODE_VoluntaryGoodsNo = 2;
        public static readonly int ctINPUTMODE_VoluntaryGoodsNo = 0;
        // --- UPD 2009/10/19 ----------<<<<<
        /// <summary>端数処理対象金額区分（売上金額）</summary>
        public const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        public const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        /// <summary>端数処理対象金額区分（原価単価）</summary>
        public const int ctFracProcMoneyDiv_SalesUnitCost = 2;
        /// <summary>端数処理対象金額区分（原価金額）</summary>
        public const int ctFracProcMoneyDiv_Cost = 0;

        /// <summary>拠点コード(全体)</summary>
        public const string ctSectionCode = "00";

        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
        /// <summary>ログ用</summary>
        private const string PGID_Log = "MAHNB01001U";
        /// <summary>メソッド名</summary>
        private const string MethodNm = "SearchBLGoodsInfo";
        // ログ出力部品
        OutLogCommon LogCommon;
        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<<
        // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加--->>>>
        private const string CtRateLogSetting = "MAHNB01001URateLog";//ADD 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
        private const string CtRnGetTaxRateStatus = "最新情報 税率取得 status:{0}";
        private const string CtRnGetTaxRateNull = "最新情報 税率取得Null";
        // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加---<<<<
        # endregion

        #region ■列挙体
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
        #endregion

        #region ■プロパティ
        /// <summary>入力モード</summary>
        public int InputMode
        {
            get { return this._inputMode; }
        }
        /// <summary>税率</summary>
        public double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>
        /// <summary>税率入力値</summary>
        public double TaxRateInput
        {
            get { return _taxRateInput; }
            set { _taxRateInput = value; }
        }

        /// <summary>消費税転嫁方式</summary>
        public int ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// <summary>消費税税率区分</summary>
        public int TaxRateDiv
        {
            get { return _taxRateDiv; }
            set { _taxRateDiv = value; }
        }

        /// <summary>税率マスタ値</summary>
        public double TaxRateMst
        {
            get { return _taxRateMst; }
            set { _taxRateMst = value; }
        }

        public bool RentSyncSupSlipFlag
        {
            set { this._rentSyncSupSlipFlag = value; }
            get { return this._rentSyncSupSlipFlag; }
        }

        public bool SlipSrcTaxFlg
        {
            set { this._slipSrcTaxFlg = value; }
            get { return this._slipSrcTaxFlg; }
        }

        /// <summary>貸出同時仕入伝票Flg</summary>
        public bool RentSyncSupFlg
        {
            set { this._rentSyncSupFlg = value; }
            get { return this._rentSyncSupFlg; }
        }
        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<

        /// <summary>伝票印刷設定マスタリスト</summary>
        public List<SlipPrtSet> SlipPrtSetList
        {
            get { return this._slipPrtSetList; }
        }
        /// <summary>得意先マスタ（伝票管理）リスト</summary>
        public List<CustSlipMng> CustSlipMngList
        {
            get { return this._custSlipMngList; }
        }

        /// <summary>従業員コードMAX桁数</summary>
        public int EmployeeCodeMaxLength
        {
            get { return this._employeeCodeMaxLength; }
            set { this._employeeCodeMaxLength = value; }
        }

        // --- ADD 2009/12/23 ---------->>>>>
        /// public propaty name  :  SlipNoteCharCnt
        /// <summary>伝票備考桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNoteCharCnt
        {
            get { return _slipNoteCharCnt; }
            set { _slipNoteCharCnt = value; }
        }

        /// public propaty name  :  SlipNote2CharCnt
        /// <summary>伝票備考２桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNote2CharCnt
        {
            get { return _slipNote2CharCnt; }
            set { _slipNote2CharCnt = value; }
        }

        /// public propaty name  :  SlipNote3CharCnt
        /// <summary>伝票備考３桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNote3CharCnt
        {
            get { return _slipNote3CharCnt; }
            set { _slipNote3CharCnt = value; }
        }
        // --- ADD 2009/12/23 ----------<<<<<

        /// <summary>オーナーフォーム</summary>
        public IWin32Window Owner
        {
            set { this._owner = value; }
            get { return this._owner; }
        }

        /// <summary>
        /// 車両管理オプション
        /// </summary>
        public int Opt_CarMng
        {
            get { return this._opt_CarMng; }
            set { this._opt_CarMng = value; }
        }

        /// <summary>
        /// 自由検索オプション
        /// </summary>
        public int Opt_FreeSearch
        {
            get { return this._opt_FreeSearch; }
            set { this._opt_FreeSearch = value; }
        }
        /// <summary>
        /// ＰＣＣオプション
        /// </summary>
        public int Opt_PCC
        {
            get { return this._opt_PCC; }
            set { this._opt_PCC = value; }
        }
        /// <summary>
        /// リサイクル連動オプション
        /// </summary>
        public int Opt_RCLink
        {
            get { return this._opt_RCLink; }
            set { this._opt_RCLink = value; }
        }
        /// <summary>
        /// ＵＯＥオプション
        /// </summary>
        public int Opt_UOE
        {
            get { return this._opt_UOE; }
            set { this._opt_UOE = value; }
        }
        /// <summary>
        /// 仕入支払管理オプション
        /// </summary>
        public int Opt_StockingPayment
        {
            get { return this._opt_StockingPayment; }
            set { this._opt_StockingPayment = value; }
        }
        //>>>2010/02/26
        /// <summary>
        /// SCMオプション
        /// </summary>
        public int Opt_SCM
        {
            get { return this._opt_SCM; }
            set { this._opt_SCM = value; }
        }
        //<<<2010/02/26

        //>>>2010/06/26
        /// <summary>
        /// QRMailオプション
        /// </summary>
        public int Opt_QRMail
        {
            get { return this._opt_QRMail; }
            set { this._opt_QRMail = value; }
        }
        //<<<2010/06/26

        // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
        // 売上日付制御オプション
        public int Opt_DateCtrl
        {
            get { return this._opt_DateCtrl; }
            set { this._opt_DateCtrl = value; }
        }
        // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        // 売仕入同時入力制御オプション(OPT-CPM0050)
        public int Opt_StockEntCtrl
        {
            get { return this._opt_StockEntCtrl; }
            set { this._opt_StockEntCtrl = value; }
        }
        // 仕入日付フォーカス制御オプション(OPT-CPM0060)
        public int Opt_StockDateCtrl
        {
            get { return this._opt_StockDateCtrl; }
            set { this._opt_StockDateCtrl = value; }
        }
        // 原価修正制御オプション(OPT-CPM0070)
        public int Opt_SalesCostCtrl
        {
            get { return this._opt_SalesCostCtrl; }
            set { this._opt_SalesCostCtrl = value; }
        }
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        // BLP参照在庫追オプション(OPT-PM00230)
        public int Opt_BLPPriWarehouse
        {
            get { return this._opt_BLPPriWarehouse; }
            set { this._opt_BLPPriWarehouse = value; }
        }
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        // フタバ伝票印刷制御オプション（個別）：OPT-CPM0090
        public int Opt_Cpm_FutabaSlipPrtCtl
        {
            get { return this._opt_Cpm_FutabaSlipPrtCtl; }
            set { this._opt_Cpm_FutabaSlipPrtCtl = value; }
        }
        // フタバ倉庫引当てオプション（個別）：OPT-CPM0100
        public int Opt_Cpm_FutabaWarehAlloc
        {
            get { return this._opt_Cpm_FutabaWarehAlloc; }
            set { this._opt_Cpm_FutabaWarehAlloc = value; }
        }
        // フタバUOEオプション（個別）：OPT-CPM0110
        public int Opt_Cpm_FutabaUOECtl
        {
            get { return this._opt_Cpm_FutabaUOECtl; }
            set { this._opt_Cpm_FutabaUOECtl = value; }
        }
        // フタバ出力済伝票制御オプション（個別）：OPT-CPM0120
        public int Opt_Cpm_FutabaOutSlipCtl
        {
            get { return this._opt_Cpm_FutabaOutSlipCtl; }
            set { this._opt_Cpm_FutabaOutSlipCtl = value; }
        }

        // --- ADD 譚洪 K2014/01/22 ---------->>>>>
        // 登戸個別専門用のキーにオプション（個別）：OPT-CPM0120
        public int Opt_NoBuTo
        {
            get { return this._opt_NoBuTo; }
            set { this._opt_NoBuTo = value; }
        }
        // --- ADD 譚洪 K2014/01/22 ----------<<<<<

        // ---ADD 鄧潘ハン K2014/02/17--------------->>>>>
        /// <summary>参照用方法コール</summary>
        public MethodInfo MyMethodNobuto
        {
            get { return this._myMethodNobuto; }
            set { this._myMethodNobuto = value; }
        }

        /// <summary>参照用object</summary>
        public object ObjNobuto
        {
            get { return this._objNobuto; }
            set { this._objNobuto = value; }
        }
        // ---ADD 鄧潘ハン K2014/02/17---------------<<<<<

        // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ---------->>>>>
        /// <summary>
        /// 富士ジーワイ商事㈱オプション（個別）
        /// </summary>
        public int Opt_ForFuJi
        {
            get { return this._opt_FuJi; }
            set { this._opt_FuJi = value; }
        }
        // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ----------<<<<<

       // --- ADD K2015/06/18 紀飛 ㈱メイゴ WebUOE発注回答取込 ---------->>>>>
        /// <summary>
        /// ㈱メイゴオプション（個別）
        /// </summary>
        public int Opt_ForMeiGo
        {
            get { return this._opt_MeiGo; }
            set { this._opt_MeiGo = value; }
        }
        // --- ADD K2015/06/18 紀飛 ㈱メイゴ WebUOE発注回答取込 ----------<<<<<

        // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
        /// <summary>
        /// 水野商工㈱オプション（個別）
        /// </summary>
        public int Opt_Mizuno2ndSellPriceCtl
        {
            get { return this._opt_Mizuno2ndSellPriceCtl; }
            set { this._opt_Mizuno2ndSellPriceCtl = value; }
        }
        // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

        /// <summary>
        /// BLP参照倉庫追加オプション
        /// </summary>
        public int Opt_BLPRefWarehouse
        {
            get { return this._opt_BLPRefWarehouse; }
            set { this._opt_BLPRefWarehouse = value; }
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2015/04/01 高騁 森川部品個別依頼 ---------->>>>>
        /// <summary>
        /// 森川部品オプション（個別）
        /// </summary>
        public int Opt_MoriKawa
        {
            get { return this._opt_MoriKawa; }
            set { this._opt_MoriKawa = value; }
        }
        // --- ADD K2015/04/01 高騁 森川部品個別依頼 ----------<<<<<

        // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ---------->>>>>
        /// <summary>
        /// 山形部品㈱ 売上伝票入力(価格・売価変更ロック)(個別)
        /// </summary>
        public int Opt_YamagataCustom
        {
            get { return this._opt_YamagataCustom; }
            set { this._opt_YamagataCustom = value; }
        }
        // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ----------<<<<<

        // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
        /// <summary>
        ///  ㈱コーエイオプション（個別）
        /// </summary>
        public int Opt_PermitForKoei
        {
            get { return this._opt_PermitForKoei; }
            set { this._opt_PermitForKoei = value; }
        }
        // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<


        // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- >>>>>
        /// <summary>
        ///  ㈱福田部品オプション（個別）
        /// </summary>
        public int Opt_FukudaCustom
        {
            get { return this._opt_FukudaCustom; }
            set { this._opt_FukudaCustom = value; }
        }
        // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- >>>>>

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        /// <summary>
        /// TSPオプション
        /// </summary>
        public int Opt_TSP
        {
            get { return this._opt_TSP; }
            set { this._opt_TSP = value; }
        }
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
        /// <summary>
        /// 電子帳簿連携オプション
        /// </summary>
        public int Opt_PM_EBooks
        {
            get { return this._opt_PM_EBooks; }
            set { this._opt_PM_EBooks = value; }
        }
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        /// <summary>離島価格設定リストを取得・設定します。</summary>
        public List<IsolIslandPrcWork> IsolIslandList
        {
            get 
            {
                if (this._isolIslandList == null || this._isolIslandList.Count == 0)
                {
                    if (this._goodsAcs != null)
                    {
                        this._isolIslandList = new List<IsolIslandPrcWork>();
                        if (this._goodsAcs.IsolIslandPrcWorkList != null && this._goodsAcs.IsolIslandPrcWorkList.Count != 0)
                        {
                            this._isolIslandList.AddRange(this._goodsAcs.IsolIslandPrcWorkList);
                        }
                    }
                }
                return _isolIslandList; 
            }
            set { _isolIslandList = value; }
        }
        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        #endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        /// <br>Update Note : 2010/03/01 李占川 PM.NS保守依頼５次改良対応</br>
        /// <br>             単価モジュールの掛率優先管理マスタキャッシュ処理を使用するように変更</br>
        public int ReadInitData(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList aList;

            #region ●商品アクセスクラス初期処理(キャッシュなし)
            LogWrite("１ 商品アクセスクラス初期処理");
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = ctIsLocalDBRead;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true; // 2010/04/28
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);
            #endregion

            //>>>2010/02/26
            #region ●提供ＢＬコードリスト
            this._tbsPartsCodeList = this._goodsAcs.OfrBLList;
            LogWrite("★★★★★提供ＢＬコードリスト件数：" + this._tbsPartsCodeList.Count.ToString());
            #endregion
            //<<<2010/02/26

            #region ●メーカーマスタ
            LogWrite("１ メーカーリストを取得");
            List<MakerUMnt> makerList;
            status = this._goodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            #endregion

            #region ●ＢＬコードリスト
            LogWrite("１ BLコードリストを取得");
            List<BLGoodsCdUMnt> blGoodsList;
            status = this._goodsAcs.GetAllBLGoodsCd(enterpriseCode, out blGoodsList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (blGoodsList != null) this._blGoodsCdUMntList = blGoodsList;
            }
            #endregion

            #region ●端末管理マスタ MAPOS09152A(キャッシュなし)
            LogWrite("１ 端末管理マスタを取得");
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            posTerminalMgAcs.Search(out this._posTerminalMg, enterpriseCode);
            #endregion

            #region ●部門情報取得 DCKHN09012A(キャッシュなし)
            LogWrite("１ 部門を取得");
            SubSectionAcs subSectionAcs = new SubSectionAcs();
            status = subSectionAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._subSectionList = new List<SubSection>((SubSection[])aList.ToArray(typeof(SubSection)));
            }
            #endregion

            // --- ADD 2009/10/19 ---------->>>>>
            #region ●得意先掛率ｸﾞﾙｰﾌﾟの全件取得 PMKHN09172A(キャッシュなし)
            LogWrite("得意先掛率ｸﾞﾙｰﾌﾟを取得");
            CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
            status = custRateGroupAcs.Search(out aList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._allCustRateGroupList = aList;
            }
            else
            {
                this._allCustRateGroupList = new ArrayList();
            }
            #endregion

            #region ●表示区分マスタ PMHNB09003A
            LogWrite("表示区分マスタを取得");
            PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
            status = priceSelectSetAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._displayDivList = new List<PriceSelectSet>((PriceSelectSet[])aList.ToArray(typeof(PriceSelectSet))); ;
            }
            else
            {
                this._displayDivList = new List<PriceSelectSet>();
            }
            #endregion
            // --- ADD 2009/10/19 ----------<<<<<

            // --- ADD 2009/12/23 ---------->>>>>
            #region ●備考ガイドマスタアクセスクラス SFTOK09402A
            LogWrite("備考ガイド全件を取得");
            NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
            noteGuidAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = noteGuidAcs.SearchBody(out aList, enterpriseCode);
            this._noteGuidList = new List<NoteGuidBd>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._noteGuidList = new List<NoteGuidBd>((NoteGuidBd[])aList.ToArray(typeof(NoteGuidBd)));
            }
            #endregion

            // --- ADD 2009/12/23 ----------<<<<<

            // --- ADD 2010/03/01 ---------->>>>>
            #region ●掛率優先管理マスタ DCKHN09102A
            LogWrite("掛率優先管理マスタを取得");
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();
            int retTotalCnt;
            bool nextDat;
            status = rateProtyMngAcs.Search(out aList, out retTotalCnt, out nextDat, enterpriseCode, string.Empty, out retMessage);
            this._rateProtyMngList = new List<RateProtyMng>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._rateProtyMngList = new List<RateProtyMng>((RateProtyMng[])aList.ToArray(typeof(RateProtyMng)));
            }
            this.CacheRateProtyMngListCall();
            #endregion
            // --- ADD 2010/03/01 ----------<<<<<

            return 0;
        }

        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2020/02/24 譚洪</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// <br>Update Note: 2021/08/23 陳艶丹</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : PMKOBETSU-4178 税率のログ追加</br> 
        /// <br>Update Note: 2021/10/09 田建委</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : PMKOBETSU-4192 伝票入力後の処理が遅い件の調査</br>
        /// </remarks>
        public int ReadInitDataSecond(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●倉庫情報取得 MAKHN09332A
            LogWrite("２ 倉庫情報を取得");
            WarehouseAcs warehouseAcs = new WarehouseAcs();
            warehouseAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = warehouseAcs.Search(out aList, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._warehouseList = new List<Warehouse>((Warehouse[])aList.ToArray(typeof(Warehouse)));
            }
            #endregion

            #region ●受発注管理全体設定マスタ DCKHN09232A
            LogWrite("２ 受発注管理全体設定を取得");
            AcptAnOdrTtlStAcs acptAnOdrTtlStAcs = new AcptAnOdrTtlStAcs();  // 受発注全体設定マスタ
            acptAnOdrTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = acptAnOdrTtlStAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheAcptAnOdrTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ●売上全体設定マスタ DCKHN09212A
            LogWrite("２ 売上全体設定を取得");
            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // 売上全体設定マスタ
            salesTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesTtlStAcs.SearchOnlySalesTtlInfo(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheSalesTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ●見積初期値設定マスタ DCMIT09012A
            LogWrite("２ 見積初期値設定を取得");
            EstimateDefSetAcs estimateDefSetAcs = new EstimateDefSetAcs();  // 見積初期値設定マスタ
            status = estimateDefSetAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheEstimateDefSet(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ●仕入在庫全体設定マスタ SFSIR09002A
            LogWrite("２ 仕入在庫全体設定を取得");
            StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();          // 仕入在庫全体設定マスタ
            status = stockTtlStAcs.SearchOnlyStockTtlInfo(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheStockTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion

            #region ●全体初期値設定マスタ SFCMN09082A
            LogWrite("２ 全体初期値設定を取得");
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = (ctIsLocalDBRead == true) ? AllDefSetAcs.SearchMode.Local : AllDefSetAcs.SearchMode.Remote;
            status = allDefSetAcs.Search(out aList, enterpriseCode, allDefSetSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, aList);
                if (this._allDefSet != null) this._inputMode = this._allDefSet.GoodsNoInpDiv;
            }
            #endregion

            #region ●自社情報設定マスタ SFUKN09002A
            LogWrite("２ 自社情報設定を取得");
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out this._companyInf, enterpriseCode);
            #endregion

            #region ●税率設定マスタ SFUKK09002A
            LogWrite("２ 消費税を取得");
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSetAcs.SearchMode taxRateSearchMode = (ctIsLocalDBRead == true) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            status = taxRateSetAcs.Search(out aList, enterpriseCode, taxRateSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._taxRateSet = (TaxRateSet)aList[0];
                // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>
                this._taxRateInput = 0;
                this._rentSyncSupFlg = false;
                this._rentSyncSupSlipFlag = false;
                // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<
                this._taxRate = this.GetTaxRate(DateTime.Today);
                // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加--->>>>
                if (_taxRateSet == null)
                {
                    // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
                    if (ProcessControlSetting.RateLogOutFlg == (int)OutFlgType.Output)
                    {
                    // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
                        try
                        {
                            // ログ出力
                            if (LogCommon == null)
                            {
                                LogCommon = new OutLogCommon();
                            }
                            //LogCommon.OutputClientLog(PGID_Log, CtRnGetTaxRateNull, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//DEL 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
                            LogCommon.OutputClientLog(CtRateLogSetting, CtRnGetTaxRateNull, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//ADD 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
                        }
                        catch
                        {
                            // 既存ロジックに影響無し
                        }
                    }//ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応
                }
                // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加---<<<<
            }
            // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加--->>>>
            else
            {
                // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
                if (ProcessControlSetting.RateLogOutFlg == (int)OutFlgType.Output)
                {
                // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
                    try
                    {
                        //メッセージ
                        string logMsg = string.Format(CtRnGetTaxRateStatus, status.ToString());

                        // ログ出力
                        if (LogCommon == null)
                        {
                            LogCommon = new OutLogCommon();
                        }
                        //LogCommon.OutputClientLog(PGID_Log, logMsg, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//DEL 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
                        LogCommon.OutputClientLog(CtRateLogSetting, logMsg, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//ADD 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査

                    }
                    catch
                    {
                        // 既存ロジックに影響無し
                    }
                }//ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応
            }
            // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加---<<<<
            #endregion

            #region ●伝票印刷設定マスタ SFURI09022A
            LogWrite("２ 伝票印刷設定マスタリストを取得");
            SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
            slipPrtSetAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = slipPrtSetAcs.SearchSlipPrtSet(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])aList.ToArray(typeof(SlipPrtSet)));
            }
            #endregion

            #region ●得意先マスタ（伝票管理） SFURI09022A
            LogWrite("２ 得意先マスタ（伝票管理）リストを取得");
            int count = 0;
            CustSlipMngAcs custSlipMngAcs = new CustSlipMngAcs();
            custSlipMngAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = custSlipMngAcs.SearchOnlyCustSlipMng(out count, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._custSlipMngList = new List<CustSlipMng>((CustSlipMng[])custSlipMngAcs.CustSlipMngList.ToArray(typeof(CustSlipMng)));
            }
            #endregion

            #region ●オプション情報
            LogWrite("２ オプション情報を取得");
            this.CacheOptionInfo();
            #endregion

            #region ●ＵＯＥガイド名称マスタ PMUOE09032A
            LogWrite("２ UOEガイド名称マスタリストを取得");
            UOEGuideName uOEGuideName = new UOEGuideName();
            uOEGuideName.EnterpriseCode = enterpriseCode;
            uOEGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            UOEGuideNameAcs uOEGuideNameAcs = new UOEGuideNameAcs();
            status = uOEGuideNameAcs.Search(out aList, uOEGuideName);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._uoeGuideNameList = new List<UOEGuideName>((UOEGuideName[])aList.ToArray(typeof(UOEGuideName)));
            }
            #endregion

            #region ●ＵＯＥ自社マスタ PMUOE09042A
            LogWrite("２ UOE自社マスタを取得");
            UOESettingAcs uoeSettingAcs = new UOESettingAcs();
            uoeSettingAcs.Read(out this._uoeSetting, enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            #endregion

            // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 --->>>>>
            #region ●仕入先リスト
            LogWrite(LOGWRITESUPPLIER);
            _supplierAcs = new SupplierAcs();
            ArrayList supplierList;
            status = this._supplierAcs.SearchAll(out supplierList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (supplierList != null)
                {
                    _supplierList = new List<Supplier>((Supplier[])supplierList.ToArray(typeof(Supplier)));
                }
            }
            #endregion
            // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 ---<<<<<

            return 0;
        }

        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataThird(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            ArrayList aList2;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●全従業員／従業員詳細情報を取得 SFTOK09382A
            LogWrite("３ 全従業員／従業員詳細情報を取得");
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employeeAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = employeeAcs.SearchOnlyEmployeeInfo(out aList, out aList2, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._employeeList = new List<Employee>((Employee[])aList.ToArray(typeof(Employee)));
                if (aList2 != null) this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])aList2.ToArray(typeof(EmployeeDtl)));
            }
            #endregion

            #region ●ユーザーガイドマスタ SFCMN09062A
            LogWrite("３ ユーザーガイドを取得");
            this._userGuideAcs = new UserGuideAcs();
            CacheUserGd(enterpriseCode, ctDIVCODE_UserGuideDivCd_RetGoodsReason);       // 返品理由
            CacheUserGd(enterpriseCode, ctDIVCODE_UserGuideDivCd_DeliveredGoodsDiv);    // 納品区分
            CacheUserGd(enterpriseCode, ctDIVCODE_UserGuideDivCd_SalesCode);            // 販売区分
            #endregion

            #region ●売上金額処理区分設定マスタ DCHMB09112A
            LogWrite("３ 売上金額処理区分設定を取得");
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            salesProcMoneyAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesProcMoneyAcs.Search(out aList, enterpriseCode);
            this._salesProcMoneyList = new List<SalesProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }
            this.CacheSalesProcMoneyListCall();
            #endregion

            #region ●仕入金額処理区分設定マスタ DCKON09102A
            LogWrite("３ 仕入金額処理区分設定を取得");
            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            status = stockProcMoneyAcs.Search(out aList, enterpriseCode);
            this._stockProcMoneyList = new List<StockProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])aList.ToArray(typeof(StockProcMoney)));
            }
            this.CacheStockProcMoneyListCall();
            #endregion

            //>>>2010/02/26
            #region ●SCM全体設定マスタ SFCMN09082A
            LogWrite("３ SCM全体設定マスタを取得");
            SCMTtlStAcs scmTtlStAcs = new SCMTtlStAcs();
            status = scmTtlStAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._scmTtlSt = this.GetScmTtlStFromList(sectionCode, aList);
            }
            #endregion

            #region ●SCM納期設定マスタ
            LogWrite("３ SCM納期設定マスタを取得");
            SCMDeliDateStAcs scmDeliDateStAcs = new SCMDeliDateStAcs();
            status = scmDeliDateStAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._scmDeliDateStList = new List<SCMDeliDateSt>((SCMDeliDateSt[])aList.ToArray(typeof(SCMDeliDateSt)));
                // 2012/08/28 ADD T.Yoshioka 2012/10月配信予定 SCM障害№10363 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                this._scmDeliDateStList.Sort(new SCMDeliDateStComparer());
                // 2012/08/28 ADD T.Yoshioka 2012/10月配信予定 SCM障害№10363 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            #endregion

            //>>>2010/06/26
            //#region ●BLコード変換マスタ
            //LogWrite("３ BLコード変換マスタを取得");
            //BLCodeChangeAcs blCodeChangeAcs = new BLCodeChangeAcs();
            //TbsPartsCdChgWork paraTbsPartsCdChgWork = new TbsPartsCdChgWork();
            //status = blCodeChangeAcs.Search(out this._tbsPartsCdChgWorkList, paraTbsPartsCdChgWork);
            //#endregion
            //<<<2010/06/26
            //<<<2010/02/26

            //>>>2011/09/27
            #region ●在庫管理全体設定マスタ
            LogWrite("３ 在庫管理全体設定を取得");
            StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
            status = stockMngTtlStAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this.CacheStockMngTtlSt(aList, enterpriseCode, sectionCode);
            }
            #endregion
            //<<<2011/09/27

            return 0;  
        }

        /// <summary>
        /// 処理区分マスタリスト設定処理
        /// </summary>
        public void SettingProcMoney()
        {
            this._goodsAcs.SalesProcMoneyList = this._salesProcMoneyList;
            this._goodsAcs.SalesProcMoneyList = this._salesProcMoneyList;
        }
        # endregion

        # region ■従業員マスタ制御処理
        /// <summary>
        /// 従業員名称取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名称</returns>
        public string GetName_FromEmployee(string employeeCode)
        {
            Employee employee = this.GetEmployee(employeeCode);

            return (employee == null) ? string.Empty : employee.Name;
        }

        /// <summary>
        /// 従業員情報取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員マスタオブジェクト</returns>
        public Employee GetEmployee(string employeeCode)
        {
            Employee employee = this._employeeList.Find(
                delegate(Employee emp)
                {
                    return (emp.EmployeeCode.Trim() == employeeCode.Trim()) ? true : false;
                }
            );

            return (employee == null) ? null : employee;
        }

        /// <summary>
        /// 従業員所属情報取得
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="belongSectionCode">所属拠点コード</param>
        /// <param name="belongSubSectionCode">所属部門コード</param>
        public void GetBelongInfo_FromEmployee(string employeeCode, out string belongSectionCode, out int belongSubSectionCode)
        {
            belongSectionCode = string.Empty;
            belongSubSectionCode = 0;
            Employee employee = this.GetEmployee(employeeCode.PadLeft(_employeeCodeMaxLength, '0'));
            EmployeeDtl employeeDtl = this.GetEmployeeDtl(employeeCode.PadLeft(_employeeCodeMaxLength, '0'));
            if (employee != null) belongSectionCode = employee.BelongSectionCode;
            if (employeeDtl != null) belongSubSectionCode = employeeDtl.BelongSubSectionCode;
        }
        # endregion

        #region ■従業員詳細マスタ制御処理
        /// <summary>
        /// 従業員詳細情報取得処理
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public EmployeeDtl GetEmployeeDtl(string employeeCode)
        {
            EmployeeDtl employeeDtl = this._employeeDtlList.Find(
                delegate(EmployeeDtl empDtl)
                {
                    return (empDtl.EmployeeCode.Trim() == employeeCode.Trim()) ? true : false;
                }
            );
            return (employeeDtl == null) ? null : employeeDtl;
        }

        /// <summary>
        /// 所属部門、所属課取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="subSectionCode">部門コード</param>
        public void GetSubSection_FromEmployeeDtl(string employeeCode, out int subSectionCode)
        {
            EmployeeDtl employeeDtl = this.GetEmployeeDtl(employeeCode);
            subSectionCode = (employeeDtl == null) ? 0 : employeeDtl.BelongSubSectionCode;
        }
        #endregion

        # region ■倉庫マスタ制御処理
        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        public string GetName_FromWarehouse(string warehouseCode)
        {
            Warehouse warehouse = this._warehouseList.Find(
                delegate(Warehouse whouse)
                {
                    return (whouse.WarehouseCode.Trim() == warehouseCode.Trim()) ? true : false;
                }
            );
            return (warehouse == null) ? string.Empty : warehouse.WarehouseName;
        }

        //>>>2010/02/26
        /// <summary>
        /// 倉庫情報取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        public Warehouse GetInfo_FromWarehouse(string warehouseCode)
        {
            // --- UPD T.Nishi 2012/06/14 ---------->>>>>
            //Warehouse warehouse = this._warehouseList.Find(
            //    delegate(Warehouse whouse)
            //    {
            //        return (whouse.WarehouseCode.Trim() == warehouseCode.Trim()) ? true : false;
            //    }
            //);
            //return warehouse;
            Warehouse warehouse = null;

            if (this._warehouseList != null)
            {
                warehouse = this._warehouseList.Find(
                delegate(Warehouse whouse)
                {
                    return (whouse.WarehouseCode.Trim() == warehouseCode.Trim()) ? true : false;
                }
                );
            }
            return warehouse;
            // --- UPD T.Nishi 2012/06/14 ----------<<<<<
        }
        //<<<2010/02/26

        // ADD 2015/02/18 SCM高速化Redmine#243対応 ------------------------------------->>>>>
        /// <summary>
        ///  倉庫情報取得
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>倉庫情報</returns>
        public Warehouse GetInfo_FromWarehouse(string warehouseCode, string enterpriseCode)
        {
            Warehouse warehouse = null;
            // 倉庫リストが存在しない時はマスタより取得する
            if (this._warehouseList == null)
            {
                ArrayList aList;
                List<Warehouse> warehouseList = null;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                WarehouseAcs warehouseAcs = new WarehouseAcs();
                status = warehouseAcs.Search(out aList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (aList != null) warehouseList = new List<Warehouse>((Warehouse[])aList.ToArray(typeof(Warehouse)));
                    this.SetWarehouseList(warehouseList);
                }
            }

            if (this._warehouseList != null)
            {
                warehouse = this._warehouseList.Find(
                delegate(Warehouse whouse)
                {
                    return (whouse.WarehouseCode.Trim() == warehouseCode.Trim()) ? true : false;
                }
                );
            }
            return warehouse;

        }
        // ADD 2015/02/18 SCM高速化Redmine#243対応 -------------------------------------<<<<<

        # endregion

        # region ■部門マスタ制御処理
        /// <summary>
        /// 部門名称取得処理
        /// </summary>
        /// <param name="subSectionCode">部門コード</param>
        /// <returns>部門名称</returns>
        public string GetName_FromSubSection(int subSectionCode)
        {
            SubSection subSection = null;
            if (this._subSectionList != null)
            {
                subSection = this._subSectionList.Find(
                    delegate(SubSection sSection)
                    {
                        return (sSection.SubSectionCode == subSectionCode) ? true : false;
                    }
                );
            }
            return (subSection == null) ? string.Empty : subSection.SubSectionName;
        }
        # endregion

        # region ■受発注管理全体設定マスタ制御処理
        /// <summary>
        /// 受発注管理全体設定マスタキャッシュ
        /// </summary>
        /// <param name="acptAnOdrTtlStList">受発注管理全体設定マスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        internal void CacheAcptAnOdrTtlSt(ArrayList acptAnOdrTtlStList, string enterpriseCode, string sectionCode)
        {
            if (acptAnOdrTtlStList != null)
            {
                List<AcptAnOdrTtlSt> list = new List<AcptAnOdrTtlSt>((AcptAnOdrTtlSt[])acptAnOdrTtlStList.ToArray(typeof(AcptAnOdrTtlSt)));

                this._acptAnOdrTtlSt = list.Find(
                    delegate(AcptAnOdrTtlSt acptttl)
                    {
                        if ((acptttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (acptttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._acptAnOdrTtlSt != null) return;

                this._acptAnOdrTtlSt = list.Find(
                    delegate(AcptAnOdrTtlSt acptttl)
                    {
                        if ((acptttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (acptttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );


                //// 指定企業コード＆拠点コードで一致
                //foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in acptAnOdrTtlStList)
                //{
                //    if ((acptAnOdrTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                //        (acptAnOdrTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                //    {
                //        this._acptAnOdrTtlSt = acptAnOdrTtlSt;
                //        return;
                //    }
                //}
                //// 指定コードで一致しない場合、全体設定キャッシュ
                //foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in acptAnOdrTtlStList)
                //{
                //    if ((acptAnOdrTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                //        (acptAnOdrTtlSt.SectionCode.Trim() == ctSectionCode.Trim()))
                //    {
                //        this._acptAnOdrTtlSt = acptAnOdrTtlSt;
                //        return;
                //    }
                //}
            }
        }

        /// <summary>
        /// 受発注管理全体設定マスタオブジェクト取得処理
        /// </summary>
        /// <returns></returns>
        public AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
        {
            return this._acptAnOdrTtlSt;
        }
        # endregion

        # region ■売上全体設定マスタ制御処理
        /// <summary>
        /// 売上全体設定マスタキャッシュ
        /// </summary>
        /// <param name="salesTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheSalesTtlSt(ArrayList salesTtlStList, string enterpriseCode, string sectionCode)
        {
            if (salesTtlStList != null)
            {
                List<SalesTtlSt> list = new List<SalesTtlSt>((SalesTtlSt[])salesTtlStList.ToArray(typeof(SalesTtlSt)));

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._salesTtlSt != null) return;

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if ((salesttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }

        /// <summary>
        /// 売上全体設定マスタオブジェクト取得処理
        /// </summary>
        /// <returns></returns>
        public SalesTtlSt GetSalesTtlSt()
        {
            return this._salesTtlSt;
        }
        # endregion

        # region ■見積初期値設定マスタ制御処理
        /// <summary>
        /// 見積初期値設定マスタキャッシュ
        /// </summary>
        /// <param name="estimateDefSetList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheEstimateDefSet(ArrayList estimateDefSetList, string enterpriseCode, string sectionCode)
        {
            if (estimateDefSetList != null)
            {
                List<EstimateDefSet> list = new List<EstimateDefSet>((EstimateDefSet[])estimateDefSetList.ToArray(typeof(EstimateDefSet)));

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == sectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._estimateDefSet != null) return;

                this._estimateDefSet = list.Find(
                    delegate(EstimateDefSet estimatedef)
                    {
                        if ((estimatedef.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (estimatedef.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                //// 指定企業コード＆拠点コードで一致
                //foreach (EstimateDefSet estimateDefSet in estimateDefSetList)
                //{
                //    if ((estimateDefSet.EnterpriseCode.Trim() == enterpriseCode) &&
                //        (estimateDefSet.SectionCode.Trim() == sectionCode))
                //    {
                //        this._estimateDefSet = estimateDefSet;
                //        return;
                //    }
                //}
                //// 指定コードで一致しない場合、全体設定キャッシュ
                //foreach (EstimateDefSet estimateDefSet in estimateDefSetList)
                //{
                //    if ((estimateDefSet.EnterpriseCode.Trim() == enterpriseCode) &&
                //        (estimateDefSet.SectionCode.Trim() == ctSectionCode))
                //    {
                //        this._estimateDefSet = estimateDefSet;
                //        return;
                //    }
                //}
            }
        }

        /// <summary>
        /// 見積初期値設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public EstimateDefSet GetEstimateDefSet()
        {
            return this._estimateDefSet;
        }
        # endregion

        # region ■仕入在庫全体設定マスタ制御処理
        /// <summary>
        /// 仕入在庫全体設定マスタキャッシュ
        /// </summary>
        /// <param name="stockTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheStockTtlSt(ArrayList stockTtlStList, string enterpriseCode, string sectionCode)
        {
            if (stockTtlStList != null)
            {
                List<StockTtlSt> list = new List<StockTtlSt>((StockTtlSt[])stockTtlStList.ToArray(typeof(StockTtlSt)));

                this._stockTtlSt = list.Find(
                    delegate(StockTtlSt stockttl)
                    {
                        if ((stockttl.SectionCode.Trim() == sectionCode.Trim()) &&
                            (stockttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._stockTtlSt != null) return;

                this._stockTtlSt = list.Find(
                    delegate(StockTtlSt stockttl)
                    {
                        if ((stockttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (stockttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );


                //// 指定企業コード＆拠点コードで一致
                //foreach (StockTtlSt stockTtlSt in stockTtlStList)
                //{
                //    if ((stockTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                //        (stockTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                //    {
                //        this._stockTtlSt = stockTtlSt;
                //        return;
                //    }
                //}
                //// 指定コードで一致しない場合、全体設定キャッシュ
                //foreach (StockTtlSt stockTtlSt in stockTtlStList)
                //{
                //    if ((stockTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                //        (stockTtlSt.SectionCode.Trim() == ctSectionCode.Trim()))
                //    {
                //        this._stockTtlSt = stockTtlSt;
                //        return;
                //    }
                //}
            }
        }

        /// <summary>
        /// 仕入在庫全体設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public StockTtlSt GetStockTtlSt()
        {
            return this._stockTtlSt;
        }
        # endregion

        # region ■全体初期値設定マスタ制御処理
        /// <summary>
        /// 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            if (allDefSetArrayList == null) return null;

            List<AllDefSet> list = new List<AllDefSet>((AllDefSet[])allDefSetArrayList.ToArray(typeof(AllDefSet)));

            AllDefSet allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (allSecAllDefSet != null) return allSecAllDefSet;

            allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return allSecAllDefSet;




            //if (allDefSetArrayList == null) return null;

            //AllDefSet allSecAllDefSet = null;

            //foreach (AllDefSet allDefSet in allDefSetArrayList)
            //{
            //    if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
            //    {
            //        return allDefSet;
            //    }
            //    else if (allDefSet.SectionCode.Trim() == ctSectionCode.Trim())
            //    {
            //        allSecAllDefSet = allDefSet;
            //    }
            //}

            //return allSecAllDefSet;
        }

        /// <summary>
        /// 全体初期値設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }
        # endregion

        # region ■ユーザーガイドマスタ（ボディ）制御処理
        /// <summary>
        /// ユーザーガイドキャッシュ処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="userGuideDivCd">ユーザーガイド区分コード</param>
        private void CacheUserGd(string enterpriseCode, int userGuideDivCd)
        {
            ArrayList userGdBdList;
            List<UserGdBd> tmpList = new List<UserGdBd>();

            int status = this._userGuideAcs.SearchDivCodeBody(out userGdBdList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if ((this._userGdBdList != null) && (this._userGdBdList.Count != 0))
                {
                    this._userGdBdList.AddRange(new List<UserGdBd>((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd))));
                }
                else
                {
                    this._userGdBdList = new List<UserGdBd>((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));
                }
            }
        }

        // -------ADD 2010/06/02------->>>>>
        /// <summary>
        /// ユーザーガイドリストのクリア処理
        /// </summary>
        /// <returns></returns>
        public void ClearUserGd()
        {
            this._userGdBdList = new List<UserGdBd>();
        }
        // -------ADD 2010/06/02-------<<<<<

        /// <summary>
        /// ガイド名称取得処理
        /// </summary>
        /// <param name="userGuideDivCd">ユーザーガイド区分</param>
        /// <param name="guideCode">ガイドコード</param>
        /// <returns>ガイド名称</returns>
        public string GetName_FromUserGdBd(int userGuideDivCd, int guideCode)
        {
            UserGdBd userGuide = this._userGdBdList.Find(
                delegate(UserGdBd uGuide)
                {
                    if ((uGuide.UserGuideDivCd == userGuideDivCd) &&
                        (uGuide.GuideCode == guideCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (userGuide == null)
            {
                return string.Empty;
            }
            else
            {
                return userGuide.GuideName;
            }
        }

        /// <summary>
        /// ユーザーガイドコンボエディタリスト設定処理
        /// </summary>
        /// <param name="sender">対象コンボエディタ</param>
        /// <param name="userGuideDivCd">ユーザーガイド区分</param>
        public void SetUserGdBdComboEditor(ref TComboEditor sender, int userGuideDivCd)
        {
            Infragistics.Win.ValueList valueList;
            this.SetUserGdBdComboEditor(out valueList, userGuideDivCd);

            if (valueList != null)
            {
                for (int i = 0; i < valueList.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;                    
                    sender.Items.Add(vlltem);
                }

                if (valueList.ValueListItems.Count > 0)
                {
                    sender.MaxDropDownItems = valueList.ValueListItems.Count;
                }
            }
        }

        /// <summary>
        /// ユーザーガイドコンボエディタリスト設定処理
        /// </summary>
        /// <param name="sender">対象コンボボックスバリューリスト</param>
        /// <param name="userGuideDivCd">ユーザーガイド区分</param>
        public void SetUserGdBdComboEditor(out Infragistics.Win.ValueList sender, int userGuideDivCd)
        {

            sender = new Infragistics.Win.ValueList();

            List<UserGdBd> userGuideList = this._userGdBdList.FindAll(
                delegate(UserGdBd uGuide)
                {
                    if (uGuide.UserGuideDivCd == userGuideDivCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            int i = 0;
            foreach (UserGdBd userGuide in userGuideList)
            {
                Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
                secInfoItem.Tag = i;
                secInfoItem.DataValue = userGuide.GuideCode;
                secInfoItem.DisplayText = userGuide.GuideName;
                sender.ValueListItems.Add(secInfoItem);
                i++;
            }
#if false
            sender = new Infragistics.Win.ValueList();

            DataRow[] rows = this._dataSet.UserGdBd.Select(string.Format("UserGuideDivCd = {0}", userGuideDivCd), "GuideCode ASC");
            int i = 0;
            foreach (SalesInputInitialDataSet.UserGdBdRow row in rows)
            {
                Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
                secInfoItem.Tag = i;
                secInfoItem.DataValue = row.GuideCode;
                secInfoItem.DisplayText = row.GuideName;
                sender.ValueListItems.Add(secInfoItem);
                i++;
            }
#endif
        }

        /// <summary>
        /// ユーザーガイド コード最小値取得処理
        /// </summary>
        /// <param name="userGuideDivCd">ユーザーガイド区分</param>
        /// <returns>最小コード</returns>
        public int GetMinCode_FormUserCd(int userGuideDivCd)
        {
            if ((this._userGdBdList == null) || (this._userGdBdList.Count == 0)) return 0;

            List<UserGdBd> userGuideList = this._userGdBdList.FindAll(
                delegate(UserGdBd uGuide)
                {
                    if (uGuide.UserGuideDivCd == userGuideDivCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if ((userGuideList != null) && (userGuideList.Count != 0))
            {
                userGuideList.Sort(new UserGdBdComparer());
                return userGuideList[0].GuideCode;
            }
            else
            {
                return 0;
            }

#if false
            DataRow[] rows = this._dataSet.UserGdBd.Select(string.Format("UserGuideDivCd = {0}", userGuideDivCd), "GuideCode ASC");
            if ((rows == null) || (rows.Length == 0))
            {
                return 0;
            }
            else
            {
                SalesInputInitialDataSet.UserGdBdRow[] dataRows = (SalesInputInitialDataSet.UserGdBdRow[])rows;

                return dataRows[0].GuideCode;
            }
#endif
        }

        /// <summary>
        /// ユーザーガイドマスタ比較クラス(ガイドコード(昇順))
        /// </summary>
        private class UserGdBdComparer : Comparer<UserGdBd>
        {
            public override int Compare(UserGdBd x, UserGdBd y)
            {
                int result = x.GuideCode.CompareTo(y.GuideCode);
                return result;
            }
        }

        # endregion

        # region ■メーカーマスタ制御処理
        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        public string GetName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerName;
        }

        /// <summary>
        /// メーカー名称取得処理(半角カナ名称)
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        public string GetKanaName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerKanaName;
        }
        # endregion

        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 --->>>>>
        # region ■仕入先マスタ制御処理
        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>仕入先名称</returns>
        public string GetName_FromSupplier(int supplierCode)
        {
            Supplier supplierInfo = this._supplierList.Find(
                delegate(Supplier supplier)
                {
                    return (supplier.SupplierCd == supplierCode) ? true : false;
                }
            );
            return (supplierInfo == null) ? string.Empty : supplierInfo.SupplierSnm;
        }
        #endregion
        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 ---<<<<<

        // --- ADD 2009/12/23 ---------->>>>>
        # region ■指定備考情報制御処理
        /// <summary>
        /// 備考ガイド名称取得処理
        /// </summary>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <param name="noteGuideCode">備考ガイドコード</param>
        /// <param name="noteGuideName">備考ガイド名称</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド名称取得処理します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/12/23</br>
        /// </remarks>
        public int GetName_NoteGuidBd(int noteGuideDivCode, int noteGuideCode, out string noteGuideName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            noteGuideName = string.Empty;

            NoteGuidBd noteGuidBd = this._noteGuidList.Find(
                delegate(NoteGuidBd noteGuid)
                {
                    return (noteGuid.NoteGuideDivCode == noteGuideDivCode && noteGuid.NoteGuideCode == noteGuideCode) ? true : false;
                }
            );

            if (noteGuidBd != null)
            {
                noteGuideName = noteGuidBd.NoteGuideName;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        # endregion

        // --- ADD 2009/12/23 ----------<<<<<

        # region ■BLコードマスタ制御処理
        /// <summary>
        /// BLコード情報取得処理
        /// </summary>
        /// <param name="blGoodsCode">BL商品コード</param>
        /// <returns></returns>
        public BLGoodsCdUMnt GetBLGoodsInfo_FromBLGoods(int blGoodsCode)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = this._blGoodsCdUMntList.Find(
                delegate(BLGoodsCdUMnt blGoods)
                {
                    return (blGoods.BLGoodsCode == blGoodsCode) ? true : false;
                }
            );
            return blGoodsCdUMnt;
        }

        /// <summary>
        /// BLコードマスタ情報設定処理
        /// </summary>
        /// <param name="bLGoodsCdUMntList"></param>
        public void SettingBLGoodsInfo(ref List<BLGoodsCdUMnt> bLGoodsCdUMntList)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            List<BLGoodsCdUMnt> retBLGoodsCdUMntList = new List<BLGoodsCdUMnt>();

            foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMntList)
            {
                blGoodsCdUMnt = this.GetBLGoodsInfo_FromBLGoods(bLGoodsCdUMnt.BLGoodsCode);
                if (blGoodsCdUMnt != null)
                {
                    bLGoodsCdUMnt.BLGoodsName = blGoodsCdUMnt.BLGoodsFullName;
                    bLGoodsCdUMnt.BLGoodsFullName = blGoodsCdUMnt.BLGoodsFullName;
                    bLGoodsCdUMnt.BLGoodsHalfName = blGoodsCdUMnt.BLGoodsHalfName;
                }
                retBLGoodsCdUMntList.Add(bLGoodsCdUMnt);
            }
        }
        # endregion

        //>>>2010/02/26
        #region ■提供BLコードマスタ制御処理
        /// <summary>
        /// 提供BLコード情報取得処理
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <param name="blGoodsDerivedNo"></param>
        /// <returns></returns>
        public TbsPartsCodeWork GetOfrBLGoodsInfo_FromTbsPartsCodeWork(int blGoodsCode, int blGoodsDerivedNo)
        {
            TbsPartsCodeWork tbsPartsCodeWork = this._tbsPartsCodeList.Find(
                delegate(TbsPartsCodeWork work)
                {
                    if ((work.TbsPartsCode == blGoodsCode) &&
                        (work.TbsPartsCdDerivedNo == blGoodsDerivedNo))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            return tbsPartsCodeWork;
        }

        /// <summary>
        /// 提供BLコード情報取得処理
        /// </summary>
        /// <param name="blGoodsCode"></param>
        /// <returns></returns>
        public List<TbsPartsCodeWork> GetOfrBLGoodsInfo_FromTbsPartsCodeWork(int blGoodsCode)
        {
            List<TbsPartsCodeWork> tbsPartsCodeWorkList = this._tbsPartsCodeList.FindAll(
                delegate(TbsPartsCodeWork work)
                {
                    if (work.TbsPartsCode == blGoodsCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            return tbsPartsCodeWorkList;
        }
        #endregion
        //<<<2010/02/26

        # region ■ＵＯＥガイド名称マスタキャッシュ制御処理
        /// <summary>
        /// ＵＯＥガイド名称取得処理
        /// </summary>
        /// <param name="uOEGuideCode">ＵＯＥガイド区分</param>
        /// <param name="uOESupplierCd">ＵＯＥ発注先コード</param>
        /// <param name="uOEGuideDivCd">ＵＯＥガイドコード</param>
        public UOEGuideName GetUOEGuideNameRow_FromUOEGuideName(int uOEGuideDivCd, int uOESupplierCd, string uOEGuideCode)
        {
            if (this._uoeGuideNameList == null) return null;
            UOEGuideName uoeGuideName = this._uoeGuideNameList.Find(
                delegate(UOEGuideName uoeName)
                {
                    if ((uoeName.UOEGuideCode.Trim() == uOEGuideCode.Trim()) &&
                        (uoeName.UOESupplierCd == uOESupplierCd) &&
                        (uoeName.UOEGuideDivCd == uOEGuideDivCd))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return uoeGuideName;
        }

        /// <summary>
        /// ＵＯＥガイド名称取得処理
        /// </summary>
        /// <param name="uOEGuideCode">ＵＯＥガイド区分</param>
        /// <param name="uOESupplierCd">ＵＯＥ発注先コード</param>
        /// <param name="uOEGuideDivCd">ＵＯＥガイドコード</param>
        public string GetName_FromUOEGuideName(int uOEGuideDivCd, int uOESupplierCd, string uOEGuideCode)
        {
            UOEGuideName uoeGuideName = this.GetUOEGuideNameRow_FromUOEGuideName(uOEGuideDivCd, uOESupplierCd, uOEGuideCode);
            return (uoeGuideName == null) ? string.Empty : uoeGuideName.UOEGuideNm;
        }
        # endregion

        # region ■売上金額処理区分設定マスタ制御処理
        /// <summary>
        /// 売上金額処理区分設定キャッシュデリゲート コール処理
        /// </summary>
        public void CacheSalesProcMoneyListCall()
        {
            if (this.CacheSalesProcMoneyList != null) this.CacheSalesProcMoneyList(this._salesProcMoneyList);
        }
        # endregion

        # region ■仕入金額処理区分設定マスタ制御処理
        /// <summary>
        /// 仕入金額処理区分設定キャッシュデリゲート コール処理
        /// </summary>
        public void CacheStockProcMoneyListCall()
        {
            if (this.CacheStockProcMoneyList != null) this.CacheStockProcMoneyList(this._stockProcMoneyList);
        }
        # endregion

        // --- ADD 2010/03/01 ---------->>>>>
        # region ■掛率優先管理マスタ制御処理
        /// <summary>
        /// 掛率優先管理マスタキャッシュデリゲート コール処理
        /// </summary>
        public void CacheRateProtyMngListCall()
        {
            if (this.CacheRateProtyMngList != null) this.CacheRateProtyMngList(this._rateProtyMngList);
        }
        # endregion
        // --- ADD 2010/03/01 ----------<<<<<

        #region ■自社情報設定マスタ制御関連
        /// <summary>
        /// 自社情報設定マスタ取得処理
        /// </summary>
        /// <returns>自社情報設定マスタオブジェクト</returns>
        public CompanyInf GetCompanyInf()
        {
            return this._companyInf;
        }
        #endregion

        # region ■税率設定マスタ制御処理
        /// <summary>
        /// 転嫁方式取得処理(税率設定マスタ)
        /// </summary>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public Int32 GetConsTaxLayMethod(int taxRateCode)
        {
            return (_taxRateSet == null) ? 0 : _taxRateSet.ConsTaxLayMethod;
        }

        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }

        /// <summary>
        /// 税率取得処理
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2020/02/24 譚洪</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
        public double GetTaxRate(DateTime addUpADate)
        {
            if (_taxRateSet == null)
            {
                this._taxRate = 0;
                this._taxRateDiv = 0;// ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応
            }
            else
            {
                this._taxRate = 0;
                //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
                if (this.ConsTaxLayMethod != 0 || this._taxRateInput == 0)
                {
                //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<
                if ((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                    (addUpADate <= _taxRateSet.TaxRateEndDate))
                {
                    this._taxRate = _taxRateSet.TaxRate;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate2))
                {
                    this._taxRate = _taxRateSet.TaxRate2;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate3))
                {
                    this._taxRate = _taxRateSet.TaxRate3;
                }
                    //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
                    // 税率マスタの税率を利用
                    this._taxRateDiv = 0;
                    this._taxRateMst = this._taxRate;
                }
                else
                {
                    if(this._taxRateInput != 0 )
                    {
                        this._taxRate = this._taxRateInput;
                        // 消費税率設定新規画面の税率を利用
                        this._taxRateDiv = 1;
                    }
                    if ((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                        (addUpADate <= _taxRateSet.TaxRateEndDate))
                    {
                        this._taxRateMst = _taxRateSet.TaxRate;
                    }
                    else if ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                        (addUpADate <= _taxRateSet.TaxRateEndDate2))
                    {
                        this._taxRateMst = _taxRateSet.TaxRate2;
                    }
                    else if ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                             (addUpADate <= _taxRateSet.TaxRateEndDate3))
                    {
                        this._taxRateMst = _taxRateSet.TaxRate3;
                    }
                }
                //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<
            }
            return this._taxRate;
        }

        //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
        /// <summary>
        /// 税率設定マスタの税率取得処理
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note: 2020/02/24 譚洪</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
        public double GetTaxRateMst(DateTime addUpADate)
        {
            if (_taxRateSet == null)
            {
                this._taxRateMst = 0;
            }
            else
            {
                if ((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                        (addUpADate <= _taxRateSet.TaxRateEndDate))
                {
                    this._taxRateMst = _taxRateSet.TaxRate;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                        (addUpADate <= _taxRateSet.TaxRateEndDate2))
                {
                    this._taxRateMst = _taxRateSet.TaxRate2;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate3))
                {
                    this._taxRateMst = _taxRateSet.TaxRate3;
                }
            }
            return this._taxRateMst;
        }
        //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<

        /// <summary>
        /// 税率設定マスタに設定されている消費税名称を取得します。
        /// </summary>
        /// <returns>消費税表示名称</returns>
        public string GetTaxRateName()
        {
            string result = string.Empty;

            if (_taxRateSet == null) return result;

            return _taxRateSet.TaxRateName;
        }

        //>>>2010/08/30
        /// <summary>
        /// 税率設定範囲有効チェック
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        public bool ExistTaxRateRange(DateTime addUpADate)
        {
            bool ret = false;

            if (_taxRateSet == null)
            {
                ret = false;
            }
            else
            {
                if (((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                     (addUpADate <= _taxRateSet.TaxRateEndDate)) ||
                    ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                     (addUpADate <= _taxRateSet.TaxRateEndDate2)) ||
                    ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                     (addUpADate <= _taxRateSet.TaxRateEndDate3)))
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            return ret;
        }
        //<<<2010/08/30

        //>>>2010/11/26
        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="dt"></param>
        public void GetTaxRateSet(string enterpriseCode, DateTime dt)
        {
            #region ●税率設定マスタ SFUKK09002A
            ArrayList aList;
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSetAcs.SearchMode taxRateSearchMode = (ctIsLocalDBRead == true) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            int status = taxRateSetAcs.Search(out aList, enterpriseCode, taxRateSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._taxRateSet = (TaxRateSet)aList[0];
                this._taxRate = this.GetTaxRate(dt);
            }
            #endregion
        }
        //<<<2010/11/26
        # endregion

        //>>>2010/02/26
        # region ■SCM全体設定制御処理
        /// <summary>
        /// SCM全体設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        private SCMTtlSt GetScmTtlStFromList(string sectionCode, ArrayList scmTtlStArrayList)
        {
            if (scmTtlStArrayList == null) return null;

            List<SCMTtlSt> list = new List<SCMTtlSt>((SCMTtlSt[])scmTtlStArrayList.ToArray(typeof(SCMTtlSt)));

            SCMTtlSt scmTtlSt = list.Find(
                delegate(SCMTtlSt scmTtl)
                {
                    if (scmTtl.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (scmTtlSt != null) return scmTtlSt;

            scmTtlSt = list.Find(
                delegate(SCMTtlSt scmTtl)
                {
                    if (scmTtl.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return scmTtlSt;
        }

        /// <summary>
        /// SCM全体設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public SCMTtlSt GetScmTtlSt()
        {
            return this._scmTtlSt;
        }
        # endregion

        #region ■SCM納期設定マスタ
        /// <summary>
        /// SCM納期設定マスタ取得処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public SCMDeliDateSt GetSCMDeliDateSt(string sectionCode, int customerCode)
        {
            SCMDeliDateSt ret = null;
            if (this._scmDeliDateStList == null) return null;

            ret = this._scmDeliDateStList.Find(
                delegate(SCMDeliDateSt work)
                {
                    if ((work.CustomerCode == customerCode) && (work.SectionCode.Trim() == string.Empty))
                    {
                        return true;
                    }
                    else if ((work.CustomerCode == 0) && (work.SectionCode.Trim() == string.Empty))
                    {
                        return true;
                    }
                    else if ((work.CustomerCode == 0) && (work.SectionCode.Trim() == sectionCode.Trim()))
                    {
                        return true;
                    }
                    else if ((work.CustomerCode == 0) && (work.SectionCode.Trim() == "00"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return ret;
        }

        // 2011/01/31 Add >>>
        /// <summary>
        /// ＳＣＭ納期設定マスタ比較クラス(得意先、拠点(昇順))
        /// </summary>
        private class SCMDeliDateStComparer : Comparer<SCMDeliDateSt>
        {
            public override int Compare(SCMDeliDateSt x, SCMDeliDateSt y)
            {
                int result = y.CustomerCode.CompareTo(x.CustomerCode);
                if (result != 0) return result;

                result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2011/01/31 Add <<<
        # endregion

        //>>>2010/06/26
        //#region ■BLコード変換マスタ
        ///// <summary>
        ///// BLコード変換マスタのリスト中から、指定した条件で情報取得します。
        ///// </summary>
        ///// <param name="blCode"></param>
        ///// <returns></returns>
        //public List<TbsPartsCdChgWork> GetBLPartsCdChgList(int blCode)
        //{
        //    List<TbsPartsCdChgWork> retList = null;

        //    if (this._tbsPartsCdChgWorkList == null) return null;

        //    retList = this._tbsPartsCdChgWorkList.FindAll(
        //        delegate(TbsPartsCdChgWork work)
        //        {
        //            if (work.TbsPartsCode == blCode)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    );
        //    return retList;
        //}
        //# endregion
        //<<<2010/06/26

        //<<<2010/02/26

        //>>>2011/09/27
        # region ■在庫管理全体設定マスタ
        /// <summary>
        /// 在庫管理全体設定マスタキャッシュ
        /// </summary>
        /// <param name="salesTtlStList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheStockMngTtlSt(ArrayList stockMngTtlStList, string enterpriseCode, string sectionCode)
        {

            if (stockMngTtlStList != null)
            {
                List<StockMngTtlSt> list = new List<StockMngTtlSt>((StockMngTtlSt[])stockMngTtlStList.ToArray(typeof(StockMngTtlSt)));

                this._stockMngTtlSt = list.Find(
                    delegate(StockMngTtlSt stockmngttl)
                    {
                        if ((stockmngttl.SectionCode.Trim() == ctSectionCode.Trim()) &&
                            (stockmngttl.EnterpriseCode.Trim() == enterpriseCode.Trim()))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }
        
        /// <summary>
        /// 在庫管理全体設定マスタオブジェクト取得処理
        /// </summary>
        /// <returns></returns>
        public StockMngTtlSt GetStockMngTtlSt()
        {
            return this._stockMngTtlSt;
        }
        # endregion
        //<<<2011/09/27

        #region ■端末管理マスタ
        /// <summary>
        /// 端末管理マスタを取得します。
        /// </summary>
        /// <returns></returns>
        public PosTerminalMg GetPosTerminalMg()
        {
            return this._posTerminalMg;
        }
        #endregion

        #region ■UOE自社マスタ
        /// <summary>
        /// UOE自社マスタを取得します。
        /// </summary>
        /// <returns></returns>
        public UOESetting GetUOESetting()
        {
            if (this._uoeSetting == null) this._uoeSetting = new UOESetting();
            return this._uoeSetting;
        }
        #endregion

        // --- ADD 2009/10/19 ---------->>>>>
        #region ■得意先掛率グループコードマスタ
        /// <summary>
        /// 得意先掛率グループコードマスタの全件取得処理
        /// </summary>
        /// <returns></returns>
        public ArrayList GetGetCustRateGrpAll()
        {
            return this._allCustRateGroupList;
        }
        #endregion

        #region ■表示区分マスタ
        /// <summary>
        /// 表示区分マスタの取得処理
        /// </summary>
        /// <returns></returns>
        public List<PriceSelectSet> GetDisplayDivList()
        {
            return this._displayDivList;
        }
        #endregion

        // --- ADD 2009/10/19 ----------<<<<<

        #region ■売上金額処理区分設定マスタ データ取得処理関連
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
#if false
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// 
        public void GetFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //デフォルト
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            // 端数処理対象金額区分、端数処理コードが一致するデータを降順に取得
            DataRow[] dr = this._dataSet.SalesProcMoney.Select(string.Format("{0} = {1} AND {2} = {3}", this._dataSet.SalesProcMoney.FracProcMoneyDivColumn.ColumnName,
                                                                                                        fracProcMoneyDiv,
                                                                                                        this._dataSet.SalesProcMoney.FractionProcCodeColumn, fractionProcCode,
                                                                                                        fractionProcCode),
                                                               string.Format("{0} DESC", this._dataSet.SalesProcMoney.UpperLimitPriceColumn.ColumnName));

            foreach (SalesInputInitialDataSet.SalesProcMoneyRow stockProcMoneyRow in dr)
            {
                if (stockProcMoneyRow.UpperLimitPrice < targetPrice)
                {
                    break;
                }
                fractionProcUnit = stockProcMoneyRow.FractionProcUnit;
                fractionProcCd = stockProcMoneyRow.FractionProcCd;
            }
        }
#endif
        #endregion

        #region ■仕入金額処理区分設定マスタ データ取得処理関連
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        public void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<StockProcMoney> stockProcMoneyList = this._stockProcMoneyList.FindAll(
                delegate(StockProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            stockProcMoneyList.Sort(new StockProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            StockProcMoney stockProcMoney = stockProcMoneyList.Find(
                delegate(StockProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if (stockProcMoney != null)
            {
                fractionProcUnit = stockProcMoney.FractionProcUnit;
                fractionProcCd = stockProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 仕入金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
#if false
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// 
        public void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //デフォルト
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            // 端数処理対象金額区分、端数処理コードが一致するデータを降順に取得
            DataRow[] dr = this._dataSet.StockProcMoney.Select(string.Format("{0} = {1} AND {2} = {3}", this._dataSet.StockProcMoney.FracProcMoneyDivColumn.ColumnName,
                                                                                                        fracProcMoneyDiv,
                                                                                                        this._dataSet.StockProcMoney.FractionProcCodeColumn, fractionProcCode,
                                                                                                        fractionProcCode),
                                                               string.Format("{0} DESC", this._dataSet.StockProcMoney.UpperLimitPriceColumn.ColumnName));

            foreach (SalesInputInitialDataSet.StockProcMoneyRow stockProcMoneyRow in dr)
            {
                if (stockProcMoneyRow.UpperLimitPrice < targetPrice)
                {
                    break;
                }
                fractionProcUnit = stockProcMoneyRow.FractionProcUnit;
                fractionProcCd = stockProcMoneyRow.FractionProcCd;
            }
        }
#endif
        #endregion

        # region ■商品関連処理
        /// <summary>
        /// 指定した商品コードを元に商品情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsUnitData">商品情報オブジェクト（out）</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(string enterpriseCode, string loginSectionCode, int makerCode, string goodsCode, out GoodsUnitData goodsUnitData)
        {
            return this._goodsAcs.Read(enterpriseCode, loginSectionCode, makerCode, goodsCode, 1, 1, ConstantManagement.LogicalMode.GetData0, out goodsUnitData);
        }

        /// <summary>
        /// 指定日条件該当価格情報データオブジェクト取得処理
        /// </summary>
        /// <param name="targetDateTime">価格開始日</param>
        /// <param name="goodsPriceList">価格情報データオブジェクトリスト</param>
        /// <returns>価格情報データオブジェクト</returns>
        public GoodsPrice GetGoodsPrice(DateTime targetDateTime, List<GoodsPrice> goodsPriceList)
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDateTime, goodsPriceList);
        }

        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="cndtn">商品検索抽出条件クラス</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNo(GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            return this._goodsAcs.SearchPartsFromGoodsNo(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg);
        }

        /// <summary>
        /// BLコード検索
        /// </summary>
        /// <param name="cndtn">商品検索抽出条件クラス</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchPartsFromBLCode(GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            return this._goodsAcs.SearchPartsFromBLCode(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg);
        }

        /// <summary>
        /// 結合元検索
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="cndtnList">商品検索条件オブジェクトリスト</param>
        /// <param name="partsInfoDataSetList">部品検索データセット</param>
        /// <param name="goodsUnitDataListList">商品連結データオブジェクトリストリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 結合元情報を検索します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/10/19</br>
        /// <br></br>
        /// <br>Update Note: 2015/04/06 30757 佐々木 貴英</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>             仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// <br></br>
        /// </remarks>
        /// <returns>ConstantManagement.MethodResult</returns>
        public int SearchPartsForSrcParts(int mode, GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            //---DEL 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
            //GoodsAcs goodsAcs = new GoodsAcs();
            //---DEL 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>

            // 純正品の標準価格を取得する際、離島価格を反映した価格を取得する為、
            // デフォルトコンストラクタではなく、パラメータで計上拠点を指定する
            // コンストラクタでGoodsAcsインスタンスを生成するよう修正
            GoodsAcs goodsAcs = new GoodsAcs(cndtn.SectionCode);
            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
            // --- UPD 2013/02/13 Y.Wakita ---------->>>>>
            //goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
            goodsAcs.SearchInitial();
            // --- UPD 2013/02/13 Y.Wakita ----------<<<<<
            return goodsAcs.SearchPartsForSrcParts(mode, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// TBO検索
        /// </summary>
        /// <param name="cndtn">商品検索抽出条件クラス</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.MethodResult</returns>
        /// <br>Update Note : 2009/11/13 李占川</br>
        /// <br>              TBO検索ボタンからTBO検索を修正</br>
        public int SearchTBO(GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            //return this._goodsAcs.SearchTBO(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg); // DEL 2009/11/13
            return this._goodsAcs.SearchTBOForButton(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg); // ADD 2009/11/13
        }

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="isSettingSupplier"></param>
        /// <param name="sectionCode"></param>
        public void SettingGoodsUnitDataListFromVariousMst(ref List<GoodsUnitData> goodsUnitDataList, bool isSettingSupplier, string sectionCode)
        {
            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();
                retGoodsUnitData.SectionCode = sectionCode;
                this.SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData, isSettingSupplier);
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;
        }

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <param name="cndtn">商品検索条件クラス</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        public void SettingGoodsUnitDataListFromVariousMst(ref GoodsUnitData goodsUnitData, bool isSettingSupplier)
        {
            //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, (isSettingSupplier) ? 0 : 1);// DEL 2014/08/11 duzg For 検証／総合テスト障害No.5
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst2(ref goodsUnitData, (isSettingSupplier) ? 0 : 1);// Add 2014/08/11 duzg For 検証／総合テスト障害No.5
        }

        /// <summary>
        /// 指定条件該当在庫情報取得処理
        /// </summary>
        /// <param name="warehouseCode"></param>
        /// <param name="makerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="stockList"></param>
        /// <returns></returns>
        public Stock GetStockFromStockList(string warehouseCode, int makerCd, string goodsNo, List<Stock> stockList)
        {
            if (stockList == null) return null;
            return this._goodsAcs.GetStockFromStockList(warehouseCode, makerCd, goodsNo, stockList);
        }

        /// <summary>
        /// BLコードガイド起動
        /// </summary>
        /// <param name="bLGoodsCdUMntList"></param>
        /// <param name="searchCarInfo"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
        //public int ExecuteBLGoodsCd(out List<BLGoodsCdUMnt> bLGoodsCdUMntList, PMKEN01010E searchCarInfo, int customerCode)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        public int ExecuteBLGoodsCd( out List<BLGoodsCdUMnt> bLGoodsCdUMntList, PMKEN01010E searchCarInfo, int customerCode, GoodsAcs.BLGuideMode blGuideMode )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
            //return this._goodsAcs.ExecuteBLGoodsCd(out bLGoodsCdUMntList, searchCarInfo, customerCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
            return this._goodsAcs.ExecuteBLGoodsCd( out bLGoodsCdUMntList, searchCarInfo, _loginSectionCode, customerCode, blGuideMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        }

        // UPD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
        ///// <summary>
        ///// 品番検索(商品情報一括取得)
        ///// </summary>
        ///// <param name="goodsCndtnList">商品検索条件オブジェクトリスト</param>
        ///// <param name="goodsUnitDataListList">商品連結データオブジェクトリストリスト</param>
        ///// <param name="msg">メッセージ</param>
        //public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        //{
        //    return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
        //}
        /// <summary>
        /// 品番検索(商品情報一括取得)
        /// </summary>
        /// <param name="goodsCndtnList">商品検索条件オブジェクトリスト</param>
        /// <param name="goodsUnitDataListList">商品連結データオブジェクトリストリスト</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="msg">メッセージ</param>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList, out List<List<GoodsUnitData>> goodsUnitDataListList, out PartsInfoDataSet partsInfoDataSet, out String msg)
        {
            return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out partsInfoDataSet, out msg);
        }
        // UPD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<

        /// <summary>
        /// BLコードに連結するBLコードマスタ情報、BLグループコード情報、商品中分類情報、商品大分類情報を取得します。
        /// </summary>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="bLGoodsCdUMnt">BLコードマスタ</param>
        /// <param name="bLGroupU">グループコードマスタ</param>
        /// <param name="goodsGroupU">商品中分類マスタ</param>
        /// <param name="userGdBdU">商品大分類マスタ（ユーザーガイド）</param>
        /// <returns>True:取得成功</returns>
        public bool GetBLGoodsRelation(int bLGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt, out BLGroupU bLGroupU, out GoodsGroupU goodsGroupU, out UserGdBdU userGdBdU)
        {
            this._goodsAcs.GetBLGoodsRelation(bLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);

            return !((bLGoodsCdUMnt.BLGoodsCode == 0) && (string.IsNullOrEmpty(bLGoodsCdUMnt.BLGoodsName)));
        }

        /// <summary>
        /// 商品連結データリストリストより商品連結データリストを取得
        /// </summary>
        /// <param name="goodsUnitDataListList"></param>
        /// <param name="goodsUnitDataList"></param>
        public void GetGoodsUnitDataListFromListList(List<List<GoodsUnitData>> goodsUnitDataListList, out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            if (goodsUnitDataListList != null)
            {
                foreach (List<GoodsUnitData> tempGoodsUnitDataList in goodsUnitDataListList)
                {
                    if (tempGoodsUnitDataList.Count != 0) goodsUnitDataList.Add(tempGoodsUnitDataList[0]);
                }
            }
        }
        # endregion

        #region ■オプション情報制御処理
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●車両管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_CarMng = (int)Option.ON;
            }
            else
            {
                this._opt_CarMng = (int)Option.OFF;
            }
            #endregion

            #region ●自由検索オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FreeSearch = (int)Option.ON;
            }
            else
            {
                this._opt_FreeSearch = (int)Option.OFF;
            }
            #endregion

            #region ●ＰＣＣオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PCC = (int)Option.ON;
            }
            else
            {
                this._opt_PCC = (int)Option.OFF;
            }
            #endregion

            #region ●リサイクル連動オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_RCLink = (int)Option.ON;
            }
            else
            {
                this._opt_RCLink = (int)Option.OFF;
            }
            #endregion

            #region ●ＵＯＥオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_UOE = (int)Option.ON;
            }
            else
            {
                this._opt_UOE = (int)Option.OFF;
            }
            #endregion

            #region ●仕入支払管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockingPayment = (int)Option.ON;
            }
            else
            {
                this._opt_StockingPayment = (int)Option.OFF;
            }
            #endregion

            //>>>2010/02/26
            #region ●SCMオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_SCM = (int)Option.ON;
            }
            else
            {
                this._opt_SCM = (int)Option.OFF;
            }
            #endregion
            //<<<2010/02/26

            // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
            #region ●山形部品オプション
            // 売仕入同時入力制御オプション(OPT-CPM0050)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockEntControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockEntCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_StockEntCtrl = (int)Option.OFF;
            }
            // 仕入日付フォーカス制御オプション(OPT-CPM0060)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockDateControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockDateCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_StockDateCtrl = (int)Option.OFF;
            }
            // 原価修正制御オプション(OPT-CPM0070)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SalesCostControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_SalesCostCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_SalesCostCtrl = (int)Option.OFF;
            }
            #endregion
            // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
            #region ●㈱フタバオプション
            // フタバ伝票印刷制御オプション（個別）：OPT-CPM0090
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaSlipPrtCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaSlipPrtCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaSlipPrtCtl = (int)Option.OFF;
            }
            // フタバ倉庫引当てオプション（個別）：OPT-CPM0100
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaWarehAlloc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaWarehAlloc = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaWarehAlloc = (int)Option.OFF;
            }
            // フタバUOEオプション（個別）：OPT-CPM0110
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaUOECtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaUOECtl = (int)Option.OFF;
            }
            // フタバ出力済伝票制御オプション（個別）：OPT-CPM0120
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaOutSlipCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaOutSlipCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaOutSlipCtl = (int)Option.OFF;
            }
            #endregion

            #region ●BLP参照倉庫追加オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_BLPRefWarehouse = (int)Option.ON;
            }
            else
            {
                this._opt_BLPRefWarehouse = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

            // --- ADD 譚洪 K2014/01/22 ---------->>>>>
            #region ●登戸個別専門用のキーにオプション（個別）     
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_NobutoCustom);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // ---ADD 鄧潘ハン K2014/02/17--------------->>>>>
                // インスタンス生成
                this._objNobuto = this.LoadAssemblyNobuto("PMHNB09312AC", "Broadleaf.Application.Controller.NobutoSpecSalesAcs");
                this._myMethodNobuto = null;
                if (this._objNobuto != null)
                {
                    // メソッド取得
                    this._myMethodNobuto = this._objNobuto.GetType().GetMethod("ReadSpecSalesDetailUriAge", new Type[] { typeof(string), typeof(string), typeof(int) });
                }

                if (this._myMethodNobuto != null)
                {
                    this._opt_NoBuTo = (int)Option.ON;
                }
                else
                {
                    this._opt_NoBuTo = (int)Option.OFF;
                }
                // ---ADD 鄧潘ハン K2014/02/17---------------<<<<<

                //this._opt_NoBuTo = (int)Option.ON;// DEL 鄧潘ハン K2014/02/17
            }
            else
            {
                this._opt_NoBuTo = (int)Option.OFF;
            }
            #endregion
            // --- ADD 譚洪 K2014/01/22 ----------<<<<<
            // --- ADD K2015/04/01 高騁 森川部品個別依頼 ---------->>>>>
            #region ●森川部品オプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MorikawaCustom);
          
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_MoriKawa = (int)Option.ON;
            }
            else
            {
                this._opt_MoriKawa = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/04/01 高騁 森川部品個別依頼 ----------<<<<<

            // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
            #region ● ㈱コーエイオプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KoeiCallExtProgCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PermitForKoei = (int)Option.ON;
            }
            else
            {
                this._opt_PermitForKoei = (int)Option.OFF;
            }
            #endregion
            // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<


            // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- >>>>>
            #region ● ㈱福田部品オプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FukudaCustom);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FukudaCustom = (int)Option.ON;
            }
            else
            {
                this._opt_FukudaCustom = (int)Option.OFF;
            }
            #endregion
            // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- <<<<<

            // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ---------->>>>>
            #region ●富士ジーワイ商事㈱オプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FujiGYSubaruWebUoeCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuJi = (int)Option.ON;
            }
            else
            {
                this._opt_FuJi = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ----------<<<<<

           // --- ADD K2015/06/18 紀飛 ㈱メイゴ WebUOE発注回答取込 ---------->>>>>
            #region ●㈱メイゴオプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoWebUOECtrl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_MeiGo = (int)Option.ON;
            }
            else
            {
                this._opt_MeiGo = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/06/18 紀飛 ㈱メイゴ WebUOE発注回答取込 ----------<<<<<

            // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ---------->>>>>
            #region ●山形部品㈱ 売上伝票入力(価格・売価変更ロック)(個別)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_YamagataCustomControl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_YamagataCustom = (int)Option.ON;
            }
            else
            {
                this._opt_YamagataCustom = (int)Option.OFF;
            }
            #endregion
            // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ----------<<<<<

            // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
            #region ●水野商工㈱オプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_Mizuno2ndSellPriceCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Mizuno2ndSellPriceCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Mizuno2ndSellPriceCtl = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
            #region ●TSPオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_Tsp);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TSP = (int)Option.ON;
            }
            else
            {
                this._opt_TSP = (int)Option.OFF;
            }

            #endregion
            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<<
            // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
            #region ●電子帳簿連携オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PM_EBooks = (int)Option.ON;
            }
            else
            {
                this._opt_PM_EBooks = (int)Option.OFF;
            }
            #endregion
            // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
        }

        #endregion

        #region ■DEBUGログ出力
        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<

                System.IO.FileStream _fs;										// ファイルストリーム
                System.IO.StreamWriter _sw;										// ストリームwriter
                _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
                DateTime edt = DateTime.Now;
                //yyyy/MM/dd hh:mm:ss
                _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
            }
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
        }

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg"></param>
        public static void LogWrite(string className, string methodName, string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-70} {3}", edt, edt.Millisecond, className + "." + methodName, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
            }
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
        }

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg"></param>
        /// <param name="count"></param>
        public static void LogWrite(string className, string methodName, string pMsg, string count)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-70} {3} {4}", edt, edt.Millisecond, className + "." + methodName, pMsg, count));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
            }
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
        }

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg"></param>
        /// <param name="count1"></param>
        /// <param name="count2"></param>
        public static void LogWrite(string className, string methodName, string pMsg, string count1, string count2)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-70} {3} {4} {5}", edt, edt.Millisecond, className + "." + methodName, pMsg, count1, count2));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
            }
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
        }

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg"></param>
        /// <param name="count1"></param>
        /// <param name="count2"></param>
        /// <param name="count3"></param>
        public static void LogWrite(string className, string methodName, string pMsg, string count1, string count2, string count3)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (_Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    _Log_Check = 1;
                }
                else
                {
                    _Log_Check = 2;
                }

            }

            if (_Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-70} {3} {4} {5} {6}", edt, edt.Millisecond, className + "." + methodName, pMsg, count1, count2, count3));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
            }
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
        }
        #endregion

        // --- ADD 2010/04/01 ----------<<<<
        #region マスタチェック処理
        // マスタチェック処理
        public int ExistUserGuideDivCd_FormUserCd(int userGuideDivCd)
        {
            if ((this._userGdBdList == null) || (this._userGdBdList.Count == 0)) return 0;

            UserGdBd userGuide = this._userGdBdList.Find(
                delegate(UserGdBd uGuide)
                {
                    if (uGuide.UserGuideDivCd == userGuideDivCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (userGuide != null)
            {
                return userGuide.GuideCode;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region ReadInitData
        // メーカーマスタ
        public void GetMakerUMntList(out List<MakerUMnt> makerUMntList)
        {
            makerUMntList = this._makerUMntList;
        }
        // 提供ＢＬコードマスタ
        public void GettbsPartsCodeList(out List<TbsPartsCodeWork> tbsPartsCodeList)
        {
            tbsPartsCodeList = this._tbsPartsCodeList;
        }
        public void SetMakerUMntList(List<MakerUMnt> makerUMntList)
        {
            this._makerUMntList = makerUMntList;
        }
        // ＢＬコードリス
        public void GetBlGoodsCdUMntList(out List<BLGoodsCdUMnt> blGoodsCdUMntList)
        {
            blGoodsCdUMntList = this._blGoodsCdUMntList;
        }
        public void SetBlGoodsCdUMntList(List<BLGoodsCdUMnt> blGoodsCdUMntList)
        {
            this._blGoodsCdUMntList = blGoodsCdUMntList;
        }
        // 端末管理マスタ
        public void GetPosTerminalMg(out PosTerminalMg posTerminalMg)
        {
            posTerminalMg = this._posTerminalMg;
        }
        public void SetPosTerminalMg(PosTerminalMg posTerminalMg)
        {
            this._posTerminalMg = posTerminalMg;
        }
        // 部門情報取得
        public void GetSubSectionList(out List<SubSection> subSectionList)
        {
            subSectionList = this._subSectionList;
        }
        public void SetSubSectionList(List<SubSection> subSectionList)
        {
            this._subSectionList = subSectionList;
        }
        // 得意先掛率ｸﾞﾙｰﾌﾟの全件取得
        public void GetAllCustRateGroupList(out ArrayList allCustRateGroupList)
        {
            allCustRateGroupList = this._allCustRateGroupList;
        }
        public void SetAllCustRateGroupList(ArrayList allCustRateGroupList)
        {
            this._allCustRateGroupList = allCustRateGroupList;
        }
        //2013/05/09 T.Nishi
        public void SetTbsPartsCodeList(List<TbsPartsCodeWork> tbsPartsCodeList)
        {
            this._tbsPartsCodeList = tbsPartsCodeList;
        }
        //2013/05/09 T.Nishi
        // 表示区分マスタ
        public void GetDisplayDivList(out List<PriceSelectSet> displayDivList)
        {
            displayDivList = this._displayDivList;
        }
        public void SetDisplayDivList(List<PriceSelectSet> displayDivList)
        {
            this._displayDivList = displayDivList;
        }
        // 備考ガイドマスタ
        public void GetNoteGuidList(out List<NoteGuidBd> noteGuidList)
        {
            noteGuidList = this._noteGuidList;
        }
        public void SetNoteGuidList(List<NoteGuidBd> noteGuidList)
        {
            this._noteGuidList = noteGuidList;
        }
        // 掛率優先管理マスタ
        public void GetRateProtyMngList(out List<RateProtyMng> rateProtyMngList)
        {
            rateProtyMngList = this._rateProtyMngList;
        }
        public void SetRateProtyMngList(List<RateProtyMng> rateProtyMngList)
        {
            this._rateProtyMngList = rateProtyMngList;
        }
        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 --->>>>>
        // 仕入先マスタ
        public void GetSupplierList(out List<Supplier> supplierList)
        {
            supplierList = this._supplierList;
        }
        public void SetSupplierList(List<Supplier> supplierList)
        {
            this._supplierList = supplierList;
        }
        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 ---<<<<<
        #endregion

        #region ReadInitDataSecond
        // 倉庫情報取得
        public void GetWarehouseList(out List<Warehouse> warehouseList)
        {
            warehouseList = this._warehouseList;
        }
        public void SetWarehouseList(List<Warehouse> warehouseList)
        {
            this._warehouseList = warehouseList;
        }
        // 受発注管理全体設定マスタ
        public void GetAcptAnOdrTtlSt(out AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            acptAnOdrTtlSt = this._acptAnOdrTtlSt;
        }
        public void SetAcptAnOdrTtlSt(AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            this._acptAnOdrTtlSt = acptAnOdrTtlSt;
        }
        // 売上全体設定マスタ
        public void GetSalesTtlSt(out SalesTtlSt salesTtlSt)
        {
            salesTtlSt = this._salesTtlSt;
        }
        public void SetSalesTtlSt(SalesTtlSt salesTtlSt)
        {
            this._salesTtlSt = salesTtlSt;
        }
        // 見積初期値設定マスタ
        public void GetEstimateDefSet(out EstimateDefSet estimateDefSet)
        {
            estimateDefSet = this._estimateDefSet;
        }
        public void SetEstimateDefSet(EstimateDefSet estimateDefSet)
        {
            this._estimateDefSet = estimateDefSet;
        }
        // 仕入在庫全体設定マスタ
        public void GetStockTtlSt(out StockTtlSt stockTtlSt)
        {
            stockTtlSt = this._stockTtlSt;
        }
        public void SetStockTtlSt(StockTtlSt stockTtlSt)
        {
            this._stockTtlSt = stockTtlSt;
        }
        // 全体初期値設定マスタ
        public void GetAllDefSet(out AllDefSet allDefSet)
        {
            allDefSet = this._allDefSet;
        }
        public void SetAllDefSet(AllDefSet allDefSet)
        {
            this._allDefSet = allDefSet;
        }
        public void SetInputMode(int inputMode)
        {
            this._inputMode = inputMode;
        }
        // 自社情報設定マスタ
        public void GetCompanyInf(out CompanyInf companyInf)
        {
            companyInf = this._companyInf;
        }
        public void SetCompanyInf(CompanyInf companyInf)
        {
            this._companyInf = companyInf;
        }
        // 税率設定マスタ
        public void GetTaxRateSet(out TaxRateSet taxRateSet, out double taxRate)
        {
            taxRateSet = this._taxRateSet;
            taxRate = this._taxRate;
        }
        public void SetTaxRateSet(TaxRateSet taxRateSet, double taxRate)
        {
            this._taxRateSet = taxRateSet;
            this._taxRate = taxRate;
        }
        // 伝票印刷設定マスタ
        public void GetSlipPrtSetList(out List<SlipPrtSet> slipPrtSetList)
        {
            slipPrtSetList = this._slipPrtSetList;
        }
        public void SetSlipPrtSetList(List<SlipPrtSet> slipPrtSetList)
        {
            this._slipPrtSetList = slipPrtSetList;
        }
        // 得意先マスタ（伝票管理）
        public void GetCustSlipMngList(out List<CustSlipMng> custSlipMngList)
        {
            custSlipMngList = this._custSlipMngList;
        }
        public void SetCustSlipMngList(List<CustSlipMng> custSlipMngList)
        {
            this._custSlipMngList = custSlipMngList;
        }
        // オプション情報
        // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
        ////>>>2010/05/30
        ////public void GetOptInfo(out int opt_CarMng, out int opt_FreeSearch, out int opt_PCC, out int opt_RCLink, out int opt_UOE,
        ////    out int opt_StockingPayment)
        //public void GetOptInfo(out int opt_CarMng, out int opt_FreeSearch, out int opt_PCC, out int opt_RCLink, out int opt_UOE,
        //    out int opt_StockingPayment, out int opt_SCM, out int opt_QRMail)
        ////<<<2010/05/30
        // --- DEL 譚洪 K2014/01/22 ---------->>>>>
        //public void GetOptInfo(out int opt_CarMng, out int opt_FreeSearch, out int opt_PCC, out int opt_RCLink, out int opt_UOE,
        //    out int opt_StockingPayment, out int opt_SCM, out int opt_QRMail, out int opt_DateCtrl)
        // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
        // --- DEL 譚洪 K2014/01/22 ----------<<<<<
        // --- ADD 譚洪 K2014/01/22 ---------->>>>>
        public void GetOptInfo(out int opt_CarMng, out int opt_FreeSearch, out int opt_PCC, out int opt_RCLink, out int opt_UOE,
            out int opt_StockingPayment, out int opt_SCM, out int opt_QRMail, out int opt_DateCtrl, out int opt_NoBuTo)
        // --- ADD 譚洪 K2014/01/22 ----------<<<<<
        {
            // 車両管理オプション
            opt_CarMng = this._opt_CarMng;
            // 自由検索オプション
            opt_FreeSearch = this._opt_FreeSearch;
            // ＰＣＣオプション
            opt_PCC = this._opt_PCC;
            // リサイクル連動オプション
            opt_RCLink = this._opt_RCLink;
            // ＵＯＥオプション
            opt_UOE = this._opt_UOE;
            // 仕入支払管理オプション
            opt_StockingPayment = this._opt_StockingPayment;
            //>>>2010/05/30
            // SCM
            opt_SCM = this._opt_SCM;
            //<<<2010/05/30
            //>>>2010/06/26
            // QR
            opt_QRMail = this._opt_QRMail;
            //<<<2010/06/26
            // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
            // 売上日付制御オプション
            opt_DateCtrl = this._opt_DateCtrl;
            // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

            // --- ADD 譚洪 K2014/01/22 ---------->>>>>
            // 登戸個別専門用のキーにオプション
            opt_NoBuTo = this._opt_NoBuTo;
            // --- ADD 譚洪 K2014/01/22 ----------<<<<<
        }

        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        // 山形部品オプション情報
        public void GetYamagataOptInfo(out int opt_StockEntCtrl
                                     , out int opt_StockDateCtrl
                                     , out int opt_SalesCostCtrl
                                      )
        {
            opt_StockEntCtrl = this._opt_StockEntCtrl;
            opt_StockDateCtrl = this._opt_StockDateCtrl;
            opt_SalesCostCtrl = this._opt_SalesCostCtrl;
        }
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        // BLP参照倉庫追加オプション取得
        public void GetBLPPriWarehouseOptInfo(out int opt_BLPPriWarehouse)
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            #region ●BLP参照倉庫追加オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_BLPPriWarehouse = (int)Option.ON;
            }
            else
            {
                this._opt_BLPPriWarehouse = (int)Option.OFF;
            }
            #endregion
            opt_BLPPriWarehouse = this._opt_BLPPriWarehouse;
        }
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

        // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
        ////>>>2010/05/30
        ////public void SetOptInfo(int opt_CarMng, int opt_FreeSearch, int opt_PCC, int opt_RCLink, int opt_UOE,
        ////    int opt_StockingPayment)
        //public void SetOptInfo(int opt_CarMng, int opt_FreeSearch, int opt_PCC, int opt_RCLink, int opt_UOE,
        //    int opt_StockingPayment, int opt_SCM, int opt_QRMail)
        ////<<<2010/05/30
        // --- DEL 譚洪 K2014/01/22 ---------->>>>>
        //public void SetOptInfo(int opt_CarMng, int opt_FreeSearch, int opt_PCC, int opt_RCLink, int opt_UOE,
        //    int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl)
        // --- UPD T.Miyamoto 2012/11/13 ----------<<<<<
        // --- DEL 譚洪 K2014/01/22 ----------<<<<<
        // --- ADD 譚洪 K2014/01/22 ---------->>>>>
        public void SetOptInfo(int opt_CarMng, int opt_FreeSearch, int opt_PCC, int opt_RCLink, int opt_UOE,
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo)// DEL 鄧潘ハン K2014/02/17
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, MethodInfo myMethodNobuto, object objNobuto)// ADD 鄧潘ハン K2014/02/17　// DEL 高騁 K2015/04/01
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, MethodInfo myMethodNobuto, object objNobuto, int opt_MoriKawa)// ADD 高騁 K2015/04/01 // DEL K2015/04/29 黄興貴 富士ジーワイ商事㈱
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, MethodInfo myMethodNobuto, object objNobuto, int opt_MoriKawa)// ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱  // DEL  譚洪 2015/10/26 Redmine#47609
            int opt_PermitForKoei,   // ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ
            int opt_FukudaCustom,   // ADD 譚洪 K2016/12/26 ㈱福田部品
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, MethodInfo myMethodNobuto, object objNobuto, int opt_MoriKawa)// ADD  譚洪 2015/10/26 Redmine#47609  // DEL 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, MethodInfo myMethodNobuto, int opt_YamagataCustom, object objNobuto, int opt_MoriKawa) // ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応   // DEL K2016/12/30 譚洪 水野商工㈱
            // ---UPD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, int opt_Mizuno2ndSellPriceCtl, MethodInfo myMethodNobuto, int opt_YamagataCustom, object objNobuto, int opt_MoriKawa)  // ADD K2016/12/30 譚洪 水野商工㈱
            // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
            //int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, int opt_Mizuno2ndSellPriceCtl, MethodInfo myMethodNobuto, int opt_YamagataCustom, object objNobuto, int opt_MoriKawa, int opt_TSP)
            int opt_StockingPayment, int opt_SCM, int opt_QRMail, int opt_DateCtrl, int Opt_NoBuTo, int opt_FuJi, int opt_MeiGo, int opt_Mizuno2ndSellPriceCtl, MethodInfo myMethodNobuto, int opt_YamagataCustom, object objNobuto, int opt_MoriKawa, int opt_TSP, int opt_PM_EBooks)
            // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
            // ---UPD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        // --- ADD 譚洪 K2014/01/22 ----------<<<<<
        {
            // 車両管理オプション
            this._opt_CarMng = opt_CarMng;
            // 自由検索オプション
            this._opt_FreeSearch = opt_FreeSearch;
            // ＰＣＣオプション
            this._opt_PCC = opt_PCC;
            // リサイクル連動オプション
            this._opt_RCLink = opt_RCLink;
            // ＵＯＥオプション
            this._opt_UOE = opt_UOE;
            // 仕入支払管理オプション
            this._opt_StockingPayment = opt_StockingPayment;
            //>>>2010/05/30
            // SCM
            this._opt_SCM = opt_SCM;
            //<<<2010/05/30
            //>>>2010/06/26
            // QR
            this._opt_QRMail = opt_QRMail;
            //<<<2010/06/26
            // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
            // 売上日付制御オプション
            this._opt_DateCtrl = opt_DateCtrl;
            // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

            this._opt_NoBuTo = Opt_NoBuTo; // ADD 譚洪 K2014/01/22

            // ---ADD 鄧潘ハン K2014/02/17--------------->>>>>
            // 参照用方法コール
            this.MyMethodNobuto = myMethodNobuto;
            // 参照用object
            this.ObjNobuto = objNobuto;
            // ---ADD 鄧潘ハン K2014/02/17---------------<<<<<
            
            // --- ADD K2015/04/01 高騁 森川部品個別依頼 ---------->>>>>
            // 森川部品オプション（個別）
            this._opt_MoriKawa = opt_MoriKawa;
            // --- ADD K2015/04/01 高騁 森川部品個別依頼 ----------<<<<<

            // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
            //  ㈱コーエイオプション（個別）
            this._opt_PermitForKoei = opt_PermitForKoei;
            // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

            // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- >>>>>
            //  ㈱福田部品オプション（個別）
            this._opt_FukudaCustom = opt_FukudaCustom;
            // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- <<<<<

            // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ---------->>>>>
            // 富士ジーワイ商事㈱オプション（個別）
            this._opt_FuJi = opt_FuJi;
            // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ----------<<<<<

            // --- ADD K2015/06/18 紀飛 ㈱メイゴ WebUOE発注回答取込 ---------->>>>>
            // ㈱メイゴオプション（個別）
            this._opt_MeiGo = opt_MeiGo;
            // --- ADD K2015/06/18 紀飛 ㈱メイゴ WebUOE発注回答取込 ----------<<<<<

            // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ---------->>>>>
            // 山形部品㈱ 売上伝票入力(価格・売価変更ロック)(個別)
            this._opt_YamagataCustom = opt_YamagataCustom;
            // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ----------<<<<<

            // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
            // 水野商工㈱オプション（個別）
            this._opt_Mizuno2ndSellPriceCtl = opt_Mizuno2ndSellPriceCtl;
            // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<
            this._opt_TSP = opt_TSP;// ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応
            this._opt_PM_EBooks = opt_PM_EBooks;// ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応
        }

        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        public void SetYamagataOptInfo(int opt_StockEntCtrl
                                     , int opt_StockDateCtrl
                                     , int opt_SalesCostCtrl
                                      )
        {
            this._opt_StockEntCtrl = opt_StockEntCtrl;
            this._opt_StockDateCtrl = opt_StockDateCtrl;
            this._opt_SalesCostCtrl = opt_SalesCostCtrl;
        }
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        public void SetFutabaOptInfo(int opt_Cpm_FutabaSlipPrtCtl
                                    ,int opt_Cpm_FutabaWarehAlloc
                                    ,int opt_Cpm_FutabaUOECtl
                                    ,int opt_Cpm_FutabaOutSlipCtl
                                    )
        {
            this._opt_Cpm_FutabaSlipPrtCtl = opt_Cpm_FutabaSlipPrtCtl;
            this._opt_Cpm_FutabaWarehAlloc = opt_Cpm_FutabaWarehAlloc;
            this._opt_Cpm_FutabaUOECtl     = opt_Cpm_FutabaUOECtl;
            this._opt_Cpm_FutabaOutSlipCtl = opt_Cpm_FutabaOutSlipCtl;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

        // ＵＯＥガイド名称マスタ
        public void GetUoeGuideNameList(out List<UOEGuideName> uoeGuideNameList)
        {
            uoeGuideNameList = this._uoeGuideNameList;
        }
        public void SetUoeGuideNameList(List<UOEGuideName> uoeGuideNameList)
        {
            this._uoeGuideNameList = uoeGuideNameList;
        }
        // ＵＯＥ自社マスタ
        public void GetUoeSetting(out UOESetting uoeSetting)
        {
            uoeSetting = this._uoeSetting;
        }
        public void SetUoeSetting(UOESetting uoeSetting)
        {
            this._uoeSetting = uoeSetting;
        }
        #endregion

        #region ReadInitDataThird
        // 全従業員／従業員詳細情報
        public void GetEmployeeInfo(out List<Employee> employeeList, out List<EmployeeDtl> employeeDtlList)
        {
            employeeList = this._employeeList;
            employeeDtlList = this._employeeDtlList;
        }
        public void SetEmployeeInfo(List<Employee> employeeList, List<EmployeeDtl> employeeDtlList)
        {
            this._employeeList = employeeList;
            this._employeeDtlList = employeeDtlList;
        }
        // ユーザーガイドマスタ
        public void GetUserGdBdList(out List<UserGdBd> userGdBdList)
        {
            userGdBdList = this._userGdBdList;
        }
        public void SetUserGdBdList(List<UserGdBd> userGdBdList)
        {
            this._userGdBdList = userGdBdList;
        }
        // 売上金額処理区分設定マスタ
        public void GetSalesProcMoneyList(out List<SalesProcMoney> salesProcMoneyList)
        {
            salesProcMoneyList = this._salesProcMoneyList;
        }
        public void SetSalesProcMoneyList(List<SalesProcMoney> salesProcMoneyList)
        {
            this._salesProcMoneyList = salesProcMoneyList;
        }
        // 仕入金額処理区分設定マスタ
        public void GetStockProcMoneyList(out List<StockProcMoney> stockProcMoneyList)
        {
            stockProcMoneyList = this._stockProcMoneyList;
        }
        public void SetStockProcMoneyList(List<StockProcMoney> stockProcMoneyList)
        {
            this._stockProcMoneyList = stockProcMoneyList;
        }
        public void SetGoodsAcs(GoodsAcs goodsAcs)
        {
            this._goodsAcs = goodsAcs;
        }
        public void SetUserGuideAcs(UserGuideAcs userGuideAcs)
        {
            this._userGuideAcs = userGuideAcs;
        }
        #endregion
        // --- ADD 2010/04/01 ---------->>>>

        //>>>2010/05/30
        public void SetSCMTtlSt(SCMTtlSt scmTtlSt)
        {
            this._scmTtlSt = scmTtlSt;
        }
        public void SetSCMDeliDateStList(List<SCMDeliDateSt> scmDeliDateStList)
        {
            this._scmDeliDateStList = scmDeliDateStList;
            // 2011/01/31 Add >>>
            this._scmDeliDateStList.Sort(new SCMDeliDateStComparer());
            // 2011/01/31 Add <<<
        }
        // --- DEL 2010/06/26 ---------->>>>>
        //public void SetTbsPartsCdChgWorkList(List<TbsPartsCdChgWork> tbsPartsCdChgWorkList)
        //{
        //    this._tbsPartsCdChgWorkList = tbsPartsCdChgWorkList;
        //}
        // --- DEL 2010/06/26 ----------<<<<<
        //<<<2010/05/30

        //>>>2010/07/29
        public void SetSCMTtlSt(List<PriceSelectSet> displayDivList)
        {
            this._displayDivList = displayDivList;
        }
        //<<<2010/07/29

        //>>>2011/09/27
        // 在庫管理全体設定マスタ
        public void GetStockMngTtlSt(out StockMngTtlSt stockMngTtlSt)
        {
            stockMngTtlSt = this._stockMngTtlSt;
        }
        public void SetStockMngTtlSt(StockMngTtlSt stockMngTtlSt)
        {
            this._stockMngTtlSt = stockMngTtlSt;
        }
        //<<<2011/09/27

        // --- ADD 鄧潘ハン K2014/02/17 -------------------->>>>>
        #region 登戸個別対応
        /// <summary>
        /// アセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : K2014/02/17</br>
        /// </remarks>
        public object LoadAssemblyNobuto(string asmname, string classname)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return obj;
        }
        #endregion
        // --- ADD 鄧潘ハン K2014/02/17 --------------------<<<<<

        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>>
        /// <summary>
        /// 初期値データ取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 初期値データを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/16</br>
        /// </remarks>
        public void SearchBLGoodsInfo(string enterpriseCode)
        {
            string retMessage = string.Empty;
            // ログ出力部品
            if (LogCommon == null)
            {
                LogCommon = new OutLogCommon();
            }
            try
            {
                
                // 初期値データ取得
                this._goodsAcs.SearchInitial(enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out retMessage);
                // メッセージあるの場合、ログ出力
                if (!string.IsNullOrEmpty(retMessage))
                {
                    LogCommon.OutputClientLog(PGID_Log, retMessage, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
                }
            }
            catch (Exception ex)
            {
                // ログ出力
                LogCommon.OutputClientLog(PGID_Log, MethodNm, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            }
        }
        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<<

        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
        /// <summary>
        /// 出力制御XMLファイル取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : 出力制御XMLファイル取得処理を行う</br>
        /// <br>Programmer   : 呉元嘯</br>
        /// <br>Date         : 2021/09/10</br>
        /// </remarks>
        public void GetControlXmlInfo()
        {
            try
            {
                _processControlSetting = new ProcessControlSetting();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ProcessControlSettingFile)))
                {
                    // XML情報を取得する
                    _processControlSetting = UserSettingController.DeserializeUserSetting<ProcessControlSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ProcessControlSettingFile));

                }
                else
                {
                    _processControlSetting.RateLogOutFlg = (int)OutFlgType.noOutput;
                    _processControlSetting.SaveAddUpDateCheckFlg = (int)OutFlgType.noOutput;
                }
            }
            catch
            {
                if (_processControlSetting == null) _processControlSetting = new ProcessControlSetting();
                _processControlSetting.RateLogOutFlg = (int)OutFlgType.noOutput;
                _processControlSetting.SaveAddUpDateCheckFlg = (int)OutFlgType.noOutput;
            }
        }
        // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<

    }

    // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
    # region
    /// <summary>
    /// 出力制御設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出力制御設定クラス</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2021/09/10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ProcessControlSetting
    {
        // 税率ログ出力区分
        private int _rateLogOutFlg;
        // 計上日チェック区分
        private int _saveAddUpDateCheckFlg;

        /// <summary>
        /// 税率ログ制御設定クラス
        /// </summary>
        public ProcessControlSetting()
        {

        }

        /// <summary>税率ログ出力区分</summary>
        public Int32 RateLogOutFlg
        {
            get { return this._rateLogOutFlg; }
            set { this._rateLogOutFlg = value; }
        }

        /// <summary>計上日チェック区分</summary>
        public Int32 SaveAddUpDateCheckFlg
        {
            get { return this._saveAddUpDateCheckFlg; }
            set { this._saveAddUpDateCheckFlg = value; }
        }
    }
    # endregion
    // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
}
