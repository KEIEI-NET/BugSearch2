//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受信エラーチェック処理
// プログラム概要   : ユーザデータに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 作 成 日  2011/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// エラー表示フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : エラー表示のフォームクラスです。</br>
    /// <br>Programmer : 孫東響</br>
    /// <br>Date       : 2011.07.28</br>
    /// </remarks>
    public partial class PMKYO01910UA : Form
    {
        #region private
        private const int DEFAULT_X = 100000;//デフォルトx座標
        private const int DEFAULT_Y = 100000;//デフォルトy座標

        private const string MSG_NO_NEW_ORDER = "自動受信エラー情報はありません";
        private const string MSG_NEW_ORDER = "自動受信エラー情報が {0} 件あります";
        private const string CTFILE_UISETTING = "UISetting_PMKYO01100U.xml";

        private OprtnHisLogAcs _logAcs = new OprtnHisLogAcs();
        private ArrayList _errInfoList = new ArrayList();
        private const double CT_FORM_OPACITY = 0.92;
        private const int INTERVAL_DEFAULT = 3600000;
        private bool _hasErrorInfo = false;
        #endregion

        #region <コマンドライン引数>

        /// <summary>コマンドライン引数</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>コマンドライン引数を取得します。</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion // </コマンドライン引数>

        #region <フォームを閉じる判定>

        /// <summary>フォームを閉じる判定フラグ</summary>
        private bool _canClose;
        /// <summary>フォームを閉じる判定フラグのアクセサ</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion // </フォームを閉じる判定>

        #region イベント
        /// <summary>
        /// エラー処理
        /// </summary>
        /// <param name="commandLineArgs"></param>
        public PMKYO01910UA(string[] commandLineArgs)
        {
            InitializeComponent();
            _commandLineArgs = commandLineArgs;
        }

        /// <summary>
        /// エラー明細表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UltraButton_Detail_Click(object sender, EventArgs e)
        {
            try
            {
                if (_errInfoList.Count > 0)
                {
                    //エラー詳しい画面を表示
                    PMKYO01900UA form = new PMKYO01900UA(_errInfoList);
                    form.Show();

                    //ログをロジック削除
                    _logAcs.LogicalDelete();

                    //変数初期化になる
                    _hasErrorInfo = false;
                    _errInfoList = new ArrayList();
                }                
            }
            catch { }
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UltraButton_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }

        /// <summary>
        /// 画面Load
        /// </summary>
        private void PMKYO01910UA_Load(object sender, EventArgs e)
        {
            // 初期表示は隠し
            SetVisibleState(false);

            // 初期位置を設定（ちらつき防止の為、10000にしています）
            SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);

            //初期チェック
            SerachLog();

            //自動チェックを設定
            check_timer.Enabled = true;
            check_timer.Interval = GetInterval();
            
        }

        /// <summary>
        /// 画面を閉じます。
        /// </summary>
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult dResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "自動受信エラー情報処理も終了します。\r\n" +
                "終了してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.No) return;
            
            CanClose = true;
            Close();
        }

        /// <summary>
        /// パトランプアイコンのMouseClickイベントハンドラ
        /// </summary>
        /// <remarks>画面を表示します。</remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PatoLampNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (!e.Button.Equals(MouseButtons.Left)) return;
            if (_hasErrorInfo)
            {
                SetVisibleState(true);
            }
        }

        /// <summary>
        /// パトランプアイコンのMouseMoveイベントハンドラ
        /// </summary>
        /// <remarks>情報を表示します。</remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PatoLampNotifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (_errInfoList.Count > 0)
                {
                    this.patoLampNotifyIcon.Text = string.Format(MSG_NEW_ORDER, _errInfoList.Count);
                }
                else
                {
                    this.patoLampNotifyIcon.Text = MSG_NO_NEW_ORDER;
                }
            }
            catch { }
        }

        /// <summary>
        /// 画面透過率設定処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void Close_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = this.Opacity - 0.02;
            }
            catch (Exception)
            {
                this.Opacity = 0.0;
            }
            finally
            {
                if (this.Opacity <= 0.0)
                {
                    this.Visible = false;

                    // 透過率を元に戻しておく
                    this.Opacity = CT_FORM_OPACITY;

                    this.close_Timer.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 定期チェック実行タイマー処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void Check_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                SerachLog();
            }
            catch { }
        }

        /// <summary>
        /// フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PMKYO01910U_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // 意図的な終了以外はキャンセルしてアイコン化（フォームを非表示にする）
                    e.Cancel = true; // 終了処理のキャンセル
                    this.close_Timer.Enabled = true;
                    return;
                }
            }
        }
        #endregion

        #region private　メソッド
        /// <summary>
        /// 間隔時間を取得します。
        /// </summary>
        private int GetInterval()
        {
            int interval = 0;
            try
            {                
                string path = ConstantManagement_ClientDirectory.UISettings + "\\" + CTFILE_UISETTING;
                if (File.Exists(path))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path);

                    //間隔時間（分）をミリ秒に変える
                    interval = Convert.ToInt32(ds.Tables["add"].Rows[0]["value"].ToString()) * 60 * 1000;
                }
                return interval;
            }
            catch
            {
                interval = INTERVAL_DEFAULT;
                return interval;
            }
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
                Visible = false;
            }
        }

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
        /// エラーログ検索
        /// </summary>
        private void SerachLog()
        {
            try
            {
                //DO CHECK
                _logAcs.SearchLog(out _errInfoList);
                if (_errInfoList.Count > 0)
                {
                    _hasErrorInfo = true;
                    this.SetVisibleState(true);
                }
                else
                {
                    _hasErrorInfo = false;
                }
            }
            catch { }
        }
        #endregion
    }
}