//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定アクセス
// プログラム概要   : DBアクセスのアクセス結果を保持します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// DBアクセスクラスの代理人クラス
    /// </summary>
    /// <typeparam name="TDBAccess">DBのアクセスクラスの型</typeparam>
    /// <typeparam name="TDBRecord">DBのレコードクラスの型</typeparam>
    /// <typeparam name="TDataSet">DBのデータセットの型</typeparam>
    public abstract class DBAccessAgent<
        TDBAccess,
        TDBRecord,
        TDataSet
    > : IDisposable   
        where TDBAccess : class, new()
        where TDBRecord : class, new()
        where TDataSet  : DataSet, new()
    {
        #region <IDisposable Member/>

        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        /// <summary>
        /// 処分済みフラグを取得します。
        /// </summary>
        public bool Disposed { get { return _disposed; } }

        /// <summary>
        /// 処分します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトの処分フラグ</param>
        protected virtual void Dispose(bool disposing)
        {
            #region <Guard Phrase/>

            if (Disposed) return;

            #endregion  // <Guard Phrase/>

            // ↓マネージオブジェクト
            if (disposing)
            {
                Reset();
            }
            // ↓アンマネージオブジェクト
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~DBAccessAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        /// <summary>DBのアクセサ</summary>
        private TDBAccess _realAccesser;
        /// <summary>
        /// DBのアクセサを取得します。
        /// </summary>
        /// <value>DBのアクセサ</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public TDBAccess RealAccesser
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_realAccesser == null)
                {
                    _realAccesser = new TDBAccess();
                }
                return _realAccesser;
            }
        }

        /// <summary>DBのレコードリスト</summary>
        private List<TDBRecord> _recordList;
        /// <summary>
        /// DBのレコードを取得します。
        /// </summary>
        /// <value>DBのレコードリスト</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public List<TDBRecord> RecordList
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_recordList == null)
                {
                    _recordList = new List<TDBRecord>();
                    Initialize();
                }
                return _recordList;
            }
        }

        /// <summary>DBのデータセット</summary>
        private TDataSet _db;
        /// <summary>
        /// DBのデータセットを取得します。
        /// </summary>
        /// <value>DBのデタセット</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public TDataSet DB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_db == null)
                {
                    _db = new TDataSet();
                    if (_recordList == null)
                    {
                        _recordList = new List<TDBRecord>();
                        Initialize();
                    }
                }
                return _db;
            }
        }

        /// <summary>
        /// リセットします。
        /// </summary>
        public void Reset()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
            if (_recordList != null)
            {
                _recordList.Clear();
                _recordList = null;
            }
            _realAccesser = null;
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected DBAccessAgent() { }

        /// <summary>
        /// 初期化します。
        /// </summary>
        protected abstract void Initialize();
    }
}
