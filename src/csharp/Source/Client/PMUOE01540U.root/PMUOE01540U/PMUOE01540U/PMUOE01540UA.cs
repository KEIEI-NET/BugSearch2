//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マツダ発注処理
// プログラム概要   : マツダ発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 李占川
// 作 成 日  2011/05/18  修正内容 : 新規作成
//                                  マツダWebUOEとの連携用データとして、UOE発注データからマツダ用システム連携アドレスの作成を行う
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
    /// マツダ発注処理メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: マツダ発注処理UIクラスを表示します。</br>
    /// <br>Programmer	: 李占川</br>
    /// <br>Date		: 2011/05/18</br>
    /// </remarks>
    public partial class PMUOE01540UA : Form
    {
        PMUOE01541UA _pmuoe01541UA;

        /// <summary>
        ///マツダ発注処理メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: マツダ発注処理メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2011/05/18</br>
        /// </remarks>
        public PMUOE01540UA()
        {
            InitializeComponent();
        }
        /// <summary>
        /// マツダ発注処理フォーム閉じるイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : マツダ発注処理フォーム閉じる</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void _pmuoe01541UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2011/05/18</br>
        /// </remarks>
        private void PMUOE01540U_Load(object sender, EventArgs e)
        {
            this._pmuoe01541UA = new PMUOE01541UA();
            this._pmuoe01541UA.TopLevel = false;
            this._pmuoe01541UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01541UA.Show();
            this._pmuoe01541UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01541UA);


            this._pmuoe01541UA.FormClosed += new FormClosedEventHandler(_pmuoe01541UA_FormClosed);
        }
    }
}