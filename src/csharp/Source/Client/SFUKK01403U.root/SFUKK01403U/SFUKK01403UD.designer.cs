namespace Broadleaf.Windows.Forms
{
    partial class SFUKK01403UD
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
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("入金検索ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01403UD));
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_Save = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tNedit_SalesSlipNum = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tEdit1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Btn_SalesSlipGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTip = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel3
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance3;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 9);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel3.TabIndex = 25;
            this.ultraLabel3.Text = "伝票番号";
            // 
            // uButton_Save
            // 
            this.uButton_Save.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Save.Location = new System.Drawing.Point(125, 39);
            this.uButton_Save.Name = "uButton_Save";
            this.uButton_Save.Size = new System.Drawing.Size(75, 25);
            this.uButton_Save.TabIndex = 3;
            this.uButton_Save.Text = "確定(&S)";
            this.uButton_Save.Click += new System.EventHandler(this.uButton_Save_Click);
            // 
            // uButton_Close
            // 
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Close.Location = new System.Drawing.Point(206, 39);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(75, 25);
            this.uButton_Close.TabIndex = 4;
            this.uButton_Close.Text = "閉じる(&X)";
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
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
            // tNedit_SalesSlipNum
            // 
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance88.TextHAlignAsString = "Right";
            this.tNedit_SalesSlipNum.ActiveAppearance = appearance88;
            appearance89.BackColor = System.Drawing.Color.White;
            appearance89.TextHAlignAsString = "Right";
            this.tNedit_SalesSlipNum.Appearance = appearance89;
            this.tNedit_SalesSlipNum.AutoSelect = true;
            this.tNedit_SalesSlipNum.BackColor = System.Drawing.Color.White;
            this.tNedit_SalesSlipNum.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesSlipNum.DataText = "";
            this.tNedit_SalesSlipNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesSlipNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesSlipNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tNedit_SalesSlipNum.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesSlipNum.Location = new System.Drawing.Point(168, 9);
            this.tNedit_SalesSlipNum.MaxLength = 9;
            this.tNedit_SalesSlipNum.Name = "tNedit_SalesSlipNum";
            this.tNedit_SalesSlipNum.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesSlipNum.Size = new System.Drawing.Size(84, 24);
            this.tNedit_SalesSlipNum.TabIndex = 1;
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 73);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            this.uStatusBar_Main.Size = new System.Drawing.Size(293, 23);
            this.uStatusBar_Main.TabIndex = 55;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tEdit1
            // 
            this.tEdit1.ActiveAppearance = appearance7;
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Left;
            this.tEdit1.Appearance = appearance9;
            this.tEdit1.AutoSelect = true;
            this.tEdit1.DataText = "入金";
            this.tEdit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tEdit1.Location = new System.Drawing.Point(88, 9);
            this.tEdit1.MaxLength = 12;
            this.tEdit1.Name = "tEdit1";
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Left;
            this.tEdit1.NullTextAppearance = appearance8;
            this.tEdit1.ReadOnly = true;
            this.tEdit1.Size = new System.Drawing.Size(68, 24);
            this.tEdit1.TabIndex = 2;
            this.tEdit1.Text = "入金";
            // 
            // Btn_SalesSlipGuide
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.Btn_SalesSlipGuide.Appearance = appearance4;
            this.Btn_SalesSlipGuide.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_SalesSlipGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btn_SalesSlipGuide.Location = new System.Drawing.Point(258, 9);
            this.Btn_SalesSlipGuide.Name = "Btn_SalesSlipGuide";
            this.Btn_SalesSlipGuide.Size = new System.Drawing.Size(24, 24);
            this.Btn_SalesSlipGuide.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "入金検索ガイド";
            this.ultraToolTip.SetUltraToolTip(this.Btn_SalesSlipGuide, ultraToolTipInfo1);
            this.Btn_SalesSlipGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Btn_SalesSlipGuide.Click += new System.EventHandler(this.uButton_SalesSlipGuide_Click);
            // 
            // ultraToolTip
            // 
            this.ultraToolTip.ContainingControl = this;
            this.ultraToolTip.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SFUKK01403UD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(293, 96);
            this.Controls.Add(this.Btn_SalesSlipGuide);
            this.Controls.Add(this.tEdit1);
            this.Controls.Add(this.tNedit_SalesSlipNum);
            this.Controls.Add(this.uStatusBar_Main);
            this.Controls.Add(this.uButton_Close);
            this.Controls.Add(this.uButton_Save);
            this.Controls.Add(this.ultraLabel3);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFUKK01403UD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伝票番号入力";
            this.Load += new System.EventHandler(this.SFUKK01403UD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraButton uButton_Save;
        private Infragistics.Win.Misc.UltraButton uButton_Close;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SalesSlipNum;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit1;
        private Infragistics.Win.Misc.UltraButton Btn_SalesSlipGuide;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTip;
    }
}