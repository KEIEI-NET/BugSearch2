namespace Broadleaf.Windows.Forms
{
    partial class PMKYO01101UD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKYO01101UD));
            this.ultraButton_Detail = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.ultraPictureBox_Warning = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton_Continue = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // ultraButton_Detail
            // 
            this.ultraButton_Detail.Location = new System.Drawing.Point(57, 117);
            this.ultraButton_Detail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraButton_Detail.Name = "ultraButton_Detail";
            this.ultraButton_Detail.Size = new System.Drawing.Size(125, 34);
            this.ultraButton_Detail.TabIndex = 1;
            this.ultraButton_Detail.Text = "エラー詳細";
            this.ultraButton_Detail.Click += new System.EventHandler(this.ultraButton_Detail_Click);
            // 
            // ultraButton_Close
            // 
            this.ultraButton_Close.Location = new System.Drawing.Point(354, 117);
            this.ultraButton_Close.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraButton_Close.Name = "ultraButton_Close";
            this.ultraButton_Close.Size = new System.Drawing.Size(125, 34);
            this.ultraButton_Close.TabIndex = 3;
            this.ultraButton_Close.Text = "終了";
            this.ultraButton_Close.Click += new System.EventHandler(this.ultraButton_Close_Click);
            // 
            // ultraPictureBox_Warning
            // 
            this.ultraPictureBox_Warning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraPictureBox_Warning.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox_Warning.Location = new System.Drawing.Point(39, 110);
            this.ultraPictureBox_Warning.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraPictureBox_Warning.Name = "ultraPictureBox_Warning";
            this.ultraPictureBox_Warning.Size = new System.Drawing.Size(74, 2);
            this.ultraPictureBox_Warning.TabIndex = 3;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(28, 55);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(435, 27);
            this.ultraLabel2.TabIndex = 6;
            this.ultraLabel2.Text = "エラー詳細を確認して下さい。";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(28, 22);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(519, 23);
            this.ultraLabel1.TabIndex = 5;
            this.ultraLabel1.Text = "前回請求締日・前回月次更新日以前のデータを含むデータを受信しました。";
            // 
            // ultraButton_Continue
            // 
            this.ultraButton_Continue.Location = new System.Drawing.Point(206, 117);
            this.ultraButton_Continue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ultraButton_Continue.Name = "ultraButton_Continue";
            this.ultraButton_Continue.Size = new System.Drawing.Size(125, 34);
            this.ultraButton_Continue.TabIndex = 2;
            this.ultraButton_Continue.Text = "続行";
            this.ultraButton_Continue.Click += new System.EventHandler(this.ultraButton_Continue_Click);
            // 
            // PMKYO01101UD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(563, 165);
            this.Controls.Add(this.ultraButton_Continue);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraPictureBox_Warning);
            this.Controls.Add(this.ultraButton_Close);
            this.Controls.Add(this.ultraButton_Detail);
            this.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMKYO01101UD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注意";
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ultraButton_Detail;
        private Infragistics.Win.Misc.UltraButton ultraButton_Close;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox_Warning;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton ultraButton_Continue;
    }
}