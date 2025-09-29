using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
    /// <summary>
    /// 仕入先総額表示方法区分の列挙体
    /// </summary>
    public enum SuppTtlAmntDspWayCd : int
    {
        /// <summary>総額表示しない（税抜き）</summary>
        NotShown = 0,
        /// <summary>総額表示する（税込み）</summary>
        Shown = 1
    }

    /// <summary>
    /// 仕入先消費税転嫁方式コードの列挙体
    /// </summary>
    public enum SuppCTaxLayCd : int
    {
        /// <summary>伝票単位</summary>
        BySlip = 0,
        /// <summary>明細単位</summary>
        ByDetails = 1,
        /// <summary>支払親</summary>
        ParentPayment = 2,
        /// <summary>支払子</summary>
        ChildPayment = 3,
        /// <summary>非課税</summary>
        TaxExemption = 9
    }

    /// <summary>
    /// 課税区分の列挙体
    /// </summary>
    public enum TaxationCode : int
    {
        /// <summary>外税</summary>
        OutsideTax = 0,
        /// <summary>非課税</summary>
        TaxExemption = 1,
        /// <summary>内税</summary>
        TaxIncluded = 2
    }
    // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<

	/// <summary>
	/// 仕入確認表(明細単位)抽出結果データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 仕入確認表(明細単位)の抽出結果テーブルスキーマです。</br>
	/// <br>Programmer : 22021　谷藤　範幸</br>
	/// <br>Date       : 2006.01.27</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : ・データ項目の追加/修正</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date	   : 2008/07/16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note: 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 尹安 </br>
    /// <br>Date	   : 2020/02/27</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note: 11800255-00　インボイス対応（税率別合計金額不具合修正） </br>
    /// <br>Programmer : 陳艶丹 </br>
    /// <br>Date       : 2022/09/28</br>
    /// </remarks>
	public class MAKON02249EA
	{
		#region Public Members
        /// <summary>仕入確認表(明細単位)データテーブル名</summary>
        public const string CT_StockConfDataTable = "StockConfDataTable";
        /// <summary>仕入確認表(明細単位)バッファデータテーブル名</summary>
        public const string CT_StockConfBuffDataTable = "StockConfBuffDataTable";

		#region 仕入確認表（明細単位）カラム情報

        /// <summary>拠点コード</summary>
        public const string CT_StockConf_SectionCodeRF = "SectionCodeRF";
        /// <summary>拠点ガイド名称</summary>
        public const string CT_StockConf_SectionGuideNmRF = "SectionGuideNmRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>仕入先コード</summary>
        public const string CT_StockConf_SupplierCd = "SupplierCd";
        /// <summary>仕入先略称</summary>
        public const string CT_StockConf_SupplierSnm = "SupplierSnm";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        /// <summary>入力日付</summary>
        public const string CT_StockConf_InputDayRF = "InputDayRF";
        /// <summary>仕入日付</summary>
        public const string CT_StockConf_StockDateRF = "StockDateRF";
        /// <summary>入荷日付</summary>
        public const string CT_StockConf_ArrivalGoodsDayRF = "ArrivalGoodsDayRF";

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// <summary>得意先コード</summary>
        //public const string CT_StockConf_CustomerCodeRF = "CustomerCodeRF";
        ///// <summary>得意先名称</summary>
        //public const string CT_StockConf_CustomerNameRF = "CustomerNameRF";
        ///// <summary>得意先名称2</summary>
        //public const string CT_StockConf_CustomerName2RF = "CustomerName2RF";
        // --- DEL 2008/07/16 --------------------------------<<<<< 

        /// <summary>商品コード</summary>
        public const string CT_StockConf_GoodsCodeRF = "GoodsCodeRF";
        /// <summary>商品名称</summary>
        public const string CT_StockConf_GoodsNameRF = "GoodsNameRF";
        /// <summary>仕入伝票番号</summary>
        public const string CT_StockConf_SupplierSlipNoRF = "SupplierSlipNoRF";
        /// <summary>仕入行番号</summary>
        public const string CT_StockConf_StockRowNoRF = "StockRowNoRF";
        /// <summary>仕入詳細番号</summary>
        public const string CT_StockConf_StckSlipExpNumRF = "StckSlipExpNumRF";
        /// <summary>赤伝区分</summary>
        public const string CT_StockConf_DebitNoteDivRF = "DebitNoteDivRF";
        /// <summary>赤伝区分名</summary>
        public const string CT_StockConf_DebitNoteDivNmRF = "DebitNoteDivNmRF";
        /// <summary>仕入形式</summary>
        public const string CT_StockConf_SupplierFormalRF = "SupplierFormalRF";
        /// <summary>仕入形式名</summary>
        public const string CT_StockConf_SupplierFormalNmRF = "SupplierFormalNmRF";
        /// <summary>買掛区分</summary>
        public const string CT_StockConf_AccPayDivCdRF = "AccPayDivCdRF";
        /// <summary>買掛区分名</summary>
        public const string CT_StockConf_AccPayDivNmRF = "AccPayDivNmRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>ＵＯＥリマーク１</summary>
        public const string CT_StockConf_UoeRemark1 = "UoeRemark1";
        /// <summary>ＵＯＥリマーク２</summary>
        public const string CT_StockConf_UoeRemark2 = "UoeRemark2";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        // --- DEL 2008/07/16 -------------------------------->>>>>
        ///// <summary>商品大分類コード</summary>
        //public const string CT_StockConf_LargeGoodsGanreCodeRF = "LargeGoodsGanreCodeRF";
        ///// <summary>商品大分類名称</summary>
        //public const string CT_StockConf_LargeGoodsGanreNameRF = "LargeGoodsGanreNameRF";
        ///// <summary>商品中分類コード</summary>
        //public const string CT_StockConf_MediumGoodsGanreCodeRF = "MediumGoodsGanreCodeRF";
        ///// <summary>商品中分類名称</summary>
        //public const string CT_StockConf_MediumGoodsGanreNameRF = "MediumGoodsGanreNameRF";
        // --- DEL 2008/07/16 --------------------------------<<<<< 

		/// <summary>仕入担当者コード</summary>
        public const string CT_StockConf_StockAgentCodeRF = "StockAgentCodeRF";
        /// <summary>仕入担当者名称</summary>
        public const string CT_StockConf_StockAgentNameRF = "StockAgentNameRF";
		/// <summary>仕入数</summary>
        public const string CT_StockConf_StockCountRF = "StockCountRF";
        /// <summary>仕入単価</summary>
        public const string CT_StockConf_StockUnitPriceRF = "StockUnitPriceRF";
        /// <summary>仕入金額</summary>
        public const string CT_StockConf_StockPriceTaxExcRF = "StockPriceTaxExcRF";
        /// <summary>仕入伝票区分</summary>
        public const string CT_StockConf_SupplierSlipCdRF = "SupplierSlipCdRF";
        /// <summary>仕入伝票区分名</summary>
        public const string CT_StockConf_SupplierSlipNmRF = "SupplierSlipNmRF";
        /// <summary>先頭出力詳細フラグ</summary>
        public const string CT_StockConf_FirstRowFlg = "FirstRowFlg";

		/// <summary>相手先伝票番号</summary>
		public const string CT_StockConf_PartySaleSlipNumRF = "PartySaleSlipNumRF";

		/// <summary>商品区分詳細コード</summary>
		public const string CT_StockConf_DetailGoodsGanreCodeRF = "DetailGoodsGanreCodeRF";
		/// <summary>商品区分詳細名称</summary>
		public const string CT_StockConf_DetailGoodsGanreNameRF = "DetailGoodsGanreNameRF";

		/// <summary>自社分類コード</summary>
		public const string CT_StockConf_EnterpriseGanreCodeRF = "EnterpriseGanreCodeRF";
		/// <summary>自社分類名称</summary>
		public const string CT_StockConf_EnterpriseGanreNameRF = "EnterpriseGanreNameRF";
		/// <summary>商品メーカーコード</summary>
		public const string CT_StockConf_GoodsMakerCdRF = "GoodsMakerCdRF";
		/// <summary>メーカー名称</summary>
		public const string CT_StockConf_MakerNameRF = "MakerNameRF";
		/// <summary>仕入在庫取寄せ区分</summary>
		public const string CT_StockConf_StockOrderDivCdRF = "StockOrderDivCdRF";
		/// <summary>仕入在庫取寄せ名称</summary>
		public const string CT_StockConf_StockOrderDivNmRF = "StockOrderDivNmRF";
		/// <summary>倉庫コード</summary>
		public const string CT_StockConf_WarehouseCodeRF = "WarehouseCodeRF";
		/// <summary>倉庫名称</summary>
		public const string CT_StockConf_WarehouseNameRF = "WarehouseNameRF";
		/// <summary>BL商品コード</summary>
		public const string CT_StockConf_BLGoodsCodeRF = "BLGoodsCodeRF";
		/// <summary>仕入伝票明細備考1</summary>
		public const string CT_StockConf_StockDtiSlipNote1RF = "StockDtiSlipNote1RF";
		/// <summary>単位コード</summary>
		public const string CT_StockConf_UnitCodeRF = "UnitCodeRF";
		/// <summary>単位名称</summary>
		public const string CT_StockConf_UnitNameRF = "UnitNameRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>変更前定価</summary>
        public const string CT_StockConf_BfListPriceRF = "BfListPriceRF";
        /// <summary>変更前仕入単価</summary>
        public const string CT_StockConf_BfStockUnitPriceFlRF = "BfStockUnitPriceFlRF";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// <summary>定価（浮動）</summary>
		public const string CT_StockConf_ListPriceFlRF = "ListPriceFlRF";
		/// <summary>発注番号</summary>
		public const string CT_StockConf_OrderNumberRF = "OrderNumberRF";
		/// <summary>消費税</summary>
		public const string CT_StockConf_TaxRF = "TaxRF";

		/// <summary>仕入伝票備考1</summary>
		public const string CT_StockConf_SupplierSlipNote1RF = "SupplierSlipNote1RF";
		/// <summary>仕入伝票備考2</summary>
		public const string CT_StockConf_SupplierSlipNote2RF = "SupplierSlipNote2RF";
		/// <summary>仕入先略称</summary>
		public const string CT_StockConf_CustomerSnmRF = "CustomerSnmRF";
		/// <summary>仕入計上日付</summary>
		public const string CT_StockConf_StockAddUpADateRF = "StockAddUpADateRF";

		/// <summary>入力日付(印刷用)</summary>
		public const string CT_StockConf_InputDayStringRF = "InputDayStringRF";
		/// <summary>仕入日付(印刷用)</summary>
		public const string CT_StockConf_StockDateStringRF = "StockDateStringRF";
		/// <summary>仕入計上日付(印刷用)</summary>
		public const string CT_StockConf_StockAddUpADateStringRF = "StockAddUpADateStringRF";
		/// <summary>入荷日付(印刷用)</summary>
		public const string CT_StockConf_ArrivalGoodsDayStringRF = "ArrivalGoodsDayStringRF";

		/// <summary>仕入商品区分</summary>
		public const string CT_StockConf_StockGoodsCdRF = "StockGoodsCdRF";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>売上伝票番号</summary>
        public const string CT_StockConf_SalesSlipNum = "SalesSlipNum";
        /// <summary>得意先コード</summary>
        public const string CT_StockConf_CustomerCodeRF = "CustomerCodeRF";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

		/// <summary>仕入日計・入力日計</summary>
		public const string CT_StockConf_groupHeader1DataField = "groupHeader1DataField";
		/// <summary>伝票計</summary>
		public const string CT_StockConf_groupHeader2DataField = "groupHeader2DataField";
		/// <summary>仕入先計</summary>
		public const string CT_StockConf_DailyHeaderDataField = "DailyHeaderDataField";

        // --- ADD 2008/07/16 -------------------------------->>>>>
        /// <summary>仕入金額（税込み）</summary>
        public const string CT_StockConf_StockPriceTaxIncRF = "StockPriceTaxIncRF";
        /// <summary>伝票枚数(売上)</summary>
        public const string CT_StockConf_SalCntRF = "SalCntRF";
        /// <summary>伝票枚数(返品値引)</summary>
        public const string CT_StockConf_DisCntRF = "DisCntRF";
        /// <summary>伝票枚数(合計)</summary>
        public const string CT_StockConf_TotleCntRF = "TotleCntRF";

        /// <summary>仕入金額(売上)</summary>
        public const string CT_StockConf_SalStockPricTaxExcRF = "SalStockPricTaxExcRF";
        /// <summary>消費税(売上)</summary>
        public const string CT_StockConf_SalStockPriceConsTaxRF = "SalStockPriceConsTaxRF";
        /// <summary>合計金額(売上)</summary>
        public const string CT_StockConf_SalTotalPriceRF = "SalTotalPriceRF";

        // 2009.01.09 30413 犬飼 値引の金額を追加 >>>>>>START
        ///// <summary>仕入金額(返品値引)</summary>
        //public const string CT_StockConf_DisStockPricTaxExcRF = "DisStockPricTaxExcRF";
        ///// <summary>消費税(返品値引)</summary>
        //public const string CT_StockConf_DisStockPriceConsTaxRF = "DisStockPriceConsTaxRF";
        ///// <summary>合計金額(返品値引)</summary>
        //public const string CT_StockConf_DisTotalPriceRF = "DisTotalPriceRF";
        /// <summary>仕入金額(返品)</summary>
        public const string CT_StockConf_RetGdsStockPricTaxExcRF = "RetGdsStockPricTaxExcRF";
        /// <summary>消費税(返品)</summary>
        public const string CT_StockConf_RetGdsStockPriceConsTaxRF = "RetGdsStockPriceConsTaxRF";
        /// <summary>合計金額(返品)</summary>
        public const string CT_StockConf_RetGdsTotalPriceRF = "RetGdsTotalPriceRF";
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        /// <summary>仕入金額(値引)</summary>
        public const string CT_StockConf_DisStockPricTaxExcRF = "DisStockPricTaxExcRF";
        /// <summary>消費税(値引)</summary>
        public const string CT_StockConf_DisStockPriceConsTaxRF = "DisStockPriceConsTaxRF";
        /// <summary>合計金額(値引)</summary>
        public const string CT_StockConf_DisTotalPriceRF = "DisTotalPriceRF";        
        // 2009.01.09 30413 犬飼 値引の金額を追加 <<<<<<END

        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
        /// <summary> 消費税税率 </summary>
        public const String CT_Col_ConsTaxRate = "SupplierConsTaxRate";

        #region 「消費税税率１」
        /// <summary>Title_税率１</summary>
        public const string CT_StockConf_TaxRate1_Title = "TaxRate1Title";
        /// <summary>仕入枚数_税率１</summary>
        public const string CT_StockConf_TaxRate1_SalSlipCntRF = "TaxRate1SalSlipCntRF";
        /// <summary>仕入金額計（税抜き）_税率１</summary>
        public const string CT_StockConf_TaxRate1_StockTtlPricTaxExcRF = "TaxRate1StockTtlPricTaxExcRF";

        /// <summary>Title(返品)_税率１</summary>
        public const string CT_StockConf_TaxRate1_RetTitle = "TaxRate1RetTitle";
        /// <summary>伝票枚数(返品値引)_税率１</summary>
        public const string CT_StockConf_TaxRate1_DisSlipCntRF = "TaxRate1DisSlipCntRF";
        /// <summary>仕入金額(返品)_税率１</summary>
        public const string CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF = "TaxRate1RetGdsStockTtlPricTaxExcRF";
        #endregion

        #region 「消費税税率２」
        /// <summary>Title_税率2</summary>
        public const string CT_StockConf_TaxRate2_Title = "TaxRate2Title";
        /// <summary>仕入枚数_税率２</summary>
        public const string CT_StockConf_TaxRate2_SalSlipCntRF = "TaxRate2SalSlipCntRF";
        /// <summary>仕入金額計（税抜き）_税率２</summary>
        public const string CT_StockConf_TaxRate2_StockTtlPricTaxExcRF = "TaxRate2StockTtlPricTaxExcRF";

        /// <summary>Title(返品)_税率２</summary>
        public const string CT_StockConf_TaxRate2_RetTitle = "TaxRate2RetTitle";
        /// <summary>伝票枚数(返品値引)_税率２</summary>
        public const string CT_StockConf_TaxRate2_DisSlipCntRF = "TaxRate2DisSlipCntRF";
        /// <summary>仕入金額(返品)_税率２</summary>
        public const string CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF = "TaxRate2RetGdsStockTtlPricTaxExcRF";
        #endregion

        #region 「消費税税率その他」
        /// <summary>Title_その他</summary>
        public const string CT_StockConf_Other_Title = "OtherTitle";
        /// <summary>仕入枚数_その他</summary>
        public const string CT_StockConf_Other_SalSlipCntRF = "OtherSalSlipCntRF";
        /// <summary>仕入金額計（税抜き）_その他</summary>
        public const string CT_StockConf_Other_StockTtlPricTaxExcRF = "OtherStockTtlPricTaxExcRF";

        /// <summary>Title_その他</summary>
        public const string CT_StockConf_Other_RetTitle = "OtherRetTitle";
        /// <summary>仕入枚数(返品値引)_その他</summary>
        public const string CT_StockConf_Other_DisSlipCntRF = "OtherDisSlipCntRF";
        /// <summary>仕入金額(返品)_その他</summary>
        public const string CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF = "OtherRetGdsStockTtlPricTaxExcRF";
        #endregion
        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<



        // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
        #region 「消費税税率非課税」
        /// <summary>Title_非課税</summary>
        public const string CT_StockConf_TaxFree_Title = "TaxFreeTitle";
        /// <summary>仕入枚数_非課税</summary>
        public const string CT_StockConf_TaxFree_SalSlipCntRF = "TaxFreeSalSlipCntRF";
        /// <summary>仕入金額計（税抜き）_非課税</summary>
        public const string CT_StockConf_TaxFree_StockTtlPricTaxExcRF = "TaxFreeStockTtlPricTaxExcRF";

        /// <summary>Title_非課税</summary>
        public const string CT_StockConf_TaxFree_RetTitle = "TaxFreeRetTitle";
        /// <summary>仕入枚数(返品値引)_非課税</summary>
        public const string CT_StockConf_TaxFree_DisSlipCntRF = "TaxFreeDisSlipCntRF";
        /// <summary>仕入金額(返品)_非課税</summary>
        public const string CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF = "TaxFreeRetGdsStockTtlPricTaxExcRF";
        #endregion
        // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
		// キーブレイク
		public const string COL_KEYBREAK_AR = "KEYBREAK_AR";

        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
        // 仕入先総額表示方法区分
        public const string CT_StockConf_SuppTtlAmntDspWayCd = "SuppTtlAmntDspWayCd";
        // 仕入先消費税転嫁方式コード
        public const string CT_StockConf_SuppCTaxLayCd = "SuppCTaxLayCd";
        // 課税区分
        public const string CT_StockConf_TaxationCode = "TaxationCode";
        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<

		#endregion

		#endregion

		#region Constructor
		/// <summary>
		/// 仕入確認表抽出結果データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入確認表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// <br>Programmer : 22021　谷藤　範幸</br>
		/// <br>Date       : 2006.01.27</br>
		/// </remarks>
		public MAKON02249EA()
		{
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22021 谷藤　範幸</br>
		/// <br>Date       : 2006.01.21</br>
		/// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
			if ( (ds.Tables.Contains(CT_StockConfDataTable)) )
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_StockConfDataTable].Clear();
			}
			else
			{
                CreateStockConfTable(ref ds, 0);

			}
			
			// 売上チェックリストバッファデータテーブル------------------------------------------
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_StockConfBuffDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_StockConfBuffDataTable].Clear();
			}
			else
			{
                CreateStockConfTable(ref ds, 1);
			}
		}

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// 仕入確認表(明細単位)抽出結果作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22021 谷藤　範幸</br>
		/// <br>Date       : 2006.01.28</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
		/// </remarks>
		private static void CreateStockConfTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// スキーマ設定
				ds.Tables.Add(CT_StockConfDataTable);
				dt = ds.Tables[CT_StockConfDataTable];
			}
			else
			{
				// スキーマ設定
				ds.Tables.Add(CT_StockConfBuffDataTable);
				dt = ds.Tables[CT_StockConfBuffDataTable];
			}

                // 拠点コード
                dt.Columns.Add(CT_StockConf_SectionCodeRF, typeof(string));
                dt.Columns[CT_StockConf_SectionCodeRF].DefaultValue = "";
                // 拠点ガイド名称
                dt.Columns.Add(CT_StockConf_SectionGuideNmRF, typeof(string));
                dt.Columns[CT_StockConf_SectionGuideNmRF].DefaultValue = "";
                // 仕入日付
                dt.Columns.Add(CT_StockConf_StockDateRF, typeof(DateTime));
                dt.Columns[CT_StockConf_StockDateRF].DefaultValue = null;
                // 入荷日付
                dt.Columns.Add(CT_StockConf_ArrivalGoodsDayRF, typeof(DateTime));
                dt.Columns[CT_StockConf_ArrivalGoodsDayRF].DefaultValue = null;

                // --- DEL 2008/07/16 -------------------------------->>>>>
                //// 得意先コード
                //dt.Columns.Add(CT_StockConf_CustomerCodeRF, typeof(Int32));
                //dt.Columns[CT_StockConf_CustomerCodeRF].DefaultValue = 0;
                //// 得意先名称
                //dt.Columns.Add(CT_StockConf_CustomerNameRF, typeof(string));
                //dt.Columns[CT_StockConf_CustomerNameRF].DefaultValue = "";
                //// 得意先名称2
                //dt.Columns.Add(CT_StockConf_CustomerName2RF, typeof(string));
                //dt.Columns[CT_StockConf_CustomerName2RF].DefaultValue = "";
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 仕入先コード
                dt.Columns.Add(CT_StockConf_SupplierCd, typeof(Int32));
                dt.Columns[CT_StockConf_SupplierCd].DefaultValue = 0;
                // 仕入先略称
                dt.Columns.Add(CT_StockConf_SupplierSnm, typeof(string));
                dt.Columns[CT_StockConf_SupplierSnm].DefaultValue = "";
                // --- ADD 2008/07/16 --------------------------------<<<<< 

                // 商品コード
                dt.Columns.Add(CT_StockConf_GoodsCodeRF, typeof(string));
                dt.Columns[CT_StockConf_GoodsCodeRF].DefaultValue = "";
                // 商品名称
                dt.Columns.Add(CT_StockConf_GoodsNameRF, typeof(string));
                dt.Columns[CT_StockConf_GoodsNameRF].DefaultValue = "";
                // 仕入伝票番号
                dt.Columns.Add(CT_StockConf_SupplierSlipNoRF, typeof(Int32));
                dt.Columns[CT_StockConf_SupplierSlipNoRF].DefaultValue = 0;
                // 仕入行番号
                dt.Columns.Add(CT_StockConf_StockRowNoRF, typeof(Int32));
                dt.Columns[CT_StockConf_StockRowNoRF].DefaultValue = 0;
                // 仕入詳細番号
                dt.Columns.Add(CT_StockConf_StckSlipExpNumRF, typeof(Int32));
                dt.Columns[CT_StockConf_StckSlipExpNumRF].DefaultValue = 0;
                // 赤伝区分
                dt.Columns.Add(CT_StockConf_DebitNoteDivRF, typeof(Int32));
                dt.Columns[CT_StockConf_DebitNoteDivRF].DefaultValue = 0;
                // 赤伝区分名
                dt.Columns.Add(CT_StockConf_DebitNoteDivNmRF, typeof(string));
                dt.Columns[CT_StockConf_DebitNoteDivNmRF].DefaultValue = "";
                // 買掛区分
                dt.Columns.Add(CT_StockConf_AccPayDivCdRF, typeof(Int32));
                dt.Columns[CT_StockConf_AccPayDivCdRF].DefaultValue = 0;
                // 買掛区分名
                dt.Columns.Add(CT_StockConf_AccPayDivNmRF, typeof(string));
                dt.Columns[CT_StockConf_AccPayDivNmRF].DefaultValue = "";

                // --- DEL 2008/07/16 -------------------------------->>>>>
                //// 商品大分類コード
                //dt.Columns.Add(CT_StockConf_LargeGoodsGanreCodeRF, typeof(string));
                //dt.Columns[CT_StockConf_LargeGoodsGanreCodeRF].DefaultValue = 0;
                //// 商品大分類名称
                //dt.Columns.Add(CT_StockConf_LargeGoodsGanreNameRF, typeof(string));
                //dt.Columns[CT_StockConf_LargeGoodsGanreNameRF].DefaultValue = "";
                //// 商品中分類コード
                //dt.Columns.Add(CT_StockConf_MediumGoodsGanreCodeRF, typeof(string));
                //dt.Columns[CT_StockConf_MediumGoodsGanreCodeRF].DefaultValue = 0;
                //// 商品中分類名称
                //dt.Columns.Add(CT_StockConf_MediumGoodsGanreNameRF, typeof(string));
                //dt.Columns[CT_StockConf_MediumGoodsGanreNameRF].DefaultValue = "";
                // --- DEL 2008/07/16 --------------------------------<<<<< 

				// 仕入担当者コード
                dt.Columns.Add(CT_StockConf_StockAgentCodeRF, typeof(string));
                dt.Columns[CT_StockConf_StockAgentCodeRF].DefaultValue = "";
                // 仕入担当者名称
                dt.Columns.Add(CT_StockConf_StockAgentNameRF, typeof(string));
                dt.Columns[CT_StockConf_StockAgentNameRF].DefaultValue = "";
                // 仕入数
                dt.Columns.Add(CT_StockConf_StockCountRF, typeof(double));
                dt.Columns[CT_StockConf_StockCountRF].DefaultValue = 0;
                // 仕入単価
				dt.Columns.Add(CT_StockConf_StockUnitPriceRF, typeof(double));
                dt.Columns[CT_StockConf_StockUnitPriceRF].DefaultValue = 0;
                // 仕入金額
                dt.Columns.Add(CT_StockConf_StockPriceTaxExcRF, typeof(Int64));
                dt.Columns[CT_StockConf_StockPriceTaxExcRF].DefaultValue = 0;
                // 仕入伝票区分
                dt.Columns.Add(CT_StockConf_SupplierSlipCdRF, typeof(Int32));
                dt.Columns[CT_StockConf_SupplierSlipCdRF].DefaultValue = 0;
                // 仕入伝票区分名
                dt.Columns.Add(CT_StockConf_SupplierSlipNmRF, typeof(string));
                dt.Columns[CT_StockConf_SupplierSlipNmRF].DefaultValue = "";
                // 先頭出力詳細フラグ
                dt.Columns.Add(CT_StockConf_FirstRowFlg, typeof(Int32));
                dt.Columns[CT_StockConf_FirstRowFlg].DefaultValue = 0;

                // 入力日付
                dt.Columns.Add(CT_StockConf_InputDayRF, typeof(DateTime));
                dt.Columns[CT_StockConf_InputDayRF].DefaultValue = null;
				// 相手先伝票番号
				dt.Columns.Add(CT_StockConf_PartySaleSlipNumRF, typeof(string));
				dt.Columns[CT_StockConf_PartySaleSlipNumRF].DefaultValue = "";
				// 商品区分詳細コード
				dt.Columns.Add(CT_StockConf_DetailGoodsGanreCodeRF, typeof(string));
				dt.Columns[CT_StockConf_DetailGoodsGanreCodeRF].DefaultValue = "";
				// 商品区分詳細名称
				dt.Columns.Add(CT_StockConf_DetailGoodsGanreNameRF, typeof(string));
				dt.Columns[CT_StockConf_DetailGoodsGanreNameRF].DefaultValue = "";
				// 自社分類コード
				dt.Columns.Add(CT_StockConf_EnterpriseGanreCodeRF, typeof(Int32));
				dt.Columns[CT_StockConf_EnterpriseGanreCodeRF].DefaultValue = 0;
				// 自社分類名称
				dt.Columns.Add(CT_StockConf_EnterpriseGanreNameRF, typeof(string));
				dt.Columns[CT_StockConf_EnterpriseGanreNameRF].DefaultValue = "";
				// 商品メーカーコード
				dt.Columns.Add(CT_StockConf_GoodsMakerCdRF, typeof(Int32));
				dt.Columns[CT_StockConf_GoodsMakerCdRF].DefaultValue = 0;
				// メーカー名称
				dt.Columns.Add(CT_StockConf_MakerNameRF, typeof(string));
				dt.Columns[CT_StockConf_MakerNameRF].DefaultValue = "";
				// 仕入在庫取寄せ区分
				dt.Columns.Add(CT_StockConf_StockOrderDivCdRF, typeof(Int32));
				dt.Columns[CT_StockConf_StockOrderDivCdRF].DefaultValue = 0;
				// 仕入在庫取寄せ名称
				dt.Columns.Add(CT_StockConf_StockOrderDivNmRF, typeof(string));
				dt.Columns[CT_StockConf_StockOrderDivNmRF].DefaultValue = "";
				// 倉庫コード
				dt.Columns.Add(CT_StockConf_WarehouseCodeRF, typeof(string));
				dt.Columns[CT_StockConf_WarehouseCodeRF].DefaultValue = "";
				// 倉庫名称
				dt.Columns.Add(CT_StockConf_WarehouseNameRF, typeof(string));
				dt.Columns[CT_StockConf_WarehouseNameRF].DefaultValue = "";
				// BL商品コード
				dt.Columns.Add(CT_StockConf_BLGoodsCodeRF, typeof(Int32));
				dt.Columns[CT_StockConf_BLGoodsCodeRF].DefaultValue = 0;
				// 仕入伝票明細備考1
				dt.Columns.Add(CT_StockConf_StockDtiSlipNote1RF, typeof(string));
				dt.Columns[CT_StockConf_StockDtiSlipNote1RF].DefaultValue = "";
				// 単位コード
				dt.Columns.Add(CT_StockConf_UnitCodeRF, typeof(Int32));
				dt.Columns[CT_StockConf_UnitCodeRF].DefaultValue = 0;
				// 単位名称
				dt.Columns.Add(CT_StockConf_UnitNameRF, typeof(string));
				dt.Columns[CT_StockConf_UnitNameRF].DefaultValue = "";

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 変更前定価
                dt.Columns.Add(CT_StockConf_BfListPriceRF, typeof(Double));
                dt.Columns[CT_StockConf_BfListPriceRF].DefaultValue = 0.0;
                // 変更前仕入単価 
                dt.Columns.Add(CT_StockConf_BfStockUnitPriceFlRF, typeof(Double));
                dt.Columns[CT_StockConf_BfStockUnitPriceFlRF].DefaultValue = 0.0;
                // 売上伝票番号
                dt.Columns.Add(CT_StockConf_SalesSlipNum, typeof(string));
                dt.Columns[CT_StockConf_SalesSlipNum].DefaultValue = "";
                // 得意先コード
                dt.Columns.Add(CT_StockConf_CustomerCodeRF, typeof(Int32));
                dt.Columns[CT_StockConf_CustomerCodeRF].DefaultValue = 0;
                // テストＵＯＥリマーク１
                dt.Columns.Add(CT_StockConf_UoeRemark1, typeof(string));
                dt.Columns[CT_StockConf_UoeRemark1].DefaultValue = "";
                // テストＵＯＥリマーク２
                dt.Columns.Add(CT_StockConf_UoeRemark2, typeof(string));
                dt.Columns[CT_StockConf_UoeRemark2].DefaultValue = "";
                // --- ADD 2008/07/16 --------------------------------<<<<< 

				// 定価（浮動）
				dt.Columns.Add(CT_StockConf_ListPriceFlRF, typeof(Double));
				dt.Columns[CT_StockConf_ListPriceFlRF].DefaultValue = 0.0;
				// 発注番号
				dt.Columns.Add(CT_StockConf_OrderNumberRF, typeof(string));
				dt.Columns[CT_StockConf_OrderNumberRF].DefaultValue = "";
				// 消費税
                dt.Columns.Add(CT_StockConf_TaxRF, typeof(Int64));
                dt.Columns[CT_StockConf_TaxRF].DefaultValue = 0;

				// 仕入伝票備考1
				dt.Columns.Add(CT_StockConf_SupplierSlipNote1RF, typeof(string));
				dt.Columns[CT_StockConf_SupplierSlipNote1RF].DefaultValue = "";

				// 仕入伝票備考2
				dt.Columns.Add(CT_StockConf_SupplierSlipNote2RF, typeof(string));
				dt.Columns[CT_StockConf_SupplierSlipNote2RF].DefaultValue = "";

				// 仕入先略称
				dt.Columns.Add(CT_StockConf_CustomerSnmRF, typeof(string));
				dt.Columns[CT_StockConf_CustomerSnmRF].DefaultValue = "";

				// 仕入計上日付
				dt.Columns.Add(CT_StockConf_StockAddUpADateRF, typeof(DateTime));
				dt.Columns[CT_StockConf_StockAddUpADateRF].DefaultValue = null;

				// 入力日付(印刷用)
				dt.Columns.Add(CT_StockConf_InputDayStringRF, typeof(string));
				dt.Columns[CT_StockConf_InputDayStringRF].DefaultValue = "";
				
				// 仕入日付(印刷用)
				dt.Columns.Add(CT_StockConf_StockDateStringRF, typeof(string));
				dt.Columns[CT_StockConf_StockDateStringRF].DefaultValue = "";
				
				// 仕入計上日付(印刷用)
				dt.Columns.Add(CT_StockConf_StockAddUpADateStringRF, typeof(string));
				dt.Columns[CT_StockConf_StockAddUpADateStringRF].DefaultValue = "";
				
				// 入荷日付(印刷用)
				dt.Columns.Add(CT_StockConf_ArrivalGoodsDayStringRF, typeof(string));
				dt.Columns[CT_StockConf_ArrivalGoodsDayStringRF].DefaultValue = "";

				// 仕入商品区分
				dt.Columns.Add(CT_StockConf_StockGoodsCdRF, typeof(Int32));
				dt.Columns[CT_StockConf_StockGoodsCdRF].DefaultValue = 0;

				// 仕入日計・入力日計
				dt.Columns.Add(CT_StockConf_groupHeader1DataField, typeof(string));
				dt.Columns[CT_StockConf_groupHeader1DataField].DefaultValue = "";

				// 伝票計
				dt.Columns.Add(CT_StockConf_groupHeader2DataField, typeof(string));
				dt.Columns[CT_StockConf_groupHeader2DataField].DefaultValue = "";

				// 仕入先計
				dt.Columns.Add(CT_StockConf_DailyHeaderDataField, typeof(string));
				dt.Columns[CT_StockConf_DailyHeaderDataField].DefaultValue = "";

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 仕入金額（税込み）
                dt.Columns.Add(CT_StockConf_StockPriceTaxIncRF, typeof(Int64));
                dt.Columns[CT_StockConf_StockPriceTaxIncRF].DefaultValue = 0;
                //伝票枚数(売上)
                dt.Columns.Add(CT_StockConf_SalCntRF, typeof(Int32));
                dt.Columns[CT_StockConf_SalCntRF ].DefaultValue = 0;
                //伝票枚数(返品値引)
                dt.Columns.Add(CT_StockConf_DisCntRF, typeof(Int32));
                dt.Columns[CT_StockConf_DisCntRF ].DefaultValue = 0;
                //伝票枚数(合計)
                dt.Columns.Add(CT_StockConf_TotleCntRF, typeof(Int32));
                dt.Columns[CT_StockConf_TotleCntRF].DefaultValue = 0;
                //仕入金額(売上)
                dt.Columns.Add(CT_StockConf_SalStockPricTaxExcRF, typeof(Int64));
                dt.Columns[CT_StockConf_SalStockPricTaxExcRF].DefaultValue = 0;
                //消費税(売上)
                dt.Columns.Add(CT_StockConf_SalStockPriceConsTaxRF, typeof(Int64));
                dt.Columns[CT_StockConf_SalStockPriceConsTaxRF].DefaultValue = 0;
                //合計金額(売上)
                dt.Columns.Add(CT_StockConf_SalTotalPriceRF, typeof(Int64));
                dt.Columns[CT_StockConf_SalTotalPriceRF].DefaultValue = 0;

                // 2009.01.09 30413 犬飼 値引の金額を追加 >>>>>>START
                ////仕入金額(返品値引)
                //dt.Columns.Add(CT_StockConf_DisStockPricTaxExcRF, typeof(Int64));
                //dt.Columns[CT_StockConf_DisStockPricTaxExcRF].DefaultValue = 0;
                ////消費税(返品値引)
                //dt.Columns.Add(CT_StockConf_DisStockPriceConsTaxRF, typeof(Int64));
                //dt.Columns[CT_StockConf_DisStockPriceConsTaxRF].DefaultValue = 0;
                ////合計金額(返品値引)
                //dt.Columns.Add(CT_StockConf_DisTotalPriceRF, typeof(Int64));
                //dt.Columns[CT_StockConf_DisTotalPriceRF].DefaultValue = 0;
                //仕入金額(返品)
                dt.Columns.Add(CT_StockConf_RetGdsStockPricTaxExcRF, typeof(Int64));
                dt.Columns[CT_StockConf_RetGdsStockPricTaxExcRF].DefaultValue = 0;
                //消費税(返品)
                dt.Columns.Add(CT_StockConf_RetGdsStockPriceConsTaxRF, typeof(Int64));
                dt.Columns[CT_StockConf_RetGdsStockPriceConsTaxRF].DefaultValue = 0;
                //合計金額(返品)
                dt.Columns.Add(CT_StockConf_RetGdsTotalPriceRF, typeof(Int64));
                dt.Columns[CT_StockConf_RetGdsTotalPriceRF].DefaultValue = 0;
                // --- ADD 2008/07/16 --------------------------------<<<<< 

                //仕入金額(値引)
                dt.Columns.Add(CT_StockConf_DisStockPricTaxExcRF, typeof(Int64));
                dt.Columns[CT_StockConf_DisStockPricTaxExcRF].DefaultValue = 0;
                //消費税(値引)
                dt.Columns.Add(CT_StockConf_DisStockPriceConsTaxRF, typeof(Int64));
                dt.Columns[CT_StockConf_DisStockPriceConsTaxRF].DefaultValue = 0;
                //合計金額(値引)
                dt.Columns.Add(CT_StockConf_DisTotalPriceRF, typeof(Int64));
                dt.Columns[CT_StockConf_DisTotalPriceRF].DefaultValue = 0;
                // 2009.01.09 30413 犬飼 値引の金額を追加 <<<<<<END
        
                // キーブレイク
				dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
				dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";

                // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
                // 仕入先総額表示方法区分
                dt.Columns.Add(CT_StockConf_SuppTtlAmntDspWayCd, typeof(int));
                dt.Columns[CT_StockConf_SuppTtlAmntDspWayCd].DefaultValue = 0;

                // 仕入先消費税転嫁方式コード
                dt.Columns.Add(CT_StockConf_SuppCTaxLayCd, typeof(int));
                dt.Columns[CT_StockConf_SuppCTaxLayCd].DefaultValue = 0;

                // 課税区分
                dt.Columns.Add(CT_StockConf_TaxationCode, typeof(int));
                dt.Columns[CT_StockConf_TaxationCode].DefaultValue = 0;
                // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<

                // --- ADD START 3H 尹安 2020/02/27 ---------->>>>>
                // 消費税税率
                dt.Columns.Add(CT_Col_ConsTaxRate, typeof(string));
                dt.Columns[CT_Col_ConsTaxRate].DefaultValue = "";
                #region 「消費税税率１」
                // Title_税率１
                dt.Columns.Add(CT_StockConf_TaxRate1_Title, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_Title].DefaultValue = "";
                // 仕入枚数_税率１
                dt.Columns.Add(CT_StockConf_TaxRate1_SalSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_SalSlipCntRF].DefaultValue = "";
                // 仕入金額計（税抜き）_税率１
                dt.Columns.Add(CT_StockConf_TaxRate1_StockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_StockTtlPricTaxExcRF].DefaultValue = "";
                // Title(返品値引)_税率１
                dt.Columns.Add(CT_StockConf_TaxRate1_RetTitle, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_RetTitle].DefaultValue = "";
                // 伝票枚数(返品値引)_税率１
                dt.Columns.Add(CT_StockConf_TaxRate1_DisSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_DisSlipCntRF].DefaultValue = "";
                // 仕入金額(返品)_税率１
                dt.Columns.Add(CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
                #endregion
                #region 「消費税税率２」
                // Title_税率２
                dt.Columns.Add(CT_StockConf_TaxRate2_Title, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_Title].DefaultValue = "";
                // 仕入枚数_税率２</summary>
                dt.Columns.Add(CT_StockConf_TaxRate2_SalSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_SalSlipCntRF].DefaultValue = "";
                // 仕入金額計（税抜き）_税率２
                dt.Columns.Add(CT_StockConf_TaxRate2_StockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_StockTtlPricTaxExcRF].DefaultValue = "";
                // Title(返品値引)_税率２
                dt.Columns.Add(CT_StockConf_TaxRate2_RetTitle, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_RetTitle].DefaultValue = "";
                // 伝票枚数(返品値引)_税率２<
                dt.Columns.Add(CT_StockConf_TaxRate2_DisSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_DisSlipCntRF].DefaultValue = "";
                // 仕入金額(返品)_税率２
                dt.Columns.Add(CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
                #endregion
                #region 「消費税税率その他」
                // Title_その他
                dt.Columns.Add(CT_StockConf_Other_Title, typeof(string));
                dt.Columns[CT_StockConf_Other_Title].DefaultValue = "";
                // 仕入枚数_その他
                dt.Columns.Add(CT_StockConf_Other_SalSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_Other_SalSlipCntRF].DefaultValue = "";
                // 仕入金額計（税抜き）_その他
                dt.Columns.Add(CT_StockConf_Other_StockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_Other_StockTtlPricTaxExcRF].DefaultValue = "";
                // Title(返品値引)_その他
                dt.Columns.Add(CT_StockConf_Other_RetTitle, typeof(string));
                dt.Columns[CT_StockConf_Other_RetTitle].DefaultValue = "";
                // 仕入枚数(返品値引)_その他
                dt.Columns.Add(CT_StockConf_Other_DisSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_Other_DisSlipCntRF].DefaultValue = "";
                // 仕入金額(返品)_その他
                dt.Columns.Add(CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
                #endregion
                // --- ADD END 3H 尹安 2020/02/27 ----------<<<<<

                // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                #region 「消費税税率非課税」
                // Title_非課税
                dt.Columns.Add(CT_StockConf_TaxFree_Title, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_Title].DefaultValue = "";
                // 仕入枚数_非課税
                dt.Columns.Add(CT_StockConf_TaxFree_SalSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_SalSlipCntRF].DefaultValue = "";
                // 仕入金額計（税抜き）_非課税
                dt.Columns.Add(CT_StockConf_TaxFree_StockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_StockTtlPricTaxExcRF].DefaultValue = "";
                // Title(返品値引)_非課税
                dt.Columns.Add(CT_StockConf_TaxFree_RetTitle, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_RetTitle].DefaultValue = "";
                // 仕入枚数(返品値引)_非課税
                dt.Columns.Add(CT_StockConf_TaxFree_DisSlipCntRF, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_DisSlipCntRF].DefaultValue = "";
                // 仕入金額(返品)_非課税
                dt.Columns.Add(CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF, typeof(string));
                dt.Columns[CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF].DefaultValue = "";
                #endregion
                // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

		}

		#endregion
	}
}