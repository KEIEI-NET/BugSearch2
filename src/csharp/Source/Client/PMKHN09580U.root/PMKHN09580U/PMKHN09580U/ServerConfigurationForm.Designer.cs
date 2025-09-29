namespace Broadleaf.Windows.Forms
{
    partial class ServerConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConfigurationForm));
            this.mnuConfiguration = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stsConfiguration = new System.Windows.Forms.StatusStrip();
            this.pnlConfiguration = new System.Windows.Forms.Panel();
            this.tabConfiguration = new System.Windows.Forms.TabControl();
            this.tabPageServerPrinterSetting = new System.Windows.Forms.TabPage();
            this.serverPrinterSettingViewer = new Broadleaf.Windows.Forms.ServerPrinterSettingView();
            this.mnuConfiguration.SuspendLayout();
            this.pnlConfiguration.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.tabPageServerPrinterSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuConfiguration
            // 
            this.mnuConfiguration.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.mnuConfiguration.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuConfiguration.Location = new System.Drawing.Point(0, 0);
            this.mnuConfiguration.Name = "mnuConfiguration";
            this.mnuConfiguration.Size = new System.Drawing.Size(892, 24);
            this.mnuConfiguration.TabIndex = 0;
            this.mnuConfiguration.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "終了(&X)";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // stsConfiguration
            // 
            this.stsConfiguration.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.stsConfiguration.Location = new System.Drawing.Point(0, 444);
            this.stsConfiguration.Name = "stsConfiguration";
            this.stsConfiguration.Size = new System.Drawing.Size(892, 22);
            this.stsConfiguration.TabIndex = 2;
            this.stsConfiguration.Text = "statusStrip1";
            // 
            // pnlConfiguration
            // 
            this.pnlConfiguration.Controls.Add(this.tabConfiguration);
            this.pnlConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfiguration.Location = new System.Drawing.Point(0, 24);
            this.pnlConfiguration.Name = "pnlConfiguration";
            this.pnlConfiguration.Size = new System.Drawing.Size(892, 420);
            this.pnlConfiguration.TabIndex = 3;
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.tabPageServerPrinterSetting);
            this.tabConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfiguration.Location = new System.Drawing.Point(0, 0);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.SelectedIndex = 0;
            this.tabConfiguration.Size = new System.Drawing.Size(892, 420);
            this.tabConfiguration.TabIndex = 1;
            // 
            // tabPageServerPrinterSetting
            // 
            this.tabPageServerPrinterSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageServerPrinterSetting.Controls.Add(this.serverPrinterSettingViewer);
            this.tabPageServerPrinterSetting.Location = new System.Drawing.Point(4, 21);
            this.tabPageServerPrinterSetting.Name = "tabPageServerPrinterSetting";
            this.tabPageServerPrinterSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServerPrinterSetting.Size = new System.Drawing.Size(884, 395);
            this.tabPageServerPrinterSetting.TabIndex = 0;
            this.tabPageServerPrinterSetting.Text = "プリンタ設定";
            this.tabPageServerPrinterSetting.UseVisualStyleBackColor = true;
            // 
            // serverPrinterSettingViewer
            // 
            this.serverPrinterSettingViewer.BackColor = System.Drawing.SystemColors.Control;
            this.serverPrinterSettingViewer.Caption = "プリンタ設定マスタ(サーバ用)";
            this.serverPrinterSettingViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverPrinterSettingViewer.Location = new System.Drawing.Point(3, 3);
            this.serverPrinterSettingViewer.Name = "serverPrinterSettingViewer";
            this.serverPrinterSettingViewer.Size = new System.Drawing.Size(878, 389);
            this.serverPrinterSettingViewer.TabIndex = 0;
            // 
            // ServerConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 466);
            this.Controls.Add(this.pnlConfiguration);
            this.Controls.Add(this.stsConfiguration);
            this.Controls.Add(this.mnuConfiguration);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuConfiguration;
            this.Name = "ServerConfigurationForm";
            this.Text = "マスタメンテナンス";
            this.mnuConfiguration.ResumeLayout(false);
            this.mnuConfiguration.PerformLayout();
            this.pnlConfiguration.ResumeLayout(false);
            this.tabConfiguration.ResumeLayout(false);
            this.tabPageServerPrinterSetting.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuConfiguration;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stsConfiguration;
        private System.Windows.Forms.Panel pnlConfiguration;
        private System.Windows.Forms.TabControl tabConfiguration;
        private System.Windows.Forms.TabPage tabPageServerPrinterSetting;
        private ServerPrinterSettingView serverPrinterSettingViewer;
    }
}

