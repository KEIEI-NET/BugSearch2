//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 伝票番号引当処理
// プログラム概要   : 伝票番号引当処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/06/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2010/11/02  修正内容 : ActiveReportsのライセンスが付与されていないので対応。
//                                 (印刷時にトライアル版の旨、印字されてしまうので修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2010/11/25  修正内容 : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)
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
    /// 伝票番号引当処理フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 伝票番号引当処理を行います。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2008.06.01</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/25  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01600UA : Form
    {
        #region Constroctors
        /// <summary>
        /// 伝票番号引当処理フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 伝票番号引当処理フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2008.06.01</br>
        /// </remarks>
        public PMUOE01600UA()
        {
            InitializeComponent();
        }
        #endregion


        #region Private Members
        private PMUOE01601UA _slipNoAlwcForm;

        #endregion


        #region Event
        /// <summary>
        /// 伝票番号引当処理フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2008.03.27</br>
        /// </remarks>
        private void PMUOE01600UA_Load(object sender, EventArgs e)
        {
            this._slipNoAlwcForm = new PMUOE01601UA();

            this._slipNoAlwcForm.TopLevel = false;
            this._slipNoAlwcForm.FormBorderStyle = FormBorderStyle.None;
            this._slipNoAlwcForm.Show();
            this._slipNoAlwcForm.Dock = DockStyle.Fill;

            this.Text = this._slipNoAlwcForm.Text;

            this.Controls.Add(this._slipNoAlwcForm);
            this._slipNoAlwcForm.FormClosed += new FormClosedEventHandler(this.slipNoAlwc_FormClosed);
        }

        /// <summary>
        /// 伝票番号引当処理フォーム閉じるイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2008.03.27</br>
        /// </remarks>
        private void slipNoAlwc_FormClosed(object sender, FormClosedEventArgs e)
        {
            // --- ADD m.suzuki 2010/11/25 ---------->>>>>
            // _slipNoAlwcForm自身のCloseにより本処理が実行されているので、
            // _slipNoAlwcForm=null にすることで
            _slipNoAlwcForm = null;
            // --- ADD m.suzuki 2010/11/25 ----------<<<<<
            this.Close();
        }

        #endregion

        // --- ADD m.suzuki 2010/11/25 ---------->>>>>
        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE01600UA_FormClosed( object sender, FormClosedEventArgs e )
        {
            if ( _slipNoAlwcForm != null )
            {
                _slipNoAlwcForm.FormClosed -= this.slipNoAlwc_FormClosed;
                _slipNoAlwcForm.Close();
                _slipNoAlwcForm.Dispose();
            }
        }
        // --- ADD m.suzuki 2010/11/25 ----------<<<<<
    }
}