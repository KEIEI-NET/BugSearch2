using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	partial class MAKAU00139UA
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
                /* --- DEL 2008/08/07 --------------------------------------------------------------------->>>>>
				// グリッド設定保存
				if (_colDispInfo != null)
				{
					

//					_colDispInfo.DispBothTaxway = this._bufDispBothTaxway;
					_colDispInfo.SerializeData(ctFILE_ColDispInfo);
					_colDispInfo = null;
				}
                   --- DEL 2008/08/07 ---------------------------------------------------------------------<<<<<*/
                
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU00139UA));
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape1 = new Broadleaf.Library.Windows.Forms.TShape();
            this.tDateEdit_CurrentTotalMonth = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbGridFont = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tEdit_SectionName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraButton_Prepare = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton_StopPrepare = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tDateEdit_PrevTotalMonth = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Minute = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_Hour = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel_Minute = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_Hour = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_StartTime = new Infragistics.Win.Misc.UltraLabel();
            this.timer_ShowOrNot = new System.Windows.Forms.Timer(this.components);
            this.ultraLabel_Message = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Hour)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel42
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance8.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance8;
            this.ultraLabel42.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel42.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.ultraLabel42.Location = new System.Drawing.Point(76, 55);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(345, 24);
            this.ultraLabel42.TabIndex = 1019;
            this.ultraLabel42.Text = "仕入月次更新条件入力";
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
            // tDateEdit_CurrentTotalMonth
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_CurrentTotalMonth.ActiveEditAppearance = appearance3;
            this.tDateEdit_CurrentTotalMonth.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_CurrentTotalMonth.CalendarDisp = true;
            this.tDateEdit_CurrentTotalMonth.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.tDateEdit_CurrentTotalMonth.EditAppearance = appearance4;
            this.tDateEdit_CurrentTotalMonth.Enabled = false;
            this.tDateEdit_CurrentTotalMonth.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_CurrentTotalMonth.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.tDateEdit_CurrentTotalMonth.LabelAppearance = appearance11;
            this.tDateEdit_CurrentTotalMonth.Location = new System.Drawing.Point(241, 163);
            this.tDateEdit_CurrentTotalMonth.Name = "tDateEdit_CurrentTotalMonth";
            this.tDateEdit_CurrentTotalMonth.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_CurrentTotalMonth.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tDateEdit_CurrentTotalMonth.Size = new System.Drawing.Size(127, 24);
            this.tDateEdit_CurrentTotalMonth.TabIndex = 3;
            this.tDateEdit_CurrentTotalMonth.TabStop = true;
            // 
            // ultraLabel1
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance15;
            this.ultraLabel1.Location = new System.Drawing.Point(104, 163);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(125, 24);
            this.ultraLabel1.TabIndex = 1022;
            this.ultraLabel1.Text = "今回月次処理日";
            // 
            // ultraLabel2
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance10;
            this.ultraLabel2.Location = new System.Drawing.Point(104, 95);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(38, 16);
            this.ultraLabel2.TabIndex = 1054;
            this.ultraLabel2.Text = "拠点";
            this.ultraLabel2.Visible = false;
            // 
            // cmbGridFont
            // 
            this.cmbGridFont.ActiveAppearance = appearance9;
            this.cmbGridFont.Location = new System.Drawing.Point(0, 0);
            this.cmbGridFont.Name = "cmbGridFont";
            this.cmbGridFont.Size = new System.Drawing.Size(144, 21);
            this.cmbGridFont.TabIndex = 0;
            // 
            // tEdit_SectionName
            // 
            this.tEdit_SectionName.ActiveAppearance = appearance1;
            appearance2.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.tEdit_SectionName.Appearance = appearance2;
            this.tEdit_SectionName.AutoSelect = true;
            this.tEdit_SectionName.DataText = "";
            this.tEdit_SectionName.Enabled = false;
            this.tEdit_SectionName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionName.Location = new System.Drawing.Point(283, 95);
            this.tEdit_SectionName.MaxLength = 12;
            this.tEdit_SectionName.Name = "tEdit_SectionName";
            this.tEdit_SectionName.ReadOnly = true;
            this.tEdit_SectionName.Size = new System.Drawing.Size(175, 24);
            this.tEdit_SectionName.TabIndex = 1;
            this.tEdit_SectionName.Visible = false;
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
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionCode.Location = new System.Drawing.Point(241, 95);
            this.tEdit_SectionCode.MaxLength = 2;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 0;
            this.tEdit_SectionCode.Visible = false;
            // 
            // uButton_SectionGuide
            // 
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance18.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SectionGuide.Appearance = appearance18;
            this.uButton_SectionGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SectionGuide.Location = new System.Drawing.Point(468, 95);
            this.uButton_SectionGuide.Name = "uButton_SectionGuide";
            this.uButton_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SectionGuide.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_SectionGuide, ultraToolTipInfo1);
            this.uButton_SectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SectionGuide.Visible = false;
            this.uButton_SectionGuide.Click += new System.EventHandler(this.uButton_SectionGuide_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ultraButton_Prepare
            // 
            appearance21.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance21.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraButton_Prepare.Appearance = appearance21;
            this.ultraButton_Prepare.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraButton_Prepare.Location = new System.Drawing.Point(393, 207);
            this.ultraButton_Prepare.Name = "ultraButton_Prepare";
            this.ultraButton_Prepare.Size = new System.Drawing.Size(71, 26);
            this.ultraButton_Prepare.TabIndex = 1124;
            this.ultraButton_Prepare.Text = "待機(&T)";
            this.ultraButton_Prepare.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton_Prepare.Click += new System.EventHandler(this.ultraButton_Prepare_Click);
            // 
            // ultraButton_StopPrepare
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraButton_StopPrepare.Appearance = appearance12;
            this.ultraButton_StopPrepare.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraButton_StopPrepare.Location = new System.Drawing.Point(393, 207);
            this.ultraButton_StopPrepare.Name = "ultraButton_StopPrepare";
            this.ultraButton_StopPrepare.Size = new System.Drawing.Size(71, 26);
            this.ultraButton_StopPrepare.TabIndex = 1125;
            this.ultraButton_StopPrepare.Text = "中止(&T)";
            this.ultraButton_StopPrepare.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton_StopPrepare.Click += new System.EventHandler(this.ultraButton_StopPrepare_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
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
            // tDateEdit_PrevTotalMonth
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_PrevTotalMonth.ActiveEditAppearance = appearance5;
            this.tDateEdit_PrevTotalMonth.AllowDrop = true;
            this.tDateEdit_PrevTotalMonth.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_PrevTotalMonth.CalendarDisp = true;
            this.tDateEdit_PrevTotalMonth.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.tDateEdit_PrevTotalMonth.EditAppearance = appearance16;
            this.tDateEdit_PrevTotalMonth.Enabled = false;
            this.tDateEdit_PrevTotalMonth.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_PrevTotalMonth.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance17.TextHAlignAsString = "Left";
            appearance17.TextVAlignAsString = "Middle";
            this.tDateEdit_PrevTotalMonth.LabelAppearance = appearance17;
            this.tDateEdit_PrevTotalMonth.Location = new System.Drawing.Point(241, 129);
            this.tDateEdit_PrevTotalMonth.Name = "tDateEdit_PrevTotalMonth";
            this.tDateEdit_PrevTotalMonth.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_PrevTotalMonth.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tDateEdit_PrevTotalMonth.Size = new System.Drawing.Size(127, 24);
            this.tDateEdit_PrevTotalMonth.TabIndex = 1055;
            this.tDateEdit_PrevTotalMonth.TabStop = true;
            // 
            // ultraLabel3
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance13;
            this.ultraLabel3.Location = new System.Drawing.Point(104, 129);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(125, 24);
            this.ultraLabel3.TabIndex = 1056;
            this.ultraLabel3.Text = "前回月次処理日";
            // 
            // tEdit_Minute
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Minute.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance7.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Minute.Appearance = appearance7;
            this.tEdit_Minute.AutoSelect = true;
            this.tEdit_Minute.AutoSize = false;
            this.tEdit_Minute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_Minute.DataText = "";
            this.tEdit_Minute.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Minute.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_Minute.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_Minute.Location = new System.Drawing.Point(295, 207);
            this.tEdit_Minute.MaxLength = 2;
            this.tEdit_Minute.Name = "tEdit_Minute";
            this.tEdit_Minute.Size = new System.Drawing.Size(28, 24);
            this.tEdit_Minute.TabIndex = 1119;
            this.tEdit_Minute.Leave += new System.EventHandler(this.tEdit_Minute_Leave);
            // 
            // tEdit_Hour
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Hour.ActiveAppearance = appearance28;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance29.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Hour.Appearance = appearance29;
            this.tEdit_Hour.AutoSelect = true;
            this.tEdit_Hour.AutoSize = false;
            this.tEdit_Hour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_Hour.DataText = "";
            this.tEdit_Hour.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Hour.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_Hour.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_Hour.Location = new System.Drawing.Point(241, 207);
            this.tEdit_Hour.MaxLength = 2;
            this.tEdit_Hour.Name = "tEdit_Hour";
            this.tEdit_Hour.Size = new System.Drawing.Size(28, 24);
            this.tEdit_Hour.TabIndex = 1118;
            this.tEdit_Hour.Leave += new System.EventHandler(this.tEdit_Hour_Leave);
            // 
            // ultraLabel_Minute
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel_Minute.Appearance = appearance14;
            this.ultraLabel_Minute.Location = new System.Drawing.Point(329, 207);
            this.ultraLabel_Minute.Name = "ultraLabel_Minute";
            this.ultraLabel_Minute.Size = new System.Drawing.Size(25, 24);
            this.ultraLabel_Minute.TabIndex = 1122;
            this.ultraLabel_Minute.Text = "分";
            // 
            // ultraLabel_Hour
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel_Hour.Appearance = appearance19;
            this.ultraLabel_Hour.Location = new System.Drawing.Point(274, 207);
            this.ultraLabel_Hour.Name = "ultraLabel_Hour";
            this.ultraLabel_Hour.Size = new System.Drawing.Size(25, 24);
            this.ultraLabel_Hour.TabIndex = 1121;
            this.ultraLabel_Hour.Text = "時";
            // 
            // ultraLabel_StartTime
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.ultraLabel_StartTime.Appearance = appearance20;
            this.ultraLabel_StartTime.Location = new System.Drawing.Point(104, 207);
            this.ultraLabel_StartTime.Name = "ultraLabel_StartTime";
            this.ultraLabel_StartTime.Size = new System.Drawing.Size(121, 24);
            this.ultraLabel_StartTime.TabIndex = 1120;
            this.ultraLabel_StartTime.Text = "処理開始時間";
            // 
            // timer_ShowOrNot
            // 
            this.timer_ShowOrNot.Interval = 500;
            this.timer_ShowOrNot.Tick += new System.EventHandler(this.timer_ShowOrNot_Tick);
            // 
            // ultraLabel_Message
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel_Message.Appearance = appearance26;
            this.ultraLabel_Message.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Message.Location = new System.Drawing.Point(329, 290);
            this.ultraLabel_Message.Name = "ultraLabel_Message";
            this.ultraLabel_Message.Size = new System.Drawing.Size(229, 24);
            this.ultraLabel_Message.TabIndex = 1126;
            this.ultraLabel_Message.Text = "仕入月次更新　処理待機中です";
            // 
            // MAKAU00139UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(992, 734);
            this.Controls.Add(this.ultraLabel_Message);
            this.Controls.Add(this.ultraButton_StopPrepare);
            this.Controls.Add(this.ultraButton_Prepare);
            this.Controls.Add(this.tEdit_Minute);
            this.Controls.Add(this.tEdit_Hour);
            this.Controls.Add(this.ultraLabel_Minute);
            this.Controls.Add(this.ultraLabel_Hour);
            this.Controls.Add(this.ultraLabel_StartTime);
            this.Controls.Add(this.tDateEdit_PrevTotalMonth);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.uButton_SectionGuide);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.tEdit_SectionName);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.tDateEdit_CurrentTotalMonth);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tShape1);
            this.Controls.Add(this.ultraLabel42);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAKAU00139UA";
            this.Text = "仕入月次更新";
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Hour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Broadleaf.Library.Windows.Forms.TShape tShape1;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_CurrentTotalMonth;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TComboEditor cmbGridFont;
        public Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionName;
        private Infragistics.Win.Misc.UltraButton uButton_SectionGuide;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        public Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCode;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_PrevTotalMonth;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraButton ultraButton_Prepare;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Minute;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Hour;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Minute;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Hour;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_StartTime;
        private Infragistics.Win.Misc.UltraButton ultraButton_StopPrepare;
        private System.Windows.Forms.Timer timer_ShowOrNot;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Message;
	}
}
