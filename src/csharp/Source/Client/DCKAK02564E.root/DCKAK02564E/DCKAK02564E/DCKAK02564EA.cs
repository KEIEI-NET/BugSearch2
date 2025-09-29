using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 支払残高元帳用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 支払残高元帳用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 20081 疋田　勇人</br>
	/// <br>Date       : 2007.10.02</br>
	/// <br></br>
    /// <br>Update Note: 2008/12/10 30414 忍 幸史 Partsman用に変更</br>
	/// </remarks>
	public class DCKAK02564EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string Col_Tbl_PaymentBalance = "Tbl_PaymentBalance";

        /// <summary> 計上拠点コード </summary>
        /// <remarks> 集計の対象となっている拠点コード</remarks>
        public const string Col_AddUpSecCode = "AddUpSecCode";

        /// <summary> 計上拠点名称 </summary>
        public const string Col_AddUpSecName = "AddUpSecName";

        /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
        /// <summary> 計上拠点名称(明細用) </summary>
        public const string Col_AddUpSecName_Detail = "AddUpSecName_Detail";
           --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 支払先コード </summary>
        public const string Col_PayeeCode = "PayeeCode";

        /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
        /// <summary> 支払先名称 </summary>
        public const string Col_PayeeName = "PayeeName";

        /// <summary> 支払先名称2 </summary>
        public const string Col_PayeeName2 = "PayeeName2";
           --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 支払先略称 </summary>
        public const string Col_PayeeSnm = "PayeeSnm";

        /// <summary> 計上年月日 </summary>
        public const string Col_AddUpDate  = "AddUpDate";

        /// <summary> 前回支払金額 </summary>
        public const string Col_LastTimePayment = "LastTimePayment";

        /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
        /// <summary> 今回手数料額(通常支払) </summary>
        public const string Col_ThisTimeFeePayNrml = "ThisTimeFeePayNrml";

        /// <summary> 今回値引額(通常支払) </summary>
        public const string Col_ThisTimeDisPayNrml = "ThisTimeDisPayNrml";
           --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 今回支払金額(通常支払) </summary>
        public const string Col_ThisTimePayNrml = "ThisTimePayNrml";

        /// <summary> 今回繰越残高 </summary>
        public const string Col_ThisTimeTtlBlcPay = "ThisTimeTtlBlcPay";

        /// <summary> 相殺後今回仕入金額 </summary>
        public const string Col_OfsThisTimeStock = "OfsThisTimeStock";

        /// <summary> 相殺後今回仕入消費税 </summary>
        public const string Col_OfsThisStockTax = "OfsThisStockTax";

        /// <summary> 今回仕入金額 </summary>
        public const string Col_ThisTimeStockPrice = "ThisTimeStockPrice";

        /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
        /// <summary> 今回仕入消費税 </summary>
        public const string Col_ThisStcPrcTax = "ThisStcPrcTax";

        /// <summary> 今回返品金額 </summary>
        public const string Col_ThisStckPricRgds = "ThisStckPricRgds";

        /// <summary> 今回返品消費税 </summary>
        public const string Col_ThisStcPrcTaxRgds = "ThisStcPrcTaxRgds";

        /// <summary> 今回値引金額 </summary>
        public const string Col_ThisStckPricDis = "ThisStckPricDis";

        /// <summary> 今回値引消費税 </summary>
        public const string Col_ThisStcPrcTaxDis = "ThisStcPrcTaxDis";

        /// <summary> 今回受取金額 </summary>
        public const string Col_ThisRecvOffset = "ThisRecvOffset";

        /// <summary> 今回受取相殺消費税 </summary>
        public const string Col_ThisRecvOffsetTax = "ThisRecvOffsetTax";

        /// <summary> 消費税調整額 </summary>
        public const string Col_TaxAdjust = "TaxAdjust";

        /// <summary> 残高調整額 </summary>
        public const string Col_BalanceAdjust = "BalanceAdjust";
           --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 仕入合計残高（今回分の支払金額）</summary>
        public const string Col_StockTotalPayBalance = "StockTotalPayBalance";

        /// <summary> 仕入伝票枚数 </summary>
        public const string Col_StockSlipCount = "StockSlipCount";

        /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
        /// <summary> 支払予定日 </summary>
        public const string Col_PaymentSchedule = "PaymentSchedule";
           --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 支払条件 </summary>
        public const string Col_PaymentCond = "PaymentCond";

        /// <summary> 返品・値引合計 </summary>
        public const string Col_RgdsDisT = "RgdsDisT";

        /// <summary> 税込仕入額 </summary>
        public const string Col_ThisNetStckTax = "ThisNetStckTax";

        /// <summary> 締日 </summary>
        public const string Col_PaymentTotalDay = "PaymentTotalDay";

        /// <summary> 支払月 </summary>
        public const string Col_PaymentMonthName = "PaymentMonthName";

        /// <summary> 支払日 </summary>
        public const string Col_PaymentDay = "PaymentDay";


        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 支払残高元帳用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払残高元帳用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.02</br>
		/// </remarks>
		public DCKAK02564EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ CreateDataTable(ref DataSet ds)
		/// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
		/// <br>Programmer : 20081 疋田　勇人</br>
		/// <br>Date       : 2007.10.02</br>
		/// </remarks>
        static public void CreateDataTablePaymentBalanceMain(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_PaymentBalance))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_PaymentBalance].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_PaymentBalance);

                DataTable dt = ds.Tables[Col_Tbl_PaymentBalance];

                dt.Columns.Add(Col_AddUpSecCode, typeof(string));		            // 計上拠点コード
                dt.Columns[Col_AddUpSecCode].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName, typeof(string));	            	// 計上拠点名称
                dt.Columns[Col_AddUpSecName].DefaultValue = "";

                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_AddUpSecName_Detail, typeof(string));		    // 計上拠点名称(明細)
                dt.Columns[Col_AddUpSecName_Detail].DefaultValue = "";
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_PayeeCode, typeof(int));  			            // 支払先コード
                dt.Columns[Col_PayeeCode].DefaultValue = 0;

                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_PayeeName, typeof(string));		                // 支払先名称
                dt.Columns[Col_PayeeName].DefaultValue = "";

                dt.Columns.Add(Col_PayeeName2, typeof(string));		                // 支払先名称2
                dt.Columns[Col_PayeeName2].DefaultValue = "";
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_PayeeSnm, typeof(string));		                // 支払先略称
                dt.Columns[Col_PayeeSnm].DefaultValue = "";

                dt.Columns.Add(Col_AddUpDate, typeof(string));		                // 計上年月日
                dt.Columns[Col_AddUpDate].DefaultValue = "";

                dt.Columns.Add(Col_LastTimePayment, typeof(long));		            // 前回支払金額
                dt.Columns[Col_LastTimePayment].DefaultValue = 0;

                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_ThisTimeFeePayNrml, typeof(long));		        // 今回手数料額(通常支払)
                dt.Columns[Col_ThisTimeFeePayNrml].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeDisPayNrml, typeof(long));		        // 今回値引額(通常支払)
                dt.Columns[Col_ThisTimeDisPayNrml].DefaultValue = 0;
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_ThisTimePayNrml, typeof(long));		            // 今回支払金額(通常支払)
                dt.Columns[Col_ThisTimePayNrml].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeTtlBlcPay, typeof(long));		        // 今回繰越残高
                dt.Columns[Col_ThisTimeTtlBlcPay].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisTimeStock, typeof(long));		            // 相殺後今回仕入金額
                dt.Columns[Col_OfsThisTimeStock].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisStockTax, typeof(long));		            // 相殺後今回消費税額
                dt.Columns[Col_OfsThisStockTax].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeStockPrice, typeof(long));		        // 今回仕入金額
                dt.Columns[Col_ThisTimeStockPrice].DefaultValue = 0;

                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_ThisStcPrcTax, typeof(long));		            // 今回仕入消費税
                dt.Columns[Col_ThisStcPrcTax].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStckPricRgds, typeof(long));		            // 今回返品金額
                dt.Columns[Col_ThisStckPricRgds].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStcPrcTaxRgds, typeof(long));		        // 今回返品消費税
                dt.Columns[Col_ThisStcPrcTaxRgds].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStckPricDis, typeof(long));		            // 今回値引金額
                dt.Columns[Col_ThisStckPricDis].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStcPrcTaxDis, typeof(long));		            // 今回値引消費税
                dt.Columns[Col_ThisStcPrcTaxDis].DefaultValue = 0;

                dt.Columns.Add(Col_ThisRecvOffset, typeof(long));		            // 今回受取金額
                dt.Columns[Col_ThisRecvOffset].DefaultValue = 0;

                dt.Columns.Add(Col_ThisRecvOffsetTax, typeof(long));		        // 今回受取相殺消費税
                dt.Columns[Col_ThisRecvOffsetTax].DefaultValue = 0;

                dt.Columns.Add(Col_TaxAdjust, typeof(long));		                // 消費税調整額
                dt.Columns[Col_TaxAdjust].DefaultValue = 0;

                dt.Columns.Add(Col_BalanceAdjust, typeof(long));		            // 残高調整額
                dt.Columns[Col_BalanceAdjust].DefaultValue = 0;
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_StockTotalPayBalance, typeof(long));		        // 仕入合計残高（今回分の支払金額）
                dt.Columns[Col_StockTotalPayBalance].DefaultValue = 0;

                dt.Columns.Add(Col_StockSlipCount, typeof(int));		            // 仕入伝票枚数
                dt.Columns[Col_StockSlipCount].DefaultValue = 0;

                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_PaymentSchedule, typeof(string));		        // 支払予定日
                dt.Columns[Col_PaymentSchedule].DefaultValue = "";
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_PaymentCond, typeof(string));		            // 支払条件
                dt.Columns[Col_PaymentCond].DefaultValue = "";

                dt.Columns.Add(Col_RgdsDisT, typeof(long));		                    // 返品・値引合計
                dt.Columns[Col_RgdsDisT].DefaultValue = 0;

                dt.Columns.Add(Col_ThisNetStckTax, typeof(long));		            // 税込仕入額
                dt.Columns[Col_ThisNetStckTax].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentTotalDay, typeof(int));  			        // 締日
                dt.Columns[Col_PaymentTotalDay].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentMonthName, typeof(string));  			    // 支払月区分名称
                dt.Columns[Col_PaymentMonthName].DefaultValue = "";

                dt.Columns.Add(Col_PaymentDay, typeof(int));  			            // 支払日
                dt.Columns[Col_PaymentDay].DefaultValue = 0;
            }

		}
		#endregion
		#endregion
	}
}
