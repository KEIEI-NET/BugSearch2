using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// 売掛残高一覧表 得意先売掛金額データ用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売掛残高一覧表 得意先売掛金額データ用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 20081 疋田　勇人</br>
	/// <br>Date       : 2007.10.24</br>
	/// <br></br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/02/28</br>
    /// <br>UpdateNote : 11800255-00　インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2022/09/19</br>  
	/// </remarks>
	public class DCKAU02544EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string Col_Tbl_CustAccRecMain = "Tbl_CustAccRecMain";

        /// <summary> 計上拠点コード </summary>
        /// <remarks> 集計の対象となっている拠点コード</remarks>
        public const string Col_AddUpSecCode = "AddUpSecCode";

        /// <summary> 計上拠点名称 </summary>
        public const string Col_AddUpSecName = "AddUpSecName";

        /// <summary> 計上拠点名称(明細用) </summary>
        public const string Col_AddUpSecName_Detail = "AddUpSecName_Detail";

        /// <summary> 請求先コード </summary>
        public const string Col_ClaimCode = "ClaimCode";

        ///// <summary> 請求先名称 </summary>
        //public const string Col_ClaimName = "ClaimName";

        ///// <summary> 請求先名称2 </summary>
        //public const string Col_ClaimName2 = "ClaimName2";

        ///// <summary> 請求先カナ </summary>
        //public const string Col_ClaimKana = "ClaimKana";

        /// <summary> 請求先略称 </summary>
        public const string Col_ClaimSnm = "ClaimSnm";

        ///// <summary> 集金担当従業員コード </summary>
        //public const string Col_BillCollecterCd = "BillCollecterCd";

        ///// <summary> 集金担当従業員名称 </summary>
        //public const string Col_BillCollecterNm = "BillCollecterNm";

        ///// <summary> 顧客担当従業員コード </summary>
        //public const string Col_CustomerAgentCd = "CustomerAgentCd";

        ///// <summary> 顧客担当従業員名称 </summary>
        //public const string Col_CustomerAgentNm = "CustomerAgentNm";

        /// <summary> 販売エリアコード </summary>
        public const string Col_SalesAreaCode = "SalesAreaCode";

        /// <summary> 販売エリア名称 </summary>
        public const string Col_SalesAreaName = "SalesAreaName";

        /// <summary> 計上年月日 </summary>
        public const string Col_AddUpDate = "AddUpDate";

        /// <summary> ソート用計上年月日 </summary>
        public const string Col_Sort_AddUpDate = "Sort_AddUpDate";

        /// <summary> 計上年月 </summary>
        public const string Col_AddUpYearMonth = "AddUpYearMonth";

        /// <summary> ソート用計上年月 </summary>
        public const string Col_Sort_AddUpYearMonth = "Sort_AddUpYearMonth";

        /// <summary> 前回売掛金額 </summary>     
        public const string Col_LastTimeAccRec = "LastTimeAccRec";

        /// <summary> 今回入金金額（通常入金）</summary>
        public const string Col_ThisTimeDmdNrml = "ThisTimeDmdNrml";

        /// <summary> 今回繰越残高 </summary>        
        public const string Col_ThisTimeTtlBlcAcc = "ThisTimeTtlBlcAcc";

        /// <summary> 相殺後今回売上金額 </summary>
        public const string Col_OfsThisTimeSales = "OfsThisTimeSales";

        /// <summary> 返品値引 </summary>
        public const string Col_ThisRgdsDisPric = "ThisRgdsDisPric";

        /// <summary> 相殺後今回売上消費税 </summary>
        public const string Col_OfsThisSalesTax = "OfsThisSalesTax";

        // 2009.01.27 30413 犬飼 今回売上金額の復活 >>>>>>START
        /// <summary> 今回売上金額 </summary>
        public const string Col_ThisTimeSales = "ThisTimeSales";
        // 2009.01.27 30413 犬飼 今回売上金額の復活 <<<<<<END
                
        ///// <summary> 今回売上返品金額 </summary>
        //public const string Col_ThisSalesPricRgds = "ThisSalesPricRgds";

        ///// <summary> 今回売上値引金額 </summary>
        //public const string Col_ThisSalesPricDis = "ThisSalesPricDis";

        ///// <summary> 今回支払相殺金額 </summary>
        //public const string Col_ThisPayOffset = "ThisPayOffset";

        ///// <summary> 消費税調整額 </summary>
        //public const string Col_TaxAdjust = "TaxAdjust";

        ///// <summary> 残高調整額 </summary>
        //public const string Col_BalanceAdjust = "BalanceAdjust";

        /// <summary> 計算後当月売掛金額 </summary>
        public const string Col_AfCalTMonthAccRec = "AfCalTMonthAccRec";

        /// <summary> 売上伝票枚数 </summary>
        public const string Col_SalesSlipCount = "SalesSlipCount";

        ///// <summary> 今回売上返品・値引 </summary>
        //public const string Col_ThisSalesPricRgdsDis = "ThisSalesPricRgdsDis";

        /// <summary> 当月合計 </summary>
        public const string Col_SalesPricTax = "SalesPricTax";

        /// <summary> 担当者コード </summary>
        public const string Col_AgentCd = "AgentCd";

        /// <summary> 担当者名 </summary>
        public const string Col_Name = "Name";

        /// <summary> 手数料 </summary>
        public const string Col_ThisTimeFeeDmdNrml = "ThisTimeFeeDmdNrml";

        /// <summary> 値引 </summary>
        public const string Col_ThisTimeDisDmdNrml = "ThisTimeDisDmdNrml";

        /// <summary> 現金 </summary>
        public const string Col_CashDeposit = "CashDeposit";

        /// <summary> 振込 </summary>
        public const string Col_TrfrDeposit = "TrfrDeposit";

        /// <summary> 小切手 </summary>
        public const string Col_CheckDeposit = "CheckDeposit";

        /// <summary> 手形 </summary>
        public const string Col_DraftDeposit = "DraftDeposit";

        /// <summary> 相殺 </summary>
        public const string Col_OffsetDeposit = "OffsetDeposit";

        /// <summary> 口座振替 </summary>
        public const string Col_FundTransferDeposit = "FundTransferDeposit";

        /// <summary> その他 </summary>
        public const string Col_OthsDeposit = "OthsDeposit";

        // 印刷用
        /// <summary> 純売上額 </summary>
        public const string ct_Col_PureSales = "PureSales";

        /// <summary> 月次締未更新 </summary>
        public const string Col_MonAddUpNonProc = "MonAddUpNonProc";

        // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
        /// <summary> 売上額(計税率1) </summary>
        public const string Col_TotalThisTimeSalesTaxRate1 = "TotalThisTimeSalesTaxRate1";

        /// <summary> 売上額(計税率2) </summary>
        public const string Col_TotalThisTimeSalesTaxRate2 = "TotalThisTimeSalesTaxRate2";

        /// <summary> 売上額(計その他) </summary>
        public const string Col_TotalThisTimeSalesOther = "TotalThisTimeSalesOther";

        /// <summary> 返品値引(計税率1) </summary>
        public const string Col_TotalThisRgdsDisPricTaxRate1 = "TotalThisRgdsDisPricTaxRate1";

        /// <summary> 返品値引(計税率2) </summary>
        public const string Col_TotalThisRgdsDisPricTaxRate2 = "TotalThisRgdsDisPricTaxRate2";

        /// <summary> 返品値引(計その他) </summary>
        public const string Col_TotalThisRgdsDisPricOther = "TotalThisRgdsDisPricOther";

        /// <summary> 純売上額(計税率1) </summary>
        public const string Col_TotalPureSalesTaxRate1 = "TotalPureSalesTaxRate1";

        /// <summary> 純売上額(計税率2) </summary>
        public const string Col_TotalPureSalesTaxRate2 = "TotalPureSalesTaxRate2";

        /// <summary> 純売上額(計その他) </summary>
        public const string Col_TotalPureSalesOther = "TotalPureSalesOther";

        /// <summary> 消費税(計税率1) </summary>
        public const string Col_TotalSalesPricTaxTaxRate1 = "TotalSalesPricTaxTaxRate1";

        /// <summary> 消費税(計税率2) </summary>
        public const string Col_TotalSalesPricTaxTaxRate2 = "TotalSalesPricTaxTaxRate2";

        /// <summary> 消費税(計その他) </summary>
        public const string Col_TotalSalesPricTaxOther = "TotalSalesPricTaxOther";

        /// <summary> 当月合計(計税率1) </summary>
        public const string Col_TotalAfCalTMonthAccRecTaxRate1 = "TotalAfCalTMonthAccRecTaxRate1";

        /// <summary> 当月合計(計税率2) </summary>
        public const string Col_TotalAfCalTMonthAccRecTaxRate2 = "TotalAfCalTMonthAccRecTaxRate2";

        /// <summary> 当月合計(計その他) </summary>
        public const string Col_TotalAfCalTMonthAccRecOther = "TotalAfCalTMonthAccRecOther";

        /// <summary> 枚数(計税率1) </summary>
        public const string Col_TotalSalesSlipCountTaxRate1 = "TotalSalesSlipCountTaxRate1";

        /// <summary> 枚数(計税率2) </summary>
        public const string Col_TotalSalesSlipCountTaxRate2 = "TotalSalesSlipCountTaxRate2";

        /// <summary> 枚数(計その他) </summary>
        public const string Col_TotalSalesSlipCountOther = "TotalSalesSlipCountOther";

        /// <summary> 税率1タイトル </summary>
        public const string Col_TitleTaxRate1 = "TitleTaxRate1";

        /// <summary> 税率2タイトル </summary>
        public const string Col_TitleTaxRate2 = "TitleTaxRate2";
        // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<

        // --- ADD 2022/09/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
        /// <summary> 売上額(計非課税) </summary>
        public const string Col_TotalThisTimeSalesTaxFree = "TotalThisTimeSalesTaxFree";
        /// <summary> 返品値引(計非課税) </summary>
        public const string Col_TotalThisRgdsDisPricTaxFree = "TotalThisRgdsDisPricTaxFree";
        /// <summary> 純売上額(計非課税) </summary>
        public const string Col_TotalPureSalesTaxFree = "TotalPureSalesTaxFree";
        /// <summary> 消費税(計非課税) </summary>
        public const string Col_TotalSalesPricTaxTaxFree = "TotalSalesPricTaxTaxFree";
        /// <summary> 当月合計(計非課税) </summary>
        public const string Col_TotalAfCalTMonthAccRecTaxFree = "TotalAfCalTMonthAccRecTaxFree";
        /// <summary> 枚数(計非課税) </summary>
        public const string Col_TotalSalesSlipCountTaxFree = "TotalSalesSlipCountTaxFree";
        // --- ADD 2022/09/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 売掛残高一覧表 得意先売掛金額データ用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表 得意先売掛金額データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.24</br>
		/// </remarks>
		public DCKAU02544EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ CreateDataTable(ref DataSet ds)
		/// <summary>
        /// 得意先売掛金額DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
        /// <br>Note       : 得意先売掛金額データセットのスキーマを設定する。</br>
		/// <br>Programmer : 20081 疋田　勇人</br>
		/// <br>Date       : 2007.10.24</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/02/28</br>
		/// </remarks>
        static public void CreateDataTableCustAccRecMain(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_CustAccRecMain))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_CustAccRecMain].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_CustAccRecMain);

                DataTable dt = ds.Tables[Col_Tbl_CustAccRecMain];

                dt.Columns.Add(Col_AddUpSecCode, typeof(string));		            // 計上拠点コード
                dt.Columns[Col_AddUpSecCode].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName, typeof(string));	            	// 計上拠点名称
                dt.Columns[Col_AddUpSecName].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName_Detail, typeof(string));		    // 計上拠点名称(明細)
                dt.Columns[Col_AddUpSecName_Detail].DefaultValue = "";

                dt.Columns.Add(Col_ClaimCode, typeof(int));  			            // 請求先コード
                dt.Columns[Col_ClaimCode].DefaultValue = 0;

                //dt.Columns.Add(Col_ClaimName, typeof(string));		                // 請求先名称
                //dt.Columns[Col_ClaimName].DefaultValue = "";

                //dt.Columns.Add(Col_ClaimName2, typeof(string));		                // 請求先名称2
                //dt.Columns[Col_ClaimName2].DefaultValue = "";

                //dt.Columns.Add(Col_ClaimKana, typeof(string));		                // 請求先カナ
                //dt.Columns[Col_ClaimKana].DefaultValue = "";

                dt.Columns.Add(Col_ClaimSnm, typeof(string));		                // 請求先略称
                dt.Columns[Col_ClaimSnm].DefaultValue = "";

                //dt.Columns.Add(Col_BillCollecterCd, typeof(string));		        // 集金担当従業員コード
                //dt.Columns[Col_BillCollecterCd].DefaultValue = "";

                //dt.Columns.Add(Col_BillCollecterNm, typeof(string));		        // 集金担当従業員名称
                //dt.Columns[Col_BillCollecterNm].DefaultValue = "";

                //dt.Columns.Add(Col_CustomerAgentCd, typeof(string));		        // 顧客担当従業員コード
                //dt.Columns[Col_CustomerAgentCd].DefaultValue = "";

                //dt.Columns.Add(Col_CustomerAgentNm, typeof(string));		        // 顧客担当従業員名称
                //dt.Columns[Col_CustomerAgentNm].DefaultValue = "";

                dt.Columns.Add(Col_SalesAreaCode, typeof(string));		            // 販売エリアコード
                dt.Columns[Col_SalesAreaCode].DefaultValue = "";

                dt.Columns.Add(Col_SalesAreaName, typeof(string));		            // 販売エリア名称
                dt.Columns[Col_SalesAreaName].DefaultValue = "";

                dt.Columns.Add(Col_AddUpDate, typeof(string));		                // 計上年月日
                dt.Columns[Col_AddUpDate].DefaultValue = "";

                dt.Columns.Add(Col_Sort_AddUpDate, typeof(long));		            // ソート用計上年月日
                dt.Columns[Col_Sort_AddUpDate].DefaultValue = 0;

                dt.Columns.Add(Col_AddUpYearMonth, typeof(string));		            // 計上年月
                dt.Columns[Col_AddUpYearMonth].DefaultValue = "";

                dt.Columns.Add(Col_Sort_AddUpYearMonth, typeof(long));		        // ソート用計上年月
                dt.Columns[Col_Sort_AddUpYearMonth].DefaultValue = 0;

                dt.Columns.Add(Col_LastTimeAccRec, typeof(long));		            // 前回売掛金額
                dt.Columns[Col_LastTimeAccRec].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeDmdNrml, typeof(long));		            // 今回入金金額（通常入金）
                dt.Columns[Col_ThisTimeDmdNrml].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeTtlBlcAcc, typeof(long));		        // 今回繰越残高
                dt.Columns[Col_ThisTimeTtlBlcAcc].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisTimeSales, typeof(long));		            // 相殺後今回売上金額
                dt.Columns[Col_OfsThisTimeSales].DefaultValue = 0;

                dt.Columns.Add(Col_ThisRgdsDisPric, typeof(long));		            // 返品値引
                dt.Columns[Col_ThisRgdsDisPric].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisSalesTax, typeof(long));		            // 相殺後今回売上消費税
                dt.Columns[Col_OfsThisSalesTax].DefaultValue = 0;

                // 2009.01.27 30413 犬飼 今回売上金額の復活 >>>>>>START
                dt.Columns.Add(Col_ThisTimeSales, typeof(long));		            // 今回売上金額
                dt.Columns[Col_ThisTimeSales].DefaultValue = 0;
                // 2009.01.27 30413 犬飼 今回売上金額の復活 <<<<<<END
                
                //dt.Columns.Add(Col_ThisSalesPricRgds, typeof(long));		        // 今回売上返品金額
                //dt.Columns[Col_ThisSalesPricRgds].DefaultValue = 0;

                //dt.Columns.Add(Col_ThisSalesPricDis, typeof(long));		            // 今回売上値引金額
                //dt.Columns[Col_ThisSalesPricDis].DefaultValue = 0;

                //dt.Columns.Add(Col_ThisPayOffset, typeof(long));		            // 今回支払相殺金額
                //dt.Columns[Col_ThisPayOffset].DefaultValue = 0;

                //dt.Columns.Add(Col_TaxAdjust, typeof(long));		                // 消費税調整額
                //dt.Columns[Col_TaxAdjust].DefaultValue = 0;

                //dt.Columns.Add(Col_BalanceAdjust, typeof(long));		            // 残高調整額
                //dt.Columns[Col_BalanceAdjust].DefaultValue = 0;

                dt.Columns.Add(Col_AfCalTMonthAccRec, typeof(long));		        // 計算後当月売掛金額
                dt.Columns[Col_AfCalTMonthAccRec].DefaultValue = 0;

                dt.Columns.Add(Col_SalesSlipCount, typeof(long));		            // 売上伝票枚数
                dt.Columns[Col_SalesSlipCount].DefaultValue = 0;

                //dt.Columns.Add(Col_ThisSalesPricRgdsDis, typeof(long));		        // 今回売上返品・値引
                //dt.Columns[Col_ThisSalesPricRgdsDis].DefaultValue = 0;

                dt.Columns.Add(Col_SalesPricTax, typeof(long));		                // 当月合計
                dt.Columns[Col_SalesPricTax].DefaultValue = 0;

                // 担当者コード
                dt.Columns.Add(Col_AgentCd, typeof(string));
                dt.Columns[Col_AgentCd].DefaultValue = "";

                // 担当者名
                dt.Columns.Add(Col_Name, typeof(string));
                dt.Columns[Col_Name].DefaultValue = "";

                // 手数料
                dt.Columns.Add(Col_ThisTimeFeeDmdNrml, typeof(Int64));
                dt.Columns[Col_ThisTimeFeeDmdNrml].DefaultValue = 0;

                // 値引
                dt.Columns.Add(Col_ThisTimeDisDmdNrml, typeof(Int64));
                dt.Columns[Col_ThisTimeDisDmdNrml].DefaultValue = 0;

                // 現金
                dt.Columns.Add(Col_CashDeposit, typeof(Int64));
                dt.Columns[Col_CashDeposit].DefaultValue = 0;

                // 振込
                dt.Columns.Add(Col_TrfrDeposit, typeof(Int64));
                dt.Columns[Col_TrfrDeposit].DefaultValue = 0;

                // 小切手
                dt.Columns.Add(Col_CheckDeposit, typeof(Int64));
                dt.Columns[Col_CheckDeposit].DefaultValue = 0;

                // 手形
                dt.Columns.Add(Col_DraftDeposit, typeof(Int64));
                dt.Columns[Col_DraftDeposit].DefaultValue = 0;

                // 相殺
                dt.Columns.Add(Col_OffsetDeposit, typeof(Int64));
                dt.Columns[Col_OffsetDeposit].DefaultValue = 0;

                // 口座振替
                dt.Columns.Add(Col_FundTransferDeposit, typeof(Int64));
                dt.Columns[Col_FundTransferDeposit].DefaultValue = 0;

                // その他
                dt.Columns.Add(Col_OthsDeposit, typeof(Int64));
                dt.Columns[Col_OthsDeposit].DefaultValue = 0;

                // 印刷用
                // 純仕入額
                dt.Columns.Add(ct_Col_PureSales, typeof(Int64));
                dt.Columns[ct_Col_PureSales].DefaultValue = 0;

                // 月次締未更新
                dt.Columns.Add(Col_MonAddUpNonProc, typeof(bool));
                dt.Columns[Col_MonAddUpNonProc].DefaultValue = false;

                // --- ADD START 3H 劉星光 2020/02/28 ---------->>>>>
                // 売上額(計税率1)
                dt.Columns.Add(Col_TotalThisTimeSalesTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalThisTimeSalesTaxRate1].DefaultValue = 0;

                // 売上額(計税率2)
                dt.Columns.Add(Col_TotalThisTimeSalesTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalThisTimeSalesTaxRate2].DefaultValue = 0;

                // 売上額(計その他)
                dt.Columns.Add(Col_TotalThisTimeSalesOther, typeof(Int64));
                dt.Columns[Col_TotalThisTimeSalesOther].DefaultValue = 0;

                // 返品値引(計税率1)
                dt.Columns.Add(Col_TotalThisRgdsDisPricTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricTaxRate1].DefaultValue = 0;

                // 返品値引(計税率2)
                dt.Columns.Add(Col_TotalThisRgdsDisPricTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricTaxRate2].DefaultValue = 0;

                // 返品値引(計その他)
                dt.Columns.Add(Col_TotalThisRgdsDisPricOther, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricOther].DefaultValue = 0;

                // 純売上額(計税率1)
                dt.Columns.Add(Col_TotalPureSalesTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalPureSalesTaxRate1].DefaultValue = 0;

                // 純売上額(計税率2)
                dt.Columns.Add(Col_TotalPureSalesTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalPureSalesTaxRate2].DefaultValue = 0;

                // 純売上額(計その他)
                dt.Columns.Add(Col_TotalPureSalesOther, typeof(Int64));
                dt.Columns[Col_TotalPureSalesOther].DefaultValue = 0;

                // 消費税(計税率1)
                dt.Columns.Add(Col_TotalSalesPricTaxTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalSalesPricTaxTaxRate1].DefaultValue = 0;

                // 消費税(計税率2)
                dt.Columns.Add(Col_TotalSalesPricTaxTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalSalesPricTaxTaxRate2].DefaultValue = 0;

                // 消費税(計その他)
                dt.Columns.Add(Col_TotalSalesPricTaxOther, typeof(Int64));
                dt.Columns[Col_TotalSalesPricTaxOther].DefaultValue = 0;

                // 当月合計(計税率1)
                dt.Columns.Add(Col_TotalAfCalTMonthAccRecTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalAfCalTMonthAccRecTaxRate1].DefaultValue = 0;

                // 当月合計(計税率2)
                dt.Columns.Add(Col_TotalAfCalTMonthAccRecTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalAfCalTMonthAccRecTaxRate2].DefaultValue = 0;

                // 当月合計(計その他)
                dt.Columns.Add(Col_TotalAfCalTMonthAccRecOther, typeof(Int64));
                dt.Columns[Col_TotalAfCalTMonthAccRecOther].DefaultValue = 0;

                // 枚数(計税率1)
                dt.Columns.Add(Col_TotalSalesSlipCountTaxRate1, typeof(Int32));
                dt.Columns[Col_TotalSalesSlipCountTaxRate1].DefaultValue = 0;

                // 枚数(計税率2)
                dt.Columns.Add(Col_TotalSalesSlipCountTaxRate2, typeof(Int32));
                dt.Columns[Col_TotalSalesSlipCountTaxRate2].DefaultValue = 0;

                // 枚数(計その他)
                dt.Columns.Add(Col_TotalSalesSlipCountOther, typeof(Int32));
                dt.Columns[Col_TotalSalesSlipCountOther].DefaultValue = 0;

                // 税率1タイトル
                dt.Columns.Add(Col_TitleTaxRate1, typeof(string));
                dt.Columns[Col_TitleTaxRate1].DefaultValue = string.Empty;

                // 税率2タイトル
                dt.Columns.Add(Col_TitleTaxRate2, typeof(string));
                dt.Columns[Col_TitleTaxRate2].DefaultValue = string.Empty;
                // --- ADD END 3H 劉星光 2020/02/28 ----------<<<<<

                // --- ADD 2022/09/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                // 売上額(計非課税)
                dt.Columns.Add(Col_TotalThisTimeSalesTaxFree, typeof(Int64));
                dt.Columns[Col_TotalThisTimeSalesTaxFree].DefaultValue = 0;
                // 返品値引(計非課税)
                dt.Columns.Add(Col_TotalThisRgdsDisPricTaxFree, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricTaxFree].DefaultValue = 0;
                // 純売上額(計非課税)
                dt.Columns.Add(Col_TotalPureSalesTaxFree, typeof(Int64));
                dt.Columns[Col_TotalPureSalesTaxFree].DefaultValue = 0;
                // 消費税(計非課税)
                dt.Columns.Add(Col_TotalSalesPricTaxTaxFree, typeof(Int64));
                dt.Columns[Col_TotalSalesPricTaxTaxFree].DefaultValue = 0;
                // 当月合計(計非課税)
                dt.Columns.Add(Col_TotalAfCalTMonthAccRecTaxFree, typeof(Int64));
                dt.Columns[Col_TotalAfCalTMonthAccRecTaxFree].DefaultValue = 0;
                // 枚数(計非課税)
                dt.Columns.Add(Col_TotalSalesSlipCountTaxFree, typeof(Int32));
                dt.Columns[Col_TotalSalesSlipCountTaxFree].DefaultValue = 0;
                // --- ADD 2022/09/19 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
            }
		}
		#endregion
		#endregion
	}
}
