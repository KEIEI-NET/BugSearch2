//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限取得部品
// プログラム概要   : ADO.NET関連の共通処理を実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Data;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ADO.NETのユーティリティ
    /// </summary>
    public static class ADOUtil
    {
        /// <summary>=キーワード</summary>
        public const string EQ = "=";

        /// <summary>＜＞キーワード</summary>
        public const string NOT_EQ = "<>";

        /// <summary>ANDキーワード</summary>
        public const string AND = " AND ";

        /// <summary>ORキーワード</summary>
        public const string OR = " OR ";

        /// <summary>降順のキーワード</summary>
        public const string DESC = " DESC";

        /// <summary>カンマキーワード</summary>
        public const string COMMA = ",";

        /// <summary>LIKEキーワード</summary>
        public const string LIKE = " LIKE ";

        /// <summary>ワイルドカードキーワード</summary>
        public const string WILD = "%";

        /// <summary>≧キーワード</summary>
        public const string LARGE_EQ = ">=";

        /// <summary>＞キーワード</summary>
        public const string LARGE = ">";

        /// <summary>≦キーワード</summary>
        public const string LESS_EQ = "<=";

        /// <summary>＜キーワード</summary>
        public const string LESS = "<";

        /// <summary>NOTキーワード</summary>
        public const string NOT = "<>";

        /// <summary>(キーワード</summary>
        public const string BEGIN_BLOCK = "(";

        /// <summary>)キーワード</summary>
        public const string END_BLOCK = ")";

        /// <summary>
        /// SQLの文字列値表記を取得します。
        /// </summary>
        /// <param name="val">文字列値</param>
        /// <returns>SQLの文字列値表記</returns>
        public static string GetString(string val)
        {
            return "'" + val + "'";
        }

        /// <summary>
        /// SQLの文字列値表記を取得します。
        /// </summary>
        /// <param name="number">数値</param>
        /// <returns>SQLの文字列値表記</returns>
        public static string GetString(int number)
        {
            return GetString(number.ToString());
        }

        /// <summary>
        /// SQLのワールドカード付き文字列表記を取得します。
        /// </summary>
        /// <param name="val">文字列値</param>
        /// <returns>SQLのワールドカード付き文字列表記</returns>
        public static string GetWild(string val)
        {
            return GetString(WILD + val + WILD);
        }

        /// <summary>
        /// DataRowの配列からDataTableを生成します。
        /// </summary>
        /// <typeparam name="TDataTable">DataTableの型</typeparam>
        /// <param name="dataRows">DataRowの配列</param>
        /// <returns>新しいDataTableのインスタンス</returns>
        public static TDataTable CreateDataTable<TDataTable>(DataRow[] dataRows) where TDataTable : DataTable, new()
        {
            TDataTable dataTable = new TDataTable();
            foreach (DataRow dataRow in dataRows)
            {
                dataTable.Rows.Add(dataRow.ItemArray);
            }
            return dataTable;
        }

        /// <summary>
        /// DataRow配列を型付きDataRow配列に変換します。
        /// </summary>
        /// <typeparam name="TDataRow">型付きDataRowの型</typeparam>
        /// <param name="dataRows">DataRow配列</param>
        /// <returns>型付きDataRow配列</returns>
        public static TDataRow[] ConvertAll<TDataRow>(DataRow[] dataRows) where TDataRow : DataRow
        {
            return Array.ConvertAll<DataRow, TDataRow>(dataRows, delegate(DataRow dataRow) { return (TDataRow)dataRow; });
        }
    }
}
