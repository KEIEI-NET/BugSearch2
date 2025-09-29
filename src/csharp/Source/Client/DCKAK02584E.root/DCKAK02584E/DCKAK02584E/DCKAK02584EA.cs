using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 買掛残高元帳用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 買掛残高元帳用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 矢田 敬吾</br>
	/// <br>Date       : 2007.11.19</br>
    /// <br>Update Note: 2008/12/11 30414 忍 幸史 Partsman用に変更</br>
	/// </remarks>
	public class DCKAK02584EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string Col_Tbl_DmdBalance = "Tbl_DmdBalance";

        /// <summary> 計上拠点コード </summary>
        /// <remarks> 集計の対象となっている拠点コード</remarks>
        public const string Col_AddUpSecCode = "AddUpSecCode";

        /// <summary> 計上拠点名称 </summary>
        public const string Col_AddUpSecName = "AddUpSecName";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 計上拠点名称(明細用) </summary>
        public const string Col_AddUpSecName_Detail = "AddUpSecName_Detail";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 支払先コード </summary>
        public const string Col_PayeeCode = "PayeeCode";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 支払先名称 </summary>
        public const string Col_PayeeName = "PayeeName";

        /// <summary> 支払先名称2 </summary>
        public const string Col_PayeeName2 = "PayeeName2";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 支払先略称 </summary>
        public const string Col_PayeeSnm = "PayeeSnm";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 計上年月日(請求締を行った日)(相手先基準) </summary>
        public const string Col_AddUpDate  = "AddUpDate";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 計上年月日(YYYY/MM)</summary>
        public const string Col_AddUpYearMonth = "AddUpYearMonth";

        /// <summary> 前回買掛金額 </summary>
        public const string Col_LastTimeAccPay = "LastTimeAccPay";

        /// <summary> 今回支払金額 (通常支払)</summary>
        public const string Col_ThisTimePayNrml = "ThisTimePayNrml";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 今回手数料額 (通常支払)</summary>
        public const string Col_ThisTimeFeePayNrml = "ThisTimeFeePayNrml";

        /// <summary> 今回値引額（通常入金） </summary>
        public const string Col_ThisTimeDisPayNrml = "ThisTimeDisPayNrml";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 今回繰越残高 (買掛計)</summary>
        public const string Col_ThisTimeTtlBlcAcPay = "ThisTimeTtlBlcAcPay";

        /// <summary> 相殺後今回仕入金額 </summary>
        public const string Col_OfsThisTimeStock = "OfsThisTimeStock";

        /// <summary> 相殺後今回仕入消費税 </summary>
        public const string Col_OfsThisStockTax = "OfsThisStockTax";

        /// <summary> 今回仕入金額 </summary>
        public const string Col_ThisTimeStockPrice = "ThisTimeStockPrice";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 仕入合計残高(買掛計)</summary>
        public const string Col_StckTtlAccPayBalance = "StckTtlAccPayBalance";

        /// <summary> 仕入伝票枚数 </summary>
        public const string Col_StockSlipCount = "StockSlipCount";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 未決済金額(自振) </summary>
        public const string Col_NonStmntAppearance = "NonStmntAppearance";

        /// <summary> 未決済金額(廻し) </summary>
        public const string Col_NonStmntIsdone = "NonStmntIsdone";

        /// <summary> 決済金額(自振) </summary>
        public const string Col_StmntAppearance = "StmntAppearance";

        /// <summary> 決済金額(廻し) </summary>
        public const string Col_StmntIsdone = "StmntIsdone";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 支払条件 </summary>
        public const string Col_PaymentCond = "PaymentCond";
  
        /// <summary> 支払締日 </summary>
        public const string Col_PaymentTotalDay = "PaymentTotalDay";

        /// <summary> 支払月区分名称 </summary>
        public const string Col_PaymentMonthName = "PaymentMonthName";

        /// <summary> 支払日 </summary>
        public const string Col_PaymentDay = "PaymentDay";

        /// <summary> 返品・値引合計 </summary>
        public const string Col_RgdsDisT = "RgdsDisT";

        /// <summary> 税込売上額 </summary>
        public const string Col_ThisStockTax = "ThisStockTax";

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 買掛残高元帳用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 買掛残高元帳用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 矢田 敬吾</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		public DCKAK02584EA()
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
		/// <br>Programmer : 矢田 敬吾</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
        static public void CreateDataTableDmdBalanceMain(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_DmdBalance))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_DmdBalance].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_DmdBalance);

                DataTable dt = ds.Tables[Col_Tbl_DmdBalance];

                dt.Columns.Add(Col_AddUpSecCode, typeof(string));		            // 計上拠点コード
                dt.Columns[Col_AddUpSecCode].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName, typeof(string));	            	// 計上拠点名称
                dt.Columns[Col_AddUpSecName].DefaultValue = "";

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_AddUpSecName_Detail, typeof(string));		    // 計上拠点名称(明細)
                dt.Columns[Col_AddUpSecName_Detail].DefaultValue = "";
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_PayeeCode, typeof(Int32));  			            // 支払先コード
                dt.Columns[Col_PayeeCode].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_PayeeName, typeof(string));		                // 支払先名称
                dt.Columns[Col_PayeeName].DefaultValue = "";

                dt.Columns.Add(Col_PayeeName2, typeof(string));		                // 支払先名称2
                dt.Columns[Col_PayeeName2].DefaultValue = "";
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_PayeeSnm, typeof(string));		                // 支払先略称
                dt.Columns[Col_PayeeSnm].DefaultValue = "";

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_AddUpDate, typeof(DateTime));		            // 計上年月日
                dt.Columns[Col_AddUpDate].DefaultValue = DateTime.MinValue;
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_AddUpYearMonth, typeof(DateTime));		        // 計上年月
                dt.Columns[Col_AddUpYearMonth].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_LastTimeAccPay, typeof(Int64));		            // 前回買掛金額
                dt.Columns[Col_LastTimeAccPay].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimePayNrml, typeof(Int64));		            // 今回支払金額（通常入金）
                dt.Columns[Col_ThisTimePayNrml].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_ThisTimeFeePayNrml, typeof(Int64));		        // 今回手数料額（通常入金）
                dt.Columns[Col_ThisTimeFeePayNrml].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeDisPayNrml, typeof(Int64));		        // 今回値引額（通常入金）
                dt.Columns[Col_ThisTimeDisPayNrml].DefaultValue = 0;
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_ThisTimeTtlBlcAcPay, typeof(Int64));		        // 今回繰越残高(買掛計)
                dt.Columns[Col_ThisTimeTtlBlcAcPay].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisTimeStock, typeof(Int64));		        // 相殺後今回仕入金額
                dt.Columns[Col_OfsThisTimeStock].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisStockTax, typeof(Int64));		            // 相殺後今回仕入消費税
                dt.Columns[Col_OfsThisStockTax].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeStockPrice, typeof(Int64));		       // 今回仕入金額
                dt.Columns[Col_ThisTimeStockPrice].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_ThisStcPrcTax, typeof(Int64));		           // 今回仕入消費税
                dt.Columns[Col_ThisStcPrcTax].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStckPricRgds, typeof(Int64));		       // 今回返品金額
                dt.Columns[Col_ThisStckPricRgds].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStcPrcTaxRgds, typeof(Int64));		       // 今回返品消費税
                dt.Columns[Col_ThisStcPrcTaxRgds].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStckPricDis, typeof(Int64));		           // 今回値引金額
                dt.Columns[Col_ThisStckPricDis].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStcPrcTaxDis, typeof(Int64));		       // 今回値引消費税
                dt.Columns[Col_ThisStcPrcTaxDis].DefaultValue = 0;

                dt.Columns.Add(Col_ThisRecvOffset, typeof(Int64));		           // 今回受取金額
                dt.Columns[Col_ThisRecvOffset].DefaultValue = 0;

                dt.Columns.Add(Col_ThisRecvOffsetTax, typeof(Int64));		       // 今回受取相殺消費税
                dt.Columns[Col_ThisRecvOffsetTax].DefaultValue = 0;
   
                dt.Columns.Add(Col_TaxAdjust, typeof(Int64));		               // 消費税調整額
                dt.Columns[Col_TaxAdjust].DefaultValue = 0;

                dt.Columns.Add(Col_BalanceAdjust, typeof(Int64));		           // 残高調整額
                dt.Columns[Col_BalanceAdjust].DefaultValue = 0;
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_StckTtlAccPayBalance, typeof(Int64));		   // 仕入合計残高(買掛)
                dt.Columns[Col_StckTtlAccPayBalance].DefaultValue = 0;

                dt.Columns.Add(Col_StockSlipCount, typeof(Int32));		          // 仕入伝票枚数
                dt.Columns[Col_StockSlipCount].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_NonStmntAppearance, typeof(Int64));		    　// 未決済金額(自振)
                dt.Columns[Col_NonStmntAppearance].DefaultValue = 0;

                dt.Columns.Add(Col_NonStmntIsdone, typeof(Int64));		          // 未決済金額(廻し)
                dt.Columns[Col_NonStmntIsdone].DefaultValue = 0;

                dt.Columns.Add(Col_StmntAppearance, typeof(Int64));		          // 決済金額(自振)
                dt.Columns[Col_StmntAppearance].DefaultValue = 0;

                dt.Columns.Add(Col_StmntIsdone, typeof(Int64));		             // 決済金額(廻し)
                dt.Columns[Col_StmntIsdone].DefaultValue = 0;
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_PaymentCond, typeof(string));		        // 支払条件
                dt.Columns[Col_PaymentCond].DefaultValue = "";

                dt.Columns.Add(Col_PaymentTotalDay, typeof(Int32));  			 // 支払締日
                dt.Columns[Col_PaymentTotalDay].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentMonthName, typeof(string));  			 // 支払月区分名称
                dt.Columns[Col_PaymentMonthName].DefaultValue = "";

                dt.Columns.Add(Col_PaymentDay, typeof(Int32));  			     // 支払日
                dt.Columns[Col_PaymentDay].DefaultValue = 0;

                dt.Columns.Add(Col_RgdsDisT, typeof(Int64));		             // 返品・値引合計
                dt.Columns[Col_RgdsDisT].DefaultValue = 0;

                dt.Columns.Add(Col_ThisStockTax, typeof(Int64));		         // 税込売上額
                dt.Columns[Col_ThisStockTax].DefaultValue = 0;

            }

		}
		#endregion
		#endregion
	}
}
