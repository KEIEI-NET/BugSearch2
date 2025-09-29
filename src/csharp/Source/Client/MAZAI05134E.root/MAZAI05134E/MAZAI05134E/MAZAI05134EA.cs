//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸入力
// プログラム概要   : 棚卸入力UI抽出結果クラスワークヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2007/04/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/02/14  修正内容 : 棚卸実施日対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/09/01  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/14  修正内容 : 不具合対応[13260]　No項目追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/09/11  修正内容 : 不具合対応[13914]　キーに棚番を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修 正 日  2011/01/30  修正内容 : 障害報告 #18764
//----------------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当 : yangyi
// 修 正 日  2013/03/01     修正内容 : 20130326配信分の対応、Redmine#34175
//                                     棚卸業務のサーバー負荷軽減
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// public class name:   InventInputResult
	/// <summary>
	/// 棚卸数入力UI抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   棚卸数入力UI抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/4/2</br>
	/// <br>Genarated Date   :   2007/04/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008.02.14 980035 金沢 貞義</br>
    /// <br>			         ・棚卸実施日対応（DC.NS対応）</br>
    /// <br>Update Note      :   2008/09/01 30414 忍 幸史</br>
    /// <br>			         ・Partsman用に変更</br>
    /// <br>                 :   2009/05/14 照田 貴志　不具合対応[13260]</br>
    /// <br>UpdateNote       :   2011/01/30 鄧潘ハン </br>
    /// <br>                     障害報告 #18764</br>
    /// </remarks>
	public class InventInputResult
    {
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ■ Public Const
		/// <summary>テーブル名称</summary>
		public const string ct_Tbl_InventInput = "Tbl_InventInput";

		/// <summary>作成日時</summary>
		public const string ct_Col_CreateDateTime = "CreateDateTime";
		/// <summary>更新日時</summary>
		public const string ct_Col_UpdateDateTime = "UpdateDateTime";
		/// <summary>企業コード</summary>
		public const string ct_Col_EnterpriseCode = "EnterpriseCode";
		/// <summary>GUID</summary>
		public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
		/// <summary>更新従業員コード</summary>
		public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
		/// <summary>更新アセンブリID1</summary>
		public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
		/// <summary>更新アセンブリID2</summary>
		public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
		/// <summary>論理削除区分</summary>
		public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
		/// <summary>拠点コード</summary>
		public const string ct_Col_SectionCode = "SectionCode";
		/// <summary>拠点ガイド名称</summary>
		public const string ct_Col_SectionGuideNm = "SectionGuideNm";
		/// <summary>棚卸通番</summary>
		public const string ct_Col_InventorySeqNo = "InventorySeqNo";
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>製番在庫マスタGUID</summary>
		//public const string ct_Col_ProductStockGuid = "ProductStockGuid";
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary>倉庫コード</summary>
		public const string ct_Col_WarehouseCode = "WarehouseCode";
		/// <summary>倉庫名称</summary>
		public const string ct_Col_WarehouseName = "WarehouseName";
		/// <summary>メーカーコード</summary>
		public const string ct_Col_MakerCode = "MakerCode";
		/// <summary>メーカー名称</summary>
		public const string ct_Col_MakerName = "MakerName";
		/// <summary>品番</summary>
        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
        //public const string ct_Col_GoodsCode = "GoodsCode";
        public const string ct_Col_GoodsNo = "GoodsNo";
        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
        /// <summary>品名</summary>
		public const string ct_Col_GoodsName = "GoodsName";
        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>機種コード</summary>
		//public const string ct_Col_CellphoneModelCode = "CellphoneModelCode";
		///// <summary>機種名称</summary>
		//public const string ct_Col_CellphoneModelName = "CellphoneModelName";
        ///// <summary>キャリアコード</summary>
        //public const string ct_Col_CarrierCode = "CarrierCode";
        ///// <summary>キャリア名称</summary>
        //public const string ct_Col_CarrierName = "CarrierName";
        ///// <summary>系統色コード</summary>
        //public const string ct_Col_SystematicColorCd = "SystematicColorCd";
        ///// <summary>系統色名称</summary>
        //public const string ct_Col_SystematicColorNm = "SystematicColorNm";
        /// <summary>倉庫棚番</summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>重複棚番1</summary>
        public const string ct_Col_DuplicationShelfNo1 = "DuplicationShelfNo1";
        /// <summary>重複棚番2</summary>
        public const string ct_Col_DuplicationShelfNo2 = "DuplicationShelfNo2";
        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
        /// <summary>商品大分類コード</summary>
		public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode";
		/// <summary>商品大分類名称</summary>
		public const string ct_Col_LargeGoodsGanreName = "LargeGoodsGanreName";
		/// <summary>商品中分類コード</summary>
		public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode";
		/// <summary>商品中分類名称</summary>
		public const string ct_Col_MediumGoodsGanreName = "MediumGoodsGanreName";
        // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>事業者コード</summary>
		//public const string ct_Col_CarrierEpCode = "CarrierEpCode";
		///// <summary>事業者名称</summary>
		//public const string ct_Col_CarrierEpName = "CarrierEpName";
        /// <summary>グループコード</summary>
        public const string ct_Col_DetailGoodsGanreCode = "DetailGoodsGanreCode";
        /// <summary>グループコード名称</summary>
        public const string ct_Col_DetailGoodsGanreName = "DetailGoodsGanreName";
        /// <summary>自社分類コード</summary>
        public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary>自社分類名称</summary>
        public const string ct_Col_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary>ＢＬ品番</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>ＢＬ品名</summary>
        public const string ct_Col_BLGoodsName = "BLGoodsName";
        // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
        /// <summary>得意先コード</summary>
		public const string ct_Col_CustomerCode = "CustomerCode";
		/// <summary>得意先名称</summary>
		public const string ct_Col_CustomerName = "CustomerName";
		/// <summary>得意先名称2</summary>
		public const string ct_Col_CustomerName2 = "CustomerName2";
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>仕入日</summary>
        //public const string ct_Col_StockDate = "StockDate";
        ///// <summary>入荷日</summary>
        //public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";
        ///// <summary>製造番号</summary>
        //public const string ct_Col_ProductNumber = "ProductNumber";
        ///// <summary>商品電話番号1</summary>
        //public const string ct_Col_StockTelNo1 = "StockTelNo1";
        ///// <summary>変更前商品電話番号1</summary>
        //public const string ct_Col_BfStockTelNo1 = "BfStockTelNo1";
        ///// <summary>商品電話番号1変更フラグ</summary>
        //public const string ct_Col_StkTelNo1ChgFlg = "StkTelNo1ChgFlg";
        ///// <summary>商品電話番号2</summary>
        //public const string ct_Col_StockTelNo2 = "StockTelNo2";
		///// <summary>変更前商品電話番号2</summary>
		//public const string ct_Col_BfStockTelNo2 = "BfStockTelNo2";
		///// <summary>商品電話番号2変更フラグ</summary>
		//public const string ct_Col_StkTelNo2ChgFlg = "StkTelNo2ChgFlg";
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary>JANコード</summary>
		public const string ct_Col_Jan = "Jan";
		/// <summary>仕入単価</summary>
		public const string ct_Col_StockUnitPrice = "StockUnitPrice";
		/// <summary>変更前仕入単価</summary>
		public const string ct_Col_BfStockUnitPrice = "BfStockUnitPrice";
		/// <summary>仕入単価変更フラグ</summary>
		public const string ct_Col_StkUnitPriceChgFlg = "StkUnitPriceChgFlg";
		/// <summary>在庫区分</summary>
		public const string ct_Col_StockDiv = "StockDiv";
        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>在庫状態</summary>
		//public const string ct_Col_StockState = "StockState";
		///// <summary>移動状態</summary>
		//public const string ct_Col_MoveStatus = "MoveStatus";
		///// <summary>商品状態</summary>
		//public const string ct_Col_GoodsCodeStatus = "GoodsCodeStatus";
		///// <summary>製番管理区分</summary>
		//public const string ct_Col_PrdNumMngDiv = "PrdNumMngDiv";
        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        /// <summary>最終仕入年月日</summary>
		public const string ct_Col_LastStockDate = "LastStockDate";
		/// <summary>帳簿在庫数</summary>
		public const string ct_Col_StockTotal = "StockTotal";
		/// <summary>出荷先得意先コード</summary>
		public const string ct_Col_ShipCustomerCode = "ShipCustomerCode";
		/// <summary>出荷先得意先名称</summary>
		public const string ct_Col_ShipCustomerName = "ShipCustomerName";
		/// <summary>出荷先得意先名称2</summary>
		public const string ct_Col_ShipCustomerName2 = "ShipCustomerName2";
		/// <summary>棚卸在庫数</summary>
		public const string ct_Col_InventoryStockCnt = "InventoryStockCnt";
		/// <summary>差異数</summary>
		public const string ct_Col_InventoryTolerancCnt = "InventoryTolerancCnt";
		/// <summary>変更前差異数</summary>
		public const string ct_Col_BfChgInventoryToleCnt = "BfChgInventoryToleCnt";
        // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>棚卸日(int)</summary>
        public const string ct_Col_InventoryExeDay = "InventoryExeDay";
        /// <summary>棚卸日(DateTime)</summary>
        public const string ct_Col_InventoryExeDay_Datetime = "InventoryExeDay_Datetime";
        /// <summary>棚卸日(String)</summary>
        public const string ct_Col_InventoryExeDay_Str = "InventoryExeDay_Str";
        // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
		/// <summary>棚卸準備処理日付(int)</summary>
		public const string ct_Col_InventoryPreprDay = "InventoryPreprDay";
		/// <summary>棚卸準備処理日付(Datetime)</summary>
		public const string ct_Col_InventoryPreprDay_Datetime = "InventoryPreprDay_Datetime";
		/// <summary>棚卸準備処理日付(年 入力)</summary>
		public const string ct_Col_InventoryPreprDay_Year = "InventoryPreprDay_Year";
		/// <summary>棚卸準備処理日付(年 ラベル)</summary>
		public const string ct_Col_InventoryPreprDay_YearL = "InventoryPreprDay_YearL";
		/// <summary>棚卸準備処理日付(月 入力)</summary>
		public const string ct_Col_InventoryPreprDay_Month = "InventoryPreprDay_Month";
		/// <summary>棚卸準備処理日付(月 ラベル)</summary>
		public const string ct_Col_InventoryPreprDay_MonthL = "InventoryPreprDay_MonthL";
		/// <summary>棚卸準備処理日付(日 入力)</summary>
		public const string ct_Col_InventoryPreprDay_Day = "InventoryPreprDay_Day";
		/// <summary>棚卸準備処理日付(日 ラベル)</summary>
		public const string ct_Col_InventoryPreprDay_DayL = "InventoryPreprDay_DayL";
		/// <summary>棚卸準備処理時間</summary>
		public const string ct_Col_InventoryPreprTim = "InventoryPreprTim";
		/// <summary>棚卸実施日(int)</summary>
		public const string ct_Col_InventoryDay = "InventoryDay";
		/// <summary>棚卸実施日(Datetime)</summary>
		public const string ct_Col_InventoryDay_Datetime = "InventoryDay_Datetime";
		/// <summary>棚卸実施日(年 入力)</summary>
		public const string ct_Col_InventoryDay_Year = "InventoryDay_Year";
		/// <summary>棚卸実施日(年 ラベル)</summary>
		public const string ct_Col_InventoryDay_YearL = "InventoryDay_YearL";
		/// <summary>棚卸実施日(月 入力)</summary>
		public const string ct_Col_InventoryDay_Month = "InventoryDay_Month";
		/// <summary>棚卸実施日(月 ラベル)</summary>
		public const string ct_Col_InventoryDay_MonthL = "InventoryDay_MonthL";
		/// <summary>棚卸実施日(日 入力)</summary>
		public const string ct_Col_InventoryDay_Day = "InventoryDay_Day";
		/// <summary>棚卸実施日(日 ラベル)</summary>
		public const string ct_Col_InventoryDay_DayL = "InventoryDay_DayL";
		/// <summary>最終棚卸更新日</summary>
		public const string ct_Col_LastInventoryUpdate = "LastInventoryUpdate";
		/// <summary>棚卸新規追加区分</summary>
		public const string ct_Col_InventoryNewDiv = "InventoryNewDiv";
		/// <summary>棚卸新規追加区分名称</summary>
		public const string ct_Col_InventoryNewDivName = "InventoryNewDivName";
        // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>マシン在庫額</summary>
        public const string ct_Col_StockMashinePrice = "StockMashinePrice";
        /// <summary>棚卸在庫額</summary>
        public const string ct_Col_InventoryStockPrice = "InventoryStockPrice";
        /// <summary>棚卸過不足金額</summary>
        public const string ct_Col_InventoryTlrncPrice = "InventoryTlrncPrice";
        // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

		/// <summary>在庫委託受託区分</summary>
		public const string ct_Col_StockTrtEntDiv = "StockTrtEntDiv";
		/// <summary>在庫委託受託区分名称</summary>
		public const string ct_Col_StockTrtEntDivName = "StockTrtEntDivName";
		/// <summary>集計区分</summary>
		public const string ct_Col_GrossDiv = "GrossDiv";
		/// <summary>表示区分</summary>
		public const string ct_Col_ViewDiv = "ViewDiv";
		/// <summary>更新対象区分</summary>
		public const string ct_Col_UpdateDiv = "UpdateDiv";
		/// <summary>ボタン用カラム</summary>
		public const string ct_Col_Button = "Button";
		/// <summary>自行</summary>
		public const string ct_Col_RowSelf = "RowSelf";
		/// <summary>key</summary>
		public const string ct_Col_key = "key";
		/// <summary>移動在庫数</summary>
		public const string ct_Col_MoveStockCount = "MoveStockCount";
		/// <summary>Status</summary>
		public const string ct_Col_Status = "Status";
		/// <summary>Status内容</summary>
		public const string ct_Col_StatusDetail = "StatusDetail";
		/// <summary>変更区分(0:更新対象, 1~:更新対象外)</summary>
		public const string ct_Col_ChangeDiv = "ChangeDiv";

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        ///// <summary>Status内容</summary>
        //public const string ct_Col_StatusDetail = "StatusDetail";
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

		// 2007.07.31 kubo add
		/// <summary>ソート用製造番号</summary>
		public const string ct_Col_SortProductNumber = "SortProductNumber";

		#endregion ■ Public Const
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #region ■ Public Const
        /// <summary>テーブル名称</summary>
        public const string ct_Tbl_InventInput = "Tbl_InventInput";

        /// <summary>作成日時</summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary>更新日時</summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary>企業コード</summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
        /// <summary>更新従業員コード</summary>
        public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary>更新アセンブリID1</summary>
        public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary>更新アセンブリID2</summary>
        public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary>論理削除区分</summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary>拠点コード</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>棚卸通番</summary>
        public const string ct_Col_InventorySeqNo = "InventorySeqNo";
        /// <summary>倉庫コード</summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary>倉庫名称</summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary>メーカーコード</summary>
        public const string ct_Col_MakerCode = "MakerCode";
        /// <summary>メーカー名称</summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary>品番</summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary>品名</summary>
        public const string ct_Col_GoodsName = "GoodsName";
        //---ADD 2011/01/30-------------------------------->>>>>
        /// <summary>定価</summary>
        public const string ct_Col_ListPrice = "ListPrice";
        //---ADD 2011/01/30--------------------------------<<<<<
        /// <summary>倉庫棚番</summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>重複棚番1</summary>
        public const string ct_Col_DuplicationShelfNo1 = "DuplicationShelfNo1";
        /// <summary>重複棚番2</summary>
        public const string ct_Col_DuplicationShelfNo2 = "DuplicationShelfNo2";
        /// <summary>商品大分類コード</summary>
        public const string ct_Col_LargeGoodsGanreCode = "LargeGoodsGanreCode";
        /// <summary>商品中分類コード</summary>
        public const string ct_Col_MediumGoodsGanreCode = "MediumGoodsGanreCode";
        /// <summary>グループコード</summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary>グループコード名称</summary>
        public const string ct_Col_BLGroupName = "BLGroupName";
        /// <summary>自社分類コード</summary>
        public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary>ＢＬ品番</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary>ＢＬ品名</summary>
        public const string ct_Col_BLGoodsName = "BLGoodsName";
        /// <summary>仕入先コード</summary>
        public const string ct_Col_SupplierCode = "SupplierCode";
        /// <summary>仕入先名称</summary>
        public const string ct_Col_SupplierName = "SupplierName";
        /// <summary>仕入先名称2</summary>
        public const string ct_Col_SupplierName2 = "SupplierName2";
        /// <summary>JANコード</summary>
        public const string ct_Col_Jan = "Jan";
        /// <summary>仕入単価</summary>
        public const string ct_Col_StockUnitPrice = "StockUnitPrice";
        /// <summary>変更前仕入単価</summary>
        public const string ct_Col_BfStockUnitPrice = "BfStockUnitPrice";
        /// <summary>仕入単価変更フラグ</summary>
        public const string ct_Col_StkUnitPriceChgFlg = "StkUnitPriceChgFlg";
        /// <summary>在庫区分</summary>
        public const string ct_Col_StockDiv = "StockDiv";
        /// <summary>最終仕入年月日</summary>
        public const string ct_Col_LastStockDate = "LastStockDate";
        /// <summary>帳簿在庫数</summary>
        public const string ct_Col_StockTotal = "StockTotal";
        /// <summary>出荷先得意先コード</summary>
        public const string ct_Col_ShipCustomerCode = "ShipCustomerCode";
        /// <summary>棚卸在庫数</summary>
        public const string ct_Col_InventoryStockCnt = "InventoryStockCnt";
        /// <summary>差異数</summary>
        public const string ct_Col_InventoryTolerancCnt = "InventoryTolerancCnt";
        /// <summary>変更前差異数</summary>
        public const string ct_Col_BfChgInventoryToleCnt = "BfChgInventoryToleCnt";
        /// <summary>棚卸日(DateTime)</summary>
        public const string ct_Col_InventoryExeDay_Datetime = "InventoryExeDay_Datetime";
        /// <summary>棚卸準備処理日付(Datetime)</summary>
        public const string ct_Col_InventoryPreprDay_Datetime = "InventoryPreprDay_Datetime";
        /// <summary>棚卸準備処理時間</summary>
        public const string ct_Col_InventoryPreprTim = "InventoryPreprTim";
        /// <summary>棚卸実施日(int)</summary>
        public const string ct_Col_InventoryDay = "InventoryDay";
        /// <summary>棚卸実施日(Datetime)</summary>
        public const string ct_Col_InventoryDay_Datetime = "InventoryDay_Datetime";
        /// <summary>棚卸実施日(年 入力)</summary>
        public const string ct_Col_InventoryDay_Year = "InventoryDay_Year";
        /// <summary>棚卸実施日(年 ラベル)</summary>
        public const string ct_Col_InventoryDay_YearL = "InventoryDay_YearL";
        /// <summary>棚卸実施日(月 入力)</summary>
        public const string ct_Col_InventoryDay_Month = "InventoryDay_Month";
        /// <summary>棚卸実施日(月 ラベル)</summary>
        public const string ct_Col_InventoryDay_MonthL = "InventoryDay_MonthL";
        /// <summary>棚卸実施日(日 入力)</summary>
        public const string ct_Col_InventoryDay_Day = "InventoryDay_Day";
        /// <summary>棚卸実施日(日 ラベル)</summary>
        public const string ct_Col_InventoryDay_DayL = "InventoryDay_DayL";
        /// <summary>最終棚卸更新日</summary>
        public const string ct_Col_LastInventoryUpdate = "LastInventoryUpdate";
        /// <summary>棚卸新規追加区分</summary>
        public const string ct_Col_InventoryNewDiv = "InventoryNewDiv";
        /// <summary>棚卸新規追加区分名称</summary>
        public const string ct_Col_InventoryNewDivName = "InventoryNewDivName";
        /// <summary>マシン在庫額</summary>
        public const string ct_Col_StockMashinePrice = "StockMashinePrice";
        /// <summary>棚卸在庫額</summary>
        public const string ct_Col_InventoryStockPrice = "InventoryStockPrice";
        /// <summary>棚卸過不足金額</summary>
        public const string ct_Col_InventoryTlrncPrice = "InventoryTlrncPrice";
        /// <summary>在庫委託受託区分</summary>
        public const string ct_Col_StockTrtEntDiv = "StockTrtEntDiv";
        /// <summary>在庫委託受託区分名称</summary>
        public const string ct_Col_StockTrtEntDivName = "StockTrtEntDivName";
        /// <summary>集計区分</summary>
        public const string ct_Col_GrossDiv = "GrossDiv";
        /// <summary>表示区分</summary>
        public const string ct_Col_ViewDiv = "ViewDiv";
        /// <summary>更新対象区分</summary>
        public const string ct_Col_UpdateDiv = "UpdateDiv";
        /// <summary>ボタン用カラム</summary>
        public const string ct_Col_Button = "Button";
        /// <summary>自行</summary>
        public const string ct_Col_RowSelf = "RowSelf";
        /// <summary>key</summary>
        public const string ct_Col_key = "key";
        /// <summary>移動在庫数</summary>
        public const string ct_Col_MoveStockCount = "MoveStockCount";
        /// <summary>Status</summary>
        public const string ct_Col_Status = "Status";
        /// <summary>Status内容</summary>
        public const string ct_Col_StatusDetail = "StatusDetail";
        /// <summary>変更区分(0:更新対象, 1~:更新対象外)</summary>
        public const string ct_Col_ChangeDiv = "ChangeDiv";
        /// <summary>ソート用製造番号</summary>
        public const string ct_Col_SortProductNumber = "SortProductNumber";
        /// <summary>削除フラグ</summary>
        public const string ct_Col_DeleteDiv = "DeleteDiv";

        // ---ADD 2009/05/14 不具合対応[13260] ------------>>>>>
        /// <summary>No</summary>
        public const string ct_Col_No = "No";
        /// <summary>在庫総数(実施日)</summary>
        public const string ct_Col_StockTotalExec = "StockTotalExec";
        /// <summary>過不足更新区分</summary>
        public const string ct_Col_ToleranceUpdateCd = "ToleranceUpdateCd";
        /// <summary>調整用計算原価</summary>
        public const string ct_Col_AdjustCalcCost = "AdjustCalcCost";
        /// <summary>棚卸過不足数(DBの値そのまま)</summary>
        public const string ct_Col_InventoryTolerancCntBf = "InventoryTolerancCntBf";
        // ---ADD 2009/05/14 不具合対応[13260] ------------<<<<<

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 棚卸数入力UI抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>InventInputResultクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   InventInputResultクラスの新しいインスタンスを生成します</br>
		/// <br>Programer       :   自動生成</br>
		/// </remarks>
		public InventInputResult()
		{
		}
		#endregion

		#region ■ Public Method
		#region ◆ テーブルスキーマ定義メソッド
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// テーブルスキーマ定義メソッド
		/// </summary>
		/// <param name="dt">DataTable</param>
        /// <br>UpdateNote       :   2011/01/30 鄧潘ハン </br>
        /// <br>                     障害報告 #18764</br>
        /// <br>Update Note: 2013/03/01 yangyi</br>
        /// <br>管理番号   : 10801804-00 2013/03/06配信分の緊急対応</br>
        /// <br>           : Redmine#34175 　棚卸業務のサーバー負荷軽減対策</br>
        static public void CreateDataTable( ref DataTable dt )
		{

			// テーブルインスタンスのチェック
			if ( dt != null )
			{
				// テーブルクリア
				dt.Clear();
                dt.PrimaryKey = null;  //ADD yangyi 2013/03/01 Redmine#34175
			}
			else
			{
				dt = new DataTable( ct_Tbl_InventInput );	// テーブルインスタンス作成
				// ﾃｰﾌﾞﾙｽｷｰﾏ定義
				// 作成日時
				dt.Columns.Add( CreateColumn( ct_Col_CreateDateTime, typeof(DateTime), "作成日時" ) );
				dt.Columns[ct_Col_CreateDateTime].DefaultValue = DateTime.MinValue;
				// 更新日時
				dt.Columns.Add( CreateColumn( ct_Col_UpdateDateTime, typeof(DateTime), "更新日時" ) );
				dt.Columns[ct_Col_UpdateDateTime].DefaultValue = DateTime.MinValue;
				// 企業コード
				dt.Columns.Add( CreateColumn( ct_Col_EnterpriseCode, typeof(string), "企業コード" ) );
				dt.Columns[ct_Col_EnterpriseCode].DefaultValue = "";
				// GUID
				dt.Columns.Add( CreateColumn( ct_Col_FileHeaderGuid, typeof(Guid), "GUID" ) );
				dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
				// 更新従業員コード
				dt.Columns.Add( CreateColumn( ct_Col_UpdEmployeeCode, typeof(string), "更新従業員コード" ) );
				dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = "";
				// 更新アセンブリID1
				dt.Columns.Add( CreateColumn( ct_Col_UpdAssemblyId1, typeof(string), "更新アセンブリID1" ) );
				dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = "";
				// 更新アセンブリID2
				dt.Columns.Add( CreateColumn( ct_Col_UpdAssemblyId2, typeof(string), "更新アセンブリID2" ) );
				dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = "";
				// 論理削除区分
				dt.Columns.Add( CreateColumn( ct_Col_LogicalDeleteCode, typeof(Int32), "論理削除区分" ) );
				dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = 0;
				// 棚卸通番
				dt.Columns.Add( CreateColumn( ct_Col_InventorySeqNo, typeof(Int32), "通番" ) );
				dt.Columns[ct_Col_InventorySeqNo].DefaultValue = 0;
				// 倉庫名称
				dt.Columns.Add( CreateColumn( ct_Col_WarehouseName, typeof(string), "倉庫名" ) );
				dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
				// メーカー名称
				dt.Columns.Add( CreateColumn( ct_Col_MakerName, typeof(string), "メーカー名" ) );
				dt.Columns[ct_Col_MakerName].DefaultValue = "";
				// 品名
				dt.Columns.Add( CreateColumn( ct_Col_GoodsName, typeof(string), "品名" ) );
                //---ADD 2011/01/30-------------------------------->>>>>
                // 定価
                dt.Columns.Add(CreateColumn(ct_Col_ListPrice, typeof(Double), "定価"));
                dt.Columns[ct_Col_ListPrice].DefaultValue = 0;
				dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                //---ADD 2011/01/30--------------------------------<<<<<
                // -- DEL 2009/09/11 --------------------------------->>>
                // Primary作成時に移動
                //// 倉庫棚番
                //dt.Columns.Add( CreateColumn( ct_Col_WarehouseShelfNo, typeof(string), "棚番" ) );
                //dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";
                // -- DEL 2009/09/11 ---------------------------------<<<
                // 重複棚番1
				dt.Columns.Add( CreateColumn( ct_Col_DuplicationShelfNo1, typeof(string), "重複棚番１" ) );
				dt.Columns[ct_Col_DuplicationShelfNo1].DefaultValue = "";
                // 重複棚番2
				dt.Columns.Add( CreateColumn( ct_Col_DuplicationShelfNo2, typeof(string), "重複棚番２" ) );
				dt.Columns[ct_Col_DuplicationShelfNo2].DefaultValue = "";
                // 商品大分類コード
                dt.Columns.Add(CreateColumn(ct_Col_LargeGoodsGanreCode, typeof(Int32), "商品大分類コード"));
				dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = 0;
				// 商品中分類コード
                dt.Columns.Add(CreateColumn(ct_Col_MediumGoodsGanreCode, typeof(Int32), "商品中分類コード"));
				dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = 0;
                // グループコード
                dt.Columns.Add(CreateColumn(ct_Col_BLGroupCode, typeof(Int32), "ｸﾞﾙｰﾌﾟｺｰﾄﾞ"));
                dt.Columns[ct_Col_BLGroupCode].DefaultValue = 0;
                // グループコード名称
				dt.Columns.Add( CreateColumn( ct_Col_BLGroupName, typeof(string), "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名" ) );
                dt.Columns[ct_Col_BLGroupName].DefaultValue = "";
                // 自社分類コード
				dt.Columns.Add( CreateColumn( ct_Col_EnterpriseGanreCode, typeof(Int32), "自社分類コード" ) );
				dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = 0;
                // ＢＬ品番
				dt.Columns.Add( CreateColumn( ct_Col_BLGoodsCode, typeof(Int32), "BLｺｰﾄﾞ" ) );
				dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                // ＢＬ品名
				dt.Columns.Add( CreateColumn( ct_Col_BLGoodsName, typeof(string), "BLｺｰﾄﾞ名" ) );
				dt.Columns[ct_Col_BLGoodsName].DefaultValue = "";
				// 得意先名称
                dt.Columns.Add(CreateColumn(ct_Col_SupplierName, typeof(string), "仕入先名"));
                dt.Columns[ct_Col_SupplierName].DefaultValue = "";
				// 得意先名称2
                dt.Columns.Add(CreateColumn(ct_Col_SupplierName2, typeof(string), "仕入先名2"));
                dt.Columns[ct_Col_SupplierName2].DefaultValue = "";
                // JANコード
				dt.Columns.Add( CreateColumn( ct_Col_Jan, typeof(string), "JANコード" ) );
				dt.Columns[ct_Col_Jan].DefaultValue = "";
                // 変更前仕入単価
                dt.Columns.Add(CreateColumn(ct_Col_BfStockUnitPrice, typeof(Double), "変更前原単価"));
                dt.Columns[ct_Col_BfStockUnitPrice].DefaultValue = 0;
                // 仕入単価変更フラグ
				dt.Columns.Add( CreateColumn( ct_Col_StkUnitPriceChgFlg, typeof(Int32), "原単価変更フラグ" ) );
				dt.Columns[ct_Col_StkUnitPriceChgFlg].DefaultValue = 0;
                // 最終仕入年月日
				dt.Columns.Add( CreateColumn( ct_Col_LastStockDate, typeof(DateTime), "最終仕入年月日" ) );
				dt.Columns[ct_Col_LastStockDate].DefaultValue = DateTime.MinValue;
				// 帳簿在庫数
				dt.Columns.Add( CreateColumn( ct_Col_StockTotal, typeof(Double), "帳簿数" ) );
				dt.Columns[ct_Col_StockTotal].DefaultValue = 0;
				// 棚卸在庫数
				dt.Columns.Add( CreateColumn( ct_Col_InventoryStockCnt, typeof(Double), "棚卸数" ) );
				dt.Columns[ct_Col_InventoryStockCnt].DefaultValue = 0;
				// 差異数
				dt.Columns.Add( CreateColumn( ct_Col_InventoryTolerancCnt, typeof(Double), "過不足数" ) );
				dt.Columns[ct_Col_InventoryTolerancCnt].DefaultValue = 0;
				// 変更前差異数
                dt.Columns.Add(CreateColumn(ct_Col_BfChgInventoryToleCnt, typeof(Double), "変更前過不足数"));
				dt.Columns[ct_Col_BfChgInventoryToleCnt].DefaultValue = 0;
                // 棚卸日(DateTime)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryExeDay_Datetime, typeof(DateTime), "棚卸日"));
                dt.Columns[ct_Col_InventoryExeDay_Datetime].DefaultValue = DateTime.MinValue;
				// 棚卸準備処理日付(DateTime)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryPreprDay_Datetime, typeof(DateTime), "棚卸準備処理日付" ) );
				dt.Columns[ct_Col_InventoryPreprDay_Datetime].DefaultValue = DateTime.MinValue;
				// 棚卸実施日(int)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay, typeof(Int32), "棚卸実施日"));
                dt.Columns[ct_Col_InventoryDay].DefaultValue = 0;
				// 棚卸実施日(DateTime)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Datetime, typeof(DateTime), "棚卸実施日"));
                dt.Columns[ct_Col_InventoryDay_Datetime].DefaultValue = DateTime.MinValue;
				// 棚卸実施日(年 入力)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_Year, typeof(Int32), "年" ) );
				dt.Columns[ct_Col_InventoryDay_Year].DefaultValue = 0;
				// 棚卸実施日(年 ラベル)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_YearL, typeof(string), "" ) );
				dt.Columns[ct_Col_InventoryDay_YearL].DefaultValue = "年";
				// 棚卸実施日(月 入力)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_Month, typeof(Int32), "月" ) );
				dt.Columns[ct_Col_InventoryDay_Month].DefaultValue = 0;
				// 棚卸実施日(月 ラベル)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_MonthL, typeof(string), "" ) );
				dt.Columns[ct_Col_InventoryDay_MonthL].DefaultValue = "月";
				// 棚卸実施日(日 入力)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_Day, typeof(Int32), "日" ) );
				dt.Columns[ct_Col_InventoryDay_Day].DefaultValue = 0;
				// 棚卸実施日(日 ラベル)
				dt.Columns.Add( CreateColumn( ct_Col_InventoryDay_DayL, typeof(string), "" ) );
				dt.Columns[ct_Col_InventoryDay_DayL].DefaultValue = "日";
				// 棚卸準備処理時間
				dt.Columns.Add( CreateColumn( ct_Col_InventoryPreprTim, typeof(Int32), "棚卸準備処理時間" ) );
				dt.Columns[ct_Col_InventoryPreprTim].DefaultValue = 0;
				// 棚卸更新日
				dt.Columns.Add( CreateColumn( ct_Col_LastInventoryUpdate, typeof(DateTime), "棚卸更新日" ) );
				dt.Columns[ct_Col_LastInventoryUpdate].DefaultValue = DateTime.MinValue;
                // 棚卸新規追加区分
				dt.Columns.Add( CreateColumn( ct_Col_InventoryNewDiv, typeof(Int32), "区分" ) );
				dt.Columns[ct_Col_InventoryNewDiv].DefaultValue = 0;
				// 棚卸新規追加区分名称
				dt.Columns.Add( CreateColumn( ct_Col_InventoryNewDivName, typeof(string), "新規区分" ) );
				dt.Columns[ct_Col_InventoryNewDivName].DefaultValue = "";
                // 在庫額
				dt.Columns.Add( CreateColumn( ct_Col_StockMashinePrice, typeof(Int64), "在庫額" ) );
				dt.Columns[ct_Col_StockMashinePrice].DefaultValue = 0;
                // 棚卸在庫額
				dt.Columns.Add( CreateColumn( ct_Col_InventoryStockPrice, typeof(Int64), "棚卸在庫額" ) );
				dt.Columns[ct_Col_InventoryStockPrice].DefaultValue = 0;
                // 棚卸過不足金額
				dt.Columns.Add( CreateColumn( ct_Col_InventoryTlrncPrice, typeof(Int64), "棚卸過不足金額" ) );
				dt.Columns[ct_Col_InventoryTlrncPrice].DefaultValue = 0;
                // 在庫委託受託区分
				dt.Columns.Add( CreateColumn( ct_Col_StockTrtEntDiv, typeof(Int32), "在庫委託受託区分" ) );
				dt.Columns[ct_Col_StockTrtEntDiv].DefaultValue = 0;
				// 在庫委託受託区分名称
				dt.Columns.Add( CreateColumn( ct_Col_StockTrtEntDivName, typeof(string), "在庫区分" ) );
				dt.Columns[ct_Col_StockTrtEntDivName].DefaultValue = "";
				// 表示区分
				dt.Columns.Add( CreateColumn( ct_Col_ViewDiv, typeof(Int32), "表示区分" ) );
				dt.Columns[ct_Col_ViewDiv].DefaultValue = 0;
				// ボタン用カラム
				dt.Columns.Add( CreateColumn( ct_Col_Button, typeof(char), "" ) );
				// 自行
				dt.Columns.Add( CreateColumn( ct_Col_RowSelf, typeof(object), "" ) );
				dt.Columns[ct_Col_RowSelf].DefaultValue = null;			
				// ステータス
				dt.Columns.Add( CreateColumn( ct_Col_Status, typeof(Int32), "ステータス" ) );
				dt.Columns[ct_Col_Status].DefaultValue = 0;
				// ステータス内容
				dt.Columns.Add( CreateColumn( ct_Col_StatusDetail, typeof(string), "ステータス" ) );
				dt.Columns[ct_Col_StatusDetail].DefaultValue = "";
				// 変更区分
				dt.Columns.Add( CreateColumn( ct_Col_ChangeDiv, typeof(Int32), "変更区分" ) );
				dt.Columns[ct_Col_ChangeDiv].DefaultValue = 0;
				// 更新対象区分
				dt.Columns.Add( CreateColumn( ct_Col_UpdateDiv, typeof(Int32), "更新対象" ) );
				dt.Columns[ct_Col_UpdateDiv].DefaultValue = 0;
				// 移動在庫数
				dt.Columns.Add( CreateColumn( ct_Col_MoveStockCount, typeof(Int32), "移動在庫数" ) );
				dt.Columns[ct_Col_MoveStockCount].DefaultValue = 0;
				// Key(バーコード読込に使用
				dt.Columns.Add( CreateColumn( ct_Col_key, typeof(Guid), "Key" ) );
				dt.Columns[ct_Col_key].DefaultValue = Guid.Empty;
				// ソート用製造番号
				dt.Columns.Add( CreateColumn( ct_Col_SortProductNumber, typeof(string), "" ) );
				dt.Columns[ct_Col_SortProductNumber].DefaultValue = "";
                // 削除フラグ
                dt.Columns.Add(CreateColumn(ct_Col_DeleteDiv, typeof(Int32), ""));
                dt.Columns[ct_Col_DeleteDiv].DefaultValue = 0;

                // ---ADD 2009/05/14 不具合対応[13260] ---------------------->>>>>
                // No
                dt.Columns.Add(CreateColumn(ct_Col_No, typeof(Int32), "No"));
                dt.Columns[ct_Col_No].DefaultValue = 0;
                //在庫総数(実施日)
                dt.Columns.Add(CreateColumn(ct_Col_StockTotalExec, typeof(Double), "在庫総数(実施日)"));
                dt.Columns[ct_Col_StockTotalExec].DefaultValue = 0;
                //過不足更新区分
                dt.Columns.Add(CreateColumn(ct_Col_ToleranceUpdateCd, typeof(Int32), "過不足更新区分"));
                dt.Columns[ct_Col_ToleranceUpdateCd].DefaultValue = 0;
                //調整用計算原価
                dt.Columns.Add(CreateColumn(ct_Col_AdjustCalcCost, typeof(Double), "調整用計算原価"));
                dt.Columns[ct_Col_AdjustCalcCost].DefaultValue = 0;
                //棚卸過不足数(DBの値そのまま)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryTolerancCntBf, typeof(Double), "棚卸過不足数(DBの値そのまま)"));
                dt.Columns[ct_Col_InventoryTolerancCntBf].DefaultValue = 0;
                // ---ADD 2009/05/14 不具合対応[13260] ----------------------<<<<<

                //  -- UPD 2009/09/11 ---------------------->>>
                //DataColumn[] primaryKeys = new DataColumn[9];
                DataColumn[] primaryKeys = new DataColumn[10];
                //  -- UPD 2009/09/11 ----------------------<<<
                for (int index = 0; index < primaryKeys.Length; index++)
				{
					primaryKeys[index] = new DataColumn();
				}

                // 拠点コード
                primaryKeys[0] = CreateColumn(ct_Col_SectionCode, typeof(string), "拠点コード");
                primaryKeys[0].DefaultValue = "";
                dt.Columns.Add(primaryKeys[0]); // DataTableにColumnを追加
                // 倉庫コード
                primaryKeys[1] = CreateColumn(ct_Col_WarehouseCode, typeof(string), "倉庫コード");
                primaryKeys[1].DefaultValue = "";
                dt.Columns.Add(primaryKeys[1]); // DataTableにColumnを追加
                // メーカーコード
                primaryKeys[2] = CreateColumn(ct_Col_MakerCode, typeof(Int32), "メーカーコード");
                primaryKeys[2].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[2]); // DataTableにColumnを追加
                // 品番
                primaryKeys[3] = CreateColumn(ct_Col_GoodsNo, typeof(string), "品番");
                primaryKeys[3].DefaultValue = "";
                dt.Columns.Add(primaryKeys[3]); // DataTableにColumnを追加
                // 得意先コード
                primaryKeys[4] = CreateColumn(ct_Col_SupplierCode, typeof(Int32), "仕入先コード");
                primaryKeys[4].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[4]); // DataTableにColumnを追加
                // 出荷先得意先コード
                primaryKeys[5] = CreateColumn(ct_Col_ShipCustomerCode, typeof(Int32), "出荷先得意先コード");
                primaryKeys[5].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[5]); // DataTableにColumnを追加
                // 原単価
                primaryKeys[6] = CreateColumn(ct_Col_StockUnitPrice, typeof(Double), "原単価");
                primaryKeys[6].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[6]); // DataTableにColumnを追加
                // 在庫区分
                primaryKeys[7] = CreateColumn(ct_Col_StockDiv, typeof(Int32), "在庫区分");
                primaryKeys[7].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[7]); // DataTableにColumnを追加
                // 集計区分
                primaryKeys[8] = CreateColumn(ct_Col_GrossDiv, typeof(Int32), "集計区分");
                primaryKeys[8].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[8]); // DataTableにColumnを追加

                // -- UPD 2009/09/11 ----------------------------------->>>
                // 棚番
                primaryKeys[9] = CreateColumn(ct_Col_WarehouseShelfNo, typeof(string), "棚番");
                primaryKeys[9].DefaultValue = "";
                dt.Columns.Add(primaryKeys[9]); // DataTableにColumnを追加
                // -- UPD 2009/09/11 -----------------------------------<<<
                
                
                // DataTableにKeyを追加
                //dt.PrimaryKey = primaryKeys; //DEL yangyi 2013/03/01 Redmine#34175
			}
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// テーブルスキーマ定義メソッド
        /// </summary>
        /// <param name="dt">DataTable</param>
        static public void CreateDataTable(ref DataTable dt)
        {

            // テーブルインスタンスのチェック
            if (dt != null)
            {
                // テーブルクリア
                dt.Clear();
            }
            else
            {
                dt = new DataTable(ct_Tbl_InventInput);	// テーブルインスタンス作成
                // ﾃｰﾌﾞﾙｽｷｰﾏ定義
                #region
                // 作成日時
                dt.Columns.Add(CreateColumn(ct_Col_CreateDateTime, typeof(DateTime), "作成日時"));
                dt.Columns[ct_Col_CreateDateTime].DefaultValue = DateTime.MinValue;
                // 更新日時
                dt.Columns.Add(CreateColumn(ct_Col_UpdateDateTime, typeof(DateTime), "更新日時"));
                dt.Columns[ct_Col_UpdateDateTime].DefaultValue = DateTime.MinValue;
                // 企業コード
                dt.Columns.Add(CreateColumn(ct_Col_EnterpriseCode, typeof(string), "企業コード"));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = "";
                // GUID
                dt.Columns.Add(CreateColumn(ct_Col_FileHeaderGuid, typeof(Guid), "GUID"));
                dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
                // 更新従業員コード
                dt.Columns.Add(CreateColumn(ct_Col_UpdEmployeeCode, typeof(string), "更新従業員コード"));
                dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = "";
                // 更新アセンブリID1
                dt.Columns.Add(CreateColumn(ct_Col_UpdAssemblyId1, typeof(string), "更新アセンブリID1"));
                dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = "";
                // 更新アセンブリID2
                dt.Columns.Add(CreateColumn(ct_Col_UpdAssemblyId2, typeof(string), "更新アセンブリID2"));
                dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = "";
                // 論理削除区分
                dt.Columns.Add(CreateColumn(ct_Col_LogicalDeleteCode, typeof(Int32), "論理削除区分"));
                dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = 0;
                //// 拠点コード
                //dt.Columns.Add( CreateColumn( ct_Col_SectionCode, typeof(string), "拠点コード" ) );
                //dt.Columns[ct_Col_SectionCode].DefaultValue = "";
                // 拠点ガイド名称
                dt.Columns.Add(CreateColumn(ct_Col_SectionGuideNm, typeof(string), "拠点ガイド名称"));
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";
                // 棚卸通番
                dt.Columns.Add(CreateColumn(ct_Col_InventorySeqNo, typeof(Int32), "通番"));
                dt.Columns[ct_Col_InventorySeqNo].DefaultValue = 0;
                //// 製番在庫マスタGUID
                //dt.Columns.Add( CreateColumn( ct_Col_ProductStockGuid, typeof(Guid), "製番在庫マスタGUID" ) );
                //dt.Columns[ct_Col_ProductStockGuid].DefaultValue = Guid.Empty;
                //// 倉庫コード
                //dt.Columns.Add( CreateColumn( ct_Col_WarehouseCode, typeof(string), "倉庫コード" ) );
                //dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";
                // 倉庫名称
                dt.Columns.Add(CreateColumn(ct_Col_WarehouseName, typeof(string), "倉庫名称"));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
                //// メーカーコード
                //dt.Columns.Add( CreateColumn( ct_Col_MakerCode, typeof(Int32), "メーカーコード" ) );
                //dt.Columns[ct_Col_MakerCode].DefaultValue = 0;
                // メーカー名称
                dt.Columns.Add(CreateColumn(ct_Col_MakerName, typeof(string), "メーカー名称"));
                dt.Columns[ct_Col_MakerName].DefaultValue = "";
                //// 品番
                //dt.Columns.Add( CreateColumn( ct_Col_GoodsCode, typeof(string), "品番" ) );
                //dt.Columns[ct_Col_GoodsCode].DefaultValue = "";
                // 品名
                dt.Columns.Add(CreateColumn(ct_Col_GoodsName, typeof(string), "品名"));
                dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //// 機種コード
                //dt.Columns.Add( CreateColumn( ct_Col_CellphoneModelCode, typeof(string), "機種コード" ) );
                //dt.Columns[ct_Col_CellphoneModelCode].DefaultValue = "";
                //// 機種名称
                //dt.Columns.Add( CreateColumn( ct_Col_CellphoneModelName, typeof(string), "機種名称" ) );
                //dt.Columns[ct_Col_CellphoneModelName].DefaultValue = "";
                //// キャリアコード
                //dt.Columns.Add( CreateColumn( ct_Col_CarrierCode, typeof(Int32), "キャリアコード" ) );
                //dt.Columns[ct_Col_CarrierCode].DefaultValue = 0;
                //// キャリア名称
                //dt.Columns.Add( CreateColumn( ct_Col_CarrierName, typeof(string), "キャリア名称" ) );
                //dt.Columns[ct_Col_CarrierName].DefaultValue = "";
                //// 系統色コード
                //dt.Columns.Add( CreateColumn( ct_Col_SystematicColorCd, typeof(Int32), "系統色コード" ) );
                //dt.Columns[ct_Col_SystematicColorCd].DefaultValue = 0;
                //// 系統色名称
                //dt.Columns.Add( CreateColumn( ct_Col_SystematicColorNm, typeof(string), "系統色名称" ) );
                //dt.Columns[ct_Col_SystematicColorNm].DefaultValue = "";
                // 倉庫棚番
                dt.Columns.Add(CreateColumn(ct_Col_WarehouseShelfNo, typeof(string), "棚番"));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = "";
                // 重複棚番1
                dt.Columns.Add(CreateColumn(ct_Col_DuplicationShelfNo1, typeof(string), "重複棚番１"));
                dt.Columns[ct_Col_DuplicationShelfNo1].DefaultValue = "";
                // 重複棚番2
                dt.Columns.Add(CreateColumn(ct_Col_DuplicationShelfNo2, typeof(string), "重複棚番２"));
                dt.Columns[ct_Col_DuplicationShelfNo2].DefaultValue = "";
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                // 商品大分類コード
                dt.Columns.Add(CreateColumn(ct_Col_LargeGoodsGanreCode, typeof(string), "商品大分類コード"));
                dt.Columns[ct_Col_LargeGoodsGanreCode].DefaultValue = 0;
                // 商品大分類名称
                dt.Columns.Add(CreateColumn(ct_Col_LargeGoodsGanreName, typeof(string), "商品大分類名称"));
                dt.Columns[ct_Col_LargeGoodsGanreName].DefaultValue = "";
                // 商品中分類コード
                dt.Columns.Add(CreateColumn(ct_Col_MediumGoodsGanreCode, typeof(string), "商品中分類コード"));
                dt.Columns[ct_Col_MediumGoodsGanreCode].DefaultValue = 0;
                // 商品中分類名称
                dt.Columns.Add(CreateColumn(ct_Col_MediumGoodsGanreName, typeof(string), "商品中分類名称"));
                dt.Columns[ct_Col_MediumGoodsGanreName].DefaultValue = "";
                //// 事業者コード
                //dt.Columns.Add( CreateColumn( ct_Col_CarrierEpCode, typeof(Int32), "事業者コード" ) );
                //dt.Columns[ct_Col_CarrierEpCode].DefaultValue = 0;
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //// 事業者名称
                //dt.Columns.Add( CreateColumn( ct_Col_CarrierEpName, typeof(string), "事業者名称" ) );
                //dt.Columns[ct_Col_CarrierEpName].DefaultValue = "";
                // グループコード
                dt.Columns.Add(CreateColumn(ct_Col_DetailGoodsGanreCode, typeof(string), "グループコード"));
                dt.Columns[ct_Col_DetailGoodsGanreCode].DefaultValue = 0;
                // グループコード名称
                dt.Columns.Add(CreateColumn(ct_Col_DetailGoodsGanreName, typeof(string), "グループコード名称"));
                dt.Columns[ct_Col_DetailGoodsGanreName].DefaultValue = "";
                // 自社分類コード
                dt.Columns.Add(CreateColumn(ct_Col_EnterpriseGanreCode, typeof(Int32), "自社分類コード"));
                dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = 0;
                // 自社分類名称
                dt.Columns.Add(CreateColumn(ct_Col_EnterpriseGanreName, typeof(string), "自社分類名称"));
                dt.Columns[ct_Col_EnterpriseGanreName].DefaultValue = "";
                // ＢＬ品番
                dt.Columns.Add(CreateColumn(ct_Col_BLGoodsCode, typeof(Int32), "ＢＬ品番"));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
                // ＢＬ品名
                dt.Columns.Add(CreateColumn(ct_Col_BLGoodsName, typeof(string), "ＢＬ品名"));
                dt.Columns[ct_Col_BLGoodsName].DefaultValue = "";
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                //// 得意先コード
                //dt.Columns.Add( CreateColumn( ct_Col_CustomerCode, typeof(Int32), "得意先コード" ) );
                //dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                // 得意先名称
                dt.Columns.Add(CreateColumn(ct_Col_CustomerName, typeof(string), "得意先名称"));
                dt.Columns[ct_Col_CustomerName].DefaultValue = "";
                // 得意先名称2
                dt.Columns.Add(CreateColumn(ct_Col_CustomerName2, typeof(string), "得意先名称2"));
                dt.Columns[ct_Col_CustomerName2].DefaultValue = "";
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 仕入日
                //dt.Columns.Add( CreateColumn( ct_Col_StockDate, typeof(DateTime), "仕入日" ) );
                //dt.Columns[ct_Col_StockDate].DefaultValue = DateTime.MinValue;
                //// 入荷日
                //dt.Columns.Add( CreateColumn( ct_Col_ArrivalGoodsDay, typeof(DateTime), "入荷日" ) );
                //dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = DateTime.MinValue;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                //// 製造番号
                //dt.Columns.Add( CreateColumn( ct_Col_ProductNumber, typeof(string), "製造番号" ) );
                //dt.Columns[ct_Col_ProductNumber].DefaultValue = "";
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 商品電話番号1
                //dt.Columns.Add( CreateColumn( ct_Col_StockTelNo1, typeof(string), "電話番号1" ) );
                //dt.Columns[ct_Col_StockTelNo1].DefaultValue = "";
                //// 変更前商品電話番号1
                //dt.Columns.Add( CreateColumn( ct_Col_BfStockTelNo1, typeof(string), "変更前商品電話番号1" ) );
                //dt.Columns[ct_Col_BfStockTelNo1].DefaultValue = "";
                //// 商品電話番号1変更フラグ
                //dt.Columns.Add( CreateColumn( ct_Col_StkTelNo1ChgFlg, typeof(Int32), "商品電話番号1変更フラグ" ) );
                //dt.Columns[ct_Col_StkTelNo1ChgFlg].DefaultValue = 0;
                //// 商品電話番号2
                //dt.Columns.Add( CreateColumn( ct_Col_StockTelNo2, typeof(string), "電話番号2" ) );
                //dt.Columns[ct_Col_StockTelNo2].DefaultValue = "";
                //// 変更前商品電話番号2
                //dt.Columns.Add( CreateColumn( ct_Col_BfStockTelNo2, typeof(string), "変更前商品電話番号2" ) );
                //dt.Columns[ct_Col_BfStockTelNo2].DefaultValue = "";
                //// 商品電話番号2変更フラグ
                //dt.Columns.Add( CreateColumn( ct_Col_StkTelNo2ChgFlg, typeof(Int32), "商品電話番号2変更フラグ" ) );
                //dt.Columns[ct_Col_StkTelNo2ChgFlg].DefaultValue = 0;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                // JANコード
                dt.Columns.Add(CreateColumn(ct_Col_Jan, typeof(string), "JANコード"));
                dt.Columns[ct_Col_Jan].DefaultValue = "";
                //// 仕入単価
                //dt.Columns.Add( CreateColumn( ct_Col_StockUnitPrice, typeof(Int64), "原単価" ) );
                //dt.Columns[ct_Col_StockUnitPrice].DefaultValue = 0;
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //// 変更前仕入単価
                //dt.Columns.Add( CreateColumn( ct_Col_BfStockUnitPrice, typeof(Int64), "変更前原単価" ) );
                //dt.Columns[ct_Col_BfStockUnitPrice].DefaultValue = 0;
                // 変更前仕入単価
                dt.Columns.Add(CreateColumn(ct_Col_BfStockUnitPrice, typeof(Double), "変更前原単価"));
                dt.Columns[ct_Col_BfStockUnitPrice].DefaultValue = 0;
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                // 仕入単価変更フラグ
                dt.Columns.Add(CreateColumn(ct_Col_StkUnitPriceChgFlg, typeof(Int32), "原単価変更フラグ"));
                dt.Columns[ct_Col_StkUnitPriceChgFlg].DefaultValue = 0;
                //// 在庫区分
                //dt.Columns.Add( CreateColumn( ct_Col_StockDiv, typeof(Int32), "在庫区分" ) );
                //dt.Columns[ct_Col_StockDiv].DefaultValue = 0;
                //// 在庫状態
                //dt.Columns.Add( CreateColumn( ct_Col_StockState, typeof(Int32), "在庫状態" ) );
                //dt.Columns[ct_Col_StockState].DefaultValue = 0;
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 移動状態
                //dt.Columns.Add( CreateColumn( ct_Col_MoveStatus, typeof(Int32), "移動状態" ) );
                //dt.Columns[ct_Col_MoveStatus].DefaultValue = 0;
                //// 商品状態
                //dt.Columns.Add( CreateColumn( ct_Col_GoodsCodeStatus, typeof(Int32), "商品状態" ) );
                //dt.Columns[ct_Col_GoodsCodeStatus].DefaultValue = 0;
                //// 製番管理区分
                //dt.Columns.Add( CreateColumn( ct_Col_PrdNumMngDiv, typeof(Int32), "製番管理区分" ) );
                //dt.Columns[ct_Col_PrdNumMngDiv].DefaultValue = 0;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                // 最終仕入年月日
                dt.Columns.Add(CreateColumn(ct_Col_LastStockDate, typeof(DateTime), "最終仕入年月日"));
                dt.Columns[ct_Col_LastStockDate].DefaultValue = DateTime.MinValue;
                // 帳簿在庫数
                dt.Columns.Add(CreateColumn(ct_Col_StockTotal, typeof(Double), "帳簿数"));
                dt.Columns[ct_Col_StockTotal].DefaultValue = 0;
                //// 出荷先得意先コード
                //dt.Columns.Add( CreateColumn( ct_Col_ShipCustomerCode, typeof(Int32), "出荷先得意先コード" ) );
                //dt.Columns[ct_Col_ShipCustomerCode].DefaultValue = 0;
                // 出荷先得意先名称
                dt.Columns.Add(CreateColumn(ct_Col_ShipCustomerName, typeof(string), "出荷先得意先名称"));
                dt.Columns[ct_Col_ShipCustomerName].DefaultValue = "";
                // 出荷先得意先名称2
                dt.Columns.Add(CreateColumn(ct_Col_ShipCustomerName2, typeof(string), "出荷先得意先名称2"));
                dt.Columns[ct_Col_ShipCustomerName2].DefaultValue = "";
                // 棚卸在庫数
                dt.Columns.Add(CreateColumn(ct_Col_InventoryStockCnt, typeof(Double), "棚卸数"));
                dt.Columns[ct_Col_InventoryStockCnt].DefaultValue = 0;
                // 差異数
                dt.Columns.Add(CreateColumn(ct_Col_InventoryTolerancCnt, typeof(Double), "差異数"));
                dt.Columns[ct_Col_InventoryTolerancCnt].DefaultValue = 0;
                // 変更前差異数
                dt.Columns.Add(CreateColumn(ct_Col_BfChgInventoryToleCnt, typeof(Double), "変更前差異数"));
                dt.Columns[ct_Col_BfChgInventoryToleCnt].DefaultValue = 0;
                // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                // 棚卸日(int)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryExeDay, typeof(Int32), "棚卸日"));
                dt.Columns[ct_Col_InventoryExeDay].DefaultValue = 0;
                // 棚卸日(DateTime)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryExeDay_Datetime, typeof(DateTime), "棚卸日"));
                dt.Columns[ct_Col_InventoryExeDay_Datetime].DefaultValue = DateTime.MinValue;
                // 棚卸日(String)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryExeDay_Str, typeof(string), "棚卸日"));
                dt.Columns[ct_Col_InventoryExeDay_Str].DefaultValue = "";
                // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
                // 棚卸準備処理日付(int)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay, typeof(Int32), "棚卸準備処理日付"));
                dt.Columns[ct_Col_InventoryPreprDay].DefaultValue = 0;
                // 棚卸準備処理日付(DateTime)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_Datetime, typeof(DateTime), "棚卸準備処理日付"));
                dt.Columns[ct_Col_InventoryPreprDay_Datetime].DefaultValue = DateTime.MinValue;
                // 棚卸準備処理日付(年 入力)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_Year, typeof(Int32), "年"));
                dt.Columns[ct_Col_InventoryPreprDay_Year].DefaultValue = 0;
                // 棚卸準備処理日付(年 ラベル)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_YearL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryPreprDay_YearL].DefaultValue = "年";
                // 棚卸準備処理日付(月 入力)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_Month, typeof(Int32), "月"));
                dt.Columns[ct_Col_InventoryPreprDay_Month].DefaultValue = 0;
                // 棚卸準備処理日付(月 ラベル)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_MonthL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryPreprDay_MonthL].DefaultValue = "月";
                // 棚卸準備処理日付(日 入力)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_Day, typeof(Int32), "日"));
                dt.Columns[ct_Col_InventoryPreprDay_Day].DefaultValue = 0;
                // 棚卸準備処理日付(日 ラベル)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprDay_DayL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryPreprDay_DayL].DefaultValue = "日";
                // 棚卸実施日(int)
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(CreateColumn(ct_Col_InventoryDay, typeof(Int32), "棚卸日"));
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay, typeof(Int32), "棚卸実施日"));
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                dt.Columns[ct_Col_InventoryDay].DefaultValue = 0;
                // 棚卸実施日(DateTime)
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Datetime, typeof(DateTime), "棚卸日"));
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Datetime, typeof(DateTime), "棚卸実施日"));
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                dt.Columns[ct_Col_InventoryDay_Datetime].DefaultValue = DateTime.MinValue;
                // 棚卸実施日(年 入力)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Year, typeof(Int32), "年"));
                dt.Columns[ct_Col_InventoryDay_Year].DefaultValue = 0;
                // 棚卸実施日(年 ラベル)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_YearL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryDay_YearL].DefaultValue = "年";
                // 棚卸実施日(月 入力)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Month, typeof(Int32), "月"));
                dt.Columns[ct_Col_InventoryDay_Month].DefaultValue = 0;
                // 棚卸実施日(月 ラベル)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_MonthL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryDay_MonthL].DefaultValue = "月";
                // 棚卸実施日(日 入力)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_Day, typeof(Int32), "日"));
                dt.Columns[ct_Col_InventoryDay_Day].DefaultValue = 0;
                // 棚卸実施日(日 ラベル)
                dt.Columns.Add(CreateColumn(ct_Col_InventoryDay_DayL, typeof(string), ""));
                dt.Columns[ct_Col_InventoryDay_DayL].DefaultValue = "日";
                // 棚卸準備処理時間
                dt.Columns.Add(CreateColumn(ct_Col_InventoryPreprTim, typeof(Int32), "棚卸準備処理時間"));
                dt.Columns[ct_Col_InventoryPreprTim].DefaultValue = 0;
                // 棚卸更新日
                dt.Columns.Add(CreateColumn(ct_Col_LastInventoryUpdate, typeof(DateTime), "棚卸更新日"));
                dt.Columns[ct_Col_LastInventoryUpdate].DefaultValue = DateTime.MinValue;
                // 棚卸新規追加区分
                dt.Columns.Add(CreateColumn(ct_Col_InventoryNewDiv, typeof(Int32), "区分"));
                dt.Columns[ct_Col_InventoryNewDiv].DefaultValue = 0;
                // 棚卸新規追加区分名称
                dt.Columns.Add(CreateColumn(ct_Col_InventoryNewDivName, typeof(string), "新規区分"));
                dt.Columns[ct_Col_InventoryNewDivName].DefaultValue = "";
                // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
                // 在庫額
                dt.Columns.Add(CreateColumn(ct_Col_StockMashinePrice, typeof(Int64), "在庫額"));
                dt.Columns[ct_Col_StockMashinePrice].DefaultValue = 0;
                // 棚卸在庫額
                dt.Columns.Add(CreateColumn(ct_Col_InventoryStockPrice, typeof(Int64), "棚卸在庫額"));
                dt.Columns[ct_Col_InventoryStockPrice].DefaultValue = 0;
                // 棚卸過不足金額
                dt.Columns.Add(CreateColumn(ct_Col_InventoryTlrncPrice, typeof(Int64), "棚卸過不足金額"));
                dt.Columns[ct_Col_InventoryTlrncPrice].DefaultValue = 0;
                // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<

                // 在庫委託受託区分
                dt.Columns.Add(CreateColumn(ct_Col_StockTrtEntDiv, typeof(Int32), "在庫委託受託区分"));
                dt.Columns[ct_Col_StockTrtEntDiv].DefaultValue = 0;
                // 在庫委託受託区分名称
                dt.Columns.Add(CreateColumn(ct_Col_StockTrtEntDivName, typeof(string), "在庫区分"));
                dt.Columns[ct_Col_StockTrtEntDivName].DefaultValue = "";
                //// 集計区分
                //dt.Columns.Add( CreateColumn( ct_Col_GrossDiv, typeof(Int32), "集計区分" ) );
                //dt.Columns[ct_Col_GrossDiv].DefaultValue = 0;
                // 表示区分
                dt.Columns.Add(CreateColumn(ct_Col_ViewDiv, typeof(Int32), "表示区分"));
                dt.Columns[ct_Col_ViewDiv].DefaultValue = 0;
                // ボタン用カラム
                dt.Columns.Add(CreateColumn(ct_Col_Button, typeof(char), ""));
                //dt.Columns[ct_Col_Button].DefaultValue = 0;
                // 自行
                dt.Columns.Add(CreateColumn(ct_Col_RowSelf, typeof(object), ""));
                dt.Columns[ct_Col_RowSelf].DefaultValue = null;
                // ステータス
                dt.Columns.Add(CreateColumn(ct_Col_Status, typeof(Int32), "ステータス"));
                dt.Columns[ct_Col_Status].DefaultValue = 0;
                // ステータス内容
                dt.Columns.Add(CreateColumn(ct_Col_StatusDetail, typeof(string), "ステータス"));
                dt.Columns[ct_Col_StatusDetail].DefaultValue = "";
                // 変更区分
                dt.Columns.Add(CreateColumn(ct_Col_ChangeDiv, typeof(Int32), "変更区分"));
                dt.Columns[ct_Col_ChangeDiv].DefaultValue = 0;
                // 更新対象区分
                dt.Columns.Add(CreateColumn(ct_Col_UpdateDiv, typeof(Int32), "更新対象"));
                dt.Columns[ct_Col_UpdateDiv].DefaultValue = 0;
                // 移動在庫数
                dt.Columns.Add(CreateColumn(ct_Col_MoveStockCount, typeof(Int32), "移動在庫数"));
                dt.Columns[ct_Col_MoveStockCount].DefaultValue = 0;

                // Key(バーコード読込に使用
                dt.Columns.Add(CreateColumn(ct_Col_key, typeof(Guid), "Key"));
                dt.Columns[ct_Col_key].DefaultValue = Guid.Empty;

                // ソート用製造番号
                dt.Columns.Add(CreateColumn(ct_Col_SortProductNumber, typeof(string), ""));
                dt.Columns[ct_Col_SortProductNumber].DefaultValue = "";


                // 2007.07.19 kubo add -------------------------------------->
                // 2007.09.11 変更 >>>>>>>>>>>>>>>>>>>>
                //DataColumn[] primaryKeys = new DataColumn[13];
                DataColumn[] primaryKeys = new DataColumn[9];
                // 2007.09.11 変更 <<<<<<<<<<<<<<<<<<<<
                for (int index = 0; index < primaryKeys.Length; index++)
                {
                    primaryKeys[index] = new DataColumn();
                }

                // 2007.09.11 変更 >>>>>>>>>>>>>>>>>>>>
                #region // 2007.09.11 変更
                //// 拠点コード
                //primaryKeys[0] = CreateColumn( ct_Col_SectionCode, typeof(string), "拠点コード" );
                //primaryKeys[0].DefaultValue = "";
                //dt.Columns.Add(primaryKeys[0]); // DataTableにColumnを追加
                //// 倉庫コード
                //primaryKeys[1] = CreateColumn( ct_Col_WarehouseCode, typeof(string), "倉庫コード" );
                //primaryKeys[1].DefaultValue = "";
                //dt.Columns.Add(primaryKeys[1]); // DataTableにColumnを追加
                //// メーカーコード
                //primaryKeys[2] = CreateColumn( ct_Col_MakerCode, typeof(Int32), "メーカーコード" );
                //primaryKeys[2].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[2]); // DataTableにColumnを追加
                //// 品番
                //primaryKeys[3] = CreateColumn( ct_Col_GoodsCode, typeof(string), "品番" );
                //primaryKeys[3].DefaultValue = "";
                //dt.Columns.Add(primaryKeys[3]); // DataTableにColumnを追加
                //// 事業者コード
                //primaryKeys[4] = CreateColumn( ct_Col_CarrierEpCode, typeof(Int32), "事業者コード" );
                //primaryKeys[4].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[4]); // DataTableにColumnを追加
                //// 得意先コード
                //primaryKeys[5] = CreateColumn( ct_Col_CustomerCode, typeof(Int32), "得意先コード" );
                //primaryKeys[5].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[5]); // DataTableにColumnを追加
                //// 出荷先得意先コード
                //primaryKeys[6] = CreateColumn( ct_Col_ShipCustomerCode, typeof(Int32), "出荷先得意先コード" );
                //primaryKeys[6].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[6]); // DataTableにColumnを追加
                //// 原単価
                //primaryKeys[7] = CreateColumn( ct_Col_StockUnitPrice, typeof(Int64), "原単価" );
                //primaryKeys[7].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[7]); // DataTableにColumnを追加
                //// 在庫区分
                //primaryKeys[8] = CreateColumn( ct_Col_StockDiv, typeof(Int32), "在庫区分" );
                //primaryKeys[8].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[8]); // DataTableにColumnを追加
                //// 在庫状態
                //primaryKeys[9] = CreateColumn( ct_Col_StockState, typeof(Int32), "在庫状態" );
                //primaryKeys[9].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[9]); // DataTableにColumnを追加
                ////// 棚卸新規追加区分
                ////primaryKeys[10] = CreateColumn( ct_Col_InventoryNewDiv, typeof(Int32), "区分" );
                ////primaryKeys[10].DefaultValue = 0;
                ////dt.Columns.Add(primaryKeys[10]); // DataTableにColumnを追加
                //// 製造番号
                //primaryKeys[10] = CreateColumn( ct_Col_ProductNumber, typeof(string), "製造番号" );
                //primaryKeys[10].DefaultValue = "";
                //dt.Columns.Add(primaryKeys[10]); // DataTableにColumnを追加
                //// 集計区分
                //primaryKeys[11] = CreateColumn( ct_Col_GrossDiv, typeof(Int32), "集計区分" );
                //primaryKeys[11].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[11]); // DataTableにColumnを追加
                //// 製番在庫マスタGUID
                //primaryKeys[12] = CreateColumn( ct_Col_ProductStockGuid, typeof(Guid), "製番在庫マスタGUID" );
                //primaryKeys[12].DefaultValue = Guid.Empty;
                //dt.Columns.Add(primaryKeys[12]); // DataTableにColumnを追加
                //// 2007.07.19 kubo add <--------------------------------------
                #endregion
                // 拠点コード
                primaryKeys[0] = CreateColumn(ct_Col_SectionCode, typeof(string), "拠点コード");
                primaryKeys[0].DefaultValue = "";
                dt.Columns.Add(primaryKeys[0]); // DataTableにColumnを追加
                // 倉庫コード
                primaryKeys[1] = CreateColumn(ct_Col_WarehouseCode, typeof(string), "倉庫コード");
                primaryKeys[1].DefaultValue = "";
                dt.Columns.Add(primaryKeys[1]); // DataTableにColumnを追加
                // メーカーコード
                primaryKeys[2] = CreateColumn(ct_Col_MakerCode, typeof(Int32), "メーカーコード");
                primaryKeys[2].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[2]); // DataTableにColumnを追加
                // 品番
                primaryKeys[3] = CreateColumn(ct_Col_GoodsNo, typeof(string), "品番");
                primaryKeys[3].DefaultValue = "";
                dt.Columns.Add(primaryKeys[3]); // DataTableにColumnを追加
                // 得意先コード
                primaryKeys[4] = CreateColumn(ct_Col_CustomerCode, typeof(Int32), "得意先コード");
                primaryKeys[4].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[4]); // DataTableにColumnを追加
                // 出荷先得意先コード
                primaryKeys[5] = CreateColumn(ct_Col_ShipCustomerCode, typeof(Int32), "出荷先得意先コード");
                primaryKeys[5].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[5]); // DataTableにColumnを追加
                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                //// 原単価
                //primaryKeys[6] = CreateColumn(ct_Col_StockUnitPrice, typeof(Int64), "原単価");
                //primaryKeys[6].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[6]); // DataTableにColumnを追加
                // 原単価
                primaryKeys[6] = CreateColumn(ct_Col_StockUnitPrice, typeof(Double), "原単価");
                primaryKeys[6].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[6]); // DataTableにColumnを追加
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                // 在庫区分
                primaryKeys[7] = CreateColumn(ct_Col_StockDiv, typeof(Int32), "在庫区分");
                primaryKeys[7].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[7]); // DataTableにColumnを追加
                // 棚卸新規追加区分
                //primaryKeys[8] = CreateColumn( ct_Col_InventoryNewDiv, typeof(Int32), "区分" );
                //primaryKeys[8].DefaultValue = 0;
                //dt.Columns.Add(primaryKeys[8]); // DataTableにColumnを追加
                // 集計区分
                primaryKeys[8] = CreateColumn(ct_Col_GrossDiv, typeof(Int32), "集計区分");
                primaryKeys[8].DefaultValue = 0;
                dt.Columns.Add(primaryKeys[8]); // DataTableにColumnを追加
                // 2007.09.11 変更 <<<<<<<<<<<<<<<<<<<<

                #region // 2007.07.19 kubo del -------------------------------------->
                //// key1:key
                //primaryKeys[14].ColumnName	= ct_Col_key;
                //primaryKeys[14].DataType		= System.Type.GetType("System.String");
                //primaryKeys[14].DefaultValue = "";
                //// DataTableにColumnを追加
                //dt.Columns.Add(primaryKeys[14]);
                #endregion // 2007.07.19 kubo del <--------------------------------------

                // DataTableにKeyを追加
                dt.PrimaryKey = primaryKeys;

                #endregion

            }
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion ◆ テーブルスキーマ定義メソッド
        #endregion ■ Public Method

        #region ■ Public Method
        #region ◆ データテーブル列作成メソッド
        /// <summary>
        /// データテーブルの列を作成する
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="type">型</param>
        /// <param name="caption">キャプション</param>
        /// <returns></returns>
        private static DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc;

            dc = new DataColumn();
            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;
            dc.ColumnMapping = MappingType.Element;
            return dc;
        }
		#endregion ◆ データテーブル列作成メソッド
		#endregion ■ Public Method

	}
}
