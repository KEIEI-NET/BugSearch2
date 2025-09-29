//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先実績修正
// プログラム概要   ：得意先実績修正の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：21024 佐々木 健
// 修正日    2009/01/06     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/06     修正内容：Mantis【13144】起動後の得意先追加時エラー対応
// ---------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Reflection;

using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;


namespace  Broadleaf.Windows.Forms
{
	/// **********************************************************************
	/// public class name:	MAKAU09110UA
	///						MAKAU09110U.DLL                                    
	/// <summary>
	///						得意先実績修正画面
	/// </summary>
	/// ----------------------------------------------------------------------
	/// <remarks> 
	/// <br>note         :	得意先の売掛・請求の実績修正を行います。</br>
	/// <br>note         :	※ マスタメンテメインSFCMN09000UEを流用しました。</br>
    /// <br>Programmer   : 30154 安藤　昌仁</br>
    /// <br>Date         : 2007.04.18</br>
    /// <br></br>
    /// <br>note         :	流通.NS用に変更</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.09.27</br>
    /// <br></br>
    /// <br>Note         : PM.NS用に変更</br>
    /// <br>Programmer   : 21024 佐々木 健</br>
    /// <br>Date         : 2009.01.06</br>    
    /// </remarks>
	/// **********************************************************************
	public class MAKAU09110UA : System.Windows.Forms.Form
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel ViewButtonPanel;
		private Infragistics.Win.Misc.UltraButton Details_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton New_Button;
		private Infragistics.Win.Misc.UltraButton Modify_Button;
		private Infragistics.Win.Misc.UltraButton Close_Button;
		private System.Windows.Forms.Panel Customer_Panel;
		private Infragistics.Win.Misc.UltraLabel CustomerName2_Label;
		private Infragistics.Win.Misc.UltraButton Customer_Guide_Button;
		private Infragistics.Win.Misc.UltraLabel CustomerSnm_Label;
		private Infragistics.Win.Misc.UltraLabel CustomerInfo_Label;
		private Broadleaf.Library.Windows.Forms.TNedit CustomerCode_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel TotalDay_Tittle_Label;
        private Infragistics.Win.Misc.UltraLabel TotalDay_Label;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.Panel Five_Grid_Panel;
		private Infragistics.Win.UltraWinGrid.UltraGrid Acc_Grid;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.Misc.UltraLabel Line2_Label;
		private Infragistics.Win.UltraWinGrid.UltraGrid Dmd_Grid;
        private System.Windows.Forms.Panel claim_panel;
		private Broadleaf.Library.Windows.Forms.TLine tLine28;
		private Broadleaf.Library.Windows.Forms.TLine tLine30;
        private Broadleaf.Library.Windows.Forms.TLine tLine31;
        private Infragistics.Win.Misc.UltraLabel TtlBlDmd_Label;
        private Infragistics.Win.Misc.UltraLabel TtlDepoDmd_Label;
        private Infragistics.Win.Misc.UltraLabel TtlConsTaxDmd_Label;
        private Infragistics.Win.Misc.UltraLabel TtlSalesDmd_Label;
        private Infragistics.Win.Misc.UltraLabel TtlLMBlDmd_Label;
        private Infragistics.Win.Misc.UltraLabel Ttl2TmDmd_Label;
        private Infragistics.Win.Misc.UltraLabel Ttl3TmDmd_Label;
		private Broadleaf.Library.Windows.Forms.TLine tLine33;
		private Broadleaf.Library.Windows.Forms.TLine tLine34;
		private Broadleaf.Library.Windows.Forms.TLine tLine35;
		private Broadleaf.Library.Windows.Forms.TLine tLine36;
		private Broadleaf.Library.Windows.Forms.TLine tLine37;
		private Broadleaf.Library.Windows.Forms.TLine tLine38;
		private Broadleaf.Library.Windows.Forms.TLine tLine39;
        private Broadleaf.Library.Windows.Forms.TLine tLine40;
		private Infragistics.Win.Misc.UltraLabel BlDmdTitle_Label;
		private Infragistics.Win.Misc.UltraLabel DepositTotalTitle_Label;
		private Infragistics.Win.Misc.UltraLabel ConsTaxTitle_Label;
		private Infragistics.Win.Misc.UltraLabel SalesTotalTitle_Label;
		private Infragistics.Win.Misc.UltraLabel TtlLMTitle_Label;
		private Infragistics.Win.Misc.UltraLabel Ttl2TmTitle_Label;
		private Infragistics.Win.Misc.UltraLabel Ttl3TmTitle_Label;
		private Broadleaf.Library.Windows.Forms.TLine tLine42;
        private System.Windows.Forms.Splitter splitter1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar First_StatusBar;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Second_StatusBar;
		private System.Windows.Forms.Timer Close_Timer;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToFirstGridColumn_CheckEditor;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToSecondGridColumn_CheckEditor;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU09110UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU09110UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU09110UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU09110UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.Misc.UltraLabel cust_Label;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel ClaimName2_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ClaimSnm_Label;
        private TNedit ClaimCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel TtlBalanceAdjust_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel CustomerName_Label;
        private Infragistics.Win.Misc.UltraLabel ClaimName_Label;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TComboEditor TargetDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel SecInfo_Tittle_Label;
        private TComboEditor SecCode_tComboEditor;
        private TNedit tNedit_SectionCode;
        private Infragistics.Win.Misc.UltraButton uButton_SectionGuide;
        private Infragistics.Win.Misc.UltraLabel SectionName_Label;
		private System.ComponentModel.IContainer components;

		# endregion

        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor

