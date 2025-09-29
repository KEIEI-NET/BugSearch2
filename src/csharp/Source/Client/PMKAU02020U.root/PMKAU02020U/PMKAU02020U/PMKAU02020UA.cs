//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d�q����A�g�ݒ�
// �v���O�����T�v   : �d�q����A�g�ݒ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00 �쐬�S�� : 3H ����
// �� �� ��  2022/03/25  �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using System.IO;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �d�q����A�g�ݒ�
    /// </summary>
    /// <remarks>
    /// <br>Note        : �d�q����A�g�ݒ���s���܂��B</br>
    /// <br>Programmer	: 3H ����</br>
    /// <br>Date		: 2022/03/25</br>  
    /// </remarks>
    public partial class PMKAU02020UA : Form
    {
        # region Private Constant
        // �v���O����ID
        private const string ct_PGID = "PMKAU02020U";
        # endregion

        # region Private Members
        private EbooksLinkSetAcs _ebooksLinkSetAcs;
        #endregion

        #region Constractor
        /// <summary>
        /// �d�q����A�g�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: �d�q����A�g�ݒ�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: 3H ����</br>
        /// <br>Date		: 2022/03/25</br>
        /// </remarks>
        public PMKAU02020UA()
        {
            InitializeComponent();

            if (_ebooksLinkSetAcs == null)
                _ebooksLinkSetAcs = new EbooksLinkSetAcs();
        }
        # endregion

        #region Private Methods
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������A�����ݒ菈�����s���܂��B</br>
        /// <br>Programmer	: 3H ����</br>
        /// <br>Date		: 2022/03/25</br>
        /// </remarks> 
        private void InitilSetting()
        {
            // �{�^���̃C���[�W�ݒ�
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.OK_Button.ImageList = imageList24;
            this.OK_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;


            // �K�C�h�{�^���̃C���[�W�ݒ�
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.EBooksFolderGuide_ultraButton.ImageList = imageList16;
            this.CustomFolderGuide_ultraButton.ImageList = imageList16;
            this.EBooksFolderGuide_ultraButton.Appearance.Image = Size16_Index.STAR1;
            this.CustomFolderGuide_ultraButton.Appearance.Image = Size16_Index.STAR1;

            // �t�H���_�p�X�����\��
            EBooksLinkSetInfo eBooksLinkSetInfo = new EBooksLinkSetInfo();
            _ebooksLinkSetAcs.GetEBooksFolderPath(out eBooksLinkSetInfo);

            this.EBooksFolderPath_tEdit.Text = eBooksLinkSetInfo.EBooksFolder;
            this.CustomFolderPath_tEdit.Text = eBooksLinkSetInfo.CustomFolder;
        }

        /// <summary>
        /// �t�H���_�p�X���̓`�F�b�N
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �t�H���_�p�X�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private bool FolderPathCheck()
        {
            bool checkFlg = true;

            string eBooksFolderPath = this.EBooksFolderPath_tEdit.Text.TrimEnd();
            string customFolderPath = this.CustomFolderPath_tEdit.Text.TrimEnd();

            #region [�t�H���_�`�F�b�N]
            // �d�q����󂯓n���t�H���_ �ݒ�L��
            if (string.IsNullOrEmpty(eBooksFolderPath))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, �@�@�@�@       // �G���[���x��
                              ct_PGID, 						    �@�@�@�@         // �A�Z���u���h�c�܂��̓N���X�h�c
                              "�d�q����󂯓n���t�H���_��ݒ肵�ĉ������B",      // �\�����郁�b�Z�[�W
                              0, 							�@�@�@�@�@�@�@�@     // �X�e�[�^�X�l
                              MessageBoxButtons.OK);				�@�@�@�@     // �\������{�^��
                EBooksFolderPath_tEdit.Focus();
                checkFlg = false;
            }
            // �d�q����󂯓n���t�H���_ ���݃`�F�b�N
            else if (!Directory.Exists(eBooksFolderPath))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, �@�@�@�@                              // �G���[���x��
                              ct_PGID, 						    �@�@�@�@                                // �A�Z���u���h�c�܂��̓N���X�h�c
                              "�w�肳�ꂽ�t�H���_�����݂��܂���B(�d�q����󂯓n���t�H���_)",           // �\�����郁�b�Z�[�W
                              0, 							�@�@�@�@�@�@ �@�@                           // �X�e�[�^�X�l
                              MessageBoxButtons.OK);                                                    // �\������{�^��
                EBooksFolderPath_tEdit.Focus();
                checkFlg = false;
            }
            // ����惊�X�g�󂯓n���t�H���_�@�ݒ�L��
            else if (string.IsNullOrEmpty(customFolderPath))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, �@�@�@�@      // �G���[���x��
                              ct_PGID, 						    �@�@�@�@        // �A�Z���u���h�c�܂��̓N���X�h�c
                              "����惊�X�g�󂯓n���t�H���_��ݒ肵�ĉ������B", // �\�����郁�b�Z�[�W
                              0, 							�@�@�@�@�@�@�@�@    // �X�e�[�^�X�l
                              MessageBoxButtons.OK);				�@�@�@�@    // �\������{�^��
                CustomFolderPath_tEdit.Focus();
                checkFlg = false;
            }
            // ����惊�X�g�󂯓n���t�H���_�@���݃`�F�b�N
            else if (!Directory.Exists(customFolderPath))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, �@�@�@�@                                  // �G���[���x��
                              ct_PGID, 						    �@�@�@�@                                   // �A�Z���u���h�c�܂��̓N���X�h�c
                              "�w�肳�ꂽ�t�H���_�����݂��܂���B(����惊�X�g�󂯓n���t�H���_)",   	   // �\�����郁�b�Z�[�W
                              0, 							�@�@�@�@�@�@�@�@                               // �X�e�[�^�X�l
                              MessageBoxButtons.OK);				�@�@�@�@                               // �\������{�^��
                CustomFolderPath_tEdit.Focus();
                checkFlg = false;
            }
            #endregion

            return checkFlg;
        }
        # endregion

        #region Private Methods (Control Event)
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����[�h�C�x���g�������s���܂��B</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void PMKAU02010U_Load(object sender, EventArgs e)
        {
            InitilSetting();
        }

        /// <summary>
        /// ������Focus����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ������Focus�������s���܂��B</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void PMKAU02010UA_Shown(object sender, EventArgs e)
        {
            this.EBooksFolderPath_tEdit.Focus();
        }

        /// <summary>
        ///  Control.Click �C�x���g(Guide_ultraButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : Guide_ultraButton�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void FolderGuide_ultraButton_Click(object sender, EventArgs e)
        {
            // �d�q����󂯓n���t�H���_�K�C�h�̏ꍇ
            if (sender == this.EBooksFolderGuide_ultraButton)
            {
                folderBrowserDialog1.SelectedPath = EBooksFolderPath_tEdit.Text;
                folderBrowserDialog1.Description = "�󂯓n���t�H���_�̏ꏊ���w�肵�Ă��������B";

                DialogResult dRet = folderBrowserDialog1.ShowDialog();
                if (dRet == DialogResult.OK)
                {
                    this.EBooksFolderPath_tEdit.Text = System.IO.Path.GetFullPath(folderBrowserDialog1.SelectedPath);
                    this.CustomFolderPath_tEdit.Focus();
                }
                else
                {
                    this.EBooksFolderGuide_ultraButton.Focus();
                }
            }
            // ����惊�X�g�󂯓n���t�H���_�K�C�h�̏ꍇ
            else if (sender == this.CustomFolderGuide_ultraButton)
            {
                folderBrowserDialog1.SelectedPath = CustomFolderPath_tEdit.Text;
                folderBrowserDialog1.Description = "�󂯓n���t�H���_�̏ꏊ���w�肵�Ă��������B";

                DialogResult dRet = folderBrowserDialog1.ShowDialog();
                if (dRet == DialogResult.OK)
                {
                    this.CustomFolderPath_tEdit.Text = System.IO.Path.GetFullPath(folderBrowserDialog1.SelectedPath);

                    this.OK_Button.Focus();
                }
                else
                {
                    this.CustomFolderGuide_ultraButton.Focus();
                }
            }
        }

        /// <summary>
        /// Ok_Button.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : OK�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (this.FolderPathCheck() == false)
                return;

            EBooksLinkSetInfo eBooksLinkSetInfo = new EBooksLinkSetInfo();
            eBooksLinkSetInfo.CustomFolder = this.CustomFolderPath_tEdit.Text.Trim();
            eBooksLinkSetInfo.EBooksFolder = this.EBooksFolderPath_tEdit.Text.Trim();

            int status = _ebooksLinkSetAcs.WriteEBooksFolderPath(ref eBooksLinkSetInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                MessageBox.Show("�ۑ����܂����B", "�ۑ��m�F", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOPDISP, �@�@�@   �@         // �G���[���x��
                        ct_PGID, 						    �@�@�@�@         // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�d�q����A�g�ݒ�̕ۑ����ɃG���[���������܂����B",  // �\�����郁�b�Z�[�W
                        status, 							�@�@�@�@         // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				�@�@�@�@         // �\������{�^��

            }

            this.Close();
        }

        /// <summary>
        /// Cancel_Button.Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : Cancel�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2022/03/25</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
