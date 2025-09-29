//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/10/10  修正内容 : 新規作成：ＴＳＰ送受信処理【ＰＭ側】(SFMIT02851A)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : SCM用にアレンジ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21112 久保田 誠
// 作 成 日  2011/06/01  修正内容 : 送信ログの難読化(Base64によるエンコード)
//　　　　　　　　　　　　　　　　　上記に伴う送信ログ表示ウィンドウの追加
//　　　　　　　　　　　　　　　　　テーブルレイアウト変更対応
// 管理番号              作成担当 : ZHANGYH
// 作 成 日  2011/07/12  修正内容 : 1分問題対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/06  修正内容 : Websync PCCUOEのチャンネルを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/10/17  修正内容 : SCM障害対応 SCM連携未送信データ取得条件を修正 №10414
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/12/05  修正内容 : 2012/12/99配信 SCM障害№10442対応 送信ボタン表示制御、単体起動時ログ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/08/28  修正内容 : タブレットからの売上登録時、"送信中"ウィンドウを非表示にする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/09  修正内容 : SCM仕掛一覧№10641対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/11/26  修正内容 : SCM仕掛一覧№10707対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/06/30  修正内容 : ②SCM仕掛一覧№10707 ログ出力の追加
//----------------------------------------------------------------------------//

#define _ENABLED_SENDING_   // 送信を行うフラグ(開発用：送信処理を無効にする際にコメント化) ※注意！通常は有効にしておくこと！

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 回答送信処理コントローラクラス
    /// </summary>
    public abstract class SCMSendController : ILogable
    {
        #region API定義
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        static extern uint SendMessage(IntPtr window, int msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        public const Int32 WM_COPYDATA = 0x4A;
        public const Int32 WM_USER = 0x400;

        //COPYDATASTRUCT構造体 
        struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public UInt32 cbData;
            public string lpData;
        }
        #endregion 

        /// <summary>プログラムID</summary>
        private const string PG_ID  = "PMSCM01100U";
        /// <summary>プログラム名称</summary>
        private const string PG_NAME= "回答送信処理";
        // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ---------->>>>>>>>>>
        /// <summary>
        /// 回答送信処理起動時に、タブレットからの起動を伝える為の引数
        /// </summary>
        public const string CMD_LINE_FOR_PMSCM01100_TABLET = "TABLET";

        private string _cmdLineTablet = string.Empty;
        public string CmdLineTablet
        {
            set { _cmdLineTablet = value; }
            get { return _cmdLineTablet; }
        }
        // ADD 2013/08/28 吉岡 タブレット 送信中ウィンドウ非表示 ----------<<<<<<<<<<


        #region <起動モード>

        /// <summary>
        /// バッチ処理(送信起動モード)であるか判断します。
        /// </summary>
        /// <value>
        /// <c>true</c> :バッチ処理(送信起動モード)です。<br/>
        /// <c>false</c>:対話処理(単体起動モード)です。
        /// </value>
        public abstract bool IsBatchMode { get; }

        // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// 送信ボタン表示
        public bool SendDisplay = false;
        // --- ADD 2012/12/05 三戸 2012/12/99配信分 SCM障害№10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion // </起動モード>

        #region <設定情報>

        /// <summary>設定情報</summary>
        private readonly SCMSendSettingInformation _settingInfo = new SCMSendSettingInformation();
        /// <summary>設定情報を取得します。</summary>
        public SCMSendSettingInformation SettingInfo { get { return _settingInfo; } }

        #endregion // </設定情報>

        #region <ログ>

        /// <summary>ログファイル名称</summary>
        //protected const string LOG_FILE_NAME = "ScmSendLog.txt";  //DEL 2011/06/01
        //--- ADD 2011/06/01 -------------------------------------------->>>
        protected const string LOG_FILE_NAME = "ScmSendLog_{0:yyyyMM}.dat";
        
        /// <summary>ログファイル名書式</summary>
        public string LogFileNameFormat { get { return LOG_FILE_NAME; } }
        //--- ADD 2011/06/01 --------------------------------------------<<<

        /// <summary>ログファイルのパス</summary>
        protected string _logFilePath;
        /// <summary>ログファイルのパスを取得します。</summary>
        public string LogFilePath { get { return _logFilePath; } }

        /// <summary>ログファイルのオープン済みフラグ</summary>
        private bool _isOpenedLog;
        /// <summary>ログファイルのオープン済みフラグを取得します。</summary>
        public bool IsOpenedLog { get { return _isOpenedLog; } }

        /// <summary>テキスト書込</summary>
        private TextWriter _textWriter;
        /// <summary>テキスト書込を取得します。</summary>
        private TextWriter TextWriter
        {
            get { return _textWriter; }
            set { _textWriter = value; }
        }

        /// <summary>
        /// ログファイルをオープンします。
        /// </summary>
        /// <remarks>排他処理も兼ねる（リトライ6回）</remarks>
        /// <returns>-1の時はオープン失敗</returns>
        public int OpenLog()
        {
            // UPD 2014/04/09 SCM仕掛一覧№10641対応 -------------------------------->>>>>
            //const int LIMIT = 5;        // リトライのリミッタ
            //const int SLEEP_SEC = 1000; // 1秒待ち
            const int LIMIT = 59;        // リトライのリミッタ
            const int SLEEP_SEC = 5000; // 5秒待ち
            // UPD 2014/04/09 SCM仕掛一覧№10641対応 --------------------------------<<<<<

            # region --- DEL 2011/06/01 ---
            // ログファイルを月単位に分けて保存する仕様の変更に伴い、バックアップ処理は削除する
            
            // 条件付きでログをバックアップ
            //string backupedLogFileName = SimpleLogger.BackupLogIf(LogFilePath);
            //bool isAppendMode = string.IsNullOrEmpty(backupedLogFileName);
            # endregion

            bool isAppendMode = true;  //ADD 2011/06/1

            int limitter = 0;
            while (limitter < LIMIT)
            {
                try
                {
                    TextWriter = new StreamWriter(LogFilePath, isAppendMode, Encoding.GetEncoding("SHIFT-JIS"));
                    ((StreamWriter)TextWriter).AutoFlush = true;  //ADD 2011/06/01

                    _isOpenedLog = (TextWriter != null);

                    # region --- DEL 2011/06/01 ---
                    //if (!string.IsNullOrEmpty(backupedLogFileName))
                    //{
                    //    WriteLog("過去のログデータを " + backupedLogFileName + " に退避しました。");
                    //}
                    # endregion

                    // ADD 2014/04/09 SCM仕掛一覧№10641対応 -------------------------------->>>>>
                    // 単体起動の排他制御時はStreamWriterを使用してログ出力を行わないのでログファイルをクローズする
                    if (!this.IsBatchMode)
                    {
                        this.TextWriter.Close();
                    }
                    // ADD 2014/04/09 SCM仕掛一覧№10641対応 --------------------------------<<<<<

                    return (int)ResultUtil.ResultCode.Normal;
                }
                catch (IOException e)
                {
                    Debug.WriteLine(e.ToString());
                    limitter++;
                    Thread.Sleep(SLEEP_SEC);
                }
            }
            _isOpenedLog = false;
            return (int)ResultUtil.ResultCode.Error;
        }

        /// <summary>
        /// ログを書込みます。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void WriteLog(string msg)
        {
            #region <Guard Phrase>

            if (!IsOpenedLog)
            {
                Debug.Assert(false, "ログファイルをオープンしていません。");
                return;
            }

            #endregion // </Guard Phrase>

            # region --- DEL 2011/06/01 ---
            //string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            //TextWriter.WriteLine(dateTime + "  " + msg);
            # endregion

            //--- ADD 2011/06/01 ---------------------------------------->>>
            msg = String.Format("{0:yyyy/MM/dd HH:mm:ss}  {1}", DateTime.Now, msg);

            // 行単位でBase64変換をし、パッと見た感じ何が記述されているのかわからなくする
            byte[] binMsg = Encoding.GetEncoding("shift-jis").GetBytes(msg);
            string encMsg = System.Convert.ToBase64String(binMsg);

            // UPD 2014/04/09 SCM仕掛一覧№10641対応 ---------------------------->>>>>
            //this.TextWriter.WriteLine(encMsg);
            if (this.IsBatchMode)
            {
                this.TextWriter.WriteLine(encMsg);
            }
            else
            {
                // 単体起動時はTextWriterを使用しない
                System.IO.File.AppendAllText(LogFilePath, encMsg + Environment.NewLine, Encoding.GetEncoding("SHIFT-JIS"));
            }
            // UPD 2014/04/09 SCM仕掛一覧№10641対応 ----------------------------<<<<<
            //--- ADD 2011/06/01 ----------------------------------------<<<
        }

        /// <summary>
        /// ログの保存と終了を行います。
        /// </summary>
        public void CloseLog()
        {
            #region <Guard Phrase>

            if (TextWriter == null)
            {
                Debug.Assert(false, "ストリームが null です。");
                return;
            }

            #endregion // </Guard Phrase>

            TextWriter.Close();
            _isOpenedLog = false;
        }

        #endregion // </ログ>

        #region <SCM I/O>

        /// <summary>SCM I/O</summary>
        private SCMIOAgent _scmIO;
        /// <summary>SCM I/O を取得します。</summary>
        protected SCMIOAgent SCMIO
        {
            get
            {
                if (_scmIO == null)
                {
                    _scmIO = CreateSCMIO(_settingInfo.SCMDataPath);
                }
                //>>>2010/04/08
                //// 2010/03/15 Add >>>
                //_scmIO.SalesSlipNum = SalesSlipNum;
                //_scmIO.AcptAnOdrStatus = AcptAnOdrStatus;
                //// 2010/03/15 Add <<<

                _scmIO.InquiryNumber = InquiryNumber;
                _scmIO.InqOrdDivCd = InqOrdDivCd;
                // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
                _scmIO.SalesSlipNumList = SalesSlipNumList;
                // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<
                //<<<2010/04/08
                return _scmIO;
            }
        }

        /// <summary>
        /// SCM I/Oを生成します。
        /// </summary>
        /// <param name="dataPath">データパス</param>
        /// <returns>SCM I/O</returns>
        protected abstract SCMIOAgent CreateSCMIO(string dataPath);

        /// <summary>
        /// 
        /// </summary>
        public void ClearSCMIOData()
        {
            _sendingViewDB = null;
            _scmIO = null;
        }

        #endregion // </SCM I/O>

        #region <送信処理画面用データセット>

        /// <summary>送信処理画面用データセット</summary>
        private SCMSendViewDataSet _sendingViewDB;
        /// <summary>送信処理画面用データセットを取得します。</summary>
        protected SCMSendViewDataSet SendingViewDB
        {
            get
            {
                if (_sendingViewDB == null)
                {
                    SCMIO.SettingInformation = this.SettingInfo;
                    _sendingViewDB = SCMIO.CreateSCMSendViewDataSet();
                }
                return _sendingViewDB;
            }
        }

        /// <summary>
        /// 送信先得意先リスト用テーブルを取得します。
        /// </summary>
        public SCMSendViewDataSet.SendingCustomerDataTable SendingCustomerTable
        {
            get { return SendingViewDB.SendingCustomer; }
        }

        /// <summary>
        /// 送信伝票リスト用テーブルを取得します。
        /// </summary>
        public SCMSendViewDataSet.SendingSlipHeaderDataTable SendingHeaderTable
        {
            get { return SendingViewDB.SendingSlipHeader; }
        }

        /// <summary>
        /// 明細詳細画面用テーブルを取得します。
        /// </summary>
        public SCMSendViewDataSet.SendingSlipDetailDataTable SendingDetailTable
        {
            get { return SendingViewDB.SendingSlipDetail; }
        }

        #endregion // </送信処理画面用データセット>

        #region <SCM Web-DB>

        /// <summary>SCM Web-DBのアクセサ</summary>
        private SCMWebAcsAgent _scmWebDB;
        /// <summary>SCM Web-DBのアクセサを取得します。</summary>
        protected SCMWebAcsAgent SCMWebDB
        {
            get
            {
                if (_scmWebDB == null)
                {
                    _scmWebDB = new SCMWebAcsAgent();
                }
                return _scmWebDB;
            }
        }

        #endregion // </SCM Web-DB>

        #region <情報部>

        private int _stat0Cnt;
        /// <summary>未送信データ件数</summary>
        public int Stat0Cnt { get { return _stat0Cnt; } }

        private int _stat1Cnt;
        /// <summary>未送信データ件数</summary>
        public int Stat1Cnt { get { return this._stat1Cnt; } }

        //private int _stat2Cnt;
        ///// <summary>未送信データ件数</summary>
        //public int Stat2Cnt { get { return this._stat2Cnt; } }

        #endregion // </情報部>

        #region <送信>

        // 2011.07.12 ZHANGYH DEL STA >>>>>>
        ///// <summary>
        ///// 送信します。
        ///// </summary>
        ///// <returns>結果コード</returns>
        //public int Send()
        //{
        //#if _ENABLED_SENDING_
        //    // SCM Webサーバへ送信
        //    int status = SendToWebServer();
        //    SendRecevingClose();
        //    // SCM受注データを更新
        //    status = UpdateAfterSend();
        //    if (!status.Equals((int)ResultUtil.ResultCode.Normal))
        //    {
        //        WriteLog("Webサーバーへの回答後のDB更新処理でエラーが発生しました。");
        //        WriteLog(status.ToString());
        //        return status;
        //    }
        //#else
        //    int status = 0;
        //#endif
        //    WriteLog("回答送信処理を終了しました。");

        //    return status;
        //}
        // 2011.07.12 ZHANGYH DEL END <<<<<<

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        /// <summary>
        /// 送信します。
        /// </summary>
        /// <returns>結果コード</returns>
        public int Send()
        {
            List<string> sendEnterpriceCodeList = null;
            List<string> sendSectionCodeList = null;
            // 2011.09.06 zhouzy UPDATE STA >>>>>>
            List<SCMAcOdrDataWork> scmAcOdrDataList = null;

            //return Send(out sendEnterpriceCodeList, out sendSectionCodeList);
            return Send(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            // 2011.09.06 zhouzy UPDATE END <<<<<<

        }

        /// <summary>
        /// 送信します。
        /// </summary>
        /// <returns>結果コード</returns>
        ///             
        // 2011.09.06 zhouzy UPDATE STA >>>>>>
        //public int Send(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList)
        public int Send(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList, out List<SCMAcOdrDataWork> scmAcOdrDataList)
        // 2011.09.06 zhouzy UPDATE END <<<<<<
        {
            sendEnterpriceCodeList = null;
            sendSectionCodeList = null;
        #if _ENABLED_SENDING_
            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
            SCMWebDB.SettingInformation = this.SettingInfo;
            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

            // SCM Webサーバへ送信
            // 2011.09.06 zhouzy UPDATE STA >>>>>>
            //int status = SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList);
            SimpleLogger.WriteDebugLog("SCMSendController", "Send", "SCM Webサーバ送信開始"); // ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707
            int status = SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            SimpleLogger.WriteDebugLog("SCMSendController", "Send", string.Format("SCM Webサーバ送信終了：status = [{0}]", status)); // ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707
            // 2011.09.06 zhouzy UPDATE END <<<<<<

            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
            if (!status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                string commentSlipNumber = string.Empty;
                bool flag = false;
                if (scmAcOdrDataList != null)
                {
                    foreach (SCMAcOdrDataWork tempHeader in scmAcOdrDataList)
                    {
                        if (flag) commentSlipNumber = commentSlipNumber + ",";
                        commentSlipNumber = commentSlipNumber + tempHeader.SalesSlipNum;
                        flag = true;
                    }
                }

                string msg = "回答送信中にエラーが発生した為、送信できませんでした。" + Environment.NewLine +
                                "(Webサーバ更新エラー)" + Environment.NewLine +
                                "売上伝票番号【" + commentSlipNumber + "】" + Environment.NewLine + Environment.NewLine +
                                "担当サポートへ連絡をお願い致します。";

                if (!(this is SCMMethodCalledController) && this.IsBatchMode)
                {
                    MessageBox.Show(msg, "回答送信処理", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msg = msg + Environment.NewLine + "ステータス【" + status.ToString() + "】";
                }
                SimpleLogger.WriteSlipNumLog(this.SettingInfo.SCMDataPath, msg);
                WriteLog(msg);
                return status;
            }
            // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<

            SendRecevingClose();
            // SCM受注データを更新
            status = UpdateAfterSend();
            if (!status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                string commentSlipNumber = string.Empty;
                bool flag = false;
                if (scmAcOdrDataList != null)
                {
                    foreach (SCMAcOdrDataWork tempHeader in scmAcOdrDataList)
                    {
                        if (flag) commentSlipNumber = commentSlipNumber + ",";
                        commentSlipNumber = commentSlipNumber + tempHeader.SalesSlipNum;
                        flag = true;
                    }
                }

                string msg = "回答送信中にエラーが発生した為、送信できませんでした。" + Environment.NewLine +
                                "(ユーザDB更新エラー)" + Environment.NewLine +
                                "売上伝票番号【" + commentSlipNumber + "】" + Environment.NewLine + Environment.NewLine +
                                "担当サポートへ連絡をお願い致します。";

                if (!(this is SCMMethodCalledController) && this.IsBatchMode)
                {
                    MessageBox.Show(msg, "回答送信処理", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msg = msg + Environment.NewLine + "ステータス【" + status.ToString() + "】";
                }
                SimpleLogger.WriteSlipNumLog(this.SettingInfo.SCMDataPath, msg);
                WriteLog(msg);
                // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
                WriteLog("Webサーバーへの回答後のDB更新処理でエラーが発生しました。");
                WriteLog(status.ToString());
                return status;
            }
        #else
            int status = 0;
        #endif
            WriteLog("回答送信処理を終了しました。");

            return status;
        }
        // 2011.07.12 ZHANGYH ADD END <<<<<<

        private void SendRecevingClose()
        {
            Process[] pr = Process.GetProcessesByName("PMSCM01104U");
            foreach (Process process in pr)
            {
                COPYDATASTRUCT st = new COPYDATASTRUCT();

                string msg = "Close";
                st.dwData = (IntPtr)0;
                st.cbData = (uint)( msg.Length + 1 );
                st.lpData = msg;

                SendMessage(process.MainWindowHandle, WM_COPYDATA, (IntPtr)0, ref st);
            }
        }

        /// <summary>
        /// SCM Webサーバへ送信します。
        /// </summary>
        /// <param name="sendEnterpriceCodeList">企業コードリスト</param>
        /// <param name="sendSectionCodeList">拠点コードリスト</param>
        /// <returns>結果コード</returns>
        // 2011.07.13 ZHANGYH EDT STA >>>>>>
        //protected int SendToWebServer()
        // 2011.09.06 zhouzy UPDATE STA >>>>>>
        //protected int SendToWebServer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList)
        protected int SendToWebServer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList, out List<SCMAcOdrDataWork> scmAcOdrDataList)
        // 2011.09.06 zhouzy UPDATE END <<<<<<
        // 2011.07.13 ZHANGYH EDT END <<<<<<
        {
            SCMWebDB.Logger = this;

            string errMsg = string.Empty;
            // 2011.07.13 ZHANGYH EDT STA >>>>>>
            //int status = SCMWebDB.WriteAnswerData(SCMIO, ref errMsg);
            // 2011.09.06 zhouzy UPDATE STA >>>>>>
            //int status = SCMWebDB.WriteAnswerData(SCMIO, ref errMsg, out sendEnterpriceCodeList, out sendSectionCodeList);
            int status = SCMWebDB.WriteAnswerData(SCMIO, ref errMsg, out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            // 2011.09.06 zhouzy UPDATE END <<<<<<
            // 2011.07.13 ZHANGYH EDT END <<<<<<

            if (errMsg.Length != 0)
            {
                WriteLog(errMsg);
            }

            return status;
        }

        // 2011.07.13 ZHANGYH ADD STA >>>>>>
        /// <summary>
        /// SCM Webサーバへ送信します。
        /// </summary>
        /// <returns>結果コード</returns>
        protected int SendToWebServer()
        {
            List<string> sendEnterpriceCodeList;
            List<string> sendSectionCodeList;
            // 2011.09.06 zhouzy UPDATE STA >>>>>>
            List<SCMAcOdrDataWork> scmAcOdrDataList;

            //return SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList);
            return SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            // 2011.09.06 zhouzy UPDATE END <<<<<<

        }
        // 2011.07.13 ZHANGYH ADD END <<<<<<

        /// <summary>
        /// SCM受注データを更新します。
        /// </summary>
        /// <returns>結果コード</returns>
        protected abstract int UpdateAfterSend();

        #endregion // </送信>

        #region <自動削除>

        /// <summary>
        /// 保存期間切れXMLファイルの自動削除（終了時に実行）
        /// </summary>
        /// <returns>削除した数、マイナスはエラー</returns>
        public void AutoDelete()
        {
            DateTime limitdate = System.DateTime.Now;
            switch (_settingInfo.SavePeriodType)
            {
                case 1:
                    {
                        limitdate = limitdate.AddMonths(-1);
                        break;
                    }
                case 2:
                    {
                        limitdate = limitdate.AddMonths(-3);
                        break;
                    }
            }

            // 削除実行
            this.DeleteExpiredData(limitdate);
        }


        /// <summary>
        /// 保存期間を過ぎたデータの削除処理(PM7のみ)
        /// </summary>
        /// <returns></returns>
        protected virtual int DeleteExpiredData(DateTime limitdate)
        {
            return 0;
        }

        #endregion // </自動削除>

        //>>>2010/04/08
        //// 2010/03/15 Add >>>
        //private int _acptAnOdrStatus;
        //private string _salesSlipNum;

        //public int AcptAnOdrStatus
        //{
        //    get { return _acptAnOdrStatus; }
        //    set { _acptAnOdrStatus = value; }
        //}

        //public string SalesSlipNum
        //{
        //    get { return _salesSlipNum; }
        //    set { _salesSlipNum = value; }
        //}
        //// 2010/03/15 Add <<<

        private Int64 _inquiryNumber;
        private int _inqOrdDivCd;
        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
        private List<string> _salesSlipNumList = null;
        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<

        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        public int InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }
        //<<<2010/04/08

        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
        /// <summary>
        /// SalesSlipNumList
        /// </summary>
        public List<string> SalesSlipNumList
        {
            set { this._salesSlipNumList = value; }
            get { return this._salesSlipNumList; }
        }
        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<


        #region <削除ボタン>

        /// <summary>
        /// データの単独削除:画面で削除ボタンを押した場合
        /// </summary>
        /// <param name="drv">DataRowView（グリッドの選択行）</param>
        /// <returns>失敗した場合false</returns>
        public bool Delete(DataRowView drv)
        {
            bool stat = false;

            ExecuteDelete(drv);

            return stat;

        }

        /// <summary>
        /// 削除処理を行う(単体起動のみ)
        /// </summary>
        /// <returns>結果コード</returns>
        protected virtual int ExecuteDelete(DataRowView drv)
        {
            return 0;
        }

        #endregion // </削除ボタン>

        /// <summary>
        /// 対象伝票数の取得
        /// </summary>
        public void GetSlipCnt()
        {
            List<ScmOdDtAns> scmOdDtAnsList = SCMIO.CreateWebAnswerRecordList();

            int allCount = scmOdDtAnsList.Count;

            List<ScmOdDtAns> notSendList = scmOdDtAnsList.FindAll(
                delegate(ScmOdDtAns scmOdDtAns)
                {
                    if (scmOdDtAns.UpdateDate == DateTime.MinValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            int notSendCount = notSendList.Count;

            // 未送信
            _stat0Cnt = notSendCount;

            // 送信済
            _stat1Cnt = allCount - notSendCount;
        }

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="path">データパス（<c>string.Empty</c>でコンフィグファイルのデータパスを使用します）</param>
        /// <exception cref="DirectoryNotFoundException"><c>path</c>が存在しません。</exception>
        protected SCMSendController(string path)
        {
            _settingInfo.Load();
            {
                if (!string.IsNullOrEmpty(path.Trim()))
                {
                    SCMConfig.MakeFolderIf(path);
                    _settingInfo.SCMDataPath = path;
                }
            }
            //_logFilePath = Path.Combine(_settingInfo.SCMDataPath, LOG_FILE_NAME);  //DEL 2011/06/01

            //--- ADD 2011/06/01 ------------------------------------------->>>
            string file = String.Format(this.LogFileNameFormat, DateTime.Now);
            _logFilePath = Path.Combine(this.SettingInfo.SCMDataPath, file);
            //--- ADD 2011/06/01 -------------------------------------------<<<
        }

        #endregion // </Constructor>

        /// <summary>
        /// SCM受発注データと同キーの明細(回答)リスト、車両情報を取得する。
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <param name="scmOdDtAnsList"></param>
        /// <param name="scmOdDtCarList"></param>
        /// <param name="relatedSCMOdDtAnsList"></param>
        /// <param name="relatedSCMOdDtCar"></param>
        protected void GetRelatedSCMOdrData(
            SCMAcOdrDataWork scmOdrData, List<SCMAcOdrDtlAsWork> scmOdDtAnsList, List<SCMAcOdrDtCarWork> scmOdDtCarList,
            out List<SCMAcOdrDtlAsWork> relatedSCMOdDtAnsList, out SCMAcOdrDtCarWork relatedSCMOdDtCar)
        {
            relatedSCMOdDtAnsList = new List<SCMAcOdrDtlAsWork>();
            relatedSCMOdDtCar = new SCMAcOdrDtCarWork();

            // キー項目の取得
            string inqOriginalEpCd = scmOdrData.InqOriginalEpCd.Trim();    // 問合せ元企業コード//@@@@20230303
            string inqOriginalSecCd = scmOdrData.InqOriginalSecCd;  // 問合せ元拠点コード
            string inqOtherEpCd = scmOdrData.InqOtherEpCd;          // 問合せ先企業コード
            string inqOtherSecCd = scmOdrData.InqOtherSecCd;        // 問合せ先拠点コード
            Int64 inquiryNumber = scmOdrData.InquiryNumber;         // 問合せ番号
            int acptAnOdrStatus = scmOdrData.AcptAnOdrStatus;       // 受注ステータス
            string salesSlipNum = scmOdrData.SalesSlipNum;          // 売上伝票番号
            Int32 inqOrdDivCd = scmOdrData.InqOrdDivCd;             // 見積受注種別

            // 明細(回答)データ取得
            relatedSCMOdDtAnsList = scmOdDtAnsList.FindAll(
                delegate(SCMAcOdrDtlAsWork scmOdDtAns)
                {
                    if (scmOdDtAns.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtAns.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtAns.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmOdDtAns.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmOdDtAns.InquiryNumber == inquiryNumber
                        && scmOdDtAns.AcptAnOdrStatus == acptAnOdrStatus
                        && scmOdDtAns.SalesSlipNum == salesSlipNum
                        && scmOdDtAns.InqOrdDivCd == inqOrdDivCd
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

            // 車両情報取得
            relatedSCMOdDtCar = scmOdDtCarList.Find(
                delegate(SCMAcOdrDtCarWork scmOdDtCar)
                {
                    if (scmOdDtCar.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtCar.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtCar.InquiryNumber == inquiryNumber
                        && scmOdDtCar.AcptAnOdrStatus == acptAnOdrStatus
                        && scmOdDtCar.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// SCM受発注データと同キーの明細(回答)リスト、車両情報を取得する。
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <param name="scmOdDtAnsList"></param>
        /// <param name="scmOdDtCarList"></param>
        /// <param name="scmAcOdrSetDtList"></param>
        /// <param name="relatedSCMOdDtAnsList"></param>
        /// <param name="relatedSCMOdDtCar"></param>
        /// <param name="relatedScmAcOdrSetDtList"></param>
        protected void GetRelatedSCMOdrData(
                                            SCMAcOdrDataWork scmOdrData, 
                                            List<SCMAcOdrDtlAsWork> scmOdDtAnsList, 
                                            List<SCMAcOdrDtCarWork> scmOdDtCarList,
                                            List<SCMAcOdSetDtWork> scmAcOdrSetDtList,
                                            out List<SCMAcOdrDtlAsWork> relatedSCMOdDtAnsList, 
                                            out SCMAcOdrDtCarWork relatedSCMOdDtCar,
                                            out List<SCMAcOdSetDtWork> relatedScmAcOdrSetDtList)
        
        {
            relatedSCMOdDtAnsList = new List<SCMAcOdrDtlAsWork>();
            relatedSCMOdDtCar = new SCMAcOdrDtCarWork();

            // キー項目の取得
            string inqOriginalEpCd = scmOdrData.InqOriginalEpCd.Trim();    // 問合せ元企業コード//@@@@20230303
            string inqOriginalSecCd = scmOdrData.InqOriginalSecCd;  // 問合せ元拠点コード
            string inqOtherEpCd = scmOdrData.InqOtherEpCd;          // 問合せ先企業コード
            string inqOtherSecCd = scmOdrData.InqOtherSecCd;        // 問合せ先拠点コード
            Int64 inquiryNumber = scmOdrData.InquiryNumber;         // 問合せ番号
            int acptAnOdrStatus = scmOdrData.AcptAnOdrStatus;       // 受注ステータス
            string salesSlipNum = scmOdrData.SalesSlipNum;          // 売上伝票番号
            Int32 inqOrdDivCd = scmOdrData.InqOrdDivCd;             // 見積受注種別

            // 明細(回答)データ取得
            relatedSCMOdDtAnsList = scmOdDtAnsList.FindAll(
                delegate(SCMAcOdrDtlAsWork scmOdDtAns)
                {
                    if (scmOdDtAns.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtAns.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtAns.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmOdDtAns.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmOdDtAns.InquiryNumber == inquiryNumber
                        && scmOdDtAns.AcptAnOdrStatus == acptAnOdrStatus
                        && scmOdDtAns.SalesSlipNum == salesSlipNum
                        && scmOdDtAns.InqOrdDivCd == inqOrdDivCd
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

            // 車両情報取得
            relatedSCMOdDtCar = scmOdDtCarList.Find(
                delegate(SCMAcOdrDtCarWork scmOdDtCar)
                {
                    if (scmOdDtCar.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtCar.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtCar.InquiryNumber == inquiryNumber
                        && scmOdDtCar.AcptAnOdrStatus == acptAnOdrStatus
                        && scmOdDtCar.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // -- ADD 2011/08/10   ------ >>>>>>
            relatedScmAcOdrSetDtList = scmAcOdrSetDtList.FindAll(
                delegate(SCMAcOdSetDtWork scmAcOdSetDt)
                {
                    if (scmAcOdSetDt.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmAcOdSetDt.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmAcOdSetDt.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmAcOdSetDt.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmAcOdSetDt.InquiryNumber == inquiryNumber
                        && scmAcOdSetDt.PMAcptAnOdrStatus == acptAnOdrStatus
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
            // -- ADD 2011/08/10   ------ <<<<<<
        }
    }
}
