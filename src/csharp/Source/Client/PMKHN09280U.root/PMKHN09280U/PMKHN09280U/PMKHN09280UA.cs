//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �a�k�R�[�h�w�ʕϊ�����
// �v���O�����T�v   : �a�k�R�[�h�w�ʕϊ��������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2010/01/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/01/25  �C�����e : Redmine#2603�̑Ή�
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
using System.IO;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �a�k�R�[�h�w�ʕϊ�����
    /// </summary>
    /// <remarks>
    /// <br>Note        : �a�k�R�[�h�w�ʕϊ������ł��B<br/>
    /// <br>Programmer  : ������<br/>
    /// <br>Date        : 2010/01/11<br/>
    /// <br>Update Note : 2010/01/25 ������ Redmine#2593�̑Ή�</br>
    /// </remarks>
    public partial class PMKHN09280UA : Form
    {
        #region �� Const Memebers ��
        private const string ct_ClassID = "PMKHN09280UA";
        //�|���p�����[�^�t�@�C��
        private const string INI_FILE_RATE = "PMCV1200.INI";
        //���i�p�����[�^�t�@�C��
        private const string INI_FILE_GOODS = "PMCV1100.INI";
        //���ʃp�����[�^�t�@�C��
        private const string INI_FILE_PARTS = "PMCV1160.INI";
        //�D�ǐݒ�p�����[�^�t�@�C��
        private const string INI_FILE_EXCELLENTSET = "PMCV1180.INI";
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
        // �a�k�R�[�h�w�ʕϊ������C���^�[�t�F�[�X�Ώ�
        private BlCodeLevelChangeAcs _blCodeLevelChangeAcs;
        // ���O�C���S���Җ���
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        // �f�t�H���g�s�̊O�ϐݒ�
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        # endregion �� private field ��

        # region �� Constructor ��
        /// <summary>
        /// �a�k�R�[�h�w�ʕϊ�����UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�w�ʕϊ�����UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09280UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._runButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._blCodeLevelChangeAcs = new BlCodeLevelChangeAcs();

        }
        # endregion �� Constructor ��

        #region  �� Control Event ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/01/11</br>
        /// </remarks>
        private void PMKHN09280UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // �{�^��������
            this.ButtonInitialSetting();

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/01/11</br>
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
                        string errMessage = "";
                        Control errComponent = null;
                        // ���̓`�F�b�N����
                        if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
                        {
                            // ���b�Z�[�W��\��
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMessage, 0);

                            // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                            if (errComponent != null)
                            {
                                errComponent.Focus();
                            }
                            return;
                        }
                        // ���s�m�F���b�Z�[�W�\��
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "���������s���܂����H",
                            0,
                            MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // ���s����
                            this.UpdateProcess();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// INI�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : INI�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/01/11</br>
        /// </remarks>
        private void uButton_IniTextFileName_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "�t�H���_�̎Q��";
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tEdit_IniTextFileName.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        /// <summary>
        /// Log�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : Log�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/01/11</br>
        /// </remarks>
        private void uButton_LogTextFileName_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "�t�H���_�̎Q��";
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tEdit_LogTextFileName.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        /// <summary>
        /// �p�C���̃u���[�h�̐ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �p�C���̃u���[�h�̐ݒ���s���B</br> 
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/01/11</br>
        /// </remarks>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                        panel1.ClientRectangle,
                                        Color.Black,
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.Black,
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.Black,
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.Black,
                                        1,
                                        ButtonBorderStyle.Solid);
        }
        #endregion

        #region  �� Private Method ��

        /// <summary>�G���[���b�Z�[�W�\������</summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/01/11</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                "�a�k�R�[�h�w�ʕϊ�����",			// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/01/11</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            string iniFileName = this.tEdit_IniTextFileName.DataText.Trim();
            string logFileName = this.tEdit_LogTextFileName.DataText.Trim();
            if (iniFileName == string.Empty)
            {
                errMessage = "INI�t�@�C���i�[�t�H���_����͂��ĉ������B";
                errComponent = this.tEdit_IniTextFileName;
                status = false;
                return status;
            }
            if (!Directory.Exists(iniFileName))
            {
                errMessage = "INI�t�@�C���i�[�t�H���_�����݂��܂���B";
                errComponent = this.tEdit_IniTextFileName;
                status = false;
                return status;
            }
            if (Directory.Exists(iniFileName))
            {
                // -----------ADD 2010/01/25----------->>>>>
                //�Ō��"\"��t������ꍇ
                if (iniFileName.Substring(iniFileName.Length - 1).Equals("\\"))
                {
                    iniFileName = iniFileName.Remove(iniFileName.Length - 1);
                }
                // -----------ADD 2010/01/25-----------<<<<<
                string[] fileList = Directory.GetFiles(iniFileName);
                string iniFile_Rate = iniFileName + "\\" + INI_FILE_RATE;
                string iniFile_Goods = iniFileName + "\\" + INI_FILE_GOODS;
                string iniFile_Parts = iniFileName + "\\" + INI_FILE_PARTS;
                string iniFile_ExcellentSet = iniFileName + "\\" + INI_FILE_EXCELLENTSET;
                string message = "INI�t�@�C�����i�[����Ă��邩\r\n" + "�m�F���ĉ������B\r\n\n" + INI_FILE_GOODS + "\n" + INI_FILE_PARTS + "\n" + INI_FILE_EXCELLENTSET + "\n" + INI_FILE_RATE + "\n";

                ArrayList al = new ArrayList();
                if (fileList == null)
                {
                    errMessage = "INI�t�@�C���i�[�t�H���_�����݂��܂���B";
                    errComponent = this.tEdit_IniTextFileName;
                    status = false;
                    return status;
                }
                else
                {
                    foreach (string file in fileList)
                    {
                        al.Add(file);
                    }
                    //�t�H���_���ɉ��L�t�@�C�����P�ł��s�����Ă���ꍇ�̓G���[
                    if (!al.Contains(iniFile_Rate) || !al.Contains(iniFile_Goods) ||
                        !al.Contains(iniFile_Parts) || !al.Contains(iniFile_ExcellentSet))
                    {
                        errMessage = message;
                        errComponent = this.tEdit_IniTextFileName;
                        status = false;
                        return status;
                    }
                }
            }
            if (logFileName == string.Empty)
            {
                errMessage = "���O�t�@�C���i�[�t�H���_����͂��ĉ������B";
                errComponent = this.tEdit_LogTextFileName;
                status = false;
                return status;
            }
            if (!Directory.Exists(logFileName))
            {
                errMessage = "���O�t�@�C���i�[�t�H���_�����݂��܂���B";
                errComponent = this.tEdit_LogTextFileName;
                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// �a�k�R�[�h�w�ʕϊ�����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �a�k�R�[�h�w�ʕϊ��������s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/01/11</br>
        /// </remarks>
        private void UpdateProcess()
        {
            // ���o����ʕ��i�̃C���X�^���X���쐬
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�a�k�R�[�h�w�ʕϊ�����";
            form.Message = "���݁A�������ł��B";
            // �_�C�A���O�\��
            form.Show();
            string errMsg = string.Empty;
            // �a�k�R�[�h�w�ʕϊ�����
            status = this._blCodeLevelChangeAcs.Update(this.tEdit_IniTextFileName.Text, this.tEdit_LogTextFileName.Text, out errMsg);
            // �_�C�A���O�����
            form.Close();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�������������܂����B",
                    -1,
                    MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�������ɃG���[���������܂����B(" + status + ")",
                    -1,
                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/01/11</br>
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
            //INI�t�@�C���i�[�t�H���_
            this.uButton_IniTextFileName.ImageList = this._imageList16;
            this.uButton_IniTextFileName.Appearance.Image = Size16_Index.STAR1;
            //���O�t�@�C���i�[�t�H���_
            this.uButton_LogTextFileName.ImageList = this._imageList16;
            this.uButton_LogTextFileName.Appearance.Image = Size16_Index.STAR1;
        }
        #endregion  �� Private Method ��
    }
}