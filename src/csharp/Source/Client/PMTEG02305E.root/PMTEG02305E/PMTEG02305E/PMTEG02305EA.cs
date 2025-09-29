//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形期日別表テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/05/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 手形期日別表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形期日別表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class PMTEG02305EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_TegataKibiListReportData = "Tbl_TegataKibiListReportData";

        /// <summary> 日付 </summary>
        public const string ct_Col_Day = "Day";
        /// <summary> 手形種別コード </summary>
        public const string ct_Col_DraftKindCd = "DraftKindCd";
        /// <summary> 手形種別名称 </summary>
        public const string ct_Col_DraftKindName = "DraftKindName";
        /// <summary> 銀行支店コード </summary>
        public const string ct_Col_BankAndBranchCd = "BankAndBranchCd";
        /// <summary> 銀行支店名称 </summary>
        public const string ct_Col_BankAndBranchNm = "BankAndBranchNm";
        /// <summary> 手形種別 + 銀行支店 </summary>
        public const string ct_Col_DraftKindAndBankCode = "DraftKindAndBankCode";

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

        /// <summary> 開始月分の件数合計 </summary>
        public const string ct_Col_CountMonth1 = "CountMonth1";
        /// <summary> ２ヶ月目分の件数合計  </summary>
        public const string ct_Col_CountMonth2 = "CountMonth2";
        /// <summary> ３ヶ月目分の件数合計  </summary>
        public const string ct_Col_CountMonth3 = "CountMonth3";
        /// <summary> ４ヶ月目分の件数合計  </summary>
        public const string ct_Col_CountMonth4 = "CountMonth4";
        /// <summary> ５ヶ月目分の件数合計  </summary>
        public const string ct_Col_CountMonth5 = "CountMonth5";
        /// <summary> ６ヶ月目分の件数合計  </summary>
        public const string ct_Col_CountMonth6 = "CountMonth6";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 手形期日別表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手形期日別表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02305EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 手形期日別表DataSetテーブルスキーマ設定
        /// <summary>
        /// 手形期日別表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 手形期日別表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_TegataKibiListReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_TegataKibiListReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_TegataKibiListReportData);

                DataTable dt = ds.Tables[ct_Tbl_TegataKibiListReportData];
                // 日付
                dt.Columns.Add(ct_Col_Day, typeof(string));
                dt.Columns[ct_Col_Day].DefaultValue = string.Empty;
                // 手形種別コード
                dt.Columns.Add(ct_Col_DraftKindCd, typeof(string));
                dt.Columns[ct_Col_DraftKindCd].DefaultValue = string.Empty;
                // 手形種別名称
                dt.Columns.Add(ct_Col_DraftKindName, typeof(string));
                dt.Columns[ct_Col_DraftKindName].DefaultValue = string.Empty;
                // 銀行支店コード
                dt.Columns.Add(ct_Col_BankAndBranchCd, typeof(string));
                dt.Columns[ct_Col_BankAndBranchCd].DefaultValue = string.Empty;
                // 銀行支店名称
                dt.Columns.Add(ct_Col_BankAndBranchNm, typeof(string));
                dt.Columns[ct_Col_BankAndBranchNm].DefaultValue = string.Empty;
                // 手形種別 + 銀行支店
                dt.Columns.Add(ct_Col_DraftKindAndBankCode, typeof(string));
                dt.Columns[ct_Col_DraftKindAndBankCode].DefaultValue = string.Empty;

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

                // 開始月分の件数合計
                dt.Columns.Add(ct_Col_CountMonth1, typeof(long));
                dt.Columns[ct_Col_CountMonth1].DefaultValue = 0;
                // ２ヶ月目分の件数合計
                dt.Columns.Add(ct_Col_CountMonth2, typeof(long));
                dt.Columns[ct_Col_CountMonth2].DefaultValue = 0;
                // ３ヶ月目分の件数合計
                dt.Columns.Add(ct_Col_CountMonth3, typeof(long));
                dt.Columns[ct_Col_CountMonth3].DefaultValue = 0;
                // ４ヶ月目分の件数合計
                dt.Columns.Add(ct_Col_CountMonth4, typeof(long));
                dt.Columns[ct_Col_CountMonth4].DefaultValue = 0;
                // ５ヶ月目分の件数合計
                dt.Columns.Add(ct_Col_CountMonth5, typeof(long));
                dt.Columns[ct_Col_CountMonth5].DefaultValue = 0;
                // ６ヶ月目分の件数合計
                dt.Columns.Add(ct_Col_CountMonth6, typeof(long));
                dt.Columns[ct_Col_CountMonth6].DefaultValue = 0;

            }
        }
        #endregion
        #endregion
    }
}