namespace Broadleaf.Windows.Forms
{
    partial class PMKHN09690UA
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("得意先ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("BLコードガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("BLコードガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09690UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.FrontEmployee_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SalesSlipPrtDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DeliveredGoodsDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_CustomerGuide = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uButton_PMBLCdGuid = new Infragistics.Win.Misc.UltraButton();
            this.uButton_SFBLCdGuid = new Infragistics.Win.Misc.UltraButton();
            this.Bind_DataSet = new System.Data.DataSet();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PMBLCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SFBLCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_CustomerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_CustomerNm = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PMBLCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SFBLCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCd)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(552, 201);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 11;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(421, 201);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 10;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // FrontEmployee_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.FrontEmployee_Label.Appearance = appearance3;
            this.FrontEmployee_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FrontEmployee_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FrontEmployee_Label.Location = new System.Drawing.Point(21, 68);
            this.FrontEmployee_Label.Name = "FrontEmployee_Label";
            this.FrontEmployee_Label.Size = new System.Drawing.Size(144, 23);
            this.FrontEmployee_Label.TabIndex = 22;
            this.FrontEmployee_Label.Text = "得意先コード";
            // 
            // SalesSlipPrtDiv_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.SalesSlipPrtDiv_Label.Appearance = appearance7;
            this.SalesSlipPrtDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SalesSlipPrtDiv_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.SalesSlipPrtDiv_Label.Location = new System.Drawing.Point(21, 138);
            this.SalesSlipPrtDiv_Label.Name = "SalesSlipPrtDiv_Label";
            this.SalesSlipPrtDiv_Label.Size = new System.Drawing.Size(144, 23);
            this.SalesSlipPrtDiv_Label.TabIndex = 25;
            this.SalesSlipPrtDiv_Label.Text = "SF側BLコード";
            // 
            // DeliveredGoodsDiv_Label
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.DeliveredGoodsDiv_Label.Appearance = appearance12;
            this.DeliveredGoodsDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DeliveredGoodsDiv_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.DeliveredGoodsDiv_Label.Location = new System.Drawing.Point(21, 98);
            this.DeliveredGoodsDiv_Label.Name = "DeliveredGoodsDiv_Label";
            this.DeliveredGoodsDiv_Label.Size = new System.Drawing.Size(124, 23);
            this.DeliveredGoodsDiv_Label.TabIndex = 28;
            this.DeliveredGoodsDiv_Label.Text = "PM側BLコード";
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(593, 6);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 29;
            this.Mode_Label.Text = "更新モード";
            // 
            // uButton_CustomerGuide
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uButton_CustomerGuide.Appearance = appearance2;
            this.uButton_CustomerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uButton_CustomerGuide.Location = new System.Drawing.Point(529, 66);
            this.uButton_CustomerGuide.Name = "uButton_CustomerGuide";
            this.uButton_CustomerGuide.Size = new System.Drawing.Size(25, 25);
            this.uButton_CustomerGuide.TabIndex = 2;
            this.uButton_CustomerGuide.Tag = "1";
            ultraToolTipInfo3.ToolTipText = "得意先ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_CustomerGuide, ultraToolTipInfo3);
            this.uButton_CustomerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CustomerGuide.Click += new System.EventHandler(this.uButtonCustomerGuid_Click);
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
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // uButton_PMBLCdGuid
            // 
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uButton_PMBLCdGuid.Appearance = appearance9;
            this.uButton_PMBLCdGuid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uButton_PMBLCdGuid.Location = new System.Drawing.Point(241, 98);
            this.uButton_PMBLCdGuid.Name = "uButton_PMBLCdGuid";
            this.uButton_PMBLCdGuid.Size = new System.Drawing.Size(25, 25);
            this.uButton_PMBLCdGuid.TabIndex = 4;
            this.uButton_PMBLCdGuid.Tag = "1";
            ultraToolTipInfo2.ToolTipText = "BLコードガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_PMBLCdGuid, ultraToolTipInfo2);
            this.uButton_PMBLCdGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_PMBLCdGuid.Click += new System.EventHandler(this.uButton_PMBLCdGuid_Click);
            // 
            // uButton_SFBLCdGuid
            // 
            appearance45.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uButton_SFBLCdGuid.Appearance = appearance45;
            this.uButton_SFBLCdGuid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uButton_SFBLCdGuid.Location = new System.Drawing.Point(241, 138);
            this.uButton_SFBLCdGuid.Name = "uButton_SFBLCdGuid";
            this.uButton_SFBLCdGuid.Size = new System.Drawing.Size(25, 25);
            this.uButton_SFBLCdGuid.TabIndex = 6;
            this.uButton_SFBLCdGuid.Tag = "1";
            ultraToolTipInfo1.ToolTipText = "BLコードガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_SFBLCdGuid, ultraToolTipInfo1);
            this.uButton_SFBLCdGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SFBLCdGuid.Click += new System.EventHandler(this.uButton_SFBLCdGuid_Click);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(290, 201);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 8;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(421, 201);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 9;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 250);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(699, 27);
            this.ultraStatusBar1.TabIndex = 122;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.DivideLine_Label.Location = new System.Drawing.Point(11, 127);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(672, 3);
            this.DivideLine_Label.TabIndex = 123;
            // 
            // tNedit_PMBLCd
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Right";
            this.tNedit_PMBLCd.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.tNedit_PMBLCd.Appearance = appearance11;
            this.tNedit_PMBLCd.AutoSelect = true;
            this.tNedit_PMBLCd.AutoSize = false;
            this.tNedit_PMBLCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_PMBLCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PMBLCd.DataText = "12345";
            this.tNedit_PMBLCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PMBLCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PMBLCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tNedit_PMBLCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_PMBLCd.Location = new System.Drawing.Point(171, 98);
            this.tNedit_PMBLCd.MaxLength = 5;
            this.tNedit_PMBLCd.Name = "tNedit_PMBLCd";
            this.tNedit_PMBLCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_PMBLCd.Size = new System.Drawing.Size(52, 24);
            this.tNedit_PMBLCd.TabIndex = 3;
            this.tNedit_PMBLCd.Text = "12345";
            // 
            // tNedit_SFBLCd
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.TextHAlignAsString = "Right";
            this.tNedit_SFBLCd.ActiveAppearance = appearance26;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance38.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Right";
            this.tNedit_SFBLCd.Appearance = appearance38;
            this.tNedit_SFBLCd.AutoSelect = true;
            this.tNedit_SFBLCd.AutoSize = false;
            this.tNedit_SFBLCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SFBLCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SFBLCd.DataText = "12345";
            this.tNedit_SFBLCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SFBLCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SFBLCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tNedit_SFBLCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SFBLCd.Location = new System.Drawing.Point(171, 138);
            this.tNedit_SFBLCd.MaxLength = 5;
            this.tNedit_SFBLCd.Name = "tNedit_SFBLCd";
            this.tNedit_SFBLCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SFBLCd.Size = new System.Drawing.Size(52, 24);
            this.tNedit_SFBLCd.TabIndex = 5;
            this.tNedit_SFBLCd.Text = "12345";
            // 
            // tNedit_CustomerCd
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.tNedit_CustomerCd.ActiveAppearance = appearance4;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.tNedit_CustomerCd.Appearance = appearance8;
            this.tNedit_CustomerCd.AutoSelect = true;
            this.tNedit_CustomerCd.AutoSize = false;
            this.tNedit_CustomerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCd.DataText = "12345678";
            this.tNedit_CustomerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tNedit_CustomerCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCd.Location = new System.Drawing.Point(171, 67);
            this.tNedit_CustomerCd.MaxLength = 8;
            this.tNedit_CustomerCd.Name = "tNedit_CustomerCd";
            this.tNedit_CustomerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCd.Size = new System.Drawing.Size(76, 24);
            this.tNedit_CustomerCd.TabIndex = 1;
            this.tNedit_CustomerCd.Text = "12345678";
            // 
            // uLabel_CustomerNm
            // 
            appearance1.BackColor = System.Drawing.Color.Gainsboro;
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.uLabel_CustomerNm.Appearance = appearance1;
            this.uLabel_CustomerNm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_CustomerNm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_CustomerNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerNm.Location = new System.Drawing.Point(254, 67);
            this.uLabel_CustomerNm.Name = "uLabel_CustomerNm";
            this.uLabel_CustomerNm.Size = new System.Drawing.Size(269, 24);
            this.uLabel_CustomerNm.TabIndex = 1307;
            this.uLabel_CustomerNm.WrapText = false;
            // 
            // PMKHN09690UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(699, 277);
            this.Controls.Add(this.tNedit_CustomerCd);
            this.Controls.Add(this.tNedit_SFBLCd);
            this.Controls.Add(this.uButton_SFBLCdGuid);
            this.Controls.Add(this.tNedit_PMBLCd);
            this.Controls.Add(this.uButton_PMBLCdGuid);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.uButton_CustomerGuide);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.DeliveredGoodsDiv_Label);
            this.Controls.Add(this.SalesSlipPrtDiv_Label);
            this.Controls.Add(this.FrontEmployee_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.uLabel_CustomerNm);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09690UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BLﾊﾟｰﾂｵｰﾀﾞｰBLコード変換マスタ";
            this.Load += new System.EventHandler(this.PMKHN09690UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09690UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKHN09690UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PMBLCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SFBLCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraLabel FrontEmployee_Label;
        private Infragistics.Win.Misc.UltraLabel SalesSlipPrtDiv_Label;
        private Infragistics.Win.Misc.UltraLabel DeliveredGoodsDiv_Label;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraButton uButton_CustomerGuide;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_PMBLCd;
        private Infragistics.Win.Misc.UltraButton uButton_PMBLCdGuid;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SFBLCd;
        private Infragistics.Win.Misc.UltraButton uButton_SFBLCdGuid;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCd;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerNm;
    }
}