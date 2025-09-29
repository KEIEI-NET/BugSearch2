namespace Broadleaf.Windows.Forms
{
    partial class PMCMN00900UA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMCMN00900UA));
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.contimueBtn = new Infragistics.Win.Misc.UltraButton();
            this.closeBtn = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(16, 15);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(538, 118);
            this.ultraLabel1.TabIndex = 0;
            // 
            // contimueBtn
            // 
            this.contimueBtn.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.contimueBtn.Location = new System.Drawing.Point(205, 135);
            this.contimueBtn.Margin = new System.Windows.Forms.Padding(4);
            this.contimueBtn.Name = "contimueBtn";
            this.contimueBtn.Size = new System.Drawing.Size(125, 34);
            this.contimueBtn.TabIndex = 1;
            this.contimueBtn.Text = "続行";
            this.contimueBtn.Click += new System.EventHandler(this.contimueBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.closeBtn.Location = new System.Drawing.Point(353, 135);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(125, 34);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "自動処理終了";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // PMCMN00900UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(567, 193);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.contimueBtn);
            this.Controls.Add(this.ultraLabel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMCMN00900UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "エラー発生 ‐ ＜送信処理＞";
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton contimueBtn;
        private Infragistics.Win.Misc.UltraButton closeBtn;
    }
}