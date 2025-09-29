using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// パスワード入力クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : パスワード入力クラス</br>
    /// <br>Programmer  : 30414 忍 幸史</br>
    /// <br>Date        : 2009/02/19</br>
    /// </remarks>
    public partial class InputPassword : Form
    {
        private ControlScreenSkin _controlScreenSkin;
        private string _password;

        /// <summary>
        /// パスワード入力コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : パスワード入力クラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/02/19</br>
        /// </remarks>
        public InputPassword()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();
        }

        /// <summary>
        /// パスワードプロパティ
        /// </summary>
        public String Password
        {
            get { return _password;}
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void InputPassword_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.tEdit_Password.Focus();
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this._password = this.tEdit_Password.Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}