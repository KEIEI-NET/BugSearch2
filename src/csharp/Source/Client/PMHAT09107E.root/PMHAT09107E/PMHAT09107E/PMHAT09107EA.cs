//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定処理
// プログラム概要   : 発注点設定処理テーブルスキーマ情報クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 発注点設定処理 テーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定処理テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class OrderPointStSimulationTbl
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string Col_Tbl_Result_OrderPointStSimulation = "Tbl_Result_OrderPointStSimulation";
        /// <summary>
        /// 企業コード
        /// </summary>
        public const string Col_EnterpriseCode = "EnterpriseCode";
        /// <summary>
        /// 更新日時
        /// </summary>
        public const string Col_UpdateDateTime = "UpdateDateTime";
        /// <summary>
        /// 拠点コード
        /// </summary>
        public const string Col_SectionCode = "SectionCode";
        /// <summary>
        /// 拠点名称
        /// </summary>
        public const string Col_SectionName = "SectionName";
        /// <summary>
        /// パターン番号
        /// </summary>
        public const string Col_PatterNo = "PatterNo";
        /// <summary>
        /// パターン番号枝番
        /// </summary>
        public const string Col_PatternNoDerivedNo = "PatternNoDerivedNo";
        /// <summary>
        /// 設定行番号（帳票明細用）
        /// </summary>
        public const string Col_Detail_PatternNoDerivedNo = "Detail_PatternNoDerivedNo";
        /// <summary>
        /// 設定コード
        /// </summary>
        public const string Col_SettingCode = "SettingCode";
        /// <summary>
        /// 倉庫コード
        /// </summary>
        public const string Col_WarehouseCode = "WarehouseCode";
        /// <summary>
        /// 倉庫名称
        /// </summary>
        public const string Col_WarehouseName = "WarehouseName";
        /// <summary>
        /// 棚番
        /// </summary>
        public const string Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>
        /// 仕入先
        /// </summary>
        public const string Col_SupplierCd = "SupplierCd";
        /// <summary>
        /// 仕入先名称
        /// </summary>
        public const string Col_SupplierName = "SupplierName";
        /// <summary>
        /// 商品メーカーコード
        /// </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>
        /// 商品メーカーコード（帳票明細用）
        /// </summary>
        public const string Col_Detail_GoodsMakerCd = "Detail_GoodsMakerCd";
        /// <summary>
        /// 商品メーカー名称
        /// </summary>
        public const string Col_GoodsMakerName = "GoodsMakerName";
        /// <summary>
        /// 中分類
        /// </summary>
        public const string Col_GoodsMGroup = "GoodsMGroup";
        /// <summary>
        /// BLグループ
        /// </summary>
        public const string Col_BLGroupCode = "BLGroupCode";
        /// <summary>
        /// BL商品コード
        /// </summary>
        public const string Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>
        /// 在庫出荷対象開始月
        /// </summary>
        public const string Col_StckShipMonthSt = "StckShipMonthSt";
        /// <summary>
        /// 在庫出荷対象終了月
        /// </summary>
        public const string Col_StckShipMonthEd = "StckShipMonthEd";
        /// <summary>
        /// 発注適用区分
        /// </summary>
        public const string Col_OrderApplyDiv = "OrderApplyDiv";
        /// <summary>
        /// 在庫登録日
        /// </summary>
        public const string Col_StockCreateDate = "StockCreateDate";
        /// <summary>
        /// 出荷数範囲(以上)
        /// </summary>
        public const string Col_ShipScopeMore = "ShipScopeMore";
        /// <summary>
        /// 出荷数範囲(以下)
        /// </summary>
        public const string Col_ShipScopeLess = "ShipScopeLess";
        /// <summary>
        /// 最低在庫数
        /// </summary>
        public const string Col_MinimumStockCnt = "MinimumStockCnt";
        /// <summary>
        /// 最高在庫数
        /// </summary>
        public const string Col_MaximumStockCnt = "MaximumStockCnt";
        /// <summary>
        /// 発注単位
        /// </summary>
        public const string Col_SalesOrderUnit = "SalesOrderUnit";
        /// <summary>
        /// 発注点処理更新フラグ
        /// </summary>
        public const string Col_OrderPProcUpdFlg = "OrderPProcUpdFlg";
        /// <summary>
        /// 品番
        /// </summary>
        public const string Col_GoodsNo = "GoodsNo";
        /// <summary>
        /// 品名
        /// </summary>
        public const string Col_GoodsName = "GoodsName";
        /// <summary>
        /// 原単価
        /// </summary>
        public const string Col_OldPrice = "OldPrice";
        /// <summary>
        /// 現在庫数
        /// </summary>
        public const string Col_NowPrice = "NowPrice";
        /// <summary>
        /// 現在庫金額
        /// </summary>
        public const string Col_NowStockPrice = "NowStockPrice";
        /// <summary>
        /// 最低数（変更前）
        /// </summary>
        public const string Col_OldMinCnt = "OldMinCnt";
        /// <summary>
        /// 最高数（変更前）
        /// </summary>
        public const string Col_OldMaxCnt = "OldMaxCnt";
        /// <summary>
        /// 最低数（変更後）
        /// </summary>
        public const string Col_NewMinCnt = "NewMinCnt";
        /// <summary>
        /// 最高数（変更後）
        /// </summary>
        public const string Col_NewMaxCnt = "NewMaxCnt";
        /// <summary>
        /// 最低金額（変更前）
        /// </summary>
        public const string Col_OldMinPrice = "OldMinPrice";
        /// <summary>
        /// 最高金額（変更前）
        /// </summary>
        public const string Col_OldMaxPrice = "OldMaxPrice";
        /// <summary>
        /// 最低金額（変更後）
        /// </summary>
        public const string Col_NewMinPrice = "NewMinPrice";
        /// <summary>
        /// 最高金額（変更後）
        /// </summary>
        public const string Col_NewMaxPrice = "NewMaxPrice";
        /// <summary>
        /// Stock_CreateDateTime
        /// </summary>
        public const string Col_Stock_CreateDateTime = "Stock_CreateDateTime";
        /// <summary>
        /// Stock_UpdateDateTime
        /// </summary>
        public const string Col_Stock_UpdateDateTime = "Stock_UpdateDateTime";
        /// <summary>
        /// Stock_EnterpriseCode
        /// </summary>
        public const string Col_Stock_EnterpriseCode = "Stock_EnterpriseCode";
        /// <summary>
        /// Stock_FileHeaderGuid
        /// </summary>
        public const string Col_Stock_FileHeaderGuid = "Stock_FileHeaderGuid";
        /// <summary>
        /// Stock_UpdEmployeeCode
        /// </summary>
        public const string Col_Stock_UpdEmployeeCode = "Stock_UpdEmployeeCode";
        /// <summary>
        /// Stock_UpdAssemblyId1
        /// </summary>
        public const string Col_Stock_UpdAssemblyId1 = "Stock_UpdAssemblyId1";
        /// <summary>
        /// Stock_UpdAssemblyId2
        /// </summary>
        public const string Col_Stock_UpdAssemblyId2 = "Stock_UpdAssemblyId2";
        /// <summary>
        /// Stock_LogicalDeleteCode
        /// </summary>
        public const string Col_Stock_LogicalDeleteCode = "Stock_LogicalDeleteCode";
        /// <summary>
        /// Stock_SectionCode
        /// </summary>
        public const string Col_Stock_SectionCode = "Stock_SectionCode";
        /// <summary>
        /// Stock_WarehouseCode
        /// </summary>
        public const string Col_Stock_WarehouseCode = "Stock_WarehouseCode";
        /// <summary>
        /// Stock_GoodsMakerCd
        /// </summary>
        public const string Col_Stock_GoodsMakerCd = "Stock_GoodsMakerCd";
        /// <summary>
        /// Stock_GoodsNo
        /// </summary>
        public const string Col_Stock_GoodsNo = "Stock_GoodsNo";
        /// <summary>
        /// Stock_StockUnitPriceFl
        /// </summary>
        public const string Col_Stock_StockUnitPriceFl = "Stock_StockUnitPriceFl";
        /// <summary>
        /// Stock_SupplierStock
        /// </summary>
        public const string Col_Stock_SupplierStock = "Stock_SupplierStock";
        /// <summary>
        /// Stock_AcpOdrCount
        /// </summary>
        public const string Col_Stock_AcpOdrCount = "Stock_AcpOdrCount";
        /// <summary>
        /// Stock_MonthOrderCount
        /// </summary>
        public const string Col_Stock_MonthOrderCount = "Stock_MonthOrderCount";
        /// <summary>
        /// Stock_SalesOrderCount
        /// </summary>
        public const string Col_Stock_SalesOrderCount = "Stock_SalesOrderCount";
        /// <summary>
        /// Stock_StockDiv
        /// </summary>
        public const string Col_Stock_StockDiv = "Stock_StockDiv";
        /// <summary>
        /// Stock_MovingSupliStock
        /// </summary>
        public const string Col_Stock_MovingSupliStock = "Stock_MovingSupliStock";
        /// <summary>
        /// Stock_ShipmentPosCnt
        /// </summary>
        public const string Col_Stock_ShipmentPosCnt = "Stock_ShipmentPosCnt";
        /// <summary>
        /// Stock_StockTotalPrice
        /// </summary>
        public const string Col_Stock_StockTotalPrice = "Stock_StockTotalPrice";
        /// <summary>
        /// Stock_LastStockDate
        /// </summary>
        public const string Col_Stock_LastStockDate = "Stock_LastStockDate";
        /// <summary>
        /// Stock_LastSalesDate
        /// </summary>
        public const string Col_Stock_LastSalesDate = "Stock_LastSalesDate";
        /// <summary>
        /// Stock_LastInventoryUpdate
        /// </summary>
        public const string Col_Stock_LastInventoryUpdate = "Stock_LastInventoryUpdate";
        /// <summary>
        /// Stock_MinimumStockCnt
        /// </summary>
        public const string Col_Stock_MinimumStockCnt = "Stock_MinimumStockCnt";
        /// <summary>
        /// Stock_MaximumStockCnt
        /// </summary>
        public const string Col_Stock_MaximumStockCnt = "Stock_MaximumStockCnt";
        /// <summary>
        /// Stock_NmlSalOdrCount
        /// </summary>
        public const string Col_Stock_NmlSalOdrCount = "Stock_NmlSalOdrCount";
        /// <summary>
        /// Stock_SalesOrderUnit
        /// </summary>
        public const string Col_Stock_SalesOrderUnit = "Stock_SalesOrderUnit";
        /// <summary>
        /// Stock_StockSupplierCode
        /// </summary>
        public const string Col_Stock_StockSupplierCode = "Stock_StockSupplierCode";
        /// <summary>
        /// Stock_GoodsNoNoneHyphen
        /// </summary>
        public const string Col_Stock_GoodsNoNoneHyphen = "Stock_GoodsNoNoneHyphen";
        /// <summary>
        /// Stock_WarehouseShelfNo
        /// </summary>
        public const string Col_Stock_WarehouseShelfNo = "Stock_WarehouseShelfNo";
        /// <summary>
        /// Stock_DuplicationShelfNo1
        /// </summary>
        public const string Col_Stock_DuplicationShelfNo1 = "Stock_DuplicationShelfNo1";
        /// <summary>
        /// Stock_DuplicationShelfNo2
        /// </summary>
        public const string Col_Stock_DuplicationShelfNo2 = "Stock_DuplicationShelfNo2";
        /// <summary>
        /// Stock_PartsManagementDivide1
        /// </summary>
        public const string Col_Stock_PartsManagementDivide1 = "Stock_PartsManagementDivide1";
        /// <summary>
        /// Stock_PartsManagementDivide2
        /// </summary>
        public const string Col_Stock_PartsManagementDivide2 = "Stock_PartsManagementDivide2";
        /// <summary>
        /// Stock_StockNote1
        /// </summary>
        public const string Col_Stock_StockNote1 = "Stock_StockNote1";
        /// <summary>
        /// Stock_StockNote2
        /// </summary>
        public const string Col_Stock_StockNote2 = "Stock_StockNote2";
        /// <summary>
        /// Stock_ShipmentCnt
        /// </summary>
        public const string Col_Stock_ShipmentCnt = "Stock_ShipmentCnt";
        /// <summary>
        /// Stock_ArrivalCnt
        /// </summary>
        public const string Col_Stock_ArrivalCnt = "Stock_ArrivalCnt";
        /// <summary>
        /// Stock_StockCreateDate
        /// </summary>
        public const string Col_Stock_StockCreateDate = "Stock_StockCreateDate";
        /// <summary>
        /// Stock_UpdateDate
        /// </summary>
        public const string Col_Stock_UpdateDate = "Stock_UpdateDate";

        /// <summary>
        /// 発注点設定処理テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 発注点設定処理テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public OrderPointStSimulationTbl()
		{
		}

        /// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        static public void CreateDataTableOrderPointStSimulationTbl(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_Result_OrderPointStSimulation))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_Result_OrderPointStSimulation].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_Result_OrderPointStSimulation);

                DataTable dt = ds.Tables[Col_Tbl_Result_OrderPointStSimulation];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                Int64 defValueInt64 = 0;
                double defValueDouble = 0.0;
                DateTime defValueDateTime = DateTime.MinValue;
                Guid defValueGuid = new Guid();

                dt.Columns.Add(Col_EnterpriseCode, typeof(string));
                dt.Columns[Col_EnterpriseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdateDateTime, typeof(DateTime));
                dt.Columns[Col_UpdateDateTime].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_SectionCode, typeof(string));
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionName, typeof(string));
                dt.Columns[Col_SectionName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_PatterNo, typeof(Int32));
                dt.Columns[Col_PatterNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_PatternNoDerivedNo, typeof(Int32));
                dt.Columns[Col_PatternNoDerivedNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Detail_PatternNoDerivedNo, typeof(string));
                dt.Columns[Col_Detail_PatternNoDerivedNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SettingCode, typeof(string));
                dt.Columns[Col_SettingCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));
                dt.Columns[Col_WarehouseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseName, typeof(string));
                dt.Columns[Col_WarehouseName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseShelfNo, typeof(string));
                dt.Columns[Col_WarehouseShelfNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierName, typeof(string));
                dt.Columns[Col_SupplierName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Detail_GoodsMakerCd, typeof(string));
                dt.Columns[Col_Detail_GoodsMakerCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerName, typeof(string));
                dt.Columns[Col_GoodsMakerName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMGroup, typeof(Int32));
                dt.Columns[Col_GoodsMGroup].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BLGroupCode, typeof(Int32));
                dt.Columns[Col_BLGroupCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BLGoodsCode, typeof(Int32));
                dt.Columns[Col_BLGoodsCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_StckShipMonthSt, typeof(Int32));
                dt.Columns[Col_StckShipMonthSt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_StckShipMonthEd, typeof(Int32));
                dt.Columns[Col_StckShipMonthEd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_OrderApplyDiv, typeof(Int32));
                dt.Columns[Col_OrderApplyDiv].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_StockCreateDate, typeof(Int32));
                dt.Columns[Col_StockCreateDate].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_ShipScopeMore, typeof(Double));
                dt.Columns[Col_ShipScopeMore].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_ShipScopeLess, typeof(Double));
                dt.Columns[Col_ShipScopeLess].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_MinimumStockCnt, typeof(Double));
                dt.Columns[Col_MinimumStockCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_MaximumStockCnt, typeof(Double));
                dt.Columns[Col_MaximumStockCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesOrderUnit, typeof(Int32));
                dt.Columns[Col_SalesOrderUnit].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_OrderPProcUpdFlg, typeof(Int32));
                dt.Columns[Col_OrderPProcUpdFlg].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_GoodsNo, typeof(string));
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_OldPrice, typeof(Double));
                dt.Columns[Col_OldPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_NowPrice, typeof(Double));
                dt.Columns[Col_NowPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_NowStockPrice, typeof(Double));
                dt.Columns[Col_NowStockPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_OldMinCnt, typeof(Double));
                dt.Columns[Col_OldMinCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_OldMaxCnt, typeof(Double));
                dt.Columns[Col_OldMaxCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_NewMinCnt, typeof(Double));
                dt.Columns[Col_NewMinCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_NewMaxCnt, typeof(Double));
                dt.Columns[Col_NewMaxCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_OldMinPrice, typeof(Double));
                dt.Columns[Col_OldMinPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_OldMaxPrice, typeof(Double));
                dt.Columns[Col_OldMaxPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_NewMinPrice, typeof(Double));
                dt.Columns[Col_NewMinPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_NewMaxPrice, typeof(Double));
                dt.Columns[Col_NewMaxPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_CreateDateTime, typeof(DateTime));
                dt.Columns[Col_Stock_CreateDateTime].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_Stock_UpdateDateTime, typeof(DateTime));
                dt.Columns[Col_Stock_UpdateDateTime].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_Stock_EnterpriseCode, typeof(string));
                dt.Columns[Col_Stock_EnterpriseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_FileHeaderGuid, typeof(Guid));
                dt.Columns[Col_Stock_FileHeaderGuid].DefaultValue = defValueGuid;

                dt.Columns.Add(Col_Stock_UpdEmployeeCode, typeof(string));
                dt.Columns[Col_Stock_UpdEmployeeCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_UpdAssemblyId1, typeof(string));
                dt.Columns[Col_Stock_UpdAssemblyId1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_UpdAssemblyId2, typeof(string));
                dt.Columns[Col_Stock_UpdAssemblyId2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_LogicalDeleteCode, typeof(Int32));
                dt.Columns[Col_Stock_LogicalDeleteCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Stock_SectionCode, typeof(string));
                dt.Columns[Col_Stock_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_WarehouseCode, typeof(string));
                dt.Columns[Col_Stock_WarehouseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_GoodsMakerCd, typeof(Int32));
                dt.Columns[Col_Stock_GoodsMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Stock_GoodsNo, typeof(string));
                dt.Columns[Col_Stock_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_StockUnitPriceFl, typeof(Double));
                dt.Columns[Col_Stock_StockUnitPriceFl].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_SupplierStock, typeof(Double));
                dt.Columns[Col_Stock_SupplierStock].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_AcpOdrCount, typeof(Double));
                dt.Columns[Col_Stock_AcpOdrCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_MonthOrderCount, typeof(Double));
                dt.Columns[Col_Stock_MonthOrderCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_SalesOrderCount, typeof(Double));
                dt.Columns[Col_Stock_SalesOrderCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_StockDiv, typeof(Int32));
                dt.Columns[Col_Stock_StockDiv].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Stock_MovingSupliStock, typeof(Double));
                dt.Columns[Col_Stock_MovingSupliStock].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_ShipmentPosCnt, typeof(Double));
                dt.Columns[Col_Stock_ShipmentPosCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_StockTotalPrice, typeof(Int64));
                dt.Columns[Col_Stock_StockTotalPrice].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_Stock_LastStockDate, typeof(DateTime));
                dt.Columns[Col_Stock_LastStockDate].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_Stock_LastSalesDate, typeof(DateTime));
                dt.Columns[Col_Stock_LastSalesDate].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_Stock_LastInventoryUpdate, typeof(DateTime));
                dt.Columns[Col_Stock_LastInventoryUpdate].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_Stock_MinimumStockCnt, typeof(Double));
                dt.Columns[Col_Stock_MinimumStockCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_MaximumStockCnt, typeof(Double));
                dt.Columns[Col_Stock_MaximumStockCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_NmlSalOdrCount, typeof(Double));
                dt.Columns[Col_Stock_NmlSalOdrCount].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_SalesOrderUnit, typeof(Int32));
                dt.Columns[Col_Stock_SalesOrderUnit].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Stock_StockSupplierCode, typeof(Int32));
                dt.Columns[Col_Stock_StockSupplierCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Stock_GoodsNoNoneHyphen, typeof(string));
                dt.Columns[Col_Stock_GoodsNoNoneHyphen].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_WarehouseShelfNo, typeof(string));
                dt.Columns[Col_Stock_WarehouseShelfNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_DuplicationShelfNo1, typeof(string));
                dt.Columns[Col_Stock_DuplicationShelfNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_DuplicationShelfNo2, typeof(string));
                dt.Columns[Col_Stock_DuplicationShelfNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_PartsManagementDivide1, typeof(string));
                dt.Columns[Col_Stock_PartsManagementDivide1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_PartsManagementDivide2, typeof(string));
                dt.Columns[Col_Stock_PartsManagementDivide2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_StockNote1, typeof(string));
                dt.Columns[Col_Stock_StockNote1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_StockNote2, typeof(string));
                dt.Columns[Col_Stock_StockNote2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Stock_ShipmentCnt, typeof(Double));
                dt.Columns[Col_Stock_ShipmentCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_ArrivalCnt, typeof(Double));
                dt.Columns[Col_Stock_ArrivalCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_Stock_StockCreateDate, typeof(DateTime));
                dt.Columns[Col_Stock_StockCreateDate].DefaultValue = defValueDateTime;

                dt.Columns.Add(Col_Stock_UpdateDate, typeof(DateTime));
                dt.Columns[Col_Stock_UpdateDate].DefaultValue = defValueDateTime;


            }
        }
    }
}
