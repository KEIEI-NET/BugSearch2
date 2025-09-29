//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐
// プログラム概要   : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370037-00 作成担当 : 太田
// 作 成 日  2017/10/24  修正内容 : ハンディターミナル二次開発の対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 作 成 日  2019/11/13  修正内容 : ハンディ６次改良
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Microsoft.Win32;
using System.IO;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting;

using System.Security.Principal;
using System.Collections;
using System.ServiceProcess;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐
    /// </summary>
    /// <remarks>
    /// <br>Note       : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐画面</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/06</br>
    /// </remarks>
    public partial class PMHND00001UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region　コンスト Memebers
        /// <summary>プログラムID</summary>
        private const string AssemblyId = "PMHND00001U";
        /// <summary>プログラム名称</summary>
        private const string AssemblyName = "ハンディ常駐";
        /// <summary>XMLファイル</summary>
        private const string XmlFileName = "PMHND00001U_UserSetting.xml";
        /// <summary>終了メッセージ</summary>
        private const string MessageCloseQst = "終了処理を実行してもよろしいですか？";
        /// <summary>サービス起動失敗メッセージ</summary>
        private const string MessageStartupError = "ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐の起動が失敗しました。";
        /// <summary>HT/APサーバー（サービス）不存在のメッセージ</summary>
        private const string MessageHtApEmptyError = "HT/APサービスが存在しません。";
        /// <summary>空文字列</summary>
        private const string StringEmpty = "";
        /// <summary>IPCチャネル名</summary>
        private const string IpcChannelName = "PmHandyChannel";
        /// <summary>IPCチャネルサービス名</summary>
        private const string IpcChannelServerName = "PmHandyService";
        /// <summary>IPCチャネル</summary>
        private const string IpcChannel = "ipc://PmHandyChannel/PmHandyService";
        /// <summary>HT/APサーバー（サービス）</summary>
        private const string HtApService = "Partsman.NS HT_RELAY_SERVICE";
        /// <summary>デフォルト読込最大件数</summary>
        private const int XmlReadMaxCount = 2;
        /// <summary>デフォルト書込最大件数</summary>
        private const int XmlWriteMaxCount = 1;
        /// <summary>デフォルトスレッド待ち時間</summary>
        private const int XmlThreadWaitTime = 30;
        /// <summary>オペレーションコード（起動）</summary>
        private const int OperationCodeStartup = 0;
        /// <summary>オペレーションコード（終了）</summary>
        private const int OperationClose = 14;
        /// <summary>エラーメッセージ（起動）</summary>
        private const string MessageStartup = "正常起動しました。";
        /// <summary>エラーメッセージ（終了）</summary>
        private const string MessageClose = "正常終了しました。";
        /// <summary>他のエラーメッセージ</summary>
        private const string MessageError = "エラーが発生しました。";
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;

        /// <summary>ポート名称</summary>
        private const string PortName = "portName";
        /// <summary>権限グループ</summary>
        private const string AuthorizedGroup = "authorizedGroup";
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        /// <summary>ユーザー設定情報</summary>
        private UserSettingInfo UserSetInfo;
        /// <summary>ﾊﾝﾃﾞｨﾀｰﾐﾅﾙサービス</summary>
        private IPmHandy IPmHandy = null;
        /// <summary>終了ダイアログ閉じるフラグ</summary>
        private bool CloseDialogFlg = true;
        /// <summary>操作履歴ログ</summary>
        private OperationHistoryLog OperationHistoryLog = null;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// <br>Programmer : 太田</br>
        /// <br>Date       : 2017/10/24</br>
        /// </remarks>
        public PMHND00001UA()
        {
            // 初期化処理
            InitializeComponent();
            // ユーザー設定情報
            UserSetInfo = new UserSettingInfo();
            // 操作履歴ログ
            OperationHistoryLog = new OperationHistoryLog();
        }
        #endregion

        // ===================================================================================== //
        // 画面操作処理ラクタ
        // ===================================================================================== //
        #region Control Event Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMHND00001UA_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = true;
            this.Visible = false;

            try
            {
                // 重複起動チェック
                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    this.Close();
                    return;
                }

                // ﾊﾝﾃﾞｨﾀｰﾐﾅﾙのIPCチャネルを登録します。
                this.StartPmHandy();

                // XML情報を取得します。
                this.GetXmlInfo();

                // 読込最大件数
                int resultReadMaxCount;
                // 書込最大件数
                int resultWriteMaxCount;
                // スレッド待ち時間
                int resultThreadWaitTime;

                if (!int.TryParse(this.UserSetInfo.ReadMaxCount, out resultReadMaxCount))
                {
                    // 変換できなかった場合は読込最大件数2件を固定とする
                    resultReadMaxCount = XmlReadMaxCount;
                }

                if (!int.TryParse(this.UserSetInfo.WriteMaxCount, out resultWriteMaxCount))
                {
                    // 変換できなかった場合は書込最大件数1件を固定とする
                    resultWriteMaxCount = XmlWriteMaxCount;
                }

                if (!int.TryParse(this.UserSetInfo.ThreadWaitTime, out resultThreadWaitTime))
                {
                    // 変換できなかった場合はスレッド待ち時間30秒を固定とする
                    resultThreadWaitTime = XmlThreadWaitTime;
                }

                // IPCチャネルチェック
                this.IPmHandy = (IPmHandy)Activator.GetObject(typeof(IPmHandy), IpcChannel);
                if (this.IPmHandy == null)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, MessageStartupError, StatusError);
                    #region 操作履歴ログデータの登録
                    this.OperationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, AssemblyId, AssemblyName, StringEmpty, OperationCodeStartup, StatusError, MessageError, StringEmpty);
                    #endregion
                    this.Close();
                    return;
                }

                // HT/APサーバー（サービス）存在チェック処理
                if (IsExistService(HtApService))
                {

                    // HT/APサーバー（サービス）を起動します。
                    ServiceController ServiceCtrl = new ServiceController(HtApService);

                    // ------ ADD 2017/10/24 --------- >>>>
                    TimeSpan SERVICE_TIMEOUT_SEC = new TimeSpan(0, 3, 0);

                    // HT/APサーバー（サービス）の状態が停止及び停止中以外の場合、サービスの停止処理を行う
                    if (ServiceCtrl.Status != ServiceControllerStatus.Stopped && ServiceCtrl.Status != ServiceControllerStatus.StopPending)
                    {
                        ServiceCtrl.Stop();
                    }
                    // HT/APサーバー（サービス）の状態が停止以外の場合、サービス状態変更待機を行う
                    if (ServiceCtrl.Status != ServiceControllerStatus.Stopped)
                    {
                        //タイムアウトの場合は例外でエラーとする
                        ServiceCtrl.WaitForStatus(ServiceControllerStatus.Stopped, SERVICE_TIMEOUT_SEC);
                    }

                    // HT/APサーバー（サービス）の状態が実行中及び開始中以外の場合、サービスの開始処理を行う
                    if (ServiceCtrl.Status != ServiceControllerStatus.Running && ServiceCtrl.Status != ServiceControllerStatus.StartPending)
                    {
                        ServiceCtrl.Start();
                    }
                    // 対象サービスの状態が実行中以外の場合、サービス状態変更待機を行う
                    if (ServiceCtrl.Status != ServiceControllerStatus.Running)
                    {
                        //タイムアウトの場合は例外でエラーとする
                        ServiceCtrl.WaitForStatus(ServiceControllerStatus.Running, SERVICE_TIMEOUT_SEC);
                    }
                    ServiceCtrl.Refresh();
                    // ------ ADD 2017/10/24 --------- <<<<

                    // ------ DEL 2017/10/24 --------- >>>>
                    // HT/APサーバー（サービス）未起動する時、起動します。
                    //if ((ServiceCtrl.Status.Equals(ServiceControllerStatus.Stopped)) || (ServiceCtrl.Status.Equals(ServiceControllerStatus.StopPending)))
                    //{
                    //    ServiceCtrl.Start();
                    //    ServiceCtrl.Refresh();
                    //}
                    // ------ DEL 2017/10/24 --------- <<<<
                }
                else
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, MessageHtApEmptyError, StatusError);
                    #region 操作履歴ログデータの登録
                    this.OperationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, AssemblyId, AssemblyName, StringEmpty, OperationCodeStartup, StatusError, MessageError, StringEmpty);
                    #endregion
                    this.Close();
                    return;
                }
                

                // 読込最大件数を設定します。
                this.IPmHandy.SetReadMaxCount(resultReadMaxCount);
                // 書込最大件数を設定します。
                this.IPmHandy.SetWriteMaxCount(resultWriteMaxCount);
                // スレッド待ち時間を設定します。
                this.IPmHandy.SetThreadWaitTime(resultThreadWaitTime);

                #region 操作履歴ログデータの登録
                this.OperationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, AssemblyId, AssemblyName, StringEmpty, OperationCodeStartup, StatusNomal, MessageStartup, StringEmpty);
                #endregion
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, MessageStartupError, StatusError);
                #region 操作履歴ログデータの登録
                this.OperationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, AssemblyId, AssemblyName, StringEmpty, OperationCodeStartup, StatusError, MessageError, StringEmpty);
                #endregion
                this.Close();
            }
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show();
            }
        }

        /// <summary>
        /// 終了クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.CloseDialogFlg)
            {
                this.CloseDialogFlg = false;

                // 確認メッセージを表示する。
                DialogResult result = TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_QUESTION,                // エラーレベル
                            AssemblyId,						                // アセンブリＩＤまたはクラスＩＤ
                            AssemblyName,				                        // プログラム名称
                            StringEmpty, 								            // 処理名称
                            StringEmpty,									            // オペレーション
                            MessageCloseQst,						    // 表示するメッセージ
                            StatusError, 							                // ステータス値
                            null, 								            // エラーが発生したオブジェクト
                            MessageBoxButtons.YesNo, 				        // 表示するボタン
                            MessageBoxDefaultButton.Button1);	            // 初期表示ボタン

                // 入力画面へ戻る。
                if (result == DialogResult.Yes)
                {
                    // 終了タイムを起動します。
                    this.timer1.Enabled = true;
                }

                this.CloseDialogFlg = true;
            }
        }

        /// <summary>
        /// IPCチャネル取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private void StartPmHandy()
        {
            SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
            NTAccount account = sid.Translate(typeof(NTAccount)) as NTAccount;

            IDictionary channelProperties = new Hashtable();
            channelProperties[PortName] = IpcChannelName;
            channelProperties[AuthorizedGroup] = account.Value;

            IpcChannel ipcChannel = new IpcChannel(channelProperties, null, null);
            ChannelServices.RegisterChannel(ipcChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(PmHandy), IpcChannelServerName, WellKnownObjectMode.Singleton);
        }

        /// <summary>
        /// HT/APサーバー（サービス）チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : HT/APサーバー（サービス）のチェック処理です。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private bool IsExistService(string serviceName)
        {
            bool result = false;
            try
            {
                ServiceController[] controllers = ServiceController.GetServices();

                for (int i = 0; i < controllers.Length; i++)
                {
                    if ((controllers[i].ServiceName.ToUpper() == serviceName.ToUpper()))
                    {
                        result = true;
                        break;
                    }
                }
            }
            catch
            {
                result = false;
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, MessageStartupError, StatusError);
                #region 操作履歴ログデータの登録
                this.OperationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, AssemblyId, AssemblyName, StringEmpty, OperationCodeStartup, StatusError, MessageError, StringEmpty);
                #endregion
            }

            return result;
        }

        #region エラーメッセージ
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date	   : 2017/06/06</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                AssemblyId,						// アセンブリＩＤまたはクラスＩＤ
                StringEmpty,						// プログラム名称
                StringEmpty,						// 処理名称
                StringEmpty,						// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region タイム処理
        /// <summary>
        /// タイム処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : タイム処理</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 読込最大件数を取得します。
            int readingCount = this.IPmHandy.GetReadingCount();

            // 書込最大件数を取得します。
            int writingCount = this.IPmHandy.GetWritingCount();

            if (readingCount == 0 && writingCount == 0)
            {
                this.timer1.Enabled = false;
                #region 操作履歴ログデータの登録
                this.OperationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, AssemblyId, AssemblyName, StringEmpty, OperationClose, StatusNomal, MessageClose, StringEmpty);
                #endregion
                Close();
            }

        }
        #endregion

        #endregion

        // ===================================================================================== //
        // XML情報取得用ユーザー設定情報
        // ===================================================================================== //
        #region XML情報取得用ユーザー設定情報処理

        /// <summary>
        /// XML情報取得用ユーザー設定情報の取得
        /// </summary>
        /// <remarks>
        /// <br>Note        : XML情報取得用ユーザー設定情報を取得します。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/06/06</br>
        /// </remarks>
        private void GetXmlInfo()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName)))
            {
                try
                {
                    this.UserSetInfo = UserSettingController.DeserializeUserSetting<UserSettingInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName));
                }
                catch
                {
                    this.UserSetInfo = new UserSettingInfo();
                }
            }
        }

        /// <summary>
        /// XML情報取得用ユーザー設定情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : XML情報取得用ユーザー設定情報クラスです。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2017/06/06</br>
        /// </remarks>
        public class UserSettingInfo
        {
            /// <summary> 読込最大件数 </summary>
            private string _readMaxCount;

            /// <summary> 書込最大件数 </summary>
            private string _writeMaxCount;

            /// <summary> スレッド待ち時間 </summary>
            private string _threadWaitTime;

            /// <summary>
            /// 読込最大件数
            /// </summary>
            public string ReadMaxCount
            {
                get { return _readMaxCount; }
                set { _readMaxCount = value; }
            }

            /// <summary>
            /// 書込最大件数
            /// </summary>
            public string WriteMaxCount
            {
                get { return _writeMaxCount; }
                set { _writeMaxCount = value; }
            }

            /// <summary>
            /// スレッド待ち時間
            /// </summary>
            public string ThreadWaitTime
            {
                get { return _threadWaitTime; }
                set { _threadWaitTime = value; }
            }
        }

        #endregion
    }
}