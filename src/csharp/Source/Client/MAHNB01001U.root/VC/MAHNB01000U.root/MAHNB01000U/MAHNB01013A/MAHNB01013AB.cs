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
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上伝票入力(Delphi)初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上伝票入力(Delphi)の初期値取得データ制御を行います。</br>
    /// <br>Programmer : LDNS</br>
    /// <br>Date       : 2010/05/29</br>
    /// <br></br>
    /// <br>Update Note : 2010/05/30 20056 對馬 大輔 </br>
    /// <br>              成果物統合(６次改良＋７次改良＋自由検索＋SCM)</br>
    /// <br>Update Note : 2010/07/29 20056 對馬 大輔 </br>
    /// <br>              表示区分マスタが特定タイミングに取得できない件の対応(初期取得マスタ最終時にリストがnullの場合、再取得する)</br>
    /// <br>Update Note : 2012/02/07 2012/03/28配信分　#28284 liusy</br>
    /// <br>              起動時のマスタ取得処理内に得意先掛率グループの取得処理を追加する</br>
    /// <br>Update Note : 2012/12/19 西 毅</br>
    /// <br>管理番号    : 10801804-00</br>
    /// <br>              MAHNB01001U.Logが存在する場合ログを出力するように変更</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataAcs == null)
            {
                _delphiSalesSlipInputInitDataAcs = new DelphiSalesSlipInputInitDataAcs();
            }
            return _delphiSalesSlipInputInitDataAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataAcs _delphiSalesSlipInputInitDataAcs;
        private GoodsAcs _goodsAcs;

        private List<RateProtyMng> _rateProtyMngList = null;
        private List<SubSection> _subSectionList = null;       // 部門マスタリスト
        private List<MakerUMnt> _makerUMntList = null;         // メーカーマスタリスト
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList = null; // ＢＬコードマスタリスト
        private PosTerminalMg _posTerminalMg = null;
        private ArrayList _allCustRateGroupList = null;        // 得意先マスタ全件リスト
        private IWin32Window _owner = null;
        private List<TbsPartsCodeWork> _tbsPartsCodeList = null; // 提供ＢＬコードマスタリスト // 2010/05/30
        private List<PriceSelectSet> _displayDivList = null;              // 表示区分リスト // 2010/07/29

        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
        /// <br>Update Note: 2009/09/08 張凱 車輌管理機能対応</br>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
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
        /// <summary>掛率優先管理マスタセットイベント</summary>
        public event CacheRateProtyMngListEventHandler CacheRateProtyMngList;
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
        /// <br>Update Note : 2012/02/07 liusy</br>
        /// <br>             起動時のマスタ取得処理内に得意先掛率グループの取得処理を追加する</br>
        public int ReadInitData(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●商品アクセスクラス初期処理(キャッシュなし)
            LogWrite("１商品アクセスクラス初期処理");
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = ctIsLocalDBRead;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);
            #endregion

            //>>>2010/05/30
            #region ●提供ＢＬコードリスト
            this._tbsPartsCodeList = this._goodsAcs.OfrBLList;
            LogWrite("★★★★★提供ＢＬコードリスト件数：" + this._tbsPartsCodeList.Count.ToString());
            #endregion
            //<<<2010/05/30

            #region ●メーカーマスタ
            LogWrite("１メーカーリストを取得");
            List<MakerUMnt> makerList;
            status = this._goodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            #endregion

            #region ●ＢＬコードリスト
            LogWrite("１BLコードリストを取得");
            List<BLGoodsCdUMnt> blGoodsList;
            status = this._goodsAcs.GetAllBLGoodsCd(enterpriseCode, out blGoodsList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (blGoodsList != null) this._blGoodsCdUMntList = blGoodsList;
            }
            #endregion

            //>>>2010/07/29
            #region ●表示区分マスタ PMHNB09003A
            ArrayList aList = new ArrayList();
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
            //<<<2010/07/29

            //add by liusy #28284 2012/02/07 ---->>>>>
            // 得意先掛率グループ再セット
            CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
            ArrayList custRateGroupList;
            LogWrite("得意先掛率グループを取得");
            status = custRateGroupAcs.Search(out custRateGroupList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._allCustRateGroupList = custRateGroupList;
            }
            else
            {
                this._allCustRateGroupList = new ArrayList();
            }
            //add by liusy #28284 2012/02/07 ----<<<<<
            return 0;
        }

        #region ■DEBUGログ出力
        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (SalesSlipInputInitDataAcs._Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    SalesSlipInputInitDataAcs._Log_Check = 1;
                }
                else
                {
                    SalesSlipInputInitDataAcs._Log_Check = 2;
                }

            }

            if (SalesSlipInputInitDataAcs._Log_Check == 1)
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

        #endregion

        //メーカーマスタ
        public List<MakerUMnt> GetMakerUMntList()
        {
            return this._makerUMntList;
        }
        //ＢＬコードリスト
        public List<BLGoodsCdUMnt> GetBlGoodsCdUMntList()
        {
            return this._blGoodsCdUMntList;
        }
        public GoodsAcs GetGoodsAcs()
        {
            return this._goodsAcs;
        }

        //>>>2010/05/30
        // 提供BLコードリスト
        public List<TbsPartsCodeWork> GetTbsPartsCodeList()
        {
            return this._tbsPartsCodeList;
        }
        //<<<2010/05/30

        //>>>2010/07/29
        public List<PriceSelectSet> GetDisplayDivList()
        {
            return this._displayDivList;
        }
        //<<<2010/07/29

        //add by liusy 2012/02/07 #28284 ----->>>>>
        public ArrayList GetCustRateGroupList()
        {
            return this._allCustRateGroupList;
        }
        //add by liusy 2012/02/07 #28284 -----<<<<<
        
        # endregion

    }
}
