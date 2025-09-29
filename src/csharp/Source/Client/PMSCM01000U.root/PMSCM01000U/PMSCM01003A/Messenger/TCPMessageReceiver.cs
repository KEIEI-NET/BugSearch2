//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メッセージSenderとReciver
// プログラム概要   : メッセージの送信と受信処理を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 周正雨
// 作 成 日  2011/09/16  修正内容 : 日本語メッセージ受信文字化け問題の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/09/29  修正内容 : #25624 プログラム停止の対応
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.NetworkConfig;
using System.IO;// zhouzy add 2011.09.16

namespace Broadleaf.Application.Controller.Messenger
{
    /// <summary>
    /// TCPメッセージ受信者クラス
    /// </summary>
    public sealed class TCPMessageReceiver : ITextMessageReceivable
    {
        #region <ITextMessageReceivable メンバ>

        /// <summary>ネットワーク設定</summary>
        private readonly INetworkConfig _config;
        /// <summary>ネットワーク設定を取得します。</summary>
        public INetworkConfig Config { get { return _config; } }

        /// <summary>受信イベントハンドラ</summary>
        /// <see cref="ITextMessageReceivable"/>
        public event ReceivedEventHandler Received;

        /// <summary>
        /// 受信を開始します。
        /// </summary>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <see cref="ITextMessageReceivable"/>
        public void StartReceiving()
        {
            #region <Guard Phrase>

            if (Disposed) throw new ObjectDisposedException("This is disposed.");

            #endregion // </Guard Phrase>

            IsRunning = true;
            ReceiveRunner.Start();
        }

        /// <summary>
        /// 受信を停止します。
        /// </summary>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        /// <see cref="ITextMessageReceivable"/>
        public void StopReceiving()
        {
            #region <Guard Phrase>

            if (Disposed) throw new ObjectDisposedException("This is disposed.");

            #endregion // </Guard Phrase>

            IsRunning = false;
            ReceiveRunner.Abort();
        }

        #endregion // </ITextMessageReceivable メンバ>

        #region <IDisposable メンバ>

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <see cref="IDisposable"/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        #region <IDisposable Idiom>

        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        /// <summary>処分済みフラグを取得します。</summary>
        private bool Disposed { get { return _disposed; } }

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトを処分するフラグ</param>
        private void Dispose(bool disposing)
        {
            // マネージオブジェクト
            if (disposing)
            {
                _isRunning = false;
            }
            // アンマネージオブジェクト
            if (_tcpListener != null) _tcpListener.Stop();
            _tcpListener = null;
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~TCPMessageReceiver() { Dispose(false); }

        #endregion // <IDisposable Idiom>

        #endregion // </IDisposable メンバ>

        #region <TCPリスナー>

        /// <summary>TCPリスナー</summary>
        private TcpListener _tcpListener;
        /// <summary>TCPリスナーを取得します。</summary>
        private TcpListener TCPListener
        {
            get
            {
                if (!Disposed && _tcpListener == null)
                {
                    _tcpListener = new TcpListener(Config.IPAddress, Config.PortNumber);
                }
                return _tcpListener;
            }
        }

        #endregion // </TCPリスナー>

        #region <受信スレッド>

        /// <summary>起動中フラグ</summary>
        private bool _isRunning;
        /// <summary>起動中フラグのアクセサ</summary>
        private bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }

        /// <summary>受信スレッド</summary>
        private Thread _receiveRunner;
        /// <summary>受信スレッドを取得します。</summary>
        private Thread ReceiveRunner
        {
            get
            {
                if (_receiveRunner == null)
                {
                    _receiveRunner = new Thread(new ThreadStart(this.Run));
                }
                return _receiveRunner;
            }
        }

        #endregion // </受信スレッド>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="networkConfig">ネットワーク設定</param>
        public TCPMessageReceiver(INetworkConfig networkConfig)
        {
            _config = networkConfig;

            Received += new ReceivedEventHandler(DebugPrint);
        }

        #endregion // </Constructor>

        #region <クライアントハンドラ>
        //2011.07.15 ZHANGYH ADD STA >>>>>>
        private delegate void SingleCallback<T>(T arg);
        //2011.07.15 ZHANGYH ADD End <<<<<<

        /// <summary>
        /// クライアントハンドラクラス
        /// </summary>
        private sealed class ClientHandler
        {
            #region <バッファ>

