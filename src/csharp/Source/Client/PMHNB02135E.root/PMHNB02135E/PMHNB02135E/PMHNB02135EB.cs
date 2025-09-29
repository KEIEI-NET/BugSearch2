using System;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 得意先別過年度統計表 帳票印字用テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別過年度統計表の帳票印字用データを保持。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02135EB
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_CustFinancialRsltListForPrint = "CustFinancialRsltPrintListForPrint";
        // 拠点コード
        public const string ct_Col_SectionCode = "SectionCode";
        // 拠点名称
        public const string ct_Col_SectionName = "SectionName";
        // 得意先コード
        public const string ct_Col_CustomerCode = "CustomerCode";
        // 得意先名称
        public const string ct_Col_CustomerName = "CustomerName";
        // 売上金額1
        public const string ct_Col_SalesMoney1 = "SalesMoney1";
        // 売上金額2
        public const string ct_Col_SalesMoney2 = "SalesMoney2";
        // 売上金額3
        public const string ct_Col_SalesMoney3 = "SalesMoney3";
        // 売上金額4
        public const string ct_Col_SalesMoney4 = "SalesMoney4";
        // 売上金額5
        public const string ct_Col_SalesMoney5 = "SalesMoney5";
        // 売上金額6
        public const string ct_Col_SalesMoney6 = "SalesMoney6";
        // 売上金額7
        public const string ct_Col_SalesMoney7 = "SalesMoney7";
        // 売上金額8
        public const string ct_Col_SalesMoney8 = "SalesMoney8";
        // 粗利金額1
        public const string ct_Col_GrossProfit1 = "GrossProfit1";
        // 粗利金額2
        public const string ct_Col_GrossProfit2 = "GrossProfit2";
        // 粗利金額3
        public const string ct_Col_GrossProfit3 = "GrossProfit3";
        // 粗利金額4
        public const string ct_Col_GrossProfit4 = "GrossProfit4";
        // 粗利金額5
        public const string ct_Col_GrossProfit5 = "GrossProfit5";
        // 粗利金額6
        public const string ct_Col_GrossProfit6 = "GrossProfit6";
        // 粗利金額7
        public const string ct_Col_GrossProfit7 = "GrossProfit7";
        // 粗利金額8
        public const string ct_Col_GrossProfit8 = "GrossProfit8";

        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMHNB02135EB()
        {
        }
        
        #endregion

        #region ■ publicメソッド
        static public void CreateDataTable(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定
                dt = new DataTable(ct_Tbl_CustFinancialRsltListForPrint);


                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionName, typeof(string));
                dt.Columns[ct_Col_SectionName].DefaultValue = string.Empty;

                // 得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerName, typeof(string));
                dt.Columns[ct_Col_CustomerName].DefaultValue = string.Empty;

                // 売上金額1
                dt.Columns.Add(ct_Col_SalesMoney1, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney1].DefaultValue = 0;

                // 売上金額2
                dt.Columns.Add(ct_Col_SalesMoney2, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney2].DefaultValue = 0;

                // 売上金額3
                dt.Columns.Add(ct_Col_SalesMoney3, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney3].DefaultValue = 0;

                // 売上金額4
                dt.Columns.Add(ct_Col_SalesMoney4, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney4].DefaultValue = 0;

                // 売上金額5
                dt.Columns.Add(ct_Col_SalesMoney5, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney5].DefaultValue = 0;

                // 売上金額6
                dt.Columns.Add(ct_Col_SalesMoney6, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney6].DefaultValue = 0;

                // 売上金額7
                dt.Columns.Add(ct_Col_SalesMoney7, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney7].DefaultValue = 0;

                // 売上金額8
                dt.Columns.Add(ct_Col_SalesMoney8, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney8].DefaultValue = 0;

                // 粗利金額1
                dt.Columns.Add(ct_Col_GrossProfit1, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit1].DefaultValue = 0;

                // 粗利金額2
                dt.Columns.Add(ct_Col_GrossProfit2, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit2].DefaultValue = 0;

                // 粗利金額3
                dt.Columns.Add(ct_Col_GrossProfit3, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit3].DefaultValue = 0;

                // 粗利金額4
                dt.Columns.Add(ct_Col_GrossProfit4, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit4].DefaultValue = 0;

                // 粗利金額5
                dt.Columns.Add(ct_Col_GrossProfit5, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit5].DefaultValue = 0;

                // 粗利金額6
                dt.Columns.Add(ct_Col_GrossProfit6, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit6].DefaultValue = 0;

                // 粗利金額7
                dt.Columns.Add(ct_Col_GrossProfit7, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit7].DefaultValue = 0;

                // 粗利金額8
                dt.Columns.Add(ct_Col_GrossProfit8, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit8].DefaultValue = 0;
            }
        }
        #endregion
    }
}
