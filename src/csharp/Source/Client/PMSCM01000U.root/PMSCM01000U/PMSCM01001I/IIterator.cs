using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 反復子インターフェース
    /// </summary>
    /// <typeparam name="T">反復子の型</typeparam>
    public interface IIterator<T> where T : class
    {
        /// <summary>
        /// 次の反復子があるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :あり<br/>
        /// <c>false</c>:なし
        /// </returns>
        bool HasNext();

        /// <summary>
        /// 次の反復子を取得します。
        /// </summary>
        /// <returns>次の反復子</returns>
        T GetNext();
    }
}
