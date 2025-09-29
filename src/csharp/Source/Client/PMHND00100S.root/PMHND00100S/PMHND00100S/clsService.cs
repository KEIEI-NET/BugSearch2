using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using log4net;
using HT_RELAY_SERVICE.Common;
using HT_RELAY_SERVICE.Socket;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace HT_RELAY_SERVICE
{
    class clsService
    {
#region "定数"

    // ロガー
    private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    /// <summary>終了メッセージ</summary>
    private const string MESSAGE_CLOSE = "終了処理を実行してもよろしいですか？";

#endregion

#region "変数"

        // ************************************
        // メンバー変数
        // ************************************
        private System.Net.Sockets.TcpListener ServerSocket;        // リスナー(接続待ちや受信等を行なうｵﾌﾞｼﾞｪｸﾄ)
        private System.Threading.Thread ListeningCallbackThread;    // 接続待ちスレッド
        private volatile bool SLTAlive;                             // 接続待ちスレッド終了指示フラグ

        // 送受信電文処理スレッド呼び出し用オブジェクト
        private CommunicationCallbackDelegate Caller = null;

        // 送受信電文処理ﾒｿｯﾄﾞ用ﾃﾞﾘｹﾞｰﾄ
        delegate ProcessingResultOfCommunication CommunicationCallbackDelegate(System.Net.Sockets.TcpListener listener);

        // 待機中のスレッドを管理するオブジェクト
        private static System.Threading.ManualResetEvent AllDone = new System.Threading.ManualResetEvent(false);

        // 対ＰＭＮＳ用引数 RemoteObjectインターフェース
        private IPmHandy _iPmHandy;

        // 受信日時（ログ出力用）
        private string LogYmdTime = string.Empty;

#endregion

#region "イベント"

        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        public void ServiceStart(object sender, EventArgs e)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "frmConsole_Load -->>");

            try
            {
                // 受信日時（ログ出力用）セット
                LogYmdTime = "【 起動 "
                            + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                            + "】";

                // 多重起動チェック
                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "多重起動チェック エラー -->>");
                    return;
                }

                // スレッド終了指示フラグを未終了に初期化
                SLTAlive = false;

                // 送受信電文処理スレッド用メソッドをスレッド用メソッドとして登録
                Caller = new CommunicationCallbackDelegate(CommunicationCallback);

                // 対ハンデ用ソケット準備
                SocketSet();

                // 対ＰＭＮＳ用通信準備
                AplSet();

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "frmConsole_Load <<--");
            }
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <remarks></remarks>
        public void ServiceStop(object sender, EventArgs e)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "toolStripMenuItem1_Click -->>");

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
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "toolStripMenuItem1_Click <<--");
            }
        }
#endregion

