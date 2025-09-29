using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫調整確認表用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫調整確認表用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2007.03.09</br>
	/// <br></br>
    /// <br>Update Note: 2007.10.04 980035 金沢 貞義</br>
    /// <br>             ・ DC.NS対応</br>
    /// <br>Update Note: 2010/11/15 tianjw</br>
    /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
    /// <br>Update Note: 2011/11/15 xupz</br>
    /// <br>            ・redmine#26559 在庫仕入確認表／担当者の出力について
    /// </remarks>
	public class MAZAI02054EA
	{
		# region Public Const

		/// <summary> テーブル名称 </summary>
		public const string ct_Tbl_StockAdjustDtl			= "Tbl_StockAdjustDtl";

		/// <summary> 拠点コード </summary>
		public const string ct_Col_SectionCode				= "SectionCode";

		/// <summary> 拠点ガイド名称 </summary>
		public const string ct_Col_SectionGuideNm			= "SectionGuideNm";

		/// <summary> 受払元伝票区分 </summary>
		public const string ct_Col_AcPaySlipCd				= "AcPaySlipCd";

		/// <summary> 受払元伝票名称 </summary>
		public const string ct_Col_AcPaySlipNm				= "AcPaySlipNm";

		/// <summary> 受払元取引区分 </summary>
		public const string ct_Col_AcPayTransCd				= "AcPayTrans";

		/// <summary> 受払元取引名称 </summary>
		public const string ct_Col_AcPayTransNm				= "AcPayTransNm";

		/// <summary> 調整日付(表示用) </summary>
		public const string ct_Col_AdjustDate				= "AdjustDate";

		/// <summary> ソート用調整日付 </summary>
		public const string ct_Col_Sort_AdjustDate			= "Sort_AdjustDate";

        // --- ADD 2008/09/26 -------------------------------->>>>>
        /// <summary> 入力日 </summary>
        public const string ct_Col_InputDay                 = "InputDay";
        // --- ADD 2008/09/26 --------------------------------<<<<<

		/// <summary> 在庫調整伝票番号 </summary>
		public const string ct_Col_StockAdjustSlipNo		= "StockAdjustSlipNo";

		/// <summary> 在庫調整行番号 </summary>
		public const string ct_Col_StockAdjustRowNo			= "StockAdjustRowNo";

		/// <summary> メーカーコード </summary>
		public const string ct_Col_MakerCode				= "MakerCode";

		/// <summary> メーカー名称 </summary>
		public const string ct_Col_MakerName				= "MakerName";

		/// <summary> 商品コード </summary>
		public const string ct_Col_GoodsCode				= "GoodsCode";

		/// <summary> 商品名称 </summary>
		public const string ct_Col_GoodsName				= "GoodsName";

        // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> 製造番号 </summary>
		//public const string ct_Col_ProductNumber			= "ProductNumber";
        //
		///// <summary> 変更前製造番号 </summary>
		//public const string ct_Col_BfProductNumber			= "BfProductNumber";
        //
		///// <summary> 商品電話番号1 </summary>
		//public const string ct_Col_StockTelNo1				= "StockTelNo1";
        //
		///// <summary> 変更前商品電話番号1 </summary>
		//public const string ct_Col_BfStockTelNo1			= "BfStockTelNo1";
        // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
        // ----- DEL 2011/11/15 xupz---------->>>>>
        ///// <summary> 入力担当者コード </summary>
        //public const string ct_Col_InputAgenCd = "InputAgenCd";

        ///// <summary> 入力担当者名称 </summary>
        //public const string ct_Col_InputAgenNm = "InputAgenNm";
        // ----- DEL 2011/11/15 xupz----------<<<<<
        // ----- ADD 2011/11/15 xupz---------->>>>>
        /// <summary> 仕入担当者コード </summary>
        public const string ct_Col_StockAgenCd = "StockAgenCd";

        /// <summary> 仕入担当者名称 </summary>
        public const string ct_Col_StockAgenNm = "StockAgenNm";
        // ----- ADD 2011/11/15 xupz----------<<<<<
		

        //--- ADD 2008/07/04 ---------->>>>>
        /// <summary> 定価(浮動) </summary>
        public const string ct_Col_ListPrice                = "ListPrice";
        //--- ADD 2008/07/04 ----------<<<<<

		/// <summary> 仕入単価 </summary>
		public const string ct_Col_StockUnitPrice			= "StockUnitPrice";

		/// <summary> 変更前仕入単価 </summary>
		public const string ct_Col_BfStockUnitPrice			= "BfStockUnitPrice";

		/// <summary> 仕入単価(合計) </summary>
		public const string ct_Col_TotalStockUnitPrice		= "TotalStockUnitPrice";

		/// <summary> 仕入単価(合計)(プラス) </summary>
		public const string ct_Col_TotalStockUnitPricePlus	= "TotalStockUnitPricePlus";

		/// <summary> 仕入単価(合計)(マイナス) </summary>
		public const string ct_Col_TotalStockUnitPriceMinus	= "TotalStockUnitPriceMinus";

		/// <summary> 明細備考 </summary>
		public const string ct_Col_DtlNote					= "DtlNote";

		/// <summary> 調整数 </summary>
		public const string ct_Col_AdjustCount				= "AdjustCount";

		/// <summary> 調整数(プラス) </summary>
		public const string ct_Col_AdjustCountPlus			= "AdjustCountPlus";

		/// <summary> 調整数(マイナス) </summary>
		public const string ct_Col_AdjustCountMinus			= "AdjustCountMinus";

		/// <summary> 伝票備考 </summary>
		public const string ct_Col_SlipNote					= "SlipNote";

        // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> 商品電話番号2 </summary>
        //public const string ct_Col_StockTelNo2				= "StockTelNo2";
        //
        ///// <summary> 変更前商品電話番号2 </summary>
        //public const string ct_Col_BfStockTelNo2			= "BfStockTelNo2";
        //
        ///// <summary> 製番管理区分 </summary>
        //public const string ct_Col_PrdNumMngDiv				= "PrdNumMngDiv";
        //
        ///// <summary> 製番管理名称 </summary>
        //public const string ct_Col_PrdNumMngDivNm			= "PrdNumMngDivNm";
        // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

        // --- DEL 2008/09/11 -------------------------------->>>>>
		// /// <summary> 仕入在庫数 </summary>
		//public const string ct_Col_SupplierStock			= "SupplierStock";

		// /// <summary> 受託数 </summary>
		// //public const string ct_Col_TrustCount				= "TrustCount";
        // --- DEL 2008/09/11 --------------------------------<<<<<

        // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> 在庫状態 </summary>
        //public const string ct_Col_StockState				= "StockState";
        //
        ///// <summary> 在庫状態名称 </summary>
        //public const string ct_Col_StockStateNm				= "StockStateNm";
        //
        ///// <summary> 変更前在庫状態 </summary>
        //public const string ct_Col_BfStockState				= "BfStockState";
        //
        ///// <summary> 変更前在庫状態名称 </summary>
        //public const string ct_Col_BfStockStateNm			= "BfStockStateNm";
        // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

        // --- DEL 2008/09/11 -------------------------------->>>>>
		// /// <summary> 在庫区分 </summary>
		//public const string ct_Col_StockDiv					= "StockDiv";
        
		// /// <summary> 在庫区分名称 </summary>
		//public const string ct_Col_StockDivNm				= "StockDivNm";
        // --- DEL 2008/09/11 --------------------------------<<<<<

        // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary> 商品状態 </summary>
		//public const string ct_Col_GoodsCodeStatus			= "GoodsCodeStatus";
        //
		///// <summary> 商品状態名称 </summary>
		//public const string ct_Col_GoodsCodeStatusNm		= "GoodsCodeStatusNm";
        // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

        // 2007.10.04 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode            = "WarehouseCode";

        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName            = "WarehouseName";

        /// <summary> 棚番 </summary>
        public const string ct_Col_WarehouseShelfNo         = "WarehouseShelfNo";
        // 2007.10.04 追加 <<<<<<<<<<<<<<<<<<<<

        // ---------- ADD 2010/11/15 ---------->>>>>
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        // ---------- ADD 2010/11/15 ----------<<<<<

        /// <summary> フリーカラム１ </summary>
		public const string ct_Col_FreeColumn1				= "FreeColumn1";

		/// <summary> フリーカラム１名称 </summary>
		public const string ct_Col_FreeColumn1Nm			= "FreeColumn1Nm";

		/// <summary> フリーカラム２ </summary>
		public const string ct_Col_FreeColumn2				= "FreeColumn2";

		/// <summary> フリーカラム２名称 </summary>
		public const string ct_Col_FreeColumn2Nm			= "FreeColumn2Nm";

		// --- キーブレイク用 DataTable列名 --- //
		/// <summary> 小計出力キーブレイク </summary>
		public const string ct_Col_MiniTotal_KeyBleak		= "MiniTotal_KeyBleak";

		// --- DataTable項目フォーマット形式 --- //
		/// <summary>共通 表示用日付フォーマット</summary>
		public const string ct_DateFomat = "YYYY/MM/DD";
		# endregion Public Const

		# region Constructor
		/// <summary>
		/// 在庫調整確認表用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫調整確認表用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.09</br>
		/// </remarks>
		public MAZAI02054EA()
		{
		}
		# endregion

		# region Static Public Method
		/// <summary>
		/// 在庫調整確認表DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : 在庫調整確認表データセットのスキーマを設定する。</br>
		/// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.03.09</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
		/// </remarks>
		static public void CreateDataTableStockAdjustDtl(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
			if (ds.Tables.Contains(ct_Tbl_StockAdjustDtl))
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				ds.Tables[ct_Tbl_StockAdjustDtl].Clear();
			}
			else
			{
				// スキーマ設定
				ds.Tables.Add(ct_Tbl_StockAdjustDtl);
				DataTable dt = ds.Tables[ct_Tbl_StockAdjustDtl];

				dt.Columns.Add(ct_Col_SectionCode				, typeof(string));		// 拠点コード
				dt.Columns[ct_Col_SectionCode					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_SectionGuideNm			, typeof(string));		// 拠点名称
				dt.Columns[ct_Col_SectionGuideNm				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_AcPaySlipCd				, typeof(int));			// 受払元伝票区分
				dt.Columns[ct_Col_AcPaySlipCd					].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_AcPaySlipNm				, typeof(string));		// 受払元伝票名称
				dt.Columns[ct_Col_AcPaySlipNm					].DefaultValue = "";

				dt.Columns.Add(ct_Col_AcPayTransCd				, typeof(int));			// 受払元取引区分
				dt.Columns[ct_Col_AcPayTransCd					].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_AcPayTransNm				, typeof(string));		// 受払元取引名称
				dt.Columns[ct_Col_AcPayTransNm					].DefaultValue = "";

				dt.Columns.Add(ct_Col_AdjustDate				, typeof(string));		// 調整日付
				dt.Columns[ct_Col_AdjustDate					].DefaultValue = "";

				dt.Columns.Add(ct_Col_Sort_AdjustDate			, typeof(int));			// ソート用調整日付
				dt.Columns[ct_Col_Sort_AdjustDate				].DefaultValue = 0;

                // --- ADD 2008/09/26 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_InputDay                  , typeof(string));		// 入力日
                dt.Columns[ct_Col_InputDay                      ].DefaultValue = "";
                // --- ADD 2008/09/26 --------------------------------<<<<<

				dt.Columns.Add(ct_Col_StockAdjustSlipNo			, typeof(int));			// 在庫調整伝票番号
				dt.Columns[ct_Col_StockAdjustSlipNo				].DefaultValue = 0;

				dt.Columns.Add(ct_Col_StockAdjustRowNo			, typeof(int));			// 在庫調整行番号
				dt.Columns[ct_Col_StockAdjustRowNo				].DefaultValue = 0;

				dt.Columns.Add(ct_Col_MakerCode					, typeof(int));			// メーカーコード
				dt.Columns[ct_Col_MakerCode						].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_MakerName					, typeof(string));		// メーカー名称
				dt.Columns[ct_Col_MakerName						].DefaultValue = "";

				dt.Columns.Add(ct_Col_GoodsCode					, typeof(string));		// 商品コード
				dt.Columns[ct_Col_GoodsCode						].DefaultValue = "";		

				dt.Columns.Add(ct_Col_GoodsName					, typeof(string));		// 商品名称
				dt.Columns[ct_Col_GoodsName						].DefaultValue = "";

                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(ct_Col_ProductNumber             , typeof(string));		// 製造番号
                //dt.Columns[ct_Col_ProductNumber					].DefaultValue = "";
                //
                //dt.Columns.Add(ct_Col_BfProductNumber			, typeof(string));		// 変更前製造番号
                //dt.Columns[ct_Col_BfProductNumber				].DefaultValue = "";
                //
                //dt.Columns.Add(ct_Col_StockTelNo1				, typeof(string));		// 商品電話番号1
                //dt.Columns[ct_Col_StockTelNo1					].DefaultValue = "";
                //
				//dt.Columns.Add(ct_Col_BfStockTelNo1				, typeof(string));		// 変更前商品電話番号1
				//dt.Columns[ct_Col_BfStockTelNo1					].DefaultValue = "";
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

                // ----- DEL 2011/11/15 xupz---------->>>>>
                //dt.Columns.Add(ct_Col_InputAgenCd, typeof(string));		// 入力担当者コード
                //dt.Columns[ct_Col_InputAgenCd].DefaultValue = "";

                //dt.Columns.Add(ct_Col_InputAgenNm, typeof(string));		// 入力担当者名称
                //dt.Columns[ct_Col_InputAgenNm].DefaultValue = "";
                // ----- DEL 2011/11/15 xupz----------<<<<<
                // ----- ADD 2011/11/15 xupz---------->>>>>
                dt.Columns.Add(ct_Col_StockAgenCd, typeof(string));		// 仕入担当者コード
                dt.Columns[ct_Col_StockAgenCd].DefaultValue = "";

                dt.Columns.Add(ct_Col_StockAgenNm, typeof(string));		// 仕入担当者名称
                dt.Columns[ct_Col_StockAgenNm].DefaultValue = "";
                // ----- ADD 2011/11/15 xupz----------<<<<<
			
                //--- ADD 2008/07/04 ---------->>>>>
                dt.Columns.Add(ct_Col_ListPrice                 , typeof(Int64));       // 定価
                dt.Columns[ct_Col_ListPrice].DefaultValue                      = 0;
                //--- ADD 2008/07/04 ----------<<<<<

                // --- DEL 2008/09/19 -------------------------------->>>>>
				//dt.Columns.Add(ct_Col_StockUnitPrice			, typeof(Int64));		// 仕入単価
                // --- DEL 2008/09/19 -------------------------------->>>>>
                // --- ADD 2008/09/19 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_StockUnitPrice,             typeof(double));		// 仕入単価
                // --- ADD 2008/09/19 --------------------------------<<<<<
				dt.Columns[ct_Col_StockUnitPrice				].DefaultValue = 0;

                // --- DEL 2008/09/19 -------------------------------->>>>>
				//dt.Columns.Add(ct_Col_BfStockUnitPrice			, typeof(Int64));		// 変更前仕入単価
                // --- DEL 2008/09/19 -------------------------------->>>>>
                // --- ADD 2008/09/19 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_BfStockUnitPrice,           typeof(double));		// 変更前仕入単価
                // --- ADD 2008/09/19 --------------------------------<<<<<
				dt.Columns[ct_Col_BfStockUnitPrice				].DefaultValue = 0;
                
				dt.Columns.Add(ct_Col_TotalStockUnitPrice		, typeof(Int64));		// 仕入単価仕入単価(合計)
				dt.Columns[ct_Col_TotalStockUnitPrice			].DefaultValue = 0;

				dt.Columns.Add(ct_Col_TotalStockUnitPricePlus	, typeof(Int64));		// 仕入単価仕入単価(合計)(プラス)
				dt.Columns[ct_Col_TotalStockUnitPricePlus		].DefaultValue = 0;

				dt.Columns.Add(ct_Col_TotalStockUnitPriceMinus	, typeof(Int64));		// 仕入単価仕入単価(合計)(マイナス)
				dt.Columns[ct_Col_TotalStockUnitPriceMinus		].DefaultValue = 0;

				dt.Columns.Add(ct_Col_DtlNote					, typeof(string));		// 明細備考
				dt.Columns[ct_Col_DtlNote						].DefaultValue = "";

				dt.Columns.Add(ct_Col_AdjustCount				, typeof(double));		// 調整数
				dt.Columns[ct_Col_AdjustCount					].DefaultValue = 0.0;

				dt.Columns.Add(ct_Col_AdjustCountPlus			, typeof(double));		// 調整数(プラス)
				dt.Columns[ct_Col_AdjustCountPlus				].DefaultValue = 0.0;

				dt.Columns.Add(ct_Col_AdjustCountMinus			, typeof(double));		// 調整数(マイナス)
				dt.Columns[ct_Col_AdjustCountMinus				].DefaultValue = 0.0;

				dt.Columns.Add(ct_Col_SlipNote					,typeof(string));		// 伝票備考
				dt.Columns[ct_Col_SlipNote						].DefaultValue = "";

                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(ct_Col_StockTelNo2               , typeof(string));		// 商品電話番号2
                //dt.Columns[ct_Col_StockTelNo2					].DefaultValue = "";
                //
                //dt.Columns.Add(ct_Col_BfStockTelNo2				, typeof(string));		// 変更前商品電話番号2
                //dt.Columns[ct_Col_BfStockTelNo2					].DefaultValue = "";
                //
                //dt.Columns.Add(ct_Col_PrdNumMngDiv				, typeof(int));			// 製番管理区分
                //dt.Columns[ct_Col_PrdNumMngDiv					].DefaultValue = 0;
                //
                //dt.Columns.Add(ct_Col_PrdNumMngDivNm			, typeof(string));		// 製番管理名称
                //dt.Columns[ct_Col_PrdNumMngDivNm				].DefaultValue = "";
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

                // --- DEL 2008/09/11 -------------------------------->>>>>
				//dt.Columns.Add(ct_Col_SupplierStock				, typeof(double));		// 仕入在庫数
				//dt.Columns[ct_Col_SupplierStock					].DefaultValue = 0.0;

				//dt.Columns.Add(ct_Col_TrustCount				, typeof(double));		// 受託数
				//dt.Columns[ct_Col_TrustCount					].DefaultValue = 0.0;
                // --- DEL 2008/09/11 --------------------------------<<<<<

                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(ct_Col_StockState                , typeof(int));			// 在庫状態
                //dt.Columns[ct_Col_StockState					].DefaultValue = 0;
                //
                //dt.Columns.Add(ct_Col_StockStateNm				, typeof(string));		// 在庫状態名称
                //dt.Columns[ct_Col_StockStateNm					].DefaultValue = "";
                //
                //dt.Columns.Add(ct_Col_BfStockState				, typeof(int));			// 変更前在庫状態
                //dt.Columns[ct_Col_BfStockState					].DefaultValue = 0;
                //
                //dt.Columns.Add(ct_Col_BfStockStateNm			, typeof(string));		// 変更前在庫状態名称
                //dt.Columns[ct_Col_BfStockStateNm				].DefaultValue = "";
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

                // --- DEL 2008/09/11 -------------------------------->>>>>
				//dt.Columns.Add(ct_Col_StockDiv					, typeof(int));			// 在庫区分
				//dt.Columns[ct_Col_StockDiv						].DefaultValue = 0;
                
				//dt.Columns.Add(ct_Col_StockDivNm				, typeof(string));		// 在庫区分名称
				//dt.Columns[ct_Col_StockDivNm					].DefaultValue = "";
                // --- DEL 2008/09/11 --------------------------------<<<<<

                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(ct_Col_GoodsCodeStatus           , typeof(int));			// 商品状態
                //dt.Columns[ct_Col_GoodsCodeStatus				].DefaultValue = 0;
                //
                //dt.Columns.Add(ct_Col_GoodsCodeStatusNm			, typeof(string));		// 商品状態名称
                //dt.Columns[ct_Col_GoodsCodeStatusNm				].DefaultValue = "";
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.04 追加 >>>>>>>>>>>>>>>>>>>>
                dt.Columns.Add(ct_Col_WarehouseCode				, typeof(string));		// 倉庫コード
                dt.Columns[ct_Col_WarehouseCode					].DefaultValue = "";
                
                dt.Columns.Add(ct_Col_WarehouseName				, typeof(string));		// 倉庫名称
                dt.Columns[ct_Col_WarehouseName					].DefaultValue = "";

                dt.Columns.Add(ct_Col_WarehouseShelfNo			, typeof(string));		// 棚番
                dt.Columns[ct_Col_WarehouseShelfNo				].DefaultValue = "";
                // 2007.10.04 追加 <<<<<<<<<<<<<<<<<<<<

                // ---------- ADD 2010/11/15 ---------->>>>>
                dt.Columns.Add(ct_Col_GoodsNo                   , typeof(string));		// 品番
                dt.Columns[ct_Col_GoodsNo                       ].DefaultValue = "";
                // ---------- ADD 2010/11/15 ----------<<<<<

				dt.Columns.Add(ct_Col_FreeColumn1				, typeof(string));		// フリーカラム１
				dt.Columns[ct_Col_FreeColumn1					].DefaultValue = "";

				dt.Columns.Add(ct_Col_FreeColumn1Nm				, typeof(string));		// フリーカラム１名称
				dt.Columns[ct_Col_FreeColumn1Nm					].DefaultValue = "";

				dt.Columns.Add(ct_Col_FreeColumn2				, typeof(string));		// フリーカラム２
				dt.Columns[ct_Col_FreeColumn2					].DefaultValue = "";

				dt.Columns.Add(ct_Col_FreeColumn2Nm				, typeof(string));		// フリーカラム２名称
				dt.Columns[ct_Col_FreeColumn2Nm					].DefaultValue = "";

				dt.Columns.Add(ct_Col_MiniTotal_KeyBleak		,typeof(string));		// 小計出力キーブレイク
				dt.Columns[ct_Col_MiniTotal_KeyBleak			].DefaultValue	= "";

			}
		}

		/// <summary>
		/// 受払元伝票区分名称取得処理
		/// </summary>
		/// <param name="acPaySlipCd">受払元伝票区分</param>
		/// <returns>受払元伝票区分名称</returns>
		/// <remarks>
		/// <br>Note       : 受払元伝票区分名称の取得を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		static public string GetAcPaySlipNm(int acPaySlipCd)
		{
			string acPaySlipNm = "";
			switch (acPaySlipCd)
			{
				case 10: acPaySlipNm = "仕入"; break;
				case 11: acPaySlipNm = "受託"; break;
				case 12: acPaySlipNm = "受計上"; break;
				case 20: acPaySlipNm = "売上"; break;
				case 21: acPaySlipNm = "売計上"; break;
				case 22: acPaySlipNm = "委託"; break;
				case 23: acPaySlipNm = "売切"; break;
				case 30: acPaySlipNm = "移動出荷"; break;
				case 31: acPaySlipNm = "移動入荷"; break;
				case 40: acPaySlipNm = "調整"; break;
				case 41: acPaySlipNm = "半黒"; break;
				case 50: acPaySlipNm = "棚卸"; break;
			}
			return acPaySlipNm;
		}

		/// <summary>
		/// 受払元取引区分名称取得処理
		/// </summary>
		/// <param name="acPayTransCd">受払元取引区分</param>
		/// <returns>受払元取引区分名称</returns>
		/// <remarks>
		/// <br>Note       : 受払元取引区分名称の取得を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		static public string GetAcPayTransCdNm(int acPayTransCd)
		{
			string acPayTransCdNm = "";
			switch (acPayTransCd)
			{
				case 10: acPayTransCdNm = "通常伝票"; break;
				case 11: acPayTransCdNm = "返品"; break;
				case 12: acPayTransCdNm = "値引"; break;
				case 20: acPayTransCdNm = "赤伝"; break;
				case 21: acPayTransCdNm = "削除"; break;
				case 22: acPayTransCdNm = "解除"; break;
				case 30: acPayTransCdNm = "在庫数調整"; break;
				case 31: acPayTransCdNm = "原価調整"; break;
				case 32: acPayTransCdNm = "製番調整"; break;
				case 33: acPayTransCdNm = "不良品"; break;
				case 34: acPayTransCdNm = "抜出"; break;
				case 35: acPayTransCdNm = "消去"; break;
				case 40: acPayTransCdNm = "過不足更新"; break;
				case 90: acPayTransCdNm = "取消"; break;
			}
			return acPayTransCdNm;
		}

        // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 製番管理区分名称取得処理
        ///// </summary>
        ///// <param name="prdNumMngDiv">製番管理区分</param>
        ///// <returns>製番管理区分名称</returns>
        ///// <remarks>
        ///// <br>Note       : 製番管理区分名称の取得を行います。</br>
        ///// <br>Programmer : 97036 amami</br>
        ///// <br>Date       : 2007.03.14</br>
        ///// </remarks>
        //static public string GetPrdNumMngDivNm(int prdNumMngDiv)
        //{
        //	string prdNumMngDivNm = "";
        //	switch (prdNumMngDiv)
        //	{
        //		case 0: prdNumMngDivNm = "無"; break;
        //		case 1: prdNumMngDivNm = "有"; break;
        //	}
        //	return prdNumMngDivNm;
        //}
        //
        ///// <summary>
		///// 在庫状態名称取得処理
		///// </summary>
		///// <param name="stockState">在庫状態</param>
		///// <returns>在庫状態名称</returns>
		///// <remarks>
		///// <br>Note       : 在庫状態名称の取得を行います。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2007.03.14</br>
		///// </remarks>
		//static public string GetStockStateNm(int stockState)
		//{
		//	string stockStateNm = "";
		//	switch (stockState)
		//	{
		//		case  0: stockStateNm = "在庫"; break;
		//		case 10: stockStateNm = "受託中"; break;
		//		case 20: stockStateNm = "委託中"; break;
		//		case 30: stockStateNm = "売切"; break;
		//		case 50: stockStateNm = "売上計上済"; break;
        //		case 60: stockStateNm = "予約中"; break;
        //		case 70: stockStateNm = "返品"; break;
        //		case 80: stockStateNm = "抜出"; break;
        //		case 81: stockStateNm = "消去"; break;
        //	}
        //	return stockStateNm;
        //}
        // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 在庫区分名称取得処理
		/// </summary>
		/// <param name="stockDiv">在庫区分</param>
		/// <returns>在庫区分名称</returns>
		/// <remarks>
		/// <br>Note       : 在庫区分名称の取得を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		static public string GetStockDivNm(int stockDiv)
		{
			string stockDivNm = "";
			switch (stockDiv)
			{
				case 0: stockDivNm = "自社"; break;
				case 1: stockDivNm = "受託"; break;
			}
			return stockDivNm;
		}

        // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
		///// 商品状態名称取得処理
		///// </summary>
		///// <param name="goodsCodeStatus">商品状態</param>
		///// <returns>商品状態名称</returns>
		///// <remarks>
		///// <br>Note       : 商品状態名称の取得を行います。</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2007.03.14</br>
		///// </remarks>
		//static public string GetGoodsCodeStatusNm(int goodsCodeStatus)
		//{
		//	string goodsCodeStatusNm = "";
		//	switch (goodsCodeStatus)
		//	{
		//		case 0: goodsCodeStatusNm = "正常"; break;
		//		case 1: goodsCodeStatusNm = "不良品"; break;
		//	}
		//	return goodsCodeStatusNm;
		//}
        // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
        # endregion
	}
}
