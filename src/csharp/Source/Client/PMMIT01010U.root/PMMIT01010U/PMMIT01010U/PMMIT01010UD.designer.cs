namespace Broadleaf.Windows.Forms
{
	partial class PMMIT01010UD
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMMIT01010UD));
            this.uButton_Save = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.timer_InitialSetFocus = new System.Windows.Forms.Timer(this.components);
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uButton_SalesSlipGuide = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_SalesSlipNum = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SalesSlipNum ) ).BeginInit();
            this.SuspendLayout();
            // 
            // uButton_Save
            // 
            this.uButton_Save.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uButton_Save.Location = new System.Drawing.Point(37, 42);
            this.uButton_Save.Name = "uButton_Save";
            this.uButton_Save.Size = new System.Drawing.Size(75, 25);
            this.uButton_Save.TabIndex = 6;
            this.uButton_Save.Text = "確定(&S)";
            this.uButton_Save.Click += new System.EventHandler(this.uButton_Save_Click);
            // 
            // uButton_Close
            // 
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uButton_Close.Location = new System.Drawing.Point(118, 42);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(75, 25);
            this.uButton_Close.TabIndex = 7;
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
            // timer_InitialSetFocus
            // 
            this.timer_InitialSetFocus.Interval = 1;
            this.timer_InitialSetFocus.Tick += new System.EventHandler(this.timer_InitialSetFocus_Tick);
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 74);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            this.uStatusBar_Main.Size = new System.Drawing.Size(207, 23);
            this.uStatusBar_Main.TabIndex = 54;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // uButton_SalesSlipGuide
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesSlipGuide.Appearance = appearance4;
            this.uButton_SalesSlipGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uButton_SalesSlipGuide.Location = new System.Drawing.Point(169, 12);
            this.uButton_SalesSlipGuide.Name = "uButton_SalesSlipGuide";
            this.uButton_SalesSlipGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesSlipGuide.TabIndex = 56;
            this.toolTip1.SetToolTip(this.uButton_SalesSlipGuide, "仕入伝票検索");
            this.uButton_SalesSlipGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesSlipGuide.Click += new System.EventHandler(this.uButton_SalesSlipGuide_Click);
            // 
            // tNedit_SalesSlipNum
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
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
            this.tNedit_SalesSlipNum.Location = new System.Drawing.Point(85, 12);
            this.tNedit_SalesSlipNum.MaxLength = 9;
            this.tNedit_SalesSlipNum.Name = "tNedit_SalesSlipNum";
            this.tNedit_SalesSlipNum.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SalesSlipNum.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SalesSlipNum.TabIndex = 55;
            // 
            // ultraLabel3
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance3;
            this.ultraLabel3.Location = new System.Drawing.Point(12, 12);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel3.TabIndex = 57;
            this.ultraLabel3.Text = "伝票番号";
            // 
            // PMMIT01010UD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 254 ) ) ) ));
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(207, 97);
            this.Controls.Add(this.tNedit_SalesSlipNum);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.uButton_SalesSlipGuide);
            this.Controls.Add(this.uStatusBar_Main);
            this.Controls.Add(this.uButton_Close);
            this.Controls.Add(this.uButton_Save);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMMIT01010UD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伝票番号入力";
            this.Load += new System.EventHandler(this.PMMIT01010UD_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMMIT01010UD_FormClosed);
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SalesSlipNum ) ).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Infragistics.Win.Misc.UltraButton uButton_Save;
		private Infragistics.Win.Misc.UltraButton uButton_Close;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer timer_InitialSetFocus;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
        private System.Windows.Forms.ToolTip toolTip1;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SalesSlipNum;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraButton uButton_SalesSlipGuide;


	}
}