#region "関数"
        /// <summary>
        /// 対ハンデ用ソケット準備
        /// </summary>
        /// <remarks></remarks>
        private void SocketSet()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "SocketSet -->>");
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

                    // 接続待ち用スレッドを開始
                    ListeningCallbackThread.Start();

                    // スレッド終了指示フラグを未終了に設定
                    SLTAlive = true;
                }
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "SocketSet ERROR = " + ex.Message);

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "SocketSet <<--");
            }
        }

        /// <summary>
        // 送受信電文処理スレッド用メソッド
        //  --- 受信された電文に対して、具体的な処理を行なうメソッドです。このサ
        //      ンプルでは、受信電文をテキストボックスに表示し、また、クライアン
        //      トへ返信を返す処理としています。
        //      なお、本メソッド(電文処理部)は、複数のクライアントからの接続に対
        //      応しています。すなわち、受信があるたびにスレッドが起動し、本メソ
        //      ッドが実行されます。
        /// </summary>
        /// <param name="listener">クライアントからの受信接続要求を処理するリスナー</param>
        /// <remarks>処理結果</remarks>
        public ProcessingResultOfCommunication CommunicationCallback(System.Net.Sockets.TcpListener listener)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "CommunicationCallback -->>");

            // AllDoneをシグナル状態にする。
            // すなわち、接続待ちスレッドのロックを解除して、接続待ちスレッドの実行再開の許可をする。
            AllDone.Set();

            // 処理結果格納用クラスの生成
            ProcessingResultOfCommunication ResultData = new ProcessingResultOfCommunication();

            if (SLTAlive)  // 接続待ちｽﾚｯﾄﾞが作成されていて使える場合
            {
                try
                {
                    // クライアントからの接続を受け付ける
                    System.Net.Sockets.TcpClient ClientSocket = listener.AcceptTcpClient(); // TCPｸﾗｲｱﾝﾄ

                    // 通信ストリームの取得
                    System.Net.Sockets.NetworkStream stream = ClientSocket.GetStream();

                    //============
                    // クライアントからの電文の受信
                    byte[] ReceiveData = new byte[2000];
                    int DataLength = stream.Read(ReceiveData, 0, ReceiveData.Length);   // 電文の列長
                    string rcvstr = System.Text.Encoding.Unicode.GetString(ReceiveData, 0, DataLength);
                    rcvstr = rcvstr.Trim();

                    // ハンディからの受信データ（string ResultData.ReceivedData）を元に
                    // アプリ側から情報を取得して、送信データ（string ResultData.Reply）にセット
                    byte[] reply = APLCom(ReceiveData);

                    //============
                    // 返信電文をクライアントへ送信
                    //byte[] SendBuffer = System.Text.Encoding.Unicode.GetBytes(ResultData.Reply);
                    stream.Write(reply, 0, reply.Length);
                    stream.Flush(); // フラッシュ(強制書き出し)

                    // 通信ストリームをクローズ
                    stream.Close();

                    // TCPｸﾗｲｱﾝﾄをｸﾛｰｽﾞ
                    ClientSocket.Close();
                }
                catch (Exception ex)
                {
                    clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "CommunicationCallback ERROR = " + ex.Message);
                }
            }

            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "CommunicationCallback <<--");

            return ResultData;
        }

        /// <summary>
        // 接続待ちスレッド用メソッド
        //  --- クライアントからの受信受け付けを行なうメソッドです。なお、受信受
        //      け付けを常に行なうため、無限ループで受け付け処理を行っています。
        //      無限ループは、処理を占有して、本サーバープログラム自体の動作に影
        //      響しますので、本メソッドは、スレッドとして起動します。
        /// </summary>
        /// <remarks></remarks>
        private void ListeningCallback()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "ListeningCallback -->>");

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
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "ListeningCallback ERROR = " + ex.Message);
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "ListeningCallback <<--");
            }
        }

        /// <summary>
        // スレッド完了時起動のコールバックメソッド
        // BeginInvokeでの呼び出し(非同期呼び出し)で起動されたスレッドにおいて、
        // その処理が完了した時に、呼び出し元に呼び出されるメソッドです。
        // よって、ワーカースレッド(BeginInvokeで呼び出されるスレッド)での処理
        // 結果に関する処理等をここに定義すると便利です。
        // 第1引数: 非同期ﾃﾞﾘｹﾞｰﾄでの非同期操作の結果(をカプセル化した物)
        /// </summary>
        /// <param name="AsyRes"></param>
        /// <remarks></remarks>
        private void ReturnCallback(IAsyncResult AsyRes)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "ReturnCallback -->>");

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
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "ReturnCallback ERROR = " + ex.Message);
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "ReturnCallback <<--");
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
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "APLCom -->>");

            try
            {
                string msgInfo = "";
                int status = 0;
                object condObjs;
                object retObjs;

                byte[] reply = null;
                clsLoginInfo logininfo = new clsLoginInfo();
                clsSyohinInfo syohininfo = new clsSyohinInfo();

                // ソケット処理区分を取得するために一旦ログイン情報で展開
                logininfo.RelayGetHtInArg(rcvData);
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "ソケット処理区分を取得=" + logininfo.SokSyoriKbn);

                switch (Int32.Parse(logininfo.SokSyoriKbn))
                {
                    // ログイン情報
                    case 1:
                        logininfo.RelayGetHtInArg(rcvData);

                        // 受信日時（ログ出力用）セット
                        LogYmdTime = "【" + logininfo.HtName.Trim() + " "
                                    + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                                    + "】";

                        msgInfo = "APLCom（対ハンディ） 受信 = " + logininfo.SokSyoriKbn + logininfo.HtName + logininfo.LoginId;
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                        HandyLoginInfoCondWork condObj = new HandyLoginInfoCondWork();
                        condObj.MachineName = logininfo.HtName.ToString();
                        condObj.LoginId = logininfo.LoginId.ToString();
                        condObjs = condObj;
                        retObjs = null;

                        msgInfo = "APLCom（対ＰＭＮＳ） 送信 = " + logininfo.HtName + logininfo.LoginId;
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                        status = 0;
                        try
                        {
                            // 対ＰＭＮＳ側検索する
                            status = _iPmHandy.SearchHandyLoginInfo(ref condObjs, out retObjs);
                        }
                        catch (Exception ex)
                        {
                            LOGGER.Error(LogYmdTime + "対ＰＭＮＳ エラー " + ex.Message);
                            status = -3;
                        }

                        logininfo.IniOutArg();
                        logininfo.RetVal = string.Empty;
                        logininfo.RetVal = status.ToString();

                        HandyLoginInfoWork LoginRetObj = new HandyLoginInfoWork();
                        if (retObjs != null)
                        {
                            LoginRetObj = (HandyLoginInfoWork)retObjs;
                        }

                        if (LoginRetObj != null)
                        {
                            msgInfo = "APLCom（対ＰＭＮＳ） 受信 = "
                                     + LoginRetObj.BelongSectionCode + LoginRetObj.BelongSectionName
                                     + LoginRetObj.EmployeeCode + LoginRetObj.Name
                                     + LoginRetObj.RetirementDate + LoginRetObj.EnterCompanyDate
                                     + LoginRetObj.AuthorityLevel1 + LoginRetObj.AuthorityLevel2
                                     + status.ToString();

                            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);
                        }
                        else
                        {
                            msgInfo = "APLCom（対ＰＭＮＳ） 受信 = " + status.ToString();
                            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);
                        }

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
                        }
                        
                        reply = logininfo.RelayGetOutArg();

                        break;

