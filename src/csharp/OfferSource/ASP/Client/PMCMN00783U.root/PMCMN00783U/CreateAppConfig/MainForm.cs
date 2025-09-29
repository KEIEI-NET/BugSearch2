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
	/// .NS �ύX�ē��ʒm�p�A�v���P�[�V�����\���t�@�C���쐬�c�[��
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// �Í����L�[
		/// </summary>
		private static readonly string[] AppConfigKey = new string[] { typeof(PMCMN00783UA).Name, "AppConfigKey" };

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// �쐬�{�^���N���b�N�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
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
				// DataFormats.FileDrop �`���̏ꍇ�̓R�s�[���󂯓����
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