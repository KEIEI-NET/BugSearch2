//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品設定マスタ
// プログラム概要   : お買得商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
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
    /// お買得商品設定マスタ UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買得商品設定マスタUIフォームクラス</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public partial class PMREC09020UA : Form
    {
        /// <summary>
        ///お買得商品設定マスタメインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : お買得商品設定マスタメインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public PMREC09020UA()
        {
            InitializeComponent();
        }

        private PMREC09021UA _PMREC09021UA;

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面がLoadされた時に発生します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09020UA_Load(object sender, EventArgs e)
        {
            this._PMREC09021UA = new PMREC09021UA();
            this._PMREC09021UA.TopLevel = false;
            this._PMREC09021UA.FormBorderStyle = FormBorderStyle.None;
            this._PMREC09021UA.Show();
            this.Controls.Add(this._PMREC09021UA);
            this._PMREC09021UA.Dock = DockStyle.Fill;

            this._PMREC09021UA.FormClosed += new FormClosedEventHandler(this.PMREC09021UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : お買得商品設定マスタメインフレーム画面を終了します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09021UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._PMREC09021UA.BeforeFormClose();
            this.Close();
        }

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
                this._PMREC09021UA.BeforeFormClose();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : お買得商品設定マスタメインフレーム画面を表示します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09020UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
            this._PMREC09021UA.SetInitFocus();
        }
    }
}