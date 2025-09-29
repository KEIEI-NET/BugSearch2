//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : PMNS-HTT通信サービス
// プログラム概要   : PMNS-HTT間の通信を行うサービスプログラムです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 佐藤　智之
// 作 成 日  2017/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 佐藤　智之
// 修 正 日  2017/08/01  修正内容 : ２次開発
//----------------------------------------------------------------------------//
// 管理番号  11375156-00 作成担当 : 脇田　靖之
// 修 正 日  2017/11/27  修正内容 :サービス待ち受け障害解除対応
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 脇田　靖之
// 修 正 日  2017/12/14  修正内容 :ハンディターミナル三次対応
//----------------------------------------------------------------------------//
// 管理番号  11575094-00 作成担当 : 岸　傑
// 修 正 日  2019/06/13  修正内容 :大黒商会検品障害対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 白厩  翔也
// 修 正 日  2019/10/16  修正内容 : ６次対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 修 正 日  2019/11/14  修正内容 : ６次対応（調整）
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 白厩  翔也
// 修 正 日  2020/04/01  修正内容 : ハンディ仕入れ時在庫登録対応
//----------------------------------------------------------------------------//
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using System.Data;
using System.Text;
using System.Net;
using System.Collections;
using System.Xml;
using System.IO;
using System.Reflection;
using log4net;
using PMHND00100S.Common;
using PMHND00100S.Socket;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace PMHND00100S
{
    /// public class name:   PMHND00100S
    /// <summary>
    ///                      ソケット通信用　メインクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＨＴＴおよび、ＰＭＮＳとの通信処理</br>
    /// <br>Programmer       :   佐藤　智之</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   2017/08/01  佐藤　智之</br>
    /// <br>                 :   ２次開発</br>
    /// <br></br>
    /// </remarks>
    public partial class PMHND00100S : ServiceBase
    {

#region "定数"

    // ロガー
    private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    // HTTとのソケット通信用電文の最大文字長
    // MOD 2019/08/09 ---------->>>>>
    // 想定件数：100件 →　1000件
    //private const Int32 RELAY_LEN = 50000;
    // -- UPD 2019/10/16 ------------------------------>>>
    //private const Int32 RELAY_LEN = 500000;
    //バッファサイズを計算するように修正
    private const Int32 RELAY_LEN = 0;
    // -- UPD 2019/10/16 ------------------------------<<<
    // MOD 2019/08/09 ----------<<<<<
    // 機能区分(HTTとのソケット通信の電文内の先頭4byteを指す。必ずセットされる値)
    private const Int32 SOCKET_SYORI_KBN_LEN = 4;

#endregion

#region "変数"

        // ************************************
        // メンバー変数
        // ************************************
        private System.Net.Sockets.TcpListener ServerSocket;        // リスナー(接続待ちや受信等を行なうｵﾌﾞｼﾞｪｸﾄ)
        private System.Threading.Thread ListeningCallbackThread;    // 接続待ちスレッド
        private volatile bool SLTAlive;                             // 接続待ちスレッド終了指示フラグ   true:スレッド動作中、false:スレッド終了

        // 送受信電文処理スレッド呼び出し用オブジェクト
        private CommunicationCallbackDelegate Caller = null;

        // 送受信電文処理ﾒｿｯﾄﾞ用ﾃﾞﾘｹﾞｰﾄ
        delegate ProcessingResultOfCommunication CommunicationCallbackDelegate(System.Net.Sockets.TcpListener listener);

        // 待機中のスレッドを管理するオブジェクト
        private static System.Threading.ManualResetEvent AllDone = new System.Threading.ManualResetEvent(false);

        // 対ＰＭＮＳ用引数 RemoteObjectインターフェース
        private IPmHandy _iPmHandy;

#endregion

#region "イベント"
        /// <summary>
        /// 初期処理
        /// </summary>
        public PMHND00100S()
        {
            InitializeComponent();
        }

        /// <summary>
        /// サービス開始時イベント
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            // サービスを開始するためのコードをここに追加します。
            ServiceStart();
        }

        /// <summary>
        /// サービス終了時イベント
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStop()
        {
            // サービスを停止するのに必要な終了処理を実行するコードをここに追加します。
            ServiceStop();
        }

#endregion

#region "関数"
        /// <summary>
        /// 開始
        /// </summary>
        /// <remarks></remarks>
        public void ServiceStart()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ServiceStart -->>");

            try
            {
                // 多重起動チェック
                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, "多重起動チェック エラー -->>");
                    return;
                }

                // 初期処理
                InitProcess();

                // スレッド終了指示フラグを未終了に初期化
                SLTAlive = false;

                // 送受信電文処理スレッド用メソッドをスレッド用メソッドとして登録
                Caller = new CommunicationCallbackDelegate(CommunicationCallback);

                // 対ハンデ用ソケット準備
                SocketSet();

                // 対ＰＭＮＳ用通信準備
                AplSet();
            }
            catch (Exception ex)    
            {
                StringBuilder msgInfo = new System.Text.StringBuilder();
                msgInfo.Length = 0;
                msgInfo.Append("サービス起動時エラー:" + ex.Message);
                LOGGER.Error(msgInfo.ToString());

                // アプリケーションを終了する
                this.Stop();

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ServiceStart <<--");
            }
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <remarks></remarks>
        public void ServiceStop()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ServiceStop -->>");

            try
            {
                // ｻｰﾊﾞｱﾌﾟﾘを終了するにもかかわらず、接続待ちｽﾚｯﾄﾞを終了していない場合の処理
                if (SLTAlive)
                {
                    // スレッド終了指示フラグを終了に設定
                    SLTAlive = false;

                    // 接続要求受け入れの終了
                    ServerSocket.Stop();

                    // 念のためスレッドをnull設定
                    ListeningCallbackThread = null;
                }
            }
            catch (Exception ex)
            {
                StringBuilder msgInfo = new System.Text.StringBuilder();
                msgInfo.Length = 0;
                msgInfo.Append("サービス終了時エラー:" + ex.Message);
                LOGGER.Error(msgInfo.ToString());
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ServiceStop <<--");
            }
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        /// <remarks></remarks>
        private void InitProcess()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "InitProcess -->>");

            Boolean IsGetIpAddress = false;
            
            try
            {
                //ＩＰアドレスの取得
                string hostname = Dns.GetHostName();
                IPHostEntry localhost = Dns.GetHostEntry(hostname);
                foreach (IPAddress ipWk in localhost.AddressList)
                {
                    if (ipWk.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        clsCommon.gIpAddress = ipWk.ToString();
                        IsGetIpAddress = true;
                        break;
                    }
                }

                //IPアドレスの取得チェック
                if (IsGetIpAddress == false)
                {
                    clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "InitProcess ERROR = IPアドレスを取得できませんでした。");
                }

                // 設定ファイル　ハンディとのソケット通信　ポート
                // --- MOD 2019/11/14 ---------->>>>>
                //clsCommon.gSocketPort = Int32.Parse(ConfigurationManager.AppSettings[clsBtConst.KEY_SOCKETPORT]);
                string[] allKeys = ConfigurationManager.AppSettings.AllKeys;
                List<string> allKeyList = new List<string>();
                foreach (string s in allKeys)
                {
                    allKeyList.Add(s.ToUpper());
                }


                if (!allKeyList.Contains(clsBtConst.KEY_SOCKETPORT.ToUpper()))
                {
                    WriteConfig(clsBtConst.KEY_SOCKETPORT, clsCommon.gSocketPort.ToString());
                }
                else
                {
                    int result = 0;

                    if (int.TryParse(ConfigurationManager.AppSettings[clsBtConst.KEY_SOCKETPORT], out result))
                    {
                        clsCommon.gSocketPort = result;
                    }
                }
                // --- MOD 2019/11/14 ----------<<<<<

                // 設定ファイル　ログの出力判定
                // --- MOD 2019/11/14 ---------->>>>>
                //clsCommon.gDebugDetailLog = ConfigurationManager.AppSettings[clsBtConst.KEY_DEBUGDETAILLOG];
                if (!allKeyList.Contains(clsBtConst.KEY_DEBUGDETAILLOG.ToUpper()))
                {
                    WriteConfig(clsBtConst.KEY_DEBUGDETAILLOG, clsCommon.gDebugDetailLog);
                }
                else
                {
                    clsCommon.gDebugDetailLog = ConfigurationManager.AppSettings[clsBtConst.KEY_DEBUGDETAILLOG];
                }
                // --- MOD 2019/10/01 ----------<<<<<

                // ＩＰＣアドレス
                // --- MOD 2019/11/14 ---------->>>>>
                //clsCommon.gIpcAddress = ConfigurationManager.AppSettings[clsBtConst.KEY_IPCADDRESS];
                if (!allKeyList.Contains(clsBtConst.KEY_IPCADDRESS.ToUpper()))
                {
                    WriteConfig(clsBtConst.KEY_IPCADDRESS, clsCommon.gIpcAddress);
                }
                else
                {
                    clsCommon.gIpcAddress = ConfigurationManager.AppSettings[clsBtConst.KEY_IPCADDRESS];
                }
                // --- MOD 2019/11/14 ----------<<<<<

                // --- ADD 2019/06/13 ---------->>>>>
                // リトライ回数
                // --- MOD 2019/11/14 ---------->>>>>
                //clsCommon.gRetryTimes = ConfigurationManager.AppSettings[clsBtConst.KEY_RETRYTIMES];
                if (!allKeyList.Contains(clsBtConst.KEY_RETRYTIMES.ToUpper()))
                {
                    WriteConfig(clsBtConst.KEY_RETRYTIMES, clsCommon.gRetryTimes);
                }
                else
                {
                    clsCommon.gRetryTimes = ConfigurationManager.AppSettings[clsBtConst.KEY_RETRYTIMES];
                }
                // --- MOD 2019/11/14 ----------<<<<<
                // リトライ間隔
                // --- MOD 2019/11/14 ---------->>>>>
                //clsCommon.gRetryInterval = ConfigurationManager.AppSettings[clsBtConst.KEY_RETRYINTERVAL];
                if (!allKeyList.Contains(clsBtConst.KEY_RETRYINTERVAL.ToUpper()))
                {
                    WriteConfig(clsBtConst.KEY_RETRYINTERVAL, clsCommon.gRetryInterval);
                }
                else
                {
                    clsCommon.gRetryInterval = ConfigurationManager.AppSettings[clsBtConst.KEY_RETRYINTERVAL];
                }
                // --- MOD 2019/11/14 ----------<<<<<


                // --- UPD 2019/11/14 ----------<<<<<
                // -- ADD 2019/10/16 ------------------------------>>>
                // ソケット通信のバッファサイズ
                //clsCommon.gSocketBufferSiz = Int32.Parse(ConfigurationManager.AppSettings[clsBtConst.KEY_SOCKET_BUFFER_SIZE]);
                if (!allKeyList.Contains(clsBtConst.KEY_SOCKET_BUFFER_SIZE.ToUpper()))
                {
                    WriteConfig(clsBtConst.KEY_SOCKET_BUFFER_SIZE, clsCommon.gSocketBufferSiz.ToString());
                }
                else
                {
                    int result = 0;
                    if (int.TryParse(ConfigurationManager.AppSettings[clsBtConst.KEY_SOCKET_BUFFER_SIZE], out result))
                    {
                        clsCommon.gSocketBufferSiz = result;
                    }
                }
                // -- ADD 2019/10/16 ------------------------------<<<
                // --- UPD 2019/11/14 ----------<<<<<

                return;
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "InitProcess ERROR = " + ex.Message);
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "InitProcess <<--");
            }
        }

        // --- ADD 2019/11/14 ---------->>>>>
        /// <summary>
        /// 設定ファイル書き込み
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private void WriteConfig(string key, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {

                string filePath = string.Format("{0}{1}", Process.GetCurrentProcess().MainModule.FileName, ".config");

                // ロード
                if (File.Exists(filePath))
                {
                    xmlDoc.Load(filePath);
                }

                // ノード選択
                XmlNode xn = xmlDoc.DocumentElement.SelectSingleNode("appSettings");

                if (xn != null)
                {
                    //if (string.IsNullOrEmpty(xn.InnerText))
                    //{
                    //    XmlComment commentFirst = xmlDoc.CreateComment("ハンディとのソケット通信用");
                    //    xn.InsertAfter(commentFirst, xn.LastChild);
                    //}

                    string commentstr = string.Empty;
                    if (key == clsBtConst.KEY_SOCKETPORT)
                    {
                        commentstr = " ポート　　　(当プログラムを実行するPCのポート) ";
                    }
                    else if (key == clsBtConst.KEY_DEBUGDETAILLOG)
                    {
                        commentstr = " ログの出力判定(on:出力する,off:出力しない) ";
                    }
                    else if (key == clsBtConst.KEY_IPCADDRESS)
                    {
                        commentstr = " ＩＰＣアドレス ";
                    }
                    else if (key == clsBtConst.KEY_RETRYTIMES)
                    {
                        commentstr = " リトライ回数 ";
                    }
                    else if (key == clsBtConst.KEY_RETRYINTERVAL)
                    {
                        commentstr = " リトライ間隔 ";
                    }
                    else if (key == clsBtConst.KEY_SOCKET_BUFFER_SIZE)
                    {
                        commentstr = " ソケット通信のバッファサイズ ";
                    }

                    XmlElement child = xmlDoc.CreateElement("add");
                    XmlComment comment = xmlDoc.CreateComment(commentstr);

                    xn.InsertAfter(comment, xn.LastChild);
                    child.SetAttribute("key", key);
                    child.SetAttribute("value", value);
                    xn.InsertAfter(child, xn.LastChild);

                    xmlDoc.Save(filePath);
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                xmlDoc = null;
            }

        }
        // --- ADD 2019/11/14 ----------<<<<<


        /// <summary>
        /// 対ハンデ用ソケット準備
        /// </summary>
        /// <remarks></remarks>
        private void SocketSet()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "SocketSet -->>");
            try
            {
                if (!SLTAlive)  // まだ接続待ちｽﾚｯﾄﾞを生成していない場合
                {

                    // リスナー(接続要求受け入れ待機)を生成
                    ServerSocket = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Parse(clsCommon.gIpAddress), clsCommon.gSocketPort);

                    // 接続要求受け入れ開始
                    ServerSocket.Start();

                    // 接続待ち用スレッドを作成
                    ListeningCallbackThread = new System.Threading.Thread(ListeningCallback);

                    // --- ADD 2017/11/27 Y.Wakita ---------->>>>>
                    // スレッド終了指示フラグを未終了に設定
                    SLTAlive = true;
                    // --- ADD 2017/11/27 Y.Wakita ----------<<<<<

                    // 接続待ち用スレッドを開始
                    ListeningCallbackThread.Start();

                    // --- DEL 2017/11/27 Y.Wakita ---------->>>>>
                    //// スレッド終了指示フラグを未終了に設定
                    //SLTAlive = true;
                    // --- DEL 2017/11/27 Y.Wakita ----------<<<<<
                }
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "SocketSet ERROR = " + ex.Message);

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "SocketSet <<--");
            }
        }

        /// <summary>
        /// 送受信電文処理スレッド用メソッド
        ///  --- 受信された電文に対して、具体的な処理を行なうメソッドです。
        ///      受信電文をテキストボックスに表示し、また、クライアントへ返信を返す処理としています。
        ///      なお、本メソッド(電文処理部)は、複数のクライアントからの接続に対応しています。
        ///      受信があるたびにスレッドが起動し、本メソッドが実行されます。
        /// </summary>
        /// <param name="listener">クライアントからの受信接続要求を処理するリスナー</param>
        /// <remarks>処理結果</remarks>
        public ProcessingResultOfCommunication CommunicationCallback(System.Net.Sockets.TcpListener listener)
        {
            // --- ADD 2019/06/13 ---------->>>>>
            // 処理成功判定
            bool isSuccess = true;
            // --- ADD 2019/06/13 ----------<<<<<

            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "CommunicationCallback -->>");

            // AllDoneをシグナル状態にする。
            // 接続待ちスレッドのロックを解除して、接続待ちスレッドの実行再開の許可をする。
            AllDone.Set();

            // 処理結果格納用クラスの生成
            ProcessingResultOfCommunication ResultData = new ProcessingResultOfCommunication();

            if (SLTAlive)  // 接続待ちｽﾚｯﾄﾞが作成されていて使える場合
            {
                // -- ADD 2017/08/01 ------------------------------>>>
                // クライアントからの接続を受け付ける
                System.Net.Sockets.TcpClient ClientSocket = listener.AcceptTcpClient(); // TCPｸﾗｲｱﾝﾄ

                //受信タイムアウトは設定が必要ない。が、初期値=0 のままだといつまでも読み込みされない。
                //意味合いとして、設定時間待ってから受信される。
                ClientSocket.ReceiveTimeout = -1;

                // 通信ストリームの取得
                System.Net.Sockets.NetworkStream stream = ClientSocket.GetStream();

                byte[] reply = null;
                // -- ADD 2017/08/01 ------------------------------<<<

                try
                {
                    StringBuilder myCompleteMessage = new StringBuilder();
                    Int32 DataLength = 0;

                    // -- DEL 2017/08/01 ------------------------------>>>
                    //// クライアントからの接続を受け付ける
                    //System.Net.Sockets.TcpClient ClientSocket = listener.AcceptTcpClient(); // TCPｸﾗｲｱﾝﾄ

                    ////受信タイムアウトは設定が必要ない。が、初期値=0 のままだといつまでも読み込みされない。
                    ////意味合いとして、設定時間待ってから受信される。
                    //ClientSocket.ReceiveTimeout = -1;

                    //// 通信ストリームの取得
                    //System.Net.Sockets.NetworkStream stream = ClientSocket.GetStream();
                    // -- DEL 2017/08/01 ------------------------------<<<

                    //============
                    // クライアントからの電文の受信
                    // MOD 2019/08/09 ---------->>>>>
                    //byte[] ReceiveData = new byte[50000];
                    // 想定件数　100件　→　1000件
                    // -- ADD 2019/10/16 ------------------------------>>>
                    //byte[] ReceiveData = new byte[500000];
                    byte[] ReceiveData = new byte[clsCommon.gSocketBufferSiz];
                    // -- ADD 2019/10/16 ------------------------------<<<
                    // MOD 2019/08/09 ----------<<<<<
                    //true:ループ処理、false:ループ処理を抜ける
                    bool rcvloopFlg = true;

                    // -- UPD 2017/08/01 ------------------------------>>>
                    //Int32 socketCnt = 0;

                    //while (rcvloopFlg)
                    //{
                    //    try
                    //    {
                    //        System.Threading.Thread.Sleep(100);

                    //        while ((DataLength = stream.Read(ReceiveData, 0, ReceiveData.Length)) != 0)
                    //        {
                    //            string SubRcvData = System.Text.Encoding.GetEncoding("shift_jis").GetString(ReceiveData, 0, DataLength);
                    //            myCompleteMessage.AppendFormat("{0}", SubRcvData);

                    //            //終端文字が見つかるまで文字列をReadし続ける。
                    //            if (SubRcvData.IndexOf(clsBtConst.HT_MSG_CRLF) >= 0)
                    //            {
                    //                rcvloopFlg = false;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        string err = ex.Message;
                    //        socketCnt += 1;
                    //        if (socketCnt >= 10)
                    //        {
                    //            rcvloopFlg = false;
                    //        }
                    //    }
                    //}

                    try
                    {
                        string SubRcvData = "";

                        System.Threading.Thread.Sleep(100);

                        DataLength = stream.Read(ReceiveData, 0, ReceiveData.Length);

                        SubRcvData = System.Text.Encoding.GetEncoding("shift_jis").GetString(ReceiveData, 0, DataLength);
                        myCompleteMessage.AppendFormat("{0}", SubRcvData);

                        //終端文字が無かった場合、文字列をReadし続ける。
                        if (SubRcvData.IndexOf(clsBtConst.HT_MSG_CRLF) < 0)
                        {

                            while (rcvloopFlg)
                            {

                                System.Threading.Thread.Sleep(100);

                                while ((DataLength = stream.Read(ReceiveData, 0, ReceiveData.Length)) != 0)
                                {

                                    SubRcvData = System.Text.Encoding.GetEncoding("shift_jis").GetString(ReceiveData, 0, DataLength);
                                    myCompleteMessage.AppendFormat("{0}", SubRcvData);

                                    //終端文字が見つかるまで文字列をReadし続ける。
                                    if (SubRcvData.IndexOf(clsBtConst.HT_MSG_CRLF) >= 0)
                                    {
                                        rcvloopFlg = false;
                                        break;
                                    }
                                }

                                // 0byte受信時は受信処理終了とする。
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "CommunicationCallback_nest ERROR = " + ex.Message);

                        // --- ADD 2019/06/13 ---------->>>>>
                        isSuccess = false;
                        // --- ADD 2019/06/13 ----------<<<<<

                    }
                    // -- UPD 2017/08/01 ------------------------------<<<

                    // -- UPD 2019/10/16 ------------------------------>>>
                    // --- MOD 2019/06/13 ---------->>>>>
                    ////ReceiveData = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(myCompleteMessage.ToString());
                    //if (isSuccess)
                    //{
                    //    ReceiveData = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(myCompleteMessage.ToString());
                    //}
                    //// --- MOD 2019/06/13 ----------<<<<<
                    if (isSuccess)
                    {
                        byte[] ReceiveDataComp = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(myCompleteMessage.ToString());
                        reply = APLCom(ReceiveData);
                    }
                    // -- UPD 2019/10/16 ------------------------------<<<

                    // ハンディからの受信データ（string ResultData.ReceivedData）を元に
                    // アプリ側から情報を取得して、送信データ（string ResultData.Reply）にセット
                    // -- UPD 2017/08/01 ------------------------------>>>
                    //byte[] reply = APLCom(ReceiveData);
                    // --- MOD 2019/06/13 ---------->>>>>
                    //reply = APLCom(ReceiveData);
                    // -- DEL 2019/10/16 ------------------------------>>>
                    //if (isSuccess)
                    //{
                    //    reply = APLCom(ReceiveData);
                    //}
                    // -- DEL 2019/10/16 ------------------------------<<<
                    // --- MOD 2019/06/13 ----------<<<<<
                    // -- UPD 2017/08/01 ------------------------------<<<

                    // -- ADD 2017/08/01 ------------------------------>>>
                    //終端文字をbyte変換(1byte)
                    byte[] bytEntStr = System.Text.Encoding.GetEncoding("shift_jis").GetBytes((clsBtConst.HT_MSG_CRLF).ToString());

                    //空文字でHTTへは返さない(APLCom内でのエラー発生した場合の対応)
                    if (reply == null)
                    {
                        reply = bytEntStr;
                    }

                    //最終文字が終端文字かの判断
                    if (reply[reply.Length - 1] != bytEntStr[0])
                    {
                        //終端文字が無い場合は、終端文字を付加する。(基本的には当ロジックを通ることは無い)
                        Array.Resize(ref reply, reply.Length + 1);
                        reply[reply.Length - 1] = bytEntStr[0];
                    }

                    // -- ADD 2017/08/01 ------------------------------<<<

                    ////============
                    //// 返信電文をクライアントへ送信
                    //stream.Write(reply, 0, reply.Length);

                    //// フラッシュ(強制書き出し)
                    //stream.Flush();

                    //// 短時間だけ待機
                    //System.Threading.Thread.Sleep(100);

                    //// 通信ストリームをクローズ
                    //stream.Close();

                    //// TCPｸﾗｲｱﾝﾄをｸﾛｰｽﾞ
                    //ClientSocket.Close();
                }
                catch (Exception ex)
                {
                    // -- ADD 2017/08/01 ------------------------------>>>
                    //空文字でHTTへは返さない(アプリケーションエラー時の対応)
                    reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes((clsBtConst.HT_MSG_CRLF).ToString());
                    // -- ADD 2017/08/01 ------------------------------<<<

                    clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "CommunicationCallback ERROR = " + ex.Message);
                }
                finally
                {
                    //============
                    // 返信電文をクライアントへ送信
                    stream.Write(reply, 0, reply.Length);

                    // フラッシュ(強制書き出し)
                    stream.Flush();

                    // 短時間だけ待機
                    System.Threading.Thread.Sleep(100);

                    // 通信ストリームをクローズ
                    stream.Close();

                    // TCPｸﾗｲｱﾝﾄをｸﾛｰｽﾞ
                    ClientSocket.Close();
                }
            }

            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "CommunicationCallback <<--");

            return ResultData;
        }

        /// <summary>
        // 接続待ちスレッド用メソッド
        //  --- クライアントからの受信受け付けを行なうメソッドです。
        //      なお、受信受け付けを常に行なうため、無限ループで受け付け処理を行っています。
        //      無限ループは、処理を占有して、本サーバープログラム自体の動作に影響しますので、
        //      本メソッドは、スレッドとして起動します。
        /// </summary>
        /// <remarks></remarks>
        private void ListeningCallback()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ListeningCallback -->>");

            try
            {
                // 受信の受付を行なうための無限ループ
                while (SLTAlive)    // ｽﾚｯﾄﾞ終了指示ﾌﾗｸﾞでの終了指示がある場合はﾙｰﾌﾟ終了
                {
                    // 受信接続キュー内で、接続待ちがあるか判断
                    if (ServerSocket.Pending() == true)
                    {
                        // AllDoneを非シグナル状態にする
                        // すなわち、スレッドの実行指示の状態をリセットして戻す。
                        AllDone.Reset();

                        // ﾜｰｶｰｽﾚｯﾄﾞでの処理終了時に起動するｺｰﾙﾊﾞｯｸﾒｿｯﾄﾞを指定
                        AsyncCallback asc = new AsyncCallback(ReturnCallback);

                        // スレッドを起動し、送受信電文処理スレッド用メソッドを実行します。
                        IAsyncResult AsyRes = Caller.BeginInvoke(ServerSocket, asc, null);

                        // AllDoneがシグナル状態になるまでスレッドをブロック。
                        // すなわち、送受信電文処理用スレッドから、実行開始の指示が出るまで待機する。
                        AllDone.WaitOne();
                    }

                    // 短時間だけ待機
                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "ListeningCallback ERROR = " + ex.Message);
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ListeningCallback <<--");
            }
        }

        /// <summary>
        // スレッド完了時起動のコールバックメソッド
        // BeginInvokeでの呼び出し(非同期呼び出し)で起動されたスレッドにおいて、
        // その処理が完了した時に、呼び出し元に呼び出されるメソッドです。
        // よって、ワーカースレッド(BeginInvokeで呼び出されるスレッド)での
        // 処理結果に関する処理等をここに定義すると便利です。
        // 第1引数: 非同期ﾃﾞﾘｹﾞｰﾄでの非同期操作の結果(をカプセル化した物)
        /// </summary>
        /// <param name="AsyRes"></param>
        /// <remarks></remarks>
        private void ReturnCallback(IAsyncResult AsyRes)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ReturnCallback -->>");

            try
            {
                //------------------------
                // EndInvoke を使って、非同期呼び出しによるスレッドから、返却値を取得する。
                //  --- スレッドの非同期呼び出しでの結果「AsyRes」はカプセル化されています。
                //      よって、処理結果を取り出すために、まず、結果AsyResをｷｬｽﾄする必要がある。

                // 結果を取り出すための非同期結果のキャスト。
                System.Runtime.Remoting.Messaging.AsyncResult aResult = (System.Runtime.Remoting.Messaging.AsyncResult)AsyRes;

                // 非同期の呼び出しが行われたデリゲートオブジェクトを取得。
                CommunicationCallbackDelegate dele = (CommunicationCallbackDelegate)aResult.AsyncDelegate;

                // EndInvoke()メソッドで、スレッドの完了処理を実行。
                // 及びワーカースレッドでの処理結果の受け取り。
                ProcessingResultOfCommunication ResultData = dele.EndInvoke(AsyRes);
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "ReturnCallback ERROR = " + ex.Message);
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ReturnCallback <<--");
            }
        }

        /// <summary>
        /// ハンディからの受信データを元にアプリ側から情報を取得して
        /// 戻り値にセット
        /// </summary>
        /// <param name="rcvData"></param>
        /// <remarks></remarks>
        private byte[] APLCom(byte[] rcvData)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "APLCom -->>");

            try
            {
                byte[] reply = null;

                // ソケット処理区分を取得(必ず先頭4byteを使用しセットされる値)
                Encoding Encd = System.Text.Encoding.GetEncoding("Shift_JIS");
                string SocketSyoriKbn = Encd.GetString(rcvData, 0, SOCKET_SYORI_KBN_LEN);

                //機能ごとに処理分岐
                switch (Int32.Parse(SocketSyoriKbn))
                {
                    // ログイン情報取得
                    case clsBtConst.SCKSYRKBN_GET_LOGININFO:

                        reply = GetLoginInfo(rcvData);
                        break;

                    // 商品情報取得
                    case clsBtConst.SCKSYRKBN_GET_SYOHININFO:

                        reply = GetSyohinInfo(rcvData);
                        break;

                    // 伝票情報取得 伝票検品
                    case clsBtConst.SCKSYRKBN_GET_SLIPINFO_MDDENPYOU:
                    // 伝票情報取得 一括検品
                    case clsBtConst.SCKSYRKBN_GET_SLIPINFO_MDIKKATSU:

                        reply = GetSlipInfo(rcvData);
                        break;

                    // 在庫情報取得
                    case clsBtConst.SCKSYRKBN_GET_ZAIKOINFO:

                        reply = GetZaikoInfo(rcvData);
                        break;

                    // 伝票情報更新
                    case clsBtConst.SCKSYRKBN_INS_SLIPINFO:

                        reply = InsSlipInfo(rcvData);
                        break;

                    // 商品情報更新（バーコード）
                    case clsBtConst.SCKSYRKBN_INS_SYOHININFO_BARCODE:

                        reply = InsSyohinBar(rcvData);
                        break;

                    // 商品情報更新（数量）先行
                    case clsBtConst.SCKSYRKBN_INS_SYOHININFO_SU:

                        reply = InsSyohinSu(rcvData);
                        break;

                    // -- ADD 2017/08/01 ------------------------------>>>
                    // 在庫仕入(入庫更新)　伝票一覧取得
                    case clsBtConst.SCKSYRKBN_GET_NYU_SLIPLIST:

                        reply = GetNyuSlipList(rcvData);
                        break;
                    // 在庫仕入(入庫更新)　伝票情報取得
                    case clsBtConst.SCKSYRKBN_GET_NYU_SLIPINFO:

                        reply = GetNyuSlipInfo(rcvData);
                        break;
                    // 発注先一覧取得
                    case clsBtConst.SCKSYRKBN_GET_HACLIST:

                        reply = GetHacList(rcvData);
                        break;
                    // 検品データ登録(在庫仕入　入庫更新)
                    case clsBtConst.SCKSYRKBN_INS_NYU_SLIPINFO:

                        reply = InsNyuSlipInfo(rcvData);
                        break;
                    // 在庫仕入(UOE以外)　伝票情報取得
                    case clsBtConst.SCKSYRKBN_GET_NOTUOE_SLIPINFO:

                        reply = GetNotUoeSlipInfo(rcvData);
                        break;
                    // 検品データ登録(在庫仕入　UOE以外)
                    case clsBtConst.SCKSYRKBN_INS_NOTUOE_SLIPINFO:

                        reply = InsNotUoeSlipInfo(rcvData);
                        break;
                    // 在庫仕入(入荷/出荷)　伝票情報取得
                    case clsBtConst.SCKSYRKBN_GET_NYUSYU_SLIPINFO:

                        reply = GetNyuSyuSlipInfo(rcvData);
                        break;
                    // 検品データ登録(在庫仕入　入荷/出荷)
                    case clsBtConst.SCKSYRKBN_INS_NYUSYU_SLIPINFO:

                        reply = InsNyuSyuSlipInfo(rcvData);
                        break;
                    // 在庫移動(出荷/入荷)　伝票情報取得
                    case clsBtConst.SCKSYRKBN_GET_IDO_SLIPINFO:

                        reply = GetIdouSlipInfo(rcvData);
                        break;
                    // 検品データ登録(在庫移動　出荷/入荷)
                    case clsBtConst.SCKSYRKBN_INS_IDO_SLIPINFO:

                        reply = InsIdouSlipInfo(rcvData);
                        break;
                    // 倉庫情報取得
                    case clsBtConst.SCKSYRKBN_GET_SOKO_INFO:

                        reply = GetSokoInfo(rcvData);
                        break;
                    // 委託在庫補充　伝票情報取得
                    case clsBtConst.SCKSYRKBN_GET_ITAKU_SLIPINFO:

                        reply = GetItakuSlipInfo(rcvData);
                        break;
                    // 検品データ登録(委託在庫補充)
                    case clsBtConst.SCKSYRKBN_INS_ITAKU_SLIPINFO:

                        reply = InsItakuSlipInfo(rcvData);
                        break;
                    // 棚卸(一斉)情報存在確認
                    case clsBtConst.SCKSYRKBN_GET_TANA_ISSEICHECK:

                        reply = GetIsseiCheck(rcvData);
                        break;
                    // 棚卸(一斉)情報取得
                    case clsBtConst.SCKSYRKBN_GET_TANA_ISSEIINFO:

                        reply = GetIsseiInfo(rcvData);
                        break;
                    // 棚卸データ登録(一斉)
                    case clsBtConst.SCKSYRKBN_INS_TANA_ISSEIINFO:

                        reply = InsGetIsseiInfo(rcvData);
                        break;
                    // 棚卸(循環)情報存在確認
                    case clsBtConst.SCKSYRKBN_GET_TANA_JYUNCHECK:

                        reply = GetJyunCheck(rcvData);
                        break;
                    // 棚卸(循環)情報取得
                    case clsBtConst.SCKSYRKBN_GET_TANA_JYUNINFO:

                        reply = GetJyunCheckInfo(rcvData);
                        break;
                    // 棚卸データ登録(循環)
                    case clsBtConst.SCKSYRKBN_INS_TANA_JYUNINFO:

                        reply = InsJyunCheckInfo(rcvData);
                        break;
                    // -- ADD 2017/08/01 ------------------------------<<<
                    // -- ADD 2019/10/16 ------------------------------>>>
                    // 倉庫リスト取得
                    case clsBtConst.SCKSYRKBN_GET_SOKO_LIST:

                        reply = GetSokoList(rcvData);
                        break;
                    // -- ADD 2019/10/16 ------------------------------<<<
                    // -- ADD 2020/04/17 ------------------------------>>>
                    // 倉庫情報取得（在庫登録用）
                    case clsBtConst.SCKSYRKBN_GET_SOKO_INFO_FOR_STOCK:

                        reply = GetSokoInfoForStock(rcvData);
                        break;
                    // -- ADD 2020/04/17 ------------------------------<<<
                    // -- ADD 2020/04/01 ------------------------------>>>
                    // 商品在庫登録検索（パターン検索）
                    case clsBtConst.SCKSYRKBN_GET_INS_ZAIKOINFO_PATURN:

                        reply = GetZaikoInfoPaturn(rcvData);
                        break;
                    // 商品在庫登録検索（品番検索）
                    case clsBtConst.SCKSYRKBN_GET_INS_ZAIKOINFO_GOODSNO:

                        reply = GetZaikoInfoGoodsNo(rcvData);
                        break;
                    // 商品在庫登録確定
                    case clsBtConst.SCKSYRKBN_INS_ZAIKO_INSERT:

                        reply = InsZaikoInfo(rcvData);
                        break;
                    // UOE発注データ存在チェック
                    case clsBtConst.SCKSYRKBN_CHK_UOE_ORDER:

                        reply = ChkUoeOrder(rcvData);
                        break;
                    // メーカー一覧取得
                    case clsBtConst.SCKSYRKBN_GET_MAKER_LIST:

                        reply = GetMakerList(rcvData);
                        break;
                    // メーカー情報取得
                    case clsBtConst.SCKSYRKBN_GET_MAKER_INFO:

                        reply = GetMakerInfo(rcvData);
                        break;
                    // 仕入先一覧取得
                    case clsBtConst.SCKSYRKBN_GET_SUPPLIER_LIST:

                        reply = GetSupplierList(rcvData);
                        break;
                    //仕入先情報取得
                    case clsBtConst.SCKSYRKBN_GET_SUPPLIER_INFO:

                        reply = GetsupplierInfo(rcvData);
                        break;
                    // -- ADD 2020/04/01 ------------------------------<<<
                    // --- ADD 2019/06/13 ---------->>>>>
                    // ファイル転送
                    case clsBtConst.SCKSYRKBN_FILE_TRANSFER:

                        reply = MoveFile(rcvData);
                        break;
                    // --- ADD 2019/06/13 ----------<<<<<
                }

                return reply;
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "APLCom ERROR = " + ex.Message);
                return null;
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "APLCom <<--");
            }
        }

        /// <summary>
        /// 対ＰＭＮＳ用通信準備
        /// </summary>
        /// <remarks></remarks>
        private void AplSet()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "AplSet -->>");

            try
            {
                // IPCセット
                _iPmHandy = (IPmHandy)Activator.GetObject(typeof(IPmHandy), clsCommon.gIpcAddress);

            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "AplSet ERROR = " + ex.Message);

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "AplSet <<--");
            }
        }

        /// <summary>
        /// 処理区分名称取得
        /// </summary>
        /// <remarks></remarks>
        private string GetSckSyrKbn(string argSckSyrKbn)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "GetSckSyrKbn -->>");

            try
            {
                string RetVal = string.Empty;

                if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_LOGININFO)
                {
                    RetVal = clsBtConst.STRING_GET_LOGININFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_SYOHININFO)
                {
                    RetVal = clsBtConst.STRING_GET_SYOHININFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_SLIPINFO_MDDENPYOU)
                {
                    RetVal = clsBtConst.STRING_GET_SLIPINFO_MDDENPYOU;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_SLIPINFO_MDIKKATSU)
                {
                    RetVal = clsBtConst.STRING_GET_SLIPINFO_MDIKKATSU;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_ZAIKOINFO)
                {
                    RetVal = clsBtConst.STRING_GET_ZAIKOINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_INS_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_SYOHININFO_BARCODE)
                {
                    RetVal = clsBtConst.STRING_INS_SYOHININFO_BARCODE;
                }   
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_SYOHININFO_SU)
                {
                    RetVal = clsBtConst.STRING_INS_SYOHININFO_SU;
                }
                // -- ADD 2017/08/01 ------------------------------>>>
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_NYU_SLIPLIST)
                {
                    RetVal = clsBtConst.STRING_GET_NYU_SLIPLIST;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_NYU_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_GET_NYU_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_HACLIST)
                {
                    RetVal = clsBtConst.STRING_GET_HACLIST;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_NYU_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_INS_NYU_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_NOTUOE_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_GET_NOTUOE_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_NOTUOE_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_INS_NOTUOE_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_NYUSYU_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_GET_NYUSYU_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_NYUSYU_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_INS_NYUSYU_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_IDO_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_GET_IDO_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_IDO_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_INS_IDO_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_SOKO_INFO)
                {
                    RetVal = clsBtConst.STRING_GET_SOKO_INFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_ITAKU_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_GET_ITAKU_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_ITAKU_SLIPINFO)
                {
                    RetVal = clsBtConst.STRING_INS_ITAKU_SLIPINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_TANA_ISSEICHECK)
                {
                    RetVal = clsBtConst.STRING_GET_TANA_ISSEICHECK;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_TANA_ISSEIINFO)
                {
                    RetVal = clsBtConst.STRING_GET_TANA_ISSEIINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_TANA_ISSEIINFO)
                {
                    RetVal = clsBtConst.STRING_INS_TANA_ISSEIINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_TANA_JYUNCHECK)
                {
                    RetVal = clsBtConst.STRING_GET_TANA_JYUNCHECK;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_TANA_JYUNINFO)
                {
                    RetVal = clsBtConst.STRING_GET_TANA_JYUNINFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_TANA_JYUNINFO)
                {
                    RetVal = clsBtConst.STRING_INS_TANA_JYUNINFO;
                }
                // -- ADD 2017/08/01 ------------------------------<<<
                // -- ADD 2019/11/13 ------------------------------>>>
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_SOKO_LIST)
                {
                    RetVal = clsBtConst.STRING_GET_SOKO_LIST;
                }
                // -- ADD 2019/11/13 ------------------------------>>>
                // -- ADD 2020/04/01 ------------------------------>>>
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_INS_ZAIKOINFO_PATURN)
                {
                    RetVal = clsBtConst.STRING_GET_INS_ZAIKOINFO_PATURN;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_INS_ZAIKOINFO_GOODSNO)
                {
                    RetVal = clsBtConst.STRING_GET_INS_ZAIKOINFO_GOODSNO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_INS_ZAIKO_INSERT)
                {
                    RetVal = clsBtConst.STRING_INS_ZAIKO_INSERT;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_CHK_UOE_ORDER)
                {
                    RetVal = clsBtConst.STRING_CHK_UOE_ORDER;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_MAKER_LIST)
                {
                    RetVal = clsBtConst.STRING_GET_MAKER_LIST;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_MAKER_INFO)
                {
                    RetVal = clsBtConst.STRING_GET_MAKER_INFO;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_SUPPLIER_LIST)
                {
                    RetVal = clsBtConst.STRING_GET_SUPPLIER_LIST;
                }
                else if (Int32.Parse(argSckSyrKbn) == clsBtConst.SCKSYRKBN_GET_SUPPLIER_INFO)
                {
                    RetVal = clsBtConst.STRING_GET_SUPPLIER_INFO;
                }
                // -- ADD 2020/04/01 ------------------------------<<<
                else
                {
                    RetVal = null;
                }

                return RetVal;
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, "GetSckSyrKbn ERROR = " + ex.Message);
                return  ex.Message;
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "GetSckSyrKbn <<--");
            }
        }
