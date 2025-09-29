//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ印刷用テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宋剛
// 作 成 日  2013/02/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 掛率マスタ印刷用テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ印刷用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 宋剛</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    public class PMKHN09903EC
    {
        #region ■ Public Const

        public const string ct_Tbl_ReportData = "Tbl_ReportData"; // テーブル名称

        public const int CNTPERPAGE = 31;                          // PDFページで最大表示明細件数

        public const string ct_Col_Col1HeadValue = "Col1HeadValue"; // 商品掛率G or 層別
        public const string ct_Col_Col1ShowValue = "Col1ShowValue"; // 表示用データ
        public const string ct_Col_Col1HideValue = "Col1HideValue"; // 設定用データ
        public const string ct_Col_Col2ShowGlcd = "Col2ShowGlcd"; // 表示用BLコードＧ
        public const string ct_Col_Col2HideGlcd = "Col2HideGlcd"; // 設定用BLコードＧ
        public const string ct_Col_Col2Name = "Col2Name"; // 名称（商品掛率G名称）
        public const string ct_Col_Col3Blcd = "Col3Blcd"; // BLコード
        public const string ct_Col_Col3GlcdName = "Col3GlcdName"; // BLコードＧ名称
        public const string ct_Col_Col4BLCodeName = "Col4BLCodeName"; // BLコード名称
        public const string ct_Col_Col5Maker = "Col5Maker"; // メーカー
        public const string ct_Col_Col6CostRate = "Col6CostRate"; // 仕入率
        public const string ct_Col_Col7All = "Col7All"; // All
        public const string ct_Col_Row1Name = "Row1Name"; // 名称（売価率/原価UP率/粗利確保率）
        public const string ct_Col_Col1InputHeadName = "Col1InputHeadName"; // ヘッダ部1コラム入力条件情報
        public const string ct_Col_Col2InputHeadName = "Col2InputHeadName"; // ヘッダ部2コラム入力条件情報
        public const string ct_Col_Col3InputHeadName = "Col3InputHeadName"; // ヘッダ部3コラム入力条件情報
        public const string ct_Col_Col4InputHeadName = "Col4InputHeadName"; // ヘッダ部4コラム入力条件情報
        public const string ct_Col_Col5InputHeadName = "Col5InputHeadName"; // ヘッダ部5コラム入力条件情報
        public const string ct_Col_Col6InputHeadName = "Col6InputHeadName"; // ヘッダ部6コラム入力条件情報
        public const string ct_Col_Col7InputHeadName = "Col7InputHeadName"; // ヘッダ部7コラム入力条件情報
        public const string ct_Col_Col8InputHeadName = "Col8InputHeadName"; // ヘッダ部8コラム入力条件情報
        public const string ct_Col_Col9InputHeadName = "Col9InputHeadName"; // ヘッダ部9コラム入力条件情報
        public const string ct_Col_Col10InputHeadName = "Col10InputHeadName"; // ヘッダ部10コラム入力条件情報
        public const string ct_Col_Col11InputHeadName = "Col11InputHeadName"; // ヘッダ部11コラム入力条件情報
        public const string ct_Col_Col12InputHeadName = "Col12InputHeadName"; // ヘッダ部12コラム入力条件情報
        public const string ct_Col_Col13InputHeadName = "Col13InputHeadName"; // ヘッダ部13コラム入力条件情報
        public const string ct_Col_Col14InputHeadName = "Col14InputHeadName"; // ヘッダ部14コラム入力条件情報
        public const string ct_Col_Col15InputHeadName = "Col15InputHeadName"; // ヘッダ部15コラム入力条件情報
        public const string ct_Col_Col16InputHeadName = "Col16InputHeadName"; // ヘッダ部16コラム入力条件情報
        public const string ct_Col_Col17InputHeadName = "Col17InputHeadName"; // ヘッダ部17コラム入力条件情報
        public const string ct_Col_Col18InputHeadName = "Col18InputHeadName"; // ヘッダ部18コラム入力条件情報
        public const string ct_Col_Col19InputHeadName = "Col19InputHeadName"; // ヘッダ部19コラム入力条件情報
        public const string ct_Col_Col20InputHeadName = "Col20InputHeadName"; // ヘッダ部20コラム入力条件情報
        public const string ct_Col_Col1InputValue = "Col1InputValue"; // 1コラム入力データ
        public const string ct_Col_Col2InputValue = "Col2InputValue"; // 2コラム入力データ
        public const string ct_Col_Col3InputValue = "Col3InputValue"; // 3コラム入力データ
        public const string ct_Col_Col4InputValue = "Col4InputValue"; // 4コラム入力データ
        public const string ct_Col_Col5InputValue = "Col5InputValue"; // 5コラム入力データ
        public const string ct_Col_Col6InputValue = "Col6InputValue"; // 6コラム入力データ
        public const string ct_Col_Col7InputValue = "Col7InputValue"; // 7コラム入力データ
        public const string ct_Col_Col8InputValue = "Col8InputValue"; // 8コラム入力データ
        public const string ct_Col_Col9InputValue = "Col9InputValue"; // 9コラム入力データ
        public const string ct_Col_Col10InputValue = "Col10InputValue"; // 10コラム入力データ
        public const string ct_Col_Col11InputValue = "Col11InputValue"; // 11コラム入力データ
        public const string ct_Col_Col12InputValue = "Col12InputValue"; // 12コラム入力データ
        public const string ct_Col_Col13InputValue = "Col13InputValue"; // 13コラム入力データ
        public const string ct_Col_Col14InputValue = "Col14InputValue"; // 14コラム入力データ
        public const string ct_Col_Col15InputValue = "Col15InputValue"; // 15コラム入力データ
        public const string ct_Col_Col16InputValue = "Col16InputValue"; // 16コラム入力データ
        public const string ct_Col_Col17InputValue = "Col17InputValue"; // 17コラム入力データ
        public const string ct_Col_Col18InputValue = "Col18InputValue"; // 18コラム入力データ
        public const string ct_Col_Col19InputValue = "Col19InputValue"; // 19コラム入力データ
        public const string ct_Col_Col20InputValue = "Col20InputValue"; // 20コラム入力データ

        public const string ct_Col_Col1InputHeadNm = "Col1InputHeadNm"; // ヘッダ部1コラム入力条件の名称情報
        public const string ct_Col_Col2InputHeadNm = "Col2InputHeadNm"; // ヘッダ部2コラム入力条件の名称情報
        public const string ct_Col_Col3InputHeadNm = "Col3InputHeadNm"; // ヘッダ部3コラム入力条件の名称情報
        public const string ct_Col_Col4InputHeadNm = "Col4InputHeadNm"; // ヘッダ部4コラム入力条件の名称情報
        public const string ct_Col_Col5InputHeadNm = "Col5InputHeadNm"; // ヘッダ部5コラム入力条件の名称情報
        public const string ct_Col_Col6InputHeadNm = "Col6InputHeadNm"; // ヘッダ部6コラム入力条件の名称情報
        public const string ct_Col_Col7InputHeadNm = "Col7InputHeadNm"; // ヘッダ部7コラム入力条件の名称情報
        public const string ct_Col_Col8InputHeadNm = "Col8InputHeadNm"; // ヘッダ部8コラム入力条件の名称情報
        public const string ct_Col_Col9InputHeadNm = "Col9InputHeadNm"; // ヘッダ部9コラム入力条件の名称情報
        public const string ct_Col_Col10InputHeadNm = "Col10InputHeadNm"; // ヘッダ部10コラム入力条件の名称情報
        public const string ct_Col_Col11InputHeadNm = "Col11InputHeadNm"; // ヘッダ部11コラム入力条件の名称情報
        public const string ct_Col_Col12InputHeadNm = "Col12InputHeadNm"; // ヘッダ部12コラム入力条件の名称情報
        public const string ct_Col_Col13InputHeadNm = "Col13InputHeadNm"; // ヘッダ部13コラム入力条件の名称情報
        public const string ct_Col_Col14InputHeadNm = "Col14InputHeadNm"; // ヘッダ部14コラム入力条件の名称情報
        public const string ct_Col_Col15InputHeadNm = "Col15InputHeadNm"; // ヘッダ部15コラム入力条件の名称情報
        public const string ct_Col_Col16InputHeadNm = "Col16InputHeadNm"; // ヘッダ部16コラム入力条件の名称情報
        public const string ct_Col_Col17InputHeadNm = "Col17InputHeadNm"; // ヘッダ部17コラム入力条件の名称情報
        public const string ct_Col_Col18InputHeadNm = "Col18InputHeadNm"; // ヘッダ部18コラム入力条件の名称情報
        public const string ct_Col_Col19InputHeadNm = "Col19InputHeadNm"; // ヘッダ部19コラム入力条件の名称情報
        public const string ct_Col_Col20InputHeadNm = "Col20InputHeadNm"; // ヘッダ部20コラム入力条件の名称情報
        #endregion

        #region ■ Static Public Method
        #region ◆ 掛率マスタ印刷DataSetテーブルスキーマ設定
        /// <summary>
        /// 掛率マスタ印刷DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタ印刷データセットのスキーマを設定する。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_ReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_ReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_ReportData);

                DataTable dt = ds.Tables[ct_Tbl_ReportData];

                dt.Columns.Add(ct_Col_Col1HeadValue, typeof(string));
                dt.Columns[ct_Col_Col1HeadValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col1ShowValue, typeof(string));
                dt.Columns[ct_Col_Col1ShowValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col1HideValue, typeof(string));
                dt.Columns[ct_Col_Col1HideValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2ShowGlcd, typeof(string));
                dt.Columns[ct_Col_Col2ShowGlcd].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2HideGlcd, typeof(string));
                dt.Columns[ct_Col_Col2HideGlcd].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2Name, typeof(string));
                dt.Columns[ct_Col_Col2Name].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3Blcd, typeof(string));
                dt.Columns[ct_Col_Col3Blcd].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3GlcdName, typeof(string));
                dt.Columns[ct_Col_Col3GlcdName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col4BLCodeName, typeof(string));
                dt.Columns[ct_Col_Col4BLCodeName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col5Maker, typeof(string));
                dt.Columns[ct_Col_Col5Maker].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col6CostRate, typeof(string));
                dt.Columns[ct_Col_Col6CostRate].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col7All, typeof(string));
                dt.Columns[ct_Col_Col7All].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Row1Name, typeof(string));
                dt.Columns[ct_Col_Row1Name].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col1InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col1InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col2InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col3InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col4InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col4InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col5InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col5InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col6InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col6InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col7InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col7InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col8InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col8InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col9InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col9InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col10InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col10InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col11InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col11InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col12InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col12InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col13InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col13InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col14InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col14InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col15InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col15InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col16InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col16InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col17InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col17InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col18InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col18InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col19InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col19InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col20InputHeadName, typeof(string));
                dt.Columns[ct_Col_Col20InputHeadName].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col1InputValue, typeof(string));
                dt.Columns[ct_Col_Col1InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2InputValue, typeof(string));
                dt.Columns[ct_Col_Col2InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3InputValue, typeof(string));
                dt.Columns[ct_Col_Col3InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col4InputValue, typeof(string));
                dt.Columns[ct_Col_Col4InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col5InputValue, typeof(string));
                dt.Columns[ct_Col_Col5InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col6InputValue, typeof(string));
                dt.Columns[ct_Col_Col6InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col7InputValue, typeof(string));
                dt.Columns[ct_Col_Col7InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col8InputValue, typeof(string));
                dt.Columns[ct_Col_Col8InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col9InputValue, typeof(string));
                dt.Columns[ct_Col_Col9InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col10InputValue, typeof(string));
                dt.Columns[ct_Col_Col10InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col11InputValue, typeof(string));
                dt.Columns[ct_Col_Col11InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col12InputValue, typeof(string));
                dt.Columns[ct_Col_Col12InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col13InputValue, typeof(string));
                dt.Columns[ct_Col_Col13InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col14InputValue, typeof(string));
                dt.Columns[ct_Col_Col14InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col15InputValue, typeof(string));
                dt.Columns[ct_Col_Col15InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col16InputValue, typeof(string));
                dt.Columns[ct_Col_Col16InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col17InputValue, typeof(string));
                dt.Columns[ct_Col_Col17InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col18InputValue, typeof(string));
                dt.Columns[ct_Col_Col18InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col19InputValue, typeof(string));
                dt.Columns[ct_Col_Col19InputValue].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col20InputValue, typeof(string));
                dt.Columns[ct_Col_Col20InputValue].DefaultValue = string.Empty;



                dt.Columns.Add(ct_Col_Col1InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col1InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col2InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col2InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col3InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col3InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col4InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col4InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col5InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col5InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col6InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col6InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col7InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col7InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col8InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col8InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col9InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col9InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col10InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col10InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col11InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col11InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col12InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col12InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col13InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col13InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col14InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col14InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col15InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col15InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col16InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col16InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col17InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col17InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col18InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col18InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col19InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col19InputHeadNm].DefaultValue = string.Empty;

                dt.Columns.Add(ct_Col_Col20InputHeadNm, typeof(string));
                dt.Columns[ct_Col_Col20InputHeadNm].DefaultValue = string.Empty;
                

            }
        }
        #endregion
        #endregion
    }
}
