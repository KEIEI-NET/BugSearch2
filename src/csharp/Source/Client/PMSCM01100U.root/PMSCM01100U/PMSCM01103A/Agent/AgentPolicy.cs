//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// 代理人ポリシークラス
    /// </summary>
    /// <typeparam name="TRealAccesser">本物のアクセサの型</typeparam>
    /// <typeparam name="TRecord">レコードの型</typeparam>
    public abstract class AgentPolicy<TRealAccesser, TRecord> where TRealAccesser : new()
    {
        #region <本物のアクセサ>

        /// <summary>本物のアクセサ</summary>
        private TRealAccesser _realAccesser;
        /// <summary>本物のアクセサを取得します。</summary>
        public TRealAccesser RealAccesser
        {
            get
            {
                if (_realAccesser == null)
                {
                    _realAccesser = new TRealAccesser();
                }
                return _realAccesser;
            }
        }

        #endregion // </本物のアクセサ>

        #region <キャッシュ>

        /// <summary>検索済みレコードのマップ</summary>
        private IDictionary<string, TRecord> _foundRecordMap;
        /// <summary>検索済みレコードのマップを取得します。</summary>
        protected IDictionary<string, TRecord> FoundRecordMap
        {
            get
            {
                if (_foundRecordMap == null)
                {
                    _foundRecordMap = new Dictionary<string, TRecord>();
                }
                return _foundRecordMap;
            }
        }

        #endregion // </キャッシュ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected AgentPolicy() { }

        #endregion // </Constructor>
    }
}
