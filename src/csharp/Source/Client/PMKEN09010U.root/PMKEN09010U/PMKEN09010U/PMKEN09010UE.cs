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
    /// �p�X���[�h���̓N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �p�X���[�h���̓N���X</br>
    /// <br>Programmer  : 30414 �E �K�j</br>
    /// <br>Date        : 2009/02/19</br>
    /// </remarks>
    public partial class InputPassword : Form
    {
        private ControlScreenSkin _controlScreenSkin;
        private string _password;

        /// <summary>
        /// �p�X���[�h���̓R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �p�X���[�h���̓N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2009/02/19</br>
        /// </remarks>
        public InputPassword()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();
        }

        /// <summary>
        /// �p�X���[�h�v���p�e�B
        /// </summary>
        public String Password
        {
            get { return _password;}
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void InputPassword_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.tEdit_Password.Focus();
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this._password = this.tEdit_Password.Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}