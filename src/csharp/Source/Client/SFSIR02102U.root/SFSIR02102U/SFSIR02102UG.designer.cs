namespace Broadleaf.Windows.Forms
{
    partial class SFSIR02102UG
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("支払検索ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFSIR02102UG));
            this.uButton_Save = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SalesSlipNum = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tEdit1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Btn_SalesSlipGuide = new Infragistics.Win.Misc.UltraButton();
            this.uttmToolTip = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // uButton_Save
            // 
            this.uButton_Save.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Save.Location = new System.Drawing.Point(125, 39);
            this.uButton_Save.Name = "uButton_Save";
            this.uButton_Save.Size = new System.Drawing.Size(75, 25);
            this.uButton_Save.TabIndex = 5;
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
            this.uButton_Close.TabIndex = 6;
            this.uButton_Close.Text = "閉じる(&X)";
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
            // 
            // ultraLabel3
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance3;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 9);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel3.TabIndex = 1;
            this.ultraLabel3.Text = "伝票番号";
            // 
            // tNedit_SalesSlipNum
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextHAlignAsString = "Right";
            this.tNedit_SalesSlipNum.ActiveAppearance = appearance1;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.tNedit_SalesSlipNum.Appearance = appearance5;
            this.tNedit_SalesSlipNum.AutoSelect = true;
            this.tNedit_SalesSlipNum.AutoSize = false;
            this.tNedit_SalesSlipNum.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesSlipNum.DataText = "";
            this.tNedit_SalesSlipNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesSlipNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesSlipNum.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesSlipNum.Location = new System.Drawing.Point(168, 9);
            this.tNedit_SalesSlipNum.MaxLength = 9;
            this.tNedit_SalesSlipNum.Name = "tNedit_SalesSlipNum";
            this.tNedit_SalesSlipNum.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SalesSlipNum.Size = new System.Drawing.Size(83, 24);
            this.tNedit_SalesSlipNum.TabIndex = 3;
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 73);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            this.uStatusBar_Main.Size = new System.Drawing.Size(293, 23);
            this.uStatusBar_Main.TabIndex = 56;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
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
            // tEdit1
            // 
            this.tEdit1.ActiveAppearance = appearance10;
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Left;
            this.tEdit1.Appearance = appearance11;
            this.tEdit1.AutoSelect = true;
            this.tEdit1.DataText = "支払";
            this.tEdit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit1.Location = new System.Drawing.Point(88, 9);
            this.tEdit1.MaxLength = 12;
            this.tEdit1.Name = "tEdit1";
            this.tEdit1.ReadOnly = true;
            this.tEdit1.Size = new System.Drawing.Size(67, 24);
            this.tEdit1.TabIndex = 2;
            this.tEdit1.Text = "支払";
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
            this.Btn_SalesSlipGuide.TabIndex = 4;
            ultraToolTipInfo1.ToolTipText = "支払検索ガイド";
            this.uttmToolTip.SetUltraToolTip(this.Btn_SalesSlipGuide, ultraToolTipInfo1);
            this.Btn_SalesSlipGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Btn_SalesSlipGuide.Click += new System.EventHandler(this.Btn_SalesSlipGuide_Click);
            // 
            // uttmToolTip
            // 
            this.uttmToolTip.ContainingControl = this;
            this.uttmToolTip.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SFSIR02102UG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(293, 96);
            this.Controls.Add(this.Btn_SalesSlipGuide);
            this.Controls.Add(this.tEdit1);
            this.Controls.Add(this.uStatusBar_Main);
            this.Controls.Add(this.tNedit_SalesSlipNum);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.uButton_Close);
            this.Controls.Add(this.uButton_Save);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFSIR02102UG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伝票番号入力";
            this.Load += new System.EventHandler(this.SFSIR02102UG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton uButton_Save;
        private Infragistics.Win.Misc.UltraButton uButton_Close;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SalesSlipNum;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit1;
        private Infragistics.Win.Misc.UltraButton Btn_SalesSlipGuide;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uttmToolTip;
    }
}