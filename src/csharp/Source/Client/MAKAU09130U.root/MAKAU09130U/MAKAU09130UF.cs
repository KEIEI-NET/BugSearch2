using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 残高表示用テーブルスキーマ定義クラス
    /// </summary>
    internal class AccPayBalanceDispayTable
    {
        public AccPayBalanceDispayTable()
        {
        }

        public const string ctTableName = "AccPayBalanceDispayTable";

        /// <summary>計上年月</summary>
        public const string ct_Col_ADDUPYEARMONTHJP = "ADDUPYEARMONTHJP";
        /// <summary>計上年月日</summary>
        public const string ct_Col_ADDUPDATEJP = "ADDUPDATEJP";
        /// <summary>前々々回残高</summary>
        public const string ct_Col_TOTAL3_BEF = "TOTAL3_BEF";
        /// <summary>前々回残高</summary>
        public const string ct_Col_TOTAL2_BEF = "TOTAL2_BEF";
        /// <summary> 前回残高</summary>
        public const string ct_Col_TOTAL1_BEF = "TOTAL1_BEF";
        /// <summary>今回仕入</summary>
        public const string ct_Col_OFSTHISTIMESTOCK = "OFSTHISTIMESTOCK";
        /// <summary>消費税</summary>
        public const string ct_Col_OFSTHISSTOCKTAX = "CONSTAX";
        /// <summary>今回支払</summary>
        public const string ct_Col_THISTIMEPAYM = "THISTIMEPAYM";
        /// <summary>買掛残高</summary>
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
            // 今回仕入
            dt.Columns.Add(ct_Col_OFSTHISTIMESTOCK, typeof(Int64));
            dt.Columns[ct_Col_OFSTHISTIMESTOCK].DefaultValue = 0;
            // 消費税
            dt.Columns.Add(ct_Col_OFSTHISSTOCKTAX, typeof(Int64));
            dt.Columns[ct_Col_OFSTHISSTOCKTAX].DefaultValue = 0;
            // 今回支払
            dt.Columns.Add(ct_Col_THISTIMEPAYM, typeof(Int64));
            dt.Columns[ct_Col_THISTIMEPAYM].DefaultValue = 0;
            // 買掛残高
            dt.Columns.Add(ct_Col_ACCRECBLNCE, typeof(Int64));
            dt.Columns[ct_Col_ACCRECBLNCE].DefaultValue = 0;
        }
    }
}
