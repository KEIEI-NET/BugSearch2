//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品理由一覧表テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 返品理由一覧表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品理由一覧表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.05.11</br>
    /// </remarks>
    public class PMHNB02215EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_RetGoodsReasonReportData = "Tbl_RetGoodsReasonReportData";
        /// <summary> 返品理由コード </summary>
        public const string ct_Col_RetGoodsReasonDiv = "RetGoodsReasonDiv";
        /// <summary> 返品理由 </summary>
        public const string ct_Col_RetGoodsReason = "RetGoodsReason";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点名称 </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先名称 </summary>
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> 担当者コード </summary>
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        /// <summary> 担当者名称 </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> 詳細コード </summary>
        public const string ct_Col_DetailCode = "DetailCode";
        /// <summary> 詳細名称 </summary>
        public const string ct_Col_DetailNm = "DetailNm";
        /// <summary> 受注者コード </summary>
        public const string ct_Col_FrontEmployeeCd = "FrontEmployeeCd";
        /// <summary> 受注者名称 </summary>
        public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        /// <summary> 発行者コード </summary>
        public const string ct_Col_SalesInputCode = "SalesInputCode";
        /// <summary> 発行者名称 </summary>
        public const string ct_Col_SalesInputName = "SalesInputName";
        /// <summary> 金額 </summary>
        public const string ct_Col_MoneySum = "MoneySum";
        /// <summary> 件数 </summary>
        public const string ct_Col_Count = "Count";
        /// <summary> 比率 </summary>
        public const string ct_Col_Rate = "Rate";
        /// <summary> Detail比率 </summary>
        public const string ct_Col_DetailRate = "DetailRate";
        /// <summary> 拠点比率 </summary>
        public const string ct_Col_SectionRate = "SectionRate";
        /// <summary> 実績計上拠点コード </summary>
        public const string ct_Col_ResultsAddUpSecCd = "ResultsAddUpSecCd";
        /// <summary> 改頁 </summary>
        public const string ct_Col_ChangePage = "ChangePage";
        /// <summary> 伝票種別 </summary>
        public const string ct_Col_SlipKind = "SlipKind";
        /// <summary> 対象年月 </summary>
        public const string ct_Col_YearMonth = "YearMonth";
        /// <summary> 出力順 </summary>
        public const string ct_Col_PrintType = "PrintType";
        /// <summary> 売上行番号 </summary>
        public const string ct_Col_SlipKey = "SlipKey";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 返品理由一覧表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 返品理由一覧表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public PMHNB02215EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 返品理由一覧DataSetテーブルスキーマ設定
        /// <summary>
        /// 返品理由一覧DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 返品理由一覧データセットのスキーマを設定する。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_RetGoodsReasonReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_RetGoodsReasonReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_RetGoodsReasonReportData);

                DataTable dt = ds.Tables[ct_Tbl_RetGoodsReasonReportData];
                // 返品理由コード
                dt.Columns.Add(ct_Col_RetGoodsReasonDiv, typeof(string));
                dt.Columns[ct_Col_RetGoodsReasonDiv].DefaultValue = string.Empty;
                // 返品理由
                dt.Columns.Add(ct_Col_RetGoodsReason, typeof(string));
                dt.Columns[ct_Col_RetGoodsReason].DefaultValue = string.Empty;
                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;
                // 拠点ガイド名称
                dt.Columns.Add(ct_Col_SectionName, typeof(string));
                dt.Columns[ct_Col_SectionName].DefaultValue = string.Empty;
                // 得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = string.Empty;
                // 得意先名称
                dt.Columns.Add(ct_Col_CustomerName, typeof(string));
                dt.Columns[ct_Col_CustomerName].DefaultValue = string.Empty;
                // 担当者コード
                dt.Columns.Add(ct_Col_SalesEmployeeCd, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = string.Empty;
                // 担当者名称
                dt.Columns.Add(ct_Col_SalesEmployeeNm, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = string.Empty;
                // 受注者コード
                dt.Columns.Add(ct_Col_FrontEmployeeCd, typeof(string));
                dt.Columns[ct_Col_FrontEmployeeCd].DefaultValue = string.Empty;
                // 受注者名称
                dt.Columns.Add(ct_Col_FrontEmployeeNm, typeof(string));
                dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = string.Empty;
                // 発行者コード
                dt.Columns.Add(ct_Col_SalesInputCode, typeof(string));
                dt.Columns[ct_Col_SalesInputCode].DefaultValue = string.Empty;
                // 発行者名称
                dt.Columns.Add(ct_Col_SalesInputName, typeof(string));
                dt.Columns[ct_Col_SalesInputName].DefaultValue = string.Empty;
                // 金額
                dt.Columns.Add(ct_Col_MoneySum, typeof(Int64));
                dt.Columns[ct_Col_MoneySum].DefaultValue = 0;
                // 件数
                dt.Columns.Add(ct_Col_Count, typeof(Int32));
                dt.Columns[ct_Col_Count].DefaultValue = 0;
                // 伝票種別
                dt.Columns.Add(ct_Col_SlipKind, typeof(string));
                dt.Columns[ct_Col_SlipKind].DefaultValue = string.Empty;
                // 比率
                dt.Columns.Add(ct_Col_Rate, typeof(double));
                dt.Columns[ct_Col_Rate].DefaultValue = 0;
                // Detail比率 
                dt.Columns.Add(ct_Col_DetailRate, typeof(double));
                dt.Columns[ct_Col_DetailRate].DefaultValue = 0;
                // 拠点比率 
                dt.Columns.Add(ct_Col_SectionRate, typeof(double));
                dt.Columns[ct_Col_SectionRate].DefaultValue = 0;
                // 改頁
                dt.Columns.Add(ct_Col_ChangePage, typeof(string));
                dt.Columns[ct_Col_ChangePage].DefaultValue = string.Empty;
                // 対象年月
                dt.Columns.Add(ct_Col_YearMonth, typeof(string));
                dt.Columns[ct_Col_YearMonth].DefaultValue = string.Empty;
                // 出力順
                dt.Columns.Add(ct_Col_PrintType, typeof(string));
                dt.Columns[ct_Col_PrintType].DefaultValue = string.Empty;
                // 実績計上拠点コード 
                dt.Columns.Add(ct_Col_ResultsAddUpSecCd, typeof(string));
                dt.Columns[ct_Col_ResultsAddUpSecCd].DefaultValue = string.Empty;
                // 売上行番号 
                dt.Columns.Add(ct_Col_SlipKey, typeof(string));
                dt.Columns[ct_Col_SlipKey].DefaultValue = string.Empty;
                // 詳細コード 
                dt.Columns.Add(ct_Col_DetailCode, typeof(string));
                dt.Columns[ct_Col_DetailCode].DefaultValue = string.Empty;
                // 詳細名称
                dt.Columns.Add(ct_Col_DetailNm, typeof(string));
                dt.Columns[ct_Col_DetailNm].DefaultValue = string.Empty;

            }
        }
        #endregion
        #endregion
    }
}