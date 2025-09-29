namespace Broadleaf.Windows.Forms
{
    partial class PMSCM01104UC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM01104UC));
            this.Image1_PictureBox = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.pictLogo2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo2)).BeginInit();
            this.SuspendLayout();
            // 
            // Image1_PictureBox
            // 
            this.Image1_PictureBox.BorderShadowColor = System.Drawing.Color.Empty;
            this.Image1_PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image1_PictureBox.Image = ((object)(resources.GetObject("Image1_PictureBox.Image")));
            this.Image1_PictureBox.ImageTransparentColor = System.Drawing.Color.White;
            this.Image1_PictureBox.Location = new System.Drawing.Point(0, 0);
            this.Image1_PictureBox.Name = "Image1_PictureBox";
            this.Image1_PictureBox.Size = new System.Drawing.Size(253, 87);
            this.Image1_PictureBox.TabIndex = 2;
            // 
            // pictLogo2
            // 
            this.pictLogo2.Image = ((System.Drawing.Image)(resources.GetObject("pictLogo2.Image")));
            this.pictLogo2.Location = new System.Drawing.Point(6, 20);
            this.pictLogo2.Name = "pictLogo2";
            this.pictLogo2.Size = new System.Drawing.Size(47, 47);
            this.pictLogo2.TabIndex = 14;
            this.pictLogo2.TabStop = false;
            // 
            // PMSCM01104UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 87);
            this.ControlBox = false;
            this.Controls.Add(this.pictLogo2);
            this.Controls.Add(this.Image1_PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(259, 111);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(259, 111);
            this.Name = "PMSCM01104UC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "受信通知";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PMSCM01104UC_Load);
            this.Shown += new System.EventHandler(this.PMSCM01104UC_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraPictureBox Image1_PictureBox;
        private System.Windows.Forms.PictureBox pictLogo2;


    }
}