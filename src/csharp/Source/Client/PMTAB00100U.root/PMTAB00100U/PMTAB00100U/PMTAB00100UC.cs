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
    /// SCMポップアップ画面に自動回答情報を表示するかどうかの設定画面
    /// </summary>
    /// <remarks>
    /// <br>Note		: 設定画面</br>
    /// </remarks>
    public partial class PMTAB00100UC : Form
    {
        /// <summary>売上情報登録の提示を表示するかどうか定数</summary>
        private const string CT_Conf_SaleSlipCreateView = "SaleSlipCreateView";

        /// <summary>「config」ファイル</summary>
        private const string Exe_Conf_Filename = "PMTAB00100U.exe.config";

        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMTAB00100UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定ボタンイベント処理
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 設定ボタン処理を行います。</br>
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
        /// 閉じるボタンイベント処理
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 閉じるボタン処理を行います。</br>
        /// </remarks>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 画面表示イベント処理
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 画面表示処理を行います。</br>
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
        /// ConfigurationSection取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ConfigurationSection取得処理を行います。</br>
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