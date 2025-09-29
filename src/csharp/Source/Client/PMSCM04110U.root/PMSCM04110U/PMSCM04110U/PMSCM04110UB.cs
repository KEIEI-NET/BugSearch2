//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 同期状態表示プログラム
// プログラム概要   : 同期状態表示プログラム処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070136-00 作成担当 : chenyk
// 作 成 日  2014/08/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/09/03   修正内容 : Redmine#43408
//                                   ステータスが2、またMaxErrorCountまで到達していないものも取得する対応
//----------------------------------------------------------------------------//
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/09/12   修正内容 : Redmine#43532
//                                   クライアントログの出力、アイコンの指摘を対応する
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using System.IO;
using System.Xml;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// エラー表示フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : エラー表示のフォームクラスです。</br>
    /// <br>Programmer : chenyk</br>
    /// <br>Date       : 2014/08/14</br>
    /// <br>Update Note: 2014/09/03 田建委</br>
    /// <br>管理番号   : 11070136-00 Redmine#43408</br>
    /// <br>           : ステータスが2、またMaxErrorCountまで到達していないものも取得する対応</br>
    /// <br>Update Note: 2014/09/12 田建委</br>
    /// <br>管理番号   : 11070136-00 Redmine#43532</br>
    /// <br>           : クライアントログの出力、アイコンの指摘を対応する</br>
    /// </remarks>
    public partial class PMSCM04110UB : Form
    {
        #region Private Members
        private const int DEFAULT_X = 100000;//デフォルトx座標
        private const int DEFAULT_Y = 100000;//デフォルトy座標
        private int _requireTime; //要求経過時間
        private int _showTime; //ポップアップの表示時間
        private int _monitorTime; //監視間隔時間
        private int _retryCount; //再試行回数
        private const double CT_FORM_OPACITY = 1; //画面透過率
        private const string XMLFILE = "PMSCM04110U_RunFile.XML";
        private const string E0001 = "E0001";
        private const string E0002 = "E0002";
        private const string E0003 = "E0003";
        private const string E0004 = "E0004";
        private PMSCM04110UA _form;
        bool _res = false;

        private SynchConfirmAcs _synchConfirmAcs; // 同期状況確認アクセスクラス
        private string _errorMessageId; //エラーメッセージ
        private bool _isErrorRead;
        private PosTerminalMgAcs _posTerminalMgAcs; // 端末管理設定アクセスクラス
        private SyncStateDspTermStAcs _syncStateDspTermStAcs; // 同期状態表示端末設定アクセスクラス
        #endregion

        #region コマンドライン引数
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        //private string _sectionCode; //DEL 2014/09/01 田建委 Redmine#43391
        #endregion

        #region フォームを閉じる判定
        /// <summary>フォームを閉じる判定フラグ</summary>
        private bool _canClose;
        /// <summary>フォームを閉じる判定フラグのアクセサ</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }
        #endregion

        # region Constructors
        public PMSCM04110UB()
        {
            InitializeComponent();
            _errorMessageId = "";
            _isErrorRead = false;
            _posTerminalMgAcs = new PosTerminalMgAcs();
            _synchConfirmAcs = new SynchConfirmAcs();
            _syncStateDspTermStAcs = new SyncStateDspTermStAcs();
            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; // 企業コード
            }
            //this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode; // 拠点コード //DEL 2014/09/01 田建委 Redmine#43391
        }
        #endregion

        #region イベント
        /// <summary>
        /// 画面Load
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面Load</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// <br>Update Note: 2014/09/12 田建委</br>
        /// <br>管理番号   : 11070136-00 Redmine#43532</br>
        /// <br>           : クライアントログの出力、アイコンの指摘を対応する</br>
        /// </remarks>
        private void PMSCM04110UB_Load(object sender, EventArgs e)
        {
            //ポップアップの多重起動防止
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                CanClose = true;
                this.Close();
                return;
            }

            //----- ADD 2014/09/12 田建委 Redmine#43532 ----->>>>>
            try
            {
                //----- ADD 2014/09/12 田建委 Redmine#43532 -----<<<<<
                //端末チェック
                ArrayList localList = new ArrayList();
                ArrayList serverList = new ArrayList();
                ArrayList localMachineList = new ArrayList();
                ArrayList serverMachineList = new ArrayList();
                ArrayList syncStateDspTermList = new ArrayList();
                int status1 = this._posTerminalMgAcs.SearchLocal(out localList, this._enterpriseCode);
                int status2 = this._posTerminalMgAcs.SearchServer(out serverList, this._enterpriseCode);
                int status3 = this._syncStateDspTermStAcs.SearchAll(out syncStateDspTermList, this._enterpriseCode);

                if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL || status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL || status3 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CanClose = true;
                    this.Close();
                    return;
                }
                else
                {
                    #region サーバーに登録済みのローカルの端末IDを取得
                    foreach (PosTerminalMg work in localList)
                    {
                        if (work.LogicalDeleteCode == 0)
                        {
                            string machineName = work.MachineName;
                            localMachineList.Add(machineName);
                        }
                    }
                    foreach (PosTerminalMg work in serverList)
                    {
                        if (work.LogicalDeleteCode == 0)
                        {
                            for (int i = 0; i < localMachineList.Count; i++)
                            {
                                if (work.MachineName.Equals(localMachineList[i]))
                                {
                                    serverMachineList.Add(work.CashRegisterNo);
                                }
                            }
                        }
                    }
                    #endregion
                }
                bool flag = false;
                string belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                foreach (SyncStateDspTermStWork work in syncStateDspTermList)
                {
                    if (work.LogicalDeleteCode == 0)
                    {
                        for (int i = 0; i < serverMachineList.Count; i++)
                        {
                            #region 拠点制御チェック
                            if (!string.IsNullOrEmpty(work.SectionCode) && (work.SectionCode.Trim() == "00" || work.SectionCode.Trim() == belongSectionCode))
                            {
                                #region 起動端末チェック
                                if (work.CashRegisterNo.ToString().Equals(serverMachineList[i].ToString()))
                                {
                                    flag = true;
                                    break;
                                }
                                #endregion
                            }
                            #endregion
                        }
                    }
                }
                if (!flag)
                {
                    CanClose = true;
                    this.Close();
                    return;
                }


                //起動ファイルを読む
                int status4 = GetXML();
                if (status4 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CanClose = true;
                    this.Close();
                    return;
                }
                this.notifyIcon.Visible = true;

                // 初期表示は隠し
                SetVisibleState(false);

                // 初期位置を設定（ちらつき防止の為、10000にしています）
                SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

                if (_showTime > 0)
                {
                    this.show_timer.Interval = _showTime;
                }

                //初期チェック
                SerachErr();

                if (!string.IsNullOrEmpty(this._errorMessageId) && !_isErrorRead)
                {
                    if (_showTime > 0)
                    {
                        this.show_timer.Enabled = true;
                    }
                    MessageSetting();
                }
                //自動チェックを設定
                if (_monitorTime > 0)
                {
                    check_timer.Enabled = true;
                    check_timer.Interval = _monitorTime;
                }
            }
            catch (Exception ex)
            {
                PMSCM04110UA.WriteErrorLog(ex, "PMSCM04110UB.PMSCM04110UB_Load", -1);

                CanClose = true;
                this.Close();
                return;
            }
        }

        /// <summary>
        /// 定期チェック実行タイマー処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 定期チェック実行タイマー処理</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void Check_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                check_timer.Enabled = false;
                SerachErr();
                if (!string.IsNullOrEmpty(this._errorMessageId) && !this._isErrorRead)
                {
                    if (_showTime > 0)
                    {
                        this.show_timer.Enabled = true;
                    }
                    MessageSetting();
                }
            }
            catch
            {
            }
            finally
            {
                check_timer.Enabled = true;
            }
        }

        /// <summary>
        /// 画面計時処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 画面計時処理</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void show_timer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this._errorMessageId) && _showTime > 0)
            {
                this.show_timer.Enabled = false;
            }
            this.PMSCM04110UB_MouseLeave(sender, e);
        }

        /// <summary>
        /// フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームのFormClosingイベントハンドラ</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void PMSCM04110UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // 意図的な終了以外はキャンセルしてアイコン化（フォームを非表示にする）
                    e.Cancel = true; // 終了処理のキャンセル
                    Visible = false;
                    return;
                }
            }
        }

        /// <summary>
        /// 画面を閉じます。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を閉じます。</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "同期状態表示プログラムを終了します。\r\n" +
                "終了してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.No) return;

            CanClose = true;
            Close();
        }

        /// <summary>
        /// フォームのMouseLeaveイベントハンドラ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームのMouseLeaveイベントハンドラ</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void PMSCM04110UB_MouseLeave(object sender, EventArgs e)
        {
            if (!CanClose)
            {
                this._isErrorRead = true;
                Visible = false;
                return;
            }

        }

        /// <summary>
        /// バタンーのcloseイベントハンドラ
        /// </summary>
        /// <remarks>
        /// <br>Note       : バタンーのcloseイベントハンドラ</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void close_button_Click(object sender, EventArgs e)
        {
            this.show_timer.Enabled = false; // ADD 2014/09/03 田建委
            if (!CanClose)
            {
                this._isErrorRead = true;
                Visible = false;
                return;
            }
        }

        /// <summary>
        /// バタンーのMouseMoveイベントハンドラ
        /// </summary>
        /// <remarks>
        /// <br>Note       : バタンーのcloseイベントハンドラ</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void close_button_MouseMove(object sender, MouseEventArgs e)
        {
            this.close_button.Appearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.close_button.Appearance.BackColor = System.Drawing.Color.LightGray;
        }

        /// <summary>
        /// バタンーのMouseLeaveイベントハンドラ
        /// </summary>
        /// <remarks>
        /// <br>Note       : バタンーのMouseLeaveイベントハンドラ</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void close_button_MouseLeave(object sender, EventArgs e)
        {
            this.close_button.Appearance.BorderColor = System.Drawing.Color.White;
            this.close_button.Appearance.BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>
        /// パトランプアイコンのMouseClickイベントハンドラ
        /// </summary>
        /// <remarks>画面を表示します。</remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : パトランプアイコンのMouseClickイベントハンドラ</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (!e.Button.Equals(MouseButtons.Left) || _res) return;
            Activate();

            if (_form == null)
            {
                _form = new PMSCM04110UA();
                _form.FormClosed += new FormClosedEventHandler(ChildForm_FormClosed);
                _form.RetetEvent += new EventHandler(ClearErrorMessage);
                _form.Show(this);
            }
            else
            {
                if (_form.WindowState == FormWindowState.Minimized)
                {
                    _form.WindowState = FormWindowState.Normal;
                }

                _res = true;
                string msg = "同期状況確認は既に起動しています。";
                DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text, msg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.OK)
                {
                    _res = false;
                }
            }

            /*----- DEL 2014/09/03 田建委 ---------->>>>>
            if (_form == null)
            {
                _form = new PMSCM04110UA();
                //_form.ShowDialog(this); // DEL 2014/09/03 田建委
                //----- ADD 2014/09/03 田建委 ---------->>>>>
                if (_form.ShowDialog(this) == DialogResult.Cancel)
                {
                    _form.Dispose();
                    _form = null;
                }
                //----- ADD 2014/09/03 田建委 ----------<<<<<
            }
            else
            {
                if (!_form.Visible)
                {
                    //_form.ShowDialog(this); // DEL 2014/09/03 田建委
                    //----- ADD 2014/09/03 田建委 ---------->>>>>
                    if (_form.ShowDialog(this) == DialogResult.Cancel)
                    {
                        _form.Dispose();
                        _form = null;
                    }
                    //----- ADD 2014/09/03 田建委 ----------<<<<<
                }
                else
                {
                    if (_form.WindowState == FormWindowState.Minimized)
                    {
                        _form.WindowState = FormWindowState.Normal;
                    }

                    _res = true;
                    string msg = "同期状況確認は既に起動しています。";
                    DialogResult res = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text, msg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    if (res == DialogResult.OK)
                    {
                        _res = false;
                    }
                }
            }
            ----- DEL 2014/09/03 田建委 ----------<<<<<*/
        }

        //----- ADD 2014/09/03 田建委 ---------->>>>>
        /// <summary>
        /// 子フォームのクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 子フォームをクローズした後の処理。</br>
        /// <br>Programer  : 田建委</br>
        /// <br>Date       : 2014/09/03</br>
        /// </remarks>
        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Dispose();
            _form = null;
        }
        #endregion
        //----- ADD 2014/09/03 田建委 ----------<<<<<

        #region private　メソッド
        /// <summary>
        /// 表示状態を設定します。
        /// </summary>
        /// <param name="visible">表示フラグ</param>
        /// <remarks>
        /// <br>Note       : 表示状態を設定します。</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                SetInitialPosition();
                SetWindowPos();
                Visible = true;
            }
            else
            {
                Visible = false;
            }
        }

        /// <summary>
        /// ShowWithoutActivation
        /// </summary>
        /// <remarks>
        /// <br>Note       : ShowWithoutActivation</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private void SetWindowPos()
        {
            const int HWND_TOPMOST = -1;
            const int SWP_NOSIZE = 0x0001;
            const int SWP_NOMOVE = 0x0002;
            const int SWP_NOACTIVATE = 0x0010;
            const int SWP_DRAWFRAME = 0x0020;
            const int SWP_SHOWWINDOW = 0x0040;
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_DRAWFRAME);
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_DRAWFRAME);
        }

        /// <summary>
        /// 初期起動位置を設定します。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期起動位置を設定します。</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
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
        /// エラーログ検索
        /// </summary>
        /// <remarks>
        /// <br>Note       : エラーログ検索</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// <br>Update Note: 2014/09/03 田建委</br>
        /// <br>管理番号   : 11070136-00 Redmine#43408</br>
        /// <br>           : ステータスが2、またMaxErrorCountまで到達していないものも取得する対応</br>
        /// <br>Update Note: 2014/09/12 田建委</br>
        /// <br>管理番号   : 11070136-00 Redmine#43532</br>
        /// <br>           : クライアントログの出力、アイコンの指摘を対応する</br>
        /// </remarks>
        private int SerachErr()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string errMessage = string.Empty;
            string err = string.Empty;
            ArrayList retList = new ArrayList();
            DateTime nowDateTime = DateTime.Now;
            DateTime dt = nowDateTime.AddSeconds((double)_requireTime * -1);
            string newErrorMessageId = string.Empty;
            try
            {
                //DO CHECK
                status = _synchConfirmAcs.SerachErr(this._enterpriseCode, _retryCount, dt, ref retList, out err);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList.Count > 0)
                {
                    SyncReqDataWork work = retList[0] as SyncReqDataWork;
                    if (work != null && work.SyncExecRslt == 2 && work.RetryCount >= _retryCount)
                    {
                        //E0001
                        if (work.ErrorStatus == 1010 || work.ErrorStatus == 1020 || work.ErrorStatus == 1030 || work.ErrorStatus == 1040)
                        {
                            newErrorMessageId = E0001;
                        }
                        //E0002
                        else if (work.ErrorStatus == 2000)
                        {
                            newErrorMessageId = E0002;
                        }
                        //E0004
                        else
                        {
                            newErrorMessageId = E0004;
                        }
                    }
                    else if (work != null)
                    {
                        //E0003
                        newErrorMessageId = E0003;
                    }

                    if (this._errorMessageId != newErrorMessageId)
                    {
                        this._errorMessageId = newErrorMessageId;
                        this._isErrorRead = false;
                    }
                }
                else
                {
                    this.ClearErrorMessage(this, null);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMessage = ex.Message;
                PMSCM04110UA.WriteErrorLog(ex, "PMSCM04110UB.SerachErr", status); // ADD 2014/09/12 田建委 Redmine#43532
            }
            finally
            {
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (string.IsNullOrEmpty(errMessage))
                    {
                        errMessage = err;
                    }

                    PMSCM04110UA.WriteErrorLog(null, errMessage, status); // ADD 2014/09/12 田建委 Redmine#43532
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text, errMessage, 0, MessageBoxButtons.OK);
                }
            }
            return status;
        }

        /// <summary>
        /// エラー情報のクリア
        /// </summary>
        public void ClearErrorMessage(object sender, System.EventArgs e)
        {
            this._errorMessageId = string.Empty;
            this._isErrorRead = false;
        }

        /// <summary>
        /// メッセージを設定します。
        /// </summary>
        /// <param name="count">計数フラグ</param>
        /// <remarks>
        /// <br>Note       : メッセージを設定します。</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// </remarks>
        private void MessageSetting()
        {
            if (this._errorMessageId.Equals(E0001))
            {
                E0001_Label.Visible = true;
                E0002_Label.Visible = false;
                E0003_Label.Visible = false;
                E0004_Label.Visible = false;
                SetVisibleState(true);
            }
            if (this._errorMessageId.Equals(E0002))
            {
                E0001_Label.Visible = false;
                E0002_Label.Visible = true;
                E0003_Label.Visible = false;
                E0004_Label.Visible = false;
                SetVisibleState(true);
            }
            if (this._errorMessageId.Equals(E0003))
            {
                E0001_Label.Visible = false;
                E0002_Label.Visible = false;
                E0003_Label.Visible = true;
                E0004_Label.Visible = false;
                SetVisibleState(true);
            }
            if (this._errorMessageId.Equals(E0004))
            {
                E0001_Label.Visible = false;
                E0002_Label.Visible = false;
                E0003_Label.Visible = false;
                E0004_Label.Visible = true;
                SetVisibleState(true);
            }
        }

        /// <summary>
        /// 起動ファイルを取得します。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 起動ファイルを取得します。</br>
        /// <br>Programer  : chenyk</br>
        /// <br>Date       : 2014/08/14</br>
        /// <br>Update Note: 2014/09/12 田建委</br>
        /// <br>管理番号   : 11070136-00 Redmine#43532</br>
        /// <br>           : クライアントログの出力、アイコンの指摘を対応する</br>
        /// </remarks>
        private int GetXML()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string errMessage = string.Empty;
            try
            {
                string path = ConstantManagement_ClientDirectory.UISettings + "\\" + XMLFILE;
                if (File.Exists(path))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(path);
                    XmlNode root = xmlDoc.SelectSingleNode("//ExtractConditionItem");
                    if (root != null)
                    {
                        _requireTime = Convert.ToInt32((root.SelectSingleNode("RequireTime")).InnerText);
                        _showTime = Convert.ToInt32((root.SelectSingleNode("ShowTime")).InnerText) * 1000;
                        _monitorTime = Convert.ToInt32((root.SelectSingleNode("MonitorTime")).InnerText) * 1000;
                        _retryCount = Convert.ToInt32((root.SelectSingleNode("RetryCount")).InnerText);
                    }
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMessage = ex.Message;
                PMSCM04110UA.WriteErrorLog(ex, "PMSCM04110UB.GetXML", status); // ADD 2014/09/12 田建委 Redmine#43532
            }
            finally
            {
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMessage))
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Text,
                        errMessage, 0, MessageBoxButtons.OK);
                    }
                }
            }
            return status;
        }
        #endregion
    }
}