        /// <summary>
		/// 
		/// </summary>
		public MAKAU09110UA()
		{
			InitializeComponent();
		
			//　企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.29 TOKUNAGA ADD START
            // 自拠点コードを取得する
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.29 TOKUNAGA ADD END

			// 変数初期化
			this._targetData = TargetData.First;

            this._customerInfoAcs = new CustomerInfoAcs();

            this._controlScreenSkin = new ControlScreenSkin();      // 2009.01.06 Add
        }
		# endregion 

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion 

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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("得意先検索ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Delete_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("New_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool5 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool6 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("New_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool7 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Delete_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool8 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool9 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Details_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool1");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool10 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("AddUpDateBase_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU09110UA));
            this.AutoFillToFirstGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.AutoFillToSecondGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.Five_Grid_Panel = new System.Windows.Forms.Panel();
            this.Acc_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.First_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.Dmd_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Second_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.New_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Modify_Button = new Infragistics.Win.Misc.UltraButton();
            this.Details_Button = new Infragistics.Win.Misc.UltraButton();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.Customer_Panel = new System.Windows.Forms.Panel();
            this.SectionName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.SecInfo_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SecCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.TargetDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ClaimName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ClaimName2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ClaimSnm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ClaimCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.TotalDay_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TotalDay_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerName2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Customer_Guide_Button = new Infragistics.Win.Misc.UltraButton();
            this.CustomerSnm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerInfo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.cust_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Line2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.claim_panel = new System.Windows.Forms.Panel();
            this.TtlBalanceAdjust_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.TtlBlDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BlDmdTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlDepoDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositTotalTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlConsTaxDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlSalesDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlLMBlDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ttl2TmDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ttl3TmDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SalesTotalTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlLMTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ttl2TmTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ttl3TmTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tLine33 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine34 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine35 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine36 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine38 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine39 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine28 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine30 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine31 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine37 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine40 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine42 = new Broadleaf.Library.Windows.Forms.TLine();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Close_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this._MAKAU09110UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MAKAU09110UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU09110UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl1.SuspendLayout();
            this.Five_Grid_Panel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.Acc_Grid ) ).BeginInit();
            this.First_StatusBar.SuspendLayout();
            this.ultraTabPageControl4.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.Dmd_Grid ) ).BeginInit();
            this.Second_StatusBar.SuspendLayout();
            this.ViewButtonPanel.SuspendLayout();
            this.Customer_Panel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SectionCode ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SecCode_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TargetDiv_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ClaimCode_tNedit ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.CustomerCode_tNedit ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraTabControl1 ) ).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.Bind_DataSet ) ).BeginInit();
            this.claim_panel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine33 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine34 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine35 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine36 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine38 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine39 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine28 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine30 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine31 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine37 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine40 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine42 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraToolbarsManager1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // AutoFillToFirstGridColumn_CheckEditor
            // 
            appearance1.FontData.SizeInPoints = 9F;
            this.AutoFillToFirstGridColumn_CheckEditor.Appearance = appearance1;
            this.AutoFillToFirstGridColumn_CheckEditor.Checked = true;
            this.AutoFillToFirstGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToFirstGridColumn_CheckEditor.Location = new System.Drawing.Point(3, 4);
            this.AutoFillToFirstGridColumn_CheckEditor.Name = "AutoFillToFirstGridColumn_CheckEditor";
            this.AutoFillToFirstGridColumn_CheckEditor.Size = new System.Drawing.Size(138, 20);
            this.AutoFillToFirstGridColumn_CheckEditor.TabIndex = 10;
            this.AutoFillToFirstGridColumn_CheckEditor.Text = "列サイズの自動調整";
            this.AutoFillToFirstGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToFirstGridColumn_CheckedChanged);
            // 
            // AutoFillToSecondGridColumn_CheckEditor
            // 
            appearance2.FontData.SizeInPoints = 9F;
            this.AutoFillToSecondGridColumn_CheckEditor.Appearance = appearance2;
            this.AutoFillToSecondGridColumn_CheckEditor.Checked = true;
            this.AutoFillToSecondGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToSecondGridColumn_CheckEditor.Location = new System.Drawing.Point(3, 4);
            this.AutoFillToSecondGridColumn_CheckEditor.Name = "AutoFillToSecondGridColumn_CheckEditor";
            this.AutoFillToSecondGridColumn_CheckEditor.Size = new System.Drawing.Size(138, 20);
            this.AutoFillToSecondGridColumn_CheckEditor.TabIndex = 10;
            this.AutoFillToSecondGridColumn_CheckEditor.Text = "列サイズの自動調整";
            this.AutoFillToSecondGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToSecondGridColumn_CheckedChanged);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.Five_Grid_Panel);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 32);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(928, 393);
            // 
            // Five_Grid_Panel
            // 
            this.Five_Grid_Panel.Controls.Add(this.Acc_Grid);
            this.Five_Grid_Panel.Controls.Add(this.First_StatusBar);
            this.Five_Grid_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Five_Grid_Panel.Location = new System.Drawing.Point(0, 0);
            this.Five_Grid_Panel.Name = "Five_Grid_Panel";
            this.Five_Grid_Panel.Size = new System.Drawing.Size(928, 393);
            this.Five_Grid_Panel.TabIndex = 11;
            // 
            // Acc_Grid
            // 
            this.Acc_Grid.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Acc_Grid.DisplayLayout.Appearance = appearance3;
            this.Acc_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.Acc_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Acc_Grid.DisplayLayout.InterBandSpacing = 10;
            this.Acc_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Acc_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Acc_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Acc_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Acc_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.Acc_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.Acc_Grid.DisplayLayout.Override.CardAreaAppearance = appearance4;
            this.Acc_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance5.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Acc_Grid.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.Acc_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance6.BackColor = System.Drawing.Color.Lavender;
            this.Acc_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 1 ) ) ) ), ( (int)( ( (byte)( 68 ) ) ) ), ( (int)( ( (byte)( 208 ) ) ) ));
            this.Acc_Grid.DisplayLayout.Override.RowAppearance = appearance7;
            this.Acc_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Acc_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance8.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.White;
            this.Acc_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance8;
            this.Acc_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Acc_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Acc_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance9.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.Acc_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance9;
            this.Acc_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Acc_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Acc_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Acc_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
            this.Acc_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Acc_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Acc_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Acc_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Acc_Grid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Acc_Grid.Location = new System.Drawing.Point(0, 0);
            this.Acc_Grid.Name = "Acc_Grid";
            this.Acc_Grid.Size = new System.Drawing.Size(928, 366);
            this.Acc_Grid.TabIndex = 6;
            this.Acc_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.Acc_Grid_AfterSelectChange);
            this.Acc_Grid.Enter += new System.EventHandler(this.Acc_Grid_Enter);
            this.Acc_Grid.AfterRowActivate += new System.EventHandler(this.Acc_Grid_AfterRowActivate);
            this.Acc_Grid.DoubleClick += new System.EventHandler(this.Acc_Grid_DoubleClick);
            this.Acc_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Acc_Grid_KeyDown);
            this.Acc_Grid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.Acc_Grid_AfterSortChange);
            this.Acc_Grid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.Acc_Grid_BeforeRowDeactivate);
            // 
            // First_StatusBar
            // 
            appearance10.FontData.SizeInPoints = 9F;
            this.First_StatusBar.Appearance = appearance10;
            this.First_StatusBar.Controls.Add(this.AutoFillToFirstGridColumn_CheckEditor);
            this.First_StatusBar.InterPanelSpacing = 5;
            this.First_StatusBar.Location = new System.Drawing.Point(0, 366);
            this.First_StatusBar.Name = "First_StatusBar";
            ultraStatusPanel1.Control = this.AutoFillToFirstGridColumn_CheckEditor;
            ultraStatusPanel1.Key = "AutoFillToFiveGridColumn_StatusPanel";
            ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel1.Width = 140;
            ultraStatusPanel2.Key = "Line1_StatusPanel";
            ultraStatusPanel2.Width = 1;
            appearance11.TextHAlignAsString = "Right";
            ultraStatusPanel3.Appearance = appearance11;
            ultraStatusPanel3.Key = "SearchCount_StatusPanel";
            ultraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel3.Text = "件";
            ultraStatusPanel3.Width = 0;
            this.First_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.First_StatusBar.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.None;
            this.First_StatusBar.Size = new System.Drawing.Size(928, 27);
            this.First_StatusBar.TabIndex = 14;
            this.First_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.Dmd_Grid);
            this.ultraTabPageControl4.Controls.Add(this.Second_StatusBar);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(928, 393);
            // 
            // Dmd_Grid
            // 
            this.Dmd_Grid.Cursor = System.Windows.Forms.Cursors.Default;
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Dmd_Grid.DisplayLayout.Appearance = appearance12;
            this.Dmd_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.Dmd_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Dmd_Grid.DisplayLayout.InterBandSpacing = 10;
            this.Dmd_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Dmd_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Dmd_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Dmd_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Dmd_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.Dmd_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.Dmd_Grid.DisplayLayout.Override.CardAreaAppearance = appearance13;
            this.Dmd_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance14.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.White;
            appearance14.TextHAlignAsString = "Left";
            appearance14.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Dmd_Grid.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.Dmd_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance15.BackColor = System.Drawing.Color.Lavender;
            this.Dmd_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 1 ) ) ) ), ( (int)( ( (byte)( 68 ) ) ) ), ( (int)( ( (byte)( 208 ) ) ) ));
            this.Dmd_Grid.DisplayLayout.Override.RowAppearance = appearance16;
            this.Dmd_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Dmd_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance17.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance17.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.ForeColor = System.Drawing.Color.White;
            this.Dmd_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance17;
            this.Dmd_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Dmd_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Dmd_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance18.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.ForeColor = System.Drawing.Color.Black;
            this.Dmd_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance18;
            this.Dmd_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Dmd_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Dmd_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Dmd_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
            this.Dmd_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Dmd_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Dmd_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Dmd_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dmd_Grid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Dmd_Grid.Location = new System.Drawing.Point(0, 0);
            this.Dmd_Grid.Name = "Dmd_Grid";
            this.Dmd_Grid.Size = new System.Drawing.Size(928, 366);
            this.Dmd_Grid.TabIndex = 14;
            this.Dmd_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.Acc_Grid_AfterSelectChange);
            this.Dmd_Grid.Enter += new System.EventHandler(this.Dmd_Grid_Enter);
            this.Dmd_Grid.AfterRowActivate += new System.EventHandler(this.Acc_Grid_AfterRowActivate);
            this.Dmd_Grid.DoubleClick += new System.EventHandler(this.Acc_Grid_DoubleClick);
            this.Dmd_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Acc_Grid_KeyDown);
            this.Dmd_Grid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.Acc_Grid_AfterSortChange);
            this.Dmd_Grid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.Acc_Grid_BeforeRowDeactivate);
            // 
            // Second_StatusBar
            // 
            appearance19.FontData.SizeInPoints = 9F;
            this.Second_StatusBar.Appearance = appearance19;
            this.Second_StatusBar.Controls.Add(this.AutoFillToSecondGridColumn_CheckEditor);
            this.Second_StatusBar.InterPanelSpacing = 5;
            this.Second_StatusBar.Location = new System.Drawing.Point(0, 366);
            this.Second_StatusBar.Name = "Second_StatusBar";
            ultraStatusPanel4.Control = this.AutoFillToSecondGridColumn_CheckEditor;
            ultraStatusPanel4.Key = "AutoFillToFiveGridColumn_StatusPanel";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel4.Width = 140;
            ultraStatusPanel5.Key = "Line1_StatusPanel";
            ultraStatusPanel5.Width = 1;
            appearance20.TextHAlignAsString = "Right";
            ultraStatusPanel6.Appearance = appearance20;
            ultraStatusPanel6.Key = "SearchCount_StatusPanel";
            ultraStatusPanel6.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel6.Text = "件";
            ultraStatusPanel6.Width = 0;
            this.Second_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6});
            this.Second_StatusBar.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.None;
            this.Second_StatusBar.Size = new System.Drawing.Size(928, 27);
            this.Second_StatusBar.TabIndex = 13;
            this.Second_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Close_Button
            // 
            this.Close_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Close_Button.Location = new System.Drawing.Point(15, 10);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(90, 27);
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Text = "閉じる(&C)";
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // New_Button
            // 
            this.New_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.New_Button.Location = new System.Drawing.Point(173, 3);
            this.New_Button.Name = "New_Button";
            this.New_Button.Size = new System.Drawing.Size(75, 27);
            this.New_Button.TabIndex = 3;
            this.New_Button.TabStop = false;
            this.New_Button.Text = "新規(&N)";
            this.New_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.New_Button.Click += new System.EventHandler(this.New_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Delete_Button.Location = new System.Drawing.Point(170, 0);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 27);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.TabStop = false;
            this.Delete_Button.Text = "削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // Modify_Button
            // 
            this.Modify_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Modify_Button.Location = new System.Drawing.Point(251, 10);
            this.Modify_Button.Name = "Modify_Button";
            this.Modify_Button.Size = new System.Drawing.Size(75, 27);
            this.Modify_Button.TabIndex = 5;
            this.Modify_Button.TabStop = false;
            this.Modify_Button.Text = "修正(&E)";
            this.Modify_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Modify_Button.Click += new System.EventHandler(this.Modify_Button_Click);
            // 
            // Details_Button
            // 
            this.Details_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Details_Button.Location = new System.Drawing.Point(333, 3);
            this.Details_Button.Name = "Details_Button";
            this.Details_Button.Size = new System.Drawing.Size(90, 27);
            this.Details_Button.TabIndex = 9;
            this.Details_Button.TabStop = false;
            this.Details_Button.Text = "詳細(&T)";
            this.Details_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Details_Button.Visible = false;
            this.Details_Button.Click += new System.EventHandler(this.Details_Button_Click);
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.Details_Button);
            this.ViewButtonPanel.Controls.Add(this.Delete_Button);
            this.ViewButtonPanel.Controls.Add(this.New_Button);
            this.ViewButtonPanel.Controls.Add(this.Modify_Button);
            this.ViewButtonPanel.Controls.Add(this.Close_Button);
            this.ViewButtonPanel.Location = new System.Drawing.Point(301, 0);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(488, 40);
            this.ViewButtonPanel.TabIndex = 2;
            this.ViewButtonPanel.Visible = false;
            // 
            // Customer_Panel
            // 
            this.Customer_Panel.Controls.Add(this.SectionName_Label);
            this.Customer_Panel.Controls.Add(this.tNedit_SectionCode);
            this.Customer_Panel.Controls.Add(this.uButton_SectionGuide);
            this.Customer_Panel.Controls.Add(this.SecInfo_Tittle_Label);
            this.Customer_Panel.Controls.Add(this.SecCode_tComboEditor);
            this.Customer_Panel.Controls.Add(this.ultraLabel4);
            this.Customer_Panel.Controls.Add(this.TargetDiv_tComboEditor);
            this.Customer_Panel.Controls.Add(this.ClaimName_Label);
            this.Customer_Panel.Controls.Add(this.CustomerName_Label);
            this.Customer_Panel.Controls.Add(this.ClaimName2_Label);
            this.Customer_Panel.Controls.Add(this.ultraLabel2);
            this.Customer_Panel.Controls.Add(this.ClaimSnm_Label);
            this.Customer_Panel.Controls.Add(this.ClaimCode_tNedit);
            this.Customer_Panel.Controls.Add(this.ultraLabel6);
            this.Customer_Panel.Controls.Add(this.TotalDay_Tittle_Label);
            this.Customer_Panel.Controls.Add(this.TotalDay_Label);
            this.Customer_Panel.Controls.Add(this.CustomerCode_tNedit);
            this.Customer_Panel.Controls.Add(this.CustomerName2_Label);
            this.Customer_Panel.Controls.Add(this.Customer_Guide_Button);
            this.Customer_Panel.Controls.Add(this.CustomerSnm_Label);
            this.Customer_Panel.Controls.Add(this.CustomerInfo_Label);
            this.Customer_Panel.Controls.Add(this.cust_Label);
            this.Customer_Panel.Controls.Add(this.Line2_Label);
            this.Customer_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Customer_Panel.Location = new System.Drawing.Point(0, 29);
            this.Customer_Panel.Name = "Customer_Panel";
            this.Customer_Panel.Size = new System.Drawing.Size(930, 145);
            this.Customer_Panel.TabIndex = 370;
            // 
            // SectionName_Label
            // 
            appearance34.BackColor = System.Drawing.Color.Gainsboro;
            appearance34.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextVAlignAsString = "Middle";
            this.SectionName_Label.Appearance = appearance34;
            this.SectionName_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.SectionName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SectionName_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SectionName_Label.Location = new System.Drawing.Point(130, 56);
            this.SectionName_Label.Name = "SectionName_Label";
            this.SectionName_Label.Size = new System.Drawing.Size(323, 24);
            this.SectionName_Label.TabIndex = 1380;
            // 
            // tNedit_SectionCode
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.TextHAlignAsString = "Right";
            appearance48.TextVAlignAsString = "Middle";
            this.tNedit_SectionCode.ActiveAppearance = appearance48;
            appearance75.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColor = System.Drawing.Color.Black;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            appearance75.TextHAlignAsString = "Right";
            appearance75.TextVAlignAsString = "Middle";
            this.tNedit_SectionCode.Appearance = appearance75;
            this.tNedit_SectionCode.AutoSelect = true;
            this.tNedit_SectionCode.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tNedit_SectionCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SectionCode.DataText = "";
            this.tNedit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SectionCode.Location = new System.Drawing.Point(98, 56);
            this.tNedit_SectionCode.MaxLength = 2;
            this.tNedit_SectionCode.Name = "tNedit_SectionCode";
            this.tNedit_SectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SectionCode.Size = new System.Drawing.Size(28, 24);
            this.tNedit_SectionCode.TabIndex = 1377;
            this.tNedit_SectionCode.Leave += new System.EventHandler(this.tNedit_SectionCode_Leave);
            // 
            // uButton_SectionGuide
            // 
            this.uButton_SectionGuide.Location = new System.Drawing.Point(455, 56);
            this.uButton_SectionGuide.Name = "uButton_SectionGuide";
            this.uButton_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SectionGuide.TabIndex = 1378;
            this.uButton_SectionGuide.Click += new System.EventHandler(this.uButton_SectionGuide_Click);
            // 
            // SecInfo_Tittle_Label
            // 
            appearance63.BackColor = System.Drawing.Color.Transparent;
            appearance63.TextVAlignAsString = "Middle";
            this.SecInfo_Tittle_Label.Appearance = appearance63;
            this.SecInfo_Tittle_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SecInfo_Tittle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SecInfo_Tittle_Label.Location = new System.Drawing.Point(8, 56);
            this.SecInfo_Tittle_Label.Name = "SecInfo_Tittle_Label";
            this.SecInfo_Tittle_Label.Size = new System.Drawing.Size(84, 24);
            this.SecInfo_Tittle_Label.TabIndex = 381;
            this.SecInfo_Tittle_Label.Text = "拠点";
            // 
            // SecCode_tComboEditor
            // 
            this.SecCode_tComboEditor.ActiveAppearance = appearance64;
            appearance65.ForeColor = System.Drawing.Color.Black;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.SecCode_tComboEditor.Appearance = appearance65;
            this.SecCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SecCode_tComboEditor.Location = new System.Drawing.Point(440, 28);
            this.SecCode_tComboEditor.Name = "SecCode_tComboEditor";
            this.SecCode_tComboEditor.Size = new System.Drawing.Size(244, 24);
            this.SecCode_tComboEditor.TabIndex = 2;
            this.SecCode_tComboEditor.Visible = false;
            // 
            // ultraLabel4
            // 
            appearance37.BackColor = System.Drawing.Color.Transparent;
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance37;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ultraLabel4.Location = new System.Drawing.Point(8, 30);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(84, 24);
            this.ultraLabel4.TabIndex = 379;
            this.ultraLabel4.Text = "指定区分";
            // 
            // TargetDiv_tComboEditor
            // 
            this.TargetDiv_tComboEditor.ActiveAppearance = appearance38;
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            this.TargetDiv_tComboEditor.Appearance = appearance39;
            this.TargetDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            valueListItem1.DisplayText = "請求先";
            valueListItem2.DataValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            valueListItem2.DisplayText = "得意先";
            this.TargetDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.TargetDiv_tComboEditor.Location = new System.Drawing.Point(98, 30);
            this.TargetDiv_tComboEditor.Name = "TargetDiv_tComboEditor";
            this.TargetDiv_tComboEditor.Size = new System.Drawing.Size(104, 24);
            this.TargetDiv_tComboEditor.TabIndex = 1;
            this.TargetDiv_tComboEditor.ValueChanged += new System.EventHandler(this.TargetDiv_tComboEditor_ValueChanged);
            // 
            // ClaimName_Label
            // 
            appearance40.BackColor = System.Drawing.SystemColors.Control;
            appearance40.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.ClaimName_Label.Appearance = appearance40;
            this.ClaimName_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.ClaimName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ClaimName_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ClaimName_Label.Location = new System.Drawing.Point(714, 58);
            this.ClaimName_Label.Name = "ClaimName_Label";
            this.ClaimName_Label.Size = new System.Drawing.Size(20, 24);
            this.ClaimName_Label.TabIndex = 377;
            this.ClaimName_Label.Visible = false;
            // 
            // CustomerName_Label
            // 
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextVAlignAsString = "Middle";
            this.CustomerName_Label.Appearance = appearance22;
            this.CustomerName_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.CustomerName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerName_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.CustomerName_Label.Location = new System.Drawing.Point(690, 28);
            this.CustomerName_Label.Name = "CustomerName_Label";
            this.CustomerName_Label.Size = new System.Drawing.Size(18, 24);
            this.CustomerName_Label.TabIndex = 376;
            this.CustomerName_Label.Visible = false;
            // 
            // ClaimName2_Label
            // 
            appearance23.BackColor = System.Drawing.SystemColors.Control;
            appearance23.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.ClaimName2_Label.Appearance = appearance23;
            this.ClaimName2_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.ClaimName2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ClaimName2_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ClaimName2_Label.Location = new System.Drawing.Point(690, 58);
            this.ClaimName2_Label.Name = "ClaimName2_Label";
            this.ClaimName2_Label.Size = new System.Drawing.Size(23, 24);
            this.ClaimName2_Label.TabIndex = 375;
            this.ClaimName2_Label.Visible = false;
            // 
            // ultraLabel2
            // 
            appearance24.BackColor = System.Drawing.Color.Transparent;
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance24;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ultraLabel2.Location = new System.Drawing.Point(266, 107);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(64, 24);
            this.ultraLabel2.TabIndex = 374;
            this.ultraLabel2.Text = "請求先";
            this.ultraLabel2.Visible = false;
            // 
            // ClaimSnm_Label
            // 
            appearance25.BackColor = System.Drawing.Color.Gainsboro;
            appearance25.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.ClaimSnm_Label.Appearance = appearance25;
            this.ClaimSnm_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.ClaimSnm_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ClaimSnm_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ClaimSnm_Label.Location = new System.Drawing.Point(426, 108);
            this.ClaimSnm_Label.Name = "ClaimSnm_Label";
            this.ClaimSnm_Label.Size = new System.Drawing.Size(472, 24);
            this.ClaimSnm_Label.TabIndex = 373;
            this.ClaimSnm_Label.Visible = false;
            // 
            // ClaimCode_tNedit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Right";
            this.ClaimCode_tNedit.ActiveAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Right";
            this.ClaimCode_tNedit.Appearance = appearance27;
            this.ClaimCode_tNedit.AutoSelect = true;
            this.ClaimCode_tNedit.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.ClaimCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.ClaimCode_tNedit.DataText = "";
            this.ClaimCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ClaimCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.ClaimCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ClaimCode_tNedit.Location = new System.Drawing.Point(338, 108);
            this.ClaimCode_tNedit.MaxLength = 8;
            this.ClaimCode_tNedit.Name = "ClaimCode_tNedit";
            this.ClaimCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.ClaimCode_tNedit.ReadOnly = true;
            this.ClaimCode_tNedit.Size = new System.Drawing.Size(82, 24);
            this.ClaimCode_tNedit.TabIndex = 372;
            this.ClaimCode_tNedit.Visible = false;
            // 
            // ultraLabel6
            // 
            appearance28.TextHAlignAsString = "Center";
            appearance28.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance28;
            this.ultraLabel6.Location = new System.Drawing.Point(131, 110);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(28, 24);
            this.ultraLabel6.TabIndex = 5;
            this.ultraLabel6.Text = "日";
            // 
            // TotalDay_Tittle_Label
            // 
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            this.TotalDay_Tittle_Label.Appearance = appearance29;
            this.TotalDay_Tittle_Label.Location = new System.Drawing.Point(8, 108);
            this.TotalDay_Tittle_Label.Name = "TotalDay_Tittle_Label";
            this.TotalDay_Tittle_Label.Size = new System.Drawing.Size(64, 24);
            this.TotalDay_Tittle_Label.TabIndex = 363;
            this.TotalDay_Tittle_Label.Text = "締日";
            // 
            // TotalDay_Label
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 224 ) ) ) ), ( (int)( ( (byte)( 224 ) ) ) ), ( (int)( ( (byte)( 224 ) ) ) ));
            appearance30.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance30.TextHAlignAsString = "Right";
            appearance30.TextVAlignAsString = "Middle";
            this.TotalDay_Label.Appearance = appearance30;
            this.TotalDay_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.TotalDay_Label.Location = new System.Drawing.Point(98, 108);
            this.TotalDay_Label.Name = "TotalDay_Label";
            this.TotalDay_Label.Size = new System.Drawing.Size(32, 24);
            this.TotalDay_Label.TabIndex = 4;
            // 
            // CustomerCode_tNedit
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            appearance31.TextHAlignAsString = "Right";
            this.CustomerCode_tNedit.ActiveAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Right";
            this.CustomerCode_tNedit.Appearance = appearance32;
            this.CustomerCode_tNedit.AutoSelect = true;
            this.CustomerCode_tNedit.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.CustomerCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerCode_tNedit.DataText = "";
            this.CustomerCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CustomerCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CustomerCode_tNedit.Location = new System.Drawing.Point(98, 82);
            this.CustomerCode_tNedit.MaxLength = 8;
            this.CustomerCode_tNedit.Name = "CustomerCode_tNedit";
            this.CustomerCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.CustomerCode_tNedit.Size = new System.Drawing.Size(74, 24);
            this.CustomerCode_tNedit.TabIndex = 3;
            this.CustomerCode_tNedit.ValueChanged += new System.EventHandler(this.CustomerCode_tNedit_ValueChanged);
            this.CustomerCode_tNedit.Leave += new System.EventHandler(this.CustomerCode_tNedit_Leave);
            this.CustomerCode_tNedit.Enter += new System.EventHandler(this.CustomerCode_tNedit_Enter);
            // 
            // CustomerName2_Label
            // 
            appearance33.BackColor = System.Drawing.SystemColors.Control;
            appearance33.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            appearance33.TextVAlignAsString = "Middle";
            this.CustomerName2_Label.Appearance = appearance33;
            this.CustomerName2_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.CustomerName2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerName2_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.CustomerName2_Label.Location = new System.Drawing.Point(714, 28);
            this.CustomerName2_Label.Name = "CustomerName2_Label";
            this.CustomerName2_Label.Size = new System.Drawing.Size(20, 24);
            this.CustomerName2_Label.TabIndex = 6;
            this.CustomerName2_Label.Visible = false;
            // 
            // Customer_Guide_Button
            // 
            this.Customer_Guide_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Customer_Guide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Customer_Guide_Button.Location = new System.Drawing.Point(501, 82);
            this.Customer_Guide_Button.Name = "Customer_Guide_Button";
            this.Customer_Guide_Button.Size = new System.Drawing.Size(24, 24);
            this.Customer_Guide_Button.TabIndex = 4;
            this.Customer_Guide_Button.Text = "?";
            ultraToolTipInfo1.ToolTipText = "得意先検索ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.Customer_Guide_Button, ultraToolTipInfo1);
            this.Customer_Guide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Customer_Guide_Button.Click += new System.EventHandler(this.Customer_Guide_Button_Click);
            // 
            // CustomerSnm_Label
            // 
            appearance46.BackColor = System.Drawing.Color.Gainsboro;
            appearance46.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            appearance46.TextVAlignAsString = "Middle";
            this.CustomerSnm_Label.Appearance = appearance46;
            this.CustomerSnm_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.CustomerSnm_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CustomerSnm_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.CustomerSnm_Label.Location = new System.Drawing.Point(176, 82);
            this.CustomerSnm_Label.Name = "CustomerSnm_Label";
            this.CustomerSnm_Label.Size = new System.Drawing.Size(323, 24);
            this.CustomerSnm_Label.TabIndex = 5;
            // 
            // CustomerInfo_Label
            // 
            appearance35.BackColor = System.Drawing.Color.Transparent;
            appearance35.TextVAlignAsString = "Middle";
            this.CustomerInfo_Label.Appearance = appearance35;
            this.CustomerInfo_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CustomerInfo_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.CustomerInfo_Label.Location = new System.Drawing.Point(8, 82);
            this.CustomerInfo_Label.Name = "CustomerInfo_Label";
            this.CustomerInfo_Label.Size = new System.Drawing.Size(64, 24);
            this.CustomerInfo_Label.TabIndex = 357;
            this.CustomerInfo_Label.Text = "得意先";
            // 
            // cust_Label
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance36.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance36.BorderColor = System.Drawing.Color.Black;
            appearance36.TextHAlignAsString = "Center";
            appearance36.TextVAlignAsString = "Middle";
            this.cust_Label.Appearance = appearance36;
            this.cust_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.cust_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cust_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.cust_Label.Location = new System.Drawing.Point(0, 0);
            this.cust_Label.Name = "cust_Label";
            this.cust_Label.Size = new System.Drawing.Size(244, 24);
            this.cust_Label.TabIndex = 371;
            this.cust_Label.Text = "得意先情報";
            // 
            // Line2_Label
            // 
            this.Line2_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Line2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.Line2_Label.Location = new System.Drawing.Point(0, 148);
            this.Line2_Label.Name = "Line2_Label";
            this.Line2_Label.Size = new System.Drawing.Size(986, 3);
            this.Line2_Label.TabIndex = 359;
            // 
            // ultraTabControl1
            // 
            appearance41.BackColor = System.Drawing.Color.LightPink;
            appearance41.BackColor2 = System.Drawing.Color.White;
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance41.ForeColor = System.Drawing.Color.Black;
            this.ultraTabControl1.ActiveTabAppearance = appearance41;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.ImageSize = new System.Drawing.Size(24, 24);
            this.ultraTabControl1.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 174);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.ultraTabControl1.Size = new System.Drawing.Size(930, 426);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.ultraTabControl1.TabIndex = 30;
            this.ultraTabControl1.TabPadding = new System.Drawing.Size(3, 3);
            appearance42.BackColor = System.Drawing.Color.White;
            appearance42.BackColor2 = System.Drawing.Color.LightPink;
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab1.ActiveAppearance = appearance42;
            appearance43.BackColor = System.Drawing.Color.White;
            appearance43.BackColor2 = System.Drawing.Color.Lavender;
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab1.Appearance = appearance43;
            ultraTab1.Key = "campanyTab";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "売掛設定";
            appearance44.BackColor = System.Drawing.Color.White;
            appearance44.BackColor2 = System.Drawing.Color.LightPink;
            appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab2.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.White;
            appearance45.BackColor2 = System.Drawing.Color.Lavender;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab2.Appearance = appearance45;
            ultraTab2.Key = "customerTab";
            ultraTab2.TabPage = this.ultraTabPageControl4;
            ultraTab2.Text = "請求設定";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.ultraTabControl1.Click += new System.EventHandler(this.ultraTabControl1_Click);
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(928, 393);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
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
            // claim_panel
            // 
            this.claim_panel.Controls.Add(this.TtlBalanceAdjust_Label);
            this.claim_panel.Controls.Add(this.ultraLabel1);
            this.claim_panel.Controls.Add(this.TtlBlDmd_Label);
            this.claim_panel.Controls.Add(this.BlDmdTitle_Label);
            this.claim_panel.Controls.Add(this.TtlDepoDmd_Label);
            this.claim_panel.Controls.Add(this.DepositTotalTitle_Label);
            this.claim_panel.Controls.Add(this.TtlConsTaxDmd_Label);
            this.claim_panel.Controls.Add(this.TtlSalesDmd_Label);
            this.claim_panel.Controls.Add(this.TtlLMBlDmd_Label);
            this.claim_panel.Controls.Add(this.Ttl2TmDmd_Label);
            this.claim_panel.Controls.Add(this.Ttl3TmDmd_Label);
            this.claim_panel.Controls.Add(this.ConsTaxTitle_Label);
            this.claim_panel.Controls.Add(this.SalesTotalTitle_Label);
            this.claim_panel.Controls.Add(this.TtlLMTitle_Label);
            this.claim_panel.Controls.Add(this.Ttl2TmTitle_Label);
            this.claim_panel.Controls.Add(this.Ttl3TmTitle_Label);
            this.claim_panel.Controls.Add(this.tLine33);
            this.claim_panel.Controls.Add(this.tLine34);
            this.claim_panel.Controls.Add(this.tLine35);
            this.claim_panel.Controls.Add(this.tLine36);
            this.claim_panel.Controls.Add(this.tLine38);
            this.claim_panel.Controls.Add(this.tLine39);
            this.claim_panel.Controls.Add(this.tLine28);
            this.claim_panel.Controls.Add(this.tLine30);
            this.claim_panel.Controls.Add(this.tLine31);
            this.claim_panel.Controls.Add(this.tLine37);
            this.claim_panel.Controls.Add(this.tLine40);
            this.claim_panel.Controls.Add(this.tLine42);
            this.claim_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.claim_panel.Location = new System.Drawing.Point(0, 600);
            this.claim_panel.Name = "claim_panel";
            this.claim_panel.Size = new System.Drawing.Size(930, 70);
            this.claim_panel.TabIndex = 389;
            this.claim_panel.Visible = false;
            // 
            // TtlBalanceAdjust_Label
            // 
            appearance68.TextHAlignAsString = "Right";
            appearance68.TextVAlignAsString = "Middle";
            this.TtlBalanceAdjust_Label.Appearance = appearance68;
            this.TtlBalanceAdjust_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlBalanceAdjust_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlBalanceAdjust_Label.Location = new System.Drawing.Point(568, 29);
            this.TtlBalanceAdjust_Label.Name = "TtlBalanceAdjust_Label";
            this.TtlBalanceAdjust_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlBalanceAdjust_Label.TabIndex = 183;
            // 
            // ultraLabel1
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance66.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance66.TextHAlignAsString = "Center";
            appearance66.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance66;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ultraLabel1.Location = new System.Drawing.Point(568, 5);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(93, 23);
            this.ultraLabel1.TabIndex = 182;
            this.ultraLabel1.Text = "残高調整";
            // 
            // TtlBlDmd_Label
            // 
            appearance69.TextHAlignAsString = "Right";
            appearance69.TextVAlignAsString = "Middle";
            this.TtlBlDmd_Label.Appearance = appearance69;
            this.TtlBlDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlBlDmd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlBlDmd_Label.Location = new System.Drawing.Point(662, 29);
            this.TtlBlDmd_Label.Name = "TtlBlDmd_Label";
            this.TtlBlDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlBlDmd_Label.TabIndex = 167;
            // 
            // BlDmdTitle_Label
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance49.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance49.TextHAlignAsString = "Center";
            appearance49.TextVAlignAsString = "Middle";
            this.BlDmdTitle_Label.Appearance = appearance49;
            this.BlDmdTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.BlDmdTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.BlDmdTitle_Label.Location = new System.Drawing.Point(662, 5);
            this.BlDmdTitle_Label.Name = "BlDmdTitle_Label";
            this.BlDmdTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.BlDmdTitle_Label.TabIndex = 142;
            this.BlDmdTitle_Label.Text = "売掛残高";
            // 
            // TtlDepoDmd_Label
            // 
            appearance70.TextHAlignAsString = "Right";
            appearance70.TextVAlignAsString = "Middle";
            this.TtlDepoDmd_Label.Appearance = appearance70;
            this.TtlDepoDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlDepoDmd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlDepoDmd_Label.Location = new System.Drawing.Point(474, 29);
            this.TtlDepoDmd_Label.Name = "TtlDepoDmd_Label";
            this.TtlDepoDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlDepoDmd_Label.TabIndex = 165;
            // 
            // DepositTotalTitle_Label
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance56.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance56.TextHAlignAsString = "Center";
            appearance56.TextVAlignAsString = "Middle";
            this.DepositTotalTitle_Label.Appearance = appearance56;
            this.DepositTotalTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.DepositTotalTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.DepositTotalTitle_Label.Location = new System.Drawing.Point(474, 5);
            this.DepositTotalTitle_Label.Name = "DepositTotalTitle_Label";
            this.DepositTotalTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.DepositTotalTitle_Label.TabIndex = 141;
            this.DepositTotalTitle_Label.Text = "今回入金";
            // 
            // TtlConsTaxDmd_Label
            // 
            appearance71.TextHAlignAsString = "Right";
            appearance71.TextVAlignAsString = "Middle";
            this.TtlConsTaxDmd_Label.Appearance = appearance71;
            this.TtlConsTaxDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlConsTaxDmd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlConsTaxDmd_Label.Location = new System.Drawing.Point(380, 29);
            this.TtlConsTaxDmd_Label.Name = "TtlConsTaxDmd_Label";
            this.TtlConsTaxDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlConsTaxDmd_Label.TabIndex = 163;
            // 
            // TtlSalesDmd_Label
            // 
            appearance72.TextHAlignAsString = "Right";
            appearance72.TextVAlignAsString = "Middle";
            this.TtlSalesDmd_Label.Appearance = appearance72;
            this.TtlSalesDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlSalesDmd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlSalesDmd_Label.Location = new System.Drawing.Point(286, 29);
            this.TtlSalesDmd_Label.Name = "TtlSalesDmd_Label";
            this.TtlSalesDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlSalesDmd_Label.TabIndex = 161;
            // 
            // TtlLMBlDmd_Label
            // 
            appearance73.TextHAlignAsString = "Right";
            appearance73.TextVAlignAsString = "Middle";
            this.TtlLMBlDmd_Label.Appearance = appearance73;
            this.TtlLMBlDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlLMBlDmd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlLMBlDmd_Label.Location = new System.Drawing.Point(192, 29);
            this.TtlLMBlDmd_Label.Name = "TtlLMBlDmd_Label";
            this.TtlLMBlDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlLMBlDmd_Label.TabIndex = 159;
            // 
            // Ttl2TmDmd_Label
            // 
            appearance54.TextHAlignAsString = "Right";
            appearance54.TextVAlignAsString = "Middle";
            this.Ttl2TmDmd_Label.Appearance = appearance54;
            this.Ttl2TmDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.Ttl2TmDmd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Ttl2TmDmd_Label.Location = new System.Drawing.Point(98, 29);
            this.Ttl2TmDmd_Label.Name = "Ttl2TmDmd_Label";
            this.Ttl2TmDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.Ttl2TmDmd_Label.TabIndex = 157;
            // 
            // Ttl3TmDmd_Label
            // 
            appearance55.TextHAlignAsString = "Right";
            appearance55.TextVAlignAsString = "Middle";
            this.Ttl3TmDmd_Label.Appearance = appearance55;
            this.Ttl3TmDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.Ttl3TmDmd_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Ttl3TmDmd_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.Ttl3TmDmd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Ttl3TmDmd_Label.Location = new System.Drawing.Point(4, 29);
            this.Ttl3TmDmd_Label.Name = "Ttl3TmDmd_Label";
            this.Ttl3TmDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.Ttl3TmDmd_Label.TabIndex = 155;
            // 
            // ConsTaxTitle_Label
            // 
            appearance57.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance57.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance57.TextHAlignAsString = "Center";
            appearance57.TextVAlignAsString = "Middle";
            this.ConsTaxTitle_Label.Appearance = appearance57;
            this.ConsTaxTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.ConsTaxTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ConsTaxTitle_Label.Location = new System.Drawing.Point(380, 5);
            this.ConsTaxTitle_Label.Name = "ConsTaxTitle_Label";
            this.ConsTaxTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.ConsTaxTitle_Label.TabIndex = 140;
            this.ConsTaxTitle_Label.Text = "消費税";
            // 
            // SalesTotalTitle_Label
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance58.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance58.TextHAlignAsString = "Center";
            appearance58.TextVAlignAsString = "Middle";
            this.SalesTotalTitle_Label.Appearance = appearance58;
            this.SalesTotalTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.SalesTotalTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SalesTotalTitle_Label.Location = new System.Drawing.Point(286, 5);
            this.SalesTotalTitle_Label.Name = "SalesTotalTitle_Label";
            this.SalesTotalTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.SalesTotalTitle_Label.TabIndex = 139;
            this.SalesTotalTitle_Label.Text = "今回売上";
            // 
            // TtlLMTitle_Label
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance59.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance59.TextHAlignAsString = "Center";
            appearance59.TextVAlignAsString = "Middle";
            this.TtlLMTitle_Label.Appearance = appearance59;
            this.TtlLMTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.TtlLMTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlLMTitle_Label.Location = new System.Drawing.Point(192, 5);
            this.TtlLMTitle_Label.Name = "TtlLMTitle_Label";
            this.TtlLMTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlLMTitle_Label.TabIndex = 138;
            this.TtlLMTitle_Label.Text = "前回残高";
            // 
            // Ttl2TmTitle_Label
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance60.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance60.TextHAlignAsString = "Center";
            appearance60.TextVAlignAsString = "Middle";
            this.Ttl2TmTitle_Label.Appearance = appearance60;
            this.Ttl2TmTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.Ttl2TmTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Ttl2TmTitle_Label.Location = new System.Drawing.Point(98, 5);
            this.Ttl2TmTitle_Label.Name = "Ttl2TmTitle_Label";
            this.Ttl2TmTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.Ttl2TmTitle_Label.TabIndex = 137;
            this.Ttl2TmTitle_Label.Text = "前々回残高";
            // 
            // Ttl3TmTitle_Label
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance61.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.BorderColor = System.Drawing.Color.White;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.Ttl3TmTitle_Label.Appearance = appearance61;
            this.Ttl3TmTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.Ttl3TmTitle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Ttl3TmTitle_Label.Location = new System.Drawing.Point(4, 5);
            this.Ttl3TmTitle_Label.Name = "Ttl3TmTitle_Label";
            this.Ttl3TmTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.Ttl3TmTitle_Label.TabIndex = 136;
            this.Ttl3TmTitle_Label.Text = "前々々回残高";
            // 
            // tLine33
            // 
            this.tLine33.BackColor = System.Drawing.Color.Transparent;
            this.tLine33.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine33.ForeColor = System.Drawing.Color.Black;
            this.tLine33.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine33.Location = new System.Drawing.Point(755, 4);
            this.tLine33.Name = "tLine33";
            this.tLine33.Size = new System.Drawing.Size(4, 49);
            this.tLine33.TabIndex = 153;
            this.tLine33.Text = "tLine14";
            // 
            // tLine34
            // 
            this.tLine34.BackColor = System.Drawing.Color.Transparent;
            this.tLine34.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine34.ForeColor = System.Drawing.Color.Black;
            this.tLine34.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine34.Location = new System.Drawing.Point(661, 4);
            this.tLine34.Name = "tLine34";
            this.tLine34.Size = new System.Drawing.Size(1, 49);
            this.tLine34.TabIndex = 152;
            this.tLine34.Text = "tLine13";
            // 
            // tLine35
            // 
            this.tLine35.BackColor = System.Drawing.Color.Transparent;
            this.tLine35.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine35.ForeColor = System.Drawing.Color.Black;
            this.tLine35.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine35.Location = new System.Drawing.Point(567, 4);
            this.tLine35.Name = "tLine35";
            this.tLine35.Size = new System.Drawing.Size(4, 49);
            this.tLine35.TabIndex = 151;
            this.tLine35.Text = "tLine12";
            // 
            // tLine36
            // 
            this.tLine36.BackColor = System.Drawing.Color.Transparent;
            this.tLine36.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine36.ForeColor = System.Drawing.Color.Black;
            this.tLine36.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine36.Location = new System.Drawing.Point(473, 4);
            this.tLine36.Name = "tLine36";
            this.tLine36.Size = new System.Drawing.Size(1, 49);
            this.tLine36.TabIndex = 150;
            this.tLine36.Text = "tLine11";
            // 
            // tLine38
            // 
            this.tLine38.BackColor = System.Drawing.Color.Transparent;
            this.tLine38.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine38.ForeColor = System.Drawing.Color.Black;
            this.tLine38.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine38.Location = new System.Drawing.Point(285, 4);
            this.tLine38.Name = "tLine38";
            this.tLine38.Size = new System.Drawing.Size(1, 49);
            this.tLine38.TabIndex = 148;
            this.tLine38.Text = "tLine9";
            // 
            // tLine39
            // 
            this.tLine39.BackColor = System.Drawing.Color.Transparent;
            this.tLine39.ForeColor = System.Drawing.Color.Black;
            this.tLine39.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine39.Location = new System.Drawing.Point(191, 4);
            this.tLine39.Name = "tLine39";
            this.tLine39.Size = new System.Drawing.Size(1, 49);
            this.tLine39.TabIndex = 147;
            this.tLine39.Text = "tLine8";
            // 
            // tLine28
            // 
            this.tLine28.BackColor = System.Drawing.Color.Transparent;
            this.tLine28.ForeColor = System.Drawing.Color.Black;
            this.tLine28.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine28.Location = new System.Drawing.Point(97, 4);
            this.tLine28.Name = "tLine28";
            this.tLine28.Size = new System.Drawing.Size(1, 49);
            this.tLine28.TabIndex = 173;
            this.tLine28.Text = "tLine1";
            // 
            // tLine30
            // 
            this.tLine30.BackColor = System.Drawing.Color.Transparent;
            this.tLine30.ForeColor = System.Drawing.Color.Black;
            this.tLine30.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine30.Location = new System.Drawing.Point(3, 4);
            this.tLine30.Name = "tLine30";
            this.tLine30.Size = new System.Drawing.Size(1, 49);
            this.tLine30.TabIndex = 171;
            this.tLine30.Text = "tLine20";
            // 
            // tLine31
            // 
            this.tLine31.BackColor = System.Drawing.Color.Transparent;
            this.tLine31.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine31.Location = new System.Drawing.Point(3, 4);
            this.tLine31.Name = "tLine31";
            this.tLine31.Size = new System.Drawing.Size(753, 10);
            this.tLine31.TabIndex = 170;
            this.tLine31.Text = "tLine19";
            // 
            // tLine37
            // 
            this.tLine37.BackColor = System.Drawing.Color.Transparent;
            this.tLine37.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine37.ForeColor = System.Drawing.Color.Black;
            this.tLine37.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine37.Location = new System.Drawing.Point(379, 4);
            this.tLine37.Name = "tLine37";
            this.tLine37.Size = new System.Drawing.Size(1, 49);
            this.tLine37.TabIndex = 149;
            this.tLine37.Text = "tLine10";
            // 
            // tLine40
            // 
            this.tLine40.BackColor = System.Drawing.Color.Transparent;
            this.tLine40.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine40.Location = new System.Drawing.Point(3, 52);
            this.tLine40.Name = "tLine40";
            this.tLine40.Size = new System.Drawing.Size(753, 10);
            this.tLine40.TabIndex = 146;
            this.tLine40.Text = "tLine7";
            // 
            // tLine42
            // 
            this.tLine42.BackColor = System.Drawing.Color.Transparent;
            this.tLine42.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine42.Location = new System.Drawing.Point(3, 28);
            this.tLine42.Name = "tLine42";
            this.tLine42.Size = new System.Drawing.Size(753, 10);
            this.tLine42.TabIndex = 135;
            this.tLine42.Text = "tLine4";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 597);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(930, 3);
            this.splitter1.TabIndex = 390;
            this.splitter1.TabStop = false;
            // 
            // Close_Timer
            // 
            this.Close_Timer.Tick += new System.EventHandler(this.Close_Timer_Tick);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // _MAKAU09110UA_Toolbars_Dock_Area_Right
            // 
            this._MAKAU09110UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU09110UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.GhostWhite;
            this._MAKAU09110UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKAU09110UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU09110UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(930, 29);
            this._MAKAU09110UA_Toolbars_Dock_Area_Right.Name = "_MAKAU09110UA_Toolbars_Dock_Area_Right";
            this._MAKAU09110UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 641);
            this._MAKAU09110UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            appearance62.BackColor = System.Drawing.Color.GhostWhite;
            this.ultraToolbarsManager1.Appearance = appearance62;
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(2, 194);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(659, 50);
            ultraToolbar1.IsMainMenuBar = true;
            controlContainerTool1.ControlName = "Delete_Button";
            controlContainerTool2.ControlName = "Close_Button";
            controlContainerTool2.InstanceProps.Width = 92;
            controlContainerTool3.ControlName = "New_Button";
            controlContainerTool3.InstanceProps.Width = 77;
            controlContainerTool4.ControlName = "Modify_Button";
            controlContainerTool4.InstanceProps.Width = 77;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1,
            controlContainerTool2,
            controlContainerTool3,
            controlContainerTool4});
            ultraToolbar1.Text = "標準";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            controlContainerTool5.ControlName = "Close_Button";
            controlContainerTool5.SharedProps.Caption = "Close_ControlContainerTool";
            controlContainerTool5.SharedProps.Width = 92;
            controlContainerTool6.ControlName = "New_Button";
            controlContainerTool6.SharedProps.Caption = "New_ControlContainerTool";
            controlContainerTool6.SharedProps.Width = 77;
            controlContainerTool7.ControlName = "Delete_Button";
            controlContainerTool7.SharedProps.Caption = "Delete_ControlContainerTool";
            controlContainerTool7.SharedProps.Visible = false;
            controlContainerTool8.ControlName = "Modify_Button";
            controlContainerTool8.SharedProps.Caption = "Modify_ControlContainerTool";
            controlContainerTool8.SharedProps.Width = 77;
            labelTool1.SharedProps.Spring = true;
            controlContainerTool9.ControlName = "Details_Button";
            controlContainerTool9.SharedProps.Caption = "Details_ControlContainerTool";
            controlContainerTool9.SharedProps.Width = 92;
            buttonTool1.SharedProps.Caption = "ButtonTool1";
            controlContainerTool10.SharedProps.Caption = "AddUpDateBase_ControlContainerTool";
            controlContainerTool10.SharedProps.Width = 169;
            labelTool2.SharedProps.Caption = "計上日付初期値";
            labelTool2.SharedProps.CustomizerCaption = "LabelTool";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool5,
            controlContainerTool6,
            controlContainerTool7,
            controlContainerTool8,
            labelTool1,
            controlContainerTool9,
            buttonTool1,
            controlContainerTool10,
            labelTool2});
            this.ultraToolbarsManager1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraToolbarsManager1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _MAKAU09110UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU09110UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU09110UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.GhostWhite;
            this._MAKAU09110UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU09110UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU09110UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
            this._MAKAU09110UA_Toolbars_Dock_Area_Left.Name = "_MAKAU09110UA_Toolbars_Dock_Area_Left";
            this._MAKAU09110UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 641);
            this._MAKAU09110UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _MAKAU09110UA_Toolbars_Dock_Area_Top
            // 
            this._MAKAU09110UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU09110UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.GhostWhite;
            this._MAKAU09110UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKAU09110UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU09110UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAKAU09110UA_Toolbars_Dock_Area_Top.Name = "_MAKAU09110UA_Toolbars_Dock_Area_Top";
            this._MAKAU09110UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(930, 29);
            this._MAKAU09110UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _MAKAU09110UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.GhostWhite;
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 670);
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom.Name = "_MAKAU09110UA_Toolbars_Dock_Area_Bottom";
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(930, 0);
            this._MAKAU09110UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // MAKAU09110UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(930, 670);
            this.Controls.Add(this.ViewButtonPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this.claim_panel);
            this.Controls.Add(this.Customer_Panel);
            this.Controls.Add(this._MAKAU09110UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAKAU09110UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAKAU09110UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAKAU09110UA_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.Name = "MAKAU09110UA";
            this.Text = "得意先実績修正";
            this.Load += new System.EventHandler(this.MAKAU09110UA_Load);
            this.Shown += new System.EventHandler(this.MAKAU09110UA_Shown);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.Five_Grid_Panel.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.Acc_Grid ) ).EndInit();
            this.First_StatusBar.ResumeLayout(false);
            this.ultraTabPageControl4.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.Dmd_Grid ) ).EndInit();
            this.Second_StatusBar.ResumeLayout(false);
            this.ViewButtonPanel.ResumeLayout(false);
            this.Customer_Panel.ResumeLayout(false);
            this.Customer_Panel.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SectionCode ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SecCode_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TargetDiv_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ClaimCode_tNedit ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.CustomerCode_tNedit ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraTabControl1 ) ).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.Bind_DataSet ) ).EndInit();
            this.claim_panel.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.tLine33 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine34 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine35 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine36 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine38 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine39 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine28 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine30 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine31 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine37 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine40 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine42 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraToolbarsManager1 ) ).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		// ===================================================================================== //
		// プライベートメンバー
		// ===================================================================================== //
		#region Private Members
		private bool        _underExtractionFlg                 = false;
		private bool        _detailFlg                          = false;

		private string[]    _tableNameList                      = new string[2];
		private string[]    _gridTitleList                      = new string[2];
		private int[]       _dataIndexList                      = new int[2];
		private bool[]      _canLogicalDeleteDataExtractionList = new bool[2];
		private bool[]      _defaultAutoFillToGridColumnList    = new bool[2];
		private Image[]     _gridIconList                       = new Image[2];
		private Hashtable[] _appearanceTable                    = new Hashtable[2];

		private bool        _changeFlg;
		//　企業コード
		private string      _enterpriseCode = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.29 TOKUNAGA ADD START
        // 自拠点コード
        private string      _loginSectionCode = "";

        // 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.29 TOKUNAGA ADD END

		private int         _sectionIndex   = -1;

        private CustomerInfoAcs _customerInfoAcs;

        private ProgramItemMAKAU09110U        _programItemObj;
		private TargetData                    _targetData;
		private IMasterMaintenanceAccDmdType  _arrayTypeObj;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        // 指定区分プルダウン選択項目値設定
        private const int   TARGET_DIV_CLAIM    = 0;
        private const int   TARGET_DIV_CUSTOMER = 1;

        // 管理営業所コード
        private string  _mngSectionCode;

        private int _targetClaimCode;
        private int _targetCustomerCode;
        private string _targetSectionCode;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

		private const int    FIRST_INDEX    = 0;
		private const int    SECOND_INDEX   = 1;
		private const int    CUSTOMER_INDEX = 2;
		// 全社拠点コード
		private const string ALLSECCODE     = "000000";

        private ControlScreenSkin _controlScreenSkin;   // 2009.01.06 Add
		
		#endregion

		# region enum TargetData
		/// <summary>操作対象データの列挙型です。</summary>
		private enum TargetData: int
		{
			/// <summary>１階層目</summary>
			First = 0,
			/// <summary>２階層目</summary>
			Second = 1,
		}
		# endregion


		# region Internal Methods
		/// <summary>
		/// グリッド列タイトルリスト取得処理
		/// </summary>
		/// <param name="dataList">データ項目リスト</param>
		/// <param name="colList1">TAB1グリッド列タイトルリスト</param>
		/// <param name="colList2">TAB2グリッド列タイトルリスト</param>
		/// <remarks>
		/// <br>Note       : 一覧表示用グリッドに表示されている列のタイトル(Key)を
		///					 ArrayListに格納して返します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void GetColKeyList(out ArrayList dataList, out ArrayList colList1,out ArrayList colList2)
		{
			dataList = new ArrayList();
			colList1 = new ArrayList();
			colList2 = new ArrayList();

			dataList.Add(this._gridTitleList[FIRST_INDEX]);
			dataList.Add(this._gridTitleList[SECOND_INDEX]);

			for (int i = 0; i < this.Acc_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				if (this.Acc_Grid.DisplayLayout.Bands[0].Columns[i].Hidden == false)
				{
					colList1.Add(this.Acc_Grid.DisplayLayout.Bands[0].Columns[i].Key.ToString());
				}
			}

			for (int i = 0; i < this.Dmd_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				if (this.Dmd_Grid.DisplayLayout.Bands[0].Columns[i].Hidden == false)
				{
					colList2.Add(this.Dmd_Grid.DisplayLayout.Bands[0].Columns[i].Key.ToString());
				}
			}
		}

		/// <summary>
		/// グリッドテキスト検索処理
		/// </summary>
		/// <param name="columnKey">グリッドの検索対象列名称</param>
		/// <param name="searchString">検索文字列</param>
		/// <param name="targetName">検索対象グリッド名称</param>
		/// <remarks>
		/// <br>Note       : 引数のcolumnKeyと一致する検索対象列を検索し、
		///					 検索文字列(searchString)に一致する行が存在した
		///					 場合はその行をアクティブにします。
		///					 引数のcolumnKeyと一致する列が存在しない場合は、
		///					 全ての列を検索対象とします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void GridTextSearch(string columnKey, string searchString, string targetName)
		{
			this.Cursor = Cursors.WaitCursor;
			bool checkFlg = false;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid;

			if (this._gridTitleList[FIRST_INDEX] == targetName)
			{
				targetGrid = this.Acc_Grid;
			}
			else
			{
				targetGrid = this.Dmd_Grid;
			}

			// 既にアクティブ行が存在する場合はその行から、そうでない場合は
			// 最初の行をアクティブに設定し、検索を開始する
			Infragistics.Win.UltraWinGrid.UltraGridRow oRow = targetGrid.ActiveRow;
			if (oRow == null)
			{
				oRow = targetGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);
			}

			// RowオブジェクトのGetSibling メソッドを使用して各行を繰り返し
			// チェックし、該当行をを検索する
			while (oRow != null)
			{
				oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

				if (this.MatchText(oRow, columnKey, searchString, targetGrid))
				{
					targetGrid.ActiveRow = oRow;
					targetGrid.ActiveRow.Selected = true;
					targetGrid.Refresh();

					checkFlg = true;
					break;
				}
			}

			if (!checkFlg)
			{
				oRow = targetGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);

				// リトライ
				while (oRow != null)
				{
					if (this.MatchText(oRow, columnKey, searchString, targetGrid))
					{
						targetGrid.ActiveRow = oRow;
						targetGrid.ActiveRow.Selected = true;
						targetGrid.Refresh();

						checkFlg = true;
						break;
					}

					oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
				}
			}

			this.Cursor = Cursors.Default;

			if (!checkFlg)
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"検索条件に一致するデータは見つかりません。",
					0,
					MessageBoxButtons.OK);
		}

		/// <summary>
		/// 画面終了処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面を終了させます。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		internal void ViewFormClose()
		{
			Close_Button_Click(this, null);
		}
		# endregion

		// ===================================================================================== //
		// 内部メソッド
		// ===================================================================================== //
		# region Private Methods

        /// <summary>画面初期処理</summary>
		/// <remarks>
		/// <br>Note       : 画面起動時の初期処理を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void InitialDisplay()
		{
			// ボタンのTagを設定する（Tagはボタンクリック処理の有効無効を示します）
			this.Close_Button.Tag   = true;
			this.New_Button.Tag     = true;
			this.Delete_Button.Tag  = true;
			this.Modify_Button.Tag  = true;
			this.Delete_Button.Tag  = true;
			this.Details_Button.Tag = true;

			// アイコンを表示する
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Close_Button.ImageList   = imageList16;
			this.New_Button.ImageList     = imageList16;
			this.Delete_Button.ImageList  = imageList16;
			this.Modify_Button.ImageList  = imageList16;
			this.Details_Button.ImageList = imageList16;

			this.Close_Button.Appearance.Image   = Size16_Index.CLOSE;
			this.New_Button.Appearance.Image     = Size16_Index.NEW;
			this.Delete_Button.Appearance.Image  = Size16_Index.DELETE;
			this.Modify_Button.Appearance.Image  = Size16_Index.MODIFY;
			this.Details_Button.Appearance.Image = Size16_Index.DETAILS;

			// 各マスタメンテナンスオブジェクトより設定値を取得する
			this._canLogicalDeleteDataExtractionList = this._arrayTypeObj.GetCanLogicalDeleteDataExtractionList();
			this._gridTitleList                      = this._arrayTypeObj.GetGridTitleList();
			this._gridIconList                       = this._arrayTypeObj.GetGridIconList();
			this._defaultAutoFillToGridColumnList    = this._arrayTypeObj.GetDefaultAutoFillToGridColumnList();

			this.New_Button.Visible    = this._arrayTypeObj.CanNew;
			this.Delete_Button.Visible = this._arrayTypeObj.CanDelete;
			this.ultraToolbarsManager1.Tools["New_ControlContainerTool"].SharedProps.Visible    = this._arrayTypeObj.CanNew;
			this.ultraToolbarsManager1.Tools["Delete_ControlContainerTool"].SharedProps.Visible = this._arrayTypeObj.CanDelete;

			// 拠点オプションが無い時には拠点情報の画面は表示しない
            if (this._arrayTypeObj.Opt_SectionInfo == true)
            {
                // 拠点オプションがない場合は拠点の変更を不可にする
                //this.SecCode_tComboEditor.Enabled = true;
                this.tNedit_SectionCode.Enabled = true;
                // 2009.01.14 >>>
                //this.tEdit_SectionName.Enabled = true;
                // 2009.01.14 <<<
                this.uButton_SectionGuide.Enabled = true;
                //// 本社機能以外は修正不可
                //if (this._arrayTypeObj.GetMainOfficeFuncMode == false)
                //{
                //    //this.SecCode_tComboEditor.Enabled = false;
                //    this.tNedit_SectionCode.Enabled = false;
                //    this.tEdit_SectionName.Enabled = false;
                //    this.uButton_SectionGuide.Enabled = false;
                //}
            }

			// イベントにメソッドを登録する
			this._arrayTypeObj.UnDisplaying += new MasterMaintenanceAccDmdTypeUnDisplayingEventHandler(this.MasterMaintenance_UnDisplaying);
			((Form)this._arrayTypeObj).VisibleChanged +=new EventHandler(this.SFCMN09000UE_VisibleChanged);

			// グリッドにバインドさせるデータセットを取得する			
			DataSet bindDataSet = new DataSet();
			this._arrayTypeObj.GetBindDataSet(ref bindDataSet, ref this._tableNameList);
			this.Bind_DataSet = bindDataSet;

		}

		/// <summary>データビュー用グリッド初期設定処理</summary>
		/// <remarks>
		/// <br>Note       : グリッドの初期設定を行います。
		///					 （表示非表示、表示横位置、フォーマット、フォント色、フィルタ）</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void GridInitialSetting()
		{
            // TAB1のグリッドの設定
            GridSetting(FIRST_INDEX, Acc_Grid, TargetData.First);
            this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]].Columns[CustAccRecDmdPrcAcs.COL_AFCALTMONTHACCREC_TITLE].Caption = "売掛残高";

            // TAB2のグリッドの設定
            GridSetting(SECOND_INDEX, Dmd_Grid, TargetData.Second);
            this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]].Columns[CustAccRecDmdPrcAcs.COL_AFCALDEMANDPRICE_TITLE].Caption = "請求残高";
        }

        /// <summary>データビュー用グリッド設定処理</summary>
        /// <remarks>
        /// <br>Note       : グリッドの設定を行います(表示非表示、表示横位置、フォーマット、フォント色、フィルタ)</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void GridSetting(int tabIndex, Infragistics.Win.UltraWinGrid.UltraGrid tagetGrid, TargetData targetIndex)
        {
            for (int i = 0; i < this.Bind_DataSet.Tables[this._tableNameList[tabIndex]].Columns.Count; i++)
            {
                GridColAppearance appearance = (GridColAppearance)this._appearanceTable[tabIndex][this.Bind_DataSet.Tables[this._tableNameList[tabIndex]].Columns[i].ColumnName];

                // グリッド列の表示非表示設定処理
                this.GridColHidden(i, appearance.GridColDispType, targetIndex);

                // 値の表示横位置を設定する
                switch (appearance.CellTextAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.BottomLeft:
                        {
                            tagetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                            break;
                        }
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.BottomCenter:
                        {
                            tagetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                            break;
                        }
                    case ContentAlignment.TopRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.BottomRight:
                        {
                            tagetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                            break;
                        }
                }

                // 値のフォーマットを設定する
                if ((appearance.Format != "") && (appearance.Format != null))
                {
                    tagetGrid.DisplayLayout.Bands[0].Columns[i].Format = appearance.Format;
                }

                // 列のフォント色を設定する
                tagetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.ForeColor = appearance.ColFontColor;

                // グリッドのフィルタリング処理
                AddGridFiltering(targetIndex);
            }
        }

            
            
        /// <summary>グリッド列の表示非表示設定処理</summary>
		/// <param name="colDispType">グリッド列の表示タイプ</param>
		/// <param name="index">グリッド列のインデックス</param>
		/// <param name="targetData">制御対象グリッド名称</param>
		/// <remarks>
		/// <br>Note       : グリッド列の表示非表示設定を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void GridColHidden(int index, MGridColDispType colDispType, TargetData targetData)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = null;

			switch (targetData)
			{
				case (TargetData.First):
				{
					targetGrid = this.Acc_Grid;
					break;
				}
				case (TargetData.Second):
				{
					targetGrid = this.Dmd_Grid;
					break;
				}
			}

			switch (colDispType)
			{
				case MGridColDispType.None:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					break;
				}
				case MGridColDispType.Both:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					break;
				}
				case MGridColDispType.ListOnly:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					break;
				}
				case MGridColDispType.DetailsOnly:
				{
					if (this._detailFlg == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataBoth:
				{
					if (targetCheckEditor.Checked == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataListOnly:
				{
					if (targetCheckEditor.Checked == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataDetailsOnly:
				{
					if (targetCheckEditor.Checked == true)
					{
						if (this._detailFlg == true)
						{
							targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
						}
						else
						{
							targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
						}
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				default:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					break;
				}
			}
		}

		/// <summary>グリッドのフィルタリング処理</summary>
		/// <remarks>
		/// <br>Note       : グリッド列のフィルタリングを行います。
		///					 初期起動時に、削除データをフィルタリングします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AddGridFiltering(TargetData targetData)
		{
			int index = -1;
			string tableName = "";
			Hashtable appearanceTable;
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = null;
			
			switch (targetData)
			{
				case TargetData.First:
				{
					tableName = this._tableNameList[FIRST_INDEX];
					targetGrid = this.Acc_Grid;
					appearanceTable = this._appearanceTable[FIRST_INDEX];

					break;
				}
				case TargetData.Second:
				{
					tableName = this._tableNameList[SECOND_INDEX];
					targetGrid = this.Dmd_Grid;
					appearanceTable = this._appearanceTable[SECOND_INDEX];

					break;
				}
				default:
				{
					return;
				}
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
			{
                GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];

				if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataListOnly) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataDetailsOnly))
				{
					index = i;
					break;
				}
			}	

			if (index >= 0)
			{
				// 行フィルタがバンドに基づいている場合、バンドの列フィルタを外す。
				Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = targetGrid.DisplayLayout.Bands[0].ColumnFilters;
				columnFilters.ClearAllFilters();

				if (targetCheckEditor.Checked == false)
				{
					// 空白とNull以外をフィルタに設定する
					columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
					columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
					columnFilters[index].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
				}
			}
		}

		/// <summary>テキスト一致チェック処理</summary>
		/// <param name="userString">検索文字列</param>
		/// <param name="cellValue">検索対象セル値</param>
		/// <remarks>
		/// <br>Note       : グリッドのセル値と引数が一致するかどうかをチェックします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool Match(string userString, string cellValue)
		{
			// 文字列を両方とも大文字に変換する
			userString = userString.ToUpper();
			cellValue = cellValue.ToUpper();

			// セル値よりもユーザー検索文字列が大きい場合は、不一致なので
			// Falseを戻す
			if (userString.Length > cellValue.Length)
			{
				return false;
			}
			else if (userString.Length == cellValue.Length)
			{
				// 長さが一致する場合、文字列も一致する
				if (userString == cellValue)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				for ( int i = 0; i <= (cellValue.Length - userString.Length); i++ )
				{
					if (userString == cellValue.Substring(i, userString.Length))
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <summary>テキスト一致行存在チェック処理</summary>
		/// <param name="oRow">検索対象グリッド行</param>
		/// <param name="columnKey">検索対象グリッド列名</param>
		/// <param name="searchString">検索文字列</param>
		/// <param name="targetGrid">検索対象グリッド</param>
		/// <remarks>
		/// <br>Note       : 引数の行に対して、検索対象列のセルの値と一致する
		///					 かどうかをチェックします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool MatchText(Infragistics.Win.UltraWinGrid.UltraGridRow oRow, string columnKey, string searchString, Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
		{
			if (oRow == null)
			{
				return false;
			}

			// 選択されている列を検索するのか全ての列を検索するのかを確認する
			bool bSearchAllColumns = true;
			if (targetGrid.DisplayLayout.Bands[0].Columns.Exists(columnKey))
			{
				bSearchAllColumns = false;
			}

			// 全ての列を検索する場合、行の全てのセルを一つ一つ検索する
			// この場合Bands.Columnsコレクションを使用し、効率化を図る
			if (bSearchAllColumns)
			{
				foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn oCol in targetGrid.DisplayLayout.Bands[0].Columns)
				{
					if (!oCol.IsVisibleInLayout) continue;

					if ((oRow.Cells[oCol.Key].Value != null) && (oRow.IsFilteredOut == false))
					{
						if (this.Match(searchString, oRow.Cells[oCol.Key].Value.ToString()))
						{
							return true;
						}
					}
				}
			}
			else
			{
				Infragistics.Win.UltraWinGrid.UltraGridColumn oCol = targetGrid.DisplayLayout.Bands[0].Columns[columnKey];
				if ((oRow.Cells[oCol.Key].Value != null ) && (oRow.IsFilteredOut == false))
				{
					if (this.Match(searchString, oRow.Cells[oCol.Key].Value.ToString()))
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>ステータスバー件数表示処理</summary>
		/// <remarks>
		/// <br>Note       : ステータスバーにグリッドの行数を表示します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void StatusBarCountIndication()
		{
			this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text  = this.Acc_Grid.Rows.FilteredInRowCount.ToString()  + "件";
			this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = this.Dmd_Grid.Rows.FilteredInRowCount.ToString() + "件";
		}

		/// <summary>グリッドアクティブ行設定処理</summary>
		/// <param name="targetGrid">操作対象Grid</param>
		/// <remarks>
		/// <br>Note       : グリッドのアクティブ行を検索し、選択状態にします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void SetActiveRow(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
		{
			if (targetGrid.ActiveRow != null)
			{
				bool setFlg = false;
				Infragistics.Win.UltraWinGrid.UltraGridRow nextRow = targetGrid.ActiveRow;
				while (nextRow != null)
				{
					if (nextRow.IsFilteredOut)
					{
						int index = nextRow.Index;

						// 選択行がフィルタリングされている場合Next行を選択
						nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

						// インデックスが同じ場合は、次が存在しないと判断してbreak
						if ((nextRow != null) && (index == nextRow.Index))
						{
							break;
						}
					}
					else
					{
						targetGrid.ActiveRow = nextRow;
						targetGrid.ActiveRow.Selected = true;
						setFlg = true;
						break;
					}
				}

				if (setFlg == false)
				{
					// 該当する行が存在しない場合は、最初から再度Next検索
					nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First);
					while (nextRow != null)
					{
						if (nextRow.IsFilteredOut)
						{
							int index = nextRow.Index;

							// 選択行がフィルタリングされている場合Next行を選択
							nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

							// インデックスが同じ場合は、次が存在しないと判断してbreak;
							if ((nextRow != null) && (index == nextRow.Index))
							{
								break;
							}
						}
						else
						{
							targetGrid.ActiveRow = nextRow;
							targetGrid.ActiveRow.Selected = true;
							break;
						}
					}
				}
			}
			else if (targetGrid.Rows.Count > 0)
			{
				if (targetGrid.Rows[0] != null)
				{
					targetGrid.ActiveRow = targetGrid.Rows[0];
					targetGrid.ActiveRow.Selected = true;
				}
			}
		}

		/// <summary>画面非表示イベント用メソッド</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="me">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : マスタメンテナンスの画面非表示イベント用メソッドです。
		///					 ツリーチェックボックスのチェック処理を実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MasterMaintenance_UnDisplaying(object sender, MasterMaintenanceUnDisplayingEventArgs me)
		{
			// 引数のDialogResultがOKまたはYesの場合は、ノードのチェックボックスにチェックを付ける
			if ((me.DialogResult == DialogResult.OK) || (me.DialogResult == DialogResult.Yes))
			{
				this.StatusBarCountIndication();
			}
			else
			{
				switch(this._targetData)
				{
					case (TargetData.First):
					{
						CurrencyManager cm = (CurrencyManager)BindingContext[this.Acc_Grid.DataSource];
						this._dataIndexList[FIRST_INDEX] = cm.Position;	
						break;
					}
					case (TargetData.Second):
					{
						CurrencyManager cm = (CurrencyManager)BindingContext[this.Dmd_Grid.DataSource];
						this._dataIndexList[SECOND_INDEX] = cm.Position;	
						break;
					}
				}
			}
			switch(this._targetData)
			{
				case (TargetData.First):
				{
					// グリッドアクティブ行設定処理
					this.SetActiveRow(this.Acc_Grid);

					break;
				}
				case (TargetData.Second):
				{
					// グリッドアクティブ行設定処理
					this.SetActiveRow(this.Dmd_Grid);
					break;
				}
			}
		}

		/// <summary>画面表示変更後発生イベント用メソッド</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 子画面のVisibleが変更になった後に発生します。
		///					 ボタンの有効無効チェックを行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void SFCMN09000UE_VisibleChanged(object sender, EventArgs e)
		{
			this.Details_Button.Visible = false;
			if (((Form)this._arrayTypeObj).Visible == true)
			{
				this.Close_Button.Enabled   = false;
				this.New_Button.Enabled     = false;
				this.Modify_Button.Enabled  = false;
				this.Details_Button.Enabled = false;
			}
			else
			{
				this.Close_Button.Enabled   = true;
				this.New_Button.Enabled     = true;
				this.Modify_Button.Enabled  = true;
				this.Details_Button.Enabled = true;

				this.ButtonEnabledControl(this._targetData);
			}
		}

		/// <summary>ボタン有効無効制御処理</summary>
		/// <param name="targetData">操作対象グリッド</param>
		/// <remarks>
		/// <br>Note       : ボタンの有効無効制御を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ButtonEnabledControl(TargetData targetData)
		{
			bool[] newEnabled    = this._arrayTypeObj.GetNewButtonEnabledList();
			bool[] modifyEnabled = this._arrayTypeObj.GetModifyButtonEnabledList();

			switch(targetData)
			{
				case (TargetData.First):
				{
					this.New_Button.Enabled = newEnabled[0];
					this.Modify_Button.Enabled = modifyEnabled[0];

					break;
				}
				case (TargetData.Second):
				{
					this.New_Button.Enabled = newEnabled[1];
					this.Modify_Button.Enabled = modifyEnabled[1];
					break;
				}
			}

			this.New_Button.Tag    = this.New_Button.Enabled;
			this.Modify_Button.Tag = this.Modify_Button.Enabled;
		}

		/// <summary>削除データチェック処理</summary>
		/// <returns>true:削除可能 false:削除不可</returns>
		/// <remarks>
		/// <br>Note       : 削除データの削除済みチェックを行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool DeleteDataCheck(TargetData targetData)
		{
			bool ret = true;
			int index = -1;

			string tableName = "";
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Hashtable appearanceTable;

			switch (targetData)
			{
				case (TargetData.First):
				{
					tableName = this._tableNameList[FIRST_INDEX];
					targetGrid = this.Acc_Grid;
					appearanceTable = this._appearanceTable[FIRST_INDEX];
					break;
				}
				case (TargetData.Second):
				{
					tableName = this._tableNameList[SECOND_INDEX];
					targetGrid = this.Dmd_Grid;
					appearanceTable = this._appearanceTable[SECOND_INDEX];
					break;
				}
				default:
				{
					return ret;
				}
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
			{
                GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];

				if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataListOnly) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataDetailsOnly))
				{
					index = i;
					break;
				}
			}	

			if (index >= 0)
			{
				if (targetGrid.ActiveRow.Cells[index].Text.Trim() != "") ret = false;
			}

			return ret;
		}

		/// <summary>画面初期設定処理</summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
            //// 拠点情報をコンボに設定
            //this.SecCode_tComboEditor.Clear();
            ArrayList retSecInfSetList = new ArrayList();
            this._arrayTypeObj.SecInf_Search(out retSecInfSetList);

            //this.SecCode_tComboEditor.Items.Add(ALLSECCODE, "全社");

            //foreach(SecInfoSet secInfSet in retSecInfSetList)
            //{
            //    this.SecCode_tComboEditor.Items.Add(secInfSet.SectionCode,secInfSet.SectionGuideNm);
			
            //    if ( this._arrayTypeObj.GetCompanySectionCode == secInfSet.SectionCode )
            //        this._sectionIndex = this.SecCode_tComboEditor.Items.Count -1;
			
            //}
            //// 起動時は自拠点を初期値とする
            //this.SecCode_tComboEditor.SelectedIndex = this._sectionIndex;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            // 起動時は指定区分は0[請求先]
            this.TargetDiv_tComboEditor.SelectedIndex = TARGET_DIV_CLAIM;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.29 TOKUNAGA ADD START
            // 拠点情報にログインユーザーの自拠点情報をセット
            this.tNedit_SectionCode.Text = this._loginSectionCode.TrimEnd();

            // 拠点名を取得
            ResearchFromSectionCode(false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.29 TOKUNAGA ADD END
        }

		/// <summary>画面クリア処理</summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenClear()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.29 TOKUNAGA ADD START
            // 拠点情報が参照のみの時はクリアしない
            if (this._arrayTypeObj.Opt_SectionInfo == false)
            {
                this.tNedit_SectionCode.Clear();
                // 2009.01.14 >>>
                //this.tEdit_SectionName.Clear();
                this.SectionName_Label.Text = string.Empty;
                // 2009.01.14 <<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.29 TOKUNAGA ADD END

			// 得意先情報（コード・名称・締日)
			this.CustomerCode_tNedit.Clear();
			this.CustomerName_Label.Text = "";
			this.CustomerName2_Label.Text = "";
			this.TotalDay_Label.Text      = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.ClaimCode_tNedit.Clear();
            this.ClaimName_Label.Text = "";
            this.ClaimName2_Label.Text = "";
            this.ClaimSnm_Label.Text = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// 売掛・請求のList
			// 拠点オプションが無い場合、本社機能ではない場合は、自拠点を常に設定
            if ((this._arrayTypeObj.Opt_SectionInfo == true) && (this._arrayTypeObj.GetMainOfficeFuncMode == true))
            {
                this.SecCode_tComboEditor.SelectedIndex = -1;
            }
            else
            {
                this.SecCode_tComboEditor.SelectedIndex = this._sectionIndex;
            }

            this._dataIndexList[FIRST_INDEX]  = 0;
            this._dataIndexList[SECOND_INDEX] = 0;
            this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
            
            this.Bind_DataSet.Tables[FIRST_INDEX].Clear();
			this.Bind_DataSet.Tables[SECOND_INDEX].Clear();

			// 詳細画面鑑情報クリア
			claim_panel_Clear();

			this._changeFlg = false;
		}

        /// <summary>鑑画面のクリア処理</summary>
		/// <remarks>
		/// <br>Note       : 鑑画面をクリアします。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void claim_panel_Clear()
		{
			// 詳細画面情報クリア(鑑項目)
			
			this.Ttl3TmDmd_Label.Text     = "";     // 3回以前残高
			this.Ttl2TmDmd_Label.Text     = "";     // 2回以前残高
			this.TtlLMBlDmd_Label.Text    = "";     // 前回残高
			this.TtlSalesDmd_Label.Text   = "";     // 今回売上
            this.TtlConsTaxDmd_Label.Text = "";     // 消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.TtlPayDmd_Label.Text     = "";     // 今回支払
            //this.TtlPayTaxDmd_Label.Text  = "";     // 支払消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            TtlBalanceAdjust_Label.Text   = "";     // 残高調整額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.TtlDepoDmd_Label.Text    = "";     // 今回入金
			this.TtlBlDmd_Label.Text      = "";     // 残高
		}

		/// <summary>得意先クラス画面展開処理</summary>
        /// <param name="customerRet">得意先オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 得意先オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void CustomerToScreen(CustomerSearchRet customerRet)
		{
            this.CustomerCode_tNedit.SetInt(customerRet.CustomerCode);
            this.CustomerName_Label.Text = customerRet.Name;
            this.CustomerName2_Label.Text = customerRet.Name2;
            this.CustomerSnm_Label.Text = customerRet.Snm;
            this.TotalDay_Label.Text = customerRet.TotalDay.ToString();
		}
	
		/// <summary>鑑情報展開処理</summary>
		/// <param name="sender">オブジェクト</param>
		/// <remarks>
		/// <br>Note			:   指定された行の情報を鑑に展開します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void claim_panelInfoSet(object sender)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            if (targetGrid.ActiveRow == null)
            {
                // 全てクリア
                Ttl3TmDmd_Label.Text = string.Empty;
                Ttl2TmDmd_Label.Text = string.Empty;
                TtlLMBlDmd_Label.Text = string.Empty;
                TtlSalesDmd_Label.Text = string.Empty;
                TtlConsTaxDmd_Label.Text = string.Empty;
                TtlBalanceAdjust_Label.Text = string.Empty;
                TtlDepoDmd_Label.Text = string.Empty;
                TtlBlDmd_Label.Text = string.Empty;
                return;
            }

			int rowIndex = targetGrid.ActiveRow.Index;

			string[] textList = null;
			this._arrayTypeObj.ReadTabelData_claim_panelSet(out textList);
            if (textList == null)
            {
                return;
            }

			// 画面情報に反映
			Ttl3TmDmd_Label.Text     = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[0]].Value, true);    // ３回以前残高
			Ttl2TmDmd_Label.Text     = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[1]].Value, true);    // ２回以前残高
			TtlLMBlDmd_Label.Text    = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[2]].Value, true);    // 前回残高
			TtlSalesDmd_Label.Text   = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[3]].Value, true);    // 今回売上
            TtlConsTaxDmd_Label.Text = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[4]].Value, true);    // 消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //TtlPayDmd_Label.Text     = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[5]].Value, true);    // 今回支払
            //TtlPayTaxDmd_Label.Text  = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[6]].Value, true);    // 支払消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            TtlBalanceAdjust_Label.Text = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_BALANCEADJUST_TITLE].Value + (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_TAXADJUST_TITLE].Value, true); // 残高調整額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Int64 totalDepoDmd = (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEDMDNRML_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDNRML_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDNRML_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDNRML_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEDMDDEPO_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDDEPO_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDDEPO_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMERBTDMDDEPO_TITLE].Value;
            Int64 totalDepoDmd = (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEDMDNRML_TITLE].Value +
                                 (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEFEEDMDNRML_TITLE].Value +
                                 (Int64)targetGrid.ActiveRow.Cells[CustAccRecDmdPrcAcs.COL_THISTIMEDISDMDNRML_TITLE].Value;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            TtlDepoDmd_Label.Text    = this._arrayTypeObj.Claim_panelDataFormat(totalDepoDmd, true);                                            // 今回入金
            TtlBlDmd_Label.Text = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[8]].Value, true);    // 売掛残高
		}
		# endregion

		// ===================================================================================== //
		// コントロールイベント
		// ===================================================================================== //
		#region Control Events

        /// <summary>Form.Load イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09110UA_Load(object sender, System.EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.29 TOKUNAGA ADD START
            // アクセスクラス取得
            this._secInfoSetAcs = new SecInfoSetAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.29 TOKUNAGA ADD END

			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList16 = IconResourceManagement.ImageList16;
            // 得意先ガイドボタン
			this.Customer_Guide_Button.ImageList = imageList16;
			this.Customer_Guide_Button.Appearance.Image = Size16_Index.STAR1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.29 TOKUNAGA ADD START
            // 拠点ガイドボタン
            this.uButton_SectionGuide.ImageList = imageList16;
            this.uButton_SectionGuide.Appearance.Image = Size16_Index.STAR1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.29 TOKUNAGA ADD END

            this._programItemObj = new ProgramItemMAKAU09110U(" ", 
                                                              "MAKAU09110U.DLL",
                                                              "Broadleaf.Windows.Forms.MAKAU09110UB",
                                                              "得意先実績修正",
                                                              ProgramPatternMAKAU09110U.Multi);
			
			string AssemblyID = this._programItemObj.AssemblyID;
			string ClassID    = this._programItemObj.ClassID;

			Assembly assmbly = Assembly.LoadFrom(AssemblyID);
			System.Type type = assmbly.GetType(ClassID);

			this._programItemObj.ClassType  = type;
			this._programItemObj.Object     = Activator.CreateInstance(type);
			this._programItemObj.CustomForm = (Form)this._programItemObj.Object;

			this._arrayTypeObj = (IMasterMaintenanceAccDmdType)this._programItemObj.CustomForm;

            // 拠点情報取得
            ScreenInitialSetting();
            
            this.InitialDisplay();
            
            // データの抽出処理を実行する
			int totalCount = 0;
			// 得意先情報の取得
			int status = this._arrayTypeObj.CustomerData_Search(ref totalCount, 0);

			switch (status)
			{
				case 0:
				{
					break;
				}
				case 9:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP,
						          this.Name,
						          "読み込みに失敗しました。",
						          status,
						          MessageBoxButtons.OK);
					return;
				}
			}

			this.Acc_Grid.DataSource = this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]];
			this.Dmd_Grid.DataSource = this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]];

			this._arrayTypeObj.GetAppearanceTable(out this._appearanceTable);
			this.GridInitialSetting();

			this._arrayTypeObj.GetDisPlayDisplayLayoutTable(ref Acc_Grid ,this._tableNameList[FIRST_INDEX]);
			this._arrayTypeObj.GetDisPlayDisplayLayoutTable(ref Dmd_Grid ,this._tableNameList[SECOND_INDEX]);

			this.AutoFillToFirstGridColumn_CheckEditor.Checked  = false;
			this.AutoFillToFirstGridColumn_CheckEditor.Checked  = this._defaultAutoFillToGridColumnList[FIRST_INDEX];
            
			this.AutoFillToSecondGridColumn_CheckEditor.Checked = false;
			this.AutoFillToSecondGridColumn_CheckEditor.Checked = this._defaultAutoFillToGridColumnList[SECOND_INDEX];

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.28 TOKUNAGA ADD START
            // 背景色が理由なく変更されることへの対応（暫定）→原因不明
            // 親コンテナの背景色をデザイナで同じにしても、実行時には変わってしまう
            this.AutoFillToSecondGridColumn_CheckEditor.Parent.BackColor = this.AutoFillToFirstGridColumn_CheckEditor.Parent.BackColor;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.28 TOKUNAGA ADD END

			this.ActiveControl = this.CustomerCode_tNedit;

			if (this.Acc_Grid.Rows.Count > 0)
			{
				this.Acc_Grid.ActiveRow = this.Acc_Grid.Rows[0];
				this.Acc_Grid.ActiveRow.Selected = true;
			}

			if (this.Dmd_Grid.Rows.Count > 0)
			{
				this.Dmd_Grid.ActiveRow = this.Dmd_Grid.Rows[0];
				this.Dmd_Grid.ActiveRow.Selected = true;
			}	

			this._targetData = TargetData.First;
            // 詳細情報の名称切り替えの為追加
            ultraTabControl1_Click(sender, null);

            //ScreenClear();

            // メッセージ出す
            this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
            this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";

            // 2009.01.06 Add >>>
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // 2009.01.06 Add <<<
		}

		/// <summary>Acc_Grid_AfterRowActivate イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note	   : 行がアクティブになった後に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_AfterRowActivate(object sender, System.EventArgs e)
		{
			// 指定された行情報の鑑を作成します。	
			claim_panelInfoSet(sender);
		}

        /// <summary>ダブルクリックされた時に発生する イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ダブルクリックされた時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_DoubleClick(object sender, System.EventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			
			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
			objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

			objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// ヘッダ部の場合は以下の処理をキャンセルする
			if(objRowCellAreaUIElement == null)
			{
				return;
			}
			// 修正画面を起動する
			Modify_Button_Click(Modify_Button, e);
		}

        /// <summary>解除 イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : セルが非アクティブになる前に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_BeforeRowDeactivate(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cl in targetGrid.ActiveRow.Cells)
			{
				cl.Appearance  = null;
			}
		}

		/// <summary>Control.ChangeFocus イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォーカス移動時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null) return;
			if (e.NextCtrl == null) return;

            // 2008.11.18 add start [7894]
            switch (e.Key)
            {
                case Keys.Return:
                case Keys.Tab:
                case Keys.Down:
                    {
                        switch (e.PrevCtrl.Name)
                        {
                            case "tNedit_SectionCode":
                                {
                                    if (String.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
                                    {
                                        // 2008.11.25 add start [8221]
                                        // 2009.01.14 >>>
                                        //this.tEdit_SectionName.Clear();
                                        this.SectionName_Label.Text = string.Empty;
                                        // 2009.01.14 <<<
                                        // 2008.11.25 add end [8221]
                                        e.NextCtrl = this.uButton_SectionGuide;
                                    }
                                    else
                                    {
                                        ResearchFromSectionCode(false);
                                        e.NextCtrl = this.CustomerCode_tNedit;
                                    }
                                    break;
                                }
                            case "uButton_SectionGuide":
                                {
                                    e.NextCtrl = this.CustomerCode_tNedit;
                                    break;
                                }
                            case "CustomerCode_tNedit":
                                {
                                    if (String.IsNullOrEmpty(this.CustomerCode_tNedit.Text.Trim()))
                                    {
                                        e.NextCtrl = this.Customer_Guide_Button;
                                    }
                                    else
                                    {
                                        if (ultraTabControl1.ActiveTab.Key == "campanyTab")
                                        {
                                            if (this.Acc_Grid.Rows.Count > 0) e.NextCtrl = this.Acc_Grid;
                                            else e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
                                        }
                                        else
                                        {
                                            if (this.Dmd_Grid.Rows.Count > 0) e.NextCtrl = this.Dmd_Grid;
                                            else e.NextCtrl = this.AutoFillToSecondGridColumn_CheckEditor;
                                        }
                                    }
                                    break;
                                }
                            case "Customer_Guide_Button":
                                {
                                    if (ultraTabControl1.ActiveTab.Key == "campanyTab")
                                    {
                                        if (this.Acc_Grid.Rows.Count > 0) e.NextCtrl = this.Acc_Grid;
                                        else e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
                                    }
                                    else
                                    {
                                        if (this.Dmd_Grid.Rows.Count > 0) e.NextCtrl = this.Dmd_Grid;
                                        else e.NextCtrl = this.AutoFillToSecondGridColumn_CheckEditor;
                                    }
                                    break;
                                }
                            case "TargetDiv_tComboEditor":
                                {
                                    if (this.tNedit_SectionCode.Enabled)
                                    {
                                        e.NextCtrl = this.tNedit_SectionCode;
                                    }
                                    else
                                    {
                                        // 2008.11.20 modify start [7958]
                                        //e.NextCtrl = this.CustomerCode_tNedit;
                                        e.NextCtrl = this.tNedit_SectionCode;
                                        // 2008.11.20 modify end [7958]
                                    }
                                    break;
                                }
                            case "AutoFillToFirstGridColumn_CheckEditor":
                                {
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                    break;
                                }
                            case "AutoFillToSecondGridColumn_CheckEditor":
                                {
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                    break;
                                }
                            case "Acc_Grid":
                                {
                                    e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
                                    break;
                                }
                            case "Dmd_Grid":
                                {
                                    e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        switch (e.PrevCtrl.Name)
                        {
                            // 拠点コード
                            case "tNedit_SectionCode":
                                {
                                    // 指定区分へ
                                    if (!String.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
                                    {
                                        ResearchFromSectionCode(true);
                                    }
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                // 2008.11.17 add end [7894]
                default: break;
            }
            // 2008.11.17 del start [7894]
            //if ( e.PrevCtrl == this.CustomerCode_tNedit )
            //{
            //    if (e.Key == Keys.Return)
            //    {
            //        if (this.CustomerCode_tNedit.GetValue() != 0)
            //        {
            //            switch (ultraTabControl1.ActiveTab.Key)
            //            {
            //                case "campanyTab":
            //                    {
            //                        if (this.Acc_Grid.Rows.Count > 0)
            //                        {
            //                            e.NextCtrl = this.Acc_Grid;
            //                        }
            //                        else
            //                        {
            //                            e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
            //                        }
            //                    }
            //                    break;
            //                case "customerTab":
            //                    {
            //                        if (this.Dmd_Grid.Rows.Count > 0)
            //                        {
            //                            e.NextCtrl = this.Dmd_Grid;
            //                        }
            //                        else
            //                        {
            //                            e.NextCtrl = this.AutoFillToSecondGridColumn_CheckEditor;
            //                        }
            //                        break;
            //                    }
            //                default:
            //                    {
            //                        return;
            //                    }
            //            }
            //        }
            //        else if (this.CustomerCode_tNedit.GetValue() == 0)
            //        {
            //            e.NextCtrl = this.Customer_Guide_Button;
            //        }
            //    }
            //}
            // 2008.11.17 del end [7894]

			if ((e.PrevCtrl == this.Acc_Grid) || (e.PrevCtrl == this.Dmd_Grid))
			{
                if (e.Key == Keys.Return)
                {
                    switch (ultraTabControl1.ActiveTab.Key)
                    {
                        case "campanyTab":
                            {
                                if (this.Acc_Grid.Rows.Count > 0)
                                {
                                    KeyEventArgs k = new KeyEventArgs(e.Key);
                                    this.Acc_Grid_KeyDown(sender, k);
                                    //e.NextCtrl = this.Acc_Grid;
                                }
                                else
                                {
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                }
                                break;

                            }
                        case "customerTab":
                            {
                                if (this.Dmd_Grid.Rows.Count > 0)
                                {
                                    KeyEventArgs k = new KeyEventArgs(e.Key);
                                    this.Acc_Grid_KeyDown(sender, k);
                                    //e.NextCtrl = this.Dmd_Grid;
                                }
                                else
                                {
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                }
                                break;
                            }
                        default:
                            {
                                return;
                            }
                    }
                }
	
			}	
		}

        // 2008.11.17 add start [7894]
        /// <summary>
        /// 拠点コードからフォーカスを移送した際に再検索する
        /// </summary>
        private void ResearchFromSectionCode(bool moveUpward)
        {
            // 拠点コード入力値を取得
            int sectionCd = this.tNedit_SectionCode.GetInt();
            string sectionCode = this.tNedit_SectionCode.Text.Trim().PadLeft(2, '0');

            // 拠点コードが入力されている場合のみ変換
            if (String.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
            {
                this.tNedit_SectionCode.Clear();
                // 2009.01.14 >>>
                //this.tEdit_SectionName.Clear();
                this.SectionName_Label.Text = string.Empty;
                // 2009.01.14 <<<
                this.tNedit_SectionCode.Focus();
                return;
            }
            else
            {
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (sectionInfo.LogicalDeleteCode == 0))
                {
                    // 2008.11.25 modify start [8221]
                    // 2009.01.14 >>>
                    //this.tEdit_SectionName.Text = sectionInfo.SectionGuideSnm.TrimEnd();
                    this.SectionName_Label.Text = sectionInfo.SectionGuideNm.TrimEnd();
                    // 2009.01.14 <<<
                    // 2008.11.25 modify end [8221]

                    if (!String.IsNullOrEmpty(this.CustomerCode_tNedit.Text.Trim()))
                    {
                        this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "";
                        this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "";
                    }
                }
                else
                {
                    TMsgDisp.Show( this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                    "入力された拠点は存在しません。", -1, MessageBoxButtons.OK);
                    this.tNedit_SectionCode.Clear();
                    // 2009.01.14 >>>
                    //this.tEdit_SectionName.Clear();
                    this.SectionName_Label.Text = string.Empty;
                    // 2009.01.14 <<<
                    this.tNedit_SectionCode.Focus();
                    return;
                }
            }
        }
        // 2008.11.18 add end [7894]

		/// <summary>SecCode_tComboEditor_ValueChangedイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 選択データが変更された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void SecCode_tComboEditor_ValueChanged(object sender, System.EventArgs e)
		{
			// 選択顧客の売掛・請求の前情報を取得する
			if ( this.SecCode_tComboEditor.SelectedIndex == -1 ) return;
			// 表示拠点を変更されたら指定された拠点の売掛・請求情報を表示する
			// 現在選択されている拠点の情報を取得する
    		string secCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
            
			Form customForm = (Form)this._arrayTypeObj;
            MAKAU09110UB mForm = (MAKAU09110UB)customForm;
            mForm.MngSectionCode = secCode;
            mForm.SectionCodeData = secCode;

			if ((this._arrayTypeObj.SectionCodeData != secCode ) && (customForm.Visible == true))
			{
				customForm.Hide();
			}
			
			// 鑑情報の画面情報のクリア
			claim_panel_Clear();

			if ( this.CustomerCode_tNedit.GetInt() != 0 )
			{
				this._dataIndexList[FIRST_INDEX]  = 0;	
				this._dataIndexList[SECOND_INDEX] = 0;	
				this._arrayTypeObj.SetDataIndexList(this._dataIndexList);

				this.Bind_DataSet.Tables[FIRST_INDEX].Clear();
				this.Bind_DataSet.Tables[SECOND_INDEX].Clear();
				
				int customercode  = this.CustomerCode_tNedit.GetInt();
                int claimcode     = this.ClaimCode_tNedit.GetInt();

                this._arrayTypeObj.TargetCustomerCode = customercode;
                this._arrayTypeObj.TargetClaimCode = claimcode;

                // 選択顧客の売掛・請求の前情報を取得する
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                // 指定区分の値を渡すように変更
                //this._arrayTypeObj.DmdRec_Data_Search(claimcode, customercode, secCode);
                //this._arrayTypeObj.AccRec_Data_Search(claimcode, customercode, secCode);

                //this._arrayTypeObj.DmdRec_Data_Search(claimcode, customercode, secCode, this.TargetDiv_tComboEditor.SelectedIndex);
                //this._arrayTypeObj.AccRec_Data_Search(claimcode, customercode, secCode, this.TargetDiv_tComboEditor.SelectedIndex);
                this._arrayTypeObj.DmdRec_Data_Search(_targetClaimCode, _targetCustomerCode, _targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                this._arrayTypeObj.AccRec_Data_Search(_targetClaimCode, _targetCustomerCode, _targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

				// ステータスバー件数表示処理
				this.StatusBarCountIndication();

				if (this.Acc_Grid.Rows.Count > 0)
				{
					this.Acc_Grid.ActiveRow = this.Acc_Grid.Rows[0];
					this.Acc_Grid.ActiveRow.Selected = true;
				}

				if (this.Dmd_Grid.Rows.Count > 0)
				{
					this.Dmd_Grid.ActiveRow = this.Dmd_Grid.Rows[0];
					this.Dmd_Grid.ActiveRow.Selected = true;
				}	

				this._arrayTypeObj.SectionCodeData = secCode.Trim();
				// 有効なTABの情報で表示する
				ultraTabControl1_Click(sender, null);
			}
		}

		/// <summary>修正ボタンイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 修正ボタンが選択された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Modify_Button_Click(object sender, System.EventArgs e)
		{
			if ((this.ultraToolbarsManager1.Tools["Modify_ControlContainerTool"].SharedProps.Visible == false) ||
				((bool)this.Modify_Button.Tag == false))
			{
				return;
			}

			//if ( this.SecCode_tComboEditor.SelectedIndex == -1 ) return;
            if (this.tNedit_SectionCode.Text.Trim().Length == 0)
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
                this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
                return;
            }
            // 得意先未設定の時は新規不可 
            if (this.CustomerCode_tNedit.GetInt() == 0)
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
                this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
                return;
            }
	
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;

			switch (this._targetData)
			{
				case (TargetData.First):
				{
					targetGrid = Acc_Grid;
					break;
				}
				case (TargetData.Second):
				{
					targetGrid = Dmd_Grid;
					break;
				}
				default:
				{
					return;
				}
			}

			//this._arrayTypeObj.SectionCodeData = this.SecCode_tComboEditor.SelectedItem.DataValue.ToString();
            this._arrayTypeObj.SectionCodeData = this.tNedit_SectionCode.Text.Trim();

			if (targetGrid.ActiveRow == null)
			{
				return;
			}

			if (targetGrid.ActiveRow.IsFilteredOut == true)
			{
				return;
			}

			CurrencyManager cm1 = (CurrencyManager)BindingContext[this.Acc_Grid.DataSource];
			CurrencyManager cm2 = (CurrencyManager)BindingContext[this.Dmd_Grid.DataSource];

			this._dataIndexList[FIRST_INDEX]  = cm1.Position;
			this._dataIndexList[SECOND_INDEX] = cm2.Position;	

			this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
			this._arrayTypeObj.CanClose = false;

			if (this._targetData == TargetData.First)
			{
				this._arrayTypeObj.TargetTableName = this._tableNameList[FIRST_INDEX];
			}
			else if (this._targetData == TargetData.Second)
			{
				this._arrayTypeObj.TargetTableName = this._tableNameList[SECOND_INDEX];
			}

			Form customForm = (Form)this._arrayTypeObj;
            ((MAKAU09110UB)customForm).InvokerForm = this;
			customForm.StartPosition = FormStartPosition.CenterScreen;

			if (customForm.Visible == true)
			{
				customForm.Hide();
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            MAKAU09110UB bForm = (MAKAU09110UB)customForm;

            // 指定区分をセット
            bForm.TargetDivType = this.TargetDiv_tComboEditor.SelectedIndex;

            // 管理営業所コードをセット
            bForm.MngSectionCode = this._mngSectionCode;
            bForm.TargetClaimCode = this._targetClaimCode;
            bForm.TargetCustomerCode = this._targetCustomerCode;
            bForm.SectionCodeData = this._targetSectionCode.Trim();

            // 得意先情報を取得させる
            bForm.GetSettledCustomerData();
            //bForm.update_TtlBl_Label();

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
            this._controlScreenSkin.SettingScreenSkin(customForm);  // 2009.01.06 Add
			customForm.Show(this);
		}

		/// <summary>詳細ボタンイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 詳細ボタンが選択された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Details_Button_Click(object sender, System.EventArgs e)
		{
			//  詳細情報を表示する
            if (this.claim_panel.Visible == false)
            {
                this.claim_panel.Visible = true;
            }
            else
            {
                this.claim_panel.Visible = false;
            }
		}

        /// <summary>新規ボタンイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 新規ボタンが選択された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void New_Button_Click(object sender, System.EventArgs e)
		{
			if ((this.ultraToolbarsManager1.Tools["New_ControlContainerTool"].SharedProps.Visible == false) ||
				((bool)this.New_Button.Tag == false))
			{
				return;
			}

            // 拠点未設定の時は新規不可 
            //if (this.SecCode_tComboEditor.SelectedIndex == -1) return;
            if (this.tNedit_SectionCode.Text.Trim().Length == 0)
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
                this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
                return;
            }
            // 得意先未設定の時は新規不可 
            if (this.CustomerCode_tNedit.GetInt() == 0)
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
                this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "拠点・得意先を設定して下さい。";
                return;
            }
            
            if (this._targetData == TargetData.First)
			{
				this._arrayTypeObj.TargetTableName = this._tableNameList[FIRST_INDEX];
				this._dataIndexList[FIRST_INDEX] = -1;
			}
			else if (this._targetData == TargetData.Second)
			{
				this._arrayTypeObj.TargetTableName = this._tableNameList[SECOND_INDEX];
				this._dataIndexList[SECOND_INDEX] = -1;
			}

			this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
			this._arrayTypeObj.CanClose = false;

			//this._arrayTypeObj.SectionCodeData = this.SecCode_tComboEditor.SelectedItem.DataValue.ToString();
            this._arrayTypeObj.SectionCodeData = this.tNedit_SectionCode.Text.Trim();
			
			Form customForm = (Form)this._arrayTypeObj;
			customForm.StartPosition = FormStartPosition.CenterScreen;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            MAKAU09110UB bForm = (MAKAU09110UB)customForm;

            // 指定区分をセット
            bForm.TargetDivType = this.TargetDiv_tComboEditor.SelectedIndex;

            // 管理営業所コードをセット
            bForm.MngSectionCode = this._mngSectionCode;
            bForm.TargetClaimCode = this._targetClaimCode;
            bForm.TargetCustomerCode = this._targetCustomerCode;
            bForm.SectionCodeData = this._targetSectionCode.Trim();

            bForm.InvokerForm = this;

            // 得意先情報を取得させる
            bForm.GetSettledCustomerData();

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END


			// 既にフォームが表示されている場合は、一旦終了させる
			if (customForm.Visible == true)
			{
				customForm.Hide();
			}
            this._controlScreenSkin.SettingScreenSkin(customForm);  // 2009.01.06 Add
			customForm.Show(this);
		}

        /// <summary>タブ選択イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : タブが選択された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ultraTabControl1_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
			switch (ultraTabControl1.ActiveTab.Key)

			{
				case "campanyTab" :
				{
					ActiveControl = this.Acc_Grid;
					this._targetData = TargetData.First;
					targetGrid = this.Acc_Grid;
                    this.BlDmdTitle_Label.Text = "売掛残高";
					break;
				}
				case "customerTab":
				{
					ActiveControl = this.Dmd_Grid;
					this._targetData = TargetData.Second;
					targetGrid = this.Dmd_Grid;
                    this.BlDmdTitle_Label.Text = "請求残高";
                    break;
				}
				default:
				{
					return;
				}
			}
			claim_panelInfoSet(targetGrid);
		}

        /// <summary>閉じるボタンイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンが選択された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Close_Button_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        /// <summary>Leave  イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : アクティブコントロールでなくなった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------</br>
        /// <br>Modify At  : 2008.06.20</br>
        /// <br>Modifier   : 30417 徳永 俊詞</br>
        /// <br>Details    : 指定区分の値により、入力できる得意先の種類を判定するコードを追加</br>
        /// </remarks>
		private void CustomerCode_tNedit_Leave(object sender, System.EventArgs e)
		{
			// 得意先情報取得
			if (this._changeFlg == false ) return;
			int customerCode = 0;
			customerCode = this.CustomerCode_tNedit.GetInt();

            //if (!this.SecCode_tComboEditor.IsItemInList())
            if (this.tNedit_SectionCode.Text.Trim().Length == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "得意先を選択する前に、拠点を選択してください。",
                0,
                MessageBoxButtons.OK);

                // 項目をクリア
                ScreenClear();
                this.CustomerSnm_Label.Text = "";
                // 2008.12.05 add start [8814]
                this.tNedit_SectionCode.Focus();
                // 2008.12.05 add end [8814]

                return;
            }
			
			Form customForm = (Form)this._arrayTypeObj;
			if ((this._arrayTypeObj.TargetCustomerCode != customerCode) && (customForm.Visible == true))
			{
				customForm.Hide();
			}

			if( customerCode == 0 ) 
			{
				ScreenClear();
                this.CustomerSnm_Label.Text = "";

                CustomerSearchRet customerRet = new CustomerSearchRet();
				this._arrayTypeObj.ReadCustomerData(out customerRet ,customerCode);
				this._arrayTypeObj.TargetCustomerCode = 0;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                this._arrayTypeObj.TargetClaimCode = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			}
			else
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                // 得意先を変更すると拠点がクリアされる仕様をクリアしないように変更
				//ScreenClear();
                //this.CustomerSnm_Label.Text = "";

                // 各種関数戻り値受け皿
                int status;                 // 戻り値
                int claimCode;              // 請求先コード
                string claimSectionCode;    // 請求拠点コード
                string secCode;             // 画面上の拠点コード
                
                // 得意先コード種別を判定するため、入力（または選択）された得意先コードから得意先情報を取得する
                CustomerInfo customerInfo;
                status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (customerInfo != null)
                {

                    claimCode = customerInfo.ClaimCode;                         // 請求先コード
                    claimSectionCode = customerInfo.ClaimSectionCode.Trim();    // 請求拠点コード

                    // 画面上の拠点コードを取得
                    //secCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                    secCode = this.tNedit_SectionCode.Text.Trim();

                    //// 入力された得意先コードに紐づく請求先コードから得意先情報を取得
                    //CustomerInfo customerInfo2;
                    //status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerInfo.ClaimCode, out customerInfo2);

                    // xxxx管理営業所コードを保存
                    //_mngSectionCode = customerInfo2.MngSectionCode;

                    // 得意先の請求拠点コードを保存
                    _mngSectionCode = claimSectionCode;

                    // 入力得意先先コードの整合性チェック
                    if (this.TargetDiv_tComboEditor.SelectedIndex == TARGET_DIV_CLAIM)
                    {

                        // 指定区分が[請求先]

                        // 親得意先のみ入力可能
                        // 親得意先条件：[得意先コードと請求先コードが一致]かつ[画面上の拠点コードと請求拠点が一致]
                        if ((customerCode != claimCode) || (claimSectionCode != secCode))
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "指定区分が「請求先」の時は、親得意先コードのみ入力可能です。",
                            0,
                            MessageBoxButtons.OK);

                            // 項目をクリア
                            ScreenClear();
                            this.CustomerCode_tNedit.Focus();
                            this.CustomerSnm_Label.Text = "";

                            return;
                        }
                        #region del
                        //// 画面上の選択された拠点コードを取得
                        //string secCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;

                        //// 指定区分が請求先（親得意先のみ入力可能）
                        //// 親得意先：得意先情報の「得意先コード」＝「請求先コード」
                        //// 　　　　　「画面上の拠点コード」＝「請求拠点コード」
                        ////xxxx 　　　　　「画面上の拠点コード」＝「請求先の管理営業所コード」

                        ////if (!customerInfo2.MngSectionCode.Equals(secCode) &&
                        //if (!customerInfo.ClaimSectionCode.Equals(secCode) &&
                        //    !customerInfo.ClaimCode.Equals(customerCode))
                        ////if (!customerInfo.ClaimCode.Equals(customerCode))
                        //{
                        //    TMsgDisp.Show(
                        //    this,
                        //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //    this.Name,
                        //    "指定区分が「請求先」の時は、親得意先コードのみ入力可能です。",
                        //    0,
                        //    MessageBoxButtons.OK);

                        //    // 項目をクリア
                        //    ScreenClear();
                        //    this.CustomerSnm_Label.Text = "";

                        //    return;
                        //}
                        #endregion // del
                    }
                    else
                    {
                        // 指定区分が[得意先]

                        // 2009.01.06 Del >>>
                        //// 子得意先のみ入力可能
                        //// 子得意先条件：[得意先コードと請求先コードが異なる]または[画面上の拠点コードと請求拠点が異なる]
                        //if ((customerCode == claimCode) && (claimSectionCode == secCode))
                        //{
                        //    TMsgDisp.Show(
                        //    this,
                        //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //    this.Name,
                        //    "指定区分が「得意先」の時は、子得意先コードのみ入力可能です。",
                        //    0,
                        //    MessageBoxButtons.OK);

                        //    // 項目をクリア
                        //    ScreenClear();
                        //    this.CustomerCode_tNedit.Focus();
                        //    this.CustomerSnm_Label.Text = "";

                        //    return;
                        //}
                        // 2009.01.06 Del <<<

                        //// 指定区分が得意先（子得意先のみ入力可能）
                        //// 子得意先：得意先情報の「得意先コード」≠「請求先コード」または
                        //// 　　　　　「得意先の管理営業所コード」≠「請求先の管理営業所コード」
                        //// xxx　　　　　「得意先の管理営業所コード」≠「請求先の管理営業所コード」
                        //if (!customerInfo.ClaimCode.Equals(customerCode) ||
                        //    !customerInfo2.MngSectionCode.Equals(customerInfo.MngSectionCode))
                        //{
                        //    TMsgDisp.Show(
                        //    this,
                        //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //    this.Name,
                        //    "指定区分が「得意先」の時は、子得意先コードのみ入力可能です。",
                        //    0,
                        //    MessageBoxButtons.OK);

                        //    // 項目をクリア
                        //    ScreenClear();
                        //    this.CustomerSnm_Label.Text = "";

                        //    return;
                        //}
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

                    CustomerSearchRet customerRet = new CustomerSearchRet();
                    this._arrayTypeObj.ReadCustomerData(out customerRet, customerCode);

                    if (customerRet != null)
                    {
                        this.CustomerCode_tNedit.SetInt(customerCode);
                        this.CustomerName_Label.Text = customerRet.Name;
                        this.CustomerName2_Label.Text = customerRet.Name2;
                        this.CustomerSnm_Label.Text = customerRet.Snm;
                        this.TotalDay_Label.Text = customerRet.TotalDay.ToString();

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //CustomerInfo customerInfo;
                        //int
                        status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerRet.EnterpriseCode, customerRet.CustomerCode, true, out customerInfo);

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
                        this.ClaimCode_tNedit.SetInt(customerInfo.ClaimCode);
                        this.ClaimName_Label.Text = customerInfo.ClaimName;
                        this.ClaimName2_Label.Text = customerInfo.ClaimName2;
                        this.ClaimSnm_Label.Text = customerInfo.ClaimSnm;


                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
                        if (this.TargetDiv_tComboEditor.SelectedIndex == TARGET_DIV_CLAIM)
                        {
                            if (this._targetData == TargetData.First)
                            {
                                // 「請求先」かつ「売掛」の場合
                                // 得意先コード = 画面得意先コード
                                // 請求先コード = 画面得意先コード
                                // 計上拠点コード = 画面拠点コード
                                _targetClaimCode = customerCode;
                                _targetCustomerCode = customerCode;
                                //_targetSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                                _targetSectionCode = this.tNedit_SectionCode.Text.Trim();
                                //this._arrayTypeObj.TargetClaimCode = customerCode;
                                //this._arrayTypeObj.TargetCustomerCode = customerCode;
                                //this._arrayTypeObj.SectionCodeData = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                                //((MAKAU09110UB)this._arrayTypeObj).MngSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                            }
                            else
                            {
                                // 「請求先」かつ「請求」の場合
                                // 得意先コード = 画面得意先コード
                                // 請求先コード = 画面得意先コード
                                // 計上拠点コード = 画面拠点コード
                                // 実績拠点コード = 画面拠点コード
                                _targetClaimCode = customerCode;
                                _targetCustomerCode = customerCode;
                                //_targetSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                                _targetSectionCode = this.tNedit_SectionCode.Text.Trim();
                                _mngSectionCode = this.tNedit_SectionCode.Text.Trim();
                                //_mngSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                                //this._arrayTypeObj.TargetCustomerCode = customerCode;
                                //this._arrayTypeObj.TargetClaimCode = customerCode;
                                //this._arrayTypeObj.SectionCodeData = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                                //((MAKAU09110UB)this._arrayTypeObj).MngSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                            }
                        }
                        else
                        {
                            if (this._targetData == TargetData.First)
                            {
                                // 「得意先」かつ「売掛」の場合
                                // 得意先コード = 画面得意先コード
                                // 請求先コード = 得意先に対する請求先コード
                                // 計上拠点コード = 請求拠点コード
                                _targetClaimCode = customerInfo.ClaimCode;
                                _targetCustomerCode = customerCode;
                                _targetSectionCode = customerInfo.ClaimSectionCode;
                                //this._arrayTypeObj.TargetCustomerCode = customerCode;
                                //this._arrayTypeObj.TargetClaimCode = customerInfo.ClaimCode;
                                //((MAKAU09110UB)this._arrayTypeObj).MngSectionCode = customerInfo2.MngSectionCode;
                                //this._arrayTypeObj.SectionCodeData = (string)this.SecCode_tComboEditor.SelectedItem.DataValue; 
                            }
                            else
                            {
                                // 「得意先」かつ「請求」の場合
                                // 得意先コード = 画面得意先コード
                                // 請求先コード = 得意先に対する請求先コード
                                // 計上拠点コード = 請求拠点コード
                                // 実績拠点コード = 画面拠点コード
                                _targetClaimCode = customerInfo.ClaimCode;
                                _targetCustomerCode = customerCode;
                                _targetSectionCode = customerInfo.ClaimSectionCode;
                                //_mngSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                                _mngSectionCode = this.tNedit_SectionCode.Text.Trim();
                                //this._arrayTypeObj.TargetCustomerCode = customerCode;
                                //this._arrayTypeObj.TargetClaimCode = customerInfo.ClaimCode;
                                //((MAKAU09110UB)this._arrayTypeObj).MngSectionCode = customerInfo2.MngSectionCode;
                                //this._arrayTypeObj.SectionCodeData = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                            }
                            ((MAKAU09110UB)this._arrayTypeObj).CondClaimCode = _targetClaimCode;
                            ((MAKAU09110UB)this._arrayTypeObj).CondCustomerCode = _targetCustomerCode;
                            ((MAKAU09110UB)this._arrayTypeObj).CondSectionCode = _targetSectionCode;
                        }

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                        // ADD 2009/04/06 ------>>>
                        // nullエラーが発生することがあるので移動
                        if (customerRet.CustomerCode != 0)
                        {
                            // 情報取得処理
                            GetList();
                        }
                        // ADD 2009/04/06 ------<<<
                    }

                    // DEL 2009/04/06 ------>>>
                    // nullエラーが発生することがあるので移動
                    //if (customerRet.CustomerCode != 0)
                    //{
                    //    // 情報取得処理
                    //    //SecCode_tComboEditor_ValueChanged(sender, e);
                    //    GetList();
                    //}
                    // DEL 2009/04/06 ------<<<
                }
                else
                {
                    CustomerSearchRet customerRet = new CustomerSearchRet();
                    this._arrayTypeObj.ReadCustomerData(out customerRet, customerCode);
                    this._arrayTypeObj.TargetCustomerCode = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    this._arrayTypeObj.TargetClaimCode = 0;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "登録されていない得意先コードです。", 0, MessageBoxButtons.OK);
                    //this.CustomerCode_tNedit.Text = "";

                    // 不正な得意先コードの場合はクリア
                    this.CustomerCode_tNedit.Clear();
                    this.CustomerSnm_Label.Text = string.Empty;
                    // 締め日もクリア
                    this.TotalDay_Label.Text = string.Empty;

                    this.CustomerCode_tNedit.Focus();
                    return;
                }
			}
            
            // ステータスバー件数表示処理
            this.StatusBarCountIndication();
            // 有効なTABの情報で表示する
            ultraTabControl1_Click(sender, e);
		}

        /// <summary>Enter イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : アクティブコントロールになった時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void CustomerCode_tNedit_Enter(object sender, System.EventArgs e)
		{
			this._changeFlg = false;
		}

		/// <summary>ValueChanged イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールの値が変更された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void CustomerCode_tNedit_ValueChanged(object sender, System.EventArgs e)
		{
			this._changeFlg = true;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        /// <summary>
        /// 指定区分ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 得意先コードが入力されていた場合
            if (this.CustomerCode_tNedit.Text.Trim().Length > 0)
            {
                // 入力されているということは、指定区分と一致している
                // 指定区分を変更すると、必ず得意先コードは指定先区分の条件に違反する
                // 指定区分「請求先」：親得意先コードのみ
                // 　　　　「得意先」：子得意先コードのみ
                // 得意先コードをクリアするか聞く
                if (TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "指定区分が変更されると、現在入力されている得意先がクリアされます。",
                        0,
                        MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    // 反対の選択肢をセット
                    if (this.TargetDiv_tComboEditor.SelectedIndex == TARGET_DIV_CLAIM)
                    {
                        this.TargetDiv_tComboEditor.SelectedIndex = TARGET_DIV_CUSTOMER;
                    }
                    else
                    {
                        this.TargetDiv_tComboEditor.SelectedIndex = TARGET_DIV_CLAIM;
                    }
                }
                else
                {
                    // 項目をクリア
                    ScreenClear();
                    this.CustomerSnm_Label.Text = "";
                }

            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

		/// <summary>ガイドボタン イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ガイドボタンが選択された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Customer_Guide_Button_Click(object sender, System.EventArgs e)
		{
			// 得意先ガイド
            Infragistics.Win.Misc.UltraButton _pushBtn = (Infragistics.Win.Misc.UltraButton)sender;
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            //this._changeFlg = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
            this.CustomerCode_tNedit_Leave(sender, e);
        }

        /// <summary>得意先選択時発生イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);
                this.CustomerName_Label.Text = "";
                this.CustomerName2_Label.Text = "";
                this.CustomerSnm_Label.Text = "";
                this.TotalDay_Label.Text = "";
                return;
            }
            else
            {
                TMsgDisp.Show(this,
                              emErrorLevel.ERR_LEVEL_STOPDISP,
                              this.Name,
                              "得意先情報の取得に失敗しました。",
                              status,
                              MessageBoxButtons.OK);
                this.CustomerName_Label.Text = "";
                this.CustomerName2_Label.Text = "";
                this.CustomerSnm_Label.Text = "";
                this.TotalDay_Label.Text = "";
                return;
            }

            this.CustomerCode_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
            this.CustomerName_Label.Text = customerInfo.Name;
            this.CustomerName2_Label.Text = customerInfo.Name2;
            this.CustomerSnm_Label.Text = customerInfo.CustomerSnm;
            this.TotalDay_Label.Text = customerInfo.TotalDay.ToString();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.ClaimCode_tNedit.Text = customerInfo.ClaimCode.ToString().Trim();
            this.ClaimName_Label.Text = customerInfo.ClaimName;
            this.ClaimName2_Label.Text = customerInfo.ClaimName2;
            this.ClaimSnm_Label.Text = customerInfo.ClaimSnm;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            if (!String.IsNullOrEmpty(this.tNedit_SectionCode.Text))
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "";
            }
        }

        /// <summary>ソートチェンジイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : グリッドのソートアクションの完了後に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_AfterSortChange(object sender, Infragistics.Win.UltraWinGrid.BandEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// 選択行を先頭に配置する
			if (targetGrid.Rows.Count > 0)
			{
				targetGrid.ActiveRow = targetGrid.Rows[0];
				targetGrid.ActiveRow.Selected = true;
				targetGrid.Refresh();
			}
		}

        /// <summary>AfterSelectChange イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : １つ以上の行、セル、または列オブジェクトが選択または選択解除された後に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			// 捜査対象グリッドが異なり、行ポジションが変更された場合は、子画面を強制的に非表示とする
			string targetTableName = "";
			Form customForm = (Form)this._arrayTypeObj;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			if (this._targetData == TargetData.First)
			{
				targetTableName = this._tableNameList[FIRST_INDEX];
			}
			if (this._targetData == TargetData.Second)
			{
				targetTableName = this._tableNameList[SECOND_INDEX];
			}

			if ((this._arrayTypeObj.TargetTableName != targetTableName) && (customForm.Visible == true))
			{
				customForm.Hide();
			}

			CurrencyManager cm = (CurrencyManager)BindingContext[targetGrid.DataSource];

			if (this._targetData == TargetData.First)
			{
				this._dataIndexList[FIRST_INDEX] = cm.Position;	
			}
			if (this._targetData == TargetData.Second)
			{
				this._dataIndexList[SECOND_INDEX] = cm.Position;	
			}

			this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
		}

		/// <summary>KeyDownイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : キーが押された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case (Keys.Return):
				{
					Modify_Button_Click(Modify_Button, e);

					break;
				}
				case (Keys.Tab):
				{
					switch (this._targetData)
					{
						case (TargetData.First):
						{
							this.ActiveControl = this.Dmd_Grid;
							break;
						}
						case (TargetData.Second):
						{
							this.ActiveControl = this.Acc_Grid;
							break;
						}
						default:
						{
							return;
						}
					}

					break;
				}
			}
		}

        /// <summary>Enter イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : グリッドが選択された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_Enter(object sender, System.EventArgs e)
		{
			this._targetData = TargetData.First;	
			this.ButtonEnabledControl(this._targetData);
			this.SFCMN09000UE_VisibleChanged(this, new EventArgs());
		}

        /// <summary>Enter イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : グリッドが選択された時に発生します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Dmd_Grid_Enter(object sender, System.EventArgs e)
		{
			this._targetData = TargetData.Second;	
			this.ButtonEnabledControl(this._targetData);
			this.SFCMN09000UE_VisibleChanged(this, new EventArgs());
		}

        /// <summary>CheckedChanged	イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 列のサイズを自動調整するチェックエディタコントロールのChecked
		///	                 プロパティが変更されるときに発生します。
		///	                 グリッド列のAutoResizeメソッドを実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AutoFillToSecondGridColumn_CheckedChanged(object sender, System.EventArgs e)
		{
			bool result =  this.AutoFillToSecondGridColumn_CheckEditor.Checked;
            if (result == false)
                this.Dmd_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            else
                this.Dmd_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            if (this.AutoFillToSecondGridColumn_CheckEditor.Checked == false)
			{
				for (int i = 0; i < this.Dmd_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					this.Dmd_Grid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
				}
			}
		}

        /// <summary>CheckedChanged	イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 列のサイズを自動調整するチェックエディタコントロールのChecked
		///	                 プロパティが変更されるときに発生します。
		///	               　グリッド列のAutoResizeメソッドを実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AutoFillToFirstGridColumn_CheckedChanged(object sender, System.EventArgs e)
		{
			bool result =  this.AutoFillToFirstGridColumn_CheckEditor.Checked;
            if (result == false)
                this.Acc_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            else
                this.Acc_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            if (this.AutoFillToFirstGridColumn_CheckEditor.Checked == false)
			{
				for (int i = 0; i < this.Acc_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					this.Acc_Grid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
				}
			}
		}

        /// <summary>タイマーイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 終了処理時に実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Close_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Close_Timer.Enabled = false;

			if (this._underExtractionFlg == false)
			{	
				Form customForm = (Form)this._arrayTypeObj;
				customForm.Close();
				this.Close();
			}
			else
			{
				this.Close_Timer.Enabled = true;
			}
		}

        /// <summary>
        /// 拠点コード変換処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_SectionCode_Leave(object sender, EventArgs e)
        {
            // 2008.11.18 del start [7894]
            //// 拠点コード入力値を取得
            //int sectionCd = this.tNedit_SectionCode.GetInt();
            //string sectionCode = this.tNedit_SectionCode.Text.Trim().PadLeft(2, '0');
            //int status = 0;

            //// 拠点コードが入力されている場合のみ変換
            //if (sectionCd == 0)
            //{
            //    // 警告を出す？
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //    "拠点コードは必須入力です。", -1, MessageBoxButtons.OK);
            //    this.tNedit_SectionCode.Clear();
            //    this.tEdit_SectionName.Clear();

            //    //2008.11.13 del start [7745]
            //    //this.tNedit_SectionCode.Focus();
            //    //2008.11.13 del end [7745]
            //    return;
            //}
            //else //if (!String.IsNullOrEmpty(sectionCode))
            //{
            //    SecInfoSet sectionInfo;
            //    status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();

            //        if (!String.IsNullOrEmpty(this.CustomerCode_tNedit.Text.Trim()))
            //        {
            //            this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "。";
            //        }
            //    }
            //    else
            //    {
            //        // 警告を出す？
            //        TMsgDisp.Show(
            //                  this,
            //                  emErrorLevel.ERR_LEVEL_INFO,
            //                  this.Name,
            //                  "入力された拠点は存在しません。",
            //                  -1,
            //                  MessageBoxButtons.OK);
            //        this.tNedit_SectionCode.Clear();
            //        this.tEdit_SectionName.Clear();
            //        this.tNedit_SectionCode.Focus();
            //        return;
            //    }
            //}

            //// 0詰めの拠点コードをセット
            //this.tNedit_SectionCode.Text = sectionCode;
            //int customerCode = this.CustomerCode_tNedit.GetInt();
            //if (customerCode > 0)
            //{
            //    GetList();
            //    //CustomerInfo customerInfo;
            //    //status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

            //    //if (this.TargetDiv_tComboEditor.SelectedIndex == TARGET_DIV_CLAIM)
            //    //{
            //    //    if (this._targetData == TargetData.First)
            //    //    {
            //    //        // 「請求先」かつ「売掛」の場合
            //    //        // 得意先コード = 画面得意先コード
            //    //        // 請求先コード = 画面得意先コード
            //    //        // 計上拠点コード = 画面拠点コード
            //    //        _targetClaimCode = customerCode;
            //    //        _targetCustomerCode = customerCode;
            //    //        _targetSectionCode = this.tNedit_SectionCode.Text.Trim();
            //    //    }
            //    //    else
            //    //    {
            //    //        // 「請求先」かつ「請求」の場合
            //    //        // 得意先コード = 画面得意先コード
            //    //        // 請求先コード = 画面得意先コード
            //    //        // 計上拠点コード = 画面拠点コード
            //    //        // 実績拠点コード = 画面拠点コード
            //    //        _targetClaimCode = customerCode;
            //    //        _targetCustomerCode = customerCode;
            //    //        _targetSectionCode = this.tNedit_SectionCode.Text.Trim();
            //    //        _mngSectionCode = this.tNedit_SectionCode.Text.Trim();
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    if (this._targetData == TargetData.First)
            //    //    {
            //    //        // 「得意先」かつ「売掛」の場合
            //    //        // 得意先コード = 画面得意先コード
            //    //        // 請求先コード = 得意先に対する請求先コード
            //    //        // 計上拠点コード = 請求拠点コード
            //    //        _targetClaimCode = customerInfo.ClaimCode;
            //    //        _targetCustomerCode = customerCode;
            //    //        _targetSectionCode = customerInfo.ClaimSectionCode;
            //    //    }
            //    //    else
            //    //    {
            //    //        // 「得意先」かつ「請求」の場合
            //    //        // 得意先コード = 画面得意先コード
            //    //        // 請求先コード = 得意先に対する請求先コード
            //    //        // 計上拠点コード = 請求拠点コード
            //    //        // 実績拠点コード = 画面拠点コード
            //    //        _targetClaimCode = customerInfo.ClaimCode;
            //    //        _targetCustomerCode = customerCode;
            //    //        _targetSectionCode = customerInfo.ClaimSectionCode;
            //    //        _mngSectionCode = this.tNedit_SectionCode.Text.Trim();
            //    //    }
            //    //    ((MAKAU09110UB)this._arrayTypeObj).CondClaimCode = _targetClaimCode;
            //    //    ((MAKAU09110UB)this._arrayTypeObj).CondCustomerCode = _targetCustomerCode;
            //    //    ((MAKAU09110UB)this._arrayTypeObj).CondSectionCode = _targetSectionCode;

                    
            //    //}
            //}
            // 2008.11.18 del end [7894]
            
        }

        /// <summary>
        /// 拠点ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCode.Text = sectionInfo.SectionCode.TrimEnd();
                // 2009.01.14 >>>
                //this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                this.SectionName_Label.Text = sectionInfo.SectionGuideNm.TrimEnd();
                // 2009.01.14 <<<
                // 2008.11.25 add start [8221]
                this.CustomerCode_tNedit.Focus();
                // 2008.11.25 del end [8221]
            }
            else
            {
                // 2008.11.25 del start [8221]
                //this.tNedit_SectionCode.Clear();
                //this.tEdit_SectionName.Clear();
                // 2008.11.25 del end [8221]
            }
        }

        /// <summary>
        /// リスト更新処理
        /// </summary>
        private void GetList()
        {
            // 現在選択されている拠点の情報を取得する
            string secCode = this.tNedit_SectionCode.Text.Trim().PadLeft(2, '0');

            Form customForm = (Form)this._arrayTypeObj;
            MAKAU09110UB mForm = (MAKAU09110UB)customForm;
            mForm.MngSectionCode = secCode;

            if ((this._arrayTypeObj.SectionCodeData != secCode) && (customForm.Visible == true))
            {
                customForm.Hide();
            }

            // 鑑情報の画面情報のクリア
            claim_panel_Clear();

            if (this.CustomerCode_tNedit.GetInt() != 0)
            {
                this._dataIndexList[FIRST_INDEX] = 0;
                this._dataIndexList[SECOND_INDEX] = 0;
                this._arrayTypeObj.SetDataIndexList(this._dataIndexList);

                this.Bind_DataSet.Tables[FIRST_INDEX].Clear();
                this.Bind_DataSet.Tables[SECOND_INDEX].Clear();

                int customercode = this.CustomerCode_tNedit.GetInt();
                int claimcode = this.ClaimCode_tNedit.GetInt();

                this._arrayTypeObj.TargetCustomerCode = customercode;
                this._arrayTypeObj.TargetClaimCode = claimcode;

                // 選択顧客の売掛・請求の前情報を取得する
                this._arrayTypeObj.DmdRec_Data_Search(_targetClaimCode, _targetCustomerCode, _targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                this._arrayTypeObj.AccRec_Data_Search(_targetClaimCode, _targetCustomerCode, _targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);

                // ステータスバー件数表示処理
                this.StatusBarCountIndication();

                if (this.Acc_Grid.Rows.Count > 0)
                {
                    this.Acc_Grid.ActiveRow = this.Acc_Grid.Rows[0];
                    this.Acc_Grid.ActiveRow.Selected = true;
                }

                if (this.Dmd_Grid.Rows.Count > 0)
                {
                    this.Dmd_Grid.ActiveRow = this.Dmd_Grid.Rows[0];
                    this.Dmd_Grid.ActiveRow.Selected = true;
                }

                this._arrayTypeObj.SectionCodeData = secCode.Trim();

                // 有効なTABの情報で表示する
                ultraTabControl1_Click(null, null);
            }
        }

        private void MAKAU09110UA_Shown(object sender, EventArgs e)
        {
            this.CustomerCode_tNedit.Focus();
        }

    }

    # endregion
}
