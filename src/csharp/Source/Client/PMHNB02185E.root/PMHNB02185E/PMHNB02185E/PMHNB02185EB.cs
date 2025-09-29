using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 得意先別取引分布表 帳票印字用データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別取引分布表の帳票印字用データを保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02185EB
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_CustSalesDistributionReportForPrint = "CustSalesDistributionReportForPrint";
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
        // 粗利
        public const string ct_Col_GrossProfit = "GrossProfit";
        // 営業日数
        public const string ct_Col_BusinessDays = "BusinessDays";

        // 売上日付1
        public const string ct_Col_SalesDate1 = "SalesDate1";
        // 売上日付2
        public const string ct_Col_SalesDate2 = "SalesDate2";
        // 売上日付3
        public const string ct_Col_SalesDate3 = "SalesDate3";
        // 売上日付4
        public const string ct_Col_SalesDate4 = "SalesDate4";
        // 売上日付5
        public const string ct_Col_SalesDate5 = "SalesDate5";
        // 売上日付6
        public const string ct_Col_SalesDate6 = "SalesDate6";
        // 売上日付7
        public const string ct_Col_SalesDate7 = "SalesDate7";
        // 売上日付8
        public const string ct_Col_SalesDate8 = "SalesDate8";
        // 売上日付9
        public const string ct_Col_SalesDate9 = "SalesDate9";
        // 売上日付10
        public const string ct_Col_SalesDate10 = "SalesDate10";
        // 売上日付11
        public const string ct_Col_SalesDate11 = "SalesDate11";
        // 売上日付12
        public const string ct_Col_SalesDate12 = "SalesDate12";
        // 売上日付13
        public const string ct_Col_SalesDate13 = "SalesDate13";
        // 売上日付14
        public const string ct_Col_SalesDate14 = "SalesDate14";
        // 売上日付15
        public const string ct_Col_SalesDate15 = "SalesDate15";
        // 売上日付16
        public const string ct_Col_SalesDate16 = "SalesDate16";
        // 売上日付17
        public const string ct_Col_SalesDate17 = "SalesDate17";
        // 売上日付18
        public const string ct_Col_SalesDate18 = "SalesDate18";
        // 売上日付19
        public const string ct_Col_SalesDate19 = "SalesDate19";
        // 売上日付20
        public const string ct_Col_SalesDate20 = "SalesDate20";
        // 売上日付21
        public const string ct_Col_SalesDate21 = "SalesDate21";
        // 売上日付22
        public const string ct_Col_SalesDate22 = "SalesDate22";
        // 売上日付23
        public const string ct_Col_SalesDate23 = "SalesDate23";
        // 売上日付24
        public const string ct_Col_SalesDate24 = "SalesDate24";
        // 売上日付25
        public const string ct_Col_SalesDate25 = "SalesDate25";
        // 売上日付26
        public const string ct_Col_SalesDate26 = "SalesDate26";
        // 売上日付27
        public const string ct_Col_SalesDate27 = "SalesDate27";
        // 売上日付28
        public const string ct_Col_SalesDate28 = "SalesDate28";
        // 売上日付29
        public const string ct_Col_SalesDate29 = "SalesDate29";
        // 売上日付30
        public const string ct_Col_SalesDate30 = "SalesDate30";
        // 売上日付31
        public const string ct_Col_SalesDate31 = "SalesDate31";

        // 順位
        public const string ct_Col_Order = "Order";


        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMHNB02185EB()
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
                dt = new DataTable(ct_Tbl_CustSalesDistributionReportForPrint);

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
                // 粗利
                dt.Columns.Add(ct_Col_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;
                // 営業日数
                dt.Columns.Add(ct_Col_BusinessDays, typeof(Int32));
                dt.Columns[ct_Col_BusinessDays].DefaultValue = 0;
                // 売上日付1
                dt.Columns.Add(ct_Col_SalesDate1, typeof(string));
                dt.Columns[ct_Col_SalesDate1].DefaultValue = string.Empty;
                // 売上日付2
                dt.Columns.Add(ct_Col_SalesDate2, typeof(string));
                dt.Columns[ct_Col_SalesDate2].DefaultValue = string.Empty;
                // 売上日付3
                dt.Columns.Add(ct_Col_SalesDate3, typeof(string));
                dt.Columns[ct_Col_SalesDate3].DefaultValue = string.Empty;
                // 売上日付4
                dt.Columns.Add(ct_Col_SalesDate4, typeof(string));
                dt.Columns[ct_Col_SalesDate4].DefaultValue = string.Empty;
                // 売上日付5
                dt.Columns.Add(ct_Col_SalesDate5, typeof(string));
                dt.Columns[ct_Col_SalesDate5].DefaultValue = string.Empty;
                // 売上日付6
                dt.Columns.Add(ct_Col_SalesDate6, typeof(string));
                dt.Columns[ct_Col_SalesDate6].DefaultValue = string.Empty;
                // 売上日付7
                dt.Columns.Add(ct_Col_SalesDate7, typeof(string));
                dt.Columns[ct_Col_SalesDate7].DefaultValue = string.Empty;
                // 売上日付8
                dt.Columns.Add(ct_Col_SalesDate8, typeof(string));
                dt.Columns[ct_Col_SalesDate8].DefaultValue = string.Empty;
                // 売上日付9
                dt.Columns.Add(ct_Col_SalesDate9, typeof(string));
                dt.Columns[ct_Col_SalesDate9].DefaultValue = string.Empty;
                // 売上日付10
                dt.Columns.Add(ct_Col_SalesDate10, typeof(string));
                dt.Columns[ct_Col_SalesDate10].DefaultValue = string.Empty;
                // 売上日付11
                dt.Columns.Add(ct_Col_SalesDate11, typeof(string));
                dt.Columns[ct_Col_SalesDate11].DefaultValue = string.Empty;
                // 売上日付12
                dt.Columns.Add(ct_Col_SalesDate12, typeof(string));
                dt.Columns[ct_Col_SalesDate12].DefaultValue = string.Empty;
                // 売上日付13
                dt.Columns.Add(ct_Col_SalesDate13, typeof(string));
                dt.Columns[ct_Col_SalesDate13].DefaultValue = string.Empty;
                // 売上日付14
                dt.Columns.Add(ct_Col_SalesDate14, typeof(string));
                dt.Columns[ct_Col_SalesDate14].DefaultValue = string.Empty;
                // 売上日付15
                dt.Columns.Add(ct_Col_SalesDate15, typeof(string));
                dt.Columns[ct_Col_SalesDate15].DefaultValue = string.Empty;
                // 売上日付16
                dt.Columns.Add(ct_Col_SalesDate16, typeof(string));
                dt.Columns[ct_Col_SalesDate16].DefaultValue = string.Empty;
                // 売上日付17
                dt.Columns.Add(ct_Col_SalesDate17, typeof(string));
                dt.Columns[ct_Col_SalesDate17].DefaultValue = string.Empty;
                // 売上日付18
                dt.Columns.Add(ct_Col_SalesDate18, typeof(string));
                dt.Columns[ct_Col_SalesDate18].DefaultValue = string.Empty;
                // 売上日付19
                dt.Columns.Add(ct_Col_SalesDate19, typeof(string));
                dt.Columns[ct_Col_SalesDate19].DefaultValue = string.Empty;
                // 売上日付20
                dt.Columns.Add(ct_Col_SalesDate20, typeof(string));
                dt.Columns[ct_Col_SalesDate20].DefaultValue = string.Empty;
                // 売上日付21
                dt.Columns.Add(ct_Col_SalesDate21, typeof(string));
                dt.Columns[ct_Col_SalesDate21].DefaultValue = string.Empty;
                // 売上日付22
                dt.Columns.Add(ct_Col_SalesDate22, typeof(string));
                dt.Columns[ct_Col_SalesDate22].DefaultValue = string.Empty;
                // 売上日付23
                dt.Columns.Add(ct_Col_SalesDate23, typeof(string));
                dt.Columns[ct_Col_SalesDate23].DefaultValue = string.Empty;
                // 売上日付24
                dt.Columns.Add(ct_Col_SalesDate24, typeof(string));
                dt.Columns[ct_Col_SalesDate24].DefaultValue = string.Empty;
                // 売上日付25
                dt.Columns.Add(ct_Col_SalesDate25, typeof(string));
                dt.Columns[ct_Col_SalesDate25].DefaultValue = string.Empty;
                // 売上日付26
                dt.Columns.Add(ct_Col_SalesDate26, typeof(string));
                dt.Columns[ct_Col_SalesDate26].DefaultValue = string.Empty;
                // 売上日付27
                dt.Columns.Add(ct_Col_SalesDate27, typeof(string));
                dt.Columns[ct_Col_SalesDate27].DefaultValue = string.Empty;
                // 売上日付28
                dt.Columns.Add(ct_Col_SalesDate28, typeof(string));
                dt.Columns[ct_Col_SalesDate28].DefaultValue = string.Empty;
                // 売上日付29
                dt.Columns.Add(ct_Col_SalesDate29, typeof(string));
                dt.Columns[ct_Col_SalesDate29].DefaultValue = string.Empty;
                // 売上日付30
                dt.Columns.Add(ct_Col_SalesDate30, typeof(string));
                dt.Columns[ct_Col_SalesDate30].DefaultValue = string.Empty;
                // 売上日付31
                dt.Columns.Add(ct_Col_SalesDate31, typeof(string));
                dt.Columns[ct_Col_SalesDate31].DefaultValue = string.Empty;

                // 順位
                dt.Columns.Add(ct_Col_Order, typeof(Int32));
                dt.Columns[ct_Col_Order].DefaultValue = 0;
            }
        }
        #endregion
    }
}
