namespace Broadleaf.Windows.Forms
{
    partial class SFMIT01297UA
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFMIT01297UA));
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			this.Panel_Top = new System.Windows.Forms.Panel();
			this.Panel_Header = new System.Windows.Forms.Panel();
			this.Label_Header = new Infragistics.Win.Misc.UltraLabel();
			this.Label_Close = new Infragistics.Win.Misc.UltraLabel();
			this.Panel_NoticeItem = new System.Windows.Forms.Panel();
			this.Notification_CheckBox = new System.Windows.Forms.CheckBox();
			this.lblLink = new System.Windows.Forms.Label();
			this.Label_Contents = new Infragistics.Win.Misc.UltraLabel();
			this.Label_Title = new Infragistics.Win.Misc.UltraLabel();
			this.Label_Footer = new Infragistics.Win.Misc.UltraLabel();
			this.Panel_Main = new System.Windows.Forms.Panel();
			this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
			this.timerOpacity = new System.Windows.Forms.Timer(this.components);
			this.Setting = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.timerBeforeShow = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.timerHide = new System.Windows.Forms.Timer(this.components);
			this.lblLink2 = new System.Windows.Forms.Label();
			this.Panel_Top.SuspendLayout();
			this.Panel_Header.SuspendLayout();
			this.Panel_NoticeItem.SuspendLayout();
			this.Panel_Main.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel_Top
			// 
			this.Panel_Top.BackColor = System.Drawing.Color.Transparent;
			this.Panel_Top.Controls.Add(this.Panel_Header);
			this.Panel_Top.Controls.Add(this.Label_Close);
			this.Panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel_Top.Location = new System.Drawing.Point(0, 0);
			this.Panel_Top.Name = "Panel_Top";
			this.Panel_Top.Size = new System.Drawing.Size(536, 20);
			this.Panel_Top.TabIndex = 0;
			// 
			// Panel_Header
			// 
			this.Panel_Header.Controls.Add(this.Label_Header);
			this.Panel_Header.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel_Header.Location = new System.Drawing.Point(0, 0);
			this.Panel_Header.Name = "Panel_Header";
			this.Panel_Header.Size = new System.Drawing.Size(516, 20);
			this.Panel_Header.TabIndex = 4;
			// 
			// Label_Header
			// 
			appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(156)))), ((int)(((byte)(183)))));
			appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.Label_Header.Appearance = appearance1;
			this.Label_Header.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Raised;
			this.Label_Header.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label_Header.Location = new System.Drawing.Point(0, 0);
			this.Label_Header.Name = "Label_Header";
			this.Label_Header.Size = new System.Drawing.Size(516, 20);
			this.Label_Header.TabIndex = 4;
			this.Label_Header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Header_MouseMove);
			this.Label_Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
			// 
			// Label_Close
			// 
			appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Label_Close.Appearance = appearance2;
			this.Label_Close.BackColor = System.Drawing.Color.Transparent;
			this.Label_Close.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
			this.Label_Close.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Label_Close.Dock = System.Windows.Forms.DockStyle.Right;
			this.Label_Close.Location = new System.Drawing.Point(516, 0);
			this.Label_Close.Name = "Label_Close";
			this.Label_Close.Size = new System.Drawing.Size(20, 20);
			this.Label_Close.TabIndex = 6;
			this.Label_Close.Text = "Ｘ";
			this.Label_Close.Click += new System.EventHandler(this.Label_Close_Click);
			// 
			// Panel_NoticeItem
			// 
			this.Panel_NoticeItem.AutoScroll = true;
			this.Panel_NoticeItem.BackColor = System.Drawing.Color.Transparent;
			this.Panel_NoticeItem.Controls.Add(this.lblLink2);
			this.Panel_NoticeItem.Controls.Add(this.Notification_CheckBox);
			this.Panel_NoticeItem.Controls.Add(this.lblLink);
			this.Panel_NoticeItem.Controls.Add(this.Label_Contents);
			this.Panel_NoticeItem.Controls.Add(this.Label_Title);
			this.Panel_NoticeItem.Controls.Add(this.Label_Footer);
			this.Panel_NoticeItem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel_NoticeItem.Location = new System.Drawing.Point(0, 20);
			this.Panel_NoticeItem.Name = "Panel_NoticeItem";
			this.Panel_NoticeItem.Size = new System.Drawing.Size(536, 273);
			this.Panel_NoticeItem.TabIndex = 3;
			// 
			// Notification_CheckBox
			// 
			this.Notification_CheckBox.AutoSize = true;
			this.Notification_CheckBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Notification_CheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Notification_CheckBox.Location = new System.Drawing.Point(320, 249);
			this.Notification_CheckBox.Name = "Notification_CheckBox";
			this.Notification_CheckBox.Size = new System.Drawing.Size(204, 16);
			this.Notification_CheckBox.TabIndex = 4;
			this.Notification_CheckBox.Text = "今後このメッセージは表示しない";
			this.Notification_CheckBox.UseVisualStyleBackColor = true;
			// 
			// lblLink
			// 
			this.lblLink.AutoSize = true;
			this.lblLink.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblLink.Font = new System.Drawing.Font("ＭＳ ゴシック", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblLink.ForeColor = System.Drawing.Color.Blue;
			this.lblLink.Location = new System.Drawing.Point(84, 218);
			this.lblLink.Name = "lblLink";
			this.lblLink.Size = new System.Drawing.Size(65, 17);
			this.lblLink.TabIndex = 9;
			this.lblLink.Text = "こちら";
			this.lblLink.Click += new System.EventHandler(this.lblLink_Click);
			// 
			// Label_Contents
			// 
			this.Label_Contents.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
			appearance3.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance3.TextVAlign = Infragistics.Win.VAlign.Top;
			this.Label_Contents.Appearance = appearance3;
			this.Label_Contents.BackColor = System.Drawing.Color.Transparent;
			this.Label_Contents.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Label_Contents.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(221)))));
			this.Label_Contents.Location = new System.Drawing.Point(21, 38);
			this.Label_Contents.Name = "Label_Contents";
			this.Label_Contents.Size = new System.Drawing.Size(503, 167);
			this.Label_Contents.TabIndex = 2;
			this.Label_Contents.Text = resources.GetString("Label_Contents.Text");
			// 
			// Label_Title
			// 
			this.Label_Title.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
			appearance4.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Label_Title.Appearance = appearance4;
			this.Label_Title.BackColor = System.Drawing.Color.Transparent;
			this.Label_Title.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label_Title.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Label_Title.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(221)))));
			this.Label_Title.Location = new System.Drawing.Point(12, 12);
			this.Label_Title.Name = "Label_Title";
			this.Label_Title.Size = new System.Drawing.Size(256, 20);
			this.Label_Title.TabIndex = 1;
			this.Label_Title.Text = "【重要なお知らせ】";
			// 
			// Label_Footer
			// 
			this.Label_Footer.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
			appearance5.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance5.TextVAlign = Infragistics.Win.VAlign.Top;
			this.Label_Footer.Appearance = appearance5;
			this.Label_Footer.BackColor = System.Drawing.Color.Transparent;
			this.Label_Footer.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Label_Footer.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(221)))));
			this.Label_Footer.Location = new System.Drawing.Point(21, 220);
			this.Label_Footer.Name = "Label_Footer";
			this.Label_Footer.Size = new System.Drawing.Size(245, 15);
			this.Label_Footer.TabIndex = 3;
			this.Label_Footer.Text = "詳しくは 　　　 をご覧ください";
			// 
			// Panel_Main
			// 
			this.Panel_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Panel_Main.Controls.Add(this.Panel_NoticeItem);
			this.Panel_Main.Controls.Add(this.Panel_Top);
			this.Panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel_Main.Location = new System.Drawing.Point(0, 0);
			this.Panel_Main.Name = "Panel_Main";
			this.Panel_Main.Size = new System.Drawing.Size(538, 295);
			this.Panel_Main.TabIndex = 5;
			this.Panel_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Main_Paint);
			// 
			// tMemPos1
			// 
			this.tMemPos1.OwnerForm = this;
			this.tMemPos1.SetType = Broadleaf.Library.Windows.Forms.TMemPos.emSetType.Position;
			// 
			// timerOpacity
			// 
			this.timerOpacity.Interval = 30;
			this.timerOpacity.Tick += new System.EventHandler(this.timerOpacity_Tick);
			// 
			// Setting
			// 
			this.Setting.Name = "Setting";
			this.Setting.Size = new System.Drawing.Size(32, 19);
			// 
			// notifyIcon
			// 
			this.notifyIcon.Text = "電帳DX通知";
			this.notifyIcon.Visible = true;
			// 
			// timerBeforeShow
			// 
			this.timerBeforeShow.Tick += new System.EventHandler(this.timerBeforeShow_Tick);
			// 
			// lblLink2
			// 
			this.lblLink2.AutoSize = true;
			this.lblLink2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblLink2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblLink2.ForeColor = System.Drawing.Color.Blue;
			this.lblLink2.Location = new System.Drawing.Point(21, 250);
			this.lblLink2.Name = "lblLink2";
			this.lblLink2.Size = new System.Drawing.Size(137, 12);
			this.lblLink2.TabIndex = 10;
			this.lblLink2.Text = "情報の外部送信について";
			this.lblLink2.Click += new System.EventHandler(this.lblLink2_Click);
			// 
			// SFMIT01297UA
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(538, 295);
			this.ControlBox = false;
			this.Controls.Add(this.Panel_Main);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "SFMIT01297UA";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "電帳DX通知";
			this.Shown += new System.EventHandler(this.SFMIT01297UA_Shown);
			this.Panel_Top.ResumeLayout(false);
			this.Panel_Header.ResumeLayout(false);
			this.Panel_NoticeItem.ResumeLayout(false);
			this.Panel_NoticeItem.PerformLayout();
			this.Panel_Main.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Top;
        private Infragistics.Win.Misc.UltraLabel Label_Close;
        private Infragistics.Win.Misc.UltraLabel Label_Header;
        private System.Windows.Forms.Panel Panel_NoticeItem;
		private Infragistics.Win.Misc.UltraLabel Label_Title;
        private System.Windows.Forms.Panel Panel_Main;
        private System.Windows.Forms.Panel Panel_Header;
        private Broadleaf.Library.Windows.Forms.TMemPos tMemPos1;
        private System.Windows.Forms.Timer timerOpacity;
		private System.Windows.Forms.ToolStripMenuItem Setting;
        private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Timer timerBeforeShow;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerHide;
		private Infragistics.Win.Misc.UltraLabel Label_Contents;
		private System.Windows.Forms.Label lblLink;
		private Infragistics.Win.Misc.UltraLabel Label_Footer;
		private System.Windows.Forms.CheckBox Notification_CheckBox;
		private System.Windows.Forms.Label lblLink2;
    }
}

