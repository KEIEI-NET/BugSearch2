namespace Broadleaf.Windows.Forms
{
    partial class PMHND09210UC
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMHND09210UC));
            this.uLabel_CatFile = new Infragistics.Win.Misc.UltraLabel();
            this.tLine_CatFile = new Broadleaf.Library.Windows.Forms.TLine();
            this.uLabel_FileNameTitle = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_TextFileName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.uButton_OK = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uLabel_FileFullName = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tLine_CatFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_TextFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // uLabel_CatFile
            // 
            this.uLabel_CatFile.Location = new System.Drawing.Point(11, 21);
            this.uLabel_CatFile.Name = "uLabel_CatFile";
            this.uLabel_CatFile.Size = new System.Drawing.Size(103, 21);
            this.uLabel_CatFile.TabIndex = 1303;
            this.uLabel_CatFile.Text = "出力ファイル";
            // 
            // tLine_CatFile
            // 
            this.tLine_CatFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tLine_CatFile.BackColor = System.Drawing.Color.Transparent;
            this.tLine_CatFile.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tLine_CatFile.Location = new System.Drawing.Point(119, 28);
            this.tLine_CatFile.Name = "tLine_CatFile";
            this.tLine_CatFile.Size = new System.Drawing.Size(409, 10);
            this.tLine_CatFile.TabIndex = 1305;
            this.tLine_CatFile.Text = "tLine_CatFile1";
            // 
            // uLabel_FileNameTitle
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.uLabel_FileNameTitle.Appearance = appearance3;
            this.uLabel_FileNameTitle.Location = new System.Drawing.Point(27, 41);
            this.uLabel_FileNameTitle.Name = "uLabel_FileNameTitle";
            this.uLabel_FileNameTitle.Size = new System.Drawing.Size(86, 22);
            this.uLabel_FileNameTitle.TabIndex = 1306;
            this.uLabel_FileNameTitle.Text = "ファイル名";
            // 
            // tEdit_TextFileName
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_TextFileName.ActiveAppearance = appearance2;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_TextFileName.Appearance = appearance1;
            this.tEdit_TextFileName.AutoSelect = true;
            this.tEdit_TextFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_TextFileName.DataText = "";
            this.tEdit_TextFileName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_TextFileName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_TextFileName.Location = new System.Drawing.Point(121, 39);
            this.tEdit_TextFileName.MaxLength = 256;
            this.tEdit_TextFileName.Name = "tEdit_TextFileName";
            this.tEdit_TextFileName.Size = new System.Drawing.Size(314, 24);
            this.tEdit_TextFileName.TabIndex = 1;
            this.tEdit_TextFileName.ValueChanged += new System.EventHandler(this.tEdit_TextFileName_ValueChanged);
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Cancel.Location = new System.Drawing.Point(413, 99);
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size(117, 34);
            this.uButton_Cancel.TabIndex = 3;
            this.uButton_Cancel.Text = "キャンセル";
            this.uButton_Cancel.Click += new System.EventHandler(this.uButton_Cancel_Click);
            // 
            // uButton_OK
            // 
            this.uButton_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_OK.Location = new System.Drawing.Point(291, 99);
            this.uButton_OK.Name = "uButton_OK";
            this.uButton_OK.Size = new System.Drawing.Size(117, 34);
            this.uButton_OK.TabIndex = 2;
            this.uButton_OK.Text = "テキスト出力";
            this.uButton_OK.Click += new System.EventHandler(this.uButton_OK_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.AlwaysEvent = true;
            this.tArrowKeyControl.OwnerForm = this;
            this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // uLabel_FileFullName
            // 
            this.uLabel_FileFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Top";
            this.uLabel_FileFullName.Appearance = appearance4;
            this.uLabel_FileFullName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_FileFullName.Location = new System.Drawing.Point(121, 69);
            this.uLabel_FileFullName.Name = "uLabel_FileFullName";
            this.uLabel_FileFullName.Size = new System.Drawing.Size(409, 22);
            this.uLabel_FileFullName.TabIndex = 1307;
            this.uLabel_FileFullName.WrapText = false;
            // 
            // PMHND09210UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(536, 136);
            this.Controls.Add(this.uLabel_FileFullName);
            this.Controls.Add(this.uButton_Cancel);
            this.Controls.Add(this.uButton_OK);
            this.Controls.Add(this.uLabel_CatFile);
            this.Controls.Add(this.tLine_CatFile);
            this.Controls.Add(this.uLabel_FileNameTitle);
            this.Controls.Add(this.tEdit_TextFileName);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "PMHND09210UC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "テキスト出力確認";
            this.Load += new System.EventHandler(this.PMHND09210UC_Load);
            this.Shown += new System.EventHandler(this.PMHND09210UC_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tLine_CatFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_TextFileName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel uLabel_CatFile;
        private Broadleaf.Library.Windows.Forms.TLine tLine_CatFile;
        private Infragistics.Win.Misc.UltraLabel uLabel_FileNameTitle;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_TextFileName;
        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private Infragistics.Win.Misc.UltraButton uButton_OK;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
        private Infragistics.Win.Misc.UltraLabel uLabel_FileFullName;
    }
}