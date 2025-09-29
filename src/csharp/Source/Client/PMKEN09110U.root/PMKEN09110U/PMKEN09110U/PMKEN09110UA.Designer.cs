namespace Broadleaf.Windows.Forms
{
    partial class PMKEN09110UA
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("装備名ガイド", Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKEN09110UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.EquipGenreGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.uGrid_Details = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_EquipGenreCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tEdit_EquipGenreName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.RowDelete_Button = new Infragistics.Win.Misc.UltraButton();
            this.GoodsRegist_Button = new Infragistics.Win.Misc.UltraButton();
            this.QuotationRegist_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_EquipGenreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EquipGenreName)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 683);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(1018, 23);
            this.ultraStatusBar1.TabIndex = 204;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(875, 639);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(749, 639);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 4;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // EquipGenreGuide_Button
            // 
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.EquipGenreGuide_Button.Appearance = appearance7;
            this.EquipGenreGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EquipGenreGuide_Button.Location = new System.Drawing.Point(634, 56);
            this.EquipGenreGuide_Button.Name = "EquipGenreGuide_Button";
            this.EquipGenreGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.EquipGenreGuide_Button.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "装備名ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.EquipGenreGuide_Button, ultraToolTipInfo1);
            this.EquipGenreGuide_Button.Click += new System.EventHandler(this.EquipGenreGuide_Button_Click);
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
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // uGrid_Details
            // 
            appearance20.BackColor = System.Drawing.Color.White;
            appearance20.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Details.DisplayLayout.Appearance = appearance20;
            this.uGrid_Details.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Details.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Details.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Details.DisplayLayout.MaxRowScrollRegions = 1;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.uGrid_Details.DisplayLayout.Override.ActiveCellAppearance = appearance21;
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
            appearance8.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Details.DisplayLayout.Override.CellAppearance = appearance8;
            this.uGrid_Details.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid_Details.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance22.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.ForeColor = System.Drawing.Color.White;
            appearance22.TextHAlignAsString = "Center";
            appearance22.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.uGrid_Details.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Details.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance5.TextVAlignAsString = "Middle";
            this.uGrid_Details.DisplayLayout.Override.RowAppearance = appearance5;
            this.uGrid_Details.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Details.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.uGrid_Details.DisplayLayout.Override.RowSelectorAppearance = appearance6;
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
            this.uGrid_Details.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_Details.Location = new System.Drawing.Point(20, 144);
            this.uGrid_Details.Name = "uGrid_Details";
            this.uGrid_Details.Size = new System.Drawing.Size(980, 482);
            this.uGrid_Details.TabIndex = 3;
            this.uGrid_Details.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.uGrid_Details_BeforeCellUpdate);
            this.uGrid_Details.AfterExitEditMode += new System.EventHandler(this.uGrid_Details_AfterExitEditMode);
            this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            this.uGrid_Details.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uGrid_Details_KeyPress);
            this.uGrid_Details.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Details_KeyDown);
            this.uGrid_Details.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.uGrid_Details_BeforeCellActivate);
            this.uGrid_Details.AfterCellActivate += new System.EventHandler(this.uGrid_Details_AfterCellActivate);
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(913, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 210;
            // 
            // uLabel2
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.uLabel2.Appearance = appearance3;
            this.uLabel2.Location = new System.Drawing.Point(20, 56);
            this.uLabel2.Name = "uLabel2";
            this.uLabel2.Size = new System.Drawing.Size(106, 24);
            this.uLabel2.TabIndex = 222;
            this.uLabel2.Text = "装備名";
            // 
            // uLabel1
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.uLabel1.Appearance = appearance2;
            this.uLabel1.Location = new System.Drawing.Point(20, 21);
            this.uLabel1.Name = "uLabel1";
            this.uLabel1.Size = new System.Drawing.Size(106, 24);
            this.uLabel1.TabIndex = 221;
            this.uLabel1.Text = "装備分類";
            // 
            // tComboEditor_EquipGenreCode
            // 
            this.tComboEditor_EquipGenreCode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.tComboEditor_EquipGenreCode.ActiveAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.tComboEditor_EquipGenreCode.Appearance = appearance18;
            this.tComboEditor_EquipGenreCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_EquipGenreCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.tComboEditor_EquipGenreCode.ItemAppearance = appearance19;
            this.tComboEditor_EquipGenreCode.Location = new System.Drawing.Point(132, 21);
            this.tComboEditor_EquipGenreCode.Name = "tComboEditor_EquipGenreCode";
            this.tComboEditor_EquipGenreCode.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_EquipGenreCode.TabIndex = 0;
            this.tComboEditor_EquipGenreCode.ValueChanged += new System.EventHandler(this.tComboEditor_EquipGenreCode_ValueChanged);
            // 
            // tEdit_EquipGenreName
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance24.ForeColor = System.Drawing.Color.Black;
            this.tEdit_EquipGenreName.ActiveAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_EquipGenreName.Appearance = appearance25;
            this.tEdit_EquipGenreName.AutoSelect = true;
            this.tEdit_EquipGenreName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_EquipGenreName.DataText = "";
            this.tEdit_EquipGenreName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EquipGenreName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_EquipGenreName.Location = new System.Drawing.Point(132, 56);
            this.tEdit_EquipGenreName.MaxLength = 60;
            this.tEdit_EquipGenreName.Name = "tEdit_EquipGenreName";
            this.tEdit_EquipGenreName.Size = new System.Drawing.Size(484, 24);
            this.tEdit_EquipGenreName.TabIndex = 1;
            // 
            // RowDelete_Button
            // 
            this.RowDelete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.RowDelete_Button.Location = new System.Drawing.Point(20, 100);
            this.RowDelete_Button.Name = "RowDelete_Button";
            this.RowDelete_Button.Size = new System.Drawing.Size(110, 34);
            this.RowDelete_Button.TabIndex = 226;
            this.RowDelete_Button.TabStop = false;
            this.RowDelete_Button.Text = "行削除(&D)";
            this.RowDelete_Button.Click += new System.EventHandler(this.RowDelete_Button_Click);
            // 
            // GoodsRegist_Button
            // 
            this.GoodsRegist_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.GoodsRegist_Button.Location = new System.Drawing.Point(136, 100);
            this.GoodsRegist_Button.Name = "GoodsRegist_Button";
            this.GoodsRegist_Button.Size = new System.Drawing.Size(110, 34);
            this.GoodsRegist_Button.TabIndex = 227;
            this.GoodsRegist_Button.TabStop = false;
            this.GoodsRegist_Button.Text = "商品登録(&I)";
            this.GoodsRegist_Button.Click += new System.EventHandler(this.GoodsRegist_Button_Click);
            // 
            // QuotationRegist_Button
            // 
            this.QuotationRegist_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.QuotationRegist_Button.Location = new System.Drawing.Point(252, 100);
            this.QuotationRegist_Button.Name = "QuotationRegist_Button";
            this.QuotationRegist_Button.Size = new System.Drawing.Size(110, 34);
            this.QuotationRegist_Button.TabIndex = 228;
            this.QuotationRegist_Button.TabStop = false;
            this.QuotationRegist_Button.Text = "引用登録(&Q)";
            this.QuotationRegist_Button.Click += new System.EventHandler(this.QuotationRegist_Button_Click);
            // 
            // PMKEN09110UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1018, 706);
            this.Controls.Add(this.QuotationRegist_Button);
            this.Controls.Add(this.GoodsRegist_Button);
            this.Controls.Add(this.RowDelete_Button);
            this.Controls.Add(this.EquipGenreGuide_Button);
            this.Controls.Add(this.tEdit_EquipGenreName);
            this.Controls.Add(this.tComboEditor_EquipGenreCode);
            this.Controls.Add(this.uLabel2);
            this.Controls.Add(this.uLabel1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.uGrid_Details);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PMKEN09110UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TBOマスタ";
            this.Load += new System.EventHandler(this.PMKEN09110UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKEN09110UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKEN09110UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_EquipGenreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EquipGenreName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.Misc.UltraButton EquipGenreGuide_Button;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_EquipGenreName;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_EquipGenreCode;
        private Infragistics.Win.Misc.UltraLabel uLabel2;
        private Infragistics.Win.Misc.UltraLabel uLabel1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        public Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Details;
        private Infragistics.Win.Misc.UltraButton QuotationRegist_Button;
        private Infragistics.Win.Misc.UltraButton GoodsRegist_Button;
        private Infragistics.Win.Misc.UltraButton RowDelete_Button;

    }
}