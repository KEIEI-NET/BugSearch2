//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入荷一覧表
// プログラム概要   : 入荷一覧表抽出結果データテーブルスキーマクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 立花 裕輔
// 作 成 日  2007/09/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馬淵 愛
// 修 正 日  2008/01/28  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/06/25  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/08  修正内容 : 障害対応9803、11150、11153、12398
//----------------------------------------------------------------------------//

using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 入荷一覧表抽出結果データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入荷一覧表の抽出結果テーブルスキーマです。</br>
	/// <br>Programmer : 96186　立花 裕輔</br>
	/// <br>Date       : 2007.09.03</br>
	/// ---------------------------------------------------------------------
	/// <br>UpdateNote	: 仕様変更</br>
	/// <br>Programmer	: 30191 馬淵 愛</br>
	/// <br>Date		: 2008.01.28</br>
    /// ---------------------------------------------------------------------
    /// <br>UpdateNote	: 仕様変更</br>
    /// <br>Programmer  : 30415 柴田 倫幸</br>
    /// <br>Date        : 2008/06/25</br>
    /// ---------------------------------------------------------------------
    /// <br>UpdateNote	: 障害対応9803、11150、11153、12398</br>
    /// <br>Programmer  : 上野 俊治</br>
    /// <br>Date        : 2009/04/08</br>
	/// </remarks>
    public class DCKOU02305EA
    {
        #region Public Members
        ///// <summary>入荷一覧表データテーブル名</summary>
        //public const string CT_StockTableDataTable = "StockTableDataTable";
        ///// <summary>入荷一覧表バッファデータテーブル名</summary>
        //public const string CT_StockTableBuffDataTable = "StockTableBuffDataTable";

        /// <summary>入荷一覧表データテーブル名</summary>
        public const string ct_Tbl_ArrivalDtl      = "Tbl_ArrivalDtl";
        /// <summary>入荷一覧表バッファデータテーブル名</summary>
        public const string ct_Tbl_ArrivalBuffDtl  = "Tbl_ArrivalBuffDtl";

        #region 入荷一覧表カラム情報

        /// <summary>拠点コード</summary>
        public const string ct_Col_SectionCode          = "SectionCode";
                                                    
        /// <summary>拠点ガイド名称</summary>           
        public const string ct_Col_SectionGuideNm       = "SectionGuideNm";

		/// <summary>仕入伝票番号</summary>             
		public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";

		/// <summary>仕入伝票区分</summary>
		public const string ct_Col_SupplierSlipCd = "SupplierSlipCd";

		/// <summary>買掛区分</summary>
		public const string ct_Col_AccPayDivCd = "AccPayDivCd";

		/// <summary>赤伝区分</summary>
		public const string ct_Col_DebitNoteDiv = "DebitNoteDiv";

		/// <summary>入力日付</summary>                 
		public const string ct_Col_InputDay = "InputDay";

		/// <summary>入荷日付</summary>                 
		public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";

		/// <summary>仕入日付</summary>                 
		public const string ct_Col_StockDate = "StockDate";

        /* --- DEL 2008/06/25 -------------------------------->>>>>
		/// <summary>得意先コード</summary>             
		public const string ct_Col_CustomerCode = "CustomerCode";

		/// <summary>得意先名称</summary>               
		public const string ct_Col_CustomerName = "CustomerName";
           --- DEL 2008/06/25 --------------------------------<<<<< */

        // --- ADD 2008/06/25 -------------------------------->>>>>
        /// <summary>仕入先コード</summary>               
        public const string ct_Col_SupplierCd = "SupplierCd";

        /// <summary>仕入先略称</summary>               
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        // --- ADD 2008/06/25 --------------------------------<<<<< 

		/// <summary>支払先コード</summary>             
		public const string ct_Col_PayeeCode = "PayeeCode";

		/// <summary>支払先名称</summary>               
		public const string ct_Col_PayeeSnm = "PayeeSnm";

		/// <summary>仕入担当者コード</summary>         
		public const string ct_Col_StockAgentCode = "StockAgentCode";

		/// <summary>仕入担当者名称</summary>           
		public const string ct_Col_StockAgentName = "StockAgentName";

		/// <summary>仕入入力者コード</summary>         
		public const string ct_Col_StockInputCode = "StockInputCode";

		/// <summary>仕入入力者名称</summary>           
		public const string ct_Col_StockInputName = "StockInputName";

		/// <summary>相手先伝票番号</summary>
		public const string ct_Col_PartySaleSlipNum = "PartySaleSlipNum";

		/// <summary>仕入行番号</summary>             
		public const string ct_Col_StockRowNo = "StockRowNo";

		/// <summary>仕入伝票区分（明細）</summary>
		public const string ct_Col_StockSlipCdDtl = "StockSlipCdDtl";

		/// <summary>商品メーカーコード</summary>       
        public const string ct_Col_GoodsMakerCd         = "GoodsMakerCd";
                                                    
        /// <summary>メーカー名称</summary>             
        public const string ct_Col_MakerName            = "MakerName";
                                                    
        /// <summary>商品番号</summary>                 
        public const string ct_Col_GoodsNo              = "GoodsNo";
                                                    
        /// <summary>商品名称</summary>                 
        public const string ct_Col_GoodsName            = "GoodsName";

		/// <summary>仕入数</summary>
		public const string ct_Col_StockCount = "StockCount";

		/// <summary>発注数量</summary>
		public const string ct_Col_OrderCnt = "OrderCnt";

		/// <summary>発注調整数</summary>
		public const string ct_Col_OrderAdjustCnt = "OrderAdjustCnt";

		/// <summary>発注残数</summary>
		public const string ct_Col_OrderRemainCnt = "OrderRemainCnt";

        /* --- DEL 2008/06/25 -------------------------------->>>>>
		/// <summary>単位コード</summary>
		public const string ct_Col_UnitCode = "UnitCode";

		/// <summary>単位名称</summary>
		public const string ct_Col_UnitName = "UnitName";
           --- DEL 2008/06/25 --------------------------------<<<<< */

		/// <summary>仕入単価（税込，浮動）</summary>
		public const string ct_Col_StockUnitTaxPriceFl = "StockUnitTaxPriceFl";

		/// <summary>仕入単価（税抜，浮動）</summary>
		public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";

		/// <summary>仕入金額（税込み）</summary>
		public const string ct_Col_StockPriceTaxInc = "StockPriceTaxInc";

		/// <summary>仕入金額（税抜き）</summary>
		public const string ct_Col_StockPriceTaxExc = "StockPriceTaxExc";

		/// <summary>課税区分</summary>
		public const string ct_Col_TaxationCode = "TaxationCode";

		/// <summary>倉庫コード</summary>               
		public const string ct_Col_WarehouseCode = "WarehouseCode";

		/// <summary>倉庫名称</summary>                 
		public const string ct_Col_WarehouseName = "WarehouseName";

		/// <summary>明細備考</summary>
        public const string ct_Col_DtlNote              = "DtlNote";

		/// <summary>未計上数</summary>
		public const string ct_Col_UnAddUpCnt = "UnAddUpCnt";

		/// <summary>未計上金額</summary>
		public const string ct_Col_UnAddUpAmount = "UnAddUpAmount";

		/// <summary>計上数</summary>
		public const string ct_Col_AddUpCnt = "AddUpCnt";

		/// <summary>伝票区分名称</summary>
		public const string ct_Col_TransactionsDivName = "TransactionsDivName";

		/// <summary>赤伝区分名称（明細印字部分）</summary>
		public const string ct_Col_DebitNoteDivNameDtl = "DebitNoteDivNameDtl";

		/// <summary>帳票タイトル</summary>
		public const string ct_Col_ListTitle = "ListTitle";

		//// --- キーブレイク用 DataTable列名 --- //
		///// <summary> 小計出力キーブレイク </summary>
		//public const string ct_Col_MiniTotal_KeyBleak = "MiniTotal_KeyBleak";

        // --- DataTable項目フォーマット形式 --- //
        /// <summary>入荷 表示用日付フォーマット</summary>
        public const string ct_DateFomat                = "YYYY/MM/DD";

        // --- ADD 2009/04/08 -------------------------------->>>>>
        /// <summary>仕入計上日付</summary>
        public const string ct_Col_StockAddUpADate = "StockAddUpADate";

        /// <summary>仕入伝票備考1</summary>
        public const string ct_Col_SupplierSlipNote1 = "SupplierSlipNote1";

        /// <summary>仕入伝票備考2</summary>
        public const string ct_Col_SupplierSlipNote2 = "SupplierSlipNote2";

        /// <summary>仕入先消費税転嫁方式コード</summary>
        public const string ct_Col_SuppCTaxLayCd = "SuppCTaxLayCd";

        /// <summary>BL商品コード</summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";

        /// <summary>BL商品コード名称（全角）</summary>
        public const string ct_Col_BLGoodsFullName = "BLGoodsFullName";

        /// <summary>仕入在庫取寄せ区分</summary>
        public const string ct_Col_StockOrderDivCd = "StockOrderDivCd";

        /// <summary>仕入在庫取寄せ区分名称</summary>
        public const string ct_Col_StockOrderDivName = "StockOrderDivName";

        /// <summary>仕入金額消費税額</summary>
        public const string ct_Col_StockPriceConsTax = "StockPriceConsTax";

        /// <summary>入荷残数(発注残数)</summary>
        public const string ct_Col_ArrivalRemainCnt = "ArrivalRemainCnt";

        /// <summary>入荷残金額(発注残数×仕入単価(税抜))</summary>
        public const string ct_Col_ArrivalRemainPrice = "ArrivalRemainPrice";
        // --- ADD 2009/04/08 --------------------------------<<<<<

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 入荷一覧表抽出結果データテーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷一覧表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public DCKOU02305EA()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds)
        {
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(ct_Tbl_ArrivalDtl)))
            {
                // TODO:テーブルが存在するときはクリアーするのみ
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_ArrivalDtl].Clear();
            }
            else
            {
                CreateSaleConfTable(ref ds, 0);

            }

            // 仕入チェックリストバッファデータテーブル------------------------------------------
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(ct_Tbl_ArrivalBuffDtl)))
            {
                // TODO:テーブルが存在するときはクリアーするのみ
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_ArrivalBuffDtl].Clear();
            }
            else
            {
                CreateSaleConfTable(ref ds, 1);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 入荷一覧表抽出結果作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
        {
            DataTable dt = null;
            if (buffCheck == 0)
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_ArrivalDtl);
                dt = ds.Tables[ct_Tbl_ArrivalDtl];
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_ArrivalBuffDtl);
                dt = ds.Tables[ct_Tbl_ArrivalBuffDtl];
            }

            // 拠点コード
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = "";

            // 拠点ガイド名称
            dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string));
            dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";

			// 仕入伝票番号
			dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(string));
			dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = "";

			// 仕入伝票区分
			dt.Columns.Add(ct_Col_SupplierSlipCd, typeof(Int32));
			dt.Columns[ct_Col_SupplierSlipCd].DefaultValue = 0;

			// 買掛区分
			dt.Columns.Add(ct_Col_AccPayDivCd, typeof(Int32));
			dt.Columns[ct_Col_AccPayDivCd].DefaultValue = 0;

			// 赤伝区分
			dt.Columns.Add(ct_Col_DebitNoteDiv, typeof(Int32));
			dt.Columns[ct_Col_DebitNoteDiv].DefaultValue = 0;

			// 入力日付
			dt.Columns.Add(ct_Col_InputDay, typeof(DateTime));
			dt.Columns[ct_Col_InputDay].DefaultValue = null;

			// 入荷日付
            dt.Columns.Add(ct_Col_ArrivalGoodsDay, typeof(DateTime));
			dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = null;

			// 仕入日付
			dt.Columns.Add(ct_Col_StockDate, typeof(DateTime));
			dt.Columns[ct_Col_StockDate].DefaultValue = null;

            /* --- DEL 2008/06/25 -------------------------------->>>>>
			// 得意先コード
			dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
			dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

			// 得意先名称
			dt.Columns.Add(ct_Col_CustomerName, typeof(string));
			dt.Columns[ct_Col_CustomerName].DefaultValue = "";
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            // 仕入先コード
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;

            // 仕入先略称
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";
            // --- ADD 2008/06/25 --------------------------------<<<<< 

			// 支払先コード
			dt.Columns.Add(ct_Col_PayeeCode, typeof(Int32));
			dt.Columns[ct_Col_PayeeCode].DefaultValue = 0;

			// 支払先名称
			dt.Columns.Add(ct_Col_PayeeSnm, typeof(string));
			dt.Columns[ct_Col_PayeeSnm].DefaultValue = "";

			// 仕入担当者コード
			dt.Columns.Add(ct_Col_StockAgentCode, typeof(string));
			dt.Columns[ct_Col_StockAgentCode].DefaultValue = "";

			// 仕入担当者名称
			dt.Columns.Add(ct_Col_StockAgentName, typeof(string));
			dt.Columns[ct_Col_StockAgentName].DefaultValue = "";

			// 仕入入力者コード
            dt.Columns.Add(ct_Col_StockInputCode, typeof(string));
            dt.Columns[ct_Col_StockInputCode].DefaultValue = "";

            // 仕入入力者名称
            dt.Columns.Add(ct_Col_StockInputName, typeof(string));
            dt.Columns[ct_Col_StockInputName].DefaultValue = "";

			// 相手先伝票番号
			dt.Columns.Add(ct_Col_PartySaleSlipNum, typeof(string));
			dt.Columns[ct_Col_PartySaleSlipNum].DefaultValue = "";

			// 仕入行番号
			dt.Columns.Add(ct_Col_StockRowNo, typeof(Int32));
			dt.Columns[ct_Col_StockRowNo].DefaultValue = 0;

			// 仕入伝票区分（明細）
			dt.Columns.Add(ct_Col_StockSlipCdDtl, typeof(Int32));
			dt.Columns[ct_Col_StockSlipCdDtl].DefaultValue = 0;

            // 商品メーカーコード
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;

            // メーカー名称
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = "";

            // 商品番号
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = "";

            // 商品名称
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = "";

			// 仕入数
			dt.Columns.Add(ct_Col_StockCount, typeof(Double));
			dt.Columns[ct_Col_StockCount].DefaultValue = 0;

			// 発注数量
			dt.Columns.Add(ct_Col_OrderCnt, typeof(Double));
			dt.Columns[ct_Col_OrderCnt].DefaultValue = 0;

			// 発注調整数
			dt.Columns.Add(ct_Col_OrderAdjustCnt, typeof(Double));
			dt.Columns[ct_Col_OrderAdjustCnt].DefaultValue = 0;

			// 発注残数
			dt.Columns.Add(ct_Col_OrderRemainCnt, typeof(Double));
			dt.Columns[ct_Col_OrderRemainCnt].DefaultValue = 0;

            /* --- DEL 2008/06/25 -------------------------------->>>>>
			// 単位コード
			dt.Columns.Add(ct_Col_UnitCode, typeof(Int32));
			dt.Columns[ct_Col_UnitCode].DefaultValue = 0;

			// 単位名称
			dt.Columns.Add(ct_Col_UnitName, typeof(string));
			dt.Columns[ct_Col_UnitName].DefaultValue = "";
               --- DEL 2008/06/25 --------------------------------<<<<< */

			// 仕入単価（税込，浮動）
			dt.Columns.Add(ct_Col_StockUnitTaxPriceFl, typeof(Double));
			dt.Columns[ct_Col_StockUnitTaxPriceFl].DefaultValue = 0;

			// 仕入単価（税抜，浮動）
			dt.Columns.Add(ct_Col_StockUnitPriceFl, typeof(Double));
			dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = 0;

			// 仕入金額（税込み）
			dt.Columns.Add(ct_Col_StockPriceTaxInc, typeof(Int64));
			dt.Columns[ct_Col_StockPriceTaxInc].DefaultValue = 0;

			// 仕入金額（税抜き）
			dt.Columns.Add(ct_Col_StockPriceTaxExc, typeof(Int64));
			dt.Columns[ct_Col_StockPriceTaxExc].DefaultValue = 0;

			// 課税区分
			dt.Columns.Add(ct_Col_TaxationCode, typeof(Int32));
			dt.Columns[ct_Col_TaxationCode].DefaultValue = 0;

			// 倉庫コード
            dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
            dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";

            // 倉庫名称
            dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
            dt.Columns[ct_Col_WarehouseName].DefaultValue = "";

			// 明細備考
			dt.Columns.Add(ct_Col_DtlNote, typeof(string));
			dt.Columns[ct_Col_DtlNote].DefaultValue = "";

			// 伝票区分名称
            dt.Columns.Add(ct_Col_TransactionsDivName, typeof(string));
            dt.Columns[ct_Col_TransactionsDivName].DefaultValue = "";

            // 未計上数
            dt.Columns.Add(ct_Col_UnAddUpCnt, typeof(Double));
            dt.Columns[ct_Col_UnAddUpCnt].DefaultValue = 0;

            // 未計上金額
            dt.Columns.Add(ct_Col_UnAddUpAmount, typeof(Double));
            dt.Columns[ct_Col_UnAddUpAmount].DefaultValue = 0;

            // 計上数
            dt.Columns.Add(ct_Col_AddUpCnt, typeof(Double));
            dt.Columns[ct_Col_AddUpCnt].DefaultValue = 0;

			// 赤伝区分名称（明細印字部分）
			dt.Columns.Add(ct_Col_DebitNoteDivNameDtl, typeof(string));
			dt.Columns[ct_Col_DebitNoteDivNameDtl].DefaultValue = 0;

			// 帳票タイトル
			dt.Columns.Add(ct_Col_ListTitle, typeof(string));
			dt.Columns[ct_Col_ListTitle].DefaultValue = "";

			// --- キーブレイク用 DataTable列名 --- //
			// キーブレイク
			//dt.Columns.Add(ct_Col_MiniTotal_KeyBleak, typeof(string));
			//dt.Columns[ct_Col_MiniTotal_KeyBleak].DefaultValue = "";

            // --- ADD 2009/04/08 -------------------------------->>>>>
            // 仕入計上日付
            dt.Columns.Add(ct_Col_StockAddUpADate, typeof(DateTime));
            dt.Columns[ct_Col_StockAddUpADate].DefaultValue = null;
            // 仕入伝票備考1
            dt.Columns.Add(ct_Col_SupplierSlipNote1, typeof(string));
            dt.Columns[ct_Col_SupplierSlipNote1].DefaultValue = "";
            // 仕入伝票備考2
            dt.Columns.Add(ct_Col_SupplierSlipNote2, typeof(string));
            dt.Columns[ct_Col_SupplierSlipNote2].DefaultValue = "";
            // 仕入先消費税転嫁方式コード
            dt.Columns.Add(ct_Col_SuppCTaxLayCd, typeof(Int32));
            dt.Columns[ct_Col_SuppCTaxLayCd].DefaultValue = 0;
            // BL商品コード
            dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
            // BL商品コード名称（全角）
            dt.Columns.Add(ct_Col_BLGoodsFullName, typeof(string));
            dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = "";
            // 仕入在庫取寄せ区分
            dt.Columns.Add(ct_Col_StockOrderDivCd, typeof(Int32));
            dt.Columns[ct_Col_StockOrderDivCd].DefaultValue = 0;
            // 仕入在庫取寄せ区分名称
            dt.Columns.Add(ct_Col_StockOrderDivName, typeof(string));
            dt.Columns[ct_Col_StockOrderDivName].DefaultValue = "";
            // 仕入金額消費税額
            dt.Columns.Add(ct_Col_StockPriceConsTax, typeof(Int64));
            dt.Columns[ct_Col_StockPriceConsTax].DefaultValue = 0;
            // 入荷残数(発注残数)
            dt.Columns.Add(ct_Col_ArrivalRemainCnt, typeof(Double));
            dt.Columns[ct_Col_ArrivalRemainCnt].DefaultValue = 0;
            // 入荷残金額(発注残数×仕入単価(税抜))
            dt.Columns.Add(ct_Col_ArrivalRemainPrice, typeof(Double));
            dt.Columns[ct_Col_ArrivalRemainPrice].DefaultValue = 0;
            // --- ADD 2009/04/08 --------------------------------<<<<<
		}

        #endregion
    }
}