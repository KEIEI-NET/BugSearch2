using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// 棚卸関連一覧表抽出結果データテーブルスキーマクラス
	/// </summa ry>
	/// <remarks>
    /// <br>Note       : 棚卸関連一覧表抽出結果テーブルスキーマです。</br>
	/// <br>Programmer : 23010　中村　仁</br>
	/// <br>Date       : 2007.04.09</br>
    /// <br>Update Note: 2007.09.14 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.02.13 980035 金沢 貞義</br>
    /// <br>			 ・棚卸実施日対応（DC.NS対応）</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.10.14</br>
    /// <br>Update Note: 2009/12/07 張凱</br>
    /// <br>			 不具合対応(PM.NS保守依頼③対応)</br>
    /// <br>Update Note: 2010/02/20 呉元嘯</br>
    /// <br>			 不具合対応(PM1005)</br>
    /// <br>Update Note: K2014/03/10 licb</br>
    ///	<br>			 管理番号 11000606-00 信越自動車商会個別開発 テキスト出力機能を追加する</br>
    /// </remarks>
	public class MAZAI02114EA
	{
		#region Public Members
		/// <summary>データセット名</summary>
        public const string InventoryListDataSet = "InventoryListDataSet";
		/// <summary>データテーブル名</summary>
        public const string InventoryListDataTable = "InventoryListDataTable";
        /// <summary>棚卸関連一覧表バッファデータテーブル名</summary>
        public const string InventoryListCommonBuffDataTable = "InventoryListCommonBuffDataTable";

        #region 棚卸関連一覧表カラム情報

        // 2008.10.14 30413 犬飼 棚卸関連一覧表カラム情報を全更新 >>>>>>START
        ///// <summary>拠点コード</summary>
        //public const string ctCol_SectionCode = "SectionCode";
        ///// <summary>拠点ガイド名称</summary>
        //public const string ctCol_SectionGuideNm = "SectionGuideNm";
        ///// <summary>棚卸通番</summary>
        //public const string ctCol_InventorySeqNo = "InventorySeqNo";
        ///// <summary>メーカーコード</summary>
        //public const string ctCol_MakerCode = "MakerCode";
        ///// <summary>メーカー名称</summary>
        //public const string ctCol_MakerName = "MakerName";
        ///// <summary>商品コード</summary>
        //public const string ctCol_GoodsCode = "GoodsCode";
        ///// <summary>商品名称</summary>
        //public const string ctCol_GoodsName = "GoodsName";
        //// 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>機種コード</summary>
        ////public const string ctCol_CellphoneModelCode = "CellphoneModelCode";
        /////// <summary>機種名称</summary>
        ////public const string ctCol_CellphoneModelName = "CellphoneModelName";
        /////// <summary>キャリアコード</summary>
        ////public const string ctCol_CarrierCode = "CarrierCode";
        /////// <summary>キャリア名称</summary>
        ////public const string ctCol_CarrierName = "CarrierName";
        /////// <summary>系統色コード</summary>
        ////public const string ctCol_SystematicColorCd = "SystematicColorCd";
        /////// <summary>系統色名称</summary>
        ////public const string ctCol_SystematicColorNm = "SystematicColorNm";
        //// 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>商品区分グループコード</summary>
        //public const string ctCol_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        ///// <summary>商品区分グループ名称</summary>
        //public const string ctCol_LargeGoodsGanreName = "LargeGoodsGanreName";
        ///// <summary>商品区分コード</summary>
        //public const string ctCol_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        ///// <summary>商品区分名称</summary>
        //public const string ctCol_MediumGoodsGanreName = "MediumGoodsGanreName";
        //// 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>商品区分詳細コード</summary>
        //public const string ctCol_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        ///// <summary>商品区分詳細名称</summary>
        //public const string ctCol_DetailGoodsGanreName = "DetailGoodsGanreName";
        ///// <summary>ＢＬ商品コード</summary>
        //public const string ctCol_BLGoodsCode = "BLGoodsCode";
        ///// <summary>ＢＬ商品名称</summary>
        //public const string ctCol_BLGoodsName = "BLGoodsName";
        ///// <summary>自社分類コード</summary>
        //public const string ctCol_EnterpriseGanreCode = "EnterpriseGanreCode";
        ///// <summary>自社分類名称</summary>
        //public const string ctCol_EnterpriseGanreName = "EnterpriseGanreName";
        ///// <summary>棚番</summary>
        //public const string ctCol_WarehouseShelfNo = "WarehouseShelfNo";
        ///// <summary>重複棚番1</summary>
        //public const string ctCol_DuplicationShelfNo1 = "DuplicationShelfNo1";
        ///// <summary>重複棚番2</summary>
        //public const string ctCol_DuplicationShelfNo2 = "DuplicationShelfNo2";
        //// 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>JANコード</summary>
        //public const string ctCol_Jan = "Jan";
        ///// <summary>仕入単価</summary>
        //public const string ctCol_StockUnitPrice = "StockUnitPrice";
        ///// <summary>変更前仕入単価</summary>
        //public const string ctCol_BfStockUnitPrice = "BfStockUnitPrice";
        ///// <summary>仕入単価変更フラグ</summary>
        //public const string ctCol_StkUnitPriceChgFlg = "StkUnitPriceChgFlg";
        //// 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>在庫委託受託区分</summary>
        ////public const string ctCol_StockTrtEntDiv = "StockTrtEntDiv";
        //// 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>棚卸在庫数</summary>
        //public const string ctCol_InventoryStkCnt = "InventoryStkCnt";
        ///// <summary>棚卸過不足数</summary>
        //public const string ctCol_InventoryTolerancCnt = "InventoryTolerancCnt";
        ///// <summary>棚卸準備処理日付</summary>
        //public const string ctCol_InventoryPreprDay = "InventoryPreprDay";
        ///// <summary>棚卸実施日</summary>
        //public const string ctCol_InventoryDay = "InventoryDay";
        ///// <summary>棚卸更新日</summary>
        //public const string ctCol_InventoryUpDate = "InventoryUpDate";
        ///// <summary>棚卸新規追加区分</summary>
        //public const string ctCol_InventoryNewDiv = "InventoryNewDiv";
        //// 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>製番管理区分</summary>
        ////public const string ctCol_PrdNumMngDiv = "PrdNumMngDiv";
        //// 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>最終仕入年月日</summary>
        //public const string ctCol_LastStockDate = "LastStockDate";
        ///// <summary>在庫数</summary>
        //public const string ctCol_StockCnt = "StockCnt";
        //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>実施日帳簿数</summary>
        //public const string ctCol_StockTotalExec = "StockTotalExec";
        ///// <summary>棚卸日</summary>
        //public const string ctCol_InventoryDate = "InventoryDate";
        //// 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>製番在庫マスタGUID</summary>
        //public const string ctCol_ProductStockGuid = "ProductStockGuid";
        ///// <summary>倉庫コード</summary>
        //public const string ctCol_WarehouseCode = "WarehouseCode";
        ///// <summary>倉庫名称</summary>
        //public const string ctCol_WarehouseName = "WarehouseName";
        //// 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>事業者コード</summary>
        ////public const string ctCol_CarrierEpCode = "CarrierEpCode";
        /////// <summary>事業者名称</summary>
        ////public const string ctCol_CarrierEpName = "CarrierEpName";
        /////// <summary>仕入日</summary>
        ////public const string ctCol_StockDate = "StockDate";
        /////// <summary>入荷日</summary>
        ////public const string ctCol_ArrivalGoodsDay = "ArrivalGoodsDay";
        /////// <summary>製造番号</summary>
        ////public const string ctCol_ProductNumber = "ProductNumber";
        /////// <summary>商品電話番号1</summary>
        ////public const string ctCol_StockTelNo1 = "StockTelNo1";
        /////// <summary>変更前商品電話番号1</summary>
        ////public const string ctCol_BfStockTelNo1 = "BfStockTelNo1";
        /////// <summary>商品電話番号1変更フラグ</summary>
        ////public const string ctCol_StkTelNo1ChgFlg = "StkTelNo1ChgFlg";
        /////// <summary>商品電話番号2</summary>
        ////public const string ctCol_StockTelNo2 = "StockTelNo2";
        /////// <summary>変更前商品電話番号2</summary>
        ////public const string ctCol_BfStockTelNo2 = "BfStockTelNo2";
        /////// <summary>商品電話番号2変更フラグ</summary>
        ////public const string ctCol_StkTelNo2ChgFlg = "StkTelNo2ChgFlg";
        //// 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>明細用拠点名称</summary>
        //public const string ctCol_SectionName_Detail = "SectionName_Detail";
        ///// <summary>得意先コード(仕入先)</summary>
        //public const string ctCol_CustomerCode = "CustomerCode";
        ///// <summary>得意先名称(仕入先)</summary>
        //public const string ctCol_CustomerName = "CustomerName";
        ///// <summary>得意先名称２(仕入先)</summary>
        //public const string ctCol_CustomerName2 = "CustomerName2";
        ///// <summary>出荷先得意先コード(委託先)</summary>
        //public const string ctCol_ShipCustomerCode = "ShipCustomerCode";
        ///// <summary>出荷先得意先名称(委託先)</summary>
        //public const string ctCol_ShipCustomerName = "ShipCustomerName";
        ///// <summary>出荷先得意先名称２(委託先)</summary>
        //public const string ctCol_ShipCustomerName2 = "ShipCustomerName2";
        ///// <summary>差異金額</summary>
        //public const string ctCol_TolerancPrice = "TolerancPrice";
        ///// <summary>在庫金額(仮)</summary>
        //public const string ctCol_StockPrice = "StockPrice";

        
        /// <summary> 拠点コード </summary>
        public const string ctCol_SectionCode = "SectionCode";
        /// <summary> 拠点ガイド名称 </summary>
        public const string ctCol_SectionGuideNm = "SectionGuideNm";
        /// <summary> 棚卸通番 </summary>
        public const string ctCol_InventorySeqNo = "InventorySeqNo";
        /// <summary> 倉庫コード </summary>
        public const string ctCol_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ctCol_WarehouseName = "WarehouseName";
        /// <summary> 商品メーカーコード </summary>
        public const string ctCol_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ctCol_MakerName = "MakerName";
        /// <summary> 商品番号 </summary>
        public const string ctCol_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ctCol_GoodsName = "GoodsName";
        /// <summary> 倉庫棚番 </summary>
        public const string ctCol_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 重複棚番1 </summary>
        public const string ctCol_DuplicationShelfNo1 = "DuplicationShelfNo1";
        /// <summary> 重複棚番2 </summary>
        public const string ctCol_DuplicationShelfNo2 = "DuplicationShelfNo2";
        /// <summary> 商品大分類コード </summary>
        public const string ctCol_GoodsLGroup = "GoodsLGroup";
        /// <summary> 商品大分類コード名称 </summary>
        public const string ctCol_GoodsLGroupName = "GoodsLGroupName";
        /// <summary> 商品中分類コード </summary>
        public const string ctCol_GoodsMGroup = "GoodsMGroup";
        /// <summary> 商品中分類コード名称 </summary>
        public const string ctCol_GoodsMGroupName = "GoodsMGroupName";
        /// <summary> BLグループコード </summary>
        public const string ctCol_BLGroupCode = "BLGroupCode";
        /// <summary> BLグループコード名称 </summary>
        public const string ctCol_BLGroupName = "BLGroupName";
        /// <summary> 自社分類コード </summary>
        public const string ctCol_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary> 自社分類名称 </summary>
        public const string ctCol_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary> ＢＬ商品コード </summary>
        public const string ctCol_BLGoodsCode = "BLGoodsCode";
        /// <summary> ＢＬ商品コード枝番 </summary>
        public const string ctCol_BLGoodsCdDerivedNo = "BLGoodsCdDerivedNo";
        /// <summary> ＢＬ商品名称 </summary>
        public const string ctCol_BLGoodsName = "BLGoodsName";
        /// <summary> 仕入先コード </summary>
        public const string ctCol_SupplierCd = "SupplierCd";
        /// <summary> ＪＡＮコード </summary>
        public const string ctCol_Jan = "Jan";
        /// <summary> 仕入単価 </summary>
        public const string ctCol_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> 変更前仕入単価 </summary>
        public const string ctCol_BfStockUnitPriceFl = "BfStockUnitPriceFl";
        /// <summary> 仕入単価変更フラグ </summary>
        public const string ctCol_StkUnitPriceChgFlg = "StkUnitPriceChgFlg";
        /// <summary> 在庫区分 </summary>
        public const string ctCol_StockDiv = "StockDiv";
        /// <summary> 最終仕入年月日 </summary>
        public const string ctCol_LastStockDate = "LastStockDate";
        /// <summary> 在庫総数 </summary>
        public const string ctCol_StockTotal = "StockTotal";
        /// <summary> 出荷先得意先コード </summary>
        public const string ctCol_ShipCustomerCode = "ShipCustomerCode";
        /// <summary> 出荷先得意先名称 </summary>
        public const string ctCol_ShipCustomerName = "ShipCustomerName";
        /// <summary> 出荷得意先名称2 </summary>
        public const string ctCol_ShipCustomerName2 = "ShipCustomerName2";
        /// <summary> 棚卸在庫数 </summary>
        public const string ctCol_InventoryStockCnt = "InventoryStockCnt";
        /// <summary> 棚卸過不足数 </summary>
        public const string ctCol_InventoryTolerancCnt = "InventoryTolerancCnt";
        /// <summary> 棚卸準備処理日付 </summary>
        public const string ctCol_InventoryPreprDay = "InventoryPreprDay";
        /// <summary> 棚卸準備処理時間 </summary>
        public const string ctCol_InventoryPreprTim = "InventoryPreprTim";
        /// <summary> 棚卸実施日 </summary>
        public const string ctCol_InventoryDay = "InventoryDay";
        /// <summary> 最終棚卸更新日 </summary>
        public const string ctCol_LastInventoryUpdate = "LastInventoryUpdate";
        /// <summary> 棚卸新規追加区分 </summary>
        public const string ctCol_InventoryNewDiv = "InventoryNewDiv";
        /// <summary> マシン在庫額 </summary>
        public const string ctCol_StockMashinePrice = "StockMashinePrice";
        /// <summary> 棚卸在庫額 </summary>
        public const string ctCol_InventoryStockPrice = "InventoryStockPrice";
        /// <summary> 棚卸過不足金額 </summary>
        public const string ctCol_InventoryTlrncPrice = "InventoryTlrncPrice";
        /// <summary> 定価（浮動） </summary>
        public const string ctCol_ListPriceFl = "ListPriceFl";
        /// <summary> 棚卸日 </summary>
        public const string ctCol_InventoryDate = "InventoryDate";
        /// <summary> 在庫総数（実施日） </summary>
        public const string ctCol_StockTotalExec = "StockTotalExec";
        /// <summary> 過不足更新区分 </summary>
        public const string ctCol_ToleranceUpdateCd = "ToleranceUpdateCd";
        /// <summary> 算出在庫数 </summary>
        public const string ctCol_StockAmount = "StockAmount";
        // 2008.10.14 30413 犬飼 棚卸関連一覧表カラム情報を全更新 <<<<<<END

        /// <summary>在庫区分(UI)</summary>
        public const string ctCol_UiSotckDiv = "UiSotckDiv";


        //印刷用カラム
        /// <summary>倉庫コード(印刷用)</summary>
        public const string ctCol_WarehouseCode_Print = "WarehouseCode_Print";
        /// <summary>仕入先コード(印刷用)</summary>
        public const string ctCol_SupplierCd_Print = "SupplierCd_Print";
        /// <summary>BLコード(印刷用)</summary>
        public const string ctCol_BLGoodsCode_Print = "BLGoodsCode_Print";
        /// <summary>グループコード(印刷用)</summary>
        public const string ctCol_BLGroupCode_Print = "BLGroupCode_Print";
        /// <summary>メーカーコード(印刷用)</summary>
        public const string ctCol_MakerCode_Print = "MakerCode_Print";
        // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>キャリアコード(印刷用)</summary>
        //public const string ctCol_CarrierCode_Print = "CarrierCode_Print";
        ///// <summary>系統色コード(印刷用)</summary>
        //public const string ctCol_SystematicColorCd_Print = "SystematicColorCd_Print";
        // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary>商品区分グループコード(印刷用)</summary>
        public const string ctCol_LargeGoodsGanreCode_Print = "LargeGoodsGanreCode_Print";
        /// <summary>商品区分コード(印刷用)</summary>
        public const string ctCol_MediumGoodsGanreCode_Print = "MediumGoodsGanreCode_Print";
        // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>事業者コード(印刷用)</summary>
        //public const string ctCol_CarrierEpCode_Print = "CarrierEpCode_Print";
        // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary>棚卸準備処理日付</summary>
        public const string ctCol_InventoryPreprDay_Print = "InventoryPreprDay_Print";
        /// <summary>棚卸実施日</summary>
        public const string ctCol_InventoryDay_Print = "InventoryDay_Print";
        /// <summary>棚卸更新日</summary>
        public const string ctCol_InventoryUpDate_Print = "InventoryUpDate_Print";
        /// <summary>最終仕入年月日</summary>
        public const string ctCol_LastStockDate_Print = "LastStockDate_Print";
        // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>仕入日</summary>
        //public const string ctCol_StockDate_Print = "StockDate_Print";
        ///// <summary>入荷日</summary>
        //public const string ctCol_ArrivalGoodsDay_Print = "ArrivalGoodsDay_Print";
        // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary>在庫区分</summary>
        public const string ctCol_StockDiv_Print = "StockDiv_Print";
        // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>棚番（棚番ブレイク用）</summary>
        public const string ctCol_WarehouseShelfNo_Print = "WarehouseShelfNo_Print";
        // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
        // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
        /// <summary>棚卸日</summary>
        public const string ctCol_InventoryDate_Print = "InventoryDate_Print";
        // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<

        // 2008.11.04 30413 犬飼 棚卸差異表の差異小計印字 >>>>>>START
        /// <summary> プラスの差異数 </summary>
        public const string ctCol_PlusInventoryTolerancCnt = "PlusInventoryTolerancCnt";
        /// <summary> マイナスの差異数 </summary>
        public const string ctCol_MinusInventoryTolerancCnt = "MinusInventoryTolerancCnt";
        /// <summary> プラスの差異金額 </summary>
        public const string ctCol_PlusInventoryTlrncPrice = "PlusInventoryTlrncPrice";
        /// <summary> マイナスの差異金額 </summary>
        public const string ctCol_MinusInventoryTlrncPrice = "MinusInventoryTlrncPrice";
        // 2008.11.04 30413 犬飼 棚卸差異表の差異小計印字 <<<<<<END

        /// <summary> 棚卸数(印字用) </summary>
        public const string ctCol_StockCount_Print = "StockCount_Print";
        /// <summary> 標準価格(価格マスタの定価)(印字用) </summary>
        public const string ctCol_ListPrice_Print = "ListPrice_Print";
        /// <summary> 原単価(仕入単価)(印字用) </summary>
        public const string ctCol_StockUnitPriceFl_Print = "StockUnitPriceFl_Print";
        /// <summary> 算出棚卸金額(印字用) </summary>
        public const string ctCol_StockAmountPrice_Print = "StockAmountPrice_Print";

        // -------ADD 2009/12/07------->>>>>
        /// <summary>棚卸数、原単価、帳薄数空白Flag</summary>
        public const string ctCol_BlankShowFlag_Print = "BlankShowFlag_Print";
        // -------ADD 2009/12/07-------<<<<<
        // -------ADD 2010/02/20------->>>>>
        /// <summary>棚卸数空白Flag</summary>
        public const string ctCol_InvStockCntFlag_Print = "InvStockCntFlag_Print";
        // -------ADD 2010/02/20-------<<<<<
        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
        /// <summary>棚卸在庫数テキスト用</summary>
        public const string ctCol_InventoryStockCntTextOut = "InventoryStockCntTextOut";
        /// <summary>標準価格テキスト用</summary>
        public const string ctCol_ListPriceTextOut = "ListPriceTextOut";
        // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

		#endregion

		#endregion

		#region Constructor
		/// <summary>
        /// 棚卸関連一覧表抽出結果データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 棚卸関連一覧表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		public MAZAI02114EA()
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
		/// <br>Date       : 2007.04.10</br>
        /// <br>Update Note: 2007.09.14 980035 金沢 貞義</br>
        /// <br>			 ・DC.NS対応</br>
        /// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(InventoryListDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
                ds.Tables[InventoryListDataTable].Clear();
			}
			else
			{
                CreateRestListCommonTable(ref ds, 0);
			}

            // 在庫車両入出庫管理表抽出結果バッファデータテーブル------------------------------------------
			// テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(InventoryListCommonBuffDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
                ds.Tables[InventoryListCommonBuffDataTable].Clear();
			}
			else
			{
                CreateRestListCommonTable(ref ds, 1);
			}
		}
		
		
		/// <summary>
        /// 棚卸関連一覧表抽出結果作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.10</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 信越自動車商会個別開発 テキスト出力機能を追加する</br>
		/// </remarks>
        private static void CreateRestListCommonTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// スキーマ設定
                ds.Tables.Add(InventoryListDataTable);
                dt = ds.Tables[InventoryListDataTable];
			}
			else
			{
				// スキーマ設定
                ds.Tables.Add(InventoryListCommonBuffDataTable);
                dt = ds.Tables[InventoryListCommonBuffDataTable];
            }

            // 2008.10.14 30413 犬飼 棚卸関連一覧表カラム情報を全更新 >>>>>>START

            string defValuestring = "";
            Int32 defValueInt32 = 0;
            Int64 defValueInt64 = 0;
            double defValueDouble = 0.0;

            //// 拠点コード
            //dt.Columns.Add(ctCol_SectionCode,typeof(string));
            //dt.Columns[ctCol_SectionCode].DefaultValue = "";
            //// 拠点ガイド名称
            //dt.Columns.Add(ctCol_SectionGuideNm,typeof(string));
            //dt.Columns[ctCol_SectionGuideNm].DefaultValue = "";
            //// 棚卸通番
            //dt.Columns.Add(ctCol_InventorySeqNo,typeof(Int32));
            //dt.Columns[ctCol_InventorySeqNo].DefaultValue = 0;                       
            //// メーカーコード
            //dt.Columns.Add(ctCol_MakerCode,typeof(Int32));
            //dt.Columns[ctCol_MakerCode].DefaultValue = 0;
            //// メーカー名称
            //dt.Columns.Add(ctCol_MakerName,typeof(string));
            //dt.Columns[ctCol_MakerName].DefaultValue = "";
            //// 商品コード
            //dt.Columns.Add(ctCol_GoodsCode,typeof(string));
            //dt.Columns[ctCol_GoodsCode].DefaultValue = "";
            //// 商品名称
            //dt.Columns.Add(ctCol_GoodsName,typeof(string));
            //dt.Columns[ctCol_GoodsName].DefaultValue = "";
            //// 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 機種コード
            ////dt.Columns.Add(ctCol_CellphoneModelCode,typeof(string));
            ////dt.Columns[ctCol_CellphoneModelCode].DefaultValue = "";
            ////// 機種名称
            ////dt.Columns.Add(ctCol_CellphoneModelName,typeof(string));
            ////dt.Columns[ctCol_CellphoneModelName].DefaultValue = "";
            ////// キャリアコード
            ////dt.Columns.Add(ctCol_CarrierCode,typeof(Int32));
            ////dt.Columns[ctCol_CarrierCode].DefaultValue = 0;
            ////// キャリア名称
            ////dt.Columns.Add(ctCol_CarrierName,typeof(string));
            ////dt.Columns[ctCol_CarrierName].DefaultValue = "";
            ////// 系統色コード
            ////dt.Columns.Add(ctCol_SystematicColorCd,typeof(Int32));
            ////dt.Columns[ctCol_SystematicColorCd].DefaultValue = 0;
            ////// 系統色名称
            ////dt.Columns.Add(ctCol_SystematicColorNm,typeof(string));
            ////dt.Columns[ctCol_SystematicColorNm].DefaultValue = "";
            //// 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
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
            //// 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            //// 商品区分詳細コード
            //dt.Columns.Add(ctCol_DetailGoodsGanreCode,typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreCode].DefaultValue = "";
            //// 商品区分詳細名称
            //dt.Columns.Add(ctCol_DetailGoodsGanreName,typeof(string));
            //dt.Columns[ctCol_DetailGoodsGanreName].DefaultValue = "";
            //// ＢＬ商品コード
            //dt.Columns.Add(ctCol_BLGoodsCode,typeof(Int32));
            //dt.Columns[ctCol_BLGoodsCode].DefaultValue = 0;
            //// ＢＬ商品名称
            //dt.Columns.Add(ctCol_BLGoodsName,typeof(string));
            //dt.Columns[ctCol_BLGoodsName].DefaultValue = "";
            //// 自社分類コード
            //dt.Columns.Add(ctCol_EnterpriseGanreCode,typeof(Int32));
            //dt.Columns[ctCol_EnterpriseGanreCode].DefaultValue = 0;
            //// 自社分類名称
            //dt.Columns.Add(ctCol_EnterpriseGanreName,typeof(string));
            //dt.Columns[ctCol_EnterpriseGanreName].DefaultValue = "";
            //// 棚番
            //dt.Columns.Add(ctCol_WarehouseShelfNo,typeof(string));
            //dt.Columns[ctCol_WarehouseShelfNo].DefaultValue = "";
            //// 重複棚番1
            //dt.Columns.Add(ctCol_DuplicationShelfNo1, typeof(string));
            //dt.Columns[ctCol_DuplicationShelfNo1].DefaultValue = "";
            //// 重複棚番2
            //dt.Columns.Add(ctCol_DuplicationShelfNo2, typeof(string));
            //dt.Columns[ctCol_DuplicationShelfNo2].DefaultValue = "";
            //// 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
            //// JANコード
            //dt.Columns.Add(ctCol_Jan,typeof(string));
            //dt.Columns[ctCol_Jan].DefaultValue = "";
            //// 仕入単価
            //dt.Columns.Add(ctCol_StockUnitPrice,typeof(Int64));
            //dt.Columns[ctCol_StockUnitPrice].DefaultValue = 0L;
            //// 変更前仕入単価
            //dt.Columns.Add(ctCol_BfStockUnitPrice,typeof(Int64));
            //dt.Columns[ctCol_BfStockUnitPrice].DefaultValue = 0L;
            //// 仕入単価変更フラグ
            //dt.Columns.Add(ctCol_StkUnitPriceChgFlg,typeof(Int32));
            //dt.Columns[ctCol_StkUnitPriceChgFlg].DefaultValue = 0;
            //// 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 在庫委託受託区分
            ////dt.Columns.Add(ctCol_StockTrtEntDiv,typeof(Int32));
            ////dt.Columns[ctCol_StockTrtEntDiv].DefaultValue = 0;
            //// 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
            //// 棚卸在庫数
            //dt.Columns.Add(ctCol_InventoryStkCnt,typeof(Double));
            //dt.Columns[ctCol_InventoryStkCnt].DefaultValue = 0D;
            //// 棚卸過不足数
            //dt.Columns.Add(ctCol_InventoryTolerancCnt,typeof(Double));
            //dt.Columns[ctCol_InventoryTolerancCnt].DefaultValue = 0D;
            //// 棚卸準備処理日付
            //dt.Columns.Add(ctCol_InventoryPreprDay,typeof(Int32));
            //dt.Columns[ctCol_InventoryPreprDay].DefaultValue = 0;
            //// 棚卸実施日
            //dt.Columns.Add(ctCol_InventoryDay,typeof(Int32));
            //dt.Columns[ctCol_InventoryDay].DefaultValue = 0;
            //// 棚卸更新日
            //dt.Columns.Add(ctCol_InventoryUpDate,typeof(Int32));
            //dt.Columns[ctCol_InventoryUpDate].DefaultValue = 0;
            //// 棚卸新規追加区分
            //dt.Columns.Add(ctCol_InventoryNewDiv,typeof(Int32));
            //dt.Columns[ctCol_InventoryNewDiv].DefaultValue = 0;
            //// 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 製番管理区分
            ////dt.Columns.Add(ctCol_PrdNumMngDiv,typeof(Int32));
            ////dt.Columns[ctCol_PrdNumMngDiv].DefaultValue = 0;
            //// 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
            //// 最終仕入年月日
            //dt.Columns.Add(ctCol_LastStockDate,typeof(Int32));
            //dt.Columns[ctCol_LastStockDate].DefaultValue = 0;
            //// 在庫数
            //dt.Columns.Add(ctCol_StockCnt,typeof(Double));
            //dt.Columns[ctCol_StockCnt].DefaultValue = 0D;
            //// 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            //// 実施日帳簿数
            //dt.Columns.Add(ctCol_StockTotalExec, typeof(Double));
            //dt.Columns[ctCol_StockTotalExec].DefaultValue = 0D;
            //// 棚卸日
            //dt.Columns.Add(ctCol_InventoryDate, typeof(Int32));
            //dt.Columns[ctCol_InventoryDate].DefaultValue = 0;
            //// 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            //// 製番在庫マスタGUID
            //dt.Columns.Add(ctCol_ProductStockGuid,typeof(Guid));
            //dt.Columns[ctCol_ProductStockGuid].DefaultValue = Guid.Empty;
            //// 倉庫コード
            //dt.Columns.Add(ctCol_WarehouseCode,typeof(string));
            //dt.Columns[ctCol_WarehouseCode].DefaultValue = "";
            //// 倉庫名称
            //dt.Columns.Add(ctCol_WarehouseName,typeof(string));
            //dt.Columns[ctCol_WarehouseName].DefaultValue = "";
            //// 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////// 事業者コード
            ////dt.Columns.Add(ctCol_CarrierEpCode,typeof(Int32));
            ////dt.Columns[ctCol_CarrierEpCode].DefaultValue = 0;
            ////// 事業者名称
            ////dt.Columns.Add(ctCol_CarrierEpName,typeof(string));
            ////dt.Columns[ctCol_CarrierEpName].DefaultValue = "";
            ////// 仕入日
            ////dt.Columns.Add(ctCol_StockDate,typeof(Int32));
            ////dt.Columns[ctCol_StockDate].DefaultValue = 0;
            ////// 入荷日
            ////dt.Columns.Add(ctCol_ArrivalGoodsDay,typeof(Int32));
            ////dt.Columns[ctCol_ArrivalGoodsDay].DefaultValue = 0;
            ////// 製造番号
            ////dt.Columns.Add(ctCol_ProductNumber,typeof(string));
            ////dt.Columns[ctCol_ProductNumber].DefaultValue = "";
            ////// 商品電話番号1
            ////dt.Columns.Add(ctCol_StockTelNo1,typeof(string));
            ////dt.Columns[ctCol_StockTelNo1].DefaultValue = "";
            ////// 変更前商品電話番号1
            ////dt.Columns.Add(ctCol_BfStockTelNo1,typeof(string));
            ////dt.Columns[ctCol_BfStockTelNo1].DefaultValue = "";
            ////// 商品電話番号1変更フラグ
            ////dt.Columns.Add(ctCol_StkTelNo1ChgFlg,typeof(Int32));
            ////dt.Columns[ctCol_StkTelNo1ChgFlg].DefaultValue = 0;
            ////// 商品電話番号2
            ////dt.Columns.Add(ctCol_StockTelNo2,typeof(string));
            ////dt.Columns[ctCol_StockTelNo2].DefaultValue = "";
            ////// 変更前商品電話番号2
            ////dt.Columns.Add(ctCol_BfStockTelNo2,typeof(string));
            ////dt.Columns[ctCol_BfStockTelNo2].DefaultValue = "";
            ////// 商品電話番号2変更フラグ
            ////dt.Columns.Add(ctCol_StkTelNo2ChgFlg,typeof(Int32));
            ////dt.Columns[ctCol_StkTelNo2ChgFlg].DefaultValue = 0;
            //// 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
            //// 得意先コード(仕入先)
            //dt.Columns.Add(ctCol_CustomerCode,typeof(Int32));
            //dt.Columns[ctCol_CustomerCode].DefaultValue = 0;
            //// 得意先名称(仕入先)
            //dt.Columns.Add(ctCol_CustomerName,typeof(string));
            //dt.Columns[ctCol_CustomerName].DefaultValue = "";
            //// 得意先名称２(仕入先)
            //dt.Columns.Add(ctCol_CustomerName2,typeof(string));
            //dt.Columns[ctCol_CustomerName2].DefaultValue = "";
            //// 出荷先得意先コード(委託先)
            //dt.Columns.Add(ctCol_ShipCustomerCode,typeof(Int32));
            //dt.Columns[ctCol_ShipCustomerCode].DefaultValue = 0;
            //// 出荷先得意先名称(委託先)
            //dt.Columns.Add(ctCol_ShipCustomerName,typeof(string));
            //dt.Columns[ctCol_ShipCustomerName].DefaultValue = "";
            //// 出荷先得意先名称２(委託先)
            //dt.Columns.Add(ctCol_ShipCustomerName2,typeof(string));
            //dt.Columns[ctCol_ShipCustomerName2].DefaultValue = "";
            //// 差異金額
            //dt.Columns.Add(ctCol_TolerancPrice,typeof(Int64));
            //dt.Columns[ctCol_TolerancPrice].DefaultValue = 0L;
            //// 在庫金額(仮)
            //dt.Columns.Add(ctCol_StockPrice,typeof(Int64));
            //dt.Columns[ctCol_StockPrice].DefaultValue = 0L;

            // 拠点コード
            dt.Columns.Add(ctCol_SectionCode, typeof(string));
            dt.Columns[ctCol_SectionCode].DefaultValue = defValuestring;
            // 拠点ガイド名称
            dt.Columns.Add(ctCol_SectionGuideNm, typeof(string));
            dt.Columns[ctCol_SectionGuideNm].DefaultValue = defValuestring;
            // 棚卸通番
            dt.Columns.Add(ctCol_InventorySeqNo, typeof(Int32));
            dt.Columns[ctCol_InventorySeqNo].DefaultValue = defValueInt32;
            // 倉庫コード
            dt.Columns.Add(ctCol_WarehouseCode, typeof(string));
            dt.Columns[ctCol_WarehouseCode].DefaultValue = defValuestring;
            // 倉庫名称
            dt.Columns.Add(ctCol_WarehouseName, typeof(string));
            dt.Columns[ctCol_WarehouseName].DefaultValue = defValuestring;
            // 商品メーカーコード
            dt.Columns.Add(ctCol_GoodsMakerCd, typeof(Int32));
            dt.Columns[ctCol_GoodsMakerCd].DefaultValue = defValueInt32;
            // メーカー名称
            dt.Columns.Add(ctCol_MakerName, typeof(string));
            dt.Columns[ctCol_MakerName].DefaultValue = defValuestring;
            // 商品番号
            dt.Columns.Add(ctCol_GoodsNo, typeof(string));
            dt.Columns[ctCol_GoodsNo].DefaultValue = defValuestring;
            // 商品名称
            dt.Columns.Add(ctCol_GoodsName, typeof(string));
            dt.Columns[ctCol_GoodsName].DefaultValue = defValuestring;
            // 倉庫棚番
            dt.Columns.Add(ctCol_WarehouseShelfNo, typeof(string));
            dt.Columns[ctCol_WarehouseShelfNo].DefaultValue = defValuestring;
            // 重複棚番1
            dt.Columns.Add(ctCol_DuplicationShelfNo1, typeof(string));
            dt.Columns[ctCol_DuplicationShelfNo1].DefaultValue = defValuestring;
            // 重複棚番2
            dt.Columns.Add(ctCol_DuplicationShelfNo2, typeof(string));
            dt.Columns[ctCol_DuplicationShelfNo2].DefaultValue = defValuestring;
            // 商品大分類コード
            dt.Columns.Add(ctCol_GoodsLGroup, typeof(Int32));
            dt.Columns[ctCol_GoodsLGroup].DefaultValue = defValueInt32;
            // 商品大分類コード名称
            dt.Columns.Add(ctCol_GoodsLGroupName, typeof(string));
            dt.Columns[ctCol_GoodsLGroupName].DefaultValue = defValuestring;
            // 商品中分類コード
            dt.Columns.Add(ctCol_GoodsMGroup, typeof(Int32));
            dt.Columns[ctCol_GoodsMGroup].DefaultValue = defValueInt32;
            // 商品中分類コード名称
            dt.Columns.Add(ctCol_GoodsMGroupName, typeof(string));
            dt.Columns[ctCol_GoodsMGroupName].DefaultValue = defValuestring;
            // BLグループコード
            dt.Columns.Add(ctCol_BLGroupCode, typeof(Int32));
            dt.Columns[ctCol_BLGroupCode].DefaultValue = defValueInt32;
            // BLグループコード名称
            dt.Columns.Add(ctCol_BLGroupName, typeof(string));
            dt.Columns[ctCol_BLGroupName].DefaultValue = defValuestring;
            // 自社分類コード
            dt.Columns.Add(ctCol_EnterpriseGanreCode, typeof(Int32));
            dt.Columns[ctCol_EnterpriseGanreCode].DefaultValue = defValueInt32;
            // 自社分類名称
            dt.Columns.Add(ctCol_EnterpriseGanreName, typeof(string));
            dt.Columns[ctCol_EnterpriseGanreName].DefaultValue = defValuestring;
            // ＢＬ商品コード
            dt.Columns.Add(ctCol_BLGoodsCode, typeof(Int32));
            dt.Columns[ctCol_BLGoodsCode].DefaultValue = defValueInt32;
            // ＢＬ商品コード枝番
            dt.Columns.Add(ctCol_BLGoodsCdDerivedNo, typeof(Int32));
            dt.Columns[ctCol_BLGoodsCdDerivedNo].DefaultValue = defValueInt32;
            // ＢＬ商品名称
            dt.Columns.Add(ctCol_BLGoodsName, typeof(string));
            dt.Columns[ctCol_BLGoodsName].DefaultValue = defValuestring;
            // 仕入先コード
            dt.Columns.Add(ctCol_SupplierCd, typeof(Int32));
            dt.Columns[ctCol_SupplierCd].DefaultValue = defValueInt32;
            // ＪＡＮコード
            dt.Columns.Add(ctCol_Jan, typeof(string));
            dt.Columns[ctCol_Jan].DefaultValue = defValuestring;
            // 仕入単価
            dt.Columns.Add(ctCol_StockUnitPriceFl, typeof(Double));
            dt.Columns[ctCol_StockUnitPriceFl].DefaultValue = defValueDouble;
            // 変更前仕入単価
            dt.Columns.Add(ctCol_BfStockUnitPriceFl, typeof(Double));
            dt.Columns[ctCol_BfStockUnitPriceFl].DefaultValue = defValueDouble;
            // 仕入単価変更フラグ
            dt.Columns.Add(ctCol_StkUnitPriceChgFlg, typeof(Int32));
            dt.Columns[ctCol_StkUnitPriceChgFlg].DefaultValue = defValueInt32;
            // 在庫区分
            dt.Columns.Add(ctCol_StockDiv, typeof(Int32));
            dt.Columns[ctCol_StockDiv].DefaultValue = defValueInt32;
            // 最終仕入年月日
            dt.Columns.Add(ctCol_LastStockDate, typeof(Int32));
            dt.Columns[ctCol_LastStockDate].DefaultValue = defValueInt32;
            // 在庫総数
            dt.Columns.Add(ctCol_StockTotal, typeof(Double));
            dt.Columns[ctCol_StockTotal].DefaultValue = defValueDouble;
            // 出荷先得意先コード
            dt.Columns.Add(ctCol_ShipCustomerCode, typeof(Int32));
            dt.Columns[ctCol_ShipCustomerCode].DefaultValue = defValueInt32;
            // 出荷先得意先名称
            dt.Columns.Add(ctCol_ShipCustomerName, typeof(string));
            dt.Columns[ctCol_ShipCustomerName].DefaultValue = defValuestring;
            // 出荷得意先名称2
            dt.Columns.Add(ctCol_ShipCustomerName2, typeof(string));
            dt.Columns[ctCol_ShipCustomerName2].DefaultValue = defValuestring;
            // 棚卸在庫数
            dt.Columns.Add(ctCol_InventoryStockCnt, typeof(Double));
            dt.Columns[ctCol_InventoryStockCnt].DefaultValue = defValueDouble;
            // 棚卸過不足数
            dt.Columns.Add(ctCol_InventoryTolerancCnt, typeof(Double));
            dt.Columns[ctCol_InventoryTolerancCnt].DefaultValue = defValueDouble;
            // 棚卸準備処理日付
            dt.Columns.Add(ctCol_InventoryPreprDay, typeof(Int32));
            dt.Columns[ctCol_InventoryPreprDay].DefaultValue = defValueInt32;
            // 棚卸準備処理時間
            dt.Columns.Add(ctCol_InventoryPreprTim, typeof(Int32));
            dt.Columns[ctCol_InventoryPreprTim].DefaultValue = defValueInt32;
            // 棚卸実施日
            dt.Columns.Add(ctCol_InventoryDay, typeof(Int32));
            dt.Columns[ctCol_InventoryDay].DefaultValue = defValueInt32;
            // 最終棚卸更新日
            dt.Columns.Add(ctCol_LastInventoryUpdate, typeof(Int32));
            dt.Columns[ctCol_LastInventoryUpdate].DefaultValue = defValueInt32;
            // 棚卸新規追加区分
            dt.Columns.Add(ctCol_InventoryNewDiv, typeof(Int32));
            dt.Columns[ctCol_InventoryNewDiv].DefaultValue = defValueInt32;
            // マシン在庫額
            dt.Columns.Add(ctCol_StockMashinePrice, typeof(Int64));
            dt.Columns[ctCol_StockMashinePrice].DefaultValue = defValueInt64;
            // 棚卸在庫額
            dt.Columns.Add(ctCol_InventoryStockPrice, typeof(Int64));
            dt.Columns[ctCol_InventoryStockPrice].DefaultValue = defValueInt64;
            // 棚卸過不足金額
            dt.Columns.Add(ctCol_InventoryTlrncPrice, typeof(Int64));
            dt.Columns[ctCol_InventoryTlrncPrice].DefaultValue = defValueInt64;
            // 定価（浮動）
            dt.Columns.Add(ctCol_ListPriceFl, typeof(Double));
            dt.Columns[ctCol_ListPriceFl].DefaultValue = defValueDouble;
            // 棚卸日
            dt.Columns.Add(ctCol_InventoryDate, typeof(Int32));
            dt.Columns[ctCol_InventoryDate].DefaultValue = defValueInt32;
            // 在庫総数（実施日）
            dt.Columns.Add(ctCol_StockTotalExec, typeof(Double));
            dt.Columns[ctCol_StockTotalExec].DefaultValue = defValueDouble;
            // 過不足更新区分
            dt.Columns.Add(ctCol_ToleranceUpdateCd, typeof(Int32));
            dt.Columns[ctCol_ToleranceUpdateCd].DefaultValue = defValueInt32;
            // 算出在庫数
            dt.Columns.Add(ctCol_StockAmount, typeof(Double));
            dt.Columns[ctCol_StockAmount].DefaultValue = defValueDouble;
            // 2008.10.14 30413 犬飼 棚卸関連一覧表カラム情報を全更新 <<<<<<END


            // 在庫区分UI(ソート用)
            dt.Columns.Add(ctCol_UiSotckDiv,typeof(Int32));
            dt.Columns[ctCol_UiSotckDiv].DefaultValue = 0;          

            //// 拠点名称(明細用)
            //dt.Columns.Add(ctCol_SectionName_Detail,typeof(string));
            //dt.Columns[ctCol_SectionName_Detail].DefaultValue = "";
            // 倉庫コード(印刷用)
            dt.Columns.Add(ctCol_WarehouseCode_Print,typeof(string));
            dt.Columns[ctCol_WarehouseCode_Print].DefaultValue = "";
            // 仕入先コード(印刷用)
            dt.Columns.Add(ctCol_SupplierCd_Print, typeof(string));
            dt.Columns[ctCol_SupplierCd_Print].DefaultValue = "";
            // BLコード(印刷用)
            dt.Columns.Add(ctCol_BLGoodsCode_Print, typeof(string));
            dt.Columns[ctCol_BLGoodsCode_Print].DefaultValue = "";
            // グループコード(印刷用)
            dt.Columns.Add(ctCol_BLGroupCode_Print, typeof(string));
            dt.Columns[ctCol_BLGroupCode_Print].DefaultValue = "";
            //メーカーコード(印刷用)
            dt.Columns.Add(ctCol_MakerCode_Print,typeof(string));
            dt.Columns[ctCol_MakerCode_Print].DefaultValue = "";
            // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////キャリアコード(印刷用)
            //dt.Columns.Add(ctCol_CarrierCode_Print,typeof(string));
            //dt.Columns[ctCol_CarrierCode_Print].DefaultValue = "";
            ////事業者コード(印刷用)
            //dt.Columns.Add(ctCol_CarrierEpCode_Print,typeof(string));
            //dt.Columns[ctCol_CarrierEpCode_Print].DefaultValue = "";
            ////系統色コード(印刷用)
            //dt.Columns.Add(ctCol_SystematicColorCd_Print,typeof(string));
            //dt.Columns[ctCol_SystematicColorCd_Print].DefaultValue = "";
            // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
            //商品区分グループコード(印刷用)
            dt.Columns.Add(ctCol_LargeGoodsGanreCode_Print,typeof(string));
            dt.Columns[ctCol_LargeGoodsGanreCode_Print].DefaultValue = "";
            //商品区分コード(印刷用)
            dt.Columns.Add(ctCol_MediumGoodsGanreCode_Print,typeof(string));
            dt.Columns[ctCol_MediumGoodsGanreCode_Print].DefaultValue = "";
            // 棚卸準備処理日付
            dt.Columns.Add(ctCol_InventoryPreprDay_Print,typeof(string));
            dt.Columns[ctCol_InventoryPreprDay_Print].DefaultValue = "";
            // 棚卸実施日
            dt.Columns.Add(ctCol_InventoryDay_Print,typeof(string));
            dt.Columns[ctCol_InventoryDay_Print].DefaultValue = "";
            // 棚卸更新日
            dt.Columns.Add(ctCol_InventoryUpDate_Print,typeof(string));
            dt.Columns[ctCol_InventoryUpDate_Print].DefaultValue = "";
            // 最終仕入年月日
            dt.Columns.Add(ctCol_LastStockDate_Print,typeof(string));
            dt.Columns[ctCol_LastStockDate_Print].DefaultValue = "";
            // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            //// 仕入日
            //dt.Columns.Add(ctCol_StockDate_Print,typeof(string));
            //dt.Columns[ctCol_StockDate_Print].DefaultValue = "";
            //// 入荷日
            //dt.Columns.Add(ctCol_ArrivalGoodsDay_Print,typeof(string));
            //dt.Columns[ctCol_ArrivalGoodsDay_Print].DefaultValue = "";
            // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
            // 在庫区分
