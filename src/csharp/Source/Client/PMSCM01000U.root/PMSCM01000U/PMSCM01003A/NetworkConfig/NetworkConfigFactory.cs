using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller.NetworkConfig
{
    /// <summary>
    /// ネットワーク設定種別列挙体
    /// </summary>
    public enum NetworkConfigType : int
    {
        /// <summary>デフォルト</summary>
        Default,
        /// <summary>XML</summary>
        XML,
        /// <summary>DB</summary>
        DB
    }

    /// <summary>
    /// ネットワーク設定のファクトリクラス
    /// </summary>
    public static class NetworkConfigFactory
    {
        /// <summary>
        /// ネットワーク設定を生成します。
        /// </summary>
        /// <param name="networkConfigType">ネットワーク設定種別</param>
        /// <returns>ネットワーク設定</returns>
        public static INetworkConfig Create(NetworkConfigType networkConfigType)
        {
            switch (networkConfigType)
            {
                case NetworkConfigType.DB:
                    return new DBNetworkConfig();
                case NetworkConfigType.XML:
                    return new XMLNetworkConfig();
                default:
                    return new DefaultNetworkConfig();
            }
        }
    }
}
