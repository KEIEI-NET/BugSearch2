//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 支払一覧表（総括）仕入先支払データ用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 支払一覧表（総括）仕入先支払データ用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : FSI東 隆史</br>
	/// <br>Date       : 2012/09/04</br>
	/// </remarks>
	public class PMKAK02005EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string Col_Tbl_SuplierPayMain = "Tbl_SuplierPayMain";

        /// <summary> 総括計上拠点コード </summary>
        /// <remarks> 集計の対象となっている拠点コード</remarks>
        public const string Col_SumAddUpSecCode = "SumAddUpSecCode";

        /// <summary> 総括計上拠点名称 </summary>
        public const string Col_SumAddUpSecName = "SumAddUpSecName";

        /// <summary> 計上拠点コード </summary>
        /// <remarks> 集計の対象となっている拠点コード</remarks>
        public const string Col_AddUpSecCode = "AddUpSecCode";

        /// <summary> 計上拠点名称 </summary>
        public const string Col_AddUpSecName = "AddUpSecName";

        /// <summary> 計上拠点名称(明細用) </summary>
        public const string Col_AddUpSecName_Detail = "AddUpSecName_Detail";

        /// <remarks> 実績拠点コード </remarks>
        public const string Col_ResultsSectCd = "ResultsSectCd";

        /// <summary> 総括支払先コード </summary>
        public const string Col_SumPayeeCode = "SumPayeeCode";

        /// <summary> 総括支払先略称 </summary>
        public const string Col_SumPayeeSnm = "SumPayeeSnm";

        /// <summary> 支払先コード </summary>
        public const string Col_PayeeCode = "PayeeCode";

        /// <summary> 支払先名称 </summary>
        public const string Col_PayeeName = "PayeeName";

        /// <summary> 支払先名称2 </summary>
        public const string Col_PayeeName2 = "PayeeName2";

        /// <summary> 支払先略称 </summary>
        public const string Col_PayeeSnm = "PayeeSnm";

        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> 仕入先名1 </summary>
        public const string Col_SupplierNm1 = "SupplierNm1";

        /// <summary> 仕入先名2 </summary>
        public const string Col_SupplierNm2 = "SupplierNm2";

        /// <summary> 仕入先略称 </summary>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> 計上年月日 </summary>
        public const string Col_AddUpDate = "AddUpDate";

        /// <summary> ソート用計上年月日 </summary>
        public const string Col_Sort_AddUpDate = "Sort_AddUpDate";

        /// <summary> 計上年月 </summary>
        public const string Col_AddUpYearMonth = "AddUpYearMonth";

        /// <summary> ソート用計上年月 </summary>
        public const string Col_Sort_AddUpYearMonth = "Sort_AddUpYearMonth";

        /// <summary> 前回支払金額 </summary>
        public const string Col_LastTimePayment = "LastTimePayment";

        /// <summary> 仕入2回前残高（支払計） </summary>
        public const string Col_StockTtl2TmBfBlPay = "StockTtl2TmBfBlPay";

        /// <summary> 仕入3回前残高（支払計） </summary>
        public const string Col_StockTtl3TmBfBlPay = "StockTtl3TmBfBlPay";

        /// <summary> 今回支払金額（通常支払）</summary>
        public const string Col_ThisTimePayNrml = "ThisTimePayNrml";

        /// <summary> 今回繰越残高（支払計） </summary>
        public const string Col_ThisTimeTtlBlcPay = "ThisTimeTtlBlcPay";

        /// <summary> 相殺後今回仕入金額 </summary>
        public const string Col_OfsThisTimeStock = "OfsThisTimeStock";

        /// <summary> 相殺後今回仕入消費税 </summary>
        public const string Col_OfsThisStockTax = "OfsThisStockTax";

        /// <summary> 今回仕入金額 </summary>
        public const string Col_ThisTimeStockPrice = "ThisTimeStockPrice";

        /// <summary> 今回返品金額 </summary>
        public const string Col_ThisStckPricRgds = "ThisStckPricRgds";

        /// <summary> 今回値引金額 </summary>
        public const string Col_ThisStckPricDis = "ThisStckPricDis";

        /// <summary> 仕入合計残高（今回分の支払金額）</summary>
        public const string Col_StockTotalPayBalance = "StockTotalPayBalance";

        /// <summary> 仕入合計残高（今回分の支払金額）(フィルター用)</summary>
        public const string Col_StockTotalPayBalanceFilter = "StockTotalPayBalanceFilter";

        /// <summary> 仕入伝票枚数 </summary>
        public const string Col_StockSlipCount = "StockSlipCount";

        /// <summary> 今回手数料額（通常支払） </summary>
        public const string Col_ThisTimeFeePayNrml = "ThisTimeFeePayNrml";

        /// <summary> 今回値引額（通常支払） </summary>
        public const string Col_ThisTimeDisPayNrml = "ThisTimeDisPayNrml";

        /// <summary> 支払月区分名称 </summary>
        public const string Col_PaymentMonthName = "PaymentMonthName";

        /// <summary> 支払日 </summary>
        public const string Col_PaymentDay = "PaymentDay";

        /// <summary> 今回合計 </summary>
        public const string Col_ThisTotal = "ThisTotal";

        // 計算金額(印字用)
        /// <summary> 支払残高 </summary>
        public const string Col_PaymentBalance = "PaymentBalance";

        /// <summary> 返品値引 </summary>
        public const string Col_RetGoodsDiscount = "RetGoodsDiscount";

        /// <summary> 純仕入額 </summary>
        public const string Col_PureCost = "PureCost";

        // 金種コード
        /// <summary> 現金 </summary>
        public const string Col_CashPayment = "CashPayment";
        /// <summary> 振込 </summary>
        public const string Col_TrfrPayment = "TrfrPayment";
        /// <summary> 小切手 </summary>
        public const string Col_CheckPayment = "CheckPayment";
        /// <summary> 手形 </summary>
        public const string Col_DraftPayment = "DraftPayment";
        /// <summary> 相殺 </summary>
        public const string Col_OffsetPayment = "OffsetPayment";
        /// <summary> 口座振替 </summary>
        public const string Col_FundTransferPayment = "FundTransferPayment";
        /// <summary> その他 </summary>
        public const string Col_OthsPayment = "OthsPayment";


        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 支払一覧表（総括）仕入先支払データ用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払一覧表（総括）仕入先支払データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
		/// </remarks>
		public PMKAK02005EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ CreateDataTable(ref DataSet ds)
		/// <summary>
		/// 仕入先支払DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : 仕入先支払データセットのスキーマを設定する。</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
		/// </remarks>
        static public void CreateDataTableSuplierPayMain(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_SuplierPayMain))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_SuplierPayMain].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_SuplierPayMain);

                DataTable dt = ds.Tables[Col_Tbl_SuplierPayMain];

                dt.Columns.Add(Col_SumAddUpSecCode, typeof(string));                // 総括計上拠点コード
                dt.Columns[Col_SumAddUpSecCode].DefaultValue = "";

                dt.Columns.Add(Col_SumAddUpSecName, typeof(string));                // 総括計上拠点名称
                dt.Columns[Col_SumAddUpSecName].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecCode, typeof(string));                   // 計上拠点コード
                dt.Columns[Col_AddUpSecCode].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName, typeof(string));                   // 計上拠点名称
                dt.Columns[Col_AddUpSecName].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName_Detail, typeof(string));            // 計上拠点名称(明細)
                dt.Columns[Col_AddUpSecName_Detail].DefaultValue = "";

                dt.Columns.Add(Col_ResultsSectCd, typeof(string));                  // 実績拠点コード
                dt.Columns[Col_ResultsSectCd].DefaultValue = "";

                dt.Columns.Add(Col_SumPayeeCode, typeof(int));                      // 総括支払先コード
                dt.Columns[Col_SumPayeeCode].DefaultValue = 0;

                dt.Columns.Add(Col_SumPayeeSnm, typeof(string));                    // 総括支払先略称
                dt.Columns[Col_SumPayeeSnm].DefaultValue = "";

                dt.Columns.Add(Col_PayeeCode, typeof(int));                         // 支払先コード
                dt.Columns[Col_PayeeCode].DefaultValue = 0;

                dt.Columns.Add(Col_PayeeName, typeof(string));                      // 支払先名称
                dt.Columns[Col_PayeeName].DefaultValue = "";

                dt.Columns.Add(Col_PayeeName2, typeof(string));                     // 支払先名称2
                dt.Columns[Col_PayeeName2].DefaultValue = "";

                dt.Columns.Add(Col_PayeeSnm, typeof(string));                       // 支払先略称
                dt.Columns[Col_PayeeSnm].DefaultValue = "";

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                      // 仕入先コード
                dt.Columns[Col_SupplierCd].DefaultValue = 0;

                dt.Columns.Add(Col_SupplierNm1, typeof(string));                    // 仕入先名1
                dt.Columns[Col_SupplierNm1].DefaultValue = "";

                dt.Columns.Add(Col_SupplierNm2, typeof(string));                    // 仕入先名2
                dt.Columns[Col_SupplierNm2].DefaultValue = "";

                dt.Columns.Add(Col_SupplierSnm, typeof(string));                    // 仕入先略称
                dt.Columns[Col_SupplierSnm].DefaultValue = "";

                dt.Columns.Add(Col_AddUpDate, typeof(string));                      // 計上年月日
                dt.Columns[Col_AddUpDate].DefaultValue = "";

                dt.Columns.Add(Col_Sort_AddUpDate, typeof(long));                   // ソート用計上年月日
                dt.Columns[Col_Sort_AddUpDate].DefaultValue = 0;

                dt.Columns.Add(Col_AddUpYearMonth, typeof(string));                 // 計上年月
                dt.Columns[Col_AddUpYearMonth].DefaultValue = "";

                dt.Columns.Add(Col_Sort_AddUpYearMonth, typeof(long));              // ソート用計上年月
                dt.Columns[Col_Sort_AddUpYearMonth].DefaultValue = 0;

                dt.Columns.Add(Col_LastTimePayment, typeof(long));                  // 前回支払金額
                dt.Columns[Col_LastTimePayment].DefaultValue = 0;

                dt.Columns.Add(Col_StockTtl2TmBfBlPay, typeof(Int64));              // 仕入2回前残高（支払計）
                dt.Columns[Col_StockTtl2TmBfBlPay].DefaultValue = 0;

                dt.Columns.Add(Col_StockTtl3TmBfBlPay, typeof(Int64));              // 仕入3回前残高（支払計）
                dt.Columns[Col_StockTtl3TmBfBlPay].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimePayNrml, typeof(long));                  // 今回支払金額（通常支払）
                dt.Columns[Col_ThisTimePayNrml].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeTtlBlcPay, typeof(long));                // 今回繰越残高（支払計）
                dt.Columns[Col_ThisTimeTtlBlcPay].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisTimeStock, typeof(long));                 // 相殺後今回仕入金額
                dt.Columns[Col_OfsThisTimeStock].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisStockTax, typeof(long));                  // 相殺後今回仕入消費税
                dt.Columns[Col_OfsThisStockTax].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeStockPrice, typeof(long));               // 今回仕入金額
                dt.Columns[Col_ThisTimeStockPrice].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStckPricRgds, typeof(long));                 // 今回返品金額
                dt.Columns[Col_ThisStckPricRgds].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStckPricDis, typeof(long));                  // 今回値引金額
                dt.Columns[Col_ThisStckPricDis].DefaultValue = 0;

                dt.Columns.Add(Col_StockTotalPayBalance, typeof(long));             // 仕入合計残高（今回分の支払金額）
                dt.Columns[Col_StockTotalPayBalance].DefaultValue = 0;

                dt.Columns.Add(Col_StockTotalPayBalanceFilter, typeof(long));       // 仕入合計残高（今回分の支払金額）(フィルター用)
                dt.Columns[Col_StockTotalPayBalanceFilter].DefaultValue = 0;

                dt.Columns.Add(Col_StockSlipCount, typeof(long));                   // 仕入伝票枚数
                dt.Columns[Col_StockSlipCount].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeFeePayNrml, typeof(Int64));              // 今回手数料額（通常支払）
                dt.Columns[Col_ThisTimeFeePayNrml].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeDisPayNrml, typeof(Int64));              // 今回値引額（通常支払）
                dt.Columns[Col_ThisTimeDisPayNrml].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentMonthName, typeof(string));               // 支払月区分名称
                dt.Columns[Col_PaymentMonthName].DefaultValue = "";

                dt.Columns.Add(Col_PaymentDay, typeof(string));                     // 支払日
                dt.Columns[Col_PaymentDay].DefaultValue = "";

                dt.Columns.Add(Col_ThisTotal, typeof(Int64));                       // 今回合計
                dt.Columns[Col_ThisTotal].DefaultValue = 0;

                // 計算金額(印字用)
                dt.Columns.Add(Col_PaymentBalance, typeof(Int64));                  // 支払残高
                dt.Columns[Col_PaymentBalance].DefaultValue = 0;

                dt.Columns.Add(Col_RetGoodsDiscount, typeof(Int64));                // 返品値引
                dt.Columns[Col_RetGoodsDiscount].DefaultValue = 0;

                dt.Columns.Add(Col_PureCost, typeof(Int64));                        // 純仕入額
                dt.Columns[Col_PureCost].DefaultValue = 0;

                // 金種コード
                dt.Columns.Add(Col_CashPayment, typeof(Int64));                     // 現金
                dt.Columns[Col_CashPayment].DefaultValue = 0;

                dt.Columns.Add(Col_TrfrPayment, typeof(Int64));                     // 振込
                dt.Columns[Col_TrfrPayment].DefaultValue = 0;

                dt.Columns.Add(Col_CheckPayment, typeof(Int64));                    // 小切手
                dt.Columns[Col_CheckPayment].DefaultValue = 0;

                dt.Columns.Add(Col_DraftPayment, typeof(Int64));                    // 手形
                dt.Columns[Col_DraftPayment].DefaultValue = 0;

                dt.Columns.Add(Col_OffsetPayment, typeof(Int64));                   // 相殺
                dt.Columns[Col_OffsetPayment].DefaultValue = 0;

                dt.Columns.Add(Col_FundTransferPayment, typeof(Int64));             // 口座振替
                dt.Columns[Col_FundTransferPayment].DefaultValue = 0;

                dt.Columns.Add(Col_OthsPayment, typeof(Int64));                     // その他
                dt.Columns[Col_OthsPayment].DefaultValue = 0;
            }
		}
		#endregion
		#endregion
	}
}
