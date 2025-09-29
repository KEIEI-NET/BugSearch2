using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫実績照会アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 在庫実績照会アクセスクラス</br>
    /// <br>Programmer  : 30350 櫻井 亮太</br>
    /// <br>Date        : 2008/11/25</br>
    /// <br>Update Note : 2009/07/27 王増喜 テキスト出力対応</br>
    /// <br>Update Note : 2010/09/08 楊明俊</br>
    /// <br>            ・障害ID:14444 テキスト出力対応</br>
    /// </remarks>
    public class StockHistoryDspAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IStockHisDspDB _iStockHistDspDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// 在庫実績照会アクセスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 在庫実績照会アクセスクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// 
        /// </remarks>
        public StockHistoryDspAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iStockHistDspDB = (IStockHisDspDB)MediationStockHisDspDB.GetStockHisDspDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iStockHistDspDB = null;
            }

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="extrInfo">検索条件</param>
        /// <param name="updHisDspWorkList">検索結果リスト</param>
        /// <returns>ステータス</returns>
        public int Search(StockHistoryDspSearchParam extrInfo, out List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
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
                status = this._iStockHistDspDB.Search(out retObj, paraObj);
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

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="extrInfo">検索条件</param>
        /// <param name="updHisDspWorkList">検索結果リスト</param>
        /// <returns>ステータス</returns>
        public int SearchAll(StockHistoryDspSearchParam extrInfo, out List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
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
                status = this._iStockHistDspDB.SearchAll(out retObj, paraObj);
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
            catch(Exception ex)
            {
                status = -1;
                stockHistoryDspSearchResultList = new List<StockHistoryDspSearchResult>();
            }

            return (status);
        }
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

        #endregion Public Methods


        #region Private Methods


        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="para">出荷部品表示条件クラス</param>
        /// <returns>出荷部品表示条件ワーククラス</returns>
        private StockHistoryDspSearchParamWork CopyToStockHistoryDspSearchParamWorkFromShipmentPartsDspParam(StockHistoryDspSearchParam para)
        {
            StockHistoryDspSearchParamWork paraWork = new StockHistoryDspSearchParamWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.GoodsNo = para.GoodsNo;
            paraWork.GoodsMakerCd = para.GoodsMakerCd;
            paraWork.WarehouseCode = para.WarehouseCode;
            paraWork.StAddUpYearMonth = para.StAddUpYearMonth;
            paraWork.EdAddUpYearMonth = para.EdAddUpYearMonth;
            paraWork.StAddUpADate = para.StAddUpDate;
            paraWork.EdAddUpADate = para.EdAddUpDate;
            paraWork.SectionCodes = new string[1];
            paraWork.SectionCodes[0] = para.SectionCode;
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            paraWork.WarehouseCodeList = para.WarehouseCodeList;
            paraWork.WarehouseShelfNoList = para.WarehouseShelfNoList;
            paraWork.BlGoodsCodeList = para.BlGoodsCodeList;
            paraWork.GoodsNoList = para.GoodsNoList;
            paraWork.MakerCodeList = para.MakerCodeList;
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="retWork">出荷部品表示結果ワーククラス</param>
        /// <returns>出荷部品表示結果クラス</returns>
        /// <br>Update Note : 2010/09/08 楊明俊</br>
        /// <br>            ・障害ID:14444 テキスト出力対応</br>
        private StockHistoryDspSearchResult CopyToStockHistoryDspSearchResultFromShipmentPartsDspResultWork(StockHistoryDspSearchResultWork retWork)
        {
            StockHistoryDspSearchResult ret = new StockHistoryDspSearchResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.AddUpYearMonth = retWork.AddUpYearMonth;
            // --- UPD 2010/09/08-------------------------------->>>>>
            //ret.WarehouseCode = retWork.WarehouseCode;
            ret.WarehouseCode = retWork.WarehouseCode.Trim();
            // --- UPD 2010/09/08--------------------------------<<<<<
            ret.GoodsNo = retWork.GoodsNo;
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            ret.GoodsName = retWork.GoodsName;
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            ret.GoodsMakerCd = retWork.GoodsMakerCd;
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            ret.WarehouseShelfNo= retWork.WarehouseShelfNo;
            ret.BlGoodsCode = retWork.BlGoodsCode;
            ret.StockCreateDate = retWork.StockCreateDate;
            ret.LastSalesDate = retWork.LastSalesDate;
            ret.LastStockDate = retWork.LastStockDate;
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
            ret.SalesTimes = retWork.SalesTimes;
            ret.SalesCount = retWork.SalesCount;
            ret.SalesMoneyTaxExc = retWork.SalesMoneyTaxExc;
            ret.StockTimes = retWork.StockTimes;
            ret.StockCount = retWork.StockCount;
            ret.StockPriceTaxExc = retWork.StockPriceTaxExc;
            ret.GrossProfit = retWork.GrossProfit;
            ret.MoveArrivalCnt = retWork.MoveArrivalCnt;
            ret.MoveArrivalPrice = retWork.MoveArrivalPrice;
            ret.MoveShipmentCnt = retWork.MoveShipmentCnt;
            ret.MoveShipmentPrice = retWork.MoveShipmentPrice;
            ret.SearchDiv = retWork.SearchDiv;

            return ret;
        }

        #endregion Private Methods
    }
}
