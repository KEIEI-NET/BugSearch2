using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	internal class FloatingWindowF : System.Windows.Forms.Form
    {
        private PictureBox pictureBox_Floating;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public FloatingWindowF()
		{
			InitializeComponent();			
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloatingWindowF));
            this.pictureBox_Floating = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Floating)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Floating
            // 
            this.pictureBox_Floating.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Floating.Image")));
            this.pictureBox_Floating.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Floating.Name = "pictureBox_Floating";
            this.pictureBox_Floating.Size = new System.Drawing.Size(396, 297);
            this.pictureBox_Floating.TabIndex = 0;
            this.pictureBox_Floating.TabStop = false;
            // 
            // FloatingWindowF
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 297);
            this.Controls.Add(this.pictureBox_Floating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FloatingWindowF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�N�����ł��B���΂炭���҂����������B";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Floating)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FloatingWindowF());
		}

	}
}
