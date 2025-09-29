using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 売掛残高元帳用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売掛残高元帳抽出結果ワーク</br>
	/// <br>Programmer : 矢田 敬吾</br>
	/// <br>Date       : 2007.11.19</br>
    /// <br>UpdateNote : 2008/12/11 30414 忍 幸史 Partsman用に変更</br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class DCKAU02604EA
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

        /// <summary> 請求先コード(請求先親コード) </summary>
        public const string Col_ClaimCode = "ClaimCode";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 請求先名称 </summary>
        public const string Col_ClaimName = "ClaimName";

        /// <summary> 請求先名称2 </summary>
        public const string Col_ClaimName2 = "ClaimName2";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 請求先略称 </summary>
        public const string Col_ClaimSnm = "ClaimSnm";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 計上年月日(請求締を行った日)(相手先基準) </summary>
        public const string Col_AddUpDate  = "AddUpDate";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 計上年月</summary>
        public const string Col_AddUpYearMonth = "AddUpYearMonth";

        /// <summary> 前回売掛金額 </summary>
        public const string Col_LastTimeAccRec = "LastTimeAccRec";

        /// <summary> 今回入金金額（通常入金） </summary>
        public const string Col_ThisTimeDmdNrml = "ThisTimeDmdNrml";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 今回手数料額（通常入金） </summary>
        public const string Col_ThisTimeFeeDmdNrml = "ThisTimeFeeDmdNrml";

        /// <summary> 今回値引額（通常入金） </summary>
        public const string Col_ThisTimeDisDmdNrml = "ThisTimeDisDmdNrml";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 今回繰越残高 </summary>
        public const string Col_ThisTimeTtlBlcAcc = "ThisTimeTtlBlcAcc";

        /// <summary> 相殺後今回売上金額 </summary>
        public const string Col_OfsThisTimeSales = "OfsThisTimeSales";

        /// <summary> 相殺後今回売上消費税 </summary>
        public const string Col_OfsThisSalesTax = "OfsThisSalesTax";

        /// <summary> 今回売上金額 </summary>
        public const string Col_ThisTimeSales = "ThisTimeSales";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 今回売上消費税 </summary>
        public const string Col_ThisSalesTax = "ThisSalesTax";

        /// <summary> 今回売上返品金額 </summary>
        public const string Col_ThisSalesPricRgds = "ThisSalesPricRgds";

        /// <summary> 今回売上返品消費税 </summary>
        public const string Col_ThisSalesPrcTaxRgds = "ThisSalesPrcTaxRgds";

        /// <summary> 今回売上値引金額 </summary>
        public const string Col_ThisSalesPricDis = "ThisSalesPricDis";

        /// <summary> 今回売上値引消費税 </summary>
        public const string Col_ThisSalesPrcTaxDis = "ThisSalesPrcTaxDis";

        /// <summary> 今回支払相殺金額 </summary>
        public const string Col_ThisPayOffset = "ThisPayOffset";

        /// <summary> 今回支払相殺消費税 </summary>
        public const string Col_ThisPayOffsetTax = "ThisPayOffsetTax";

        /// <summary> 消費税調整額 </summary>
        public const string Col_TaxAdjust = "TaxAdjust";

        /// <summary> 残高調整額 </summary>
        public const string Col_BalanceAdjust = "BalanceAdjust";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 計算後当月売掛金額(今月分の売掛金額)</summary>
        public const string Col_AfCalTMonthAccRec = "AfCalTMonthAccRec";

        /// <summary> 売上伝票枚数 </summary>
        public const string Col_SalesSlipCount = "SalesSlipCount";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 未決済金額(自振) </summary>
        public const string Col_NonStmntAppearance = "NonStmntAppearance";

        /// <summary> 未決済金額(廻し) </summary>
        public const string Col_NonStmntlsdone = "NonStmntlsdone";

        /// <summary> 決済金額(自振) </summary>
        public const string Col_StmntAppearance = "StmntAppearance";

        /// <summary> 決済金額(廻し) </summary>
        public const string Col_Stmntlsdone = "Stmntlsdone";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 回収条件 </summary>
        public const string Col_CollectCond = "CollectCond";

        /// <summary> 請求締日 </summary>
        public const string Col_TotalDay = "TotalDay";

        /// <summary> 回収月区分名称 </summary>
        public const string Col_CollectMoneyName = "CollectMoneyName";

        /// <summary> 回収日 </summary>
        public const string Col_CollectMoneyDay = "CollectMoneyDay";

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        /// <summary> 集金担当従業員コード </summary>
        public const string Col_BillCollecterCd = "BillCollecterCd";
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

        /// <summary> 集金担当従業員名称 </summary>
        public const string Col_BillCollecterNm = "BillCollecterNm";

        /// <summary> 返品・値引合計 </summary>
        public const string Col_RgdsDisT = "RgdsDisT";

        /// <summary> 税込売上額 </summary>
        public const string Col_TimeSalesTax = "TimeSalesTax";

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 請求残高元帳用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 請求残高元帳用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public DCKAU02604EA()
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

                dt.Columns.Add(Col_ClaimCode, typeof(Int32));  			            // 請求先コード
                dt.Columns[Col_ClaimCode].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_ClaimName, typeof(string));		                // 請求先名称
                dt.Columns[Col_ClaimName].DefaultValue = "";

                dt.Columns.Add(Col_ClaimName2, typeof(string));		                // 請求先名称2
                dt.Columns[Col_ClaimName2].DefaultValue = "";
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_ClaimSnm, typeof(string));		                // 請求先略称
                dt.Columns[Col_ClaimSnm].DefaultValue = "";

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_AddUpDate, typeof(DateTime));		            // 計上年月日
                dt.Columns[Col_AddUpDate].DefaultValue = DateTime.MinValue;
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_AddUpYearMonth, typeof(DateTime));		        // 計上年月
                dt.Columns[Col_AddUpYearMonth].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_LastTimeAccRec, typeof(Int64));		            // 前回売掛金額
                dt.Columns[Col_LastTimeAccRec].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeDmdNrml, typeof(Int64));		            // 今回入金金額（通常入金）
                dt.Columns[Col_ThisTimeDmdNrml].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_ThisTimeFeeDmdNrml, typeof(Int64));		        // 今回手数料額（通常入金）
                dt.Columns[Col_ThisTimeFeeDmdNrml].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeDisDmdNrml, typeof(Int64));		        // 今回値引額（通常入金）
                dt.Columns[Col_ThisTimeDisDmdNrml].DefaultValue = 0;
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_ThisTimeTtlBlcAcc, typeof(Int64));		        // 今回繰越残高
                dt.Columns[Col_ThisTimeTtlBlcAcc].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisTimeSales, typeof(Int64));		        // 相殺後今回売上金額
                dt.Columns[Col_OfsThisTimeSales].DefaultValue = 0;

                dt.Columns.Add(Col_OfsThisSalesTax, typeof(Int64));		            // 相殺後今回売上消費税
                dt.Columns[Col_OfsThisSalesTax].DefaultValue = 0;

                dt.Columns.Add(Col_ThisTimeSales, typeof(Int64));		            // 今回売上金額
                dt.Columns[Col_ThisTimeSales].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_ThisSalesTax, typeof(Int64));		            // 今回売上消費税
                dt.Columns[Col_ThisSalesTax].DefaultValue = 0;

                dt.Columns.Add(Col_ThisSalesPricRgds, typeof(Int64));		        // 今回売上返品金額
                dt.Columns[Col_ThisSalesPricRgds].DefaultValue = 0;

                dt.Columns.Add(Col_ThisSalesPrcTaxRgds, typeof(Int64));		        // 今回売上返品消費税
                dt.Columns[Col_ThisSalesPrcTaxRgds].DefaultValue = 0;

                dt.Columns.Add(Col_ThisSalesPricDis, typeof(Int64));		        // 今回売上値引金額
                dt.Columns[Col_ThisSalesPricDis].DefaultValue = 0;

                dt.Columns.Add(Col_ThisSalesPrcTaxDis, typeof(Int64));		        // 今回売上値引消費税
                dt.Columns[Col_ThisSalesPrcTaxDis].DefaultValue = 0;

                dt.Columns.Add(Col_ThisPayOffset, typeof(Int64));		            // 今回支払相殺金額
                dt.Columns[Col_ThisPayOffset].DefaultValue = 0;

                dt.Columns.Add(Col_ThisPayOffsetTax, typeof(Int64));		        // 今回支払相殺消費税
                dt.Columns[Col_ThisPayOffsetTax].DefaultValue = 0;

                dt.Columns.Add(Col_TaxAdjust, typeof(Int64));		                // 消費税調整額
                dt.Columns[Col_TaxAdjust].DefaultValue = 0;

                dt.Columns.Add(Col_BalanceAdjust, typeof(Int64));		            // 残高調整額
                dt.Columns[Col_BalanceAdjust].DefaultValue = 0;
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_AfCalTMonthAccRec, typeof(Int64));		        // 計算後当月売掛金額
                dt.Columns[Col_AfCalTMonthAccRec].DefaultValue = 0;

                dt.Columns.Add(Col_SalesSlipCount, typeof(Int32));		            // 売上伝票枚数
                dt.Columns[Col_SalesSlipCount].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_NonStmntAppearance, typeof(Int64));		        // 未決済金額(自振)
                dt.Columns[Col_NonStmntAppearance].DefaultValue = 0;

                dt.Columns.Add(Col_NonStmntlsdone, typeof(Int64));		            // 未決済金額(廻し)
                dt.Columns[Col_NonStmntlsdone].DefaultValue = 0;

                dt.Columns.Add(Col_StmntAppearance, typeof(Int64));		           // 決済金額(自振)
                dt.Columns[Col_StmntAppearance].DefaultValue = 0;

                dt.Columns.Add(Col_Stmntlsdone, typeof(Int64));		               // 決済金額(廻し)
                dt.Columns[Col_Stmntlsdone].DefaultValue = 0;
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_CollectCond, typeof(string));		           // 回収条件
                dt.Columns[Col_CollectCond].DefaultValue = "";

                dt.Columns.Add(Col_TotalDay, typeof(Int32));  			           // 請求締日
                dt.Columns[Col_TotalDay].DefaultValue = 0;

                dt.Columns.Add(Col_CollectMoneyName, typeof(string));  			   // 回収月区分名称
                dt.Columns[Col_CollectMoneyName].DefaultValue = "";

                dt.Columns.Add(Col_CollectMoneyDay, typeof(Int32));  			   // 回収日
                dt.Columns[Col_CollectMoneyDay].DefaultValue = 0;

                /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
                dt.Columns.Add(Col_BillCollecterCd, typeof(string));  			   // 集金担当従業員コード
                dt.Columns[Col_BillCollecterCd].DefaultValue = "";
                     --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/

                dt.Columns.Add(Col_BillCollecterNm, typeof(string));  			   // 集金担当従業員名称
                dt.Columns[Col_BillCollecterNm].DefaultValue = "";

                dt.Columns.Add(Col_RgdsDisT, typeof(Int64));		               // 返品・値引合計
                dt.Columns[Col_RgdsDisT].DefaultValue = 0;

                dt.Columns.Add(Col_TimeSalesTax, typeof(Int64));		           // 税込売上額
                dt.Columns[Col_TimeSalesTax].DefaultValue = 0;
            }

		}
		#endregion
		#endregion
	}
}