#region "関数 APLCom（商品情報）"
                    // 商品情報
                    case 2:
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "1");
                        syohininfo.RelayGetHtInArg(rcvData);
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "2");

                        // 受信日時（ログ出力用）セット
                        LogYmdTime = "【" + syohininfo.HtName.Trim() + " "
                                    + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                                    + "】";

                        msgInfo = "APLCom（対ハンディ） 受信 = " + syohininfo.SokSyoriKbn + syohininfo.HtName + syohininfo.SokoCd + syohininfo.TokShouCd;
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                        HandyLoginInfoCondWork SyohinCondObj = new HandyLoginInfoCondWork();    //TODO
                        SyohinCondObj.MachineName = syohininfo.HtName.ToString();               //TODO
                        SyohinCondObj.LoginId = syohininfo.SokoCd.ToString();                   //TODO
                        SyohinCondObj.LoginId = syohininfo.TokShouCd.ToString();                //TODO
                        condObjs = SyohinCondObj;
                        retObjs = null;

                        msgInfo = "APLCom（対ＰＭＮＳ） 送信 = " + syohininfo.HtName + syohininfo.SokoCd + syohininfo.TokShouCd;
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                        status = 0;
                        try
                        {
                            // 対ＰＭＮＳ側検索する
                            status = _iPmHandy.SearchHandyLoginInfo(ref condObjs, out retObjs);     //TODO
                        }
                        catch (Exception ex)
                        {
                            LOGGER.Error(LogYmdTime + "対ＰＭＮＳ エラー " + ex.Message);
                            status = -3;
                        }

                        syohininfo.IniOutArg();
                        syohininfo.RetVal = string.Empty;
                        syohininfo.RetVal = status.ToString();

                        HandyLoginInfoWork SyohinRetObj = new HandyLoginInfoWork();       //TODO
                        if (retObjs != null)
                        {
                            SyohinRetObj = (HandyLoginInfoWork)retObjs;                   //TODO
                        }

                        if (SyohinRetObj != null)
                        {
                            msgInfo = "APLCom（対ＰＭＮＳ） 受信 = "
                                     + SyohinRetObj.BelongSectionCode + SyohinRetObj.BelongSectionName      //TODO
                                     + SyohinRetObj.EmployeeCode + SyohinRetObj.Name                        //TODO
                                     + SyohinRetObj.RetirementDate + SyohinRetObj.EnterCompanyDate          //TODO
                                     + SyohinRetObj.AuthorityLevel1 + SyohinRetObj.AuthorityLevel2          //TODO
                                     + status.ToString();

                            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);
                        }
                        else
                        {
                            msgInfo = "APLCom（対ＰＭＮＳ） 受信 = " + status.ToString();
                            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);
                        }

                        if (Int32.Parse(syohininfo.RetVal.ToString()) == 0)
                        {
                            syohininfo.MakerCd = SyohinRetObj.BelongSectionCode;                      //TODO
                            syohininfo.MakerNm = SyohinRetObj.BelongSectionName;                      //TODO
                            syohininfo.SyoCd = SyohinRetObj.EmployeeCode;                             //TODO
                            syohininfo.TanaNo = SyohinRetObj.Name;                                    //TODO
                            syohininfo.RtSokoCd = SyohinRetObj.RetirementDate.ToString();             //TODO
                            syohininfo.SokoNm = SyohinRetObj.EnterCompanyDate.ToString();             //TODO
                            syohininfo.ZaikoNum = SyohinRetObj.AuthorityLevel1.ToString();            //TODO
                            syohininfo.LastUri = SyohinRetObj.AuthorityLevel2.ToString();             //TODO
                            syohininfo.LastSir = SyohinRetObj.AuthorityLevel2.ToString();             //TODO
                            syohininfo.BefTokShouCd = SyohinRetObj.AuthorityLevel2.ToString();        //TODO
                            syohininfo.NetTokShouCd = SyohinRetObj.AuthorityLevel2.ToString();        //TODO
                        }

                        reply = syohininfo.RelayGetOutArg();

                        break;
