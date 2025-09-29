//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Ԍ������X�V
// �v���O�����T�v   : �Ԍ������X�V�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
// Update Note : 2010/05/08 ���C�� REDMINE #7111�̑Ή�
// �@�@�@�@�@�@: �m�F�̃��b�Z�[�W�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �Ԍ������X�V
    /// </summary>
    /// <remarks>
    /// Note       : �Ԍ������X�V�����ł��B<br />
    /// Programmer : ���C��<br />
    /// Date       : 2010/04/21<br />
    /// </remarks>
    public partial class PMSYA05001UA : Form
    {
        #region �� Const Memebers ��
        private const string PROGRAM_ID = "PMSYA05000U";
        #endregion

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �R���X�g���N�^�̏��������s���B</br>
        /// <br>Programmer	: ���C��</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        public PMSYA05001UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._inspectDateUpdAcs = InspectDateUpdAcs.GetInstance();
        }
        # endregion

        # region �� private field ��
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executionButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode;                         // ��ƃR�[�h
        private InspectDateUpdAcs _inspectDateUpdAcs;
        #endregion

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: ���C��</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void PMKHN09270UA_Load(object sender, EventArgs e)
        {
            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ��ʃf�[�^�̏������ݒ�
            this.InitializeScreen();
        }

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this.Main_UTabControl.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2];
        }
        # endregion

        #region �� ��ʃf�[�^�̏��������� ��
        /// <summary>
        /// ��ʃf�[�^�̏���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʃf�[�^�̂��s��</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010/04/21</br>
        /// <br>Update Note: 2010/05/08 ���C�� �m�F�̃��b�Z�[�W�̕ύX</br>
        /// </remarks>
        private void InitializeScreen()
        {
            this.UpdateDate_tDateEdit.SetDateTime(DateTime.Today);
        }
        #endregion
       
        #endregion

        #region �� �Ԍ������X�V�������b�\�h�֘A ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: ���C��</br>	
        /// <br>Date		: 2010/04/21</br>
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
                        bool inputCheck = this.ExecutBeforeCheck();

                        if (inputCheck)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            // --- UPD 2010/05/08 ---------->>>>>
                            //"�Ԍ������̍X�V���s���܂��B\r\n��邵���ł����H",
                            "�Ԍ������̍X�V���s���܂��B\r\n��낵���ł����H",
                            // --- UPD 2010/05/08 ----------<<<<<
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // ���s����
                                this.ExecuteProcess();
                            }
                        }
                    }
                    break;
            }
        }

        #region �� ���̓`�F�b�N���� ��
        /// <summary>
        /// �Ԍ������X�V�O�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �Ԍ������X�V�O�`�F�b�N�������s���B</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private bool ExecutBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);


                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="errControl">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string message, ref Control errControl)
        {
            message = "";
            errControl = null;

            //���͓��t�𐔒l�^�Ŏ擾
            int date = this.UpdateDate_tDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;

            if (yy == 0 || mm > 12 || mm == 0)
            {
                message = "�X�V�N���̓��͂��s���ł��B";
                errControl = this.UpdateDate_tDateEdit;
                return false;
            }

            return true;
        }
        #endregion
        #endregion

        #region �� �Ԍ������X�V ��
        /// <summary>
        /// �Ԍ������X�V����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �Ԍ������X�V�������s���B</br>
        /// <br>Programmer	: ���C��</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        private void ExecuteProcess()
        {


            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�Ԍ������X�V";
            form.Message = "���݁A�Ԍ������̍X�V�������ł��B\r\n���΂炭���҂���������";

            this.Cursor = Cursors.WaitCursor;
            // �_�C�A���O�\��
            form.Show();

            int date = this.UpdateDate_tDateEdit.GetLongDate();
            int day = DateTime.DaysInMonth(date / 10000, (date / 100) % 100);
            //TODO ��ʎw�� �X�V�N��(����)�ȑO
            int status = _inspectDateUpdAcs.InspectDateUpdProc(this._enterpriseCode, date / 100 * 100 + day);

            // �_�C�A���O�����
            form.Close();
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "�������������܂����B",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "�Y���f�[�^������܂���B",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "�������ɃG���[���������܂����B�i" + status.ToString() + "�j",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion
    }
}