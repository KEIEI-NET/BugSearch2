namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
	partial class PMSCM01101UC
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM01101UC));
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPlease = new System.Windows.Forms.Label();
            this.pictureWait = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.sendTimer = new System.Windows.Forms.Timer(this.components);
            this.nowSendingNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ( (System.ComponentModel.ISupportInitialize)( this.pictureWait ) ).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(251, 22);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "データを送信しています・・・";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlease
            // 
            this.lblPlease.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlease.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.lblPlease.Location = new System.Drawing.Point(0, 22);
            this.lblPlease.Name = "lblPlease";
            this.lblPlease.Size = new System.Drawing.Size(251, 22);
            this.lblPlease.TabIndex = 1;
            this.lblPlease.Text = "しばらくお待ちください。";
            this.lblPlease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureWait
            // 
            this.pictureWait.Image = ( (System.Drawing.Image)( resources.GetObject("pictureWait.Image") ) );
            this.pictureWait.Location = new System.Drawing.Point(17, 50);
            this.pictureWait.Name = "pictureWait";
            this.pictureWait.Size = new System.Drawing.Size(220, 16);
            this.pictureWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureWait.TabIndex = 13;
            this.pictureWait.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.btnCancel.Location = new System.Drawing.Point(150, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "閉じる";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // sendTimer
            // 
            this.sendTimer.Tick += new System.EventHandler(this.sendTimer_Tick);
            // 
            // nowSendingNotifyIcon
            // 
            this.nowSendingNotifyIcon.Icon = ( (System.Drawing.Icon)( resources.GetObject("nowSendingNotifyIcon.Icon") ) );
            this.nowSendingNotifyIcon.Text = "回答データを送信中...";
            this.nowSendingNotifyIcon.Visible = true;
            this.nowSendingNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nowSendingNotifyIcon_MouseDoubleClick);
            // 
            // PMSCM01101UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(251, 72);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureWait);
            this.Controls.Add(this.lblPlease);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMSCM01101UC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "回答送信処理";
            this.Load += new System.EventHandler(this.PMSCM01101UC_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMSCM01101UC_FormClosing);
            ( (System.ComponentModel.ISupportInitialize)( this.pictureWait ) ).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblPlease;
		private System.Windows.Forms.PictureBox pictureWait;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Timer sendTimer;
        private System.Windows.Forms.NotifyIcon nowSendingNotifyIcon;
	}
}