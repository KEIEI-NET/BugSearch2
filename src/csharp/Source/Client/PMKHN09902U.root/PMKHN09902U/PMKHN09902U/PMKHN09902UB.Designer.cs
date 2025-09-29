namespace Broadleaf.Windows.Forms
{
    partial class PMKHN09902UB
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.tempUltraGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.tempUltraGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tempUltraGrid
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.tempUltraGrid.DisplayLayout.Appearance = appearance1;
            this.tempUltraGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tempUltraGrid.Location = new System.Drawing.Point(0, 0);
            this.tempUltraGrid.Name = "tempUltraGrid";
            this.tempUltraGrid.Size = new System.Drawing.Size(880, 437);
            this.tempUltraGrid.TabIndex = 308;
            this.tempUltraGrid.Text = "ultraGrid1";
            // 
            // PMKHN09902UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(880, 437);
            this.Controls.Add(this.tempUltraGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PMKHN09902UB";
            this.Text = "PMKHN09902UB";
            ((System.ComponentModel.ISupportInitialize)(this.tempUltraGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        /// <summary>
        /// Excel出力用グリッド
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid tempUltraGrid;

    }
}