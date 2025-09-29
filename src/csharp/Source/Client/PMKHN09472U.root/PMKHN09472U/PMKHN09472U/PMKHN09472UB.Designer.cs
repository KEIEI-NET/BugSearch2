namespace Broadleaf.Windows.Forms
{
    partial class PMKHN09472UB
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09472UB));
            this.uTabControl_Setup = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CellMove = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.uTabControl_Setup)).BeginInit();
            this.uTabControl_Setup.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CellMove)).BeginInit();
            this.SuspendLayout();
            // 
            // uTabControl_Setup
            // 
            this.uTabControl_Setup.Controls.Add(this.ultraTabSharedControlsPage1);
            this.uTabControl_Setup.Controls.Add(this.ultraTabPageControl2);
            this.uTabControl_Setup.Location = new System.Drawing.Point(10, 15);
            this.uTabControl_Setup.Name = "uTabControl_Setup";
            this.uTabControl_Setup.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.uTabControl_Setup.Size = new System.Drawing.Size(305, 125);
            this.uTabControl_Setup.TabIndex = 9;
            ultraTab3.Key = "DetailInputControl";
            ultraTab3.TabPage = this.ultraTabPageControl2;
            ultraTab3.Text = "セル移動制御";
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
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl2.Controls.Add(this.tComboEditor_CellMove);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(301, 98);
            // 
            // ultraLabel1
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance6;
            this.ultraLabel1.Location = new System.Drawing.Point(18, 36);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "セルの移動";
            // 
            // tComboEditor_CellMove
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.BorderColor = System.Drawing.Color.Black;
            this.tComboEditor_CellMove.ActiveAppearance = appearance4;
            this.tComboEditor_CellMove.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.tComboEditor_CellMove.ItemAppearance = appearance5;
            this.tComboEditor_CellMove.Location = new System.Drawing.Point(137, 36);
            this.tComboEditor_CellMove.Name = "tComboEditor_CellMove";
            this.tComboEditor_CellMove.Size = new System.Drawing.Size(73, 24);
            this.tComboEditor_CellMove.TabIndex = 0;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.Location = new System.Drawing.Point(219, 155);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(96, 24);
            this.Cancel_Button.TabIndex = 12;
            this.Cancel_Button.Text = "キャンセル";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.Location = new System.Drawing.Point(117, 155);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(96, 24);
            this.Ok_Button.TabIndex = 11;
            this.Ok_Button.Text = "ＯＫ";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // PMKHN09472UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(321, 187);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.uTabControl_Setup);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMKHN09472UB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ユーザー設定";
            this.Load += new System.EventHandler(this.PMKHN09472UB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uTabControl_Setup)).EndInit();
            this.uTabControl_Setup.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CellMove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl_Setup;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CellMove;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
    }
}