//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（エクスポート）
// プログラム概要   : 在庫マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 在庫マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 李占川</br>
	/// <br>Date       : 2009.05.14</br>
	/// <br></br>
    /// </remarks>
	public class StockSetExpAcs 
	{

        private static bool _isLocalDBRead = false;

        /// <summary>商品セットリモートオブジェクト格納バッファ</summary>
        private IStockDB _iStockDB;

        private MakerAcs _makerAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 在庫マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public StockSetExpAcs()
		{
            this._iStockDB = (IStockDB)MediationStockDB.GetStockDB();
            this._makerAcs = new MakerAcs();
        }

        /// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

		/// <summary>
        /// 在庫マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="stockExpWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 在庫マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, StockExpWork stockExpWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, stockExpWork);
        }

		/// <summary>
        /// 在庫マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="stockExpWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 在庫マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, StockExpWork stockExpWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, stockExpWork);
        }

		/// <summary>
        /// 在庫マスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="stockExpWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 在庫マスタ検索処理を行います。</br>
		/// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, StockExpWork stockExpWork)
        {
            StockWork paraStockWork = new StockWork();

            paraStockWork.EnterpriseCode = enterpriseCode;

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;
            nextData = false;
            retTotalCnt = 0;

            // 検索結果
            retList = new ArrayList();
            retList.Clear();

            ArrayList resultList = new ArrayList();
            resultList.Clear();

            object paraobj = paraStockWork;
            object retobj = new ArrayList();

            status = this._iStockDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                resultList = retobj as ArrayList;
                foreach (StockWork stockWork in resultList)
                {
                    // 抽出処理
                    checkstatus = DataCheck(stockWork, stockExpWork);
                    if (checkstatus == 0)
                    {
                        //ＢＬグループ情報クラスへメンバコピー
                        retList.Add(CopyToStockSetExpFromStockWork(stockWork, enterpriseCode));
                    }
                }
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（在庫マスタワーククラス⇒在庫マスタクラス）
        /// </summary>
        /// <param name="stockWork">在庫マスタワーククラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>在庫マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタワーククラスから在庫マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private StockSetExp CopyToStockSetExpFromStockWork(StockWork stockWork, string enterpriseCode)
        {
            StockSetExp stockSetExp = new StockSetExp();

            stockSetExp.SectionCode = stockWork.SectionCode;
            stockSetExp.WarehouseCode = stockWork.WarehouseCode;
            stockSetExp.GoodsMakerCd = stockWork.GoodsMakerCd;
            stockSetExp.GoodsNo = stockWork.GoodsNo;
            stockSetExp.StockUnitPriceFl = stockWork.StockUnitPriceFl;
            stockSetExp.SupplierStock = stockWork.SupplierStock;
            stockSetExp.AcpOdrCount = stockWork.AcpOdrCount;
            stockSetExp.MonthOrderCount = stockWork.MonthOrderCount;
            stockSetExp.SalesOrderCount = stockWork.SalesOrderCount;
            stockSetExp.StockDiv = stockWork.StockDiv;
            stockSetExp.MovingSupliStock = stockWork.MovingSupliStock;
            stockSetExp.ShipmentPosCnt = stockWork.ShipmentPosCnt;
            stockSetExp.StockTotalPrice = stockWork.StockTotalPrice;
            stockSetExp.LastStockDate = stockWork.LastStockDate;
            stockSetExp.LastSalesDate = stockWork.LastSalesDate;
            stockSetExp.LastInventoryUpdate = stockWork.LastInventoryUpdate;
            stockSetExp.MinimumStockCnt = stockWork.MinimumStockCnt;
            stockSetExp.MaximumStockCnt = stockWork.MaximumStockCnt;
            stockSetExp.NmlSalOdrCount = stockWork.NmlSalOdrCount;
            stockSetExp.SalesOrderUnit = stockWork.SalesOrderUnit;
            stockSetExp.StockSupplierCode = stockWork.StockSupplierCode;
            stockSetExp.GoodsNoNoneHyphen = stockWork.GoodsNoNoneHyphen;
            stockSetExp.WarehouseShelfNo = stockWork.WarehouseShelfNo;
            stockSetExp.DuplicationShelfNo1 = stockWork.DuplicationShelfNo1;
            stockSetExp.DuplicationShelfNo2 = stockWork.DuplicationShelfNo2;
            stockSetExp.PartsManagementDivide1 = stockWork.PartsManagementDivide1;
            stockSetExp.PartsManagementDivide2 = stockWork.PartsManagementDivide2;
            stockSetExp.StockNote1 = stockWork.StockNote1;
            stockSetExp.StockNote2 = stockWork.StockNote2;
            stockSetExp.ShipmentCnt = stockWork.ShipmentCnt;
            stockSetExp.ArrivalCnt = stockWork.ArrivalCnt;

            return stockSetExp;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="stockWork">検索結果</param>
        /// <param name="stockExpWork">抽出条件</param>
        /// <returns></returns>
        private int DataCheck(StockWork stockWork, StockExpWork stockExpWork)
        {
            int status = 0;

            // 論理削除区分
            if (stockWork.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // 倉庫コード
            if (!stockExpWork.WarehouseCodeSt.Trim().Equals(string.Empty) &&
                !stockExpWork.WarehouseCodeEd.Trim().Equals(string.Empty))
            {
                if (stockExpWork.WarehouseCodeSt.CompareTo(stockWork.WarehouseCode.Trim()) > 0 ||
                    stockExpWork.WarehouseCodeEd.CompareTo(stockWork.WarehouseCode.Trim()) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!stockExpWork.WarehouseCodeSt.Trim().Equals(string.Empty))
            {
                if (stockExpWork.WarehouseCodeSt.CompareTo(stockWork.WarehouseCode.Trim()) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!stockExpWork.WarehouseCodeEd.Trim().Equals(string.Empty))
            {
                if (stockExpWork.WarehouseCodeEd.CompareTo(stockWork.WarehouseCode.Trim()) < 0)
                {
                    status = -1;
                    return status;
                }
            }

            // 商品メーカーコード
            if (stockExpWork.GoodsMakerCdSt != 0 &&
                stockExpWork.GoodsMakerCdEd != 0)
            {
                if (stockWork.GoodsMakerCd < stockExpWork.GoodsMakerCdSt ||
                   stockWork.GoodsMakerCd > stockExpWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (stockExpWork.GoodsMakerCdSt != 0)
            {
                if (stockWork.GoodsMakerCd < stockExpWork.GoodsMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (stockExpWork.GoodsMakerCdEd != 0)
            {
                if (stockWork.GoodsMakerCd > stockExpWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            // 商品番号
            if (!stockExpWork.GoodsNoSt.Trim().Equals(string.Empty) &&
                !stockExpWork.GoodsNoEd.Trim().Equals(string.Empty))
            {
                if (stockExpWork.GoodsNoSt.CompareTo(stockWork.GoodsNo.Trim()) > 0 ||
                    stockExpWork.GoodsNoEd.CompareTo(stockWork.GoodsNo.Trim()) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!stockExpWork.GoodsNoSt.Trim().Equals(string.Empty))
            {
                if (stockExpWork.GoodsNoSt.CompareTo(stockWork.GoodsNo.Trim()) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!stockExpWork.GoodsNoEd.Trim().Equals(string.Empty))
            {
                if (stockExpWork.GoodsNoEd.CompareTo(stockWork.GoodsNo.Trim()) < 0)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
