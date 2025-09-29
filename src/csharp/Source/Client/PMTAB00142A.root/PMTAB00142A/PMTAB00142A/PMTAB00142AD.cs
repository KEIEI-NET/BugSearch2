//**********************************************************************//
// システム         ：PM.NS
// プログラム名称   ：PMTAB 自動回答処理(検索) テーブルアクセスクラス
// プログラム概要   ：PMTAB常駐処理よりパラメータで車両、部品検索条件が渡される
//                    車両、部品検索条件より車両、部品の検索を行い、
//                    取得した情報をSCM_DBの検索結果関連のテーブルに書込む
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
//----------------------------------------------------------------------//
// 管理番号  10902622-01  作成担当 : songg
// 作 成 日  2013/05/29   作成内容 : PMTAB 自動回答処理(検索)
//----------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// シングルトン化するクラス
    /// </summary>
    /// <typeparam name="T">シングルトンとするクラスの型</typeparam>
    public class SingletonInstanceForTablet<T> where T : class, new()
    {
        #region <Singleton Idiom/>

        /// <summary>同期オブジェクト</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>シングルトンインスタンス</summary>
        private static SingletonInstanceForTablet<T> _singleton;
        /// <summary>
        /// シングルトンインスタンスを取得します。
        /// </summary>
        /// <value>シングルトンインスタンス</value>
        public static SingletonInstanceForTablet<T> Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    lock (_syncRoot)
                    {
                        if (_singleton == null)
                        {
                            _singleton = new SingletonInstanceForTablet<T>();
                        }
                    }
                }
                return _singleton;
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private SingletonInstanceForTablet()
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
