//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品・入荷予約
// プログラム概要   : 出品・入荷予約 アップロード判断ダイアログ
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 陳艶丹
// 作 成 日 : 2016/01/21   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// アップロード判断ダイアログクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : アップロード判断ダイアログクラス。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/21</br>
    /// </remarks>
    public partial class PMMAX02000UG : Form
    {
        # region □private
        /// <summary>ファイル</summary>
        private string _fileName;
        /// <summary>モード</summary>
        private int _mode;

        /// <summary>ファイル</summary>
        private string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>モード</summary>
        private int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        # endregion

        #region □ Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMMAX02000UG()
        {
            InitializeComponent();
        }

         /// <summary>
        /// コンストラクタ　Nunit用
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <remarks>
        /// <br>Note       : アップロード判断ダイアログクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UG(string param)
        {
            if (("NUnit").Equals(param))
            {
                // 初期化
                InitializeComponent();
            }
            else
            {
                throw new Exception();
            }
        }

        #endregion

        #region □ Public Method

        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <param name="owner">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        /// <param name="fileName">出力ファイル</param>
        /// <param name="mode">モード</param>
        /// <remarks>
        /// <br>Note       : 画面 ShowDialog</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public DialogResult ShowDialog(IWin32Window owner, string message, int mode, string fileName)
        {
            this.lbl_Message.Text = message;
            this._mode = mode;
            this._fileName = fileName;
            return base.ShowDialog(owner);
        }

        #endregion

        #region □Control Event
        /// <summary>
        /// 画面 Loadイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 画面 Loadイベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UG_Load(object sender, EventArgs e)
        {
            Bitmap iconBitmap = new Bitmap(288, 32);
            Graphics graphics = Graphics.FromImage(iconBitmap);
            try
            {
                graphics.DrawIcon(SystemIcons.Information, 0, 0);
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }
            pictureBox_Icon.Image = iconBitmap;
        }

        /// <summary>
        /// 画面 Shownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 画面Shownイベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UG_Shown(object sender, EventArgs e)
        {
            // アップロード判断ダイアログ
            if (this._mode == 0)
            {
                this.btn_Open.Focus();
                this.btn_ErrList.Visible = false;
                this.btn_OK.Visible = false;
            }
            // 部品MAX状況監視ダイアログ
            else
            {
                this.btn_ErrList.Focus();
                this.btn_Open.Visible = false;
                this.btn_Yes.Visible = false;
                this.btn_Cancel.Visible = false;
            }
        }

        /// <summary>
        /// チェックリストを確認するボタンClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : チェックリストを確認するボタンClick イベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_Open_Click(object sender, EventArgs e)
        {
            Process.Start(_fileName);
            this.DialogResult = DialogResult.None;
        }

        /// <summary>
        /// チェックリストを確認するボタンClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : チェックリストを確認するボタンClick イベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_Yes_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// Cancel_Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 中止ボタンClick イベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Abort;
        }

        /// <summary>
        /// エラーリストを修正するボタン押下時Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : エラーリストを修正するボタン押下時イベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_ErrList_Click(object sender, EventArgs e)
        {
            Process.Start(_fileName);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// OKボタン押下時Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : OKボタン押下時イベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Yes;
            
        }

        /// <summary>
        /// 「×」ボタン押下時Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 「×」ボタン押下時イベント</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UG_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
        #endregion

       
    }
}