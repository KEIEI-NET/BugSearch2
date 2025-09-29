namespace Broadleaf.Windows.Forms
{
    partial class PMKHN08000UB
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08000UB));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape2 = new Broadleaf.Library.Windows.Forms.TShape();
            this.ultraLabel_Message = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_DelText = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton_Wait = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.timer_StartWait = new System.Windows.Forms.Timer(this.components);
            this.comb_FileImport = new System.Windows.Forms.ComboBox();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 475);
            this.ultraStatusBar1.Margin = new System.Windows.Forms.Padding(4);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(893, 33);
            this.ultraStatusBar1.TabIndex = 68;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.CatchMouse = true;
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // ultraLabel42
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance8.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance8;
            this.ultraLabel42.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel42.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.ultraLabel42.Location = new System.Drawing.Point(76, 55);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(345, 24);
            this.ultraLabel42.TabIndex = 1020;
            this.ultraLabel42.Text = "PMNSインポート待機条件";
            // 
            // tShape2
            // 
            this.tShape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tShape2.ForeColor = System.Drawing.Color.Blue;
            this.tShape2.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape2.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape2.Location = new System.Drawing.Point(76, 78);
            this.tShape2.Name = "tShape2";
            this.tShape2.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape2.Size = new System.Drawing.Size(734, 317);
            this.tShape2.TabIndex = 1073;
            this.tShape2.Text = "tShape2";
            // 
            // ultraLabel_Message
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel_Message.Appearance = appearance26;
            this.ultraLabel_Message.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Message.Location = new System.Drawing.Point(306, 211);
            this.ultraLabel_Message.Name = "ultraLabel_Message";
            this.ultraLabel_Message.Size = new System.Drawing.Size(229, 24);
            this.ultraLabel_Message.TabIndex = 1116;
            this.ultraLabel_Message.Text = "インポート処理待機中です。";
            // 
            // ultraLabel3
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance11;
            this.ultraLabel3.Location = new System.Drawing.Point(104, 95);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(129, 24);
            this.ultraLabel3.TabIndex = 1117;
            this.ultraLabel3.Text = "インポートファイル";
            // 
            // ultraLabel_DelText
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.ultraLabel_DelText.Appearance = appearance20;
            this.ultraLabel_DelText.Location = new System.Drawing.Point(104, 129);
            this.ultraLabel_DelText.Name = "ultraLabel_DelText";
            this.ultraLabel_DelText.Size = new System.Drawing.Size(562, 24);
            this.ultraLabel_DelText.TabIndex = 1120;
            this.ultraLabel_DelText.Text = "削除処理は画面指定条件に従います。";
            // 
            // ultraButton_Wait
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraButton_Wait.Appearance = appearance4;
            this.ultraButton_Wait.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraButton_Wait.Location = new System.Drawing.Point(484, 312);
            this.ultraButton_Wait.Name = "ultraButton_Wait";
            this.ultraButton_Wait.Size = new System.Drawing.Size(130, 26);
            this.ultraButton_Wait.TabIndex = 1121;
            this.ultraButton_Wait.Text = "待機(&T)";
            this.ultraButton_Wait.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton_Wait.Click += new System.EventHandler(this.ultraButton_Wait_Click);
            // 
            // ultraButton_Cancel
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraButton_Cancel.Appearance = appearance12;
            this.ultraButton_Cancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraButton_Cancel.Location = new System.Drawing.Point(630, 312);
            this.ultraButton_Cancel.Name = "ultraButton_Cancel";
            this.ultraButton_Cancel.Size = new System.Drawing.Size(130, 26);
            this.ultraButton_Cancel.TabIndex = 1122;
            this.ultraButton_Cancel.Text = "キャンセル(&C)";
            this.ultraButton_Cancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton_Cancel.Click += new System.EventHandler(this.ultraButton_Cancel_Click);
            // 
            // timer_StartWait
            // 
            this.timer_StartWait.Interval = 60000;
            this.timer_StartWait.Tick += new System.EventHandler(this.timer_StartWait_Tick);
            // 
            // comb_FileImport
            // 
            this.comb_FileImport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_FileImport.FormattingEnabled = true;
            this.comb_FileImport.Items.AddRange(new object[] {
            "0:NSインポート画面に従う",
            "1:エクスポート処理に従う"});
            this.comb_FileImport.Location = new System.Drawing.Point(239, 95);
            this.comb_FileImport.Name = "comb_FileImport";
            this.comb_FileImport.Size = new System.Drawing.Size(296, 23);
            this.comb_FileImport.TabIndex = 1123;
            this.comb_FileImport.SelectedIndexChanged += new System.EventHandler(this.comb_FileImport_SelectedIndexChanged);
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // PMKHN08000UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(893, 508);
            this.Controls.Add(this.comb_FileImport);
            this.Controls.Add(this.ultraButton_Cancel);
            this.Controls.Add(this.ultraLabel_DelText);
            this.Controls.Add(this.ultraButton_Wait);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel_Message);
            this.Controls.Add(this.tShape2);
            this.Controls.Add(this.ultraLabel42);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(684, 533);
            this.Name = "PMKHN08000UB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PMNSインポート待機";
            this.Load += new System.EventHandler(this.PmNsWait_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Broadleaf.Library.Windows.Forms.TShape tShape2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Message;
        private Infragistics.Win.Misc.UltraButton ultraButton_Wait;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_DelText;
        private Infragistics.Win.Misc.UltraButton ultraButton_Cancel;
        private System.Windows.Forms.Timer timer_StartWait;
        private System.Windows.Forms.ComboBox comb_FileImport;
        private Broadleaf.Library.Windows.Forms.TMemPos tMemPos1;

    }
}

