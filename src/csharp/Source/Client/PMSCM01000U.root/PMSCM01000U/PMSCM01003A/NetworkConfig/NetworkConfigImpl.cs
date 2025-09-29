using System;
using System.Net;

namespace Broadleaf.Application.Controller.NetworkConfig
{
    /// <summary>
    /// ネットワーク設定の実装クラス
    /// </summary>
    public class NetworkConfigImpl : AbstractNetworkConfig
    {
        #region <AbstractNetworkConfig メンバ>

        /// <summary>IPアドレス</summary>
        private readonly string _ipAddress;
        /// <summary>IPアドレスを取得します。</summary>
        /// <see cref="AbstractNetworkConfig"/>
        public override IPAddress IPAddress
        {
            get { return IPAddress.Parse(_ipAddress); }
        }

        /// <summary>ポート番号</summary>
        private readonly int _portNumber;
        /// <summary>ポート番号を取得します。</summary>
        /// <see cref="AbstractNetworkConfig"/>
        public override int PortNumber { get { return _portNumber; } }

        /// <summary>
        /// 初期化します。
        /// </summary>
        /// <see cref="AbstractNetworkConfig"/>
        protected override void Initialize() { }

        #endregion  // </AbstractNetworkConfig メンバ>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="ipAddress">IPアドレス</param>
        /// <param name="portNumber">ポート番号</param>
        public NetworkConfigImpl(string ipAddress, int portNumber) : base()
        {
            _ipAddress = ipAddress;
            _portNumber= portNumber;
        }

        #endregion // </Constructor>
    }
}
