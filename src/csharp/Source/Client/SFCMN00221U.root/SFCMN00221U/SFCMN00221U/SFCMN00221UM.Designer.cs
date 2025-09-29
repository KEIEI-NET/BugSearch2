using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	partial class SFCMN00221UM
	{
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
		private Infragistics.Win.Misc.UltraButton uButton_Find;
		internal System.Windows.Forms.Panel panel_Main;
		private System.Data.DataSet dataSet_CustomerSearch;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_Condition;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerFindCondition;
		private Infragistics.Win.Misc.UltraLabel uLabel_CustomerTitle;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerFindCondition;
		private System.Windows.Forms.Panel panel_Condition;
		private System.Windows.Forms.Timer timer_Search;
		private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Search;
		private System.Windows.Forms.Timer timer_Activated;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CustomerFindCondition;
		private Infragistics.Win.Misc.UltraLabel uLabel_CustomerFindCondition;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_CAddUpDisplay;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_GridFontSize;
		private System.Windows.Forms.Timer timer_MessageUnDisp;
		private System.Windows.Forms.ToolTip toolTip_Hint;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナ デザイナで生成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
			Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
			Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
			this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
			this.tNedit_CustomerFindCondition = new Broadleaf.Library.Windows.Forms.TNedit();
			this.uLabel_CustomerTitle = new Infragistics.Win.Misc.UltraLabel();
			this.uButton_Find = new Infragistics.Win.Misc.UltraButton();
			this.tEdit_CustomerFindCondition = new Broadleaf.Library.Windows.Forms.TEdit();
			this.tComboEditor_CustomerFindCondition = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.uLabel_CustomerFindCondition = new Infragistics.Win.Misc.UltraLabel();
			this.tComboEditor_GridFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.panel_Main = new System.Windows.Forms.Panel();
			this.uGrid_Search = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.panel_Condition = new System.Windows.Forms.Panel();
			this.uExplorerBar_Condition = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.uCheckEditor_CAddUpDisplay = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.dataSet_CustomerSearch = new System.Data.DataSet();
			this.timer_Search = new System.Windows.Forms.Timer(this.components);
			this.timer_Activated = new System.Windows.Forms.Timer(this.components);
			this.timer_MessageUnDisp = new System.Windows.Forms.Timer(this.components);
			this.toolTip_Hint = new System.Windows.Forms.ToolTip(this.components);
			this.uToolTipManager_Information = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.ultraExplorerBarContainerControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerFindCondition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerFindCondition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustomerFindCondition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GridFontSize)).BeginInit();
			this.panel_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uGrid_Search)).BeginInit();
			this.panel_Condition.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Condition)).BeginInit();
			this.uExplorerBar_Condition.SuspendLayout();
			this.uStatusBar_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataSet_CustomerSearch)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraExplorerBarContainerControl2
			// 
			this.ultraExplorerBarContainerControl2.Controls.Add(this.tNedit_CustomerFindCondition);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.uLabel_CustomerTitle);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.uButton_Find);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.tEdit_CustomerFindCondition);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.tComboEditor_CustomerFindCondition);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.uLabel_CustomerFindCondition);
			this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(6, 29);
			this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
			this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(338, 101);
			this.ultraExplorerBarContainerControl2.TabIndex = 0;
			// 
			// tNedit_CustomerFindCondition
			// 
			appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tNedit_CustomerFindCondition.ActiveAppearance = appearance45;
			appearance46.TextHAlign = Infragistics.Win.HAlign.Right;
			this.tNedit_CustomerFindCondition.Appearance = appearance46;
			this.tNedit_CustomerFindCondition.AutoSelect = true;
			this.tNedit_CustomerFindCondition.AutoSize = false;
			this.tNedit_CustomerFindCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			this.tNedit_CustomerFindCondition.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.tNedit_CustomerFindCondition.CalcSize = new System.Drawing.Size(172, 200);
			this.tNedit_CustomerFindCondition.DataText = "";
			this.tNedit_CustomerFindCondition.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tNedit_CustomerFindCondition.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.tNedit_CustomerFindCondition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tNedit_CustomerFindCondition.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.tNedit_CustomerFindCondition.Location = new System.Drawing.Point(11, 80);
			this.tNedit_CustomerFindCondition.MaxLength = 9;
			this.tNedit_CustomerFindCondition.Name = "tNedit_CustomerFindCondition";
			this.tNedit_CustomerFindCondition.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
			this.tNedit_CustomerFindCondition.Size = new System.Drawing.Size(211, 20);
            this.tNedit_CustomerFindCondition.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.tNedit_CustomerFindCondition.TabIndex = 2;
			this.tNedit_CustomerFindCondition.Enter += new System.EventHandler(this.tNedit_CustomerFindCondition_Enter);
			this.tNedit_CustomerFindCondition.Leave += new System.EventHandler(this.tNedit_CustomerFindCondition_Leave);
			// 
			// uLabel_CustomerTitle
			// 
			appearance47.ForeColor = System.Drawing.Color.Navy;
			this.uLabel_CustomerTitle.Appearance = appearance47;
			this.uLabel_CustomerTitle.BackColor = System.Drawing.Color.Transparent;
			this.uLabel_CustomerTitle.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.uLabel_CustomerTitle.ImageTransparentColor = System.Drawing.Color.Empty;
			this.uLabel_CustomerTitle.Location = new System.Drawing.Point(0, 1);
			this.uLabel_CustomerTitle.Name = "uLabel_CustomerTitle";
			this.uLabel_CustomerTitle.Size = new System.Drawing.Size(230, 16);
			this.uLabel_CustomerTitle.TabIndex = 8;
			this.uLabel_CustomerTitle.Text = "得意先情報";
			// 
			// uButton_Find
			// 
			this.uButton_Find.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Find.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.uButton_Find.Location = new System.Drawing.Point(283, 75);
			this.uButton_Find.Name = "uButton_Find";
			this.uButton_Find.Size = new System.Drawing.Size(47, 25);
			this.uButton_Find.TabIndex = 3;
			this.uButton_Find.Text = "検索";
			this.uButton_Find.Click += new System.EventHandler(this.uButton_Find_Click);
			// 
			// tEdit_CustomerFindCondition
			// 
			appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tEdit_CustomerFindCondition.ActiveAppearance = appearance48;
			this.tEdit_CustomerFindCondition.AutoSelect = true;
			this.tEdit_CustomerFindCondition.AutoSize = false;
			this.tEdit_CustomerFindCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			this.tEdit_CustomerFindCondition.DataText = "";
			this.tEdit_CustomerFindCondition.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tEdit_CustomerFindCondition.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.tEdit_CustomerFindCondition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tEdit_CustomerFindCondition.Location = new System.Drawing.Point(11, 66);
			this.tEdit_CustomerFindCondition.MaxLength = 12;
			this.tEdit_CustomerFindCondition.Name = "tEdit_CustomerFindCondition";
			this.tEdit_CustomerFindCondition.Size = new System.Drawing.Size(211, 20);
            this.tEdit_CustomerFindCondition.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.tEdit_CustomerFindCondition.TabIndex = 1;
			this.tEdit_CustomerFindCondition.Enter += new System.EventHandler(this.tEdit_CustomerFindCondition_Enter);
			this.tEdit_CustomerFindCondition.Leave += new System.EventHandler(this.tEdit_CustomerFindCondition_Leave);
			// 
			// tComboEditor_CustomerFindCondition
			// 
			appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tComboEditor_CustomerFindCondition.ActiveAppearance = appearance49;
			this.tComboEditor_CustomerFindCondition.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.tComboEditor_CustomerFindCondition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tComboEditor_CustomerFindCondition.ItemAppearance = appearance50;
			valueListItem19.DataValue = 1;
			valueListItem19.DisplayText = "カナ";
			valueListItem20.DataValue = 2;
			valueListItem20.DisplayText = "コード";
			valueListItem21.DataValue = 4;
			valueListItem21.DisplayText = "サブコード";
			valueListItem22.DataValue = 6;
			valueListItem22.DisplayText = "電話番号（検索番号）";
			this.tComboEditor_CustomerFindCondition.Items.Add(valueListItem19);
			this.tComboEditor_CustomerFindCondition.Items.Add(valueListItem20);
			this.tComboEditor_CustomerFindCondition.Items.Add(valueListItem21);
			this.tComboEditor_CustomerFindCondition.Items.Add(valueListItem22);
			this.tComboEditor_CustomerFindCondition.Location = new System.Drawing.Point(10, 23);
			this.tComboEditor_CustomerFindCondition.MaxDropDownItems = 60;
			this.tComboEditor_CustomerFindCondition.Name = "tComboEditor_CustomerFindCondition";
			this.tComboEditor_CustomerFindCondition.Size = new System.Drawing.Size(320, 24);
			this.tComboEditor_CustomerFindCondition.TabIndex = 0;
			this.tComboEditor_CustomerFindCondition.SizeChanged += new System.EventHandler(this.tComboEditor_CustomerFindCondition_SizeChanged);
			this.tComboEditor_CustomerFindCondition.ValueChanged += new System.EventHandler(this.tComboEditor_FindCondition_ValueChanged);
			// 
			// uLabel_CustomerFindCondition
			// 
			appearance51.BackColor = System.Drawing.Color.White;
			appearance51.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			appearance51.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.uLabel_CustomerFindCondition.Appearance = appearance51;
			this.uLabel_CustomerFindCondition.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
			this.uLabel_CustomerFindCondition.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.uLabel_CustomerFindCondition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.uLabel_CustomerFindCondition.Location = new System.Drawing.Point(10, 50);
			this.uLabel_CustomerFindCondition.Name = "uLabel_CustomerFindCondition";
			this.uLabel_CustomerFindCondition.Size = new System.Drawing.Size(320, 22);
			this.uLabel_CustomerFindCondition.TabIndex = 18;
			this.uLabel_CustomerFindCondition.Click += new System.EventHandler(this.uLabel_CustomerFindCondition_Click);
			// 
			// tComboEditor_GridFontSize
			// 
			appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tComboEditor_GridFontSize.ActiveAppearance = appearance52;
			this.tComboEditor_GridFontSize.AutoSize = false;
			this.tComboEditor_GridFontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.tComboEditor_GridFontSize.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tComboEditor_GridFontSize.ItemAppearance = appearance53;
			valueListItem23.DataValue = 9;
			valueListItem23.DisplayText = "9";
			valueListItem24.DataValue = 10;
			valueListItem24.DisplayText = "10";
			valueListItem25.DataValue = 11;
			valueListItem25.DisplayText = "11";
			valueListItem26.DataValue = 12;
			valueListItem26.DisplayText = "12";
			valueListItem27.DataValue = 14;
			valueListItem27.DisplayText = "14";
			this.tComboEditor_GridFontSize.Items.Add(valueListItem23);
			this.tComboEditor_GridFontSize.Items.Add(valueListItem24);
			this.tComboEditor_GridFontSize.Items.Add(valueListItem25);
			this.tComboEditor_GridFontSize.Items.Add(valueListItem26);
			this.tComboEditor_GridFontSize.Items.Add(valueListItem27);
			this.tComboEditor_GridFontSize.Location = new System.Drawing.Point(72, 3);
			this.tComboEditor_GridFontSize.Name = "tComboEditor_GridFontSize";
			this.tComboEditor_GridFontSize.Size = new System.Drawing.Size(40, 18);
			this.tComboEditor_GridFontSize.TabIndex = 18;
			this.tComboEditor_GridFontSize.ValueChanged += new System.EventHandler(this.tComboEditor_GridFontSize_ValueChanged);
			// 
			// panel_Main
			// 
			this.panel_Main.BackColor = System.Drawing.Color.White;
			this.panel_Main.Controls.Add(this.uGrid_Search);
			this.panel_Main.Controls.Add(this.panel_Condition);
			this.panel_Main.Controls.Add(this.uStatusBar_Main);
			this.panel_Main.Controls.Add(this.uCheckEditor_CAddUpDisplay);
			this.panel_Main.Location = new System.Drawing.Point(5, 5);
			this.panel_Main.Name = "panel_Main";
			this.panel_Main.Size = new System.Drawing.Size(350, 628);
			this.panel_Main.TabIndex = 2;
			// 
			// uGrid_Search
			// 
			appearance54.BackColor = System.Drawing.Color.White;
			appearance54.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance54.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
			appearance54.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.uGrid_Search.DisplayLayout.Appearance = appearance54;
			this.uGrid_Search.DisplayLayout.GroupByBox.Hidden = true;
			this.uGrid_Search.DisplayLayout.InterBandSpacing = 10;
			this.uGrid_Search.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.uGrid_Search.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
			this.uGrid_Search.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.uGrid_Search.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Search.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
			this.uGrid_Search.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
			appearance55.BackColor = System.Drawing.Color.Transparent;
			this.uGrid_Search.DisplayLayout.Override.CardAreaAppearance = appearance55;
			this.uGrid_Search.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
			appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance56.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance56.ForeColor = System.Drawing.Color.White;
			appearance56.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance56.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			this.uGrid_Search.DisplayLayout.Override.HeaderAppearance = appearance56;
			this.uGrid_Search.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
			appearance57.BackColor = System.Drawing.Color.Lavender;
			this.uGrid_Search.DisplayLayout.Override.RowAlternateAppearance = appearance57;
			appearance58.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
			this.uGrid_Search.DisplayLayout.Override.RowAppearance = appearance58;
			this.uGrid_Search.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
			this.uGrid_Search.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
			appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance59.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.uGrid_Search.DisplayLayout.Override.RowSelectorAppearance = appearance59;
			this.uGrid_Search.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			this.uGrid_Search.DisplayLayout.Override.RowSelectorWidth = 12;
			this.uGrid_Search.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
			appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
			appearance60.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance60.ForeColor = System.Drawing.Color.Black;
			this.uGrid_Search.DisplayLayout.Override.SelectedRowAppearance = appearance60;
			this.uGrid_Search.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.uGrid_Search.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
			this.uGrid_Search.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
			this.uGrid_Search.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Search.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Search.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
			this.uGrid_Search.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
			this.uGrid_Search.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
			this.uGrid_Search.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.uGrid_Search.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.uGrid_Search.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.uGrid_Search.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uGrid_Search.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.uGrid_Search.Location = new System.Drawing.Point(0, 136);
			this.uGrid_Search.Name = "uGrid_Search";
			this.uGrid_Search.Size = new System.Drawing.Size(350, 469);
			this.uGrid_Search.TabIndex = 9;
			this.uGrid_Search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uGrid_Search_MouseDown);
			this.uGrid_Search.Click += new System.EventHandler(this.uGrid_Search_Click);
			this.uGrid_Search.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.uGrid_Search_MouseLeaveElement);
			this.uGrid_Search.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.uGrid_Search_MouseEnterElement);
			// 
			// panel_Condition
			// 
			this.panel_Condition.BackColor = System.Drawing.Color.Transparent;
			this.panel_Condition.Controls.Add(this.uExplorerBar_Condition);
			this.panel_Condition.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_Condition.Location = new System.Drawing.Point(0, 0);
			this.panel_Condition.Name = "panel_Condition";
			this.panel_Condition.Size = new System.Drawing.Size(350, 136);
			this.panel_Condition.TabIndex = 1;
			// 
			// uExplorerBar_Condition
			// 
			appearance61.BackColor = System.Drawing.Color.White;
			appearance61.BackColor2 = System.Drawing.Color.CornflowerBlue;
			appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal;
			appearance61.ForeColor = System.Drawing.Color.DarkBlue;
			this.uExplorerBar_Condition.Appearance = appearance61;
			this.uExplorerBar_Condition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.uExplorerBar_Condition.Controls.Add(this.ultraExplorerBarContainerControl2);
			this.uExplorerBar_Condition.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uExplorerBar_Condition.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl2;
			ultraExplorerBarGroup3.Key = "CustomerRecord";
			appearance62.BackColor = System.Drawing.Color.GhostWhite;
			appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance62;
			appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance63.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance63.FontData.BoldAsString = "False";
			appearance63.FontData.SizeInPoints = 11.25F;
			appearance63.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup3.Settings.AppearancesSmall.HeaderAppearance = appearance63;
			ultraExplorerBarGroup3.Text = "得 意 先 検 索";
			this.uExplorerBar_Condition.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup3});
			this.uExplorerBar_Condition.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
			this.uExplorerBar_Condition.Location = new System.Drawing.Point(0, 0);
			this.uExplorerBar_Condition.Name = "uExplorerBar_Condition";
			this.uExplorerBar_Condition.ShowDefaultContextMenu = false;
			this.uExplorerBar_Condition.Size = new System.Drawing.Size(350, 136);
			this.uExplorerBar_Condition.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
            this.uExplorerBar_Condition.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.uExplorerBar_Condition.TabIndex = 0;
			this.uExplorerBar_Condition.TabStop = false;
			this.uExplorerBar_Condition.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			// 
			// uStatusBar_Main
			// 
			this.uStatusBar_Main.Controls.Add(this.tComboEditor_GridFontSize);
			this.uStatusBar_Main.Location = new System.Drawing.Point(0, 605);
			this.uStatusBar_Main.Name = "uStatusBar_Main";
			appearance64.FontData.SizeInPoints = 9F;
			ultraStatusPanel5.Appearance = appearance64;
			ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel5.Key = "StatusBarPanel_FontSizeTitle";
			ultraStatusPanel5.Padding = new System.Drawing.Size(5, 0);
			ultraStatusPanel5.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
			ultraStatusPanel5.Text = "文字サイズ";
			ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel6.Control = this.tComboEditor_GridFontSize;
			ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
			ultraStatusPanel6.Width = 40;
			this.uStatusBar_Main.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel5,
            ultraStatusPanel6});
			this.uStatusBar_Main.Size = new System.Drawing.Size(350, 23);
			this.uStatusBar_Main.TabIndex = 21;
			this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// uCheckEditor_CAddUpDisplay
			// 
			appearance65.FontData.SizeInPoints = 9F;
			this.uCheckEditor_CAddUpDisplay.Appearance = appearance65;
			this.uCheckEditor_CAddUpDisplay.BackColor = System.Drawing.Color.Transparent;
			this.uCheckEditor_CAddUpDisplay.Location = new System.Drawing.Point(2, 3);
			this.uCheckEditor_CAddUpDisplay.Name = "uCheckEditor_CAddUpDisplay";
			this.uCheckEditor_CAddUpDisplay.Size = new System.Drawing.Size(110, 18);
			this.uCheckEditor_CAddUpDisplay.TabIndex = 21;
			this.uCheckEditor_CAddUpDisplay.Text = "締済伝票を表示";
			// 
			// dataSet_CustomerSearch
			// 
			this.dataSet_CustomerSearch.DataSetName = "NewDataSet";
			this.dataSet_CustomerSearch.Locale = new System.Globalization.CultureInfo("ja-JP");
			// 
			// timer_Search
			// 
			this.timer_Search.Interval = 1;
			this.timer_Search.Tick += new System.EventHandler(this.timer_Search_Tick);
			// 
			// timer_Activated
			// 
			this.timer_Activated.Interval = 10;
			this.timer_Activated.Tick += new System.EventHandler(this.timer_Activated_Tick);
			// 
			// timer_MessageUnDisp
			// 
			this.timer_MessageUnDisp.Interval = 3000;
			this.timer_MessageUnDisp.Tick += new System.EventHandler(this.timer_MessageUnDisp_Tick);
			// 
			// uToolTipManager_Information
			// 
			appearance66.FontData.Name = "ＭＳ ゴシック";
			this.uToolTipManager_Information.Appearance = appearance66;
			// 
			// tRetKeyControl1
			// 
			this.tRetKeyControl1.OwnerForm = this.panel_Main;
			this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
			// 
			// tArrowKeyControl1
			// 
			this.tArrowKeyControl1.OwnerForm = this.panel_Main;
			this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
			// 
			// SFCMN00221UM
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panel_Main);
			this.Name = "SFCMN00221UM";
			this.Size = new System.Drawing.Size(474, 612);
			this.ultraExplorerBarContainerControl2.ResumeLayout(false);
			this.ultraExplorerBarContainerControl2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerFindCondition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerFindCondition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustomerFindCondition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GridFontSize)).EndInit();
			this.panel_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.uGrid_Search)).EndInit();
			this.panel_Condition.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Condition)).EndInit();
			this.uExplorerBar_Condition.ResumeLayout(false);
			this.uStatusBar_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataSet_CustomerSearch)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uToolTipManager_Information;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
	}
}