            /// <summary>バッファ</summary>
            private readonly byte[] _buffer = new byte[256];
            /// <summary>バッファを取得します。</summary>
            private byte[] Buffer { get { return _buffer; } }

            #endregion // </バッファ>

            #region <ソケット>

            /// <summary>ソケット</summary>
            private Socket _mySocket;
            /// <summary>ソケットを取得します。</summary>
            private Socket MySocket
            {
                get { return _mySocket; }
                set { _mySocket = value; }
            }

            #endregion // </ソケット>

            #region <ネットワークストリーム>

            /// <summary>ネットワークストリーム</summary>
            private NetworkStream _myNetworkStream;
            /// <summary>ネットワークストリームを取得します。</summary>
            private NetworkStream MyNetworkStream
            {
                get { return _myNetworkStream; }
                set { _myNetworkStream = value; }
            }

            #endregion // </ネットワークストリーム>

            #region <コールバック>

            /// <summary>読み込み時のコールバック</summary>
            private readonly AsyncCallback _callbackRead;
            /// <summary>読み込み時のコールバックを取得します。</summary>
            private AsyncCallback CallbackRead { get { return _callbackRead; } }

            /// <summary>書き込み時のコールバック</summary>
            private readonly AsyncCallback _callbackWrite;
            /// <summary>書き込み時のコールバック</summary>
            private AsyncCallback CallbackWrite { get { return _callbackWrite; } }

            #endregion // </コールバック>

            #region <読み込んだメッセージ>

            /// <summary>読み込んだメッセージ</summary>
            private string _readMessage;
            /// <summary>読み込んだメッセージを取得します。</summary>
            public string ReadMessage { get { return _readMessage; } }

            //2011.07.15 ZHANGYH ADD STA >>>>>>
            private StringBuilder _readMessageBuf = new StringBuilder();
            private SingleCallback<string> _readSuccessCallback;
            public SingleCallback<string> ReadSuccessCallback { set { _readSuccessCallback = value; } get { return _readSuccessCallback; } }
            //2011.07.15 ZHANGYH ADD END <<<<<<

            //2011.09.16 zhouzy ADD STA >>>>>>
            private MemoryStream _readStream = new MemoryStream();
            //2011.09.16 zhouzy ADD END <<<<<<

            #endregion // </読み込んだメッセージ>

            #region <Constructor>

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="mySocket">ソケット</param>
            public ClientHandler(Socket mySocket)
            {
                _mySocket = mySocket;
                _myNetworkStream = new NetworkStream(mySocket);
                _callbackRead = new AsyncCallback(OnReadComplete);
                _callbackWrite = new AsyncCallback(OnWriteComplete);
            }

            #endregion // </Constructor>

            /// <summary>
            /// クライアントからのメッセージを読み込みます。
            /// </summary>
            public void BeginRead()
            {
                //2011.07.15 ZHANGYH ADD STA >>>>>>
                _readMessageBuf.Length = 0;
                //2011.07.15 ZHANGYH ADD END <<<<<<
                MyNetworkStream.BeginRead(Buffer, 0, Buffer.Length, CallbackRead, null);
            }

            /// <summary>
            /// 読み込み完了時の処理
            /// </summary>
            /// <param name="asyncResult">同期用の結果</param>
            private void OnReadComplete(IAsyncResult asyncResult)
            {
                int readByteSize = MyNetworkStream.EndRead(asyncResult);
                if (readByteSize > 0)
                {
                    //2011.07.15 ZHANGYH EDT STA >>>>>>
                    //_readMessage = Encoding.Unicode.GetString(Buffer, 0, readByteSize);
                    //受信情報のキャラクタセットを変更する
                    //2011.09.16 zhouzy EDT STA >>>>>>
                    // _readMessage = Encoding.UTF8.GetString(Buffer, 0, readByteSize);
                    _readStream.Write(Buffer, 0, readByteSize);
                    //2011.09.16 zhouzy EDT END <<<<<<
                    //2011.07.15 ZHANGYH EDT END <<<<<<
                    //Debug.WriteLine(string.Format("クライアントから {0} [byte]受信しました：{1}", readByteSize, _readMessage));

                    //2011.09.16 zhouzy DEL STA >>>>>>
                    //2011.07.15 ZHANGYH ADD STA >>>>>>
                    //_readMessageBuf.Append(_readMessage);
                    //2011.07.15 ZHANGYH ADD END <<<<<<
                    //2011.09.16 zhouzy DEL END <<<<<<

                    MyNetworkStream.BeginWrite(Buffer, 0, readByteSize, CallbackWrite, null);
                }
                else
                {
                    Debug.WriteLine("接続が中断されました。");
                    MyNetworkStream.Close();
                    MySocket.Close();
                    MyNetworkStream = null;
                    MySocket = null;

                    //2011.07.15 ZHANGYH ADD STA >>>>>>
                    //ターゲット部品（新着チェック）へ送信する
                    if (_readSuccessCallback != null)
                    {
                        //2011.09.16 zhouzy ADD STA >>>>>>
                        byte[] bytes = new byte[_readStream.Length];
                        _readStream.Position = 0;
                        _readStream.Read(bytes, 0, bytes.Length);
                        string temp = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        //2011.09.16 zhouzy ADD END <<<<<<                       
                        _readMessage = temp.Substring(0, temp.Length - 2); // Remove \r\n at end
                        _readSuccessCallback(_readMessage);
                    }
                    //2011.09.16 zhouzy ADD STA >>>>>>
                    _readStream.Close();
                    //2011.09.16 zhouzy ADD END <<<<<<   
                    //2011.07.15 ZHANGYH ADD END <<<<<<
                }
            }

