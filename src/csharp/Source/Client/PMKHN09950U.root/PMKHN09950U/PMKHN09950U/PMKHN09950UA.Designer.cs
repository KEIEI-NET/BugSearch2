namespace Broadleaf.Windows.Forms
{
    partial class PMKHN09950UA
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09950UA));
            this.TargetFile_label = new System.Windows.Forms.Label();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Start_Button = new Infragistics.Win.Misc.UltraButton();
            this.MainCompfile_label = new System.Windows.Forms.Label();
            this.SubCompfile_label = new System.Windows.Forms.Label();
            this.TargetFile_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MainCompfile_Edit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Outputfile_label = new System.Windows.Forms.Label();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.SubCompfile_Edit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Outputfile_Edit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MainFolderSelect_button = new Infragistics.Win.Misc.UltraButton();
            this.SubFolderSelect_button = new Infragistics.Win.Misc.UltraButton();
            this.OutputFolderSelect_button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.TargetFile_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainCompfile_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubCompfile_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Outputfile_Edit)).BeginInit();
            this.SuspendLayout();
            // 
            // TargetFile_label
            // 
            this.TargetFile_label.AutoSize = true;
            this.TargetFile_label.Location = new System.Drawing.Point(12, 19);
            this.TargetFile_label.Name = "TargetFile_label";
            this.TargetFile_label.Size = new System.Drawing.Size(119, 15);
            this.TargetFile_label.TabIndex = 0;
            this.TargetFile_label.Text = "対象ファイル名";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(475, 153);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(133, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "終了(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // Start_Button
            // 
            this.Start_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Start_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Start_Button.Location = new System.Drawing.Point(342, 153);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(133, 34);
            this.Start_Button.TabIndex = 7;
            this.Start_Button.Text = "チェック開始(&S)";
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // MainCompfile_label
            // 
            this.MainCompfile_label.AutoSize = true;
            this.MainCompfile_label.Location = new System.Drawing.Point(12, 49);
            this.MainCompfile_label.Name = "MainCompfile_label";
            this.MainCompfile_label.Size = new System.Drawing.Size(87, 15);
            this.MainCompfile_label.TabIndex = 224;
            this.MainCompfile_label.Text = "比較メイン";
            // 
            // SubCompfile_label
            // 
            this.SubCompfile_label.AutoSize = true;
            this.SubCompfile_label.Location = new System.Drawing.Point(12, 80);
            this.SubCompfile_label.Name = "SubCompfile_label";
            this.SubCompfile_label.Size = new System.Drawing.Size(71, 15);
            this.SubCompfile_label.TabIndex = 225;
            this.SubCompfile_label.Text = "比較サブ";
            // 
            // TargetFile_tComboEditor
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TargetFile_tComboEditor.ActiveAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.TargetFile_tComboEditor.Appearance = appearance4;
            this.TargetFile_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.TargetFile_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.TargetFile_tComboEditor.Location = new System.Drawing.Point(138, 19);
            this.TargetFile_tComboEditor.Name = "TargetFile_tComboEditor";
            this.TargetFile_tComboEditor.Size = new System.Drawing.Size(259, 24);
            this.TargetFile_tComboEditor.TabIndex = 0;
            // 
            // MainCompfile_Edit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MainCompfile_Edit.ActiveAppearance = appearance6;
            this.MainCompfile_Edit.AllowDrop = true;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MainCompfile_Edit.Appearance = appearance1;
            this.MainCompfile_Edit.AutoSelect = true;
            this.MainCompfile_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MainCompfile_Edit.DataText = "";
            this.MainCompfile_Edit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MainCompfile_Edit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 100, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.MainCompfile_Edit.Location = new System.Drawing.Point(138, 49);
            this.MainCompfile_Edit.MaxLength = 100;
            this.MainCompfile_Edit.Name = "MainCompfile_Edit";
            this.MainCompfile_Edit.Size = new System.Drawing.Size(438, 24);
            this.MainCompfile_Edit.TabIndex = 1;
            // 
            // Outputfile_label
            // 
            this.Outputfile_label.AutoSize = true;
            this.Outputfile_label.Location = new System.Drawing.Point(12, 126);
            this.Outputfile_label.Name = "Outputfile_label";
            this.Outputfile_label.Size = new System.Drawing.Size(119, 15);
            this.Outputfile_label.TabIndex = 233;
            this.Outputfile_label.Text = "出力ファイル名";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.Location = new System.Drawing.Point(8, 111);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(626, 23);
            this.tLine1.TabIndex = 234;
            this.tLine1.Text = "tLine1";
            // 
            // SubCompfile_Edit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SubCompfile_Edit.ActiveAppearance = appearance8;
            this.SubCompfile_Edit.AllowDrop = true;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SubCompfile_Edit.Appearance = appearance5;
            this.SubCompfile_Edit.AutoSelect = true;
            this.SubCompfile_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SubCompfile_Edit.DataText = "";
            this.SubCompfile_Edit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SubCompfile_Edit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 100, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SubCompfile_Edit.Location = new System.Drawing.Point(138, 80);
            this.SubCompfile_Edit.MaxLength = 100;
            this.SubCompfile_Edit.Name = "SubCompfile_Edit";
            this.SubCompfile_Edit.Size = new System.Drawing.Size(438, 24);
            this.SubCompfile_Edit.TabIndex = 3;
            // 
            // Outputfile_Edit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Outputfile_Edit.ActiveAppearance = appearance2;
            this.Outputfile_Edit.AllowDrop = true;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Outputfile_Edit.Appearance = appearance7;
            this.Outputfile_Edit.AutoSelect = true;
            this.Outputfile_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Outputfile_Edit.DataText = "";
            this.Outputfile_Edit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Outputfile_Edit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 100, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.Outputfile_Edit.Location = new System.Drawing.Point(138, 117);
            this.Outputfile_Edit.MaxLength = 100;
            this.Outputfile_Edit.Name = "Outputfile_Edit";
            this.Outputfile_Edit.Size = new System.Drawing.Size(438, 24);
            this.Outputfile_Edit.TabIndex = 5;
            // 
            // MainFolderSelect_button
            // 
            this.MainFolderSelect_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainFolderSelect_button.Location = new System.Drawing.Point(579, 49);
            this.MainFolderSelect_button.Name = "MainFolderSelect_button";
            this.MainFolderSelect_button.Size = new System.Drawing.Size(26, 25);
            this.MainFolderSelect_button.TabIndex = 2;
            this.MainFolderSelect_button.Click += new System.EventHandler(this.FolderSelect_button_Click);
            // 
            // SubFolderSelect_button
            // 
            this.SubFolderSelect_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubFolderSelect_button.Location = new System.Drawing.Point(579, 79);
            this.SubFolderSelect_button.Name = "SubFolderSelect_button";
            this.SubFolderSelect_button.Size = new System.Drawing.Size(26, 25);
            this.SubFolderSelect_button.TabIndex = 4;
            this.SubFolderSelect_button.Click += new System.EventHandler(this.FolderSelect_button_Click);
            // 
            // OutputFolderSelect_button
            // 
            this.OutputFolderSelect_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OutputFolderSelect_button.Location = new System.Drawing.Point(579, 117);
            this.OutputFolderSelect_button.Name = "OutputFolderSelect_button";
            this.OutputFolderSelect_button.Size = new System.Drawing.Size(26, 25);
            this.OutputFolderSelect_button.TabIndex = 6;
            this.OutputFolderSelect_button.Click += new System.EventHandler(this.OutputFolderSelect_button_Click);
            // 
            // PMKHN09950UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(617, 199);
            this.Controls.Add(this.OutputFolderSelect_button);
            this.Controls.Add(this.SubFolderSelect_button);
            this.Controls.Add(this.MainFolderSelect_button);
            this.Controls.Add(this.Outputfile_Edit);
            this.Controls.Add(this.SubCompfile_Edit);
            this.Controls.Add(this.tLine1);
            this.Controls.Add(this.Outputfile_label);
            this.Controls.Add(this.MainCompfile_Edit);
            this.Controls.Add(this.TargetFile_tComboEditor);
            this.Controls.Add(this.SubCompfile_label);
            this.Controls.Add(this.MainCompfile_label);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.TargetFile_label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PMKHN09950UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV比較ツール";
            this.Load += new System.EventHandler(this.PMKHN09950UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TargetFile_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainCompfile_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubCompfile_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Outputfile_Edit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TargetFile_label;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TComboEditor TargetFile_tComboEditor;
        private System.Windows.Forms.Label MainCompfile_label;
        private Infragistics.Win.Misc.UltraButton Start_Button;
        private Broadleaf.Library.Windows.Forms.TEdit MainCompfile_Edit;
        private Broadleaf.Library.Windows.Forms.TLine tLine1;
        private System.Windows.Forms.Label Outputfile_label;
        private Broadleaf.Library.Windows.Forms.TEdit SubCompfile_Edit;
        private Broadleaf.Library.Windows.Forms.TEdit Outputfile_Edit;
        private Infragistics.Win.Misc.UltraButton MainFolderSelect_button;
        private Infragistics.Win.Misc.UltraButton OutputFolderSelect_button;
        private Infragistics.Win.Misc.UltraButton SubFolderSelect_button;
        public System.Windows.Forms.Label SubCompfile_label;
    }
}

