//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCM簡単問合せシステム間制御クラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/20  修正内容 : IAAE版から製品版へ変更(不要ロジック削除)
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/30  修正内容 : 売上伝票入力起動時に回答区分をセットする
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/20  修正内容 : 受信処理改良対応
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 20056　對馬 大輔
// 作 成 日  2010/06/17  修正内容 : Delphi売伝を起動するように変更
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 30434　工藤 恵優
// 作 成 日  2010/06/26  修正内容 : IDExchangeサービスの変更に伴う対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/03  修正内容 : ①システム側の接続アカウント管理関係のロジック削除
//                                 ②CMT接続中かフラグ管理する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/18  修正内容 : キャンセル区分の仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/03/03  修正内容 : CMT連携の取消対応
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;   

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
// 2011/03/03 Add >>>
using Broadleaf.Library.Collections;
using System.Collections;
// 2011/03/03 Add <<<

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// SCM簡単問合せシステム間制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成(IAAEから変更)</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/20</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM00008UA : Form
    {
        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region ■ Private Const

        /// <summary>デフォルトx座標</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>デフォルトy座標</summary>
        private const int DEFAULT_Y = 100000;

        /// <summary>ログファイル名称</summary>
        private const string ctLogName = "PMSCM00008U_{0}.log";

        private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01001U.exe";   // 2010/06/17
        private const string CTI_EXE_NAME = "PMSCM00100U.exe";              // 2011/03/04 Add

        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        private readonly string[] _commandLineArgs; // コマンドライン引数 
        private Thread _createInstanceThread;       // 売上伝票入力生成用スレッド
        private Thread _msgCatchProcThread = null;  // Ipcメッセージ受信処理用スレッド
        private PosTerminalMg _posTerminalMg;       // 端末管理情報

        //private MAHNB01010UA _entryFrm;             // 売上伝票入力 フォームクラス // 2010/06/17
        private PMSCM01104UA _compDlg;              // 完了画面

        bool first = true;                          // 初回起動フラグ

        private PMSCM01104UA _rcvForm = null;       // 処理中画面
        private List<PMSCM00009UA> _list;           // 受信画面リスト
        private UserSCMOrderHeaderRecord _cuurentData;  // 処理対象のSCM受注データ

        private CmtLocalSet _cmtLocalSet;           // ローカル設定

        // 2011/02/03 Del >>>
        //private SimplInqCnectInfoAcs _simplInqCnectInfoAcs;     // 簡単問合せ接続情報アクセスクラス
        // 2011/02/03 Del <<<
        private SimplInqIDExchangeAcs _simplInqIDExchangeAcs;   // 簡単問合せWebサービスアクセスクラス
        
        private IIOWriteScmDB _iIOWriteScmDB;       // SCM I/OWriter

        private SCMDtRcveExecAcs _sCMDtRcveExecAcs;  // SCM 受信起動リモートアクセスクラス  2010/05/20 Add

        // 2011/02/03 Add >>>
        private bool _cmtConnected = false;         // CMT接続管理フラグ
        // 2011/02/03 Add <<<

        #endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ■ Delegate

        /// <summary>エントリインスタンス生成デリゲート</summary>
        private delegate void CreateEntryInstanceDelegate();

        /// <summary>メッセージ受信処理用デリゲート</summary>
        /// <param name="msg">受信メッセージ</param>
        private delegate void CatchMessageDelegate(object msg);

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■ Property

        /// <summary>コマンドライン引数を取得します。</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMSCM00008UA()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        public PMSCM00008UA(string[] commandLineArgs)
            : this()
        {
            _commandLineArgs = commandLineArgs;

            // 2010/04/05 >>>
            //this._cmtConnectionAcs = new CMTConnectionAcs();    // 2010/03/02 Add

            // 2011/02/03 Del >>>
            //this._simplInqCnectInfoAcs = new SimplInqCnectInfoAcs();
            // 2011/02/03 Del <<<
            // 2010/04/05 <<<
        }

        #endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region ■ Control Event

        /// <summary>
        /// 画面 ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //// 初期位置を設定（ちらつき防止の為、10000にしています）
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

            this._iIOWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB(); // IOWriter

            // 端末管理情報の取得
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            posTerminalMgAcs.Search(out this._posTerminalMg, LoginInfoAcquisition.EnterpriseCode);

            // ローカル設定の取得
            CmtLocalSetAcs cmtLocalSetAcs = new CmtLocalSetAcs();
            this._cmtLocalSet = cmtLocalSetAcs.ReadScmLocalSet();
            if (this._cmtLocalSet == null) this._cmtLocalSet = new CmtLocalSet();
            if (this._cmtLocalSet.RecvTime == 0) this._cmtLocalSet.RecvTime = 30;
            if (this._cmtLocalSet.CTIMode == -1) this._cmtLocalSet.CTIMode = 1;   // 2011/03/04 Add
            cmtLocalSetAcs.CmtLocal = this._cmtLocalSet;
            cmtLocalSetAcs.WriteLocalSet();

            this.ScmLoadingDlg_Timer.Interval = this._cmtLocalSet.RecvTime * 1000;

            // IPCサーバーの生成・イベント登録
            SimpleInqPMIpcServer server = new SimpleInqPMIpcServer();
            server.SimplInqPMCommMsg.MessageRecieveEvent += new SimplInqPMCommMsg.ReceivedMessageEventHandler(msg_eventCall);
            // 2011/02/03 Add >>>
            server.SimplInqPMCommMsg.ConnectCheckEvent += new SimplInqPMCommMsg.CheckedConnectEventHandler(ConnectionCheck_EventCall);
            // 2011/02/03 Add <<<

            // アプリ終了時のイベント追加
            System.Windows.Forms.Application.ApplicationExit += new EventHandler(Application_ApplicationExit); 

            // 売上伝票入力インスタンス化スレッドの開始
            this._createInstanceThread = new Thread(new ThreadStart(this.CreateEntryInstance));
            this._createInstanceThread.IsBackground = true;
            this._createInstanceThread.Start();

            WriteLog("MainForm_Load", "常駐開始");
        }


        /// <summary>
        /// 画面表示時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// SCM共通処理中ダイアログ終了タイマー(Exception等で正常終了しなかったときの為)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScmLoadingDlg_Timer_Tick(object sender, EventArgs e)
        {
            ScmLoadingDlg_Timer.Enabled = false;
            try
            {
                if (_rcvForm != null)
                {
                    _rcvForm.Close();
                    _rcvForm.Dispose();
                    _rcvForm = null;
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 完了通知用タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compMsg_timer_Tick(object sender, EventArgs e)
        {
            compMsg_timer.Enabled = false;
            try
            {
                _compDlg.Close2();
                _compDlg.Dispose();
                _compDlg = null;
            }
            catch (Exception)
            {
            }
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        /// <summary>
        /// アプリケーション終了時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            // 2011/02/03 >>>
            //// 簡単問合せ接続情報をクリアする(自端末分)
            //this.ClearConnection();
            this._cmtConnected = false;
            // 2011/02/03 <<<

            System.Windows.Forms.Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
        }

        // 2011/02/03 Add >>>
        #region □ 接続管理関連
        /// <summary>
        /// 接続チェックイベント
        /// </summary>
        /// <param name="isConnected"></param>
        private void ConnectionCheck_EventCall(out bool isConnected)
        {
            // CMT連携中フラグを返す
            isConnected = this._cmtConnected;
        }
        #endregion
        // 2011/02/03 Add <<<

        #region □ メッセージ受信関連

        /// <summary>
        /// Ipcメッセージ受信時イベント
        /// </summary>
        /// <param name="str">Ipcクライアントからのメッセージ</param>
        private void msg_eventCall(string msg)
        {
            // メッセージ受信処理用スレッド開始
            this._msgCatchProcThread = new Thread(new ParameterizedThreadStart(CatchMessageThreadStart));
            this._msgCatchProcThread.IsBackground = true;   // バックグラウンドスレッド
            this._msgCatchProcThread.SetApartmentState(ApartmentState.STA);
            this._msgCatchProcThread.Start(msg);
        }

        /// <summary>
        ///	Ipcメッセージ受信時処理用スレッド開始処理
        /// </summary>
        /// <param name="msg">受信メッセージ</param>
        /// <remarks>
        /// <br>Note        : Ipcメッセージ受信時処理用スレッドを開始します。</br>
        /// </remarks>
        private void CatchMessageThreadStart(object msg)
        {
            // スレッドセーフにするためInvokeでデリゲートを呼び出す
            // ちなみに、別スレッドから直接メインスレッドのコントロールを変更できない
            Invoke(new CatchMessageDelegate(CatchMessageProc), msg);
        }

        /// <summary>
        /// メッセージ受信時の実際の処理
        /// </summary>
        /// <param name="msg">受信メッセージ</param>
        private void CatchMessageProc(object msg)
        {
            WriteLog("CatchMessageProc", "Start");

            /*---<メモ 受信メッセージは次の形式です-----------------------------------------------------------------------//
             * コミュニケーションツールの状態取得
             *  【プラグイン起動】
             *      "pluginon"
             *  【プラグイン終了】
             *      "pluginoff"
             *  【接続】
             *      "Connect"
             *  【切断】
             *      "DisConnect" (1アカウントの場合は、:区切りでアカウントIDを受信します)
             * 
             * PM→SF/BKの通信 (カンマ区切り)                                                                                                
             *  【問合せ回答/発注回答】                                                                                    
             *　    問合せ元企業コード:問合せ元拠点コード:問合せ先企業コード:問合せ先拠点コード:問合せ・発注種別:問合せ番号:更新日付:更新時間
             *  【相手方受信完了】                                                                                         
             *　    問合せ元企業コード:問合せ元拠点コード:問合せ先企業コード:問合せ先拠点コード:問合せ・発注種別:complete    
             ____________________________________________________________________________________________________________*/

            string[] messages;

            try
            {
                // パラメータ不正
                if (string.IsNullOrEmpty((string)msg))
                {
                    WriteLog("CatchMessageProc", "パラメータ不正");
                    return;
                }

                // 受信メッセージをコロンで区切る
                messages = ( (string)msg ).Split(':');

                WriteLog("CatchMessageProc", (string)msg);

                switch (messages[0])
                {
                    #region プラグイン:On
                    case "pluginon":
                        {
                            this._cmtConnected = true;  // 2011/02/03 Add
                            break;
                        }
                    #endregion  // プラグイン:On

                    #region プラグイン:Off
                    case "pluginoff":
                        {
                            // 2011/02/03 >>>
                            //this.ClearConnection();
                            this._cmtConnected = false;
                            // 2011/02/03 <<<
                            break;
                        }
                    #endregion  // プラグイン:Off

                    #region アカウント接続があった場合
                    case "Connect":
                        {
                            if (messages.Length > 1)
                            {
                                // 全アカウントを得意先に変換し、接続情報追加＆CTI起動
                                List<int> customerCodeList = new List<int>();
                                for (int i = 1; i < messages.Length; i++)
                                {
                                    CustomerSearchRet customer = GetCustomerFromInqAcount(messages[i]);
                                    if (customer != null)
                                    {
                                        if (!customerCodeList.Contains(customer.CustomerCode))
                                        {
                                            this.ExecuteCTI(customer.CustomerCode);
                                            // 2011/02/03 Del >>>
                                            //this.AddConnection(customer.CustomerCode);
                                            this._cmtConnected = true;
                                            // 2011/02/03 Del <<<
                                            customerCodeList.Add(customer.CustomerCode);
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    #endregion  // アカウント接続があった場合

                    #region 切断があった場合
                    case "DisConnect":
                        {
                            // 2011/02/03 Del >>>
                            //// アカウント指定がなかった場合は全て切断
                            //if (messages.Length == 1)
                            //{
                            //    this.ClearConnection();
                            //}
                            //else if (messages.Length > 1)
                            //{
                            //    // 全アカウントを得意先に変換し、接続情報削除
                            //    List<int> customerCodeList = new List<int>();
                            //    for (int i = 1; i < messages.Length; i++)
                            //    {
                            //        CustomerSearchRet customer = GetCustomerFromInqAcount(messages[i]);
                            //        if (customer != null)
                            //        {
                            //            if (!customerCodeList.Contains(customer.CustomerCode))
                            //            {
                            //                this.DelConnection(customer.CustomerCode);
                            //                customerCodeList.Add(customer.CustomerCode);
                            //            }
                            //        }
                            //    }
                            //}
                            // 2011/02/03 Del <<<
                            break;
                        }
                    #endregion  // 切断があった場合

                    #region 上記以外(受信、完了通知)
                    default:
                        // 2011/02/03 Add >>>
                        // 念の為ここでもフラグを立てる
                        this._cmtConnected = true;
                        // 2011/02/03 Add <<<
                        if (messages.Length > 5)
                        {
                            // 自企業・自拠点に送られたメッセージでなければ終了
                            if (messages[2] != LoginInfoAcquisition.EnterpriseCode || messages[3].Trim() != LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
                            {
                                WriteLog("CatchMessageProc", "自拠点宛の送信ではありません:" + LoginInfoAcquisition.EnterpriseCode + "," + LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                                return;
                            }
                            if ("complete" == messages[5])
                            {
                                // 相手方受信完了ダイアログ表示
                                completeDlgShow();
                            }
                            else if (messages.Length == 8)
                            {
                                // 2011/03/03 >>>
                                //_rcvForm = new PMSCM01104UA();
                                //int status = 0;
                                //_rcvForm.Title = "受信処理";
                                //_rcvForm.Message = "データを受信しています";
                                //_rcvForm.Show();

                                int status = 0;
                                if (_rcvForm == null)
                                {
                                    _rcvForm = new PMSCM01104UA();
                                    _rcvForm.Title = "受信処理";
                                    _rcvForm.Message = "データを受信しています";
                                    _rcvForm.Show();
                                }
                                // 2011/03/03 <<<
                                this.ScmLoadingDlg_Timer.Stop();
                                this.ScmLoadingDlg_Timer.Enabled = true;
                                this.ScmLoadingDlg_Timer.Start();

                                string inqOriginalEpCd = messages[0].Trim();
                                string inqOriginalSecCd = messages[1].Trim();
                                string inqOtherEpCd = messages[2].Trim();
                                string inqOtherSecCd = messages[3].Trim();
                                int inqOrdDivCd = TStrConv.StrToIntDef(messages[4].Trim(), 0);
                                long inqNum = (long)TStrConv.StrToDoubleDef(messages[5].Trim(), 0);

                                DateTime updateDate = DateTime.MinValue;
                                try
                                {
                                    updateDate = DateTime.ParseExact(messages[6].Trim(), "yyyyMMdd", null);
                                }
                                catch
                                {
                                }
                                int updateTime = TStrConv.StrToIntDef(messages[7].Trim(), 0);


                                status = 2;

                                // 問い合わせデータの読込
                                UserSCMOrderHeaderRecord scmorderHeader = null;
                                // 2011/03/03 Add >>>
                                List<UserSCMOrderDetailRecord> detailList = null;
                                // 2011/03/03 Add <<<

                                int retryCnt = this._cmtLocalSet.RecvTime;
                                for (int cnt = 1; cnt <= retryCnt; cnt++)
                                {
                                    // 2010/05/20 Add >>>
                                    this.ExecuteReceive();
                                    // 2010/05/20 Add <<<
                                    // 2011/03/03 >>>
                                    //scmorderHeader = this.ReadSCMData(inqOriginalEpCd, inqOriginalSecCd, inqOtherEpCd, inqOtherSecCd, inqNum, inqOrdDivCd, updateDate, updateTime);
                                    this.ReadSCMData(inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOtherEpCd, inqOtherSecCd, inqNum, inqOrdDivCd, updateDate, updateTime, out scmorderHeader, out detailList);//@@@@20230303
                                    // 2011/03/03 <<<
                                    if (scmorderHeader != null) break;
                                    System.Threading.Thread.Sleep(1000);
                                }

                                // あったら完了画面表示
                                if (scmorderHeader != null)
                                {
                                    status = 4;

                                    const string ctProtcol_SBpipe = "pmcmtpipe";
                                    // 簡単問合せにメッセージ送信
                                    string errorMsg;
                                    status = SimpleInquiryPipeMessage.Send(ctProtcol_SBpipe + ":" + messages[0] + ":" + messages[1] + ":" + messages[2] + ":" + messages[3] + ":" + messages[4] + ":" + "complete", 30000, out errorMsg);
                                    // 2011/02/03 >>>
                                    //this.AddConnection(scmorderHeader.CustomerCode);
                                    // 2011/02/03 <<<
                                    // 2011/03/03 >>>
                                    //this.ShowRcvCompDialog(scmorderHeader);
                                    this.ShowRcvCompDialog(scmorderHeader, detailList);
                                    // 2011/03/03 <<<
                                    status = 0;
                                }
                                else
                                {
                                    WriteLog("CatchMessageProc", "受信対象となるデータが存在しませんでした");

                                    if (this._cmtLocalSet.Retry == 1)
                                    {
                                        this.TopMost = true;
                                        System.Windows.Forms.Application.DoEvents();
                                        this.TopMost = false;
                                        DialogResult ret =
                                            MessageBox.Show(this, "データを受信できませんでした。" + Environment.NewLine + "再試行しますか？",
                                            "受信処理",
                                            MessageBoxButtons.RetryCancel,
                                            MessageBoxIcon.Information);

                                        if (ret == DialogResult.Retry)
                                        {
                                            this.CatchMessageThreadStart(msg);
                                            return;
                                        }
                                    }
                                }

                            }
                        }
                        
                        break;
                    #endregion  // 上記以外(受信、完了通知)
                }
            }
            catch (Exception ex)
            {
                WriteLog("CatchMessageProc", ex.Message);
            }
            finally
            {
                WriteLog("CatchMessageProc", "End");
            }
        }

        #endregion

        /// <summary>
        /// 完了通知画面表示処理
        /// </summary>
        private void completeDlgShow()
        {
            if (_compDlg == null)
            {
                compMsg_timer.Stop();
                _compDlg = new PMSCM01104UA();
                compMsg_timer.Enabled = true;
                _compDlg.Show2(this);
                compMsg_timer.Start();
            }
        }

        #region □ データ受信関連

        /// <summary>
        /// データ受信画面が表示されたときに呼び出されます
        /// </summary>
        /// <param name="sender">問発画面</param>
        /// <param name="e">イベントパラメータ</param>
        private void RcvCompDialog_Shown(object sender, EventArgs e)
        {
            // SCM共通処理中画面をクローズ
            try
            {
                lock (_rcvForm)
                {
                    if (_rcvForm != null)
                    {
                        _rcvForm.Close();
                        _rcvForm.Dispose();
                        _rcvForm = null;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 受信完了画面の表示
        /// </summary>
        /// <param name="header"></param>
        // 2011/03/03 >>>
        //private void ShowRcvCompDialog(UserSCMOrderHeaderRecord header)
        private void ShowRcvCompDialog(UserSCMOrderHeaderRecord header, List<UserSCMOrderDetailRecord> detailList)
        // 2011/03/03 <<<
        {
            if (_list != null && _list.Count > 0)
            {
                foreach (PMSCM00009UA fm in _list)
                {
                    if (fm != null && !fm.IsDisposed)
                    {
                        fm.Invoke(new MethodInvoker(fm.Close));
                        fm.Close();
                        fm.Dispose();
                    }
                }
                _list.Clear();

            }

            _cuurentData = new UserSCMOrderHeaderRecord();
            _cuurentData.EnterpriseCode = header.EnterpriseCode;
            _cuurentData.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
            _cuurentData.InqOriginalSecCd = header.InqOriginalSecCd;
            _cuurentData.InqOtherEpCd = header.InqOtherEpCd;
            _cuurentData.InqOtherSecCd = header.InqOtherSecCd;
            _cuurentData.InquiryNumber = header.InquiryNumber;
            _cuurentData.InqOrdDivCd = header.InqOrdDivCd;
            _cuurentData.AcptAnOdrStatus = header.AcptAnOdrStatus;
            _cuurentData.SalesSlipNum = header.SalesSlipNum;
            _cuurentData.AnswerDivCd = header.AnswerDivCd;
            // 2011/02/18 Add >>>
            _cuurentData.CancelDiv = header.CancelDiv;
            // 2011/02/18 Add <<<

            PMSCM00009UA frm = new PMSCM00009UA();

            frm.Top = ( Screen.PrimaryScreen.WorkingArea.Height - this.Height ) / 2;
            frm.Left = ( Screen.PrimaryScreen.WorkingArea.Width - this.Width ) / 2;

            // 得意先を取得
            CustomerInfo ret = this.GetCustomerInfo(header.CustomerCode);

            if (ret != null)
            {
                frm.CustomerCode = ret.CustomerCode;
                frm.CustomerSnm = ret.CustomerSnm;
            }

            frm.InqOrdDiv = (PMSCM00009UA.InqOrdDivCd)header.InqOrdDivCd;
            frm.InquiryNumber = header.InquiryNumber;
            // 2011/03/03 Add >>>
            frm.CancelDiv = header.CancelDiv;
            UserSCMOrderDetailRecord cancelRow = this.GetCancelRow(detailList);
            if (cancelRow != null)
            {
                frm.CancelRowNumber = cancelRow.InqRowNumber;
                frm.CancelGoodsName = ( string.IsNullOrEmpty(cancelRow.AnsGoodsName.Trim()) ) ? cancelRow.InqGoodsName.Trim() : cancelRow.AnsGoodsName.Trim();
            }
            // 2011/03/03 Add <<<

            // イベントの追加
            frm.button_ExecuteEntry.Click += new EventHandler(this.ExecuteEntry);
            frm.Shown += new EventHandler(RcvCompDialog_Shown);

            frm.Show();
            frm.TopMost = true;
            System.Windows.Forms.Application.DoEvents();
            frm.TopMost = false;
            if (_list == null) _list = new List<PMSCM00009UA>();
            _list.Add(frm);
        }

        // 2011/03/03 Add >>>
        /// <summary>
        /// 取消データかチェックします
        /// </summary>
        /// <param name="detailList"></param>
        /// <returns></returns>
        private UserSCMOrderDetailRecord GetCancelRow(List<UserSCMOrderDetailRecord> detailList)
        {
            return detailList.Find(
                    delegate(UserSCMOrderDetailRecord data)
                    {
                        if (data.CancelCndtinDiv == 30) return true;
                        return false;
                    });
            ;
        }
        // 2011/03/03 Add <<<


        #region 受信データの読み込み

        /// <summary>
        /// 受信データの読み込み
        /// </summary>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="inqOrdDivCd">問合せ・発注種別</param>
        /// <param name="updateDate">更新年月日</param>
        /// <param name="updateTime">更新時分秒ミリ秒</param>
        /// <returns></returns>
        // 2011/03/03 >>>
        //private UserSCMOrderHeaderRecord ReadSCMData(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, long inquiryNumber, int inqOrdDivCd, DateTime updateDate, int updateTime)
        private void ReadSCMData(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, long inquiryNumber, int inqOrdDivCd, DateTime updateDate, int updateTime, out UserSCMOrderHeaderRecord header, out List<UserSCMOrderDetailRecord> detailList)
        // 2011/03/03 <<<
        {
            SCMAcOdrDataWork para = new SCMAcOdrDataWork();
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            para.InqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            para.InqOriginalSecCd = inqOriginalSecCd;
            para.InqOtherEpCd = inqOtherEpCd;
            para.InqOtherSecCd = inqOtherSecCd;
            para.InquiryNumber = inquiryNumber;
            para.UpdateDate = updateDate;
            para.UpdateTime = updateTime;

            object paraObj = (object)para;
            // 2011/03/03 >>>
            //object retObj;

            //int status = this._iIOWriteScmDB.GetSCMAcOdrData(out retObj, paraObj);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    if (retObj is SCMAcOdrDataWork)
            //    {
            //        SCMAcOdrDataWork scmHeaderWork = (SCMAcOdrDataWork)retObj;
            //        UserSCMOrderHeaderRecord retHeader = new UserSCMOrderHeaderRecord(scmHeaderWork);

            //        return retHeader;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //else
            //{
            //    return null;
            //}

            header = null;
            detailList = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            int status = this._iIOWriteScmDB.GetSCMAcOdrData(ref retList, paraObj);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SCMAcOdrDataWork scmHeaderWork = null;
                ArrayList inqList = null;
                if (retList != null)
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        if (retList[i] is SCMAcOdrDataWork)
                        {
                            scmHeaderWork = (SCMAcOdrDataWork)retList[i];
                        }
                        else if (retList[i] is ArrayList)
                        {
                            inqList = (ArrayList)retList[i];
                        }
                    }
                }
                if (scmHeaderWork != null) header = new UserSCMOrderHeaderRecord(scmHeaderWork);

                if (inqList != null)
                {
                    detailList = new List<UserSCMOrderDetailRecord>();
                    foreach (SCMAcOdrDtlIqWork dtlInq in inqList)
                    {
                        detailList.Add(new UserSCMOrderDetailRecord(dtlInq));
                    }
                }
            }
            // 2011/03/03 <<<
        }

        #endregion // 受信データの読み込み


        // 2010/05/20 Add >>>
        /// <summary>
        /// データ受信処理の起動
        /// </summary>
        private int ExecuteReceive()
        {
            string msg;
            if (_sCMDtRcveExecAcs == null) _sCMDtRcveExecAcs = new SCMDtRcveExecAcs();
            //>>>2010/07/30
            this._sCMDtRcveExecAcs.GetStartParameterEvent += new SCMDtRcveExecAcs.GetStartParameterEventHandler(this.GetStartParameter);
            //<<<2010/07/30
            return this._sCMDtRcveExecAcs.DataReceive(false, out msg);
        }
        // 2010/05/20 Add <<<

        #endregion // データ受信関連

        /// <summary>
        /// 売上伝票入力インスタンス化処理
        /// </summary>
        private void CreateEntryInstance()
        {
            if (InvokeRequired)
            {
                // スレッドセーフ
                Invoke(new CreateEntryInstanceDelegate(CreateEntryInstance));
                return;
            }

            //_entryFrm = new MAHNB01010UA(); // 2010/06/17
        }

        /// <summary>
        /// エントリ画面の起動
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void ExecuteEntry(object obj, EventArgs e)
        {
            //>>>2010/06/17
            //while (_createInstanceThread.ThreadState == System.Threading.ThreadState.Running)
            //{
            //    Thread.Sleep(100);
            //}

            //bool isNew = false;
            //if (_entryFrm == null || _entryFrm.IsDisposed)
            //{
            //    _entryFrm = new MAHNB01010UA();
            //    isNew = true;
            //}
            //if (_cuurentData != null)
            //{
            //    _entryFrm.InqOriginalEpCd = _cuurentData.InqOriginalEpCd;
            //    _entryFrm.InqOriginalSecCd = _cuurentData.InqOriginalSecCd;
            //    _entryFrm.InquiryNumber = _cuurentData.InquiryNumber;
            //    _entryFrm.AcptAnOdrStatus = _cuurentData.AcptAnOdrStatus;
            //    _entryFrm.SalesSlipNum = _cuurentData.SalesSlipNum;
            //    // 2010/04/30 Add >>>
            //    _entryFrm.AnswerDivCd = _cuurentData.AnswerDivCd;
            //    // 2010/04/30 Add <<<
            //    _entryFrm.TopMost = true;
            //    System.Windows.Forms.Application.DoEvents();
            //    _entryFrm.TopMost = false;
            //    System.Windows.Forms.Application.DoEvents();
            //    _entryFrm.InqOrdDivCd = _cuurentData.InqOrdDivCd;

            //    if (_entryFrm.WindowState == FormWindowState.Minimized)
            //    {
            //        _entryFrm.WindowState = FormWindowState.Normal;
            //    }

            //    // ログインパラメータ情報を設定
            //    StringBuilder loginArguments = new StringBuilder();
            //    {
            //        foreach (string argument in CommandLineArgs)
            //        {
            //            if (!string.IsNullOrEmpty(argument.Trim()))
            //            {
            //                loginArguments.Append(argument + " ");
            //            }
            //        }
            //    }
            //    loginArguments.ToString();
            //}

            //_entryFrm.Show();
            //if (!first && !isNew)
            //{
            //    _entryFrm.InputInquiryNumber();
            //}
            //first = false;

            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return;

            // ログインパラメータ情報を設定
            StringBuilder param = new StringBuilder();
            {
                foreach (string argument in CommandLineArgs)
                {
                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        param.Append(argument + " ");
                    }
                }
            }

            param.Append("/SCM ");
            param.Append(_cuurentData.InquiryNumber.ToString() + ','); // 問合せ番号
            param.Append(_cuurentData.AcptAnOdrStatus.ToString() + ','); // 受注ステータス
            param.Append(_cuurentData.SalesSlipNum + ','); // 売上伝票番号
            param.Append(_cuurentData.InqOriginalEpCd.Trim() + ','); // 問合元企業コード//@@@@20230303_
            param.Append(_cuurentData.InqOriginalSecCd + ','); // 問合元拠点コード
            param.Append(_cuurentData.InqOrdDivCd.ToString() + ','); // 問合せ・発注種別
            // 2011/02/18 >>>
            //param.Append(_cuurentData.AnswerDivCd.ToString() + ','); // 回答区分
            param.Append(_cuurentData.CancelDiv.ToString() + ','); // キャンセル区分
            // 2011/02/18 <<<

            Process.Start(programPath, param.ToString());
            //<<<2010/06/17
        }

        // 2011/02/03 Del >>>
#if False
        #region □ 簡単問合せ接続情報の管理
        /// <summary>
        /// コミュニケーション情報の削除
        /// </summary>
        /// <param name="customerCode"></param>
        private void DelConnection(int customerCode)
        {
            WriteLog("DelConnection", string.Format("EnterpriseCode:{0},CashRegisterNo:{1},CustomerCode:{2}", LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, customerCode));

            this._simplInqCnectInfoAcs.DeleteConnect(LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, customerCode);
        }

        /// <summary>
        /// コミュニケーション情報の削除
        /// </summary>
        private void ClearConnection()
        {
            WriteLog("ClearConnection", "EnterpriseCode:" + LoginInfoAcquisition.EnterpriseCode + "," + "CashRegisterNo:" + this._posTerminalMg.CashRegisterNo.ToString());
            // 接続情報のクリア(得意先０で、端末情報を全てクリア)
            this._simplInqCnectInfoAcs.DeleteConnect(LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, 0);
        }

        /// <summary>
        /// コミュニケーション情報の追加
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        private void AddConnection(int customerCode)
        {
            WriteLog("AddConnection", string.Format("EnterpriseCode:{0},CashRegisterNo:{1},CustomerCode:{2}", LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, customerCode));

            this._simplInqCnectInfoAcs.AddConnect(LoginInfoAcquisition.EnterpriseCode, this._posTerminalMg.CashRegisterNo, customerCode);
        }

        #endregion // 簡単問合せ接続情報の管理
#endif
        // 2011/02/03 Del <<<

        /// <summary>
        /// 得意先情報の取得
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerInfo GetCustomerInfo(int customerCode)
        {
            CustomerInfo inf;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            int status = customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out inf);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return inf;
            }
            return null;
        }

        /// <summary>
        /// 簡単問合せのアカウントより、得意先を特定します。
        /// </summary>
        /// <param name="acntId"></param>
        /// <returns></returns>
        private CustomerSearchRet GetCustomerFromInqAcount(string acntId)
        {
            SmplInqBas smplInqbas = GetSmplInqBas(acntId);
            if (smplInqbas == null)
            {
                WriteLog("GetCustomerFromInqAcount", "アカウントの変換に失敗しました。:" + acntId);
                return null;
            }

            List<CustomerSearchRet> custList = new List<CustomerSearchRet>();
            CustomerSearchAcs _customerSearchAcs = new CustomerSearchAcs();
            CustomerSearchPara para = new CustomerSearchPara();
            {
                para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            CustomerSearchRet[] retList;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            int status = customerSearchAcs.Serch(out retList, para);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                custList = new List<CustomerSearchRet>();

                custList.AddRange(retList);
            }
            else
            {
                return null;
            }
            if (custList == null || custList.Count == 0) return null;

            // ADD 2010/06/26 IDExchangeサービスの変更に伴う対応 ---------->>>>>
            if (custList.Count.Equals(1))
            {
                return custList[0]; // 1件のみの場合、そのまま返す
            }

            // 企業コードは0詰16桁で統一
            smplInqbas.EnterpriseCode = smplInqbas.EnterpriseCode.Trim().PadLeft(16, '0');

            #region 企業コード + アカウントグループIDで得意先を特定（※該当なしの場合、企業コードのみで特定↓）

            SmplInqBasExt smpInqBasExt = smplInqbas as SmplInqBasExt;
            if (smpInqBasExt != null)
            {
                List<string> simplInqAcntGrIdList = smpInqBasExt.SimplInqAcntGrIdList;
                foreach (string simpInqAcntGrId in simplInqAcntGrIdList)
                {
                    CustomerSearchRet foundCustomer = custList.Find(
                        delegate(CustomerSearchRet searchRet)
                        {
                            // nullチェック
                            if (searchRet == null) return false;
                            if (string.IsNullOrEmpty(searchRet.CustomerEpCode))
                            {
                                searchRet.CustomerEpCode = string.Empty;
                            }
                            if (string.IsNullOrEmpty(searchRet.SimplInqAcntAcntGrId))
                            {
                                searchRet.SimplInqAcntAcntGrId = string.Empty;
                            }

                            // 企業コードは0詰16桁で統一
                            searchRet.CustomerEpCode = searchRet.CustomerEpCode.Trim().PadLeft(16, '0');

                            if (
                                searchRet.OnlineKindDiv == 10
                                    &&
                                searchRet.CustomerEpCode.Trim() == smplInqbas.EnterpriseCode.Trim()
                                    &&
                                searchRet.SimplInqAcntAcntGrId.Trim() == simpInqAcntGrId.Trim()
                            )
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );
                    if (foundCustomer != null) return foundCustomer;
                }   // foreach (string simpInqAcntGrId in simplInqAcntGrIdList)
            }   // if (smpInqBasExt != null)

            #endregion // 企業コード + アカウントグループIDで得意先を特定（※該当なしの場合、企業コードのみで特定↓）
            // ADD 2010/06/26 IDExchangeサービスの変更に伴う対応 ----------<<<<<

            #region 企業コードのみで得意先を特定

            CustomerSearchRet ret = custList.Find(
                delegate(CustomerSearchRet searchRet)
                {
                    // ADD 2010/06/26 IDExchangeサービスの変更に伴う対応 ---------->>>>>
                    // nullチェック
                    if (searchRet == null) return false;
                    if (string.IsNullOrEmpty(searchRet.CustomerEpCode))
                    {
                        searchRet.CustomerEpCode = string.Empty;
                    }

                    // 企業コードは0詰16桁で統一
                    searchRet.CustomerEpCode = searchRet.CustomerEpCode.Trim().PadLeft(16, '0');
                    // ADD 2010/06/26 IDExchangeサービスの変更に伴う対応 ----------<<<<<

                    if (searchRet.OnlineKindDiv == 10 &&
                        searchRet.CustomerEpCode.Trim() == smplInqbas.EnterpriseCode.Trim()
                        // TODO:本来は拠点まで当てる→2010/06/26 簡単問合せアカウントグループIDで当てる↑
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            #endregion // 企業コードのみで得意先を特定

            return ret;
        }

        /// <summary>
        /// 簡単問合せアカウント情報の取得
        /// </summary>
        /// <param name="acntId">アカウントID</param>
        /// <returns></returns>
        private SmplInqBas GetSmplInqBas(string acntId)
        {
            if (this._simplInqIDExchangeAcs == null) this._simplInqIDExchangeAcs= new SimplInqIDExchangeAcs();

            SmplInqInf inf;
            SmplInqBas bas;
            List<SmplInqChg> chgList;
            string msg;
            int status = this._simplInqIDExchangeAcs.SearchRelatedSmplInqInf(acntId, out inf, out bas, out chgList, out msg);

            return bas;
        }
        
        /// <summary>
        /// CTI画面起動
        /// </summary>
        /// <param name="customerCode"></param>
        private void ExecuteCTI(int customerCode)
        {
            // 2011/03/04 >>>
            //string programPath = Path.Combine(Directory.GetCurrentDirectory(), "PMSCM00100U.EXE");
            //if (!File.Exists(programPath)) return;

            //// ログインパラメータ情報を設定
            //StringBuilder arguments = new StringBuilder();
            //{
            //    foreach (string argument in CommandLineArgs)
            //    {
            //        if (!string.IsNullOrEmpty(argument.Trim()))
            //        {
            //            arguments.Append(argument + " ");
            //        }
            //    }
            //}

            //arguments.Append("/Customer," + customerCode.ToString());

            //Process.Start(programPath, arguments.ToString());

            CmtLocalSetAcs cmtLocalSetAcs = new CmtLocalSetAcs();
            CmtLocalSet localSet = cmtLocalSetAcs.ReadScmLocalSet();
            if (localSet == null) localSet = this._cmtLocalSet;
            if (localSet.CTIMode <= 0) return;

            string programPath = Path.Combine(Directory.GetCurrentDirectory(), ( localSet.CTIMode == 1 ) ? CTI_EXE_NAME : SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return;

            // ログインパラメータ情報を設定
            StringBuilder arguments = new StringBuilder();
            {
                foreach (string argument in CommandLineArgs)
                {
                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        arguments.Append(argument + " ");
                    }
                }
            }

            switch (localSet.CTIMode)
            {
                case 1:
                    arguments.Append("/Customer," + customerCode.ToString());
                    break;
                case 2:
                    arguments.Append("/CTI ");
                    arguments.Append(customerCode.ToString());
                    break;
                default:
                    break;
            }
            

            Process.Start(programPath, arguments.ToString());

            // 2011/03/04 <<<
        }

        //>>>2010/07/30
        /// <summary>
        /// 起動パラメータ取得処理(エントリメイン画面でデリゲートで使用)
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameter(out string param)
        {
            if (this._commandLineArgs.Length != 0)
            {
                param = this._commandLineArgs[0] + " " + this._commandLineArgs[1];
            }
            else
            {
                param = string.Empty;
            }
        }
        //<<<2010/07/30
        #endregion

        #region ログ

        /// <summary>
        /// ログ書込み
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="msg"></param>
        private static void WriteLog(string methodName, string msg)
        {
            System.IO.FileStream _fs = null;										// ファイルストリーム
            System.IO.StreamWriter _sw = null;										// ストリームwriter
            string dir = System.IO.Directory.GetCurrentDirectory();
            dir = Path.Combine(dir, @"log\SimpleInquiryConnect");

            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                _fs = new FileStream(Path.Combine(dir, string.Format(ctLogName, DateTime.Now.ToString("yyyyMMdd"))), FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));

                DateTime edt = DateTime.Now;
                _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2},{3}", edt, edt.Millisecond, methodName, msg));
            }
            catch
            {
            }
            finally
            {
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
        }

        #endregion
    }
}
