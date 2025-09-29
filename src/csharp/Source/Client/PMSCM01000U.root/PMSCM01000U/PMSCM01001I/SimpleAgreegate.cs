using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 簡易集合体クラス
    /// </summary>
    /// <typeparam name="T">集合体の要素の型</typeparam>
    public class SimpleAgreegate<T> : IAgreegate<T> where T : class
    {
        #region <IAgreegate<T> メンバ>

        /// <summary>
        /// サイズを取得します。
        /// </summary>
        /// <value>サイズ</value>
        public int Size
        {
            get { return ItemList.Count; }
        }

        /// <summary>
        /// 要素を全て削除します。
        /// </summary>
        public void Clear()
        {
            ItemList.Clear();
        }

        /// <summary>
        /// 要素を追加します。
        /// </summary>
        /// <param name="item">要素</param>
        public void Add(T item)
        {
            ItemList.Add(item);
        }

        /// <summary>
        /// 要素を削除します。
        /// </summary>
        /// <param name="item">要素</param>
        public void Remove(T item)
        {
            ItemList.Remove(item);
        }

        /// <summary>
        /// インデックスに対応する要素を取得します。
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>インデックスに対応する要素</returns>
        public T GetAt(int index)
        {
            return this[index];
        }

        /// <summary>
        /// 反復子を生成します。
        /// </summary>
        /// <returns>反復子</returns>
        public IIterator<T> CreateIterator()
        {
            return new SimpleIterator<T>(this);
        }

        #endregion // </IAgreegate<T> メンバ>

        #region <要素リスト>

        /// <summary>要素リスト</summary>
        private readonly IList<T> _itemList = new List<T>();
        /// <summary>要素リストを取得します。</summary>
        protected IList<T> ItemList { get { return _itemList; } }

        #endregion // </要素リスト>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SimpleAgreegate() { }

        #endregion // </Constructor>

        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>該当する要素</returns>
        public T this[int index]
        {
            get { return ItemList[index]; }
            set { ItemList[index] = value; }
        }
    }
}
