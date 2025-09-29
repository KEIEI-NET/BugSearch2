//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定UI：操作権限設定マスタ
// プログラム概要   : フォームコントロールに関する共通処理を実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 値のペアクラス
    /// </summary>
    /// <typeparam name="TFirst">1番目の値の型</typeparam>
    /// <typeparam name="TSecond">2番目の値の型</typeparam>
    public class Pair<TFirst, TSecond>
    {
        /// <summary>1番目の値</summary>
        private readonly TFirst _first;
        /// <summary>
        /// 1番目の値を取得します。
        /// </summary>
        /// <value>1番目の値</value>
        public TFirst First { get { return _first; } }

        /// <summary>2番目の値を取得します。</summary>
        private readonly TSecond _second;
        /// <summary>
        /// 2番目の値を取得します。
        /// </summary>
        /// <value>2番目の値</value>
        public TSecond Second { get { return _second; } }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="first">1番目の値</param>
        /// <param name="second">2番目の値</param>
        public Pair(
            TFirst first,
            TSecond second
        )
        {
            _first = first;
            _second = second;
        }

        #region <object override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return First.ToString() + "," + Second.ToString();
        }

        #endregion  // <object override/>
    }

    #region <Special Version/>

    /// <summary>
    /// コードと名称のペアクラス
    /// </summary>
    /// <typeparam name="TCode">コードの型</typeparam>
    public class CodeNamePair<TCode> : Pair<TCode, string>
    {
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="code">コード</param>
        /// <param name="name">名称</param>
        public CodeNamePair(
            TCode code,
            string name
        ) : base(code, name)
        {}

        /// <summary>
        /// コードを取得します。
        /// </summary>
        /// <value>コード</value>
        public TCode Code { get { return base.First; } }

        /// <summary>
        /// 名称を取得します。
        /// </summary>
        /// <value>名称</value>
        public string Name { get { return base.Second; } }

        #region <object override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion  // <object override/>
    }

    /// <summary>
    /// キーと値のペアクラス
    /// </summary>
    /// <typeparam name="TValue">値の型</typeparam>
    public class KeyValuePair<TValue> : Pair<string, TValue>
    {
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="val">値</param>
        public KeyValuePair(
            string key,
            TValue val
        ) : base(key, val)
        {}

        /// <summary>
        /// キーを取得します。
        /// </summary>
        /// <value>キー</value>
        public string Key { get { return base.First; } }

        /// <summary>
        /// 値を取得します。
        /// </summary>
        /// <value>値</value>
        public TValue Value { get { return base.Second; } }
    }

    #endregion  // <Special Version/>
}
