//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^�u���b�g�ݒ�}�X�^�A�b�v���[�h����
// �v���O�����T�v   : �^�u���b�g�ݒ�}�X�^�A�b�v���[�h����
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �A����
// �� �� ��  2013/05/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �A����
// �� �� ��  2013/06/14  �C�����e : ���Ӑ�}�X�^�A�b�v���[�h�����̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �A����
// �� �� ��  2013/06/19  �C�����e : status�l���풓�����ƍ��킹�邱�Ƃ̕ύX
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �^�u���b�g�ݒ�}�X�^�A�b�v���[�h�����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�u���b�g�ݒ�}�X�^�A�b�v���[�h�����̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : �A����</br>
    /// <br>Date       : 2013/05/29</br>
    /// </remarks>
    public partial class PMTAB00110UA : Form
    {
        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        #region �� Private Const
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// �I��
        private const string TOOLBAR_EXECUTEBUTTON_KEY = "ButtonTool_Execute";                  // ���s

        private const string CT_PGID = "PMTAB00110U";
        private const string CT_PGNM = "�^�u���b�g�ݒ�}�X�^�A�b�v���[�h����";

        private TabSCMUpLoadAcs tabSCMUpLoadAcs = null;
        #endregion �� Private Const

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// �^�u���b�g�ݒ�}�X�^�A�b�v���[�h�����t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�ݒ�}�X�^�A�b�v���[�h�����̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        public PMTAB00110UA()
        {
            InitializeComponent();
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // �R���X�g���N�^�Ń��O�o�͗p�f�B���N�g�����쐬
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }
        #endregion

        //======================================================================================= //
        //  ���������o�[
        //======================================================================================= //
        #region ��Private Members
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = "";
        /// <summary>�����_�R�[�h</summary>
        private string _loginSectionCode = "";

        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        private const string CLASS_NAME = "PMTAB00110UA";
        // �^�u���b�g���O�Ή��@---------------------------------<<<<<

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private void PMTAB00110UA_Load(object sender, EventArgs e)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "PMTAB00110UA_Load";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            // ��ʂ��\�z
            this.ScreenInitialSetting();
            tabSCMUpLoadAcs = new TabSCMUpLoadAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        ///	��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����ݒ���������܂��B</br>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {

            // �C���[�W���X�g�ݒ�
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // �c�[���A�C�R���ݒ�
            //----------------------------
            // �I��
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // ���s
            this.tToolsManager_MainMenu.Tools[TOOLBAR_EXECUTEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private DialogResult MsgDisp(string message, emErrorLevel iLevel)
        {
            // ���b�Z�[�W�\��
            return TMsgDisp.Show(
                this,                               // �e�E�B���h�E�t�H�[��
                iLevel,                             // �G���[���x��
                this.GetType().ToString(),          // �A�Z���u���h�c�܂��̓N���X�h�c
                message,                            // �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OK);             // �\������{�^��
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g�B</br>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "tToolsManager_MainMenu_ToolClick";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            switch (e.Tool.Key)
            {
                // -------------------------------------------------------------------------------
                // �I��
                // -------------------------------------------------------------------------------
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                        EasyLogger.Write(CLASS_NAME, methodName, "�I���{�^���N���b�N");
                        // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                        #region �I��
                        this.Close();
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // ���s
                // -------------------------------------------------------------------------------
                case TOOLBAR_EXECUTEBUTTON_KEY:
                    {
                        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                        EasyLogger.Write(CLASS_NAME, methodName, "���s�{�^���N���b�N");
                        // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                        #region ���s
                        DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, Text,
                                "���s���܂����H", 0, MessageBoxButtons.OKCancel);
                        if (ret == DialogResult.OK)
                        {
                            SFCMN00299CA _progressForm;
                            _progressForm = new SFCMN00299CA();

                            _progressForm.Title = "�A�b�v���[�h��";
                            _progressForm.Message = "���݁A�f�[�^���A�b�v���[�h���ł��B";
                            _progressForm.Show();
                            string msg = "";
                            if (this.ExecuteProc())
                            {
                                _progressForm.Close();
                                msg = "�ݒ�}�X�^�̃A�b�v���[�h���������܂����B";
                            }
                            else
                            {
                                _progressForm.Close();
                                msg = "�ݒ�}�X�^�̃A�b�v���[�h�����s���܂����B";
                            }
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                               msg, 0, MessageBoxButtons.OK);
                        }
                        #endregion
                        break;
                    }
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
        }

        /// <summary>
        /// ���s����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���s�������܂��B</br>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <returns></returns>
        private bool ExecuteProc()
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "ExecuteProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            bool saveFlg = false;

            if(tabSCMUpLoadAcs == null)
            {
                tabSCMUpLoadAcs = new TabSCMUpLoadAcs();
            }
            int status = tabSCMUpLoadAcs.UploadFromNStoSCM(this._enterpriseCode,this._loginSectionCode.Trim());
            //�e�e�[�v���A�b�v���[�h�����̏ꍇstatus++ 
            //status = 10:�A�b�v���[�h�����@status<10:�A�b�v���[�h���s
            //if (status == 9) // DEL �A����  2013/06/14 ���Ӑ�}�X�^�A�b�v���[�h�����̒ǉ� 
            //if (status == 10)  // ADD �A����  2013/06/14 ���Ӑ�}�X�^�A�b�v���[�h�����̒ǉ�    // DEL �A����  2013/06/19  status�l���풓�����ƍ��킹�邱�Ƃ̕ύX�@
            if (status == 0)  // ADD �A����  2013/06/19  status�l���풓�����ƍ��킹�邱�Ƃ̕ύX
            {
                saveFlg = true;
            }

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return saveFlg;
        }

        #endregion
    }
}