using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// SFTOK09998UE �̊T�v�̐����ł��B
	/// </summary>
	public class DetailViewForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool isInitialize = false;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
		public DetailViewForm()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailViewForm));
			this.webBrowser_DetailView = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// webBrowser_DetailView
			// 
			this.webBrowser_DetailView.AllowWebBrowserDrop = false;
			this.webBrowser_DetailView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser_DetailView.Location = new System.Drawing.Point(0, 0);
			this.webBrowser_DetailView.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser_DetailView.Name = "webBrowser_DetailView";
			this.webBrowser_DetailView.Size = new System.Drawing.Size(942, 671);
			this.webBrowser_DetailView.TabIndex = 1;
			// 
			// DetailViewForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.ClientSize = new System.Drawing.Size(942, 671);
			this.Controls.Add(this.webBrowser_DetailView);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DetailViewForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "���Ӑ�E�ԗ��ڍו\��";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DetailViewForm_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		internal WebBrowser webBrowser_DetailView;


		internal void DataView(string htmlString)
		{
			if (!this.isInitialize)
			{
				this.webBrowser_DetailView.Navigate("about:blank");
				this.isInitialize = true;
			}

			HtmlDocument htmlDocument = this.webBrowser_DetailView.Document.OpenNew(false);
			htmlDocument.Write(htmlString);
		}

		private void DetailViewForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
	}
}