            /// <summary>
            /// 書き込み完了時の処理
            /// </summary>
            /// <param name="asyncResult">同期用の結果</param>
            private void OnWriteComplete(IAsyncResult asyncResult)
            {
                MyNetworkStream.EndWrite(asyncResult);
                Debug.WriteLine("書き込みが完了しました。");

                //MyNetworkStream.BeginRead(Buffer, 0, Buffer.Length, CallbackRead, null); DEL by huanghx for #25624 プログラム停止修正 on 20110929
                //-----ADD by huanghx for #25624 プログラム停止修正 on 20110929 ----->>>>>
                if (MyNetworkStream.DataAvailable)
                {
                    MyNetworkStream.BeginRead(Buffer, 0, Buffer.Length, CallbackRead, null);
                }
                else
                {
                    Debug.WriteLine("接続が中断されました。");
                    MyNetworkStream.Close();
                    MySocket.Close();
                    MyNetworkStream = null;
                    MySocket = null;

                    //ターゲット部品（新着チェック）へ送信する
                    if (_readSuccessCallback != null)
                    {
                        byte[] bytes = new byte[_readStream.Length];
                        _readStream.Position = 0;
                        _readStream.Read(bytes, 0, bytes.Length);
                        string temp = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        _readMessage = temp.Substring(0, temp.Length - 2); // Remove \r\n at end
                        _readSuccessCallback(_readMessage);
                    }
                    _readStream.Close();
                }
                //-----ADD by huanghx for #25624 プログラム停止修正 on 20110929 -----<<<<<
            }
        }

        #endregion // </クライアントハンドラ>

        /// <summary>
        /// 起動します。
        /// </summary>
        private void Run()
        {
            try
            {
                TCPListener.Start();

                // クライアントの接続を受けるための永久ループ
                while (true)
                {
                    Debug.WriteLine("接続待ち...");

                    // 強制終了
                    if (Disposed || !IsRunning)
                    {
                        if (TCPListener != null) TCPListener.Stop();
                        return;
                    }

                    // 接続があると、接続を許可して、新しいソケットを返す
                    Socket socketForClient = TCPListener.AcceptSocket();
                    Debug.WriteLine(string.Format("{0} クライアントが接続しました。", DateTime.Now));

                    ClientHandler clientHandler = new ClientHandler(socketForClient);

                    //2011.07.15 ZHANGYH ADD STA >>>>>>
                    clientHandler.ReadSuccessCallback = new SingleCallback<string>(delegate(string msg)
                    {
                        Received(this, new ReceivedEventArgs(msg));
                    });
                    //2011.07.15 ZHANGYH ADD END <<<<<<

                    clientHandler.BeginRead();
                    //2011.07.15 ZHANGYH DEL STA >>>>>>
                    //Received(this, new ReceivedEventArgs(clientHandler.ReadMessage));
                    //2011.07.15 ZHANGYH DEL END <<<<<<
                }
            }
            catch (SocketException e)
            {
                if (TCPListener != null) TCPListener.Stop();
                Debug.WriteLine("接続が強制的に切断されました。");
                Debug.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// デフォルト受信イベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private static void DebugPrint(object sender, ReceivedEventArgs e)
        {
            Debug.WriteLine(string.Format("{0} 受信テキスト：{1}", DateTime.Now, e.Text));
        }
    }
}
