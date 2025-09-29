using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上内容分析表 リモート抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上内容分析表のリモート抽出結果を保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02165EA
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_SalesHistAnalyzeResult = "ct_Tbl_SalesHistAnalyzeResult";
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

        // 売上金額(日計取寄)
        public const string ct_Col_SalesMoneyOrder = "SalesMoneyOrder";
        // 売上金額(日計在庫)
        public const string ct_Col_SalesMoneyStock = "SalesMoneyStock";
        // 売上金額(日計純正)
        public const string ct_Col_SalesMoneyGenuine = "SalesMoneyGenuine";
        // 売上金額(日計優良)
        public const string ct_Col_SalesMoneyPrm = "SalesMoneyPrm";
        // 売上金額(日計外装)
        public const string ct_Col_SalesMoneyOutside = "SalesMoneyOutside";
        // 売上金額(日計その他)
        public const string ct_Col_SalesMoneyOther = "SalesMoneyOther";
        // 売上金額(累計取寄)
        public const string ct_Col_MonthSalesMoneyOrder = "MonthSalesMoneyOrder";
        // 売上金額(累計在庫)
        public const string ct_Col_MonthSalesMoneyStock = "MonthSalesMoneyStock";
        // 売上金額(累計純正)
        public const string ct_Col_MonthSalesMoneyGenuine = "MonthSalesMoneyGenuine";
        // 売上金額(累計優良)
        public const string ct_Col_MonthSalesMoneyPrm = "MonthSalesMoneyPrm";
        // 売上金額(累計外装)
        public const string ct_Col_MonthSalesMoneyOutside = "MonthSalesMoneyOutside";
        // 売上金額(累計その他)
        public const string ct_Col_MonthSalesMoneyOther = "MonthSalesMoneyOther";

        // 粗利金額(日計取寄)
        public const string ct_Col_GrossProfitOrder = "GrossProfitOrder";
        // 粗利金額(日計在庫)
        public const string ct_Col_GrossProfitStock = "GrossProfitStock";
        // 粗利金額(日計純正)
        public const string ct_Col_GrossProfitGenuine = "GrossProfitGenuine";
        // 粗利金額(日計優良)
        public const string ct_Col_GrossProfitPrm = "GrossProfitPrm";
        // 粗利金額(日計外装)
        public const string ct_Col_GrossProfitOutside = "GrossProfitOutside";
        // 粗利金額(日計その他)
        public const string ct_Col_GrossProfitOther = "GrossProfitOther";
        // 粗利金額(累計取寄)
        public const string ct_Col_MonthGrossProfitOrder = "MonthGrossProfitOrder";
        // 粗利金額(累計在庫)
        public const string ct_Col_MonthGrossProfitStock = "MonthGrossProfitStock";
        // 粗利金額(累計純正)
        public const string ct_Col_MonthGrossProfitGenuine = "MonthGrossProfitGenuine";
        // 粗利金額(累計優良)
        public const string ct_Col_MonthGrossProfitPrm = "MonthGrossProfitPrm";
        // 粗利金額(累計外装)
        public const string ct_Col_MonthGrossProfitOutside = "MonthGrossProfitOutside";
        // 粗利金額(累計その他)
        public const string ct_Col_MonthGrossProfitOther = "MonthGrossProfitOther";

        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMHNB02165EA()
        {
        }

        #endregion

        #region ■ publicメソッド
        /// <summary>
        /// 売上内容分析表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 売上内容分析表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.11</br>
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
                dt = new DataTable(ct_Tbl_SalesHistAnalyzeResult);

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

                // 売上金額(日計取寄)
                dt.Columns.Add(ct_Col_SalesMoneyOrder, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyOrder].DefaultValue = 0;
        
                // 売上金額(日計在庫)
                dt.Columns.Add(ct_Col_SalesMoneyStock, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyStock].DefaultValue = 0;

                // 売上金額(日計純正)
                dt.Columns.Add(ct_Col_SalesMoneyGenuine, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyGenuine].DefaultValue = 0;

                // 売上金額(日計優良)
                dt.Columns.Add(ct_Col_SalesMoneyPrm, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyPrm].DefaultValue = 0;

                // 売上金額(日計外装)
                dt.Columns.Add(ct_Col_SalesMoneyOutside, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyOutside].DefaultValue = 0;

                // 売上金額(日計その他)
                dt.Columns.Add(ct_Col_SalesMoneyOther, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyOther].DefaultValue = 0;

                // 売上金額(累計取寄)
                dt.Columns.Add(ct_Col_MonthSalesMoneyOrder, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyOrder].DefaultValue = 0;

                // 売上金額(累計在庫)
                dt.Columns.Add(ct_Col_MonthSalesMoneyStock, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyStock].DefaultValue = 0;

                // 売上金額(累計純正)
                dt.Columns.Add(ct_Col_MonthSalesMoneyGenuine, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyGenuine].DefaultValue = 0;

                // 売上金額(累計優良)
                dt.Columns.Add(ct_Col_MonthSalesMoneyPrm, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyPrm].DefaultValue = 0;

                // 売上金額(累計外装)
                dt.Columns.Add(ct_Col_MonthSalesMoneyOutside, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyOutside].DefaultValue = 0;

                // 売上金額(累計その他)
                dt.Columns.Add(ct_Col_MonthSalesMoneyOther, typeof(Int64));
                dt.Columns[ct_Col_MonthSalesMoneyOther].DefaultValue = 0;

                // 粗利金額(日計取寄)
                dt.Columns.Add(ct_Col_GrossProfitOrder, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitOrder].DefaultValue = 0;

                // 粗利金額(日計在庫)
                dt.Columns.Add(ct_Col_GrossProfitStock, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitStock].DefaultValue = 0;

                // 粗利金額(日計純正)
                dt.Columns.Add(ct_Col_GrossProfitGenuine, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitGenuine].DefaultValue = 0;

                // 粗利金額(日計優良)
                dt.Columns.Add(ct_Col_GrossProfitPrm, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitPrm].DefaultValue = 0;

                // 粗利金額(日計外装)
                dt.Columns.Add(ct_Col_GrossProfitOutside, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitOutside].DefaultValue = 0;

                // 粗利金額(日計その他)
                dt.Columns.Add(ct_Col_GrossProfitOther, typeof(Int64));
                dt.Columns[ct_Col_GrossProfitOther].DefaultValue = 0;

                // 粗利金額(累計取寄)
                dt.Columns.Add(ct_Col_MonthGrossProfitOrder, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitOrder].DefaultValue = 0;

                // 粗利金額(累計在庫)
                dt.Columns.Add(ct_Col_MonthGrossProfitStock, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitStock].DefaultValue = 0;

                // 粗利金額(累計純正)
                dt.Columns.Add(ct_Col_MonthGrossProfitGenuine, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitGenuine].DefaultValue = 0;

                // 粗利金額(累計優良)
                dt.Columns.Add(ct_Col_MonthGrossProfitPrm, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitPrm].DefaultValue = 0;

                // 粗利金額(累計外装)
                dt.Columns.Add(ct_Col_MonthGrossProfitOutside, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitOutside].DefaultValue = 0;

                // 粗利金額(累計その他)
                dt.Columns.Add(ct_Col_MonthGrossProfitOther, typeof(Int64));
                dt.Columns[ct_Col_MonthGrossProfitOther].DefaultValue = 0;



        
            }
        }
        #endregion
    }
}
