//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率一括登録・修正Ⅱ
// プログラム概要   ：掛率マスタの登録・修正をを一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：李占川
// 修正日    2013/02/17     修正内容：新規作成
// ---------------------------------------------------------------------//
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
    /// 掛率一括登録・修正Ⅱメインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 掛率一括登録・修正ⅡUIクラスを表示します。</br>
    /// <br>Programmer	: 李占川</br>
    /// <br>Date		: 2013/02/17</br>
    /// </remarks>
    public partial class PMKHN09901UA : Form
    {
        PMKHN09902UA _pmkhn09902UA;

        /// <summary>
        /// 掛率一括登録・修正Ⅱメインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 掛率一括登録・修正Ⅱメインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        public PMKHN09901UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        private void PMKHN09901UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09902UA = new PMKHN09902UA();
            this._pmkhn09902UA.TopLevel = false;
            this._pmkhn09902UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09902UA.Show();
            this.Controls.Add(this._pmkhn09902UA);
            this._pmkhn09902UA.Dock = DockStyle.Fill;

            this._pmkhn09902UA.FormClosed += new FormClosedEventHandler(PMKHN09902UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param> 
        /// <remarks>
        /// <br>Note		: 掛率一括登録・修正Ⅱメインフレーム画面を終了します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        private void PMKHN09902UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームが閉じられる時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void PMKHN09901UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面情報比較
            bool bStatus = this._pmkhn09902UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML保存
            this._pmkhn09902UA.SaveStateXmlData();
        }

        /// <summary>
        /// 画面サイズ変更後処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param> 
        /// <remarks>
        /// <br>Note		: 画面サイズ変更後処理時に発生します。</br>
        /// <br>Programmer	: gezh</br>
        /// <br>Date		: 2013/03/25</br>
        /// </remarks>
        private void PMKHN09901UA_SizeChanged(object sender, EventArgs e)
        {
            if (_pmkhn09902UA != null && this.WindowState != FormWindowState.Minimized)
            {
                // グリッドにスクロールバー売価率ラベルの制御
                this._pmkhn09902UA.ScrollControl();
            }
        }

    }
}