//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタメンテナンス
// プログラム概要   : 発注点設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注点設定マスタメンテナンスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタメンテナンスのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.03.31</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class OrderPointStAcs
    {
        # region -- リモートオブジェクト格納バッファ --
        private IOrderPointStDB _iOrderPointStDB = null;
        # endregion

        # region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public OrderPointStAcs()
        {
            // リモートオブジェクト取得
            this._iOrderPointStDB = (IOrderPointStDB)MediationOrderPointStDB.GetOrderPointStDB();
        }
        # endregion

        # region -- 検索処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="patterNo">設定コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public int Search(out List<OrderPointSt> retList, int patterNo, string enterpriseCode)
        {
            OrderPointStWork orderPointStWork = new OrderPointStWork();

            orderPointStWork.PatterNo = patterNo;
            orderPointStWork.EnterpriseCode = enterpriseCode;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<OrderPointSt>();

            object paraobj = orderPointStWork;
            object retobj = null;

            ArrayList orderPointStWorkList = new ArrayList();
            orderPointStWorkList.Clear();

            status = this._iOrderPointStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                orderPointStWorkList = retobj as ArrayList;

                foreach (OrderPointStWork orderPointStWorkTemp in orderPointStWorkList)
                {
                    retList.Add(CopyToOrderPointStFromOrderPointStWork(orderPointStWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }
        # endregion

        # region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="orderPointStList">UIデータList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public int Write(ref List<OrderPointSt> orderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;;

            ArrayList orderPointStWorkList = new ArrayList();

            foreach (OrderPointSt orderPointSt in orderPointStList)
            {
                // UIデータクラス→ワーク
                OrderPointStWork orderPointStWork = CopyToOrderPointStWorkFromOrderPointSt(orderPointSt);

                orderPointStWorkList.Add(orderPointStWork);
            }

            object paraObj = orderPointStWorkList;

            status = this._iOrderPointStDB.Write(ref paraObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                orderPointStWorkList = paraObj as ArrayList;

                orderPointStList.Clear();
                foreach (OrderPointStWork orderPointStWork in orderPointStWorkList)
                {
                    // ワーク→UIデータクラス
                    OrderPointSt orderPointSt = CopyToOrderPointStFromOrderPointStWork(orderPointStWork);

                    orderPointStList.Add(orderPointSt);
                }
            }

            return status;
        }
        # endregion

        #region 論理削除処理
        /// <summary>
        /// 論理削除処理(発注点設定マスタ)
        /// </summary>
        /// <param name="orderPointStList">発注点設定マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタを論理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int LogicalDelete(ref List<OrderPointSt> orderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList orderPointStWorkList = new ArrayList();

                foreach (OrderPointSt orderPointSt in orderPointStList)
                {
                    // UIデータクラス→ワーク
                    OrderPointStWork orderPointStWork = CopyToOrderPointStWorkFromOrderPointSt(orderPointSt);

                    orderPointStWorkList.Add(orderPointStWork);
                }

                object paraObj = orderPointStWorkList;

                // 論理削除処理
                status = this._iOrderPointStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    orderPointStWorkList = paraObj as ArrayList;

                    orderPointStList.Clear();
                    foreach (OrderPointStWork orderPointStWork in orderPointStWorkList)
                    {
                        // ワーク→UIデータクラス
                        OrderPointSt orderPointSt = CopyToOrderPointStFromOrderPointStWork(orderPointStWork);

                        orderPointStList.Add(orderPointSt);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region 物理削除処理
        /// <summary>
        /// 物理削除処理(発注点設定マスタ)
        /// </summary>
        /// <param name="orderPointStList">発注点設定マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタリストを物理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int Delete(List<OrderPointSt> orderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList orderPointStWorkList = new ArrayList();

                foreach (OrderPointSt orderPointSt in orderPointStList)
                {
                    // UIデータクラス→ワーク
                    OrderPointStWork orderPointStWork = CopyToOrderPointStWorkFromOrderPointSt(orderPointSt);

                    orderPointStWorkList.Add(orderPointStWork);
                }

                object paraObj = orderPointStWorkList;

                // 物理削除処理
                status = this._iOrderPointStDB.Delete(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region 復活処理
        /// <summary>
        /// 復活処理(発注点設定マスタ)
        /// </summary>
        /// <param name="orderPointStList">発注点設定マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタを復活します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int Revival(ref List<OrderPointSt> orderPointStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList orderPointStWorkList = new ArrayList();

                foreach (OrderPointSt orderPointSt in orderPointStList)
                {
                                        // UIデータクラス→ワーク
                    OrderPointStWork orderPointStWork = CopyToOrderPointStWorkFromOrderPointSt(orderPointSt);

                    orderPointStWorkList.Add(orderPointStWork);
                }

                object paraObj = orderPointStWorkList;

                // 論理削除処理
                status = this._iOrderPointStDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    orderPointStWorkList = paraObj as ArrayList;

                    orderPointStList.Clear();
                    foreach (OrderPointStWork orderPointStWork in orderPointStWorkList)
                    {
                        // ワーク→UIデータクラス
                        OrderPointSt orderPointSt = CopyToOrderPointStFromOrderPointStWork(orderPointStWork);

                        orderPointStList.Add(orderPointSt);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        # endregion

        # region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（発注点設定マスタワーククラス⇒発注点設定マスタクラス）
        /// </summary>
        /// <param name="orderPointStWork">発注点設定マスタワーククラス</param>
        /// <returns>発注点設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタワーククラスから発注点設定マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        private OrderPointSt CopyToOrderPointStFromOrderPointStWork(OrderPointStWork orderPointStWork)
        {
            OrderPointSt orderPointSt = new OrderPointSt();

            orderPointSt.CreateDateTime = orderPointStWork.CreateDateTime;
            orderPointSt.UpdateDateTime = orderPointStWork.UpdateDateTime;
            orderPointSt.EnterpriseCode = orderPointStWork.EnterpriseCode;
            orderPointSt.FileHeaderGuid = orderPointStWork.FileHeaderGuid;
            orderPointSt.UpdEmployeeCode = orderPointStWork.UpdEmployeeCode;
            orderPointSt.UpdAssemblyId1 = orderPointStWork.UpdAssemblyId1;
            orderPointSt.UpdAssemblyId2 = orderPointStWork.UpdAssemblyId2;
            orderPointSt.LogicalDeleteCode = orderPointStWork.LogicalDeleteCode;
            orderPointSt.PatterNo = orderPointStWork.PatterNo;
            orderPointSt.PatternNoDerivedNo = orderPointStWork.PatternNoDerivedNo;
            orderPointSt.WarehouseCode = orderPointStWork.WarehouseCode;
            orderPointSt.SupplierCd = orderPointStWork.SupplierCd;
            orderPointSt.GoodsMakerCd = orderPointStWork.GoodsMakerCd;
            orderPointSt.GoodsMGroup = orderPointStWork.GoodsMGroup;
            orderPointSt.BLGroupCode = orderPointStWork.BLGroupCode;
            orderPointSt.BLGoodsCode = orderPointStWork.BLGoodsCode;
            orderPointSt.StckShipMonthSt = orderPointStWork.StckShipMonthSt;
            orderPointSt.StckShipMonthEd = orderPointStWork.StckShipMonthEd;
            orderPointSt.OrderApplyDiv = orderPointStWork.OrderApplyDiv;
            orderPointSt.StockCreateDate = orderPointStWork.StockCreateDate;
            orderPointSt.ShipScopeMore = orderPointStWork.ShipScopeMore;
            orderPointSt.ShipScopeLess = orderPointStWork.ShipScopeLess;
            orderPointSt.MinimumStockCnt = orderPointStWork.MinimumStockCnt;
            orderPointSt.MaximumStockCnt = orderPointStWork.MaximumStockCnt;
            orderPointSt.SalesOrderUnit = orderPointStWork.SalesOrderUnit;
            orderPointSt.OrderPProcUpdFlg = orderPointStWork.OrderPProcUpdFlg;


            return orderPointSt;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（発注点設定マスタクラス⇒発注点設定マスタワーククラス）
        /// </summary>
        /// <param name="orderPointSt">発注点設定マスタクラス</param>
        /// <returns>発注点設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタクラスから発注点設定マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        private OrderPointStWork CopyToOrderPointStWorkFromOrderPointSt(OrderPointSt orderPointSt)
        {
            OrderPointStWork orderPointStWork = new OrderPointStWork();

            orderPointStWork.CreateDateTime = orderPointSt.CreateDateTime;
            orderPointStWork.UpdateDateTime = orderPointSt.UpdateDateTime;
            orderPointStWork.EnterpriseCode = orderPointSt.EnterpriseCode;
            orderPointStWork.FileHeaderGuid = orderPointSt.FileHeaderGuid;
            orderPointStWork.UpdEmployeeCode = orderPointSt.UpdEmployeeCode;
            orderPointStWork.UpdAssemblyId1 = orderPointSt.UpdAssemblyId1;
            orderPointStWork.UpdAssemblyId2 = orderPointSt.UpdAssemblyId2;
            orderPointStWork.LogicalDeleteCode = orderPointSt.LogicalDeleteCode;
            orderPointStWork.PatterNo = orderPointSt.PatterNo;
            orderPointStWork.PatternNoDerivedNo = orderPointSt.PatternNoDerivedNo;
            orderPointStWork.WarehouseCode = orderPointSt.WarehouseCode;
            orderPointStWork.SupplierCd = orderPointSt.SupplierCd;
            orderPointStWork.GoodsMakerCd = orderPointSt.GoodsMakerCd;
            orderPointStWork.GoodsMGroup = orderPointSt.GoodsMGroup;
            orderPointStWork.BLGroupCode = orderPointSt.BLGroupCode;
            orderPointStWork.BLGoodsCode = orderPointSt.BLGoodsCode;
            orderPointStWork.StckShipMonthSt = orderPointSt.StckShipMonthSt;
            orderPointStWork.StckShipMonthEd = orderPointSt.StckShipMonthEd;
            orderPointStWork.OrderApplyDiv = orderPointSt.OrderApplyDiv;
            orderPointStWork.StockCreateDate = orderPointSt.StockCreateDate;
            orderPointStWork.ShipScopeMore = orderPointSt.ShipScopeMore;
            orderPointStWork.ShipScopeLess = orderPointSt.ShipScopeLess;
            orderPointStWork.MinimumStockCnt = orderPointSt.MinimumStockCnt;
            orderPointStWork.MaximumStockCnt = orderPointSt.MaximumStockCnt;
            orderPointStWork.SalesOrderUnit = orderPointSt.SalesOrderUnit;
            orderPointStWork.OrderPProcUpdFlg = orderPointSt.OrderPProcUpdFlg;

            return orderPointStWork;
        }
        # endregion
    }
}
