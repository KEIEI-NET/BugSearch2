//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動確認表
// プログラム概要   : 在庫移動確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/10  修正内容 : 不具合対応[12213]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/11  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//

using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 在庫・倉庫移動確認表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫・倉庫移動確認表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22013 久保　将太</br>
	/// <br>Date       : 2007.03.14</br>
	/// <br></br>
    /// <br>Update Note: 2007.09.11 鈴木 正臣</br>
    /// <br>           : 流通.NS用に変更</br>
    /// <br>           : 2009/03/16 照田 貴志　不具合対応[12331]</br>
	/// </remarks>
	public class MAZAI02034EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
		public const string ct_Tbl_StockMove				= "Tbl_StockMove";

		/// <summary> 出荷予定日 </summary>
		public const string ct_Col_ShipmentScdlDay			= "ShipmentScdlDay";
		/// <summary> 出荷予定日(ソート) </summary>
		public const string ct_Col_Sort_ShipmentScdlDay		= "Sort_ShipmentScdlDay";
		/// <summary> 出荷確定日 </summary>
		public const string ct_Col_ShipmentFixDay			= "ShipmentFixDay";
		/// <summary> 出荷確定日(ソート) </summary>
		public const string ct_Col_Sort_ShipmentFixDay		= "Sort_ShipmentFixDay";
		/// <summary> 入荷日 </summary>
		public const string ct_Col_ArrivalGoodsDay			= "ArrivalGoodsDay";
		/// <summary> 入荷日(ソート) </summary>
		public const string ct_Col_Sort_ArrivalGoodsDay		= "Sort_ArrivalGoodsDay";
		/// <summary> 移動元拠点コード </summary>
		public const string ct_Col_BfSectionCode			= "BfSectionCode";
		/// <summary> 移動元拠点ガイド名称 </summary>
		public const string ct_Col_BfSectionGuideNm			= "BfSectionGuideNm";
		/// <summary> 移動元倉庫コード </summary>
		public const string ct_Col_BfEnterWarehCode			= "BfEnterWarehCode";
		/// <summary> 移動元倉庫名称 </summary>
		public const string ct_Col_BfEnterWarehName			= "BfEnterWarehName";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>移動元棚番</summary>
        public const string ct_Col_BfShelfNo                = "BfShelfNo";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /// <summary> 移動先拠点コード </summary>
		public const string ct_Col_AfSectionCode			= "AfSectionCode";
		/// <summary> 移動先拠点ガイド名称 </summary>
		public const string ct_Col_AfSectionGuideNm			= "AfSectionGuideNm";
		/// <summary> 移動先倉庫コード </summary>
		public const string ct_Col_AfEnterWarehCode			= "AfEnterWarehCode";
		/// <summary> 移動先倉庫名称 </summary>
		public const string ct_Col_AfEnterWarehName			= "AfEnterWarehName";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>移動先棚番</summary>
        public const string ct_Col_AfShelfNo                = "AfShelfNo";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		/// <summary> 在庫移動伝票番号 </summary>
		public const string ct_Col_StockMoveSlipNo			= "StockMoveSlipNo";
		/// <summary> 在庫移動行番号 </summary>
		public const string ct_Col_StockMoveRowNo			= "StockMoveRowNo";
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary> 在庫移動行詳細番号 </summary>
        //public const string ct_Col_StockMoveExpNum			= "StockMoveExpNum";
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /// <summary> 仕入先コード </summary>
		public const string ct_Col_CustomerCode				= "CustomerCode";
		/// <summary> 得意先名称 </summary>
		public const string ct_Col_CustomerName				= "CustomerName";
		/// <summary> 得意先名称2 </summary>
		public const string ct_Col_CustomerName2			= "CustomerName2";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm              = "CustomerSnm";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /// <summary> メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd             = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
		public const string ct_Col_MakerName 				= "MakerName";
		/// <summary> 商品番号 </summary>
		public const string ct_Col_GoodsNo 				    = "GoodsNo";
		/// <summary> 商品名称 </summary>
		public const string ct_Col_GoodsName 				= "GoodsName";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary> 製造番号 </summary>
        //public const string ct_Col_ProDuctNumber			= "ProDuctNumber";
        ///// <summary> 商品電話番号1 </summary>
        //public const string ct_Col_StockTelNo1				= "StockTelNo1";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary> 移動中仕入在庫数 </summary>
        //public const string ct_Col_MovingSupliStock 		= "MovingSupliStock";
        ///// <summary> 移動中受託在庫数 </summary>
        //public const string ct_Col_MovingTrustStock 		= "MovingTrustStock";
        ///// <summary> 移動在庫数 </summary>
        //public const string ct_Col_MovingTotalStock 		= "MovingTotalStock";
        /// <summary> 移動数 </summary>
        public const string ct_Col_MoveCount                = "MoveCount";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /// <summary> 伝票備考1 </summary>
		public const string ct_Col_SlipNote1 				= "SlipNote1";
		/// <summary> 伝票備考2 </summary>
		public const string ct_Col_SlipNote2 				= "SlipNote2";
		/// <summary> 伝票備考3 </summary>
		public const string ct_Col_SlipNote3 				= "SlipNote3";
		/// <summary> 伝票備考4 </summary>
		public const string ct_Col_SlipNote4 				= "SlipNote4";
		/// <summary> 伝票備考5 </summary>
		public const string ct_Col_SlipNote5 				= "SlipNote5";
		/// <summary> 伝票備考6 </summary>
		public const string ct_Col_SlipNote6 				= "SlipNote6";
		/// <summary> 更新拠点コード </summary>
		public const string ct_Col_St_UpdateSecCd			= "St_UpdateSecCd";
		/// <summary> 在庫移動従業員コード </summary>
		public const string ct_Col_StockMvEmpCode 			= "StockMvEmpCode";
		/// <summary> 在庫移動従業員名称 </summary>
		public const string ct_Col_StockMvEmpName 			= "StockMvEmpName";
		/// <summary> 出荷担当従業員コード </summary>
		public const string ct_Col_ShipAgentCd				= "ShipAgentCd";
		/// <summary> 出荷担当従業員名称 </summary>
		public const string ct_Col_ShipAgentNm				= "ShipAgentNm";
		/// <summary> 引取担当従業員コード </summary>
		public const string ct_Col_ReceiveAgentCd 			= "ReceiveAgentCd";
		/// <summary> 引取担当従業員名称 </summary>
		public const string ct_Col_ReceiveAgentNm 			= "ReceiveAgentNm";
		/// <summary> 在庫区分 </summary>
		public const string ct_Col_StockDiv					= "StockDiv";
		/// <summary> 在庫区分名称 </summary>
		public const string ct_Col_StockDivName				= "StockDivName";
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary> 商品電話番号2 </summary>
        //public const string ct_Col_StockTelNo2				= "StockTelNo2";
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        /// <summary> 移動状態 </summary>
		public const string ct_Col_MoveStatus				= "MoveStatus";
		/// <summary> 移動状態名称 </summary>
		public const string ct_Col_MoveStatusName			= "MoveStatusName";
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary> 仕入単価 </summary>
        //public const string ct_Col_StockUnitPrice			= "StockUnitPrice";
        ///// <summary> 仕入金額 </summary>
        //public const string ct_Col_StockPrice				= "StockPrice";
        /// <summary> 仕入単価 (税抜,浮動) </summary>
        public const string ct_Col_StockUnitPriceFl         = "StockUnitPriceFl";
        /// <summary> 移動金額 </summary>
        public const string ct_Col_StockPrice               = "StockPrice";
        /// <summary> 定価 (浮動) </summary>
        public const string ct_Col_ListPriceFl              = "ListPriceFl";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		/// <summary> 主拠点コード </summary>
		public const string ct_Col_MainSectionCode			= "MainSectionCode";
		/// <summary> 主拠点名称 </summary>
		public const string ct_Col_MainSectionName			= "MainSectionName";
		/// <summary> 主倉庫コード </summary>
		public const string ct_Col_MainWhareHouseCode		= "MainWhareHouseCode";
		/// <summary> 主倉庫名称 </summary>
		public const string ct_Col_MainWhareHouseName		= "MainWhareHouseName";
		/// <summary> 絞込拠点コード </summary>
		public const string ct_Col_ExtractSectionCode		= "ExtractSectionCode";
		/// <summary> 絞込拠点名称 </summary>
		public const string ct_Col_ExtractSectionName		= "ExtractSectionName";
		/// <summary> 絞込倉庫コード </summary>
		public const string ct_Col_ExtractWhareHouseCode	= "ExtractWhareHouseCode";
		/// <summary> 絞込倉庫名称 </summary>
		public const string ct_Col_ExtractWhareHouseName	= "ExtractWhareHouseName";
		/// <summary> 絞込み日付 </summary>
		public const string ct_Col_ExtractDate				= "ExtractDate";
		/// <summary> 絞込み日付 </summary>
		public const string ct_Col_Sort_ExtractDate			= "Sort_ExtractDate";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary> ＢＬ商品コード </summary>
        public const string ct_Col_BLGoodsCode              = "BLGoodsCode";
        ///// <summary> ＢＬ商品コード枝番 </summary>
        //public const string ct_Col_BLGoodsCdDerivedNo       = "BLGoodsCdDerivedNo";
        /// <summary> ＢＬ商品コード名称 (全角) </summary>
        public const string ct_Col_BLGoodsFullName          = "BLGoodsFullName";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        //--- ADD 2008/08/12 ---------->>>>>
        /// <summary> 移動元拠点ガイド略称 </summary>
        public const string ct_Col_BfSectionGuideSnm = "BfSectionGuideSnm";
        /// <summary> 移動先拠点ガイド略称 </summary>
        public const string ct_Col_AfSectionGuideSnm = "AfSectionGuideSnm";
        /// <summary> 入力日付 </summary>
        public const string ct_Col_InputDay = "InputDay";
        /// <summary> 移動枚数 </summary>
        public const string ct_Col_StockMoveSlipCnt = "StockMoveSlipCnt";
        //--- ADD 2008/08/12 ----------<<<<<

        // ---ADD 2009/03/16 不具合対応[12331] ---------------------------->>>>>
        /// <summary> 伝票発行済区分 </summary>
        public const string ct_Col_SlipPrintFinishCd = "SlipPrintFinishCd";
        /// <summary> 在庫移動形式 </summary>
        public const string ct_Col_StockMoveFormal = "StockMoveFormal";
        // ---ADD 2009/03/16 不具合対応[12331] ----------------------------<<<<<

        // ADD 2009/06/11 ------>>>
        /// <summary> 伝票区分 </summary>
        public const string ct_Col_SlipDivName = "SlipDivName";
        // ADD 2009/06/11 ------<<<

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 在庫・倉庫移動確認表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動確認表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		public MAZAI02034EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// <summary>
		/// 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動データセットのスキーマを設定する。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
			// テーブルが存在するかどうかのチェック
			if ( dt != null )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				dt.Clear();
			}
			else
			{
				// スキーマ設定
				dt = new DataTable( ct_Tbl_StockMove );

				dt.Columns.Add(ct_Col_ShipmentScdlDay		, typeof(string));		// 出荷予定日
				dt.Columns[ct_Col_ShipmentScdlDay			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_Sort_ShipmentScdlDay	, typeof(Int32));		// 出荷予定日(ソート)
				dt.Columns[ct_Col_Sort_ShipmentScdlDay		].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_ShipmentFixDay		, typeof(string));		// 出荷確定日
				dt.Columns[ct_Col_ShipmentFixDay			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_Sort_ShipmentFixDay	, typeof(Int32));		// 出荷確定日(ソート)
				dt.Columns[ct_Col_Sort_ShipmentFixDay		].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_ArrivalGoodsDay		, typeof(string));		// 入荷日
				dt.Columns[ct_Col_ArrivalGoodsDay			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_Sort_ArrivalGoodsDay	, typeof(Int32));		// 入荷日(ソート)
				dt.Columns[ct_Col_Sort_ArrivalGoodsDay		].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_BfSectionCode			, typeof(string));		// 移動元拠点コード
				dt.Columns[ct_Col_BfSectionCode				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_BfSectionGuideNm		, typeof(string));		// 移動元拠点ガイド名称
				dt.Columns[ct_Col_BfSectionGuideNm			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_BfEnterWarehCode		, typeof(string));		// 移動元倉庫コード
				dt.Columns[ct_Col_BfEnterWarehCode			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_BfEnterWarehName		, typeof(string));		// 移動元倉庫名称
				dt.Columns[ct_Col_BfEnterWarehName			].DefaultValue = "";		

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                dt.Columns.Add(ct_Col_BfShelfNo             , typeof(string));		// 移動元棚番
                dt.Columns[ct_Col_BfShelfNo                 ].DefaultValue = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				dt.Columns.Add(ct_Col_AfSectionCode			, typeof(string));		// 移動先拠点コード
				dt.Columns[ct_Col_AfSectionCode				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_AfSectionGuideNm		, typeof(string));		// 移動先拠点ガイド名称
				dt.Columns[ct_Col_AfSectionGuideNm			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_AfEnterWarehCode		, typeof(string));		// 移動先倉庫コード
				dt.Columns[ct_Col_AfEnterWarehCode			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_AfEnterWarehName		, typeof(string));		// 移動先倉庫名称
				dt.Columns[ct_Col_AfEnterWarehName			].DefaultValue = "";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                dt.Columns.Add(ct_Col_AfShelfNo             , typeof(string));		// 移動先棚番
                dt.Columns[ct_Col_AfShelfNo                 ].DefaultValue = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				dt.Columns.Add(ct_Col_StockMoveSlipNo		, typeof(Int32));		// 在庫移動伝票番号
				dt.Columns[ct_Col_StockMoveSlipNo			].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_StockMoveRowNo		, typeof(Int32));		// 在庫移動行番号
				dt.Columns[ct_Col_StockMoveRowNo			].DefaultValue = 0;		

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dt.Columns.Add(ct_Col_StockMoveExpNum		, typeof(Int32));		// 在庫移動行詳細番号
                //dt.Columns[ct_Col_StockMoveExpNum			].DefaultValue = 0;		
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				dt.Columns.Add(ct_Col_CustomerCode			, typeof(Int32));		// 仕入先コード
				dt.Columns[ct_Col_CustomerCode				].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_CustomerName			, typeof(string));		// 得意先名称
				dt.Columns[ct_Col_CustomerName				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_CustomerName2			, typeof(string));		// 得意先名称2
				dt.Columns[ct_Col_CustomerName2				].DefaultValue = "";		

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                dt.Columns.Add(ct_Col_CustomerSnm           , typeof(string));		// 得意先略称
                dt.Columns[ct_Col_CustomerSnm               ].DefaultValue = "";		
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                
                dt.Columns.Add(ct_Col_GoodsMakerCd				, typeof(Int32));		// メーカーコード
				dt.Columns[ct_Col_GoodsMakerCd					].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_MakerName				, typeof(string));		// メーカー名称
				dt.Columns[ct_Col_MakerName					].DefaultValue = "";		

				dt.Columns.Add(ct_Col_GoodsNo				, typeof(string));		// 商品コード
				dt.Columns[ct_Col_GoodsNo					].DefaultValue = "";		

				dt.Columns.Add(ct_Col_GoodsName				, typeof(string));		// 商品名称
				dt.Columns[ct_Col_GoodsName					].DefaultValue = "";		

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dt.Columns.Add(ct_Col_ProDuctNumber			, typeof(string));		// 製造番号
                //dt.Columns[ct_Col_ProDuctNumber				].DefaultValue = "";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dt.Columns.Add(ct_Col_StockTelNo1			, typeof(string));		// 商品電話番号1
                //dt.Columns[ct_Col_StockTelNo1				].DefaultValue = "";		
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dt.Columns.Add(ct_Col_MovingSupliStock		, typeof(Double));		// 移動中仕入在庫数
                //dt.Columns[ct_Col_MovingSupliStock			].DefaultValue = 0;		

                //dt.Columns.Add(ct_Col_MovingTrustStock		, typeof(Double));		// 移動中受託在庫数
                //dt.Columns[ct_Col_MovingTrustStock			].DefaultValue = 0;		

                //dt.Columns.Add(ct_Col_MovingTotalStock		, typeof(Double));		// 移動在庫数
                //dt.Columns[ct_Col_MovingTotalStock			].DefaultValue = 0;		
                
				dt.Columns.Add(ct_Col_MoveCount				, typeof(Double));		// 移動数
				dt.Columns[ct_Col_MoveCount					].DefaultValue = 0;		
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				dt.Columns.Add(ct_Col_SlipNote1				, typeof(string));		// 伝票備考1
				dt.Columns[ct_Col_SlipNote1					].DefaultValue = "";		

				dt.Columns.Add(ct_Col_SlipNote2				, typeof(string));		// 伝票備考2
				dt.Columns[ct_Col_SlipNote2					].DefaultValue = "";		

				dt.Columns.Add(ct_Col_SlipNote3				, typeof(string));		// 伝票備考3
				dt.Columns[ct_Col_SlipNote3					].DefaultValue = "";		

				dt.Columns.Add(ct_Col_SlipNote4				, typeof(string));		// 伝票備考4
				dt.Columns[ct_Col_SlipNote4					].DefaultValue = "";		

				dt.Columns.Add(ct_Col_SlipNote5				, typeof(string));		// 伝票備考5
				dt.Columns[ct_Col_SlipNote5					].DefaultValue = "";		

				dt.Columns.Add(ct_Col_SlipNote6				, typeof(string));		// 伝票備考6
				dt.Columns[ct_Col_SlipNote6					].DefaultValue = "";		

				dt.Columns.Add(ct_Col_St_UpdateSecCd		, typeof(string));		// 更新拠点コード
				dt.Columns[ct_Col_St_UpdateSecCd			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_StockMvEmpCode		, typeof(string));		// 在庫移動従業員コード
				dt.Columns[ct_Col_StockMvEmpCode			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_StockMvEmpName		, typeof(string));		// 在庫移動従業員名称
				dt.Columns[ct_Col_StockMvEmpName			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ShipAgentCd			, typeof(string));		// 出荷担当従業員コード
				dt.Columns[ct_Col_ShipAgentCd				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ShipAgentNm			, typeof(string));		// 出荷担当従業員名称
				dt.Columns[ct_Col_ShipAgentNm				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ReceiveAgentCd		, typeof(string));		// 引取担当従業員コード
				dt.Columns[ct_Col_ReceiveAgentCd			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ReceiveAgentNm		, typeof(string));		// 引取担当従業員名称
				dt.Columns[ct_Col_ReceiveAgentNm			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_StockDiv				, typeof(Int32));		// 在庫区分
				dt.Columns[ct_Col_StockDiv					].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_StockDivName			, typeof(string));		// 在庫区分名称
				dt.Columns[ct_Col_StockDivName				].DefaultValue = "";		

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dt.Columns.Add(ct_Col_StockTelNo2			, typeof(string));		// 商品電話番号2
                //dt.Columns[ct_Col_StockTelNo2				].DefaultValue = "";		
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				dt.Columns.Add(ct_Col_MoveStatus			, typeof(Int32));		// 移動状態
				dt.Columns[ct_Col_MoveStatus				].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_MoveStatusName		, typeof(string));		// 移動状態名称
				dt.Columns[ct_Col_MoveStatusName			].DefaultValue = "";		

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dt.Columns.Add(ct_Col_StockUnitPrice		, typeof(Int64));		// 仕入単価
                //dt.Columns[ct_Col_StockUnitPrice			].DefaultValue = 0;		

                //dt.Columns.Add(ct_Col_StockPrice			, typeof(Int64));		// 仕入金額
                //dt.Columns[ct_Col_StockPrice				].DefaultValue = 0;

				dt.Columns.Add(ct_Col_StockUnitPriceFl		, typeof(Double));		// 仕入単価 (税抜,浮動)
				dt.Columns[ct_Col_StockUnitPriceFl			].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockPrice            , typeof(Double));		// 移動金額
                dt.Columns[ct_Col_StockPrice                ].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_ListPriceFl	    	, typeof(Double));		// 定価 (浮動)
				dt.Columns[ct_Col_ListPriceFl			    ].DefaultValue = 0;		
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

				dt.Columns.Add(ct_Col_MainSectionCode		, typeof(string));		// 主拠点コード
				dt.Columns[ct_Col_MainSectionCode			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_MainSectionName		, typeof(string));		// 主拠点名称
				dt.Columns[ct_Col_MainSectionName			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_MainWhareHouseCode	, typeof(string));		// 主倉庫コード
				dt.Columns[ct_Col_MainWhareHouseCode		].DefaultValue = "";		

				dt.Columns.Add(ct_Col_MainWhareHouseName	, typeof(string));		// 主倉庫名称
				dt.Columns[ct_Col_MainWhareHouseName		].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ExtractSectionCode	, typeof(string));		// 絞込拠点コード
				dt.Columns[ct_Col_ExtractSectionCode		].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ExtractSectionName	, typeof(string));		// 絞込拠点名称
				dt.Columns[ct_Col_ExtractSectionName		].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ExtractWhareHouseCode	, typeof(string));		// 絞込倉庫コード
				dt.Columns[ct_Col_ExtractWhareHouseCode		].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ExtractWhareHouseName	, typeof(string));		// 絞込倉庫名称
				dt.Columns[ct_Col_ExtractWhareHouseName		].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ExtractDate			, typeof(string));		// 絞込日付
				dt.Columns[ct_Col_ExtractDate				].DefaultValue = "";		
			
				dt.Columns.Add(ct_Col_Sort_ExtractDate		, typeof(Int32));		// 絞込日付(ソート用)
				dt.Columns[ct_Col_Sort_ExtractDate			].DefaultValue = 0;		
                
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
				dt.Columns.Add(ct_Col_BLGoodsCode	    	, typeof(Int32));		// ＢＬ商品コード
				dt.Columns[ct_Col_BLGoodsCode		    	].DefaultValue = 0;		

                //dt.Columns.Add(ct_Col_BLGoodsCdDerivedNo	, typeof(Int32));		// ＢＬ商品コード枝番
                //dt.Columns[ct_Col_BLGoodsCdDerivedNo		].DefaultValue = 0;		
                
				dt.Columns.Add(ct_Col_BLGoodsFullName		, typeof(string));		// ＢＬ商品コード名称 (全角)
				dt.Columns[ct_Col_BLGoodsFullName			].DefaultValue = "";		
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //--- ADD 2008.08.12 ---------->>>>>
                dt.Columns.Add(ct_Col_BfSectionGuideSnm, typeof(string));		    // 移動元拠点ガイド略称
                dt.Columns[ct_Col_BfSectionGuideSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_AfSectionGuideSnm, typeof(string));		    // 移動先拠点ガイド略称
                dt.Columns[ct_Col_AfSectionGuideSnm].DefaultValue = "";

                dt.Columns.Add(ct_Col_InputDay, typeof(string));		            // 入力日付
                dt.Columns[ct_Col_InputDay].DefaultValue = "";

                dt.Columns.Add(ct_Col_StockMoveSlipCnt, typeof(string));		    // 移動枚数
                dt.Columns[ct_Col_StockMoveSlipCnt].DefaultValue = "";
                //--- ADD 2008.08.12 ----------<<<<<

                // ---ADD 2009/03/16 不具合対応[12331] ----------------------------->>>>>
                dt.Columns.Add(ct_Col_SlipPrintFinishCd, typeof(Int32));		    // 伝票発行済区分
                dt.Columns[ct_Col_SlipPrintFinishCd].DefaultValue = 0;

                dt.Columns.Add(ct_Col_StockMoveFormal, typeof(Int32));		        // 在庫移動形式
                dt.Columns[ct_Col_StockMoveFormal].DefaultValue = 0;
                // ---ADD 2009/03/16 不具合対応[12331] -----------------------------<<<<<

                // ADD 2009/06/11 ------>>>
                dt.Columns.Add(ct_Col_SlipDivName, typeof(string));		            // 伝票区分
                dt.Columns[ct_Col_SlipDivName].DefaultValue = "";
                // ADD 2009/06/11 ------<<<
            }
		}
		#endregion
		#endregion
	}
}
