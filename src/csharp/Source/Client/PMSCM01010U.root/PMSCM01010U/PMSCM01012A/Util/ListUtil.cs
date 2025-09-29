//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/07/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// リストユーティリティ
    /// </summary>
    public static class ListUtil
    {
        /// <summary>
        /// <c>null</c>または空であるか判断します。
        /// </summary>
        /// <typeparam name="T">項目の型</typeparam>
        /// <param name="list">リスト</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>または空です。<br/>
        /// <c>false</c>:項目を持ちます。
        /// </returns>
        public static bool IsNullOrEmpty<T>(ICollection<T> list)
        {
            return list == null || list.Count.Equals(0);
        }

        /// <summary>
        /// <c>null</c>または空であるか判断します。
        /// </summary>
        /// <remarks>
        /// <c>ICollection</c>のスペシャルバージョン
        /// </remarks>
        /// <param name="collection">リスト</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>または空です。<br/>
        /// <c>false</c>:項目を持ちます。
        /// </returns>
        public static bool IsNullOrEmpty(ICollection collection)
        {
            return collection == null || collection.Count.Equals(0);
        }

        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        /// <summary>
        /// <c>null</c>または空であるか判断します。
        /// </summary>
        /// <remarks>
        /// <c>List&lt;T&gt;</c>のスペシャルバージョン
        /// </remarks>
        /// <param name="list">リスト</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>または空です。<br/>
        /// <c>false</c>:項目を持ちます。
        /// </returns>
        public static bool IsNullOrEmpty<T>(List<T> list)
        {
            return list == null || list.Count.Equals(0);
        }
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

        /// <summary>
        /// コレクションから特定のクラスを検索します。
        /// </summary>
        /// <typeparam name="T">検索するクラスの型</typeparam>
        /// <param name="collection">コレクション</param>
        /// <returns>最初に検索されたクラス ※該当クラスが存在しない場合、<c>null</c>を返します。</returns>
        public static T FindFirstFrom<T>(ICollection collection) where T : class
        {
            foreach (object item in collection)
            {
                if (item is T) return (T)item;
            }
            return null;
        }

        /// <summary>
        /// コレクションから特定のクラスを検索します。
        /// </summary>
        /// <typeparam name="T">検索するクラスの型</typeparam>
        /// <param name="collection">コレクション</param>
        /// <returns>検索されたクラスのリスト</returns>
        public static IList<T> FindFrom<T>(ICollection collection) where T : class
        {
            IList<T> foundList = new List<T>();
            {
                foreach (object item in collection)
                {
                    if (item is T) foundList.Add((T)item);
                }
            }
            return foundList;
        }
    }
}
