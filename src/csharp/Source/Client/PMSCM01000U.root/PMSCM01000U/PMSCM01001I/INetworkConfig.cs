using System;
using System.Net;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ネットワーク設定インターフェース
    /// </summary>
    public interface INetworkConfig : IAgreegate<INetworkConfig>
    {
        /// <summary>
        /// IPアドレスを取得します。
        /// </summary>
        IPAddress IPAddress { get; }

        /// <summary>
        /// ポート番号を取得します。
        /// </summary>
        int PortNumber { get; }
    }
}
