using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM�|�b�v�A�b�v��ʂɎ����񓚏���\�����邩�ǂ����̐ݒ���
    /// </summary>
    /// <remarks>
    /// <br>Note		: �ݒ���</br>
    /// <br>Programmer	: duzg</br>
    /// <br>Date		: 2011/07/18</br>
    /// <br>Update Note : 2011/07/27 duzg</br>
    /// <br>            :  �V���`�F�b�J�[����:Redmine#23240 �{�^������</br> 
    /// <br>Update Note : 2011/07/28 duzg</br>
    /// <br>            :  �V���`�F�b�J�[����:Redmine#23241�Ή�</br> 
    /// <br>Update Note : 2014/10/17 �{�{ ����</br>
    /// <br>            :  SCM�d�|�ꗗ��82�@���M���Ή�</br> 
    /// <br>Update Note : 2014/10/28 �{�{ ����</br>
    /// <br>            :  �V�X�e���e�X�g��Q�ꗗ��1�FEnableChars�v���p�e�B��Word��True�ɐݒ�</br> 
    /// <br>            :  �V�X�e���e�X�g��Q�ꗗ��2�FArrowKeyControl��t����B</br> 
    /// </remarks>
    public partial class PMSCM00005UF : Form
    {
        /// <summary>�����񓚂̏���\�����邩�ǂ����萔</summary>
        private const string CT_Conf_AutoAnswerView = "AutoAnswerView";

        /// <summary>�uconfig�v�t�@�C��</summary>
        private const string Exe_Conf_Filename = "PMSCM00005U.exe.config";

        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";

        // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� -------------------->>>>>
        /// <summary>���M���ݒ�</summary>
        private const string CT_Conf_SoundMode = "SoundMode"; //���M�����[�h
        private const string CT_Conf_SoundTime = "SoundTime"; //���M���b��
        private const string CT_Conf_SoundPath = "SoundPath"; //���M���t�@�C��

        private bool _soundMode = false;
        private int _soundTime = 0;
        private string _soundPath = string.Empty;

        public bool SoundMode
        {
            set { _soundMode = value; }
            get { return _soundMode; }
        }
        public int SoundTime
        {
            set { this._soundTime = value; }
            get { return this._soundTime; }
        }
        public string SoundPath
        {
            set { this._soundPath = value; }
            get { return this._soundPath; }
        }
        // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� --------------------<<<<<

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMSCM00005UF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �ݒ�{�^���C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �ݒ�{�^���������s���܂��B</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private void setButton_Click(object sender, EventArgs e)
        {
            Configuration config = null;
            AppSettingsSection appSettingSection = GetAppSettingsSection(out config);
            if (this.checkEditor.Checked)
            {
                appSettingSection.Settings[CT_Conf_AutoAnswerView].Value = "1";
            }
            else
            {
                appSettingSection.Settings[CT_Conf_AutoAnswerView].Value = "0";
            }
            // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� -------------------->>>>>
            // ���M�����[�h
            if (this.checkSound.Checked)
            {
                appSettingSection.Settings[CT_Conf_SoundMode].Value = "1"; //�I��

                // ���M���ݒ���e�`�F�b�N
                if (!checkSoundTime()) return;
                if (!checkSoundPath()) return;
            }
            else
            {
                appSettingSection.Settings[CT_Conf_SoundMode].Value = "0"; //�I�t
            }
            // ���M���b��
            appSettingSection.Settings[CT_Conf_SoundTime].Value = this.tNedit_SoundSec.GetInt().ToString();
            // ���M���t�@�C��
            appSettingSection.Settings[CT_Conf_SoundPath].Value = this.tEdit_SoundPath.Text.Trim();

            _soundMode = this.checkSound.Checked;
            _soundTime = this.tNedit_SoundSec.GetInt();
            _soundPath = this.tEdit_SoundPath.Text.Trim();
            // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� --------------------<<<<<

            config.Save(ConfigurationSaveMode.Modified);

            this.Close();
        }

        /// <summary>
        /// ����{�^���C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : ����{�^���������s���܂��B</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��ʕ\���C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : ��ʕ\���������s���܂��B</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private void PMSCM00005UF_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Activate();

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
            Configuration config = null;
            AppSettingsSection appSettingSection = GetAppSettingsSection(out config);

            if (appSettingSection.Settings[CT_Conf_AutoAnswerView].Value.Equals("1"))
                this.checkEditor.Checked = true;
            else
                this.checkEditor.Checked = false;

            // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� -------------------->>>>>
            _soundMode = (!appSettingSection.Settings[CT_Conf_SoundMode].Value.Equals("0"));
            _soundTime = int.Parse(appSettingSection.Settings[CT_Conf_SoundTime].Value);
            _soundPath = appSettingSection.Settings[CT_Conf_SoundPath].Value;

            tNedit_SoundSec.SetInt(this._soundTime);
            tEdit_SoundPath.DataText = this._soundPath;
            checkSound.Checked = this._soundMode;
            SoundEnabledChanged();

            ImageList imageList16 = IconResourceManagement.ImageList16;
            uButton_SoundGuide.ImageList = imageList16;
            uButton_SoundGuide.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� --------------------<<<<<
        }

        /// <summary>
        /// ConfigurationSection�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ConfigurationSection�擾�������s���܂��B</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private AppSettingsSection GetAppSettingsSection(out Configuration config)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            
            file.ExeConfigFilename = Exe_Conf_Filename;
            config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� -------------------->>>>>
            AppSettingsSection appSettingSection = (AppSettingsSection)config.GetSection(App_Set_Section);
            // ���M�����[�h�ݒ�̍��ڂ������ꍇ�A�R���t�B�O�ɒǉ����ĕۑ�
            if (appSettingSection.Settings[CT_Conf_SoundMode] == null)
            {
                config.AppSettings.Settings.Add(CT_Conf_SoundMode, "0");
            }
            config.Save(ConfigurationSaveMode.Modified);
            if (appSettingSection.Settings[CT_Conf_SoundTime] == null)
            {
                config.AppSettings.Settings.Add(CT_Conf_SoundTime, "0");
            }
            config.Save(ConfigurationSaveMode.Modified);
            if (appSettingSection.Settings[CT_Conf_SoundPath] == null)
            {
                config.AppSettings.Settings.Add(CT_Conf_SoundPath, string.Empty);
            }
            config.Save(ConfigurationSaveMode.Modified);
            // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� --------------------<<<<<

            return (AppSettingsSection)config.GetSection(App_Set_Section);
        }

        // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� -------------------->>>>>
        /// <summary>
        /// ���M����ON/OFF�ؑ�
        /// </summary>
        private void checkSound_CheckedChanged(object sender, EventArgs e)
        {
            SoundEnabledChanged();
        }

        /// <summary>
        /// ���M����ON/OFF�ؑւɂ�鍀�ڐݒ�
        /// </summary>
        private void SoundEnabledChanged()
        {
            tNedit_SoundSec.Enabled = checkSound.Checked;
            tEdit_SoundPath.Enabled = checkSound.Checked;
            uButton_SoundGuide.Enabled = checkSound.Checked;
            uLabel_Sound.Enabled = checkSound.Checked;
            uLabel_SoundSec.Enabled = checkSound.Checked;
            uLabel_SoundPath.Enabled = checkSound.Checked;
            uLabel_SoundNotes.Enabled = checkSound.Checked;
        }

        /// <summary>
        /// ���M���ݒ�_�C�A���O
        /// </summary>
        private void uButton_SoundGuide_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.tEdit_SoundPath.DataText = this.openFileDialog.FileName;
                if (!checkSoundPath()) return;
            }
        }

        /// <summary>
        /// ���M���ݒ�l�`�F�b�N�F�Đ�����
        /// </summary>
        private bool checkSoundTime()
        {
            bool bRet = true;
            string sErrMsg = string.Empty;

            if (this.tNedit_SoundSec.GetInt() == 0)
            {
                sErrMsg = "�Đ����Ԃ�ݒ肵�Ă��������B";
                bRet = false;
            }
            if (!bRet)
            {
                TMsgDisp.Show(this                               // �e�E�B���h�E�t�H�[��
                             ,emErrorLevel.ERR_LEVEL_EXCLAMATION // �G���[���x��
                             ,"PMSCM00005UF"                     // �A�Z���u���h�c�܂��̓N���X�h�c
                             ,sErrMsg                            // �\�����郁�b�Z�[�W
                             ,0                                  // �X�e�[�^�X�l
                             ,MessageBoxButtons.OK);             // �\������{�^��
                this.tNedit_SoundSec.Focus();
            }
            return bRet;
        }

        /// <summary>
        /// ���M���ݒ�l�`�F�b�N�F���M���t�@�C��
        /// </summary>
        private bool checkSoundPath()
        {
            bool bRet = true;
            string sErrMsg = string.Empty;

            if (!this.tEdit_SoundPath.Text.Trim().Equals(string.Empty))
            {
                if (!System.IO.File.Exists(this.tEdit_SoundPath.Text.Trim()))
                {
                    sErrMsg = "�w�肵�����M���t�@�C���͑��݂��܂���B";
                    bRet = false;
                }
                else
                {
                    string sExtension = Path.GetExtension(this.tEdit_SoundPath.Text).TrimStart('.');
                    if (sExtension.ToUpper() != "WAV")
                    {
                        sErrMsg = "�t�@�C���`���Ɍ�肪����܂��B";
                        bRet = false;
                    }
                }
                if (!bRet)
                {
                    TMsgDisp.Show(this
                                 ,emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 ,"PMSCM00005UF"
                                 ,sErrMsg
                                 ,0
                                 ,MessageBoxButtons.OK);
                    this.tEdit_SoundPath.Focus();
                }
            }
            return bRet;
        }

        /// <summary>
        /// ���^�[���L�[�ړ��C�x���g
        /// </summary>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_SoundSec":
                {
                    if (!checkSoundTime()) e.NextCtrl = e.PrevCtrl;
                    break;
                }
                case "tEdit_SoundPath":
                {
                    if (!checkSoundPath()) e.NextCtrl = e.PrevCtrl;
                    break;
                }
            }
        }
        // --- ADD 2014/10/17 T.Miyamoto SCM�d�|�ꗗ��82 ���M���Ή� --------------------<<<<<
    }
}