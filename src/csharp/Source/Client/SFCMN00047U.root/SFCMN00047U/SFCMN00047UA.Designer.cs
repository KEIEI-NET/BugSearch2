namespace Broadleaf.Windows.Forms
{
    partial class SFCMN00047UAF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN00047UAF));
            this.TTraynotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMsg = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TTraynotifyIcon
            // 
            this.TTraynotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TTraynotifyIcon.Icon")));
            this.TTraynotifyIcon.Text = "notifyIcon1";
            this.TTraynotifyIcon.Visible = true;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShow});
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(98, 26);
            // 
            // mnuShow
            // 
            this.mnuShow.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mnuShow.ForeColor = System.Drawing.Color.Black;
            this.mnuShow.Image = ((System.Drawing.Image)(resources.GetObject("mnuShow.Image")));
            this.mnuShow.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(97, 22);
            this.mnuShow.Text = "表示";
            this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(12, 9);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 1;
            // 
            // SFCMN00047UAF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(340, 113);
            this.Controls.Add(this.lblMsg);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SFCMN00047UAF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NSログイン制御（Partsman）";
            this.Load += new System.EventHandler(this.SFCMN00047UAF_Load);
            this.Activated += new System.EventHandler(this.SFCMN00047UAF_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SFCMN00047UAF_FormClosing);
            this.Resize += new System.EventHandler(this.SFCMN00047UAF_Resize);
            this.mnuMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TTraynotifyIcon;
        private System.Windows.Forms.ContextMenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuShow;
        private System.Windows.Forms.Label lblMsg;
    }
}

