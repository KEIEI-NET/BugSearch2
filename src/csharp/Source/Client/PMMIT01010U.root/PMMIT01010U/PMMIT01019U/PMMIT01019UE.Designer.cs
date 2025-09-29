namespace Broadleaf.Windows.Forms
{
	partial class PMMIT01019UE
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && ( components != null ))
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
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
			Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMMIT01019UE));
			this.panel1 = new System.Windows.Forms.Panel();
			this.tEdit_PatternName = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.tComboEditor_SearchType = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.panel2 = new System.Windows.Forms.Panel();
			this.uGrid_Detail = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.uButton_DownDetailItem = new Infragistics.Win.Misc.UltraButton();
			this.uButton_UpDetailItem = new Infragistics.Win.Misc.UltraButton();
			this.uButton_Cancel = new Infragistics.Win.Misc.UltraButton();
			this.uButton_Ok = new Infragistics.Win.Misc.UltraButton();
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.panel1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.tEdit_PatternName ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_SearchType ) ).BeginInit();
			this.panel2.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.uGrid_Detail ) ).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.GhostWhite;
			this.panel1.Controls.Add(this.tEdit_PatternName);
			this.panel1.Controls.Add(this.ultraLabel1);
			this.panel1.Controls.Add(this.ultraLabel2);
			this.panel1.Controls.Add(this.tComboEditor_SearchType);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(450, 76);
			this.panel1.TabIndex = 27;
			// 
			// tEdit_PatternName
			// 
			this.tEdit_PatternName.ActiveAppearance = appearance2;
			this.tEdit_PatternName.AutoSelect = true;
			this.tEdit_PatternName.DataText = "";
			this.tEdit_PatternName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tEdit_PatternName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
			this.tEdit_PatternName.Location = new System.Drawing.Point(105, 12);
			this.tEdit_PatternName.MaxLength = 20;
			this.tEdit_PatternName.Name = "tEdit_PatternName";
			this.tEdit_PatternName.Size = new System.Drawing.Size(330, 24);
			this.tEdit_PatternName.TabIndex = 0;
			// 
			// ultraLabel1
			// 
			appearance28.TextVAlignAsString = "Middle";
			this.ultraLabel1.Appearance = appearance28;
			this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel1.Location = new System.Drawing.Point(12, 42);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(87, 24);
			this.ultraLabel1.TabIndex = 36;
			this.ultraLabel1.Text = "検索部品";
			// 
			// ultraLabel2
			// 
			appearance1.TextVAlignAsString = "Middle";
			this.ultraLabel2.Appearance = appearance1;
			this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel2.Location = new System.Drawing.Point(12, 12);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(87, 24);
			this.ultraLabel2.TabIndex = 34;
			this.ultraLabel2.Text = "パターン名";
			// 
			// tComboEditor_SearchType
			// 
			appearance25.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
			this.tComboEditor_SearchType.ActiveAppearance = appearance25;
			this.tComboEditor_SearchType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			appearance26.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
			this.tComboEditor_SearchType.ItemAppearance = appearance26;
			valueListItem1.DataValue = ( (short)( 1 ) );
			valueListItem1.DisplayText = "純正";
			valueListItem1.Tag = ( (short)( 0 ) );
			valueListItem2.DataValue = ( (short)( 2 ) );
			valueListItem2.DisplayText = "優良";
			valueListItem2.Tag = ( (short)( 1 ) );
			valueListItem3.DataValue = ( (short)( 3 ) );
			valueListItem3.DisplayText = "無し（表示のみ）";
			valueListItem3.Tag = ( (short)( 2 ) );
			this.tComboEditor_SearchType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
			this.tComboEditor_SearchType.Location = new System.Drawing.Point(105, 42);
			this.tComboEditor_SearchType.Name = "tComboEditor_SearchType";
			this.tComboEditor_SearchType.Size = new System.Drawing.Size(195, 24);
			this.tComboEditor_SearchType.TabIndex = 1;
			this.tComboEditor_SearchType.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SearchType_SelectionChangeCommitted);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.GhostWhite;
			this.panel2.Controls.Add(this.uGrid_Detail);
			this.panel2.Controls.Add(this.uButton_DownDetailItem);
			this.panel2.Controls.Add(this.uButton_UpDetailItem);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 76);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(450, 355);
			this.panel2.TabIndex = 28;
			// 
			// uGrid_Detail
			// 
			appearance41.BackColor = System.Drawing.Color.White;
			appearance41.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
			appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.uGrid_Detail.DisplayLayout.Appearance = appearance41;
			this.uGrid_Detail.DisplayLayout.GroupByBox.Hidden = true;
			this.uGrid_Detail.DisplayLayout.InterBandSpacing = 10;
			this.uGrid_Detail.DisplayLayout.MaxColScrollRegions = 1;
			this.uGrid_Detail.DisplayLayout.MaxRowScrollRegions = 1;
			appearance42.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
			appearance42.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
			appearance42.ForeColor = System.Drawing.Color.Black;
			this.uGrid_Detail.DisplayLayout.Override.ActiveCellAppearance = appearance42;
			this.uGrid_Detail.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.uGrid_Detail.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
			this.uGrid_Detail.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
			this.uGrid_Detail.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
			this.uGrid_Detail.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.uGrid_Detail.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
			this.uGrid_Detail.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
			this.uGrid_Detail.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
			this.uGrid_Detail.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
			this.uGrid_Detail.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
			this.uGrid_Detail.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
			this.uGrid_Detail.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
			this.uGrid_Detail.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
			this.uGrid_Detail.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
			this.uGrid_Detail.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
			this.uGrid_Detail.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Detail.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
			this.uGrid_Detail.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			appearance43.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
			appearance43.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
			appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance43.ForeColor = System.Drawing.Color.White;
			appearance43.ForeColorDisabled = System.Drawing.Color.White;
			appearance43.TextHAlignAsString = "Center";
			appearance43.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance = appearance43;
			appearance44.BackColor = System.Drawing.Color.Lavender;
			this.uGrid_Detail.DisplayLayout.Override.RowAlternateAppearance = appearance44;
			appearance45.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
			appearance45.TextVAlignAsString = "Middle";
			this.uGrid_Detail.DisplayLayout.Override.RowAppearance = appearance45;
			this.uGrid_Detail.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
			this.uGrid_Detail.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
			appearance46.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
			appearance46.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
			appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance46.ForeColor = System.Drawing.Color.White;
			this.uGrid_Detail.DisplayLayout.Override.RowSelectorAppearance = appearance46;
			this.uGrid_Detail.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Detail.DisplayLayout.Override.RowSelectorWidth = 20;
			this.uGrid_Detail.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
			appearance47.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
			appearance47.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
			appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance47.ForeColor = System.Drawing.Color.Black;
			this.uGrid_Detail.DisplayLayout.Override.SelectedRowAppearance = appearance47;
			this.uGrid_Detail.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
			this.uGrid_Detail.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.uGrid_Detail.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
			this.uGrid_Detail.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Detail.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Detail.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Detail.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
			this.uGrid_Detail.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.uGrid_Detail.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.uGrid_Detail.DisplayLayout.UseFixedHeaders = true;
			this.uGrid_Detail.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.uGrid_Detail.Dock = System.Windows.Forms.DockStyle.Left;
			this.uGrid_Detail.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
			this.uGrid_Detail.Location = new System.Drawing.Point(0, 0);
			this.uGrid_Detail.Name = "uGrid_Detail";
			this.uGrid_Detail.Size = new System.Drawing.Size(407, 355);
			this.uGrid_Detail.TabIndex = 0;
			this.uGrid_Detail.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_DetailPattern_InitializeLayout);
			this.uGrid_Detail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uGrid_Detail_MouseClick);
			this.uGrid_Detail.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Detail_AfterCellUpdate);
			// 
			// uButton_DownDetailItem
			// 
			this.uButton_DownDetailItem.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.uButton_DownDetailItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.uButton_DownDetailItem.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
			appearance48.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
			this.uButton_DownDetailItem.HotTrackAppearance = appearance48;
			this.uButton_DownDetailItem.Location = new System.Drawing.Point(413, 182);
			this.uButton_DownDetailItem.Name = "uButton_DownDetailItem";
			this.uButton_DownDetailItem.Size = new System.Drawing.Size(32, 59);
			this.uButton_DownDetailItem.TabIndex = 2;
			this.uButton_DownDetailItem.Text = "▼";
			this.uButton_DownDetailItem.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.uButton_DownDetailItem.Click += new System.EventHandler(this.uButton_DownDetailItem_Click);
			// 
			// uButton_UpDetailItem
			// 
			this.uButton_UpDetailItem.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.uButton_UpDetailItem.Cursor = System.Windows.Forms.Cursors.Default;
			this.uButton_UpDetailItem.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
			appearance49.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
			this.uButton_UpDetailItem.HotTrackAppearance = appearance49;
			this.uButton_UpDetailItem.Location = new System.Drawing.Point(413, 117);
			this.uButton_UpDetailItem.Name = "uButton_UpDetailItem";
			this.uButton_UpDetailItem.Size = new System.Drawing.Size(32, 59);
			this.uButton_UpDetailItem.TabIndex = 1;
			this.uButton_UpDetailItem.Text = "▲";
			this.uButton_UpDetailItem.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.uButton_UpDetailItem.Click += new System.EventHandler(this.uButton_UpDetailItem_Click);
			// 
			// uButton_Cancel
			// 
			this.uButton_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.uButton_Cancel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
			this.uButton_Cancel.Location = new System.Drawing.Point(349, 437);
			this.uButton_Cancel.Name = "uButton_Cancel";
			this.uButton_Cancel.Size = new System.Drawing.Size(96, 26);
			this.uButton_Cancel.TabIndex = 30;
			this.uButton_Cancel.Text = "キャンセル";
			this.uButton_Cancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			// 
			// uButton_Ok
			// 
			this.uButton_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.uButton_Ok.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
			this.uButton_Ok.Location = new System.Drawing.Point(247, 437);
			this.uButton_Ok.Name = "uButton_Ok";
			this.uButton_Ok.Size = new System.Drawing.Size(96, 26);
			this.uButton_Ok.TabIndex = 29;
			this.uButton_Ok.Text = "ＯＫ";
			this.uButton_Ok.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.uButton_Ok.Click += new System.EventHandler(this.uButton_Ok_Click);
			// 
			// tArrowKeyControl1
			// 
			this.tArrowKeyControl1.OwnerForm = this;
			// 
			// tRetKeyControl1
			// 
			this.tRetKeyControl1.OwnerForm = this;
			this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			// 
			// PMMIT01019UE
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(450, 466);
			this.Controls.Add(this.uButton_Cancel);
			this.Controls.Add(this.uButton_Ok);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PMMIT01019UE";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "明細パターン編集";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMMIT01019UE_FormClosing);
			this.Load += new System.EventHandler(this.PMMIT01019UE_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.tEdit_PatternName ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_SearchType ) ).EndInit();
			this.panel2.ResumeLayout(false);
			( (System.ComponentModel.ISupportInitialize)( this.uGrid_Detail ) ).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SearchType;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton uButton_Cancel;
		private Infragistics.Win.Misc.UltraButton uButton_Ok;
		internal Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Detail;
		private Infragistics.Win.Misc.UltraButton uButton_DownDetailItem;
		private Infragistics.Win.Misc.UltraButton uButton_UpDetailItem;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_PatternName;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;


	}
}