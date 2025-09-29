namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 設定画面
    /// </summary>
    partial class PMKHN09122UC
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
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09122UC));
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.uButton_TextOut = new Infragistics.Win.Misc.UltraButton();
            this.uButton_FileSelect = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_TextOutpuPath = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_FileName = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_FileFormat = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_TextOutpuPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_FileFormat)).BeginInit();
            this.SuspendLayout();
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Cancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Cancel.Location = new System.Drawing.Point(435, 121);
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size(116, 34);
            this.uButton_Cancel.TabIndex = 33;
            this.uButton_Cancel.Text = "キャンセル";
            this.uButton_Cancel.Click += new System.EventHandler(this.uButton_Cancel_Click);
            // 
            // uButton_TextOut
            // 
            this.uButton_TextOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_TextOut.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_TextOut.Location = new System.Drawing.Point(313, 121);
            this.uButton_TextOut.Name = "uButton_TextOut";
            this.uButton_TextOut.Size = new System.Drawing.Size(116, 34);
            this.uButton_TextOut.TabIndex = 32;
            this.uButton_TextOut.Text = "テキスト出力";
            this.uButton_TextOut.Click += new System.EventHandler(this.uButton_TextOut_Click);
            // 
            // uButton_FileSelect
            // 
            appearance41.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_FileSelect.Appearance = appearance41;
            this.uButton_FileSelect.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_FileSelect.Location = new System.Drawing.Point(516, 80);
            this.uButton_FileSelect.Name = "uButton_FileSelect";
            this.uButton_FileSelect.Size = new System.Drawing.Size(24, 24);
            this.uButton_FileSelect.TabIndex = 29;
            this.toolTip1.SetToolTip(this.uButton_FileSelect, "ファイル名");
            this.uButton_FileSelect.Click += new System.EventHandler(this.uButton_FileSelect_Click);
            // 
            // tEdit_TextOutpuPath
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_TextOutpuPath.ActiveAppearance = appearance5;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_TextOutpuPath.Appearance = appearance8;
            this.tEdit_TextOutpuPath.AutoSelect = true;
            this.tEdit_TextOutpuPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_TextOutpuPath.DataText = "";
            this.tEdit_TextOutpuPath.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_TextOutpuPath.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_TextOutpuPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_TextOutpuPath.Location = new System.Drawing.Point(150, 80);
            this.tEdit_TextOutpuPath.MaxLength = 254;
            this.tEdit_TextOutpuPath.Name = "tEdit_TextOutpuPath";
            this.tEdit_TextOutpuPath.Size = new System.Drawing.Size(353, 24);
            this.tEdit_TextOutpuPath.TabIndex = 28;
            // 
            // uLabel_FileName
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance6.TextVAlignAsString = "Middle";
            this.uLabel_FileName.Appearance = appearance6;
            this.uLabel_FileName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_FileName.Location = new System.Drawing.Point(33, 80);
            this.uLabel_FileName.Name = "uLabel_FileName";
            this.uLabel_FileName.Size = new System.Drawing.Size(87, 23);
            this.uLabel_FileName.TabIndex = 30;
            this.uLabel_FileName.Text = "ファイル名";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel4.Location = new System.Drawing.Point(118, 23);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(430, 3);
            this.ultraLabel4.TabIndex = 922;
            // 
            // ultraLabel1
            // 
            appearance7.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(18, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(98, 23);
            this.ultraLabel1.TabIndex = 923;
            this.ultraLabel1.Text = "出力ファイル";
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            // 
            // ultraLabel2
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance1;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(33, 46);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(118, 23);
            this.ultraLabel2.TabIndex = 925;
            this.ultraLabel2.Text = "ファイル形式";
            // 
            // tComboEditor_FileFormat
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_FileFormat.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_FileFormat.Appearance = appearance3;
            this.tComboEditor_FileFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_FileFormat.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_FileFormat.ItemAppearance = appearance4;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "CSV";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "TSV";
            this.tComboEditor_FileFormat.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_FileFormat.LimitToList = true;
            this.tComboEditor_FileFormat.Location = new System.Drawing.Point(150, 45);
            this.tComboEditor_FileFormat.Name = "tComboEditor_FileFormat";
            this.tComboEditor_FileFormat.Size = new System.Drawing.Size(119, 24);
            this.tComboEditor_FileFormat.TabIndex = 26;
            // 
            // PMKHN09122UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(577, 166);
            this.Controls.Add(this.tComboEditor_FileFormat);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.uButton_Cancel);
            this.Controls.Add(this.uButton_TextOut);
            this.Controls.Add(this.uButton_FileSelect);
            this.Controls.Add(this.tEdit_TextOutpuPath);
            this.Controls.Add(this.uLabel_FileName);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PMKHN09122UC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "テキスト出力確認";
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_TextOutpuPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_FileFormat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private Infragistics.Win.Misc.UltraButton uButton_TextOut;
        private Infragistics.Win.Misc.UltraButton uButton_FileSelect;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_TextOutpuPath;
        private Infragistics.Win.Misc.UltraLabel uLabel_FileName;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Broadleaf.Library.Windows.Forms.UiMemInput uiMemInput1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_FileFormat;
    }
}