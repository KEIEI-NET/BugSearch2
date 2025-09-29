//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形取引先別表テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 手形取引先別表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形取引先別表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class PMTEG02505EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_TegataTorihikisakiListReportData = "Tbl_TegataTorihikisakiListReportData";

        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点名称 </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先名称 </summary>
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> 開始月分の合計 </summary>
        public const string ct_Col_SumMonth1 = "SumMonth1";
        /// <summary> ２ヶ月目分の合計 </summary>
        public const string ct_Col_SumMonth2 = "SumMonth2";
        /// <summary> ３ヶ月目分の合計 </summary>
        public const string ct_Col_SumMonth3 = "SumMonth3";
        /// <summary> ４ヶ月目分の合計 </summary>
        public const string ct_Col_SumMonth4 = "SumMonth4";
        /// <summary> ５ヶ月目分の合計 </summary>
        public const string ct_Col_SumMonth5 = "SumMonth5";
        /// <summary> ６ヶ月目分の合計 </summary>
        public const string ct_Col_SumMonth6 = "SumMonth6";
        /// <summary> ６ヶ月以降分の合計 </summary>
        public const string ct_Col_SumMonthSpare = "SumMonthSpare";
        /// <summary> 合計 </summary>
        public const string ct_Col_SumMonthAll = "SumMonthAll";

        /// <summary> 開始月分の合計(自振) </summary>
        public const string ct_Col_SumMonth1Self = "SumMonth1Self";
        /// <summary> ２ヶ月目分の合計(自振)  </summary>
        public const string ct_Col_SumMonth2Self = "SumMonth2Self";
        /// <summary> ３ヶ月目分の合計(自振)  </summary>
        public const string ct_Col_SumMonth3Self = "SumMonth3Self";
        /// <summary> ４ヶ月目分の合計(自振)  </summary>
        public const string ct_Col_SumMonth4Self = "SumMonth4Self";
        /// <summary> ５ヶ月目分の合計(自振)  </summary>
        public const string ct_Col_SumMonth5Self = "SumMonth5Self";
        /// <summary> ６ヶ月目分の合計(自振)  </summary>
        public const string ct_Col_SumMonth6Self = "SumMonth6Self";
        /// <summary> ６ヶ月以降分の合計(自振)  </summary>
        public const string ct_Col_SumMonthSpareSelf = "SumMonthSpareSelf";
        /// <summary> 合計(自振)  </summary>
        public const string ct_Col_SumMonthAllSelf = "SumMonthAllSelf";

        /// <summary> 開始月分の合計(他振) </summary>
        public const string ct_Col_SumMonth1Else = "SumMonth1Else";
        /// <summary> ２ヶ月目分の合計(他振)  </summary>
        public const string ct_Col_SumMonth2Else = "SumMonth2Else";
        /// <summary> ３ヶ月目分の合計(他振)  </summary>
        public const string ct_Col_SumMonth3Else = "SumMonth3Else";
        /// <summary> ４ヶ月目分の合計(他振)  </summary>
        public const string ct_Col_SumMonth4Else = "SumMonth4Else";
        /// <summary> ５ヶ月目分の合計(他振)  </summary>
        public const string ct_Col_SumMonth5Else = "SumMonth5Else";
        /// <summary> ６ヶ月目分の合計(他振)  </summary>
        public const string ct_Col_SumMonth6Else = "SumMonth6Else";
        /// <summary> ６ヶ月以降分の合計(他振)  </summary>
        public const string ct_Col_SumMonthSpareElse = "SumMonthSpareElse";
        /// <summary> 合計(他振)  </summary>
        public const string ct_Col_SumMonthAllElse = "SumMonthAllElse";

        /// <summary> 改頁 </summary>
        public const string ct_Col_ChangePage = "ChangePage";
        /// <summary> 出力順 </summary>
        public const string ct_Col_PrintType = "PrintType";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 手形取引先別表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手形取引先別表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public PMTEG02505EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 手形取引先別表DataSetテーブルスキーマ設定
        /// <summary>
        /// 手形取引先別表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 手形取引先別表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_TegataTorihikisakiListReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_TegataTorihikisakiListReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_TegataTorihikisakiListReportData);

                DataTable dt = ds.Tables[ct_Tbl_TegataTorihikisakiListReportData];
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
                // 開始月分の合計
                dt.Columns.Add(ct_Col_SumMonth1, typeof(long));
                dt.Columns[ct_Col_SumMonth1].DefaultValue = 0;
                // ２ヶ月目分の合計
                dt.Columns.Add(ct_Col_SumMonth2, typeof(long));
                dt.Columns[ct_Col_SumMonth2].DefaultValue = 0;
                // ３ヶ月目分の合計
                dt.Columns.Add(ct_Col_SumMonth3, typeof(long));
                dt.Columns[ct_Col_SumMonth3].DefaultValue = 0;
                // ４ヶ月目分の合計
                dt.Columns.Add(ct_Col_SumMonth4, typeof(long));
                dt.Columns[ct_Col_SumMonth4].DefaultValue = 0;
                // ５ヶ月目分の合計
                dt.Columns.Add(ct_Col_SumMonth5, typeof(long));
                dt.Columns[ct_Col_SumMonth5].DefaultValue = 0;
                // ６ヶ月目分の合計
                dt.Columns.Add(ct_Col_SumMonth6, typeof(long));
                dt.Columns[ct_Col_SumMonth6].DefaultValue = 0;
                // ６ヶ月以降分の合計
                dt.Columns.Add(ct_Col_SumMonthSpare, typeof(long));
                dt.Columns[ct_Col_SumMonthSpare].DefaultValue = 0;
                // 合計
                dt.Columns.Add(ct_Col_SumMonthAll, typeof(long));
                dt.Columns[ct_Col_SumMonthAll].DefaultValue = 0;

                // 開始月分の合計(自振)
                dt.Columns.Add(ct_Col_SumMonth1Self, typeof(long));
                dt.Columns[ct_Col_SumMonth1Self].DefaultValue = 0;
                // ２ヶ月目分の合計(自振)
                dt.Columns.Add(ct_Col_SumMonth2Self, typeof(long));
                dt.Columns[ct_Col_SumMonth2Self].DefaultValue = 0;
                // ３ヶ月目分の合計(自振)
                dt.Columns.Add(ct_Col_SumMonth3Self, typeof(long));
                dt.Columns[ct_Col_SumMonth3Self].DefaultValue = 0;
                // ４ヶ月目分の合計(自振)
                dt.Columns.Add(ct_Col_SumMonth4Self, typeof(long));
                dt.Columns[ct_Col_SumMonth4Self].DefaultValue = 0;
                // ５ヶ月目分の合計(自振)
                dt.Columns.Add(ct_Col_SumMonth5Self, typeof(long));
                dt.Columns[ct_Col_SumMonth5Self].DefaultValue = 0;
                // ６ヶ月目分の合計(自振)
                dt.Columns.Add(ct_Col_SumMonth6Self, typeof(long));
                dt.Columns[ct_Col_SumMonth6Self].DefaultValue = 0;
                // ６ヶ月以降分の合計(自振)
                dt.Columns.Add(ct_Col_SumMonthSpareSelf, typeof(long));
                dt.Columns[ct_Col_SumMonthSpareSelf].DefaultValue = 0;
                // 合計(自振)
                dt.Columns.Add(ct_Col_SumMonthAllSelf, typeof(long));
                dt.Columns[ct_Col_SumMonthAllSelf].DefaultValue = 0;

                // 開始月分の合計(他振)
                dt.Columns.Add(ct_Col_SumMonth1Else, typeof(long));
                dt.Columns[ct_Col_SumMonth1Else].DefaultValue = 0;
                // ２ヶ月目分の合計(他振)
                dt.Columns.Add(ct_Col_SumMonth2Else, typeof(long));
                dt.Columns[ct_Col_SumMonth2Else].DefaultValue = 0;
                // ３ヶ月目分の合計(他振)
                dt.Columns.Add(ct_Col_SumMonth3Else, typeof(long));
                dt.Columns[ct_Col_SumMonth3Else].DefaultValue = 0;
                // ４ヶ月目分の合計(他振)
                dt.Columns.Add(ct_Col_SumMonth4Else, typeof(long));
                dt.Columns[ct_Col_SumMonth4Else].DefaultValue = 0;
                // ５ヶ月目分の合計(他振)
                dt.Columns.Add(ct_Col_SumMonth5Else, typeof(long));
                dt.Columns[ct_Col_SumMonth5Else].DefaultValue = 0;
                // ６ヶ月目分の合計(他振)
                dt.Columns.Add(ct_Col_SumMonth6Else, typeof(long));
                dt.Columns[ct_Col_SumMonth6Else].DefaultValue = 0;
                // ６ヶ月以降分の合計(他振)
                dt.Columns.Add(ct_Col_SumMonthSpareElse, typeof(long));
                dt.Columns[ct_Col_SumMonthSpareElse].DefaultValue = 0;
                // 合計(他振)
                dt.Columns.Add(ct_Col_SumMonthAllElse, typeof(long));
                dt.Columns[ct_Col_SumMonthAllElse].DefaultValue = 0;

                // 改頁
                dt.Columns.Add(ct_Col_ChangePage, typeof(string));
                dt.Columns[ct_Col_ChangePage].DefaultValue = string.Empty;
                // 出力順
                dt.Columns.Add(ct_Col_PrintType, typeof(string));
                dt.Columns[ct_Col_PrintType].DefaultValue = string.Empty;

            }
        }
        #endregion
        #endregion
    }
}