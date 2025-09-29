namespace Broadleaf.Windows.Forms
{
    partial class PMKOU04001UB
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMKOU04001UB ) );
            this.tLine_CatFile = new Broadleaf.Library.Windows.Forms.TLine();
            this.uLabel_FileNameTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_OK = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.uButton_FileSelect = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SettingFileName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.uLabel_PetternSelectTitle = new Infragistics.Win.Misc.UltraLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl( this.components );
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl( this.components );
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl( this.components );
            this.tComboEditor_PetternSelect = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.tLine_CatFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SettingFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PetternSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // tLine_CatFile
            // 
            this.tLine_CatFile.BackColor = System.Drawing.Color.Transparent;
            this.tLine_CatFile.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tLine_CatFile.Location = new System.Drawing.Point( 40, 25 );
            this.tLine_CatFile.Margin = new System.Windows.Forms.Padding( 4 );
            this.tLine_CatFile.Name = "tLine_CatFile";
            this.tLine_CatFile.Size = new System.Drawing.Size( 465, 12 );
            this.tLine_CatFile.TabIndex = 2;
            this.tLine_CatFile.Text = "tLine_CatFile1";
            // 
            // uLabel_FileNameTitle
            // 
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.uLabel_FileNameTitle.Appearance = appearance5;
            this.uLabel_FileNameTitle.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.uLabel_FileNameTitle.Location = new System.Drawing.Point( 13, 13 );
            this.uLabel_FileNameTitle.Margin = new System.Windows.Forms.Padding( 4 );
            this.uLabel_FileNameTitle.Name = "uLabel_FileNameTitle";
            this.uLabel_FileNameTitle.Size = new System.Drawing.Size( 115, 24 );
            this.uLabel_FileNameTitle.TabIndex = 1298;
            this.uLabel_FileNameTitle.Text = "出力ファイル";
            // 
            // uButton_OK
            // 
            this.uButton_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uButton_OK.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.uButton_OK.Location = new System.Drawing.Point( 280, 128 );
            this.uButton_OK.Margin = new System.Windows.Forms.Padding( 4 );
            this.uButton_OK.Name = "uButton_OK";
            this.uButton_OK.Size = new System.Drawing.Size( 113, 34 );
            this.uButton_OK.TabIndex = 3;
            this.uButton_OK.Text = "テキスト出力";
            this.uButton_OK.Click += new System.EventHandler( this.uButton_OK_Click );
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.uButton_Cancel.Location = new System.Drawing.Point( 401, 128 );
            this.uButton_Cancel.Margin = new System.Windows.Forms.Padding( 4 );
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size( 113, 34 );
            this.uButton_Cancel.TabIndex = 4;
            this.uButton_Cancel.Text = "キャンセル";
            this.uButton_Cancel.Click += new System.EventHandler( this.uButton_Cancel_Click );
            // 
            // uButton_FileSelect
            // 
            appearance85.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance85.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_FileSelect.Appearance = appearance85;
            this.uButton_FileSelect.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.uButton_FileSelect.Location = new System.Drawing.Point( 449, 37 );
            this.uButton_FileSelect.Margin = new System.Windows.Forms.Padding( 4 );
            this.uButton_FileSelect.Name = "uButton_FileSelect";
            this.uButton_FileSelect.Size = new System.Drawing.Size( 24, 24 );
            this.uButton_FileSelect.TabIndex = 1;
            this.uButton_FileSelect.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_FileSelect.Click += new System.EventHandler( this.uButton_FileSelect_Click );
            // 
            // tEdit_SettingFileName
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tEdit_SettingFileName.ActiveAppearance = appearance2;
            appearance7.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tEdit_SettingFileName.Appearance = appearance7;
            this.tEdit_SettingFileName.AutoSelect = true;
            this.tEdit_SettingFileName.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tEdit_SettingFileName.DataText = "";
            this.tEdit_SettingFileName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase( true, true, true, true, true, true, true, true, false );
            this.tEdit_SettingFileName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit( Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars( true, true, true, true, true, true, true ) );
            this.tEdit_SettingFileName.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.tEdit_SettingFileName.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SettingFileName.Location = new System.Drawing.Point( 175, 37 );
            this.tEdit_SettingFileName.Margin = new System.Windows.Forms.Padding( 4 );
            this.tEdit_SettingFileName.MaxLength = 256;
            this.tEdit_SettingFileName.Name = "tEdit_SettingFileName";
            this.tEdit_SettingFileName.Size = new System.Drawing.Size( 266, 24 );
            this.tEdit_SettingFileName.TabIndex = 0;
            // 
            // ultraLabel1
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance4;
            this.ultraLabel1.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.ultraLabel1.Location = new System.Drawing.Point( 35, 37 );
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding( 4 );
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size( 115, 24 );
            this.ultraLabel1.TabIndex = 1303;
            this.ultraLabel1.Text = "ファイル名";
            // 
            // ultraLabel2
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance6;
            this.ultraLabel2.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.ultraLabel2.Location = new System.Drawing.Point( 13, 65 );
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding( 4 );
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size( 115, 24 );
            this.ultraLabel2.TabIndex = 1304;
            this.ultraLabel2.Text = "出力パターン";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tLine1.Location = new System.Drawing.Point( 40, 77 );
            this.tLine1.Margin = new System.Windows.Forms.Padding( 4 );
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size( 465, 12 );
            this.tLine1.TabIndex = 1305;
            this.tLine1.Text = "tLine_CatFile1";
            // 
            // uLabel_PetternSelectTitle
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance3.TextVAlignAsString = "Middle";
            this.uLabel_PetternSelectTitle.Appearance = appearance3;
            this.uLabel_PetternSelectTitle.Location = new System.Drawing.Point( 35, 91 );
            this.uLabel_PetternSelectTitle.Name = "uLabel_PetternSelectTitle";
            this.uLabel_PetternSelectTitle.Size = new System.Drawing.Size( 134, 23 );
            this.uLabel_PetternSelectTitle.TabIndex = 1307;
            this.uLabel_PetternSelectTitle.Text = "出力パターン選択";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tArrowKeyControl_ChangeFocus );
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.AlwaysEvent = true;
            this.tArrowKeyControl.OwnerForm = this;
            this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tArrowKeyControl_ChangeFocus );
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler( this.tArrowKeyControl_ChangeFocus );
            // 
            // tComboEditor_PetternSelect
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tComboEditor_PetternSelect.ActiveAppearance = appearance33;
            appearance34.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tComboEditor_PetternSelect.Appearance = appearance34;
            this.tComboEditor_PetternSelect.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))) );
            this.tComboEditor_PetternSelect.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_PetternSelect.ImeMode = System.Windows.Forms.ImeMode.Close;
            appearance40.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))) );
            this.tComboEditor_PetternSelect.ItemAppearance = appearance40;
            this.tComboEditor_PetternSelect.Location = new System.Drawing.Point( 175, 90 );
            this.tComboEditor_PetternSelect.Name = "tComboEditor_PetternSelect";
            this.tComboEditor_PetternSelect.Size = new System.Drawing.Size( 312, 24 );
            this.tComboEditor_PetternSelect.TabIndex = 2;
            //add by 汪権来 #35640(#25の件) 2013/06/25--------<<<<<<
            this.tComboEditor_PetternSelect.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_PetternSelect_SelectionChangeCommitted);
            this.tComboEditor_PetternSelect.ValueChanged += new System.EventHandler(this.tComboEditor_PetternSelect_ValueChanged);
            //add by 汪権来 #35640(#25の件) 2013/06/25-------->>>>>>
            // 
            // PMKOU04001UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))) );
            this.ClientSize = new System.Drawing.Size( 549, 175 );
            this.Controls.Add( this.tComboEditor_PetternSelect );
            this.Controls.Add( this.uLabel_PetternSelectTitle );
            this.Controls.Add( this.ultraLabel2 );
            this.Controls.Add( this.tLine1 );
            this.Controls.Add( this.tEdit_SettingFileName );
            this.Controls.Add( this.ultraLabel1 );
            this.Controls.Add( this.uButton_FileSelect );
            this.Controls.Add( this.uButton_Cancel );
            this.Controls.Add( this.uButton_OK );
            this.Controls.Add( this.uLabel_FileNameTitle );
            this.Controls.Add( this.tLine_CatFile );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.Name = "PMKOU04001UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "テキスト出力確認";
            this.Load += new System.EventHandler( this.PMKOU04001UB_Load );
            ((System.ComponentModel.ISupportInitialize)(this.tLine_CatFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SettingFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PetternSelect)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private Broadleaf.Library.Windows.Forms.TLine tLine_CatFile;
        private Infragistics.Win.Misc.UltraLabel uLabel_FileNameTitle;
        private Infragistics.Win.Misc.UltraButton uButton_OK;
        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private Infragistics.Win.Misc.UltraButton uButton_FileSelect;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SettingFileName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TLine tLine1;
        private Infragistics.Win.Misc.UltraLabel uLabel_PetternSelectTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_PetternSelect;
    }
}