//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動入力の制御全般を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20008 伊藤 豊
// 作 成 日  2007/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 修 正 日  2007/09/05  修正内容 : 流通.NS用に変更
//                       対象のTableを含め大幅な変更がある為,変更箇所のコメントは残さない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 作 成 日  2008/07/14  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2009/06/04  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 修 正 日  2009.07.07  修正内容 : MANTIS[0013663]の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2010/02/19  修正内容 : MANTIS[0015007]の対応：入荷処理用に出荷時間を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2010/04/15  修正内容 : MANTIS対応[0015286] 品名カナ印字対応
//                                 (StockMoveInputDataSet.xsdにGoodsNameKanaを追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2010/06/09  修正内容 : MANTIS[0015261]の対応：再入荷処理すると、在庫移動伝票が検索されなくなる
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2010/06/15  修正内容 : MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/11/15  修正内容 : 障害改良対応「２」の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2010/11/19  修正内容 : 商品自動登録の価格開始日を前回月次更新日＋１に変更
//                               : （※参照設定に追加：DCCMN00003C.dll、SFUKN09001E.dll）
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 鄧潘ハン
// 修 正 日  2011/04/11  修正内容 : 障害改良対応(4月)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2011/05/10  修正内容 : Redmine #21101
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 譚洪
// 修 正 日  2011/07/25  修正内容 : 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/05/22  修正内容 : 06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸 伸悟
// 修 正 日  2012/07/05  修正内容 : 移動時在庫自動登録区分による制御を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日 K2013/09/11  修正内容 : フタバ個別対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 修 正 日 K2013/10/10  修正内容 : Redmine#40626 フタバテキスト変換抽出済判断処理を動的に呼出す様に修正
//----------------------------------------------------------------------------//
// 管理番号  10970522-00  作成担当 : 鄧潘ハン
// 作 成 日  K2013/12/25  修正内容 : フタバ個別拠点間発注ﾃﾞｰﾀより、入庫ﾃﾞｰﾀの作成することの対応
//----------------------------------------------------------------------------//
// 管理番号  10970522-00  作成担当 : wangl2
// 作 成 日  K2014/01/20  修正内容 : Redmine#41497 フタバ個別対応
//----------------------------------------------------------------------------//
// 管理番号  11070149-00  作成担当 : 劉超
// 作 成 日  K2014/11/20  修正内容 : Redmine#44000 フタバ　在庫移動入力入荷確定処理のエラーの対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

using Broadleaf.Application.UIData;
//using Broadleaf.Windows.Forms;

