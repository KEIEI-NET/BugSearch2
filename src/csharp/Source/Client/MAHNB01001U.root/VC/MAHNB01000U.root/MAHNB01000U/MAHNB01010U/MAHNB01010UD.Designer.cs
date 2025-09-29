namespace Broadleaf.Windows.Forms
{
	partial class MAHNB01010UD
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAHNB01010UD));
            this.tNedit_SalesSlipNum = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_SalesSlipGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Save = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tComboEditor_AcptAnOdrStatus = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.timer_InitialSetFocus = new System.Windows.Forms.Timer(this.components);
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AcptAnOdrStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tNedit_SalesSlipNum
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.TextHAlignAsString = "Right";
            this.tNedit_SalesSlipNum.ActiveAppearance = appearance1;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            this.tNedit_SalesSlipNum.Appearance = appearance2;
            this.tNedit_SalesSlipNum.AutoSelect = true;
            this.tNedit_SalesSlipNum.AutoSize = false;
            this.tNedit_SalesSlipNum.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesSlipNum.DataText = "";
            this.tNedit_SalesSlipNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesSlipNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesSlipNum.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesSlipNum.Location = new System.Drawing.Point(178, 9);
            this.tNedit_SalesSlipNum.MaxLength = 9;
            this.tNedit_SalesSlipNum.Name = "tNedit_SalesSlipNum";
            this.tNedit_SalesSlipNum.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SalesSlipNum.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SalesSlipNum.TabIndex = 1;
            // 
            // ultraLabel3
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance3;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 9);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel3.TabIndex = 24;
            this.ultraLabel3.Text = "伝票番号";
            // 
            // uButton_SalesSlipGuide
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesSlipGuide.Appearance = appearance4;
            this.uButton_SalesSlipGuide.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_SalesSlipGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesSlipGuide.Location = new System.Drawing.Point(262, 9);
            this.uButton_SalesSlipGuide.Name = "uButton_SalesSlipGuide";
            this.uButton_SalesSlipGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesSlipGuide.TabIndex = 2;
            this.toolTip1.SetToolTip(this.uButton_SalesSlipGuide, "売上伝票検索");
            this.uButton_SalesSlipGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesSlipGuide.Click += new System.EventHandler(this.uButton_SalesSlipGuide_Click);
            // 
            // uButton_Save
            // 
            this.uButton_Save.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Save.Location = new System.Drawing.Point(135, 39);
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
            this.uButton_Close.Location = new System.Drawing.Point(211, 39);
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
            // tComboEditor_AcptAnOdrStatus
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AcptAnOdrStatus.ActiveAppearance = appearance5;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tComboEditor_AcptAnOdrStatus.Appearance = appearance6;
            this.tComboEditor_AcptAnOdrStatus.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AcptAnOdrStatus.ItemAppearance = appearance7;
            valueListItem1.DataValue = 30;
            valueListItem1.DisplayText = "売上";
            valueListItem1.Tag = 3;
            valueListItem2.DataValue = 20;
            valueListItem2.DisplayText = "受注";
            valueListItem2.Tag = 2;
            valueListItem3.DataValue = 40;
            valueListItem3.DisplayText = "貸出";
            valueListItem3.Tag = 4;
            valueListItem4.DataValue = 10;
            valueListItem4.DisplayText = "見積";
            valueListItem4.Tag = 1;
            this.tComboEditor_AcptAnOdrStatus.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.tComboEditor_AcptAnOdrStatus.Location = new System.Drawing.Point(79, 9);
            this.tComboEditor_AcptAnOdrStatus.Name = "tComboEditor_AcptAnOdrStatus";
            this.tComboEditor_AcptAnOdrStatus.Size = new System.Drawing.Size(93, 24);
            this.tComboEditor_AcptAnOdrStatus.TabIndex = 0;
            // 
            // timer_InitialSetFocus
            // 
            this.timer_InitialSetFocus.Interval = 1;
            this.timer_InitialSetFocus.Tick += new System.EventHandler(this.timer_InitialSetFocus_Tick);
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 73);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            this.uStatusBar_Main.Size = new System.Drawing.Size(294, 23);
            this.uStatusBar_Main.TabIndex = 54;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // MAHNB01010UD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(294, 96);
            this.Controls.Add(this.uStatusBar_Main);
            this.Controls.Add(this.tComboEditor_AcptAnOdrStatus);
            this.Controls.Add(this.uButton_Close);
            this.Controls.Add(this.uButton_Save);
            this.Controls.Add(this.tNedit_SalesSlipNum);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.uButton_SalesSlipGuide);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAHNB01010UD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伝票番号入力";
            this.Load += new System.EventHandler(this.MAKON01110UD_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAKON01110UD_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AcptAnOdrStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Broadleaf.Library.Windows.Forms.TNedit tNedit_SalesSlipNum;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraButton uButton_SalesSlipGuide;
		private Infragistics.Win.Misc.UltraButton uButton_Save;
		private Infragistics.Win.Misc.UltraButton uButton_Close;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_AcptAnOdrStatus;
		private System.Windows.Forms.Timer timer_InitialSetFocus;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
		private System.Windows.Forms.ToolTip toolTip1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;


	}
}