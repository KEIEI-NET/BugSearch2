using System;
using System.Data;
//using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 目標売上対比表(売上目標金額)チャート用抽出結果データテーブルスキーマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 目標売上対比表(売上目標金額)チャート用抽出結果テーブルスキーマです。</br>
    /// <br>Programmer : ネプコ</br>
    /// <br>Date       : 2007.04.19</br>
    /// </remarks>
    public class MAMOK02123EB
    {
        #region Public Members
        /// <summary>目標売上対比表(売上目標金額)チャート用データテーブル名</summary>
        public const string CT_CsSalesTargetDataTable     = "CsSalesTargetDataTable";
        /// <summary>目標売上対比表(売上目標金額)チャート用バッファデータテーブル名</summary>
        public const string CT_CsSalesTargetBuffDataTable = "CsSalesTargetBuffDataTable";

        #region 目標売上対比表チャート用カラム情報
        /// <summary>適用開始日</summary>
        public const string CT_CsSalesTarget_ApplyStaDate      = "日";
/*
        /// <summary>売上目標金額(日付別)</summary>
        public const string CT_CsSalesTarget_SalesTargetMoney  = "売上目標金額";

        /// <summary>売上実績金額(日付別)</summary>
        public const string CT_CsSalesTarget_SalesMoney        = "売上実績金額";

        /// <summary>売上目標粗利額(日付別)</summary>
        public const string CT_CsSalesTarget_SalesTargetProfit = "売上目標粗利";

        /// <summary>売上実績粗利額(日付別)</summary>
        public const string CT_CsSalesTarget_SalesProfit       = "売上実績粗利";

        /// <summary>売上目標数量(日付別)</summary>
        public const string CT_CsSalesTarget_SalesTargetCount  = "売上目標数量";

        /// <summary>売上実績数量(日付別)</summary>
        public const string CT_CsSalesTarget_SalesCount        = "売上実績数量";
*/
        /// <summary>キーブレイク</summary>
        public const string COL_KEYBREAK_AR = "KEYBREAK_AR";
        #endregion 目標売上対比表チャート用カラム情報
        #endregion Public Members

        #region Constructor
        /// <summary>
        /// 目標売上対比表(売上目標金額)チャート用抽出結果データテーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 目標売上対比表(売上目標金額)抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : ネプコ</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>
        public MAMOK02123EB()
        {
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ネプコ</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds)
        {
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(CT_CsSalesTargetDataTable)))
            {
                // TODO:テーブルが存在するときはクリアーするのみ
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[CT_CsSalesTargetDataTable].Clear();
            }
            else
            {
                CreateSalesTarget_MoneyTable(ref ds, 0);

            }

            // バッファデータテーブル------------------------------------------
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(CT_CsSalesTargetBuffDataTable)))
            {
                // TODO:テーブルが存在するときはクリアーするのみ
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[CT_CsSalesTargetBuffDataTable].Clear();
            }
            else
            {
                CreateSalesTarget_MoneyTable(ref ds, 1);
            }
        }
        #endregion Methods

        #region Private Methods

        /// <summary>
        /// 目標売上対比表(売上目標金額)チャート用抽出結果作成処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <param name="buffCheck">バッファチェック</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ネプコ</br>
        /// <br>Date       : 2007.04.19</br>
        /// </remarks>
        private static void CreateSalesTarget_MoneyTable(ref DataSet ds, int buffCheck)
        {
            DataTable dt = null;
            if (buffCheck == 0)
            {
                // スキーマ設定
                ds.Tables.Add(CT_CsSalesTargetDataTable);
                dt = ds.Tables[CT_CsSalesTargetDataTable];
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(CT_CsSalesTargetBuffDataTable);
                dt = ds.Tables[CT_CsSalesTargetBuffDataTable];
            }
/*
            // 適用開始日
            dt.Columns.Add(CT_CsSalesTarget_ApplyStaDate, typeof(String));
            dt.Columns[CT_CsSalesTarget_ApplyStaDate].DefaultValue = "";

            // 売上目標金額
            dt.Columns.Add(CT_CsSalesTarget_SalesTargetMoney, typeof(Int64));
            dt.Columns[CT_CsSalesTarget_SalesTargetMoney].DefaultValue = 0;

            // 売上実績金額
            dt.Columns.Add(CT_CsSalesTarget_SalesMoney, typeof(Int64));
            dt.Columns[CT_CsSalesTarget_SalesMoney].DefaultValue = 0;

            // 売上目標粗利額
            dt.Columns.Add(CT_CsSalesTarget_SalesTargetProfit, typeof(Int64));
            dt.Columns[CT_CsSalesTarget_SalesTargetProfit].DefaultValue = 0;

            // 売上実績粗利額
            dt.Columns.Add(CT_CsSalesTarget_SalesProfit, typeof(Int64));
            dt.Columns[CT_CsSalesTarget_SalesProfit].DefaultValue = 0;

            // 売上目標数量
            dt.Columns.Add(CT_CsSalesTarget_SalesTargetCount, typeof(Double));
            dt.Columns[CT_CsSalesTarget_SalesTargetCount].DefaultValue = 0.0;

            // 売上実績数量
            dt.Columns.Add(CT_CsSalesTarget_SalesCount, typeof(Double));
            dt.Columns[CT_CsSalesTarget_SalesCount].DefaultValue = 0.0;
*/
            // キーブレイク
            dt.Columns.Add(COL_KEYBREAK_AR, typeof(String));
            dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";

            // 適用開始日
            dt.Columns.Add(CT_CsSalesTarget_ApplyStaDate, typeof(String));
            dt.Columns[CT_CsSalesTarget_ApplyStaDate].DefaultValue = "";
        }

        #endregion Methods
    }
}