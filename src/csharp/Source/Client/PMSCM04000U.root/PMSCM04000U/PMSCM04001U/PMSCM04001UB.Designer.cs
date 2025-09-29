namespace Broadleaf.Windows.Forms
{
    partial class PMSCM04001UB
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM04001UB));
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.panel_Detail = new System.Windows.Forms.Panel();
            this.uGrid_Details = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uButton_SalesSlip = new Infragistics.Win.Misc.UltraButton();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uLabel_SalesTotalTaxInc = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SalesTotalTaxIncTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ProduceTypeOfYearNum = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ModelName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ModelDesignationNo = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ModelCategory = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ModelDesignationNoTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ProduceTypeOfYearNumTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ModelNameTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ModelCategoryTitle = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Form1_Fill_Panel.SuspendLayout();
            this.panel_Detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.Controls.Add(this.panel_Detail);
            this.Form1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.Form1_Fill_Panel.Name = "Form1_Fill_Panel";
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(1016, 466);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // panel_Detail
            // 
            this.panel_Detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.panel_Detail.Controls.Add(this.uGrid_Details);
            this.panel_Detail.Controls.Add(this.panel2);
            this.panel_Detail.Controls.Add(this.panel1);
            this.panel_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Detail.Location = new System.Drawing.Point(0, 0);
            this.panel_Detail.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Detail.Name = "panel_Detail";
            this.panel_Detail.Size = new System.Drawing.Size(1016, 466);
            this.panel_Detail.TabIndex = 0;
            // 
            // uGrid_Details
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Details.DisplayLayout.Appearance = appearance1;
            this.uGrid_Details.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Details.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Details.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Details.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.uGrid_Details.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            this.uGrid_Details.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.uGrid_Details.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_Details.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.uGrid_Details.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.uGrid_Details.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_Details.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid_Details.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.TextHAlignAsString = "Center";
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.uGrid_Details.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance5.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Details.DisplayLayout.Override.RowAlternateAppearance = appearance5;
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance6.TextVAlignAsString = "Middle";
            this.uGrid_Details.DisplayLayout.Override.RowAppearance = appearance6;
            this.uGrid_Details.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Details.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.White;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorAppearance = appearance8;
            this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid_Details.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Details.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Details.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.None;
            this.uGrid_Details.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Details.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_Details.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Details.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Details.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_Details.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Details.Location = new System.Drawing.Point(0, 79);
            this.uGrid_Details.Name = "uGrid_Details";
            this.uGrid_Details.Size = new System.Drawing.Size(1016, 322);
            this.uGrid_Details.TabIndex = 10;
            this.uGrid_Details.TabStop = false;
            this.uGrid_Details.Click += new System.EventHandler(this.uGrid_Details_Click);
            this.uGrid_Details.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Details_InitializeLayout);
            this.uGrid_Details.Leave += new System.EventHandler(this.uGrid_Details_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uButton_SalesSlip);
            this.panel2.Controls.Add(this.uButton_Close);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 65);
            this.panel2.TabIndex = 2;
            // 
            // uButton_SalesSlip
            // 
            this.uButton_SalesSlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_SalesSlip.ImageSize = new System.Drawing.Size(24, 24);
            this.uButton_SalesSlip.Location = new System.Drawing.Point(702, 4);
            this.uButton_SalesSlip.Margin = new System.Windows.Forms.Padding(1);
            this.uButton_SalesSlip.Name = "uButton_SalesSlip";
            this.uButton_SalesSlip.Size = new System.Drawing.Size(151, 51);
            this.uButton_SalesSlip.TabIndex = 20;
            this.uButton_SalesSlip.Text = "売上伝票入力(&I)";
            this.uButton_SalesSlip.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesSlip.Click += new System.EventHandler(this.uButton_SalesSlip_Click);
            // 
            // uButton_Close
            // 
            this.uButton_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.ImageSize = new System.Drawing.Size(24, 24);
            this.uButton_Close.Location = new System.Drawing.Point(855, 4);
            this.uButton_Close.Margin = new System.Windows.Forms.Padding(1);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(151, 51);
            this.uButton_Close.TabIndex = 30;
            this.uButton_Close.Text = "閉じる(&X)";
            this.uButton_Close.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uLabel_SalesTotalTaxInc);
            this.panel1.Controls.Add(this.uLabel_SalesTotalTaxIncTitle);
            this.panel1.Controls.Add(this.uLabel_ProduceTypeOfYearNum);
            this.panel1.Controls.Add(this.uLabel_ModelName);
            this.panel1.Controls.Add(this.uLabel_ModelDesignationNo);
            this.panel1.Controls.Add(this.uLabel_ModelCategory);
            this.panel1.Controls.Add(this.uLabel_ModelDesignationNoTitle);
            this.panel1.Controls.Add(this.uLabel_ProduceTypeOfYearNumTitle);
            this.panel1.Controls.Add(this.uLabel_ModelNameTitle);
            this.panel1.Controls.Add(this.uLabel_ModelCategoryTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 79);
            this.panel1.TabIndex = 0;
            // 
            // uLabel_SalesTotalTaxInc
            // 
            appearance64.BackColor = System.Drawing.Color.Gainsboro;
            appearance64.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance64.TextHAlignAsString = "Right";
            appearance64.TextVAlignAsString = "Middle";
            this.uLabel_SalesTotalTaxInc.Appearance = appearance64;
            this.uLabel_SalesTotalTaxInc.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SalesTotalTaxInc.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SalesTotalTaxInc.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_SalesTotalTaxInc.Location = new System.Drawing.Point(833, 40);
            this.uLabel_SalesTotalTaxInc.Name = "uLabel_SalesTotalTaxInc";
            this.uLabel_SalesTotalTaxInc.Size = new System.Drawing.Size(171, 24);
            this.uLabel_SalesTotalTaxInc.TabIndex = 171;
            this.uLabel_SalesTotalTaxInc.Visible = false;
            this.uLabel_SalesTotalTaxInc.WrapText = false;
            // 
            // uLabel_SalesTotalTaxIncTitle
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.uLabel_SalesTotalTaxIncTitle.Appearance = appearance21;
            this.uLabel_SalesTotalTaxIncTitle.Location = new System.Drawing.Point(739, 41);
            this.uLabel_SalesTotalTaxIncTitle.Name = "uLabel_SalesTotalTaxIncTitle";
            this.uLabel_SalesTotalTaxIncTitle.Size = new System.Drawing.Size(88, 23);
            this.uLabel_SalesTotalTaxIncTitle.TabIndex = 170;
            this.uLabel_SalesTotalTaxIncTitle.Text = "金額合計";
            this.uLabel_SalesTotalTaxIncTitle.Visible = false;
            // 
            // uLabel_ProduceTypeOfYearNum
            // 
            appearance26.BackColor = System.Drawing.Color.Gainsboro;
            appearance26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.uLabel_ProduceTypeOfYearNum.Appearance = appearance26;
            this.uLabel_ProduceTypeOfYearNum.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ProduceTypeOfYearNum.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ProduceTypeOfYearNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_ProduceTypeOfYearNum.Location = new System.Drawing.Point(376, 40);
            this.uLabel_ProduceTypeOfYearNum.Name = "uLabel_ProduceTypeOfYearNum";
            this.uLabel_ProduceTypeOfYearNum.Size = new System.Drawing.Size(171, 24);
            this.uLabel_ProduceTypeOfYearNum.TabIndex = 169;
            this.uLabel_ProduceTypeOfYearNum.WrapText = false;
            // 
            // uLabel_ModelName
            // 
            appearance23.BackColor = System.Drawing.Color.Gainsboro;
            appearance23.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance23.TextHAlignAsString = "Left";
            appearance23.TextVAlignAsString = "Middle";
            this.uLabel_ModelName.Appearance = appearance23;
            this.uLabel_ModelName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ModelName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ModelName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_ModelName.Location = new System.Drawing.Point(376, 11);
            this.uLabel_ModelName.Name = "uLabel_ModelName";
            this.uLabel_ModelName.Size = new System.Drawing.Size(171, 24);
            this.uLabel_ModelName.TabIndex = 168;
            this.uLabel_ModelName.WrapText = false;
            // 
            // uLabel_ModelDesignationNo
            // 
            appearance25.BackColor = System.Drawing.Color.Gainsboro;
            appearance25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance25.TextHAlignAsString = "Left";
            appearance25.TextVAlignAsString = "Middle";
            this.uLabel_ModelDesignationNo.Appearance = appearance25;
            this.uLabel_ModelDesignationNo.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ModelDesignationNo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ModelDesignationNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_ModelDesignationNo.Location = new System.Drawing.Point(118, 40);
            this.uLabel_ModelDesignationNo.Name = "uLabel_ModelDesignationNo";
            this.uLabel_ModelDesignationNo.Size = new System.Drawing.Size(171, 24);
            this.uLabel_ModelDesignationNo.TabIndex = 167;
            this.uLabel_ModelDesignationNo.WrapText = false;
            // 
            // uLabel_ModelCategory
            // 
            appearance24.BackColor = System.Drawing.Color.Gainsboro;
            appearance24.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance24.TextHAlignAsString = "Left";
            appearance24.TextVAlignAsString = "Middle";
            this.uLabel_ModelCategory.Appearance = appearance24;
            this.uLabel_ModelCategory.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ModelCategory.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ModelCategory.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_ModelCategory.Location = new System.Drawing.Point(118, 11);
            this.uLabel_ModelCategory.Name = "uLabel_ModelCategory";
            this.uLabel_ModelCategory.Size = new System.Drawing.Size(171, 24);
            this.uLabel_ModelCategory.TabIndex = 166;
            this.uLabel_ModelCategory.WrapText = false;
            // 
            // uLabel_ModelDesignationNoTitle
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.uLabel_ModelDesignationNoTitle.Appearance = appearance7;
            this.uLabel_ModelDesignationNoTitle.Location = new System.Drawing.Point(51, 41);
            this.uLabel_ModelDesignationNoTitle.Name = "uLabel_ModelDesignationNoTitle";
            this.uLabel_ModelDesignationNoTitle.Size = new System.Drawing.Size(55, 23);
            this.uLabel_ModelDesignationNoTitle.TabIndex = 154;
            this.uLabel_ModelDesignationNoTitle.Text = "型式";
            // 
            // uLabel_ProduceTypeOfYearNumTitle
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.uLabel_ProduceTypeOfYearNumTitle.Appearance = appearance27;
            this.uLabel_ProduceTypeOfYearNumTitle.Location = new System.Drawing.Point(315, 41);
            this.uLabel_ProduceTypeOfYearNumTitle.Name = "uLabel_ProduceTypeOfYearNumTitle";
            this.uLabel_ProduceTypeOfYearNumTitle.Size = new System.Drawing.Size(55, 23);
            this.uLabel_ProduceTypeOfYearNumTitle.TabIndex = 153;
            this.uLabel_ProduceTypeOfYearNumTitle.Text = "年式";
            // 
            // uLabel_ModelNameTitle
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.uLabel_ModelNameTitle.Appearance = appearance22;
            this.uLabel_ModelNameTitle.Location = new System.Drawing.Point(315, 12);
            this.uLabel_ModelNameTitle.Name = "uLabel_ModelNameTitle";
            this.uLabel_ModelNameTitle.Size = new System.Drawing.Size(55, 23);
            this.uLabel_ModelNameTitle.TabIndex = 152;
            this.uLabel_ModelNameTitle.Text = "車種";
            // 
            // uLabel_ModelCategoryTitle
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.uLabel_ModelCategoryTitle.Appearance = appearance20;
            this.uLabel_ModelCategoryTitle.Location = new System.Drawing.Point(51, 12);
            this.uLabel_ModelCategoryTitle.Name = "uLabel_ModelCategoryTitle";
            this.uLabel_ModelCategoryTitle.Size = new System.Drawing.Size(55, 23);
            this.uLabel_ModelCategoryTitle.TabIndex = 151;
            this.uLabel_ModelCategoryTitle.Text = "類別";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.CatchMouse = true;
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // PMSCM04001UB
            // 
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(1016, 466);
            this.Controls.Add(this.Form1_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMSCM04001UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PCC問合せ一覧（明細）";
            this.Load += new System.EventHandler(this.PMSCM04001UB_Load);
            this.Shown += new System.EventHandler(this.PMSCM04001UB_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMSCM04001UB_FormClosing);
            this.Form1_Fill_Panel.ResumeLayout(false);
            this.panel_Detail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Form1_Fill_Panel;
        private System.Windows.Forms.Panel panel_Detail;
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Details;
        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.Misc.UltraLabel uLabel_ModelCategoryTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_ModelDesignationNoTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_ProduceTypeOfYearNumTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_ModelNameTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_ModelCategory;
        private Infragistics.Win.Misc.UltraLabel uLabel_ProduceTypeOfYearNum;
        private Infragistics.Win.Misc.UltraLabel uLabel_ModelName;
        private Infragistics.Win.Misc.UltraLabel uLabel_ModelDesignationNo;
        private Infragistics.Win.Misc.UltraLabel uLabel_SalesTotalTaxInc;
        private Infragistics.Win.Misc.UltraLabel uLabel_SalesTotalTaxIncTitle;
        private Infragistics.Win.Misc.UltraButton uButton_SalesSlip;
        private Infragistics.Win.Misc.UltraButton uButton_Close;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}