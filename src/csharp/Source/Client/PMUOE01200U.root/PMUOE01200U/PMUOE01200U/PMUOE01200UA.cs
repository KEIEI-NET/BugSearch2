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
    /// UOE入庫更新メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE入庫更新のメインフレームクラスです。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/09/04</br>
    /// </remarks>
    public partial class PMUOE01200UA : Form
	{
        // 変数
        private PMUOE01201UA _uoeEnterUpdate;    // UI

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ▼Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public PMUOE01200UA()
		{
			InitializeComponent();
        }
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ▼PMUOE01200UA_Load(フォームロード)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender">PMUOE01200UA型</param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面表示項目の初期化を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void PMUOE01200UA_Load(object sender, EventArgs e)
        {
            this._uoeEnterUpdate = new PMUOE01201UA();

            // PMUOE01200UA表示
            this._uoeEnterUpdate.TopLevel = false;
            this._uoeEnterUpdate.FormBorderStyle = FormBorderStyle.None;
            this._uoeEnterUpdate.Show();

            // PMUOE01201UAをPMUOE01200UAに貼り付ける
            this._uoeEnterUpdate.Dock = DockStyle.Fill;
            this._uoeEnterUpdate.FormClosed += new FormClosedEventHandler(this.UOEEnterUpdateForm_FormClosed);
            this.Controls.Add(this._uoeEnterUpdate);
        }
        #endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ▼UOEEnterUpdateForm_FormClosed(フォームクローズ)
        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender">PMUOE01201UA型</param>
        /// <param name="e">フォームクローズイベントデータ</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void UOEEnterUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}