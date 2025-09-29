namespace Broadleaf.Windows.Forms
{
    partial class PMKYO09110UA
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKYO09110UA));
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.EnterpriseCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PmEnterpriseCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Bind_DataSet = new System.Data.DataSet();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PmEnterpriseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Section_uLabel
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance6;
            this.Section_uLabel.Location = new System.Drawing.Point(27, 45);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(63, 23);
            this.Section_uLabel.TabIndex = 0;
            this.Section_uLabel.Text = "拠点";
            // 
            // tEdit_SectionCode
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.TextHAlignAsString = "Right";
            this.tEdit_SectionCode.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.tEdit_SectionCode.Appearance = appearance8;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCode.Location = new System.Drawing.Point(111, 45);
            this.tEdit_SectionCode.MaxLength = 2;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(44, 24);
            this.tEdit_SectionCode.TabIndex = 1;
            // 
            // SectionName_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance10;
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance5;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(161, 45);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(145, 24);
            this.SectionName_tEdit.TabIndex = 2;
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(314, 45);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 3;
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // EnterpriseCode_uLabel
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.EnterpriseCode_uLabel.Appearance = appearance13;
            this.EnterpriseCode_uLabel.Location = new System.Drawing.Point(27, 81);
            this.EnterpriseCode_uLabel.Name = "EnterpriseCode_uLabel";
            this.EnterpriseCode_uLabel.Size = new System.Drawing.Size(87, 23);
            this.EnterpriseCode_uLabel.TabIndex = 4;
            this.EnterpriseCode_uLabel.Text = "企業コード";
            // 
            // tEdit_PmEnterpriseCode
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.TextHAlignAsString = "Right";
            this.tEdit_PmEnterpriseCode.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Right";
            this.tEdit_PmEnterpriseCode.Appearance = appearance12;
            this.tEdit_PmEnterpriseCode.AutoSelect = true;
            this.tEdit_PmEnterpriseCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_PmEnterpriseCode.DataText = "";
            this.tEdit_PmEnterpriseCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PmEnterpriseCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.tEdit_PmEnterpriseCode.Location = new System.Drawing.Point(111, 81);
            this.tEdit_PmEnterpriseCode.MaxLength = 16;
            this.tEdit_PmEnterpriseCode.Name = "tEdit_PmEnterpriseCode";
            this.tEdit_PmEnterpriseCode.Size = new System.Drawing.Size(195, 24);
            this.tEdit_PmEnterpriseCode.TabIndex = 5;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(467, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 62;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(173, 173);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 63;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(305, 173);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 64;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(436, 173);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 65;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(305, 173);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 66;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 217);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(573, 23);
            this.ultraStatusBar1.TabIndex = 67;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // PMKYO09110UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(573, 240);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.tEdit_PmEnterpriseCode);
            this.Controls.Add(this.EnterpriseCode_uLabel);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.Section_uLabel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "PMKYO09110UA";
            this.Text = "企業設定";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PmEnterpriseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel Section_uLabel;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCode;
        private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel EnterpriseCode_uLabel;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_PmEnterpriseCode;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
    }
}

