using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 集合体インターフェース
    /// </summary>
    /// <typeparam name="T">集合体の要素の型</typeparam>
    public interface IAgreegate<T> where T : class
    {
        /// <summary>
        /// サイズを取得します。
        /// </summary>
        /// <value>サイズ</value>
        int Size { get; }

        /// <summary>
        /// 要素を全て削除します。
        /// </summary>
        void Clear();

        /// <summary>
        /// 要素を追加します。
        /// </summary>
        /// <param name="item">要素</param>
        void Add(T item);

        /// <summary>
        /// 要素を削除します。
        /// </summary>
        /// <param name="item">要素</param>
        void Remove(T item);

        /// <summary>
        /// インデックスに対応する要素を取得します。
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>インデックスに対応する要素</returns>
        T GetAt(int index);

        /// <summary>
        /// 反復子を生成します。
        /// </summary>
        /// <returns>反復子</returns>
        IIterator<T> CreateIterator();
    }
}
