namespace Broadleaf.Windows.Forms
{
    partial class PMZAI09201UC
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
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMZAI09201UC));
            this.tNedit_MaxCount = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.OK_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uTabControl_Setup = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MaxCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uTabControl_Setup)).BeginInit();
            this.uTabControl_Setup.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tNedit_MaxCount
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance25.TextHAlignAsString = "Right";
            this.tNedit_MaxCount.ActiveAppearance = appearance25;
            appearance26.TextHAlignAsString = "Right";
            this.tNedit_MaxCount.Appearance = appearance26;
            this.tNedit_MaxCount.AutoSelect = true;
            this.tNedit_MaxCount.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MaxCount.DataText = "11111";
            this.tNedit_MaxCount.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MaxCount.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MaxCount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_MaxCount.Location = new System.Drawing.Point(142, 32);
            this.tNedit_MaxCount.MaxLength = 5;
            this.tNedit_MaxCount.Name = "tNedit_MaxCount";
            this.tNedit_MaxCount.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_MaxCount.Size = new System.Drawing.Size(52, 24);
            this.tNedit_MaxCount.TabIndex = 1;
            this.tNedit_MaxCount.Text = "11111";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.Cancel_Button.Location = new System.Drawing.Point(219, 155);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(96, 24);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "キャンセル";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.OK_Button.Location = new System.Drawing.Point(117, 155);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(96, 24);
            this.OK_Button.TabIndex = 2;
            this.OK_Button.Text = "ＯＫ";
            this.OK_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraLabel1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Location = new System.Drawing.Point(8, 36);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 4;
            this.ultraLabel1.Text = "最大出力件数";
            // 
            // ultraLabel2
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance2;
            this.ultraLabel2.Location = new System.Drawing.Point(200, 36);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(36, 23);
            this.ultraLabel2.TabIndex = 4;
            this.ultraLabel2.Text = "件";
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // uTabControl_Setup
            // 
            this.uTabControl_Setup.Controls.Add(this.ultraTabSharedControlsPage1);
            this.uTabControl_Setup.Controls.Add(this.ultraTabPageControl2);
            this.uTabControl_Setup.Location = new System.Drawing.Point(10, 15);
            this.uTabControl_Setup.Name = "uTabControl_Setup";
            this.uTabControl_Setup.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.uTabControl_Setup.Size = new System.Drawing.Size(305, 125);
            this.uTabControl_Setup.TabIndex = 0;
            ultraTab3.Key = "DetailInputControl";
            ultraTab3.TabPage = this.ultraTabPageControl2;
            ultraTab3.Text = "明細設定";
            this.uTabControl_Setup.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3});
            this.uTabControl_Setup.TabStop = false;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(301, 98);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl2.Controls.Add(this.tNedit_MaxCount);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(301, 98);
            // 
            // PMZAI09201UC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(323, 189);
            this.Controls.Add(this.uTabControl_Setup);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMZAI09201UC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ユーザー設定";
            this.Load += new System.EventHandler(this.PMZAI09201UC_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMZAI09201UC_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MaxCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uTabControl_Setup)).EndInit();
            this.uTabControl_Setup.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TNedit tNedit_MaxCount;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton OK_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl_Setup;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
    }
}