#endregion

#region "機能単位の通信処理"

        #region "■SELECT ログイン情報取得"
        /// <summary>
        /// ログイン情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetLoginInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsLoginInfo logininfo = new clsLoginInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", logininfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                logininfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(logininfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(logininfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(logininfo.LoginId);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyLoginInfoCondWork LogincondObj = new HandyLoginInfoCondWork();
                LogincondObj.MachineName = logininfo.HtName.ToString().Trim();
                LogincondObj.LoginId = logininfo.LoginId.ToString().Trim();
                condObjs = LogincondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- MOD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchHandyLoginInfo(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);
                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyLoginInfo(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- MOD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                logininfo.IniOutArg();
                logininfo.RetVal = string.Empty;
                logininfo.RetVal = status.ToString();

                HandyLoginInfoWork LoginRetObj = new HandyLoginInfoWork();
                if (retObjs != null)
                {
                    LoginRetObj = (HandyLoginInfoWork)retObjs;
                }

                //
                if (Int32.Parse(logininfo.RetVal.ToString()) == 0)
                {
                    logininfo.BaseCd = LoginRetObj.BelongSectionCode;
                    logininfo.BaseName = LoginRetObj.BelongSectionName;
                    logininfo.EmpCd = LoginRetObj.EmployeeCode;
                    logininfo.EmpName = LoginRetObj.Name;
                    logininfo.RetDate = LoginRetObj.RetirementDate.ToString();
                    logininfo.EntDate = LoginRetObj.EnterCompanyDate.ToString();
                    logininfo.AutLv1 = LoginRetObj.AuthorityLevel1.ToString();
                    logininfo.AutLv2 = LoginRetObj.AuthorityLevel2.ToString();
                    logininfo.KSokoCd = LoginRetObj.SectWarehouseCd1.ToString();
                    // -- ADD 2017/08/01 ------------------------------>>>
                    logininfo.ShiireOP = LoginRetObj.HandySupOp.ToString();
                    logininfo.SyanaiOP = LoginRetObj.HandyHouOp.ToString();
                    logininfo.ShiireShiharaiOP = LoginRetObj.SupPayManageOp.ToString();
                    logininfo.RollTanaOroshi = LoginRetObj.CycleCountRoll.ToString();
                    // -- ADD 2017/08/01 ------------------------------<<<
                    // -- ADD 2020/04/01 ------------------------------>>>
                    logininfo.ZaikoTourokuOP = LoginRetObj.HandyZaikoRegistOp.ToString();
                    // -- ADD 2020/04/01 ------------------------------<<<
                }

                //対ハンディ 送信
                reply = logininfo.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(logininfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 商品情報取得"
        /// <summary>
        /// 商品情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetSyohinInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSyohinInfo syohininfo = new clsSyohinInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", syohininfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                syohininfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(syohininfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(syohininfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(syohininfo.SokoCd);
                msgData.Append(syohininfo.Barcode);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                HandyStockCondWork SyohinCondObj = new HandyStockCondWork();
                SyohinCondObj.MachineName = syohininfo.HtName.ToString().Trim();
                SyohinCondObj.WarehouseCode = syohininfo.SokoCd.ToString().Trim();
                // -- ADD 2019/10/16 ------------------------------>>>
                //SyohinCondObj.CustomerGoodsCode = syohininfo.Barcode.ToString().Trim();
                if (syohininfo.Barcode.ToString().Trim() == "")
                {
                    SyohinCondObj.GoodsNo = syohininfo.SyoCd.ToString().Trim();
                }
                else
                {
                    SyohinCondObj.CustomerGoodsCode = syohininfo.Barcode.ToString().Trim();
                }
                // -- ADD 2019/10/16 ------------------------------<<<
                SyohinCondObj.EmployeeCode = syohininfo.EmpCd.ToString().Trim();

                condObjs = SyohinCondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchHandyStockInspect(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyStockInspect(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                syohininfo.IniOutArg();
                syohininfo.RetVal = string.Empty;
                syohininfo.RetVal = status.ToString();

                // -- ADD 2019/10/16 ------------------------------>>>
                //HandyStockWork SyohinRetObj = new HandyStockWork();
                //if (retObjs != null)
                //{
                //    SyohinRetObj = (HandyStockWork)retObjs;
                //}

                ////
                //if (Int32.Parse(syohininfo.RetVal.ToString()) == 0)
                //{
                //    syohininfo.MakerCd = SyohinRetObj.GoodsMakerCd.ToString();
                //    syohininfo.MakerNm = SyohinRetObj.MakerName.ToString();
                //    syohininfo.SyoCd = SyohinRetObj.GoodsNo.ToString();
                //    syohininfo.SyoNm = SyohinRetObj.GoodsName.ToString();
                //    syohininfo.TanaNo = SyohinRetObj.WarehouseShelfNo.ToString();
                //    syohininfo.RtSokoCd = SyohinRetObj.WarehouseCode.ToString();
                //    syohininfo.SokoNm = SyohinRetObj.WarehouseName.ToString();
                //    syohininfo.ZaikoNum = SyohinRetObj.ShipmentPosCnt.ToString();
                //    syohininfo.LastUri = clsCommon.datFormat(SyohinRetObj.LastSalesDate);
                //    syohininfo.LastSir = clsCommon.datFormat(SyohinRetObj.LastStockDate);
                //}

                ////対ハンディ 送信
                //reply = syohininfo.RelayGetOutArg();

                Int32 ArgStpost = 0;
                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SyohinRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SyohinRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SyohinRetArray.Count == 0)
                {
                    syohininfo.SetRow = "-1";
                    syohininfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyStockWork SyohinRetObj in SyohinRetArray)
                {
                    row += 1;

                    if (Int32.Parse(syohininfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            syohininfo.SetRow = SyohinRetArray.Count.ToString();
                        }
                        else
                        {
                            syohininfo.SetRow = "0";
                        }

                        if (row == SyohinRetArray.Count)
                        {
                            intSetrow = (-1 * SyohinRetArray.Count);
                            syohininfo.SetRow = intSetrow.ToString();
                        }

                        syohininfo.MakerCd = SyohinRetObj.GoodsMakerCd.ToString();
                        syohininfo.MakerNm = SyohinRetObj.MakerName.ToString();
                        syohininfo.SyoCd = SyohinRetObj.GoodsNo.ToString();
                        syohininfo.SyoNm = SyohinRetObj.GoodsName.ToString();
                        syohininfo.TanaNo = SyohinRetObj.WarehouseShelfNo.ToString();
                        syohininfo.RtSokoCd = SyohinRetObj.WarehouseCode.ToString();
                        syohininfo.SokoNm = SyohinRetObj.WarehouseName.ToString();
                        syohininfo.ZaikoNum = SyohinRetObj.ShipmentPosCnt.ToString();
                        syohininfo.LastUri = clsCommon.datFormat(SyohinRetObj.LastSalesDate);
                        syohininfo.LastSir = clsCommon.datFormat(SyohinRetObj.LastStockDate);

                        syohininfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);
                // -- ADD 2019/10/16 ------------------------------<<<

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(syohininfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 伝票情報取得(伝票検品/一括検品)"
        /// <summary>
        /// 伝票情報取得(伝票検品/一括検品)
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSlipInfo slipinfo = new clsSlipInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", slipinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                slipinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(slipinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(slipinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(slipinfo.ProcDiv);
                msgData.Append(slipinfo.SlipNo);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInspectCondWork SlipcondObj = new HandyInspectCondWork();
                SlipcondObj.MachineName = slipinfo.HtName.ToString().Trim();
                SlipcondObj.EmployeeCode = slipinfo.EmpCd.ToString().Trim();
                SlipcondObj.ProcDiv = Int32.Parse(slipinfo.ProcDiv.ToString().Trim());
                SlipcondObj.SlipNum = slipinfo.SlipNo.ToString().Trim();
                condObjs = SlipcondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- 2019/06/13 ---------->>>>>
                    //if (Int32.Parse(slipinfo.SokSyoriKbn) == clsBtConst.SCKSYRKBN_GET_SLIPINFO_MDDENPYOU)
                    //{
                    //    // 伝票情報取得 伝票検品
                    //    // 対ＰＭＮＳ側検索する
                    //    status = _iPmHandy.SearchHandyInspectDataSlipNum(ref condObjs, out retObjs);
                    //}
                    //else
                    //{
                    //    // 伝票情報取得 一括検品
                    //    // 対ＰＭＮＳ側検索する
                    //    status = _iPmHandy.SearchHandyInspectDataTotal(ref condObjs, out retObjs);
                    //}
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            if (Int32.Parse(slipinfo.SokSyoriKbn) == clsBtConst.SCKSYRKBN_GET_SLIPINFO_MDDENPYOU)
                            {
                                // 伝票情報取得 伝票検品
                                // 対ＰＭＮＳ側検索する
                                status = _iPmHandy.SearchHandyInspectDataSlipNum(ref condObjs, out retObjs);
                            }
                            else
                            {
                                // 伝票情報取得 一括検品
                                // 対ＰＭＮＳ側検索する
                                status = _iPmHandy.SearchHandyInspectDataTotal(ref condObjs, out retObjs);
                            }

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<

                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                slipinfo.IniOutArg();
                slipinfo.RetVal = string.Empty;
                slipinfo.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    slipinfo.SetRow = "-1";
                    slipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyInspectWork SlipRetObj in SlipRetArray)
                {
                    row += 1;

                    if (Int32.Parse(slipinfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            slipinfo.TokuiNm = SlipRetObj.CustomerSnm;
                            slipinfo.SetRow = SlipRetArray.Count.ToString();
                        }
                        else
                        {
                            slipinfo.TokuiNm = string.Empty;
                            slipinfo.SetRow = "0";
                        }

                        if (row == SlipRetArray.Count)
                        {
                            intSetrow = (-1 * SlipRetArray.Count);
                            slipinfo.SetRow = intSetrow.ToString();
                        }

                        slipinfo.SktRtSlipNo = SlipRetObj.SlipNum;
                        slipinfo.SktRTSlipRow = SlipRetObj.RowNo.ToString();
                        slipinfo.SktMekerCd = SlipRetObj.MakerCd.ToString();
                        slipinfo.SktShouCd = SlipRetObj.GoodsNo;
                        slipinfo.SktShouNm = SlipRetObj.GoodsNameKana;
                        slipinfo.SktShukoNum = SlipRetObj.ShipmentCnt.ToString();
                        slipinfo.SktTanaNo = SlipRetObj.ShelfNo;
                        slipinfo.SktSokoCd = SlipRetObj.WarehouseCode;
                        slipinfo.SktUToriKbn = SlipRetObj.SalesOrderDivCd.ToString();
                        slipinfo.SktTokShouCd = SlipRetObj.GoodsBarCode;
                        slipinfo.SktCheckStus = SlipRetObj.InspectStatus.ToString();
                        slipinfo.SktCheckNum = SlipRetObj.InspectCnt.ToString();
                        slipinfo.SktCheckKbn = SlipRetObj.InspectCode.ToString();

                        slipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(slipinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 在庫情報取得"
        /// <summary>
        /// 在庫情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetZaikoInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsZaikoInfo zaikoinfo = new clsZaikoInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", zaikoinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                zaikoinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(zaikoinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(zaikoinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(zaikoinfo.SyoriKbn);
                msgData.Append(zaikoinfo.SokoCd);
                msgData.Append(zaikoinfo.Barcode);
                msgData.Append(zaikoinfo.MakerCd);
                msgData.Append(zaikoinfo.SyoCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyStockCondWork ZaikoCondObj = new HandyStockCondWork();
                ZaikoCondObj.MachineName = zaikoinfo.HtName.ToString().Trim();
                ZaikoCondObj.EmployeeCode = zaikoinfo.EmpCd.ToString().Trim();
                ZaikoCondObj.OpDiv = Int32.Parse(zaikoinfo.SyoriKbn.ToString().Trim());
                ZaikoCondObj.WarehouseCode = zaikoinfo.SokoCd.ToString().Trim();
                ZaikoCondObj.GoodsNo = zaikoinfo.SyoCd.ToString().Trim();
                ZaikoCondObj.GoodsMakerCd = Int32.Parse(zaikoinfo.MakerCd.ToString().Trim());
                ZaikoCondObj.CustomerGoodsCode = zaikoinfo.Barcode.ToString().Trim();
                ZaikoCondObj.WarehouseShelfNo = zaikoinfo.TanaNo.ToString().Trim();
                condObjs = ZaikoCondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchHandyStock(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyStock(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                zaikoinfo.IniOutArg();
                zaikoinfo.RetVal = string.Empty;
                zaikoinfo.RetVal = status.ToString();

                HandyStockWork ZaikoRetObj = new HandyStockWork();
                if (retObjs != null)
                {
                    ZaikoRetObj = (HandyStockWork)retObjs;
                }

                //
                if (Int32.Parse(zaikoinfo.RetVal.ToString()) == 0)
                {
                    zaikoinfo.RtMakerCd = ZaikoRetObj.GoodsMakerCd.ToString();
                    zaikoinfo.RtMakerNm = ZaikoRetObj.MakerName.ToString();
                    zaikoinfo.RtSyoCd = ZaikoRetObj.GoodsNo.ToString();
                    zaikoinfo.RtSyoNm = ZaikoRetObj.GoodsName.ToString();
                    zaikoinfo.RtTanaNo = ZaikoRetObj.WarehouseShelfNo.ToString();
                    zaikoinfo.RtSokoCd = ZaikoRetObj.WarehouseCode.ToString();
                    zaikoinfo.RtSokoNm = ZaikoRetObj.WarehouseName.ToString();
                    zaikoinfo.RtZaikoNum = ZaikoRetObj.ShipmentPosCnt.ToString();
                    zaikoinfo.RtLastUri = clsCommon.datFormat(ZaikoRetObj.LastSalesDate);
                    zaikoinfo.RtLastSir = clsCommon.datFormat(ZaikoRetObj.LastStockDate);
                }

                //対ハンディ 送信
                reply = zaikoinfo.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(zaikoinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 伝票情報更新"
        /// <summary>
        /// 伝票情報更新
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSlipInsert slipinsert = new clsSlipInsert();

            Int32 GetRow = 1;
            Int32 GetRowEnd = 1;
            Int32 StPost = 0;
            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                while (GetRow <= GetRowEnd)
                {
                    slipinsert.RelayGetHtInArg(rcvData, GetRow, ref StPost);

                    if (GetRow == 1)
                    {
                        // 受信日時(１回の処理単位で同じ時間を使用する)
                        msgYmdHms.Length = 0;
                        msgYmdHms.Append("【");
                        msgYmdHms.Append(slipinsert.HtName.Trim());
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(GetSckSyrKbn(slipinsert.SokSyoriKbn));
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        msgYmdHms.Append("】");

                        msgData.Length = 0;
                        msgData.Append(slipinsert.SyoriKbn);
                        msgData.Append(slipinsert.SlipNo);

                        msgInfo.Length = 0;
                        msgInfo.Append(msgYmdHms.ToString());
                        msgInfo.Append("APLCom（対ハンディ） 受信=");
                        msgInfo.Append(msgData.ToString());
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                        GetRowEnd = Int32.Parse(slipinsert.SetRow);
                    }

                    HandyInspectDataWork SlipInsCondObj = new HandyInspectDataWork();
                    SlipInsCondObj.MachineName = slipinsert.HtName.Trim();
                    SlipInsCondObj.EmployeeCode = slipinsert.EmpCd.Trim();
                    SlipInsCondObj.AcPaySlipCd = Int32.Parse(slipinsert.SyoriKbn.Trim());
                    SlipInsCondObj.AcPaySlipNum = slipinsert.SlipNo.Trim();
                    SlipInsCondObj.AcPaySlipRowNo = Int32.Parse(slipinsert.SlipRow.Trim());
                    SlipInsCondObj.GoodsMakerCd = Int32.Parse(slipinsert.MakerCd.ToString().Trim());
                    SlipInsCondObj.GoodsNo = slipinsert.SyoCd.Trim();
                    SlipInsCondObj.WarehouseCode = slipinsert.SokoCd.Trim();
                    SlipInsCondObj.InspectStatus = Int32.Parse(slipinsert.CheckStus.ToString().Trim());
                    SlipInsCondObj.InspectCode = Int32.Parse(slipinsert.CheckKbn.ToString().Trim());

                    if (slipinsert.CheckNum.ToString() == string.Empty)
                    {
                        SlipInsCondObj.InspectCnt = 0;
                    }
                    else
                    {
                        SlipInsCondObj.InspectCnt = double.Parse(slipinsert.CheckNum.ToString().Trim());
                    }

                    ListcondObjs.Add(SlipInsCondObj);

                    GetRow += 1;
                }

                condObjs = ListcondObjs;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側へ
                    //status = _iPmHandy.WriteInspectData(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteInspectData(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                slipinsert.IniOutArg();
                slipinsert.RetVal = string.Empty;
                slipinsert.RetVal = status.ToString();

                //対ハンディ 送信
                reply = slipinsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(slipinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2016/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2016/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 商品情報更新（バーコード）"
        /// <summary>
        /// 商品情報更新（バーコード）
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsSyohinBar(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsBarcodeInsert barcodeinsert = new clsBarcodeInsert();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                barcodeinsert.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(barcodeinsert.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(barcodeinsert.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(barcodeinsert.Barcode);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                GoodsBarCodeRevnWork BarcodeCondObj = new GoodsBarCodeRevnWork();
                BarcodeCondObj.MachineName = barcodeinsert.HtName.Trim();
                BarcodeCondObj.EmployeeCode = barcodeinsert.EmpCd.Trim();
                BarcodeCondObj.GoodsMakerCd = Int32.Parse(barcodeinsert.MakerCd.ToString().Trim());
                BarcodeCondObj.GoodsNo = barcodeinsert.SyoCd.Trim();
                BarcodeCondObj.GoodsBarCode = barcodeinsert.Barcode.Trim();
                BarcodeCondObj.GoodsBarCodeKind = Int32.Parse(barcodeinsert.BarcodeType.ToString().Trim());

                condObjs = BarcodeCondObj;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.InsertHandyGoodsBarCode(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.InsertHandyGoodsBarCode(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                barcodeinsert.IniOutArg();
                barcodeinsert.RetVal = string.Empty;
                barcodeinsert.RetVal = status.ToString();

                //対ハンディ 送信
                reply = barcodeinsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(barcodeinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 商品情報更新（数量）先行"
        /// <summary>
        /// 商品情報更新（数量）先行
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsSyohinSu(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSyohinInsert syohininsert = new clsSyohinInsert();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                syohininsert.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(syohininsert.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(syohininsert.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(syohininsert.SokoCd);
                msgData.Append(syohininsert.MakerCd);
                msgData.Append(syohininsert.SyoCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInspectDataWork SyouhinInsCondObj = new HandyInspectDataWork();
                SyouhinInsCondObj.MachineName = syohininsert.HtName;
                SyouhinInsCondObj.EmployeeCode = syohininsert.EmpCd;
                SyouhinInsCondObj.GoodsMakerCd = Int32.Parse(syohininsert.MakerCd.ToString());
                SyouhinInsCondObj.GoodsNo = syohininsert.SyoCd;
                SyouhinInsCondObj.WarehouseCode = syohininsert.SokoCd;
                SyouhinInsCondObj.InspectCode = Int32.Parse(syohininsert.KenpinKbn.ToString());
                if (syohininsert.KenpinNum.ToString() == string.Empty)
                {
                    SyouhinInsCondObj.InspectCnt = 0;
                }
                else
                {
                    SyouhinInsCondObj.InspectCnt = double.Parse(syohininsert.KenpinNum.ToString());
                }

                condObjs = SyouhinInsCondObj;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ----------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.WriteSenKouInspect(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteSenKouInspect(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }
                    // --- ADD 2019/06/13 -----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                syohininsert.IniOutArg();
                syohininsert.RetVal = string.Empty;
                syohininsert.RetVal = status.ToString();

                reply = syohininsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(syohininsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        // --- ADD 2019/10/16 ---------->>>>>
        /// <summary>
        /// ハンディターミナルUOE発注データ一覧情報（HTAP用）ワーク（拡張）
        /// </summary>
        private class HandyUOEOrderResultListWorkCstm : HandyUOEOrderResultListWork
        {
            /// <summary>処理区分</summary>
            private string _procDiv;

            /// <summary>処理区分プロパティ</summary>
            public string ProcDiv
            {
                get { return _procDiv; }
                set { _procDiv = value; }
            }
        }
        // --- ADD 2019/10/16 ----------<<<<<

        // -- ADD 2017/08/01 ------------------------------>>>
        #region "■SELECT 在庫仕入(入庫更新)　伝票一覧取得"
        /// <summary>
        /// 在庫仕入(入庫更新)　伝票一覧取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetNyuSlipList(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsNyuSlipList nyusliplist = new clsNyuSlipList();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", nyusliplist.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                nyusliplist.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(nyusliplist.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(nyusliplist.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(nyusliplist.ProcDiv);
                msgData.Append(nyusliplist.HacCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                // -- UPD 2019/10/16 ------------------------------>>> 
                ////対ＰＭＮＳ　条件セット
                //HandyUOEOrderListParamWork NyuListcondObj = new HandyUOEOrderListParamWork();
                //NyuListcondObj.MachineName = nyusliplist.HtName.ToString().Trim();
                //NyuListcondObj.EmployeeCode = nyusliplist.EmpCd.ToString().Trim();
                //NyuListcondObj.OpDiv = Int32.Parse(nyusliplist.ProcDiv.ToString().Trim());
                //NyuListcondObj.SupplierCode = Int32.Parse(nyusliplist.HacCd);
                //condObjs = NyuListcondObj;
                //retObjs = null;

                //status = 0;
                //try
                //{
                //    // --- ADD 2019/06/13 ---------->>>>>
                //    // 対ＰＭＮＳ側検索する
                //    //status = _iPmHandy.SearchHandyStockSupplierList(ref condObjs, out retObjs);
                //    int retryTimes = 0;
                //    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                //    int retryInterval = 0;
                //    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                //    for (int i = 0; i <= retryTimes; i++)
                //    {
                //        try
                //        {
                //            status = _iPmHandy.SearchHandyStockSupplierList(ref condObjs, out retObjs);

                //            if (status == 0)
                //            {
                //                break;
                //            }
                //            else
                //            {
                //                if (i != 0)
                //                {
                //                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                //                }
                //            }

                //        }
                //        catch (Exception ex)
                //        {
                //            status = -1;

                //            if (i != 0)
                //            {
                //                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                //            }
                //            else
                //            {
                //                LOGGER.Error(ex.Message);
                //            }

                //        }

                //        System.Threading.Thread.Sleep(retryInterval);
                //    }

                //    // --- ADD 2019/06/13 ----------<<<<<
                //}
                //catch (Exception ex)
                //{
                //    msgInfo.Length = 0;
                //    msgInfo.Append(msgYmdHms.ToString());
                //    msgInfo.Append("対ＰＭＮＳ エラー ");
                //    msgInfo.Append(ex.Message);

                //    LOGGER.Error(msgInfo.ToString());
                //    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                //}
                ArrayList resultArray = new ArrayList();
                Int32 statusPrev = -1;

                foreach (clsNyuSlipList.SearchKeyItem itm in nyusliplist.SearchItemList)
                {
                    HandyUOEOrderListParamWork NyuListcondObj = new HandyUOEOrderListParamWork();
                    NyuListcondObj.MachineName = nyusliplist.HtName.ToString().Trim();
                    NyuListcondObj.EmployeeCode = nyusliplist.EmpCd.ToString().Trim();
                    NyuListcondObj.OpDiv = Int32.Parse(itm.ProcDiv.ToString().Trim());
                    NyuListcondObj.SupplierCode = Int32.Parse(itm.HacCd);
                    condObjs = NyuListcondObj;
                    retObjs = null;

                    status = 0;
                    try
                    {
                        // 対ＰＭＮＳ側検索する
                        int retryTimes = 0;
                        int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                        int retryInterval = 0;
                        int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                        for (int i = 0; i <= retryTimes; i++)
                        {
                            try
                            {
                                status = _iPmHandy.SearchHandyStockSupplierList(ref condObjs, out retObjs);

                                if (status == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    if (i != 0)
                                    {
                                        LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                status = -1;

                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                                }
                                else
                                {
                                    LOGGER.Error(ex.Message);
                                }
                            }

                            System.Threading.Thread.Sleep(retryInterval);

                        }
                    }
                    catch (Exception ex)
                    {
                        msgInfo.Length = 0;
                        msgInfo.Append(msgYmdHms.ToString());
                        msgInfo.Append("対ＰＭＮＳ エラー ");
                        msgInfo.Append(ex.Message);

                        LOGGER.Error(msgInfo.ToString());
                        status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                    }

                    ArrayList arr = new ArrayList();
                    if (retObjs != null)
                    {
                        arr = (ArrayList)retObjs;
                    }

                    foreach (HandyUOEOrderResultListWork rowItem in arr)
                    {
                        HandyUOEOrderResultListWorkCstm rsltItm = new HandyUOEOrderResultListWorkCstm();

                        rsltItm.ProcDiv = itm.ProcDiv.ToString().Trim();
                        rsltItm.SlipNo = rowItem.SlipNo;
                        rsltItm.UoeRemark1 = rowItem.UoeRemark1;
                        rsltItm.OnlineNo = rowItem.OnlineNo;
                        rsltItm.UOESalesOrderNo = rowItem.UOESalesOrderNo;
                        rsltItm.WarehousingDivCd = rowItem.WarehousingDivCd;

                        resultArray.Add(rsltItm);
                    }

                    //エラーもしくはタイムアウトが発生した場合、データ取得処理を終了する。
                    if ((status == ((int)clsBtConst.enumStatus.Error)) || (status == ((int)clsBtConst.enumStatus.Timeout)))
                    {
                        break;
                    }

                    //前回のデータ取得に成功している場合、ステータスは成功とする。
                    if ((statusPrev == ((int)clsBtConst.enumStatus.Nomal)) && (status == ((int)clsBtConst.enumStatus.NotFound)))
                    {
                        status = (int)clsBtConst.enumStatus.Nomal;
                    }

                    //前回のステータスを保存
                    statusPrev = status;
                }
                retObjs = resultArray;
                // -- UPD 2019/10/16 ------------------------------<<<

                // 対ＰＭＮＳ　戻り値
                nyusliplist.IniOutArg();
                nyusliplist.RetVal = string.Empty;
                nyusliplist.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    nyusliplist.SetSlip = "-1";
                    nyusliplist.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyUOEOrderResultListWorkCstm SlipRetObj in SlipRetArray)
                {
                    row += 1;

                    //１行目処理
                    if (row == 1)
                    {
                        nyusliplist.SetSlip = SlipRetArray.Count.ToString();
                    }
                    else
                    {
                        nyusliplist.SetSlip = "0";
                    }

                    if (row == SlipRetArray.Count)
                    {
                        intSetrow = (-1 * SlipRetArray.Count);
                        nyusliplist.SetSlip = intSetrow.ToString();
                    }

                    nyusliplist.RtSlipNo = SlipRetObj.SlipNo;
                    nyusliplist.RtReMark = SlipRetObj.UoeRemark1;
                    nyusliplist.RtOnLineNo = SlipRetObj.OnlineNo.ToString();
                    nyusliplist.RtUoeHacNo = SlipRetObj.UOESalesOrderNo.ToString();
                    nyusliplist.RtNyukoKbn = SlipRetObj.WarehousingDivCd.ToString();
                    nyusliplist.ProcDiv = SlipRetObj.ProcDiv.ToString();

                    nyusliplist.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(nyusliplist.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        // --- ADD 2019/06/13 ---------->>>>>
        /// public private name:   HandyUOEOrderResultDtlWorkCstm
        /// <summary>
        ///                      ハンディターミナル在庫仕入（入庫更新）_明細情報ワーク（HT/APサーバー用）ワーク（拡張）
        /// </summary>
        /// <remarks>
        /// <br>note             :   ハンディターミナル在庫仕入（入庫更新）_明細情報ワーク（HT/APサーバー用）ワークヘッダファイル（ヘッダ情報付き）</br>
        /// <br>Programmer       :   自動生成</br>
        /// <br>Date             :   2019/06/13</br>
        /// <br>Genarated Date   :   2019/06/13  (CSharp File Generated Date)</br>
        /// </remarks>
        private class HandyUOEOrderResultDtlWorkCstm : HandyUOEOrderResultDtlWork
        {
            /// <summary>伝票番号</summary>
            private string _slipNo;
            /// <summary>オンライン番号</summary>
            private string _onlineNo;
            /// <summary>UOE発注番号</summary>
            private string _uoeHacNo;
            /// <summary>入庫区分</summary>
            private string _nyukoKbn;
            // -- ADD 2019/10/16 ------------------------------>>>
            /// <summary>処理区分</summary>
            private string _procDivDtl;
            // -- ADD 2019/10/16 ------------------------------<<<

            /// public propaty name  :  SlipNo
            /// <summary>伝票番号プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   伝票番号プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public string SlipNo
            {
                get { return _slipNo; }
                set { _slipNo = value; }
            }
            /// public propaty name  :  OnlineNo
            /// <summary>オンライン番号プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   オンライン番号プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public string OnlineNo
            {
                get { return _onlineNo; }
                set { _onlineNo = value; }
            }
            /// public propaty name  :  UoeHacNo
            /// <summary>ＵＯＥ発注番号プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ＵＯＥ発注番号プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public string UoeHacNo
            {
                get { return _uoeHacNo; }
                set { _uoeHacNo = value; }
            }
            /// public propaty name  :  NyukoKbn
            /// <summary>入庫区分プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   入庫区分プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public string NyukoKbn
            {
                get { return _nyukoKbn; }
                set { _nyukoKbn = value; }
            }
            // -- ADD 2019/10/16 ------------------------------>>>
            /// public propaty name  :  ProcDiv
            /// <summary>処理区分プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   処理区分プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public string ProcDivDtl
            {
                get { return _procDivDtl; }
                set { _procDivDtl = value; }
            }
            // -- ADD 2019/10/16 ------------------------------<<<
        }
        // --- ADD 2019/06/13 ----------<<<<<


        #region "■SELECT 在庫仕入(入庫更新)　伝票情報取得"
        /// <summary>
        /// 在庫仕入(入庫更新)　伝票情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetNyuSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsNyuSlipInfo nyuslipinfo = new clsNyuSlipInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", nyuslipinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                nyuslipinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(nyuslipinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(nyuslipinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(nyuslipinfo.ProcDiv);
                msgData.Append(nyuslipinfo.OnLineNo);
                msgData.Append(nyuslipinfo.UoeHacNo);
                msgData.Append(nyuslipinfo.NyukoKbn);
                // --- ADD 2019/06/13 ---------->>>>>
                msgData.Append(nyuslipinfo.SlipNo);
                // --- ADD 2019/06/13 ----------<<<<<

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                // --- MOD 2019/06/13 ---------->>>>>
                //HandyUOEOrderDtlParamWork NyuInfocondObj = new HandyUOEOrderDtlParamWork();
                //NyuInfocondObj.MachineName = nyuslipinfo.HtName.ToString().Trim();
                //NyuInfocondObj.EmployeeCode = nyuslipinfo.EmpCd.ToString().Trim();
                //NyuInfocondObj.OpDiv = Int32.Parse(nyuslipinfo.ProcDiv.ToString().Trim());
                //NyuInfocondObj.OnlineNo = Int32.Parse(nyuslipinfo.OnLineNo.ToString().Trim());
                //NyuInfocondObj.UOESalesOrderNo = Int32.Parse(nyuslipinfo.UoeHacNo.ToString().Trim());
                //NyuInfocondObj.WarehousingDivCd = Int32.Parse(nyuslipinfo.NyukoKbn.ToString().Trim());
                //// --- ADD 2019/06/13 ---------->>>>>
                //NyuInfocondObj.SlipNo = Int32.Parse(nyuslipinfo.SlipNo.ToString().Trim());
                //// --- ADD 2019/06/13 ----------<<<<<
                //condObjs = NyuInfocondObj;
                //retObjs = null;

                //status = 0;
                //try
                //{
                //    // 対ＰＭＮＳ側検索する
                //    status = _iPmHandy.SearchHandyStockSupplierSlipNum(ref condObjs, out retObjs);
                //}
                //catch (Exception ex)
                //{
                //    msgInfo.Length = 0;
                //    msgInfo.Append(msgYmdHms.ToString());
                //    msgInfo.Append("対ＰＭＮＳ エラー ");
                //    msgInfo.Append(ex.Message);

                //    LOGGER.Error(msgInfo.ToString());
                //    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                //}
                if (nyuslipinfo.SearchItemList != null && nyuslipinfo.SearchItemList.Count > 1)
                {
                    ArrayList resultArray = new ArrayList();

                    foreach (clsNyuSlipInfo.SearchKeyItem itm in nyuslipinfo.SearchItemList)
                    {
                        HandyUOEOrderDtlParamWork NyuInfocondObj = new HandyUOEOrderDtlParamWork();
                        NyuInfocondObj.MachineName = nyuslipinfo.HtName.ToString().Trim();
                        NyuInfocondObj.EmployeeCode = nyuslipinfo.EmpCd.ToString().Trim();
                        NyuInfocondObj.OpDiv = Int32.Parse(nyuslipinfo.ProcDiv.ToString().Trim());
                        NyuInfocondObj.OnlineNo = Int32.Parse(itm.OnlineNo.ToString().Trim());
                        NyuInfocondObj.UOESalesOrderNo = Int32.Parse(itm.UoeHacNo.ToString().Trim());
                        NyuInfocondObj.WarehousingDivCd = Int32.Parse(itm.NyukoKbn.ToString().Trim());
                        NyuInfocondObj.SlipNo = itm.SlipNo.ToString().Trim();
                        condObjs = NyuInfocondObj;
                        retObjs = null;

                        status = 0;
                        try
                        {
                            // --- ADD 2019/06/13 ---------->>>>>
                            // 対ＰＭＮＳ側検索する
                            //status = _iPmHandy.SearchHandyStockSupplierSlipNum(ref condObjs, out retObjs);
                            int retryTimes = 0;
                            int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                            int retryInterval = 0;
                            int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                            for (int i = 0; i <= retryTimes; i++)
                            {
                                try
                                {
                                    status = _iPmHandy.SearchHandyStockSupplierSlipNum(ref condObjs, out retObjs);

                                    if (status == 0)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (i != 0)
                                        {
                                            LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    status = -1;

                                    if (i != 0)
                                    {
                                        LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                                    }
                                    else
                                    {
                                        LOGGER.Error(ex.Message);
                                    }
                                }

                                System.Threading.Thread.Sleep(retryInterval);

                            }
                            // --- ADD 2019/06/13 ----------<<<<<
                        }
                        catch (Exception ex)
                        {
                            msgInfo.Length = 0;
                            msgInfo.Append(msgYmdHms.ToString());
                            msgInfo.Append("対ＰＭＮＳ エラー ");
                            msgInfo.Append(ex.Message);

                            LOGGER.Error(msgInfo.ToString());
                            status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                        }


                        ArrayList arr = new ArrayList();
                        if (retObjs != null)
                        {
                            arr = (ArrayList)retObjs;
                        }

                        foreach (HandyUOEOrderResultDtlWork rowItem in arr)
                        {
                            HandyUOEOrderResultDtlWorkCstm rsltItm = new HandyUOEOrderResultDtlWorkCstm();

                            // ヘッダ情報の設定
                            rsltItm.SlipNo = itm.SlipNo;
                            rsltItm.UoeHacNo = itm.UoeHacNo;
                            rsltItm.OnlineNo = itm.OnlineNo;
                            rsltItm.NyukoKbn = itm.NyukoKbn;
                            // -- ADD 2019/10/16 ------------------------------>>>
                            rsltItm.ProcDivDtl = itm.ProcDivDtl;
                            // -- ADD 2019/10/16 ------------------------------<<<

                            // 明細情報の設定
                            rsltItm.GoodsBarCode = rowItem.GoodsBarCode;
                            rsltItm.GoodsMakerCd = rowItem.GoodsMakerCd;
                            rsltItm.GoodsName = rowItem.GoodsName;
                            rsltItm.GoodsNo = rowItem.GoodsNo;
                            rsltItm.StockCount = rowItem.StockCount;
                            rsltItm.StockSlipDtlNum = rowItem.StockSlipDtlNum;
                            rsltItm.SupplierSnm = rowItem.SupplierSnm;
                            rsltItm.WarehouseCode = rowItem.WarehouseCode;
                            rsltItm.WarehouseShelfNo = rowItem.WarehouseShelfNo;

                            resultArray.Add(rsltItm);
                        }

                    }

                    retObjs = resultArray;

                }
                else
                {
                    HandyUOEOrderDtlParamWork NyuInfocondObj = new HandyUOEOrderDtlParamWork();
                    NyuInfocondObj.MachineName = nyuslipinfo.HtName.ToString().Trim();
                    NyuInfocondObj.EmployeeCode = nyuslipinfo.EmpCd.ToString().Trim();
                    NyuInfocondObj.OpDiv = Int32.Parse(nyuslipinfo.ProcDiv.ToString().Trim());
                    NyuInfocondObj.OnlineNo = Int32.Parse(nyuslipinfo.OnLineNo.ToString().Trim());
                    NyuInfocondObj.UOESalesOrderNo = Int32.Parse(nyuslipinfo.UoeHacNo.ToString().Trim());
                    NyuInfocondObj.WarehousingDivCd = Int32.Parse(nyuslipinfo.NyukoKbn.ToString().Trim());
                    // --- ADD 2019/06/13 ---------->>>>>
                    NyuInfocondObj.SlipNo = nyuslipinfo.SlipNo.ToString().Trim();
                    ArrayList resultArray = new ArrayList();
                    // --- ADD 2019/06/13 ----------<<<<<
                    condObjs = NyuInfocondObj;
                    retObjs = null;

                    status = 0;
                    try
                    {
                        // --- ADD 2019/06/13 ---------->>>>>
                        // 対ＰＭＮＳ側検索する
                        //status = _iPmHandy.SearchHandyStockSupplierSlipNum(ref condObjs, out retObjs);
                        int retryTimes = 0;
                        int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                        int retryInterval = 0;
                        int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                        for (int i = 0; i <= retryTimes; i++)
                        {
                            try
                            {
                                status = _iPmHandy.SearchHandyStockSupplierSlipNum(ref condObjs, out retObjs);

                                if (status == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    if (i != 0)
                                    {
                                        LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                status = -1;

                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                                }
                                else
                                {
                                    LOGGER.Error(ex.Message);
                                }

                            }

                            System.Threading.Thread.Sleep(retryInterval);
                        }

                        ArrayList arr = new ArrayList();
                        if (retObjs != null)
                        {
                            arr = (ArrayList)retObjs;
                        }

                        foreach (HandyUOEOrderResultDtlWork rowItem in arr)
                        {
                            HandyUOEOrderResultDtlWorkCstm rsltItm = new HandyUOEOrderResultDtlWorkCstm();

                            // ヘッダ情報の設定
                            rsltItm.SlipNo = nyuslipinfo.SlipNo.ToString().Trim();
                            rsltItm.UoeHacNo = nyuslipinfo.UoeHacNo.ToString().Trim();
                            rsltItm.OnlineNo = nyuslipinfo.OnLineNo.ToString().Trim();
                            rsltItm.NyukoKbn = nyuslipinfo.NyukoKbn.ToString().Trim();
                            // -- ADD 2019/10/16 ------------------------------>>>
                            rsltItm.ProcDivDtl = nyuslipinfo.ProcDivDtl.ToString().Trim();
                            // -- ADD 2019/10/16 ------------------------------<<<

                            // 明細情報の設定
                            rsltItm.GoodsBarCode = rowItem.GoodsBarCode;
                            rsltItm.GoodsMakerCd = rowItem.GoodsMakerCd;
                            rsltItm.GoodsName = rowItem.GoodsName;
                            rsltItm.GoodsNo = rowItem.GoodsNo;
                            rsltItm.StockCount = rowItem.StockCount;
                            rsltItm.StockSlipDtlNum = rowItem.StockSlipDtlNum;
                            rsltItm.SupplierSnm = rowItem.SupplierSnm;
                            rsltItm.WarehouseCode = rowItem.WarehouseCode;
                            rsltItm.WarehouseShelfNo = rowItem.WarehouseShelfNo;

                            resultArray.Add(rsltItm);
                        }
                        retObjs = resultArray;
                        // --- ADD 2019/06/13 ----------<<<<<
                    }
                    catch (Exception ex)
                    {
                        msgInfo.Length = 0;
                        msgInfo.Append(msgYmdHms.ToString());
                        msgInfo.Append("対ＰＭＮＳ エラー ");
                        msgInfo.Append(ex.Message);

                        LOGGER.Error(msgInfo.ToString());
                        status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                    }

                }
                

                // --- MOD 2019/06/13 ----------<<<<<

                // 対ＰＭＮＳ　戻り値
                nyuslipinfo.IniOutArg();
                nyuslipinfo.RetVal = string.Empty;
                nyuslipinfo.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    nyuslipinfo.SetRow = "-1";
                    nyuslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                // --- MOD 2019/06/13 ---------->>>>>
                //foreach (HandyUOEOrderResultDtlWork SlipRetObj in SlipRetArray)
                foreach (HandyUOEOrderResultDtlWorkCstm SlipRetObj in SlipRetArray)
                // --- MOD 2019/06/13 ----------<<<<<
                {
                    row += 1;

                    if (Int32.Parse(nyuslipinfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            nyuslipinfo.RtSirNm = SlipRetObj.SupplierSnm;
                            nyuslipinfo.SetRow = SlipRetArray.Count.ToString();
                        }
                        else
                        {
                            nyuslipinfo.SetRow = "0";
                        }

                        if (row == SlipRetArray.Count)
                        {
                            intSetrow = (-1 * SlipRetArray.Count);
                            nyuslipinfo.SetRow = intSetrow.ToString();
                        }

                        nyuslipinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                        nyuslipinfo.RtSyoCd = SlipRetObj.GoodsNo;
                        nyuslipinfo.RtSyoNm = SlipRetObj.GoodsName;
                        nyuslipinfo.RtSokoCd = SlipRetObj.WarehouseCode;
                        nyuslipinfo.RtBarCode = SlipRetObj.GoodsBarCode;
                        nyuslipinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                        nyuslipinfo.RtSirSeqNo = SlipRetObj.StockSlipDtlNum.ToString();
                        nyuslipinfo.RtSirNum = SlipRetObj.StockCount.ToString();
                        // --- ADD 2019/06/13 ---------->>>>>
                        nyuslipinfo.OnLineNo = SlipRetObj.OnlineNo;
                        nyuslipinfo.UoeHacNo = SlipRetObj.UoeHacNo;
                        nyuslipinfo.NyukoKbn = SlipRetObj.NyukoKbn;
                        nyuslipinfo.SlipNo = SlipRetObj.SlipNo;
                        // --- ADD 2019/06/13 ----------<<<<<
                        // -- ADD 2019/10/16 ------------------------------>>>
                        nyuslipinfo.ProcDivDtl = SlipRetObj.ProcDivDtl;
                        // -- ADD 2019/10/16 ------------------------------<<<

                        nyuslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(nyuslipinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                // エラーメッセージをログ出力
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 発注先一覧取得"
        /// <summary>
        /// 発注先一覧取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetHacList(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsHacList haclist = new clsHacList();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", haclist.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                haclist.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(haclist.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(haclist.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                SupplierGuideParamWork HacListcondObj = new SupplierGuideParamWork();
                HacListcondObj.MachineName = haclist.HtName.ToString().Trim();
                HacListcondObj.EmployeeCode = haclist.EmpCd.ToString().Trim();
                condObjs = HacListcondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchHandySupplierGuide(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandySupplierGuide(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                    // --- ADD 2019/06/13 ----------<<<<<

                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                haclist.IniOutArg();
                haclist.RetVal = string.Empty;
                haclist.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList HacRetArray = new ArrayList();
                if (retObjs != null)
                {
                    HacRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (HacRetArray.Count == 0)
                {
                    haclist.SetRow = "-1";
                    haclist.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (SupplierGuideResultWork HacRetObj in HacRetArray)
                {
                    row += 1;

                    if (Int32.Parse(haclist.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            haclist.SetRow = HacRetArray.Count.ToString();
                        }
                        else
                        {
                            haclist.SetRow = "0";
                        }

                        if (row == HacRetArray.Count)
                        {
                            intSetrow = (-1 * HacRetArray.Count);
                            haclist.SetRow = intSetrow.ToString();
                        }

                        haclist.RtHacCd = HacRetObj.UOESupplierCd.ToString();
                        haclist.RtHacNm = HacRetObj.UOESupplierName;

                        haclist.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                //対ハンディ 送信
                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(haclist.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 検品データ登録(在庫仕入　入庫更新)"
        /// <summary>
        /// 検品データ登録(在庫仕入　入庫更新)
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsNyuSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsNyuSlipInsert nyuslipinsert = new clsNyuSlipInsert();

            Int32 GetRow = 1;
            Int32 GetRowEnd = 1;
            Int32 StPost = 0;
            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                while (GetRow <= GetRowEnd)
                {
                    nyuslipinsert.RelayGetHtInArg(rcvData, GetRow, ref StPost);

                    if (GetRow == 1)
                    {
                        // 受信日時(１回の処理単位で同じ時間を使用する)
                        msgYmdHms.Length = 0;
                        msgYmdHms.Append("【");
                        msgYmdHms.Append(nyuslipinsert.HtName.Trim());
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(GetSckSyrKbn(nyuslipinsert.SokSyoriKbn));
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        msgYmdHms.Append("】");

                        msgData.Length = 0;
                        msgData.Append(nyuslipinsert.ProcDiv);
                        msgData.Append(nyuslipinsert.HacCd);
                        msgData.Append(nyuslipinsert.NyuKbn);

                        msgInfo.Length = 0;
                        msgInfo.Append(msgYmdHms.ToString());
                        msgInfo.Append("APLCom（対ハンディ） 受信=");
                        msgInfo.Append(msgData.ToString());
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                        GetRowEnd = Int32.Parse(nyuslipinsert.SetRow);
                    }

                    //対ＰＭＮＳ　条件セット
                    InspectDataAddWork NyuSlipInsCondObj = new InspectDataAddWork();
                    NyuSlipInsCondObj.MachineName = nyuslipinsert.HtName;
                    NyuSlipInsCondObj.EmployeeCode = nyuslipinsert.EmpCd;
                    NyuSlipInsCondObj.OpDiv = Int32.Parse(nyuslipinsert.ProcDiv);
                    NyuSlipInsCondObj.UOESupplierCd = Int32.Parse(nyuslipinsert.HacCd);
                    NyuSlipInsCondObj.StockSlipDtlNum = long.Parse(nyuslipinsert.SlipRow);
                    NyuSlipInsCondObj.WarehousingDivCd = Int32.Parse(nyuslipinsert.NyuKbn);
                    NyuSlipInsCondObj.GoodsMakerCd = Int32.Parse(nyuslipinsert.MakerCd);
                    NyuSlipInsCondObj.GoodsNo = nyuslipinsert.SyoCd;
                    NyuSlipInsCondObj.WarehouseCode = nyuslipinsert.SokoCd;
                    NyuSlipInsCondObj.InspectStatus = Int32.Parse(nyuslipinsert.CheckStus);
                    NyuSlipInsCondObj.InspectCode = Int32.Parse(nyuslipinsert.CheckKbn);
                    if (nyuslipinsert.CheckNum.ToString() == string.Empty)
                    {
                        NyuSlipInsCondObj.InspectCnt = 0;
                    }
                    else
                    {
                        NyuSlipInsCondObj.InspectCnt = double.Parse(nyuslipinsert.CheckNum.ToString());
                    }
                    NyuSlipInsCondObj.UpdateDiv = Int32.Parse(nyuslipinsert.UpdKbn);

                    ListcondObjs.Add(NyuSlipInsCondObj);

                    GetRow += 1;
                }

                condObjs = ListcondObjs;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.WriteHandyStockSupplier(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteHandyStockSupplier(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryTimes);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                nyuslipinsert.IniOutArg();
                nyuslipinsert.RetVal = string.Empty;
                nyuslipinsert.RetVal = status.ToString();

                reply = nyuslipinsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(nyuslipinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 在庫仕入(UOE以外)　伝票情報取得"
        /// <summary>
        /// 在庫仕入(UOE以外)　伝票情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetNotUoeSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsNotUoeSlipInfo notuoeslipinfo = new clsNotUoeSlipInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", notuoeslipinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                notuoeslipinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(notuoeslipinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(notuoeslipinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(notuoeslipinfo.ProcDiv);
                msgData.Append(notuoeslipinfo.SlipNo);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyNonUOEStockParamWork NonUOEInfocondObj = new HandyNonUOEStockParamWork();
                NonUOEInfocondObj.MachineName = notuoeslipinfo.HtName.ToString().Trim();
                NonUOEInfocondObj.EmployeeCode = notuoeslipinfo.EmpCd.ToString().Trim();
                NonUOEInfocondObj.OpDiv = Int32.Parse(notuoeslipinfo.ProcDiv.ToString().Trim());
                NonUOEInfocondObj.SlipNo = Int32.Parse(notuoeslipinfo.SlipNo.ToString().Trim());
                condObjs = NonUOEInfocondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchHandyNonUOEStockSupplier(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyNonUOEStockSupplier(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                notuoeslipinfo.IniOutArg();
                notuoeslipinfo.RetVal = string.Empty;
                notuoeslipinfo.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    notuoeslipinfo.SetRow = "-1";
                    notuoeslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyNonUOEStockResultWork SlipRetObj in SlipRetArray)
                {
                    row += 1;

                    if (Int32.Parse(notuoeslipinfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            notuoeslipinfo.RtSirNm = SlipRetObj.SupplierSnm;
                            notuoeslipinfo.SetRow = SlipRetArray.Count.ToString();
                        }
                        else
                        {
                            notuoeslipinfo.SetRow = "0";
                        }

                        if (row == SlipRetArray.Count)
                        {
                            intSetrow = (-1 * SlipRetArray.Count);
                            notuoeslipinfo.SetRow = intSetrow.ToString();
                        }

                        notuoeslipinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                        notuoeslipinfo.RtSyoCd = SlipRetObj.GoodsNo;
                        notuoeslipinfo.RtSyoNm = SlipRetObj.GoodsName;
                        notuoeslipinfo.RtSokoCd = SlipRetObj.WarehouseCode;
                        notuoeslipinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                        notuoeslipinfo.RtBarCode = SlipRetObj.GoodsBarCode;
                        notuoeslipinfo.RtNyuNum = SlipRetObj.StockCount.ToString();
                        notuoeslipinfo.RtSirRowSeq = SlipRetObj.StockSlipDtlNum.ToString();

                        notuoeslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(notuoeslipinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 検品データ登録(在庫仕入　UOE以外)"
        /// <summary>
        /// 検品データ登録(在庫仕入　UOE以外)
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsNotUoeSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsNotUoeSlipInsert notuoeslipinsert = new clsNotUoeSlipInsert();

            Int32 GetRow = 1;
            Int32 GetRowEnd = 1;
            Int32 StPost = 0;
            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                while (GetRow <= GetRowEnd)
                {
                    notuoeslipinsert.RelayGetHtInArg(rcvData, GetRow, ref StPost);

                    if (GetRow == 1)
                    {
                        // 受信日時(１回の処理単位で同じ時間を使用する)
                        msgYmdHms.Length = 0;
                        msgYmdHms.Append("【");
                        msgYmdHms.Append(notuoeslipinsert.HtName.Trim());
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(GetSckSyrKbn(notuoeslipinsert.SokSyoriKbn));
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        msgYmdHms.Append("】");

                        msgData.Length = 0;
                        msgData.Append(notuoeslipinsert.ProcDiv);
                        msgData.Append(notuoeslipinsert.SirSeqNo);

                        msgInfo.Length = 0;
                        msgInfo.Append(msgYmdHms.ToString());
                        msgInfo.Append("APLCom（対ハンディ） 受信=");
                        msgInfo.Append(msgData.ToString());
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                        GetRowEnd = Int32.Parse(notuoeslipinsert.SetRow);
                    }

                    //対ＰＭＮＳ　条件セット
                    HandyNonUOEInspectParamWork NonUOESlipInsCondObj = new HandyNonUOEInspectParamWork();
                    NonUOESlipInsCondObj.MachineName = notuoeslipinsert.HtName;
                    NonUOESlipInsCondObj.EmployeeCode = notuoeslipinsert.EmpCd;
                    NonUOESlipInsCondObj.OpDiv = Int32.Parse(notuoeslipinsert.ProcDiv);
                    NonUOESlipInsCondObj.PartySaleSlipNum = notuoeslipinsert.SirSlipNo;
                    NonUOESlipInsCondObj.StockSlipDtlNum = Int32.Parse(notuoeslipinsert.SirRowSeq);
                    NonUOESlipInsCondObj.GoodsNo = notuoeslipinsert.SyoCd;
                    NonUOESlipInsCondObj.WarehouseCode = notuoeslipinsert.SokoCd;
                    NonUOESlipInsCondObj.InspectStatus = Int32.Parse(notuoeslipinsert.CheckStus);
                    NonUOESlipInsCondObj.InspectCode = Int32.Parse(notuoeslipinsert.CheckKbn);
                    if (notuoeslipinsert.MakerCd.ToString().Trim() == string.Empty)
                    {
                        NonUOESlipInsCondObj.GoodsMakerCd = 0;
                    }
                    else
                    {
                        NonUOESlipInsCondObj.GoodsMakerCd = Int32.Parse(notuoeslipinsert.MakerCd.ToString());
                    }
                    if (notuoeslipinsert.CheckNum.ToString().Trim() == string.Empty)
                    {
                        NonUOESlipInsCondObj.InspectCnt = 0;
                    }
                    else
                    {
                        NonUOESlipInsCondObj.InspectCnt = double.Parse(notuoeslipinsert.CheckNum.ToString());
                    }
                    if (notuoeslipinsert.SirSeqNo.ToString().Trim() == string.Empty)
                    {
                        NonUOESlipInsCondObj.SupplierSlipNo = 0;
                    }
                    else
                    {
                        NonUOESlipInsCondObj.SupplierSlipNo = Int32.Parse(notuoeslipinsert.SirSeqNo);
                    }
                    
                    ListcondObjs.Add(NonUOESlipInsCondObj);

                    GetRow += 1;
                }

                condObjs = ListcondObjs;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.WriteHandyNonUOEInspect(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteHandyNonUOEInspect(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }

                    // --- ADD 2019/06/13 ----------<<<<<
                
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                notuoeslipinsert.IniOutArg();
                notuoeslipinsert.RetVal = string.Empty;
                notuoeslipinsert.RetVal = status.ToString();

                reply = notuoeslipinsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(notuoeslipinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 在庫仕入(入荷/出荷)　伝票情報取得"
        /// <summary>
        /// 在庫仕入(入荷/出荷)　伝票情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetNyuSyuSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsNyuSyuSlipInfo nyusyuslipinfo = new clsNyuSyuSlipInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", nyusyuslipinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                nyusyuslipinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(nyusyuslipinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(nyusyuslipinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(nyusyuslipinfo.ProcDiv);
                msgData.Append(nyusyuslipinfo.SokoCd);
                msgData.Append(nyusyuslipinfo.BarCode);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyStockCondWork handystockInfocondObj = new HandyStockCondWork();
                handystockInfocondObj.MachineName = nyusyuslipinfo.HtName.ToString().Trim();
                handystockInfocondObj.EmployeeCode = nyusyuslipinfo.EmpCd.ToString().Trim();
                handystockInfocondObj.OpDiv = Int32.Parse(nyusyuslipinfo.ProcDiv.ToString().Trim());
                handystockInfocondObj.WarehouseCode = nyusyuslipinfo.SokoCd;
                // -- ADD 2019/10/16 ------------------------------>>>
                //handystockInfocondObj.CustomerGoodsCode = nyusyuslipinfo.BarCode.ToString().Trim();
                if (nyusyuslipinfo.BarCode.ToString().Trim() == "")
                {
                    handystockInfocondObj.GoodsNo = nyusyuslipinfo.RtSyoCd.ToString().Trim();
                }
                else
                {
                    handystockInfocondObj.CustomerGoodsCode = nyusyuslipinfo.BarCode.ToString().Trim();
                }
                // -- ADD 2019/10/16 ------------------------------<<<

                condObjs = handystockInfocondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchStock(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchStock(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                nyusyuslipinfo.IniOutArg();
                nyusyuslipinfo.RetVal = string.Empty;
                nyusyuslipinfo.RetVal = status.ToString();

                // -- ADD 2019/10/16 ------------------------------>>>
                //HandyStockWork SlipRetObj = new HandyStockWork();
                //if (retObjs != null)
                //{
                //    SlipRetObj = (HandyStockWork)retObjs;
                //}

                //if (Int32.Parse(nyusyuslipinfo.RetVal.ToString()) == 0)
                //{
                //    nyusyuslipinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                //    nyusyuslipinfo.RtMakerNm = SlipRetObj.MakerName;
                //    nyusyuslipinfo.RtSyoCd = SlipRetObj.GoodsNo;
                //    nyusyuslipinfo.RtSyoNm = SlipRetObj.GoodsName;
                //    nyusyuslipinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                //    nyusyuslipinfo.RtHacNm = SlipRetObj.UOESupplierName;
                //    nyusyuslipinfo.RtSirNm = SlipRetObj.SupplierNm;
                //}

                //nyusyuslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    nyusyuslipinfo.SetRow = "-1";
                    nyusyuslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyStockWork SlipRetObj in SlipRetArray)
                {
                    row += 1;

                    if (Int32.Parse(nyusyuslipinfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            nyusyuslipinfo.SetRow = SlipRetArray.Count.ToString();
                        }
                        else
                        {
                            nyusyuslipinfo.SetRow = "0";
                        }

                        if (row == SlipRetArray.Count)
                        {
                            intSetrow = (-1 * SlipRetArray.Count);
                            nyusyuslipinfo.SetRow = intSetrow.ToString();
                        }

                        nyusyuslipinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                        nyusyuslipinfo.RtMakerNm = SlipRetObj.MakerName;
                        nyusyuslipinfo.RtSyoCd = SlipRetObj.GoodsNo;
                        nyusyuslipinfo.RtSyoNm = SlipRetObj.GoodsName;
                        nyusyuslipinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                        nyusyuslipinfo.RtHacNm = SlipRetObj.UOESupplierName;
                        nyusyuslipinfo.RtSirNm = SlipRetObj.SupplierNm;

                        nyusyuslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                // -- ADD 2019/10/16 ------------------------------<<<

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(nyusyuslipinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 検品データ登録(在庫仕入　入荷/出荷)"
        /// <summary>
        /// 検品データ登録(在庫仕入　入荷/出荷)
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsNyuSyuSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsNyuSyuSlipInsert nyusyuslipinsert = new clsNyuSyuSlipInsert();

            Int32 StPost = 0;
            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                nyusyuslipinsert.RelayGetHtInArg(rcvData, ref StPost);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(nyusyuslipinsert.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(nyusyuslipinsert.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(nyusyuslipinsert.ProcDiv);
                msgData.Append(nyusyuslipinsert.SokoCd);
                msgData.Append(nyusyuslipinsert.SyoCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInspectDataWork HandyStokInsCondObj = new HandyInspectDataWork();
                HandyStokInsCondObj.MachineName = nyusyuslipinsert.HtName;
                HandyStokInsCondObj.EmployeeCode = nyusyuslipinsert.EmpCd;
                HandyStokInsCondObj.ProcDiv = Int32.Parse(nyusyuslipinsert.ProcDiv);
                HandyStokInsCondObj.GoodsMakerCd = Int32.Parse(nyusyuslipinsert.MakerCd);
                HandyStokInsCondObj.GoodsNo = nyusyuslipinsert.SyoCd;
                HandyStokInsCondObj.WarehouseCode = nyusyuslipinsert.SokoCd;
                HandyStokInsCondObj.InspectStatus = Int32.Parse(nyusyuslipinsert.CheckStus);
                HandyStokInsCondObj.InspectCode = Int32.Parse(nyusyuslipinsert.CheckKbn);
                if (nyusyuslipinsert.CheckNum.ToString() == string.Empty)
                {
                    HandyStokInsCondObj.InspectCnt = 0;
                }
                else
                {
                    HandyStokInsCondObj.InspectCnt = double.Parse(nyusyuslipinsert.CheckNum.ToString());
                }

                condObjs = HandyStokInsCondObj;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.WriteHandyInspect(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteHandyInspect(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }

                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                nyusyuslipinsert.IniOutArg();
                nyusyuslipinsert.RetVal = string.Empty;
                nyusyuslipinsert.RetVal = status.ToString();

                reply = nyusyuslipinsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(nyusyuslipinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 在庫移動(出荷/入荷)　伝票情報取得"
        /// <summary>
        /// 在庫移動(出荷/入荷)　伝票情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetIdouSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsIdoSlipInfo idouslipinfo = new clsIdoSlipInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", idouslipinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                idouslipinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(idouslipinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(idouslipinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(idouslipinfo.ProcDiv);
                msgData.Append(idouslipinfo.SlipNo);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyStockMoveCondWork MoveInfocondObj = new HandyStockMoveCondWork();
                MoveInfocondObj.MachineName = idouslipinfo.HtName.ToString().Trim();
                MoveInfocondObj.EmployeeCode = idouslipinfo.EmpCd.ToString().Trim();
                MoveInfocondObj.ProcDiv = Int32.Parse(idouslipinfo.ProcDiv.ToString().Trim());
                MoveInfocondObj.StockMoveSlipNo = Int32.Parse(idouslipinfo.SlipNo.ToString().Trim());
                condObjs = MoveInfocondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchStockMoveData(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchStockMoveData(ref condObjs, out retObjs);
                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                idouslipinfo.IniOutArg();
                idouslipinfo.RetVal = string.Empty;
                idouslipinfo.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    idouslipinfo.SetRow = "-1";
                    idouslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyStockMoveWork SlipRetObj in SlipRetArray)
                {
                    row += 1;

                    if (Int32.Parse(idouslipinfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            idouslipinfo.SetRow = SlipRetArray.Count.ToString();
                        }
                        else
                        {
                            idouslipinfo.SetRow = "0";
                        }

                        if (row == SlipRetArray.Count)
                        {
                            intSetrow = (-1 * SlipRetArray.Count);
                            idouslipinfo.SetRow = intSetrow.ToString();
                        }

                        idouslipinfo.RtSlipNo = SlipRetObj.StockMoveSlipNo.ToString();
                        idouslipinfo.RtSlipRow = SlipRetObj.StockMoveRowNo.ToString();
                        idouslipinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                        idouslipinfo.RtSyoCd = SlipRetObj.GoodsNo;
                        idouslipinfo.RtSyoNm = SlipRetObj.GoodsNameKana;
                        idouslipinfo.RtTyoseiSu = SlipRetObj.MoveCount.ToString();
                        idouslipinfo.RtFrSokoCd = SlipRetObj.BfEnterWarehCode;
                        idouslipinfo.RtFrSokoNm = SlipRetObj.BfEnterWarehName;
                        idouslipinfo.RtToSokoCd = SlipRetObj.AfEnterWarehCode;
                        idouslipinfo.RtToSokoNm = SlipRetObj.AfEnterWarehName;
                        idouslipinfo.RtFrTanaNo = SlipRetObj.BfShelfNo;
                        idouslipinfo.RtToTanaNo = SlipRetObj.AfShelfNo;
                        idouslipinfo.RtBarCode = SlipRetObj.GoodsBarCode;
                        idouslipinfo.RtCheckStus = SlipRetObj.InspectStatus.ToString();
                        idouslipinfo.RtCheckKbn = SlipRetObj.InspectCode.ToString();
                        idouslipinfo.RtCheckNum = SlipRetObj.InspectCnt.ToString();

                        idouslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(idouslipinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 検品データ登録(在庫移動　出荷/入荷)"
        /// <summary>
        /// 検品データ登録(在庫移動　出荷/入荷)
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsIdouSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsIdoSlipInsert idouslipinsert = new clsIdoSlipInsert();

            Int32 GetRow = 1;
            Int32 GetRowEnd = 1;
            Int32 StPost = 0;
            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                while (GetRow <= GetRowEnd)
                {
                    idouslipinsert.RelayGetHtInArg(rcvData, GetRow, ref StPost);

                    if (GetRow == 1)
                    {
                        // 受信日時(１回の処理単位で同じ時間を使用する)
                        msgYmdHms.Length = 0;
                        msgYmdHms.Append("【");
                        msgYmdHms.Append(idouslipinsert.HtName.Trim());
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(GetSckSyrKbn(idouslipinsert.SokSyoriKbn));
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        msgYmdHms.Append("】");

                        msgData.Length = 0;
                        msgData.Append(idouslipinsert.ProcDiv);
                        msgData.Append(idouslipinsert.ZaiSlipNo);

                        msgInfo.Length = 0;
                        msgInfo.Append(msgYmdHms.ToString());
                        msgInfo.Append("APLCom（対ハンディ） 受信=");
                        msgInfo.Append(msgData.ToString());
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                        GetRowEnd = Int32.Parse(idouslipinsert.SetRow);
                    }

                    //対ＰＭＮＳ　条件セット
                    HandyInspectDataWork HdyInsSlipInsCondObj = new HandyInspectDataWork();
                    HdyInsSlipInsCondObj.MachineName = idouslipinsert.HtName;
                    HdyInsSlipInsCondObj.EmployeeCode = idouslipinsert.EmpCd;
                    HdyInsSlipInsCondObj.ProcDiv = Int32.Parse(idouslipinsert.ProcDiv);
                    HdyInsSlipInsCondObj.AcPaySlipNum = idouslipinsert.ZaiSlipNo;
                    HdyInsSlipInsCondObj.AcPaySlipRowNo = Int32.Parse(idouslipinsert.SlipRow);
                    HdyInsSlipInsCondObj.GoodsMakerCd = Int32.Parse(idouslipinsert.MakerCd);
                    HdyInsSlipInsCondObj.GoodsNo = idouslipinsert.SyoCd;
                    HdyInsSlipInsCondObj.WarehouseCode = idouslipinsert.SokoCd;
                    HdyInsSlipInsCondObj.InspectStatus = Int32.Parse(idouslipinsert.CheckStus);
                    HdyInsSlipInsCondObj.InspectCode = Int32.Parse(idouslipinsert.CheckKbn);
                    if (idouslipinsert.CheckNum.ToString() == string.Empty)
                    {
                        HdyInsSlipInsCondObj.InspectCnt = 0;
                    }
                    else
                    {
                        HdyInsSlipInsCondObj.InspectCnt = double.Parse(idouslipinsert.CheckNum.ToString());
                    }

                    ListcondObjs.Add(HdyInsSlipInsCondObj);

                    GetRow += 1;
                }

                condObjs = ListcondObjs;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.WriteStockMoveInspect(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteStockMoveInspect(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }
                    // --- ADD 2019/06/13 ----------<<<<<

                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                idouslipinsert.IniOutArg();
                idouslipinsert.RetVal = string.Empty;
                idouslipinsert.RetVal = status.ToString();

                reply = idouslipinsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(idouslipinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 倉庫情報取得"
        /// <summary>
        /// 倉庫情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetSokoInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSokoInfo sokoinfo = new clsSokoInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", sokoinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                sokoinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(sokoinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(sokoinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(sokoinfo.SokoCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                ConsStockRepWarehouseParamWork RepWarehouseInfocondObj = new ConsStockRepWarehouseParamWork();
                RepWarehouseInfocondObj.MachineName = sokoinfo.HtName.ToString().Trim();
                RepWarehouseInfocondObj.EmployeeCode = sokoinfo.EmpCd.ToString().Trim();
                RepWarehouseInfocondObj.WarehouseCode = sokoinfo.SokoCd.ToString().Trim();
                condObjs = RepWarehouseInfocondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchHandyWarehouseInfo(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyWarehouseInfo(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }

                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                sokoinfo.IniOutArg();
                sokoinfo.RetVal = string.Empty;
                sokoinfo.RetVal = status.ToString();

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    sokoinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (ConsStockRepWarehouseRetWork SlipRetObj in SlipRetArray)
                {
                    if (Int32.Parse(sokoinfo.RetVal.ToString()) == 0)
                    {
                        sokoinfo.RtItkSokoCd = SlipRetObj.ConsignWarehouseCode;
                        sokoinfo.RtItkSokoNm = SlipRetObj.ConsignWarehouseName;
                        sokoinfo.RtSkmSokoCd = SlipRetObj.MainMngWarehouseCd;
                        sokoinfo.RtSkmSokoNm = SlipRetObj.MainMngWarehouseName;
                    }

                    sokoinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                //ConsStockRepWarehouseRetWork SlipRetObj = new ConsStockRepWarehouseRetWork();
                //if (retObjs != null)
                //{
                //    SlipRetObj = (ConsStockRepWarehouseRetWork)retObjs;
                //}

                //if (Int32.Parse(sokoinfo.RetVal.ToString()) == 0)
                //{
                //    sokoinfo.RtItkSokoCd = SlipRetObj.ConsignWarehouseCode;
                //    sokoinfo.RtItkSokoNm = SlipRetObj.ConsignWarehouseName;
                //    sokoinfo.RtSkmSokoCd = SlipRetObj.MainMngWarehouseCd;
                //    sokoinfo.RtSkmSokoNm = SlipRetObj.MainMngWarehouseName;
                //}

                //sokoinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(sokoinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 倉庫情報取得"
        // --- ADD 2020/04/17 M.KISHI ---------->>>>>
        /// <summary>
        /// 倉庫情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetSokoInfoForStock(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSokoInfo sokoinfo = new clsSokoInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", sokoinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                sokoinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(sokoinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(sokoinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(sokoinfo.SokoCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                object condEnterPriseCode = null;
                object condWarehouseCode = (object)sokoinfo.SokoCd.ToString().Trim();
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchHandyWarehouseInfo(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyWarehouseInfoForStock(out retObjs, condEnterPriseCode, condWarehouseCode);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }

                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                sokoinfo.IniOutArg();
                sokoinfo.RetVal = string.Empty;
                sokoinfo.RetVal = status.ToString();

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    sokoinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (WarehouseWork SlipRetObj in SlipRetArray)
                {
                    if (Int32.Parse(sokoinfo.RetVal.ToString()) == 0)
                    {
                        sokoinfo.RtItkSokoCd = SlipRetObj.WarehouseCode;
                        sokoinfo.RtItkSokoNm = SlipRetObj.WarehouseName;
                        sokoinfo.RtSkmSokoCd = SlipRetObj.WarehouseCode;
                        sokoinfo.RtSkmSokoNm = SlipRetObj.WarehouseName;
                    }

                    sokoinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                //ConsStockRepWarehouseRetWork SlipRetObj = new ConsStockRepWarehouseRetWork();
                //if (retObjs != null)
                //{
                //    SlipRetObj = (ConsStockRepWarehouseRetWork)retObjs;
                //}

                //if (Int32.Parse(sokoinfo.RetVal.ToString()) == 0)
                //{
                //    sokoinfo.RtItkSokoCd = SlipRetObj.ConsignWarehouseCode;
                //    sokoinfo.RtItkSokoNm = SlipRetObj.ConsignWarehouseName;
                //    sokoinfo.RtSkmSokoCd = SlipRetObj.MainMngWarehouseCd;
                //    sokoinfo.RtSkmSokoNm = SlipRetObj.MainMngWarehouseName;
                //}

                //sokoinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(sokoinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        // --- ADD 2020/04/17 M.KISHI ---------->>>>>
        #endregion

        #region "■SELECT 倉庫リスト取得"
        // -- ADD 2019/10/16 ------------------------------>>>
        /// <summary>
        /// 倉庫リスト取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetSokoList(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSokoList sokolist = new clsSokoList();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", sokolist.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                sokolist.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(sokolist.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(sokolist.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(sokolist.SectionCode);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                ConsStockRepWarehouseParamWork WarehouseCondObj = new ConsStockRepWarehouseParamWork();
                WarehouseCondObj.MachineName = sokolist.HtName.ToString().Trim();
                WarehouseCondObj.EmployeeCode = sokolist.EmpCd.ToString().Trim();
                condObjs = WarehouseCondObj;
                retObjs = null;

                status = 0;
                try
                {
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyWarehouseList(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }

                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                sokolist.IniOutArg();
                sokolist.RetVal = string.Empty;
                sokolist.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SokoListRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SokoListRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SokoListRetArray.Count == 0)
                {
                    sokolist.SetRow = "-1";
                    sokolist.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (WarehouseWork SokoListRetObj in SokoListRetArray)
                {
                    row += 1;

                    if (Int32.Parse(sokolist.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            sokolist.SetRow = SokoListRetArray.Count.ToString();
                        }
                        else
                        {
                            sokolist.SetRow = "0";
                        }

                        if (row == SokoListRetArray.Count)
                        {
                            intSetrow = (-1 * SokoListRetArray.Count);
                            sokolist.SetRow = intSetrow.ToString();
                        }

                        sokolist.RtSokoCd = SokoListRetObj.WarehouseCode;
                        sokolist.RtSokoNm = SokoListRetObj.WarehouseName;

                        sokolist.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(sokolist.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
        // -- ADD 2019/10/16 ------------------------------<<<
        #endregion

        #region "■SELECT 委託在庫補充　伝票情報取得"
        /// <summary>
        /// 委託在庫補充　伝票情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetItakuSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsItakuSlipInfo itakuslipinfo = new clsItakuSlipInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", itakuslipinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                itakuslipinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(itakuslipinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(itakuslipinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(itakuslipinfo.ItkSokoCd);
                msgData.Append(itakuslipinfo.SyukaDate);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                ConsStockRepInspectParamWork ItakuSlipInfocondObj = new ConsStockRepInspectParamWork();
                ItakuSlipInfocondObj.MachineName = itakuslipinfo.HtName.ToString().Trim();
                ItakuSlipInfocondObj.EmployeeCode = itakuslipinfo.EmpCd.ToString().Trim();
                ItakuSlipInfocondObj.ConsignWarehouseCode = itakuslipinfo.ItkSokoCd.ToString().Trim();
                ItakuSlipInfocondObj.ShipmentDay = Int32.Parse(itakuslipinfo.SyukaDate.ToString().Trim());
                // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
                ItakuSlipInfocondObj.MainMngWarehouseCode = itakuslipinfo.MngSokoCd.ToString().Trim();
                // --- ADD 2017/12/14 Y.Wakita ----------<<<<<
                condObjs = ItakuSlipInfocondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchHandyInspectInfo(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyInspectInfo(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                itakuslipinfo.IniOutArg();
                itakuslipinfo.RetVal = string.Empty;
                itakuslipinfo.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    itakuslipinfo.SetRow = "-1";
                    itakuslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (ConsStockRepInspectRetWork SlipRetObj in SlipRetArray)
                {
                    row += 1;

                    if (Int32.Parse(itakuslipinfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            itakuslipinfo.SetRow = SlipRetArray.Count.ToString();
                        }
                        else
                        {
                            itakuslipinfo.SetRow = "0";
                        }

                        if (row == SlipRetArray.Count)
                        {
                            intSetrow = (-1 * SlipRetArray.Count);
                            itakuslipinfo.SetRow = intSetrow.ToString();
                        }

                        itakuslipinfo.RtSlipNo = SlipRetObj.StockAdjustSlipNo.ToString();
                        itakuslipinfo.RtSlipRow = SlipRetObj.StockAdjustRowNo.ToString();
                        itakuslipinfo.RtSyukaDate = SlipRetObj.AdjustDate.ToString();
                        itakuslipinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                        itakuslipinfo.RtSyoCd = SlipRetObj.GoodsNo;
                        itakuslipinfo.RtSyoNm = SlipRetObj.GoodsName;
                        itakuslipinfo.RtTyoseiNum = SlipRetObj.AdjustCount.ToString();
                        itakuslipinfo.RtSokoCd = SlipRetObj.WarehouseCode;
                        itakuslipinfo.RtSokoNm = SlipRetObj.WarehouseName;
                        itakuslipinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                        itakuslipinfo.RtBarCode = SlipRetObj.GoodsBarCode;
                        itakuslipinfo.RtCheckStus = SlipRetObj.InspectStatus.ToString();
                        itakuslipinfo.RtCheckKbn = SlipRetObj.InspectCode.ToString();
                        itakuslipinfo.RtCheckNum = SlipRetObj.InspectCnt.ToString();

                        itakuslipinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(itakuslipinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 検品データ登録(委託在庫補充)"
        /// <summary>
        /// 検品データ登録(委託在庫補充)
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsItakuSlipInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsItakuSlipInsert itakuslipinsert = new clsItakuSlipInsert();

            Int32 GetRow = 1;
            Int32 GetRowEnd = 1;
            Int32 StPost = 0;
            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                while (GetRow <= GetRowEnd)
                {
                    itakuslipinsert.RelayGetHtInArg(rcvData, GetRow, ref StPost);

                    if (GetRow == 1)
                    {
                        // 受信日時(１回の処理単位で同じ時間を使用する)
                        msgYmdHms.Length = 0;
                        msgYmdHms.Append("【");
                        msgYmdHms.Append(itakuslipinsert.HtName.Trim());
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(GetSckSyrKbn(itakuslipinsert.SokSyoriKbn));
                        msgYmdHms.Append(" ");
                        msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                        msgYmdHms.Append("】");

                        msgData.Length = 0;
                        msgData.Append(itakuslipinsert.ProcDiv);
                        msgData.Append(itakuslipinsert.ZaiSlipNo);

                        msgInfo.Length = 0;
                        msgInfo.Append(msgYmdHms.ToString());
                        msgInfo.Append("APLCom（対ハンディ） 受信=");
                        msgInfo.Append(msgData.ToString());
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                        GetRowEnd = Int32.Parse(itakuslipinsert.SetRow);
                    }

                    //対ＰＭＮＳ　条件セット
                    ConsStockRepInspectDataParamWork StockRepSlipInsCondObj = new ConsStockRepInspectDataParamWork();
                    StockRepSlipInsCondObj.MachineName = itakuslipinsert.HtName;
                    StockRepSlipInsCondObj.EmployeeCode = itakuslipinsert.EmpCd;
                    StockRepSlipInsCondObj.OpDiv = Int32.Parse(itakuslipinsert.ProcDiv);
                    StockRepSlipInsCondObj.AcPaySlipNum = itakuslipinsert.ZaiSlipNo;
                    StockRepSlipInsCondObj.AcPaySlipRowNo = Int32.Parse(itakuslipinsert.SlipRow);
                    StockRepSlipInsCondObj.GoodsMakerCd = Int32.Parse(itakuslipinsert.MakerCd);
                    StockRepSlipInsCondObj.GoodsNo = itakuslipinsert.SyoCd;
                    StockRepSlipInsCondObj.WarehouseCode = itakuslipinsert.SokoCd;
                    StockRepSlipInsCondObj.InspectStatus = Int32.Parse(itakuslipinsert.CheckStus);
                    StockRepSlipInsCondObj.InspectCode = Int32.Parse(itakuslipinsert.CheckKbn);
                    if (itakuslipinsert.CheckNum.ToString() == string.Empty)
                    {
                        StockRepSlipInsCondObj.InspectCnt = 0;
                    }
                    else
                    {
                        StockRepSlipInsCondObj.InspectCnt = double.Parse(itakuslipinsert.CheckNum.ToString());
                    }

                    ListcondObjs.Add(StockRepSlipInsCondObj);

                    GetRow += 1;
                }

                condObjs = ListcondObjs;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.WriteHandyConsStockRepInspect(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteHandyConsStockRepInspect(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                itakuslipinsert.IniOutArg();
                itakuslipinsert.RetVal = string.Empty;
                itakuslipinsert.RetVal = status.ToString();

                reply = itakuslipinsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(itakuslipinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 棚卸(一斉)情報存在確認"
        /// <summary>
        /// 棚卸(一斉)情報存在確認
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetIsseiCheck(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsTanaIsseiCheck tanaisseicheck = new clsTanaIsseiCheck();

            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                tanaisseicheck.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(tanaisseicheck.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(tanaisseicheck.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(tanaisseicheck.SokoCd);
                msgData.Append(tanaisseicheck.TanaDate);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInventoryCondWork HandyInventoryCondObj = new HandyInventoryCondWork();
                HandyInventoryCondObj.MachineName = tanaisseicheck.HtName;
                HandyInventoryCondObj.EmployeeCode = tanaisseicheck.EmpCd;
                HandyInventoryCondObj.WarehouseCode = tanaisseicheck.SokoCd;
                HandyInventoryCondObj.InventoryDate = Int32.Parse(tanaisseicheck.TanaDate.Replace("/",""));

                condObjs = HandyInventoryCondObj;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchCount(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchCount(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }

                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                tanaisseicheck.IniOutArg();
                tanaisseicheck.RetVal = string.Empty;
                tanaisseicheck.RetVal = status.ToString();

                reply = tanaisseicheck.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(tanaisseicheck.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 棚卸(一斉)情報取得"
        /// <summary>
        /// 棚卸(一斉)情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetIsseiInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsTanaIsseiInfo tanaisseiinfo = new clsTanaIsseiInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", tanaisseiinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                tanaisseiinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(tanaisseiinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(tanaisseiinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(tanaisseiinfo.SokoCd);
                msgData.Append(tanaisseiinfo.BarCode);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInventoryCondWork handyinvInfocondObj = new HandyInventoryCondWork();
                handyinvInfocondObj.MachineName = tanaisseiinfo.HtName.ToString().Trim();
                handyinvInfocondObj.EmployeeCode = tanaisseiinfo.EmpCd.ToString().Trim();
                handyinvInfocondObj.WarehouseCode = tanaisseiinfo.SokoCd;
                // -- ADD 2019/10/16 ------------------------------>>>
                //handyinvInfocondObj.GoodsBarCode = tanaisseiinfo.BarCode;
                if (tanaisseiinfo.BarCode.ToString().Trim() == "")
                {
                    handyinvInfocondObj.GoodsNo = tanaisseiinfo.RtSyoCd;
                }
                else
                {
                    handyinvInfocondObj.GoodsBarCode = tanaisseiinfo.BarCode;
                }
                // -- ADD 2019/10/16 ------------------------------<<<
                condObjs = handyinvInfocondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchInventory(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchInventory(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                tanaisseiinfo.IniOutArg();
                tanaisseiinfo.RetVal = string.Empty;
                tanaisseiinfo.RetVal = status.ToString();

                // -- UPD 2019/10/16 ------------------------------>>>
                //HandyInventoryDataWork SlipRetObj = new HandyInventoryDataWork();
                //if (retObjs != null)
                //{
                //    SlipRetObj = (HandyInventoryDataWork)retObjs;
                //}

                //if (Int32.Parse(tanaisseiinfo.RetVal.ToString()) == 0)
                //{
                //    tanaisseiinfo.RtTanaSeq = SlipRetObj.CirculInventSeqNo.ToString();
                //    tanaisseiinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                //    tanaisseiinfo.RtMakerNm = SlipRetObj.MakerName;
                //    tanaisseiinfo.RtSyoCd = SlipRetObj.GoodsNo;
                //    tanaisseiinfo.RtSyoNm = SlipRetObj.GoodsName;
                //    tanaisseiinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                //    tanaisseiinfo.RtTyoboNum = SlipRetObj.StockTotal.ToString();
                //    tanaisseiinfo.RtTanaNum = SlipRetObj.InventoryStockCnt.ToString();
                //    tanaisseiinfo.RtSectionCode = SlipRetObj.SectionCode.ToString();
                //}

                //tanaisseiinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    tanaisseiinfo.SetRow = "-1";
                    tanaisseiinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyInventoryDataWork SlipRetObj in SlipRetArray)
                {
                    row += 1;

                    if (Int32.Parse(tanaisseiinfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            tanaisseiinfo.SetRow = SlipRetArray.Count.ToString();
                        }
                        else
                        {
                            tanaisseiinfo.SetRow = "0";
                        }

                        if (row == SlipRetArray.Count)
                        {
                            intSetrow = (-1 * SlipRetArray.Count);
                            tanaisseiinfo.SetRow = intSetrow.ToString();
                        }

                        tanaisseiinfo.RtTanaSeq = SlipRetObj.CirculInventSeqNo.ToString();
                        tanaisseiinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                        tanaisseiinfo.RtMakerNm = SlipRetObj.MakerName;
                        tanaisseiinfo.RtSyoCd = SlipRetObj.GoodsNo;
                        tanaisseiinfo.RtSyoNm = SlipRetObj.GoodsName;
                        tanaisseiinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                        tanaisseiinfo.RtTyoboNum = SlipRetObj.StockTotal.ToString();
                        tanaisseiinfo.RtTanaNum = SlipRetObj.InventoryStockCnt.ToString();
                        tanaisseiinfo.RtSectionCode = SlipRetObj.SectionCode.ToString();

                        tanaisseiinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                // -- UPD 2019/10/16 ------------------------------<<<

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(tanaisseiinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 棚卸データ登録(一斉)"
        /// <summary>
        /// 棚卸データ登録(一斉)
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsGetIsseiInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsTanaIsseiInsert tanaisseiinsert = new clsTanaIsseiInsert();

            Int32 StPost = 0;
            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                tanaisseiinsert.RelayGetHtInArg(rcvData, ref StPost);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(tanaisseiinsert.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(tanaisseiinsert.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(tanaisseiinsert.TanaSeq);
                msgData.Append(tanaisseiinsert.SokoCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInventoryCondWork HandyInvInsCondObj = new HandyInventoryCondWork();
                HandyInvInsCondObj.MachineName = tanaisseiinsert.HtName;
                HandyInvInsCondObj.EmployeeCode = tanaisseiinsert.EmpCd;
                HandyInvInsCondObj.CirculInventSeqNo = Int32.Parse(tanaisseiinsert.TanaSeq);
                HandyInvInsCondObj.WarehouseCode = tanaisseiinsert.SokoCd;
                if (tanaisseiinsert.KenpinNum.ToString() == string.Empty)
                {
                    HandyInvInsCondObj.InventoryStockCnt = 0;
                }
                else
                {
                    HandyInvInsCondObj.InventoryStockCnt = double.Parse(tanaisseiinsert.KenpinNum.ToString());
                }
                HandyInvInsCondObj.BelongSectionCode = tanaisseiinsert.SectionCode;

                condObjs = HandyInvInsCondObj;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.WriteInventoryData(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteInventoryData(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                    
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                tanaisseiinsert.IniOutArg();
                tanaisseiinsert.RetVal = string.Empty;
                tanaisseiinsert.RetVal = status.ToString();

                reply = tanaisseiinsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(tanaisseiinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 棚卸(循環)情報存在確認"
        /// <summary>
        /// 棚卸(循環)情報存在確認
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetJyunCheck(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsTanaJyunCheck tanajyuncheck = new clsTanaJyunCheck();

            ArrayList ListcondObjs = new ArrayList();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                tanajyuncheck.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(tanajyuncheck.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(tanajyuncheck.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(tanajyuncheck.SokoCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInventoryCondWork HandyInvCondObj = new HandyInventoryCondWork();
                HandyInvCondObj.MachineName = tanajyuncheck.HtName;
                HandyInvCondObj.EmployeeCode = tanajyuncheck.EmpCd;
                HandyInvCondObj.WarehouseCode = tanajyuncheck.SokoCd;

                condObjs = HandyInvCondObj;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchStockCount(ref condObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchStockCount(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }

                        System.Threading.Thread.Sleep(retryInterval);
                    }
                    // --- ADD 2019/06/13 ---------->>>>>
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                tanajyuncheck.IniOutArg();
                tanajyuncheck.RetVal = string.Empty;
                tanajyuncheck.RetVal = status.ToString();

                reply = tanajyuncheck.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(tanajyuncheck.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        // --- ADD 2019/06/13 ---------->>>>>
        #region "■FILE-MOVE ファイル転送"
        private byte[] MoveFile(byte[] rcvData)
        {
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;
            byte[] reply = null;

            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            int status = 0;

            clsFileTransferInfo fileTransferInfo = new clsFileTransferInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //ハンディ受注データ取得
                fileTransferInfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(clsBtConst.STRING_FILE_TRANSFER);
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(rcvData.Length);
                msgData.Append(fileTransferInfo.HtName);
                msgData.Append(fileTransferInfo.FileName);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                // データをファイル化
                System.Reflection.Assembly _asm = System.Reflection.Assembly.GetEntryAssembly();
                string path = System.IO.Path.GetDirectoryName(_asm.Location); 
                string fileName = string.Format(path + "\\log\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") +  "_log_" + fileTransferInfo.HtName + "_" + fileTransferInfo.FileName);

                // ハンディから受信したデータをファイル化
                try
                {
                    using (System.IO.StreamWriter fs = new System.IO.StreamWriter(fileName))
                    {
                        fs.Write(fileTransferInfo.FileData);
                    }
                    msgData.Length = 0;
                }
                catch (Exception ex)
                {
                    status = -1;
                    msgData.Length = 0;
                    msgData.Append(ex.Message);
                }

                reply = fileTransferInfo.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(status);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;

            }
        }
        #endregion
        // --- ADD 2019/06/13 ----------<<<<<

        #region "■SELECT 棚卸(循環)情報取得"
        /// <summary>
        /// 棚卸(循環)情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetJyunCheckInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsTanaJyunInfo tanajyunkinfo = new clsTanaJyunInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", tanajyunkinfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                tanajyunkinfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(tanajyunkinfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(tanajyunkinfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(tanajyunkinfo.ProcDiv);
                msgData.Append(tanajyunkinfo.SokoCd);
                msgData.Append(tanajyunkinfo.BarCode);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInventoryCondWork handyinvInfocondObj = new HandyInventoryCondWork();
                handyinvInfocondObj.MachineName = tanajyunkinfo.HtName.ToString().Trim();
                handyinvInfocondObj.EmployeeCode = tanajyunkinfo.EmpCd.ToString().Trim();
                handyinvInfocondObj.ProcDiv = Int32.Parse(tanajyunkinfo.ProcDiv.ToString().Trim());
                handyinvInfocondObj.WarehouseCode = tanajyunkinfo.SokoCd.ToString().Trim();
                // -- ADD 2019/10/16 ------------------------------>>>
                //handyinvInfocondObj.GoodsBarCode = tanajyunkinfo.BarCode.ToString().Trim();
                if (tanajyunkinfo.BarCode.ToString().Trim() == "")
                {
                    handyinvInfocondObj.GoodsNo = tanajyunkinfo.RtSyoCd.ToString().Trim();
                }
                else
                {
                    handyinvInfocondObj.GoodsBarCode = tanajyunkinfo.BarCode.ToString().Trim();
                }
                // -- ADD 2019/10/16 ------------------------------<<<
                condObjs = handyinvInfocondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.SearchStockCircul(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchStockCircul(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }

                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                tanajyunkinfo.IniOutArg();
                tanajyunkinfo.RetVal = string.Empty;
                tanajyunkinfo.RetVal = status.ToString();

                // -- ADD 2019/10/16 ------------------------------>>>
                //HandyStockWork SlipRetObj = new HandyStockWork();
                //if (retObjs != null)
                //{
                //    SlipRetObj = (HandyStockWork)retObjs;
                //}

                //if (Int32.Parse(tanajyunkinfo.RetVal.ToString()) == 0)
                //{
                //    tanajyunkinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                //    tanajyunkinfo.RtMakerNm = SlipRetObj.MakerName;
                //    tanajyunkinfo.RtSyoCd = SlipRetObj.GoodsNo;
                //    tanajyunkinfo.RtSyoNm = SlipRetObj.GoodsName;
                //    tanajyunkinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                //    tanajyunkinfo.RtTanaNum = SlipRetObj.ShipmentPosCnt.ToString();
                //}

                //tanajyunkinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);

                Int32 row = 0;
                Int32 intSetrow = 0;

                ArrayList SlipRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SlipRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SlipRetArray.Count == 0)
                {
                    tanajyunkinfo.SetRow = "-1";
                    tanajyunkinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyStockWork SlipRetObj in SlipRetArray)
                {
                    row += 1;

                    if (Int32.Parse(tanajyunkinfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            tanajyunkinfo.SetRow = SlipRetArray.Count.ToString();
                        }
                        else
                        {
                            tanajyunkinfo.SetRow = "0";
                        }

                        if (row == SlipRetArray.Count)
                        {
                            intSetrow = (-1 * SlipRetArray.Count);
                            tanajyunkinfo.SetRow = intSetrow.ToString();
                        }

                        tanajyunkinfo.RtMakerCd = SlipRetObj.GoodsMakerCd.ToString();
                        tanajyunkinfo.RtMakerNm = SlipRetObj.MakerName;
                        tanajyunkinfo.RtSyoCd = SlipRetObj.GoodsNo;
                        tanajyunkinfo.RtSyoNm = SlipRetObj.GoodsName;
                        tanajyunkinfo.RtTanaNo = SlipRetObj.WarehouseShelfNo;
                        tanajyunkinfo.RtTanaNum = SlipRetObj.ShipmentPosCnt.ToString();

                        tanajyunkinfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                // -- ADD 2019/10/16 ------------------------------<<<

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(tanajyunkinfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 棚卸データ登録(循環)"
        /// <summary>
        /// 棚卸データ登録(循環)
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsJyunCheckInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsTanaJyunInsert tanajyunkinsert = new clsTanaJyunInsert();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", tanajyunkinsert.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                tanajyunkinsert.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(tanajyunkinsert.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(tanajyunkinsert.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(tanajyunkinsert.SokoCd);
                msgData.Append(tanajyunkinsert.MakerCd);
                msgData.Append(tanajyunkinsert.SyoCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyInventoryCondWork handyinvInfocondObj = new HandyInventoryCondWork();
                handyinvInfocondObj.MachineName = tanajyunkinsert.HtName.ToString().Trim();
                handyinvInfocondObj.EmployeeCode = tanajyunkinsert.EmpCd.ToString().Trim();
                handyinvInfocondObj.WarehouseCode = tanajyunkinsert.SokoCd;
                handyinvInfocondObj.GoodsMakerCd = Int32.Parse(tanajyunkinsert.MakerCd);
                handyinvInfocondObj.GoodsNo = tanajyunkinsert.SyoCd;
                handyinvInfocondObj.WarehouseShelfNo = tanajyunkinsert.TanaNo;
                handyinvInfocondObj.InventoryStockCnt = double.Parse(tanajyunkinsert.TanaNum);
                handyinvInfocondObj.CirculInventSeqNo = Int32.Parse(tanajyunkinsert.TanaSeq);
                handyinvInfocondObj.Note = tanajyunkinsert.Biko;
                handyinvInfocondObj.FirstFlg = Int32.Parse(tanajyunkinsert.FirstFlg);
                condObjs = handyinvInfocondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // --- ADD 2019/06/13 ---------->>>>>
                    // 対ＰＭＮＳ側検索する
                    //status = _iPmHandy.WriteCirculInventoryData(ref condObjs, out retObjs);
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteCirculInventoryData(ref condObjs, out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }

                        }

                        System.Threading.Thread.Sleep(retryInterval);

                    }
                    // --- ADD 2019/06/13 ----------<<<<<
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                tanajyunkinsert.IniOutArg();
                tanajyunkinsert.RetVal = string.Empty;
                tanajyunkinsert.RetVal = status.ToString();

                HandyInventoryDataWork SlipRetObj = new HandyInventoryDataWork();
                if (retObjs != null)
                {
                    SlipRetObj = (HandyInventoryDataWork)retObjs;
                }

                if (Int32.Parse(tanajyunkinsert.RetVal.ToString()) == 0)
                {
                    tanajyunkinsert.RtTanaSeq = SlipRetObj.CirculInventSeqNo.ToString();
                }

                tanajyunkinsert.RelayGetOutArg(ref ArgReply, ref ArgStpost);

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(tanajyunkinsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                // --- ADD 2019/06/13 ---------->>>>>
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                // --- ADD 2019/06/13 ----------<<<<<
                return byteErrReply;
            }
        }
        #endregion
        // -- ADD 2017/08/01 ------------------------------<<<

        // -- ADD 2020/04/01 ------------------------------>>>
        #region "■SELECT メーカー情報取得"
        /// <summary>
        /// メーカー情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetMakerInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsMakerInfo makerInfo = new clsMakerInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", makerInfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                makerInfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(makerInfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(makerInfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(makerInfo.GoodsMakerCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                retObjs = null;

                status = 0;
                try
                {
                    // 対ＰＭＮＳ側検索する
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyMakerInfo(out retObjs,String.Empty, Int32.Parse(makerInfo.GoodsMakerCd.Trim()));

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                makerInfo.IniOutArg();
                makerInfo.RetVal = string.Empty;
                makerInfo.RetVal = status.ToString();

                MakerUWork MakerRetObj = new MakerUWork();
                if (retObjs != null)
                {
                    MakerRetObj = (MakerUWork)retObjs;
                }

                if (Int32.Parse(makerInfo.RetVal.ToString()) == 0)
                {

                    makerInfo.RtGoodsMakerCd = MakerRetObj.GoodsMakerCd.ToString().Trim();
                    makerInfo.RtMakerShortName = MakerRetObj.MakerName;
                }

                makerInfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                //対ハンディ 送信
                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(makerInfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT メーカー一覧取得"
        /// <summary>
        /// メーカー一覧取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetMakerList(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsMakerList MakerList = new clsMakerList();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", MakerList.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                MakerList.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(MakerList.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(MakerList.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                retObjs = null;

                status = 0;
                try
                {
                    // 対ＰＭＮＳ側検索する
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyMakerList(out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                MakerList.IniOutArg();
                MakerList.RetVal = string.Empty;
                MakerList.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetGoodsCount = 0;

                ArrayList MakerRetArray = new ArrayList();
                if (retObjs != null)
                {
                    MakerRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (MakerRetArray.Count == 0)
                {
                    MakerList.SetMakerCount = "-1";
                    MakerList.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (MakerUWork MakerRetObj in MakerRetArray)
                {
                    row += 1;

                    if (Int32.Parse(MakerList.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            MakerList.SetMakerCount = MakerRetArray.Count.ToString();
                        }
                        else
                        {
                            MakerList.SetMakerCount = "0";
                        }

                        if (row == MakerRetArray.Count)
                        {
                            intSetGoodsCount = (-1 * MakerRetArray.Count);
                            MakerList.SetMakerCount = intSetGoodsCount.ToString();
                        }

                        MakerList.RtGoodsMakerCd = MakerRetObj.GoodsMakerCd.ToString().Trim();
                        MakerList.RtMakerShortName = MakerRetObj.MakerName;

                        MakerList.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                //対ハンディ 送信
                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(MakerList.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
        #endregion
        #region "■SELECT 仕入先情報取得"
        /// <summary>
        /// 仕入先情報取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetsupplierInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSupplierInfo supplierInfo = new clsSupplierInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", supplierInfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                supplierInfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(supplierInfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(supplierInfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(supplierInfo.SupplierCd);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                retObjs = null;

                status = 0;
                try
                {
                    // 対ＰＭＮＳ側検索する
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandySupplierInfo(out retObjs, String.Empty, Int32.Parse(supplierInfo.SupplierCd.Trim()));

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                supplierInfo.IniOutArg();
                supplierInfo.RetVal = string.Empty;
                supplierInfo.RetVal = status.ToString();

                SupplierWork SupplierRetObj = new SupplierWork();
                if (retObjs != null)
                {
                    SupplierRetObj = (SupplierWork)retObjs;
                }

                if (Int32.Parse(supplierInfo.RetVal.ToString()) == 0)
                {

                    supplierInfo.RtSupplierCd = SupplierRetObj.SupplierCd.ToString().Trim();
                    supplierInfo.RtSupplierSnm = SupplierRetObj.SupplierSnm;
                }

                supplierInfo.RelayGetOutArg(ref ArgReply, ref ArgStpost);

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                //対ハンディ 送信
                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(supplierInfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
                #endregion

        #region "■SELECT 仕入先一覧取得"
        /// <summary>
        /// 仕入先一覧取得
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetSupplierList(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object retObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsSupplierList SupplierList = new clsSupplierList();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", SupplierList.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                SupplierList.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(SupplierList.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(SupplierList.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                retObjs = null;

                status = 0;
                try
                {
                    // 対ＰＭＮＳ側検索する
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandySupplierList(out retObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                SupplierList.IniOutArg();
                SupplierList.RetVal = string.Empty;
                SupplierList.RetVal = status.ToString();

                Int32 row = 0;
                Int32 intSetGoodsCount = 0;

                ArrayList SupplierRetArray = new ArrayList();
                if (retObjs != null)
                {
                    SupplierRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (SupplierRetArray.Count == 0)
                {
                    SupplierList.SetSupplierCount = "-1";
                    SupplierList.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                }

                foreach (SupplierWork SupplierRetObj in SupplierRetArray)
                {
                    row += 1;

                    if (Int32.Parse(SupplierList.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (row == 1)
                        {
                            SupplierList.SetSupplierCount = SupplierRetArray.Count.ToString();
                        }
                        else
                        {
                            SupplierList.SetSupplierCount = "0";
                        }

                        if (row == SupplierRetArray.Count)
                        {
                            intSetGoodsCount = (-1 * SupplierRetArray.Count);
                            SupplierList.SetSupplierCount = intSetGoodsCount.ToString();
                        }

                        SupplierList.RtSupplierCd = SupplierRetObj.SupplierCd.ToString().Trim();
                        SupplierList.RtSupplierSnm = SupplierRetObj.SupplierSnm;

                        SupplierList.RelayGetOutArg(ref ArgReply, ref ArgStpost);
                    }
                }
                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                //対ハンディ 送信
                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(SupplierList.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 商品在庫登録検索（パターン検索）"
        /// <summary>
        /// 商品在庫登録検索（パターン検索）
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetZaikoInfoPaturn(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object retObjs;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            object hisNoObj = null;

            clsInsZaikoInfo zaikoInfo = new clsInsZaikoInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", zaikoInfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                zaikoInfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(zaikoInfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(zaikoInfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(zaikoInfo.GoodsMakerCd);
                msgData.Append(zaikoInfo.BarCodeInfo);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyGoodsSearchCondWork HandyGoodsSearchCondObj = new HandyGoodsSearchCondWork();
                HandyGoodsSearchCondObj.MachineName = zaikoInfo.HtName.Trim();
                HandyGoodsSearchCondObj.EmployeeCode = zaikoInfo.EmpCd.Trim();
                HandyGoodsSearchCondObj.GoodsMakerCd = Int32.Parse(zaikoInfo.GoodsMakerCd.Trim());
                HandyGoodsSearchCondObj.GoodsNo = string.Empty;
                HandyGoodsSearchCondObj.BarCodeData = zaikoInfo.BarCodeInfo.Trim();
                condObjs = HandyGoodsSearchCondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // 対ＰＭＮＳ側検索する
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyStockPaturn(ref condObjs, out retObjs, out hisNoObj);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                zaikoInfo.IniOutArg();
                zaikoInfo.RetVal = string.Empty;
                zaikoInfo.RetVal = status.ToString();

                Int32 rowGoods = 0;
                Int32 rowStock = 0;

                ArrayList GoodsInfoRetArray = new ArrayList();

                if (retObjs != null)
                {
                    GoodsInfoRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (GoodsInfoRetArray.Count == 0)
                {
                    zaikoInfo.RtMakerGoodsSearchHisNo = "0";
                    zaikoInfo.SetGoodsCount = "0";
                    zaikoInfo.SetStockCount = "0";
                    zaikoInfo.RelayGetOutArgHeader(ref ArgReply, ref ArgStpost);
                    zaikoInfo.RelayGetOutArgFooter(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyStockInsGoodsInfo GoodsInfoRetObj in GoodsInfoRetArray)
                {
                    rowGoods += 1;

                    if (Int32.Parse(zaikoInfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (rowGoods == 1)
                        {
                            //ヘッダー情報
                            int hisNo = (int)hisNoObj;
                            zaikoInfo.RtMakerGoodsSearchHisNo = hisNo.ToString().Trim();
                            zaikoInfo.SetGoodsCount = GoodsInfoRetArray.Count.ToString();
                            zaikoInfo.RelayGetOutArgHeader(ref ArgReply, ref ArgStpost);
                        }

                        //商品情報
                        zaikoInfo.RtSupplierCd = clsCommon.gNullToStr(GoodsInfoRetObj.SupplierCd);
                        zaikoInfo.RtSupplierSnm = clsCommon.gNullToStr(GoodsInfoRetObj.SupplierSNm);
                        zaikoInfo.RtGoodsMakerCd = clsCommon.gNullToStr(GoodsInfoRetObj.GoodsMakerCd);
                        zaikoInfo.RtMakerShortName = clsCommon.gNullToStr(GoodsInfoRetObj.GoodsMakerShortName);
                        zaikoInfo.RtGoodsNo = clsCommon.gNullToStr(GoodsInfoRetObj.GoodsNo);
                        zaikoInfo.RtGoodsName = clsCommon.gNullToStr(GoodsInfoRetObj.GoodsName);

                        rowStock = 0;
                        if (GoodsInfoRetObj.StockList != null)
                        {
                            zaikoInfo.SetStockCount = GoodsInfoRetObj.StockList.Count.ToString();
                            zaikoInfo.RelayGetOutArgGoodsInfo(ref ArgReply, ref ArgStpost);

                            foreach (HandyStockInsStockInfo StockInfoRetObj in GoodsInfoRetObj.StockList)
                            {
                                rowStock += 1;

                                if (Int32.Parse(zaikoInfo.RetVal.ToString()) == 0)
                                {
                                    zaikoInfo.RtWarehouseCode = clsCommon.gNullToStr(StockInfoRetObj.WarehouseCode);
                                    zaikoInfo.RtWarehouseShelfNo = clsCommon.gNullToStr(StockInfoRetObj.WarehouseShelfNo);
                                    zaikoInfo.RtShipmentPosCnt = clsCommon.gNullToStr(StockInfoRetObj.ShipmentPosCnt);

                                    zaikoInfo.RelayGetOutArgStock(ref ArgReply, ref ArgStpost);
                                }
                            }
                        }
                        else
                        {
                            zaikoInfo.SetStockCount = "0";
                            zaikoInfo.RelayGetOutArgGoodsInfo(ref ArgReply, ref ArgStpost);
                        }

                        //フッター(処理結果出力)
                        if (rowGoods == GoodsInfoRetArray.Count)
                        {
                            zaikoInfo.RelayGetOutArgFooter(ref ArgReply, ref ArgStpost);
                        }
                    }
                }

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                //対ハンディ 送信
                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(zaikoInfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
        #endregion

        #region "■SELECT 商品在庫登録検索（品番検索）"
        /// <summary>
        /// 商品在庫登録検索（品番検索）
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] GetZaikoInfoGoodsNo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object retObjs;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            Int32 ArgStpost = 0;
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            object hisNoObj = null;

            clsInsZaikoInfo zaikoInfo = new clsInsZaikoInfo();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", zaikoInfo.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                zaikoInfo.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(zaikoInfo.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(zaikoInfo.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(zaikoInfo.GoodsMakerCd);
                msgData.Append(zaikoInfo.GoodsNo);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyGoodsSearchCondWork HandyGoodsSearchCondObj = new HandyGoodsSearchCondWork();
                HandyGoodsSearchCondObj.MachineName = zaikoInfo.HtName.Trim();
                HandyGoodsSearchCondObj.EmployeeCode = zaikoInfo.EmpCd.Trim();
                HandyGoodsSearchCondObj.GoodsMakerCd = Int32.Parse(zaikoInfo.GoodsMakerCd.Trim());
                HandyGoodsSearchCondObj.GoodsNo = zaikoInfo.GoodsNo.Trim();
                HandyGoodsSearchCondObj.BarCodeData = string.Empty;
                condObjs = HandyGoodsSearchCondObj;
                retObjs = null;

                status = 0;
                try
                {
                    // 対ＰＭＮＳ側検索する
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.SearchHandyStockGoodsNo(ref condObjs, out retObjs, out hisNoObj);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                zaikoInfo.IniOutArg();
                zaikoInfo.RetVal = string.Empty;
                zaikoInfo.RetVal = status.ToString();

                Int32 rowGoods = 0;
                Int32 rowStock = 0;

                ArrayList GoodsInfoRetArray = new ArrayList();

                if (retObjs != null)
                {
                    GoodsInfoRetArray = (ArrayList)retObjs;
                }

                //エラー時用の処理
                if (GoodsInfoRetArray.Count == 0)
                {
                    zaikoInfo.RtMakerGoodsSearchHisNo = "0";
                    zaikoInfo.SetGoodsCount = "0";
                    zaikoInfo.SetStockCount = "0";
                    zaikoInfo.RelayGetOutArgHeader(ref ArgReply, ref ArgStpost);
                    zaikoInfo.RelayGetOutArgFooter(ref ArgReply, ref ArgStpost);
                }

                foreach (HandyStockInsGoodsInfo GoodsInfoRetObj in GoodsInfoRetArray)
                {
                    rowGoods += 1;

                    if (Int32.Parse(zaikoInfo.RetVal.ToString()) == 0)
                    {
                        //１行目処理
                        if (rowGoods == 1)
                        {
                            //ヘッダー情報
                            int hisNo = (int)hisNoObj;
                            zaikoInfo.RtMakerGoodsSearchHisNo = hisNo.ToString().Trim();
                            zaikoInfo.SetGoodsCount = GoodsInfoRetArray.Count.ToString();
                            zaikoInfo.RelayGetOutArgHeader(ref ArgReply, ref ArgStpost);
                        }

                        //商品情報
                        zaikoInfo.RtSupplierCd = clsCommon.gNullToStr(GoodsInfoRetObj.SupplierCd);
                        zaikoInfo.RtSupplierSnm = clsCommon.gNullToStr(GoodsInfoRetObj.SupplierSNm);
                        zaikoInfo.RtGoodsMakerCd = clsCommon.gNullToStr(GoodsInfoRetObj.GoodsMakerCd);
                        zaikoInfo.RtMakerShortName = clsCommon.gNullToStr(GoodsInfoRetObj.GoodsMakerShortName);
                        zaikoInfo.RtGoodsNo = clsCommon.gNullToStr(GoodsInfoRetObj.GoodsNo);
                        zaikoInfo.RtGoodsName = clsCommon.gNullToStr(GoodsInfoRetObj.GoodsName);

                        rowStock = 0;
                        if (GoodsInfoRetObj.StockList != null)
                        {
                            zaikoInfo.SetStockCount = GoodsInfoRetObj.StockList.Count.ToString();
                            zaikoInfo.RelayGetOutArgGoodsInfo(ref ArgReply, ref ArgStpost);

                            foreach (HandyStockInsStockInfo StockInfoRetObj in GoodsInfoRetObj.StockList)
                            {
                                rowStock += 1;

                                if (Int32.Parse(zaikoInfo.RetVal.ToString()) == 0)
                                {
                                    zaikoInfo.RtWarehouseCode = clsCommon.gNullToStr(StockInfoRetObj.WarehouseCode);
                                    zaikoInfo.RtWarehouseShelfNo = clsCommon.gNullToStr(StockInfoRetObj.WarehouseShelfNo);
                                    zaikoInfo.RtShipmentPosCnt = clsCommon.gNullToStr(StockInfoRetObj.ShipmentPosCnt);

                                    zaikoInfo.RelayGetOutArgStock(ref ArgReply, ref ArgStpost);
                                }
                            }
                        }
                        else
                        {
                            zaikoInfo.SetStockCount = "0";
                            zaikoInfo.RelayGetOutArgGoodsInfo(ref ArgReply, ref ArgStpost);
                        }

                        //フッター(処理結果出力)
                        if (rowGoods == GoodsInfoRetArray.Count)
                        {
                            zaikoInfo.RelayGetOutArgFooter(ref ArgReply, ref ArgStpost);
                        }
                    }
                }

                //対ハンディ 送信
                stReply = System.Text.Encoding.GetEncoding("shift_jis").GetString(ArgReply).TrimEnd('\0');
                reply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(stReply);

                //対ハンディ 送信
                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(zaikoInfo.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT UOE発注データ存在チェック"
        /// <summary>
        /// 商品在庫登録確定
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] ChkUoeOrder(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            object countObj = null;

            clsInsZaikoInsert zaikoInsert = new clsInsZaikoInsert();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", zaikoInsert.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                zaikoInsert.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(zaikoInsert.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(zaikoInsert.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(zaikoInsert.GoodsMakerCd);
                msgData.Append(zaikoInsert.GoodsNo);
                msgData.Append(zaikoInsert.WarehouseCode);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyGoodsUpdateCondWork HandyGoodsUpdateCondObj = new HandyGoodsUpdateCondWork();
                HandyGoodsUpdateCondObj.MachineName = zaikoInsert.HtName.Trim();
                HandyGoodsUpdateCondObj.EmployeeCode = zaikoInsert.EmpCd.Trim();
                HandyGoodsUpdateCondObj.GoodsMakerCd = Int32.Parse(zaikoInsert.GoodsMakerCd.Trim());
                HandyGoodsUpdateCondObj.GoodsNo = zaikoInsert.GoodsNo.Trim();
                HandyGoodsUpdateCondObj.WarehouseCode = zaikoInsert.WarehouseCode.Trim();
                HandyGoodsUpdateCondObj.WarehouseShelfNo = zaikoInsert.WarehouseShelfNo.Trim();
                HandyGoodsUpdateCondObj.SupplierCd = Int32.Parse(zaikoInsert.SupplierCd.Trim());
                HandyGoodsUpdateCondObj.StockCount = 0;
                HandyGoodsUpdateCondObj.MakerGoodsSerchHisNo = Int32.Parse(zaikoInsert.MakerGoodsSearchHisNo.Trim());

                condObjs = HandyGoodsUpdateCondObj;

                status = 0;
                try
                {
                    // 対ＰＭＮＳ側検索する
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.CheckHandyUOEOrder(ref condObjs, out countObj);

                            if (status == 0)
                            {
                                if ((int)countObj == 0)
                                {
                                    status = 0;
                                }
                                else
                                {
                                    status = 1;
                                }

                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                zaikoInsert.IniOutArg();
                zaikoInsert.RetVal = string.Empty;
                zaikoInsert.RetVal = status.ToString();

                reply = zaikoInsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(zaikoInsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
        #endregion

        #region "■INSERT 商品在庫登録確定"
        /// <summary>
        /// 商品在庫登録確定
        /// </summary>
        /// <param name="rcvData">処理対象データ</param>
        private byte[] InsZaikoInfo(byte[] rcvData)
        {
            StringBuilder msgYmdHms = new System.Text.StringBuilder();
            StringBuilder msgInfo = new System.Text.StringBuilder();
            StringBuilder msgData = new System.Text.StringBuilder();

            Int32 status = 0;
            object condObjs;

            byte[] reply = null;
            byte[] ArgReply = new byte[RELAY_LEN];
            string stReply = string.Empty;
            string strErrReply = string.Empty;
            byte[] byteErrReply = null;

            clsInsZaikoInsert zaikoInsert = new clsInsZaikoInsert();

            try
            {
                //エラー電文作成
                strErrReply = clsCommon.setMaeSpace(" ", zaikoInsert.DenbunLen) + clsBtConst.HT_MSG_SOCKETERR + clsBtConst.HT_MSG_CRLF;
                byteErrReply = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(strErrReply);

                //対ハンディ 受信 
                zaikoInsert.RelayGetHtInArg(rcvData);

                // 受信日時(１回の処理単位で同じ時間を使用する)
                msgYmdHms.Length = 0;
                msgYmdHms.Append("【");
                msgYmdHms.Append(zaikoInsert.HtName.Trim());
                msgYmdHms.Append(" ");
                msgYmdHms.Append(GetSckSyrKbn(zaikoInsert.SokSyoriKbn));
                msgYmdHms.Append(" ");
                msgYmdHms.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                msgYmdHms.Append("】");

                msgData.Length = 0;
                msgData.Append(zaikoInsert.GoodsMakerCd);
                msgData.Append(zaikoInsert.GoodsNo);
                msgData.Append(zaikoInsert.WarehouseCode);

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 受信=");
                msgInfo.Append(msgData.ToString());
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                //対ＰＭＮＳ　条件セット
                HandyGoodsUpdateCondWork HandyGoodsUpdateCondObj = new HandyGoodsUpdateCondWork();
                HandyGoodsUpdateCondObj.MachineName = zaikoInsert.HtName.Trim();
                HandyGoodsUpdateCondObj.EmployeeCode = zaikoInsert.EmpCd.Trim();
                HandyGoodsUpdateCondObj.GoodsMakerCd = Int32.Parse(zaikoInsert.GoodsMakerCd.Trim());
                HandyGoodsUpdateCondObj.GoodsNo = zaikoInsert.GoodsNo.Trim();
                HandyGoodsUpdateCondObj.WarehouseCode = zaikoInsert.WarehouseCode.Trim();
                HandyGoodsUpdateCondObj.WarehouseShelfNo = zaikoInsert.WarehouseShelfNo.Trim();
                HandyGoodsUpdateCondObj.SupplierCd = Int32.Parse(zaikoInsert.SupplierCd.Trim());
                HandyGoodsUpdateCondObj.StockCount = Int32.Parse(zaikoInsert.StockCount.Trim());
                HandyGoodsUpdateCondObj.GoodsKindCode = Int32.Parse(zaikoInsert.GoodsKindCodeRF.Trim());
                HandyGoodsUpdateCondObj.TaxationDivCd = Int32.Parse(zaikoInsert.TaxationDivCdRF.Trim());
                HandyGoodsUpdateCondObj.StockDiv = Int32.Parse(zaikoInsert.StockDivRF.Trim());
                HandyGoodsUpdateCondObj.MakerGoodsSerchHisNo = Int32.Parse(zaikoInsert.MakerGoodsSearchHisNo.Trim());
                // --- ADD 2020/04/22 M.KISHI ---------->>>>>
                try
                {
                    ArrayList warehouseResult = new ArrayList();
                    string warehouseparaEnterPriseCode = string.Empty;
                    string warehouseparaWarehouseCd = zaikoInsert.WarehouseCode;

                    object resultObj = (object)warehouseResult;
                    object paraEnterpriseCodeObj = (object)warehouseparaEnterPriseCode;
                    object paraWarehouseCd = (object)warehouseparaWarehouseCd;

                    int warehouseStatus = _iPmHandy.SearchHandyWarehouseInfoForStock(out resultObj, paraEnterpriseCodeObj, paraWarehouseCd);

                    if (warehouseStatus == 0)
                    {
                        warehouseResult = resultObj as ArrayList;

                        foreach (WarehouseWork itm in warehouseResult)
                        {
                            HandyGoodsUpdateCondObj.WarehouseName = itm.WarehouseName;
                        }
                    }

                }
                catch (Exception ex)
                {
                    LOGGER.Error("Get WarehouseInfo Error:" + ex.Message);
                }
                // --- ADD 2020/04/22 M.KISHI ----------<<<<<

                condObjs = HandyGoodsUpdateCondObj;

                status = 0;
                try
                {
                    // 対ＰＭＮＳ側検索する
                    int retryTimes = 0;
                    int.TryParse(clsCommon.gRetryTimes, out retryTimes);
                    int retryInterval = 0;
                    int.TryParse(clsCommon.gRetryInterval, out retryInterval);

                    for (int i = 0; i <= retryTimes; i++)
                    {
                        try
                        {
                            status = _iPmHandy.WriteHandyStock(ref condObjs);

                            if (status == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            status = -1;

                            if (i != 0)
                            {
                                LOGGER.Error("RETRY[" + i.ToString() + "]:STATUS=" + status + ex.Message);
                            }
                            else
                            {
                                LOGGER.Error(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgInfo.Length = 0;
                    msgInfo.Append(msgYmdHms.ToString());
                    msgInfo.Append("対ＰＭＮＳ エラー ");
                    msgInfo.Append(ex.Message);

                    LOGGER.Error(msgInfo.ToString());
                    status = Int32.Parse(clsBtConst.HT_MSG_SOCKETERR);
                }

                // 対ＰＭＮＳ　戻り値
                zaikoInsert.IniOutArg();
                zaikoInsert.RetVal = string.Empty;
                zaikoInsert.RetVal = status.ToString();

                reply = zaikoInsert.RelayGetOutArg();

                msgInfo.Length = 0;
                msgInfo.Append(msgYmdHms.ToString());
                msgInfo.Append("APLCom（対ハンディ） 送信=【");
                msgInfo.Append(zaikoInsert.RetVal);
                msgInfo.Append("】");
                msgInfo.Append(msgData.ToString());

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, msgInfo.ToString());

                return reply;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, err);
                return byteErrReply;
            }
        }
        #endregion
        // -- ADD 2020/04/01 ------------------------------<<<
#endregion
    }
}
