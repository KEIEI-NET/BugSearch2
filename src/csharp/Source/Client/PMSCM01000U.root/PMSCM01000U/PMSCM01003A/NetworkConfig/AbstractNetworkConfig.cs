using System;
using System.Net;

using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller.NetworkConfig
{
    /// <summary>
    /// 抽象ネットワーク設定クラス
    /// </summary>
    public abstract class AbstractNetworkConfig : INetworkConfig
    {
        #region <INetworkConfig メンバ>

        /// <summary>
        /// IPアドレスを取得します。
        /// </summary>
        /// <see cref="INetworkConfig"/>
        public abstract IPAddress IPAddress { get; }

        /// <summary>
        /// ポート番号を取得します。
        /// </summary>
        /// <see cref="INetworkConfig"/>
        public abstract int PortNumber { get; }

        #endregion // </INetworkConfig メンバ>

        #region <IAgreegate<INetworkConfig> メンバ>

        /// <summary>
        /// サイズを取得します。
        /// </summary>
        /// <value>サイズ</value>
        public int Size
        {
            get { return ConfigAgreegate.Size; }
        }

        /// <summary>
        /// 要素を全て削除します。
        /// </summary>
        public void Clear()
        {
            ConfigAgreegate.Clear();
        }

        /// <summary>
        /// 要素を追加します。
        /// </summary>
        /// <param name="item">要素</param>
        public void Add(INetworkConfig item)
        {
            ConfigAgreegate.Add(item);
        }

        /// <summary>
        /// 要素を削除します。
        /// </summary>
        /// <param name="item">要素</param>
        public void Remove(INetworkConfig item)
        {
            ConfigAgreegate.Remove(item);
        }

        /// <summary>
        /// インデックスに対応する要素を取得します。
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>インデックスに対応する要素</returns>
        public INetworkConfig GetAt(int index)
        {
            return ConfigAgreegate.GetAt(index);
        }

        /// <summary>
        /// 反復子を生成します。
        /// </summary>
        /// <returns>反復子</returns>
        public IIterator<INetworkConfig> CreateIterator()
        {
            return ConfigAgreegate.CreateIterator();
        }

        #endregion // </IAgreegate<INetworkConfig> メンバ>

        #region <設定の集合体>

        /// <summary>設定の集合体</summary>
        private readonly SimpleAgreegate<INetworkConfig> _configAgreegate = new SimpleAgreegate<INetworkConfig>();
        /// <summary>設定の集合体を取得します。</summary>
        private SimpleAgreegate<INetworkConfig> ConfigAgreegate { get { return _configAgreegate; } }

        #endregion // </設定の集合体>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected AbstractNetworkConfig()
        {
            Initialize();
        }

        #endregion // </Constructor>

        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>該当するネットワーク設定</returns>
        public INetworkConfig this[int index]
        {
            get { return ConfigAgreegate[index]; }
            set { ConfigAgreegate[index] = value; }
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        protected abstract void Initialize();
    }
}
