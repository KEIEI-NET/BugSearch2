//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : Tab�����̕ύX
// �v���O�����T�v   : Tab�����̕ύX �t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    public partial class PMPCC09040UC : Form
    {
        private string _tabName;
        /// <summary>
        /// Tab�����̕ύX�̃t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Node        :  Tab�����̕ύX�̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        public PMPCC09040UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tab��
        /// </summary>
        public string TabName
        {
           get { return this._tabName; }
           set { this._tabName = value; }
        }
        
        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            this.Name_tEdit.Text = string.Empty;
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �m��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            //�K�{���̓`�F�b�N
            string inputValue = this.Name_tEdit.Text.Trim();
            if (string.IsNullOrEmpty(inputValue))
            {
                //���C���ɖ߂�
                TMsgDisp.Show(this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "TAB������͂��ĉ�����",
                                   -1,
                                   MessageBoxButtons.OK);
                this.Name_tEdit.Focus();
                return;
            }
            else
            {
                this._tabName = inputValue;
                this.DialogResult = DialogResult.OK;
                this.Name_tEdit.Clear();
                this.Name_tEdit.Focus();

                this.Close();
            }
        }

        /// <summary>
        /// Form.Load �C�x���g(PMPCC09040UC)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer  : ���C��</br>
        /// <br>Date        : 2011.07.20</br>
        /// </remarks>
        private void PMPCC09040UC_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            this.Cancel_Button.ImageList = imageList25;
            this.Save_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;

            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Save_Button.Appearance.Image = Size24_Index.DECISION;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Name_tEdit.Focus();
            this.Name_tEdit.Text = this._tabName;
            this.Cancel_Button.Enabled = true;
            this.Delete_Button.Enabled = true;
        }

      
    }
}