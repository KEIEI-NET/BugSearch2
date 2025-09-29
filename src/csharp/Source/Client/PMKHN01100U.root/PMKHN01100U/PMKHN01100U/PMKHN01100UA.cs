//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񋟃f�[�^�폜����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��č폜�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� :
// �C �� ��              �C�����e :
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �񋟃f�[�^�폜����
    /// </summary>
    /// <remarks>
    /// Note       : �񋟃f�[�^�폜�����ł��B<br />
    /// Programmer : ������<br />
    /// Date       : 2009.06.15<br />
    /// </remarks>
    public partial class PMKHN01100UA : Form
    {
        #region �� Const Memebers ��
        private const string ct_ClassID = "PMKHN01100UA";
        #endregion �� Const Memebers ��

        # region �� private field ��

        private ImageList _imageList16 = null;
        // �N���[�Y�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        // ���s�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _runButton;
        // ���O�C���S����
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;
        // �񋟃f�[�^�폜�����C���^�[�t�F�[�X�Ώ�
        private OfferDataDeleteAcs _offerDataDeleteAcs;
        // ���O�C���S���Җ���
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        // �f�t�H���g�s�̊O�ϐݒ�
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        # endregion �� private field ��

        # region �� Constructor ��
        /// <summary>
        /// �񋟃f�[�^�폜����UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �񋟃f�[�^�폜����UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        /// <br></br>
        /// </remarks>
        public PMKHN01100UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._runButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._offerDataDeleteAcs = new OfferDataDeleteAcs();

        }
        # endregion �� Constructor ��

        #region  �� Control Event ��
        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.06.15</br>
        /// </remarks>
        private void PMKHN01100UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // �{�^��������
            this.ButtonInitialSetting();

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

        }
        # endregion �� �t�H�[�����[�h ��

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.06.15</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Run":
                    {
                        // ���s�m�F���b�Z�[�W�\��
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�񋟃f�[�^�폜���������s���܂��B\r\n��낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // ���s����
                            this.DeleteProcess();
                        }
                        break;
                    }
            }
        }
        #endregion

        #region  �� Private Method ��
        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �f�[�^�폜�������s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.06.15</br>
        /// </remarks>
        private void DeleteProcess()
        {
            // ���o����ʕ��i�̃C���X�^���X���쐬
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�񋟃f�[�^�폜����";
            form.Message = "���݁A�񋟃f�[�^�폜���ł��B";
            // �_�C�A���O�\��
            form.Show();
            string errMsg = string.Empty;
            // �f�[�^�폜����
            status = this._offerDataDeleteAcs.Delete(out errMsg);
            // �_�C�A���O�����
            form.Close();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�񋟃f�[�^�폜�������������܂����B",
                    -1,
                    MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.Name,
                   errMsg,
                   -1,
                   MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�񋟃f�[�^�폜�������ɃG���[���������܂����B\r\n�Z�L�����e�B�Ǘ��̃��O�\����\r\n�V�X�e�����O���m�F���ĉ������B",
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.15</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            // �I���{�^��
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // ���s�{�^��
            this._runButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // ���O�C���S���҃��[�x��
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        # endregion �� �{�^�������ݒ菈�� ��
        #endregion  �� Private Method ��


    }
}