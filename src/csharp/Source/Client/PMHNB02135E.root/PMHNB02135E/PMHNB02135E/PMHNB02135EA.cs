using System;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 得意先別過年度統計表 リモート抽出結果クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別過年度統計表のリモート抽出結果を保持する。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br>           : </br>
    /// </remarks>
    public class PMHNB02135EA
    {
        #region ■ Public定数
        // テーブル名称
        public const string ct_Tbl_CustFinancialRsltList = "CustFinancialRsltList";
        // 企業コード
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        // 計上拠点コード
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        // 拠点ガイド略称
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";
        // 得意先コード
        public const string ct_Col_CustomerCode = "CustomerCode";
        // 得意先略称
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        // 売上金額
        public const string ct_Col_SalesMoney = "SalesMoney";
        // 返品額
        public const string ct_Col_SalesRetGoodsPrice = "SalesRetGoodsPrice";
        // 値引金額
        public const string ct_Col_DiscountPrice = "DiscountPrice";
        // 粗利金額
        public const string ct_Col_GrossProfit = "GrossProfit";
        // 会計年度
        public const string ct_Col_FinancialYear = "FinancialYear";

        #endregion

        #region ■ コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public PMHNB02135EA()
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
                dt = new DataTable(ct_Tbl_CustFinancialRsltList);

                // 企業コード
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;

                // 計上拠点コード
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = string.Empty;

                // 得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;

                // 売上金額
                dt.Columns.Add(ct_Col_SalesMoney, typeof(Int64));
                dt.Columns[ct_Col_SalesMoney].DefaultValue = 0;

                // 返品額
                dt.Columns.Add(ct_Col_SalesRetGoodsPrice, typeof(Int64));
                dt.Columns[ct_Col_SalesRetGoodsPrice].DefaultValue = 0;

                // 値引金額
                dt.Columns.Add(ct_Col_DiscountPrice, typeof(Int64));
                dt.Columns[ct_Col_DiscountPrice].DefaultValue = 0;

                // 粗利金額
                dt.Columns.Add(ct_Col_GrossProfit, typeof(Int64));
                dt.Columns[ct_Col_GrossProfit].DefaultValue = 0;

                // 会計年度
                dt.Columns.Add(ct_Col_FinancialYear, typeof(Int32));
                dt.Columns[ct_Col_FinancialYear].DefaultValue = 0;
            }
        }
        #endregion
    }
}
