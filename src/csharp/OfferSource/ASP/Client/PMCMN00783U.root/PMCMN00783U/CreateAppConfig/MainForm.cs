using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;


namespace CreateAppConfig
{
	/// <summary>
	/// .NS 変更案内通知用アプリケーション構成ファイル作成ツール
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// 暗号化キー
		/// </summary>
		private static readonly string[] AppConfigKey = new string[] { typeof(PMCMN00783UA).Name, "AppConfigKey" };

		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 作成ボタンクリックイベントハンドラ
		/// </summary>
		/// <param name="sender">イベント発生オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void btn_Create_Click(object sender, EventArgs e)
		{
			ChangeInfoCheckAppConfig config = new ChangeInfoCheckAppConfig();

			config.WebServiceURL = this.txt_WebServiceURL.Text.Trim();
			config.CheckTimeSpan = Decimal.ToInt32(this.num_Span.Value);
			config.WebTopPageURL = this.txt_WebTopPageURL.Text.Trim();

			UserSettingController.EncryptionSerializeUserSetting(config, this.txt_FileName.Text.Trim(), AppConfigKey);
		}

		private void btn_Open_Click(object sender, EventArgs e)
		{
			if (UserSettingController.ExistUserSetting(this.txt_FileName.Text.Trim()))
			{
				ChangeInfoCheckAppConfig config;
				try
				{
					config = UserSettingController.DecryptionDeserializeUserSetting<ChangeInfoCheckAppConfig>(this.txt_FileName.Text.Trim(), AppConfigKey);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Fail to Decrypt and Deserialize!!\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (config != null)
				{
					this.txt_WebServiceURL.Text = config.WebServiceURL;
					this.num_Span.Value = config.CheckTimeSpan;
					this.txt_WebTopPageURL.Text = config.WebTopPageURL;
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

		private void txt_FileName_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				// DataFormats.FileDrop 形式の場合はコピーを受け入れる
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void txt_FileName_DragDrop(object sender, DragEventArgs e)
		{
			string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);

			foreach (string filepath in fileList)
			{
				if (File.GetAttributes(filepath) != FileAttributes.Directory)
				{
					this.txt_FileName.Text = filepath;
					break;
				}
			}
		}
	}
}