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
    /// 売上入力用初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の初期値取得データ制御を行います。</br>
    /// <br>Update Note : 2010/05/30 20056 對馬 大輔 </br>
    /// <br>              成果物統合(６次改良＋７次改良＋自由検索＋SCM)</br>
    /// <br>Update Note: 2012/12/19 西 毅</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             MAHNB01001U.Logが存在する場合ログを出力するように変更</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataFifthAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataFifthAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataFifthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataFifthAcs == null)
            {
                _delphiSalesSlipInputInitDataFifthAcs = new DelphiSalesSlipInputInitDataFifthAcs();
            }
            return _delphiSalesSlipInputInitDataFifthAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataFifthAcs _delphiSalesSlipInputInitDataFifthAcs;

        private List<MakerUMnt> _makerUMntList = null;         // メーカーマスタリスト
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList = null; // ＢＬコードマスタリスト

        //private double _taxRate = 0; // 2010/05/30

        ///// <summary> 入力モード</summary> // 2010/05/30
        //private int _inputMode; // 2010/05/30

        private GoodsAcs _goodsAcs;
        private IWin32Window _owner = null;
        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
        # endregion

        #region ■デリゲート
        /// <summary>売上金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>仕入金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        /// <summary>掛率優先管理マスタキャッシュデリゲート</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);

        #endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataFifth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●商品アクセスクラス初期処理(キャッシュなし)
            LogWrite("１ 商品アクセスクラス初期処理");
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = ctIsLocalDBRead;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);
            #endregion

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

            return 0;
        }
        #endregion

        public List<MakerUMnt> GetMakerUMntList()
        {
            return this._makerUMntList;
        }
        public List<BLGoodsCdUMnt> GetBlGoodsCdUMntList()
        {
            return this._blGoodsCdUMntList;
        }
        public GoodsAcs GetGoodsAcs()
        {
            return this._goodsAcs;

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
    }
}
