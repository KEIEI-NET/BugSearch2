namespace Broadleaf.Windows.Forms
{
    partial class PMKAU04004UC
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.Main_ProgressBar = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // Main_ProgressBar
            // 
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.Main_ProgressBar.FillAppearance = appearance4;
            this.Main_ProgressBar.Location = new System.Drawing.Point(32, 31);
            this.Main_ProgressBar.Name = "Main_ProgressBar";
            this.Main_ProgressBar.Size = new System.Drawing.Size(360, 18);
            this.Main_ProgressBar.TabIndex = 4;
            this.Main_ProgressBar.Text = "[Formatted]";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(166, 66);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(92, 24);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "キャンセル";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // PMKAU04004UC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(424, 98);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Main_ProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMKAU04004UC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抽出中";
            this.Load += new System.EventHandler(this.PMKAU04004UC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar Main_ProgressBar;
        internal Infragistics.Win.Misc.UltraButton Cancel_Button;
    }
}