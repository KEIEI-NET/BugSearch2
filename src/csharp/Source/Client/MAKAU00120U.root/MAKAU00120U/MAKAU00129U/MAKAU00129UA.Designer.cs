using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	partial class MAKAU00129UA
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
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU00129UA));
            this.timFontChange = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tArrowKeyControl2 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tipGuide = new System.Windows.Forms.ToolTip(this.components);
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape1 = new Broadleaf.Library.Windows.Forms.TShape();
            this.tDateEdit1 = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Customer01_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer02_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer03_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer04_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode4_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer05_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode5_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer06_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode6_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer07_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode7_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer08_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode8_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer09_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode9_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer10_uButton = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode10_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.Target_uOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.TotalDay_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbGridFont = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.LastDay_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tRetKeyControl2 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Section_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm6_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm5_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm10_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm9_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm8_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerNm7_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode1_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode3_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode4_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode5_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode6_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode7_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode8_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode9_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode10_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Target_uOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDay_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm6_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm5_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm10_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm9_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm8_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm7_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // timFontChange
            // 
            this.timFontChange.Interval = 10;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tArrowKeyControl2
            // 
            this.tArrowKeyControl2.OwnerForm = this;
            // 
            // ultraLabel42
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance49.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance49.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance49.FontData.BoldAsString = "True";
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance49.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel42.Appearance = appearance49;
            this.ultraLabel42.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel42.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.ultraLabel42.Location = new System.Drawing.Point(76, 55);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(345, 24);
            this.ultraLabel42.TabIndex = 1019;
            this.ultraLabel42.Text = "請求準備処理条件入力";
            // 
            // tShape1
            // 
            this.tShape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tShape1.ForeColor = System.Drawing.Color.Blue;
            this.tShape1.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape1.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape1.Location = new System.Drawing.Point(76, 79);
            this.tShape1.Name = "tShape1";
            this.tShape1.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape1.Size = new System.Drawing.Size(809, 474);
            this.tShape1.TabIndex = 1020;
            this.tShape1.Text = "tShape1";
            // 
            // tDateEdit1
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit1.ActiveEditAppearance = appearance46;
            this.tDateEdit1.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit1.CalendarDisp = true;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance47.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance47.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.tDateEdit1.EditAppearance = appearance47;
            this.tDateEdit1.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance48.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance48.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.tDateEdit1.LabelAppearance = appearance48;
            this.tDateEdit1.Location = new System.Drawing.Point(223, 430);
            this.tDateEdit1.Name = "tDateEdit1";
            this.tDateEdit1.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit1.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tDateEdit1.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit1.TabIndex = 25;
            this.tDateEdit1.TabStop = true;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(104, 438);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(125, 16);
            this.ultraLabel1.TabIndex = 1022;
            this.ultraLabel1.Text = "準備処理年月日";
            // 
            // Customer01_uButton
            // 
            this.Customer01_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer01_uButton.Location = new System.Drawing.Point(193, 260);
            this.Customer01_uButton.Name = "Customer01_uButton";
            this.Customer01_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer01_uButton.TabIndex = 6;
            this.Customer01_uButton.Tag = "";
            // 
            // CustomerCode1_tNedit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode1_tNedit.ActiveAppearance = appearance44;
            appearance45.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode1_tNedit.Appearance = appearance45;
            this.CustomerCode1_tNedit.AutoSelect = true;
            this.CustomerCode1_tNedit.AutoSize = false;
            this.CustomerCode1_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode1_tNedit.DataText = "";
            this.CustomerCode1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode1_tNedit.Location = new System.Drawing.Point(104, 260);
            this.CustomerCode1_tNedit.MaxLength = 9;
            this.CustomerCode1_tNedit.Name = "CustomerCode1_tNedit";
            this.CustomerCode1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode1_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode1_tNedit.TabIndex = 5;
            // 
            // Customer02_uButton
            // 
            this.Customer02_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer02_uButton.Location = new System.Drawing.Point(193, 290);
            this.Customer02_uButton.Name = "Customer02_uButton";
            this.Customer02_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer02_uButton.TabIndex = 8;
            this.Customer02_uButton.Tag = "";
            // 
            // CustomerCode2_tNedit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode2_tNedit.ActiveAppearance = appearance42;
            appearance43.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode2_tNedit.Appearance = appearance43;
            this.CustomerCode2_tNedit.AutoSelect = true;
            this.CustomerCode2_tNedit.AutoSize = false;
            this.CustomerCode2_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode2_tNedit.DataText = "";
            this.CustomerCode2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode2_tNedit.Location = new System.Drawing.Point(104, 290);
            this.CustomerCode2_tNedit.MaxLength = 9;
            this.CustomerCode2_tNedit.Name = "CustomerCode2_tNedit";
            this.CustomerCode2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode2_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode2_tNedit.TabIndex = 7;
            // 
            // Customer03_uButton
            // 
            this.Customer03_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer03_uButton.Location = new System.Drawing.Point(193, 320);
            this.Customer03_uButton.Name = "Customer03_uButton";
            this.Customer03_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer03_uButton.TabIndex = 10;
            this.Customer03_uButton.Tag = "";
            // 
            // CustomerCode3_tNedit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode3_tNedit.ActiveAppearance = appearance40;
            appearance41.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode3_tNedit.Appearance = appearance41;
            this.CustomerCode3_tNedit.AutoSelect = true;
            this.CustomerCode3_tNedit.AutoSize = false;
            this.CustomerCode3_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode3_tNedit.DataText = "";
            this.CustomerCode3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode3_tNedit.Location = new System.Drawing.Point(104, 320);
            this.CustomerCode3_tNedit.MaxLength = 9;
            this.CustomerCode3_tNedit.Name = "CustomerCode3_tNedit";
            this.CustomerCode3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode3_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode3_tNedit.TabIndex = 9;
            // 
            // Customer04_uButton
            // 
            this.Customer04_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer04_uButton.Location = new System.Drawing.Point(193, 350);
            this.Customer04_uButton.Name = "Customer04_uButton";
            this.Customer04_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer04_uButton.TabIndex = 12;
            this.Customer04_uButton.Tag = "";
            // 
            // CustomerCode4_tNedit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode4_tNedit.ActiveAppearance = appearance38;
            appearance39.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode4_tNedit.Appearance = appearance39;
            this.CustomerCode4_tNedit.AutoSelect = true;
            this.CustomerCode4_tNedit.AutoSize = false;
            this.CustomerCode4_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode4_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode4_tNedit.DataText = "";
            this.CustomerCode4_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode4_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode4_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode4_tNedit.Location = new System.Drawing.Point(104, 350);
            this.CustomerCode4_tNedit.MaxLength = 9;
            this.CustomerCode4_tNedit.Name = "CustomerCode4_tNedit";
            this.CustomerCode4_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode4_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode4_tNedit.TabIndex = 11;
            // 
            // Customer05_uButton
            // 
            this.Customer05_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer05_uButton.Location = new System.Drawing.Point(193, 380);
            this.Customer05_uButton.Name = "Customer05_uButton";
            this.Customer05_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer05_uButton.TabIndex = 14;
            this.Customer05_uButton.Tag = "";
            // 
            // CustomerCode5_tNedit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode5_tNedit.ActiveAppearance = appearance36;
            appearance37.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode5_tNedit.Appearance = appearance37;
            this.CustomerCode5_tNedit.AutoSelect = true;
            this.CustomerCode5_tNedit.AutoSize = false;
            this.CustomerCode5_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode5_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode5_tNedit.DataText = "";
            this.CustomerCode5_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode5_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode5_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode5_tNedit.Location = new System.Drawing.Point(104, 380);
            this.CustomerCode5_tNedit.MaxLength = 9;
            this.CustomerCode5_tNedit.Name = "CustomerCode5_tNedit";
            this.CustomerCode5_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode5_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode5_tNedit.TabIndex = 13;
            // 
            // Customer06_uButton
            // 
            this.Customer06_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer06_uButton.Location = new System.Drawing.Point(604, 260);
            this.Customer06_uButton.Name = "Customer06_uButton";
            this.Customer06_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer06_uButton.TabIndex = 16;
            this.Customer06_uButton.Tag = "";
            // 
            // CustomerCode6_tNedit
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode6_tNedit.ActiveAppearance = appearance34;
            appearance35.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode6_tNedit.Appearance = appearance35;
            this.CustomerCode6_tNedit.AutoSelect = true;
            this.CustomerCode6_tNedit.AutoSize = false;
            this.CustomerCode6_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode6_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode6_tNedit.DataText = "";
            this.CustomerCode6_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode6_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode6_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode6_tNedit.Location = new System.Drawing.Point(516, 260);
            this.CustomerCode6_tNedit.MaxLength = 9;
            this.CustomerCode6_tNedit.Name = "CustomerCode6_tNedit";
            this.CustomerCode6_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode6_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode6_tNedit.TabIndex = 15;
            // 
            // Customer07_uButton
            // 
            this.Customer07_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer07_uButton.Location = new System.Drawing.Point(604, 290);
            this.Customer07_uButton.Name = "Customer07_uButton";
            this.Customer07_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer07_uButton.TabIndex = 18;
            this.Customer07_uButton.Tag = "";
            // 
            // CustomerCode7_tNedit
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode7_tNedit.ActiveAppearance = appearance32;
            appearance33.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode7_tNedit.Appearance = appearance33;
            this.CustomerCode7_tNedit.AutoSelect = true;
            this.CustomerCode7_tNedit.AutoSize = false;
            this.CustomerCode7_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode7_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode7_tNedit.DataText = "";
            this.CustomerCode7_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode7_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode7_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode7_tNedit.Location = new System.Drawing.Point(516, 290);
            this.CustomerCode7_tNedit.MaxLength = 9;
            this.CustomerCode7_tNedit.Name = "CustomerCode7_tNedit";
            this.CustomerCode7_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode7_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode7_tNedit.TabIndex = 17;
            // 
            // Customer08_uButton
            // 
            this.Customer08_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer08_uButton.Location = new System.Drawing.Point(604, 320);
            this.Customer08_uButton.Name = "Customer08_uButton";
            this.Customer08_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer08_uButton.TabIndex = 20;
            this.Customer08_uButton.Tag = "";
            // 
            // CustomerCode8_tNedit
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode8_tNedit.ActiveAppearance = appearance30;
            appearance31.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode8_tNedit.Appearance = appearance31;
            this.CustomerCode8_tNedit.AutoSelect = true;
            this.CustomerCode8_tNedit.AutoSize = false;
            this.CustomerCode8_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode8_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode8_tNedit.DataText = "";
            this.CustomerCode8_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode8_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode8_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode8_tNedit.Location = new System.Drawing.Point(516, 320);
            this.CustomerCode8_tNedit.MaxLength = 9;
            this.CustomerCode8_tNedit.Name = "CustomerCode8_tNedit";
            this.CustomerCode8_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode8_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode8_tNedit.TabIndex = 19;
            // 
            // Customer09_uButton
            // 
            this.Customer09_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer09_uButton.Location = new System.Drawing.Point(604, 350);
            this.Customer09_uButton.Name = "Customer09_uButton";
            this.Customer09_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer09_uButton.TabIndex = 22;
            this.Customer09_uButton.Tag = "";
            // 
            // CustomerCode9_tNedit
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode9_tNedit.ActiveAppearance = appearance28;
            appearance29.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode9_tNedit.Appearance = appearance29;
            this.CustomerCode9_tNedit.AutoSelect = true;
            this.CustomerCode9_tNedit.AutoSize = false;
            this.CustomerCode9_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode9_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode9_tNedit.DataText = "";
            this.CustomerCode9_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode9_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode9_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode9_tNedit.Location = new System.Drawing.Point(516, 350);
            this.CustomerCode9_tNedit.MaxLength = 9;
            this.CustomerCode9_tNedit.Name = "CustomerCode9_tNedit";
            this.CustomerCode9_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode9_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode9_tNedit.TabIndex = 21;
            // 
            // Customer10_uButton
            // 
            this.Customer10_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer10_uButton.Location = new System.Drawing.Point(604, 380);
            this.Customer10_uButton.Name = "Customer10_uButton";
            this.Customer10_uButton.Size = new System.Drawing.Size(24, 24);
            this.Customer10_uButton.TabIndex = 24;
            this.Customer10_uButton.Tag = "";
            // 
            // CustomerCode10_tNedit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCode10_tNedit.ActiveAppearance = appearance26;
            appearance27.TextHAlign = Infragistics.Win.HAlign.Right;
            this.CustomerCode10_tNedit.Appearance = appearance27;
            this.CustomerCode10_tNedit.AutoSelect = true;
            this.CustomerCode10_tNedit.AutoSize = false;
            this.CustomerCode10_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.CustomerCode10_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode10_tNedit.DataText = "";
            this.CustomerCode10_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode10_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerCode10_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerCode10_tNedit.Location = new System.Drawing.Point(516, 380);
            this.CustomerCode10_tNedit.MaxLength = 9;
            this.CustomerCode10_tNedit.Name = "CustomerCode10_tNedit";
            this.CustomerCode10_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerCode10_tNedit.Size = new System.Drawing.Size(82, 24);
            this.CustomerCode10_tNedit.TabIndex = 23;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(104, 101);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(38, 16);
            this.ultraLabel2.TabIndex = 1054;
            this.ultraLabel2.Text = "拠点";
            // 
            // Target_uOptionSet
            // 
            this.Target_uOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.Target_uOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Target_uOptionSet.CheckedIndex = 0;
            appearance25.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Target_uOptionSet.ItemAppearance = appearance25;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "全得意先対象";
            valueListItem2.DataValue = 2;
            valueListItem2.DisplayText = "個別得意先指定";
            valueListItem3.DataValue = 3;
            valueListItem3.DisplayText = "個別得意先除外";
            this.Target_uOptionSet.Items.Add(valueListItem1);
            this.Target_uOptionSet.Items.Add(valueListItem2);
            this.Target_uOptionSet.Items.Add(valueListItem3);
            this.Target_uOptionSet.ItemSpacingVertical = 5;
            this.Target_uOptionSet.Location = new System.Drawing.Point(104, 215);
            this.Target_uOptionSet.Name = "Target_uOptionSet";
            this.Target_uOptionSet.Size = new System.Drawing.Size(394, 22);
            this.Target_uOptionSet.TabIndex = 4;
            this.Target_uOptionSet.Text = "全得意先対象";
            // 
            // TotalDay_tNedit
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TotalDay_tNedit.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.TextHAlign = Infragistics.Win.HAlign.Right;
            this.TotalDay_tNedit.Appearance = appearance24;
            this.TotalDay_tNedit.AutoSelect = true;
            this.TotalDay_tNedit.AutoSize = false;
            this.TotalDay_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.TotalDay_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalDay_tNedit.DataText = "";
            this.TotalDay_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalDay_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalDay_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TotalDay_tNedit.Location = new System.Drawing.Point(193, 140);
            this.TotalDay_tNedit.MaxLength = 9;
            this.TotalDay_tNedit.Name = "TotalDay_tNedit";
            this.TotalDay_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalDay_tNedit.Size = new System.Drawing.Size(35, 24);
            this.TotalDay_tNedit.TabIndex = 2;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(104, 143);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(87, 21);
            this.ultraLabel3.TabIndex = 1058;
            this.ultraLabel3.Text = "得意先締日";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(235, 143);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(17, 21);
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
            // LastDay_CheckEditor
            // 
            this.LastDay_CheckEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.LastDay_CheckEditor.Location = new System.Drawing.Point(193, 170);
            this.LastDay_CheckEditor.Name = "LastDay_CheckEditor";
            this.LastDay_CheckEditor.Size = new System.Drawing.Size(118, 20);
            this.LastDay_CheckEditor.TabIndex = 3;
            this.LastDay_CheckEditor.Text = "28～31全て";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tRetKeyControl2
            // 
            this.tRetKeyControl2.OwnerForm = this;
            this.tRetKeyControl2.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // Section_tEdit
            // 
            this.Section_tEdit.ActiveAppearance = appearance21;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.Section_tEdit.Appearance = appearance22;
            this.Section_tEdit.AutoSelect = true;
            this.Section_tEdit.DataText = "";
            this.Section_tEdit.Enabled = false;
            this.Section_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Section_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.Section_tEdit.Location = new System.Drawing.Point(148, 98);
            this.Section_tEdit.MaxLength = 12;
            this.Section_tEdit.Name = "Section_tEdit";
            this.Section_tEdit.ReadOnly = true;
            this.Section_tEdit.Size = new System.Drawing.Size(128, 24);
            this.Section_tEdit.TabIndex = 1;
            // 
            // CustomerNm1_tEdit
            // 
            this.CustomerNm1_tEdit.ActiveAppearance = appearance19;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            appearance20.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm1_tEdit.Appearance = appearance20;
            this.CustomerNm1_tEdit.AutoSelect = true;
            this.CustomerNm1_tEdit.DataText = "";
            this.CustomerNm1_tEdit.Enabled = false;
            this.CustomerNm1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm1_tEdit.Location = new System.Drawing.Point(223, 260);
            this.CustomerNm1_tEdit.MaxLength = 12;
            this.CustomerNm1_tEdit.Name = "CustomerNm1_tEdit";
            this.CustomerNm1_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm1_tEdit.TabIndex = 1062;
            // 
            // CustomerNm6_tEdit
            // 
            this.CustomerNm6_tEdit.ActiveAppearance = appearance17;
            appearance18.BackColor2 = System.Drawing.Color.Black;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm6_tEdit.Appearance = appearance18;
            this.CustomerNm6_tEdit.AutoSelect = true;
            this.CustomerNm6_tEdit.DataText = "";
            this.CustomerNm6_tEdit.Enabled = false;
            this.CustomerNm6_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm6_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm6_tEdit.Location = new System.Drawing.Point(634, 260);
            this.CustomerNm6_tEdit.MaxLength = 12;
            this.CustomerNm6_tEdit.Name = "CustomerNm6_tEdit";
            this.CustomerNm6_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm6_tEdit.TabIndex = 1063;
            // 
            // CustomerNm2_tEdit
            // 
            this.CustomerNm2_tEdit.ActiveAppearance = appearance15;
            appearance16.BackColor2 = System.Drawing.Color.Black;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm2_tEdit.Appearance = appearance16;
            this.CustomerNm2_tEdit.AutoSelect = true;
            this.CustomerNm2_tEdit.DataText = "";
            this.CustomerNm2_tEdit.Enabled = false;
            this.CustomerNm2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm2_tEdit.Location = new System.Drawing.Point(223, 290);
            this.CustomerNm2_tEdit.MaxLength = 12;
            this.CustomerNm2_tEdit.Name = "CustomerNm2_tEdit";
            this.CustomerNm2_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm2_tEdit.TabIndex = 1064;
            // 
            // CustomerNm3_tEdit
            // 
            this.CustomerNm3_tEdit.ActiveAppearance = appearance13;
            appearance14.BackColor2 = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm3_tEdit.Appearance = appearance14;
            this.CustomerNm3_tEdit.AutoSelect = true;
            this.CustomerNm3_tEdit.DataText = "";
            this.CustomerNm3_tEdit.Enabled = false;
            this.CustomerNm3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm3_tEdit.Location = new System.Drawing.Point(223, 320);
            this.CustomerNm3_tEdit.MaxLength = 12;
            this.CustomerNm3_tEdit.Name = "CustomerNm3_tEdit";
            this.CustomerNm3_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm3_tEdit.TabIndex = 1065;
            // 
            // CustomerNm4_tEdit
            // 
            this.CustomerNm4_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColor2 = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm4_tEdit.Appearance = appearance12;
            this.CustomerNm4_tEdit.AutoSelect = true;
            this.CustomerNm4_tEdit.DataText = "";
            this.CustomerNm4_tEdit.Enabled = false;
            this.CustomerNm4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm4_tEdit.Location = new System.Drawing.Point(223, 350);
            this.CustomerNm4_tEdit.MaxLength = 12;
            this.CustomerNm4_tEdit.Name = "CustomerNm4_tEdit";
            this.CustomerNm4_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm4_tEdit.TabIndex = 1066;
            // 
            // CustomerNm5_tEdit
            // 
            this.CustomerNm5_tEdit.ActiveAppearance = appearance9;
            appearance10.BackColor2 = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm5_tEdit.Appearance = appearance10;
            this.CustomerNm5_tEdit.AutoSelect = true;
            this.CustomerNm5_tEdit.DataText = "";
            this.CustomerNm5_tEdit.Enabled = false;
            this.CustomerNm5_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm5_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm5_tEdit.Location = new System.Drawing.Point(223, 380);
            this.CustomerNm5_tEdit.MaxLength = 12;
            this.CustomerNm5_tEdit.Name = "CustomerNm5_tEdit";
            this.CustomerNm5_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm5_tEdit.TabIndex = 1067;
            // 
            // CustomerNm10_tEdit
            // 
            this.CustomerNm10_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColor2 = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm10_tEdit.Appearance = appearance8;
            this.CustomerNm10_tEdit.AutoSelect = true;
            this.CustomerNm10_tEdit.DataText = "";
            this.CustomerNm10_tEdit.Enabled = false;
            this.CustomerNm10_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm10_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm10_tEdit.Location = new System.Drawing.Point(634, 380);
            this.CustomerNm10_tEdit.MaxLength = 12;
            this.CustomerNm10_tEdit.Name = "CustomerNm10_tEdit";
            this.CustomerNm10_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm10_tEdit.TabIndex = 1068;
            // 
            // CustomerNm9_tEdit
            // 
            this.CustomerNm9_tEdit.ActiveAppearance = appearance5;
            appearance6.BackColor2 = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm9_tEdit.Appearance = appearance6;
            this.CustomerNm9_tEdit.AutoSelect = true;
            this.CustomerNm9_tEdit.DataText = "";
            this.CustomerNm9_tEdit.Enabled = false;
            this.CustomerNm9_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm9_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm9_tEdit.Location = new System.Drawing.Point(634, 350);
            this.CustomerNm9_tEdit.MaxLength = 12;
            this.CustomerNm9_tEdit.Name = "CustomerNm9_tEdit";
            this.CustomerNm9_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm9_tEdit.TabIndex = 1069;
            // 
            // CustomerNm8_tEdit
            // 
            this.CustomerNm8_tEdit.ActiveAppearance = appearance3;
            appearance4.BackColor2 = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            appearance4.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm8_tEdit.Appearance = appearance4;
            this.CustomerNm8_tEdit.AutoSelect = true;
            this.CustomerNm8_tEdit.DataText = "";
            this.CustomerNm8_tEdit.Enabled = false;
            this.CustomerNm8_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm8_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm8_tEdit.Location = new System.Drawing.Point(634, 320);
            this.CustomerNm8_tEdit.MaxLength = 12;
            this.CustomerNm8_tEdit.Name = "CustomerNm8_tEdit";
            this.CustomerNm8_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm8_tEdit.TabIndex = 1070;
            // 
            // CustomerNm7_tEdit
            // 
            this.CustomerNm7_tEdit.ActiveAppearance = appearance1;
            appearance2.BackColor2 = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.CustomerNm7_tEdit.Appearance = appearance2;
            this.CustomerNm7_tEdit.AutoSelect = true;
            this.CustomerNm7_tEdit.DataText = "";
            this.CustomerNm7_tEdit.Enabled = false;
            this.CustomerNm7_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNm7_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CustomerNm7_tEdit.Location = new System.Drawing.Point(634, 290);
            this.CustomerNm7_tEdit.MaxLength = 12;
            this.CustomerNm7_tEdit.Name = "CustomerNm7_tEdit";
            this.CustomerNm7_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerNm7_tEdit.TabIndex = 1071;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // MAKAU00129UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(992, 734);
            this.Controls.Add(this.CustomerNm7_tEdit);
            this.Controls.Add(this.CustomerNm8_tEdit);
            this.Controls.Add(this.CustomerNm9_tEdit);
            this.Controls.Add(this.CustomerNm10_tEdit);
            this.Controls.Add(this.CustomerNm5_tEdit);
            this.Controls.Add(this.CustomerNm4_tEdit);
            this.Controls.Add(this.CustomerNm3_tEdit);
            this.Controls.Add(this.CustomerNm2_tEdit);
            this.Controls.Add(this.CustomerNm6_tEdit);
            this.Controls.Add(this.CustomerNm1_tEdit);
            this.Controls.Add(this.Section_tEdit);
            this.Controls.Add(this.LastDay_CheckEditor);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.TotalDay_tNedit);
            this.Controls.Add(this.Target_uOptionSet);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.Customer10_uButton);
            this.Controls.Add(this.CustomerCode10_tNedit);
            this.Controls.Add(this.Customer09_uButton);
            this.Controls.Add(this.CustomerCode9_tNedit);
            this.Controls.Add(this.Customer08_uButton);
            this.Controls.Add(this.CustomerCode8_tNedit);
            this.Controls.Add(this.Customer07_uButton);
            this.Controls.Add(this.CustomerCode7_tNedit);
            this.Controls.Add(this.Customer06_uButton);
            this.Controls.Add(this.CustomerCode6_tNedit);
            this.Controls.Add(this.Customer05_uButton);
            this.Controls.Add(this.CustomerCode5_tNedit);
            this.Controls.Add(this.Customer04_uButton);
            this.Controls.Add(this.CustomerCode4_tNedit);
            this.Controls.Add(this.Customer03_uButton);
            this.Controls.Add(this.CustomerCode3_tNedit);
            this.Controls.Add(this.Customer02_uButton);
            this.Controls.Add(this.CustomerCode2_tNedit);
            this.Controls.Add(this.Customer01_uButton);
            this.Controls.Add(this.CustomerCode1_tNedit);
            this.Controls.Add(this.tDateEdit1);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tShape1);
            this.Controls.Add(this.ultraLabel42);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAKAU00129UA";
            this.Text = "請求準備処理";
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode1_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode3_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode4_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode5_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode6_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode7_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode8_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode9_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode10_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Target_uOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDay_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm6_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm5_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm10_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm9_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm8_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNm7_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Timer timFontChange;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl2;
        private System.Windows.Forms.ToolTip tipGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Broadleaf.Library.Windows.Forms.TShape tShape1;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton Customer01_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode1_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer02_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode2_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer03_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode3_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer04_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode4_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer05_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode5_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer06_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode6_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer07_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode7_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer08_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode8_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer09_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode9_tNedit;
        private Infragistics.Win.Misc.UltraButton Customer10_uButton;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerCode10_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        internal Infragistics.Win.UltraWinEditors.UltraOptionSet Target_uOptionSet;
        private Broadleaf.Library.Windows.Forms.TNedit TotalDay_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Broadleaf.Library.Windows.Forms.TComboEditor cmbGridFont;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor LastDay_CheckEditor;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl2;
        public Broadleaf.Library.Windows.Forms.TEdit Section_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm7_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm8_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm9_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm10_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm5_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm4_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm3_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm2_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm6_tEdit;
        public Broadleaf.Library.Windows.Forms.TEdit CustomerNm1_tEdit;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
	}
}