using System.Windows.Forms;
namespace Broadleaf.Windows.Forms
{
    partial class PMKAU02020UA
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKAU02020UA));
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.FolderPath_panel = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.OK_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.CustomFolderGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.EBooksFolderGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomFolderPath_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EBooksFolderPath_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EBooksFolder_lable = new Infragistics.Win.Misc.UltraLabel();
            this.CustomFolder_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.FolderPath_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomFolderPath_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EBooksFolderPath_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(200, 100);
            this.ultraExplorerBarContainerControl1.TabIndex = 1;
            // 
            // FolderPath_panel
            // 
            this.FolderPath_panel.Controls.Add(this.OK_Button);
            this.FolderPath_panel.Controls.Add(this.Cancel_Button);
            this.FolderPath_panel.Controls.Add(this.CustomFolderGuide_ultraButton);
            this.FolderPath_panel.Controls.Add(this.EBooksFolderGuide_ultraButton);
            this.FolderPath_panel.Controls.Add(this.CustomFolderPath_tEdit);
            this.FolderPath_panel.Controls.Add(this.EBooksFolderPath_tEdit);
            this.FolderPath_panel.Controls.Add(this.EBooksFolder_lable);
            this.FolderPath_panel.Controls.Add(this.CustomFolder_ultraLabel);
            this.FolderPath_panel.Location = new System.Drawing.Point(-3, -2);
            this.FolderPath_panel.Name = "FolderPath_panel";
            this.FolderPath_panel.Size = new System.Drawing.Size(566, 258);
            this.FolderPath_panel.TabIndex = 1;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OK_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.OK_Button.Location = new System.Drawing.Point(255, 191);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(125, 34);
            this.OK_Button.TabIndex = 8;
            this.OK_Button.Text = "保　存(&S)";
            this.OK_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(386, 191);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(145, 34);
            this.Cancel_Button.TabIndex = 9;
            this.Cancel_Button.Text = "キャンセル(&E)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // CustomFolderGuide_ultraButton
            // 
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomFolderGuide_ultraButton.Appearance = appearance3;
            this.CustomFolderGuide_ultraButton.Location = new System.Drawing.Point(507, 133);
            this.CustomFolderGuide_ultraButton.Name = "CustomFolderGuide_ultraButton";
            this.CustomFolderGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.CustomFolderGuide_ultraButton.TabIndex = 7;
            this.CustomFolderGuide_ultraButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomFolderGuide_ultraButton.Click += new System.EventHandler(this.FolderGuide_ultraButton_Click);
            // 
            // EBooksFolderGuide_ultraButton
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.EBooksFolderGuide_ultraButton.Appearance = appearance4;
            this.EBooksFolderGuide_ultraButton.Location = new System.Drawing.Point(507, 57);
            this.EBooksFolderGuide_ultraButton.Name = "EBooksFolderGuide_ultraButton";
            this.EBooksFolderGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.EBooksFolderGuide_ultraButton.TabIndex = 4;
            this.EBooksFolderGuide_ultraButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.EBooksFolderGuide_ultraButton.Click += new System.EventHandler(this.FolderGuide_ultraButton_Click);
            // 
            // CustomFolderPath_tEdit
            // 
            this.CustomFolderPath_tEdit.ActiveAppearance = appearance5;
            this.CustomFolderPath_tEdit.AutoSelect = true;
            this.CustomFolderPath_tEdit.DataText = "";
            this.CustomFolderPath_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomFolderPath_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomFolderPath_tEdit.Location = new System.Drawing.Point(35, 133);
            this.CustomFolderPath_tEdit.MaxLength = 255;
            this.CustomFolderPath_tEdit.Name = "CustomFolderPath_tEdit";
            this.CustomFolderPath_tEdit.Size = new System.Drawing.Size(464, 24);
            this.CustomFolderPath_tEdit.TabIndex = 6;
            // 
            // EBooksFolderPath_tEdit
            // 
            this.EBooksFolderPath_tEdit.ActiveAppearance = appearance2;
            this.EBooksFolderPath_tEdit.AutoSelect = true;
            this.EBooksFolderPath_tEdit.DataText = "";
            this.EBooksFolderPath_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EBooksFolderPath_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 255, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EBooksFolderPath_tEdit.Location = new System.Drawing.Point(35, 57);
            this.EBooksFolderPath_tEdit.MaxLength = 255;
            this.EBooksFolderPath_tEdit.Name = "EBooksFolderPath_tEdit";
            this.EBooksFolderPath_tEdit.Size = new System.Drawing.Size(464, 24);
            this.EBooksFolderPath_tEdit.TabIndex = 3;
            this.EBooksFolderPath_tEdit.Tag = "";
            // 
            // EBooksFolder_lable
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.EBooksFolder_lable.Appearance = appearance1;
            this.EBooksFolder_lable.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EBooksFolder_lable.Location = new System.Drawing.Point(35, 34);
            this.EBooksFolder_lable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EBooksFolder_lable.Name = "EBooksFolder_lable";
            this.EBooksFolder_lable.Size = new System.Drawing.Size(200, 24);
            this.EBooksFolder_lable.TabIndex = 2;
            this.EBooksFolder_lable.Text = "電子帳簿受け渡しフォルダ";
            // 
            // CustomFolder_ultraLabel
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.TextVAlignAsString = "Middle";
            this.CustomFolder_ultraLabel.Appearance = appearance6;
            this.CustomFolder_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomFolder_ultraLabel.Location = new System.Drawing.Point(35, 111);
            this.CustomFolder_ultraLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CustomFolder_ultraLabel.Name = "CustomFolder_ultraLabel";
            this.CustomFolder_ultraLabel.Size = new System.Drawing.Size(230, 24);
            this.CustomFolder_ultraLabel.TabIndex = 5;
            this.CustomFolder_ultraLabel.Text = "取引先リスト受け渡しフォルダ";
            // 
            // PMKAU02020UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(556, 250);
            this.Controls.Add(this.FolderPath_panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKAU02020UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "電子帳簿連携設定";
            this.Load += new System.EventHandler(this.PMKAU02010U_Load);
            this.Shown += new System.EventHandler(this.PMKAU02010UA_Shown);
            this.FolderPath_panel.ResumeLayout(false);
            this.FolderPath_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomFolderPath_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EBooksFolderPath_tEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private System.Windows.Forms.Panel FolderPath_panel;
        private FolderBrowserDialog folderBrowserDialog1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.Misc.UltraButton OK_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton CustomFolderGuide_ultraButton;
        private Infragistics.Win.Misc.UltraButton EBooksFolderGuide_ultraButton;
        private Broadleaf.Library.Windows.Forms.TEdit CustomFolderPath_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit EBooksFolderPath_tEdit;
        private Infragistics.Win.Misc.UltraLabel EBooksFolder_lable;
        private Infragistics.Win.Misc.UltraLabel CustomFolder_ultraLabel;
    }
}