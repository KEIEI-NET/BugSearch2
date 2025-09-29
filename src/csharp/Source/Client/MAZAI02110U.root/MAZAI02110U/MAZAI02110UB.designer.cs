namespace Broadleaf.Windows.Forms
{
    partial class MAZAI02110UB
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02110UB));
            this.uLabel_CatFile = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_FileSelect = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SettingFileName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_OK = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SettingFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // uLabel_CatFile
            // 
            this.uLabel_CatFile.Location = new System.Drawing.Point(3, 59);
            this.uLabel_CatFile.Name = "uLabel_CatFile";
            this.uLabel_CatFile.Size = new System.Drawing.Size(114, 21);
            this.uLabel_CatFile.TabIndex = 0;
            this.uLabel_CatFile.Text = "出力ファイル名";
            // 
            // uButton_FileSelect
            // 
            appearance41.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_FileSelect.Appearance = appearance41;
            this.uButton_FileSelect.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_FileSelect.Location = new System.Drawing.Point(511, 55);
            this.uButton_FileSelect.Name = "uButton_FileSelect";
            this.uButton_FileSelect.Size = new System.Drawing.Size(25, 25);
            this.uButton_FileSelect.TabIndex = 2;
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
            this.tEdit_SettingFileName.AutoSize = false;
            this.tEdit_SettingFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SettingFileName.DataText = "";
            this.tEdit_SettingFileName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SettingFileName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 254, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SettingFileName.Location = new System.Drawing.Point(119, 56);
            this.tEdit_SettingFileName.MaxLength = 254;
            this.tEdit_SettingFileName.Name = "tEdit_SettingFileName";
            this.tEdit_SettingFileName.Size = new System.Drawing.Size(385, 24);
            this.tEdit_SettingFileName.TabIndex = 1;
            // 
            // uButton_OK
            // 
            this.uButton_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_OK.Location = new System.Drawing.Point(268, 118);
            this.uButton_OK.Name = "uButton_OK";
            this.uButton_OK.Size = new System.Drawing.Size(116, 34);
            this.uButton_OK.TabIndex = 3;
            this.uButton_OK.Text = "テキスト出力";
            this.uButton_OK.Click += new System.EventHandler(this.uButton_OK_Click);
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Cancel.Location = new System.Drawing.Point(388, 118);
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size(116, 34);
            this.uButton_Cancel.TabIndex = 4;
            this.uButton_Cancel.Text = "キャンセル";
            this.uButton_Cancel.Click += new System.EventHandler(this.uButton_Cancel_Click);
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
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            // 
            // MAZAI02110UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(547, 163);
            this.Controls.Add(this.uButton_Cancel);
            this.Controls.Add(this.uButton_OK);
            this.Controls.Add(this.uLabel_CatFile);
            this.Controls.Add(this.uButton_FileSelect);
            this.Controls.Add(this.tEdit_SettingFileName);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MAZAI02110UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "テキスト出力設定";
            this.Load += new System.EventHandler(this.PMKAU04004UB_Load);
            this.Shown += new System.EventHandler(this.PMKAU04004UA_Show);
            this.VisibleChanged += new System.EventHandler(this.MAZAI02110UB_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SettingFileName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel uLabel_CatFile;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SettingFileName;
        private Infragistics.Win.Misc.UltraButton uButton_FileSelect;
        private Infragistics.Win.Misc.UltraButton uButton_OK;
        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
        private Broadleaf.Library.Windows.Forms.UiMemInput uiMemInput1;
    }
}