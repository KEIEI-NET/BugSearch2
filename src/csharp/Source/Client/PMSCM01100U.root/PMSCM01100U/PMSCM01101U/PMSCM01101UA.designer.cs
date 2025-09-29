namespace Broadleaf.Windows.Forms
{
	partial class PMSCM01101UA
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
                if (SCMController != null) SCMController.CloseLog();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM01101UA));
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("exit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("detail");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("delete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("send");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("log");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("setting");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("exit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("send");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("filter");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("delete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("detail");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("log");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("setting");
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.Stat0Cnt_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Stat2Cnt_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.suppli_label3 = new System.Windows.Forms.Label();
            this.lblLastDate = new System.Windows.Forms.Label();
            this.lblPreviousInfo = new System.Windows.Forms.Label();
            this.Stat1Cnt_label = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.initializeTimer = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ultraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.sendingCustomerGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.sendingAnswerGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._SFMIT02850UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.myToolbar = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._SFMIT02850UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFMIT02850UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).BeginInit();
            this.ultraExplorerBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sendingCustomerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendingAnswerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myToolbar)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.Stat0Cnt_label);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.label4);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.Stat2Cnt_label);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.label1);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.suppli_label3);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.lblLastDate);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.lblPreviousInfo);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.Stat1Cnt_label);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(14, 42);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(252, 51);
            this.ultraExplorerBarContainerControl1.TabIndex = 0;
            // 
            // Stat0Cnt_label
            // 
            this.Stat0Cnt_label.BackColor = System.Drawing.Color.Transparent;
            this.Stat0Cnt_label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Stat0Cnt_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Stat0Cnt_label.Location = new System.Drawing.Point(154, 25);
            this.Stat0Cnt_label.Name = "Stat0Cnt_label";
            this.Stat0Cnt_label.Size = new System.Drawing.Size(80, 18);
            this.Stat0Cnt_label.TabIndex = 8;
            this.Stat0Cnt_label.Text = "0枚";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(0, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "未処理伝票枚数";
            // 
            // Stat2Cnt_label
            // 
            this.Stat2Cnt_label.BackColor = System.Drawing.Color.Transparent;
            this.Stat2Cnt_label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Stat2Cnt_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Stat2Cnt_label.Location = new System.Drawing.Point(154, 71);
            this.Stat2Cnt_label.Name = "Stat2Cnt_label";
            this.Stat2Cnt_label.Size = new System.Drawing.Size(80, 18);
            this.Stat2Cnt_label.TabIndex = 6;
            this.Stat2Cnt_label.Text = "0枚";
            this.Stat2Cnt_label.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "送信済伝票枚数";
            this.label1.Visible = false;
            // 
            // suppli_label3
            // 
            this.suppli_label3.AutoSize = true;
            this.suppli_label3.BackColor = System.Drawing.Color.Transparent;
            this.suppli_label3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.suppli_label3.Location = new System.Drawing.Point(0, 71);
            this.suppli_label3.Name = "suppli_label3";
            this.suppli_label3.Size = new System.Drawing.Size(119, 15);
            this.suppli_label3.TabIndex = 3;
            this.suppli_label3.Text = "処理済伝票枚数";
            this.suppli_label3.Visible = false;
            // 
            // lblLastDate
            // 
            this.lblLastDate.AutoSize = true;
            this.lblLastDate.BackColor = System.Drawing.Color.Transparent;
            this.lblLastDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLastDate.Location = new System.Drawing.Point(90, 0);
            this.lblLastDate.Name = "lblLastDate";
            this.lblLastDate.Size = new System.Drawing.Size(0, 15);
            this.lblLastDate.TabIndex = 2;
            this.lblLastDate.Visible = false;
            // 
            // lblPreviousInfo
            // 
            this.lblPreviousInfo.AutoSize = true;
            this.lblPreviousInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviousInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPreviousInfo.Location = new System.Drawing.Point(0, 0);
            this.lblPreviousInfo.Name = "lblPreviousInfo";
            this.lblPreviousInfo.Size = new System.Drawing.Size(71, 15);
            this.lblPreviousInfo.TabIndex = 1;
            this.lblPreviousInfo.Text = "前回処理";
            this.lblPreviousInfo.Visible = false;
            // 
            // Stat1Cnt_label
            // 
            this.Stat1Cnt_label.BackColor = System.Drawing.Color.Transparent;
            this.Stat1Cnt_label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Stat1Cnt_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Stat1Cnt_label.Location = new System.Drawing.Point(154, 48);
            this.Stat1Cnt_label.Name = "Stat1Cnt_label";
            this.Stat1Cnt_label.Size = new System.Drawing.Size(80, 18);
            this.Stat1Cnt_label.TabIndex = 4;
            this.Stat1Cnt_label.Text = "0枚";
            this.Stat1Cnt_label.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.statusStrip1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Maximum = 3;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(114, 16);
            this.toolStripProgressBar.Step = 1;
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // initializeTimer
            // 
            this.initializeTimer.Tick += new System.EventHandler(this.initializeTimer_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.splitContainer1.Panel1.Controls.Add(this.ultraExplorerBar1);
            this.splitContainer1.Panel1.Controls.Add(this.sendingCustomerGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.splitContainer1.Panel2.Controls.Add(this.sendingAnswerGrid);
            this.splitContainer1.Size = new System.Drawing.Size(792, 510);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 23;
            // 
            // ultraExplorerBar1
            // 
            this.ultraExplorerBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraExplorerBar1.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.ultraExplorerBar1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup1.Key = "Info";
            ultraExplorerBarGroup1.Settings.ContainerHeight = 98;
            ultraExplorerBarGroup1.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup1.Text = "情報";
            this.ultraExplorerBar1.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.ultraExplorerBar1.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.GroupSettings.AllowItemDrop = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.GroupSettings.AllowItemUncheck = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.Location = new System.Drawing.Point(509, 3);
            this.ultraExplorerBar1.Margins.Bottom = 4;
            this.ultraExplorerBar1.Margins.Left = 8;
            this.ultraExplorerBar1.Margins.Right = 8;
            this.ultraExplorerBar1.Margins.Top = 8;
            this.ultraExplorerBar1.Name = "ultraExplorerBar1";
            this.ultraExplorerBar1.ShowDefaultContextMenu = false;
            this.ultraExplorerBar1.Size = new System.Drawing.Size(280, 110);
            this.ultraExplorerBar1.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
            this.ultraExplorerBar1.TabIndex = 23;
            // 
            // sendingCustomerGrid
            // 
            this.sendingCustomerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.sendingCustomerGrid.DisplayLayout.Appearance = appearance1;
            this.sendingCustomerGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.sendingCustomerGrid.DisplayLayout.InterBandSpacing = 10;
            this.sendingCustomerGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.sendingCustomerGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.sendingCustomerGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.sendingCustomerGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.sendingCustomerGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.sendingCustomerGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.sendingCustomerGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Center";
            appearance2.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.sendingCustomerGrid.DisplayLayout.Override.HeaderAppearance = appearance2;
            this.sendingCustomerGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance3.BackColor = System.Drawing.Color.Lavender;
            this.sendingCustomerGrid.DisplayLayout.Override.RowAlternateAppearance = appearance3;
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance4.TextVAlignAsString = "Middle";
            this.sendingCustomerGrid.DisplayLayout.Override.RowAppearance = appearance4;
            this.sendingCustomerGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.sendingCustomerGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.White;
            this.sendingCustomerGrid.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            this.sendingCustomerGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.sendingCustomerGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.sendingCustomerGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.sendingCustomerGrid.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.sendingCustomerGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.sendingCustomerGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.sendingCustomerGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.sendingCustomerGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.sendingCustomerGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.sendingCustomerGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.sendingCustomerGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.sendingCustomerGrid.Location = new System.Drawing.Point(3, 3);
            this.sendingCustomerGrid.Name = "sendingCustomerGrid";
            this.sendingCustomerGrid.Size = new System.Drawing.Size(499, 110);
            this.sendingCustomerGrid.TabIndex = 22;
            this.sendingCustomerGrid.Text = "送信先得意先リスト";
            this.sendingCustomerGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.sendingCustomerGrid_InitializeLayout);
            this.sendingCustomerGrid.AfterRowActivate += new System.EventHandler(this.sendingCustomerGrid_AfterRowActivate);
            // 
            // sendingAnswerGrid
            // 
            this.sendingAnswerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.sendingAnswerGrid.DisplayLayout.Appearance = appearance7;
            this.sendingAnswerGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.sendingAnswerGrid.DisplayLayout.InterBandSpacing = 10;
            this.sendingAnswerGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.sendingAnswerGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.sendingAnswerGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.sendingAnswerGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.sendingAnswerGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.sendingAnswerGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.sendingAnswerGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.White;
            appearance8.TextHAlignAsString = "Center";
            appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.sendingAnswerGrid.DisplayLayout.Override.HeaderAppearance = appearance8;
            this.sendingAnswerGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance9.BackColor = System.Drawing.Color.Lavender;
            this.sendingAnswerGrid.DisplayLayout.Override.RowAlternateAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance10.TextVAlignAsString = "Middle";
            this.sendingAnswerGrid.DisplayLayout.Override.RowAppearance = appearance10;
            this.sendingAnswerGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.sendingAnswerGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.White;
            this.sendingAnswerGrid.DisplayLayout.Override.RowSelectorAppearance = appearance11;
            this.sendingAnswerGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.sendingAnswerGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.sendingAnswerGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.sendingAnswerGrid.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.sendingAnswerGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.sendingAnswerGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.sendingAnswerGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.sendingAnswerGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.sendingAnswerGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Both;
            this.sendingAnswerGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.sendingAnswerGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.sendingAnswerGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.sendingAnswerGrid.Location = new System.Drawing.Point(3, 3);
            this.sendingAnswerGrid.Name = "sendingAnswerGrid";
            this.sendingAnswerGrid.Size = new System.Drawing.Size(785, 304);
            this.sendingAnswerGrid.TabIndex = 29;
            this.sendingAnswerGrid.Text = "送信伝票リスト　　※ダブルクリックで明細情報が表示されます。";
            this.sendingAnswerGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.sendingAnswerGrid_InitializeLayout);
            this.sendingAnswerGrid.Enter += new System.EventHandler(this.sendingAnswerGrid_Enter);
            this.sendingAnswerGrid.Leave += new System.EventHandler(this.sendingAnswerGrid_Leave);
            this.sendingAnswerGrid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.sendingAnswerGrid_DblClick);
            // 
            // _SFMIT02850UA_Toolbars_Dock_Area_Left
            // 
            this._SFMIT02850UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT02850UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._SFMIT02850UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFMIT02850UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT02850UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 34);
            this._SFMIT02850UA_Toolbars_Dock_Area_Left.Name = "_SFMIT02850UA_Toolbars_Dock_Area_Left";
            this._SFMIT02850UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 510);
            this._SFMIT02850UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.myToolbar;
            // 
            // myToolbar
            // 
            appearance13.FontData.SizeInPoints = 11.25F;
            this.myToolbar.Appearance = appearance13;
            this.myToolbar.DesignerFlags = 1;
            this.myToolbar.DockWithinContainer = this;
            this.myToolbar.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.myToolbar.ImageSizeLarge = new System.Drawing.Size(24, 24);
            this.myToolbar.ImageSizeSmall = new System.Drawing.Size(24, 24);
            this.myToolbar.LockToolbars = true;
            this.myToolbar.MenuSettings.IsSideStripVisible = Infragistics.Win.DefaultableBoolean.False;
            this.myToolbar.MenuSettings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.myToolbar.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.myToolbar.ShowFullMenusDelay = 500;
            this.myToolbar.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6});
            ultraToolbar1.Text = "UltraToolbar";
            this.myToolbar.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.myToolbar.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            this.myToolbar.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            this.myToolbar.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            this.myToolbar.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            this.myToolbar.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            this.myToolbar.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            this.myToolbar.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            appearance14.FontData.SizeInPoints = 11.25F;
            this.myToolbar.ToolbarSettings.Appearance = appearance14;
            this.myToolbar.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            this.myToolbar.ToolbarSettings.GrabHandleStyle = Infragistics.Win.UltraWinToolbars.GrabHandleStyle.Office2003;
            this.myToolbar.ToolbarSettings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool7.SharedProps.Caption = "終了(&X)";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool8.SharedProps.Caption = "送信(&S)";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            comboBoxTool1.SharedProps.Width = 150;
            appearance15.FontData.SizeInPoints = 11.25F;
            valueListItem1.Appearance = appearance15;
            valueListItem1.DataValue = "ValueListItem0";
            valueListItem1.DisplayText = "0:全て表示";
            appearance16.FontData.SizeInPoints = 11.25F;
            valueListItem2.Appearance = appearance16;
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "1:送信済を非表示";
            valueList1.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            comboBoxTool1.ValueList = valueList1;
            buttonTool9.SharedProps.Caption = "削除(&D)";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.Caption = "詳細(&M)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.Caption = "ﾛｸﾞ表示(&L)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool12.SharedProps.Caption = "設定(&E)";
            buttonTool12.SharedProps.Visible = false;
            this.myToolbar.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7,
            buttonTool8,
            comboBoxTool1,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12});
            this.myToolbar.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.myToolbar_ToolClick);
            // 
            // _SFMIT02850UA_Toolbars_Dock_Area_Right
            // 
            this._SFMIT02850UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT02850UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._SFMIT02850UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFMIT02850UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT02850UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(792, 34);
            this._SFMIT02850UA_Toolbars_Dock_Area_Right.Name = "_SFMIT02850UA_Toolbars_Dock_Area_Right";
            this._SFMIT02850UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 510);
            this._SFMIT02850UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.myToolbar;
            // 
            // _SFMIT02850UA_Toolbars_Dock_Area_Top
            // 
            this._SFMIT02850UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT02850UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._SFMIT02850UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFMIT02850UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT02850UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFMIT02850UA_Toolbars_Dock_Area_Top.Name = "_SFMIT02850UA_Toolbars_Dock_Area_Top";
            this._SFMIT02850UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(792, 34);
            this._SFMIT02850UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.myToolbar;
            // 
            // _SFMIT02850UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 544);
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom.Name = "_SFMIT02850UA_Toolbars_Dock_Area_Bottom";
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(792, 0);
            this._SFMIT02850UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.myToolbar;
            // 
            // PMSCM01101UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._SFMIT02850UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFMIT02850UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT02850UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFMIT02850UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(685, 456);
            this.Name = "PMSCM01101UA";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "回答送信処理";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.PMSCM01101UA_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMSCM01101UA_FormClosing);
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).EndInit();
            this.ultraExplorerBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sendingCustomerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendingAnswerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myToolbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer initializeTimer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Infragistics.Win.UltraWinGrid.UltraGrid sendingCustomerGrid;
        private Infragistics.Win.UltraWinGrid.UltraGrid sendingAnswerGrid;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager myToolbar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT02850UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT02850UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT02850UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT02850UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar ultraExplorerBar1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private System.Windows.Forms.Label suppli_label3;
        private System.Windows.Forms.Label lblLastDate;
        private System.Windows.Forms.Label lblPreviousInfo;
        private System.Windows.Forms.Label Stat1Cnt_label;
        private System.Windows.Forms.Label Stat2Cnt_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Stat0Cnt_label;
        private System.Windows.Forms.Label label4;
        //private Broadleaf.Library.Windows.Forms.TMemPos tMemPos1;
        
	}
}

