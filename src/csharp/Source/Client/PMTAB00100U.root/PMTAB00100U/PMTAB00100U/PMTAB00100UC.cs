using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM�|�b�v�A�b�v��ʂɎ����񓚏���\�����邩�ǂ����̐ݒ���
    /// </summary>
    /// <remarks>
    /// <br>Note		: �ݒ���</br>
    /// </remarks>
    public partial class PMTAB00100UC : Form
    {
        /// <summary>������o�^�̒񎦂�\�����邩�ǂ����萔</summary>
        private const string CT_Conf_SaleSlipCreateView = "SaleSlipCreateView";

        /// <summary>�uconfig�v�t�@�C��</summary>
        private const string Exe_Conf_Filename = "PMTAB00100U.exe.config";

        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMTAB00100UC()
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
        /// </remarks>
        private void setButton_Click(object sender, EventArgs e)
        {
            Configuration config = null;
            AppSettingsSection appSettingSection = GetAppSettingsSection(out config);
            if (this.checkEditor.Checked)
            {
                appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value = "1";
            }
            else
            {
                appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value = "0";
            }
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
        /// </remarks>
        private void PMTAB00100UF_Shown(object sender, EventArgs e)
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

            if (appSettingSection.Settings[CT_Conf_SaleSlipCreateView].Value.Equals("1"))
                this.checkEditor.Checked = true;
            else
                this.checkEditor.Checked = false;
        }

        /// <summary>
        /// ConfigurationSection�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ConfigurationSection�擾�������s���܂��B</br>
        /// </remarks>
        private AppSettingsSection GetAppSettingsSection(out Configuration config)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            
            file.ExeConfigFilename = Exe_Conf_Filename;
            config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            return (AppSettingsSection)config.GetSection(App_Set_Section);
        }
    }
}