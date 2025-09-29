using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace CreateConfig
{
    public partial class MainForm : Form
    {
        /// <summary>アプリケーション構成クラス用シリアライズキー</summary>
        private static readonly string[] AppConfigKey = new string[] { typeof(SimplInqIDExchangeAcs).Name, "AppConfigKey" };
        /// <summary>アプリケーション設定ファイル名</summary>
        private static readonly string AppConfigFileName = "PMSCM01040A_Config.dat";


        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (UserSettingController.ExistUserSetting(this.txt_FileName.Text.Trim()))
            {
                SimplInqIDExchangeAppConfig config;
                try
                {
                    config = UserSettingController.DecryptionDeserializeUserSetting<SimplInqIDExchangeAppConfig>(this.txt_FileName.Text.Trim(), AppConfigKey);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail to Decrypt and Deserialize!!\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (config != null)
                {
                    this.txt_ServiceURL.Text = config.WebServiceURL;
                }
                else
                {
                    MessageBox.Show("Configure is Nothing!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("File Not Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            SimplInqIDExchangeAppConfig config = new SimplInqIDExchangeAppConfig();

            config.WebServiceURL = this.txt_ServiceURL.Text.Trim();

            UserSettingController.EncryptionSerializeUserSetting(config, this.txt_FileName.Text.Trim(), AppConfigKey);
        }
    }
}