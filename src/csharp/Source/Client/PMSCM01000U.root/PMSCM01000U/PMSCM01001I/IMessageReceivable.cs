using System;

namespace Broadleaf.Application.Common
{
    #region <受信イベント>

    /// <summary>
    /// 受信イベントパラメータクラス
    /// </summary>
    public class ReceivedEventArgs : EventArgs
    {
        #region <テキスト>

        /// <summary>テキスト</summary>
        private string _text;
        /// <summary>テキストのアクセサ</summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        #endregion // </テキスト>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="text">テキスト</param>
        public ReceivedEventArgs(string text)
        {
            _text = text;
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ReceivedEventArgs() : this(string.Empty) { }

        #endregion // </Constructor>
    }

    /// <summary>
    /// 受信イベントハンドラデリゲート
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void ReceivedEventHandler(
        object sender,
        ReceivedEventArgs e
    );

    #endregion // </受信イベント>

    /// <summary>
    /// メッセージ受信インターフェース
    /// </summary>
    /// <typeparam name="T">受信する情報の型</typeparam>
    public interface IMessageReceivable<T> : IDisposable
    {
        /// <summary>ネットワーク設定を取得します。</summary>
        INetworkConfig Config { get; }

        /// <summary>受信イベントハンドラ</summary>
        event ReceivedEventHandler Received;

        /// <summary>
        /// 受信を開始します。
        /// </summary>
        void StartReceiving();

        /// <summary>
        /// 受信を停止します。
        /// </summary>
        void StopReceiving();
    }

    /// <summary>
    /// テキストメッセージ受信インターフェース
    /// </summary>
    public interface ITextMessageReceivable : IMessageReceivable<string> { }
}
