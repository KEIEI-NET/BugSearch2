namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 設定画面
    /// </summary>
    partial class PMMAX02010UD
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMMAX02010UD));
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tEdit_Password = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_LoginID = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_Save = new Infragistics.Win.Misc.UltraButton();
            this.uButton_FileSelect = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_ChecklistOutpuPath = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_FileName = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_LoginID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_ChecklistOutpuPath)).BeginInit();
            this.SuspendLayout();
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Cancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Cancel.Location = new System.Drawing.Point(282, 187);
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size(116, 34);
            this.uButton_Cancel.TabIndex = 33;
            this.uButton_Cancel.Text = "キャンセル";
            this.uButton_Cancel.Click += new System.EventHandler(this.uButton_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tEdit_Password);
            this.groupBox1.Controls.Add(this.tEdit_LoginID);
            this.groupBox1.Controls.Add(this.ultraLabel2);
            this.groupBox1.Controls.Add(this.ultraLabel1);
            this.groupBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(45, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 115);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "部品MAX認証情報";
            // 
            // tEdit_Password
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Password.ActiveAppearance = appearance2;
            this.tEdit_Password.AutoSelect = true;
            this.tEdit_Password.DataText = "";
            this.tEdit_Password.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Password.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_Password.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Password.Location = new System.Drawing.Point(155, 74);
            this.tEdit_Password.MaxLength = 256;
            this.tEdit_Password.Name = "tEdit_Password";
            this.tEdit_Password.PasswordChar = '*';
            this.tEdit_Password.Size = new System.Drawing.Size(258, 24);
            this.tEdit_Password.TabIndex = 31;
            // 
            // tEdit_LoginID
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_LoginID.ActiveAppearance = appearance1;
            this.tEdit_LoginID.AutoSelect = true;
            this.tEdit_LoginID.DataText = "";
            this.tEdit_LoginID.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_LoginID.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_LoginID.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_LoginID.Location = new System.Drawing.Point(155, 32);
            this.tEdit_LoginID.MaxLength = 256;
            this.tEdit_LoginID.Name = "tEdit_LoginID";
            this.tEdit_LoginID.Size = new System.Drawing.Size(258, 24);
            this.tEdit_LoginID.TabIndex = 30;
            // 
            // ultraLabel2
            // 
            appearance5.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance5;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(16, 74);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(133, 23);
            this.ultraLabel2.TabIndex = 25;
            this.ultraLabel2.Text = "パスワード";
            // 
            // ultraLabel1
            // 
            appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance6;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(133, 23);
            this.ultraLabel1.TabIndex = 25;
            this.ultraLabel1.Text = "ログインID";
            // 
            // uButton_Save
            // 
            this.uButton_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Save.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Save.Location = new System.Drawing.Point(160, 187);
            this.uButton_Save.Name = "uButton_Save";
            this.uButton_Save.Size = new System.Drawing.Size(116, 34);
            this.uButton_Save.TabIndex = 32;
            this.uButton_Save.Text = "保存";
            this.uButton_Save.Click += new System.EventHandler(this.uButton_Save_Click);
            // 
            // uButton_FileSelect
            // 
            appearance41.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_FileSelect.Appearance = appearance41;
            this.uButton_FileSelect.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_FileSelect.Location = new System.Drawing.Point(481, 26);
            this.uButton_FileSelect.Name = "uButton_FileSelect";
            this.uButton_FileSelect.Size = new System.Drawing.Size(24, 24);
            this.uButton_FileSelect.TabIndex = 29;
            this.uButton_FileSelect.Click += new System.EventHandler(this.uButton_FileSelect_Click);
            // 
            // tEdit_ChecklistOutpuPath
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_ChecklistOutpuPath.ActiveAppearance = appearance3;
            this.tEdit_ChecklistOutpuPath.AutoSelect = true;
            this.tEdit_ChecklistOutpuPath.DataText = "";
            this.tEdit_ChecklistOutpuPath.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_ChecklistOutpuPath.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_ChecklistOutpuPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_ChecklistOutpuPath.Location = new System.Drawing.Point(217, 26);
            this.tEdit_ChecklistOutpuPath.MaxLength = 256;
            this.tEdit_ChecklistOutpuPath.Name = "tEdit_ChecklistOutpuPath";
            this.tEdit_ChecklistOutpuPath.Size = new System.Drawing.Size(258, 24);
            this.tEdit_ChecklistOutpuPath.TabIndex = 28;
            // 
            // uLabel_FileName
            // 
            appearance4.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance4.TextVAlignAsString = "Middle";
            this.uLabel_FileName.Appearance = appearance4;
            this.uLabel_FileName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_FileName.Location = new System.Drawing.Point(45, 26);
            this.uLabel_FileName.Name = "uLabel_FileName";
            this.uLabel_FileName.Size = new System.Drawing.Size(166, 23);
            this.uLabel_FileName.TabIndex = 30;
            this.uLabel_FileName.Text = "チェックリスト出力先";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
            // 
            // PMMAX02010UD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(550, 246);
            this.Controls.Add(this.uButton_Cancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uButton_Save);
            this.Controls.Add(this.uButton_FileSelect);
            this.Controls.Add(this.tEdit_ChecklistOutpuPath);
            this.Controls.Add(this.uLabel_FileName);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMMAX02010UD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定画面";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_LoginID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_ChecklistOutpuPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Password;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_LoginID;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton uButton_Save;
        private Infragistics.Win.Misc.UltraButton uButton_FileSelect;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_ChecklistOutpuPath;
        private Infragistics.Win.Misc.UltraLabel uLabel_FileName;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
    }
}