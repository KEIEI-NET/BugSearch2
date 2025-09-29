using System;
using System.IO;
using System.Net.Sockets;

using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller.Messenger
{
    /// <summary>
    /// TCPメッセージ送信者クラス
    /// </summary>
    public sealed class TCPMessageSender : ITextMessageSendable
    {
        #region <ITextMessageSendable メンバ>

        /// <summary>レスポンス</summary>
        private string _response;
        /// <summary>レスポンスを取得します。</summary>
        /// <see cref="ITextMessageSendable"/>
        public string Response { get { return _response; } }
        
        private TcpClient tcpSocket = null;

        /// <summary>
        /// 送信します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <see cref="ITextMessageSendable"/>
        public void Send(string message)
        {
            Console.WriteLine("サーバに送信中：{0}", message);

            // streamWriterを生成して、サーバへ送信する文字列を書き込みます。
            StreamWriter writer = new StreamWriter(StreamToServer);
            writer.WriteLine(message);
            writer.Flush();

            // 受信データの読み込み
            //-----DEL by huanghx for #25624 プログラム停止修正 on 20110929 ----->>>>>
            //StreamReader reader = new StreamReader(StreamToServer);
            //_response = reader.ReadLine();
            //Console.WriteLine("受信しました：{0}", _response);
            //-----DEL by huanghx for #25624 プログラム停止修正 on 20110929 -----<<<<<
            //-----ADD by huanghx for #25624 プログラム停止修正 on 20110929 ----->>>>>
            if (StreamToServer.CanRead)
            {
                StreamReader reader = new StreamReader(StreamToServer);
                _response = reader.ReadToEnd();
                Console.WriteLine("受信しました：{0}", _response);
            }
            //-----ADD by huanghx for #25624 プログラム停止修正 on 20110929 -----<<<<<

            StreamToServer.Close();
        }

        /// <summary>
        /// </summary>
        public void Disconnect()
        {
            tcpSocket.Close();
            tcpSocket = null;
        }

        #endregion // </ITextMessageSendable メンバ>

        #region <アドレス>

        /// <summary>アドレス</summary>
        private readonly string _address;
        /// <summary>アドレスを取得します。</summary>
        private string Address { get { return _address; } }

        #endregion // </アドレス>

        #region <ポート>

        /// <summary>ポート</summary>
        private readonly int _port;
        /// <summary>ポートを取得します。</summary>
        private int Port { get { return _port; } } 

        #endregion // </ポート>

        #region <ネットワークストリーム>

        /// <summary>サーバへのネットワークストリーム</summary>
        private readonly NetworkStream _streamToServer;
        /// <summary>サーバへのネットワークストリームを取得します。</summary>
        private NetworkStream StreamToServer { get { return _streamToServer; } }

        #endregion // </ネットワークストリーム>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="address">アドレス</param>
        /// <param name="port">ポート</param>
        public TCPMessageSender(
            string address,
            int port
        )
        {
            _address = address;
            _port = port;
            Console.WriteLine("サーバに接続します。{0}：{1}", _address, _port);
            if (tcpSocket==null) tcpSocket = new TcpClient(_address, _port);
            _streamToServer = tcpSocket.GetStream();

        }

        #endregion // </Constructor>
    }
}
