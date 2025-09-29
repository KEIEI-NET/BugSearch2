using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ＵＯＥ回答表示(元帳)
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// <br>Update Note: 2010/11/25  22018 鈴木 正臣</br>
    /// <br>           : Adobe Reader9以降だと終了時エラー発生する件の対応。(WebBrowser解放処理の修正)</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE04200UA : Form
	{
        private PMUOE04201UA _uoeReplyReference;    // UI

        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMUOE04200UA()
		{
			InitializeComponent();
        }
        #endregion

        #region ■PMUOE04201UA_Load(フォームロード)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォーム起動時の処理。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void PMUOE04201UA_Load(object sender, EventArgs e)
        {
            this.Text = "UOE回答表示(元帳)";                //ADD 2009/01/20 不具合対応[9833]

            this._uoeReplyReference = new PMUOE04201UA();

            this._uoeReplyReference.TopLevel = false;
            this._uoeReplyReference.FormBorderStyle = FormBorderStyle.None;
            this._uoeReplyReference.Show();

            this._uoeReplyReference.Dock = DockStyle.Fill;
            this._uoeReplyReference.FormClosed += new FormClosedEventHandler(this.UOEReplyReferenceForm_FormClosed);
            this.Controls.Add(this._uoeReplyReference);
        }
        #endregion

        #region ■UOEReplyReferenceForm_FormClosed(フォームクローズ)
        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる時の処理。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void UOEReplyReferenceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // --- ADD m.suzuki 2010/11/25 ---------->>>>>
            // _uoeReplyReference自体のCloseにより本処理が呼ばれているので、
            // _uoeReplyReference=nullにする事で、２重に処理しないようにする。
            _uoeReplyReference = null;
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
        private void PMUOE04200UA_FormClosed( object sender, FormClosedEventArgs e )
        {
            if ( _uoeReplyReference != null )
            {
                // 子フォームの解放
                _uoeReplyReference.FormClosed -= this.UOEReplyReferenceForm_FormClosed;
                _uoeReplyReference.Close();
                _uoeReplyReference.Dispose();
            }
        }
        // --- ADD m.suzuki 2010/11/25 ----------<<<<<
    }
}