#endregion

#region "関数 APLCom（伝票情報）"

                    // 伝票情報
                    case 3:
                        break;
#endregion


                }
                msgInfo = "APLCom（対ハンディ） 送信 = "
                         + logininfo.BaseCd.ToString() + logininfo.BaseName.ToString()
                         + logininfo.EmpCd.ToString() + logininfo.EmpName.ToString()
                         + logininfo.RetDate.ToString() + logininfo.EntDate.ToString()
                         + logininfo.AutLv1.ToString() + logininfo.AutLv2.ToString()
                         + logininfo.RetVal.ToString();

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                //return reply;
                return reply;
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "APLCom ERROR = " + ex.Message);
                return null;
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "APLCom <<--");
            }
        }

        /// <summary>
        /// 対ＰＭＮＳ用通信準備
        /// </summary>
        /// <remarks></remarks>
        private void AplSet()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "AplSet -->>");

            try
            {
                // IPCセット
                _iPmHandy = (IPmHandy)Activator.GetObject(typeof(IPmHandy), clsCommon.gIpcAddress);

            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "AplSet ERROR = " + ex.Message);

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "AplSet <<--");
            }
        }

        /// <summary>
        /// アセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/08</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "LoadAssembly -->>");

            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "LoadAssembly ERROR = " + ex.Message);

                LOGGER.Error("AplSet ERROR = " + ex.Message);

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "LoadAssembly <<--");
            }
            
            return obj;
        }

#endregion
    
    }
}
