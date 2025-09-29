namespace Broadleaf.Windows.Forms
{
	partial class DCKHN09140UA
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09140UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.tAttack251 = new Broadleaf.Library.Windows.Forms.TAttack25(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.uButton_CustomerGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_CustomerName = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.CreditMoney_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.WarningCreditMoney_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PrsntAccRecBalance_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreditMoney_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarningCreditMoney_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrsntAccRecBalance_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 242);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(521, 23);
            this.ultraStatusBar1.TabIndex = 36;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(257, 9);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(384, 9);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 15;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(409, 3);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 11;
            this.Mode_Label.Text = "更新モード";
            // 
            // CustomerCode_Title_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.CustomerCode_Title_Label.Appearance = appearance3;
            this.CustomerCode_Title_Label.Location = new System.Drawing.Point(12, 31);
            this.CustomerCode_Title_Label.Name = "CustomerCode_Title_Label";
            this.CustomerCode_Title_Label.Size = new System.Drawing.Size(150, 24);
            this.CustomerCode_Title_Label.TabIndex = 8;
            this.CustomerCode_Title_Label.Text = "得意先コード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(3, 9);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 12;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(130, 9);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 13;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // tAttack251
            // 
            this.tAttack251.OwnerForm = this;
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
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Location = new System.Drawing.Point(0, 195);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(521, 47);
            this.Button_Panel.TabIndex = 12;
            // 
            // uButton_CustomerGuide
            // 
            appearance33.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance33.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CustomerGuide.Appearance = appearance33;
            this.uButton_CustomerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CustomerGuide.Location = new System.Drawing.Point(261, 31);
            this.uButton_CustomerGuide.Name = "uButton_CustomerGuide";
            this.uButton_CustomerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CustomerGuide.TabIndex = 2;
            this.uButton_CustomerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CustomerGuide.Click += new System.EventHandler(this.uButton_CustomerGuide_Click);
            // 
            // uLabel_CustomerName
            // 
            appearance32.BackColor = System.Drawing.SystemColors.Control;
            appearance32.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.uLabel_CustomerName.Appearance = appearance32;
            this.uLabel_CustomerName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_CustomerName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_CustomerName.Location = new System.Drawing.Point(287, 32);
            this.uLabel_CustomerName.Name = "uLabel_CustomerName";
            this.uLabel_CustomerName.Size = new System.Drawing.Size(224, 23);
            this.uLabel_CustomerName.TabIndex = 1306;
            this.uLabel_CustomerName.WrapText = false;
            // 
            // tNedit_CustomerCode
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance30.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.ActiveAppearance = appearance30;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            appearance31.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance31;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(175, 31);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode.TabIndex = 1;
            this.tNedit_CustomerCode.Leave += new System.EventHandler(this.tNedit_CustomerCode_Leave);
            // 
            // ultraLabel6
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance24;
            this.ultraLabel6.Location = new System.Drawing.Point(12, 140);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(169, 24);
            this.ultraLabel6.TabIndex = 1312;
            this.ultraLabel6.Text = "現在売掛残高";
            // 
            // ultraLabel7
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance23;
            this.ultraLabel7.Location = new System.Drawing.Point(12, 110);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(169, 24);
            this.ultraLabel7.TabIndex = 1313;
            this.ultraLabel7.Text = "警告与信額";
            // 
            // ultraLabel8
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance22;
            this.ultraLabel8.Location = new System.Drawing.Point(12, 80);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(169, 24);
            this.ultraLabel8.TabIndex = 1314;
            this.ultraLabel8.Text = "与信額";
            // 
            // CreditMoney_tNedit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            this.CreditMoney_tNedit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.White;
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            this.CreditMoney_tNedit.Appearance = appearance17;
            this.CreditMoney_tNedit.AutoSelect = true;
            this.CreditMoney_tNedit.BackColor = System.Drawing.Color.White;
            this.CreditMoney_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CreditMoney_tNedit.DataText = "";
            this.CreditMoney_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CreditMoney_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CreditMoney_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CreditMoney_tNedit.Location = new System.Drawing.Point(175, 80);
            this.CreditMoney_tNedit.MaxLength = 12;
            this.CreditMoney_tNedit.Name = "CreditMoney_tNedit";
            this.CreditMoney_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CreditMoney_tNedit.Size = new System.Drawing.Size(105, 24);
            this.CreditMoney_tNedit.TabIndex = 3;
            // 
            // WarningCreditMoney_tNedit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            this.WarningCreditMoney_tNedit.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.White;
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            this.WarningCreditMoney_tNedit.Appearance = appearance15;
            this.WarningCreditMoney_tNedit.AutoSelect = true;
            this.WarningCreditMoney_tNedit.BackColor = System.Drawing.Color.White;
            this.WarningCreditMoney_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.WarningCreditMoney_tNedit.DataText = "123456789";
            this.WarningCreditMoney_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WarningCreditMoney_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.WarningCreditMoney_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.WarningCreditMoney_tNedit.Location = new System.Drawing.Point(175, 110);
            this.WarningCreditMoney_tNedit.MaxLength = 12;
            this.WarningCreditMoney_tNedit.Name = "WarningCreditMoney_tNedit";
            this.WarningCreditMoney_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.WarningCreditMoney_tNedit.Size = new System.Drawing.Size(105, 24);
            this.WarningCreditMoney_tNedit.TabIndex = 4;
            this.WarningCreditMoney_tNedit.Text = "123,456,789";
            // 
            // PrsntAccRecBalance_tNedit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Right";
            this.PrsntAccRecBalance_tNedit.ActiveAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            this.PrsntAccRecBalance_tNedit.Appearance = appearance13;
            this.PrsntAccRecBalance_tNedit.AutoSelect = true;
            this.PrsntAccRecBalance_tNedit.BackColor = System.Drawing.Color.White;
            this.PrsntAccRecBalance_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrsntAccRecBalance_tNedit.DataText = "";
            this.PrsntAccRecBalance_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrsntAccRecBalance_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PrsntAccRecBalance_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrsntAccRecBalance_tNedit.Location = new System.Drawing.Point(175, 140);
            this.PrsntAccRecBalance_tNedit.MaxLength = 12;
            this.PrsntAccRecBalance_tNedit.Name = "PrsntAccRecBalance_tNedit";
            this.PrsntAccRecBalance_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PrsntAccRecBalance_tNedit.Size = new System.Drawing.Size(105, 24);
            this.PrsntAccRecBalance_tNedit.TabIndex = 5;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(9, 66);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(503, 3);
            this.DivideLine_Label.TabIndex = 1327;
            // 
            // DCKHN09140UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(521, 265);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.PrsntAccRecBalance_tNedit);
            this.Controls.Add(this.WarningCreditMoney_tNedit);
            this.Controls.Add(this.CreditMoney_tNedit);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.tNedit_CustomerCode);
            this.Controls.Add(this.uLabel_CustomerName);
            this.Controls.Add(this.uButton_CustomerGuide);
            this.Controls.Add(this.CustomerCode_Title_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DCKHN09140UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "得意先マスタ(変動情報)";
            this.Load += new System.EventHandler(this.DCKHN09140UA_Load);
            this.VisibleChanged += new System.EventHandler(this.DCKHN09140UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DCKHN09140UA_FormClosing);
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreditMoney_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarningCreditMoney_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrsntAccRecBalance_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel CustomerCode_Title_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Broadleaf.Library.Windows.Forms.TAttack25 tAttack251;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Timer Initial_Timer;
        private System.Windows.Forms.Panel Button_Panel;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerName;
        private Infragistics.Win.Misc.UltraButton uButton_CustomerGuide;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Broadleaf.Library.Windows.Forms.TNedit PrsntAccRecBalance_tNedit;
        private Broadleaf.Library.Windows.Forms.TNedit WarningCreditMoney_tNedit;
        private Broadleaf.Library.Windows.Forms.TNedit CreditMoney_tNedit;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
	}
}