　          dt.Columns.Add(ctCol_StockDiv_Print,typeof(string));
            dt.Columns[ctCol_StockDiv_Print].DefaultValue = "";
            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚番（棚番ブレイク用）
            dt.Columns.Add(ctCol_WarehouseShelfNo_Print, typeof(string));
            dt.Columns[ctCol_WarehouseShelfNo_Print].DefaultValue = "";
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            // 棚卸日
            dt.Columns.Add(ctCol_InventoryDate_Print, typeof(string));
            dt.Columns[ctCol_InventoryDate_Print].DefaultValue = "";
            // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<

            // 2008.11.04 30413 犬飼 棚卸差異表の差異小計印字 >>>>>>START
            // プラスの差異数
            dt.Columns.Add(ctCol_PlusInventoryTolerancCnt, typeof(Double));
            dt.Columns[ctCol_PlusInventoryTolerancCnt].DefaultValue = defValueDouble;
            // マイナスの差異数
            dt.Columns.Add(ctCol_MinusInventoryTolerancCnt, typeof(Double));
            dt.Columns[ctCol_MinusInventoryTolerancCnt].DefaultValue = defValueDouble;
            // プラスの差異金額
            dt.Columns.Add(ctCol_PlusInventoryTlrncPrice, typeof(Int64));
            dt.Columns[ctCol_PlusInventoryTlrncPrice].DefaultValue = defValueInt64;
            // マイナスの差異金額
            dt.Columns.Add(ctCol_MinusInventoryTlrncPrice, typeof(Int64));
            dt.Columns[ctCol_MinusInventoryTlrncPrice].DefaultValue = defValueInt64;
            // 2008.11.04 30413 犬飼 棚卸差異表の差異小計印字 <<<<<<END

            // 棚卸数(印字用)
            dt.Columns.Add(ctCol_StockCount_Print, typeof(string));
            dt.Columns[ctCol_StockCount_Print].DefaultValue = defValuestring;
            // 標準価格(価格マスタの定価)(印字用)
            dt.Columns.Add(ctCol_ListPrice_Print, typeof(string));
            dt.Columns[ctCol_ListPrice_Print].DefaultValue = defValuestring;
            // 原単価(仕入単価)(印字用)
            dt.Columns.Add(ctCol_StockUnitPriceFl_Print, typeof(string));
            dt.Columns[ctCol_StockUnitPriceFl_Print].DefaultValue = defValuestring;
            // 算出棚卸金額
            dt.Columns.Add(ctCol_StockAmountPrice_Print, typeof(string));
            dt.Columns[ctCol_StockAmountPrice_Print].DefaultValue = defValuestring;
            // -------ADD 2009/12/07------->>>>>
            // 棚卸数、原単価、帳薄数空白Flag
            dt.Columns.Add(ctCol_BlankShowFlag_Print, typeof(int));
            dt.Columns[ctCol_BlankShowFlag_Print].DefaultValue = defValueInt32;
            // -------ADD 2009/12/07-------<<<<<
            // -------ADD 2010/02/20------->>>>>
            // 棚卸数空白Flag
            dt.Columns.Add(ctCol_InvStockCntFlag_Print, typeof(int));
            dt.Columns[ctCol_InvStockCntFlag_Print].DefaultValue = defValueInt32;
            // -------ADD 2010/02/20-------<<<<<

            // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
            // 棚卸在庫数テキスト用
            dt.Columns.Add(ctCol_InventoryStockCntTextOut, typeof(Double));
            dt.Columns[ctCol_InventoryStockCntTextOut].DefaultValue = defValueDouble;
            // 標準価格テキスト用
            dt.Columns.Add(ctCol_ListPriceTextOut, typeof(Double));
            dt.Columns[ctCol_ListPriceTextOut].DefaultValue = defValueDouble;
            // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

        }

		#endregion
	}
}