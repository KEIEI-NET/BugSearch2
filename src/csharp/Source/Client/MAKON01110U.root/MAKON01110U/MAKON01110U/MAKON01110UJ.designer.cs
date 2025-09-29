namespace Broadleaf.Windows.Forms
{
    partial class MAKON01110UJ
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
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKON01110UJ));
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Save = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraButton_FolderName = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_FolderName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.errorCount = new Infragistics.Win.Misc.UltraLabel();
            this.readCount = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine4 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FolderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            this.SuspendLayout();
            // 
            // uButton_Close
            // 
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uButton_Close.Location = new System.Drawing.Point(488, 185);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(133, 37);
            this.uButton_Close.TabIndex = 4;
            this.uButton_Close.Text = "キャンセル(&X)";
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
            // 
            // uButton_Save
            // 
            this.uButton_Save.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uButton_Save.Location = new System.Drawing.Point(350, 185);
            this.uButton_Save.Name = "uButton_Save";
            this.uButton_Save.Size = new System.Drawing.Size(132, 37);
            this.uButton_Save.TabIndex = 3;
            this.uButton_Save.Text = "データ取込(&S)";
            this.uButton_Save.Click += new System.EventHandler(this.uButton_Save_Click);
            // 
            // ultraLabel1
            // 
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.Location = new System.Drawing.Point(33, 41);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(91, 24);
            this.ultraLabel1.TabIndex = 1357;
            this.ultraLabel1.Text = "ファイル名";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraButton_FolderName
            // 
            appearance86.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ultraButton_FolderName.Appearance = appearance86;
            this.ultraButton_FolderName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraButton_FolderName.Location = new System.Drawing.Point(556, 40);
            this.ultraButton_FolderName.Name = "ultraButton_FolderName";
            this.ultraButton_FolderName.Size = new System.Drawing.Size(25, 25);
            this.ultraButton_FolderName.TabIndex = 2;
            this.ultraButton_FolderName.Tag = "1";
            this.ultraButton_FolderName.UseHotTracking = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton_FolderName.Click += new System.EventHandler(this.ultraButton_FolderName_Click);
            // 
            // tEdit_FolderName
            // 
            appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_FolderName.ActiveAppearance = appearance84;
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance85.TextHAlignAsString = "Left";
            this.tEdit_FolderName.Appearance = appearance85;
            this.tEdit_FolderName.AutoSelect = false;
            this.tEdit_FolderName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_FolderName.DataText = "";
            this.tEdit_FolderName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FolderName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 254, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_FolderName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_FolderName.Location = new System.Drawing.Point(140, 41);
            this.tEdit_FolderName.MaxLength = 254;
            this.tEdit_FolderName.Name = "tEdit_FolderName";
            this.tEdit_FolderName.Size = new System.Drawing.Size(401, 24);
            this.tEdit_FolderName.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance3;
            this.ultraLabel2.Location = new System.Drawing.Point(12, 10);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(112, 24);
            this.ultraLabel2.TabIndex = 1363;
            this.ultraLabel2.Text = "取込ファイル";
            // 
            // ultraLabel3
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance1;
            this.ultraLabel3.Location = new System.Drawing.Point(12, 71);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(112, 24);
            this.ultraLabel3.TabIndex = 1364;
            this.ultraLabel3.Text = "取込結果";
            // 
            // errorCount
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Middle";
            this.errorCount.Appearance = appearance7;
            this.errorCount.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorCount.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.errorCount.Location = new System.Drawing.Point(156, 134);
            this.errorCount.Margin = new System.Windows.Forms.Padding(1);
            this.errorCount.Name = "errorCount";
            this.errorCount.Size = new System.Drawing.Size(130, 24);
            this.errorCount.TabIndex = 1368;
            this.errorCount.Text = "  件";
            // 
            // readCount
            // 
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.readCount.Appearance = appearance11;
            this.readCount.BackColorInternal = System.Drawing.Color.Transparent;
            this.readCount.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.readCount.Location = new System.Drawing.Point(156, 99);
            this.readCount.Margin = new System.Windows.Forms.Padding(1);
            this.readCount.Name = "readCount";
            this.readCount.Size = new System.Drawing.Size(130, 24);
            this.readCount.TabIndex = 1367;
            this.readCount.Text = "  件";
            // 
            // ultraLabel4
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance15;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.ultraLabel4.Location = new System.Drawing.Point(33, 99);
            this.ultraLabel4.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel4.TabIndex = 1365;
            this.ultraLabel4.Text = "読込件数";
            // 
            // ultraLabel5
            // 
            appearance82.BackColor = System.Drawing.Color.Transparent;
            appearance82.ForeColorDisabled = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Left";
            appearance82.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance82;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.ultraLabel5.Location = new System.Drawing.Point(33, 134);
            this.ultraLabel5.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel5.TabIndex = 1366;
            this.ultraLabel5.Text = "エラー件数";
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.ForeColor = System.Drawing.Color.Silver;
            this.tLine4.Location = new System.Drawing.Point(130, 81);
            this.tLine4.Name = "tLine4";
            this.tLine4.Size = new System.Drawing.Size(475, 3);
            this.tLine4.TabIndex = 1372;
            this.tLine4.Text = "tLine4";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.ForeColor = System.Drawing.Color.Silver;
            this.tLine1.Location = new System.Drawing.Point(131, 21);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(475, 3);
            this.tLine1.TabIndex = 1373;
            this.tLine1.Text = "tLine1";
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.ReadOnLoad = false;
            // 
            // MAKON01110UJ
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(642, 234);
            this.Controls.Add(this.tLine1);
            this.Controls.Add(this.tLine4);
            this.Controls.Add(this.errorCount);
            this.Controls.Add(this.readCount);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraButton_FolderName);
            this.Controls.Add(this.tEdit_FolderName);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.uButton_Close);
            this.Controls.Add(this.uButton_Save);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAKON01110UJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入データ取込";
            this.Load += new System.EventHandler(this.MAKON01110UJ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FolderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton uButton_Close;
        private Infragistics.Win.Misc.UltraButton uButton_Save;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraButton ultraButton_FolderName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_FolderName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel errorCount;
        private Infragistics.Win.Misc.UltraLabel readCount;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Broadleaf.Library.Windows.Forms.TLine tLine1;
        private Broadleaf.Library.Windows.Forms.TLine tLine4;
        private Broadleaf.Library.Windows.Forms.UiMemInput uiMemInput1;

    }
}