using Broadleaf.Xml.Serialization;  // m.suzuki
using Broadleaf.Application.Resources;  // --- ADD m.suzuki 2010/11/19

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 移動在庫入力アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫移動入力の制御全般を行います。</br>
    /// <br>Programmer : 20008 伊藤 豊</br>
    /// <br>Date       : 2007.01.26</br>
    /// <br>UpDate     : 2007.01.26 伊藤 豊 新規作成</br>
    /// <br>UpDate     : 2007.09.05 鈴木 正臣 流通.NS用に変更</br>
    /// <br>           : 対象のTableを含め大幅な変更がある為,変更箇所のコメントは残さない</br>
    /// <br>UpDate     : 2008/07/14 忍 幸史 Partsman用に変更</br>
    /// <br>           : 2009/06/04 照田 貴志　移動データ拠点管理対応</br>
    /// <br>           : 2009.07.07　佐々木 健　MANTIS対応[0013663]</br>
    /// <br>           : 2010/04/15　鈴木 正臣　MANTIS対応[0015286]</br>
    /// <br>           : 2010/11/15　曹文傑　障害改良対応「２」の対応</br>
    /// <br>           : 2010/11/19　鈴木 正臣　商品自動登録の価格開始日を前回月次更新日＋１に変更</br>
    /// <br>           :                       （※参照設定に追加：DCCMN00003C.dll、SFUKN09001E.dll）</br>
    /// <br>           : 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
    /// <br>           : 2011/05/10 dingjx Redmine #21101</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>Update Date: K2013/09/11 田建委</br>
    /// <br>           : フタバ個別対応</br>
    /// <br>           : テキスト変換後のデータを修正・削除不可とする。</br>
    /// <br>Update Date: K2013/10/10 田建委</br>
    /// <br>           : フタバ個別対応</br>
    /// <br>           : Redmine#40626 フタバテキスト変換抽出済判断処理を動的に呼出す様に修正。</br>
    /// <br>Update Note: K2013/12/25 鄧潘ハン</br>
    /// <br>             フタバ個別拠点間発注ﾃﾞｰﾀより、入庫ﾃﾞｰﾀの作成することの対応</br>
    /// <br>Update Note: K2014/01/20 wangl2</br>
    /// <br>             Redmine#41497 フタバ個別対応</br>
    /// <br>Update Note: K2014/11/20 劉超</br>
    /// <br>             Redmine#44000 フタバ　在庫移動入力入荷確定処理のエラーの対応</br>
    /// </remarks>
    public class StockMoveInputAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
        private StockMoveInputAcs ()
        {
            // 変数初期化

            // 在庫移動初期化データ
            this._stockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();

            // 在庫移動ヘッダ情報
            this._StockMoveHeader = _stockMoveInputInitAcs.StockMoveHeader;

            // 在庫移動検索条件情報
            this._StockMoveSlipSearchCond = _stockMoveInputInitAcs.StockMoveSlipSearchCond;

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // 在庫検索アクセスクラス
            this._searchStockAcs = new SearchStockAcs();
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // 在庫移動データセット
            this._dataSet = new StockMoveInputDataSet();

            // 在庫移動データテーブル
            this._stockMoveDataTable = this._dataSet.StockMove;

            // 在庫移動初期データテーブルバックアップ
            this._stockMoveDataTableBackup = new StockMoveInputDataSet.StockMoveDataTable();

            // 在庫移動リモーティングオブジェクト
            this._iStockMoveDB = (IStockMoveDB)MediationStockMoveDB.GetStockMoveDB();

            // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
            //OPT-CPM0130：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaSecOrderCtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // 商品価格リモーティングオブジェクト
            this._iGoodsPriceUDB = MediationGoodsPriceUDB.GetGoodsPriceUDB();
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // 商品アクセスクラス
            this._goodsAcs = new GoodsAcs();
            _goodsAcsInitializeSectionCode = string.Empty;

            // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
            this._goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();

            this._makerAcs = new MakerAcs();

            // メーカーマスタ取得
            LoadMakerUMnt();

            this._blGoodsCdAcs = new BLGoodsCdAcs();

            this._stockMngTtlStAcs = new StockMngTtlStAcs();

            this._companyInfAcs = new CompanyInfAcs();  // ADD 2011/07/25

            // BL商品コードマスタ取得
            LoadBlGoodsCdUMnt();

            // 在庫管理全体設定マスタ取得
            LoadStockMngTtlSt();

            this._searchStockAcs = new SearchStockAcs();
            // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            this._supplierAcs = new SupplierAcs();

            // 仕入先マスタ取得
            LoadSupplierCdUMnt();
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<

        }

        public static string GetStr()
        {
            return "";
        }

        /// <summary>
        /// 在庫移動入力アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>仕入入力アクセスクラス インスタンス</returns>
        public static StockMoveInputAcs GetInstance ()
        {
            if ( _stockMoveInputAcs == null )
            {
                _stockMoveInputAcs = new StockMoveInputAcs();
            }

            return _stockMoveInputAcs;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members

        // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[入荷時刻]列を追加 ---------->>>>>
        /// <summary>時刻のフォーマット</summary>
        public const string TIME_FORMAT = "HH:mm:ss";
        // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[入荷時刻]列を追加 ----------<<<<<

        // 在庫移動ヘッダ情報
        private StockMoveHeader _StockMoveHeader;

        // 在庫移動検索条件情報
        private StockMoveSlipSearchCond _StockMoveSlipSearchCond;

        // 在庫移動初期化アクセス部品
        private StockMoveInputInitDataAcs _stockMoveInputInitAcs;

        // 在庫移動入力処理関連アクセス部品
        private static StockMoveInputAcs _stockMoveInputAcs;

        //IFuTaBaStockMoveJoinWorkDB _iFuTaBaStockMoveJoinWorkDB; // ADD K2013/09/11 田建委 // DEL K2013/09/11 田建委 Redmine#40626
        // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0130：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;

        // 拠点間発注データにて抽出済み伝票の格納
        private Dictionary<string, ArrayList> _orderDataDic;

        // 拠点間発注データにて抽出済み伝票を取得
        //private IFutabaSecOrderDtDB _iSecOrderDB;// DEL K2014/01/20 wangl2 Redmine#41497
        // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        // 商品価格リモートオブジェクト
        private IGoodsPriceUDB _iGoodsPriceUDB;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // 在庫移動処理リモートオブジェクト
        private IStockMoveDB _iStockMoveDB;

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// 在庫検索アクセスクラス
        private SearchStockAcs _searchStockAcs;
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        // 在庫移動処理データセット
        private StockMoveInputDataSet _dataSet;

        // グリッドの移動伝票番号初期値
        private int _currentStockMoveSlipNo = 0;

        // 在庫移動グリッドデータテーブル
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTable;

        // 検索初期グリッドデータ保持用テーブル
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTableBackup;

        // バックアップフラグ
        Boolean backupFlg = false;

        // 所属拠点コード
        private string _belongSectionCode;
        // 所属拠点名称
        private string _belongSectionName;

        // 商品アクセスクラス
        private GoodsAcs _goodsAcs;
        // 商品アクセスSearchInitial拠点退避
        private string _goodsAcsInitializeSectionCode;

        private bool _slipPrint;

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        private Dictionary<string, GoodsUnitData> _goodsUnitDataDic;

        private MakerAcs _makerAcs;
        private Dictionary<int, MakerUMnt> _makerUMntDic;

        private BLGoodsCdAcs _blGoodsCdAcs;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;

        private StockMngTtlStAcs _stockMngTtlStAcs;
        private CompanyInfAcs _companyInfAcs;    // ADD 2011/07/25
        private CompanyInf _companyInf = null;   // 自社情報  // ADD 2011/07/25
        private Dictionary<string, StockMngTtlSt> _stockMngTtlStDic;

        private int _stockMoveFormal;
        private int _stockMoveSlipNo;

        /// <summary>在庫検索アクセスクラス</summary>
        private SearchStockAcs _searchStockAcs;
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        //---UPD 2011/04/11----------------------------------------------------------->>>>>
        // 仕入先ガイド
        private SupplierAcs _supplierAcs;
        private Dictionary<int, Supplier> _supplierAcsUMntDic;
        //---UPD 2011/04/11-----------------------------------------------------------<<<<<

        /// <summary>伝票区分「0：出庫伝票、1：入庫伝票」</summary>
        private int _slipDiv = 0;                   //ADD 2009/06/04

        private ArrayList _prevStockMoveWorkList = null; // ADD 2010/11/15

        // --- ADD m.suzuki 2010/11/19 ---------->>>>>
        private TotalDayCalculator _totalDayCalculator; // 締日チェック部品
        private DateGetAcs _dateGetAcs; // 日付取得部品
        // --- ADD m.suzuki 2010/11/19 ----------<<<<<

        //  ADD dingjx  Redmine #21101  >>>
        private int count;      // 空白行を削除使用
        //  ADD dingjx  Redmine #21101  <<<
        # endregion

        # region Public Readonly Members
        public static readonly int CODE_ROWSTATUS_NORMAL = 0;
        public static readonly int CODE_ROWSTATUS_COPY = 1;
        public static readonly int CODE_ROWSTATUS_CUT = 2;
        public static readonly string PRODUCT_NUMBER_STRING = "＊＊＊";
        public static readonly int MODE_PRODUCTNUMBER_INPUT = 0;
        public static readonly int MODE_BELONGINFO_INPUT = 1;
        # endregion

        # region Properties
        /// <summary>
        /// 移動在庫明細データテーブルプロパティ
        /// </summary>
        public StockMoveInputDataSet.StockMoveDataTable StockMoveDataTable
        {
            get { return _stockMoveDataTable; }
        }

        /// <summary>
        /// 移動在庫明細データテーブルバックアッププロパティ
        /// </summary>
        public StockMoveInputDataSet.StockMoveDataTable StockMoveDataTableBackup
        {
            get { return _stockMoveDataTableBackup; }
        }

        public Boolean SlipPrint
        {
            get { return _slipPrint; }
            set { _slipPrint = value; }
        }

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        public Dictionary<string, GoodsUnitData> GoodsUnitDataDic
        {
            get { return _goodsUnitDataDic; }
        }

        public int StockMoveFormal
        {
            get { return _stockMoveFormal; }
        }

        public int StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<
        // ---- ADD K2013/12/25 鄧潘ハン ------------------------------- >>>>>
        /// <summary>拠点間発注データにて抽出済み伝票の格納</summary>
        public Dictionary<string, ArrayList> OrderDataDic
        {
            get { return _orderDataDic; }
        }
        // ---- ADD K2013/12/25 鄧潘ハン ------------------------------- <<<<<
        // ---ADD 2009/06/04 --------------------->>>>>
        /// <summary>伝票区分「0：出庫伝票、1：入庫伝票」</summary>
        public int SlipDiv
        {
            set { this._slipDiv = value; }
        }
        // ---ADD 2009/06/04 ---------------------<<<<<
        # endregion

        public int ReadGoods(int makerCode, string goodsNo, ConstantManagement.LogicalMode logicalMode, out List<Stock> stockList)
        {
            stockList = new List<Stock>();

            GoodsUnitData wkGoodsUnitData;
            List<Rate> wkRateList;
            int wkStatus = this._goodsAcs.ReadGoodsWithRate(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, logicalMode, out wkGoodsUnitData, out wkRateList);
            if (wkStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                stockList = wkGoodsUnitData.StockList;
            }

            return wkStatus;
        }

        /// <summary>
        /// メーカーマスタ取得
        /// </summary>
        public void LoadMakerUMnt()
        {
            ArrayList retList;
            int status;

            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                status = this._makerAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
                else
                {
                    this._makerUMntDic = new Dictionary<int, MakerUMnt>();
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        public string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// 在庫管理全体設定マスタ取得
        /// </summary>
        public void LoadStockMngTtlSt()
        {
            this._stockMngTtlStDic = new Dictionary<string, StockMngTtlSt>();

            try
            {
                ArrayList retList;
                int status = this._stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (StockMngTtlSt stockMngTtlSt in retList)
                    {
                        if (stockMngTtlSt.LogicalDeleteCode == 0)
                        {
                            this._stockMngTtlStDic.Add(stockMngTtlSt.SectionCode.Trim(), stockMngTtlSt);
                        }
                    }
                }
            }
            catch
            {
                this._stockMngTtlStDic = new Dictionary<string, StockMngTtlSt>();
            }
        }

        // --- ADD 2011/07/25 --- >>>
        /// <summary>
        /// 自社情報設定マスタ取得
        /// </summary>
        public void LoadCompanyInf()
        {
            this._companyInfAcs.Read(out this._companyInf, LoginInfoAcquisition.EnterpriseCode);
        }

        // 自社情報設定マスタ
        public CompanyInf GetCompanyInf()
        {
            return this._companyInf;
        }
        // --- ADD 2011/07/25 --- <<<

        /// <summary>
        /// 在庫切れ出荷区分取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>在庫切れ出荷区分(0:無し 1:警告 2:警告＋再入力 3:再入力)</returns>
        public int GetStockTolerncShipmDiv(string sectionCode)
        {
            if (this._stockMngTtlStDic.ContainsKey(sectionCode.Trim()))
            {
                return this._stockMngTtlStDic[sectionCode.Trim()].StockTolerncShipmDiv;
            }
            else
            {
                return this._stockMngTtlStDic["00"].StockTolerncShipmDiv;
            }
        }

        /// <summary>
        /// BL商品コードマスタ取得
        /// </summary>
        public void LoadBlGoodsCdUMnt()
        {
            ArrayList retList;
            int status;

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                status = this._blGoodsCdAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
                else
                {
                    this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        //---ADD 2011/04/11----------------------------------------------------------->>>>>
        /// <summary>
        /// 仕入先マスタ取得
        /// </summary>
        /// <br>Note　　　  : 明細に仕入先を追加する。</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/04/11</br>
        public void LoadSupplierCdUMnt()
        {
            ArrayList retList;
            int status;

            this._supplierAcsUMntDic = new Dictionary<int, Supplier>();

            try
            {
                status = this._supplierAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode == 0)
                        {
                            this._supplierAcsUMntDic.Add(supplier.SupplierCd, supplier);
                        }
                    }
                }
                else
                {
                    this._supplierAcsUMntDic = new Dictionary<int, Supplier>();
                }
            }
            catch
            {
                this._supplierAcsUMntDic = new Dictionary<int, Supplier>();
            }
        
        
        }
        //---ADD 2011/04/11-----------------------------------------------------------<<<<<<

        /// <summary>
        /// BLコード名取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BLコード名</returns>
        public string GetBLGoodsFullName(int blGoodsCode)
        {
            string bLGoodsFullName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                bLGoodsFullName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsFullName.Trim();
            }

            return bLGoodsFullName;
        }

        // ===================================================================================== //
        // ＜在庫移動＞　登録・削除   Write, Delete
        // ===================================================================================== //

        public int StringToInt(string strTarget)
        {
            int intTarget = 0;

            try
            {
                intTarget = Convert.ToInt32(strTarget);
            }
            catch
            {
                return 0;
            }

            return intTarget;
        }

        private double StringToDouble(string strTarget)
        {
            double doubleTarget = 0;

            try
            {
                doubleTarget = Convert.ToDouble(strTarget);
            }
            catch
            {
                return 0;
            }

            return doubleTarget;
        }

        private double ObjDoubleToDouble(object target)
        {
            if ((target == DBNull.Value) || (target == null))
            {
                return 0;
            }

            return (double)target;
        }

        private double ObjStringToDouble(object target)
        {
            if ((target == DBNull.Value) || (target == null) || ((string)target == ""))
            {
                return 0;
            }

            return double.Parse((string)target);
        }

        # region ■■　在庫移動データ登録　■■

        public int WriteStockMove(out bool isNew)
        {
            // 在庫移動データワークオブジェクト格納リスト
            ArrayList stockMoveList = new ArrayList();

            //  ADD dingjx  Redmine #21101  >>>
            this.count = 0;
            //  ADD dingjx  Redmine #21101  <<<

            // 所属拠点取得
            GetBelongSection(_stockMoveInputInitAcs.StockMoveHeader.StockMvEmpCode);

            // 新規に登録するのか、更新なのかを判断
            if (_stockMoveInputInitAcs.RegistMode == 0)
            {
                //------------------------------------------------------------------
                // 新規在庫移動データ作成
                //------------------------------------------------------------------
                isNew = true;

                // 在庫移動ローカルデータをワークオブジェクトに格納
                for (int i = 0; i < _stockMoveDataTable.Count; i++)
                {
                    // 商品コード、メーカーコードが無かった場合は登録しない
                    if ((_stockMoveDataTable[i].GoodsNo.Trim() == "") ||
                        (StringToInt(_stockMoveDataTable[i].GoodsMakerCd) == 0))
                    {
                        //  ADD dingjx  Redmine #21101  >>>
                        ++(this.count);
                        //  ADD dingjx  Redmine #21101  <<<
                        continue;
                    }

                    StockMoveWork stockMoveWork = new StockMoveWork();

                    // 在庫移動ワークオブジェクトに格納(iはデータテーブルレコード番号)
                    stockMoveWork = CopyStockMoveWorkFromDataRowForNew(i);
                    stockMoveList.Add(stockMoveWork);
                }
            }
            else
            {
                //------------------------------------------------------------------
                // 更新在庫移動データ作成
                //------------------------------------------------------------------
                isNew = false;

                // 在庫移動ローカルデータをワークオブジェクトに格納
                for (int i = 0; i < _stockMoveDataTable.Count; i++)
                {
                    // 商品コード、メーカーコードが無かった場合は登録しない
                    if ((_stockMoveDataTable[i].GoodsNo.Trim() == "") ||
                        (StringToInt(_stockMoveDataTable[i].GoodsMakerCd) == 0))
                    {
                        continue;
                    }

                    StockMoveWork stockMoveWork = new StockMoveWork();

                    // 在庫移動ワークオブジェクトに格納
                    stockMoveWork = CopyStockMoveWorkFromDataRowForUpdate(i);
                    // ---ADD 2010/11/15---------------->>>>>
                    // 明細項目を何も変更しない場合、在庫受払データ作成区分は１を設定
                    if (_prevStockMoveWorkList.Count > 0)
                    {
                        foreach (StockMoveWork work in _prevStockMoveWorkList)
                        {
                            if (work.StockMoveFormal == stockMoveWork.StockMoveFormal &&
                                work.StockMoveSlipNo == stockMoveWork.StockMoveSlipNo &&
                                work.StockMoveRowNo == stockMoveWork.StockMoveRowNo)
                            {
                                if (work.MoveCount == stockMoveWork.MoveCount &&
                                    work.StockUnitPriceFl == stockMoveWork.StockUnitPriceFl &&
                                    work.ListPriceFl == stockMoveWork.ListPriceFl)
                                {
                                    stockMoveWork.CreateHistDiv = 1;
                                }
                                break;
                            }
                        }
                    }
                    // ---ADD 2010/11/15----------------<<<<<
                    stockMoveList.Add(stockMoveWork);
                }

                //// 更新時在庫データチェック
                //int checkStatus = CheckStockMove(stockMoveList);
                //if (checkStatus != 0)
                //{
                //    return checkStatus;
                //}
            }

            // 商品連結データワーククラスリスト作成
            ArrayList saveGoodsUnitDataWorkList = CreateSaveGoodsUnitDataWorkList(stockMoveList);

            // カスタムシリアライズアレイリスト生成
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // カスタムシリアライズアレイリストに在庫移動データを格納
            customSerializeArrayList.Add(stockMoveList);

            // カスタムシリアライズアレイリストに商品連結データを追加
            customSerializeArrayList.Add(saveGoodsUnitDataWorkList);

            // リモーティング引渡オブジェクト
            object obj = customSerializeArrayList;
            string msg;

            // TODO:在庫移動登録処理
            int status = this._iStockMoveDB.Write(ref obj, out msg);
            if (status == 0)
            {
                // データテーブル初期化
                this.StockMoveDetailRowInitialSetting(20);

                DelteGoodsUnitDataRecord(stockMoveList);

                customSerializeArrayList = (CustomSerializeArrayList)obj;

                ArrayList resStockMoveWorkList = (ArrayList)customSerializeArrayList[0];

                StockMoveWork stockMoveWork = (StockMoveWork)resStockMoveWorkList[0];
                this._stockMoveFormal = stockMoveWork.StockMoveFormal;
                this._stockMoveSlipNo = stockMoveWork.StockMoveSlipNo;

                // テーブルクリア
                this._stockMoveDataTable.Clear();

                // ADD MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる ---------->>>>>
                // TODO:商品の検索結果(キャッシュ)をクリア
                this.GoodsUnitDataDic.Clear();
                // ADD MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる ----------<<<<<
            }

            return (status);
        }

        /// <summary>
        /// FIXME:出荷確定ありであるか判断します。
        /// </summary>
        /// <value>在庫管理全体設定マスタ.在庫移動確定区分が 1 の場合、true を返します。</value>
        private bool FixedStockMove
        {
            get { return _stockMoveInputInitAcs.StockMngTtlSt.StockMoveFixCode.Equals(1); }
        }

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫移動データ登録 (登録・更新)
        /// </summary>
        public int WriteStockMove()
        {
            // 在庫移動データワークオブジェクト格納リスト
            ArrayList stockMoveList = new ArrayList();

            // 在庫移動詳細データワークオブジェクト格納リスト
            ArrayList stockMoveExpList = new ArrayList();

            // 所属拠点取得
            GetBelongSection( _stockMoveInputInitAcs.StockMoveHeader.StockMvEmpCode );

            // 新規に登録するのか、更新なのかを判断
            if ( _stockMoveInputInitAcs.RegistMode == 0 )
            {
                //------------------------------------------------------------------
                // 新規在庫移動データ作成
                //------------------------------------------------------------------
                # region 新規在庫移動データ作成

                // 在庫移動ローカルデータをワークオブジェクトに格納
                for ( int i = 0; i < _stockMoveDataTable.Count; i++ )
                {
                    // 数量のチェック
                    bool result = this.DataTableCountCheck();

                    if ( result == false )
                    {
                        return -4;
                    }

                    // 同一倉庫チェック
                    bool warehouseResults = this.warehouseCheck();

                    if ( warehouseResults == true )
                    {
                        return -3;
                    }

                    StockMoveWork stockMoveWork = new StockMoveWork();

                    // 商品コードがなかった場合は登録しない
                    if (_stockMoveDataTable[i].GoodsNo.Trim() == "")
                    {
                        continue;
                    }

                    // 在庫移動ワークオブジェクトに格納(iはデータテーブルレコード番号)
                    stockMoveWork = this.CopyStockMoveWorkFromDataRowForNew( i );
                    stockMoveList.Add( stockMoveWork );
                }

                # endregion
            }
            else
            {
                //------------------------------------------------------------------
                // 更新在庫移動データ作成
                //------------------------------------------------------------------
                # region 更新在庫移動データ作成

                // 在庫移動ローカルデータをワークオブジェクトに格納
                for ( int i = 0; i < _stockMoveDataTable.Count; i++ )
                {
                    // 数量のチェック
                    bool result = this.DataTableCountCheck();

                    if ( result == false )
                    {
                        return -4;
                    }

                    // 同一倉庫チェック
                    bool warehouseResults = this.warehouseCheck();

                    if ( warehouseResults == true )
                    {
                        return -3;
                    }

                    StockMoveWork stockMoveWork = new StockMoveWork();

                    // 商品コードがなかった場合は登録しない
                    if (_stockMoveDataTable[i].GoodsNo.Trim() == "")
                    {
                        continue;
                    }

                    // 在庫移動ワークオブジェクトに格納
                    stockMoveWork = this.CopyStockMoveWorkFromDataRowForUpdate( i );
                    stockMoveList.Add( stockMoveWork );
                }

                // 更新時在庫データチェック
                int checkStatus = this.CheckStockMove(stockMoveList, stockMoveExpList);

                if ( checkStatus != 0 )
                {
                    return checkStatus;
                }

                # endregion
            }

            // カスタムシリアライズアレイリスト生成
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // カスタムシリアライズアレイリストに在庫移動データ、在庫移動詳細データを格納
            customSerializeArrayList.Add( stockMoveList );
            if ( stockMoveExpList.Count != 0 )
            {
                customSerializeArrayList.Add( stockMoveExpList );
            }

            // リモーティング引渡オブジェクト
            object obj = customSerializeArrayList;
            string msg;

            // 在庫移動登録処理
            int status = this._iStockMoveDB.Write( ref obj, out msg );
            if ( status == 0 )
            {
                // データテーブル初期化
                this.StockMoveDetailRowInitialSetting( 20 );

                DelteGoodsUnitDataRecord(stockMoveList);

                customSerializeArrayList = (CustomSerializeArrayList)obj;

                ArrayList resStockMoveWorkList = (ArrayList)customSerializeArrayList[0];

                StockMoveWork stockMoveWork = (StockMoveWork)resStockMoveWorkList[0];
                this._stockMoveFormal = stockMoveWork.StockMoveFormal;
                this._stockMoveSlipNo = stockMoveWork.StockMoveSlipNo;

                // テーブルクリア
                this._stockMoveDataTable.Clear();
            }
            return status;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        # endregion

        // --- ADD 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品連結データDictionary削除処理
        /// </summary>
        /// <param name="stockMoveWorkList">在庫移動ワークリスト</param>
        /// <remarks>
        /// <br>Note　　　  : 商品連結データDictionaryの中からユーザーデータ以外を削除します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private void DelteGoodsUnitDataRecord(ArrayList stockMoveWorkList)
        {
            List<string> deleteKeyList = new List<string>();

            // 削除リスト作成
            foreach (string key in this._goodsUnitDataDic.Keys)
            {
                GoodsUnitData goodsUnitData = (GoodsUnitData)this._goodsUnitDataDic[key];
                if (goodsUnitData.OfferKubun != 0)
                {
                    if (goodsUnitData.OfferKubun == -1)
                    {
                        deleteKeyList.Add(key);
                    }
                    else
                    {
                        foreach (StockMoveWork stockMoveWork in stockMoveWorkList)
                        {
                            if (key == stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim())
                            {
                                deleteKeyList.Add(key);
                            }
                        }
                    }
                }
            }

            // 削除
            foreach (string key in deleteKeyList)
            {
                this._goodsUnitDataDic.Remove(key);
            }
        }

        /// <summary>
        /// 保存用商品データリスト作成処理
        /// </summary>
        /// <param name="stockMoveList">在庫移動データリスト</param>
        /// <returns>保存用商品データリスト</returns>
        /// <remarks>
        /// <br>Note　　　  : 保存用商品データリストを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private ArrayList CreateSaveGoodsUnitDataWorkList(ArrayList stockMoveList)
        {
            int status = 0;
            string errMsg;
            ArrayList saveGoodsUnitDataWorkList = new ArrayList();

            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsUnitDataWork goodsUnitDataWork;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>(); ;

            foreach (StockMoveWork stockMoveWork in stockMoveList)
            {
                // ADD 2010/06/15 MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる ---------->>>>>
                // TODO:商品の検索結果をクリア
                goodsUnitDataList = new List<GoodsUnitData>();
                // ADD 2010/06/15 MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる ----------<<<<<

                if (this._goodsUnitDataDic.ContainsKey(stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim()) == true)
                {
                    goodsUnitDataList.Add((GoodsUnitData)this._goodsUnitDataDic[stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim()]);
                }
                else
                {
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    goodsCndtn.EnterpriseCode = stockMoveWork.EnterpriseCode;
                    goodsCndtn.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
                    goodsCndtn.GoodsNo = stockMoveWork.GoodsNo;

                    status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);
                }

                if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                    if (goodsUnitData.OfferKubun != -1)
                    {
                        // 商品データがユーザー・提供のどちらかに存在する場合
                        if (goodsUnitDataList[0].OfferKubun != 0)
                        {
                            // 提供データの場合
                            goodsUnitDataWork = CopyToGoodsUnitDataWorkFromGoodsUnitData(goodsUnitDataList[0]);
                            UpdateGoodsUnitDataWork(ref goodsUnitDataWork, stockMoveWork);
                            saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                        }
                        else
                        {
                            // ユーザーデータの場合
                            goodsUnitDataWork = CopyToGoodsUnitDataWorkFromGoodsUnitData(goodsUnitDataList[0]);
                            saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                        }
                    }
                }
                else
                {
                    // 商品データがユーザー・提供両方に存在しない場合
                    goodsUnitDataWork = CreateGoodsUnitDataWork(stockMoveWork);
                    saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                }
            }

            return saveGoodsUnitDataWorkList;
        }

        /// <summary>
        /// 保存用商品データリスト作成処理
        /// </summary>
        /// <param name="stockMoveList">在庫移動データリスト</param>
        /// <returns>保存用商品データリスト</returns>
        /// <remarks>
        /// <br>Note　　　  : 保存用商品データリストを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private ArrayList CreateSaveGoodsUnitDataWorkListArrival(ArrayList stockMoveList)
        {
            int status = 0;
            string errMsg;
            ArrayList saveGoodsUnitDataWorkList = new ArrayList();

            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsUnitDataWork goodsUnitDataWork;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            foreach (StockMoveWork stockMoveWork in stockMoveList)
            {
                // ADD 2010/06/15 MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる ---------->>>>>
                // TODO:商品の検索結果をクリア
                goodsUnitDataList = new List<GoodsUnitData>();
                // ADD 2010/06/15 MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる ----------<<<<<

                if (this._goodsUnitDataDic.ContainsKey(stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim()) == true)
                {
                    goodsUnitDataList.Add((GoodsUnitData)this._goodsUnitDataDic[stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim()]);
                }
                else
                {
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    goodsCndtn.EnterpriseCode = stockMoveWork.EnterpriseCode;
                    goodsCndtn.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
                    goodsCndtn.GoodsNo = stockMoveWork.GoodsNo;

                    status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);
                }

                if ((status == 0) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                    if (goodsUnitData.OfferKubun != -1)
                    {
                        // 商品データがユーザー・提供のどちらかに存在する場合
                        if (goodsUnitDataList[0].OfferKubun != 0)
                        {
                            // 提供データの場合
                            goodsUnitDataWork = CopyToGoodsUnitDataWorkFromGoodsUnitData(goodsUnitDataList[0]);
                            UpdateGoodsUnitDataWork(ref goodsUnitDataWork, stockMoveWork);
                            saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                        }
                    }
                }
                else
                {
                    // 商品データがユーザー・提供両方に存在しない場合
                    goodsUnitDataWork = CreateGoodsUnitDataWork(stockMoveWork);
                    saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                }
            }

            return saveGoodsUnitDataWorkList;
        }

        /// <summary>
        /// 商品データ作成処理
        /// </summary>
        /// <param name="stockMoveWork">在庫移動データ</param>
        /// <returns>商品データ</returns>
        /// <remarks>
        /// <br>Note　　　  : 商品データを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private GoodsUnitDataWork CreateGoodsUnitDataWork(StockMoveWork stockMoveWork)
        {
            GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

            goodsUnitDataWork.EnterpriseCode = stockMoveWork.EnterpriseCode;
            goodsUnitDataWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsUnitDataWork.GoodsNo = stockMoveWork.GoodsNo;
            goodsUnitDataWork.GoodsName = stockMoveWork.GoodsName;
            goodsUnitDataWork.GoodsNameKana = stockMoveWork.GoodsNameKana;
            goodsUnitDataWork.BLGoodsCode = stockMoveWork.BLGoodsCode;
            goodsUnitDataWork.GoodsNoNoneHyphen = GetGoodsNoNoneHyphen(stockMoveWork.GoodsNo);
            ArrayList priceList = new ArrayList();
            priceList.Add(CreateGoodsPriceUWork(stockMoveWork));
            goodsUnitDataWork.PriceList = priceList;
            
            return goodsUnitDataWork;
        }

        /// <summary>
        /// 商品データ更新処理
        /// </summary>
        /// <param name="goodsUnitDataWork">商品データワーククラス</param>
        /// <param name="stockMoveWork">在庫移動データワーククラス</param>
        /// <remarks>
        /// <br>Note　　　  : 商品データを更新します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private void UpdateGoodsUnitDataWork(ref GoodsUnitDataWork goodsUnitDataWork, StockMoveWork stockMoveWork)
        {
            goodsUnitDataWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsUnitDataWork.BLGoodsCode = stockMoveWork.BLGoodsCode;
            goodsUnitDataWork.GoodsName = stockMoveWork.GoodsName;
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            goodsUnitDataWork.GoodsNameKana = stockMoveWork.GoodsNameKana;
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
        }

        /// <summary>
        /// ハイフン無品番取得処理
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <returns>ハイフン無品番</returns>
        /// <remarks>
        /// <br>Note　　　  : ハイフン無品番を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private string GetGoodsNoNoneHyphen(string goodsNo)
        {
            string goodsNoNoneHyphen = "";

            // ハイフンを削除します
            for (int i = goodsNo.Length - 1; i >= 0; i--)
            {
                if (goodsNo[i].ToString() == "-")
                {
                    goodsNo = goodsNo.Remove(i, 1);
                }
            }

            goodsNoNoneHyphen = goodsNo;
            return goodsNoNoneHyphen;
        }

        /// <summary>
        /// クラスメンバコピー処理(商品連結データ→商品連結データワーク)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>商品連結データワーククラス</returns>
        /// <remarks>
        /// <br>Note　　　  : クラスメンバをコピーします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

            goodsUnitDataWork.CreateDateTime = goodsUnitData.CreateDateTime;
            goodsUnitDataWork.UpdateDateTime = goodsUnitData.UpdateDateTime;
            goodsUnitDataWork.EnterpriseCode = goodsUnitData.EnterpriseCode;
            goodsUnitDataWork.FileHeaderGuid = goodsUnitData.FileHeaderGuid;
            goodsUnitDataWork.UpdEmployeeCode = goodsUnitData.UpdEmployeeCode;
            goodsUnitDataWork.UpdAssemblyId1 = goodsUnitData.UpdAssemblyId1;
            goodsUnitDataWork.UpdAssemblyId2 = goodsUnitData.UpdAssemblyId2;
            goodsUnitDataWork.LogicalDeleteCode = goodsUnitData.LogicalDeleteCode;
            goodsUnitDataWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
            goodsUnitDataWork.GoodsNo = goodsUnitData.GoodsNo;
            goodsUnitDataWork.GoodsName = goodsUnitData.GoodsName;
            goodsUnitDataWork.GoodsNameKana = goodsUnitData.GoodsNameKana;
            goodsUnitDataWork.Jan = goodsUnitData.Jan;
            goodsUnitDataWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
            goodsUnitDataWork.DisplayOrder = goodsUnitData.DisplayOrder;
            goodsUnitDataWork.GoodsRateRank = goodsUnitData.GoodsRateRank;
            goodsUnitDataWork.TaxationDivCd = goodsUnitData.TaxationDivCd;
            goodsUnitDataWork.GoodsNoNoneHyphen = goodsUnitData.GoodsNoNoneHyphen;
            goodsUnitDataWork.OfferDate = goodsUnitData.OfferDate;
            goodsUnitDataWork.GoodsKindCode = goodsUnitData.GoodsKindCode;
            goodsUnitDataWork.GoodsNote1 = goodsUnitData.GoodsNote1;
            goodsUnitDataWork.GoodsNote2 = goodsUnitData.GoodsNote2;
            goodsUnitDataWork.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote;
            goodsUnitDataWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;
            goodsUnitDataWork.UpdateDate = goodsUnitData.UpdateDate;
            ArrayList priceWorkList = new ArrayList();
            foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
            {
                priceWorkList.Add(CopyToGoodsPriceUWorkFromGoodsPrice(goodsPrice));
            }
            goodsUnitDataWork.PriceList = priceWorkList;
            ArrayList stockWorkList = new ArrayList();
            foreach (Stock stock in goodsUnitData.StockList)
            {
                stockWorkList.Add(CopyToStockWorkFromStock(stock));
            }
            goodsUnitDataWork.StockList = stockWorkList;

            return goodsUnitDataWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(価格マスタ→価格マスタワーク)
        /// </summary>
        /// <param name="goodsPrice">価格マスタ</param>
        /// <returns>価格マスタワーク</returns>
        /// <remarks>
        /// <br>Note　　　  : クラスメンバをコピーします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private GoodsPriceUWork CopyToGoodsPriceUWorkFromGoodsPrice(GoodsPrice goodsPrice)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
            goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
            goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;
            goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;
            goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;
            goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;
            goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;
            goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;
            goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;
            goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;
            goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;
            goodsPriceUWork.ListPrice = goodsPrice.ListPrice;
            goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;
            goodsPriceUWork.StockRate = goodsPrice.StockRate;
            goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
            goodsPriceUWork.OfferDate = goodsPrice.OfferDate;
            goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;

            return goodsPriceUWork;
        }

        /// <summary>
        /// 価格ワーククラス作成処理
        /// </summary>
        /// <param name="stockMoveWork">在庫移動ワーククラス</param>
        /// <returns>価格ワーククラス</returns>
        /// <remarks>
        /// <br>Note　　　  : 価格ワーククラスを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private GoodsPriceUWork CreateGoodsPriceUWork(StockMoveWork stockMoveWork)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            goodsPriceUWork.EnterpriseCode = stockMoveWork.EnterpriseCode;
            goodsPriceUWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsPriceUWork.GoodsNo = stockMoveWork.GoodsNo;
            // --- UPD m.suzuki 2010/11/19 ---------->>>>>
            //goodsPriceUWork.PriceStartDate = stockMoveWork.ShipmentFixDay;
            goodsPriceUWork.PriceStartDate = GetPriceStartDate( stockMoveWork.ShipmentFixDay );
            // --- UPD m.suzuki 2010/11/19 ----------<<<<<
            goodsPriceUWork.ListPrice = stockMoveWork.ListPriceFl;
            goodsPriceUWork.SalesUnitCost = stockMoveWork.StockUnitPriceFl;
            //goodsPriceUWork.OfferDate = stockMoveWork.ArrivalGoodsDay;

            return goodsPriceUWork;
        }

        // --- ADD m.suzuki 2010/11/19 ---------->>>>>
        /// <summary>
        /// 価格開始日取得処理
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private DateTime GetPriceStartDate( DateTime dateTime )
        {
            try
            {
                //--------------------------------------------------
                // 通常は、前回月次更新日の翌日
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if ( prevTotalDay != DateTime.MinValue )
                {
                    // 前回月次更新日の翌日
                    return prevTotalDay.AddDays( 1 );
                }

                //--------------------------------------------------
                // （※新規搬入して一度も月次更新をしていないような場合）自社.期首日
                //--------------------------------------------------
                if ( _dateGetAcs == null )
                {
                    _dateGetAcs = DateGetAcs.GetInstance();
                }
                else
                {
                    _dateGetAcs.ReloadCompanyInf(); // 必ず再取得する
                }
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = _dateGetAcs.GetCompanyInf();
                if ( companyInf != null && companyInf.CompanyBiginDate != 0 )
                {
                    _dateGetAcs.GetFinancialYearTable( out startMonthDateList, out endMonthDateList );
                    if ( startMonthDateList != null && startMonthDateList.Count > 0 )
                    {
                        // 期首日←最初の月の開始日
                        return startMonthDateList[0];
                    }
                }
            }
            catch
            {
            }

            // ※通常は発生しないが期首日も取得できなかった場合は既存処理と同様。
            return dateTime;
        }
        /// <summary>
        /// 前回月次更新日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetHisTotalDayMonthly()
        {
            if ( _totalDayCalculator == null ) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            int status;
            DateTime prevTotalDay;

            // 締日算出モジュールのキャッシュクリア
            this._totalDayCalculator.ClearCache();

            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment );
            if ( ps == PurchaseStatus.Contract )
            {
                // 買掛オプションあり
                // 売上月次処理日、仕入月次処理日の古い年月取得
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly( string.Empty, out prevTotalDay );
                if ( prevTotalDay == DateTime.MinValue )
                {
                    // 売上月次処理日取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec( string.Empty, out prevTotalDay );
                    if ( prevTotalDay == DateTime.MinValue )
                    {
                        // 仕入月次処理日取得
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay( string.Empty, out prevTotalDay );
                    }
                }
            }
            else
            {
                // 買掛オプションなし
                // 売上月次処理日取得
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec( string.Empty, out prevTotalDay );
            }

            return prevTotalDay;
        }
        // --- ADD m.suzuki 2010/11/19 ----------<<<<<

        /// <summary>
        /// クラスメンバコピー処理(在庫データ→在庫データワーク)
        /// </summary>
        /// <param name="stock">在庫データ</param>
        /// <returns>在庫データワーククラス</returns>
        /// <remarks>
        /// <br>Note　　　  : クラスメンバをコピーします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromStock(Stock stock)
        {
            StockWork stockWork = new StockWork();

            stockWork.CreateDateTime = stock.CreateDateTime;
            stockWork.UpdateDateTime = stock.UpdateDateTime;
            stockWork.EnterpriseCode = stock.EnterpriseCode;
            stockWork.FileHeaderGuid = stock.FileHeaderGuid;
            stockWork.UpdEmployeeCode = stock.UpdEmployeeCode;
            stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1;
            stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2;
            stockWork.LogicalDeleteCode = stock.LogicalDeleteCode;
            stockWork.SectionCode = stock.SectionCode;
            stockWork.WarehouseCode = stock.WarehouseCode;
            stockWork.GoodsMakerCd = stock.GoodsMakerCd;
            stockWork.GoodsNo = stock.GoodsNo;
            stockWork.StockUnitPriceFl = stock.StockUnitPriceFl;
            stockWork.SupplierStock = stock.SupplierStock;
            stockWork.AcpOdrCount = stock.AcpOdrCount;
            stockWork.MonthOrderCount = stock.MonthOrderCount;
            stockWork.SalesOrderCount = stock.SalesOrderCount;
            stockWork.StockDiv = stock.StockDiv;
            stockWork.MovingSupliStock = stock.MovingSupliStock;
            stockWork.ShipmentPosCnt = stock.ShipmentPosCnt;
            stockWork.StockTotalPrice = stock.StockTotalPrice;
            stockWork.LastStockDate = stock.LastStockDate;
            stockWork.LastSalesDate = stock.LastSalesDate;
            stockWork.LastInventoryUpdate = stock.LastInventoryUpdate;
            stockWork.MinimumStockCnt = stock.MinimumStockCnt;
            stockWork.MaximumStockCnt = stock.MaximumStockCnt;
            stockWork.NmlSalOdrCount = stock.NmlSalOdrCount;
            stockWork.SalesOrderUnit = stock.SalesOrderUnit;
            stockWork.StockSupplierCode = stock.StockSupplierCode;
            stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
            stockWork.WarehouseShelfNo = stock.WarehouseShelfNo;
            stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
            stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
            stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1;
            stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2;
            stockWork.StockNote1 = stock.StockNote1;
            stockWork.StockNote2 = stock.StockNote2;
            stockWork.ShipmentCnt = stock.ShipmentCnt;
            stockWork.ArrivalCnt = stock.ArrivalCnt;
            stockWork.StockCreateDate = stock.StockCreateDate;
            stockWork.UpdateDate = stock.UpdateDate;

            return stockWork;
        }
        // --- ADD 2008/07/14 ---------------------------------------------------------------------<<<<<

        # region ■■　新規在庫移動データ作成処理　■■

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 新規在庫移動データ作成処理
        /// </summary>
        /// <param name="recordIndex"></param>
        /// <returns></returns>
        private StockMoveWork CopyStockMoveWorkFromDataRowForNew ( int recordIndex )
        {
            StockMoveWork stockMoveWork = new StockMoveWork();

            // 新規登録時は企業コードのみファイルヘッダ情報を加える
            stockMoveWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点
            string loginSection = _belongSectionCode.Trim();

            //新規の在庫移動データの場合はファイルヘッダ情報を格納しない(企業コード以外)
            //stockMoveWork.CreateDateTime    = _stockMoveDataTable[recordIndex].CreateDateTime;
            //stockMoveWork.UpdateDateTime    = _stockMoveDataTable[recordIndex].UpdateDateTime;
            //stockMoveWork.FileHeaderGuid    = _stockMoveDataTable[recordIndex].FileHeaderGuid;
            //stockMoveWork.UpdEmployeeCode   = _stockMoveDataTable[recordIndex].UpdEmployeeCode;
            //stockMoveWork.UpdAssemblyId1    = _stockMoveDataTable[recordIndex].UpdAssemblyId1;
            //stockMoveWork.UpdAssemblyId2    = _stockMoveDataTable[recordIndex].UpdAssemblyId2;
            //stockMoveWork.LogicalDeleteCode = _stockMoveDataTable[recordIndex].LogicalDeleteCode;

            // 在庫移動形式
            int stockMoveFormal;
            if ( ( _StockMoveHeader.BfSectionCode.Trim() == _StockMoveHeader.AfSectionCode.Trim() ) ||
                ( loginSection == _StockMoveHeader.AfSectionCode.Trim() && loginSection == _StockMoveHeader.BfSectionCode.Trim() ) ||
                ( _StockMoveHeader.BfSectionCode.Trim() == loginSection && _StockMoveHeader.AfSectionCode.Trim() == "" ) ||
                ( _StockMoveHeader.AfSectionCode.Trim() == loginSection && _StockMoveHeader.BfSectionCode.Trim() == "" )
               )
            {
                // 倉庫間移動
                stockMoveFormal = 2;
            }
            else
            {
                // 拠点間移動
                stockMoveFormal = 1;
            }
            stockMoveWork.StockMoveFormal = stockMoveFormal;

            // 更新拠点コード(移動指示担当者の所属拠点コードを設定)
            stockMoveWork.UpdateSecCd = _belongSectionCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 在庫移動確定区分によって制御
            //if ( _stockMoveInputInitAcs.StockMoveFixCode == 1 )
            //{
            //    // 移動状態(1:未出荷状態に設定)
            //    stockMoveWork.MoveStatus = 1;
            //}
            //else if ( _stockMoveInputInitAcs.StockMoveFixCode == 2 )
            //{
            //    // 移動状態(2:移動中に設定)
            //    stockMoveWork.MoveStatus = 2;
            //}

            //// 倉庫移動であった場合は即入荷を行う
            //if ( stockMoveFormal == 2 )
            //{
            //    stockMoveWork.MoveStatus = 9;
            //}

            // 移動状態を設定
            if ( stockMoveFormal == 1 )
            {
                // 在庫移動の場合は 1:未出荷状態にする
                stockMoveWork.MoveStatus = 1;
            }
            else
            {
                // 倉庫移動の場合は即入荷
                stockMoveWork.MoveStatus = 9;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 以下、在庫移動データテーブルデータ
            stockMoveWork.StockMoveSlipNo = _stockMoveDataTable[recordIndex].StockMoveSlipNo;
            stockMoveWork.StockMoveRowNo = _stockMoveDataTable[recordIndex].StockMoveRowNo;
            stockMoveWork.GoodsMakerCd = _stockMoveDataTable[recordIndex].GoodsMakerCd;
            stockMoveWork.MakerName = _stockMoveDataTable[recordIndex].MakerName;
            stockMoveWork.GoodsNo = _stockMoveDataTable[recordIndex].GoodsNo;
            stockMoveWork.GoodsName = _stockMoveDataTable[recordIndex].GoodsName;
            stockMoveWork.BfSectionCode = _stockMoveDataTable[recordIndex].BfSectionCode;
            stockMoveWork.BfSectionGuideNm = _stockMoveDataTable[recordIndex].BfSectionGuideNm;
            stockMoveWork.BfEnterWarehCode = _stockMoveDataTable[recordIndex].BfEnterWarehCode;
            stockMoveWork.BfEnterWarehName = _stockMoveDataTable[recordIndex].BfEnterWarehName;
            stockMoveWork.WarehouseNote1 = _stockMoveDataTable[recordIndex].WarehouseNote1;
            stockMoveWork.WarehouseNote2 = _stockMoveDataTable[recordIndex].WarehouseNote2;
            stockMoveWork.WarehouseNote3 = _stockMoveDataTable[recordIndex].WarehouseNote3;
            stockMoveWork.WarehouseNote4 = _stockMoveDataTable[recordIndex].WarehouseNote4;
            stockMoveWork.WarehouseNote5 = _stockMoveDataTable[recordIndex].WarehouseNote5;

            // 以下、在庫移動処理画面ヘッダ項目
            stockMoveWork.StockMvEmpCode = _StockMoveHeader.StockMvEmpCode;
            stockMoveWork.StockMvEmpName = _StockMoveHeader.StockMvEmpName;
            string[] splitString = _StockMoveHeader.ShipmentScdlDay.ToString( "yyyy/MM/dd" ).Trim().Split( '/' );
            stockMoveWork.ShipmentScdlDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );

            //if ( stockMoveFormal == 2 )
            //{
            //    stockMoveWork.AfSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            //    stockMoveWork.AfSectionGuideNm = _stockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            //}
            //else
            //{
            //    stockMoveWork.AfSectionCode = _StockMoveHeader.AfSectionCode;
            //    stockMoveWork.AfSectionGuideNm = _StockMoveHeader.AfSectionGuideName;
            //}
            stockMoveWork.AfSectionCode = _StockMoveHeader.AfSectionCode;
            stockMoveWork.AfSectionGuideNm = _StockMoveHeader.AfSectionGuideName;

            stockMoveWork.AfEnterWarehCode = _StockMoveHeader.AfEnterWarehCode;
            stockMoveWork.AfEnterWarehName = _StockMoveHeader.AfEnterWarehName;
            stockMoveWork.Outline = _StockMoveHeader.OutLine;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 在庫確定区分が2(出荷確定無)の場合、出荷確定者を格納
            //if ( _stockMoveInputInitAcs.StockMoveFixCode == 2 ) {
            if ( _stockMoveInputInitAcs.StockMoveFixCode > 0 )
            {
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //stockMoveWork.ShipmentFixDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );
                stockMoveWork.ShipmentFixDay = DateTime.MinValue;

                stockMoveWork.ShipAgentCd = _StockMoveHeader.StockMvEmpCode;
                stockMoveWork.ShipAgentNm = _StockMoveHeader.StockMvEmpName;
            }

            // 倉庫移動だった場合、即入荷する
            if ( stockMoveFormal == 2 )
            {
                stockMoveWork.ShipmentFixDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );
                stockMoveWork.ArrivalGoodsDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );

                stockMoveWork.ShipAgentCd = _StockMoveHeader.StockMvEmpCode;
                stockMoveWork.ShipAgentNm = _StockMoveHeader.StockMvEmpName;

                stockMoveWork.ReceiveAgentCd = _StockMoveHeader.StockMvEmpCode;
                stockMoveWork.ReceiveAgentNm = _StockMoveHeader.StockMvEmpName;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            else
            {
                // 在庫移動なら、初期値セット
                stockMoveWork.ArrivalGoodsDay = DateTime.MinValue;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //在庫移動登録では確定しないデータ(出荷確定日、入荷日)
            //stockMoveWork.ShipmentFixDay = _stockMoveDataTable[recordIndex].ShipmentFixDay;
            //stockMoveWork.ArrivalGoodsDay = _stockMoveDataTable[recordIndex].ArrivalGoodsDay;

            //在庫移動登録では確定しないデータ(出荷確定担当者コード、出荷確定担当者名称)
            //stockMoveWork.ShipAgentCd = _stockMoveDataTable[recordIndex].ShipAgentCd;
            //stockMoveWork.ShipAgentNm = _stockMoveDataTable[recordIndex].ShipAgentNm;
            //在庫移動登録では確定しないデータ(入荷担当者コード、入荷担当者名称)
            //stockMoveWork.ReceiveAgentCd = _stockMoveDataTable[recordIndex].ReceiveAgentCd;
            //stockMoveWork.ReceiveAgentNm = _stockMoveDataTable[recordIndex].ReceiveAgentNm;

            // 以下、制御コード

            // 更新営業所
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 移動指示担当者の所属拠点をセット
            //stockMoveWork.UpdateSecCd = _stockMoveDataTable[recordIndex].UpdateSecCd;
            stockMoveWork.UpdateSecCd = _belongSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 入荷日
            //stockMoveWork.ArrivalGoodsDay = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            try
            {
                if ( _stockMoveDataTable[recordIndex].ArrivalGoodsDay.Contains( "/" ) )
                {
                    splitString = _stockMoveDataTable[recordIndex].ArrivalGoodsDay.Trim().Split( '/' );
                    stockMoveWork.ArrivalGoodsDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );
                }
            }
            catch
            {
            }
            // 得意先コード
            stockMoveWork.CustomerCode = _stockMoveDataTable[recordIndex].CustomerCode;
            // 得意先名称１
            stockMoveWork.CustomerName = _stockMoveDataTable[recordIndex].CustomerName;
            // 得意先名称２
            stockMoveWork.CustomerName2 = _stockMoveDataTable[recordIndex].CustomerName2;

            // 仕入単価
            stockMoveWork.StockUnitPriceFl = _stockMoveDataTable[recordIndex].StockUnitPriceFl;
            // 課税区分
            stockMoveWork.TaxationDivCd = _stockMoveDataTable[recordIndex].TaxationDivCd;

            // 出庫棚番
            stockMoveWork.BfShelfNo = _stockMoveDataTable[recordIndex].BfShelfNo;
            // 入庫棚番
            stockMoveWork.AfShelfNo = _stockMoveDataTable[recordIndex].AfShelfNo;
            // ＢＬ商品コード
            stockMoveWork.BLGoodsCode = _stockMoveDataTable[recordIndex].BLGoodsCode;
            //// ＢＬ商品コード枝番
            //stockMoveWork.BLGoodsCdDerivedNo = _stockMoveDataTable[recordIndex].BLGoodsCdDerivedNo;
            // ＢＬ商品名称
            stockMoveWork.BLGoodsFullName = _stockMoveDataTable[recordIndex].BLGoodsFullName;
            // 定価
            stockMoveWork.ListPriceFl = _stockMoveDataTable[recordIndex].ListPriceFl;

            if ( _stockMoveDataTable[recordIndex].MovingSupliStock != 0 )
            {
                // 移動数（仕:自社）
                stockMoveWork.MoveCount = _stockMoveDataTable[recordIndex].MovingSupliStock;
                // 在庫区分
                stockMoveWork.StockDiv = 0; // 0:自社
            }
            else
            {
                // 移動数（受:受託）
                stockMoveWork.MoveCount = _stockMoveDataTable[recordIndex].MovingTrustStock;
                // 在庫区分
                stockMoveWork.StockDiv = 1; // 1:委託
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 移動金額
            stockMoveWork.StockMovePrice = GetStockMovePrice( _stockMoveDataTable[recordIndex] );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return stockMoveWork;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// 新規在庫移動データ作成処理
        /// </summary>
        /// <param name="recordIndex"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note　　　  : 新規在庫移動データを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/07/14</br>
        /// <br>Update Note : 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        /// </remarks>
        private StockMoveWork CopyStockMoveWorkFromDataRowForNew(int recordIndex)
        {
            StockMoveWork stockMoveWork = new StockMoveWork();

            // 新規登録時は企業コードのみファイルヘッダ情報を加える
            stockMoveWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点
            string loginSection = this._belongSectionCode.Trim();

            // 在庫移動形式
            int stockMoveFormal;
            //if ((this._StockMoveHeader.BfSectionCode.Trim() == this._StockMoveHeader.AfSectionCode.Trim()) ||
            //    (loginSection == _StockMoveHeader.AfSectionCode.Trim() && loginSection == this._StockMoveHeader.BfSectionCode.Trim()) ||
            //    (this._StockMoveHeader.BfSectionCode.Trim() == loginSection && this._StockMoveHeader.AfSectionCode.Trim() == "") ||
            //    (this._StockMoveHeader.AfSectionCode.Trim() == loginSection && this._StockMoveHeader.BfSectionCode.Trim() == ""))
            //{
            //    // 倉庫間移動
            //    stockMoveFormal = 2;
            //}
            //else
            //{
            //    // 拠点間移動
            //    stockMoveFormal = 1;
            //}
            if (_StockMoveHeader.AfSectionCode.Trim() == _StockMoveHeader.BfSectionCode.Trim())
            {
                // 倉庫間移動
                stockMoveFormal = 2;
            }
            else
            {
                // 拠点間移動
                stockMoveFormal = 1;
            }
            stockMoveWork.StockMoveFormal = stockMoveFormal;

            // 更新拠点コード(移動指示担当者の所属拠点コードを設定)
            stockMoveWork.UpdateSecCd = this._belongSectionCode;

            // 移動状態を設定(2:移動中)
            stockMoveWork.MoveStatus = 2;

            // 以下、在庫移動データテーブルデータ
            stockMoveWork.StockMoveSlipNo = this._stockMoveDataTable[recordIndex].StockMoveSlipNo;
            //stockMoveWork.StockMoveRowNo = this._stockMoveDataTable[recordIndex].StockMoveRowNo;  // DEL dingjx  Redmine #21101

            stockMoveWork.StockMoveRowNo = this._stockMoveDataTable[recordIndex].StockMoveRowNo - this.count; // ADD dingjx  Redmine #21101

            stockMoveWork.GoodsMakerCd = StringToInt(this._stockMoveDataTable[recordIndex].GoodsMakerCd);
            stockMoveWork.MakerName = GetMakerName(stockMoveWork.GoodsMakerCd);
            stockMoveWork.GoodsNo = this._stockMoveDataTable[recordIndex].GoodsNo;
            stockMoveWork.GoodsName = this._stockMoveDataTable[recordIndex].GoodsName;
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            stockMoveWork.GoodsNameKana = this._stockMoveDataTable[recordIndex].GoodsNameKana;
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
            stockMoveWork.BfSectionCode = this._StockMoveHeader.BfSectionCode;
            stockMoveWork.BfSectionGuideSnm = this._StockMoveHeader.BfSectionGuideName;
            stockMoveWork.BfEnterWarehCode = this._StockMoveHeader.BfEnterWarehCode;
            stockMoveWork.BfEnterWarehName = this._StockMoveHeader.BfEnterWarehName;
            stockMoveWork.WarehouseNote1 = this._stockMoveDataTable[recordIndex].WarehouseNote1;

            // 以下、在庫移動処理画面ヘッダ項目
            stockMoveWork.StockMvEmpCode = this._StockMoveHeader.StockMvEmpCode;
            stockMoveWork.StockMvEmpName = this._StockMoveHeader.StockMvEmpName;
            stockMoveWork.ShipmentScdlDay = this._StockMoveHeader.ShipmentScdlDay;
            stockMoveWork.ShipmentFixDay = this._StockMoveHeader.ShipmentScdlDay;
            stockMoveWork.ArrivalGoodsDay = DateTime.MinValue;

            stockMoveWork.ShipAgentCd = this._StockMoveHeader.StockMvEmpCode;
            stockMoveWork.ShipAgentNm = this._StockMoveHeader.StockMvEmpName;

            stockMoveWork.AfSectionCode = this._StockMoveHeader.AfSectionCode;
            stockMoveWork.AfSectionGuideSnm = this._StockMoveHeader.AfSectionGuideName;

            stockMoveWork.AfEnterWarehCode = this._StockMoveHeader.AfEnterWarehCode;
            stockMoveWork.AfEnterWarehName = this._StockMoveHeader.AfEnterWarehName;
            stockMoveWork.Outline = this._StockMoveHeader.OutLine;

            // 移動指示担当者の所属拠点をセット
            stockMoveWork.UpdateSecCd = this._belongSectionCode;

            //---UPD 2011/04/11-------------------------------->>>>>
            // 仕入先コード
            //stockMoveWork.SupplierCd = this._stockMoveDataTable[recordIndex].CustomerCode;// DEL 2011/04/11
            stockMoveWork.SupplierCd = StringToInt(this._stockMoveDataTable[recordIndex].SupplierCd);
            //---UPD 2011/04/11--------------------------------<<<<<

            //---UPD 2011/04/11-------------------------------->>>>>
            // 仕入先略称
            //stockMoveWork.SupplierSnm = this._stockMoveDataTable[recordIndex].CustomerName.Trim() + this._stockMoveDataTable[recordIndex].CustomerName2.Trim();// DEL 2011/04/11
            stockMoveWork.SupplierSnm = this._stockMoveDataTable[recordIndex].SupplierSnm;
            //---UPD 2011/04/11-------------------------------->>>>>
            
            // 仕入単価
            stockMoveWork.StockUnitPriceFl = ObjDoubleToDouble(this._stockMoveDataTable[recordIndex]["StockUnitPriceFl"]);
            // 課税区分
            stockMoveWork.TaxationDivCd = this._stockMoveDataTable[recordIndex].TaxationDivCd;

            // 出庫棚番
            stockMoveWork.BfShelfNo = this._stockMoveDataTable[recordIndex].BfShelfNo;
            // 入庫棚番
            stockMoveWork.AfShelfNo = this._stockMoveDataTable[recordIndex].AfShelfNo;
            // ＢＬ商品コード
            stockMoveWork.BLGoodsCode = StringToInt(this._stockMoveDataTable[recordIndex].BLGoodsCode);
            // ＢＬ商品名称
            stockMoveWork.BLGoodsFullName = GetBLGoodsFullName(stockMoveWork.BLGoodsCode);
            // 定価
            //if ((this._stockMoveDataTable[recordIndex]["ListPriceFlView"] != DBNull.Value) &&
            //    (this._stockMoveDataTable[recordIndex]["ListPriceFlView"] != null) &&
            //    ((string)this._stockMoveDataTable[recordIndex]["ListPriceFlView"] != ""))
            //{
            //    if ((string)this._stockMoveDataTable[recordIndex]["ListPriceFlView"] == "オープン価格")
            //    {
            //        stockMoveWork.ListPriceFl = 0;
            //    }
            //    else
            //    {
            //        stockMoveWork.ListPriceFl = ObjStringToDouble(this._stockMoveDataTable[recordIndex]["ListPriceFlView"]);
            //    }
            //}
            //else
            //{
            //    stockMoveWork.ListPriceFl = ObjStringToDouble(this._stockMoveDataTable[recordIndex]["ListPriceFlView"]);
            //}
            stockMoveWork.ListPriceFl = ObjStringToDouble(this._stockMoveDataTable[recordIndex]["ListPriceFlView"]);

            if (this._stockMoveDataTable[recordIndex].MovingSupliStock != 0)
            {
                // 移動数（仕:自社）
                stockMoveWork.MoveCount = this._stockMoveDataTable[recordIndex].MovingSupliStock;
                // 在庫区分
                stockMoveWork.StockDiv = 0; // 0:自社
            }
            else
            {
                // 移動数（受:受託）
                stockMoveWork.MoveCount = this._stockMoveDataTable[recordIndex].MovingTrustStock;
                // 在庫区分
                stockMoveWork.StockDiv = 1; // 1:委託
            }

            // 移動金額
            stockMoveWork.StockMovePrice = GetStockMovePrice(this._stockMoveDataTable[recordIndex]);

            // 入力日
            stockMoveWork.InputDay = DateTime.Today;

            // 伝票発行済区分
            if (_slipPrint == true)
            {
                stockMoveWork.SlipPrintFinishCd = 1;
            }
            else
            {
                stockMoveWork.SlipPrintFinishCd = 0;
            }

            // ---ADD 2009/06/04 在庫移動確定区分が「2：入荷確定なし」の場合にセットする値を変更する --------------------------->>>>>
            stockMoveWork.ReceiveAgentCd = this._StockMoveHeader.StockMvEmpCode;
            stockMoveWork.ReceiveAgentNm = this._StockMoveHeader.StockMvEmpName;

            // 在庫移動確定区分
            stockMoveWork.StockMoveFixCode = this._stockMoveInputInitAcs.StockMoveFixCode;

            // --- ADD 三戸 2012/07/05 ---------->>>>>
            // 移動時在庫自動登録区分
            stockMoveWork.MoveStockAutoInsDiv = this._stockMoveInputInitAcs.MoveStockAutoInsDiv;
            // --- ADD 三戸 2012/07/05 ----------<<<<<

            if (stockMoveWork.StockMoveFixCode == 2)
            {
                //画面の伝票区分が「0：出庫伝票」時
                if (this._slipDiv == 0)
                {
                    //入荷日
                    stockMoveWork.ArrivalGoodsDay = this._StockMoveHeader.ShipmentScdlDay;
                    //移動状態
                    stockMoveWork.MoveStatus = 9;       //入荷済
                }
                //画面の伝票区分が「1：入庫伝票」時
                else if (this._slipDiv == 1)
                {
                    //在庫移動形式
                    if (stockMoveWork.StockMoveFormal == 1)
                    {
                        stockMoveWork.StockMoveFormal = 3;      // 在庫移動
                    }
                    else
                    {
                        stockMoveWork.StockMoveFormal = 4;      // 倉庫移動
                    }
                    //入荷日
                    stockMoveWork.ArrivalGoodsDay = this._StockMoveHeader.ShipmentScdlDay;
                    //移動状態
                    stockMoveWork.MoveStatus = 9;       //入荷済
                }
                //画面の伝票区分が非表示の時
                else
                {
                    //変更しない
                }
            }
            // ---ADD 2009/06/04 在庫移動確定区分が「2：入荷確定なし」の場合にセットする値を変更する ---------------------------<<<<<

            return stockMoveWork;
        }

        /// <summary>
        /// 在庫移動金額取得
        /// </summary>
        /// <param name="stockMoveRow"></param>
        /// <returns></returns>
        private Int64 GetStockMovePrice( StockMoveInputDataSet.StockMoveRow stockMoveRow )
        {
            long totalPrice = 0;

            // 単価
            double unitPrice = ObjDoubleToDouble(stockMoveRow["StockUnitPriceFl"]);
            // 出荷数
            double movingSupliStock;

            if (stockMoveRow.MovingSupliStock != 0)
            {
                // 仕入在庫に対する金額
                movingSupliStock = stockMoveRow.MovingSupliStock;
            }
            else
            {
                // 受託在庫に対する金額
                movingSupliStock = stockMoveRow.MovingTrustStock;
            }

            // 合計に加算する。
            double dblTotalPrice = unitPrice * movingSupliStock;
            switch (this._stockMoveInputInitAcs.StockMngTtlSt.FractionProcCd)
            {
                case 1:
                    {
                        // 切り捨て
                        totalPrice += (long)(dblTotalPrice / 1);
                        break;
                    }
                case 2:
                    {
                        // 四捨五入
                        totalPrice += (long)((dblTotalPrice + 0.5) / 1);
                        break;
                    }
                case 3:
                    {
                        // 切り上げ
                        if (dblTotalPrice % 1 == 0)
                        {
                            totalPrice += (long)(dblTotalPrice);
                        }
                        else
                        {
                            totalPrice += (long)((dblTotalPrice + 1) / 1);
                        }
                        break;
                    }
            }

            return totalPrice;
        }
        # endregion ■■　新規在庫移動データ作成処理　■■

        # region ■■　更新在庫移動データ作成処理　■■

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 更新在庫移動データ作成処理
        /// </summary>
        /// <param name="recordIndex"></param>
        /// <returns></returns>
        private StockMoveWork CopyStockMoveWorkFromDataRowForUpdate ( int recordIndex )
        {
            StockMoveWork stockMoveWork = new StockMoveWork();

            // 更新の在庫移動データの場合はファイルヘッダ情報を格納する(ただし追加レコードの場合はEnterPriseCodeのみ)
            if ( _stockMoveDataTable[recordIndex].IsNull( "CreateDateTime" ) )
            {
                stockMoveWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }
            else
            {
                stockMoveWork.CreateDateTime = _stockMoveDataTable[recordIndex].CreateDateTime;
                stockMoveWork.UpdateDateTime = _stockMoveDataTable[recordIndex].UpdateDateTime;
                stockMoveWork.EnterpriseCode = _stockMoveDataTable[recordIndex].EnterpriseCode;
                stockMoveWork.FileHeaderGuid = _stockMoveDataTable[recordIndex].FileHeaderGuid;
                stockMoveWork.UpdEmployeeCode = _stockMoveDataTable[recordIndex].UpdEmployeeCode;
                stockMoveWork.UpdAssemblyId1 = _stockMoveDataTable[recordIndex].UpdAssemblyId1;
                stockMoveWork.UpdAssemblyId2 = _stockMoveDataTable[recordIndex].UpdAssemblyId2;
                stockMoveWork.LogicalDeleteCode = _stockMoveDataTable[recordIndex].LogicalDeleteCode;
            }

            // 在庫移動形式
            int stockMoveFormal;
            if ( ( LoginInfoAcquisition.Employee.BelongSectionCode.Trim() == _StockMoveHeader.AfSectionCode.Trim() ) ||
                 _StockMoveHeader.AfSectionCode.Trim() == "" )
            {
                // 倉庫間移動
                stockMoveFormal = 2;
            }
            else
            {
                // 拠点間移動
                stockMoveFormal = 1;
            }
            stockMoveWork.StockMoveFormal = stockMoveFormal;

            // 更新拠点コード(移動指示担当者の拠点コードを設定)
            stockMoveWork.UpdateSecCd = _belongSectionCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 在庫移動確定区分によって制御
            //if ( _stockMoveInputInitAcs.StockMoveFixCode == 1 )
            //{
            //    // 移動状態(1:未出荷状態に設定)
            //    stockMoveWork.MoveStatus = 1;
            //}
            //else if ( _stockMoveInputInitAcs.StockMoveFixCode == 2 )
            //{
            //    // 移動状態(2:移動中に設定)
            //    stockMoveWork.MoveStatus = 2;
            //}

            //// 倉庫移動であった場合は即入荷を行う
            //if ( stockMoveFormal == 2 )
            //{
            //    stockMoveWork.MoveStatus = 9;
            //}

            if ( stockMoveFormal == 1 )
            {
                // 在庫移動の場合は移動中に設定
                // (移動確定後は更新できないので考慮しない)
                stockMoveWork.MoveStatus = 1;
            }
            else
            {
                // 倉庫移動の場合は入荷にする
                stockMoveWork.MoveStatus = 9;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 以下、在庫移動データテーブルデータ
            stockMoveWork.StockMoveSlipNo = _stockMoveDataTable[recordIndex].StockMoveSlipNo;
            stockMoveWork.StockMoveRowNo = _stockMoveDataTable[recordIndex].StockMoveRowNo;
            stockMoveWork.GoodsMakerCd = _stockMoveDataTable[recordIndex].GoodsMakerCd;
            stockMoveWork.MakerName = _stockMoveDataTable[recordIndex].MakerName;
            stockMoveWork.GoodsNo = _stockMoveDataTable[recordIndex].GoodsNo;
            stockMoveWork.GoodsName = _stockMoveDataTable[recordIndex].GoodsName;
            stockMoveWork.BfSectionCode = _stockMoveDataTable[recordIndex].BfSectionCode;
            stockMoveWork.BfSectionGuideNm = _stockMoveDataTable[recordIndex].BfSectionGuideNm;
            stockMoveWork.BfEnterWarehCode = _stockMoveDataTable[recordIndex].BfEnterWarehCode;
            stockMoveWork.BfEnterWarehName = _stockMoveDataTable[recordIndex].BfEnterWarehName;
            stockMoveWork.WarehouseNote1 = _stockMoveDataTable[recordIndex].WarehouseNote1;
            stockMoveWork.WarehouseNote2 = _stockMoveDataTable[recordIndex].WarehouseNote2;
            stockMoveWork.WarehouseNote3 = _stockMoveDataTable[recordIndex].WarehouseNote3;
            stockMoveWork.WarehouseNote4 = _stockMoveDataTable[recordIndex].WarehouseNote4;
            stockMoveWork.WarehouseNote5 = _stockMoveDataTable[recordIndex].WarehouseNote5;

            // 以下、在庫移動処理画面ヘッダ項目
            stockMoveWork.StockMvEmpCode = _StockMoveHeader.StockMvEmpCode;
            stockMoveWork.StockMvEmpName = _StockMoveHeader.StockMvEmpName;

            string[] splitString = _StockMoveHeader.ShipmentScdlDay.ToString( "yyyy/MM/dd" ).Trim().Split( '/' );
            stockMoveWork.ShipmentScdlDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );

            //if ( stockMoveFormal == 2 )
            //{
            //    stockMoveWork.AfSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            //    stockMoveWork.AfSectionGuideNm = _stockMoveInputInitAcs.GetSectionName( LoginInfoAcquisition.Employee.BelongSectionCode );
            //}
            //else
            //{
            //    stockMoveWork.AfSectionCode = _StockMoveHeader.AfSectionCode;
            //    stockMoveWork.AfSectionGuideNm = _StockMoveHeader.AfSectionGuideName;
            //}
            stockMoveWork.AfSectionCode = _StockMoveHeader.AfSectionCode;
            stockMoveWork.AfSectionGuideNm = _StockMoveHeader.AfSectionGuideName;

            stockMoveWork.AfEnterWarehCode = _StockMoveHeader.AfEnterWarehCode;
            stockMoveWork.AfEnterWarehName = _StockMoveHeader.AfEnterWarehName;
            stockMoveWork.Outline = _StockMoveHeader.OutLine;

            // 倉庫移動だった場合、即入荷する
            if ( stockMoveFormal == 2 )
            {
                stockMoveWork.ShipmentFixDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );
                stockMoveWork.ArrivalGoodsDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );

                stockMoveWork.ShipAgentCd = _StockMoveHeader.StockMvEmpCode;
                stockMoveWork.ShipAgentNm = _StockMoveHeader.StockMvEmpName;

                stockMoveWork.ReceiveAgentCd = _StockMoveHeader.StockMvEmpCode;
                stockMoveWork.ReceiveAgentNm = _StockMoveHeader.StockMvEmpName;
            }
            
            //在庫移動登録では確定しないデータ(出荷確定日、入荷日)
            //stockMoveWork.ShipmentFixDay = _stockMoveDataTable[recordIndex].ShipmentFixDay;
            //stockMoveWork.ArrivalGoodsDay = _stockMoveDataTable[recordIndex].ArrivalGoodsDay;

            //在庫移動登録では確定しないデータ(出荷確定担当者コード、出荷確定担当者名称)
            //stockMoveWork.ShipAgentCd = _stockMoveDataTable[recordIndex].ShipAgentCd;
            //stockMoveWork.ShipAgentNm = _stockMoveDataTable[recordIndex].ShipAgentNm;
            //在庫移動登録では確定しないデータ(入荷担当者コード、入荷担当者名称)
            //stockMoveWork.ReceiveAgentCd = _stockMoveDataTable[recordIndex].ReceiveAgentCd;
            //stockMoveWork.ReceiveAgentNm = _stockMoveDataTable[recordIndex].ReceiveAgentNm;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 移動指示担当者の所属拠点をセット
            //stockMoveWork.UpdateSecCd = _stockMoveDataTable[recordIndex].UpdateSecCd;
            stockMoveWork.UpdateSecCd = _belongSectionCode; 
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 入荷日
            stockMoveWork.ArrivalGoodsDay = DateTime.MinValue;
            try
            {
                if ( _stockMoveDataTable[recordIndex].ArrivalGoodsDay.Contains( "/" ) )
                {
                    splitString = _stockMoveDataTable[recordIndex].ArrivalGoodsDay.Trim().Split( '/' );
                    stockMoveWork.ArrivalGoodsDay = new DateTime( Int32.Parse( splitString[0] ), Int32.Parse( splitString[1] ), Int32.Parse( splitString[2] ) );
                }
            }
            catch
            {
            }
            stockMoveWork.CustomerCode = _stockMoveDataTable[recordIndex].CustomerCode;
            stockMoveWork.CustomerName = _stockMoveDataTable[recordIndex].CustomerName;
            stockMoveWork.CustomerName2 = _stockMoveDataTable[recordIndex].CustomerName2;
            stockMoveWork.StockDiv = _stockMoveDataTable[recordIndex].StockDiv;
            stockMoveWork.StockUnitPriceFl = _stockMoveDataTable[recordIndex].StockUnitPriceFl;
            stockMoveWork.TaxationDivCd = _stockMoveDataTable[recordIndex].TaxationDivCd;
            stockMoveWork.BfShelfNo = _stockMoveDataTable[recordIndex].BfShelfNo;
            stockMoveWork.AfShelfNo = _stockMoveDataTable[recordIndex].AfShelfNo;
            //stockMoveWork.BLGoodsCdDerivedNo = _stockMoveDataTable[recordIndex].BLGoodsCdDerivedNo;
            stockMoveWork.BLGoodsFullName = _stockMoveDataTable[recordIndex].BLGoodsFullName;
            stockMoveWork.ListPriceFl = _stockMoveDataTable[recordIndex].ListPriceFl;

            if ( _stockMoveDataTable[recordIndex].MovingSupliStock != 0 )
            {
                // 移動数（仕:自社）
                stockMoveWork.MoveCount = _stockMoveDataTable[recordIndex].MovingSupliStock;
                // 在庫区分
                stockMoveWork.StockDiv = 0; // 0:自社
            }
            else
            {
                // 移動数（受:受託）
                stockMoveWork.MoveCount = _stockMoveDataTable[recordIndex].MovingTrustStock;
                // 在庫区分
                stockMoveWork.StockDiv = 1; // 1:委託
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 移動金額
            stockMoveWork.StockMovePrice = GetStockMovePrice( _stockMoveDataTable[recordIndex] );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return stockMoveWork;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        /// <summary>
        /// 更新在庫移動データ作成処理
        /// </summary>
        /// <param name="recordIndex"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note　　　  : 更新在庫移動データを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        /// </remarks>
        private StockMoveWork CopyStockMoveWorkFromDataRowForUpdate(int recordIndex)
        {
            StockMoveWork stockMoveWork = new StockMoveWork();

            // 更新の在庫移動データの場合はファイルヘッダ情報を格納する(ただし追加レコードの場合はEnterPriseCodeのみ)
            if (_stockMoveDataTable[recordIndex].IsNull("CreateDateTime"))
            {
                stockMoveWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }
            else
            {
                stockMoveWork.CreateDateTime = _stockMoveDataTable[recordIndex].CreateDateTime;
                stockMoveWork.UpdateDateTime = _stockMoveDataTable[recordIndex].UpdateDateTime;
                stockMoveWork.EnterpriseCode = _stockMoveDataTable[recordIndex].EnterpriseCode;
                stockMoveWork.FileHeaderGuid = _stockMoveDataTable[recordIndex].FileHeaderGuid;
                stockMoveWork.UpdEmployeeCode = _stockMoveDataTable[recordIndex].UpdEmployeeCode;
                stockMoveWork.UpdAssemblyId1 = _stockMoveDataTable[recordIndex].UpdAssemblyId1;
                stockMoveWork.UpdAssemblyId2 = _stockMoveDataTable[recordIndex].UpdAssemblyId2;
                stockMoveWork.LogicalDeleteCode = _stockMoveDataTable[recordIndex].LogicalDeleteCode;
            }

            // 在庫移動形式
            int stockMoveFormal;
            if (_StockMoveHeader.AfSectionCode.Trim() == _StockMoveHeader.BfSectionCode.Trim())
            {
                // 倉庫間移動
                stockMoveFormal = 2;
            }
            else
            {
                // 拠点間移動
                stockMoveFormal = 1;
            }
            //if ((LoginInfoAcquisition.Employee.BelongSectionCode.Trim() == _StockMoveHeader.AfSectionCode.Trim()) ||
            //     _StockMoveHeader.AfSectionCode.Trim() == "")
            //{
            //    // 倉庫間移動
            //    stockMoveFormal = 2;
            //}
            //else
            //{
            //    // 拠点間移動
            //    stockMoveFormal = 1;
            //}
            stockMoveWork.StockMoveFormal = stockMoveFormal;

            // 更新拠点コード(移動指示担当者の拠点コードを設定)
            stockMoveWork.UpdateSecCd = _belongSectionCode;

            // 在庫移動の場合は移動中に設定
            // (移動確定後は更新できないので考慮しない)
            stockMoveWork.MoveStatus = 2;

            // 以下、在庫移動データテーブルデータ
            stockMoveWork.StockMoveSlipNo = _stockMoveDataTable[recordIndex].StockMoveSlipNo;
            stockMoveWork.StockMoveRowNo = _stockMoveDataTable[recordIndex].StockMoveRowNo;
            stockMoveWork.GoodsMakerCd = StringToInt(_stockMoveDataTable[recordIndex].GoodsMakerCd);
            stockMoveWork.MakerName = GetMakerName(stockMoveWork.GoodsMakerCd);
            stockMoveWork.GoodsNo = _stockMoveDataTable[recordIndex].GoodsNo;
            stockMoveWork.GoodsName = _stockMoveDataTable[recordIndex].GoodsName;
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            stockMoveWork.GoodsNameKana = _stockMoveDataTable[recordIndex].GoodsNameKana;
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
            stockMoveWork.BfSectionCode = _stockMoveDataTable[recordIndex].BfSectionCode;
            stockMoveWork.BfSectionGuideSnm = this._stockMoveInputInitAcs.GetSectionName(stockMoveWork.BfSectionCode);
            stockMoveWork.BfEnterWarehCode = _stockMoveDataTable[recordIndex].BfEnterWarehCode;
            stockMoveWork.BfEnterWarehName = this._stockMoveInputInitAcs.GetWarehouseName(stockMoveWork.BfEnterWarehCode);
            stockMoveWork.WarehouseNote1 = _stockMoveDataTable[recordIndex].WarehouseNote1;

            // 以下、在庫移動処理画面ヘッダ項目
            stockMoveWork.StockMvEmpCode = _StockMoveHeader.StockMvEmpCode;
            stockMoveWork.StockMvEmpName = _StockMoveHeader.StockMvEmpName;
            stockMoveWork.ShipmentScdlDay = _StockMoveHeader.ShipmentScdlDay;
            stockMoveWork.ShipmentFixDay = _StockMoveHeader.ShipmentScdlDay;
            // 入荷日
            stockMoveWork.ArrivalGoodsDay = DateTime.MinValue;

            stockMoveWork.ShipAgentCd = _StockMoveHeader.StockMvEmpCode;
            stockMoveWork.ShipAgentNm = _StockMoveHeader.StockMvEmpName;

            stockMoveWork.AfSectionCode = _StockMoveHeader.AfSectionCode;
            stockMoveWork.AfSectionGuideSnm = _StockMoveHeader.AfSectionGuideName;

            stockMoveWork.AfEnterWarehCode = _StockMoveHeader.AfEnterWarehCode;
            stockMoveWork.AfEnterWarehName = _StockMoveHeader.AfEnterWarehName;
            stockMoveWork.Outline = _StockMoveHeader.OutLine;

            stockMoveWork.UpdateSecCd = _belongSectionCode;

            //---UPD 2011/04/11------------------------------------------------>>>>>
            //stockMoveWork.SupplierCd  = _stockMoveDataTable[recordIndex].CustomerCode; // DEL 2011/04/11
            //stockMoveWork.SupplierSnm = _stockMoveDataTable[recordIndex].CustomerName.Trim() + _stockMoveDataTable[recordIndex].CustomerName2.Trim();// DEL 2011/04/11
            stockMoveWork.SupplierCd =StringToInt(_stockMoveDataTable[recordIndex].SupplierCd);
            stockMoveWork.SupplierSnm = _stockMoveDataTable[recordIndex].SupplierSnm;
            //---UPD 2011/04/15------------------------------------------------<<<<<
            stockMoveWork.StockDiv = _stockMoveDataTable[recordIndex].StockDiv;
            stockMoveWork.StockUnitPriceFl = ObjDoubleToDouble(_stockMoveDataTable[recordIndex]["StockUnitPriceFl"]);
            stockMoveWork.TaxationDivCd = _stockMoveDataTable[recordIndex].TaxationDivCd;
            stockMoveWork.BfShelfNo = _stockMoveDataTable[recordIndex].BfShelfNo;
            stockMoveWork.AfShelfNo = _stockMoveDataTable[recordIndex].AfShelfNo;
            stockMoveWork.BLGoodsCode = StringToInt(_stockMoveDataTable[recordIndex].BLGoodsCode);
            stockMoveWork.BLGoodsFullName = GetBLGoodsFullName(stockMoveWork.BLGoodsCode);
            //stockMoveWork.ListPriceFl = _stockMoveDataTable[recordIndex].ListPriceFl;
            stockMoveWork.ListPriceFl = ObjStringToDouble(this._stockMoveDataTable[recordIndex]["ListPriceFlView"]);

            if (_stockMoveDataTable[recordIndex].MovingSupliStock != 0)
            {
                // 移動数（仕:自社）
                stockMoveWork.MoveCount = _stockMoveDataTable[recordIndex].MovingSupliStock;
                // 在庫区分
                stockMoveWork.StockDiv = 0; // 0:自社
            }
            else
            {
                // 移動数（受:受託）
                stockMoveWork.MoveCount = _stockMoveDataTable[recordIndex].MovingTrustStock;
                // 在庫区分
                stockMoveWork.StockDiv = 1; // 1:委託
            }

            // 移動金額
            if ((_stockMoveDataTable[recordIndex].MovingSupliStock != _stockMoveDataTable[recordIndex].BfMovingSupliStock) ||
            //---UPD 2011/04/11-------------------------------------------------------------->>>>>
                //(_stockMoveDataTable[recordIndex].StockUnitPriceFl != _stockMoveDataTable[recordIndex].BfStockUnitPriceFl)) // DEL 2011/04/11
                (_stockMoveDataTable[recordIndex].StockUnitPriceFl != _stockMoveDataTable[recordIndex].BfStockUnitPriceFl) ||
                (StringToInt((_stockMoveDataTable[recordIndex].SupplierCd))!= _stockMoveDataTable[recordIndex].CustomerCode))
             //---UPD 2011/04/11--------------------------------------------------------------<<<<<    
           
            {
                // 移動数、仕入単価に変更がある場合は、移動金額を再計算
                stockMoveWork.StockMovePrice = GetStockMovePrice(_stockMoveDataTable[recordIndex]);
            }
            else
            {
                stockMoveWork.StockMovePrice = _stockMoveDataTable[recordIndex].MovingPrice;
            }

            // 入力日
            stockMoveWork.InputDay = DateTime.Today;

            // 伝票発行済区分
            if (_slipPrint == true)
            {
                stockMoveWork.SlipPrintFinishCd = 1;
            }

            // ---ADD 2009/06/04 在庫移動確定区分が「2：入荷確定なし」の場合にセットする値を変更する --------------------------->>>>>
            stockMoveWork.ReceiveAgentCd = this._StockMoveHeader.StockMvEmpCode;
            stockMoveWork.ReceiveAgentNm = this._StockMoveHeader.StockMvEmpName;

            // 在庫移動確定区分
            stockMoveWork.StockMoveFixCode = this._stockMoveInputInitAcs.StockMoveFixCode;

            // --- ADD 三戸 2012/07/05 ---------->>>>>
            // 移動時在庫自動登録区分
            stockMoveWork.MoveStockAutoInsDiv = this._stockMoveInputInitAcs.MoveStockAutoInsDiv;
            // --- ADD 三戸 2012/07/05 ----------<<<<<

            if (stockMoveWork.StockMoveFixCode == 2)
            {
                //画面の伝票区分が「0：出庫伝票」時
                if (this._slipDiv == 0)
                {
                    //入荷日
                    stockMoveWork.ArrivalGoodsDay = this._StockMoveHeader.ShipmentScdlDay;
                    //移動状態
                    stockMoveWork.MoveStatus = 9;       //入荷済
                }
                //画面の伝票区分が「1：入庫伝票」時
                else if (this._slipDiv == 1)
                {
                    //在庫移動形式
                    if (stockMoveWork.StockMoveFormal == 1)
                    {
                        stockMoveWork.StockMoveFormal = 3;      // 在庫移動
                    }
                    else
                    {
                        stockMoveWork.StockMoveFormal = 4;      // 倉庫移動
                    }
                    //入荷日
                    stockMoveWork.ArrivalGoodsDay = this._StockMoveHeader.ShipmentScdlDay;
                    //移動状態
                    stockMoveWork.MoveStatus = 9;       //入荷済
                }
                //画面の伝票区分が非表示の時
                else
                {
                    //変更しない
                }
            }
            // ---ADD 2009/06/04 在庫移動確定区分が「2：入荷確定なし」の場合にセットする値を変更する ---------------------------<<<<<

            return stockMoveWork;
        }

        # endregion ■■　更新在庫移動データ作成処理　■■

        # region ■■　在庫移動データ削除処理　■■

        /// <summary>
        /// 在庫移動伝票削除
        /// </summary>
        /// <returns>検索結果ステータス</returns>
        /// <br>Update Note: K2013/12/25 鄧潘ハン</br>
        /// <br>             フタバ個別拠点間発注ﾃﾞｰﾀより、入庫ﾃﾞｰﾀの作成することの対応</br>
        /// <br>Update Note: K2014/11/20 劉超</br>
        /// <br>             Redmine#44000 フタバ　在庫移動入力入荷確定処理のエラーの対応</br>
        public int DeleteStockMove (out int slipNo)
        {
            slipNo = 0;

            // 在庫移動データワークオブジェクト格納リスト
            ArrayList stockMoveList = new ArrayList();

            // 在庫移動詳細データワークオブジェクト格納リスト
            ArrayList stockMoveExpList = new ArrayList();

            // 所属拠点取得
            GetBelongSection( _stockMoveInputInitAcs.StockMoveHeader.StockMvEmpCode );

            // 在庫移動データテーブルをワークオブジェクトに格納
            for ( int i = 0; i < _stockMoveDataTable.Count; i++ )
            {
                // 商品コードの無いレコードは対象外
                if ( _stockMoveDataTable[i].GoodsNo == "" )
                {
                    continue;
                }

                // 在庫移動ワークデータ作成
                StockMoveWork stockMoveWork = CopyStockMoveWorkFromDataRowForUpdate( i );

                slipNo = stockMoveWork.StockMoveSlipNo;

                // リストに格納
                if ( stockMoveWork.GoodsNo != "" )
                {
                    stockMoveList.Add( stockMoveWork );
                }
            }

            // カスタムシリアライズアレイリスト生成
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // カスタムシリアライズアレイリストに在庫移動データ、在庫移動詳細データを格納
            customSerializeArrayList.Add( stockMoveList );
            //customSerializeArrayList.Add(stockMoveExpList);
            // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                //int futaBaStatus = GetOrderData(); // DEL K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応
                int futaBaStatus = GetOrderData(stockMoveList); // ADD K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応
                 // 拠点間発注データにて抽出済み伝票を取得
                if (futaBaStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 拠点間発注データにて抽出済み伝票を取得
                    if (_orderDataDic != null && _orderDataDic.Count > 0)
                    {
                        customSerializeArrayList.Add(_orderDataDic);
                        // オプションセット
                        customSerializeArrayList.Add(this._opt_FuTaBa);
                    }
                }
                else
                {
                    return futaBaStatus;
                }
            }
            // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

            // リモーティング引渡オブジェクト
            object obj = customSerializeArrayList;

            // TODO:在庫移動削除処理
            //int status = this._iStockMoveDB.Delete(ref obj);
            int status = this._iStockMoveDB.LogicalDelete(ref obj);

            // 終了
            return status;
        }

        # endregion ■■　在庫移動データ削除処理　■■

        // ===================================================================================== //
        // ＜在庫移動　確定／入荷＞　登録    Write
        // ===================================================================================== //

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        # region ■■　在庫移動確定データ登録　■■

        /// <summary>
        /// 在庫移動確定データ登録
        /// </summary>
        public int WriteStockMoveFix ()
        {
            ArrayList StockMoveSlipNoList = new ArrayList();

            // 在庫移動データワークオブジェクト格納リスト
            ArrayList stockMoveList = new ArrayList();

            // 所属拠点取得
            GetBelongSection( _stockMoveInputInitAcs.StockMoveHeader.StockMvEmpCode );


            // 在庫移動データテーブルをワークオブジェクトに格納
            for ( int i = 0; i < _stockMoveDataTable.Count; i++ )
            {
                // バックアップテーブルと比較し、出荷フラグに変更があるようであれば追加する
                if ( _stockMoveDataTable[i].FixFlag != _stockMoveDataTableBackup[i].FixFlag )
                {
                    bool checkFlg = false;

                    for ( int cnt = 0; cnt < StockMoveSlipNoList.Count; cnt++ )
                    {
                        if ( Int32.Parse( StockMoveSlipNoList[cnt].ToString() ) == StockMoveDataTable[i].StockMoveSlipNo )
                        {
                            checkFlg = true;
                        }
                    }

                    if ( checkFlg == false )
                    {
                        // 移動伝票番号を登録
                        StockMoveSlipNoList.Add( StockMoveDataTable[i].StockMoveSlipNo );
                    }
                }
            }

            for ( int addCount = 0; addCount < StockMoveSlipNoList.Count; addCount++ )
            {
                for ( int i = 0; i < StockMoveDataTable.Count; i++ )
                {
                    // 伝票番号が同一のレコードを抽出
                    if ( Int32.Parse( StockMoveSlipNoList[addCount].ToString() ) == StockMoveDataTable[i].StockMoveSlipNo )
                    {
                        // 在庫移動ワークオブジェクト<引数：登録レコード、更新モード(1:新規 2:更新)、呼出処理(0:入力 1:確定 2:入荷)>
                        StockMoveWork stockMoveWork = CopyToStockMoveWorkFromDataRow( i, 2, 1 );

                        // リストに格納
                        stockMoveList.Add( stockMoveWork );
                    }
                }
            }

            // カスタムシリアライズアレイリスト生成
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // カスタムシリアライズアレイリストに在庫移動データ、在庫移動詳細データを格納
            customSerializeArrayList.Add( stockMoveList );

            // 対象となるデータがなかった場合
            if ( stockMoveList.Count == 0 )
            {
                return -1;
            }

            // リモーティング引渡オブジェクト
            object obj = customSerializeArrayList;

            string msg = "";

            // 在庫移動登録処理
            int status = this._iStockMoveDB.Write( ref obj, out msg );

            // 正常終了
            if ( status == 0 )
            {
                // 戻ってきたデータをテーブルに再格納
                customSerializeArrayList = (CustomSerializeArrayList)obj;

                // レスポンスデータを取得
                stockMoveList = (ArrayList)customSerializeArrayList[0];

                // 在庫移動テーブルを初期化
                _stockMoveDataTable.Rows.Clear();

            }
            return status;
        }

        # endregion
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        # region ■■　在庫移動入荷データ登録　■■

        /// <summary>
        /// 在庫移動入荷データ登録
        /// </summary>
        /// <br>Update Note: K2013/12/25 鄧潘ハン</br>
        /// <br>             フタバ個別拠点間発注ﾃﾞｰﾀより、入庫ﾃﾞｰﾀの作成することの対応</br>
        /// <br>Update Note: K2014/11/20 劉超</br>
        /// <br>             Redmine#44000 フタバ　在庫移動入力入荷確定処理のエラーの対応</br>
        public int WriteStockMoveArrival(out ArrayList stockMoveList)
        {
            ArrayList StockMoveSlipNoList = new ArrayList();

            // 在庫移動データワークオブジェクト格納リスト
            stockMoveList = new ArrayList();

            // 所属拠点取得
            GetBelongSection( _stockMoveInputInitAcs.StockMoveHeader.StockMvEmpCode );


            // 在庫移動データテーブルをワークオブジェクトに格納
            for ( int i = 0; i < _stockMoveDataTable.Count; i++ )
            {
                // 出庫倉庫、入庫倉庫が削除または論理削除されている場合は更新対象から外す
                //if ((this._stockMoveInputInitAcs.GetWarehouseName(_stockMoveDataTable[i].BfEnterWarehCode) == "") ||
                //    (this._stockMoveInputInitAcs.GetWarehouseName(_stockMoveDataTable[i].AfEnterWarehCode) == ""))
                //{
                //    continue;
                //}

                // バックアップテーブルと比較し、入荷フラグに変更があるようであれば追加する
                if ( _stockMoveDataTable[i].ArrivalFlag != _stockMoveDataTableBackup[i].ArrivalFlag )
                {
                    bool checkFlg = false;

                    for ( int cnt = 0; cnt < StockMoveSlipNoList.Count; cnt++ )
                    {
                        if ( Int32.Parse( StockMoveSlipNoList[cnt].ToString() ) == StockMoveDataTable[i].StockMoveSlipNo )
                        {
                            checkFlg = true;
                        }
                    }

                    if ( checkFlg == false )
                    {
                        // 移動伝票番号を登録
                        StockMoveSlipNoList.Add( StockMoveDataTable[i].StockMoveSlipNo );
                    }
                }
            }

            for ( int addCount = 0; addCount < StockMoveSlipNoList.Count; addCount++ )
            {
                for ( int i = 0; i < StockMoveDataTable.Count; i++ )
                {
                    // 出庫倉庫、入庫倉庫が削除または論理削除されている場合は更新対象から外す
                    //if ((this._stockMoveInputInitAcs.GetWarehouseName(StockMoveDataTable[i].BfEnterWarehCode) == "") ||
                    //    (this._stockMoveInputInitAcs.GetWarehouseName(StockMoveDataTable[i].AfEnterWarehCode) == ""))
                    //{
                    //    continue;
                    //}

                    // レコードが同一のレコードを抽出
                    if ( Int32.Parse( StockMoveSlipNoList[addCount].ToString() ) == StockMoveDataTable[i].StockMoveSlipNo )
                    {
                        // 在庫移動ワークオブジェクト<引数：登録レコード、更新モード(1:新規 2:更新)、呼出処理(0:入力 1:確定 2:入荷)>
                        // DEL 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ---------->>>>>
                        //StockMoveWork stockMoveWork = CopyToStockMoveWorkFromDataRow( i, 2, 2 );
                        // DEL 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ----------<<<<<
                        // ADD 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ---------->>>>>
                        bool isCanceled = false;
                        StockMoveWork stockMoveWork = CopyToStockMoveWorkFromDataRow(i, 2, 2, out isCanceled);

                        // HACK:入荷取消用の設定
                        if (isCanceled)
                        {
                            stockMoveWork.ArrivalGoodsDay = this._StockMoveHeader.ArrivalGoodsDay;
                            stockMoveWork.LogicalDeleteCode = 1;
                        }
                        // ADD 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ----------<<<<<

                        // リストに格納
                        stockMoveList.Add( stockMoveWork );
                    }
                }
            }

            // 商品連結データワーククラスリスト作成
            ArrayList saveGoodsUnitDataWorkList = CreateSaveGoodsUnitDataWorkListArrival(stockMoveList);

            // カスタムシリアライズアレイリスト生成
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // カスタムシリアライズアレイリストに在庫移動データ、在庫移動詳細データを格納
            customSerializeArrayList.Add( stockMoveList );

            // カスタムシリアライズアレイリストに商品連結データを追加
            if (saveGoodsUnitDataWorkList.Count != 0)
            {
                customSerializeArrayList.Add(saveGoodsUnitDataWorkList);
            }

            // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                //int futaBaStatus = GetOrderData(); // DEL K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応
                int futaBaStatus = GetOrderData(stockMoveList); // ADD K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応
                // 拠点間発注データにて抽出済み伝票を取得
                if (futaBaStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (_orderDataDic != null && _orderDataDic.Count > 0)
                    {
                        customSerializeArrayList.Add(_orderDataDic);
                        // オプションセット
                        customSerializeArrayList.Add(this._opt_FuTaBa);
                    }
                }
                else
                {
                    return futaBaStatus;
                }
            }
            // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<
            
            // 対象となるデータがなかった場合
            if ( stockMoveList.Count == 0 )
            {
                return -1;
            }

            // リモーティング引渡オブジェクト
            object obj = customSerializeArrayList;

            string msg = "";

            // TODO:在庫移動登録処理
            int status = this._iStockMoveDB.Write( ref obj, out msg );

            // 正常終了
            if ( status == 0 )
            {
                // 戻ってきたデータをテーブルに再格納
                customSerializeArrayList = (CustomSerializeArrayList)obj;

                // レスポンスデータを取得
                stockMoveList = (ArrayList)customSerializeArrayList[0];

                // 在庫移動テーブルを初期化
                _stockMoveDataTable.Rows.Clear();

                // ADD MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる ---------->>>>>
                // TODO:商品の検索結果(キャッシュ)をクリア
                this.GoodsUnitDataDic.Clear();
                // ADD MANTIS[0015261]の対応：商品情報が先頭のデータのままとなる ----------<<<<<
            }
            return status;
        }

        # endregion

        // ===================================================================================== //
        // ＜在庫移動／在庫移動確定／在庫移動入荷＞　検索   Search
        // ===================================================================================== //

        # region ■■　在庫移動伝票検索　■■

        /// <summary>
        /// 在庫移動伝票検索
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note : 2010/11/15　曹文傑　障害改良対応「２」の対応</br>
        /// <br>Update Note : 2012/05/22 wangf </br>
        /// <br>            : 10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        //public int SearchStockMove(ref ArrayList retStockMoveList, ref ArrayList retStockMoveExpList)
        public int SearchStockMove ( ref ArrayList retStockMoveList )
        {
            // 検索条件ワーククラス
            StockMoveSlipSearchCondWork stockMoveSlipSearchWork = new StockMoveSlipSearchCondWork();

            // 格納データの初期化
            retStockMoveList = new ArrayList();
            //retStockMoveExpList = new ArrayList();

            // 企業コード
            stockMoveSlipSearchWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 伝票番号
            if ( _StockMoveSlipSearchCond.StockMoveSlipNo != 0 )
            {
                stockMoveSlipSearchWork.StockMoveSlipNo = _StockMoveSlipSearchCond.StockMoveSlipNo;
            }

            // 移動指示担当者コード
            if ( _StockMoveSlipSearchCond.StockMvEmpCode != null && _StockMoveSlipSearchCond.StockMvEmpCode != "" )
            {
                stockMoveSlipSearchWork.StockMvEmpCode = _StockMoveSlipSearchCond.StockMvEmpCode;
            }

            // 出荷確定担当者コード
            if ( _StockMoveSlipSearchCond.ShipAgentCd != null && _StockMoveSlipSearchCond.ShipAgentCd != "" )
            {
                stockMoveSlipSearchWork.ShipAgentCd = _StockMoveSlipSearchCond.ShipAgentCd;
            }

            // 出庫拠点コード
            if ( _StockMoveSlipSearchCond.BfSectionCode != null && _StockMoveSlipSearchCond.BfSectionCode != "" )
            {
                stockMoveSlipSearchWork.BfSectionCode = _StockMoveSlipSearchCond.BfSectionCode;
            }

            // 出庫倉庫コード
            if ( _StockMoveSlipSearchCond.BfEnterWarehCode != null && _StockMoveSlipSearchCond.BfEnterWarehCode != "" )
            {
                stockMoveSlipSearchWork.BfEnterWarehCode = _StockMoveSlipSearchCond.BfEnterWarehCode;
            }

            // 入庫拠点コード
            if ( _StockMoveSlipSearchCond.AfSectionCode != null && _StockMoveSlipSearchCond.AfSectionCode != "" )
            {
                stockMoveSlipSearchWork.AfSectionCode = _StockMoveSlipSearchCond.AfSectionCode;
            }

            // 入庫倉庫コード
            if ( _StockMoveSlipSearchCond.AfEnterWarehCode != null && _StockMoveSlipSearchCond.AfEnterWarehCode != "" )
            {
                stockMoveSlipSearchWork.AfEnterWarehCode = _StockMoveSlipSearchCond.AfEnterWarehCode;
            }

            // 出荷予定日(開始)
            if ( _StockMoveSlipSearchCond.ShipmentScdlStDay.Date != new DateTime().Date )
            {
                stockMoveSlipSearchWork.ShipmentScdlStDay = _StockMoveSlipSearchCond.ShipmentScdlStDay;
            }

            // 出荷予定日(終了)
            if ( _StockMoveSlipSearchCond.ShipmentScdlEdDay.Date != new DateTime().Date )
            {
                stockMoveSlipSearchWork.ShipmentScdlEdDay = _StockMoveSlipSearchCond.ShipmentScdlEdDay;
            }

            // 出荷確定日(開始)
            if (_StockMoveSlipSearchCond.ShipmentFixStDay.Date != new DateTime().Date)
            {
                stockMoveSlipSearchWork.ShipmentFixStDay = _StockMoveSlipSearchCond.ShipmentFixStDay;
            }

            // 出荷確定日(終了)
            if ( _StockMoveSlipSearchCond.ShipmentFixEdDay.Date != new DateTime().Date )
            {
                stockMoveSlipSearchWork.ShipmentFixEdDay = _StockMoveSlipSearchCond.ShipmentFixEdDay;
            }

            // 表示条件
            if ( _StockMoveSlipSearchCond.MoveStatus > 0 )
            {
                int[] moveStatus = { _StockMoveSlipSearchCond.MoveStatus };
                stockMoveSlipSearchWork.MoveStatus = moveStatus;
            }
            else
            {
                int[] moveStatus = { 1, 2, 9 };

                stockMoveSlipSearchWork.MoveStatus = moveStatus;
            }

            // ---ADD 2009/06/04 ------------------------------------------>>>>>
            stockMoveSlipSearchWork.StockMoveFixCode = this._stockMoveInputInitAcs.StockMoveFixCode;
            if (this._stockMoveInputInitAcs.StockMoveFixCode == 1)
            {
                stockMoveSlipSearchWork.SlipDiv = 1;
            }
            else
            {
                // 2009.07.07 Del >>>
                ////出庫伝票　選択時
                //if (this._slipDiv == 0)
                //{
                //    stockMoveSlipSearchWork.SlipDiv = 1;        //1：出庫伝票
                //}
                ////入庫伝票　選択時
                //else
                //{
                //    stockMoveSlipSearchWork.SlipDiv = 2;        //2：入庫伝票
                //}
                // 2009.07.07 Del <<<
            }
            // ---ADD 2009/06/04 ------------------------------------------<<<<<
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            // 抽出条件クラスに呼び出し元機能区分を追加する。
            stockMoveSlipSearchWork.CallerFunction = this._StockMoveSlipSearchCond.CallerFunction;
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

            // 検索条件を格納
            object reqObj = stockMoveSlipSearchWork;

            // 結果オブジェクト
            object resObj = null;

            // 在庫移動データ検索
            int status = _iStockMoveDB.Search( out resObj, reqObj, 0, ConstantManagement.LogicalMode.GetData0 );

            if ( status == 0 )
            {
                // 成功時
                ArrayList retList = (ArrayList)resObj;
                retStockMoveList = (ArrayList)retList[0];
                // ---ADD 2010/11/15---------------->>>>>
                if (_prevStockMoveWorkList == null)
                {
                    _prevStockMoveWorkList = new ArrayList();
                }

                _prevStockMoveWorkList = retStockMoveList;
                // ---ADD 2010/11/15----------------<<<<<
            }
            return status;
        }

        # endregion

        #region DEL 2008/07/14 Partsman用に変更
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        # region ■■　在庫移動確定用在庫移動伝票検索　■■

        /// <summary>
        /// 在庫移動確定用在庫移動データ検索
        /// </summary>
        /// <returns>検索結果ステータス</returns>
        public int SearchStockMoveFix ()
        {
            // ヘッダ情報から検索条件を抽出
            StockMoveSlipSearchCondWork stockMoveSlipSearchWork = new StockMoveSlipSearchCondWork();

            // 企業コード
            stockMoveSlipSearchWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 出庫拠点コード
            if ( _StockMoveSlipSearchCond.BfSectionCode != null && _StockMoveSlipSearchCond.BfSectionCode != "" )
            {
                stockMoveSlipSearchWork.BfSectionCode = _StockMoveSlipSearchCond.BfSectionCode;
            }
            // 出庫倉庫コード
            if ( _StockMoveSlipSearchCond.BfEnterWarehCode != null && _StockMoveSlipSearchCond.BfEnterWarehCode != "" )
            {
                stockMoveSlipSearchWork.BfEnterWarehCode = _StockMoveSlipSearchCond.BfEnterWarehCode;
            }
            // 入庫拠点
            if ( _StockMoveSlipSearchCond.AfSectionCode != null && _StockMoveSlipSearchCond.AfSectionCode != "" )
            {
                stockMoveSlipSearchWork.AfSectionCode = _StockMoveSlipSearchCond.AfSectionCode;
            }
            // 入庫倉庫
            if ( _StockMoveSlipSearchCond.AfEnterWarehCode != null && _StockMoveSlipSearchCond.AfEnterWarehCode != "" )
            {
                stockMoveSlipSearchWork.AfEnterWarehCode = _StockMoveSlipSearchCond.AfEnterWarehCode;
            }
            // 移動指示担当者
            if ( _StockMoveSlipSearchCond.StockMvEmpCode != null && _StockMoveSlipSearchCond.StockMvEmpCode != "" )
            {
                stockMoveSlipSearchWork.StockMvEmpCode = _StockMoveSlipSearchCond.StockMvEmpCode;
            }
            // 伝票番号
            if ( _StockMoveSlipSearchCond.StockMoveSlipNo != 0 )
            {
                stockMoveSlipSearchWork.StockMoveSlipNo = _StockMoveSlipSearchCond.StockMoveSlipNo;
            }
            // 出荷予定日(開始)
            if ( _StockMoveSlipSearchCond.ShipmentScdlStDay.Date != new DateTime().Date )
            {
                stockMoveSlipSearchWork.ShipmentScdlStDay = _StockMoveSlipSearchCond.ShipmentScdlStDay;
            }
            // 出荷予定日(終了)
            if ( _StockMoveSlipSearchCond.ShipmentScdlEdDay != new DateTime().Date )
            {
                stockMoveSlipSearchWork.ShipmentScdlEdDay = _StockMoveSlipSearchCond.ShipmentScdlEdDay;
            }
            // 表示条件
            if ( _StockMoveSlipSearchCond.MoveStatus > 0 )
            {
                int[] moveStatus = { _StockMoveSlipSearchCond.MoveStatus };
                stockMoveSlipSearchWork.MoveStatus = moveStatus;
            }
            else
            {
                // 1:未出荷状態,2:移動中,9:入荷済
                int[] moveStatus = { 1, 2, 9 };
                stockMoveSlipSearchWork.MoveStatus = moveStatus;
            }

            // 検索条件を格納
            object reqObj = stockMoveSlipSearchWork;

            // 結果オブジェクト
            object resObj = null;

            // 在庫移動データ検索
            int status = _iStockMoveDB.Search( out resObj, reqObj, 0, ConstantManagement.LogicalMode.GetData0 );

            if ( status == 0 )
            {
                // 成功時
                ArrayList retList = (ArrayList)resObj;

                // 在庫移動データテーブルを初期化
                _stockMoveDataTable.Clear();

                // 在庫移動データテーブルバックアップを初期化
                _stockMoveDataTableBackup.Clear();

                // 取得したデータを在庫移動テーブルに格納
                this.CopyToDataTableFromStockMoveWorkList( retList );

                // 検索初期データ保持用データテーブルに格納
                backupFlg = true;
                this.CopyToDataTableFromStockMoveWorkList( retList );
                backupFlg = false;
            }
            return status;
        }

        # endregion
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 Partsman用に変更

        # region ■■　在庫移動入荷用在庫移動伝票検索　■■

        /// <summary>
        /// 在庫移動入荷用在庫移動データ検索
        /// </summary>
        /// <returns>検索結果ステータス</returns>
        public int SearchStockMoveArrival ()
        {
            // ヘッダ情報から検索条件を抽出
            StockMoveSlipSearchCondWork stockMoveSlipSearchWork = new StockMoveSlipSearchCondWork();

            // 企業コード
            stockMoveSlipSearchWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 出庫拠点コード
            if ( _StockMoveSlipSearchCond.BfSectionCode != null || _StockMoveSlipSearchCond.BfSectionCode != "" )
            {
                stockMoveSlipSearchWork.BfSectionCode = _StockMoveSlipSearchCond.BfSectionCode;
            }

            // 出庫倉庫コード
            if ( _StockMoveSlipSearchCond.BfEnterWarehCode != null || _StockMoveSlipSearchCond.BfEnterWarehCode != "" )
            {
                stockMoveSlipSearchWork.BfEnterWarehCode = _StockMoveSlipSearchCond.BfEnterWarehCode;
            }
            // 入庫拠点
            if ( _StockMoveSlipSearchCond.AfSectionCode != null || _StockMoveSlipSearchCond.AfSectionCode != "" )
            {
                stockMoveSlipSearchWork.AfSectionCode = _StockMoveSlipSearchCond.AfSectionCode;
            }

            // 入庫倉庫
            // 入庫倉庫はヘッダにて入力した入庫倉庫コードを格納する。
            if ( _StockMoveSlipSearchCond.AfEnterWarehCode != null && _StockMoveSlipSearchCond.AfEnterWarehCode != "" )
            {
                stockMoveSlipSearchWork.AfEnterWarehCode = _StockMoveSlipSearchCond.AfEnterWarehCode;
            }

            // 移動指示担当者
            if ( _StockMoveSlipSearchCond.StockMvEmpCode != null && _StockMoveSlipSearchCond.StockMvEmpCode != "" )
            {
                stockMoveSlipSearchWork.StockMvEmpCode = _StockMoveSlipSearchCond.StockMvEmpCode;
            }
            // 伝票番号
            if ( _StockMoveSlipSearchCond.StockMoveSlipNo != 0 )
            {
                stockMoveSlipSearchWork.StockMoveSlipNo = _StockMoveSlipSearchCond.StockMoveSlipNo;
            }
            // 出荷予定日(開始)
            if ( _StockMoveSlipSearchCond.ShipmentFixStDay.Date != new DateTime().Date )
            {
                stockMoveSlipSearchWork.ShipmentFixStDay = _StockMoveSlipSearchCond.ShipmentFixStDay;
            }
            // 出荷予定日(終了)
            if ( _StockMoveSlipSearchCond.ShipmentFixEdDay != new DateTime().Date )
            {
                stockMoveSlipSearchWork.ShipmentFixEdDay = _StockMoveSlipSearchCond.ShipmentFixEdDay;
            }
            // 表示条件
            if ( _StockMoveSlipSearchCond.MoveStatus > 0 )
            {
                int[] moveStatus = { _StockMoveSlipSearchCond.MoveStatus };
                stockMoveSlipSearchWork.MoveStatus = moveStatus;
            }
            else
            {
                int[] moveStatus = { 2, 9 };
                stockMoveSlipSearchWork.MoveStatus = moveStatus;
            }

            // ---ADD 2009/06/04 ------------------------------------------>>>>>
            stockMoveSlipSearchWork.StockMoveFixCode = this._stockMoveInputInitAcs.StockMoveFixCode;
            if (this._stockMoveInputInitAcs.StockMoveFixCode == 1)
            {
                stockMoveSlipSearchWork.SlipDiv = 2;
            }
            else
            {
                //ここを通る事は無い？
                //出庫伝票　選択時
                if (this._slipDiv == 0)
                {
                    stockMoveSlipSearchWork.SlipDiv = 1;        //1：出庫伝票
                }
                //入庫伝票　選択時
                else
                {
                    stockMoveSlipSearchWork.SlipDiv = 2;        //2：入庫伝票
                }
            }
            // ---ADD 2009/06/04 ------------------------------------------<<<<<

            // 検索条件を格納
            object reqObj = stockMoveSlipSearchWork;

            // 結果オブジェクト
            object resObj = null;

            // 在庫移動データ検索
            int status = _iStockMoveDB.Search( out resObj, reqObj, 0, ConstantManagement.LogicalMode.GetData0 );
            if ( status == 0 )
            {
                // 成功時
                ArrayList retList = (ArrayList)resObj;

                // 在庫移動データテーブルを初期化
                _stockMoveDataTable.Clear();
                // 在庫移動データテーブルバックアップを初期化
                _stockMoveDataTableBackup.Clear();

                // 取得したデータを在庫移動テーブルに格納
                this.CopyToDataTableFromStockMoveWorkList( retList );

                // 検索初期データ保持用データテーブルに格納
                backupFlg = true;
                this.CopyToDataTableFromStockMoveWorkList( retList );
                backupFlg = false;
            }
            return status;
        }

        # endregion

        // ===================================================================================== //
        // 共通処理部分
        // ===================================================================================== //

        # region ■■　初期設定　■■

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 初期化処理
        /// </summary>
        private void Clear ()
        {
            // 在庫移動データセット
            this._dataSet = new StockMoveInputDataSet();

            // 在庫移動データテーブル
            this._stockMoveDataTable = this._dataSet.StockMove;

            this.StockMoveDataTableBackup.Clear();

            this._stockMoveInputInitAcs.Clear();
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        /// <summary>
        /// 在庫移動明細データテーブル行初期設定処理
        /// </summary>
        public void StockMoveDetailRowInitialSetting ( int defaultRowCount )
        {
            this._stockMoveDataTable.BeginLoadData();
            // データテーブルの初期化
            this._stockMoveDataTable.Clear();

            // データテーブルバックアップの初期化
            this._stockMoveDataTableBackup.Clear();

            // 引数(defaultRowCout)分だけ初期に表示するレコードを作成する。
            for ( int i = 1; i <= defaultRowCount; i++ )
            {
                // 新しい在庫移動明細のレコードを追加する。
                StockMoveInputDataSet.StockMoveRow row = this._stockMoveDataTable.NewStockMoveRow();
                // 在庫移動伝票番号を格納
                row.StockMoveSlipNo = this._currentStockMoveSlipNo;
                // 在庫移動明細行番号を格納
                row.StockMoveRowNo = i;

                this._stockMoveDataTable.AddStockMoveRow( row );
            }
            this._stockMoveDataTable.EndLoadData();
        }

        # endregion

        # region ■■　在庫移動データ更新時チェック処理(確定データ、入荷データ存在チェック)　■■

        /// <summary>
        /// 在庫更新時の状態チェックを行います。
        /// </summary>
        /// <param name="stockMoveList">在庫移動データ</param>
        /// <returns>結果ステータス</returns>
        // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
        //private int CheckStockMove ( ArrayList stockMoveList, ArrayList stockMoveExpList )
        private int CheckStockMove (ArrayList stockMoveList)
        // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        {
            // 確定データや入荷済データの存在チェック
            foreach ( StockMoveWork stockMoveWorkRes in stockMoveList )
            {
                int moveStatus = stockMoveWorkRes.MoveStatus;
                int stockMoveFormal = stockMoveWorkRes.StockMoveFormal;

                // 倉庫移動の即入荷は無視する。
                if ( stockMoveFormal == 2 && moveStatus == 9 )
                {
                    return 0;
                }
                // 更新データ内に確定済データが存在する場合
                else if ( moveStatus == 2 )
                {
                    return -2;
                }
                // 更新データ内に入荷済データが存在する場合
                else if ( moveStatus == 9 )
                {
                    return -9;
                }
            }
            // 更新データ内の全てのレコードに確定済データや入荷済データが存在しない場合
            return 0;
        }

        # endregion

        # region ■■　各種変換処理　■■

        /// <summary>
        /// 現在の在庫移動データからワークオブジェクト変換処理
        /// </summary>
        /// <param name="index">移動在庫行番号</param>
        /// <param name="mode">更新モード</param>
        /// <param name="executeProg">呼出プログラム</param>
        /// <param name="isCanceled">入荷取消フラグ</param>
        /// <returns>在庫移動ワークオブジェクト</returns>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        // DEL 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ---------->>>>>
        //private StockMoveWork CopyToStockMoveWorkFromDataRow ( int index, int mode, int executeProg )
        // DEL 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ----------<<<<<
        // ADD 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ---------->>>>>
        private StockMoveWork CopyToStockMoveWorkFromDataRow ( int index, int mode, int executeProg, out bool isCanceled )
        // ADD 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ----------<<<<<
        {
            StockMoveWork stockMoveWork = new StockMoveWork();

            // 指定したレコードを取得する。
            StockMoveInputDataSet.StockMoveRow row = _stockMoveDataTable[index];
            // バックアップ側のレコードも取得
            StockMoveInputDataSet.StockMoveRow rowBack = _stockMoveDataTableBackup[index];

            // ADD 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ---------->>>>>
            // HACK:入荷取消を判定（MAZAI04100UA.cs MAZAI04100UA.StockArrivalGoodsInputSave() 2557行目 を参考）
            isCanceled = false;
            if (row.ArrivalFlag != rowBack.ArrivalFlag)
            {
                if (row.MoveStatus != 9)
                {
                    isCanceled = true;
                }
            }
            // ADD 2010/06/09 MANTIS対応[15261]：再入荷処理すると、在庫移動伝票が検索されなくなる ----------<<<<<

            // ヘッダー情報
            // 企業コード
            stockMoveWork.EnterpriseCode = row.EnterpriseCode;
            // 更新従業員コード
            stockMoveWork.UpdEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;

            // 在庫移動更新だった場合、ヘッダ情報を格納する。
            if ( mode == 2 || _stockMoveInputInitAcs.RegistMode == 1 )
            {
                try
                {
                    // 作成日時
                    stockMoveWork.CreateDateTime = row.CreateDateTime;
                    // 更新日時
                    stockMoveWork.UpdateDateTime = row.UpdateDateTime;
                    // GUID
                    stockMoveWork.FileHeaderGuid = row.FileHeaderGuid;
                    // 更新アセンブリID1
                    stockMoveWork.UpdAssemblyId1 = row.UpdAssemblyId1;
                    // 更新アセンブリID2
                    stockMoveWork.UpdAssemblyId2 = row.UpdAssemblyId2;
                    // 論理削除区分
                    stockMoveWork.LogicalDeleteCode = row.LogicalDeleteCode;
                }
                catch
                {
                    // 例外発生時は格納しない。
                }
            }

            // 新規登録時
            stockMoveWork.StockMoveFormal = row.StockMoveFormal;

            // 在庫移動伝票番号
            stockMoveWork.StockMoveSlipNo = row.StockMoveSlipNo;
            // 在庫移動行番号
            stockMoveWork.StockMoveRowNo = row.StockMoveRowNo;
            // メーカーコード
            stockMoveWork.GoodsMakerCd = StringToInt(row.GoodsMakerCd);
            // メーカー名
            stockMoveWork.MakerName = GetMakerName(stockMoveWork.GoodsMakerCd);
            // 商品コード
            stockMoveWork.GoodsNo = row.GoodsNo;
            // 商品名称
            stockMoveWork.GoodsName = row.GoodsName;
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            // 商品名称カナ
            stockMoveWork.GoodsNameKana = row.GoodsNameKana;
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
            // 更新拠点コード
            stockMoveWork.UpdateSecCd = row.UpdateSecCd;
            // 出庫拠点コード
            stockMoveWork.BfSectionCode = row.BfSectionCode;
            // 出庫拠点ガイド名称
            stockMoveWork.BfSectionGuideSnm = this._stockMoveInputInitAcs.GetSectionName(stockMoveWork.BfSectionCode);
            // 出庫倉庫コード
            stockMoveWork.BfEnterWarehCode = row.BfEnterWarehCode;
            // 出庫倉庫名称
            stockMoveWork.BfEnterWarehName = this._stockMoveInputInitAcs.GetWarehouseName(stockMoveWork.BfEnterWarehCode);
            // 入庫拠点コード
            stockMoveWork.AfSectionCode = row.AfSectionCode;
            // 入庫拠点ガイド名称
            stockMoveWork.AfSectionGuideSnm = row.AfSectionGuideNm;
            // 入庫倉庫コード
            stockMoveWork.AfEnterWarehCode = row.AfEnterWarehCode;
            // 入庫倉庫名称
            stockMoveWork.AfEnterWarehName = row.AfEnterWarehName;

            // 日付項目は「DBNull」時に例外が発生する可能性があるため、キャッチする。

            // 出荷予定日
            try
            {
                if (row.ShipmentScdlDay.Trim() == "")
                {
                    stockMoveWork.ShipmentScdlDay = new DateTime();
                }
                else
                {
                    string[] splitString = row.ShipmentScdlDay.Split('/');
                    stockMoveWork.ShipmentScdlDay = new DateTime(Int32.Parse(splitString[0]), Int32.Parse(splitString[1]), Int32.Parse(splitString[2]));
                }
            }
            catch
            {
                // 例外が発生した場合は格納しない。
            }

            // 出荷確定日
            try
            {
                if (row.ShipmentFixDay.Contains("/"))
                {
                    string[] splitString = row.ShipmentFixDay.Split('/');
                    stockMoveWork.ShipmentFixDay = new DateTime(Int32.Parse(splitString[0]), Int32.Parse(splitString[1]), Int32.Parse(splitString[2]));
                }
            }
            catch
            {
                // 例外が発生した場合は格納しない。
            }

            // 入荷日
            try
            {
                if (executeProg == 2 && row.ArrivalFlag != rowBack.ArrivalFlag)
                {
                    stockMoveWork.ArrivalGoodsDay = _StockMoveHeader.ArrivalGoodsDay;
                }
                else
                {
                    if (row.ArrivalGoodsDay.Contains("/"))
                    {
                        string[] splitString = row.ArrivalGoodsDay.Split('/');
                        stockMoveWork.ArrivalGoodsDay = new DateTime(Int32.Parse(splitString[0]), Int32.Parse(splitString[1]), Int32.Parse(splitString[2]));
                    }
                }
            }
            catch
            {
                // 例外が発生した場合は格納しない。
            }

            // 入力日
            stockMoveWork.InputDay = DateTime.Today;

            // 移動状態(0:移動対象外 1:未出荷状態 2:移動中 9:入荷済)
            if (row.ArrivalFlag == true)
            {
                stockMoveWork.MoveStatus = 9;
            }
            else
            {
                stockMoveWork.MoveStatus = 2;
                stockMoveWork.ArrivalGoodsDay = DateTime.MinValue;
            }
            // 在庫移動入力従業員コード
            stockMoveWork.StockMvEmpCode = row.StockMvEmpCode;
            // 在庫移動入力従業員名称
            stockMoveWork.StockMvEmpName = row.StockMvEmpName;
            // 出荷担当従業員コード
            stockMoveWork.ShipAgentCd = row.ShipAgentCd;
            // 出荷担当従業員名称
            stockMoveWork.ShipAgentNm = row.ShipAgentNm;
            // 引取担当者従業員コード
            if ( executeProg == 2 && row.ArrivalFlag != rowBack.ArrivalFlag )
            {
                stockMoveWork.ReceiveAgentCd = _StockMoveHeader.ReceiveAgentCd;
            }
            else
            {
                stockMoveWork.ReceiveAgentCd = row.ReceiveAgentCd;
            }
            // 引取担当者従業員名称
            if ( executeProg == 2 && row.ArrivalFlag != rowBack.ArrivalFlag )
            {
                stockMoveWork.ReceiveAgentNm = _StockMoveHeader.ReceiveAgentNm;
            }
            else
            {
                stockMoveWork.ReceiveAgentNm = row.ReceiveAgentNm;
            }

            // 伝票摘要
            stockMoveWork.Outline = row.Outline;
            // 倉庫備考1
            stockMoveWork.WarehouseNote1 = row.WarehouseNote1;
            // 更新営業所
            stockMoveWork.UpdateSecCd = row.UpdateSecCd;
            //---UPD 2011/04/11----------------------------------------->>>>>
            // 仕入先コード
            //stockMoveWork.SupplierCd = row.CustomerCode;// DEL 2011/04/11
            stockMoveWork.SupplierCd =  StringToInt(row.SupplierCd);
            // 仕入先略称
            //stockMoveWork.SupplierSnm = row.CustomerName.Trim() + row.CustomerName2.Trim();// DEL 2011/04/11
            stockMoveWork.SupplierSnm = row.SupplierSnm;
            //---UPD 2011/04/11-----------------------------------------<<<<<
            // 在庫区分
            stockMoveWork.StockDiv = row.StockDiv;
            // 仕入単価
            stockMoveWork.StockUnitPriceFl = ObjDoubleToDouble(row["StockUnitPriceFl"]);
            // 課税区分
            stockMoveWork.TaxationDivCd = row.TaxationDivCd;
            // 移動数
            stockMoveWork.MoveCount = row.MovingSupliStock + row.MovingTrustStock;
            // 在庫区分
            stockMoveWork.StockDiv = row.StockDiv;
            // 出庫棚番
            stockMoveWork.BfShelfNo = row.BfShelfNo;
            // 入庫棚番
            stockMoveWork.AfShelfNo = row.AfShelfNo;
            // ＢＬ商品コード
            stockMoveWork.BLGoodsCode = StringToInt(row.BLGoodsCode);
            // ＢＬ商品コード名称
            stockMoveWork.BLGoodsFullName = GetBLGoodsFullName(stockMoveWork.BLGoodsCode);
            // 定価
            stockMoveWork.ListPriceFl = row.ListPriceFl;
            // 移動金額
            stockMoveWork.StockMovePrice = row.MovingPrice;
            // 伝票発行済区分
            stockMoveWork.SlipPrintFinishCd = 1;
            // 在庫移動確定区分 
            stockMoveWork.StockMoveFixCode = this._stockMoveInputInitAcs.StockMoveFixCode;      //ADD 2009/06/04

            // --- ADD 三戸 2012/07/05 ---------->>>>>
            // 移動時在庫自動登録区分
            stockMoveWork.MoveStockAutoInsDiv = this._stockMoveInputInitAcs.MoveStockAutoInsDiv;
            // --- ADD 三戸 2012/07/05 ----------<<<<<

            return stockMoveWork;
        }

        /// <summary>
        /// 在庫移動ワークオブジェクトから在庫移動データテーブルに格納処理（全Row）
        /// </summary>
        /// <param name="stockMoveList">在庫移動検索結果リスト郡</param>
        private void CopyToDataTableFromStockMoveWorkList ( ArrayList stockMoveList )
        {
            // 在庫移動データ
            ArrayList stockMove = stockMoveList[0] as ArrayList;

            foreach ( StockMoveWork stockMoveWorkRet in stockMove )
            {
                string retMessage;
                Stock stock = new Stock();
                List<Stock> stockList;

                // 条件を格納
                StockSearchPara para = new StockSearchPara();
                para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //para.SectionCode = stockMoveWorkRet.AfSectionCode;
                para.GoodsMakerCd = stockMoveWorkRet.GoodsMakerCd;
                para.GoodsNo = stockMoveWorkRet.GoodsNo;
                para.WarehouseCode = stockMoveWorkRet.AfEnterWarehCode;

                int status = _searchStockAcs.Search(para, out stockList, out retMessage);
                if (status == 0)
                {
                    stock = stockList[0];
                }

                // 在庫移動データをテーブルに格納
                this.CopyToDataRowFromStockMoveWork( stockMoveWorkRet , stock);
            }
        }

        /// <summary>
        /// 在庫移動ワークオブジェクトから在庫移動データテーブル変換処理（１Row単位）
        /// </summary>
        /// <param name="stockMoveWorkRes">レスポンス在庫移動ワークオブジェクト</param>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void CopyToDataRowFromStockMoveWork ( StockMoveWork stockMoveWorkRes , Stock stock)
        {
            StockMoveInputDataSet.StockMoveRow row = null;

            // 新規レコードの追加
            if ( backupFlg == false )
            {
                row = this._stockMoveDataTable.NewStockMoveRow();
            }
            else if ( backupFlg == true )
            {
                row = this._stockMoveDataTableBackup.NewStockMoveRow();
            }

            // 作成日時(在庫移動データ)
            row.CreateDateTime = stockMoveWorkRes.CreateDateTime;
            // 更新日時(在庫移動データ)
            row.UpdateDateTime = stockMoveWorkRes.UpdateDateTime;
            // 企業コード(在庫移動データ)
            row.EnterpriseCode = stockMoveWorkRes.EnterpriseCode;
            // GUID(在庫移動データ)
            row.FileHeaderGuid = stockMoveWorkRes.FileHeaderGuid;
            // 更新従業員コード(在庫移動データ)
            row.UpdEmployeeCode = stockMoveWorkRes.UpdEmployeeCode;
            // 更新アセンブリID1(在庫移動データ)
            row.UpdAssemblyId1 = stockMoveWorkRes.UpdAssemblyId1;
            // 更新アセンブリID2(在庫移動データ)
            row.UpdAssemblyId2 = stockMoveWorkRes.UpdAssemblyId2;
            // 論理削除区分(在庫移動データ)
            row.LogicalDeleteCode = stockMoveWorkRes.LogicalDeleteCode;

            // 在庫移動形式
            row.StockMoveFormal = stockMoveWorkRes.StockMoveFormal;
            // 在庫移動伝票番号
            row.StockMoveSlipNo = stockMoveWorkRes.StockMoveSlipNo;
            // 在庫移動行番号
            row.StockMoveRowNo = stockMoveWorkRes.StockMoveRowNo;
            // メーカーコード
            if (stockMoveWorkRes.GoodsMakerCd == 0)
            {
                row.GoodsMakerCd = "";
            }
            else
            {
                row.GoodsMakerCd = stockMoveWorkRes.GoodsMakerCd.ToString().PadLeft(4, '0');
            }
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // メーカー名称
            row.MakerName = stockMoveWorkRes.MakerName;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            // 商品コード
            row.GoodsNo = stockMoveWorkRes.GoodsNo;
            // 商品名称
            row.GoodsName = stockMoveWorkRes.GoodsName;
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            // 商品名称カナ
            row.GoodsNameKana = stockMoveWorkRes.GoodsNameKana;
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
            // 更新拠点コード
            row.UpdateSecCd = stockMoveWorkRes.UpdateSecCd;
            // 出庫拠点コード
            row.BfSectionCode = stockMoveWorkRes.BfSectionCode;
            // 出庫拠点ガイド名称
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //row.BfSectionGuideNm = stockMoveWorkRes.BfSectionGuideNm;
            row.BfSectionGuideNm = stockMoveWorkRes.BfSectionGuideSnm;
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
            // 出庫倉庫コード
            row.BfEnterWarehCode = stockMoveWorkRes.BfEnterWarehCode;
            // 出庫倉庫名称
            row.BfEnterWarehName = stockMoveWorkRes.BfEnterWarehName;
            // 入庫拠点コード
            row.AfSectionCode = stockMoveWorkRes.AfSectionCode;
            // 入庫拠点ガイド名称
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //row.AfSectionGuideNm = stockMoveWorkRes.AfSectionGuideNm;
            row.AfSectionGuideNm = stockMoveWorkRes.AfSectionGuideSnm;
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
            // 入庫倉庫コード
            row.AfEnterWarehCode = stockMoveWorkRes.AfEnterWarehCode;
            // 入庫倉庫名称
            row.AfEnterWarehName = stockMoveWorkRes.AfEnterWarehName;

            // 出荷予定日
            if ( stockMoveWorkRes.ShipmentScdlDay == new DateTime() )
            {
                row.ShipmentScdlDay = "";
            }
            else
            {
                row.ShipmentScdlDay = stockMoveWorkRes.ShipmentScdlDay.ToString( "yyyy/MM/dd" );
            }

            // 出荷確定日
            if ( stockMoveWorkRes.ShipmentFixDay == new DateTime() )
            {
                row.ShipmentFixDay = "";
            }
            else
            {
                row.ShipmentFixDay = stockMoveWorkRes.ShipmentFixDay.ToString( "yyyy/MM/dd" );
            }
            // ADD 2010/02/19 MANTIS対応[15007]：入荷処理用に出荷時間を追加 ---------->>>>>
            // 出荷時間
            if (!string.IsNullOrEmpty(row.ShipmentFixDay))
            {
                row.ShipmentFixTime = row.CreateDateTime.ToString(TIME_FORMAT);    // 作成日時の時刻を設定
            }
            else
            {
                row.ShipmentFixTime = string.Empty;
            }
            // ADD 2010/02/19 MANTIS対応[15007]：入荷処理用に出荷時間を追加 ----------<<<<<

            // 入荷日
            if ( stockMoveWorkRes.ArrivalGoodsDay == new DateTime() )
            {
                row.ArrivalGoodsDay = "";
            }
            else
            {
                row.ArrivalGoodsDay = stockMoveWorkRes.ArrivalGoodsDay.ToString( "yyyy/MM/dd" );
            }

            // 移動状態
            row.MoveStatus = stockMoveWorkRes.MoveStatus;
            // 移動状態バックアップ
            row.MoveStatusView = stockMoveWorkRes.MoveStatus;
            // 在庫移動入力従業員コード
            row.StockMvEmpCode = stockMoveWorkRes.StockMvEmpCode;
            // 在庫移動入力従業員名称
            row.StockMvEmpName = stockMoveWorkRes.StockMvEmpName;
            // 出荷担当従業員コード
            row.ShipAgentCd = stockMoveWorkRes.ShipAgentCd;
            // 出荷担当従業員名称
            row.ShipAgentNm = stockMoveWorkRes.ShipAgentNm;
            // 引取担当従業員コード
            row.ReceiveAgentCd = stockMoveWorkRes.ReceiveAgentCd;
            // 引取担当従業員名称
            row.ReceiveAgentNm = stockMoveWorkRes.ReceiveAgentNm;
            // 伝票摘要
            row.Outline = stockMoveWorkRes.Outline;
            // 倉庫備考1
            row.WarehouseNote1 = stockMoveWorkRes.WarehouseNote1;
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            // 倉庫備考2
            row.WarehouseNote2 = stockMoveWorkRes.WarehouseNote2;
            // 倉庫備考3
            row.WarehouseNote3 = stockMoveWorkRes.WarehouseNote3;
            // 倉庫備考4
            row.WarehouseNote4 = stockMoveWorkRes.WarehouseNote4;
            // 倉庫備考5
            row.WarehouseNote5 = stockMoveWorkRes.WarehouseNote5;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            // 検索結果用行インデックス
            row.SearchIndexNumber = _stockMoveDataTable.Count + 1;

            // 更新営業所
            row.UpdateSecCd = stockMoveWorkRes.UpdateSecCd;
            // 入荷日
            row.ArrivalGoodsDay = stockMoveWorkRes.ArrivalGoodsDay.ToString( "yyyy/MM/dd" );
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //// 得意先コード
            //row.CustomerCode = stockMoveWorkRes.CustomerCode;
            //// 得意先名称１
            //row.CustomerName = stockMoveWorkRes.CustomerName;
            //// 得意先名称２
            //row.CustomerName2 = stockMoveWorkRes.CustomerName2;
            // 仕入先コード
            row.CustomerCode = stockMoveWorkRes.SupplierCd;
            // 仕入先略称
            row.CustomerName = stockMoveWorkRes.SupplierSnm;
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
            // 在庫区分
            row.StockDiv = stockMoveWorkRes.StockDiv;
            // 仕入単価
            row.StockUnitPriceFl = stockMoveWorkRes.StockUnitPriceFl;
            // 変更前仕入単価
            row.BfStockUnitPriceFl = stockMoveWorkRes.StockUnitPriceFl;
            // 移動金額
            row.MovingPrice = stockMoveWorkRes.StockMovePrice;

            // 課税区分
            row.TaxationDivCd = stockMoveWorkRes.TaxationDivCd;

            // 移動数
            if ( row.StockDiv == 0 )
            {
                // 移動数（仕：自社）
                row.MovingSupliStock = stockMoveWorkRes.MoveCount;
                row.BfMovingSupliStock = stockMoveWorkRes.MoveCount;
                row.MovingTrustStock = 0;
            }
            else
            {
                // 移動数（受：受託）
                row.MovingSupliStock = 0;
                row.BfMovingSupliStock = 0;
                row.MovingTrustStock = stockMoveWorkRes.MoveCount;
            }

            // 入荷済
            if (row.MoveStatus == 9)
            {
                // 入庫後数
                double afAfterMoveCount = stock.ShipmentPosCnt;
                row.AfAfterMoveCount = afAfterMoveCount.ToString("N");

                // 入庫前数
                double afBeforeMoveCount = afAfterMoveCount - stockMoveWorkRes.MoveCount;
                row.AfBeforeMoveCount = afBeforeMoveCount.ToString("N");
            }
            // 未入荷
            else
            {
                // 入庫前数
                double afBeforeMoveCount = stock.ShipmentPosCnt;
                row.AfBeforeMoveCount = afBeforeMoveCount.ToString("N");

                // 入庫後数
                double afAfterMoveCount = afBeforeMoveCount + stockMoveWorkRes.MoveCount;
                row.AfAfterMoveCount = afAfterMoveCount.ToString("N");
            }

            // 出庫棚番
            row.BfShelfNo = stockMoveWorkRes.BfShelfNo;
            // 入庫棚番
            //row.AfShelfNo = stockMoveWorkRes.AfShelfNo;
            row.AfShelfNo = stock.WarehouseShelfNo;
            
            // ＢＬ商品コード
            if (stockMoveWorkRes.BLGoodsCode == 0)
            {
                row.BLGoodsCode = "";
            }
            else
            {
                row.BLGoodsCode = stockMoveWorkRes.BLGoodsCode.ToString().PadLeft(5, '0');
            }
            //---ADD 2011/04/11----------------------------------------------------------->>>>>
            //仕入先
            if (stockMoveWorkRes.SupplierCd == 0)
            {
                row.SupplierCd = "";
            }
            else
            {
                row.SupplierCd = stockMoveWorkRes.SupplierCd.ToString().PadLeft(6, '0');
            }
            row.SupplierSnm = stockMoveWorkRes.SupplierSnm;
            //---ADD 2011/04/11-----------------------------------------------------------<<<<<
            //// ＢＬ商品コード枝番
            //row.BLGoodsCdDerivedNo = stockMoveWorkRes.BLGoodsCdDerivedNo;
            // ＢＬ商品コード名称
            row.BLGoodsFullName = GetBLGoodsFullName(stockMoveWorkRes.BLGoodsCode);
            // 定価
            row.ListPriceFl = stockMoveWorkRes.ListPriceFl;

            // 制御項目

            // 在庫移動確定フラグ
            if ( row.MoveStatus == 2 || row.MoveStatus == 9 )
            {
                row.FixFlag = true;
            }

            // 在庫移動入荷フラグ
            if ( row.MoveStatus == 9 )
            {
                row.ArrivalFlag = true;
            }

            // 検索用インデックス
            row.SearchIndexNumber = _stockMoveDataTable.Count + 1;

            if ( backupFlg == false )
            {
                _stockMoveDataTable.AddStockMoveRow( row );
            }
            else if ( backupFlg == true )
            {
                _stockMoveDataTableBackup.AddStockMoveRow( row );
            }
        }

        # endregion

        # region ■■　グリッドデータ操作処理　■■

        /// <summary>
        /// 在庫移動明細データテーブルRowStatus列初期化処理
        /// </summary>
        public void InitializeStockDetailRowStatusColumn ()
        {
            StockMoveInputDataSet.StockMoveRow[] rows = (StockMoveInputDataSet.StockMoveRow[])this._stockMoveDataTable.Select( this._stockMoveDataTable.RowStatusColumn.ColumnName + " <> " + CODE_ROWSTATUS_NORMAL.ToString() );

            this._stockMoveDataTable.BeginLoadData();
            foreach ( StockMoveInputDataSet.StockMoveRow row in rows )
            {
                row.RowStatus = 0;
            }
            this._stockMoveDataTable.EndLoadData();
        }

        /// <summary>
        /// コピー在庫移動明細行存在チェック処理
        /// </summary>
        /// <returns>true:コピーデータが存在する false:存在しない</returns>
        public bool ExistCopyStockMoveDetailRow ()
        {
            object value = this._stockMoveDataTable.Compute( "COUNT(" + this._stockMoveDataTable.RowStatusColumn.ColumnName + ")", this._stockMoveDataTable.RowStatusColumn.ColumnName + " <> " + CODE_ROWSTATUS_NORMAL.ToString() );
            if ( value is System.DBNull ) return false;

            int count = (int)value;

            if ( count > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 在庫移動明細行クリア処理
        /// </summary>
        /// <param name="row">在庫移動明細データテーブル行クラス</param>
        private void ClearStockMoveRow ( StockMoveInputDataSet.StockMoveRow row )
        {
            if ( row == null ) return;

            row.GoodsNo = "";
            row.GoodsName = "";
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            row.GoodsNameKana = "";
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<
            row.MovingSupliStock = 0;
            row.BfMovingSupliStock = 0;
            row.MovingTrustStock = 0;
            row.BfEnterWarehName = "";
            row.RowStatus = CODE_ROWSTATUS_NORMAL;
        }

        /// <summary>
        /// 在庫移動明細行追加処理
        /// </summary>
        public void AddStockDetailRow ()
        {
            int rowCount = this._stockMoveDataTable.Rows.Count;

            StockMoveInputDataSet.StockMoveRow row = this._stockMoveDataTable.NewStockMoveRow();
            // 更新モードだった場合
            if ( _stockMoveInputInitAcs.RegistMode == 1 )
            {
                row.StockMoveSlipNo = _stockMoveDataTable[0].StockMoveSlipNo;
            }
            else
            {
                row.StockMoveSlipNo = this._currentStockMoveSlipNo;
            }

            row.StockMoveRowNo = rowCount + 1;
            this._stockMoveDataTable.AddStockMoveRow( row );
        }

        /// <summary>
        /// 在庫移動明細データテーブルRowStatus列値設定処理
        /// </summary>
        /// <param name="stockRowNoList">在庫移動明細行番号リスト</param>
        /// <param name="rowStatus">RowStatus値</param>
        public void SetStockDetailRowStatusColumn ( List<int> stockRowNoList, int rowStatus )
        {
            //this._stockMoveDataTable.BeginLoadData();
            //foreach (int stockRowNo in stockRowNoList)
            //{
            //    StockMoveInputDataSet.StockMoveRow row = this._stockMoveDataTable.FindByStockMoveSlipNoStockMoveRowNoStockMoveExpNum(this._currentStockMoveSlipNo, stockRowNo);
            //    if (row.GoodsName == "") continue;

            //    row.RowStatus = rowStatus;
            //}
            //this._stockMoveDataTable.EndLoadData();
        }

        /// <summary>
        /// 在庫移動明細行挿入処理
        /// </summary>
        /// <param name="insertIndex">挿入行Index</param>
        public void InsertStockDetailRow ( int insertIndex )
        {
            this.InsertStockDetailRow( insertIndex, 1 );
        }

        /// <summary>
        /// 在庫移動明細行挿入処理（オーバーロード）
        /// </summary>
        /// <param name="insertIndex">挿入行Index</param>
        /// <param name="line">挿入段数</param>
        public void InsertStockDetailRow ( int insertIndex, int line )
        {
            //int lastRowIndex = this._stockMoveDataTable.Rows.Count - 1;

            //// 在庫移動明細行追加処理
            //for (int i = 0; i < line; i++)
            //{
            //    this.AddStockDetailRow();
            //}

            //// 最終行から挿入対象行までの行情報を指定段ずつ下にコピーする
            //this._stockMoveDataTable.BeginLoadData();
            //for (int i = lastRowIndex; i >= insertIndex; i--)
            //{
            //    StockMoveInputDataSet.StockMoveRow sourceRow = this._stockMoveDataTable.FindByStockMoveSlipNoStockMoveRowNoStockMoveExpNum(this._stockMoveDataTable[i].StockMoveSlipNo, this._stockMoveDataTable[i].StockMoveRowNo, _stockMoveDataTable[i].StockMoveExpNum);
            //    StockMoveInputDataSet.StockMoveRow targetRow = this._stockMoveDataTable.FindByStockMoveSlipNoStockMoveRowNoStockMoveExpNum(this._stockMoveDataTable[i].StockMoveSlipNo, this._stockMoveDataTable[i + line].StockMoveRowNo,_stockMoveDataTable[i].StockMoveExpNum);

            //    //// 在庫移動明細コピー
            //    this.CopyStockMoveRow(sourceRow, targetRow);

            //}

            //// 挿入対象行をクリアする
            //StockMoveInputDataSet.StockMoveRow clearRow = this._stockMoveDataTable.FindByStockMoveSlipNoStockMoveRowNoStockMoveExpNum(this._stockMoveDataTable[insertIndex].StockMoveSlipNo, this._stockMoveDataTable[insertIndex].StockMoveRowNo,_stockMoveDataTable[insertIndex].StockMoveExpNum);
            //this.ClearStockMoveRow(clearRow);
            //this._stockMoveDataTable.EndLoadData();
        }

        ///// <summary>
        ///// 在庫移動明細行コピー処理
        ///// </summary>
        ///// <param name="sourceRow">コピー元在庫移動明細データテーブル行クラス</param>
        ///// <param name="targetRow">コピー先在庫移動明細データテーブル行クラス</param>
        //private void CopyStockMoveRow ( StockMoveInputDataSet.StockMoveRow sourceRow, StockMoveInputDataSet.StockMoveRow targetRow )
        //{
        //    if ( ( sourceRow == null ) || ( targetRow == null ) ) return;

        //    //targetRow.StockMoveSlipNo = sourceRow.StockMoveSlipNo;
        //    //targetRow.StockMoveRowNo = sourceRow.StockMoveRowNo;
        //    // 在庫移動形式
        //    targetRow.StockMoveFormal = sourceRow.StockMoveFormal;
        //    // メーカーコード
        //    targetRow.GoodsNo = sourceRow.GoodsNo;
        //    // メーカー名称
        //    targetRow.GoodsName = sourceRow.GoodsName;
        //    // 商品コード
        //    targetRow.GoodsNo = sourceRow.GoodsNo;
        //    // 商品名称
        //    targetRow.GoodsName = sourceRow.GoodsName;
        //    // 更新拠点コード
        //    targetRow.UpdateSecCd = sourceRow.UpdateSecCd;
        //    // 出庫拠点コード
        //    targetRow.BfSectionCode = sourceRow.BfSectionCode;
        //    // 出庫拠点ガイド名称
        //    targetRow.BfSectionGuideNm = sourceRow.BfSectionGuideNm;
        //    // 出庫倉庫コード
        //    targetRow.BfEnterWarehCode = sourceRow.BfEnterWarehCode;
        //    // 出庫倉庫名称
        //    targetRow.BfEnterWarehName = sourceRow.BfEnterWarehName;
        //    // 入庫拠点コード
        //    targetRow.AfSectionCode = sourceRow.AfSectionCode;
        //    // 入庫拠点ガイド名称
        //    targetRow.AfSectionGuideNm = sourceRow.AfSectionGuideNm;
        //    // 入庫倉庫コード
        //    targetRow.AfEnterWarehCode = sourceRow.AfEnterWarehCode;
        //    // 入庫倉庫名称
        //    targetRow.AfEnterWarehName = sourceRow.AfEnterWarehName;

        //    // 日付項目に関しては「DBNull」の場合は例外が発生する可能性があるのでキャッチする。

        //    // 出荷予定日
        //    try
        //    {
        //        targetRow.ShipmentScdlDay = sourceRow.ShipmentScdlDay;
        //    }
        //    catch
        //    {
        //        // 例外が発生した場合は格納しない。
        //    }

        //    // 出荷確定日
        //    try
        //    {
        //        targetRow.ShipmentFixDay = sourceRow.ShipmentFixDay;
        //    }
        //    catch
        //    {
        //        // 例外が発生した場合は格納しない。
        //    }

        //    // 入荷日
        //    try
        //    {
        //        targetRow.ArrivalGoodsDay = sourceRow.ArrivalGoodsDay;
        //    }
        //    catch
        //    {
        //        // 例外が発生した場合は格納しない。
        //    }

        //    // 移動状態
        //    targetRow.MoveStatus = sourceRow.MoveStatus;
        //    // 在庫移動入力従業員コード
        //    targetRow.StockMvEmpCode = sourceRow.StockMvEmpCode;
        //    // 在庫移動入力従業員名称
        //    targetRow.StockMvEmpName = sourceRow.StockMvEmpName;
        //    // 出荷担当従業員コード
        //    targetRow.ShipAgentCd = sourceRow.ShipAgentCd;
        //    // 出荷担当従業員名称
        //    targetRow.ShipAgentNm = sourceRow.ShipAgentNm;
        //    // 移動中仕入在庫数
        //    targetRow.MovingSupliStock = sourceRow.MovingSupliStock;
        //    // 移動中受託在庫数
        //    targetRow.MovingTrustStock = sourceRow.MovingTrustStock;
        //    // 引取担当従業員コード
        //    targetRow.ReceiveAgentCd = sourceRow.ReceiveAgentCd;
        //    // 引取担当従業員名称
        //    targetRow.ReceiveAgentNm = sourceRow.ReceiveAgentNm;
        //    // 伝票摘要
        //    targetRow.Outline = sourceRow.Outline;
        //    // 倉庫備考1
        //    targetRow.WarehouseNote1 = sourceRow.WarehouseNote1;
        //    /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        //    // 倉庫備考2
        //    targetRow.WarehouseNote2 = sourceRow.WarehouseNote2;
        //    // 倉庫備考3
        //    targetRow.WarehouseNote3 = sourceRow.WarehouseNote3;
        //    // 倉庫備考4
        //    targetRow.WarehouseNote4 = sourceRow.WarehouseNote4;
        //    // 倉庫備考5
        //    targetRow.WarehouseNote5 = sourceRow.WarehouseNote5;
        //    // 仕入在庫残数
        //    targetRow.SlipRemainCount = sourceRow.SlipRemainCount;
        //       --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        //    // 受託在庫残数
        //    targetRow.TrustRemainCount = sourceRow.TrustRemainCount;
        //    // 単価
        //    targetRow.StockUnitPriceFl = sourceRow.StockUnitPriceFl;
        //    // 移動金額
        //    targetRow.MovingPrice = sourceRow.MovingPrice;
        //    // 行ステータス
        //    targetRow.RowStatus = CODE_ROWSTATUS_NORMAL;
        //}

        /// <summary>
        /// 在庫移動明細行削除可能チェック処理
        /// </summary>
        /// <param name="stockMoveRowNoList">削除行StockRowNoリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>true:行削除可能 false:行削除不可</returns>
        public bool CanDeleteStockMoveDetailRow ( List<int> stockMoveRowNoList, out string message )
        {
            message = "";
            return true;
        }

        /// <summary>
        /// 在庫移動明細行削除処理
        /// </summary>
        /// <param name="stockMoveRowNoList">削除行StockRowNoリスト</param>
        public void DeleteStockMoveDetailRow ( List<int> stockMoveRowNoList )
        {
            this.DeleteStockMoveDetailRow( stockMoveRowNoList, false );
        }

        /// <summary>
        /// 在庫移動明細行削除処理
        /// </summary>
        /// <param name="stockMoveRowNoList">削除行StockRowNoリスト</param>
        /// <param name="isRowCountChange">true:行数を変更する false:行数を変更するは変更しない</param>
        public void DeleteStockMoveDetailRow ( List<int> stockMoveRowNoList, bool isRowCountChange )
        {
            Hashtable grossMapEx = new Hashtable();

            int stockMoveSlipNo = 0;

            this._stockMoveDataTable.BeginLoadData();
            foreach ( int stockMoveRowNo in stockMoveRowNoList )
            {
                foreach ( StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable )
                {
                    if ( row.StockMoveRowNo == stockMoveRowNo )
                    {
                        // 削除したレコードの伝票番号を保持
                        stockMoveSlipNo = row.StockMoveSlipNo;
                        // 対象レコードを削除
                        this._stockMoveDataTable.RemoveStockMoveRow( row );

                        break;
                    }
                }

            }

            this._stockMoveDataTable.EndLoadData();

            // 在庫移動データテーブルStockRowNo列初期化処理(再採番処理<抜けレコードを無くす>)
            this.InitializeStockMoveDetailStockRowNoColumn();

            if ( !isRowCountChange )
            {
                // 削除した分だけ新規に行を追加する
                for ( int i = 0; i < stockMoveRowNoList.Count; i++ )
                {
                    this.AddStockDetailRow();
                }
            }
        }

        /// <summary>
        /// 在庫移動明細データテーブルStockRowNo列初期化処理
        /// </summary>
        public void InitializeStockMoveDetailStockRowNoColumn ()
        {
            this._stockMoveDataTable.BeginLoadData();
            for ( int i = 0; i < this._stockMoveDataTable.Rows.Count; i++ )
            {
                this._stockMoveDataTable[i].StockMoveRowNo = i + 1;
            }
            this._stockMoveDataTable.EndLoadData();
        }

        /// <summary>
        /// コピー在庫移動明細行番号取得処理
        /// </summary>
        /// <returns>行番号リスト</returns>
        public List<int> GetCopyStockMoveDetailRowNo ()
        {
            StockMoveInputDataSet.StockMoveRow[] rows = (StockMoveInputDataSet.StockMoveRow[])this._stockMoveDataTable.Select( this._stockMoveDataTable.RowStatusColumn.ColumnName + " <> " + CODE_ROWSTATUS_NORMAL.ToString() );

            if ( ( rows != null ) && ( rows.Length > 0 ) )
            {
                List<int> stockRowNoList = new List<int>();
                foreach ( StockMoveInputDataSet.StockMoveRow row in rows )
                {
                    stockRowNoList.Add( row.StockMoveRowNo );
                }

                return stockRowNoList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 在庫移動明細行貼り付け処理
        /// </summary>
        /// <param name="copyStockRowNoList">コピー元行番号リスト</param>
        /// <param name="pasteIndex">貼り付け行Index</param>
        public void PasteStockMoveDetailRow ( List<int> copyStockRowNoList, int pasteIndex )
        {
            this._stockMoveDataTable.BeginLoadData();
            int index = 0;
            List<int> cutStockRowNoList = new List<int>();

            for ( int cnt = pasteIndex; cnt < pasteIndex + copyStockRowNoList.Count; cnt++ )
            {
                if ( cnt >= this._stockMoveDataTable.Count )
                {
                    this.AddStockDetailRow();
                }

                index++;
            }

            this._stockMoveDataTable.EndLoadData();
        }

        /// <summary>
        /// 入力データ同一チェック処理
        /// </summary>
        /// <returns>true:変更なし false:変更あり</returns>
        public bool EqualsInputData ()
        {
            return true;
        }

        ///// <summary>
        ///// データテーブル内の出荷数チェック
        ///// </summary>
        ///// <returns>True: チェックOK False: エラー</returns>
        //private bool DataTableCountCheck ()
        //{
        //    foreach ( StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable )
        //    {
        //        if (row.GoodsNo.Trim() != "")
        //        {
        //            double movingSupliStock;
        //            try
        //            {
        //                movingSupliStock = Convert.ToDouble(row.MovingSupliStock);
        //            }
        //            catch
        //            {
        //                return (false);
        //            }
        //            if (movingSupliStock == 0 && row.MovingTrustStock == 0)
        //            {
        //                return (false);
        //            }
        //        }
        //        //if ( row.GoodsNo.Trim() != "" && row.MovingSupliStock == 0 && row.MovingTrustStock == 0 )
        //        //{
        //        //    return false;
        //        //}
        //    }
        //    return true;
        //}

        /// <summary>
        /// 倉庫移動チェック
        /// </summary>
        /// <returns>true:同一倉庫が存在する false:同一倉庫は存在しない</returns>
        private bool warehouseCheck ()
        {
            foreach ( StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable )
            {
                if ( ( row.BfSectionCode.Trim() == _StockMoveHeader.AfSectionCode.Trim() ) &&
                    ( row.BfEnterWarehCode.Trim() != "" && row.BfEnterWarehCode.Trim() == _StockMoveHeader.AfEnterWarehCode.Trim() ) )
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 商品マスタユーザーチェック
        /// </summary>
        /// <returns>true:商品マスタ(ユーザー) false:商品マスタ(提供)</returns>
        private bool goodsUnitDataCheck()
        {
            foreach (StockMoveInputDataSet.StockMoveRow row in _stockMoveDataTable)
            {
                // 提供区分
                if (row.OfferKubun != 0)
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// メーカーコード存在チェック
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>true:メーカーコードが存在する false:メーカーコードは存在しない</returns>
        public bool makerCodeCheck(int makerCode)
        {
            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// BL商品コード存在チェック
        /// </summary>
        /// <param name="blGoodsCode">BL商品コード</param>
        /// <returns>true:BL商品コードが存在する false:BL商品コードは存在しない</returns>
        public bool blGoodsCodeCheck(int blGoodsCode)
        {
            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        
        //---ADD 2011/04/11----------------------------------------------------------->>>>>
        /// <summary>
        /// 仕入先コード存在チェック
        /// </summary>
        /// <param name="blGoodsCode">仕入先コード</param>
        /// <returns>true:仕入先コードが存在する false:仕入先コードは存在しない</returns>
        /// <remarks>
        /// <br>Note　　　  : 明細に仕入先を追加する。</br>
        /// <br>Programmer  : 鄧潘ハン</br>
        /// <br>Date        : 2011/04/11</br>
        /// </remarks>
        public bool SupplierCdCheck(int SupplierCd)
        {
            if (this._supplierAcsUMntDic.ContainsKey(SupplierCd))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        //---ADD 2011/04/11----------------------------------------------------------->>>>>
        # endregion

        # region ■■ 端数処理 ■■
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <returns>四捨五入されたdouble</returns>
        private static Int64 Round( double parameter )
        {
            // 整数部　四捨五入
            return (Int64)Round( parameter, 0, 5 );
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <param name="digits">小数点以下の有効桁数</param>
        /// <returns>四捨五入されたdouble</returns>
        public static double Round( double parameter, int digits )
        {
            // 四捨五入
            return Round( parameter, digits, 5 );
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <param name="digits">小数点以下の有効桁数</param>
        /// <param name="divide">切り上げる境界の値 1～9　(ex. 5→四捨五入)</param>
        /// <returns>四捨五入されたdouble</returns>
        public static double Round( double parameter, int digits, int divide )
        {
            decimal param = (decimal)parameter;
            decimal dCoef = (decimal)Math.Pow( 10, digits );
            decimal dDiv = 1.0m - ((decimal)divide / 10);

            if ( param > 0 )
            {
                // 0.5を足して「＋のときの切り捨て」（ゼロに近づける）
                param = Math.Floor( (param * dCoef) + dDiv ) / dCoef;
            }
            else
            {
                // -0.5を足して「－のときの切り捨て」（ゼロに近づける）
                param = Math.Ceiling( (param * dCoef) - dDiv ) / dCoef;
            }
            return (double)param;
        }
        # endregion ■■ 端数処理 ■■

        # region ■■ 所属拠点取得 ■■
        /// <summary>
        /// 所属拠点取得
        /// </summary>
        private void GetBelongSection( string employeeCode )
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.Read( out employee, LoginInfoAcquisition.EnterpriseCode, employeeCode );
            if ( status == 0 )
            {
                _belongSectionCode = employee.BelongSectionCode;
                _belongSectionName = employee.BelongSectionName;
            }
            else
            {
                // 取得できなかった場合はログイン拠点
                _belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                _belongSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
            }
        }
        # endregion ■■ 所属拠点取得 ■■


        # region ■ 商品読み込み ■
        /// <summary>
        /// 商品情報読み込み
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="sectionCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <returns>STATUS</returns>
        public int ReadGoods( out GoodsUnitData goodsUnitData, string sectionCode, int goodsMakerCd, string goodsNo )
        {
            // 対象の拠点コードが異なる場合は再度初期化処理を行う
            if ( sectionCode != _goodsAcsInitializeSectionCode )
            {
                _goodsAcs = new GoodsAcs();
                string msg;
                _goodsAcs.SearchInitial( LoginInfoAcquisition.EnterpriseCode, sectionCode, out msg );
            }

            // 商品読み込み
            return _goodsAcs.Read( LoginInfoAcquisition.EnterpriseCode, sectionCode, goodsMakerCd, goodsNo, out goodsUnitData );
        }

        #region DEL 2008/07/14 使用していないのでコメントアウト
        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫情報読み込み
        /// </summary>
        /// <param name="stockExpansion"></param>
        /// <param name="sectionCode"></param>
        /// <param name="warehouseCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <returns>STATUS</returns>
        public int ReadStock( out StockExpansion stockExpansion, string sectionCode, string warehouseCode, int goodsMakerCd, string goodsNo )
        {
            stockExpansion = null;

            StockSearchPara para = new StockSearchPara();
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            para.SectionCode = sectionCode;
            para.WarehouseCode = warehouseCode;
            para.GoodsMakerCd = goodsMakerCd;
            para.GoodsNo = goodsNo;

            List<StockExpansion> stockList;
            string msg;
            int status = _searchStockAcs.Search( para, out stockList, out msg );

            if ( status == 0 )
            {
                if ( stockList != null && stockList.Count > 0 )
                {
                    stockExpansion = stockList[0];
                }
            }
            return status;
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/14 使用していないのでコメントアウト

        # endregion ■ 商品読み込み ■

        //----- ADD K2013/09/11 田建委 ---------->>>>>
        #region ■フタバ売上移動出力データの取得■
        /// <summary>
        /// フタバ売上移動出力データのチェック
        /// </summary>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : フタバ売上移動出力データをチェックする。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2013/09/11</br>
        /// <br>Update Date: K2013/10/10 田建委</br>
        /// <br>           : フタバ個別対応</br>
        /// <br>           : Redmine#40626 フタバテキスト変換抽出済判断処理を動的に呼出す様に修正。</br>
        /// </remarks>
        public int CheckFTStockMoveData(int stockMoveSlipNo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            try
            {
                string enterPriseCode = LoginInfoAcquisition.EnterpriseCode;

                //----- DEL K2013/10/10 田建委 Redmine#40626 --------------->>>>>
                //this._iFuTaBaStockMoveJoinWorkDB = (IFuTaBaStockMoveJoinWorkDB)MediationFuTaBaStockMoveJoinResultDB.GetFuTaBaStockMoveJoinWorkDB();

                //object salesMoveResultWork = null;
                //status = this._iFuTaBaStockMoveJoinWorkDB.Search(out salesMoveResultWork, enterPriseCode, stockMoveSlipNo);

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                //}
                //----- DEL K2013/10/10 田建委 Redmine#40626 ---------------<<<<<
                //----- ADD K2013/10/10 田建委 Redmine#40626 --------------->>>>>
                // インスタンス生成
                object obj = this.LoadAssembly("PMKHN01702AC", "Broadleaf.Application.Controller.FuTaBaStockMoveAcs");

                // メソッド取得
                System.Reflection.MethodInfo myMethod = obj.GetType().GetMethod("SearchFTStockMoveExistenceCheck", new Type[] { typeof(string), typeof(int) });

                // 処理実行
                object ret = myMethod.Invoke(obj, new object[] { enterPriseCode, stockMoveSlipNo });

                status = (int)ret;
                //----- ADD K2013/10/10 田建委 Redmine#40626 ---------------<<<<<
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// アセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2013/10/10</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname)
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
            }
            return obj;
        }
        #endregion
        //----- ADD K2013/09/11 田建委 ----------<<<<<
        // ---- ADD K2013/12/25 鄧潘ハン ------------------------------- >>>>>
        /// <summary>
        /// 拠点間発注データにて抽出済み伝票を取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点間発注データにて抽出済み伝票を取得。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : K2013/12/25</br>
        /// <br>Update Note: K2014/11/20 劉超</br>
        /// <br>             Redmine#44000 フタバ　在庫移動入力入荷確定処理のエラーの対応</br>
        /// </remarks>
        //public int GetOrderData() // DEL K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応
        public int GetOrderData(ArrayList stockMoveList) // ADD K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
          
            _orderDataDic = new Dictionary<string, ArrayList>();
            //----- DEL K2014/01/20 wangl2 Redmine#41497 --------------->>>>>
            //// 在庫移動伝票番号と在庫移動行番号をkeyとして、格納する
            //string orderDataKey = string.Empty;
            //// 拠点引当数と発注データの更新時間格納する
            //ArrayList secOrderDtList = null;
            //----- DEL K2014/01/20 wangl2 Redmine#41497 ---------------<<<<<
            try
            {
                //----- DEL K2014/01/20 wangl2 Redmine#41497 --------------->>>>>
                //this._iSecOrderDB = (IFutabaSecOrderDtDB)MediationFutabaSecOrderDtDB.GetFutabaSecOrderDtDB();
                //// 拠点間発注データの検索パラメーター
                //SecOrderCndtnWork paraSecOrderCndtnWork = new SecOrderCndtnWork();
                //SecOrderDtWork secOrderDtWork = new SecOrderDtWork();
                //// 企業コード
                //paraSecOrderCndtnWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //// 拠点間発注データ
                //object retList = null;
                //object paraObj = paraSecOrderCndtnWork;

                //// 拠点間発注データを検索する
                //status = this._iSecOrderDB.Search(out retList, paraObj, 0);

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    ArrayList al = retList as ArrayList;
                //    for (int i = 0; i < al.Count; i++)
                //    {
                //        secOrderDtWork = al[i] as SecOrderDtWork;
                //        secOrderDtList = new ArrayList();
                //        // key 在庫移動伝票番号と在庫移動行番号
                //        orderDataKey = secOrderDtWork.StockMoveSlipNo + "_" + secOrderDtWork.StockMoveRowNo;

                //        // 拠点間発注データ区分0ではない、1:発注済と2:引当済をセットする
                //        if (!_orderDataDic.ContainsKey(orderDataKey) && secOrderDtWork.SecOrderDataDiv != 0)
                //        {
                //            secOrderDtList.Add(secOrderDtWork.UpdateDateTime);
                //            secOrderDtList.Add(secOrderDtWork.SecAllocCnt);
                //            // 取消の場合：1発注済 // 入庫の場合：2引当済
                //            secOrderDtList.Add(secOrderDtWork.SecOrderDataDiv);
                //            _orderDataDic.Add(orderDataKey, secOrderDtList);
                //        }
                //    }
                 
                //}
                //----- DEL K2014/01/20 wangl2 Redmine#41497 ---------------<<<<<

                //----- ADD K2014/01/20 wangl2 Redmine#41497 --------------->>>>> 
                object obj = this.LoadAssembly("PMZAI02205AC", "Broadleaf.Application.Controller.SecOrderAcs");
                /* ------ DEL START K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応 ------>>>>>
                // メソッド取得
                System.Reflection.MethodInfo myMethod = obj.GetType().GetMethod("SearchSecOrderData", new Type[] { typeof(Dictionary<string,ArrayList>).MakeByRefType(), typeof(string)});
                // 処理実行
                object[] arguments = new object[] { _orderDataDic, LoginInfoAcquisition.EnterpriseCode };
                //------ DEL END K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応 ------<<<<<*/
                //------ ADD START K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応 ------>>>>>
                // メソッド取得
                System.Reflection.MethodInfo myMethod = obj.GetType().GetMethod("SearchSecOrderData", new Type[] { typeof(Dictionary<string, ArrayList>).MakeByRefType(), typeof(ArrayList) });
                // 処理実行
                object[] arguments = new object[] { _orderDataDic, stockMoveList };
                //------ ADD END K2014/11/20 劉超 FOR Redmine#44000 フタバ個別対応 ------<<<<<
                object ret = myMethod.Invoke(obj, arguments);

                status = (int)ret;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _orderDataDic = (Dictionary<string, ArrayList>)arguments[0];
                }
                //----- ADD K2014/01/20 wangl2 Redmine#41497 ---------------<<<<<

            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        // ---- ADD K2013/12/25 鄧潘ハン ------------------------------- <<<<<
    }
}
