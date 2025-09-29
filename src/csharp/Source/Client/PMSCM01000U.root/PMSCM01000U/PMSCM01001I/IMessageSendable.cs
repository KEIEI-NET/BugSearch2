using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// メッセージ送信インターフェース
    /// </summary>
    /// <typeparam name="T">送信する情報の型</typeparam>
    public interface IMessageSendable<T>
    {
        /// <summary>レスポンスを取得します。</summary>
        T Response { get; }

        /// <summary>
        /// 送信します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        void Send(T message);

        /// <summary>
        /// 切断します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        void Disconnect();
    }

    /// <summary>
    /// テキストメッセージ送信インターフェース
    /// </summary>
    public interface ITextMessageSendable : IMessageSendable<string> { }
}
