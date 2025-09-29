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
// 作 成 日  2009/06/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// IList&lt;T&gt;の反復子クラス
    /// </summary>
    public class ListIterator<T> : IIterator<T> where T : class
    {
        #region <IIterator<T> メンバ>

        /// <summary>
        /// 次の反復子を取得します。
        /// </summary>
        /// <returns>次の反復子</returns>
        public T GetNext()
        {
            return Agreegate[_nextIndex++];
        }

        /// <summary>
        /// 次の反復子があるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :あり<br/>
        /// <c>false</c>:なし
        /// </returns>
        public bool HasNext()
        {
            return _nextIndex < Agreegate.Count;
        }

        #endregion // </IIterator<T> メンバ>

        #region <集合体>

        /// <summary>集合体</summary>
        private readonly IList<T> _agreegate;
        /// <summary>集合体を取得します。</summary>
        private IList<T> Agreegate { get { return _agreegate; } }

        /// <summary>次のインデックス</summary>
        private int _nextIndex;

        #endregion // </集合体>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="agreegate">集合体</param>
        public ListIterator(IList<T> agreegate)
        {
            _agreegate = agreegate;
        }

        #endregion // </Constructor>
    }
}
