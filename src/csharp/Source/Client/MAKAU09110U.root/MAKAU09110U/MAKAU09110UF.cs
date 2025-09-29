using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 結合登録用のテーブルスキーマ定義クラス
    /// </summary>
    internal class BalanceDisplayTable
    {
        public BalanceDisplayTable()
        {
        }

        public const string ctTableName = "BalanceDisplayTable";

        /// <summary> 計上年月 </summary>
        public const string ct_Col_ADDUPYEARMONTHJP = "ADDUPYEARMONTHJP";
        /// <summary> 計上年月日 </summary>
        public const string ct_Col_ADDUPDATEJP = "ADDUPDATEJP";
        /// <summary> 前々々回残高 </summary>
        public const string ct_Col_TOTAL3_BEF = "TOTAL3_BEF";
        /// <summary> 前々回残高 </summary>
        public const string ct_Col_TOTAL2_BEF = "TOTAL2_BEF";
        /// <summary> 前回残高 </summary>
        public const string ct_Col_TOTAL1_BEF = "TOTAL1_BEF";
        /// <summary> 今回売上 </summary>
        public const string ct_Col_THISTIMESALES = "THISTIMESALES";
        /// <summary> 消費税 </summary>
        public const string ct_Col_CONSTAX = "CONSTAX";
        /// <summary> 今回支払 </summary>
        public const string ct_Col_THISTIMEPAYM = "THISTIMEPAYM";
        /// <summary> 支払消費税 </summary>
        public const string ct_Col_PAYMCONSTAX = "PAYMCONSTAX";
        /// <summary> 今回入金 </summary>
        public const string ct_Col_THISTIMEDEPO = "THISTIMEDEPO";
        /// <summary> 売掛残高 </summary>
        public const string ct_Col_ACCRECBLNCE = "ACCRECBLNCE";

        static public void CreateTable(ref DataTable dt)
        {
            if (dt == null)
            {
                dt = new DataTable(ctTableName);
            }
            dt.Rows.Clear();

            // 計上年月
            dt.Columns.Add(ct_Col_ADDUPYEARMONTHJP, typeof(Int64));
            dt.Columns[ct_Col_ADDUPYEARMONTHJP].DefaultValue = 0;
            // 計上年月日
            dt.Columns.Add(ct_Col_ADDUPDATEJP, typeof(Int64));
            dt.Columns[ct_Col_ADDUPDATEJP].DefaultValue = 0;
            // 前々々回残高
            dt.Columns.Add(ct_Col_TOTAL3_BEF, typeof(Int64));
            dt.Columns[ct_Col_TOTAL3_BEF].DefaultValue = 0;
            // 前々回残高
            dt.Columns.Add(ct_Col_TOTAL2_BEF, typeof(Int64));
            dt.Columns[ct_Col_TOTAL2_BEF].DefaultValue = 0;
            // 前回残高
            dt.Columns.Add(ct_Col_TOTAL1_BEF, typeof(Int64));
            dt.Columns[ct_Col_TOTAL1_BEF].DefaultValue = 0;
            // 今回売上
            dt.Columns.Add(ct_Col_THISTIMESALES, typeof(Int64));
            dt.Columns[ct_Col_THISTIMESALES].DefaultValue = 0;
            // 消費税
            dt.Columns.Add(ct_Col_CONSTAX, typeof(Int64));
            dt.Columns[ct_Col_CONSTAX].DefaultValue = 0;
            // 今回支払
            dt.Columns.Add(ct_Col_THISTIMEPAYM, typeof(Int64));
            dt.Columns[ct_Col_THISTIMEPAYM].DefaultValue = 0;
            // 支払消費税
            dt.Columns.Add(ct_Col_PAYMCONSTAX, typeof(Int64));
            dt.Columns[ct_Col_PAYMCONSTAX].DefaultValue = 0;
            // 今回入金
            dt.Columns.Add(ct_Col_THISTIMEDEPO, typeof(Int64));
            dt.Columns[ct_Col_THISTIMEDEPO].DefaultValue = 0;
            // 売掛残高
            dt.Columns.Add(ct_Col_ACCRECBLNCE, typeof(Int64));
            dt.Columns[ct_Col_ACCRECBLNCE].DefaultValue = 0;
        }
    }
}
