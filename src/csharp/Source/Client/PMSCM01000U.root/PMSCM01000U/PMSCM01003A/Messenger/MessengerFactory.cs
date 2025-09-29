using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.NetworkConfig;

namespace Broadleaf.Application.Controller.Messenger
{
    /// <summary>
    /// プロトコル種別列挙体
    /// </summary>
    public enum ProtcolType : int
    {
        /// <summary>TCP</summary>
        TCP
    }

    /// <summary>
    /// メッセンジャーファクトリクラス
    /// </summary>
    public static class MessengerFactory
    {
        /// <summary>
        /// テキストメッセージの受信者を生成します。
        /// </summary>
        /// <param name="protocolType">プロトコル種別</param>
        /// <param name="networkConfigType">ネットワーク設定種別</param>
        /// <returns>メッセージの受信者</returns>
        public static ITextMessageReceivable CreateTextReceiver(
            ProtcolType protocolType,
            INetworkConfig iNetworkConfig
        )
        {
            switch (protocolType)
            {
                default:
                    return new TCPMessageReceiver(iNetworkConfig);
            }
        }

        /// <summary>
        /// テキストメッセージの送信者を生成します。
        /// </summary>
        /// <param name="protocolType">プロトコル種別</param>
        /// <param name="address">アドレス</param>
        /// <param name="port">ポート</param>
        /// <returns>メッセージの送信者</returns>
        public static ITextMessageSendable CreateTextSender(
            ProtcolType protocolType,
            string address,
            int port
        )
        {
            switch (protocolType)
            {
                default:
                    return new TCPMessageSender(address, port);
            }
        }
    }
}
