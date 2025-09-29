//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^
// �v���O�����T�v   : �����}�X�^�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2010/06/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2013/12/04  �C�����e : Redmine#41447�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO; // ADD 杍^�@2013/12/04
using Broadleaf.Application.Common; // ADD 杍^�@2013/12/04
using Broadleaf.Application.Resources; // ADD 杍^�@2013/12/04

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����}�X�^
    /// </summary>
    /// <remarks>
    /// Note       : �����}�X�^�ݒ菈���ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2010/06/08<br />
    /// </remarks>
    public partial class PMKEN09079UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKEN09079UA()
        {
            InitializeComponent();

            this._userSetting = new FormMemPos(); // ADD 杍^�@2013/12/04
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private PMKEN09074UA _pmKEN09074UA;

        // ADD 杍^�@2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMKEN09079U.XML";

        // ���[�U�[�ݒ�
        private FormMemPos _userSetting;

        public FormMemPos UserSetting
        {
            get { return this._userSetting; }
        }
        // ADD 杍^�@2013/12/04 FOR Redmine#41447 ------<<<<<<

        # endregion �� private field ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void PMKEN09079UA_Load(object sender, EventArgs e)
        {
            this._pmKEN09074UA = new PMKEN09074UA();
            this._pmKEN09074UA.TopLevel = false;
            this._pmKEN09074UA.FormBorderStyle = FormBorderStyle.None;

            // ADD 杍^�@2013/12/04 FOR Redmine#41447 ------>>>>>>
            // �ݒ�ǂݍ���
            bool existFlg = this.Deserialize();

            if (existFlg)
            {
                this.Location = new Point(_userSetting.Left, _userSetting.Top);
                this.Height = _userSetting.Height;
                this.Width = _userSetting.Width;

                if (_userSetting.WindowState.Equals("Maximized"))
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (_userSetting.WindowState.Equals("Minimized"))
                {
                    this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
            // ADD 杍^�@2013/12/04 FOR Redmine#41447 ------<<<<<<

            this._pmKEN09074UA.Show();
            this._pmKEN09074UA.Dock = DockStyle.Fill;
            this.Text = this._pmKEN09074UA.Text;
            this.Controls.Add(this._pmKEN09074UA);
            this._pmKEN09074UA.FormClosed += new FormClosedEventHandler(this.PMKEN09079UA_FormClosed);
        }
        # endregion �� �t�H�[�����[�h ��

        #region �� Private Method ��
        /// <summary>
        /// ��ʕ��鏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void PMKEN09079UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        // ADD START �����@2013/12/04 FOR Redmine#41447 ------>>>>>>
        private void PMKEN09079UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._pmKEN09074UA.BeforeFormClose();

            _userSetting.Top = this.Top;
            _userSetting.Left = this.Left;
            _userSetting.Height = this.Height;
            _userSetting.Width = this.Width;
            _userSetting.WindowState = this.WindowState.ToString();
            this.Serialize();


        }
        // ADD END �����@2013/12/04 FOR Redmine#41447 ------<<<<<<

        // ADD START 杍^�@2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>
        /// �����}�X�^�p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        private void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// �����}�X�^�p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        private bool Deserialize()
        {
            bool fileExist = false;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<FormMemPos>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME)));
                    fileExist = true;
                }
                catch
                {
                    this._userSetting = new FormMemPos();
                }
            }

            return fileExist;
        }
        // ADD END 杍^�@2013/12/04 FOR Redmine#41447 ------<<<<<<

        #endregion �� Private Method ��
    }

    #region FormMemPos
    /// <summary>
    /// �����}�X�^�p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class FormMemPos
    {
        #region �v���C�x�[�g�ϐ�
        // TOP
        private int _top;
        // LEFT
        private int _left;
        // HEIGHT
        private int _height;
        // WIDTH
        private int _width;
        // WINDOWSTATE
        private string _windowState = string.Empty;
        #endregion

        # region �R���X�g���N�^
        /// <summary>
        /// �����}�X�^���[�U�[�ݒ���N���X
        /// </summary>
        public FormMemPos()
        {
        }
        # endregion // �R���X�g���N�^

        #region �v���p�e�B
        /// <summary>TOP</summary>
        public int Top
        {
            get { return this._top; }
            set { this._top = value; }
        }
        /// <summary>LEFT</summary>
        public int Left
        {
            get { return this._left; }
            set { this._left = value; }
        }
        /// <summary>HEIGHT</summary>
        public int Height
        {
            get { return this._height; }
            set { this._height = value; }
        }
        /// <summary>WIDTH</summary>
        public int Width
        {
            get { return this._width; }
            set { this._width = value; }
        }
        /// <summary>WINDOWSTATE</summary>
        public string WindowState
        {
            get { return this._windowState; }
            set { this._windowState = value; }
        }
        #endregion
    }
    #endregion
}