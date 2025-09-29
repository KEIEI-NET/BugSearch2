//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ
// プログラム概要   : キャンペーン対象商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10701342-00 作成担当 : 曹文傑
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/07  修正内容 : Redmine#22810 明細項目の幅・文字サイズは変更時に保存の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタUIフォームクラス</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 明細項目の幅・文字サイズは変更時に保存の対応</br>
    /// </remarks>
    public partial class PMKHN09620UA : Form
    {
        /// <summary>
        ///キャンペーン対象商品設定マスタメインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン対象商品設定マスタメインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public PMKHN09620UA()
        {
            InitializeComponent();
        }

        private PMKHN09621UA _pmkhn09621UA;

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面がLoadされた時に発生します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09620UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09621UA = new PMKHN09621UA();
            this._pmkhn09621UA.TopLevel = false;
            this._pmkhn09621UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09621UA.Show();
            this.Controls.Add(this._pmkhn09621UA);
            this._pmkhn09621UA.Dock = DockStyle.Fill;

            this._pmkhn09621UA.FormClosed += new FormClosedEventHandler(this.PMKHN09621UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン対象商品設定マスタメインフレーム画面を終了します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 明細項目の幅・文字サイズは変更時に保存の対応</br>
        /// </remarks>
        private void PMKHN09621UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._pmkhn09621UA.BeforeFormClose();  // ADD 2011/07/07 
            this.Close();
        }

        // ----- ADD 2011/07/07 ------- >>>>>>>>>
        /// <summary>
        /// ウィンドウメッセージ制御処理
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                // FormClose前の処理
                this._pmkhn09621UA.BeforeFormClose();
            }
            base.WndProc(ref m);
        }
        // ----- ADD 2011/07/07 ------- <<<<<<<<<

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン対象商品設定マスタメインフレーム画面を表示します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09620UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
            this._pmkhn09621UA.SetInitFocus();
        }
    }
}