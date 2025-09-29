namespace Broadleaf.Windows.Forms
{
    partial class PMSCM04110UB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM04110UB));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.check_timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.E0001_Label = new Infragistics.Win.Misc.UltraLabel();
            this.E0002_Label = new Infragistics.Win.Misc.UltraLabel();
            this.E0003_Label = new Infragistics.Win.Misc.UltraLabel();
            this.E0004_Label = new Infragistics.Win.Misc.UltraLabel();
            this.show_timer = new System.Windows.Forms.Timer(this.components);
            this.close_button = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(12, 102);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(465, 32);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "同期状態は、右下タスクトレイに表示される　　をクリックして頂く事で確認できます。";
            // 
            // check_timer
            // 
            this.check_timer.Tick += new System.EventHandler(this.Check_timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "同期状況確認";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.closeToolStripMenuItem.Text = "終了(&X)";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // E0001_Label
            // 
            this.E0001_Label.Location = new System.Drawing.Point(12, 26);
            this.E0001_Label.Name = "E0001_Label";
            this.E0001_Label.Size = new System.Drawing.Size(465, 66);
            this.E0001_Label.TabIndex = 2;
            this.E0001_Label.Text = "データ同期中に自動回答サーバーに接続できませんでした。    インターネット回線がご利用かご確認下さい。                 ご利用可能な場合はお手数" +
                "おかけしますが、弊社コールセンターまでお問合せ頂けます様お願いします。";
            // 
            // E0002_Label
            // 
            this.E0002_Label.Location = new System.Drawing.Point(12, 26);
            this.E0002_Label.Name = "E0002_Label";
            this.E0002_Label.Size = new System.Drawing.Size(465, 66);
            this.E0002_Label.TabIndex = 3;
            this.E0002_Label.Text = "データ同期中に自動回答サーバーでエラーが発生しました。          お手数おかけしますが、弊社コールセンターまでお問合せ頂けます様お願いします。";
            // 
            // E0003_Label
            // 
            this.E0003_Label.Location = new System.Drawing.Point(12, 26);
            this.E0003_Label.Name = "E0003_Label";
            this.E0003_Label.Size = new System.Drawing.Size(465, 66);
            this.E0003_Label.TabIndex = 4;
            this.E0003_Label.Text = "自動回答サーバーへのデータ同期に時間が掛かっています。          ただ今大変混み合っておりますので、今暫くお待ち頂けます様お願いします。 ";
            // 
            // E0004_Label
            // 
            this.E0004_Label.Location = new System.Drawing.Point(12, 26);
            this.E0004_Label.Name = "E0004_Label";
            this.E0004_Label.Size = new System.Drawing.Size(465, 66);
            this.E0004_Label.TabIndex = 5;
            this.E0004_Label.Text = "データ同期準備中にエラーが発生しました。                   お手数おかけしますが、弊社コールセンターまでお問合せ頂けます様お願いします。 ";
            // 
            // show_timer
            // 
            this.show_timer.Tick += new System.EventHandler(this.show_timer_Tick);
            // 
            // close_button
            // 
            appearance1.BorderColor = System.Drawing.Color.White;
            appearance1.ForeColor = System.Drawing.Color.Red;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.close_button.Appearance = appearance1;
            this.close_button.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.close_button.Font = new System.Drawing.Font("ＭＳ ゴシック", 16F, System.Drawing.FontStyle.Bold);
            appearance5.BackColor = System.Drawing.Color.DimGray;
            appearance5.BorderColor2 = System.Drawing.Color.LightGray;
            this.close_button.HotTrackAppearance = appearance5;
            this.close_button.Location = new System.Drawing.Point(457, 5);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(26, 26);
            this.close_button.TabIndex = 8;
            this.close_button.Text = "×";
            this.close_button.MouseLeave += new System.EventHandler(this.close_button_MouseLeave);
            this.close_button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.close_button_MouseMove);
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // ultraLabel3
            // 
            appearance2.BorderColor = System.Drawing.Color.Black;
            this.ultraLabel3.Appearance = appearance2;
            this.ultraLabel3.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel3.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(489, 157);
            this.ultraLabel3.TabIndex = 9;
            // 
            // ultraPictureBox1
            // 
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
            this.ultraPictureBox1.Location = new System.Drawing.Point(325, 98);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(26, 23);
            this.ultraPictureBox1.TabIndex = 11;
            // 
            // PMSCM04110UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(489, 157);
            this.Controls.Add(this.ultraPictureBox1);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.E0001_Label);
            this.Controls.Add(this.E0003_Label);
            this.Controls.Add(this.E0002_Label);
            this.Controls.Add(this.E0004_Label);
            this.Controls.Add(this.ultraLabel3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMSCM04110UB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "同期状況確認";
            this.Load += new System.EventHandler(this.PMSCM04110UB_Load);
            this.MouseLeave += new System.EventHandler(this.PMSCM04110UB_MouseLeave);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMSCM04110UB_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private System.Windows.Forms.Timer check_timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private Infragistics.Win.Misc.UltraLabel E0001_Label;
        private Infragistics.Win.Misc.UltraLabel E0002_Label;
        private Infragistics.Win.Misc.UltraLabel E0003_Label;
        private Infragistics.Win.Misc.UltraLabel E0004_Label;
        private System.Windows.Forms.Timer show_timer;
        private Infragistics.Win.Misc.UltraLabel close_button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
    }
}