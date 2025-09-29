//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10806793-00  作成担当 : 田建委
// 修 正 日  2012/12/13  修正内容 : 2013/03/13配信分  Redmine#33835
//                                  出荷回数を追加する対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫マスタ処理スクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ処理です。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2010/08/11</br>
    /// <br>Update Note: 2012/12/13 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33835 出荷回数を追加する対応</br>
    /// </remarks>
    public class StockMstAcs
    {
        #region ◆Private Members
        private static StockMstAcs _stockMstAcs;
        /// <summary>結合リモートオブジェクト格納バッファ</summary>
        private IStockMstDB _stockMstDB;
        private IGoodsUDB _goodsUDB;
        #endregion

        #region ◆Constructor 
        /// <summary>
        /// 在庫マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタアクセスクラスコンストラクタ。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        public StockMstAcs()
        {
            try
            {
                // 結合マスタリモートオブジェクト取得
                this._stockMstDB = (IStockMstDB)MediationStockMstDB.GetStockMstDB();

            }
            catch (Exception)
            {
                this._stockMstDB = null;
            }
        }
        #endregion

        #region ■ 在庫マスタアクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// 在庫マスタアクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタアクセスクラス インスタンス取得処理。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>在庫マスタアクセスクラス インスタンス</returns>
        public static StockMstAcs GetInstance()
        {
            if (_stockMstAcs == null)
            {
                _stockMstAcs = new StockMstAcs();
            }

            return _stockMstAcs;
        }
        #endregion

        #region ◆Public Methods
        /// <summary>
        /// 在庫マスタ検索処理
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">ﾒｰｶｰ</param>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 在庫マスタ検索処理。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int SearchStockInfo(string enterPriseCode, string goodsNo, Int32 goodsMakerCd, out ArrayList stockList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList stockRemoteList = new ArrayList();

            status = this._stockMstDB.SearchStockInfo(enterPriseCode, goodsNo, goodsMakerCd, out stockRemoteList, out retMessage);

            stockList = new ArrayList();
            Stock _stock = null;

            foreach (StockWork _stockWork in stockRemoteList)
            {
                _stock = new Stock();

                _stock.CreateDateTime = _stockWork.CreateDateTime;
                _stock.UpdateDateTime = _stockWork.UpdateDateTime;
                _stock.EnterpriseCode = _stockWork.EnterpriseCode;
                _stock.FileHeaderGuid = _stockWork.FileHeaderGuid;
                _stock.UpdEmployeeCode = _stockWork.UpdEmployeeCode;
                _stock.UpdAssemblyId1 = _stockWork.UpdAssemblyId1;
                _stock.UpdAssemblyId2 = _stockWork.UpdAssemblyId2;
                _stock.LogicalDeleteCode = _stockWork.LogicalDeleteCode;
                _stock.SectionCode = _stockWork.SectionCode;
                _stock.WarehouseCode = _stockWork.WarehouseCode;
                _stock.GoodsMakerCd = _stockWork.GoodsMakerCd;
                _stock.GoodsNo = _stockWork.GoodsNo;
                _stock.StockUnitPriceFl = _stockWork.StockUnitPriceFl;
                _stock.SupplierStock = _stockWork.SupplierStock;
                _stock.AcpOdrCount = _stockWork.AcpOdrCount;
                _stock.MonthOrderCount = _stockWork.MonthOrderCount;
                _stock.SalesOrderCount = _stockWork.SalesOrderCount;
                _stock.StockDiv = _stockWork.StockDiv;
                _stock.MovingSupliStock = _stockWork.MovingSupliStock;
                _stock.ShipmentPosCnt = _stockWork.ShipmentPosCnt;
                _stock.StockTotalPrice = _stockWork.StockTotalPrice;
                _stock.LastStockDate = _stockWork.LastStockDate;
                _stock.LastSalesDate = _stockWork.LastSalesDate;
                _stock.LastInventoryUpdate = _stockWork.LastInventoryUpdate;
                _stock.MinimumStockCnt = _stockWork.MinimumStockCnt;
                _stock.MaximumStockCnt = _stockWork.MaximumStockCnt;
                _stock.NmlSalOdrCount = _stockWork.NmlSalOdrCount;
                _stock.SalesOrderUnit = _stockWork.SalesOrderUnit;
                _stock.StockSupplierCode = _stockWork.StockSupplierCode;
                _stock.GoodsNoNoneHyphen = _stockWork.GoodsNoNoneHyphen;
                _stock.WarehouseShelfNo = _stockWork.WarehouseShelfNo;
                _stock.DuplicationShelfNo1 = _stockWork.DuplicationShelfNo1;
                _stock.DuplicationShelfNo2 = _stockWork.DuplicationShelfNo2;
                _stock.PartsManagementDivide1 = _stockWork.PartsManagementDivide1;
                _stock.PartsManagementDivide2 = _stockWork.PartsManagementDivide2;
                _stock.StockNote1 = _stockWork.StockNote1;
                _stock.StockNote2 = _stockWork.StockNote2;
                _stock.ShipmentCnt = _stockWork.ShipmentCnt;
                _stock.ArrivalCnt = _stockWork.ArrivalCnt;
                _stock.StockCreateDate = _stockWork.StockCreateDate;
                _stock.UpdateDate = _stockWork.UpdateDate;
                stockList.Add(_stock);
            }

            return status;
        }

        //----- ADD 2012/12/13 田建委 Redmine#33835 ------------->>>>>
        /// <summary>
        /// 出荷回数検索処理
        /// </summary>
        /// <param name="extrInfo">検索条件</param>
        /// <param name="updHisDspWorkList">検索結果リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 出荷回数検索処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        public int SearchStockHisDsp(StockHistoryDspSearchParam extrInfo, out List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList paraList = new ArrayList();

            stockHistoryDspSearchResultList = new List<StockHistoryDspSearchResult>();

            // クラスメンバコピー処理(E→D)
            StockHistoryDspSearchParamWork paraWork = CopyToStockHistoryDspSearchParamWorkFromShipmentPartsDspParam(extrInfo);

            paraList.Add(paraWork);
            ArrayList retList;

            object paraObj = paraList;
            object retObj;

            try
            {
                status = this._stockMstDB.SearchStockHisDsp(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (StockHistoryDspSearchResultWork retWork in retList)
                    {
                        // クラスメンバコピー処理(D→E)
                        stockHistoryDspSearchResultList.Add(CopyToStockHistoryDspSearchResultFromShipmentPartsDspResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = -1;
                stockHistoryDspSearchResultList = new List<StockHistoryDspSearchResult>();
            }

            return (status);
        }

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="para">出荷部品表示条件クラス</param>
        /// <returns>出荷部品表示条件ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバコピー処理(E→D)を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private StockHistoryDspSearchParamWork CopyToStockHistoryDspSearchParamWorkFromShipmentPartsDspParam(StockHistoryDspSearchParam para)
        {
            StockHistoryDspSearchParamWork paraWork = new StockHistoryDspSearchParamWork();

            // 企業コード
            paraWork.EnterpriseCode = para.EnterpriseCode;
            // 品番
            paraWork.GoodsNo = para.GoodsNo;
            //メーカー
            paraWork.GoodsMakerCd = para.GoodsMakerCd;
            // 倉庫コード
            paraWork.WarehouseCode = para.WarehouseCode;
            // 開始年月
            paraWork.StAddUpYearMonth = para.StAddUpYearMonth;
            // 終了年月
            paraWork.EdAddUpYearMonth = para.EdAddUpYearMonth;
            // 開始年月日
            paraWork.StAddUpADate = para.StAddUpDate;
            // 終了年月日
            paraWork.EdAddUpADate = para.EdAddUpDate;

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="retWork">出荷部品表示結果ワーククラス</param>
        /// <returns>出荷部品表示結果クラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバコピー処理(D→E)を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private StockHistoryDspSearchResult CopyToStockHistoryDspSearchResultFromShipmentPartsDspResultWork(StockHistoryDspSearchResultWork retWork)
        {
            StockHistoryDspSearchResult ret = new StockHistoryDspSearchResult();

            // 企業コード
            ret.EnterpriseCode = retWork.EnterpriseCode;
            // 計上年月
            ret.AddUpYearMonth = retWork.AddUpYearMonth;
            // 倉庫コード
            ret.WarehouseCode = retWork.WarehouseCode.Trim();
            // 品番
            ret.GoodsNo = retWork.GoodsNo;
            //メーカー
            ret.GoodsMakerCd = retWork.GoodsMakerCd;
            // 出荷回数
            ret.SalesTimes = retWork.SalesTimes;

            return ret;
        }
        //----- ADD 2012/12/13 田建委 Redmine#33835 -------------<<<<<

        /// <summary>
        /// 商品マスタ検索処理「品名の取得」
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">ﾒｰｶｰ</param>
        /// <param name="goodsUWork">商品リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ検索処理「品名の取得」。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int SearchGoodsUInfo(string enterPriseCode, string goodsNo, Int32 goodsMakerCd, out GoodsUWork goodsUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object goodsUObj = new object();

            GoodsUWork goodsUCond = new GoodsUWork();
            goodsUCond.EnterpriseCode = enterPriseCode;
            goodsUCond.GoodsNo = goodsNo;
            goodsUCond.GoodsMakerCd = goodsMakerCd;
            goodsUCond.LogicalDeleteCode = 0;

            object goodsUCondObj = (object)goodsUCond;

            // サーバーユーザーデータ
            if (this._goodsUDB == null)
            {
                this._goodsUDB = MediationGoodsUDB.GetGoodsUDB();
            }

            status = this._goodsUDB.Search(out goodsUObj, goodsUCondObj, 0, ConstantManagement.LogicalMode.GetData0);

            if (goodsUObj != null)
            {
                goodsUWork = goodsUObj as GoodsUWork;
            }
            else
            {
                goodsUWork = null;
            }

            return status;
        }

        /// <summary>
        /// 在庫マスタ保存処理
        /// </summary>
        /// <param name="retStock">在庫データ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ保存処理。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int SaveStockInfo(Stock retStock, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 保存データ
            ArrayList stockList = new ArrayList();
            StockWork _stockWork = new StockWork();
            _stockWork.EnterpriseCode = retStock.EnterpriseCode;
            _stockWork.SectionCode = retStock.SectionCode;
            _stockWork.WarehouseCode = retStock.WarehouseCode;
            _stockWork.GoodsMakerCd = retStock.GoodsMakerCd;
            _stockWork.GoodsNo = retStock.GoodsNo;
            _stockWork.StockUnitPriceFl = retStock.StockUnitPriceFl;
            _stockWork.SupplierStock = retStock.SupplierStock;
            _stockWork.AcpOdrCount = retStock.AcpOdrCount;
            _stockWork.SalesOrderCount = retStock.SalesOrderCount;
            _stockWork.StockDiv = retStock.StockDiv;
            _stockWork.MovingSupliStock = retStock.MovingSupliStock;
            _stockWork.ShipmentPosCnt = retStock.ShipmentPosCnt;
            _stockWork.LastStockDate = retStock.LastStockDate;
            _stockWork.LastSalesDate = retStock.LastSalesDate;
            _stockWork.MinimumStockCnt = retStock.MinimumStockCnt;
            _stockWork.MaximumStockCnt = retStock.MaximumStockCnt;
            _stockWork.SalesOrderUnit = retStock.SalesOrderUnit;
            _stockWork.StockSupplierCode = retStock.StockSupplierCode;
            _stockWork.GoodsNoNoneHyphen = retStock.GoodsNoNoneHyphen;
            _stockWork.WarehouseShelfNo = retStock.WarehouseShelfNo;
            _stockWork.DuplicationShelfNo1 = retStock.DuplicationShelfNo1;
            _stockWork.DuplicationShelfNo2 = retStock.DuplicationShelfNo2;
            _stockWork.PartsManagementDivide1 = retStock.PartsManagementDivide1;
            _stockWork.PartsManagementDivide2 = retStock.PartsManagementDivide2;
            _stockWork.StockNote1 = retStock.StockNote1;
            _stockWork.StockNote2 = retStock.StockNote2;
            _stockWork.ShipmentCnt = retStock.ShipmentCnt;
            _stockWork.ArrivalCnt = retStock.ArrivalCnt;
            _stockWork.StockCreateDate = retStock.StockCreateDate;
            _stockWork.UpdateDate = retStock.UpdateDate;
            _stockWork.UpdateDateTime = retStock.UpdateDateTime;
            stockList.Add(_stockWork);

            status = this._stockMstDB.Write(stockList, out retMessage);

            return status;
        }

        /// <summary>
        /// 在庫マスタ論理削除処理
        /// </summary>
        /// <param name="retStock">在庫データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ論理削除処理。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int LogicalDelete(Stock retStock)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 保存データ
            ArrayList stockList = new ArrayList();
            StockWork _stockWork = new StockWork();
            _stockWork.EnterpriseCode = retStock.EnterpriseCode;
            _stockWork.WarehouseCode = retStock.WarehouseCode;
            _stockWork.GoodsMakerCd = retStock.GoodsMakerCd;
            _stockWork.GoodsNo = retStock.GoodsNo;
            _stockWork.UpdateDateTime = retStock.UpdateDateTime;
            stockList.Add(_stockWork);

            status = this._stockMstDB.LogicalDelete(ref stockList);

            return status;
        }

        /// <summary>
        /// 在庫マスタ復活処理
        /// </summary>
        /// <param name="retStock">在庫データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ復活処理。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int RevivalLogicalDelete(ref Stock retStock )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 保存データ
            ArrayList stockList = new ArrayList();
            StockWork _stockWork = new StockWork();
            _stockWork.EnterpriseCode = retStock.EnterpriseCode;
            _stockWork.WarehouseCode = retStock.WarehouseCode;
            _stockWork.GoodsMakerCd = retStock.GoodsMakerCd;
            _stockWork.GoodsNo = retStock.GoodsNo;
            _stockWork.UpdateDateTime = retStock.UpdateDateTime;
            stockList.Add(_stockWork);

            status = this._stockMstDB.RevivalLogicalDelete(ref stockList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockList != null && stockList.Count > 0)
                {
                    StockWork  stockWork = (StockWork)stockList[0];
                    retStock.UpdateDateTime = stockWork.UpdateDateTime;
                    retStock.UpdEmployeeCode = stockWork.UpdEmployeeCode; // ADD 2010/09/06
                    retStock.UpdAssemblyId1 = stockWork.UpdAssemblyId1; // ADD 2010/09/06
                    retStock.UpdAssemblyId2 = stockWork.UpdAssemblyId2; // ADD 2010/09/06
                    retStock.LogicalDeleteCode = stockWork.LogicalDeleteCode; // ADD 2010/09/06
                    retStock.SupplierStock = stockWork.SupplierStock; // ADD 2010/09/06
                }
            }

            return status;
        }

        /// <summary>
        /// 在庫マスタ完全削除処理
        /// </summary>
        /// <param name="retStock">在庫データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタ完全削除処理。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        /// <returns>STATUS</returns>
        public int Delete(Stock retStock)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 保存データ
            ArrayList stockList = new ArrayList();
            StockWork _stockWork = new StockWork();
            _stockWork.EnterpriseCode = retStock.EnterpriseCode;
            _stockWork.WarehouseCode = retStock.WarehouseCode;
            _stockWork.GoodsMakerCd = retStock.GoodsMakerCd;
            _stockWork.GoodsNo = retStock.GoodsNo;
            _stockWork.UpdateDateTime = retStock.UpdateDateTime;
            stockList.Add(_stockWork);

            status = this._stockMstDB.Delete(stockList);

            return status;
        }
        #endregion
    }
}
