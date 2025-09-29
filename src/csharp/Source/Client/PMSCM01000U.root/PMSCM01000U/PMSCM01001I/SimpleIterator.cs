using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 簡易反復子クラス
    /// </summary>
    /// <typeparam name="T">反復子の型</typeparam>
    public class SimpleIterator<T> : IIterator<T> where T : class
    {
        #region <IIterator<T> メンバ>

        /// <summary>
        /// 次の反復子があるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :あり<br/>
        /// <c>false</c>:なし
        /// </returns>
        public bool HasNext()
        {
            return _nextIndex < Agreegate.Size;
        }

        /// <summary>
        /// 次の反復子を取得します。
        /// </summary>
        /// <returns>次の反復子</returns>
        public T GetNext()
        {
            return Agreegate.GetAt(_nextIndex++);
        }

        #endregion // </IIterator<T> メンバ>

        #region <集合体>

        /// <summary>集合体</summary>
        private readonly IAgreegate<T> _agreegate;
        /// <summary>集合体を取得します。</summary>
        protected IAgreegate<T> Agreegate { get { return _agreegate; } }

        #endregion // </集合体>

        /// <summary>次の要素のインデックス</summary>
        protected int _nextIndex;

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="agreegate">集合体</param>
        public SimpleIterator(IAgreegate<T> agreegate)
        {
            _agreegate = agreegate;
        }

        #endregion  // <Constructor/>
    }
}
