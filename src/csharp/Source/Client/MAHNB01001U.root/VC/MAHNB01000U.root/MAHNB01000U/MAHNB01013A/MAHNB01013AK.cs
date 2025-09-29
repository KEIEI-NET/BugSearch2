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
    /// </remarks>
    public class DelphiSalesSlipInputInitDataNinthAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataNinthAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataNinthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataNinthAcs == null)
            {
                _delphiSalesSlipInputInitDataNinthAcs = new DelphiSalesSlipInputInitDataNinthAcs();
            }
            return _delphiSalesSlipInputInitDataNinthAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataNinthAcs _delphiSalesSlipInputInitDataNinthAcs;
        private List<SalesProcMoney> _salesProcMoneyList = null;
        private List<StockProcMoney> _stockProcMoneyList = null;
        private List<RateProtyMng> _rateProtyMngList = null; // ADD 2010/03/01
        #endregion

        #region ■デリゲート
        /// <summary>売上金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>仕入金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        #endregion

        #region ■イベント
        /// <summary>売上金額処理区分設定キャッシュイベント</summary>
        public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
        /// <summary>仕入金額処理区分設定セットイベント</summary>
        public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
        # endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataNinth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●売上金額処理区分設定マスタ DCHMB09112A
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
            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            status = stockProcMoneyAcs.Search(out aList, enterpriseCode);
            this._stockProcMoneyList = new List<StockProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])aList.ToArray(typeof(StockProcMoney)));
            }
            this.CacheStockProcMoneyListCall();
            #endregion

            return 0;
        }
        #endregion

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

        public List<SalesProcMoney> GetSalesProcMoneyList()
        {
            return this._salesProcMoneyList;
        }
        public List<StockProcMoney> GetStockProcMoneyList()
        {
            return this._stockProcMoneyList;
        }
    }
}
