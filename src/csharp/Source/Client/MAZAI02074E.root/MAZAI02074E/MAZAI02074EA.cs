using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// 在庫一覧表抽出結果データテーブルスキーマクラス
	/// </summa ry>
	/// <remarks>
    /// <br>Note       : 在庫一覧表抽出結果テーブルスキーマです。</br>
	/// <br>Programmer : 23010　中村　仁</br>
	/// <br>Date       : 2007.03.20</br>
    /// <br>Update Note: 2007.10.05 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.01.24 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応（不具合対応）</br>
    /// <br>Update Note: 2008/10/08        照田 貴志</br>
    /// <br>			 ・バグ修正、仕様変更対応</br>
    /// </remarks>
	public class MAZAI02074EA
	{
		#region Public Members
		/// <summary>データセット名</summary>
        public const string StockListDataSet = "StockListDataSet";
		/// <summary>データテーブル名</summary>
        public const string StockListDataTable = "StockListDataTable";
        /// <summary>在庫一覧表バッファデータテーブル名</summary>
        public const string StockListCommonBuffDataTable = "StockListCommonBuffDataTable";

        #region 在庫一覧表カラム情報

        /// <summary>拠点コード</summary>
        public const string ctCol_SectionCode = "SectionCode";
        /// <summary>拠点名称</summary>
        public const string ctCol_SectionName = "SectionName";
        /// <summary>メーカーコード</summary>
        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
        //public const string ctCol_MakerCode = "MakerCode";
        public const string ctCol_GoodsMakerCd = "GoodsMakerCd";
        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
        /// <summary>メーカー名称</summary>
        public const string ctCol_MakerName = "MakerName";
        /// <summary>商品コード</summary>
        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
        //public const string ctCol_GoodsCode = "GoodsCode";
        public const string ctCol_GoodsNo = "GoodsNo";
        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
        /// <summary>商品名称</summary>
        public const string ctCol_GoodsName = "GoodsName";
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>仕入単価</summary>
        //public const string ctCol_StockUnitPrice = "StockUnitPrice";
        ///// <summary>仕入在庫数</summary>
        //public const string ctCol_SupplierStock = "SupplierStock";
        //--- DEL 2008/08/01 ----------<<<<<
        // 2008.01.24 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>受託数</summary>
        //public const string ctCol_TrustCount = "TrustCount";
        // 2008.01.24 削除 <<<<<<<<<<<<<<<<<<<<
        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>予約数</summary>
        //public const string ctCol_ReservedCount = "ReservedCount";
        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>引当在庫数</summary>
        //public const string ctCol_AllowStockCnt = "AllowStockCnt";
        ///// <summary>受注数</summary>
        //public const string ctCol_AcpOdrCount = "AcpOdrCount";
        ///// <summary>発注数</summary>
        //public const string ctCol_SalesOrderCount = "SalesOrderCount";
        ///// <summary>仕入在庫分委託数</summary>
        //public const string ctCol_EntrustCnt = "EntrustCnt";
        //--- DEL 2008/08/01 ----------<<<<<
        // 2008.01.24 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>受託分委託数</summary>
        //public const string ctCol_TrustEntrustCnt = "TrustEntrustCnt";
        // 2008.01.24 削除 <<<<<<<<<<<<<<<<<<<<
        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>売切数</summary>
        //public const string ctCol_SoldCnt = "SoldCnt";
        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>移動中仕入在庫数</summary>
        //public const string ctCol_MovingSupliStock = "MovingSupliStock";
        //--- DEL 2008/08/01 ----------<<<<<
        // 2008.01.24 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>移動中受託在庫数</summary>
        //public const string ctCol_MovingTrustStock = "MovingTrustStock";
        /// <summary>出荷数(未計上)</summary>
        public const string ctCol_ShipmentCnt = "ShipmentCnt";
        /// <summary>入荷数(未計上)</summary>
        public const string ctCol_ArrivalCnt = "ArrivalCnt";
        // 2008.01.24 修正 <<<<<<<<<<<<<<<<<<<<
        /// <summary>出荷可能数</summary>
        public const string ctCol_ShipmentPosCnt = "ShipmentPosCnt";
        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>製番管理区分</summary>
        //public const string ctCol_PrdNumMngDiv = "PrdNumMngDiv";
        ///// <summary>製番管理区分</summary>
        //public const string ctCol_PrdNumMngDivName = "PrdNumMngDivName";
        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>最終仕入年月日</summary>
        //public const string ctCol_LastStockDate = "LastStockDate";
        ///// <summary>最終売上日</summary>
        //public const string ctCol_LastSalesDate = "LastSalesDate";
        ///// <summary>最終棚卸更新日</summary>
        //public const string ctCol_LastInventoryUpdate = "LastInventoryUpdate";
        //--- DEL 2008/08/01 ----------<<<<<
        /// <summary>最終仕入年月日(ソート用)</summary>
        public const string ctCol_LastStockDate_sort = "LastStockDate_sort";
        /// <summary>最終売上日(ソート用)</summary>
        public const string ctCol_LastSalesDate_sort = "LastSalesDate_sort";
        /// <summary>最終棚卸更新日(ソート用)</summary>
        public const string ctCol_LastInventoryUpdate_sort = "LastInventoryUpdate_sort";
        /// <summary>最終仕入年月日(印刷用)</summary>
        public const string ctCol_LastStockDate_print = "LastStockDate_print";
        /// <summary>最終売上日(印刷用)</summary>
        public const string ctCol_LastSalesDate_print = "LastSalesDate_print";
        /// <summary>最終棚卸更新日(印刷用)</summary>
        public const string ctCol_LastInventoryUpdate_print = "LastInventoryUpdate_print";
        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>機種コード</summary>
        //public const string ctCol_CellphoneModelCode = "CellphoneModelCode";
        ///// <summary>機種名称</summary>
        //public const string ctCol_CellphoneModelName = "CellphoneModelName";
        ///// <summary>キャリアコード</summary>
        //public const string ctCol_CarrierCode = "CarrierCode";
        ///// <summary>キャリア名称</summary>
        //public const string ctCol_CarrierName = "CarrierName";
        ///// <summary>系統色コード</summary>
        //public const string ctCol_SystematicColorCd = "SystematicColorCd";
        ///// <summary>系統色名称</summary>
        //public const string ctCol_SystematicColorNm = "SystematicColorNm";
        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>商品区分グループコード</summary>
        //public const string ctCol_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary>商品区分グループ名称</summary>
        //public const string ctCol_LargeGoodsGanreName = "LargeGoodsGanreName";
        ///// <summary>商品区分コード</summary>
        //public const string ctCol_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        ///// <summary>商品区分名称</summary>
        //public const string ctCol_MediumGoodsGanreName = "MediumGoodsGanreName";
        //// 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>商品区分詳細コード</summary>
        //public const string ctCol_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary>商品区分詳細名称</summary>
        //public const string ctCol_DetailGoodsGanreName = "DetailGoodsGanreName";
        ///// <summary>自社分類コード</summary>
        //public const string ctCol_EnterpriseGanreCode = "EnterpriseGanreCode";
        ///// <summary>自社分類名称</summary>
        //public const string ctCol_EnterpriseGanreName = "EnterpriseGanreName";
        //--- DEL 2008/08/01 ----------<<<<<
        /// <summary>ＢＬ商品コード</summary>
        public const string ctCol_BLGoodsCode = "BLGoodsCode";
        /// <summary>ＢＬ商品名称</summary>
        public const string ctCol_BLGoodsName = "BLGoodsName";
        /// <summary>倉庫コード</summary>
        public const string ctCol_WarehouseCode = "WarehouseCode";
        /// <summary>倉庫名称</summary>
        public const string ctCol_WarehouseName = "WarehouseName";
        // 2008.01.24 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>倉庫棚番</summary>
        public const string ctCol_WarehouseShelfNo = "WarehouseShelfNo";
        // 2008.01.24 追加 <<<<<<<<<<<<<<<<<<<<
        // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
        /// <summary>最低在庫数</summary>
        public const string ctCol_MinimumStockCnt = "MinimumStockCnt";
        /// <summary>最高在庫数</summary>
        public const string ctCol_MaximumStockCnt = "MaximumStockCnt";
        //--- DEL 2008/08/01 ---------->>>>>
        ///// <summary>基準発注数</summary>
        //public const string ctCol_NmlSalOdrCount = "NmlSalOdrCount";
        ///// <summary>発注単位</summary>
        //public const string ctCol_SalOdrLot = "SalOdrLot";
        ///// <summary>在庫保有総額</summary>
        //public const string ctCol_StockTotalPrice = "StockTotalPrice";
        ///// <summary>ソート順ブレイクキー</summary>
        //public const string ctCol_SortTotalKey = "SortTotalKey";
        ///// <summary>明細用拠点名称</summary>
        //public const string ctCol_SectionName_Detail = "SectionName_Detail";
        ///// <summary>メーカーコード(印刷用)</summary>
        //public const string ctCol_MakerCode_Print = "MakerCode_Print";
        //// 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>キャリアコード(印刷用)</summary>
        ////public const string ctCol_CarrierCode_Print = "CarrierCode_Print";
        /////// <summary>系統色コード(印刷用)</summary>
        ////public const string ctCol_SystematicColorCd_Print = "SystematicColorCd_Print";
        //// 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>商品区分グループコード(印刷用)</summary>
        //public const string ctCol_LargeGoodsGanreCode_Print = "LargeGoodsGanreCode_Print";
        ///// <summary>商品区分コード(印刷用)</summary>
        //public const string ctCol_MediumGoodsGanreCode_Print = "MediumGoodsGanreCode_Print";     
        //// 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>商品区分詳細コード(印刷用)</summary>
        //public const string ctCol_DetailGoodsGanreCode_Print = "DetailGoodsGanreCode_Print";
        //// 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
        //--- DEL 2008/08/01 ----------<<<<<

        //--- ADD 2008/08/01 ---------->>>>>
        /// <summary>在庫発注先コード</summary>
        public const string ctCol_StockSupplierCode = "StockSupplierCode";
        /// <summary>仕入先略称</summary>
        public const string ctCol_SupplierSnm = "SupplierSnm";
        /// <summary>部品管理区分１</summary>
        //public const string ctCol_DuplicationShelfNo1 = "DuplicationShelfNo1";        //DEL 2008/10/08 ID変更
        public const string ctCol_PartsManagementDivide1 = "PartsManagementDivide1";    //ADD 2008/10/08
        /// <summary>部品管理区分２</summary>
        //public const string ctCol_DuplicationShelfNo2 = "DuplicationShelfNo2";        //DEL 2008/10/08 ID変更
        public const string ctCol_PartsManagementDivide2 = "PartsManagementDivide2";    //ADD 2008/10/08
        /// <summary>在庫登録日</summary>
        public const string ctCol_StockCreateDate = "StockCreateDate";
        /// <summary>計上年月</summary>
        public const string ctCol_AddUpYearMonth = "AddUpYearMonth";
        /// <summary>出荷金額</summary>
        public const string ctCol_ShipmentPrice = "ShipmentPrice";

        /// <summary> １ヶ月前 </summary>
        public const string ctCol_ShipmentCntBefore1 = "ShipmentCntBefore1";
        /// <summary> ２ヶ月前 </summary>
        public const string ctCol_ShipmentCntBefore2 = "ShipmentCntBefore2";
        /// <summary> ３ヶ月前 </summary>
        public const string ctCol_ShipmentCntBefore3 = "ShipmentCntBefore3";
        /// <summary> ６ヶ月合計 </summary>
        public const string ctCol_ShipmentCntBeforeTotal = "ShipmentCntBeforeTotal";

        /// <summary> １ヶ月前 </summary>
        public const string ctCol_ShipmentPriceBefore1 = "ShipmentPriceBefore1";
        /// <summary> ２ヶ月前 </summary>
        public const string ctCol_ShipmentPriceBefore2 = "ShipmentPriceBefore2";
        /// <summary> ３ヶ月前 </summary>
        public const string ctCol_ShipmentPriceBefore3 = "ShipmentPriceBefore3";
        /// <summary> ６ヶ月合計 </summary>
        public const string ctCol_ShipmentPriceBeforeTotal = "ShipmentPriceBeforeTotal";

        /// <summary> 倉庫棚番ブレイク </summary>
        public const string ctCol_WarehouseShelfNoBreak = "WarehouseShelfNoBreak";

        /// <summary> ソート用　拠点コード </summary>
        public const string ctCol_Sort_SectionCode = "Sort_SectionCode";
        /// <summary> ソート用　倉庫コード </summary>
        public const string ctCol_Sort_WarehouseCode = "Sort_WarehouseCode";
        /// <summary> ソート用　仕入先コード </summary>
        public const string ctCol_Sort_CustomerCode = "Sort_CustomerCode";
        /// <summary> ソート用　商品メーカーコード </summary>
        public const string ctCol_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";
        /// <summary> ソート用　商品番号 </summary>
        public const string ctCol_Sort_GoodsNo = "Sort_GoodsNo";
        /// <summary> ソート用　倉庫棚番ブレイク </summary>
        public const string ctCol_Sort_WarehouseShelfNoBreak = "Sort_WarehouseShelfNoBreak";
        /// <summary> ソート用　倉庫棚番 </summary>
        public const string ctCol_Sort_WarehouseShelfNo = "Sort_WarehouseShelfNo";
        //--- ADD 2008/08/01 ----------<<<<<
        #endregion

		#endregion

		#region Constructor
		/// <summary>
        /// 在庫一覧表抽出結果データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫一覧表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public MAZAI02074EA()
		{
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(StockListDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
                ds.Tables[StockListDataTable].Clear();
			}
			else
			{
                CreateRestListCommonTable(ref ds, 0);
			}

            // 在庫車両入出庫管理表抽出結果バッファデータテーブル------------------------------------------
			// テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(StockListCommonBuffDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
                ds.Tables[StockListCommonBuffDataTable].Clear();
			}
			else
			{
                CreateRestListCommonTable(ref ds, 1);
			}
		}
		
		
		/// <summary>
        /// 在庫一覧表抽出結果作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
        private static void CreateRestListCommonTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// スキーマ設定
                ds.Tables.Add(StockListDataTable);
                dt = ds.Tables[StockListDataTable];
			}
			else
			{
				// スキーマ設定
                ds.Tables.Add(StockListCommonBuffDataTable);
                dt = ds.Tables[StockListCommonBuffDataTable];
            }

            // 拠点コード
            dt.Columns.Add(ctCol_SectionCode,typeof(string));
            dt.Columns[ctCol_SectionCode].DefaultValue = "";
            // 拠点名称
            dt.Columns.Add(ctCol_SectionName,typeof(string));
            dt.Columns[ctCol_SectionName].DefaultValue = "";
            // メーカーコード
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //dt.Columns.Add(ctCol_MakerCode, typeof(Int32));
            //dt.Columns[ctCol_MakerCode].DefaultValue = 0;
            dt.Columns.Add(ctCol_GoodsMakerCd, typeof(Int32));
            dt.Columns[ctCol_GoodsMakerCd].DefaultValue = 0;
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            // メーカー名称
            dt.Columns.Add(ctCol_MakerName,typeof(string));
            dt.Columns[ctCol_MakerName].DefaultValue = "";
            // 商品コード
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //dt.Columns.Add(ctCol_GoodsCode, typeof(string));
            //dt.Columns[ctCol_GoodsCode].DefaultValue = "";
            dt.Columns.Add(ctCol_GoodsNo, typeof(string));
            dt.Columns[ctCol_GoodsNo].DefaultValue = "";
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品名称
            dt.Columns.Add(ctCol_GoodsName,typeof(string));
            dt.Columns[ctCol_GoodsName].DefaultValue = "";
            //--- DEL 2008/08/01 ---------->>>>>
            //// 仕入単価
            //dt.Columns.Add(ctCol_StockUnitPrice,typeof(Int64));
            //dt.Columns[ctCol_StockUnitPrice].DefaultValue = 0;
            //// 仕入在庫数
            //dt.Columns.Add(ctCol_SupplierStock,typeof(Double));
            //dt.Columns[ctCol_SupplierStock].DefaultValue = 0;
            //--- DEL 2008/08/01 ----------<<<<<
            // 2008.01.24 削除 >>>>>>>>>>>>>>>>>>>>
            //// 受託数
            //dt.Columns.Add(ctCol_TrustCount,typeof(Double));
            //dt.Columns[ctCol_TrustCount].DefaultValue = 0;
            // 2008.01.24 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
            //// 予約数
            //dt.Columns.Add(ctCol_ReservedCount,typeof(Int32));
            //dt.Columns[ctCol_ReservedCount].DefaultValue = 0;
            // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            //// 引当在庫数
            //dt.Columns.Add(ctCol_AllowStockCnt,typeof(Double));
            //dt.Columns[ctCol_AllowStockCnt].DefaultValue = 0;
            //// 受注数
            //dt.Columns.Add(ctCol_AcpOdrCount,typeof(Double));
            //dt.Columns[ctCol_AcpOdrCount].DefaultValue = 0;
            //// 発注数
            //dt.Columns.Add(ctCol_SalesOrderCount,typeof(Double));
            //dt.Columns[ctCol_SalesOrderCount].DefaultValue = 0;
            //// 仕入在庫分委託数
            //dt.Columns.Add(ctCol_EntrustCnt,typeof(Double));
            //dt.Columns[ctCol_EntrustCnt].DefaultValue = 0;
            //--- DEL 2008/08/01 ----------<<<<<
            // 2008.01.24 削除 >>>>>>>>>>>>>>>>>>>>
            //// 受託分委託数
            //dt.Columns.Add(ctCol_TrustEntrustCnt,typeof(Double));
            //dt.Columns[ctCol_TrustEntrustCnt].DefaultValue = 0;
            // 2008.01.24 削除 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
            //// 売切数
            //dt.Columns.Add(ctCol_SoldCnt,typeof(Double));
            //dt.Columns[ctCol_SoldCnt].DefaultValue = 0;
            // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            //// 移動中仕入在庫数
            //dt.Columns.Add(ctCol_MovingSupliStock,typeof(Double));
            //dt.Columns[ctCol_MovingSupliStock].DefaultValue = 0;
            //--- DEL 2008/08/01 ----------<<<<<
            // 2008.01.24 修正 >>>>>>>>>>>>>>>>>>>>
            //// 移動中受託在庫数
            //dt.Columns.Add(ctCol_MovingTrustStock,typeof(Double));
            //dt.Columns[ctCol_MovingTrustStock].DefaultValue = 0;
            // 出荷数(未計上)
            dt.Columns.Add(ctCol_ShipmentCnt, typeof(Double));
            dt.Columns[ctCol_ShipmentCnt].DefaultValue = 0;
            // 入荷数(未計上)
            dt.Columns.Add(ctCol_ArrivalCnt, typeof(Double));
            dt.Columns[ctCol_ArrivalCnt].DefaultValue = 0;
            // 2008.01.24 修正 <<<<<<<<<<<<<<<<<<<<
            // 出荷可能数
            dt.Columns.Add(ctCol_ShipmentPosCnt,typeof(Double));
            dt.Columns[ctCol_ShipmentPosCnt].DefaultValue = 0;
            // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番管理区分
            //dt.Columns.Add(ctCol_PrdNumMngDiv,typeof(Int32));
            //dt.Columns[ctCol_PrdNumMngDiv].DefaultValue = 0;
            //// 製番管理名称
            //dt.Columns.Add(ctCol_PrdNumMngDivName,typeof(string));
            //dt.Columns[ctCol_PrdNumMngDivName].DefaultValue = "";
            // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            //// 最終仕入年月日
            //dt.Columns.Add(ctCol_LastStockDate,typeof(DateTime));
            //dt.Columns[ctCol_LastStockDate].DefaultValue = DateTime.MinValue;
            //// 最終売上日
            //dt.Columns.Add(ctCol_LastSalesDate,typeof(DateTime));
            //dt.Columns[ctCol_LastSalesDate].DefaultValue = DateTime.MinValue;
            //// 最終棚卸更新日
            //dt.Columns.Add(ctCol_LastInventoryUpdate,typeof(DateTime));
            //dt.Columns[ctCol_LastInventoryUpdate].DefaultValue = DateTime.MinValue;
            //--- DEL 2008/08/01 ----------<<<<<
            // 最終仕入年月日(ソート)
            dt.Columns.Add(ctCol_LastStockDate_sort,typeof(Int32));
            dt.Columns[ctCol_LastStockDate_sort].DefaultValue = 0;
            // 最終売上日(ソート)
            dt.Columns.Add(ctCol_LastSalesDate_sort,typeof(Int32));
            dt.Columns[ctCol_LastSalesDate_sort].DefaultValue = 0;
            // 最終棚卸更新日(ソート)
            dt.Columns.Add(ctCol_LastInventoryUpdate_sort,typeof(Int32));
            dt.Columns[ctCol_LastInventoryUpdate_sort].DefaultValue = 0;
            // 最終仕入年月日(印刷)
            dt.Columns.Add(ctCol_LastStockDate_print,typeof(string));
            dt.Columns[ctCol_LastStockDate_print].DefaultValue = "";
            // 最終売上日(印刷)
            dt.Columns.Add(ctCol_LastSalesDate_print,typeof(string));
            dt.Columns[ctCol_LastSalesDate_print].DefaultValue = "";
            // 最終棚卸更新日(印刷)
            dt.Columns.Add(ctCol_LastInventoryUpdate_print,typeof(string));
            dt.Columns[ctCol_LastInventoryUpdate_print].DefaultValue = "";
            // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
            //// 機種コード
            //dt.Columns.Add(ctCol_CellphoneModelCode,typeof(string));
            //dt.Columns[ctCol_CellphoneModelCode].DefaultValue = "";
            //// 機種名称
            //dt.Columns.Add(ctCol_CellphoneModelName,typeof(string));
            //dt.Columns[ctCol_CellphoneModelName].DefaultValue = "";
            //// キャリアコード
            //dt.Columns.Add(ctCol_CarrierCode,typeof(Int32));
            //dt.Columns[ctCol_CarrierCode].DefaultValue = 0;
            //// キャリア名称
            //dt.Columns.Add(ctCol_CarrierName,typeof(string));
            //dt.Columns[ctCol_CarrierName].DefaultValue = "";
            //// 系統色コード
            //dt.Columns.Add(ctCol_SystematicColorCd,typeof(Int32));
            //dt.Columns[ctCol_SystematicColorCd].DefaultValue = 0;
            //// 系統色名称
            //dt.Columns.Add(ctCol_SystematicColorNm,typeof(string));
            //dt.Columns[ctCol_SystematicColorNm].DefaultValue = "";
            // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            //// 商品区分グループコード
            //dt.Columns.Add(ctCol_LargeGoodsGanreCode,typeof(string));
            //dt.Columns[ctCol_LargeGoodsGanreCode].DefaultValue = "";
            //// 商品区分グループ名称
            //dt.Columns.Add(ctCol_LargeGoodsGanreName,typeof(string));
            //dt.Columns[ctCol_LargeGoodsGanreName].DefaultValue = "";
            //// 商品区分コード
            //dt.Columns.Add(ctCol_MediumGoodsGanreCode,typeof(string));
            //dt.Columns[ctCol_MediumGoodsGanreCode].DefaultValue = "";
            //// 商品区分名称
            //dt.Columns.Add(ctCol_MediumGoodsGanreName,typeof(string));
            //dt.Columns[ctCol_MediumGoodsGanreName].DefaultValue = "";
            //// 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
            //// 商品区分詳細コード
            //dt.Columns.Add(ctCol_DetailGoodsGanreCode, typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreCode].DefaultValue = "";
            //// 商品区分詳細名称
            //dt.Columns.Add(ctCol_DetailGoodsGanreName, typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreName].DefaultValue = "";
            //// 自社分類コード
            //dt.Columns.Add(ctCol_EnterpriseGanreCode, typeof(Int32));
            //dt.Columns[ctCol_EnterpriseGanreCode].DefaultValue = 0;
            //// 自社分類名称
            //dt.Columns.Add(ctCol_EnterpriseGanreName, typeof(string));
            //dt.Columns[ctCol_EnterpriseGanreName].DefaultValue = "";
            //--- DEL 2008/08/01 ----------<<<<<
            // ＢＬ商品コード
            dt.Columns.Add(ctCol_BLGoodsCode, typeof(Int32));
            dt.Columns[ctCol_BLGoodsCode].DefaultValue = 0;
            // ＢＬ商品名称
            dt.Columns.Add(ctCol_BLGoodsName, typeof(string));
            dt.Columns[ctCol_BLGoodsName].DefaultValue = "";
            // 倉庫コード
            dt.Columns.Add(ctCol_WarehouseCode, typeof(string));
            dt.Columns[ctCol_WarehouseCode].DefaultValue = "";
            // 倉庫名称
            dt.Columns.Add(ctCol_WarehouseName, typeof(string));
            dt.Columns[ctCol_WarehouseName].DefaultValue = "";
            // 2008.01.24 追加 >>>>>>>>>>>>>>>>>>>>
            // 倉庫棚番
            dt.Columns.Add(ctCol_WarehouseShelfNo, typeof(string));
            dt.Columns[ctCol_WarehouseShelfNo].DefaultValue = "";
            // 2008.01.24 追加 <<<<<<<<<<<<<<<<<<<<
            // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
            // 最低在庫数
            dt.Columns.Add(ctCol_MinimumStockCnt,typeof(Double));
            dt.Columns[ctCol_MinimumStockCnt].DefaultValue = 0;
            // 最高在庫数
            dt.Columns.Add(ctCol_MaximumStockCnt,typeof(Double));
            dt.Columns[ctCol_MaximumStockCnt].DefaultValue = 0;
            //--- DEL 2008/08/01 ---------->>>>>
            //// 基準発注数
            //dt.Columns.Add(ctCol_NmlSalOdrCount,typeof(Double));
            //dt.Columns[ctCol_NmlSalOdrCount].DefaultValue = 0;
            //// 発注単位
            //dt.Columns.Add(ctCol_SalOdrLot,typeof(Int32));
            //dt.Columns[ctCol_SalOdrLot].DefaultValue = 0;
            //// 在庫保有総額
            //dt.Columns.Add(ctCol_StockTotalPrice,typeof(Int64));
            //dt.Columns[ctCol_StockTotalPrice].DefaultValue = 0;
            //// ソート順計ブレイクキー
            //dt.Columns.Add(ctCol_SortTotalKey,typeof(string));
            //dt.Columns[ctCol_SortTotalKey].DefaultValue = "";
            //// 拠点名称(明細用)
            //dt.Columns.Add(ctCol_SectionName_Detail,typeof(string));
            //dt.Columns[ctCol_SectionName_Detail].DefaultValue = "";
            ////メーカーコード(印刷用)
            //dt.Columns.Add(ctCol_MakerCode_Print,typeof(string));
            //dt.Columns[ctCol_MakerCode_Print].DefaultValue = "";
            //--- DEL 2008/08/01 ----------<<<<<
            // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
            ////キャリアコード(印刷用)
            //dt.Columns.Add(ctCol_CarrierCode_Print,typeof(string));
            //dt.Columns[ctCol_CarrierCode_Print].DefaultValue = "";
            ////系統色コード(印刷用)
            //dt.Columns.Add(ctCol_SystematicColorCd_Print,typeof(string));
            //dt.Columns[ctCol_SystematicColorCd_Print].DefaultValue = "";
            // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ---------->>>>>
            ////商品区分グループコード(印刷用)
            //dt.Columns.Add(ctCol_LargeGoodsGanreCode_Print,typeof(string));
            //dt.Columns[ctCol_LargeGoodsGanreCode_Print].DefaultValue = "";
            ////商品区分コード(印刷用)
            //dt.Columns.Add(ctCol_MediumGoodsGanreCode_Print,typeof(string));
            //dt.Columns[ctCol_MediumGoodsGanreCode_Print].DefaultValue = "";                               
            //// 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
            ////商品区分詳細コード(印刷用)
            //dt.Columns.Add(ctCol_DetailGoodsGanreCode_Print,typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreCode_Print].DefaultValue = "";                               
            //// 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008/08/01 ----------<<<<<

            //--- ADD 2008/08/01 ---------->>>>>
            // 在庫発注先コード
            dt.Columns.Add(ctCol_StockSupplierCode, typeof(Int32));
            dt.Columns[ctCol_StockSupplierCode].DefaultValue = 0;

            // 仕入先略称
            dt.Columns.Add(ctCol_SupplierSnm, typeof(string));
            dt.Columns[ctCol_SupplierSnm].DefaultValue = "";

            /* --- DEL 2008/10/08 ID変更の為 ----------------------->>>>>
            // 部品管理区分１
            dt.Columns.Add(ctCol_DuplicationShelfNo1, typeof(string));
            dt.Columns[ctCol_DuplicationShelfNo1].DefaultValue = "";

            // 部品管理区分２
            dt.Columns.Add(ctCol_DuplicationShelfNo2, typeof(string));
            dt.Columns[ctCol_DuplicationShelfNo2].DefaultValue = "";
               --- DEL 2008/10/08 ----------------------------------<<<<< */
            // --- ADD 2008/10/08 ---------------------------------->>>>>
            // 部品管理区分１
            dt.Columns.Add(ctCol_PartsManagementDivide1, typeof(string));
            dt.Columns[ctCol_PartsManagementDivide1].DefaultValue = "";

            // 部品管理区分２
            dt.Columns.Add(ctCol_PartsManagementDivide2, typeof(string));
            dt.Columns[ctCol_PartsManagementDivide2].DefaultValue = "";
            // --- ADD 2008/10/08 ----------------------------------<<<<<

            // 在庫登録日
            dt.Columns.Add(ctCol_StockCreateDate, typeof(string));
            dt.Columns[ctCol_StockCreateDate].DefaultValue = 0;

            // 計上年月
            dt.Columns.Add(ctCol_AddUpYearMonth, typeof(Int32));
            dt.Columns[ctCol_AddUpYearMonth].DefaultValue = 0;

            // 出荷金額
            dt.Columns.Add(ctCol_ShipmentPrice, typeof(Int64));
            dt.Columns[ctCol_ShipmentPrice].DefaultValue = 0;

            // １ヶ月前
            dt.Columns.Add(ctCol_ShipmentCntBefore1, typeof(Double));
            dt.Columns[ctCol_ShipmentCntBefore1].DefaultValue = 0;

            // ２ヶ月前
            dt.Columns.Add(ctCol_ShipmentCntBefore2, typeof(Double));
            dt.Columns[ctCol_ShipmentCntBefore2].DefaultValue = 0;

            // ３ヶ月前
            dt.Columns.Add(ctCol_ShipmentCntBefore3, typeof(Double));
            dt.Columns[ctCol_ShipmentCntBefore3].DefaultValue = 0;

            // ６ヶ月合計
            dt.Columns.Add(ctCol_ShipmentCntBeforeTotal, typeof(Double));
            dt.Columns[ctCol_ShipmentCntBeforeTotal].DefaultValue = 0;

            // １ヶ月前
            dt.Columns.Add(ctCol_ShipmentPriceBefore1, typeof(Double));
            dt.Columns[ctCol_ShipmentPriceBefore1].DefaultValue = 0;

            // ２ヶ月前
            dt.Columns.Add(ctCol_ShipmentPriceBefore2, typeof(Double));
            dt.Columns[ctCol_ShipmentPriceBefore2].DefaultValue = 0;

            // ３ヶ月前
            dt.Columns.Add(ctCol_ShipmentPriceBefore3, typeof(Double));
            dt.Columns[ctCol_ShipmentPriceBefore3].DefaultValue = 0;

            // ６ヶ月合計
            dt.Columns.Add(ctCol_ShipmentPriceBeforeTotal, typeof(Double));
            dt.Columns[ctCol_ShipmentPriceBeforeTotal].DefaultValue = 0;

            dt.Columns.Add(ctCol_WarehouseShelfNoBreak, typeof(string)); // 倉庫棚番ブレイク
            dt.Columns[ctCol_WarehouseShelfNoBreak].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_SectionCode, typeof(string)); // ソート用　拠点コード
            dt.Columns[ctCol_Sort_SectionCode].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_WarehouseCode, typeof(string)); // ソート用　倉庫コード
            dt.Columns[ctCol_Sort_WarehouseCode].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_CustomerCode, typeof(Int32)); // ソート用　仕入先コード
            dt.Columns[ctCol_Sort_CustomerCode].DefaultValue = 0;

            dt.Columns.Add(ctCol_Sort_GoodsMakerCd, typeof(Int32)); // ソート用　商品メーカーコード
            dt.Columns[ctCol_Sort_GoodsMakerCd].DefaultValue = 0;

            dt.Columns.Add(ctCol_Sort_GoodsNo, typeof(string)); // ソート用　商品番号
            dt.Columns[ctCol_Sort_GoodsNo].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_WarehouseShelfNo, typeof(string)); // ソート用　倉庫棚番
            dt.Columns[ctCol_Sort_WarehouseShelfNo].DefaultValue = "";

            dt.Columns.Add(ctCol_Sort_WarehouseShelfNoBreak, typeof(string)); // ソート用　倉庫棚番ブレイク
            dt.Columns[ctCol_Sort_WarehouseShelfNoBreak].DefaultValue = "";
            //--- ADD 2008/08/01 ----------<<<<<
        }

		#endregion
	}
}