using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Lifetime;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 簡単問合せ－PMIPCクライアント
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/05</br>
    /// <br>----------------------------------------------------------------------------</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public static class SimpleInqPMIpcClient
    {
        #region ■ Private Static Member

        /// <summary>
        /// リモートオブジェクト
        /// </summary>
        private static SimplInqPMCommMsg _simplInqPMCommMsg = null;

        #endregion

        #region ■ Private Static Method

        /// <summary>
        /// Ipcクライアントの生成
        /// </summary>
        private static void RegistClientChannel()
        {
            // IPC Channel を作成
            IpcClientChannel clientChannel = new IpcClientChannel();
            // リモートオブジェクトを登録
            ChannelServices.RegisterChannel(clientChannel, true);
            // プロセス間通信用オブジェクト取得
            _simplInqPMCommMsg = (SimplInqPMCommMsg)Activator.GetObject(typeof(SimplInqPMCommMsg), "ipc://simpleinq-pm/message");
        }

        #endregion

        #region ■ Public Method

        /// <summary>
        /// メッセージ送信処理
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static int SendMessage(string msg, out string errMsg)
        {
            errMsg = string.Empty;
            int status = 0;
            try
            {
                if (_simplInqPMCommMsg == null) RegistClientChannel();
                _simplInqPMCommMsg.SendMessage(msg);
            }
            catch (Exception ex)
            {
                status = -1;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 接続チェック処理
        /// </summary>
        /// <param name="connected">True:接続中</param>
        /// <returns></returns>
        public static int CheckConnect(out bool connected, out string errMsg)
        {
            errMsg = string.Empty;
            connected = false;
            int status = 0;
            try
            {
                if (_simplInqPMCommMsg == null) RegistClientChannel();
                _simplInqPMCommMsg.CheckConnect(out connected);
            }
            catch (Exception ex)
            {
                status = -1;
                errMsg = ex.Message;
            }

            return status;
        }

        #endregion
    }

    /// <summary>
    /// 簡単問合せ－PMIPCサーバー
    /// </summary>
    public class SimpleInqPMIpcServer : IDisposable
    {
        #region ■ Private Member

        private SimplInqPMCommMsg _simplInqPMCommMsg = null;

        #endregion

        #region ■ Constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SimpleInqPMIpcServer()
        {
            LifetimeServices.LeaseTime = TimeSpan.Zero;
            LifetimeServices.RenewOnCallTime = TimeSpan.Zero;

            // IPC Channelを作成
            IpcServerChannel servChannel = new IpcServerChannel("simpleinq-pm");
            // リモートオブジェクトを登録
            ChannelServices.RegisterChannel(servChannel, true);
            _simplInqPMCommMsg = new SimplInqPMCommMsg();
            RemotingServices.Marshal(_simplInqPMCommMsg, "message", typeof(SimplInqPMCommMsg));
        }

        #endregion

        #region ■ Destructor

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~SimpleInqPMIpcServer() { Dispose(false); }

        #endregion

        #region ■ Property

        /// <summary>
        /// 
        /// </summary>
        public SimplInqPMCommMsg SimplInqPMCommMsg
        {
            get { return _simplInqPMCommMsg; }
        }

        #endregion

        #region ■ IDisposable メンバ

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

        #endregion

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
            }
            //// アンマネージオブジェクト
            _simplInqPMCommMsg = null;
        }
    }

    /// <summary>
    /// 簡単問合せ－PM間のリモートオブジェクト
    /// </summary>
    public class SimplInqPMCommMsg : MarshalByRefObject
    {
        #region ■ Delegate

        /// <summary>
        /// 接続チェック用デリゲート
        /// </summary>
        /// <param name="isConnect">True:接続中</param>
        public delegate void CheckedConnectEventHandler(out bool isConnect);

        /// <summary>
        /// メッセージ受信用デリゲート
        /// </summary>
        /// <param name="message"></param>
        public delegate void ReceivedMessageEventHandler(string message);

        #endregion

        #region ■ Event

        /// <summary>メッセージ受信イベント</summary>
        public event ReceivedMessageEventHandler MessageRecieveEvent;
        /// <summary>接続チェックイベント</summary>
        public event CheckedConnectEventHandler ConnectCheckEvent;

        #endregion

        #region ■ Public Method

        /// <summary>
        /// メッセージ送信処理
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            MessageRecieveEvent(message);
        }

        /// <summary>
        /// 接続チェック処理
        /// </summary>
        /// <param name="isConnect"></param>
        public void CheckConnect(out bool isConnect)
        {
            ConnectCheckEvent(out isConnect);
        }

        #endregion
    }
}
