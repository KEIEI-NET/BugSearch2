namespace Broadleaf.Windows.Forms
{
    partial class PMSCM09110UA
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM09110UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolTipManager = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Section_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.WarehouseNote1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_MachineIpAddr = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_MachineName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CashRegisterNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.comment_label = new System.Windows.Forms.Label();
            this.tNedit_CashRegisterNo = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MachineIpAddr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MachineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CashRegisterNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNEdit_SectionCode)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 231);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(615, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(488, 2);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 62;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(222, 179);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 11;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(351, 179);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 13;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Save_Button.Location = new System.Drawing.Point(351, 179);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(125, 34);
            this.Save_Button.TabIndex = 12;
            this.Save_Button.Text = "保存(&S)";
            this.Save_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(479, 179);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 14;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.OwnerForm = this;
            this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // ultraToolTipManager
            // 
            this.ultraToolTipManager.ContainingControl = this;
            this.ultraToolTipManager.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(178, 36);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 3;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(8, 71);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(580, 3);
            this.DivideLine_Label.TabIndex = 144;
            // 
            // tEdit_SectionName
            // 
            this.tEdit_SectionName.ActiveAppearance = appearance9;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionName.Appearance = appearance10;
            this.tEdit_SectionName.AutoSelect = true;
            this.tEdit_SectionName.DataText = "";
            this.tEdit_SectionName.Enabled = false;
            this.tEdit_SectionName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SectionName.Location = new System.Drawing.Point(209, 36);
            this.tEdit_SectionName.MaxLength = 6;
            this.tEdit_SectionName.Name = "tEdit_SectionName";
            this.tEdit_SectionName.ReadOnly = true;
            this.tEdit_SectionName.Size = new System.Drawing.Size(159, 24);
            this.tEdit_SectionName.TabIndex = 4;
            // 
            // Section_Title_Label
            // 
            this.Section_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Section_Title_Label.Location = new System.Drawing.Point(8, 36);
            this.Section_Title_Label.Name = "Section_Title_Label";
            this.Section_Title_Label.Size = new System.Drawing.Size(100, 24);
            this.Section_Title_Label.TabIndex = 1;
            this.Section_Title_Label.Text = "拠点";
            // 
            // WarehouseNote1_Title_Label
            // 
            this.WarehouseNote1_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.WarehouseNote1_Title_Label.Location = new System.Drawing.Point(8, 113);
            this.WarehouseNote1_Title_Label.Name = "WarehouseNote1_Title_Label";
            this.WarehouseNote1_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.WarehouseNote1_Title_Label.TabIndex = 8;
            this.WarehouseNote1_Title_Label.Text = "端末IPアドレス";
            // 
            // tEdit_MachineIpAddr
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MachineIpAddr.ActiveAppearance = appearance2;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_MachineIpAddr.Appearance = appearance3;
            this.tEdit_MachineIpAddr.AutoSelect = true;
            this.tEdit_MachineIpAddr.DataText = "";
            this.tEdit_MachineIpAddr.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MachineIpAddr.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MachineIpAddr.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_MachineIpAddr.Location = new System.Drawing.Point(144, 113);
            this.tEdit_MachineIpAddr.MaxLength = 40;
            this.tEdit_MachineIpAddr.Name = "tEdit_MachineIpAddr";
            this.tEdit_MachineIpAddr.ReadOnly = true;
            this.tEdit_MachineIpAddr.Size = new System.Drawing.Size(221, 24);
            this.tEdit_MachineIpAddr.TabIndex = 9;
            // 
            // tEdit_MachineName
            // 
            this.tEdit_MachineName.ActiveAppearance = appearance4;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_MachineName.Appearance = appearance11;
            this.tEdit_MachineName.AutoSelect = true;
            this.tEdit_MachineName.DataText = "";
            this.tEdit_MachineName.Enabled = false;
            this.tEdit_MachineName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MachineName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MachineName.Location = new System.Drawing.Point(190, 83);
            this.tEdit_MachineName.MaxLength = 6;
            this.tEdit_MachineName.Name = "tEdit_MachineName";
            this.tEdit_MachineName.ReadOnly = true;
            this.tEdit_MachineName.Size = new System.Drawing.Size(175, 24);
            this.tEdit_MachineName.TabIndex = 7;
            // 
            // CashRegisterNo_Label
            // 
            this.CashRegisterNo_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CashRegisterNo_Label.Location = new System.Drawing.Point(8, 83);
            this.CashRegisterNo_Label.Name = "CashRegisterNo_Label";
            this.CashRegisterNo_Label.Size = new System.Drawing.Size(130, 24);
            this.CashRegisterNo_Label.TabIndex = 5;
            this.CashRegisterNo_Label.Text = "端末番号";
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(222, 179);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 10;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // comment_label
            // 
            this.comment_label.AutoSize = true;
            this.comment_label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comment_label.Location = new System.Drawing.Point(373, 41);
            this.comment_label.Name = "comment_label";
            this.comment_label.Size = new System.Drawing.Size(215, 15);
            this.comment_label.TabIndex = 145;
            this.comment_label.Text = "※ゼロで共通設定になります";
            // 
            // tNedit_CashRegisterNo
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Right";
            this.tNedit_CashRegisterNo.ActiveAppearance = appearance5;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.tNedit_CashRegisterNo.Appearance = appearance8;
            this.tNedit_CashRegisterNo.AutoSelect = true;
            this.tNedit_CashRegisterNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CashRegisterNo.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CashRegisterNo.DataText = "";
            this.tNedit_CashRegisterNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CashRegisterNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CashRegisterNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CashRegisterNo.Location = new System.Drawing.Point(144, 83);
            this.tNedit_CashRegisterNo.MaxLength = 3;
            this.tNedit_CashRegisterNo.Name = "tNedit_CashRegisterNo";
            this.tNedit_CashRegisterNo.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CashRegisterNo.Size = new System.Drawing.Size(36, 24);
            this.tNedit_CashRegisterNo.TabIndex = 5;
            this.tNedit_CashRegisterNo.Leave += new System.EventHandler(this.tNedit_CashRegisterNo_Leave);
            // 
            // tNEdit_SectionCode
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.TextHAlignAsString = "Right";
            this.tNEdit_SectionCode.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            this.tNEdit_SectionCode.Appearance = appearance7;
            this.tNEdit_SectionCode.AutoSelect = true;
            this.tNEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNEdit_SectionCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNEdit_SectionCode.DataText = "";
            this.tNEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNEdit_SectionCode.Location = new System.Drawing.Point(144, 36);
            this.tNEdit_SectionCode.MaxLength = 2;
            this.tNEdit_SectionCode.Name = "tNEdit_SectionCode";
            this.tNEdit_SectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNEdit_SectionCode.Size = new System.Drawing.Size(28, 24);
            this.tNEdit_SectionCode.TabIndex = 2;
            this.tNEdit_SectionCode.Leave += new System.EventHandler(this.tNEdit_SectionCode_Leave);
            // 
            // PMSCM09110UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(615, 254);
            this.Controls.Add(this.tNEdit_SectionCode);
            this.Controls.Add(this.tNedit_CashRegisterNo);
            this.Controls.Add(this.comment_label);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.WarehouseNote1_Title_Label);
            this.Controls.Add(this.tEdit_MachineIpAddr);
            this.Controls.Add(this.tEdit_MachineName);
            this.Controls.Add(this.CashRegisterNo_Label);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.tEdit_SectionName);
            this.Controls.Add(this.Section_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PMSCM09110UA";
            this.Text = "同期状態表示端末設定";
            this.Load += new System.EventHandler(this.PMSCM09110UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMSCM09110UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMSCM09110UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MachineIpAddr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MachineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CashRegisterNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNEdit_SectionCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Save_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel WarehouseNote1_Title_Label;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_MachineIpAddr;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_MachineName;
        private Infragistics.Win.Misc.UltraLabel CashRegisterNo_Label;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionName;
        private Infragistics.Win.Misc.UltraLabel Section_Title_Label;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private System.Windows.Forms.Label comment_label;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CashRegisterNo;
        private Broadleaf.Library.Windows.Forms.TNedit tNEdit_SectionCode;
    }
}

