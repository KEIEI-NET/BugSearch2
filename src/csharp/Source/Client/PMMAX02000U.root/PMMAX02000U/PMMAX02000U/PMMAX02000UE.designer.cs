namespace Broadleaf.Windows.Forms
{
    partial class PMMAX02000UE
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
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMMAX02000UE));
            this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Save = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_Message = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_LoginId = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_Password = new Broadleaf.Library.Windows.Forms.TEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_LoginId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Password)).BeginInit();
            this.SuspendLayout();
            // 
            // uButton_Cancel
            // 
            this.uButton_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Cancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Cancel.Location = new System.Drawing.Point(287, 226);
            this.uButton_Cancel.Name = "uButton_Cancel";
            this.uButton_Cancel.Size = new System.Drawing.Size(116, 34);
            this.uButton_Cancel.TabIndex = 32;
            this.uButton_Cancel.Text = "中止";
            this.uButton_Cancel.Click += new System.EventHandler(this.uButton_Cancel_Click);
            // 
            // uButton_Save
            // 
            this.uButton_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Save.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Save.Location = new System.Drawing.Point(165, 226);
            this.uButton_Save.Name = "uButton_Save";
            this.uButton_Save.Size = new System.Drawing.Size(116, 34);
            this.uButton_Save.TabIndex = 31;
            this.uButton_Save.Text = "保存";
            this.uButton_Save.Click += new System.EventHandler(this.uButton_Save_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraLabel1
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance9;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(108, 140);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(108, 23);
            this.ultraLabel1.TabIndex = 25;
            this.ultraLabel1.Text = "ログインID";
            // 
            // ultraLabel2
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance10;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(108, 183);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(108, 23);
            this.ultraLabel2.TabIndex = 25;
            this.ultraLabel2.Text = "パスワード";
            // 
            // ultraLabel_Message
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Top";
            this.ultraLabel_Message.Appearance = appearance4;
            this.ultraLabel_Message.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Message.Location = new System.Drawing.Point(34, 18);
            this.ultraLabel_Message.Name = "ultraLabel_Message";
            this.ultraLabel_Message.Size = new System.Drawing.Size(495, 103);
            this.ultraLabel_Message.TabIndex = 33;
            this.ultraLabel_Message.Text = "部品MAX管理画面にログインするための下記情報を入力してください。";
            // 
            // tEdit_LoginId
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_LoginId.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_LoginId.Appearance = appearance16;
            this.tEdit_LoginId.AutoSelect = true;
            this.tEdit_LoginId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_LoginId.DataText = "";
            this.tEdit_LoginId.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_LoginId.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_LoginId.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_LoginId.Location = new System.Drawing.Point(222, 140);
            this.tEdit_LoginId.MaxLength = 256;
            this.tEdit_LoginId.Name = "tEdit_LoginId";
            this.tEdit_LoginId.Size = new System.Drawing.Size(198, 24);
            this.tEdit_LoginId.TabIndex = 10;
            // 
            // tEdit_Password
            // 
            appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Password.ActiveAppearance = appearance112;
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance113.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_Password.Appearance = appearance113;
            this.tEdit_Password.AutoSelect = true;
            this.tEdit_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_Password.DataText = "";
            this.tEdit_Password.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Password.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_Password.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_Password.Location = new System.Drawing.Point(222, 183);
            this.tEdit_Password.MaxLength = 256;
            this.tEdit_Password.Name = "tEdit_Password";
            this.tEdit_Password.PasswordChar = '*';
            this.tEdit_Password.Size = new System.Drawing.Size(198, 24);
            this.tEdit_Password.TabIndex = 20;
            // 
            // PMMAX02000UE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(555, 294);
            this.Controls.Add(this.tEdit_Password);
            this.Controls.Add(this.tEdit_LoginId);
            this.Controls.Add(this.ultraLabel_Message);
            this.Controls.Add(this.uButton_Cancel);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.uButton_Save);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMMAX02000UE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "部品MAX認証入力画面";
            this.Load += new System.EventHandler(this.PMMAX02000UE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_LoginId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Password)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton uButton_Cancel;
        private Infragistics.Win.Misc.UltraButton uButton_Save;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Message;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_LoginId;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Password;
    }
}