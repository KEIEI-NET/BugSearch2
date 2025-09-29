//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : マスタメンテナンス
// プログラム概要   : マスタメンテナンスの制御全般を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2008/09/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// シングルトン化するクラス
    /// </summary>
    /// <typeparam name="T">シングルトンとするクラス</typeparam>
    public sealed class SingletonPolicy<T> where T : class, new()
    {
        #region <Singleton Idiom/>

        /// <summary>同期オブジェクト</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>シングルトンインスタンス</summary>
        private static SingletonPolicy<T> _instance;
        /// <summary>
        /// シングルトンインスタンスを取得します。
        /// </summary>
        /// <value>シングルトンインスタンス</value>
        public static SingletonPolicy<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonPolicy<T>();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private SingletonPolicy()
        {
            _policy = new T();
        }

        #endregion  // <Singleton Idiom/>

        /// <summary>シングルトンとするインスタンス</summary>
        private readonly T _policy;
        /// <summary>
        /// シングルトンとするインスタンスを取得します。
        /// </summary>
        /// <value>シングルトンとするインスタンス</value>
        public T Policy
        {
            get { return _policy; }
        }
    }

    /// <summary>
    /// 降順の比較者クラス
    /// </summary>
    /// <typeparam name="T">対象オブジェクトの型</typeparam>
    public class ReverseComparer<T> : IComparer<T> where T : IComparable<T>
    {
        #region <IComparer<T> メンバ/>

        /// <summary>
        /// 比較します。
        /// </summary>
        /// <param name="x">左辺</param>
        /// <param name="y">右辺</param>
        /// <returns><c>x.ComapreTo(y) * (-1)</c></returns>
        public int Compare(T x, T y)
        {
            return x.CompareTo(y) * (-1);
        }

        #endregion  // <IComparer<T> メンバ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ReverseComparer() { }

        #endregion  // <Constructor/>
    }
}
