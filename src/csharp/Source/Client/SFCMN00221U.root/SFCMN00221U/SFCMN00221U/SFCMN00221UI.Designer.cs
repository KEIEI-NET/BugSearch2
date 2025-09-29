using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	partial class SFCMN00221UI
	{
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_Condition;
		private System.Windows.Forms.Panel panel_Condition;
		internal System.Windows.Forms.Panel panel_Main;
		private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Search;
		private System.Data.DataSet dataSet_AcceptAnOrderSearch;
		private System.Windows.Forms.Timer timer_Search;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer timer_Activated;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_GridFontSize;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_CAddUpDisplay;
		private System.Windows.Forms.Timer timer_MessageUnDisp;
		private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_DateEnd;
		private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_DateSta;
		private Infragistics.Win.Misc.UltraButton uButton_Guide;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_FindCondition;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_FindCondition;
		private Infragistics.Win.Misc.UltraButton uButton_Find;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SupplierFormal;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_FindCondition;
		private Infragistics.Win.Misc.UltraLabel uLabel_SlipDate;
		private Infragistics.Win.Misc.UltraLabel uLabel_FindCondition;
		private System.Windows.Forms.Panel panel_ConditionSub;
		private System.Windows.Forms.Panel panel_ConditionSection;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_StockSectionCd;
		private Infragistics.Win.Misc.UltraLabel uLabel_DemandAddUpSecCd;
		private Broadleaf.Library.Windows.Forms.TLine tLine_SectionPanel;
		private System.Windows.Forms.ContextMenu contextMenu_Condition;
		private System.Windows.Forms.MenuItem menuItem_MakerModelClear;
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
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.panel_ConditionSub = new System.Windows.Forms.Panel();
            this.ulabel_SupplierSlipNoCndtn = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierSlipNo_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SupplierSlipNo_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_PartySaleSlipNum = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_EmployeeCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_EmployeeName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SupplierName = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SupplierSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tEdit_FindConditionCodeType = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_FindConditionCodeType = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_Find = new Infragistics.Win.Misc.UltraButton();
            this.tDateEdit_DateEnd = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tDateEdit_DateSta = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.uLabel_SlipDate = new Infragistics.Win.Misc.UltraLabel();
            this.tLine_ConditionPanel = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_Guide = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_FindCondition = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_FindCondition = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tComboEditor_SupplierFormal = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_FindCondition = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_FindCondition = new Infragistics.Win.Misc.UltraLabel();
            this.panel_ConditionSection = new System.Windows.Forms.Panel();
            this.tLine_SectionPanel = new Broadleaf.Library.Windows.Forms.TLine();
            this.uLabel_DemandAddUpSecCd = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_StockSectionCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uCheckEditor_CAddUpDisplay = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tComboEditor_GridFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.uGrid_Search = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel_Condition = new System.Windows.Forms.Panel();
            this.uExplorerBar_Condition = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.dataSet_AcceptAnOrderSearch = new System.Data.DataSet();
            this.timer_Search = new System.Windows.Forms.Timer(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.timer_Activated = new System.Windows.Forms.Timer(this.components);
            this.timer_MessageUnDisp = new System.Windows.Forms.Timer(this.components);
            this.contextMenu_Condition = new System.Windows.Forms.ContextMenu();
            this.menuItem_MakerModelClear = new System.Windows.Forms.MenuItem();
            this.toolTip_Hint = new System.Windows.Forms.ToolTip(this.components);
            this.uToolTipManager_Information = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tComboEditor_StockGoodsCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            this.panel_ConditionSub.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SupplierSlipNo_Ed ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SupplierSlipNo_St ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_PartySaleSlipNum ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_EmployeeCode ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SupplierCd ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_SupplierSlipCd ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_FindConditionCodeType ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_FindConditionCodeType ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine_ConditionPanel ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_FindCondition ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_FindCondition ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_SupplierFormal ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_FindCondition ) ).BeginInit();
            this.panel_ConditionSection.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine_SectionPanel ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_StockSectionCd ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_GridFontSize ) ).BeginInit();
            this.panel_Main.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.uGrid_Search ) ).BeginInit();
            this.panel_Condition.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.uExplorerBar_Condition ) ).BeginInit();
            this.uExplorerBar_Condition.SuspendLayout();
            this.uStatusBar_Main.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dataSet_AcceptAnOrderSearch ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_StockGoodsCd ) ).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.panel_ConditionSub);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.panel_ConditionSection);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(6, 26);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(338, 194);
            this.ultraExplorerBarContainerControl1.TabIndex = 0;
            // 
            // panel_ConditionSub
            // 
            this.panel_ConditionSub.BackColor = System.Drawing.Color.Transparent;
            this.panel_ConditionSub.Controls.Add(this.tComboEditor_StockGoodsCd);
            this.panel_ConditionSub.Controls.Add(this.ulabel_SupplierSlipNoCndtn);
            this.panel_ConditionSub.Controls.Add(this.tNedit_SupplierSlipNo_Ed);
            this.panel_ConditionSub.Controls.Add(this.tNedit_SupplierSlipNo_St);
            this.panel_ConditionSub.Controls.Add(this.tEdit_PartySaleSlipNum);
            this.panel_ConditionSub.Controls.Add(this.tEdit_EmployeeCode);
            this.panel_ConditionSub.Controls.Add(this.tNedit_SupplierCd);
            this.panel_ConditionSub.Controls.Add(this.uLabel_EmployeeName);
            this.panel_ConditionSub.Controls.Add(this.uLabel_SupplierName);
            this.panel_ConditionSub.Controls.Add(this.tComboEditor_SupplierSlipCd);
            this.panel_ConditionSub.Controls.Add(this.tEdit_FindConditionCodeType);
            this.panel_ConditionSub.Controls.Add(this.tNedit_FindConditionCodeType);
            this.panel_ConditionSub.Controls.Add(this.uButton_Find);
            this.panel_ConditionSub.Controls.Add(this.tDateEdit_DateEnd);
            this.panel_ConditionSub.Controls.Add(this.tDateEdit_DateSta);
            this.panel_ConditionSub.Controls.Add(this.uLabel_SlipDate);
            this.panel_ConditionSub.Controls.Add(this.tLine_ConditionPanel);
            this.panel_ConditionSub.Controls.Add(this.ultraLabel11);
            this.panel_ConditionSub.Controls.Add(this.ultraLabel9);
            this.panel_ConditionSub.Controls.Add(this.ultraLabel1);
            this.panel_ConditionSub.Controls.Add(this.uButton_Guide);
            this.panel_ConditionSub.Controls.Add(this.tNedit_FindCondition);
            this.panel_ConditionSub.Controls.Add(this.tEdit_FindCondition);
            this.panel_ConditionSub.Controls.Add(this.tComboEditor_SupplierFormal);
            this.panel_ConditionSub.Controls.Add(this.tComboEditor_FindCondition);
            this.panel_ConditionSub.Controls.Add(this.uLabel_FindCondition);
            this.panel_ConditionSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ConditionSub.Location = new System.Drawing.Point(0, 32);
            this.panel_ConditionSub.Name = "panel_ConditionSub";
            this.panel_ConditionSub.Size = new System.Drawing.Size(338, 162);
            this.panel_ConditionSub.TabIndex = 1;
            // 
            // ulabel_SupplierSlipNoCndtn
            // 
            appearance85.TextVAlignAsString = "Middle";
            this.ulabel_SupplierSlipNoCndtn.Appearance = appearance85;
            this.ulabel_SupplierSlipNoCndtn.Location = new System.Drawing.Point(158, 69);
            this.ulabel_SupplierSlipNoCndtn.Name = "ulabel_SupplierSlipNoCndtn";
            this.ulabel_SupplierSlipNoCndtn.Size = new System.Drawing.Size(23, 24);
            this.ulabel_SupplierSlipNoCndtn.TabIndex = 1207;
            this.ulabel_SupplierSlipNoCndtn.Text = "～";
            // 
            // tNedit_SupplierSlipNo_Ed
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance66.TextHAlignAsString = "Right";
            this.tNedit_SupplierSlipNo_Ed.ActiveAppearance = appearance66;
            appearance67.TextHAlignAsString = "Right";
            this.tNedit_SupplierSlipNo_Ed.Appearance = appearance67;
            this.tNedit_SupplierSlipNo_Ed.AutoSelect = true;
            this.tNedit_SupplierSlipNo_Ed.AutoSize = false;
            this.tNedit_SupplierSlipNo_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierSlipNo_Ed.DataText = "";
            this.tNedit_SupplierSlipNo_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierSlipNo_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierSlipNo_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierSlipNo_Ed.Location = new System.Drawing.Point(193, 74);
            this.tNedit_SupplierSlipNo_Ed.MaxLength = 9;
            this.tNedit_SupplierSlipNo_Ed.Name = "tNedit_SupplierSlipNo_Ed";
            this.tNedit_SupplierSlipNo_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierSlipNo_Ed.Size = new System.Drawing.Size(136, 22);
            this.tNedit_SupplierSlipNo_Ed.TabIndex = 7;
            // 
            // tNedit_SupplierSlipNo_St
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance10.TextHAlignAsString = "Right";
            this.tNedit_SupplierSlipNo_St.ActiveAppearance = appearance10;
            appearance11.TextHAlignAsString = "Right";
            this.tNedit_SupplierSlipNo_St.Appearance = appearance11;
            this.tNedit_SupplierSlipNo_St.AutoSelect = true;
            this.tNedit_SupplierSlipNo_St.AutoSize = false;
            this.tNedit_SupplierSlipNo_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierSlipNo_St.DataText = "";
            this.tNedit_SupplierSlipNo_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierSlipNo_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierSlipNo_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierSlipNo_St.Location = new System.Drawing.Point(10, 74);
            this.tNedit_SupplierSlipNo_St.MaxLength = 9;
            this.tNedit_SupplierSlipNo_St.Name = "tNedit_SupplierSlipNo_St";
            this.tNedit_SupplierSlipNo_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierSlipNo_St.Size = new System.Drawing.Size(136, 22);
            this.tNedit_SupplierSlipNo_St.TabIndex = 6;
            // 
            // tEdit_PartySaleSlipNum
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance16.TextHAlignAsString = "Right";
            this.tEdit_PartySaleSlipNum.ActiveAppearance = appearance16;
            appearance3.TextHAlignAsString = "Right";
            this.tEdit_PartySaleSlipNum.Appearance = appearance3;
            this.tEdit_PartySaleSlipNum.AutoSelect = true;
            this.tEdit_PartySaleSlipNum.AutoSize = false;
            this.tEdit_PartySaleSlipNum.DataText = "";
            this.tEdit_PartySaleSlipNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PartySaleSlipNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_PartySaleSlipNum.Location = new System.Drawing.Point(10, 55);
            this.tEdit_PartySaleSlipNum.MaxLength = 9;
            this.tEdit_PartySaleSlipNum.Name = "tEdit_PartySaleSlipNum";
            this.tEdit_PartySaleSlipNum.Size = new System.Drawing.Size(322, 22);
            this.tEdit_PartySaleSlipNum.TabIndex = 6;
            // 
            // tEdit_EmployeeCode
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance7.TextHAlignAsString = "Right";
            this.tEdit_EmployeeCode.ActiveAppearance = appearance7;
            appearance9.TextHAlignAsString = "Right";
            this.tEdit_EmployeeCode.Appearance = appearance9;
            this.tEdit_EmployeeCode.AutoSelect = true;
            this.tEdit_EmployeeCode.AutoSize = false;
            this.tEdit_EmployeeCode.DataText = "";
            this.tEdit_EmployeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_EmployeeCode.Location = new System.Drawing.Point(10, 85);
            this.tEdit_EmployeeCode.MaxLength = 9;
            this.tEdit_EmployeeCode.Name = "tEdit_EmployeeCode";
            this.tEdit_EmployeeCode.Size = new System.Drawing.Size(82, 22);
            this.tEdit_EmployeeCode.TabIndex = 6;
            // 
            // tNedit_SupplierCd
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance2.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.ActiveAppearance = appearance2;
            appearance4.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.Appearance = appearance4;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.AutoSize = false;
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(10, 113);
            this.tNedit_SupplierCd.MaxLength = 9;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(82, 22);
            this.tNedit_SupplierCd.TabIndex = 6;
            // 
            // uLabel_EmployeeName
            // 
            appearance57.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance57.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance57.TextVAlignAsString = "Middle";
            this.uLabel_EmployeeName.Appearance = appearance57;
            this.uLabel_EmployeeName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_EmployeeName.Cursor = System.Windows.Forms.Cursors.Default;
            this.uLabel_EmployeeName.Location = new System.Drawing.Point(98, 120);
            this.uLabel_EmployeeName.Name = "uLabel_EmployeeName";
            this.uLabel_EmployeeName.Size = new System.Drawing.Size(203, 22);
            this.uLabel_EmployeeName.TabIndex = 1201;
            this.uLabel_EmployeeName.WrapText = false;
            // 
            // uLabel_SupplierName
            // 
            appearance22.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance22.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance22.TextVAlignAsString = "Middle";
            this.uLabel_SupplierName.Appearance = appearance22;
            this.uLabel_SupplierName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SupplierName.Cursor = System.Windows.Forms.Cursors.Default;
            this.uLabel_SupplierName.Location = new System.Drawing.Point(98, 113);
            this.uLabel_SupplierName.Name = "uLabel_SupplierName";
            this.uLabel_SupplierName.Size = new System.Drawing.Size(203, 22);
            this.uLabel_SupplierName.TabIndex = 1199;
            this.uLabel_SupplierName.Text = "a";
            this.uLabel_SupplierName.WrapText = false;
            // 
            // tComboEditor_SupplierSlipCd
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_SupplierSlipCd.ActiveAppearance = appearance12;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            this.tComboEditor_SupplierSlipCd.Appearance = appearance13;
            this.tComboEditor_SupplierSlipCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance15.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_SupplierSlipCd.ItemAppearance = appearance15;
            valueListItem4.DataValue = 99;
            valueListItem4.DisplayText = "全て";
            valueListItem4.Tag = 1;
            valueListItem5.DataValue = 11;
            valueListItem5.DisplayText = "仕入";
            valueListItem5.Tag = 2;
            valueListItem6.DataValue = 21;
            valueListItem6.DisplayText = "返品";
            valueListItem6.Tag = 3;
            this.tComboEditor_SupplierSlipCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.tComboEditor_SupplierSlipCd.Location = new System.Drawing.Point(242, 0);
            this.tComboEditor_SupplierSlipCd.Name = "tComboEditor_SupplierSlipCd";
            this.tComboEditor_SupplierSlipCd.Size = new System.Drawing.Size(89, 24);
            this.tComboEditor_SupplierSlipCd.TabIndex = 1;
            // 
            // tEdit_FindConditionCodeType
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tEdit_FindConditionCodeType.ActiveAppearance = appearance8;
            this.tEdit_FindConditionCodeType.AutoSelect = true;
            this.tEdit_FindConditionCodeType.AutoSize = false;
            this.tEdit_FindConditionCodeType.DataText = "";
            this.tEdit_FindConditionCodeType.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FindConditionCodeType.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_FindConditionCodeType.Location = new System.Drawing.Point(157, 104);
            this.tEdit_FindConditionCodeType.MaxLength = 12;
            this.tEdit_FindConditionCodeType.Name = "tEdit_FindConditionCodeType";
            this.tEdit_FindConditionCodeType.Size = new System.Drawing.Size(128, 22);
            this.tEdit_FindConditionCodeType.TabIndex = 6;
            // 
            // tNedit_FindConditionCodeType
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tNedit_FindConditionCodeType.ActiveAppearance = appearance5;
            appearance6.TextHAlignAsString = "Right";
            this.tNedit_FindConditionCodeType.Appearance = appearance6;
            this.tNedit_FindConditionCodeType.AutoSelect = true;
            this.tNedit_FindConditionCodeType.AutoSize = false;
            this.tNedit_FindConditionCodeType.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_FindConditionCodeType.DataText = "";
            this.tNedit_FindConditionCodeType.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_FindConditionCodeType.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_FindConditionCodeType.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_FindConditionCodeType.Location = new System.Drawing.Point(192, 117);
            this.tNedit_FindConditionCodeType.MaxLength = 9;
            this.tNedit_FindConditionCodeType.Name = "tNedit_FindConditionCodeType";
            this.tNedit_FindConditionCodeType.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_FindConditionCodeType.Size = new System.Drawing.Size(66, 22);
            this.tNedit_FindConditionCodeType.TabIndex = 6;
            // 
            // uButton_Find
            // 
            this.uButton_Find.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.uButton_Find.Location = new System.Drawing.Point(273, 134);
            this.uButton_Find.Name = "uButton_Find";
            this.uButton_Find.Size = new System.Drawing.Size(58, 25);
            this.uButton_Find.TabIndex = 11;
            this.uButton_Find.Text = "検索";
            this.uButton_Find.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Find.Click += new System.EventHandler(this.uButton_Find_Click);
            // 
            // tDateEdit_DateEnd
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tDateEdit_DateEnd.ActiveEditAppearance = appearance75;
            this.tDateEdit_DateEnd.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_DateEnd.CalendarDisp = true;
            appearance76.TextHAlignAsString = "Left";
            appearance76.TextVAlignAsString = "Middle";
            this.tDateEdit_DateEnd.EditAppearance = appearance76;
            this.tDateEdit_DateEnd.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_DateEnd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance77.TextHAlignAsString = "Left";
            appearance77.TextVAlignAsString = "Middle";
            this.tDateEdit_DateEnd.LabelAppearance = appearance77;
            this.tDateEdit_DateEnd.Location = new System.Drawing.Point(10, 132);
            this.tDateEdit_DateEnd.Name = "tDateEdit_DateEnd";
            this.tDateEdit_DateEnd.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_DateEnd.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_DateEnd.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_DateEnd.TabIndex = 9;
            this.tDateEdit_DateEnd.TabStop = true;
            this.tDateEdit_DateEnd.Visible = false;
            // 
            // tDateEdit_DateSta
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tDateEdit_DateSta.ActiveEditAppearance = appearance78;
            this.tDateEdit_DateSta.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_DateSta.CalendarDisp = true;
            appearance79.TextHAlignAsString = "Left";
            appearance79.TextVAlignAsString = "Middle";
            this.tDateEdit_DateSta.EditAppearance = appearance79;
            this.tDateEdit_DateSta.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_DateSta.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance80.TextHAlignAsString = "Left";
            appearance80.TextVAlignAsString = "Middle";
            this.tDateEdit_DateSta.LabelAppearance = appearance80;
            this.tDateEdit_DateSta.Location = new System.Drawing.Point(10, 90);
            this.tDateEdit_DateSta.Name = "tDateEdit_DateSta";
            this.tDateEdit_DateSta.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_DateSta.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_DateSta.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_DateSta.TabIndex = 8;
            this.tDateEdit_DateSta.TabStop = true;
            this.tDateEdit_DateSta.Visible = false;
            // 
            // uLabel_SlipDate
            // 
            this.uLabel_SlipDate.BackColorInternal = System.Drawing.Color.Transparent;
            this.uLabel_SlipDate.Location = new System.Drawing.Point(95, 115);
            this.uLabel_SlipDate.Name = "uLabel_SlipDate";
            this.uLabel_SlipDate.Size = new System.Drawing.Size(18, 15);
            this.uLabel_SlipDate.TabIndex = 30;
            this.uLabel_SlipDate.Text = "～";
            // 
            // tLine_ConditionPanel
            // 
            this.tLine_ConditionPanel.BackColor = System.Drawing.Color.Transparent;
            this.tLine_ConditionPanel.ForeColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            this.tLine_ConditionPanel.Location = new System.Drawing.Point(5, 55);
            this.tLine_ConditionPanel.Name = "tLine_ConditionPanel";
            this.tLine_ConditionPanel.Size = new System.Drawing.Size(327, 10);
            this.tLine_ConditionPanel.TabIndex = 1196;
            // 
            // ultraLabel11
            // 
            appearance84.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance84;
            this.ultraLabel11.Location = new System.Drawing.Point(10, 27);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel11.TabIndex = 35;
            this.ultraLabel11.Text = "入力区分";
            // 
            // ultraLabel9
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance14;
            this.ultraLabel9.Location = new System.Drawing.Point(174, 1);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel9.TabIndex = 33;
            this.ultraLabel9.Text = "伝票区分";
            // 
            // ultraLabel1
            // 
            appearance86.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance86;
            this.ultraLabel1.Location = new System.Drawing.Point(10, 1);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel1.TabIndex = 31;
            this.ultraLabel1.Text = "伝票種別";
            // 
            // uButton_Guide
            // 
            this.uButton_Guide.Location = new System.Drawing.Point(307, 87);
            this.uButton_Guide.Name = "uButton_Guide";
            this.uButton_Guide.Size = new System.Drawing.Size(24, 23);
            this.uButton_Guide.TabIndex = 10;
            this.uButton_Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Guide.Visible = false;
            this.uButton_Guide.Click += new System.EventHandler(this.uButton_Guide_Click);
            // 
            // tNedit_FindCondition
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_FindCondition.ActiveAppearance = appearance50;
            appearance53.TextHAlignAsString = "Right";
            this.tNedit_FindCondition.Appearance = appearance53;
            this.tNedit_FindCondition.AutoSelect = true;
            this.tNedit_FindCondition.AutoSize = false;
            this.tNedit_FindCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.tNedit_FindCondition.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_FindCondition.DataText = "";
            this.tNedit_FindCondition.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_FindCondition.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_FindCondition.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_FindCondition.Location = new System.Drawing.Point(219, 90);
            this.tNedit_FindCondition.MaxLength = 9;
            this.tNedit_FindCondition.Name = "tNedit_FindCondition";
            this.tNedit_FindCondition.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_FindCondition.Size = new System.Drawing.Size(82, 20);
            this.tNedit_FindCondition.TabIndex = 6;
            this.tNedit_FindCondition.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tNedit_FindCondition.ValueChanged += new System.EventHandler(this.tNedit_FindCondition_ValueChanged);
            this.tNedit_FindCondition.Leave += new System.EventHandler(this.tNedit_FindCondition_Leave);
            this.tNedit_FindCondition.Enter += new System.EventHandler(this.tNedit_FindCondition_Enter);
            // 
            // tEdit_FindCondition
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tEdit_FindCondition.ActiveAppearance = appearance24;
            this.tEdit_FindCondition.AutoSelect = true;
            this.tEdit_FindCondition.AutoSize = false;
            this.tEdit_FindCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.tEdit_FindCondition.DataText = "";
            this.tEdit_FindCondition.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FindCondition.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_FindCondition.Location = new System.Drawing.Point(3, 90);
            this.tEdit_FindCondition.MaxLength = 12;
            this.tEdit_FindCondition.Name = "tEdit_FindCondition";
            this.tEdit_FindCondition.Size = new System.Drawing.Size(113, 20);
            this.tEdit_FindCondition.TabIndex = 6;
            this.tEdit_FindCondition.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tEdit_FindCondition.Leave += new System.EventHandler(this.tEdit_FindCondition_Leave);
            this.tEdit_FindCondition.Enter += new System.EventHandler(this.tEdit_FindCondition_Enter);
            // 
            // tComboEditor_SupplierFormal
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_SupplierFormal.ActiveAppearance = appearance90;
            this.tComboEditor_SupplierFormal.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SupplierFormal.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            appearance91.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_SupplierFormal.ItemAppearance = appearance91;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "仕入";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "入荷";
            this.tComboEditor_SupplierFormal.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8});
            this.tComboEditor_SupplierFormal.Location = new System.Drawing.Point(83, 1);
            this.tComboEditor_SupplierFormal.MaxDropDownItems = 60;
            this.tComboEditor_SupplierFormal.Name = "tComboEditor_SupplierFormal";
            this.tComboEditor_SupplierFormal.Size = new System.Drawing.Size(88, 24);
            this.tComboEditor_SupplierFormal.TabIndex = 0;
            this.tComboEditor_SupplierFormal.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SupplierFormal_SelectionChangeCommitted);
            // 
            // tComboEditor_FindCondition
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_FindCondition.ActiveAppearance = appearance92;
            this.tComboEditor_FindCondition.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_FindCondition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            appearance93.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_FindCondition.ItemAppearance = appearance93;
            valueListItem9.DataValue = 1;
            valueListItem9.DisplayText = "仕入日";
            valueListItem10.DataValue = 2;
            valueListItem10.DisplayText = "入力日";
            valueListItem11.DataValue = 3;
            valueListItem11.DisplayText = "仕入SEQ番号";
            valueListItem12.DataValue = 4;
            valueListItem12.DisplayText = "担当者";
            valueListItem13.DataValue = 5;
            valueListItem13.DisplayText = "仕入先";
            valueListItem14.DataValue = 8;
            valueListItem14.DisplayText = "伝票番号";
            this.tComboEditor_FindCondition.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14});
            this.tComboEditor_FindCondition.Location = new System.Drawing.Point(10, 60);
            this.tComboEditor_FindCondition.MaxDropDownItems = 60;
            this.tComboEditor_FindCondition.Name = "tComboEditor_FindCondition";
            this.tComboEditor_FindCondition.Size = new System.Drawing.Size(321, 24);
            this.tComboEditor_FindCondition.TabIndex = 5;
            this.tComboEditor_FindCondition.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_FindCondition_SelectionChangeCommitted);
            this.tComboEditor_FindCondition.ValueChanged += new System.EventHandler(this.tComboEditor_FindCondition_ValueChanged);
            // 
            // uLabel_FindCondition
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance1.TextVAlignAsString = "Middle";
            this.uLabel_FindCondition.Appearance = appearance1;
            this.uLabel_FindCondition.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_FindCondition.Cursor = System.Windows.Forms.Cursors.Default;
            this.uLabel_FindCondition.Location = new System.Drawing.Point(10, 89);
            this.uLabel_FindCondition.Name = "uLabel_FindCondition";
            this.uLabel_FindCondition.Size = new System.Drawing.Size(289, 22);
            this.uLabel_FindCondition.TabIndex = 18;
            this.uLabel_FindCondition.Click += new System.EventHandler(this.uLabel_FindCondition_Click);
            // 
            // panel_ConditionSection
            // 
            this.panel_ConditionSection.BackColor = System.Drawing.Color.Transparent;
            this.panel_ConditionSection.Controls.Add(this.tLine_SectionPanel);
            this.panel_ConditionSection.Controls.Add(this.uLabel_DemandAddUpSecCd);
            this.panel_ConditionSection.Controls.Add(this.tComboEditor_StockSectionCd);
            this.panel_ConditionSection.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ConditionSection.Location = new System.Drawing.Point(0, 0);
            this.panel_ConditionSection.Name = "panel_ConditionSection";
            this.panel_ConditionSection.Size = new System.Drawing.Size(338, 32);
            this.panel_ConditionSection.TabIndex = 0;
            // 
            // tLine_SectionPanel
            // 
            this.tLine_SectionPanel.BackColor = System.Drawing.Color.Transparent;
            this.tLine_SectionPanel.ForeColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            this.tLine_SectionPanel.Location = new System.Drawing.Point(5, 28);
            this.tLine_SectionPanel.Name = "tLine_SectionPanel";
            this.tLine_SectionPanel.Size = new System.Drawing.Size(327, 1);
            this.tLine_SectionPanel.TabIndex = 5;
            // 
            // uLabel_DemandAddUpSecCd
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.uLabel_DemandAddUpSecCd.Appearance = appearance27;
            this.uLabel_DemandAddUpSecCd.Location = new System.Drawing.Point(10, 0);
            this.uLabel_DemandAddUpSecCd.Name = "uLabel_DemandAddUpSecCd";
            this.uLabel_DemandAddUpSecCd.Size = new System.Drawing.Size(67, 24);
            this.uLabel_DemandAddUpSecCd.TabIndex = 4;
            this.uLabel_DemandAddUpSecCd.Text = "仕入拠点";
            // 
            // tComboEditor_StockSectionCd
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_StockSectionCd.ActiveAppearance = appearance28;
            this.tComboEditor_StockSectionCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_StockSectionCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tComboEditor_StockSectionCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance29.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_StockSectionCd.ItemAppearance = appearance29;
            this.tComboEditor_StockSectionCd.Location = new System.Drawing.Point(83, 0);
            this.tComboEditor_StockSectionCd.Name = "tComboEditor_StockSectionCd";
            this.tComboEditor_StockSectionCd.Size = new System.Drawing.Size(246, 24);
            this.tComboEditor_StockSectionCd.TabIndex = 0;
            // 
            // uCheckEditor_CAddUpDisplay
            // 
            appearance30.FontData.SizeInPoints = 9F;
            this.uCheckEditor_CAddUpDisplay.Appearance = appearance30;
            this.uCheckEditor_CAddUpDisplay.BackColor = System.Drawing.Color.Transparent;
            this.uCheckEditor_CAddUpDisplay.BackColorInternal = System.Drawing.Color.Transparent;
            this.uCheckEditor_CAddUpDisplay.Location = new System.Drawing.Point(2, 3);
            this.uCheckEditor_CAddUpDisplay.Name = "uCheckEditor_CAddUpDisplay";
            this.uCheckEditor_CAddUpDisplay.Size = new System.Drawing.Size(110, 18);
            this.uCheckEditor_CAddUpDisplay.TabIndex = 21;
            this.uCheckEditor_CAddUpDisplay.Text = "締済伝票を表示";
            // 
            // tComboEditor_GridFontSize
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_GridFontSize.ActiveAppearance = appearance31;
            this.tComboEditor_GridFontSize.AutoSize = false;
            this.tComboEditor_GridFontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_GridFontSize.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            appearance32.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_GridFontSize.ItemAppearance = appearance32;
            valueListItem15.DataValue = 9;
            valueListItem15.DisplayText = "9";
            valueListItem16.DataValue = 10;
            valueListItem16.DisplayText = "10";
            valueListItem17.DataValue = 11;
            valueListItem17.DisplayText = "11";
            valueListItem18.DataValue = 12;
            valueListItem18.DisplayText = "12";
            valueListItem19.DataValue = 14;
            valueListItem19.DisplayText = "14";
            this.tComboEditor_GridFontSize.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem15,
            valueListItem16,
            valueListItem17,
            valueListItem18,
            valueListItem19});
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
            this.panel_Main.Location = new System.Drawing.Point(5, 5);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(350, 628);
            this.panel_Main.TabIndex = 5;
            // 
            // uGrid_Search
            // 
            appearance33.BackColor = System.Drawing.Color.White;
            appearance33.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ));
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            appearance33.TextVAlignAsString = "Middle";
            this.uGrid_Search.DisplayLayout.Appearance = appearance33;
            this.uGrid_Search.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Search.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Search.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_Search.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.uGrid_Search.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Search.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Search.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_Search.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.uGrid_Search.DisplayLayout.Override.CardAreaAppearance = appearance34;
            this.uGrid_Search.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance35.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance35.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance35.ForeColor = System.Drawing.Color.White;
            appearance35.TextHAlignAsString = "Left";
            appearance35.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Search.DisplayLayout.Override.HeaderAppearance = appearance35;
            this.uGrid_Search.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance36.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Search.DisplayLayout.Override.RowAlternateAppearance = appearance36;
            appearance37.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 1 ) ) ) ), ( (int)( ( (byte)( 68 ) ) ) ), ( (int)( ( (byte)( 208 ) ) ) ));
            this.uGrid_Search.DisplayLayout.Override.RowAppearance = appearance37;
            this.uGrid_Search.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Search.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance38.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance38.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Search.DisplayLayout.Override.RowSelectorAppearance = appearance38;
            this.uGrid_Search.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Search.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid_Search.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance39.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance39.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance39.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Search.DisplayLayout.Override.SelectedRowAppearance = appearance39;
            this.uGrid_Search.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Search.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Search.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Search.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Search.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Search.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Search.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
            this.uGrid_Search.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.uGrid_Search.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Search.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Search.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Search.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uGrid_Search.Location = new System.Drawing.Point(0, 226);
            this.uGrid_Search.Name = "uGrid_Search";
            this.uGrid_Search.Size = new System.Drawing.Size(350, 379);
            this.uGrid_Search.TabIndex = 2;
            this.uGrid_Search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uGrid_Search_MouseDown);
            this.uGrid_Search.Click += new System.EventHandler(this.uGrid_Search_Click);
            this.uGrid_Search.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.uGrid_Search_MouseLeaveElement);
            this.uGrid_Search.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.uGrid_Search_InitializeRow);
            this.uGrid_Search.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.uGrid_Search_MouseEnterElement);
            // 
            // panel_Condition
            // 
            this.panel_Condition.BackColor = System.Drawing.Color.Transparent;
            this.panel_Condition.Controls.Add(this.uExplorerBar_Condition);
            this.panel_Condition.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Condition.Location = new System.Drawing.Point(0, 0);
            this.panel_Condition.Name = "panel_Condition";
            this.panel_Condition.Size = new System.Drawing.Size(350, 226);
            this.panel_Condition.TabIndex = 1;
            // 
            // uExplorerBar_Condition
            // 
            this.uExplorerBar_Condition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uExplorerBar_Condition.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.uExplorerBar_Condition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uExplorerBar_Condition.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
            appearance40.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ));
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance40;
            appearance41.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 84 ) ) ) ), ( (int)( ( (byte)( 130 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            appearance41.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 15 ) ) ) ), ( (int)( ( (byte)( 67 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance41.FontData.BoldAsString = "False";
            appearance41.FontData.SizeInPoints = 11.25F;
            appearance41.ForeColor = System.Drawing.Color.White;
            ultraExplorerBarGroup1.Settings.AppearancesSmall.HeaderAppearance = appearance41;
            ultraExplorerBarGroup1.Text = "仕 入 伝 票 検 索";
            this.uExplorerBar_Condition.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.uExplorerBar_Condition.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.uExplorerBar_Condition.Location = new System.Drawing.Point(0, 0);
            this.uExplorerBar_Condition.Name = "uExplorerBar_Condition";
            this.uExplorerBar_Condition.ShowDefaultContextMenu = false;
            this.uExplorerBar_Condition.Size = new System.Drawing.Size(350, 226);
            this.uExplorerBar_Condition.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
            this.uExplorerBar_Condition.TabIndex = 19;
            this.uExplorerBar_Condition.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.uExplorerBar_Condition.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Controls.Add(this.uCheckEditor_CAddUpDisplay);
            this.uStatusBar_Main.Controls.Add(this.tComboEditor_GridFontSize);
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 605);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            ultraStatusPanel1.AccessibleName = "";
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Control = this.uCheckEditor_CAddUpDisplay;
            ultraStatusPanel1.Key = "StatusBarPanel_CAddUpDisplay";
            ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel1.Visible = false;
            ultraStatusPanel1.Width = 110;
            appearance42.FontData.SizeInPoints = 9F;
            ultraStatusPanel2.Appearance = appearance42;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraStatusPanel2.Key = "StatusBarPanel_Separator";
            ultraStatusPanel2.Visible = false;
            ultraStatusPanel2.Width = 1;
            appearance43.FontData.SizeInPoints = 9F;
            ultraStatusPanel3.Appearance = appearance43;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel3.Key = "StatusBarPanel_FontSizeTitle";
            ultraStatusPanel3.Padding = new System.Drawing.Size(5, 0);
            ultraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel3.Text = "文字サイズ";
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Control = this.tComboEditor_GridFontSize;
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel4.Width = 40;
            this.uStatusBar_Main.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4});
            this.uStatusBar_Main.Size = new System.Drawing.Size(350, 23);
            this.uStatusBar_Main.TabIndex = 20;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // dataSet_AcceptAnOrderSearch
            // 
            this.dataSet_AcceptAnOrderSearch.DataSetName = "NewDataSet";
            this.dataSet_AcceptAnOrderSearch.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // timer_Search
            // 
            this.timer_Search.Interval = 1;
            this.timer_Search.Tick += new System.EventHandler(this.timer_Search_Tick);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this.panel_Main;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this.panel_Main;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
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
            // contextMenu_Condition
            // 
            this.contextMenu_Condition.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_MakerModelClear});
            // 
            // menuItem_MakerModelClear
            // 
            this.menuItem_MakerModelClear.Index = 0;
            this.menuItem_MakerModelClear.Text = "クリア(&C)";
            // 
            // uToolTipManager_Information
            // 
            this.uToolTipManager_Information.ContainingControl = this;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tComboEditor_StockGoodsCd
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_StockGoodsCd.ActiveAppearance = appearance69;
            appearance70.ForeColorDisabled = System.Drawing.Color.Black;
            this.tComboEditor_StockGoodsCd.Appearance = appearance70;
            this.tComboEditor_StockGoodsCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance71.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.tComboEditor_StockGoodsCd.ItemAppearance = appearance71;
            valueListItem1.DataValue = 99;
            valueListItem1.DisplayText = "全て";
            valueListItem1.Tag = 1;
            valueListItem2.DataValue = 0;
            valueListItem2.DisplayText = "明細";
            valueListItem2.Tag = 2;
            valueListItem3.DataValue = 6;
            valueListItem3.DisplayText = "合計";
            valueListItem3.Tag = 3;
            this.tComboEditor_StockGoodsCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.tComboEditor_StockGoodsCd.Location = new System.Drawing.Point(83, 27);
            this.tComboEditor_StockGoodsCd.Name = "tComboEditor_StockGoodsCd";
            this.tComboEditor_StockGoodsCd.Size = new System.Drawing.Size(248, 24);
            this.tComboEditor_StockGoodsCd.TabIndex = 2;
            // 
            // SFCMN00221UI
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel_Main);
            this.Name = "SFCMN00221UI";
            this.Size = new System.Drawing.Size(448, 646);
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.panel_ConditionSub.ResumeLayout(false);
            this.panel_ConditionSub.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SupplierSlipNo_Ed ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SupplierSlipNo_St ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_PartySaleSlipNum ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_EmployeeCode ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SupplierCd ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_SupplierSlipCd ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_FindConditionCodeType ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_FindConditionCodeType ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine_ConditionPanel ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_FindCondition ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_FindCondition ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_SupplierFormal ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_FindCondition ) ).EndInit();
            this.panel_ConditionSection.ResumeLayout(false);
            this.panel_ConditionSection.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine_SectionPanel ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_StockSectionCd ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_GridFontSize ) ).EndInit();
            this.panel_Main.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.uGrid_Search ) ).EndInit();
            this.panel_Condition.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.uExplorerBar_Condition ) ).EndInit();
            this.uExplorerBar_Condition.ResumeLayout(false);
            this.uStatusBar_Main.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.dataSet_AcceptAnOrderSearch ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tComboEditor_StockGoodsCd ) ).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uToolTipManager_Information;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Broadleaf.Library.Windows.Forms.TLine tLine_ConditionPanel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_FindConditionCodeType;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_FindConditionCodeType;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SupplierSlipCd;
        private Infragistics.Win.Misc.UltraLabel uLabel_SupplierName;
        private Infragistics.Win.Misc.UltraLabel uLabel_EmployeeName;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierCd;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_EmployeeCode;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_PartySaleSlipNum;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierSlipNo_Ed;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierSlipNo_St;
        private Infragistics.Win.Misc.UltraLabel ulabel_SupplierSlipNoCndtn;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_StockGoodsCd;
	}
}
