//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売掛残高一覧表(総括)
// プログラム概要   : 売掛残高一覧表(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 修 正 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号  11800255-00 作成担当 : 陳艶丹
// 修 正 日  2022/10/13  修正内容 : インボイス対応（税率別合計金額不具合修正）
//----------------------------------------------------------------------------//

using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// 売掛残高一覧表(総括)テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売掛残高一覧表(総括)テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/04/10</br>
	/// </remarks>
	public class PMHNB02274EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string Col_Tbl_SumBillBalance = "Tbl_SumBillBalance";

        /// <summary> 拠点コード </summary>
        public const string Col_AddUpSecCode = "AddUpSecCode";

        /// <summary> 拠点名称 </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> 総括請求先コード </summary>
        public const string Col_ClaimCode = "ClaimCode";

        /// <summary> 総括請求先略称 </summary>
        public const string Col_ClaimSnm = "ClaimSnm";

        /// <summary> 前月末残高 </summary>
        public const string Col_LastTimeAccRec = "LastTimeAccRec";

        /// <summary> 当月入金 </summary>
        public const string Col_ThisTimeDmdNrml = "ThisTimeDmdNrml";

        /// <summary> 繰越額 </summary>
        public const string Col_ThisTimeTtlBlcAcc = "ThisTimeTtlBlcAcc";

        /// <summary> 売上額 </summary>
        public const string Col_OfsThisTimeSales = "OfsThisTimeSales";

        /// <summary> 返品値引 </summary>
        public const string Col_ThisRgdsDisPric = "ThisRgdsDisPric";

        /// <summary> 消費税 </summary>
        public const string Col_OfsThisSalesTax = "OfsThisSalesTax";

        /// <summary> 当月末残高 </summary>
        public const string Col_AfCalTMonthAccRec = "AfCalTMonthAccRec";

        /// <summary> 枚数 </summary>
        public const string Col_SalesSlipCount = "SalesSlipCount";

        /// <summary> 担当者コード </summary>
        public const string Col_AgentCd = "AgentCd";

        /// <summary> 担当者名 </summary>
        public const string Col_Name = "Name";

        /// <summary> 地区コード </summary>
        public const string Col_SalesAreaCode = "SalesAreaCode";

        /// <summary> 地区名 </summary>
        public const string Col_SalesAreaName = "SalesAreaName";

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

        /// <summary> 今回売上金額 </summary>
        public const string Col_ThisTimeSales = "ThisTimeSales";

        /// <summary> 総括得意先コード </summary>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> 総括得意先略称 </summary>
        public const string Col_Customersnm = "Customersnm";

        // 印刷用
        /// <summary> 純売上額 </summary>
        public const string ct_Col_PureSales = "PureSales";

        /// <summary> 月次締未更新 </summary>
        public const string Col_MonAddUpNonProc = "MonAddUpNonProc";

        /// <summary> 当月合計 </summary>
        public const string Col_SalesPricTax = "SalesPricTax";

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
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
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

        // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
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
        // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 売掛残高一覧表(総括)テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表(総括)テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br></br>
        /// </remarks>
		public PMHNB02274EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ CreateDataTable(ref DataSet ds)
		/// <summary>
        /// 売掛残高一覧表(総括)DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
        /// <br>Note       : 売掛残高一覧表(総括)データセットのスキーマを設定する。</br>
		/// <br></br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
        static public void CreateDataTableSumBillBalance(ref DataSet ds)
		{
            string defValuestring = "";
            Int32 defValueInt32 = 0;
            Int64 defValueInt64 = 0;

			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_SumBillBalance))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_SumBillBalance].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_SumBillBalance);

                DataTable dt = ds.Tables[Col_Tbl_SumBillBalance];

                dt.Columns.Add(Col_AddUpSecCode, typeof(string));               // 拠点コード
                dt.Columns[Col_AddUpSecCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));            // 拠点名称
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ClaimCode, typeof(Int32));                   // 総括請求先コード
                dt.Columns[Col_ClaimCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_ClaimSnm, typeof(string));                   // 総括請求先略称
                dt.Columns[Col_ClaimSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LastTimeAccRec, typeof(Int64));              // 前月末残高
                dt.Columns[Col_LastTimeAccRec].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_ThisTimeDmdNrml, typeof(Int64));             // 当月入金
                dt.Columns[Col_ThisTimeDmdNrml].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_ThisTimeTtlBlcAcc, typeof(Int64));           // 繰越額
                dt.Columns[Col_ThisTimeTtlBlcAcc].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_OfsThisTimeSales, typeof(Int64));            // 売上額
                dt.Columns[Col_OfsThisTimeSales].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_ThisRgdsDisPric, typeof(Int64));             // 返品値引
                dt.Columns[Col_ThisRgdsDisPric].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_OfsThisSalesTax, typeof(Int64));             // 消費税
                dt.Columns[Col_OfsThisSalesTax].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_AfCalTMonthAccRec, typeof(Int64));           // 当月末残高
                dt.Columns[Col_AfCalTMonthAccRec].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_SalesSlipCount, typeof(Int32));              // 枚数
                dt.Columns[Col_SalesSlipCount].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_AgentCd, typeof(string));                    // 担当者コード
                dt.Columns[Col_AgentCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_Name, typeof(string));                       // 担当者名
                dt.Columns[Col_Name].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SalesAreaCode, typeof(Int32));               // 地区コード
                dt.Columns[Col_SalesAreaCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SalesAreaName, typeof(string));              // 地区名
                dt.Columns[Col_SalesAreaName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ThisTimeFeeDmdNrml, typeof(Int64));          // 手数料
                dt.Columns[Col_ThisTimeFeeDmdNrml].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_ThisTimeDisDmdNrml, typeof(Int64));          // 値引
                dt.Columns[Col_ThisTimeDisDmdNrml].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_CashDeposit, typeof(Int64));                 // 現金
                dt.Columns[Col_CashDeposit].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_TrfrDeposit, typeof(Int64));                 // 振込
                dt.Columns[Col_TrfrDeposit].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_CheckDeposit, typeof(Int64));                // 小切手
                dt.Columns[Col_CheckDeposit].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_DraftDeposit, typeof(Int64));                // 手形
                dt.Columns[Col_DraftDeposit].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_OffsetDeposit, typeof(Int64));               // 相殺
                dt.Columns[Col_OffsetDeposit].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_FundTransferDeposit, typeof(Int64));         // 口座振替
                dt.Columns[Col_FundTransferDeposit].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_OthsDeposit, typeof(Int64));                 // その他
                dt.Columns[Col_OthsDeposit].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_ThisTimeSales, typeof(Int64));               // 今回売上金額
                dt.Columns[Col_ThisTimeSales].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_CustomerCode, typeof(Int32));                // 総括得意先コード
                dt.Columns[Col_CustomerCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_Customersnm, typeof(string));                // 総括得意先略称
                dt.Columns[Col_Customersnm].DefaultValue = defValuestring;

                // 印刷用
                // 純仕入額
                dt.Columns.Add(ct_Col_PureSales, typeof(Int64));
                dt.Columns[ct_Col_PureSales].DefaultValue = defValueInt64;

                // 月次締未更新
                dt.Columns.Add(Col_MonAddUpNonProc, typeof(bool));
                dt.Columns[Col_MonAddUpNonProc].DefaultValue = false;

                // 当月合計
                dt.Columns.Add(Col_SalesPricTax, typeof(long));
                dt.Columns[Col_SalesPricTax].DefaultValue = defValueInt64;

                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
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
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<

                // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
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
                // --- ADD 2022/10/13 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
            }
		}
		#endregion
		#endregion
	}
}
