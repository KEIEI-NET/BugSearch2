namespace Broadleaf.Windows.Forms
{
    partial class PMKOU02050UB
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
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKOU02050UB));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._PMKOU02050UBUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKOU02050UBUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKOU02050UBUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKOU02050UBUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKOU02050UBAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.First_panel = new System.Windows.Forms.Panel();
            this.First_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Second_panel = new System.Windows.Forms.Panel();
            this.Second_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.timer_SetFocus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this.First_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.First_Grid)).BeginInit();
            this.Second_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Second_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(12, 12);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "閉じる(&C)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(143, 12);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 6;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraDockManager1
            // 
            this.ultraDockManager1.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            this.ultraDockManager1.CompressUnpinnedTabs = false;
            this.ultraDockManager1.HostControl = this;
            this.ultraDockManager1.HotTracking = false;
            this.ultraDockManager1.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.ultraDockManager1.ShowCloseButton = false;
            this.ultraDockManager1.ShowDisabledButtons = false;
            this.ultraDockManager1.ShowMaximizeButton = true;
            this.ultraDockManager1.ShowMenuButton = Infragistics.Win.DefaultableBoolean.False;
            appearance30.FontData.SizeInPoints = 9F;
            this.ultraDockManager1.UnpinnedTabAreaAppearance = appearance30;
            this.ultraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _PMKOU02050UBUnpinnedTabAreaLeft
            // 
            this._PMKOU02050UBUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._PMKOU02050UBUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this._PMKOU02050UBUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._PMKOU02050UBUnpinnedTabAreaLeft.Name = "_PMKOU02050UBUnpinnedTabAreaLeft";
            this._PMKOU02050UBUnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._PMKOU02050UBUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 441);
            this._PMKOU02050UBUnpinnedTabAreaLeft.TabIndex = 18;
            // 
            // _PMKOU02050UBUnpinnedTabAreaRight
            // 
            this._PMKOU02050UBUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._PMKOU02050UBUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this._PMKOU02050UBUnpinnedTabAreaRight.Location = new System.Drawing.Point(546, 0);
            this._PMKOU02050UBUnpinnedTabAreaRight.Name = "_PMKOU02050UBUnpinnedTabAreaRight";
            this._PMKOU02050UBUnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._PMKOU02050UBUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 441);
            this._PMKOU02050UBUnpinnedTabAreaRight.TabIndex = 19;
            // 
            // _PMKOU02050UBUnpinnedTabAreaTop
            // 
            this._PMKOU02050UBUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._PMKOU02050UBUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this._PMKOU02050UBUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._PMKOU02050UBUnpinnedTabAreaTop.Name = "_PMKOU02050UBUnpinnedTabAreaTop";
            this._PMKOU02050UBUnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._PMKOU02050UBUnpinnedTabAreaTop.Size = new System.Drawing.Size(546, 0);
            this._PMKOU02050UBUnpinnedTabAreaTop.TabIndex = 20;
            // 
            // _PMKOU02050UBUnpinnedTabAreaBottom
            // 
            this._PMKOU02050UBUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PMKOU02050UBUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this._PMKOU02050UBUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 441);
            this._PMKOU02050UBUnpinnedTabAreaBottom.Name = "_PMKOU02050UBUnpinnedTabAreaBottom";
            this._PMKOU02050UBUnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._PMKOU02050UBUnpinnedTabAreaBottom.Size = new System.Drawing.Size(546, 0);
            this._PMKOU02050UBUnpinnedTabAreaBottom.TabIndex = 21;
            // 
            // _PMKOU02050UBAutoHideControl
            // 
            this._PMKOU02050UBAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this._PMKOU02050UBAutoHideControl.Location = new System.Drawing.Point(0, 0);
            this._PMKOU02050UBAutoHideControl.Name = "_PMKOU02050UBAutoHideControl";
            this._PMKOU02050UBAutoHideControl.Owner = this.ultraDockManager1;
            this._PMKOU02050UBAutoHideControl.Size = new System.Drawing.Size(0, 0);
            this._PMKOU02050UBAutoHideControl.TabIndex = 22;
            // 
            // First_panel
            // 
            this.First_panel.Controls.Add(this.First_Grid);
            this.First_panel.Controls.Add(this.ultraStatusBar2);
            this.First_panel.Location = new System.Drawing.Point(12, 52);
            this.First_panel.Name = "First_panel";
            this.First_panel.Size = new System.Drawing.Size(150, 377);
            this.First_panel.TabIndex = 23;
            // 
            // First_Grid
            // 
            appearance157.BackColor = System.Drawing.Color.White;
            appearance157.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance157.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.First_Grid.DisplayLayout.Appearance = appearance157;
            this.First_Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.First_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.First_Grid.DisplayLayout.GroupByBox.Style = Infragistics.Win.UltraWinGrid.GroupByBoxStyle.Compact;
            this.First_Grid.DisplayLayout.InterBandSpacing = 10;
            this.First_Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.First_Grid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance158.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance158.ForeColor = System.Drawing.Color.Black;
            this.First_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance158;
            this.First_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.First_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.First_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.First_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            appearance159.ForeColor = System.Drawing.Color.Black;
            appearance159.ForeColorDisabled = System.Drawing.Color.Black;
            this.First_Grid.DisplayLayout.Override.CellAppearance = appearance159;
            this.First_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.First_Grid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance160.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance160.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance160.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance160.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance160.ForeColor = System.Drawing.Color.White;
            appearance160.TextHAlignAsString = "Center";
            appearance160.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.First_Grid.DisplayLayout.Override.HeaderAppearance = appearance160;
            this.First_Grid.DisplayLayout.Override.MaxSelectedCells = 1;
            this.First_Grid.DisplayLayout.Override.MaxSelectedRows = 1;
            appearance161.BackColor = System.Drawing.Color.Lavender;
            this.First_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance161;
            appearance162.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance162.TextVAlignAsString = "Middle";
            this.First_Grid.DisplayLayout.Override.RowAppearance = appearance162;
            appearance163.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance163.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance163.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance163.ForeColor = System.Drawing.Color.White;
            this.First_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance163;
            this.First_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.First_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.First_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance164.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance164.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance164.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance164.ForeColor = System.Drawing.Color.Black;
            this.First_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance164;
            this.First_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.First_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.First_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.First_Grid.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.First_Grid.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.First_Grid.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.First_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.First_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.First_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.First_Grid.DisplayLayout.UseFixedHeaders = true;
            this.First_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.First_Grid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.First_Grid.Location = new System.Drawing.Point(0, 24);
            this.First_Grid.Name = "First_Grid";
            this.First_Grid.Size = new System.Drawing.Size(150, 350);
            this.First_Grid.TabIndex = 3;
            this.First_Grid.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.First_Grid_BeforeEnterEditMode);
            this.First_Grid.AfterExitEditMode += new System.EventHandler(this.First_Grid_AfterExitEditMode);
            this.First_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.First_Grid_AfterSelectChange);
            this.First_Grid.AfterEnterEditMode += new System.EventHandler(this.First_Grid_AfterEnterEditMode);
            this.First_Grid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.First_Grid_KeyPress);
            this.First_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            this.First_Grid.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.First_Grid_BeforeCellActivate);
            // 
            // ultraStatusBar2
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance17.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.FontData.BoldAsString = "True";
            appearance17.FontData.Name = "ＭＳ ゴシック";
            appearance17.ForeColor = System.Drawing.Color.White;
            appearance17.TextHAlignAsString = "Center";
            appearance17.TextVAlignAsString = "Middle";
            this.ultraStatusBar2.Appearance = appearance17;
            this.ultraStatusBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar2.Location = new System.Drawing.Point(0, 0);
            this.ultraStatusBar2.Name = "ultraStatusBar2";
            this.ultraStatusBar2.Size = new System.Drawing.Size(150, 30);
            this.ultraStatusBar2.TabIndex = 208;
            this.ultraStatusBar2.Text = "仕入先拠点";
            this.ultraStatusBar2.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Second_panel
            // 
            this.Second_panel.Controls.Add(this.Second_Grid);
            this.Second_panel.Controls.Add(this.ultraStatusBar1);
            this.Second_panel.Location = new System.Drawing.Point(162, 52);
            this.Second_panel.Name = "Second_panel";
            this.Second_panel.Size = new System.Drawing.Size(374, 377);
            this.Second_panel.TabIndex = 24;
            // 
            // Second_Grid
            // 
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Second_Grid.DisplayLayout.Appearance = appearance8;
            this.Second_Grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Second_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Second_Grid.DisplayLayout.GroupByBox.Style = Infragistics.Win.UltraWinGrid.GroupByBoxStyle.Compact;
            this.Second_Grid.DisplayLayout.InterBandSpacing = 10;
            this.Second_Grid.DisplayLayout.MaxColScrollRegions = 1;
            this.Second_Grid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.Second_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            this.Second_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.Second_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.Second_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Second_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.Second_Grid.DisplayLayout.Override.CellAppearance = appearance10;
            this.Second_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Second_Grid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Second_Grid.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.Second_Grid.DisplayLayout.Override.MaxSelectedCells = 1;
            this.Second_Grid.DisplayLayout.Override.MaxSelectedRows = 1;
            appearance12.BackColor = System.Drawing.Color.Lavender;
            this.Second_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance12;
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance13.TextVAlignAsString = "Middle";
            this.Second_Grid.DisplayLayout.Override.RowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.White;
            this.Second_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance14;
            this.Second_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.Second_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Second_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.Second_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.Second_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Second_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Second_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Second_Grid.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.Second_Grid.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.Second_Grid.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.Second_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Second_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Second_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Second_Grid.DisplayLayout.UseFixedHeaders = true;
            this.Second_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.Second_Grid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Second_Grid.Location = new System.Drawing.Point(0, 24);
            this.Second_Grid.Name = "Second_Grid";
            this.Second_Grid.Size = new System.Drawing.Size(374, 350);
            this.Second_Grid.TabIndex = 4;
            this.Second_Grid.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Second_Grid_ClickCellButton);
            this.Second_Grid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Second_Grid_KeyPress);
            this.Second_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            this.Second_Grid.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.Second_Grid_BeforeCellActivate);
            // 
            // ultraStatusBar1
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.FontData.BoldAsString = "True";
            appearance18.FontData.Name = "ＭＳ ゴシック";
            appearance18.ForeColor = System.Drawing.Color.White;
            appearance18.TextHAlignAsString = "Center";
            appearance18.TextVAlignAsString = "Middle";
            this.ultraStatusBar1.Appearance = appearance18;
            this.ultraStatusBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 0);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(374, 30);
            this.ultraStatusBar1.TabIndex = 206;
            this.ultraStatusBar1.Text = "PM拠点";
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // timer_SetFocus
            // 
            this.timer_SetFocus.Tick += new System.EventHandler(this.timer_SetFocus_Tick);
            // 
            // PMKOU02050UB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(546, 441);
            this.Controls.Add(this._PMKOU02050UBAutoHideControl);
            this.Controls.Add(this.Second_panel);
            this.Controls.Add(this.First_panel);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this._PMKOU02050UBUnpinnedTabAreaTop);
            this.Controls.Add(this._PMKOU02050UBUnpinnedTabAreaBottom);
            this.Controls.Add(this._PMKOU02050UBUnpinnedTabAreaLeft);
            this.Controls.Add(this._PMKOU02050UBUnpinnedTabAreaRight);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMKOU02050UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拠点変換設定";
            this.Load += new System.EventHandler(this.PMKOU02050UB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this.First_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.First_Grid)).EndInit();
            this.Second_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Second_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
        private Infragistics.Win.UltraWinDock.AutoHideControl _PMKOU02050UBAutoHideControl;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKOU02050UBUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKOU02050UBUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKOU02050UBUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKOU02050UBUnpinnedTabAreaRight;
        private System.Windows.Forms.Panel Second_panel;
        private System.Windows.Forms.Panel First_panel;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.UltraWinGrid.UltraGrid Second_Grid;
        private Infragistics.Win.UltraWinGrid.UltraGrid First_Grid;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar2;
        private System.Windows.Forms.Timer timer_SetFocus;
    }
}