//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Z�b�g�}�X�^
// �v���O�����T�v   : �Z�b�g�}�X�^�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2010/06/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11175121-00 �쐬�S�� : gaocheng
// �C �� ��  2015/07/02  �C�����e : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Application.Resources;
//---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �Z�b�g�}�X�^
    /// </summary>
    /// <remarks>
    /// Note       : �Z�b�g�}�X�^�ݒ菈���ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2010/06/08<br />
    /// </remarks>
    public partial class MAKHN09629UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MAKHN09629UA()
        {
            InitializeComponent();
            this._userSetting = new FormMemPos(); // ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private MAKHN09620UA _maKHN09620UA;

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "MAKHN09629U.XML";
        /// <summary>��ʂ̑O��top�ʒu</summary>
        private int _top;
        /// <summary>��ʂ̑O��left�ʒu</summary>
        private int _left;
        /// <summary>��ʂ̑O��width�l</summary>
        private int _width;
        /// <summary>��ʂ̑O��height�l</summary>
        private int _height;
        // ���[�U�[�ݒ�
        private FormMemPos _userSetting;

        public FormMemPos UserSetting
        {
            get { return this._userSetting; }
        }
        //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<

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
        /// <br>Update Note: 2015/07/02 gaocheng</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>  
        /// </remarks>
        private void MAKHN09629UA_Load(object sender, EventArgs e)
        {
            this._maKHN09620UA = new MAKHN09620UA();
            this._maKHN09620UA.TopLevel = false;
            this._maKHN09620UA.FormBorderStyle = FormBorderStyle.None;
            //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
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
            //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<
            this._maKHN09620UA.Show();
            this._maKHN09620UA.Dock = DockStyle.Fill;
            this.Text = this._maKHN09620UA.Text;
            this.Controls.Add(this._maKHN09620UA);
            this._maKHN09620UA.FormClosed += new FormClosedEventHandler(this.MAKHN09629UA_FormClosed);
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
        /// <br>Update Note: 2015/07/02 gaocheng</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>   
        /// </remarks>
        private void MAKHN09629UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ---->>>>>
        /// <summary>
        /// �t�H�[���N���[�W���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���[�W���O�C�x���g���s���B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>   
        /// </remarks> 
        private void MAKHN09629UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._maKHN09620UA.BeforeFormClose();
            if (this.WindowState == FormWindowState.Minimized)
            {
                _userSetting.Top = this._top;
                _userSetting.Left = this._left;
                _userSetting.Height = this._height;
                _userSetting.Width = this._width;
                _userSetting.WindowState = this.WindowState.ToString();
            }
            else
            {
                _userSetting.Top = this.Top;
                _userSetting.Left = this.Left;
                _userSetting.Height = this.Height;
                _userSetting.Width = this.Width;
                _userSetting.WindowState = this.WindowState.ToString();
            }
            this.Serialize();
        }

        /// <summary>
        /// �Z�b�g�}�X�^�p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>   
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
        /// �Z�b�g�}�X�^�p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>    
        /// </remarks>
        private bool Deserialize()
        {
            bool fileExist = false;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<FormMemPos>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_FormPos, XML_FILE_NAME));
                    fileExist = true;
                }
                catch
                {
                    this._userSetting = new FormMemPos();
                }
            }

            return fileExist;
        }

        #endregion �� Private Method ��
        /// <summary>
        /// �t�H�[���T�C�Y�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���T�C�Y�ύX�C�x���g���s���B</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>�Ǘ��ԍ�   : 11175121-00</br>
        /// <br>           : Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή�</br>    
        /// </remarks>
        private void MAKHN09629UA_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this._left = this.Left;
                this._top = this.Top;
                this._width = this.Width;
                this._height = this.Height;
            }
        }
    }

    #region FormMemPos
    /// <summary>
    /// �Z�b�g�}�X�^�p���[�U�[�ݒ�N���X
    /// </summary>
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
        /// �Z�b�g�}�X�^���[�U�[�ݒ���N���X
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
    //---- ADD gaocheng 2015/07/02 for Redmine#45798 �E�B���h�E�ʒu�ƃT�C�Y�̋L�����\�̑Ή� ----<<<<<
}