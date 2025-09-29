using System;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 在庫調整明細列表示状況クラス
	/// </summary>
	internal class PtAdjustStockDtlDisplayStatus
	{
		//====================================================================================================
		//  プライベート定数
		//====================================================================================================
		#region プライベート定数
		/// <summary>
		/// クラスID(TEMP保存用)
		/// </summary>
		private const string CT_CLASSID = "MAZAI04360UC";

        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// KEYLIST(TEMP保存用)
		/// </summary>
		private const string CT_KEYLIST = "StockAdjustDtlStatus";
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        
        #region 列順定義定数
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>行番号</summary>
        //public const int ctINDX_RowNum = 0;
        ///// <summary>商品コード</summary>
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////public const int ctINDX_GoodsCode = ctINDX_RowNum + 1;
        //public const int ctINDX_GoodsNo = ctINDX_RowNum + 1;
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>商品ガイド</summary>
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////public const int ctINDX_GoodsGuide = ctINDX_GoodsCode + 1;
        //public const int ctINDX_GoodsGuide = ctINDX_GoodsNo + 1;
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>商品名</summary>
        //public const int ctINDX_GoodsName = ctINDX_GoodsGuide + 1;
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>倉庫コード</summary>
        ////public const int ctINDX_WarehouseCode = ctINDX_GoodsName + 1;
        ///// <summary>メーカーコード</summary>
        //public const int ctINDX_GoodsMakerCd = ctINDX_GoodsName + 1;
        ///// <summary>メーカー名称</summary>
        //public const int ctINDX_MakerName = ctINDX_GoodsMakerCd + 1;
        ///// <summary>仕入先名称</summary>
        //public const int ctINDX_CustomerName = ctINDX_MakerName + 1;
        ///// <summary>ＢＬ商品コード</summary>
        //public const int ctINDX_BLGoodsCode = ctINDX_CustomerName + 1;
        ///// <summary>倉庫コード</summary>
        //public const int ctINDX_WarehouseCode = ctINDX_BLGoodsCode + 1;
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>倉庫名称</summary>
        //public const int ctINDX_WarehouseName = ctINDX_WarehouseCode + 1;
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>製造番号</summary>
        ////public const int ctINDX_ProductNumber = ctINDX_WarehouseName + 1;
        /////// <summary>携帯番号</summary>
        ////public const int ctINDX_StockTelNo1 = ctINDX_ProductNumber + 1;
        /////// <summary>修正前製番</summary>
        ////public const int ctINDX_BfProductNumber = ctINDX_StockTelNo1+ 1;
        /////// <summary>商品状態</summary>
        ////public const int ctINDX_GoodsCodeStatus = ctINDX_BfProductNumber + 1;
        /////// <summary>在庫数(仕入在庫数)</summary>
        ////public const int ctINDX_SupplierStock = ctINDX_GoodsCodeStatus + 1;
        ///// <summary>棚番</summary>
        //public const int ctINDX_WarehouseShelfNo = ctINDX_WarehouseName + 1;
        ///// <summary>修正前棚番</summary>
        //public const int ctINDX_BfWarehouseShelfNo = ctINDX_WarehouseShelfNo + 1;
        ///// <summary>在庫数(仕入在庫数)</summary>
        //public const int ctINDX_SupplierStock = ctINDX_BfWarehouseShelfNo + 1;
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>在庫数(仕入在庫数)</summary>
        //public const int ctINDX_TrustCount = ctINDX_SupplierStock + 1;
        ///// <summary>調整数</summary>
        //public const int ctINDX_AdjustCount = ctINDX_TrustCount + 1;
        ///// <summary>仕入単価</summary>
        //public const int ctINDX_StockUnitPrice = ctINDX_AdjustCount + 1;
        ///// <summary>修正前原価単価</summary>
        //public const int ctINDX_BfStockUnitPrice = ctINDX_StockUnitPrice + 1;
        //// 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>調整金額</summary>
        ////public const int ctINDX_AdjustPrice = ctINDX_StockUnitPrice + 1;
        //public const int ctINDX_AdjustPrice = ctINDX_BfStockUnitPrice + 1;
        //// 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<
        //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>明細備考</summary>
        //public const int ctINDX_DtlNote = ctINDX_AdjustPrice + 1;
        //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>定価（浮動）</summary>
        //public const int ctINDX_ListPriceFl = ctINDX_DtlNote + 1;
        //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>No</summary>
        public const int ctINDX_RowNum = 0;
        /// <summary>品番</summary>
        public const int ctINDX_GoodsNo = ctINDX_RowNum + 1;
        /// <summary>品名</summary>
        public const int ctINDX_GoodsName = ctINDX_GoodsNo + 1;
        /// <summary>ＢＬ商品コード</summary>
        public const int ctINDX_BLGoodsCode = ctINDX_GoodsName + 1;
        /// <summary>メーカー</summary>
        public const int ctINDX_GoodsMakerCd = ctINDX_BLGoodsCode + 1;
        /// <summary>仕入先</summary>
        public const int ctINDX_SupplierCd = ctINDX_GoodsMakerCd + 1;
        /// <summary>標準価格</summary>
        public const int ctINDX_ListPriceFl = ctINDX_SupplierCd + 1;
        /// <summary>原単価</summary>
        public const int ctINDX_StockUnitPrice = ctINDX_ListPriceFl + 1;
        /// <summary>仕入数</summary>
        public const int ctINDX_SalesOrderUnit = ctINDX_StockUnitPrice + 1;
        /// <summary>仕入後数</summary>
        public const int ctINDX_AfSalesOrderUnit = ctINDX_SalesOrderUnit + 1;
        /// <summary>棚番</summary>
        public const int ctINDX_WarehouseShelfNo = ctINDX_AfSalesOrderUnit + 1;
        /// <summary>発注残</summary>
        public const int ctINDX_SalesOrderCount = ctINDX_WarehouseShelfNo + 1;
        /// <summary>在庫数(仕入在庫数)</summary>
        public const int ctINDX_SupplierStock = ctINDX_SalesOrderCount + 1;
        /// <summary>明細備考</summary>
        public const int ctINDX_DtlNote = ctINDX_SupplierStock + 1;
        
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		#region 列名定義定数
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>行番号</summary>
        //public const string ctCOL_RowNum = "RowNum";
        ///// <summary>商品コード</summary>
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////public const string ctCOL_GoodsCode = "GoodsCode";
        //public const string ctCOL_GoodsNo = "GoodsNo";
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>商品ガイド</summary>
        //public const string ctCOL_GoodsGuide = "GoodsGuide";
        ///// <summary>商品名</summary>
        //public const string ctCOL_GoodsName = "GoodsName";
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>メーカーコード</summary>
        //public const string ctCOL_GoodsMakerCd = "GoodsMakerCd";
        ///// <summary>メーカー名称</summary>
        //public const string ctCOL_MakerName = "MakerName";
        ///// <summary>仕入先名称</summary>
        //public const string ctCOL_CustomerName = "CustomerName";
        ///// <summary>ＢＬ商品コード</summary>
        //public const string ctCOL_BLGoodsCode = "BLGoodsCode";
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>倉庫コード</summary>
        //public const string ctCOL_WarehouseCode = "WarehouseCode";
        ///// <summary>倉庫名称</summary>
        //public const string ctCOL_WarehouseName = "WarehouseName";
        ////// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>製造番号</summary>
        ////public const string ctCOL_ProductNumber = "ProductNumber";
        /////// <summary>携帯番号</summary>
        ////public const string ctCOL_StockTelNo1 = "StockTelNo1";
        /////// <summary>修正前製番</summary>
        ////public const string ctCOL_BfProductNumber = "BfProductNumber";
        /////// <summary>商品状態</summary>
        ////public const string ctCOL_GoodsCodeStatus = "GoodsCodeStatus";
        ///// <summary>棚番</summary>
        //public const string ctCOL_WarehouseShelfNo = "WarehouseShelfNo";
        ///// <summary>修正前棚番</summary>
        //public const string ctCOL_BfWarehouseShelfNo = "BfWarehouseShelfNo";
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>在庫数(仕入在庫数)</summary>
        //public const string ctCOL_SupplierStock = "SupplierStock";
        ///// <summary>受託数</summary>
        //public const string ctCOL_TrustCount = "TrustCount";
        ///// <summary>調整数</summary>
        //public const string ctCOL_AdjustCount = "AdjustCount";
        ///// <summary>仕入単価</summary>
        //public const string ctCOL_StockUnitPrice = "StockUnitPrice";
        ///// <summray>修正前仕入単価</summray>
        //public const string ctCOL_BfStockUnitPrice = "BfStockUnitPrice";
        ///// <summary>調整金額</summary>
        //public const string ctCOL_AdjustPrice = "AdjustPrice";
        //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>明細備考</summary>
        //public const string ctCOL_DtlNote = "DtlNote";
        //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>定価（浮動）</summary>
        //public const string ctCOL_ListPriceFl = "ListPriceFl";
        //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>No</summary>
        public const string ctCOL_RowNum = "RowNum";
        /// <summary>品番</summary>
        public const string ctCOL_GoodsNo = "GoodsNo";
        /// <summary>品名</summary>
        public const string ctCOL_GoodsName = "GoodsName";
        /// <summary>ＢＬ商品コード</summary>
        public const string ctCOL_BLGoodsCode = "BLGoodsCode";
        /// <summary>メーカー</summary>
        public const string ctCOL_GoodsMakerCd = "GoodsMakerCd";
        /// <summary>仕入先</summary>
        public const string ctCOL_SupplierCd = "SupplierCd";
        /// <summary>標準価格</summary>
        public const string ctCOL_ListPriceFl = "ListPriceFl";
        /// <summary>原単価</summary>
        public const string ctCOL_StockUnitPrice = "StockUnitPrice";
        /// <summary>仕入数</summary>
        public const string ctCOL_SalesOrderUnit = "SalesOrderUnit";
        /// <summary>仕入後数</summary>
        public const string ctCOL_AfSalesOrderUnit = "AfSalesOrderUnit";
        /// <summary>棚番</summary>
        public const string ctCOL_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary>発注残</summary>
        public const string ctCOL_SalesOrderCount = "SalesOrderCount";
        /// <summary>在庫数(仕入在庫数)</summary>
        public const string ctCOL_SupplierStock = "SupplierStock";
        /// <summary>明細備考</summary>
        public const string ctCOL_DtlNote = "DtlNote";
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

		/// <summary>文字サイズ</summary>
		private const string ctCOL_FontSize = "FontSize";
		/// <summary>内税外税両表示</summary>
		private const string ctCOL_TaxDisplay = "TaxDisplay";
		#endregion

		#region 列初期値テーブル
		/// <summary>
		/// 明細列表示ステータスの初期値
		/// </summary>
		private AdjustStockDtlDisplayStatus[] CT_DEFAULTSTATUS = new AdjustStockDtlDisplayStatus[]
			{
                // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                #region DEL 2008/07/24
                //new AdjustStockDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,50,true),
                //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                ////new AdjustStockDtlDisplayStatus(ctCOL_GoodsCode,ctINDX_GoodsCode, 180, true),	// 商品コード
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsNo,ctINDX_GoodsNo, 180, true),	// 商品コード
                //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsGuide,ctINDX_GoodsGuide,30,true),    // 商品ガイド
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsName,ctINDX_GoodsName, 180, true),	// 商品名称
                //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsMakerCd, ctINDX_GoodsMakerCd, 120, true),    // メーカーコード
                //new AdjustStockDtlDisplayStatus(ctCOL_MakerName, ctINDX_MakerName, 120, true),  // メーカー名称
                //new AdjustStockDtlDisplayStatus(ctCOL_CustomerName, ctINDX_CustomerName, 100, false),    // 仕入先名称
                //new AdjustStockDtlDisplayStatus(ctCOL_BLGoodsCode, ctINDX_BLGoodsCode, 100, true),  // ＢＬ商品コード
                //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseCode,ctINDX_WarehouseCode,100,true), //倉庫コード
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseName,ctINDX_WarehouseName,100,true), //倉庫名称
                //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                ////new AdjustStockDtlDisplayStatus(ctCOL_ProductNumber, ctINDX_ProductNumber, 160, true),	// 製造番号
                ////new AdjustStockDtlDisplayStatus(ctCOL_StockTelNo1, ctINDX_StockTelNo1, 120, true),	// 携帯番号
                ////new AdjustStockDtlDisplayStatus(ctCOL_BfProductNumber,ctINDX_BfProductNumber,120,false),    //変更前製番
                ////new AdjustStockDtlDisplayStatus(ctCOL_GoodsCodeStatus,ctINDX_GoodsCodeStatus,50,false) ,//商品状態
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseShelfNo, ctINDX_WarehouseShelfNo, 100, true),    // 棚番
                //new AdjustStockDtlDisplayStatus(ctCOL_BfWarehouseShelfNo, ctINDX_BfWarehouseShelfNo, 100, true),    // 修正前棚番
                //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_SupplierStock, ctINDX_SupplierStock, 80, true),	// 仕入在庫数
                //new AdjustStockDtlDisplayStatus(ctCOL_TrustCount, ctINDX_SupplierStock, 80, true),	// 受託在庫数
                //new AdjustStockDtlDisplayStatus(ctCOL_AdjustCount, ctINDX_AdjustCount, 80, true),	// 調整数
                //new AdjustStockDtlDisplayStatus(ctCOL_StockUnitPrice, ctINDX_StockUnitPrice, 80, true), // 仕入単価
                //new AdjustStockDtlDisplayStatus(ctCOL_BfStockUnitPrice, ctINDX_BfStockUnitPrice, 80, true), // 修正前仕入単価                
                //new AdjustStockDtlDisplayStatus(ctCOL_AdjustPrice, ctINDX_AdjustPrice, 80, true),   // 調整金額
                //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_DtlNote, ctINDX_DtlNote, 280, true),  // 明細備考
                //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
                //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_ListPriceFl, ctINDX_ListPriceFl, 80, false),  // 定価（浮動）
                //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
                #endregion DEL 2008/07/24

                new AdjustStockDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,50,true),                            // No
				new AdjustStockDtlDisplayStatus(ctCOL_GoodsNo,ctINDX_GoodsNo, 180, true),	                    // 品番
				new AdjustStockDtlDisplayStatus(ctCOL_GoodsName,ctINDX_GoodsName, 180, true),	                // 品名
                new AdjustStockDtlDisplayStatus(ctCOL_BLGoodsCode, ctINDX_BLGoodsCode, 100, true),              // ＢＬコード
                new AdjustStockDtlDisplayStatus(ctCOL_GoodsMakerCd, ctINDX_GoodsMakerCd, 100, true),            // メーカー
                new AdjustStockDtlDisplayStatus(ctCOL_SupplierCd, ctINDX_SupplierCd, 100, true),                // 仕入先
                new AdjustStockDtlDisplayStatus(ctCOL_ListPriceFl, ctINDX_ListPriceFl, 135, true),               // 標準価格
				new AdjustStockDtlDisplayStatus(ctCOL_StockUnitPrice, ctINDX_StockUnitPrice, 130, true),         // 原単価
				new AdjustStockDtlDisplayStatus(ctCOL_SalesOrderUnit, ctINDX_SalesOrderUnit, 125, true),         // 仕入数
				new AdjustStockDtlDisplayStatus(ctCOL_AfSalesOrderUnit, ctINDX_AfSalesOrderUnit, 125, true),     // 仕入後数
                new AdjustStockDtlDisplayStatus(ctCOL_WarehouseShelfNo, ctINDX_WarehouseShelfNo, 100, true),    // 棚番
                new AdjustStockDtlDisplayStatus(ctCOL_SalesOrderCount, ctINDX_SalesOrderCount, 100, true),      // 発注残
				new AdjustStockDtlDisplayStatus(ctCOL_SupplierStock, ctINDX_SupplierStock, 100, true),	        // 在庫数(仕入在庫数)
				new AdjustStockDtlDisplayStatus(ctCOL_DtlNote, ctINDX_DtlNote, 280, true),                      // 明細備考
                // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
			};
        /// <summary>
        /// 明細列表示ステータスの変更値
        /// </summary>
        private AdjustStockDtlDisplayStatus[] CT_CHANGESTATUS = new AdjustStockDtlDisplayStatus[]
			{
                // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
                #region DEL 2008/07/24
                //new AdjustStockDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,50,true),
                //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                ////new AdjustStockDtlDisplayStatus(ctCOL_GoodsCode,ctINDX_GoodsCode, 180, true),	// 商品コード
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsNo,ctINDX_GoodsNo, 180, true),	// 商品コード
                //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsGuide,ctINDX_GoodsGuide,30,true),    // 商品ガイド
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsName,ctINDX_GoodsName, 180, true),	// 商品名称
                //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_GoodsMakerCd, ctINDX_GoodsMakerCd, 120, true),    // メーカーコード
                //new AdjustStockDtlDisplayStatus(ctCOL_MakerName, ctINDX_MakerName, 120, true),  // メーカー名称
                //new AdjustStockDtlDisplayStatus(ctCOL_CustomerName, ctINDX_CustomerName, 100, false),    // 仕入先名称
                //new AdjustStockDtlDisplayStatus(ctCOL_BLGoodsCode, ctINDX_BLGoodsCode, 100, true),  // ＢＬ商品コード
                //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseCode,ctINDX_WarehouseCode,100,true), //倉庫コード
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseName,ctINDX_WarehouseName,100,true), //倉庫名称
                //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                ////new AdjustStockDtlDisplayStatus(ctCOL_ProductNumber, ctINDX_ProductNumber, 160, true),	// 製造番号
                ////new AdjustStockDtlDisplayStatus(ctCOL_StockTelNo1, ctINDX_StockTelNo1, 120, false),	// 携帯番号
                ////new AdjustStockDtlDisplayStatus(ctCOL_BfProductNumber,ctINDX_BfProductNumber,120,true), //変更前製番
                ////new AdjustStockDtlDisplayStatus(ctCOL_GoodsCodeStatus,ctINDX_GoodsCodeStatus,50,false),//商品状態
                //new AdjustStockDtlDisplayStatus(ctCOL_WarehouseShelfNo, ctINDX_WarehouseShelfNo, 80, true),    // 棚番
                //new AdjustStockDtlDisplayStatus(ctCOL_BfWarehouseShelfNo, ctINDX_BfWarehouseShelfNo, 80, true),    // 修正前棚番
                //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
                //new AdjustStockDtlDisplayStatus(ctCOL_SupplierStock, ctINDX_SupplierStock, 80, true),	// 仕入在庫数
                //new AdjustStockDtlDisplayStatus(ctCOL_TrustCount, ctINDX_SupplierStock, 80, true),	// 受託在庫数
                //new AdjustStockDtlDisplayStatus(ctCOL_AdjustCount, ctINDX_AdjustCount, 80, true),	// 調整数
                //new AdjustStockDtlDisplayStatus(ctCOL_StockUnitPrice, ctINDX_StockUnitPrice, 80, true), // 仕入単価
                //new AdjustStockDtlDisplayStatus(ctCOL_BfStockUnitPrice, ctINDX_BfStockUnitPrice, 80, true), // 仕入単価
                //new AdjustStockDtlDisplayStatus(ctCOL_AdjustPrice, ctINDX_AdjustPrice, 80, true),   // 調整金額
                //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_DtlNote, ctINDX_DtlNote, 280, true),  // 明細備考
                //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
                //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockDtlDisplayStatus(ctCOL_ListPriceFl, ctINDX_ListPriceFl, 80, false),  // 定価（浮動）
                //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
                #endregion DEL 2008/07/24

                new AdjustStockDtlDisplayStatus(ctCOL_RowNum,ctINDX_RowNum,50,true),                            // No
				new AdjustStockDtlDisplayStatus(ctCOL_GoodsNo,ctINDX_GoodsNo, 180, true),	                    // 品番
				new AdjustStockDtlDisplayStatus(ctCOL_GoodsName,ctINDX_GoodsName, 180, true),	                // 品名
                new AdjustStockDtlDisplayStatus(ctCOL_BLGoodsCode, ctINDX_BLGoodsCode, 100, true),              // ＢＬコード
                new AdjustStockDtlDisplayStatus(ctCOL_GoodsMakerCd, ctINDX_GoodsMakerCd, 100, true),            // メーカー
                new AdjustStockDtlDisplayStatus(ctCOL_SupplierCd, ctINDX_SupplierCd, 100, true),                // 仕入先
                new AdjustStockDtlDisplayStatus(ctCOL_ListPriceFl, ctINDX_ListPriceFl, 135, true),               // 標準価格
				new AdjustStockDtlDisplayStatus(ctCOL_StockUnitPrice, ctINDX_StockUnitPrice, 130, true),         // 原単価
				new AdjustStockDtlDisplayStatus(ctCOL_SalesOrderUnit, ctINDX_SalesOrderUnit, 125, true),         // 仕入数
				new AdjustStockDtlDisplayStatus(ctCOL_AfSalesOrderUnit, ctINDX_AfSalesOrderUnit, 125, true),     // 仕入後数
                new AdjustStockDtlDisplayStatus(ctCOL_WarehouseShelfNo, ctINDX_WarehouseShelfNo, 100, true),     // 棚番
                new AdjustStockDtlDisplayStatus(ctCOL_SalesOrderCount, ctINDX_SalesOrderCount, 100, true),       // 発注残
				new AdjustStockDtlDisplayStatus(ctCOL_SupplierStock, ctINDX_SupplierStock, 100, true),	        // 在庫数(仕入在庫数)
				new AdjustStockDtlDisplayStatus(ctCOL_DtlNote, ctINDX_DtlNote, 280, true),                      // 明細備考
                // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
			};

		#endregion
		#endregion

		//====================================================================================================
		//  プライベート変数宣言
		//====================================================================================================
		#region プライベート変数
		/// <summary>
		/// 仕入明細列ステータス
		/// </summary>
		private ArrayList mDetailStatus;
		/// <summary>
		/// フォントサイズ
		/// </summary>
		private int _fontSize = 11;
		/// <summary>
		/// 内税外税両表示
		/// </summary>
		private bool _dispBothTaxway = false;
		#endregion

		//====================================================================================================
		//  コンストラクタ
		//====================================================================================================
		#region コンストラクタ
		/// <summary>
		/// 仕入明細列表示状況クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入明細列表示状況クラスのインスタンスを作成し、初期化します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public PtAdjustStockDtlDisplayStatus()
		{
			mDetailStatus = new ArrayList();

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            //InitializeStatus(ctCOL_RowNum);
            //// 商品コード
            //InitializeStatus(ctCOL_GoodsName);
            //// 商品名称
            //InitializeStatus(ctCOL_GoodsName);
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// メーカーコード
            //InitializeStatus(ctCOL_GoodsMakerCd);
            //// メーカー名称
            //InitializeStatus(ctCOL_MakerName);
            //// 仕入先名称
            //InitializeStatus(ctCOL_CustomerName);
            //// ＢＬ商品コード
            //InitializeStatus(ctCOL_BLGoodsCode);
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 倉庫コード
            //InitializeStatus(ctCOL_WarehouseCode);
            //// 倉庫名称
            //InitializeStatus(ctCOL_WarehouseName);
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////// 製造番号
            ////InitializeStatus(ctCOL_ProductNumber);
            ////// 携帯番号
            ////InitializeStatus(ctCOL_StockTelNo1);
            ////// 修正前製番
            ////InitializeStatus(ctCOL_BfProductNumber);
            ////// 商品状態
            ////InitializeStatus(ctCOL_GoodsCodeStatus);
            //// 棚番
            //InitializeStatus(ctCOL_WarehouseShelfNo);
            //// 修正前棚番
            //InitializeStatus(ctCOL_BfWarehouseShelfNo);
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 仕入在庫数
            //InitializeStatus(ctCOL_SupplierStock);
            //// 受託在庫数
            //InitializeStatus(ctCOL_TrustCount);
            //// 調整数
            //InitializeStatus(ctCOL_AdjustCount);
            //// 仕入単価
            //InitializeStatus(ctCOL_StockUnitPrice);
            //// 修正前仕入単価
            //InitializeStatus(ctCOL_BfStockUnitPrice);
            //// 調整金額
            //InitializeStatus(ctCOL_AdjustPrice);
            //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            //// 明細備考
            //InitializeStatus(ctCOL_DtlNote);
            //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
            //// 定価（浮動）
            //InitializeStatus(ctCOL_ListPriceFl);
            //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            // No
            InitializeStatus(ctCOL_RowNum);
            // 品番
            InitializeStatus(ctCOL_GoodsName);
            // 品名
            InitializeStatus(ctCOL_GoodsName);
            // ＢＬ商品コード
            InitializeStatus(ctCOL_BLGoodsCode);
            // メーカーコード
            InitializeStatus(ctCOL_GoodsMakerCd);
            // 仕入先
            InitializeStatus(ctCOL_SupplierCd);
            // 標準価格
            InitializeStatus(ctCOL_ListPriceFl);
            // 原単価
            InitializeStatus(ctCOL_StockUnitPrice);
            // 仕入数
            InitializeStatus(ctCOL_SalesOrderUnit);
            // 仕入後数
            InitializeStatus(ctCOL_AfSalesOrderUnit);
            // 棚番
            InitializeStatus(ctCOL_WarehouseShelfNo);
            // 発注残
            InitializeStatus(ctCOL_SalesOrderCount);
            // 在庫数(仕入在庫数)
            InitializeStatus(ctCOL_SupplierStock);
            // 明細備考
            InitializeStatus(ctCOL_DtlNote);
            
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        }
		#endregion

		//====================================================================================================
		//  パブリックプロパティ
		//====================================================================================================
		#region パブリックプロパティ
		#region [表示位置]プロパティ
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>
        ///// [表示位置]行番号
        ///// </summary>
        //public int Order_RowNum
        //{
        //    get { return GetVisiblePosition(ctCOL_RowNum); }
        //    set { SetVisiblePosition(ctCOL_RowNum, value); }
        //}
        ///// <summary>
        ///// [表示位置]商品コード
        ///// </summary>
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////public int Order_GoodsCode
        ////{
        ////	get { return GetVisiblePosition(ctCOL_GoodsCode); }
        ////	set { SetVisiblePosition(ctCOL_GoodsCode, value); }
        ////}
        //public int Order_GoodsNo
        //{
        //    get { return GetVisiblePosition(ctCOL_GoodsNo); }
        //    set { SetVisiblePosition(ctCOL_GoodsNo, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [表示位置]商品ガイド
        ///// </summary>
        //public int Order_GoodsGuide
        //{
        //    get { return GetVisiblePosition(ctCOL_GoodsGuide); }
        //    set { SetVisiblePosition(ctCOL_GoodsGuide, value); }
        //}
        ///// <summary>
        ///// [表示位置]商品名称
        ///// </summary>
        //public int Order_GoodsName
        //{
        //    get { return GetVisiblePosition(ctCOL_GoodsName); }
        //    set { SetVisiblePosition(ctCOL_GoodsName, value); }
        //}
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [表示位置]メーカーコード
        ///// </summary>
        //public int Order_GoodsMakerCd
        //{
        //    get { return GetVisiblePosition(ctCOL_GoodsMakerCd); }
        //    set { SetVisiblePosition(ctCOL_GoodsMakerCd, value); }
        //}
        ///// <summary>
        ///// [表示位置]メーカー名称
        ///// </summary>
        //public int Order_MakerName
        //{
        //    get { return GetVisiblePosition(ctCOL_MakerName); }
        //    set { SetVisiblePosition(ctCOL_MakerName, value); }
        //}
        ///// <summary>
        ///// [表示位置]仕入先名称
        ///// </summary>
        //public int Order_CustomerName
        //{
        //    get { return GetVisiblePosition(ctCOL_CustomerName); }
        //    set { SetVisiblePosition(ctCOL_CustomerName, value); }
        //}
        ///// <summary>
        ///// [表示位置]ＢＬ商品コード
        ///// </summary>
        //public int Order_BLGoodsCode
        //{
        //    get { return GetVisiblePosition(ctCOL_BLGoodsCode); }
        //    set { SetVisiblePosition(ctCOL_BLGoodsCode, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [表示位置]倉庫コード
        ///// </summary>
        //public int Order_WarehouseCode
        //{
        //    get { return GetVisiblePosition(ctCOL_WarehouseCode); }
        //    set { SetVisiblePosition(ctCOL_WarehouseCode, value); }
        //}
        ///// <summary>
        ///// [表示位置]倉庫名称
        ///// </summary>
        //public int Order_WarehouseName
        //{
        //    get { return GetVisiblePosition(ctCOL_WarehouseName); }
        //    set { SetVisiblePosition(ctCOL_WarehouseName, value); }
        //}
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>
        /////// [表示位置]製造番号
        /////// </summary>
        ////public int Order_ProductNumber
        ////{
        ////	get { return GetVisiblePosition(ctCOL_ProductNumber); }
        ////	set { SetVisiblePosition(ctCOL_ProductNumber, value); }
        ////}
        /////// <summary>
        /////// [表示位置]携帯番号
        /////// </summary>
        ////public int Order_StockTelNo1
        ////{
        ////	get { return GetVisiblePosition(ctCOL_StockTelNo1); }
        ////	set { SetVisiblePosition(ctCOL_StockTelNo1, value); }
        ////}
        /////// <summary>
        /////// [表示位置]修正前製番
        ////public int Order_BfProductNumber
        ////{
        ////    get { return GetVisiblePosition(ctCOL_BfProductNumber); }
        ////    set { SetVisiblePosition(ctCOL_BfProductNumber, value); }
        ////}
        /////// <summary>
        /////// [表示位置]商品状態
        /////// </summary>
        ////public int Order_GoodsCodeStatus
        ////{
        ////    get { return GetVisiblePosition(ctCOL_GoodsCodeStatus); }
        ////    set { SetVisiblePosition(ctCOL_GoodsCodeStatus, value); }
        ////}
        ///// <summary>
        ///// [表示位置]棚番
        ///// </summary>
        //public int Order_WarehouseShelfNo
        //{
        //    get { return GetVisiblePosition(ctCOL_WarehouseShelfNo); }
        //    set { SetVisiblePosition(ctCOL_WarehouseShelfNo, value); }
        //}
        ///// <summary>
        ///// [表示位置]修正前棚番
        ///// </summary>
        //public int Order_BfWarehouseShelfNo
        //{
        //    get { return GetVisiblePosition(ctCOL_BfWarehouseShelfNo); }
        //    set { SetVisiblePosition(ctCOL_BfWarehouseShelfNo, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [表示位置]仕入在庫数
        ///// </summary>
        //public int Order_SupplierStock
        //{
        //    get { return GetVisiblePosition(ctCOL_SupplierStock); }
        //    set { SetVisiblePosition(ctCOL_SupplierStock, value); }
        //}
        ///// <summary>
        ///// [表示位置]受託在庫数
        ///// </summary>
        //public int Order_TrustCount
        //{
        //    get { return GetVisiblePosition(ctCOL_TrustCount); }
        //    set { SetVisiblePosition(ctCOL_TrustCount, value); }
        //}
        ///// <summary>
        ///// [表示位置]調整数
        ///// </summary>
        //public int Order_AdjustCount
        //{
        //    get { return GetVisiblePosition(ctCOL_AdjustCount); }
        //    set { SetVisiblePosition(ctCOL_AdjustCount, value); }
        //}
        ///// <summary>
        ///// [表示位置]仕入単価
        ///// </summary>
        //public int Order_StockUnitPrice
        //{
        //    get { return GetVisiblePosition(ctCOL_StockUnitPrice); }
        //    set { SetVisiblePosition(ctCOL_StockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [表示位置]修正前仕入単価
        ///// </summary>
        //public int Order_BfStockUnitPrice
        //{
        //    get { return GetVisiblePosition(ctCOL_BfStockUnitPrice); }
        //    set { SetVisiblePosition(ctCOL_BfStockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [表示位置]調整金額
        ///// </summary>
        //public int Order_AdjustPrice
        //{
        //    get { return GetVisiblePosition(ctCOL_AdjustPrice); }
        //    set { SetVisiblePosition(ctCOL_AdjustPrice, value); }
        //}
        //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [表示位置]明細備考
        ///// </summary>
        //public int Order_DtlNote
        //{
        //    get { return GetVisiblePosition(ctCOL_DtlNote); }
        //    set { SetVisiblePosition(ctCOL_DtlNote, value); }
        //}
        //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [表示位置]定価（浮動）
        ///// </summary>
        //public int Order_ListPriceFl
        //{
        //    get { return GetVisiblePosition(ctCOL_ListPriceFl); }
        //    set { SetVisiblePosition(ctCOL_ListPriceFl, value); }
        //}
        //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>
        /// [表示位置]No
        /// </summary>
        public int Order_RowNum
        {
            get { return GetVisiblePosition(ctCOL_RowNum); }
            set { SetVisiblePosition(ctCOL_RowNum, value); }
        }
        /// <summary>
        /// [表示位置]品番
        /// </summary>
        public int Order_GoodsNo
        {
            get { return GetVisiblePosition(ctCOL_GoodsNo); }
            set { SetVisiblePosition(ctCOL_GoodsNo, value); }
        }
        /// <summary>
        /// [表示位置]品名
        /// </summary>
        public int Order_GoodsName
        {
            get { return GetVisiblePosition(ctCOL_GoodsName); }
            set { SetVisiblePosition(ctCOL_GoodsName, value); }
        }
        /// <summary>
        /// [表示位置]ＢＬコード
        /// </summary>
        public int Order_BLGoodsCode
        {
            get { return GetVisiblePosition(ctCOL_BLGoodsCode); }
            set { SetVisiblePosition(ctCOL_BLGoodsCode, value); }
        }
        /// <summary>
        /// [表示位置]メーカー
        /// </summary>
        public int Order_GoodsMakerCd
        {
            get { return GetVisiblePosition(ctCOL_GoodsMakerCd); }
            set { SetVisiblePosition(ctCOL_GoodsMakerCd, value); }
        }
        /// <summary>
        /// [表示位置]仕入先
        /// </summary>
        public int Order_SupplierCd
        {
            get { return GetVisiblePosition(ctCOL_SupplierCd); }
            set { SetVisiblePosition(ctCOL_SupplierCd, value); }
        }
        /// <summary>
        /// [表示位置]標準価格
        /// </summary>
        public int Order_ListPriceFl
        {
            get { return GetVisiblePosition(ctCOL_ListPriceFl); }
            set { SetVisiblePosition(ctCOL_ListPriceFl, value); }
        }
        /// <summary>
        /// [表示位置]原単価
        /// </summary>
        public int Order_StockUnitPrice
        {
            get { return GetVisiblePosition(ctCOL_StockUnitPrice); }
            set { SetVisiblePosition(ctCOL_StockUnitPrice, value); }
        }
        /// <summary>
        /// [表示位置]仕入数
        /// </summary>
        public int Order_SalesOrderUnit
        {
            get { return GetVisiblePosition(ctCOL_SalesOrderUnit); }
            set { SetVisiblePosition(ctCOL_SalesOrderUnit, value); }
        }
        /// <summary>
        /// [表示位置]仕入後数
        /// </summary>
        public int Order_AfSalesOrderUnit
        {
            get { return GetVisiblePosition(ctCOL_AfSalesOrderUnit); }
            set { SetVisiblePosition(ctCOL_AfSalesOrderUnit, value); }
        }
        /// <summary>
        /// [表示位置]棚番
        /// </summary>
        public int Order_WarehouseShelfNo
        {
            get { return GetVisiblePosition(ctCOL_WarehouseShelfNo); }
            set { SetVisiblePosition(ctCOL_WarehouseShelfNo, value); }
        }
        /// <summary>
        /// [表示位置]発注残
        /// </summary>
        public int Order_SalesOrderCount
        {
            get { return GetVisiblePosition(ctCOL_SalesOrderCount); }
            set { SetVisiblePosition(ctCOL_SalesOrderCount, value); }
        }
        /// <summary>
        /// [表示位置]在庫数(仕入在庫数)
        /// </summary>
        public int Order_SupplierStock
        {
            get { return GetVisiblePosition(ctCOL_SupplierStock); }
            set { SetVisiblePosition(ctCOL_SupplierStock, value); }
        }
        /// <summary>
        /// [表示位置]明細備考
        /// </summary>
        public int Order_DtlNote
        {
            get { return GetVisiblePosition(ctCOL_DtlNote); }
            set { SetVisiblePosition(ctCOL_DtlNote, value); }
        }
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		#region [表示]プロパティ
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>
        ///// [表示]行番号
        ///// </summary>
        //public bool Visible_RowNum
        //{
        //    get { return GetVisible(ctCOL_RowNum); }
        //    set { SetVisible(ctCOL_RowNum, value); }
        //}
        ///// <summary>
        ///// [表示]商品コード
        ///// </summary>
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////public bool Visible_GoodsCode
        ////{
        ////	get { return GetVisible(ctCOL_GoodsCode); }
        ////	set { SetVisible(ctCOL_GoodsCode, value); }
        ////}
        //public bool Visible_GoodsNo
        //{
        //    get { return GetVisible(ctCOL_GoodsNo); }
        //    set { SetVisible(ctCOL_GoodsNo, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [表示]商品ガイド
        ///// </summary>
        //public bool Visible_GoodsGuide
        //{
        //    get { return GetVisible(ctCOL_GoodsGuide); }
        //    set { SetVisible(ctCOL_GoodsGuide, value); }
        //}
        ///// <summary>
        ///// [表示]商品名称
        ///// </summary>
        //public bool Visible_GoodsName
        //{
        //    get { return GetVisible(ctCOL_GoodsName); }
        //    set { SetVisible(ctCOL_GoodsName, value); }
        //}
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [表示]メーカーコード
        ///// </summary>
        //public bool Visible_GoodsMakerCd
        //{
        //    get { return GetVisible(ctCOL_GoodsMakerCd); }
        //    set { SetVisible(ctCOL_GoodsMakerCd, value); }
        //}
        ///// <summary>
        ///// [表示]メーカー名称
        ///// </summary>
        //public bool Visible_MakerName
        //{
        //    get { return GetVisible(ctCOL_MakerName); }
        //    set { SetVisible(ctCOL_MakerName, value); }
        //}
        ///// <summary>
        ///// [表示]仕入先名称
        ///// </summary>
        //public bool Visible_CustomerName
        //{
        //    get { return GetVisible(ctCOL_CustomerName); }
        //    set { SetVisible(ctCOL_CustomerName, value); }
        //}
        ///// <summary>
        ///// [表示]ＢＬ商品コード
        ///// </summary>
        //public bool Visible_BLGoodsCode
        //{
        //    get { return GetVisible(ctCOL_BLGoodsCode); }
        //    set { SetVisible(ctCOL_BLGoodsCode, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [表示]倉庫コード
        ///// </summary>
        //public bool Visible_WarehouseCode
        //{
        //    get { return GetVisible(ctCOL_WarehouseCode); }
        //    set { SetVisible(ctCOL_WarehouseCode, value); }
        //}
        ///// <summary>
        ///// [表示]倉庫名称
        ///// </summary>
        //public bool Visible_WarehouseName
        //{
        //    get { return GetVisible(ctCOL_WarehouseName); }
        //    set { SetVisible(ctCOL_WarehouseName, value); }
        //}
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>
        /////// [表示]製造番号
        /////// </summary>
        ////public bool Visible_ProductNumber
        ////{
        ////	get { return GetVisible(ctCOL_ProductNumber); }
        ////	set { SetVisible(ctCOL_ProductNumber, value); }
        ////}
        /////// <summary>
        /////// [表示]携帯番号
        /////// </summary>
        ////public bool Visible_StockTelNo1
        ////{
        ////	get { return GetVisible(ctCOL_StockTelNo1); }
        ////	set { SetVisible(ctCOL_StockTelNo1, value); }
        ////}
        /////// <summary>
        /////// [表示]修正前製番
        /////// </summary>
        ////public bool Visible_BfProductNumber
        ////{
        ////    get { return GetVisible(ctCOL_BfProductNumber); }
        ////    set { SetVisible(ctCOL_BfProductNumber, value); }
        ////}
        /////// <summary>
        /////// [表示]商品状態
        /////// </summary>
        ////public bool Visible_GoodsCodeStatus
        ////{
        ////    get { return GetVisible(ctCOL_GoodsCodeStatus); }
        ////    set { SetVisible(ctCOL_GoodsCodeStatus, value); }
        ////}
        ///// <summary>
        ///// [表示]棚番
        ///// </summary>
        //public bool Visible_WarehouseShelfNo
        //{
        //    get { return GetVisible(ctCOL_WarehouseShelfNo); }
        //    set { SetVisible(ctCOL_WarehouseShelfNo, value); }
        //}
        ///// <summary>
        ///// [表示]修正前棚番
        ///// </summary>
        //public bool Visible_BfWarehouseShelfNo
        //{
        //    get { return GetVisible(ctCOL_BfWarehouseShelfNo); }
        //    set { SetVisible(ctCOL_BfWarehouseShelfNo, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [表示]仕入在庫数
        ///// </summary>
        //public bool Visible_SupplierStock
        //{
        //    get { return GetVisible(ctCOL_SupplierStock); }
        //    set { SetVisible(ctCOL_SupplierStock, value); }
        //}
        ///// <summary>
        ///// [表示]受託在庫数
        ///// </summary>
        //public bool Visible_TrustCount
        //{
        //    get { return GetVisible(ctCOL_TrustCount); }
        //    set { SetVisible(ctCOL_TrustCount, value); }
        //}
        ///// <summary>
        ///// [表示]調整数
        ///// </summary>
        //public bool Visible_AdjustCount
        //{
        //    get { return GetVisible(ctCOL_AdjustCount); }
        //    set { SetVisible(ctCOL_AdjustCount, value); }
        //}
        ///// <summary>
        ///// [表示]仕入単価
        ///// </summary>
        //public bool Visible_StockUnitPrice
        //{
        //    get { return GetVisible(ctCOL_StockUnitPrice); }
        //    set { SetVisible(ctCOL_StockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [表示]修正前仕入単価
        ///// </summary>
        //public bool Visible_BfStockUnitPrice
        //{
        //    get { return GetVisible(ctCOL_BfStockUnitPrice); }
        //    set { SetVisible(ctCOL_BfStockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [表示]調整金額
        ///// </summary>
        //public bool Visible_AdjustPrice
        //{
        //    get { return GetVisible(ctCOL_AdjustPrice); }
        //    set { SetVisible(ctCOL_AdjustPrice, value); }
        //}
        //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [表示]明細備考
        ///// </summary>
        //public bool Visible_DtlNote
        //{
        //    get { return GetVisible(ctCOL_DtlNote); }
        //    set { SetVisible(ctCOL_DtlNote, value); }
        //}
        //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [表示]定価（浮動）
        ///// </summary>
        //public bool Visible_ListPriceFl
        //{
        //    get { return GetVisible(ctCOL_ListPriceFl); }
        //    set { SetVisible(ctCOL_ListPriceFl, value); }
        //}
        //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>
        /// [表示]No
        /// </summary>
        public bool Visible_RowNum
        {
            get { return GetVisible(ctCOL_RowNum); }
            set { SetVisible(ctCOL_RowNum, value); }
        }
        /// <summary>
        /// [表示]品番
        /// </summary>
        public bool Visible_GoodsNo
        {
            get { return GetVisible(ctCOL_GoodsNo); }
            set { SetVisible(ctCOL_GoodsNo, value); }
        }
        /// <summary>
        /// [表示]品名
        /// </summary>
        public bool Visible_GoodsName
        {
            get { return GetVisible(ctCOL_GoodsName); }
            set { SetVisible(ctCOL_GoodsName, value); }
        }
        /// <summary>
        /// [表示]ＢＬコード
        /// </summary>
        public bool Visible_BLGoodsCode
        {
            get { return GetVisible(ctCOL_BLGoodsCode); }
            set { SetVisible(ctCOL_BLGoodsCode, value); }
        }
        /// <summary>
        /// [表示]メーカー
        /// </summary>
        public bool Visible_GoodsMakerCd
        {
            get { return GetVisible(ctCOL_GoodsMakerCd); }
            set { SetVisible(ctCOL_GoodsMakerCd, value); }
        }
        /// <summary>
        /// [表示]仕入先
        /// </summary>
        public bool Visible_SupplierCd
        {
            get { return GetVisible(ctCOL_SupplierCd); }
            set { SetVisible(ctCOL_SupplierCd, value); }
        }
        /// <summary>
        /// [表示]標準価格
        /// </summary>
        public bool Visible_ListPriceFl
        {
            get { return GetVisible(ctCOL_ListPriceFl); }
            set { SetVisible(ctCOL_ListPriceFl, value); }
        }
        /// <summary>
        /// [表示]原単価
        /// </summary>
        public bool Visible_StockUnitPrice
        {
            get { return GetVisible(ctCOL_StockUnitPrice); }
            set { SetVisible(ctCOL_StockUnitPrice, value); }
        }
        /// <summary>
        /// [表示]仕入数
        /// </summary>
        public bool Visible_SalesOrderUnit
        {
            get { return GetVisible(ctCOL_SalesOrderUnit); }
            set { SetVisible(ctCOL_SalesOrderUnit, value); }
        }
        /// <summary>
        /// [表示]仕入後数
        /// </summary>
        public bool Visible_AfSalesOrderUnit
        {
            get { return GetVisible(ctCOL_AfSalesOrderUnit); }
            set { SetVisible(ctCOL_AfSalesOrderUnit, value); }
        }
        /// <summary>
        /// [表示]棚番
        /// </summary>
        public bool Visible_WarehouseShelfNo
        {
            get { return GetVisible(ctCOL_WarehouseShelfNo); }
            set { SetVisible(ctCOL_WarehouseShelfNo, value); }
        }
        /// <summary>
        /// [表示]発注残
        /// </summary>
        public bool Visible_SalesOrderCount
        {
            get { return GetVisible(ctCOL_SalesOrderCount); }
            set { SetVisible(ctCOL_SalesOrderCount, value); }
        }
        /// <summary>
        /// [表示]在庫数(仕入在庫数)
        /// </summary>
        public bool Visible_SupplierStock
        {
            get { return GetVisible(ctCOL_SupplierStock); }
            set { SetVisible(ctCOL_SupplierStock, value); }
        }
        /// <summary>
        /// [表示]明細備考
        /// </summary>
        public bool Visible_DtlNote
        {
            get { return GetVisible(ctCOL_DtlNote); }
            set { SetVisible(ctCOL_DtlNote, value); }
        }
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		#region [列幅]プロパティ
        // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
        #region DEL 2008/07/24
        ///// <summary>
        ///// [列幅]行番号
        ///// </summary>
        //public int Width_RowNum
        //{
        //    get { return GetWidth(ctCOL_RowNum); }
        //    set { SetWidth(ctCOL_RowNum, value); }
        //}
        ///// <summary>
        ///// [列幅]商品コード
        ///// </summary>
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////public int Width_GoodsCode
        ////{
        ////	get { return GetWidth(ctCOL_GoodsCode); }
        ////	set { SetWidth(ctCOL_GoodsCode, value); }
        ////}
        //public int Width_GoodsNo
        //{
        //    get { return GetWidth(ctCOL_GoodsNo); }
        //    set { SetWidth(ctCOL_GoodsNo, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [列幅]商品ガイド
        ///// </summary>
        //public int Width_GoodsGuide
        //{
        //    get { return GetWidth(ctCOL_GoodsGuide); }
        //    set { SetWidth(ctCOL_GoodsGuide, value); }
        //}
        ///// <summary>
        ///// [列幅]商品名称
        ///// </summary>
        //public int Width_GoodsName
        //{
        //    get { return GetWidth(ctCOL_GoodsName); }
        //    set { SetWidth(ctCOL_GoodsName, value); }
        //}
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [列幅]メーカーコード
        ///// </summary>
        //public int Width_GoodsMakerCd
        //{
        //    get { return GetWidth(ctCOL_GoodsMakerCd); }
        //    set { SetWidth(ctCOL_GoodsMakerCd, value); }
        //}
        ///// <summary>
        ///// [列幅]メーカー名称
        ///// </summary>
        //public int Width_MakerName
        //{
        //    get { return GetWidth(ctCOL_MakerName); }
        //    set { SetWidth(ctCOL_MakerName, value); }
        //}
        ///// <summary>
        ///// [列幅]仕入先名称
        ///// </summary>
        //public int Width_CustomerName
        //{
        //    get { return GetWidth(ctCOL_CustomerName); }
        //    set { SetWidth(ctCOL_CustomerName, value); }
        //}
        ///// <summary>
        ///// [列幅]ＢＬ商品コード
        ///// </summary>
        //public int Width_BLGoodsCode
        //{
        //    get { return GetWidth(ctCOL_BLGoodsCode); }
        //    set { SetWidth(ctCOL_BLGoodsCode, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [列幅]倉庫コード
        ///// </summary>
        //public int Width_WarehouseCode
        //{
        //    get { return GetWidth(ctCOL_WarehouseCode); }
        //    set { SetWidth(ctCOL_WarehouseCode, value); }
        //}
        ///// <summary>
        ///// [列幅]倉庫名称
        ///// </summary>
        //public int Width_WarehouseName
        //{
        //    get { return GetWidth(ctCOL_WarehouseName); }
        //    set { SetWidth(ctCOL_WarehouseName, value); }
        //}
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>
        /////// [列幅]製造番号
        /////// </summary>
        ////public int Width_ProductNumber
        ////{
        ////	get { return GetWidth(ctCOL_ProductNumber); }
        ////	set { SetWidth(ctCOL_ProductNumber, value); }
        ////}
        /////// <summary>
        /////// [列幅]携帯番号
        /////// </summary>
        ////public int Width_StockTelNo1
        ////{
        ////	get { return GetWidth(ctCOL_StockTelNo1); }
        ////	set { SetWidth(ctCOL_StockTelNo1, value); }
        ////}
        /////// <summary>
        /////// [列幅]修正前製番
        /////// </summary>
        ////public int Width_BfProductNumber
        ////{
        ////    get { return GetWidth(ctCOL_BfProductNumber); }
        ////    set { SetWidth(ctCOL_BfProductNumber, value); }
        ////}
        /////// <summary>
        /////// [列幅]商品状態
        /////// </summary>
        ////public int Width_GoodsCodeStatus
        ////{
        ////    get { return GetWidth(ctCOL_GoodsCodeStatus); }
        ////    set { SetWidth(ctCOL_GoodsCodeStatus, value); }
        ////}
        ///// <summary>
        ///// [列幅]棚番
        ///// </summary>
        //public int Width_WarehouseShelfNo
        //{
        //    get { return GetWidth(ctCOL_WarehouseShelfNo); }
        //    set { SetWidth(ctCOL_WarehouseShelfNo, value); }
        //}
        ///// <summary>
        ///// [列幅]修正前棚番
        ///// </summary>
        //public int Width_BfWarehouseShelfNo
        //{
        //    get { return GetWidth(ctCOL_BfWarehouseShelfNo); }
        //    set { SetWidth(ctCOL_BfWarehouseShelfNo, value); }
        //}
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        ///// <summary>
        ///// [列幅]仕入在庫数
        ///// </summary>
        //public int Width_SupplierStock
        //{
        //    get { return GetWidth(ctCOL_SupplierStock); }
        //    set { SetWidth(ctCOL_SupplierStock, value); }
        //}
        ///// <summary>
        ///// [列幅]受託在庫数
        ///// </summary>
        //public int Width_TrustCount
        //{
        //    get { return GetWidth(ctCOL_TrustCount); }
        //    set { SetWidth(ctCOL_TrustCount, value); }
        //}
        ///// <summary>
        ///// [列幅]調整数
        ///// </summary>
        //public int Width_AdjustCount
        //{
        //    get { return GetWidth(ctCOL_AdjustCount); }
        //    set { SetWidth(ctCOL_AdjustCount, value); }
        //}
        ///// <summary>
        ///// [列幅]仕入単価
        ///// </summary>
        //public int Width_StockUnitPrice
        //{
        //    get { return GetWidth(ctCOL_StockUnitPrice); }
        //    set { SetWidth(ctCOL_StockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [列幅]修正前仕入単価
        ///// </summary>
        //public int Width_BfStockUnitPrice
        //{
        //    get { return GetWidth(ctCOL_BfStockUnitPrice); }
        //    set { SetWidth(ctCOL_BfStockUnitPrice, value); }
        //}
        ///// <summary>
        ///// [列幅]調整金額
        ///// </summary>
        //public int Width_AdjustPrice
        //{
        //    get { return GetWidth(ctCOL_AdjustPrice); }
        //    set { SetWidth(ctCOL_AdjustPrice, value); }
        //}
        ///// <summary>
        //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [列幅]明細備考
        ///// </summary>
        //public int Width_DtlNote
        //{
        //    get { return GetWidth(ctCOL_DtlNote); }
        //    set { SetWidth(ctCOL_DtlNote, value); }
        //}
        //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
        //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// [列幅]定価（浮動）
        ///// </summary>
        //public int Width_ListPriceFl
        //{
        //    get { return GetWidth(ctCOL_ListPriceFl); }
        //    set { SetWidth(ctCOL_ListPriceFl, value); }
        //}
        //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2008/07/24

        /// <summary>
        /// [列幅]No
        /// </summary>
        public int Width_RowNum
        {
            get { return GetWidth(ctCOL_RowNum); }
            set { SetWidth(ctCOL_RowNum, value); }
        }
        /// <summary>
        /// [列幅]品名
        /// </summary>
        public int Width_GoodsNo
        {
            get { return GetWidth(ctCOL_GoodsNo); }
            set { SetWidth(ctCOL_GoodsNo, value); }
        }
        /// <summary>
        /// [列幅]品名
        /// </summary>
        public int Width_GoodsName
        {
            get { return GetWidth(ctCOL_GoodsName); }
            set { SetWidth(ctCOL_GoodsName, value); }
        }
        /// <summary>
        /// [列幅]ＢＬコード
        /// </summary>
        public int Width_BLGoodsCode
        {
            get { return GetWidth(ctCOL_BLGoodsCode); }
            set { SetWidth(ctCOL_BLGoodsCode, value); }
        }
        /// <summary>
        /// [列幅]メーカー
        /// </summary>
        public int Width_GoodsMakerCd
        {
            get { return GetWidth(ctCOL_GoodsMakerCd); }
            set { SetWidth(ctCOL_GoodsMakerCd, value); }
        }
        /// <summary>
        /// [列幅]仕入先
        /// </summary>
        public int Width_SupplierCd
        {
            get { return GetWidth(ctCOL_SupplierCd); }
            set { SetWidth(ctCOL_SupplierCd, value); }
        }
        /// <summary>
        /// [列幅]標準価格
        /// </summary>
        public int Width_ListPriceFl
        {
            get { return GetWidth(ctCOL_ListPriceFl); }
            set { SetWidth(ctCOL_ListPriceFl, value); }
        }
        /// <summary>
        /// [列幅]原単価
        /// </summary>
        public int Width_StockUnitPrice
        {
            get { return GetWidth(ctCOL_StockUnitPrice); }
            set { SetWidth(ctCOL_StockUnitPrice, value); }
        }
        /// <summary>
        /// [列幅]仕入数
        /// </summary>
        public int Width_SalesOrderUnit
        {
            get { return GetWidth(ctCOL_SalesOrderUnit); }
            set { SetWidth(ctCOL_SalesOrderUnit, value); }
        }
        /// <summary>
        /// [列幅]仕入後数
        /// </summary>
        public int Width_AfSalesOrderUnit
        {
            get { return GetWidth(ctCOL_AfSalesOrderUnit); }
            set { SetWidth(ctCOL_AfSalesOrderUnit, value); }
        }
        /// <summary>
        /// [列幅]棚番
        /// </summary>
        public int Width_WarehouseShelfNo
        {
            get { return GetWidth(ctCOL_WarehouseShelfNo); }
            set { SetWidth(ctCOL_WarehouseShelfNo, value); }
        }
        /// <summary>
        /// [列幅]発注残
        /// </summary>
        public int Width_SalesOrderCount
        {
            get { return GetWidth(ctCOL_SalesOrderCount); }
            set { SetWidth(ctCOL_SalesOrderCount, value); }
        }
        /// <summary>
        /// [列幅]在庫数(仕入在庫数)
        /// </summary>
        public int Width_SupplierStock
        {
            get { return GetWidth(ctCOL_SupplierStock); }
            set { SetWidth(ctCOL_SupplierStock, value); }
        }
        /// <summary>
        /// <summary>
        /// [列幅]明細備考
        /// </summary>
        public int Width_DtlNote
        {
            get { return GetWidth(ctCOL_DtlNote); }
            set { SetWidth(ctCOL_DtlNote, value); }
        }
        // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
        #endregion

		/// <summary>
		/// フォントサイズ
		/// </summary>
		public int FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; }
		}

		/// <summary>
		/// 内税外税両表示
		/// </summary>
		public bool DispBothTaxway
		{
			get { return _dispBothTaxway; }
			set { _dispBothTaxway = value; }
		}
		#endregion

		//====================================================================================================
		//  パブリックメソッド
		//====================================================================================================
		#region パブリックメソッド
		/// <summary>
		/// 明細列表示ステータスデータが正しく設定してあるかをチェック
		/// </summary>
		/// <returns>true=正常,false=異常</returns>
		/// <remarks>
		/// <br>Note       : 明細列表示ステータスが正常に設定してあるかをチェックします。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public Boolean CheckDisplayStatus()
		{
			AdjustStockDtlDisplayStatus _temp;

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            //_temp = SearchDisplayStatus(ctCOL_RowNum);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 商品コード
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////_temp = SearchDisplayStatus(ctCOL_GoodsCode);
            //_temp = SearchDisplayStatus(ctCOL_GoodsNo);
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 商品ガイド
            //_temp = SearchDisplayStatus(ctCOL_GoodsGuide);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 商品名称
            //_temp = SearchDisplayStatus(ctCOL_GoodsName);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// メーカーコード
            //_temp = SearchDisplayStatus(ctCOL_GoodsMakerCd);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// メーカー名称
            //_temp = SearchDisplayStatus(ctCOL_MakerName);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 仕入先名称
            //_temp = SearchDisplayStatus(ctCOL_CustomerName);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// ＢＬ商品コード
            //_temp = SearchDisplayStatus(ctCOL_BLGoodsCode);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 倉庫コード
            //_temp = SearchDisplayStatus(ctCOL_WarehouseCode);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 倉庫名称
            //_temp = SearchDisplayStatus(ctCOL_WarehouseName);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////// 製造番号
            ////_temp = SearchDisplayStatus(ctCOL_ProductNumber);
            ////if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 携帯番号
            ////_temp = SearchDisplayStatus(ctCOL_StockTelNo1);
            ////if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            ////// 修正前製番
            ////_temp = SearchDisplayStatus(ctCOL_BfProductNumber);            
            ////if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            ////// 商品状態
            ////_temp = SearchDisplayStatus(ctCOL_GoodsCodeStatus);
            ////if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 棚番
            //_temp = SearchDisplayStatus(ctCOL_WarehouseShelfNo);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 修正前棚番
            //_temp = SearchDisplayStatus(ctCOL_BfWarehouseShelfNo);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 仕入在庫数
            //_temp = SearchDisplayStatus(ctCOL_SupplierStock);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 受託在庫数
            //_temp = SearchDisplayStatus(ctCOL_TrustCount);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 調整数
            //_temp = SearchDisplayStatus(ctCOL_AdjustCount);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 仕入単価
            //_temp = SearchDisplayStatus(ctCOL_StockUnitPrice);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 修正前仕入単価
            //_temp = SearchDisplayStatus(ctCOL_BfStockUnitPrice);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 調整金額
            //_temp = SearchDisplayStatus(ctCOL_AdjustPrice);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            //// 明細備考
            //_temp = SearchDisplayStatus(ctCOL_DtlNote);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
            //// 定価（浮動）
            //_temp = SearchDisplayStatus(ctCOL_ListPriceFl);
            //if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            string[] colKey = new string[14];
            colKey[0] = ctCOL_RowNum;               // No
            colKey[1] = ctCOL_GoodsNo;              // 品番
            colKey[2] = ctCOL_GoodsName;            // 品名
            colKey[3] = ctCOL_BLGoodsCode;          // ＢＬコード
            colKey[4] = ctCOL_GoodsMakerCd;         // メーカー
            colKey[5] = ctCOL_SupplierCd;           // 仕入先
            colKey[6] = ctCOL_ListPriceFl;          // 標準価格
            colKey[7] = ctCOL_StockUnitPrice;       // 原単価
            colKey[8] = ctCOL_SalesOrderUnit;       // 仕入数
            colKey[9] = ctCOL_AfSalesOrderUnit;    // 仕入後数
            colKey[10] = ctCOL_WarehouseShelfNo;    // 棚番
            colKey[11] = ctCOL_SalesOrderCount;     // 発注残
            colKey[12] = ctCOL_SupplierStock;       // 在庫数(仕入在庫数)
            colKey[13] = ctCOL_DtlNote;             // 明細備考

            for (int index = 0; index < colKey.Length; index++)
            {
                _temp = SearchDisplayStatus(colKey[index]);
                if ((_temp == null) || (_temp.VisiblePosition == -1)) return false;
            }
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
            return true;
		}

		/// <summary>
		/// 明細表示ステータスデータを初期値に設定する。
		/// </summary>
		/// <remarks>
		/// <br>Note       : 明細表示ステータスを初期状態にする。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public void SetDefaultValue()
		{
			AdjustStockDtlDisplayStatus _temp;

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            ////行番号
            //_temp = SearchDisplayStatus(ctCOL_RowNum); if (_temp == null) _temp = InitializeStatus(ctCOL_RowNum);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_RowNum].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_RowNum].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_RowNum].Visible;            
            //// 商品コード
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////_temp = SearchDisplayStatus(ctCOL_GoodsCode); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsCode);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsCode].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsCode].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsCode].Visible;
            //_temp = SearchDisplayStatus(ctCOL_GoodsNo); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsNo);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsNo].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsNo].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsNo].Visible;
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 商品ガイド
            //_temp = SearchDisplayStatus(ctCOL_GoodsGuide); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsGuide);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsGuide].Visible;
            //// 商品名称
            //_temp = SearchDisplayStatus(ctCOL_GoodsName); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsName);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsName].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsName].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsName].Visible;
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// メーカーコード
            //_temp = SearchDisplayStatus(ctCOL_GoodsMakerCd); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsMakerCd);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsMakerCd].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsMakerCd].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsMakerCd].Visible;
            //// メーカー名称
            //_temp = SearchDisplayStatus(ctCOL_MakerName); if (_temp == null) _temp = InitializeStatus(ctCOL_MakerName);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_MakerName].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_MakerName].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_MakerName].Visible;
            //// 仕入先名称
            //_temp = SearchDisplayStatus(ctCOL_CustomerName); if (_temp == null) _temp = InitializeStatus(ctCOL_CustomerName);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_CustomerName].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_CustomerName].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_CustomerName].Visible;
            //// ＢＬ商品コード
            //_temp = SearchDisplayStatus(ctCOL_BLGoodsCode); if (_temp == null) _temp = InitializeStatus(ctCOL_BLGoodsCode);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_BLGoodsCode].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_BLGoodsCode].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_BLGoodsCode].Visible;
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 倉庫コード
            //_temp = SearchDisplayStatus(ctCOL_WarehouseCode); if (_temp == null) _temp = InitializeStatus(ctCOL_WarehouseCode);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_WarehouseCode].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_WarehouseCode].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_WarehouseCode].Visible;
            //// 倉庫名称
            //_temp = SearchDisplayStatus(ctCOL_WarehouseName); if (_temp == null) _temp = InitializeStatus(ctCOL_WarehouseName);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_WarehouseName].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_WarehouseName].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_WarehouseName].Visible;
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////// 製造番号
            ////_temp = SearchDisplayStatus(ctCOL_ProductNumber); if (_temp == null) _temp = InitializeStatus(ctCOL_ProductNumber);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_ProductNumber].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_ProductNumber].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_ProductNumber].Visible;
            ////// 携帯番号
            ////_temp = SearchDisplayStatus(ctCOL_StockTelNo1); if (_temp == null) _temp = InitializeStatus(ctCOL_StockTelNo1);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_StockTelNo1].Visible;
            ////// 修正前製番
            ////_temp = SearchDisplayStatus(ctCOL_BfProductNumber); if (_temp == null) _temp = InitializeStatus(ctCOL_BfProductNumber);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_BfProductNumber].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_BfProductNumber].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_BfProductNumber].Visible;
            ////// 商品状態
            ////_temp = SearchDisplayStatus(ctCOL_GoodsCodeStatus); if (_temp == null) _temp = InitializeStatus(ctCOL_GoodsCodeStatus);
            ////_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_GoodsCodeStatus].VisiblePosition;
            ////_temp.Width = CT_DEFAULTSTATUS[ctINDX_GoodsCodeStatus].Width;
            ////_temp.Visible = CT_DEFAULTSTATUS[ctINDX_GoodsCodeStatus].Visible;
            //// 棚番
            //_temp = SearchDisplayStatus(ctCOL_WarehouseShelfNo); if (_temp == null) _temp = InitializeStatus(ctCOL_WarehouseShelfNo);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_WarehouseShelfNo].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_WarehouseShelfNo].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_WarehouseShelfNo].Visible;
            //// 修正前棚番
            //_temp = SearchDisplayStatus(ctCOL_BfWarehouseShelfNo); if (_temp == null) _temp = InitializeStatus(ctCOL_BfWarehouseShelfNo);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_BfWarehouseShelfNo].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_BfWarehouseShelfNo].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_BfWarehouseShelfNo].Visible;
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 仕入在庫数
            //_temp = SearchDisplayStatus(ctCOL_SupplierStock); if (_temp == null) _temp = InitializeStatus(ctCOL_SupplierStock);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_SupplierStock].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_SupplierStock].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_SupplierStock].Visible;
            //// 受託在庫数
            //_temp = SearchDisplayStatus(ctCOL_TrustCount); if (_temp == null) _temp = InitializeStatus(ctCOL_TrustCount);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_TrustCount].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_TrustCount].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_TrustCount].Visible;
            //// 調整数
            //_temp = SearchDisplayStatus(ctCOL_AdjustCount); if (_temp == null) _temp = InitializeStatus(ctCOL_AdjustCount);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_AdjustCount].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_AdjustCount].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_AdjustCount].Visible;
            //// 仕入単価
            //_temp = SearchDisplayStatus(ctCOL_StockUnitPrice); if (_temp == null) _temp = InitializeStatus(ctCOL_StockUnitPrice);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_StockUnitPrice].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_StockUnitPrice].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_StockUnitPrice].Visible;
            //// 修正前仕入単価
            //_temp = SearchDisplayStatus(ctCOL_BfStockUnitPrice); if (_temp == null) _temp = InitializeStatus(ctCOL_BfStockUnitPrice);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_BfStockUnitPrice].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_BfStockUnitPrice].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_BfStockUnitPrice].Visible;
            //// 調整金額
            //_temp = SearchDisplayStatus(ctCOL_AdjustPrice); if (_temp == null) _temp = InitializeStatus(ctCOL_AdjustPrice);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_AdjustPrice].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_AdjustPrice].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_AdjustPrice].Visible;
            //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            //// 明細備考
            //_temp = SearchDisplayStatus(ctCOL_DtlNote); if (_temp == null) _temp = InitializeStatus(ctCOL_DtlNote);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_DtlNote].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_DtlNote].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_DtlNote].Visible;
            //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
            //// 定価（浮動）
            //_temp = SearchDisplayStatus(ctCOL_ListPriceFl); if (_temp == null) _temp = InitializeStatus(ctCOL_ListPriceFl);
            //_temp.VisiblePosition = CT_DEFAULTSTATUS[ctINDX_ListPriceFl].VisiblePosition;
            //_temp.Width = CT_DEFAULTSTATUS[ctINDX_ListPriceFl].Width;
            //_temp.Visible = CT_DEFAULTSTATUS[ctINDX_ListPriceFl].Visible;
            //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            string[] colKey = new string[14];
            colKey[0] = ctCOL_RowNum;               // No
            colKey[1] = ctCOL_GoodsNo;              // 品番
            colKey[2] = ctCOL_GoodsName;            // 品名
            colKey[3] = ctCOL_BLGoodsCode;          // ＢＬコード
            colKey[4] = ctCOL_GoodsMakerCd;         // メーカー
            colKey[5] = ctCOL_SupplierCd;           // 仕入先
            colKey[6] = ctCOL_ListPriceFl;          // 標準価格
            colKey[7] = ctCOL_StockUnitPrice;       // 原単価
            colKey[8] = ctCOL_SalesOrderUnit;       // 仕入数
            colKey[9] = ctCOL_AfSalesOrderUnit;    // 仕入後数
            colKey[10] = ctCOL_WarehouseShelfNo;    // 棚番
            colKey[11] = ctCOL_SalesOrderCount;     // 発注残
            colKey[12] = ctCOL_SupplierStock;       // 在庫数(仕入在庫数)
            colKey[13] = ctCOL_DtlNote;             // 明細備考

            int[] colIndex = new int[14];
            colIndex[0] = ctINDX_RowNum;            // No
            colIndex[1] = ctINDX_GoodsNo;           // 品番
            colIndex[2] = ctINDX_GoodsName;         // 品名
            colIndex[3] = ctINDX_BLGoodsCode;       // ＢＬコード
            colIndex[4] = ctINDX_GoodsMakerCd;      // メーカー
            colIndex[5] = ctINDX_SupplierCd;        // 仕入先
            colIndex[6] = ctINDX_ListPriceFl;       // 標準価格
            colIndex[7] = ctINDX_StockUnitPrice;    // 原単価
            colIndex[8] = ctINDX_SalesOrderUnit;    // 仕入数
            colIndex[9] = ctINDX_AfSalesOrderUnit; // 仕入後数
            colIndex[10] = ctINDX_WarehouseShelfNo; // 棚番
            colIndex[11] = ctINDX_SalesOrderCount;  // 発注残
            colIndex[12] = ctINDX_SupplierStock;    // 在庫数(仕入在庫数)
            colIndex[13] = ctINDX_DtlNote;          // 明細備考

            for (int index = 0; index < colKey.Length; index++)
            {
                _temp = SearchDisplayStatus(colKey[index]); if (_temp == null) _temp = InitializeStatus(colKey[index]);
                _temp.VisiblePosition = CT_DEFAULTSTATUS[colIndex[index]].VisiblePosition;
                _temp.Width = CT_DEFAULTSTATUS[colIndex[index]].Width;
                _temp.Visible = CT_DEFAULTSTATUS[colIndex[index]].Visible;
            }
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<
            
            // フォントサイズ
			_fontSize = 11;
        }

        #region 2007.10.11 削除
        // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 明細表示ステータスデータを製番訂正に設定する。
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 明細表示ステータスを製番訂正にする。</br>
        ///// <br>Programer  : 19077 渡邉貴裕</br>
        ///// <br>Date       : 2007.03.26</br>
        ///// </remarks>
        //public void SetProductValue()
        //{
        //    AdjustStockDtlDisplayStatus _temp;
        //    _temp = ChangeStatus(ctCOL_StockTelNo1);
        //    _temp.Visible = false;
        //    // 修正前製番
        //    //_temp = SearchDisplayStatus(ctCOL_BfProductNumber); 
        //    _temp = ChangeStatus(ctCOL_BfProductNumber);
        //    _temp.Visible = true;
        //}
        // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion 2007.10.11 削除

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 明細表示ステータスデータを棚番訂正に設定する。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細表示ステータスを棚番訂正にする。</br>
        /// <br>Programer  : 980035 金沢貞義</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        public void SetShelfNoValue()
        {
            AdjustStockDtlDisplayStatus _temp;
            // 棚番
            _temp = ChangeStatus(ctCOL_WarehouseShelfNo);
            _temp.Visible = true;

            // 修正前棚番
            _temp = ChangeStatus(ctCOL_BfWarehouseShelfNo);
            _temp.Visible = true;
        }
        // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<

        // 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 明細表示ステータスデータを通常表示（調整金額表示）に設定する。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細表示ステータスを通常表示（調整金額表示）にする。</br>
        /// <br>Programer  : 980035 金沢貞義</br>
        /// <br>Date       : 2008.02.15</br>
        /// </remarks>
        public void SetAdjustPriceValue()
        {
            AdjustStockDtlDisplayStatus _temp;
            // 調整金額
            _temp = ChangeStatus(ctCOL_AdjustPrice);
            _temp.Visible = true;
        }
        // 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        /// <summary>
		/// クラスデータをシリアライズする。
		/// </summary>
		/// <param name="_filename">出力するファイル名称</param>
		/// <remarks>
		/// <br>Note       : 明細列ステータス情報をシリアライズする</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public void SerializeData(string _filename)
		{
			try
			{
				// シリアライズする前に、フォントサイズを追加しておく
				AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(ctCOL_FontSize);

				// まだ内部保持リストの中にない(間違いなくないはずです！！！)
				if (_temp == null)
				{
					_temp = new AdjustStockDtlDisplayStatus(ctCOL_FontSize, 9999, 11, false);
					mDetailStatus.Add(_temp);
				}

				// フォントサイズを幅に入れる
				_temp.Width = _fontSize;

				// シリアライズする前に、内税外税両表示を追加しておく
				_temp = SearchDisplayStatus(ctCOL_TaxDisplay);

				// まだ内部保持リストの中にない(間違いなくないはずです！！！)
				if (_temp == null)
				{
					_temp = new AdjustStockDtlDisplayStatus(ctCOL_TaxDisplay, 9999, 0, false);
					mDetailStatus.Add(_temp);
				}

				// 内税外税両表示をVisibleに入れる
				_temp.Visible = _dispBothTaxway;

				// 保持している情報をバイト配列に変換する
				AdjustStockDtlDisplayStatus[] dtlStat = (AdjustStockDtlDisplayStatus[])mDetailStatus.ToArray(typeof(AdjustStockDtlDisplayStatus));

				Broadleaf.Application.Common.UserSettingController.ByteSerializeUserSetting(dtlStat, ConstantManagement_ClientDirectory.UISettings_GridInfo + "\\" + _filename);
			}
			catch
			{
				// 何もなしとする。
			}
		}

		/// <summary>
		/// クラスデータをデシリアライズする。
		/// </summary>
		/// <param name="_filename">取得するファイル名称</param>
		/// <remarks>
		/// <br>Note       : 明細列ステータス情報をデシリアライズする</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public void DeserializeData(string _filename)
		{
			try
			{
				// 設定データをREADする
				AdjustStockDtlDisplayStatus[] dtl = Broadleaf.Application.Common.UserSettingController.ByteDeserializeUserSetting<AdjustStockDtlDisplayStatus[]>(ConstantManagement_ClientDirectory.UISettings_GridInfo + "\\" + _filename);

				// データがあった場合
				if (dtl != null)
				{
					// 一旦リストを削除
					mDetailStatus.Clear();

					foreach (AdjustStockDtlDisplayStatus wk in dtl)
					{
						mDetailStatus.Add(wk.Clone());
					}
				}

				// デシリアライズしたときに、フォントデータ・内税外税両表示は取得後リストからは削除する
				// (Gridの列ではないのでこのままあると明細画面を修正する必要があるため)
				if (mDetailStatus != null)
				{
					int[] delIndex = new int[] { -1, -1 };
					int ix = 0;

					foreach (AdjustStockDtlDisplayStatus _st in mDetailStatus)
					{
						// フォントサイズ
						if (_st.ColName == ctCOL_FontSize)
						{
							_fontSize = _st.Width;
							delIndex[0] = ix;
						}
						// 内税外税両表示
						else if (_st.ColName == ctCOL_TaxDisplay)
						{
							_dispBothTaxway = _st.Visible;
							delIndex[1] = ix;
						}

						if ((delIndex[0] != -1) && (delIndex[1] != -1)) break;
						ix++;
					}

					// リストより削除(後ろから)
					Array.Sort(delIndex);
					for (int i = delIndex.Length -1; i >= 0; i--)
					{
						if (delIndex[i] != -1)
						{
							mDetailStatus.RemoveAt(delIndex[i]);
						}
					}
				}
			}
			catch
			{
				// 何もなしとする。
			}
		}

		/// <summary>
		/// 表示順に並び替えられたカラム名称リストを取得します。
		/// </summary>
		/// <returns>表示順のカラム名称リスト</returns>
		/// <remarks>
		/// <br>Note       : 明細列表示ステータスを表示順に並び替え、そのカラム名称リストを取得します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public ArrayList GetVisiblePositionList()
		{
			mDetailStatus.Sort(new VisibleCompare());

			ArrayList _retList = new ArrayList();
			for (int i = 0; i < mDetailStatus.Count; i++)
			{
				_retList.Add(((AdjustStockDtlDisplayStatus)mDetailStatus[i]).ColName);
			}
			return _retList;
		}

		/// <summary>
		/// 明細表示列ステータス比較
		/// </summary>
		/// <remarks>
		/// <br>Note       : 明細表示列を表示順に並び替えます。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		internal class VisibleCompare : System.Collections.IComparer
		{
			#region IComparer メンバ
			/// <summary>
			/// 並び替え処理部
			/// </summary>
			/// <param name="x">第一比較オブジェクト</param>
			/// <param name="y">第二比較オブジェクト</param>
			/// <returns>0未満:ｘ＜ｙ,0:ｘ＝ｙ,0より大:x＞ｙ</returns>
			/// <remarks>
			/// <br>Note       : オブジェクト同士を比較します。</br>
			/// <br>Programer  : 19077 渡邉貴裕</br>
			/// <br>Date       : 2007.03.26</br>
			/// </remarks>
			public int Compare(object x, object y)
			{
				if ((x is AdjustStockDtlDisplayStatus) && (y is AdjustStockDtlDisplayStatus))
				{
					return ((AdjustStockDtlDisplayStatus)x).VisiblePosition - ((AdjustStockDtlDisplayStatus)y).VisiblePosition;
				}

				return 0;
			}

			#endregion
		}
		#endregion

		//====================================================================================================
		//  プライベートメソッド
		//====================================================================================================
		#region プライベートメソッド
		/// <summary>
		/// 明細列表示ステータス検索
		/// </summary>
		/// <param name="_key">カラム名称</param>
		/// <returns>発見した明細列表示ステータス</returns>
		/// <remarks>
		/// <br>Note       : 明細列表示ステータスを検索します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private AdjustStockDtlDisplayStatus SearchDisplayStatus(string _key)
		{
			if (mDetailStatus != null)
			{
				foreach (AdjustStockDtlDisplayStatus _st in mDetailStatus)
				{
					if (_st.ColName == _key)
					{
						return _st;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// 指定された明細列の表示状況ステータスを初期化します。
		/// </summary>
		/// <param name="_key">初期化する列名</param>
		/// <remarks>
		/// <br>Note       : 指定された明細表示列の表示状況ステータスを初期化します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private AdjustStockDtlDisplayStatus InitializeStatus(string _key)
		{
			int _index = -1;

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            //if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }
            //// 商品コード
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////else if (_key == ctCOL_GoodsCode) { _index = ctINDX_GoodsCode; }
            //else if (_key == ctCOL_GoodsNo) { _index = ctINDX_GoodsNo; }
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 商品ガイド
            //else if (_key == ctCOL_GoodsGuide) { _index = ctINDX_GoodsGuide; }
            //// 商品名称
            //else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }
            //// 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
            //// 倉庫棚番
            //else if (_key == ctCOL_WarehouseShelfNo) { _index = ctINDX_WarehouseShelfNo; }
            //// 修正前倉庫棚番
            //else if (_key == ctCOL_BfWarehouseShelfNo) { _index = ctINDX_BfWarehouseShelfNo; }
            //// 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////// 製造番号
            ////else if (_key == ctCOL_ProductNumber) { _index = ctINDX_ProductNumber; }
            ////// 携帯番号
            ////else if (_key == ctCOL_StockTelNo1) { _index = ctINDX_StockTelNo1; }
            ////// 修正前製番
            ////else if (_key == ctCOL_BfProductNumber) { _index = ctINDX_BfProductNumber; }
            ////// 商品状態
            ////else if (_key == ctCOL_GoodsCodeStatus) { _index = ctINDX_GoodsCodeStatus; }
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 仕入在庫数
            //else if (_key == ctCOL_SupplierStock) { _index = ctINDX_SupplierStock; }
            //// 受託在庫数
            //else if (_key == ctCOL_TrustCount) { _index = ctINDX_TrustCount; }
            //// 調整数
            //else if (_key == ctCOL_AdjustCount) { _index = ctINDX_AdjustCount; }
            //// 仕入単価
            //else if (_key == ctCOL_StockUnitPrice) { _index = ctINDX_StockUnitPrice; }
            //// 修正前仕入単価
            //else if (_key == ctCOL_BfStockUnitPrice) { _index = ctINDX_BfStockUnitPrice; }
            //// 調整金額
            //else if (_key == ctCOL_AdjustPrice) { _index = ctINDX_AdjustPrice; }
            //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            //// 明細備考
            //else if (_key == ctCOL_DtlNote) { _index = ctINDX_DtlNote; }
            //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
            //// 定価（浮動）
            //else if (_key == ctCOL_ListPriceFl) { _index = ctINDX_ListPriceFl; }
            //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }                               // No
            else if (_key == ctCOL_GoodsNo) { _index = ctINDX_GoodsNo; }                        // 品番
            else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }                    // 品名
            else if (_key == ctCOL_BLGoodsCode) { _index = ctINDX_BLGoodsCode; }                // BLコード
            else if (_key == ctCOL_GoodsMakerCd) { _index = ctINDX_GoodsMakerCd; }              // メーカー
            else if (_key == ctCOL_SupplierCd) { _index = ctINDX_SupplierCd; }                  // 仕入先
            else if (_key == ctCOL_ListPriceFl) { _index = ctINDX_ListPriceFl; }                // 標準価格
            else if (_key == ctCOL_StockUnitPrice) { _index = ctINDX_StockUnitPrice; }          // 原単価
            else if (_key == ctCOL_SalesOrderUnit) { _index = ctINDX_SalesOrderUnit; }          // 仕入数
            else if (_key == ctCOL_AfSalesOrderUnit) { _index = ctINDX_AfSalesOrderUnit; }      // 仕入後数
            else if (_key == ctCOL_WarehouseShelfNo) { _index = ctINDX_WarehouseShelfNo; }      // 棚番
            else if (_key == ctCOL_SalesOrderCount) { _index = ctINDX_SalesOrderCount; }        // 発注残
            else if (_key == ctCOL_SupplierStock) { _index = ctINDX_SupplierStock; }            // 在庫数(仕入在庫数)
            else if (_key == ctCOL_DtlNote) { _index = ctINDX_DtlNote; }                        // 明細備考
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

			int _width = 0;
			Boolean _visible = false;

			if (_index != -1)
			{
				_width = CT_DEFAULTSTATUS[_index].Width;
				_visible = CT_DEFAULTSTATUS[_index].Visible;
                _visible = CT_CHANGESTATUS[_index].Visible;
			}

			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			if (_temp == null)
			{
				_temp = new AdjustStockDtlDisplayStatus(_key, -1, _width, _visible);
				mDetailStatus.Add(_temp);
			}
			else
			{
				_temp.Width = _width;
				_temp.Visible = _visible;
				_temp.VisiblePosition = -1;                

			}
			return _temp;
		}

        /// <summary>
        /// 指定された明細列の表示状況ステータスを変更します。
        /// </summary>
        /// <param name="_key">変更する列名</param>
        /// <remarks>
        /// <br>Note       : 指定された明細表示列の表示状況ステータスを変更します。</br>
        /// <br>Programer  : 19077 渡邉貴裕</br>
        /// <br>Date       : 2007.03.26</br>
        /// </remarks>
        private AdjustStockDtlDisplayStatus ChangeStatus(string _key)
        {
            int _index = -1;

            // --- CHG 2008/07/24 --------------------------------------------------------------------->>>>>
            #region DEL 2008/07/24
            //if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }
            //// 商品コード
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////else if (_key == ctCOL_GoodsCode) { _index = ctINDX_GoodsCode; }
            //else if (_key == ctCOL_GoodsNo) { _index = ctINDX_GoodsNo; }
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 商品名称
            //else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }
            //// 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
            //// 倉庫棚番
            //else if (_key == ctCOL_WarehouseShelfNo) { _index = ctINDX_WarehouseShelfNo; }
            //// 修正前倉庫棚番
            //else if (_key == ctCOL_BfWarehouseShelfNo) { _index = ctINDX_BfWarehouseShelfNo; }
            //// 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////// 製造番号
            ////else if (_key == ctCOL_ProductNumber) { _index = ctINDX_ProductNumber; }
            ////// 携帯番号
            ////else if (_key == ctCOL_StockTelNo1) { _index = ctINDX_StockTelNo1; }
            ////// 修正前製番
            ////else if (_key == ctCOL_BfProductNumber) { _index = ctINDX_BfProductNumber; }
            ////// 商品状態
            ////else if (_key == ctCOL_GoodsCodeStatus) { _index = ctINDX_GoodsCodeStatus; }
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 仕入在庫数
            //else if (_key == ctCOL_SupplierStock) { _index = ctINDX_SupplierStock; }
            //// 受託在庫数
            //else if (_key == ctCOL_TrustCount) { _index = ctINDX_TrustCount; }
            //// 調整数
            //else if (_key == ctCOL_AdjustCount) { _index = ctINDX_AdjustCount; }
            //// 仕入単価
            //else if (_key == ctCOL_StockUnitPrice) { _index = ctINDX_StockUnitPrice; }
            //// 修正前仕入単価
            //else if (_key == ctCOL_BfStockUnitPrice) { _index = ctINDX_BfStockUnitPrice; }
            //// 調整金額
            //else if (_key == ctCOL_AdjustPrice) { _index = ctINDX_AdjustPrice; }
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 修正前製番
            ////else if (_key == ctCOL_BfProductNumber) { _index = ctINDX_BfProductNumber; }
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //// 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            //// 明細備考
            //else if (_key == ctCOL_DtlNote) { _index = ctINDX_DtlNote; }
            //// 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            //// 2008.02.15 追加 >>>>>>>>>>>>>>>>>>>>
            //// 定価（浮動）
            //else if (_key == ctCOL_ListPriceFl) { _index = ctINDX_ListPriceFl; }
            //// 2008.02.15 追加 <<<<<<<<<<<<<<<<<<<<
            #endregion DEL 2008/07/24

            if (_key == ctCOL_RowNum) { _index = ctINDX_RowNum; }                               // No
            else if (_key == ctCOL_GoodsNo) { _index = ctINDX_GoodsNo; }                        // 品番
            else if (_key == ctCOL_GoodsName) { _index = ctINDX_GoodsName; }                    // 品名
            else if (_key == ctCOL_BLGoodsCode) { _index = ctINDX_BLGoodsCode; }                // BLコード
            else if (_key == ctCOL_GoodsMakerCd) { _index = ctINDX_GoodsMakerCd; }              // メーカー
            else if (_key == ctCOL_SupplierCd) { _index = ctINDX_SupplierCd; }                  // 仕入先
            else if (_key == ctCOL_ListPriceFl) { _index = ctINDX_ListPriceFl; }                // 標準価格
            else if (_key == ctCOL_StockUnitPrice) { _index = ctINDX_StockUnitPrice; }          // 原単価
            else if (_key == ctCOL_SalesOrderUnit) { _index = ctINDX_SalesOrderUnit; }          // 仕入数
            else if (_key == ctCOL_AfSalesOrderUnit) { _index = ctINDX_AfSalesOrderUnit; }      // 仕入後数
            else if (_key == ctCOL_WarehouseShelfNo) { _index = ctINDX_WarehouseShelfNo; }      // 棚番
            else if (_key == ctCOL_SalesOrderCount) { _index = ctINDX_SalesOrderCount; }        // 発注残
            else if (_key == ctCOL_SupplierStock) { _index = ctINDX_SupplierStock; }            // 在庫数(仕入在庫数)
            else if (_key == ctCOL_DtlNote) { _index = ctINDX_DtlNote; }                        // 明細備考
            // --- CHG 2008/07/24 ---------------------------------------------------------------------<<<<<

            int _width = 0;
            Boolean _visible = false;

            if (_index != -1)
            {
                _width = CT_DEFAULTSTATUS[_index].Width;
                _visible = CT_DEFAULTSTATUS[_index].Visible;
            }

            AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
            if (_temp == null)
            {
                _temp = new AdjustStockDtlDisplayStatus(_key, -1, _width, _visible);
                mDetailStatus.Add(_temp);
            }
            else
            {
                _temp.Width = _width;
                _temp.Visible = _visible;
                _temp.VisiblePosition = -1;
            }
            return _temp;
        }


		/// <summary>
		/// 指定された列の表示ステータスを取得する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <returns>true=表示,false=非表示</returns>
		/// <remarks>
		/// <br>Note       : 列の表示ステータス取得</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private Boolean GetVisible(string _key)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);

			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を戻す。
			return _temp.Visible;
		}

		/// <summary>
		/// 指定された列の表示ステータスを設定する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <param name="_value">true=表示,false=非表示</param>
		/// <remarks>
		/// <br>Note       : 列の表示ステータス設定</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SetVisible(string _key, Boolean _value)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を設定する。
			_temp.Visible = _value;
		}

		/// <summary>
		/// 指定された列の列幅を取得する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <returns>取得した列幅</returns>
		/// <remarks>
		/// <br>Note       : 列の列幅取得</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private int GetWidth(string _key)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を戻す。
			return _temp.Width;
		}

		/// <summary>
		/// 指定された列の列幅を設定する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <param name="_width">列幅</param>
		/// <remarks>
		/// <br>Note       : 列の列幅設定</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SetWidth(string _key, int _width)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を設定する。
			_temp.Width = _width;
		}

		/// <summary>
		/// 指定された列の表示位置を取得する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <returns>取得した列位置</returns>
		/// <remarks>
		/// <br>Note       : 列の列位置取得</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private int GetVisiblePosition(string _key)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を戻す。
			return _temp.VisiblePosition;
		}

		/// <summary>
		/// 指定された列の表示位置を設定する。
		/// </summary>
		/// <param name="_key">対象列キー</param>
		/// <param name="_position">表示位置</param>
		/// <remarks>
		/// <br>Note       : 列の表示位置設定</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SetVisiblePosition(string _key, int _position)
		{
			AdjustStockDtlDisplayStatus _temp = SearchDisplayStatus(_key);
			// 初期化されていない？
			if (_temp == null)
			{
				// ステータスを初期化する。
				_temp = InitializeStatus(_key);
			}
			// 指定された値を設定する。
			_temp.VisiblePosition = _position;
		}
		#endregion
	}

	/// <summary>
	/// 明細表示状況クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 伝票明細の表示状況を示すクラス</br>
	/// <br>Programer  : 19077 渡邉貴裕</br>
	/// <br>Date       : 2007.03.26</br>
	/// </remarks>
	[Serializable]
	public class AdjustStockDtlDisplayStatus : ICloneable
	{
		#region コンストラクタ
		/// <summary>
		/// 明細表示状況クラスコンストラクタ
		/// </summary>
		public AdjustStockDtlDisplayStatus()
		{ }

		/// <summary>
		/// 明細表示状況クラスコンストラクタ
		/// </summary>
		/// <param name="_colName">カラム名称</param>
		/// <param name="_position">表示位置</param>
		/// <param name="_width">列幅</param>
		/// <param name="_visible">表示／非表示</param>
		/// <remarks>
		/// <br>Note       : 明細表示状況クラスのインスタンスを作成し、初期化します。</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public AdjustStockDtlDisplayStatus(string _colName, int _position, int _width, Boolean _visible)
		{
			mColName = _colName;
			mOrder = _position;
			mWidth = _width;
			mVisible = _visible;
		}
		#endregion

		#region	プライベート変数
		/// <summary>
		/// 表示位置
		/// </summary>
		private int mOrder = -1;
		/// <summary>
		/// 列幅
		/// </summary>
		private int mWidth = -1;
		/// <summary>
		/// 表示/非表示
		/// </summary>
		private Boolean mVisible = false;
		/// <summary>
		/// カラム名称
		/// </summary>
		private string mColName = "";
		#endregion

		#region パブリックプロパティ
		/// <summary>
		/// 表示位置
		/// </summary>
		public int VisiblePosition
		{
			get { return this.mOrder; }
			set { this.mOrder = value; }
		}
		/// <summary>
		/// 列幅
		/// </summary>
		public int Width
		{
			get { return this.mWidth; }
			set { this.mWidth = value; }
		}
		/// <summary>
		/// 表示／非表示
		/// </summary>
		public Boolean Visible
		{
			get { return this.mVisible; }
			set { this.mVisible = value; }
		}
		/// <summary>
		/// カラム名称
		/// </summary>
		public string ColName
		{
			get { return this.mColName; }
			set { this.mColName = value; }
		}
		#endregion

		#region ICloneable メンバ
		/// <summary>
		/// 本クラスのコピー処理
		/// </summary>
		/// <returns>このクラスのクローン</returns>
		/// <remarks>
		/// <br>Note       : クラスのクローン処理</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public object Clone()
		{
			return new AdjustStockDtlDisplayStatus(this.mColName, this.mOrder, this.mWidth, this.mVisible); ;
		}
		#endregion
	}
}
