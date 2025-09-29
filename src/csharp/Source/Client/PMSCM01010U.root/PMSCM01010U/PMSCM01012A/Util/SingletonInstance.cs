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
// 作 成 日  2009/06/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// シングルトン化するクラス
    /// </summary>
    /// <typeparam name="T">シングルトンとするクラスの型</typeparam>
    public class SingletonInstance<T> where T : class, new()
    {
        #region <Singleton Idiom/>

        /// <summary>同期オブジェクト</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>シングルトンインスタンス</summary>
        private static SingletonInstance<T> _singleton;
        /// <summary>
        /// シングルトンインスタンスを取得します。
        /// </summary>
        /// <value>シングルトンインスタンス</value>
        public static SingletonInstance<T> Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    lock (_syncRoot)
                    {
                        if (_singleton == null)
                        {
                            _singleton = new SingletonInstance<T>();
                        }
                    }
                }
                return _singleton;
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private SingletonInstance()
        {
            _instance = new T();
        }

        #endregion  // <Singleton Idiom/>

        /// <summary>シングルトンとするインスタンス</summary>
        private readonly T _instance;
        /// <summary>
        /// シングルトンとするインスタンスを取得します。
        /// </summary>
        /// <value>シングルトンとするインスタンス</value>
        public T Instance { get { return _instance; } }
    }
}
