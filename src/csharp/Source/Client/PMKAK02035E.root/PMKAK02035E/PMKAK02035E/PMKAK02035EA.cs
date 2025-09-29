//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表抽出結果データテーブルスキーマクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 仕入返品予定一覧表抽出結果データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入返品予定一覧表の抽出結果テーブルスキーマです。</br>
	/// <br>Programmer : FSI高橋 文彰</br>
	/// <br>Date       :  2013/01/28</br>
	/// </remarks>
    public class PMKAK02035EA
    {
        #region Public Members
        /// <summary>仕入返品予定一覧表データテーブル名</summary>
        public const string ct_Tbl_StockRetDtl                  = "Tbl_StockRetDtl";
        /// <summary>仕入返品予定一覧表バッファデータテーブル名</summary>
        public const string ct_Tbl_StockRetBuffDtl              = "Tbl_ArrivalBuffDtl";

        #region 仕入返品予定一覧表カラム情報
        /// <summary>拠点コード</summary>
        public const string ct_Col_SectionCode                 = "SectionCode";
        /// <summary>拠点ガイド名称</summary>           
        public const string ct_Col_SectionGuideNm              = "SectionGuideNm";
		/// <summary>仕入伝票番号</summary>             
		public const string ct_Col_SupplierSlipNo              = "SupplierSlipNo";
		/// <summary>入力日付</summary>                 
		public const string ct_Col_InputDay                    = "InputDay";
		/// <summary>仕入日付</summary>                 
		public const string ct_Col_StockDate                   = "StockDate";
        /// <summary>仕入先コード</summary>               
        public const string ct_Col_SupplierCd                  = "SupplierCd";
        /// <summary>仕入先略称</summary>               
        public const string ct_Col_SupplierSnm                 = "SupplierSnm";
		/// <summary>商品メーカーコード</summary>       
        public const string ct_Col_GoodsMakerCd                = "GoodsMakerCd";
        /// <summary>メーカー名称</summary>             
        public const string ct_Col_MakerName                   = "MakerName";
        /// <summary>商品番号</summary>                 
        public const string ct_Col_GoodsNo                     = "GoodsNo";
        /// <summary>商品名称</summary>                 
        public const string ct_Col_GoodsName                   = "GoodsName";
		/// <summary>仕入数</summary>
		public const string ct_Col_StockCount                  = "StockCount";
		/// <summary>仕入単価（税込，浮動）</summary>
		public const string ct_Col_StockUnitTaxPriceFl         = "StockUnitTaxPriceFl";
		/// <summary>仕入単価（税抜，浮動）</summary>
		public const string ct_Col_StockUnitPriceFl            = "StockUnitPriceFl";
		/// <summary>仕入金額（税込み）</summary>
		public const string ct_Col_StockPriceTaxInc            = "StockPriceTaxInc";
		/// <summary>仕入金額（税抜き）</summary>
		public const string ct_Col_StockPriceTaxExc            = "StockPriceTaxExc";
		/// <summary>課税区分</summary>
		public const string ct_Col_TaxationCode                = "TaxationCode";
		/// <summary>返品予定区分</summary>
        public const string ct_Col_ReturnedGoodsType           = "ReturnedGoodsType";
		/// <summary>帳票タイトル</summary>
		public const string ct_Col_ListTitle                   = "ListTitle";
        /// <summary>仕入伝票備考1</summary>
        public const string ct_Col_SupplierSlipNote1           = "SupplierSlipNote1";
        /// <summary>仕入先消費税転嫁方式コード</summary>
        public const string ct_Col_SuppCTaxLayCd               = "SuppCTaxLayCd";
        /// <summary>BL商品コード</summary>
        public const string ct_Col_BLGoodsCode                 = "BLGoodsCode";
        /// <summary>BL商品名称</summary>
        public const string ct_Col_BLGoodsName                 = "BLGoodsName";
        /// <summary>仕入金額消費税額</summary>
        public const string ct_Col_StockPriceConsTax           = "StockPriceConsTax";
        /// <summary>伝票区分</summary>
        public const string ct_Col_SupplierSlipCd              = "SupplierSlipCd";
        /// <summary>税抜伝票金額</summary>
        public const string ct_Col_StockTtlPricTaxExc          = "StockTtlPricTaxExc";
        /// <summary>税込伝票金額</summary>
        public const string ct_Col_StockTtlPricTaxInc          = "StockTtlPricTaxInc";
        /// <summary>伝票消費税</summary>
        public const string ct_Col_SlpConsTax                  = "SlpConsTax";
        /// <summary>明細消費税</summary>
        public const string ct_Col_DtlConsTax                  = "DtlConsTax";
        /// <summary>税抜定価</summary>
        public const string ct_Col_ListPriceTaxExc             = "ListPriceTaxExc";
        /// <summary>税込定価</summary>
        public const string ct_Col_ListPriceTaxInc             = "ListPriceTaxInc";

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 仕入返品予定一覧表抽出結果データテーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入返品予定一覧表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public PMKAK02035EA()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds)
        {
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(ct_Tbl_StockRetDtl)))
            {
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_StockRetDtl].Clear();
            }
            else
            {
                CreateSaleConfTable(ref ds, 0);

            }

            // 仕入チェックリストバッファデータテーブル
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(ct_Tbl_StockRetBuffDtl)))
            {
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_StockRetBuffDtl].Clear();
            }
            else
            {
                CreateSaleConfTable(ref ds, 1);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 仕入返品予定一覧表抽出結果作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
        {
            DataTable dt = null;
            if (buffCheck == 0)
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_StockRetDtl);
                dt = ds.Tables[ct_Tbl_StockRetDtl];
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_StockRetBuffDtl);
                dt = ds.Tables[ct_Tbl_StockRetBuffDtl];
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
			// 入力日付
			dt.Columns.Add(ct_Col_InputDay, typeof(DateTime));
			dt.Columns[ct_Col_InputDay].DefaultValue = null;
			// 仕入日付
			dt.Columns.Add(ct_Col_StockDate, typeof(DateTime));
			dt.Columns[ct_Col_StockDate].DefaultValue = null;
            // 仕入先コード
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;
            // 仕入先略称
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";
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
			// 返品仕入区分
            dt.Columns.Add(ct_Col_ReturnedGoodsType, typeof(string));
            dt.Columns[ct_Col_ReturnedGoodsType].DefaultValue = "";
			// 帳票タイトル
			dt.Columns.Add(ct_Col_ListTitle, typeof(string));
			dt.Columns[ct_Col_ListTitle].DefaultValue = "";
            // 仕入伝票備考1
            dt.Columns.Add(ct_Col_SupplierSlipNote1, typeof(string));
            dt.Columns[ct_Col_SupplierSlipNote1].DefaultValue = "";
            // 仕入先消費税転嫁方式コード
            dt.Columns.Add(ct_Col_SuppCTaxLayCd, typeof(Int32));
            dt.Columns[ct_Col_SuppCTaxLayCd].DefaultValue = 0;
            // BL商品コード
            dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_BLGoodsCode].DefaultValue = 0;
            // BL商品名称
            dt.Columns.Add(ct_Col_BLGoodsName, typeof(string));
            dt.Columns[ct_Col_BLGoodsName].DefaultValue = 0;
            // 伝票区分
            dt.Columns.Add(ct_Col_SupplierSlipCd, typeof(string));
            dt.Columns[ct_Col_SupplierSlipCd].DefaultValue = 0;
            // 税抜伝票金額
            dt.Columns.Add(ct_Col_StockTtlPricTaxExc, typeof(string));
            dt.Columns[ct_Col_StockTtlPricTaxExc].DefaultValue = 0;
            // 税込伝票金額
            dt.Columns.Add(ct_Col_StockTtlPricTaxInc, typeof(string));
            dt.Columns[ct_Col_StockTtlPricTaxInc].DefaultValue = 0;
            // 伝票消費税
            dt.Columns.Add(ct_Col_SlpConsTax, typeof(string));
            dt.Columns[ct_Col_SlpConsTax].DefaultValue = 0;
            // 明細消費税
            dt.Columns.Add(ct_Col_DtlConsTax, typeof(string));
            dt.Columns[ct_Col_DtlConsTax].DefaultValue = 0;
            // 税抜定価
            dt.Columns.Add(ct_Col_ListPriceTaxExc, typeof(string));
            dt.Columns[ct_Col_ListPriceTaxExc].DefaultValue = 0;
            // 税込定価
            dt.Columns.Add(ct_Col_ListPriceTaxInc, typeof(string));
            dt.Columns[ct_Col_ListPriceTaxInc].DefaultValue = 0;
        }
        #endregion
    }
}