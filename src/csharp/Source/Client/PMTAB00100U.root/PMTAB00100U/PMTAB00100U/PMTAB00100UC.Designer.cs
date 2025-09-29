namespace Broadleaf.Windows.Forms
{
    partial class PMTAB00100UC
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
            this.checkEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.setButton = new Infragistics.Win.Misc.UltraButton();
            this.closeButton = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // checkEditor
            // 
            this.checkEditor.Location = new System.Drawing.Point(31, 33);
            this.checkEditor.Name = "checkEditor";
            this.checkEditor.Size = new System.Drawing.Size(198, 20);
            this.checkEditor.TabIndex = 0;
            this.checkEditor.Text = "売上登録通知を表示する";
            // 
            // setButton
            // 
            this.setButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.setButton.Location = new System.Drawing.Point(134, 77);
            this.setButton.Margin = new System.Windows.Forms.Padding(1);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 24);
            this.setButton.TabIndex = 1;
            this.setButton.Text = "設定(&S)";
            this.setButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.closeButton.Location = new System.Drawing.Point(213, 77);
            this.closeButton.Margin = new System.Windows.Forms.Padding(1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 24);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "閉じる(&X)";
            this.closeButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // PMTAB00100UF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(292, 110);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.checkEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PMTAB00100UF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "動作設定";
            this.Shown += new System.EventHandler(this.PMTAB00100UF_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkEditor;
        private Infragistics.Win.Misc.UltraButton setButton;
        private Infragistics.Win.Misc.UltraButton closeButton;
    }
}