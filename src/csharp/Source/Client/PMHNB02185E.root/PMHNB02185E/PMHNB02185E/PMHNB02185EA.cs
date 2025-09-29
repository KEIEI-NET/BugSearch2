using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 得意先別取引分布表 リモート抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別取引分布表のリモート抽出結果を保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02185EA
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_CustSalesDistributionReport = "CustSalesDistributionReport";
        // 企業コード
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        // 拠点コード
        public const string ct_Col_SecCode = "SecCode";
        // 拠点ガイド略称
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        // 得意先コード
        public const string ct_Col_CustomerCode = "CustomerCode";
        // 得意先略称
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        // 販売従業員コード
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        // 販売従業員名称
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        // 販売エリアコード
        public const string ct_Col_SalesAreaCode = "SalesAreaCode";
        // 販売エリア名称
        public const string ct_Col_SalesAreaName = "SalesAreaName";

        // 伝票枚数
        public const string ct_Col_SalesCount = "SalesCount";
        // 純売上
        public const string ct_Col_SalesTotalTaxExc = "SalesTotalTaxExc";
        // 原価金額計
        public const string ct_Col_TotalCost = "TotalCost";
        // 売上日付
        public const string ct_Col_SalesDate = "SalesDate";


        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMHNB02185EA()
        {
        }

        #endregion

        #region ■ publicメソッド
        /// <summary>
        /// 得意先別取引分布表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 得意先別取引分布表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
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
                dt = new DataTable(ct_Tbl_CustSalesDistributionReport);

                // 企業コード
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;

                // 拠点コード
                dt.Columns.Add(ct_Col_SecCode, typeof(string));
                dt.Columns[ct_Col_SecCode].DefaultValue = string.Empty;

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // 得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;

                // 販売従業員コード
                dt.Columns.Add(ct_Col_SalesEmployeeCd, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = string.Empty;

                // 販売従業員名称
                dt.Columns.Add(ct_Col_SalesEmployeeNm, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = string.Empty;

                // 販売エリアコード
                dt.Columns.Add(ct_Col_SalesAreaCode, typeof(Int32));
                dt.Columns[ct_Col_SalesAreaCode].DefaultValue = 0;

                // 販売エリア名称
                dt.Columns.Add(ct_Col_SalesAreaName, typeof(string));
                dt.Columns[ct_Col_SalesAreaName].DefaultValue = string.Empty;

                // 伝票枚数
                dt.Columns.Add(ct_Col_SalesCount, typeof(Int32));
                dt.Columns[ct_Col_SalesCount].DefaultValue = 0;
                // 純売上
                dt.Columns.Add(ct_Col_SalesTotalTaxExc, typeof(Int64));
                dt.Columns[ct_Col_SalesTotalTaxExc].DefaultValue = 0;
                // 原価金額計
                dt.Columns.Add(ct_Col_TotalCost, typeof(Int64));
                dt.Columns[ct_Col_TotalCost].DefaultValue = 0;
                // 売上日付
                dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
                dt.Columns[ct_Col_SalesDate].DefaultValue = DateTime.MinValue;
            }
        }
        #endregion
    }
}
