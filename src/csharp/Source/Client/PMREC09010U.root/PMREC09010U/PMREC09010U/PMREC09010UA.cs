//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : レコメンド商品関連設定マスタ
// プログラム概要   : レコメンド商品関連設定マスタの保守を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/01/20  修正内容 : 新規作成
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
    /// レコメンド商品関連設定マスタ UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : レコメンド商品関連設定マスタUIフォームクラス</br>
    /// <br>Programmer : 宮本利明</br>
    /// <br>Date       : 2015/01/20</br>
    /// </remarks>
    public partial class PMREC09010UA : Form
    {
        /// <summary>
        ///レコメンド商品関連設定マスタメインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : レコメンド商品関連設定マスタメインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public PMREC09010UA()
        {
            InitializeComponent();
        }

        private PMREC09011UA _pmrec09011UA;

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面がLoadされた時に発生します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09010UA_Load(object sender, EventArgs e)
        {
            this._pmrec09011UA = new PMREC09011UA();
            this._pmrec09011UA.TopLevel = false;
            this._pmrec09011UA.FormBorderStyle = FormBorderStyle.None;
            this._pmrec09011UA.Show();
            this.Controls.Add(this._pmrec09011UA);
            this._pmrec09011UA.Dock = DockStyle.Fill;

            this._pmrec09011UA.FormClosed += new FormClosedEventHandler(this.PMREC09011UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : レコメンド商品関連設定マスタメインフレーム画面を終了します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09011UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._pmrec09011UA.BeforeFormClose();
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
                this._pmrec09011UA.BeforeFormClose();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : レコメンド商品関連設定マスタメインフレーム画面を表示します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void PMREC09010UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
            this._pmrec09011UA.SetInitFocus();
        }
    }
}