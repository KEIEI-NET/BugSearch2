using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	partial class MAKAU00149UA
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
                /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
				// グリッド設定保存
				if (_colDispInfo != null)
				{
					

//					_colDispInfo.DispBothTaxway = this._bufDispBothTaxway;
					_colDispInfo.SerializeData(ctFILE_ColDispInfo);
					_colDispInfo = null;
				}
                   --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
                /*
                                // 仕入管理アクセスクラスイベントハンドラ削除
                                if (this._stockMngAcs != null)
                                {
                                    this._stockMngAcs.RemoveInfoChangeStockMngEvent(this.InfoChangeStockMngEvent);
                                    this._stockMngAcs.RemoveInfoNewEntryStockMngEvent(this.InfoNewEntryStockMngEvent);
                                }
                */
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
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU00149UA));
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape1 = new Broadleaf.Library.Windows.Forms.TShape();
            this.tDateEdit_CAddUpUpdDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_TotalDay = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbGridFont = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tEdit_SectionName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.tDateEdit_LastCAddUpUpdDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_TotalDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // ultraLabel42
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance49.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance49.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance49.FontData.BoldAsString = "True";
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.TextHAlignAsString = "Center";
            appearance49.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance49;
            this.ultraLabel42.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel42.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.ultraLabel42.Location = new System.Drawing.Point(76, 55);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(345, 24);
            this.ultraLabel42.TabIndex = 1019;
            this.ultraLabel42.Text = "仕入締次更新処理条件入力";
            // 
            // tShape1
            // 
            this.tShape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tShape1.ForeColor = System.Drawing.Color.Blue;
            this.tShape1.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape1.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape1.Location = new System.Drawing.Point(76, 78);
            this.tShape1.Name = "tShape1";
            this.tShape1.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape1.Size = new System.Drawing.Size(809, 474);
            this.tShape1.TabIndex = 1020;
            this.tShape1.Text = "tShape1";
            // 
            // tDateEdit_CAddUpUpdDate
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            this.tDateEdit_CAddUpUpdDate.ActiveEditAppearance = appearance46;
            this.tDateEdit_CAddUpUpdDate.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_CAddUpUpdDate.CalendarDisp = true;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Left";
            appearance47.TextVAlignAsString = "Middle";
            this.tDateEdit_CAddUpUpdDate.EditAppearance = appearance47;
            this.tDateEdit_CAddUpUpdDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_CAddUpUpdDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance48.TextHAlignAsString = "Left";
            appearance48.TextVAlignAsString = "Middle";
            this.tDateEdit_CAddUpUpdDate.LabelAppearance = appearance48;
            this.tDateEdit_CAddUpUpdDate.Location = new System.Drawing.Point(220, 163);
            this.tDateEdit_CAddUpUpdDate.Name = "tDateEdit_CAddUpUpdDate";
            this.tDateEdit_CAddUpUpdDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_CAddUpUpdDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tDateEdit_CAddUpUpdDate.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_CAddUpUpdDate.TabIndex = 4;
            this.tDateEdit_CAddUpUpdDate.TabStop = true;
            // 
            // ultraLabel1
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance3;
            this.ultraLabel1.Location = new System.Drawing.Point(104, 163);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel1.TabIndex = 1022;
            this.ultraLabel1.Text = "今回締処理日";
            // 
            // ultraLabel2
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance9;
            this.ultraLabel2.Location = new System.Drawing.Point(104, 95);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(38, 24);
            this.ultraLabel2.TabIndex = 1054;
            this.ultraLabel2.Text = "拠点";
            this.ultraLabel2.Visible = false;
            // 
            // tNedit_TotalDay
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            this.tNedit_TotalDay.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            appearance24.TextHAlignAsString = "Right";
            this.tNedit_TotalDay.Appearance = appearance24;
            this.tNedit_TotalDay.AutoSelect = true;
            this.tNedit_TotalDay.AutoSize = false;
            this.tNedit_TotalDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_TotalDay.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_TotalDay.DataText = "";
            this.tNedit_TotalDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_TotalDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_TotalDay.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_TotalDay.Location = new System.Drawing.Point(220, 197);
            this.tNedit_TotalDay.MaxLength = 9;
            this.tNedit_TotalDay.Name = "tNedit_TotalDay";
            this.tNedit_TotalDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_TotalDay.Size = new System.Drawing.Size(35, 24);
            this.tNedit_TotalDay.TabIndex = 5;
            // 
            // ultraLabel3
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance6;
            this.ultraLabel3.Location = new System.Drawing.Point(104, 197);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(72, 24);
            this.ultraLabel3.TabIndex = 1058;
            this.ultraLabel3.Text = "対象締日";
            // 
            // ultraLabel4
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance8;
            this.ultraLabel4.Location = new System.Drawing.Point(261, 197);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(17, 24);
            this.ultraLabel4.TabIndex = 1059;
            this.ultraLabel4.Text = "日";
            // 
            // cmbGridFont
            // 
            this.cmbGridFont.ActiveAppearance = appearance50;
            this.cmbGridFont.Location = new System.Drawing.Point(0, 0);
            this.cmbGridFont.Name = "cmbGridFont";
            this.cmbGridFont.Size = new System.Drawing.Size(144, 21);
            this.cmbGridFont.TabIndex = 0;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tEdit_SectionName
            // 
            this.tEdit_SectionName.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.Gainsboro;
            appearance5.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionName.Appearance = appearance5;
            this.tEdit_SectionName.AutoSelect = true;
            this.tEdit_SectionName.BackColor = System.Drawing.Color.Gainsboro;
            this.tEdit_SectionName.DataText = "";
            this.tEdit_SectionName.Enabled = false;
            this.tEdit_SectionName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionName.Location = new System.Drawing.Point(262, 95);
            this.tEdit_SectionName.MaxLength = 12;
            this.tEdit_SectionName.Name = "tEdit_SectionName";
            this.tEdit_SectionName.Size = new System.Drawing.Size(175, 24);
            this.tEdit_SectionName.TabIndex = 1;
            this.tEdit_SectionName.Visible = false;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // tEdit_SectionCode
            // 
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance76.ForeColor = System.Drawing.Color.Black;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.ActiveAppearance = appearance76;
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance77.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance77.ForeColorDisabled = System.Drawing.Color.Black;
            appearance77.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.tEdit_SectionCode.Appearance = appearance77;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionCode.Location = new System.Drawing.Point(220, 95);
            this.tEdit_SectionCode.MaxLength = 12;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 0;
            this.tEdit_SectionCode.Visible = false;
            // 
            // uButton_SectionGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SectionGuide.Appearance = appearance12;
            this.uButton_SectionGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SectionGuide.Location = new System.Drawing.Point(443, 95);
            this.uButton_SectionGuide.Name = "uButton_SectionGuide";
            this.uButton_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SectionGuide.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_SectionGuide, ultraToolTipInfo1);
            this.uButton_SectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SectionGuide.Visible = false;
            this.uButton_SectionGuide.Click += new System.EventHandler(this.uButton_SectionGuide_Click);
            // 
            // tDateEdit_LastCAddUpUpdDate
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            this.tDateEdit_LastCAddUpUpdDate.ActiveEditAppearance = appearance53;
            this.tDateEdit_LastCAddUpUpdDate.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_LastCAddUpUpdDate.CalendarDisp = true;
            appearance54.BackColor = System.Drawing.Color.Gainsboro;
            appearance54.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance54.ForeColor = System.Drawing.Color.Black;
            appearance54.ForeColorDisabled = System.Drawing.Color.Black;
            appearance54.TextHAlignAsString = "Left";
            appearance54.TextVAlignAsString = "Middle";
            this.tDateEdit_LastCAddUpUpdDate.EditAppearance = appearance54;
            this.tDateEdit_LastCAddUpUpdDate.Enabled = false;
            this.tDateEdit_LastCAddUpUpdDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_LastCAddUpUpdDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance55.TextHAlignAsString = "Left";
            appearance55.TextVAlignAsString = "Middle";
            this.tDateEdit_LastCAddUpUpdDate.LabelAppearance = appearance55;
            this.tDateEdit_LastCAddUpUpdDate.Location = new System.Drawing.Point(220, 129);
            this.tDateEdit_LastCAddUpUpdDate.Name = "tDateEdit_LastCAddUpUpdDate";
            this.tDateEdit_LastCAddUpUpdDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_LastCAddUpUpdDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tDateEdit_LastCAddUpUpdDate.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_LastCAddUpUpdDate.TabIndex = 3;
            this.tDateEdit_LastCAddUpUpdDate.TabStop = true;
            // 
            // ultraLabel5
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance7;
            this.ultraLabel5.Location = new System.Drawing.Point(104, 129);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel5.TabIndex = 1104;
            this.ultraLabel5.Text = "前回締処理日";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // MAKAU00149UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(992, 734);
            this.Controls.Add(this.tDateEdit_LastCAddUpUpdDate);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.uButton_SectionGuide);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.tEdit_SectionName);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.tNedit_TotalDay);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.tDateEdit_CAddUpUpdDate);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tShape1);
            this.Controls.Add(this.ultraLabel42);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAKAU00149UA";
            this.Text = "仕入締次更新";
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_TotalDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Broadleaf.Library.Windows.Forms.TShape tShape1;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_CAddUpUpdDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_TotalDay;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Broadleaf.Library.Windows.Forms.TComboEditor cmbGridFont;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        public Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionName;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton uButton_SectionGuide;
        public Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCode;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_LastCAddUpUpdDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
	}
}