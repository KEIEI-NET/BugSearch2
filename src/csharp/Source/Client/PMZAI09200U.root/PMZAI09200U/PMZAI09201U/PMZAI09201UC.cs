//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F ���i�݌Ɉꊇ�o�^�C�����
// �v���O�����T�v   �F ���i�݌Ɉꊇ�o�^�C����ʂ̍ő�o�͌�����ǉ�
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���Fyangyi
// �C����    2013/03/13     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00    �쐬�S�� : yangyi
// �C �� ��  2013/04/19     �C�����e : 20150515�z�M���̑Ή��ARedmine#35018
//                                     �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�݌Ɉꊇ�o�^�C����ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�݌Ɉꊇ�o�^�C����ʗp�̃��[�U�[�ݒ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : yangyi</br>
    /// <br>Date       : 2013/03/13</br>
    /// <br>Update Note: 2013/04/18 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���Ή�</br>
    /// </remarks>
    public partial class PMZAI09201UC : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region �� Private Members
        private ImageList _imageList16 = null;
        private const string XML_FILE_NAME = "UISetting_PMZAI09201UC.XML";
        //private const string WARNING_MSG = "�ő�o�͌������������߁A�������x���Ȃ�\��������܂��B" + "\r\n" + "\r\n" + "�o�^���Ă�낵���ł����H"; //DEL yangyi 2013/04/19 Redmine#35018
        private const string WARNING_MSG = "�ő�o�͌������������߁A�������x���Ȃ�\��������܂��B" + "\r\n" + "\r\n" + "�ݒ肵�Ă�낵���ł����H";   //ADD yangyi 2013/04/19 Redmine#35018
        private const string WARNING_MSG2 = "�ő�o�͌�����1����20000�̒l����͂��ĉ������B";   //ADD yangyi 2013/04/19 Redmine#35018
        private const string ERROR_MSG = "���͉\�ȍő�l�� 20000 �ł��B";

        private int _maxCount;            //�ő�o�͌���
        # endregion �� Private Members

        #region �� Public Property
        /// <summary>
        /// �ő�o�͌����v���p�e�B
        /// </summary>
        public int MaxCount
        {
            get
            {
                return _maxCount;
            }
        }
        #endregion �� Public Property

        #region �� Constructor
        /// <summary>
        /// ���i�݌Ɉꊇ�o�^�C����ʗp���[�U�[�ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�݌Ɉꊇ�o�^�C����ʗp���[�U�[�ݒ�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// <br></br>
        /// </remarks>
        public PMZAI09201UC()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            Deserialize();

        }
        #endregion �� Constructor

        #region �� Control Events
        /// <summary>
        /// Form.Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void PMZAI09201UC_Load(object sender, EventArgs e)
        {
            this.OK_Button.ImageList = this._imageList16;
            this.OK_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.ImageList = this._imageList16;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.UNDO;
        }

        /// <summary>
        /// Button_Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // --- ADD yangyi 2013/04/19 for Redmine#35018 ------->>>>>>>>>>>
            if (this.tNedit_MaxCount.GetInt() <=0 )
            {
                //�ő�o�͌�����1�`20000���̌x����ʂ�\�����܂��B
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    this.Name,				            // �v���O��������
                    WARNING_MSG2,						// �\�����郁�b�Z�[�W
                    0, 							        // �X�e�[�^�X�l
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��

                //�ݒ��ʂɖ߂�܂�
                this.DialogResult = DialogResult.Retry;
                this.tNedit_MaxCount.Focus();
            }
            else if (this.tNedit_MaxCount.GetInt() >0 && this.tNedit_MaxCount.GetInt() < 5000)
            // --- ADD yangyi 2013/04/19 for Redmine#35018 -------<<<<<<<<<<<
	        {
                //���̂܂ܓo�^���܂�
	            Serialize(); 
                this.Close();
            }

            else if (this.tNedit_MaxCount.GetInt() >= 5000 && this.tNedit_MaxCount.GetInt() <= 20000)
	        {
                // �x����\��
                DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        WARNING_MSG,
                        0,
                        MessageBoxButtons.OKCancel,
                        MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.OK)
                {
                    Serialize();
                    this.Close();
                }
                else
                {
                   //�ݒ��ʂɖ߂�܂�
                   this.DialogResult = DialogResult.Retry;
                   this.tNedit_MaxCount.Focus();
                }
                
	        }
            else if (this.tNedit_MaxCount.GetInt() > 20000)
            {
                //�ő�o�͌�����5000���ȏ�̂Ƃ��Ɍx����ʂ�\�����܂��B
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    this.Name,				            // �v���O��������
                    ERROR_MSG,							// �\�����郁�b�Z�[�W
                    0, 							        // �X�e�[�^�X�l
                    MessageBoxButtons.OK, 				// �\������{�^��
                    MessageBoxDefaultButton.Button1);	// �����\���{�^��

                //�ݒ��ʂɖ߂�܂�
                this.DialogResult = DialogResult.Retry;
                this.tNedit_MaxCount.Focus();
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �t�H�[���N���[�W���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�������[�W���O���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void PMZAI09201UC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }

        #endregion �� Control Events

        #region �� Private Methods
        /// <summary>
        ///  ���i�݌Ɉꊇ�o�^�C����ʗp���[�U�[�ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _maxCount = UserSettingController.DeserializeUserSetting<int>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            else
            {
                //�K��l2000
                _maxCount = 2000;
            }
            this.tNedit_MaxCount.SetInt(_maxCount);      
        }

        /// <summary>
        ///  ���i�݌Ɉꊇ�o�^�C����ʗp���[�U�[�ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void Serialize()
        {
            if (this.tNedit_MaxCount.GetInt() == 0)
            {
                _maxCount = 2000;
            }
            else
            {
                _maxCount = this.tNedit_MaxCount.GetInt();
            }
            
            UserSettingController.SerializeUserSetting(_maxCount, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
        }


        #endregion �� Private Methods
   }
}


