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
// 作 成 日  2007/01/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Y.Sasaki
// 修 正 日  2007/07/05  修正内容 : １.在庫マスタ(倉庫毎)検索機能追加に伴う修正。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/02/09  修正内容 : 障害ID:11214対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/01  修正内容 : 不具合対応[12837]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/17  修正内容 : 不具合対応[13050]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/01  修正内容 : 不具合対応[12837] マイナス時、端数処理不正となる為、修正
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 王飛３
// 修 正 日  2011/07/07  修正内容 : 連番36 在庫照会の抽出中の中断機能が欲しい 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20073 西 毅
// 修 正 日  2012/04/10  修正内容 : 起動、抽出の速度改良
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using System.Data;
// -- ADD 2011.07.07 ----->>>>>
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
// -- ADD 2011.07.07 -----<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫検索アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫検索のアクセス制御を行います。</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2007.01.22</br>
    /// <br>Update Note: xxxx.xx.xx</br>
    /// <br>Update Note: 2007.07.05 Y.Sasaki</br>
    /// <br>           : １.在庫マスタ(倉庫毎)検索機能追加に伴う修正。</br>
    /// <br>Update Note: 2009.02.09 忍 幸史</br>
    /// <br>           : 障害ID:11214対応</br>
    /// <br>Update Note: 2009/04/01       照田 貴志</br>
    ///	<br>		   : 不具合対応[12837]</br>
    /// <br>Update Note: 2009/04/17       照田 貴志</br>
    ///	<br>		   : 不具合対応[13050]</br>
    /// <br>Update Note: 2009/05/01       照田 貴志</br>
    ///	<br>		   : 不具合対応[12837] マイナス時、端数処理不正となる為、修正</br>
    /// <br>Update Note: 2011/07/07       王飛３ </br>
    /// <br>               : 連番36   在庫照会の抽出中の中断機能が欲しい </br>
    /// </remarks>
    public class SearchStockAcs : IGeneralGuideData
    {
        //================================================================================
        //  コンストラクター
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 在庫検索アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫検索アクセスクラスの新しいインスタンスを作成します。</br>
        /// <br>Programer  : 18012  Y.Sasaki</br>
        /// <br>Date       : 2007.01.22</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public SearchStockAcs()
        {
            // ---ADD 2009/04/01 不具合対応[12837] ------------>>>>>
            // 在庫全体設定マスタアクセスクラス
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this.ReadStockMngTtlSt();
            // ---ADD 2009/04/01 不具合対応[12837] ------------<<<<<

            this._userGuideAcs = new UserGuideAcs();
        }

        /// <summary>
        /// 在庫検索アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫検索アクセスクラスの新しいインスタンスを作成します。</br>
        /// <br>Programer  : 18012  Y.Sasaki</br>
        /// <br>Date       : 2007.01.22</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public SearchStockAcs(string enterpriseCode, string sectionCode)
        {
            // ---ADD 2009/04/01 不具合対応[12837] ------------>>>>>
            // 在庫全体設定マスタアクセスクラス
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this.ReadStockMngTtlSt();
            // ---ADD 2009/04/01 不具合対応[12837] ------------<<<<<

            this._userGuideAcs = new UserGuideAcs();
            this._goodsAcs.IsGetSupplier = true;            //ADD 2009/04/17 不具合対応[13050]
            string msg;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out msg);

            // --- ADD 2009/02/09 障害ID:11217対応------------------------------------------------------>>>>>
            this._stockProcMoneyAcs = new StockProcMoneyAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._taxRateSetAcs = new TaxRateSetAcs();

            ReadInitData();
            ReadTaxRate();
            // --- ADD 2009/02/09 障害ID:11217対応------------------------------------------------------<<<<<
        }
        #endregion

        // >>>ddd
        //================================================================================
        //  プロパティ
        //================================================================================
        /// <summary>
        /// 商品アクセスクラス
        /// </summary>
        public GoodsAcs GoodsAcs
        {
            get { return this._goodsAcs; }
            set { this._goodsAcs = value; }
        }
        // <<<ddd

        //================================================================================
        //  内部使用メンバ
        //================================================================================
        #region Private Members(リモートオブジェクト)

        // --------------------------------------------------
        #region < リモートオブジェクト >
        /// <summary>在庫検索リモートオブジェクト格納バッファ</summary>
        private IGoodsStockSearchDB _iGoodsStockSearchDB = null;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
        // メーカー名取得用
        private MakerAcs _makerAcs = new MakerAcs();
        //private MakerUMnt _makerInfo;
        //private int _status;

        // 商品管理情報マスタ取得用
        private GoodsAcs _goodsAcs = new GoodsAcs();
        private GoodsUnitData _goodsUnitDate = new GoodsUnitData();
        //private GoodsPrice _goodsPrice; //ddd

        private int _paraSupplierCd = 0;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

        // --- ADD 2009/02/09 障害ID:11217対応------------------------------------------------------>>>>>
        private StockProcMoneyAcs _stockProcMoneyAcs;   // 単価算出クラスアクセスクラス
        private UnitPriceCalculation _unitPriceCalculation;
        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        private TaxRateSet _taxRateSet;
        // --- ADD 2009/02/09 障害ID:11217対応------------------------------------------------------<<<<<
        private StockMngTtlStAcs _stockMngTtlStAcs;         //ADD 2009/04/01 不具合対応[12837]
        private StockMngTtlSt _stockMngTtlSt;               //ADD 2009/04/01 不具合対応[12837]
        SFCMN00299CA _processingDialog = new SFCMN00299CA();  // ADD 2011/07/07
        #endregion

        // --- ADD 2009/02/09 障害ID:11217対応------------------------------------------------------>>>>>
        /// <summary>
        /// 単価算出クラス初期データ読込処理
        /// </summary>
        private void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
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
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);         // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

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
        /// 税率設定マスタ取得処理
        /// </summary>
        private void ReadTaxRate()
        {
            int status;

            try
            {
                // 税率設定マスタ取得(税率コード=0固定)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }
        // --- ADD 2009/02/09 障害ID:11217対応------------------------------------------------------<<<<<

        // --------------------------------------------------
        #region < 各種アクセスクラス >
        /// <summary>ユーザーガイドアクセスクラス</summary>
        UserGuideAcs _userGuideAcs;
        #endregion

        // --------------------------------------------------
        #region < データ格納用 >

        /// <summary>在庫検索結果格納格納バッファ</summary>
        private Dictionary<string, Dictionary<string, StockExpansion>> _drStockSearchRet;
        private Dictionary<string, Dictionary<string, Stock>> _drStockSearchRet2;


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>ユーザーガイドリスト static</summary>
        private static ArrayList _userGdBdList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>製番在庫検索結果格納格納バッファ</summary>
        //private Dictionary<string, ProductStock> _drProductStockSearchRet;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion

        #endregion

        //================================================================================
        //  内部 Staticメンバ
        //================================================================================
        #region Private Static Members

        //--- ADD 2011/07/07 ----->>>>>
        #region 抽出中断フラグ
        // 抽出中断フラグ
        private bool _extractCancelFlag;


        /// 抽出中断フラグ
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>
        /// 在庫全体設定マスタ
        /// </summary>
        public StockMngTtlSt StockMngTtlSt
        {
            get { return _stockMngTtlSt; }
        }

        /// <summary>
        /// 税率設定マスタ
        /// </summary>
        public TaxRateSet TaxRateSet
        {
            get { return _taxRateSet; }
        }

        /// <summary>
        /// 
        /// </summary>
        public UnitPriceCalculation UnitPriceCalculation
        {
            get { return _unitPriceCalculation; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD
        #endregion
        //--- ADD 2011/07/07 -----<<<<<
        #endregion

        //================================================================================
        //  外部提供関数
        //================================================================================
        #region Public Methods

        // --------------------------------------------------
        #region < 在庫検索関連メソッド群 >

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        #region ■ 商品在庫(+定価)取得
        /// <summary>
        /// 在庫検索
        /// </summary>
        /// <param name="searchPara">在庫検索条件</param>
        /// <param name="stockSearchRetList">在庫結果データリスト(StockExpansion)</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        public int Search(StockSearchPara searchPara, out List<StockExpansion> stockSearchRetList, out string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";

            //2008.10.03 stokunaga Add start
            _paraSupplierCd = searchPara.SupplierCd;
            //2008.10.03 stokunaga Add end

            stockSearchRetList = new List<StockExpansion>();

            try
            {
                // バッファクリア
                if (this._drStockSearchRet == null)
                    this._drStockSearchRet = new Dictionary<string, Dictionary<string, StockExpansion>>();
                else
                    this._drStockSearchRet.Clear();

                if (this._iGoodsStockSearchDB == null)
                {
                    this._iGoodsStockSearchDB = MediationGoodsStockSearchDB.GetGoodsStockSearchDB();
                }

                StockSearchParaWork searchParaWork = this.CopyToSearchParaWorkFromSearchPara(searchPara);

                object retObj;

                // 検索
                status = this._iGoodsStockSearchDB.Search(out retObj, searchParaWork, 0, ConstantManagement.LogicalMode.GetData0);


                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;

                            // 取得データを変換
                            if (retList != null)
                            {
                                // 在庫データの取得
                                status = GetStockWorkToUIdata(retList, out stockSearchRetList);
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
                                                //string primaryKey = this.GetPrimaryKeyStock(stockSearchRet.GoodsMakerCd, stockSearchRet.GoodsNo, stockSearchRet.WarehouseCode);
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
                this._iGoodsStockSearchDB = null;
            }


            return status;
        }

        /// <summary>
        /// 在庫検索
        /// </summary>
        /// <param name="searchPara">在庫検索条件</param>
        /// <param name="stockSearchRetList">在庫結果データリスト(StockExpansion)</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        public int Search(StockSearchPara searchPara, out List<Stock> stockSearchRetList, out string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";
            //2008.10.03 stokunaga Add start
            _paraSupplierCd = searchPara.SupplierCd;
            //2008.10.03 stokunaga Add end

            stockSearchRetList = new List<Stock>();

            try
            {
                // バッファクリア
                if (this._drStockSearchRet2 == null)
                    this._drStockSearchRet2 = new Dictionary<string, Dictionary<string, Stock>>();
                else
                    this._drStockSearchRet2.Clear();

                if (this._iGoodsStockSearchDB == null)
                {
                    this._iGoodsStockSearchDB = MediationGoodsStockSearchDB.GetGoodsStockSearchDB();
                }

                StockSearchParaWork searchParaWork = this.CopyToSearchParaWorkFromSearchPara(searchPara);

                object retObj;

                // 検索
                status = this._iGoodsStockSearchDB.Search(out retObj, searchParaWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;

                            // 取得データを変換
                            if (retList != null)
                            {
                                // 在庫データの取得
                                status = GetStockWorkToUIdata2(retList, out stockSearchRetList);
                                switch (status)
                                {
                                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                        {
                                            foreach (Stock stockSearchRet in stockSearchRetList)
                                            {
                                                Dictionary<string, Stock> stock;

                                                // 拠点コード毎の在庫リストを取得する
                                                if (this._drStockSearchRet2.ContainsKey(stockSearchRet.SectionCode))
                                                {
                                                    stock = this._drStockSearchRet2[stockSearchRet.SectionCode];
                                                }
                                                else
                                                {
                                                    stock = new Dictionary<string, Stock>();
                                                    this._drStockSearchRet2.Add(stockSearchRet.SectionCode, stock);
                                                }

                                                // プライマリキーを作成
                                                //string primaryKey = this.GetPrimaryKeyStock(stockSearchRet.GoodsMakerCd, stockSearchRet.GoodsNo, stockSearchRet.WarehouseCode);
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
                if (this._drStockSearchRet2 != null && this._drStockSearchRet2.Count > 0)
                {
                    stockSearchRetList = new List<Stock>();

                    foreach (KeyValuePair<string, Dictionary<string, Stock>> kvP in this._drStockSearchRet2)
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
                this._iGoodsStockSearchDB = null;
            }

            return status;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>
        /// 在庫検索（中断用）
        /// </summary>
        /// <param name="searchPara">在庫検索条件</param>
        /// <param name="retObj">在庫結果データリスト(StockExpansion)</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        public int StopSearch2(StockSearchPara searchPara, out object retObj, out string msg)
        {
            retObj = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";
            _paraSupplierCd = searchPara.SupplierCd;

            _extractCancelFlag = false;

            try
            {
                // バッファクリア
                if (this._drStockSearchRet == null)
                    this._drStockSearchRet = new Dictionary<string, Dictionary<string, StockExpansion>>();
                else
                    this._drStockSearchRet.Clear();

                if (this._iGoodsStockSearchDB == null)
                {
                    this._iGoodsStockSearchDB = MediationGoodsStockSearchDB.GetGoodsStockSearchDB();
                }

                StockSearchParaWork searchParaWork = this.CopyToSearchParaWorkFromSearchPara(searchPara);
                searchParaWork.pricestartdate = DateTime.Now;


                // 検索
                status = this._iGoodsStockSearchDB.Search2(out retObj, searchParaWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    default:
                        msg = "在庫データの取得に失敗しました";
                        return status;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "在庫検索で例外が発生しました[" + ex.Message + "]";
                msg = ex.Message;
                this._iGoodsStockSearchDB = null;
            }

            return status;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        //--- ADD 2011/07/07 ----->>>>>
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
        /// <br>Date	    : 2011.07.07</br>
        /// </remarks>
        public int StopSearch(StockSearchPara searchPara, out List<StockExpansion> stockSearchRetList, out string msg, ref SFCMN00299CA processingDialog)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";
            _paraSupplierCd = searchPara.SupplierCd;

            stockSearchRetList = new List<StockExpansion>();
            _extractCancelFlag = false;

            try
            {
                // バッファクリア
                if (this._drStockSearchRet == null)
                    this._drStockSearchRet = new Dictionary<string, Dictionary<string, StockExpansion>>();
                else
                    this._drStockSearchRet.Clear();

                if (this._iGoodsStockSearchDB == null)
                {
                    this._iGoodsStockSearchDB = MediationGoodsStockSearchDB.GetGoodsStockSearchDB();
                }

                StockSearchParaWork searchParaWork = this.CopyToSearchParaWorkFromSearchPara(searchPara);

                object retObj;

                // 検索
                status = this._iGoodsStockSearchDB.Search(out retObj, searchParaWork, 0, ConstantManagement.LogicalMode.GetData0);


                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;

                            // 取得データを変換
                            if (retList != null)
                            {
                                _processingDialog = processingDialog;
                                this._extractCancelFlag = false;
                                _processingDialog.DispCancelButton = true;
                                _processingDialog.CancelButtonClick += new EventHandler(processingDialog_CancelButtonClick);
                                _processingDialog.Title = "抽出処理";
                                _processingDialog.Message = "現在、データ抽出中です。(ESCで中断します)";

                                _processingDialog.Show();

                                // 在庫データの取得
                                status = GetStockWorkToUIdata(retList, out stockSearchRetList);
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
                this._iGoodsStockSearchDB = null;
            }


            return status;
        }
        #endregion
        //--- ADD 2011/07/07 -----<<<<<
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion

        #endregion

        //================================================================================
        //  内部使用関数
        //================================================================================
        #region Private Methods

        #region ●　クラスメンバーコピー処理（在庫検索抽出条件クラス ⇒ 在庫検索条件クラスワーク）
        /// <summary>
        /// クラスメンバーコピー処理（在庫検索抽出条件クラス ⇒ 在庫検索条件クラスワーク）
        /// </summary>
        /// <param name="searchPara">在庫検索抽出条件クラス</param>
        /// <returns>在庫検索条件クラスワーク</returns>
        private StockSearchParaWork CopyToSearchParaWorkFromSearchPara(StockSearchPara searchPara)
        {
            StockSearchParaWork searchParaWork = null;

            if (searchPara != null)
            {
                searchParaWork = new StockSearchParaWork();

                // 企業コード
                searchParaWork.EnterpriseCode = searchPara.EnterpriseCode;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// データ取得区分
                //searchParaWork.DataAcqrDiv = searchPara.DataAcqrDiv;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 拠点コード
                searchParaWork.SectionCode = searchPara.SectionCode;

                // メーカーコード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //searchParaWork.MakerCode = searchPara.MakerCode;
                searchParaWork.GoodsMakerCd = searchPara.GoodsMakerCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 品番
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //searchParaWork.GoodsCode = searchPara.GoodsCode;
                searchParaWork.GoodsNo = searchPara.GoodsNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 品番検索タイプ
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //searchParaWork.GoodsCodeSrchTyp = searchPara.GoodsCodeSrchTyp;
                searchParaWork.GoodsNoSrchTyp = searchPara.GoodsNoSrchTyp;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 品名
                searchParaWork.GoodsName = searchPara.GoodsName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 品名カナ
                searchParaWork.GoodsNameKana = searchPara.GoodsNameKana;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
                // 品名検索タイプ
                searchParaWork.GoodsNameSrchTyp = searchPara.GoodsNameSrchTyp;

                // 品名カナ検索タイプ
                searchParaWork.GoodsNameKanaSrchTyp = searchPara.GoodsNameKanaSrchTyp;

                // 棚番
                searchParaWork.WarehouseShelfNo = searchPara.WarehouseShelfNo;

                // 棚番検索タイプ
                searchParaWork.WarehouseShelfNoSrchTyp = searchPara.WarehouseShelfNoSrchTyp;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 機種コード
                //searchParaWork.CellphoneModelCode = searchPara.CellphoneModelCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA DEL START
                // 商品区分グループコード
                //searchParaWork.LargeGoodsGanreCode = searchPara.LargeGoodsGanreCode;

                // 商品区分コード
                //searchParaWork.MediumGoodsGanreCode = searchPara.MediumGoodsGanreCode;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 商品区分詳細コード
                //searchParaWork.DetailGoodsGanreCode = searchPara.DetailGoodsGanreCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA DEL END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// キャリアコード
                //searchParaWork.CarrierCode = searchPara.CarrierCode;

                //// 事業者コード
                //searchParaWork.CarrierEpCode = searchPara.CarrierEpCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // ＢＬ商品コード
                searchParaWork.BLGoodsCode = searchPara.BLGoodsCode;
                // 自社分類コード
                searchParaWork.EnterpriseGanreCode = searchPara.EnterpriseGanreCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 倉庫コード
                searchParaWork.WarehouseCode = searchPara.WarehouseCode;

                // 得意先コード
                //searchParaWork.CustomerCode = searchPara.CustomerCode;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 製造番号
                //searchParaWork.ProductNumber = searchPara.ProductNumber;

                //// 製造番号タイプ
                //searchParaWork.ProductNumberSrchTyp = searchPara.ProductNumberSrchTyp;

                //// 製造番号検索区分
                //searchParaWork.ProductNumberSrchDivCd = searchPara.ProductNumberSrchDivCd;

                //// 商品電話番号
                //searchParaWork.StockTelNo = searchPara.StockTelNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // ゼロ在庫表示
                searchParaWork.ZeroStckDsp = searchPara.ZeroStckDsp;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
                // 対象日付区分
                searchParaWork.DateDiv = searchPara.DateDiv;

                // 開始対象日付
                searchParaWork.St_Date = TDateTime.LongDateToDateTime(searchPara.St_Date);

                // 終了対象日付
                searchParaWork.Ed_Date = TDateTime.LongDateToDateTime(searchPara.Ed_Date);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 在庫状態、移動状態、商品状態の固定設定項目を設定する
                //// 在庫状態
                //if (searchPara.StockState != null && searchPara.StockState.Length > 0)
                //{
                //    searchParaWork.StockState = new Int32[searchPara.StockState.Length];
                //    searchPara.StockState.CopyTo(searchParaWork.StockState, 0);
                //}
                //else
                //{
                //    searchParaWork.StockState = null;
                //}

                //// 移動状態状態
                //if (searchPara.MoveStatus != null && searchPara.MoveStatus.Length > 0)
                //{
                //    searchParaWork.MoveStatus = new Int32[searchPara.MoveStatus.Length];
                //    searchPara.MoveStatus.CopyTo(searchParaWork.MoveStatus, 0);
                //}
                //else
                //{
                //    searchParaWork.MoveStatus = null;
                //}

                //// 商品状態
                //if (searchPara.GoodsCodeStatus != null && searchPara.GoodsCodeStatus.Length > 0)
                //{
                //    searchParaWork.GoodsCodeStatus = new Int32[searchPara.GoodsCodeStatus.Length];
                //    searchPara.GoodsCodeStatus.CopyTo(searchParaWork.GoodsCodeStatus, 0);
                //}
                //else
                //{
                //    searchParaWork.GoodsCodeStatus = null;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 商品コード(複数)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if (searchPara.GoodsCodes != null && searchPara.GoodsCodes.Length > 0)
                //{
                //    searchParaWork.GoodsCodes = new string[searchPara.GoodsCodes.Length];
                //    searchPara.GoodsCodes.CopyTo(searchParaWork.GoodsCodes, 0);
                //}
                //else
                //{
                //    searchParaWork.GoodsCodes = null;
                //}
                if (searchPara.GoodsNos != null && searchPara.GoodsNos.Length > 0)
                {
                    searchParaWork.GoodsNos = new string[searchPara.GoodsNos.Length];
                    searchPara.GoodsNos.CopyTo(searchParaWork.GoodsNos, 0);
                }
                else
                {
                    searchParaWork.GoodsNos = null;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 倉庫コード(複数)
                if (searchPara.WarehouseCodes != null && searchPara.WarehouseCodes.Length > 0)
                {
                    searchParaWork.WarehouseCodes = new string[searchPara.WarehouseCodes.Length];
                    searchPara.WarehouseCodes.CopyTo(searchParaWork.WarehouseCodes, 0);
                }
                else
                {
                    searchParaWork.WarehouseCodes = null;
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.05 TOKUNAGA ADD START
                // メーカーコード(複数)
                if (searchPara.GoodsMakerCds != null && searchPara.GoodsMakerCds.Length > 0)
                {
                    searchParaWork.GoodsMakerCds = new int[searchPara.GoodsMakerCds.Length];
                    searchPara.GoodsMakerCds.CopyTo(searchParaWork.GoodsMakerCds, 0);
                }
                else
                {
                    searchParaWork.GoodsMakerCds = null;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.05 TOKUNAGA ADD END
            }

            return searchParaWork;
        }
        #endregion

        #region ●　クラスメンバーコピー処理（在庫検索抽出条件クラス ⇒ 商品抽出条件クラス）

        #region 使ってない？

        /// <summary>
        /// クラスメンバーコピー処理（在庫検索抽出条件クラス ⇒ 商品抽出条件クラス）
        /// </summary>
        /// <param name="searchPara">在庫検索抽出条件クラス</param>
        /// <returns>商品抽出条件クラス</returns>
        private GoodsCndtn CopyToGoodsCndtnFromStockSearchPara(StockSearchPara searchPara)
        {
            GoodsCndtn goodsCndtn = null;

            if (searchPara != null)
            {
                goodsCndtn = new GoodsCndtn();

                // 企業コード
                goodsCndtn.EnterpriseCode = searchPara.EnterpriseCode;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// キャリアコード
                //goodsCndtn.CarrierCode = searchPara.CarrierCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // メーカーコード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //goodsCndtn.MakerCode = searchPara.MakerCode;
                goodsCndtn.GoodsMakerCd = searchPara.GoodsMakerCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //// 商品区分グループコード
                //goodsCndtn.LargeGoodsGanreCode = searchPara.LargeGoodsGanreCode;

                //// 商品区分コード
                //goodsCndtn.MediumGoodsGanreCode = searchPara.MediumGoodsGanreCode;

                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 商品区分詳細コード
                //goodsCndtn.DetailGoodsGanreCode = searchPara.DetailGoodsGanreCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 商品コード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //goodsCndtn.GoodsCode = searchPara.GoodsCode;
                goodsCndtn.GoodsNo = searchPara.GoodsNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 商品コード検索タイプ[0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //goodsCndtn.GoodsCodeSrchTyp = 0;
                goodsCndtn.GoodsNoSrchTyp = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 商品名称カナ
                goodsCndtn.GoodsNameKana = searchPara.GoodsNameKana;

                // 商品名称カナ検索タイプ[0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索]
                goodsCndtn.GoodsNameKanaSrchTyp = 3;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 商品名称
                goodsCndtn.GoodsName = searchPara.GoodsName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 機種コード
                //goodsCndtn.CellphoneModelCode = searchPara.CellphoneModelCode;

                //// 機種コード検索タイプ
                //goodsCndtn.CellphoneModelCodeSrchTyp = 3;

                //// 商品現行区分
                //goodsCndtn.GoodsValiditySrchCode = null;

                //// 商品種別
                //goodsCndtn.GoodsKindSrchCode = null;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

            return goodsCndtn;
        }

        #endregion // 使ってない？

        #endregion
        #region ●　CustomSerializeArrayList →　在庫クラス取得
        /// <summary>
        /// CustomSerializeArrayList →　在庫クラス取得
        /// </summary>
        /// <param name="retList">WORK型データリスト</param>
        /// <param name="uiList">在庫クラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        private int GetStockWorkToUIdata(CustomSerializeArrayList retList, out List<StockExpansion> uiList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            uiList = null;

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
            //MakerAcs _makerAcs = new MakerAcs();
            //MakerUMnt makerInfo;
            //int status;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

            try
            {
                foreach (ArrayList arList in retList)
                {
                    //--- ADD 2011/07/07 ----->>>>>
                    if (_extractCancelFlag == true)
                    {
                        break;
                    }
                    //--- ADD 2011/07/07 -----<<<<<
                    if (arList != null && arList.Count > 0)
                    {
                        if (arList[0] is StockEachWarehouseWork)
                        {
                            // クラスメンバーコピー処理
                            uiList = this.CopyToStockFromStockWork(arList);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                            // ここで受け取った値を元に取得できる項目をすべて取得し、StockExpansionクラスの列に放り込む

                            //if (uiList[0].GoodsMakerCd != 0)
                            //{
                            //    status = _makerAcs.Read(makerInfo, uiList[0].EnterpriseCode, uiList[0].GoodsMakerCd);
                            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //    {
                            //        //uiList[0]
                            //    }
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

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
        /// CustomSerializeArrayList →　在庫クラス取得
        /// </summary>
        /// <param name="retList">WORK型データリスト</param>
        /// <param name="uiList">在庫クラス</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        private int GetStockWorkToUIdata2(CustomSerializeArrayList retList, out List<Stock> uiList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            uiList = null;

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
            //MakerAcs _makerAcs = new MakerAcs();
            //MakerUMnt makerInfo;
            //int status;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

            try
            {
                foreach (ArrayList arList in retList)
                {
                    //--- ADD 2011/07/07 ----->>>>>
                    if (_extractCancelFlag == true)
                    {
                        break;
                    }
                    //--- ADD 2011/07/07 -----<<<<<
                    if (arList != null && arList.Count > 0)
                    {
                        if (arList[0] is StockEachWarehouseWork)
                        {
                            // クラスメンバーコピー処理
                            uiList = this.CopyToStockFromStockWork2(arList);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                            // ここで受け取った値を元に取得できる項目をすべて取得し、StockExpansionクラスの列に放り込む

                            //if (uiList[0].GoodsMakerCd != 0)
                            //{
                            //    status = _makerAcs.Read(makerInfo, uiList[0].EnterpriseCode, uiList[0].GoodsMakerCd);
                            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //    {
                            //        //uiList[0]
                            //    }
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

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
        #endregion

        #region ●　CustomSerializeArrayList →　在庫クラス(倉庫毎)取得
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// CustomSerializeArrayList →　在庫クラス(倉庫毎)取得
        ///// </summary>
        ///// <param name="retList">WORK型データリスト</param>
        ///// <param name="uiList">在庫クラス(倉庫毎)</param>
        ///// <returns>ConstantManagement.DB_Status</returns>
        //private int GetStockEachWarehouseWorkToUIdata(CustomSerializeArrayList retList, out List<StockEachWarehouse> uiList)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    uiList = null;

        //    try
        //    {
        //        foreach (ArrayList arList in retList)
        //        {
        //            if (arList != null && arList.Count > 0)
        //            {
        //                if (arList[0] is StockEachWarehouseWork)
        //                {
        //                    // クラスメンバーコピー処理
        //                    uiList = this.CopyToStockEachWarehouseFromStockEachWarehouseWork(arList);

        //                    status = (uiList.Count != 0) ? (int)ConstantManagement.DB_Status.ctDB_NORMAL : (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        // 例外を発生させる
        //        string message = "在庫データクラス(倉庫毎)取得で例外が発生しました[" + ex.Message + "]";
        //        throw new SearchStockAcsException(message, -1);
        //    }

        //    return status;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #region ●　CustomSerializeArrayList →　製番在庫クラス取得
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// CustomSerializeArrayList →　製番在庫クラス取得
        ///// </summary>
        ///// <param name="retList">WORK型データリスト</param>
        ///// <param name="uiList">製番在庫クラス</param>
        ///// <returns>ConstantManagement.DB_Status</returns>
        //private int GetProductStockWorkToUIdata(CustomSerializeArrayList retList, out List<ProductStock> uiList)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    uiList = null;

        //    try
        //    {
        //        foreach (ArrayList arList in retList)
        //        {
        //            if (arList != null && arList.Count > 0)
        //            {
        //                if (arList[0] is ProductStockWork)
        //                {
        //                    // クラスメンバーコピー処理
        //                    uiList = this.CopyToProductStockFromProductStockWork(arList);

        //                    status = (uiList.Count != 0) ? (int)ConstantManagement.DB_Status.ctDB_NORMAL : (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        // 例外を発生させる
        //        string msg = "製番在庫マスタの取得で例外が発生しました[" + ex.Message + "]";
        //        throw new SearchStockAcsException(msg, -1);
        //    }

        //    return status;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #region ●　クラスメンバーコピー処理（在庫ワークリスト⇒在庫クラス(List<T>)）
        /// <summary>
        /// クラスメンバーコピー処理（在庫ワークリスト⇒在庫クラス(List<T>)）
        /// </summary>
        /// <param name="workList">在庫ワークリスト</param>
        /// <returns>在庫クラス(List)</returns>
        private List<StockExpansion> CopyToStockFromStockWork(ArrayList workList)
        {
            // ご提案シートタイプリスト
            List<StockExpansion> stockRetList = null;

            // 商品管理在庫クラスから仕入れ情報を取得し、ない場合は結果として返さない
            List<GoodsUnitData> unitDataList = new List<GoodsUnitData>();
            GoodsUnitData unitData = new GoodsUnitData();
            //GoodsAcs goodsAcs = new GoodsAcs(); // ddd
            //Supplier supplierInfo;
            SupplierAcs supplierAcs = new SupplierAcs();
            string msg = string.Empty;

            if (workList != null)
            {
                stockRetList = new List<StockExpansion>();
                StockExpansion stockEx = null;

                foreach (StockEachWarehouseWork wrk in workList)
                {
                    //--- ADD 2011/07/07 ----->>>>>
                    if (_extractCancelFlag == true)
                    {
                        break;
                    }
                    //--- ADD 2011/07/07 -----<<<<<

                    // 商品在庫管理クラスを検索
                    GoodsCndtn condition = new GoodsCndtn();
                    condition.EnterpriseCode = wrk.EnterpriseCode;
                    condition.SectionCode = wrk.SectionCode;
                    condition.GoodsMakerCd = wrk.GoodsMakerCd;
                    condition.BLGoodsCode = wrk.BLGoodsCode;
                    condition.GoodsNo = wrk.GoodsNo;
                    // 追加仕様 2008/11/06 add start
                    condition.GoodsKindCode = 9;
                    // 追加仕様 2008/11/06 add end

                    condition.IsSettingSupplier = 1; // ddd

                    //int status = goodsAcs.Search(condition, out unitDataList, out msg); //ddd
                    //SearchStockAcs.LogWrite("▼商品検索　開始");
                    int status = this._goodsAcs.Search(condition, out unitDataList, out msg); // ddd
                    //SearchStockAcs.LogWrite("▲商品検索　終了");
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        unitData = unitDataList[0];
                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref unitData);

                        //goodsAcs.GetGoodsMngInfo(ref unitData);
                        stockEx = CopyToStockExpansionFromStockEachWarehouseWork(wrk);

                        //>>>ddd 仕入先マスタのReadせずに検索結果を使用
                        //if (unitData.SupplierCd > 0)
                        //{
                        //    stockEx.SupplierCd = unitData.SupplierCd;
                        //    status = supplierAcs.Read(out supplierInfo, unitData.EnterpriseCode, unitData.SupplierCd);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        stockEx.SupplierSnm = supplierInfo.SupplierSnm;
                        //    }
                        //    else
                        //    {
                        //       stockEx.SupplierSnm = unitData.SupplierSnm;
                        //    }
                        //}
                        stockEx.SupplierCd = unitData.SupplierCd;   // 仕入先コード
                        stockEx.SupplierSnm = unitData.SupplierSnm; // 仕入先略称
                        stockEx.MakerName = unitData.MakerName;     // メーカー名称
                        //<<<ddd

                        //SearchStockAcs.LogWrite("▼定価取得　開始");
                        // 標準価格
                        //GoodsPrice goodsPrice = goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, unitData.GoodsPriceList); //ddd
                        GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, unitData.GoodsPriceList);//ddd
                        if (goodsPrice != null)
                        {
                            stockEx.ListPrice = goodsPrice.ListPrice;
                        }
                        //SearchStockAcs.LogWrite("▲定価取得　終了");

                        //SearchStockAcs.LogWrite("▼原価取得　開始");
                        // --- ADD 2009/02/09 障害ID:11217対応------------------------------------------------------>>>>>
                        stockEx.StockUnitPriceFl = GetStockUnitPrice(unitData);
                        //stockEx.StockTotalPrice = (long)(stockEx.StockUnitPriceFl * stockEx.SupplierStock);   //DEL 2009/04/01 不具合対応[12837]
                        stockEx.StockTotalPrice = this.StockTotalPriceToLong(stockEx);                          //ADD 2009/04/01 不具合対応[12837]
                        // --- ADD 2009/02/09 障害ID:11217対応------------------------------------------------------<<<<<
                        //SearchStockAcs.LogWrite("▲原価取得　終了");

                        //stockEx.SupplierSnm = unitData.SupplierSnm;
                        //stockEx.SupplierLot = unitData.SupplierLot;

                        // 検索条件と同じであれば追加
                        if (this._paraSupplierCd > 0)
                        {
                            if (this._paraSupplierCd == stockEx.SupplierCd) stockRetList.Add(stockEx);
                        }
                        else
                        {
                            // 検索条件がなければ無条件で追加
                            stockRetList.Add(stockEx);
                        }
                    }
                }
            }

            return stockRetList;
        }

        // ---ADD 2009/04/01 不具合対応[12837] ----------------------------------------->>>>>
        #region StockTotalPriceToLong(在庫金額算出)
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
            switch (this._stockMngTtlSt.FractionProcCd)
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
                        //longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);      //DEL 2009/05/01 マイナス時、端数処理不正となる為
                        // ---ADD 2009/05/01 マイナス時、端数処理不正となる為 -------------------------------------->>>>>
                        if (doubleStockTotalPrice >= 0)
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);
                        }
                        else
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice - 0.5) / 1);
                        }
                        // ---ADD 2009/05/01 マイナス時、端数処理不正となる為 --------------------------------------<<<<<
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
                            //longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);    //DEL 2009/05/01 マイナス時、端数処理不正となる為
                            // ---ADD 2009/05/01 マイナス時、端数処理不正となる為 -------------------------------------->>>>>
                            if (doubleStockTotalPrice >= 0)
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);
                            }
                            else
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice - 1) / 1);
                            }
                            // ---ADD 2009/05/01 マイナス時、端数処理不正となる為 --------------------------------------<<<<<
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
        #endregion

        #region ReadStockMngTtlSt(在庫全体管理設定読み込み)
        /// <summary>
        /// 在庫全体管理設定読み込み
        /// </summary>
        private void ReadStockMngTtlSt()
        {

            ArrayList retList;

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        this._stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                this._stockMngTtlSt = new StockMngTtlSt();
            }
        }
        #endregion
        // ---ADD 2009/04/01 不具合対応[12837] -----------------------------------------<<<<<

        /// <summary>
        /// クラスメンバーコピー処理（在庫ワークリスト⇒在庫クラス(List<T>)）
        /// </summary>
        /// <param name="workList">在庫ワークリスト</param>
        /// <returns>在庫クラス(List)</returns>
        private List<Stock> CopyToStockFromStockWork2(ArrayList workList)
        {
            // ご提案シートタイプリスト
            List<Stock> stockRetList = null;

            // 商品管理在庫クラスから仕入れ情報を取得し、ない場合は結果として返さない
            List<GoodsUnitData> unitDataList = new List<GoodsUnitData>();
            GoodsUnitData unitData = new GoodsUnitData();
            //GoodsAcs goodsAcs = new GoodsAcs(); // ddd
            Supplier supplierInfo;
            SupplierAcs supplierAcs = new SupplierAcs();
            string msg = string.Empty;

            if (workList != null)
            {
                stockRetList = new List<Stock>();
                Stock stock = null;

                foreach (StockEachWarehouseWork wrk in workList)
                {
                    //// 商品在庫管理クラスを検索
                    GoodsCndtn condition = new GoodsCndtn();
                    condition.EnterpriseCode = wrk.EnterpriseCode;
                    condition.SectionCode = wrk.SectionCode;
                    condition.GoodsMakerCd = wrk.GoodsMakerCd;
                    condition.BLGoodsCode = wrk.BLGoodsCode;
                    condition.GoodsNo = wrk.GoodsNo;
                    // 追加仕様 2008/11/06 add start
                    condition.GoodsKindCode = 9;
                    // 追加仕様 2008/11/06 add end

                    //int status = goodsAcs.Search(condition, out unitDataList, out msg);//ddd
                    int status = this._goodsAcs.Search(condition, out unitDataList, out msg);//ddd
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {

                        unitData = unitDataList[0];

                        //goodsAcs.GetGoodsMngInfo(ref unitData);
                        stock = CopyToStockExpansionFromStockEachWarehouseWork2(wrk);
                        if (unitData.SupplierCd > 0)
                        {
                            stock.SupplierCd = unitData.SupplierCd;
                            status = supplierAcs.Read(out supplierInfo, unitData.EnterpriseCode, unitData.SupplierCd);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                stock.SupplierSnm = supplierInfo.SupplierSnm;
                            }
                            else
                            {
                                stock.SupplierSnm = unitData.SupplierSnm;
                            }
                        }

                        // 標準価格
                        //GoodsPrice goodsPrice = goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, unitData.GoodsPriceList);
                        //if (goodsPrice != null)
                        //{
                        //    stock.ListPrice = goodsPrice.ListPrice;
                        //}

                        //stockEx.SupplierSnm = unitData.SupplierSnm;
                        //stockEx.SupplierLot = unitData.SupplierLot;

                        // 検索条件と同じであれば追加
                        if (this._paraSupplierCd > 0)
                        {
                            if (this._paraSupplierCd == stock.SupplierCd) stockRetList.Add(stock);
                        }
                        else
                        {
                            // 検索条件がなければ無条件で追加
                            stockRetList.Add(stock);
                        }
                    }

                    // 商品在庫管理クラスを検索
                    //unitData.EnterpriseCode = wrk.EnterpriseCode;
                    //unitData.SectionCode = wrk.SectionCode;
                    //unitData.GoodsMakerCd = wrk.GoodsMakerCd;
                    //unitData.BLGoodsCode = wrk.BLGoodsCode;
                    //unitData.GoodsNo = wrk.GoodsNo;
                    //goodsAcs.GetGoodsMngInfo(ref unitData);

                    //if (unitData.SupplierCd > 0)
                    //{
                    //    stock = CopyToStockExpansionFromStockEachWarehouseWork2(wrk);
                    //    stock.SupplierCd = unitData.SupplierCd;
                    //    stock.SupplierSnm = unitData.SupplierSnm;
                    //    stock.SupplierLot = unitData.SupplierLot;
                    //    stockRetList.Add(stock);
                    //}

                }
            }

            return stockRetList;
        }
        #endregion

        #region ●　クラスメンバーコピー処理（在庫ワーククラス⇒在庫クラス）
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// クラスメンバーコピー処理（在庫ワーククラス(在庫)⇒在庫クラス(在庫)）
        ///// </summary>
        ///// <param name="stockWork">在庫ワーククラス(在庫)</param>
        ///// <returns>在庫クラス(在庫)</returns>
        //private Stock CopyToStockFromStockWork(StockWork stockWork)
        //{
        //    Stock stock = new Stock();

        //    if (stockWork != null)
        //    {
        //        // 作成日時
        //        stock.CreateDateTime = stockWork.CreateDateTime;

        //        // 更新日時
        //        stock.UpdateDateTime = stockWork.UpdateDateTime;

        //        // 企業コード
        //        stock.EnterpriseCode = stockWork.EnterpriseCode;

        //        // GUID
        //        stock.FileHeaderGuid = stockWork.FileHeaderGuid;

        //        // 更新従業員コード
        //        stock.UpdEmployeeCode = stockWork.UpdEmployeeCode;

        //        // 更新アセンブリID1
        //        stock.UpdAssemblyId1 = stockWork.UpdAssemblyId1;

        //        // 更新アセンブリID2
        //        stock.UpdAssemblyId2 = stockWork.UpdAssemblyId2;

        //        // 論理削除区分
        //        stock.LogicalDeleteCode = stockWork.LogicalDeleteCode;

        //        // 拠点コード
        //        stock.SectionCode = stockWork.SectionCode;

        //        // メーカーコード
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //stock.MakerCode = stockWork.MakerCode;
        //        stock.GoodsMakerCd = stockWork.GoodsMakerCd;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // 商品コード
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //stock.GoodsCode = stockWork.GoodsCode;
        //        stock.GoodsNo = stockWork.GoodsNo;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // 商品名称
        //        stock.GoodsName = stockWork.GoodsName;

        //        // 仕入単価
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //stock.StockUnitPrice = stockWork.StockUnitPrice;
        //        stock.StockUnitPriceFl = stockWork.StockUnitPriceFl;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // 仕入在庫数
        //        stock.SupplierStock = stockWork.SupplierStock;

        //        // 受託数
        //        stock.TrustCount = stockWork.TrustCount;

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //// 予約数
        //        //stock.ReservedCount = stockWork.ReservedCount;

        //        //// 引当在庫数
        //        //stock.AllowStockCnt = stockWork.AllowStockCnt;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // 受注数
        //        stock.AcpOdrCount = stockWork.AcpOdrCount;

        //        // 発注数
        //        stock.SalesOrderCount = stockWork.SalesOrderCount;

        //        // 仕入在庫分委託数
        //        stock.EntrustCnt = stockWork.EntrustCnt;

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //// 受託分委託数
        //        //stock.TrustEntrustCnt = stockWork.TrustEntrustCnt;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // 売切数
        //        stock.SoldCnt = stockWork.SoldCnt;

        //        // 移動中仕入在庫数
        //        stock.MovingSupliStock = stockWork.MovingSupliStock;

        //        // 移動中受託在庫数
        //        stock.MovingTrustStock = stockWork.MovingTrustStock;

        //        // 出荷可能数
        //        stock.ShipmentPosCnt = stockWork.ShipmentPosCnt;

        //        // 在庫保有総額
        //        stock.StockTotalPrice = stockWork.StockTotalPrice;

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //// 製番管理区分
        //        //stock.PrdNumMngDiv = stockWork.PrdNumMngDiv;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // 最終仕入年月日
        //        stock.LastStockDate = stockWork.LastStockDate;

        //        // 最終売上日
        //        stock.LastSalesDate = stockWork.LastSalesDate;

        //        // 最終棚卸更新日
        //        stock.LastInventoryUpdate = stockWork.LastInventoryUpdate;

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //// 機種コード
        //        //stock.CellphoneModelCode = stockWork.CellphoneModelCode;

        //        //// 機種名称
        //        //stock.CellphoneModelName = stockWork.CellphoneModelName;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //// キャリアコード
        //        //stock.CarrierCode = stockWork.CarrierCode;

        //        //// キャリア名称
        //        //stock.CarrierName = stockWork.CarrierName;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // メーカー名称
        //        stock.MakerName = stockWork.MakerName;

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //// 系統色コード
        //        //stock.SystematicColorCd = stockWork.SystematicColorCd;

        //        //// 系統色名称
        //        //stock.SystematicColorNm = stockWork.SystematicColorNm;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        // 商品区分グループコード
        //        //stock.LargeGoodsGanreCode = stockWork.LargeGoodsGanreCode;

        //        //// 商品区分コード
        //        //stock.MediumGoodsGanreCode = stockWork.MediumGoodsGanreCode;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // 最低在庫数
        //        stock.MinimumStockCnt = stockWork.MinimumStockCnt;

        //        // 最高在庫数
        //        stock.MaximumStockCnt = stockWork.MaximumStockCnt;

        //        // 基準発注数
        //        stock.NmlSalOdrCount = stockWork.NmlSalOdrCount;

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        //// 発注単位
        //        //stock.SalOdrLot = stockWork.SalOdrLot;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //        // 倉庫コード
        //        stock.WarehouseCode = stockWork.WarehouseCode;

        //        // 倉庫名称
        //        stock.WarehouseName = stockWork.WarehouseName;

        //        // 棚番
        //        stock.WarehouseShelfNo = stockWork.WarehouseShelfNo;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //    }

        //    return stock;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.07 TOKUNAGA MODIFY START
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

                //>>>ddd メーカーマスタのReadを使用せず検索結果をしようする
                //// メーカー名称
                //_status = _makerAcs.Read(out _makerInfo, stockWork.EnterpriseCode, stockWork.GoodsMakerCd);
                //if (_status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    stock.MakerName = _makerInfo.MakerName.Trim();
                //}
                //<<<ddd

                //stock.MakerName = stockWork.MakerName;

                // 仕入単価
                stock.StockUnitPriceFl = stockWork.StockUnitPriceFl;

                // 在庫金額
                stock.StockTotalPrice = stockWork.StockTotalPrice;
                //stock.StockTotalPrice = long.Parse((stockWork.StockUnitPriceFl * stockWork.SupplierStock).ToString());

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

                //2008.10.03 stokunaga add start
                // 発注ロット
                // --- CHG 2009/02/09 障害ID:11214対応------------------------------------------------------>>>>>
                //stock.SupplierLot = stockWork.StockSupplierCode;
                // --- CHG 2009/02/09 障害ID:11214対応------------------------------------------------------<<<<<
                stock.SupplierLot = stockWork.SalesOrderUnit;
                //2008.10.03 stokunaga add end


                // 商品管理情報
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.07 TOKUNAGA ADD START
                //// 商品管理情報を取得するためにキー データをセット
                //_goodsUnitDate.SectionCode = stockWork.SectionCode;     // 拠点コード
                //_goodsUnitDate.GoodsMakerCd = stockWork.GoodsMakerCd;   // メーカーコード
                //_goodsUnitDate.GoodsNo = stockWork.GoodsNo;             // 品番
                //_goodsAcs.GetGoodsMngInfo(ref _goodsUnitDate);

                //// 発注ロット
                //stock.SupplierLot = _goodsUnitDate.SupplierLot;

                //// 仕入先コード
                //stock.SupplierCd = _goodsUnitDate.SupplierCd;

                //// 仕入先略称
                //stock.SupplierSnm = _goodsUnitDate.SupplierSnm;

                //// 標準価格を取得（基準日：検索日）
                //_goodsPrice = _goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, _goodsUnitDate.GoodsPriceList);
                //if (_goodsPrice != null)
                //{
                //    // 標準価格
                //    stock.ListPrice = _goodsPrice.ListPrice;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.07 TOKUNAGA ADD END

                // ここまで表示項目
                // 以下は整合性確保のために必要

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.07 TOKUNAGA MODIFY END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // M/O発注数
                stock.MonthOrderCount = stockWork.MonthOrderCount;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

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

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA DEL START
                //// 受託数
                ////stock.TrustCount = stockWork.TrustCount;

                //// 仕入在庫分委託数
                ////stock.EntrustCnt = stockWork.EntrustCnt;

                //// 売切数
                ////stock.SoldCnt = stockWork.SoldCnt;

                //// 移動中受託在庫数
                ////stock.MovingTrustStock = stockWork.MovingTrustStock;

                //// 在庫評価率
                ////stock.StockAssessmentRate = stockWork.StockAssessmentRate;

                //// ＢＬ商品コード名称
                //stock.BLGoodsFullName = stockWork.BLGoodsFullName;

                //// 商品区分グループコード
                //stock.LargeGoodsGanreCode = stockWork.LargeGoodsGanreCode;

                //// 商品区分グループ名称
                //stock.LargeGoodsGanreName = stockWork.LargeGoodsGanreName;

                //// 商品区分コード
                //stock.MediumGoodsGanreCode = stockWork.MediumGoodsGanreCode;

                //// 商品区分名称
                //stock.MediumGoodsGanreName = stockWork.MediumGoodsGanreName;

                //// 商品区分詳細コード
                //stock.DetailGoodsGanreCode = stockWork.DetailGoodsGanreCode;

                //// 商品区分詳細名称
                //stock.DetailGoodsGanreName = stockWork.DetailGoodsGanreName;

                //// 自社分類コード
                //stock.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;                

                //// 自社分類名称
                //stock.EnterpriseGanreName = stockWork.EnterpriseGanreName;                

                //// 価格区分（定価）
                //stock.PriceDivCd = stockWork.PriceDivCd;                

                //// 新価格（定価）
                //stock.NewPrice = stockWork.NewPrice;

                //// 新価格開始日
                //stock.NewPriceStartDate = stockWork.NewPriceStartDate;

                //// 旧価格（定価）
                //stock.OldPrice = stockWork.OldPrice;

                //// オープン価格区分
                //stock.OpenPriceDiv = stockWork.OpenPriceDiv;

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA DEL END

            }

            return stock;
        }


        /// <summary>
        /// クラスメンバーコピー処理（在庫ワーククラス(在庫)⇒商品在庫情報クラス(在庫)）
        /// </summary>
        /// <param name="stockWork">在庫ワーククラス(在庫)</param>
        /// <returns>在庫クラス(在庫)</returns>
        private Stock CopyToStockExpansionFromStockEachWarehouseWork2(StockEachWarehouseWork stockWork)
        {
            Stock stock = new Stock();

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


                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.07 TOKUNAGA MODIFY START
                // 倉庫コード
                stock.WarehouseCode = stockWork.WarehouseCode;

                // 棚番
                stock.WarehouseShelfNo = stockWork.WarehouseShelfNo;

                // メーカーコード
                stock.GoodsMakerCd = stockWork.GoodsMakerCd;

                // 品名
                //stock.GoodsName = stockWork.GoodsName;

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
                //stock.BLGoodsCode = stockWork.BLGoodsCode;

                // 品名カナ
                //stock.GoodsNameKana = stockWork.GoodsNameKana;

                // 棚番１
                stock.DuplicationShelfNo1 = stockWork.DuplicationShelfNo1;

                // 棚番２
                stock.DuplicationShelfNo2 = stockWork.DuplicationShelfNo2;

                // メーカー名称
                //_status = _makerAcs.Read(out _makerInfo, stockWork.EnterpriseCode, stockWork.GoodsMakerCd);
                //if (_status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    stock.MakerName = _makerInfo.MakerName.Trim();
                //}
                //stock.MakerName = stockWork.MakerName;

                // 仕入単価
                stock.StockUnitPriceFl = stockWork.StockUnitPriceFl;

                // 在庫金額
                stock.StockTotalPrice = stockWork.StockTotalPrice;
                //stock.StockTotalPrice = long.Parse((stockWork.StockUnitPriceFl * stockWork.SupplierStock).ToString());

                // 登録日付
                stock.StockCreateDate = stockWork.StockCreateDate;

                // 更新日付
                stock.UpdateDate = stockWork.UpdateDate;

                // 拠点コード
                stock.SectionCode = stockWork.SectionCode;

                // 拠点ガイド名称
                //stock.SectionGuideNm = stockWork.SectionGuideNm;

                // 倉庫名称
                stock.WarehouseName = stockWork.WarehouseName;

                // 商品管理情報
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.07 TOKUNAGA ADD START
                // 商品管理情報を取得するためにキー データをセット
                //_goodsUnitDate.SectionCode = stockWork.SectionCode;     // 拠点コード
                //_goodsUnitDate.GoodsMakerCd = stockWork.GoodsMakerCd;   // メーカーコード
                //_goodsUnitDate.GoodsNo = stockWork.GoodsNo;             // 品番
                //_goodsAcs.GetGoodsMngInfo(ref _goodsUnitDate);

                //// 発注ロット
                ////stock.SupplierLot = _goodsUnitDate.SupplierLot;

                //// 仕入先コード
                ////stock.SupplierCd = _goodsUnitDate.SupplierCd;

                //// 仕入先略称
                ////stock.SupplierSnm = _goodsUnitDate.SupplierSnm;

                //// 標準価格を取得（基準日：検索日）
                //_goodsPrice = _goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, _goodsUnitDate.GoodsPriceList);
                //if (_goodsPrice != null)
                //{
                //    // 標準価格
                //    //stock.ListPrice = _goodsPrice.ListPrice;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.07 TOKUNAGA ADD END

                // ここまで表示項目
                // 以下は整合性確保のために必要

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.07 TOKUNAGA MODIFY END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA ADD START
                // M/O発注数
                stock.MonthOrderCount = stockWork.MonthOrderCount;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA ADD END

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

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.06 TOKUNAGA DEL START
                //// 受託数
                ////stock.TrustCount = stockWork.TrustCount;

                //// 仕入在庫分委託数
                ////stock.EntrustCnt = stockWork.EntrustCnt;

                //// 売切数
                ////stock.SoldCnt = stockWork.SoldCnt;

                //// 移動中受託在庫数
                ////stock.MovingTrustStock = stockWork.MovingTrustStock;

                //// 在庫評価率
                ////stock.StockAssessmentRate = stockWork.StockAssessmentRate;

                //// ＢＬ商品コード名称
                //stock.BLGoodsFullName = stockWork.BLGoodsFullName;

                //// 商品区分グループコード
                //stock.LargeGoodsGanreCode = stockWork.LargeGoodsGanreCode;

                //// 商品区分グループ名称
                //stock.LargeGoodsGanreName = stockWork.LargeGoodsGanreName;

                //// 商品区分コード
                //stock.MediumGoodsGanreCode = stockWork.MediumGoodsGanreCode;

                //// 商品区分名称
                //stock.MediumGoodsGanreName = stockWork.MediumGoodsGanreName;

                //// 商品区分詳細コード
                //stock.DetailGoodsGanreCode = stockWork.DetailGoodsGanreCode;

                //// 商品区分詳細名称
                //stock.DetailGoodsGanreName = stockWork.DetailGoodsGanreName;

                //// 自社分類コード
                //stock.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;                

                //// 自社分類名称
                //stock.EnterpriseGanreName = stockWork.EnterpriseGanreName;                

                //// 価格区分（定価）
                //stock.PriceDivCd = stockWork.PriceDivCd;                

                //// 新価格（定価）
                //stock.NewPrice = stockWork.NewPrice;

                //// 新価格開始日
                //stock.NewPriceStartDate = stockWork.NewPriceStartDate;

                //// 旧価格（定価）
                //stock.OldPrice = stockWork.OldPrice;

                //// オープン価格区分
                //stock.OpenPriceDiv = stockWork.OpenPriceDiv;

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.06 TOKUNAGA DEL END

            }

            return stock;
        }
        #endregion

        #region ●　クラスメンバーコピー処理（在庫ワークリスト(倉庫毎)⇒在庫クラス(倉庫毎)(List<T>)）
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// クラスメンバーコピー処理（在庫ワークリスト⇒在庫クラス(List<T>)）
        ///// </summary>
        ///// <param name="workList">在庫ワークリスト(倉庫毎)</param>
        ///// <returns>在庫クラス(倉庫毎)(List<T>)</returns>
        //private List<StockEachWarehouse> CopyToStockEachWarehouseFromStockEachWarehouseWork(ArrayList workList)
        //{
        //    List<StockEachWarehouse> stockEachWarehouseRetList = null;

        //    if (workList != null)
        //    {
        //        stockEachWarehouseRetList = new List<StockEachWarehouse>();

        //        foreach (StockEachWarehouseWork wrk in workList)
        //        {
        //            stockEachWarehouseRetList.Add(CopyToStockEachWarehouseFromStockEachWarehouseWork(wrk));
        //        }
        //    }

        //    return stockEachWarehouseRetList;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #region ●　クラスメンバーコピー処理（在庫ワーククラス(倉庫毎)⇒在庫クラス(倉庫毎)）
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// クラスメンバーコピー処理（在庫ワーククラス(倉庫毎)⇒在庫クラス(倉庫毎)）
        ///// </summary>
        ///// <param name="stockWork">在庫ワーククラス(倉庫毎)</param>
        ///// <returns>在庫クラス(倉庫毎)</returns>
        //private StockEachWarehouse CopyToStockEachWarehouseFromStockEachWarehouseWork(StockEachWarehouseWork stockEachWarehouseWork)
        //{
        //    StockEachWarehouse stockEachWarehouse = new StockEachWarehouse();

        //    if (stockEachWarehouseWork != null)
        //    {
        //        // 作成日時
        //        stockEachWarehouse.CreateDateTime = stockEachWarehouseWork.CreateDateTime;

        //        // 更新日時
        //        stockEachWarehouse.UpdateDateTime = stockEachWarehouseWork.UpdateDateTime;

        //        // 企業コード
        //        stockEachWarehouse.EnterpriseCode = stockEachWarehouseWork.EnterpriseCode;

        //        // GUID
        //        stockEachWarehouse.FileHeaderGuid = stockEachWarehouseWork.FileHeaderGuid;

        //        // 更新従業員コード
        //        stockEachWarehouse.UpdEmployeeCode = stockEachWarehouseWork.UpdEmployeeCode;

        //        // 更新アセンブリID1
        //        stockEachWarehouse.UpdAssemblyId1 = stockEachWarehouseWork.UpdAssemblyId1;

        //        // 更新アセンブリID2
        //        stockEachWarehouse.UpdAssemblyId2 = stockEachWarehouseWork.UpdAssemblyId2;

        //        // 論理削除区分
        //        stockEachWarehouse.LogicalDeleteCode = stockEachWarehouseWork.LogicalDeleteCode;

        //        // 拠点コード
        //        stockEachWarehouse.SectionCode = stockEachWarehouseWork.SectionCode;

        //        // メーカーコード
        //        stockEachWarehouse.MakerCode = stockEachWarehouseWork.MakerCode;

        //        // 商品コード
        //        stockEachWarehouse.GoodsCode = stockEachWarehouseWork.GoodsCode;

        //        // 商品名称
        //        stockEachWarehouse.GoodsName = stockEachWarehouseWork.GoodsName;

        //        // 仕入単価
        //        stockEachWarehouse.StockUnitPrice = stockEachWarehouseWork.StockUnitPrice;

        //        // 仕入在庫数
        //        stockEachWarehouse.SupplierStock = stockEachWarehouseWork.SupplierStock;

        //        // 受託数
        //        stockEachWarehouse.TrustCount = stockEachWarehouseWork.TrustCount;

        //        // 予約数
        //        stockEachWarehouse.ReservedCount = stockEachWarehouseWork.ReservedCount;

        //        // 引当在庫数
        //        stockEachWarehouse.AllowStockCnt = stockEachWarehouseWork.AllowStockCnt;

        //        // 受注数
        //        stockEachWarehouse.AcpOdrCount = stockEachWarehouseWork.AcpOdrCount;

        //        // 発注数
        //        stockEachWarehouse.SalesOrderCount = stockEachWarehouseWork.SalesOrderCount;

        //        // 仕入在庫分委託数
        //        stockEachWarehouse.EntrustCnt = stockEachWarehouseWork.EntrustCnt;

        //        // 受託分委託数
        //        stockEachWarehouse.TrustEntrustCnt = stockEachWarehouseWork.TrustEntrustCnt;

        //        // 売切数
        //        stockEachWarehouse.SoldCnt = stockEachWarehouseWork.SoldCnt;

        //        // 移動中仕入在庫数
        //        stockEachWarehouse.MovingSupliStock = stockEachWarehouseWork.MovingSupliStock;

        //        // 移動中受託在庫数
        //        stockEachWarehouse.MovingTrustStock = stockEachWarehouseWork.MovingTrustStock;

        //        // 出荷可能数
        //        stockEachWarehouse.ShipmentPosCnt = stockEachWarehouseWork.ShipmentPosCnt;

        //        // 在庫保有総額
        //        stockEachWarehouse.StockTotalPrice = stockEachWarehouseWork.StockTotalPrice;

        //        // 製番管理区分
        //        stockEachWarehouse.PrdNumMngDiv = stockEachWarehouseWork.PrdNumMngDiv;

        //        // 最終仕入年月日
        //        stockEachWarehouse.LastStockDate = stockEachWarehouseWork.LastStockDate;

        //        // 最終売上日
        //        stockEachWarehouse.LastSalesDate = stockEachWarehouseWork.LastSalesDate;

        //        // 最終棚卸更新日
        //        stockEachWarehouse.LastInventoryUpdate = stockEachWarehouseWork.LastInventoryUpdate;

        //        // 機種コード
        //        stockEachWarehouse.CellphoneModelCode = stockEachWarehouseWork.CellphoneModelCode;

        //        // 機種名称
        //        stockEachWarehouse.CellphoneModelName = stockEachWarehouseWork.CellphoneModelName;

        //        // キャリアコード
        //        stockEachWarehouse.CarrierCode = stockEachWarehouseWork.CarrierCode;

        //        // キャリア名称
        //        stockEachWarehouse.CarrierName = stockEachWarehouseWork.CarrierName;

        //        // メーカー名称
        //        stockEachWarehouse.MakerName = stockEachWarehouseWork.MakerName;

        //        // 系統色コード
        //        stockEachWarehouse.SystematicColorCd = stockEachWarehouseWork.SystematicColorCd;

        //        // 系統色名称
        //        stockEachWarehouse.SystematicColorNm = stockEachWarehouseWork.SystematicColorNm;

        //        // 商品区分グループコード
        //        stockEachWarehouse.LargeGoodsGanreCode = stockEachWarehouseWork.LargeGoodsGanreCode;

        //        // 商品区分コード
        //        stockEachWarehouse.MediumGoodsGanreCode = stockEachWarehouseWork.MediumGoodsGanreCode;

        //        // 最低在庫数
        //        stockEachWarehouse.MinimumStockCnt = stockEachWarehouseWork.MinimumStockCnt;

        //        // 最高在庫数
        //        stockEachWarehouse.MaximumStockCnt = stockEachWarehouseWork.MaximumStockCnt;

        //        // 基準発注数
        //        stockEachWarehouse.NmlSalOdrCount = stockEachWarehouseWork.NmlSalOdrCount;

        //        // 発注単位
        //        stockEachWarehouse.SalOdrLot = stockEachWarehouseWork.SalOdrLot;

        //        // 倉庫コード
        //        stockEachWarehouse.WarehouseCode = stockEachWarehouseWork.WarehouseCode;

        //        // 倉庫名称
        //        stockEachWarehouse.WarehouseName = stockEachWarehouseWork.WarehouseName;

        //    }

        //    return stockEachWarehouse;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #region ●　クラスメンバーコピー処理（製番在庫検索抽出結果ワークリスト⇒製番在庫クラス(List<T>)）
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// クラスメンバーコピー処理（製番在庫検索抽出結果ワークリスト⇒製番在庫クラス(List<T>)）
        ///// </summary>
        ///// <param name="workList">製番在庫検索抽出結果ワークリスト</param>
        ///// <returns>製番在庫クラス(List<T>)</returns>
        //private List<ProductStock> CopyToProductStockFromProductStockWork(ArrayList workList)
        //{
        //    // ご提案シートタイプリスト
        //    List<ProductStock> productStockRetList = null;

        //    if (workList != null)
        //    {
        //        productStockRetList = new List<ProductStock>();

        //        foreach (ProductStockWork wrk in workList)
        //        {
        //            productStockRetList.Add(CopyToProductStockFromProductStockWork(wrk));
        //        }
        //    }

        //    return productStockRetList;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #region ●　クラスメンバーコピー処理（製番在庫ワーククラス⇒製番在庫クラス）
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>
        ///// クラスメンバーコピー処理（製番在庫ワーククラス⇒製番在庫クラス）
        ///// </summary>
        ///// <param name="productStockWork">製番在庫ワーククラス</param>
        ///// <returns>製番在庫クラス</returns>
        //private ProductStock CopyToProductStockFromProductStockWork(ProductStockWork productStockWork)
        //{
        //    ProductStock productStock = new ProductStock();

        //    if (productStockWork != null)
        //    {
        //        // 作成日時
        //        productStock.CreateDateTime = productStockWork.CreateDateTime;

        //        // 更新日時
        //        productStock.UpdateDateTime = productStockWork.UpdateDateTime;

        //        // 企業コード
        //        productStock.EnterpriseCode = productStockWork.EnterpriseCode;

        //        // GUID
        //        productStock.FileHeaderGuid = productStockWork.FileHeaderGuid;

        //        // 更新従業員コード
        //        productStock.UpdEmployeeCode = productStockWork.UpdEmployeeCode;

        //        // 更新アセンブリID1
        //        productStock.UpdAssemblyId1 = productStockWork.UpdAssemblyId1;

        //        // 更新アセンブリID2
        //        productStock.UpdAssemblyId2 = productStockWork.UpdAssemblyId2;

        //        // 論理削除区分
        //        productStock.LogicalDeleteCode = productStockWork.LogicalDeleteCode;

        //        // 拠点コード
        //        productStock.SectionCode = productStockWork.SectionCode;

        //        // メーカーコード
        //        productStock.MakerCode = productStockWork.MakerCode;

        //        // 商品コード
        //        productStock.GoodsCode = productStockWork.GoodsCode;

        //        // 商品名称
        //        productStock.GoodsName = productStockWork.GoodsName;

        //        // 製造番号
        //        productStock.ProductNumber = productStockWork.ProductNumber;

        //        // 製番在庫マスタGUID
        //        productStock.ProductStockGuid = productStockWork.ProductStockGuid;

        //        // 在庫区分
        //        productStock.StockDiv = productStockWork.StockDiv;

        //        // 倉庫コード
        //        productStock.WarehouseCode = productStockWork.WarehouseCode;

        //        // 倉庫名称
        //        productStock.WarehouseName = productStockWork.WarehouseName;

        //        // 事業者コード
        //        productStock.CarrierEpCode = productStockWork.CarrierEpCode;

        //        // 事業者名称
        //        productStock.CarrierEpName = productStockWork.CarrierEpName;

        //        // 得意先コード
        //        productStock.CustomerCode = productStockWork.CustomerCode;

        //        // 得意先名称
        //        productStock.CustomerName = productStockWork.CustomerName;

        //        // 得意先名称2
        //        productStock.CustomerName2 = productStockWork.CustomerName2;

        //        // 仕入日
        //        productStock.StockDate = productStockWork.StockDate;

        //        // 入荷日
        //        productStock.ArrivalGoodsDay = productStockWork.ArrivalGoodsDay;

        //        // 仕入単価
        //        productStock.StockUnitPrice = productStockWork.StockUnitPrice;

        //        // 課税区分
        //        productStock.TaxationCode = productStockWork.TaxationCode;

        //        // 在庫状態
        //        productStock.StockState = productStockWork.StockState;

        //        // 移動状態
        //        productStock.MoveStatus = productStockWork.MoveStatus;

        //        // 商品状態
        //        productStock.GoodsCodeStatus = productStockWork.GoodsCodeStatus;

        //        // 商品電話番号1
        //        productStock.StockTelNo1 = productStockWork.StockTelNo1;

        //        // 商品電話番号2
        //        productStock.StockTelNo2 = productStockWork.StockTelNo2;

        //        // ロム区分
        //        productStock.RomDiv = productStockWork.RomDiv;

        //        // 機種コード
        //        productStock.CellphoneModelCode = productStockWork.CellphoneModelCode;

        //        // 機種名称
        //        productStock.CellphoneModelName = productStockWork.CellphoneModelName;

        //        // キャリアコード
        //        productStock.CarrierCode = productStockWork.CarrierCode;

        //        // キャリア名称
        //        productStock.CarrierName = productStockWork.CarrierName;

        //        // メーカー名称
        //        productStock.MakerName = productStockWork.MakerName;

        //        // 系統色コード
        //        productStock.SystematicColorCd = productStockWork.SystematicColorCd;

        //        // 系統色名称
        //        productStock.SystematicColorNm = productStockWork.SystematicColorNm;

        //        // 商品区分グループコード
        //        productStock.LargeGoodsGanreCode = productStockWork.LargeGoodsGanreCode;

        //        // 商品区分コード
        //        productStock.MediumGoodsGanreCode = productStockWork.MediumGoodsGanreCode;

        //        // 出荷先得意先コード
        //        productStock.ShipCustomerCode = productStockWork.ShipCustomerCode;

        //        // 出荷先得意先名称
        //        productStock.ShipCustomerName = productStockWork.ShipCustomerName;

        //        // 出荷得意先名称2
        //        productStock.ShipCustomerName2 = productStockWork.ShipCustomerName2;
        //    }

        //    return productStock;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #region ●　在庫プライマリーキー情報取得

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

        #endregion

        #endregion

        #endregion

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

        // ===============================================================================
        // ガイド
        // ===============================================================================
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        #region ●　（ユーザーガイド）自社分類取得
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="enterpriseGanreCode"></param>
        /// <param name="userGdBd"></param>
        /// <returns></returns>
        public int GetEnterpriseGanreCode(string enterpriseCode, int enterpriseGanreCode, out UserGdBd userGdBd)
        {
            //..保留　↓ガイド区分コードが決定したらセットする
            int userGuideDivCd = 91;
            //..保留　↑ガイド区分コードが決定したらセットする

            UserGuideAcsData acsData = UserGuideAcsData.MergeBodyData;
            int status = this._userGuideAcs.ReadBody(out userGdBd, enterpriseCode, userGuideDivCd, enterpriseGanreCode, ref acsData);

            return status;
        }
        #endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        #region ●　（ユーザーガイド）自社分類ガイド関連
        /// <summary>
        /// （ユーザーガイド）自社分類ガイド表示
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="userGdBd"></param>
        /// <returns></returns>
        public int ExecuteUserGuideGuid(string enterpriseCode, out UserGdBd userGdBd)
        {
            int status = -1;
            userGdBd = new UserGdBd();

            TableGuideParent tableGuideParent = new TableGuideParent("ENTERPRISEGANREGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                userGdBd.EnterpriseCode = retObj["EnterpriseCode"].ToString();
                userGdBd.GuideCode = Int32.Parse(retObj["GuideCode"].ToString());
                userGdBd.GuideName = retObj["GuideName"].ToString();
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }
        /// <summary>
        /// ガイドデータ抽出
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns></returns>
        public int GetGuideData(int mode, Hashtable inParm, ref System.Data.DataSet guideList)
        {
            int userGuideDivCd = 41;

            //---------------------------------------------
            // ガイドデータ抽出
            //---------------------------------------------
            if (_userGdBdList == null)
            {
                _userGdBdList = new ArrayList();

                try
                {
                    //this._userGuideAcs.SearchBody(out _userGdBdList, LoginInfoAcquisition.EnterpriseCode, UserGuideAcsData.MergeBodyData, userGuideDivCd);            
                    this._userGuideAcs.SearchDivCodeBody(out _userGdBdList, LoginInfoAcquisition.EnterpriseCode, userGuideDivCd, UserGuideAcsData.MergeBodyData);
                }
                catch
                {
                }
            }
            //---------------------------------------------
            // ガイドＵＩにセット
            //---------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            //if ( _userGdBdList == null || _userGdBdList.Count == 0 )
            if (_userGdBdList == null)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else
            {
                DataTable table = new DataTable();

                try
                {
                    // Declare DataColumn and DataRow variables.
                    DataColumn column;
                    DataRow row;

                    // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "EnterpriseCode";
                    table.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Int32");
                    column.ColumnName = "GuideCode";
                    table.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "GuideName";
                    table.Columns.Add(column);

                    table.BeginLoadData();

                    foreach (UserGdBd kv in _userGdBdList)
                    {
                        if (userGuideDivCd != kv.UserGuideDivCd) continue;

                        row = table.NewRow();

                        row["EnterpriseCode"] = kv.EnterpriseCode;
                        row["GuideCode"] = kv.GuideCode;
                        row["GuideName"] = kv.GuideName;

                        table.Rows.Add(row);
                    }

                    table.EndLoadData();


                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                finally
                {
                    guideList.Tables.Add(table);
                }
            }

            return status;
        }

        #endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //--- ADD 2011/07/07 ----->>>>>
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
            _extractCancelFlag = true;
            if (_processingDialog != null)
            {
                _processingDialog.Message = "中断します。";
            }
        }
        //--- ADD 2011/07/07 -----<<<<<
    }
}
