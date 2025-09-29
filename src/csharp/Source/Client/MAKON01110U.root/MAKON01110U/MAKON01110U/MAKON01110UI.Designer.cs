namespace Broadleaf.Windows.Forms
{
    partial class MAKON01110UI
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKON01110UI));
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Save = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.TaxRate_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // uButton_Close
            // 
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Close.Location = new System.Drawing.Point(172, 39);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(75, 25);
            this.uButton_Close.TabIndex = 3;
            this.uButton_Close.Text = "閉じる(&X)";
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
            // 
            // uButton_Save
            // 
            this.uButton_Save.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Save.Location = new System.Drawing.Point(91, 39);
            this.uButton_Save.Name = "uButton_Save";
            this.uButton_Save.Size = new System.Drawing.Size(75, 25);
            this.uButton_Save.TabIndex = 2;
            this.uButton_Save.Text = "確定(&S)";
            this.uButton_Save.Click += new System.EventHandler(this.uButton_Save_Click);
            // 
            // ultraLabel1
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Location = new System.Drawing.Point(24, 9);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel1.TabIndex = 1357;
            this.ultraLabel1.Text = "消費税率";
            // 
            // ultraLabel2
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance21;
            this.ultraLabel2.Location = new System.Drawing.Point(164, 10);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel2.TabIndex = 1359;
            this.ultraLabel2.Text = "％";
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
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 74);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            this.uStatusBar_Main.Size = new System.Drawing.Size(255, 23);
            this.uStatusBar_Main.TabIndex = 1360;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // TaxRate_tNedit
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Right";
            this.TaxRate_tNedit.ActiveAppearance = appearance34;
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Right";
            this.TaxRate_tNedit.Appearance = appearance35;
            this.TaxRate_tNedit.AutoSelect = true;
            this.TaxRate_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.TaxRate_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxRate_tNedit.DataText = "";
            this.TaxRate_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRate_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.TaxRate_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxRate_tNedit.Location = new System.Drawing.Point(98, 9);
            this.TaxRate_tNedit.MaxLength = 2;
            this.TaxRate_tNedit.Name = "TaxRate_tNedit";
            this.TaxRate_tNedit.NullText = "0";
            this.TaxRate_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxRate_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaxRate_tNedit.Size = new System.Drawing.Size(59, 24);
            this.TaxRate_tNedit.TabIndex = 1;
            // 
            // MAKON01110UI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(255, 97);
            this.Controls.Add(this.TaxRate_tNedit);
            this.Controls.Add(this.uStatusBar_Main);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.uButton_Close);
            this.Controls.Add(this.uButton_Save);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAKON01110UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消費税率設定";
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton uButton_Close;
        private Infragistics.Win.Misc.UltraButton uButton_Save;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TNedit TaxRate_tNedit;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;

    }
}