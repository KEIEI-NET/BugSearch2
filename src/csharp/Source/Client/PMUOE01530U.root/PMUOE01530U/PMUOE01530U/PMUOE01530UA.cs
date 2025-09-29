//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 三菱発注処理
// プログラム概要   : 三菱発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : gaoyh
// 作 成 日  2010/04/20  修正内容 : 新規作成
//                                  三菱Web-UOEとの連携用データとして、UOE発注データから三菱Web-UOE用システム連携ファイルの作成を行う
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
    /// 三菱発注処理メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 三菱発注処理UIクラスを表示します。</br>
    /// <br>Programmer	: gaoyh</br>
    /// <br>Date		: 2010/04/20</br>
    /// </remarks>
    public partial class PMUOE01530UA : Form
    {
        PMUOE01531UA _pmuoe01531UA;

        /// <summary>
        ///三菱発注処理メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 三菱発注処理メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: gaoyh</br>
        /// <br>Date		: 2010/04/20</br>
        /// </remarks>
        public PMUOE01530UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 三菱発注処理メインフレーム画面を終了します。</br>
        /// <br>Programmer	: gaoyh</br>
        /// <br>Date		: 2010/04/20</br>
        /// </remarks>
        private void PMUOE01530UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: gaoyh</br>
        /// <br>Date		: 2010/04/20</br>
        /// </remarks>
        private void PMUOE01530U_Load(object sender, EventArgs e)
        {
            this._pmuoe01531UA = new PMUOE01531UA();
            this._pmuoe01531UA.TopLevel = false;
            this._pmuoe01531UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01531UA.Show();
            this._pmuoe01531UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01531UA);


            this._pmuoe01531UA.FormClosed += new FormClosedEventHandler(PMUOE01530UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 三菱発注処理メインフレーム画面を終了します。</br>
        /// <br>Programmer	: gaoyh</br>
        /// <br>Date		: 2010/04/20</br>
        /// </remarks>
        private void PMUOE01530UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ファイル（ストリーム）をクローズ
            this._pmuoe01531UA.CloseFileStreamU();

        }
    }
}