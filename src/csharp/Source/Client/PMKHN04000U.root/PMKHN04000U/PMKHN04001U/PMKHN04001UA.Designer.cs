using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	partial class PMKHN04001UA
	{
		private System.Windows.Forms.Panel Form1_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01600UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01600UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Fill_Panel_Toolbars_Dock_Area_Bottom;
		private Broadleaf.Library.Windows.Forms.TToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ExplorerBar;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl Condition_UExplorerBarContainerControl;
		private System.Windows.Forms.Panel Condition_Panel;
		private System.Windows.Forms.Panel Condition_Kana_Panel;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerKana;
		private Infragistics.Win.Misc.UltraLabel ConditionTitle_Kana_ULabel;
		private Infragistics.Win.Misc.UltraLabel Condition_Kana_ULabel;
		private System.Windows.Forms.Panel Condition_CustomerCode_Panel;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode;
		private Infragistics.Win.Misc.UltraLabel ConditionTitle_CustomerCode_ULabel;
		private Infragistics.Win.Misc.UltraLabel Condition_CustomerCode_ULabel;
		private System.Windows.Forms.Panel Condition_SearchTelNo_Panel;
		private Infragistics.Win.Misc.UltraLabel ConditionTitle_SearchTelNo_ULabel;
		private Infragistics.Win.Misc.UltraLabel Condition_SearchTelNo_ULabel;
		private System.Windows.Forms.Panel Condition_CustomerSubCode_Panel;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerSubCode;
		private Infragistics.Win.Misc.UltraLabel ConditionTitle_CustomerSubCode_ULabel;
		private Infragistics.Win.Misc.UltraLabel Condition_CustomerSubCode_ULabel;
		private System.Windows.Forms.Panel Condition_Header_Panel;
		private System.Windows.Forms.Panel ConditionButton_FrameNo_Panel;
		private System.Windows.Forms.Splitter Center_Splitter;
		private System.Windows.Forms.Panel panel3;
		private Infragistics.Win.Misc.UltraLabel SearchResultHeader_ULabel;
		private System.Windows.Forms.Panel ExtractResult_Panel;
		private Infragistics.Win.Misc.UltraButton Search_UButton;
		private Broadleaf.Library.Windows.Forms.TEdit SearchTelNo_TEdit;
		private System.Data.DataSet Search_DataSet;
		private System.Windows.Forms.Timer Search_Timer;
		private Infragistics.Win.UltraWinGrid.UltraGrid SearchResult_UGrid;
		private System.Windows.Forms.Timer ColSizeChange_Timer;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.UltraWinTree.UltraTree ExtractConditionSetting_UTree;
		private Broadleaf.Library.Windows.Forms.TLine tLine1;
		private System.Windows.Forms.Panel DetailView_Panel;
		private System.Windows.Forms.Splitter DetailView_Splitter;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN04001UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN04001UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN04001UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN04001UA_Toolbars_Dock_Area_Right;
		private System.Windows.Forms.Timer DetailView_Timer;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoSearch_UCheckEditor;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Timer MessageUnDisp_Timer;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ExtractResult_UStatusBar;
		private Broadleaf.Library.Windows.Forms.TComboEditor GridFontSize_TComboEditor;
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_Toolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Select_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerNew_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerEdit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerDelete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Customer_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerNew_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerEdit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerDelete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("DetailView_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerDelete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerNew_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Return_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerEdit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("Customer_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerRevival_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("DetailView_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InnerDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DialogDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NoDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InnerDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DialogDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NoDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool10 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Guide_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("Customer_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Return_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Select_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN04001UA));
            this.GridFontSize_TComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DeleteIndication_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.Condition_UExplorerBarContainerControl = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.Condition_Panel = new System.Windows.Forms.Panel();
            this.Condition_CustomerSnm_Panel = new System.Windows.Forms.Panel();
            this.SnmSearchType_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tEdit_CustomerSnm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ConditionTitle_Snm_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_Snm_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_TelNum_Panel = new System.Windows.Forms.Panel();
            this.TelNum_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tEdit_TelNum = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TelNum_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_TelNum_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_MngSectionCode_Panel = new System.Windows.Forms.Panel();
            this.MngSectionCodeGuide_UButton = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_MngSectionNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_MngSectionCode_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustomerAgentCd_Panel = new System.Windows.Forms.Panel();
            this.CustomerAgentCdGuide_UButton = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerAgentCdTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustomerAgentCd_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustAnalysCode_Panel = new System.Windows.Forms.Panel();
            this.CustAnalysCode5_TNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustAnalysCode1_TNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustAnalysCode3_TNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustAnalysCode6_TNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustAnalysCode4_TNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustAnalysCode2_TNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustAnalysCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustAnalysCode_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustomerKind_Panel = new System.Windows.Forms.Panel();
            this.Receiver_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.Customer_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.CustomerKindTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustomerKind_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_Header_Panel = new System.Windows.Forms.Panel();
            this.Condition_Name_Panel = new System.Windows.Forms.Panel();
            this.NameSearchType_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tEdit_CustomerName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ConditionTitle_Name_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_Name_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_Kana_Panel = new System.Windows.Forms.Panel();
            this.KanaSearchType_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tEdit_CustomerKana = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ConditionTitle_Kana_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_Kana_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustomerCode_Panel = new System.Windows.Forms.Panel();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ConditionTitle_CustomerCode_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustomerCode_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_SearchTelNo_Panel = new System.Windows.Forms.Panel();
            this.SearchTelNo_TEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ConditionTitle_SearchTelNo_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_SearchTelNo_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustomerSubCode_Panel = new System.Windows.Forms.Panel();
            this.CustomerSubCodeSearchType_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tEdit_CustomerSubCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ConditionTitle_CustomerSubCode_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Condition_CustomerSubCode_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.ConditionButton_FrameNo_Panel = new System.Windows.Forms.Panel();
            this.MultiSelect_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.AutoSearch_UCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.Search_UButton = new Infragistics.Win.Misc.UltraButton();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.ExtractConditionSetting_UTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ExtractConditionSettingHint_Panel = new System.Windows.Forms.Panel();
            this.ExtractConditionSettingHint_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.DetailView_Splitter = new System.Windows.Forms.Splitter();
            this.DetailView_Panel = new System.Windows.Forms.Panel();
            this.ExtractResult_Panel = new System.Windows.Forms.Panel();
            this.SearchResult_UGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SearchResultHeader_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ExtractResult_UStatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Center_Splitter = new System.Windows.Forms.Splitter();
            this.Main_ExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this._SFMIT01600UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SFMIT01600UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Search_DataSet = new System.Data.DataSet();
            this.Search_Timer = new System.Windows.Forms.Timer(this.components);
            this.ColSizeChange_Timer = new System.Windows.Forms.Timer(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.DetailView_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MessageUnDisp_Timer = new System.Windows.Forms.Timer(this.components);
            this.uToolTipManager_Information = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this._PMKHN04001UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN04001UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN04001UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.GridFontSize_TComboEditor)).BeginInit();
            this.Condition_UExplorerBarContainerControl.SuspendLayout();
            this.Condition_Panel.SuspendLayout();
            this.Condition_CustomerSnm_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSnm)).BeginInit();
            this.Condition_TelNum_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_TelNum)).BeginInit();
            this.Condition_MngSectionCode_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MngSectionNm)).BeginInit();
            this.Condition_CustomerAgentCd_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeNm)).BeginInit();
            this.Condition_CustAnalysCode_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode5_TNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode1_TNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode3_TNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode6_TNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode4_TNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode2_TNedit)).BeginInit();
            this.Condition_CustomerKind_Panel.SuspendLayout();
            this.Condition_Name_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerName)).BeginInit();
            this.Condition_Kana_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerKana)).BeginInit();
            this.Condition_CustomerCode_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            this.Condition_SearchTelNo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchTelNo_TEdit)).BeginInit();
            this.Condition_CustomerSubCode_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSubCode)).BeginInit();
            this.ConditionButton_FrameNo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExtractConditionSetting_UTree)).BeginInit();
            this.ExtractConditionSettingHint_Panel.SuspendLayout();
            this.Form1_Fill_Panel.SuspendLayout();
            this.ExtractResult_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResult_UGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.ExtractResult_UStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ExplorerBar)).BeginInit();
            this.Main_ExplorerBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // GridFontSize_TComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GridFontSize_TComboEditor.ActiveAppearance = appearance1;
            this.GridFontSize_TComboEditor.AutoSize = false;
            this.GridFontSize_TComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.GridFontSize_TComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GridFontSize_TComboEditor.ItemAppearance = appearance2;
            valueListItem1.DataValue = 6;
            valueListItem1.DisplayText = "6";
            valueListItem2.DataValue = 8;
            valueListItem2.DisplayText = "8";
            valueListItem3.DataValue = 9;
            valueListItem3.DisplayText = "9";
            valueListItem4.DataValue = 10;
            valueListItem4.DisplayText = "10";
            valueListItem5.DataValue = 11;
            valueListItem5.DisplayText = "11";
            valueListItem6.DataValue = 12;
            valueListItem6.DisplayText = "12";
            valueListItem7.DataValue = 14;
            valueListItem7.DisplayText = "14";
            this.GridFontSize_TComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.GridFontSize_TComboEditor.Location = new System.Drawing.Point(70, 2);
            this.GridFontSize_TComboEditor.Name = "GridFontSize_TComboEditor";
            this.GridFontSize_TComboEditor.Size = new System.Drawing.Size(40, 19);
            this.GridFontSize_TComboEditor.TabIndex = 0;
            this.GridFontSize_TComboEditor.TabStop = false;
            this.GridFontSize_TComboEditor.ValueChanged += new System.EventHandler(this.GridFontSize_TComboEditor_ValueChanged);
            // 
            // DeleteIndication_CheckEditor
            // 
            appearance50.BackColor = System.Drawing.Color.Transparent;
            appearance50.FontData.SizeInPoints = 9F;
            appearance50.TextVAlignAsString = "Middle";
            this.DeleteIndication_CheckEditor.Appearance = appearance50;
            this.DeleteIndication_CheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.DeleteIndication_CheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.DeleteIndication_CheckEditor.Location = new System.Drawing.Point(112, 2);
            this.DeleteIndication_CheckEditor.Name = "DeleteIndication_CheckEditor";
            this.DeleteIndication_CheckEditor.Size = new System.Drawing.Size(150, 19);
            this.DeleteIndication_CheckEditor.TabIndex = 16;
            this.DeleteIndication_CheckEditor.Text = "削除済みデータの表示";
            this.DeleteIndication_CheckEditor.CheckedChanged += new System.EventHandler(this.DeleteIndication_CheckEditor_CheckedChanged);
            // 
            // Condition_UExplorerBarContainerControl
            // 
            this.Condition_UExplorerBarContainerControl.Controls.Add(this.Condition_Panel);
            this.Condition_UExplorerBarContainerControl.Controls.Add(this.ConditionButton_FrameNo_Panel);
            this.Condition_UExplorerBarContainerControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Condition_UExplorerBarContainerControl.Location = new System.Drawing.Point(1, 27);
            this.Condition_UExplorerBarContainerControl.Name = "Condition_UExplorerBarContainerControl";
            this.Condition_UExplorerBarContainerControl.Size = new System.Drawing.Size(258, 530);
            this.Condition_UExplorerBarContainerControl.TabIndex = 1;
            // 
            // Condition_Panel
            // 
            this.Condition_Panel.AutoScroll = true;
            this.Condition_Panel.BackColor = System.Drawing.Color.White;
            this.Condition_Panel.Controls.Add(this.Condition_CustomerSnm_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_TelNum_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_MngSectionCode_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_CustomerAgentCd_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_CustAnalysCode_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_CustomerKind_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_Header_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_Name_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_Kana_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_CustomerCode_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_SearchTelNo_Panel);
            this.Condition_Panel.Controls.Add(this.Condition_CustomerSubCode_Panel);
            this.Condition_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_Panel.Location = new System.Drawing.Point(0, 0);
            this.Condition_Panel.Name = "Condition_Panel";
            this.Condition_Panel.Size = new System.Drawing.Size(258, 489);
            this.Condition_Panel.TabIndex = 23;
            this.Condition_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Condition_Panel_Paint);
            this.Condition_Panel.Resize += new System.EventHandler(this.Condition_Panel_Resize);
            // 
            // Condition_CustomerSnm_Panel
            // 
            this.Condition_CustomerSnm_Panel.Controls.Add(this.SnmSearchType_UCheckEditor);
            this.Condition_CustomerSnm_Panel.Controls.Add(this.tEdit_CustomerSnm);
            this.Condition_CustomerSnm_Panel.Controls.Add(this.ConditionTitle_Snm_ULabel);
            this.Condition_CustomerSnm_Panel.Controls.Add(this.Condition_Snm_ULabel);
            this.Condition_CustomerSnm_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_CustomerSnm_Panel.Location = new System.Drawing.Point(0, 572);
            this.Condition_CustomerSnm_Panel.Name = "Condition_CustomerSnm_Panel";
            this.Condition_CustomerSnm_Panel.Size = new System.Drawing.Size(241, 59);
            this.Condition_CustomerSnm_Panel.TabIndex = 3;
            // 
            // SnmSearchType_UCheckEditor
            // 
            this.SnmSearchType_UCheckEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SnmSearchType_UCheckEditor.Location = new System.Drawing.Point(148, 1);
            this.SnmSearchType_UCheckEditor.Name = "SnmSearchType_UCheckEditor";
            this.SnmSearchType_UCheckEditor.Size = new System.Drawing.Size(84, 20);
            this.SnmSearchType_UCheckEditor.TabIndex = 1;
            this.SnmSearchType_UCheckEditor.Text = "曖昧検索";
            this.SnmSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.SnmSearchType_UCheckEditor_AfterCheckStateChanged);
            // 
            // tEdit_CustomerSnm
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerSnm.ActiveAppearance = appearance21;
            appearance22.TextHAlignAsString = "Left";
            this.tEdit_CustomerSnm.Appearance = appearance22;
            this.tEdit_CustomerSnm.AutoSelect = true;
            this.tEdit_CustomerSnm.DataText = "";
            this.tEdit_CustomerSnm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerSnm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_CustomerSnm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_CustomerSnm.Location = new System.Drawing.Point(15, 24);
            this.tEdit_CustomerSnm.MaxLength = 20;
            this.tEdit_CustomerSnm.Name = "tEdit_CustomerSnm";
            this.tEdit_CustomerSnm.Size = new System.Drawing.Size(217, 24);
            this.tEdit_CustomerSnm.TabIndex = 0;
            // 
            // ConditionTitle_Snm_ULabel
            // 
            appearance23.TextHAlignAsString = "Left";
            appearance23.TextVAlignAsString = "Middle";
            this.ConditionTitle_Snm_ULabel.Appearance = appearance23;
            this.ConditionTitle_Snm_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConditionTitle_Snm_ULabel.Location = new System.Drawing.Point(5, 2);
            this.ConditionTitle_Snm_ULabel.Name = "ConditionTitle_Snm_ULabel";
            this.ConditionTitle_Snm_ULabel.Size = new System.Drawing.Size(123, 19);
            this.ConditionTitle_Snm_ULabel.TabIndex = 1;
            this.ConditionTitle_Snm_ULabel.Text = "得意先略称";
            // 
            // Condition_Snm_ULabel
            // 
            this.Condition_Snm_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_Snm_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_Snm_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_Snm_ULabel.Name = "Condition_Snm_ULabel";
            this.Condition_Snm_ULabel.Size = new System.Drawing.Size(241, 59);
            this.Condition_Snm_ULabel.TabIndex = 0;
            // 
            // Condition_TelNum_Panel
            // 
            this.Condition_TelNum_Panel.Controls.Add(this.TelNum_UCheckEditor);
            this.Condition_TelNum_Panel.Controls.Add(this.tEdit_TelNum);
            this.Condition_TelNum_Panel.Controls.Add(this.TelNum_ULabel);
            this.Condition_TelNum_Panel.Controls.Add(this.Condition_TelNum_ULabel);
            this.Condition_TelNum_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_TelNum_Panel.Location = new System.Drawing.Point(0, 516);
            this.Condition_TelNum_Panel.Name = "Condition_TelNum_Panel";
            this.Condition_TelNum_Panel.Size = new System.Drawing.Size(241, 56);
            this.Condition_TelNum_Panel.TabIndex = 7;
            // 
            // TelNum_UCheckEditor
            // 
            this.TelNum_UCheckEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TelNum_UCheckEditor.Location = new System.Drawing.Point(148, 1);
            this.TelNum_UCheckEditor.Name = "TelNum_UCheckEditor";
            this.TelNum_UCheckEditor.Size = new System.Drawing.Size(84, 20);
            this.TelNum_UCheckEditor.TabIndex = 1;
            this.TelNum_UCheckEditor.Text = "曖昧検索";
            this.TelNum_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.TelNum_UCheckEditor_AfterCheckStateChanged);
            // 
            // tEdit_TelNum
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_TelNum.ActiveAppearance = appearance55;
            this.tEdit_TelNum.AutoSelect = true;
            this.tEdit_TelNum.DataText = "";
            this.tEdit_TelNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_TelNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_TelNum.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_TelNum.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_TelNum.Location = new System.Drawing.Point(15, 22);
            this.tEdit_TelNum.MaxLength = 16;
            this.tEdit_TelNum.Name = "tEdit_TelNum";
            this.tEdit_TelNum.Size = new System.Drawing.Size(219, 24);
            this.tEdit_TelNum.TabIndex = 309;
            // 
            // TelNum_ULabel
            // 
            appearance54.TextHAlignAsString = "Left";
            appearance54.TextVAlignAsString = "Middle";
            this.TelNum_ULabel.Appearance = appearance54;
            this.TelNum_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TelNum_ULabel.Location = new System.Drawing.Point(5, 1);
            this.TelNum_ULabel.Name = "TelNum_ULabel";
            this.TelNum_ULabel.Size = new System.Drawing.Size(123, 19);
            this.TelNum_ULabel.TabIndex = 1;
            this.TelNum_ULabel.Text = "電話番号";
            // 
            // Condition_TelNum_ULabel
            // 
            this.Condition_TelNum_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_TelNum_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_TelNum_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_TelNum_ULabel.Name = "Condition_TelNum_ULabel";
            this.Condition_TelNum_ULabel.Size = new System.Drawing.Size(241, 56);
            this.Condition_TelNum_ULabel.TabIndex = 0;
            // 
            // Condition_MngSectionCode_Panel
            // 
            this.Condition_MngSectionCode_Panel.Controls.Add(this.MngSectionCodeGuide_UButton);
            this.Condition_MngSectionCode_Panel.Controls.Add(this.tEdit_MngSectionNm);
            this.Condition_MngSectionCode_Panel.Controls.Add(this.ultraLabel2);
            this.Condition_MngSectionCode_Panel.Controls.Add(this.Condition_MngSectionCode_ULabel);
            this.Condition_MngSectionCode_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_MngSectionCode_Panel.Location = new System.Drawing.Point(0, 460);
            this.Condition_MngSectionCode_Panel.Name = "Condition_MngSectionCode_Panel";
            this.Condition_MngSectionCode_Panel.Size = new System.Drawing.Size(241, 56);
            this.Condition_MngSectionCode_Panel.TabIndex = 11;
            // 
            // MngSectionCodeGuide_UButton
            // 
            this.MngSectionCodeGuide_UButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MngSectionCodeGuide_UButton.Location = new System.Drawing.Point(200, 21);
            this.MngSectionCodeGuide_UButton.Name = "MngSectionCodeGuide_UButton";
            this.MngSectionCodeGuide_UButton.Size = new System.Drawing.Size(25, 24);
            this.MngSectionCodeGuide_UButton.TabIndex = 310;
            this.toolTip1.SetToolTip(this.MngSectionCodeGuide_UButton, "担当者ガイド");
            this.MngSectionCodeGuide_UButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.MngSectionCodeGuide_UButton.Click += new System.EventHandler(this.MngSectionCodeGuide_UButton_Click);
            // 
            // tEdit_MngSectionNm
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MngSectionNm.ActiveAppearance = appearance3;
            this.tEdit_MngSectionNm.AutoSelect = true;
            this.tEdit_MngSectionNm.AutoSize = false;
            this.tEdit_MngSectionNm.DataText = "";
            this.tEdit_MngSectionNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MngSectionNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MngSectionNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MngSectionNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_MngSectionNm.Location = new System.Drawing.Point(15, 22);
            this.tEdit_MngSectionNm.MaxLength = 9;
            this.tEdit_MngSectionNm.Name = "tEdit_MngSectionNm";
            this.tEdit_MngSectionNm.Size = new System.Drawing.Size(183, 22);
            this.tEdit_MngSectionNm.TabIndex = 309;
            // 
            // ultraLabel2
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance4;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(5, 1);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(213, 19);
            this.ultraLabel2.TabIndex = 1;
            this.ultraLabel2.Text = "管理拠点";
            // 
            // Condition_MngSectionCode_ULabel
            // 
            this.Condition_MngSectionCode_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_MngSectionCode_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_MngSectionCode_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_MngSectionCode_ULabel.Name = "Condition_MngSectionCode_ULabel";
            this.Condition_MngSectionCode_ULabel.Size = new System.Drawing.Size(241, 56);
            this.Condition_MngSectionCode_ULabel.TabIndex = 0;
            // 
            // Condition_CustomerAgentCd_Panel
            // 
            this.Condition_CustomerAgentCd_Panel.Controls.Add(this.CustomerAgentCdGuide_UButton);
            this.Condition_CustomerAgentCd_Panel.Controls.Add(this.tEdit_EmployeeNm);
            this.Condition_CustomerAgentCd_Panel.Controls.Add(this.CustomerAgentCdTitle_ULabel);
            this.Condition_CustomerAgentCd_Panel.Controls.Add(this.Condition_CustomerAgentCd_ULabel);
            this.Condition_CustomerAgentCd_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_CustomerAgentCd_Panel.Location = new System.Drawing.Point(0, 404);
            this.Condition_CustomerAgentCd_Panel.Name = "Condition_CustomerAgentCd_Panel";
            this.Condition_CustomerAgentCd_Panel.Size = new System.Drawing.Size(241, 56);
            this.Condition_CustomerAgentCd_Panel.TabIndex = 10;
            // 
            // CustomerAgentCdGuide_UButton
            // 
            this.CustomerAgentCdGuide_UButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerAgentCdGuide_UButton.Location = new System.Drawing.Point(200, 21);
            this.CustomerAgentCdGuide_UButton.Name = "CustomerAgentCdGuide_UButton";
            this.CustomerAgentCdGuide_UButton.Size = new System.Drawing.Size(25, 24);
            this.CustomerAgentCdGuide_UButton.TabIndex = 310;
            this.toolTip1.SetToolTip(this.CustomerAgentCdGuide_UButton, "担当者ガイド");
            this.CustomerAgentCdGuide_UButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerAgentCdGuide_UButton.Click += new System.EventHandler(this.CustomerAgentCdGuide_UButton_Click);
            // 
            // tEdit_EmployeeNm
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeNm.ActiveAppearance = appearance5;
            this.tEdit_EmployeeNm.AutoSelect = true;
            this.tEdit_EmployeeNm.AutoSize = false;
            this.tEdit_EmployeeNm.DataText = "";
            this.tEdit_EmployeeNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_EmployeeNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_EmployeeNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_EmployeeNm.Location = new System.Drawing.Point(15, 22);
            this.tEdit_EmployeeNm.MaxLength = 9;
            this.tEdit_EmployeeNm.Name = "tEdit_EmployeeNm";
            this.tEdit_EmployeeNm.Size = new System.Drawing.Size(183, 22);
            this.tEdit_EmployeeNm.TabIndex = 309;
            // 
            // CustomerAgentCdTitle_ULabel
            // 
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.CustomerAgentCdTitle_ULabel.Appearance = appearance6;
            this.CustomerAgentCdTitle_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerAgentCdTitle_ULabel.Location = new System.Drawing.Point(5, 1);
            this.CustomerAgentCdTitle_ULabel.Name = "CustomerAgentCdTitle_ULabel";
            this.CustomerAgentCdTitle_ULabel.Size = new System.Drawing.Size(213, 19);
            this.CustomerAgentCdTitle_ULabel.TabIndex = 1;
            this.CustomerAgentCdTitle_ULabel.Text = "得意先担当";
            // 
            // Condition_CustomerAgentCd_ULabel
            // 
            this.Condition_CustomerAgentCd_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_CustomerAgentCd_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_CustomerAgentCd_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_CustomerAgentCd_ULabel.Name = "Condition_CustomerAgentCd_ULabel";
            this.Condition_CustomerAgentCd_ULabel.Size = new System.Drawing.Size(241, 56);
            this.Condition_CustomerAgentCd_ULabel.TabIndex = 0;
            // 
            // Condition_CustAnalysCode_Panel
            // 
            this.Condition_CustAnalysCode_Panel.Controls.Add(this.CustAnalysCode5_TNedit);
            this.Condition_CustAnalysCode_Panel.Controls.Add(this.CustAnalysCode1_TNedit);
            this.Condition_CustAnalysCode_Panel.Controls.Add(this.CustAnalysCode3_TNedit);
            this.Condition_CustAnalysCode_Panel.Controls.Add(this.CustAnalysCode6_TNedit);
            this.Condition_CustAnalysCode_Panel.Controls.Add(this.CustAnalysCode4_TNedit);
            this.Condition_CustAnalysCode_Panel.Controls.Add(this.CustAnalysCode2_TNedit);
            this.Condition_CustAnalysCode_Panel.Controls.Add(this.CustAnalysCodeTitle_ULabel);
            this.Condition_CustAnalysCode_Panel.Controls.Add(this.Condition_CustAnalysCode_ULabel);
            this.Condition_CustAnalysCode_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_CustAnalysCode_Panel.Location = new System.Drawing.Point(0, 345);
            this.Condition_CustAnalysCode_Panel.Name = "Condition_CustAnalysCode_Panel";
            this.Condition_CustAnalysCode_Panel.Size = new System.Drawing.Size(241, 59);
            this.Condition_CustAnalysCode_Panel.TabIndex = 9;
            // 
            // CustAnalysCode5_TNedit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.TextHAlignAsString = "Right";
            this.CustAnalysCode5_TNedit.ActiveAppearance = appearance7;
            appearance8.TextHAlignAsString = "Right";
            this.CustAnalysCode5_TNedit.Appearance = appearance8;
            this.CustAnalysCode5_TNedit.AutoSelect = true;
            this.CustAnalysCode5_TNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustAnalysCode5_TNedit.DataText = "";
            this.CustAnalysCode5_TNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustAnalysCode5_TNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustAnalysCode5_TNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustAnalysCode5_TNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustAnalysCode5_TNedit.Location = new System.Drawing.Point(161, 28);
            this.CustAnalysCode5_TNedit.MaxLength = 3;
            this.CustAnalysCode5_TNedit.Name = "CustAnalysCode5_TNedit";
            this.CustAnalysCode5_TNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustAnalysCode5_TNedit.Size = new System.Drawing.Size(32, 22);
            this.CustAnalysCode5_TNedit.TabIndex = 415;
            // 
            // CustAnalysCode1_TNedit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.TextHAlignAsString = "Right";
            this.CustAnalysCode1_TNedit.ActiveAppearance = appearance9;
            appearance10.TextHAlignAsString = "Right";
            this.CustAnalysCode1_TNedit.Appearance = appearance10;
            this.CustAnalysCode1_TNedit.AutoSelect = true;
            this.CustAnalysCode1_TNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustAnalysCode1_TNedit.DataText = "";
            this.CustAnalysCode1_TNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustAnalysCode1_TNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustAnalysCode1_TNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustAnalysCode1_TNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustAnalysCode1_TNedit.Location = new System.Drawing.Point(15, 28);
            this.CustAnalysCode1_TNedit.MaxLength = 3;
            this.CustAnalysCode1_TNedit.Name = "CustAnalysCode1_TNedit";
            this.CustAnalysCode1_TNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustAnalysCode1_TNedit.Size = new System.Drawing.Size(32, 22);
            this.CustAnalysCode1_TNedit.TabIndex = 411;
            // 
            // CustAnalysCode3_TNedit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.TextHAlignAsString = "Right";
            this.CustAnalysCode3_TNedit.ActiveAppearance = appearance11;
            appearance12.TextHAlignAsString = "Right";
            this.CustAnalysCode3_TNedit.Appearance = appearance12;
            this.CustAnalysCode3_TNedit.AutoSelect = true;
            this.CustAnalysCode3_TNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustAnalysCode3_TNedit.DataText = "";
            this.CustAnalysCode3_TNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustAnalysCode3_TNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustAnalysCode3_TNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustAnalysCode3_TNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustAnalysCode3_TNedit.Location = new System.Drawing.Point(88, 28);
            this.CustAnalysCode3_TNedit.MaxLength = 3;
            this.CustAnalysCode3_TNedit.Name = "CustAnalysCode3_TNedit";
            this.CustAnalysCode3_TNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustAnalysCode3_TNedit.Size = new System.Drawing.Size(32, 22);
            this.CustAnalysCode3_TNedit.TabIndex = 413;
            // 
            // CustAnalysCode6_TNedit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.CustAnalysCode6_TNedit.ActiveAppearance = appearance13;
            appearance14.TextHAlignAsString = "Right";
            this.CustAnalysCode6_TNedit.Appearance = appearance14;
            this.CustAnalysCode6_TNedit.AutoSelect = true;
            this.CustAnalysCode6_TNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustAnalysCode6_TNedit.DataText = "";
            this.CustAnalysCode6_TNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustAnalysCode6_TNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustAnalysCode6_TNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustAnalysCode6_TNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustAnalysCode6_TNedit.Location = new System.Drawing.Point(198, 28);
            this.CustAnalysCode6_TNedit.MaxLength = 3;
            this.CustAnalysCode6_TNedit.Name = "CustAnalysCode6_TNedit";
            this.CustAnalysCode6_TNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustAnalysCode6_TNedit.Size = new System.Drawing.Size(32, 22);
            this.CustAnalysCode6_TNedit.TabIndex = 416;
            // 
            // CustAnalysCode4_TNedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Right";
            this.CustAnalysCode4_TNedit.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Right";
            this.CustAnalysCode4_TNedit.Appearance = appearance16;
            this.CustAnalysCode4_TNedit.AutoSelect = true;
            this.CustAnalysCode4_TNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustAnalysCode4_TNedit.DataText = "";
            this.CustAnalysCode4_TNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustAnalysCode4_TNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustAnalysCode4_TNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustAnalysCode4_TNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustAnalysCode4_TNedit.Location = new System.Drawing.Point(124, 28);
            this.CustAnalysCode4_TNedit.MaxLength = 3;
            this.CustAnalysCode4_TNedit.Name = "CustAnalysCode4_TNedit";
            this.CustAnalysCode4_TNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustAnalysCode4_TNedit.Size = new System.Drawing.Size(32, 22);
            this.CustAnalysCode4_TNedit.TabIndex = 414;
            // 
            // CustAnalysCode2_TNedit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance17.TextHAlignAsString = "Right";
            this.CustAnalysCode2_TNedit.ActiveAppearance = appearance17;
            appearance18.TextHAlignAsString = "Right";
            this.CustAnalysCode2_TNedit.Appearance = appearance18;
            this.CustAnalysCode2_TNedit.AutoSelect = true;
            this.CustAnalysCode2_TNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustAnalysCode2_TNedit.DataText = "";
            this.CustAnalysCode2_TNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustAnalysCode2_TNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustAnalysCode2_TNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustAnalysCode2_TNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustAnalysCode2_TNedit.Location = new System.Drawing.Point(52, 28);
            this.CustAnalysCode2_TNedit.MaxLength = 3;
            this.CustAnalysCode2_TNedit.Name = "CustAnalysCode2_TNedit";
            this.CustAnalysCode2_TNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustAnalysCode2_TNedit.Size = new System.Drawing.Size(32, 22);
            this.CustAnalysCode2_TNedit.TabIndex = 412;
            // 
            // CustAnalysCodeTitle_ULabel
            // 
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.CustAnalysCodeTitle_ULabel.Appearance = appearance19;
            this.CustAnalysCodeTitle_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustAnalysCodeTitle_ULabel.Location = new System.Drawing.Point(5, 2);
            this.CustAnalysCodeTitle_ULabel.Name = "CustAnalysCodeTitle_ULabel";
            this.CustAnalysCodeTitle_ULabel.Size = new System.Drawing.Size(213, 19);
            this.CustAnalysCodeTitle_ULabel.TabIndex = 1;
            this.CustAnalysCodeTitle_ULabel.Text = "分析コード";
            // 
            // Condition_CustAnalysCode_ULabel
            // 
            this.Condition_CustAnalysCode_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_CustAnalysCode_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_CustAnalysCode_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_CustAnalysCode_ULabel.Name = "Condition_CustAnalysCode_ULabel";
            this.Condition_CustAnalysCode_ULabel.Size = new System.Drawing.Size(241, 59);
            this.Condition_CustAnalysCode_ULabel.TabIndex = 0;
            // 
            // Condition_CustomerKind_Panel
            // 
            this.Condition_CustomerKind_Panel.Controls.Add(this.Receiver_UCheckEditor);
            this.Condition_CustomerKind_Panel.Controls.Add(this.Customer_UCheckEditor);
            this.Condition_CustomerKind_Panel.Controls.Add(this.CustomerKindTitle_ULabel);
            this.Condition_CustomerKind_Panel.Controls.Add(this.Condition_CustomerKind_ULabel);
            this.Condition_CustomerKind_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_CustomerKind_Panel.Location = new System.Drawing.Point(0, 298);
            this.Condition_CustomerKind_Panel.Name = "Condition_CustomerKind_Panel";
            this.Condition_CustomerKind_Panel.Size = new System.Drawing.Size(241, 47);
            this.Condition_CustomerKind_Panel.TabIndex = 8;
            // 
            // Receiver_UCheckEditor
            // 
            this.Receiver_UCheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.Receiver_UCheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.Receiver_UCheckEditor.Location = new System.Drawing.Point(90, 24);
            this.Receiver_UCheckEditor.Name = "Receiver_UCheckEditor";
            this.Receiver_UCheckEditor.Size = new System.Drawing.Size(69, 15);
            this.Receiver_UCheckEditor.TabIndex = 2;
            this.Receiver_UCheckEditor.Text = "納入先";
            this.Receiver_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
            this.Receiver_UCheckEditor.BeforeCheckStateChanged += new Infragistics.Win.CheckEditor.BeforeCheckStateChangedHandler(this.Customer_UCheckEditor_BeforeCheckStateChanged);
            // 
            // Customer_UCheckEditor
            // 
            this.Customer_UCheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.Customer_UCheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.Customer_UCheckEditor.Location = new System.Drawing.Point(15, 24);
            this.Customer_UCheckEditor.Name = "Customer_UCheckEditor";
            this.Customer_UCheckEditor.Size = new System.Drawing.Size(69, 15);
            this.Customer_UCheckEditor.TabIndex = 1;
            this.Customer_UCheckEditor.Text = "得意先";
            this.Customer_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerKind_AfterCheckStateChanged);
            this.Customer_UCheckEditor.BeforeCheckStateChanged += new Infragistics.Win.CheckEditor.BeforeCheckStateChangedHandler(this.Customer_UCheckEditor_BeforeCheckStateChanged);
            // 
            // CustomerKindTitle_ULabel
            // 
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.CustomerKindTitle_ULabel.Appearance = appearance20;
            this.CustomerKindTitle_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerKindTitle_ULabel.Location = new System.Drawing.Point(5, 2);
            this.CustomerKindTitle_ULabel.Name = "CustomerKindTitle_ULabel";
            this.CustomerKindTitle_ULabel.Size = new System.Drawing.Size(216, 19);
            this.CustomerKindTitle_ULabel.TabIndex = 1;
            this.CustomerKindTitle_ULabel.Text = "得意先種別";
            // 
            // Condition_CustomerKind_ULabel
            // 
            this.Condition_CustomerKind_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_CustomerKind_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_CustomerKind_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_CustomerKind_ULabel.Name = "Condition_CustomerKind_ULabel";
            this.Condition_CustomerKind_ULabel.Size = new System.Drawing.Size(241, 47);
            this.Condition_CustomerKind_ULabel.TabIndex = 0;
            // 
            // Condition_Header_Panel
            // 
            this.Condition_Header_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_Header_Panel.Location = new System.Drawing.Point(0, 295);
            this.Condition_Header_Panel.Name = "Condition_Header_Panel";
            this.Condition_Header_Panel.Size = new System.Drawing.Size(241, 3);
            this.Condition_Header_Panel.TabIndex = 18;
            // 
            // Condition_Name_Panel
            // 
            this.Condition_Name_Panel.Controls.Add(this.NameSearchType_UCheckEditor);
            this.Condition_Name_Panel.Controls.Add(this.tEdit_CustomerName);
            this.Condition_Name_Panel.Controls.Add(this.ConditionTitle_Name_ULabel);
            this.Condition_Name_Panel.Controls.Add(this.Condition_Name_ULabel);
            this.Condition_Name_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_Name_Panel.Location = new System.Drawing.Point(0, 236);
            this.Condition_Name_Panel.Name = "Condition_Name_Panel";
            this.Condition_Name_Panel.Size = new System.Drawing.Size(241, 59);
            this.Condition_Name_Panel.TabIndex = 2;
            // 
            // NameSearchType_UCheckEditor
            // 
            this.NameSearchType_UCheckEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NameSearchType_UCheckEditor.Location = new System.Drawing.Point(148, 1);
            this.NameSearchType_UCheckEditor.Name = "NameSearchType_UCheckEditor";
            this.NameSearchType_UCheckEditor.Size = new System.Drawing.Size(84, 20);
            this.NameSearchType_UCheckEditor.TabIndex = 1;
            this.NameSearchType_UCheckEditor.Text = "曖昧検索";
            this.NameSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.NameSearchType_UCheckEditor_AfterCheckStateChanged);
            // 
            // tEdit_CustomerName
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerName.ActiveAppearance = appearance56;
            appearance57.TextHAlignAsString = "Left";
            this.tEdit_CustomerName.Appearance = appearance57;
            this.tEdit_CustomerName.AutoSelect = true;
            this.tEdit_CustomerName.DataText = "";
            this.tEdit_CustomerName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_CustomerName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_CustomerName.Location = new System.Drawing.Point(15, 24);
            this.tEdit_CustomerName.MaxLength = 30;
            this.tEdit_CustomerName.Name = "tEdit_CustomerName";
            this.tEdit_CustomerName.Size = new System.Drawing.Size(217, 24);
            this.tEdit_CustomerName.TabIndex = 0;
            // 
            // ConditionTitle_Name_ULabel
            // 
            appearance58.TextHAlignAsString = "Left";
            appearance58.TextVAlignAsString = "Middle";
            this.ConditionTitle_Name_ULabel.Appearance = appearance58;
            this.ConditionTitle_Name_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConditionTitle_Name_ULabel.Location = new System.Drawing.Point(5, 2);
            this.ConditionTitle_Name_ULabel.Name = "ConditionTitle_Name_ULabel";
            this.ConditionTitle_Name_ULabel.Size = new System.Drawing.Size(123, 19);
            this.ConditionTitle_Name_ULabel.TabIndex = 1;
            this.ConditionTitle_Name_ULabel.Text = "得意先名";
            // 
            // Condition_Name_ULabel
            // 
            this.Condition_Name_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_Name_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_Name_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_Name_ULabel.Name = "Condition_Name_ULabel";
            this.Condition_Name_ULabel.Size = new System.Drawing.Size(241, 59);
            this.Condition_Name_ULabel.TabIndex = 0;
            // 
            // Condition_Kana_Panel
            // 
            this.Condition_Kana_Panel.Controls.Add(this.KanaSearchType_UCheckEditor);
            this.Condition_Kana_Panel.Controls.Add(this.tEdit_CustomerKana);
            this.Condition_Kana_Panel.Controls.Add(this.ConditionTitle_Kana_ULabel);
            this.Condition_Kana_Panel.Controls.Add(this.Condition_Kana_ULabel);
            this.Condition_Kana_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_Kana_Panel.Location = new System.Drawing.Point(0, 177);
            this.Condition_Kana_Panel.Name = "Condition_Kana_Panel";
            this.Condition_Kana_Panel.Size = new System.Drawing.Size(241, 59);
            this.Condition_Kana_Panel.TabIndex = 1;
            // 
            // KanaSearchType_UCheckEditor
            // 
            this.KanaSearchType_UCheckEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KanaSearchType_UCheckEditor.Location = new System.Drawing.Point(148, 1);
            this.KanaSearchType_UCheckEditor.Name = "KanaSearchType_UCheckEditor";
            this.KanaSearchType_UCheckEditor.Size = new System.Drawing.Size(84, 20);
            this.KanaSearchType_UCheckEditor.TabIndex = 1;
            this.KanaSearchType_UCheckEditor.Text = "曖昧検索";
            this.KanaSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.KanaSearchType_UCheckEditor_AfterCheckStateChanged);
            // 
            // tEdit_CustomerKana
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerKana.ActiveAppearance = appearance51;
            appearance52.TextHAlignAsString = "Left";
            this.tEdit_CustomerKana.Appearance = appearance52;
            this.tEdit_CustomerKana.AutoSelect = true;
            this.tEdit_CustomerKana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_CustomerKana.DataText = "";
            this.tEdit_CustomerKana.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerKana.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CustomerKana.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.tEdit_CustomerKana.Location = new System.Drawing.Point(15, 24);
            this.tEdit_CustomerKana.MaxLength = 20;
            this.tEdit_CustomerKana.Name = "tEdit_CustomerKana";
            this.tEdit_CustomerKana.Size = new System.Drawing.Size(217, 24);
            this.tEdit_CustomerKana.TabIndex = 0;
            // 
            // ConditionTitle_Kana_ULabel
            // 
            appearance53.TextHAlignAsString = "Left";
            appearance53.TextVAlignAsString = "Middle";
            this.ConditionTitle_Kana_ULabel.Appearance = appearance53;
            this.ConditionTitle_Kana_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConditionTitle_Kana_ULabel.Location = new System.Drawing.Point(5, 2);
            this.ConditionTitle_Kana_ULabel.Name = "ConditionTitle_Kana_ULabel";
            this.ConditionTitle_Kana_ULabel.Size = new System.Drawing.Size(123, 19);
            this.ConditionTitle_Kana_ULabel.TabIndex = 1;
            this.ConditionTitle_Kana_ULabel.Text = "得意先名(ｶﾅ)";
            // 
            // Condition_Kana_ULabel
            // 
            this.Condition_Kana_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_Kana_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_Kana_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_Kana_ULabel.Name = "Condition_Kana_ULabel";
            this.Condition_Kana_ULabel.Size = new System.Drawing.Size(241, 59);
            this.Condition_Kana_ULabel.TabIndex = 0;
            // 
            // Condition_CustomerCode_Panel
            // 
            this.Condition_CustomerCode_Panel.Controls.Add(this.tNedit_CustomerCode);
            this.Condition_CustomerCode_Panel.Controls.Add(this.ConditionTitle_CustomerCode_ULabel);
            this.Condition_CustomerCode_Panel.Controls.Add(this.Condition_CustomerCode_ULabel);
            this.Condition_CustomerCode_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_CustomerCode_Panel.Location = new System.Drawing.Point(0, 118);
            this.Condition_CustomerCode_Panel.Name = "Condition_CustomerCode_Panel";
            this.Condition_CustomerCode_Panel.Size = new System.Drawing.Size(241, 59);
            this.Condition_CustomerCode_Panel.TabIndex = 4;
            // 
            // tNedit_CustomerCode
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode.ActiveAppearance = appearance24;
            appearance25.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance25;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(15, 24);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(76, 24);
            this.tNedit_CustomerCode.TabIndex = 0;
            // 
            // ConditionTitle_CustomerCode_ULabel
            // 
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.ConditionTitle_CustomerCode_ULabel.Appearance = appearance26;
            this.ConditionTitle_CustomerCode_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConditionTitle_CustomerCode_ULabel.Location = new System.Drawing.Point(5, 1);
            this.ConditionTitle_CustomerCode_ULabel.Name = "ConditionTitle_CustomerCode_ULabel";
            this.ConditionTitle_CustomerCode_ULabel.Size = new System.Drawing.Size(213, 19);
            this.ConditionTitle_CustomerCode_ULabel.TabIndex = 1;
            this.ConditionTitle_CustomerCode_ULabel.Text = "得意先コード";
            // 
            // Condition_CustomerCode_ULabel
            // 
            this.Condition_CustomerCode_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_CustomerCode_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_CustomerCode_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_CustomerCode_ULabel.Name = "Condition_CustomerCode_ULabel";
            this.Condition_CustomerCode_ULabel.Size = new System.Drawing.Size(241, 59);
            this.Condition_CustomerCode_ULabel.TabIndex = 0;
            // 
            // Condition_SearchTelNo_Panel
            // 
            this.Condition_SearchTelNo_Panel.Controls.Add(this.SearchTelNo_TEdit);
            this.Condition_SearchTelNo_Panel.Controls.Add(this.ConditionTitle_SearchTelNo_ULabel);
            this.Condition_SearchTelNo_Panel.Controls.Add(this.Condition_SearchTelNo_ULabel);
            this.Condition_SearchTelNo_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_SearchTelNo_Panel.Location = new System.Drawing.Point(0, 59);
            this.Condition_SearchTelNo_Panel.Name = "Condition_SearchTelNo_Panel";
            this.Condition_SearchTelNo_Panel.Size = new System.Drawing.Size(241, 59);
            this.Condition_SearchTelNo_Panel.TabIndex = 6;
            // 
            // SearchTelNo_TEdit
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SearchTelNo_TEdit.ActiveAppearance = appearance27;
            appearance28.TextHAlignAsString = "Left";
            this.SearchTelNo_TEdit.Appearance = appearance28;
            this.SearchTelNo_TEdit.AutoSelect = true;
            this.SearchTelNo_TEdit.DataText = "";
            this.SearchTelNo_TEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SearchTelNo_TEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SearchTelNo_TEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SearchTelNo_TEdit.Location = new System.Drawing.Point(15, 23);
            this.SearchTelNo_TEdit.MaxLength = 16;
            this.SearchTelNo_TEdit.Name = "SearchTelNo_TEdit";
            this.SearchTelNo_TEdit.Size = new System.Drawing.Size(217, 24);
            this.SearchTelNo_TEdit.TabIndex = 0;
            // 
            // ConditionTitle_SearchTelNo_ULabel
            // 
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            this.ConditionTitle_SearchTelNo_ULabel.Appearance = appearance29;
            this.ConditionTitle_SearchTelNo_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConditionTitle_SearchTelNo_ULabel.Location = new System.Drawing.Point(5, 2);
            this.ConditionTitle_SearchTelNo_ULabel.Name = "ConditionTitle_SearchTelNo_ULabel";
            this.ConditionTitle_SearchTelNo_ULabel.Size = new System.Drawing.Size(216, 19);
            this.ConditionTitle_SearchTelNo_ULabel.TabIndex = 1;
            this.ConditionTitle_SearchTelNo_ULabel.Text = "電話番号（検索番号）";
            // 
            // Condition_SearchTelNo_ULabel
            // 
            this.Condition_SearchTelNo_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_SearchTelNo_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_SearchTelNo_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_SearchTelNo_ULabel.Name = "Condition_SearchTelNo_ULabel";
            this.Condition_SearchTelNo_ULabel.Size = new System.Drawing.Size(241, 59);
            this.Condition_SearchTelNo_ULabel.TabIndex = 0;
            // 
            // Condition_CustomerSubCode_Panel
            // 
            this.Condition_CustomerSubCode_Panel.Controls.Add(this.CustomerSubCodeSearchType_UCheckEditor);
            this.Condition_CustomerSubCode_Panel.Controls.Add(this.tEdit_CustomerSubCode);
            this.Condition_CustomerSubCode_Panel.Controls.Add(this.ConditionTitle_CustomerSubCode_ULabel);
            this.Condition_CustomerSubCode_Panel.Controls.Add(this.Condition_CustomerSubCode_ULabel);
            this.Condition_CustomerSubCode_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Condition_CustomerSubCode_Panel.Location = new System.Drawing.Point(0, 0);
            this.Condition_CustomerSubCode_Panel.Name = "Condition_CustomerSubCode_Panel";
            this.Condition_CustomerSubCode_Panel.Size = new System.Drawing.Size(241, 59);
            this.Condition_CustomerSubCode_Panel.TabIndex = 5;
            // 
            // CustomerSubCodeSearchType_UCheckEditor
            // 
            this.CustomerSubCodeSearchType_UCheckEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerSubCodeSearchType_UCheckEditor.Location = new System.Drawing.Point(148, 3);
            this.CustomerSubCodeSearchType_UCheckEditor.Name = "CustomerSubCodeSearchType_UCheckEditor";
            this.CustomerSubCodeSearchType_UCheckEditor.Size = new System.Drawing.Size(84, 20);
            this.CustomerSubCodeSearchType_UCheckEditor.TabIndex = 1;
            this.CustomerSubCodeSearchType_UCheckEditor.Text = "曖昧検索";
            this.CustomerSubCodeSearchType_UCheckEditor.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.CustomerSubCodeSearchType_UCheckEditor_AfterCheckStateChanged);
            // 
            // tEdit_CustomerSubCode
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerSubCode.ActiveAppearance = appearance30;
            appearance31.TextHAlignAsString = "Left";
            this.tEdit_CustomerSubCode.Appearance = appearance31;
            this.tEdit_CustomerSubCode.AutoSelect = true;
            this.tEdit_CustomerSubCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_CustomerSubCode.DataText = "";
            this.tEdit_CustomerSubCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerSubCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CustomerSubCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_CustomerSubCode.Location = new System.Drawing.Point(15, 26);
            this.tEdit_CustomerSubCode.MaxLength = 20;
            this.tEdit_CustomerSubCode.Name = "tEdit_CustomerSubCode";
            this.tEdit_CustomerSubCode.Size = new System.Drawing.Size(217, 24);
            this.tEdit_CustomerSubCode.TabIndex = 0;
            // 
            // ConditionTitle_CustomerSubCode_ULabel
            // 
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.ConditionTitle_CustomerSubCode_ULabel.Appearance = appearance32;
            this.ConditionTitle_CustomerSubCode_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConditionTitle_CustomerSubCode_ULabel.Location = new System.Drawing.Point(5, 3);
            this.ConditionTitle_CustomerSubCode_ULabel.Name = "ConditionTitle_CustomerSubCode_ULabel";
            this.ConditionTitle_CustomerSubCode_ULabel.Size = new System.Drawing.Size(137, 19);
            this.ConditionTitle_CustomerSubCode_ULabel.TabIndex = 1;
            this.ConditionTitle_CustomerSubCode_ULabel.Text = "得意先サブコード";
            // 
            // Condition_CustomerSubCode_ULabel
            // 
            this.Condition_CustomerSubCode_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Condition_CustomerSubCode_ULabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Condition_CustomerSubCode_ULabel.Location = new System.Drawing.Point(0, 0);
            this.Condition_CustomerSubCode_ULabel.Name = "Condition_CustomerSubCode_ULabel";
            this.Condition_CustomerSubCode_ULabel.Size = new System.Drawing.Size(241, 59);
            this.Condition_CustomerSubCode_ULabel.TabIndex = 0;
            // 
            // ConditionButton_FrameNo_Panel
            // 
            this.ConditionButton_FrameNo_Panel.BackColor = System.Drawing.Color.White;
            this.ConditionButton_FrameNo_Panel.Controls.Add(this.MultiSelect_UCheckEditor);
            this.ConditionButton_FrameNo_Panel.Controls.Add(this.AutoSearch_UCheckEditor);
            this.ConditionButton_FrameNo_Panel.Controls.Add(this.tLine1);
            this.ConditionButton_FrameNo_Panel.Controls.Add(this.Search_UButton);
            this.ConditionButton_FrameNo_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConditionButton_FrameNo_Panel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConditionButton_FrameNo_Panel.Location = new System.Drawing.Point(0, 489);
            this.ConditionButton_FrameNo_Panel.Name = "ConditionButton_FrameNo_Panel";
            this.ConditionButton_FrameNo_Panel.Size = new System.Drawing.Size(258, 41);
            this.ConditionButton_FrameNo_Panel.TabIndex = 24;
            // 
            // MultiSelect_UCheckEditor
            // 
            appearance33.ForeColor = System.Drawing.Color.Blue;
            this.MultiSelect_UCheckEditor.Appearance = appearance33;
            this.MultiSelect_UCheckEditor.Location = new System.Drawing.Point(6, 24);
            this.MultiSelect_UCheckEditor.Name = "MultiSelect_UCheckEditor";
            this.MultiSelect_UCheckEditor.Size = new System.Drawing.Size(84, 15);
            this.MultiSelect_UCheckEditor.TabIndex = 18;
            this.MultiSelect_UCheckEditor.Text = "複数選択";
            this.toolTip1.SetToolTip(this.MultiSelect_UCheckEditor, "複数の抽出条件で検索処理を実行します。");
            // 
            // AutoSearch_UCheckEditor
            // 
            appearance34.ForeColor = System.Drawing.Color.Blue;
            this.AutoSearch_UCheckEditor.Appearance = appearance34;
            this.AutoSearch_UCheckEditor.Checked = true;
            this.AutoSearch_UCheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoSearch_UCheckEditor.Location = new System.Drawing.Point(6, 7);
            this.AutoSearch_UCheckEditor.Name = "AutoSearch_UCheckEditor";
            this.AutoSearch_UCheckEditor.Size = new System.Drawing.Size(84, 15);
            this.AutoSearch_UCheckEditor.TabIndex = 17;
            this.AutoSearch_UCheckEditor.Text = "自動検索";
            this.toolTip1.SetToolTip(this.AutoSearch_UCheckEditor, "抽出条件が変更される度に、検索処理を実行します。");
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tLine1.Location = new System.Drawing.Point(0, 3);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(267, 8);
            this.tLine1.TabIndex = 16;
            this.tLine1.Text = "tLine1";
            // 
            // Search_UButton
            // 
            this.Search_UButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_UButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Search_UButton.Location = new System.Drawing.Point(165, 9);
            this.Search_UButton.Name = "Search_UButton";
            this.Search_UButton.Size = new System.Drawing.Size(88, 27);
            this.Search_UButton.TabIndex = 15;
            this.Search_UButton.Text = "検索(&R)";
            this.Search_UButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Search_UButton.Click += new System.EventHandler(this.Search_UButton_Click);
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ExtractConditionSetting_UTree);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ExtractConditionSettingHint_Panel);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(258, 530);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            this.ultraExplorerBarContainerControl1.Visible = false;
            // 
            // ExtractConditionSetting_UTree
            // 
            this.ExtractConditionSetting_UTree.AllowDrop = true;
            this.ExtractConditionSetting_UTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtractConditionSetting_UTree.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExtractConditionSetting_UTree.HideSelection = false;
            this.ExtractConditionSetting_UTree.Location = new System.Drawing.Point(0, 0);
            this.ExtractConditionSetting_UTree.Name = "ExtractConditionSetting_UTree";
            appearance35.Cursor = System.Windows.Forms.Cursors.Hand;
            _override1.NodeAppearance = appearance35;
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            this.ExtractConditionSetting_UTree.Override = _override1;
            this.ExtractConditionSetting_UTree.Size = new System.Drawing.Size(258, 506);
            this.ExtractConditionSetting_UTree.TabIndex = 0;
            this.ExtractConditionSetting_UTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExtractConditionSetting_UTree_MouseClick);
            this.ExtractConditionSetting_UTree.SelectionDragStart += new System.EventHandler(this.ExtractConditionSetting_UTree_SelectionDragStart);
            this.ExtractConditionSetting_UTree.DragLeave += new System.EventHandler(this.ExtractConditionSetting_UTree_DragLeave);
            this.ExtractConditionSetting_UTree.BeforeCheck += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.ExtractConditionSetting_UTree_BeforeCheck);
            this.ExtractConditionSetting_UTree.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.ExtractConditionSetting_UTree_QueryContinueDrag);
            this.ExtractConditionSetting_UTree.DragOver += new System.Windows.Forms.DragEventHandler(this.ExtractConditionSetting_UTree_DragOver);
            this.ExtractConditionSetting_UTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExtractConditionSetting_UTree_DragDrop);
            this.ExtractConditionSetting_UTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.ExtractConditionSetting_UTree_AfterCheck);
            // 
            // ExtractConditionSettingHint_Panel
            // 
            this.ExtractConditionSettingHint_Panel.BackColor = System.Drawing.Color.White;
            this.ExtractConditionSettingHint_Panel.Controls.Add(this.ExtractConditionSettingHint_Label);
            this.ExtractConditionSettingHint_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExtractConditionSettingHint_Panel.Location = new System.Drawing.Point(0, 506);
            this.ExtractConditionSettingHint_Panel.Name = "ExtractConditionSettingHint_Panel";
            this.ExtractConditionSettingHint_Panel.Size = new System.Drawing.Size(258, 24);
            this.ExtractConditionSettingHint_Panel.TabIndex = 1;
            // 
            // ExtractConditionSettingHint_Label
            // 
            this.ExtractConditionSettingHint_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExtractConditionSettingHint_Label.Location = new System.Drawing.Point(3, 6);
            this.ExtractConditionSettingHint_Label.Name = "ExtractConditionSettingHint_Label";
            this.ExtractConditionSettingHint_Label.Size = new System.Drawing.Size(252, 14);
            this.ExtractConditionSettingHint_Label.TabIndex = 0;
            this.ExtractConditionSettingHint_Label.Text = "ドラッグ＆ドロップで順位を変更できます。";
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.Controls.Add(this.DetailView_Splitter);
            this.Form1_Fill_Panel.Controls.Add(this.DetailView_Panel);
            this.Form1_Fill_Panel.Controls.Add(this.ExtractResult_Panel);
            this.Form1_Fill_Panel.Controls.Add(this.Center_Splitter);
            this.Form1_Fill_Panel.Controls.Add(this.Main_ExplorerBar);
            this.Form1_Fill_Panel.Controls.Add(this.Main_StatusBar);
            this.Form1_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Form1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1_Fill_Panel.Location = new System.Drawing.Point(0, 63);
            this.Form1_Fill_Panel.Name = "Form1_Fill_Panel";
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(1016, 671);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // DetailView_Splitter
            // 
            this.DetailView_Splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
            this.DetailView_Splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.DetailView_Splitter.Location = new System.Drawing.Point(265, 352);
            this.DetailView_Splitter.Name = "DetailView_Splitter";
            this.DetailView_Splitter.Size = new System.Drawing.Size(751, 3);
            this.DetailView_Splitter.TabIndex = 138;
            this.DetailView_Splitter.TabStop = false;
            // 
            // DetailView_Panel
            // 
            this.DetailView_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
            this.DetailView_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailView_Panel.Location = new System.Drawing.Point(265, 352);
            this.DetailView_Panel.Name = "DetailView_Panel";
            this.DetailView_Panel.Size = new System.Drawing.Size(751, 296);
            this.DetailView_Panel.TabIndex = 137;
            // 
            // ExtractResult_Panel
            // 
            this.ExtractResult_Panel.Controls.Add(this.SearchResult_UGrid);
            this.ExtractResult_Panel.Controls.Add(this.panel3);
            this.ExtractResult_Panel.Controls.Add(this.ExtractResult_UStatusBar);
            this.ExtractResult_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExtractResult_Panel.Location = new System.Drawing.Point(265, 0);
            this.ExtractResult_Panel.Name = "ExtractResult_Panel";
            this.ExtractResult_Panel.Size = new System.Drawing.Size(751, 352);
            this.ExtractResult_Panel.TabIndex = 136;
            // 
            // SearchResult_UGrid
            // 
            appearance36.BackColor = System.Drawing.Color.White;
            appearance36.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.SearchResult_UGrid.DisplayLayout.Appearance = appearance36;
            this.SearchResult_UGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.SearchResult_UGrid.DisplayLayout.InterBandSpacing = 10;
            this.SearchResult_UGrid.DisplayLayout.MaxColScrollRegions = 1;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.SearchResult_UGrid.DisplayLayout.Override.ActiveCellAppearance = appearance37;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinBand;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.SearchResult_UGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance38.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance38.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance38.ForeColor = System.Drawing.Color.White;
            appearance38.TextHAlignAsString = "Center";
            appearance38.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance = appearance38;
            this.SearchResult_UGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance39.BackColor = System.Drawing.Color.Lavender;
            this.SearchResult_UGrid.DisplayLayout.Override.RowAlternateAppearance = appearance39;
            appearance40.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance40.TextVAlignAsString = "Middle";
            this.SearchResult_UGrid.DisplayLayout.Override.RowAppearance = appearance40;
            this.SearchResult_UGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.SearchResult_UGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance41.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance41.ForeColor = System.Drawing.Color.White;
            this.SearchResult_UGrid.DisplayLayout.Override.RowSelectorAppearance = appearance41;
            this.SearchResult_UGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.SearchResult_UGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.SearchResult_UGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance42.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance42.ForeColor = System.Drawing.Color.Black;
            this.SearchResult_UGrid.DisplayLayout.Override.SelectedRowAppearance = appearance42;
            this.SearchResult_UGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.SearchResult_UGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.SearchResult_UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.SearchResult_UGrid.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.SearchResult_UGrid.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.SearchResult_UGrid.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.SearchResult_UGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.SearchResult_UGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.SearchResult_UGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.SearchResult_UGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.SearchResult_UGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchResult_UGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchResult_UGrid.Location = new System.Drawing.Point(0, 28);
            this.SearchResult_UGrid.Name = "SearchResult_UGrid";
            this.SearchResult_UGrid.Size = new System.Drawing.Size(751, 301);
            this.SearchResult_UGrid.TabIndex = 2;
            this.SearchResult_UGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchResult_UGrid_KeyUp);
            this.SearchResult_UGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SearchResult_UGrid_MouseUp);
            this.SearchResult_UGrid.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.SearchResult_UGrid_MouseLeaveElement);
            this.SearchResult_UGrid.Enter += new System.EventHandler(this.SearchResult_UGrid_Enter);
            this.SearchResult_UGrid.AfterRowActivate += new System.EventHandler(this.SearchResult_UGrid_AfterRowActivate);
            this.SearchResult_UGrid.DoubleClick += new System.EventHandler(this.SearchResult_UGrid_DoubleClick);
            this.SearchResult_UGrid.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.SearchResult_UGrid_MouseEnterElement);
            this.SearchResult_UGrid.Leave += new System.EventHandler(this.SearchResult_UGrid_Leave);
            this.SearchResult_UGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchResult_UGrid_KeyDown);
            this.SearchResult_UGrid.AfterCellActivate += new System.EventHandler(this.SearchResult_UGrid_AfterCellActivate);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.panel3.Controls.Add(this.SearchResultHeader_ULabel);
            this.panel3.Controls.Add(this.ultraLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(751, 28);
            this.panel3.TabIndex = 0;
            // 
            // SearchResultHeader_ULabel
            // 
            this.SearchResultHeader_ULabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance43.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance43.ForeColor = System.Drawing.Color.White;
            appearance43.TextHAlignAsString = "Left";
            appearance43.TextVAlignAsString = "Middle";
            this.SearchResultHeader_ULabel.Appearance = appearance43;
            this.SearchResultHeader_ULabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.SearchResultHeader_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchResultHeader_ULabel.Location = new System.Drawing.Point(1, 1);
            this.SearchResultHeader_ULabel.Name = "SearchResultHeader_ULabel";
            this.SearchResultHeader_ULabel.Size = new System.Drawing.Size(749, 27);
            this.SearchResultHeader_ULabel.TabIndex = 1;
            this.SearchResultHeader_ULabel.Text = "抽出結果";
            // 
            // ultraLabel1
            // 
            appearance44.TextHAlignAsString = "Left";
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance44;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Black;
            this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(751, 28);
            this.ultraLabel1.TabIndex = 2;
            // 
            // ExtractResult_UStatusBar
            // 
            this.ExtractResult_UStatusBar.Controls.Add(this.GridFontSize_TComboEditor);
            this.ExtractResult_UStatusBar.Controls.Add(this.DeleteIndication_CheckEditor);
            this.ExtractResult_UStatusBar.Location = new System.Drawing.Point(0, 329);
            this.ExtractResult_UStatusBar.Name = "ExtractResult_UStatusBar";
            this.ExtractResult_UStatusBar.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(0, 1, 0, 0);
            appearance45.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance45;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel1.Text = "文字サイズ";
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Control = this.GridFontSize_TComboEditor;
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel2.Width = 40;
            ultraStatusPanel3.Control = this.DeleteIndication_CheckEditor;
            ultraStatusPanel3.Key = "DeleteIndication_StatusPanel";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel3.Width = 150;
            this.ExtractResult_UStatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.ExtractResult_UStatusBar.Size = new System.Drawing.Size(751, 23);
            this.ExtractResult_UStatusBar.TabIndex = 15;
            this.ExtractResult_UStatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Center_Splitter
            // 
            this.Center_Splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
            this.Center_Splitter.Location = new System.Drawing.Point(260, 0);
            this.Center_Splitter.Name = "Center_Splitter";
            this.Center_Splitter.Size = new System.Drawing.Size(5, 648);
            this.Center_Splitter.TabIndex = 135;
            this.Center_Splitter.TabStop = false;
            // 
            // Main_ExplorerBar
            // 
            appearance46.FontData.BoldAsString = "False";
            this.Main_ExplorerBar.Appearance = appearance46;
            this.Main_ExplorerBar.Controls.Add(this.Condition_UExplorerBarContainerControl);
            this.Main_ExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ExplorerBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Main_ExplorerBar.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ultraExplorerBarGroup1.Container = this.Condition_UExplorerBarContainerControl;
            ultraExplorerBarGroup1.Key = "ExtractCondition";
            ultraExplorerBarGroup1.Text = "抽出条件";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup2.Key = "ExtractConditionSetting";
            ultraExplorerBarGroup2.Text = "抽出条件設定";
            this.Main_ExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2});
            this.Main_ExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ExplorerBar.Location = new System.Drawing.Point(0, 0);
            this.Main_ExplorerBar.Name = "Main_ExplorerBar";
            this.Main_ExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ExplorerBar.Size = new System.Drawing.Size(260, 648);
            this.Main_ExplorerBar.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.OutlookNavigationPane;
            this.Main_ExplorerBar.TabIndex = 134;
            this.Main_ExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ExplorerBar.ActiveGroupChanged += new Infragistics.Win.UltraWinExplorerBar.ActiveGroupChangedEventHandler(this.Main_ExplorerBar_ActiveGroupChanged);
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 648);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance47.FontData.SizeInPoints = 9F;
            ultraStatusPanel4.Appearance = appearance47;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Key = "StatusBarPanel_Text";
            ultraStatusPanel4.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel5.Key = "StatusBarPanel_Progress";
            appearance48.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel5.ProgressBarInfo.FillAppearance = appearance48;
            ultraStatusPanel5.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel5.Width = 150;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel6.Key = "StatusBarPanel_Date";
            ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel6.Width = 90;
            ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel7.Key = "StatusBarPanel_Time";
            ultraStatusPanel7.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel7.Width = 50;
            this.Main_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6,
            ultraStatusPanel7});
            this.Main_StatusBar.Size = new System.Drawing.Size(1016, 23);
            this.Main_StatusBar.TabIndex = 14;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // _SFMIT01600UA_Toolbars_Dock_Area_Left
            // 
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.Name = "_SFMIT01600UA_Toolbars_Dock_Area_Left";
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 671);
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this.Form1_Fill_Panel;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.Main_ToolbarsManager.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.False;
            popupMenuTool4.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool4.InstanceProps.IsFirstInGroup = true;
            buttonTool12.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool4,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12});
            popupMenuTool5.SharedProps.Caption = "ツール(&T)";
            popupMenuTool5.SharedProps.MergeOrder = 3;
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool13});
            popupMenuTool6.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool6.SharedProps.MergeOrder = 4;
            popupMenuTool7.InstanceProps.IsFirstInGroup = true;
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool7});
            labelTool5.SharedProps.MergeOrder = 80;
            labelTool5.SharedProps.Spring = true;
            labelTool6.SharedProps.Caption = "ログイン担当者";
            labelTool6.SharedProps.MergeOrder = 98;
            labelTool6.SharedProps.ShowInCustomizer = false;
            appearance49.BackColor = System.Drawing.Color.White;
            appearance49.TextHAlignAsString = "Left";
            labelTool7.SharedProps.AppearancesSmall.Appearance = appearance49;
            labelTool7.SharedProps.Caption = "翼　太郎";
            labelTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool7.SharedProps.MergeOrder = 99;
            labelTool7.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Width = 150;
            buttonTool14.SharedProps.Caption = "閉じる(&X)";
            buttonTool14.SharedProps.CustomizerCaption = "閉じるボタン";
            buttonTool14.SharedProps.CustomizerDescription = "閉じるボタン";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.MergeOrder = 1;
            buttonTool14.SharedProps.ToolTipText = "得意先画面を閉じます。";
            buttonTool15.SharedProps.Caption = "削除(&D)";
            buttonTool15.SharedProps.CustomizerCaption = "削除ボタン";
            buttonTool15.SharedProps.CustomizerDescription = "削除ボタン";
            buttonTool15.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool15.SharedProps.MergeOrder = 6;
            buttonTool15.SharedProps.ToolTipText = "選択中の得意先を削除します。";
            buttonTool16.SharedProps.Caption = "設定(&O)";
            buttonTool16.SharedProps.CustomizerCaption = "設定ボタン";
            buttonTool16.SharedProps.CustomizerDescription = "設定ボタン";
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool16.SharedProps.MergeOrder = 50;
            buttonTool16.SharedProps.ToolTipText = "ユーザー設定画面を表示します。";
            buttonTool17.SharedProps.Caption = "新規(&N)";
            buttonTool17.SharedProps.CustomizerCaption = "新規ボタン";
            buttonTool17.SharedProps.CustomizerDescription = "新規ボタン";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool17.SharedProps.MergeOrder = 4;
            buttonTool17.SharedProps.ToolTipText = "新規に得意先情報を入力します。";
            popupMenuTool8.SharedProps.Caption = "編集(&E)";
            popupMenuTool8.SharedProps.CustomizerCaption = "編集";
            popupMenuTool8.SharedProps.CustomizerDescription = "編集";
            popupMenuTool8.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool18,
            buttonTool19});
            buttonTool20.SharedProps.Caption = "編集(&E)";
            buttonTool20.SharedProps.CustomizerCaption = "編集ボタン";
            buttonTool20.SharedProps.CustomizerDescription = "編集ボタン";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.MergeOrder = 5;
            buttonTool20.SharedProps.ToolTipText = "選択中の得意先を編集します。";
            labelTool8.SharedProps.Caption = "【得意先】";
            labelTool8.SharedProps.CustomizerCaption = "得意先";
            labelTool8.SharedProps.CustomizerDescription = "得意先";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool8.SharedProps.MergeOrder = 3;
            buttonTool21.SharedProps.Caption = "復元";
            buttonTool21.SharedProps.CustomizerCaption = "得意先復元ボタン";
            buttonTool21.SharedProps.CustomizerDescription = "得意先復元ボタン";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool21.SharedProps.MergeOrder = 8;
            buttonTool21.SharedProps.ToolTipText = "選択中の削除済み得意先情報を復元します。";
            popupMenuTool9.SharedProps.Caption = "詳細表示";
            popupMenuTool9.SharedProps.CustomizerCaption = "詳細表示";
            popupMenuTool9.SharedProps.CustomizerDescription = "詳細表示";
            popupMenuTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool9.SharedProps.MergeOrder = 18;
            popupMenuTool9.SharedProps.ToolTipText = "得意先・車両の詳細を表示します。";
            popupMenuTool9.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool22,
            buttonTool23,
            buttonTool24});
            buttonTool25.SharedProps.Caption = "抽出結果ウィンドウ内で表示する";
            buttonTool25.SharedProps.CustomizerCaption = "抽出結果ウィンドウ内で表示する";
            buttonTool25.SharedProps.CustomizerDescription = "抽出結果ウィンドウ内で表示する";
            buttonTool25.SharedProps.ToolTipText = "詳細情報を抽出結果ウィンドウ内で表示します。";
            buttonTool26.SharedProps.Caption = "別ウィンドウで表示する";
            buttonTool26.SharedProps.CustomizerCaption = "別ウィンドウで表示する";
            buttonTool26.SharedProps.CustomizerDescription = "別ウィンドウで表示する";
            buttonTool26.SharedProps.ToolTipText = "詳細情報を別ウィンドウで表示します。";
            buttonTool27.SharedProps.Caption = "表示しない";
            buttonTool27.SharedProps.CustomizerCaption = "表示しない";
            buttonTool27.SharedProps.CustomizerDescription = "表示しない";
            buttonTool27.SharedProps.ToolTipText = "詳細情報を表示しません。";
            popupMenuTool10.SharedProps.Caption = "ガイド(&G)";
            popupMenuTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool10.SharedProps.MergeOrder = 2;
            popupMenuTool10.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool9});
            buttonTool28.SharedProps.Caption = "戻る(&B)";
            buttonTool28.SharedProps.CustomizerCaption = "戻るボタン";
            buttonTool28.SharedProps.CustomizerDescription = "戻るボタン";
            buttonTool28.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool28.SharedProps.ToolTipText = "一つ前の抽出条件に戻します。";
            buttonTool29.SharedProps.Caption = "選択(&S)";
            buttonTool29.SharedProps.CustomizerCaption = "選択ボタン";
            buttonTool29.SharedProps.CustomizerDescription = "選択ボタン";
            buttonTool29.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool29.SharedProps.ToolTipText = "グリッドにて選択中の得意先情報を呼び元に渡します。";
            buttonTool30.SharedProps.Caption = "取消(&C)";
            buttonTool30.SharedProps.CustomizerCaption = "取消ボタン";
            buttonTool30.SharedProps.CustomizerDescription = "取消ボタン";
            buttonTool30.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool30.SharedProps.ToolTipText = "画面を初期化します。";
            buttonTool31.SharedProps.Caption = "検索(&R)";
            buttonTool31.SharedProps.CustomizerCaption = "検索ボタン";
            buttonTool31.SharedProps.CustomizerDescription = "検索ボタン";
            buttonTool31.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool31.SharedProps.ToolTipText = "得意先情報を検索します。";
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            labelTool5,
            labelTool6,
            labelTool7,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            popupMenuTool8,
            buttonTool20,
            labelTool8,
            buttonTool21,
            popupMenuTool9,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            popupMenuTool10,
            buttonTool28,
            buttonTool29,
            buttonTool30,
            buttonTool31});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _SFMIT01600UA_Toolbars_Dock_Area_Right
            // 
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Name = "_SFMIT01600UA_Toolbars_Dock_Area_Right";
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 671);
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _Form1_Fill_Panel_Toolbars_Dock_Area_Bottom
            // 
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 0);
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.Name = "_Form1_Fill_Panel_Toolbars_Dock_Area_Bottom";
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(0, 0);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Search_DataSet
            // 
            this.Search_DataSet.DataSetName = "NewDataSet";
            this.Search_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Search_Timer
            // 
            this.Search_Timer.Interval = 1;
            // 
            // ColSizeChange_Timer
            // 
            this.ColSizeChange_Timer.Interval = 1;
            this.ColSizeChange_Timer.Tick += new System.EventHandler(this.ColSizeChange_Timer_Tick);
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
            // DetailView_Timer
            // 
            this.DetailView_Timer.Interval = 1;
            this.DetailView_Timer.Tick += new System.EventHandler(this.DetailView_Timer_Tick);
            // 
            // MessageUnDisp_Timer
            // 
            this.MessageUnDisp_Timer.Interval = 5000;
            this.MessageUnDisp_Timer.Tick += new System.EventHandler(this.MessageUnDisp_Timer_Tick);
            // 
            // uToolTipManager_Information
            // 
            this.uToolTipManager_Information.AutoPopDelay = 20000;
            this.uToolTipManager_Information.ContainingControl = this;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // _PMKHN04001UA_Toolbars_Dock_Area_Right
            // 
            this._PMKHN04001UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN04001UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN04001UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN04001UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN04001UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._PMKHN04001UA_Toolbars_Dock_Area_Right.Name = "_PMKHN04001UA_Toolbars_Dock_Area_Right";
            this._PMKHN04001UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 671);
            this._PMKHN04001UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN04001UA_Toolbars_Dock_Area_Left
            // 
            this._PMKHN04001UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN04001UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN04001UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN04001UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN04001UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._PMKHN04001UA_Toolbars_Dock_Area_Left.Name = "_PMKHN04001UA_Toolbars_Dock_Area_Left";
            this._PMKHN04001UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 671);
            this._PMKHN04001UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN04001UA_Toolbars_Dock_Area_Top
            // 
            this._PMKHN04001UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN04001UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN04001UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN04001UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN04001UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN04001UA_Toolbars_Dock_Area_Top.Name = "_PMKHN04001UA_Toolbars_Dock_Area_Top";
            this._PMKHN04001UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
            this._PMKHN04001UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN04001UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 734);
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom.Name = "_PMKHN04001UA_Toolbars_Dock_Area_Bottom";
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN04001UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMKHN04001UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.Form1_Fill_Panel);
            this.Controls.Add(this._PMKHN04001UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT01600UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT01600UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN04001UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN04001UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN04001UA_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "PMKHN04001UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先検索";
            this.Load += new System.EventHandler(this.PMKHN04001UA_Load);
            this.Shown += new System.EventHandler(this.PMKHN04001UA_Shown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN04001UA_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKHN04001UA_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PMKHN04001UA_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridFontSize_TComboEditor)).EndInit();
            this.Condition_UExplorerBarContainerControl.ResumeLayout(false);
            this.Condition_Panel.ResumeLayout(false);
            this.Condition_CustomerSnm_Panel.ResumeLayout(false);
            this.Condition_CustomerSnm_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSnm)).EndInit();
            this.Condition_TelNum_Panel.ResumeLayout(false);
            this.Condition_TelNum_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_TelNum)).EndInit();
            this.Condition_MngSectionCode_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MngSectionNm)).EndInit();
            this.Condition_CustomerAgentCd_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeNm)).EndInit();
            this.Condition_CustAnalysCode_Panel.ResumeLayout(false);
            this.Condition_CustAnalysCode_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode5_TNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode1_TNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode3_TNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode6_TNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode4_TNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustAnalysCode2_TNedit)).EndInit();
            this.Condition_CustomerKind_Panel.ResumeLayout(false);
            this.Condition_Name_Panel.ResumeLayout(false);
            this.Condition_Name_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerName)).EndInit();
            this.Condition_Kana_Panel.ResumeLayout(false);
            this.Condition_Kana_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerKana)).EndInit();
            this.Condition_CustomerCode_Panel.ResumeLayout(false);
            this.Condition_CustomerCode_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            this.Condition_SearchTelNo_Panel.ResumeLayout(false);
            this.Condition_SearchTelNo_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchTelNo_TEdit)).EndInit();
            this.Condition_CustomerSubCode_Panel.ResumeLayout(false);
            this.Condition_CustomerSubCode_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSubCode)).EndInit();
            this.ConditionButton_FrameNo_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExtractConditionSetting_UTree)).EndInit();
            this.ExtractConditionSettingHint_Panel.ResumeLayout(false);
            this.Form1_Fill_Panel.ResumeLayout(false);
            this.ExtractResult_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchResult_UGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ExtractResult_UStatusBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ExplorerBar)).EndInit();
            this.Main_ExplorerBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_DataSet)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.Panel Condition_CustomerKind_Panel;
		private Infragistics.Win.Misc.UltraLabel CustomerKindTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel Condition_CustomerKind_ULabel;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor Customer_UCheckEditor;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor MultiSelect_UCheckEditor;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uToolTipManager_Information;
		private System.Windows.Forms.Panel ExtractConditionSettingHint_Panel;
		private Infragistics.Win.Misc.UltraLabel ExtractConditionSettingHint_Label;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor KanaSearchType_UCheckEditor;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor CustomerSubCodeSearchType_UCheckEditor;
		private System.Windows.Forms.Panel Condition_CustAnalysCode_Panel;
		private Infragistics.Win.Misc.UltraLabel CustAnalysCodeTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel Condition_CustAnalysCode_ULabel;
		private Broadleaf.Library.Windows.Forms.TNedit CustAnalysCode5_TNedit;
		private Broadleaf.Library.Windows.Forms.TNedit CustAnalysCode1_TNedit;
		private Broadleaf.Library.Windows.Forms.TNedit CustAnalysCode3_TNedit;
		private Broadleaf.Library.Windows.Forms.TNedit CustAnalysCode6_TNedit;
		private Broadleaf.Library.Windows.Forms.TNedit CustAnalysCode4_TNedit;
		private Broadleaf.Library.Windows.Forms.TNedit CustAnalysCode2_TNedit;
		private System.Windows.Forms.Panel Condition_CustomerAgentCd_Panel;
		private Infragistics.Win.Misc.UltraLabel CustomerAgentCdTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel Condition_CustomerAgentCd_ULabel;
		private Infragistics.Win.Misc.UltraButton CustomerAgentCdGuide_UButton;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_EmployeeNm;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor Receiver_UCheckEditor;
        private System.Windows.Forms.Panel Condition_MngSectionCode_Panel;
        private Infragistics.Win.Misc.UltraButton MngSectionCodeGuide_UButton;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_MngSectionNm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel Condition_MngSectionCode_ULabel;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor DeleteIndication_CheckEditor;
        private System.Windows.Forms.Panel Condition_Name_Panel;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor NameSearchType_UCheckEditor;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerName;
        private Infragistics.Win.Misc.UltraLabel ConditionTitle_Name_ULabel;
        private Infragistics.Win.Misc.UltraLabel Condition_Name_ULabel;
        private System.Windows.Forms.Panel Condition_TelNum_Panel;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_TelNum;
        private Infragistics.Win.Misc.UltraLabel TelNum_ULabel;
        private Infragistics.Win.Misc.UltraLabel Condition_TelNum_ULabel;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor TelNum_UCheckEditor;
        private System.Windows.Forms.Panel Condition_CustomerSnm_Panel;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor SnmSearchType_UCheckEditor;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerSnm;
        private Infragistics.Win.Misc.UltraLabel ConditionTitle_Snm_ULabel;
        private Infragistics.Win.Misc.UltraLabel Condition_Snm_ULabel;
	}
}
