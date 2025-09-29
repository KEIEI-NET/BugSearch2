//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 日産発注処理
// プログラム概要   : 日産発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 作 成 日  2010/03/08  修正内容 : 新規作成
//                                  日産Web-UOEとの連携用データとして、UOE発注データから日産Web-UOE用システム連携ファイルの作成を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 日産発注処理メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 日産発注処理UIクラスを表示します。</br>
    /// <br>Programmer	: 呉元嘯</br>
    /// <br>Date		: 2010/03/08</br>
    /// </remarks>
    public partial class PMUOE01520UA : Form
    {
        PMUOE01521UA _pmuoe01521UA;

        /// <summary>
        ///日産発注処理メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 日産発注処理メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/03/08</br>
        /// </remarks>
        public PMUOE01520UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 日産発注処理メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/03/08</br>
        /// </remarks>
        private void PMUOE01520UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/03/08</br>
        /// </remarks>
        private void PMUOE01520U_Load(object sender, EventArgs e)
        {
            this._pmuoe01521UA = new PMUOE01521UA();
            this._pmuoe01521UA.TopLevel = false;
            this._pmuoe01521UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01521UA.Show();
            this._pmuoe01521UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01521UA);


            this._pmuoe01521UA.FormClosed += new FormClosedEventHandler(PMUOE01520UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 日産発注処理メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/03/08</br>
        /// </remarks>
        private void PMUOE01520UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ファイル（ストリーム）をクローズ
            this._pmuoe01521UA.CloseFileStreamU();

        }
    }
}