using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 仕入確認表(伝票単位)抽出結果データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 仕入確認表(伝票単位)の抽出結果テーブルスキーマです。</br>
	/// <br>Programmer : 96186　立花裕輔</br>
	/// <br>Date       : 2008.01.16</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 尹安</br>
    /// <br>Date       : 2020/02/27</br>
    /// <br>Update Note: 11800255-00　インボイス対応（税率別合計金額不具合修正） </br>
    /// <br>Programmer : 陳艶丹 </br>
    /// <br>Date       : 2022/09/28</br>
	/// </remarks>
	public class MAKON02249EB
	{
		#region Public Members
        /// <summary>仕入確認表(伝票単位)データテーブル名</summary>
        public const string CT_StockConfSlipTtlDataTable = "StockConfSlipTtlDataTable";

		#region 仕入確認表（伝票単位）カラム情報
        /// <summary>拠点コード</summary>
		public const string CT_StockConfSlipTtl_SectionCodeRF = "SectionCodeRF";
        /// <summary>拠点ガイド名称</summary>
		public const string CT_StockConfSlipTtl_SectionGuideNmRF = "SectionGuideNmRF";

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// <summary>得意先コード</summary>
        //public const string CT_StockConfSlipTtl_CustomerCodeRF = "CustomerCodeRF";
        ///// <summary>得意先名称</summary>
        //public const string CT_StockConfSlipTtl_CustomerSnmRF = "CustomerSnmRF";
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>仕入先コード</summary>
        public const string CT_StockConfSlipTtl_SupplierCd = "SupplierCd";
        /// <summary>仕入先名称</summary>
        public const string CT_StockConfSlipTtl_SupplierSnm = "SupplierSnm";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// <summary>入力日付</summary>
		public const string CT_StockConfSlipTtl_InputDayRF = "InputDayRF";
		/// <summary>入力日付(印刷)</summary>
		public const string CT_StockConfSlipTtl_InputDayNmRF = "InputDayNmRF";
        /// <summary>入荷日付</summary>
		public const string CT_StockConfSlipTtl_ArrivalGoodsDayRF = "ArrivalGoodsDayRF";
		/// <summary>仕入日付</summary>
		public const string CT_StockConfSlipTtl_StockDateRF = "StockDateRF";
		/// <summary>仕入日付(印刷)</summary>
		public const string CT_StockConfSlipTtl_StockDateNmRF = "StockDateNmRF";
        /// <summary>仕入形式</summary>
		public const string CT_StockConfSlipTtl_SupplierFormalRF = "SupplierFormalRF";
        /// <summary>仕入形式名</summary>
		public const string CT_StockConfSlipTtl_SupplierFormalNmRF = "SupplierFormalNmRF";
        /// <summary>仕入伝票番号</summary>
		public const string CT_StockConfSlipTtl_SupplierSlipNoRF = "SupplierSlipNoRF";
		/// <summary>相手先伝票番号</summary>
		public const string CT_StockConfSlipTtl_PartySaleSlipNumRF = "PartySaleSlipNumRF";
        /// <summary>仕入伝票区分</summary>
		public const string CT_StockConfSlipTtl_SupplierSlipCdRF = "SupplierSlipCdRF";
        /// <summary>仕入伝票区分名</summary>
		public const string CT_StockConfSlipTtl_SupplierSlipNmRF = "SupplierSlipNmRF";

        /// <summary>仕入金額計（税抜き）</summary>
		public const string CT_StockConfSlipTtl_StockTtlPricTaxExcRF = "StockTtlPricTaxExcRF";
		/// <summary>仕入金額消費税額</summary>
		public const string CT_StockConfSlipTtl_StockPriceConsTaxRF = "StockPriceConsTaxRF";
		/// <summary>仕入金額計（税込み）</summary>
		public const string CT_StockConfSlipTtl_StockPriceTaxIncRF = "StockPriceTaxIncRF";
		
		/// <summary>伝票枚数(売上)</summary>
		public const string CT_StockConfSlipTtl_SalSlipCntRF = "SalSlipCntRF";
		/// <summary>伝票枚数(返品値引)</summary>
		public const string CT_StockConfSlipTtl_DisSlipCntRF = "DisSlipCntRF";
		/// <summary>伝票枚数(合計)</summary>
		public const string CT_StockConfSlipTtl_TotleSlipCntRF = "TotleSlipCntRF";

		/// <summary>仕入金額(売上)</summary>
		public const string CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF = "SalStockTtlPricTaxExcRF";
		/// <summary>消費税(売上)</summary>
		public const string CT_StockConfSlipTtl_SalStockPriceConsTaxRF = "SalStockPriceConsTaxRF";
		/// <summary>合計金額(売上)</summary>
		public const string CT_StockConfSlipTtl_SalTotalPriceRF = "SalTotalPriceRF";

        // 2009.01.09 30413 犬飼 値引の金額を追加 >>>>>>START
        ///// <summary>仕入金額(返品値引)</summary>
        //public const string CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF = "DisStockTtlPricTaxExcRF";
        ///// <summary>消費税(返品値引)</summary>
        //public const string CT_StockConfSlipTtl_DisStockPriceConsTaxRF = "DisStockPriceConsTaxRF";
        ///// <summary>合計金額(返品値引)</summary>
        //public const string CT_StockConfSlipTtl_DisTotalPriceRF = "DisTotalPriceRF";
        /// <summary>仕入金額(返品)</summary>
        public const string CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF = "RetGdsStockTtlPricTaxExcRF";
        /// <summary>消費税(返品)</summary>
        public const string CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF = "RetGdsStockPriceConsTaxRF";
        /// <summary>合計金額(返品)</summary>
        public const string CT_StockConfSlipTtl_RetGdsTotalPriceRF = "RetGdsTotalPriceRF";

        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
        /// <summary> 消費税税率 </summary>
        public const String CT_Col_ConsTaxRate = "SupplierConsTaxRate";

        #region 「消費税税率１」
        /// <summary>Title_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_Title = "TaxRate1Title";
        /// <summary>仕入枚数_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_SalSlipCntRF = "TaxRate1SalSlipCntRF";
        /// <summary>仕入金額計（税抜き）_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF = "TaxRate1StockTtlPricTaxExcRF";
        /// <summary>仕入金額消費税額_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_StockPriceConsTaxRF = "TaxRate1StockPriceConsTaxRF";
        /// <summary>仕入金額計（税込み）_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF = "TaxRate1StockPriceTaxIncRF";

        /// <summary>Title(返品)_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_RetTitle = "TaxRate1RetTitle";
        /// <summary>仕入枚数(返品値引)_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_DisSlipCntRF = "TaxRate1DisSlipCntRF";
        /// <summary>仕入金額(返品)_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF = "TaxRate1RetGdsStockTtlPricTaxExcRF";
        /// <summary>消費税(返品)_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_RetGdsStockPriceConsTaxRF = "TaxRate1RetGdsStockPriceConsTaxRF";
        /// <summary>合計金額(返品)_税率１</summary>
        public const string CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF = "TaxRate1RetGdsTotalPriceRF";
        #endregion

        #region 「消費税税率２」
        /// <summary>Title_税率2</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_Title = "TaxRate2Title";
        /// <summary>仕入枚数_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_SalSlipCntRF = "TaxRate2SalSlipCntRF";
        /// <summary>仕入金額計（税抜き）_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF = "TaxRate2StockTtlPricTaxExcRF";
        /// <summary>仕入金額消費税額_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_StockPriceConsTaxRF = "TaxRate2StockPriceConsTaxRF";
        /// <summary>仕入金額計（税込み）_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF = "TaxRate2StockPriceTaxIncRF";

        /// <summary>Title(返品)_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_RetTitle = "TaxRate2RetTitle";
        /// <summary>仕入枚数(返品値引)_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_DisSlipCntRF = "TaxRate2DisSlipCntRF";
        /// <summary>仕入金額(返品)_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF = "TaxRate2RetGdsStockTtlPricTaxExcRF";
        /// <summary>消費税(返品)_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_RetGdsStockPriceConsTaxRF = "TaxRate2RetGdsStockPriceConsTaxRF";
        /// <summary>合計金額(返品)_税率２</summary>
        public const string CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF = "TaxRate2RetGdsTotalPriceRF";
        #endregion

        #region 「消費税税率その他」
        /// <summary>Title_その他</summary>
        public const string CT_StockConfSlipTtl_Other_Title = "OtherTitle";
        /// <summary>仕入枚数_その他</summary>
        public const string CT_StockConfSlipTtl_Other_SalSlipCntRF = "OtherSalSlipCntRF";
        /// <summary>仕入金額計（税抜き）_その他</summary>
        public const string CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF = "OtherStockTtlPricTaxExcRF";
        /// <summary>仕入金額消費税額_その他</summary>
        public const string CT_StockConfSlipTtl_Other_StockPriceConsTaxRF = "OtherStockPriceConsTaxRF";
        /// <summary>仕入金額計（税込み）_その他</summary>
        public const string CT_StockConfSlipTtl_Other_StockPriceTaxIncRF = "OtherStockPriceTaxIncRF";

        /// <summary>Title_その他</summary>
        public const string CT_StockConfSlipTtl_Other_RetTitle = "OtherRetTitle";
        /// <summary>仕入枚数_その他</summary>
        public const string CT_StockConfSlipTtl_Other_DisSlipCntRF = "OtherDisSlipCntRF";
        /// <summary>仕入金額(返品)_その他</summary>
        public const string CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF = "OtherRetGdsStockTtlPricTaxExcRF";
        /// <summary>消費税(返品)_その他</summary>
        public const string CT_StockConfSlipTtl_Other_RetGdsStockPriceConsTaxRF = "OtherRetGdsStockPriceConsTaxRF";
        /// <summary>合計金額(返品)_その他</summary>
        public const string CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF = "OtherRetGdsTotalPriceRF";
        #endregion
        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

        // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
        #region 「消費税税率非課税」
        /// <summary>Title_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_Title = "TaxFreeTitle";
        /// <summary>仕入枚数_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_SalSlipCntRF = "TaxFreeSalSlipCntRF";
        /// <summary>仕入金額計（税抜き）_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_StockTtlPricTaxExcRF = "TaxFreeStockTtlPricTaxExcRF";
        /// <summary>仕入金額消費税額_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_StockPriceConsTaxRF = "TaxFreeStockPriceConsTaxRF";
        /// <summary>仕入金額計（税込み）_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_StockPriceTaxIncRF = "TaxFreeStockPriceTaxIncRF";

        /// <summary>Title(返品)_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_RetTitle = "TaxFreeRetTitle";
        /// <summary>仕入枚数(返品値引)_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_DisSlipCntRF = "TaxFreeDisSlipCntRF";
        /// <summary>仕入金額(返品)_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_RetGdsStockTtlPricTaxExcRF = "TaxFreeRetGdsStockTtlPricTaxExcRF";
        /// <summary>消費税(返品)_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_RetGdsStockPriceConsTaxRF = "TaxFreeRetGdsStockPriceConsTaxRF";
        /// <summary>合計金額(返品)_非課税</summary>
        public const string CT_StockConfSlipTtl_TaxFree_RetGdsTotalPriceRF = "TaxFreeRetGdsTotalPriceRF";
        #endregion
        // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
      
        /// <summary>仕入金額(値引)</summary>
        public const string CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF = "DisStockTtlPricTaxExcRF";
        /// <summary>消費税(値引)</summary>
        public const string CT_StockConfSlipTtl_DisStockPriceConsTaxRF = "DisStockPriceConsTaxRF";
        /// <summary>合計金額(値引)</summary>
        public const string CT_StockConfSlipTtl_DisTotalPriceRF = "DisTotalPriceRF";
        // 2009.01.09 30413 犬飼 値引の金額を追加 <<<<<<END
                
		/// <summary>仕入商品区分</summary>
		public const string CT_StockConfSlipTtl_StockGoodsCdRF = "StockGoodsCdRF";
		/// <summary>仕入金額合計</summary>
		public const string CT_StockConfSlipTtl_StockTotalPriceRF = "StockTotalPriceRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>ＵＯＥリマーク１</summary>
        public const string CT_StockConfSlipTtl_UoeRemark1 = "UoeRemark1";
        /// <summary>ＵＯＥリマーク２</summary>
        public const string CT_StockConfSlipTtl_UoeRemark2 = "UoeRemark2";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		public const string COL_KEYBREAK_AR	= "KEYBREAK_AR";				// キーブレイク

        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
        // 仕入先総額表示方法区分
        public const string CT_StockConfSlipTtl_SuppTtlAmntDspWayCd = "SuppTtlAmntDspWayCd";

        // 仕入先消費税転嫁方式コード
        public const string CT_StockConfSlipTtl_SuppCTaxLayCd = "SuppCTaxLayCd";

        // UNDONE:仕入金額消費税額（内税）
        public const string CT_StockConfSlipTtl_StckPrcConsTaxInclu = "StckPrcConsTaxInclu";

        // UNDONE:仕入値引消費税額
        public const string CT_StockConfSlipTtl_StckDisTtlTaxInclu = "StckDisTtlTaxInclu";
        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<

		#endregion

		#endregion

		#region Constructor
		/// <summary>
		/// 仕入確認表抽出結果データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入確認表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// <br>Programmer : 96186　立花裕輔</br>
		/// <br>Date       : 2008.01.27</br>
		/// </remarks>
		public MAKON02249EB()
		{
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186　立花裕輔</br>
		/// <br>Date       : 2008.01.16</br>
		/// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_StockConfSlipTtlDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_StockConfSlipTtlDataTable].Clear();
			}
			else
			{
                CreateStockConfTable(ref ds);
			}
		}

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// 仕入確認表(伝票)抽出結果作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186　立花裕輔</br>
		/// <br>Date       : 2008.01.16</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
		/// </remarks>
		private static void CreateStockConfTable(ref DataSet ds)
		{
			DataTable dt = null;

			// スキーマ設定
			ds.Tables.Add(CT_StockConfSlipTtlDataTable);
			dt = ds.Tables[CT_StockConfSlipTtlDataTable];

			//拠点コード
			dt.Columns.Add(CT_StockConfSlipTtl_SectionCodeRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_SectionCodeRF].DefaultValue = "";
			//拠点ガイド名称
			dt.Columns.Add(CT_StockConfSlipTtl_SectionGuideNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_SectionGuideNmRF].DefaultValue = "";

            // --- DEL 2008/07/16 -------------------------------->>>>>
            ////得意先コード
            //dt.Columns.Add(CT_StockConfSlipTtl_CustomerCodeRF, typeof(Int32));
            //dt.Columns[CT_StockConfSlipTtl_CustomerCodeRF].DefaultValue = 0;
            ////得意先略称
            //dt.Columns.Add(CT_StockConfSlipTtl_CustomerSnmRF, typeof(string));
            //dt.Columns[CT_StockConfSlipTtl_CustomerSnmRF].DefaultValue = "";
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 仕入先コード
            dt.Columns.Add(CT_StockConfSlipTtl_SupplierCd, typeof(Int32));
            dt.Columns[CT_StockConfSlipTtl_SupplierCd].DefaultValue = 0;
            // 仕入先略称
            dt.Columns.Add(CT_StockConfSlipTtl_SupplierSnm, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_SupplierSnm].DefaultValue = "";
            // --- ADD 2008/07/16 --------------------------------<<<<< 

			//入力日
			dt.Columns.Add(CT_StockConfSlipTtl_InputDayRF, typeof(DateTime));
			dt.Columns[CT_StockConfSlipTtl_InputDayRF].DefaultValue = DateTime.MinValue;
			//入荷日
			dt.Columns.Add(CT_StockConfSlipTtl_ArrivalGoodsDayRF, typeof(DateTime));
			dt.Columns[CT_StockConfSlipTtl_ArrivalGoodsDayRF].DefaultValue = DateTime.MinValue;
			//仕入日
			dt.Columns.Add(CT_StockConfSlipTtl_StockDateRF, typeof(DateTime));
			dt.Columns[CT_StockConfSlipTtl_StockDateRF].DefaultValue = DateTime.MinValue;
			//仕入形式
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierFormalRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_SupplierFormalRF].DefaultValue = 0;
			//仕入形式名
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierFormalNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_SupplierFormalNmRF].DefaultValue = "";
			//仕入伝票番号
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierSlipNoRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_SupplierSlipNoRF].DefaultValue = 0;
			//相手先伝票番号
			dt.Columns.Add(CT_StockConfSlipTtl_PartySaleSlipNumRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_PartySaleSlipNumRF].DefaultValue = "";
			//仕入伝票区分
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierSlipCdRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_SupplierSlipCdRF].DefaultValue = 0;
			//仕入金額計（税抜き）
			dt.Columns.Add(CT_StockConfSlipTtl_StockTtlPricTaxExcRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_StockTtlPricTaxExcRF].DefaultValue = 0;
			//仕入金額消費税額
			dt.Columns.Add(CT_StockConfSlipTtl_StockPriceConsTaxRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_StockPriceConsTaxRF].DefaultValue = 0;


			//入力日付(印刷)
			dt.Columns.Add(CT_StockConfSlipTtl_InputDayNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_InputDayNmRF].DefaultValue = "";
			//仕入日付(印刷)
			dt.Columns.Add(CT_StockConfSlipTtl_StockDateNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_StockDateNmRF].DefaultValue = "";
			//仕入伝票区分名
			dt.Columns.Add(CT_StockConfSlipTtl_SupplierSlipNmRF, typeof(string));
			dt.Columns[CT_StockConfSlipTtl_SupplierSlipNmRF].DefaultValue = "";
			//仕入金額計（税込み）
			dt.Columns.Add(CT_StockConfSlipTtl_StockPriceTaxIncRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_StockPriceTaxIncRF].DefaultValue = 0;
			//伝票枚数(売上)
			dt.Columns.Add(CT_StockConfSlipTtl_SalSlipCntRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_SalSlipCntRF].DefaultValue = 0;
			//伝票枚数(返品値引)
			dt.Columns.Add(CT_StockConfSlipTtl_DisSlipCntRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_DisSlipCntRF].DefaultValue = 0;
			//伝票枚数(合計)
			dt.Columns.Add(CT_StockConfSlipTtl_TotleSlipCntRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_TotleSlipCntRF].DefaultValue = 0;

			//仕入金額(売上)
			dt.Columns.Add(CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF].DefaultValue = 0;
			//消費税(売上)
			dt.Columns.Add(CT_StockConfSlipTtl_SalStockPriceConsTaxRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_SalStockPriceConsTaxRF].DefaultValue = 0;
			//合計金額(売上)
			dt.Columns.Add(CT_StockConfSlipTtl_SalTotalPriceRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_SalTotalPriceRF].DefaultValue = 0;

            // 2009.01.09 30413 犬飼 値引の金額を追加 >>>>>>START
            ////仕入金額(返品値引)
            //dt.Columns.Add(CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF, typeof(Int64));
            //dt.Columns[CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF].DefaultValue = 0;
            ////消費税(返品値引)
            //dt.Columns.Add(CT_StockConfSlipTtl_DisStockPriceConsTaxRF, typeof(Int64));
            //dt.Columns[CT_StockConfSlipTtl_DisStockPriceConsTaxRF].DefaultValue = 0;
            ////合計金額(返品値引)
            //dt.Columns.Add(CT_StockConfSlipTtl_DisTotalPriceRF, typeof(Int64));
            //dt.Columns[CT_StockConfSlipTtl_DisTotalPriceRF].DefaultValue = 0;
            //仕入金額(返品)
            dt.Columns.Add(CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF].DefaultValue = 0;
            //消費税(返品)
            dt.Columns.Add(CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF].DefaultValue = 0;
            //合計金額(返品)
            dt.Columns.Add(CT_StockConfSlipTtl_RetGdsTotalPriceRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_RetGdsTotalPriceRF].DefaultValue = 0;

            //仕入金額(値引)
            dt.Columns.Add(CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF].DefaultValue = 0;
            //消費税(値引)
            dt.Columns.Add(CT_StockConfSlipTtl_DisStockPriceConsTaxRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_DisStockPriceConsTaxRF].DefaultValue = 0;
            //合計金額(値引)
            dt.Columns.Add(CT_StockConfSlipTtl_DisTotalPriceRF, typeof(Int64));
            dt.Columns[CT_StockConfSlipTtl_DisTotalPriceRF].DefaultValue = 0;
            // 2009.01.09 30413 犬飼 値引の金額を追加 <<<<<<END
        
			//仕入商品区分
			dt.Columns.Add(CT_StockConfSlipTtl_StockGoodsCdRF, typeof(Int32));
			dt.Columns[CT_StockConfSlipTtl_StockGoodsCdRF].DefaultValue = 0;
			//仕入金額合計
			dt.Columns.Add(CT_StockConfSlipTtl_StockTotalPriceRF, typeof(Int64));
			dt.Columns[CT_StockConfSlipTtl_StockTotalPriceRF].DefaultValue = 0;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // ＵＯＥリマーク１
            dt.Columns.Add(CT_StockConfSlipTtl_UoeRemark1, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_UoeRemark1].DefaultValue = "";

            // ＵＯＥリマーク２
            dt.Columns.Add(CT_StockConfSlipTtl_UoeRemark2, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_UoeRemark2].DefaultValue = "";
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // キーブレイク
			dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
			dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";

            // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
            // 仕入先総額表示方法区分
            dt.Columns.Add(CT_StockConfSlipTtl_SuppTtlAmntDspWayCd, typeof(int));
            dt.Columns[CT_StockConfSlipTtl_SuppTtlAmntDspWayCd].DefaultValue = 0;

            // 仕入先消費税転嫁方式コード
            dt.Columns.Add(CT_StockConfSlipTtl_SuppCTaxLayCd, typeof(int));
            dt.Columns[CT_StockConfSlipTtl_SuppCTaxLayCd].DefaultValue = 0;

            // UNDONE:仕入金額消費税額（内税）
            dt.Columns.Add(CT_StockConfSlipTtl_StckPrcConsTaxInclu, typeof(long));
            dt.Columns[CT_StockConfSlipTtl_StckPrcConsTaxInclu].DefaultValue = 0;

            // UNDONE:仕入値引消費税額
            dt.Columns.Add(CT_StockConfSlipTtl_StckDisTtlTaxInclu, typeof(long));
            dt.Columns[CT_StockConfSlipTtl_StckDisTtlTaxInclu].DefaultValue = 0;
            // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 消費税税率
            dt.Columns.Add(CT_Col_ConsTaxRate, typeof(string));
            dt.Columns[CT_Col_ConsTaxRate].DefaultValue = "";
            #region 「消費税税率１」
            // Title_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_Title, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_Title].DefaultValue = "";
            // 仕入枚数_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_SalSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_SalSlipCntRF].DefaultValue = "";
            // 仕入金額計（税抜き）_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF].DefaultValue = "";
            // 仕入金額消費税額_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_StockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_StockPriceConsTaxRF].DefaultValue = "";
            // 仕入金額計（税込み）_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF].DefaultValue = "";
            // Title(返品値引)_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_RetTitle, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_RetTitle].DefaultValue = "";
            // 仕入枚数(返品値引)_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_DisSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_DisSlipCntRF].DefaultValue = "";
            // 仕入金額(返品)_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
            // 消費税(返品)_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_RetGdsStockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_RetGdsStockPriceConsTaxRF].DefaultValue = "";
            // 合計金額(返品)_税率１
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF].DefaultValue = "";
            #endregion
            #region 「消費税税率２」
            // Title_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_Title, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_Title].DefaultValue = "";
            // 仕入枚数_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_SalSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_SalSlipCntRF].DefaultValue = "";
            // 仕入金額計（税抜き）_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF].DefaultValue = "";
            // 仕入金額消費税額_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_StockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_StockPriceConsTaxRF].DefaultValue = "";
            // 仕入金額計（税込み）_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF].DefaultValue = "";
            // Title(返品値引)_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_RetTitle, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_RetTitle].DefaultValue = "";
            // 仕入枚数(返品値引)_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_DisSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_DisSlipCntRF].DefaultValue = "";
            // 仕入金額(返品)_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
            // 消費税(返品)_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_RetGdsStockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_RetGdsStockPriceConsTaxRF].DefaultValue = "";
            // 合計金額(返品)_税率２
            dt.Columns.Add(CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF].DefaultValue = "";
            #endregion
            #region 「消費税税率その他」
            // Title_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_Title, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_Title].DefaultValue = "";
            // 仕入枚数_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_SalSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_SalSlipCntRF].DefaultValue = "";
            // 仕入金額計（税抜き）_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF].DefaultValue = "";
            // 仕入金額消費税額_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_StockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_StockPriceConsTaxRF].DefaultValue = "";
            // 仕入金額計（税込み）_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_StockPriceTaxIncRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_StockPriceTaxIncRF].DefaultValue = "";
            // Title(返品値引)_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_RetTitle, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_RetTitle].DefaultValue = "";
            // 仕入枚数(返品値引)_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_DisSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_DisSlipCntRF].DefaultValue = "";
            // 仕入金額(返品)_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
            // 消費税(返品)_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_RetGdsStockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_RetGdsStockPriceConsTaxRF].DefaultValue = "";
            // 合計金額(返品)_その他
            dt.Columns.Add(CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF].DefaultValue = "";
            #endregion
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

            // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
            #region 「消費税税率非課税」
            // Title_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_Title, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_Title].DefaultValue = "";
            // 仕入枚数_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_SalSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_SalSlipCntRF].DefaultValue = "";
            // 仕入金額計（税抜き）_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_StockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_StockTtlPricTaxExcRF].DefaultValue = "";
            // 仕入金額消費税額_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_StockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_StockPriceConsTaxRF].DefaultValue = "";
            // 仕入金額計（税込み）_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_StockPriceTaxIncRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_StockPriceTaxIncRF].DefaultValue = "";
            // Title(返品値引)_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_RetTitle, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_RetTitle].DefaultValue = "";
            // 仕入枚数(返品値引)_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_DisSlipCntRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_DisSlipCntRF].DefaultValue = "";
            // 仕入金額(返品)_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_RetGdsStockTtlPricTaxExcRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
            // 消費税(返品)_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_RetGdsStockPriceConsTaxRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_RetGdsStockPriceConsTaxRF].DefaultValue = "";
            // 合計金額(返品)_非課税
            dt.Columns.Add(CT_StockConfSlipTtl_TaxFree_RetGdsTotalPriceRF, typeof(string));
            dt.Columns[CT_StockConfSlipTtl_TaxFree_RetGdsTotalPriceRF].DefaultValue = "";
            #endregion
            // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
		}

		#endregion
	}
}