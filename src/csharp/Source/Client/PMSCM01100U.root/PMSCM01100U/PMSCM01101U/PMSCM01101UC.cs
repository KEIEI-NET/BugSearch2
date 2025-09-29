//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理の画面
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/10/10  修正内容 : 新規作成：ＴＳＰ送受信処理【ＰＭ側】(SFMIT02850U)
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : SCM用にアレンジ
// 管理番号              作成担当 : ZHANGYH
// 作 成 日  2011/07/12  修正内容 : 1分問題対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/06  修正内容 : Websync PCCUOEのチャンネルを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/06/30  ②修正内容 : SCM仕掛一覧№10707 ログ出力の追加
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData; // 2011.09.06 zhouzy ADD

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信画面フォーム
    /// </summary>
	public partial class PMSCM01101UC : Form
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

        #region <回答送信処理>

        /// <summary>回答送信処理</summary>
        private readonly SCMSendController _scmController;
        /// <summary>回答送信処理を取得します。</summary>
        private SCMSendController SCMController { get { return _scmController; } }

        #endregion // </回答送信処理>

        #region <Constructor>
        /// <summary>デフォルトx座標</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>デフォルトy座標</summary>
        private const int DEFAULT_Y = 100000;

        /// <summary>
		/// カスタムコンストラクタ
		/// </summary>
        /// <param name="scmController">回答送信処理</param>
        /// <param name="position">位置</param>
        public PMSCM01101UC(
            SCMSendController scmController,
            FormStartPosition position
        )
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // <Designer Code>

            _scmController = scmController;
            //this.StartPosition = position;
            this.Hide();
        }

        #endregion // </Constructor>

        #region <初期化>

        /// <summary>
        /// 送信画面フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
		private void PMSCM01101UC_Load(object sender, EventArgs e)
		{
            SimpleLogger.WriteDebugLog("PMSCM01101UC", "PMSCM01101UC_Load", "フォームLoadイベント"); // ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707
            // 初期位置を設定（ちらつき防止の為、10000にしています）
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);
            this.SetVisibleState(false);
            this.sendTimer.Enabled = true;
        }

        #endregion // </初期化>

        /// <summary>
        /// 送信タイマーのTickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 2010/02/13 >>>
                this.SetVisibleState(false);
                this.Refresh();
                // 2010/02/13 <<<
                this.sendTimer.Enabled = false;
                //this.Refresh();

                // 送信
                CanClose = false;
                // 2011.07.12 ZHANGYH ADD STA >>>>>>
                List<string> sendEnterpriseCodeList;
                List<string> sendSectionCodeList;
                // 2011.09.06 zhouzy UPDATE STA >>>>>>
                List<SCMAcOdrDataWork> scmAcOdrDataList;
                // 2011.09.06 zhouzy UPDATE END <<<<<<
                // 2011.07.12 ZHANGYH ADD END <<<<<<

                // 2011.07.12 ZHANGYH EDT STA >>>>>>
                //int status = SCMController.Send();
                // 2011.09.06 zhouzy UPDATE STA >>>>>>
                //int status = SCMController.Send(out sendEnterpriseCodeList, out sendSectionCodeList);
                int status = SCMController.Send(out sendEnterpriseCodeList, out sendSectionCodeList, out scmAcOdrDataList);
                // 2011.09.06 zhouzy UPDATE END <<<<<<
                // 2011.07.12 ZHANGYH EDT END <<<<<<
                if (status.Equals((int)ResultUtil.ResultCode.Error))
                {
                    SetErrorStatus();
                    return;
                }

                // 2011.07.12 ZHANGYH ADD STA >>>>>>
                // 回答成功すると、SF.NS端末を通知します。
                // 2011.09.06 zhouzy UPDATE STA >>>>>>
                //if (sendEnterpriseCodeList != null && sendSectionCodeList != null && sendEnterpriseCodeList.Count > 0 && sendSectionCodeList.Count > 0)
                //{
                //    SCMChecker.NotifyOtherSide(sendEnterpriseCodeList, sendSectionCodeList);
                //}
                if (sendEnterpriseCodeList != null && sendSectionCodeList != null && sendEnterpriseCodeList.Count > 0 && sendSectionCodeList.Count > 0
                    && scmAcOdrDataList != null && scmAcOdrDataList.Count > 0)
                {
                    SCMAcOdrDataWork sCMAcOdrDataWork = scmAcOdrDataList[0];
                    SCMChecker.NotifyOtherSide(sendEnterpriseCodeList, sendSectionCodeList, sCMAcOdrDataWork.AcceptOrOrderKind);
                }
                // 2011.09.06 zhouzy UPDATE END <<<<<<
                // 2011.07.12 ZHANGYH ADD END <<<<<<

                CanClose = true;
                SCMController.SettingInfo.LastDate = DateTime.Now;
                //this.Refresh();
            }
            finally
            {
                SendRecevingClose();
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// エラー状態を設定します。
        /// </summary>
        private void SetErrorStatus()
        {
            this.pictureWait.Visible = false;
            this.lblStatus.Text = "送信中にエラーが発生しました。";
            this.lblPlease.Text = "詳細はエラーログを参照してください。";
            this.btnCancel.Visible = true;
        }

        // 2010/02/13 Add >>>
        /// <summary>
        /// 初期起動位置を設定します。
        /// </summary>
        private void SetInitialPosition()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
        }

        /// <summary>
        /// 表示状態を設定します。
        /// </summary>
        /// <param name="visible">表示フラグ</param>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                SetInitialPosition();
                Visible = true;
                TopMost = true;
                Activate();
                TopMost = false;
            }
            else
            {
                this.ShowIcon = false;
                Visible = false;
            }
        }
        // 2010/02/13 Add <<<


        /// <summary>
        /// 送信中アイコンのMouseDoubleClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void nowSendingNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            #region <Guard Phrase>

            if (!e.Button.Equals(MouseButtons.Left)) return;

            #endregion // </Guard Phrase>

            this.Visible = true;
        }

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

                SendMessage(process.MainWindowHandle, WM_COPYDATA, this.Handle, ref st);
            }
        }

        #region <終了処理>

        #region <クローズ可能フラグ>

        /// <summary>クローズ可能フラグ</summary>
        private bool _canClose;
        /// <summary>クローズ可能フラグを取得または設定します。</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion // </クローズ可能フラグ>

        /// <summary>
        /// [閉じる]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
            CanClose = true;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 送信画面フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMSCM01101UC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // 意図的な終了以外はキャンセルしてアイコン化（フォームを非表示にする）
                    e.Cancel = true; // 終了処理のキャンセル
                    this.Visible = false;
                    return;
                }
            }
        }

        #endregion // </終了処理>
    }
}