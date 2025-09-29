//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形月別予定表テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
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
    /// 手形月別予定表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形月別予定表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class PMTEG02405EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_TegataTsukibetsuYoteListReportData = "Tbl_TegataTsukibetsuYoteListReportData";

		/// <summary> 手形種別コード </summary>
		public const string ct_Col_DraftKindCd = "DraftKindCd";
		/// <summary> 手形種別名称 </summary>
		public const string ct_Col_DraftKindName = "DraftKindName";
		/// <summary> 銀行・支店コード </summary>
		public const string ct_Col_BankAndBranchCd = "BankAndBranchCd";
		/// <summary> 銀行・支店名称 </summary>
		public const string ct_Col_BankAndBranchNm = "BankAndBranchNm";
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
        /// <summary> 改頁 </summary>
        public const string ct_Col_ChangePage = "ChangePage";
        /// <summary> 出力順 </summary>
        public const string ct_Col_PrintType = "PrintType";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 手形月別予定表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手形月別予定表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        public PMTEG02405EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 手形月別予定表DataSetテーブルスキーマ設定
        /// <summary>
        /// 手形月別予定表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 手形月別予定表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_TegataTsukibetsuYoteListReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_TegataTsukibetsuYoteListReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_TegataTsukibetsuYoteListReportData);

                DataTable dt = ds.Tables[ct_Tbl_TegataTsukibetsuYoteListReportData];
				// 手形種別コード
				dt.Columns.Add(ct_Col_DraftKindCd, typeof(string));
				dt.Columns[ct_Col_DraftKindCd].DefaultValue = string.Empty;
				// 手形種別名称
				dt.Columns.Add(ct_Col_DraftKindName, typeof(string));
				dt.Columns[ct_Col_DraftKindName].DefaultValue = string.Empty;
				// 銀行・支店コード
				dt.Columns.Add(ct_Col_BankAndBranchCd, typeof(string));
				dt.Columns[ct_Col_BankAndBranchCd].DefaultValue = string.Empty;
				// 銀行・支店名称
				dt.Columns.Add(ct_Col_BankAndBranchNm, typeof(string));
				dt.Columns[ct_Col_BankAndBranchNm].DefaultValue = string.Empty;
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