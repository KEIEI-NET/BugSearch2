namespace Broadleaf.Windows.Forms
{
    partial class PMKYO01910UA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKYO01910UA));
            this.ultraButton_Detail = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPictureBox_Warning = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.close_Timer = new System.Windows.Forms.Timer(this.components);
            this.check_timer = new System.Windows.Forms.Timer(this.components);
            this.patoLampNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraButton_Detail
            // 
            this.ultraButton_Detail.Location = new System.Drawing.Point(206, 117);
            this.ultraButton_Detail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraButton_Detail.Name = "ultraButton_Detail";
            this.ultraButton_Detail.Size = new System.Drawing.Size(125, 34);
            this.ultraButton_Detail.TabIndex = 1;
            this.ultraButton_Detail.Text = "エラー詳細";
            this.ultraButton_Detail.Click += new System.EventHandler(this.UltraButton_Detail_Click);
            // 
            // ultraButton_Close
            // 
            this.ultraButton_Close.Location = new System.Drawing.Point(352, 117);
            this.ultraButton_Close.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraButton_Close.Name = "ultraButton_Close";
            this.ultraButton_Close.Size = new System.Drawing.Size(125, 34);
            this.ultraButton_Close.TabIndex = 2;
            this.ultraButton_Close.Text = "終了";
            this.ultraButton_Close.Click += new System.EventHandler(this.UltraButton_Close_Click);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(28, 23);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(435, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "前回請求締日・前回月次更新日以前のデータを";
            // 
            // ultraPictureBox_Warning
            // 
            this.ultraPictureBox_Warning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraPictureBox_Warning.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox_Warning.Location = new System.Drawing.Point(39, 110);
            this.ultraPictureBox_Warning.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraPictureBox_Warning.Name = "ultraPictureBox_Warning";
            this.ultraPictureBox_Warning.Size = new System.Drawing.Size(0, 2);
            this.ultraPictureBox_Warning.TabIndex = 3;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(28, 83);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(435, 27);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "エラー詳細を確認して下さい。";
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
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // close_Timer
            // 
            this.close_Timer.Interval = 30;
            this.close_Timer.Tick += new System.EventHandler(this.Close_Timer_Tick);
            // 
            // check_timer
            // 
            this.check_timer.Interval = 60000;
            this.check_timer.Tick += new System.EventHandler(this.Check_timer_Tick);
            // 
            // patoLampNotifyIcon
            // 
            this.patoLampNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.patoLampNotifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.patoLampNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("patoLampNotifyIcon.Icon")));
            this.patoLampNotifyIcon.Text = "自動受信エラー情報はありません";
            this.patoLampNotifyIcon.Visible = true;
            this.patoLampNotifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PatoLampNotifyIcon_MouseMove);
            this.patoLampNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PatoLampNotifyIcon_MouseClick);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(28, 53);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(435, 23);
            this.ultraLabel3.TabIndex = 2;
            this.ultraLabel3.Text = "含むデータを受信しました。";
            // 
            // PMKYO01910UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(489, 165);
            this.Controls.Add(this.ultraPictureBox_Warning);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraButton_Close);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraButton_Detail);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMKYO01910UA";
            this.Opacity = 0.92;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "注意";
            this.Load += new System.EventHandler(this.PMKYO01910UA_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKYO01910U_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ultraButton_Detail;
        private Infragistics.Win.Misc.UltraButton ultraButton_Close;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox_Warning;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Timer close_Timer;
        private System.Windows.Forms.Timer check_timer;
        private System.Windows.Forms.NotifyIcon patoLampNotifyIcon;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
    }
}