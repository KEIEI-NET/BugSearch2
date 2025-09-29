namespace Broadleaf.Windows.Forms
{
    partial class MAZAI04110UC
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
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI04110UC));
            this.tComboEditor_PetternSelect = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_PetternSelectTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_CatFile = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_CatPatternTitle = new Infragistics.Win.Misc.UltraLabel();
            this.tLine_CatPattern = new Broadleaf.Library.Windows.Forms.TLine();
            this.uButton_FileSelect = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SettingFileName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_FileNameTitle = new Infragistics.Win.Misc.UltraLabel();
            this.tLine_CatFile = new Broadleaf.Library.Windows.Forms.TLine();
            this.uButton_OK = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PetternSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine_CatPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SettingFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine_CatFile)).BeginInit();
            this.SuspendLayout();
            // 
            // tComboEditor_PetternSelect
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PetternSelect.ActiveAppearance = appearance33;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PetternSelect.Appearance = appearance34;
            this.tComboEditor_PetternSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PetternSelect.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PetternSelect.ItemAppearance = appearance40;
            this.tComboEditor_PetternSelect.Location = new System.Drawing.Point(167, 91);
            this.tComboEditor_PetternSelect.Name = "tComboEditor_PetternSelect";
            this.tComboEditor_PetternSelect.Size = new System.Drawing.Size(312, 24);
            this.tComboEditor_PetternSelect.TabIndex = 2;
            this.tComboEditor_PetternSelect.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_PetternSelect_SelectionChangeCommitted);
            this.tComboEditor_PetternSelect.ValueChanged += new System.EventHandler(this.tComboEditor_PetternSelect_ValueChanged);
            // 
            // uLabel_PetternSelectTitle
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.uLabel_PetternSelectTitle.Appearance = appearance3;
            this.uLabel_PetternSelectTitle.Location = new System.Drawing.Point(30, 93);
            this.uLabel_PetternSelectTitle.Name = "uLabel_PetternSelectTitle";
            this.uLabel_PetternSelectTitle.Size = new System.Drawing.Size(134, 23);
            this.uLabel_PetternSelectTitle.TabIndex = 1302;
            this.uLabel_PetternSelectTitle.Text = "出力パターン選択";
            // 
            // uLabel_CatFile
            // 
            this.uLabel_CatFile.Location = new System.Drawing.Point(16, 21);
            this.uLabel_CatFile.Name = "uLabel_CatFile";
            this.uLabel_CatFile.Size = new System.Drawing.Size(100, 21);
            this.uLabel_CatFile.TabIndex = 0;
            this.uLabel_CatFile.Text = "出力ファイル";
            // 
            // uLabel_CatPatternTitle
            // 
            appearance22.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            this.uLabel_CatPatternTitle.Appearance = appearance22;
            this.uLabel_CatPatternTitle.Location = new System.Drawing.Point(16, 71);
            this.uLabel_CatPatternTitle.Name = "uLabel_CatPatternTitle";
            this.uLabel_CatPatternTitle.Size = new System.Drawing.Size(100, 21);
            this.uLabel_CatPatternTitle.TabIndex = 1301;
            this.uLabel_CatPatternTitle.Text = "出力パターン";
            // 
            // tLine_CatPattern
            // 
            this.tLine_CatPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tLine_CatPattern.BackColor = System.Drawing.Color.Transparent;
            this.tLine_CatPattern.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tLine_CatPattern.Location = new System.Drawing.Point(99, 78);
            this.tLine_CatPattern.Name = "tLine_CatPattern";
            this.tLine_CatPattern.Size = new System.Drawing.Size(402, 10);
            this.tLine_CatPattern.TabIndex = 1300;
            this.tLine_CatPattern.Text = "tLine_CatFile1";
            // 
            // uButton_FileSelect
            // 
            appearance41.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_FileSelect.Appearance = appearance41;
            this.uButton_FileSelect.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_FileSelect.Location = new System.Drawing.Point(444, 39);
            this.uButton_FileSelect.Name = "uButton_FileSelect";
            this.uButton_FileSelect.Size = new System.Drawing.Size(24, 24);
            this.uButton_FileSelect.TabIndex = 1;
            this.uButton_FileSelect.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_FileSelect.Click += new System.EventHandler(this.uButton_FileSelect_Click);
            // 
            // tEdit_SettingFileName
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SettingFileName.ActiveAppearance = appearance2;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SettingFileName.Appearance = appearance1;
            this.tEdit_SettingFileName.AutoSelect = true;
            this.tEdit_SettingFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SettingFileName.DataText = "";
            this.tEdit_SettingFileName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SettingFileName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SettingFileName.Location = new System.Drawing.Point(167, 39);
            this.tEdit_SettingFileName.MaxLength = 256;
            this.tEdit_SettingFileName.Name = "tEdit_SettingFileName";
            this.tEdit_SettingFileName.Size = new System.Drawing.Size( 268, 24 );
            this.tEdit_SettingFileName.TabIndex = 0;
            // 
            // uLabel_FileNameTitle
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.uLabel_FileNameTitle.Appearance = appearance4;
            this.uLabel_FileNameTitle.Location = new System.Drawing.Point(30, 41);
            this.uLabel_FileNameTitle.Name = "uLabel_FileNameTitle";
            this.uLabel_FileNameTitle.Size = new System.Drawing.Size(86, 23);
            this.uLabel_FileNameTitle.TabIndex = 1297;
            this.uLabel_FileNameTitle.Text = "ファイル名";
            // 
            // tLine_CatFile
            // 
            this.tLine_CatFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tLine_CatFile.BackColor = System.Drawing.Color.Transparent;
            this.tLine_CatFile.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tLine_CatFile.Location = new System.Drawing.Point(99, 28);
            this.tLine_CatFile.Name = "tLine_CatFile";
            this.tLine_CatFile.Size = new System.Drawing.Size(402, 10);
            this.tLine_CatFile.TabIndex = 1;
            this.tLine_CatFile.Text = "tLine_CatFile1";
            // 
            // uButton_OK
            // 
            this.uButton_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_OK.Location = new System.Drawing.Point(277, 131);
            this.uButton_OK.Name = "uButton_OK";
            this.uButton_OK.Size = new System.Drawing.Size(116, 34);
            this.uButton_OK.TabIndex = 991;
            this.uButton_OK.Text = "テキスト出力";
            this.uButton_OK.Click += new System.EventHandler(this.uButton_OK_Click);
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Cancel.Location = new System.Drawing.Point(399, 131);
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size(116, 34);
            this.uButton_Cancel.TabIndex = 992;
            this.uButton_Cancel.Text = "キャンセル";
            this.uButton_Cancel.Click += new System.EventHandler(this.uButton_Cancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
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
            // MAZAI04110UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(547, 174);
            this.Controls.Add(this.tComboEditor_PetternSelect);
            this.Controls.Add(this.uButton_Cancel);
            this.Controls.Add(this.uLabel_PetternSelectTitle);
            this.Controls.Add(this.uButton_OK);
            this.Controls.Add(this.uLabel_CatFile);
            this.Controls.Add(this.uLabel_CatPatternTitle);
            this.Controls.Add(this.tLine_CatPattern);
            this.Controls.Add(this.tLine_CatFile);
            this.Controls.Add(this.uButton_FileSelect);
            this.Controls.Add(this.uLabel_FileNameTitle);
            this.Controls.Add(this.tEdit_SettingFileName);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MAZAI04110UC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "テキスト出力確認";
            this.Load += new System.EventHandler(this.MAZAI04110UC_Load);
            this.Shown += new System.EventHandler(this.MAZAI04110UB_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PetternSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine_CatPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SettingFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine_CatFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TLine tLine_CatFile;
        private Infragistics.Win.Misc.UltraLabel uLabel_CatFile;
        private Infragistics.Win.Misc.UltraLabel uLabel_FileNameTitle;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SettingFileName;
        private Infragistics.Win.Misc.UltraButton uButton_FileSelect;
        private Broadleaf.Library.Windows.Forms.TLine tLine_CatPattern;
        private Infragistics.Win.Misc.UltraLabel uLabel_CatPatternTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_PetternSelectTitle;
        private Infragistics.Win.Misc.UltraButton uButton_OK;
        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_PetternSelect;
    }
}