namespace Broadleaf.Windows.Forms
{
    partial class PMKHN00900UB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN00900UB));
            this.probar = new System.Windows.Forms.ProgressBar();
            this.laCap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // probar
            // 
            this.probar.Location = new System.Drawing.Point(18, 37);
            this.probar.Name = "probar";
            this.probar.Size = new System.Drawing.Size(320, 21);
            this.probar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.probar.TabIndex = 0;
            // 
            // laCap
            // 
            this.laCap.AutoSize = true;
            this.laCap.Location = new System.Drawing.Point(16, 14);
            this.laCap.Name = "laCap";
            this.laCap.Size = new System.Drawing.Size(34, 12);
            this.laCap.TabIndex = 1;
            this.laCap.Text = "laCap";
            // 
            // PMKHN00900UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 74);
            this.Controls.Add(this.laCap);
            this.Controls.Add(this.probar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN00900UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProcessBar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProBar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar probar;
        private System.Windows.Forms.Label laCap;

    }
}