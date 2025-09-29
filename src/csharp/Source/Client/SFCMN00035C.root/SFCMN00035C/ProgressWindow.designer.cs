namespace Broadleaf.Library.Net.Mail
{
    partial class ProgressWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressWindow));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.pnlBar = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnFunc = new System.Windows.Forms.Button();
            this.lstImage = new System.Windows.Forms.ImageList(this.components);
            this.barProgress = new System.Windows.Forms.ProgressBar();
            this.pnlMain.SuspendLayout();
            this.pnlBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.lstStatus);
            this.pnlMain.Location = new System.Drawing.Point(2, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(589, 160);
            this.pnlMain.TabIndex = 3;
            // 
            // lstStatus
            // 
            this.lstStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.HorizontalScrollbar = true;
            this.lstStatus.ItemHeight = 12;
            this.lstStatus.Location = new System.Drawing.Point(0, 0);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(589, 160);
            this.lstStatus.TabIndex = 2;
            this.lstStatus.TabStop = false;
            // 
            // pnlBar
            // 
            this.pnlBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBar.Controls.Add(this.lblProgress);
            this.pnlBar.Controls.Add(this.btnFunc);
            this.pnlBar.Controls.Add(this.barProgress);
            this.pnlBar.Location = new System.Drawing.Point(2, 166);
            this.pnlBar.Name = "pnlBar";
            this.pnlBar.Size = new System.Drawing.Size(589, 61);
            this.pnlBar.TabIndex = 4;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblProgress.Location = new System.Drawing.Point(277, 38);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(55, 13);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "(          )";
            // 
            // btnFunc
            // 
            this.btnFunc.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFunc.ImageIndex = 0;
            this.btnFunc.ImageList = this.lstImage;
            this.btnFunc.Location = new System.Drawing.Point(30, 32);
            this.btnFunc.Name = "btnFunc";
            this.btnFunc.Size = new System.Drawing.Size(98, 24);
            this.btnFunc.TabIndex = 3;
            this.btnFunc.Text = "戻る(&C)";
            this.btnFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFunc.UseVisualStyleBackColor = true;
            this.btnFunc.Visible = false;
            this.btnFunc.Click += new System.EventHandler(this.btnFunc_Click);
            // 
            // lstImage
            // 
            this.lstImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lstImage.ImageStream")));
            this.lstImage.TransparentColor = System.Drawing.Color.Aqua;
            this.lstImage.Images.SetKeyName(0, "17.BEFORE.bmp");
            // 
            // barProgress
            // 
            this.barProgress.Location = new System.Drawing.Point(30, 7);
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(530, 19);
            this.barProgress.TabIndex = 1;
            // 
            // ProgressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(592, 226);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBar);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "進捗状況：";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.ProgressWindow_Resize);
            this.Shown += new System.EventHandler(this.ProgressWindow_Shown);
            this.pnlMain.ResumeLayout(false);
            this.pnlBar.ResumeLayout(false);
            this.pnlBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListBox lstStatus;
        private System.Windows.Forms.Panel pnlBar;
        private System.Windows.Forms.Button btnFunc;
        private System.Windows.Forms.ProgressBar barProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ImageList lstImage;

    }
}