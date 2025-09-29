//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌出荷部品表示
// プログラム概要   : 車輌出荷部品表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/09/10  修正内容 : 新規作成
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
    /// 車輌出荷部品表示
    /// </summary>
    /// <remarks>
    /// Note       : 車輌出荷部品表示設定処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.09.10<br />
    /// </remarks>
    public partial class PMSYA04000UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        public PMSYA04000UA()
        {
            InitializeComponent();
        }
        #endregion

        # region ■ private field ■

        private PMSYA04001UA _pMSYA04001UA;

        # endregion ■ private field ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void PMSYA04000UA_Load(object sender, EventArgs e)
        {
            this._pMSYA04001UA = new PMSYA04001UA();
            this._pMSYA04001UA.TopLevel = false;
            this._pMSYA04001UA.FormBorderStyle = FormBorderStyle.None;
            this._pMSYA04001UA.Show();
            this._pMSYA04001UA.Dock = DockStyle.Fill;
            this.Text = this._pMSYA04001UA.Text;
            this.Controls.Add(this._pMSYA04001UA);
            this._pMSYA04001UA.FormClosed += new FormClosedEventHandler(this.PMSYA04001UA_FormClosed);
        }
        # endregion ■ フォームロード ■

        #region ■ Private Method ■
        /// <summary>
        /// 画面閉じる処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void PMSYA04001UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion ■ Private Method ■
    }
}