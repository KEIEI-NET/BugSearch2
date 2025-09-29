using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

// ジェネリックに対する別名定義
using SlipDtlColumnStateList =
	System.Collections.Generic.Dictionary<string, Broadleaf.Windows.Forms.ControlSlipDtlColumnState.AdjustStockColumnState>;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 伝票明細列状態管理クラス
	/// </summary>
	internal class ControlSlipDtlColumnState
	{
		#region Private Members
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>通常入力列状態リスト</summary>
		private static Dictionary<int, SlipDtlColumnStateList> normalInputList = null;
		/// <summary>在庫オプション入力列状態リスト</summary>
		private static Dictionary<int, SlipDtlColumnStateList> stockOptionInputList = null;
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        private static SlipDtlColumnStateList _slipDtlColumnStateList;
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        //GRID項目編集形態
		private const int ctKEY_None = 0;					// 仕入原価調整
        // 2008.01.17 修正 >>>>>>>>>>>>>>>>>>>>
        //private const int ctKEY_Trust = 1;
        //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        ////private const int ctKEY_Product = 2;       			// 製番変更
        ////private const int ctKEY_ErrorGoods = 3;				// 不良品
        ////private const int ctKEY_Stock_PriceExc = 4;			// 原価調整
        //private const int ctKEY_Stock_PriceExc = 2;			// 原価調整
        //private const int ctKEY_ShelfNo = 3;				// 棚番変更
        //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
        private const int ctKEY_Stock_PriceExc = 1;			// 原価調整
        private const int ctKEY_ShelfNo = 2;				// 棚番変更
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        // 2008.01.17 修正 <<<<<<<<<<<<<<<<<<<<

		#endregion

		#region Constructor
		/// <summary>
		/// スタティックコンストラクタ
		/// </summary>
		static ControlSlipDtlColumnState()
		{
			// 通常入力時状態リスト作成
			CreateNormalList();

            /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
			// 在庫オプション時状態リスト作成
			CreateStockOptionList();
               --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        }

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		private ControlSlipDtlColumnState()
		{
		}
		#endregion

		#region Public Methods

        /// <summary>
        /// 列状態リスト取得処理[行番号指定版]
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 列状態リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public static SlipDtlColumnStateList GetSlipDtlColumnState(int rowIndex)
        {
            return GetProductStockColumnStateListProc(AdjustStockAcs.AdjustStockView[rowIndex].Row);
        }

        /// <summary>
        /// 列状態リスト取得処理[データ行指定版]
        /// </summary>
        /// <param name="dataRow">データ列</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 列状態リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        public static SlipDtlColumnStateList GetSlipDtlColumnState(DataRow dataRow)
        {
            return GetProductStockColumnStateListProc(dataRow);
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 列状態リスト取得処理[行番号指定版]
		/// </summary>
		/// <param name="rowIndex"></param>
		/// <returns></returns>
		public static SlipDtlColumnStateList GetSlipDtlColumnState(int rowIndex,int mode)
		{
			return GetProductStockColumnStateListProc(AdjustStockAcs.AdjustStockView[rowIndex].Row,mode);
		}


		/// <summary>
		/// 列状態リスト取得処理[データ行指定版]
		/// </summary>
		/// <param name="dataRow"></param>
		/// <returns></returns>
		public static SlipDtlColumnStateList GetSlipDtlColumnState(DataRow dataRow,int mode)
		{
			return GetProductStockColumnStateListProc(dataRow,mode);
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// 列状態リスト取得処理
        /// </summary>
        /// <param name="srcRow">データ列</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 列状態リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private static SlipDtlColumnStateList GetProductStockColumnStateListProc(DataRow srcRow)
        {
            return _slipDtlColumnStateList;
        }

        #region DEL 2008/07/24 Partsman用に変更
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 列状態リスト取得処理
		/// </summary>
		/// <returns></returns>
		private static SlipDtlColumnStateList GetProductStockColumnStateListProc(DataRow srcRow,int mode)
		{
//			SlipDtlColumnStateList retList = normalInputList[ctKEY_None];
			SlipDtlColumnStateList retList = normalInputList[mode];

  //          SlipDtlColumnStateList retList = normalInputList[selectMode];
            
			return retList;
        }
        
        /// <summary>
        /// 通常入力列状態リスト作成処理
        /// </summary>
        private static void CreateNormalList()
        {
            normalInputList = new Dictionary<int, Dictionary<string, AdjustStockColumnState>>();
            SlipDtlColumnStateList wkDic;

            //-- 在庫調整 --//商品コード・ガイド・調整数			ReadOnly, Enable, Visible
            #region
            wkDic = new SlipDtlColumnStateList();
            wkDic.Add(
                AdjustStockAcs.ctCOL_RowNum,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); // No
            wkDic.Add(
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //AdjustStockAcs.ctCOL_GoodsCode,
                //new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black)); // 商品コード
                AdjustStockAcs.ctCOL_GoodsNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black)); // 商品コード
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsGuide,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //商品ガイド
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black)); // 商品名称
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsMakerCd,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black)); // メーカーコード
            wkDic.Add(
                AdjustStockAcs.ctCOL_MakerName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_MakerName, false, false, true, Color.Black)); // メーカー名称
            wkDic.Add(
                AdjustStockAcs.ctCOL_BLGoodsCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black)); // ＢＬ商品コード
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black)); //倉庫コード
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black));
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //	AdjustStockAcs.ctCOL_ProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, false, true, Color.Black)); // 製番
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black)); //変更前製番
            //wkDic.Add(
            //	AdjustStockAcs.ctCOL_StockTelNo1,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black)); // 携帯番号
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, false, true, Color.Black)); //棚番
            wkDic.Add(
                AdjustStockAcs.ctCOL_BfWarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfWarehouseShelfNo, false, false, false, Color.Black)); //修正前棚番
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_SupplierStock,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black)); // 在庫数
            wkDic.Add(
                AdjustStockAcs.ctCOL_TrustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black)); // 受託数
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, true, true, Color.Black)); // 調整数
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, false, false, Color.Black)); // 在庫状態
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_StockUnitPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black)); // 仕入単価
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black)); // 調整金額
            // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_DtlNote,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_DtlNote, false, true, true, Color.Black)); // 明細備考
            // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_ListPriceFl,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_ListPriceFl, false, false, false, Color.Black)); // 定価（浮動）
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
            normalInputList.Add(ctKEY_None, wkDic);
            #endregion

            // 2008.01.17 削除 >>>>>>>>>>>>>>>>>>>>
            #region 受託調整
            //wkDic = new SlipDtlColumnStateList();
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_RowNum,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); // No
            //wkDic.Add(
            //    // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //    //AdjustStockAcs.ctCOL_GoodsCode,
            //    //new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black)); // 商品コード
            //    AdjustStockAcs.ctCOL_GoodsNo,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black)); // 商品コード
            //    // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsGuide,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //商品ガイド
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black)); // 商品名称
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsMakerCd,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black)); // メーカーコード
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_MakerName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_MakerName, false, false, true, Color.Black)); // メーカー名称
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_CustomerName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_CustomerName, false, false, false, Color.Black)); // 仕入先名称
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BLGoodsCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black)); // ＢＬ商品コード
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black)); //倉庫コード
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black)); //倉庫名称
            //// 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            ////wkDic.Add(
            ////    AdjustStockAcs.ctCOL_ProductNumber,
            ////    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, false, true, Color.Black)); // 製番
            ////wkDic.Add(
            ////    AdjustStockAcs.ctCOL_BfProductNumber,
            ////    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black)); //変更前製番
            ////wkDic.Add(
            ////    AdjustStockAcs.ctCOL_StockTelNo1,
            ////    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black)); // 携帯番号
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseShelfNo,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, false, true, Color.Black)); //棚番
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfWarehouseShelfNo,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfWarehouseShelfNo, false, false, false, Color.Black)); //修正前棚番
            //// 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_SupplierStock,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black)); // 在庫数
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_TrustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black)); // 受託数
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, true, true, Color.Black)); // 調整数
            //// 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            ////wkDic.Add(
            ////    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            ////    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, false, false, Color.Black)); // 在庫状態
            //// 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockUnitPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black)); // 仕入単価
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black)); // 調整金額
            //normalInputList.Add(ctKEY_Trust, wkDic);
            #endregion
            // 2008.01.17 削除 <<<<<<<<<<<<<<<<<<<<


            //--製番変更--// 商品コード・商品ガイド・製造番号
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            #region 製番変更
            //wkDic = new SlipDtlColumnStateList();
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_RowNum,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black));	// No
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black));	// 商品コード
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsGuide,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //商品ガイド
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black));		// 商品名称
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_ProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, true, true, Color.Black));	// 製番
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black));
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black));
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black));//変更前製番
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockTelNo1,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black));			// 携帯番号
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_SupplierStock,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black));				// 在庫数
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_TrustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black));          // 受託数
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, false, true, Color.Black));			// 調整数
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, false, false, Color.Black));         // 在庫状態
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockUnitPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black));		// 仕入単価
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black));			// 調整金額
            //normalInputList.Add(ctKEY_Product, wkDic);
            #endregion
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            //--不良品--// 商品コード・商品ガイド・商品状態
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            #region 不良品
            //wkDic = new SlipDtlColumnStateList();
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_RowNum,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black));	// No
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black));	// 商品コード
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsGuide,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //商品ガイド
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black));		// 商品名称
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseCode,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black));
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_WarehouseName,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black));
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_ProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, false, true, Color.Black));	// 製番
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black));//変更前製番
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockTelNo1,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black));			// 携帯番号
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_SupplierStock,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black));				// 在庫数
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_TrustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black));          // 受託数
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustCount,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, false, true, Color.Black));			// 調整数
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, true, true, Color.Black));         // 在庫状態
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockUnitPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black));		// 仕入単価
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_AdjustPrice,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black));			// 調整金額
            //normalInputList.Add(ctKEY_ErrorGoods, wkDic);
            #endregion
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<

            //--原価調整--// 商品コード・商品ガイド・仕入単価
            #region 原価調整
            wkDic = new SlipDtlColumnStateList();
            wkDic.Add(
                AdjustStockAcs.ctCOL_RowNum,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); // No
            wkDic.Add(
                // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
                //AdjustStockAcs.ctCOL_GoodsCode,
                //new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCode, false, true, true, Color.Black)); // 商品コード
                AdjustStockAcs.ctCOL_GoodsNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black)); // 商品コード
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsGuide,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); //商品ガイド
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black)); // 商品名称
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsMakerCd,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black)); // メーカーコード
            wkDic.Add(
                AdjustStockAcs.ctCOL_MakerName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_MakerName, false, false, true, Color.Black)); // メーカー名称
            wkDic.Add(
                AdjustStockAcs.ctCOL_BLGoodsCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black)); // ＢＬ商品コード
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, false, Color.Black));
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black));
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_ProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_ProductNumber, false, false, true, Color.Black));	// 製番
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_BfProductNumber,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfProductNumber, false, false, false, Color.Black)); //変更前製番
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_StockTelNo1,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockTelNo1, false, false, true, Color.Black)); // 携帯番号
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, false, true, Color.Black)); //棚番
            wkDic.Add(
                AdjustStockAcs.ctCOL_BfWarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfWarehouseShelfNo, false, false, false, Color.Black)); //修正前棚番
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_SupplierStock,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black)); // 在庫数
            wkDic.Add(
                AdjustStockAcs.ctCOL_TrustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black)); // 受託数
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, false, true, Color.Black));	// 調整数
            // 2007.10.11 削除 >>>>>>>>>>>>>>>>>>>>
            //wkDic.Add(
            //    AdjustStockAcs.ctCOL_GoodsCodeStatus,
            //    new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsCodeStatus, false, false, false, Color.Black)); // 在庫状態
            // 2007.10.11 削除 <<<<<<<<<<<<<<<<<<<<
            wkDic.Add(
                AdjustStockAcs.ctCOL_StockUnitPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, true, true, Color.Black)); // 仕入単価
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black)); // 調整金額
            // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_DtlNote,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_DtlNote, false, true, true, Color.Black)); // 明細備考
            // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_ListPriceFl,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_ListPriceFl, false, false, false, Color.Black)); // 定価（浮動）
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
            normalInputList.Add(ctKEY_Stock_PriceExc, wkDic);
            #endregion

            // 2007.10.11 追加 >>>>>>>>>>>>>>>>>>>>
            //--棚番変更--// 商品コード・商品ガイド・棚番
            #region 棚番変更
            wkDic = new SlipDtlColumnStateList();
            wkDic.Add(
                AdjustStockAcs.ctCOL_RowNum,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); // No
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black)); // 商品コード
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsGuide,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsGuide, false, true, true, Color.Black)); // 商品ガイド
            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black)); // 商品名称

            wkDic.Add(
                AdjustStockAcs.ctCOL_GoodsMakerCd,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black)); // メーカーコード
            wkDic.Add(
                AdjustStockAcs.ctCOL_MakerName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_MakerName, false, false, true, Color.Black)); // メーカー名称
            wkDic.Add(
                AdjustStockAcs.ctCOL_BLGoodsCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black)); // ＢＬ商品コード

            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseCode,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseCode, false, false, true, Color.Black)); //倉庫コード
            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseName,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseName, false, false, true, Color.Black)); //倉庫名称

            wkDic.Add(
                AdjustStockAcs.ctCOL_WarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, true, true, Color.Black)); //棚番
            wkDic.Add(
                AdjustStockAcs.ctCOL_BfWarehouseShelfNo,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_BfWarehouseShelfNo, false, false, true, Color.Black)); //修正前棚番

            wkDic.Add(
                AdjustStockAcs.ctCOL_SupplierStock,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black)); // 在庫数
            wkDic.Add(
                AdjustStockAcs.ctCOL_TrustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_TrustCount, false, false, true, Color.Black)); // 受託数
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustCount,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustCount, false, false, true, Color.Black));	// 調整数
            wkDic.Add(
                AdjustStockAcs.ctCOL_StockUnitPrice,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, false, true, Color.Black)); // 仕入単価
            wkDic.Add(
                AdjustStockAcs.ctCOL_AdjustPrice,
                // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
                //new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, true, Color.Black));	// 調整金額
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_AdjustPrice, false, false, false, Color.Black));	// 調整金額
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.17 追加 >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_DtlNote,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_DtlNote, false, true, true, Color.Black)); // 明細備考
            // 2008.01.17 追加 <<<<<<<<<<<<<<<<<<<<
            // 2008.02.15 修正 >>>>>>>>>>>>>>>>>>>>
            wkDic.Add(
                AdjustStockAcs.ctCOL_ListPriceFl,
                new AdjustStockColumnState(AdjustStockAcs.ctCOL_ListPriceFl, false, false, false, Color.Black)); // 定価（浮動）
            // 2008.02.15 修正 <<<<<<<<<<<<<<<<<<<<
            normalInputList.Add(ctKEY_ShelfNo, wkDic);
            #endregion
            // 2007.10.11 追加 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 Partsman用に変更

        // --- ADD 2008/07/24 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 通常入力列状態リスト作成処理
		/// </summary>
        /// <remarks>
        /// <br>Note       : 通常入力列状態リストを作成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private static void CreateNormalList()
        {
            _slipDtlColumnStateList = new SlipDtlColumnStateList();

            // No
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_RowNum,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_RowNum, false, false, true, Color.Black)); 
            // 品番
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_GoodsNo,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsNo, false, true, true, Color.Black));
            // 品名
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_GoodsName,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsName, false, false, true, Color.Black));
            // BLコード
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_BLGoodsCode,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_BLGoodsCode, false, false, true, Color.Black));
            // メーカー
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_GoodsMakerCd,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_GoodsMakerCd, false, false, true, Color.Black));
            // 仕入先
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_SupplierCd,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierCd, false, false, true, Color.Black));
            // 標準価格
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_ListPriceFl,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_ListPriceFl, false, true, true, Color.Black));
            // 原単価
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_StockUnitPrice,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_StockUnitPrice, false, true, true, Color.Black));
            // 仕入数
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_SalesOrderUnit,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_SalesOrderUnit, false, true, true, Color.Black));
            // 仕入後数
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_AfSalesOrderUnit,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_AfSalesOrderUnit, false, false, true, Color.Black));
            // 棚番
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_WarehouseShelfNo,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_WarehouseShelfNo, false, false, true, Color.Black));
            // 発注残
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_SalesOrderCount,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_SalesOrderCount, false, false, true, Color.Black));
            // 在庫数
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_SupplierStock,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_SupplierStock, false, false, true, Color.Black));
            // 明細備考
            _slipDtlColumnStateList.Add(AdjustStockAcs.ctCOL_DtlNote,
                                        new AdjustStockColumnState(AdjustStockAcs.ctCOL_DtlNote, false, true, true, Color.Black));
            
        }
        // --- ADD 2008/07/24 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/07/24 使用していないのでコメントアウト
        /* --- DEL 2008/07/24 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 在庫オプション入力列状態リスト作成処理
		/// </summary>
		private static void CreateStockOptionList()
		{
			// 未実装
            stockOptionInputList = new Dictionary<int, Dictionary<string, AdjustStockColumnState>>();
			SlipDtlColumnStateList wkDic;
            wkDic = new Dictionary<string, AdjustStockColumnState>();
			stockOptionInputList.Add((int)ConstantManagement_SF_AP.DetailKindCode.None, wkDic);
		}
           --- DEL 2008/07/24 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/07/24 使用していないのでコメントアウト

        #endregion

        #region InnerClass
        /// <summary>
		/// 伝票明細列状態クラス
		/// </summary>
		public class AdjustStockColumnState
		{
			/// <summary>
			/// カラム名称
			/// </summary>
			private string _columnName = null;
			/// <summary>
			/// 参照状態
			/// </summary>
			private bool _readOnly = false;
			/// <summary>
			/// 有効状態
			/// </summary>
			private bool _enable = false;
			/// <summary>
			/// 表示状態
			/// </summary>
			private bool _visible = false;
			/// <summary>
			/// 文字色
			/// </summary>
			private Color _foreColor;

			/// <summary>
			/// 伝票明細列状態クラスのコンストラクタ
			/// </summary>
			/// <param name="columnName">カラム名称</param>
			/// <param name="readOnly">読取専用状態(true=読取専用,false=通常)</param>
			/// <param name="enabled">有効無効状態(true=有効,false=無効)</param>
			/// <param name="visible">表示非表示設定</param>
			/// <param name="foreColor">文字色</param>
            public AdjustStockColumnState(string columnName, bool readOnly, bool enabled, bool visible, Color foreColor)
			{
				this._columnName = columnName;
				this._readOnly = readOnly;
				this._enable = enabled;
				this._visible = visible;
				this._foreColor = foreColor;
			}
			/// <summary>
			/// カラム名称プロパティ
			/// </summary>
			public string ColumnName
			{
				get { return this._columnName; }
			}
			/// <summary>
			/// 読取専用プロパティ
			/// </summary>
			/// <value>true=読取専用,false=通常</value>
			public bool ReadOnly
			{
				get { return this._readOnly; }
			}
			/// <summary>
			/// 有効無効プロパティ
			/// </summary>
			/// <value>true=有効,false=無効</value>
			public bool Enabled
			{
				get { return this._enable; }
			}
			/// <summary>
			/// 表示プロパティ
			/// </summary>
			/// <value>true=表示可,false=表示不可</value>
			public bool Visible
			{
				get { return this._visible; }
			}
			/// <summary>
			/// 文字色プロパティ
			/// </summary>
			public Color ForeColor
			{
				get { return this._foreColor; }
			}
		}
		#endregion
	}
}
