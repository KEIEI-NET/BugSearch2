namespace Broadleaf.Windows.Forms
{
	partial class PMSCM01206UA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM01206UA));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.SndAndRcvNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.close_Snd_Timer = new System.Windows.Forms.Timer(this.components);
            this.Snd_timer = new System.Windows.Forms.Timer(this.components);
            this.Rcv_timer = new System.Windows.Forms.Timer(this.components);
            this.patoLampImage = new System.Windows.Forms.PictureBox();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.sndErrMsg_Label = new Infragistics.Win.Misc.UltraLabel();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patoLampImage)).BeginInit();
            this.panel_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // SndAndRcvNotifyIcon
            // 
            this.SndAndRcvNotifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.SndAndRcvNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SndAndRcvNotifyIcon.Icon")));
            this.SndAndRcvNotifyIcon.Text = "PM7連携自動送受信バッチ";
            this.SndAndRcvNotifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(110, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.closeToolStripMenuItem.Text = "終了(&X)";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // close_Snd_Timer
            // 
            this.close_Snd_Timer.Interval = 30;
            this.close_Snd_Timer.Tick += new System.EventHandler(this.close_Snd_Timer_Tick);
            // 
            // Snd_timer
            // 
            this.Snd_timer.Enabled = true;
            this.Snd_timer.Interval = 8000;
            this.Snd_timer.Tick += new System.EventHandler(this.Snd_timer_Tick);
            // 
            // Rcv_timer
            // 
            this.Rcv_timer.Enabled = true;
            this.Rcv_timer.Interval = 10000;
            this.Rcv_timer.Tick += new System.EventHandler(this.Rcv_timer_Tick);
            // 
            // patoLampImage
            // 
            this.patoLampImage.Image = ((System.Drawing.Image)(resources.GetObject("patoLampImage.Image")));
            this.patoLampImage.InitialImage = null;
            this.patoLampImage.Location = new System.Drawing.Point(2, 7);
            this.patoLampImage.Name = "patoLampImage";
            this.patoLampImage.Size = new System.Drawing.Size(35, 35);
            this.patoLampImage.TabIndex = 15;
            this.patoLampImage.TabStop = false;
            // 
            // panel_Info
            // 
            this.panel_Info.BackColor = System.Drawing.Color.DimGray;
            this.panel_Info.Controls.Add(this.sndErrMsg_Label);
            this.panel_Info.Controls.Add(this.patoLampImage);
            this.panel_Info.Location = new System.Drawing.Point(-2, 0);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(386, 97);
            this.panel_Info.TabIndex = 18;
            // 
            // sndErrMsg_Label
            // 
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "ＭＳ ゴシック";
            appearance1.FontData.SizeInPoints = 9.75F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            this.sndErrMsg_Label.Appearance = appearance1;
            this.sndErrMsg_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.sndErrMsg_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sndErrMsg_Label.Location = new System.Drawing.Point(38, 7);
            this.sndErrMsg_Label.Name = "sndErrMsg_Label";
            this.sndErrMsg_Label.Size = new System.Drawing.Size(331, 80);
            this.sndErrMsg_Label.TabIndex = 19;
            // 
            // PMSCM01206UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(372, 104);
            this.Controls.Add(this.panel_Info);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMSCM01206UA";
            this.Opacity = 0.92;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "PM7連携自動送受信バッチ";
            this.Load += new System.EventHandler(this.PMSCM01206UA_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMSCM01206UA_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patoLampImage)).EndInit();
            this.panel_Info.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.NotifyIcon SndAndRcvNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Timer close_Snd_Timer;
        private System.Windows.Forms.Timer Snd_timer;
        private System.Windows.Forms.Timer Rcv_timer;
        private System.Windows.Forms.PictureBox patoLampImage;
        private System.Windows.Forms.Panel panel_Info;
        private Infragistics.Win.Misc.UltraLabel sndErrMsg_Label;
	}
}

